﻿using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Entities;

namespace ProductClientHub.API.Infrastructure
{
    public class ProductClientHubDbContext : DbContext
    {
        //public DbSet<Client> Clients { get; set; } = default!;
        //public DbSet<Product> Products { get; set; } = default!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(@"Data Source=""C:\Users\Nei Junio\Documents\bancotesteconexao.db""");
        
            public ProductClientHubDbContext()
            {
            }
            public ProductClientHubDbContext(DbContextOptions<ProductClientHubDbContext> options)
                : base(options)
            {
            }
            public virtual DbSet<Client> Clients { get; set; } = default!;
            public virtual DbSet<Product> Products { get; set; } = default!;
        
    }
}
