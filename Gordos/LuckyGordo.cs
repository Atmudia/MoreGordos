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
	internal class LuckyGordo
	{
		public static void CreateGordo(Identifiable.Id gordoId, string gordoName)
		{
			GameObject gordo = PrefabUtils.CopyPrefab(Identifiable.Id.TANGLE_GORDO.GetPrefab());
			gordo.name = gordoName;

			GameObject flower = gordo.transform.Find("Vibrating/bone_root/bone_slime/bone_core/bone_jiggle_top/bone_skin_top/Flower").gameObject;
			flower.SetActive(false);
			Object.DestroyImmediate(flower.GetComponent<BoxCollider>());
			Object.DestroyImmediate(flower.GetComponent<MeshCollider>());
			

			SlimeDefinition slimeDef = Identifiable.Id.LUCKY_SLIME.GetSlimeDefinition();
			Material baseMaterial = slimeDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
			Material coinMaterial = slimeDef.AppearancesDefault[0].Structures[2].DefaultMaterials[0];

			GameObject ears = gordo.transform.Find("Vibrating/ears_n_tail_LOD0").gameObject;
			GameObject coin = gordo.transform.Find("Vibrating/bone_root/bone_slime/luckycat_coin_LOD1").gameObject;
			ears.SetActive(true);
			coin.SetActive(true);

			MeshFilter coinMeshFilter = coin.GetComponent<MeshFilter>();
			coinMeshFilter.sharedMesh = SRObjects.Get<Mesh>("luckycat_coin_LOD0");

			MeshRenderer coinRenderer = coinMeshFilter.GetComponent<MeshRenderer>();
			coinRenderer.sharedMaterial = coinMaterial;
			coinRenderer.transform.position = new Vector3(0f, 3.8f, 1f);

			ears.GetComponent<SkinnedMeshRenderer>().sharedMaterial = baseMaterial;

			GordoFaceComponents tabbyFaceComp = PrefabUtils.CopyPrefab(Identifiable.Id.TABBY_GORDO.GetPrefab()).GetComponent<GordoFaceComponents>();
			GordoFaceComponents gordoFaceComp = gordo.GetComponent<GordoFaceComponents>();
			gordoFaceComp.happyMouth = tabbyFaceComp.happyMouth;

			GordoDisplayOnMap mapDisplay = gordo.GetComponent<GordoDisplayOnMap>();
			GameObject marker = PrefabUtils.CopyPrefab(mapDisplay.markerPrefab.gameObject);
			marker.name = "GordoLuckyMarker";
			marker.GetComponent<Image>().sprite = EntryPoint.assetBundle.LoadAsset<Sprite>("iconGordoLucky");
			mapDisplay.markerPrefab = marker.GetComponent<MapMarker>();

			GordoIdentifiable ident = gordo.GetComponent<GordoIdentifiable>();
			ident.id = gordoId;
			ident.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>(ZoneDirector.Zone.RANCH);

			GordoEat gordoEat = gordo.GetComponent<GordoEat>();
			SlimeDefinition slimeCopy = (SlimeDefinition)PrefabUtils.DeepCopyObject(gordoEat.slimeDefinition);
			slimeCopy.AppearancesDefault = slimeDef.AppearancesDefault;
			slimeCopy.Diet = slimeDef.Diet;
			slimeCopy.IdentifiableId = gordoId;
			slimeCopy.name = gordoName;
			gordoEat.slimeDefinition = slimeCopy;
			gordoEat.targetCount = 50;

			GameObject cratePrefab = Identifiable.Id.CRATE_REEF_01.GetPrefab();
			List<GameObject> rewards = new() { cratePrefab, cratePrefab, cratePrefab };

			GordoRewards rewardsComp = gordo.GetComponent<GordoRewards>();
			rewardsComp.rewardPrefabs = rewards.ToArray();
			rewardsComp.slimePrefab = Identifiable.Id.LUCKY_SLIME.GetPrefab();
			rewardsComp.rewardOverrides = Array.Empty<GordoRewards.RewardOverride>();

			SkinnedMeshRenderer smr = gordo.transform.Find("Vibrating/slime_gordo").GetComponent<SkinnedMeshRenderer>();
			smr.sharedMaterial = baseMaterial;
			smr.sharedMaterials[0] = baseMaterial;
			smr.material = baseMaterial;
			smr.materials[0] = baseMaterial;

			LookupRegistry.RegisterGordo(gordo);
		}
	}
}
