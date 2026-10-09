using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Faster.Map.Core;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
[DebuggerDisplay("hashcode  {Hashcode }")]
public struct Entry<TKey, TValue>
{
	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private TKey gparam_0;

	[CompilerGenerated]
	private TValue gparam_1;

	public int Hashcode
	{
		[CompilerGenerated]
		readonly get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public TKey Key
	{
		[CompilerGenerated]
		readonly get
		{
			return gparam_0;
		}
		[CompilerGenerated]
		set
		{
			gparam_0 = value;
		}
	}

	public TValue Value
	{
		[CompilerGenerated]
		readonly get
		{
			return gparam_1;
		}
		[CompilerGenerated]
		set
		{
			gparam_1 = value;
		}
	}

	static Entry()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_0()
	{
		return true;
	}

	internal static object smethod_1()
	{
		return null;
	}
}
