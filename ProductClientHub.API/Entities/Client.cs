namespace ProductClientHub.API.Entities
{
    // A classe Client representa um cliente no sistema.
    // Ela herda de EntityBase, possivelmente para reutilizar propriedades comuns entre entidades.
    public class Client : EntityBase
    {
        // Identificador único do cliente, gerado automaticamente ao instanciar a classe.
        public Guid Id { get; set; } = Guid.NewGuid();

        // Nome do cliente, inicializado como uma string vazia para evitar valores nulos.
        public string Name { get; set; } = string.Empty;

        // Email do cliente, também inicializado como string vazia para evitar valores nulos.
        public string Email { get; set; } = string.Empty;

        // Lista de produtos associados ao cliente.
        // Inicializada como uma lista vazia para evitar null reference exceptions.
        public List<Product> Products { get; set; } = [];
    }
}

/* 
    Explicação Detalhada:
    
    1- Namespace (namespace ProductClientHub.API.Entities)
        - Define um agrupamento lógico para organizar classes relacionadas.
        - Aqui, ProductClientHub.API.Entities indica que esta classe faz parte da camada de entidades do projeto.
        
    2- Herança (public class Client : EntityBase)
        - A classe Client herda de EntityBase, o que significa que pode reutilizar métodos e propriedades definidos nessa classe base.
         - EntityBase pode conter propriedades comuns, como CreatedAt ou UpdatedAt.
        
    2- Propriedade Id (public Guid Id { get; set; } = Guid.NewGuid();)
        - Guid é um tipo de dado usado para gerar identificadores únicos.
        - Guid.NewGuid() cria um novo identificador automaticamente quando um objeto da classe Client é instanciado.
        - Isso evita que o campo seja nulo e garante unicidade.
        
    3- Propriedade Name e Email
        - Ambas são strings inicializadas como string.Empty.
        - Isso evita problemas de null quando a classe é instanciada sem valores atribuídos.
        - Boa prática para evitar exceções de referência nula.
        
    4- Lista de Produtos (public List<Product> Products { get; set; } = [];)
        - Representa uma coleção de produtos associados ao cliente.
        - Inicializa uma lista vazia ([] é um atalho para new List<Product>() a partir do C# 9.0).
        - Isso previne NullReferenceException ao acessar a lista antes de adicionar elementos.
    
 */