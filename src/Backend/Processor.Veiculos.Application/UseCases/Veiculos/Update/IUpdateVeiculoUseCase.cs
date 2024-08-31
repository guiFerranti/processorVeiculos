using Processor.Veiculos.Communication.Requests;

namespace Processor.Veiculos.Application.UseCases.Veiculos.Update;

public interface IUpdateVeiculoUseCase
{
    Task Execute(long id, RequestUpdateVeiculoJson veiculo);
}
