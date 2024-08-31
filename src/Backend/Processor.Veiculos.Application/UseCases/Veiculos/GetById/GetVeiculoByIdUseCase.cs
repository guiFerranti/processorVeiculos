using AutoMapper;
using Processor.Veiculos.Communication.Responses;
using Processor.Veiculos.Domain.Repositories.Veiculos;
using Processor.Veiculos.Exceptions;
using Processor.Veiculos.Exceptions.ExceptionsBase;

namespace Processor.Veiculos.Application.UseCases.Veiculos.GetById;

public class GetVeiculoByIdUseCase : IGetVeiculoByIdUseCase
{
    private readonly IVeiculoReadOnlyRepository _veiculoReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetVeiculoByIdUseCase(IVeiculoReadOnlyRepository veiculoReadOnlyRepository, IMapper mapper)
    {
        _veiculoReadOnlyRepository = veiculoReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<ResponseGetVeiculoJson> Execute(long id)
    {
        var veiculo = await _veiculoReadOnlyRepository.GetById(id);

        if (veiculo is null)
        {
            throw new NotFoundException(ResourceMessagesException.VEICULO_NOT_FOUND);
        }

        return _mapper.Map<ResponseGetVeiculoJson>(veiculo);
    }
}
