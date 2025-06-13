using HarmonyLib;
using UnityEngine;

namespace More_Gordos.Components
{
    [HarmonyPatch(typeof(GordoEat))]
    internal static class Patch_GordoEat
    {
        internal static int GROW_BY = 1;

        [HarmonyPatch(nameof(GordoEat.MaybeEat)), HarmonyPrefix]
        public static bool MaybeEat(GordoEat __instance, ref bool __result, Collider col)
        {
            var gid = __instance.GetComponent<GordoIdentifiable>();
            if (gid == null || gid.id != Identifiable.Id.PUDDLE_GORDO)
                return true;

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
                    SRBehaviour.SpawnAndPlayFX(__instance.EatFavoriteFX, col.transform.position, col.transform.rotation);

                if (__instance.GetEatenCount() >= __instance.GetTargetCount())
                    __instance.StartCoroutine(__instance.ReachedTarget());

                __result = true;
                return false;
            }

            __result = false;
            return false;
        }

        [HarmonyPatch(nameof(GordoEat.Start)), HarmonyPrefix]
        public static bool Start(GordoEat __instance)
        {
            var gid = __instance.GetComponent<GordoIdentifiable>();
            if (gid == null || gid.id != Identifiable.Id.PUDDLE_GORDO)
                return true;

            if (__instance.GetEatenCount() != -1 && __instance.GetEatenCount() >= __instance.GetTargetCount())
                __instance.ImmediateReachedTarget();

            return false;
        }

        [HarmonyPatch(nameof(GordoEat.GetDirectFoodGroupsMsg)), HarmonyPrefix]
        public static bool GetDirectFoodGroupsMsg(GordoEat __instance, ref string __result)
        {
            var gid = __instance.GetComponent<GordoIdentifiable>();
            if (gid == null)
                return true;

            if (gid.id == Identifiable.Id.PUDDLE_GORDO)
            {
                __result = "m.foodgroup.water";
                return false;
            }

            if (gid.id == IdentifiableGordo.OtherId.TARR_GORDO)
            {
                __result = "m.foodgroup.tarr";
                return false;
            }

            return true;
        }

    }
}
