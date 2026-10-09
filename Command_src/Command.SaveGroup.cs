using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace Command;

[DesignerGenerated]
public sealed class SaveGroup : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _Button2;

	[AccessedThroughProperty("SaveFileDialog1")]
	[CompilerGenerated]
	private SaveFileDialog saveFileDialog_0;

	[AccessedThroughProperty("SaveAsTemplate")]
	[CompilerGenerated]
	private DarkUICheckBox _SaveAsTemplate;

	private Keys[] keys_0;

	private ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_0;

	private bool bool_2;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("TB_Name")]
	internal virtual DarkUITextBox TB_Name { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("TB_ValidFrom")]
	internal virtual DarkUITextBox TB_ValidFrom { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("TB_ValidUntil")]
	internal virtual DarkUITextBox TB_ValidUntil { get; set; }

	[field: AccessedThroughProperty("TB_Notes")]
	internal virtual DarkUITextBox TB_Notes { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

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
			EventHandler eventHandler = method_3;
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

	internal virtual DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _Button2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button2 = value;
			darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual SaveFileDialog SaveFileDialog1
	{
		[CompilerGenerated]
		get
		{
			return saveFileDialog_0;
		}
		[CompilerGenerated]
		set
		{
			saveFileDialog_0 = value;
		}
	}

	internal virtual DarkUICheckBox SaveAsTemplate
	{
		[CompilerGenerated]
		get
		{
			return _SaveAsTemplate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUICheckBox darkUICheckBox = _SaveAsTemplate;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged -= eventHandler;
			}
			_SaveAsTemplate = value;
			darkUICheckBox = _SaveAsTemplate;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	public SaveGroup()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += SaveGroup_Load;
		((Control)this).KeyDown += new KeyEventHandler(SaveGroup_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(SaveGroup_FormClosing);
		keys_0 = (Keys[])(object)new Keys[1] { (Keys)27 };
		bool_2 = false;
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
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		Label1 = new DarkLabel();
		TB_Name = new DarkUITextBox();
		Label2 = new DarkLabel();
		TB_ValidFrom = new DarkUITextBox();
		Label3 = new DarkLabel();
		TB_ValidUntil = new DarkUITextBox();
		TB_Notes = new DarkUITextBox();
		Label4 = new DarkLabel();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		SaveFileDialog1 = new SaveFileDialog();
		SaveAsTemplate = new DarkUICheckBox();
		((Control)this).SuspendLayout();
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(13, 13);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(55, 17);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Name:";
		((Control)TB_Name).Anchor = (AnchorStyles)15;
		TB_Name.AutoCompleteCustomSource = null;
		TB_Name.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Name.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Name).BackColor = Color.Transparent;
		((Control)TB_Name).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Name.Image = null;
		TB_Name.Lines = null;
		((Control)TB_Name).Location = new Point(78, 13);
		TB_Name.MaxLength = 32767;
		TB_Name.Multiline = false;
		((Control)TB_Name).Name = "TB_Name";
		TB_Name.ReadOnly = false;
		TB_Name.ScrollBars = (ScrollBars)0;
		TB_Name.SelectionStart = 0;
		((Control)TB_Name).Size = new Size(492, 27);
		((Control)TB_Name).TabIndex = 1;
		TB_Name.TextAlign = (HorizontalAlignment)0;
		TB_Name.UseSystemPasswordChar = false;
		TB_Name.WatermarkText = "";
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(12, 39);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(56, 26);
		((Control)Label2).TabIndex = 2;
		((Label)Label2).Text = "From:";
		((Control)TB_ValidFrom).Anchor = (AnchorStyles)15;
		TB_ValidFrom.AutoCompleteCustomSource = null;
		TB_ValidFrom.AutoCompleteMode = (AutoCompleteMode)0;
		TB_ValidFrom.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_ValidFrom).BackColor = Color.Transparent;
		((Control)TB_ValidFrom).ForeColor = Color.FromArgb(189, 189, 189);
		TB_ValidFrom.Image = null;
		TB_ValidFrom.Lines = null;
		((Control)TB_ValidFrom).Location = new Point(78, 36);
		TB_ValidFrom.MaxLength = 32767;
		TB_ValidFrom.Multiline = false;
		((Control)TB_ValidFrom).Name = "TB_ValidFrom";
		TB_ValidFrom.ReadOnly = false;
		TB_ValidFrom.ScrollBars = (ScrollBars)0;
		TB_ValidFrom.SelectionStart = 0;
		((Control)TB_ValidFrom).Size = new Size(492, 30);
		((Control)TB_ValidFrom).TabIndex = 3;
		TB_ValidFrom.TextAlign = (HorizontalAlignment)0;
		TB_ValidFrom.UseSystemPasswordChar = false;
		TB_ValidFrom.WatermarkText = "";
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(13, 65);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(59, 24);
		((Control)Label3).TabIndex = 4;
		((Label)Label3).Text = "Until:";
		((Control)TB_ValidUntil).Anchor = (AnchorStyles)15;
		TB_ValidUntil.AutoCompleteCustomSource = null;
		TB_ValidUntil.AutoCompleteMode = (AutoCompleteMode)0;
		TB_ValidUntil.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_ValidUntil).BackColor = Color.Transparent;
		((Control)TB_ValidUntil).ForeColor = Color.FromArgb(189, 189, 189);
		TB_ValidUntil.Image = null;
		TB_ValidUntil.Lines = null;
		((Control)TB_ValidUntil).Location = new Point(78, 62);
		TB_ValidUntil.MaxLength = 32767;
		TB_ValidUntil.Multiline = false;
		((Control)TB_ValidUntil).Name = "TB_ValidUntil";
		TB_ValidUntil.ReadOnly = false;
		TB_ValidUntil.ScrollBars = (ScrollBars)0;
		TB_ValidUntil.SelectionStart = 0;
		((Control)TB_ValidUntil).Size = new Size(491, 30);
		((Control)TB_ValidUntil).TabIndex = 5;
		TB_ValidUntil.TextAlign = (HorizontalAlignment)0;
		TB_ValidUntil.UseSystemPasswordChar = false;
		TB_ValidUntil.WatermarkText = "";
		((Control)TB_Notes).Anchor = (AnchorStyles)13;
		TB_Notes.AutoCompleteCustomSource = null;
		TB_Notes.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Notes.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Notes).BackColor = Color.Transparent;
		((Control)TB_Notes).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Notes.Image = null;
		TB_Notes.Lines = null;
		((Control)TB_Notes).Location = new Point(78, 88);
		TB_Notes.MaxLength = 32767;
		TB_Notes.Multiline = true;
		((Control)TB_Notes).Name = "TB_Notes";
		TB_Notes.ReadOnly = false;
		TB_Notes.ScrollBars = (ScrollBars)0;
		TB_Notes.SelectionStart = 0;
		((Control)TB_Notes).Size = new Size(491, 114);
		((Control)TB_Notes).TabIndex = 6;
		TB_Notes.TextAlign = (HorizontalAlignment)0;
		TB_Notes.UseSystemPasswordChar = false;
		TB_Notes.WatermarkText = "";
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(13, 89);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(55, 21);
		((Control)Label4).TabIndex = 7;
		((Label)Label4).Text = "Notes:";
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(210, 209);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(70, 37);
		((Control)Button1).TabIndex = 8;
		Button1.Text = "Save";
		((Control)Button2).Anchor = (AnchorStyles)9;
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Button)Button2).DialogResult = (DialogResult)2;
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(466, 209);
		((Control)Button2).Name = "Button2";
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(91, 37);
		((Control)Button2).TabIndex = 9;
		Button2.Text = "Cancel";
		((FileDialog)SaveFileDialog1).DefaultExt = "inst";
		((FileDialog)SaveFileDialog1).Filter = "Import/Export file (*.inst)|*.inst|All Files (*.*)|*.*";
		((FileDialog)SaveFileDialog1).InitialDirectory = "Installations";
		((ButtonBase)SaveAsTemplate).BackColor = Color.Transparent;
		((CheckBox)SaveAsTemplate).Checked = false;
		((Control)SaveAsTemplate).Cursor = Cursors.Hand;
		((Control)SaveAsTemplate).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)SaveAsTemplate).Location = new Point(17, 209);
		((Control)SaveAsTemplate).Name = "SaveAsTemplate";
		((Control)SaveAsTemplate).Size = new Size(177, 18);
		((Control)SaveAsTemplate).TabIndex = 10;
		((ButtonBase)SaveAsTemplate).Text = "Save as template";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).CancelButton = (IButtonControl)(object)Button2;
		((Form)this).ClientSize = new Size(582, 267);
		((Control)this).Controls.Add((Control)(object)SaveAsTemplate);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)TB_Notes);
		((Control)this).Controls.Add((Control)(object)TB_ValidUntil);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)TB_ValidFrom);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)TB_Name);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Form)this).FormBorderStyle = (FormBorderStyle)2;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "SaveGroup";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Export units/groups to file";
		((Control)this).ResumeLayout(false);
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		Keys[] array = keys_0;
		foreach (Keys val in array)
		{
			if (keyData == val)
			{
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
		}
		return false;
	}

	private void method_2(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void SaveGroup_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		readOnlyCollection_0 = Client.CurrentSide.SelectedUnits;
	}

	private void method_3(object sender, EventArgs e)
	{
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Invalid comparison between Unknown and I4
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ImportExportRecord importExportRecord = new ImportExportRecord();
			importExportRecord.Name = TB_Name.Text;
			importExportRecord.ValidFrom = TB_ValidFrom.Text;
			importExportRecord.ValidUntil = TB_ValidUntil.Text;
			importExportRecord.Comments = TB_Notes.Text;
			importExportRecord.DB_ID = Client.CurrentDB.DBID;
			importExportRecord.Template = bool_2;
			new XmlWriterSettings
			{
				Indent = true,
				IndentChars = "    ",
				ConformanceLevel = (ConformanceLevel)0
			};
			foreach (ActiveUnit item2 in readOnlyCollection_0.Where([SpecialName] (Module_Unit.Unit theU) => theU.IsActiveUnit).ToList())
			{
				if (item2.IsGroup)
				{
					ActiveUnit groupLead = ((Group)item2).GroupLead;
					ImportExportRecord.MemberRecord item = Client.CurrentScenario.ExportUnitsToIER(groupLead);
					importExportRecord.MemberRecords.Add(item);
					foreach (ActiveUnit value in ((Group)item2).Units.Values)
					{
						if (!value.IsGroupLead())
						{
							item = Client.CurrentScenario.ExportUnitsToIER(value);
							importExportRecord.MemberRecords.Add(item);
						}
					}
				}
				else
				{
					ImportExportRecord.MemberRecord item = Client.CurrentScenario.ExportUnitsToIER(item2);
					importExportRecord.MemberRecords.Add(item);
				}
			}
			((FileDialog)SaveFileDialog1).InitialDirectory = GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "ImportExport";
			if (bool_2)
			{
				((FileDialog)SaveFileDialog1).InitialDirectory = ((FileDialog)SaveFileDialog1).InitialDirectory + Conversions.ToString(Path.DirectorySeparatorChar) + "Templates";
				if (!Directory.Exists(((FileDialog)SaveFileDialog1).InitialDirectory))
				{
					Directory.CreateDirectory(((FileDialog)SaveFileDialog1).InitialDirectory);
				}
			}
			if ((int)((CommonDialog)SaveFileDialog1).ShowDialog() == 1)
			{
				StreamWriter streamWriter = new StreamWriter(((FileDialog)SaveFileDialog1).FileName);
				JsonSerializer jsonSerializer = new JsonSerializer();
				using (streamWriter)
				{
					JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter);
					jsonTextWriter.Formatting = Formatting.Indented;
					using (jsonTextWriter)
					{
						jsonSerializer.Serialize(jsonTextWriter, importExportRecord);
					}
				}
				((Form)this).Close();
				DarkMessageBox.ShowInformation("INST exported successfully.", "");
			}
			else
			{
				DarkMessageBox.ShowError(((Enum)((CommonDialog)SaveFileDialog1).ShowDialog()/*cast due to .constrained prefix*/).ToString(), "");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message);
			ex2?.Data.Add("Error at 1000405673", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_4(ref ActiveUnit activeUnit_0, ref ImportExportRecord.MemberRecord memberRecord_0)
	{
		if (activeUnit_0.AirOps.EmbarkedAircraft_ReadOnly.Count <= 0)
		{
			return;
		}
		foreach (Aircraft item2 in activeUnit_0.AirOps.EmbarkedAircraft_ReadOnly)
		{
			ImportExportRecord.HostedAircraftRecord item = new ImportExportRecord.HostedAircraftRecord(theLoadout_ID: (!Information.IsNothing((object)item2.Loadout)) ? item2.Loadout.DBID : 0, theName: item2.Name, theAC_DBID: item2.DBID, theReadyTime_Mins: (int)Math.Round(item2.AirOps.ConditionTimer / 60f));
			memberRecord_0.HostedAircraftRecords.Add(item);
		}
	}

	private void method_5(ref ActiveUnit activeUnit_0, ref ImportExportRecord.MemberRecord memberRecord_0)
	{
		if (activeUnit_0.DockingOps.EmbarkedBoats_ReadOnly.Count <= 0)
		{
			return;
		}
		foreach (ActiveUnit item2 in activeUnit_0.DockingOps.EmbarkedBoats_ReadOnly)
		{
			ImportExportRecord.EmbarkedBoatRecord item = new ImportExportRecord.EmbarkedBoatRecord(item2.Name, item2.DBID, (int)Math.Round(item2.DockingOps.ConditionTimer / 60f), item2.UnitType_String);
			memberRecord_0.EmbarkedBoatRecords.Add(item);
		}
	}

	private void method_6(ref ActiveUnit activeUnit_0, ref ImportExportRecord.MemberRecord memberRecord_0)
	{
		if (!(activeUnit_0.IsFacility | activeUnit_0.IsShip | activeUnit_0.IsSubmarine))
		{
			return;
		}
		Magazine[] sharedMagazines = activeUnit_0.SharedMagazines;
		foreach (Magazine magazine in sharedMagazines)
		{
			ImportExportRecord.MagazineRecord magazineRecord = new ImportExportRecord.MagazineRecord(magazine.Name, magazine.DBID);
			foreach (WeaponRec weapon in magazine.Weapons)
			{
				ImportExportRecord.WeaponRecord item = new ImportExportRecord.WeaponRecord(weapon.Name, weapon.int_3, weapon.MaxLoad, weapon.Multiple, weapon.CurrentLoad, (int)Math.Round(weapon.ReloadTime));
				magazineRecord.WeaponRecords.Add(item);
			}
			memberRecord_0.MagazineRecords.Add(magazineRecord);
		}
	}

	private void SaveGroup_KeyDown(object sender, KeyEventArgs e)
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

	private void SaveGroup_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_7(object sender, EventArgs e)
	{
		bool_2 = ((CheckBox)SaveAsTemplate).Checked;
	}

	static SaveGroup()
	{
		Class72.smethod_20();
	}
}
