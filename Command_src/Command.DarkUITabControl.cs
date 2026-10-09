using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using DarkUI.Config;

namespace Command;

public sealed class DarkUITabControl : TabControl
{
	public DarkUITabControl()
	{
		((Control)this).SetStyle((ControlStyles)141314, true);
		((TabControl)this).DoubleBuffered = true;
		((TabControl)this).SizeMode = (TabSizeMode)0;
		((Control)this).Dock = (DockStyle)0;
		((TabControl)this).ItemSize = new Size(80, 20);
		((TabControl)this).Alignment = (TabAlignment)0;
		((Control)this).UpdateStyles();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		graphics.SmoothingMode = (SmoothingMode)4;
		graphics.TextRenderingHint = (TextRenderingHint)5;
		graphics.Clear(Color.FromArgb(39, 39, 39));
		((Control)this).Cursor = Cursors.Hand;
		int num = 0;
		int num2 = ((TabControl)this).TabCount - 1;
		for (int i = 0; i <= num2; i++)
		{
			if (!((TabControl)this).TabPages[i].Enabled)
			{
				continue;
			}
			Rectangle tabRect = ((TabControl)this).GetTabRect(i);
			if (tabRect.Width == 0 || tabRect.Height == 0)
			{
				continue;
			}
			if (i == ((TabControl)this).TabCount - 1)
			{
				LinearGradientBrush val = new LinearGradientBrush(tabRect, Color.FromArgb(29, 29, 29), Color.FromArgb(41, 41, 41), 270f);
				try
				{
					HelperMethods.FillRoundedPath(graphics, (Brush)(object)val, tabRect, 2, TopLeft: false, TopRight: true, BottomLeft: false);
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
			}
			else if (i == 0)
			{
				LinearGradientBrush val2 = new LinearGradientBrush(tabRect, Color.FromArgb(29, 29, 29), Color.FromArgb(41, 41, 41), 270f);
				try
				{
					HelperMethods.FillRoundedPath(graphics, (Brush)(object)val2, new Rectangle(tabRect.X, tabRect.Y, tabRect.Width, tabRect.Height), 2, TopLeft: true, TopRight: false, BottomLeft: true, BottomRight: false);
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			else
			{
				LinearGradientBrush val3 = new LinearGradientBrush(tabRect, Color.FromArgb(29, 29, 29), Color.FromArgb(41, 41, 41), 270f);
				try
				{
					graphics.FillRectangle((Brush)(object)val3, tabRect);
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
			}
		}
		int num3 = ((TabControl)this).TabCount - 1;
		for (int j = 0; j <= num3; j++)
		{
			if (!((TabControl)this).TabPages[j].Enabled)
			{
				continue;
			}
			Rectangle tabRect2 = ((TabControl)this).GetTabRect(j);
			num += tabRect2.Width;
			if (((TabControl)this).SelectedIndex == j)
			{
				LinearGradientBrush val4 = new LinearGradientBrush(tabRect2, Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f);
				try
				{
					if (j == ((TabControl)this).TabCount - 1)
					{
						graphics.FillPath((Brush)(object)val4, HelperMethods.RoundRec(new Rectangle(tabRect2.X + 1, tabRect2.Y, tabRect2.Width - 1, tabRect2.Height - 1), 2, TopLeft: false, TopRight: true, BottomLeft: false));
					}
					else if (j != 0)
					{
						graphics.FillRectangle((Brush)(object)val4, new Rectangle(tabRect2.X + 1, tabRect2.Y, tabRect2.Width - 1, tabRect2.Height));
					}
					else
					{
						graphics.FillPath((Brush)(object)val4, HelperMethods.RoundRec(new Rectangle(tabRect2.X, tabRect2.Y, tabRect2.Width, tabRect2.Height), 2, TopLeft: true, TopRight: false, BottomLeft: true, BottomRight: false));
					}
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
				SolidBrush val5 = new SolidBrush(Color.White);
				try
				{
					graphics.DrawString(((TabControl)this).TabPages[j].Text, ((Control)this).Font, (Brush)(object)val5, (RectangleF)tabRect2, HelperMethods.SetPosition((StringAlignment)1, (StringAlignment)1));
				}
				finally
				{
					((IDisposable)val5)?.Dispose();
				}
			}
			else
			{
				SolidBrush val6 = new SolidBrush(Color.FromArgb(168, 168, 168));
				try
				{
					graphics.DrawString(((TabControl)this).TabPages[j].Text, ((Control)this).Font, (Brush)(object)val6, (RectangleF)tabRect2, HelperMethods.SetPosition((StringAlignment)1, (StringAlignment)1));
				}
				finally
				{
					((IDisposable)val6)?.Dispose();
				}
			}
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		((Control)this).OnMouseMove(e);
		int num = ((TabControl)this).TabCount - 1;
		for (int i = 0; i <= num; i++)
		{
			if (((TabControl)this).GetTabRect(i).Contains(e.Location))
			{
				((Control)this).Cursor = Cursors.Hand;
				((Control)this).Invalidate();
			}
			else
			{
				((Control)this).Cursor = Cursors.Arrow;
				((Control)this).Invalidate();
			}
		}
	}

	protected override void OnCreateControl()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		((Control)this).OnCreateControl();
		foreach (TabPage tabPage in ((TabControl)this).TabPages)
		{
			tabPage.BackColor = Colors.GreyBackground;
		}
	}

	protected override void OnSelecting(TabControlCancelEventArgs e)
	{
		((TabControl)this).OnSelecting(e);
		if (e.TabPage != null && !e.TabPage.Enabled)
		{
			((CancelEventArgs)(object)e).Cancel = true;
		}
	}

	internal void HideDisabledTabs()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		foreach (TabPage tabPage in ((TabControl)this).TabPages)
		{
			TabPage val = tabPage;
			if (val.Enabled)
			{
				((Control)val).Parent = (Control)(object)this;
			}
			else
			{
				((Control)val).Parent = null;
			}
		}
	}

	public void HideNonSelectedTabs()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		foreach (TabPage tabPage in ((TabControl)this).TabPages)
		{
			TabPage val = tabPage;
			if (val == ((TabControl)this).SelectedTab)
			{
				((Control)val).Parent = (Control)(object)this;
			}
			else
			{
				((Control)val).Parent = null;
			}
		}
	}

	static DarkUITabControl()
	{
		Class72.smethod_20();
	}
}
