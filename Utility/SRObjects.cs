using UnityEngine;
using Object = UnityEngine.Object;

namespace More_Gordos.Utility
{
	public static class SRObjects
	{
		public static T Get<T>(string name) where T : Object
		{
			foreach (T t in Resources.FindObjectsOfTypeAll<T>())
			{
				bool flag = t.name.Equals(name);
				if (flag)
				{
					return t;
				}
			}
			return null;
		}

		public static T GetInst<T>(string name) where T : Object
		{
			foreach (T t in Resources.FindObjectsOfTypeAll<T>())
			{
				bool flag = t.name.Equals(name);
				if (flag)
				{
					return Object.Instantiate<T>(t);
				}
			}
			return null;
		}
	}
}
