namespace HyperX;

public interface IViewModelTemplateDescriptor
{
    object Key { get; }

    Type ViewModelType { get; }

    Type ViewType { get; }

    object? GetView();

    object? GetViewModel(object?[]? parameters = null);
}