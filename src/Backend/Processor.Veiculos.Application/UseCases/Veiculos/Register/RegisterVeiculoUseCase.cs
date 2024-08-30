using AutoMapper;
using Processor.Veiculos.Application.Services.AutoMapper;
using Processor.Veiculos.Communication.Requests;
using Processor.Veiculos.Communication.Responses;
using Processor.Veiculos.Domain.Repositories.Veiculos;
using Processor.Veiculos.Exceptions.ExceptionsBase;

namespace Processor.Veiculos.Application.UseCases.Veiculos.Register;

public class RegisterVeiculoUseCase : IRegisterVeiculoUseCase
{
    private readonly IMapper _mapper;
    private readonly IVeiculoWriteOnlyRepository _veiculoWriteOnlyRepository;

    public RegisterVeiculoUseCase(IMapper mapper, IVeiculoWriteOnlyRepository veiculoWriteOnlyRepository)
    {
        _mapper = mapper;
        _veiculoWriteOnlyRepository = veiculoWriteOnlyRepository;
    }

    public async Task<ResponseRegisteredVeiculoJson> Execute(RequestRegisteredVeiculoJson request)
    {
        Validate(request);

        var veiculo = _mapper.Map<Domain.Entities.Veiculo>(request);

        await _veiculoWriteOnlyRepository.Add(veiculo);

        return null;
    }


    private void Validate(RequestRegisteredVeiculoJson request)
    {
        var validator = new RegisterVeiculoValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorsOnValidationException(errorMessages);
        }
    }
}
