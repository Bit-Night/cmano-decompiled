using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public class DarkRadioButton : RadioButton
{
	private DarkControlState darkControlState_0;

	private bool bool_0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Appearance Appearance => ((RadioButton)this).Appearance;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool AutoEllipsis => ((ButtonBase)this).AutoEllipsis;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Image BackgroundImage => ((Control)this).BackgroundImage;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public ImageLayout BackgroundImageLayout => ((Control)this).BackgroundImageLayout;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool FlatAppearance => false;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public FlatStyle FlatStyle => ((ButtonBase)this).FlatStyle;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Image Image => ((ButtonBase)this).Image;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public ContentAlignment TextAlign => ((RadioButton)this).TextAlign;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public TextImageRelation TextImageRelation => ((ButtonBase)this).TextImageRelation;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool UseCompatibleTextRendering => false;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool UseVisualStyleBackColor => false;

	public DarkRadioButton()
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
			if (((Control)this).ClientRectangle.Contains(e.Location))
			{
				method_0(DarkControlState.Pressed);
			}
			else
			{
				method_0(DarkControlState.Hover);
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
		((RadioButton)this).OnMouseUp(e);
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

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		Rectangle rectangle = new Rectangle(0, 0, ((Control)this).ClientSize.Width, ((Control)this).ClientSize.Height);
		int radioButtonSize = Consts.RadioButtonSize;
		Color color = Colors.LightText;
		Color color2 = Colors.LightText;
		Color color3 = Colors.LightestBackground;
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
		SolidBrush val = new SolidBrush(Colors.GreyBackground);
		try
		{
			graphics.FillRectangle((Brush)(object)val, rectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		graphics.SmoothingMode = (SmoothingMode)2;
		Pen val2 = new Pen(color2);
		try
		{
			Rectangle rectangle2 = new Rectangle(0, rectangle.Height / 2 - radioButtonSize / 2, radioButtonSize, radioButtonSize);
			graphics.DrawEllipse(val2, rectangle2);
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
		if (((RadioButton)this).Checked)
		{
			SolidBrush val3 = new SolidBrush(color3);
			try
			{
				Rectangle rectangle3 = new Rectangle(3, rectangle.Height / 2 - (radioButtonSize - 7) / 2 - 1, radioButtonSize - 6, radioButtonSize - 6);
				graphics.FillEllipse((Brush)(object)val3, rectangle3);
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
		}
		graphics.SmoothingMode = (SmoothingMode)0;
		SolidBrush val4 = new SolidBrush(color);
		try
		{
			StringFormat val5 = new StringFormat
			{
				LineAlignment = (StringAlignment)1,
				Alignment = (StringAlignment)0
			};
			Rectangle rectangle4 = new Rectangle(radioButtonSize + 4, 0, rectangle.Width - radioButtonSize, rectangle.Height);
			graphics.DrawString(((Control)this).Text, ((Control)this).Font, (Brush)(object)val4, (RectangleF)rectangle4, val5);
		}
		finally
		{
			((IDisposable)val4)?.Dispose();
		}
	}

	static DarkRadioButton()
	{
		Class72.smethod_20();
	}
}
