namespace HyperX;

public interface IViewModelTemplateDescriptor
{
    object Key { get; }

    Type ViewModelType { get; }

    Type ViewType { get; }
}