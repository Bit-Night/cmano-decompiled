using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace OpenDis.Core;

public class EnumNotFoundException : Exception
{
	[CompilerGenerated]
	private Type type_0;

	public Type EnumType
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

	public EnumNotFoundException(string message, Exception exception)
		: base(message, exception)
	{
	}

	private EnumNotFoundException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public EnumNotFoundException(string message, Type enumType)
		: base(message)
	{
		EnumType = enumType;
	}

	public EnumNotFoundException(string message)
		: base(message)
	{
	}

	public EnumNotFoundException()
	{
	}

	static EnumNotFoundException()
	{
		Class72.smethod_20();
	}
}
