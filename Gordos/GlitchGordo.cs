using System;
using System.Collections.Generic;
using System.Linq;
using SRML.SR;
using SRML.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace More_Gordos.Gordos
{
	internal class GlitchGordo
	{
		public static void CreateGordo(Identifiable.Id gordoId, string gordoName)
		{
			GameObject gordo = PrefabUtils.CopyPrefab(Identifiable.Id.PINK_GORDO.GetPrefab());
			gordo.name = gordoName;
			
			SlimeDefinition pinkSlimeDef = Identifiable.Id.PINK_SLIME.GetSlimeDefinition();
			SlimeDefinition glitchSlimeDef = Identifiable.Id.GLITCH_SLIME.GetSlimeDefinition();

			Material glitchMaterial = glitchSlimeDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];

			SlimeFace glitchFace = glitchSlimeDef.AppearancesDefault[0].Face;
			GordoFaceComponents faceComp = gordo.GetComponent<GordoFaceComponents>();

			faceComp.blinkEyes = glitchFace.GetExpressionFace(SlimeFace.SlimeExpression.Blink).Eyes;
			faceComp.strainEyes = glitchFace.GetExpressionFace(SlimeFace.SlimeExpression.Scared).Eyes;
			faceComp.chompOpenMouth = glitchFace.GetExpressionFace(SlimeFace.SlimeExpression.ChompOpen).Mouth;
			faceComp.happyMouth = glitchFace.GetExpressionFace(SlimeFace.SlimeExpression.Happy).Mouth;
			faceComp.strainMouth = glitchFace.GetExpressionFace(SlimeFace.SlimeExpression.ChompClosed).Mouth;

			GordoDisplayOnMap displayOnMap = gordo.GetComponent<GordoDisplayOnMap>();
			GameObject marker = PrefabUtils.CopyPrefab(displayOnMap.markerPrefab.gameObject);
			marker.name = "GordoGlitchMarker";
			marker.GetComponent<Image>().sprite = EntryPoint.assetBundle.LoadAsset<Sprite>("iconGordoGlitch");
			displayOnMap.markerPrefab = marker.GetComponent<MapMarker>();

			GordoIdentifiable ident = gordo.GetComponent<GordoIdentifiable>();
			ident.id = gordoId;
			ident.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>(ZoneDirector.Zone.RANCH);

			GordoEat gordoEat = gordo.GetComponent<GordoEat>();
			SlimeDefinition slimeDefCopy = (SlimeDefinition)PrefabUtils.DeepCopyObject(pinkSlimeDef);
			slimeDefCopy.IdentifiableId = gordoId;
			slimeDefCopy.name = gordoName;
			slimeDefCopy.Name = gordoName;
			slimeDefCopy.Diet.EatMap = pinkSlimeDef.Diet.EatMap.ToList();
			gordoEat.slimeDefinition = slimeDefCopy;
			gordoEat.targetCount = 50;

			GameObject cratePrefab = Identifiable.Id.CRATE_REEF_01.GetPrefab();
			List<GameObject> rewards = new() { cratePrefab, cratePrefab, cratePrefab };

			GordoRewards rewardsComp = gordo.GetComponent<GordoRewards>();
			rewardsComp.rewardPrefabs = rewards.ToArray();
			rewardsComp.slimePrefab = Identifiable.Id.GLITCH_SLIME.GetPrefab();
			rewardsComp.rewardOverrides = Array.Empty<GordoRewards.RewardOverride>();

			SkinnedMeshRenderer smr = gordo.transform.Find("Vibrating/slime_gordo").GetComponent<SkinnedMeshRenderer>();
			smr.sharedMaterial = glitchMaterial;

			LookupRegistry.RegisterGordo(gordo);
		}
		public static void PostLoadGlitchGordo(Identifiable.Id gordoId)
		{
			var eat = gordoId.GetPrefab()?.GetComponent<GordoEat>();
			if (eat == null) return;

			var diet = eat.slimeDefinition.Diet;
			diet.RefreshEatMap(SRSingleton<GameContext>.Instance.SlimeDefinitions, eat.slimeDefinition);
			var glitchPogo = EnumUtils.Parse("GLITCH_POGO_FRUIT", Identifiable.Id.NONE);
			if (glitchPogo == Identifiable.Id.NONE)
				return;
			diet.EatMap.RemoveAll(x => x.eats == glitchPogo);
			diet.EatMap.Add(new SlimeDiet.EatMapEntry
			{
				becomesId = Identifiable.Id.NONE,
				producesId = Identifiable.Id.GLITCH_SLIME,
				driver = SlimeEmotions.Emotion.HUNGER,
				eats = glitchPogo,
				isFavorite = true,
				favoriteProductionCount = 2
			});
		}
	}
}
