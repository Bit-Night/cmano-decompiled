using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DotSpatial.Serialization;

public static class ReflectionHelper
{
	public static IEnumerable<Type> FindDerivedClasses<T>()
	{
		return FindDerivedClasses(typeof(T));
	}

	public static IEnumerable<Type> FindDerivedClasses(Type baseType)
	{
		List<Type> list = new List<Type>();
		string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.AllDirectories);
		foreach (string assemblyFile in files)
		{
			Assembly assembly;
			try
			{
				assembly = Assembly.LoadFrom(assemblyFile);
			}
			catch (BadImageFormatException)
			{
				continue;
			}
			catch (FileLoadException)
			{
				continue;
			}
			try
			{
				if (!baseType.IsGenericTypeDefinition)
				{
					list.AddRange(from t in assembly.GetTypes()
						where !t.Equals(baseType) && baseType.IsAssignableFrom(t)
						select t);
					continue;
				}
				list.AddRange(assembly.GetTypes().Where(delegate(Type t)
				{
					int result;
					if (t.BaseType != null)
					{
						if (t.BaseType.IsGenericType)
						{
							return t.BaseType.GetGenericTypeDefinition().Equals(baseType);
						}
						result = 0;
					}
					else
					{
						result = 0;
					}
					return (byte)result != 0;
				}));
			}
			catch (Exception)
			{
			}
		}
		return list;
	}

	static ReflectionHelper()
	{
		Class72.smethod_20();
	}
}
