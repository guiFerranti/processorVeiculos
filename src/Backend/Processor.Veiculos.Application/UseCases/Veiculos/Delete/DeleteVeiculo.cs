
using Processor.Veiculos.Domain.Repositories.Veiculos;

namespace Processor.Veiculos.Application.UseCases.Veiculos.Delete;

internal class DeleteVeiculo : IDeleteVeiculo
{
    private readonly IVeiculoDeleteOnlyRepository _veiculoDeleteOnlyRepository;

    public async Task Execute(long id)
    {
        await _veiculoDeleteOnlyRepository.Delete(id);
    }
}
