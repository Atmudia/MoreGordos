using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using MonomiPark.SlimeRancher.DataModel;
using MonomiPark.SlimeRancher.Regions;
using MoreGordos;
using SRML;
using SRML.Console;
using Console = SRML.Console.Console;
using SRML.SR;
using SRML.SR.SaveSystem;
using SRML.SR.SaveSystem.Data;
using SRML.SR.Translation;
using SRML.Utils;
using SRML.Utils.Enum;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;


namespace MoreGordos
{

    public class Main : ModEntryPoint
    {
        // THE EXECUTING ASSEMBLY
        public static Assembly execAssembly;

        public static AssetBundle assetBundle;

        public static AssetBundle LoadAssetbundle(string name) => AssetBundle.LoadFromStream(execAssembly.GetManifestResourceStream(typeof(Main), name));


        private static AssetBundle tarrAssetBundle;
        internal static Texture tarrMouthTexture;
        internal static Texture tarrEyeTexture;
        internal static Sprite tarrGordoIcon;


        // Called before GameContext.Awake
        // You want to register new things and enum values here, as well as do all your harmony patching
        public override void PreLoad()
        {
            execAssembly = Assembly.GetExecutingAssembly();
            assetBundle = LoadAssetbundle("moregordos");

            TranslationPatcher.AddPediaTranslation("t.lucky_gordo", "Lucky Gordo");
            TranslationPatcher.AddPediaTranslation("t.fire_gordo", "Fire Gordo");
            TranslationPatcher.AddPediaTranslation("t.glitch_gordo", "Glitch Gordo");
            TranslationPatcher.AddPediaTranslation("t.twinkle_gordo", "Twinkle Gordo");
            TranslationPatcher.AddPediaTranslation("t.saber_gordo", "Saber Gordo");

            if (!SRModLoader.IsModPresent("tarrgordo"))
            {
                tarrAssetBundle = LoadAssetbundle("tarrmellow");
                tarrMouthTexture = tarrAssetBundle.LoadAsset<Texture>("mouthTarrMellow");
                tarrEyeTexture = tarrAssetBundle.LoadAsset<Texture>("eyeTarrMellow");
                tarrGordoIcon = tarrAssetBundle.LoadAsset<Sprite>("iconGordoTarr");
                TranslationPatcher.AddPediaTranslation("t.tarr_gordo", "Tarr Gordo");
                TranslationPatcher.AddUITranslation("m.foodgroup.nontarrgold_slimes", "Slimes, Meat, and Ranchers");
                OtherId.TARR_GORDO = IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "TARR_GORDO", true);
                Identifiable.TARR_CLASS.Add(OtherId.TARR_GORDO);
            }

            HarmonyInstance.PatchAll(execAssembly);
        }


        // Called before GameContext.Start
        // Used for registering things that require a loaded gamecontext
        public override void Load()
        {
            if (SRModLoader.IsModPresent("translationapi"))
                Translations.Init();
            Lucky_Gordo.CreateGordo(Id.LUCKY_GORDO, "gordoLucky");
            Fire_Gordo.CreateGordo(Id.FIRE_GORDO, "gordoFire");
            Puddle_Gordo.CreateGordo(Identifiable.Id.PUDDLE_GORDO, "gordoPuddle");
            Glitch_Gordo.CreateGordo(Id.GLITCH_GORDO, "gordoGlitch");
            Twinkle_Gordo.CreateGordo(Id.TWINKLE_GORDO, "gordoTwinkle");
            Saber_Gordo.CreateGordo(Id.SABER_GORDO, "gordoSaber");
            if (!SRModLoader.IsModPresent("tarrgordo"))
                Tarr_Gordo.CreateGordo(OtherId.TARR_GORDO);
        }

        public override void PostLoad()
        {
            if (!SRModLoader.IsModPresent("tarrgordo"))
                Tarr_Gordo.PostLoadTarrGordo(OtherId.TARR_GORDO);
        }
    }
}

#pragma warning disable 0649
namespace MoreGordos
{
    [EnumHolder]
    class Id
    {
        //public static readonly Identifiable.Id PUDDLE_GORDO;
        public static readonly Identifiable.Id LUCKY_GORDO;
        public static readonly Identifiable.Id GLITCH_GORDO;
        public static readonly Identifiable.Id QUICKSILVER_GORDO;
        public static readonly Identifiable.Id FIRE_GORDO;
        public static readonly Identifiable.Id TWINKLE_GORDO;
        public static readonly Identifiable.Id SABER_GORDO;
    }
    class OtherId
    {
        public static Identifiable.Id TARR_GORDO;
    }
}

#pragma warning restore 0649