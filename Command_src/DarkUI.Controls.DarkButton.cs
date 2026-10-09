using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

[DefaultEvent("Click")]
[ToolboxBitmap(typeof(Button))]
public class DarkButton : Button
{
	private DarkButtonStyle darkButtonStyle_0;

	private DarkControlState darkControlState_0;

	private bool bool_0;

	private bool bool_1;

	private int int_0 = Consts.Padding / 2;

	private int vmXetritnkh = 5;

	public string Text
	{
		get
		{
			return ((ButtonBase)this).Text;
		}
		set
		{
			((ButtonBase)this).Text = value;
			((Control)this).Invalidate();
		}
	}

	public bool Enabled
	{
		get
		{
			return ((Control)this).Enabled;
		}
		set
		{
			((Control)this).Enabled = value;
			((Control)this).Invalidate();
		}
	}

	[Description("Determines the style of the button.")]
	[DefaultValue(DarkButtonStyle.Normal)]
	[Category("Appearance")]
	public DarkButtonStyle ButtonStyle
	{
		get
		{
			return darkButtonStyle_0;
		}
		set
		{
			darkButtonStyle_0 = value;
			((Control)this).Invalidate();
		}
	}

	[Category("Appearance")]
	[Description("Determines the amount of padding between the image and text.")]
	[DefaultValue(5)]
	public int ImagePadding
	{
		get
		{
			return vmXetritnkh;
		}
		set
		{
			vmXetritnkh = value;
			((Control)this).Invalidate();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public bool AutoEllipsis => false;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DarkControlState ButtonState => darkControlState_0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ContentAlignment ImageAlign => ((ButtonBase)this).ImageAlign;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public bool FlatAppearance => false;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public FlatStyle FlatStyle => ((ButtonBase)this).FlatStyle;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ContentAlignment TextAlign => ((ButtonBase)this).TextAlign;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public bool UseCompatibleTextRendering => false;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public bool UseVisualStyleBackColor => false;

	public DarkButton()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		((Control)this).SetStyle((ControlStyles)131090, true);
		((ButtonBase)this).UseVisualStyleBackColor = false;
		((ButtonBase)this).UseCompatibleTextRendering = false;
		method_0(DarkControlState.Normal);
		((Control)this).Padding = new Padding(int_0);
		((Control)this).ForeColor = Colors.LightText;
	}

	private void method_0(DarkControlState darkControlState_1)
	{
		if (darkControlState_0 != darkControlState_1)
		{
			darkControlState_0 = darkControlState_1;
			((Control)this).Invalidate();
		}
	}

	protected override void OnCreateControl()
	{
		((Control)this).OnCreateControl();
		Form val = ((Control)this).FindForm();
		if (val != null && (object)val.AcceptButton == this)
		{
			bool_0 = true;
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		((ButtonBase)this).OnMouseMove(e);
		if (bool_1)
		{
			return;
		}
		if ((int)e.Button == 1048576)
		{
			if (!((Control)this).ClientRectangle.Contains(e.Location))
			{
				method_0(DarkControlState.Hover);
			}
			else
			{
				method_0(DarkControlState.Pressed);
			}
		}
		else
		{
			method_0(DarkControlState.Hover);
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		((ButtonBase)this).OnMouseDown(e);
		if (((Control)this).ClientRectangle.Contains(e.Location))
		{
			method_0(DarkControlState.Pressed);
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		((Button)this).OnMouseUp(e);
		if (!bool_1)
		{
			method_0(DarkControlState.Normal);
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		((Button)this).OnMouseLeave(e);
		if (!bool_1)
		{
			method_0(DarkControlState.Normal);
		}
	}

	protected override void OnMouseCaptureChanged(EventArgs e)
	{
		((Control)this).OnMouseCaptureChanged(e);
		if (!bool_1)
		{
			Point position = Cursor.Position;
			if (!((Control)this).ClientRectangle.Contains(position))
			{
				method_0(DarkControlState.Normal);
			}
		}
	}

	protected override void OnGotFocus(EventArgs e)
	{
		((ButtonBase)this).OnGotFocus(e);
		((Control)this).Invalidate();
	}

	protected override void OnLostFocus(EventArgs e)
	{
		((ButtonBase)this).OnLostFocus(e);
		bool_1 = false;
		Point position = Cursor.Position;
		if (!((Control)this).ClientRectangle.Contains(position))
		{
			method_0(DarkControlState.Normal);
		}
		else
		{
			method_0(DarkControlState.Hover);
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		((ButtonBase)this).OnKeyDown(e);
		if ((int)e.KeyCode == 32)
		{
			bool_1 = true;
			method_0(DarkControlState.Pressed);
		}
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		((ButtonBase)this).OnKeyUp(e);
		if ((int)e.KeyCode == 32)
		{
			bool_1 = false;
			Point position = Cursor.Position;
			if (!((Control)this).ClientRectangle.Contains(position))
			{
				method_0(DarkControlState.Normal);
			}
			else
			{
				method_0(DarkControlState.Hover);
			}
		}
	}

	public override void NotifyDefault(bool value)
	{
		((Button)this).NotifyDefault(value);
		if (((Component)this).DesignMode)
		{
			bool_0 = value;
			((Control)this).Invalidate();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Expected O, but got Unknown
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected I4, but got Unknown
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Invalid comparison between Unknown and I4
		Graphics graphics = e.Graphics;
		Rectangle rectangle = new Rectangle(0, 0, ((Control)this).ClientSize.Width, ((Control)this).ClientSize.Height);
		Color color = ((Control)this).ForeColor;
		Color color2 = Colors.GreySelection;
		Color color3 = (bool_0 ? Colors.DarkBlueBackground : Colors.LightBackground);
		if (Enabled)
		{
			if (ButtonStyle == DarkButtonStyle.Normal)
			{
				if (((Control)this).Focused && ((Control)this).TabStop)
				{
					color2 = Colors.BlueHighlight;
				}
				switch (ButtonState)
				{
				case DarkControlState.Pressed:
					color3 = (bool_0 ? Colors.DarkBackground : Colors.DarkBackground);
					break;
				case DarkControlState.Hover:
					color3 = (bool_0 ? Colors.BlueBackground : Colors.LighterBackground);
					break;
				}
			}
			else if (ButtonStyle == DarkButtonStyle.Flat)
			{
				switch (ButtonState)
				{
				case DarkControlState.Normal:
					color3 = Colors.GreyBackground;
					break;
				case DarkControlState.Hover:
					color3 = Colors.MediumBackground;
					break;
				case DarkControlState.Pressed:
					color3 = Colors.DarkBackground;
					break;
				}
			}
		}
		else
		{
			color = Colors.DisabledText;
			color3 = Colors.DarkGreySelection;
		}
		SolidBrush val = new SolidBrush(color3);
		try
		{
			graphics.FillRectangle((Brush)(object)val, rectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		int num;
		if (ButtonStyle != DarkButtonStyle.Normal)
		{
			num = 0;
		}
		else
		{
			Pen val2 = new Pen(color2, 1f);
			try
			{
				Rectangle rectangle2 = new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width - 1, rectangle.Height - 1);
				graphics.DrawRectangle(val2, rectangle2);
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
			num = 0;
		}
		int num2 = num;
		int num3 = 0;
		if (((ButtonBase)this).Image != null)
		{
			SizeF sizeF = graphics.MeasureString(Text, ((Control)this).Font, (SizeF)rectangle.Size);
			int num4 = ((Control)this).ClientSize.Width / 2 - ((ButtonBase)this).Image.Size.Width / 2;
			int num5 = ((Control)this).ClientSize.Height / 2 - ((ButtonBase)this).Image.Size.Height / 2;
			TextImageRelation textImageRelation = ((ButtonBase)this).TextImageRelation;
			switch (textImageRelation - 1)
			{
			default:
				if ((int)textImageRelation == 8)
				{
					num4 += (int)sizeF.Width;
				}
				break;
			case 0:
				num3 = ((ButtonBase)this).Image.Size.Height / 2 + ImagePadding / 2;
				num5 -= (int)(sizeF.Height / 2f) + ImagePadding / 2;
				break;
			case 1:
				num3 = (((ButtonBase)this).Image.Size.Height / 2 + ImagePadding / 2) * -1;
				num5 += (int)(sizeF.Height / 2f) + ImagePadding / 2;
				break;
			case 3:
				num2 = ((ButtonBase)this).Image.Size.Width + ImagePadding * 2;
				num4 = ImagePadding;
				break;
			case 2:
				break;
			}
			graphics.DrawImageUnscaled(((ButtonBase)this).Image, num4, num5);
		}
		SolidBrush val3 = new SolidBrush(color);
		try
		{
			int num6 = rectangle.Left + num2;
			Padding padding = ((Control)this).Padding;
			int x = num6 + ((Padding)(ref padding)).Left;
			int num7 = rectangle.Top + num3;
			padding = ((Control)this).Padding;
			int y = num7 + ((Padding)(ref padding)).Top;
			int width = rectangle.Width;
			padding = ((Control)this).Padding;
			int width2 = width - ((Padding)(ref padding)).Horizontal;
			int height = rectangle.Height;
			padding = ((Control)this).Padding;
			Rectangle rectangle3 = new Rectangle(x, y, width2, height - ((Padding)(ref padding)).Vertical);
			StringFormat val4 = new StringFormat
			{
				LineAlignment = (StringAlignment)1,
				Alignment = (StringAlignment)1,
				Trimming = (StringTrimming)3
			};
			graphics.TextRenderingHint = (TextRenderingHint)5;
			graphics.DrawString(Text, ((Control)this).Font, (Brush)(object)val3, (RectangleF)rectangle3, val4);
		}
		finally
		{
			((IDisposable)val3)?.Dispose();
		}
	}

	static DarkButton()
	{
		Class72.smethod_20();
	}
}
