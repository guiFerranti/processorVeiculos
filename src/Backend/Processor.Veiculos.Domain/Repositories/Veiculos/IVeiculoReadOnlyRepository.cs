namespace Processor.Veiculos.Domain.Repositories.Veiculos;

public interface IVeiculoReadOnlyRepository
{
    public Task<Entities.Veiculo> GetById(long id);
    public Task<IList<Entities.Veiculo>> GetAll();
    public Task<bool> Exists(long id);
}
