using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DotSpatial.Serialization;

public class SerializationMap
{
	private static readonly Dictionary<Type, SerializationMap> dictionary_0;

	private readonly List<SerializationMapEntry> list_0 = new List<SerializationMapEntry>();

	[CompilerGenerated]
	private Type type_0;

	public Type ForType
	{
		[CompilerGenerated]
		get
		{
			return type_0;
		}
		[CompilerGenerated]
		private set
		{
			type_0 = value;
		}
	}

	public List<SerializationMapEntry> Members => list_0;

	static SerializationMap()
	{
		Class72.smethod_20();
		dictionary_0 = new Dictionary<Type, SerializationMap>();
		foreach (Type item in ReflectionHelper.FindDerivedClasses(typeof(SerializationMap)))
		{
			SerializationMap serializationMap;
			try
			{
				serializationMap = (SerializationMap)item.Assembly.CreateInstance(item.FullName);
			}
			catch
			{
				continue;
			}
			if (serializationMap != null)
			{
				dictionary_0[serializationMap.ForType] = serializationMap;
			}
		}
	}

	protected SerializationMap(Type forType)
	{
		ForType = forType;
		ufVelsSndsN(forType);
		dictionary_0[forType] = this;
	}

	public static SerializationMap FromType(Type type)
	{
		SerializationMap serializationMap = smethod_0(type);
		if (serializationMap != null)
		{
			return serializationMap;
		}
		return new SerializationMap(type);
	}

	private static SerializationMap smethod_0(Type type_1)
	{
		if (!dictionary_0.ContainsKey(type_1))
		{
			return null;
		}
		return dictionary_0[type_1];
	}

	protected SerializationMapEntry Serialize(MemberInfo memberInfo, string name)
	{
		SerializationMapEntry serializationMapEntry = new SerializationMapEntry(memberInfo, new SerializeAttribute(name));
		list_0.Add(serializationMapEntry);
		return serializationMapEntry;
	}

	private void ufVelsSndsN(Type type_1)
	{
		urdelncMuCe(type_1);
		iBselKeugcZ(type_1);
	}

	private void method_0(Type type_1, BindingFlags bindingFlags_0)
	{
		fsyeluyCcyQ(type_1.GetProperties(bindingFlags_0));
	}

	private void method_1(Type type_1, BindingFlags bindingFlags_0)
	{
		fsyeluyCcyQ((from fi in type_1.GetFields(bindingFlags_0)
			where !fi.IsInitOnly || smethod_1(fi)
			select fi).Cast<MemberInfo>());
	}

	private static bool smethod_1(MemberInfo memberInfo_0)
	{
		object[] customAttributes = memberInfo_0.GetCustomAttributes(typeof(SerializeAttribute), inherit: true);
		int num = 0;
		if (0 < customAttributes.Length)
		{
			return ((SerializeAttribute)customAttributes[num]).ConstructorArgumentIndex >= 0;
		}
		return false;
	}

	private void fsyeluyCcyQ(IEnumerable<MemberInfo> ienumerable_0)
	{
		foreach (MemberInfo item in ienumerable_0)
		{
			SerializeAttribute serializeAttribute = item.GetCustomAttributes(typeof(SerializeAttribute), inherit: true).Cast<SerializeAttribute>().FirstOrDefault();
			MemberInfo memberInfo_0 = item;
			if (serializeAttribute != null && !list_0.Any(delegate(SerializationMapEntry mi)
			{
				int result;
				if (!(mi.Member.Name == memberInfo_0.Name))
				{
					result = 0;
				}
				else
				{
					if (mi.Member.DeclaringType == memberInfo_0.DeclaringType)
					{
						return mi.Member.MemberType == memberInfo_0.MemberType;
					}
					result = 0;
				}
				return (byte)result != 0;
			}))
			{
				list_0.Add(new SerializationMapEntry(item, serializeAttribute));
			}
		}
	}

	private void urdelncMuCe(Type type_1)
	{
		Type baseType = type_1.BaseType;
		Stack<Type> stack = new Stack<Type>();
		stack.Push(type_1);
		while (baseType != null && !baseType.Equals(typeof(object)))
		{
			stack.Push(baseType);
			baseType = baseType.BaseType;
		}
		while (stack.Count > 0)
		{
			type_1 = stack.Pop();
			method_1(type_1, BindingFlags.Instance | BindingFlags.NonPublic);
			method_0(type_1, BindingFlags.Instance | BindingFlags.NonPublic);
		}
	}

	private void iBselKeugcZ(Type type_1)
	{
		method_1(type_1, BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
		method_0(type_1, BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
	}
}
