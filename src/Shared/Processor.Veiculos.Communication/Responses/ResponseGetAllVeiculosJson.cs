namespace Processor.Veiculos.Communication.Responses;

public class ResponseGetAllVeiculosJson
{
    public IEnumerable<ResponseGetVeiculoJson> Veiculos { get; set; } = new List<ResponseGetVeiculoJson>();
}
