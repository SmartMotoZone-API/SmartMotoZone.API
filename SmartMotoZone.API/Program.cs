using SmartMotoZone.API.Extensions;
using SmartMotoZone.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Adiciona o Swagger configurado via extensão
builder.Services.AddCustomizedSwagger(); // Extensão de Swagger

// Configurar o DbContext com Oracle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Moto Zone API v1");
        options.RoutePrefix = string.Empty; // Swagger na raiz (localhost:5000/)
        options.DocumentTitle = "Smart Moto Zone Docs";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
