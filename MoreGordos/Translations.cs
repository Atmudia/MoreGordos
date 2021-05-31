using System;
using System.Collections.Generic;
using System.Linq;
using SRML;
using TranslationAPI;

namespace MoreGordos
{
    internal class Translations
    {
        public static void Init()
        {
            TranslationUtil.RegisterAssembly(Main.execAssembly, "Lang");
            if (!SRModLoader.IsModPresent("tarrgordo"))
                InitTarr();
        }

        public static void InitTarr()
        {
            TranslationUtil.RegisterRedirect("ui", "m.foodgroup.tarr", "ui", "m.foodgroup.nontarrgold_slimes");
        }
    }
}
