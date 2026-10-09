using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace DarkUI.Docking;

public sealed class DockRegionState
{
	[CompilerGenerated]
	private DarkDockArea darkDockArea_0;

	[CompilerGenerated]
	private Size size_0;

	[CompilerGenerated]
	private List<DockGroupState> list_0;

	public DarkDockArea Area
	{
		[CompilerGenerated]
		get
		{
			return darkDockArea_0;
		}
		[CompilerGenerated]
		set
		{
			darkDockArea_0 = value;
		}
	}

	public Size Size
	{
		[CompilerGenerated]
		get
		{
			return size_0;
		}
		[CompilerGenerated]
		set
		{
			size_0 = value;
		}
	}

	public List<DockGroupState> Groups
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

	public DockRegionState()
	{
		Groups = new List<DockGroupState>();
	}

	public DockRegionState(DarkDockArea area)
		: this()
	{
		Area = area;
	}

	public DockRegionState(DarkDockArea area, Size size)
		: this(area)
	{
		Size = size;
	}

	static DockRegionState()
	{
		Class72.smethod_20();
	}
}
