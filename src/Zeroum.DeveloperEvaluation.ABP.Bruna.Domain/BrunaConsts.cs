using Volo.Abp.Identity;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna;

public static class BrunaConsts
{
    public const string DbTablePrefix = "App";
    public const string? DbSchema = null;
    public const string AdminEmailDefaultValue = IdentityDataSeedContributor.AdminEmailDefaultValue;
    public const string AdminPasswordDefaultValue = IdentityDataSeedContributor.AdminPasswordDefaultValue;
}
