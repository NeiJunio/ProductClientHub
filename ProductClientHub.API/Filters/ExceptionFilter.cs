using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.Filters
{
    // A classe ExceptionFilter implementa a interface IExceptionFilter para lidar com exceções lançadas durante a execução das ações HTTP.
    public class ExceptionFilter : IExceptionFilter
    {
        // Método obrigatório ao implementar a interface IExceptionFilter.
        // Esse método será chamado quando uma exceção for lançada durante a execução de uma ação no controlador.
        public void OnException(ExceptionContext context)
        {
            // Verifica se a exceção é do tipo ProductClientHubException (uma exceção personalizada do projeto).
            if (context.Exception is ProductClientHubException productClientHubException)
            {
                // Se for uma ProductClientHubException, define o código de status HTTP com base no código de status associado à exceção.
                context.HttpContext.Response.StatusCode = (int)productClientHubException.GetHttpStatusCode();

                // Define o resultado da ação como um JSON com os erros da exceção.
                context.Result = new ObjectResult(new ResponseErrorMessagesJson(productClientHubException.GetErrors()));
            }
            else
            {
                // Se a exceção não for do tipo esperado, invoca o método para tratar um erro desconhecido.
                ThrowUnknowError(context);
            }
        }

        // Método privado que lida com exceções desconhecidas.
        private static void ThrowUnknowError(ExceptionContext context)
        {
            // Define o código de status HTTP como 500 (Erro Interno do Servidor) para erros desconhecidos.
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            // Define o resultado da ação como um JSON com uma mensagem de erro genérica para erros desconhecidos.
            context.Result = new ObjectResult(new ResponseErrorMessagesJson("ERRO DESCONHECIDO"));
        }
    }
}


/*
    Explicação detalhada: 
    
1- Classe ExceptionFilter:
    - Esta classe implementa a interface IExceptionFilter, permitindo que o código se inscreva no pipeline de filtros de exceção do ASP.NET Core. O   propósito dessa classe é interceptar exceções que possam ocorrer durante a execução de uma ação e definir uma resposta HTTP adequada, com     base no tipo de exceção.
    
2- Método OnException:
    - Este é o método principal que será chamado sempre que uma exceção for gerada durante a execução de uma ação de API.
    - O parâmetro ExceptionContext fornece detalhes sobre a exceção lançada (context.Exception) e permite modificar a resposta HTTP   (context.HttpContext.Response).
    - O código verifica se a exceção lançada é do tipo ProductClientHubException. Se for, ele configura o código de status HTTP com base na lógica    definida na exceção (por exemplo, 400 para erros de validação ou 404 para "não encontrado").
    - A resposta do cliente é configurada para ser um objeto JSON que descreve os erros detalhados, facilitando o diagnóstico do erro pelo    desenvolvedor ou usuário final.
    
3- Método ThrowUnknowError:
    - Este método é invocado caso uma exceção não esperada ou desconhecida seja capturada. Ele define o código de status HTTP como 500 (Erro Interno  do Servidor) e retorna uma mensagem de erro genérica ("ERRO DESCONHECIDO") em formato JSON.
    - Isso assegura que, caso o sistema encontre uma exceção que não tenha um tratamento específico, o cliente ainda receba uma resposta  compreensível e o servidor não falhe silenciosamente.
    
## Termos técnicos:
    - IExceptionFilter: Interface que permite a implementação de um filtro para capturar exceções no ASP.NET Core. Ao implementar essa interface,     você pode definir como o sistema lida com erros de forma centralizada.
    - ExceptionContext: Um contexto que fornece acesso à exceção lançada e permite manipular a resposta HTTP que será enviada ao cliente.
    - ObjectResult: Classe usada para encapsular o resultado de uma ação, permitindo retornar dados como um objeto que pode ser serializado em JSON.
    - ProductClientHubException: Exceção personalizada, provavelmente definida no código do projeto, que permite um controle mais refinado sobre os   tipos de erros específicos para o contexto do sistema.
    - ResponseErrorMessagesJson: Classe que provavelmente formata a resposta de erro em um formato JSON, contendo mensagens ou dados estruturados     sobre os erros ocorridos.
    

## IMPORTANTE: 
    - Esse tipo de estrutura é útil em APIs, pois centraliza o tratamento de erros e torna a resposta mais clara para os desenvolvedores que consomem  a API, além de oferecer uma maneira escalável de adicionar novos tipos de exceções e tratamentos conforme o sistema cresce.
     
 */