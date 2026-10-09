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

public class DarkTreeView : DarkScrollView
{
	public delegate void AfterNodeExpandDelegate(DarkTreeView tree, DarkTreeNode Node);

	public delegate void AfterNodeCollapseDelegate(DarkTreeView tree, DarkTreeNode Node);

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

	private ObservableList<DarkTreeNode> observableList_0;

	private ObservableCollection<DarkTreeNode> observableCollection_0;

	private DarkTreeNode darkTreeNode_0;

	private DarkTreeNode darkTreeNode_1;

	private Bitmap bitmap_0;

	private Bitmap bitmap_1;

	private Bitmap bitmap_2;

	private Bitmap bitmap_3;

	private Bitmap bitmap_4;

	private Bitmap bitmap_5;

	private DarkTreeNode darkTreeNode_2;

	private DarkTreeNode darkTreeNode_3;

	private bool QoTeeGocyrf;

	private List<DarkTreeNode> list_0;

	private Point point_1;

	[CompilerGenerated]
	private bool bool_5;

	[CompilerGenerated]
	private bool bool_6;

	[CompilerGenerated]
	private bool bool_7;

	[CompilerGenerated]
	private int int_6;

	[CompilerGenerated]
	private IComparer<DarkTreeNode> icomparer_0;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public ObservableList<DarkTreeNode> Nodes
	{
		get
		{
			return observableList_0;
		}
		set
		{
			if (observableList_0 != null)
			{
				observableList_0.ItemsAdded -= LoseygMlBe6;
				observableList_0.ItemsRemoved -= method_8;
				observableList_0.ItemsCleared -= method_9;
				foreach (DarkTreeNode item in observableList_0)
				{
					method_17(item);
				}
			}
			observableList_0 = value;
			observableList_0.ItemsAdded += LoseygMlBe6;
			observableList_0.ItemsRemoved += method_8;
			observableList_0.ItemsCleared += method_9;
			foreach (DarkTreeNode item2 in observableList_0)
			{
				method_16(item2);
			}
			UpdateNodes();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public ObservableCollection<DarkTreeNode> SelectedNodes => observableCollection_0;

	[Description("Determines the height of tree nodes.")]
	[DefaultValue(20)]
	[Category("Appearance")]
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

	[Description("Determines the amount of horizontal space given by parent node.")]
	[DefaultValue(20)]
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
	[Description("Determines whether multiple tree nodes can be selected at once.")]
	[DefaultValue(false)]
	public bool MultiSelect
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
		[CompilerGenerated]
		set
		{
			bool_5 = value;
		}
	}

	[Category("Behavior")]
	[Description("Determines whether nodes can be moved within this tree view.")]
	[DefaultValue(false)]
	public bool AllowMoveNodes
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

	[Category("Appearance")]
	[Description("Determines whether icons are rendered with the tree nodes.")]
	[DefaultValue(false)]
	public bool ShowIcons
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public IComparer<DarkTreeNode> TreeViewNodeSorter
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

	public DarkTreeView()
	{
		Nodes = new ObservableList<DarkTreeNode>();
		observableCollection_0 = new ObservableCollection<DarkTreeNode>();
		observableCollection_0.CollectionChanged += observableCollection_0_CollectionChanged;
		base.MaxDragChange = int_4;
		method_19();
	}

	protected override void Dispose(bool disposing)
	{
		if (!bool_4)
		{
			method_20();
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

	private void LoseygMlBe6(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
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

	private void method_8(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
		{
			item.ParentTree = this;
			item.IsRoot = true;
			method_16(item);
		}
		UpdateNodes();
	}

	private void method_9(object object_0, object object_1)
	{
		observableCollection_0.Clear();
	}

	private void method_10(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
		{
			method_16(item);
		}
		UpdateNodes();
	}

	private void method_11(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
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
			afterNodeExpandDelegate_0(this, (DarkTreeNode)sender);
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		UpdateNodes();
		if (afterNodeCollapseDelegate_0 != null)
		{
			afterNodeCollapseDelegate_0(this, (DarkTreeNode)sender);
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (QoTeeGocyrf && base.OffsetMousePosition != point_1)
		{
			StartDrag();
			method_29();
			return;
		}
		if (base.IsDragging && darkTreeNode_3 != null && !GetNodeFullRowArea(darkTreeNode_3).Contains(base.OffsetMousePosition))
		{
			darkTreeNode_3 = null;
			((Control)this).Invalidate();
		}
		method_21();
		if (base.IsDragging)
		{
			method_29();
		}
		base.OnMouseMove(e);
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		method_21();
		base.OnMouseWheel(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Invalid comparison between Unknown and I4
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.Button == 1048576 || (int)e.Button == 2097152)
		{
			foreach (DarkTreeNode item in Nodes.ToList())
			{
				method_24(item, base.OffsetMousePosition, e.Button);
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
		if (QoTeeGocyrf)
		{
			if (darkTreeNode_2 != null)
			{
				Point point = point_1;
				if (base.OffsetMousePosition == point)
				{
					SelectNode(darkTreeNode_2);
				}
			}
			QoTeeGocyrf = false;
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
			foreach (DarkTreeNode node in Nodes)
			{
				method_25(node, base.OffsetMousePosition);
			}
		}
		((Control)this).OnMouseDoubleClick(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		((Control)this).OnMouseLeave(e);
		foreach (DarkTreeNode node in Nodes)
		{
			method_22(node);
		}
	}

	protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
	{
		base.OnPreviewKeyDown(e);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Invalid comparison between Unknown and I4
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Invalid comparison between Unknown and I4
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Invalid comparison between Unknown and I4
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Invalid comparison between Unknown and I4
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Invalid comparison between Unknown and I4
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Invalid comparison between Unknown and I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Invalid comparison between Unknown and I4
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Invalid comparison between Unknown and I4
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Invalid comparison between Unknown and I4
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Invalid comparison between Unknown and I4
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Invalid comparison between Unknown and I4
		((Control)this).OnKeyDown(e);
		if (base.IsDragging || Nodes.Count == 0 || ((int)e.KeyCode != 40 && (int)e.KeyCode != 38 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39))
		{
			return;
		}
		if (darkTreeNode_1 != null)
		{
			if ((int)e.KeyCode == 40 || (int)e.KeyCode == 38)
			{
				if (MultiSelect && (int)Control.ModifierKeys == 65536)
				{
					if ((int)e.KeyCode == 38)
					{
						if (darkTreeNode_1.PrevVisibleNode != null)
						{
							method_26(darkTreeNode_1.PrevVisibleNode);
							EnsureVisible();
							e.Handled = base.HandlesEvents;
						}
					}
					else if ((int)e.KeyCode == 40 && darkTreeNode_1.NextVisibleNode != null)
					{
						method_26(darkTreeNode_1.NextVisibleNode);
						EnsureVisible();
						e.Handled = base.HandlesEvents;
					}
				}
				else if ((int)e.KeyCode == 38)
				{
					if (darkTreeNode_1.PrevVisibleNode != null)
					{
						SelectNode(darkTreeNode_1.PrevVisibleNode);
						EnsureVisible();
						e.Handled = base.HandlesEvents;
					}
				}
				else if ((int)e.KeyCode == 40 && darkTreeNode_1.NextVisibleNode != null)
				{
					SelectNode(darkTreeNode_1.NextVisibleNode);
					EnsureVisible();
					e.Handled = base.HandlesEvents;
				}
			}
			if ((int)e.KeyCode != 37 && (int)e.KeyCode != 39)
			{
				return;
			}
			if ((int)e.KeyCode == 37)
			{
				if (darkTreeNode_1.Expanded && darkTreeNode_1.Nodes.Count > 0)
				{
					darkTreeNode_1.Expanded = false;
				}
				else if (darkTreeNode_1.ParentNode != null)
				{
					SelectNode(darkTreeNode_1.ParentNode);
					EnsureVisible();
					e.Handled = base.HandlesEvents;
				}
			}
			else if ((int)e.KeyCode == 39)
			{
				if (!darkTreeNode_1.Expanded)
				{
					darkTreeNode_1.Expanded = true;
				}
				else if (darkTreeNode_1.Nodes.Count > 0)
				{
					SelectNode(darkTreeNode_1.Nodes[0]);
					EnsureVisible();
					e.Handled = base.HandlesEvents;
				}
			}
		}
		else if (Nodes.Count > 0)
		{
			SelectNode(Nodes[0]);
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

	private void method_16(DarkTreeNode darkTreeNode_4)
	{
		darkTreeNode_4.Nodes.ItemsAdded += method_10;
		darkTreeNode_4.Nodes.ItemsRemoved += method_11;
		darkTreeNode_4.TextChanged += method_12;
		darkTreeNode_4.NodeExpanded += method_13;
		darkTreeNode_4.NodeCollapsed += method_14;
		foreach (DarkTreeNode node in darkTreeNode_4.Nodes)
		{
			method_16(node);
		}
	}

	private void method_17(DarkTreeNode darkTreeNode_4)
	{
		darkTreeNode_4.Nodes.ItemsAdded -= method_10;
		darkTreeNode_4.Nodes.ItemsRemoved -= method_11;
		darkTreeNode_4.TextChanged -= method_12;
		darkTreeNode_4.NodeExpanded -= method_13;
		darkTreeNode_4.NodeCollapsed -= method_14;
		foreach (DarkTreeNode node in darkTreeNode_4.Nodes)
		{
			method_17(node);
		}
	}

	public void UpdateNodes()
	{
		if (base.IsDragging || Nodes.Count == 0)
		{
			return;
		}
		int int_ = 0;
		bool bool_ = false;
		int int_2 = 0;
		DarkTreeNode darkTreeNode_ = null;
		base.ContentSize = new Size(0, 0);
		Graphics val = ((Control)this).CreateGraphics();
		try
		{
			for (int i = 0; i <= Nodes.Count - 1; i++)
			{
				DarkTreeNode darkTreeNode_2 = Nodes[i];
				method_18(darkTreeNode_2, ref darkTreeNode_, 0, ref int_, ref bool_, ref int_2, val);
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

	private void method_18(DarkTreeNode darkTreeNode_4, ref DarkTreeNode darkTreeNode_5, int int_7, ref int int_8, ref bool bool_8, ref int int_9, Graphics graphics_0)
	{
		dZueyWsGyxD(darkTreeNode_4, int_8, int_7, graphics_0);
		int_8 += ItemHeight;
		darkTreeNode_4.Odd = bool_8;
		bool_8 = !bool_8;
		darkTreeNode_4.VisibleIndex = int_9;
		int_9++;
		darkTreeNode_4.PrevVisibleNode = darkTreeNode_5;
		if (darkTreeNode_5 != null)
		{
			darkTreeNode_5.NextVisibleNode = darkTreeNode_4;
		}
		darkTreeNode_5 = darkTreeNode_4;
		if (!darkTreeNode_4.Expanded)
		{
			return;
		}
		foreach (DarkTreeNode node in darkTreeNode_4.Nodes)
		{
			method_18(node, ref darkTreeNode_5, int_7 + Indent, ref int_8, ref bool_8, ref int_9, graphics_0);
		}
	}

	private void dZueyWsGyxD(DarkTreeNode darkTreeNode_4, int int_7, int int_8, Graphics graphics_0)
	{
		int y = int_7 + ItemHeight / 2 - int_2 / 2;
		darkTreeNode_4.ExpandArea = new Rectangle(int_8 + 3, y, int_2, int_2);
		int y2 = int_7 + ItemHeight / 2 - int_3 / 2;
		if (!ShowIcons)
		{
			darkTreeNode_4.IconArea = new Rectangle(darkTreeNode_4.ExpandArea.Right, y2, 0, 0);
		}
		else
		{
			darkTreeNode_4.IconArea = new Rectangle(darkTreeNode_4.ExpandArea.Right + 2, y2, int_3, int_3);
		}
		int num = (int)((double)graphics_0.MeasureString(darkTreeNode_4.Text, ((Control)this).Font).Width * 1.5);
		darkTreeNode_4.TextArea = new Rectangle(darkTreeNode_4.IconArea.Right + 2, int_7, num + 1, ItemHeight);
		darkTreeNode_4.FullArea = new Rectangle(int_8, int_7, darkTreeNode_4.TextArea.Right - int_8, ItemHeight);
		if (base.ContentSize.Width < darkTreeNode_4.TextArea.Right + 2)
		{
			base.ContentSize = new Size(darkTreeNode_4.TextArea.Right + 2, base.ContentSize.Height);
		}
	}

	private void method_19()
	{
		method_20();
		bitmap_0 = BitmapExtensions.SetColor(TreeViewIcons.node_closed_empty, Colors.LightText);
		bitmap_1 = BitmapExtensions.SetColor(TreeViewIcons.node_closed_empty, Colors.BlueHighlight);
		bitmap_2 = BitmapExtensions.SetColor(TreeViewIcons.node_closed_full, Colors.LightText);
		bitmap_3 = BitmapExtensions.SetColor(TreeViewIcons.node_open, Colors.LightText);
		bitmap_4 = BitmapExtensions.SetColor(TreeViewIcons.node_open, Colors.BlueHighlight);
		bitmap_5 = BitmapExtensions.SetColor(TreeViewIcons.node_open_empty, Colors.LightText);
	}

	private void method_20()
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

	private void method_21()
	{
		if (((Control)this).ClientRectangle.Contains(((Control)this).PointToClient(Control.MousePosition)))
		{
			foreach (DarkTreeNode node in Nodes)
			{
				method_23(node, base.OffsetMousePosition);
			}
			return;
		}
		if (base.IsDragging && darkTreeNode_3 != null)
		{
			darkTreeNode_3 = null;
			((Control)this).Invalidate();
		}
	}

	private void method_22(DarkTreeNode darkTreeNode_4)
	{
		darkTreeNode_4.ExpandAreaHot = false;
		foreach (DarkTreeNode node in darkTreeNode_4.Nodes)
		{
			method_22(node);
		}
		((Control)this).Invalidate();
	}

	private void method_23(DarkTreeNode darkTreeNode_4, Point point_2)
	{
		if (base.IsDragging)
		{
			if (GetNodeFullRowArea(darkTreeNode_4).Contains(base.OffsetMousePosition))
			{
				DarkTreeNode darkTreeNode = (list_0.Contains(darkTreeNode_4) ? null : darkTreeNode_4);
				if (darkTreeNode_3 != darkTreeNode)
				{
					darkTreeNode_3 = darkTreeNode;
					((Control)this).Invalidate();
				}
			}
		}
		else
		{
			bool flag = darkTreeNode_4.ExpandArea.Contains(point_2);
			if (darkTreeNode_4.ExpandAreaHot != flag)
			{
				darkTreeNode_4.ExpandAreaHot = flag;
				((Control)this).Invalidate();
			}
		}
		foreach (DarkTreeNode node in darkTreeNode_4.Nodes)
		{
			method_23(node, point_2);
		}
	}

	private void method_24(DarkTreeNode darkTreeNode_4, Point point_2, MouseButtons mouseButtons_0)
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Invalid comparison between Unknown and I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Invalid comparison between Unknown and I4
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Invalid comparison between Unknown and I4
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Invalid comparison between Unknown and I4
		if (GetNodeFullRowArea(darkTreeNode_4).Contains(point_2))
		{
			if (!darkTreeNode_4.ExpandArea.Contains(point_2))
			{
				if ((int)mouseButtons_0 == 1048576)
				{
					if (MultiSelect && (int)Control.ModifierKeys == 65536)
					{
						method_26(darkTreeNode_4);
						return;
					}
					if (MultiSelect && (int)Control.ModifierKeys == 131072)
					{
						ToggleNode(darkTreeNode_4);
						return;
					}
					if (!SelectedNodes.Contains(darkTreeNode_4))
					{
						SelectNode(darkTreeNode_4);
					}
					point_1 = base.OffsetMousePosition;
					QoTeeGocyrf = true;
					darkTreeNode_2 = darkTreeNode_4;
					return;
				}
				if ((int)mouseButtons_0 == 2097152)
				{
					if ((!MultiSelect || (int)Control.ModifierKeys != 65536) && (!MultiSelect || (int)Control.ModifierKeys != 131072) && !SelectedNodes.Contains(darkTreeNode_4))
					{
						SelectNode(darkTreeNode_4);
					}
					return;
				}
			}
			else if ((int)mouseButtons_0 == 1048576)
			{
				darkTreeNode_4.Expanded = !darkTreeNode_4.Expanded;
			}
		}
		if (!darkTreeNode_4.Expanded)
		{
			return;
		}
		foreach (DarkTreeNode node in darkTreeNode_4.Nodes)
		{
			method_24(node, point_2, mouseButtons_0);
		}
	}

	private void method_25(DarkTreeNode darkTreeNode_4, Point point_2)
	{
		if (GetNodeFullRowArea(darkTreeNode_4).Contains(point_2))
		{
			if (!darkTreeNode_4.ExpandArea.Contains(point_2))
			{
				darkTreeNode_4.Expanded = !darkTreeNode_4.Expanded;
			}
		}
		else
		{
			if (!darkTreeNode_4.Expanded)
			{
				return;
			}
			foreach (DarkTreeNode node in darkTreeNode_4.Nodes)
			{
				method_25(node, point_2);
			}
		}
	}

	public void SelectNode(DarkTreeNode node)
	{
		observableCollection_0.Clear();
		observableCollection_0.Add(node);
		darkTreeNode_0 = node;
		darkTreeNode_1 = node;
		((Control)this).Invalidate();
	}

	public void SelectNodes(DarkTreeNode startNode, DarkTreeNode endNode)
	{
		List<DarkTreeNode> list = new List<DarkTreeNode>();
		if (startNode == endNode)
		{
			list.Add(startNode);
		}
		if (startNode.VisibleIndex >= endNode.VisibleIndex)
		{
			if (startNode.VisibleIndex > endNode.VisibleIndex)
			{
				DarkTreeNode darkTreeNode = startNode;
				list.Add(darkTreeNode);
				while (darkTreeNode != endNode && darkTreeNode != null)
				{
					darkTreeNode = darkTreeNode.PrevVisibleNode;
					list.Add(darkTreeNode);
				}
			}
		}
		else
		{
			DarkTreeNode darkTreeNode2 = startNode;
			list.Add(darkTreeNode2);
			while (darkTreeNode2 != endNode && darkTreeNode2 != null)
			{
				darkTreeNode2 = darkTreeNode2.NextVisibleNode;
				list.Add(darkTreeNode2);
			}
		}
		SelectNodes(list, updateAnchors: false);
	}

	public void SelectNodes(List<DarkTreeNode> nodes, bool updateAnchors = true)
	{
		observableCollection_0.Clear();
		foreach (DarkTreeNode node in nodes)
		{
			observableCollection_0.Add(node);
		}
		if (updateAnchors && observableCollection_0.Count > 0)
		{
			darkTreeNode_0 = observableCollection_0[observableCollection_0.Count - 1];
			darkTreeNode_1 = observableCollection_0[observableCollection_0.Count - 1];
		}
		((Control)this).Invalidate();
	}

	private void method_26(DarkTreeNode darkTreeNode_4)
	{
		if (darkTreeNode_0 == null)
		{
			darkTreeNode_0 = darkTreeNode_4;
		}
		darkTreeNode_1 = darkTreeNode_4;
		SelectNodes(darkTreeNode_0, darkTreeNode_1);
	}

	public void ToggleNode(DarkTreeNode node)
	{
		if (observableCollection_0.Contains(node))
		{
			observableCollection_0.Remove(node);
			if (darkTreeNode_0 == node && darkTreeNode_1 == node)
			{
				if (observableCollection_0.Count > 0)
				{
					darkTreeNode_0 = observableCollection_0[0];
					darkTreeNode_1 = observableCollection_0[0];
				}
				else
				{
					darkTreeNode_0 = null;
					darkTreeNode_1 = null;
				}
			}
			if (darkTreeNode_0 == node)
			{
				if (darkTreeNode_1.VisibleIndex < node.VisibleIndex)
				{
					darkTreeNode_0 = node.PrevVisibleNode;
				}
				else if (darkTreeNode_1.VisibleIndex > node.VisibleIndex)
				{
					darkTreeNode_0 = node.NextVisibleNode;
				}
				else
				{
					darkTreeNode_0 = darkTreeNode_1;
				}
			}
			if (darkTreeNode_1 == node)
			{
				if (darkTreeNode_0.VisibleIndex >= node.VisibleIndex)
				{
					if (darkTreeNode_0.VisibleIndex > node.VisibleIndex)
					{
						darkTreeNode_1 = node.NextVisibleNode;
					}
					else
					{
						darkTreeNode_1 = darkTreeNode_0;
					}
				}
				else
				{
					darkTreeNode_1 = node.PrevVisibleNode;
				}
			}
		}
		else
		{
			observableCollection_0.Add(node);
			darkTreeNode_0 = node;
			darkTreeNode_1 = node;
		}
		((Control)this).Invalidate();
	}

	public Rectangle GetNodeFullRowArea(DarkTreeNode node)
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
		foreach (DarkTreeNode selectedNode in SelectedNodes)
		{
			selectedNode.EnsureVisible();
		}
		int num = -1;
		num = (MultiSelect ? darkTreeNode_1.FullArea.Top : SelectedNodes[0].FullArea.Top);
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
		foreach (DarkTreeNode node in Nodes)
		{
			method_27(node);
		}
	}

	private void method_27(DarkTreeNode darkTreeNode_4)
	{
		darkTreeNode_4.Nodes.Sort(TreeViewNodeSorter);
		foreach (DarkTreeNode node in darkTreeNode_4.Nodes)
		{
			method_27(node);
		}
	}

	public DarkTreeNode FindNode(string path)
	{
		foreach (DarkTreeNode node in Nodes)
		{
			DarkTreeNode darkTreeNode = method_28(node, path);
			if (darkTreeNode != null)
			{
				return darkTreeNode;
			}
		}
		return null;
	}

	private DarkTreeNode method_28(DarkTreeNode darkTreeNode_4, string string_0, bool bool_8 = true)
	{
		if (darkTreeNode_4.FullPath == string_0)
		{
			return darkTreeNode_4;
		}
		foreach (DarkTreeNode node in darkTreeNode_4.Nodes)
		{
			if (!(node.FullPath == string_0))
			{
				if (bool_8)
				{
					DarkTreeNode darkTreeNode = method_28(node, string_0);
					if (darkTreeNode != null)
					{
						return darkTreeNode;
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
			list_0 = new List<DarkTreeNode>();
			foreach (DarkTreeNode selectedNode in SelectedNodes)
			{
				list_0.Add(selectedNode);
			}
			foreach (DarkTreeNode item in list_0.ToList())
			{
				if (item.ParentNode != null && list_0.Contains(item.ParentNode))
				{
					list_0.Remove(item);
				}
			}
			QoTeeGocyrf = false;
			((Control)this).Cursor = Cursors.SizeAll;
			base.StartDrag();
		}
		else
		{
			QoTeeGocyrf = false;
		}
	}

	private void method_29()
	{
		if (!AllowMoveNodes)
		{
			return;
		}
		DarkTreeNode parentNode = darkTreeNode_3;
		if (parentNode != null)
		{
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
		else if (((Control)this).Cursor != Cursors.No)
		{
			((Control)this).Cursor = Cursors.No;
		}
	}

	private void method_30()
	{
		if (!AllowMoveNodes)
		{
			return;
		}
		DarkTreeNode parentNode = darkTreeNode_3;
		if (parentNode != null)
		{
			if (ForceDropToParent(parentNode))
			{
				parentNode = parentNode.ParentNode;
			}
			if (CanMoveNodes(list_0, parentNode, isMoving: true))
			{
				List<DarkTreeNode> list = SelectedNodes.ToList();
				MoveNodes(list_0, parentNode);
				foreach (DarkTreeNode item in list_0)
				{
					if (item.ParentNode == null)
					{
						Nodes.Remove(item);
					}
					else
					{
						item.ParentNode.Nodes.Remove(item);
					}
					parentNode.Nodes.Add(item);
				}
				if (TreeViewNodeSorter != null)
				{
					parentNode.Nodes.Sort(TreeViewNodeSorter);
				}
				parentNode.Expanded = true;
				NodesMoved(list_0);
				foreach (DarkTreeNode item2 in list)
				{
					observableCollection_0.Add(item2);
				}
			}
			StopDrag();
			UpdateNodes();
		}
		else
		{
			StopDrag();
		}
	}

	protected override void StopDrag()
	{
		list_0 = null;
		darkTreeNode_3 = null;
		((Control)this).Cursor = Cursors.Default;
		((Control)this).Invalidate();
		base.StopDrag();
	}

	protected virtual bool ForceDropToParent(DarkTreeNode node)
	{
		return false;
	}

	protected virtual bool CanMoveNodes(List<DarkTreeNode> dragNodes, DarkTreeNode dropNode, bool isMoving = false)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		if (dropNode == null)
		{
			return false;
		}
		foreach (DarkTreeNode dragNode in dragNodes)
		{
			if (dragNode != dropNode)
			{
				if (dragNode.ParentNode == null || dragNode.ParentNode != dropNode)
				{
					DarkTreeNode parentNode = dropNode.ParentNode;
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

	protected virtual void MoveNodes(List<DarkTreeNode> dragNodes, DarkTreeNode dropNode)
	{
	}

	protected virtual void NodesMoved(List<DarkTreeNode> nodesMoved)
	{
	}

	protected override void PaintContent(Graphics g)
	{
		foreach (DarkTreeNode node in Nodes)
		{
			method_31(node, g);
		}
	}

	private void method_31(DarkTreeNode darkTreeNode_4, Graphics graphics_0)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected O, but got Unknown
		Rectangle nodeFullRowArea = GetNodeFullRowArea(darkTreeNode_4);
		Color color = (darkTreeNode_4.Odd ? Colors.HeaderBackground : Colors.GreyBackground);
		if (SelectedNodes.Count > 0 && SelectedNodes.Contains(darkTreeNode_4))
		{
			color = (((Control)this).Focused ? Colors.BlueSelection : Colors.GreySelection);
		}
		if (base.IsDragging && darkTreeNode_3 == darkTreeNode_4)
		{
			color = (((Control)this).Focused ? Colors.BlueSelection : Colors.GreySelection);
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
		if (darkTreeNode_4.Nodes.Count > 0)
		{
			Point point = new Point(darkTreeNode_4.ExpandArea.Location.X - 1, darkTreeNode_4.ExpandArea.Location.Y - 1);
			Bitmap val2 = bitmap_3;
			if (darkTreeNode_4.Expanded && !darkTreeNode_4.ExpandAreaHot)
			{
				val2 = bitmap_3;
			}
			else if (darkTreeNode_4.Expanded && darkTreeNode_4.ExpandAreaHot && !SelectedNodes.Contains(darkTreeNode_4))
			{
				val2 = bitmap_4;
			}
			else if (darkTreeNode_4.Expanded && darkTreeNode_4.ExpandAreaHot && SelectedNodes.Contains(darkTreeNode_4))
			{
				val2 = bitmap_5;
			}
			else if (!darkTreeNode_4.Expanded && !darkTreeNode_4.ExpandAreaHot)
			{
				val2 = bitmap_0;
			}
			else if (!darkTreeNode_4.Expanded && darkTreeNode_4.ExpandAreaHot && !SelectedNodes.Contains(darkTreeNode_4))
			{
				val2 = bitmap_1;
			}
			else if (!darkTreeNode_4.Expanded && darkTreeNode_4.ExpandAreaHot && SelectedNodes.Contains(darkTreeNode_4))
			{
				val2 = bitmap_2;
			}
			graphics_0.DrawImageUnscaled((Image)(object)val2, point);
		}
		if (ShowIcons && darkTreeNode_4.Icon != null)
		{
			if (darkTreeNode_4.Expanded && darkTreeNode_4.ExpandedIcon != null)
			{
				graphics_0.DrawImageUnscaled((Image)(object)darkTreeNode_4.ExpandedIcon, darkTreeNode_4.IconArea.Location);
			}
			else
			{
				graphics_0.DrawImageUnscaled((Image)(object)darkTreeNode_4.Icon, darkTreeNode_4.IconArea.Location);
			}
		}
		graphics_0.TextRenderingHint = (TextRenderingHint)5;
		SolidBrush val3 = new SolidBrush(darkTreeNode_4.ForeColor);
		try
		{
			StringFormat val4 = new StringFormat
			{
				Alignment = (StringAlignment)0,
				LineAlignment = (StringAlignment)1
			};
			if (darkTreeNode_4.Font != null)
			{
				graphics_0.DrawString(darkTreeNode_4.Text, darkTreeNode_4.Font, (Brush)(object)val3, (RectangleF)darkTreeNode_4.TextArea, val4);
			}
			else
			{
				graphics_0.DrawString(darkTreeNode_4.Text, ((Control)this).Font, (Brush)(object)val3, (RectangleF)darkTreeNode_4.TextArea, val4);
			}
		}
		finally
		{
			((IDisposable)val3)?.Dispose();
		}
		if (!darkTreeNode_4.Expanded)
		{
			return;
		}
		foreach (DarkTreeNode node in darkTreeNode_4.Nodes)
		{
			method_31(node, graphics_0);
		}
	}

	static DarkTreeView()
	{
		Class72.smethod_20();
	}
}
