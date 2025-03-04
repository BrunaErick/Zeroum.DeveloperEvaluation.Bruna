using Zeroum.DeveloperEvaluation.ABP.Bruna.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BrunaController : AbpControllerBase
{
    protected BrunaController()
    {
        LocalizationResource = typeof(BrunaResource);
    }
}
