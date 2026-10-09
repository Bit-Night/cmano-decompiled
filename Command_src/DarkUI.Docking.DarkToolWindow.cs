using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Docking;

[ToolboxItem(false)]
public sealed class DarkToolWindow : DarkDockContent
{
	private Rectangle rectangle_0;

	private bool bool_0;

	private bool bool_1;

	private Rectangle rectangle_1;

	private bool bool_2;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding Padding => ((Control)this).Padding;

	public DarkToolWindow()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		((Control)this).SetStyle((ControlStyles)131090, true);
		((Control)this).BackColor = Colors.GreyBackground;
		((Control)this).Padding = new Padding(0, 25, 0, 0);
		method_0();
	}

	private bool IsActive()
	{
		if (base.DockPanel != null)
		{
			return base.DockPanel.ActiveContent == this;
		}
		return false;
	}

	private void method_0()
	{
		rectangle_1 = new Rectangle
		{
			X = ((Control)this).ClientRectangle.Left,
			Y = ((Control)this).ClientRectangle.Top,
			Width = ((Control)this).ClientRectangle.Width,
			Height = 25
		};
		rectangle_0 = new Rectangle
		{
			X = ((Control)this).ClientRectangle.Right - ((Image)DockIcons.tw_close).Width - 5 - 3,
			Y = ((Control)this).ClientRectangle.Top + 12 - ((Image)DockIcons.tw_close).Height / 2,
			Width = ((Image)DockIcons.tw_close).Width,
			Height = ((Image)DockIcons.tw_close).Height
		};
	}

	protected override void OnResize(EventArgs e)
	{
		((UserControl)this).OnResize(e);
		method_0();
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		((Control)this).OnMouseMove(e);
		if (!rectangle_0.Contains(e.Location) && !bool_1)
		{
			if (bool_0)
			{
				bool_0 = false;
				((Control)this).Invalidate();
			}
			if (bool_2)
			{
				base.DockPanel.DragContent(this);
			}
		}
		else if (!bool_0)
		{
			bool_0 = true;
			((Control)this).Invalidate();
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		((UserControl)this).OnMouseDown(e);
		if (rectangle_0.Contains(e.Location))
		{
			bool_1 = true;
			bool_0 = true;
			((Control)this).Invalidate();
		}
		else if (rectangle_1.Contains(e.Location))
		{
			bool_2 = true;
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		((Control)this).OnMouseUp(e);
		if (rectangle_0.Contains(e.Location) && bool_1)
		{
			Close();
		}
		bool_1 = false;
		bool_0 = false;
		bool_2 = false;
		((Control)this).Invalidate();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		SolidBrush val = new SolidBrush(Colors.GreyBackground);
		try
		{
			graphics.FillRectangle((Brush)(object)val, ((Control)this).ClientRectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		bool flag;
		Color color = ((flag = IsActive()) ? Colors.BlueBackground : Colors.HeaderBackground);
		Color color2 = ((!flag) ? Colors.DarkBorder : Colors.DarkBlueBorder);
		Color color3 = ((!flag) ? Colors.LightBorder : Colors.LightBlueBorder);
		SolidBrush val2 = new SolidBrush(color);
		try
		{
			Rectangle rectangle = new Rectangle(0, 0, ((Control)this).ClientRectangle.Width, 25);
			graphics.FillRectangle((Brush)(object)val2, rectangle);
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
		Pen val3 = new Pen(color2);
		try
		{
			graphics.DrawLine(val3, ((Control)this).ClientRectangle.Left, 0, ((Control)this).ClientRectangle.Right, 0);
			graphics.DrawLine(val3, ((Control)this).ClientRectangle.Left, 24, ((Control)this).ClientRectangle.Right, 24);
		}
		finally
		{
			((IDisposable)val3)?.Dispose();
		}
		Pen val4 = new Pen(color3);
		try
		{
			graphics.DrawLine(val4, ((Control)this).ClientRectangle.Left, 1, ((Control)this).ClientRectangle.Right, 1);
		}
		finally
		{
			((IDisposable)val4)?.Dispose();
		}
		int num = 2;
		if (base.Icon != null)
		{
			graphics.DrawImageUnscaled(base.Icon, ((Control)this).ClientRectangle.Left + 5, ((Control)this).ClientRectangle.Top + 12 - base.Icon.Height / 2 + 1);
			num = base.Icon.Width + 8;
		}
		SolidBrush val5 = new SolidBrush(Colors.LightText);
		try
		{
			Rectangle rectangle2 = new Rectangle(num, 0, ((Control)this).ClientRectangle.Width - 4 - num, 25);
			StringFormat val6 = new StringFormat
			{
				Alignment = (StringAlignment)0,
				LineAlignment = (StringAlignment)1,
				FormatFlags = (StringFormatFlags)4096,
				Trimming = (StringTrimming)3
			};
			graphics.DrawString(base.DockText, ((Control)this).Font, (Brush)(object)val5, (RectangleF)rectangle2, val6);
		}
		finally
		{
			((IDisposable)val5)?.Dispose();
		}
		Bitmap val7 = (bool_0 ? DockIcons.tw_close_selected : DockIcons.tw_close);
		if (flag)
		{
			val7 = (bool_0 ? DockIcons.tw_active_close_selected : DockIcons.tw_active_close);
		}
		graphics.DrawImageUnscaled((Image)(object)val7, rectangle_0.Left, rectangle_0.Top);
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
	}

	static DarkToolWindow()
	{
		Class72.smethod_20();
	}
}
