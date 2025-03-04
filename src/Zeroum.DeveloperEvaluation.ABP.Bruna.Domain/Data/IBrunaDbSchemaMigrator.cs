using System.Threading.Tasks;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna.Data;

public interface IBrunaDbSchemaMigrator
{
    Task MigrateAsync();
}
