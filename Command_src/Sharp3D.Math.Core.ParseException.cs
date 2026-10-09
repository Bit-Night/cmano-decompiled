using System;
using System.Runtime.Serialization;

namespace Sharp3D.Math.Core;

[Serializable]
public sealed class ParseException : ApplicationException
{
	public ParseException()
	{
	}

	public ParseException(string message)
		: base(message)
	{
	}

	public ParseException(string message, Exception inner)
		: base(message, inner)
	{
	}

	protected ParseException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	static ParseException()
	{
		Class72.smethod_20();
	}
}
