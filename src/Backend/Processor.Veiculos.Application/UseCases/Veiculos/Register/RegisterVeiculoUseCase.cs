using AutoMapper;
using Processor.Veiculos.Application.Services.AutoMapper;
using Processor.Veiculos.Communication.Requests;
using Processor.Veiculos.Communication.Responses;
using Processor.Veiculos.Domain.Repositories.Veiculos;
using Processor.Veiculos.Exceptions.ExceptionsBase;
using System;

namespace Processor.Veiculos.Application.UseCases.Veiculos.Register;

public class RegisterVeiculoUseCase : IRegisterVeiculoUseCase
{
    private readonly IMapper _mapper;
    private readonly IVeiculoWriteOnlyRepository _veiculoWriteOnlyRepository;
    private readonly IVeiculoReadOnlyRepository _veiculoReadOnlyRepository;

    public RegisterVeiculoUseCase(IMapper mapper, IVeiculoWriteOnlyRepository veiculoWriteOnlyRepository, IVeiculoReadOnlyRepository veiculoReadOnlyRepository)
    {
        _mapper = mapper;
        _veiculoWriteOnlyRepository = veiculoWriteOnlyRepository;
        _veiculoReadOnlyRepository = veiculoReadOnlyRepository;
    }

    public async Task<ResponseRegisteredVeiculoJson> Execute(RequestRegisteredVeiculoJson request)
    {
        Validate(request);

        var veiculo = _mapper.Map<Domain.Entities.Veiculo>(request);
        veiculo.Id = await GenerateUniqueIdVeiculo();

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

    private async Task<long> GenerateUniqueIdVeiculo()
    {
        long newId;
        bool isUnique;
        Random random = new Random();

        do
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            long id = BitConverter.ToInt64(buffer, 0);

            newId = (long)(random.NextDouble() * 1_000_000_000);
            isUnique = !await _veiculoReadOnlyRepository.Exists(newId);
        }
        while (!isUnique);

        return newId;
    }
}
