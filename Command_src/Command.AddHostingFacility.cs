using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.DAL;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AddHostingFacility : DarkSecondaryFormBase
{
	public enum _EditHostingMode
	{
		AirFacs,
		BoatFacs
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AddSelected")]
	private DarkUIButton _Button_AddSelected;

	[CompilerGenerated]
	[AccessedThroughProperty("BackgroundThread")]
	private BackgroundWorker backgroundWorker_0;

	private DataTable dataTable_0;

	private DataView dataView_0;

	private bool bool_2;

	public int Mode;

	public Form ParentForm;

	public ActiveUnit theSelectedUnit;

	[field: AccessedThroughProperty("LV_Facs")]
	internal virtual DarkListView LV_Facs { get; set; }

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
			EventHandler eventHandler = [SpecialName] (object sender, EventArgs e) =>
			{
				method_5();
			};
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

	[field: AccessedThroughProperty("Label_Unit")]
	internal virtual DarkLabel Label_Unit { get; set; }

	internal virtual BackgroundWorker BackgroundThread
	{
		[CompilerGenerated]
		get
		{
			return backgroundWorker_0;
		}
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = method_2;
			RunWorkerCompletedEventHandler value3 = method_3;
			BackgroundWorker backgroundWorker = backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
				backgroundWorker.RunWorkerCompleted -= value3;
			}
			backgroundWorker_0 = value;
			backgroundWorker = backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
				backgroundWorker.RunWorkerCompleted += value3;
			}
		}
	}

	public AddHostingFacility()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += AddHostingFacility_Load;
		((Form)this).FormClosing += new FormClosingEventHandler(AddHostingFacility_FormClosing);
		((Control)this).KeyDown += new KeyEventHandler(AddHostingFacility_KeyDown);
		bool_2 = false;
		Mode = 0;
		ParentForm = null;
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
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		BackgroundThread = new BackgroundWorker();
		LV_Facs = new DarkListView();
		Button_AddSelected = new DarkUIButton();
		Label_Unit = new DarkLabel();
		((Control)this).SuspendLayout();
		((Control)LV_Facs).Anchor = (AnchorStyles)15;
		((Control)LV_Facs).Location = new Point(0, 28);
		((Control)LV_Facs).Name = "LV_Facs";
		LV_Facs.RelatedInfos = null;
		((Control)LV_Facs).Size = new Size(400, 394);
		((Control)LV_Facs).TabIndex = 23;
		((ButtonBase)Button_AddSelected).BackColor = Color.Transparent;
		((Button)Button_AddSelected).DialogResult = (DialogResult)0;
		((Control)Button_AddSelected).Dock = (DockStyle)2;
		((Control)Button_AddSelected).Font = new Font("Segoe UI", 10f);
		((Control)Button_AddSelected).ForeColor = SystemColors.Control;
		((Control)Button_AddSelected).Location = new Point(0, 422);
		((Control)Button_AddSelected).Name = "Button_AddSelected";
		Button_AddSelected.RoundRadius = 0;
		((Control)Button_AddSelected).Size = new Size(400, 24);
		((Control)Button_AddSelected).TabIndex = 3;
		Button_AddSelected.Text = "Add Selected";
		((Control)Label_Unit).Font = new Font("Segoe UI", 10f, (FontStyle)1);
		((Control)Label_Unit).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Unit).Location = new Point(0, 4);
		((Control)Label_Unit).Name = "Label_Unit";
		((Control)Label_Unit).Size = new Size(503, 16);
		((Control)Label_Unit).TabIndex = 19;
		((Label)Label_Unit).Text = "Adding Facilities for: <Unit>";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(400, 446);
		((Control)this).Controls.Add((Control)(object)Label_Unit);
		((Control)this).Controls.Add((Control)(object)Button_AddSelected);
		((Control)this).Controls.Add((Control)(object)LV_Facs);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "AddHostingFacility";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Add Hosting Facility";
		((Control)this).ResumeLayout(false);
	}

	private void AddHostingFacility_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		BackgroundThread.RunWorkerAsync();
		switch (Mode)
		{
		case 0:
			((Label)Label_Unit).Text = "Add air facilities for: ";
			break;
		case 1:
			((Label)Label_Unit).Text = "Add docking facilities for: ";
			break;
		}
		((Label)Label_Unit).Text = ((Label)Label_Unit).Text + theSelectedUnit.Name;
	}

	private void AddHostingFacility_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
		if (ParentForm != null)
		{
			((Control)ParentForm).BringToFront();
		}
		theSelectedUnit = null;
	}

	private void method_2(object sender, DoWorkEventArgs e)
	{
		switch (Mode)
		{
		case 0:
			dataTable_0 = DBFunctions.GetAllAirFacilities(Client.CurrentScenario.DBConnection);
			break;
		case 1:
			dataTable_0 = DBFunctions.GetAllDockFacilities(Client.CurrentScenario.DBConnection);
			break;
		}
	}

	private void method_3(object sender, RunWorkerCompletedEventArgs e)
	{
		method_4();
	}

	private void method_4()
	{
		int num = 0;
		int num2 = 0;
		AirFacility airFacility = null;
		DockFacility dockFacility = null;
		DarkListItem darkListItem = null;
		try
		{
			LV_Facs.Items.Clear();
			dataView_0 = new DataView(dataTable_0);
			switch (Mode)
			{
			case 1:
				dataView_0.Sort = "Type, PhysicalSize, Capacity";
				break;
			case 0:
				dataView_0.Sort = "Type, PhysicalSize, Capacity, RunwayLength";
				break;
			}
			int num3 = dataView_0.Count - 1;
			for (num = 0; num <= num3; num++)
			{
				num2 = Conversions.ToInteger(dataView_0[num].Row["ID"]);
				switch (Mode)
				{
				case 1:
				{
					int facilityDBID2 = num2;
					SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
					dockFacility = DBFunctions.GetDockFacility(facilityDBID2, ref sqliteConnection_);
					if (dockFacility != null)
					{
						darkListItem = new DarkListItem(dockFacility.Name);
						darkListItem.Tag = num2;
						LV_Facs.Items.Add(darkListItem);
					}
					break;
				}
				case 0:
				{
					int facilityDBID = num2;
					SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
					airFacility = DBFunctions.GetAirFacility(facilityDBID, ref sqliteConnection_);
					if (airFacility != null)
					{
						if (airFacility.AirFacType == AirFacility._AirFacType.Runway || airFacility.AirFacType == AirFacility._AirFacType.RunwayGrade_Taxiway)
						{
							airFacility.Name = airFacility.Name + " " + airFacility.RunwayString;
						}
						darkListItem = new DarkListItem(airFacility.Name);
						darkListItem.Tag = num2;
						LV_Facs.Items.Add(darkListItem);
					}
					break;
				}
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void AddHostingFacility_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
	}

	private void method_5()
	{
		try
		{
			if (theSelectedUnit == null)
			{
				return;
			}
			List<DarkListItem> selectedItems = LV_Facs.SelectedItems;
			if (selectedItems.Count <= 0)
			{
				return;
			}
			switch (Mode)
			{
			case 0:
			{
				AirFacility airFacility = null;
				int num2 = selectedItems.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					int facilityDBID2 = Conversions.ToInteger(selectedItems[j].Tag);
					SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
					airFacility = DBFunctions.GetAirFacility(facilityDBID2, ref sqliteConnection_, theSelectedUnit);
					if (airFacility != null)
					{
						theSelectedUnit.AddAirFacility(airFacility);
					}
				}
				break;
			}
			case 1:
			{
				DockFacility dockFacility = null;
				int num = selectedItems.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int facilityDBID = Conversions.ToInteger(selectedItems[i].Tag);
					SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
					dockFacility = DBFunctions.GetDockFacility(facilityDBID, ref sqliteConnection_, theSelectedUnit);
					if (dockFacility != null)
					{
						theSelectedUnit.AddDockFacility(dockFacility);
					}
				}
				break;
			}
			}
			if (Client.CurrentGame.Status == Game._GameStatus.Paused)
			{
				MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, v: false);
			}
			if (ParentForm != null)
			{
				if ((object)ParentForm == MyProject.Forms.m_AirOps && ((Control)MyProject.Forms.AirOps).Visible)
				{
					MyProject.Forms.AirOps.RefreshForm();
					Module1.ExpandAll(MyProject.Forms.AirOps.TV_Facilities);
				}
				else if ((object)ParentForm == MyProject.Forms.m_DockingOps && ((Control)MyProject.Forms.DockingOps).Visible)
				{
					MyProject.Forms.DockingOps.RefreshForm();
					Module1.ExpandAll(MyProject.Forms.DockingOps.TV_Facilities);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	static AddHostingFacility()
	{
		Class72.smethod_20();
	}
}
