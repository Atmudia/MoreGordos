using UnityEngine;
using HarmonyLib;

namespace MoreGordos
{
    public class GordoEatWater : MonoBehaviour
    {
    }

    internal static class EatWaterPatches
    {
        [HarmonyPatch(typeof(GordoEat), "MaybeEat")]
        internal static class MaybeEatPatch
        {
            /// <summary>
            /// How much the gordo grows every time it gets fed water. Being set at 2 is equal to if a gordo eats a favorite food.
            /// </summary>
            internal static int GROW_BY = 1;

            internal static bool Prefix(GordoEat __instance, ref bool __result, Collider col)
            {
                if (__instance.GetComponent<GordoEatWater>() != null)
                {
                    if (!__instance.CanEat())
                    {
                        __result = false;
                        return false;
                    }
                    Identifiable component = col.GetComponent<Identifiable>();
                    if (component != null && Identifiable.IsWater(component.id) && !__instance.eating.Contains(col.gameObject))
                    {
                        __instance.DoEat(col.gameObject);
                        __instance.SetEatenCount(__instance.GetEatenCount() + GROW_BY);
                        if (GROW_BY >= 2)
                            SRBehaviour.SpawnAndPlayFX(__instance.EatFavoriteFX, col.gameObject.transform.position, col.gameObject.transform.rotation);
                        if (__instance.GetEatenCount() >= __instance.GetTargetCount())
                            __instance.StartCoroutine(__instance.ReachedTarget());
                        __result = true;
                        return false;
                    }
                    __result = false;
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(GordoEat), "Start")]
        internal static class StartPatch
        {
            internal static bool Prefix(GordoEat __instance)
            {
                if (__instance.GetComponent<GordoEatWater>() != null)
                {
                    int eatenCount = __instance.GetEatenCount();
                    if (eatenCount == -1 || eatenCount < __instance.GetTargetCount())
                        return false;
                    __instance.ImmediateReachedTarget();
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(GordoEat), "GetDirectFoodGroupsMsg")]
        internal static class GetDirectFoodGroupsMsgPatche
        {
            internal static bool Prefix(GordoEat __instance, ref string __result)
            {
                if (__instance.GetComponent<GordoEatWater>() != null)
                {
                    __result = "m.foodgroup.water";
                    return false;
                }
                return true;
            }
        }
    }
}
