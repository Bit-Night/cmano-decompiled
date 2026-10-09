using System;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;
using DarkUI.Extensions;

namespace DarkUI.Renderers;

public class DarkToolStripRenderer : DarkMenuRenderer
{
	protected override void InitializeItem(ToolStripItem item)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		base.InitializeItem(item);
		if (((object)item).GetType() == typeof(ToolStripSeparator) && !((ToolStripItem)(ToolStripSeparator)item).IsOnDropDown)
		{
			item.Margin = new Padding(0, 0, 2, 0);
		}
		if (((object)item).GetType() == typeof(ToolStripButton))
		{
			item.AutoSize = false;
			item.Size = new Size(24, 24);
		}
	}

	protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		base.OnRenderToolStripBackground(e);
		Graphics graphics = e.Graphics;
		if (((object)e.ToolStrip).GetType() == typeof(ToolStripOverflow))
		{
			Pen val = new Pen(Colors.GreyBackground);
			try
			{
				Rectangle rectangle = new Rectangle(e.AffectedBounds.Left, e.AffectedBounds.Top, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1);
				graphics.DrawRectangle(val, rectangle);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
	{
		if (((object)e.ToolStrip).GetType() != typeof(ToolStrip))
		{
			((ToolStripRenderer)this).OnRenderToolStripBorder(e);
		}
	}

	protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		Rectangle rectangle = new Rectangle(0, 1, e.Item.Width, e.Item.Height - 2);
		if (e.Item.Selected || e.Item.Pressed)
		{
			SolidBrush val = new SolidBrush(Colors.GreySelection);
			try
			{
				graphics.FillRectangle((Brush)(object)val, rectangle);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		if (!(((object)e.Item).GetType() == typeof(ToolStripButton)))
		{
			return;
		}
		ToolStripButton val2 = (ToolStripButton)e.Item;
		if (val2.Checked)
		{
			SolidBrush val3 = new SolidBrush(Colors.GreySelection);
			try
			{
				graphics.FillRectangle((Brush)(object)val3, rectangle);
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
		}
		if (val2.Checked && ((ToolStripItem)val2).Selected)
		{
			Rectangle rectangle2 = new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width - 1, rectangle.Height - 1);
			Pen val4 = new Pen(Colors.GreyHighlight);
			try
			{
				graphics.DrawRectangle(val4, rectangle2);
			}
			finally
			{
				((IDisposable)val4)?.Dispose();
			}
		}
	}

	protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		Rectangle rectangle = new Rectangle(0, 1, e.Item.Width, e.Item.Height - 2);
		if (e.Item.Selected || e.Item.Pressed)
		{
			SolidBrush val = new SolidBrush(Colors.GreySelection);
			try
			{
				graphics.FillRectangle((Brush)(object)val, rectangle);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	protected override void OnRenderGrip(ToolStripGripRenderEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.GripStyle != 0)
		{
			Graphics graphics = ((ToolStripRenderEventArgs)e).Graphics;
			Bitmap val = BitmapExtensions.SetColor(MenuIcons.grip, Colors.LightBorder);
			try
			{
				graphics.DrawImageUnscaled((Image)(object)val, new Point(((ToolStripRenderEventArgs)e).AffectedBounds.Left, ((ToolStripRenderEventArgs)e).AffectedBounds.Top));
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		Graphics graphics = ((ToolStripItemRenderEventArgs)e).Graphics;
		if (!((ToolStripItem)(ToolStripSeparator)((ToolStripItemRenderEventArgs)e).Item).IsOnDropDown)
		{
			Rectangle rectangle = new Rectangle(3, 3, 2, ((ToolStripItemRenderEventArgs)e).Item.Height - 4);
			Pen val = new Pen(Colors.DarkBorder);
			try
			{
				graphics.DrawLine(val, rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Height);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			Pen val2 = new Pen(Colors.LightBorder);
			try
			{
				graphics.DrawLine(val2, rectangle.Left + 1, rectangle.Top, rectangle.Left + 1, rectangle.Height);
				return;
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		base.OnRenderSeparator(e);
	}

	protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
	{
		Graphics graphics = ((ToolStripItemRenderEventArgs)e).Graphics;
		if (e.Image != null)
		{
			if (!((ToolStripItemRenderEventArgs)e).Item.Enabled)
			{
				ControlPaint.DrawImageDisabled(graphics, e.Image, e.ImageRectangle.Left, e.ImageRectangle.Top, Color.Transparent);
			}
			else
			{
				graphics.DrawImageUnscaled(e.Image, new Point(e.ImageRectangle.Left, e.ImageRectangle.Top));
			}
		}
	}

	protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
	{
	}

	static DarkToolStripRenderer()
	{
		Class72.smethod_20();
	}
}
