using HarmonyLib;
using MonomiPark.SlimeRancher.DataModel;
using UnityEngine;

namespace MoreGordos
{
    // Token: 0x02000008 RID: 8
    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("OnTriggerEnter")]
    public class Patch_SnareResourceEchoNote1
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
                    foreach(Identifiable.Id id in Identifiable.ECHO_CLASS) {
                        if(component.id == Identifiable.Id.ECHO_NOTE_01  && Identifiable.IsEchoNote(component.id)) {
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
	public class Patch_SnareResourceEchoNote2
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
					foreach(Identifiable.Id id in Identifiable.ECHO_CLASS) {
						if(component.id == Identifiable.Id.ECHO_NOTE_02  && Identifiable.IsEchoNote(component.id)) {
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
	public class Patch_SnareResourceEchoNote3
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
					foreach(Identifiable.Id id in Identifiable.ECHO_CLASS) {
						if(component.id == Identifiable.Id.ECHO_NOTE_03  && Identifiable.IsEchoNote(component.id)) {
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
	public class Patch_SnareResourceEchoNote4
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
					foreach(Identifiable.Id id in Identifiable.ECHO_CLASS) {
						if(component.id == Identifiable.Id.ECHO_NOTE_04  && Identifiable.IsEchoNote(component.id)) {
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
	public class Patch_SnareResourceEchoNote5
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
					foreach(Identifiable.Id id in Identifiable.ECHO_CLASS) {
						if(component.id == Identifiable.Id.ECHO_NOTE_05  && Identifiable.IsEchoNote(component.id)) {
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
	public class Patch_SnareResourceEchoNote6
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
					foreach(Identifiable.Id id in Identifiable.ECHO_CLASS) {
						if(component.id == Identifiable.Id.ECHO_NOTE_06  && Identifiable.IsEchoNote(component.id)) {
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
	public class Patch_SnareResourceEchoNote7
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
					foreach(Identifiable.Id id in Identifiable.ECHO_CLASS) {
						if(component.id == Identifiable.Id.ECHO_NOTE_07  && Identifiable.IsEchoNote(component.id)) {
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
	public class Patch_SnareResourceEchoNote8
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
					foreach(Identifiable.Id id in Identifiable.ECHO_CLASS) {
						if(component.id == Identifiable.Id.ECHO_NOTE_08  && Identifiable.IsEchoNote(component.id)) {
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
	public class Patch_SnareResourceEchoNote9
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
					foreach(Identifiable.Id id in Identifiable.ECHO_CLASS) {
						if(component.id == Identifiable.Id.ECHO_NOTE_09  && Identifiable.IsEchoNote(component.id)) {
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
	public class Patch_SnareResourceEchoNote10
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
					foreach(Identifiable.Id id in Identifiable.ECHO_CLASS) {
						if(component.id == Identifiable.Id.ECHO_NOTE_10  && Identifiable.IsEchoNote(component.id)) {
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
	public class Patch_SnareResourceEchoNote11
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
					foreach(Identifiable.Id id in Identifiable.ECHO_CLASS) {
						if(component.id == Identifiable.Id.ECHO_NOTE_11  && Identifiable.IsEchoNote(component.id)) {
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
	public class Patch_SnareResourceEchoNote12
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
					foreach(Identifiable.Id id in Identifiable.ECHO_CLASS) {
						if(component.id == Identifiable.Id.ECHO_NOTE_12  && Identifiable.IsEchoNote(component.id)) {
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
	public class Patch_SnareResourceEchoNote13
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
					foreach(Identifiable.Id id in Identifiable.ECHO_CLASS) {
						if(component.id == Identifiable.Id.ECHO_NOTE_13  && Identifiable.IsEchoNote(component.id)) {
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

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_Twinkle_Gordo1
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.ECHO_NOTE_01 &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.TWINKLE_GORDO;
                return false;
            }

            return true;
        }
    }
}
namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_Twinkle_Gordo2
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.ECHO_NOTE_02 &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.TWINKLE_GORDO;
                return false;
            }

            return true;
        }
    }
}
namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_Twinkle_Gordo3
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.ECHO_NOTE_03 &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.TWINKLE_GORDO;
                return false;
            }

            return true;
        }
    }
}
namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_Twinkle_Gordo4
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.ECHO_NOTE_04 &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.TWINKLE_GORDO;
                return false;
            }

            return true;
        }
    }
}
namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_Twinkle_Gordo5
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.ECHO_NOTE_05 &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.TWINKLE_GORDO;
                return false;
            }

            return true;
        }
    }
}
namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_Twinkle_Gordo6
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.ECHO_NOTE_06 &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.TWINKLE_GORDO;
                return false;
            }

            return true;
        }
    }
}
namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_Twinkle_Gordo7
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.ECHO_NOTE_07 &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.TWINKLE_GORDO;
                return false;
            }

            return true;
        }
    }
}
namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_Twinkle_Gordo8
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.ECHO_NOTE_08 &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.TWINKLE_GORDO;
                return false;
            }

            return true;
        }
    }
}
namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_Twinkle_Gordo9
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.ECHO_NOTE_09 &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.TWINKLE_GORDO;
                return false;
            }

            return true;
        }
    }
}
namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_Twinkle_Gordo10
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.ECHO_NOTE_10 &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.TWINKLE_GORDO;
                return false;
            }

            return true;
        }
    }
}
namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_Twinkle_Gordo11
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.ECHO_NOTE_11 &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.TWINKLE_GORDO;
                return false;
            }

            return true;
        }
    }
}
namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_Twinkle_Gordo12
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.ECHO_NOTE_12 &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.TWINKLE_GORDO;
                return false;
            }

            return true;
        }
    }
}
namespace MoreGordos
{

    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    public class Patch_Twinkle_Gordo13
    {
        [HarmonyPriority(Priority.First)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            Identifiable.Id baitId = __instance.GetPrivateField<SnareModel>("model").baitTypeId;
            if (baitId == Identifiable.Id.ECHO_NOTE_13 &&
                Randoms.SHARED.GetInRange(0, 100) <= 100) //75% chance of gummy gordo
            {
                __result = Id.TWINKLE_GORDO;
                return false;
            }

            return true;
        }
    }
}