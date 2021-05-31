using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using HarmonyLib;
using SRML.SR;
using SRML.Utils;
using UnityEngine;
using UnityEngine.UI;
using MonomiPark;
using MonomiPark.SlimeRancher.DataModel;
using MonomiPark.SlimeRancher.Regions;
using MonomiPark.SlimeRancher.Serializable.Optional;
using SRML;
using UnityEngine.Experimental.GlobalIllumination;
using Object = UnityEngine.Object;
using String = System.String;

namespace MoreGordos
{
    class Lucky_Gordo
    {

        public static void CreateGordo(Identifiable.Id GordoId, string GordoName)
        {

            GameObject Prefab = PrefabUtils.CopyPrefab(GameContext.Instance.LookupDirector?.GetGordo(Identifiable.Id.TANGLE_GORDO));
            Prefab.name = GordoName;
            GameObject baseSlime = PrefabUtils.CopyPrefab(GameContext.Instance.LookupDirector?.GetPrefab(Identifiable.Id.LUCKY_SLIME));
            baseSlime.GetComponent<Vacuumable>().size = Vacuumable.Size.LARGE;
            SlimeDefinition baseSlimeDef = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME);
            // Get Material
            Material ModelMat = baseSlimeDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
            SlimeEyeComponents baseSlimeEyes = baseSlime.GetComponent<SlimeEyeComponents>();
            SlimeMouthComponents baseSlimeMouth = baseSlime.GetComponent<SlimeMouthComponents>();

            // Load Components;
            SlimeDefinition LuckySlime = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME);
            Material CoinMaterial = LuckySlime.AppearancesDefault[0].Structures[2].DefaultMaterials[0];
            GameObject ears = Prefab.transform.Find("Vibrating/ears_n_tail_LOD0").gameObject;
            GameObject tangleflower = Prefab.transform.Find("Vibrating/bone_root/bone_slime/bone_core/bone_jiggle_top/bone_skin_top/Flower").gameObject;
            GameObject luckycoin = Prefab.transform.Find("Vibrating/bone_root/bone_slime/luckycat_coin_LOD1").gameObject;
            ears.SetActive(true);
            tangleflower.SetActive(false);
            luckycoin.SetActive(true);

            MeshFilter luckycoinchanger = luckycoin.GetComponent<MeshFilter>();//
            luckycoinchanger.sharedMesh = Main.assetBundle.LoadAsset<Mesh>("luckycat_coin_LOD0");
            MeshRenderer luckycoincolor = luckycoinchanger.GetComponent<MeshRenderer>();
            luckycoincolor.sharedMaterial = CoinMaterial;
            luckycoincolor.transform.position = new Vector3(0, 3.8f, 1);

            //luckycoin.transform.localScale = new Vector3(1.001f, 1.00f, 1.00f);


            SkinnedMeshRenderer earschanger = ears.GetComponent<SkinnedMeshRenderer>();
            earschanger.sharedMaterial = ModelMat;

            //Mouth
            GameObject PrefabTabby = PrefabUtils.CopyPrefab(GameContext.Instance.LookupDirector?.GetGordo(Identifiable.Id.TABBY_GORDO));
            GordoFaceComponents faceTabby = PrefabTabby.GetComponent<GordoFaceComponents>();
            GordoFaceComponents faceTangle = Prefab.GetComponent<GordoFaceComponents>();
            faceTangle.happyMouth = faceTabby.happyMouth;







            //Marker for map
            GordoDisplayOnMap disp = Prefab.GetComponent<GordoDisplayOnMap>();
            GameObject markerPrefab = PrefabUtils.CopyPrefab(disp.markerPrefab.gameObject);
            markerPrefab.name = "GordoLuckyMarker";
            markerPrefab.GetComponent<Image>().sprite = Main.assetBundle.LoadAsset<Sprite>("icon_lucky_gordo"); ;
            disp.markerPrefab = markerPrefab.GetComponent<MapMarker>();
            //Ids
            GordoIdentifiable iden = Prefab.GetComponent<GordoIdentifiable>();
            iden.id = GordoId;
            iden.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>();
            //Appearance & diet
            GordoEat eat = Prefab.GetComponent<GordoEat>();
            SlimeDefinition oldDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(eat.slimeDefinition);
            oldDefinition.AppearancesDefault = baseSlimeDef.AppearancesDefault;
            oldDefinition.Diet = baseSlimeDef.Diet;
            oldDefinition.IdentifiableId = GordoId;
            oldDefinition.name = GordoName;
            eat.slimeDefinition = oldDefinition;
            eat.targetCount = 50; //How many food it need to be fed to pop
            GameObject prefab =
                SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.CRATE_REEF_01);

            List<GameObject> rews = new List<GameObject>()
            {
                prefab,
                prefab,
                prefab
            };

            GordoRewards rew = Prefab.GetComponent<GordoRewards>();
            rew.rewardPrefabs = rews.ToArray();
            rew.slimePrefab = GameContext.Instance.LookupDirector.GetPrefab(Identifiable.Id.LUCKY_SLIME);
            rew.rewardOverrides = new GordoRewards.RewardOverride[0];

            GameObject child = Prefab.transform.Find("Vibrating/slime_gordo").gameObject;
            SkinnedMeshRenderer render = child.GetComponent<SkinnedMeshRenderer>();
            render.sharedMaterial = ModelMat;
            render.sharedMaterials[0] = ModelMat;
            render.material = ModelMat;
            render.materials[0] = ModelMat;
            LookupRegistry.RegisterGordo(Prefab);
        }
    }
}
namespace MoreGordos
{
    class Glitch_Gordo
    {

