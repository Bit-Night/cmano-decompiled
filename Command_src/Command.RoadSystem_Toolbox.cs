using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class RoadSystem_Toolbox : Form, IObserver_UI
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("SimplifySegment_Ratio")]
	[CompilerGenerated]
	private DarkUIButton _SimplifySegment_Ratio;

	[AccessedThroughProperty("ComboRoadType")]
	[CompilerGenerated]
	private DarkUIComboBox _ComboRoadType;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Snapping")]
	private DarkUICheckBox _CB_Snapping;

	[AccessedThroughProperty("Button_ReplaceType")]
	[CompilerGenerated]
	private DarkUIButton _Button_ReplaceType;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonRoadEditro")]
	private Button _ButtonRoadEditro;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonUnitToNetwork")]
	private DarkUIButton _ButtonUnitToNetwork;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonUnitPF")]
	private DarkUIButton _ButtonUnitPF;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkUIButton1")]
	private DarkUIButton _DarkUIButton1;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkUIButton2")]
	private DarkUIButton _DarkUIButton2;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonSetGoalPF")]
	private DarkUIButton _ButtonSetGoalPF;

	[AccessedThroughProperty("ButtonPFToGoal")]
	[CompilerGenerated]
	private DarkUIButton _ButtonPFToGoal;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkUIButton3")]
	private DarkUIButton _DarkUIButton3;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonLoadnetworkFromFile")]
	private DarkUIButton _ButtonLoadnetworkFromFile;

	internal virtual DarkUIButton SimplifySegment_Ratio
	{
		[CompilerGenerated]
		get
		{
			return _SimplifySegment_Ratio;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _SimplifySegment_Ratio;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_SimplifySegment_Ratio = value;
			darkUIButton = _SimplifySegment_Ratio;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1 { get; set; }

	[field: AccessedThroughProperty("Panel2")]
	internal virtual Panel Panel2 { get; set; }

	internal virtual DarkUIComboBox ComboRoadType
	{
		[CompilerGenerated]
		get
		{
			return _ComboRoadType;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			EventHandler eventHandler2 = method_5;
			DarkUIComboBox darkUIComboBox = _ComboRoadType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler2;
			}
			_ComboRoadType = value;
			darkUIComboBox = _ComboRoadType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	[field: AccessedThroughProperty("Panel1")]
	internal virtual Panel Panel1 { get; set; }

	[field: AccessedThroughProperty("LabelSnapping")]
	internal virtual DarkLabel LabelSnapping { get; set; }

	internal virtual DarkUICheckBox CB_Snapping
	{
		[CompilerGenerated]
		get
		{
			return _CB_Snapping;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUICheckBox darkUICheckBox = _CB_Snapping;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged -= eventHandler;
			}
			_CB_Snapping = value;
			darkUICheckBox = _CB_Snapping;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ReplaceType
	{
		[CompilerGenerated]
		get
		{
			return _Button_ReplaceType;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUIButton darkUIButton = _Button_ReplaceType;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ReplaceType = value;
			darkUIButton = _Button_ReplaceType;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("NodeInfos")]
	internal virtual DarkListView NodeInfos { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox1")]
	internal virtual DarkGroupBox DarkGroupBox1 { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox2")]
	internal virtual DarkGroupBox DarkGroupBox2 { get; set; }

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3 { get; set; }

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	internal virtual Button ButtonRoadEditro
	{
		[CompilerGenerated]
		get
		{
			return _ButtonRoadEditro;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			Button val = _ButtonRoadEditro;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_ButtonRoadEditro = value;
			val = _ButtonRoadEditro;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonUnitToNetwork
	{
		[CompilerGenerated]
		get
		{
			return _ButtonUnitToNetwork;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkUIButton darkUIButton = _ButtonUnitToNetwork;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonUnitToNetwork = value;
			darkUIButton = _ButtonUnitToNetwork;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonUnitPF
	{
		[CompilerGenerated]
		get
		{
			return _ButtonUnitPF;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkUIButton darkUIButton = _ButtonUnitPF;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonUnitPF = value;
			darkUIButton = _ButtonUnitPF;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel2")]
	internal virtual FlowLayoutPanel FlowLayoutPanel2 { get; set; }

	internal virtual DarkUIButton DarkUIButton1
	{
		[CompilerGenerated]
		get
		{
			return _DarkUIButton1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkUIButton darkUIButton = _DarkUIButton1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_DarkUIButton1 = value;
			darkUIButton = _DarkUIButton1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton DarkUIButton2
	{
		[CompilerGenerated]
		get
		{
			return _DarkUIButton2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			DarkUIButton darkUIButton = _DarkUIButton2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_DarkUIButton2 = value;
			darkUIButton = _DarkUIButton2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonSetGoalPF
	{
		[CompilerGenerated]
		get
		{
			return _ButtonSetGoalPF;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkUIButton darkUIButton = _ButtonSetGoalPF;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonSetGoalPF = value;
			darkUIButton = _ButtonSetGoalPF;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LabelGoalPF")]
	internal virtual DarkLabel LabelGoalPF { get; set; }

	internal virtual DarkUIButton ButtonPFToGoal
	{
		[CompilerGenerated]
		get
		{
			return _ButtonPFToGoal;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUIButton darkUIButton = _ButtonPFToGoal;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonPFToGoal = value;
			darkUIButton = _ButtonPFToGoal;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox3")]
	internal virtual DarkGroupBox DarkGroupBox3 { get; set; }

	[field: AccessedThroughProperty("LV_SelectedUnitPF")]
	internal virtual DarkListView LV_SelectedUnitPF { get; set; }

	internal virtual DarkUIButton DarkUIButton3
	{
		[CompilerGenerated]
		get
		{
			return _DarkUIButton3;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			DarkUIButton darkUIButton = _DarkUIButton3;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_DarkUIButton3 = value;
			darkUIButton = _DarkUIButton3;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonLoadnetworkFromFile
	{
		[CompilerGenerated]
		get
		{
			return _ButtonLoadnetworkFromFile;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkUIButton darkUIButton = _ButtonLoadnetworkFromFile;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonLoadnetworkFromFile = value;
			darkUIButton = _ButtonLoadnetworkFromFile;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	public bool IsDisposed => ((Control)this).IsDisposed;

	public RoadSystem_Toolbox()
	{
		((Form)this).Load += RoadSystem_Toolbox_Load;
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0684: Expected O, but got Unknown
		//IL_0721: Unknown result type (might be due to invalid IL or missing references)
		//IL_0938: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_104b: Unknown result type (might be due to invalid IL or missing references)
		//IL_116c: Unknown result type (might be due to invalid IL or missing references)
		FlowLayoutPanel1 = new FlowLayoutPanel();
		Panel2 = new Panel();
		DarkGroupBox2 = new DarkGroupBox();
		ButtonRoadEditro = new Button();
		DarkLabel4 = new DarkLabel();
		DarkLabel3 = new DarkLabel();
		DarkLabel2 = new DarkLabel();
		DarkLabel1 = new DarkLabel();
		ComboRoadType = new DarkUIComboBox();
		Button_ReplaceType = new DarkUIButton();
		Panel1 = new Panel();
		LabelSnapping = new DarkLabel();
		CB_Snapping = new DarkUICheckBox();
		SimplifySegment_Ratio = new DarkUIButton();
		DarkGroupBox3 = new DarkGroupBox();
		LV_SelectedUnitPF = new DarkListView();
		DarkUIButton3 = new DarkUIButton();
		NodeInfos = new DarkListView();
		DarkGroupBox1 = new DarkGroupBox();
		FlowLayoutPanel2 = new FlowLayoutPanel();
		ButtonPFToGoal = new DarkUIButton();
		ButtonUnitToNetwork = new DarkUIButton();
		ButtonUnitPF = new DarkUIButton();
		DarkUIButton1 = new DarkUIButton();
		DarkUIButton2 = new DarkUIButton();
		ButtonSetGoalPF = new DarkUIButton();
		LabelGoalPF = new DarkLabel();
		ButtonLoadnetworkFromFile = new DarkUIButton();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((Control)Panel2).SuspendLayout();
		((Control)DarkGroupBox2).SuspendLayout();
		((Control)Panel1).SuspendLayout();
		((Control)DarkGroupBox3).SuspendLayout();
		((Control)DarkGroupBox1).SuspendLayout();
		((Control)FlowLayoutPanel2).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Panel2);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Button_ReplaceType);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Panel1);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)SimplifySegment_Ratio);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)DarkGroupBox3);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)DarkUIButton3);
		((Control)FlowLayoutPanel1).Location = new Point(12, 12);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(211, 418);
		((Control)FlowLayoutPanel1).TabIndex = 3;
		((Control)Panel2).Controls.Add((Control)(object)DarkGroupBox2);
		((Control)Panel2).Location = new Point(3, 3);
		((Control)Panel2).Name = "Panel2";
		((Control)Panel2).Size = new Size(200, 126);
		((Control)Panel2).TabIndex = 5;
		((Control)DarkGroupBox2).Controls.Add((Control)(object)ButtonRoadEditro);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel4);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel3);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel2);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel1);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)ComboRoadType);
		((Control)DarkGroupBox2).Dock = (DockStyle)5;
		((Control)DarkGroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox2).Location = new Point(0, 0);
		((Control)DarkGroupBox2).Name = "DarkGroupBox2";
		((Control)DarkGroupBox2).Size = new Size(200, 126);
		((Control)DarkGroupBox2).TabIndex = 9;
		((GroupBox)DarkGroupBox2).TabStop = false;
		((GroupBox)DarkGroupBox2).Text = "Road Editor";
		((Control)ButtonRoadEditro).Location = new Point(6, 19);
		((Control)ButtonRoadEditro).Name = "ButtonRoadEditro";
		((Control)ButtonRoadEditro).Size = new Size(188, 23);
		((Control)ButtonRoadEditro).TabIndex = 13;
		((ButtonBase)ButtonRoadEditro).Text = "Button1";
		((ButtonBase)ButtonRoadEditro).UseVisualStyleBackColor = true;
		DarkLabel4.AutoSize = true;
		((Control)DarkLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel4).Location = new Point(7, 105);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(145, 13);
		((Control)DarkLabel4).TabIndex = 12;
		((Label)DarkLabel4).Text = "ESC (x2) : Disable road editor";
		DarkLabel3.AutoSize = true;
		((Control)DarkLabel3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel3).Location = new Point(7, 89);
		((Control)DarkLabel3).Name = "DarkLabel3";
		((Control)DarkLabel3).Size = new Size(125, 13);
		((Control)DarkLabel3).TabIndex = 11;
		((Label)DarkLabel3).Text = "ESC : Clear starting node";
		DarkLabel2.AutoSize = true;
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(7, 72);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(118, 13);
		((Control)DarkLabel2).TabIndex = 10;
		((Label)DarkLabel2).Text = "Shift : continuous mode";
		((Control)DarkLabel1).Anchor = (AnchorStyles)7;
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(7, 52);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(60, 13);
		((Control)DarkLabel1).TabIndex = 2;
		((Label)DarkLabel1).Text = "Road Type";
		((Control)ComboRoadType).Anchor = (AnchorStyles)11;
		((ComboBox)ComboRoadType).BackColor = Color.Transparent;
		((ComboBox)ComboRoadType).DrawMode = (DrawMode)1;
		((ComboBox)ComboRoadType).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboRoadType).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboRoadType).FormattingEnabled = true;
		((Control)ComboRoadType).Location = new Point(73, 48);
		((Control)ComboRoadType).Name = "ComboRoadType";
		((Control)ComboRoadType).Size = new Size(121, 21);
		((Control)ComboRoadType).TabIndex = 1;
		((ButtonBase)Button_ReplaceType).BackColor = Color.Transparent;
		((Control)Button_ReplaceType).ForeColor = SystemColors.Control;
		((Control)Button_ReplaceType).Location = new Point(3, 135);
		((Control)Button_ReplaceType).Name = "Button_ReplaceType";
		((Control)Button_ReplaceType).Padding = new Padding(5);
		Button_ReplaceType.RoundRadius = 0;
		((Control)Button_ReplaceType).Size = new Size(197, 23);
		((Control)Button_ReplaceType).TabIndex = 7;
		Button_ReplaceType.Text = "Replace Selection";
		((Control)Panel1).Controls.Add((Control)(object)LabelSnapping);
		((Control)Panel1).Controls.Add((Control)(object)CB_Snapping);
		((Control)Panel1).Location = new Point(3, 164);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(200, 31);
		((Control)Panel1).TabIndex = 6;
		((Control)LabelSnapping).Anchor = (AnchorStyles)7;
		LabelSnapping.AutoSize = true;
		((Control)LabelSnapping).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelSnapping).Location = new Point(3, 9);
		((Control)LabelSnapping).Name = "LabelSnapping";
		((Control)LabelSnapping).Size = new Size(52, 13);
		((Control)LabelSnapping).TabIndex = 2;
		((Label)LabelSnapping).Text = "Snapping";
		((ButtonBase)CB_Snapping).BackColor = Color.Transparent;
		((Control)CB_Snapping).Cursor = Cursors.Hand;
		((Control)CB_Snapping).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)CB_Snapping).Location = new Point(76, 7);
		((Control)CB_Snapping).Name = "CB_Snapping";
		((Control)CB_Snapping).Size = new Size(75, 18);
		((Control)CB_Snapping).TabIndex = 6;
		((ButtonBase)SimplifySegment_Ratio).BackColor = Color.Transparent;
		((Control)SimplifySegment_Ratio).ForeColor = SystemColors.Control;
		((Control)SimplifySegment_Ratio).Location = new Point(3, 201);
		((Control)SimplifySegment_Ratio).Name = "SimplifySegment_Ratio";
		((Control)SimplifySegment_Ratio).Padding = new Padding(5);
		SimplifySegment_Ratio.RoundRadius = 0;
		((Control)SimplifySegment_Ratio).Size = new Size(200, 23);
		((Control)SimplifySegment_Ratio).TabIndex = 0;
		SimplifySegment_Ratio.Text = "Simplify Selection(1:2)";
		((Control)DarkGroupBox3).Controls.Add((Control)(object)LV_SelectedUnitPF);
		((Control)DarkGroupBox3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox3).Location = new Point(3, 230);
		((Control)DarkGroupBox3).Name = "DarkGroupBox3";
		((Control)DarkGroupBox3).Size = new Size(200, 150);
		((Control)DarkGroupBox3).TabIndex = 8;
		((GroupBox)DarkGroupBox3).TabStop = false;
		((GroupBox)DarkGroupBox3).Text = "SelectedUnit PF";
		((Control)LV_SelectedUnitPF).Dock = (DockStyle)5;
		((Control)LV_SelectedUnitPF).Location = new Point(3, 16);
		((Control)LV_SelectedUnitPF).Name = "LV_SelectedUnitPF";
		LV_SelectedUnitPF.RelatedInfos = null;
		((Control)LV_SelectedUnitPF).Size = new Size(194, 131);
		((Control)LV_SelectedUnitPF).TabIndex = 4;
		((ButtonBase)DarkUIButton3).BackColor = Color.Transparent;
		((Control)DarkUIButton3).ForeColor = SystemColors.Control;
		((Control)DarkUIButton3).Location = new Point(3, 386);
		((Control)DarkUIButton3).Name = "DarkUIButton3";
		((Control)DarkUIButton3).Padding = new Padding(5);
		DarkUIButton3.RoundRadius = 0;
		((Control)DarkUIButton3).Size = new Size(200, 18);
		((Control)DarkUIButton3).TabIndex = 13;
		DarkUIButton3.Text = "Refresh";
		((Control)NodeInfos).Dock = (DockStyle)5;
		((Control)NodeInfos).Location = new Point(3, 16);
		((Control)NodeInfos).Name = "NodeInfos";
		NodeInfos.RelatedInfos = null;
		((Control)NodeInfos).Size = new Size(208, 131);
		((Control)NodeInfos).TabIndex = 4;
		((Control)DarkGroupBox1).Controls.Add((Control)(object)NodeInfos);
		((Control)DarkGroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox1).Location = new Point(229, 12);
		((Control)DarkGroupBox1).Name = "DarkGroupBox1";
		((Control)DarkGroupBox1).Size = new Size(214, 150);
		((Control)DarkGroupBox1).TabIndex = 5;
		((GroupBox)DarkGroupBox1).TabStop = false;
		((GroupBox)DarkGroupBox1).Text = "Selected Node";
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)ButtonLoadnetworkFromFile);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)ButtonPFToGoal);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)ButtonUnitToNetwork);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)ButtonUnitPF);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)DarkUIButton1);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)DarkUIButton2);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)ButtonSetGoalPF);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)LabelGoalPF);
		((Control)FlowLayoutPanel2).Location = new Point(229, 168);
		((Control)FlowLayoutPanel2).Name = "FlowLayoutPanel2";
		((Control)FlowLayoutPanel2).Size = new Size(211, 262);
		((Control)FlowLayoutPanel2).TabIndex = 6;
		((ButtonBase)ButtonPFToGoal).BackColor = Color.Transparent;
		((Control)ButtonPFToGoal).ForeColor = SystemColors.Control;
		((Control)ButtonPFToGoal).Location = new Point(3, 35);
		((Control)ButtonPFToGoal).Name = "ButtonPFToGoal";
		((Control)ButtonPFToGoal).Padding = new Padding(5);
		ButtonPFToGoal.RoundRadius = 0;
		((Control)ButtonPFToGoal).Size = new Size(200, 26);
		((Control)ButtonPFToGoal).TabIndex = 14;
		ButtonPFToGoal.Text = "PF to Goal PF";
		((ButtonBase)ButtonUnitToNetwork).BackColor = Color.Transparent;
		((Control)ButtonUnitToNetwork).ForeColor = SystemColors.Control;
		((Control)ButtonUnitToNetwork).Location = new Point(3, 67);
		((Control)ButtonUnitToNetwork).Name = "ButtonUnitToNetwork";
		((Control)ButtonUnitToNetwork).Padding = new Padding(5);
		ButtonUnitToNetwork.RoundRadius = 0;
		((Control)ButtonUnitToNetwork).Size = new Size(200, 38);
		((Control)ButtonUnitToNetwork).TabIndex = 8;
		ButtonUnitToNetwork.Text = "Attach selected units to closest network";
		((ButtonBase)ButtonUnitPF).BackColor = Color.Transparent;
		((Control)ButtonUnitPF).ForeColor = SystemColors.Control;
		((Control)ButtonUnitPF).Location = new Point(3, 111);
		((Control)ButtonUnitPF).Name = "ButtonUnitPF";
		((Control)ButtonUnitPF).Padding = new Padding(5);
		ButtonUnitPF.RoundRadius = 0;
		((Control)ButtonUnitPF).Size = new Size(200, 26);
		((Control)ButtonUnitPF).TabIndex = 9;
		ButtonUnitPF.Text = "PF Go to selected node";
		((ButtonBase)DarkUIButton1).BackColor = Color.Transparent;
		((Control)DarkUIButton1).ForeColor = SystemColors.Control;
		((Control)DarkUIButton1).Location = new Point(3, 143);
		((Control)DarkUIButton1).Name = "DarkUIButton1";
		((Control)DarkUIButton1).Padding = new Padding(5);
		DarkUIButton1.RoundRadius = 0;
		((Control)DarkUIButton1).Size = new Size(200, 26);
		((Control)DarkUIButton1).TabIndex = 10;
		DarkUIButton1.Text = "PF Floodfill From Selected";
		((ButtonBase)DarkUIButton2).BackColor = Color.Transparent;
		((Control)DarkUIButton2).ForeColor = SystemColors.Control;
		((Control)DarkUIButton2).Location = new Point(3, 175);
		((Control)DarkUIButton2).Name = "DarkUIButton2";
		((Control)DarkUIButton2).Padding = new Padding(5);
		DarkUIButton2.RoundRadius = 0;
		((Control)DarkUIButton2).Size = new Size(200, 26);
		((Control)DarkUIButton2).TabIndex = 11;
		DarkUIButton2.Text = "Clear PF Floodfill";
		((ButtonBase)ButtonSetGoalPF).BackColor = Color.Transparent;
		((Control)ButtonSetGoalPF).ForeColor = SystemColors.Control;
		((Control)ButtonSetGoalPF).Location = new Point(3, 207);
		((Control)ButtonSetGoalPF).Name = "ButtonSetGoalPF";
		((Control)ButtonSetGoalPF).Padding = new Padding(5);
		ButtonSetGoalPF.RoundRadius = 0;
		((Control)ButtonSetGoalPF).Size = new Size(200, 26);
		((Control)ButtonSetGoalPF).TabIndex = 12;
		ButtonSetGoalPF.Text = "Set Goal PF";
		((Control)LabelGoalPF).Anchor = (AnchorStyles)7;
		LabelGoalPF.AutoSize = true;
		((Control)LabelGoalPF).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelGoalPF).Location = new Point(3, 236);
		((Control)LabelGoalPF).Name = "LabelGoalPF";
		((Control)LabelGoalPF).Size = new Size(54, 13);
		((Control)LabelGoalPF).TabIndex = 13;
		((Label)LabelGoalPF).Text = "Goal PF : ";
		((ButtonBase)ButtonLoadnetworkFromFile).BackColor = Color.Transparent;
		((Control)ButtonLoadnetworkFromFile).ForeColor = SystemColors.Control;
		((Control)ButtonLoadnetworkFromFile).Location = new Point(3, 3);
		((Control)ButtonLoadnetworkFromFile).Name = "ButtonLoadnetworkFromFile";
		((Control)ButtonLoadnetworkFromFile).Padding = new Padding(5);
		ButtonLoadnetworkFromFile.RoundRadius = 0;
		((Control)ButtonLoadnetworkFromFile).Size = new Size(200, 26);
		((Control)ButtonLoadnetworkFromFile).TabIndex = 15;
		ButtonLoadnetworkFromFile.Text = "Import Network from file";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(65, 65, 65);
		((Form)this).ClientSize = new Size(455, 442);
		((Control)this).Controls.Add((Control)(object)FlowLayoutPanel2);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox1);
		((Control)this).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)this).Name = "RoadSystem_Toolbox";
		((Form)this).Text = "RoadSystem_Toolbox";
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((Control)Panel2).ResumeLayout(false);
		((Control)DarkGroupBox2).ResumeLayout(false);
		((Control)DarkGroupBox2).PerformLayout();
		((Control)Panel1).ResumeLayout(false);
		((Control)Panel1).PerformLayout();
		((Control)DarkGroupBox3).ResumeLayout(false);
		((Control)DarkGroupBox1).ResumeLayout(false);
		((Control)FlowLayoutPanel2).ResumeLayout(false);
		((Control)FlowLayoutPanel2).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	public void Refresh_FromEvent()
	{
		((Label)LabelGoalPF).Text = "Goal PF (NONE)";
		method_0();
		RefreshRoadEditor();
	}

	private void method_0()
	{
		NodeInfos.Items.Clear();
		RoadSystem.Node nodeCurrentlySnapped = RoadSystemEditor.NodeCurrentlySnapped;
		if (nodeCurrentlySnapped == null)
		{
			return;
		}
		NodeInfos.Items.Add(new DarkListItem("ID " + nodeCurrentlySnapped.ID));
		NodeInfos.Items.Add(new DarkListItem("Network " + nodeCurrentlySnapped.Network));
		NodeInfos.Items.Add(new DarkListItem("Longtitude " + nodeCurrentlySnapped.Coordinates.Longitude));
		NodeInfos.Items.Add(new DarkListItem("latitude " + nodeCurrentlySnapped.Coordinates.Latitude));
		foreach (RoadSystem.Segment connectedSegment in nodeCurrentlySnapped.ConnectedSegments)
		{
			NodeInfos.Items.Add(new DarkListItem("Connected to segment " + connectedSegment.Id));
		}
	}

	private void method_1()
	{
		LV_SelectedUnitPF.Items.Clear();
		if (Client.SelectedUnit == null || Client.SelectedUnit.RoadNetworkPath.Count <= 0)
		{
			return;
		}
		LV_SelectedUnitPF.Items.Add(new DarkListItem("Pathfinding for selected unit"));
		foreach (RoadSystem.Node item in Client.SelectedUnit.RoadNetworkPath)
		{
			if (Client.SelectedUnit.NodeA == item)
			{
				DarkListItem darkListItem = new DarkListItem(item.ID.ToString() ?? "");
				darkListItem.TextColor = Color.Orange;
				LV_SelectedUnitPF.Items.Add(darkListItem);
			}
			else if (Client.SelectedUnit.NodeB == item)
			{
				DarkListItem darkListItem2 = new DarkListItem(item.ID.ToString() ?? "");
				darkListItem2.TextColor = Color.IndianRed;
				LV_SelectedUnitPF.Items.Add(darkListItem2);
			}
			else
			{
				LV_SelectedUnitPF.Items.Add(new DarkListItem(item.ID.ToString() ?? ""));
			}
		}
	}

	private void RoadSystem_Toolbox_Load(object sender, EventArgs e)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		((Form)this).TopMost = true;
		foreach (object value in Enum.GetValues(typeof(RoadSystem.SegmentEnum)))
		{
			RoadSystem.SegmentEnum segmentEnum = (RoadSystem.SegmentEnum)Conversions.ToInteger(value);
			if (segmentEnum < RoadSystem.SegmentEnum.Any)
			{
				((ComboBox)ComboRoadType).Items.Add((object)segmentEnum.ToString());
			}
		}
		RoadSystemEditor.AddUIObserver(this);
		((Control)MyProject.Forms.MainForm.WorldWindow1).MouseDown += new MouseEventHandler(method_7);
		((Control)MyProject.Forms.MainForm.WorldWindow1).MouseUp += new MouseEventHandler(method_8);
		Refresh_FromEvent();
	}

	private void method_2(object sender, EventArgs e)
	{
	}

	private void method_3(object sender, EventArgs e)
	{
	}

	private void method_4(object sender, EventArgs e)
	{
		RoadSystemEditor.CurrentRoadType = (RoadSystem.SegmentEnum)((ComboBox)ComboRoadType).SelectedIndex;
	}

	private void method_5(object sender, EventArgs e)
	{
		RoadSystemEditor.CurrentRoadType = (RoadSystem.SegmentEnum)((ComboBox)ComboRoadType).SelectedIndex;
	}

	private void method_6(object sender, EventArgs e)
	{
		RoadSystemEditor.SelectedSegment_ReplaceType();
	}

	private void method_7(object sender, MouseEventArgs e)
	{
	}

	private void method_8(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Invalid comparison between Unknown and I4
		if ((int)e.Button != 1048576 || !RoadSystemEditor.DrawSegmentMode)
		{
			return;
		}
		(Geopoint_Struct?, RoadSystem.Node)? segmentStartingPoint = RoadSystemEditor.SegmentStartingPoint;
		Geopoint_Struct coordinate = WWC.WWC_ScreenToWorld_Struct(MyProject.Forms.MainForm.WorldWindow1, e.X, e.Y);
		RoadSystem.Node node = null;
		RoadSystem.Node node2 = null;
		if (!segmentStartingPoint.HasValue)
		{
			RoadSystemEditor.SegmentStartingPoint = (WWC.WWC_ScreenToWorld_Struct(MyProject.Forms.MainForm.WorldWindow1, e.X, e.Y), RoadSystemEditor.NodeCurrentlySnapped);
			return;
		}
		if (segmentStartingPoint.Value.Item2 == null)
		{
			if (segmentStartingPoint.Value.Item1.HasValue)
			{
				node = RoadSystemEditor.RoadSystem.AddNode(segmentStartingPoint.Value.Item1.Value);
			}
		}
		else
		{
			node = segmentStartingPoint.Value.Item2;
		}
		if (node != null)
		{
			node2 = (((int)Control.ModifierKeys == 65536 || RoadSystemEditor.NodeCurrentlySnapped == null || RoadSystemEditor.NodeCurrentlySnapped == node) ? RoadSystemEditor.RoadSystem.AddNode(coordinate) : RoadSystemEditor.NodeCurrentlySnapped);
		}
		if (node != null && node2 != null)
		{
			RoadSystemEditor.RoadSystem.AddSegment(node.ID, node2.ID, RoadSystemEditor.CurrentRoadType);
			RoadSystemEditor.SegmentStartingPoint = (null, node2);
		}
	}

	public void RefreshRoadEditor()
	{
		if (!RoadSystemEditor.DrawSegmentMode)
		{
			((ButtonBase)ButtonRoadEditro).BackColor = Color.IndianRed;
			((ButtonBase)ButtonRoadEditro).Text = "Disabled";
		}
		else
		{
			((ButtonBase)ButtonRoadEditro).BackColor = Color.DarkGreen;
			((ButtonBase)ButtonRoadEditro).Text = "Enabled";
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		RoadSystemEditor.DrawSegmentMode = !RoadSystemEditor.DrawSegmentMode;
		RoadSystemEditor.Enabled = !RoadSystemEditor.Enabled;
	}

	private void method_10(object sender, EventArgs e)
	{
		Client.SelectedUnit.AttachToClosestRoadSystem(RoadSystemEditor.RoadSystem);
	}

	private void method_11(object sender, EventArgs e)
	{
		if (Client.SelectedUnit != null && RoadSystemEditor.SelectedRoadNodes.Count > 0)
		{
			Client.SelectedUnit.PathFindingToDestination(RoadSystemEditor.RoadSystem, RoadSystemEditor.SelectedRoadNodes.ElementAt(0).Coordinates.Latitude, RoadSystemEditor.SelectedRoadNodes.ElementAt(0).Coordinates.Longitude, 100f);
			method_1();
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		if (RoadSystemEditor.SelectedRoadNodes.Count > 0 && RoadSystemEditor.RoadSystem.Segments.Count != 0)
		{
			RoadSystemEditor.FloodfillResult = AStar.Search(RoadSystemEditor.RoadSystem, RoadSystemEditor.SelectedRoadNodes.ElementAt(0), null);
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		RoadSystemEditor.FloodfillResult.Clear();
	}

	private void method_14(object sender, EventArgs e)
	{
		if (RoadSystemEditor.SelectedRoadNodes.Count > 0 && RoadSystemEditor.RoadSystem.Segments.Count != 0)
		{
			RoadSystemEditor.GoalPF = RoadSystemEditor.SelectedRoadNodes.ElementAt(0);
			((Label)LabelGoalPF).Text = "Goal PF " + RoadSystemEditor.GoalPF.ID;
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		if (RoadSystemEditor.SelectedRoadNodes.Count > 0 && RoadSystemEditor.GoalPF != null)
		{
			_ = RoadSystemEditor.RoadSystem.Segments.Count;
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		OpenFileDialog val = new OpenFileDialog();
		try
		{
			((FileDialog)val).Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
			((FileDialog)val).Title = "Select a Road Network XML File";
			if ((int)((CommonDialog)val).ShowDialog() == 1)
			{
				string fileName = ((FileDialog)val).FileName;
				RoadSystemEditor.RoadSystem.LoadRoadsFromFile(fileName);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("Failed to load the road network." + Environment.NewLine + "Error: " + ex2.Message, "Error", (MessageBoxButtons)0, (MessageBoxIcon)16);
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		method_1();
	}

	static RoadSystem_Toolbox()
	{
		Class72.smethod_20();
	}
}
