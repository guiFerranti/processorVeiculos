using Processor.Veiculos.Communication.Responses;

namespace Processor.Veiculos.Application.UseCases.Veiculos.GetAll;

public interface IGetAllVeiculoUseCase
{
    Task<ResponseGetAllVeiculosJson> Execute(int pageNumber, int pageSize);
}
