using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class SelectSAO : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripButton1")]
	private ToolStripButton _ToolStripButton1;

	private List<ScenAttachmentObject> list_0;

	public List<ScenAttachmentObject> SelectedSAOs;

	[field: AccessedThroughProperty("ToolStrip1")]
	internal virtual DarkToolStrip ToolStrip1 { get; set; }

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("DataGridView1")]
	internal virtual DarkDataGridView DataGridView1 { get; set; }

	[field: AccessedThroughProperty("TabControl1")]
	internal virtual DarkUITabControl TabControl1 { get; set; }

	internal virtual ToolStripButton ToolStripButton1
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			ToolStripButton val = _ToolStripButton1;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ToolStripButton1 = value;
			val = _ToolStripButton1;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Column_name")]
	internal virtual DataGridViewTextBoxColumn Column_name { get; set; }

	[field: AccessedThroughProperty("Type")]
	internal virtual DataGridViewTextBoxColumn Type { get; set; }

	[field: AccessedThroughProperty("GUID")]
	internal virtual DataGridViewTextBoxColumn GUID { get; set; }

	public SelectSAO()
	{
		((Form)this).Shown += SelectSAO_Shown;
		((Form)this).Load += SelectSAO_Load;
		SelectedSAOs = new List<ScenAttachmentObject>();
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
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected O, but got Unknown
		//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ed: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(SelectSAO));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		ToolStrip1 = new DarkToolStrip();
		ToolStripButton1 = new ToolStripButton();
		TabPage1 = new TabPage();
		DataGridView1 = new DarkDataGridView();
		Column_name = new DataGridViewTextBoxColumn();
		Type = new DataGridViewTextBoxColumn();
		GUID = new DataGridViewTextBoxColumn();
		TabControl1 = new DarkUITabControl();
		((Control)ToolStrip1).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((ISupportInitialize)(object)DataGridView1).BeginInit();
		((Control)TabControl1).SuspendLayout();
		((Control)this).SuspendLayout();
		((ToolStrip)ToolStrip1).AutoSize = false;
		((ToolStrip)ToolStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)ToolStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)ToolStrip1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)ToolStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[1] { (ToolStripItem)ToolStripButton1 });
		((Control)ToolStrip1).Location = new Point(0, 0);
		((Control)ToolStrip1).Name = "ToolStrip1";
		((Control)ToolStrip1).Padding = new Padding(5, 0, 1, 0);
		((Control)ToolStrip1).Size = new Size(845, 25);
		((Control)ToolStrip1).TabIndex = 2;
		((Control)ToolStrip1).Text = "ToolStrip1";
		((ToolStripItem)ToolStripButton1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripButton1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripButton1).Image = (Image)componentResourceManager.GetObject("ToolStripButton1.Image");
		((ToolStripItem)ToolStripButton1).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)ToolStripButton1).Name = "ToolStripButton1";
		((ToolStripItem)ToolStripButton1).Size = new Size(176, 22);
		((ToolStripItem)ToolStripButton1).Text = "Load selected attachment(s)";
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)DataGridView1);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(837, 294);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Local repository";
		((DataGridView)DataGridView1).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DataGridView1).BorderStyle = (BorderStyle)2;
		((DataGridView)DataGridView1).CellBorderStyle = (DataGridViewCellBorderStyle)4;
		((DataGridView)DataGridView1).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DataGridView1).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DataGridView1).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DataGridView1).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[3]
		{
			(DataGridViewColumn)Column_name,
			(DataGridViewColumn)Type,
			(DataGridViewColumn)GUID
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DataGridView1).DefaultCellStyle = val2;
		((Control)DataGridView1).Dock = (DockStyle)5;
		((DataGridView)DataGridView1).EnableHeadersVisualStyles = false;
		((Control)DataGridView1).Location = new Point(3, 3);
		((Control)DataGridView1).Name = "DataGridView1";
		((DataGridView)DataGridView1).RowHeadersVisible = false;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DataGridView1).RowsDefaultCellStyle = val3;
		((DataGridView)DataGridView1).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DataGridView1).Size = new Size(831, 288);
		((Control)DataGridView1).TabIndex = 0;
		((DataGridViewColumn)Column_name).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Column_name).HeaderText = "Name";
		((DataGridViewColumn)Column_name).Name = "Name";
		((DataGridViewColumn)Column_name).ReadOnly = true;
		((DataGridViewColumn)Column_name).Width = 58;
		((DataGridViewColumn)Type).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Type).HeaderText = "Type";
		((DataGridViewColumn)Type).Name = "Type";
		((DataGridViewColumn)Type).ReadOnly = true;
		((DataGridViewColumn)Type).Width = 54;
		((DataGridViewColumn)GUID).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)GUID).HeaderText = "GUID";
		((DataGridViewColumn)GUID).Name = "GUID";
		((DataGridViewColumn)GUID).ReadOnly = true;
		((Control)TabControl1).Controls.Add((Control)(object)TabPage1);
		((Control)TabControl1).Cursor = Cursors.Hand;
		((Control)TabControl1).Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		((TabControl)TabControl1).ItemSize = new Size(80, 20);
		((Control)TabControl1).Location = new Point(0, 28);
		((Control)TabControl1).Name = "TabControl1";
		((TabControl)TabControl1).SelectedIndex = 0;
		((Control)TabControl1).Size = new Size(845, 322);
		((Control)TabControl1).TabIndex = 1;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(845, 347);
		((Control)this).Controls.Add((Control)(object)TabControl1);
		((Control)this).Controls.Add((Control)(object)ToolStrip1);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "Select SAO";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Load existing scenario attachment";
		((Control)ToolStrip1).ResumeLayout(false);
		((Control)ToolStrip1).PerformLayout();
		((Control)TabPage1).ResumeLayout(false);
		((ISupportInitialize)(object)DataGridView1).EndInit();
		((Control)TabControl1).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	private void SelectSAO_Shown(object sender, EventArgs e)
	{
		SelectedSAOs.Clear();
		RefreshRepoAttachments();
	}

	public void RefreshRepoAttachments()
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		List<ScenAttachmentObject> list = new List<ScenAttachmentObject>();
		string[] directories = Directory.GetDirectories(GameGeneral.AttachmentRepoPath);
		for (int i = 0; i < directories.Length; i = checked(i + 1))
		{
			ScenAttachmentObject item = ScenAttachmentObject.ReadFromFolder(directories[i]);
			list.Add(item);
		}
		((Control)DataGridView1).SuspendLayout();
		((DataGridView)DataGridView1).Rows.Clear();
		foreach (ScenAttachmentObject item2 in list)
		{
			DataGridViewRow val = new DataGridViewRow();
			val.CreateCells((DataGridView)(object)DataGridView1);
			val.Cells[0].Value = item2.Name;
			val.Cells[1].Value = item2.Type.ToString();
			val.Cells[2].Value = item2.ObjectID;
			((DataGridViewBand)val).Tag = item2;
			((DataGridView)DataGridView1).Rows.Add(val);
		}
		((Control)DataGridView1).ResumeLayout();
	}

	private void method_2(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count == 0)
		{
			return;
		}
		foreach (object item2 in (BaseCollection)((DataGridView)DataGridView1).SelectedRows)
		{
			ScenAttachmentObject item = (ScenAttachmentObject)NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(item2), (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null);
			SelectedSAOs.Add(item);
		}
		((Form)this).DialogResult = (DialogResult)1;
		((Form)this).Close();
	}

	private void SelectSAO_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	static SelectSAO()
	{
		Class72.smethod_20();
	}
}
