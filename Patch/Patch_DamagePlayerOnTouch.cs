using HarmonyLib;
using More_Gordos.IdentifiableGordo;
using UnityEngine;

namespace More_Gordos.Patch
{
	[HarmonyPatch(typeof(DamagePlayerOnTouch))]
	public class Patch_DamagePlayerOnTouch
	{
		[HarmonyPatch( nameof(DamagePlayerOnTouch.TryToDamage)), HarmonyPrefix]
		public static void TryToDamage(DamagePlayerOnTouch __instance, GameObject gameObj)
		{
			GordoIdentifiable gordoIdentifiable = __instance.gameObject.GetComponent<GordoIdentifiable>();
			if (!gordoIdentifiable || gordoIdentifiable.id != OtherId.TARR_GORDO) return;
			GordoEat gordoEat = __instance.gameObject.GetComponent<GordoEat>();
			if (gordoEat.eatFX)
			{
				SRBehaviour.SpawnAndPlayFX(gordoEat.eatFX, gameObj.transform.position, gameObj.transform.localRotation);
			}
			if (gordoEat.eatCue)
			{
				SECTR_AudioSystem.Play(gordoEat.eatCue, gameObj.transform.position, false);
			}
			gordoEat.eating.Add(gameObj);
			gordoEat.SetEatenCount(gordoEat.GetEatenCount() + 1);
			if (gordoEat.GetEatenCount() >= gordoEat.GetTargetCount())
			{
				gordoEat.StartCoroutine(gordoEat.ReachedTarget());
			}
		}
	}
}
