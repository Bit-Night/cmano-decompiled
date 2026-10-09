using System;

namespace CSMaterial.ClipperLib;

internal class ClipperException : Exception
{
	public ClipperException(string description)
		: base(description)
	{
	}

	static ClipperException()
	{
		Class72.smethod_20();
	}
}
