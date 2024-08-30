using AutoMapper;
using Processor.Veiculos.Communication.Requests;

namespace Processor.Veiculos.Application.Services.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToDomain();
    }

    private void RequestToDomain()
    {
        CreateMap<RequestRegisteredVeiculoJson, Domain.Entities.Veiculo>();
    }

    private void DomainToResponse() {}
}