using Processor.Veiculos.Communication.Responses;

namespace Processor.Veiculos.Application.UseCases.Veiculos.GetById;

public interface IGetVeiculoByIdUseCase
{
    public Task<ResponseGetVeiculoJson> Execute(long id);
}
