using System.Runtime.CompilerServices;

namespace HPCsharp;

public static class SystemAttributes
{
	[CompilerGenerated]
	private static int int_0;

	public static int HyperthreadingNumberOfWays
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	static SystemAttributes()
	{
		Class72.smethod_20();
		int_0 = 2;
	}
}
