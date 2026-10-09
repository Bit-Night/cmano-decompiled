using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkDropdownList : Control
{
	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private DarkControlState darkControlState_0;

	private ObservableCollection<DarkDropdownItem> observableCollection_0 = new ObservableCollection<DarkDropdownItem>();

	private DarkDropdownItem KaTetDgeMnF;

	private DarkContextMenu darkContextMenu_0 = new DarkContextMenu();

	private bool bool_0;

	private bool bool_1 = true;

	private int int_0 = 22;

	private int int_1 = 130;

	private readonly int int_2 = 16;

	private ToolStripDropDownDirection toolStripDropDownDirection_0 = (ToolStripDropDownDirection)7;

	private bool bool_2 = true;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ObservableCollection<DarkDropdownItem> Items => observableCollection_0;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public DarkDropdownItem SelectedItem
	{
		get
		{
			return KaTetDgeMnF;
		}
		set
		{
			KaTetDgeMnF = value;
			eventHandler_0?.Invoke(this, new EventArgs());
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectedIndex
	{
		get
		{
			return Items.IndexOf(KaTetDgeMnF);
		}
		set
		{
			KaTetDgeMnF = Items[value];
			eventHandler_0?.Invoke(this, new EventArgs());
		}
	}

	[Description("Determines whether a border is drawn around the control.")]
	[DefaultValue(true)]
	[Category("Appearance")]
	public bool ShowBorder
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

	protected override Size DefaultSize => new Size(100, 26);

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public DarkControlState ControlState => darkControlState_0;

	[Description("Determines the height of the individual list view items.")]
	[DefaultValue(22)]
	[Category("Appearance")]
	public int ItemHeight
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			ResizeMenu(setWidth: true, setHeight: true);
		}
	}

	[DefaultValue(130)]
	[Description("Determines the maximum height of the dropdown panel.")]
	[Category("Appearance")]
	public int MaxHeight
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
			ResizeMenu(setWidth: true, setHeight: true);
		}
	}

	[DefaultValue(/*Could not decode attribute arguments.*/)]
	[Description("Determines what location the dropdown list appears.")]
	[Category("Behavior")]
	public ToolStripDropDownDirection DropdownDirection
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return toolStripDropDownDirection_0;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			toolStripDropDownDirection_0 = value;
		}
	}

	[DefaultValue(true)]
	[Description("Auto-resize menu after each item addition/removal (can be slow with lots of items)")]
	[Category("Behavior")]
	public bool AutoResizeOnItemChange
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public event EventHandler SelectedItemChanged
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

	public DarkDropdownList()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		((Control)this).SetStyle((ControlStyles)132626, true);
		((Control)darkContextMenu_0).AutoSize = false;
		((ToolStripDropDown)darkContextMenu_0).Closed += new ToolStripDropDownClosedEventHandler(darkContextMenu_0_Closed);
		Items.CollectionChanged += method_3;
		SelectedItemChanged += DarkDropdownList_SelectedItemChanged;
		method_1(DarkControlState.Normal);
	}

	private ToolStripMenuItem method_0(DarkDropdownItem darkDropdownItem_0)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		foreach (ToolStripMenuItem item in (ArrangedElementCollection)((ToolStrip)darkContextMenu_0).Items)
		{
			ToolStripMenuItem val = item;
			if ((DarkDropdownItem)((ToolStripItem)val).Tag == darkDropdownItem_0)
			{
				return val;
			}
		}
		return null;
	}

	private void method_1(DarkControlState darkControlState_1)
	{
		if (!bool_0 && darkControlState_0 != darkControlState_1)
		{
			darkControlState_0 = darkControlState_1;
			((Control)this).Invalidate();
		}
	}

	private void method_2()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Invalid comparison between Unknown and I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		if (!((ToolStripDropDown)darkContextMenu_0).Visible)
		{
			method_1(DarkControlState.Pressed);
			bool_0 = true;
			Point point = new Point(0, ((Control)this).ClientRectangle.Bottom);
			if ((int)toolStripDropDownDirection_0 == 0 || (int)toolStripDropDownDirection_0 == 1)
			{
				point.Y = 0;
			}
			((ToolStripDropDown)darkContextMenu_0).Show((Control)(object)this, point, toolStripDropDownDirection_0);
			if (SelectedItem != null)
			{
				((ToolStripItem)method_0(SelectedItem)).Select();
			}
		}
	}

	public void PopulateSelections(string[] SelectionsArray)
	{
		Items.Clear();
		int num = 0;
		foreach (string text in SelectionsArray)
		{
			DarkDropdownItem darkDropdownItem = new DarkDropdownItem();
			darkDropdownItem.Text = text;
			darkDropdownItem.Value = Convert.ToString(num);
			Items.Add(darkDropdownItem);
			num++;
		}
	}

	public void ResizeMenu(bool setWidth, bool setHeight)
	{
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		if (!setWidth && !setHeight)
		{
			return;
		}
		int width = ((Control)this).ClientRectangle.Width;
		int num = ((ArrangedElementCollection)((ToolStrip)darkContextMenu_0).Items).Count * int_0 + 4;
		if (num > int_1)
		{
			num = int_1;
		}
		if (setWidth)
		{
			foreach (ToolStripMenuItem item in (ArrangedElementCollection)((ToolStrip)darkContextMenu_0).Items)
			{
				ToolStripMenuItem val = item;
				if (!((ToolStripItem)val).AutoSize)
				{
					((ToolStripItem)val).AutoSize = true;
				}
				if (((ToolStripItem)val).Size.Width > width)
				{
					width = ((ToolStripItem)val).Size.Width;
				}
				((ToolStripItem)val).AutoSize = false;
			}
		}
		foreach (ToolStripMenuItem item2 in (ArrangedElementCollection)((ToolStrip)darkContextMenu_0).Items)
		{
			((ToolStripItem)item2).Size = new Size(width - 1, int_0);
		}
		if (!(setWidth && setHeight))
		{
			if (!(!setWidth && setHeight))
			{
				if (setWidth && !setHeight)
				{
					((Control)darkContextMenu_0).Size = new Size(width, ((Control)darkContextMenu_0).Size.Height);
				}
			}
			else
			{
				((Control)darkContextMenu_0).Size = new Size(((Control)darkContextMenu_0).Size.Width, num);
			}
		}
		else
		{
			((Control)darkContextMenu_0).Size = new Size(width, num);
		}
	}

	private void method_3(object sender, NotifyCollectionChangedEventArgs e)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		if (e.Action == NotifyCollectionChangedAction.Add)
		{
			foreach (DarkDropdownItem newItem in e.NewItems)
			{
				ToolStripMenuItem val = new ToolStripMenuItem(newItem.Text)
				{
					Image = (Image)(object)newItem.Icon,
					AutoSize = false,
					Height = int_0,
					Font = ((Control)this).Font,
					Tag = newItem,
					TextAlign = (ContentAlignment)16
				};
				((ToolStrip)darkContextMenu_0).Items.Add((ToolStripItem)(object)val);
				((ToolStripItem)val).Click += method_4;
				if (SelectedItem == null)
				{
					SelectedItem = newItem;
				}
			}
		}
		if (e.Action == NotifyCollectionChangedAction.Remove)
		{
			foreach (DarkDropdownItem oldItem in e.OldItems)
			{
				foreach (ToolStripMenuItem item in (ArrangedElementCollection)((ToolStrip)darkContextMenu_0).Items)
				{
					ToolStripMenuItem val2 = item;
					if ((DarkDropdownItem)((ToolStripItem)val2).Tag == oldItem)
					{
						((ToolStrip)darkContextMenu_0).Items.Remove((ToolStripItem)(object)val2);
					}
				}
			}
		}
		if (bool_2)
		{
			ResizeMenu(setWidth: true, setHeight: true);
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		ToolStripMenuItem val = (ToolStripMenuItem)((sender is ToolStripMenuItem) ? sender : null);
		if (val != null)
		{
			DarkDropdownItem darkDropdownItem = (DarkDropdownItem)((ToolStripItem)val).Tag;
			if (KaTetDgeMnF != darkDropdownItem)
			{
				SelectedItem = darkDropdownItem;
			}
		}
	}

	private void DarkDropdownList_SelectedItemChanged(object sender, EventArgs e)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		foreach (ToolStripMenuItem item in (ArrangedElementCollection)((ToolStrip)darkContextMenu_0).Items)
		{
			ToolStripMenuItem val = item;
			if ((DarkDropdownItem)((ToolStripItem)val).Tag == SelectedItem)
			{
				((ToolStripItem)val).BackColor = Colors.DarkBlueBackground;
				((ToolStripItem)val).Font = new Font(((Control)this).Font, (FontStyle)1);
			}
			else
			{
				((ToolStripItem)val).BackColor = Colors.GreyBackground;
				((ToolStripItem)val).Font = new Font(((Control)this).Font, (FontStyle)0);
			}
		}
		((Control)this).Invalidate();
	}

	protected override void OnResize(EventArgs e)
	{
		((Control)this).OnResize(e);
		ResizeMenu(setWidth: true, setHeight: true);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		((Control)this).OnMouseMove(e);
		if ((int)e.Button == 1048576)
		{
			if (!((Control)this).ClientRectangle.Contains(e.Location))
			{
				method_1(DarkControlState.Hover);
			}
			else
			{
				method_1(DarkControlState.Pressed);
			}
		}
		else
		{
			method_1(DarkControlState.Hover);
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		((Control)this).OnMouseDown(e);
		method_2();
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		((Control)this).OnMouseUp(e);
		method_1(DarkControlState.Normal);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		((Control)this).OnMouseLeave(e);
		method_1(DarkControlState.Normal);
	}

	protected override void OnMouseCaptureChanged(EventArgs e)
	{
		((Control)this).OnMouseCaptureChanged(e);
		Point position = Cursor.Position;
		if (!((Control)this).ClientRectangle.Contains(position))
		{
			method_1(DarkControlState.Normal);
		}
	}

	protected override void OnGotFocus(EventArgs e)
	{
		((Control)this).OnGotFocus(e);
		((Control)this).Invalidate();
	}

	protected override void OnLostFocus(EventArgs e)
	{
		((Control)this).OnLostFocus(e);
		Point position = Cursor.Position;
		if (!((Control)this).ClientRectangle.Contains(position))
		{
			method_1(DarkControlState.Normal);
		}
		else
		{
			method_1(DarkControlState.Hover);
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		((Control)this).OnKeyDown(e);
		if ((int)e.KeyCode == 32)
		{
			method_2();
		}
	}

	private void darkContextMenu_0_Closed(object sender, ToolStripDropDownClosedEventArgs e)
	{
		bool_0 = false;
		if (!((Control)this).ClientRectangle.Contains(Control.MousePosition))
		{
			method_1(DarkControlState.Normal);
		}
		else
		{
			method_1(DarkControlState.Hover);
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		SolidBrush val = new SolidBrush(Colors.MediumBackground);
		try
		{
			graphics.FillRectangle((Brush)(object)val, ((Control)this).ClientRectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		if (ControlState == DarkControlState.Normal && ShowBorder)
		{
			Pen val2 = new Pen(Colors.LightBorder, 1f);
			try
			{
				Rectangle rectangle = new Rectangle(((Control)this).ClientRectangle.Left, ((Control)this).ClientRectangle.Top, ((Control)this).ClientRectangle.Width - 1, ((Control)this).ClientRectangle.Height - 1);
				graphics.DrawRectangle(val2, rectangle);
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		if (ControlState == DarkControlState.Hover)
		{
			SolidBrush val3 = new SolidBrush(Colors.DarkBorder);
			try
			{
				graphics.FillRectangle((Brush)(object)val3, ((Control)this).ClientRectangle);
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
			SolidBrush val4 = new SolidBrush(Colors.DarkBackground);
			try
			{
				Rectangle rectangle2 = new Rectangle(((Control)this).ClientRectangle.Right - ((Image)DropdownIcons.small_arrow).Width - 8, ((Control)this).ClientRectangle.Top, ((Image)DropdownIcons.small_arrow).Width + 8, ((Control)this).ClientRectangle.Height);
				graphics.FillRectangle((Brush)(object)val4, rectangle2);
			}
			finally
			{
				((IDisposable)val4)?.Dispose();
			}
			Pen val5 = new Pen(Colors.BlueSelection, 1f);
			try
			{
				Rectangle rectangle3 = new Rectangle(((Control)this).ClientRectangle.Left, ((Control)this).ClientRectangle.Top, ((Control)this).ClientRectangle.Width - 1 - ((Image)DropdownIcons.small_arrow).Width - 8, ((Control)this).ClientRectangle.Height - 1);
				graphics.DrawRectangle(val5, rectangle3);
			}
			finally
			{
				((IDisposable)val5)?.Dispose();
			}
		}
		if (ControlState == DarkControlState.Pressed)
		{
			SolidBrush val6 = new SolidBrush(Colors.DarkBorder);
			try
			{
				graphics.FillRectangle((Brush)(object)val6, ((Control)this).ClientRectangle);
			}
			finally
			{
				((IDisposable)val6)?.Dispose();
			}
			SolidBrush val7 = new SolidBrush(Colors.BlueSelection);
			try
			{
				Rectangle rectangle4 = new Rectangle(((Control)this).ClientRectangle.Right - ((Image)DropdownIcons.small_arrow).Width - 8, ((Control)this).ClientRectangle.Top, ((Image)DropdownIcons.small_arrow).Width + 8, ((Control)this).ClientRectangle.Height);
				graphics.FillRectangle((Brush)(object)val7, rectangle4);
			}
			finally
			{
				((IDisposable)val7)?.Dispose();
			}
		}
		Bitmap small_arrow = DropdownIcons.small_arrow;
		try
		{
			graphics.DrawImageUnscaled((Image)(object)small_arrow, ((Control)this).ClientRectangle.Right - ((Image)small_arrow).Width - 4, ((Control)this).ClientRectangle.Top + ((Control)this).ClientRectangle.Height / 2 - ((Image)small_arrow).Height / 2);
		}
		finally
		{
			((IDisposable)small_arrow)?.Dispose();
		}
		if (SelectedItem == null)
		{
			return;
		}
		bool flag;
		if (flag = SelectedItem.Icon != null)
		{
			graphics.DrawImageUnscaled((Image)(object)SelectedItem.Icon, new Point(((Control)this).ClientRectangle.Left + 5, ((Control)this).ClientRectangle.Top + ((Control)this).ClientRectangle.Height / 2 - int_2 / 2));
		}
		SolidBrush val8 = new SolidBrush(Colors.LightText);
		try
		{
			StringFormat val9 = new StringFormat
			{
				Alignment = (StringAlignment)0,
				LineAlignment = (StringAlignment)1
			};
			Rectangle rectangle5 = new Rectangle(((Control)this).ClientRectangle.Left + 2, ((Control)this).ClientRectangle.Top, ((Control)this).ClientRectangle.Width - 16, ((Control)this).ClientRectangle.Height);
			if (flag)
			{
				rectangle5.X += int_2 + 7;
				rectangle5.Width -= int_2 + 7;
			}
			graphics.DrawString(SelectedItem.Text, ((Control)this).Font, (Brush)(object)val8, (RectangleF)rectangle5, val9);
		}
		finally
		{
			((IDisposable)val8)?.Dispose();
		}
	}

	static DarkDropdownList()
	{
		Class72.smethod_20();
	}
}
