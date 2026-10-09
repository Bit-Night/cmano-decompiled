using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace AdvancedDataGridView;

[Docking(/*Could not decode attribute arguments.*/)]
[ComplexBindingProperties]
[Designer(typeof(ControlDesigner))]
[DesignerCategory("code")]
public class TreeGridView : DataGridView
{
	private static class Class29
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(HandleRef handleRef_0, int int_0, IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		public static extern IntPtr SendMessage_1(HandleRef handleRef_0, int int_0, int int_1, int int_2);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool PostMessage(HandleRef handleRef_0, int int_0, IntPtr intptr_0, IntPtr intptr_1);

		static Class29()
		{
			Class72.smethod_20();
		}
	}

	private int int_0;

	private TreeGridNode treeGridNode_0;

	private TreeGridColumn LeEyqsmfrEi;

	private bool bool_0;

	internal ImageList _imageList;

	private bool bool_1;

	internal bool _inExpandCollapseMouseCapture;

	private Control control_0;

	private bool bool_2 = true;

	private bool bool_3;

	[CompilerGenerated]
	private ExpandingEventHandler expandingEventHandler_0;

	[CompilerGenerated]
	private ExpandedEventHandler expandedEventHandler_0;

	[CompilerGenerated]
	private CollapsingEventHandler collapsingEventHandler_0;

