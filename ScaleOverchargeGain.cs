using HarmonyLib;

namespace Necrofancy.Repo.ScaleOverchargeToUpgrades;

[HarmonyPatch(typeof(PhysGrabber), nameof(PhysGrabber.PhysGrabOverCharge))]
public static class ScaleOverchargeGain
{
    static void Prefix(PhysGrabber __instance, ref float _amount, ref float _multiplier)
    {
        string id = SemiFunc.PlayerGetSteamID(__instance.playerAvatar);
        var strengthTable = StatsManager.instance.playerUpgradeStrength;
        if (strengthTable.TryGetValue(id, out var strength))
            _amount *= Math.Max(Plugin.ConstantFactor + Plugin.ScalingFactor * strength, 0f);
    }
}