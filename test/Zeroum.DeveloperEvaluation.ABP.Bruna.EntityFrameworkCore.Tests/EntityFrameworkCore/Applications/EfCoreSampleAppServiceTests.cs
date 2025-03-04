using Zeroum.DeveloperEvaluation.ABP.Bruna.Samples;
using Xunit;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna.EntityFrameworkCore.Applications;

[Collection(BrunaTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<BrunaEntityFrameworkCoreTestModule>
{

}
