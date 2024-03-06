namespace HyperX;

public class ViewModelTemplateDescriptorProvider(IEnumerable<IViewModelTemplateDescriptor> viewModelTemplates) :
    IViewModelTemplateDescriptorProvider
{
    public IViewModelTemplateDescriptor? Get(object key)
    {
        if (viewModelTemplates.FirstOrDefault(x => x.Key.Equals(key))
            is IViewModelTemplateDescriptor viewModelTemplate)
        {
            return viewModelTemplate;
        }

        return default;
    }
}
