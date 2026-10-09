using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.Lua;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class ExportImportTool : DarkSecondaryFormBase
{
	public enum LogType
	{
		Success,
		Info,
		Warning,
		Issue
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Export")]
	private DarkUIButton _Button_Export;

	[AccessedThroughProperty("OpenFolder")]
	[CompilerGenerated]
	private DarkUIButton _OpenFolder;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ImportSerials")]
	private DarkUIButton _Button_ImportSerials;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ImportLandingPlan")]
	private DarkUIButton _Button_ImportLandingPlan;

	internal virtual DarkUIButton Button_Export
	{
		[CompilerGenerated]
		get
		{
			return _Button_Export;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button_Export;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Export = value;
			darkUIButton = _Button_Export;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox1")]
	internal virtual DarkGroupBox DarkGroupBox1 { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox2")]
	internal virtual DarkGroupBox DarkGroupBox2 { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel3")]
	internal virtual FlowLayoutPanel FlowLayoutPanel3 { get; set; }

	[field: AccessedThroughProperty("CB_Rp")]
	internal virtual CheckBox CB_Rp { get; set; }

	[field: AccessedThroughProperty("CB_Zones")]
	internal virtual CheckBox CB_Zones { get; set; }

	[field: AccessedThroughProperty("CB_Serials")]
	internal virtual CheckBox CB_Serials { get; set; }

	[field: AccessedThroughProperty("CB_Cargo")]
	internal virtual CheckBox CB_Cargo { get; set; }

	internal virtual DarkUIButton OpenFolder
	{
		[CompilerGenerated]
		get
		{
			return _OpenFolder;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _OpenFolder;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_OpenFolder = value;
			darkUIButton = _OpenFolder;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Panel1")]
	internal virtual Panel Panel1 { get; set; }

	[field: AccessedThroughProperty("CB_Units")]
	internal virtual CheckBox CB_Units { get; set; }

	[field: AccessedThroughProperty("CB_Missions")]
	internal virtual CheckBox CB_Missions { get; set; }

	[field: AccessedThroughProperty("CB_Side")]
	internal virtual CheckBox CB_Side { get; set; }

	[field: AccessedThroughProperty("CB_ExclZones")]
	internal virtual CheckBox CB_ExclZones { get; set; }

	[field: AccessedThroughProperty("CB_NONAVZones")]
	internal virtual CheckBox CB_NONAVZones { get; set; }

	[field: AccessedThroughProperty("CB_EnvZones")]
	internal virtual CheckBox CB_EnvZones { get; set; }

	[field: AccessedThroughProperty("CB_CreateSeparateFiles")]
	internal virtual CheckBox CB_CreateSeparateFiles { get; set; }

	internal virtual DarkUIButton Button_ImportSerials
	{
		[CompilerGenerated]
		get
		{
			return _Button_ImportSerials;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIButton darkUIButton = _Button_ImportSerials;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ImportSerials = value;
			darkUIButton = _Button_ImportSerials;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LV_Log")]
	internal virtual DarkListView LV_Log { get; set; }

	internal virtual DarkUIButton Button_ImportLandingPlan
	{
		[CompilerGenerated]
		get
		{
			return _Button_ImportLandingPlan;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIButton darkUIButton = _Button_ImportLandingPlan;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ImportLandingPlan = value;
			darkUIButton = _Button_ImportLandingPlan;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	public ExportImportTool()
	{
		((Form)this).Load += ExportImportTool_Load;
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
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		DarkGroupBox2 = new DarkGroupBox();
		LV_Log = new DarkListView();
		DarkGroupBox1 = new DarkGroupBox();
		CB_CreateSeparateFiles = new CheckBox();
		Panel1 = new Panel();
		FlowLayoutPanel3 = new FlowLayoutPanel();
		CB_Units = new CheckBox();
		CB_Missions = new CheckBox();
		CB_Rp = new CheckBox();
		CB_Zones = new CheckBox();
		CB_ExclZones = new CheckBox();
		CB_NONAVZones = new CheckBox();
		CB_EnvZones = new CheckBox();
		CB_Serials = new CheckBox();
		CB_Cargo = new CheckBox();
		CB_Side = new CheckBox();
		Button_ImportLandingPlan = new DarkUIButton();
		Button_ImportSerials = new DarkUIButton();
		Button_Export = new DarkUIButton();
		OpenFolder = new DarkUIButton();
		((Control)DarkGroupBox2).SuspendLayout();
		((Control)DarkGroupBox1).SuspendLayout();
		((Control)Panel1).SuspendLayout();
		((Control)FlowLayoutPanel3).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)DarkGroupBox2).Controls.Add((Control)(object)Button_ImportLandingPlan);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)Button_ImportSerials);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)LV_Log);
		((Control)DarkGroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox2).Location = new Point(434, 12);
		((Control)DarkGroupBox2).Name = "DarkGroupBox2";
		((Control)DarkGroupBox2).Size = new Size(416, 260);
		((Control)DarkGroupBox2).TabIndex = 2;
		((GroupBox)DarkGroupBox2).TabStop = false;
		((GroupBox)DarkGroupBox2).Text = "Importer";
		((Control)LV_Log).BackColor = Color.FromArgb(20, 23, 25);
		((Control)LV_Log).Location = new Point(6, 97);
		((Control)LV_Log).Name = "LV_Log";
		LV_Log.RelatedInfos = null;
		((Control)LV_Log).Size = new Size(401, 154);
		((Control)LV_Log).TabIndex = 5;
		((Control)LV_Log).Text = "LV_Report";
		((Control)DarkGroupBox1).Controls.Add((Control)(object)CB_CreateSeparateFiles);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)Panel1);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)FlowLayoutPanel3);
		((Control)DarkGroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox1).Location = new Point(12, 12);
		((Control)DarkGroupBox1).Name = "DarkGroupBox1";
		((Control)DarkGroupBox1).Size = new Size(416, 260);
		((Control)DarkGroupBox1).TabIndex = 1;
		((GroupBox)DarkGroupBox1).TabStop = false;
		((GroupBox)DarkGroupBox1).Text = "Exporter";
		((ButtonBase)CB_CreateSeparateFiles).AutoSize = true;
		((Control)CB_CreateSeparateFiles).Location = new Point(6, 193);
		((Control)CB_CreateSeparateFiles).Name = "CB_CreateSeparateFiles";
		((Control)CB_CreateSeparateFiles).Size = new Size(132, 17);
		((Control)CB_CreateSeparateFiles).TabIndex = 8;
		((ButtonBase)CB_CreateSeparateFiles).Text = "Export in separate files";
		((ButtonBase)CB_CreateSeparateFiles).UseVisualStyleBackColor = true;
		((Control)Panel1).Anchor = (AnchorStyles)6;
		((Control)Panel1).BackColor = Color.FromArgb(70, 73, 75);
		((Control)Panel1).Controls.Add((Control)(object)Button_Export);
		((Control)Panel1).Controls.Add((Control)(object)OpenFolder);
		((Control)Panel1).Location = new Point(6, 216);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(404, 38);
		((Control)Panel1).TabIndex = 7;
		((Control)FlowLayoutPanel3).Anchor = (AnchorStyles)13;
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)CB_Units);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)CB_Missions);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)CB_Rp);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)CB_Zones);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)CB_ExclZones);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)CB_NONAVZones);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)CB_EnvZones);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)CB_Serials);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)CB_Cargo);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)CB_Side);
		FlowLayoutPanel3.FlowDirection = (FlowDirection)1;
		((Control)FlowLayoutPanel3).Location = new Point(9, 31);
		((Control)FlowLayoutPanel3).Name = "FlowLayoutPanel3";
		((Control)FlowLayoutPanel3).Size = new Size(398, 141);
		((Control)FlowLayoutPanel3).TabIndex = 3;
		((ButtonBase)CB_Units).AutoSize = true;
		((Control)CB_Units).Location = new Point(3, 3);
		((Control)CB_Units).Name = "CB_Units";
		((Control)CB_Units).Size = new Size(50, 17);
		((Control)CB_Units).TabIndex = 2;
		((ButtonBase)CB_Units).Text = "Units";
		((ButtonBase)CB_Units).UseVisualStyleBackColor = true;
		((ButtonBase)CB_Missions).AutoSize = true;
		((Control)CB_Missions).Location = new Point(3, 26);
		((Control)CB_Missions).Name = "CB_Missions";
		((Control)CB_Missions).Size = new Size(66, 17);
		((Control)CB_Missions).TabIndex = 3;
		((ButtonBase)CB_Missions).Text = "Missions";
		((ButtonBase)CB_Missions).UseVisualStyleBackColor = true;
		((ButtonBase)CB_Rp).AutoSize = true;
		((Control)CB_Rp).Location = new Point(3, 49);
		((Control)CB_Rp).Name = "CB_Rp";
		((Control)CB_Rp).Size = new Size(108, 17);
		((Control)CB_Rp).TabIndex = 2;
		((ButtonBase)CB_Rp).Text = "Reference Points";
		((ButtonBase)CB_Rp).UseVisualStyleBackColor = true;
		((ButtonBase)CB_Zones).AutoSize = true;
		((Control)CB_Zones).Location = new Point(3, 72);
		((Control)CB_Zones).Name = "CB_Zones";
		((Control)CB_Zones).Size = new Size(102, 17);
		((Control)CB_Zones).TabIndex = 1;
		((ButtonBase)CB_Zones).Text = "Standard Zones";
		((ButtonBase)CB_Zones).UseVisualStyleBackColor = true;
		((ButtonBase)CB_ExclZones).AutoSize = true;
		((Control)CB_ExclZones).Location = new Point(3, 95);
		((Control)CB_ExclZones).Name = "CB_ExclZones";
		((Control)CB_ExclZones).Size = new Size(104, 17);
		((Control)CB_ExclZones).TabIndex = 5;
		((ButtonBase)CB_ExclZones).Text = "Exclusion Zones";
		((ButtonBase)CB_ExclZones).UseVisualStyleBackColor = true;
		((ButtonBase)CB_NONAVZones).AutoSize = true;
		((Control)CB_NONAVZones).Location = new Point(3, 118);
		((Control)CB_NONAVZones).Name = "CB_NONAVZones";
		((Control)CB_NONAVZones).Size = new Size(96, 17);
		((Control)CB_NONAVZones).TabIndex = 6;
		((ButtonBase)CB_NONAVZones).Text = "No-Nav Zones";
		((ButtonBase)CB_NONAVZones).UseVisualStyleBackColor = true;
		((ButtonBase)CB_EnvZones).AutoSize = true;
		((Control)CB_EnvZones).Location = new Point(117, 3);
		((Control)CB_EnvZones).Name = "CB_EnvZones";
		((Control)CB_EnvZones).Size = new Size(156, 17);
		((Control)CB_EnvZones).TabIndex = 7;
		((ButtonBase)CB_EnvZones).Text = "Custom Environment Zones";
		((ButtonBase)CB_EnvZones).UseVisualStyleBackColor = true;
		((ButtonBase)CB_Serials).AutoSize = true;
		((Control)CB_Serials).Location = new Point(117, 26);
		((Control)CB_Serials).Name = "CB_Serials";
		((Control)CB_Serials).Size = new Size(57, 17);
		((Control)CB_Serials).TabIndex = 1;
		((ButtonBase)CB_Serials).Text = "Serials";
		((ButtonBase)CB_Serials).UseVisualStyleBackColor = true;
		((ButtonBase)CB_Cargo).AutoSize = true;
		((Control)CB_Cargo).Location = new Point(117, 49);
		((Control)CB_Cargo).Name = "CB_Cargo";
		((Control)CB_Cargo).Size = new Size(54, 17);
		((Control)CB_Cargo).TabIndex = 1;
		((ButtonBase)CB_Cargo).Text = "Cargo";
		((ButtonBase)CB_Cargo).UseVisualStyleBackColor = true;
		((ButtonBase)CB_Side).AutoSize = true;
		((Control)CB_Side).Location = new Point(117, 72);
		((Control)CB_Side).Name = "CB_Side";
		((Control)CB_Side).Size = new Size(52, 17);
		((Control)CB_Side).TabIndex = 4;
		((ButtonBase)CB_Side).Text = "Sides";
		((ButtonBase)CB_Side).UseVisualStyleBackColor = true;
		((ButtonBase)Button_ImportLandingPlan).BackColor = Color.Transparent;
		((Button)Button_ImportLandingPlan).DialogResult = (DialogResult)0;
		((Control)Button_ImportLandingPlan).ForeColor = SystemColors.Control;
		((Control)Button_ImportLandingPlan).Location = new Point(6, 57);
		((Control)Button_ImportLandingPlan).Name = "Button_ImportLandingPlan";
		Button_ImportLandingPlan.RoundRadius = 0;
		((Control)Button_ImportLandingPlan).Size = new Size(401, 34);
		((Control)Button_ImportLandingPlan).TabIndex = 7;
		Button_ImportLandingPlan.Text = "Import Landing Plan";
		((Control)Button_ImportLandingPlan).Visible = false;
		((ButtonBase)Button_ImportSerials).BackColor = Color.Transparent;
		((Button)Button_ImportSerials).DialogResult = (DialogResult)0;
		((Control)Button_ImportSerials).ForeColor = SystemColors.Control;
		((Control)Button_ImportSerials).Location = new Point(6, 19);
		((Control)Button_ImportSerials).Name = "Button_ImportSerials";
		Button_ImportSerials.RoundRadius = 0;
		((Control)Button_ImportSerials).Size = new Size(401, 34);
		((Control)Button_ImportSerials).TabIndex = 6;
		Button_ImportSerials.Text = "Import Serials";
		((Control)Button_ImportSerials).Visible = false;
		((ButtonBase)Button_Export).BackColor = Color.Transparent;
		((Button)Button_Export).DialogResult = (DialogResult)0;
		((Control)Button_Export).ForeColor = SystemColors.Control;
		((Control)Button_Export).Location = new Point(6, 3);
		((Control)Button_Export).Name = "Button_Export";
		Button_Export.RoundRadius = 0;
		((Control)Button_Export).Size = new Size(285, 32);
		((Control)Button_Export).TabIndex = 0;
		Button_Export.Text = "Export";
		((ButtonBase)OpenFolder).BackColor = Color.Transparent;
		((Button)OpenFolder).DialogResult = (DialogResult)0;
		((Control)OpenFolder).ForeColor = SystemColors.Control;
		((Control)OpenFolder).Location = new Point(315, 3);
		((Control)OpenFolder).Name = "OpenFolder";
		OpenFolder.RoundRadius = 0;
		((Control)OpenFolder).Size = new Size(86, 32);
		((Control)OpenFolder).TabIndex = 6;
		OpenFolder.Text = "Open Folder";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 63, 65);
		((Form)this).ClientSize = new Size(861, 283);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox2);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox1);
		((Control)this).Name = "ExportImportTool";
		((Form)this).Text = "CsvExporter";
		((Control)DarkGroupBox2).ResumeLayout(false);
		((Control)DarkGroupBox1).ResumeLayout(false);
		((Control)DarkGroupBox1).PerformLayout();
		((Control)Panel1).ResumeLayout(false);
		((Control)FlowLayoutPanel3).ResumeLayout(false);
		((Control)FlowLayoutPanel3).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	private void method_2(object sender, EventArgs e)
	{
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			List<string> list = new List<string>();
			Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
			if (CB_Units.Checked)
			{
				dictionary.Add("Units", CreateExportString_Units());
			}
			if (CB_Missions.Checked)
			{
				dictionary.Add("Missions", CreateExportString_Missions());
			}
			if (CB_Rp.Checked)
			{
				dictionary.Add("Reference Points", CreateExportString_RP());
			}
			if (CB_Zones.Checked)
			{
				dictionary.Add("Standard Zones", CreateExportString_StandardZones());
			}
			if (CB_EnvZones.Checked)
			{
				dictionary.Add("Environment Zones", CreateExportString_EnvironmentZone());
			}
			if (CB_NONAVZones.Checked)
			{
				dictionary.Add("NONAV Zones", CreateExportString_NoNavZones());
			}
			if (CB_ExclZones.Checked)
			{
				dictionary.Add("Exclusion Zones", CreateExportString_ExclusionZones());
			}
			if (CB_Side.Checked)
			{
				dictionary.Add("Sides", CreateExportString_Sides());
			}
			if (CB_Serials.Checked)
			{
				dictionary.Add("Serials", CreateExportString_Serials());
			}
			if (CB_Cargo.Checked)
			{
				dictionary.Add("Cargo", CreateExportString_Cargo());
			}
			string path = CreateDestinationFolder_ImportExport();
			foreach (KeyValuePair<string, List<string>> item in dictionary)
			{
				if (CB_CreateSeparateFiles.Checked)
				{
					File.WriteAllLines(Path.Combine(path, item.Key + ".csv"), item.Value.ToArray());
				}
				else
				{
					list.AddRange(item.Value);
				}
			}
			File.WriteAllLines(Path.Combine(path, "All_Exports.csv"), list.ToArray());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("Failed to export - ERROR : " + ex2.Message, "Export failure", (MessageBoxButtons)0);
			ProjectData.ClearProjectError();
		}
	}

	public static string CreateDestinationFolder_ImportExport()
	{
		string text = Path.Combine(GameGeneral.TopLevelWritablePath, "ExportTool");
		Directory.CreateDirectory(text);
		string path = ((!string.IsNullOrEmpty(Client.CurrentScenario.Title)) ? Misc.ReplaceIllegalCharacters(Client.CurrentScenario.Title, "_") : "Untitled");
		string text2 = Path.Combine(text, path);
		Directory.CreateDirectory(text2);
		return Path.Combine(text, text2);
	}

	public static string CreateDestinationFolder_LandingPlanner()
	{
		string text = Path.Combine(GameGeneral.TopLevelWritablePath, "LandingPlanner");
		Directory.CreateDirectory(text);
		string path = ((!string.IsNullOrEmpty(Client.CurrentScenario.Title)) ? Misc.ReplaceIllegalCharacters(Client.CurrentScenario.Title, "_") : "Untitled");
		string text2 = Path.Combine(text, path);
		Directory.CreateDirectory(text2);
		return Path.Combine(text, text2);
	}

	public List<string> CreateExportString_Units()
	{
		List<string> list = new List<string>();
		list.Add("Units");
		list.Add("GUID;SIDE;NAME;CLASS;TYPE;ASSIGNED MISSIONS;QUEUED TO MISSION;MOTHERSHIP;ASSOCIATED SERIAL");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			Dictionary<ActiveUnit, int> dictionary = new Dictionary<ActiveUnit, int>();
			foreach (Chalk chalk in side.Chalks)
			{
				foreach (KeyValuePair<Cargo, int> item in chalk.Cargo)
				{
					if (item.Key.CargoObjectActiveUnit != null)
					{
						dictionary.Add(item.Key.CargoObjectActiveUnit, chalk.Priority);
					}
				}
			}
			foreach (ActiveUnit unit in side.Units)
			{
				List<string> list2 = new List<string>();
				list2.Add(unit.ObjectID);
				list2.Add(side.Name + " (" + side.ObjectID + ")");
				list2.Add(unit.Name);
				list2.Add(unit.UnitClass);
				list2.Add(unit.UnitType_String);
				Mission mission = unit.ActiveMissionOrPackage();
				if (mission == null)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(mission.Name + " (" + mission.ObjectID + ")");
				}
				List<string> list3 = new List<string>();
				foreach (Mission value in unit.AssignedMissionsQueue.Values)
				{
					list3.Add(value.Name + " (" + value.ObjectID + ")");
				}
				if (list3.Count <= 0)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(string.Join("|", list3));
				}
				if (unit.DockingOps.CurrentHostUnit == null)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(unit.DockingOps.CurrentHostUnit.Name + "(" + unit.DockingOps.CurrentHostUnit.ObjectID + ")");
				}
				if (!dictionary.ContainsKey(unit))
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(dictionary[unit].ToString());
				}
				list3.Clear();
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_Missions()
	{
		List<string> list = new List<string>();
		list.Add("Missions");
		list.Add("GUID;SIDE;NAME;CLASS;ASSIGNED UNITS;QUEUED UNITS;PRIORITY");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			foreach (Mission mission in side.Missions)
			{
				List<string> list2 = new List<string>();
				list2.Add(mission.ObjectID);
				list2.Add(side.Name + " (" + side.ObjectID + ")");
				list2.Add(mission.Name);
				list2.Add(mission.MissionClass.ToString());
				List<string> list3 = new List<string>();
				foreach (ActiveUnit value in mission.UnitsAssignedToMission.Values)
				{
					list3.Add(value.Name + " (" + value.ObjectID + ")");
				}
				if (list3.Count <= 0)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(string.Join("|", list3));
				}
				list3.Clear();
				foreach (ActiveUnit value2 in mission.UnitsQueuedToMission.Values)
				{
					list3.Add(value2.Name + " (" + value2.ObjectID + ")");
				}
				if (list3.Count > 0)
				{
					list2.Add(string.Join("|", list3));
				}
				else
				{
					list2.Add("None");
				}
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_RP()
	{
		List<string> list = new List<string>();
		list.Add("Reference Points");
		list.Add("GUID;SIDE;NAME;LATITUDE;LONGITUDE");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			foreach (ReferencePoint refPoint in side.RefPoints)
			{
				List<string> list2 = new List<string>();
				list2.Add(refPoint.ObjectID);
				list2.Add(side.Name + " (" + side.ObjectID + ")");
				list2.Add(refPoint.Name);
				list2.Add(refPoint.Latitude.ToString());
				list2.Add(refPoint.Longitude.ToString());
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_StandardZones()
	{
		List<string> list = new List<string>();
		list.Add("Standard Zones");
		list.Add("GUID;SIDE;NAME;Reference Points");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			foreach (Zone standardZone in side.StandardZones)
			{
				List<string> list2 = new List<string>();
				list2.Add(standardZone.ObjectID);
				list2.Add(side.Name + " (" + side.ObjectID + ")");
				list2.Add(standardZone.Name);
				List<string> list3 = new List<string>();
				foreach (ReferencePoint item in standardZone.Area)
				{
					list3.Add(item.Name + " (" + item.ObjectID + ")");
				}
				if (list3.Count > 0)
				{
					list2.Add(string.Join("|", list3));
				}
				else
				{
					list2.Add("None");
				}
				list3.Clear();
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_EnvironmentZone()
	{
		List<string> list = new List<string>();
		list.Add("Custom Environment Zones");
		list.Add("GUID;SIDE;NAME;Reference Points");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			CustomEnvironmentZone[] customEnvironmentZones = side.CustomEnvironmentZones;
			foreach (CustomEnvironmentZone customEnvironmentZone in customEnvironmentZones)
			{
				List<string> list2 = new List<string>();
				list2.Add(customEnvironmentZone.ObjectID);
				list2.Add(side.Name + " (" + side.ObjectID + ")");
				list2.Add(customEnvironmentZone.Name);
				List<string> list3 = new List<string>();
				foreach (ReferencePoint item in customEnvironmentZone.Area)
				{
					list3.Add(item.Name + " (" + item.ObjectID + ")");
				}
				if (list3.Count > 0)
				{
					list2.Add(string.Join("|", list3));
				}
				else
				{
					list2.Add("None");
				}
				list3.Clear();
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_NoNavZones()
	{
		List<string> list = new List<string>();
		list.Add("No-Nav Zones");
		list.Add("GUID;SIDE;NAME;Reference Points");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			foreach (NoNavZone noNavZone in side.NoNavZones)
			{
				List<string> list2 = new List<string>();
				list2.Add(noNavZone.ObjectID);
				list2.Add(side.Name + " (" + side.ObjectID + ")");
				list2.Add(noNavZone.Name);
				List<string> list3 = new List<string>();
				foreach (ReferencePoint item in noNavZone.Area)
				{
					list3.Add(item.Name + " (" + item.ObjectID + ")");
				}
				if (list3.Count <= 0)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(string.Join("|", list3));
				}
				list3.Clear();
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_ExclusionZones()
	{
		List<string> list = new List<string>();
		list.Add("Exclusion Zones");
		list.Add("GUID;SIDE;NAME;Reference Points");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			foreach (ExclusionZone exclusionZone in side.ExclusionZones)
			{
				List<string> list2 = new List<string>();
				list2.Add(exclusionZone.ObjectID);
				list2.Add(side.Name + " (" + side.ObjectID + ")");
				list2.Add(exclusionZone.Name);
				List<string> list3 = new List<string>();
				foreach (ReferencePoint item in exclusionZone.Area)
				{
					list3.Add(item.Name + " (" + item.ObjectID + ")");
				}
				if (list3.Count <= 0)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(string.Join("|", list3));
				}
				list3.Clear();
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_Sides()
	{
		List<string> list = new List<string>();
		list.Add("Sides");
		list.Add("GUID;NAME");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			foreach (ExclusionZone exclusionZone in side.ExclusionZones)
			{
				List<string> list2 = new List<string>();
				list2.Add(exclusionZone.ObjectID);
				list2.Add(exclusionZone.Name);
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_Serials()
	{
		List<string> list = new List<string>();
		list.Add("Serials");
		list.Add("ID;SIDE;MOTHERSHIP;CARGO");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			foreach (Chalk chalk in side.Chalks)
			{
				List<string> list2 = new List<string>();
				list2.Add(chalk.ID.ToString());
				list2.Add(side.Name + " (" + side.ObjectID + ")");
				list2.Add(chalk.AssociatedMothership.Name + "(" + chalk.AssociatedMothership.ObjectID + ")");
				List<string> list3 = new List<string>();
				foreach (KeyValuePair<Cargo, int> item in chalk.Cargo)
				{
					list3.Add(item.Key.CargoObjectName + " (" + item.Key.ObjectID + ")");
				}
				if (list3.Count <= 0)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(string.Join("|", list3));
				}
				list3.Clear();
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_Cargo()
	{
		List<string> list = new List<string>();
		list.Add("Cargo");
		list.Add("GUID;SIDE;NAME;PARENT PLATFORM;CARGO SIZE;MASS;AREA;PAX;ASSOCIATED SERIAL");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			Dictionary<Cargo, int> dictionary = new Dictionary<Cargo, int>();
			foreach (Chalk chalk in side.Chalks)
			{
				foreach (KeyValuePair<Cargo, int> item in chalk.Cargo)
				{
					dictionary.Add(item.Key, chalk.ID);
				}
			}
			foreach (ActiveUnit unit in side.Units)
			{
				Cargo[] onboardCargo = unit.OnboardCargo;
				foreach (Cargo cargo in onboardCargo)
				{
					List<string> list2 = new List<string>();
					list2.Add(cargo.ObjectID);
					list2.Add(side.Name + " (" + side.ObjectID + ")");
					list2.Add(cargo.CargoObjectName);
					list2.Add(cargo.ParentPlatform.Name + "(" + cargo.ParentPlatform.ObjectID + ")");
					list2.Add(cargo.RequiredCargoType.ToString());
					list2.Add(cargo.RequiredMass.ToString());
					list2.Add(cargo.RequiredArea.ToString());
					list2.Add(cargo.RequiredCrewSpace.ToString());
					if (!dictionary.ContainsKey(cargo))
					{
						list2.Add("None");
					}
					else
					{
						list2.Add(dictionary[cargo].ToString());
					}
					list.Add(string.Join(";", string.Join(";", list2.ToArray())));
				}
			}
		}
		return list;
	}

	private void method_3(object sender, EventArgs e)
	{
		Process.Start(CreateDestinationFolder_ImportExport());
	}

	private void method_4(object sender, EventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		//IL_0612: Unknown result type (might be due to invalid IL or missing references)
		OpenFileDialog val = new OpenFileDialog();
		if ((int)((CommonDialog)val).ShowDialog() != 1)
		{
			return;
		}
		try
		{
			string text = new StreamReader(((FileDialog)val).FileName).ReadToEnd();
			List<Dictionary<SerialColumn_E, string>> list = new List<Dictionary<SerialColumn_E, string>>();
			string[] array = Strings.Split(text, "\r\n", -1, (CompareMethod)1);
			foreach (string text2 in array)
			{
				if (string.IsNullOrEmpty(text2))
				{
					continue;
				}
				List<string> list2 = Strings.Split(text2, ";", -1, (CompareMethod)1).ToList();
				if (list2.Count >= 4 && Operators.CompareString(list2.ElementAt(0).ToLower(), "#serial", true) == 0)
				{
					list2.RemoveAt(0);
					Dictionary<SerialColumn_E, string> dictionary = new Dictionary<SerialColumn_E, string>();
					int num = list2.Count - 1;
					for (int j = 0; j <= num; j++)
					{
						dictionary.Add((SerialColumn_E)j, list2[j]);
					}
					list.Add(dictionary);
				}
			}
			foreach (Dictionary<SerialColumn_E, string> item in list)
			{
				if (string.IsNullOrEmpty(item[SerialColumn_E.Side]))
				{
					AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.Side.ToString() + " field (Empty field)", LV_Log, LogType.Issue);
					continue;
				}
				Side side = null;
				try
				{
					side = LuaUtility.QuerySideObject(item[SerialColumn_E.Side], Client.CurrentScenario);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.Side.ToString() + " field (Side not found)", LV_Log, LogType.Issue);
					ProjectData.ClearProjectError();
				}
				if (side != null)
				{
					if (string.IsNullOrEmpty(item[SerialColumn_E.ID]))
					{
						AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.ID.ToString() + " field (Empty field)", LV_Log, LogType.Issue);
						continue;
					}
					int result = -1;
					if (int.TryParse(item[SerialColumn_E.ID], out result))
					{
						if (Chalk.ValidateChalkID(result, side))
						{
							if (string.IsNullOrEmpty(item[SerialColumn_E.AssociatedMothership]))
							{
								AddLogEntry("Serial " + item[SerialColumn_E.AssociatedMothership] + " has an issue with the " + SerialColumn_E.ID.ToString() + " field (Empty field)", LV_Log, LogType.Issue);
								continue;
							}
							ActiveUnit activeUnit = PrivateMethods.smethod_1(item[SerialColumn_E.AssociatedMothership], Client.CurrentScenario);
							if (activeUnit == null)
							{
								AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.AssociatedMothership.ToString() + " field (mothership not found)", LV_Log, LogType.Issue);
								continue;
							}
							string[] array2 = Strings.Split(item[SerialColumn_E.CargoIDs], "|", -1, (CompareMethod)1);
							List<Cargo> list3 = new List<Cargo>();
							string[] array3 = array2;
							foreach (string text3 in array3)
							{
								if (!string.IsNullOrEmpty(text3))
								{
									Cargo cargo = FetchCargoInMotherShip(text3, activeUnit);
									if (cargo == null)
									{
										AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.CargoIDs.ToString() + " field (Cargo #" + text3 + " not found in mothership)", LV_Log, LogType.Issue);
									}
									else
									{
										list3.Add(cargo);
									}
								}
								else
								{
									AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.CargoIDs.ToString() + " field (Empty field)", LV_Log, LogType.Issue);
								}
							}
							Chalk chalk = new Chalk(result, activeUnit);
							foreach (Cargo item2 in list3)
							{
								chalk.AddCargo(item2);
							}
							side.Chalks.Add(chalk);
							if (list3.Count == 0)
							{
								AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has no cargo .", LV_Log, LogType.Warning);
							}
							AddLogEntry("Serial " + item[SerialColumn_E.ID] + " was successfully added to mothership " + activeUnit.Name, LV_Log, LogType.Success);
						}
						else
						{
							AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.ID.ToString() + " field (chalk ID validation issue)", LV_Log, LogType.Issue);
						}
					}
					else
					{
						AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.ID.ToString() + " field (int parsing failed)", LV_Log, LogType.Issue);
					}
				}
				else
				{
					AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.Side.ToString() + " field (Side not found)", LV_Log, LogType.Issue);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show($"Security error.\\n\\nError message: {ex2.Message}\\n\\n" + $"Details:\\n\\n{ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
	}

	public Cargo FetchCargoInMotherShip(string ID, ActiveUnit Mothership)
	{
		if (string.IsNullOrEmpty(ID))
		{
			return null;
		}
		Cargo[] onboardCargo = Mothership.OnboardCargo;
		foreach (Cargo cargo in onboardCargo)
		{
			if (Operators.CompareString(cargo.ObjectID, ID, true) == 0)
			{
				return cargo;
			}
		}
		return null;
	}

	public static void AddLogEntry(string Text, DarkListView ParentDebugger, LogType Type = LogType.Info)
	{
		if (ParentDebugger != null)
		{
			Color textColor = default(Color);
			switch (Type)
			{
			case LogType.Success:
				textColor = Color.Green;
				break;
			case LogType.Info:
				textColor = Color.White;
				break;
			case LogType.Warning:
				textColor = Color.Orange;
				break;
			case LogType.Issue:
				textColor = Color.OrangeRed;
				break;
			}
			DarkListItem darkListItem = new DarkListItem(Type.ToString() + ": " + Text);
			darkListItem.TextColor = textColor;
			ParentDebugger.Items.Add(darkListItem);
		}
	}

	public static void ImportLandingPlan(LandingPlanner LandingPlannerUI = null, DarkListView ParentDebugger = null, bool ShowErrorLogAsPopup = false)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Invalid comparison between Unknown and I4
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		OpenFileDialog val = new OpenFileDialog();
		((FileDialog)val).InitialDirectory = CreateDestinationFolder_LandingPlanner();
		Export_ImportFeedback export_ImportFeedback = null;
		if ((int)((CommonDialog)val).ShowDialog() != 1)
		{
			return;
		}
		try
		{
			if (ShowErrorLogAsPopup && ParentDebugger == null)
			{
				export_ImportFeedback = new Export_ImportFeedback();
				ParentDebugger = export_ImportFeedback.LV_Main;
			}
			string[] array = Strings.Split(new StreamReader(((FileDialog)val).FileName).ReadToEnd(), "\r\n", -1, (CompareMethod)1);
			Dictionary<DataObject_E, bool> dictionary = new Dictionary<DataObject_E, bool>();
			dictionary.Add(DataObject_E.mothership, value: true);
			dictionary.Add(DataObject_E.transport, value: true);
			dictionary.Add(DataObject_E.transportClass, value: true);
			dictionary.Add(DataObject_E.zone, value: true);
			dictionary.Add(DataObject_E.serial, value: true);
			LandingPlan_ImportWrapper landingPlan_ImportWrapper = new LandingPlan_ImportWrapper();
			try
			{
				foreach (KeyValuePair<DataObject_E, bool> item in dictionary)
				{
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i = checked(i + 1))
					{
						Import_ProcessLandingPlanLine(array2[i], landingPlan_ImportWrapper, ParentDebugger, item.Key);
					}
				}
				if (!ShowErrorLogAsPopup)
				{
					AddLogEntry("Landing plan was successfully imported : ", ParentDebugger, LogType.Success);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				AddLogEntry("Critical issue when importing landing plan " + ex2.Message, ParentDebugger, LogType.Issue);
				ProjectData.ClearProjectError();
			}
			if (LandingPlannerUI != null)
			{
				((Form)LandingPlannerUI).Close();
			}
			((Control)new LandingPlanner
			{
				LandingPlanImport = landingPlan_ImportWrapper
			}).Show();
			if (export_ImportFeedback != null && export_ImportFeedback.LV_Main.Items.Count > 0)
			{
				((Form)export_ImportFeedback).ShowDialog();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			AddLogEntry("Issue when loading landing plan : " + ex4.Message, ParentDebugger, LogType.Issue);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ExportLandingPlan_Simplified(LandingPlanner LandingPlanner, DarkListView ParentDebugger = null, bool ShowErrorLogAsPopup = false, bool ExportInHumanReadableWay = false)
	{
		//IL_0a43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1d: Unknown result type (might be due to invalid IL or missing references)
		Export_ImportFeedback export_ImportFeedback = null;
		string text = "";
		try
		{
			if (ShowErrorLogAsPopup && ParentDebugger == null)
			{
				export_ImportFeedback = new Export_ImportFeedback();
				ParentDebugger = export_ImportFeedback.LV_Main;
			}
			new LandingPlan_ImportWrapper();
			try
			{
				text = text + "sep =;" + Environment.NewLine;
				if (ExportInHumanReadableWay)
				{
					text = text + "; [NON-EDITABLE];;" + Environment.NewLine;
				}
				text = (ExportInHumanReadableWay ? (text + "#Mothership;" + LandingPlanner.CurrentMothership.Name + ";" + Environment.NewLine) : (text + "#Mothership;" + LandingPlanner.CurrentMothership.ObjectID + ";" + Environment.NewLine));
				Dictionary<string, Transport> dictionary = new Dictionary<string, Transport>();
				Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
				Dictionary<string, bool> dictionary3 = new Dictionary<string, bool>();
				foreach (ActiveUnit key in LandingPlanner.TransportList.Keys)
				{
					if (!dictionary2.ContainsKey(key.UnitClass))
					{
						dictionary2.Add(key.UnitClass, 1);
						dictionary3.Add(key.UnitClass, value: true);
						dictionary.Add(key.UnitClass, LandingPlanner.TransportList[key]);
					}
					else
					{
						dictionary2[key.UnitClass]++;
					}
				}
				if (ExportInHumanReadableWay)
				{
					text = text + ";;;" + Environment.NewLine;
					text = text + ";;;" + Environment.NewLine;
					text = text + ";Transports;;;" + Environment.NewLine;
					text = text + ";Type [NON-EDITABLE];Amount [NON-EDITABLE];PAX capacity [NON-EDITABLE];Weight capacity (Tons) [NON-EDITABLE];Area capacity (M2) [NON-EDITABLE]; Max type capacity [NON-EDITABLE]" + Environment.NewLine;
				}
				foreach (KeyValuePair<string, Transport> item in dictionary)
				{
					text = text + "#Transport;" + item.Key + ";" + dictionary2[item.Key] + ";" + item.Value.CrewCapacity + ";" + item.Value.MassCapacity + ";" + item.Value.AreaCapacity + ";" + item.Value.MaxSize.ToString() + ";" + Environment.NewLine;
				}
				if (ExportInHumanReadableWay)
				{
					text = text + ";;;" + Environment.NewLine;
					text = text + ";;;" + Environment.NewLine;
					text = text + "Zones;;;" + Environment.NewLine;
					text = text + ";Name  [NON-EDITABLE];Type  [NON-EDITABLE];" + Environment.NewLine;
				}
				foreach (KeyValuePair<LandingZoneWrapper, LandingZoneWrapper> assignedZone in LandingPlanner.AssignedZones)
				{
					if (assignedZone.Value.LandingZoneType != LandingType.Unassigned)
					{
						text = (ExportInHumanReadableWay ? (text + "#Zone;" + assignedZone.Key.LandingZone.Description + ";" + assignedZone.Value.LandingZoneType.ToString().ToLower() + ";" + Environment.NewLine) : (text + "#Zone;" + assignedZone.Key.LandingZone.ObjectID + ";" + assignedZone.Value.LandingZoneType.ToString().ToLower() + ";" + Environment.NewLine));
					}
				}
				if (ExportInHumanReadableWay)
				{
					List<string> list = new List<string>();
					foreach (KeyValuePair<string, int> item2 in dictionary2)
					{
						list.Add("Use " + item2.Key + " (x" + item2.Value + ")");
					}
					text = text + ";;;" + Environment.NewLine;
					text = text + ";;;" + Environment.NewLine;
					text = text + "Serials;;;" + Environment.NewLine;
					text = text + ";Name  [NON-EDITABLE];Priority;Assigned Landing Zone;" + string.Join(";", list) + ";Serial's units & cargo [NON-EDITABLE];PAX [NON-EDITABLE];Weight (Tons) [NON-EDITABLE];Area (M2) [NON-EDITABLE];Cargo Type [NON-EDITABLE]" + Environment.NewLine;
				}
				foreach (KeyValuePair<Chalk, List<UnitLineWrapper>> item3 in LandingPlanner.ChalkContainer)
				{
					if (item3.Value.Count <= 0 || item3.Value.ElementAt(0).ChalkUnit.LandingZone == null)
					{
						continue;
					}
					Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
					foreach (ActiveUnit key2 in LandingPlanner.TransportList.Keys)
					{
						dictionary3[key2.UnitClass] = true;
						foreach (UnitLineWrapper item4 in item3.Value)
						{
							if (!item4.ChalkUnit.TransportAvailable.ContainsKey(key2.UnitClass) || item4.ChalkUnit.TransportAvailable[key2.UnitClass] != TransportAvailability.UseTransport)
							{
								dictionary3[key2.UnitClass] = false;
							}
						}
					}
					foreach (KeyValuePair<string, bool> item5 in dictionary3)
					{
						dictionary4.Add(item5.Key, Bool2HumanReadableString(item5.Value));
					}
					string text2 = string.Join(";", dictionary4.Values);
					string text3 = "";
					string text4 = "";
					List<string> list2 = new List<string>();
					foreach (KeyValuePair<Cargo, int> item6 in item3.Key.Cargo)
					{
						list2.Add("(x" + item6.Key.CargoObjectQuantity + ") " + item6.Key.CargoObjectName);
					}
					text4 = text4 + string.Join(", ", list2) + ";";
					text4 = text4 + item3.Key.GetCrew() + ";" + item3.Key.GetMass() + ";" + item3.Key.GetArea() + ";" + item3.Key.GetLargestCargo();
					text3 = ((!ExportInHumanReadableWay) ? item3.Value.ElementAt(0).ChalkUnit.LandingZone.LandingZone.ObjectID : item3.Value.ElementAt(0).ChalkUnit.LandingZone.LandingZone.Description);
					text = ((item3.Key.Preboat == null) ? (text + "#Serial;" + item3.Key.ID + ";" + item3.Value.ElementAt(0).ChalkUnit.Priority + ";" + text3 + ";" + text2 + ";" + text4 + ";" + Environment.NewLine) : (text + "#Serial;" + item3.Key.Preboat.ActualTransport.Name + ";" + item3.Value.ElementAt(0).ChalkUnit.Priority + ";" + text3 + ";" + text2 + ";" + text4 + ";" + Environment.NewLine));
				}
				string text5 = Path.Combine(CreateDestinationFolder_LandingPlanner(), "LandingPlan_" + LandingPlanner.CurrentMothership.Name);
				string text6 = "csv";
				int num = 0;
				string path = text5 + "." + text6;
				while (File.Exists(path))
				{
					num++;
					path = text5 + " - " + Conversions.ToString(num) + "." + text6;
				}
				File.WriteAllText(path, text);
				if (!ShowErrorLogAsPopup)
				{
					AddLogEntry("Landing plan was successfully exported : ", ParentDebugger, LogType.Success);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				AddLogEntry("Critical issue when exporting landing plan " + ex2.Message, ParentDebugger, LogType.Issue);
				ProjectData.ClearProjectError();
			}
			if (export_ImportFeedback != null && export_ImportFeedback.LV_Main.Items.Count > 0)
			{
				((Form)export_ImportFeedback).ShowDialog();
			}
			DarkMessageBox.ShowInformation("LandingPlan_" + LandingPlanner.CurrentMothership.Name + " was successfully saved.", "Landing plan saved");
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			AddLogEntry("Issue when loading landing plan : " + ex4.Message, ParentDebugger, LogType.Issue);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static string Bool2HumanReadableString(bool input)
	{
		if (!input)
		{
			return "no";
		}
		return "yes";
	}

	public static bool HumanReadableString2Bool(string Input)
	{
		return new string[7] { "yes", "true", "allow", "allowed", "use", "used", "1" }.Contains(Input.ToLower());
	}

	public static void ExportLandingPlan(LandingPlanner LandingPlanner, DarkListView ParentDebugger = null, bool ShowErrorLogAsPopup = false, bool ExportInHumanReadableWay = false)
	{
		//IL_06ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
		Export_ImportFeedback export_ImportFeedback = null;
		string text = "";
		try
		{
			if (ShowErrorLogAsPopup && ParentDebugger == null)
			{
				export_ImportFeedback = new Export_ImportFeedback();
				ParentDebugger = export_ImportFeedback.LV_Main;
			}
			new LandingPlan_ImportWrapper();
			try
			{
				if (ExportInHumanReadableWay)
				{
					text = text + "; [NON-EDITABLE];;" + Environment.NewLine;
				}
				text = ((!ExportInHumanReadableWay) ? (text + "#Mothership;" + LandingPlanner.CurrentMothership.ObjectID + ";" + Environment.NewLine) : (text + "#Mothership;" + LandingPlanner.CurrentMothership.Name + ";" + Environment.NewLine));
				List<string> list = new List<string>();
				if (ExportInHumanReadableWay)
				{
					foreach (ActiveUnit key in LandingPlanner.AllowedTransport.Keys)
					{
						list.Add(key.Name);
					}
				}
				else
				{
					foreach (ActiveUnit key2 in LandingPlanner.AllowedTransport.Keys)
					{
						list.Add(key2.ObjectID);
					}
				}
				text = text + "#Transports;" + string.Join("|", list) + ";" + Environment.NewLine;
				if (ExportInHumanReadableWay)
				{
					text = text + ";;;" + Environment.NewLine;
					text = text + ";;;" + Environment.NewLine;
					text = text + "Zones;;;" + Environment.NewLine;
					text = text + ";Name  [NON-EDITABLE];Type  [NON-EDITABLE];" + Environment.NewLine;
				}
				foreach (KeyValuePair<LandingZoneWrapper, LandingZoneWrapper> assignedZone in LandingPlanner.AssignedZones)
				{
					if (assignedZone.Value.LandingZoneType != LandingType.Unassigned)
					{
						text = (ExportInHumanReadableWay ? (text + "#Zone;" + assignedZone.Key.LandingZone.Description + ";" + assignedZone.Value.LandingZoneType.ToString().ToLower() + ";" + Environment.NewLine) : (text + "#Zone;" + assignedZone.Key.LandingZone.ObjectID + ";" + assignedZone.Value.LandingZoneType.ToString().ToLower() + ";" + Environment.NewLine));
					}
				}
				if (ExportInHumanReadableWay)
				{
					text = text + ";;;" + Environment.NewLine;
					text = text + ";;;" + Environment.NewLine;
					text = text + "Serials;;;" + Environment.NewLine;
					text = text + ";Name  [NON-EDITABLE];Priority;Assigned Landing Zone" + Environment.NewLine;
				}
				foreach (KeyValuePair<Chalk, List<UnitLineWrapper>> item in LandingPlanner.ChalkContainer)
				{
					if (item.Value.Count > 0 && item.Value.ElementAt(0).ChalkUnit.LandingZone != null)
					{
						text = ((item.Key.Preboat != null) ? (ExportInHumanReadableWay ? (text + "#Serial;" + item.Key.Preboat.ActualTransport.Name + ";" + item.Value.ElementAt(0).ChalkUnit.Priority + ";" + item.Value.ElementAt(0).ChalkUnit.LandingZone.LandingZone.Description + ";" + Environment.NewLine) : (text + "#Serial;" + item.Key.Preboat.ActualTransport.Name + ";" + item.Value.ElementAt(0).ChalkUnit.Priority + ";" + item.Value.ElementAt(0).ChalkUnit.LandingZone.LandingZone.ObjectID + ";" + Environment.NewLine)) : (ExportInHumanReadableWay ? (text + "#Serial;" + item.Key.ID + ";" + item.Value.ElementAt(0).ChalkUnit.Priority + ";" + item.Value.ElementAt(0).ChalkUnit.LandingZone.LandingZone.Description + ";" + Environment.NewLine) : (text + "#Serial;" + item.Key.ID + ";" + item.Value.ElementAt(0).ChalkUnit.Priority + ";" + item.Value.ElementAt(0).ChalkUnit.LandingZone.LandingZone.ObjectID + ";" + Environment.NewLine)));
					}
				}
				string text2 = Path.Combine(CreateDestinationFolder_LandingPlanner(), "LandingPlan_" + LandingPlanner.CurrentMothership.Name);
				string text3 = "csv";
				int num = 0;
				string path = text2 + "." + text3;
				while (File.Exists(path))
				{
					num++;
					path = text2 + " - " + Conversions.ToString(num) + "." + text3;
				}
				File.WriteAllText(path, text);
				if (!ShowErrorLogAsPopup)
				{
					AddLogEntry("Landing plan was successfully exported : ", ParentDebugger, LogType.Success);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				AddLogEntry("Critical issue when exporting landing plan " + ex2.Message, ParentDebugger, LogType.Issue);
				ProjectData.ClearProjectError();
			}
			if (export_ImportFeedback != null && export_ImportFeedback.LV_Main.Items.Count > 0)
			{
				((Form)export_ImportFeedback).ShowDialog();
			}
			DarkMessageBox.ShowInformation("LandingPlan_" + LandingPlanner.CurrentMothership.Name + " was successfully saved.", "Landing plan saved");
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			AddLogEntry("Issue when loading landing plan : " + ex4.Message, ParentDebugger, LogType.Issue);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		ImportLandingPlan(null, LV_Log);
	}

	public static void Import_ProcessLandingPlanLine(string TheLine, LandingPlan_ImportWrapper landingplan, DarkListView ParentDebugger = null, DataObject_E? TypeToEvaluate = null)
	{
		if (string.IsNullOrEmpty(TheLine))
		{
			return;
		}
		string[] source = Strings.Split(TheLine, ";", -1, (CompareMethod)1);
		if (source.Count() != 0)
		{
			string text = source.ElementAt(0).ToLower();
			if (Operators.CompareString(text, "#serial", true) == 0 && (!TypeToEvaluate.HasValue || TypeToEvaluate.Value == DataObject_E.serial))
			{
				Import_ProcessLandingPlanLine_Serial(TheLine, landingplan, ParentDebugger);
			}
			else if (Operators.CompareString(text, "#transports", true) == 0 && (!TypeToEvaluate.HasValue || TypeToEvaluate.Value == DataObject_E.transport))
			{
				Import_ProcessLandingPlanLine_Transports(TheLine, landingplan, ParentDebugger);
			}
			else if (Operators.CompareString(text, "#transport", true) == 0 && (!TypeToEvaluate.HasValue || TypeToEvaluate.Value == DataObject_E.transportClass))
			{
				Import_ProcessLandingPlanLine_Transport(TheLine, landingplan, ParentDebugger);
			}
			else if (Operators.CompareString(text, "#zone", true) == 0 && (!TypeToEvaluate.HasValue || TypeToEvaluate.Value == DataObject_E.zone))
			{
				Import_ProcessLandingPlanLine_Zone(TheLine, landingplan, ParentDebugger);
			}
			else if (Operators.CompareString(text, "#mothership", true) == 0 && (!TypeToEvaluate.HasValue || TypeToEvaluate.Value == DataObject_E.mothership))
			{
				Import_ProcessLandingPlanLine_Mothership(TheLine, landingplan, ParentDebugger);
			}
		}
	}

	public static void Import_ProcessLandingPlanLine_Zone(string TheLine, LandingPlan_ImportWrapper landingplan, DarkListView ParentDebugger = null)
	{
		if (landingplan == null || landingplan.Mothership == null)
		{
			return;
		}
		List<string> list = Strings.Split(TheLine, ";", -1, (CompareMethod)1).ToList();
		if (list.Count < 3)
		{
			return;
		}
		list.RemoveAt(0);
		string text = list.ElementAt(0);
		Zone zone = null;
		if (string.IsNullOrEmpty(text))
		{
			AddLogEntry("A zone entry has an empty ID", ParentDebugger, LogType.Issue);
			return;
		}
		Side side = landingplan.Mothership.get_UnitSide(SetSideOnly: false);
		foreach (Zone standardZone in side.StandardZones)
		{
			if (Operators.CompareString(standardZone.ObjectID, text, true) == 0 || Operators.CompareString(standardZone.Description, text, true) == 0)
			{
				zone = standardZone;
			}
		}
		if (zone != null)
		{
			string text2 = list.ElementAt(1).ToLower();
			LandingZoneWrapper landingZoneWrapper = ((Operators.CompareString(text2, "amphibious", true) == 0) ? new LandingZoneWrapper(zone, LandingType.Amphibious) : ((Operators.CompareString(text2, "airborne", true) != 0) ? new LandingZoneWrapper(zone, LandingType.Unassigned) : new LandingZoneWrapper(zone, LandingType.Airborne)));
			if (!landingplan.LandingZones.ContainsKey(landingZoneWrapper.LandingZone))
			{
				landingplan.LandingZones.Add(landingZoneWrapper.LandingZone, landingZoneWrapper);
			}
		}
		else
		{
			AddLogEntry("Zone " + text + " not found in side " + side.Name, ParentDebugger, LogType.Issue);
		}
	}

	public static void Import_ProcessLandingPlanLine_Transport(string TheLine, LandingPlan_ImportWrapper landingplan, DarkListView ParentDebugger = null)
	{
		if (landingplan == null || landingplan.Mothership == null)
		{
			return;
		}
		List<string> list = Strings.Split(TheLine, ";", -1, (CompareMethod)1).ToList();
		if (list.Count >= 2)
		{
			list.RemoveAt(0);
			new HashSet<string>();
			string text = list.ElementAt(0);
			if (!string.IsNullOrEmpty(text) && !landingplan.AllowedTransportClasses.Contains(text))
			{
				landingplan.AllowedTransportClasses.Add(text);
			}
		}
	}

	public static void Import_ProcessLandingPlanLine_Transports(string TheLine, LandingPlan_ImportWrapper landingplan, DarkListView ParentDebugger = null)
	{
		if (landingplan == null || landingplan.Mothership == null)
		{
			return;
		}
		List<string> list = Strings.Split(TheLine, ";", -1, (CompareMethod)1).ToList();
		if (list.Count < 2)
		{
			return;
		}
		list.RemoveAt(0);
		string[] array = Strings.Split(list.ElementAt(0), "|", -1, (CompareMethod)1);
		List<ActiveUnit> list2 = new List<ActiveUnit>();
		if (array.Count() != 0)
		{
			string[] array2 = array;
			foreach (string text in array2)
			{
				ActiveUnit activeUnit = PrivateMethods.smethod_1(text, Client.CurrentScenario);
				if (activeUnit == null)
				{
					AddLogEntry("Transport ID " + text + " is not valid.", ParentDebugger, LogType.Issue);
				}
				else
				{
					list2.Add(activeUnit);
				}
			}
		}
		else
		{
			AddLogEntry("No transport has been allowed for this landing plan", ParentDebugger, LogType.Warning);
		}
		landingplan.AllowedTransports = list2;
	}

	public static void Import_ProcessLandingPlanLine_Serial(string TheLine, LandingPlan_ImportWrapper landingplan, DarkListView ParentDebugger = null)
	{
		if (landingplan == null || landingplan.Mothership == null)
		{
			return;
		}
		List<string> list = Strings.Split(TheLine, ";", -1, (CompareMethod)1).ToList();
		if (list.Count < 4)
		{
			return;
		}
		list.RemoveAt(0);
		Dictionary<LandingPlanSerialColumn_E, string> dictionary = new Dictionary<LandingPlanSerialColumn_E, string>();
		int num = list.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			dictionary.Add((LandingPlanSerialColumn_E)i, list[i]);
		}
		Dictionary<int, Chalk> dictionary2 = new Dictionary<int, Chalk>();
		foreach (Chalk chalk in landingplan.Mothership.get_UnitSide(SetSideOnly: false).Chalks)
		{
			if (Operators.CompareString(chalk.AssociatedMothership.ObjectID, landingplan.Mothership.ObjectID, true) == 0)
			{
				dictionary2.Add(chalk.ID, chalk);
			}
		}
		new Dictionary<Chalk, Zone>();
		ActiveUnit activeUnit = PrivateMethods.smethod_1(dictionary[LandingPlanSerialColumn_E.ID], Client.CurrentScenario);
		int result = default(int);
		if (activeUnit == null)
		{
			if (!int.TryParse(dictionary[LandingPlanSerialColumn_E.ID], out result))
			{
				AddLogEntry("Unable to parse serial ID " + dictionary[LandingPlanSerialColumn_E.ID], ParentDebugger, LogType.Issue);
			}
			else if (dictionary2.ContainsKey(result))
			{
				Chalk key = dictionary2[result];
				int result2 = 0;
				if (!int.TryParse(dictionary[LandingPlanSerialColumn_E.Priority], out result2))
				{
					AddLogEntry("Unable to parse serial priority " + dictionary[LandingPlanSerialColumn_E.Priority] + " for serial #" + result, ParentDebugger, LogType.Warning);
					result2 = 0;
				}
				Zone zone = null;
				if (!string.IsNullOrEmpty(dictionary[LandingPlanSerialColumn_E.Zone]))
				{
					foreach (Zone standardZone in landingplan.Mothership.get_UnitSide(SetSideOnly: false).StandardZones)
					{
						zone = standardZone;
						if (Operators.CompareString(zone.ObjectID, dictionary[LandingPlanSerialColumn_E.Zone], true) == 0 || Operators.CompareString(zone.Description, dictionary[LandingPlanSerialColumn_E.Zone], true) == 0)
						{
							zone = zone;
							break;
						}
					}
				}
				else
				{
					AddLogEntry("No zone defined for serial #" + result, ParentDebugger, LogType.Warning);
				}
				int num2;
				if (zone == null)
				{
					AddLogEntry("Zone ID" + dictionary[LandingPlanSerialColumn_E.Zone] + " defined for serial #" + result + " is not valid.", ParentDebugger, LogType.Warning);
					num2 = 3;
				}
				else
				{
					num2 = 3;
				}
				int num3 = num2;
				string text = result.ToString();
				landingplan.SerialAllowedTransportClasses.Add(text, new HashSet<string>());
				foreach (string allowedTransportClass in landingplan.AllowedTransportClasses)
				{
					if (num3 <= list.Count - 1)
					{
						if (HumanReadableString2Bool(list[num3]) && !landingplan.SerialAllowedTransportClasses[text].Contains(allowedTransportClass))
						{
							landingplan.SerialAllowedTransportClasses[text].Add(allowedTransportClass);
						}
						num3++;
						continue;
					}
					AddLogEntry("There are more transport columns in serial #" + text + " than the actual defined transport class count", ParentDebugger, LogType.Issue);
					break;
				}
				if (!landingplan.SerialToZoneAssociation.ContainsKey(key))
				{
					landingplan.SerialToZoneAssociation.Add(key, zone);
				}
				if (!landingplan.SerialToPriority.ContainsKey(key))
				{
					landingplan.SerialToPriority.Add(key, result2);
				}
			}
			else
			{
				AddLogEntry("Serial ID " + dictionary[LandingPlanSerialColumn_E.ID] + " is not part of mothership " + landingplan.Mothership.Name, ParentDebugger, LogType.Issue);
			}
			return;
		}
		Zone zone2 = null;
		if (!string.IsNullOrEmpty(dictionary[LandingPlanSerialColumn_E.Zone]))
		{
			foreach (Zone standardZone2 in landingplan.Mothership.get_UnitSide(SetSideOnly: false).StandardZones)
			{
				if (Operators.CompareString(standardZone2.ObjectID, dictionary[LandingPlanSerialColumn_E.Zone], true) == 0 || Operators.CompareString(standardZone2.Description, dictionary[LandingPlanSerialColumn_E.Zone], true) == 0)
				{
					zone2 = standardZone2;
					break;
				}
			}
		}
		else
		{
			AddLogEntry("No zone defined for preboated serial " + activeUnit.Name.ToString(), ParentDebugger, LogType.Warning);
		}
		if (zone2 == null)
		{
			AddLogEntry("Zone ID" + dictionary[LandingPlanSerialColumn_E.Zone] + " defined for serial #" + result + " is not valid.", ParentDebugger, LogType.Warning);
		}
		else
		{
			landingplan.Preboated.Add(activeUnit, zone2);
		}
	}

	public static void Import_ProcessLandingPlanLine_Mothership(string TheLine, LandingPlan_ImportWrapper landingplan, DarkListView ParentDebugger = null)
	{
		landingplan.Mothership = null;
		string[] source = Strings.Split(TheLine, ";", -1, (CompareMethod)1);
		if (source.Count() == 0)
		{
			return;
		}
		string text = source.ElementAt(1);
		if (string.IsNullOrEmpty(text))
		{
			AddLogEntry("Mothership ID is empty", ParentDebugger, LogType.Issue);
			return;
		}
		landingplan.Mothership = PrivateMethods.smethod_1(text, Client.CurrentScenario);
		if (landingplan.Mothership == null)
		{
			AddLogEntry("Mothership ID " + text + " is not valid.", ParentDebugger, LogType.Issue);
		}
	}

	private void ExportImportTool_Load(object sender, EventArgs e)
	{
		((Control)Button_ImportSerials).Visible = false;
		((Control)Button_ImportLandingPlan).Visible = false;
		CB_Serials.Checked = false;
	}

	static ExportImportTool()
	{
		Class72.smethod_20();
	}
}
