namespace HyperX;

public interface IViewModelTemplateProvider
{
    IViewModelTemplateDescriptor? Get(object key);
}
