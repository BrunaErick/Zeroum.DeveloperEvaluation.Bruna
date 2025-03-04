using Zeroum.DeveloperEvaluation.ABP.Bruna.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BrunaEntityFrameworkCoreModule),
    typeof(BrunaApplicationContractsModule)
)]
public class BrunaDbMigratorModule : AbpModule
{
}
