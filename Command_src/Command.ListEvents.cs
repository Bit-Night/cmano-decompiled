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
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ListEvents : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridView1")]
	private DarkDataGridView _DataGridView1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditSelected")]
	private DarkUIButton _Button_EditSelected;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_DeleteSelected")]
	private DarkUIButton _Button_DeleteSelected;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_CloneSelected")]
	private DarkUIButton _Button_CloneSelected;

	private EditEvent editEvent_0;

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
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			EventHandler eventHandler = method_6;
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_7);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(method_8);
			DarkDataGridView darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
				((DataGridView)darkDataGridView).CellContentClick -= val;
				((DataGridView)darkDataGridView).CellContentDoubleClick -= val2;
			}
			_DataGridView1 = value;
			darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
				((DataGridView)darkDataGridView).CellContentClick += val;
				((DataGridView)darkDataGridView).CellContentDoubleClick += val2;
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

	[field: AccessedThroughProperty("ID")]
	internal virtual DataGridViewTextBoxColumn ID { get; set; }

	[field: AccessedThroughProperty("Description")]
	internal virtual DataGridViewTextBoxColumn Description { get; set; }

	[field: AccessedThroughProperty("IsRepeatable")]
	internal virtual DataGridViewCheckBoxColumn IsRepeatable { get; set; }

	[field: AccessedThroughProperty("IsActive")]
	internal virtual DataGridViewCheckBoxColumn IsActive { get; set; }

	[field: AccessedThroughProperty("Probability")]
	internal virtual DataGridViewTextBoxColumn Probability { get; set; }

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

	public ListEvents()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Shown += ListEvents_Shown;
		((Control)this).KeyDown += new KeyEventHandler(ListEvents_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(ListEvents_FormClosing);
		((Form)this).Load += ListEvents_Load;
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
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected O, but got Unknown
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0585: Expected O, but got Unknown
		//IL_063f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0649: Expected O, but got Unknown
		//IL_0703: Unknown result type (might be due to invalid IL or missing references)
		//IL_070d: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		IsRepeatable = new DataGridViewCheckBoxColumn();
		IsActive = new DataGridViewCheckBoxColumn();
		Probability = new DataGridViewTextBoxColumn();
		Button_EditSelected = new DarkUIButton();
		Button_DeleteSelected = new DarkUIButton();
		Button1 = new DarkUIButton();
		Button_CloneSelected = new DarkUIButton();
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
		((DataGridView)DataGridView1).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[5]
		{
			(DataGridViewColumn)ID,
			(DataGridViewColumn)Description,
			(DataGridViewColumn)IsRepeatable,
			(DataGridViewColumn)IsActive,
			(DataGridViewColumn)Probability
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
		((Control)DataGridView1).Location = new Point(2, 2);
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
		((Control)DataGridView1).Size = new Size(678, 361);
		((Control)DataGridView1).TabIndex = 1;
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		((DataGridViewColumn)ID).HeaderText = "ID";
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).ReadOnly = true;
		((DataGridViewColumn)ID).Visible = false;
		((DataGridViewColumn)Description).DataPropertyName = "Description";
		((DataGridViewColumn)Description).HeaderText = "Description";
		((DataGridViewColumn)Description).Name = "Description";
		((DataGridViewColumn)Description).ReadOnly = true;
		((DataGridViewColumn)Description).Width = 335;
		((DataGridViewColumn)IsRepeatable).DataPropertyName = "IsRepeatable";
		((DataGridViewColumn)IsRepeatable).HeaderText = "Is Repeatable";
		((DataGridViewColumn)IsRepeatable).Name = "IsRepeatable";
		((DataGridViewColumn)IsRepeatable).ReadOnly = true;
		((DataGridViewColumn)IsActive).DataPropertyName = "IsActive";
		((DataGridViewColumn)IsActive).HeaderText = "Is Active";
		((DataGridViewColumn)IsActive).Name = "IsActive";
		((DataGridViewColumn)IsActive).ReadOnly = true;
		((DataGridViewColumn)Probability).DataPropertyName = "Probability";
		((DataGridViewColumn)Probability).HeaderText = "Probability (%)";
		((DataGridViewColumn)Probability).Name = "Probability";
		((DataGridViewColumn)Probability).ReadOnly = true;
		((Control)Button_EditSelected).Anchor = (AnchorStyles)10;
		((ButtonBase)Button_EditSelected).BackColor = Color.Transparent;
		((Button)Button_EditSelected).DialogResult = (DialogResult)0;
		((Control)Button_EditSelected).Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_EditSelected).ForeColor = SystemColors.Control;
		((Control)Button_EditSelected).Location = new Point(432, 369);
		((Control)Button_EditSelected).Name = "Button_EditSelected";
		Button_EditSelected.RoundRadius = 0;
		((Control)Button_EditSelected).Size = new Size(121, 21);
		((Control)Button_EditSelected).TabIndex = 7;
		Button_EditSelected.Text = "Edit selected";
		((Control)Button_DeleteSelected).Anchor = (AnchorStyles)10;
		((ButtonBase)Button_DeleteSelected).BackColor = Color.Transparent;
		((Button)Button_DeleteSelected).DialogResult = (DialogResult)0;
		((Control)Button_DeleteSelected).Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_DeleteSelected).ForeColor = SystemColors.Control;
		((Control)Button_DeleteSelected).Location = new Point(559, 369);
		((Control)Button_DeleteSelected).Name = "Button_DeleteSelected";
		Button_DeleteSelected.RoundRadius = 0;
		((Control)Button_DeleteSelected).Size = new Size(121, 21);
		((Control)Button_DeleteSelected).TabIndex = 6;
		Button_DeleteSelected.Text = "Delete selected";
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(2, 369);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(133, 21);
		((Control)Button1).TabIndex = 5;
		Button1.Text = "Create new event";
		((Control)Button_CloneSelected).Anchor = (AnchorStyles)10;
		((ButtonBase)Button_CloneSelected).BackColor = Color.Transparent;
		((Button)Button_CloneSelected).DialogResult = (DialogResult)0;
		((Control)Button_CloneSelected).Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_CloneSelected).ForeColor = SystemColors.Control;
		((Control)Button_CloneSelected).Location = new Point(305, 369);
		((Control)Button_CloneSelected).Name = "Button_CloneSelected";
		Button_CloneSelected.RoundRadius = 0;
		((Control)Button_CloneSelected).Size = new Size(121, 21);
		((Control)Button_CloneSelected).TabIndex = 8;
		Button_CloneSelected.Text = "Clone selected";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(682, 392);
		((Control)this).Controls.Add((Control)(object)Button_CloneSelected);
		((Control)this).Controls.Add((Control)(object)Button_EditSelected);
		((Control)this).Controls.Add((Control)(object)Button_DeleteSelected);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)DataGridView1);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "ListEvents";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Events";
		((ISupportInitialize)(object)DataGridView1).EndInit();
		((Control)this).ResumeLayout(false);
	}

	public void RefreshGrid(int rowIndex = 0)
	{
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Expected O, but got Unknown
		try
		{
			bool_2 = true;
			((Control)DataGridView1).SuspendLayout();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(string));
			dataTable.Columns.Add("Description", typeof(string));
			dataTable.Columns.Add("IsRepeatable", typeof(bool));
			dataTable.Columns.Add("IsActive", typeof(bool));
			dataTable.Columns.Add("IsShown", typeof(bool));
			dataTable.Columns.Add("Probability", typeof(short));
			foreach (SimEvent item in Client.CurrentScenario.SimEvents.Values.OrderBy([SpecialName] (SimEvent theEvent) => theEvent.Description))
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["ID"] = item.ObjectID;
				dataRow["Description"] = item.Description;
				dataRow["IsRepeatable"] = item.IsRepeatable;
				dataRow["IsActive"] = item.IsActive;
				dataRow["IsShown"] = item.IsShown;
				dataRow["Probability"] = item.Probability;
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
			ex2?.Data.Add("Error at 200102", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			RefreshGrid();
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		try
		{
			SimEvent theEvent = new SimEvent();
			editEvent_0 = new EditEvent();
			editEvent_0.theEvent = theEvent;
			editEvent_0.Action = EditEvent._FormAction.AddNew;
			((Control)editEvent_0).Show();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			RefreshGrid();
			ProjectData.ClearProjectError();
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		try
		{
			if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count != 0)
			{
				SimEvent theEvent = Client.CurrentScenario.SimEvents[Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value)];
				editEvent_0 = new EditEvent();
				editEvent_0.theEvent = theEvent;
				editEvent_0.Action = EditEvent._FormAction.EditExisting;
				((Control)editEvent_0).Show();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			RefreshGrid();
			ProjectData.ClearProjectError();
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		try
		{
			if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count == 0)
			{
				return;
			}
			SimEvent value = Client.CurrentScenario.SimEvents[Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value)];
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
			Client.CurrentScenario.SimEvents.TryRemove(value.ObjectID, out value);
			RefreshGrid(rowIndex);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			RefreshGrid();
			ProjectData.ClearProjectError();
		}
	}

	private void ListEvents_Shown(object sender, EventArgs e)
	{
		RefreshGrid();
	}

	private void ListEvents_KeyDown(object sender, KeyEventArgs e)
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

	private void ListEvents_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_5(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count != 0)
		{
			SimEvent simEvent = Client.CurrentScenario.SimEvents[Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value)].Clone();
			Client.CurrentScenario.SimEvents.TryAdd(simEvent.ObjectID, simEvent);
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

	private void ListEvents_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void method_7(object sender, DataGridViewCellEventArgs e)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		try
		{
			if (e.RowIndex == -1)
			{
				return;
			}
			DataGridViewColumn val = ((DataGridView)DataGridView1).Columns[e.ColumnIndex];
			if ((object)val.CellType == typeof(DataGridViewCheckBoxCell))
			{
				DataGridViewCheckBoxCell val2 = (DataGridViewCheckBoxCell)((DataGridView)DataGridView1).Rows[e.RowIndex].Cells[e.ColumnIndex];
				string key = Conversions.ToString(((DataGridView)DataGridView1).Rows[e.RowIndex].Cells["ID"].Value);
				SimEvent simEvent = Client.CurrentScenario.SimEvents[key];
				((DataGridViewCell)val2).Value = Operators.NotObject(((DataGridViewCell)val2).Value);
				string name = val.Name;
				if (Operators.CompareString(name, "IsRepeatable", true) == 0)
				{
					simEvent.IsRepeatable = Conversions.ToBoolean(((DataGridViewCell)val2).Value);
				}
				else if (Operators.CompareString(name, "IsActive", true) == 0)
				{
					simEvent.IsActive = Conversions.ToBoolean(((DataGridViewCell)val2).Value);
				}
				else if (Operators.CompareString(name, "IsShown", true) == 0)
				{
					simEvent.IsShown = Conversions.ToBoolean(((DataGridViewCell)val2).Value);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			RefreshGrid();
			ProjectData.ClearProjectError();
		}
	}

	private void method_8(object sender, DataGridViewCellEventArgs e)
	{
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count != 0)
		{
			SimEvent theEvent = Client.CurrentScenario.SimEvents[Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value)];
			editEvent_0 = new EditEvent();
			editEvent_0.theEvent = theEvent;
			editEvent_0.Action = EditEvent._FormAction.EditExisting;
			((Control)editEvent_0).Show();
		}
	}

	static ListEvents()
	{
		Class72.smethod_20();
	}
}
