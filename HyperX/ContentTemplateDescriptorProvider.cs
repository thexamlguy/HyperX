namespace HyperX;

public class ContentTemplateDescriptorProvider(IEnumerable<IContentTemplateDescriptor> contentTemplates) :
    IContentTemplateDescriptorProvider
{
    public IContentTemplateDescriptor? Get(object key)
    {
        if (contentTemplates.FirstOrDefault(x => x.Key.Equals(key))
            is IContentTemplateDescriptor viewModelTemplate)
        {
            return viewModelTemplate;
        }

        return default;
    }
}
