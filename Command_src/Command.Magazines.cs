using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdvancedDataGridView;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Magazines : DarkSecondaryFormBase, GInterface0
{
	[CompilerGenerated]
	internal sealed class _Closure$__102-0
	{
		public List<WeaponRec> $VB$Local_WeapRecs_NotEmpty;

		public TreeGridNode $VB$Local_MagNode;

		public List<WeaponRec> $VB$Local_WeapRecs_Empty;

		public Magazines $VB$Me;

		public _Closure$__102-0(_Closure$__102-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_WeapRecs_NotEmpty = arg0.$VB$Local_WeapRecs_NotEmpty;
				$VB$Local_MagNode = arg0.$VB$Local_MagNode;
				$VB$Local_WeapRecs_Empty = arg0.$VB$Local_WeapRecs_Empty;
			}
		}

		[SpecialName]
		internal void _Lambda$__4()
		{
			using (List<WeaponRec>.Enumerator enumerator = $VB$Local_WeapRecs_NotEmpty.GetEnumerator())
			{
				_Closure$__102-1 closure$__102- = default(_Closure$__102-1);
				while (enumerator.MoveNext())
				{
					closure$__102- = new _Closure$__102-1(closure$__102-)
					{
						$VB$NonLocal_$VB$Closure_2 = this,
						$VB$Local_theRec = enumerator.Current
					};
					((Control)$VB$Me).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__102-._Lambda$__5));
				}
			}
			using List<WeaponRec>.Enumerator enumerator2 = $VB$Local_WeapRecs_Empty.GetEnumerator();
			_Closure$__102-2 closure$__102-2 = default(_Closure$__102-2);
			while (enumerator2.MoveNext())
			{
				closure$__102-2 = new _Closure$__102-2(closure$__102-2)
				{
					$VB$NonLocal_$VB$Closure_3 = this,
					$VB$Local_theRec = enumerator2.Current
				};
				((Control)$VB$Me).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__102-2._Lambda$__6));
			}
		}

		static _Closure$__102-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__102-1
	{
		public WeaponRec $VB$Local_theRec;

		public _Closure$__102-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__102-1(_Closure$__102-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theRec = arg0.$VB$Local_theRec;
			}
		}

		[SpecialName]
		internal void _Lambda$__5()
		{
			$VB$NonLocal_$VB$Closure_2.$VB$Me.method_26($VB$NonLocal_$VB$Closure_2.$VB$Local_MagNode, $VB$Local_theRec);
		}

		static _Closure$__102-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__102-2
	{
		public WeaponRec $VB$Local_theRec;

		public _Closure$__102-0 $VB$NonLocal_$VB$Closure_3;

		public _Closure$__102-2(_Closure$__102-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theRec = arg0.$VB$Local_theRec;
			}
		}

		[SpecialName]
		internal void _Lambda$__6()
		{
			$VB$NonLocal_$VB$Closure_3.$VB$Me.method_26($VB$NonLocal_$VB$Closure_3.$VB$Local_MagNode, $VB$Local_theRec);
		}

		static _Closure$__102-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__83-0
	{
		public TreeGridNode $VB$Local_theNode;

		public Magazines $VB$Me;

		public _Closure$__83-0(_Closure$__83-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theNode = arg0.$VB$Local_theNode;
			}
		}

		static _Closure$__83-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__83-1
	{
		public WeaponRec $VB$Local_theRec;

		public _Closure$__83-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__83-1(_Closure$__83-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theRec = arg0.$VB$Local_theRec;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$NonLocal_$VB$Closure_2.$VB$Me.method_26($VB$NonLocal_$VB$Closure_2.$VB$Local_theNode, $VB$Local_theRec);
			if (!$VB$NonLocal_$VB$Closure_2.$VB$Local_theNode.IsExpanded)
			{
				$VB$NonLocal_$VB$Closure_2.$VB$Local_theNode.Expand();
			}
		}

		static _Closure$__83-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__84-0
	{
		public TreeGridNode $VB$Local_theNode;

		public _Closure$__84-0(_Closure$__84-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theNode = arg0.$VB$Local_theNode;
			}
		}

		static _Closure$__84-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__84-1
	{
		public TreeGridNode $VB$Local_theRecNode;

		public _Closure$__84-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__84-1(_Closure$__84-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theRecNode = arg0.$VB$Local_theRecNode;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$NonLocal_$VB$Closure_2.$VB$Local_theNode.Nodes.Remove($VB$Local_theRecNode);
		}

		static _Closure$__84-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__85-0
	{
		public TreeGridNode $VB$Local_theRecNode;

		public _Closure$__85-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__85-0(_Closure$__85-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theRecNode = arg0.$VB$Local_theRecNode;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			((DataGridViewRow)$VB$Local_theRecNode).SetValues(new object[1] { Conversions.ToString($VB$NonLocal_$VB$Closure_2.$VB$Local_theRec.CurrentLoad) + "/" + Conversions.ToString($VB$NonLocal_$VB$Closure_2.$VB$Local_theRec.MaxLoad) + " " + Misc.RemoveHiddenString(Strings.Trim($VB$NonLocal_$VB$Closure_2.$VB$Local_theRec.get_ReferenceWeapon($VB$NonLocal_$VB$Closure_2.$VB$Me.SelectedUnit.ParentScen).Name)) });
		}

		static _Closure$__85-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__85-1
	{
		public WeaponRec $VB$Local_theRec;

		public Magazines $VB$Me;

		public _Closure$__85-1(_Closure$__85-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theRec = arg0.$VB$Local_theRec;
			}
		}

		static _Closure$__85-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__86-0
	{
		public TreeGridNode $VB$Local_theNode;

		public Magazines $VB$Me;

		public _Closure$__86-0(_Closure$__86-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theNode = arg0.$VB$Local_theNode;
			}
		}

		static _Closure$__86-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__86-1
	{
		public Magazine $VB$Local_theMag;

		public _Closure$__86-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__86-1(_Closure$__86-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theMag = arg0.$VB$Local_theMag;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$NonLocal_$VB$Closure_2.$VB$Me.method_15($VB$NonLocal_$VB$Closure_2.$VB$Local_theNode, $VB$Local_theMag);
		}

		static _Closure$__86-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__87-0
	{
		public Mount $VB$Local_theMount;

		public Magazines $VB$Me;

		public _Closure$__87-0(_Closure$__87-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theMount = arg0.$VB$Local_theMount;
			}
		}

		[SpecialName]
		internal void _Lambda$__1()
		{
			$VB$Me.method_14($VB$Local_theMount.MountMagazine);
		}

		static _Closure$__87-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__87-1
	{
		public Magazine $VB$Local_theMag;

		public Magazines $VB$Me;

		public _Closure$__87-1(_Closure$__87-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theMag = arg0.$VB$Local_theMag;
			}
		}

		[SpecialName]
		internal void _Lambda$__2()
		{
			$VB$Me.method_14($VB$Local_theMag);
		}

		static _Closure$__87-1()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TGV_Mags")]
	private DarkTreeGridView _TGV_Mags;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_RemoveRec")]
	private ToolStripButton _TSB_RemoveRec;

	[AccessedThroughProperty("TSTB_RecCount")]
	[CompilerGenerated]
	private ToolStripTextBox _TSTB_RecCount;

	[AccessedThroughProperty("TSB_AddRec")]
	[CompilerGenerated]
	private ToolStripButton _TSB_AddRec;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private Timer timer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_AddMag")]
	private ToolStripButton _TSB_AddMag;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_RemoveMag")]
	private ToolStripButton _TSB_RemoveMag;

	[CompilerGenerated]
	private bool bool_2;

	public ActiveUnit SelectedUnit;

	public Magazine SelectedMag;

	private WeaponRec weaponRec_0;

	private MaintainScrollPosition maintainScrollPosition_0;

	[CompilerGenerated]
	[AccessedThroughProperty("CB1")]
	private ComboBox comboBox_0;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private Keys[] keys_0;

	private virtual DarkTreeGridView TGV_Mags
	{
		[CompilerGenerated]
		get
		{
			return _TGV_Mags;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellMouseEventHandler val = new DataGridViewCellMouseEventHandler(method_16);
			ExpandingEventHandler value2 = method_25;
			CollapsingEventHandler value3 = method_27;
			DarkTreeGridView darkTreeGridView = _TGV_Mags;
			if (darkTreeGridView != null)
			{
				((DataGridView)darkTreeGridView).CellMouseClick -= val;
				darkTreeGridView.NodeExpanding -= value2;
				darkTreeGridView.NodeCollapsing -= value3;
			}
			_TGV_Mags = value;
			darkTreeGridView = _TGV_Mags;
			if (darkTreeGridView != null)
			{
				((DataGridView)darkTreeGridView).CellMouseClick += val;
				darkTreeGridView.NodeExpanding += value2;
				darkTreeGridView.NodeCollapsing += value3;
			}
		}
	}

	[field: AccessedThroughProperty("TS_Edit")]
	internal virtual DarkToolStrip TS_Edit { get; set; }

	internal virtual ToolStripButton TSB_RemoveRec
	{
		[CompilerGenerated]
		get
		{
			return _TSB_RemoveRec;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			ToolStripButton val = _TSB_RemoveRec;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_RemoveRec = value;
			val = _TSB_RemoveRec;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripLabel1")]
	internal virtual ToolStripLabel ToolStripLabel1 { get; set; }

	internal virtual ToolStripTextBox TSTB_RecCount
	{
		[CompilerGenerated]
		get
		{
			return _TSTB_RecCount;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			EventHandler eventHandler2 = method_21;
			EventHandler eventHandler3 = method_22;
			ToolStripTextBox val = _TSTB_RecCount;
			if (val != null)
			{
				((ToolStripItem)val).TextChanged -= eventHandler;
				((ToolStripControlHost)val).Enter -= eventHandler2;
				((ToolStripControlHost)val).Leave -= eventHandler3;
			}
			_TSTB_RecCount = value;
			val = _TSTB_RecCount;
			if (val != null)
			{
				((ToolStripItem)val).TextChanged += eventHandler;
				((ToolStripControlHost)val).Enter += eventHandler2;
				((ToolStripControlHost)val).Leave += eventHandler3;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripLabel2")]
	internal virtual ToolStripLabel ToolStripLabel2 { get; set; }

	[field: AccessedThroughProperty("TSC_MagStatus")]
	internal virtual ToolStripComboBox TSC_MagStatus { get; set; }

	internal virtual ToolStripButton TSB_AddRec
	{
		[CompilerGenerated]
		get
		{
			return _TSB_AddRec;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			ToolStripButton val = _TSB_AddRec;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_AddRec = value;
			val = _TSB_AddRec;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
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
			EventHandler eventHandler = method_4;
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

	internal virtual ToolStripButton TSB_AddMag
	{
		[CompilerGenerated]
		get
		{
			return _TSB_AddMag;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_23;
			ToolStripButton val = _TSB_AddMag;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_AddMag = value;
			val = _TSB_AddMag;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_RemoveMag
	{
		[CompilerGenerated]
		get
		{
			return _TSB_RemoveMag;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_24;
			ToolStripButton val = _TSB_RemoveMag;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_RemoveMag = value;
			val = _TSB_RemoveMag;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Column_Magazine")]
	internal virtual TreeGridColumn Column_Magazine { get; set; }

	[field: AccessedThroughProperty("Status")]
	internal virtual TreeGridColumn Status { get; set; }

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

	public Magazines()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		((Form)this).Load += Magazines_Load;
		((Form)this).Shown += Magazines_Shown;
		((Control)this).KeyDown += new KeyEventHandler(Magazines_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(Magazines_FormClosing);
		((Form)this).FormClosed += new FormClosedEventHandler(Magazines_FormClosed);
		((Form)this).Closed += Magazines_Closed;
		RTMPEnabled = true;
		maintainScrollPosition_0 = new MaintainScrollPosition();
		bool_4 = false;
		bool_5 = false;
		keys_0 = (Keys[])(object)new Keys[2]
		{
			(Keys)116,
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
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Expected O, but got Unknown
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Expected O, but got Unknown
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_057c: Expected O, but got Unknown
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_0610: Expected O, but got Unknown
		icontainer_1 = new Container();
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Magazines));
		TGV_Mags = new DarkTreeGridView();
		TS_Edit = new DarkToolStrip();
		TSB_AddMag = new ToolStripButton();
		TSB_RemoveMag = new ToolStripButton();
		TSB_AddRec = new ToolStripButton();
		TSB_RemoveRec = new ToolStripButton();
		ToolStripLabel1 = new ToolStripLabel();
		TSTB_RecCount = new ToolStripTextBox();
		ToolStripLabel2 = new ToolStripLabel();
		TSC_MagStatus = new ToolStripComboBox();
		Timer1 = new Timer(icontainer_1);
		Column_Magazine = new TreeGridColumn();
		Status = new TreeGridColumn();
		((ISupportInitialize)(object)TGV_Mags).BeginInit();
		((Control)TS_Edit).SuspendLayout();
		((Control)this).SuspendLayout();
		((DataGridView)TGV_Mags).AllowUserToAddRows = false;
		((DataGridView)TGV_Mags).AllowUserToDeleteRows = false;
		((DataGridView)TGV_Mags).AllowUserToOrderColumns = true;
		((Control)TGV_Mags).Anchor = (AnchorStyles)15;
		((DataGridView)TGV_Mags).BackgroundColor = Color.FromArgb(43, 43, 43);
		((DataGridView)TGV_Mags).BorderStyle = (BorderStyle)2;
		((DataGridView)TGV_Mags).CellBorderStyle = (DataGridViewCellBorderStyle)4;
		((DataGridView)TGV_Mags).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)TGV_Mags).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)TGV_Mags).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[2]
		{
			(DataGridViewColumn)Column_Magazine,
			(DataGridViewColumn)Status
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)TGV_Mags).DefaultCellStyle = val2;
		((DataGridView)TGV_Mags).EditMode = (DataGridViewEditMode)4;
		((DataGridView)TGV_Mags).EnableHeadersVisualStyles = false;
		TGV_Mags.ImageList = null;
		((Control)TGV_Mags).Location = new Point(0, 0);
		((Control)TGV_Mags).Name = "TGV_Mags";
		((DataGridView)TGV_Mags).RowHeadersVisible = false;
		((DataGridView)TGV_Mags).SelectionMode = (DataGridViewSelectionMode)1;
		TGV_Mags.ShowLines = false;
		((Control)TGV_Mags).Size = new Size(815, 300);
		((Control)TGV_Mags).TabIndex = 5;
		((ToolStrip)TS_Edit).AutoSize = false;
		((ToolStrip)TS_Edit).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)TS_Edit).Dock = (DockStyle)2;
		((ToolStrip)TS_Edit).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)TS_Edit).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)TS_Edit).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[8]
		{
			(ToolStripItem)TSB_AddMag,
			(ToolStripItem)TSB_RemoveMag,
			(ToolStripItem)TSB_AddRec,
			(ToolStripItem)TSB_RemoveRec,
			(ToolStripItem)ToolStripLabel1,
			(ToolStripItem)TSTB_RecCount,
			(ToolStripItem)ToolStripLabel2,
			(ToolStripItem)TSC_MagStatus
		});
		((Control)TS_Edit).Location = new Point(0, 303);
		((Control)TS_Edit).Name = "TS_Edit";
		((Control)TS_Edit).Padding = new Padding(5, 0, 1, 0);
		((Control)TS_Edit).Size = new Size(815, 25);
		((Control)TS_Edit).TabIndex = 6;
		((Control)TS_Edit).Text = "ToolStrip1";
		((ToolStripItem)TSB_AddMag).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_AddMag).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_AddMag).Image = (Image)componentResourceManager.GetObject("TSB_AddMag.Image");
		((ToolStripItem)TSB_AddMag).ImageScaling = (ToolStripItemImageScaling)0;
		((ToolStripItem)TSB_AddMag).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_AddMag).Name = "TSB_AddMag";
		((ToolStripItem)TSB_AddMag).Size = new Size(103, 22);
		((ToolStripItem)TSB_AddMag).Text = "Add Magazine";
		((ToolStripItem)TSB_RemoveMag).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_RemoveMag).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_RemoveMag).Image = (Image)componentResourceManager.GetObject("TSB_RemoveMag.Image");
		((ToolStripItem)TSB_RemoveMag).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_RemoveMag).Name = "TSB_RemoveMag";
		((ToolStripItem)TSB_RemoveMag).Size = new Size(124, 22);
		((ToolStripItem)TSB_RemoveMag).Text = "Remove Magazine";
		((ToolStripItem)TSB_AddRec).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_AddRec).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_AddRec).Image = (Image)componentResourceManager.GetObject("TSB_AddRec.Image");
		((ToolStripItem)TSB_AddRec).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_AddRec).Name = "TSB_AddRec";
		((ToolStripItem)TSB_AddRec).Size = new Size(101, 22);
		((ToolStripItem)TSB_AddRec).Text = "Add Weapons";
		((ToolStripItem)TSB_RemoveRec).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_RemoveRec).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_RemoveRec).Image = (Image)componentResourceManager.GetObject("TSB_RemoveRec.Image");
		((ToolStripItem)TSB_RemoveRec).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_RemoveRec).Name = "TSB_RemoveRec";
		((ToolStripItem)TSB_RemoveRec).Size = new Size(122, 22);
		((ToolStripItem)TSB_RemoveRec).Text = "Remove Weapons";
		((ToolStripItem)ToolStripLabel1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripLabel1).Name = "ToolStripLabel1";
		((ToolStripItem)ToolStripLabel1).Size = new Size(90, 22);
		((ToolStripItem)ToolStripLabel1).Text = "Weapon Count:";
		((ToolStripControlHost)TSTB_RecCount).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripControlHost)TSTB_RecCount).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSTB_RecCount).Name = "TSTB_RecCount";
		((ToolStripControlHost)TSTB_RecCount).Size = new Size(50, 25);
		((ToolStripItem)ToolStripLabel2).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripLabel2).Name = "ToolStripLabel2";
		((ToolStripItem)ToolStripLabel2).Size = new Size(42, 22);
		((ToolStripItem)ToolStripLabel2).Text = "Status:";
		((ToolStripControlHost)TSC_MagStatus).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripControlHost)TSC_MagStatus).ForeColor = Color.FromArgb(220, 220, 220);
		TSC_MagStatus.Items.AddRange(new object[5] { "Operational", "Damaged (Light)", "Damaged (Medium)", "Damaged (Heavy)", "Destroyed" });
		((ToolStripItem)TSC_MagStatus).Name = "TSC_MagStatus";
		((ToolStripControlHost)TSC_MagStatus).Size = new Size(121, 25);
		Timer1.Interval = 1000;
		((DataGridViewColumn)Column_Magazine).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Column_Magazine).DataPropertyName = "Name";
		Column_Magazine.DefaultNodeImage = null;
		((DataGridViewColumn)Column_Magazine).HeaderText = "Magazine";
		((DataGridViewColumn)Column_Magazine).Name = "Magazine";
		((DataGridViewColumn)Column_Magazine).Resizable = (DataGridViewTriState)1;
		((DataGridViewTextBoxColumn)Column_Magazine).SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Status).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		Status.DefaultNodeImage = null;
		((DataGridViewColumn)Status).HeaderText = "Status";
		((DataGridViewColumn)Status).Name = "Status";
		((DataGridViewColumn)Status).ReadOnly = true;
		((DataGridViewTextBoxColumn)Status).SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Status).Width = 43;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(815, 328);
		((Control)this).Controls.Add((Control)(object)TS_Edit);
		((Control)this).Controls.Add((Control)(object)TGV_Mags);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "Magazines";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Magazines";
		((ISupportInitialize)(object)TGV_Mags).EndInit();
		((Control)TS_Edit).ResumeLayout(false);
		((Control)TS_Edit).PerformLayout();
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
		EventHandler eventHandler = method_20;
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

	private void method_2()
	{
		bool_5 = true;
	}

	private void method_3()
	{
		bool_5 = false;
		List<string> list = new List<string>();
		int num = -1;
		if (((BaseCollection)((DataGridView)TGV_Mags).SelectedRows).Count > 0 && ((DataGridViewBand)((DataGridView)TGV_Mags).SelectedRows[0]).Tag != null)
		{
			num = ((DataGridViewBand)((DataGridView)TGV_Mags).SelectedRows[0]).Index;
		}
		foreach (TreeGridNode item2 in Module1.AllNodes((TreeGridView)TGV_Mags))
		{
			if (item2 == null || ((DataGridViewBand)item2).Tag == null || !item2.IsExpanded)
			{
				continue;
			}
			ScenarioObject scenarioObject = (ScenarioObject)((DataGridViewBand)item2).Tag;
			string item = scenarioObject.ObjectID;
			if ((object)scenarioObject.GetType() == typeof(Magazine))
			{
				Magazine magazine = (Magazine)scenarioObject;
				if (magazine.DBID == 0)
				{
					item = magazine.Name;
				}
			}
			list.Add(item);
		}
		method_13();
		int num2 = -1;
		if (num > 0 && TGV_Mags.Nodes.Count > 0)
		{
			((DataGridViewRow)TGV_Mags.Nodes[0]).Selected = false;
		}
		foreach (TreeGridNode node in TGV_Mags.Nodes)
		{
			if (node == null || ((DataGridViewBand)node).Tag == null)
			{
				continue;
			}
			num2++;
			if (num2 == num)
			{
				((DataGridViewRow)node).Selected = true;
				SelectedMag = (Magazine)((DataGridViewBand)node).Tag;
				num = -1;
			}
			ScenarioObject scenarioObject = (ScenarioObject)((DataGridViewBand)node).Tag;
			if (!list.Contains(scenarioObject.ObjectID) && ((object)scenarioObject.GetType() != typeof(Magazine) || !list.Contains(scenarioObject.Name)))
			{
				continue;
			}
			node.Expand();
			if (num < 0)
			{
				continue;
			}
			foreach (TreeGridNode node2 in node.Nodes)
			{
				num2++;
				if (num2 == num)
				{
					SelectedMag = (Magazine)((DataGridViewBand)node2.Parent).Tag;
					weaponRec_0 = (WeaponRec)((DataGridViewBand)node2).Tag;
					((DataGridViewRow)node2).Selected = true;
					num = -1;
					break;
				}
			}
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		if (bool_5)
		{
			method_3();
		}
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
					((Form)this).Activate();
					result = 1;
				}
				return (byte)result != 0;
			}
		}
		return false;
	}

	public void RefreshForm()
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
	}

	private void Magazines_Load(object sender, EventArgs e)
	{
		bool_4 = Client.Realtime;
		if (bool_4)
		{
			Timer1.Start();
		}
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		vmethod_1(TSC_MagStatus.ComboBox);
		PlatformComponent.StatusChanged += method_12;
		WeaponRec.CurrentLoadChanged += method_11;
		Magazine.MagazineWeaponRecordAdded += method_9;
		Magazine.MagazineWeaponRecordRemoved += method_10;
		Platform.PlatformMagazinesAdded += method_8;
		Platform.PlatformMagazinesRemoved += method_7;
		ActiveUnit.ActiveUnitMountsAdded += method_6;
		ActiveUnit.ActiveUnitMountsRemoved += method_5;
	}

	private void method_5(string string_0, string string_1)
	{
		if (!bool_4)
		{
			method_13();
		}
		else
		{
			method_2();
		}
	}

	private void method_6(string string_0, string string_1)
	{
		if (!bool_4)
		{
			method_13();
		}
		else
		{
			method_2();
		}
	}

	private void method_7(string string_0, string string_1)
	{
		if (!bool_4)
		{
			method_13();
		}
		else
		{
			method_2();
		}
	}

	private void method_8(string string_0, string string_1)
	{
		if (!bool_4)
		{
			method_13();
		}
		else
		{
			method_2();
		}
	}

	private void Magazines_Shown(object sender, EventArgs e)
	{
		((Control)TS_Edit).Visible = Client.AllowEditModeActions;
		((ToolStripItem)TSB_AddRec).Enabled = false;
		((ToolStripItem)TSB_RemoveRec).Enabled = false;
		method_13();
		((Form)this).Text = "Magazine status - " + SelectedUnit.Name;
	}

	private void method_9(string string_0, string string_1)
	{
		using IEnumerator<TreeGridNode> enumerator = TGV_Mags.Nodes.GetEnumerator();
		_Closure$__83-0 closure$__83- = default(_Closure$__83-0);
		Magazine magazine;
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			closure$__83- = new _Closure$__83-0(closure$__83-);
			closure$__83-.$VB$Me = this;
			closure$__83-.$VB$Local_theNode = enumerator.Current;
			if (((DataGridViewBand)closure$__83-.$VB$Local_theNode).Tag != null && (object)((DataGridViewBand)closure$__83-.$VB$Local_theNode).Tag.GetType() == typeof(Magazine))
			{
				magazine = (Magazine)((DataGridViewBand)closure$__83-.$VB$Local_theNode).Tag;
				if (Operators.CompareString(magazine.ObjectID, string_0, true) == 0)
				{
					break;
				}
			}
		}
		using List<WeaponRec>.Enumerator enumerator2 = magazine.Weapons.GetEnumerator();
		_Closure$__83-1 closure$__83-2 = default(_Closure$__83-1);
		do
		{
			if (enumerator2.MoveNext())
			{
				closure$__83-2 = new _Closure$__83-1(closure$__83-2);
				closure$__83-2.$VB$NonLocal_$VB$Closure_2 = closure$__83-;
				closure$__83-2.$VB$Local_theRec = enumerator2.Current;
				continue;
			}
			return;
		}
		while (Operators.CompareString(closure$__83-2.$VB$Local_theRec.ObjectID, string_1, true) != 0);
		if (bool_4)
		{
			method_2();
		}
		else
		{
			((Control)this).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__83-2._Lambda$__0));
		}
	}

	private void method_10(string string_0, string string_1)
	{
		using IEnumerator<TreeGridNode> enumerator = TGV_Mags.Nodes.GetEnumerator();
		_Closure$__84-0 closure$__84- = default(_Closure$__84-0);
		do
		{
			if (enumerator.MoveNext())
			{
				closure$__84- = new _Closure$__84-0(closure$__84-);
				closure$__84-.$VB$Local_theNode = enumerator.Current;
				continue;
			}
			return;
		}
		while (((DataGridViewBand)closure$__84-.$VB$Local_theNode).Tag == null || (object)((DataGridViewBand)closure$__84-.$VB$Local_theNode).Tag.GetType() != typeof(Magazine) || Operators.CompareString(((Magazine)((DataGridViewBand)closure$__84-.$VB$Local_theNode).Tag).ObjectID, string_0, true) != 0);
		using IEnumerator<TreeGridNode> enumerator2 = closure$__84-.$VB$Local_theNode.Nodes.GetEnumerator();
		_Closure$__84-1 closure$__84-2 = default(_Closure$__84-1);
		do
		{
			if (enumerator2.MoveNext())
			{
				closure$__84-2 = new _Closure$__84-1(closure$__84-2);
				closure$__84-2.$VB$NonLocal_$VB$Closure_2 = closure$__84-;
				closure$__84-2.$VB$Local_theRecNode = enumerator2.Current;
				continue;
			}
			return;
		}
		while (((DataGridViewBand)closure$__84-2.$VB$Local_theRecNode).Tag == null || (object)((DataGridViewBand)closure$__84-2.$VB$Local_theRecNode).Tag.GetType() != typeof(WeaponRec) || Operators.CompareString(((WeaponRec)((DataGridViewBand)closure$__84-2.$VB$Local_theRecNode).Tag).ObjectID, string_1, true) != 0);
		if (!bool_4)
		{
			((Control)this).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__84-2._Lambda$__0));
		}
		else
		{
			method_2();
		}
	}

	private void method_11(string string_0)
	{
		_Closure$__85-1 closure$__85- = new _Closure$__85-1(closure$__85-);
		closure$__85-.$VB$Me = this;
		if (SelectedUnit == null)
		{
			return;
		}
		using IEnumerator<TreeGridNode> enumerator = TGV_Mags.Nodes.GetEnumerator();
		TreeGridNode current;
		do
		{
			if (enumerator.MoveNext())
			{
				current = enumerator.Current;
				continue;
			}
			return;
		}
		while (((DataGridViewBand)current).Tag == null || (object)((DataGridViewBand)current).Tag.GetType() != typeof(Magazine));
		_ = (Magazine)((DataGridViewBand)current).Tag;
		using IEnumerator<TreeGridNode> enumerator2 = current.Nodes.GetEnumerator();
		_Closure$__85-0 closure$__85-2 = default(_Closure$__85-0);
		while (true)
		{
			if (!enumerator2.MoveNext())
			{
				return;
			}
			closure$__85-2 = new _Closure$__85-0(closure$__85-2);
			closure$__85-2.$VB$NonLocal_$VB$Closure_2 = closure$__85-;
			closure$__85-2.$VB$Local_theRecNode = enumerator2.Current;
			if (((DataGridViewBand)closure$__85-2.$VB$Local_theRecNode).Tag != null && (object)((DataGridViewBand)closure$__85-2.$VB$Local_theRecNode).Tag.GetType() == typeof(WeaponRec))
			{
				closure$__85-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theRec = (WeaponRec)((DataGridViewBand)closure$__85-2.$VB$Local_theRecNode).Tag;
				if (Operators.CompareString(closure$__85-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theRec.ObjectID, string_0, true) == 0)
				{
					break;
				}
			}
		}
		if (!bool_4)
		{
			((Control)this).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__85-2._Lambda$__0));
		}
		else
		{
			method_2();
		}
	}

	private void method_12(PlatformComponent platformComponent_0)
	{
		using IEnumerator<TreeGridNode> enumerator = TGV_Mags.Nodes.GetEnumerator();
		_Closure$__86-0 closure$__86- = default(_Closure$__86-0);
		_Closure$__86-1 closure$__86-2 = default(_Closure$__86-1);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			closure$__86- = new _Closure$__86-0(closure$__86-);
			closure$__86-.$VB$Me = this;
			closure$__86-.$VB$Local_theNode = enumerator.Current;
			if (((DataGridViewBand)closure$__86-.$VB$Local_theNode).Tag != null && (object)((DataGridViewBand)closure$__86-.$VB$Local_theNode).Tag.GetType() == typeof(Magazine))
			{
				closure$__86-2 = new _Closure$__86-1(closure$__86-2);
				closure$__86-2.$VB$NonLocal_$VB$Closure_2 = closure$__86-;
				closure$__86-2.$VB$Local_theMag = (Magazine)((DataGridViewBand)closure$__86-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theNode).Tag;
				if (Operators.CompareString(closure$__86-2.$VB$Local_theMag.ObjectID, platformComponent_0.ObjectID, true) == 0)
				{
					break;
				}
			}
		}
		if (!bool_4)
		{
			((Control)this).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__86-2._Lambda$__0));
		}
		else
		{
			method_2();
		}
	}

	private void method_13()
	{
		if (SelectedUnit == null)
		{
			return;
		}
		TGV_Mags.Nodes.Clear();
		if (bool_4)
		{
			foreach (Mount mount in SelectedUnit.Mounts)
			{
				if (mount.MountMagazine.Weapons.Count > 0)
				{
					method_14(mount.MountMagazine);
				}
			}
			Magazine[] sharedMagazines = SelectedUnit.SharedMagazines;
			foreach (Magazine magazine_ in sharedMagazines)
			{
				method_14(magazine_);
			}
			if (TGV_Mags.Nodes.Count > 0)
			{
				SelectedMag = (Magazine)((DataGridViewBand)TGV_Mags.Nodes[0]).Tag;
			}
			((ToolStripItem)TSB_AddMag).Enabled = false;
			((ToolStripItem)TSB_RemoveMag).Enabled = false;
			((ToolStripItem)TSB_AddRec).Enabled = false;
			((ToolStripItem)TSB_RemoveRec).Enabled = false;
			return;
		}
		Task.Factory.StartNew([SpecialName] () =>
		{
			using (List<Mount>.Enumerator enumerator2 = SelectedUnit.Mounts.GetEnumerator())
			{
				_Closure$__87-0 closure$__87- = default(_Closure$__87-0);
				while (enumerator2.MoveNext())
				{
					closure$__87- = new _Closure$__87-0(closure$__87-);
					closure$__87-.$VB$Me = this;
					closure$__87-.$VB$Local_theMount = enumerator2.Current;
					if (closure$__87-.$VB$Local_theMount.MountMagazine.Weapons.Count > 0)
					{
						((Control)this).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__87-._Lambda$__1));
					}
				}
			}
			Magazine[] sharedMagazines2 = SelectedUnit.SharedMagazines;
			_Closure$__87-1 closure$__87-2 = default(_Closure$__87-1);
			for (int j = 0; j < sharedMagazines2.Length; j = checked(j + 1))
			{
				closure$__87-2 = new _Closure$__87-1(closure$__87-2);
				closure$__87-2.$VB$Me = this;
				closure$__87-2.$VB$Local_theMag = sharedMagazines2[j];
				((Control)this).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__87-2._Lambda$__2));
			}
			((Control)this).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				if (TGV_Mags.Nodes.Count <= 0)
				{
					((ToolStripItem)TSB_AddRec).Enabled = false;
					((ToolStripItem)TSB_RemoveRec).Enabled = false;
				}
				else
				{
					SelectedMag = (Magazine)((DataGridViewBand)TGV_Mags.Nodes[0]).Tag;
					((ToolStripItem)TSB_AddRec).Enabled = true;
					((ToolStripItem)TSB_RemoveRec).Enabled = true;
				}
				((ToolStripItem)TSB_AddMag).Visible = !SelectedUnit.IsGroup;
			}));
		});
	}

	private void method_14(Magazine magazine_0)
	{
		TreeGridNode treeGridNode = TGV_Mags.Nodes.Add("New Node");
		method_15(treeGridNode, magazine_0);
		if (magazine_0.Weapons.Count <= 0)
		{
			return;
		}
		if (!bool_4)
		{
			treeGridNode.Nodes.Add("Temp");
			return;
		}
		List<WeaponRec> list = magazine_0.Weapons.Where([SpecialName] (WeaponRec theWR) => theWR.CurrentLoad > 0).OrderBy([SpecialName] (WeaponRec theWR) => theWR.get_ReferenceWeapon(Client.CurrentScenario).Name, new NaturalSortComparer<string[]>()).ToList();
		List<WeaponRec> list2 = magazine_0.Weapons.Where([SpecialName] (WeaponRec theWR) => theWR.CurrentLoad == 0).OrderBy([SpecialName] (WeaponRec theWR) => theWR.get_ReferenceWeapon(Client.CurrentScenario).Name, new NaturalSortComparer<string[]>()).ToList();
		foreach (WeaponRec item in list)
		{
			method_26(treeGridNode, item);
		}
		foreach (WeaponRec item2 in list2)
		{
			method_26(treeGridNode, item2);
		}
	}

	private void method_15(TreeGridNode treeGridNode_0, Magazine magazine_0)
	{
		string text = ((!SelectedUnit.IsGroup || !((Group)SelectedUnit).IsLandInstallation) ? Misc.RemoveHiddenString(magazine_0.Name) : (Misc.RemoveHiddenString(magazine_0.Name) + " [" + magazine_0.ParentPlatform.Name + "]"));
		Color componentDamageColor = GetComponentDamageColor(magazine_0);
		((DataGridViewRow)treeGridNode_0).SetValues(new object[2]
		{
			text,
			magazine_0.Status.ToString()
		});
		((DataGridViewRow)treeGridNode_0).DefaultCellStyle.ForeColor = componentDamageColor;
		((DataGridViewBand)treeGridNode_0).Tag = magazine_0;
	}

	private void method_16(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.RowIndex != -1 && !Information.IsNothing((object)TGV_Mags.CurrentNode))
		{
			if ((object)((DataGridViewBand)TGV_Mags.CurrentNode).Tag.GetType() == typeof(Magazine))
			{
				SelectedMag = (Magazine)((DataGridViewBand)TGV_Mags.CurrentNode).Tag;
				((ToolStripItem)TSB_RemoveRec).Enabled = false;
				((ToolStripControlHost)TSTB_RecCount).Enabled = false;
				((ToolStripControlHost)TSC_MagStatus).Enabled = true;
			}
			if ((object)((DataGridViewBand)TGV_Mags.CurrentNode).Tag.GetType() == typeof(WeaponRec))
			{
				SelectedMag = (Magazine)((DataGridViewBand)TGV_Mags.CurrentNode.Parent).Tag;
				weaponRec_0 = (WeaponRec)((DataGridViewBand)TGV_Mags.CurrentNode).Tag;
				((ToolStripItem)TSB_RemoveRec).Enabled = true;
				((ToolStripControlHost)TSTB_RecCount).Enabled = true;
				((ToolStripControlHost)TSC_MagStatus).Enabled = false;
			}
			switch (SelectedMag.Status)
			{
			case PlatformComponent._ComponentStatus.Operational:
				TSC_MagStatus.SelectedIndex = 0;
				break;
			case PlatformComponent._ComponentStatus.Damaged:
				TSC_MagStatus.SelectedIndex = 1;
				break;
			case PlatformComponent._ComponentStatus.Destroyed:
				TSC_MagStatus.SelectedIndex = 2;
				break;
			}
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		MyProject.Forms.AddWeaponRecord.FormThatCalledMe = (Form)(object)this;
		((Control)MyProject.Forms.AddWeaponRecord).Show();
	}

	private void method_18(object sender, EventArgs e)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Invalid comparison between Unknown and I4
		switch (((BaseCollection)((DataGridView)TGV_Mags).SelectedRows).Count)
		{
		case 1:
			SelectedMag.Weapons.Remove(weaponRec_0);
			return;
		case 0:
			return;
		}
		List<DataGridViewRow> list = new List<DataGridViewRow>();
		foreach (DataGridViewRow item in (BaseCollection)((DataGridView)TGV_Mags).SelectedRows)
		{
			DataGridViewRow val = item;
			if ((object)((DataGridViewBand)val).Tag.GetType() == typeof(WeaponRec))
			{
				list.Add(val);
			}
		}
		if ((int)DarkMessageBox.ShowWarning("Are you sure?", "Remove " + Conversions.ToString(list.Count) + " weapon records", DarkDialogButton.OkCancel) != 1)
		{
			return;
		}
		foreach (DataGridViewRow item2 in list)
		{
			SelectedMag.Weapons.Remove((WeaponRec)((DataGridViewBand)item2).Tag);
		}
	}

	private void method_19(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)weaponRec_0) || !((Operators.CompareString(((ToolStripControlHost)TSTB_RecCount).Text, "", true) != 0) & Versioned.IsNumeric((object)((ToolStripControlHost)TSTB_RecCount).Text)))
		{
			return;
		}
		int num = Conversions.ToInteger(((ToolStripControlHost)TSTB_RecCount).Text);
		if (num < 0)
		{
			num = 0;
		}
		if (num > weaponRec_0.MaxLoad)
		{
			num = weaponRec_0.MaxLoad;
		}
		if ((double)num / (double)weaponRec_0.Multiple > (double)weaponRec_0.MaxLoad)
		{
			num = weaponRec_0.MaxLoad;
		}
		weaponRec_0.CurrentLoad = 0;
		Magazine selectedMag = SelectedMag;
		int theQty_FullyLoadedCells = 0;
		int theQty_PartiallyLoadedCells = 0;
		int num2 = selectedMag.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells);
		if ((double)num / (double)weaponRec_0.Multiple > (double)(SelectedMag.Capacity - num2))
		{
			num = SelectedMag.Capacity - num2 * weaponRec_0.Multiple;
		}
		if (num < 0)
		{
			num = 0;
		}
		weaponRec_0.CurrentLoad = num;
		foreach (TreeGridNode node in TGV_Mags.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewBand)node2).Tag == weaponRec_0)
				{
					((DataGridViewRow)node2).SetValues(new object[1] { Conversions.ToString(weaponRec_0.CurrentLoad) + "/" + Conversions.ToString(weaponRec_0.MaxLoad) + " " + Misc.RemoveHiddenString(Strings.Trim(weaponRec_0.get_ReferenceWeapon(Client.CurrentScenario).Name)) });
					return;
				}
			}
		}
	}

	private void method_20(object sender, EventArgs e)
	{
		int num = 5;
		while (true)
		{
			int selectedIndex = vmethod_0().SelectedIndex;
			num = 13;
			while (true)
			{
				if (num != 13)
				{
					if (num != 994)
					{
						return;
					}
					switch (num)
					{
					default:
						continue;
					case 5:
						break;
					case 2:
						return;
					case 6:
						return;
					case 3:
						return;
					case 4:
						return;
					case 1:
						return;
					case 0:
						return;
					}
					break;
				}
				switch (selectedIndex)
				{
				case 0:
					SelectedMag.MakeOperational(GiveUserFeedback: true);
					break;
				case 1:
					SelectedMag.Damage(PlatformComponent._DamageSeverityFactor.Light);
					break;
				case 2:
					SelectedMag.Damage(PlatformComponent._DamageSeverityFactor.Medium);
					break;
				case 3:
					SelectedMag.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
					break;
				case 4:
					SelectedMag.Destroy(SelectedUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: true, Module_ActiveUnit.IsAimpointFacility(SelectedMag.ParentPlatform));
					break;
				}
				return;
			}
		}
	}

	private void Magazines_KeyDown(object sender, KeyEventArgs e)
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
		if ((int)e.KeyCode == 116 && ((Control)this).Visible)
		{
			((Form)this).Close();
			return;
		}
		if (bool_3 && ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
		if (!bool_3 && (e.KeyValue != 32 || !((Control)this).Visible))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void Magazines_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_21(object sender, EventArgs e)
	{
		bool_3 = true;
	}

	private void method_22(object sender, EventArgs e)
	{
		bool_3 = false;
		((ToolStripItem)ToolStripLabel2).Select();
	}

	private void Magazines_FormClosed(object sender, FormClosedEventArgs e)
	{
		Timer1.Stop();
		PlatformComponent.StatusChanged -= method_12;
		WeaponRec.CurrentLoadChanged -= method_11;
		Magazine.MagazineWeaponRecordAdded -= method_9;
		Magazine.MagazineWeaponRecordRemoved -= method_10;
		Platform.PlatformMagazinesAdded -= method_8;
		Platform.PlatformMagazinesRemoved -= method_7;
		ActiveUnit.ActiveUnitMountsAdded -= method_6;
		ActiveUnit.ActiveUnitMountsRemoved -= method_5;
	}

	private void method_23(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)SelectedUnit) && !SelectedUnit.IsGroup)
		{
			MyProject.Forms.AddMagazine.FormThatCalledMe = (Form)(object)this;
			((Control)MyProject.Forms.AddMagazine).Show();
		}
	}

	private void method_24(object sender, EventArgs e)
	{
		if (!(!Information.IsNothing((object)SelectedUnit) & !Information.IsNothing((object)SelectedMag)))
		{
			return;
		}
		if (SelectedUnit.IsPlatform)
		{
			((Platform)SelectedUnit).RemoveSharedMagazine(SelectedMag);
		}
		else
		{
			if (!SelectedUnit.IsGroup)
			{
				return;
			}
			using IEnumerator<ActiveUnit> enumerator = ((Group)SelectedUnit).Units.Values.GetEnumerator();
			ActiveUnit current;
			do
			{
				if (enumerator.MoveNext())
				{
					current = enumerator.Current;
					continue;
				}
				return;
			}
			while (!current.IsPlatform || !((Platform)current).Magazines.Contains(SelectedMag));
			((Platform)current).RemoveSharedMagazine(SelectedMag);
		}
	}

	private void method_25(object sender, ExpandingEventArgs e)
	{
		if (bool_4 || ((DataGridViewBand)e.Node).Tag == null || (object)((DataGridViewBand)e.Node).Tag.GetType() != typeof(Magazine))
		{
			return;
		}
		_Closure$__102-0 arg = default(_Closure$__102-0);
		_Closure$__102-0 CS$<>8__locals11 = new _Closure$__102-0(arg);
		CS$<>8__locals11.$VB$Me = this;
		CS$<>8__locals11.$VB$Local_MagNode = e.Node;
		Magazine magazine = (Magazine)((DataGridViewBand)e.Node).Tag;
		CS$<>8__locals11.$VB$Local_MagNode.Nodes.Clear();
		CS$<>8__locals11.$VB$Local_WeapRecs_NotEmpty = magazine.Weapons.Where([SpecialName] (WeaponRec theWR) => theWR.CurrentLoad > 0).OrderBy([SpecialName] (WeaponRec theWR) => theWR.get_ReferenceWeapon(Client.CurrentScenario)?.Name, new NaturalSortComparer<string[]>()).ToList();
		CS$<>8__locals11.$VB$Local_WeapRecs_Empty = magazine.Weapons.Where([SpecialName] (WeaponRec theWR) => theWR.CurrentLoad == 0).OrderBy([SpecialName] (WeaponRec theWR) => theWR.get_ReferenceWeapon(Client.CurrentScenario)?.Name, new NaturalSortComparer<string[]>()).ToList();
		Task.Factory.StartNew([SpecialName] () =>
		{
			using (List<WeaponRec>.Enumerator enumerator = CS$<>8__locals11.$VB$Local_WeapRecs_NotEmpty.GetEnumerator())
			{
				_Closure$__102-1 closure$__102- = default(_Closure$__102-1);
				while (enumerator.MoveNext())
				{
					closure$__102- = new _Closure$__102-1(closure$__102-);
					closure$__102-.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals11;
					closure$__102-.$VB$Local_theRec = enumerator.Current;
					((Control)CS$<>8__locals11.$VB$Me).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__102-._Lambda$__5));
				}
			}
			using List<WeaponRec>.Enumerator enumerator2 = CS$<>8__locals11.$VB$Local_WeapRecs_Empty.GetEnumerator();
			_Closure$__102-2 closure$__102-2 = default(_Closure$__102-2);
			while (enumerator2.MoveNext())
			{
				closure$__102-2 = new _Closure$__102-2(closure$__102-2);
				closure$__102-2.$VB$NonLocal_$VB$Closure_3 = CS$<>8__locals11;
				closure$__102-2.$VB$Local_theRec = enumerator2.Current;
				((Control)CS$<>8__locals11.$VB$Me).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__102-2._Lambda$__6));
			}
		});
	}

	private void method_26(TreeGridNode treeGridNode_0, WeaponRec weaponRec_1)
	{
		((DataGridViewBand)treeGridNode_0.Nodes.Add(Conversions.ToString(weaponRec_1.CurrentLoad) + "/" + Conversions.ToString(weaponRec_1.MaxLoad) + " " + Misc.RemoveHiddenString(Strings.Trim(weaponRec_1.get_ReferenceWeapon(SelectedUnit.ParentScen)?.Name)))).Tag = weaponRec_1;
	}

	private void Magazines_Closed(object sender, EventArgs e)
	{
		PlatformComponent.StatusChanged -= method_12;
		WeaponRec.CurrentLoadChanged -= method_11;
		Magazine.MagazineWeaponRecordAdded -= method_9;
		Magazine.MagazineWeaponRecordRemoved -= method_10;
	}

	private void method_27(object sender, CollapsingEventArgs e)
	{
		if (!bool_4)
		{
			e.Node.Nodes.Clear();
			e.Node.Nodes.Add("Temp");
		}
	}

	static Magazines()
	{
		Class72.smethod_20();
	}
}
