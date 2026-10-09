using System;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Controls;

public abstract class DarkScrollView : DarkScrollBase
{
	protected DarkScrollView()
	{
		((Control)this).SetStyle((ControlStyles)131090, true);
	}

	protected abstract void PaintContent(Graphics g);

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		SolidBrush val = new SolidBrush(((Control)this).BackColor);
		try
		{
			graphics.FillRectangle((Brush)(object)val, ((Control)this).ClientRectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		graphics.TranslateTransform((float)(base.Viewport.Left * -1), (float)(base.Viewport.Top * -1));
		PaintContent(graphics);
		graphics.TranslateTransform((float)base.Viewport.Left, (float)base.Viewport.Top);
		if (_vScrollBar.Visible && _hScrollBar.Visible)
		{
			SolidBrush val2 = new SolidBrush(((Control)this).BackColor);
			try
			{
				Rectangle rectangle = new Rectangle(((Control)_hScrollBar).Right, ((Control)_vScrollBar).Bottom, ((Control)_vScrollBar).Width, ((Control)_hScrollBar).Height);
				graphics.FillRectangle((Brush)(object)val2, rectangle);
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
	}

	static DarkScrollView()
	{
		Class72.smethod_20();
	}
}
