using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkScrollBar : Control
{
	private DarkScrollOrientation darkScrollOrientation_0;

	private int int_0;

	private int int_1;

	private int int_2 = 100;

	private int int_3;

	private Rectangle rectangle_0;

	private float float_0;

	private Rectangle rectangle_1;

	private Rectangle rectangle_2;

	private Rectangle rectangle_3;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private int int_4;

	private Point point_0;

	private Timer timer_0;

	[DefaultValue(DarkScrollOrientation.Vertical)]
	[Description("The orientation type of the scrollbar.")]
	[Category("Behavior")]
	public DarkScrollOrientation ScrollOrientation
	{
		get
		{
			return darkScrollOrientation_0;
		}
		set
		{
			darkScrollOrientation_0 = value;
			UpdateScrollBar();
		}
	}

	[DefaultValue(0)]
	[Description("The value that the scroll thumb position represents.")]
	[Category("Behavior")]
	public int Value
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < Minimum)
			{
				value = Minimum;
			}
			int num = Maximum - ViewSize;
			if (value > num)
			{
				value = num;
			}
			if (int_0 != value)
			{
				int_0 = value;
				method_0(bool_7: true);
				if (this.ValueChanged != null)
				{
					this.ValueChanged(this, new ScrollValueEventArgs(Value));
				}
			}
		}
	}

	[Category("Behavior")]
	[DefaultValue(0)]
	[Description("The lower limit value of the scrollable range.")]
	public int Minimum
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
			UpdateScrollBar();
		}
	}

	[DefaultValue(100)]
	[Category("Behavior")]
	[Description("The upper limit value of the scrollable range.")]
	public int Maximum
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
			UpdateScrollBar();
		}
	}

	[Category("Behavior")]
	[Description("The view size for the scrollable area.")]
	[DefaultValue(0)]
	public int ViewSize
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
			UpdateScrollBar();
		}
	}

	public bool Visible
	{
		get
		{
			return ((Control)this).Visible;
		}
		set
		{
			if (((Control)this).Visible != value)
			{
				((Control)this).Visible = value;
			}
		}
	}

	public event EventHandler<ScrollValueEventArgs> ValueChanged;

	public DarkScrollBar()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		((Control)this).SetStyle((ControlStyles)131090, true);
		((Control)this).SetStyle((ControlStyles)512, false);
		timer_0 = new Timer();
		timer_0.Interval = 1;
		timer_0.Tick += timer_0_Tick;
	}

	protected override void OnResize(EventArgs e)
	{
		((Control)this).OnResize(e);
		UpdateScrollBar();
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Invalid comparison between Unknown and I4
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Invalid comparison between Unknown and I4
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Invalid comparison between Unknown and I4
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Invalid comparison between Unknown and I4
		((Control)this).OnMouseDown(e);
		if (rectangle_1.Contains(e.Location) && (int)e.Button == 1048576)
		{
			bool_6 = true;
			point_0 = e.Location;
			if (darkScrollOrientation_0 == DarkScrollOrientation.Vertical)
			{
				int_4 = rectangle_1.Top;
			}
			else
			{
				int_4 = rectangle_1.Left;
			}
			((Control)this).Invalidate();
		}
		else if (rectangle_2.Contains(e.Location) && (int)e.Button == 1048576)
		{
			bool_4 = true;
			timer_0.Enabled = true;
			((Control)this).Invalidate();
		}
		else if (rectangle_3.Contains(e.Location) && (int)e.Button == 1048576)
		{
			bool_5 = true;
			timer_0.Enabled = true;
			((Control)this).Invalidate();
		}
		else
		{
			if (!rectangle_0.Contains(e.Location) || (int)e.Button != 1048576)
			{
				return;
			}
			if (darkScrollOrientation_0 == DarkScrollOrientation.Vertical)
			{
				if (!new Rectangle(rectangle_1.Left, rectangle_0.Top, rectangle_1.Width, rectangle_0.Height).Contains(e.Location))
				{
					return;
				}
			}
			else if (darkScrollOrientation_0 == DarkScrollOrientation.Horizontal && !new Rectangle(rectangle_0.Left, rectangle_1.Top, rectangle_0.Width, rectangle_1.Height).Contains(e.Location))
			{
				return;
			}
			if (darkScrollOrientation_0 == DarkScrollOrientation.Vertical)
			{
				int y = e.Location.Y;
				y -= rectangle_2.Bottom - 1;
				y -= rectangle_1.Height / 2;
				ScrollToPhysical(y);
			}
			else
			{
				int x = e.Location.X;
				x -= rectangle_2.Right - 1;
				x -= rectangle_1.Width / 2;
				ScrollToPhysical(x);
			}
			bool_6 = true;
			point_0 = e.Location;
			bool_0 = true;
			if (darkScrollOrientation_0 != DarkScrollOrientation.Vertical)
			{
				int_4 = rectangle_1.Left;
			}
			else
			{
				int_4 = rectangle_1.Top;
			}
			((Control)this).Invalidate();
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		((Control)this).OnMouseUp(e);
		bool_6 = false;
		bool_3 = false;
		bool_4 = false;
		bool_5 = false;
		((Control)this).Invalidate();
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Invalid comparison between Unknown and I4
		((Control)this).OnMouseMove(e);
		if (!bool_6)
		{
			bool flag = rectangle_1.Contains(e.Location);
			if (bool_0 != flag)
			{
				bool_0 = flag;
				((Control)this).Invalidate();
			}
			bool flag2 = rectangle_2.Contains(e.Location);
			if (bool_1 != flag2)
			{
				bool_1 = flag2;
				((Control)this).Invalidate();
			}
			bool flag3 = rectangle_3.Contains(e.Location);
			if (bool_2 != flag3)
			{
				bool_2 = flag3;
				((Control)this).Invalidate();
			}
		}
		if (!bool_6)
		{
			return;
		}
		if ((int)e.Button != 1048576)
		{
			((Control)this).OnMouseUp((MouseEventArgs)null);
			return;
		}
		Point point = new Point(e.Location.X - point_0.X, e.Location.Y - point_0.Y);
		if (darkScrollOrientation_0 != DarkScrollOrientation.Vertical)
		{
			if (darkScrollOrientation_0 == DarkScrollOrientation.Horizontal)
			{
				int positionInPixels = int_4 - rectangle_0.Left + point.X;
				ScrollToPhysical(positionInPixels);
			}
		}
		else
		{
			int positionInPixels2 = int_4 - rectangle_0.Top + point.Y;
			ScrollToPhysical(positionInPixels2);
		}
		UpdateScrollBar();
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		((Control)this).OnMouseLeave(e);
		bool_0 = false;
		bool_1 = false;
		bool_2 = false;
		((Control)this).Invalidate();
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (!bool_4 && !bool_5)
		{
			timer_0.Enabled = false;
		}
		else if (!bool_4)
		{
			if (bool_5)
			{
				ScrollBy(1);
			}
		}
		else
		{
			ScrollBy(-1);
		}
	}

	public void ScrollTo(int position)
	{
		Value = position;
	}

	public void ScrollToPhysical(int positionInPixels)
	{
		int num = ((darkScrollOrientation_0 != DarkScrollOrientation.Vertical) ? (rectangle_0.Width - rectangle_1.Width) : (rectangle_0.Height - rectangle_1.Height));
		float num2 = (float)positionInPixels / (float)num;
		int num3 = Maximum - ViewSize;
		int value = (int)(num2 * (float)num3);
		Value = value;
	}

	public void ScrollBy(int offset)
	{
		int position = Value + offset;
		ScrollTo(position);
	}

	public void ScrollByPhysical(int offsetInPixels)
	{
		int positionInPixels = ((darkScrollOrientation_0 == DarkScrollOrientation.Vertical) ? (rectangle_1.Top - rectangle_0.Top) : (rectangle_1.Left - rectangle_0.Left)) - offsetInPixels;
		ScrollToPhysical(positionInPixels);
	}

	public void UpdateScrollBar()
	{
		Rectangle clientRectangle = ((Control)this).ClientRectangle;
		if (darkScrollOrientation_0 != DarkScrollOrientation.Vertical)
		{
			if (darkScrollOrientation_0 == DarkScrollOrientation.Horizontal)
			{
				rectangle_2 = new Rectangle(clientRectangle.Left, clientRectangle.Top, Consts.ArrowButtonSize, Consts.ArrowButtonSize);
				rectangle_3 = new Rectangle(clientRectangle.Right - Consts.ArrowButtonSize, clientRectangle.Top, Consts.ArrowButtonSize, Consts.ArrowButtonSize);
			}
		}
		else
		{
			rectangle_2 = new Rectangle(clientRectangle.Left, clientRectangle.Top, Consts.ArrowButtonSize, Consts.ArrowButtonSize);
			rectangle_3 = new Rectangle(clientRectangle.Left, clientRectangle.Bottom - Consts.ArrowButtonSize, Consts.ArrowButtonSize, Consts.ArrowButtonSize);
		}
		if (darkScrollOrientation_0 == DarkScrollOrientation.Vertical)
		{
			rectangle_0 = new Rectangle(clientRectangle.Left, clientRectangle.Top + Consts.ArrowButtonSize, clientRectangle.Width, clientRectangle.Height - Consts.ArrowButtonSize * 2);
		}
		else if (darkScrollOrientation_0 == DarkScrollOrientation.Horizontal)
		{
			rectangle_0 = new Rectangle(clientRectangle.Left + Consts.ArrowButtonSize, clientRectangle.Top, clientRectangle.Width - Consts.ArrowButtonSize * 2, clientRectangle.Height);
		}
		method_0();
		((Control)this).Invalidate();
	}

	private void method_0(bool bool_7 = false)
	{
		if (ViewSize >= Maximum)
		{
			return;
		}
		int num = Maximum - ViewSize;
		if (Value > num)
		{
			Value = num;
		}
		float_0 = (float)ViewSize / (float)Maximum;
		int num2 = Maximum - ViewSize;
		float num3 = (float)Value / (float)num2;
		if (darkScrollOrientation_0 == DarkScrollOrientation.Vertical)
		{
			int num4 = (int)((float)rectangle_0.Height * float_0);
			if (num4 < Consts.MinimumThumbSize)
			{
				num4 = Consts.MinimumThumbSize;
			}
			int num5 = (int)((float)(rectangle_0.Height - num4) * num3);
			rectangle_1 = new Rectangle(rectangle_0.Left + 3, rectangle_0.Top + num5, Consts.ScrollBarSize - 6, num4);
		}
		else if (darkScrollOrientation_0 == DarkScrollOrientation.Horizontal)
		{
			int num6 = (int)((float)rectangle_0.Width * float_0);
			if (num6 < Consts.MinimumThumbSize)
			{
				num6 = Consts.MinimumThumbSize;
			}
			int num7 = (int)((float)(rectangle_0.Width - num6) * num3);
			rectangle_1 = new Rectangle(rectangle_0.Left + num7, rectangle_0.Top + 3, num6, Consts.ScrollBarSize - 6);
		}
		if (bool_7)
		{
			((Control)this).Invalidate();
			((Control)this).Update();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		Bitmap val = ((!bool_1) ? ScrollIcons.scrollbar_arrow_standard : ScrollIcons.scrollbar_arrow_hot);
		if (bool_4)
		{
			val = ScrollIcons.scrollbar_arrow_clicked;
		}
		if (!((Control)this).Enabled)
		{
			val = ScrollIcons.scrollbar_arrow_disabled;
		}
		if (darkScrollOrientation_0 != DarkScrollOrientation.Vertical)
		{
			if (darkScrollOrientation_0 == DarkScrollOrientation.Horizontal)
			{
				((Image)val).RotateFlip((RotateFlipType)1);
			}
		}
		else
		{
			((Image)val).RotateFlip((RotateFlipType)6);
		}
		graphics.DrawImageUnscaled((Image)(object)val, rectangle_2.Left + rectangle_2.Width / 2 - ((Image)val).Width / 2, rectangle_2.Top + rectangle_2.Height / 2 - ((Image)val).Height / 2);
		Bitmap val2 = (bool_2 ? ScrollIcons.scrollbar_arrow_hot : ScrollIcons.scrollbar_arrow_standard);
		if (bool_5)
		{
			val2 = ScrollIcons.scrollbar_arrow_clicked;
		}
		if (!((Control)this).Enabled)
		{
			val2 = ScrollIcons.scrollbar_arrow_disabled;
		}
		if (darkScrollOrientation_0 == DarkScrollOrientation.Horizontal)
		{
			((Image)val2).RotateFlip((RotateFlipType)3);
		}
		graphics.DrawImageUnscaled((Image)(object)val2, rectangle_3.Left + rectangle_3.Width / 2 - ((Image)val2).Width / 2, rectangle_3.Top + rectangle_3.Height / 2 - ((Image)val2).Height / 2);
		if (((Control)this).Enabled)
		{
			Color color = (bool_0 ? Colors.GreyHighlight : Colors.GreySelection);
			if (bool_6)
			{
				color = Colors.ActiveControl;
			}
			SolidBrush val3 = new SolidBrush(color);
			try
			{
				graphics.FillRectangle((Brush)(object)val3, rectangle_1);
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
		}
	}

	static DarkScrollBar()
	{
		Class72.smethod_20();
	}
}
