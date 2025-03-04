using Volo.Abp.Modularity;
using Zeroum.DeveloperEvaluation.ABP.Bruna.Tests;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna;

[DependsOn(
    typeof(BrunaApplicationModule),
    typeof(ClientesRepositoryTests)
)]
public class BrunaApplicationTestModule : AbpModule
{

}
