using AutoMapper;
using Processor.Veiculos.Communication.Requests;
using Processor.Veiculos.Domain.Repositories.Veiculos;

namespace Processor.Veiculos.Application.UseCases.Veiculos.Update;

public class UpdateVeiculo : IUpdateVeiculo
{
    private readonly IVeiculoUpdateOnlyRepository _veiculoRepository;
    private readonly IMapper _mapper;

    public UpdateVeiculo(IVeiculoUpdateOnlyRepository veiculoRepository, IMapper mapper)
    {
        _veiculoRepository = veiculoRepository;
        _mapper = mapper;
    }

    public Task Execute(long id, RequestUpdateVeiculoJson veiculo)
    {
        var veiculoAtualizado = _mapper.Map<Domain.Entities.Veiculo>(veiculo);

        return _veiculoRepository.Update(id, veiculoAtualizado);
    }
}
