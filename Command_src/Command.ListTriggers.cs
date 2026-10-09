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
public sealed class ListTriggers : DarkSecondaryFormBase
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

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[AccessedThroughProperty("Button_CloneSelected")]
	[CompilerGenerated]
	private DarkUIButton _Button_CloneSelected;

	private EditTrigger editTrigger_0;

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
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = method_6;
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_7);
			DarkDataGridView darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
				((DataGridView)darkDataGridView).CellDoubleClick -= val;
			}
			_DataGridView1 = value;
			darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
				((DataGridView)darkDataGridView).CellDoubleClick += val;
			}
		}
	}

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

	[field: AccessedThroughProperty("CB_TriggerType")]
	internal virtual DarkUIComboBox CB_TriggerType { get; set; }

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

	public ListTriggers()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Shown += ListTriggers_Shown;
		((Control)this).KeyDown += new KeyEventHandler(ListTriggers_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(ListTriggers_FormClosing);
		((Form)this).Load += ListTriggers_Load;
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
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected O, but got Unknown
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Expected O, but got Unknown
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Expected O, but got Unknown
		//IL_0580: Unknown result type (might be due to invalid IL or missing references)
		//IL_058a: Expected O, but got Unknown
		//IL_06b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c0: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		Button_EditSelected = new DarkUIButton();
		Button_DeleteSelected = new DarkUIButton();
		Button1 = new DarkUIButton();
		CB_TriggerType = new DarkUIComboBox();
		Button_CloneSelected = new DarkUIButton();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		Type = new DataGridViewTextBoxColumn();
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
		((Control)DataGridView1).TabIndex = 2;
		((Control)Button_EditSelected).Anchor = (AnchorStyles)10;
		((ButtonBase)Button_EditSelected).BackColor = Color.Transparent;
		((Button)Button_EditSelected).DialogResult = (DialogResult)0;
		((Control)Button_EditSelected).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_EditSelected).ForeColor = SystemColors.Control;
		((Control)Button_EditSelected).Location = new Point(455, 370);
		((Control)Button_EditSelected).Name = "Button_EditSelected";
		Button_EditSelected.RoundRadius = 0;
		((Control)Button_EditSelected).Size = new Size(98, 21);
		((Control)Button_EditSelected).TabIndex = 10;
		Button_EditSelected.Text = "Edit selected";
		((Control)Button_DeleteSelected).Anchor = (AnchorStyles)10;
		((ButtonBase)Button_DeleteSelected).BackColor = Color.Transparent;
		((Button)Button_DeleteSelected).DialogResult = (DialogResult)0;
		((Control)Button_DeleteSelected).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_DeleteSelected).ForeColor = SystemColors.Control;
		((Control)Button_DeleteSelected).Location = new Point(559, 370);
		((Control)Button_DeleteSelected).Name = "Button_DeleteSelected";
		Button_DeleteSelected.RoundRadius = 0;
		((Control)Button_DeleteSelected).Size = new Size(99, 21);
		((Control)Button_DeleteSelected).TabIndex = 9;
		Button_DeleteSelected.Text = "Delete selected";
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(3, 370);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(106, 21);
		((Control)Button1).TabIndex = 8;
		Button1.Text = "Create new trigger:";
		((Control)CB_TriggerType).Anchor = (AnchorStyles)6;
		((ComboBox)CB_TriggerType).BackColor = Color.Transparent;
		((ComboBox)CB_TriggerType).DrawMode = (DrawMode)1;
		((ComboBox)CB_TriggerType).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_TriggerType).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_TriggerType).FormattingEnabled = true;
		((ComboBox)CB_TriggerType).Items.AddRange(new object[15]
		{
			"Unit Is Destroyed", "Unit Is Damaged", "Side Points", "Time", "Unit Remains In Area", "Unit Enters Area", "Random Time", "Unit is Detected", "Scenario is Loaded", "Regular Time",
			"Scenario has Ended", "Base Ops Status", "Unit Emissions", "Unit Cargo Moved", "Player Joined Side"
		});
		((Control)CB_TriggerType).Location = new Point(115, 370);
		((Control)CB_TriggerType).Name = "CB_TriggerType";
		((Control)CB_TriggerType).Size = new Size(200, 21);
		((Control)CB_TriggerType).TabIndex = 11;
		((Control)Button_CloneSelected).Anchor = (AnchorStyles)10;
		((ButtonBase)Button_CloneSelected).BackColor = Color.Transparent;
		((Button)Button_CloneSelected).DialogResult = (DialogResult)0;
		((Control)Button_CloneSelected).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_CloneSelected).ForeColor = SystemColors.Control;
		((Control)Button_CloneSelected).Location = new Point(342, 370);
		((Control)Button_CloneSelected).Name = "Button_CloneSelected";
		Button_CloneSelected.RoundRadius = 0;
		((Control)Button_CloneSelected).Size = new Size(107, 21);
		((Control)Button_CloneSelected).TabIndex = 12;
		Button_CloneSelected.Text = "Clone selected";
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		((DataGridViewColumn)ID).HeaderText = "ID";
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).ReadOnly = true;
		((DataGridViewColumn)ID).Visible = false;
		((DataGridViewColumn)ID).Width = 10;
		((DataGridViewColumn)Description).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Description).DataPropertyName = "Description";
		((DataGridViewColumn)Description).HeaderText = "Description";
		((DataGridViewColumn)Description).Name = "Description";
		((DataGridViewColumn)Description).ReadOnly = true;
		((DataGridViewColumn)Type).AutoSizeMode = (DataGridViewAutoSizeColumnMode)10;
		((DataGridViewColumn)Type).DataPropertyName = "Type";
		((DataGridViewColumn)Type).HeaderText = "Type";
		((DataGridViewColumn)Type).MinimumWidth = 50;
		((DataGridViewColumn)Type).Name = "Type";
		((DataGridViewColumn)Type).ReadOnly = true;
		((DataGridViewColumn)Type).Width = 54;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(661, 397);
		((Control)this).Controls.Add((Control)(object)Button_CloneSelected);
		((Control)this).Controls.Add((Control)(object)CB_TriggerType);
		((Control)this).Controls.Add((Control)(object)Button_EditSelected);
		((Control)this).Controls.Add((Control)(object)Button_DeleteSelected);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)DataGridView1);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "ListTriggers";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Event Triggers";
		((ISupportInitialize)(object)DataGridView1).EndInit();
		((Control)this).ResumeLayout(false);
	}

	public void RefreshGrid(int rowIndex = 0)
	{
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		try
		{
			bool_2 = true;
			((Control)DataGridView1).SuspendLayout();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(string));
			dataTable.Columns.Add("Description", typeof(string));
			dataTable.Columns.Add("Type", typeof(string));
			foreach (EventTrigger item in Client.CurrentScenario.EventTriggers.Values.OrderBy([SpecialName] (EventTrigger theTrigger) => theTrigger.Description))
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["ID"] = item.ObjectID;
				dataRow["Description"] = item.Description;
				dataRow["Type"] = item.Type.ToString();
				dataTable.Rows.Add(dataRow);
			}
			((DataGridView)DataGridView1).DataSource = dataTable;
			((DataGridView)DataGridView1).Columns["Description"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
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
			ex2?.Data.Add("Error at 200382", ex2.Message);
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
		if (((ComboBox)CB_TriggerType).SelectedIndex <= -1)
		{
			return;
		}
		EventTrigger eventTrigger = null;
		switch (((ComboBox)CB_TriggerType).SelectedIndex)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		case 0:
			eventTrigger = new EventTrigger_UnitDestroyed();
			break;
		case 1:
			eventTrigger = new EventTrigger_UnitDamaged();
			break;
		case 2:
			eventTrigger = new EventTrigger_Points();
			break;
		case 3:
			eventTrigger = new EventTrigger_Time(Client.CurrentScenario.Time.AddMinutes(30.0));
			break;
		case 4:
			eventTrigger = new EventTrigger_UnitRemainsInArea();
			break;
		case 5:
			eventTrigger = new EventTrigger_UnitEntersArea();
			((EventTrigger_UnitEntersArea)eventTrigger).dateTime_0 = Client.CurrentScenario.Time;
			((EventTrigger_UnitEntersArea)eventTrigger).dateTime_1 = ((EventTrigger_UnitEntersArea)eventTrigger).dateTime_0.AddYears(1);
			break;
		case 6:
			eventTrigger = new EventTrigger_RandomTime(Client.CurrentScenario.Time.AddMinutes(30.0), Client.CurrentScenario.Time.AddMinutes(120.0));
			break;
		case 7:
			eventTrigger = new EventTrigger_UnitDetected();
			break;
		case 8:
			eventTrigger = new EventTrigger_ScenLoaded();
			break;
		case 9:
			eventTrigger = new EventTrigger_RegularTime();
			break;
		case 10:
			if (Client.CurrentScenario.IsRunningInCampaignMode)
			{
				eventTrigger = new EventTrigger_ScenLoaded();
			}
			break;
		case 11:
			eventTrigger = new EventTrigger_UnitBaseStatus();
			break;
		case 12:
			eventTrigger = new EventTrigger_UnitEmissions();
			break;
		case 13:
			eventTrigger = new EventTrigger_UnitCargoMoved();
			break;
		case 14:
			eventTrigger = new EventTrigger_PlayerJoinedSide();
			break;
		}
		if (((ComboBox)CB_TriggerType).SelectedIndex == 8)
		{
			EventTrigger_ScenLoaded eventTrigger_ScenLoaded = new EventTrigger_ScenLoaded();
			eventTrigger_ScenLoaded.Description = "Scenario is Loaded";
			Client.CurrentScenario.EventTriggers.TryAdd(eventTrigger_ScenLoaded.ObjectID, eventTrigger_ScenLoaded);
			RefreshGrid();
		}
		else if (((ComboBox)CB_TriggerType).SelectedIndex == 10)
		{
			EventTrigger_ScenEnded eventTrigger_ScenEnded = new EventTrigger_ScenEnded();
			eventTrigger_ScenEnded.Description = "Campaign/Scenario has Ended";
			Client.CurrentScenario.EventTriggers.TryAdd(eventTrigger_ScenEnded.ObjectID, eventTrigger_ScenEnded);
			RefreshGrid();
		}
		else if (((ComboBox)CB_TriggerType).SelectedIndex == 14)
		{
			EventTrigger_PlayerJoinedSide eventTrigger_PlayerJoinedSide = new EventTrigger_PlayerJoinedSide();
			eventTrigger_PlayerJoinedSide.Description = "Player Joined Side";
			Client.CurrentScenario.EventTriggers.TryAdd(eventTrigger_PlayerJoinedSide.ObjectID, eventTrigger_PlayerJoinedSide);
			RefreshGrid();
		}
		else
		{
			editTrigger_0 = new EditTrigger();
			editTrigger_0.theTrigger = eventTrigger;
			editTrigger_0.Action = EditTrigger._FormAction.AddNew;
			((Control)editTrigger_0).Show();
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count != 0)
		{
			EventTrigger theTrigger = Client.CurrentScenario.EventTriggers[Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value)];
			editTrigger_0 = new EditTrigger();
			editTrigger_0.theTrigger = theTrigger;
			editTrigger_0.Action = EditTrigger._FormAction.EditExisting;
			((Control)editTrigger_0).Show();
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Invalid comparison between Unknown and I4
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count == 0)
		{
			return;
		}
		string key = Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value);
		EventTrigger value = Client.CurrentScenario.EventTriggers[key];
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
			if (value2.Triggers.Contains(value))
			{
				flag = true;
				break;
			}
		}
		if (flag && (int)DarkMessageBox.ShowWarning("This trigger is used by at least one event, are you sure you want to delete it?", "Trigger is in use!", DarkDialogButton.YesNo) == 7)
		{
			return;
		}
		Client.CurrentScenario.EventTriggers.TryRemove(value.ObjectID, out value);
		foreach (SimEvent value3 in Client.CurrentScenario.SimEvents.Values)
		{
			value3.Triggers.Remove(value);
		}
		RefreshGrid(rowIndex);
	}

	private void ListTriggers_Shown(object sender, EventArgs e)
	{
		RefreshGrid();
	}

	private void ListTriggers_KeyDown(object sender, KeyEventArgs e)
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

	private void ListTriggers_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_5(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count != 0)
		{
			string key = Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value);
			EventTrigger eventTrigger = Client.CurrentScenario.EventTriggers[key].Clone();
			Client.CurrentScenario.EventTriggers.TryAdd(eventTrigger.ObjectID, eventTrigger);
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

	private void ListTriggers_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void method_7(object sender, DataGridViewCellEventArgs e)
	{
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count != 0)
		{
			EventTrigger theTrigger = Client.CurrentScenario.EventTriggers[Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value)];
			editTrigger_0 = new EditTrigger();
			editTrigger_0.theTrigger = theTrigger;
			editTrigger_0.Action = EditTrigger._FormAction.EditExisting;
			((Control)editTrigger_0).Show();
		}
	}

	public void ShowEditTrigger(EventTrigger theTr)
	{
		editTrigger_0 = new EditTrigger();
		editTrigger_0.theTrigger = theTr;
		editTrigger_0.Action = EditTrigger._FormAction.EditExisting;
		((Control)editTrigger_0).Show();
	}

	static ListTriggers()
	{
		Class72.smethod_20();
	}
}
