using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using MonoMod.Utils;
using More_Gordos.Gordos;
using More_Gordos.IdentifiableGordo;
using Secret_Style_Things.Utils;
using SRML;
using SRML.SR;
using SRML.Utils;
using UnityEngine;
using Object = UnityEngine.Object;
using SRObjects = More_Gordos.Utility.SRObjects;
namespace More_Gordos
{
	public class EntryPoint : ModEntryPoint
	{

		public static Dictionary<Identifiable.Id, Identifiable.Id> SnareableGordos;
		public static AssetBundle LoadAssetBundle(string name)
		{
			var manifestResourceStream = typeof(EntryPoint).Assembly.GetManifestResourceStream("More_Gordos." + name);
			return AssetBundle.LoadFromStream(manifestResourceStream);
		}

		public override void PreLoad()
		{
			if (AccessTools.TypeByName("ChromaRegistry") == null)
			{
				throw new Exception("This version of SRML is really outdated please use the latest");
			}
			SnareableGordos = new Dictionary<Identifiable.Id, Identifiable.Id>
			{
				{
					Identifiable.Id.DEEP_BRINE_CRAFT,
					Identifiable.Id.PUDDLE_GORDO
				},
				{
					Identifiable.Id.STRANGE_DIAMOND_CRAFT,
					Ids.LUCKY_GORDO
				},
				{
					Identifiable.Id.SPICY_TOFU,
					Ids.SABER_GORDO
				},
				{
					Identifiable.Id.MANIFOLD_CUBE_CRAFT,
					Ids.GLITCH_GORDO
				},
				{
					Identifiable.Id.LAVA_DUST_CRAFT,
					Ids.FIRE_GORDO
				},
				{
					Identifiable.Id.VALLEY_AMMO_2,
					Ids.QUICKSILVER_GORDO
				}
			};

			foreach (var id in EnumUtils.GetAll<Identifiable.Id>().Where(x => x.ToString().Contains("ECHO_NOTE_")))
			{
				SnareableGordos.Add(id, Ids.TWINKLE_GORDO);

			}
			foreach (var id in SnareableGordos.Keys)
			{
				id.RegisterAsSnareable();
			}
			HarmonyInstance.PatchAll(typeof(EntryPoint).Assembly);
			assetBundle = LoadAssetBundle("moregordos");
			TranslationPatcher.AddPediaTranslation("t.lucky_gordo", "Lucky Gordo");
			TranslationPatcher.AddPediaTranslation("t.fire_gordo", "Fire Gordo");
			TranslationPatcher.AddPediaTranslation("t.glitch_gordo", "Glitch Gordo");
			TranslationPatcher.AddPediaTranslation("t.twinkle_gordo", "Twinkle Gordo");
			TranslationPatcher.AddPediaTranslation("t.saber_gordo", "Saber Gordo");
			TranslationPatcher.AddPediaTranslation("t.quicksilver_gordo", "Quicksilver Gordo");
			if (!SRModLoader.IsModPresent("tarrgordo"))
			{
				tarrAssetBundle = LoadAssetBundle("tarrmellow");
				TranslationPatcher.AddPediaTranslation("t.tarr_gordo", "Tarr Gordo");
				OtherId.TARR_GORDO = IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "TARR_GORDO");
				Identifiable.TARR_CLASS.Add(OtherId.TARR_GORDO);
			}
			if (SRModLoader.IsModPresent("secretstylethings"))
			{
				SecretStyle();
			}
		}

		public override void Load()
		{
			GlitchGordo.CreateGordo(Ids.GLITCH_GORDO, "gordoGlitch");
			LuckyGordo.CreateGordo(Ids.LUCKY_GORDO, "gordoLucky");
			FireGordo.CreateGordo(Ids.FIRE_GORDO, "gordoFire");
			PuddleGordo.CreateGordo(Identifiable.Id.PUDDLE_GORDO, "gordoPuddle");
			TwinkleGordo.CreateGordo(Ids.TWINKLE_GORDO, "gordoTwinkle");
			SaberGordo.CreateGordo(Ids.SABER_GORDO, "gordoSaber");
			QuicksilverGordo.CreateGordo(Ids.QUICKSILVER_GORDO, "gordoQuicksilver");
			if (!SRModLoader.IsModPresent("tarrgordo"))
			{
				TarrGordo.CreateGordo(OtherId.TARR_GORDO, "gordoTarr");
			}
		}

