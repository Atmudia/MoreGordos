using System;
using More_Gordos.IdentifiableGordo;
using SRML.SR;
using SRML.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace More_Gordos.Gordos
{
	internal class DigiTarrGordo
	{
		public static void CreateGordo(Identifiable.Id gordoId, string gordoName)
		{
			var gordo = PrefabUtils.CopyPrefab(OtherId.TARR_GORDO.GetPrefab());
			var slimeDef = (SlimeDefinition)PrefabUtils.DeepCopyObject(Identifiable.Id.GLITCH_TARR_SLIME.GetSlimeDefinition());
			slimeDef.Diet.AdditionalFoods = new[]
			{
				Identifiable.Id.MANIFOLD_CUBE_CRAFT
			};
			slimeDef.Diet.MajorFoodGroups = Array.Empty<SlimeEat.FoodGroup>();
			var mat = slimeDef.AppearancesDefault[0].Structures[1].DefaultMaterials[0];

			var eat = gordo.GetComponent<GordoEat>();
			eat.slimeDefinition = slimeDef;
			eat.targetCount = 10;

			gordo.AddComponent<DamagePlayerOnTouch>();
			

			gordo.name = gordoName;
			var ident = gordo.GetComponent<GordoIdentifiable>();
			ident.id = gordoId;
			ident.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>(ZoneDirector.Zone.RANCH);

			gordo.transform.Find("Vibrating/slime_gordo").GetComponent<SkinnedMeshRenderer>().sharedMaterial = mat;

			var marker = PrefabUtils.CopyPrefab(gordo.GetComponent<GordoDisplayOnMap>().markerPrefab.gameObject);
			marker.name = "GordoTarrMarker";
			marker.GetComponent<Image>().sprite = digitarrGordoIcon;
			gordo.GetComponent<GordoDisplayOnMap>().markerPrefab = marker.GetComponent<MapMarker>();

			var reward = Identifiable.Id.GLITCH_TARR_SLIME.GetPrefab();
			var rewards = gordo.GetComponent<GordoRewards>();
			rewards.rewardPrefabs = new[] { reward, reward, reward };
			rewards.slimePrefab = reward;
			rewards.rewardOverrides = Array.Empty<GordoRewards.RewardOverride>();

			LookupRegistry.RegisterGordo(gordo);
		}

		public static void PostLoadDigiTarrGordo(Identifiable.Id gordoId)
		{
			var eat = gordoId.GetPrefab()?.GetComponent<GordoEat>();
			if (eat == null) return;

			var diet = eat.slimeDefinition.Diet;
			diet.RefreshEatMap(SRSingleton<GameContext>.Instance.SlimeDefinitions, eat.slimeDefinition);
			diet.EatMap.Clear();
			diet.EatMap.Add(new SlimeDiet.EatMapEntry
			{
				becomesId = Identifiable.Id.NONE,
				producesId = Identifiable.Id.TARR_SLIME,
				driver = SlimeEmotions.Emotion.AGITATION,
				eats = Identifiable.Id.MANIFOLD_CUBE_CRAFT,
				isFavorite = true,
				favoriteProductionCount = 1
			});
		}

		private static Sprite digitarrGordoIcon = EntryPoint.CreateSprite(EntryPoint.LoadImage("iconGordoDigiTarr"));
	}
}
