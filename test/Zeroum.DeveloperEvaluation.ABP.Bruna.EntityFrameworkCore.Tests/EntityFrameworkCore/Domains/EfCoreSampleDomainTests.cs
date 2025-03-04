using Zeroum.DeveloperEvaluation.ABP.Bruna.Samples;
using Xunit;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna.EntityFrameworkCore.Domains;

[Collection(BrunaTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<BrunaEntityFrameworkCoreTestModule>
{

}
