using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Processor.Veiculos.Communication.Requests;
using Processor.Veiculos.Communication.Responses;

namespace Processor.Veiculos.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VeiculosController : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredVeiculoJson), StatusCodes.Status201Created)]
    public IActionResult Register(RequestRegisteredVeiculoJson request)
    {
        return Created();
    }

}
