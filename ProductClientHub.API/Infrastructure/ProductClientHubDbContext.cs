using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Entities;

namespace ProductClientHub.API.Infrastructure // Definindo o namespace da aplicação
{
    // Classe que representa o contexto do banco de dados do ProductClientHub
    public class ProductClientHubDbContext : DbContext
    {
        // Construtor sem parâmetros, necessário para o EF Core
        public ProductClientHubDbContext() // LINHA FIXA
        {
        }

        // Propriedades DbSet para acessar as entidades 'Client' e 'Product' no banco de dados
        public virtual DbSet<Client> Clients { get; set; } = default!; // Representa a tabela 'Clients'
        public virtual DbSet<Product> Products { get; set; } = default!; // Representa a tabela 'Products'

        // ## IDENTIFICAÇÃO 1
        // Método que configura as opções de banco de dados, nesse caso, usando o SQLite
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=banco.db"); // Configuração para usar SQLite com arquivo 'banco.db'

        // Caso o banco de dados seja especificado diretamente no caminho (comentado)
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        //    => optionsBuilder.UseSqlite("Data Source=C:\\Users\\Nei Junio\\Documents\\bancotesteconexao.db");

        // Método comentado que poderia ser usado para configurar chaves estrangeiras e comportamentos
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração para garantir que ao deletar um Cliente, todos os Produtos associados também sejam apagados
            modelBuilder.Entity<Product>()
                .HasOne<Client>()  // Produto pertence a um Cliente
                .WithMany()        // Um Cliente pode ter vários Produtos
                .HasForeignKey(p => p.ClientId) // Definindo a chave estrangeira
                .OnDelete(DeleteBehavior.Cascade); // Delete em cascata, apaga os Produtos ao deletar um Cliente
        }
        */

        /*
         * 
         ## IDENTIFICAÇÃO 2
         // Construtor que recebe opções de configuração para o contexto (usado quando se configura o DbContext fora da classe)
         public ProductClientHubDbContext(DbContextOptions<ProductClientHubDbContext> options)
            : base(options)
         {
         }

         // Repetição das propriedades DbSet para 'Client' e 'Product'
         public virtual DbSet<Client> Clients { get; set; } = default!;
         public virtual DbSet<Product> Products { get; set; } = default!;
         *
         */

    }
}


/*
    Explicação detalhada:
        
    1- namespace ProductClientHub.API.Infrastructure
        -Define o espaço de nomes (namespace) da aplicação. Este namespace agrupa as classes relacionadas  à infraestrutura da aplicação, como o    contexto do banco de dados.
        
    2- public class ProductClientHubDbContext : DbContext
        -Esta classe herda de DbContext e é responsável por gerenciar a comunicação entre a  aplicação e o banco de dados. O DbContext é a  principal classe do Entity Framework Core que permite realizar operações como consultas,   inserções, atualizações e exclusões no banco.
        
    3- Construtor public ProductClientHubDbContext()
        - Um construtor padrão. Em muitos cenários, o Entity Framework Core usa construtores sem   parâmetros para criar o DbContext. O parâmetro   pode ser necessário em casos onde a aplicação requer uma configuração especial (construtor com  parâmetros está comentado na  Identificação 2).
        
    4- public virtual DbSet<Client> Clients { get; set; } = default!;
        - Propriedade DbSet que representa a tabela Clients no banco de dados. A anotação  virtual permite que o EF Core faça proxy para    implementar carregamento preguiçoso e rastreamento de mudanças. default! evita o erro de  inicialização nula do C# 8+.
        
    5- protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        - Método usado para configurar a conexão com o banco de dados.     Aqui, ele usa o SQLite como banco de dados, especificando o caminho do   arquivo. O SQLite é um banco de dados leve, geralmente utilizado para    testes ou aplicações locais.
        
    6- OnModelCreating(ModelBuilder modelBuilder)
        - O método comentado define as regras de mapeamento entre entidades e o banco de  dados. Especificamente, ele configura uma relação de  chave estrangeira entre Product e Client, garantindo que, se um Client for deletado,    todos os Products associados a ele também sejam  deletados (comportamento de "delete cascade").
        
    7- Comentário sobre a Identificação 2
        - Esta parte descreve outra possível implementação do construtor, que recebe opções de configuração do    contexto de banco de dados (útil  em cenários onde o contexto é configurado fora da classe, como em uma injeção de dependência).
        
    ## Termos Técnicos:
        - DbSet<T>: Representa uma coleção de todas as entidades do tipo especificado (Client ou Product), e fornece métodos para realizar  operações no   banco de dados.
        - DbContext: Classe do Entity Framework Core que representa uma sessão com o banco de dados, permitindo realizar operações de CRUD (Create,  Read,  Update, Delete).
        - OnConfiguring e DbContextOptionsBuilder: Métodos usados para configurar o comportamento do DbContext, como qual banco de dados usar e     como se   conectar a ele
        - OnModelCreating: Usado para configurar o modelo de entidades, como relacionamentos entre tabelas e comportamentos ao deletar ou atualizar    dados.
    
 */