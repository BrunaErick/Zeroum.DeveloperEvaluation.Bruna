using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna.Data;

/* This is used if database provider does't define
 * IBrunaDbSchemaMigrator implementation.
 */
public class NullBrunaDbSchemaMigrator : IBrunaDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
