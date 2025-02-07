using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.GetAll;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.API.UseCases.Clients.Update;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ClientsController(RegisterClientUseCase registerClientUseCase) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]

    public IActionResult Register([FromBody] RequestClientJson request)
    {
        var response = registerClientUseCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestClientJson request)
    {
        var useCase = new UpdateClientUseCase();

        useCase.Execute(id, request);

        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllClientsUseCase();

        var response = useCase.Execute();

        if (response.Clients.Count == 0)
        {
            return NoContent();
        }

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")] // impede de aceitar nulo, tendo em vista que essa rota foi criada com o intuito de buscar um valor específico

    // [HttpGet("By-Id")]

    public IActionResult GetById([FromRoute] Guid id)
    {
        return Ok();
    }

    [HttpDelete]

    public IActionResult Delete()
    {
        return Ok();
    }
}
