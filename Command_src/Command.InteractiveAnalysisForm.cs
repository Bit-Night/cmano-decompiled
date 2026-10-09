using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
internal class InteractiveAnalysisForm : CommandFormParent
{
	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("SQLiteTab")]
	private TabPage tabPage_0;

	[CompilerGenerated]
	[AccessedThroughProperty("PropertyGridSQLite")]
	private PropertyGrid propertyGrid_0;

	[field: AccessedThroughProperty("ControlTab")]
	internal virtual DarkUITabControl ControlTab { get; set; }

	[field: AccessedThroughProperty("ExportSettingsTab")]
	internal virtual TabPage ExportSettingsTab { get; set; }

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual DarkGroupBox GroupBox1 { get; set; }

	[field: AccessedThroughProperty("OutputDirectoryButton")]
	internal virtual DarkUIButton OutputDirectoryButton { get; set; }

	[field: AccessedThroughProperty("OutputRootDirectory")]
	internal virtual DarkLabel OutputRootDirectory { get; set; }

	[field: AccessedThroughProperty("CB_ExportSIMDIS")]
	internal virtual DarkCheckBox CB_ExportSIMDIS { get; set; }

	[field: AccessedThroughProperty("CB_ExportSQLite")]
	internal virtual DarkCheckBox CB_ExportSQLite { get; set; }

	[field: AccessedThroughProperty("CB_ExportSQLServer")]
	internal virtual DarkCheckBox CB_ExportSQLServer { get; set; }

	[field: AccessedThroughProperty("CB_ExportCSV")]
	internal virtual DarkCheckBox CB_ExportCSV { get; set; }

	[field: AccessedThroughProperty("CB_ExportMSAccess")]
	internal virtual DarkCheckBox CB_ExportMSAccess { get; set; }

	[field: AccessedThroughProperty("CB_ExportTacview2x")]
	internal virtual DarkCheckBox CB_ExportTacview2x { get; set; }

	[field: AccessedThroughProperty("CB_ExportXML")]
	internal virtual DarkCheckBox CB_ExportXML { get; set; }

	[field: AccessedThroughProperty("CB_ExportTacview1x")]
	internal virtual DarkCheckBox CB_ExportTacview1x { get; set; }

	[field: AccessedThroughProperty("CB_OutputSeparated")]
	internal virtual DarkCheckBox CB_OutputSeparated { get; set; }

	[field: AccessedThroughProperty("PropertyGridCSV")]
	internal virtual PropertyGrid PropertyGridCSV { get; set; }

	[field: AccessedThroughProperty("SettingsTab")]
	internal virtual DarkUITabControl SettingsTab { get; set; }

	[field: AccessedThroughProperty("CSVTab")]
	internal virtual TabPage CSVTab { get; set; }

	[field: AccessedThroughProperty("XMLTab")]
	internal virtual TabPage XMLTab { get; set; }

	[field: AccessedThroughProperty("PropertyGridXML")]
	internal virtual PropertyGrid PropertyGridXML { get; set; }

	[field: AccessedThroughProperty("MSATab")]
	internal virtual TabPage MSATab { get; set; }

	[field: AccessedThroughProperty("SQLServerTab")]
	internal virtual TabPage SQLServerTab { get; set; }

	internal virtual TabPage SQLiteTab
	{
		[CompilerGenerated]
		get
		{
			return tabPage_0;
		}
		[CompilerGenerated]
		set
		{
			tabPage_0 = value;
		}
	}

	[field: AccessedThroughProperty("PropertyGridMSA")]
	internal virtual PropertyGrid PropertyGridMSA { get; set; }

	[field: AccessedThroughProperty("PropertyGridSQLServer")]
	internal virtual PropertyGrid PropertyGridSQLServer { get; set; }

	internal virtual PropertyGrid PropertyGridSQLite
	{
		[CompilerGenerated]
		get
		{
			return propertyGrid_0;
		}
		[CompilerGenerated]
		set
		{
			propertyGrid_0 = value;
		}
	}

	[field: AccessedThroughProperty("Start_StopButton")]
	internal virtual DarkUIButton Start_StopButton { get; set; }

	[field: AccessedThroughProperty("TB_OutputRootDirectoryValue")]
	internal virtual DarkUITextBox TB_OutputRootDirectoryValue { get; set; }

	public InteractiveAnalysisForm()
	{
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
		}
		finally
		{
			((Form)this).Dispose(disposing);
		}
	}

	private void InitializeComponent()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
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
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_0597: Unknown result type (might be due to invalid IL or missing references)
		//IL_0735: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a51: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e80: Expected O, but got Unknown
		ControlTab = new DarkUITabControl();
		ExportSettingsTab = new TabPage();
		SettingsTab = new DarkUITabControl();
		CSVTab = new TabPage();
		PropertyGridCSV = new PropertyGrid();
		XMLTab = new TabPage();
		PropertyGridXML = new PropertyGrid();
		MSATab = new TabPage();
		PropertyGridMSA = new PropertyGrid();
		SQLServerTab = new TabPage();
		PropertyGridSQLServer = new PropertyGrid();
		SQLiteTab = new TabPage();
		PropertyGridSQLite = new PropertyGrid();
		GroupBox1 = new DarkGroupBox();
		TB_OutputRootDirectoryValue = new DarkUITextBox();
		Start_StopButton = new DarkUIButton();
		CB_OutputSeparated = new DarkCheckBox();
		OutputDirectoryButton = new DarkUIButton();
		OutputRootDirectory = new DarkLabel();
		CB_ExportSIMDIS = new DarkCheckBox();
		CB_ExportSQLite = new DarkCheckBox();
		CB_ExportSQLServer = new DarkCheckBox();
		CB_ExportCSV = new DarkCheckBox();
		CB_ExportMSAccess = new DarkCheckBox();
		CB_ExportTacview2x = new DarkCheckBox();
		CB_ExportXML = new DarkCheckBox();
		CB_ExportTacview1x = new DarkCheckBox();
		((Control)ControlTab).SuspendLayout();
		((Control)ExportSettingsTab).SuspendLayout();
		((Control)SettingsTab).SuspendLayout();
		((Control)CSVTab).SuspendLayout();
		((Control)XMLTab).SuspendLayout();
		((Control)MSATab).SuspendLayout();
		((Control)SQLServerTab).SuspendLayout();
		((Control)SQLiteTab).SuspendLayout();
		((Control)GroupBox1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)ControlTab).Controls.Add((Control)(object)ExportSettingsTab);
		((Control)ControlTab).Cursor = Cursors.Hand;
		((Control)ControlTab).Dock = (DockStyle)5;
		((TabControl)ControlTab).ItemSize = new Size(80, 20);
		((Control)ControlTab).Location = new Point(0, 0);
		((Control)ControlTab).Name = "ControlTab";
		((TabControl)ControlTab).SelectedIndex = 0;
		((Control)ControlTab).Size = new Size(631, 543);
		((Control)ControlTab).TabIndex = 0;
		ExportSettingsTab.BackColor = Color.FromArgb(60, 63, 65);
		((Control)ExportSettingsTab).Controls.Add((Control)(object)SettingsTab);
		((Control)ExportSettingsTab).Controls.Add((Control)(object)GroupBox1);
		ExportSettingsTab.Location = new Point(4, 24);
		((Control)ExportSettingsTab).Name = "ExportSettingsTab";
		((Control)ExportSettingsTab).Padding = new Padding(3);
		((Control)ExportSettingsTab).Size = new Size(623, 515);
		ExportSettingsTab.TabIndex = 0;
		ExportSettingsTab.Text = "Export Settings";
		((Control)SettingsTab).Controls.Add((Control)(object)CSVTab);
		((Control)SettingsTab).Controls.Add((Control)(object)XMLTab);
		((Control)SettingsTab).Controls.Add((Control)(object)MSATab);
		((Control)SettingsTab).Controls.Add((Control)(object)SQLServerTab);
		((Control)SettingsTab).Controls.Add((Control)(object)SQLiteTab);
		((Control)SettingsTab).Cursor = Cursors.Hand;
		((TabControl)SettingsTab).ItemSize = new Size(80, 20);
		((Control)SettingsTab).Location = new Point(6, 113);
		((Control)SettingsTab).Name = "SettingsTab";
		((TabControl)SettingsTab).SelectedIndex = 0;
		((Control)SettingsTab).Size = new Size(611, 396);
		((Control)SettingsTab).TabIndex = 2;
		CSVTab.BackColor = Color.FromArgb(60, 63, 65);
		((Control)CSVTab).Controls.Add((Control)(object)PropertyGridCSV);
		CSVTab.Location = new Point(4, 24);
		((Control)CSVTab).Name = "CSVTab";
		((Control)CSVTab).Padding = new Padding(3);
		((Control)CSVTab).Size = new Size(603, 368);
		CSVTab.TabIndex = 0;
		CSVTab.Text = "CSV Settings";
		PropertyGridCSV.BackColor = Color.FromArgb(70, 73, 75);
		PropertyGridCSV.CategoryForeColor = Color.White;
		PropertyGridCSV.CommandsForeColor = Color.White;
		PropertyGridCSV.HelpBackColor = Color.FromArgb(80, 83, 85);
		PropertyGridCSV.HelpForeColor = Color.White;
		PropertyGridCSV.LineColor = Color.FromArgb(110, 113, 115);
		((Control)PropertyGridCSV).Location = new Point(3, 3);
		((Control)PropertyGridCSV).Name = "PropertyGridCSV";
		PropertyGridCSV.PropertySort = (PropertySort)1;
		((Control)PropertyGridCSV).Size = new Size(597, 362);
		((Control)PropertyGridCSV).TabIndex = 1;
		PropertyGridCSV.ViewBackColor = Color.FromArgb(60, 63, 65);
		PropertyGridCSV.ViewForeColor = Color.White;
		XMLTab.BackColor = Color.FromArgb(60, 63, 65);
		((Control)XMLTab).Controls.Add((Control)(object)PropertyGridXML);
		XMLTab.Location = new Point(4, 24);
		((Control)XMLTab).Name = "XMLTab";
		((Control)XMLTab).Padding = new Padding(3);
		((Control)XMLTab).Size = new Size(603, 368);
		XMLTab.TabIndex = 1;
		XMLTab.Text = "XML Settings";
		PropertyGridXML.BackColor = Color.FromArgb(70, 73, 75);
		PropertyGridXML.CategoryForeColor = Color.White;
		PropertyGridXML.CommandsBackColor = SystemColors.Control;
		PropertyGridXML.CommandsForeColor = Color.White;
		((Control)PropertyGridXML).Dock = (DockStyle)5;
		PropertyGridXML.HelpBackColor = Color.FromArgb(80, 83, 85);
		PropertyGridXML.HelpForeColor = Color.White;
		PropertyGridXML.LineColor = Color.FromArgb(110, 113, 115);
		((Control)PropertyGridXML).Location = new Point(3, 3);
		((Control)PropertyGridXML).Name = "PropertyGridXML";
		PropertyGridXML.PropertySort = (PropertySort)1;
		((Control)PropertyGridXML).Size = new Size(597, 362);
		((Control)PropertyGridXML).TabIndex = 2;
		PropertyGridXML.ViewBackColor = Color.FromArgb(60, 63, 65);
		PropertyGridXML.ViewForeColor = Color.White;
		MSATab.BackColor = Color.FromArgb(60, 63, 65);
		((Control)MSATab).Controls.Add((Control)(object)PropertyGridMSA);
		MSATab.Location = new Point(4, 24);
		((Control)MSATab).Name = "MSATab";
		((Control)MSATab).Padding = new Padding(3);
		((Control)MSATab).Size = new Size(603, 368);
		MSATab.TabIndex = 2;
		MSATab.Text = "MS Access Settings";
		PropertyGridMSA.BackColor = Color.FromArgb(70, 73, 75);
		PropertyGridMSA.CategoryForeColor = Color.White;
		PropertyGridMSA.CommandsForeColor = Color.White;
		((Control)PropertyGridMSA).Dock = (DockStyle)5;
		PropertyGridMSA.HelpBackColor = Color.FromArgb(80, 83, 85);
		PropertyGridMSA.HelpForeColor = Color.White;
		PropertyGridMSA.LineColor = Color.FromArgb(110, 113, 115);
		((Control)PropertyGridMSA).Location = new Point(3, 3);
		((Control)PropertyGridMSA).Name = "PropertyGridMSA";
		PropertyGridMSA.PropertySort = (PropertySort)1;
		((Control)PropertyGridMSA).Size = new Size(597, 362);
		((Control)PropertyGridMSA).TabIndex = 2;
		PropertyGridMSA.ViewBackColor = Color.FromArgb(60, 63, 65);
		PropertyGridMSA.ViewForeColor = Color.White;
		SQLServerTab.BackColor = Color.FromArgb(60, 63, 65);
		((Control)SQLServerTab).Controls.Add((Control)(object)PropertyGridSQLServer);
		SQLServerTab.Location = new Point(4, 24);
		((Control)SQLServerTab).Name = "SQLServerTab";
		((Control)SQLServerTab).Padding = new Padding(3);
		((Control)SQLServerTab).Size = new Size(603, 368);
		SQLServerTab.TabIndex = 2;
		SQLServerTab.Text = "SQL Server Settings";
		PropertyGridSQLServer.BackColor = Color.FromArgb(70, 73, 75);
		PropertyGridSQLServer.CategoryForeColor = Color.White;
		PropertyGridSQLServer.CommandsForeColor = Color.White;
		((Control)PropertyGridSQLServer).Dock = (DockStyle)5;
		PropertyGridSQLServer.HelpBackColor = Color.FromArgb(80, 83, 85);
		PropertyGridSQLServer.HelpForeColor = Color.White;
		PropertyGridSQLServer.LineColor = Color.FromArgb(110, 113, 115);
		((Control)PropertyGridSQLServer).Location = new Point(3, 3);
		((Control)PropertyGridSQLServer).Name = "PropertyGridSQLServer";
		PropertyGridSQLServer.PropertySort = (PropertySort)1;
		((Control)PropertyGridSQLServer).Size = new Size(597, 362);
		((Control)PropertyGridSQLServer).TabIndex = 2;
		PropertyGridSQLServer.ViewBackColor = Color.FromArgb(60, 63, 65);
		PropertyGridSQLServer.ViewForeColor = Color.White;
		SQLiteTab.BackColor = Color.FromArgb(60, 63, 65);
		((Control)SQLiteTab).Controls.Add((Control)(object)PropertyGridSQLite);
		SQLiteTab.Location = new Point(4, 24);
		((Control)SQLiteTab).Name = "SQLiteTab";
		((Control)SQLiteTab).Padding = new Padding(3);
		((Control)SQLiteTab).Size = new Size(603, 368);
		SQLiteTab.TabIndex = 2;
		SQLiteTab.Text = "SQLite Settings";
		PropertyGridSQLite.BackColor = Color.FromArgb(70, 73, 75);
		PropertyGridSQLite.CategoryForeColor = Color.White;
		PropertyGridSQLite.CommandsForeColor = Color.White;
		((Control)PropertyGridSQLite).Dock = (DockStyle)5;
		PropertyGridSQLite.HelpBackColor = Color.FromArgb(80, 83, 85);
		PropertyGridSQLite.HelpForeColor = Color.White;
		PropertyGridSQLite.LineColor = Color.FromArgb(110, 113, 115);
		((Control)PropertyGridSQLite).Location = new Point(3, 3);
		((Control)PropertyGridSQLite).Name = "PropertyGridSQLite";
		PropertyGridSQLite.PropertySort = (PropertySort)1;
		((Control)PropertyGridSQLite).Size = new Size(597, 362);
		((Control)PropertyGridSQLite).TabIndex = 2;
		PropertyGridSQLite.ViewBackColor = Color.FromArgb(60, 63, 65);
		PropertyGridSQLite.ViewForeColor = Color.White;
		((Control)GroupBox1).Controls.Add((Control)(object)TB_OutputRootDirectoryValue);
		((Control)GroupBox1).Controls.Add((Control)(object)Start_StopButton);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_OutputSeparated);
		((Control)GroupBox1).Controls.Add((Control)(object)OutputDirectoryButton);
		((Control)GroupBox1).Controls.Add((Control)(object)OutputRootDirectory);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_ExportSIMDIS);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_ExportSQLite);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_ExportSQLServer);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_ExportCSV);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_ExportMSAccess);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_ExportTacview2x);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_ExportXML);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_ExportTacview1x);
		((Control)GroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox1).Location = new Point(6, 6);
		((Control)GroupBox1).Name = "GroupBox1";
		((Control)GroupBox1).Size = new Size(611, 101);
		((Control)GroupBox1).TabIndex = 11;
		((GroupBox)GroupBox1).TabStop = false;
		((GroupBox)GroupBox1).Text = "Export to:";
		TB_OutputRootDirectoryValue.AutoCompleteCustomSource = null;
		TB_OutputRootDirectoryValue.AutoCompleteMode = (AutoCompleteMode)0;
		TB_OutputRootDirectoryValue.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_OutputRootDirectoryValue).BackColor = Color.Transparent;
		((Control)TB_OutputRootDirectoryValue).ForeColor = Color.FromArgb(189, 189, 189);
		TB_OutputRootDirectoryValue.Image = null;
		TB_OutputRootDirectoryValue.Lines = null;
		((Control)TB_OutputRootDirectoryValue).Location = new Point(104, 46);
		TB_OutputRootDirectoryValue.MaxLength = 32767;
		TB_OutputRootDirectoryValue.Multiline = false;
		((Control)TB_OutputRootDirectoryValue).Name = "TB_OutputRootDirectoryValue";
		TB_OutputRootDirectoryValue.ReadOnly = false;
		TB_OutputRootDirectoryValue.ScrollBars = (ScrollBars)0;
		TB_OutputRootDirectoryValue.SelectionStart = 0;
		((Control)TB_OutputRootDirectoryValue).Size = new Size(257, 24);
		((Control)TB_OutputRootDirectoryValue).TabIndex = 18;
		TB_OutputRootDirectoryValue.TextAlign = (HorizontalAlignment)0;
		TB_OutputRootDirectoryValue.UseSystemPasswordChar = false;
		TB_OutputRootDirectoryValue.WatermarkText = "";
		((ButtonBase)Start_StopButton).BackColor = Color.Transparent;
		((Button)Start_StopButton).DialogResult = (DialogResult)0;
		((Control)Start_StopButton).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Start_StopButton).ForeColor = Color.Green;
		((Control)Start_StopButton).Location = new Point(473, 46);
		((Control)Start_StopButton).Name = "Start_StopButton";
		Start_StopButton.RoundRadius = 0;
		((Control)Start_StopButton).Size = new Size(131, 49);
		((Control)Start_StopButton).TabIndex = 17;
		Start_StopButton.Text = "Start";
		((ButtonBase)CB_OutputSeparated).AutoSize = true;
		((Control)CB_OutputSeparated).Location = new Point(9, 72);
		((Control)CB_OutputSeparated).Name = "CB_OutputSeparated";
		((Control)CB_OutputSeparated).Size = new Size(328, 17);
		((Control)CB_OutputSeparated).TabIndex = 16;
		((ButtonBase)CB_OutputSeparated).Text = "Each run is separated in a different folder (Partition output mode)";
		((ButtonBase)OutputDirectoryButton).BackColor = Color.Transparent;
		((Button)OutputDirectoryButton).DialogResult = (DialogResult)0;
		((Control)OutputDirectoryButton).ForeColor = SystemColors.Control;
		((Control)OutputDirectoryButton).Location = new Point(367, 46);
		((Control)OutputDirectoryButton).Name = "OutputDirectoryButton";
		OutputDirectoryButton.RoundRadius = 0;
		((Control)OutputDirectoryButton).Size = new Size(51, 24);
		((Control)OutputDirectoryButton).TabIndex = 15;
		OutputDirectoryButton.Text = "Change";
		OutputRootDirectory.AutoSize = true;
		((Control)OutputRootDirectory).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)OutputRootDirectory).Location = new Point(6, 49);
		((Control)OutputRootDirectory).Name = "OutputRootDirectory";
		((Control)OutputRootDirectory).Size = new Size(92, 13);
		((Control)OutputRootDirectory).TabIndex = 13;
		((Label)OutputRootDirectory).Text = "Output root folder:";
		((ButtonBase)CB_ExportSIMDIS).AutoSize = true;
		((Control)CB_ExportSIMDIS).Location = new Point(196, 19);
		((Control)CB_ExportSIMDIS).Name = "CB_ExportSIMDIS";
		((Control)CB_ExportSIMDIS).Size = new Size(63, 17);
		((Control)CB_ExportSIMDIS).TabIndex = 12;
		((ButtonBase)CB_ExportSIMDIS).Text = "SIMDIS";
		((ButtonBase)CB_ExportSQLite).AutoSize = true;
		((Control)CB_ExportSQLite).Location = new Point(524, 19);
		((Control)CB_ExportSQLite).Name = "CB_ExportSQLite";
		((Control)CB_ExportSQLite).Size = new Size(58, 17);
		((Control)CB_ExportSQLite).TabIndex = 11;
		((ButtonBase)CB_ExportSQLite).Text = "SQLite";
		((ButtonBase)CB_ExportSQLServer).AutoSize = true;
		((Control)CB_ExportSQLServer).Location = new Point(352, 19);
		((Control)CB_ExportSQLServer).Name = "CB_ExportSQLServer";
		((Control)CB_ExportSQLServer).Size = new Size(81, 17);
		((Control)CB_ExportSQLServer).TabIndex = 10;
		((ButtonBase)CB_ExportSQLServer).Text = "SQL Server";
		((ButtonBase)CB_ExportCSV).AutoSize = true;
		((Control)CB_ExportCSV).Location = new Point(6, 19);
		((Control)CB_ExportCSV).Name = "CB_ExportCSV";
		((Control)CB_ExportCSV).Size = new Size(47, 17);
		((Control)CB_ExportCSV).TabIndex = 5;
		((ButtonBase)CB_ExportCSV).Text = "CSV";
		((ButtonBase)CB_ExportMSAccess).AutoSize = true;
		((Control)CB_ExportMSAccess).Location = new Point(110, 19);
		((Control)CB_ExportMSAccess).Name = "CB_ExportMSAccess";
		((Control)CB_ExportMSAccess).Size = new Size(80, 17);
		((Control)CB_ExportMSAccess).TabIndex = 7;
		((ButtonBase)CB_ExportMSAccess).Text = "MS Access";
		((ButtonBase)CB_ExportTacview2x).AutoSize = true;
		((Control)CB_ExportTacview2x).Location = new Point(437, 19);
		((Control)CB_ExportTacview2x).Name = "CB_ExportTacview2x";
		((Control)CB_ExportTacview2x).Size = new Size(84, 17);
		((Control)CB_ExportTacview2x).TabIndex = 8;
		((ButtonBase)CB_ExportTacview2x).Text = "Tacview 2.x";
		((ButtonBase)CB_ExportXML).AutoSize = true;
		((Control)CB_ExportXML).Location = new Point(59, 19);
		((Control)CB_ExportXML).Name = "CB_ExportXML";
		((Control)CB_ExportXML).Size = new Size(48, 17);
		((Control)CB_ExportXML).TabIndex = 4;
		((ButtonBase)CB_ExportXML).Text = "XML";
		((ButtonBase)CB_ExportTacview1x).AutoSize = true;
		((Control)CB_ExportTacview1x).Location = new Point(262, 19);
		((Control)CB_ExportTacview1x).Name = "CB_ExportTacview1x";
		((Control)CB_ExportTacview1x).Size = new Size(84, 17);
		((Control)CB_ExportTacview1x).TabIndex = 6;
		((ButtonBase)CB_ExportTacview1x).Text = "Tacview 1.x";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 63, 65);
		((Form)this).ClientSize = new Size(631, 543);
		((Control)this).Controls.Add((Control)(object)ControlTab);
		((Form)this).MaximumSize = new Size(647, 582);
		((Form)this).MinimumSize = new Size(647, 582);
		((Control)this).Name = "InteractiveAnalysisForm";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Interactive Analysis";
		((Control)ControlTab).ResumeLayout(false);
		((Control)ExportSettingsTab).ResumeLayout(false);
		((Control)SettingsTab).ResumeLayout(false);
		((Control)CSVTab).ResumeLayout(false);
		((Control)XMLTab).ResumeLayout(false);
		((Control)MSATab).ResumeLayout(false);
		((Control)SQLServerTab).ResumeLayout(false);
		((Control)SQLiteTab).ResumeLayout(false);
		((Control)GroupBox1).ResumeLayout(false);
		((Control)GroupBox1).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	static InteractiveAnalysisForm()
	{
		Class72.smethod_20();
	}
}
