using Processor.Veiculos.Communication.Requests;
using Processor.Veiculos.Communication.Responses;

namespace Processor.Veiculos.Application.UseCases.Veiculos.Register;

public interface IRegisterVeiculoUseCase
{
    public Task<ResponseRegisteredVeiculoJson> Execute(RequestRegisteredVeiculoJson request);
}
