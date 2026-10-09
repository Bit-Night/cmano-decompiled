using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AdvancedDataGridView;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class DamageControlWindow : DarkSecondaryFormBase, GInterface0
{
	[CompilerGenerated]
	internal sealed class _Closure$__103-0
	{
		public PlatformComponent $VB$Local_theComponent;

		public Func<Sensor, bool> $I0;

		public _Closure$__103-0(_Closure$__103-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theComponent = arg0.$VB$Local_theComponent;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Sensor theSensor)
		{
			return Operators.CompareString(theSensor.ObjectID, $VB$Local_theComponent.ObjectID, true) == 0;
		}

		static _Closure$__103-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TGV_Damage")]
	private DarkTreeGridView _TGV_Damage;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private Timer timer_0;

	[AccessedThroughProperty("TSTB_Damage")]
	[CompilerGenerated]
	private ToolStripTextBox _TSTB_Damage;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer2")]
	private Timer timer_1;

	[CompilerGenerated]
	private bool bool_2;

	public ActiveUnit theSelectedUnit;

	public Game theCurrentGame;

	private PlatformComponent platformComponent_0;

	[CompilerGenerated]
	[AccessedThroughProperty("CB1")]
	private ComboBox comboBox_0;

	[CompilerGenerated]
	[AccessedThroughProperty("CB2")]
	private ComboBox comboBox_1;

	[AccessedThroughProperty("CB3")]
	[CompilerGenerated]
	private ComboBox comboBox_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private Keys[] keys_0;

	private virtual DarkTreeGridView TGV_Damage
	{
		[CompilerGenerated]
		get
		{
			return _TGV_Damage;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellMouseEventHandler val = new DataGridViewCellMouseEventHandler(method_4);
			DarkTreeGridView darkTreeGridView = _TGV_Damage;
			if (darkTreeGridView != null)
			{
				((DataGridView)darkTreeGridView).CellMouseClick -= val;
			}
			_TGV_Damage = value;
			darkTreeGridView = _TGV_Damage;
			if (darkTreeGridView != null)
			{
				((DataGridView)darkTreeGridView).CellMouseClick += val;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStrip1")]
	internal virtual DarkToolStrip ToolStrip1 { get; set; }

	[field: AccessedThroughProperty("ToolStripLabel1")]
	internal virtual ToolStripLabel ToolStripLabel1 { get; set; }

	[field: AccessedThroughProperty("Status")]
	internal virtual TreeGridColumn Status { get; set; }

	[field: AccessedThroughProperty("TS_EditDamage")]
	internal virtual DarkToolStrip TS_EditDamage { get; set; }

	[field: AccessedThroughProperty("ToolStripLabel2")]
	internal virtual ToolStripLabel ToolStripLabel2 { get; set; }

	[field: AccessedThroughProperty("TSC_ComponentStatus")]
	internal virtual ToolStripComboBox TSC_ComponentStatus { get; set; }

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
			timer_0 = value;
		}
	}

	[field: AccessedThroughProperty("ToolStripLabel3")]
	internal virtual ToolStripLabel ToolStripLabel3 { get; set; }

	internal virtual ToolStripTextBox TSTB_Damage
	{
		[CompilerGenerated]
		get
		{
			return _TSTB_Damage;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			EventHandler eventHandler2 = method_9;
			EventHandler eventHandler3 = method_10;
			ToolStripTextBox val = _TSTB_Damage;
			if (val != null)
			{
				((ToolStripItem)val).TextChanged -= eventHandler;
				((ToolStripControlHost)val).Enter -= eventHandler2;
				((ToolStripControlHost)val).Leave -= eventHandler3;
			}
			_TSTB_Damage = value;
			val = _TSTB_Damage;
			if (val != null)
			{
				((ToolStripItem)val).TextChanged += eventHandler;
				((ToolStripControlHost)val).Enter += eventHandler2;
				((ToolStripControlHost)val).Leave += eventHandler3;
			}
		}
	}

	internal virtual Timer Timer2
	{
		[CompilerGenerated]
		get
		{
			return timer_1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			Timer val = timer_1;
			if (val != null)
			{
				val.Tick -= eventHandler;
			}
			timer_1 = value;
			val = timer_1;
			if (val != null)
			{
				val.Tick += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripLabel4")]
	internal virtual ToolStripLabel ToolStripLabel4 { get; set; }

	[field: AccessedThroughProperty("ToolStripLabel5")]
	internal virtual ToolStripLabel ToolStripLabel5 { get; set; }

	[field: AccessedThroughProperty("TSC_Fire")]
	internal virtual ToolStripComboBox TSC_Fire { get; set; }

	[field: AccessedThroughProperty("TSC_Flood")]
	internal virtual ToolStripComboBox TSC_Flood { get; set; }

	[field: AccessedThroughProperty("ComponentName")]
	internal virtual TreeGridColumn ComponentName { get; set; }

	[field: AccessedThroughProperty("ComponentStatus")]
	internal virtual TreeGridColumn ComponentStatus { get; set; }

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

	public DamageControlWindow()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		((Form)this).Load += DamageControlWindow_Load;
		((Control)this).KeyDown += new KeyEventHandler(DamageControlWindow_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(DamageControlWindow_FormClosing);
		((Form)this).FormClosed += new FormClosedEventHandler(DamageControlWindow_FormClosed);
		RTMPEnabled = true;
		bool_5 = false;
		keys_0 = (Keys[])(object)new Keys[2]
		{
			(Keys)112,
			(Keys)27
		};
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
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_058e: Unknown result type (might be due to invalid IL or missing references)
		icontainer_1 = new Container();
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		TGV_Damage = new DarkTreeGridView();
		Status = new TreeGridColumn();
		ToolStrip1 = new DarkToolStrip();
		ToolStripLabel1 = new ToolStripLabel();
		TS_EditDamage = new DarkToolStrip();
		ToolStripLabel2 = new ToolStripLabel();
		TSC_ComponentStatus = new ToolStripComboBox();
		ToolStripLabel3 = new ToolStripLabel();
		TSTB_Damage = new ToolStripTextBox();
		ToolStripLabel4 = new ToolStripLabel();
		TSC_Fire = new ToolStripComboBox();
		ToolStripLabel5 = new ToolStripLabel();
		TSC_Flood = new ToolStripComboBox();
		Timer2 = new Timer(icontainer_1);
		ComponentName = new TreeGridColumn();
		ComponentStatus = new TreeGridColumn();
		((ISupportInitialize)(object)TGV_Damage).BeginInit();
		((Control)ToolStrip1).SuspendLayout();
		((Control)TS_EditDamage).SuspendLayout();
		((Control)this).SuspendLayout();
		((DataGridView)TGV_Damage).AllowUserToAddRows = false;
		((DataGridView)TGV_Damage).AllowUserToDeleteRows = false;
		((DataGridView)TGV_Damage).AllowUserToOrderColumns = true;
		((Control)TGV_Damage).Anchor = (AnchorStyles)15;
		((DataGridView)TGV_Damage).BackgroundColor = Color.FromArgb(43, 43, 43);
		((DataGridView)TGV_Damage).BorderStyle = (BorderStyle)0;
		((DataGridView)TGV_Damage).CellBorderStyle = (DataGridViewCellBorderStyle)4;
		((DataGridView)TGV_Damage).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)TGV_Damage).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)TGV_Damage).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[2]
		{
			(DataGridViewColumn)ComponentName,
			(DataGridViewColumn)ComponentStatus
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)TGV_Damage).DefaultCellStyle = val2;
		((DataGridView)TGV_Damage).EditMode = (DataGridViewEditMode)4;
		((DataGridView)TGV_Damage).EnableHeadersVisualStyles = false;
		TGV_Damage.ImageList = null;
		((Control)TGV_Damage).Location = new Point(2, 28);
		((Control)TGV_Damage).Name = "TGV_Damage";
		((DataGridView)TGV_Damage).RowHeadersVisible = false;
		((DataGridView)TGV_Damage).SelectionMode = (DataGridViewSelectionMode)1;
		TGV_Damage.ShowLines = false;
		((Control)TGV_Damage).Size = new Size(471, 233);
		((Control)TGV_Damage).TabIndex = 5;
		Status.DefaultNodeImage = null;
		((DataGridViewColumn)Status).HeaderText = "Status";
		((DataGridViewColumn)Status).Name = "Status";
		((DataGridViewColumn)Status).ReadOnly = true;
		((DataGridViewColumn)Status).Resizable = (DataGridViewTriState)1;
		((DataGridViewTextBoxColumn)Status).SortMode = (DataGridViewColumnSortMode)0;
		((ToolStrip)ToolStrip1).AutoSize = false;
		((ToolStrip)ToolStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)ToolStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)ToolStrip1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)ToolStrip1).ImageScalingSize = new Size(20, 20);
		((ToolStrip)ToolStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[1] { (ToolStripItem)ToolStripLabel1 });
		((Control)ToolStrip1).Location = new Point(0, 0);
		((Control)ToolStrip1).Name = "ToolStrip1";
		((Control)ToolStrip1).Padding = new Padding(5, 0, 1, 0);
		((Control)ToolStrip1).Size = new Size(475, 25);
		((Control)ToolStrip1).TabIndex = 6;
		((Control)ToolStrip1).Text = "ToolStrip1";
		((ToolStripItem)ToolStripLabel1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripLabel1).Name = "ToolStripLabel1";
		((ToolStripItem)ToolStripLabel1).Size = new Size(69, 22);
		((ToolStripItem)ToolStripLabel1).Text = "Damage:";
		((ToolStrip)TS_EditDamage).AutoSize = false;
		((ToolStrip)TS_EditDamage).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)TS_EditDamage).Dock = (DockStyle)2;
		((ToolStrip)TS_EditDamage).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)TS_EditDamage).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)TS_EditDamage).ImageScalingSize = new Size(20, 20);
		((ToolStrip)TS_EditDamage).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[8]
		{
			(ToolStripItem)ToolStripLabel2,
			(ToolStripItem)TSC_ComponentStatus,
			(ToolStripItem)ToolStripLabel3,
			(ToolStripItem)TSTB_Damage,
			(ToolStripItem)ToolStripLabel4,
			(ToolStripItem)TSC_Fire,
			(ToolStripItem)ToolStripLabel5,
			(ToolStripItem)TSC_Flood
		});
		((Control)TS_EditDamage).Location = new Point(0, 264);
		((Control)TS_EditDamage).Name = "TS_EditDamage";
		((Control)TS_EditDamage).Padding = new Padding(5, 0, 1, 0);
		((Control)TS_EditDamage).Size = new Size(475, 25);
		((Control)TS_EditDamage).TabIndex = 7;
		((Control)TS_EditDamage).Text = "ToolStrip2";
		((ToolStripItem)ToolStripLabel2).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripLabel2).Name = "ToolStripLabel2";
		((ToolStripItem)ToolStripLabel2).Size = new Size(52, 22);
		((ToolStripItem)ToolStripLabel2).Text = "Status:";
		((ToolStripControlHost)TSC_ComponentStatus).BackColor = Color.FromArgb(60, 63, 65);
		TSC_ComponentStatus.DropDownStyle = (ComboBoxStyle)2;
		((ToolStripControlHost)TSC_ComponentStatus).ForeColor = Color.FromArgb(220, 220, 220);
		TSC_ComponentStatus.Items.AddRange(new object[5] { "Operational", "Damaged (Light)", "Damaged (Medium)", "Damaged (Heavy)", "Destroyed" });
		((ToolStripItem)TSC_ComponentStatus).Name = "TSC_ComponentStatus";
		((ToolStripControlHost)TSC_ComponentStatus).Size = new Size(121, 25);
		((ToolStripItem)ToolStripLabel3).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripLabel3).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripLabel3).Name = "ToolStripLabel3";
		((ToolStripItem)ToolStripLabel3).Size = new Size(120, 22);
		((ToolStripItem)ToolStripLabel3).Text = "Overall Damage:";
		((ToolStripControlHost)TSTB_Damage).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripControlHost)TSTB_Damage).ForeColor = Color.FromArgb(220, 220, 220);
		TSTB_Damage.MaxLength = 5;
		((ToolStripItem)TSTB_Damage).Name = "TSTB_Damage";
		((ToolStripControlHost)TSTB_Damage).Size = new Size(50, 25);
		((ToolStripItem)ToolStripLabel4).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripLabel4).Name = "ToolStripLabel4";
		((ToolStripItem)ToolStripLabel4).Size = new Size(33, 22);
		((ToolStripItem)ToolStripLabel4).Text = "Fire";
		((ToolStripControlHost)TSC_Fire).BackColor = Color.FromArgb(60, 63, 65);
		TSC_Fire.DropDownWidth = 100;
		((ToolStripControlHost)TSC_Fire).ForeColor = Color.FromArgb(220, 220, 220);
		TSC_Fire.Items.AddRange(new object[5] { "No Fire", "Minor", "Major", "Servere", "Conflagration" });
		((ToolStripItem)TSC_Fire).Name = "TSC_Fire";
		((ToolStripControlHost)TSC_Fire).Size = new Size(121, 28);
		((ToolStripItem)ToolStripLabel5).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripLabel5).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripLabel5).Name = "ToolStripLabel5";
		((ToolStripItem)ToolStripLabel5).Size = new Size(47, 20);
		((ToolStripItem)ToolStripLabel5).Text = "Flood";
		((ToolStripControlHost)TSC_Flood).BackColor = Color.FromArgb(60, 63, 65);
		TSC_Flood.DropDownWidth = 100;
		((ToolStripControlHost)TSC_Flood).ForeColor = Color.FromArgb(220, 220, 220);
		TSC_Flood.Items.AddRange(new object[5] { "No Flooding", "Minor", "Major", "Servere", "Capsizing" });
		((ToolStripItem)TSC_Flood).Name = "TSC_Flood";
		((ToolStripControlHost)TSC_Flood).Size = new Size(121, 28);
		ComponentName.DefaultNodeImage = null;
		((DataGridViewColumn)ComponentName).HeaderText = "Name";
		((DataGridViewColumn)ComponentName).Name = "ComponentName";
		((DataGridViewColumn)ComponentName).ReadOnly = true;
		((DataGridViewTextBoxColumn)ComponentName).SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)ComponentName).Width = 200;
		((DataGridViewColumn)ComponentStatus).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		ComponentStatus.DefaultNodeImage = null;
		((DataGridViewColumn)ComponentStatus).HeaderText = "Status";
		((DataGridViewColumn)ComponentStatus).Name = "ComponentStatus";
		((DataGridViewColumn)ComponentStatus).ReadOnly = true;
		((DataGridViewTextBoxColumn)ComponentStatus).SortMode = (DataGridViewColumnSortMode)0;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(475, 289);
		((Control)this).Controls.Add((Control)(object)TS_EditDamage);
		((Control)this).Controls.Add((Control)(object)ToolStrip1);
		((Control)this).Controls.Add((Control)(object)TGV_Damage);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "DamageControlWindow";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Damage Control";
		((ISupportInitialize)(object)TGV_Damage).EndInit();
		((Control)ToolStrip1).ResumeLayout(false);
		((Control)ToolStrip1).PerformLayout();
		((Control)TS_EditDamage).ResumeLayout(false);
		((Control)TS_EditDamage).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual ComboBox vmethod_0()
	{
		return comboBox_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_1(ComboBox WithEventsValue)
	{
		EventHandler eventHandler = method_5;
		ComboBox val = comboBox_0;
		if (val != null)
		{
			val.SelectionChangeCommitted -= eventHandler;
		}
		comboBox_0 = WithEventsValue;
		val = comboBox_0;
		if (val != null)
		{
			val.SelectionChangeCommitted += eventHandler;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual ComboBox vmethod_2()
	{
		return comboBox_1;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_3(ComboBox WithEventsValue)
	{
		EventHandler eventHandler = method_11;
		ComboBox val = comboBox_1;
		if (val != null)
		{
			val.SelectionChangeCommitted -= eventHandler;
		}
		comboBox_1 = WithEventsValue;
		val = comboBox_1;
		if (val != null)
		{
			val.SelectionChangeCommitted += eventHandler;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual ComboBox vmethod_4()
	{
		return comboBox_2;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_5(ComboBox WithEventsValue)
	{
		EventHandler eventHandler = method_12;
		ComboBox val = comboBox_2;
		if (val != null)
		{
			val.SelectionChangeCommitted -= eventHandler;
		}
		comboBox_2 = WithEventsValue;
		val = comboBox_2;
		if (val != null)
		{
			val.SelectionChangeCommitted += eventHandler;
		}
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		Keys[] array = keys_0;
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				Keys val = array[num];
				if (keyData == val)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return false;
		}
		int result;
		if (!((Control)this).Visible)
		{
			((Form)this).Activate();
			result = 1;
		}
		else
		{
			((Form)this).Close();
			result = 1;
		}
		return (byte)result != 0;
	}

	private void DamageControlWindow_Load(object sender, EventArgs e)
	{
		bool_5 = Client.Realtime;
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		if (!Information.IsNothing((object)theCurrentGame))
		{
			((Control)TS_EditDamage).Visible = Client.AllowEditModeActions;
		}
		vmethod_1(TSC_ComponentStatus.ComboBox);
		vmethod_3(TSC_Fire.ComboBox);
		vmethod_5(TSC_Flood.ComboBox);
		Timer2.Start();
		method_2();
		platformComponent_0 = (PlatformComponent)((DataGridViewBand)TGV_Damage.CurrentNode).Tag;
		PlatformComponent.StatusChanged += method_6;
	}

	private void DamageControlWindow_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Invalid comparison between Unknown and I4
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Invalid comparison between Unknown and I4
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Invalid comparison between Unknown and I4
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Invalid comparison between Unknown and I4
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Invalid comparison between Unknown and I4
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Invalid comparison between Unknown and I4
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Invalid comparison between Unknown and I4
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Invalid comparison between Unknown and I4
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Invalid comparison between Unknown and I4
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Invalid comparison between Unknown and I4
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Invalid comparison between Unknown and I4
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
			return;
		}
		if ((int)e.KeyCode == 121 && ((Control)this).Visible)
		{
			((Form)this).Close();
			return;
		}
		if (bool_4 && ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
		if (!bool_4)
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_2()
	{
		TGV_Damage.Rows.Clear();
		TGV_Damage.Nodes.Clear();
		((ToolStripItem)ToolStripLabel1).Text = "Damage: " + string.Format("{0:0.0}", theSelectedUnit.Damage.DamagePercent, 1) + "%";
		((Form)this).Text = "Damage Status for " + Misc.RemoveHiddenString(theSelectedUnit.Name);
		if (theSelectedUnit.Mounts.Count > 0)
		{
			TreeGridNode treeGridNode = new TreeGridNode();
			new TreeGridNode();
			treeGridNode = TGV_Damage.Nodes.Add("Mounts");
			foreach (Mount mount in theSelectedUnit.Mounts)
			{
				TreeGridNode treeGridNode2 = treeGridNode.Nodes.Add(Misc.RemoveHiddenString(mount.Name), mount.Status.ToString());
				((DataGridViewBand)treeGridNode2).Tag = mount;
				((DataGridViewRow)treeGridNode2).DefaultCellStyle.ForeColor = GetComponentDamageColor(mount);
			}
			treeGridNode.Expand();
		}
		if (((Platform)theSelectedUnit).Magazines.Count() > 0)
		{
			TreeGridNode treeGridNode3 = new TreeGridNode();
			new TreeGridNode();
			treeGridNode3 = TGV_Damage.Nodes.Add("Magazines");
			Magazine[] magazines = ((Platform)theSelectedUnit).Magazines;
			foreach (Magazine magazine in magazines)
			{
				TreeGridNode treeGridNode4 = treeGridNode3.Nodes.Add(Misc.RemoveHiddenString(magazine.Name), magazine.Status.ToString());
				((DataGridViewBand)treeGridNode4).Tag = magazine;
				((DataGridViewRow)treeGridNode4).DefaultCellStyle.ForeColor = GetComponentDamageColor(magazine);
			}
			treeGridNode3.Expand();
		}
		if (theSelectedUnit.Sensors_ReadOnly().Length > 0)
		{
			TreeGridNode treeGridNode5 = new TreeGridNode();
			new TreeGridNode();
			treeGridNode5 = TGV_Damage.Nodes.Add("Sensors");
			Sensor[] array = theSelectedUnit.Sensors_ReadOnly();
			foreach (Sensor sensor in array)
			{
				TreeGridNode treeGridNode6 = treeGridNode5.Nodes.Add(Misc.RemoveHiddenString(sensor.Name), sensor.Status.ToString());
				((DataGridViewBand)treeGridNode6).Tag = sensor;
				((DataGridViewRow)treeGridNode6).DefaultCellStyle.ForeColor = GetComponentDamageColor(sensor);
			}
			treeGridNode5.Expand();
		}
		if (theSelectedUnit.Comms_ReadOnly.Count() > 0)
		{
			TreeGridNode treeGridNode7 = new TreeGridNode();
			TreeGridNode treeGridNode8 = new TreeGridNode();
			treeGridNode7 = TGV_Damage.Nodes.Add("Comms & Datalinks");
			CommDevice[] comms_ReadOnly = theSelectedUnit.Comms_ReadOnly;
			foreach (CommDevice commDevice in comms_ReadOnly)
			{
				string text = commDevice.Status.ToString();
				if (commDevice.Status == PlatformComponent._ComponentStatus.Operational && commDevice.IsJammed)
				{
					text += " - JAMMED";
				}
				treeGridNode8 = treeGridNode7.Nodes.Add(Misc.RemoveHiddenString(commDevice.Name), text);
				((DataGridViewBand)treeGridNode8).Tag = commDevice;
				((DataGridViewRow)treeGridNode8).DefaultCellStyle.ForeColor = GetComponentDamageColor(commDevice);
				if (commDevice.Status == PlatformComponent._ComponentStatus.Operational && commDevice.IsJammed)
				{
					((DataGridViewRow)treeGridNode8).DefaultCellStyle.ForeColor = Color.Blue;
				}
			}
			treeGridNode7.Expand();
		}
		if (theSelectedUnit.MineCountermeasures.Count > 0)
		{
			TreeGridNode treeGridNode9 = new TreeGridNode();
			new TreeGridNode();
			treeGridNode9 = TGV_Damage.Nodes.Add("Mine Counter Measures");
			foreach (Sensor mineCountermeasure in theSelectedUnit.MineCountermeasures)
			{
				string text2 = mineCountermeasure.Status.ToString();
				TreeGridNode treeGridNode10 = treeGridNode9.Nodes.Add(Misc.RemoveHiddenString(mineCountermeasure.Name), text2);
				((DataGridViewBand)treeGridNode10).Tag = mineCountermeasure;
				((DataGridViewRow)treeGridNode10).DefaultCellStyle.ForeColor = GetComponentDamageColor(mineCountermeasure);
			}
			treeGridNode9.Expand();
		}
		if (theSelectedUnit.DockFacilities_ReadOnly.Length > 0)
		{
			TreeGridNode treeGridNode11 = new TreeGridNode();
			new TreeGridNode();
			treeGridNode11 = TGV_Damage.Nodes.Add("Docking Facilities");
			DockFacility[] dockFacilities_ReadOnly = theSelectedUnit.DockFacilities_ReadOnly;
			foreach (DockFacility dockFacility in dockFacilities_ReadOnly)
			{
				TreeGridNode treeGridNode12 = treeGridNode11.Nodes.Add(Misc.RemoveHiddenString(dockFacility.Name), dockFacility.Status.ToString());
				((DataGridViewBand)treeGridNode12).Tag = dockFacility;
				((DataGridViewRow)treeGridNode12).DefaultCellStyle.ForeColor = GetComponentDamageColor(dockFacility);
			}
			treeGridNode11.Expand();
		}
		if (theSelectedUnit.AirFacilities_ReadOnly.Length > 0)
		{
			TreeGridNode treeGridNode13 = new TreeGridNode();
			new TreeGridNode();
			treeGridNode13 = TGV_Damage.Nodes.Add("Air Facilities");
			for (int m = theSelectedUnit.AirFacilities_ReadOnly.Length - 1; m >= 0; m += -1)
			{
				AirFacility airFacility = theSelectedUnit.AirFacilities_ReadOnly[m];
				string text3 = "";
				text3 = ((airFacility.MaxAircraftSize <= airFacility.EffectiveRunwaySize) ? airFacility.Status.ToString() : "Operational, Reduced Capacity");
				TreeGridNode treeGridNode14 = treeGridNode13.Nodes.Add(Misc.RemoveHiddenString(airFacility.Name), text3);
				((DataGridViewBand)treeGridNode14).Tag = airFacility;
				((DataGridViewRow)treeGridNode14).DefaultCellStyle.ForeColor = GetComponentDamageColor(airFacility);
			}
			treeGridNode13.Expand();
		}
		if (((Platform)theSelectedUnit).Propulsion.Count > 0)
		{
			TreeGridNode treeGridNode15 = new TreeGridNode();
			new TreeGridNode();
			treeGridNode15 = TGV_Damage.Nodes.Add("Engineering / Propulsion");
			foreach (Engine item in theSelectedUnit.Propulsion)
			{
				TreeGridNode treeGridNode16 = treeGridNode15.Nodes.Add(Misc.RemoveHiddenString(item.Name), item.Status.ToString());
				((DataGridViewBand)treeGridNode16).Tag = item;
				((DataGridViewRow)treeGridNode16).DefaultCellStyle.ForeColor = GetComponentDamageColor(item);
			}
			treeGridNode15.Expand();
		}
		switch (theSelectedUnit.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Ship:
		{
			TreeGridNode treeGridNode20 = TGV_Damage.Nodes.Add(((Ship)theSelectedUnit).CIC.Name, ((Ship)theSelectedUnit).CIC.Status.ToString());
			((DataGridViewBand)treeGridNode20).Tag = ((Ship)theSelectedUnit).CIC;
			((DataGridViewRow)treeGridNode20).DefaultCellStyle.ForeColor = GetComponentDamageColor(((Ship)theSelectedUnit).CIC);
			TreeGridNode treeGridNode21 = TGV_Damage.Nodes.Add(((Ship)theSelectedUnit).Rudder.Name, ((Ship)theSelectedUnit).Rudder.Status.ToString());
			((DataGridViewBand)treeGridNode21).Tag = ((Ship)theSelectedUnit).Rudder;
			((DataGridViewRow)treeGridNode21).DefaultCellStyle.ForeColor = GetComponentDamageColor(((Ship)theSelectedUnit).Rudder);
			break;
		}
		case GlobalVariables.ActiveUnitType.Submarine:
		{
			TreeGridNode treeGridNode18 = TGV_Damage.Nodes.Add(((Submarine)theSelectedUnit).CIC.Name, ((Submarine)theSelectedUnit).CIC.Status.ToString());
			((DataGridViewBand)treeGridNode18).Tag = ((Submarine)theSelectedUnit).CIC;
			((DataGridViewRow)treeGridNode18).DefaultCellStyle.ForeColor = GetComponentDamageColor(((Submarine)theSelectedUnit).CIC);
			TreeGridNode treeGridNode19 = TGV_Damage.Nodes.Add(((Submarine)theSelectedUnit).Rudder.Name, ((Submarine)theSelectedUnit).Rudder.Status.ToString());
			((DataGridViewBand)treeGridNode19).Tag = ((Submarine)theSelectedUnit).Rudder;
			((DataGridViewRow)treeGridNode19).DefaultCellStyle.ForeColor = GetComponentDamageColor(((Submarine)theSelectedUnit).Rudder);
			break;
		}
		case GlobalVariables.ActiveUnitType.Facility:
		{
			TreeGridNode treeGridNode17 = TGV_Damage.Nodes.Add(((Facility)theSelectedUnit).CIC.Name, ((Facility)theSelectedUnit).CIC.Status.ToString());
			((DataGridViewBand)treeGridNode17).Tag = ((Facility)theSelectedUnit).CIC;
			((DataGridViewRow)treeGridNode17).DefaultCellStyle.ForeColor = GetComponentDamageColor(((Facility)theSelectedUnit).CIC);
			break;
		}
		}
		vmethod_2().SelectedIndex = Math.Min(Math.Max(0, (int)theSelectedUnit.Damage.FireIntensity), 4);
		if (!Client.SelectedUnit.IsSubmarine && !Client.SelectedUnit.IsShip)
		{
			((Control)vmethod_4()).Enabled = false;
			return;
		}
		((Control)vmethod_4()).Enabled = true;
		vmethod_4().SelectedIndex = (int)theSelectedUnit.Damage.FloodIntensity;
	}

	public void RefreshForm()
	{
		foreach (TreeGridNode node in TGV_Damage.Nodes)
		{
			method_3(node);
		}
	}

	private void method_3(TreeGridNode treeGridNode_0)
	{
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(((DataGridViewBand)treeGridNode_0).Tag)))
		{
			PlatformComponent platformComponent = (PlatformComponent)((DataGridViewBand)treeGridNode_0).Tag;
			string text = platformComponent.Status.ToString();
			if ((object)platformComponent.GetType() == typeof(CommDevice) && platformComponent.Status == PlatformComponent._ComponentStatus.Operational && ((CommDevice)platformComponent).IsJammed)
			{
				text += " - JAMMED";
				((DataGridViewRow)treeGridNode_0).DefaultCellStyle.ForeColor = Color.Blue;
			}
			((DataGridViewRow)treeGridNode_0).SetValues(new object[2] { platformComponent.Name, text });
			((DataGridViewRow)treeGridNode_0).DefaultCellStyle.ForeColor = GetComponentDamageColor(platformComponent);
		}
		foreach (TreeGridNode node in treeGridNode_0.Nodes)
		{
			method_3(node);
		}
	}

	private void method_4(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(((DataGridViewBand)TGV_Damage.CurrentNode).Tag)))
		{
			return;
		}
		platformComponent_0 = (PlatformComponent)((DataGridViewBand)TGV_Damage.CurrentNode).Tag;
		switch (platformComponent_0.Status)
		{
		case PlatformComponent._ComponentStatus.Operational:
			TSC_ComponentStatus.SelectedIndex = 0;
			break;
		case PlatformComponent._ComponentStatus.Damaged:
			switch (platformComponent_0.DamageSeverity)
			{
			case PlatformComponent._DamageSeverityFactor.Light:
				TSC_ComponentStatus.SelectedIndex = 1;
				break;
			case PlatformComponent._DamageSeverityFactor.Medium:
				TSC_ComponentStatus.SelectedIndex = 2;
				break;
			case PlatformComponent._DamageSeverityFactor.Heavy:
				TSC_ComponentStatus.SelectedIndex = 3;
				break;
			}
			break;
		case PlatformComponent._ComponentStatus.Destroyed:
			TSC_ComponentStatus.SelectedIndex = 4;
			break;
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		foreach (TreeGridNode item in Module1.AllNodes((TreeGridView)TGV_Damage))
		{
			if (!((DataGridViewRow)item).Selected || Information.IsNothing(RuntimeHelpers.GetObjectValue(((DataGridViewBand)item).Tag)))
			{
				continue;
			}
			platformComponent_0 = (PlatformComponent)((DataGridViewBand)item).Tag;
			if (!Information.IsNothing((object)platformComponent_0))
			{
				switch (vmethod_0().SelectedIndex)
				{
				case 0:
					platformComponent_0.MakeOperational(GiveUserFeedback: true);
					break;
				case 1:
					platformComponent_0.Damage(PlatformComponent._DamageSeverityFactor.Light);
					break;
				case 2:
					platformComponent_0.Damage(PlatformComponent._DamageSeverityFactor.Medium);
					break;
				case 3:
					platformComponent_0.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
					break;
				case 4:
					platformComponent_0.Destroy(theSelectedUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: true, IsAimpointFacility: false);
					break;
				}
			}
		}
	}

	private void method_6(PlatformComponent platformComponent_1)
	{
		_Closure$__103-0 arg = default(_Closure$__103-0);
		_Closure$__103-0 CS$<>8__locals9 = new _Closure$__103-0(arg);
		CS$<>8__locals9.$VB$Local_theComponent = platformComponent_1;
		if (CS$<>8__locals9.$VB$Local_theComponent.ParentPlatform == theSelectedUnit)
		{
			bool_3 = true;
		}
		else
		{
			if ((object)CS$<>8__locals9.$VB$Local_theComponent.GetType() != typeof(Sensor) || CS$<>8__locals9.$VB$Local_theComponent.ParentPlatform == null || !CS$<>8__locals9.$VB$Local_theComponent.ParentPlatform.IsWeapon)
			{
				return;
			}
			using IEnumerator<Sensor> enumerator = theSelectedUnit.Sensors_ReadOnly().Where((CS$<>8__locals9.$I0 != null) ? CS$<>8__locals9.$I0 : (CS$<>8__locals9.$I0 = [SpecialName] (Sensor theSensor) => Operators.CompareString(theSensor.ObjectID, CS$<>8__locals9.$VB$Local_theComponent.ObjectID, true) == 0)).GetEnumerator();
			if (enumerator.MoveNext())
			{
				_ = enumerator.Current;
				bool_3 = true;
			}
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		if (!((Operators.CompareString(((ToolStripControlHost)TSTB_Damage).Text, "", true) == 0) | !Versioned.IsNumeric((object)((ToolStripControlHost)TSTB_Damage).Text)))
		{
			if (Conversions.ToDouble(((ToolStripControlHost)TSTB_Damage).Text) < 0.0)
			{
				((ToolStripControlHost)TSTB_Damage).Text = 0.ToString();
			}
			if (Conversions.ToDouble(((ToolStripControlHost)TSTB_Damage).Text) > 100.0)
			{
				((ToolStripControlHost)TSTB_Damage).Text = 100.ToString();
			}
			theSelectedUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, (float)((double)theSelectedUnit.InitialDP * ((100.0 - Conversions.ToDouble(((ToolStripControlHost)TSTB_Damage).Text)) / 100.0)));
			((ToolStripItem)ToolStripLabel1).Text = "Damage: " + string.Format("{0:0.0}", theSelectedUnit.Damage.DamagePercent, 2) + "%";
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		if (bool_3 || bool_5)
		{
			RefreshForm();
			bool_3 = false;
		}
	}

	private void DamageControlWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
		Client.MustRefreshMainForm = true;
		Client.MustRefreshMainForm = true;
	}

	private void DamageControlWindow_FormClosed(object sender, FormClosedEventArgs e)
	{
		PlatformComponent.StatusChanged -= method_6;
	}

	private void method_9(object sender, EventArgs e)
	{
		bool_4 = true;
	}

	private void method_10(object sender, EventArgs e)
	{
		bool_4 = false;
		((ToolStripItem)ToolStripLabel2).Select();
	}

	private void method_11(object sender, EventArgs e)
	{
		ActiveUnit_Damage.FireIntensityLevel fireIntensity = theSelectedUnit.Damage.FireIntensity;
		switch (vmethod_2().SelectedIndex)
		{
		case 0:
			fireIntensity = ActiveUnit_Damage.FireIntensityLevel.NoFire;
			break;
		case 1:
			fireIntensity = ActiveUnit_Damage.FireIntensityLevel.Minor;
			break;
		case 2:
			fireIntensity = ActiveUnit_Damage.FireIntensityLevel.Major;
			break;
		case 3:
			fireIntensity = ActiveUnit_Damage.FireIntensityLevel.Severe;
			break;
		case 4:
			fireIntensity = ActiveUnit_Damage.FireIntensityLevel.Conflagration;
			break;
		}
		theSelectedUnit.Damage.FireIntensity = fireIntensity;
	}

	private void method_12(object sender, EventArgs e)
	{
		ActiveUnit_Damage.FloodingIntensityLevel floodIntensity = theSelectedUnit.Damage.FloodIntensity;
		switch (vmethod_4().SelectedIndex)
		{
		case 0:
			floodIntensity = ActiveUnit_Damage.FloodingIntensityLevel.NoFlooding;
			break;
		case 1:
			floodIntensity = ActiveUnit_Damage.FloodingIntensityLevel.Minor;
			break;
		case 2:
			floodIntensity = ActiveUnit_Damage.FloodingIntensityLevel.Major;
			break;
		case 3:
			floodIntensity = ActiveUnit_Damage.FloodingIntensityLevel.Severe;
			break;
		case 4:
			floodIntensity = ActiveUnit_Damage.FloodingIntensityLevel.Capsizing;
			break;
		}
		theSelectedUnit.Damage.FloodIntensity = floodIntensity;
	}

	static DamageControlWindow()
	{
		Class72.smethod_20();
	}
}
