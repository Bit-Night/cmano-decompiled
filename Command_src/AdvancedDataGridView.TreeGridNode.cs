using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace AdvancedDataGridView;

[ToolboxItem(false)]
[DesignTimeVisible(false)]
public class TreeGridNode : DataGridViewRow
{
	internal TreeGridView _grid;

	internal TreeGridNode _parent;

	internal TreeGridNodeCollection _owner;

	internal bool _IsExpanded;

	internal bool _IsRoot;

	internal bool _isSited;

	internal bool _isFirstSibling;

	internal bool _isLastSibling;

	internal Image _image;

	internal int _imageIndex;

	private Random iRnyqqqyWlk = new Random();

	public int UniqueValue = -1;

	private TreeGridCell treeGridCell_0;

	private TreeGridNodeCollection treeGridNodeCollection_0;

	private int int_0;

	private int int_1;

	private bool bool_0;

	private ISite isite_0;

	private EventHandler eventHandler_0;

	public bool IsExpanded => _IsExpanded;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Description("Represents the index of this row in the Grid. Advanced usage.")]
	public int RowIndex => ((DataGridViewBand)this).Index;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int Index
	{
		get
		{
			if (int_0 == -1)
			{
				int_0 = _owner.IndexOf(this);
			}
			return int_0;
		}
		internal set
		{
			int_0 = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public ImageList ImageList
	{
		get
		{
			if (_grid == null)
			{
				return null;
			}
			return _grid.ImageList;
		}
	}

	[Category("Appearance")]
	[Description("...")]
	[TypeConverter(typeof(ImageIndexConverter))]
	[DefaultValue(-1)]
	[Editor("System.Windows.Forms.Design.ImageIndexEditor", typeof(UITypeEditor))]
	public int ImageIndex
	{
		get
		{
			return _imageIndex;
		}
		set
		{
			_imageIndex = value;
			if (_imageIndex != -1)
			{
				_image = null;
			}
			if (_isSited)
			{
				treeGridCell_0.UpdateStyle();
				if (((DataGridViewBand)this).Displayed)
				{
					((DataGridView)_grid).InvalidateRow(RowIndex);
				}
			}
		}
	}

	public Image Image
	{
		get
		{
			if (_image == null && _imageIndex != -1)
			{
				if (ImageList != null && _imageIndex < ImageList.Images.Count)
				{
					return ImageList.Images[_imageIndex];
				}
				return null;
			}
			return _image;
		}
		set
		{
			_image = value;
			if (_image != null)
			{
				_imageIndex = -1;
			}
			if (_isSited)
			{
				treeGridCell_0.UpdateStyle();
				if (((DataGridViewBand)this).Displayed)
				{
					((DataGridView)_grid).InvalidateRow(RowIndex);
				}
			}
		}
	}

	[Category("Data")]
	[Description("The collection of root nodes in the treelist.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
	public TreeGridNodeCollection Nodes
	{
		get
		{
			if (treeGridNodeCollection_0 == null)
			{
				treeGridNodeCollection_0 = new TreeGridNodeCollection(this);
			}
			return treeGridNodeCollection_0;
		}
		set
		{
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public DataGridViewCellCollection Cells
	{
		get
		{
			if (!bool_0 && ((DataGridViewElement)this).DataGridView == null)
			{
				if (_grid == null)
				{
					return null;
				}
				((DataGridViewRow)this).CreateCells((DataGridView)(object)_grid);
				bool_0 = true;
			}
			return ((DataGridViewRow)this).Cells;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int Level
	{
		get
		{
			if (int_1 == -1)
			{
				int num = 0;
				for (TreeGridNode parent = Parent; parent != null; parent = parent.Parent)
				{
					num++;
				}
				int_1 = num;
			}
			return int_1;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public TreeGridNode Parent => _parent;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual bool HasChildren
	{
		get
		{
			if (treeGridNodeCollection_0 == null)
			{
				return false;
			}
			return Nodes.Count != 0;
		}
	}

	[Browsable(false)]
	public bool IsSited => _isSited;

	[Browsable(false)]
	public bool IsFirstSibling => Index == 0;

	[Browsable(false)]
	public bool IsLastSibling
	{
		get
		{
			TreeGridNode parent = Parent;
			int result;
			if (parent != null)
			{
				if (parent.HasChildren)
				{
					return Index == parent.Nodes.Count - 1;
				}
				result = 1;
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ISite Site
	{
		get
		{
			return isite_0;
		}
		set
		{
			isite_0 = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public event EventHandler Disposed
	{
		add
		{
			eventHandler_0 = (EventHandler)Delegate.Combine(eventHandler_0, value);
		}
		remove
		{
			eventHandler_0 = (EventHandler)Delegate.Remove(eventHandler_0, value);
		}
	}

	internal TreeGridNode(TreeGridView owner)
		: this()
	{
		_grid = owner;
		_IsExpanded = true;
	}

	public TreeGridNode()
	{
		int_0 = -1;
		int_1 = -1;
		_IsExpanded = false;
		UniqueValue = iRnyqqqyWlk.Next();
		_isSited = false;
		_isFirstSibling = false;
		_isLastSibling = false;
		_imageIndex = -1;
	}

	public override object Clone()
	{
		TreeGridNode treeGridNode = (TreeGridNode)((DataGridViewRow)this).Clone();
		treeGridNode.UniqueValue = -1;
		treeGridNode.int_1 = int_1;
		treeGridNode._grid = _grid;
		treeGridNode._parent = Parent;
		treeGridNode._imageIndex = _imageIndex;
		if (treeGridNode._imageIndex == -1)
		{
			treeGridNode.Image = Image;
		}
		treeGridNode._IsExpanded = _IsExpanded;
		return treeGridNode;
	}

	protected internal virtual void UnSited()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		foreach (DataGridViewCell item in (BaseCollection)Cells)
		{
			if (item is TreeGridCell treeGridCell)
			{
				treeGridCell.UnSited();
			}
		}
		_isSited = false;
	}

	protected internal virtual void Sited()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		_isSited = true;
		bool_0 = true;
		foreach (DataGridViewCell item in (BaseCollection)Cells)
		{
			if (item is TreeGridCell treeGridCell)
			{
				treeGridCell.Sited();
			}
		}
	}

	private bool ShouldSerializeImageIndex()
	{
		if (_imageIndex != -1)
		{
			return _image == null;
		}
		return false;
	}

	private bool ShouldSerializeImage()
	{
		if (_imageIndex == -1)
		{
			return _image != null;
		}
		return false;
	}

	protected override DataGridViewCellCollection CreateCellsInstance()
	{
		DataGridViewCellCollection obj = ((DataGridViewRow)this).CreateCellsInstance();
		obj.CollectionChanged += method_0;
		return obj;
	}

	private void method_0(object sender, CollectionChangeEventArgs e)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		if (treeGridCell_0 != null || (e.Action != CollectionChangeAction.Add && e.Action != CollectionChangeAction.Refresh))
		{
			return;
		}
		TreeGridCell treeGridCell = null;
		if (e.Element == null)
		{
			foreach (DataGridViewCell item in (BaseCollection)((DataGridViewRow)this).Cells)
			{
				DataGridViewCell val = item;
				if (((object)val).GetType().IsAssignableFrom(typeof(TreeGridCell)))
				{
					treeGridCell = (TreeGridCell)(object)val;
					break;
				}
			}
		}
		else
		{
			treeGridCell = e.Element as TreeGridCell;
		}
		if (treeGridCell != null)
		{
			treeGridCell_0 = treeGridCell;
		}
	}

	public virtual bool Collapse()
	{
		return _grid.CollapseNode(this);
	}

	public virtual bool Expand()
	{
		if (_grid == null)
		{
			_IsExpanded = true;
			return true;
		}
		return _grid.ExpandNode(this);
	}

	protected internal virtual bool InsertChildNode(int index, TreeGridNode node)
	{
		node._parent = this;
		node._grid = _grid;
		if (_grid != null)
		{
			method_1(node);
		}
		int result;
		if (!_isSited && !_IsRoot)
		{
			result = 1;
		}
		else if (!_IsExpanded)
		{
			result = 1;
		}
		else
		{
			_grid.SiteNode(node);
			result = 1;
		}
		return (byte)result != 0;
	}

	protected internal virtual bool InsertChildNodes(int index, params TreeGridNode[] nodes)
	{
		foreach (TreeGridNode node in nodes)
		{
			InsertChildNode(index, node);
		}
		return true;
	}

	protected internal virtual bool AddChildNode(TreeGridNode node)
	{
		node._parent = this;
		node._grid = _grid;
		if (_grid != null)
		{
			method_1(node);
		}
		int result;
		if (!_isSited && !_IsRoot)
		{
			result = 1;
		}
		else if (!_IsExpanded)
		{
			result = 1;
		}
		else if (node._isSited)
		{
			result = 1;
		}
		else
		{
			_grid.SiteNode(node);
			result = 1;
		}
		return (byte)result != 0;
	}

	protected internal virtual bool AddChildNodes(params TreeGridNode[] nodes)
	{
		foreach (TreeGridNode node in nodes)
		{
			AddChildNode(node);
		}
		return true;
	}

	protected internal virtual bool RemoveChildNode(TreeGridNode node)
	{
		if ((_IsRoot || _isSited) && _IsExpanded)
		{
			_grid.UnSiteNode(node);
		}
		foreach (TreeGridNode node2 in Nodes)
		{
			node2.int_0 = -1;
		}
		node._grid = null;
		node._parent = null;
		return true;
	}

	protected internal virtual bool ClearNodes()
	{
		int result;
		if (!HasChildren)
		{
			result = 1;
		}
		else
		{
			for (int num = Nodes.Count - 1; num >= 0; num--)
			{
				Nodes.RemoveAt(num);
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	private void method_1(TreeGridNode treeGridNode_0)
	{
		if (!treeGridNode_0.HasChildren)
		{
			return;
		}
		foreach (TreeGridNode node in treeGridNode_0.Nodes)
		{
			node._grid = treeGridNode_0._grid;
			method_1(node);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(36);
		stringBuilder.Append("TreeGridNode { Index=");
		stringBuilder.Append(RowIndex.ToString(CultureInfo.CurrentCulture));
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	static TreeGridNode()
	{
		Class72.smethod_20();
	}
}
