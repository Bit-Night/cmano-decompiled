using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AdvancedDataGridView;

public sealed class TreeGridNodeCollection : IList<TreeGridNode>, ICollection<TreeGridNode>, IEnumerable<TreeGridNode>, IEnumerable, IList, ICollection
{
	internal List<TreeGridNode> _list;

	internal TreeGridNode _owner;

	public TreeGridNode this[int index]
	{
		get
		{
			return _list[index];
		}
		set
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	public int Count => _list.Count;

	public bool IsReadOnly => false;

	bool IList.IsReadOnly => IsReadOnly;

	bool IList.IsFixedSize => false;

	int ICollection.Count => Count;

	object IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	bool ICollection.IsSynchronized
	{
		get
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	object ICollection.SyncRoot
	{
		get
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	internal TreeGridNodeCollection(TreeGridNode owner)
	{
		_owner = owner;
		_list = new List<TreeGridNode>();
	}

	public void Add(TreeGridNode item)
	{
		item._grid = _owner._grid;
		bool hasChildren = _owner.HasChildren;
		item._owner = this;
		_list.Add(item);
		_owner.AddChildNode(item);
		if (!hasChildren && _owner.IsSited)
		{
			((DataGridView)_owner._grid).InvalidateRow(_owner.RowIndex);
		}
	}

	public TreeGridNode Add(string text)
	{
		TreeGridNode treeGridNode = new TreeGridNode();
		Add(treeGridNode);
		treeGridNode.Cells[0].Value = text;
		return treeGridNode;
	}

	public TreeGridNode Add(params object[] values)
	{
		TreeGridNode treeGridNode = new TreeGridNode();
		Add(treeGridNode);
		int num = 0;
		if (values.Length > ((BaseCollection)treeGridNode.Cells).Count)
		{
			throw new ArgumentOutOfRangeException("values");
		}
		foreach (object value in values)
		{
			treeGridNode.Cells[num].Value = value;
			num++;
		}
		return treeGridNode;
	}

	public void Insert(int index, TreeGridNode item)
	{
		item._grid = _owner._grid;
		item._owner = this;
		_list.Insert(index, item);
		_owner.InsertChildNode(index, item);
	}

	public bool Remove(TreeGridNode item)
	{
		_owner.RemoveChildNode(item);
		item._grid = null;
		return _list.Remove(item);
	}

	public void RemoveAt(int index)
	{
		TreeGridNode treeGridNode = _list[index];
		_owner.RemoveChildNode(treeGridNode);
		treeGridNode._grid = null;
		_list.RemoveAt(index);
	}

	public void Clear()
	{
		_owner.ClearNodes();
		_list.Clear();
	}

	public int IndexOf(TreeGridNode item)
	{
		return _list.IndexOf(item);
	}

	public bool Contains(TreeGridNode item)
	{
		return _list.Contains(item);
	}

	public void CopyTo(TreeGridNode[] array, int arrayIndex)
	{
		throw new Exception("The method or operation is not implemented.");
	}

	void IList.Remove(object value)
	{
		Remove(value as TreeGridNode);
	}

	int IList.Add(object value)
	{
		TreeGridNode treeGridNode = value as TreeGridNode;
		Add(treeGridNode);
		return treeGridNode.Index;
	}

	void IList.RemoveAt(int index)
	{
		RemoveAt(index);
	}

	void IList.Clear()
	{
		Clear();
	}

	int IList.IndexOf(object item)
	{
		return IndexOf(item as TreeGridNode);
	}

	void IList.Insert(int index, object value)
	{
		Insert(index, value as TreeGridNode);
	}

	bool IList.Contains(object value)
	{
		return Contains(value as TreeGridNode);
	}

	void ICollection.CopyTo(Array array, int index)
	{
		throw new Exception("The method or operation is not implemented.");
	}

	public IEnumerator<TreeGridNode> GetEnumerator()
	{
		return _list.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	static TreeGridNodeCollection()
	{
		Class72.smethod_20();
	}
}
