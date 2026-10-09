using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ListSpecialActions : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditSelected")]
	private DarkUIButton _Button_EditSelected;

	[AccessedThroughProperty("Button_DeleteSelected")]
	[CompilerGenerated]
	private DarkUIButton _Button_DeleteSelected;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_CloneSelected")]
	private DarkUIButton _Button_CloneSelected;

	[AccessedThroughProperty("DataGridView1")]
	[CompilerGenerated]
	private DarkDataGridView _DataGridView1;

	private EditSpecialAction editSpecialAction_0;

	private string string_0;

	private bool bool_2;

	internal virtual DarkUIButton Button_EditSelected
	{
		[CompilerGenerated]
		get
		{
			return _Button_EditSelected;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _Button_EditSelected;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_EditSelected = value;
			darkUIButton = _Button_EditSelected;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_DeleteSelected
	{
		[CompilerGenerated]
		get
		{
			return _Button_DeleteSelected;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIButton darkUIButton = _Button_DeleteSelected;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_DeleteSelected = value;
			darkUIButton = _Button_DeleteSelected;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

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

	internal virtual DarkUIButton Button_CloneSelected
	{
		[CompilerGenerated]
		get
		{
			return _Button_CloneSelected;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIButton darkUIButton = _Button_CloneSelected;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_CloneSelected = value;
			darkUIButton = _Button_CloneSelected;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ID")]
	internal virtual DataGridViewTextBoxColumn ID { get; set; }

	[field: AccessedThroughProperty("ActionName")]
	internal virtual DataGridViewTextBoxColumn ActionName { get; set; }

	[field: AccessedThroughProperty("IsActive")]
	internal virtual DataGridViewCheckBoxColumn IsActive { get; set; }

	[field: AccessedThroughProperty("IsRepeatable")]
	internal virtual DataGridViewCheckBoxColumn IsRepeatable { get; set; }

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
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			EventHandler eventHandler = method_6;
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_7);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(method_8);
			DarkDataGridView darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
				((DataGridView)darkDataGridView).CellClick -= val;
				((DataGridView)darkDataGridView).CellDoubleClick -= val2;
			}
			_DataGridView1 = value;
			darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
				((DataGridView)darkDataGridView).CellClick += val;
				((DataGridView)darkDataGridView).CellDoubleClick += val2;
			}
		}
	}

	[field: AccessedThroughProperty("Label_ActionDescription")]
	internal virtual DarkLabel Label_ActionDescription { get; set; }

	public ListSpecialActions()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Shown += ListSpecialActions_Shown;
		((Control)this).KeyDown += new KeyEventHandler(ListSpecialActions_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(ListSpecialActions_FormClosing);
		((Form)this).Load += ListSpecialActions_Load;
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
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Expected O, but got Unknown
		//IL_0566: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Expected O, but got Unknown
		//IL_062b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0635: Expected O, but got Unknown
		//IL_06f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fa: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		ActionName = new DataGridViewTextBoxColumn();
		IsActive = new DataGridViewCheckBoxColumn();
		IsRepeatable = new DataGridViewCheckBoxColumn();
		Button_EditSelected = new DarkUIButton();
		Button_DeleteSelected = new DarkUIButton();
		Button1 = new DarkUIButton();
		Button_CloneSelected = new DarkUIButton();
		Label_ActionDescription = new DarkLabel();
		((ISupportInitialize)(object)DataGridView1).BeginInit();
		((Control)this).SuspendLayout();
		((DataGridView)DataGridView1).AllowUserToAddRows = false;
		((DataGridView)DataGridView1).AllowUserToDeleteRows = false;
		((Control)DataGridView1).Anchor = (AnchorStyles)15;
		((DataGridView)DataGridView1).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DataGridView1).BorderStyle = (BorderStyle)2;
		((DataGridView)DataGridView1).CellBorderStyle = (DataGridViewCellBorderStyle)8;
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
		((DataGridView)DataGridView1).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[4]
		{
			(DataGridViewColumn)ID,
			(DataGridViewColumn)ActionName,
			(DataGridViewColumn)IsActive,
			(DataGridViewColumn)IsRepeatable
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DataGridView1).DefaultCellStyle = val2;
		((DataGridView)DataGridView1).EditMode = (DataGridViewEditMode)4;
		((DataGridView)DataGridView1).EnableHeadersVisualStyles = false;
		((Control)DataGridView1).Location = new Point(3, 3);
		((DataGridView)DataGridView1).MultiSelect = false;
		((Control)DataGridView1).Name = "DataGridView1";
		((DataGridView)DataGridView1).ReadOnly = true;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DataGridView1).RowsDefaultCellStyle = val3;
		((DataGridView)DataGridView1).SelectionMode = (DataGridViewSelectionMode)1;
		((DataGridView)DataGridView1).ShowCellToolTips = false;
		((DataGridView)DataGridView1).ShowEditingIcon = false;
		((DataGridView)DataGridView1).ShowRowErrors = false;
		((Control)DataGridView1).Size = new Size(496, 365);
		((Control)DataGridView1).TabIndex = 3;
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		((DataGridViewColumn)ID).HeaderText = "ID";
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).ReadOnly = true;
		((DataGridViewColumn)ID).Visible = false;
		((DataGridViewColumn)ActionName).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)ActionName).DataPropertyName = "Name";
		((DataGridViewColumn)ActionName).HeaderText = "Name";
		((DataGridViewColumn)ActionName).Name = "ActionName";
		((DataGridViewColumn)ActionName).ReadOnly = true;
		((DataGridViewColumn)IsActive).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)IsActive).DataPropertyName = "IsActive";
		((DataGridViewColumn)IsActive).HeaderText = "Is Active";
		((DataGridViewColumn)IsActive).Name = "IsActive";
		((DataGridViewColumn)IsActive).ReadOnly = true;
		((DataGridViewColumn)IsActive).Width = 52;
		((DataGridViewColumn)IsRepeatable).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)IsRepeatable).DataPropertyName = "IsRepeatable";
		((DataGridViewColumn)IsRepeatable).HeaderText = "Is Repeatable";
		((DataGridViewColumn)IsRepeatable).Name = "IsRepeatable";
		((DataGridViewColumn)IsRepeatable).ReadOnly = true;
		((DataGridViewColumn)IsRepeatable).Width = 77;
		((Control)Button_EditSelected).Anchor = (AnchorStyles)10;
		((ButtonBase)Button_EditSelected).BackColor = Color.Transparent;
		((Button)Button_EditSelected).DialogResult = (DialogResult)0;
		((Control)Button_EditSelected).Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_EditSelected).ForeColor = SystemColors.Control;
		((Control)Button_EditSelected).Location = new Point(276, 373);
		((Control)Button_EditSelected).Name = "Button_EditSelected";
		Button_EditSelected.RoundRadius = 0;
		((Control)Button_EditSelected).Size = new Size(110, 21);
		((Control)Button_EditSelected).TabIndex = 14;
		Button_EditSelected.Text = "Edit selected";
		((Control)Button_DeleteSelected).Anchor = (AnchorStyles)10;
		((ButtonBase)Button_DeleteSelected).BackColor = Color.Transparent;
		((Button)Button_DeleteSelected).DialogResult = (DialogResult)0;
		((Control)Button_DeleteSelected).Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_DeleteSelected).ForeColor = SystemColors.Control;
		((Control)Button_DeleteSelected).Location = new Point(392, 373);
		((Control)Button_DeleteSelected).Name = "Button_DeleteSelected";
		Button_DeleteSelected.RoundRadius = 0;
		((Control)Button_DeleteSelected).Size = new Size(105, 21);
		((Control)Button_DeleteSelected).TabIndex = 13;
		Button_DeleteSelected.Text = "Delete selected";
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(3, 373);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(145, 21);
		((Control)Button1).TabIndex = 12;
		Button1.Text = "Create new special action";
		((Control)Button_CloneSelected).Anchor = (AnchorStyles)10;
		((ButtonBase)Button_CloneSelected).BackColor = Color.Transparent;
		((Button)Button_CloneSelected).DialogResult = (DialogResult)0;
		((Control)Button_CloneSelected).Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_CloneSelected).ForeColor = SystemColors.Control;
		((Control)Button_CloneSelected).Location = new Point(154, 373);
		((Control)Button_CloneSelected).Name = "Button_CloneSelected";
		Button_CloneSelected.RoundRadius = 0;
		((Control)Button_CloneSelected).Size = new Size(116, 21);
		((Control)Button_CloneSelected).TabIndex = 16;
		Button_CloneSelected.Text = "Clone selected";
		((Control)Label_ActionDescription).Anchor = (AnchorStyles)9;
		Label_ActionDescription.AutoSize = true;
		((Control)Label_ActionDescription).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_ActionDescription).Location = new Point(505, 3);
		((Control)Label_ActionDescription).MaximumSize = new Size(185, 0);
		((Control)Label_ActionDescription).Name = "Label_ActionDescription";
		((Control)Label_ActionDescription).Size = new Size(39, 13);
		((Control)Label_ActionDescription).TabIndex = 17;
		((Label)Label_ActionDescription).Text = "Label1";
		((Control)Label_ActionDescription).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(693, 397);
		((Control)this).Controls.Add((Control)(object)Label_ActionDescription);
		((Control)this).Controls.Add((Control)(object)Button_CloneSelected);
		((Control)this).Controls.Add((Control)(object)Button_EditSelected);
		((Control)this).Controls.Add((Control)(object)Button_DeleteSelected);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)DataGridView1);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "ListSpecialActions";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Special Actions for this side";
		((ISupportInitialize)(object)DataGridView1).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public void RefreshGrid(int rowIndex = 0)
	{
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Expected O, but got Unknown
		if (Client.CurrentSide == null)
		{
			return;
		}
		try
		{
			bool_2 = true;
			((Control)DataGridView1).SuspendLayout();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(string));
			dataTable.Columns.Add("Name", typeof(string));
			dataTable.Columns.Add("IsActive", typeof(string));
			dataTable.Columns.Add("IsRepeatable", typeof(string));
			foreach (SpecialAction item in Client.CurrentSide.SpecialActions.Values.OrderBy([SpecialName] (SpecialAction theAction) => theAction.Name))
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["ID"] = item.ObjectID;
				dataRow["Name"] = item.Name;
				dataRow["IsActive"] = item.IsActive;
				dataRow["IsRepeatable"] = item.IsRepeatable;
				dataTable.Rows.Add(dataRow);
			}
			((DataGridView)DataGridView1).DataSource = dataTable;
			((Control)DataGridView1).ResumeLayout();
			bool_2 = false;
			if (((DataGridView)DataGridView1).Rows.Count > 0 && rowIndex > 0)
			{
				string_0 = Conversions.ToString(((DataGridView)DataGridView1).Rows[rowIndex - 1].Cells["ID"].Value);
			}
			if (string.IsNullOrEmpty(string_0))
			{
				return;
			}
			IEnumerator enumerator2 = ((IEnumerable)((DataGridView)DataGridView1).Rows).GetEnumerator();
			try
			{
				object objectValue;
				do
				{
					if (enumerator2.MoveNext())
					{
						objectValue = RuntimeHelpers.GetObjectValue(enumerator2.Current);
						continue;
					}
					return;
				}
				while (!Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, (Type)null, "Cells", new object[1] { "ID" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Value", new object[0], (string[])null, (Type[])null, (bool[])null), (object)string_0, true));
				((DataGridView)DataGridView1).CurrentCell = (DataGridViewCell)NewLateBinding.LateGet(objectValue, (Type)null, "cells", new object[1] { 1 }, (string[])null, (Type[])null, (bool[])null);
			}
			finally
			{
				IDisposable disposable = enumerator2 as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			RefreshGrid();
			ex2?.Data.Add("Error at 200381", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		SpecialAction theSA = new SpecialAction();
		editSpecialAction_0 = new EditSpecialAction();
		editSpecialAction_0.theSA = theSA;
		editSpecialAction_0.Action = EditSpecialAction._FormAction.AddNew;
		((Control)editSpecialAction_0).Show();
	}

	private void method_3(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count != 0)
		{
			SpecialAction theSA = Client.CurrentSide.SpecialActions[Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value)];
			editSpecialAction_0 = new EditSpecialAction();
			editSpecialAction_0.theSA = theSA;
			editSpecialAction_0.Action = EditSpecialAction._FormAction.EditExisting;
			((Control)editSpecialAction_0).Show();
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count == 0)
		{
			return;
		}
		string key = Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value);
		SpecialAction specialAction = Client.CurrentSide.SpecialActions[key];
		int rowIndex = -1;
		int num = ((DataGridView)DataGridView1).Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			if (((DataGridView)DataGridView1).Rows[i].Cells["ID"].Value == specialAction.ObjectID)
			{
				rowIndex = i;
				break;
			}
		}
		if (!Information.IsNothing((object)specialAction))
		{
			Client.CurrentSide.SpecialActions.Remove(specialAction.ObjectID);
			RefreshGrid(rowIndex);
		}
	}

	private void ListSpecialActions_Shown(object sender, EventArgs e)
	{
		RefreshGrid();
	}

	private void ListSpecialActions_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Invalid comparison between Unknown and I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Invalid comparison between Unknown and I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Invalid comparison between Unknown and I4
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Invalid comparison between Unknown and I4
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Invalid comparison between Unknown and I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Invalid comparison between Unknown and I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Invalid comparison between Unknown and I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void ListSpecialActions_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_5(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count != 0)
		{
			string key = Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value);
			SpecialAction specialAction = Client.CurrentSide.SpecialActions[key].Clone();
			Client.CurrentSide.SpecialActions.Add(specialAction.ObjectID, specialAction);
			RefreshGrid();
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count == 0)
		{
			((Control)Label_ActionDescription).Visible = false;
			return;
		}
		((Control)Label_ActionDescription).Visible = true;
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count != 0)
		{
			string key = Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value);
			SpecialAction specialAction = Client.CurrentSide.SpecialActions[key];
			((Label)Label_ActionDescription).Text = specialAction.Description;
			if (!bool_2)
			{
				string_0 = Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value);
			}
		}
	}

	private void method_7(object sender, DataGridViewCellEventArgs e)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		if (e.RowIndex == -1 || e.ColumnIndex == -1)
		{
			return;
		}
		DataGridViewColumn val = ((DataGridView)DataGridView1).Columns[e.ColumnIndex];
		if (!((Operators.CompareString(val.Name, "IsActive", true) == 0) | (Operators.CompareString(val.Name, "IsRepeatable", true) == 0)))
		{
			return;
		}
		DataGridViewCheckBoxCell val2 = (DataGridViewCheckBoxCell)((DataGridView)DataGridView1)[e.ColumnIndex, e.RowIndex];
		string key = Conversions.ToString(((DataGridView)DataGridView1).Rows[e.RowIndex].Cells["ID"].Value);
		SpecialAction specialAction = Client.CurrentSide.SpecialActions[key];
		((DataGridViewCell)val2).Value = !Conversions.ToBoolean(((DataGridViewCell)val2).Value);
		if (Operators.CompareString(val.Name, "IsActive", true) != 0)
		{
			if (Operators.CompareString(val.Name, "IsRepeatable", true) == 0)
			{
				specialAction.IsRepeatable = Conversions.ToBoolean(((DataGridViewCell)val2).Value);
			}
		}
		else
		{
			specialAction.IsActive = Conversions.ToBoolean(((DataGridViewCell)val2).Value);
		}
	}

	private void ListSpecialActions_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void method_8(object sender, DataGridViewCellEventArgs e)
	{
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count != 0)
		{
			SpecialAction theSA = Client.CurrentSide.SpecialActions[Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value)];
			editSpecialAction_0 = new EditSpecialAction();
			editSpecialAction_0.theSA = theSA;
			editSpecialAction_0.Action = EditSpecialAction._FormAction.EditExisting;
			((Control)editSpecialAction_0).Show();
		}
	}

	static ListSpecialActions()
	{
		Class72.smethod_20();
	}
}
