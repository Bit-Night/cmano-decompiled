using System;
using System.Runtime.CompilerServices;

namespace DarkUI.Controls;

public sealed class ScrollValueEventArgs : EventArgs
{
	[CompilerGenerated]
	private int int_0;

	public int Value
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		private set
		{
			int_0 = value;
		}
	}

	public ScrollValueEventArgs(int value)
	{
		Value = value;
	}

	static ScrollValueEventArgs()
	{
		Class72.smethod_20();
	}
}
