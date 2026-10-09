using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DarkUI.Docking;

public sealed class DockPanelState
{
	[CompilerGenerated]
	private List<DockRegionState> list_0;

	public List<DockRegionState> Regions
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

	public DockPanelState()
	{
		Regions = new List<DockRegionState>();
	}

	static DockPanelState()
	{
		Class72.smethod_20();
	}
}
