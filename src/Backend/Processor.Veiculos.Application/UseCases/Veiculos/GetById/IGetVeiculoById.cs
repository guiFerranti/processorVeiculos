using Processor.Veiculos.Communication.Responses;

namespace Processor.Veiculos.Application.UseCases.Veiculos.GetById;

public interface IGetVeiculoById
{
    public Task<ResponseGetVeiculoJson> Execute(long id);
}
