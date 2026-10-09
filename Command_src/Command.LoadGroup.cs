using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace Command;

[DesignerGenerated]
public sealed class LoadGroup : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TV1")]
	private TreeView _TV1;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _Button2;

	private ImportExportRecord importExportRecord_0;

	internal virtual TreeView TV1
	{
		[CompilerGenerated]
		get
		{
			return _TV1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			TreeNodeMouseClickEventHandler val = new TreeNodeMouseClickEventHandler(method_4);
			TreeView val2 = _TV1;
			if (val2 != null)
			{
				val2.NodeMouseClick -= val;
			}
			_TV1 = value;
			val2 = _TV1;
			if (val2 != null)
			{
				val2.NodeMouseClick += val;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label_Name")]
	internal virtual DarkLabel Label_Name { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("Label_ValidFrom")]
	internal virtual DarkLabel Label_ValidFrom { get; set; }

	[field: AccessedThroughProperty("label_ValidUntil")]
	internal virtual DarkLabel label_ValidUntil { get; set; }

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1 { get; set; }

	[field: AccessedThroughProperty("Label_Notes")]
	internal virtual DarkLabel Label_Notes { get; set; }

	[field: AccessedThroughProperty("Label9")]
	internal virtual DarkLabel Label9 { get; set; }

	[field: AccessedThroughProperty("ListView1")]
	internal virtual DarkListView ListView1 { get; set; }

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
			EventHandler eventHandler = method_7;
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

	internal virtual DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _Button2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIButton darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button2 = value;
			darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStrip1")]
	internal virtual DarkToolStrip ToolStrip1 { get; set; }

	[field: AccessedThroughProperty("TSL_Loadingtext")]
	internal virtual ToolStripLabel TSL_Loadingtext { get; set; }

	[field: AccessedThroughProperty("CheckBox_DoNotCheckDBCompatibility")]
	internal virtual DarkCheckBox CheckBox_DoNotCheckDBCompatibility { get; set; }

	[field: AccessedThroughProperty("CheckBox_No_Delta_Load")]
	internal virtual DarkCheckBox CheckBox_No_Delta_Load { get; set; }

	[field: AccessedThroughProperty("Label_Template")]
	internal virtual DarkLabel Label_Template { get; set; }

	public LoadGroup()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(LoadGroup_FormClosing);
		((Form)this).Load += LoadGroup_Load;
		((Control)this).VisibleChanged += LoadGroup_VisibleChanged;
		((Control)this).KeyDown += new KeyEventHandler(LoadGroup_KeyDown);
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
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Expected O, but got Unknown
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Expected O, but got Unknown
		//IL_074b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0755: Expected O, but got Unknown
		//IL_0802: Unknown result type (might be due to invalid IL or missing references)
		//IL_080c: Expected O, but got Unknown
		//IL_093f: Unknown result type (might be due to invalid IL or missing references)
		TV1 = new TreeView();
		Label1 = new DarkLabel();
		Label_Name = new DarkLabel();
		Label3 = new DarkLabel();
		Label4 = new DarkLabel();
		Label_ValidFrom = new DarkLabel();
		label_ValidUntil = new DarkLabel();
		Label7 = new DarkLabel();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		Label_Notes = new DarkLabel();
		Label9 = new DarkLabel();
		ListView1 = new DarkListView();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		ToolStrip1 = new DarkToolStrip();
		TSL_Loadingtext = new ToolStripLabel();
		CheckBox_DoNotCheckDBCompatibility = new DarkCheckBox();
		CheckBox_No_Delta_Load = new DarkCheckBox();
		Label_Template = new DarkLabel();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((Control)ToolStrip1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)TV1).Anchor = (AnchorStyles)7;
		TV1.BackColor = Color.FromArgb(43, 43, 43);
		TV1.CheckBoxes = true;
		TV1.ForeColor = Color.LightGray;
		((Control)TV1).Location = new Point(12, 61);
		((Control)TV1).Name = "TV1";
		((Control)TV1).Size = new Size(457, 498);
		((Control)TV1).TabIndex = 0;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(476, 13);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(70, 13);
		((Control)Label1).TabIndex = 1;
		((Label)Label1).Text = "Group Name:";
		Label_Name.AutoSize = true;
		((Control)Label_Name).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label_Name).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Name).Location = new Point(598, 13);
		((Control)Label_Name).Name = "Label_Name";
		((Control)Label_Name).Size = new Size(15, 19);
		((Control)Label_Name).TabIndex = 2;
		((Label)Label_Name).Text = "?";
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(476, 38);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(70, 13);
		((Control)Label3).TabIndex = 3;
		((Label)Label3).Text = "Valid From:";
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(475, 61);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(89, 13);
		((Control)Label4).TabIndex = 4;
		((Label)Label4).Text = "Valid Until:";
		Label_ValidFrom.AutoSize = true;
		((Control)Label_ValidFrom).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label_ValidFrom).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_ValidFrom).Location = new Point(598, 38);
		((Control)Label_ValidFrom).Name = "Label_ValidFrom";
		((Control)Label_ValidFrom).Size = new Size(15, 19);
		((Control)Label_ValidFrom).TabIndex = 5;
		((Label)Label_ValidFrom).Text = "?";
		label_ValidUntil.AutoSize = true;
		((Control)label_ValidUntil).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)label_ValidUntil).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)label_ValidUntil).Location = new Point(598, 61);
		((Control)label_ValidUntil).Name = "label_ValidUntil";
		((Control)label_ValidUntil).Size = new Size(15, 19);
		((Control)label_ValidUntil).TabIndex = 6;
		((Label)label_ValidUntil).Text = "?";
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(3, 0);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(38, 13);
		((Control)Label7).TabIndex = 7;
		((Label)Label7).Text = "Notes:";
		((Control)FlowLayoutPanel1).Anchor = (AnchorStyles)12;
		((Panel)FlowLayoutPanel1).BorderStyle = (BorderStyle)1;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Label7);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Label_Notes);
		((Control)FlowLayoutPanel1).Location = new Point(479, 95);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(764, 165);
		((Control)FlowLayoutPanel1).TabIndex = 8;
		Label_Notes.AutoSize = true;
		((Control)Label_Notes).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Notes).Location = new Point(47, 0);
		((Control)Label_Notes).Name = "Label_Notes";
		((Control)Label_Notes).Size = new Size(16, 20);
		((Control)Label_Notes).TabIndex = 0;
		((Label)Label_Notes).Text = "?";
		((Control)Label9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label9).Location = new Point(479, 263);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(85, 13);
		((Control)Label9).TabIndex = 9;
		((Label)Label9).Text = "Group Members:";
		((Control)ListView1).Location = new Point(482, 280);
		((Control)ListView1).Name = "ListView1";
		ListView1.RelatedInfos = null;
		((Control)ListView1).Size = new Size(335, 238);
		((Control)ListView1).TabIndex = 10;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(482, 534);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(146, 25);
		((Control)Button1).TabIndex = 11;
		Button1.Text = "Load selected installation(s)";
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Button)Button2).DialogResult = (DialogResult)0;
		((Control)Button2).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(742, 534);
		((Control)Button2).Name = "Button2";
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(75, 25);
		((Control)Button2).TabIndex = 12;
		Button2.Text = "Close";
		((ToolStrip)ToolStrip1).AutoSize = false;
		((ToolStrip)ToolStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)ToolStrip1).Dock = (DockStyle)2;
		((ToolStrip)ToolStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)ToolStrip1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)ToolStrip1).ImageScalingSize = new Size(20, 20);
		((ToolStrip)ToolStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[1] { (ToolStripItem)TSL_Loadingtext });
		((Control)ToolStrip1).Location = new Point(0, 562);
		((Control)ToolStrip1).Name = "ToolStrip1";
		((Control)ToolStrip1).Padding = new Padding(5, 0, 1, 0);
		((Control)ToolStrip1).Size = new Size(1255, 25);
		((Control)ToolStrip1).TabIndex = 13;
		((Control)ToolStrip1).Text = "ToolStrip1";
		((ToolStripItem)TSL_Loadingtext).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSL_Loadingtext).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSL_Loadingtext).Name = "TSL_Loadingtext";
		((ToolStripItem)TSL_Loadingtext).Size = new Size(119, 22);
		((ToolStripItem)TSL_Loadingtext).Text = "TSL_LoadingText";
		((ButtonBase)CheckBox_DoNotCheckDBCompatibility).AutoSize = true;
		((Control)CheckBox_DoNotCheckDBCompatibility).Location = new Point(12, 13);
		((Control)CheckBox_DoNotCheckDBCompatibility).Name = "CheckBox_DoNotCheckDBCompatibility";
		((Control)CheckBox_DoNotCheckDBCompatibility).Size = new Size(257, 24);
		((Control)CheckBox_DoNotCheckDBCompatibility).TabIndex = 14;
		((ButtonBase)CheckBox_DoNotCheckDBCompatibility).Text = "Do not check for DB compatibility";
		((ButtonBase)CheckBox_No_Delta_Load).AutoSize = true;
		((Control)CheckBox_No_Delta_Load).Location = new Point(12, 36);
		((Control)CheckBox_No_Delta_Load).Name = "CheckBox_No_Delta_Load";
		((Control)CheckBox_No_Delta_Load).Size = new Size(176, 24);
		((Control)CheckBox_No_Delta_Load).TabIndex = 15;
		((ButtonBase)CheckBox_No_Delta_Load).Text = "Do not load any delta";
		((Control)Label_Template).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Template).Location = new Point(713, 60);
		((Control)Label_Template).Name = "Label_Template";
		((Control)Label_Template).Size = new Size(70, 13);
		((Control)Label_Template).TabIndex = 16;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1255, 587);
		((Control)this).Controls.Add((Control)(object)Label_Template);
		((Control)this).Controls.Add((Control)(object)CheckBox_No_Delta_Load);
		((Control)this).Controls.Add((Control)(object)CheckBox_DoNotCheckDBCompatibility);
		((Control)this).Controls.Add((Control)(object)ToolStrip1);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)ListView1);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)this).Controls.Add((Control)(object)label_ValidUntil);
		((Control)this).Controls.Add((Control)(object)Label_ValidFrom);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label_Name);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)TV1);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "LoadGroup";
		((Form)this).ShowIcon = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Load Group(s) from File";
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((Control)FlowLayoutPanel1).PerformLayout();
		((Control)ToolStrip1).ResumeLayout(false);
		((Control)ToolStrip1).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void LoadGroup_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).Enabled = true;
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void LoadGroup_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		method_2();
	}

	private void method_2()
	{
		TreeNode treeNode_ = TV1.Nodes.Add("Main");
		treeNode_.Tag = "";
		method_3(ref treeNode_, GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "ImportExport");
		((ToolStripItem)TSL_Loadingtext).Visible = false;
	}

	private void method_3(ref TreeNode treeNode_0, string string_0)
	{
		TreeNode treeNode_1 = treeNode_0.Nodes.Add(Path.GetFullPath(string_0), Path.GetFileName(string_0));
		treeNode_1.Tag = string_0;
		if (!Directory.Exists(string_0))
		{
			Directory.CreateDirectory(string_0);
		}
		string[] directories = Directory.GetDirectories(string_0);
		foreach (string string_1 in directories)
		{
			method_3(ref treeNode_1, string_1);
		}
		string[] files = Directory.GetFiles(string_0);
		foreach (string text in files)
		{
			treeNode_1.Nodes.Add(Path.GetFullPath(text), Path.GetFileName(text)).Tag = text;
		}
	}

	private void method_4(object sender, TreeNodeMouseClickEventArgs e)
	{
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		try
		{
			if (!Conversions.ToString(e.Node.Tag).Contains(".inst"))
			{
				if (!e.Node.Checked)
				{
					{
						foreach (TreeNode node in e.Node.Nodes)
						{
							node.Checked = false;
						}
						return;
					}
				}
				{
					foreach (TreeNode node2 in e.Node.Nodes)
					{
						TreeNode val = node2;
						StreamReader streamReader = new StreamReader(Conversions.ToString(val.Tag));
						using (streamReader)
						{
							string text = streamReader.ReadToEnd().Replace("\\\"", "");
							text = text.Replace("\\", "/");
							importExportRecord_0 = (ImportExportRecord)JsonConvert.DeserializeObject(text, typeof(ImportExportRecord));
						}
						if (importExportRecord_0.DB_ID != Client.CurrentDB.DBID && !((CheckBox)CheckBox_DoNotCheckDBCompatibility).Checked)
						{
							val.Checked = false;
						}
						else
						{
							val.Checked = true;
						}
					}
					return;
				}
			}
			ListView1.Items.Clear();
			StreamReader streamReader2 = new StreamReader(Conversions.ToString(e.Node.Tag));
			using (streamReader2)
			{
				string text2 = streamReader2.ReadToEnd().Replace("\\\"", "");
				text2 = text2.Replace("\\", "/");
				importExportRecord_0 = (ImportExportRecord)JsonConvert.DeserializeObject(text2, typeof(ImportExportRecord));
			}
			if (importExportRecord_0.DB_ID != Client.CurrentDB.DBID && !((CheckBox)CheckBox_DoNotCheckDBCompatibility).Checked)
			{
				((Label)Label_Name).Text = "CANNOT USE - INCOMPATIBLE DB";
				e.Node.Checked = false;
				return;
			}
			((Label)Label_Name).Text = importExportRecord_0.Name;
			((Label)Label_ValidFrom).Text = importExportRecord_0.ValidFrom;
			((Label)label_ValidUntil).Text = importExportRecord_0.ValidUntil;
			((Label)Label_Notes).Text = importExportRecord_0.Comments;
			((Label)Label_Template).Text = "";
			if (importExportRecord_0.Template)
			{
				((Label)Label_Template).Text = "Template";
				((Label)Label_Notes).Text = ((Label)Label_Notes).Text + "\r\nIf the template contains a 'Group', the Group will need to be renamed before the template is imported again, else the imported units will be appended to the existing Group.";
			}
			foreach (ImportExportRecord.MemberRecord memberRecord in importExportRecord_0.MemberRecords)
			{
				if (memberRecord.Member_SBR != null && memberRecord.Member_SBR.Length > 0)
				{
					DarkListItem item = new DarkListItem(memberRecord.MemberName + " [w/delta]");
					ListView1.Items.Add(item);
				}
				else
				{
					DarkListItem item = new DarkListItem(memberRecord.MemberName);
					ListView1.Items.Add(item);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200272", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void method_6(TreeNode treeNode_0)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		foreach (TreeNode node in treeNode_0.Nodes)
		{
			TreeNode val = node;
			if (Conversions.ToString(val.Tag).Contains(".inst"))
			{
				if (val.Checked)
				{
					((ToolStripItem)TSL_Loadingtext).Visible = true;
					((ToolStripItem)TSL_Loadingtext).Text = "Loading: " + val.Text;
					Client.CurrentScenario.ImportUnitsFromFile(Conversions.ToString(val.Tag), Client.CurrentSide);
					Client.MustRefreshMainForm = true;
				}
			}
			else
			{
				method_6(val);
			}
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		if (TV1.Nodes.Count == 0)
		{
			return;
		}
		method_6(TV1.Nodes[0]);
		((ToolStripItem)TSL_Loadingtext).Text = "Completed!";
		foreach (TreeNode item in Module1.AllNodes(TV1))
		{
			if (item.Checked)
			{
				item.Checked = false;
			}
		}
		Client.MustRefreshMainForm = true;
	}

	private void LoadGroup_VisibleChanged(object sender, EventArgs e)
	{
		if (((Control)this).Visible)
		{
			((Control)MyProject.Forms.MainForm).Enabled = false;
		}
		else
		{
			((Control)MyProject.Forms.MainForm).Enabled = true;
		}
	}

	private void LoadGroup_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
	}

	static LoadGroup()
	{
		Class72.smethod_20();
	}
}
