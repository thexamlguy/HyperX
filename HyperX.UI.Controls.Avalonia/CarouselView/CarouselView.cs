using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Rendering.Composition;
using Avalonia.Rendering.Composition.Animations;
using SkiaSharp;
using System;
using System.Linq.Expressions;
using System.Numerics;

namespace HyperX.UI.Controls.Avalonia;

public class CarouselView :
    TemplatedControl
{
    private readonly List<CompositionVisual> itemVisualList = [];
    private readonly List<ExpressionAnimation> animations = [];

    ExpressionAnimation? _animation, _animation_0, _animation_1, _animation_2, _animation_3, _animation_4;
    Vector3DKeyFrameAnimation _indicatorAnimation;
    private Compositor? compositor;
    private Grid? container;
    private float horizontalDelta;
    private Rectangle? indicator;
    private CompositionVisual? indicatorVisual;
    private bool isPressed;
    private List<Grid>? items;
    private Point? lastPosition;
    private int selectedIndex = 2;
    private Point? startPosition;
    private CompositionVisual? touchAreaVisual;
    public int SelectedIndex { get; set; }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs args)
    {
        container = args.NameScope.Get<Grid>("Container");
        if (container is not null)
        {
            touchAreaVisual = ElementComposition.GetElementVisual(container);
            if (touchAreaVisual is not null)
            {
                compositor = touchAreaVisual.Compositor;
            }

            items = container.Children.OfType<Grid>().ToList();
            foreach (Grid item in items)
            {
                if (ElementComposition.GetElementVisual(item) is CompositionVisual visual)
                {
                    itemVisualList.Add(visual);
                }
            }

            container.SizeChanged -= OnContainerSizeChanged;
            container.SizeChanged += OnContainerSizeChanged;
        }

        indicator = args.NameScope.Get<Rectangle>("Indicator");
        if (indicator is not null)
        {
            indicatorVisual = ElementComposition.GetElementVisual(indicator);
        }

        base.OnApplyTemplate(args);
    }

    protected override void OnLoaded(RoutedEventArgs args) =>
        MeasureItems(selectedIndex);

    protected override void OnPointerMoved(PointerEventArgs args)
    {
        if (isPressed && indicatorVisual is not null && startPosition.HasValue)
        {
            lastPosition = args.GetPosition(container);
            horizontalDelta = (float)(lastPosition.Value.X - startPosition.Value.X);

            indicatorVisual.Offset = new Vector3(horizontalDelta, 0.0f, 0.0f);
        }

        base.OnPointerMoved(args);
    }

    protected override void OnPointerPressed(PointerPressedEventArgs args)
    {
        if (!isPressed && indicatorVisual is not null)
        {
            isPressed = true;
            horizontalDelta = 0.0f;

            startPosition = args.GetPosition(container);
            isPressed = true;

            indicatorVisual.Offset = new Vector3(horizontalDelta, 0.0f, 0.0f);

            PrepareAnimations();

            for (int i = 0; i < itemVisualList.Count; i++)
            {
                itemVisualList[i].StartAnimation("Offset", animations[i]);
            }
        }

        base.OnPointerPressed(args);
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs args)
    {
        if (isPressed && container is not null && items is not null && indicatorVisual is not null)
        {
            isPressed = false;

            double itemWidth = items[0].Width;
            double threshold = itemWidth / 4;
            double deltaX = indicatorVisual.Offset.X;

            int oldSelectedIndex = selectedIndex;

            if (deltaX <= -threshold)
            {
                selectedIndex = (selectedIndex + 1) % 5;
                SelectedIndex = (SelectedIndex + 1) % items.Count;
            }
            else if (deltaX >= threshold)
            {
                selectedIndex = (selectedIndex + 4) % 5;
                SelectedIndex = (SelectedIndex + items.Count - 1) % items.Count;
            }

            MeasureItems(selectedIndex, oldSelectedIndex);
        }

        base.OnPointerReleased(args);
    }

    private async void MeasureItems(int newIndex,
        int oldIndex = -1)
    {
        if (container is not null && items is not null)
        {
            double containerWidth = container.Bounds.Width;
            double targetWidth = Math.Min(containerWidth, container.Bounds.Width / 2);

            foreach (var item in items)
            {
                item.Width = targetWidth;
            }

            double centreLeft = (containerWidth - targetWidth) / 2;
            double leftLeft = -targetWidth + centreLeft;
            double rightLeft = containerWidth - centreLeft;

            double[] offsets = [leftLeft - targetWidth, leftLeft, centreLeft, rightLeft, rightLeft + targetWidth];

            if (oldIndex == -1)
            {
                for (int i = 0; i < 5; i++)
                {
                    itemVisualList[(newIndex + i - 2 + 5) % 5].Offset = new Vector3((float)offsets[i], 0, 0);
                }
            }
            else
            {
                int diff = newIndex - oldIndex;
                double duration = 500;
                // new selected item equals to current item
                if (diff == 0)
                {
                    _indicatorAnimation = compositor.CreateVector3DKeyFrameAnimation();
                    _indicatorAnimation.InsertKeyFrame(1.0f, new Vector3D(0, 0, 0));
                    _indicatorAnimation.Duration = TimeSpan.FromMilliseconds(duration);
                }
                // new selected item is the right item of current item
                if (diff == 1 || diff < -1)
                {
                    _indicatorAnimation = compositor.CreateVector3DKeyFrameAnimation();
                    _indicatorAnimation.InsertKeyFrame(1.0f, new Vector3D((float)-targetWidth, 0, 0));
                    _indicatorAnimation.Duration = TimeSpan.FromMilliseconds(duration);
                }
                // new selected item is the left one of current item
                if (diff == -1 || diff > 1)
                {
                    _indicatorAnimation = compositor.CreateVector3DKeyFrameAnimation();
                    _indicatorAnimation.InsertKeyFrame(1.0f, new Vector3D((float)targetWidth, 0, 0));
                    _indicatorAnimation.Duration = TimeSpan.FromMilliseconds(duration);
                }

                indicatorVisual.StartAnimation("Offset", _indicatorAnimation);

                await Task.Delay(500);
                for (int i = 0; i < 5; i++)
                {
                    itemVisualList[(newIndex + i - 2 + 5) % 5].Offset = new Vector3((float)offsets[i], 0, 0);
                }
            }
        }
    }

    private void OnContainerSizeChanged(object? sender,
        SizeChangedEventArgs args)
    {
        MeasureItems(selectedIndex);
    }

    private void PrepareAnimations()
    {
        animations.Clear();

        if (compositor is not null && indicatorVisual is not null && itemVisualList is not null)
        {
            for (int i = 0; i < itemVisualList.Count; i++)
            {
                ExpressionAnimation animation = compositor.CreateExpressionAnimation();

                animation.Expression = $"Source.Offset + Vector3({itemVisualList[i].Offset.X}, 0, 0)";
                animation.SetReferenceParameter("Source", indicatorVisual);
                animations.Add(animation);
            }
        }
    }
}