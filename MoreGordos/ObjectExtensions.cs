using System;
using System.Collections.Generic;
using System.Reflection;
using SRML.Console;
using UnityEngine;
using UnityEngine.SceneManagement;
using Console = SRML.Console.Console;
using Object = UnityEngine.Object;

// Token: 0x02000003 RID: 3
public static class ObjectExtensions
{
	// Token: 0x0600000A RID: 10 RVA: 0x00002340 File Offset: 0x00000540
	public static T[] GetComponentsOfType<T>()
	{
		List<T> list = new List<T>();
		GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
		foreach (GameObject gameObject in rootGameObjects)
		{
			T[] componentsInChildren = gameObject.GetComponentsInChildren<T>();
			foreach (T item in componentsInChildren)
			{
				list.Add(item);
			}
		}

		return list.ToArray();
	}

	// Token: 0x0600000B RID: 11 RVA: 0x000023C4 File Offset: 0x000005C4
	public static T[] GetObjectsOfType<T>()
	{
		List<T> list = new List<T>();
		GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
		foreach (GameObject gameObject in rootGameObjects)
		{
			T[] componentsInChildren = gameObject.GetComponentsInChildren<T>();
			foreach (T item in componentsInChildren)
			{
				list.Add(item);
			}
		}

		return list.ToArray();
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00002448 File Offset: 0x00000648
	public static object InvokePrivateMethod<T>(this T obj, string name, params object[] list)
	{
		object result = null;
		try
		{
			List<Type> list2 = new List<Type>();
			foreach (object obj2 in list)
			{
				list2.Add(obj2.GetType());
			}

			MethodInfo method = obj.GetType().GetMethod(name,
				BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, null, list2.ToArray(),
				null);
			result = method.Invoke(obj, list);
		}
		catch (Exception ex)
		{
			string[] array = new string[12];
			array[0] = "Private Method had an error while invoking! Message = ";
			array[1] = ex.Message;
			array[2] = ". Source = ";
			array[3] = ex.Source;
			array[4] = ". InnerException = ";
			int num = 5;
			Exception innerException = ex.InnerException;
			array[num] = ((innerException != null) ? innerException.ToString() : null);
			array[6] = ". StackTrace = ";
			array[7] = ex.StackTrace;
			array[8] = ". HelpLink = ";
			array[9] = ex.HelpLink;
			array[10] = ". TargetSite = ";
			int num2 = 11;
			MethodBase targetSite = ex.TargetSite;
			array[num2] = ((targetSite != null) ? targetSite.ToString() : null);
			Console.LogError(string.Concat(array), true);
		}

		return result;
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002574 File Offset: 0x00000774
	public static R InvokePrivateMethod<T, R>(this T obj, string name, params object[] list)
	{
		return (R) ((object) obj.InvokePrivateMethod(name, list));
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002594 File Offset: 0x00000794
	public static object InvokePrivateStaticMethod<T>(string name, params object[] list)
	{
		object result = null;
		try
		{
			List<Type> list2 = new List<Type>();
			foreach (object obj in list)
			{
				list2.Add(obj.GetType());
			}

			MethodInfo method = typeof(T).GetMethod(name,
				BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, null, list2.ToArray(),
				null);
			result = method.Invoke(null, list);
		}
		catch (Exception ex)
		{
			string[] array = new string[12];
			array[0] = "Private Static Method had an error while invoking! Message = ";
			array[1] = ex.Message;
			array[2] = ". Source = ";
			array[3] = ex.Source;
			array[4] = ". InnerException = ";
			int num = 5;
			Exception innerException = ex.InnerException;
			array[num] = ((innerException != null) ? innerException.ToString() : null);
			array[6] = ". StackTrace = ";
			array[7] = ex.StackTrace;
			array[8] = ". HelpLink = ";
			array[9] = ex.HelpLink;
			array[10] = ". TargetSite = ";
			int num2 = 11;
			MethodBase targetSite = ex.TargetSite;
			array[num2] = ((targetSite != null) ? targetSite.ToString() : null);
			Console.LogError(string.Concat(array), true);
		}

		return result;
	}

	// Token: 0x0600000F RID: 15 RVA: 0x000026B8 File Offset: 0x000008B8
	public static R InvokePrivateStaticMethod<T, R>(string name, params object[] list)
	{
		return (R) ((object) ObjectExtensions.InvokePrivateStaticMethod<T>(name, list));
	}

	// Token: 0x06000010 RID: 16 RVA: 0x000026D8 File Offset: 0x000008D8
	public static T SetPrivateField<T>(this T obj, string name, object value)
	{
		try
		{
			FieldInfo field = obj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
			if (field != null)
			{
				field.SetValue(obj, value);
			}
		}
		catch
		{
		}

		return obj;
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00002730 File Offset: 0x00000930
	public static T SetPrivateProperty<T>(this T obj, string name, object value)
	{
		try
		{
			PropertyInfo property = obj.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic);
			bool flag = property == null;
			if (flag)
			{
				return obj;
			}

			bool canWrite = property.CanWrite;
			if (!canWrite)
			{
				return obj.SetPrivateField("<" + name + ">k__BackingField", value);
			}

			property.SetValue(obj, value, null);
		}
		catch
		{
		}

		return obj;
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000027B8 File Offset: 0x000009B8
	public static E GetPrivateField<E>(this object obj, string name)
	{
		try
		{
			FieldInfo field = obj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
			return (E) ((object) ((field != null) ? field.GetValue(obj) : null));
		}
		catch
		{
		}

		return default(E);
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00002810 File Offset: 0x00000A10
	public static E GetPrivateStaticField<T, E>(string name)
	{
		try
		{
			FieldInfo field = typeof(T).GetField(name, BindingFlags.Static | BindingFlags.NonPublic);
			return (E) ((object) ((field != null) ? field.GetValue(null) : null));
		}
		catch
		{
		}

		return default(E);
	}

	// Token: 0x06000014 RID: 20 RVA: 0x0000286C File Offset: 0x00000A6C

	// Token: 0x06000015 RID: 21 RVA: 0x000028F4 File Offset: 0x00000AF4
	public static T CloneInstance<T>(this T obj) where T : Object
	{
		return Object.Instantiate<T>(obj);
	}
}