		public override void PostLoad()
		{
			if (!SRModLoader.IsModPresent("tarrgordo"))
			{
				TarrGordo.PostLoadTarrGordo(OtherId.TARR_GORDO);
			}
		}

		private static void SecretStyle()
		{
			SlimeUtils.SecretStyleData[Ids.LUCKY_GORDO] = new SecretStyleData(assetBundle.LoadAsset<Sprite>("iconGordoLuckyExotic"));
			SlimeUtils.SecretStyleData[Ids.FIRE_GORDO] = new SecretStyleData(assetBundle.LoadAsset<Sprite>("iconGordoFireExotic"));
			SlimeUtils.SecretStyleData[Ids.SABER_GORDO] = new SecretStyleData(assetBundle.LoadAsset<Sprite>("iconGordoSaberExotic"));
			SlimeUtils.SecretStyleData[Ids.QUICKSILVER_GORDO] = new SecretStyleData(assetBundle.LoadAsset<Sprite>("iconGordoQuicksilverExotic"));
			SlimeUtils.SecretStyleData[Ids.GLITCH_GORDO] = new SecretStyleData(assetBundle.LoadAsset<Sprite>("iconGordoGlitchExotic"));
			SlimeUtils.SecretStyleData[Identifiable.Id.PUDDLE_GORDO] = new SecretStyleData(assetBundle.LoadAsset<Sprite>("iconGordoPuddleExotic"));
			SlimeUtils.ExtraApperanceApplicators.Add(Ids.QUICKSILVER_GORDO, delegate(Transform x, SlimeAppearance y)
			{
				GameObject flower = x.transform.Find("Vibrating/bone_root/bone_slime/bone_core/bone_jiggle_top/bone_skin_top/Flower").gameObject;
				if (y.SaveSet == SlimeAppearance.AppearanceSaveSet.SECRET_STYLE)
				{
					flower.GetComponent<MeshFilter>().sharedMesh = SRObjects.Get<Mesh>("qucksilver_DLC_crest_LOD1");
					flower.transform.localScale = new Vector3(1f, 1f, 1f);
					flower.transform.localPosition = new Vector3(0f, -1f, 0.4f);
					flower.transform.localEulerAngles = new Vector3(333.3111f, 3.8758f, 0.5057f);
					flower.gameObject.GetComponent<MeshRenderer>().sharedMaterial = y.Structures[1].DefaultMaterials[0];
				}
				else
				{
					flower.gameObject.GetComponent<MeshRenderer>().sharedMaterial = y.Structures[0].DefaultMaterials[0];
					flower.GetComponent<MeshFilter>().sharedMesh = SRObjects.Get<Mesh>("quicksilvercrest");
					flower.transform.localScale = new Vector3(1f, 1f, 1f);
					flower.GetComponent<MeshRenderer>().sharedMaterial = y.Structures[0].DefaultMaterials[0];
					flower.transform.localPosition = new Vector3(0f, -1f, 1f);
					flower.transform.localEulerAngles = new Vector3(345.9387f, 0f, 0f);
				}
				GordoFaceComponents component = x.GetComponent<GordoFaceComponents>();
				component.chompOpenMouth = y.Structures[0].DefaultMaterials[0];
				component.happyMouth = y.Structures[0].DefaultMaterials[0];
				component.strainMouth = y.Structures[0].DefaultMaterials[0];
			});
			SlimeUtils.ExtraApperanceApplicators.Add(Identifiable.Id.PUDDLE_GORDO, delegate(Transform x, SlimeAppearance y)
			{
				GameObject flower = x.transform.Find("Vibrating/bone_root/bone_slime/bone_core/bone_jiggle_top/bone_skin_top/Flower").gameObject;
				if (y.SaveSet == SlimeAppearance.AppearanceSaveSet.SECRET_STYLE)
				{
					flower.SetActive(true);
					flower.transform.localPosition = new Vector3(0f, -1.74f, 0f);
					flower.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					flower.transform.localScale = new Vector3(1.6521f, 1.6521f, 1.6521f);
					flower.GetComponent<MeshFilter>().sharedMesh = SRObjects.Get<Mesh>("puddle_DLC_flower_LOD0");
					flower.GetComponent<MeshRenderer>().sharedMaterial = y.Structures[1].DefaultMaterials[0];
				}
				else
				{
					flower.SetActive(false);
				}
				SkinnedMeshRenderer component3 = x.Find("Vibrating/slime_gordo").GetComponent<SkinnedMeshRenderer>();
				GordoFaceComponents component4 = x.GetComponent<GordoFaceComponents>();
				Material material = Object.Instantiate(y.Structures[0].DefaultMaterials[0]);
				material.SetFloat("_VertexOffset", 0f);
				component4.chompOpenMouth = material;
				component4.happyMouth = material;
				component4.strainMouth = material;
				component3.material = material;
			});
			SlimeUtils.ExtraApperanceApplicators.Add(Ids.FIRE_GORDO, delegate(Transform x, SlimeAppearance y)
			{
				GameObject flower = x.transform.Find("Vibrating/bone_root/bone_slime/bone_core/bone_jiggle_top/bone_skin_top/Flower").gameObject;
				if (y.SaveSet == SlimeAppearance.AppearanceSaveSet.SECRET_STYLE)
				{
					flower.GetComponent<MeshRenderer>().sharedMaterial = y.Structures[0].DefaultMaterials[0];
					flower.SetActive(true);
					flower.GetComponent<MeshFilter>().sharedMesh = SRObjects.Get<Mesh>("fire_DLC_horns_LOD0");
					flower.transform.localPosition = new Vector3(0f, -2f, -0.3f);
					flower.transform.localScale = new Vector3(1.5f, 2f, 2f);
					flower.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				}
				else
				{
					flower.SetActive(false);
				}
				SkinnedMeshRenderer component5 = x.Find("Vibrating/slime_gordo").GetComponent<SkinnedMeshRenderer>();
				GordoFaceComponents component6 = x.GetComponent<GordoFaceComponents>();
				Material material2 = Object.Instantiate<Material>(y.Structures[0].DefaultMaterials[0]);
				material2.SetFloat("_VertexOffset", 0f);
				component6.chompOpenMouth = material2;
				component6.happyMouth = material2;
				component6.strainMouth = material2;
				component5.material = material2;
			});
			SlimeUtils.ExtraApperanceApplicators.Add(Ids.GLITCH_GORDO, delegate(Transform x, SlimeAppearance y)
			{
				if (y.SaveSet == SlimeAppearance.AppearanceSaveSet.SECRET_STYLE)
				{
					x.GetComponent<GordoFaceComponents>().blinkEyes = y.Face.GetExpressionFace(SlimeFace.SlimeExpression.Happy).Eyes;
				}
			});
			SlimeUtils.ExtraApperanceApplicators.Add(Ids.SABER_GORDO, delegate(Transform x, SlimeAppearance y)
			{
				x.transform.Find("Vibrating/bone_root/bone_slime/bone_core/bone_jiggle_top/bone_skin_top/Flower").gameObject.GetComponent<MeshRenderer>().sharedMaterial = y.Structures[0].DefaultMaterials[0];
				GordoFaceComponents component7 = x.GetComponent<GordoFaceComponents>();
				component7.chompOpenMouth = y.Structures[0].DefaultMaterials[0];
				component7.happyMouth = y.Structures[0].DefaultMaterials[0];
				component7.strainMouth = y.Structures[0].DefaultMaterials[0];
			});
			SlimeUtils.ExtraApperanceApplicators.Add(Ids.LUCKY_GORDO, delegate(Transform x, SlimeAppearance y)
			{
				GameObject earnsNTail = x.transform.Find("Vibrating/ears_n_tail_LOD0").gameObject;
				GameObject luckyCat = x.transform.Find("Vibrating/bone_root/bone_slime/luckycat_coin_LOD1").gameObject;
				if (y.SaveSet == SlimeAppearance.AppearanceSaveSet.SECRET_STYLE)
				{
					earnsNTail.GetComponent<SkinnedMeshRenderer>().sharedMaterial = y.Structures[1].DefaultMaterials[0];
					earnsNTail.GetComponent<SkinnedMeshRenderer>().sharedMesh = SRObjects.Get<Mesh>("lucky_DLC_ears_n_tail_LOD0");
					luckyCat.GetComponent<MeshRenderer>().sharedMaterial = y.Structures[2].DefaultMaterials[0];
				}
				else
				{
					earnsNTail.GetComponent<SkinnedMeshRenderer>().sharedMaterial = y.Structures[1].DefaultMaterials[0];
					earnsNTail.GetComponent<SkinnedMeshRenderer>().sharedMesh = SRObjects.Get<Mesh>("ears_n_tail_LOD0");
					luckyCat.GetComponent<MeshRenderer>().sharedMaterial = y.Structures[2].DefaultMaterials[0];
				}
			});
		}
		public static AssetBundle assetBundle;

		public static AssetBundle tarrAssetBundle;
	}
}
