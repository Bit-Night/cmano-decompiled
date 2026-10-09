using System.Runtime.CompilerServices;

namespace DarkUI.Docking;

internal class DockDropCollection
{
	[CompilerGenerated]
	private DockDropArea dockDropArea_0;

	[CompilerGenerated]
	private DockDropArea dockDropArea_1;

	[CompilerGenerated]
	private DockDropArea dockDropArea_2;

	internal DockDropArea DropArea
	{
		[CompilerGenerated]
		get
		{
			return dockDropArea_0;
		}
		[CompilerGenerated]
		private set
		{
			dockDropArea_0 = value;
		}
	}

	internal DockDropArea InsertBeforeArea
	{
		[CompilerGenerated]
		get
		{
			return dockDropArea_1;
		}
		[CompilerGenerated]
		private set
		{
			dockDropArea_1 = value;
		}
	}

	internal DockDropArea InsertAfterArea
	{
		[CompilerGenerated]
		get
		{
			return dockDropArea_2;
		}
		[CompilerGenerated]
		private set
		{
			dockDropArea_2 = value;
		}
	}

	internal DockDropCollection(DarkDockPanel dockPanel, DarkDockGroup group)
	{
		DropArea = new DockDropArea(dockPanel, group, DockInsertType.None);
		InsertBeforeArea = new DockDropArea(dockPanel, group, DockInsertType.Before);
		InsertAfterArea = new DockDropArea(dockPanel, group, DockInsertType.After);
	}

	static DockDropCollection()
	{
		Class72.smethod_20();
	}
}
