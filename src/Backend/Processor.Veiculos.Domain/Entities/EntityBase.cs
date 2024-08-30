using System.Text.Json.Serialization;

namespace Processor.Veiculos.Domain.Entities;

public class EntityBase
{
    [JsonPropertyOrder(1)]
    public long Id { get; set; }

    [JsonPropertyOrder(2)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [JsonPropertyOrder(3)]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
