using System;
using More_Gordos.IdentifiableGordo;
using More_Gordos.Utility;
using SRML.SR;
using SRML.Utils;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace More_Gordos.Gordos
{
	internal class TwinkleGordo
	{
		public static void CreateGordo(Identifiable.Id gordoId, string gordoName)
		{
			var twinkleGordo = PrefabUtils.CopyPrefab(Identifiable.Id.PINK_GORDO.GetPrefab());
			twinkleGordo.name = gordoName;

			var markerSprite = EntryPoint.assetBundle.LoadAsset<Sprite>("iconGordoTwinkle");
			var baseMarker = Identifiable.Id.PINK_GORDO.GetPrefab().GetComponent<GordoDisplayOnMap>().markerPrefab.gameObject;
			var markerObj = PrefabUtils.CopyPrefab(baseMarker);
			markerObj.name = "GordoTwinkleMarker";
			markerObj.GetComponent<Image>().sprite = markerSprite;
			twinkleGordo.GetComponent<GordoDisplayOnMap>().markerPrefab = markerObj.GetComponent<MapMarker>();

			var identifiable = twinkleGordo.GetComponent<GordoIdentifiable>();
			identifiable.id = gordoId;
			identifiable.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>(ZoneDirector.Zone.RANCH);

			twinkleGordo.GetComponent<GordoEat>().targetCount = 50;

			twinkleGordo.GetComponent<GordoRewards>().rewardPrefabs = new[]
			{
				Identifiable.Id.ECHO_NOTE_11.GetPrefab(),
				Identifiable.Id.CRATE_REEF_01.GetPrefab(),
				Identifiable.Id.ECHO_NOTE_02.GetPrefab(),
				Identifiable.Id.ECHO_NOTE_03.GetPrefab(),
				Identifiable.Id.ECHO_NOTE_07.GetPrefab(),
				Identifiable.Id.ECHO_NOTE_06.GetPrefab(),
				Identifiable.Id.ECHO_NOTE_10.GetPrefab(),
				Identifiable.Id.ECHO_NOTE_01.GetPrefab(),
				Identifiable.Id.ECHO_NOTE_05.GetPrefab(),
				Identifiable.Id.ECHO_NOTE_11.GetPrefab(),
				Identifiable.Id.CRATE_REEF_01.GetPrefab(),
				Identifiable.Id.CRATE_REEF_01.GetPrefab(),
				Identifiable.Id.ECHO_NOTE_04.GetPrefab()
			};
			twinkleGordo.GetComponent<GordoRewards>().rewardOverrides = Array.Empty<GordoRewards.RewardOverride>();

			LookupRegistry.RegisterGordo(twinkleGordo);

			SRCallbacks.PreSaveGameLoaded += _ =>
			{
				var echoGordo = SRObjects.Get<EchoNoteGordo>("echoNoteGordo").gordo.gameObject;
				var sourceRenderer = echoGordo.GetComponentInChildren<SkinnedMeshRenderer>();

				var targetGordo = Ids.TWINKLE_GORDO.GetPrefab();
				var portal = echoGordo.transform.parent.Find("TwinkleSlime Portal")?.gameObject.Instantiate(targetGordo.transform);
				if (portal != null)
				{
					portal.SetActive(true);
					portal.transform.localScale = Vector3.one * 0.3f;
					portal.transform.localPosition = new Vector3(0, 0.05f, 0);
				}

				targetGordo.GetComponent<GordoEat>().burstCue =
					SRObjects.Get<GameObject>("ShapeParticles").GetComponentInChildren<SECTR_PointSource>().Cue;

				var newMat = Object.Instantiate(sourceRenderer.sharedMaterial);
				var slimeObj = targetGordo.transform.Find("Vibrating/slime_gordo")?.gameObject;
				var slimeRend = slimeObj?.GetComponent<SkinnedMeshRenderer>();
				if (slimeRend != null)
				{
					slimeRend.sharedMaterial = newMat;
					slimeRend.material = newMat;
					slimeRend.sharedMaterials = new[] { newMat };
					slimeRend.materials = new[] { newMat };
					slimeRend.sharedMesh = sourceRenderer.sharedMesh;
				}
			};
		}
	}
}
