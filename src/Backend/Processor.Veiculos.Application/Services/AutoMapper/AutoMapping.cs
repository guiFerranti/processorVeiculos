using AutoMapper;
using Processor.Veiculos.Communication.Requests;
using Processor.Veiculos.Communication.Responses;
using Processor.Veiculos.Domain.Repositories.Veiculos;

namespace Processor.Veiculos.Application.Services.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToDomain();
        DomainToResponse();
    }

    private void RequestToDomain()
    {
        CreateMap<RequestRegisteredVeiculoJson, Domain.Entities.Veiculo>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }

    private void DomainToResponse() 
    {
        CreateMap<Domain.Entities.Veiculo, ResponseGetVeiculoJson>();
    }
}