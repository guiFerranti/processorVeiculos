using Processor.Veiculos.Domain.Entities;

namespace Processor.Veiculos.Domain.Repositories.Veiculos;

public interface IVeiculoWriteOnlyRepository
{
    public Task Add(Entities.Veiculo veiculo);
}
