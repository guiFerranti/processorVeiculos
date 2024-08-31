using AutoMapper;
using Processor.Veiculos.Application.UseCases.Veiculos.Register;
using Processor.Veiculos.Communication.Requests;
using Processor.Veiculos.Domain.Repositories.Veiculos;
using Processor.Veiculos.Exceptions.ExceptionsBase;

namespace Processor.Veiculos.Application.UseCases.Veiculos.Update;

public class UpdateVeiculoUseCase : IUpdateVeiculoUseCase
{
    private readonly IVeiculoUpdateOnlyRepository _veiculoRepository;
    private readonly IMapper _mapper;

    public UpdateVeiculoUseCase(IVeiculoUpdateOnlyRepository veiculoRepository, IMapper mapper)
    {
        _veiculoRepository = veiculoRepository;
        _mapper = mapper;
    }

    public Task Execute(long id, RequestUpdateVeiculoJson veiculo)
    {
        Validate(veiculo);

        var veiculoAtualizado = _mapper.Map<Domain.Entities.Veiculo>(veiculo);

        return _veiculoRepository.Update(id, veiculoAtualizado);
    }

    private void Validate(RequestUpdateVeiculoJson request)
    {
        var validator = new UpdateVeiculoValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorsOnValidationException(errorMessages);
        }
    }
}
