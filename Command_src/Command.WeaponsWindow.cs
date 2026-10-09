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
using Command_Core.DAL;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class WeaponsWindow : DarkSecondaryFormBase
{
	[CompilerGenerated]
	internal sealed class _Closure$__121-0
	{
		public TreeGridNode $VB$Local_theNode;

		public _Closure$__121-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__121-0(_Closure$__121-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theNode = arg0.$VB$Local_theNode;
			}
		}

		static _Closure$__121-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__121-1
	{
		public Mount $VB$Local_theMount;

		public WeaponsWindow $VB$Me;

		public _Closure$__121-1(_Closure$__121-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theMount = arg0.$VB$Local_theMount;
			}
		}

		static _Closure$__121-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__121-2
	{
		public WeaponRec $VB$Local_theRec;

		public _Closure$__121-0 $VB$NonLocal_$VB$Closure_3;

		public _Closure$__121-2(_Closure$__121-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theRec = arg0.$VB$Local_theRec;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Me.method_13($VB$NonLocal_$VB$Closure_3.$VB$Local_theNode, $VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMount, $VB$Local_theRec);
			if (!$VB$NonLocal_$VB$Closure_3.$VB$Local_theNode.IsExpanded)
			{
				$VB$NonLocal_$VB$Closure_3.$VB$Local_theNode.Expand();
			}
		}

		static _Closure$__121-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__122-0
	{
		public TreeGridNode $VB$Local_theNode;

		public _Closure$__122-0(_Closure$__122-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theNode = arg0.$VB$Local_theNode;
			}
		}

		static _Closure$__122-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__122-1
	{
		public TreeGridNode $VB$Local_theRecNode;

		public _Closure$__122-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__122-1(_Closure$__122-1 arg0)
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

		static _Closure$__122-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__123-0
	{
		public TreeGridNode $VB$Local_theNode;

		public WeaponsWindow $VB$Me;

		public _Closure$__123-0(_Closure$__123-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theNode = arg0.$VB$Local_theNode;
			}
		}

		static _Closure$__123-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__123-1
	{
		public WeaponRec $VB$Local_theRec;

		public _Closure$__123-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__123-1(_Closure$__123-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theRec = arg0.$VB$Local_theRec;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$NonLocal_$VB$Closure_2.$VB$Me.method_14($VB$NonLocal_$VB$Closure_2.$VB$Local_theNode, $VB$Local_theRec);
			if (!$VB$NonLocal_$VB$Closure_2.$VB$Local_theNode.IsExpanded)
			{
				$VB$NonLocal_$VB$Closure_2.$VB$Local_theNode.Expand();
			}
		}

		static _Closure$__123-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__124-0
	{
		public TreeGridNode $VB$Local_theNode;

		public _Closure$__124-0(_Closure$__124-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theNode = arg0.$VB$Local_theNode;
			}
		}

		static _Closure$__124-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__124-1
	{
		public TreeGridNode $VB$Local_theRecNode;

		public _Closure$__124-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__124-1(_Closure$__124-1 arg0)
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

		static _Closure$__124-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__126-0
	{
		public TreeGridNode $VB$Local_theNode;

		public WeaponsWindow $VB$Me;

		public _Closure$__126-0(_Closure$__126-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theNode = arg0.$VB$Local_theNode;
			}
		}

		static _Closure$__126-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__126-1
	{
		public Mount $VB$Local_theMount;

		public _Closure$__126-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__126-1(_Closure$__126-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theMount = arg0.$VB$Local_theMount;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$NonLocal_$VB$Closure_2.$VB$Me.method_12($VB$NonLocal_$VB$Closure_2.$VB$Local_theNode, $VB$Local_theMount);
		}

		static _Closure$__126-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__127-0
	{
		public TreeGridNode $VB$Local_theNode;

		public _Closure$__127-2 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__127-0(_Closure$__127-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theNode = arg0.$VB$Local_theNode;
			}
		}

		static _Closure$__127-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__127-1
	{
		public TreeGridNode $VB$Local_theRecNode;

		public _Closure$__127-0 $VB$NonLocal_$VB$Closure_3;

		public _Closure$__127-1(_Closure$__127-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theRecNode = arg0.$VB$Local_theRecNode;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			if ((object)((DataGridViewBand)$VB$NonLocal_$VB$Closure_3.$VB$Local_theNode).Tag.GetType() == typeof(Mount))
			{
				$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Me.method_15($VB$Local_theRecNode, $VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_theRec, (Mount)((DataGridViewBand)$VB$NonLocal_$VB$Closure_3.$VB$Local_theNode).Tag);
			}
			if ((object)((DataGridViewBand)$VB$NonLocal_$VB$Closure_3.$VB$Local_theNode).Tag.GetType() == typeof(Loadout))
			{
				$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Me.method_16($VB$Local_theRecNode, $VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_theRec);
			}
		}

		static _Closure$__127-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__127-2
	{
		public WeaponRec $VB$Local_theRec;

		public WeaponsWindow $VB$Me;

		public _Closure$__127-2(_Closure$__127-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theRec = arg0.$VB$Local_theRec;
			}
		}

		static _Closure$__127-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__128-0
	{
		public TreeGridNode $VB$Local_theNode;

		public WeaponsWindow $VB$Me;

		public _Closure$__128-0(_Closure$__128-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theNode = arg0.$VB$Local_theNode;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$Me.TGV_Weapons.Nodes.Remove($VB$Local_theNode);
		}

		static _Closure$__128-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__129-0
	{
		public Mount $VB$Local_theMount;

		public WeaponsWindow $VB$Me;

		public _Closure$__129-0(_Closure$__129-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theMount = arg0.$VB$Local_theMount;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			TreeGridNode treeGridNode = $VB$Me.TGV_Weapons.Nodes.Add("New node");
			$VB$Me.method_12(treeGridNode, $VB$Local_theMount);
			foreach (WeaponRec mountWeapon in $VB$Local_theMount.MountWeapons)
			{
				$VB$Me.method_13(treeGridNode, $VB$Local_theMount, mountWeapon);
			}
			treeGridNode.Expand();
		}

		static _Closure$__129-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__141-0
	{
		public Mount $VB$Local_theMount;

		public _Closure$__141-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__141-0(_Closure$__141-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theMount = arg0.$VB$Local_theMount;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			using List<WeaponRec>.Enumerator enumerator = $VB$Local_theMount.MountWeapons.GetEnumerator();
			_Closure$__141-2 closure$__141- = default(_Closure$__141-2);
			while (enumerator.MoveNext())
			{
				closure$__141- = new _Closure$__141-2(closure$__141-)
				{
					$VB$NonLocal_$VB$Closure_3 = this,
					$VB$Local_theWeaponRec = enumerator.Current
				};
				((Control)$VB$NonLocal_$VB$Closure_2.$VB$Me).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__141-._Lambda$__1));
			}
		}

		static _Closure$__141-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__141-1
	{
		public ExpandingEventArgs $VB$Local_e;

		public WeaponsWindow $VB$Me;

		public _Closure$__141-1(_Closure$__141-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_e = arg0.$VB$Local_e;
			}
		}

		static _Closure$__141-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__141-2
	{
		public WeaponRec $VB$Local_theWeaponRec;

		public _Closure$__141-0 $VB$NonLocal_$VB$Closure_3;

		public _Closure$__141-2(_Closure$__141-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theWeaponRec = arg0.$VB$Local_theWeaponRec;
			}
		}

		[SpecialName]
		internal void _Lambda$__1()
		{
			$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Me.method_13($VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_e.Node, $VB$NonLocal_$VB$Closure_3.$VB$Local_theMount, $VB$Local_theWeaponRec);
		}

		static _Closure$__141-2()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TGV_Weapons")]
	private DarkTreeGridView _TGV_Weapons;

	[AccessedThroughProperty("ImageList1")]
	[CompilerGenerated]
	private ImageList imageList_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private Timer timer_0;

	[AccessedThroughProperty("TSB_AddRec")]
	[CompilerGenerated]
	private ToolStripButton _TSB_AddRec;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_RemoveRec")]
	private ToolStripButton YmgLdXuSvJb;

	[CompilerGenerated]
	[AccessedThroughProperty("TSTB_RecCount")]
	private ToolStripTextBox _TSTB_RecCount;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_AddMount")]
	private ToolStripButton _TSB_AddMount;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_RemoveMount")]
	private ToolStripButton _TSB_RemoveMount;

	[AccessedThroughProperty("TSB_ChangeWeaponCount")]
	[CompilerGenerated]
	private ToolStripButton _TSB_ChangeWeaponCount;

	[CompilerGenerated]
	private bool bool_2;

	private ActiveUnit activeUnit_0;

	private WeaponRec weaponRec_0;

	private Mount mount_0;

	private Loadout loadout_0;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool ljwLjeuCtEb;

	private bool bool_6;

	private bool bool_7;

	private Keys[] keys_0;

	[field: AccessedThroughProperty("Mount")]
	internal virtual TreeGridColumn Mount { get; set; }

	[field: AccessedThroughProperty("WeaponType")]
	internal virtual DataGridViewTextBoxColumn WeaponType { get; set; }

	[field: AccessedThroughProperty("Status")]
	internal virtual DataGridViewTextBoxColumn Status { get; set; }

	private virtual DarkTreeGridView TGV_Weapons
	{
		[CompilerGenerated]
		get
		{
			return _TGV_Weapons;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Expected O, but got Unknown
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			DataGridViewCellPaintingEventHandler val = new DataGridViewCellPaintingEventHandler(method_2);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(method_20);
			ExpandingEventHandler value2 = method_21;
			DataGridViewCellEventHandler val3 = new DataGridViewCellEventHandler(method_22);
			EventHandler eventHandler = method_25;
			DarkTreeGridView darkTreeGridView = _TGV_Weapons;
			if (darkTreeGridView != null)
			{
				((DataGridView)darkTreeGridView).CellPainting -= val;
				((DataGridView)darkTreeGridView).CellClick -= val2;
				darkTreeGridView.NodeExpanding -= value2;
				((DataGridView)darkTreeGridView).CellContentClick -= val3;
				((DataGridView)darkTreeGridView).SelectionChanged -= eventHandler;
			}
			_TGV_Weapons = value;
			darkTreeGridView = _TGV_Weapons;
			if (darkTreeGridView != null)
			{
				((DataGridView)darkTreeGridView).CellPainting += val;
				((DataGridView)darkTreeGridView).CellClick += val2;
				darkTreeGridView.NodeExpanding += value2;
				((DataGridView)darkTreeGridView).CellContentClick += val3;
				((DataGridView)darkTreeGridView).SelectionChanged += eventHandler;
			}
		}
	}

	internal virtual ImageList ImageList1
	{
		[CompilerGenerated]
		get
		{
			return imageList_0;
		}
		[CompilerGenerated]
		set
		{
			imageList_0 = value;
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
			EventHandler eventHandler = KoeLdhbFsnp;
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

	[field: AccessedThroughProperty("TS_Edit")]
	internal virtual DarkToolStrip TS_Edit { get; set; }

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
			EventHandler eventHandler = method_18;
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

	internal virtual ToolStripButton TSB_RemoveRec
	{
		[CompilerGenerated]
		get
		{
			return YmgLdXuSvJb;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			ToolStripButton val = YmgLdXuSvJb;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			YmgLdXuSvJb = value;
			val = YmgLdXuSvJb;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TSL_WeaponCount1")]
	internal virtual ToolStripLabel TSL_WeaponCount1 { get; set; }

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
			EventHandler eventHandler = method_26;
			EventHandler eventHandler2 = method_27;
			ToolStripTextBox val = _TSTB_RecCount;
			if (val != null)
			{
				((ToolStripControlHost)val).Enter -= eventHandler;
				((ToolStripControlHost)val).Leave -= eventHandler2;
			}
			_TSTB_RecCount = value;
			val = _TSTB_RecCount;
			if (val != null)
			{
				((ToolStripControlHost)val).Enter += eventHandler;
				((ToolStripControlHost)val).Leave += eventHandler2;
			}
		}
	}

	internal virtual ToolStripButton TSB_AddMount
	{
		[CompilerGenerated]
		get
		{
			return _TSB_AddMount;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = tqkLdilgjlu;
			ToolStripButton val = _TSB_AddMount;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_AddMount = value;
			val = _TSB_AddMount;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_RemoveMount
	{
		[CompilerGenerated]
		get
		{
			return _TSB_RemoveMount;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_23;
			ToolStripButton val = _TSB_RemoveMount;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_RemoveMount = value;
			val = _TSB_RemoveMount;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TSL_WeaponCount2")]
	internal virtual ToolStripLabel TSL_WeaponCount2 { get; set; }

	internal virtual ToolStripButton TSB_ChangeWeaponCount
	{
		[CompilerGenerated]
		get
		{
			return _TSB_ChangeWeaponCount;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_24;
			ToolStripButton val = _TSB_ChangeWeaponCount;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_ChangeWeaponCount = value;
			val = _TSB_ChangeWeaponCount;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator1")]
	internal virtual ToolStripSeparator ToolStripSeparator1 { get; set; }

	[field: AccessedThroughProperty("ToolStripSeparator2")]
	internal virtual ToolStripSeparator ToolStripSeparator2 { get; set; }

	[field: AccessedThroughProperty("Column1")]
	internal virtual TreeGridColumn Column1 { get; set; }

	[field: AccessedThroughProperty("Type")]
	internal virtual DataGridViewTextBoxColumn Type { get; set; }

	[field: AccessedThroughProperty("TimeToFire")]
	internal virtual DataGridViewTextBoxColumn TimeToFire { get; set; }

	[field: AccessedThroughProperty("Column3")]
	internal virtual DataGridViewTextBoxColumn Column3 { get; set; }

	[field: AccessedThroughProperty("ReloadPriority")]
	internal virtual DataGridViewCheckBoxColumn ReloadPriority { get; set; }

	[field: AccessedThroughProperty("ShowArcs")]
	internal virtual DataGridViewCheckBoxColumn ShowArcs { get; set; }

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

	public ActiveUnit theSelectedUnit
	{
		get
		{
			return activeUnit_0;
		}
		set
		{
			bool flag = default(bool);
			if (value != null)
			{
				flag = value != activeUnit_0;
			}
			activeUnit_0 = value;
			if (flag && ((Control)this).Visible && ljwLjeuCtEb)
			{
				BuildForm();
			}
		}
	}

	public WeaponsWindow()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(WeaponsWindow_FormClosing);
		((Control)this).VisibleChanged += WeaponsWindow_VisibleChanged;
		((Form)this).Load += WeaponsWindow_Load;
		((Control)this).KeyDown += new KeyEventHandler(WeaponsWindow_KeyDown);
		((Form)this).FormClosed += new FormClosedEventHandler(WeaponsWindow_FormClosed);
		RTMPEnabled = true;
		bool_4 = false;
		bool_6 = false;
		bool_7 = false;
		keys_0 = (Keys[])(object)new Keys[2]
		{
			(Keys)119,
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
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
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
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected O, but got Unknown
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Expected O, but got Unknown
		//IL_077c: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0809: Expected O, but got Unknown
		//IL_0896: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a0: Expected O, but got Unknown
		//IL_0926: Unknown result type (might be due to invalid IL or missing references)
		//IL_0999: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a3: Expected O, but got Unknown
		//IL_0a2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a37: Expected O, but got Unknown
		//IL_0aca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8a: Expected O, but got Unknown
		//IL_0d1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d24: Expected O, but got Unknown
		icontainer_1 = new Container();
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(WeaponsWindow));
		Mount = new TreeGridColumn();
		WeaponType = new DataGridViewTextBoxColumn();
		Status = new DataGridViewTextBoxColumn();
		TGV_Weapons = new DarkTreeGridView();
		Column1 = new TreeGridColumn();
		Type = new DataGridViewTextBoxColumn();
		TimeToFire = new DataGridViewTextBoxColumn();
		Column3 = new DataGridViewTextBoxColumn();
		ReloadPriority = new DataGridViewCheckBoxColumn();
		ShowArcs = new DataGridViewCheckBoxColumn();
		ImageList1 = new ImageList(icontainer_1);
		Timer1 = new Timer(icontainer_1);
		TS_Edit = new DarkToolStrip();
		TSB_AddRec = new ToolStripButton();
		TSB_RemoveRec = new ToolStripButton();
		ToolStripSeparator1 = new ToolStripSeparator();
		TSB_AddMount = new ToolStripButton();
		TSB_RemoveMount = new ToolStripButton();
		ToolStripSeparator2 = new ToolStripSeparator();
		TSL_WeaponCount1 = new ToolStripLabel();
		TSL_WeaponCount2 = new ToolStripLabel();
		TSTB_RecCount = new ToolStripTextBox();
		TSB_ChangeWeaponCount = new ToolStripButton();
		((ISupportInitialize)(object)TGV_Weapons).BeginInit();
		((Control)TS_Edit).SuspendLayout();
		((Control)this).SuspendLayout();
		((DataGridViewColumn)Mount).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		Mount.DefaultNodeImage = null;
		((DataGridViewColumn)Mount).HeaderText = "Mount";
		((DataGridViewColumn)Mount).Name = "Mount";
		((DataGridViewColumn)Mount).ReadOnly = true;
		((DataGridViewTextBoxColumn)Mount).SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)WeaponType).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)WeaponType).HeaderText = "Type";
		((DataGridViewColumn)WeaponType).Name = "WeaponType";
		((DataGridViewColumn)WeaponType).ReadOnly = true;
		WeaponType.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Status).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Status).HeaderText = "Status";
		((DataGridViewColumn)Status).Name = "Status";
		((DataGridViewColumn)Status).ReadOnly = true;
		Status.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridView)TGV_Weapons).AllowUserToAddRows = false;
		((DataGridView)TGV_Weapons).AllowUserToDeleteRows = false;
		((DataGridView)TGV_Weapons).AllowUserToOrderColumns = true;
		((Control)TGV_Weapons).Anchor = (AnchorStyles)15;
		((DataGridView)TGV_Weapons).BackgroundColor = Color.FromArgb(43, 43, 43);
		((DataGridView)TGV_Weapons).BorderStyle = (BorderStyle)2;
		((DataGridView)TGV_Weapons).CellBorderStyle = (DataGridViewCellBorderStyle)4;
		((DataGridView)TGV_Weapons).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)TGV_Weapons).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)TGV_Weapons).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[6]
		{
			(DataGridViewColumn)Column1,
			(DataGridViewColumn)Type,
			(DataGridViewColumn)TimeToFire,
			(DataGridViewColumn)Column3,
			(DataGridViewColumn)ReloadPriority,
			(DataGridViewColumn)ShowArcs
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)TGV_Weapons).DefaultCellStyle = val2;
		((DataGridView)TGV_Weapons).EditMode = (DataGridViewEditMode)4;
		((DataGridView)TGV_Weapons).EnableHeadersVisualStyles = false;
		TGV_Weapons.ImageList = null;
		((Control)TGV_Weapons).Location = new Point(0, 0);
		((DataGridView)TGV_Weapons).MultiSelect = false;
		((Control)TGV_Weapons).Name = "TGV_Weapons";
		((DataGridView)TGV_Weapons).RowHeadersVisible = false;
		((DataGridView)TGV_Weapons).SelectionMode = (DataGridViewSelectionMode)1;
		TGV_Weapons.ShowLines = false;
		((Control)TGV_Weapons).Size = new Size(732, 333);
		((Control)TGV_Weapons).TabIndex = 4;
		((DataGridViewColumn)Column1).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		Column1.DefaultNodeImage = null;
		((DataGridViewColumn)Column1).HeaderText = "Mount (click weapon for DB info)";
		((DataGridViewColumn)Column1).MinimumWidth = 250;
		((DataGridViewColumn)Column1).Name = "Column1";
		((DataGridViewColumn)Column1).ReadOnly = true;
		((DataGridViewTextBoxColumn)Column1).SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Type).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Type).FillWeight = 10f;
		((DataGridViewColumn)Type).HeaderText = "";
		((DataGridViewColumn)Type).MinimumWidth = 75;
		((DataGridViewColumn)Type).Name = "Type";
		((DataGridViewColumn)Type).ReadOnly = true;
		Type.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)TimeToFire).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)TimeToFire).HeaderText = "Time to fire";
		((DataGridViewColumn)TimeToFire).Name = "TimeToFire";
		((DataGridViewColumn)TimeToFire).ReadOnly = true;
		TimeToFire.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)TimeToFire).Width = 69;
		((DataGridViewColumn)Column3).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Column3).FillWeight = 10f;
		((DataGridViewColumn)Column3).HeaderText = "Status";
		((DataGridViewColumn)Column3).MinimumWidth = 75;
		((DataGridViewColumn)Column3).Name = "Column3";
		((DataGridViewColumn)Column3).ReadOnly = true;
		Column3.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)ReloadPriority).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)ReloadPriority).HeaderText = "Reload Priority";
		((DataGridViewColumn)ReloadPriority).Name = "ReloadPriority";
		((DataGridViewColumn)ReloadPriority).Width = 86;
		((DataGridViewColumn)ShowArcs).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)ShowArcs).HeaderText = "Show Arcs";
		((DataGridViewColumn)ShowArcs).Name = "ShowArcs";
		((DataGridViewColumn)ShowArcs).Width = 64;
		ImageList1.ColorDepth = (ColorDepth)8;
		ImageList1.ImageSize = new Size(16, 16);
		ImageList1.TransparentColor = Color.Transparent;
		Timer1.Interval = 1000;
		((ToolStrip)TS_Edit).AutoSize = false;
		((ToolStrip)TS_Edit).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)TS_Edit).Dock = (DockStyle)2;
		((ToolStrip)TS_Edit).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)TS_Edit).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)TS_Edit).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[10]
		{
			(ToolStripItem)TSB_AddRec,
			(ToolStripItem)TSB_RemoveRec,
			(ToolStripItem)ToolStripSeparator1,
			(ToolStripItem)TSB_AddMount,
			(ToolStripItem)TSB_RemoveMount,
			(ToolStripItem)ToolStripSeparator2,
			(ToolStripItem)TSL_WeaponCount1,
			(ToolStripItem)TSL_WeaponCount2,
			(ToolStripItem)TSTB_RecCount,
			(ToolStripItem)TSB_ChangeWeaponCount
		});
		((Control)TS_Edit).Location = new Point(0, 336);
		((Control)TS_Edit).Name = "TS_Edit";
		((Control)TS_Edit).Padding = new Padding(5, 0, 1, 0);
		((Control)TS_Edit).Size = new Size(732, 25);
		((Control)TS_Edit).TabIndex = 7;
		((Control)TS_Edit).Text = "ToolStrip1";
		((ToolStripItem)TSB_AddRec).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_AddRec).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_AddRec).Image = (Image)componentResourceManager.GetObject("TSB_AddRec.Image");
		((ToolStripItem)TSB_AddRec).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_AddRec).Name = "TSB_AddRec";
		((ToolStripItem)TSB_AddRec).Size = new Size(136, 22);
		((ToolStripItem)TSB_AddRec).Text = "Add Weapon Record";
		((ToolStripItem)TSB_RemoveRec).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_RemoveRec).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_RemoveRec).Image = (Image)componentResourceManager.GetObject("TSB_RemoveRec.Image");
		((ToolStripItem)TSB_RemoveRec).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_RemoveRec).Name = "TSB_RemoveRec";
		((ToolStripItem)TSB_RemoveRec).Size = new Size(170, 22);
		((ToolStripItem)TSB_RemoveRec).Text = "Remove Weapon Record(s)";
		((ToolStripItem)ToolStripSeparator1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripSeparator1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripSeparator1).Margin = new Padding(0, 0, 2, 0);
		((ToolStripItem)ToolStripSeparator1).Name = "ToolStripSeparator1";
		((ToolStripItem)ToolStripSeparator1).Size = new Size(6, 25);
		((ToolStripItem)TSB_AddMount).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_AddMount).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_AddMount).Image = (Image)componentResourceManager.GetObject("TSB_AddMount.Image");
		((ToolStripItem)TSB_AddMount).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_AddMount).Name = "TSB_AddMount";
		((ToolStripItem)TSB_AddMount).Size = new Size(88, 22);
		((ToolStripItem)TSB_AddMount).Text = "Add Mount";
		((ToolStripItem)TSB_RemoveMount).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_RemoveMount).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_RemoveMount).Image = (Image)componentResourceManager.GetObject("TSB_RemoveMount.Image");
		((ToolStripItem)TSB_RemoveMount).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_RemoveMount).Name = "TSB_RemoveMount";
		((ToolStripItem)TSB_RemoveMount).Size = new Size(109, 22);
		((ToolStripItem)TSB_RemoveMount).Text = "Remove Mount";
		((ToolStripItem)TSB_RemoveMount).ToolTipText = "Remove Mount";
		((ToolStripItem)ToolStripSeparator2).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripSeparator2).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripSeparator2).Margin = new Padding(0, 0, 2, 0);
		((ToolStripItem)ToolStripSeparator2).Name = "ToolStripSeparator2";
		((ToolStripItem)ToolStripSeparator2).Size = new Size(6, 25);
		((ToolStripItem)TSL_WeaponCount1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSL_WeaponCount1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSL_WeaponCount1).Name = "TSL_WeaponCount1";
		((ToolStripItem)TSL_WeaponCount1).Size = new Size(59, 22);
		((ToolStripItem)TSL_WeaponCount1).Text = "Weapons:";
		((ToolStripItem)TSL_WeaponCount2).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSL_WeaponCount2).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSL_WeaponCount2).Name = "TSL_WeaponCount2";
		((ToolStripItem)TSL_WeaponCount2).Size = new Size(37, 22);
		((ToolStripItem)TSL_WeaponCount2).Text = "12345";
		((ToolStripControlHost)TSTB_RecCount).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripControlHost)TSTB_RecCount).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSTB_RecCount).Name = "TSTB_RecCount";
		((ToolStripControlHost)TSTB_RecCount).Size = new Size(40, 25);
		((ToolStripItem)TSTB_RecCount).Visible = false;
		((ToolStripItem)TSB_ChangeWeaponCount).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_ChangeWeaponCount).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSB_ChangeWeaponCount).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_ChangeWeaponCount).Image = (Image)componentResourceManager.GetObject("TSB_ChangeWeaponCount.Image");
		((ToolStripItem)TSB_ChangeWeaponCount).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_ChangeWeaponCount).Name = "TSB_ChangeWeaponCount";
		((ToolStripItem)TSB_ChangeWeaponCount).Size = new Size(52, 22);
		((ToolStripItem)TSB_ChangeWeaponCount).Text = "Change";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(732, 361);
		((Control)this).Controls.Add((Control)(object)TS_Edit);
		((Control)this).Controls.Add((Control)(object)TGV_Weapons);
		((Control)this).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(200, 200);
		((Control)this).Name = "WeaponsWindow";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Weapons";
		((ISupportInitialize)(object)TGV_Weapons).EndInit();
		((Control)TS_Edit).ResumeLayout(false);
		((Control)TS_Edit).PerformLayout();
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
					((Form)this).Activate();
					result = 1;
				}
				return (byte)result != 0;
			}
		}
		return false;
	}

	public void AddWeaponRec(WeaponRec theRec)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Invalid comparison between Unknown and I4
		if (theSelectedUnit == null)
		{
			return;
		}
		if (loadout_0 != null)
		{
			loadout_0.AddWeaponRec(theRec);
		}
		else
		{
			mount_0.MountWeapons.Add(theRec);
		}
		List<CommDevice> list = new List<CommDevice>();
		bool flag = true;
		CommDevice[] comms_ReadOnly = theRec.get_ReferenceWeapon(Client.CurrentScenario).Comms_ReadOnly;
		foreach (CommDevice commDevice in comms_ReadOnly)
		{
			if (commDevice.IsOptional)
			{
				continue;
			}
			flag = false;
			list.Add(commDevice);
			CommDevice[] comms_ReadOnly2 = theSelectedUnit.Comms_ReadOnly;
			for (int j = 0; j < comms_ReadOnly2.Length; j = checked(j + 1))
			{
				if (comms_ReadOnly2[j].DBID == commDevice.DBID)
				{
					flag = true;
				}
			}
		}
		if (!flag && list.Count > 0 && (int)DarkMessageBox.ShowWarning("The weapon record you have added misses a datalink, do you want to add one ?", "Datalink Needed", DarkDialogButton.YesNo) == 6)
		{
			Client.theCommsWindow = new UnitComms();
			((Control)Client.theCommsWindow).Show();
			MyProject.Forms.AddComms.FormThatCalledMe = (Form)(object)Client.theCommsWindow;
			((Control)MyProject.Forms.AddComms).Show();
			Client.MustRefreshMainForm = true;
			AddComms addComms = MyProject.Forms.AddComms;
			int dBID = list[0].DBID;
			ActiveUnit theParentPlatform = theSelectedUnit;
			CommDevice commDevice2 = DBFunctions.GetCommDevice(dBID, ref theParentPlatform);
			theSelectedUnit = theParentPlatform;
			addComms.InjectFilterByKeyword(commDevice2.Name);
		}
	}

	public void RemoveWeaponRec(WeaponRec theRec)
	{
		if (Information.IsNothing((object)mount_0))
		{
			if (!Information.IsNothing((object)loadout_0))
			{
				loadout_0.RemoveWeaponRec(theRec);
			}
		}
		else
		{
			mount_0.MountWeapons.Remove(theRec);
		}
	}

	private void WeaponsWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		Client.SelectedMountForArcDisplay = null;
		activeUnit_0 = null;
		((CancelEventArgs)(object)e).Cancel = true;
		((Control)MyProject.Forms.MainForm).BringToFront();
		((Control)this).Hide();
	}

	private void WeaponsWindow_VisibleChanged(object sender, EventArgs e)
	{
		if (!((Control)this).Visible)
		{
			return;
		}
		if (Information.IsNothing((object)activeUnit_0) && Client.SelectedUnit.IsActiveUnit)
		{
			activeUnit_0 = (ActiveUnit)Client.SelectedUnit;
		}
		if (!Information.IsNothing((object)activeUnit_0) && activeUnit_0.IsActiveUnit)
		{
			BuildForm();
			if ((TGV_Weapons.Nodes.Count > 0 && !Information.IsNothing((object)activeUnit_0)) & (activeUnit_0.Mounts.Count > 0))
			{
				mount_0 = (Mount)((DataGridViewBand)TGV_Weapons.Nodes[0]).Tag;
			}
		}
		else
		{
			((Control)this).Hide();
		}
	}

	private void WeaponsWindow_Load(object sender, EventArgs e)
	{
		if (Client.Realtime)
		{
			bool_7 = true;
		}
		bool_3 = false;
		PlatformComponent.StatusChanged += method_8;
		WeaponRec.CurrentLoadChanged += method_9;
		Command_Core.Mount.MountWeaponRecordAdded += method_3;
		Command_Core.Mount.MountWeaponRecordRemoved += method_4;
		Loadout.LoadoutWeaponRecordAdded += method_5;
		Loadout.LoadoutWeaponRecordRemoved += method_6;
		ActiveUnit.ActiveUnitMountsAdded += method_11;
		ActiveUnit.ActiveUnitMountsRemoved += method_10;
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		ljwLjeuCtEb = true;
		Timer1.Start();
	}

	private void method_2(object sender, DataGridViewCellPaintingEventArgs e)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		if ((e.ColumnIndex == 4 || e.ColumnIndex == 5) && (e.State & 4) > 0)
		{
			e.Paint(e.ClipBounds, (DataGridViewPaintParts)67);
			((HandledEventArgs)(object)e).Handled = true;
		}
	}

	private void method_3(string string_0, string string_1)
	{
		_Closure$__121-1 closure$__121- = new _Closure$__121-1(closure$__121-);
		closure$__121-.$VB$Me = this;
		if (bool_6)
		{
			return;
		}
		using IEnumerator<TreeGridNode> enumerator = TGV_Weapons.Nodes.GetEnumerator();
		_Closure$__121-0 closure$__121-2 = default(_Closure$__121-0);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			closure$__121-2 = new _Closure$__121-0(closure$__121-2);
			closure$__121-2.$VB$NonLocal_$VB$Closure_2 = closure$__121-;
			closure$__121-2.$VB$Local_theNode = enumerator.Current;
			if (((DataGridViewBand)closure$__121-2.$VB$Local_theNode).Tag != null && (object)((DataGridViewBand)closure$__121-2.$VB$Local_theNode).Tag.GetType() == typeof(Mount))
			{
				closure$__121-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMount = (Mount)((DataGridViewBand)closure$__121-2.$VB$Local_theNode).Tag;
				if (Operators.CompareString(closure$__121-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMount.ObjectID, string_0, true) == 0)
				{
					break;
				}
			}
		}
		using List<WeaponRec>.Enumerator enumerator2 = closure$__121-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMount.MountWeapons.GetEnumerator();
		_Closure$__121-2 closure$__121-3 = default(_Closure$__121-2);
		do
		{
			if (enumerator2.MoveNext())
			{
				closure$__121-3 = new _Closure$__121-2(closure$__121-3);
				closure$__121-3.$VB$NonLocal_$VB$Closure_3 = closure$__121-2;
				closure$__121-3.$VB$Local_theRec = enumerator2.Current;
				continue;
			}
			return;
		}
		while (Operators.CompareString(closure$__121-3.$VB$Local_theRec.ObjectID, string_1, true) != 0);
		if (!bool_7)
		{
			((Control)this).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__121-3._Lambda$__0));
		}
		else
		{
			bool_6 = true;
		}
	}

	private void method_4(string string_0, string string_1)
	{
		if (bool_6)
		{
			return;
		}
		using IEnumerator<TreeGridNode> enumerator = TGV_Weapons.Nodes.GetEnumerator();
		_Closure$__122-0 closure$__122- = default(_Closure$__122-0);
		do
		{
			if (enumerator.MoveNext())
			{
				closure$__122- = new _Closure$__122-0(closure$__122-);
				closure$__122-.$VB$Local_theNode = enumerator.Current;
				continue;
			}
			return;
		}
		while (((DataGridViewBand)closure$__122-.$VB$Local_theNode).Tag == null || (object)((DataGridViewBand)closure$__122-.$VB$Local_theNode).Tag.GetType() != typeof(Mount) || Operators.CompareString(((Mount)((DataGridViewBand)closure$__122-.$VB$Local_theNode).Tag).ObjectID, string_0, true) != 0);
		using IEnumerator<TreeGridNode> enumerator2 = closure$__122-.$VB$Local_theNode.Nodes.GetEnumerator();
		_Closure$__122-1 closure$__122-2 = default(_Closure$__122-1);
		do
		{
			if (enumerator2.MoveNext())
			{
				closure$__122-2 = new _Closure$__122-1(closure$__122-2);
				closure$__122-2.$VB$NonLocal_$VB$Closure_2 = closure$__122-;
				closure$__122-2.$VB$Local_theRecNode = enumerator2.Current;
				continue;
			}
			return;
		}
		while (((DataGridViewBand)closure$__122-2.$VB$Local_theRecNode).Tag == null || (object)((DataGridViewBand)closure$__122-2.$VB$Local_theRecNode).Tag.GetType() != typeof(WeaponRec) || Operators.CompareString(((WeaponRec)((DataGridViewBand)closure$__122-2.$VB$Local_theRecNode).Tag).ObjectID, string_1, true) != 0);
		if (!bool_7)
		{
			((Control)this).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__122-2._Lambda$__0));
		}
		else
		{
			bool_6 = true;
		}
	}

	private void method_5(string string_0, string string_1)
	{
		if (bool_6)
		{
			return;
		}
		using IEnumerator<TreeGridNode> enumerator = TGV_Weapons.Nodes.GetEnumerator();
		_Closure$__123-0 closure$__123- = default(_Closure$__123-0);
		Loadout loadout;
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			closure$__123- = new _Closure$__123-0(closure$__123-);
			closure$__123-.$VB$Me = this;
			closure$__123-.$VB$Local_theNode = enumerator.Current;
			if (((DataGridViewBand)closure$__123-.$VB$Local_theNode).Tag != null && (object)((DataGridViewBand)closure$__123-.$VB$Local_theNode).Tag.GetType() == typeof(Loadout))
			{
				loadout = (Loadout)((DataGridViewBand)closure$__123-.$VB$Local_theNode).Tag;
				if (Operators.CompareString(loadout.ObjectID, string_0, true) == 0)
				{
					break;
				}
			}
		}
		WeaponRec[] weapons = loadout.Weapons;
		int num = 0;
		_Closure$__123-1 closure$__123-2 = default(_Closure$__123-1);
		while (true)
		{
			if (num < weapons.Length)
			{
				closure$__123-2 = new _Closure$__123-1(closure$__123-2);
				closure$__123-2.$VB$NonLocal_$VB$Closure_2 = closure$__123-;
				closure$__123-2.$VB$Local_theRec = weapons[num];
				if (Operators.CompareString(closure$__123-2.$VB$Local_theRec.ObjectID, string_1, true) == 0)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return;
		}
		if (!bool_7)
		{
			((Control)this).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__123-2._Lambda$__0));
		}
		else
		{
			bool_6 = true;
		}
	}

	private void method_6(string string_0, string string_1)
	{
		if (bool_6)
		{
			return;
		}
		using IEnumerator<TreeGridNode> enumerator = TGV_Weapons.Nodes.GetEnumerator();
		_Closure$__124-0 closure$__124- = default(_Closure$__124-0);
		do
		{
			if (enumerator.MoveNext())
			{
				closure$__124- = new _Closure$__124-0(closure$__124-);
				closure$__124-.$VB$Local_theNode = enumerator.Current;
				continue;
			}
			return;
		}
		while (((DataGridViewBand)closure$__124-.$VB$Local_theNode).Tag == null || (object)((DataGridViewBand)closure$__124-.$VB$Local_theNode).Tag.GetType() != typeof(Loadout) || Operators.CompareString(((Loadout)((DataGridViewBand)closure$__124-.$VB$Local_theNode).Tag).ObjectID, string_0, true) != 0);
		using IEnumerator<TreeGridNode> enumerator2 = closure$__124-.$VB$Local_theNode.Nodes.GetEnumerator();
		_Closure$__124-1 closure$__124-2 = default(_Closure$__124-1);
		do
		{
			if (enumerator2.MoveNext())
			{
				closure$__124-2 = new _Closure$__124-1(closure$__124-2);
				closure$__124-2.$VB$NonLocal_$VB$Closure_2 = closure$__124-;
				closure$__124-2.$VB$Local_theRecNode = enumerator2.Current;
				continue;
			}
			return;
		}
		while (((DataGridViewBand)closure$__124-2.$VB$Local_theRecNode).Tag == null || (object)((DataGridViewBand)closure$__124-2.$VB$Local_theRecNode).Tag.GetType() != typeof(WeaponRec) || Operators.CompareString(((WeaponRec)((DataGridViewBand)closure$__124-2.$VB$Local_theRecNode).Tag).ObjectID, string_1, true) != 0);
		if (!bool_7)
		{
			((Control)this).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__124-2._Lambda$__0));
		}
		else
		{
			bool_6 = true;
		}
	}

	private void method_7(string string_0, string string_1)
	{
		if (((Control)this).Visible && theSelectedUnit != null && Operators.CompareString(theSelectedUnit.ObjectID, string_0, true) == 0)
		{
			BuildForm();
		}
	}

	private void method_8(PlatformComponent platformComponent_0)
	{
		if (bool_6)
		{
			return;
		}
		using IEnumerator<TreeGridNode> enumerator = TGV_Weapons.Nodes.GetEnumerator();
		_Closure$__126-0 closure$__126- = default(_Closure$__126-0);
		_Closure$__126-1 closure$__126-2 = default(_Closure$__126-1);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			closure$__126- = new _Closure$__126-0(closure$__126-);
			closure$__126-.$VB$Me = this;
			closure$__126-.$VB$Local_theNode = enumerator.Current;
			if (((DataGridViewBand)closure$__126-.$VB$Local_theNode).Tag != null && (object)((DataGridViewBand)closure$__126-.$VB$Local_theNode).Tag.GetType() == typeof(Mount))
			{
				closure$__126-2 = new _Closure$__126-1(closure$__126-2);
				closure$__126-2.$VB$NonLocal_$VB$Closure_2 = closure$__126-;
				closure$__126-2.$VB$Local_theMount = (Mount)((DataGridViewBand)closure$__126-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theNode).Tag;
				if (Operators.CompareString(closure$__126-2.$VB$Local_theMount.ObjectID, platformComponent_0.ObjectID, true) == 0)
				{
					break;
				}
			}
		}
		if (bool_7)
		{
			bool_6 = true;
		}
		else
		{
			((Control)this).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__126-2._Lambda$__0));
		}
	}

	private void method_9(string string_0)
	{
		_Closure$__127-2 closure$__127- = new _Closure$__127-2(closure$__127-);
		closure$__127-.$VB$Me = this;
		if (bool_6)
		{
			return;
		}
		using IEnumerator<TreeGridNode> enumerator = TGV_Weapons.Nodes.GetEnumerator();
		_Closure$__127-0 closure$__127-2 = default(_Closure$__127-0);
		_Closure$__127-1 closure$__127-3 = default(_Closure$__127-1);
		while (enumerator.MoveNext())
		{
			closure$__127-2 = new _Closure$__127-0(closure$__127-2);
			closure$__127-2.$VB$NonLocal_$VB$Closure_2 = closure$__127-;
			closure$__127-2.$VB$Local_theNode = enumerator.Current;
			if (((DataGridViewBand)closure$__127-2.$VB$Local_theNode).Tag == null || ((object)((DataGridViewBand)closure$__127-2.$VB$Local_theNode).Tag.GetType() != typeof(Mount) && (object)((DataGridViewBand)closure$__127-2.$VB$Local_theNode).Tag.GetType() != typeof(Loadout)))
			{
				continue;
			}
			using IEnumerator<TreeGridNode> enumerator2 = closure$__127-2.$VB$Local_theNode.Nodes.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				closure$__127-3 = new _Closure$__127-1(closure$__127-3);
				closure$__127-3.$VB$NonLocal_$VB$Closure_3 = closure$__127-2;
				closure$__127-3.$VB$Local_theRecNode = enumerator2.Current;
				if (((DataGridViewBand)closure$__127-3.$VB$Local_theRecNode).Tag == null || (object)((DataGridViewBand)closure$__127-3.$VB$Local_theRecNode).Tag.GetType() != typeof(WeaponRec))
				{
					continue;
				}
				closure$__127-3.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_theRec = (WeaponRec)((DataGridViewBand)closure$__127-3.$VB$Local_theRecNode).Tag;
				if (Operators.CompareString(closure$__127-3.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_theRec.ObjectID, string_0, true) == 0)
				{
					if (bool_7)
					{
						bool_6 = true;
					}
					else
					{
						((Control)this).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__127-3._Lambda$__0));
					}
					return;
				}
			}
		}
	}

	private void method_10(string string_0, string string_1)
	{
		if (bool_6 || !((Control)this).Visible || Operators.CompareString(activeUnit_0.ObjectID, string_0, true) != 0)
		{
			return;
		}
		using IEnumerator<TreeGridNode> enumerator = TGV_Weapons.Nodes.GetEnumerator();
		_Closure$__128-0 closure$__128- = default(_Closure$__128-0);
		do
		{
			if (enumerator.MoveNext())
			{
				closure$__128- = new _Closure$__128-0(closure$__128-);
				closure$__128-.$VB$Me = this;
				closure$__128-.$VB$Local_theNode = enumerator.Current;
				continue;
			}
			return;
		}
		while (((DataGridViewBand)closure$__128-.$VB$Local_theNode).Tag == null || (object)((DataGridViewBand)closure$__128-.$VB$Local_theNode).Tag.GetType() != typeof(Mount) || Operators.CompareString(((Mount)((DataGridViewBand)closure$__128-.$VB$Local_theNode).Tag).ObjectID, string_1, true) != 0);
		if (!bool_7)
		{
			((Control)this).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__128-._Lambda$__0));
		}
		else
		{
			bool_6 = true;
		}
	}

	private void method_11(string string_0, string string_1)
	{
		if (bool_6 || !((Control)this).Visible || Operators.CompareString(activeUnit_0.ObjectID, string_0, true) != 0)
		{
			return;
		}
		using List<Mount>.Enumerator enumerator = activeUnit_0.Mounts.GetEnumerator();
		_Closure$__129-0 closure$__129- = default(_Closure$__129-0);
		do
		{
			if (enumerator.MoveNext())
			{
				closure$__129- = new _Closure$__129-0(closure$__129-);
				closure$__129-.$VB$Me = this;
				closure$__129-.$VB$Local_theMount = enumerator.Current;
				continue;
			}
			return;
		}
		while (Operators.CompareString(closure$__129-.$VB$Local_theMount.ObjectID, string_1, true) != 0);
		if (!bool_7)
		{
			((Control)this).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__129-._Lambda$__0));
		}
	}

	public void RemoveOrphanedRecords(TreeGridNode theMountNode, IEnumerable<WeaponRec> WeaponRecords)
	{
		List<TreeGridNode> list = new List<TreeGridNode>();
		foreach (TreeGridNode node in theMountNode.Nodes)
		{
			if (!WeaponRecords.Contains((WeaponRec)((DataGridViewBand)node).Tag))
			{
				list.Add(node);
			}
		}
		foreach (TreeGridNode item in list)
		{
			theMountNode.Nodes.Remove(item);
		}
	}

	private void method_12(TreeGridNode treeGridNode_0, Mount mount_1)
	{
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected O, but got Unknown
		int num = 0;
		foreach (WeaponRec mountWeapon in mount_1.MountWeapons)
		{
			num += mountWeapon.MaxLoad;
		}
		string text = Conversions.ToString(0);
		if (mount_1.ReloadStatus == Command_Core.Mount._ReloadStatus.Ready)
		{
			text = Misc.TimeString((long)Math.Round(mount_1.TimeToFire));
		}
		else
		{
			float num2 = 0f;
			if (mount_1.TimeToFire > 0f)
			{
				num2 = mount_1.TimeToFire;
			}
			if (mount_1.MountMagazine.TimeToFire > 0f && mount_1.MountMagazine.TimeToFire > num2)
			{
				num2 = mount_1.MountMagazine.TimeToFire;
			}
			foreach (WeaponRec mountWeapon2 in mount_1.MountWeapons)
			{
				if (mountWeapon2.TimeToFire > num2)
				{
					num2 = mountWeapon2.TimeToFire;
				}
			}
			foreach (WeaponRec weapon in mount_1.MountMagazine.Weapons)
			{
				if (weapon.TimeToFire > num2)
				{
					num2 = weapon.TimeToFire;
				}
			}
			if (num2 == 0f)
			{
				text = Misc.TimeString((long)Math.Round(mount_1.TimeToFire));
			}
			else if (mount_1.ReloadStatus == Command_Core.Mount._ReloadStatus.Reloading)
			{
				text = "Reloading: " + Misc.TimeString((long)Math.Round(num2));
			}
			else if (mount_1.ReloadStatus == Command_Core.Mount._ReloadStatus.Unloading)
			{
				text = "Unloading: " + Misc.TimeString((long)Math.Round(num2));
			}
		}
		object[] obj = new object[4]
		{
			Misc.RemoveHiddenString(mount_1.Name),
			null,
			null,
			null
		};
		string[] obj2 = new string[5] { "(", null, null, null, null };
		int theQty_FullyLoadedCells = 0;
		int theQty_PartiallyLoadedCells = 0;
		obj2[1] = Conversions.ToString(mount_1.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells));
		obj2[2] = "/";
		obj2[3] = Conversions.ToString(mount_1.MaxCapacity);
		obj2[4] = ")";
		obj[1] = string.Concat(obj2);
		obj[2] = text;
		obj[3] = mount_1.Status.ToString();
		((DataGridViewRow)treeGridNode_0).SetValues(obj);
		treeGridNode_0.Cells["ReloadPriority"].ReadOnly = true;
		((DataGridViewRow)treeGridNode_0).DefaultCellStyle.ForeColor = Color.Black;
		((DataGridViewRow)treeGridNode_0).DefaultCellStyle.Font = new Font(((Control)this).Font, (FontStyle)0);
		((DataGridViewRow)treeGridNode_0).DefaultCellStyle.ForeColor = GetComponentDamageColor(mount_1);
		((DataGridViewBand)treeGridNode_0).Tag = mount_1;
	}

	private void method_13(TreeGridNode treeGridNode_0, Mount mount_1, WeaponRec weaponRec_1)
	{
		TreeGridNode treeGridNode_1 = treeGridNode_0.Nodes.Add("New node");
		method_15(treeGridNode_1, weaponRec_1, mount_1);
	}

	private void method_14(TreeGridNode treeGridNode_0, WeaponRec weaponRec_1)
	{
		TreeGridNode treeGridNode_1 = treeGridNode_0.Nodes.Add("New node");
		method_16(treeGridNode_1, weaponRec_1);
	}

	private void method_15(TreeGridNode treeGridNode_0, WeaponRec weaponRec_1, Mount mount_1)
	{
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected O, but got Unknown
		if (activeUnit_0 == null)
		{
			return;
		}
		int num = activeUnit_0.Weaponry.HowManyOfThisWeaponOnMountMagazine(mount_1, weaponRec_1.int_3);
		int num2 = activeUnit_0.Weaponry.HowManyOfThisWeaponOnMagazines(weaponRec_1.int_3);
		string text = "";
		string text2 = "";
		if (num > 0)
		{
			text = " (" + Conversions.ToString(num) + " on mount mag)";
		}
		else if (num2 == 0 && mount_1.ParentPlatform != null && !mount_1.ParentPlatform.IsAircraft)
		{
			text2 = " (No reloads available)";
		}
		string text3 = (bool_3 ? (" (TTF:" + Misc.TimeString((long)Math.Round(weaponRec_1.TimeToFire)) + ") ") : string.Empty);
		string text4 = string.Empty;
		if (weaponRec_1.Multiple > 1)
		{
			text4 = " (" + Conversions.ToString(weaponRec_1.Multiple) + "x/cell)";
		}
		((DataGridViewRow)treeGridNode_0).SetValues(new object[5]
		{
			Conversions.ToString(weaponRec_1.CurrentLoad) + "/" + Conversions.ToString(weaponRec_1.MaxLoad) + text4 + text3 + " " + Misc.RemoveHiddenString(Strings.Trim(weaponRec_1.get_ReferenceWeapon(Client.CurrentScenario).Name)) + text + text2,
			Misc.ToEnglishString(weaponRec_1.get_ReferenceWeapon(Client.CurrentScenario).Type),
			null,
			null,
			mount_1.ReloadPriority.Contains(weaponRec_1.int_3)
		});
		((DataGridViewBand)treeGridNode_0).Tag = weaponRec_1;
		if (weaponRec_1.CurrentLoad == 0)
		{
			((DataGridViewRow)treeGridNode_0).DefaultCellStyle.ForeColor = Color.DarkGray;
			((DataGridViewRow)treeGridNode_0).DefaultCellStyle.Font = new Font(((DataGridView)TGV_Weapons).DefaultCellStyle.Font, (FontStyle)2);
		}
		else
		{
			((DataGridViewRow)treeGridNode_0).DefaultCellStyle.ForeColor = Color.LightBlue;
			((DataGridViewRow)treeGridNode_0).DefaultCellStyle.Font = new Font(((DataGridView)TGV_Weapons).DefaultCellStyle.Font, (FontStyle)0);
			Weapon weapon = weaponRec_1.get_ReferenceWeapon(Client.CurrentScenario);
			weapon.set_Latitude((GlobalVariables.BooleanObject)null, activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null));
			weapon.set_Longitude((GlobalVariables.BooleanObject)null, activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null));
			weapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			CommDevice[] comms_ReadOnly = weapon.Comms_ReadOnly;
			if (comms_ReadOnly.Length > 0 && !comms_ReadOnly[0].IsOptional && weapon.CommStuff.CommDevicePresentToConnectToThisUnit(comms_ReadOnly, activeUnit_0) == null)
			{
				((DataGridViewRow)treeGridNode_0).DefaultCellStyle.ForeColor = Color.Pink;
				treeGridNode_0.Cells[3].Value = "No datalink";
			}
		}
		treeGridNode_0.Cells[5].ReadOnly = true;
	}

	private void method_16(TreeGridNode treeGridNode_0, WeaponRec weaponRec_1)
	{
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		string text = (bool_3 ? (" (TTF:" + Misc.TimeString((long)Math.Round(weaponRec_1.TimeToFire)) + ") ") : "");
		((DataGridViewRow)treeGridNode_0).SetValues(new object[2]
		{
			Conversions.ToString(weaponRec_1.CurrentLoad) + "/" + Conversions.ToString(weaponRec_1.MaxLoad) + text + "  " + Misc.RemoveHiddenString(Strings.Trim(weaponRec_1.get_ReferenceWeapon(Client.CurrentScenario).Name)),
			Misc.ToEnglishString(weaponRec_1.get_ReferenceWeapon(Client.CurrentScenario).Type)
		});
		((DataGridViewBand)treeGridNode_0).Tag = weaponRec_1;
		if (weaponRec_1.CurrentLoad != 0)
		{
			((DataGridViewRow)treeGridNode_0).DefaultCellStyle.ForeColor = Color.LightBlue;
			((DataGridViewRow)treeGridNode_0).DefaultCellStyle.Font = new Font(((DataGridView)TGV_Weapons).DefaultCellStyle.Font, (FontStyle)0);
		}
		else
		{
			((DataGridViewRow)treeGridNode_0).DefaultCellStyle.ForeColor = Color.DarkGray;
			((DataGridViewRow)treeGridNode_0).DefaultCellStyle.Font = new Font(((DataGridView)TGV_Weapons).DefaultCellStyle.Font, (FontStyle)2);
		}
		treeGridNode_0.Cells[4].ReadOnly = true;
		treeGridNode_0.Cells[5].ReadOnly = true;
	}

	public void BuildForm()
	{
		if (bool_7)
		{
			((ToolStripItem)TSB_AddMount).Visible = false;
			((ToolStripItem)TSB_RemoveMount).Visible = false;
			((ToolStripItem)TSB_AddRec).Visible = false;
			((ToolStripItem)TSB_RemoveRec).Visible = false;
			((ToolStripItem)TSB_RemoveMount).Visible = false;
			((ToolStripItem)TSL_WeaponCount2).Visible = false;
			((ToolStripItem)TSL_WeaponCount1).Visible = false;
			((ToolStripItem)TSB_ChangeWeaponCount).Visible = false;
		}
		if (Information.IsNothing((object)activeUnit_0))
		{
			if (!Client.SelectedUnit.IsActiveUnit)
			{
				return;
			}
			activeUnit_0 = (ActiveUnit)Client.SelectedUnit;
		}
		TGV_Weapons.Nodes.Clear();
		((Control)TS_Edit).Visible = Client.AllowEditModeActions;
		((Form)this).Text = "Weapons for " + activeUnit_0.Name;
		((ToolStripItem)TSB_AddRec).Visible = activeUnit_0.Mounts.Count > 0 || (activeUnit_0.IsAircraft && ((Aircraft)activeUnit_0).Loadout != null);
		((ToolStripItem)TSB_RemoveRec).Visible = ((ToolStripItem)TSB_AddRec).Visible;
		TGV_Weapons.Nodes.Clear();
		List<Mount> list = activeUnit_0.Mounts.OrderBy([SpecialName] (Mount theM) => theM.Name).ToList();
		foreach (Mount item in list)
		{
			TreeGridNode treeGridNode = TGV_Weapons.Nodes.Add("New node");
			method_12(treeGridNode, item);
			if (item.MountWeapons.Count <= 0)
			{
				continue;
			}
			if (bool_7)
			{
				foreach (WeaponRec mountWeapon in item.MountWeapons)
				{
					method_13(treeGridNode, item, mountWeapon);
				}
			}
			else
			{
				treeGridNode.Nodes.Add("Temp");
			}
		}
		if (activeUnit_0.IsAircraft && !Information.IsNothing((object)((Aircraft)activeUnit_0).Loadout))
		{
			Loadout loadout = ((Aircraft)activeUnit_0).Loadout;
			TreeGridNode treeGridNode2 = TGV_Weapons.Nodes.Add("New node");
			method_17(treeGridNode2, loadout);
			WeaponRec[] weapons = loadout.Weapons;
			foreach (WeaponRec weaponRec_ in weapons)
			{
				method_14(treeGridNode2, weaponRec_);
			}
			treeGridNode2.Expand();
		}
	}

	private void method_17(TreeGridNode treeGridNode_0, Loadout loadout_1)
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		int num = 0;
		WeaponRec[] weapons = loadout_1.Weapons;
		foreach (WeaponRec weaponRec in weapons)
		{
			num += weaponRec.MaxLoad;
		}
		((DataGridViewRow)treeGridNode_0).SetValues(new object[2]
		{
			"Loadout: " + Misc.RemoveHiddenString(loadout_1.Name),
			"(" + Conversions.ToString(loadout_1.CurrentCapacity) + "/" + Conversions.ToString(num) + ")"
		});
		((DataGridViewBand)treeGridNode_0).Tag = loadout_1;
		((DataGridViewRow)treeGridNode_0).DefaultCellStyle.ForeColor = Color.LightGray;
		((DataGridViewRow)treeGridNode_0).DefaultCellStyle.Font = new Font(((Control)this).Font, (FontStyle)0);
		treeGridNode_0.Cells[4].ReadOnly = true;
		treeGridNode_0.Cells[5].ReadOnly = true;
	}

	private void method_18(object sender, EventArgs e)
	{
		MyProject.Forms.AddWeaponRecord.FormThatCalledMe = (Form)(object)this;
		((Control)MyProject.Forms.AddWeaponRecord).Show();
	}

	private void method_19(object sender, EventArgs e)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Invalid comparison between Unknown and I4
		switch (((BaseCollection)((DataGridView)TGV_Weapons).SelectedRows).Count)
		{
		case 1:
			RemoveWeaponRec(weaponRec_0);
			return;
		case 0:
			return;
		}
		List<DataGridViewRow> list = new List<DataGridViewRow>();
		foreach (DataGridViewRow item in (BaseCollection)((DataGridView)TGV_Weapons).SelectedRows)
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
			RemoveWeaponRec((WeaponRec)((DataGridViewBand)item2).Tag);
		}
	}

	private void method_20(object sender, DataGridViewCellEventArgs e)
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected O, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Expected O, but got Unknown
		if (e.RowIndex == -1 || e.ColumnIndex == -1)
		{
			return;
		}
		DataGridViewColumn val = ((DataGridView)TGV_Weapons).Columns[e.ColumnIndex];
		if (Information.IsNothing((object)TGV_Weapons.CurrentNode))
		{
			return;
		}
		if ((object)((DataGridViewBand)TGV_Weapons.CurrentNode).Tag.GetType() == typeof(WeaponRec) && Operators.CompareString(val.Name, "ReloadPriority", true) == 0 && !Information.IsNothing((object)mount_0))
		{
			DataGridViewCheckBoxCell val2 = (DataGridViewCheckBoxCell)((DataGridView)TGV_Weapons)[e.ColumnIndex, e.RowIndex];
			WeaponRec weaponRec = (WeaponRec)((DataGridViewBand)TGV_Weapons.CurrentNode).Tag;
			Mount mount = (Mount)((DataGridViewBand)TGV_Weapons.CurrentNode.Parent).Tag;
			if (!mount.ReloadPriority.Contains(weaponRec.int_3))
			{
				mount.ReloadPriority.Add(weaponRec.int_3);
				((DataGridViewCell)val2).Value = true;
				if (bool_7)
				{
					Client.RealtimeTerminal.SetWeaponReloadPriority(activeUnit_0, mount, weaponRec.int_3);
				}
				if (mount.ParentPlatform != null && mount.ParentPlatform.Weaponry.HowManyOfThisWeaponOnMountMagazine(mount, weaponRec.int_3) == 0 && mount.ParentPlatform.Weaponry.HowManyOfThisWeaponOnMagazines(weaponRec.int_3) == 0)
				{
					DarkMessageBox.ShowWarning("You have set reload priority for a weapon with no reloads available. This will have no effect unless new reloads become available.", "No reloads available.");
				}
			}
			else
			{
				mount.ReloadPriority.Remove(weaponRec.int_3);
				((DataGridViewCell)val2).Value = false;
				if (bool_7)
				{
					Client.RealtimeTerminal.RemoveWeaponReloadPriority(activeUnit_0, mount, weaponRec.int_3);
				}
			}
		}
		if ((object)((DataGridViewBand)TGV_Weapons.CurrentNode).Tag.GetType() != typeof(Mount) || Operators.CompareString(val.Name, "ShowArcs", true) != 0 || Information.IsNothing((object)mount_0))
		{
			return;
		}
		Mount mount2 = default(Mount);
		WeaponRec weaponRec2 = default(WeaponRec);
		foreach (TreeGridNode item in Module1.AllNodes((TreeGridView)TGV_Weapons))
		{
			DataGridViewCheckBoxCell val3 = (DataGridViewCheckBoxCell)item.Cells[e.ColumnIndex];
			if (Operators.ConditionalCompareObjectEqual(((DataGridViewCell)val3).Value, (object)true, true))
			{
				if ((object)((DataGridViewBand)item).Tag.GetType() == typeof(Mount))
				{
					mount2 = (Mount)((DataGridViewBand)item).Tag;
				}
				else if ((object)((DataGridViewBand)item).Tag.GetType() == typeof(WeaponRec))
				{
					weaponRec2 = (WeaponRec)((DataGridViewBand)item).Tag;
				}
			}
			((DataGridViewCell)val3).Value = false;
		}
		Mount mount3;
		WeaponRec weaponRec3 = default(WeaponRec);
		if ((object)((DataGridViewBand)TGV_Weapons.CurrentNode).Tag.GetType() == typeof(Mount))
		{
			mount3 = (Mount)((DataGridViewBand)TGV_Weapons.CurrentNode).Tag;
		}
		else if ((object)((DataGridViewBand)TGV_Weapons.CurrentNode).Tag.GetType() == typeof(WeaponRec))
		{
			mount3 = (Mount)((DataGridViewBand)TGV_Weapons.CurrentNode.Parent).Tag;
			weaponRec3 = (WeaponRec)((DataGridViewBand)TGV_Weapons.CurrentNode).Tag;
		}
		else
		{
			mount3 = null;
		}
		if (!Information.IsNothing((object)mount3))
		{
			DataGridViewCheckBoxCell val3 = (DataGridViewCheckBoxCell)((DataGridView)TGV_Weapons)[e.ColumnIndex, e.RowIndex];
			int mustRefreshMainForm;
			if (!Information.IsNothing((object)mount3) && !Information.IsNothing((object)mount2) && mount2 == mount3)
			{
				Client.SelectedMountForArcDisplay = null;
				mustRefreshMainForm = 1;
			}
			else if (!Information.IsNothing((object)weaponRec3) && !Information.IsNothing((object)weaponRec2) && weaponRec2 == weaponRec3)
			{
				Client.SelectedMountForArcDisplay = null;
				mustRefreshMainForm = 1;
			}
			else
			{
				((DataGridViewCell)val3).Value = true;
				Client.SelectedMountForArcDisplay = mount3;
				mustRefreshMainForm = 1;
			}
			Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		}
	}

	private void method_21(object sender, ExpandingEventArgs e)
	{
		_Closure$__141-1 closure$__141- = new _Closure$__141-1(closure$__141-);
		closure$__141-.$VB$Me = this;
		closure$__141-.$VB$Local_e = e;
		if (!bool_7)
		{
			closure$__141-.$VB$Local_e.Node.Nodes.Clear();
		}
		if (((DataGridViewBand)closure$__141-.$VB$Local_e.Node).Tag != null && (object)((DataGridViewBand)closure$__141-.$VB$Local_e.Node).Tag.GetType() == typeof(Mount))
		{
			_Closure$__141-0 arg = default(_Closure$__141-0);
			_Closure$__141-0 CS$<>8__locals7 = new _Closure$__141-0(arg);
			CS$<>8__locals7.$VB$NonLocal_$VB$Closure_2 = closure$__141-;
			CS$<>8__locals7.$VB$Local_theMount = (Mount)((DataGridViewBand)CS$<>8__locals7.$VB$NonLocal_$VB$Closure_2.$VB$Local_e.Node).Tag;
			if (!bool_7)
			{
				Task.Factory.StartNew([SpecialName] () =>
				{
					using List<WeaponRec>.Enumerator enumerator = CS$<>8__locals7.$VB$Local_theMount.MountWeapons.GetEnumerator();
					_Closure$__141-2 closure$__141-2 = default(_Closure$__141-2);
					while (enumerator.MoveNext())
					{
						closure$__141-2 = new _Closure$__141-2(closure$__141-2);
						closure$__141-2.$VB$NonLocal_$VB$Closure_3 = CS$<>8__locals7;
						closure$__141-2.$VB$Local_theWeaponRec = enumerator.Current;
						((Control)CS$<>8__locals7.$VB$NonLocal_$VB$Closure_2.$VB$Me).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__141-2._Lambda$__1));
					}
				});
			}
			mount_0 = (Mount)((DataGridViewBand)CS$<>8__locals7.$VB$NonLocal_$VB$Closure_2.$VB$Local_e.Node).Tag;
			((ToolStripItem)TSB_RemoveRec).Visible = false;
		}
		if ((object)((DataGridViewBand)closure$__141-.$VB$Local_e.Node).Tag.GetType() != typeof(Loadout))
		{
			return;
		}
		if (!bool_7)
		{
			WeaponRec[] weapons = ((Loadout)((DataGridViewBand)closure$__141-.$VB$Local_e.Node).Tag).Weapons;
			foreach (WeaponRec weaponRec_ in weapons)
			{
				method_14(closure$__141-.$VB$Local_e.Node, weaponRec_);
			}
		}
		((ToolStripItem)TSB_AddRec).Visible = false;
		((ToolStripItem)TSB_RemoveRec).Visible = false;
	}

	private void tqkLdilgjlu(object sender, EventArgs e)
	{
		MyProject.Forms.AddMount.FormThatCalledMe = (Form)(object)this;
		MyProject.Forms.AddMount.targetUnit = activeUnit_0;
		((Control)MyProject.Forms.AddMount).Show();
	}

	private void method_22(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex != 0)
		{
			return;
		}
		try
		{
			TreeGridNode treeGridNode = null;
			foreach (TreeGridNode item in Module1.AllNodes((TreeGridView)TGV_Weapons))
			{
				if (((DataGridViewRow)item).Selected)
				{
					treeGridNode = item;
					break;
				}
			}
			if (!Information.IsNothing((object)treeGridNode) && !Information.IsNothing(RuntimeHelpers.GetObjectValue(((DataGridViewBand)treeGridNode).Tag)) && (object)((DataGridViewBand)treeGridNode).Tag.GetType() == typeof(WeaponRec))
			{
				int int_ = ((WeaponRec)((DataGridViewBand)treeGridNode).Tag).int_3;
				Client.smethod_17("Weapon", int_);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200104", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_23(object sender, EventArgs e)
	{
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			mount_0 = null;
			if (TGV_Weapons.CurrentNode == null || (object)((DataGridViewBand)TGV_Weapons.CurrentNode).Tag.GetType() == typeof(Loadout))
			{
				return;
			}
			if (!Information.IsNothing((object)TGV_Weapons.CurrentNode))
			{
				if ((object)((DataGridViewBand)TGV_Weapons.CurrentNode).Tag.GetType() == typeof(Mount))
				{
					mount_0 = (Mount)((DataGridViewBand)TGV_Weapons.CurrentNode).Tag;
				}
				else if (TGV_Weapons.CurrentNode.Parent != null && TGV_Weapons.CurrentNode.Parent.Index > 0 && (object)((DataGridViewBand)TGV_Weapons.CurrentNode.Parent).Tag.GetType() == typeof(Mount))
				{
					mount_0 = (Mount)((DataGridViewBand)TGV_Weapons.CurrentNode.Parent).Tag;
				}
			}
			if (!Information.IsNothing((object)mount_0))
			{
				TGV_Weapons.CurrentNode.Parent.Nodes.Remove(TGV_Weapons.CurrentNode);
				if (!Information.IsNothing((object)activeUnit_0))
				{
					activeUnit_0.Mounts.Remove(mount_0);
				}
			}
			else
			{
				DarkMessageBox.ShowWarning("No mount selected!", string.Empty);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void method_24(object sender, EventArgs e)
	{
		bool flag;
		if (flag = bool_4)
		{
			if (!flag)
			{
				return;
			}
			bool_4 = false;
			((ToolStripItem)TSB_ChangeWeaponCount).Text = "Change";
			((ToolStripItem)TSTB_RecCount).Visible = false;
			((ToolStripItem)TSL_WeaponCount2).Visible = true;
			if (Information.IsNothing((object)weaponRec_0))
			{
				return;
			}
			if ((Operators.CompareString(((ToolStripControlHost)TSTB_RecCount).Text, "", true) != 0) & Versioned.IsNumeric((object)((ToolStripControlHost)TSTB_RecCount).Text))
			{
				int num = Conversions.ToInteger(((ToolStripControlHost)TSTB_RecCount).Text);
				if (num < 0)
				{
					num = 0;
				}
				if ((double)num / (double)weaponRec_0.Multiple > (double)weaponRec_0.MaxLoad)
				{
					num = weaponRec_0.MaxLoad;
				}
				if (!Information.IsNothing((object)mount_0))
				{
					weaponRec_0.CurrentLoad = 0;
					Mount mount = mount_0;
					int theQty_FullyLoadedCells = 0;
					int theQty_PartiallyLoadedCells = 0;
					int num2 = mount.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells);
					if ((double)num / (double)weaponRec_0.Multiple > (double)(mount_0.MaxCapacity - num2))
					{
						num = mount_0.MaxCapacity - num2 * weaponRec_0.Multiple;
					}
				}
				if (num < 0)
				{
					num = 0;
				}
				weaponRec_0.CurrentLoad = num;
				((ToolStripItem)TSL_WeaponCount2).Text = Conversions.ToString(num);
				foreach (TreeGridNode node in TGV_Weapons.Nodes)
				{
					foreach (TreeGridNode node2 in node.Nodes)
					{
						if (((DataGridViewBand)node2).Tag == weaponRec_0)
						{
							string text = string.Empty;
							if (weaponRec_0.Multiple > 1)
							{
								text = " (" + Conversions.ToString(weaponRec_0.Multiple) + "x/cell)";
							}
							((DataGridViewRow)node2).SetValues(new object[1] { Conversions.ToString(weaponRec_0.CurrentLoad) + "/" + Conversions.ToString(weaponRec_0.MaxLoad) + text + " " + Misc.RemoveHiddenString(Strings.Trim(weaponRec_0.get_ReferenceWeapon(Client.CurrentScenario).Name)) });
						}
					}
				}
				if (!Information.IsNothing((object)activeUnit_0) && activeUnit_0.IsAircraft)
				{
					Aircraft aircraft = (Aircraft)activeUnit_0;
					if (!Information.IsNothing((object)aircraft.Loadout))
					{
						aircraft.Weaponry.AdjustLoadoutPayloadWeight();
					}
				}
			}
			activeUnit_0.Weaponry.ClearCachedWeapons();
			Client.MustRefreshMainForm = true;
			MyProject.Forms.MainForm.MapRender_Tactical();
		}
		else
		{
			bool_4 = true;
			((ToolStripItem)TSB_ChangeWeaponCount).Text = "Set";
			((ToolStripItem)TSTB_RecCount).Visible = true;
			((ToolStripItem)TSL_WeaponCount2).Visible = false;
		}
	}

	private void method_25(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)TGV_Weapons.CurrentNode))
		{
			return;
		}
		((ToolStripItem)TSB_AddMount).Visible = true;
		((ToolStripItem)TSL_WeaponCount1).Visible = false;
		bool_4 = false;
		((ToolStripItem)TSL_WeaponCount1).Visible = true;
		((ToolStripItem)TSL_WeaponCount2).Visible = true;
		((ToolStripItem)TSTB_RecCount).Visible = false;
		((ToolStripItem)TSB_ChangeWeaponCount).Text = "Change";
		if ((object)((DataGridViewBand)TGV_Weapons.CurrentNode).Tag.GetType() == typeof(WeaponRec))
		{
			weaponRec_0 = (WeaponRec)((DataGridViewBand)TGV_Weapons.CurrentNode).Tag;
			if ((object)((DataGridViewBand)TGV_Weapons.CurrentNode.Parent).Tag.GetType() == typeof(Mount))
			{
				mount_0 = (Mount)((DataGridViewBand)TGV_Weapons.CurrentNode.Parent).Tag;
				loadout_0 = null;
				((ToolStripItem)TSB_AddRec).Visible = true;
				((ToolStripItem)TSB_RemoveRec).Visible = true;
				((ToolStripItem)TSB_RemoveMount).Visible = true;
			}
			else if ((object)((DataGridViewBand)TGV_Weapons.CurrentNode.Parent).Tag.GetType() == typeof(Loadout))
			{
				mount_0 = null;
				loadout_0 = (Loadout)((DataGridViewBand)TGV_Weapons.CurrentNode.Parent).Tag;
				((ToolStripItem)TSB_AddRec).Visible = false;
				((ToolStripItem)TSB_RemoveRec).Visible = false;
				((ToolStripItem)TSB_RemoveMount).Visible = false;
			}
			((ToolStripControlHost)TSTB_RecCount).Text = Conversions.ToString(weaponRec_0.CurrentLoad);
			((ToolStripItem)TSL_WeaponCount2).Text = Conversions.ToString(weaponRec_0.CurrentLoad);
			((ToolStripItem)TSL_WeaponCount1).Visible = true;
			((ToolStripItem)TSL_WeaponCount2).Visible = true;
			((ToolStripItem)TSB_ChangeWeaponCount).Visible = true;
		}
		if ((object)((DataGridViewBand)TGV_Weapons.CurrentNode).Tag.GetType() == typeof(Mount))
		{
			mount_0 = (Mount)((DataGridViewBand)TGV_Weapons.CurrentNode).Tag;
			loadout_0 = null;
			((ToolStripItem)TSB_AddRec).Visible = true;
			((ToolStripItem)TSB_RemoveRec).Visible = false;
			((ToolStripItem)TSB_RemoveMount).Visible = true;
			((ToolStripItem)TSL_WeaponCount2).Visible = false;
			((ToolStripItem)TSL_WeaponCount1).Visible = false;
			((ToolStripItem)TSB_ChangeWeaponCount).Visible = false;
		}
		if ((object)((DataGridViewBand)TGV_Weapons.CurrentNode).Tag.GetType() == typeof(Loadout))
		{
			loadout_0 = (Loadout)((DataGridViewBand)TGV_Weapons.CurrentNode).Tag;
			((ToolStripItem)TSB_AddRec).Visible = true;
			((ToolStripItem)TSB_RemoveRec).Visible = false;
			((ToolStripItem)TSB_RemoveMount).Visible = false;
			((ToolStripItem)TSL_WeaponCount2).Visible = false;
			((ToolStripItem)TSL_WeaponCount1).Visible = false;
			((ToolStripItem)TSB_ChangeWeaponCount).Visible = false;
		}
		if (bool_7)
		{
			((ToolStripItem)TSB_AddMount).Visible = false;
			((ToolStripItem)TSB_RemoveMount).Visible = false;
			((ToolStripItem)TSB_AddRec).Visible = false;
			((ToolStripItem)TSB_RemoveRec).Visible = false;
			((ToolStripItem)TSB_RemoveMount).Visible = false;
			((ToolStripItem)TSL_WeaponCount2).Visible = false;
			((ToolStripItem)TSL_WeaponCount1).Visible = false;
			((ToolStripItem)TSB_ChangeWeaponCount).Visible = false;
		}
	}

	private void WeaponsWindow_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Invalid comparison between Unknown and I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Invalid comparison between Unknown and I4
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
			return;
		}
		if ((int)e.KeyCode == 119 && ((Control)this).Visible)
		{
			((Form)this).Close();
			return;
		}
		if (bool_5)
		{
			if (e.KeyValue == 13 && ((Control)this).Visible)
			{
				((ToolStripItem)TSB_ChangeWeaponCount).Select();
				return;
			}
			if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
			{
				MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
		if (!bool_5 && e.KeyValue != 32)
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_26(object sender, EventArgs e)
	{
		bool_5 = true;
	}

	private void method_27(object sender, EventArgs e)
	{
		bool_5 = false;
		((ToolStripItem)TSB_ChangeWeaponCount).Select();
	}

	private void WeaponsWindow_FormClosed(object sender, FormClosedEventArgs e)
	{
		PlatformComponent.StatusChanged -= method_8;
		WeaponRec.CurrentLoadChanged -= method_9;
		Command_Core.Mount.MountWeaponRecordAdded -= method_3;
		Command_Core.Mount.MountWeaponRecordRemoved -= method_4;
		Loadout.LoadoutWeaponRecordAdded -= method_5;
		Loadout.LoadoutWeaponRecordRemoved -= method_6;
		ActiveUnit.ActiveUnitMountsAdded -= method_11;
		ActiveUnit.ActiveUnitMountsRemoved -= method_10;
		Client.SelectedMountForArcDisplay = null;
		Timer1.Stop();
	}

	private void method_28()
	{
		bool_6 = false;
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		int num = -1;
		DataGridViewColumn val = ((DataGridView)TGV_Weapons).Columns["ShowArcs"];
		int num2 = -1;
		if (val != null)
		{
			num2 = ((DataGridViewBand)val).Index;
		}
		if (((BaseCollection)((DataGridView)TGV_Weapons).SelectedRows).Count > 0 && ((DataGridViewBand)((DataGridView)TGV_Weapons).SelectedRows[0]).Tag != null)
		{
			num = ((DataGridViewBand)((DataGridView)TGV_Weapons).SelectedRows[0]).Index;
		}
		foreach (TreeGridNode item in Module1.AllNodes((TreeGridView)TGV_Weapons))
		{
			if (item == null || ((DataGridViewBand)item).Tag == null)
			{
				continue;
			}
			ScenarioObject scenarioObject = (ScenarioObject)((DataGridViewBand)item).Tag;
			if (item.IsExpanded)
			{
				list.Add(scenarioObject.ObjectID);
			}
			if ((object)scenarioObject.GetType() == typeof(Mount) && ((BaseCollection)item.Cells).Count > num2)
			{
				DataGridViewCell val2 = item.Cells[num2];
				if (val2 != null && Operators.ConditionalCompareObjectEqual(val2.Value, (object)true, true))
				{
					list2.Add(scenarioObject.ObjectID);
				}
			}
		}
		BuildForm();
		int num3 = -1;
		foreach (TreeGridNode node in TGV_Weapons.Nodes)
		{
			if (node == null || ((DataGridViewBand)node).Tag == null)
			{
				continue;
			}
			num3++;
			if (num3 == num)
			{
				((DataGridViewRow)node).Selected = true;
				num = -1;
			}
			ScenarioObject scenarioObject = (ScenarioObject)((DataGridViewBand)node).Tag;
			if (list.Contains(scenarioObject.ObjectID))
			{
				node.Expand();
				if (num >= 0)
				{
					foreach (TreeGridNode node2 in node.Nodes)
					{
						num3++;
						if (num3 == num)
						{
							((DataGridViewRow)node2).Selected = true;
							num = -1;
							break;
						}
					}
				}
			}
			if (list2.Contains(scenarioObject.ObjectID))
			{
				DataGridViewCell val3 = node.Cells[num2];
				if (val3 != null)
				{
					val3.Value = true;
				}
			}
		}
	}

	private void KoeLdhbFsnp(object sender, EventArgs e)
	{
		if (!bool_6)
		{
			if (Client.CurrentGame.Status != Game._GameStatus.Running)
			{
				return;
			}
			{
				foreach (TreeGridNode node in TGV_Weapons.Nodes)
				{
					if (((DataGridViewBand)node).Tag != null && (object)((DataGridViewBand)node).Tag.GetType() == typeof(Mount))
					{
						Mount mount_ = (Mount)((DataGridViewBand)node).Tag;
						method_12(node, mount_);
					}
				}
				return;
			}
		}
		method_28();
	}

	static WeaponsWindow()
	{
		Class72.smethod_20();
	}
}
