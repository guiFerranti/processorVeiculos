using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Processor.Veiculos.Application.UseCases.Veiculos.Delete;
using Processor.Veiculos.Application.UseCases.Veiculos.GetAll;
using Processor.Veiculos.Application.UseCases.Veiculos.GetById;
using Processor.Veiculos.Application.UseCases.Veiculos.Register;
using Processor.Veiculos.Application.UseCases.Veiculos.Update;
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

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseGetVeiculoJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromRoute] long id,
        [FromServices] IGetVeiculoByIdUseCase useCase)
    {
        var result = await useCase.Execute(id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
               [FromRoute] long id,
                      [FromBody] RequestUpdateVeiculoJson request,
                        [FromServices] IUpdateVeiculoUseCase useCase)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
               [FromRoute] long id,
                      [FromServices] IDeleteVeiculo useCase)
    {
        await useCase.Execute(id);

        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseGetAllVeiculosJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
               [FromServices] IGetAllVeiculoUseCase useCase,
               [FromQuery] int page = 1,
               [FromQuery] int pageSize = 10
               )
    {
        var result = await useCase.Execute(page, pageSize);

        return Ok(result);
    }
}
