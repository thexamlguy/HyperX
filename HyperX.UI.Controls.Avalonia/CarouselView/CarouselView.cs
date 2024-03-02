using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Rendering.Composition;
using Avalonia.Rendering.Composition.Animations;
using SkiaSharp;
using System.Collections.Specialized;
using System.Numerics;

namespace HyperX.UI.Controls.Avalonia;

public class CarouselView :
    ItemsControl
{
    private readonly List<ExpressionAnimation> animations = [];
    private readonly List<CompositionVisual> itemVisuals = [];
    private int newIndex;
    private readonly int columnCount = 5;
    private Compositor? compositor;
    private Grid? container;
    private float horizontalDelta;
    private Rectangle? indicator;
    private Vector3DKeyFrameAnimation? indicatorAnimation;
    private CompositionVisual? indicatorVisual;
    private bool isPressed;
    private List<Border>? items;
    private Point? lastPosition;
    private int SelectedIndex;
    private Point? startPosition;
    private CompositionVisual? touchAreaVisual;

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

            items = container.Children.OfType<Border>().ToList();
            foreach (Border item in items)
            {
                if (ElementComposition.GetElementVisual(item) is CompositionVisual visual)
                {
                    itemVisuals.Add(visual);
                }

                if (item.Child is ContentControl contentControl)
                {
                    contentControl.ContentTemplate = ItemTemplate;
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

        ItemsView.CollectionChanged += OnCollectionChanged;

        base.OnApplyTemplate(args);
    }

    protected override void OnLoaded(RoutedEventArgs args)
    {
        ArrangeItems(newIndex);
        base.OnLoaded(args);
    }

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

            for (int i = 0; i < itemVisuals.Count; i++)
            {
                itemVisuals[i].StartAnimation("Offset", animations[i]);
            }
        }

        base.OnPointerPressed(args);
    }
    protected override void OnPointerReleased(PointerReleasedEventArgs args)
    {
        if (isPressed && container is not null && items is not null && indicatorVisual is not null)
        {
            isPressed = false;

            double itemWidth = items[0].Bounds.Width;
            double threshold = itemWidth / 2;

            int oldSelectedIndex = newIndex;
            double offset = indicatorVisual.Offset.X;

            if (offset <= -threshold)
            {
                newIndex = (newIndex + 1) % 5;
                SelectedIndex = (SelectedIndex + 1) % ItemsView.Count;
            }

            if (offset >= threshold)
            {
                newIndex = (newIndex + 4) % 5;
                SelectedIndex = (SelectedIndex + ItemsView.Count - 1) % ItemsView.Count;
            }

            ArrangeItems(newIndex, oldSelectedIndex);
        }

        base.OnPointerReleased(args);
    }

    private async void ArrangeItems(int newIndex,
        int oldIndex = -1)
    {
        if (compositor is not null && container is not null && items is not null && indicatorVisual is not null)
        {
            double containerWidth = container.Bounds.Width;
            double ContainerHeight = container.Bounds.Height;

            double targetWidth = Math.Min(containerWidth, container.Bounds.Width / 2);
            double targetHeight = ContainerHeight;

            foreach (Border item in items)
            {
                if (item.Child is ContentControl contentControl)
                {
                    contentControl.Width = targetWidth;
                    contentControl.Height = targetHeight;
                }

                item.Width = targetWidth;
                item.Height = targetHeight;
            }

            double centreLeft = (containerWidth - targetWidth) / 2;
            double leftLeft = -targetWidth + centreLeft;
            double rightLeft = containerWidth - centreLeft;

            double[] offsets = [leftLeft - targetWidth, leftLeft, centreLeft, rightLeft, rightLeft + targetWidth];

            if (oldIndex == -1)
            {
                for (int i = 0; i < columnCount; i++)
                {
                    itemVisuals[(newIndex + i - 2 + columnCount) % columnCount].Offset = new Vector3((float)offsets[i], 0, 0);
                }
            }
            else
            {
                int diff = newIndex - oldIndex;
                double duration = 500;
                Vector3D finalOffset = new();

                finalOffset = diff switch
                {
                    0 => new Vector3D(0, 0, 0),
                    1 => new Vector3D((float)-targetWidth, 0, 0),
                    -1 => new Vector3D((float)targetWidth, 0, 0),
                    _ => new Vector3D((float)targetWidth * Math.Sign(diff), 0, 0)
                };

                indicatorAnimation = compositor.CreateVector3DKeyFrameAnimation();
                indicatorAnimation.InsertKeyFrame(1.0f, finalOffset);
                indicatorAnimation.Duration = TimeSpan.FromMilliseconds(duration);

                indicatorVisual.StartAnimation("Offset", indicatorAnimation);

                await Task.Delay(500);
                for (int i = 0; i < columnCount; i++)
                {
                    itemVisuals[(newIndex + i - 2 + columnCount) % columnCount].Offset = new Vector3((float)offsets[i], 0, 0);
                }
            }

            SetItems();
        }
    }

    private void OnCollectionChanged(object? sender,
        NotifyCollectionChangedEventArgs args) => ArrangeItems(newIndex);

    private void OnContainerSizeChanged(object? sender,
        SizeChangedEventArgs args) => ArrangeItems(newIndex);

    private void PrepareAnimations()
    {
        animations.Clear();
        if (compositor is not null && indicatorVisual is not null && itemVisuals is not null)
        {
            for (int i = 0; i < itemVisuals.Count; i++)
            {
                ExpressionAnimation animation = compositor.CreateExpressionAnimation();

                animation.Expression = $"Source.Offset + Vector3({itemVisuals[i].Offset.X}, 0, 0)";
                animation.SetReferenceParameter("Source", indicatorVisual);
                animations.Add(animation);
            }
        }
    }

    private void SetItems()
    {
        if (items is not null)
        {
            int itemCount = ItemsView.Count;
            if (itemCount == 0)
            {
                return;
            }

            int[] selectedIndexOffsets = new int[columnCount];
            int[] indexOffsets = new int[columnCount];

            SelectedIndex = SelectedIndex < 0 ? 0 : SelectedIndex;

            for (int i = -2; i <= 2; i++)
            {
                selectedIndexOffsets[i + 2] = (SelectedIndex + i + itemCount) % itemCount;
                indexOffsets[i + 2] = (newIndex + i + columnCount) % columnCount;
            }

            for (int i = 0; i < columnCount; i++)
            {
                int index = selectedIndexOffsets[i];
                if (itemCount == 1)
                {
                    index = 0;
                }

                if (items[indexOffsets[i]] is Border border && border.Child is ContentControl contentControl)
                {
                    contentControl.Content = ItemsView[index];
                }
            }
        }
    }
}