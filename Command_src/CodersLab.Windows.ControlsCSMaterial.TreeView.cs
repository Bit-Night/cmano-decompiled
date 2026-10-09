using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace CodersLab.Windows.ControlsCSMaterial;

[ToolboxItem(true)]
public sealed class TreeView : TreeView
{
	[CompilerGenerated]
	private TreeViewEventHandler treeViewEventHandler_0;

	[CompilerGenerated]
	private TreeViewEventHandler treeViewEventHandler_1;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private Container container_0;

	private bool bool_0;

	private Hashtable hashtable_0 = new Hashtable();

	private bool bool_1;

	private Hashtable hashtable_1 = new Hashtable();

	private TreeNode treeNode_0;

	private bool bool_2;

	private TreeNode treeNode_1;

	private TreeNode treeNode_2;

	private int int_0;

	private TreeViewSelectionMode treeViewSelectionMode_0;

	private Color color_0 = SystemColors.Highlight;

	private bool bool_3;

	private TreeNode treeNode_3;

	private TreeNode treeNode_4;

	public TreeNode SelectedNode
	{
		get
		{
			if (!bool_0)
			{
				throw new NotSupportedException("Use SelectedNodes instead of SelectedNode.");
			}
			return ((TreeView)this).SelectedNode;
		}
		set
		{
			if (!bool_0)
			{
				throw new NotSupportedException("Use SelectedNodes instead of SelectedNode.");
			}
			((TreeView)this).SelectedNode = value;
		}
	}

	public TreeViewSelectionMode SelectionMode
	{
		get
		{
			return treeViewSelectionMode_0;
		}
		set
		{
			treeViewSelectionMode_0 = value;
		}
	}

