using System;
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
using DarkUI.Collections;
using DarkUI.Config;
using DarkUI.Extensions;
using DarkUI.Forms;

namespace DarkUI.Controls;

public class DarkFilterTreeView : DarkScrollView
{
	public delegate void AfterNodeExpandDelegate(DarkFilterTreeView tree, DarkFilterTreeNode Node);

	public delegate void AfterNodeCollapseDelegate(DarkFilterTreeView tree, DarkFilterTreeNode Node);

	internal string FilterString;

	[CompilerGenerated]
	private EventHandler eventHandler_2;

	[CompilerGenerated]
	private AfterNodeExpandDelegate afterNodeExpandDelegate_0;

	[CompilerGenerated]
	private AfterNodeCollapseDelegate afterNodeCollapseDelegate_0;

	private bool bool_4;

	private readonly int int_2 = 16;

	private readonly int int_3 = 16;

	private int int_4 = 20;

	private int int_5 = 20;

	private ObservableList<DarkFilterTreeNode> observableList_0;

	private ObservableCollection<DarkFilterTreeNode> observableCollection_0;

	private DarkFilterTreeNode darkFilterTreeNode_0;

	private DarkFilterTreeNode darkFilterTreeNode_1;

	private Bitmap bitmap_0;

	private Bitmap bitmap_1;

	private Bitmap bitmap_2;

	private Bitmap bitmap_3;

	private Bitmap bitmap_4;

	private Bitmap bitmap_5;

	private DarkFilterTreeNode darkFilterTreeNode_2;

	private DarkFilterTreeNode darkFilterTreeNode_3;

	private bool bool_5;

	private List<DarkFilterTreeNode> list_0;

	private Point point_1;

	[CompilerGenerated]
	private bool bool_6;

	[CompilerGenerated]
	private bool bool_7;

	[CompilerGenerated]
	private bool bool_8;

	[CompilerGenerated]
	private int int_6;

	[CompilerGenerated]
	private IComparer<DarkFilterTreeNode> icomparer_0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ObservableList<DarkFilterTreeNode> Nodes
	{
		get
		{
			return observableList_0;
		}
		set
		{
			if (observableList_0 != null)
			{
				observableList_0.ItemsAdded -= method_8;
				observableList_0.ItemsRemoved -= method_9;
				foreach (DarkFilterTreeNode item in observableList_0)
				{
					method_17(item);
				}
			}
			observableList_0 = value;
			observableList_0.ItemsAdded += method_8;
			observableList_0.ItemsRemoved += method_9;
			foreach (DarkFilterTreeNode item2 in observableList_0)
			{
				method_16(item2);
			}
			UpdateNodes();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ObservableCollection<DarkFilterTreeNode> SelectedNodes => observableCollection_0;

	[Category("Appearance")]
	[Description("Determines the height of tree nodes.")]
	[DefaultValue(20)]
	public int ItemHeight
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
			base.MaxDragChange = int_4;
			UpdateNodes();
		}
	}

	[DefaultValue(20)]
	[Description("Determines the amount of horizontal space given by parent node.")]
	[Category("Appearance")]
	public int Indent
	{
		get
		{
			return int_5;
		}
		set
		{
			int_5 = value;
			UpdateNodes();
		}
	}

	[Category("Behavior")]
	[DefaultValue(false)]
	[Description("Determines whether multiple tree nodes can be selected at once.")]
	public bool MultiSelect
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

	[Category("Behavior")]
	[DefaultValue(false)]
	[Description("Determines whether nodes can be moved within this tree view.")]
	public bool AllowMoveNodes
	{
		[CompilerGenerated]
		get
		{
			return bool_7;
		}
		[CompilerGenerated]
		set
		{
			bool_7 = value;
		}
	}

