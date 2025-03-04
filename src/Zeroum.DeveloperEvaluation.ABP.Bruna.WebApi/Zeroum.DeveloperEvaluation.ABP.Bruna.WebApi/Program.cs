using Microsoft.EntityFrameworkCore;
using Zeroum.DeveloperEvaluation.ABP.Bruna.Interface;
using Zeroum.DeveloperEvaluation.ABP.Bruna.Repository;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao contêiner
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();

builder.Services.AddControllers();
// Configuração do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews();

// Configura o CORS para permitir qualquer origem, método e cabeçalho
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()    // Permite qualquer origem
              .AllowAnyMethod()    // Permite qualquer método (GET, POST, etc.)
              .AllowAnyHeader();   // Permite qualquer cabeçalho
    });
});

var app = builder.Build();

// Habilita o CORS no pipeline de requisições
app.UseCors("AllowAllOrigins");  // Aqui é onde a política de CORS é aplicada

// Configura o pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
