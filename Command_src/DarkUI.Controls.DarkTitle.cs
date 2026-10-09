using System;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkTitle : Label
{
	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		Rectangle rectangle = new Rectangle(0, 0, ((Control)this).ClientSize.Width, ((Control)this).ClientSize.Height);
		SizeF sizeF = graphics.MeasureString(((Control)this).Text, ((Control)this).Font);
		SolidBrush val = new SolidBrush(Colors.LightText);
		try
		{
			graphics.DrawString(((Control)this).Text, ((Control)this).Font, (Brush)(object)val, new PointF(-2f, 0f));
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		Pen val2 = new Pen(Colors.GreyHighlight);
		try
		{
			PointF pointF = new PointF(sizeF.Width + 5f, sizeF.Height / 2f);
			PointF pointF2 = new PointF(rectangle.Width, sizeF.Height / 2f);
			graphics.DrawLine(val2, pointF, pointF2);
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
	}

	static DarkTitle()
	{
		Class72.smethod_20();
	}
}
