using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Zeroum.DAL.Bruna;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    private readonly IConfiguration _configuration;

    public DbContext(DbContextOptions<DbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
