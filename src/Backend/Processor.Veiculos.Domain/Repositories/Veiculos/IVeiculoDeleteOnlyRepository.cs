namespace Processor.Veiculos.Domain.Repositories.Veiculos;

public interface IVeiculoDeleteOnlyRepository
{
    Task Delete(long id);
}
