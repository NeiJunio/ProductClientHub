using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Delete;
using ProductClientHub.API.UseCases.Clients.GetAll;
using ProductClientHub.API.UseCases.Clients.GetbyId;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.API.UseCases.Clients.Update;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.Controllers;

// Define o roteamento para a API e indica que esta classe é um controlador
[Route("api/[controller]")]
[ApiController]
public class ClientsController(RegisterClientUseCase registerClientUseCase) : ControllerBase
{
    // Endpoint para registrar um novo cliente
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)] // Retorno para sucesso (201 Created)
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)] // Retorno para erro (400 Bad Request)
    public IActionResult Register([FromBody] RequestClientJson request)
    {
        // Chama o caso de uso para registrar um novo cliente
        var response = registerClientUseCase.Execute(request);

        // Retorna um status 201 Created com o objeto criado
        return Created(string.Empty, response);
    }

    // Endpoint para atualizar um cliente existente
    [HttpPut]
    [Route("{id}")] // Define que a requisição deve conter um ID na URL
    [ProducesResponseType(StatusCodes.Status204NoContent)] // Retorno para sucesso sem conteúdo (204 No Content)
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)] // Retorno para erro (400 Bad Request)
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)] // Retorno para erro (404 Not Found)
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestClientJson request)
    {
        // Instancia o caso de uso de atualização do cliente
        var useCase = new UpdateClientUseCase();

        // Executa a atualização do cliente
        useCase.Execute(id, request);

        // Retorna 204 No Content, indicando sucesso sem corpo de resposta
        return NoContent();
    }

    // Endpoint para obter todos os clientes cadastrados
    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)] // Retorno para sucesso (200 OK)
    [ProducesResponseType(StatusCodes.Status204NoContent)] // Retorno caso não haja clientes cadastrados (204 No Content)
    public IActionResult GetAll()
    {
        // Instancia o caso de uso para buscar todos os clientes
        var useCase = new GetAllClientsUseCase();

        // Executa a busca dos clientes
        var response = useCase.Execute();

        // Caso não haja clientes, retorna 204 No Content
        if (response.Clients.Count == 0)
        {
            return NoContent();
        }

        // Retorna os clientes encontrados com status 200 OK
        return Ok(response);
    }

    // Endpoint para buscar um cliente por ID
    [HttpGet]
    [Route("{id}")] // Define que a rota precisa de um ID
    [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)] // Retorno para sucesso (200 OK)
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)] // Retorno caso o cliente não seja encontrado (404 Not Found)
    public IActionResult GetById([FromRoute] Guid id)
    {
        // Instancia o caso de uso para buscar um cliente pelo ID
        var useCase = new GetCLientByIdUseCase();

        // Executa a busca pelo cliente
        var response = useCase.Execute(id);

        // Retorna o cliente encontrado com status 200 OK
        return Ok(response);
    }

    // Endpoint para excluir um cliente pelo ID
    [HttpDelete]
    [Route("{id}")] // Define que a rota precisa de um ID
    [ProducesResponseType(StatusCodes.Status204NoContent)] // Retorno para sucesso sem conteúdo (204 No Content)
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)] // Retorno caso o cliente não seja encontrado (404 Not Found)
    public IActionResult Delete([FromRoute] Guid id)
    {
        // Instancia o caso de uso para deletar um cliente
        var useCase = new DeleteClientUseCase();

        // Executa a exclusão do cliente
        useCase.Execute(id);

        // Retorna 204 No Content, indicando que o cliente foi removido com sucesso
        return NoContent();
    }
}


/*
    Explicação detalhada:

    1- Namespaces e Imports
        - O código importa diversas dependências, incluindo Microsoft.AspNetCore.Mvc (para criação de APIs) e casos de uso (UseCases) responsáveis pelas operações CRUD (Create, Read, Update, Delete).
    
    2- Definição da Classe ClientsController
        - ClientsController herda de ControllerBase, que fornece funcionalidades para lidar com requisições HTTP no ASP.NET Core.
        - A anotação [Route("api/[controller]")] define a rota base do controlador, onde [controller] será substituído pelo nome da classe sem  "Controller" (neste caso, api/Clients).
        - [ApiController] informa ao ASP.NET que essa classe é um controlador de API, ativando recursos como validação automática de modelos.
        
    3- Método Register (Cadastro de Cliente)
        -[HttpPost] indica que esse método responde a requisições POST.
        -[ProducesResponseType] especifica os possíveis retornos: 201 Created para sucesso e 400 Bad Request para falha.
        - registerClientUseCase.Execute(request) executa o caso de uso para cadastrar um novo cliente.
        - return Created(string.Empty, response); retorna um status 201 Created, indicando que o recurso foi criado com sucesso.
        
    4- Método Update (Atualização de Cliente)
        - [HttpPut] indica que esse método responde a requisições PUT.
        - Route("{id}") define que a URL deve conter um id para identificar qual cliente será atualizado.
        - O método recebe um Guid id (identificador único) e RequestClientJson request (dados do cliente).
        - UpdateClientUseCase().Execute(id, request); executa a atualização dos dados.
        - return NoContent(); retorna 204 No Content, indicando que a operação foi bem-sucedida sem necessidade de resposta no corpo.
    
    5- Método GetAll (Listagem de Clientes)
        - [HttpGet] indica que responde a requisições GET.
        - useCase.Execute() busca todos os clientes cadastrados.
        - Se a lista estiver vazia, retorna 204 No Content, senão, retorna 200 OK com os clientes encontrados.
        
    6- Método GetById (Buscar Cliente por ID)
        - [HttpGet] com Route("{id}") define que a requisição deve conter um ID na URL.
        - GetCLientByIdUseCase().Execute(id); busca o cliente pelo ID.
        - Retorna 200 OK com os dados do cliente encontrado ou 404 Not Found se não existir.
        
    7- Método Delete (Exclusão de Cliente)
        - [HttpDelete] indica que responde a requisições DELETE.
        - DeleteClientUseCase().Execute(id); executa a remoção do cliente.
        - Retorna 204 No Content, indicando que o cliente foi removido com sucesso.
    
*/