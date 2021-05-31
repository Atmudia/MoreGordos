using System;
using System.Collections.Generic;

namespace MoreGordos
{
    // Token: 0x02000003 RID: 3
    public static class EnumUtils
    {
        // Token: 0x06000002 RID: 2 RVA: 0x000020E0 File Offset: 0x000002E0
        public static T Parse<T>(string value)
        {
            bool flag = !typeof(T).IsEnum;
            if (flag)
            {
                throw new Exception("The given type isn't an enum (" + typeof(T).Name + " isn't an Enum)");
            }
            T result;
            try
            {
                result = (T)((object)Enum.Parse(typeof(T), value));
            }
            catch
            {
                result = default(T);
            }
            return result;
        }

        // Token: 0x06000003 RID: 3 RVA: 0x00002164 File Offset: 0x00000364
        public static T Parse<T>(string value, bool ignoreCase)
        {
            bool flag = !typeof(T).IsEnum;
            if (flag)
            {
                throw new Exception("The given type isn't an enum (" + typeof(T).Name + " isn't an Enum)");
            }
            T result;
            try
            {
                result = (T)((object)Enum.Parse(typeof(T), value, ignoreCase));
            }
            catch
            {
                result = default(T);
            }
            return result;
        }

        // Token: 0x06000004 RID: 4 RVA: 0x000021E8 File Offset: 0x000003E8
        public static string[] GetAllNames<T>()
        {
            bool flag = !typeof(T).IsEnum;
            if (flag)
            {
                throw new Exception("The given type isn't an enum (" + typeof(T).Name + " isn't an Enum)");
            }
            return Enum.GetNames(typeof(T));
        }

        // Token: 0x06000005 RID: 5 RVA: 0x00002244 File Offset: 0x00000444
        public static T[] GetAll<T>()
        {
            bool flag = !typeof(T).IsEnum;
            if (flag)
            {
                throw new Exception("The given type isn't an enum (" + typeof(T).Name + " isn't an Enum)");
            }
            List<T> list = new List<T>();
            foreach (string value in EnumUtils.GetAllNames<T>())
            {
                list.Add(EnumUtils.Parse<T>(value));
            }
            return list.ToArray();
        }
    }
}