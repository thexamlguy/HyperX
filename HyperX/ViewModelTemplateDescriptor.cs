namespace HyperX;

public class ViewModelTemplateDescriptor(object key,
    Type viewModelType, 
    Type viewType,
    params object[]? parameters) :
    IViewModelTemplateDescriptor
{
    public object Key => key;

    public object[]? Parameters => parameters;

    public Type ViewModelType => viewModelType;

    public Type ViewType => viewType;
}