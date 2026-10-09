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
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ListActions : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridView1")]
	private DarkDataGridView _DataGridView1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditSelected")]
	private DarkUIButton _Button_EditSelected;

	[AccessedThroughProperty("Button_DeleteSelected")]
	[CompilerGenerated]
	private DarkUIButton _Button_DeleteSelected;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_CloneSelected")]
	private DarkUIButton _Button_CloneSelected;

	private EditAction editAction_0;

	private string string_0;

	private bool bool_2;

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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			EventHandler eventHandler = method_6;
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_7);
			DataGridViewCellMouseEventHandler val2 = new DataGridViewCellMouseEventHandler(method_8);
			DarkDataGridView darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
				((DataGridView)darkDataGridView).CellDoubleClick -= val;
				((DataGridView)darkDataGridView).CellMouseDown -= val2;
			}
			_DataGridView1 = value;
			darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
				((DataGridView)darkDataGridView).CellDoubleClick += val;
				((DataGridView)darkDataGridView).CellMouseDown += val2;
			}
		}
	}

	[field: AccessedThroughProperty("CB_ActionType")]
	internal virtual DarkUIComboBox CB_ActionType { get; set; }

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

	[field: AccessedThroughProperty("Description")]
	internal virtual DataGridViewTextBoxColumn Description { get; set; }

	[field: AccessedThroughProperty("Type")]
	internal virtual DataGridViewTextBoxColumn Type { get; set; }

	public ListActions()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Shown += ListActions_Shown;
		((Control)this).KeyDown += new KeyEventHandler(ListActions_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(ListActions_FormClosing);
		((Form)this).Load += ListActions_Load;
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
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Expected O, but got Unknown
		//IL_0442: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Expected O, but got Unknown
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0507: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Expected O, but got Unknown
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Expected O, but got Unknown
		//IL_0613: Unknown result type (might be due to invalid IL or missing references)
		//IL_068d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0697: Expected O, but got Unknown
		//IL_06d8: Unknown result type (might be due to invalid IL or missing references)
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		CB_ActionType = new DarkUIComboBox();
		Button_EditSelected = new DarkUIButton();
		Button_DeleteSelected = new DarkUIButton();
		Button1 = new DarkUIButton();
		Button_CloneSelected = new DarkUIButton();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		Type = new DataGridViewTextBoxColumn();
		((ISupportInitialize)(object)DataGridView1).BeginInit();
		((Control)this).SuspendLayout();
		((DataGridView)DataGridView1).AllowUserToAddRows = false;
		((DataGridView)DataGridView1).AllowUserToDeleteRows = false;
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
			(DataGridViewColumn)Description,
			(DataGridViewColumn)Type
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
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
		((DataGridView)DataGridView1).RowHeadersVisible = false;
		((DataGridView)DataGridView1).RowHeadersWidth = 51;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DataGridView1).RowsDefaultCellStyle = val3;
		((DataGridView)DataGridView1).SelectionMode = (DataGridViewSelectionMode)1;
		((DataGridView)DataGridView1).ShowCellToolTips = false;
		((DataGridView)DataGridView1).ShowEditingIcon = false;
		((DataGridView)DataGridView1).ShowRowErrors = false;
		((Control)DataGridView1).Size = new Size(655, 365);
		((Control)DataGridView1).TabIndex = 3;
		((Control)CB_ActionType).Anchor = (AnchorStyles)6;
		((ComboBox)CB_ActionType).BackColor = Color.Transparent;
		((ComboBox)CB_ActionType).DrawMode = (DrawMode)1;
		((ComboBox)CB_ActionType).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_ActionType).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_ActionType).FormattingEnabled = true;
		((ComboBox)CB_ActionType).Items.AddRange(new object[6] { "Points", "End Scenario", "Teleport to Area", "Message", "Change Mission Status", "Lua Script" });
		((Control)CB_ActionType).Location = new Point(115, 370);
		((Control)CB_ActionType).Name = "CB_ActionType";
		((Control)CB_ActionType).Size = new Size(173, 24);
		((Control)CB_ActionType).TabIndex = 15;
		((Control)Button_EditSelected).Anchor = (AnchorStyles)2;
		((ButtonBase)Button_EditSelected).BackColor = Color.Transparent;
		((Control)Button_EditSelected).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_EditSelected).ForeColor = SystemColors.Control;
		((Control)Button_EditSelected).Location = new Point(437, 370);
		((Control)Button_EditSelected).Name = "Button_EditSelected";
		((Control)Button_EditSelected).Padding = new Padding(5);
		Button_EditSelected.RoundRadius = 0;
		((Control)Button_EditSelected).Size = new Size(110, 21);
		((Control)Button_EditSelected).TabIndex = 14;
		Button_EditSelected.Text = "Edit selected";
		((Control)Button_DeleteSelected).Anchor = (AnchorStyles)2;
		((ButtonBase)Button_DeleteSelected).BackColor = Color.Transparent;
		((Control)Button_DeleteSelected).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_DeleteSelected).ForeColor = SystemColors.Control;
		((Control)Button_DeleteSelected).Location = new Point(553, 370);
		((Control)Button_DeleteSelected).Name = "Button_DeleteSelected";
		((Control)Button_DeleteSelected).Padding = new Padding(5);
		Button_DeleteSelected.RoundRadius = 0;
		((Control)Button_DeleteSelected).Size = new Size(105, 21);
		((Control)Button_DeleteSelected).TabIndex = 13;
		Button_DeleteSelected.Text = "Delete selected";
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(3, 370);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(106, 21);
		((Control)Button1).TabIndex = 12;
		Button1.Text = "Create new action:";
		((Control)Button_CloneSelected).Anchor = (AnchorStyles)2;
		((ButtonBase)Button_CloneSelected).BackColor = Color.Transparent;
		((Control)Button_CloneSelected).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_CloneSelected).ForeColor = SystemColors.Control;
		((Control)Button_CloneSelected).Location = new Point(315, 370);
		((Control)Button_CloneSelected).Name = "Button_CloneSelected";
		((Control)Button_CloneSelected).Padding = new Padding(5);
		Button_CloneSelected.RoundRadius = 0;
		((Control)Button_CloneSelected).Size = new Size(116, 21);
		((Control)Button_CloneSelected).TabIndex = 16;
		Button_CloneSelected.Text = "Clone selected";
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		((DataGridViewColumn)ID).HeaderText = "ID";
		((DataGridViewColumn)ID).MinimumWidth = 6;
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).ReadOnly = true;
		((DataGridViewColumn)ID).Visible = false;
		((DataGridViewColumn)ID).Width = 10;
		((DataGridViewColumn)Description).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Description).DataPropertyName = "Description";
		((DataGridViewColumn)Description).HeaderText = "Description";
		((DataGridViewColumn)Description).MinimumWidth = 6;
		((DataGridViewColumn)Description).Name = "Description";
		((DataGridViewColumn)Description).ReadOnly = true;
		((DataGridViewColumn)Type).AutoSizeMode = (DataGridViewAutoSizeColumnMode)10;
		((DataGridViewColumn)Type).DataPropertyName = "Type";
		((DataGridViewColumn)Type).HeaderText = "Type";
		((DataGridViewColumn)Type).MinimumWidth = 50;
		((DataGridViewColumn)Type).Name = "Type";
		((DataGridViewColumn)Type).ReadOnly = true;
		((DataGridViewColumn)Type).Width = 67;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(661, 397);
		((Control)this).Controls.Add((Control)(object)Button_CloneSelected);
		((Control)this).Controls.Add((Control)(object)CB_ActionType);
		((Control)this).Controls.Add((Control)(object)Button_EditSelected);
		((Control)this).Controls.Add((Control)(object)Button_DeleteSelected);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)DataGridView1);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "ListActions";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Event Actions";
		((ISupportInitialize)(object)DataGridView1).EndInit();
		((Control)this).ResumeLayout(false);
	}

	public void RefreshGrid(int rowIndex = 0)
	{
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Expected O, but got Unknown
		try
		{
			bool_2 = true;
			((Control)DataGridView1).SuspendLayout();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(string));
			dataTable.Columns.Add("Description", typeof(string));
			dataTable.Columns.Add("Type", typeof(string));
			dataTable.Columns.Add("Script For", typeof(string));
			foreach (EventAction item in Client.CurrentScenario.EventActions.Values.OrderBy([SpecialName] (EventAction theAction) => theAction.Description))
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["ID"] = item.ObjectID;
				dataRow["Description"] = item.Description;
				dataRow["Type"] = item.Type.ToString();
				if (item.Type == EventAction.EventActionType.LuaScript)
				{
					dataRow["Script For"] = ((EventAction_LuaScript)item).ScriptForType.ToString();
				}
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
			ex2?.Data.Add("Error at 200380", ex2.Message);
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
		if (((ComboBox)CB_ActionType).SelectedIndex <= -1)
		{
			return;
		}
		EventAction theEA;
		switch (((ComboBox)CB_ActionType).SelectedIndex)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		case 0:
			theEA = new EventAction_Points();
			break;
		case 1:
			theEA = new EventAction_EndScenario();
			break;
		case 2:
			theEA = new EventAction_TeleportInArea();
			break;
		case 3:
			theEA = new EventAction_Message();
			break;
		case 4:
			theEA = new EventAction_ChangeMissionStatus();
			break;
		case 5:
			theEA = new EventAction_LuaScript();
			break;
		}
		editAction_0 = new EditAction();
		editAction_0.theEA = theEA;
		editAction_0.Action = EditAction._FormAction.AddNew;
		((Control)editAction_0).Show();
	}

	private void method_3(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count != 0)
		{
			EventAction theEA = Client.CurrentScenario.EventActions[Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value)];
			editAction_0 = new EditAction();
			editAction_0.theEA = theEA;
			editAction_0.Action = EditAction._FormAction.EditExisting;
			((Control)editAction_0).Show();
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Invalid comparison between Unknown and I4
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count == 0)
		{
			return;
		}
		string key = Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value);
		EventAction value = Client.CurrentScenario.EventActions[key];
		int rowIndex = -1;
		int num = ((DataGridView)DataGridView1).Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			if (((DataGridView)DataGridView1).Rows[i].Cells["ID"].Value == value.ObjectID)
			{
				rowIndex = i;
				break;
			}
		}
		if (Information.IsNothing((object)value))
		{
			return;
		}
		bool flag = false;
		foreach (SimEvent value2 in Client.CurrentScenario.SimEvents.Values)
		{
			if (value2.Actions.Contains(value))
			{
				flag = true;
				break;
			}
		}
		if (flag && (int)DarkMessageBox.ShowWarning("This action is used by at least one event, are you sure you want to delete it?", "Action is in use!", DarkDialogButton.YesNo) == 7)
		{
			return;
		}
		Client.CurrentScenario.EventActions.TryRemove(value.ObjectID, out value);
		foreach (SimEvent value3 in Client.CurrentScenario.SimEvents.Values)
		{
			value3.Actions.Remove(value);
		}
		RefreshGrid(rowIndex);
	}

	private void ListActions_Shown(object sender, EventArgs e)
	{
		RefreshGrid();
	}

	private void ListActions_KeyDown(object sender, KeyEventArgs e)
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

	private void ListActions_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_5(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count != 0)
		{
			string key = Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value);
			EventAction eventAction = Client.CurrentScenario.EventActions[key].Clone();
			Client.CurrentScenario.EventActions.TryAdd(eventAction.ObjectID, eventAction);
			RefreshGrid();
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		if (!bool_2 && ((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count != 0)
		{
			string_0 = Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value);
		}
	}

	private void ListActions_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void method_7(object sender, DataGridViewCellEventArgs e)
	{
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count != 0 && e.ColumnIndex != 3)
		{
			EventAction theEA = Client.CurrentScenario.EventActions[Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value)];
			editAction_0 = new EditAction();
			editAction_0.theEA = theEA;
			editAction_0.Action = EditAction._FormAction.EditExisting;
			((Control)editAction_0).Show();
		}
	}

	public void ShowEditTrigger(EventAction theEA)
	{
		editAction_0 = new EditAction();
		editAction_0.theEA = theEA;
		editAction_0.Action = EditAction._FormAction.EditExisting;
		((Control)editAction_0).Show();
	}

	private void method_8(object sender, DataGridViewCellMouseEventArgs e)
	{
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count == 0 || e.ColumnIndex != 3 || e.RowIndex == -1)
		{
			return;
		}
		int rowIndex = e.RowIndex;
		string key = Conversions.ToString(((DataGridView)DataGridView1).Rows[rowIndex].Cells["ID"].Value);
		EventAction eventAction = Client.CurrentScenario.EventActions[key];
		if (eventAction == null || eventAction.Type != EventAction.EventActionType.LuaScript)
		{
			return;
		}
		bool flag = false;
		foreach (SimEvent value in Client.CurrentScenario.SimEvents.Values)
		{
			if (value.Actions.Contains(eventAction))
			{
				flag = true;
				break;
			}
		}
		EventAction_LuaScript.EventAction_LuaScript_Type result;
		if (flag)
		{
			DarkMessageBox.ShowWarning("This action is used by at least one actual event", "Action is in use!", DarkDialogButton.Close);
		}
		else if (Enum.TryParse<EventAction_LuaScript.EventAction_LuaScript_Type>(Conversions.ToString(((DataGridView)DataGridView1).Rows[rowIndex].Cells["Script For"].Value), out result))
		{
			result++;
			if (!Enum.IsDefined(typeof(EventAction_LuaScript.EventAction_LuaScript_Type), result))
			{
				((DataGridView)DataGridView1).Rows[rowIndex].Cells["Script For"].Value = EventAction_LuaScript.EventAction_LuaScript_Type.EventAction;
			}
			else
			{
				((DataGridView)DataGridView1).Rows[rowIndex].Cells["Script For"].Value = result;
			}
			if (eventAction.Type == EventAction.EventActionType.LuaScript)
			{
				((EventAction_LuaScript)eventAction).ScriptForType = result;
			}
		}
	}

	static ListActions()
	{
		Class72.smethod_20();
	}
}
