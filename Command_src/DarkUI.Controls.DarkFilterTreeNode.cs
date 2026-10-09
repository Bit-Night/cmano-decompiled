using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using DarkUI.Collections;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkFilterTreeNode
{
	[CompilerGenerated]
	private EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler_0;

	[CompilerGenerated]
	private EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler_1;

	[CompilerGenerated]
	private EventHandler eventHandler_2;

	[CompilerGenerated]
	private EventHandler eventHandler_3;

	[CompilerGenerated]
	private EventHandler eventHandler_4;

	private string string_0;

	private bool bool_0;

	private DarkFilterTreeView nuGeSfclojB;

	private DarkFilterTreeNode darkFilterTreeNode_0;

	private ObservableList<DarkFilterTreeNode> observableList_0;

	private bool bool_1;

	[CompilerGenerated]
	private Rectangle rectangle_0;

	[CompilerGenerated]
	private Rectangle rectangle_1;

	[CompilerGenerated]
	private Rectangle rectangle_2;

	[CompilerGenerated]
	private Rectangle rectangle_3;

	[CompilerGenerated]
	private bool bool_2;

	[CompilerGenerated]
	private Bitmap bitmap_0;

	[CompilerGenerated]
	private Bitmap bitmap_1;

	[CompilerGenerated]
	private bool bool_3;

	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

	[CompilerGenerated]
	private DarkFilterTreeNode darkFilterTreeNode_1;

	[CompilerGenerated]
	private DarkFilterTreeNode darkFilterTreeNode_2;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private Color color_0;

	[CompilerGenerated]
	private Font font_0;

	public string Text
	{
		get
		{
			return string_0;
		}
		set
		{
			if (!(string_0 == value))
			{
				string_0 = value;
				method_0();
			}
		}
	}

	public Rectangle ExpandArea
	{
		[CompilerGenerated]
		get
		{
			return rectangle_0;
		}
		[CompilerGenerated]
		set
		{
			rectangle_0 = value;
		}
	}

	public Rectangle IconArea
	{
		[CompilerGenerated]
		get
		{
			return rectangle_1;
		}
		[CompilerGenerated]
		set
		{
			rectangle_1 = value;
		}
	}

	public Rectangle TextArea
	{
		[CompilerGenerated]
		get
		{
			return rectangle_2;
		}
		[CompilerGenerated]
		set
		{
			rectangle_2 = value;
		}
	}

	public Rectangle FullArea
	{
		[CompilerGenerated]
		get
		{
			return rectangle_3;
		}
		[CompilerGenerated]
		set
		{
			rectangle_3 = value;
		}
	}

	public bool ExpandAreaHot
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public Bitmap Icon
	{
		[CompilerGenerated]
		get
		{
			return bitmap_0;
		}
		[CompilerGenerated]
		set
		{
			bitmap_0 = value;
		}
	}

	public Bitmap ExpandedIcon
	{
		[CompilerGenerated]
		get
		{
			return bitmap_1;
		}
		[CompilerGenerated]
		set
		{
			bitmap_1 = value;
		}
	}

	public bool Expanded
	{
		get
		{
			return bool_1;
		}
		set
		{
			if (bool_1 == value || (value && Nodes.Count == 0))
			{
				return;
			}
			bool_1 = value;
			if (bool_1)
			{
				if (eventHandler_3 != null)
				{
					eventHandler_3(this, null);
				}
			}
			else if (eventHandler_4 != null)
			{
				eventHandler_4(this, null);
			}
			ParentTree?.UpdateNodes();
		}
	}

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
				observableList_0.ItemsAdded -= method_1;
				observableList_0.ItemsRemoved -= method_2;
			}
			observableList_0 = value;
			observableList_0.ItemsAdded += method_1;
			observableList_0.ItemsRemoved += method_2;
		}
	}

	public bool IsRoot
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public DarkFilterTreeView ParentTree
	{
		get
		{
			return nuGeSfclojB;
		}
		set
		{
			if (nuGeSfclojB == value)
			{
				return;
			}
			nuGeSfclojB = value;
			foreach (DarkFilterTreeNode node in Nodes)
			{
				node.ParentTree = nuGeSfclojB;
			}
		}
	}

	public DarkFilterTreeNode ParentNode
	{
		get
		{
			return darkFilterTreeNode_0;
		}
		set
		{
			darkFilterTreeNode_0 = value;
		}
	}

	public bool Odd
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public object NodeType
	{
		[CompilerGenerated]
		get
		{
			return object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public object Tag
	{
		[CompilerGenerated]
		get
		{
			return object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	public string FullPath
	{
		get
		{
			DarkFilterTreeNode parentNode = ParentNode;
			string text = Text;
			while (parentNode != null)
			{
				text = string.Format("{0}{1}{2}", parentNode.Text, "\\", text);
				parentNode = parentNode.ParentNode;
			}
			return text;
		}
	}

	public DarkFilterTreeNode PrevVisibleNode
	{
		[CompilerGenerated]
		get
		{
			return darkFilterTreeNode_1;
		}
		[CompilerGenerated]
		set
		{
			darkFilterTreeNode_1 = value;
		}
	}

	public DarkFilterTreeNode NextVisibleNode
	{
		[CompilerGenerated]
		get
		{
			return darkFilterTreeNode_2;
		}
		[CompilerGenerated]
		set
		{
			darkFilterTreeNode_2 = value;
		}
	}

	public int VisibleIndex
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public Color ForeColor
	{
		[CompilerGenerated]
		get
		{
			return color_0;
		}
		[CompilerGenerated]
		set
		{
			color_0 = value;
		}
	}

	public Font Font
	{
		[CompilerGenerated]
		get
		{
			return font_0;
		}
		[CompilerGenerated]
		set
		{
			font_0 = value;
		}
	}

	public event EventHandler<ObservableListModified<DarkFilterTreeNode>> ItemsAdded
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler = eventHandler_0;
			EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<DarkFilterTreeNode>> value2 = (EventHandler<ObservableListModified<DarkFilterTreeNode>>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler = eventHandler_0;
			EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<DarkFilterTreeNode>> value2 = (EventHandler<ObservableListModified<DarkFilterTreeNode>>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<ObservableListModified<DarkFilterTreeNode>> ItemsRemoved
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler = eventHandler_1;
			EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<DarkFilterTreeNode>> value2 = (EventHandler<ObservableListModified<DarkFilterTreeNode>>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler = eventHandler_1;
			EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<DarkFilterTreeNode>> value2 = (EventHandler<ObservableListModified<DarkFilterTreeNode>>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler TextChanged
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

	public event EventHandler NodeExpanded
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

	public event EventHandler NodeCollapsed
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

	public bool IsNodeAncestor(DarkFilterTreeNode node)
	{
		DarkFilterTreeNode parentNode = ParentNode;
		while (parentNode != null)
		{
			if (parentNode != node)
			{
				parentNode = parentNode.ParentNode;
				continue;
			}
			return true;
		}
		return false;
	}

	public DarkFilterTreeNode()
	{
		Nodes = new ObservableList<DarkFilterTreeNode>();
		ForeColor = Colors.LightText;
	}

	public DarkFilterTreeNode(string text)
		: this()
	{
		Text = text;
	}

	public void Remove()
	{
		if (ParentNode != null)
		{
			ParentNode.Nodes.Remove(this);
		}
		else
		{
			ParentTree.Nodes.Remove(this);
		}
	}

	public void EnsureVisible()
	{
		for (DarkFilterTreeNode parentNode = ParentNode; parentNode != null; parentNode = parentNode.ParentNode)
		{
			parentNode.Expanded = true;
		}
	}

	private void method_0()
	{
		if (ParentTree != null && ParentTree.TreeViewNodeSorter != null)
		{
			if (ParentNode == null)
			{
				ParentTree.Nodes.Sort(ParentTree.TreeViewNodeSorter);
			}
			else
			{
				ParentNode.Nodes.Sort(ParentTree.TreeViewNodeSorter);
			}
		}
		if (eventHandler_2 != null)
		{
			eventHandler_2(this, null);
		}
	}

	private void method_1(object object_2, ObservableListModified<DarkFilterTreeNode> observableListModified_0)
	{
		foreach (DarkFilterTreeNode item in observableListModified_0.Items)
		{
			item.ParentNode = this;
			item.ParentTree = ParentTree;
		}
		if (ParentTree != null && ParentTree.TreeViewNodeSorter != null)
		{
			Nodes.Sort(ParentTree.TreeViewNodeSorter);
		}
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, observableListModified_0);
		}
	}

	private void method_2(object object_2, ObservableListModified<DarkFilterTreeNode> observableListModified_0)
	{
		if (Nodes.Count == 0)
		{
			Expanded = false;
		}
		if (eventHandler_1 != null)
		{
			eventHandler_1(this, observableListModified_0);
		}
	}

	static DarkFilterTreeNode()
	{
		Class72.smethod_20();
	}
}
