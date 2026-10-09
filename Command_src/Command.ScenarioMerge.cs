using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ScenarioMerge : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("Button_Scenario1File")]
	[CompilerGenerated]
	private DarkUIButton _Button_Scenario1File;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel VgjHhbRyUrq;

	[AccessedThroughProperty("Button_Scenario2File")]
	[CompilerGenerated]
	private DarkUIButton _Button_Scenario2File;

	[AccessedThroughProperty("Button_MergeResultFile")]
	[CompilerGenerated]
	private DarkUIButton _Button_MergeResultFile;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Merge")]
	private DarkUIButton _Button_Merge;

	[AccessedThroughProperty("OpenFileDialog1")]
	[CompilerGenerated]
	private OpenFileDialog openFileDialog_0;

	[CompilerGenerated]
	[AccessedThroughProperty("SaveFileDialog1")]
	private SaveFileDialog saveFileDialog_0;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private Timer timer_0;

	private string string_0;

	private string string_1;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("TextBox_Scenario1")]
	internal virtual DarkUITextBox TextBox_Scenario1 { get; set; }

	internal virtual DarkUIButton Button_Scenario1File
	{
		[CompilerGenerated]
		get
		{
			return _Button_Scenario1File;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _Button_Scenario1File;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Scenario1File = value;
			darkUIButton = _Button_Scenario1File;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return VgjHhbRyUrq;
		}
		[CompilerGenerated]
		set
		{
			VgjHhbRyUrq = value;
		}
	}

	[field: AccessedThroughProperty("TextBox_Scenario2")]
	internal virtual DarkUITextBox TextBox_Scenario2 { get; set; }

	internal virtual DarkUIButton Button_Scenario2File
	{
		[CompilerGenerated]
		get
		{
			return _Button_Scenario2File;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIButton darkUIButton = _Button_Scenario2File;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Scenario2File = value;
			darkUIButton = _Button_Scenario2File;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("TextBox_MergeResult")]
	internal virtual DarkUITextBox TextBox_MergeResult { get; set; }

	internal virtual DarkUIButton Button_MergeResultFile
	{
		[CompilerGenerated]
		get
		{
			return _Button_MergeResultFile;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIButton darkUIButton = _Button_MergeResultFile;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_MergeResultFile = value;
			darkUIButton = _Button_MergeResultFile;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_Merge
	{
		[CompilerGenerated]
		get
		{
			return _Button_Merge;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button_Merge;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Merge = value;
			darkUIButton = _Button_Merge;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual OpenFileDialog OpenFileDialog1
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

	[field: AccessedThroughProperty("Label_DBMatch")]
	internal virtual DarkLabel Label_DBMatch { get; set; }

	[field: AccessedThroughProperty("Combo_DBMatch")]
	internal virtual DarkUIComboBox Combo_DBMatch { get; set; }

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

	internal virtual Timer Timer1
	{
		[CompilerGenerated]
		get
		{
			return timer_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			Timer val = timer_0;
			if (val != null)
			{
				val.Tick -= eventHandler;
			}
			timer_0 = value;
			val = timer_0;
			if (val != null)
			{
				val.Tick += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual DarkUITextBox TextBox1 { get; set; }

	[field: AccessedThroughProperty("CB_AllowSameSide")]
	internal virtual DarkCheckBox CB_AllowSameSide { get; set; }

	public ScenarioMerge()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Shown += ScenarioMerge_Shown;
		((Control)this).KeyDown += new KeyEventHandler(ScenarioMerge_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(ScenarioMerge_FormClosing);
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
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_07fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0805: Expected O, but got Unknown
		//IL_095e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0968: Expected O, but got Unknown
		icontainer_1 = new Container();
		Label1 = new DarkLabel();
		TextBox_Scenario1 = new DarkUITextBox();
		Button_Scenario1File = new DarkUIButton();
		Label2 = new DarkLabel();
		TextBox_Scenario2 = new DarkUITextBox();
		Button_Scenario2File = new DarkUIButton();
		Label4 = new DarkLabel();
		TextBox_MergeResult = new DarkUITextBox();
		Button_MergeResultFile = new DarkUIButton();
		Button_Merge = new DarkUIButton();
		OpenFileDialog1 = new OpenFileDialog();
		Label_DBMatch = new DarkLabel();
		Combo_DBMatch = new DarkUIComboBox();
		SaveFileDialog1 = new SaveFileDialog();
		Timer1 = new Timer(icontainer_1);
		TextBox1 = new DarkUITextBox();
		CB_AllowSameSide = new DarkCheckBox();
		((Control)this).SuspendLayout();
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(0, 16);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(71, 15);
		((Control)Label1).TabIndex = 8;
		((Label)Label1).Text = "Scenario #1:";
		((Control)TextBox_Scenario1).Anchor = (AnchorStyles)13;
		TextBox_Scenario1.AutoCompleteCustomSource = null;
		TextBox_Scenario1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_Scenario1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_Scenario1).BackColor = Color.FromArgb(69, 73, 74);
		((Control)TextBox_Scenario1).ForeColor = Color.FromArgb(220, 220, 220);
		TextBox_Scenario1.Image = null;
		TextBox_Scenario1.Lines = null;
		((Control)TextBox_Scenario1).Location = new Point(120, 12);
		TextBox_Scenario1.MaxLength = 32767;
		TextBox_Scenario1.Multiline = false;
		((Control)TextBox_Scenario1).Name = "TextBox_Scenario1";
		TextBox_Scenario1.ReadOnly = false;
		TextBox_Scenario1.ScrollBars = (ScrollBars)0;
		TextBox_Scenario1.SelectionStart = 0;
		((Control)TextBox_Scenario1).Size = new Size(413, 23);
		((Control)TextBox_Scenario1).TabIndex = 9;
		TextBox_Scenario1.TextAlign = (HorizontalAlignment)0;
		TextBox_Scenario1.UseSystemPasswordChar = false;
		TextBox_Scenario1.WatermarkText = "";
		((Control)Button_Scenario1File).Anchor = (AnchorStyles)9;
		((ButtonBase)Button_Scenario1File).BackColor = Color.Transparent;
		((Button)Button_Scenario1File).DialogResult = (DialogResult)0;
		((Control)Button_Scenario1File).ForeColor = SystemColors.Control;
		((Control)Button_Scenario1File).Location = new Point(539, 12);
		((Control)Button_Scenario1File).Name = "Button_Scenario1File";
		Button_Scenario1File.RoundRadius = 0;
		((Control)Button_Scenario1File).Size = new Size(73, 23);
		((Control)Button_Scenario1File).TabIndex = 10;
		Button_Scenario1File.Text = "Select...";
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(0, 42);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(71, 15);
		((Control)Label2).TabIndex = 11;
		((Label)Label2).Text = "Scenario #2:";
		((Control)TextBox_Scenario2).Anchor = (AnchorStyles)13;
		TextBox_Scenario2.AutoCompleteCustomSource = null;
		TextBox_Scenario2.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_Scenario2.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_Scenario2).BackColor = Color.FromArgb(69, 73, 74);
		((Control)TextBox_Scenario2).ForeColor = Color.FromArgb(220, 220, 220);
		TextBox_Scenario2.Image = null;
		TextBox_Scenario2.Lines = null;
		((Control)TextBox_Scenario2).Location = new Point(120, 39);
		TextBox_Scenario2.MaxLength = 32767;
		TextBox_Scenario2.Multiline = false;
		((Control)TextBox_Scenario2).Name = "TextBox_Scenario2";
		TextBox_Scenario2.ReadOnly = false;
		TextBox_Scenario2.ScrollBars = (ScrollBars)0;
		TextBox_Scenario2.SelectionStart = 0;
		((Control)TextBox_Scenario2).Size = new Size(413, 23);
		((Control)TextBox_Scenario2).TabIndex = 12;
		TextBox_Scenario2.TextAlign = (HorizontalAlignment)0;
		TextBox_Scenario2.UseSystemPasswordChar = false;
		TextBox_Scenario2.WatermarkText = "";
		((Control)Button_Scenario2File).Anchor = (AnchorStyles)9;
		((ButtonBase)Button_Scenario2File).BackColor = Color.Transparent;
		((Button)Button_Scenario2File).DialogResult = (DialogResult)0;
		((Control)Button_Scenario2File).ForeColor = SystemColors.Control;
		((Control)Button_Scenario2File).Location = new Point(539, 39);
		((Control)Button_Scenario2File).Name = "Button_Scenario2File";
		Button_Scenario2File.RoundRadius = 0;
		((Control)Button_Scenario2File).Size = new Size(73, 23);
		((Control)Button_Scenario2File).TabIndex = 13;
		Button_Scenario2File.Text = "Select...";
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(0, 68);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(98, 15);
		((Control)Label4).TabIndex = 14;
		((Label)Label4).Text = "Merged scenario:";
		((Control)TextBox_MergeResult).Anchor = (AnchorStyles)13;
		TextBox_MergeResult.AutoCompleteCustomSource = null;
		TextBox_MergeResult.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_MergeResult.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_MergeResult).BackColor = Color.FromArgb(69, 73, 74);
		((Control)TextBox_MergeResult).ForeColor = Color.FromArgb(220, 220, 220);
		TextBox_MergeResult.Image = null;
		TextBox_MergeResult.Lines = null;
		((Control)TextBox_MergeResult).Location = new Point(120, 65);
		TextBox_MergeResult.MaxLength = 32767;
		TextBox_MergeResult.Multiline = false;
		((Control)TextBox_MergeResult).Name = "TextBox_MergeResult";
		TextBox_MergeResult.ReadOnly = false;
		TextBox_MergeResult.ScrollBars = (ScrollBars)0;
		TextBox_MergeResult.SelectionStart = 0;
		((Control)TextBox_MergeResult).Size = new Size(413, 23);
		((Control)TextBox_MergeResult).TabIndex = 15;
		TextBox_MergeResult.TextAlign = (HorizontalAlignment)0;
		TextBox_MergeResult.UseSystemPasswordChar = false;
		TextBox_MergeResult.WatermarkText = "";
		((Control)Button_MergeResultFile).Anchor = (AnchorStyles)9;
		((ButtonBase)Button_MergeResultFile).BackColor = Color.Transparent;
		((Button)Button_MergeResultFile).DialogResult = (DialogResult)0;
		((Control)Button_MergeResultFile).ForeColor = SystemColors.Control;
		((Control)Button_MergeResultFile).Location = new Point(539, 65);
		((Control)Button_MergeResultFile).Name = "Button_MergeResultFile";
		Button_MergeResultFile.RoundRadius = 0;
		((Control)Button_MergeResultFile).Size = new Size(73, 23);
		((Control)Button_MergeResultFile).TabIndex = 16;
		Button_MergeResultFile.Text = "Select...";
		((Control)Button_Merge).Anchor = (AnchorStyles)15;
		((ButtonBase)Button_Merge).BackColor = Color.Transparent;
		((Button)Button_Merge).DialogResult = (DialogResult)0;
		((Control)Button_Merge).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Button_Merge).ForeColor = SystemColors.Control;
		((Control)Button_Merge).Location = new Point(266, 145);
		((Control)Button_Merge).MaximumSize = new Size(100, 34);
		((Control)Button_Merge).Name = "Button_Merge";
		Button_Merge.RoundRadius = 0;
		((Control)Button_Merge).Size = new Size(100, 34);
		((Control)Button_Merge).TabIndex = 17;
		Button_Merge.Text = "MERGE";
		((FileDialog)OpenFileDialog1).FileName = "OpenFileDialog1";
		Label_DBMatch.AutoSize = true;
		((Control)Label_DBMatch).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_DBMatch).Location = new Point(0, 94);
		((Control)Label_DBMatch).Name = "Label_DBMatch";
		((Control)Label_DBMatch).Size = new Size(114, 15);
		((Control)Label_DBMatch).TabIndex = 18;
		((Label)Label_DBMatch).Text = "DB match tolerance:";
		((ComboBox)Combo_DBMatch).BackColor = Color.Transparent;
		((ComboBox)Combo_DBMatch).DrawMode = (DrawMode)1;
		((ComboBox)Combo_DBMatch).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_DBMatch).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_DBMatch).FormattingEnabled = true;
		((ComboBox)Combo_DBMatch).Items.AddRange(new object[3] { "Scenarios must use same exact DB version (safe)", "Scenarios must use same general DB (risky)", "Do not check for DB match at all (seatbelts off!)" });
		((Control)Combo_DBMatch).Location = new Point(120, 91);
		((Control)Combo_DBMatch).Name = "Combo_DBMatch";
		((Control)Combo_DBMatch).Size = new Size(413, 21);
		((Control)Combo_DBMatch).TabIndex = 19;
		((Control)TextBox1).Anchor = (AnchorStyles)15;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.FromArgb(69, 73, 74);
		((Control)TextBox1).ForeColor = Color.FromArgb(220, 220, 220);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(1, 185);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = true;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = (ScrollBars)2;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(611, 196);
		((Control)TextBox1).TabIndex = 20;
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		((ButtonBase)CB_AllowSameSide).BackColor = Color.Transparent;
		((Control)CB_AllowSameSide).Cursor = Cursors.Hand;
		((Control)CB_AllowSameSide).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)CB_AllowSameSide).Location = new Point(120, 118);
		((Control)CB_AllowSameSide).Name = "CB_AllowSameSide";
		((Control)CB_AllowSameSide).Size = new Size(205, 18);
		((Control)CB_AllowSameSide).TabIndex = 21;
		((ButtonBase)CB_AllowSameSide).Text = "Allow merging clones of the same side";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((Form)this).ClientSize = new Size(613, 379);
		((Control)this).Controls.Add((Control)(object)CB_AllowSameSide);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Controls.Add((Control)(object)Combo_DBMatch);
		((Control)this).Controls.Add((Control)(object)Label_DBMatch);
		((Control)this).Controls.Add((Control)(object)Button_Merge);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)TextBox_MergeResult);
		((Control)this).Controls.Add((Control)(object)Button_MergeResultFile);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)TextBox_Scenario1);
		((Control)this).Controls.Add((Control)(object)Button_Scenario1File);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)TextBox_Scenario2);
		((Control)this).Controls.Add((Control)(object)Button_Scenario2File);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "ScenarioMerge";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Merge scenarios";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void ScenarioMerge_Shown(object sender, EventArgs e)
	{
		((ComboBox)Combo_DBMatch).SelectedIndex = 0;
		((Control)Label_DBMatch).Visible = false;
		((Control)Combo_DBMatch).Visible = false;
		((Control)CB_AllowSameSide).Visible = false;
	}

	private void method_2(object sender, EventArgs e)
	{
		TextBox1.Clear();
		string_1 = string.Empty;
		string_0 = string.Empty;
		string text = TextBox_Scenario1.Text;
		string text2 = TextBox_Scenario2.Text;
		string text3 = TextBox_MergeResult.Text;
		DBOps.DatabaseMatchToleranceLevel dBMatchToleranceLevel = DBOps.DatabaseMatchToleranceLevel.ExactVersion;
		switch (((ComboBox)Combo_DBMatch).SelectedIndex)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		case 0:
			dBMatchToleranceLevel = DBOps.DatabaseMatchToleranceLevel.ExactVersion;
			break;
		case 1:
			dBMatchToleranceLevel = DBOps.DatabaseMatchToleranceLevel.SameFamily;
			break;
		case 2:
			dBMatchToleranceLevel = DBOps.DatabaseMatchToleranceLevel.CompletelyNoMatch;
			break;
		}
		Timer1.Start();
		Task.Factory.StartNew([SpecialName] () =>
		{
			Scenario.MergeScenarios(text, text2, text3, dBMatchToleranceLevel, ((CheckBox)CB_AllowSameSide).Checked, ref string_0);
			((Control)this).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				Timer1.Stop();
				method_7();
			}));
		});
	}

	private void method_3(object sender, EventArgs e)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		((FileDialog)OpenFileDialog1).DefaultExt = "*.scen";
		((FileDialog)OpenFileDialog1).FileName = "*.scen";
		if ((int)((CommonDialog)OpenFileDialog1).ShowDialog() == 1)
		{
			TextBox_Scenario1.Text = ((FileDialog)OpenFileDialog1).FileName;
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		((FileDialog)OpenFileDialog1).DefaultExt = "*.scen";
		((FileDialog)OpenFileDialog1).FileName = "*.scen";
		if ((int)((CommonDialog)OpenFileDialog1).ShowDialog() == 1)
		{
			TextBox_Scenario2.Text = ((FileDialog)OpenFileDialog1).FileName;
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		((FileDialog)SaveFileDialog1).DefaultExt = "*.scen";
		((FileDialog)SaveFileDialog1).Filter = "Command Scenario File|*.scen";
		if ((int)((CommonDialog)SaveFileDialog1).ShowDialog() == 1)
		{
			TextBox_MergeResult.Text = ((FileDialog)SaveFileDialog1).FileName;
		}
	}

	private void ScenarioMerge_KeyDown(object sender, KeyEventArgs e)
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

	private void ScenarioMerge_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_6(object sender, EventArgs e)
	{
		method_7();
	}

	private void method_7()
	{
		if (string.CompareOrdinal(string_0, string_1) > 0)
		{
			((Control)TextBox1).SuspendLayout();
			TextBox1.Clear();
			TextBox1.Text = string_0;
			((Control)TextBox1).ResumeLayout();
			string_1 = string_0;
		}
	}

	static ScenarioMerge()
	{
		Class72.smethod_20();
	}
}
