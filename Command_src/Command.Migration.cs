using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Command_Core;
using Command_Core.LoadSave;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Migration : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _Button2;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_BatchRebuildManual")]
	private DarkUIButton _Button_BatchRebuildManual;

	[CompilerGenerated]
	[AccessedThroughProperty("FD_LoadINI")]
	private OpenFileDialog openFileDialog_0;

	[AccessedThroughProperty("FD_ManualSelect")]
	[CompilerGenerated]
	private OpenFileDialog openFileDialog_1;

	private string string_0;

	public DBRecord TargetDB;

	[field: AccessedThroughProperty("MigrationAllScenarios")]
	internal virtual DarkGroupBox MigrationAllScenarios { get; set; }

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
			EventHandler eventHandler = method_7;
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

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual DarkUITextBox TextBox1 { get; set; }

	[field: AccessedThroughProperty("MigrationSingleScenario")]
	internal virtual DarkGroupBox MigrationSingleScenario { get; set; }

	[field: AccessedThroughProperty("CB_ApplyINI")]
	internal virtual DarkCheckBox CB_ApplyINI { get; set; }

	[field: AccessedThroughProperty("CB_DeepRebuild")]
	internal virtual DarkCheckBox CB_DeepRebuild { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

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
			EventHandler eventHandler = method_6;
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

	internal virtual DarkUIButton Button_BatchRebuildManual
	{
		[CompilerGenerated]
		get
		{
			return _Button_BatchRebuildManual;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkUIButton darkUIButton = _Button_BatchRebuildManual;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_BatchRebuildManual = value;
			darkUIButton = _Button_BatchRebuildManual;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("CB_KeepOODA")]
	internal virtual DarkCheckBox CB_KeepOODA { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	[field: AccessedThroughProperty("Combo_Default_AAW_WRA_Range")]
	internal virtual DarkUIComboBox Combo_Default_AAW_WRA_Range { get; set; }

	[field: AccessedThroughProperty("LBL_AAW_DEF_RANGE")]
	internal virtual DarkLabel LBL_AAW_DEF_RANGE { get; set; }

	internal virtual OpenFileDialog FD_LoadINI
	{
		[CompilerGenerated]
		get
		{
			return openFileDialog_0;
		}
		[CompilerGenerated]
		set
		{
			openFileDialog_0 = value;
		}
	}

	internal virtual OpenFileDialog FD_ManualSelect
	{
		[CompilerGenerated]
		get
		{
			return openFileDialog_1;
		}
		[CompilerGenerated]
		set
		{
			openFileDialog_1 = value;
		}
	}

	public Migration()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		((Form)this).Load += Migration_Load;
		((Form)this).Shown += Migration_Shown;
		((Control)this).KeyDown += new KeyEventHandler(Migration_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(Migration_FormClosing);
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
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Expected O, but got Unknown
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0497: Expected O, but got Unknown
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_074f: Expected O, but got Unknown
		//IL_0bfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c08: Expected O, but got Unknown
		//IL_0c49: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Migration));
		MigrationAllScenarios = new DarkGroupBox();
		Button_BatchRebuildManual = new DarkUIButton();
		Label4 = new DarkLabel();
		Button2 = new DarkUIButton();
		Label3 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		MigrationSingleScenario = new DarkGroupBox();
		Combo_Default_AAW_WRA_Range = new DarkUIComboBox();
		LBL_AAW_DEF_RANGE = new DarkLabel();
		DarkLabel2 = new DarkLabel();
		CB_KeepOODA = new DarkCheckBox();
		DarkLabel1 = new DarkLabel();
		CB_ApplyINI = new DarkCheckBox();
		CB_DeepRebuild = new DarkCheckBox();
		Label1 = new DarkLabel();
		Label5 = new DarkLabel();
		Label2 = new DarkLabel();
		Button1 = new DarkUIButton();
		((Control)MigrationAllScenarios).SuspendLayout();
		((Control)MigrationSingleScenario).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)MigrationAllScenarios).Controls.Add((Control)(object)Button_BatchRebuildManual);
		((Control)MigrationAllScenarios).Controls.Add((Control)(object)Label4);
		((Control)MigrationAllScenarios).Controls.Add((Control)(object)Button2);
		((Control)MigrationAllScenarios).Controls.Add((Control)(object)Label3);
		((Control)MigrationAllScenarios).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)MigrationAllScenarios).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)MigrationAllScenarios).Location = new Point(12, 308);
		((Control)MigrationAllScenarios).Name = "MigrationAllScenarios";
		((Control)MigrationAllScenarios).Size = new Size(680, 73);
		((Control)MigrationAllScenarios).TabIndex = 7;
		((GroupBox)MigrationAllScenarios).TabStop = false;
		((GroupBox)MigrationAllScenarios).Text = "Batch-Rebuild Multiple Scenarios";
		((ButtonBase)Button_BatchRebuildManual).BackColor = Color.Transparent;
		((Control)Button_BatchRebuildManual).ForeColor = SystemColors.Control;
		((Control)Button_BatchRebuildManual).Location = new Point(388, 45);
		((Control)Button_BatchRebuildManual).Name = "Button_BatchRebuildManual";
		((Control)Button_BatchRebuildManual).Padding = new Padding(5);
		Button_BatchRebuildManual.RoundRadius = 0;
		((Control)Button_BatchRebuildManual).Size = new Size(231, 23);
		((Control)Button_BatchRebuildManual).TabIndex = 6;
		Button_BatchRebuildManual.Text = "Deep-Rebuild (select manually)";
		((Control)Label4).Anchor = (AnchorStyles)13;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(363, 15);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(313, 52);
		((Control)Label4).TabIndex = 5;
		((Label)Label4).Text = "Manually select multiple scenario files and perform deep-rebuild on them and apply INI files (if present)";
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Control)Button2).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(33, 45);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(239, 23);
		((Control)Button2).TabIndex = 4;
		Button2.Text = "Deep-Rebuild All Scenarios In List";
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(9, 16);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(313, 51);
		((Control)Label3).TabIndex = 2;
		((Label)Label3).Text = "Read scenarios from a 'scenario list' file, and perform deep-rebuild on them and apply INI files (if present)";
		((Control)TextBox1).Anchor = (AnchorStyles)15;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 10f);
		((Control)TextBox1).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(-2, 387);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = true;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = (ScrollBars)2;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(706, 260);
		((Control)TextBox1).TabIndex = 6;
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		TextBox1.WordWrap = false;
		((Control)MigrationSingleScenario).Controls.Add((Control)(object)Combo_Default_AAW_WRA_Range);
		((Control)MigrationSingleScenario).Controls.Add((Control)(object)LBL_AAW_DEF_RANGE);
		((Control)MigrationSingleScenario).Controls.Add((Control)(object)DarkLabel2);
		((Control)MigrationSingleScenario).Controls.Add((Control)(object)CB_KeepOODA);
		((Control)MigrationSingleScenario).Controls.Add((Control)(object)DarkLabel1);
		((Control)MigrationSingleScenario).Controls.Add((Control)(object)CB_ApplyINI);
		((Control)MigrationSingleScenario).Controls.Add((Control)(object)CB_DeepRebuild);
		((Control)MigrationSingleScenario).Controls.Add((Control)(object)Label1);
		((Control)MigrationSingleScenario).Controls.Add((Control)(object)Label5);
		((Control)MigrationSingleScenario).Controls.Add((Control)(object)Label2);
		((Control)MigrationSingleScenario).Controls.Add((Control)(object)Button1);
		((Control)MigrationSingleScenario).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)MigrationSingleScenario).Location = new Point(12, 11);
		((Control)MigrationSingleScenario).Name = "MigrationSingleScenario";
		((Control)MigrationSingleScenario).Size = new Size(680, 291);
		((Control)MigrationSingleScenario).TabIndex = 8;
		((GroupBox)MigrationSingleScenario).TabStop = false;
		((GroupBox)MigrationSingleScenario).Text = "Rebuild Current Scenario";
		((ComboBox)Combo_Default_AAW_WRA_Range).BackColor = Color.Transparent;
		((ComboBox)Combo_Default_AAW_WRA_Range).DrawMode = (DrawMode)1;
		((ComboBox)Combo_Default_AAW_WRA_Range).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_Default_AAW_WRA_Range).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_Default_AAW_WRA_Range).FormattingEnabled = true;
		((Control)Combo_Default_AAW_WRA_Range).Location = new Point(463, 256);
		((Control)Combo_Default_AAW_WRA_Range).Name = "Combo_Default_AAW_WRA_Range";
		((Control)Combo_Default_AAW_WRA_Range).Size = new Size(196, 21);
		((Control)Combo_Default_AAW_WRA_Range).TabIndex = 10;
		LBL_AAW_DEF_RANGE.AutoSize = true;
		((Control)LBL_AAW_DEF_RANGE).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LBL_AAW_DEF_RANGE).Location = new Point(460, 238);
		((Control)LBL_AAW_DEF_RANGE).Name = "LBL_AAW_DEF_RANGE";
		((Control)LBL_AAW_DEF_RANGE).Size = new Size(171, 15);
		((Control)LBL_AAW_DEF_RANGE).TabIndex = 9;
		((Label)LBL_AAW_DEF_RANGE).Text = "Default AA Missile WRA Range:";
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(6, 201);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(668, 35);
		((Control)DarkLabel2).TabIndex = 8;
		((Label)DarkLabel2).Text = componentResourceManager.GetString("DarkLabel2.Text");
		((ButtonBase)CB_KeepOODA).AutoSize = true;
		((Control)CB_KeepOODA).Location = new Point(299, 237);
		((Control)CB_KeepOODA).Name = "CB_KeepOODA";
		((Control)CB_KeepOODA).Size = new Size(143, 19);
		((Control)CB_KeepOODA).TabIndex = 6;
		((ButtonBase)CB_KeepOODA).Text = "Preserve OODA Values";
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(6, 166);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(668, 35);
		((Control)DarkLabel1).TabIndex = 5;
		((Label)DarkLabel1).Text = componentResourceManager.GetString("DarkLabel1.Text");
		((ButtonBase)CB_ApplyINI).AutoSize = true;
		((Control)CB_ApplyINI).Location = new Point(193, 237);
		((Control)CB_ApplyINI).Name = "CB_ApplyINI";
		((Control)CB_ApplyINI).Size = new Size(96, 19);
		((Control)CB_ApplyINI).TabIndex = 4;
		((ButtonBase)CB_ApplyINI).Text = "Apply INI File";
		((ButtonBase)CB_DeepRebuild).AutoSize = true;
		((Control)CB_DeepRebuild).Location = new Point(53, 237);
		((Control)CB_DeepRebuild).Name = "CB_DeepRebuild";
		((Control)CB_DeepRebuild).Size = new Size(130, 19);
		((Control)CB_DeepRebuild).TabIndex = 3;
		((ButtonBase)CB_DeepRebuild).Text = "Force Deep-Rebuild";
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(6, 16);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(668, 63);
		((Control)Label1).TabIndex = 1;
		((Label)Label1).Text = componentResourceManager.GetString("Label1.Text");
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(6, 130);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(668, 32);
		((Control)Label5).TabIndex = 2;
		((Label)Label5).Text = componentResourceManager.GetString("Label5.Text");
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(6, 79);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(668, 47);
		((Control)Label2).TabIndex = 2;
		((Label)Label2).Text = componentResourceManager.GetString("Label2.Text");
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(208, 262);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(217, 23);
		((Control)Button1).TabIndex = 3;
		Button1.Text = "I understand - Rebuild Current Scenario";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).AutoScroll = true;
		((Form)this).AutoSize = true;
		((Form)this).ClientSize = new Size(704, 644);
		((Control)this).Controls.Add((Control)(object)MigrationAllScenarios);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Controls.Add((Control)(object)MigrationSingleScenario);
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MaximumSize = new Size(720, 683);
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(720, 683);
		((Control)this).Name = "Migration";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Scenario Migration";
		((Control)MigrationAllScenarios).ResumeLayout(false);
		((Control)MigrationSingleScenario).ResumeLayout(false);
		((Control)MigrationSingleScenario).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void method_2()
	{
		((ComboBox)Combo_Default_AAW_WRA_Range).Items.Clear();
		((ComboBox)Combo_Default_AAW_WRA_Range).Items.Add((object)"Default (max range)");
		((ComboBox)Combo_Default_AAW_WRA_Range).Items.Add((object)"75% of max");
		((ComboBox)Combo_Default_AAW_WRA_Range).Items.Add((object)"50% of max");
		((ComboBox)Combo_Default_AAW_WRA_Range).Items.Add((object)"25% of max");
		((ComboBox)Combo_Default_AAW_WRA_Range).Items.Add((object)"No-Escape Zone");
		((ComboBox)Combo_Default_AAW_WRA_Range).SelectedIndex = 0;
	}

	private void method_3(int int_0)
	{
		switch (int_0)
		{
		case -97:
			((ComboBox)Combo_Default_AAW_WRA_Range).SelectedIndex = 1;
			break;
		case -96:
			((ComboBox)Combo_Default_AAW_WRA_Range).SelectedIndex = 2;
			break;
		case -95:
			((ComboBox)Combo_Default_AAW_WRA_Range).SelectedIndex = 3;
			break;
		case -102:
			((ComboBox)Combo_Default_AAW_WRA_Range).SelectedIndex = 4;
			break;
		}
	}

	private Doctrine._WRA_FiringRange method_4()
	{
		return ((ComboBox)Combo_Default_AAW_WRA_Range).SelectedIndex switch
		{
			1 => Doctrine._WRA_FiringRange.Range75Percent, 
			2 => Doctrine._WRA_FiringRange.Range50Percent, 
			3 => Doctrine._WRA_FiringRange.Range25Percent, 
			4 => Doctrine._WRA_FiringRange.NoEscapeZone, 
			_ => Doctrine._WRA_FiringRange.NotConfigured, 
		};
	}

	private void Migration_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		method_2();
	}

	private void Migration_Shown(object sender, EventArgs e)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		DBOps.DBFileCheckResult theResult = default(DBOps.DBFileCheckResult);
		if (TargetDB == null)
		{
			TargetDB = DBOps.GetDBRecordByHash(DBOps.GetHashForMostRecentVersionOfThisDB(Client.CurrentDB.DBID), ref theResult);
		}
		if (TargetDB == null)
		{
			DarkMessageBox.ShowError("Error while preparing to migrate:" + Conversions.ToString((int)theResult) + "\r\nAborting...", "Error");
		}
		string_0 = TargetDB.FileName;
		((Form)this).Text = "Scenario Migration (Selected DB: " + string_0 + ")";
		method_3((int)Client.CurrentScenario.DefaultGuidedWeaponsVsAirTargetWRASetting);
	}

	private static void smethod_0(Scenario scenario_0, Doctrine._WRA_FiringRange _WRA_FiringRange_0)
	{
		if (scenario_0 != null)
		{
			scenario_0.DefaultGuidedWeaponsVsAirTargetWRASetting = _WRA_FiringRange_0;
		}
	}

	private static void smethod_1(Scenario scenario_0)
	{
		if (scenario_0 == null)
		{
			return;
		}
		foreach (ActiveUnit item in scenario_0.ActiveUnits.Values.ToList())
		{
			item.HasCustomOODA = true;
		}
	}

	private unsafe void method_5()
	{
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Invalid comparison between Unknown and I4
		//IL_0515: Unknown result type (might be due to invalid IL or missing references)
		//IL_0518: Invalid comparison between Unknown and I4
		//IL_0728: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fc: Unknown result type (might be due to invalid IL or missing references)
		bool flag = ((CheckBox)CB_KeepOODA).Checked;
		Doctrine._WRA_FiringRange wRA_FiringRange_ = method_4();
		TextBox1.Text = "Beginning migration... \r\n\r\n";
		DarkUITextBox textBox;
		(textBox = TextBox1).Text = textBox.Text + "Saving copy of current scenario to [" + GameGeneral.ScenariosRootPath + Conversions.ToString(Path.DirectorySeparatorChar) + Client.CurrentScenario.FileName + ".OLD]... ";
		((Control)TextBox1).Update();
		if (flag)
		{
			smethod_1(Client.CurrentScenario);
		}
		smethod_0(Client.CurrentScenario, wRA_FiringRange_);
		Client.SaveCurrentScenario(SBR: true, GameGeneral.ScenariosRootPath + Conversions.ToString(Path.DirectorySeparatorChar) + Client.CurrentScenario.FileName + ".OLD");
		if (flag)
		{
			TextBox1.Text += "Original OODA values preserved... ";
		}
		TextBox1.Text += "Done.\r\n\r\n";
		TextBox1.Text += "Switching DB version to selected... ";
		((Control)TextBox1).Update();
		Client.SwitchDB(TargetDB.Hash);
		TextBox1.Text += "Done.\r\n\r\n";
		TextBox1.Text += "Autosaving... ";
		((Control)TextBox1).Update();
		if (!((CheckBox)CB_DeepRebuild).Checked)
		{
			SBR.InProgress = true;
		}
		LoadSave.SaveScenario(Client.CurrentScenario, Client.CurrentScenario.Sides_ReadOnly[0], GameGeneral.ScenariosRootPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR.scen", SBR: false);
		TextBox1.Text += "Done.\r\n\r\n";
		TextBox1.Text += "Re-loading migrated scenario... ";
		((Control)TextBox1).Update();
		Scenario theScen = Client.CurrentScenario;
		Game._GameMode gameMode = theScen.GameContext.GameMode;
		GameGeneral.DestroyPreviousScenario(ref theScen, ClearLuaSandbox: false);
		theScen = null;
		ScenContainer scenContainer = ScenContainer.LoadFromFile(GameGeneral.ScenariosRootPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR.scen");
		string ErrorFeedback = "";
		Scenario scenarioObject = scenContainer.GetScenarioObject(ref ErrorFeedback, null, ((CheckBox)CB_DeepRebuild).Checked);
		SBR.InProgress = false;
		TextBox1.Text += "Done.\r\n\r\n";
		((Control)TextBox1).Update();
		GameGeneral.Debug_LastLoadedScenario = scenarioObject.Title;
		string text;
		if (((CheckBox)CB_ApplyINI).Checked)
		{
			TextBox1.Text += "Select INI configuration file... ";
			((Control)TextBox1).Update();
			FD_LoadINI = new OpenFileDialog();
			((FileDialog)FD_LoadINI).InitialDirectory = scenarioObject.FileNamePath;
			((FileDialog)FD_LoadINI).FileName = "*.ini";
			DialogResult val = ((CommonDialog)FD_LoadINI).ShowDialog((IWin32Window)(object)this);
			if ((int)val == 1)
			{
				TextBox1.Text += "Done.\r\n\r\n";
				(textBox = TextBox1).Text = textBox.Text + "Applying INI configuration from [" + ((FileDialog)FD_LoadINI).FileName + "]... ";
				((Control)TextBox1).Update();
				if (!Directory.Exists(GameGeneral.LogsPath))
				{
					Directory.CreateDirectory(GameGeneral.LogsPath);
				}
				text = "\r\n\r\nScenario : " + scenarioObject.Title + "\r\nConfig file: " + ((FileDialog)FD_LoadINI).FileName;
				StreamWriter streamWriter = File.AppendText(Path.Combine(GameGeneral.SBRLogFilePath));
				streamWriter.Write("\r\n\r\n" + text);
				streamWriter.Close();
				SBR.ApplyScriptToScenario(scenarioObject, ((FileDialog)FD_LoadINI).FileName, IsUnitCloningOperation: false);
				text = "Scenario " + scenarioObject.Title + ": Rebuild Completed";
				StreamWriter streamWriter2 = File.AppendText(Path.Combine(GameGeneral.SBRLogFilePath));
				streamWriter2.Write("\r\n" + text);
				streamWriter2.Close();
				foreach (ActiveUnit activeUnits_ in scenarioObject.ActiveUnits_List)
				{
					if (!Information.IsNothing((object)activeUnits_))
					{
						activeUnits_.RestoreOldComponentIDs();
					}
				}
				LoadSave.SaveScenario(scenarioObject, scenarioObject.Sides_ReadOnly[0], GameGeneral.ScenariosRootPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR.scen", SBR: true);
				theScen = Client.CurrentScenario;
				GameGeneral.DestroyPreviousScenario(ref theScen, ClearLuaSandbox: false);
				theScen = null;
				ScenContainer scenContainer2 = ScenContainer.LoadFromFile(GameGeneral.ScenariosRootPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR.scen");
				ErrorFeedback = "";
				scenarioObject = scenContainer2.GetScenarioObject(ref ErrorFeedback, null, ForceDeepRebuild: false);
				TextBox1.Text += "Done.\r\n\r\n";
			}
			else if ((int)val == 2)
			{
				TextBox1.Text += "Aborted by user.\r\n\r\n";
			}
			else
			{
				(textBox = TextBox1).Text = textBox.Text + "Failed (" + ((Enum)(*(DialogResult*)(&val))/*cast due to .constrained prefix*/).ToString() + ")\r\n\r\n";
			}
			((Control)TextBox1).Update();
		}
		TextBox1.Text += "Verifying update... ";
		((Control)TextBox1).Update();
		text = "\r\n\r\nScenario : " + scenarioObject.Title;
		StreamWriter streamWriter3 = File.AppendText(Path.Combine(GameGeneral.LogsPath, "SBR plaform list.txt"));
		streamWriter3.Write("\r\n\r\n" + text);
		streamWriter3.Close();
		SBR.GenerateScenarioContentsList(scenarioObject);
		foreach (ActiveUnit activeUnits_2 in scenarioObject.ActiveUnits_List)
		{
			activeUnits_2?.Sensory.vmethod_2(activeUnits_2.Sensors_Cached);
		}
		text = "Scenario " + scenarioObject.Title + ": Rebuild Completed";
		StreamWriter streamWriter4 = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
		streamWriter4.Write(text);
		streamWriter4.Close();
		List<string> list = SBR.CheckForAircraftCarryingIllegalLoadouts(scenarioObject);
		if (list.Count > 0)
		{
			text = "Scenario " + scenarioObject.Title + ": WARNING - ONE OR MORE AIRCRAFT FEATURED IN THIS SCENARIO CARRY A LOADOUT THAT IS NOT IN THE AIRCRAFT'S LOADOUT LIST.\r\n  PLATFORMS ARE AS FOLLOWS:\r\n";
			foreach (string item in list)
			{
				text = text + "  " + item + "\r\n";
			}
			StreamWriter streamWriter5 = File.AppendText(Path.Combine(GameGeneral.LogsPath, "SBR illegal loadouts.txt"));
			streamWriter5.Write("\r\n" + text + "\r\n--------------------------------------------");
			streamWriter5.Close();
			text += "  Please contact the author of this DB in order to have this problem rectified.\r\n";
			DarkMessageBox.ShowWarning(text, "Missing platforms from new DB!");
		}
		List<string> list2 = new List<string>();
		Side[] sides_ReadOnly = scenarioObject.Sides_ReadOnly;
		for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
		{
			Side theside = sides_ReadOnly[i];
			if (theside.Missions == null)
			{
				continue;
			}
			foreach (Mission item2 in theside.get_MissionsTotal(scenarioObject))
			{
				Mission theMission = item2;
				list2.AddRange(scenarioObject.CheckForAircraftNotTakingOffDueToFlightSizeRestrictions(ref theside, ref theMission));
			}
		}
		if (list2.Count > 0)
		{
			text = "WARNING: SOME AIRCRAFT IN THIS SCENARIO WILL NOT BE ABLE TO TAKE OFF DUE TO THE MISSION'S FLIGHT SIZE RESTRICTIONS!\r\n\r\nTo rectify this, you can change the flight size of the mission, add more aircraft to the mission, change loadouts on existing aircraft so there are enough aircraft armed with identical loadouts, or uncheck the flag Aircraft numbers below Flight Size do not take off.\r\n\r\n";
			foreach (string item3 in list2)
			{
				text = text + "\r\n" + item3;
			}
			DarkMessageBox.ShowWarning(text, "Missing platforms from new DB!");
		}
		TextBox1.Text += "Done.\r\n\r\n";
		((Control)TextBox1).Update();
		if (scenarioObject.LoadingNotices.Count > 0)
		{
			TextBox1.Text += "Notices:\r\n";
			TextBox1.Text += "--------\r\n";
			foreach (string loadingNotice in Client.CurrentScenario.LoadingNotices)
			{
				(textBox = TextBox1).Text = textBox.Text + loadingNotice + "\r\n";
			}
			TextBox1.Text += "--------\r\n";
			((Control)TextBox1).Update();
		}
		scenarioObject.FeatureCompatibility = default(Scenario._FeatureCompatibility);
		Client.CurrentGame.GameMode = gameMode;
		Client.SetCurrentScenario(scenarioObject, bool_10: false);
		Client.CurrentGame.Pause();
		(textBox = TextBox1).Text = textBox.Text + "All done! The scenario has been migrated to database version: " + TargetDB.DBName + ". You can now close this window.";
		((Control)TextBox1).Update();
	}

	private void method_6(object sender, EventArgs e)
	{
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		if (Client.CurrentScenario.Sides_ReadOnly.Any())
		{
			string hash = TargetDB.Hash;
			List<string> list = SBR.CheckForPlatFormsMissingFromDB(Client.CurrentScenario, hash, !((CheckBox)CB_DeepRebuild).Checked);
			if (list.Count <= 0)
			{
				list.Clear();
				list = null;
				method_5();
				return;
			}
			string text = "One or more platforms featured in this scenario are missing from the DB you are attempting to migrate to. The missing platforms are as follows:\r\n\r\n";
			foreach (string item in list)
			{
				text = text + item + "\r\n";
			}
			text += "\r\n";
			text += "Please contact the author of this DB in order to have this problem rectified. The platform(s) have been deleted from the new database.\r\n\r\n";
			text += "...MIGRATION ABORTED...";
			DarkMessageBox.ShowError(text, "Missing platforms from new DB!");
		}
		else
		{
			DarkMessageBox.ShowError("The scenario must have at least one side present!", "No side present");
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Invalid comparison between Unknown and I4
		bool preserveOODA = ((CheckBox)CB_KeepOODA).Checked;
		Doctrine._WRA_FiringRange defaultAAMissileWRAFiringRange = method_4();
		TextBox1.Text = "Select scenario list file... ";
		Application.DoEvents();
		FD_LoadINI = new OpenFileDialog();
		((FileDialog)FD_LoadINI).InitialDirectory = GameGeneral.ScenariosRootPath;
		if ((int)((CommonDialog)FD_LoadINI).ShowDialog() == 1)
		{
			TextBox1.Text += "Done!\r\n\r\n";
			Application.DoEvents();
			DarkUITextBox textBox;
			(textBox = TextBox1).Text = textBox.Text + "Starting rebuilding all scenarios listed in '" + ((FileDialog)FD_LoadINI).FileName + "'.\r\n\r\n";
			Application.DoEvents();
			AllInOne(((FileDialog)FD_LoadINI).FileName, preserveOODA, defaultAAMissileWRAFiringRange);
			(textBox = TextBox1).Text = textBox.Text + "Rebuilding done! Please check '" + GameGeneral.SBRLogFilePath + " for errors.\r\n\r\n";
			Application.DoEvents();
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Invalid comparison between Unknown and I4
		bool bool_ = ((CheckBox)CB_KeepOODA).Checked;
		Doctrine._WRA_FiringRange wRA_FiringRange_ = method_4();
		TextBox1.Text = "Select scenario files... ";
		Application.DoEvents();
		FD_ManualSelect = new OpenFileDialog();
		((FileDialog)FD_ManualSelect).InitialDirectory = GameGeneral.ScenariosRootPath;
		FD_ManualSelect.Multiselect = true;
		if ((int)((CommonDialog)FD_ManualSelect).ShowDialog() == 1)
		{
			DarkUITextBox textBox;
			(textBox = TextBox1).Text = textBox.Text + Conversions.ToString(((FileDialog)FD_ManualSelect).FileNames.Length) + " files selected\r\n\r\n";
			Application.DoEvents();
			TextBox1.Text += "Starting rebuilding all selected scenarios.\r\n\r\n";
			Application.DoEvents();
			int int_ = 0;
			string[] fileNames = ((FileDialog)FD_ManualSelect).FileNames;
			foreach (string text in fileNames)
			{
				string string_ = Path.GetDirectoryName(text) + Conversions.ToString(Path.DirectorySeparatorChar) + Path.GetFileNameWithoutExtension(Path.GetFullPath(text)) + ".ini";
				int_++;
				smethod_2(text, string_, ref int_, bool_, wRA_FiringRange_);
			}
			(textBox = TextBox1).Text = textBox.Text + "Rebuilding done! Please check '" + GameGeneral.SBRLogFilePath + " for errors.\r\n\r\n";
			Application.DoEvents();
		}
	}

	public static void AllInOne(string theFileName, bool PreserveOODA = false, Doctrine._WRA_FiringRange DefaultAAMissileWRAFiringRange = Doctrine._WRA_FiringRange.NotConfigured)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		FileStream fileStream = new FileStream(theFileName, FileMode.Open, FileAccess.Read);
		XmlDocument val = new XmlDocument();
		try
		{
			using (fileStream)
			{
				try
				{
					val.Load((Stream)fileStream);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					DarkMessageBox.ShowError("Scenario List file is improperly formatted, read failed!", "Error");
					ProjectData.ClearProjectError();
				}
			}
			XmlNode val2 = ((XmlNode)val).SelectSingleNode("/ScenarioList");
			if (val2 != null)
			{
				XmlNodeList childNodes = val2.ChildNodes;
				{
					IEnumerator enumerator = childNodes.GetEnumerator();
					try
					{
						string text2 = default(string);
						string text3 = default(string);
						int int_ = default(int);
						while (true)
						{
							if (!enumerator.MoveNext())
							{
								return;
							}
							XmlNode val3 = (XmlNode)enumerator.Current;
							if (Client.ShutdownInitiated)
							{
								break;
							}
							try
							{
								foreach (XmlNode childNode in val3.ChildNodes)
								{
									XmlNode val4 = childNode;
									string text = val4.Name.Split(new char[1] { '_' })[0];
									if (Operators.CompareString(text, "ScenarioFilePath", true) == 0)
									{
										try
										{
											foreach (XmlNode childNode2 in val4.ChildNodes)
											{
												XmlNode val5 = childNode2;
												if (Operators.CompareString(val5.Name.Split(new char[1] { '_' })[0], "#comment", true) == 0)
												{
													text2 = val5.InnerText;
													text2 = text2.Trim();
													Application.DoEvents();
												}
											}
										}
										catch (Exception projectError2)
										{
											ProjectData.SetProjectError(projectError2);
											DarkMessageBox.ShowError("No scenario file path found.", "Error");
											ProjectData.ClearProjectError();
										}
									}
									else
									{
										if (Operators.CompareString(text, "ConfigFilePath", true) != 0)
										{
											continue;
										}
										try
										{
											foreach (XmlNode childNode3 in val4.ChildNodes)
											{
												XmlNode val6 = childNode3;
												if (Operators.CompareString(val6.Name.Split(new char[1] { '_' })[0], "#comment", true) == 0)
												{
													text3 = val6.InnerText;
													text3 = text3.Trim();
												}
											}
										}
										catch (Exception projectError3)
										{
											ProjectData.SetProjectError(projectError3);
											DarkMessageBox.ShowError("No config file path found.", "Error");
											ProjectData.ClearProjectError();
										}
									}
								}
								int_++;
								Client.SetAllowCoreUIMessages(allow: false);
								smethod_2(text2, text3, ref int_, PreserveOODA, DefaultAAMissileWRAFiringRange);
								Client.SetAllowCoreUIMessages(allow: true);
								DBCache.ClearCache();
								Terrain.ClearCache();
								GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
								Thread.Sleep(0);
							}
							catch (Exception projectError4)
							{
								ProjectData.SetProjectError(projectError4);
								string text4 = "Scenario " + Conversions.ToString(int_) + ": ERROR: LOAD FAILED!";
								File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n\r\n" + text4);
								ProjectData.ClearProjectError();
							}
						}
						File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n\r\nSCENARIO MIGRATION TERMINATED DUE TO APP SHUTDOWN.");
						return;
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
			DarkMessageBox.ShowError("No XML data found.", "Error");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101120", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			Client.bool_4 = true;
		}
	}

	private static void smethod_2(string string_1, string string_2, ref int int_0, bool bool_2 = false, Doctrine._WRA_FiringRange _WRA_FiringRange_0 = Doctrine._WRA_FiringRange.NotConfigured)
	{
		//IL_04db: Unknown result type (might be due to invalid IL or missing references)
		Scenario scenarioObject = default(Scenario);
		if (FileExistsNative.FileExistsFast(string_1))
		{
			ScenContainer scenContainer = ScenContainer.LoadFromFile(string_1);
			string ErrorFeedback = "";
			scenarioObject = scenContainer.GetScenarioObject(ref ErrorFeedback, null, ForceDeepRebuild: false);
			if (bool_2)
			{
				smethod_1(scenarioObject);
			}
			smethod_0(scenarioObject, _WRA_FiringRange_0);
			string text = "Scenario " + Conversions.ToString(int_0) + ": " + scenarioObject.Title + "\r\nScenario file: " + string_1 + "\r\nConfig file:   " + string_2;
			File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n\r\n" + text);
			File.AppendAllText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt", "\r\n\r\n" + text);
			DBOps.DBFileCheckResult theResult = default(DBOps.DBFileCheckResult);
			DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(scenarioObject.DBUsed, ref theResult);
			if (Information.IsNothing((object)dBRecordByHash))
			{
				Interaction.MsgBox((object)("Error: " + DBOps.EnglishMessageString(theResult) + "\r\nAborting..."), (MsgBoxStyle)0, (object)null);
				return;
			}
			_ = scenarioObject.DBUsed;
			string dBHash = (scenarioObject.DBUsed = DBOps.GetHashForMostRecentVersionOfThisDB(dBRecordByHash.DBID));
			List<string> list = SBR.CheckForPlatFormsMissingFromDB(scenarioObject, dBHash, IncludeWeapons: false);
			if (list.Count > 0)
			{
				text = "  ERROR: ONE OR MORE PLATFORMS FEATURED IN THIS SCENARIO IS MISSING FROM THE DATABASE YOU ARE ATTEMPTING TO MIGRATE TO.\r\n  THE MISSING PLATFORMS ARE AS FOLLOWS:\r\n";
				foreach (string item in list)
				{
					text = text + "  " + item + "\r\n";
				}
				text += "  Please contact the author of this DB in order to have this problem rectified. The unit(s) have to be deleted and replaced with units that actually exist in the database.\r\n";
				text += "  MIGRATION ABORTED!";
				File.AppendAllText(GameGeneral.SBRLogFilePath, text);
				text = "Scenario " + Conversions.ToString(int_0) + ": ERROR: REBUILD FAILED!";
				File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n\r\n" + text);
				return;
			}
			scenarioObject.LastSavedInScenEdit = true;
			LoadSave.SaveScenario(scenarioObject, scenarioObject.Sides_ReadOnly[0], string_1, SBR: true);
			Scenario theScen = scenarioObject;
			if (!Information.IsNothing((object)theScen))
			{
				GameGeneral.DestroyPreviousScenario(ref theScen, ClearLuaSandbox: false);
			}
			scenarioObject = null;
			theScen = null;
			ScenContainer scenContainer2 = ScenContainer.LoadFromFile(string_1);
			ErrorFeedback = "";
			scenarioObject = scenContainer2.GetScenarioObject(ref ErrorFeedback, null, ForceDeepRebuild: true);
			List<string> list2 = SBR.CheckForAircraftCarryingIllegalLoadouts(scenarioObject);
			if (list2.Count > 0)
			{
				text = "  ERROR: ONE OR MORE AIRCRAFT FEATURED IN THIS SCENARIO CARRY A LOADOUT THAT IS NOT IN THE AIRCRAFT'S LOADOUT LIST.\r\n  PLATFORMS ARE AS FOLLOWS:\r\n";
				foreach (string item2 in list2)
				{
					text = text + "  " + item2 + "\r\n";
				}
				text += "  Please contact the author of this DB in order to have this problem rectified.";
				File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n" + text);
			}
			List<string> list3 = new List<string>();
			Side[] sides_ReadOnly = scenarioObject.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
			{
				Side theside = sides_ReadOnly[i];
				if (Information.IsNothing((object)theside.Missions))
				{
					continue;
				}
				foreach (Mission item3 in theside.get_MissionsTotal(scenarioObject))
				{
					Mission theMission = item3;
					list3.AddRange(scenarioObject.CheckForAircraftNotTakingOffDueToFlightSizeRestrictions(ref theside, ref theMission));
				}
			}
			if (list3.Count > 0)
			{
				text = "  WARNING: SOME AIRCRAFT IN THIS SCENARIO WILL NOT BE ABLE TO TAKE OFF DUE TO THE MISSION'S FLIGHT SIZE RESTRICTIONS!\r\n  To rectify this, you can change the flight size of the mission, add more aircraft to the mission, change loadouts on existing aircraft so there are enough aircraft armed with identical loadouts, or uncheck the flag Aircraft numbers below Flight Size do not take off.\r\n";
				foreach (string item4 in list3)
				{
					text = text + "\r\n    " + item4;
				}
				File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n" + text);
			}
			text = "";
			Client.ValidateScenarioAreas(scenarioObject, UseSBR: true, ref text);
			if (!string.IsNullOrEmpty(text))
			{
				text = "  ERROR: SOME AREAS IN THIS SCENARIO HAS PROBLEMS!\r\n" + text;
				File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n" + text);
			}
			if (FileExistsNative.FileExistsFast(string_2))
			{
				SBR.ApplyScriptToScenario(scenarioObject, string_2, IsUnitCloningOperation: false);
			}
			foreach (ActiveUnit activeUnits_ in scenarioObject.ActiveUnits_List)
			{
				if (!Information.IsNothing((object)activeUnits_))
				{
					activeUnits_.RestoreOldComponentIDs();
				}
			}
			SBR.GenerateScenarioContentsList(scenarioObject);
			foreach (ActiveUnit activeUnits_2 in scenarioObject.ActiveUnits_List)
			{
				if (!Information.IsNothing((object)activeUnits_2))
				{
					activeUnits_2.Sensory.vmethod_2(activeUnits_2.Sensors_Cached);
				}
			}
			scenarioObject.LastSavedInScenEdit = true;
			LoadSave.SaveScenario(scenarioObject, scenarioObject.Sides_ReadOnly[0], string_1, SBR: true);
			if (!string.IsNullOrEmpty(Client.IgnoredCoreUIMessages))
			{
				File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n  ERROR: ADDITIONAL WARNINGS!\r\n" + Client.IgnoredCoreUIMessages);
			}
			text = "Scenario " + Conversions.ToString(int_0) + ": Rebuild Completed";
			File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n" + text);
			File.AppendAllText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt", text);
		}
		else
		{
			string text = "Scenario " + Conversions.ToString(int_0) + ": ERROR: FILE NOT FOUND!";
			File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n\r\n" + text);
			File.AppendAllText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt", "\r\n\r\n" + text);
		}
		if (scenarioObject != null)
		{
			GameGeneral.DestroyPreviousScenario(ref scenarioObject, ClearLuaSandbox: true);
		}
	}

	private void Migration_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode != 32 || !((Control)this).Visible)
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void Migration_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	static Migration()
	{
		Class72.smethod_20();
	}
}