        public static void CreateGordo(Identifiable.Id GordoId, string GordoName)
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(GameContext.Instance.LookupDirector?.GetGordo(Identifiable.Id.TANGLE_GORDO));
            Prefab.name = GordoName;

            GameObject baseSlime = PrefabUtils.CopyPrefab(GameContext.Instance.LookupDirector?.GetPrefab(Identifiable.Id.PINK_SLIME));
            baseSlime.GetComponent<Vacuumable>().size = Vacuumable.Size.LARGE;

            SlimeDefinition baseSlimeDef = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME);;
            SlimeDefinition baseSlimeDefColor = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME);
            // Get Material
            Material ModelMatColor = baseSlimeDefColor.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
            SlimeEyeComponents baseSlimeEyes = baseSlime.GetComponent<SlimeEyeComponents>();
            SlimeMouthComponents baseSlimeMouth = baseSlime.GetComponent<SlimeMouthComponents>();

            // Load Components;
            GameObject tangleflower = Prefab.transform.Find("Vibrating/bone_root/bone_slime/bone_core/bone_jiggle_top/bone_skin_top/Flower").gameObject;
            tangleflower.SetActive(false);
            
            Color EyeColor = Color.white;
            Color MouthColor = Color.white;
            #region Face Color Change
            GordoFaceComponents faceO = Prefab.GetComponent<GordoFaceComponents>();
            Material Blink = UnityEngine.Object.Instantiate(faceO.blinkEyes);
            Material StrainEyes = UnityEngine.Object.Instantiate(faceO.strainEyes);
            StrainEyes.SetColor("_EyeRed", EyeColor);
            StrainEyes.SetColor("_EyeGreen", EyeColor);
            StrainEyes.SetColor("_EyeBlue", EyeColor);
            StrainEyes.SetColor("_GlowColor", EyeColor);
            StrainEyes.name = "eyeScaredGummy";
            faceO.strainEyes = StrainEyes;
            Blink.SetColor("_EyeRed", EyeColor);
            Blink.SetColor("_EyeGreen", EyeColor);
            Blink.SetColor("_EyeBlue", EyeColor);
            Blink.SetColor("_GlowColor", EyeColor);
            Blink.name = "eyeBlinkGummy";
            faceO.blinkEyes = Blink;
            Material ChompOpenMouth = UnityEngine.Object.Instantiate(faceO.chompOpenMouth);
            Material HappyMouth = UnityEngine.Object.Instantiate(faceO.happyMouth);
            Material StrainMputh = UnityEngine.Object.Instantiate(faceO.strainMouth);
            ChompOpenMouth.SetColor("_MouthBot", MouthColor);
            ChompOpenMouth.SetColor("_MouthMid", MouthColor);
            ChompOpenMouth.SetColor("_MouthTop", MouthColor);
            ChompOpenMouth.name = "mouthElatedGummy";
            faceO.chompOpenMouth = ChompOpenMouth;
            HappyMouth.SetColor("_MouthBot", MouthColor);
            HappyMouth.SetColor("_MouthMid", MouthColor);
            HappyMouth.SetColor("_MouthTop", MouthColor);
            HappyMouth.name = "mouthStuffedGummy";
            faceO.happyMouth = HappyMouth;
            StrainMputh.SetColor("_MouthBot", MouthColor);
            StrainMputh.SetColor("_MouthMid", MouthColor);
            StrainMputh.SetColor("_MouthTop", MouthColor);
            StrainMputh.name = "mouthHappyGummy";
            faceO.strainMouth = StrainMputh;
            #endregion
            
            
            SlimeFace glitchFace = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME).AppearancesDefault[0].Face;
            GordoFaceComponents face = Prefab.GetComponent<GordoFaceComponents>();
            face.blinkEyes = glitchFace.GetExpressionFace(SlimeFace.SlimeExpression.Blink).Eyes;
            face.strainEyes = glitchFace.GetExpressionFace(SlimeFace.SlimeExpression.Scared).Eyes;
            face.chompOpenMouth = glitchFace.GetExpressionFace(SlimeFace.SlimeExpression.ChompOpen).Mouth;
            face.happyMouth = glitchFace.GetExpressionFace(SlimeFace.SlimeExpression.Happy).Mouth;
            face.strainMouth = glitchFace.GetExpressionFace(SlimeFace.SlimeExpression.ChompClosed).Mouth;







            //Marker for map
            GordoDisplayOnMap disp = Prefab.GetComponent<GordoDisplayOnMap>();
            GameObject markerPrefab = PrefabUtils.CopyPrefab(disp.markerPrefab.gameObject);
            markerPrefab.name = "GordoGlitchMarker";
            markerPrefab.GetComponent<Image>().sprite = Main.assetBundle.LoadAsset<Sprite>("icon_glitch_gordo");;
            disp.markerPrefab = markerPrefab.GetComponent<MapMarker>();
            //Ids
            GordoIdentifiable iden = Prefab.GetComponent<GordoIdentifiable>();
            iden.id = GordoId;
            iden.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>();
            //Appearance & diet
            
            
            GordoEat eat = Prefab.GetComponent<GordoEat>();
            SlimeDefinition oldDefinition = (SlimeDefinition) PrefabUtils.DeepCopyObject(eat.slimeDefinition);
            oldDefinition.AppearancesDefault = baseSlimeDef.AppearancesDefault;
            oldDefinition.Diet = baseSlimeDef.Diet;
            oldDefinition.IdentifiableId = GordoId;
            oldDefinition.name = GordoName;
            eat.slimeDefinition = oldDefinition;
            eat.targetCount = 50; //How many food it need to be fed to pop
            
            
            
            
            GameObject prefab =
                SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.CRATE_REEF_01);

            List<GameObject> rews = new List<GameObject>()
            {
                prefab,
                prefab,
                prefab
            };
            
            GordoRewards rew = Prefab.GetComponent<GordoRewards>();
            rew.rewardPrefabs = rews.ToArray();
            rew.slimePrefab = GameContext.Instance.LookupDirector.GetPrefab(Identifiable.Id.GLITCH_SLIME);
            rew.rewardOverrides = new GordoRewards.RewardOverride[0];

            GameObject child = Prefab.transform.Find("Vibrating/slime_gordo").gameObject;
            SkinnedMeshRenderer render = child.GetComponent<SkinnedMeshRenderer>();
            render.sharedMaterial = ModelMatColor;
            render.sharedMaterials[0] = ModelMatColor;
            render.material = ModelMatColor;
            render.materials[0] = ModelMatColor;
            LookupRegistry.RegisterGordo(Prefab);
        }
    }
}
namespace MoreGordos
{
    class Retro_Gordo
    {

