using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ClientsController(RegisterClientUseCase registerClientUseCase) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]

    public IActionResult Register([FromBody] RequestClientJson request)
    {
        var response = registerClientUseCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
        //return Ok(new
        //{

        //});
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