	public Color SelectionBackColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public NodesCollection SelectedNodes
	{
		get
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			NodesCollection nodesCollection = new NodesCollection();
			foreach (TreeNode value in hashtable_0.Values)
			{
				TreeNode treeNode = value;
				nodesCollection.Add(treeNode);
			}
			nodesCollection.TreeNodeAdded += method_0;
			nodesCollection.TreeNodeInserted += method_1;
			nodesCollection.TreeNodeRemoved += method_2;
			nodesCollection.SelectedNodesCleared += method_3;
			return nodesCollection;
		}
	}

	public event TreeViewEventHandler AfterDeselect
	{
		[CompilerGenerated]
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			TreeViewEventHandler val = treeViewEventHandler_0;
			TreeViewEventHandler val2;
			do
			{
				val2 = val;
				TreeViewEventHandler value2 = (TreeViewEventHandler)Delegate.Combine((Delegate?)(object)val2, (Delegate?)(object)value);
				val = Interlocked.CompareExchange(ref treeViewEventHandler_0, value2, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			TreeViewEventHandler val = treeViewEventHandler_0;
			TreeViewEventHandler val2;
			do
			{
				val2 = val;
				TreeViewEventHandler value2 = (TreeViewEventHandler)Delegate.Remove((Delegate?)(object)val2, (Delegate?)(object)value);
				val = Interlocked.CompareExchange(ref treeViewEventHandler_0, value2, val2);
			}
			while (val != val2);
		}
	}

	public event TreeViewEventHandler BeforeDeselect
	{
		[CompilerGenerated]
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			TreeViewEventHandler val = treeViewEventHandler_1;
			TreeViewEventHandler val2;
			do
			{
				val2 = val;
				TreeViewEventHandler value2 = (TreeViewEventHandler)Delegate.Combine((Delegate?)(object)val2, (Delegate?)(object)value);
				val = Interlocked.CompareExchange(ref treeViewEventHandler_1, value2, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			TreeViewEventHandler val = treeViewEventHandler_1;
			TreeViewEventHandler val2;
			do
			{
				val2 = val;
				TreeViewEventHandler value2 = (TreeViewEventHandler)Delegate.Remove((Delegate?)(object)val2, (Delegate?)(object)value);
				val = Interlocked.CompareExchange(ref treeViewEventHandler_1, value2, val2);
			}
			while (val != val2);
		}
	}

	public event EventHandler SelectionsChanged
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

	public TreeView()
	{
		method_19();
		((Control)this).SetStyle((ControlStyles)131072, true);
		((Control)this).SetStyle((ControlStyles)8192, true);
		((Control)this).UpdateStyles();
	}

	protected void OnAfterDeselect(TreeNode tn)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		if (treeViewEventHandler_0 != null)
		{
			treeViewEventHandler_0.Invoke((object)this, new TreeViewEventArgs(tn));
		}
	}

	protected void OnBeforeDeselect(TreeNode tn)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		if (treeViewEventHandler_1 != null)
		{
			treeViewEventHandler_1.Invoke((object)this, new TreeViewEventArgs(tn));
		}
	}

	protected void OnSelectionsChanged()
	{
		if (bool_1 && eventHandler_0 != null)
		{
			eventHandler_0(this, new EventArgs());
		}
	}

	private void method_0(TreeNode treeNode_5)
	{
		bool_1 = false;
		method_11(treeNode_5, bool_4: true, (TreeViewAction)0);
		OnSelectionsChanged();
	}

	private void method_1(TreeNode treeNode_5)
	{
		bool_1 = false;
		method_11(treeNode_5, bool_4: true, (TreeViewAction)0);
		OnSelectionsChanged();
	}

	private void method_2(TreeNode treeNode_5)
	{
		bool_1 = false;
		method_11(treeNode_5, bool_4: false, (TreeViewAction)0);
		OnSelectionsChanged();
		if (treeNode_2 == treeNode_5)
		{
			treeNode_2 = null;
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		bool_1 = false;
		method_4((TreeViewAction)0);
		OnSelectionsChanged();
	}

	private void method_4(TreeViewAction treeViewAction_0)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		method_8(null, treeViewAction_0);
	}

	private void method_5(int int_1, TreeViewAction treeViewAction_0)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		ArrayList arrayList = new ArrayList();
		foreach (TreeNode value in hashtable_0.Values)
		{
			TreeNode val = value;
			if (GetNodeLevel(val) != int_1)
			{
				arrayList.Add(val);
			}
		}
		foreach (TreeNode item in arrayList)
		{
			TreeNode treeNode_ = item;
			method_11(treeNode_, bool_4: false, treeViewAction_0);
		}
	}

	private void method_6(TreeNode treeNode_5, TreeViewAction treeViewAction_0)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		ArrayList arrayList = new ArrayList();
		foreach (TreeNode value in hashtable_0.Values)
		{
			TreeNode val = value;
			if (val.Parent != treeNode_5)
			{
				arrayList.Add(val);
			}
		}
		foreach (TreeNode item in arrayList)
		{
			TreeNode treeNode_6 = item;
			method_11(treeNode_6, bool_4: false, treeViewAction_0);
		}
	}

	private void method_7(TreeNode treeNode_5, TreeViewAction treeViewAction_0)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		ArrayList arrayList = new ArrayList();
		foreach (TreeNode value in hashtable_0.Values)
		{
			TreeNode val = value;
			if (!method_14(val, treeNode_5))
			{
				arrayList.Add(val);
			}
		}
		foreach (TreeNode item in arrayList)
		{
			TreeNode treeNode_6 = item;
			method_11(treeNode_6, bool_4: false, treeViewAction_0);
		}
	}

	private void method_8(TreeNode treeNode_5, TreeViewAction treeViewAction_0)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		ArrayList arrayList = new ArrayList();
		foreach (TreeNode value in hashtable_0.Values)
		{
			TreeNode val = value;
			if (treeNode_5 != null)
			{
				if (treeNode_5 != null && val != treeNode_5)
				{
					arrayList.Add(val);
				}
			}
			else
			{
				arrayList.Add(val);
			}
		}
		foreach (TreeNode item in arrayList)
		{
			TreeNode treeNode_6 = item;
			method_11(treeNode_6, bool_4: false, treeViewAction_0);
		}
	}

	protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
	{
		((CancelEventArgs)(object)e).Cancel = true;
	}

	private bool method_9(TreeNode treeNode_5)
	{
		if (treeNode_5 == null)
		{
			return false;
		}
		return hashtable_0.ContainsKey(((object)treeNode_5).GetHashCode());
	}

	private void method_10(TreeNode treeNode_5)
	{
		if (treeNode_5 != null && !hashtable_1.ContainsKey(((object)treeNode_5).GetHashCode()))
		{
			hashtable_1.Add(((object)treeNode_5).GetHashCode(), new Color[2] { treeNode_5.BackColor, treeNode_5.ForeColor });
		}
	}

	private bool method_11(TreeNode treeNode_5, bool bool_4, TreeViewAction treeViewAction_0)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		bool result = false;
		if (treeNode_5 == null)
		{
			return false;
		}
		if (bool_4)
		{
			if (!method_9(treeNode_5))
			{
				TreeViewCancelEventArgs e = new TreeViewCancelEventArgs(treeNode_5, false, treeViewAction_0);
				((TreeView)this).OnBeforeSelect(e);
				if (((CancelEventArgs)(object)e).Cancel)
				{
					return false;
				}
				method_10(treeNode_5);
				treeNode_5.BackColor = SelectionBackColor;
				treeNode_5.ForeColor = ((Control)this).BackColor;
				hashtable_0.Add(((object)treeNode_5).GetHashCode(), treeNode_5);
				result = true;
				bool_1 = true;
				((TreeView)this).OnAfterSelect(new TreeViewEventArgs(treeNode_5, treeViewAction_0));
			}
			treeNode_1 = treeNode_5;
		}
		else if (method_9(treeNode_5))
		{
			OnBeforeDeselect(treeNode_5);
			Color[] array = (Color[])hashtable_1[((object)treeNode_5).GetHashCode()];
			if (array != null)
			{
				hashtable_0.Remove(((object)treeNode_5).GetHashCode());
				bool_1 = true;
				hashtable_1.Remove(((object)treeNode_5).GetHashCode());
				treeNode_5.BackColor = array[0];
				treeNode_5.ForeColor = array[1];
			}
			OnAfterDeselect(treeNode_5);
		}
		return result;
	}

	private void LvYyUciRpBu(TreeNode treeNode_5, TreeNode treeNode_6, TreeViewAction treeViewAction_0)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		TreeNode val = null;
		TreeNode val2 = null;
		if (treeNode_5.Bounds.Y < treeNode_6.Bounds.Y)
		{
			val = treeNode_5;
			val2 = treeNode_6;
		}
		else
		{
			val = treeNode_6;
			val2 = treeNode_5;
		}
		method_11(val, bool_4: true, treeViewAction_0);
		TreeNode val3 = val;
		while (val3 != val2)
		{
			val3 = val3.NextVisibleNode;
			if (val3 != null)
			{
				method_11(val3, bool_4: true, treeViewAction_0);
			}
		}
		method_11(val2, bool_4: true, treeViewAction_0);
	}

	private void rgByUzodZh7(TreeNode treeNode_5, TreeNode treeNode_6, TreeViewAction treeViewAction_0)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		TreeNode val = null;
		TreeNode val2 = null;
		if (treeNode_5.Bounds.Y < treeNode_6.Bounds.Y)
		{
			val = treeNode_5;
			val2 = treeNode_6;
		}
		else
		{
			val = treeNode_6;
			val2 = treeNode_5;
		}
		TreeNode val3 = val;
		while (val3 != null)
		{
			val3 = val3.PrevVisibleNode;
			if (val3 != null)
			{
				method_11(val3, bool_4: false, treeViewAction_0);
			}
		}
		val3 = val2;
		while (val3 != null)
		{
			val3 = val3.NextVisibleNode;
			if (val3 != null)
			{
				method_11(val3, bool_4: false, treeViewAction_0);
			}
		}
	}

	private void method_12(TreeNode treeNode_5, TreeViewAction treeViewAction_0)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		method_11(treeNode_5, bool_4: false, treeViewAction_0);
		foreach (TreeNode node in treeNode_5.Nodes)
		{
			TreeNode treeNode_6 = node;
			method_12(treeNode_6, treeViewAction_0);
		}
	}

	private bool method_13(TreeNode treeNode_5, MouseEventArgs mouseEventArgs_0)
	{
		if (treeNode_5 != null)
		{
			int num = treeNode_5.Bounds.X + treeNode_5.Bounds.Width;
			if (treeNode_5 != null)
			{
				return mouseEventArgs_0.X < num;
			}
			return false;
		}
		return false;
	}

	public int GetNodeLevel(TreeNode node)
	{
		int num = 0;
		while ((node = node.Parent) != null)
		{
			num++;
		}
		return num;
	}

	private bool method_14(TreeNode treeNode_5, TreeNode treeNode_6)
	{
		bool result = false;
		TreeNode val = treeNode_5;
		while (val != null)
		{
			if (val != treeNode_6)
			{
				val = val.Parent;
				continue;
			}
			result = true;
			break;
		}
		return result;
	}

	public TreeNode GetRootParent(TreeNode child)
	{
		TreeNode val = child;
		while (val.Parent != null)
		{
			val = val.Parent;
		}
		return val;
	}

	private int method_15()
	{
		int num = 0;
		for (TreeNode val = ((TreeView)this).Nodes[0]; val != null; val = val.NextVisibleNode)
		{
			if (val.IsVisible)
			{
				num++;
			}
		}
		return num;
	}

	private TreeNode method_16()
	{
		TreeNode val = ((TreeView)this).Nodes[0];
		while (val.NextVisibleNode != null)
		{
			val = val.NextVisibleNode;
		}
		return val;
	}

	private TreeNode method_17(TreeNode treeNode_5, bool bool_4, int int_1)
	{
		int i = 0;
		TreeNode val = treeNode_5;
		for (; i < int_1; i++)
		{
			if (!bool_4)
			{
				if (val.PrevVisibleNode == null)
				{
					break;
				}
				val = val.PrevVisibleNode;
			}
			else
			{
				if (val.NextVisibleNode == null)
				{
					break;
				}
				val = val.NextVisibleNode;
			}
		}
		return val;
	}

	private void method_18(TreeNode treeNode_5, bool bool_4)
	{
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		Graphics val = ((Control)this).CreateGraphics();
		Rectangle rectangle = new Rectangle(treeNode_5.Bounds.X, treeNode_5.Bounds.Y, treeNode_5.Bounds.Width, treeNode_5.Bounds.Height);
		if (!bool_4)
		{
			if (treeNode_5.BackColor != SelectionBackColor)
			{
				val.DrawRectangle(new Pen((Brush)new SolidBrush(((Control)this).BackColor), 1f), treeNode_1.Bounds.X, treeNode_1.Bounds.Y, treeNode_1.Bounds.Width, treeNode_1.Bounds.Height);
			}
			((Control)this).Invalidate(rectangle, false);
			((Control)this).Update();
		}
		else
		{
			((Control)this).Invalidate(rectangle, false);
			((Control)this).Update();
			if (treeNode_5.BackColor != SelectionBackColor)
			{
				val.DrawRectangle(new Pen((Brush)new SolidBrush(SelectionBackColor), 1f), rectangle);
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_0 != null)
		{
			container_0.Dispose();
		}
		((TreeView)this).Dispose(disposing);
	}

	private void method_19()
	{
		container_0 = new Container();
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_3)
		{
			TreeNode nodeAt = ((TreeView)this).GetNodeAt(e.X, e.Y);
			if (method_13(nodeAt, e))
			{
				method_23(treeNode_1, nodeAt, e, Control.ModifierKeys, (TreeViewAction)2, bool_4: true);
			}
		}
		bool_3 = false;
		((Control)this).OnMouseUp(e);
	}

	private bool method_20(TreeNode treeNode_5, MouseEventArgs mouseEventArgs_0)
	{
		int nodeLevel = GetNodeLevel(treeNode_5);
		bool result = false;
		if (mouseEventArgs_0.X < 20 + nodeLevel * 20)
		{
			result = true;
		}
		return result;
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		treeNode_4 = null;
		int_0 = e.Clicks;
		TreeNode nodeAt = ((TreeView)this).GetNodeAt(e.X, e.Y);
		if (nodeAt != null)
		{
			method_10(nodeAt);
			if (!method_20(nodeAt, e) && nodeAt != null && method_13(nodeAt, e) && !method_9(nodeAt))
			{
				treeNode_3 = nodeAt;
				new Thread(method_21).Start();
				bool_3 = true;
				method_23(treeNode_1, nodeAt, e, Control.ModifierKeys, (TreeViewAction)2, bool_4: true);
			}
			((Control)this).OnMouseDown(e);
		}
	}

	private void method_21()
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		if (!((Control)this).InvokeRequired)
		{
			TreeNode val = treeNode_3;
			if (!method_9(val))
			{
				val.BackColor = SelectionBackColor;
				val.ForeColor = ((Control)this).BackColor;
				((Control)this).Invalidate();
				((Control)this).Refresh();
				Application.DoEvents();
				Thread.Sleep(200);
			}
			if (!method_9(val))
			{
				val.BackColor = ((Control)this).BackColor;
				val.ForeColor = ((Control)this).ForeColor;
			}
		}
		else
		{
			((Control)this).Invoke((Delegate)(MethodInvoker)delegate
			{
				method_21();
			});
		}
	}

	private void method_22()
	{
		Thread.Sleep(200);
		if (!bool_2)
		{
			bool_0 = true;
			SelectedNode = treeNode_0;
			bool_0 = false;
			treeNode_0.BeginEdit();
		}
		else
		{
			bool_2 = false;
		}
	}

	private void method_23(TreeNode treeNode_5, TreeNode treeNode_6, MouseEventArgs mouseEventArgs_0, Keys keys_0, TreeViewAction treeViewAction_0, bool bool_4)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0702: Unknown result type (might be due to invalid IL or missing references)
		//IL_070c: Invalid comparison between Unknown and I4
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0718: Unknown result type (might be due to invalid IL or missing references)
		//IL_0722: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0591: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0682: Unknown result type (might be due to invalid IL or missing references)
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		//IL_051d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		bool_1 = false;
		if ((int)mouseEventArgs_0.Button == 1048576)
		{
			bool_2 = int_0 == 2;
			TreeNode val = null;
			if ((keys_0 & 0x20000) == 0 && (keys_0 & 0x10000) == 0)
			{
				treeNode_2 = treeNode_6;
				int count = SelectedNodes.Count;
				if (bool_2)
				{
					((Control)this).OnMouseDown(mouseEventArgs_0);
					return;
				}
				if (!method_20(treeNode_6, mouseEventArgs_0))
				{
					bool flag = false;
					if (method_9(treeNode_6))
					{
						flag = true;
					}
					method_8(treeNode_6, treeViewAction_0);
					method_11(treeNode_6, bool_4: true, treeViewAction_0);
					if (flag && ((TreeView)this).LabelEdit && bool_4 && !bool_2 && count <= 1)
					{
						treeNode_0 = treeNode_6;
						new Thread(method_22).Start();
					}
				}
			}
			else if ((keys_0 & 0x20000) != 0 && (keys_0 & 0x10000) == 0)
			{
				treeNode_2 = null;
				if (method_9(treeNode_6))
				{
					method_11(treeNode_6, bool_4: false, treeViewAction_0);
				}
				else
				{
					switch (treeViewSelectionMode_0)
					{
					case TreeViewSelectionMode.SingleSelect:
						method_8(treeNode_6, treeViewAction_0);
						break;
					case TreeViewSelectionMode.MultiSelectSameRootBranch:
					{
						TreeNode rootParent2 = GetRootParent(treeNode_6);
						method_7(rootParent2, treeViewAction_0);
						break;
					}
					case TreeViewSelectionMode.MultiSelectSameLevel:
						method_5(GetNodeLevel(treeNode_6), treeViewAction_0);
						break;
					case TreeViewSelectionMode.MultiSelectSameLevelAndRootBranch:
					{
						TreeNode rootParent = GetRootParent(treeNode_6);
						method_7(rootParent, treeViewAction_0);
						method_5(GetNodeLevel(treeNode_6), treeViewAction_0);
						break;
					}
					case TreeViewSelectionMode.MultiSelectSameParent:
					{
						TreeNode parent = treeNode_6.Parent;
						method_6(parent, treeViewAction_0);
						break;
					}
					}
					method_11(treeNode_6, bool_4: true, treeViewAction_0);
				}
			}
			else if ((keys_0 & 0x20000) == 0 && (keys_0 & 0x10000) != 0)
			{
				if (treeNode_5 != null)
				{
					if (treeNode_2 == null)
					{
						treeNode_2 = treeNode_5;
					}
					switch (treeViewSelectionMode_0)
					{
					case TreeViewSelectionMode.SingleSelect:
						method_8(treeNode_6, treeViewAction_0);
						method_11(treeNode_6, bool_4: true, treeViewAction_0);
						break;
					case TreeViewSelectionMode.MultiSelect:
						LvYyUciRpBu(treeNode_2, treeNode_6, treeViewAction_0);
						rgByUzodZh7(treeNode_2, treeNode_6, treeViewAction_0);
						break;
					case TreeViewSelectionMode.MultiSelectSameRootBranch:
					{
						TreeNode rootParent5 = GetRootParent(treeNode_5);
						val = treeNode_5;
						while (val != null && val != treeNode_6)
						{
							val = ((treeNode_5.Bounds.Y > treeNode_6.Bounds.Y) ? val.PrevVisibleNode : val.NextVisibleNode);
							if (val != null && GetRootParent(val) == rootParent5)
							{
								method_11(val, bool_4: true, treeViewAction_0);
							}
						}
						method_7(rootParent5, treeViewAction_0);
						rgByUzodZh7(treeNode_2, treeNode_6, treeViewAction_0);
						break;
					}
					case TreeViewSelectionMode.MultiSelectSameLevel:
					{
						int nodeLevel = GetNodeLevel(treeNode_5);
						val = treeNode_5;
						while (val != null && val != treeNode_6)
						{
							val = ((treeNode_5.Bounds.Y <= treeNode_6.Bounds.Y) ? val.NextVisibleNode : val.PrevVisibleNode);
							if (val != null && GetNodeLevel(val) == nodeLevel)
							{
								method_11(val, bool_4: true, treeViewAction_0);
							}
						}
						method_5(nodeLevel, treeViewAction_0);
						rgByUzodZh7(treeNode_2, treeNode_6, treeViewAction_0);
						break;
					}
					case TreeViewSelectionMode.MultiSelectSameLevelAndRootBranch:
					{
						TreeNode rootParent3 = GetRootParent(treeNode_5);
						int nodeLevel = GetNodeLevel(treeNode_5);
						val = treeNode_5;
						while (val != null && val != treeNode_6)
						{
							val = ((treeNode_5.Bounds.Y <= treeNode_6.Bounds.Y) ? val.NextVisibleNode : val.PrevVisibleNode);
							if (val != null)
							{
								int nodeLevel2 = GetNodeLevel(val);
								TreeNode rootParent4 = GetRootParent(val);
								if (nodeLevel2 == nodeLevel && rootParent4 == rootParent3)
								{
									method_11(val, bool_4: true, treeViewAction_0);
								}
							}
						}
						method_7(rootParent3, treeViewAction_0);
						method_5(nodeLevel, treeViewAction_0);
						rgByUzodZh7(treeNode_2, treeNode_6, treeViewAction_0);
						break;
					}
					case TreeViewSelectionMode.MultiSelectSameParent:
					{
						TreeNode parent2 = treeNode_5.Parent;
						val = treeNode_5;
						while (val != null && val != treeNode_6)
						{
							val = ((treeNode_5.Bounds.Y > treeNode_6.Bounds.Y) ? val.PrevVisibleNode : val.NextVisibleNode);
							if (val != null && val.Parent == parent2)
							{
								method_11(val, bool_4: true, treeViewAction_0);
							}
						}
						method_6(parent2, treeViewAction_0);
						rgByUzodZh7(treeNode_2, treeNode_6, treeViewAction_0);
						break;
					}
					}
				}
				else
				{
					method_8(treeNode_6, treeViewAction_0);
					method_11(treeNode_6, bool_4: true, treeViewAction_0);
				}
			}
			else if ((keys_0 & 0x20000) != 0 && (keys_0 & 0x10000) != 0)
			{
				switch (treeViewSelectionMode_0)
				{
				case TreeViewSelectionMode.SingleSelect:
					method_8(treeNode_6, treeViewAction_0);
					method_11(treeNode_6, bool_4: true, treeViewAction_0);
					break;
				case TreeViewSelectionMode.MultiSelect:
					val = treeNode_5;
					while (val != null && val != treeNode_6)
					{
						val = ((treeNode_5.Bounds.Y <= treeNode_6.Bounds.Y) ? val.NextVisibleNode : val.PrevVisibleNode);
						if (val != null)
						{
							method_11(val, bool_4: true, treeViewAction_0);
						}
					}
					break;
				case TreeViewSelectionMode.MultiSelectSameRootBranch:
				{
					TreeNode rootParent8 = GetRootParent(treeNode_5);
					val = treeNode_5;
					while (val != null && val != treeNode_6)
					{
						val = ((treeNode_5.Bounds.Y > treeNode_6.Bounds.Y) ? val.PrevVisibleNode : val.NextVisibleNode);
						if (val != null && GetRootParent(val) == rootParent8)
						{
							method_11(val, bool_4: true, treeViewAction_0);
						}
					}
					method_7(rootParent8, treeViewAction_0);
					break;
				}
				case TreeViewSelectionMode.MultiSelectSameLevel:
				{
					int nodeLevel = GetNodeLevel(treeNode_5);
					val = treeNode_5;
					while (val != null && val != treeNode_6)
					{
						val = ((treeNode_5.Bounds.Y > treeNode_6.Bounds.Y) ? val.PrevVisibleNode : val.NextVisibleNode);
						if (val != null && GetNodeLevel(val) == nodeLevel)
						{
							method_11(val, bool_4: true, treeViewAction_0);
						}
					}
					method_5(nodeLevel, treeViewAction_0);
					break;
				}
				case TreeViewSelectionMode.MultiSelectSameLevelAndRootBranch:
				{
					TreeNode rootParent6 = GetRootParent(treeNode_5);
					int nodeLevel = GetNodeLevel(treeNode_5);
					val = treeNode_5;
					while (val != null && val != treeNode_6)
					{
						val = ((treeNode_5.Bounds.Y <= treeNode_6.Bounds.Y) ? val.NextVisibleNode : val.PrevVisibleNode);
						if (val != null)
						{
							int nodeLevel3 = GetNodeLevel(val);
							TreeNode rootParent7 = GetRootParent(val);
							if (nodeLevel3 == nodeLevel && rootParent7 == rootParent6)
							{
								method_11(val, bool_4: true, treeViewAction_0);
							}
						}
					}
					method_7(rootParent6, treeViewAction_0);
					method_5(nodeLevel, treeViewAction_0);
					break;
				}
				case TreeViewSelectionMode.MultiSelectSameParent:
				{
					TreeNode parent3 = treeNode_5.Parent;
					val = treeNode_5;
					while (val != null && val != treeNode_6)
					{
						val = ((treeNode_5.Bounds.Y <= treeNode_6.Bounds.Y) ? val.NextVisibleNode : val.PrevVisibleNode);
						if (val != null && val.Parent == parent3)
						{
							method_11(val, bool_4: true, treeViewAction_0);
						}
					}
					method_6(parent3, treeViewAction_0);
					break;
				}
				}
			}
		}
		else if ((int)mouseEventArgs_0.Button == 2097152 && !method_9(treeNode_6))
		{
			method_4(treeViewAction_0);
			method_11(treeNode_6, bool_4: true, treeViewAction_0);
		}
		OnSelectionsChanged();
	}

	protected override void OnBeforeLabelEdit(NodeLabelEditEventArgs e)
	{
		bool_1 = false;
		method_11(e.Node, bool_4: true, (TreeViewAction)2);
		method_8(e.Node, (TreeViewAction)2);
		OnSelectionsChanged();
		((TreeView)this).OnBeforeLabelEdit(e);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected I4, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected I4, but got Unknown
		Keys keys_ = (Keys)0;
		Keys modifiers = e.Modifiers;
		int num;
		int num2;
		if ((int)modifiers != 65536 && (int)modifiers != 131072)
		{
			if ((int)modifiers != 196608)
			{
				treeNode_4 = null;
				num = 0;
				goto IL_0050;
			}
			num2 = 65536;
		}
		else
		{
			num2 = 65536;
		}
		keys_ = (Keys)num2;
		if (treeNode_4 == null)
		{
			treeNode_4 = treeNode_1;
			num = 0;
		}
		else
		{
			num = 0;
		}
		goto IL_0050;
		IL_0050:
		int num3 = num;
		TreeNode val = null;
		modifiers = e.KeyCode;
		switch (modifiers - 33)
		{
		default:
			((TreeView)this).OnKeyDown(e);
			return;
		case 0:
			num3 = method_15();
			val = method_17(treeNode_1, bool_4: false, num3);
			break;
		case 1:
			num3 = method_15();
			val = method_17(treeNode_1, bool_4: true, num3);
			break;
		case 2:
			val = method_16();
			break;
		case 3:
			val = ((TreeView)this).Nodes[0];
			break;
		case 4:
			if (treeNode_1.IsExpanded)
			{
				treeNode_1.Collapse();
			}
			else
			{
				val = treeNode_1.Parent;
			}
			break;
		case 5:
			val = treeNode_1.PrevVisibleNode;
			break;
		case 6:
			if (!treeNode_1.IsExpanded)
			{
				treeNode_1.Expand();
			}
			else if (treeNode_1.Nodes != null)
			{
				val = treeNode_1.Nodes[0];
			}
			break;
		case 7:
			val = treeNode_1.NextVisibleNode;
			break;
		}
		if (val != null)
		{
			method_18(treeNode_1, bool_4: false);
			method_23(treeNode_4, val, new MouseEventArgs((MouseButtons)1048576, 1, Cursor.Position.X, Cursor.Position.Y, 0), keys_, (TreeViewAction)1, bool_4: false);
			treeNode_1 = val;
			method_18(treeNode_1, bool_4: true);
		}
		if (treeNode_1 != null)
		{
			TreeNode val2 = null;
			modifiers = e.KeyCode;
			switch (modifiers - 33)
			{
			case 0:
				val2 = method_17(treeNode_1, bool_4: false, num3 - 2);
				break;
			case 1:
				val2 = method_17(treeNode_1, bool_4: true, num3 - 2);
				break;
			case 2:
			case 3:
				val2 = treeNode_1;
				break;
			case 4:
			case 5:
				val2 = method_17(treeNode_1, bool_4: false, 5);
				break;
			case 6:
			case 7:
				val2 = method_17(treeNode_1, bool_4: true, 5);
				break;
			}
			if (val2 != null)
			{
				val2.EnsureVisible();
			}
		}
		((TreeView)this).OnKeyDown(e);
	}

	protected override void OnAfterCollapse(TreeViewEventArgs e)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		bool_1 = false;
		bool flag = false;
		foreach (TreeNode node in e.Node.Nodes)
		{
			TreeNode treeNode_ = node;
			if (method_9(treeNode_))
			{
				flag = true;
			}
			method_12(treeNode_, (TreeViewAction)3);
		}
		if (flag)
		{
			method_11(e.Node, bool_4: true, (TreeViewAction)3);
		}
		OnSelectionsChanged();
		((TreeView)this).OnAfterCollapse(e);
	}

	protected override void OnItemDrag(ItemDragEventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		e = new ItemDragEventArgs((MouseButtons)1048576, (object)SelectedNodes);
		((TreeView)this).OnItemDrag(e);
	}

	[CompilerGenerated]
	private void method_24()
	{
		method_21();
	}

	static TreeView()
	{
		Class72.smethod_20();
	}
}
