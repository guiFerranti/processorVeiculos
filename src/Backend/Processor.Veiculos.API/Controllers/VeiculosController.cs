using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Processor.Veiculos.Application.UseCases.Veiculos.Register;
using Processor.Veiculos.Communication.Requests;
using Processor.Veiculos.Communication.Responses;

namespace Processor.Veiculos.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VeiculosController : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredVeiculoJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromBody] RequestRegisteredVeiculoJson request,
        [FromServices] IRegisterVeiculoUseCase useCase)
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }

}
