using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Config;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DefaultEvent("SelectedIndexChanged")]
public sealed class DarkUIComboBox : ComboBox
{
	private StringFormat stringFormat_0;

	private Font font_0;

	public DarkUIComboBox()
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((Control)this).SetStyle((ControlStyles)141330, true);
		((ComboBox)this).BackColor = Color.Transparent;
		((ComboBox)this).DrawMode = (DrawMode)1;
		((Control)this).DoubleBuffered = true;
		((ComboBox)this).DropDownStyle = (ComboBoxStyle)2;
		((Control)this).Font = new Font(Client.CommandDefaultFont.FontFamily, 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		stringFormat_0 = new StringFormat((StringFormatFlags)4096, 0);
		((Control)this).UpdateStyles();
	}

	protected override void OnDrawItem(DrawItemEventArgs e)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		graphics.TextRenderingHint = (TextRenderingHint)5;
		try
		{
			LinearGradientBrush val = new LinearGradientBrush(e.Graphics.ClipBounds, Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f);
			try
			{
				SolidBrush val2 = new SolidBrush(((e.State & 1) != 0) ? Color.White : Color.FromArgb(189, 189, 189));
				try
				{
					Font val3 = new Font(((Control)this).Font.Name, ((Control)this).Font.Size + 2f);
					try
					{
						graphics.FillRectangle((Brush)(object)val, e.Bounds);
						if (e.Index != -1)
						{
							graphics.DrawString(((ListControl)this).GetItemText(RuntimeHelpers.GetObjectValue(((ComboBox)this).Items[e.Index])), val3, (Brush)(object)val2, (RectangleF)e.Bounds, HelperMethods.SetPosition((StringAlignment)0, (StringAlignment)1));
						}
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	protected void AlternateOnPaint(PaintEventArgs e)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		graphics.TextRenderingHint = (TextRenderingHint)5;
		SolidBrush val = new SolidBrush(Colors.MediumBackground);
		try
		{
			graphics.FillRectangle((Brush)(object)val, ((Control)this).ClientRectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		Pen val2 = new Pen(Colors.LightBorder, 1f);
		try
		{
			Rectangle rectangle = new Rectangle(((Control)this).ClientRectangle.Left, ((Control)this).ClientRectangle.Top, ((Control)this).ClientRectangle.Width - 1, ((Control)this).ClientRectangle.Height - 1);
			graphics.DrawRectangle(val2, rectangle);
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
		HelperMethods.DrawTriangle(graphics, Color.FromArgb(192, 192, 192), 2, new Point(((Control)this).Width - 20, 10), new Point(((Control)this).Width - 16, 14), new Point(((Control)this).Width - 16, 14), new Point(((Control)this).Width - 12, 10), new Point(((Control)this).Width - 16, 15), new Point(((Control)this).Width - 16, 14));
		if (((ComboBox)this).SelectedItem == null)
		{
			return;
		}
		SolidBrush val3 = new SolidBrush(Colors.LightText);
		try
		{
			if (font_0 == null)
			{
				font_0 = new Font(((Control)this).Font.Name, ((Control)this).Font.Size + 2f);
			}
			Rectangle rectangle2 = new Rectangle(((Control)this).ClientRectangle.Left + 2, ((Control)this).ClientRectangle.Top, ((Control)this).ClientRectangle.Width - 16, ((Control)this).ClientRectangle.Height);
			graphics.SmoothingMode = (SmoothingMode)4;
			graphics.DrawString(((ComboBox)this).Text, font_0, (Brush)(object)val3, (RectangleF)rectangle2, stringFormat_0);
		}
		finally
		{
			((IDisposable)val3)?.Dispose();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		AlternateOnPaint(e);
	}

	static DarkUIComboBox()
	{
		Class72.smethod_20();
	}
}
