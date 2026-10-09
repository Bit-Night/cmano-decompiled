using System;
using System.Runtime.Serialization;

namespace Sharp3D.Math;

[Serializable]
public sealed class QuaternionNotInvertibleException : MathException
{
	public QuaternionNotInvertibleException()
	{
	}

	public QuaternionNotInvertibleException(string message)
		: base(message)
	{
	}

	public QuaternionNotInvertibleException(string message, Exception inner)
		: base(message, inner)
	{
	}

	protected QuaternionNotInvertibleException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	static QuaternionNotInvertibleException()
	{
		Class72.smethod_20();
	}
}
