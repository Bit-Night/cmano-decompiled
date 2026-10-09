using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Forms;

public class DarkForm : Form
{
	private bool bool_0;

	[Category("Appearance")]
	[Description("Determines whether a single pixel border should be rendered around the form.")]
	[DefaultValue(false)]
	public bool FlatBorder
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			((Control)this).Invalidate();
		}
	}

	public void D_Scale(SizeF Ratio)
	{
		((Control)this).Scale(Ratio);
	}

	public DarkForm()
	{
		((Control)this).BackColor = Colors.GreyBackground;
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		((ScrollableControl)this).OnPaintBackground(e);
		if (!bool_0)
		{
			return;
		}
		Graphics graphics = e.Graphics;
		Pen val = new Pen(Colors.DarkBorder);
		try
		{
			Rectangle rectangle = new Rectangle(((Control)this).ClientRectangle.Location, new Size(((Control)this).ClientRectangle.Width - 1, ((Control)this).ClientRectangle.Height - 1));
			graphics.DrawRectangle(val, rectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	static DarkForm()
	{
		Class72.smethod_20();
	}
}
