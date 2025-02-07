using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Filters;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.Register;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(option => option.Filters.Add(typeof(ExceptionFilter)));


// ## IDENTIFICAÇÃO 1
builder.Services.AddDbContext<ProductClientHubDbContext>(); // com essa linha, tenho que definir o caminho do banco lá no arquivo dbContext

/*
 * 
    ## IDENTIFICAÇÃO 2
    builder.Services.AddDbContext<ProductClientHubDbContext>(options =>
    {
        //options.UseSqlite("Data Source=banco.db"); --> Define a rota do banco, criado na pasta do proprio projeto
        options.UseSqlite("Data Source=C:\\Users\\Nei Junio\\Documents\\bancotesteconexao.db"); --> define rota do banco que esta em outra pasta do computador / servidor
    });
 *
*/


builder.Services.AddScoped<RegisterClientUseCase>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
