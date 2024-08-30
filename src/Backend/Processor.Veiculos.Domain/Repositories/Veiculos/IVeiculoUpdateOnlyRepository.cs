using Processor.Veiculos.Communication.Requests;
using Processor.Veiculos.Domain.Entities;

namespace Processor.Veiculos.Domain.Repositories.Veiculos;

public interface IVeiculoUpdateOnlyRepository
{
    Task Update(long id, Veiculo veiculo);
}
