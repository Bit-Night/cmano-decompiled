using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DarkUI.Docking;

public sealed class DockGroupState
{
	[CompilerGenerated]
	private List<string> list_0;

	[CompilerGenerated]
	private string string_0;

	public List<string> Contents
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public string VisibleContent
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public DockGroupState()
	{
		Contents = new List<string>();
	}

	static DockGroupState()
	{
		Class72.smethod_20();
	}
}
