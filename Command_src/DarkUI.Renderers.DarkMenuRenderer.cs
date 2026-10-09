using System;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Renderers;

public class DarkMenuRenderer : ToolStripRenderer
{
	protected override void Initialize(ToolStrip toolStrip)
	{
		((ToolStripRenderer)this).Initialize(toolStrip);
		toolStrip.BackColor = Colors.GreyBackground;
		toolStrip.ForeColor = Colors.LightText;
	}

	protected override void InitializeItem(ToolStripItem item)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		((ToolStripRenderer)this).InitializeItem(item);
		item.BackColor = Colors.GreyBackground;
		item.ForeColor = Colors.LightText;
		if (((object)item).GetType() == typeof(ToolStripSeparator))
		{
			item.Margin = new Padding(0, 0, 0, 1);
		}
	}

	protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		SolidBrush val = new SolidBrush(Colors.GreyBackground);
		try
		{
			graphics.FillRectangle((Brush)(object)val, e.AffectedBounds);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		Rectangle rectangle = new Rectangle(0, 0, ((Control)e.ToolStrip).Width - 1, ((Control)e.ToolStrip).Height - 1);
		Pen val = new Pen(Colors.LightBorder);
		try
		{
			graphics.DrawRectangle(val, rectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		Graphics graphics = ((ToolStripItemRenderEventArgs)e).Graphics;
		Rectangle rectangle = new Rectangle(e.ImageRectangle.Left - 2, e.ImageRectangle.Top - 2, e.ImageRectangle.Width + 4, e.ImageRectangle.Height + 4);
		SolidBrush val = new SolidBrush(Colors.LightBorder);
		try
		{
			graphics.FillRectangle((Brush)(object)val, rectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		Pen val2 = new Pen(Colors.BlueHighlight);
		try
		{
			Rectangle rectangle2 = new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width - 1, rectangle.Height - 1);
			graphics.DrawRectangle(val2, rectangle2);
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
		if (((ToolStripItemRenderEventArgs)e).Item.ImageIndex == -1 && string.IsNullOrEmpty(((ToolStripItemRenderEventArgs)e).Item.ImageKey) && ((ToolStripItemRenderEventArgs)e).Item.Image == null)
		{
			graphics.DrawImageUnscaled((Image)(object)MenuIcons.tick, new Point(e.ImageRectangle.Left, e.ImageRectangle.Top));
		}
	}

	protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		Graphics graphics = ((ToolStripItemRenderEventArgs)e).Graphics;
		Rectangle rectangle = new Rectangle(1, 3, ((ToolStripItemRenderEventArgs)e).Item.Width, 1);
		SolidBrush val = new SolidBrush(Colors.LightBorder);
		try
		{
			graphics.FillRectangle((Brush)(object)val, rectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
	{
		e.ArrowColor = Colors.LightText;
		e.ArrowRectangle = new Rectangle(new Point(e.ArrowRectangle.Left, e.ArrowRectangle.Top - 1), e.ArrowRectangle.Size);
		((ToolStripRenderer)this).OnRenderArrow(e);
	}

	protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		e.Item.ForeColor = ((!e.Item.Enabled) ? Colors.DisabledText : Colors.LightText);
		if (!e.Item.Enabled)
		{
			return;
		}
		Color obj = (e.Item.Selected ? Colors.GreyHighlight : e.Item.BackColor);
		Rectangle rectangle = new Rectangle(2, 0, e.Item.Width - 3, e.Item.Height);
		SolidBrush val = new SolidBrush(obj);
		try
		{
			graphics.FillRectangle((Brush)(object)val, rectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		if (((object)e.Item).GetType() == typeof(ToolStripMenuItem) && ((ToolStripDropDownItem)(ToolStripMenuItem)e.Item).DropDown.Visible && !e.Item.IsOnDropDown)
		{
			SolidBrush val2 = new SolidBrush(Colors.GreySelection);
			try
			{
				graphics.FillRectangle((Brush)(object)val2, rectangle);
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
	}

	static DarkMenuRenderer()
	{
		Class72.smethod_20();
	}
}
