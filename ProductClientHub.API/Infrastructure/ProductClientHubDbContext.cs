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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=C:\\Users\\Nei Junio\\Documents\\bancotesteconexao.db");

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
