using System;
using System.Text;

namespace ServiceStack.Text;

public static class StringBuilderCache
{
	[ThreadStatic]
	private static StringBuilder stringBuilder_0;

	public static StringBuilder Allocate()
	{
		StringBuilder stringBuilder = stringBuilder_0;
		if (stringBuilder == null)
		{
			return new StringBuilder();
		}
		stringBuilder.Length = 0;
		stringBuilder_0 = null;
		return stringBuilder;
	}

	public static void Free(StringBuilder sb)
	{
		stringBuilder_0 = sb;
	}

	public static string ReturnAndFree(StringBuilder sb)
	{
		string result = sb.ToString();
		stringBuilder_0 = sb;
		return result;
	}

	static StringBuilderCache()
	{
		Class72.smethod_20();
	}
}
