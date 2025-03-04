using Volo.Abp.Modularity;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna;

/* Inherit from this class for your domain layer tests. */
public abstract class BrunaDomainTestBase<TStartupModule> : BrunaTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
