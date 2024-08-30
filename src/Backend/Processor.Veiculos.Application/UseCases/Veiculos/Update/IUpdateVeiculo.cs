using Processor.Veiculos.Communication.Requests;

namespace Processor.Veiculos.Application.UseCases.Veiculos.Update;

public interface IUpdateVeiculo
{
    Task Execute(long id, RequestUpdateVeiculoJson veiculo);
}
