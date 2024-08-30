using System.Net;

namespace Processor.Veiculos.Exceptions.ExceptionsBase;

public class NotFoundException : ProcessorVeiculosException
{
    public IList<string> ErrorMessages { get; set; }

    public NotFoundException(IList<string> errors)
    {
        ErrorMessages = errors;
    }
}