        public static void CreateGordo(Identifiable.Id GordoId, String GordoName)
        {
            SlimeAppearance secretAppearance = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.SECRET_STYLE);
            Material SecretStyleMaterial = secretAppearance.Structures[0].DefaultMaterials[0];

            GameObject Prefab = PrefabUtils.CopyPrefab(GameContext.Instance.LookupDirector?.GetGordo(Identifiable.Id.TANGLE_GORDO));
            Prefab.name = GordoName;

            GameObject baseSlime = PrefabUtils.CopyPrefab(GameContext.Instance.LookupDirector?.GetPrefab(Identifiable.Id.PINK_SLIME));
            baseSlime.GetComponent<Vacuumable>().size = Vacuumable.Size.LARGE;

            SlimeDefinition baseSlimeDef = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME);;
            SlimeDefinition baseSlimeDefColor = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME);
            // Get Material
            Material ModelMatColor = baseSlimeDefColor.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
            SlimeEyeComponents baseSlimeEyes = baseSlime.GetComponent<SlimeEyeComponents>();
            SlimeMouthComponents baseSlimeMouth = baseSlime.GetComponent<SlimeMouthComponents>();

            // Load Components;
            GameObject tangleflower = Prefab.transform.Find("Vibrating/bone_root/bone_slime/bone_core/bone_jiggle_top/bone_skin_top/Flower").gameObject;
            tangleflower.SetActive(false);
            
            Color EyeColor = Color.white;
            Color MouthColor = Color.white;
            #region Face Color Change
            GordoFaceComponents faceO = Prefab.GetComponent<GordoFaceComponents>();
            Material Blink = UnityEngine.Object.Instantiate(faceO.blinkEyes);
            Material StrainEyes = UnityEngine.Object.Instantiate(faceO.strainEyes);
            StrainEyes.SetColor("_EyeRed", EyeColor);
            StrainEyes.SetColor("_EyeGreen", EyeColor);
            StrainEyes.SetColor("_EyeBlue", EyeColor);
            StrainEyes.SetColor("_GlowColor", EyeColor);
            StrainEyes.name = "eyeScaredGummy";
            faceO.strainEyes = StrainEyes;
            Blink.SetColor("_EyeRed", EyeColor);
            Blink.SetColor("_EyeGreen", EyeColor);
            Blink.SetColor("_EyeBlue", EyeColor);
            Blink.SetColor("_GlowColor", EyeColor);
            Blink.name = "eyeBlinkGummy";
            faceO.blinkEyes = Blink;
            Material ChompOpenMouth = UnityEngine.Object.Instantiate(faceO.chompOpenMouth);
            Material HappyMouth = UnityEngine.Object.Instantiate(faceO.happyMouth);
            Material StrainMputh = UnityEngine.Object.Instantiate(faceO.strainMouth);
            ChompOpenMouth.SetColor("_MouthBot", MouthColor);
            ChompOpenMouth.SetColor("_MouthMid", MouthColor);
            ChompOpenMouth.SetColor("_MouthTop", MouthColor);
            ChompOpenMouth.name = "mouthElatedGummy";
            faceO.chompOpenMouth = ChompOpenMouth;
            HappyMouth.SetColor("_MouthBot", MouthColor);
            HappyMouth.SetColor("_MouthMid", MouthColor);
            HappyMouth.SetColor("_MouthTop", MouthColor);
            HappyMouth.name = "mouthStuffedGummy";
            faceO.happyMouth = HappyMouth;
            StrainMputh.SetColor("_MouthBot", MouthColor);
            StrainMputh.SetColor("_MouthMid", MouthColor);
            StrainMputh.SetColor("_MouthTop", MouthColor);
            StrainMputh.name = "mouthHappyGummy";
            faceO.strainMouth = StrainMputh;
            #endregion


            SlimeFace glitchFace = secretAppearance.Face;
            GordoFaceComponents face = Prefab.GetComponent<GordoFaceComponents>();
            face.blinkEyes = glitchFace.GetExpressionFace(SlimeFace.SlimeExpression.Blink).Eyes;
            face.strainEyes = glitchFace.GetExpressionFace(SlimeFace.SlimeExpression.Scared).Eyes;
            face.chompOpenMouth = glitchFace.GetExpressionFace(SlimeFace.SlimeExpression.ChompOpen).Mouth;
            face.happyMouth = glitchFace.GetExpressionFace(SlimeFace.SlimeExpression.Happy).Mouth;
            face.strainMouth = glitchFace.GetExpressionFace(SlimeFace.SlimeExpression.ChompClosed).Mouth;







            //Marker for map
            GordoDisplayOnMap disp = Prefab.GetComponent<GordoDisplayOnMap>();
            GameObject markerPrefab = PrefabUtils.CopyPrefab(disp.markerPrefab.gameObject);
            markerPrefab.name = "GordoGlitchMarker";
            markerPrefab.GetComponent<Image>().sprite = Main.assetBundle.LoadAsset<Sprite>("icon_glitch_gordo");;
            disp.markerPrefab = markerPrefab.GetComponent<MapMarker>();
            //Ids
            GordoIdentifiable iden = Prefab.GetComponent<GordoIdentifiable>();
            iden.id = GordoId;
            iden.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>();
            //Appearance & diet
            
            
            GordoEat eat = Prefab.GetComponent<GordoEat>();
            SlimeDefinition oldDefinition = (SlimeDefinition) PrefabUtils.DeepCopyObject(eat.slimeDefinition);
            oldDefinition.AppearancesDefault = baseSlimeDef.AppearancesDefault;
            oldDefinition.Diet = baseSlimeDef.Diet;
            oldDefinition.IdentifiableId = GordoId;
            oldDefinition.name = GordoName;
            eat.slimeDefinition = oldDefinition;
            eat.targetCount = 50; //How many food it need to be fed to pop
            
            
            
            
            GameObject prefab =
                SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.CRATE_REEF_01);

            List<GameObject> rews = new List<GameObject>()
            {
                prefab,
                prefab,
                prefab
            };
            
            GordoRewards rew = Prefab.GetComponent<GordoRewards>();
            rew.rewardPrefabs = rews.ToArray();
            rew.slimePrefab = GameContext.Instance.LookupDirector.GetPrefab(Identifiable.Id.GLITCH_SLIME);
            rew.rewardOverrides = new GordoRewards.RewardOverride[0];

            GameObject child = Prefab.transform.Find("Vibrating/slime_gordo").gameObject;
            SkinnedMeshRenderer render = child.GetComponent<SkinnedMeshRenderer>();
            render.sharedMaterial = SecretStyleMaterial;
            render.sharedMaterials[0] = SecretStyleMaterial;
            render.material = SecretStyleMaterial;
            render.materials[0] = SecretStyleMaterial;
            LookupRegistry.RegisterGordo(Prefab);

        }
    }
}
namespace MoreGordos
{
    class Fire_Gordo
    {

