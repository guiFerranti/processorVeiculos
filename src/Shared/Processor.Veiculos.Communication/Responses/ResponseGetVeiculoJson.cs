namespace Processor.Veiculos.Communication.Responses;

public class ResponseGetVeiculoJson
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int Ano { get; set; }
    public string Modelo { get; set; }
    public string Marca { get; set; }
    public string ImageUrl { get; set; }
}
