using System;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkStatusStrip : StatusStrip
{
	public DarkStatusStrip()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		((Control)this).AutoSize = false;
		((ToolStrip)this).BackColor = Colors.GreyBackground;
		((ToolStrip)this).ForeColor = Colors.LightText;
		((StatusStrip)this).Padding = new Padding(0, 5, 0, 3);
		((Control)this).Size = new Size(((Control)this).Size.Width, 24);
		((StatusStrip)this).SizingGrip = false;
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
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
		Pen val2 = new Pen(Colors.DarkBorder);
		try
		{
			graphics.DrawLine(val2, ((Control)this).ClientRectangle.Left, 0, ((Control)this).ClientRectangle.Right, 0);
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
		Pen val3 = new Pen(Colors.LightBorder);
		try
		{
			graphics.DrawLine(val3, ((Control)this).ClientRectangle.Left, 1, ((Control)this).ClientRectangle.Right, 1);
		}
		finally
		{
			((IDisposable)val3)?.Dispose();
		}
	}

	static DarkStatusStrip()
	{
		Class72.smethod_20();
	}
}