        public static void CreateGordo(Identifiable.Id GordoId, string GordoName)
        {

            GameObject Prefab = PrefabUtils.CopyPrefab(GameContext.Instance.LookupDirector?.GetGordo(Identifiable.Id.TANGLE_GORDO));
            Prefab.name = GordoName;

            GameObject baseSlime = PrefabUtils.CopyPrefab(GameContext.Instance.LookupDirector?.GetPrefab(Identifiable.Id.PINK_SLIME));
            baseSlime.GetComponent<Vacuumable>().size = Vacuumable.Size.LARGE;

            SlimeDefinition baseSlimeDef = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME);;
            SlimeDefinition baseSlimeDefColor = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.FIRE_SLIME);
            // Get Material
            Material ModelMatColor = baseSlimeDefColor.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
            SlimeEyeComponents baseSlimeEyes = baseSlime.GetComponent<SlimeEyeComponents>();
            SlimeMouthComponents baseSlimeMouth = baseSlime.GetComponent<SlimeMouthComponents>();

            // Load Components;
            GameObject tangleflower = Prefab.transform.Find("Vibrating/bone_root/bone_slime/bone_core/bone_jiggle_top/bone_skin_top/Flower").gameObject;
            tangleflower.SetActive(false);
            GordoFaceComponents faceFire = Prefab.GetComponent<GordoFaceComponents>();
            faceFire.happyMouth = ModelMatColor;
            faceFire.chompOpenMouth = ModelMatColor;
            faceFire.strainMouth = ModelMatColor;
            
            GameObject gameObject3 = Main.assetBundle.LoadAsset<GameObject>("PS_Parent");
            gameObject3.transform.position = new Vector3(0, 0.5f, 0);
            Object.Instantiate<GameObject>(gameObject3, Prefab.transform);







