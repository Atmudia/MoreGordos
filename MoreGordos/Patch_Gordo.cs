using System.Collections.Generic;
using HarmonyLib;
using MonomiPark.SlimeRancher.DataModel;
using MonomiPark.SlimeRancher.Regions;
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
            if (baitId == Identifiable.Id.STRANGE_DIAMOND_CRAFT)
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
            if (baitId == Identifiable.Id.MANIFOLD_CUBE_CRAFT)
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
            if (baitId == Identifiable.Id.LAVA_DUST_CRAFT)
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
            if (baitId == Identifiable.Id.DEEP_BRINE_CRAFT)
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
            if (baitId == Identifiable.Id.SPICY_TOFU)
            {
                __result = Id.SABER_GORDO;
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
	public class Patch_Gordo
	{
		[HarmonyPriority(Priority.First)]
		public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
		{
			if (SRML.SRModLoader.IsModPresent("tarrgordo"))
				return true;
			if (Identifiable.IsSlime(__instance.GetPrivateField<SnareModel>("model").baitTypeId) && Randoms.SHARED.GetInRange(0, 100) <= 75)
			{
				__result = OtherId.TARR_GORDO;
				return false;
			}
			return true;
		}
	}

	[HarmonyPatch(typeof(GordoSnare))]
	[HarmonyPatch("AttachBait")]
	public class Patch_AttachSlimes
	{
		private static void RemoveComponent<T>(GameObject gameObject) where T : Component
		{
			T component = gameObject.GetComponent<T>();
			if (!(component != null))
				return;
			Destroyer.Destroy(component, "GordoSnare.RemoveComponent");
		}

		private static void RemoveComponents<T>(GameObject gameObject) where T : Component
		{
			foreach (T component in gameObject.GetComponents<T>())
				Destroyer.Destroy(component, "GordoSnare.RemoveComponents");
		}

		private static void RemoveComponentInChildren<T>(GameObject gameObject) where T : Component
		{
			T componentInChildren = gameObject.GetComponentInChildren<T>();
			if (!(componentInChildren != null))
				return;
			Destroyer.Destroy(componentInChildren, "GordoSnare.RemoveComponentInChildren");
		}

		private static void RemoveComponentsInChildren<T>(GameObject gameObject) where T : Component
		{
			foreach (T componentsInChild in gameObject.GetComponentsInChildren<T>())
				Destroyer.Destroy(componentsInChild, "GordoSnare.RemoveComponentsInChildren");
		}

		public static bool Prefix(GordoSnare __instance, Identifiable.Id id)
		{
			if (SRML.SRModLoader.IsModPresent("tarrgordo"))
				return true;
			if (Identifiable.IsSlime(id))
			{
				__instance.InvokePrivateMethod("ClearBait");
				__instance.GetPrivateField<SnareModel>("model").baitTypeId = id;
				__instance.bait = UnityEngine.Object.Instantiate<GameObject>(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(id), __instance.transform);
				__instance.bait.transform.position = __instance.baitPosition.transform.position;
				__instance.bait.transform.rotation = Quaternion.identity;
				RemoveComponents<Collider>(__instance.bait);
				RemoveComponent<DragFloatReactor>(__instance.bait);
				RemoveComponent<Rigidbody>(__instance.bait);
				RemoveComponent<KeepUpright>(__instance.bait);
				RemoveComponent<DontGoThroughThings>(__instance.bait);
				RemoveComponent<SECTR_PointSource>(__instance.bait);
				RemoveComponent<RegionMember>(__instance.bait);
				RemoveComponent<ChickenRandomMove>(__instance.bait);
				RemoveComponent<ChickenVampirism>(__instance.bait);
				RemoveComponent<PlaySoundOnHit>(__instance.bait);
				RemoveComponent<ResourceCycle>(__instance.bait);
				RemoveComponent<Reproduce>(__instance.bait);
				RemoveComponent<SlimeEmotions>(__instance.bait);
				RemoveComponent<SlimeFaceAnimator>(__instance.bait);
				RemoveComponent<SlimeEat>(__instance.bait);
				RemoveComponent<SlimeEatAsh>(__instance.bait);
				RemoveComponent<SlimeEatWater>(__instance.bait);
				RemoveComponent<SlimeEatTrigger>(__instance.bait);
				RemoveComponent<SlimeSubbehaviourPlexer>(__instance.bait);
				RemoveComponents<SlimeSubbehaviour>(__instance.bait);
				Animator componentInChildren = __instance.bait.GetComponentInChildren<Animator>();
				if (componentInChildren != null)
				{
					componentInChildren.SetBool("grounded", true);
				}
				return false;
			}
			return true;
		}
	}

	[HarmonyPatch(typeof(GordoSnare))]
	[HarmonyPatch("OnTriggerEnter")]
	public class Patch_SnareSlimes
	{

		[HarmonyPriority(Priority.First)]
		public static bool Prefix(GordoSnare __instance, Collider col)
		{
			if (SRML.SRModLoader.IsModPresent("tarrgordo"))
				return true;
			if (!(col.isTrigger || !(__instance.bait == null) || __instance.GetPrivateField<bool>("isSnared")))
			{
				Identifiable component = col.GetComponent<Identifiable>();
				if (component != null)
				{
					if (Identifiable.IsSlime(component.id) && component.id != Identifiable.Id.GOLD_SLIME && component.id != Identifiable.Id.TARR_SLIME && component.id != Identifiable.Id.LUCKY_SLIME)
					{
						if (__instance.baitAttachedFx != null)
							SRBehaviour.SpawnAndPlayFX(__instance.baitAttachedFx, __instance.gameObject);
						Destroyer.DestroyActor(col.gameObject, "GordoSnare.OnTriggerEnter");
						__instance.InvokePrivateMethod("AttachBait", component.id);
						return false;
					}
				}
			}
			return true;
		}
	}

	//[HarmonyPatch(typeof(TargetingUI))]
	//[HarmonyPatch("GetGordoInfoText")]
	//public class Patch_TarrInfo
	//{
	//	public static void Postfix(TargetingUI __instance, ref string __result, GameObject gordoObj)
	//	{
	//		if (gordoObj.GetComponent<GordoIdentifiable>().id == OtherId.TARR_GORDO)
	//		{
	//			__result = SRSingleton<GameContext>.Instance.MessageDirector.GetBundle("ui").Xlate(MessageUtil.Compose("m.hudinfo_diet", new string[1]
	//			{
	//				"m.foodgroup.tarr"
	//			}));
	//		}
	//	}
	//}
}