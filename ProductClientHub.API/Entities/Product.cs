namespace ProductClientHub.API.Entities
{
    // A classe Product representa um produto no sistema.
    // Ela herda de EntityBase, que provavelmente contém propriedades comuns como Id e Data de Criação.
    public class Product : EntityBase
    {
        // Propriedade que armazena o nome do produto.
        // Inicializa com uma string vazia para evitar valores nulos.
        public string Name { get; set; } = string.Empty;

        // Propriedade que representa a marca do produto.
        // Também é inicializada com uma string vazia.
        public string Brand { get; set; } = string.Empty;

        // Propriedade para armazenar o preço do produto.
        // Utiliza o tipo decimal, adequado para valores monetários.
        public decimal Price { get; set; }

        // Identificador único (UUID) do cliente relacionado a este produto.
        public Guid ClientId { get; set; }

        // Propriedade que representa o relacionamento com a entidade Client.
        // Está comentada, possivelmente por não estar sendo usada no momento.
        // public Client Client { get; set; } = default!;
    }
}


/*
    Explicação detalhada:
    
    1- Namespace (namespace ProductClientHub.API.Entities)
        - Define o escopo do código e organiza a classe Product dentro do projeto.
        - Segue uma estrutura hierárquica (ProductClientHub.API.Entities), sugerindo que faz parte da camada de entidades do sistema.
        
    2- Herança (public class Product : EntityBase)
        - Product herda de EntityBase, o que significa que ela reutiliza propriedades ou métodos definidos na classe EntityBase.
        - Provavelmente, EntityBase contém propriedades comuns a todas as entidades, como Id, CreatedAt, UpdatedAt, etc.
        
    3- Propriedades da Classe:
        - public string Name { get; set; } = string.Empty;
            -- Representa o nome do produto.
            -- Inicializa como string.Empty para evitar null (prática útil para evitar exceções de referência nula).
        
        - public string Brand { get; set; } = string.Empty;
            -- Armazena a marca do produto.
            -- Também inicializada para evitar valores nulos.
        
        - public decimal Price { get; set; }
            -- Define o preço do produto.
            -- O tipo decimal é escolhido porque fornece maior precisão em cálculos financeiros, evitando erros de arredondamento que ocorrem com   float ou double.
        
        - public Guid ClientId { get; set; }
            -- Armazena o identificador único do cliente relacionado ao produto.
            -- O uso de Guid (Globally Unique Identifier) garante um ID único universalmente, útil para sistemas distribuídos.
        
        - public Client Client { get; set; } = default!; (Comentado)
            -- Representa um relacionamento entre Product e Client.
            -- Provavelmente, Client é uma entidade que armazena informações sobre os clientes do sistema.
            -- O default! indica que a propriedade será inicializada posteriormente e não pode ser null, sendo útil quando usamos frameworks como   Entity Framework para carregar os dados dinamicamente.
        
 */