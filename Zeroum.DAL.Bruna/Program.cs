using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao contêiner
builder.Services.AddRazorPages();

// Adiciona o DbContext ao contêiner
builder.Services.AddDbContext<DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


try
{
    using (var connection = new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")))
    {
        connection.Open();
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Erro de conexão com o banco de dados. {ex.Message}");

}
var app = builder.Build();

// Aplica as migrações pendentes ao iniciar a aplicação
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
    dbContext.Database.Migrate(); // Aplica as migrações pendentes
}

// Configura o pipeline de requisição HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();