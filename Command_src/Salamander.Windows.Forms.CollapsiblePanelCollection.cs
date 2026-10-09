using System;
using System.Collections;

namespace Salamander.Windows.Forms;

public sealed class CollapsiblePanelCollection : CollectionBase
{
	public void Add(CollapsiblePanel panel)
	{
		base.List.Add(panel);
	}

	public void Remove(int index)
	{
		if (index >= base.Count || index < 0)
		{
			throw new IndexOutOfRangeException("The supplied index is out of range");
		}
		base.List.RemoveAt(index);
	}

	public CollapsiblePanel Item(int index)
	{
		if (index >= base.Count || index < 0)
		{
			throw new IndexOutOfRangeException("The supplied index is out of range");
		}
		return (CollapsiblePanel)base.List[index];
	}

	public void Insert(int index, CollapsiblePanel panel)
	{
		base.List.Insert(index, panel);
	}

	public void CopyTo(Array array, int index)
	{
		base.List.CopyTo(array, index);
	}

	public int IndexOf(CollapsiblePanel panel)
	{
		return base.List.IndexOf(panel);
	}

	static CollapsiblePanelCollection()
	{
		Class72.smethod_20();
	}
}
