using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace Necrofancy.Repo.ScaleOverchargeToUpgrades;

[BepInPlugin(Id, Name, Version)]
public class Plugin : BaseUnityPlugin
{
    const string Id = "Necrofancy.OverchargeScalesToStrength";
    const string Name = "Overcharge Scales To Strength";
    const string Version = "1.0.0";
    private readonly Harmony _harmony = new(Id);

    private static ConfigEntry<float>? _constantConfig;
    private static ConfigEntry<float>? _scalingConfig;
    
    public static float ConstantFactor => _constantConfig?.Value ?? 0.05f;
    public static float ScalingFactor => _scalingConfig?.Value ?? 0.15f;

    public void Awake()
    {
        _harmony.PatchAll(Assembly.GetExecutingAssembly());
        
        _constantConfig = Config.Bind("Balancing", "ConstantFactor", 0.05f, "Defines starting percentage for overcharge");
        _scalingConfig = Config.Bind("Balancing", "ScalingFactor", 0.15f, "Defines the growth per Strength upgrade applied");
    }
}