using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Faster.Map.Core;

[DebuggerDisplay("Key {Key} - value {Value} ")]
public struct FastEntry<TKey, TValue>
{
	[CompilerGenerated]
	private TKey gparam_0;

	[CompilerGenerated]
	private TValue gparam_1;

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

	static FastEntry()
	{
		Class72.smethod_20();
	}
}
