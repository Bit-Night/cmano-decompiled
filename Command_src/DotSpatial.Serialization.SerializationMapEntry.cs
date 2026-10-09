using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DotSpatial.Serialization;

public class SerializationMapEntry
{
	[CompilerGenerated]
	private MemberInfo lpfelxyksGg;

	[CompilerGenerated]
	private SerializeAttribute serializeAttribute_0;

	public MemberInfo Member
	{
		[CompilerGenerated]
		get
		{
			return lpfelxyksGg;
		}
		[CompilerGenerated]
		private set
		{
			lpfelxyksGg = value;
		}
	}

	public SerializeAttribute Attribute
	{
		[CompilerGenerated]
		get
		{
			return serializeAttribute_0;
		}
		[CompilerGenerated]
		private set
		{
			serializeAttribute_0 = value;
		}
	}

	public SerializationMapEntry(MemberInfo memberInfo, SerializeAttribute attribute)
	{
		Member = memberInfo;
		Attribute = attribute;
	}

	public SerializationMapEntry AsConstructorArgument(int index)
	{
		Attribute.ConstructorArgumentIndex = index;
		return this;
	}

	public SerializationMapEntry WithFormatterType(Type formatterType)
	{
		Attribute.Formatter = formatterType;
		return this;
	}

	public override bool Equals(object obj)
	{
		if (obj is SerializationMapEntry serializationMapEntry)
		{
			if (serializationMapEntry.Member == Member)
			{
				return serializationMapEntry.Attribute == Attribute;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Member.GetHashCode() ^ Attribute.GetHashCode();
	}

	static SerializationMapEntry()
	{
		Class72.smethod_20();
	}
}
