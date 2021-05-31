using System.Collections.Generic;
using HarmonyLib;
using MonomiPark.SlimeRancher.DataModel;
using MoreGordos;
using UnityEngine;
using Object = System.Object;

namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_LuckyGordo
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.STRANGE_DIAMOND_CRAFT &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.LUCKY_GORDO;
                return false;
            }

            return true;
        }
    }
}
namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_GlitchGordo
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.MANIFOLD_CUBE_CRAFT &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.GLITCH_GORDO;
                return false;
            }

            return true;
        }
    }
}
namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_FireGordo
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.LAVA_DUST_CRAFT &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.FIRE_GORDO;
                return false;
            }

            return true;
        }
    }
}


namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_PuddleGordo
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.DEEP_BRINE_CRAFT &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Identifiable.Id.PUDDLE_GORDO;
                return false;
            }

            return true;
        }
    }
}
namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_SaberGordo
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.SPICY_TOFU &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.SABER_GORDO;
                return false;
            }

            return true;
        }
    }
}
