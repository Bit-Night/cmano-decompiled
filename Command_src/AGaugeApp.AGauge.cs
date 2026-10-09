using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CSMaterial;

namespace AGaugeApp;

[DefaultEvent("ValueInRangeChanged")]
[Description("Displays a value on an analog gauge. Raises an event if the value enters one of the definable ranges.")]
[ToolboxBitmap(typeof(AGauge), "AGauge.bmp")]
public class AGauge : Control
{
	public enum NeedleColorEnum
	{
		Gray,
		Red,
		Green,
		Blue,
		Yellow,
		Violet,
		Magenta
	}

	public sealed class ValueInRangeChangedEventArgs : EventArgs
	{
		public int valueInRange;

		public ValueInRangeChangedEventArgs(int valueInRange)
		{
			this.valueInRange = valueInRange;
		}

		static ValueInRangeChangedEventArgs()
		{
			Class72.smethod_20();
		}
	}

	public delegate void ValueInRangeChangedDelegate(object sender, ValueInRangeChangedEventArgs e);

	private float float_0;

	private float float_1;

	private Bitmap bitmap_0;

	private bool ynKyTqoQcBd = true;

	private float float_2;

	private bool[] bool_0 = new bool[5];

	private byte byte_0 = 1;

	private Color[] color_0 = new Color[5]
	{
		Color.Black,
		Color.Black,
		Color.Black,
		Color.Black,
		Color.Black
	};

	private string[] string_0 = new string[5] { "", "", "", "", "" };

	private Point[] point_0 = new Point[5]
	{
		new Point(10, 10),
		new Point(10, 10),
		new Point(10, 10),
		new Point(10, 10),
		new Point(10, 10)
	};

	private Point point_1 = new Point(100, 100);

	private float float_3 = -100f;

	private float float_4 = 400f;

	private Color color_1 = Color.Gray;

	private int int_0 = 80;

	private int int_1 = 135;

	private int int_2 = 270;

	private int int_3 = 2;

	private Color color_2 = Color.Black;

	private int int_4 = 73;

	private int int_5 = 80;

	private int YfqyTvUjseJ = 1;

	private int int_6 = 9;

	private Color color_3 = Color.Gray;

	private int int_7 = 75;

	private int int_8 = 80;

	private int int_9 = 1;

	private float float_5 = 50f;

	private Color color_4 = Color.Black;

	private int int_10 = 70;

	private int int_11 = 80;

	private int int_12 = 2;

	private byte byte_1;

	private bool[] bool_1 = new bool[5] { true, true, false, false, false };

	private Color[] color_5 = new Color[5]
	{
		Color.LightGreen,
		Color.Red,
		Color.FromKnownColor(KnownColor.Control),
		Color.FromKnownColor(KnownColor.Control),
		Color.FromKnownColor(KnownColor.Control)
	};

	private float[] float_6 = new float[5] { -100f, 300f, 0f, 0f, 0f };

	private float[] float_7 = new float[5] { 300f, 400f, 0f, 0f, 0f };

	private int[] int_13 = new int[5] { 70, 70, 70, 70, 70 };

	private int[] int_14 = new int[5] { 80, 80, 80, 80, 80 };

	private int int_15 = 95;

	private Color color_6 = Color.Black;

	private string string_1;

	private int int_16;

	private int int_17 = 1;

	private int int_18;

	private int int_19;

	private int int_20 = 80;

	private NeedleColorEnum needleColorEnum_0;

	private Color color_7 = Color.DimGray;

	private int int_21 = 2;

	[CompilerGenerated]
	private ValueInRangeChangedDelegate valueInRangeChangedDelegate_0;

	private IContainer icontainer_0;

	public bool AllowDrop
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool AutoSize
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool ForeColor
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool ImeMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override Color BackColor
	{
		get
		{
			return ((Control)this).BackColor;
		}
		set
		{
			((Control)this).BackColor = value;
			ynKyTqoQcBd = true;
			((Control)this).Refresh();
		}
	}

	public override Font Font
	{
		get
		{
			return ((Control)this).Font;
		}
		set
		{
			((Control)this).Font = value;
			ynKyTqoQcBd = true;
			((Control)this).Refresh();
		}
	}

