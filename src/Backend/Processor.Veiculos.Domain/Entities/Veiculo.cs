namespace Processor.Veiculos.Domain.Entities;

public class Veiculo : EntityBase
{
    public int Ano { get; set; }
    public string Modelo { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
}
