namespace HyperX;

public interface IContentTemplateDescriptorProvider
{
    IContentTemplateDescriptor? Get(object key);
}
