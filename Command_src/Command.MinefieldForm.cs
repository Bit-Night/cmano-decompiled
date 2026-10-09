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
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class MinefieldForm : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	public List<ReferencePoint> theArea;

	private DataTable dataTable_0;

	private DataView dataView_0;

	[AccessedThroughProperty("BW1")]
	[CompilerGenerated]
	private BackgroundWorker backgroundWorker_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private HashSet<string> hashSet_0;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("CB_Weapon")]
	internal virtual DarkUIComboBox CB_Weapon { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("NumericUpDown1")]
	internal virtual GClass9 NumericUpDown1 { get; set; }

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

	[field: AccessedThroughProperty("ProgressBar1")]
	internal virtual DarkUIProgressBar ProgressBar1 { get; set; }

	private virtual BackgroundWorker BW1
	{
		[CompilerGenerated]
		get
		{
			return backgroundWorker_0;
		}
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = method_3;
			RunWorkerCompletedEventHandler value3 = method_4;
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

	public MinefieldForm()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += MinefieldForm_Load;
		((Control)this).KeyDown += new KeyEventHandler(MinefieldForm_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(MinefieldForm_FormClosing);
		theArea = new List<ReferencePoint>();
		dataTable_0 = new DataTable();
		BW1 = new BackgroundWorker();
		hashSet_0 = new HashSet<string>();
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
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected O, but got Unknown
		Label1 = new DarkLabel();
		CB_Weapon = new DarkUIComboBox();
		Label2 = new DarkLabel();
		NumericUpDown1 = new GClass9();
		Button1 = new DarkUIButton();
		ProgressBar1 = new DarkUIProgressBar();
		((Control)this).SuspendLayout();
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(47, 13);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(34, 16);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Type:";
		((ComboBox)CB_Weapon).BackColor = Color.Transparent;
		((ComboBox)CB_Weapon).DrawMode = (DrawMode)1;
		((ComboBox)CB_Weapon).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Weapon).Font = new Font("Segoe UI", 10f);
		((ListControl)CB_Weapon).FormattingEnabled = true;
		((Control)CB_Weapon).Location = new Point(82, 8);
		((Control)CB_Weapon).Name = "CB_Weapon";
		((Control)CB_Weapon).Size = new Size(392, 26);
		((Control)CB_Weapon).TabIndex = 1;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(13, 44);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(68, 16);
		((Control)Label2).TabIndex = 2;
		((Label)Label2).Text = "How many:";
		NumericUpDown1.BackColor = Color.Transparent;
		((Control)NumericUpDown1).Location = new Point(82, 39);
		((NumericUpDown)NumericUpDown1).Maximum = 100m;
		((NumericUpDown)NumericUpDown1).Minimum = 1m;
		((Control)NumericUpDown1).Name = "NumericUpDown1";
		((Control)NumericUpDown1).Size = new Size(124, 26);
		((Control)NumericUpDown1).TabIndex = 3;
		((NumericUpDown)NumericUpDown1).Value = 1m;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font("Segoe UI", 10f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(399, 38);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 29);
		((Control)Button1).TabIndex = 4;
		Button1.Text = "ADD";
		((Control)ProgressBar1).BackColor = Color.Transparent;
		ProgressBar1.CustomForeColor = Color.Transparent;
		((Control)ProgressBar1).Font = new Font("Segoe UI", 9f);
		((Control)ProgressBar1).Location = new Point(16, 72);
		ProgressBar1.Maximum = 100;
		((Control)ProgressBar1).Name = "ProgressBar1";
		ProgressBar1.ShowProgressLines = true;
		ProgressBar1.ShowProgressValue = false;
		ProgressBar1.ShowText = false;
		((Control)ProgressBar1).Size = new Size(458, 12);
		((Control)ProgressBar1).TabIndex = 5;
		ProgressBar1.Value = 0;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(486, 95);
		((Control)this).Controls.Add((Control)(object)ProgressBar1);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)NumericUpDown1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)CB_Weapon);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "MinefieldForm";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Add mines in designated area";
		((Control)this).ResumeLayout(false);
	}

	private void MinefieldForm_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		Scenario theScen = Client.CurrentScenario;
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		dataTable_0 = DBFunctions.GetAllWeapons(IncludeNonWeapons: true, ref theScen, ref sqliteConnection_);
		if (!dataTable_0.Columns.Contains("FullName"))
		{
			dataTable_0.Columns.Add("FullName", typeof(string));
		}
		foreach (DataRow row in dataTable_0.Rows)
		{
			if (!Client.CurrentScenario.FeatureCompatibility.get_WeaponAGL_ASL(Client.CurrentScenario.DBConnection))
			{
				row["FullName"] = Strings.Trim(Conversions.ToString(row["Name"])) + " [" + Conversions.ToString(Math.Abs(Conversions.ToInteger(row["TargetAltitudeMax"]))) + "m - " + Conversions.ToString(Math.Abs(Conversions.ToInteger(row["TargetAltitudeMin"]))) + "m]";
			}
			else
			{
				row["FullName"] = Strings.Trim(Conversions.ToString(row["Name"])) + " [" + Conversions.ToString(Math.Abs(Conversions.ToInteger(row["TargetAltitudeMax_ASL"]))) + "m - " + Conversions.ToString(Math.Abs(Conversions.ToInteger(row["TargetAltitudeMin_ASL"]))) + "m]";
			}
		}
		dataView_0 = new DataView(dataTable_0);
		dataView_0.Sort = "FULLNAME ASC";
		dataView_0.RowFilter = "TYPE IN (4004, 4005, 4006, 4007, 4008, 4009, 4011)";
		((ComboBox)CB_Weapon).DataSource = dataView_0;
		((ListControl)CB_Weapon).DisplayMember = "FullName";
		((ListControl)CB_Weapon).ValueMember = "ID";
		((Control)ProgressBar1).Visible = false;
	}

	private void method_2(object sender, EventArgs e)
	{
		Button1.Text = "WORKING...";
		Button1.Enabled = false;
		((Control)ProgressBar1).Visible = true;
		int_0 = Conversions.ToInteger(((ListControl)CB_Weapon).SelectedValue);
		BW1.RunWorkerAsync();
	}

	private void method_3(object sender, DoWorkEventArgs e)
	{
		int_1 = Convert.ToInt32(((NumericUpDown)NumericUpDown1).Value);
		int_2 = 0;
		string AttemptMessage = null;
		hashSet_0.Clear();
		int num = int_1;
		int num2;
		for (num2 = 0; num2 <= num; num2++)
		{
			num2++;
			UnguidedWeapon unguidedWeapon = Client.CurrentScenario.AddNewMine(Client.CurrentSide, int_0, theArea, ref AttemptMessage);
			if (AttemptMessage != null && !hashSet_0.Contains(AttemptMessage))
			{
				hashSet_0.Add(AttemptMessage);
			}
			if (!Information.IsNothing((object)unguidedWeapon))
			{
				int_2++;
			}
		}
	}

	private void method_4(object sender, RunWorkerCompletedEventArgs e)
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		Button1.Text = "ADD";
		Button1.Enabled = true;
		((Control)ProgressBar1).Visible = false;
		Client.MustRefreshMainForm = true;
		string text = "";
		if (int_1 == int_2)
		{
			text = "All mines were successfully laid.";
		}
		else
		{
			text = ((int_2 != 0) ? ("Only " + Conversions.ToString(int_2) + " of the mines were laid successfully. Failures are due to the following reasons : ") : "No mine was succesfully laid. Failures are due to the following reasons : ");
			text += Environment.NewLine;
			foreach (string item in hashSet_0)
			{
				text += item;
				text += Environment.NewLine;
			}
		}
		DarkMessageBox.ShowInformation(text, "Mine placement complete!");
	}

	private void MinefieldForm_KeyDown(object sender, KeyEventArgs e)
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

	private void MinefieldForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	static MinefieldForm()
	{
		Class72.smethod_20();
	}
}
