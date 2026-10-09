using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public abstract class DarkScrollBase : Control
{
	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[CompilerGenerated]
	private EventHandler eventHandler_1;

	public readonly DarkScrollBar _vScrollBar;

	public readonly DarkScrollBar _hScrollBar;

	private Size size_0;

	private Size RkbeSpfkbGb;

	private Rectangle rectangle_0;

	private Point point_0;

	private int int_0;

	private Timer timer_0;

	private int int_1 = 20;

	private bool bool_0 = true;

	[CompilerGenerated]
	private bool bool_1;

	private bool bool_2;

	[CompilerGenerated]
	private bool bool_3;

	[Category("Behavior")]
	[DefaultValue(false)]
	[Description("Set to true to make sure key events aren't spread to the rest of the form ")]
	public bool HandlesEvents
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	[Description("How many PIXELS one step of the mousewheel will increment/decrement the scrollview")]
	[Category("Behavior")]
	[DefaultValue(20)]
	public int MouseWheelStep
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
			((Control)this).Invalidate();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public Rectangle Viewport
	{
		get
		{
			return rectangle_0;
		}
		private set
		{
			rectangle_0 = value;
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, null);
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Size ContentSize
	{
		get
		{
			return RkbeSpfkbGb;
		}
		set
		{
			bool_2 = value.Width != RkbeSpfkbGb.Width || value.Height != RkbeSpfkbGb.Height;
			RkbeSpfkbGb = value;
			if (bool_2)
			{
				method_0();
			}
			if (eventHandler_1 != null)
			{
				eventHandler_1(this, null);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public Point OffsetMousePosition => point_0;

	[DefaultValue(0)]
	[Category("Behavior")]
	[Description("Determines the maximum scroll change when dragging.")]
	public int MaxDragChange
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			((Control)this).Invalidate();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsDragging
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		private set
		{
			bool_3 = value;
		}
	}

	[DefaultValue(true)]
	[Description("Determines whether scrollbars will remain visible when disabled.")]
	[Category("Behavior")]
	public bool HideScrollBars
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			method_0();
		}
	}

	public event EventHandler ViewportChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler ContentSizeChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	protected DarkScrollBase()
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		((Control)this).SetStyle((ControlStyles)1536, true);
		_vScrollBar = new DarkScrollBar
		{
			ScrollOrientation = DarkScrollOrientation.Vertical
		};
		_hScrollBar = new DarkScrollBar
		{
			ScrollOrientation = DarkScrollOrientation.Horizontal
		};
		((Control)this).Controls.Add((Control)(object)_vScrollBar);
		((Control)this).Controls.Add((Control)(object)_hScrollBar);
		_vScrollBar.ValueChanged += delegate
		{
			method_3();
		};
		_hScrollBar.ValueChanged += delegate
		{
			method_3();
		};
		((Control)_vScrollBar).MouseDown += (MouseEventHandler)delegate
		{
			((Control)this).Select();
		};
		((Control)_hScrollBar).MouseDown += (MouseEventHandler)delegate
		{
			((Control)this).Select();
		};
		timer_0 = new Timer();
		timer_0.Interval = 1;
		timer_0.Tick += timer_0_Tick;
	}

	private void method_0()
	{
		if (_vScrollBar.Maximum != ContentSize.Height)
		{
			_vScrollBar.Maximum = ContentSize.Height;
		}
		if (_hScrollBar.Maximum != ContentSize.Width)
		{
			_hScrollBar.Maximum = ContentSize.Width;
		}
		int scrollBarSize = Consts.ScrollBarSize;
		((Control)_vScrollBar).Location = new Point(((Control)this).ClientSize.Width - scrollBarSize, 0);
		((Control)_vScrollBar).Size = new Size(scrollBarSize, ((Control)this).ClientSize.Height);
		((Control)_hScrollBar).Location = new Point(0, ((Control)this).ClientSize.Height - scrollBarSize);
		((Control)_hScrollBar).Size = new Size(((Control)this).ClientSize.Width, scrollBarSize);
		if (!((Component)this).DesignMode)
		{
			method_2();
			method_1();
			method_2();
			method_1();
			if (_vScrollBar.Visible)
			{
				DarkScrollBar hScrollBar = _hScrollBar;
				((Control)hScrollBar).Width = ((Control)hScrollBar).Width - scrollBarSize;
			}
			if (_hScrollBar.Visible)
			{
				DarkScrollBar vScrollBar = _vScrollBar;
				((Control)vScrollBar).Height = ((Control)vScrollBar).Height - scrollBarSize;
			}
			_vScrollBar.ViewSize = size_0.Height;
			_hScrollBar.ViewSize = size_0.Width;
			method_3();
		}
	}

	private void method_1()
	{
		bool flag = size_0.Height < ContentSize.Height;
		bool flag2 = size_0.Width < ContentSize.Width;
		if (((Control)_vScrollBar).Enabled != flag)
		{
			((Control)_vScrollBar).Enabled = flag;
		}
		if (((Control)_hScrollBar).Enabled != flag2)
		{
			((Control)_hScrollBar).Enabled = flag2;
		}
		if (bool_0)
		{
			_vScrollBar.Visible = ((Control)_vScrollBar).Enabled;
			_hScrollBar.Visible = ((Control)_hScrollBar).Enabled;
		}
	}

	private void method_2()
	{
		int scrollBarSize = Consts.ScrollBarSize;
		size_0 = new Size(((Control)this).ClientSize.Width, ((Control)this).ClientSize.Height);
		if (_vScrollBar.Visible)
		{
			size_0.Width -= scrollBarSize;
		}
		if (_hScrollBar.Visible)
		{
			size_0.Height -= scrollBarSize;
		}
	}

	private void method_3()
	{
		if (!((Control)this).IsDisposed)
		{
			int x = 0;
			int y = 0;
			int num = ((Control)this).ClientSize.Width;
			int num2 = ((Control)this).ClientSize.Height;
			if (_hScrollBar.Visible)
			{
				x = _hScrollBar.Value;
				num2 -= ((Control)_hScrollBar).Height;
			}
			if (_vScrollBar.Visible)
			{
				y = _vScrollBar.Value;
				num -= ((Control)_vScrollBar).Width;
			}
			Viewport = new Rectangle(x, y, num, num2);
			Point point = ((Control)this).PointToClient(Control.MousePosition);
			point_0 = new Point(point.X + Viewport.Left, point.Y + Viewport.Top);
			((Control)this).Invalidate();
		}
	}

	public void ScrollTo(Point point)
	{
		method_5(point.X);
		method_4(point.Y);
	}

	public void method_4(int value, bool IgnoreVisibleCheck = false)
	{
		if (_vScrollBar.Visible || IgnoreVisibleCheck)
		{
			_vScrollBar.Value = value;
		}
	}

	public void method_5(int value)
	{
		if (_hScrollBar.Visible)
		{
			_hScrollBar.Value = value;
		}
	}

	protected virtual void StartDrag()
	{
		IsDragging = true;
		timer_0.Start();
	}

	protected virtual void StopDrag()
	{
		IsDragging = false;
		timer_0.Stop();
	}

	public Point PointToView(Point point)
	{
		return new Point(point.X - Viewport.Left, point.Y - Viewport.Top);
	}

	public Rectangle RectangleToView(Rectangle rect)
	{
		return new Rectangle(new Point(rect.Left - Viewport.Left, rect.Top - Viewport.Top), rect.Size);
	}

	protected override void OnCreateControl()
	{
		((Control)this).OnCreateControl();
		method_0();
	}

	protected override void OnGotFocus(EventArgs e)
	{
		((Control)this).OnGotFocus(e);
		((Control)this).Invalidate();
	}

	protected override void OnLostFocus(EventArgs e)
	{
		((Control)this).OnLostFocus(e);
		((Control)this).Invalidate();
	}

	protected override void OnResize(EventArgs e)
	{
		((Control)this).OnResize(e);
		method_0();
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		((Control)this).OnMouseMove(e);
		point_0 = new Point(e.X + Viewport.Left, e.Y + Viewport.Top);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		((Control)this).OnMouseDown(e);
		if ((int)e.Button == 2097152)
		{
			((Control)this).Select();
		}
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		((Control)this).OnMouseWheel(e);
		bool flag = false;
		if (_hScrollBar.Visible && (int)Control.ModifierKeys == 131072)
		{
			flag = true;
		}
		if (_hScrollBar.Visible && !_vScrollBar.Visible)
		{
			flag = true;
		}
		if (!flag)
		{
			if (e.Delta > 0)
			{
				_vScrollBar.ScrollByPhysical(MouseWheelStep);
			}
			else if (e.Delta < 0)
			{
				_vScrollBar.ScrollByPhysical(-MouseWheelStep);
			}
		}
		else if (e.Delta <= 0)
		{
			if (e.Delta < 0)
			{
				_hScrollBar.ScrollByPhysical(-MouseWheelStep);
			}
		}
		else
		{
			_hScrollBar.ScrollByPhysical(MouseWheelStep);
		}
	}

	protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected I4, but got Unknown
		((Control)this).OnPreviewKeyDown(e);
		Keys keyCode = e.KeyCode;
		switch (keyCode - 33)
		{
		case 1:
			method_4(_vScrollBar.Value + size_0.Height);
			e.IsInputKey = true;
			break;
		case 2:
			method_4(RkbeSpfkbGb.Height);
			e.IsInputKey = true;
			break;
		case 3:
			method_4(0);
			e.IsInputKey = true;
			break;
		case 6:
			break;
		case 0:
		case 4:
		case 5:
		case 7:
			method_4(_vScrollBar.Value - size_0.Height);
			e.IsInputKey = true;
			break;
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		Point point = ((Control)this).PointToClient(Control.MousePosition);
		int num = ((Control)this).ClientRectangle.Right;
		int num2 = ((Control)this).ClientRectangle.Bottom;
		if (_vScrollBar.Visible)
		{
			num = ((Control)_vScrollBar).Left;
		}
		if (_hScrollBar.Visible)
		{
			num2 = ((Control)_hScrollBar).Top;
		}
		if (_vScrollBar.Visible)
		{
			if (point.Y < ((Control)this).ClientRectangle.Top)
			{
				int num3 = (point.Y - ((Control)this).ClientRectangle.Top) * -1;
				if (MaxDragChange > 0 && num3 > MaxDragChange)
				{
					num3 = MaxDragChange;
				}
				_vScrollBar.Value -= num3;
			}
			if (point.Y > num2)
			{
				int num4 = point.Y - num2;
				if (MaxDragChange > 0 && num4 > MaxDragChange)
				{
					num4 = MaxDragChange;
				}
				_vScrollBar.Value += num4;
			}
		}
		if (!_hScrollBar.Visible)
		{
			return;
		}
		if (point.X < ((Control)this).ClientRectangle.Left)
		{
			int num5 = (point.X - ((Control)this).ClientRectangle.Left) * -1;
			if (MaxDragChange > 0 && num5 > MaxDragChange)
			{
				num5 = MaxDragChange;
			}
			_hScrollBar.Value -= num5;
		}
		if (point.X > num)
		{
			int num6 = point.X - num;
			if (MaxDragChange > 0 && num6 > MaxDragChange)
			{
				num6 = MaxDragChange;
			}
			_hScrollBar.Value += num6;
		}
	}

	[CompilerGenerated]
	private void method_6(object sender, ScrollValueEventArgs e)
	{
		method_3();
	}

	[CompilerGenerated]
	private void method_7(object sender, ScrollValueEventArgs e)
	{
		method_3();
	}

	[CompilerGenerated]
	private void _vScrollBar_MouseDown(object sender, MouseEventArgs e)
	{
		((Control)this).Select();
	}

	[CompilerGenerated]
	private void _hScrollBar_MouseDown(object sender, MouseEventArgs e)
	{
		((Control)this).Select();
	}

	static DarkScrollBase()
	{
		Class72.smethod_20();
	}
}
