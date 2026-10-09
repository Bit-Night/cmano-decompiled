using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class NodeItem : UserControl
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("Button")]
	[CompilerGenerated]
	private DarkButton _Button;

	private Hashtable hashtable_0;

	private HashtableNode hashtableNode_0;

	private HashTable_Row hashTable_Row_0;

	public HashtableNodeEditor ParentUI;

	internal virtual DarkButton Button
	{
		[CompilerGenerated]
		get
		{
			return _Button;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_0;
			DarkButton darkButton = _Button;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button = value;
			darkButton = _Button;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	public Hashtable AssociatedTable
	{
		get
		{
			return hashtable_0;
		}
		set
		{
			hashtable_0 = value;
			if (hashtable_0 != null)
			{
				Button.Text = hashtable_0.Name;
			}
		}
	}

	public HashtableNode AssociatedNode
	{
		get
		{
			return hashtableNode_0;
		}
		set
		{
			hashtableNode_0 = value;
			if (hashtableNode_0 != null)
			{
				Button.Text = hashtableNode_0.DisplayName;
			}
		}
	}

	public HashTable_Row AssociatedRow
	{
		get
		{
			return hashTable_Row_0;
		}
		set
		{
			hashTable_Row_0 = value;
			if (hashTable_Row_0 != null)
			{
				Button.Text = hashTable_Row_0.Name;
			}
		}
	}

	public NodeItem()
	{
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
		}
		finally
		{
			((ContainerControl)this).Dispose(disposing);
		}
	}

	private void InitializeComponent()
	{
		Button = new DarkButton();
		((Control)this).SuspendLayout();
		((Control)Button).Location = new Point(0, 0);
		((Control)Button).Name = "Button";
		((Control)Button).Size = new Size(195, 27);
		((Control)Button).TabIndex = 6;
		Button.Text = "Target";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).Controls.Add((Control)(object)Button);
		((Control)this).Name = "NodeItem";
		((Control)this).Size = new Size(195, 27);
		((Control)this).ResumeLayout(false);
	}

	private void method_0(object sender, EventArgs e)
	{
		if (AssociatedNode == null)
		{
			if (AssociatedTable == null)
			{
				if (AssociatedRow != null)
				{
					ParentUI.SelectedRow = AssociatedRow;
					HashtableNodeEditor.NavigationHistoryItem.Add(AssociatedRow, ParentUI);
				}
			}
			else
			{
				ParentUI.SelectedTable = AssociatedTable;
				HashtableNodeEditor.NavigationHistoryItem.Add(AssociatedTable, ParentUI);
			}
		}
		else
		{
			ParentUI.SelectedNode = AssociatedNode;
			HashtableNodeEditor.NavigationHistoryItem.Add(AssociatedNode, ParentUI);
		}
	}

	static NodeItem()
	{
		Class72.smethod_20();
	}
}
