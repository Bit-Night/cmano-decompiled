using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class ConfirmLandingPlanDialog : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("DatePicker_Date")]
	[CompilerGenerated]
	private DateTimePicker _DatePicker_Date;

	[AccessedThroughProperty("DatePicker_Time")]
	[CompilerGenerated]
	private DateTimePicker _DatePicker_Time;

	[AccessedThroughProperty("Button_OK")]
	[CompilerGenerated]
	private DarkUIButton _Button_OK;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_InstantLoading")]
	private DarkCheckBox _CB_InstantLoading;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_StartImmediately")]
	private DarkCheckBox _CB_StartImmediately;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AssociateToLHour")]
	private DarkCheckBox _CB_AssociateToLHour;

	[CompilerGenerated]
	[AccessedThroughProperty("HHourDatePicker_Date")]
	private DateTimePicker _HHourDatePicker_Date;

	[AccessedThroughProperty("HHourDatePicker_Time")]
	[CompilerGenerated]
	private DateTimePicker _HHourDatePicker_Time;

	public LandingPlanner landingPlannerWindow;

	[field: AccessedThroughProperty("TB_Description")]
	internal virtual DarkRichTextBox TB_Description { get; set; }

	[field: AccessedThroughProperty("LV_CreatedMissions")]
	internal virtual DarkListView LV_CreatedMissions { get; set; }

	[field: AccessedThroughProperty("Label_Title")]
	internal virtual DarkLabel Label_Title { get; set; }

	internal virtual DateTimePicker DatePicker_Date
	{
		[CompilerGenerated]
		get
		{
			return _DatePicker_Date;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DateTimePicker val = _DatePicker_Date;
			if (val != null)
			{
				val.ValueChanged -= eventHandler;
			}
			_DatePicker_Date = value;
			val = _DatePicker_Date;
			if (val != null)
			{
				val.ValueChanged += eventHandler;
			}
		}
	}

	internal virtual DateTimePicker DatePicker_Time
	{
		[CompilerGenerated]
		get
		{
			return _DatePicker_Time;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DateTimePicker val = _DatePicker_Time;
			if (val != null)
			{
				val.ValueChanged -= eventHandler;
			}
			_DatePicker_Time = value;
			val = _DatePicker_Time;
			if (val != null)
			{
				val.ValueChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("GB_AssociateToLHour")]
	internal virtual DarkGroupBox GB_AssociateToLHour { get; set; }

	internal virtual DarkUIButton Button_OK
	{
		[CompilerGenerated]
		get
		{
			return _Button_OK;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkUIButton darkUIButton = _Button_OK;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_OK = value;
			darkUIButton = _Button_OK;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_InstantLoading
	{
		[CompilerGenerated]
		get
		{
			return _CB_InstantLoading;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkCheckBox darkCheckBox = _CB_InstantLoading;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_InstantLoading = value;
			darkCheckBox = _CB_InstantLoading;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_StartImmediately
	{
		[CompilerGenerated]
		get
		{
			return _CB_StartImmediately;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkCheckBox darkCheckBox = _CB_StartImmediately;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_StartImmediately = value;
			darkCheckBox = _CB_StartImmediately;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_AssociateToLHour
	{
		[CompilerGenerated]
		get
		{
			return _CB_AssociateToLHour;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkCheckBox darkCheckBox = _CB_AssociateToLHour;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_AssociateToLHour = value;
			darkCheckBox = _CB_AssociateToLHour;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("GP_AmphibiousVehicles")]
	internal virtual DarkGroupBox GP_AmphibiousVehicles { get; set; }

	[field: AccessedThroughProperty("LabelWaveFreq")]
	internal virtual DarkLabel LabelWaveFreq { get; set; }

	[field: AccessedThroughProperty("NumUD_WaveFreq")]
	internal virtual NumericUpDown NumUD_WaveFreq { get; set; }

	[field: AccessedThroughProperty("CB_NewWaveEvery")]
	internal virtual DarkCheckBox CB_NewWaveEvery { get; set; }

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	internal virtual DateTimePicker HHourDatePicker_Date
	{
		[CompilerGenerated]
		get
		{
			return _HHourDatePicker_Date;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DateTimePicker val = _HHourDatePicker_Date;
			if (val != null)
			{
				val.ValueChanged -= eventHandler;
			}
			_HHourDatePicker_Date = value;
			val = _HHourDatePicker_Date;
			if (val != null)
			{
				val.ValueChanged += eventHandler;
			}
		}
	}

	internal virtual DateTimePicker HHourDatePicker_Time
	{
		[CompilerGenerated]
		get
		{
			return _HHourDatePicker_Time;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DateTimePicker val = _HHourDatePicker_Time;
			if (val != null)
			{
				val.ValueChanged -= eventHandler;
			}
			_HHourDatePicker_Time = value;
			val = _HHourDatePicker_Time;
			if (val != null)
			{
				val.ValueChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	[field: AccessedThroughProperty("TB_LandingPlanName")]
	internal virtual DarkUITextBox TB_LandingPlanName { get; set; }

	[field: AccessedThroughProperty("Label_LandingPlanName")]
	internal virtual DarkLabel Label_LandingPlanName { get; set; }

	public ConfirmLandingPlanDialog()
	{
		((Form)this).Load += ConfirmLandingPlanDialog_Load;
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
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Unknown result type (might be due to invalid IL or missing references)
		//IL_0675: Unknown result type (might be due to invalid IL or missing references)
		//IL_070c: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d65: Unknown result type (might be due to invalid IL or missing references)
		TB_Description = new DarkRichTextBox();
		LV_CreatedMissions = new DarkListView();
		Label_Title = new DarkLabel();
		DatePicker_Date = new DateTimePicker();
		DatePicker_Time = new DateTimePicker();
		GB_AssociateToLHour = new DarkGroupBox();
		DarkLabel2 = new DarkLabel();
		HHourDatePicker_Date = new DateTimePicker();
		HHourDatePicker_Time = new DateTimePicker();
		DarkLabel1 = new DarkLabel();
		Button_OK = new DarkUIButton();
		CB_InstantLoading = new DarkCheckBox();
		CB_StartImmediately = new DarkCheckBox();
		CB_AssociateToLHour = new DarkCheckBox();
		GP_AmphibiousVehicles = new DarkGroupBox();
		LabelWaveFreq = new DarkLabel();
		NumUD_WaveFreq = new NumericUpDown();
		CB_NewWaveEvery = new DarkCheckBox();
		TB_LandingPlanName = new DarkUITextBox();
		Label_LandingPlanName = new DarkLabel();
		((Control)GB_AssociateToLHour).SuspendLayout();
		((Control)GP_AmphibiousVehicles).SuspendLayout();
		((ISupportInitialize)NumUD_WaveFreq).BeginInit();
		((Control)this).SuspendLayout();
		((TextBoxBase)TB_Description).BackColor = Color.FromArgb(60, 63, 65);
		((RichTextBox)TB_Description).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_Description).Location = new Point(7, 10);
		((Control)TB_Description).Margin = new Padding(2, 3, 2, 3);
		((Control)TB_Description).Name = "TB_Description";
		((TextBoxBase)TB_Description).ReadOnly = true;
		((Control)TB_Description).Size = new Size(279, 49);
		((Control)TB_Description).TabIndex = 0;
		((RichTextBox)TB_Description).Text = "The landing plan has been succesfully created and its generated cargo landing missions added to the operation planner.";
		((Control)LV_CreatedMissions).BackColor = Color.FromArgb(40, 43, 45);
		((Control)LV_CreatedMissions).Location = new Point(9, 94);
		((Control)LV_CreatedMissions).Margin = new Padding(2, 3, 2, 3);
		((Control)LV_CreatedMissions).Name = "LV_CreatedMissions";
		((Control)LV_CreatedMissions).Size = new Size(277, 143);
		((Control)LV_CreatedMissions).TabIndex = 1;
		((Control)LV_CreatedMissions).Text = "DarkListView1";
		Label_Title.AutoSize = true;
		((Control)Label_Title).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Title).Location = new Point(7, 78);
		((Control)Label_Title).Margin = new Padding(2, 0, 2, 0);
		((Control)Label_Title).Name = "Label_Title";
		((Control)Label_Title).Size = new Size(137, 13);
		((Control)Label_Title).TabIndex = 2;
		((Label)Label_Title).Text = "Generated Cargo Missions :";
		DatePicker_Date.CustomFormat = "d/MM/yyyy";
		DatePicker_Date.Format = (DateTimePickerFormat)2;
		((Control)DatePicker_Date).Location = new Point(89, 22);
		((Control)DatePicker_Date).Name = "DatePicker_Date";
		((Control)DatePicker_Date).Size = new Size(87, 20);
		((Control)DatePicker_Date).TabIndex = 62;
		DatePicker_Time.CustomFormat = "hh:mm:ss";
		DatePicker_Time.Format = (DateTimePickerFormat)8;
		((Control)DatePicker_Time).Location = new Point(180, 22);
		((Control)DatePicker_Time).Name = "DatePicker_Time";
		DatePicker_Time.ShowUpDown = true;
		((Control)DatePicker_Time).Size = new Size(93, 20);
		((Control)DatePicker_Time).TabIndex = 63;
		((Control)GB_AssociateToLHour).Controls.Add((Control)(object)DarkLabel2);
		((Control)GB_AssociateToLHour).Controls.Add((Control)(object)HHourDatePicker_Date);
		((Control)GB_AssociateToLHour).Controls.Add((Control)(object)HHourDatePicker_Time);
		((Control)GB_AssociateToLHour).Controls.Add((Control)(object)DarkLabel1);
		((Control)GB_AssociateToLHour).Controls.Add((Control)(object)DatePicker_Date);
		((Control)GB_AssociateToLHour).Controls.Add((Control)(object)DatePicker_Time);
		((Control)GB_AssociateToLHour).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GB_AssociateToLHour).Location = new Point(7, 316);
		((Control)GB_AssociateToLHour).Margin = new Padding(2, 3, 2, 3);
		((Control)GB_AssociateToLHour).Name = "GB_AssociateToLHour";
		((Control)GB_AssociateToLHour).Padding = new Padding(2, 3, 2, 3);
		((Control)GB_AssociateToLHour).Size = new Size(280, 72);
		((Control)GB_AssociateToLHour).TabIndex = 64;
		((GroupBox)GB_AssociateToLHour).TabStop = false;
		((GroupBox)GB_AssociateToLHour).Text = "                ";
		DarkLabel2.AutoSize = true;
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(1, 47);
		((Control)DarkLabel2).Margin = new Padding(2, 0, 2, 0);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(86, 13);
		((Control)DarkLabel2).TabIndex = 67;
		((Label)DarkLabel2).Text = "Desired H-Hour :";
		HHourDatePicker_Date.CustomFormat = "d/MM/yyyy";
		HHourDatePicker_Date.Format = (DateTimePickerFormat)2;
		((Control)HHourDatePicker_Date).Location = new Point(89, 45);
		((Control)HHourDatePicker_Date).Name = "HHourDatePicker_Date";
		((Control)HHourDatePicker_Date).Size = new Size(87, 20);
		((Control)HHourDatePicker_Date).TabIndex = 65;
		HHourDatePicker_Time.CustomFormat = "hh:mm:ss";
		HHourDatePicker_Time.Format = (DateTimePickerFormat)8;
		((Control)HHourDatePicker_Time).Location = new Point(180, 45);
		((Control)HHourDatePicker_Time).Name = "HHourDatePicker_Time";
		HHourDatePicker_Time.ShowUpDown = true;
		((Control)HHourDatePicker_Time).Size = new Size(93, 20);
		((Control)HHourDatePicker_Time).TabIndex = 66;
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(1, 23);
		((Control)DarkLabel1).Margin = new Padding(2, 0, 2, 0);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(84, 13);
		((Control)DarkLabel1).TabIndex = 64;
		((Label)DarkLabel1).Text = "Desired L-Hour :";
		((ButtonBase)Button_OK).BackColor = Color.Transparent;
		((Button)Button_OK).DialogResult = (DialogResult)0;
		((Control)Button_OK).ForeColor = SystemColors.Control;
		((Control)Button_OK).Location = new Point(7, 453);
		((Control)Button_OK).Margin = new Padding(2, 3, 2, 3);
		((Control)Button_OK).MinimumSize = new Size(278, 32);
		((Control)Button_OK).Name = "Button_OK";
		Button_OK.RoundRadius = 0;
		((Control)Button_OK).Size = new Size(278, 32);
		((Control)Button_OK).TabIndex = 65;
		Button_OK.Text = "OK";
		((ButtonBase)CB_InstantLoading).AutoSize = true;
		((Control)CB_InstantLoading).Location = new Point(12, 272);
		((Control)CB_InstantLoading).Name = "CB_InstantLoading";
		((Control)CB_InstantLoading).Size = new Size(276, 17);
		((Control)CB_InstantLoading).TabIndex = 66;
		((ButtonBase)CB_InstantLoading).Text = "[EDITOR MODE] - Instant loading for all first waves ?";
		((ButtonBase)CB_StartImmediately).AutoSize = true;
		((Control)CB_StartImmediately).Location = new Point(12, 293);
		((Control)CB_StartImmediately).Name = "CB_StartImmediately";
		((Control)CB_StartImmediately).Size = new Size(157, 17);
		((Control)CB_StartImmediately).TabIndex = 67;
		((ButtonBase)CB_StartImmediately).Text = "Immediatly start the Landing";
		((ButtonBase)CB_AssociateToLHour).AutoSize = true;
		((Control)CB_AssociateToLHour).Location = new Point(12, 313);
		((Control)CB_AssociateToLHour).Name = "CB_AssociateToLHour";
		((Control)CB_AssociateToLHour).Size = new Size(67, 17);
		((Control)CB_AssociateToLHour).TabIndex = 68;
		((ButtonBase)CB_AssociateToLHour).Text = "Planning";
		((Control)GP_AmphibiousVehicles).Controls.Add((Control)(object)LabelWaveFreq);
		((Control)GP_AmphibiousVehicles).Controls.Add((Control)(object)NumUD_WaveFreq);
		((Control)GP_AmphibiousVehicles).Controls.Add((Control)(object)CB_NewWaveEvery);
		((Control)GP_AmphibiousVehicles).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GP_AmphibiousVehicles).Location = new Point(7, 394);
		((Control)GP_AmphibiousVehicles).Name = "GP_AmphibiousVehicles";
		((Control)GP_AmphibiousVehicles).Size = new Size(278, 53);
		((Control)GP_AmphibiousVehicles).TabIndex = 70;
		((GroupBox)GP_AmphibiousVehicles).TabStop = false;
		((GroupBox)GP_AmphibiousVehicles).Text = "Amphibious Vehicles Behaviour";
		((Control)GP_AmphibiousVehicles).Visible = false;
		LabelWaveFreq.AutoSize = true;
		((Control)LabelWaveFreq).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelWaveFreq).Location = new Point(223, 23);
		((Control)LabelWaveFreq).Margin = new Padding(2, 0, 2, 0);
		((Control)LabelWaveFreq).Name = "LabelWaveFreq";
		((Control)LabelWaveFreq).Size = new Size(50, 13);
		((Control)LabelWaveFreq).TabIndex = 71;
		((Label)LabelWaveFreq).Text = "Minute(s)";
		((Control)NumUD_WaveFreq).Location = new Point(118, 19);
		((Control)NumUD_WaveFreq).Name = "NumUD_WaveFreq";
		((Control)NumUD_WaveFreq).Size = new Size(99, 20);
		((Control)NumUD_WaveFreq).TabIndex = 72;
		((ButtonBase)CB_NewWaveEvery).AutoSize = true;
		((Control)CB_NewWaveEvery).Location = new Point(6, 19);
		((Control)CB_NewWaveEvery).Name = "CB_NewWaveEvery";
		((Control)CB_NewWaveEvery).Size = new Size(106, 17);
		((Control)CB_NewWaveEvery).TabIndex = 71;
		((ButtonBase)CB_NewWaveEvery).Text = "New wave every";
		TB_LandingPlanName.AutoCompleteCustomSource = null;
		TB_LandingPlanName.AutoCompleteMode = (AutoCompleteMode)0;
		TB_LandingPlanName.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_LandingPlanName).BackColor = Color.Transparent;
		((Control)TB_LandingPlanName).ForeColor = Color.FromArgb(189, 189, 189);
		TB_LandingPlanName.Image = null;
		TB_LandingPlanName.Lines = null;
		((Control)TB_LandingPlanName).Location = new Point(51, 243);
		TB_LandingPlanName.MaxLength = 32767;
		TB_LandingPlanName.Multiline = false;
		((Control)TB_LandingPlanName).Name = "TB_LandingPlanName";
		TB_LandingPlanName.ReadOnly = false;
		TB_LandingPlanName.ScrollBars = (ScrollBars)0;
		TB_LandingPlanName.SelectionStart = 0;
		((Control)TB_LandingPlanName).Size = new Size(237, 24);
		((Control)TB_LandingPlanName).TabIndex = 71;
		TB_LandingPlanName.TextAlign = (HorizontalAlignment)0;
		TB_LandingPlanName.UseSystemPasswordChar = false;
		TB_LandingPlanName.WatermarkText = "Landing plan's name";
		Label_LandingPlanName.AutoSize = true;
		((Control)Label_LandingPlanName).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_LandingPlanName).Location = new Point(10, 247);
		((Control)Label_LandingPlanName).Name = "Label_LandingPlanName";
		((Control)Label_LandingPlanName).Size = new Size(35, 13);
		((Control)Label_LandingPlanName).TabIndex = 72;
		((Label)Label_LandingPlanName).Text = "Name";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 63, 65);
		((Form)this).ClientSize = new Size(297, 494);
		((Control)this).Controls.Add((Control)(object)Label_LandingPlanName);
		((Control)this).Controls.Add((Control)(object)TB_LandingPlanName);
		((Control)this).Controls.Add((Control)(object)GP_AmphibiousVehicles);
		((Control)this).Controls.Add((Control)(object)CB_AssociateToLHour);
		((Control)this).Controls.Add((Control)(object)CB_StartImmediately);
		((Control)this).Controls.Add((Control)(object)CB_InstantLoading);
		((Control)this).Controls.Add((Control)(object)Button_OK);
		((Control)this).Controls.Add((Control)(object)GB_AssociateToLHour);
		((Control)this).Controls.Add((Control)(object)Label_Title);
		((Control)this).Controls.Add((Control)(object)LV_CreatedMissions);
		((Control)this).Controls.Add((Control)(object)TB_Description);
		((Form)this).Margin = new Padding(2, 3, 2, 3);
		((Form)this).MaximizeBox = false;
		((Form)this).MaximumSize = new Size(313, 533);
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(313, 533);
		((Control)this).Name = "ConfirmLandingPlanDialog";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Confirm Landing Plan";
		((Control)GB_AssociateToLHour).ResumeLayout(false);
		((Control)GB_AssociateToLHour).PerformLayout();
		((Control)GP_AmphibiousVehicles).ResumeLayout(false);
		((Control)GP_AmphibiousVehicles).PerformLayout();
		((ISupportInitialize)NumUD_WaveFreq).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void ConfirmLandingPlanDialog_Load(object sender, EventArgs e)
	{
		foreach (KeyValuePair<Mission, LandingType> generatedMission in landingPlannerWindow.GeneratedMissions)
		{
			DarkListItem darkListItem = new DarkListItem();
			darkListItem.Text = generatedMission.Key.Name;
			LV_CreatedMissions.Items.Add(darkListItem);
		}
		foreach (KeyValuePair<ActiveUnit, Transport> transport in landingPlannerWindow.TransportList)
		{
			if (transport.Value.Waves.Count > 0)
			{
				transport.Value.Waves.ElementAt(0).AssociatedMission.InstantLoadingForNextManifest = true;
			}
		}
		TB_LandingPlanName.Text = landingPlannerWindow.LandingPlan.Name;
		method_7();
		method_2();
	}

	private void method_2()
	{
		((CheckBox)CB_AssociateToLHour).CheckedChanged -= method_12;
		((CheckBox)CB_StartImmediately).CheckedChanged -= method_11;
		((Control)CB_InstantLoading).Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit || Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.AllowLandingPlannerInstantLoading);
		if (((CheckBox)CB_AssociateToLHour).Checked)
		{
			((Control)CB_StartImmediately).Enabled = false;
			((CheckBox)CB_StartImmediately).Checked = false;
		}
		else
		{
			((Control)CB_StartImmediately).Enabled = true;
		}
		if (!((CheckBox)CB_StartImmediately).Checked)
		{
			((Control)CB_AssociateToLHour).Enabled = true;
		}
		else
		{
			((Control)CB_AssociateToLHour).Enabled = false;
			((CheckBox)CB_AssociateToLHour).Checked = false;
		}
		((Control)GB_AssociateToLHour).Visible = ((CheckBox)CB_AssociateToLHour).Checked;
		bool flag = false;
		foreach (KeyValuePair<Mission, LandingType> generatedMission in landingPlannerWindow.GeneratedMissions)
		{
			if (generatedMission.Key.MissionClass == Mission._MissionClass.Support)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			((Control)GP_AmphibiousVehicles).Visible = false;
		}
		else
		{
			((Control)GP_AmphibiousVehicles).Visible = true;
		}
		((CheckBox)CB_AssociateToLHour).CheckedChanged += method_12;
		((CheckBox)CB_StartImmediately).CheckedChanged += method_11;
	}

	private void method_3(object sender, EventArgs e)
	{
		method_8();
	}

	private void method_4(object sender, EventArgs e)
	{
		method_8();
	}

	private void method_5(object sender, EventArgs e)
	{
		method_8();
	}

	private void method_6(object sender, EventArgs e)
	{
		method_8();
	}

	private void method_7()
	{
		DatePicker_Time.ValueChanged -= method_4;
		DatePicker_Time.ValueChanged -= method_4;
		HHourDatePicker_Date.ValueChanged -= method_5;
		HHourDatePicker_Time.ValueChanged -= method_6;
		DatePicker_Date.Value = Client.CurrentScenario.Time;
		DatePicker_Time.Value = Client.CurrentScenario.Time;
		HHourDatePicker_Date.Value = Client.CurrentScenario.Time;
		HHourDatePicker_Time.Value = Client.CurrentScenario.Time;
		DatePicker_Time.ValueChanged += method_4;
		DatePicker_Time.ValueChanged += method_4;
		HHourDatePicker_Date.ValueChanged += method_5;
		HHourDatePicker_Time.ValueChanged += method_6;
	}

	private void method_8()
	{
		if (DateTime.Compare(new DateTime(DatePicker_Date.Value.Year, DatePicker_Date.Value.Month, DatePicker_Date.Value.Day, DatePicker_Time.Value.Hour, DatePicker_Time.Value.Minute, DatePicker_Time.Value.Second), Client.CurrentScenario.Time) < 0)
		{
			method_7();
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		landingPlannerWindow.LandingPlan.Name = TB_LandingPlanName.Text;
		if (((CheckBox)CB_InstantLoading).Checked)
		{
			foreach (KeyValuePair<ActiveUnit, Transport> transport in landingPlannerWindow.TransportList)
			{
				if (transport.Value.Waves.Count > 0)
				{
					transport.Value.Waves.ElementAt(0).AssociatedMission.InstantLoadingForNextManifest = true;
				}
			}
		}
		if (((CheckBox)CB_StartImmediately).Checked)
		{
			foreach (KeyValuePair<ActiveUnit, Transport> transport2 in landingPlannerWindow.TransportList)
			{
				foreach (TransportWave wave in transport2.Value.Waves)
				{
					if (wave.IsFirstWave)
					{
						((Mission)wave.AssociatedMission).set_Phase(Client.CurrentScenario, Client.CurrentSide, MissionPhase.Active);
					}
				}
			}
		}
		if (((CheckBox)CB_AssociateToLHour).Checked && landingPlannerWindow.GeneratedMissions.Count > 0)
		{
			CargoMission cargoMission = new CargoMission(Client.CurrentSide, Client.CurrentScenario, " -[Amphibious] Master Landing Plan - ", Mission.MissionCategory.Mission, ((CargoMission)landingPlannerWindow.GeneratedMissions.Keys.ElementAt(0)).Area, ValidateArea: false);
			foreach (KeyValuePair<Mission, LandingType> item in landingPlannerWindow.GeneratedMissions.ToList())
			{
				if (item.Value == LandingType.Amphibious)
				{
					item.Key.MissionStartTrigger_MissionCompleted.Add(cargoMission, cargoMission);
					item.Key.MissionStartTrigger_MissionCompleted_Enabled = true;
					item.Key.MissionStartTrigger_MissionCompleted_Operator = false;
				}
			}
			cargoMission.MissionCompletedTrigger_ElapsedTime = 0f;
			cargoMission.MissionCompletedTrigger_ElapsedTime_Enabled = true;
			cargoMission.CreationMode = MissionCreationType.LandingPlanner;
			((Mission)cargoMission).set_Phase(Client.CurrentScenario, Client.CurrentSide, MissionPhase.OnHold);
			cargoMission.OperationName = landingPlannerWindow.CurrentMothership.Name + " landing operation.";
			Operation operation = Client.CurrentSide.Operation;
			operation.LHour = new DateTime(DatePicker_Date.Value.Year, DatePicker_Date.Value.Month, DatePicker_Date.Value.Day, DatePicker_Time.Value.Hour, DatePicker_Time.Value.Minute, DatePicker_Time.Value.Second);
			operation.LHourMission = cargoMission;
			landingPlannerWindow.LandingPlan.AddMission(cargoMission);
			cargoMission = new CargoMission(Client.CurrentSide, Client.CurrentScenario, " -[Air] Master Landing Plan - ", Mission.MissionCategory.Mission, ((CargoMission)landingPlannerWindow.GeneratedMissions.Keys.ElementAt(0)).Area, ValidateArea: false);
			cargoMission.MissionCompletedTrigger_ElapsedTime = 0f;
			cargoMission.MissionCompletedTrigger_ElapsedTime_Enabled = true;
			cargoMission.CreationMode = MissionCreationType.LandingPlanner;
			((Mission)cargoMission).set_Phase(Client.CurrentScenario, Client.CurrentSide, MissionPhase.OnHold);
			cargoMission.OperationName = landingPlannerWindow.CurrentMothership.Name + " landing operation.";
			Operation operation2 = Client.CurrentSide.Operation;
			operation2.HHour = new DateTime(HHourDatePicker_Date.Value.Year, HHourDatePicker_Date.Value.Month, HHourDatePicker_Date.Value.Day, HHourDatePicker_Time.Value.Hour, HHourDatePicker_Time.Value.Minute, HHourDatePicker_Time.Value.Second);
			operation2.HHourMission = cargoMission;
			landingPlannerWindow.LandingPlan.AddMission(cargoMission);
			foreach (KeyValuePair<Mission, LandingType> item2 in landingPlannerWindow.GeneratedMissions.ToList())
			{
				if (item2.Value == LandingType.Airborne)
				{
					item2.Key.MissionStartTrigger_MissionCompleted.Add(cargoMission, cargoMission);
					item2.Key.MissionStartTrigger_MissionCompleted_Enabled = true;
					item2.Key.MissionStartTrigger_MissionCompleted_Operator = false;
				}
			}
		}
		Dictionary<int, List<Mission>> dictionary = new Dictionary<int, List<Mission>>();
		foreach (KeyValuePair<Mission, LandingType> generatedMission in landingPlannerWindow.GeneratedMissions)
		{
			if (generatedMission.Key.MissionClass == Mission._MissionClass.Support)
			{
				if (dictionary.ContainsKey(generatedMission.Key.PriorityWeight))
				{
					dictionary[generatedMission.Key.PriorityWeight].Add(generatedMission.Key);
					continue;
				}
				dictionary.Add(generatedMission.Key.PriorityWeight, new List<Mission>());
				dictionary[generatedMission.Key.PriorityWeight].Add(generatedMission.Key);
			}
		}
		_ = from item in dictionary
			orderby item.Key
			select (item);
		foreach (KeyValuePair<int, List<Mission>> item3 in dictionary)
		{
			foreach (Mission item4 in item3.Value)
			{
				if (((CheckBox)CB_StartImmediately).Checked && decimal.Compare(NumUD_WaveFreq.Value, 0m) == 0)
				{
					item4.set_Phase(Client.CurrentScenario, Client.CurrentSide, MissionPhase.Active);
				}
			}
		}
		((Form)this).DialogResult = (DialogResult)1;
		landingPlannerWindow.ForceClose = true;
		((Form)landingPlannerWindow).Close();
	}

	private void method_10(object sender, EventArgs e)
	{
		method_2();
	}

	private void method_11(object sender, EventArgs e)
	{
		method_2();
	}

	private void method_12(object sender, EventArgs e)
	{
		method_2();
	}

	static ConfirmLandingPlanDialog()
	{
		Class72.smethod_20();
	}
}
