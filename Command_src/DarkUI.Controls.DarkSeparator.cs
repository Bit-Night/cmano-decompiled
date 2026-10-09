using System;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkSeparator : Control
{
	public DarkSeparator()
	{
		((Control)this).SetStyle((ControlStyles)512, false);
		((Control)this).Dock = (DockStyle)1;
		((Control)this).Size = new Size(1, 2);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		Pen val = new Pen(Colors.DarkBorder);
		try
		{
			graphics.DrawLine(val, ((Control)this).ClientRectangle.Left, 0, ((Control)this).ClientRectangle.Right, 0);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		Pen val2 = new Pen(Colors.LightBorder);
		try
		{
			graphics.DrawLine(val2, ((Control)this).ClientRectangle.Left, 1, ((Control)this).ClientRectangle.Right, 1);
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
	}

	static DarkSeparator()
	{
		Class72.smethod_20();
	}
}
