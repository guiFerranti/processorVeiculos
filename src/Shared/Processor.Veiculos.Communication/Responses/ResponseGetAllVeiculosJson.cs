namespace Processor.Veiculos.Communication.Responses;

public class ResponseGetAllVeiculosJson
{
    public IEnumerable<ResponseGetVeiculoJson> Veiculos { get; set; } = new List<ResponseGetVeiculoJson>();

    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
