using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class BrunaDbContextFactory : IDesignTimeDbContextFactory<BrunaDbContext>
{
    public BrunaDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        BrunaEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<BrunaDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new BrunaDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Zeroum.DeveloperEvaluation.ABP.Bruna.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
