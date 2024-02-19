using Microsoft.Extensions.FileProviders;

namespace HyperX;

public class ConfigurationFile<TConfiguration>(IFileInfo fileInfo) : 
    IConfigurationFile<TConfiguration>
    where TConfiguration :
    class
{
    public IFileInfo FileInfo => fileInfo;
}
