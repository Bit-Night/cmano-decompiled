using System;
using System.Collections.Generic;
using System.Reflection;

namespace MapReduce.NET;

public static class TypeFinder
{
	public static Type FindType(string toFind)
	{
		if (toFind == null)
		{
			return null;
		}
		Type type = null;
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < assemblies.Length; i++)
		{
			type = assemblies[i].GetType(toFind);
			if (type != null)
			{
				break;
			}
		}
		if (type == null)
		{
			type = Assembly.Load(toFind.Substring(0, toFind.IndexOf('.'))).GetType(toFind);
		}
		return type;
	}

	public static void MapDictionary(object mapTo, IDictionary<string, string> dict)
	{
		if (mapTo == null || dict == null)
		{
			return;
		}
		Type type = mapTo.GetType();
		foreach (string key in dict.Keys)
		{
			PropertyInfo property = type.GetProperty(key, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			if (!(property == null))
			{
				try
				{
					object value = Convert.ChangeType(dict[key], property.PropertyType);
					property.SetValue(mapTo, value, null);
				}
				catch (Exception)
				{
				}
			}
		}
	}

	static TypeFinder()
	{
		Class72.smethod_20();
	}
}
