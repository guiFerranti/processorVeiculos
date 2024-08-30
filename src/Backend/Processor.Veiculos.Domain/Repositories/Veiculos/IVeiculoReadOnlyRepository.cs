namespace Processor.Veiculos.Domain.Repositories.Veiculos;

public interface IVeiculoReadOnlyRepository
{
    public Task<Entities.Veiculo> GetById(long id);
    public Task<IEnumerable<Entities.Veiculo>> GetAll();
}
