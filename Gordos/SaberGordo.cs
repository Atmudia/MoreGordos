using System;
using System.Collections.Generic;
using SRML.SR;
using SRML.Utils;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace More_Gordos.Gordos
{
	internal class SaberGordo
	{
		public static void CreateGordo(Identifiable.Id gordoId, string gordoName)
		{
			var gordo = PrefabUtils.CopyPrefab(Identifiable.Id.TANGLE_GORDO.GetPrefab());
			gordo.name = gordoName;

			var saberDef = Identifiable.Id.SABER_SLIME.GetSlimeDefinition();
			var mat = saberDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];

			var meshObj = gordo.transform.Find("Vibrating/bone_root/bone_slime/bone_core/bone_jiggle_top/bone_skin_top/Flower").gameObject;
			Object.DestroyImmediate(meshObj.GetComponent<BoxCollider>());
			Object.DestroyImmediate(meshObj.GetComponent<MeshCollider>());
			meshObj.GetComponent<MeshFilter>().sharedMesh = Object.Instantiate(EntryPoint.assetBundle.LoadAsset<Mesh>("slime_saber_LOD2"));
			meshObj.transform.localScale = Vector3.one;
			meshObj.transform.localPosition = new Vector3(0f, -0.4f, 0.6f);
			meshObj.GetComponent<MeshRenderer>().sharedMaterial = mat;

			var face = gordo.GetComponent<GordoFaceComponents>();
			face.happyMouth = mat;
			face.chompOpenMouth = mat;
			face.strainMouth = mat;

			var marker = PrefabUtils.CopyPrefab(gordo.GetComponent<GordoDisplayOnMap>().markerPrefab.gameObject);
			marker.name = "GordoSaberMarker";
			marker.GetComponent<Image>().sprite = EntryPoint.assetBundle.LoadAsset<Sprite>("iconGordoSaber");
			gordo.GetComponent<GordoDisplayOnMap>().markerPrefab = marker.GetComponent<MapMarker>();

			var ident = gordo.GetComponent<GordoIdentifiable>();
			ident.id = gordoId;
			ident.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>(ZoneDirector.Zone.RANCH);

			var eat = gordo.GetComponent<GordoEat>();
			var newDef = (SlimeDefinition)PrefabUtils.DeepCopyObject(eat.slimeDefinition);
			newDef.AppearancesDefault = saberDef.AppearancesDefault;
			newDef.Diet = saberDef.Diet;
			newDef.IdentifiableId = gordoId;
			newDef.name = gordoName;
			eat.slimeDefinition = newDef;
			eat.targetCount = 50;

			var crate = Identifiable.Id.CRATE_REEF_01.GetPrefab();
			var rewards = gordo.GetComponent<GordoRewards>();
			rewards.rewardPrefabs = new[] { crate, crate, crate };
			rewards.slimePrefab = Identifiable.Id.SABER_SLIME.GetPrefab();
			rewards.rewardOverrides = Array.Empty<GordoRewards.RewardOverride>();

			var mesh = gordo.transform.Find("Vibrating/slime_gordo").GetComponent<SkinnedMeshRenderer>();
			mesh.sharedMaterial = mat;
			mesh.sharedMaterials[0] = mat;
			mesh.material = mat;
			mesh.materials[0] = mat;

			LookupRegistry.RegisterGordo(gordo);
		}
	}
}
