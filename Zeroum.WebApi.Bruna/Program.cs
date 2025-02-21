using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Zeroum.BI.Bruna;
using Zeroum.BI.Bruna.Interfaces;
using Zeroum.DAL.Bruna.Interfaces;
using Zeroum.DAL.Bruna.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()    // Permite qualquer origem
              .AllowAnyMethod()    // Permite qualquer m�todo (GET, POST, etc.)
              .AllowAnyHeader();   // Permite qualquer cabe�alho
    });
});


builder.Services.AddScoped<IClientesBI, ClientesBI>();
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
    dbContext.Database.Migrate(); // Aplica as migra��es pendentes
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
