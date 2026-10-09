using System;
using System.Runtime.Serialization;

namespace DotSpatial.Serialization;

[Obsolete("Do not use it. This class is not used in DotSpatial anymore.")]
public class AssemblyMissingException : Exception
{
	public AssemblyMissingException(string message)
		: base(message)
	{
	}

	public AssemblyMissingException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public AssemblyMissingException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	static AssemblyMissingException()
	{
		Class72.smethod_20();
	}
}
