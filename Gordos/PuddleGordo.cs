using System;
using System.Collections.Generic;
using System.Linq;
using More_Gordos.Components;
using SRML.SR;
using SRML.Utils;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace More_Gordos.Gordos
{
	internal class PuddleGordo
	{
		public static void CreateGordo(Identifiable.Id gordoId, string gordoName)
		{
			GameObject gordo = PrefabUtils.CopyPrefab(Identifiable.Id.TANGLE_GORDO.GetPrefab());

			GameObject flower = gordo.transform.Find("Vibrating/bone_root/bone_slime/bone_core/bone_jiggle_top/bone_skin_top/Flower").gameObject;
			flower.SetActive(false);
			Object.DestroyImmediate(flower.GetComponent<BoxCollider>());
			Object.DestroyImmediate(flower.GetComponent<MeshCollider>());

			gordo.name = gordoName;

			SlimeDefinition slimeDef = Identifiable.Id.PUDDLE_SLIME.GetSlimeDefinition();
			SlimeAppearance appearance = slimeDef.AppearancesDefault[0];
			Material material = Object.Instantiate(appearance.Structures[0].DefaultMaterials[0]);
			material.SetFloat("_VertexOffset", 0f);

			GordoEat eat = gordo.GetComponent<GordoEat>();
			eat.allEats = Identifiable.LIQUID_CLASS.Where(Identifiable.IsWater).ToList();
			eat.slimeDefinition = slimeDef;
			eat.targetCount = 50;

			SlimeFace face = appearance.Face;
			GordoFaceComponents faceComp = gordo.GetComponent<GordoFaceComponents>();
			faceComp.blinkEyes = face.GetExpressionFace(SlimeFace.SlimeExpression.Blink).Eyes;
			faceComp.strainEyes = face.GetExpressionFace(SlimeFace.SlimeExpression.Scared).Eyes;
			faceComp.chompOpenMouth = material;
			faceComp.happyMouth = material;
			faceComp.strainMouth = material;

			GordoDisplayOnMap mapDisplay = gordo.GetComponent<GordoDisplayOnMap>();
			GameObject marker = PrefabUtils.CopyPrefab(mapDisplay.markerPrefab.gameObject);
			marker.name = "GordoPuddleMarker";
			marker.GetComponent<Image>().sprite = EntryPoint.assetBundle.LoadAsset<Sprite>("iconGordoPuddle");
			mapDisplay.markerPrefab = marker.GetComponent<MapMarker>();

			GordoIdentifiable ident = gordo.GetComponent<GordoIdentifiable>();
			ident.id = gordoId;
			ident.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>(ZoneDirector.Zone.RANCH);

			SkinnedMeshRenderer smr = gordo.transform.Find("Vibrating/slime_gordo").GetComponent<SkinnedMeshRenderer>();
			smr.sharedMaterial = material;
			smr.sharedMaterials[0] = material;
			smr.material = material;
			smr.materials[0] = material;

			GameObject cratePrefab = Identifiable.Id.CRATE_MOSS_01.GetPrefab();
			List<GameObject> rewards = new() { cratePrefab, cratePrefab, cratePrefab };

			GordoRewards rewardsComp = gordo.GetComponent<GordoRewards>();
			rewardsComp.rewardPrefabs = rewards.ToArray();
			rewardsComp.slimePrefab = Identifiable.Id.PUDDLE_SLIME.GetPrefab();
			rewardsComp.rewardOverrides = Array.Empty<GordoRewards.RewardOverride>();

			LookupRegistry.RegisterGordo(gordo);
		}
	}
}
