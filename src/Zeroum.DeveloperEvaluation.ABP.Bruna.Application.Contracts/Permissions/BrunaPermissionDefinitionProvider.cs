using Zeroum.DeveloperEvaluation.ABP.Bruna.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna.Permissions;

public class BrunaPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BrunaPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(BrunaPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BrunaResource>(name);
    }
}
