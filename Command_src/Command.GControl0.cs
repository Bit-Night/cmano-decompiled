using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Command;

public sealed class GControl0 : Control
{
	public enum Style
	{
		Close,
		Minimize,
		Maximize
	}

	private HelperMethods.MouseMode mouseMode_0;

	private Style style_0;

	[Category("Custom")]
	[Description("Gets or sets the type of control button.")]
	public Style ControlStyle
	{
		get
		{
			return style_0;
		}
		set
		{
			style_0 = value;
			((Control)this).Invalidate();
		}
	}

	public GControl0()
	{
		style_0 = Style.Close;
		((Control)this).SetStyle((ControlStyles)141330, true);
		((Control)this).DoubleBuffered = true;
		((Control)this).BackColor = Color.Transparent;
		((Control)this).UpdateStyles();
		((Control)this).Anchor = (AnchorStyles)9;
		((Control)this).Size = new Size(18, 18);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		graphics.SmoothingMode = (SmoothingMode)4;
		switch (mouseMode_0)
		{
		case HelperMethods.MouseMode.Normal:
		{
			LinearGradientBrush val5 = new LinearGradientBrush(new Rectangle(1, 1, 15, 15), Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f);
			try
			{
				Pen val6 = new Pen(Color.FromArgb(22, 22, 22));
				try
				{
					graphics.FillEllipse((Brush)(object)val5, new Rectangle(1, 1, 15, 15));
					graphics.DrawEllipse(val6, new Rectangle(1, 1, 15, 15));
					break;
				}
				finally
				{
					((IDisposable)val6)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val5)?.Dispose();
			}
		}
		case HelperMethods.MouseMode.Hovered:
		{
			((Control)this).Cursor = Cursors.Hand;
			LinearGradientBrush val3 = new LinearGradientBrush(new Rectangle(1, 1, 15, 15), Color.FromArgb(29, 29, 29), Color.FromArgb(41, 41, 41), 90f);
			try
			{
				Pen val4 = new Pen(Color.FromArgb(22, 22, 22));
				try
				{
					graphics.FillEllipse((Brush)(object)val3, new Rectangle(1, 1, 15, 15));
					graphics.DrawEllipse(val4, new Rectangle(1, 1, 15, 15));
					break;
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
		}
		case HelperMethods.MouseMode.Pushed:
		{
			LinearGradientBrush val = new LinearGradientBrush(new Rectangle(1, 1, 15, 15), Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f);
			try
			{
				Pen val2 = new Pen(Color.FromArgb(22, 22, 22));
				try
				{
					graphics.FillEllipse((Brush)(object)val, new Rectangle(1, 1, 15, 15));
					graphics.DrawEllipse(val2, new Rectangle(1, 1, 15, 15));
					break;
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		}
	}

	protected override void OnClick(EventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Invalid comparison between Unknown and I4
		((Control)this).OnClick(e);
		if (ControlStyle != Style.Close)
		{
			if (ControlStyle == Style.Minimize)
			{
				if ((int)((Control)this).FindForm().WindowState == 0)
				{
					((Control)this).FindForm().WindowState = (FormWindowState)1;
				}
			}
			else if (ControlStyle == Style.Maximize)
			{
				if ((int)((Control)this).FindForm().WindowState == 0)
				{
					((Control)this).FindForm().WindowState = (FormWindowState)2;
				}
				else if ((int)((Control)this).FindForm().WindowState == 2)
				{
					((Control)this).FindForm().WindowState = (FormWindowState)0;
				}
			}
		}
		else
		{
			Environment.Exit(0);
			Application.Exit();
		}
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		((Control)this).OnMouseEnter(e);
		mouseMode_0 = HelperMethods.MouseMode.Hovered;
		((Control)this).Invalidate();
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		((Control)this).OnMouseUp(e);
		mouseMode_0 = HelperMethods.MouseMode.Hovered;
		((Control)this).Invalidate();
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		((Control)this).OnMouseDown(e);
		mouseMode_0 = HelperMethods.MouseMode.Pushed;
		((Control)this).Invalidate();
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		((Control)this).OnMouseLeave(e);
		mouseMode_0 = HelperMethods.MouseMode.Normal;
		((Control)this).Invalidate();
	}

	static GControl0()
	{
		Class72.smethod_20();
	}
}
