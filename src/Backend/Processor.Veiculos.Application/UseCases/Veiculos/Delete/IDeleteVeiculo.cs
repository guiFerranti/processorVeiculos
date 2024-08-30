namespace Processor.Veiculos.Application.UseCases.Veiculos.Delete;

public interface IDeleteVeiculo
{
    public Task Execute(long id);
}
