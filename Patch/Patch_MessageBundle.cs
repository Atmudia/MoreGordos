using HarmonyLib;

[HarmonyPatch(typeof(MessageBundle))]

public class Patch_MessageBundle
{
    [HarmonyPatch(nameof(MessageBundle.GetResourceString), typeof(string), typeof(bool)), HarmonyPrefix]
    public static bool GetResourceString(MessageBundle __instance, string key, bool reportMissing, ref string __result)
    {
        if (__instance.path is "pedia" && key is "t.modded_puddle_gordo")
        {
            __result = __instance.Get("t.puddle_gordo", reportMissing);
            return false;
        }
        if (__instance.path is "ui" && key is "m.foodgroup.manifold_cube" )
        {
            __result = SRSingleton<GameContext>.Instance.MessageDirector.GetBundle("actor").GetResourceString("l.manifold_cube_craft", reportMissing);
            return false;
        }
        return true;
    }
    
}