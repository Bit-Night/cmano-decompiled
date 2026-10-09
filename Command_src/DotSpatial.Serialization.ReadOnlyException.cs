using System;
using DotSpatial.Serialization.Properties;

namespace DotSpatial.Serialization;

public class ReadOnlyException : ApplicationException
{
	public ReadOnlyException()
		: base(Resources.ReadOnly)
	{
	}

	public ReadOnlyException(string message)
		: base(message)
	{
	}

	static ReadOnlyException()
	{
		Class72.smethod_20();
	}
}
