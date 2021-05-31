using System;
using System.Collections.Generic;
using HarmonyLib;
using MonomiPark.SlimeRancher.DataModel;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MoreGordos
{
	// Token: 0x0200001B RID: 27
	[HarmonyPatch(typeof(HolidayDirector))]
	[HarmonyPatch("InitForLevel")]
	public class TwinkleGet
	{
		// Token: 0x060000AE RID: 174 RVA: 0x00005FE0 File Offset: 0x000041E0
		public static void Prefix()
		{
			if (!Levels.isSpecial())
			{ 
				Material material = null;
				foreach (string text in GordoLocations)
				{
					EchoNoteGordoModel echoNoteGordoModel =
						SRSingleton<SceneContext>.Instance.GameModel.GetEchoNoteGordoModel(text);
					if (echoNoteGordoModel != null)
					{
						GameObject privateField = echoNoteGordoModel.GetPrivateField<GameObject>("gameObject");
						if (!material) 
						{
							foreach (EchoNoteGordoModel.Participant participant in privateField
								.GetComponentsInChildren<EchoNoteGordoModel.Participant>(true))
							{
								EchoNoteGordo echoNoteGordo = (EchoNoteGordo) participant;
								if (echoNoteGordo.gordo)
								{
									if (!material)
									{
										SkinnedMeshRenderer componentInChildren = echoNoteGordo.gordo.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
										if (componentInChildren && componentInChildren.sharedMaterial)
											material = componentInChildren.sharedMaterial;
									}
								}
							}
						}
					}
				}
				GameObject prefab = SRSingleton<GameContext>.Instance.LookupDirector.GetGordo(Id.TWINKLE_GORDO);
				Material material2 = Object.Instantiate<Material>(material);
				GameObject child = prefab.transform.Find("Vibrating/slime_gordo").gameObject;
				SkinnedMeshRenderer render = child.GetComponent<SkinnedMeshRenderer>();
				render.sharedMaterial = material2;
				render.sharedMaterials[0] = material2;
				render.material = material2;
				render.materials[0] = material2;
			}
		}

		private static List<string> GordoLocations = new List<string>
		{
			"gordoEchoNote1",
			"gordoEchoNote2",
			"gordoEchoNote3",
			"gordoEchoNote4",
			"gordoEchoNote5",
			"gordoEchoNote6",
			"gordoEchoNote7",
			"gordoEchoNote8",
			"gordoEchoNote9",
			"gordoEchoNote10",
			"gordoEchoNote11",
			"gordoEchoNote12",
			"gordoEchoNote13"
		};


	}
}

