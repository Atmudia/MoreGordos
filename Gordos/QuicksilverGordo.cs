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
	internal class QuicksilverGordo
	{
		public static void CreateGordo(Identifiable.Id gordoId, string gordoName)
		{
			GameObject gordo = PrefabUtils.CopyPrefab(Identifiable.Id.TANGLE_GORDO.GetPrefab());
			gordo.name = gordoName;

			GameObject flower = gordo.transform.Find("Vibrating/bone_root/bone_slime/bone_core/bone_jiggle_top/bone_skin_top/Flower").gameObject;
			flower.SetActive(true);
			Object.DestroyImmediate(flower.GetComponent<BoxCollider>());
			Object.DestroyImmediate(flower.GetComponent<MeshCollider>());
			flower.GetComponent<MeshFilter>().sharedMesh = SRObjects.Get<Mesh>("quicksilvercrest");
			flower.transform.localScale = Vector3.one;
			flower.GetComponent<MeshRenderer>().sharedMaterial = SRObjects.Get<Material>("slimeQuickSilverBase");
			flower.transform.localPosition = new Vector3(0f, 0f, 1f);

			SlimeDefinition slimeDef = Identifiable.Id.QUICKSILVER_SLIME.GetSlimeDefinition();
			SlimeAppearance appearance = slimeDef.AppearancesDefault[0];
			Material mat = appearance.Structures[0].DefaultMaterials[0];

			GordoEat eat = gordo.GetComponent<GordoEat>();
			eat.slimeDefinition = slimeDef;
			eat.targetCount = 50;

			SlimeFace face = appearance.Face;
			GordoFaceComponents faceComp = gordo.GetComponent<GordoFaceComponents>();
			faceComp.blinkEyes = face.GetExpressionFace(SlimeFace.SlimeExpression.Blink).Eyes;
			faceComp.strainEyes = face.GetExpressionFace(SlimeFace.SlimeExpression.Scared).Eyes;
			faceComp.chompOpenMouth = mat;
			faceComp.happyMouth = mat;
			faceComp.strainMouth = mat;

			GordoDisplayOnMap mapDisplay = gordo.GetComponent<GordoDisplayOnMap>();
			GameObject marker = PrefabUtils.CopyPrefab(mapDisplay.markerPrefab.gameObject);
			marker.name = "GordoQuicksilverMarker";
			marker.GetComponent<Image>().sprite = EntryPoint.assetBundle.LoadAsset<Sprite>("iconGordoQuicksilver");
			mapDisplay.markerPrefab = marker.GetComponent<MapMarker>();

			GordoIdentifiable ident = gordo.GetComponent<GordoIdentifiable>();
			ident.id = gordoId;
			ident.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>(ZoneDirector.Zone.RANCH);

			SkinnedMeshRenderer smr = gordo.transform.Find("Vibrating/slime_gordo").GetComponent<SkinnedMeshRenderer>();
			smr.sharedMaterial = mat;
			smr.sharedMaterials[0] = mat;
			smr.material = mat;
			smr.materials[0] = mat;

			GameObject cratePrefab = Identifiable.Id.CRATE_MOSS_01.GetPrefab();
			List<GameObject> rewards = new() { cratePrefab, cratePrefab, cratePrefab };
			GordoRewards rewardsComp = gordo.GetComponent<GordoRewards>();
			rewardsComp.rewardPrefabs = rewards.ToArray();
			rewardsComp.slimePrefab = Identifiable.Id.QUICKSILVER_SLIME.GetPrefab();
			rewardsComp.rewardOverrides = Array.Empty<GordoRewards.RewardOverride>();

			LookupRegistry.RegisterGordo(gordo);
		}
	}
}
