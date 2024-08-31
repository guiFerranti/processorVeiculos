using AutoMapper;
using Processor.Veiculos.Communication.Responses;
using Processor.Veiculos.Domain.Repositories.Veiculos;

namespace Processor.Veiculos.Application.UseCases.Veiculos.GetAll;

public class GetAllVeiculoUseCase : IGetAllVeiculoUseCase
{
    private readonly IVeiculoReadOnlyRepository _veiculoReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetAllVeiculoUseCase(IVeiculoReadOnlyRepository veiculoReadOnlyRepository, IMapper mapper)
    {
        _veiculoReadOnlyRepository = veiculoReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<ResponseGetAllVeiculosJson> Execute(int pageNumber, int pageSize)
    {
        var veiculos = await _veiculoReadOnlyRepository.GetAll();

        var totalCount = veiculos.Count();

        var pagedVeiculos = veiculos
            .Skip((pageNumber - 1) * pageSize) 
            .Take(pageSize)
            .ToList();

        var veiculosResponse = _mapper.Map<List<ResponseGetVeiculoJson>>(pagedVeiculos);

        var response = new ResponseGetAllVeiculosJson
        {
            Veiculos = veiculosResponse,
            TotalCount = totalCount, 
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        return response;
    }
}