            //Marker for map
            GordoDisplayOnMap disp = Prefab.GetComponent<GordoDisplayOnMap>();
            GameObject markerPrefab = PrefabUtils.CopyPrefab(disp.markerPrefab.gameObject);
            markerPrefab.name = "GordoFireMarker";
            markerPrefab.GetComponent<Image>().sprite = Main.assetBundle.LoadAsset<Sprite>("icon_fire_gordo");;
            disp.markerPrefab = markerPrefab.GetComponent<MapMarker>();
            //Ids
            GordoIdentifiable iden = Prefab.GetComponent<GordoIdentifiable>();
            iden.id = GordoId;
            iden.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>();
            //Appearance & diet
            
            
            GordoEat eat = Prefab.GetComponent<GordoEat>();
            SlimeDefinition oldDefinition = (SlimeDefinition) PrefabUtils.DeepCopyObject(eat.slimeDefinition);
            oldDefinition.AppearancesDefault = baseSlimeDef.AppearancesDefault;
            oldDefinition.Diet = baseSlimeDef.Diet;
            oldDefinition.IdentifiableId = GordoId;
            oldDefinition.name = GordoName;
            eat.slimeDefinition = oldDefinition;
            eat.targetCount = 50; //How many food it need to be fed to pop
            
            
            
            
            GameObject prefab = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.CRATE_REEF_01);

            List<GameObject> rews = new List<GameObject>()
            {
                prefab,
                prefab,
                prefab
            };
            
            GordoRewards rew = Prefab.GetComponent<GordoRewards>();
            rew.rewardPrefabs = rews.ToArray();
            rew.slimePrefab = GameContext.Instance.LookupDirector.GetPrefab(Identifiable.Id.FIRE_SLIME);
            rew.rewardOverrides = new GordoRewards.RewardOverride[0];

            GameObject child = Prefab.transform.Find("Vibrating/slime_gordo").gameObject;
            SkinnedMeshRenderer render = child.GetComponent<SkinnedMeshRenderer>();
            render.sharedMaterial = ModelMatColor;
            render.sharedMaterials[0] = ModelMatColor;
            render.material = ModelMatColor;
            render.materials[0] = ModelMatColor;
            LookupRegistry.RegisterGordo(Prefab);
        }
    }
}

namespace MoreGordos
{
	class Puddle_Gordo
	{

		public static void CreateGordo(Identifiable.Id GordoId, String GordoName)
		{
			GameObject Prefab =
				PrefabUtils.CopyPrefab(GameContext.Instance.LookupDirector?.GetGordo(Identifiable.Id.PINK_GORDO));
			Prefab.name = "gordoPuddle";

			GameObject baseSlime = GameContext.Instance.LookupDirector?.GetPrefab(Identifiable.Id.PUDDLE_SLIME);
			SlimeDefinition baseSlimeDef =
				SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(
					Identifiable.Id.PUDDLE_SLIME);
			SlimeAppearance baseSlimeAppearance = baseSlimeDef.AppearancesDefault[0];
			// Load Material
			Material ModelMat = baseSlimeAppearance.Structures[0].DefaultMaterials[0];

			// Load Components
			GordoEat eat = Prefab.GetComponent<GordoEat>();
			GordoEatWater eatWater = Prefab.AddComponent<GordoEatWater>();
			eat.allEats = Identifiable.LIQUID_CLASS.Where(id => Identifiable.IsWater(id)).ToList();
			eat.slimeDefinition = baseSlimeDef;
			eat.targetCount = 50;

			SlimeFace puddleFace = baseSlimeAppearance.Face;
			GordoFaceComponents face = Prefab.GetComponent<GordoFaceComponents>();
			face.blinkEyes = puddleFace.GetExpressionFace(SlimeFace.SlimeExpression.Blink).Eyes;
			face.strainEyes = puddleFace.GetExpressionFace(SlimeFace.SlimeExpression.Scared).Eyes;
			face.chompOpenMouth = ModelMat; //puddleFace.GetExpressionFace(SlimeFace.SlimeExpression.ChompOpen).Mouth;
			face.happyMouth = ModelMat; //puddleFace.GetExpressionFace(SlimeFace.SlimeExpression.Happy).Mouth;
			face.strainMouth = ModelMat; //puddleFace.GetExpressionFace(SlimeFace.SlimeExpression.ChompClosed).Mouth;

			GordoDisplayOnMap disp = Prefab.GetComponent<GordoDisplayOnMap>();
			GameObject markerPrefab = PrefabUtils.CopyPrefab(disp.markerPrefab.gameObject);
			markerPrefab.name = "GordoPuddleMarker";
			markerPrefab.GetComponent<Image>().sprite = Main.assetBundle.LoadAsset<Sprite>("icon_puddle_gordo");;
			disp.markerPrefab = markerPrefab.GetComponent<MapMarker>();
			//Ids

			GordoIdentifiable iden = Prefab.GetComponent<GordoIdentifiable>();
			iden.id = Identifiable.Id.PUDDLE_GORDO;
			iden.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>();

			GameObject child = Prefab.transform.Find("Vibrating/slime_gordo").gameObject;
			SkinnedMeshRenderer render = child.GetComponent<SkinnedMeshRenderer>();
			render.sharedMaterial = ModelMat;
			render.sharedMaterials[0] = ModelMat;
			render.material = ModelMat;
			render.materials[0] = ModelMat;

			GameObject prefab =
				SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.CRATE_MOSS_01);
			List<GameObject> rews = new List<GameObject>()
			{
				prefab,
				prefab,
				prefab
			};

			GordoRewards rew = Prefab.GetComponent<GordoRewards>();
			rew.rewardPrefabs = rews.ToArray();
			rew.slimePrefab = GameContext.Instance.LookupDirector.GetPrefab(Identifiable.Id.PUDDLE_SLIME);
			rew.rewardOverrides = new GordoRewards.RewardOverride[0];
			LookupRegistry.RegisterGordo(Prefab);
		}
	}
}
namespace MoreGordos
{
    class Twinkle_Gordo
    {

        public static void CreateGordo(Identifiable.Id GordoId, string GordoName)
        {

            GameObject Prefab = PrefabUtils.CopyPrefab(GameContext.Instance.LookupDirector?.GetGordo(Identifiable.Id.TANGLE_GORDO));
            Prefab.name = GordoName;

            GameObject baseSlime = PrefabUtils.CopyPrefab(GameContext.Instance.LookupDirector?.GetPrefab(Identifiable.Id.PINK_SLIME));
            baseSlime.GetComponent<Vacuumable>().size = Vacuumable.Size.LARGE;
            SlimeDefinition baseSlimeDef = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME);
            Material ModelMat = baseSlimeDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];

