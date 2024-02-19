namespace HyperX;

public class ViewModelTemplateProvider(IEnumerable<IViewModelTemplateDescriptor> viewModelTemplates) :
    IViewModelTemplateProvider
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