	[DefaultValue(false)]
	[Description("Determines whether icons are rendered with the tree nodes.")]
	[Category("Appearance")]
	public bool ShowIcons
	{
		[CompilerGenerated]
		get
		{
			return bool_8;
		}
		[CompilerGenerated]
		set
		{
			bool_8 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int VisibleNodeCount
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		private set
		{
			int_6 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IComparer<DarkFilterTreeNode> TreeViewNodeSorter
	{
		[CompilerGenerated]
		get
		{
			return icomparer_0;
		}
		[CompilerGenerated]
		set
		{
			icomparer_0 = value;
		}
	}

	public event EventHandler SelectedNodesChanged
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

	public event AfterNodeExpandDelegate AfterNodeExpand
	{
		[CompilerGenerated]
		add
		{
			AfterNodeExpandDelegate afterNodeExpandDelegate = afterNodeExpandDelegate_0;
			AfterNodeExpandDelegate afterNodeExpandDelegate2;
			do
			{
				afterNodeExpandDelegate2 = afterNodeExpandDelegate;
				AfterNodeExpandDelegate value2 = (AfterNodeExpandDelegate)Delegate.Combine(afterNodeExpandDelegate2, value);
				afterNodeExpandDelegate = Interlocked.CompareExchange(ref afterNodeExpandDelegate_0, value2, afterNodeExpandDelegate2);
			}
			while ((object)afterNodeExpandDelegate != afterNodeExpandDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			AfterNodeExpandDelegate afterNodeExpandDelegate = afterNodeExpandDelegate_0;
			AfterNodeExpandDelegate afterNodeExpandDelegate2;
			do
			{
				afterNodeExpandDelegate2 = afterNodeExpandDelegate;
				AfterNodeExpandDelegate value2 = (AfterNodeExpandDelegate)Delegate.Remove(afterNodeExpandDelegate2, value);
				afterNodeExpandDelegate = Interlocked.CompareExchange(ref afterNodeExpandDelegate_0, value2, afterNodeExpandDelegate2);
			}
			while ((object)afterNodeExpandDelegate != afterNodeExpandDelegate2);
		}
	}

	public event AfterNodeCollapseDelegate AfterNodeCollapse
	{
		[CompilerGenerated]
		add
		{
			AfterNodeCollapseDelegate afterNodeCollapseDelegate = afterNodeCollapseDelegate_0;
			AfterNodeCollapseDelegate afterNodeCollapseDelegate2;
			do
			{
				afterNodeCollapseDelegate2 = afterNodeCollapseDelegate;
				AfterNodeCollapseDelegate value2 = (AfterNodeCollapseDelegate)Delegate.Combine(afterNodeCollapseDelegate2, value);
				afterNodeCollapseDelegate = Interlocked.CompareExchange(ref afterNodeCollapseDelegate_0, value2, afterNodeCollapseDelegate2);
			}
			while ((object)afterNodeCollapseDelegate != afterNodeCollapseDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			AfterNodeCollapseDelegate afterNodeCollapseDelegate = afterNodeCollapseDelegate_0;
			AfterNodeCollapseDelegate afterNodeCollapseDelegate2;
			do
			{
				afterNodeCollapseDelegate2 = afterNodeCollapseDelegate;
				AfterNodeCollapseDelegate value2 = (AfterNodeCollapseDelegate)Delegate.Remove(afterNodeCollapseDelegate2, value);
				afterNodeCollapseDelegate = Interlocked.CompareExchange(ref afterNodeCollapseDelegate_0, value2, afterNodeCollapseDelegate2);
			}
			while ((object)afterNodeCollapseDelegate != afterNodeCollapseDelegate2);
		}
	}

	public void SetFilterString(string str)
	{
		FilterString = str;
		UpdateNodes();
		((Control)this).Invalidate();
	}

	public DarkFilterTreeView()
	{
		Nodes = new ObservableList<DarkFilterTreeNode>();
		observableCollection_0 = new ObservableCollection<DarkFilterTreeNode>();
		observableCollection_0.CollectionChanged += observableCollection_0_CollectionChanged;
		base.MaxDragChange = int_4;
		method_20();
	}

	protected override void Dispose(bool disposing)
	{
		if (!bool_4)
		{
			method_21();
			if (eventHandler_2 != null)
			{
				eventHandler_2 = null;
			}
			if (afterNodeExpandDelegate_0 != null)
			{
				afterNodeExpandDelegate_0 = null;
			}
			if (afterNodeCollapseDelegate_0 != null)
			{
				afterNodeExpandDelegate_0 = null;
			}
			if (observableList_0 != null)
			{
				observableList_0.Dispose();
			}
			if (observableCollection_0 != null)
			{
				observableCollection_0.CollectionChanged -= observableCollection_0_CollectionChanged;
			}
			bool_4 = true;
		}
		((Control)this).Dispose(disposing);
	}

	private void method_8(object object_0, ObservableListModified<DarkFilterTreeNode> observableListModified_0)
	{
		foreach (DarkFilterTreeNode item in observableListModified_0.Items)
		{
			item.ParentTree = this;
			item.IsRoot = true;
			method_16(item);
		}
		if (TreeViewNodeSorter != null)
		{
			Nodes.Sort(TreeViewNodeSorter);
		}
		UpdateNodes();
	}

	private void method_9(object object_0, ObservableListModified<DarkFilterTreeNode> observableListModified_0)
	{
		IEnumerator<DarkFilterTreeNode> enumerator = observableListModified_0.Items.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DarkFilterTreeNode current = enumerator.Current;
			current.ParentTree = this;
			current.IsRoot = true;
			method_16(current);
		}
		UpdateNodes();
	}

	private void method_10(object object_0, ObservableListModified<DarkFilterTreeNode> observableListModified_0)
	{
		foreach (DarkFilterTreeNode item in observableListModified_0.Items)
		{
			method_16(item);
		}
		UpdateNodes();
	}

	private void method_11(object object_0, ObservableListModified<DarkFilterTreeNode> observableListModified_0)
	{
		foreach (DarkFilterTreeNode item in observableListModified_0.Items)
		{
			if (SelectedNodes.Contains(item))
			{
				SelectedNodes.Remove(item);
			}
			method_17(item);
		}
		UpdateNodes();
	}

	private void observableCollection_0_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (eventHandler_2 != null)
		{
			eventHandler_2(this, null);
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		UpdateNodes();
	}

	private void method_13(object sender, EventArgs e)
	{
		UpdateNodes();
		if (afterNodeExpandDelegate_0 != null)
		{
			afterNodeExpandDelegate_0(this, (DarkFilterTreeNode)sender);
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		UpdateNodes();
		if (afterNodeCollapseDelegate_0 != null)
		{
			afterNodeCollapseDelegate_0(this, (DarkFilterTreeNode)sender);
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (bool_5 && base.OffsetMousePosition != point_1)
		{
			StartDrag();
			method_29();
			return;
		}
		if (base.IsDragging && darkFilterTreeNode_3 != null && !GetNodeFullRowArea(darkFilterTreeNode_3).Contains(base.OffsetMousePosition))
		{
			darkFilterTreeNode_3 = null;
			((Control)this).Invalidate();
		}
		KjxeLbAnlsG();
		if (base.IsDragging)
		{
			method_29();
		}
		base.OnMouseMove(e);
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		KjxeLbAnlsG();
		base.OnMouseWheel(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Invalid comparison between Unknown and I4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.Button == 1048576 || (int)e.Button == 2097152)
		{
			foreach (DarkFilterTreeNode node in Nodes)
			{
				method_24(node, base.OffsetMousePosition, e.Button);
			}
		}
		base.OnMouseDown(e);
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		if (base.IsDragging)
		{
			method_30();
		}
		if (bool_5)
		{
			if (darkFilterTreeNode_2 != null)
			{
				Point point = point_1;
				if (base.OffsetMousePosition == point)
				{
					SelectNode(darkFilterTreeNode_2);
				}
			}
			bool_5 = false;
		}
		((Control)this).OnMouseUp(e);
	}

	protected override void OnMouseDoubleClick(MouseEventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Invalid comparison between Unknown and I4
		if ((int)Control.ModifierKeys == 131072)
		{
			return;
		}
		if ((int)e.Button == 1048576)
		{
			foreach (DarkFilterTreeNode node in Nodes)
			{
				method_25(node, base.OffsetMousePosition);
			}
		}
		((Control)this).OnMouseDoubleClick(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		((Control)this).OnMouseLeave(e);
		foreach (DarkFilterTreeNode node in Nodes)
		{
			method_22(node);
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Invalid comparison between Unknown and I4
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Invalid comparison between Unknown and I4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Invalid comparison between Unknown and I4
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Invalid comparison between Unknown and I4
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Invalid comparison between Unknown and I4
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Invalid comparison between Unknown and I4
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Invalid comparison between Unknown and I4
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Invalid comparison between Unknown and I4
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Invalid comparison between Unknown and I4
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Invalid comparison between Unknown and I4
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Invalid comparison between Unknown and I4
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Invalid comparison between Unknown and I4
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Invalid comparison between Unknown and I4
		((Control)this).OnKeyDown(e);
		if (base.IsDragging || Nodes.Count == 0 || ((int)e.KeyCode != 40 && (int)e.KeyCode != 38 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39))
		{
			return;
		}
		if (darkFilterTreeNode_1 == null)
		{
			if (Nodes.Count > 0)
			{
				SelectNode(Nodes[0]);
			}
			return;
		}
		if ((int)e.KeyCode == 40 || (int)e.KeyCode == 38)
		{
			if (MultiSelect && (int)Control.ModifierKeys == 65536)
			{
				if ((int)e.KeyCode == 38)
				{
					if (darkFilterTreeNode_1.PrevVisibleNode != null)
					{
						method_26(darkFilterTreeNode_1.PrevVisibleNode);
						EnsureVisible();
					}
				}
				else if ((int)e.KeyCode == 40 && darkFilterTreeNode_1.NextVisibleNode != null)
				{
					method_26(darkFilterTreeNode_1.NextVisibleNode);
					EnsureVisible();
				}
			}
			else if ((int)e.KeyCode == 38)
			{
				if (darkFilterTreeNode_1.PrevVisibleNode != null)
				{
					SelectNode(darkFilterTreeNode_1.PrevVisibleNode);
					EnsureVisible();
				}
			}
			else if ((int)e.KeyCode == 40 && darkFilterTreeNode_1.NextVisibleNode != null)
			{
				SelectNode(darkFilterTreeNode_1.NextVisibleNode);
				EnsureVisible();
			}
		}
		if ((int)e.KeyCode != 37 && (int)e.KeyCode != 39)
		{
			return;
		}
		if ((int)e.KeyCode == 37)
		{
			if (darkFilterTreeNode_1.Expanded && darkFilterTreeNode_1.Nodes.Count > 0)
			{
				darkFilterTreeNode_1.Expanded = false;
			}
			else if (darkFilterTreeNode_1.ParentNode != null)
			{
				SelectNode(darkFilterTreeNode_1.ParentNode);
				EnsureVisible();
			}
		}
		else
		{
			if ((int)e.KeyCode != 39)
			{
				return;
			}
			if (darkFilterTreeNode_1.Expanded)
			{
				if (darkFilterTreeNode_1.Nodes.Count > 0)
				{
					SelectNode(darkFilterTreeNode_1.Nodes[0]);
					EnsureVisible();
				}
			}
			else
			{
				darkFilterTreeNode_1.Expanded = true;
			}
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Invalid comparison between Unknown and I4
		if (base.IsDragging)
		{
			if ((int)Control.MouseButtons != 1048576)
			{
				StopDrag();
				return;
			}
			Point point = ((Control)this).PointToClient(Control.MousePosition);
			if (_vScrollBar.Visible)
			{
				if (point.Y < ((Control)this).ClientRectangle.Top)
				{
					int num = (point.Y - ((Control)this).ClientRectangle.Top) * -1;
					if (num > ItemHeight)
					{
						num = ItemHeight;
					}
					_vScrollBar.Value -= num;
				}
				if (point.Y > ((Control)this).ClientRectangle.Bottom)
				{
					int num2 = point.Y - ((Control)this).ClientRectangle.Bottom;
					if (num2 > ItemHeight)
					{
						num2 = ItemHeight;
					}
					_vScrollBar.Value += num2;
				}
			}
			if (!_hScrollBar.Visible)
			{
				return;
			}
			if (point.X < ((Control)this).ClientRectangle.Left)
			{
				int num3 = (point.X - ((Control)this).ClientRectangle.Left) * -1;
				if (num3 > ItemHeight)
				{
					num3 = ItemHeight;
				}
				_hScrollBar.Value -= num3;
			}
			if (point.X > ((Control)this).ClientRectangle.Right)
			{
				int num4 = point.X - ((Control)this).ClientRectangle.Right;
				if (num4 > ItemHeight)
				{
					num4 = ItemHeight;
				}
				_hScrollBar.Value += num4;
			}
		}
		else
		{
			StopDrag();
		}
	}

	private void method_16(DarkFilterTreeNode darkFilterTreeNode_4)
	{
		darkFilterTreeNode_4.Nodes.ItemsAdded += method_10;
		darkFilterTreeNode_4.Nodes.ItemsRemoved += method_11;
		darkFilterTreeNode_4.TextChanged += method_12;
		darkFilterTreeNode_4.NodeExpanded += method_13;
		darkFilterTreeNode_4.NodeCollapsed += method_14;
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_4.Nodes)
		{
			method_16(node);
		}
	}

	private void method_17(DarkFilterTreeNode darkFilterTreeNode_4)
	{
		darkFilterTreeNode_4.Nodes.ItemsAdded -= method_10;
		darkFilterTreeNode_4.Nodes.ItemsRemoved -= method_11;
		darkFilterTreeNode_4.TextChanged -= method_12;
		darkFilterTreeNode_4.NodeExpanded -= method_13;
		darkFilterTreeNode_4.NodeCollapsed -= method_14;
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_4.Nodes)
		{
			method_17(node);
		}
	}

	public void UpdateNodes()
	{
		Dictionary<DarkFilterTreeNode, bool> dictionary_ = new Dictionary<DarkFilterTreeNode, bool>();
		if (base.IsDragging || Nodes.Count == 0)
		{
			return;
		}
		int int_ = 0;
		bool bool_ = false;
		int int_2 = 0;
		DarkFilterTreeNode darkFilterTreeNode_ = null;
		base.ContentSize = new Size(0, 0);
		Graphics val = ((Control)this).CreateGraphics();
		try
		{
			for (int i = 0; i <= Nodes.Count - 1; i++)
			{
				DarkFilterTreeNode darkFilterTreeNode_2 = Nodes[i];
				method_18(darkFilterTreeNode_2, ref darkFilterTreeNode_, 0, ref int_, ref bool_, ref int_2, dictionary_, val);
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		base.ContentSize = new Size(base.ContentSize.Width, int_);
		VisibleNodeCount = int_2;
		((Control)this).Invalidate();
	}

	private void method_18(DarkFilterTreeNode darkFilterTreeNode_4, ref DarkFilterTreeNode darkFilterTreeNode_5, int int_7, ref int int_8, ref bool bool_9, ref int int_9, Dictionary<DarkFilterTreeNode, bool> dictionary_0, Graphics graphics_0)
	{
		method_19(darkFilterTreeNode_4, int_8, int_7, graphics_0);
		int_8 += ItemHeight;
		darkFilterTreeNode_4.Odd = bool_9;
		bool_9 = !bool_9;
		darkFilterTreeNode_4.VisibleIndex = int_9;
		int_9++;
		darkFilterTreeNode_4.PrevVisibleNode = darkFilterTreeNode_5;
		if (darkFilterTreeNode_5 != null)
		{
			darkFilterTreeNode_5.NextVisibleNode = darkFilterTreeNode_4;
		}
		darkFilterTreeNode_5 = darkFilterTreeNode_4;
		if (!darkFilterTreeNode_4.Expanded)
		{
			return;
		}
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_4.Nodes)
		{
			method_18(node, ref darkFilterTreeNode_5, int_7 + Indent, ref int_8, ref bool_9, ref int_9, dictionary_0, graphics_0);
		}
	}

	private void method_19(DarkFilterTreeNode darkFilterTreeNode_4, int int_7, int int_8, Graphics graphics_0)
	{
		int y = int_7 + ItemHeight / 2 - int_2 / 2;
		darkFilterTreeNode_4.ExpandArea = new Rectangle(int_8 + 3, y, int_2, int_2);
		int y2 = int_7 + ItemHeight / 2 - int_3 / 2;
		if (!ShowIcons)
		{
			darkFilterTreeNode_4.IconArea = new Rectangle(darkFilterTreeNode_4.ExpandArea.Right, y2, 0, 0);
		}
		else
		{
			darkFilterTreeNode_4.IconArea = new Rectangle(darkFilterTreeNode_4.ExpandArea.Right + 2, y2, int_3, int_3);
		}
		int num = (int)((double)graphics_0.MeasureString(darkFilterTreeNode_4.Text, ((Control)this).Font).Width * 1.5);
		darkFilterTreeNode_4.TextArea = new Rectangle(darkFilterTreeNode_4.IconArea.Right + 2, int_7, num + 1, ItemHeight);
		darkFilterTreeNode_4.FullArea = new Rectangle(int_8, int_7, darkFilterTreeNode_4.TextArea.Right - int_8, ItemHeight);
		if (base.ContentSize.Width < darkFilterTreeNode_4.TextArea.Right + 2)
		{
			base.ContentSize = new Size(darkFilterTreeNode_4.TextArea.Right + 2, base.ContentSize.Height);
		}
	}

	private void method_20()
	{
		method_21();
		bitmap_0 = BitmapExtensions.SetColor(TreeViewIcons.node_closed_empty, Colors.LightText);
		bitmap_1 = BitmapExtensions.SetColor(TreeViewIcons.node_closed_empty, Colors.BlueHighlight);
		bitmap_2 = BitmapExtensions.SetColor(TreeViewIcons.node_closed_full, Colors.LightText);
		bitmap_3 = BitmapExtensions.SetColor(TreeViewIcons.node_open, Colors.LightText);
		bitmap_4 = BitmapExtensions.SetColor(TreeViewIcons.node_open, Colors.BlueHighlight);
		bitmap_5 = BitmapExtensions.SetColor(TreeViewIcons.node_open_empty, Colors.LightText);
	}

	private void method_21()
	{
		if (bitmap_0 != null)
		{
			((Image)bitmap_0).Dispose();
		}
		if (bitmap_1 != null)
		{
			((Image)bitmap_1).Dispose();
		}
		if (bitmap_2 != null)
		{
			((Image)bitmap_2).Dispose();
		}
		if (bitmap_3 != null)
		{
			((Image)bitmap_3).Dispose();
		}
		if (bitmap_4 != null)
		{
			((Image)bitmap_4).Dispose();
		}
		if (bitmap_5 != null)
		{
			((Image)bitmap_5).Dispose();
		}
	}

	private void KjxeLbAnlsG()
	{
		if (((Control)this).ClientRectangle.Contains(((Control)this).PointToClient(Control.MousePosition)))
		{
			foreach (DarkFilterTreeNode node in Nodes)
			{
				method_23(node, base.OffsetMousePosition);
			}
			return;
		}
		if (base.IsDragging && darkFilterTreeNode_3 != null)
		{
			darkFilterTreeNode_3 = null;
			((Control)this).Invalidate();
		}
	}

	private void method_22(DarkFilterTreeNode darkFilterTreeNode_4)
	{
		darkFilterTreeNode_4.ExpandAreaHot = false;
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_4.Nodes)
		{
			method_22(node);
		}
		((Control)this).Invalidate();
	}

	private void method_23(DarkFilterTreeNode darkFilterTreeNode_4, Point point_2)
	{
		if (!base.IsDragging)
		{
			bool flag = darkFilterTreeNode_4.ExpandArea.Contains(point_2);
			if (darkFilterTreeNode_4.ExpandAreaHot != flag)
			{
				darkFilterTreeNode_4.ExpandAreaHot = flag;
				((Control)this).Invalidate();
			}
		}
		else if (GetNodeFullRowArea(darkFilterTreeNode_4).Contains(base.OffsetMousePosition))
		{
			DarkFilterTreeNode darkFilterTreeNode = ((!list_0.Contains(darkFilterTreeNode_4)) ? darkFilterTreeNode_4 : null);
			if (darkFilterTreeNode_3 != darkFilterTreeNode)
			{
				darkFilterTreeNode_3 = darkFilterTreeNode;
				((Control)this).Invalidate();
			}
		}
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_4.Nodes)
		{
			method_23(node, point_2);
		}
	}

	private void method_24(DarkFilterTreeNode darkFilterTreeNode_4, Point point_2, MouseButtons mouseButtons_0)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Invalid comparison between Unknown and I4
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Invalid comparison between Unknown and I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Invalid comparison between Unknown and I4
		if (GetNodeFullRowArea(darkFilterTreeNode_4).Contains(point_2))
		{
			if (darkFilterTreeNode_4.ExpandArea.Contains(point_2))
			{
				if ((int)mouseButtons_0 == 1048576)
				{
					darkFilterTreeNode_4.Expanded = !darkFilterTreeNode_4.Expanded;
				}
			}
			else
			{
				if ((int)mouseButtons_0 == 1048576)
				{
					if (MultiSelect && (int)Control.ModifierKeys == 65536)
					{
						method_26(darkFilterTreeNode_4);
						return;
					}
					if (MultiSelect && (int)Control.ModifierKeys == 131072)
					{
						ToggleNode(darkFilterTreeNode_4);
						return;
					}
					if (!SelectedNodes.Contains(darkFilterTreeNode_4))
					{
						SelectNode(darkFilterTreeNode_4);
					}
					point_1 = base.OffsetMousePosition;
					bool_5 = true;
					darkFilterTreeNode_2 = darkFilterTreeNode_4;
					return;
				}
				if ((int)mouseButtons_0 == 2097152)
				{
					if ((!MultiSelect || (int)Control.ModifierKeys != 65536) && (!MultiSelect || (int)Control.ModifierKeys != 131072) && !SelectedNodes.Contains(darkFilterTreeNode_4))
					{
						SelectNode(darkFilterTreeNode_4);
					}
					return;
				}
			}
		}
		if (!darkFilterTreeNode_4.Expanded)
		{
			return;
		}
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_4.Nodes)
		{
			method_24(node, point_2, mouseButtons_0);
		}
	}

	private void method_25(DarkFilterTreeNode darkFilterTreeNode_4, Point point_2)
	{
		if (!GetNodeFullRowArea(darkFilterTreeNode_4).Contains(point_2))
		{
			if (!darkFilterTreeNode_4.Expanded)
			{
				return;
			}
			{
				foreach (DarkFilterTreeNode node in darkFilterTreeNode_4.Nodes)
				{
					method_25(node, point_2);
				}
				return;
			}
		}
		if (!darkFilterTreeNode_4.ExpandArea.Contains(point_2))
		{
			darkFilterTreeNode_4.Expanded = !darkFilterTreeNode_4.Expanded;
		}
	}

	public void SelectNode(DarkFilterTreeNode node)
	{
		observableCollection_0.Clear();
		observableCollection_0.Add(node);
		darkFilterTreeNode_0 = node;
		darkFilterTreeNode_1 = node;
		((Control)this).Invalidate();
	}

	public void SelectNodes(DarkFilterTreeNode startNode, DarkFilterTreeNode endNode)
	{
		List<DarkFilterTreeNode> list = new List<DarkFilterTreeNode>();
		if (startNode == endNode)
		{
			list.Add(startNode);
		}
		if (startNode.VisibleIndex >= endNode.VisibleIndex)
		{
			if (startNode.VisibleIndex > endNode.VisibleIndex)
			{
				DarkFilterTreeNode darkFilterTreeNode = startNode;
				list.Add(darkFilterTreeNode);
				while (darkFilterTreeNode != endNode && darkFilterTreeNode != null)
				{
					darkFilterTreeNode = darkFilterTreeNode.PrevVisibleNode;
					list.Add(darkFilterTreeNode);
				}
			}
		}
		else
		{
			DarkFilterTreeNode darkFilterTreeNode2 = startNode;
			list.Add(darkFilterTreeNode2);
			while (darkFilterTreeNode2 != endNode && darkFilterTreeNode2 != null)
			{
				darkFilterTreeNode2 = darkFilterTreeNode2.NextVisibleNode;
				list.Add(darkFilterTreeNode2);
			}
		}
		SelectNodes(list, updateAnchors: false);
	}

	public void SelectNodes(List<DarkFilterTreeNode> nodes, bool updateAnchors = true)
	{
		observableCollection_0.Clear();
		foreach (DarkFilterTreeNode node in nodes)
		{
			observableCollection_0.Add(node);
		}
		if (updateAnchors && observableCollection_0.Count > 0)
		{
			darkFilterTreeNode_0 = observableCollection_0[observableCollection_0.Count - 1];
			darkFilterTreeNode_1 = observableCollection_0[observableCollection_0.Count - 1];
		}
		((Control)this).Invalidate();
	}

	private void method_26(DarkFilterTreeNode darkFilterTreeNode_4)
	{
		darkFilterTreeNode_1 = darkFilterTreeNode_4;
		SelectNodes(darkFilterTreeNode_0, darkFilterTreeNode_1);
	}

	public void ToggleNode(DarkFilterTreeNode node)
	{
		if (observableCollection_0.Contains(node))
		{
			observableCollection_0.Remove(node);
			if (darkFilterTreeNode_0 == node && darkFilterTreeNode_1 == node)
			{
				if (observableCollection_0.Count > 0)
				{
					darkFilterTreeNode_0 = observableCollection_0[0];
					darkFilterTreeNode_1 = observableCollection_0[0];
				}
				else
				{
					darkFilterTreeNode_0 = null;
					darkFilterTreeNode_1 = null;
				}
			}
			if (darkFilterTreeNode_0 == node)
			{
				if (darkFilterTreeNode_1.VisibleIndex >= node.VisibleIndex)
				{
					if (darkFilterTreeNode_1.VisibleIndex <= node.VisibleIndex)
					{
						darkFilterTreeNode_0 = darkFilterTreeNode_1;
					}
					else
					{
						darkFilterTreeNode_0 = node.NextVisibleNode;
					}
				}
				else
				{
					darkFilterTreeNode_0 = node.PrevVisibleNode;
				}
			}
			if (darkFilterTreeNode_1 == node)
			{
				if (darkFilterTreeNode_0.VisibleIndex < node.VisibleIndex)
				{
					darkFilterTreeNode_1 = node.PrevVisibleNode;
				}
				else if (darkFilterTreeNode_0.VisibleIndex > node.VisibleIndex)
				{
					darkFilterTreeNode_1 = node.NextVisibleNode;
				}
				else
				{
					darkFilterTreeNode_1 = darkFilterTreeNode_0;
				}
			}
		}
		else
		{
			observableCollection_0.Add(node);
			darkFilterTreeNode_0 = node;
			darkFilterTreeNode_1 = node;
		}
		((Control)this).Invalidate();
	}

	public Rectangle GetNodeFullRowArea(DarkFilterTreeNode node)
	{
		if (node.ParentNode != null && !node.ParentNode.Expanded)
		{
			return new Rectangle(-1, -1, -1, -1);
		}
		int width = Math.Max(base.ContentSize.Width, base.Viewport.Width);
		return new Rectangle(0, node.FullArea.Top, width, ItemHeight);
	}

	public void EnsureVisible()
	{
		if (SelectedNodes.Count == 0)
		{
			return;
		}
		foreach (DarkFilterTreeNode selectedNode in SelectedNodes)
		{
			selectedNode.EnsureVisible();
		}
		int num = -1;
		num = ((!MultiSelect) ? SelectedNodes[0].FullArea.Top : darkFilterTreeNode_1.FullArea.Top);
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

	public void Sort()
	{
		if (TreeViewNodeSorter == null)
		{
			return;
		}
		Nodes.Sort(TreeViewNodeSorter);
		foreach (DarkFilterTreeNode node in Nodes)
		{
			method_27(node);
		}
	}

	private void method_27(DarkFilterTreeNode darkFilterTreeNode_4)
	{
		darkFilterTreeNode_4.Nodes.Sort(TreeViewNodeSorter);
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_4.Nodes)
		{
			method_27(node);
		}
	}

	public DarkFilterTreeNode FindNode(string path)
	{
		foreach (DarkFilterTreeNode node in Nodes)
		{
			DarkFilterTreeNode darkFilterTreeNode = method_28(node, path);
			if (darkFilterTreeNode != null)
			{
				return darkFilterTreeNode;
			}
		}
		return null;
	}

	private DarkFilterTreeNode method_28(DarkFilterTreeNode darkFilterTreeNode_4, string string_0, bool bool_9 = true)
	{
		if (darkFilterTreeNode_4.FullPath == string_0)
		{
			return darkFilterTreeNode_4;
		}
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_4.Nodes)
		{
			if (!(node.FullPath == string_0))
			{
				if (bool_9)
				{
					DarkFilterTreeNode darkFilterTreeNode = method_28(node, string_0);
					if (darkFilterTreeNode != null)
					{
						return darkFilterTreeNode;
					}
				}
				continue;
			}
			return node;
		}
		return null;
	}

	protected override void StartDrag()
	{
		if (AllowMoveNodes)
		{
			list_0 = new List<DarkFilterTreeNode>();
			foreach (DarkFilterTreeNode selectedNode in SelectedNodes)
			{
				list_0.Add(selectedNode);
			}
			foreach (DarkFilterTreeNode item in list_0.ToList())
			{
				if (item.ParentNode != null && list_0.Contains(item.ParentNode))
				{
					list_0.Remove(item);
				}
			}
			bool_5 = false;
			((Control)this).Cursor = Cursors.SizeAll;
			base.StartDrag();
		}
		else
		{
			bool_5 = false;
		}
	}

	private void method_29()
	{
		if (!AllowMoveNodes)
		{
			return;
		}
		DarkFilterTreeNode parentNode = darkFilterTreeNode_3;
		if (parentNode == null)
		{
			if (((Control)this).Cursor != Cursors.No)
			{
				((Control)this).Cursor = Cursors.No;
			}
			return;
		}
		if (ForceDropToParent(parentNode))
		{
			parentNode = parentNode.ParentNode;
		}
		if (!CanMoveNodes(list_0, parentNode))
		{
			if (((Control)this).Cursor != Cursors.No)
			{
				((Control)this).Cursor = Cursors.No;
			}
		}
		else if (((Control)this).Cursor != Cursors.SizeAll)
		{
			((Control)this).Cursor = Cursors.SizeAll;
		}
	}

	private void method_30()
	{
		if (!AllowMoveNodes)
		{
			return;
		}
		DarkFilterTreeNode parentNode = darkFilterTreeNode_3;
		if (parentNode == null)
		{
			StopDrag();
			return;
		}
		if (ForceDropToParent(parentNode))
		{
			parentNode = parentNode.ParentNode;
		}
		if (CanMoveNodes(list_0, parentNode, isMoving: true))
		{
			List<DarkFilterTreeNode> list = SelectedNodes.ToList();
			MoveNodes(list_0, parentNode);
			foreach (DarkFilterTreeNode item in list_0)
			{
				if (item.ParentNode != null)
				{
					item.ParentNode.Nodes.Remove(item);
				}
				else
				{
					Nodes.Remove(item);
				}
				parentNode.Nodes.Add(item);
			}
			if (TreeViewNodeSorter != null)
			{
				parentNode.Nodes.Sort(TreeViewNodeSorter);
			}
			parentNode.Expanded = true;
			NodesMoved(list_0);
			foreach (DarkFilterTreeNode item2 in list)
			{
				observableCollection_0.Add(item2);
			}
		}
		StopDrag();
		UpdateNodes();
	}

	protected override void StopDrag()
	{
		list_0 = null;
		darkFilterTreeNode_3 = null;
		((Control)this).Cursor = Cursors.Default;
		((Control)this).Invalidate();
		base.StopDrag();
	}

	protected virtual bool ForceDropToParent(DarkFilterTreeNode node)
	{
		return false;
	}

	protected virtual bool CanMoveNodes(List<DarkFilterTreeNode> dragNodes, DarkFilterTreeNode dropNode, bool isMoving = false)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		if (dropNode == null)
		{
			return false;
		}
		foreach (DarkFilterTreeNode dragNode in dragNodes)
		{
			if (dragNode != dropNode)
			{
				if (dragNode.ParentNode == null || dragNode.ParentNode != dropNode)
				{
					DarkFilterTreeNode parentNode = dropNode.ParentNode;
					while (parentNode != null)
					{
						if (dragNode != parentNode)
						{
							parentNode = parentNode.ParentNode;
							continue;
						}
						int result;
						if (isMoving)
						{
							DarkMessageBox.ShowError("Cannot move " + dragNode.Text + ". The destination folder is a subfolder of the source folder.", Application.ProductName);
							result = 0;
						}
						else
						{
							result = 0;
						}
						return (byte)result != 0;
					}
					continue;
				}
				int result2;
				if (!isMoving)
				{
					result2 = 0;
				}
				else
				{
					DarkMessageBox.ShowError("Cannot move " + dragNode.Text + ". The destination folder is the same as the source folder.", Application.ProductName);
					result2 = 0;
				}
				return (byte)result2 != 0;
			}
			int result3;
			if (!isMoving)
			{
				result3 = 0;
			}
			else
			{
				DarkMessageBox.ShowError("Cannot move " + dragNode.Text + ". The destination folder is the same as the source folder.", Application.ProductName);
				result3 = 0;
			}
			return (byte)result3 != 0;
		}
		return true;
	}

	protected virtual void MoveNodes(List<DarkFilterTreeNode> dragNodes, DarkFilterTreeNode dropNode)
	{
	}

	protected virtual void NodesMoved(List<DarkFilterTreeNode> nodesMoved)
	{
	}

	protected override void PaintContent(Graphics g)
	{
		Dictionary<DarkFilterTreeNode, bool> dictionary_ = new Dictionary<DarkFilterTreeNode, bool>();
		foreach (DarkFilterTreeNode node in Nodes)
		{
			method_32(node, g, dictionary_);
		}
	}

	private bool method_31(DarkFilterTreeNode darkFilterTreeNode_4, Dictionary<DarkFilterTreeNode, bool> dictionary_0)
	{
		if (!string.IsNullOrWhiteSpace(FilterString))
		{
			if (!dictionary_0.ContainsKey(darkFilterTreeNode_4))
			{
				if (darkFilterTreeNode_4.Text.ToLower().Contains(FilterString.ToLower()))
				{
					dictionary_0[darkFilterTreeNode_4] = true;
					return true;
				}
				dictionary_0[darkFilterTreeNode_4] = false;
				return false;
			}
			return dictionary_0[darkFilterTreeNode_4];
		}
		return false;
	}

	private void method_32(DarkFilterTreeNode darkFilterTreeNode_4, Graphics graphics_0, Dictionary<DarkFilterTreeNode, bool> dictionary_0)
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		bool num = method_31(darkFilterTreeNode_4, dictionary_0);
		Rectangle nodeFullRowArea = GetNodeFullRowArea(darkFilterTreeNode_4);
		Color color = ((!darkFilterTreeNode_4.Odd) ? Colors.GreyBackground : Colors.HeaderBackground);
		if (SelectedNodes.Count > 0 && SelectedNodes.Contains(darkFilterTreeNode_4))
		{
			color = ((!((Control)this).Focused) ? Colors.GreySelection : Colors.BlueSelection);
		}
		if (base.IsDragging && darkFilterTreeNode_3 == darkFilterTreeNode_4)
		{
			color = (((Control)this).Focused ? Colors.BlueSelection : Colors.GreySelection);
		}
		if (num)
		{
			color = Color.DarkGreen;
		}
		SolidBrush val = new SolidBrush(color);
		try
		{
			graphics_0.FillRectangle((Brush)(object)val, nodeFullRowArea);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		if (darkFilterTreeNode_4.Nodes.Count > 0)
		{
			Point point = new Point(darkFilterTreeNode_4.ExpandArea.Location.X - 1, darkFilterTreeNode_4.ExpandArea.Location.Y - 1);
			Bitmap val2 = bitmap_3;
			if (darkFilterTreeNode_4.Expanded && !darkFilterTreeNode_4.ExpandAreaHot)
			{
				val2 = bitmap_3;
			}
			else if (darkFilterTreeNode_4.Expanded && darkFilterTreeNode_4.ExpandAreaHot && !SelectedNodes.Contains(darkFilterTreeNode_4))
			{
				val2 = bitmap_4;
			}
			else if (darkFilterTreeNode_4.Expanded && darkFilterTreeNode_4.ExpandAreaHot && SelectedNodes.Contains(darkFilterTreeNode_4))
			{
				val2 = bitmap_5;
			}
			else if (!darkFilterTreeNode_4.Expanded && !darkFilterTreeNode_4.ExpandAreaHot)
			{
				val2 = bitmap_0;
			}
			else if (!darkFilterTreeNode_4.Expanded && darkFilterTreeNode_4.ExpandAreaHot && !SelectedNodes.Contains(darkFilterTreeNode_4))
			{
				val2 = bitmap_1;
			}
			else if (!darkFilterTreeNode_4.Expanded && darkFilterTreeNode_4.ExpandAreaHot && SelectedNodes.Contains(darkFilterTreeNode_4))
			{
				val2 = bitmap_2;
			}
			graphics_0.DrawImageUnscaled((Image)(object)val2, point);
		}
		if (ShowIcons && darkFilterTreeNode_4.Icon != null)
		{
			if (darkFilterTreeNode_4.Expanded && darkFilterTreeNode_4.ExpandedIcon != null)
			{
				graphics_0.DrawImageUnscaled((Image)(object)darkFilterTreeNode_4.ExpandedIcon, darkFilterTreeNode_4.IconArea.Location);
			}
			else
			{
				graphics_0.DrawImageUnscaled((Image)(object)darkFilterTreeNode_4.Icon, darkFilterTreeNode_4.IconArea.Location);
			}
		}
		graphics_0.TextRenderingHint = (TextRenderingHint)5;
		SolidBrush val3 = new SolidBrush(darkFilterTreeNode_4.ForeColor);
		try
		{
			StringFormat val4 = new StringFormat
			{
				Alignment = (StringAlignment)0,
				LineAlignment = (StringAlignment)1
			};
			if (darkFilterTreeNode_4.Font != null)
			{
				graphics_0.DrawString(darkFilterTreeNode_4.Text, darkFilterTreeNode_4.Font, (Brush)(object)val3, (RectangleF)darkFilterTreeNode_4.TextArea, val4);
			}
			else
			{
				graphics_0.DrawString(darkFilterTreeNode_4.Text, ((Control)this).Font, (Brush)(object)val3, (RectangleF)darkFilterTreeNode_4.TextArea, val4);
			}
		}
		finally
		{
			((IDisposable)val3)?.Dispose();
		}
		if (!darkFilterTreeNode_4.Expanded)
		{
			return;
		}
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_4.Nodes)
		{
			method_32(node, graphics_0, dictionary_0);
		}
	}

	public void ExpandAllItems()
	{
		foreach (DarkFilterTreeNode node in Nodes)
		{
			node.Expanded = true;
		}
	}

	public void CollapseAllItem()
	{
		foreach (DarkFilterTreeNode node in Nodes)
		{
			node.Expanded = false;
		}
	}

	static DarkFilterTreeView()
	{
		Class72.smethod_20();
	}
}
