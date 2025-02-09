using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductClientHub.API.Infrastructure
{
    public class ProductClientHubDbContext : DbContext
    {
        public ProductClientHubDbContext() // LINHA FIXA
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = default!;
        public virtual DbSet<Product> Products { get; set; } = default!;

        // ## IDENTIFICAÇÃO 1
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=banco.db");
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=C:\\Users\\Nei Junio\\Documents\\bancotesteconexao.db");


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Configurar chave estrangeira com DELETE CASCADE
        //    modelBuilder.Entity<Product>()
        //        .HasOne<Client>()  // Produto pertence a um Cliente
        //        .WithMany()        // Um Cliente pode ter vários Produtos
        //        .HasForeignKey(p => p.ClientId) // Chave estrangeira
        //        .OnDelete(DeleteBehavior.Cascade); // Apaga os produtos ao excluir um cliente
        //}

        /*
         * 
            ## IDENTIFICAÇÃO 2
            public ProductClientHubDbContext(DbContextOptions<ProductClientHubDbContext> options)
                : base(options)
            {
            }

            public virtual DbSet<Client> Clients { get; set; } = default!;
            public virtual DbSet<Product> Products { get; set; } = default!;
        *
        */

    }
}
