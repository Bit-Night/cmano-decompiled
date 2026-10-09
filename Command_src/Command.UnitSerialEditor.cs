using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class UnitSerialEditor : DarkSecondaryFormBase
{
	[DoNotPruneType]
	[DoNotPrune]
	[DoNotObfuscateType]
	private class MothershipItem
	{
		public ActiveUnit activeUnit_0;

		public string Name => Mothership.Name;

		public ActiveUnit Mothership
		{
			get
			{
				return activeUnit_0;
			}
			set
			{
				activeUnit_0 = value;
			}
		}

		public MothershipItem(ActiveUnit activeUnit_1)
		{
			activeUnit_0 = activeUnit_1;
		}

		static MothershipItem()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_MothershipHost")]
	private DarkUIComboBox _Combo_MothershipHost;

	[CompilerGenerated]
	[AccessedThroughProperty("LV_Serials")]
	private DarkListView _LV_Serials;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonAddSerial")]
	private DarkUIButton _ButtonAddSerial;

	[AccessedThroughProperty("ButtonRemoveSerial")]
	[CompilerGenerated]
	private DarkUIButton _ButtonRemoveSerial;

	[AccessedThroughProperty("DGV_Assets")]
	[CompilerGenerated]
	private DataGridView _DGV_Assets;

	[AccessedThroughProperty("ButtonRenameChalk")]
	[CompilerGenerated]
	private DarkUIButton _ButtonRenameChalk;

	public Chalk CurrentlySelectedChalk;

	public ActiveUnit CurrentlySelectedMothership;

	public List<CargoManifestItem> CargoGrouped;

	public List<CargoManifestItem> CargoGroupedAssignedToChalk;

	public Dictionary<string, Chalk> CargoChalkAssigned;

	[field: AccessedThroughProperty("DarkGroupBox1")]
	internal virtual DarkGroupBox DarkGroupBox1 { get; set; }

	[field: AccessedThroughProperty("Label_Weight")]
	internal virtual DarkLabel Label_Weight { get; set; }

	[field: AccessedThroughProperty("Label_Crew")]
	internal virtual DarkLabel Label_Crew { get; set; }

	[field: AccessedThroughProperty("Label_Area")]
	internal virtual DarkLabel Label_Area { get; set; }

	internal virtual DarkUIComboBox Combo_MothershipHost
	{
		[CompilerGenerated]
		get
		{
			return _Combo_MothershipHost;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkUIComboBox darkUIComboBox = _Combo_MothershipHost;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_Combo_MothershipHost = value;
			darkUIComboBox = _Combo_MothershipHost;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	[field: AccessedThroughProperty("TB_ChalkID")]
	internal virtual DarkUITextBox TB_ChalkID { get; set; }

	[field: AccessedThroughProperty("Label_LargestCargo")]
	internal virtual DarkLabel Label_LargestCargo { get; set; }

	[field: AccessedThroughProperty("DarkLabel5")]
	internal virtual DarkLabel DarkLabel5 { get; set; }

	internal virtual DarkListView LV_Serials
	{
		[CompilerGenerated]
		get
		{
			return _LV_Serials;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_2;
			DarkListView darkListView = _LV_Serials;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
			}
			_LV_Serials = value;
			darkListView = _LV_Serials;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1 { get; set; }

	internal virtual DarkUIButton ButtonAddSerial
	{
		[CompilerGenerated]
		get
		{
			return _ButtonAddSerial;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkUIButton darkUIButton = _ButtonAddSerial;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonAddSerial = value;
			darkUIButton = _ButtonAddSerial;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox2")]
	internal virtual DarkGroupBox DarkGroupBox2 { get; set; }

	internal virtual DarkUIButton ButtonRemoveSerial
	{
		[CompilerGenerated]
		get
		{
			return _ButtonRemoveSerial;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkUIButton darkUIButton = _ButtonRemoveSerial;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonRemoveSerial = value;
			darkUIButton = _ButtonRemoveSerial;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox3")]
	internal virtual DarkGroupBox DarkGroupBox3 { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox5")]
	internal virtual DarkGroupBox DarkGroupBox5 { get; set; }

	[field: AccessedThroughProperty("LV_PossibleTransport")]
	internal virtual DarkListView LV_PossibleTransport { get; set; }

	internal virtual DataGridView DGV_Assets
	{
		[CompilerGenerated]
		get
		{
			return _DGV_Assets;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_13);
			DataGridView val2 = _DGV_Assets;
			if (val2 != null)
			{
				val2.CellContentClick -= val;
			}
			_DGV_Assets = value;
			val2 = _DGV_Assets;
			if (val2 != null)
			{
				val2.CellContentClick += val;
			}
		}
	}

	[field: AccessedThroughProperty("DarkUIButton4")]
	internal virtual DarkUIButton DarkUIButton4 { get; set; }

	[field: AccessedThroughProperty("DarkUIButton5")]
	internal virtual DarkUIButton DarkUIButton5 { get; set; }

	internal virtual DarkUIButton ButtonRenameChalk
	{
		[CompilerGenerated]
		get
		{
			return _ButtonRenameChalk;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkUIButton darkUIButton = _ButtonRenameChalk;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonRenameChalk = value;
			darkUIButton = _ButtonRenameChalk;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Warning_NoMothership")]
	internal virtual DarkLabel Warning_NoMothership { get; set; }

	[field: AccessedThroughProperty("ModInfos")]
	internal virtual DarkLabel ModInfos { get; set; }

	public UnitSerialEditor()
	{
		((Form)this).Load += hpiHqusYdvL;
		CargoGrouped = new List<CargoManifestItem>();
		CargoGroupedAssignedToChalk = new List<CargoManifestItem>();
		CargoChalkAssigned = new Dictionary<string, Chalk>();
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
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Expected O, but got Unknown
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected O, but got Unknown
		//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e3: Expected O, but got Unknown
		//IL_0692: Unknown result type (might be due to invalid IL or missing references)
		//IL_069c: Expected O, but got Unknown
		//IL_0ae6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f51: Expected O, but got Unknown
		//IL_1160: Unknown result type (might be due to invalid IL or missing references)
		//IL_116a: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DarkLabel4 = new DarkLabel();
		DarkGroupBox3 = new DarkGroupBox();
		ModInfos = new DarkLabel();
		DGV_Assets = new DataGridView();
		DarkGroupBox2 = new DarkGroupBox();
		ButtonRemoveSerial = new DarkUIButton();
		ButtonAddSerial = new DarkUIButton();
		LV_Serials = new DarkListView();
		DarkGroupBox1 = new DarkGroupBox();
		ButtonRenameChalk = new DarkUIButton();
		DarkGroupBox5 = new DarkGroupBox();
		LV_PossibleTransport = new DarkListView();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		Label_LargestCargo = new DarkLabel();
		Label_Weight = new DarkLabel();
		Label_Area = new DarkLabel();
		Label_Crew = new DarkLabel();
		TB_ChalkID = new DarkUITextBox();
		DarkLabel5 = new DarkLabel();
		Warning_NoMothership = new DarkLabel();
		DarkUIButton5 = new DarkUIButton();
		DarkUIButton4 = new DarkUIButton();
		Combo_MothershipHost = new DarkUIComboBox();
		((Control)DarkGroupBox3).SuspendLayout();
		((ISupportInitialize)DGV_Assets).BeginInit();
		((Control)DarkGroupBox2).SuspendLayout();
		((Control)DarkGroupBox1).SuspendLayout();
		((Control)DarkGroupBox5).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((Control)this).SuspendLayout();
		DarkLabel4.AutoSize = true;
		((Control)DarkLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel4).Location = new Point(15, 10);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(29, 13);
		((Control)DarkLabel4).TabIndex = 2;
		((Label)DarkLabel4).Text = "Host";
		((Control)DarkGroupBox3).Anchor = (AnchorStyles)15;
		((Control)DarkGroupBox3).Controls.Add((Control)(object)ModInfos);
		((Control)DarkGroupBox3).Controls.Add((Control)(object)DGV_Assets);
		((Control)DarkGroupBox3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox3).Location = new Point(100, 197);
		((Control)DarkGroupBox3).Name = "DarkGroupBox3";
		((Control)DarkGroupBox3).Size = new Size(617, 233);
		((Control)DarkGroupBox3).TabIndex = 13;
		((GroupBox)DarkGroupBox3).TabStop = false;
		((GroupBox)DarkGroupBox3).Text = "Assets in Serial";
		ModInfos.AutoSize = true;
		((Control)ModInfos).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ModInfos).Location = new Point(104, 0);
		((Control)ModInfos).Name = "ModInfos";
		((Control)ModInfos).Size = new Size(96, 13);
		((Control)ModInfos).TabIndex = 9;
		((Label)ModInfos).Text = "(Ctrl +5 / Shift +10)";
		DGV_Assets.AllowUserToAddRows = false;
		DGV_Assets.AllowUserToDeleteRows = false;
		DGV_Assets.AllowUserToResizeColumns = false;
		DGV_Assets.AllowUserToResizeRows = false;
		((Control)DGV_Assets).Anchor = (AnchorStyles)15;
		DGV_Assets.BackgroundColor = Color.Silver;
		DGV_Assets.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		val.Alignment = (DataGridViewContentAlignment)32;
		val.BackColor = SystemColors.Window;
		val.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(220, 220, 220);
		val.SelectionBackColor = SystemColors.Highlight;
		val.SelectionForeColor = SystemColors.ControlText;
		val.WrapMode = (DataGridViewTriState)2;
		DGV_Assets.DefaultCellStyle = val;
		((Control)DGV_Assets).Location = new Point(6, 19);
		DGV_Assets.MultiSelect = false;
		((Control)DGV_Assets).Name = "DGV_Assets";
		val2.Alignment = (DataGridViewContentAlignment)32;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = SystemColors.WindowText;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.ControlText;
		val2.WrapMode = (DataGridViewTriState)1;
		DGV_Assets.RowHeadersDefaultCellStyle = val2;
		DGV_Assets.RowHeadersVisible = false;
		DGV_Assets.RowHeadersWidth = 51;
		val3.ForeColor = Color.Black;
		val3.SelectionForeColor = Color.Black;
		DGV_Assets.RowsDefaultCellStyle = val3;
		((Control)DGV_Assets).Size = new Size(605, 208);
		((Control)DGV_Assets).TabIndex = 0;
		((Control)DarkGroupBox2).Anchor = (AnchorStyles)7;
		((Control)DarkGroupBox2).Controls.Add((Control)(object)ButtonRemoveSerial);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)ButtonAddSerial);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)LV_Serials);
		((Control)DarkGroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox2).Location = new Point(11, 35);
		((Control)DarkGroupBox2).Name = "DarkGroupBox2";
		((Control)DarkGroupBox2).Size = new Size(81, 395);
		((Control)DarkGroupBox2).TabIndex = 9;
		((GroupBox)DarkGroupBox2).TabStop = false;
		((GroupBox)DarkGroupBox2).Text = "Serials #";
		((Control)ButtonRemoveSerial).Anchor = (AnchorStyles)6;
		((ButtonBase)ButtonRemoveSerial).BackColor = Color.Transparent;
		((Button)ButtonRemoveSerial).DialogResult = (DialogResult)0;
		((Control)ButtonRemoveSerial).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ButtonRemoveSerial).ForeColor = SystemColors.Control;
		((Control)ButtonRemoveSerial).Location = new Point(43, 366);
		((Control)ButtonRemoveSerial).Name = "ButtonRemoveSerial";
		ButtonRemoveSerial.RoundRadius = 0;
		((Control)ButtonRemoveSerial).Size = new Size(31, 23);
		((Control)ButtonRemoveSerial).TabIndex = 9;
		ButtonRemoveSerial.Text = "-";
		((Control)ButtonAddSerial).Anchor = (AnchorStyles)6;
		((ButtonBase)ButtonAddSerial).BackColor = Color.Transparent;
		((Button)ButtonAddSerial).DialogResult = (DialogResult)0;
		((Control)ButtonAddSerial).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ButtonAddSerial).ForeColor = SystemColors.Control;
		((Control)ButtonAddSerial).Location = new Point(7, 366);
		((Control)ButtonAddSerial).Name = "ButtonAddSerial";
		ButtonAddSerial.RoundRadius = 0;
		((Control)ButtonAddSerial).Size = new Size(31, 23);
		((Control)ButtonAddSerial).TabIndex = 8;
		ButtonAddSerial.Text = "+";
		((Control)LV_Serials).Anchor = (AnchorStyles)15;
		((Control)LV_Serials).BackColor = Color.FromArgb(50, 53, 55);
		((Control)LV_Serials).Location = new Point(7, 22);
		((Control)LV_Serials).Name = "LV_Serials";
		LV_Serials.RelatedInfos = null;
		((Control)LV_Serials).Size = new Size(67, 338);
		((Control)LV_Serials).TabIndex = 7;
		((Control)LV_Serials).Text = "LV_Serials";
		((Control)DarkGroupBox1).Anchor = (AnchorStyles)13;
		((Control)DarkGroupBox1).Controls.Add((Control)(object)ButtonRenameChalk);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)DarkGroupBox5);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)TB_ChalkID);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)DarkLabel5);
		((Control)DarkGroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox1).Location = new Point(100, 36);
		((Control)DarkGroupBox1).Name = "DarkGroupBox1";
		((Control)DarkGroupBox1).Size = new Size(617, 155);
		((Control)DarkGroupBox1).TabIndex = 0;
		((GroupBox)DarkGroupBox1).TabStop = false;
		((GroupBox)DarkGroupBox1).Text = "Informations";
		((ButtonBase)ButtonRenameChalk).BackColor = Color.Transparent;
		((Button)ButtonRenameChalk).DialogResult = (DialogResult)0;
		((Control)ButtonRenameChalk).ForeColor = SystemColors.Control;
		((Control)ButtonRenameChalk).Location = new Point(6, 44);
		((Control)ButtonRenameChalk).Name = "ButtonRenameChalk";
		ButtonRenameChalk.RoundRadius = 0;
		((Control)ButtonRenameChalk).Size = new Size(132, 23);
		((Control)ButtonRenameChalk).TabIndex = 8;
		ButtonRenameChalk.Text = "Rename";
		((Control)DarkGroupBox5).Anchor = (AnchorStyles)13;
		((Control)DarkGroupBox5).Controls.Add((Control)(object)LV_PossibleTransport);
		((Control)DarkGroupBox5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox5).Location = new Point(202, 18);
		((Control)DarkGroupBox5).Name = "DarkGroupBox5";
		((Control)DarkGroupBox5).Size = new Size(409, 131);
		((Control)DarkGroupBox5).TabIndex = 7;
		((GroupBox)DarkGroupBox5).TabStop = false;
		((GroupBox)DarkGroupBox5).Text = "Eligible Tranports [Capacity]";
		((Control)LV_PossibleTransport).Anchor = (AnchorStyles)13;
		((Control)LV_PossibleTransport).BackColor = Color.FromArgb(50, 53, 55);
		((Control)LV_PossibleTransport).Location = new Point(5, 19);
		((Control)LV_PossibleTransport).MinimumSize = new Size(379, 106);
		((Control)LV_PossibleTransport).Name = "LV_PossibleTransport";
		LV_PossibleTransport.RelatedInfos = null;
		((Control)LV_PossibleTransport).Size = new Size(379, 106);
		((Control)LV_PossibleTransport).TabIndex = 0;
		((Control)LV_PossibleTransport).Text = "DarkListView1";
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Label_LargestCargo);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Label_Weight);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Label_Area);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Label_Crew);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)1;
		((Control)FlowLayoutPanel1).Location = new Point(6, 69);
		((Control)FlowLayoutPanel1).Margin = new Padding(5);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Padding = new Padding(0, 1, 1, 1);
		((Control)FlowLayoutPanel1).Size = new Size(188, 80);
		((Control)FlowLayoutPanel1).TabIndex = 4;
		Label_LargestCargo.AutoSize = true;
		((Control)Label_LargestCargo).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_LargestCargo).Location = new Point(3, 1);
		((Control)Label_LargestCargo).Name = "Label_LargestCargo";
		((Control)Label_LargestCargo).Padding = new Padding(2);
		((Control)Label_LargestCargo).Size = new Size(114, 17);
		((Control)Label_LargestCargo).TabIndex = 3;
		((Label)Label_LargestCargo).Text = "Largest cargo type : L";
		Label_Weight.AutoSize = true;
		((Control)Label_Weight).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Weight).Location = new Point(3, 18);
		((Control)Label_Weight).Name = "Label_Weight";
		((Control)Label_Weight).Padding = new Padding(2);
		((Control)Label_Weight).Size = new Size(93, 17);
		((Control)Label_Weight).TabIndex = 0;
		((Label)Label_Weight).Text = "Weight : 58 Tons";
		Label_Area.AutoSize = true;
		((Control)Label_Area).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Area).Location = new Point(3, 35);
		((Control)Label_Area).Name = "Label_Area";
		((Control)Label_Area).Padding = new Padding(2);
		((Control)Label_Area).Size = new Size(71, 17);
		((Control)Label_Area).TabIndex = 1;
		((Label)Label_Area).Text = "Area : 28 m2";
		Label_Crew.AutoSize = true;
		((Control)Label_Crew).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Crew).Location = new Point(3, 52);
		((Control)Label_Crew).Name = "Label_Crew";
		((Control)Label_Crew).Padding = new Padding(2);
		((Control)Label_Crew).Size = new Size(59, 17);
		((Control)Label_Crew).TabIndex = 2;
		((Label)Label_Crew).Text = "Crew :  38";
		TB_ChalkID.AutoCompleteCustomSource = null;
		TB_ChalkID.AutoCompleteMode = (AutoCompleteMode)0;
		TB_ChalkID.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_ChalkID).BackColor = Color.Transparent;
		((Control)TB_ChalkID).ForeColor = Color.FromArgb(189, 189, 189);
		TB_ChalkID.Image = null;
		TB_ChalkID.Lines = null;
		((Control)TB_ChalkID).Location = new Point(59, 18);
		TB_ChalkID.MaxLength = 32767;
		TB_ChalkID.Multiline = false;
		((Control)TB_ChalkID).Name = "TB_ChalkID";
		TB_ChalkID.ReadOnly = false;
		TB_ChalkID.ScrollBars = (ScrollBars)0;
		TB_ChalkID.SelectionStart = 0;
		((Control)TB_ChalkID).Size = new Size(79, 24);
		((Control)TB_ChalkID).TabIndex = 5;
		TB_ChalkID.Text = "0001";
		TB_ChalkID.TextAlign = (HorizontalAlignment)0;
		TB_ChalkID.UseSystemPasswordChar = false;
		TB_ChalkID.WatermarkText = "";
		DarkLabel5.AutoSize = true;
		((Control)DarkLabel5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel5).Location = new Point(6, 22);
		((Control)DarkLabel5).Name = "DarkLabel5";
		((Control)DarkLabel5).Size = new Size(47, 13);
		((Control)DarkLabel5).TabIndex = 6;
		((Label)DarkLabel5).Text = "Serial ID";
		((Control)Warning_NoMothership).Anchor = (AnchorStyles)9;
		Warning_NoMothership.AutoSize = true;
		((Control)Warning_NoMothership).Font = new Font("Microsoft Sans Serif", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Warning_NoMothership).ForeColor = Color.FromArgb(255, 128, 128);
		((Control)Warning_NoMothership).Location = new Point(503, 12);
		((Control)Warning_NoMothership).Name = "Warning_NoMothership";
		((Control)Warning_NoMothership).Size = new Size(208, 15);
		((Control)Warning_NoMothership).TabIndex = 17;
		((Label)Warning_NoMothership).Text = "No available mothership with cargo  !";
		((Control)DarkUIButton5).Anchor = (AnchorStyles)9;
		((ButtonBase)DarkUIButton5).BackColor = Color.Transparent;
		((Button)DarkUIButton5).DialogResult = (DialogResult)0;
		((Control)DarkUIButton5).ForeColor = SystemColors.Control;
		((Control)DarkUIButton5).Location = new Point(223, 6);
		((Control)DarkUIButton5).Name = "DarkUIButton5";
		DarkUIButton5.RoundRadius = 0;
		((Control)DarkUIButton5).Size = new Size(132, 23);
		((Control)DarkUIButton5).TabIndex = 16;
		DarkUIButton5.Text = "Import from Spreadsheet";
		((Control)DarkUIButton5).Visible = false;
		((Control)DarkUIButton4).Anchor = (AnchorStyles)9;
		((ButtonBase)DarkUIButton4).BackColor = Color.Transparent;
		((Button)DarkUIButton4).DialogResult = (DialogResult)0;
		((Control)DarkUIButton4).ForeColor = SystemColors.Control;
		((Control)DarkUIButton4).Location = new Point(361, 6);
		((Control)DarkUIButton4).Name = "DarkUIButton4";
		DarkUIButton4.RoundRadius = 0;
		((Control)DarkUIButton4).Size = new Size(132, 23);
		((Control)DarkUIButton4).TabIndex = 15;
		DarkUIButton4.Text = "Export to Spreadsheet";
		((Control)DarkUIButton4).Visible = false;
		((ComboBox)Combo_MothershipHost).BackColor = Color.Transparent;
		((ComboBox)Combo_MothershipHost).DrawMode = (DrawMode)1;
		((ComboBox)Combo_MothershipHost).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_MothershipHost).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_MothershipHost).FormattingEnabled = true;
		((ComboBox)Combo_MothershipHost).Items.AddRange(new object[1] { "Wasp 1" });
		((Control)Combo_MothershipHost).Location = new Point(50, 8);
		((Control)Combo_MothershipHost).Name = "Combo_MothershipHost";
		((Control)Combo_MothershipHost).Size = new Size(167, 21);
		((Control)Combo_MothershipHost).TabIndex = 1;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 63, 65);
		((Form)this).ClientSize = new Size(726, 440);
		((Control)this).Controls.Add((Control)(object)Warning_NoMothership);
		((Control)this).Controls.Add((Control)(object)DarkUIButton5);
		((Control)this).Controls.Add((Control)(object)DarkUIButton4);
		((Control)this).Controls.Add((Control)(object)DarkLabel4);
		((Control)this).Controls.Add((Control)(object)Combo_MothershipHost);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox3);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox2);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox1);
		((Form)this).MinimumSize = new Size(742, 479);
		((Control)this).Name = "UnitSerialEditor";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Unit Serial Editor";
		((Control)DarkGroupBox3).ResumeLayout(false);
		((Control)DarkGroupBox3).PerformLayout();
		((ISupportInitialize)DGV_Assets).EndInit();
		((Control)DarkGroupBox2).ResumeLayout(false);
		((Control)DarkGroupBox1).ResumeLayout(false);
		((Control)DarkGroupBox1).PerformLayout();
		((Control)DarkGroupBox5).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((Control)FlowLayoutPanel1).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void method_2(object sender, EventArgs e)
	{
		if (LV_Serials.SelectedItems.Count >= 1)
		{
			method_3((Chalk)LV_Serials.SelectedItems.ElementAt(0).Tag);
		}
	}

	private void method_3(Chalk chalk_0)
	{
		if (!Information.IsNothing((object)chalk_0))
		{
			CurrentlySelectedChalk = chalk_0;
			method_4();
		}
	}

	private void method_4()
	{
		CargoGrouped.Clear();
		CargoGroupedAssignedToChalk.Clear();
		CargoChalkAssigned.Clear();
		if (CurrentlySelectedChalk != null)
		{
			TB_ChalkID.Text = CurrentlySelectedChalk.ID.ToString();
			((Label)Label_LargestCargo).Text = "Largest Cargo Type : " + Enum.GetName(typeof(CargoType), (int)CurrentlySelectedChalk.GetLargestCargo());
			((Label)Label_Weight).Text = "Weight : " + CurrentlySelectedChalk.GetMass() + " Tons";
			((Label)Label_Area).Text = "Area : " + CurrentlySelectedChalk.GetArea() + " m2";
			((Label)Label_Crew).Text = "Personnel Capacity : " + CurrentlySelectedChalk.GetCrew() + " PAX";
		}
		else
		{
			TB_ChalkID.Text = "";
			((Label)Label_LargestCargo).Text = "";
			((Label)Label_Weight).Text = "";
			((Label)Label_Area).Text = "";
			((Label)Label_Crew).Text = "";
		}
		method_5();
		DGV_Assets.Rows.Clear();
		if (CurrentlySelectedMothership == null || CurrentlySelectedChalk == null)
		{
			return;
		}
		CargoGrouped = Cargo.GenerateCargoManifest(CurrentlySelectedMothership, IncludeSelf: false, GroupActiveUnits: true);
		foreach (Chalk chalk in Client.CurrentSide.Chalks)
		{
			if (chalk.AssociatedMothership == null || Operators.CompareString(chalk.AssociatedMothership.ObjectID, CurrentlySelectedMothership.ObjectID, true) != 0)
			{
				continue;
			}
			foreach (KeyValuePair<Cargo, int> item in chalk.Cargo)
			{
				CargoChalkAssigned.Add(item.Key.ObjectID, chalk);
				CargoManifestItem.Add(item.Key, CargoGroupedAssignedToChalk, GroupActiveUnits: true);
			}
		}
		foreach (CargoManifestItem item2 in CargoGrouped)
		{
			if (item2.quantity <= 0)
			{
				continue;
			}
			int num = 0;
			int num2 = 0;
			foreach (KeyValuePair<Cargo, int> item3 in CurrentlySelectedChalk.Cargo)
			{
				Cargo key = item3.Key;
				if (item2.IsMatch(key))
				{
					num2++;
				}
			}
			CargoManifestItem cargoManifestItem = CargoManifestItem.FindMatch(item2, CargoGroupedAssignedToChalk);
			if (cargoManifestItem != null)
			{
				num = cargoManifestItem.quantity;
			}
			Cargo cargo = null;
			Cargo[] onboardCargo = CurrentlySelectedMothership.OnboardCargo;
			foreach (Cargo cargo2 in onboardCargo)
			{
				if (item2.IsMatch(cargo2))
				{
					cargo = cargo2;
					break;
				}
			}
			if (cargo == null)
			{
				AddRowMainDGV(num2.ToString(), "[" + num + "/" + item2.quantity + "]", item2.NameNoQuantity, "ERROR", "ERROR", "ERROR", null);
			}
			else
			{
				AddRowMainDGV(num2.ToString(), "[" + num + "/" + item2.quantity + "]", item2.NameNoQuantity, cargo.RequiredMass.ToString(), cargo.RequiredArea.ToString(), cargo.RequiredCrewSpace.ToString(), cargo);
			}
		}
	}

	private void method_5()
	{
		LV_PossibleTransport.Items.Clear();
		if (CurrentlySelectedMothership == null || CurrentlySelectedChalk == null)
		{
			return;
		}
		foreach (Aircraft item in CurrentlySelectedMothership.AirOps.EmbarkedAircraft_ReadOnly)
		{
			if (((ICargoHost)item).GetCargo_Type() != CargoType.NoCargo)
			{
				float RunRequired = 0f;
				string text = CurrentlySelectedChalk.IsTransportEligible(item, ref RunRequired);
				DarkListItem darkListItem = new DarkListItem();
				darkListItem.Text += "(Airborne) ";
				darkListItem.Text += item.Name;
				if (Operators.CompareString(text, "OK", true) != 0)
				{
					DarkListItem darkListItem2;
					(darkListItem2 = darkListItem).Text = darkListItem2.Text + " ERROR : " + text;
					darkListItem.TextColor = Color.FromArgb(255, 255, 128, 128);
				}
				else
				{
					DarkListItem darkListItem2;
					(darkListItem2 = darkListItem).Text = darkListItem2.Text + " [" + (int)Math.Round((double)RunRequired * 100.0) + " %]";
					darkListItem.TextColor = Color.FromArgb(255, 0, 255, 0);
				}
				LV_PossibleTransport.Items.Add(darkListItem);
			}
		}
		foreach (ActiveUnit item2 in CurrentlySelectedMothership.DockingOps.EmbarkedBoats_ReadOnly)
		{
			if (((ICargoHost)item2).GetCargo_Type() != CargoType.NoCargo)
			{
				float RunRequired = 0f;
				string text = CurrentlySelectedChalk.IsTransportEligible(item2, ref RunRequired);
				DarkListItem darkListItem3 = new DarkListItem();
				darkListItem3.Text += "(Amphibious) ";
				darkListItem3.Text += item2.Name;
				if (Operators.CompareString(text, "OK", true) == 0)
				{
					DarkListItem darkListItem2;
					(darkListItem2 = darkListItem3).Text = darkListItem2.Text + " [" + (int)Math.Round((double)RunRequired * 100.0) + " %]";
					darkListItem3.TextColor = Color.FromArgb(255, 0, 255, 0);
				}
				else
				{
					DarkListItem darkListItem2;
					(darkListItem2 = darkListItem3).Text = darkListItem2.Text + " ERROR : " + text;
					darkListItem3.TextColor = Color.FromArgb(255, 255, 128, 128);
				}
				LV_PossibleTransport.Items.Add(darkListItem3);
			}
		}
	}

	private void method_6()
	{
		new List<ActiveUnit>();
		((ComboBox)Combo_MothershipHost).BeginUpdate();
		((ComboBox)Combo_MothershipHost).Items.Clear();
		((ListControl)Combo_MothershipHost).DisplayMember = "Name";
		((ListControl)Combo_MothershipHost).ValueMember = "Mothership";
		foreach (ActiveUnit unit in Client.CurrentSide.Units)
		{
			if (unit.IsShip && unit.HasCargo && Information.IsNothing((object)unit.DockingOps.CurrentHostUnit))
			{
				((ComboBox)Combo_MothershipHost).Items.Add((object)new MothershipItem(unit));
			}
		}
		if (((ComboBox)Combo_MothershipHost).Items.Count > 0)
		{
			((ComboBox)Combo_MothershipHost).SelectedIndex = 0;
			((Label)Warning_NoMothership).Text = "";
		}
		else
		{
			((Label)Warning_NoMothership).Text = "No available mothership with cargo  !";
		}
		((ComboBox)Combo_MothershipHost).EndUpdate();
	}

	private void method_7()
	{
		LV_Serials.Items.Clear();
		foreach (Chalk chalk in Client.CurrentSide.Chalks)
		{
			if (chalk.AssociatedMothership != null && Operators.CompareString(chalk.AssociatedMothership.ObjectID, CurrentlySelectedMothership.ObjectID, true) == 0)
			{
				DarkListItem darkListItem = new DarkListItem();
				darkListItem.Text = chalk.ID.ToString();
				darkListItem.Tag = chalk;
				LV_Serials.Items.Add(darkListItem);
			}
		}
	}

	private void hpiHqusYdvL(object sender, EventArgs e)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		method_4();
		DGV_Assets.AutoGenerateColumns = false;
		DGV_Assets.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)16;
		DataGridViewButtonColumn val = new DataGridViewButtonColumn();
		((DataGridViewColumn)val).Name = "QTY Allocated";
		((DataGridViewCell)((DataGridViewColumn)val).HeaderCell).Style.Alignment = (DataGridViewContentAlignment)32;
		DataGridViewButtonColumn val2 = new DataGridViewButtonColumn();
		((DataGridViewColumn)val2).Name = "QTY (Mothership)";
		((DataGridViewCell)((DataGridViewColumn)val2).HeaderCell).Style.Alignment = (DataGridViewContentAlignment)32;
		DataGridViewTextBoxColumn val3 = new DataGridViewTextBoxColumn();
		((DataGridViewColumn)val3).Name = "Unit";
		((DataGridViewColumn)val3).ReadOnly = true;
		((DataGridViewColumn)val3).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		((DataGridViewColumn)val3).Width = 200;
		((DataGridViewCell)((DataGridViewColumn)val3).HeaderCell).Style.Alignment = (DataGridViewContentAlignment)32;
		DataGridViewTextBoxColumn val4 = new DataGridViewTextBoxColumn();
		((DataGridViewColumn)val4).Name = "Weight";
		((DataGridViewColumn)val4).ReadOnly = true;
		((DataGridViewCell)((DataGridViewColumn)val4).HeaderCell).Style.Alignment = (DataGridViewContentAlignment)32;
		DataGridViewTextBoxColumn val5 = new DataGridViewTextBoxColumn();
		((DataGridViewColumn)val5).Name = "Space";
		((DataGridViewColumn)val5).ReadOnly = true;
		((DataGridViewCell)((DataGridViewColumn)val5).HeaderCell).Style.Alignment = (DataGridViewContentAlignment)32;
		DataGridViewTextBoxColumn val6 = new DataGridViewTextBoxColumn();
		((DataGridViewColumn)val6).Name = "PAX";
		((DataGridViewColumn)val6).ReadOnly = true;
		((DataGridViewCell)((DataGridViewColumn)val6).HeaderCell).Style.Alignment = (DataGridViewContentAlignment)32;
		DGV_Assets.Columns.Add((DataGridViewColumn)(object)val);
		DGV_Assets.Columns.Add((DataGridViewColumn)(object)val2);
		DGV_Assets.Columns.Add((DataGridViewColumn)(object)val3);
		DGV_Assets.Columns.Add((DataGridViewColumn)(object)val4);
		DGV_Assets.Columns.Add((DataGridViewColumn)(object)val5);
		DGV_Assets.Columns.Add((DataGridViewColumn)(object)val6);
		method_6();
		method_7();
	}

	public void AddRowMainDGV(string Amount, string Amount2, string Unit, string Weight, string Space, string Crew, Cargo _Cargo)
	{
		DGV_Assets.Rows.Add();
		DGV_Assets.Rows[DGV_Assets.Rows.Count - 1].Cells["QTY Allocated"].Value = Amount;
		DGV_Assets.Rows[DGV_Assets.Rows.Count - 1].Cells["QTY Allocated"].Tag = _Cargo;
		DGV_Assets.Rows[DGV_Assets.Rows.Count - 1].Cells["QTY (Mothership)"].Value = Amount2;
		DGV_Assets.Rows[DGV_Assets.Rows.Count - 1].Cells["Unit"].Value = Unit;
		DGV_Assets.Rows[DGV_Assets.Rows.Count - 1].Cells["Weight"].Value = Weight;
		DGV_Assets.Rows[DGV_Assets.Rows.Count - 1].Cells["Space"].Value = Space;
		DGV_Assets.Rows[DGV_Assets.Rows.Count - 1].Cells["PAX"].Value = Crew;
	}

	private void method_8(object sender, EventArgs e)
	{
		if (CurrentlySelectedChalk == null)
		{
			return;
		}
		foreach (Chalk chalk in Client.CurrentSide.Chalks)
		{
			if (Operators.CompareString(TB_ChalkID.Text, chalk.ID.ToString(), true) == 0)
			{
				return;
			}
		}
		int result = CurrentlySelectedChalk.ID;
		if (int.TryParse(TB_ChalkID.Text, out result))
		{
			CurrentlySelectedChalk.ID = result;
		}
		else
		{
			TB_ChalkID.Text = result.ToString();
		}
		method_7();
	}

	private void method_9(object sender, EventArgs e)
	{
		if (CurrentlySelectedMothership != null)
		{
			Chalk.AddNewChalk(Client.CurrentSide, CurrentlySelectedMothership);
			method_7();
			if (LV_Serials.Items.Count > 0)
			{
				LV_Serials.SelectItem(LV_Serials.Items.Count - 1);
			}
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)CurrentlySelectedChalk))
		{
			Chalk.RemoveChalk(Client.CurrentSide, CurrentlySelectedChalk);
			method_7();
			if (LV_Serials.Items.Count > 0)
			{
				LV_Serials.SelectItem(LV_Serials.Items.Count - 1);
			}
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(((ComboBox)Combo_MothershipHost).SelectedItem)))
		{
			CurrentlySelectedMothership = ((MothershipItem)((ComboBox)Combo_MothershipHost).SelectedItem).Mothership;
			method_7();
			if (LV_Serials.Items.Count > 0)
			{
				LV_Serials.SelectItem(LV_Serials.Items.Count - 1);
			}
			method_4();
		}
	}

	private void method_12(Cargo cargo_0, int int_0)
	{
		if (int_0 == 0)
		{
			return;
		}
		Cargo[] array = CurrentlySelectedMothership.OnboardCargo;
		if (int_0 < 0)
		{
			array = CurrentlySelectedChalk.Cargo.Keys.ToArray();
		}
		int num = Math.Abs(int_0) - 1;
		for (int i = 0; i <= num; i++)
		{
			Cargo[] array2 = array;
			foreach (Cargo cargo in array2)
			{
				if (int_0 > 0)
				{
					if (cargo.IsMatch(cargo_0) && !CargoChalkAssigned.ContainsKey(cargo.ObjectID) && method_14(cargo))
					{
						break;
					}
				}
				else if (cargo.IsMatch(cargo_0) && method_15(cargo))
				{
					break;
				}
			}
		}
		method_4();
	}

	private void method_13(object sender, DataGridViewCellEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		DataGridView val = (DataGridView)sender;
		if (e.RowIndex < 0)
		{
			return;
		}
		int num = 1;
		if ((int)Control.ModifierKeys == 131072)
		{
			num = 5;
		}
		if ((int)Control.ModifierKeys == 65536)
		{
			num = 10;
		}
		if (!(val.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0)
		{
			return;
		}
		if (Operators.CompareString(val.Columns[e.ColumnIndex].Name, "QTY Allocated", true) != 0)
		{
			if (Operators.CompareString(val.Columns[e.ColumnIndex].Name, "QTY (Mothership)", true) == 0)
			{
				method_12((Cargo)DGV_Assets.Rows[e.RowIndex].Cells["QTY Allocated"].Tag, -num);
			}
		}
		else
		{
			method_12((Cargo)DGV_Assets.Rows[e.RowIndex].Cells["QTY Allocated"].Tag, num);
		}
	}

	private bool method_14(Cargo cargo_0)
	{
		if (CurrentlySelectedChalk.Cargo.ContainsKey(cargo_0))
		{
			return false;
		}
		CurrentlySelectedChalk.Cargo.Add(cargo_0, 0);
		return true;
	}

	private bool method_15(Cargo cargo_0)
	{
		if (!CurrentlySelectedChalk.Cargo.ContainsKey(cargo_0))
		{
			return false;
		}
		CurrentlySelectedChalk.Cargo.Remove(cargo_0);
		return true;
	}

	static UnitSerialEditor()
	{
		Class72.smethod_20();
	}
}
