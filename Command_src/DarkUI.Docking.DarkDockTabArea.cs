using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;

namespace DarkUI.Docking;

internal class DarkDockTabArea
{
	private Dictionary<DarkDockContent, DarkDockTab> dictionary_0 = new Dictionary<DarkDockContent, DarkDockTab>();

	private List<ToolStripMenuItem> list_0 = new List<ToolStripMenuItem>();

	private DarkContextMenu darkContextMenu_0 = new DarkContextMenu();

	[CompilerGenerated]
	private DarkDockArea darkDockArea_0;

	[CompilerGenerated]
	private Rectangle rectangle_0;

	[CompilerGenerated]
	private Rectangle rectangle_1;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private DarkDockTab CdKyzzqvBaW;

	public DarkDockArea DockArea
	{
		[CompilerGenerated]
		get
		{
			return darkDockArea_0;
		}
		[CompilerGenerated]
		private set
		{
			darkDockArea_0 = value;
		}
	}

	public Rectangle ClientRectangle
	{
		[CompilerGenerated]
		get
		{
			return rectangle_0;
		}
		[CompilerGenerated]
		set
		{
			rectangle_0 = value;
		}
	}

	public Rectangle DropdownRectangle
	{
		[CompilerGenerated]
		get
		{
			return rectangle_1;
		}
		[CompilerGenerated]
		set
		{
			rectangle_1 = value;
		}
	}

	public bool DropdownHot
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public int Offset
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

	public int TotalTabSize
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public bool Visible
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public DarkDockTab ClickedCloseButton
	{
		[CompilerGenerated]
		get
		{
			return CdKyzzqvBaW;
		}
		[CompilerGenerated]
		set
		{
			CdKyzzqvBaW = value;
		}
	}

	public DarkDockTabArea(DarkDockArea dockArea)
	{
		DockArea = dockArea;
	}

	public void ShowMenu(Control control, Point location)
	{
		((ToolStripDropDown)darkContextMenu_0).Show(control, location);
	}

	public void AddMenuItem(ToolStripMenuItem menuItem)
	{
		list_0.Add(menuItem);
		RebuildMenu();
	}

	public void RemoveMenuItem(ToolStripMenuItem menuItem)
	{
		list_0.Remove(menuItem);
		RebuildMenu();
	}

	public ToolStripMenuItem GetMenuItem(DarkDockContent content)
	{
		ToolStripMenuItem result = null;
		foreach (ToolStripMenuItem item in list_0)
		{
			if (((ToolStripItem)item).Tag is DarkDockContent darkDockContent && darkDockContent == content)
			{
				result = item;
			}
		}
		return result;
	}

	public void RebuildMenu()
	{
		((ToolStrip)darkContextMenu_0).Items.Clear();
		List<ToolStripMenuItem> list = new List<ToolStripMenuItem>();
		int num = 0;
		for (int i = 0; i < list_0.Count; i++)
		{
			foreach (ToolStripMenuItem item in list_0)
			{
				if (((DarkDockContent)((ToolStripItem)item).Tag).Order == num)
				{
					list.Add(item);
				}
			}
			num++;
		}
		foreach (ToolStripMenuItem item2 in list)
		{
			((ToolStrip)darkContextMenu_0).Items.Add((ToolStripItem)(object)item2);
		}
	}

	static DarkDockTabArea()
	{
		Class72.smethod_20();
	}
}
