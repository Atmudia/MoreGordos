using System;
using System.Collections.Generic;
using More_Gordos.Utility;
using SRML.SR;
using SRML.Utils;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace More_Gordos.Gordos
{
	internal class FireGordo
	{
		public static void CreateGordo(Identifiable.Id gordoId, string gordoName)
		{
			GameObject gordo = PrefabUtils.CopyPrefab(Identifiable.Id.TANGLE_GORDO.GetPrefab());
			gordo.name = gordoName;

			DamagePlayerOnTouch damage = gordo.AddComponent<DamagePlayerOnTouch>();
			damage.damagePerTouch = 100;

			GameObject flower = gordo.transform.Find("Vibrating/bone_root/bone_slime/bone_core/bone_jiggle_top/bone_skin_top/Flower").gameObject;
			flower.SetActive(false);
			Object.DestroyImmediate(flower.GetComponent<BoxCollider>());
			Object.DestroyImmediate(flower.GetComponent<MeshCollider>());

			SlimeDefinition fireSlimeDef = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.FIRE_SLIME);
			SlimeAppearance fireAppearance = fireSlimeDef.AppearancesDefault[0];
			Material fireMat = Object.Instantiate(fireAppearance.Structures[0].DefaultMaterials[0]);
			fireMat.SetFloat("_VertexOffset", 0f);

			GordoEat eat = gordo.GetComponent<GordoEat>();
			eat.eatCue = SRObjects.Get<SECTR_AudioCue>("IncinerateSmall");
			eat.eatFX = SRObjects.Get<GameObject>("fxIncinerate");

			SlimeDefinition pinkSlimeDef = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME);
			SlimeDefinition slimeDefCopy = (SlimeDefinition)PrefabUtils.DeepCopyObject(eat.slimeDefinition);
			slimeDefCopy.AppearancesDefault = pinkSlimeDef.AppearancesDefault;
			slimeDefCopy.Diet = pinkSlimeDef.Diet;
			slimeDefCopy.IdentifiableId = gordoId;
			slimeDefCopy.name = gordoName;
			eat.slimeDefinition = slimeDefCopy;
			eat.targetCount = 50;

			SlimeFace face = fireAppearance.Face;
			GordoFaceComponents faceComp = gordo.GetComponent<GordoFaceComponents>();
			faceComp.blinkEyes = face.GetExpressionFace(SlimeFace.SlimeExpression.Blink).Eyes;
			faceComp.strainEyes = face.GetExpressionFace(SlimeFace.SlimeExpression.Scared).Eyes;
			faceComp.chompOpenMouth = fireMat;
			faceComp.happyMouth = fireMat;
			faceComp.strainMouth = fireMat;

			GordoDisplayOnMap displayOnMap = gordo.GetComponent<GordoDisplayOnMap>();
			GameObject marker = PrefabUtils.CopyPrefab(displayOnMap.markerPrefab.gameObject);
			marker.name = "GordoFireMarker";
			marker.GetComponent<Image>().sprite = EntryPoint.assetBundle.LoadAsset<Sprite>("iconGordoFire");
			displayOnMap.markerPrefab = marker.GetComponent<MapMarker>();

			GordoIdentifiable identifiable = gordo.GetComponent<GordoIdentifiable>();
			identifiable.id = gordoId;
			identifiable.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>(ZoneDirector.Zone.RANCH);

			SkinnedMeshRenderer smr = gordo.transform.Find("Vibrating/slime_gordo").GetComponent<SkinnedMeshRenderer>();
			smr.sharedMaterial = fireMat;
			smr.sharedMaterials[0] = fireMat;
			smr.material = fireMat;
			smr.materials[0] = fireMat;

			GameObject cratePrefab = Identifiable.Id.CRATE_MOSS_01.GetPrefab();
			List<GameObject> rewards = new() { cratePrefab, cratePrefab, cratePrefab };

			GordoRewards rewardsComp = gordo.GetComponent<GordoRewards>();
			rewardsComp.rewardPrefabs = rewards.ToArray();
			rewardsComp.slimePrefab = Identifiable.Id.FIRE_SLIME.GetPrefab();
			rewardsComp.rewardOverrides = Array.Empty<GordoRewards.RewardOverride>();

			LookupRegistry.RegisterGordo(gordo);
		}
	}
}
