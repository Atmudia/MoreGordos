using HarmonyLib;
using More_Gordos.IdentifiableGordo;
using UnityEngine;

namespace More_Gordos.Patch
{
	[HarmonyPatch(typeof(DestroyAndShockOnTouching))]
	public class Patch_DestroyAndShockOnTouching
	{
		[HarmonyPatch(nameof(DestroyAndShockOnTouching.OnCollisionEnter)), HarmonyPatch]
		public static bool OnCollisionEnter(Collision col, DestroyAndShockOnTouching __instance)
		{
			if (!col.gameObject.TryGetComponent(out GordoIdentifiable ident) || ident.id != Ids.QUICKSILVER_GORDO)
				return true;
			if (__instance.destroyFX)
			{
				SRBehaviour.SpawnAndPlayFX(__instance.destroyFX, __instance.transform.position, __instance.transform.rotation);
			}
			GordoEat component = col.gameObject.GetComponent<GordoEat>();
			GameObject gameObject = component.eatFX;
			int num = 1;
			bool flag4 = __instance.id == Identifiable.Id.VALLEY_AMMO_2;
			if (flag4)
			{
				gameObject = component.EatFavoriteFX;
				num = 2;
			}
			if (gameObject)
			{
				SRBehaviour.SpawnAndPlayFX(gameObject, col.transform.position, col.transform.localRotation);
			}
			if (component.eatCue)
			{
				SECTR_AudioSystem.Play(component.eatCue, col.transform.position, false);
			}
			component.eating.Add(__instance.gameObject);
			component.SetEatenCount(component.GetEatenCount() + num);
			if (component.GetEatenCount() >= component.GetTargetCount())
			{
				component.StartCoroutine(component.ReachedTarget());
			}
			Destroyer.DestroyActor(__instance.gameObject, "DestroyAndShockOnTouching.DestroyAndShock", false);
			return false;
		}
	}
}
