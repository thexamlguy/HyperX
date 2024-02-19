using Microsoft.Extensions.FileProviders;

namespace HyperX;

public interface IConfigurationFile<TConfiguration>
    where TConfiguration :
    class
{
    IFileInfo FileInfo { get; }
}
