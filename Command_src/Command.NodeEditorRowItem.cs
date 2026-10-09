using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class NodeEditorRowItem : UserControl
{
	private IContainer icontainer_0;

	public HashtableNodeEditor ParentUI;

	[field: AccessedThroughProperty("GB")]
	internal virtual DarkGroupBox GB { get; set; }

	[field: AccessedThroughProperty("ElementList")]
	internal virtual FlowLayoutPanel ElementList { get; set; }

	[field: AccessedThroughProperty("Button18")]
	internal virtual DarkButton Button18 { get; set; }

	public NodeEditorRowItem()
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
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		GB = new DarkGroupBox();
		ElementList = new FlowLayoutPanel();
		Button18 = new DarkButton();
		((Control)GB).SuspendLayout();
		((Control)ElementList).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)GB).Anchor = (AnchorStyles)15;
		((Control)GB).BackColor = Color.FromArgb(60, 63, 65);
		((Control)GB).Controls.Add((Control)(object)ElementList);
		((Control)GB).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GB).Location = new Point(3, 3);
		((Control)GB).Name = "GB";
		((Control)GB).Size = new Size(236, 156);
		((Control)GB).TabIndex = 6;
		((GroupBox)GB).TabStop = false;
		((GroupBox)GB).Text = "GroupBox4";
		((Control)ElementList).Anchor = (AnchorStyles)15;
		((ScrollableControl)ElementList).AutoScroll = true;
		((Control)ElementList).BackColor = Color.FromArgb(60, 63, 65);
		((Control)ElementList).Controls.Add((Control)(object)Button18);
		((Control)ElementList).Location = new Point(6, 19);
		((Control)ElementList).Name = "ElementList";
		((Control)ElementList).Size = new Size(224, 131);
		((Control)ElementList).TabIndex = 2;
		((Control)Button18).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button18).Location = new Point(3, 3);
		((Control)Button18).Name = "Button18";
		((Control)Button18).Padding = new Padding(5);
		((Control)Button18).Size = new Size(194, 27);
		((Control)Button18).TabIndex = 5;
		Button18.Text = "Target";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).Controls.Add((Control)(object)GB);
		((Control)this).Name = "NodeEditorRowItem";
		((Control)this).Size = new Size(242, 161);
		((Control)GB).ResumeLayout(false);
		((Control)ElementList).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	public void RefreshRow(Hashtable DataHashtable, string ID, HashtableNodeEditor _ParentUI)
	{
		((Control)ElementList).Controls.Clear();
		ParentUI = _ParentUI;
		((GroupBox)GB).Text = DataHashtable.Name;
		List<HashTable_Row> rowsByID = DataHashtable.GetRowsByID(ID);
		if (rowsByID == null)
		{
			return;
		}
		foreach (HashTable_Row item in rowsByID)
		{
			HashTable_Row componentData = DataHashtable.GetComponentData(item.GetComponentOrCodeID());
			NodeItem nodeItem = new NodeItem();
			nodeItem.ParentUI = ParentUI;
			nodeItem.AssociatedRow = componentData;
			((Control)ElementList).Controls.Add((Control)(object)nodeItem);
		}
	}

	static NodeEditorRowItem()
	{
		Class72.smethod_20();
	}
}