            // Get Material
            SlimeEyeComponents baseSlimeEyes = baseSlime.GetComponent<SlimeEyeComponents>();
            SlimeMouthComponents baseSlimeMouth = baseSlime.GetComponent<SlimeMouthComponents>();

            // Load Components;
            GameObject tangleflower = Prefab.transform.Find("Vibrating/bone_root/bone_slime/bone_core/bone_jiggle_top/bone_skin_top/Flower").gameObject;
            tangleflower.SetActive(false);







            //Marker for map
            GordoDisplayOnMap disp = Prefab.GetComponent<GordoDisplayOnMap>();
            GameObject markerPrefab = PrefabUtils.CopyPrefab(disp.markerPrefab.gameObject);
            markerPrefab.name = "GordoTwinkleMarker";
            markerPrefab.GetComponent<Image>().sprite = Main.assetBundle.LoadAsset<Sprite>("icon_twinkle_gordo");;
            disp.markerPrefab = markerPrefab.GetComponent<MapMarker>();
            //Ids
            GordoIdentifiable iden = Prefab.GetComponent<GordoIdentifiable>();
            iden.id = GordoId;
            iden.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>();
            //Appearance & diet
            
            
            GordoEat eat = Prefab.GetComponent<GordoEat>();
            SlimeDefinition oldDefinition = (SlimeDefinition) PrefabUtils.DeepCopyObject(eat.slimeDefinition);
            oldDefinition.AppearancesDefault = baseSlimeDef.AppearancesDefault;
            oldDefinition.Diet = baseSlimeDef.Diet;
            oldDefinition.IdentifiableId = GordoId;
            oldDefinition.name = GordoName;
            eat.slimeDefinition = oldDefinition;
            eat.targetCount = 50; //How many food it need to be fed to pop

            List<GameObject> rews = new List<GameObject>()
            {
	            SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ECHO_NOTE_11),
	            SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.CRATE_REEF_01),
	            SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ECHO_NOTE_02),
	            SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ECHO_NOTE_03),
	            SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ECHO_NOTE_07),
	            SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ECHO_NOTE_06),
	            SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ECHO_NOTE_10),
	            SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ECHO_NOTE_01),
	            SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ECHO_NOTE_05),
	            SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ECHO_NOTE_11),
	            SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.CRATE_REEF_01),
	            SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.CRATE_REEF_01),
	            SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ECHO_NOTE_04)

            };
            GordoRewards rew = Prefab.GetComponent<GordoRewards>();
            rew.rewardPrefabs = rews.ToArray(); 
            rew.rewardOverrides = new GordoRewards.RewardOverride[0]; 
            GameObject child = Prefab.transform.Find("Vibrating/slime_gordo").gameObject;
            SkinnedMeshRenderer render = child.GetComponent<SkinnedMeshRenderer>();
            render.sharedMaterial = ModelMat;
            render.sharedMaterials[0] = ModelMat;
            render.material = ModelMat;
            render.materials[0] = ModelMat;
            LookupRegistry.RegisterGordo(Prefab);
        }
    }
}
namespace MoreGordos
{
    class Saber_Gordo
    {

        public static void CreateGordo(Identifiable.Id GordoId, string GordoName)
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(GameContext.Instance.LookupDirector?.GetGordo(Identifiable.Id.TANGLE_GORDO));
            Prefab.name = GordoName;

            GameObject baseSlime = PrefabUtils.CopyPrefab(GameContext.Instance.LookupDirector?.GetPrefab(Identifiable.Id.SABER_SLIME));
            baseSlime.GetComponent<Vacuumable>().size = Vacuumable.Size.LARGE;

