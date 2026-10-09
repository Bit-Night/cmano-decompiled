using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Forms;

namespace DarkUI.Docking;

public sealed class DarkDockSplitter
{
	private Control control_0;

	private Control control_1;

	private DarkSplitterType darkSplitterType_0;

	private int int_0;

	private int int_1;

	private DarkTranslucentForm darkTranslucentForm_0;

	[CompilerGenerated]
	private Rectangle rectangle_0;

	[CompilerGenerated]
	private Cursor cursor_0;

	public Rectangle Bounds
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

	public Cursor ResizeCursor
	{
		[CompilerGenerated]
		get
		{
			return cursor_0;
		}
		[CompilerGenerated]
		private set
		{
			cursor_0 = value;
		}
	}

	public DarkDockSplitter(Control parentControl, Control control, DarkSplitterType splitterType)
	{
		control_0 = parentControl;
		control_1 = control;
		darkSplitterType_0 = splitterType;
		switch (darkSplitterType_0)
		{
		case DarkSplitterType.Left:
		case DarkSplitterType.Right:
			ResizeCursor = Cursors.SizeWE;
			break;
		case DarkSplitterType.Top:
		case DarkSplitterType.Bottom:
			ResizeCursor = Cursors.SizeNS;
			break;
		}
	}

	public void ShowOverlay()
	{
		darkTranslucentForm_0 = new DarkTranslucentForm(Color.Black);
		((Control)darkTranslucentForm_0).Visible = true;
		UpdateOverlay(new Point(0, 0));
	}

	public void HideOverlay()
	{
		((Control)darkTranslucentForm_0).Visible = false;
	}

	public void UpdateOverlay(Point difference)
	{
		Rectangle bounds = new Rectangle(Bounds.Location, Bounds.Size);
		switch (darkSplitterType_0)
		{
		case DarkSplitterType.Left:
		{
			int num4 = Math.Max(bounds.Location.X - difference.X, int_0);
			if (int_1 != 0 && num4 > int_1)
			{
				num4 = int_1;
			}
			bounds.Location = new Point(num4, bounds.Location.Y);
			break;
		}
		case DarkSplitterType.Right:
		{
			int num3 = Math.Max(bounds.Location.X - difference.X, int_0);
			if (int_1 != 0 && num3 > int_1)
			{
				num3 = int_1;
			}
			bounds.Location = new Point(num3, bounds.Location.Y);
			break;
		}
		case DarkSplitterType.Top:
		{
			int num2 = Math.Max(bounds.Location.Y - difference.Y, int_0);
			if (int_1 != 0 && num2 > int_1)
			{
				num2 = int_1;
			}
			bounds.Location = new Point(bounds.Location.X, num2);
			break;
		}
		case DarkSplitterType.Bottom:
		{
			int num = Math.Max(bounds.Location.Y - difference.Y, int_0);
			if (int_1 != 0 && num > int_1)
			{
				int num2 = int_1;
			}
			bounds.Location = new Point(bounds.Location.X, num);
			break;
		}
		}
		((Control)darkTranslucentForm_0).Bounds = bounds;
	}

	public void Move(Point difference)
	{
		switch (darkSplitterType_0)
		{
		case DarkSplitterType.Left:
		{
			Control obj4 = control_1;
			obj4.Width += difference.X;
			break;
		}
		case DarkSplitterType.Right:
		{
			Control obj3 = control_1;
			obj3.Width -= difference.X;
			break;
		}
		case DarkSplitterType.Top:
		{
			Control obj2 = control_1;
			obj2.Height += difference.Y;
			break;
		}
		case DarkSplitterType.Bottom:
		{
			Control obj = control_1;
			obj.Height -= difference.Y;
			break;
		}
		}
		UpdateBounds();
	}

	public void UpdateBounds()
	{
		Rectangle rectangle = control_0.RectangleToScreen(control_1.Bounds);
		switch (darkSplitterType_0)
		{
		case DarkSplitterType.Left:
			Bounds = new Rectangle(rectangle.Left - 2, rectangle.Top, 5, rectangle.Height);
			int_1 = rectangle.Right - 2 - control_1.MinimumSize.Width;
			break;
		case DarkSplitterType.Right:
			Bounds = new Rectangle(rectangle.Right - 2, rectangle.Top, 5, rectangle.Height);
			int_0 = rectangle.Left - 2 + control_1.MinimumSize.Width;
			break;
		case DarkSplitterType.Top:
			Bounds = new Rectangle(rectangle.Left, rectangle.Top - 2, rectangle.Width, 5);
			int_1 = rectangle.Bottom - 2 - control_1.MinimumSize.Height;
			break;
		case DarkSplitterType.Bottom:
			Bounds = new Rectangle(rectangle.Left, rectangle.Bottom - 2, rectangle.Width, 5);
			int_0 = rectangle.Top - 2 + control_1.MinimumSize.Height;
			break;
		}
	}

	static DarkDockSplitter()
	{
		Class72.smethod_20();
	}
}
