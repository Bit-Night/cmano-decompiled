using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public class DarkCheckBox : CheckBox
{
	private DarkControlState darkControlState_0;

	private bool bool_0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Appearance Appearance => ((CheckBox)this).Appearance;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public bool AutoEllipsis => ((ButtonBase)this).AutoEllipsis;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public Image BackgroundImage => ((Control)this).BackgroundImage;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ImageLayout BackgroundImageLayout => ((Control)this).BackgroundImageLayout;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool FlatAppearance => false;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public FlatStyle FlatStyle => ((ButtonBase)this).FlatStyle;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Image Image => ((ButtonBase)this).Image;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ContentAlignment ImageAlign => ((ButtonBase)this).ImageAlign;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int ImageIndex => ((ButtonBase)this).ImageIndex;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public string ImageKey => ((ButtonBase)this).ImageKey;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public ImageList ImageList => ((ButtonBase)this).ImageList;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ContentAlignment TextAlign => ((CheckBox)this).TextAlign;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public TextImageRelation TextImageRelation => ((ButtonBase)this).TextImageRelation;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ThreeState
	{
		get
		{
			return ((CheckBox)this).ThreeState;
		}
		set
		{
			((CheckBox)this).ThreeState = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool UseCompatibleTextRendering => false;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public bool UseVisualStyleBackColor => false;

	public DarkCheckBox()
	{
		((Control)this).SetStyle((ControlStyles)133138, true);
	}

	private void method_0(DarkControlState darkControlState_1)
	{
		if (darkControlState_0 != darkControlState_1)
		{
			darkControlState_0 = darkControlState_1;
			((Control)this).Invalidate();
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		((ButtonBase)this).OnMouseMove(e);
		if (bool_0)
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
		((CheckBox)this).OnMouseUp(e);
		if (!bool_0)
		{
			method_0(DarkControlState.Normal);
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		((ButtonBase)this).OnMouseLeave(e);
		if (!bool_0)
		{
			method_0(DarkControlState.Normal);
		}
	}

	protected override void OnMouseCaptureChanged(EventArgs e)
	{
		((Control)this).OnMouseCaptureChanged(e);
		if (!bool_0)
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
		bool_0 = false;
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
		((CheckBox)this).OnKeyDown(e);
		if ((int)e.KeyCode == 32)
		{
			bool_0 = true;
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
			bool_0 = false;
			Point position = Cursor.Position;
			if (((Control)this).ClientRectangle.Contains(position))
			{
				method_0(DarkControlState.Hover);
			}
			else
			{
				method_0(DarkControlState.Normal);
			}
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Invalid comparison between Unknown and I4
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		Rectangle rectangle = new Rectangle(0, 0, ((Control)this).ClientSize.Width, ((Control)this).ClientSize.Height);
		int checkBoxSize = Consts.CheckBoxSize;
		Color color = Colors.LightText;
		Color color2 = Colors.LightText;
		Color color3 = Color.Transparent;
		if (!((Control)this).Enabled)
		{
			color = Colors.DisabledText;
			color2 = Colors.GreyHighlight;
			color3 = Colors.GreySelection;
		}
		else
		{
			if (((Control)this).Focused)
			{
				color2 = Colors.BlueHighlight;
				color3 = Colors.BlueSelection;
			}
			if (darkControlState_0 == DarkControlState.Hover)
			{
				color2 = Colors.BlueHighlight;
				color3 = Colors.BlueSelection;
			}
			else if (darkControlState_0 == DarkControlState.Pressed)
			{
				color2 = Colors.GreyHighlight;
				color3 = Colors.GreySelection;
			}
		}
		SolidBrush val = new SolidBrush(((Control)this).Parent.BackColor);
		try
		{
			graphics.FillRectangle((Brush)(object)val, rectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		Pen val2 = new Pen(color2);
		try
		{
			Rectangle rectangle2 = new Rectangle(0, rectangle.Height / 2 - checkBoxSize / 2, checkBoxSize, checkBoxSize);
			graphics.DrawRectangle(val2, rectangle2);
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
		if (((CheckBox)this).Checked)
		{
			int red;
			int green;
			int blue;
			if (!ThreeState)
			{
				red = 189;
				green = 189;
				blue = 189;
			}
			else
			{
				if ((int)((CheckBox)this).CheckState == 2)
				{
					SolidBrush val3 = new SolidBrush(color3);
					try
					{
						Rectangle rectangle3 = new Rectangle(2, rectangle.Height / 2 - (checkBoxSize - 4) / 2, checkBoxSize - 3, checkBoxSize - 3);
						graphics.FillRectangle((Brush)(object)val3, rectangle3);
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
					goto IL_0237;
				}
				red = 189;
				green = 189;
				blue = 189;
			}
			Pen val4 = new Pen(Color.FromArgb(red, green, blue), 2f);
			try
			{
				Rectangle rectangle4 = new Rectangle(0, rectangle.Height / 2 - checkBoxSize / 2, checkBoxSize, checkBoxSize);
				graphics.DrawLines(val4, new Point[3]
				{
					new Point(rectangle4.Left + 2, rectangle4.Top + 6),
					new Point(rectangle4.Left + 5, rectangle4.Top + 9),
					new Point(rectangle4.Left + 12, rectangle4.Top + 2)
				});
			}
			finally
			{
				((IDisposable)val4)?.Dispose();
			}
		}
		goto IL_0237;
		IL_0237:
		SolidBrush val5 = new SolidBrush(color);
		try
		{
			new StringFormat
			{
				LineAlignment = (StringAlignment)1,
				Alignment = (StringAlignment)0
			};
			Rectangle rectangle5 = new Rectangle(checkBoxSize + 4, 2, rectangle.Width - checkBoxSize, rectangle.Height);
			TextRenderer.DrawText((IDeviceContext)(object)graphics, ((Control)this).Text, ((Control)this).Font, rectangle5, color, (TextFormatFlags)8208);
		}
		finally
		{
			((IDisposable)val5)?.Dispose();
		}
	}

	static DarkCheckBox()
	{
		Class72.smethod_20();
	}
}
