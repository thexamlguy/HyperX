using System.Text.Json.Serialization;

namespace HyperX;

public record ComponentConfiguration
{
    public string? Description { get; set; }

    public string? Name { get; set; }

    [JsonInclude]
    internal Guid Id { get; set; } = Guid.NewGuid();
}