namespace HyperX;

public interface IContentTemplateDescriptor
{
    object Key { get; }

    Type ContentType { get; }

    Type TemplateType { get; }
}