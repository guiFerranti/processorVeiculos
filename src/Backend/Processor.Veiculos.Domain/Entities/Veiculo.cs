using System.Text.Json.Serialization;

namespace Processor.Veiculos.Domain.Entities;

public class Veiculo : EntityBase
{
    [JsonPropertyOrder(4)]
    public int Ano { get; set; }

    [JsonPropertyOrder(5)]
    public string Modelo { get; set; } = string.Empty;

    [JsonPropertyOrder(6)]
    public string Marca { get; set; } = string.Empty;
}
