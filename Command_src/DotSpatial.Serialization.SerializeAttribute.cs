using System;
using System.Runtime.CompilerServices;

namespace DotSpatial.Serialization;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class SerializeAttribute : Attribute
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private Type type_0;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		private set
		{
			string_0 = value;
		}
	}

	public int ConstructorArgumentIndex
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public Type Formatter
	{
		[CompilerGenerated]
		get
		{
			return type_0;
		}
		[CompilerGenerated]
		set
		{
			type_0 = value;
		}
	}

	public SerializeAttribute(string name)
	{
		Name = name;
		ConstructorArgumentIndex = -1;
	}

	static SerializeAttribute()
	{
		Class72.smethod_20();
	}
}