	[CompilerGenerated]
	private CollapsedEventHandler collapsedEventHandler_0;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public object DataSource
	{
		get
		{
			return null;
		}
		set
		{
			throw new NotSupportedException("The TreeGridView does not support databinding");
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public object DataMember
	{
		get
		{
			return null;
		}
		set
		{
			throw new NotSupportedException("The TreeGridView does not support databinding");
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DataGridViewRowCollection Rows => ((DataGridView)this).Rows;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool VirtualMode
	{
		get
		{
			return false;
		}
		set
		{
			throw new NotSupportedException("The TreeGridView does not support virtual mode");
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public DataGridViewRow RowTemplate
	{
		get
		{
			return ((DataGridView)this).RowTemplate;
		}
		set
		{
			((DataGridView)this).RowTemplate = value;
		}
	}

	[Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Category("Data")]
	[Description("The collection of root nodes in the treelist.")]
	public TreeGridNodeCollection Nodes => treeGridNode_0.Nodes;

	public TreeGridNode CurrentRow => ((DataGridView)this).CurrentRow as TreeGridNode;

	[DefaultValue(false)]
	[Description("Causes nodes to always show as expandable. Use the NodeExpanding event to add nodes.")]
	public bool VirtualNodes
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public TreeGridNode CurrentNode => CurrentRow;

	[DefaultValue(true)]
	public bool ShowLines
	{
		get
		{
			return bool_2;
		}
		set
		{
			if (value != bool_2)
			{
				bool_2 = value;
				((Control)this).Invalidate();
			}
		}
	}

	public ImageList ImageList
	{
		get
		{
			return _imageList;
		}
		set
		{
			_imageList = value;
		}
	}

	public int RowCount
	{
		get
		{
			return Nodes.Count;
		}
		set
		{
			for (int i = 0; i < value; i++)
			{
				Nodes.Add(new TreeGridNode());
			}
		}
	}

	public event ExpandingEventHandler NodeExpanding
	{
		[CompilerGenerated]
		add
		{
			ExpandingEventHandler expandingEventHandler = expandingEventHandler_0;
			ExpandingEventHandler expandingEventHandler2;
			do
			{
				expandingEventHandler2 = expandingEventHandler;
				ExpandingEventHandler value2 = (ExpandingEventHandler)Delegate.Combine(expandingEventHandler2, value);
				expandingEventHandler = Interlocked.CompareExchange(ref expandingEventHandler_0, value2, expandingEventHandler2);
			}
			while ((object)expandingEventHandler != expandingEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ExpandingEventHandler expandingEventHandler = expandingEventHandler_0;
			ExpandingEventHandler expandingEventHandler2;
			do
			{
				expandingEventHandler2 = expandingEventHandler;
				ExpandingEventHandler value2 = (ExpandingEventHandler)Delegate.Remove(expandingEventHandler2, value);
				expandingEventHandler = Interlocked.CompareExchange(ref expandingEventHandler_0, value2, expandingEventHandler2);
			}
			while ((object)expandingEventHandler != expandingEventHandler2);
		}
	}

	public event ExpandedEventHandler NodeExpanded
	{
		[CompilerGenerated]
		add
		{
			ExpandedEventHandler expandedEventHandler = expandedEventHandler_0;
			ExpandedEventHandler expandedEventHandler2;
			do
			{
				expandedEventHandler2 = expandedEventHandler;
				ExpandedEventHandler value2 = (ExpandedEventHandler)Delegate.Combine(expandedEventHandler2, value);
				expandedEventHandler = Interlocked.CompareExchange(ref expandedEventHandler_0, value2, expandedEventHandler2);
			}
			while ((object)expandedEventHandler != expandedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ExpandedEventHandler expandedEventHandler = expandedEventHandler_0;
			ExpandedEventHandler expandedEventHandler2;
			do
			{
				expandedEventHandler2 = expandedEventHandler;
				ExpandedEventHandler value2 = (ExpandedEventHandler)Delegate.Remove(expandedEventHandler2, value);
				expandedEventHandler = Interlocked.CompareExchange(ref expandedEventHandler_0, value2, expandedEventHandler2);
			}
			while ((object)expandedEventHandler != expandedEventHandler2);
		}
	}

	public event CollapsingEventHandler NodeCollapsing
	{
		[CompilerGenerated]
		add
		{
			CollapsingEventHandler collapsingEventHandler = collapsingEventHandler_0;
			CollapsingEventHandler collapsingEventHandler2;
			do
			{
				collapsingEventHandler2 = collapsingEventHandler;
				CollapsingEventHandler value2 = (CollapsingEventHandler)Delegate.Combine(collapsingEventHandler2, value);
				collapsingEventHandler = Interlocked.CompareExchange(ref collapsingEventHandler_0, value2, collapsingEventHandler2);
			}
			while ((object)collapsingEventHandler != collapsingEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CollapsingEventHandler collapsingEventHandler = collapsingEventHandler_0;
			CollapsingEventHandler collapsingEventHandler2;
			do
			{
				collapsingEventHandler2 = collapsingEventHandler;
				CollapsingEventHandler value2 = (CollapsingEventHandler)Delegate.Remove(collapsingEventHandler2, value);
				collapsingEventHandler = Interlocked.CompareExchange(ref collapsingEventHandler_0, value2, collapsingEventHandler2);
			}
			while ((object)collapsingEventHandler != collapsingEventHandler2);
		}
	}

	public event CollapsedEventHandler NodeCollapsed
	{
		[CompilerGenerated]
		add
		{
			CollapsedEventHandler collapsedEventHandler = collapsedEventHandler_0;
			CollapsedEventHandler collapsedEventHandler2;
			do
			{
				collapsedEventHandler2 = collapsedEventHandler;
				CollapsedEventHandler value2 = (CollapsedEventHandler)Delegate.Combine(collapsedEventHandler2, value);
				collapsedEventHandler = Interlocked.CompareExchange(ref collapsedEventHandler_0, value2, collapsedEventHandler2);
			}
			while ((object)collapsedEventHandler != collapsedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CollapsedEventHandler collapsedEventHandler = collapsedEventHandler_0;
			CollapsedEventHandler collapsedEventHandler2;
			do
			{
				collapsedEventHandler2 = collapsedEventHandler;
				CollapsedEventHandler value2 = (CollapsedEventHandler)Delegate.Remove(collapsedEventHandler2, value);
				collapsedEventHandler = Interlocked.CompareExchange(ref collapsedEventHandler_0, value2, collapsedEventHandler2);
			}
			while ((object)collapsedEventHandler != collapsedEventHandler2);
		}
	}

	public TreeGridView()
	{
		((DataGridView)this).EditMode = (DataGridViewEditMode)4;
		RowTemplate = (DataGridViewRow)(object)new TreeGridNode();
		((DataGridView)this).AllowUserToAddRows = false;
		((DataGridView)this).AllowUserToDeleteRows = false;
		treeGridNode_0 = new TreeGridNode(this);
		treeGridNode_0._IsRoot = true;
		((DataGridView)this).Rows.CollectionChanged += delegate
		{
		};
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Invalid comparison between Unknown and I4
		((DataGridView)this).OnKeyDown(e);
		if (e.Handled)
		{
			return;
		}
		if ((int)e.KeyCode == 113 && ((DataGridView)this).CurrentCellAddress.X > -1 && ((DataGridView)this).CurrentCellAddress.Y > -1)
		{
			if (!((DataGridView)this).CurrentCell.Displayed)
			{
				((DataGridView)this).FirstDisplayedScrollingRowIndex = ((DataGridView)this).CurrentCellAddress.Y;
			}
			((DataGridView)this).SelectionMode = (DataGridViewSelectionMode)0;
			((DataGridView)this).BeginEdit(true);
		}
		else if ((int)e.KeyCode == 13 && !((DataGridView)this).IsCurrentCellInEditMode)
		{
			((DataGridView)this).SelectionMode = (DataGridViewSelectionMode)1;
			((DataGridViewBand)((DataGridView)this).CurrentCell.OwningRow).Selected = true;
		}
	}

	[Description("Returns the TreeGridNode for the given DataGridViewRow")]
	public TreeGridNode GetNodeForRow(DataGridViewRow row)
	{
		return row as TreeGridNode;
	}

	[Description("Returns the TreeGridNode for the given DataGridViewRow")]
	public TreeGridNode GetNodeForRow(int index)
	{
		return GetNodeForRow(((DataGridView)this).Rows[index]);
	}

	protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
	{
		((DataGridView)this).OnRowsAdded(e);
		if (((DataGridView)this).Rows[e.RowIndex] is TreeGridNode treeGridNode)
		{
			treeGridNode.Sited();
		}
	}

	protected internal void UnSiteAll()
	{
		UnSiteNode(treeGridNode_0);
	}

	protected internal virtual void UnSiteNode(TreeGridNode node)
	{
		try
		{
			if (!node.IsSited && !node._IsRoot)
			{
				return;
			}
			foreach (TreeGridNode node2 in node.Nodes)
			{
				UnSiteNode(node2);
			}
			if (!node._IsRoot)
			{
				((DataGridView)this).Rows.Remove((DataGridViewRow)(object)node);
				node.UnSited();
			}
		}
		catch
		{
		}
	}

	protected internal virtual bool CollapseNode(TreeGridNode node)
	{
		if (node._IsExpanded)
		{
			CollapsingEventArgs e = new CollapsingEventArgs(node);
			OnNodeCollapsing(e);
			if (!e.Cancel)
			{
				method_0(bool_4: true);
				((Control)this).SuspendLayout();
				bool_1 = true;
				node._IsExpanded = false;
				foreach (TreeGridNode node2 in node.Nodes)
				{
					UnSiteNode(node2);
				}
				CollapsedEventArgs e2 = new CollapsedEventArgs(node);
				OnNodeCollapsed(e2);
				bool_1 = false;
				method_0(bool_4: false);
				((Control)this).ResumeLayout(true);
				((DataGridView)this).InvalidateCell(node.Cells[0]);
			}
			return !e.Cancel;
		}
		return false;
	}

	protected internal virtual void SiteNode(TreeGridNode node)
	{
		int num = -1;
		node._grid = this;
		TreeGridNode treeGridNode = ((node.Parent != null && !node.Parent._IsRoot) ? ((node.Index <= 0) ? node.Parent : node.Parent.Nodes[node.Index - 1]) : ((node.Index > 0) ? node.Parent.Nodes[node.Index - 1] : null));
		if (treeGridNode != null)
		{
			while (treeGridNode.Level >= node.Level && treeGridNode.RowIndex < ((DataGridView)this).Rows.Count - 1)
			{
				treeGridNode = ((DataGridView)this).Rows[treeGridNode.RowIndex + 1] as TreeGridNode;
			}
			num = ((treeGridNode == node.Parent) ? (treeGridNode.RowIndex + 1) : ((treeGridNode.Level >= node.Level) ? (treeGridNode.RowIndex + 1) : treeGridNode.RowIndex));
		}
		else
		{
			num = 0;
		}
		SiteNode(node, num);
		if (!node._IsExpanded)
		{
			return;
		}
		foreach (TreeGridNode node2 in node.Nodes)
		{
			SiteNode(node2);
		}
	}

	protected internal virtual void SiteNode(TreeGridNode node, int index)
	{
		if (index < ((DataGridView)this).Rows.Count)
		{
			((DataGridView)this).Rows.Insert(index, (DataGridViewRow)(object)node);
		}
		else
		{
			((DataGridView)this).Rows.Add((DataGridViewRow)(object)node);
		}
	}

	protected internal virtual bool ExpandNode(TreeGridNode node)
	{
		if (node._IsExpanded && !bool_3)
		{
			return false;
		}
		ExpandingEventArgs e = new ExpandingEventArgs(node);
		OnNodeExpanding(e);
		if (!e.Cancel)
		{
			method_0(bool_4: true);
			((Control)this).SuspendLayout();
			bool_1 = true;
			node._IsExpanded = true;
			foreach (TreeGridNode node2 in node.Nodes)
			{
				SiteNode(node2);
			}
			ExpandedEventArgs e2 = new ExpandedEventArgs(node);
			OnNodeExpanded(e2);
			bool_1 = false;
			method_0(bool_4: false);
			((Control)this).ResumeLayout(true);
			((DataGridView)this).InvalidateCell(node.Cells[0]);
		}
		return !e.Cancel;
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		((DataGridView)this).OnMouseUp(e);
		_inExpandCollapseMouseCapture = false;
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (!_inExpandCollapseMouseCapture)
		{
			((DataGridView)this).OnMouseMove(e);
		}
	}

	protected virtual void OnNodeExpanding(ExpandingEventArgs e)
	{
		if (expandingEventHandler_0 != null)
		{
			expandingEventHandler_0(this, e);
		}
	}

	protected virtual void OnNodeExpanded(ExpandedEventArgs e)
	{
		if (expandedEventHandler_0 != null)
		{
			expandedEventHandler_0(this, e);
		}
	}

	protected virtual void OnNodeCollapsing(CollapsingEventArgs e)
	{
		if (collapsingEventHandler_0 != null)
		{
			collapsingEventHandler_0(this, e);
		}
	}

	protected virtual void OnNodeCollapsed(CollapsedEventArgs e)
	{
		if (collapsedEventHandler_0 != null)
		{
			collapsedEventHandler_0(this, e);
		}
	}

	protected override void Dispose(bool disposing)
	{
		bool_0 = true;
		((DataGridView)this).Dispose(((Control)this).Disposing);
		UnSiteAll();
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		((DataGridView)this).OnHandleCreated(e);
		control_0 = new Control();
		control_0.Visible = false;
		control_0.Enabled = false;
		control_0.TabStop = false;
		((Control)this).Controls.Add(control_0);
	}

	protected override void OnRowEnter(DataGridViewCellEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Invalid comparison between Unknown and I4
		((DataGridView)this).OnRowEnter(e);
		if ((int)((DataGridView)this).SelectionMode == 0 || ((int)((DataGridView)this).SelectionMode == 1 && !((DataGridViewBand)((DataGridView)this).Rows[e.RowIndex]).Selected))
		{
			((DataGridView)this).SelectionMode = (DataGridViewSelectionMode)1;
			((DataGridViewBand)((DataGridView)this).Rows[e.RowIndex]).Selected = true;
		}
	}

	private void method_0(bool bool_4)
	{
		if (!bool_1)
		{
			if (!bool_4)
			{
				((Control)((DataGridView)this).VerticalScrollBar).Parent = (Control)(object)this;
			}
			else
			{
				((Control)((DataGridView)this).VerticalScrollBar).Parent = control_0;
			}
		}
	}

	protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
	{
		if (typeof(TreeGridColumn).IsAssignableFrom(((object)e.Column).GetType()) && LeEyqsmfrEi == null)
		{
			LeEyqsmfrEi = (TreeGridColumn)(object)e.Column;
		}
		e.Column.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridView)this).OnColumnAdded(e);
	}

	static TreeGridView()
	{
		Class72.smethod_20();
	}
}
