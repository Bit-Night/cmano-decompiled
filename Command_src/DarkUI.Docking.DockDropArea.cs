using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DarkUI.Docking;

internal class DockDropArea
{
	[CompilerGenerated]
	private DarkDockPanel darkDockPanel_0;

	[CompilerGenerated]
	private Rectangle rectangle_0;

	[CompilerGenerated]
	private Rectangle rectangle_1;

	[CompilerGenerated]
	private DarkDockRegion darkDockRegion_0;

	[CompilerGenerated]
	private DarkDockGroup darkDockGroup_0;

	[CompilerGenerated]
	private DockInsertType dockInsertType_0;

	internal DarkDockPanel DockPanel
	{
		[CompilerGenerated]
		get
		{
			return darkDockPanel_0;
		}
		[CompilerGenerated]
		private set
		{
			darkDockPanel_0 = value;
		}
	}

	internal Rectangle DropArea
	{
		[CompilerGenerated]
		get
		{
			return rectangle_0;
		}
		[CompilerGenerated]
		private set
		{
			rectangle_0 = value;
		}
	}

	internal Rectangle HighlightArea
	{
		[CompilerGenerated]
		get
		{
			return rectangle_1;
		}
		[CompilerGenerated]
		private set
		{
			rectangle_1 = value;
		}
	}

	internal DarkDockRegion DockRegion
	{
		[CompilerGenerated]
		get
		{
			return darkDockRegion_0;
		}
		[CompilerGenerated]
		private set
		{
			darkDockRegion_0 = value;
		}
	}

	internal DarkDockGroup DockGroup
	{
		[CompilerGenerated]
		get
		{
			return darkDockGroup_0;
		}
		[CompilerGenerated]
		private set
		{
			darkDockGroup_0 = value;
		}
	}

	internal DockInsertType InsertType
	{
		[CompilerGenerated]
		get
		{
			return dockInsertType_0;
		}
		[CompilerGenerated]
		private set
		{
			dockInsertType_0 = value;
		}
	}

	internal DockDropArea(DarkDockPanel dockPanel, DarkDockRegion region)
	{
		DockPanel = dockPanel;
		DockRegion = region;
		InsertType = DockInsertType.None;
		BuildAreas();
	}

	internal DockDropArea(DarkDockPanel dockPanel, DarkDockGroup group, DockInsertType insertType)
	{
		DockPanel = dockPanel;
		DockGroup = group;
		InsertType = insertType;
		BuildAreas();
	}

	internal void BuildAreas()
	{
		if (DockRegion == null)
		{
			if (DockGroup != null)
			{
				method_1();
			}
		}
		else
		{
			method_0();
		}
	}

	private void method_0()
	{
		switch (DockRegion.DockArea)
		{
		case DarkDockArea.Left:
		{
			Rectangle highlightArea3 = (DropArea = new Rectangle
			{
				X = ((Control)DockPanel).PointToScreen(Point.Empty).X,
				Y = ((Control)DockPanel).PointToScreen(Point.Empty).Y,
				Width = 50,
				Height = ((Control)DockPanel).Height
			});
			HighlightArea = highlightArea3;
			break;
		}
		case DarkDockArea.Right:
		{
			Rectangle highlightArea2 = (DropArea = new Rectangle
			{
				X = ((Control)DockPanel).PointToScreen(Point.Empty).X + ((Control)DockPanel).Width - 50,
				Y = ((Control)DockPanel).PointToScreen(Point.Empty).Y,
				Width = 50,
				Height = ((Control)DockPanel).Height
			});
			HighlightArea = highlightArea2;
			break;
		}
		case DarkDockArea.Bottom:
		{
			int num = ((Control)DockPanel).PointToScreen(Point.Empty).X;
			int num2 = ((Control)DockPanel).Width;
			if (((Control)DockPanel.Regions[DarkDockArea.Left]).Visible)
			{
				num += ((Control)DockPanel.Regions[DarkDockArea.Left]).Width;
				num2 -= ((Control)DockPanel.Regions[DarkDockArea.Left]).Width;
			}
			if (((Control)DockPanel.Regions[DarkDockArea.Right]).Visible)
			{
				num2 -= ((Control)DockPanel.Regions[DarkDockArea.Right]).Width;
			}
			Rectangle highlightArea = (DropArea = new Rectangle
			{
				X = num,
				Y = ((Control)DockPanel).PointToScreen(Point.Empty).Y + ((Control)DockPanel).Height - 50,
				Width = num2,
				Height = 50
			});
			HighlightArea = highlightArea;
			break;
		}
		}
	}

	private void method_1()
	{
		switch (InsertType)
		{
		case DockInsertType.None:
		{
			Rectangle highlightArea2 = (DropArea = new Rectangle
			{
				X = ((Control)DockGroup).PointToScreen(Point.Empty).X,
				Y = ((Control)DockGroup).PointToScreen(Point.Empty).Y,
				Width = ((Control)DockGroup).Width,
				Height = ((Control)DockGroup).Height
			});
			HighlightArea = highlightArea2;
			break;
		}
		case DockInsertType.Before:
		{
			int width = ((Control)DockGroup).Width;
			int height = ((Control)DockGroup).Height;
			switch (DockGroup.DockArea)
			{
			case DarkDockArea.Bottom:
				width = ((Control)DockGroup).Width / 4;
				break;
			case DarkDockArea.Left:
			case DarkDockArea.Right:
				height = ((Control)DockGroup).Height / 4;
				break;
			}
			Rectangle highlightArea3 = (DropArea = new Rectangle
			{
				X = ((Control)DockGroup).PointToScreen(Point.Empty).X,
				Y = ((Control)DockGroup).PointToScreen(Point.Empty).Y,
				Width = width,
				Height = height
			});
			HighlightArea = highlightArea3;
			break;
		}
		case DockInsertType.After:
		{
			int x = ((Control)DockGroup).PointToScreen(Point.Empty).X;
			int y = ((Control)DockGroup).PointToScreen(Point.Empty).Y;
			int num = ((Control)DockGroup).Width;
			int num2 = ((Control)DockGroup).Height;
			switch (DockGroup.DockArea)
			{
			case DarkDockArea.Bottom:
				num = ((Control)DockGroup).Width / 4;
				x = ((Control)DockGroup).PointToScreen(Point.Empty).X + ((Control)DockGroup).Width - num;
				break;
			case DarkDockArea.Left:
			case DarkDockArea.Right:
				num2 = ((Control)DockGroup).Height / 4;
				y = ((Control)DockGroup).PointToScreen(Point.Empty).Y + ((Control)DockGroup).Height - num2;
				break;
			}
			Rectangle highlightArea = (DropArea = new Rectangle
			{
				X = x,
				Y = y,
				Width = num,
				Height = num2
			});
			HighlightArea = highlightArea;
			break;
		}
		}
	}

	static DockDropArea()
	{
		Class72.smethod_20();
	}
}