            SlimeDefinition baseSlimeDef = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.SABER_SLIME);;
            SlimeDefinition baseSlimeDefColor = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.SABER_SLIME);
            // Get Material
            Material ModelMatColor = baseSlimeDefColor.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
            SlimeEyeComponents baseSlimeEyes = baseSlime.GetComponent<SlimeEyeComponents>();
            SlimeMouthComponents baseSlimeMouth = baseSlime.GetComponent<SlimeMouthComponents>();

            // Load Components;
            GameObject tangleflower = Prefab.transform.Find("Vibrating/bone_root/bone_slime/bone_core/bone_jiggle_top/bone_skin_top/Flower").gameObject;
            Object.Destroy(tangleflower.GetComponent<BoxCollider>());
	        Object.Destroy(tangleflower.GetComponent<MeshCollider>());
	        GordoFaceComponents face = Prefab.GetComponent<GordoFaceComponents>();
	        face.happyMouth = ModelMatColor;
	        face.chompOpenMouth = ModelMatColor;
	        face.strainMouth = ModelMatColor;
            MeshFilter tangleflowermeshfilter = tangleflower.GetComponent<MeshFilter>();
            tangleflowermeshfilter.sharedMesh = Main.assetBundle.LoadAsset<Mesh>("slime_saber_teeth_LOD2");
            tangleflowermeshfilter.transform.localScale = new Vector3(1, 1, 1);
            tangleflowermeshfilter.transform.position = new Vector3(0, -0.4f, 0.6f);
            MeshRenderer tangleflowermeshrender = tangleflower.GetComponent<MeshRenderer>();
            tangleflowermeshrender.sharedMaterial = ModelMatColor;
            







            //Marker for map
            GordoDisplayOnMap disp = Prefab.GetComponent<GordoDisplayOnMap>();
            GameObject markerPrefab = PrefabUtils.CopyPrefab(disp.markerPrefab.gameObject);
            markerPrefab.name = "GordoSaberMarker";
            markerPrefab.GetComponent<Image>().sprite = Main.assetBundle.LoadAsset<Sprite>("icon_saber_gordo");;
            disp.markerPrefab = markerPrefab.GetComponent<MapMarker>();
            //Ids
            GordoIdentifiable iden = Prefab.GetComponent<GordoIdentifiable>();
            iden.id = GordoId;
            iden.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>();
            //Appearance & diet
            
            
            GordoEat eat = Prefab.GetComponent<GordoEat>();
            SlimeDefinition oldDefinition = (SlimeDefinition) PrefabUtils.DeepCopyObject(eat.slimeDefinition);
            oldDefinition.AppearancesDefault = baseSlimeDef.AppearancesDefault;
            oldDefinition.Diet = baseSlimeDef.Diet;
            oldDefinition.IdentifiableId = GordoId;
            oldDefinition.name = GordoName;
            eat.slimeDefinition = oldDefinition;
            eat.targetCount = 50; //How many food it need to be fed to pop
            
            
            
            
            GameObject prefab =
                SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.CRATE_REEF_01);

            List<GameObject> rews = new List<GameObject>()
            {
                prefab,
                prefab,
                prefab
            };
            
            GordoRewards rew = Prefab.GetComponent<GordoRewards>();
            rew.rewardPrefabs = rews.ToArray();
            rew.slimePrefab = GameContext.Instance.LookupDirector.GetPrefab(Identifiable.Id.SABER_SLIME);
            rew.rewardOverrides = new GordoRewards.RewardOverride[0];

            GameObject child = Prefab.transform.Find("Vibrating/slime_gordo").gameObject;
            SkinnedMeshRenderer render = child.GetComponent<SkinnedMeshRenderer>();
            render.sharedMaterial = ModelMatColor;
            render.sharedMaterials[0] = ModelMatColor;
            render.material = ModelMatColor;
            render.materials[0] = ModelMatColor;
            LookupRegistry.RegisterGordo(Prefab);
        }
    }
}

namespace MoreGordos
{
    class Tarr_Gordo
    {

        public static void CreateGordo(Identifiable.Id GordoId)
        {
            // Get GameObjects
            GameObject Prefab = PrefabUtils.CopyPrefab(GameContext.Instance.LookupDirector?.GetGordo(Identifiable.Id.PINK_GORDO));
            Prefab.name = "gordoTarr";

            GameObject baseSlime = GameContext.Instance.LookupDirector?.GetPrefab(Identifiable.Id.TARR_SLIME);
            SlimeDefinition baseSlimeDef = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TARR_SLIME);
            SlimeAppearance baseSlimeAppearance = baseSlimeDef.AppearancesDefault[0];
            // Load Material
            Material ModelMat = baseSlimeAppearance.Structures[1].DefaultMaterials[0];
            SlimeEyeComponents baseSlimeEyes = baseSlime.GetComponent<SlimeEyeComponents>();
            SlimeMouthComponents baseSlimeMouth = baseSlime.GetComponent<SlimeMouthComponents>();

            // Load Components
            GordoEat eat = Prefab.GetComponent<GordoEat>();

            Material TarrEyeRavenous = baseSlimeEyes.chompClosedEyes;
            Material TarrMouthRavenous = baseSlimeMouth.chompClosedMouth;
            Material TarrEyeMellow = UnityEngine.Object.Instantiate<Material>(baseSlimeEyes.chompClosedEyes);
            TarrEyeMellow.name = "eyeMellow";
            TarrEyeMellow.SetTexture("_FaceTexture", Main.tarrEyeTexture);
            Material TarrMouthMellow = UnityEngine.Object.Instantiate<Material>(baseSlimeMouth.chompClosedMouth);
            TarrMouthMellow.name = "mouthMellow";
            TarrMouthMellow.SetTexture("_FaceTexture", Main.tarrMouthTexture);

            GordoFaceComponents face = Prefab.GetComponent<GordoFaceComponents>();
            face.blinkEyes = TarrEyeRavenous;//eyeBlink
            face.strainEyes = TarrEyeMellow;//eyeScared
            face.chompOpenMouth = TarrMouthRavenous;//mouthElated
            face.happyMouth = TarrMouthRavenous;//mouthHappy
            face.strainMouth = TarrMouthMellow;//mouthStuffed

            GordoDisplayOnMap disp = Prefab.GetComponent<GordoDisplayOnMap>();
            GameObject markerPrefab = PrefabUtils.CopyPrefab(disp.markerPrefab.gameObject);
            markerPrefab.name = "GordoTarrMarker";
            markerPrefab.GetComponent<Image>().sprite = Main.tarrGordoIcon;
            disp.markerPrefab = markerPrefab.GetComponent<MapMarker>();
            GordoIdentifiable iden = Prefab.GetComponent<GordoIdentifiable>();
            iden.id = GordoId;
            iden.nativeZones = EnumUtils.GetAll<ZoneDirector.Zone>();

            GameObject child = Prefab.transform.Find("Vibrating/slime_gordo").gameObject;
            SkinnedMeshRenderer render = child.GetComponent<SkinnedMeshRenderer>();

