using System;
using System.Collections.Generic;
using SRML.SR;
using SRML.Utils;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace More_Gordos.Gordos
{
	internal class TarrGordo
	{
		public static void CreateGordo(Identifiable.Id gordoId, string gordoName)
		{
			var gordo = PrefabUtils.CopyPrefab(Identifiable.Id.PINK_GORDO.GetPrefab());
			var tarr = Identifiable.Id.TARR_SLIME.GetPrefab();

			var slimeDef = (SlimeDefinition)PrefabUtils.DeepCopyObject(Identifiable.Id.TARR_SLIME.GetSlimeDefinition());
			var mat = slimeDef.AppearancesDefault[0].Structures[1].DefaultMaterials[0];

			var eyeComp = tarr.GetComponent<SlimeEyeComponents>();
			var mouthComp = tarr.GetComponent<SlimeMouthComponents>();

			var eat = gordo.GetComponent<GordoEat>();
			eat.slimeDefinition = slimeDef;

			gordo.AddComponent<DamagePlayerOnTouch>();

			var eyeMat = Object.Instantiate(eyeComp.chompClosedEyes);
			var mouthMat = Object.Instantiate(mouthComp.chompClosedMouth);
			eyeMat.SetTexture("_FaceTexture", tarrEyeTexture);
			mouthMat.SetTexture("_FaceTexture", tarrMouthTexture);

			var face = gordo.GetComponent<GordoFaceComponents>();
			face.blinkEyes = eyeComp.chompClosedEyes;
			face.strainEyes = eyeMat;
			face.chompOpenMouth = mouthComp.chompClosedMouth;
			face.happyMouth = mouthComp.chompClosedMouth;
			face.strainMouth = mouthMat;

			gordo.name = gordoName;
			var ident = gordo.GetComponent<GordoIdentifiable>();
			ident.id = gordoId;
			ident.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>(ZoneDirector.Zone.RANCH);

			gordo.transform.Find("Vibrating/slime_gordo").GetComponent<SkinnedMeshRenderer>().sharedMaterial = mat;

			var marker = PrefabUtils.CopyPrefab(gordo.GetComponent<GordoDisplayOnMap>().markerPrefab.gameObject);
			marker.name = "GordoTarrMarker";
			marker.GetComponent<Image>().sprite = tarrGordoIcon;
			gordo.GetComponent<GordoDisplayOnMap>().markerPrefab = marker.GetComponent<MapMarker>();

			var reward = Identifiable.Id.TARR_SLIME.GetPrefab();
			var rewards = gordo.GetComponent<GordoRewards>();
			rewards.rewardPrefabs = new[] { reward, reward, reward };
			rewards.slimePrefab = reward;
			rewards.rewardOverrides = Array.Empty<GordoRewards.RewardOverride>();

			LookupRegistry.RegisterGordo(gordo);
		}

		public static void PostLoadTarrGordo(Identifiable.Id gordoId)
		{
			var eat = gordoId.GetPrefab()?.GetComponent<GordoEat>();
			if (eat == null) return;

			var diet = eat.slimeDefinition.Diet;
			diet.RefreshEatMap(SRSingleton<GameContext>.Instance.SlimeDefinitions, eat.slimeDefinition);
			diet.EatMap.RemoveAll(x => x.eats == Identifiable.Id.PUDDLE_SLIME);
			diet.EatMap.Add(new SlimeDiet.EatMapEntry
			{
				becomesId = Identifiable.Id.NONE,
				producesId = Identifiable.Id.TARR_SLIME,
				driver = SlimeEmotions.Emotion.AGITATION,
				eats = Identifiable.Id.PUDDLE_SLIME,
				isFavorite = true,
				favoriteProductionCount = 50
			});
		}

		static Texture tarrMouthTexture = EntryPoint.tarrAssetBundle.LoadAsset<Texture>("mouthTarrMellow");
		static Texture tarrEyeTexture = EntryPoint.tarrAssetBundle.LoadAsset<Texture>("eyeTarrMellow");
		static Sprite tarrGordoIcon = EntryPoint.tarrAssetBundle.LoadAsset<Sprite>("iconGordoTarr");
	}
}
