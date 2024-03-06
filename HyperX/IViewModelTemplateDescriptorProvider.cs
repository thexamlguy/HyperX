namespace HyperX;

public interface IViewModelTemplateDescriptorProvider
{
    IViewModelTemplateDescriptor? Get(object key);
}
