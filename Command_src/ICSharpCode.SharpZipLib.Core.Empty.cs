using System;

namespace ICSharpCode.SharpZipLib.Core;

internal static class Empty
{
	public static T[] Array<T>()
	{
		return System.Array.Empty<T>();
	}

	static Empty()
	{
		Class72.smethod_20();
	}
}
