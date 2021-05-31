using System;
using System.Reflection;
using HarmonyLib;
using SRML.Console;
using Console = SRML.Console.Console;

namespace MoreGordos
{
    // Token: 0x02000005 RID: 5
    public class Base
    {
        // Token: 0x0600001E RID: 30 RVA: 0x00002ADC File Offset: 0x00000CDC
        public static void Log(string message, Base.LogType logType = Base.LogType.NONE, bool Override = false)
        {
            bool flag = !Base.DebugMode && !Override;
            if (!flag)
            {
                bool flag2 = logType == Base.LogType.SUCCESS;
                if (flag2)
                {
                    Console.LogSuccess(message, true);
                }
                else
                {
                    bool flag3 = logType == Base.LogType.WARNING;
                    if (flag3)
                    {
                        Console.LogWarning(message, true);
                    }
                    else
                    {
                        bool flag4 = logType == Base.LogType.ERROR;
                        if (flag4)
                        {
                            Console.LogWarning(message, true);
                        }
                        else
                        {
                            Console.Log(message, true);
                        }
                    }
                }
            }
        }

        // Token: 0x0600001F RID: 31 RVA: 0x00002B3C File Offset: 0x00000D3C
        public static void Init(Harmony HarmonyInstance, Assembly execAssembly)
        {
            bool flag = Base.isInitialized;
            if (!flag)
            {
                Base.harmony = HarmonyInstance;
                Base.assembly = execAssembly;
                Base.isInitialized = true;
            }
        }

        // Token: 0x04000001 RID: 1
        public static bool isInitialized = false;

        // Token: 0x04000002 RID: 2
        internal static Assembly assembly;

        // Token: 0x04000003 RID: 3
        internal static Harmony harmony;

        // Token: 0x04000004 RID: 4
        public static string Namespace = "TwinkleSlime";

        // Token: 0x04000005 RID: 5
        public static bool DebugMode = false;

        // Token: 0x02000024 RID: 36
        public enum LogType
        {
            // Token: 0x04000055 RID: 85
            NONE,
            // Token: 0x04000056 RID: 86
            SUCCESS,
            // Token: 0x04000057 RID: 87
            WARNING,
            // Token: 0x04000058 RID: 88
            ERROR
        }
    }
}