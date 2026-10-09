using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkListView : DarkScrollView
{
	[CompilerGenerated]
	private EventHandler eventHandler_2;

	[CompilerGenerated]
	private EventHandler eventHandler_3;

	[CompilerGenerated]
	private EventHandler eventHandler_4;

	private readonly ToolTip toolTip_0 = new ToolTip();

	private DarkListItem darkListItem_0;

	private int int_2 = 20;

	private bool bool_4;

	private readonly int int_3 = 16;

	private ObservableCollection<DarkListItem> observableCollection_0;

	private List<int> list_0;

	private int int_4 = -1;

	private int int_5 = -1;

	private bool bool_5 = true;

	[CompilerGenerated]
	private bool bool_6;

	[CompilerGenerated]
	private List<KeyValuePair<string, string>> list_1;

	public float[] tabStops;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ObservableCollection<DarkListItem> Items
	{
		get
		{
			return observableCollection_0;
		}
		set
		{
			if (observableCollection_0 != null)
			{
				observableCollection_0.CollectionChanged -= observableCollection_0_CollectionChanged;
			}
			observableCollection_0 = value;
			observableCollection_0.CollectionChanged += observableCollection_0_CollectionChanged;
			method_11();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public List<int> SelectedIndices => list_0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public List<DarkListItem> SelectedItems
	{
		get
		{
			List<DarkListItem> list = new List<DarkListItem>();
			foreach (int selectedIndex in SelectedIndices)
			{
				list.Add(Items[selectedIndex]);
			}
			return list;
		}
	}

	[DefaultValue(20)]
	[Category("Appearance")]
	[Description("Determines the height of the individual list view items.")]
	public int ItemHeight
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
			method_11();
		}
	}

	[DefaultValue(false)]
	[Description("Determines whether multiple list view items can be selected at once.")]
	[Category("Behaviour")]
	public bool MultiSelect
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	[Category("Behavior")]
	[Description("Auto-resize list after each item addition/removal (can be slow with lots of items)")]
	[DefaultValue(true)]
	public bool AutoResizeOnItemChange
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	[DefaultValue(false)]
	[Category("Appearance")]
	[Description("Determines whether icons are rendered with the list items.")]
	public bool ShowIcons
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
		[CompilerGenerated]
		set
		{
			bool_6 = value;
		}
	}

	public List<KeyValuePair<string, string>> RelatedInfos
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
		[CompilerGenerated]
		set
		{
			list_1 = value;
		}
	}

	public event EventHandler SelectedIndicesChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler DrawListItem
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_3;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_3, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_3;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_3, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler ContextMenuItem_Click
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_4;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_4, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_4;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_4, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public DarkListView()
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		Items = new ObservableCollection<DarkListItem>();
		list_0 = new List<int>();
	}

	private void observableCollection_0_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (((Control)this).IsDisposed)
		{
			return;
		}
		if (e.NewItems != null)
		{
			Graphics val = ((Control)this).CreateGraphics();
			try
			{
				foreach (DarkListItem newItem in e.NewItems)
				{
					newItem.TextChanged += method_8;
					method_13(newItem, val);
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			if (e.NewStartingIndex < Items.Count - 1)
			{
				for (int i = e.NewStartingIndex; i <= Items.Count - 1; i++)
				{
					method_14(Items[i], i);
				}
			}
		}
		if (e.OldItems != null)
		{
			foreach (DarkListItem oldItem in e.OldItems)
			{
				oldItem.TextChanged -= method_8;
			}
			if (e.OldStartingIndex < Items.Count - 1)
			{
				for (int j = e.OldStartingIndex; j <= Items.Count - 1; j++)
				{
					method_14(Items[j], j);
				}
			}
		}
		if (Items.Count == 0 && list_0.Count > 0)
		{
			list_0.Clear();
			if (eventHandler_2 != null)
			{
				eventHandler_2(this, null);
			}
		}
		if (bool_5)
		{
			UpdateContentSize();
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		DarkListItem darkListItem_ = (DarkListItem)sender;
		method_12(darkListItem_);
		method_15(darkListItem_);
		((Control)this).Invalidate();
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Invalid comparison between Unknown and I4
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Invalid comparison between Unknown and I4
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Invalid comparison between Unknown and I4
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		base.OnMouseDown(e);
		if (Items.Count == 0 || ((int)e.Button != 1048576 && (int)e.Button != 2097152))
		{
			return;
		}
		if ((int)e.Button == 2097152 && RelatedInfos != null && SelectedItems != null && SelectedItems.Count == 1)
		{
			ContextMenu val = new ContextMenu();
			foreach (KeyValuePair<string, string> relatedInfo in RelatedInfos)
			{
				bool flag = false;
				if (!(relatedInfo.Key == SelectedItems.First().Tag.ToString()))
				{
					continue;
				}
				foreach (MenuItem item in ((IEnumerable)((Menu)val).MenuItems).OfType<MenuItem>())
				{
					if (item.Text == relatedInfo.Value)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					MenuItem val2 = new MenuItem(relatedInfo.Value);
					((Menu)val2).Tag = relatedInfo.Value;
					((Menu)val).MenuItems.Add(val2);
					val2.Click += method_9;
				}
			}
			val.Show((Control)(object)this, new Point(e.X, e.Y));
		}
		Point offsetMousePosition = base.OffsetMousePosition;
		List<int> source = method_16().ToList();
		int num = source.Min();
		int num2 = source.Max();
		int width = Math.Max(base.ContentSize.Width, base.Viewport.Width);
		for (int i = num; i <= num2; i++)
		{
			if (new Rectangle(0, i * ItemHeight, width, ItemHeight).Contains(offsetMousePosition))
			{
				if (MultiSelect && (int)Control.ModifierKeys == 65536)
				{
					method_10(i);
				}
				else if (MultiSelect && (int)Control.ModifierKeys == 131072)
				{
					ToggleItem(i);
				}
				else
				{
					SelectItem(i);
				}
			}
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		eventHandler_4?.Invoke(sender, e);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Invalid comparison between Unknown and I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Invalid comparison between Unknown and I4
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Invalid comparison between Unknown and I4
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Invalid comparison between Unknown and I4
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Invalid comparison between Unknown and I4
		((Control)this).OnKeyDown(e);
		if (Items.Count == 0)
		{
			return;
		}
		if (MultiSelect && (int)Control.ModifierKeys == 65536)
		{
			if ((int)e.KeyCode == 38)
			{
				if (int_5 - 1 >= 0)
				{
					method_10(int_5 - 1);
					EnsureVisible();
					e.Handled = base.HandlesEvents;
				}
			}
			else if ((int)e.KeyCode == 40 && int_5 + 1 <= Items.Count - 1)
			{
				method_10(int_5 + 1);
				e.Handled = base.HandlesEvents;
			}
		}
		else if ((int)e.KeyCode == 38)
		{
			if (int_5 - 1 >= 0)
			{
				SelectItem(int_5 - 1);
			}
			e.Handled = base.HandlesEvents;
		}
		else if ((int)e.KeyCode == 40)
		{
			if (int_5 + 1 <= Items.Count - 1)
			{
				SelectItem(int_5 + 1);
			}
			e.Handled = base.HandlesEvents;
		}
		if ((int)Control.ModifierKeys != 65536)
		{
			EnsureVisible();
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		Point point_0 = base.OffsetMousePosition;
		DarkListItem darkListItem = Items.FirstOrDefault((DarkListItem i) => i.Area.Contains(point_0));
		if (darkListItem != darkListItem_0)
		{
			darkListItem_0 = darkListItem;
			toolTip_0.Hide((IWin32Window)(object)this);
			if (darkListItem != null && !string.IsNullOrEmpty(darkListItem.ToolTipText))
			{
				toolTip_0.Show(darkListItem.ToolTipText, (IWin32Window)(object)this, e.Location.X + 12, e.Location.Y + 12, 4000);
			}
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		((Control)this).OnMouseLeave(e);
		darkListItem_0 = null;
		toolTip_0.Hide((IWin32Window)(object)this);
	}

	public int GetItemIndex(DarkListItem item)
	{
		return Items.IndexOf(item);
	}

	public void SelectItem(int index, bool ThrowE = true)
	{
		if (index >= 0 && index <= Items.Count - 1)
		{
			list_0.Clear();
			list_0.Add(index);
			if (eventHandler_2 != null)
			{
				eventHandler_2(this, null);
			}
			int_4 = index;
			int_5 = index;
			((Control)this).Invalidate();
		}
		else if (ThrowE)
		{
			throw new IndexOutOfRangeException($"Value '{index}' is outside of valid range.");
		}
	}

	public void SelectItems(IEnumerable<int> indexes)
	{
		list_0.Clear();
		List<int> list = indexes.ToList();
		foreach (int item in list)
		{
			if (item >= 0 && item <= Items.Count - 1)
			{
				list_0.Add(item);
				continue;
			}
			throw new IndexOutOfRangeException($"Value '{item}' is outside of valid range.");
		}
		if (eventHandler_2 != null)
		{
			eventHandler_2(this, null);
		}
		int_4 = list[list.Count - 1];
		int_5 = list[list.Count - 1];
		((Control)this).Invalidate();
	}

	public void ToggleItem(int index)
	{
		if (list_0.Contains(index))
		{
			list_0.Remove(index);
			if (int_4 == index && int_5 == index)
			{
				if (list_0.Count <= 0)
				{
					int_4 = -1;
					int_5 = -1;
				}
				else
				{
					int_4 = list_0[0];
					int_5 = list_0[0];
				}
			}
			if (int_4 == index)
			{
				if (int_5 < index)
				{
					int_4 = index - 1;
				}
				else if (int_5 <= index)
				{
					int_4 = int_5;
				}
				else
				{
					int_4 = index + 1;
				}
			}
			if (int_5 == index)
			{
				if (int_4 >= index)
				{
					if (int_4 > index)
					{
						int_5 = index + 1;
					}
					else
					{
						int_5 = int_4;
					}
				}
				else
				{
					int_5 = index - 1;
				}
			}
		}
		else
		{
			list_0.Add(index);
			int_4 = index;
			int_5 = index;
		}
		if (eventHandler_2 != null)
		{
			eventHandler_2(this, null);
		}
		((Control)this).Invalidate();
	}

	public void SelectItems(int startRange, int endRange)
	{
		list_0.Clear();
		if (startRange == endRange)
		{
			list_0.Add(startRange);
		}
		if (startRange >= endRange)
		{
			if (startRange > endRange)
			{
				for (int num = startRange; num >= endRange; num--)
				{
					list_0.Add(num);
				}
			}
		}
		else
		{
			for (int i = startRange; i <= endRange; i++)
			{
				list_0.Add(i);
			}
		}
		if (eventHandler_2 != null)
		{
			eventHandler_2(this, null);
		}
		((Control)this).Invalidate();
	}

	private void method_10(int int_6)
	{
		int_5 = int_6;
		SelectItems(int_4, int_6);
	}

	private void method_11()
	{
		Graphics val = ((Control)this).CreateGraphics();
		try
		{
			for (int i = 0; i <= Items.Count - 1; i++)
			{
				DarkListItem darkListItem_ = Items[i];
				method_13(darkListItem_, val);
				method_14(darkListItem_, i);
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		UpdateContentSize();
	}

	private void method_12(DarkListItem darkListItem_1)
	{
		Graphics val = ((Control)this).CreateGraphics();
		try
		{
			method_13(darkListItem_1, val);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private void method_13(DarkListItem darkListItem_1, Graphics graphics_0)
	{
		SizeF sizeF = graphics_0.MeasureString(darkListItem_1.Text, ((Control)this).Font);
		sizeF.Width++;
		if (ShowIcons)
		{
			sizeF.Width += int_3 + 8;
		}
		darkListItem_1.Area = new Rectangle(darkListItem_1.Area.Left, darkListItem_1.Area.Top, (int)sizeF.Width, ItemHeight);
	}

	private void method_14(DarkListItem darkListItem_1, int int_6)
	{
		darkListItem_1.Area = new Rectangle(2, int_6 * ItemHeight, darkListItem_1.Area.Width, ItemHeight);
	}

	public void UpdateContentSize()
	{
		int num = 0;
		foreach (DarkListItem item in Items)
		{
			if (item.Area.Right + 1 > num)
			{
				num = item.Area.Right + 1;
			}
		}
		int num2 = num;
		int num3 = Items.Count * ItemHeight;
		if (base.ContentSize.Width != num2 || base.ContentSize.Height != num3)
		{
			base.ContentSize = new Size(num2, num3);
			((Control)this).Invalidate();
		}
	}

	private void method_15(DarkListItem darkListItem_1)
	{
		int num = darkListItem_1.Area.Right + 1;
		if (num == base.ContentSize.Width)
		{
			UpdateContentSize();
		}
		else if (num > base.ContentSize.Width)
		{
			base.ContentSize = new Size(num, base.ContentSize.Height);
			((Control)this).Invalidate();
		}
	}

	public void EnsureVisible()
	{
		if (SelectedIndices.Count != 0)
		{
			int num = -1;
			num = (MultiSelect ? (int_5 * ItemHeight) : (SelectedIndices[0] * ItemHeight));
			int num2 = num + ItemHeight;
			if (num < base.Viewport.Top)
			{
				method_4(num);
			}
			if (num2 > base.Viewport.Bottom)
			{
				method_4(num2 - base.Viewport.Height);
			}
		}
	}

	private IEnumerable<int> method_16()
	{
		int num = base.Viewport.Top / ItemHeight - 1;
		if (num < 0)
		{
			num = 0;
		}
		int num2 = (base.Viewport.Top + base.Viewport.Height) / ItemHeight + 1;
		if (num2 > Items.Count)
		{
			num2 = Items.Count;
		}
		return Enumerable.Range(num, num2 - num);
	}

	private IEnumerable<DarkListItem> method_17()
	{
		return (from int_6 in method_16()
			select Items[int_6]).ToList();
	}

	protected override void PaintContent(Graphics g)
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		List<int> list = method_16().ToList();
		if (list.Count == 0)
		{
			return;
		}
		int num = list.Min();
		int num2 = list.Max();
		for (int i = num; i <= num2; i++)
		{
			int width = Math.Max(base.ContentSize.Width, base.Viewport.Width);
			Rectangle rectangle = new Rectangle(0, i * ItemHeight, width, ItemHeight);
			Color color = ((i % 2 != 0) ? Colors.GreyBackground : Colors.HeaderBackground);
			if (SelectedIndices.Count > 0 && SelectedIndices.Contains(i))
			{
				color = (((Control)this).Focused ? Colors.BlueSelection : Colors.GreySelection);
			}
			if (eventHandler_3 == null)
			{
				SolidBrush val = new SolidBrush(color);
				try
				{
					g.FillRectangle((Brush)(object)val, rectangle);
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
				if (ShowIcons && Items[i].Icon != null)
				{
					g.DrawImageUnscaled((Image)(object)Items[i].Icon, new Point(rectangle.Left + 5, rectangle.Top + rectangle.Height / 2 - int_3 / 2));
				}
				SolidBrush val2 = new SolidBrush(Items[i].TextColor);
				try
				{
					StringFormat val3 = new StringFormat
					{
						Alignment = (StringAlignment)0,
						LineAlignment = (StringAlignment)1
					};
					Font val4 = new Font(((Control)this).Font, Items[i].FontStyle);
					Rectangle rectangle2 = new Rectangle(rectangle.Left + 2, rectangle.Top, rectangle.Width, rectangle.Height);
					if (ShowIcons)
					{
						rectangle2.X += int_3 + 8;
					}
					g.TextRenderingHint = (TextRenderingHint)5;
					if (tabStops != null && Items[i].Text != null)
					{
						val3.FormatFlags = (StringFormatFlags)4096;
						val3.Trimming = (StringTrimming)4;
						val3.Alignment = (StringAlignment)0;
						string[] array = Items[i].Text.Split(new char[1] { '\t' });
						Rectangle rectangle3 = rectangle2;
						for (int j = 0; j < array.Length; j++)
						{
							if (j > tabStops.Length)
							{
								continue;
							}
							string text = array[j];
							if (j == 0)
							{
								rectangle3.Width = (int)tabStops[j];
							}
							else
							{
								rectangle3.Offset((int)tabStops[j - 1], 0);
								if (j == tabStops.Length)
								{
									rectangle3.Width = rectangle2.Width - rectangle3.X;
								}
								else
								{
									rectangle3.Width = (int)tabStops[j];
								}
							}
							g.DrawString(text, val4, (Brush)(object)val2, (RectangleF)rectangle3, val3);
						}
					}
					else
					{
						g.DrawString(Items[i].Text, val4, (Brush)(object)val2, (RectangleF)rectangle2, val3);
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			else
			{
				DrawDarkListViewListItemEventArgs e = new DrawDarkListViewListItemEventArgs();
				e.m_index = i;
				e.m_rect = rectangle;
				e.m_item = Items[i];
				e.m_selected = color == Colors.GreySelection;
				e.m_graphics = g;
				eventHandler_3(this, e);
			}
		}
	}

	[CompilerGenerated]
	private DarkListItem method_18(int int_6)
	{
		return Items[int_6];
	}

	static DarkListView()
	{
		Class72.smethod_20();
	}
}
