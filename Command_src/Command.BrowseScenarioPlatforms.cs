using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class BrowseScenarioPlatforms : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TreeView1")]
	private DarkTreeView _TreeView1;

	private Side side_0;

	[CompilerGenerated]
	[AccessedThroughProperty("TSCB_Side_Combobox")]
	private ComboBox comboBox_0;

	[CompilerGenerated]
	private bool bool_2;

	[field: AccessedThroughProperty("ToolStripContainer1")]
	internal virtual ToolStripContainer ToolStripContainer1 { get; set; }

	[field: AccessedThroughProperty("ToolStrip1")]
	internal virtual DarkToolStrip ToolStrip1 { get; set; }

	[field: AccessedThroughProperty("ToolStripLabel1")]
	internal virtual ToolStripLabel ToolStripLabel1 { get; set; }

	[field: AccessedThroughProperty("TSCB_Side")]
	internal virtual ToolStripComboBox TSCB_Side { get; set; }

	[field: AccessedThroughProperty("ToolStripLabel2")]
	internal virtual ToolStripLabel ToolStripLabel2 { get; set; }

	internal virtual DarkTreeView TreeView1
	{
		[CompilerGenerated]
		get
		{
			return _TreeView1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(method_4);
			DarkTreeView darkTreeView = _TreeView1;
			if (darkTreeView != null)
			{
				((Control)darkTreeView).MouseDoubleClick -= val;
			}
			_TreeView1 = value;
			darkTreeView = _TreeView1;
			if (darkTreeView != null)
			{
				((Control)darkTreeView).MouseDoubleClick += val;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripContainer2")]
	internal virtual ToolStripContainer ToolStripContainer2 { get; set; }

	protected override bool RTMPEnabled
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

	public BrowseScenarioPlatforms()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += BrowseScenarioPlatforms_Load;
		((Control)this).KeyDown += new KeyEventHandler(BrowseScenarioPlatforms_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(BrowseScenarioPlatforms_FormClosing);
		RTMPEnabled = true;
		InitializeComponent_1();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_1 != null)
			{
				icontainer_1.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	private void InitializeComponent_1()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Expected O, but got Unknown
		ToolStripContainer1 = new ToolStripContainer();
		TreeView1 = new DarkTreeView();
		ToolStrip1 = new DarkToolStrip();
		ToolStripLabel1 = new ToolStripLabel();
		TSCB_Side = new ToolStripComboBox();
		ToolStripLabel2 = new ToolStripLabel();
		ToolStripContainer2 = new ToolStripContainer();
		((Control)ToolStripContainer1.ContentPanel).SuspendLayout();
		((Control)ToolStripContainer1).SuspendLayout();
		((Control)ToolStrip1).SuspendLayout();
		((Control)ToolStripContainer2.ContentPanel).SuspendLayout();
		((Control)ToolStripContainer2.TopToolStripPanel).SuspendLayout();
		((Control)ToolStripContainer2).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)ToolStripContainer1.ContentPanel).Controls.Add((Control)(object)TreeView1);
		((Control)ToolStripContainer1.ContentPanel).Size = new Size(604, 289);
		((Control)ToolStripContainer1).Dock = (DockStyle)5;
		((Control)ToolStripContainer1).Location = new Point(0, 0);
		((Control)ToolStripContainer1).Name = "ToolStripContainer1";
		((Control)ToolStripContainer1).Size = new Size(604, 289);
		((Control)ToolStripContainer1).TabIndex = 0;
		((Control)ToolStripContainer1).Text = "ToolStripContainer1";
		((Control)ToolStripContainer1.TopToolStripPanel).BackColor = Color.FromArgb(64, 64, 64);
		((Control)TreeView1).Dock = (DockStyle)5;
		((Control)TreeView1).Location = new Point(0, 0);
		TreeView1.MaxDragChange = 20;
		((Control)TreeView1).Name = "TreeView1";
		((Control)TreeView1).Size = new Size(604, 289);
		((Control)TreeView1).TabIndex = 0;
		((ToolStrip)ToolStrip1).AutoSize = false;
		((ToolStrip)ToolStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)ToolStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)ToolStrip1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)ToolStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[3]
		{
			(ToolStripItem)ToolStripLabel1,
			(ToolStripItem)TSCB_Side,
			(ToolStripItem)ToolStripLabel2
		});
		((Control)ToolStrip1).Location = new Point(0, 0);
		((Control)ToolStrip1).Name = "ToolStrip1";
		((Control)ToolStrip1).Padding = new Padding(5, 0, 1, 0);
		((Control)ToolStrip1).Size = new Size(604, 27);
		((ToolStrip)ToolStrip1).Stretch = true;
		((Control)ToolStrip1).TabIndex = 0;
		((ToolStripItem)ToolStripLabel1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripLabel1).Name = "ToolStripLabel1";
		((ToolStripItem)ToolStripLabel1).Size = new Size(32, 24);
		((ToolStripItem)ToolStripLabel1).Text = "Side:";
		((ToolStripControlHost)TSCB_Side).BackColor = Color.FromArgb(60, 63, 65);
		TSCB_Side.DropDownStyle = (ComboBoxStyle)2;
		((ToolStripControlHost)TSCB_Side).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSCB_Side).Name = "TSCB_Side";
		((ToolStripControlHost)TSCB_Side).Size = new Size(200, 27);
		((ToolStripItem)ToolStripLabel2).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripLabel2).Font = new Font("Segoe UI", 9f, (FontStyle)2);
		((ToolStripItem)ToolStripLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripLabel2).Name = "ToolStripLabel2";
		((ToolStripItem)ToolStripLabel2).Size = new Size(206, 24);
		((ToolStripItem)ToolStripLabel2).Text = "(double click platform to view DB info)";
		ToolStripContainer2.ContentPanel.AutoScroll = true;
		((Control)ToolStripContainer2.ContentPanel).Controls.Add((Control)(object)ToolStripContainer1);
		((Control)ToolStripContainer2.ContentPanel).Size = new Size(604, 289);
		((Control)ToolStripContainer2).Dock = (DockStyle)5;
		((Control)ToolStripContainer2).Location = new Point(0, 0);
		((Control)ToolStripContainer2).Name = "ToolStripContainer2";
		((Control)ToolStripContainer2).Size = new Size(604, 316);
		((Control)ToolStripContainer2).TabIndex = 1;
		((Control)ToolStripContainer2).Text = "ToolStripContainer2";
		((Control)ToolStripContainer2.TopToolStripPanel).Controls.Add((Control)(object)ToolStrip1);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(604, 316);
		((Control)this).Controls.Add((Control)(object)ToolStripContainer2);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "BrowseScenarioPlatforms";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Browse Scenario Platforms";
		((Control)ToolStripContainer1.ContentPanel).ResumeLayout(false);
		((Control)ToolStripContainer1).ResumeLayout(false);
		((Control)ToolStripContainer1).PerformLayout();
		((Control)ToolStrip1).ResumeLayout(false);
		((Control)ToolStrip1).PerformLayout();
		((Control)ToolStripContainer2.ContentPanel).ResumeLayout(false);
		((Control)ToolStripContainer2.TopToolStripPanel).ResumeLayout(false);
		((Control)ToolStripContainer2).ResumeLayout(false);
		((Control)ToolStripContainer2).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual ComboBox vmethod_0()
	{
		return comboBox_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_1(ComboBox WithEventsValue)
	{
		EventHandler eventHandler = method_3;
		ComboBox val = comboBox_0;
		if (val != null)
		{
			val.SelectionChangeCommitted -= eventHandler;
		}
		comboBox_0 = WithEventsValue;
		val = comboBox_0;
		if (val != null)
		{
			val.SelectionChangeCommitted += eventHandler;
		}
	}

	private void BrowseScenarioPlatforms_Load(object sender, EventArgs e)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		if (!Information.IsNothing((object)Client.CurrentSide))
		{
			if (Client.DPI_scale == 1f)
			{
				((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
			}
			side_0 = Client.CurrentSide;
			vmethod_1(TSCB_Side.ComboBox);
			int num = 0;
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				ComboBoxItem val = new ComboBoxItem();
				((ContentControl)val).Content = side.Name;
				((FrameworkElement)val).Tag = side.ObjectID;
				vmethod_0().Items.Add((object)val);
				if (Operators.CompareString(side_0.ObjectID, side.ObjectID, true) == 0)
				{
					vmethod_0().SelectedIndex = num;
				}
				num++;
			}
			((ListControl)vmethod_0()).DisplayMember = "Content";
			((ListControl)vmethod_0()).ValueMember = "Tag";
			method_2();
			((Control)this).Refresh();
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void method_2()
	{
		TreeView1.Nodes.Clear();
		IEnumerable<IGrouping<string, ActiveUnit>> enumerable = from AU in Client.CurrentScenario.ActiveUnits_List.Where([SpecialName] (ActiveUnit AU) =>
			{
				int result;
				if (!Information.IsNothing((object)AU))
				{
					if (AU.IsPlatform)
					{
						return AU.get_UnitSide(SetSideOnly: false) == side_0;
					}
					result = 0;
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			})
			group AU by AU.GetType().ToString() into theAU
			select (theAU);
		if (enumerable.Count() == 0)
		{
			((Control)TreeView1).Refresh();
		}
		foreach (IGrouping<string, ActiveUnit> item in enumerable)
		{
			string unitType_String = item.ElementAtOrDefault(0).UnitType_String;
			DarkTreeNode darkTreeNode = new DarkTreeNode(unitType_String);
			TreeView1.Nodes.Add(darkTreeNode);
			foreach (IGrouping<int, ActiveUnit> item2 in from AU in item
				group AU by AU.DBID)
			{
				DarkTreeNode darkTreeNode2 = new DarkTreeNode(item2.ElementAtOrDefault(0).UnitClass);
				darkTreeNode2.Tag = unitType_String + "_" + Conversions.ToString(item2.ElementAtOrDefault(0).DBID);
				darkTreeNode.Nodes.Add(darkTreeNode2);
			}
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		side_0 = Client.CurrentScenario.Sides_ReadOnly.Where([SpecialName] (Side theSide) => Operators.CompareString(theSide.ObjectID, Conversions.ToString(((FrameworkElement)(ComboBoxItem)vmethod_0().SelectedItem).Tag), true) == 0).ElementAtOrDefault(0);
		method_2();
	}

	private void method_4(object sender, EventArgs e)
	{
		if (TreeView1.SelectedNodes.Count != 0)
		{
			DarkTreeNode darkTreeNode = TreeView1.SelectedNodes[0];
			if (!string.IsNullOrEmpty(Conversions.ToString(darkTreeNode.Tag)))
			{
				string selectedObjectType = darkTreeNode.Tag.ToString().Split(Conversions.ToCharArrayRankOne("_"))[0];
				int selectedObjectID = Conversions.ToInteger(darkTreeNode.Tag.ToString().Split(Conversions.ToCharArrayRankOne("_"))[1]);
				Client.smethod_17(selectedObjectType, selectedObjectID);
			}
		}
	}

	private void BrowseScenarioPlatforms_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Invalid comparison between Unknown and I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Invalid comparison between Unknown and I4
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Invalid comparison between Unknown and I4
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Invalid comparison between Unknown and I4
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Invalid comparison between Unknown and I4
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Invalid comparison between Unknown and I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Invalid comparison between Unknown and I4
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if (!((Control)this).Visible || ((int)e.KeyCode != 33 && (int)e.KeyCode != 34 && (int)e.KeyCode != 35 && (int)e.KeyCode != 36 && (int)e.KeyCode != 38 && (int)e.KeyCode != 40 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39 && (int)e.KeyCode != 107 && (int)e.KeyCode != 109))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void BrowseScenarioPlatforms_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	static BrowseScenarioPlatforms()
	{
		Class72.smethod_20();
	}
}
