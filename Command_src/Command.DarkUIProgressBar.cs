using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DefaultProperty("Value")]
[DefaultEvent("ValueChanged")]
public sealed class DarkUIProgressBar : Control
{
	public delegate void ValueChangedEventHandler(object sender);

	private int int_0;

	private int int_1;

	private bool bool_0;

	[CompilerGenerated]
	private ValueChangedEventHandler valueChangedEventHandler_0;

	private bool bool_1;

	private bool bool_2;

	private Color color_0;

	[Category("Custom")]
	[Description("Gets or sets the current position of the progressbar.")]
	public int Value
	{
		get
		{
			if (int_1 < 0)
			{
				return 0;
			}
			return int_1;
		}
		set
		{
			if (value > Maximum)
			{
				value = Maximum;
			}
			int_1 = value;
			if (valueChangedEventHandler_0 != null)
			{
				valueChangedEventHandler_0?.Invoke(this);
			}
			((Control)this).Invalidate();
		}
	}

	[Category("Custom")]
	[Description("Gets or sets the maximum value of the progressbar.")]
	public int Maximum
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < int_1)
			{
				int_1 = value;
			}
			int_0 = value;
			((Control)this).Invalidate();
		}
	}

	[Description("Gets or sets the whether the progressbar line be shown or not.")]
	[Category("Custom")]
	public bool ShowProgressLines
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

	[Description("Gets or sets the whether the progressbar value be shown or not.")]
	[Category("Custom")]
	public bool ShowProgressValue
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			((Control)this).Invalidate();
		}
	}

	[Description("Gets or sets the color used to draw the bar. Set to 'Transparent' for default texture.")]
	[Category("Custom")]
	public Color CustomForeColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			((Control)this).Invalidate();
		}
	}

	[Description("Gets or sets whether to display the control's text.")]
	[Category("Custom")]
	public bool ShowText
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
			((Control)this).Invalidate();
		}
	}

	public event ValueChangedEventHandler ValueChanged
	{
		[CompilerGenerated]
		add
		{
			ValueChangedEventHandler valueChangedEventHandler = valueChangedEventHandler_0;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Combine(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref valueChangedEventHandler_0, value2, valueChangedEventHandler2);
			}
			while ((object)valueChangedEventHandler != valueChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ValueChangedEventHandler valueChangedEventHandler = valueChangedEventHandler_0;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Remove(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref valueChangedEventHandler_0, value2, valueChangedEventHandler2);
			}
			while ((object)valueChangedEventHandler != valueChangedEventHandler2);
		}
	}

	public DarkUIProgressBar()
	{
		int_0 = 100;
		int_1 = 0;
		bool_0 = true;
		bool_1 = true;
		bool_2 = false;
		color_0 = Color.Transparent;
		((Control)this).SetStyle((ControlStyles)141330, true);
		((Control)this).DoubleBuffered = true;
		((Control)this).BackColor = Color.Transparent;
		((Control)this).UpdateStyles();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		graphics.TextRenderingHint = (TextRenderingHint)5;
		GraphicsPath val = new GraphicsPath();
		int num = Convert.ToInt32((double)Value / (double)Maximum * (double)((Control)this).Width);
		Rectangle rectangle = new Rectangle(0, 0, ((Control)this).Width - 1, ((Control)this).Height - 1);
		LinearGradientBrush val2 = new LinearGradientBrush(rectangle, Color.FromArgb(29, 29, 29), Color.FromArgb(41, 41, 41), 90f);
		try
		{
			graphics.FillPath((Brush)(object)val2, HelperMethods.RoundRec(rectangle, 2));
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
		if (num != 0)
		{
			if (color_0 == Color.Transparent)
			{
				LinearGradientBrush val3 = new LinearGradientBrush(new Rectangle(rectangle.X, rectangle.Y, num - 1, rectangle.Height), Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f);
				try
				{
					Pen val4 = new Pen(Color.FromArgb(20, Color.White));
					try
					{
						graphics.FillPath((Brush)(object)val3, HelperMethods.RoundRec(new Rectangle(rectangle.X, rectangle.Y, num - 1, rectangle.Height), 2));
						Pen val5 = new Pen(Color.FromArgb(50, 50, 50), 20f);
						try
						{
							if (ShowProgressLines)
							{
								graphics.SmoothingMode = (SmoothingMode)4;
								int num2 = Convert.ToInt32((double)(((Control)this).Width - 20) * ((double)Value / (double)Maximum));
								for (int i = 9; i <= num2; i += 45)
								{
									graphics.DrawLine(val5, new Point(i, Convert.ToInt32(((Control)this).Height / 2 - ((Control)this).Height)), new Point(i - ((Control)this).Height, Convert.ToInt32(((Control)this).Height / 2 + ((Control)this).Height)));
								}
							}
						}
						finally
						{
							((IDisposable)val5)?.Dispose();
						}
						graphics.DrawLine(val4, rectangle.X, 1, num - 2, 1);
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
			else
			{
				SolidBrush val6 = new SolidBrush(color_0);
				try
				{
					graphics.FillPath((Brush)(object)val6, HelperMethods.RoundRec(new Rectangle(rectangle.X, rectangle.Y, num - 1, rectangle.Height), 2));
				}
				finally
				{
					((IDisposable)val6)?.Dispose();
				}
			}
		}
		SolidBrush val7 = new SolidBrush(((Control)this).ForeColor);
		try
		{
			if (ShowProgressValue)
			{
				graphics.DrawString(Conversions.ToString(Value) + "%", ((Control)this).Font, (Brush)(object)val7, (RectangleF)new Rectangle(0, 1, ((Control)this).Width, ((Control)this).Height), HelperMethods.SetPosition((StringAlignment)1, (StringAlignment)1));
			}
			if (ShowText && !string.IsNullOrEmpty(((Control)this).Text))
			{
				graphics.DrawString(((Control)this).Text, ((Control)this).Font, (Brush)(object)val7, (RectangleF)new Rectangle(0, 1, ((Control)this).Width, ((Control)this).Height), HelperMethods.SetPosition((StringAlignment)0, (StringAlignment)1));
			}
		}
		finally
		{
			((IDisposable)val7)?.Dispose();
		}
		Pen val8 = new Pen(Color.FromArgb(22, 22, 22));
		try
		{
			graphics.DrawPath(val8, HelperMethods.RoundRec(rectangle, 2));
		}
		finally
		{
			((IDisposable)val8)?.Dispose();
		}
		val.Dispose();
	}

	static DarkUIProgressBar()
	{
		Class72.smethod_20();
	}
}
