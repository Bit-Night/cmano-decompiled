using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Command_Core;
using Command_Core.DAL;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ContactReport : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("LB_Matches")]
	private DarkListView _LB_Matches;

	[AccessedThroughProperty("TabControl1")]
	[CompilerGenerated]
	private DarkUITabControl _TabControl1;

	[CompilerGenerated]
	private bool bool_2;

	public Contact theContact;

	private GlobalVariables.ActiveUnitType TargetType;

	[field: AccessedThroughProperty("Label_UnitType")]
	internal virtual DarkLabel Label_UnitType { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("LB_Emissions")]
	internal virtual DarkListView LB_Emissions { get; set; }

	internal virtual DarkListView LB_Matches
	{
		[CompilerGenerated]
		get
		{
			return _LB_Matches;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkListView darkListView = _LB_Matches;
			if (darkListView != null)
			{
				((Control)darkListView).DoubleClick -= eventHandler;
			}
			_LB_Matches = value;
			darkListView = _LB_Matches;
			if (darkListView != null)
			{
				((Control)darkListView).DoubleClick += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	internal virtual DarkUITabControl TabControl1
	{
		[CompilerGenerated]
		get
		{
			return _TabControl1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUITabControl darkUITabControl = _TabControl1;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged -= eventHandler;
			}
			_TabControl1 = value;
			darkUITabControl = _TabControl1;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

	[field: AccessedThroughProperty("Label_HostedUnits")]
	internal virtual DarkLabel Label_HostedUnits { get; set; }

	[field: AccessedThroughProperty("SplitContainer1")]
	internal virtual SplitContainer SplitContainer1 { get; set; }

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

	public ContactReport()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Shown += ContactReport_Shown;
		((Control)this).KeyDown += new KeyEventHandler(ContactReport_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(ContactReport_FormClosing);
		((Form)this).Load += ContactReport_Load;
		RTMPEnabled = true;
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
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_0410: Unknown result type (might be due to invalid IL or missing references)
		//IL_0597: Unknown result type (might be due to invalid IL or missing references)
		Label_UnitType = new DarkLabel();
		Label1 = new DarkLabel();
		Label3 = new DarkLabel();
		LB_Emissions = new DarkListView();
		LB_Matches = new DarkListView();
		Label2 = new DarkLabel();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		SplitContainer1 = new SplitContainer();
		TabPage2 = new TabPage();
		Label_HostedUnits = new DarkLabel();
		((Control)TabControl1).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((ISupportInitialize)SplitContainer1).BeginInit();
		((Control)SplitContainer1.Panel1).SuspendLayout();
		((Control)SplitContainer1.Panel2).SuspendLayout();
		((Control)SplitContainer1).SuspendLayout();
		((Control)TabPage2).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)Label_UnitType).Location = new Point(2, 9);
		((Control)Label_UnitType).Name = "Label_UnitType";
		((Control)Label_UnitType).Size = new Size(52, 13);
		((Control)Label_UnitType).TabIndex = 0;
		((Label)Label_UnitType).Text = "Unit type:";
		((Control)Label1).Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label1).Location = new Point(3, 0);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(121, 13);
		((Control)Label1).TabIndex = 3;
		((Label)Label1).Text = "Detected emissions:";
		((Control)Label3).Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label3).Location = new Point(3, -1);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(112, 13);
		((Control)Label3).TabIndex = 4;
		((Label)Label3).Text = "Potential matches:";
		((Control)LB_Emissions).Anchor = (AnchorStyles)15;
		((Control)LB_Emissions).Location = new Point(6, 16);
		((Control)LB_Emissions).Name = "LB_Emissions";
		((Control)LB_Emissions).Size = new Size(606, 147);
		((Control)LB_Emissions).TabIndex = 5;
		((Control)LB_Matches).Anchor = (AnchorStyles)15;
		((Control)LB_Matches).Location = new Point(3, 17);
		((Control)LB_Matches).Name = "LB_Matches";
		((Control)LB_Matches).Size = new Size(609, 199);
		((Control)LB_Matches).TabIndex = 6;
		((Control)Label2).Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)2, (GraphicsUnit)3, (byte)0);
		((Control)Label2).Location = new Point(121, -1);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(123, 13);
		((Control)Label2).TabIndex = 7;
		((Label)Label2).Text = "(double click for DB info)";
		((Control)TabControl1).Anchor = (AnchorStyles)15;
		((Control)TabControl1).Controls.Add((Control)(object)TabPage1);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage2);
		((Control)TabControl1).Location = new Point(5, 36);
		((Control)TabControl1).Name = "TabControl1";
		((TabControl)TabControl1).SelectedIndex = 0;
		((Control)TabControl1).Size = new Size(630, 435);
		((Control)TabControl1).TabIndex = 8;
		TabPage1.BackColor = SystemColors.Control;
		((Control)TabPage1).Controls.Add((Control)(object)SplitContainer1);
		TabPage1.Location = new Point(4, 22);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(622, 409);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Emissions";
		SplitContainer1.Dock = (DockStyle)5;
		((Control)SplitContainer1).Location = new Point(3, 3);
		((Control)SplitContainer1).Name = "SplitContainer1";
		SplitContainer1.Orientation = (Orientation)0;
		((Control)SplitContainer1.Panel1).Controls.Add((Control)(object)Label1);
		((Control)SplitContainer1.Panel1).Controls.Add((Control)(object)LB_Emissions);
		((Control)SplitContainer1.Panel2).Controls.Add((Control)(object)Label2);
		((Control)SplitContainer1.Panel2).Controls.Add((Control)(object)LB_Matches);
		((Control)SplitContainer1.Panel2).Controls.Add((Control)(object)Label3);
		((Control)SplitContainer1).Size = new Size(616, 403);
		SplitContainer1.SplitterDistance = 173;
		((Control)SplitContainer1).TabIndex = 8;
		TabPage2.BackColor = SystemColors.Control;
		((Control)TabPage2).Controls.Add((Control)(object)Label_HostedUnits);
		TabPage2.Location = new Point(4, 22);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Padding = new Padding(3);
		((Control)TabPage2).Size = new Size(622, 409);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Spotted hosted units";
		Label_HostedUnits.AutoSize = true;
		((Control)Label_HostedUnits).Location = new Point(6, 3);
		((Control)Label_HostedUnits).Name = "Label_HostedUnits";
		((Control)Label_HostedUnits).Size = new Size(97, 13);
		((Control)Label_HostedUnits).TabIndex = 0;
		((Label)Label_HostedUnits).Text = "Label_HostedUnits";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(636, 475);
		((Control)this).Controls.Add((Control)(object)TabControl1);
		((Control)this).Controls.Add((Control)(object)Label_UnitType);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "ContactReport";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Contact Report";
		((Control)TabControl1).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)SplitContainer1.Panel1).ResumeLayout(false);
		((Control)SplitContainer1.Panel1).PerformLayout();
		((Control)SplitContainer1.Panel2).ResumeLayout(false);
		((Control)SplitContainer1.Panel2).PerformLayout();
		((ISupportInitialize)SplitContainer1).EndInit();
		((Control)SplitContainer1).ResumeLayout(false);
		((Control)TabPage2).ResumeLayout(false);
		((Control)TabPage2).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void method_2(object sender, EventArgs e)
	{
		string selectedObjectType = Misc.ActiveUnitType_Description(TargetType);
		int selectedObjectID = Conversions.ToInteger(LB_Matches.SelectedItems[0].Tag);
		Client.smethod_17(selectedObjectType, selectedObjectID);
	}

	private void method_3()
	{
		((Form)this).Text = "Contact Report: " + theContact.Name;
		if (theContact.ActualUnit != null)
		{
			string text = "";
			if (theContact.ActualUnit.IsDecoy)
			{
				text = "[DECOY] ";
			}
			switch (theContact.IDStatus)
			{
			case Contact_Base.IdentificationStatus.Unknown:
			case Contact_Base.IdentificationStatus.KnownDomain:
				((Label)Label_UnitType).Text = "Type: Unknown";
				break;
			case Contact_Base.IdentificationStatus.KnownType:
				((Label)Label_UnitType).Text = "Type: " + theContact.ActualUnit.SubTypeDescription;
				break;
			case Contact_Base.IdentificationStatus.KnownClass:
				((Label)Label_UnitType).Text = text + "Class: " + theContact.ActualUnit.UnitClass;
				break;
			case Contact_Base.IdentificationStatus.PreciseID:
				((Label)Label_UnitType).Text = text + "Identified: " + theContact.ActualUnit.Name;
				break;
			}
		}
		LB_Emissions.Items.Clear();
		LB_Matches.Items.Clear();
		string text2 = "";
		EmissionContainer emissionContainer = null;
		if (!theContact.HasDetectedEmissions)
		{
			((Control)LB_Emissions).Enabled = false;
			((Label)Label1).Text = "No detected emissions";
			return;
		}
		List<int> list = theContact.DetectedEmissions.Keys.ToList();
		int num = default(int);
		if (theContact.DetectedEmissions.Count == 0)
		{
			((Control)LB_Emissions).Enabled = false;
			((Label)Label1).Text = "No detected emissions";
		}
		else
		{
			((Control)LB_Emissions).Enabled = true;
			foreach (int item in list)
			{
				emissionContainer = theContact.DetectedEmissions[item];
				text2 = emissionContainer.get_ID_Description(item, Client.CurrentScenario);
				LB_Emissions.Items.Add(new DarkListItem(text2 + " (Last: " + Misc.TimeString((long)Math.Round(emissionContainer.Age), 0, ReturnNo: false, ReturnZero: true) + " ago)"));
				if (emissionContainer.PreciseID)
				{
					num++;
				}
			}
			((Label)Label1).Text = "Detected emissions (" + Conversions.ToString(num) + " emitters identified):";
		}
		if (num != 0)
		{
			((Label)Label3).Text = "Possible matches:";
			DataTable table = null;
			switch (theContact.Type)
			{
			case Contact_Base.ContactType.Air:
				TargetType = GlobalVariables.ActiveUnitType.Aircraft;
				table = DBFunctions.GetAllAircraft(Client.CurrentScenario.DBConnection, IncludeDeprecated: true);
				break;
			case Contact_Base.ContactType.Surface:
				TargetType = GlobalVariables.ActiveUnitType.Ship;
				table = DBFunctions.GetAllShips(Client.CurrentScenario.DBConnection, IncludeDeprecated: true);
				break;
			case Contact_Base.ContactType.Submarine:
				TargetType = GlobalVariables.ActiveUnitType.Submarine;
				table = DBFunctions.GetAllSubmarines(Client.CurrentScenario.DBConnection, IncludeDeprecated: true);
				break;
			case Contact_Base.ContactType.Orbital:
				TargetType = GlobalVariables.ActiveUnitType.Satellite;
				table = DBFunctions.GetAllSatellites(Client.CurrentScenario.DBConnection);
				break;
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
				TargetType = GlobalVariables.ActiveUnitType.Facility;
				table = DBFunctions.GetAllFacilities(Client.CurrentScenario.DBConnection, IncludeDeprecated: true);
				break;
			case Contact_Base.ContactType.Missile:
			case Contact_Base.ContactType.Torpedo:
				TargetType = GlobalVariables.ActiveUnitType.Weapon;
				table = DBFunctions.GetAllWeapons(Client.CurrentScenario.DBConnection);
				break;
			}
			List<int> possibleMatchesBasedOnEmissions = theContact.PossibleMatchesBasedOnEmissions;
			if (possibleMatchesBasedOnEmissions.Count > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				_ = possibleMatchesBasedOnEmissions.Count;
				stringBuilder.Append("(" + string.Join(",", possibleMatchesBasedOnEmissions) + ")");
				DataView dataView = new DataView(table);
				dataView.RowFilter = "ID IN " + stringBuilder.ToString();
				dataView.Sort = "LongName ASC";
				((Control)LB_Matches).Enabled = true;
				foreach (DataRowView item2 in dataView)
				{
					DataRow row = item2.Row;
					DarkListItem darkListItem = new DarkListItem(Conversions.ToString(row["LongName"]));
					darkListItem.Tag = RuntimeHelpers.GetObjectValue(row["ID"]);
					LB_Matches.Items.Add(darkListItem);
				}
				((Control)LB_Matches).Refresh();
			}
			else
			{
				((Control)LB_Matches).Enabled = false;
			}
		}
		else
		{
			((Control)LB_Matches).Enabled = false;
			((Label)Label3).Text = "No emitters positively identified - unable to narrow down possible matches";
		}
	}

	private void method_4()
	{
		if (theContact.Recon_HostedUnits(Client.CurrentSide).Count > 0)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			string text = default(string);
			foreach (Contact.HostedUnitReconRecord item in theContact.Recon_HostedUnits(Client.CurrentSide))
			{
				switch (item.IDStatus)
				{
				case Contact_Base.IdentificationStatus.Unknown:
					text = "Unknown unit";
					break;
				case Contact_Base.IdentificationStatus.KnownDomain:
					try
					{
						ActiveUnit activeUnit2 = Client.CurrentScenario.ActiveUnits[item.UnitID];
						text = Misc.ToEnglishString(activeUnit2.VisualSizeClass) + " " + activeUnit2.UnitType_String;
					}
					catch (Exception ex7)
					{
						ProjectData.SetProjectError(ex7);
						Exception ex8 = ex7;
						ex8?.Data.Add("Error at 999999", ex8.Message);
						GameGeneral.WriteExceptionsToLog(ex8);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						text = "Unknown unit";
						ProjectData.ClearProjectError();
					}
					break;
				case Contact_Base.IdentificationStatus.KnownType:
					try
					{
						ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits[item.UnitID];
						text = Misc.ToEnglishString(activeUnit.VisualSizeClass) + " " + activeUnit.SubTypeDescription;
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception ex6 = ex5;
						ex6?.Data.Add("Error at 200409", ex6.Message);
						GameGeneral.WriteExceptionsToLog(ex6);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						text = "Unknown unit";
						ProjectData.ClearProjectError();
					}
					break;
				case Contact_Base.IdentificationStatus.KnownClass:
					try
					{
						text = Client.CurrentScenario.ActiveUnits[item.UnitID].UnitClass;
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 200410", ex4.Message);
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						text = "Unknown unit";
						ProjectData.ClearProjectError();
					}
					break;
				case Contact_Base.IdentificationStatus.PreciseID:
					try
					{
						text = Client.CurrentScenario.ActiveUnits[item.UnitID].Name;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200411", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						text = "Unknown unit";
						ProjectData.ClearProjectError();
					}
					break;
				}
				text = text + " (Last Recon: " + ((item.ReconAge > 0f) ? (Misc.TimeString((long)Math.Round(item.ReconAge), 0, ReturnNo: false, ReturnZero: true) + " ago)") : "Now)");
				if (dictionary.ContainsKey(text))
				{
					dictionary[text]++;
				}
				else
				{
					dictionary.Add(text, 1);
				}
			}
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, int> item2 in dictionary)
			{
				list.Add(Conversions.ToString(item2.Value) + "x " + item2.Key);
			}
			((Label)Label_HostedUnits).Text = string.Join("\r\n", list);
		}
		else
		{
			((Label)Label_HostedUnits).Text = "No hosted units spotted.";
		}
	}

	private void ContactReport_Shown(object sender, EventArgs e)
	{
		method_3();
		method_4();
		((TabControl)TabControl1).SelectedIndex = Client.ContactReport_LastSelectedTabIndex;
	}

	private void ContactReport_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void ContactReport_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_5(object sender, EventArgs e)
	{
		Client.ContactReport_LastSelectedTabIndex = ((TabControl)TabControl1).SelectedIndex;
	}

	private void ContactReport_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	static ContactReport()
	{
		Class72.smethod_20();
	}
}
