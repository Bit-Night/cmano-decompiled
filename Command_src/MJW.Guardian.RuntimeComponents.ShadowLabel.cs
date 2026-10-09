using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MJW.Guardian.RuntimeComponents;

[ToolboxItem(true)]
public sealed class ShadowLabel : Label
{
	private bool bool_0 = true;

	private Color color_0 = Color.White;

	private Color color_1 = Color.LightSkyBlue;

	private float float_0;

	private bool bool_1 = true;

	private float float_1 = 1f;

	private float float_2 = 1f;

	private Color color_2 = Color.Black;

	private Container container_0;

	[DefaultValue(true)]
	[Description("Set to true to draw the gradient background")]
	[Category("Gradient")]
	public bool DrawGradient
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

	[DefaultValue(typeof(Color), "Color.White")]
	[Description("The start color of the gradient")]
	[Category("Gradient")]
	public Color StartColor
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

	[DefaultValue(typeof(Color), "Color.LightSkyBlue")]
	[Description("The end color of the gradient")]
	[Category("Gradient")]
	public Color EndColor
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
			((Control)this).Invalidate();
		}
	}

	[Description("The angle of the gradient")]
	[DefaultValue(0)]
	[Category("Gradient")]
	public float Angle
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			((Control)this).Invalidate();
		}
	}

	[Category("Drop Shadow")]
	[Description("Set to true to draw the Drop Shadow")]
	[DefaultValue(true)]
	public bool DrawShadow
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

	[Description("The X Offset used to draw the shadow")]
	[Category("Drop Shadow")]
	[DefaultValue(1)]
	public float XOffset
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
			((Control)this).Invalidate();
		}
	}

	[Description("The Y Offset used to draw the shadow")]
	[DefaultValue(1)]
	[Category("Drop Shadow")]
	public float YOffset
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
			((Control)this).Invalidate();
		}
	}

	[Description("The color used to draw the shadow")]
	[DefaultValue(typeof(Color), "Color.Black")]
	[Category("Drop Shadow")]
	public Color ShadowColor
	{
		get
		{
			return color_2;
		}
		set
		{
			color_2 = value;
			((Control)this).Invalidate();
		}
	}

	public ShadowLabel(IContainer container)
	{
		container.Add((IComponent?)(object)this);
		method_0();
	}

	public ShadowLabel()
	{
		method_0();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_0 != null)
		{
			container_0.Dispose();
		}
		((Label)this).Dispose(disposing);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		((Label)this).OnPaint(e);
		e.Graphics.SmoothingMode = (SmoothingMode)4;
		if (bool_0)
		{
			LinearGradientBrush val = new LinearGradientBrush(new Rectangle(0, 0, ((Control)this).Width, ((Control)this).Height), color_0, color_1, float_0, true);
			e.Graphics.FillRectangle((Brush)(object)val, 0, 0, ((Control)this).Width, ((Control)this).Height);
		}
		if (bool_1)
		{
			e.Graphics.DrawString(((Control)this).Text, ((Control)this).Font, (Brush)new SolidBrush(color_2), float_2, float_1, StringFormat.GenericDefault);
		}
		e.Graphics.DrawString(((Control)this).Text, ((Control)this).Font, (Brush)new SolidBrush(((Control)this).ForeColor), 0f, 0f, StringFormat.GenericDefault);
	}

	private void method_0()
	{
		container_0 = new Container();
		((Control)this).ForeColor = Color.LightSkyBlue;
	}

	static ShadowLabel()
	{
		Class72.smethod_20();
	}
}
