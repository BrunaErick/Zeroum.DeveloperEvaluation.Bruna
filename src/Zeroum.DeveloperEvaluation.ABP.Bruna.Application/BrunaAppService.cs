using Zeroum.DeveloperEvaluation.ABP.Bruna.Localization;
using Volo.Abp.Application.Services;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna;

/* Inherit your application services from this class.
 */
public abstract class BrunaAppService : ApplicationService
{
    protected BrunaAppService()
    {
        LocalizationResource = typeof(BrunaResource);
    }
}
