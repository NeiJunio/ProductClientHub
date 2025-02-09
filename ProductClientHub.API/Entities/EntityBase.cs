namespace ProductClientHub.API.Entities
{
    // Define uma classe abstrata chamada EntityBase
    public abstract class EntityBase
    {
        // Propriedade Id do tipo Guid, inicializada com um valor único
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}

/*
    Explicação detalhada:

    1- namespace ProductClientHub.API.Entities
        - Define um namespace para organizar a classe dentro do projeto.
        - ProductClientHub.API.Entities sugere que a classe faz parte da camada de entidades dentro de um sistema chamado "ProductClientHub".
        
    2- public abstract class EntityBase
        - Declara uma classe abstrata chamada EntityBase.
        - Uma classe abstrata não pode ser instanciada diretamente, servindo apenas como base para outras classes herdarem seus membros.
        
    3- public Guid Id { get; set; } = Guid.NewGuid();
        - Declara uma propriedade Id do tipo Guid, que atua como identificador único da entidade.
        - A inicialização com Guid.NewGuid() garante que cada instância da classe (ou de suas subclasses) tenha um ID exclusivo.
        - O get; set; define a propriedade como pública, permitindo que seu valor seja acessado e modificado externamente.
        
    ## Objetivo do Código:
        A classe EntityBase é utilizada como uma classe base para outras entidades dentro da aplicação. Seu propósito é garantir que todas as   entidades  que a herdarem possuam um identificador único (Id). Esse padrão é comum em aplicações que utilizam bancos de dados,    facilitando a gestão de entidades e garantindo consistência nos identificadores.
    
 */