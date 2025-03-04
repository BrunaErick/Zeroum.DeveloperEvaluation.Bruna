using Microsoft.Extensions.Localization;
using Zeroum.DeveloperEvaluation.ABP.Bruna.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna;

[Dependency(ReplaceServices = true)]
public class BrunaBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<BrunaResource> _localizer;

    public BrunaBrandingProvider(IStringLocalizer<BrunaResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
