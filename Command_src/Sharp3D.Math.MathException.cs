using System;
using System.Runtime.Serialization;

namespace Sharp3D.Math;

[Serializable]
public class MathException : ApplicationException
{
	public MathException()
	{
	}

	public MathException(string message)
		: base(message)
	{
	}

	public MathException(string message, Exception inner)
		: base(message, inner)
	{
	}

	protected MathException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	static MathException()
	{
		Class72.smethod_20();
	}
}
