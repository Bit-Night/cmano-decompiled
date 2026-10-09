using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
public sealed class HelperMethods
{
	public enum MouseMode : byte
	{
		Normal,
		Hovered,
		Pushed,
		Disabled
	}

	public static void smethod_0(Graphics G, string string_0, Rectangle Rect)
	{
		Image val = null;
		Graphics val2 = G;
		using (MemoryTributary memoryTributary = new MemoryTributary(Convert.FromBase64String(string_0)))
		{
			val = Image.FromStream((Stream)memoryTributary);
			memoryTributary.Close();
		}
		val2.DrawImage(val, Rect);
		val2 = null;
	}

	public static void FillRoundedPath(Graphics G, Color C, Rectangle Rect, int Curve, bool TopLeft = true, bool TopRight = true, bool BottomLeft = true, bool BottomRight = true)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		G.FillPath((Brush)new SolidBrush(C), RoundRec(Rect, Curve, TopLeft, TopRight, BottomLeft, BottomRight));
	}

	public static void FillRoundedPath(Graphics G, Brush B, Rectangle Rect, int Curve, bool TopLeft = true, bool TopRight = true, bool BottomLeft = true, bool BottomRight = true)
	{
		G.FillPath(B, RoundRec(Rect, Curve, TopLeft, TopRight, BottomLeft, BottomRight));
	}

	public static void FillWithInnerRectangle(Graphics G, Color CenterColor, Color SurroundColor, Point P, Rectangle Rect, int Curve, bool TopLeft = true, bool TopRight = true, bool BottomLeft = true, bool BottomRight = true)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		PathGradientBrush val = new PathGradientBrush(RoundRec(Rect, Curve, TopLeft, TopRight, BottomLeft, BottomRight));
		try
		{
			PathGradientBrush val2 = val;
			val2.CenterColor = CenterColor;
			val2.SurroundColors = new Color[1] { SurroundColor };
			val2.FocusScales = P;
			GraphicsPath val3 = new GraphicsPath
			{
				FillMode = (FillMode)1
			};
			val3.AddRectangle(Rect);
			G.FillPath((Brush)(object)val, val3);
			val3.Dispose();
			val2 = null;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void FillWithInnerEllipse(Graphics G, Color CenterColor, Color SurroundColor, Point P, Rectangle Rect)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		GraphicsPath val = new GraphicsPath
		{
			FillMode = (FillMode)1
		};
		val.AddEllipse(Rect);
		PathGradientBrush val2 = new PathGradientBrush(val);
		try
		{
			PathGradientBrush val3 = val2;
			val3.CenterColor = CenterColor;
			val3.SurroundColors = new Color[1] { SurroundColor };
			val3.FocusScales = P;
			G.FillPath((Brush)(object)val2, val);
			val.Dispose();
			val3 = null;
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
	}

	public static void FillWithInnerRoundedPath(Graphics G, Color CenterColor, Color SurroundColor, Point P, Rectangle Rect, int Curve, bool TopLeft = true, bool TopRight = true, bool BottomLeft = true, bool BottomRight = true)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		PathGradientBrush val = new PathGradientBrush(RoundRec(Rect, Curve, TopLeft, TopRight, BottomLeft, BottomRight));
		try
		{
			PathGradientBrush val2 = val;
			val2.CenterColor = CenterColor;
			val2.SurroundColors = new Color[1] { SurroundColor };
			val2.FocusScales = P;
			G.FillPath((Brush)(object)val, RoundRec(Rect, Curve, TopLeft, TopRight, BottomLeft, BottomRight));
			val2 = null;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void DrawRoundedPath(Graphics G, Color C, float Size, Rectangle Rect, int Curve, bool TopLeft = true, bool TopRight = true, bool BottomLeft = true, bool BottomRight = true)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		G.DrawPath(new Pen(C, Size), RoundRec(Rect, Curve, TopLeft, TopRight, BottomLeft, BottomRight));
	}

	public static void DrawTriangle(Graphics G, Color C, int Size, Point P1, Point P2, Point P3, Point P4, Point P5, Point P6)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		G.DrawLine(new Pen(C, (float)Size), P1, P2);
		G.DrawLine(new Pen(C, (float)Size), P3, P4);
		G.DrawLine(new Pen(C, (float)Size), P5, P6);
	}

	public static void FillStrokedRectangle(Graphics G, Rectangle Rect, Color RectColor, Color StrokeColor, int StrokeSize = 1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		SolidBrush val = new SolidBrush(RectColor);
		try
		{
			Pen val2 = new Pen(StrokeColor, (float)StrokeSize);
			try
			{
				G.FillRectangle((Brush)(object)val, Rect);
				G.DrawRectangle(val2, Rect);
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

	public static void FillRoundedStrokedRectangle(Graphics G, Rectangle Rect, Color RectColor, Color StrokeColor, int StrokeSize = 1, int curve = 1, bool TopLeft = true, bool TopRight = true, bool BottomLeft = true, bool BottomRight = true)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		SolidBrush val = new SolidBrush(RectColor);
		try
		{
			FillRoundedPath(G, (Brush)(object)val, Rect, curve, TopLeft, TopRight, BottomLeft, BottomRight);
			DrawRoundedPath(G, StrokeColor, StrokeSize, Rect, curve, TopLeft, TopRight, BottomLeft, BottomRight);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void DrawImageWithColor(Graphics G, Rectangle R, Image _Image, Color C)
	{
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		float[][] array = new float[5][]
		{
			new float[5]
			{
				Convert.ToSingle((double)(int)C.R / 255.0),
				0f,
				0f,
				0f,
				0f
			},
			new float[5]
			{
				0f,
				Convert.ToSingle((double)(int)C.G / 255.0),
				0f,
				0f,
				0f
			},
			new float[5]
			{
				0f,
				0f,
				Convert.ToSingle((double)(int)C.B / 255.0),
				0f,
				0f
			},
			new float[5]
			{
				0f,
				0f,
				0f,
				Convert.ToSingle((double)(int)C.A / 255.0),
				0f
			},
			new float[5]
			{
				Convert.ToSingle((double)(int)C.R / 255.0),
				Convert.ToSingle((double)(int)C.G / 255.0),
				Convert.ToSingle((double)(int)C.B / 255.0),
				0f,
				Convert.ToSingle((double)(int)C.A / 255.0)
			}
		};
		ImageAttributes val = new ImageAttributes();
		val.SetColorMatrix(new ColorMatrix(array), (ColorMatrixFlag)0, (ColorAdjustType)0);
		G.DrawImage(_Image, R, 0, 0, _Image.Width, _Image.Height, (GraphicsUnit)2, val);
	}

	public static void DrawImageWithColor(Graphics G, Rectangle R, string _Image, Color C)
	{
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		Image val = ImageFromBase64(_Image);
		float[][] array = new float[5][]
		{
			new float[5]
			{
				Convert.ToSingle((double)(int)C.R / 255.0),
				0f,
				0f,
				0f,
				0f
			},
			new float[5]
			{
				0f,
				Convert.ToSingle((double)(int)C.G / 255.0),
				0f,
				0f,
				0f
			},
			new float[5]
			{
				0f,
				0f,
				Convert.ToSingle((double)(int)C.B / 255.0),
				0f,
				0f
			},
			new float[5]
			{
				0f,
				0f,
				0f,
				Convert.ToSingle((double)(int)C.A / 255.0),
				0f
			},
			new float[5]
			{
				Convert.ToSingle((double)(int)C.R / 255.0),
				Convert.ToSingle((double)(int)C.G / 255.0),
				Convert.ToSingle((double)(int)C.B / 255.0),
				0f,
				Convert.ToSingle((double)(int)C.A / 255.0)
			}
		};
		ImageAttributes val2 = new ImageAttributes();
		val2.SetColorMatrix(new ColorMatrix(array), (ColorMatrixFlag)0, (ColorAdjustType)0);
		G.DrawImage(val, R, 0, 0, val.Width, val.Height, (GraphicsUnit)2, val2);
	}

	public static Point[] Triangle(Point P1, Point P2, Point P3)
	{
		return new Point[3] { P1, P2, P3 };
	}

	public static PathGradientBrush GlowBrush(Color CenterColor, Color SurroundColor, Point P, Rectangle Rect)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		GraphicsPath val = new GraphicsPath
		{
			FillMode = (FillMode)1
		};
		val.AddRectangle(Rect);
		PathGradientBrush val2 = new PathGradientBrush(val);
		val2.CenterColor = CenterColor;
		val2.SurroundColors = new Color[1] { SurroundColor };
		val2.FocusScales = P;
		return val2;
	}

	public static SolidBrush smethod_1(int R, int G, int B, int A = 0)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		return new SolidBrush(Color.FromArgb(A, R, G, B));
	}

	public static SolidBrush smethod_2(string C_WithoutHash)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		return new SolidBrush(GetHTMLColor(C_WithoutHash));
	}

	public static Pen smethod_3(int R, int G, int B, int A, float Size)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		return new Pen(Color.FromArgb(A, R, G, B), Size);
	}

	public static Pen PenHTMlColor(string C_WithoutHash, float Size = 1f)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		return new Pen(GetHTMLColor(C_WithoutHash), Size);
	}

	public static Color GetHTMLColor(string C_WithoutHash)
	{
		return ColorTranslator.FromHtml("#" + C_WithoutHash);
	}

	public static Color GetAlphaHTMLColor(int alpha, string C_WithoutHash)
	{
		return Color.FromArgb(alpha, ColorTranslator.FromHtml("#" + C_WithoutHash));
	}

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

	public static float[][] ColorToMatrix(Color C)
	{
		return new float[5][]
		{
			new float[5]
			{
				Convert.ToSingle((double)(int)C.R / 255.0),
				0f,
				0f,
				0f,
				0f
			},
			new float[5]
			{
				0f,
				Convert.ToSingle((double)(int)C.G / 255.0),
				0f,
				0f,
				0f
			},
			new float[5]
			{
				0f,
				0f,
				Convert.ToSingle((double)(int)C.B / 255.0),
				0f,
				0f
			},
			new float[5]
			{
				0f,
				0f,
				0f,
				Convert.ToSingle((double)(int)C.A / 255.0),
				0f
			},
			new float[5]
			{
				Convert.ToSingle((double)(int)C.R / 255.0),
				Convert.ToSingle((double)(int)C.G / 255.0),
				Convert.ToSingle((double)(int)C.B / 255.0),
				0f,
				Convert.ToSingle((double)(int)C.A / 255.0)
			}
		};
	}

	public static Image ImageFromBase64(string string_0)
	{
		using MemoryTributary memoryTributary = new MemoryTributary(Convert.FromBase64String(string_0));
		return Image.FromStream((Stream)memoryTributary);
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
		if (!TopRight)
		{
			val.AddLine(r.Right - r.Width, r.Y, r.Width, r.Y);
		}
		else
		{
			val.AddArc(r.Right - Curve, r.Y, Curve, Curve, 270f, 90f);
		}
		if (BottomRight)
		{
			val.AddArc(r.Right - Curve, r.Bottom - Curve, Curve, Curve, 0f, 90f);
		}
		else
		{
			val.AddLine(r.Right, r.Bottom, r.Right, r.Bottom);
		}
		if (BottomLeft)
		{
			val.AddArc(r.X, r.Bottom - Curve, Curve, Curve, 90f, 90f);
		}
		else
		{
			val.AddLine(r.X, r.Bottom, r.X, r.Bottom);
		}
		val.CloseFigure();
		return val;
	}

	static HelperMethods()
	{
		Class72.smethod_20();
	}
}
