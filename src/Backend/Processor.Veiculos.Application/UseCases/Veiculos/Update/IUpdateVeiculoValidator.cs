using FluentValidation;
using Processor.Veiculos.Communication.Requests;
using Processor.Veiculos.Exceptions;

namespace Processor.Veiculos.Application.UseCases.Veiculos.Update;

public class UpdateVeiculoValidator : AbstractValidator<RequestUpdateVeiculoJson>
{
    public UpdateVeiculoValidator()
    {
        int anoAtual = DateTime.Now.Year;
        int anoLimite = anoAtual - 20;

        RuleFor(veiculo => veiculo.Marca).NotEmpty().WithMessage(ResourceMessagesException.MARCA_EMPTY);
        RuleFor(veiculo => veiculo.Modelo).NotEmpty().WithMessage(ResourceMessagesException.MODELO_EMPTY);
        RuleFor(veiculo => veiculo.Ano).NotEmpty().WithMessage(ResourceMessagesException.ANO_EMPTY);
        RuleFor(veiculo => veiculo.Ano).GreaterThanOrEqualTo(anoLimite).WithMessage(ResourceMessagesException.ANO_LIMITE_INVALID);  
    }
}
