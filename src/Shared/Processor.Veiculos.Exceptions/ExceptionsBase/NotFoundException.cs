using System.Net;

namespace Processor.Veiculos.Exceptions.ExceptionsBase;

public class NotFoundException : ProcessorVeiculosException
{
    public string ErrorMessages { get; set; }

    public NotFoundException(string errors)
    {
        ErrorMessages = errors;
    }
}