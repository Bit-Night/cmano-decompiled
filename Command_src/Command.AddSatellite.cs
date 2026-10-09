using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.DAL;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AddSatellite : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	private string string_0;

	private string SelectedType;

	[field: AccessedThroughProperty("TreeView1")]
	internal virtual DarkTreeView TreeView1 { get; set; }

	internal virtual DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _Button1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button1 = value;
			darkUIButton = _Button1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	public AddSatellite()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += AddSatellite_Load;
		((Control)this).KeyDown += new KeyEventHandler(AddSatellite_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(AddSatellite_FormClosing);
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
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		TreeView1 = new DarkTreeView();
		Button1 = new DarkUIButton();
		Label1 = new DarkLabel();
		((Control)this).SuspendLayout();
		((Control)TreeView1).Anchor = (AnchorStyles)15;
		((Control)TreeView1).Location = new Point(3, 3);
		TreeView1.MaxDragChange = 20;
		TreeView1.MultiSelect = true;
		((Control)TreeView1).Name = "TreeView1";
		((Control)TreeView1).Size = new Size(361, 458);
		((Control)TreeView1).TabIndex = 0;
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		((Control)Button1).Location = new Point(3, 467);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(114, 23);
		((Control)Button1).TabIndex = 1;
		Button1.Text = "Add Selected";
		((Control)Label1).Anchor = (AnchorStyles)6;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(124, 472);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(39, 13);
		((Control)Label1).TabIndex = 2;
		((Label)Label1).Text = "Label1";
		((Control)Label1).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(367, 496);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)TreeView1);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "AddSatellite";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Add Satellite";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void AddSatellite_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		TreeView1.Nodes.Clear();
		List<string> list = (from object theRow in Client.CurrentScenario.Cache_Satellites_DT.Rows
			select Conversions.ToString(NewLateBinding.LateIndexGet(theRow, new object[1] { "CountryString" }, (string[])null))).Distinct().ToList();
		list.Sort();
		foreach (string item in list)
		{
			DarkTreeNode darkTreeNode = new DarkTreeNode(item);
			darkTreeNode.Tag = "Country_" + item;
			TreeView1.Nodes.Add(darkTreeNode);
			PopulateNodesChildren(darkTreeNode);
		}
	}

	public void PopulateNodesChildren(DarkTreeNode ParentNode)
	{
		string text = Conversions.ToString(ParentNode.Tag);
		string text2 = text.Split(new char[1] { '_' })[0];
		if (Operators.CompareString(text2, "Country", true) != 0)
		{
			if (Operators.CompareString(text2, "Type", true) == 0)
			{
				SelectedType = text.Split(new char[1] { '_' })[1];
				List<VB$AnonymousType_7<string, int>> list = (from object theRow in Client.CurrentScenario.Cache_Satellites_DT.Rows
					where (Operators.CompareString(Conversions.ToString(((DataRow)theRow)["TypeString"]), SelectedType, true) == 0) & (Operators.CompareString(Conversions.ToString(((DataRow)theRow)["CountryString"]), string_0, true) == 0)
					select new VB$AnonymousType_7<string, int>(Conversions.ToString(((DataRow)theRow)["Name"]), Conversions.ToInteger(((DataRow)theRow)["ID"])) into $VB$It
					orderby $VB$It.theName
					select $VB$It).ToList();
				{
					foreach (VB$AnonymousType_7<string, int> item in list)
					{
						DarkTreeNode darkTreeNode = new DarkTreeNode(item.theName);
						darkTreeNode.Tag = "SatClass_" + Conversions.ToString(item.theID);
						ParentNode.Nodes.Add(darkTreeNode);
						PopulateNodesChildren(darkTreeNode);
					}
					return;
				}
			}
			if (Operators.CompareString(text2, "SatClass", true) != 0)
			{
				return;
			}
			DataTable orbitsForThisSatellite = DBFunctions.GetOrbitsForThisSatellite(Conversions.ToInteger(text.Split(Conversions.ToCharArrayRankOne("_"))[1]), Client.CurrentScenario.DBConnection);
			{
				foreach (DataRow row in orbitsForThisSatellite.Rows)
				{
					DarkTreeNode darkTreeNode2 = new DarkTreeNode(row["MissonName"].ToString());
					DateTime dateTime = Conversions.ToDate(row["LaunchDate"]);
					DateTime t = Conversions.ToDate(row["DeOrbitingDate"]);
					if (DateTime.Compare(t, Client.CurrentScenario.Time) < 0 && DateTime.Compare(t, new DateTime(1900, 1, 1)) > 0)
					{
						darkTreeNode2.ForeColor = Color.Gray;
						darkTreeNode2.Text = Conversions.ToString(row["MissonName"]) + " (unavailable - already de-orbited)";
					}
					else if (DateTime.Compare(dateTime, Client.CurrentScenario.Time) < 0)
					{
						darkTreeNode2.Text = Conversions.ToString(row["MissonName"]) + " (in orbit)";
					}
					else
					{
						TimeSpan timeSpan = dateTime - Client.CurrentScenario.Time;
						darkTreeNode2.Text = Conversions.ToString(row["MissonName"]) + " (will launch in " + Misc.TimeString((long)Math.Round(timeSpan.TotalSeconds)) + ")";
					}
					darkTreeNode2.Tag = "Spacecraft_" + row["ID"].ToString() + "_" + row["ComponentNumber"].ToString();
					ParentNode.Nodes.Add(darkTreeNode2);
					PopulateNodesChildren(darkTreeNode2);
				}
				return;
			}
		}
		string_0 = text.Split(new char[1] { '_' })[1];
		List<string> list2 = (from object theRow in Client.CurrentScenario.Cache_Satellites_DT.Rows
			where Operators.CompareString(Conversions.ToString(((DataRow)theRow)["CountryString"]), string_0, true) == 0
			select Conversions.ToString(((DataRow)theRow)["TypeString"]) into theType
			orderby theType
			select theType).Distinct().ToList();
		foreach (string item2 in list2)
		{
			DarkTreeNode darkTreeNode3 = new DarkTreeNode(item2);
			darkTreeNode3.Tag = "Type_" + item2;
			ParentNode.Nodes.Add(darkTreeNode3);
			PopulateNodesChildren(darkTreeNode3);
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		int num = 0;
		bool flag = default(bool);
		foreach (DarkTreeNode selectedNode in TreeView1.SelectedNodes)
		{
			string text = Conversions.ToString(selectedNode.Tag);
			if (Information.IsNothing((object)text) || Operators.CompareString(text.Split(new char[1] { '_' })[0], "Spacecraft", true) != 0 || selectedNode.ForeColor == Color.Gray)
			{
				continue;
			}
			string strB = text.Split(new char[1] { '_' })[1] + "_" + text.Split(new char[1] { '_' })[2];
			foreach (ActiveUnit activeUnits_ in Client.CurrentScenario.ActiveUnits_List)
			{
				if (!Information.IsNothing((object)activeUnits_) && activeUnits_.IsSatellite && string.CompareOrdinal(((Satellite)activeUnits_).SpacecraftID, strB) == 0)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Client.CurrentScenario.AddNewSatellite(Client.CurrentSide, "", Conversions.ToInteger(text.Split(new char[1] { '_' })[1]), Conversions.ToInteger(text.Split(new char[1] { '_' })[2]));
				num++;
			}
		}
		if (num > 0)
		{
			((Control)Label1).Visible = true;
			((Label)Label1).Text = Conversions.ToString(num) + " satellites were added to the scenario.";
			Client.MustRefreshMainForm = true;
		}
	}

	private void AddSatellite_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Invalid comparison between Unknown and I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Invalid comparison between Unknown and I4
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if (!((Control)this).Visible || ((int)e.KeyCode != 32 && (int)e.KeyCode != 107 && (int)e.KeyCode != 109))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void AddSatellite_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	static AddSatellite()
	{
		Class72.smethod_20();
	}
}