	public override ImageLayout BackgroundImageLayout
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return ((Control)this).BackgroundImageLayout;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			((Control)this).BackgroundImageLayout = value;
			ynKyTqoQcBd = true;
			((Control)this).Refresh();
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The value.")]
	public float Value
	{
		get
		{
			return float_2;
		}
		set
		{
			if (float_2 == value)
			{
				return;
			}
			float_2 = Math.Min(Math.Max(value, float_3), float_4);
			int num;
			if (((Component)this).DesignMode)
			{
				ynKyTqoQcBd = true;
				num = 0;
			}
			else
			{
				num = 0;
			}
			for (int i = num; i < 4; i++)
			{
				if (float_6[i] <= float_2 && float_2 <= float_7[i] && bool_1[i])
				{
					if (!bool_0[i] && valueInRangeChangedDelegate_0 != null)
					{
						valueInRangeChangedDelegate_0(this, new ValueInRangeChangedEventArgs(i));
					}
				}
				else
				{
					bool_0[i] = false;
				}
			}
			((Control)this).Refresh();
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The caption index. set this to a value of 0 up to 4 to change the corresponding caption's properties.")]
	[RefreshProperties(RefreshProperties.All)]
	public byte Cap_Idx
	{
		get
		{
			return byte_0;
		}
		set
		{
			if (byte_0 != value && 0 <= value && value < 5)
			{
				byte_0 = value;
			}
		}
	}

	[Category("AGauge")]
	[Browsable(true)]
	[Description("The color of the caption text.")]
	private Color hyTyTQJYnhL
	{
		get
		{
			return color_0[byte_0];
		}
		set
		{
			if (color_0[byte_0] != value)
			{
				color_0[byte_0] = value;
				CapColors = color_0;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(false)]
	public Color[] CapColors
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The text of the caption.")]
	public string CapText
	{
		get
		{
			return string_0[byte_0];
		}
		set
		{
			if (string_0[byte_0] != value)
			{
				string_0[byte_0] = value;
				CapsText = string_0;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(false)]
	public string[] CapsText
	{
		get
		{
			return string_0;
		}
		set
		{
			for (int i = 0; i < 5; i++)
			{
				string_0[i] = value[i];
			}
		}
	}

	[Browsable(true)]
	[Description("The position of the caption.")]
	[Category("AGauge")]
	public Point CapPosition
	{
		get
		{
			return point_0[byte_0];
		}
		set
		{
			if (point_0[byte_0] != value)
			{
				point_0[byte_0] = value;
				CapsPosition = point_0;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(false)]
	public Point[] CapsPosition
	{
		get
		{
			return point_0;
		}
		set
		{
			point_0 = value;
		}
	}

	[Category("AGauge")]
	[Browsable(true)]
	[Description("The center of the gauge (in the control's client area).")]
	public Point Center
	{
		get
		{
			return point_1;
		}
		set
		{
			if (point_1 != value)
			{
				point_1 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The minimum value to show on the scale.")]
	public float MinValue
	{
		get
		{
			return float_3;
		}
		set
		{
			if (float_3 != value && value < float_4)
			{
				float_3 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Browsable(true)]
	[Description("The maximum value to show on the scale.")]
	public float MaxValue
	{
		get
		{
			return float_4;
		}
		set
		{
			if (float_4 != value && value > float_3)
			{
				float_4 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Description("The color of the base arc.")]
	[Category("AGauge")]
	[Browsable(true)]
	public Color BaseArcColor
	{
		get
		{
			return color_1;
		}
		set
		{
			if (color_1 != value)
			{
				color_1 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Description("The radius of the base arc.")]
	[Browsable(true)]
	[Category("AGauge")]
	public int BaseArcRadius
	{
		get
		{
			return int_0;
		}
		set
		{
			if (int_0 != value)
			{
				int_0 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The start angle of the base arc.")]
	public int BaseArcStart
	{
		get
		{
			return int_1;
		}
		set
		{
			if (int_1 != value)
			{
				int_1 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The sweep angle of the base arc.")]
	public int BaseArcSweep
	{
		get
		{
			return int_2;
		}
		set
		{
			if (int_2 != value)
			{
				int_2 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The width of the base arc.")]
	public int BaseArcWidth
	{
		get
		{
			return int_3;
		}
		set
		{
			if (int_3 != value)
			{
				int_3 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The color of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
	public Color ScaleLinesInterColor
	{
		get
		{
			return color_2;
		}
		set
		{
			if (color_2 != value)
			{
				color_2 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Description("The inner radius of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
	[Category("AGauge")]
	[Browsable(true)]
	public int ScaleLinesInterInnerRadius
	{
		get
		{
			return int_4;
		}
		set
		{
			if (int_4 != value)
			{
				int_4 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Description("The outer radius of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
	[Browsable(true)]
	public int ScaleLinesInterOuterRadius
	{
		get
		{
			return int_5;
		}
		set
		{
			if (int_5 != value)
			{
				int_5 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The width of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
	public int ScaleLinesInterWidth
	{
		get
		{
			return YfqyTvUjseJ;
		}
		set
		{
			if (YfqyTvUjseJ != value)
			{
				YfqyTvUjseJ = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Description("The number of minor scale lines.")]
	[Browsable(true)]
	[Category("AGauge")]
	public int ScaleLinesMinorNumOf
	{
		get
		{
			return int_6;
		}
		set
		{
			if (int_6 != value)
			{
				int_6 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Description("The color of the minor scale lines.")]
	[Category("AGauge")]
	[Browsable(true)]
	public Color ScaleLinesMinorColor
	{
		get
		{
			return color_3;
		}
		set
		{
			if (color_3 != value)
			{
				color_3 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Description("The inner radius of the minor scale lines.")]
	[Category("AGauge")]
	[Browsable(true)]
	public int ScaleLinesMinorInnerRadius
	{
		get
		{
			return int_7;
		}
		set
		{
			if (int_7 != value)
			{
				int_7 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Description("The outer radius of the minor scale lines.")]
	[Browsable(true)]
	public int ScaleLinesMinorOuterRadius
	{
		get
		{
			return int_8;
		}
		set
		{
			if (int_8 != value)
			{
				int_8 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(true)]
	[Description("The width of the minor scale lines.")]
	[Category("AGauge")]
	public int ScaleLinesMinorWidth
	{
		get
		{
			return int_9;
		}
		set
		{
			if (int_9 != value)
			{
				int_9 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Description("The step value of the major scale lines.")]
	[Category("AGauge")]
	[Browsable(true)]
	public float ScaleLinesMajorStepValue
	{
		get
		{
			return float_5;
		}
		set
		{
			if (value > 0f)
			{
				float_5 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Browsable(true)]
	[Description("The color of the major scale lines.")]
	public Color ScaleLinesMajorColor
	{
		get
		{
			return color_4;
		}
		set
		{
			if (color_4 != value)
			{
				color_4 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Description("The inner radius of the major scale lines.")]
	[Browsable(true)]
	public int ScaleLinesMajorInnerRadius
	{
		get
		{
			return int_10;
		}
		set
		{
			if (int_10 != value)
			{
				int_10 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(true)]
	[Description("The outer radius of the major scale lines.")]
	[Category("AGauge")]
	public int ScaleLinesMajorOuterRadius
	{
		get
		{
			return int_11;
		}
		set
		{
			if (int_11 != value)
			{
				int_11 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Description("The width of the major scale lines.")]
	[Browsable(true)]
	[Category("AGauge")]
	public int ScaleLinesMajorWidth
	{
		get
		{
			return int_12;
		}
		set
		{
			if (int_12 != value)
			{
				int_12 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(true)]
	[Description("The range index. set this to a value of 0 up to 4 to change the corresponding range's properties.")]
	[Category("AGauge")]
	[RefreshProperties(RefreshProperties.All)]
	public byte Range_Idx
	{
		get
		{
			return byte_1;
		}
		set
		{
			if (byte_1 != value && 0 <= value && value < 5)
			{
				byte_1 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Description("Enables or disables the range selected by Range_Idx.")]
	[Category("AGauge")]
	[Browsable(true)]
	public bool RangeEnabled
	{
		get
		{
			return bool_1[byte_1];
		}
		set
		{
			if (bool_1[byte_1] != value)
			{
				bool_1[byte_1] = value;
				RangesEnabled = bool_1;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(false)]
	public bool[] RangesEnabled
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The color of the range.")]
	public Color RangeColor
	{
		get
		{
			return color_5[byte_1];
		}
		set
		{
			if (color_5[byte_1] != value)
			{
				color_5[byte_1] = value;
				RangesColor = color_5;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(false)]
	public Color[] RangesColor
	{
		get
		{
			return color_5;
		}
		set
		{
			color_5 = value;
		}
	}

	[Category("AGauge")]
	[Description("The start value of the range, must be less than RangeEndValue.")]
	[Browsable(true)]
	public float RangeStartValue
	{
		get
		{
			return float_6[byte_1];
		}
		set
		{
			if (float_6[byte_1] != value && value < float_7[byte_1])
			{
				float_6[byte_1] = value;
				RangesStartValue = float_6;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(false)]
	public float[] RangesStartValue
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = value;
		}
	}

	[Description("The end value of the range. Must be greater than RangeStartValue.")]
	[Category("AGauge")]
	[Browsable(true)]
	public float RangeEndValue
	{
		get
		{
			return float_7[byte_1];
		}
		set
		{
			if (float_7[byte_1] != value && float_6[byte_1] < value)
			{
				float_7[byte_1] = value;
				RangesEndValue = float_7;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(false)]
	public float[] RangesEndValue
	{
		get
		{
			return float_7;
		}
		set
		{
			float_7 = value;
		}
	}

	[Description("The inner radius of the range.")]
	[Category("AGauge")]
	[Browsable(true)]
	public int RangeInnerRadius
	{
		get
		{
			return int_13[byte_1];
		}
		set
		{
			if (int_13[byte_1] != value)
			{
				int_13[byte_1] = value;
				RangesInnerRadius = int_13;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(false)]
	public int[] RangesInnerRadius
	{
		get
		{
			return int_13;
		}
		set
		{
			int_13 = value;
		}
	}

	[Description("The inner radius of the range.")]
	[Browsable(true)]
	[Category("AGauge")]
	public int RangeOuterRadius
	{
		get
		{
			return int_14[byte_1];
		}
		set
		{
			if (int_14[byte_1] != value)
			{
				int_14[byte_1] = value;
				RangesOuterRadius = int_14;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(false)]
	public int[] RangesOuterRadius
	{
		get
		{
			return int_14;
		}
		set
		{
			int_14 = value;
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The radius of the scale numbers.")]
	public int ScaleNumbersRadius
	{
		get
		{
			return int_15;
		}
		set
		{
			if (int_15 != value)
			{
				int_15 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Description("The color of the scale numbers.")]
	[Browsable(true)]
	[Category("AGauge")]
	public Color ScaleNumbersColor
	{
		get
		{
			return color_6;
		}
		set
		{
			if (color_6 != value)
			{
				color_6 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The format of the scale numbers.")]
	public string ScaleNumbersFormat
	{
		get
		{
			return string_1;
		}
		set
		{
			if (string_1 != value)
			{
				string_1 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Description("The number of the scale line to start writing numbers next to.")]
	[Browsable(true)]
	public int ScaleNumbersStartScaleLine
	{
		get
		{
			return int_16;
		}
		set
		{
			if (int_16 != value)
			{
				int_16 = Math.Max(value, 1);
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The number of scale line steps for writing numbers.")]
	public int ScaleNumbersStepScaleLines
	{
		get
		{
			return int_17;
		}
		set
		{
			if (int_17 != value)
			{
				int_17 = Math.Max(value, 1);
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The angle relative to the tangent of the base arc at a scale line that is used to rotate numbers. set to 0 for no rotation or e.g. set to 90.")]
	public int ScaleNumbersRotation
	{
		get
		{
			return int_18;
		}
		set
		{
			if (int_18 != value)
			{
				int_18 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Description("The type of the needle, currently only type 0 and 1 are supported. Type 0 looks nicers but if you experience performance problems you might consider using type 1.")]
	[Browsable(true)]
	public int NeedleType
	{
		get
		{
			return int_19;
		}
		set
		{
			if (int_19 != value)
			{
				int_19 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(true)]
	[Description("The radius of the needle.")]
	[Category("AGauge")]
	public int NeedleRadius
	{
		get
		{
			return int_20;
		}
		set
		{
			if (int_20 != value)
			{
				int_20 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Description("The first color of the needle.")]
	[Browsable(true)]
	public NeedleColorEnum NeedleColor1
	{
		get
		{
			return needleColorEnum_0;
		}
		set
		{
			if (needleColorEnum_0 != value)
			{
				needleColorEnum_0 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Browsable(true)]
	[Category("AGauge")]
	[Description("The second color of the needle.")]
	public Color NeedleColor2
	{
		get
		{
			return color_7;
		}
		set
		{
			if (color_7 != value)
			{
				color_7 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Category("AGauge")]
	[Browsable(true)]
	[Description("The width of the needle.")]
	public int NeedleWidth
	{
		get
		{
			return int_21;
		}
		set
		{
			if (int_21 != value)
			{
				int_21 = value;
				ynKyTqoQcBd = true;
				((Control)this).Refresh();
			}
		}
	}

	[Description("This event is raised if the value falls into a defined range.")]
	public event ValueInRangeChangedDelegate ValueInRangeChanged
	{
		[CompilerGenerated]
		add
		{
			ValueInRangeChangedDelegate valueInRangeChangedDelegate = valueInRangeChangedDelegate_0;
			ValueInRangeChangedDelegate valueInRangeChangedDelegate2;
			do
			{
				valueInRangeChangedDelegate2 = valueInRangeChangedDelegate;
				ValueInRangeChangedDelegate value2 = (ValueInRangeChangedDelegate)Delegate.Combine(valueInRangeChangedDelegate2, value);
				valueInRangeChangedDelegate = Interlocked.CompareExchange(ref valueInRangeChangedDelegate_0, value2, valueInRangeChangedDelegate2);
			}
			while ((object)valueInRangeChangedDelegate != valueInRangeChangedDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			ValueInRangeChangedDelegate valueInRangeChangedDelegate = valueInRangeChangedDelegate_0;
			ValueInRangeChangedDelegate valueInRangeChangedDelegate2;
			do
			{
				valueInRangeChangedDelegate2 = valueInRangeChangedDelegate;
				ValueInRangeChangedDelegate value2 = (ValueInRangeChangedDelegate)Delegate.Remove(valueInRangeChangedDelegate2, value);
				valueInRangeChangedDelegate = Interlocked.CompareExchange(ref valueInRangeChangedDelegate_0, value2, valueInRangeChangedDelegate2);
			}
			while ((object)valueInRangeChangedDelegate != valueInRangeChangedDelegate2);
		}
	}

	public AGauge()
	{
		method_1();
		((Control)this).SetStyle((ControlStyles)131072, true);
	}

	private void method_0()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		SolidBrush val = new SolidBrush(Color.White);
		SolidBrush val2 = new SolidBrush(Color.Black);
		Bitmap val3 = new Bitmap(5, 5);
		SizeF sizeF = Graphics.FromImage((Image)(object)val3).MeasureString("0123456789", ((Control)this).Font, -1, StringFormat.GenericTypographic);
		val3 = new Bitmap((int)sizeF.Width, (int)sizeF.Height);
		Graphics obj = Graphics.FromImage((Image)(object)val3);
		obj.FillRectangle((Brush)(object)val, 0f, 0f, sizeF.Width, sizeF.Height);
		obj.DrawString("0123456789", ((Control)this).Font, (Brush)(object)val2, 0f, 0f, StringFormat.GenericTypographic);
		float_0 = 0f;
		float_1 = 0f;
		int i = 0;
		bool flag = false;
		for (; i < ((Image)val3).Height; i++)
		{
			if (flag)
			{
				break;
			}
			for (int j = 0; j < ((Image)val3).Width; j++)
			{
				if (flag)
				{
					break;
				}
				if (val3.GetPixel(j, i) != val.Color)
				{
					float_0 = i;
					flag = true;
				}
			}
		}
		i = ((Image)val3).Height - 1;
		flag = false;
		int num = 0;
		while (num < i && !flag)
		{
			for (int j = 0; j < ((Image)val3).Width; j++)
			{
				if (flag)
				{
					break;
				}
				if (val3.GetPixel(j, i) != val.Color)
				{
					float_1 = i;
					flag = true;
				}
			}
			i--;
			num = 0;
		}
	}

	protected override void OnPaintBackground(PaintEventArgs pevent)
	{
	}

	protected override void OnPaint(PaintEventArgs pe)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected I4, but got Unknown
		//IL_11e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_122e: Expected O, but got Unknown
		//IL_1273: Unknown result type (might be due to invalid IL or missing references)
		//IL_127a: Expected O, but got Unknown
		//IL_1297: Unknown result type (might be due to invalid IL or missing references)
		//IL_129e: Expected O, but got Unknown
		//IL_12b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b9: Expected O, but got Unknown
		//IL_12d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_12dd: Expected O, but got Unknown
		//IL_1343: Unknown result type (might be due to invalid IL or missing references)
		//IL_134a: Expected O, but got Unknown
		//IL_1361: Unknown result type (might be due to invalid IL or missing references)
		//IL_1368: Expected O, but got Unknown
		//IL_1379: Unknown result type (might be due to invalid IL or missing references)
		//IL_1380: Expected O, but got Unknown
		//IL_1397: Unknown result type (might be due to invalid IL or missing references)
		//IL_139e: Expected O, but got Unknown
		//IL_1404: Unknown result type (might be due to invalid IL or missing references)
		//IL_140b: Expected O, but got Unknown
		//IL_1422: Unknown result type (might be due to invalid IL or missing references)
		//IL_1429: Expected O, but got Unknown
		//IL_143a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1441: Expected O, but got Unknown
		//IL_1458: Unknown result type (might be due to invalid IL or missing references)
		//IL_145f: Expected O, but got Unknown
		//IL_14c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_14cc: Expected O, but got Unknown
		//IL_14e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ea: Expected O, but got Unknown
		//IL_14fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1502: Expected O, but got Unknown
		//IL_1519: Unknown result type (might be due to invalid IL or missing references)
		//IL_1520: Expected O, but got Unknown
		//IL_158c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1593: Expected O, but got Unknown
		//IL_15ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b4: Expected O, but got Unknown
		//IL_15cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d2: Expected O, but got Unknown
		//IL_15ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f3: Expected O, but got Unknown
		//IL_165f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1666: Expected O, but got Unknown
		//IL_1680: Unknown result type (might be due to invalid IL or missing references)
		//IL_1687: Expected O, but got Unknown
		//IL_169e: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a5: Expected O, but got Unknown
		//IL_16bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c6: Expected O, but got Unknown
		//IL_1732: Unknown result type (might be due to invalid IL or missing references)
		//IL_1739: Expected O, but got Unknown
		//IL_1753: Unknown result type (might be due to invalid IL or missing references)
		//IL_175a: Expected O, but got Unknown
		//IL_1771: Unknown result type (might be due to invalid IL or missing references)
		//IL_1778: Expected O, but got Unknown
		//IL_1792: Unknown result type (might be due to invalid IL or missing references)
		//IL_1799: Expected O, but got Unknown
		//IL_0d09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d53: Expected O, but got Unknown
		//IL_0d91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc7: Expected O, but got Unknown
		//IL_0dd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0f: Expected O, but got Unknown
		//IL_0e22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e58: Expected O, but got Unknown
		//IL_0e6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea0: Expected O, but got Unknown
		//IL_0eb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee9: Expected O, but got Unknown
		//IL_0efb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f31: Expected O, but got Unknown
		//IL_0f44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f7a: Expected O, but got Unknown
		//IL_0f8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc2: Expected O, but got Unknown
		//IL_0fd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_100b: Expected O, but got Unknown
		//IL_101d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1053: Expected O, but got Unknown
		//IL_1066: Unknown result type (might be due to invalid IL or missing references)
		//IL_109c: Expected O, but got Unknown
		//IL_10ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e4: Expected O, but got Unknown
		//IL_10f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_112d: Expected O, but got Unknown
		//IL_113f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1175: Expected O, but got Unknown
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Expected O, but got Unknown
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Expected O, but got Unknown
		//IL_1caa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cee: Expected O, but got Unknown
		//IL_1cfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d3e: Expected O, but got Unknown
		//IL_04e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_059c: Expected O, but got Unknown
		//IL_0ae5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b23: Expected O, but got Unknown
		//IL_08cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09dd: Expected O, but got Unknown
		//IL_0713: Unknown result type (might be due to invalid IL or missing references)
		//IL_0823: Expected O, but got Unknown
		//IL_0ba3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd8: Expected O, but got Unknown
		if (((Control)this).Width >= 10)
		{
			_ = ((Control)this).Height;
		}
		if (ynKyTqoQcBd)
		{
			ynKyTqoQcBd = false;
			method_0();
			bitmap_0 = new Bitmap(((Control)this).Width, ((Control)this).Height, pe.Graphics);
			Graphics val = Graphics.FromImage((Image)(object)bitmap_0);
			val.FillRectangle((Brush)new SolidBrush(((Control)this).BackColor), ((Control)this).ClientRectangle);
			if (((Control)this).BackgroundImage != null)
			{
				ImageLayout backgroundImageLayout = ((Control)this).BackgroundImageLayout;
				switch ((int)backgroundImageLayout)
				{
				case 0:
					val.DrawImageUnscaled(((Control)this).BackgroundImage, 0, 0);
					break;
				case 1:
				{
					int i = 0;
					int num = 0;
					for (; i < ((Control)this).Width; i += ((Control)this).BackgroundImage.Width)
					{
						for (num = 0; num < ((Control)this).Height; num += ((Control)this).BackgroundImage.Height)
						{
							val.DrawImageUnscaled(((Control)this).BackgroundImage, i, num);
						}
					}
					break;
				}
				case 2:
					val.DrawImageUnscaled(((Control)this).BackgroundImage, ((Control)this).Width / 2 - ((Control)this).BackgroundImage.Width / 2, ((Control)this).Height / 2 - ((Control)this).BackgroundImage.Height / 2);
					break;
				case 3:
					val.DrawImage(((Control)this).BackgroundImage, 0, 0, ((Control)this).Width, ((Control)this).Height);
					break;
				case 4:
					if ((float)(((Control)this).BackgroundImage.Width / ((Control)this).Width) < (float)(((Control)this).BackgroundImage.Height / ((Control)this).Height))
					{
						val.DrawImage(((Control)this).BackgroundImage, 0, 0, ((Control)this).Height, ((Control)this).Height);
					}
					else
					{
						val.DrawImage(((Control)this).BackgroundImage, 0, 0, ((Control)this).Width, ((Control)this).Width);
					}
					break;
				}
			}
			val.SmoothingMode = (SmoothingMode)2;
			val.PixelOffsetMode = (PixelOffsetMode)2;
			GraphicsPath val2 = new GraphicsPath();
			for (int j = 0; j < 5; j++)
			{
				if (float_7[j] > float_6[j] && bool_1[j])
				{
					float num2 = (float)int_1 + (float_6[j] - float_3) * (float)int_2 / (float_4 - float_3);
					float num3 = (float_7[j] - float_6[j]) * (float)int_2 / (float_4 - float_3);
					val2.Reset();
					val2.AddPie(new Rectangle(point_1.X - int_14[j], point_1.Y - int_14[j], 2 * int_14[j], 2 * int_14[j]), num2, num3);
					val2.Reverse();
					val2.AddPie(new Rectangle(point_1.X - int_13[j], point_1.Y - int_13[j], 2 * int_13[j], 2 * int_13[j]), num2, num3);
					val2.Reverse();
					val.SetClip(val2);
					val.FillPie((Brush)new SolidBrush(color_5[j]), new Rectangle(point_1.X - int_14[j], point_1.Y - int_14[j], 2 * int_14[j], 2 * int_14[j]), num2, num3);
				}
			}
			val.SetClip(((Control)this).ClientRectangle);
			if (int_0 > 0)
			{
				val.DrawArc(new Pen(color_1, (float)int_3), new Rectangle(point_1.X - int_0, point_1.Y - int_0, 2 * int_0, 2 * int_0), (float)int_1, (float)int_2);
			}
			string text = "";
			float num4 = 0f;
			int num5 = 0;
			while (num4 <= float_4 - float_3)
			{
				text = (float_3 + num4).ToString(string_1);
				val.ResetTransform();
				SizeF sizeF = val.MeasureString(text, ((Control)this).Font, -1, StringFormat.GenericTypographic);
				val2.Reset();
				val2.AddEllipse(new Rectangle(point_1.X - int_11, point_1.Y - int_11, 2 * int_11, 2 * int_11));
				val2.Reverse();
				val2.AddEllipse(new Rectangle(point_1.X - int_10, point_1.Y - int_10, 2 * int_10, 2 * int_10));
				val2.Reverse();
				val.SetClip(val2);
				val.DrawLine(new Pen(color_4, (float)int_12), (float)Center.X, (float)Center.Y, (float)((double)Center.X + (double)(2 * int_11) * Math.Cos((double)((float)int_1 + num4 * (float)int_2 / (float_4 - float_3)) * CSMath.PI_dividedBy_180)), (float)((double)Center.Y + (double)(2 * int_11) * Math.Sin((double)((float)int_1 + num4 * (float)int_2 / (float_4 - float_3)) * CSMath.PI_dividedBy_180)));
				val2.Reset();
				val2.AddEllipse(new Rectangle(point_1.X - int_8, point_1.Y - int_8, 2 * int_8, 2 * int_8));
				val2.Reverse();
				val2.AddEllipse(new Rectangle(point_1.X - int_7, point_1.Y - int_7, 2 * int_7, 2 * int_7));
				val2.Reverse();
				val.SetClip(val2);
				if (num4 < float_4 - float_3)
				{
					for (int k = 1; k <= int_6; k++)
					{
						if (int_6 % 2 == 1 && int_6 / 2 + 1 == k)
						{
							val2.Reset();
							val2.AddEllipse(new Rectangle(point_1.X - int_5, point_1.Y - int_5, 2 * int_5, 2 * int_5));
							val2.Reverse();
							val2.AddEllipse(new Rectangle(point_1.X - int_4, point_1.Y - int_4, 2 * int_4, 2 * int_4));
							val2.Reverse();
							val.SetClip(val2);
							val.DrawLine(new Pen(color_2, (float)YfqyTvUjseJ), (float)Center.X, (float)Center.Y, (float)((double)Center.X + (double)(2 * int_5) * Math.Cos((double)((float)int_1 + num4 * (float)int_2 / (float_4 - float_3) + (float)(k * int_2) / ((float_4 - float_3) / float_5 * (float)(int_6 + 1))) * CSMath.PI_dividedBy_180)), (float)((double)Center.Y + (double)(2 * int_5) * Math.Sin((double)((float)int_1 + num4 * (float)int_2 / (float_4 - float_3) + (float)(k * int_2) / ((float_4 - float_3) / float_5 * (float)(int_6 + 1))) * CSMath.PI_dividedBy_180)));
							val2.Reset();
							val2.AddEllipse(new Rectangle(point_1.X - int_8, point_1.Y - int_8, 2 * int_8, 2 * int_8));
							val2.Reverse();
							val2.AddEllipse(new Rectangle(point_1.X - int_7, point_1.Y - int_7, 2 * int_7, 2 * int_7));
							val2.Reverse();
							val.SetClip(val2);
						}
						else
						{
							val.DrawLine(new Pen(color_3, (float)int_9), (float)Center.X, (float)Center.Y, (float)((double)Center.X + (double)(2 * int_8) * Math.Cos((double)((float)int_1 + num4 * (float)int_2 / (float_4 - float_3) + (float)(k * int_2) / ((float_4 - float_3) / float_5 * (float)(int_6 + 1))) * CSMath.PI_dividedBy_180)), (float)((double)Center.Y + (double)(2 * int_8) * Math.Sin((double)((float)int_1 + num4 * (float)int_2 / (float_4 - float_3) + (float)(k * int_2) / ((float_4 - float_3) / float_5 * (float)(int_6 + 1))) * CSMath.PI_dividedBy_180)));
						}
					}
				}
				val.SetClip(((Control)this).ClientRectangle);
				if (int_18 != 0)
				{
					val.TextRenderingHint = (TextRenderingHint)4;
					val.RotateTransform(90f + (float)int_1 + num4 * (float)int_2 / (float_4 - float_3));
				}
				val.TranslateTransform((float)((double)Center.X + (double)int_15 * Math.Cos((double)((float)int_1 + num4 * (float)int_2 / (float_4 - float_3)) * CSMath.PI_dividedBy_180)), (float)((double)Center.Y + (double)int_15 * Math.Sin((double)((float)int_1 + num4 * (float)int_2 / (float_4 - float_3)) * CSMath.PI_dividedBy_180)), (MatrixOrder)1);
				if (num5 >= ScaleNumbersStartScaleLine - 1)
				{
					val.DrawString(text, ((Control)this).Font, (Brush)new SolidBrush(color_6), (0f - sizeF.Width) / 2f, 0f - float_0 - (float_1 - float_0 + 1f) / 2f, StringFormat.GenericTypographic);
				}
				num4 += float_5;
				num5++;
			}
			val.ResetTransform();
			val.SetClip(((Control)this).ClientRectangle);
			int num6;
			if (int_18 == 0)
			{
				num6 = 0;
			}
			else
			{
				val.TextRenderingHint = (TextRenderingHint)0;
				num6 = 0;
			}
			for (int l = num6; l < 5; l++)
			{
				if (string_0[l] != "")
				{
					val.DrawString(string_0[l], ((Control)this).Font, (Brush)new SolidBrush(color_0[l]), (float)point_0[l].X, (float)point_0[l].Y, StringFormat.GenericTypographic);
				}
			}
		}
		if (!((Control)this).Enabled)
		{
			return;
		}
		pe.Graphics.DrawImageUnscaled((Image)(object)bitmap_0, 0, 0);
		pe.Graphics.SmoothingMode = (SmoothingMode)4;
		pe.Graphics.PixelOffsetMode = (PixelOffsetMode)2;
		float num7 = (int)((float)int_1 + (float_2 - float_3) * (float)int_2 / (float_4 - float_3)) % 360;
		double num8 = (double)num7 * CSMath.PI_dividedBy_180;
		switch (int_19)
		{
		case 1:
		{
			Point point = new Point((int)((double)Center.X - (double)(int_20 / 8) * Math.Cos(num8)), (int)((double)Center.Y - (double)(int_20 / 8) * Math.Sin(num8)));
			Point point2 = new Point((int)((double)Center.X + (double)int_20 * Math.Cos(num8)), (int)((double)Center.Y + (double)int_20 * Math.Sin(num8)));
			pe.Graphics.FillEllipse((Brush)new SolidBrush(color_7), Center.X - int_21 * 3, Center.Y - int_21 * 3, int_21 * 6, int_21 * 6);
			switch (needleColorEnum_0)
			{
			case NeedleColorEnum.Gray:
				pe.Graphics.DrawLine(new Pen(Color.DarkGray, (float)int_21), Center.X, Center.Y, point2.X, point2.Y);
				pe.Graphics.DrawLine(new Pen(Color.DarkGray, (float)int_21), Center.X, Center.Y, point.X, point.Y);
				break;
			case NeedleColorEnum.Red:
				pe.Graphics.DrawLine(new Pen(Color.Red, (float)int_21), Center.X, Center.Y, point2.X, point2.Y);
				pe.Graphics.DrawLine(new Pen(Color.Red, (float)int_21), Center.X, Center.Y, point.X, point.Y);
				break;
			case NeedleColorEnum.Green:
				pe.Graphics.DrawLine(new Pen(Color.Green, (float)int_21), Center.X, Center.Y, point2.X, point2.Y);
				pe.Graphics.DrawLine(new Pen(Color.Green, (float)int_21), Center.X, Center.Y, point.X, point.Y);
				break;
			case NeedleColorEnum.Blue:
				pe.Graphics.DrawLine(new Pen(Color.Blue, (float)int_21), Center.X, Center.Y, point2.X, point2.Y);
				pe.Graphics.DrawLine(new Pen(Color.Blue, (float)int_21), Center.X, Center.Y, point.X, point.Y);
				break;
			case NeedleColorEnum.Yellow:
				pe.Graphics.DrawLine(new Pen(Color.Yellow, (float)int_21), Center.X, Center.Y, point2.X, point2.Y);
				pe.Graphics.DrawLine(new Pen(Color.Yellow, (float)int_21), Center.X, Center.Y, point.X, point.Y);
				break;
			case NeedleColorEnum.Violet:
				pe.Graphics.DrawLine(new Pen(Color.Violet, (float)int_21), Center.X, Center.Y, point2.X, point2.Y);
				pe.Graphics.DrawLine(new Pen(Color.Violet, (float)int_21), Center.X, Center.Y, point.X, point.Y);
				break;
			case NeedleColorEnum.Magenta:
				pe.Graphics.DrawLine(new Pen(Color.Magenta, (float)int_21), Center.X, Center.Y, point2.X, point2.Y);
				pe.Graphics.DrawLine(new Pen(Color.Magenta, (float)int_21), Center.X, Center.Y, point.X, point.Y);
				break;
			}
			break;
		}
		case 0:
		{
			PointF[] array = new PointF[3];
			Brush val3 = Brushes.White;
			Brush val4 = Brushes.White;
			Brush val5 = Brushes.White;
			Brush val6 = Brushes.White;
			_ = Brushes.White;
			int num9 = (int)((num7 + 225f) % 180f * 100f / 180f);
			int num10 = (int)((num7 + 135f) % 180f * 100f / 180f);
			pe.Graphics.FillEllipse((Brush)new SolidBrush(color_7), Center.X - int_21 * 3, Center.Y - int_21 * 3, int_21 * 6, int_21 * 6);
			switch (needleColorEnum_0)
			{
			case NeedleColorEnum.Gray:
				val3 = (Brush)new SolidBrush(Color.FromArgb(80 + num9, 80 + num9, 80 + num9));
				val4 = (Brush)new SolidBrush(Color.FromArgb(180 - num9, 180 - num9, 180 - num9));
				val5 = (Brush)new SolidBrush(Color.FromArgb(80 + num10, 80 + num10, 80 + num10));
				val6 = (Brush)new SolidBrush(Color.FromArgb(180 - num10, 180 - num10, 180 - num10));
				pe.Graphics.DrawEllipse(Pens.Gray, Center.X - int_21 * 3, Center.Y - int_21 * 3, int_21 * 6, int_21 * 6);
				break;
			case NeedleColorEnum.Red:
				val3 = (Brush)new SolidBrush(Color.FromArgb(145 + num9, num9, num9));
				val4 = (Brush)new SolidBrush(Color.FromArgb(245 - num9, 100 - num9, 100 - num9));
				val5 = (Brush)new SolidBrush(Color.FromArgb(145 + num10, num10, num10));
				val6 = (Brush)new SolidBrush(Color.FromArgb(245 - num10, 100 - num10, 100 - num10));
				pe.Graphics.DrawEllipse(Pens.Red, Center.X - int_21 * 3, Center.Y - int_21 * 3, int_21 * 6, int_21 * 6);
				break;
			case NeedleColorEnum.Green:
				val3 = (Brush)new SolidBrush(Color.FromArgb(num9, 145 + num9, num9));
				val4 = (Brush)new SolidBrush(Color.FromArgb(100 - num9, 245 - num9, 100 - num9));
				val5 = (Brush)new SolidBrush(Color.FromArgb(num10, 145 + num10, num10));
				val6 = (Brush)new SolidBrush(Color.FromArgb(100 - num10, 245 - num10, 100 - num10));
				pe.Graphics.DrawEllipse(Pens.Green, Center.X - int_21 * 3, Center.Y - int_21 * 3, int_21 * 6, int_21 * 6);
				break;
			case NeedleColorEnum.Blue:
				val3 = (Brush)new SolidBrush(Color.FromArgb(num9, num9, 145 + num9));
				val4 = (Brush)new SolidBrush(Color.FromArgb(100 - num9, 100 - num9, 245 - num9));
				val5 = (Brush)new SolidBrush(Color.FromArgb(num10, num10, 145 + num10));
				val6 = (Brush)new SolidBrush(Color.FromArgb(100 - num10, 100 - num10, 245 - num10));
				pe.Graphics.DrawEllipse(Pens.Blue, Center.X - int_21 * 3, Center.Y - int_21 * 3, int_21 * 6, int_21 * 6);
				break;
			case NeedleColorEnum.Yellow:
				val3 = (Brush)new SolidBrush(Color.FromArgb(145 + num9, 145 + num9, num9));
				val4 = (Brush)new SolidBrush(Color.FromArgb(245 - num9, 245 - num9, 100 - num9));
				val5 = (Brush)new SolidBrush(Color.FromArgb(145 + num10, 145 + num10, num10));
				val6 = (Brush)new SolidBrush(Color.FromArgb(245 - num10, 245 - num10, 100 - num10));
				pe.Graphics.DrawEllipse(Pens.Violet, Center.X - int_21 * 3, Center.Y - int_21 * 3, int_21 * 6, int_21 * 6);
				break;
			case NeedleColorEnum.Violet:
				val3 = (Brush)new SolidBrush(Color.FromArgb(145 + num9, num9, 145 + num9));
				val4 = (Brush)new SolidBrush(Color.FromArgb(245 - num9, 100 - num9, 245 - num9));
				val5 = (Brush)new SolidBrush(Color.FromArgb(145 + num10, num10, 145 + num10));
				val6 = (Brush)new SolidBrush(Color.FromArgb(245 - num10, 100 - num10, 245 - num10));
				pe.Graphics.DrawEllipse(Pens.Violet, Center.X - int_21 * 3, Center.Y - int_21 * 3, int_21 * 6, int_21 * 6);
				break;
			case NeedleColorEnum.Magenta:
				val3 = (Brush)new SolidBrush(Color.FromArgb(num9, 145 + num9, 145 + num9));
				val4 = (Brush)new SolidBrush(Color.FromArgb(100 - num9, 245 - num9, 245 - num9));
				val5 = (Brush)new SolidBrush(Color.FromArgb(num10, 145 + num10, 145 + num10));
				val6 = (Brush)new SolidBrush(Color.FromArgb(100 - num10, 245 - num10, 245 - num10));
				pe.Graphics.DrawEllipse(Pens.Magenta, Center.X - int_21 * 3, Center.Y - int_21 * 3, int_21 * 6, int_21 * 6);
				break;
			}
			if (Math.Floor((float)((double)((num7 + 225f) % 360f) / 180.0)) == 0.0)
			{
				Brush obj = val3;
				val3 = val4;
				val4 = obj;
			}
			if (Math.Floor((float)((double)((num7 + 135f) % 360f) / 180.0)) == 0.0)
			{
				val6 = val5;
			}
			array[0].X = (float)((double)Center.X + (double)int_20 * Math.Cos(num8));
			array[0].Y = (float)((double)Center.Y + (double)int_20 * Math.Sin(num8));
			array[1].X = (float)((double)Center.X - (double)(int_20 / 20) * Math.Cos(num8));
			array[1].Y = (float)((double)Center.Y - (double)(int_20 / 20) * Math.Sin(num8));
			array[2].X = (float)((double)Center.X - (double)(int_20 / 5) * Math.Cos(num8) + (double)(int_21 * 2) * Math.Cos(num8 + Math.PI / 2.0));
			array[2].Y = (float)((double)Center.Y - (double)(int_20 / 5) * Math.Sin(num8) + (double)(int_21 * 2) * Math.Sin(num8 + Math.PI / 2.0));
			pe.Graphics.FillPolygon(val3, array);
			array[2].X = (float)((double)Center.X - (double)(int_20 / 5) * Math.Cos(num8) + (double)(int_21 * 2) * Math.Cos(num8 - Math.PI / 2.0));
			array[2].Y = (float)((double)Center.Y - (double)(int_20 / 5) * Math.Sin(num8) + (double)(int_21 * 2) * Math.Sin(num8 - Math.PI / 2.0));
			pe.Graphics.FillPolygon(val4, array);
			array[0].X = (float)((double)Center.X - (double)(int_20 / 20 - 1) * Math.Cos(num8));
			array[0].Y = (float)((double)Center.Y - (double)(int_20 / 20 - 1) * Math.Sin(num8));
			array[1].X = (float)((double)Center.X - (double)(int_20 / 5) * Math.Cos(num8) + (double)(int_21 * 2) * Math.Cos(num8 + Math.PI / 2.0));
			array[1].Y = (float)((double)Center.Y - (double)(int_20 / 5) * Math.Sin(num8) + (double)(int_21 * 2) * Math.Sin(num8 + Math.PI / 2.0));
			array[2].X = (float)((double)Center.X - (double)(int_20 / 5) * Math.Cos(num8) + (double)(int_21 * 2) * Math.Cos(num8 - Math.PI / 2.0));
			array[2].Y = (float)((double)Center.Y - (double)(int_20 / 5) * Math.Sin(num8) + (double)(int_21 * 2) * Math.Sin(num8 - Math.PI / 2.0));
			pe.Graphics.FillPolygon(val6, array);
			array[0].X = (float)((double)Center.X - (double)(int_20 / 20) * Math.Cos(num8));
			array[0].Y = (float)((double)Center.Y - (double)(int_20 / 20) * Math.Sin(num8));
			array[1].X = (float)((double)Center.X + (double)int_20 * Math.Cos(num8));
			array[1].Y = (float)((double)Center.Y + (double)int_20 * Math.Sin(num8));
			pe.Graphics.DrawLine(new Pen(color_7), (float)Center.X, (float)Center.Y, array[0].X, array[0].Y);
			pe.Graphics.DrawLine(new Pen(color_7), (float)Center.X, (float)Center.Y, array[1].X, array[1].Y);
			break;
		}
		}
	}

	protected override void OnResize(EventArgs e)
	{
		ynKyTqoQcBd = true;
		((Control)this).Refresh();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		((Control)this).Dispose(disposing);
	}

	private void method_1()
	{
		icontainer_0 = new Container();
	}

	static AGauge()
	{
		Class72.smethod_20();
	}
}
