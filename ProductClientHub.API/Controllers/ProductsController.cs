using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.Entities;
using ProductClientHub.API.UseCases.Products.Delete;
using ProductClientHub.API.UseCases.Products.Register;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.Controllers
{
    // Define a rota base para este controlador como "api/products"
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Define um endpoint HTTP POST para registrar um novo produto
        [HttpPost]
        [Route("{clientId}")] // O clientId é um parâmetro da rota
        [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status201Created)] // Retorno 201 Created se bem-sucedido
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)] // Retorno 400 se houver erro de validação
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)] // Retorno 404 se o cliente não for encontrado

        public IActionResult Register([FromRoute] Guid clientId, [FromBody] RequestProductJson request)
        {
            // Instancia um caso de uso para registrar um produto
            var useCase = new RegisterProductUseCase();

            // Executa a lógica do caso de uso com os parâmetros fornecidos
            var response = useCase.Execute(clientId, request);

            // Retorna um status HTTP 201 Created com o objeto de resposta
            return Created(string.Empty, response);
        }

        // Define um endpoint HTTP DELETE para remover um produto pelo ID
        [HttpDelete]
        [Route("{id}")] // O id do produto vem na rota
        [ProducesResponseType(StatusCodes.Status204NoContent)] // Retorno 204 se a exclusão for bem-sucedida
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)] // Retorno 404 se o produto não for encontrado

        public IActionResult Delete([FromRoute] Guid id)
        {
            // Instancia um caso de uso para deletar um produto
            var useCase = new DeleteProductUseCase();

            // Executa a lógica de exclusão do produto
            useCase.Execute(id);

            // Retorna um status HTTP 204 No Content para indicar que a operação foi bem-sucedida
            return NoContent();
        }
    }
}

/*
    Explicação técnica detalhada:
        
    1- Namespace (namespace ProductClientHub.API.Controllers)
        -Define o escopo do código, agrupando o controlador dentro da estrutura do projeto.
        
    2- Atributos do controlador ([Route("api/[controller]")], [ApiController])
        - [Route("api/[controller]")] define que as rotas da API para este controlador começam com api/products. O [controller] será substituído pelo nome do controlador sem sufixo "Controller" (ou seja, ProductsController se torna api/products).
        - [ApiController] habilita funcionalidades específicas do ASP.NET Core para controllers de API, como a validação automática de modelos e a    resposta padronizada de erros.
        
    3- Método Register (Criar um produto)
        - [HttpPost]: Indica que esse método responde a requisições HTTP do tipo POST.
        - [Route("{clientId}")]: Especifica que a rota deve incluir um clientId como parâmetro.
        - [FromRoute] Guid clientId: Captura o clientId da URL da requisição.
        - [FromBody] RequestProductJson request: Captura o corpo da requisição, que deve conter os dados do produto.
        - RegisterProductUseCase useCase = new RegisterProductUseCase();: Cria uma instância do caso de uso responsável por registrar o produto.
        - useCase.Execute(clientId, request);: Executa a lógica de registro, recebendo os dados do cliente e do produto.
        - return Created(string.Empty, response);: Retorna um status HTTP 201 (Created) para indicar que o recurso foi criado com sucesso.
        
    4- Método Delete (Excluir um produto)
        - [HttpDelete]: Indica que esse método responde a requisições HTTP do tipo DELETE.
        - [Route("{id}")]: Define que o ID do produto deve ser passado na URL.
        - [FromRoute] Guid id: Captura o id da URL da requisição.
        - DeleteProductUseCase useCase = new DeleteProductUseCase();: Instancia a classe responsável por deletar produtos.
        - useCase.Execute(id);: Chama a lógica de exclusão do produto.
        - return NoContent();: Retorna um status HTTP 204 (No Content) para indicar que a exclusão foi bem-sucedida.
    
 */