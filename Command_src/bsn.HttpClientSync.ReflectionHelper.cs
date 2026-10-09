using System;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;

namespace bsn.HttpClientSync;

internal static class ReflectionHelper<TType>
{
	private static readonly Lazy<FieldInfo[]> lazy_0;

	internal static object object_0;

	public static TType CreateUninitialized()
	{
		return (TType)FormatterServices.GetUninitializedObject(typeof(TType));
	}

	public static void CopyFields(TType source, TType destination)
	{
		object obj = source;
		MemberInfo[] value = lazy_0.Value;
		object[] objectData = FormatterServices.GetObjectData(obj, value);
		object obj2 = destination;
		value = lazy_0.Value;
		FormatterServices.PopulateObjectMembers(obj2, value, objectData);
	}

	public static T GetPrivateMethod<T>(string name) where T : Delegate
	{
		MethodInfo method = typeof(TType).GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (method == null)
		{
			throw new MissingMethodException(typeof(TType).AssemblyQualifiedName, name);
		}
		return (T)Delegate.CreateDelegate(typeof(T), method);
	}

	static ReflectionHelper()
	{
		Class72.smethod_20();
		lazy_0 = new Lazy<FieldInfo[]>(() => typeof(StreamContent).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), LazyThreadSafetyMode.PublicationOnly);
	}

	internal static bool smethod_0()
	{
		return object_0 == null;
	}

	internal static object smethod_1()
	{
		return object_0;
	}
}
