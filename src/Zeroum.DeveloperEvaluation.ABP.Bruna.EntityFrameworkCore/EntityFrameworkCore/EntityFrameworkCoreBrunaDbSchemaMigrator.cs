using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Zeroum.DeveloperEvaluation.ABP.Bruna.Data;
using Volo.Abp.DependencyInjection;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna.EntityFrameworkCore;

public class EntityFrameworkCoreBrunaDbSchemaMigrator
    : IBrunaDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBrunaDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BrunaDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BrunaDbContext>()
            .Database
            .MigrateAsync();
    }
}
