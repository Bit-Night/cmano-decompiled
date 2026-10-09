using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkSectionPanel : Panel
{
	private string string_0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding Padding => ((Control)this).Padding;

	[Description("The section header text associated with this control.")]
	[Category("Appearance")]
	public string SectionHeader
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			((Control)this).Invalidate();
		}
	}

	public DarkSectionPanel()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		((Control)this).SetStyle((ControlStyles)131090, true);
		((Control)this).Padding = new Padding(1, 25, 1, 1);
	}

	protected override void OnEnter(EventArgs e)
	{
		((Control)this).OnEnter(e);
		((Control)this).Invalidate();
	}

	protected override void OnLeave(EventArgs e)
	{
		((Control)this).OnLeave(e);
		((Control)this).Invalidate();
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		((Control)this).OnMouseDown(e);
		if (((ArrangedElementCollection)((Control)this).Controls).Count > 0)
		{
			((Control)this).Controls[0].Focus();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected O, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		Rectangle clientRectangle = ((Control)this).ClientRectangle;
		SolidBrush val = new SolidBrush(Colors.GreyBackground);
		try
		{
			graphics.FillRectangle((Brush)(object)val, clientRectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		Color obj = (((Control)this).ContainsFocus ? Colors.BlueBackground : Colors.HeaderBackground);
		Color color = ((!((Control)this).ContainsFocus) ? Colors.DarkBorder : Colors.DarkBlueBorder);
		Color color2 = ((!((Control)this).ContainsFocus) ? Colors.LightBorder : Colors.LightBlueBorder);
		SolidBrush val2 = new SolidBrush(obj);
		try
		{
			Rectangle rectangle = new Rectangle(0, 0, clientRectangle.Width, 25);
			graphics.FillRectangle((Brush)(object)val2, rectangle);
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
		Pen val3 = new Pen(color);
		try
		{
			graphics.DrawLine(val3, clientRectangle.Left, 0, clientRectangle.Right, 0);
			graphics.DrawLine(val3, clientRectangle.Left, 24, clientRectangle.Right, 24);
		}
		finally
		{
			((IDisposable)val3)?.Dispose();
		}
		Pen val4 = new Pen(color2);
		try
		{
			graphics.DrawLine(val4, clientRectangle.Left, 1, clientRectangle.Right, 1);
		}
		finally
		{
			((IDisposable)val4)?.Dispose();
		}
		int num = 3;
		SolidBrush val5 = new SolidBrush(Colors.LightText);
		try
		{
			Rectangle rectangle2 = new Rectangle(num, 0, clientRectangle.Width - 4 - num, 25);
			StringFormat val6 = new StringFormat
			{
				Alignment = (StringAlignment)0,
				LineAlignment = (StringAlignment)1,
				FormatFlags = (StringFormatFlags)4096,
				Trimming = (StringTrimming)3
			};
			graphics.DrawString(SectionHeader, ((Control)this).Font, (Brush)(object)val5, (RectangleF)rectangle2, val6);
		}
		finally
		{
			((IDisposable)val5)?.Dispose();
		}
		Pen val7 = new Pen(Colors.DarkBorder, 1f);
		try
		{
			Rectangle rectangle3 = new Rectangle(clientRectangle.Left, clientRectangle.Top, clientRectangle.Width - 1, clientRectangle.Height - 1);
			graphics.DrawRectangle(val7, rectangle3);
		}
		finally
		{
			((IDisposable)val7)?.Dispose();
		}
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
	}

	static DarkSectionPanel()
	{
		Class72.smethod_20();
	}
}
