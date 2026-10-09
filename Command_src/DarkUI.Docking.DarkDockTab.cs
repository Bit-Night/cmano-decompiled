using System.Drawing;
using System.Runtime.CompilerServices;

namespace DarkUI.Docking;

internal class DarkDockTab
{
	[CompilerGenerated]
	private DarkDockContent darkDockContent_0;

	[CompilerGenerated]
	private Rectangle tuhyzuixgtT;

	[CompilerGenerated]
	private Rectangle rectangle_0;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private bool bool_2;

	public DarkDockContent DockContent
	{
		[CompilerGenerated]
		get
		{
			return darkDockContent_0;
		}
		[CompilerGenerated]
		set
		{
			darkDockContent_0 = value;
		}
	}

	public Rectangle ClientRectangle
	{
		[CompilerGenerated]
		get
		{
			return tuhyzuixgtT;
		}
		[CompilerGenerated]
		set
		{
			tuhyzuixgtT = value;
		}
	}

	public Rectangle CloseButtonRectangle
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

	public bool Hot
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

	public bool CloseButtonHot
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

	public bool ShowSeparator
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public DarkDockTab(DarkDockContent content)
	{
		DockContent = content;
	}

	public int CalculateWidth(Graphics g, Font font)
	{
		return (int)g.MeasureString(DockContent.DockText, font).Width + 10;
	}

	static DarkDockTab()
	{
		Class72.smethod_20();
	}
}
