using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Collections.Pooled;
using Command_Core;
using Command_Core.DAL;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AddWeaponRecord : DarkSecondaryFormBase
{
	[CompilerGenerated]
	internal sealed class _Closure$__47-0
	{
		public DataView $VB$Local_DV;

		public AddWeaponRecord $VB$Me;

		public _Closure$__47-0(_Closure$__47-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_DV = arg0.$VB$Local_DV;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			((DataGridView)$VB$Me.DataGridView1).AutoGenerateColumns = false;
			((DataGridView)$VB$Me.DataGridView1).DataSource = $VB$Local_DV;
			((Control)$VB$Me.DataGridView1).Refresh();
		}

		static _Closure$__47-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("DataGridView1")]
	[CompilerGenerated]
	private DarkDataGridView _DataGridView1;

	[CompilerGenerated]
	[AccessedThroughProperty("BW1")]
	private BackgroundWorker backgroundWorker_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AddSelected")]
	private DarkUIButton _Button_AddSelected;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Find")]
	private DarkUITextBox _TB_Find;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Filter2")]
	private DarkCheckBox _CB_Filter2;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Add10K")]
	private DarkUIButton _Button_Add10K;

	private DataTable dataTable_0;

	private DataView dataView_0;

	private bool bool_2;

	public Form FormThatCalledMe;

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
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_14);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(method_15);
			DarkDataGridView darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellDoubleClick -= val;
				((DataGridView)darkDataGridView).CellContentClick -= val2;
			}
			_DataGridView1 = value;
			darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellDoubleClick += val;
				((DataGridView)darkDataGridView).CellContentClick += val2;
			}
		}
	}

	internal virtual BackgroundWorker BW1
	{
		[CompilerGenerated]
		get
		{
			return backgroundWorker_0;
		}
		[CompilerGenerated]
		set
		{
			backgroundWorker_0 = value;
		}
	}

	internal virtual DarkUIButton Button_AddSelected
	{
		[CompilerGenerated]
		get
		{
			return _Button_AddSelected;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button_AddSelected;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_AddSelected = value;
			darkUIButton = _Button_AddSelected;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUITextBox TB_Find
	{
		[CompilerGenerated]
		get
		{
			return _TB_Find;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_5;
			EventHandler eventHandler = method_11;
			EventHandler eventHandler2 = method_12;
			DarkUITextBox darkUITextBox = _TB_Find;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
				((Control)darkUITextBox).Enter -= eventHandler;
				((Control)darkUITextBox).Leave -= eventHandler2;
			}
			_TB_Find = value;
			darkUITextBox = _TB_Find;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
				((Control)darkUITextBox).Enter += eventHandler;
				((Control)darkUITextBox).Leave += eventHandler2;
			}
		}
	}

	internal virtual DarkCheckBox CB_Filter2
	{
		[CompilerGenerated]
		get
		{
			return _CB_Filter2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkCheckBox darkCheckBox = _CB_Filter2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_Filter2 = value;
			darkCheckBox = _CB_Filter2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_Add10K
	{
		[CompilerGenerated]
		get
		{
			return _Button_Add10K;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			DarkUIButton darkUIButton = _Button_Add10K;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Add10K = value;
			darkUIButton = _Button_Add10K;
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

	public AddWeaponRecord()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Shown += AddWeaponRecord_Shown;
		((Control)this).KeyDown += new KeyEventHandler(AddWeaponRecord_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(AddWeaponRecord_FormClosing);
		((Form)this).Load += AddWeaponRecord_Load;
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
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Expected O, but got Unknown
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Expected O, but got Unknown
		//IL_0605: Unknown result type (might be due to invalid IL or missing references)
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		BW1 = new BackgroundWorker();
		Button_AddSelected = new DarkUIButton();
		TB_Find = new DarkUITextBox();
		CB_Filter2 = new DarkCheckBox();
		Button_Add10K = new DarkUIButton();
		((ISupportInitialize)(object)DataGridView1).BeginInit();
		((Control)this).SuspendLayout();
		((DataGridView)DataGridView1).AllowUserToOrderColumns = true;
		((Control)DataGridView1).Anchor = (AnchorStyles)15;
		((DataGridView)DataGridView1).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DataGridView1).BorderStyle = (BorderStyle)2;
		((DataGridView)DataGridView1).CellBorderStyle = (DataGridViewCellBorderStyle)4;
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
		((DataGridView)DataGridView1).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[2]
		{
			(DataGridViewColumn)ID,
			(DataGridViewColumn)Description
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
		((Control)DataGridView1).Location = new Point(0, 93);
		((DataGridView)DataGridView1).MultiSelect = false;
		((Control)DataGridView1).Name = "DataGridView1";
		((DataGridView)DataGridView1).RowHeadersVisible = false;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DataGridView1).RowsDefaultCellStyle = val3;
		((DataGridView)DataGridView1).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DataGridView1).Size = new Size(331, 413);
		((Control)DataGridView1).TabIndex = 1;
		((DataGridViewColumn)ID).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		((DataGridViewColumn)ID).HeaderText = "ID";
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).ReadOnly = true;
		((DataGridViewColumn)ID).Width = 41;
		((DataGridViewColumn)Description).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Description).DataPropertyName = "Description";
		((DataGridViewColumn)Description).HeaderText = "Description - Click name of weapon to access DB VIewer";
		((DataGridViewColumn)Description).Name = "Description";
		((DataGridViewColumn)Description).ReadOnly = true;
		((ButtonBase)Button_AddSelected).BackColor = Color.Transparent;
		((Control)Button_AddSelected).Font = new Font("Segoe UI", 10f);
		((Control)Button_AddSelected).ForeColor = SystemColors.Control;
		((Control)Button_AddSelected).Location = new Point(7, 12);
		((Control)Button_AddSelected).Name = "Button_AddSelected";
		((Control)Button_AddSelected).Padding = new Padding(5);
		Button_AddSelected.RoundRadius = 0;
		((Control)Button_AddSelected).Size = new Size(89, 23);
		((Control)Button_AddSelected).TabIndex = 3;
		Button_AddSelected.Text = "Add Selected";
		((Control)TB_Find).Anchor = (AnchorStyles)13;
		TB_Find.AutoCompleteCustomSource = null;
		TB_Find.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Find.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Find).BackColor = Color.Transparent;
		TB_Find.Font = new Font("Segoe UI", 8f);
		((Control)TB_Find).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Find.Image = null;
		TB_Find.Lines = null;
		((Control)TB_Find).Location = new Point(7, 45);
		TB_Find.MaxLength = 32767;
		TB_Find.Multiline = false;
		((Control)TB_Find).Name = "TB_Find";
		TB_Find.ReadOnly = false;
		TB_Find.ScrollBars = (ScrollBars)0;
		TB_Find.SelectionStart = 0;
		((Control)TB_Find).Size = new Size(312, 20);
		((Control)TB_Find).TabIndex = 12;
		TB_Find.TextAlign = (HorizontalAlignment)0;
		TB_Find.UseSystemPasswordChar = false;
		TB_Find.WordWrap = false;
		TB_Find.WatermarkText = "Search Weapon Record... ";
		((Control)CB_Filter2).Location = new Point(7, 70);
		((Control)CB_Filter2).Name = "CB_Filter2";
		((Control)CB_Filter2).Size = new Size(340, 17);
		((Control)CB_Filter2).TabIndex = 14;
		((ButtonBase)CB_Filter2).Text = "Show only weapons compatible with aircraft hosted by parent";
		((ButtonBase)Button_Add10K).BackColor = Color.Transparent;
		((Control)Button_Add10K).Font = new Font("Segoe UI", 10f);
		((Control)Button_Add10K).ForeColor = SystemColors.Control;
		((Control)Button_Add10K).Location = new Point(121, 12);
		((Control)Button_Add10K).Name = "Button_Add10K";
		((Control)Button_Add10K).Padding = new Padding(5);
		Button_Add10K.RoundRadius = 0;
		((Control)Button_Add10K).Size = new Size(198, 23);
		((Control)Button_Add10K).TabIndex = 15;
		Button_Add10K.Text = "Add '10000' version of selected";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(331, 506);
		((Control)this).Controls.Add((Control)(object)Button_Add10K);
		((Control)this).Controls.Add((Control)(object)CB_Filter2);
		((Control)this).Controls.Add((Control)(object)TB_Find);
		((Control)this).Controls.Add((Control)(object)Button_AddSelected);
		((Control)this).Controls.Add((Control)(object)DataGridView1);
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "AddWeaponRecord";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Add Weapon Record";
		((ISupportInitialize)(object)DataGridView1).EndInit();
		((Control)this).ResumeLayout(false);
	}

	private void method_2(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_3()
	{
		if ((object)FormThatCalledMe == Client.theWeaponsWindow)
		{
			WeaponRec weaponRec = DBFunctions.GetWeaponRec(Conversions.ToInteger(((DataGridView)DataGridView1).CurrentRow.Cells["ID"].Value), Client.CurrentScenario);
			Client.theWeaponsWindow.AddWeaponRec(weaponRec);
		}
		if ((object)FormThatCalledMe == Client.theMagazinesWindow)
		{
			WeaponRec weaponRec2 = DBFunctions.GetWeaponRec(Conversions.ToInteger(((DataGridView)DataGridView1).CurrentRow.Cells["ID"].Value), Client.theMagazinesWindow.SelectedUnit.ParentScen);
			Client.theMagazinesWindow.SelectedMag.Weapons.Add(weaponRec2);
		}
	}

	private void method_4()
	{
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		dataTable_0 = DBFunctions.GetAllWeaponRecs_Preformatted(ref sqliteConnection_);
	}

	private void method_5(object object_0)
	{
		if (!((CheckBox)CB_Filter2).Checked)
		{
			if (Operators.CompareString(TB_Find.Text, "", true) == 0)
			{
				method_7();
			}
			else
			{
				method_6();
			}
		}
		else
		{
			method_9();
		}
	}

	private void method_6()
	{
		DataView dataView = new DataView(dataTable_0);
		dataView.Sort = "Description ASC";
		dataView.RowFilter = "Description LIKE '%" + Misc.EscapeLikeValue(TB_Find.Text) + "%'";
		((DataGridView)DataGridView1).AutoGenerateColumns = false;
		((DataGridView)DataGridView1).DataSource = dataView;
		((Control)DataGridView1).Refresh();
	}

	private void method_7()
	{
		if (dataTable_0 == null)
		{
			method_4();
		}
		((Control)this).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
		{
			dataView_0 = new DataView(dataTable_0);
			dataView_0.Sort = "Description ASC";
			((DataGridView)DataGridView1).DataSource = dataView_0;
		}));
	}

	private void method_8(object sender, EventArgs e)
	{
		if (((CheckBox)CB_Filter2).Checked)
		{
			method_9();
		}
		else
		{
			method_7();
		}
	}

	private void method_9()
	{
		_Closure$__47-0 arg = default(_Closure$__47-0);
		_Closure$__47-0 CS$<>8__locals10 = new _Closure$__47-0(arg);
		CS$<>8__locals10.$VB$Me = this;
		if (dataTable_0 == null)
		{
			method_4();
		}
		List<int> list = new List<int>();
		PooledList<Aircraft> pooledList = method_10();
		if (pooledList != null)
		{
			foreach (Aircraft item in pooledList)
			{
				int dBID = item.DBID;
				SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
				List<int> list2 = DBFunctions.WeaponsCarriedByThisAircraft(dBID, ref sqliteConnection_);
				foreach (int item2 in list2)
				{
					if (!list.Contains(item2))
					{
						list.Add(item2);
					}
				}
			}
			pooledList.Dispose();
		}
		CS$<>8__locals10.$VB$Local_DV = new DataView(dataTable_0);
		CS$<>8__locals10.$VB$Local_DV.Sort = "Description ASC";
		if (list.Count <= 0)
		{
			CS$<>8__locals10.$VB$Local_DV.RowFilter = "1=2";
		}
		else
		{
			string text = "(";
			foreach (int item3 in list)
			{
				text = text + Conversions.ToString(item3) + ",";
			}
			text = text.TrimEnd(new char[1] { ',' }) + ")";
			CS$<>8__locals10.$VB$Local_DV.RowFilter = "ComponentID IN " + text;
		}
		string text2 = TB_Find.Text.Trim();
		if (text2.Length > 0)
		{
			DataView dataView;
			(dataView = CS$<>8__locals10.$VB$Local_DV).RowFilter = dataView.RowFilter + " AND Description LIKE '%" + Misc.EscapeLikeValue(text2) + "%'";
		}
		((Control)this).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
		{
			((DataGridView)CS$<>8__locals10.$VB$Me.DataGridView1).AutoGenerateColumns = false;
			((DataGridView)CS$<>8__locals10.$VB$Me.DataGridView1).DataSource = CS$<>8__locals10.$VB$Local_DV;
			((Control)CS$<>8__locals10.$VB$Me.DataGridView1).Refresh();
		}));
	}

	private PooledList<Aircraft> method_10()
	{
		if ((object)FormThatCalledMe == Client.theMagazinesWindow)
		{
			ActiveUnit parentPlatform = Client.theMagazinesWindow.SelectedMag.ParentPlatform;
			if (!parentPlatform.IsGroupMember())
			{
				return parentPlatform.AirOps.EmbarkedAircraft_ReadOnly;
			}
			if (!parentPlatform.get_ParentGroup(UsingMissionPlanner: false).IsLandInstallation)
			{
				return parentPlatform.AirOps.EmbarkedAircraft_ReadOnly;
			}
			return parentPlatform.get_ParentGroup(UsingMissionPlanner: false).AirOps.EmbarkedAircraft_ReadOnly;
		}
		return null;
	}

	private void AddWeaponRecord_Shown(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)Client.theMagazinesWindow))
		{
			if ((object)FormThatCalledMe == Client.theMagazinesWindow)
			{
				PooledList<Aircraft> pooledList = method_10();
				((Control)CB_Filter2).Visible = pooledList != null && pooledList.Count > 0;
				pooledList?.Dispose();
			}
			else
			{
				((Control)CB_Filter2).Visible = false;
			}
		}
		else
		{
			((Control)CB_Filter2).Visible = false;
		}
		if (((Control)CB_Filter2).Visible)
		{
			((CheckBox)CB_Filter2).Checked = true;
			Task.Factory.StartNew(method_9);
		}
		else
		{
			Task.Factory.StartNew(method_7);
		}
	}

	private void AddWeaponRecord_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Invalid comparison between Unknown and I4
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and I4
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Invalid comparison between Unknown and I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Invalid comparison between Unknown and I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Invalid comparison between Unknown and I4
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Invalid comparison between Unknown and I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
			return;
		}
		if (bool_2 && ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
		if (!bool_2 && (e.KeyValue != 32 || !((Control)this).Visible))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		bool_2 = true;
	}

	private void method_12(object sender, EventArgs e)
	{
		bool_2 = false;
	}

	private void AddWeaponRecord_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_13(object sender, EventArgs e)
	{
		if ((object)FormThatCalledMe == Client.theWeaponsWindow)
		{
			WeaponRec weaponRec = DBFunctions.GetWeaponRec(Conversions.ToInteger(((DataGridView)DataGridView1).CurrentRow.Cells["ID"].Value), Client.CurrentScenario);
			weaponRec.WRecDBID = null;
			weaponRec.CurrentLoad = 10000;
			weaponRec.MaxLoad = 10000;
			Client.theWeaponsWindow.AddWeaponRec(weaponRec);
		}
		if ((object)FormThatCalledMe == Client.theMagazinesWindow)
		{
			WeaponRec weaponRec2 = DBFunctions.GetWeaponRec(Conversions.ToInteger(((DataGridView)DataGridView1).CurrentRow.Cells["ID"].Value), Client.theMagazinesWindow.SelectedUnit.ParentScen);
			weaponRec2.WRecDBID = null;
			weaponRec2.MaxLoad = 10000;
			Client.theMagazinesWindow.SelectedMag.Weapons.Add(weaponRec2);
		}
	}

	private void AddWeaponRecord_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		((DataGridView)DataGridView1).AutoGenerateColumns = false;
	}

	private void method_14(object sender, DataGridViewCellEventArgs e)
	{
		method_3();
	}

	private void method_15(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex == -1 || ((DataGridView)DataGridView1).Rows.Count == 0)
			{
				return;
			}
			_ = ((DataGridView)DataGridView1).Columns[e.ColumnIndex];
			DataGridViewRow val = ((DataGridView)DataGridView1).Rows[e.RowIndex];
			if (e.ColumnIndex == 1)
			{
				WeaponRec weaponRec = DBFunctions.GetWeaponRec(Conversions.ToInteger(val.Cells[0].Value), Client.CurrentScenario);
				if (weaponRec.int_3 > 0)
				{
					Client.smethod_17("Weapon", weaponRec.int_3);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200109", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static AddWeaponRecord()
	{
		Class72.smethod_20();
	}
}
