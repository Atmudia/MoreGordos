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
        private static Stream manifestResourceStream =
            Assembly.GetExecutingAssembly().GetManifestResourceStream("MoreGordos.moregordos");

        public static AssetBundle assetBundle = AssetBundle.LoadFromStream(Main.manifestResourceStream);

        // Called before GameContext.Awake
        // You want to register new things and enum values here, as well as do all your harmony patching
        public override void PreLoad()
        {
            TranslationPatcher.AddPediaTranslation("t.lucky_gordo", "Lucky Gordo");
            TranslationPatcher.AddPediaTranslation("t.fire_gordo", "Fire Gordo");
            TranslationPatcher.AddPediaTranslation("t.glitch_gordo", "Glitch Gordo");
            TranslationPatcher.AddPediaTranslation("t.twinkle_gordo", "Twinkle Gordo");
            TranslationPatcher.AddPediaTranslation("t.saber_gordo", "Saber Gordo");
            HarmonyInstance.PatchAll();

        }


        // Called before GameContext.Start
        // Used for registering things that require a loaded gamecontext
        public override void Load()
        {
            Lucky_Gordo.CreateGordo(Id.LUCKY_GORDO, "Lucky_Gordo");
            Fire_Gordo.CreateGordo(Id.FIRE_GORDO, "Fire_Gordo");
            Puddle_Gordo.CreateGordo(Identifiable.Id.PUDDLE_GORDO, "Puddle_Gordo");
            Glitch_Gordo.CreateGordo(Id.GLITCH_GORDO, "Glitch_Gordo");
            Twinkle_Gordo.CreateGordo(Id.TWINKLE_GORDO, "Twinkle_Gordo");
            Saber_Gordo.CreateGordo(Id.SABER_GORDO, "Saber_Gordo");

        }

        public override void PostLoad()
        {
        }
    }
}

#pragma warning disable 0649
namespace MoreGordos
{
    [EnumHolder]
    class Id
    {
        public static readonly Identifiable.Id LUCKY_GORDO;
        public static readonly Identifiable.Id GLITCH_GORDO;
        public static readonly Identifiable.Id QUICKSILVER_GORDO;
        public static readonly Identifiable.Id FIRE_GORDO;
        public static readonly Identifiable.Id TWINKLE_GORDO;
        public static readonly Identifiable.Id SABER_GORDO;
    }
}

#pragma warning restore 0649