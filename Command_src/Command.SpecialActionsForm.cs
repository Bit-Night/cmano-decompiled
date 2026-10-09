using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class SpecialActionsForm : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("DataGridView1")]
	[CompilerGenerated]
	private DarkDataGridView _DataGridView1;

	[CompilerGenerated]
	private bool bool_2;

	private Keys[] keys_0;

	internal virtual DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return _DataGridView1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_2);
			DataGridViewCellFormattingEventHandler val2 = new DataGridViewCellFormattingEventHandler(method_3);
			DarkDataGridView darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellClick -= val;
				((DataGridView)darkDataGridView).CellFormatting -= val2;
			}
			_DataGridView1 = value;
			darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellClick += val;
				((DataGridView)darkDataGridView).CellFormatting += val2;
			}
		}
	}

	[field: AccessedThroughProperty("ID")]
	internal virtual DataGridViewTextBoxColumn ID { get; set; }

	[field: AccessedThroughProperty("ActionName")]
	internal virtual DataGridViewTextBoxColumn ActionName { get; set; }

	[field: AccessedThroughProperty("ExecuteAction")]
	internal virtual DataGridViewButtonColumn ExecuteAction { get; set; }

	[field: AccessedThroughProperty("CB_AllowActionPopup")]
	internal virtual DarkCheckBox CB_AllowActionPopup { get; set; }

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1 { get; set; }

	[field: AccessedThroughProperty("txtDesc")]
	internal virtual DarkUITextBox txtDesc { get; set; }

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

	public SpecialActionsForm()
	{
		((Control)this).VisibleChanged += SpecialActionsForm_VisibleChanged;
		((Form)this).Load += SpecialActionsForm_Load;
		RTMPEnabled = true;
		keys_0 = (Keys[])(object)new Keys[1] { (Keys)27 };
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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_047c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0486: Expected O, but got Unknown
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Expected O, but got Unknown
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Expected O, but got Unknown
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		ActionName = new DataGridViewTextBoxColumn();
		ExecuteAction = new DataGridViewButtonColumn();
		CB_AllowActionPopup = new DarkCheckBox();
		TableLayoutPanel1 = new TableLayoutPanel();
		txtDesc = new DarkUITextBox();
		((ISupportInitialize)(object)DataGridView1).BeginInit();
		((Control)TableLayoutPanel1).SuspendLayout();
		((Control)this).SuspendLayout();
		((DataGridView)DataGridView1).AllowUserToAddRows = false;
		((DataGridView)DataGridView1).AllowUserToOrderColumns = true;
		((Control)DataGridView1).Anchor = (AnchorStyles)15;
		((DataGridView)DataGridView1).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DataGridView1).BorderStyle = (BorderStyle)2;
		((DataGridView)DataGridView1).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DataGridView1).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DataGridView1).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DataGridView1).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DataGridView1).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[3]
		{
			(DataGridViewColumn)ID,
			(DataGridViewColumn)ActionName,
			(DataGridViewColumn)ExecuteAction
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DataGridView1).DefaultCellStyle = val2;
		((DataGridView)DataGridView1).EnableHeadersVisualStyles = false;
		((Control)DataGridView1).Location = new Point(3, 3);
		((DataGridView)DataGridView1).MultiSelect = false;
		((Control)DataGridView1).Name = "DataGridView1";
		((DataGridView)DataGridView1).RowHeadersWidth = 62;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DataGridView1).RowsDefaultCellStyle = val3;
		((Control)DataGridView1).Size = new Size(762, 227);
		((Control)DataGridView1).TabIndex = 0;
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		((DataGridViewColumn)ID).HeaderText = "ID";
		((DataGridViewColumn)ID).MinimumWidth = 8;
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).ReadOnly = true;
		((DataGridViewColumn)ID).Visible = false;
		((DataGridViewColumn)ID).Width = 150;
		((DataGridViewColumn)ActionName).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)ActionName).DataPropertyName = "Name";
		((DataGridViewColumn)ActionName).HeaderText = "Name";
		((DataGridViewColumn)ActionName).MinimumWidth = 8;
		((DataGridViewColumn)ActionName).Name = "ActionName";
		((DataGridViewColumn)ActionName).ReadOnly = true;
		((DataGridViewColumn)ExecuteAction).HeaderText = "";
		((DataGridViewColumn)ExecuteAction).MinimumWidth = 8;
		((DataGridViewColumn)ExecuteAction).Name = "ExecuteAction";
		((DataGridViewColumn)ExecuteAction).ReadOnly = true;
		ExecuteAction.Text = "Execute";
		ExecuteAction.UseColumnTextForButtonValue = true;
		((DataGridViewColumn)ExecuteAction).Width = 150;
		((Control)CB_AllowActionPopup).Anchor = (AnchorStyles)6;
		((ButtonBase)CB_AllowActionPopup).AutoSize = true;
		((CheckBox)CB_AllowActionPopup).Checked = true;
		((CheckBox)CB_AllowActionPopup).CheckState = (CheckState)1;
		((Control)CB_AllowActionPopup).Location = new Point(3, 475);
		((Control)CB_AllowActionPopup).Name = "CB_AllowActionPopup";
		((Control)CB_AllowActionPopup).Size = new Size(391, 29);
		((Control)CB_AllowActionPopup).TabIndex = 2;
		((ButtonBase)CB_AllowActionPopup).Text = "Show pop-up message with action feedback";
		TableLayoutPanel1.ColumnCount = 1;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)2, 100f));
		TableLayoutPanel1.Controls.Add((Control)(object)DataGridView1, 0, 0);
		TableLayoutPanel1.Controls.Add((Control)(object)CB_AllowActionPopup, 0, 2);
		TableLayoutPanel1.Controls.Add((Control)(object)txtDesc, 0, 1);
		((Control)TableLayoutPanel1).Dock = (DockStyle)5;
		((Control)TableLayoutPanel1).Location = new Point(0, 0);
		((Control)TableLayoutPanel1).Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 3;
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 46f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 46f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 8f));
		((Control)TableLayoutPanel1).Size = new Size(768, 507);
		((Control)TableLayoutPanel1).TabIndex = 3;
		txtDesc.AutoCompleteCustomSource = null;
		txtDesc.AutoCompleteMode = (AutoCompleteMode)0;
		txtDesc.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)txtDesc).BackColor = Color.Transparent;
		((Control)txtDesc).Dock = (DockStyle)5;
		((Control)txtDesc).ForeColor = Color.FromArgb(189, 189, 189);
		txtDesc.Image = null;
		txtDesc.Lines = null;
		((Control)txtDesc).Location = new Point(3, 236);
		txtDesc.MaxLength = 32767;
		txtDesc.Multiline = true;
		((Control)txtDesc).Name = "txtDesc";
		txtDesc.ReadOnly = false;
		txtDesc.ScrollBars = (ScrollBars)2;
		txtDesc.SelectionStart = 0;
		((Control)txtDesc).Size = new Size(762, 227);
		((Control)txtDesc).TabIndex = 3;
		txtDesc.TextAlign = (HorizontalAlignment)0;
		txtDesc.UseSystemPasswordChar = false;
		txtDesc.WatermarkText = "";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(768, 507);
		((Control)this).Controls.Add((Control)(object)TableLayoutPanel1);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "SpecialActionsForm";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Special Actions";
		((ISupportInitialize)(object)DataGridView1).EndInit();
		((Control)TableLayoutPanel1).ResumeLayout(false);
		((Control)TableLayoutPanel1).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		Keys[] array = keys_0;
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				Keys val = array[num];
				if (keyData == val)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return false;
		}
		int result;
		if (((Control)this).Visible)
		{
			((Form)this).Close();
			result = 1;
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	private void SpecialActionsForm_VisibleChanged(object sender, EventArgs e)
	{
		if (((Control)this).Visible)
		{
			RefreshGrid();
		}
	}

	public void RefreshGrid()
	{
		if (Client.CurrentSide == null)
		{
			return;
		}
		try
		{
			SpecialAction specialAction = null;
			((Control)DataGridView1).SuspendLayout();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(string));
			dataTable.Columns.Add("Name", typeof(string));
			foreach (SpecialAction item in from theAction in Client.CurrentSide.SpecialActions.Values
				where theAction.IsActive
				orderby theAction.Name
				select theAction)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["ID"] = item.ObjectID;
				dataRow["Name"] = item.Name;
				dataTable.Rows.Add(dataRow);
				if (dataTable.Rows.Count == 1)
				{
					specialAction = item;
				}
			}
			((DataGridView)DataGridView1).AutoGenerateColumns = false;
			((DataGridView)DataGridView1).DataSource = dataTable;
			((Control)DataGridView1).ResumeLayout();
			if (((DataGridView)DataGridView1).Rows.Count > 0)
			{
				((DataGridView)DataGridView1).Rows[0].Selected = true;
				((DataGridView)DataGridView1).Rows[0].Cells[0].ToolTipText = specialAction.Description;
				((Control)txtDesc).Visible = true;
				txtDesc.Text = specialAction.Description;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200406", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			((Control)this).Refresh();
			ProjectData.ClearProjectError();
		}
	}

	private void method_2(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1 || e.ColumnIndex == -1 || e.RowIndex > ((DataGridView)DataGridView1).Rows.Count - 1)
		{
			return;
		}
		DataGridViewColumn val = ((DataGridView)DataGridView1).Columns[e.ColumnIndex];
		string text = Conversions.ToString(((DataGridView)DataGridView1).Rows[e.RowIndex].Cells["ID"].Value);
		if (!Client.CurrentSide.SpecialActions.ContainsKey(text))
		{
			return;
		}
		SpecialAction specialAction = Client.CurrentSide.SpecialActions[text];
		specialAction.ShowResults = ((CheckBox)CB_AllowActionPopup).Checked;
		((Control)txtDesc).Visible = true;
		txtDesc.Text = specialAction.Description;
		int mustRefreshMainForm;
		if (Operators.CompareString(val.Name, "ExecuteAction", true) == 0)
		{
			if (!Client.Realtime)
			{
				string theResult = specialAction.Execute(Client.CurrentScenario);
				ShowActionResult(text, theResult, specialAction.ShowResults);
			}
			else
			{
				Client.RealtimeTerminal.SendSpecialActionExecute(text, Client.CurrentSide);
				((Control)DataGridView1).Enabled = false;
			}
			RefreshGrid();
			mustRefreshMainForm = 1;
		}
		else
		{
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
	}

	private void SpecialActionsForm_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		((Control)DataGridView1).Enabled = true;
	}

	private void method_3(object sender, DataGridViewCellFormattingEventArgs e)
	{
		if (Client.CurrentSide.SpecialActions.Count > 0)
		{
			string key = Conversions.ToString(((DataGridView)DataGridView1).Rows[e.RowIndex].Cells["ID"].Value);
			if (Client.CurrentSide.SpecialActions.ContainsKey(key))
			{
				SpecialAction specialAction = Client.CurrentSide.SpecialActions[key];
				((DataGridView)DataGridView1).Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = specialAction.Description;
			}
		}
	}

	public void ShowActionResult(string theActionID, string theResult, bool? bShowResults = null)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		if ((bShowResults ?? false) || (!bShowResults.HasValue && ((CheckBox)CB_AllowActionPopup).Checked))
		{
			string text = "Unknown Action";
			SpecialAction value = null;
			if (Client.CurrentSide.SpecialActions.TryGetValue(theActionID, out value))
			{
				text = value.Name;
			}
			if (theResult != null && Operators.CompareString(theResult, "", true) != 0)
			{
				DarkMessageBox.ShowInformation(theResult, text);
			}
			else
			{
				DarkMessageBox.ShowError("Special Action '" + text + "' script failed!", "Error");
			}
		}
		((Control)DataGridView1).Enabled = true;
	}

	static SpecialActionsForm()
	{
		Class72.smethod_20();
	}
}
