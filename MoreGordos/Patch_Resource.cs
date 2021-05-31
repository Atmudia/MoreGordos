using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace MoreGordos
{
    // Token: 0x02000008 RID: 8
    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("OnTriggerEnter")]
    public class Patch_SnareResourceLucky
    {
        // Token: 0x06000014 RID: 20 RVA: 0x00002CCC File Offset: 0x00000ECC
        [HarmonyPriority(800)]
        public static bool Prefix(GordoSnare __instance, Collider col)
        {
            bool flag = !col.isTrigger && __instance.bait == null && !ComponentExtensions.GetPrivateField<bool>(__instance, "isSnared");
            if (flag)
            {
                Identifiable component = col.GetComponent<Identifiable>();
                bool flag2 = component != null;
                if (flag2)
                {
                    bool flag3 = false;
                    foreach(Identifiable.Id id in Identifiable.NON_SLIMES_CLASS) {
                        if(component.id == Identifiable.Id.STRANGE_DIAMOND_CRAFT && Identifiable.IsNonSlimeResource(component.id)) {
                            flag3 = true; //because it‘s desired
                            break;
                        }
                    }
                    if (flag3)
                    {
                        bool flag4 = __instance.baitAttachedFx != null;
                        if (flag4)
                        {
                            SRBehaviour.SpawnAndPlayFX(__instance.baitAttachedFx, __instance.gameObject);
                        }
                        Destroyer.DestroyActor(col.gameObject, "GordoSnare.OnTriggerEnter", false);
                        __instance.InvokePrivateMethod("AttachBait", new object[]
                        {
                            component.id
                        });
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
namespace MoreGordos
{
    // Token: 0x02000008 RID: 8
    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("OnTriggerEnter")]
    public class Patch_SnareResourceGltich

    {
    // Token: 0x06000014 RID: 20 RVA: 0x00002CCC File Offset: 0x00000ECC
    [HarmonyPriority(800)]
    public static bool Prefix(GordoSnare __instance, Collider col)
    {
        bool flag = !col.isTrigger && __instance.bait == null &&
                    !ComponentExtensions.GetPrivateField<bool>(__instance, "isSnared");
        if (flag)
        {
            Identifiable component = col.GetComponent<Identifiable>();
            bool flag2 = component != null;
            if (flag2)
            {
                bool flag3 = false;
                foreach (Identifiable.Id id in Identifiable.NON_SLIMES_CLASS)
                {
                    if (component.id == Identifiable.Id.MANIFOLD_CUBE_CRAFT &&
                        Identifiable.IsNonSlimeResource(component.id))
                    {
                        flag3 = true; //because it‘s desired
                        break;
                    }
                }

                if (flag3)
                {
                    bool flag4 = __instance.baitAttachedFx != null;
                    if (flag4)
                    {
                        SRBehaviour.SpawnAndPlayFX(__instance.baitAttachedFx, __instance.gameObject);
                    }

                    Destroyer.DestroyActor(col.gameObject, "GordoSnare.OnTriggerEnter", false);
                    __instance.InvokePrivateMethod("AttachBait", new object[]
                    {
                        component.id
                    });
                    return false;
                }
            }
        }

        return true;
    }
    }
}
namespace MoreGordos
{
    // Token: 0x02000008 RID: 8
    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("OnTriggerEnter")]
    public class Patch_SnareResourceFire
    {
        // Token: 0x06000014 RID: 20 RVA: 0x00002CCC File Offset: 0x00000ECC
        [HarmonyPriority(800)]
        public static bool Prefix(GordoSnare __instance, Collider col)
        {
            bool flag = !col.isTrigger && __instance.bait == null && !ComponentExtensions.GetPrivateField<bool>(__instance, "isSnared");
            if (flag)
            {
                Identifiable component = col.GetComponent<Identifiable>();
                bool flag2 = component != null;
                if (flag2)
                {
                    bool flag3 = false;
                    foreach(Identifiable.Id id in Identifiable.NON_SLIMES_CLASS) {
                        if(component.id == Identifiable.Id.LAVA_DUST_CRAFT && Identifiable.IsNonSlimeResource(component.id)) {
                            flag3 = true; //because it‘s desired
                            break;
                        }
                    }
                    if (flag3)
                    {
                        bool flag4 = __instance.baitAttachedFx != null;
                        if (flag4)
                        {
                            SRBehaviour.SpawnAndPlayFX(__instance.baitAttachedFx, __instance.gameObject);
                        }
                        Destroyer.DestroyActor(col.gameObject, "GordoSnare.OnTriggerEnter", false);
                        __instance.InvokePrivateMethod("AttachBait", new object[]
                        {
                            component.id
                        });
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
namespace MoreGordos
{
    // Token: 0x02000008 RID: 8
    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("OnTriggerEnter")]
    public class Patch_SnareResourcePuddle
    {
        // Token: 0x06000014 RID: 20 RVA: 0x00002CCC File Offset: 0x00000ECC
        [HarmonyPriority(800)]
        public static bool Prefix(GordoSnare __instance, Collider col)
        {
            bool flag = !col.isTrigger && __instance.bait == null && !ComponentExtensions.GetPrivateField<bool>(__instance, "isSnared");
            if (flag)
            {
                Identifiable component = col.GetComponent<Identifiable>();
                bool flag2 = component != null;
                if (flag2)
                {
                    bool flag3 = false;
                    foreach(Identifiable.Id id in Identifiable.NON_SLIMES_CLASS) {
                        if(component.id == Identifiable.Id.DEEP_BRINE_CRAFT && Identifiable.IsNonSlimeResource(component.id)) {
                            flag3 = true; //because it‘s desired
                            break;
                        }
                    }
                    if (flag3)
                    {
                        bool flag4 = __instance.baitAttachedFx != null;
                        if (flag4)
                        {
                            SRBehaviour.SpawnAndPlayFX(__instance.baitAttachedFx, __instance.gameObject);
                        }
                        Destroyer.DestroyActor(col.gameObject, "GordoSnare.OnTriggerEnter", false);
                        __instance.InvokePrivateMethod("AttachBait", new object[]
                        {
                            component.id
                        });
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
namespace MoreGordos
{
    // Token: 0x02000008 RID: 8
    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("OnTriggerEnter")]
    public class Patch_SnareResourceSaber
    {
        // Token: 0x06000014 RID: 20 RVA: 0x00002CCC File Offset: 0x00000ECC
        [HarmonyPriority(800)]
        public static bool Prefix(GordoSnare __instance, Collider col)
        {
            bool flag = !col.isTrigger && __instance.bait == null && !ComponentExtensions.GetPrivateField<bool>(__instance, "isSnared");
            if (flag)
            {
                Identifiable component = col.GetComponent<Identifiable>();
                bool flag2 = component != null;
                if (flag2)
                {
                    bool flag3 = false;
                    foreach(Identifiable.Id id in Identifiable.NON_SLIMES_CLASS) {
                        if(component.id == Identifiable.Id.SPICY_TOFU && Identifiable.IsNonSlimeResource(component.id)) {
                            flag3 = true; //because it‘s desired
                            break;
                        }
                    }
                    if (flag3)
                    {
                        bool flag4 = __instance.baitAttachedFx != null;
                        if (flag4)
                        {
                            SRBehaviour.SpawnAndPlayFX(__instance.baitAttachedFx, __instance.gameObject);
                        }
                        Destroyer.DestroyActor(col.gameObject, "GordoSnare.OnTriggerEnter", false);
                        __instance.InvokePrivateMethod("AttachBait", new object[]
                        {
                            component.id
                        });
                        return false;
                    }
                }
            }
            return true;
        }
    }
}


