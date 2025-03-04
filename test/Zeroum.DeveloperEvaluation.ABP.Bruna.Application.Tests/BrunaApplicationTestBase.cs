using Volo.Abp.Modularity;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna;

public abstract class BrunaApplicationTestBase<TStartupModule> : BrunaTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
