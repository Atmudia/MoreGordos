using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using More_Gordos.IdentifiableGordo;
using SRML;
using SRML.Console;
using SRML.Utils;
using UnityEngine;

namespace More_Gordos.Patch
{

    [HarmonyPatch]
    public static class Patch_GordoSnare
    {
        public static bool GetGordoIdState = false;

        [HarmonyPatch(typeof(GordoSnare), nameof(GordoSnare.GetGordoIdForBait)), HarmonyPrefix]
        public static bool GetGordoIdForBait(ref Identifiable.Id __result, GordoSnare __instance)
        {
            var baitTypeId = __instance.model.baitTypeId;
            if (EntryPoint.SnareableGordos.TryGetValue(baitTypeId, out Identifiable.Id gordoId))
            {
                __result = gordoId;
                return false;
            }

            if (Identifiable.IsSlime(baitTypeId) && baitTypeId != Identifiable.Id.GOLD_SLIME &&
                baitTypeId != Identifiable.Id.TARR_SLIME && baitTypeId != Identifiable.Id.LUCKY_SLIME)
            {
                __result = EnumUtils.Parse<Identifiable.Id>("TARR_GORDO");
                return false;
            }
            GetGordoIdState = true;
            return true;
        }

        [HarmonyPatch(typeof(GordoSnare), nameof(GordoSnare.OnTriggerEnter)), HarmonyPrefix, HarmonyPriority(800)]
        public static bool OnTriggerEnter(GordoSnare __instance, Collider col)
        {
            if (SRModLoader.IsModPresent("tarrgordo"))
                return true;
            if (!col.isTrigger && !__instance.bait && !__instance.isSnared)
            {
                Identifiable component = col.GetComponent<Identifiable>();
                if (!component) 
                    return true;
                if (Identifiable.IsSlime(component.id) && component.id != Identifiable.Id.GOLD_SLIME && component.id != Identifiable.Id.TARR_SLIME && component.id != Identifiable.Id.LUCKY_SLIME)
                {
                    if (__instance.baitAttachedFx)
                    {
                        SRBehaviour.SpawnAndPlayFX(__instance.baitAttachedFx, __instance.gameObject);
                    }
                    Destroyer.DestroyActor(col.gameObject, "GordoSnare.OnTriggerEnter", false);
                    __instance.AttachBait(component.id);
                    return false;
                }
            }
            return true;
        }

        [HarmonyPatch(typeof(LookupDirector), nameof(LookupDirector.GordoEntries), MethodType.Getter), HarmonyPostfix]
        public static void GetGordoEntries(ref IEnumerable<GameObject> __result)
        {
            if (!GetGordoIdState)
                return;
            GetGordoIdState = false;
            var gameObjects = __result.ToList();
            foreach (var snareableGordos in EntryPoint.SnareableGordos.Values)
            {
                var gameObject = snareableGordos.GetPrefab();
                if (gameObject)
                {
                    gameObjects.Remove(gameObject);
                }
            }
            gameObjects.Remove(EnumUtils.Parse<Identifiable.Id>("TARR_GORDO").GetPrefab());
            __result = gameObjects;
        }
    }
}

    