            SlimeDefinition oldDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(eat.slimeDefinition);
            SlimeDefinition newDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(baseSlimeDef);
            oldDefinition.AppearancesDefault = newDefinition.AppearancesDefault;
            oldDefinition.Diet = newDefinition.Diet;
            oldDefinition.IdentifiableId = GordoId;
            oldDefinition.name = "Tarr Gordo";
            eat.slimeDefinition = oldDefinition;
            eat.targetCount = 50;

            List<BreakOnImpact.SpawnOption> tarrSpawnOptions = new List<BreakOnImpact.SpawnOption>
            {
                new BreakOnImpact.SpawnOption
                {
                    spawn = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PRIMORDY_OIL_CRAFT),
                    weight = 9,
                },
                new BreakOnImpact.SpawnOption
                {
                    spawn = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.DEEP_BRINE_CRAFT),
                    weight = 9,
                },
                new BreakOnImpact.SpawnOption
                {
                    spawn = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ROOSTER),
                    weight = 3,
                },
                new BreakOnImpact.SpawnOption
                {
                    spawn = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.HEN),
                    weight = 3,
                },
                new BreakOnImpact.SpawnOption
                {
                    spawn = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PHOSPHOR_ROCK_LARGO),
                    weight = 0.3f,
                },
                new BreakOnImpact.SpawnOption
                {
                    spawn = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_TABBY_LARGO),
                    weight = 0.3f,
                },
                new BreakOnImpact.SpawnOption
                {
                    spawn = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.BOOM_RAD_LARGO),
                    weight = 0.3f,
                },
                new BreakOnImpact.SpawnOption
                {
                    spawn = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.QUANTUM_CRYSTAL_LARGO),
                    weight = 0.3f,
                },
                new BreakOnImpact.SpawnOption
                {
                    spawn = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.HONEY_HUNTER_LARGO),
                    weight = 0.3f,
                },
                new BreakOnImpact.SpawnOption
                {
                    spawn = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.MOSAIC_DERVISH_LARGO),
                    weight = 0.3f,
                },
                new BreakOnImpact.SpawnOption
                {
                    spawn = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.SABER_TANGLE_LARGO),
                    weight = 0.3f,
                },
                new BreakOnImpact.SpawnOption
                {
                    spawn = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.TARR_LANTERN_ORNAMENT),
                    weight = 0.003f,
                },
                new BreakOnImpact.SpawnOption
                {
                    spawn = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.TARR_ORNAMENT),
                    weight = 0.003f,
                },
            };
            GameObject prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.CRATE_WILDS_01));
            prefab.name = "crateTarr";
            prefab.GetComponent<BreakOnImpact>().spawnOptions = tarrSpawnOptions;
            prefab.GetComponent<BreakOnImpact>().minSpawns = 4;
            prefab.GetComponent<BreakOnImpact>().maxSpawns = 6;
            Dictionary<BreakOnImpact.SpawnOption, float> spawnWeights = new Dictionary<BreakOnImpact.SpawnOption, float>();
            foreach (BreakOnImpact.SpawnOption spawnOption in tarrSpawnOptions)
                spawnWeights[spawnOption] = spawnOption.weight;

            List<GameObject> rews = new List<GameObject>()
            {
                prefab,
                prefab,
                prefab
            };

            GordoRewards rew = Prefab.GetComponent<GordoRewards>();
            rew.rewardPrefabs = rews.ToArray();
            rew.slimePrefab = GameContext.Instance.LookupDirector.GetPrefab(Identifiable.Id.TARR_SLIME);
            rew.rewardOverrides = new GordoRewards.RewardOverride[0];

            render.sharedMaterial = ModelMat;
            render.sharedMaterials[0] = ModelMat;
            render.material = ModelMat;
            render.materials[0] = ModelMat;

            LookupRegistry.RegisterGordo(Prefab);

            FearProfile fearProfile = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME).GetComponent<FleeThreats>().fearProfile;
            FearProfile.ThreatEntry tarrFear = fearProfile.threats.FirstOrDefault(threat => threat.id == Identifiable.Id.TARR_SLIME);
            FearProfile.ThreatEntry threatEntry = new FearProfile.ThreatEntry
            {
                id = GordoId,
                maxSearchRadius = tarrFear.maxSearchRadius,
                maxThreatFearPerSec = tarrFear.maxThreatFearPerSec,
                minSearchRadius = tarrFear.minSearchRadius,
                minThreatFearPerSec = tarrFear.minThreatFearPerSec
            };
            fearProfile.threatsLookup.Add(GordoId, threatEntry);
        }

        public static void PostLoadTarrGordo(Identifiable.Id GordoId)
        {
            GameObject Prefab = GameContext.Instance.LookupDirector?.GetGordo(GordoId);
            GordoEat eat = Prefab.GetComponent<GordoEat>();
            eat.slimeDefinition.Diet.RefreshEatMap(GameContext.Instance.SlimeDefinitions, eat.slimeDefinition);
            eat.slimeDefinition.Diet.EatMap.RemoveAll((eatMap => eatMap.eats == Identifiable.Id.PUDDLE_SLIME));
            eat.slimeDefinition.Diet.EatMap.Add(new SlimeDiet.EatMapEntry()
            {
                becomesId = Identifiable.Id.NONE,
                producesId = Identifiable.Id.TARR_SLIME,
                driver = SlimeEmotions.Emotion.AGITATION,
                eats = Identifiable.Id.PUDDLE_SLIME,
                minDrive = 0,
                extraDrive = 0,
                isFavorite = true,
                favoriteProductionCount = 50,
            });
        }
    }
}