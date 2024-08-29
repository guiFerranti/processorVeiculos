namespace Processor.Veiculos.Exceptions.ExceptionsBase;

public class ErrorsOnValidationException : ProcessorVeiculosExepction
{
    public IList<string> ErrorMessages { get; set; }

    public ErrorsOnValidationException(IList<string> errors)
    {
        ErrorMessages = errors;
    }
}
