using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using DarkUI.Config;

namespace DarkUI.Controls;

public class DarkNumericUpDown : NumericUpDown
{
	public static StringFormat SetPosition(StringAlignment Horizontal = (StringAlignment)1, StringAlignment Vertical = (StringAlignment)1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		return new StringFormat
		{
			Alignment = Horizontal,
			LineAlignment = Vertical
		};
	}

	public static GraphicsPath RoundRec(Rectangle r, int Curve, bool TopLeft = true, bool TopRight = true, bool BottomLeft = true, bool BottomRight = true)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		GraphicsPath val = new GraphicsPath((FillMode)1);
		if (!TopLeft)
		{
			val.AddLine(r.X, r.Y, r.X, r.Y);
		}
		else
		{
			val.AddArc(r.X, r.Y, Curve, Curve, 180f, 90f);
		}
		if (TopRight)
		{
			val.AddArc(r.Right - Curve, r.Y, Curve, Curve, 270f, 90f);
		}
		else
		{
			val.AddLine(r.Right - r.Width, r.Y, r.Width, r.Y);
		}
		if (!BottomRight)
		{
			val.AddLine(r.Right, r.Bottom, r.Right, r.Bottom);
		}
		else
		{
			val.AddArc(r.Right - Curve, r.Bottom - Curve, Curve, Curve, 0f, 90f);
		}
		if (!BottomLeft)
		{
			val.AddLine(r.X, r.Bottom, r.X, r.Bottom);
		}
		else
		{
			val.AddArc(r.X, r.Bottom - Curve, Curve, Curve, 90f, 90f);
		}
		val.CloseFigure();
		return val;
	}

	public DarkNumericUpDown()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		((Control)this).BackColor = Colors.LightBackground;
		((Control)this).ForeColor = Colors.LightText;
		((NumericUpDown)this).Padding = new Padding(2, 2, 2, 2);
		((UpDownBase)this).BorderStyle = (BorderStyle)0;
		((Control)this).BackColor = Colors.DarkBackground;
		foreach (Control item in (ArrangedElementCollection)((Control)this).Controls)
		{
			Control control_0 = item;
			if (control_0 is TextBox)
			{
				continue;
			}
			typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty, null, control_0, new object[1] { true });
			control_0.Paint += (PaintEventHandler)delegate(object sender, PaintEventArgs e)
			{
				//IL_0051: Unknown result type (might be due to invalid IL or missing references)
				//IL_0058: Expected O, but got Unknown
				//IL_0074: Unknown result type (might be due to invalid IL or missing references)
				//IL_007b: Expected O, but got Unknown
				//IL_0086: Unknown result type (might be due to invalid IL or missing references)
				//IL_008d: Expected O, but got Unknown
				//IL_0099: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a0: Expected O, but got Unknown
				//IL_0158: Unknown result type (might be due to invalid IL or missing references)
				//IL_015f: Expected O, but got Unknown
				//IL_019d: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a4: Expected O, but got Unknown
				//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
				//IL_01fb: Expected O, but got Unknown
				//IL_0239: Unknown result type (might be due to invalid IL or missing references)
				//IL_0240: Expected O, but got Unknown
				//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
				//IL_02b4: Expected O, but got Unknown
				//IL_030d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0314: Expected O, but got Unknown
				_ = e.Graphics;
				int height = control_0.Height;
				int width = control_0.Width;
				width -= 2;
				Graphics graphics = e.Graphics;
				graphics.Clear(Color.Transparent);
				Rectangle rectangle = new Rectangle(0, 0, width, height);
				width += 5;
				SolidBrush val = new SolidBrush(Color.FromArgb(31, 31, 31));
				try
				{
					LinearGradientBrush val2 = new LinearGradientBrush(rectangle, Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f);
					try
					{
						Pen val3 = new Pen(Color.FromArgb(22, 22, 22));
						try
						{
							Pen val4 = new Pen(Color.FromArgb(20, Color.White));
							try
							{
								graphics.FillRectangle((Brush)(object)val, rectangle);
								graphics.FillPath((Brush)(object)val2, RoundRec(new Rectangle(width - 25, 0, 24, height - 1), 2));
								graphics.DrawLine(val3, new Point(width - 25, 1), new Point(width - 25, height - 2));
								graphics.DrawLine(val3, new Point(width - 25, 13), new Point(width - 1, 13));
								graphics.DrawLine(val4, width - 24, 1, width - 24 + width, 1);
							}
							finally
							{
								((IDisposable)val4)?.Dispose();
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
				graphics.SmoothingMode = (SmoothingMode)4;
				GraphicsPath val5 = new GraphicsPath();
				try
				{
					SolidBrush val6 = new SolidBrush((((NumericUpDown)this).Value != ((NumericUpDown)this).Maximum) ? Color.FromArgb(192, 192, 192) : Color.FromArgb(22, 22, 22));
					try
					{
						val5.AddLine(width - 17, 9, width - 2, 9);
						val5.AddLine(width - 9, 9, width - 13, 4);
						val5.CloseFigure();
						graphics.FillPath((Brush)(object)val6, val5);
					}
					finally
					{
						((IDisposable)val6)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val5)?.Dispose();
				}
				GraphicsPath val7 = new GraphicsPath();
				try
				{
					SolidBrush val8 = new SolidBrush((((NumericUpDown)this).Value > ((NumericUpDown)this).Minimum) ? Color.FromArgb(192, 192, 192) : Color.FromArgb(22, 22, 22));
					try
					{
						val7.AddLine(width - 17, 17, width - 2, 17);
						val7.AddLine(width - 9, 17, width - 13, 22);
						val7.CloseFigure();
						graphics.FillPath((Brush)(object)val8, val7);
					}
					finally
					{
						((IDisposable)val8)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val7)?.Dispose();
				}
				graphics.SmoothingMode = (SmoothingMode)0;
				SolidBrush val9 = new SolidBrush(Color.FromArgb(207, 207, 207));
				try
				{
					graphics.DrawString(((NumericUpDown)this).Value.ToString(), ((Control)this).Font, (Brush)(object)val9, (RectangleF)new Rectangle(0, 0, width - 18, height), SetPosition((StringAlignment)1, (StringAlignment)1));
				}
				finally
				{
					((IDisposable)val9)?.Dispose();
				}
				Pen val10 = new Pen(Color.FromArgb(22, 22, 22));
				try
				{
					graphics.DrawRectangle(val10, rectangle);
				}
				finally
				{
					((IDisposable)val10)?.Dispose();
				}
			};
		}
	}

	static DarkNumericUpDown()
	{
		Class72.smethod_20();
	}
}
