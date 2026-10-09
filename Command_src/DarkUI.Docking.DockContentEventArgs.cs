using System;
using System.Runtime.CompilerServices;

namespace DarkUI.Docking;

public sealed class DockContentEventArgs : EventArgs
{
	[CompilerGenerated]
	private DarkDockContent darkDockContent_0;

	public DarkDockContent Content
	{
		[CompilerGenerated]
		get
		{
			return darkDockContent_0;
		}
		[CompilerGenerated]
		private set
		{
			darkDockContent_0 = value;
		}
	}

	public DockContentEventArgs(DarkDockContent content)
	{
		Content = content;
	}

	static DockContentEventArgs()
	{
		Class72.smethod_20();
	}
}
