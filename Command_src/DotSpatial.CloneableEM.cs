using System;

namespace DotSpatial;

public static class CloneableEM
{
	public static T Copy<T>(this T original) where T : class, ICloneable
	{
		if (original != null)
		{
			return original.Clone() as T;
		}
		return null;
	}

	static CloneableEM()
	{
		Class72.smethod_20();
	}
}
