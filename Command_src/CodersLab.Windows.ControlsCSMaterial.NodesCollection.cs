using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace CodersLab.Windows.ControlsCSMaterial;

public sealed class NodesCollection : CollectionBase
{
	[CompilerGenerated]
	private TreeNodeEventHandler treeNodeEventHandler_0;

	[CompilerGenerated]
	private TreeNodeEventHandler treeNodeEventHandler_1;

	[CompilerGenerated]
	private TreeNodeEventHandler treeNodeEventHandler_2;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	public TreeNode this[int index] => (TreeNode)base.List[index];

	internal event TreeNodeEventHandler TreeNodeAdded
	{
		[CompilerGenerated]
		add
		{
			TreeNodeEventHandler treeNodeEventHandler = treeNodeEventHandler_0;
			TreeNodeEventHandler treeNodeEventHandler2;
			do
			{
				treeNodeEventHandler2 = treeNodeEventHandler;
				TreeNodeEventHandler value2 = (TreeNodeEventHandler)Delegate.Combine(treeNodeEventHandler2, value);
				treeNodeEventHandler = Interlocked.CompareExchange(ref treeNodeEventHandler_0, value2, treeNodeEventHandler2);
			}
			while ((object)treeNodeEventHandler != treeNodeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TreeNodeEventHandler treeNodeEventHandler = treeNodeEventHandler_0;
			TreeNodeEventHandler treeNodeEventHandler2;
			do
			{
				treeNodeEventHandler2 = treeNodeEventHandler;
				TreeNodeEventHandler value2 = (TreeNodeEventHandler)Delegate.Remove(treeNodeEventHandler2, value);
				treeNodeEventHandler = Interlocked.CompareExchange(ref treeNodeEventHandler_0, value2, treeNodeEventHandler2);
			}
			while ((object)treeNodeEventHandler != treeNodeEventHandler2);
		}
	}

	internal event TreeNodeEventHandler TreeNodeRemoved
	{
		[CompilerGenerated]
		add
		{
			TreeNodeEventHandler treeNodeEventHandler = treeNodeEventHandler_1;
			TreeNodeEventHandler treeNodeEventHandler2;
			do
			{
				treeNodeEventHandler2 = treeNodeEventHandler;
				TreeNodeEventHandler value2 = (TreeNodeEventHandler)Delegate.Combine(treeNodeEventHandler2, value);
				treeNodeEventHandler = Interlocked.CompareExchange(ref treeNodeEventHandler_1, value2, treeNodeEventHandler2);
			}
			while ((object)treeNodeEventHandler != treeNodeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TreeNodeEventHandler treeNodeEventHandler = treeNodeEventHandler_1;
			TreeNodeEventHandler treeNodeEventHandler2;
			do
			{
				treeNodeEventHandler2 = treeNodeEventHandler;
				TreeNodeEventHandler value2 = (TreeNodeEventHandler)Delegate.Remove(treeNodeEventHandler2, value);
				treeNodeEventHandler = Interlocked.CompareExchange(ref treeNodeEventHandler_1, value2, treeNodeEventHandler2);
			}
			while ((object)treeNodeEventHandler != treeNodeEventHandler2);
		}
	}

	internal event TreeNodeEventHandler TreeNodeInserted
	{
		[CompilerGenerated]
		add
		{
			TreeNodeEventHandler treeNodeEventHandler = treeNodeEventHandler_2;
			TreeNodeEventHandler treeNodeEventHandler2;
			do
			{
				treeNodeEventHandler2 = treeNodeEventHandler;
				TreeNodeEventHandler value2 = (TreeNodeEventHandler)Delegate.Combine(treeNodeEventHandler2, value);
				treeNodeEventHandler = Interlocked.CompareExchange(ref treeNodeEventHandler_2, value2, treeNodeEventHandler2);
			}
			while ((object)treeNodeEventHandler != treeNodeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TreeNodeEventHandler treeNodeEventHandler = treeNodeEventHandler_2;
			TreeNodeEventHandler treeNodeEventHandler2;
			do
			{
				treeNodeEventHandler2 = treeNodeEventHandler;
				TreeNodeEventHandler value2 = (TreeNodeEventHandler)Delegate.Remove(treeNodeEventHandler2, value);
				treeNodeEventHandler = Interlocked.CompareExchange(ref treeNodeEventHandler_2, value2, treeNodeEventHandler2);
			}
			while ((object)treeNodeEventHandler != treeNodeEventHandler2);
		}
	}

	internal event EventHandler SelectedNodesCleared
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

	public int Add(TreeNode treeNode)
	{
		if (treeNodeEventHandler_0 != null)
		{
			treeNodeEventHandler_0(treeNode);
		}
		return base.List.Add(treeNode);
	}

	public void Insert(int index, TreeNode treeNode)
	{
		if (treeNodeEventHandler_2 != null)
		{
			treeNodeEventHandler_2(treeNode);
		}
		base.List.Add(treeNode);
	}

	public void Remove(TreeNode treeNode)
	{
		if (treeNodeEventHandler_1 != null)
		{
			treeNodeEventHandler_1(treeNode);
		}
		base.List.Remove(treeNode);
	}

	public bool Contains(TreeNode treeNode)
	{
		return base.List.Contains(treeNode);
	}

	public int IndexOf(TreeNode treeNode)
	{
		return base.List.IndexOf(treeNode);
	}

	protected override void OnClear()
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, EventArgs.Empty);
		}
		base.OnClear();
	}

	static NodesCollection()
	{
		Class72.smethod_20();
	}
}
