using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using AdvancedDataGridView;
using Command_Core;
using Command.My;
using DarkUI.Config;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class DockingOps : DarkSecondaryFormBase, GInterface0
{
	[CompilerGenerated]
	internal sealed class _Closure$__207-0
	{
		public Group $VB$Local_theGroup;

		public ActiveUnit $VB$Local_theUnit;

		public DockingOps $VB$Me;

		public _Closure$__207-0(_Closure$__207-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theGroup = arg0.$VB$Local_theGroup;
				$VB$Local_theUnit = arg0.$VB$Local_theUnit;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$Me.method_2($VB$Local_theGroup, $VB$Local_theUnit);
		}

		static _Closure$__207-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__208-0
	{
		public Group $VB$Local_theGroup;

		public ActiveUnit $VB$Local_theUnit;

		public DockingOps $VB$Me;

		public _Closure$__208-0(_Closure$__208-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theGroup = arg0.$VB$Local_theGroup;
				$VB$Local_theUnit = arg0.$VB$Local_theUnit;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$Me.method_3($VB$Local_theGroup, $VB$Local_theUnit);
		}

		static _Closure$__208-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__215-0
	{
		public ActiveUnit $VB$Local_theAU;

		public _Closure$__215-0(_Closure$__215-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAU = arg0.$VB$Local_theAU;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(TreeGridNode theNode)
		{
			return ((DataGridViewBand)theNode).Tag == $VB$Local_theAU;
		}

		static _Closure$__215-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__219-0
	{
		public int $VB$Local_theDBID;

		public _Closure$__219-0(_Closure$__219-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__12(ActiveUnit theBoat)
		{
			return theBoat.IsShip & (theBoat.DBID == $VB$Local_theDBID);
		}

		[SpecialName]
		internal bool _Lambda$__14(ActiveUnit theBoat)
		{
			return theBoat.IsShip & (theBoat.DBID == $VB$Local_theDBID);
		}

		static _Closure$__219-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__219-1
	{
		public int $VB$Local_theDBID;

		public _Closure$__219-1(_Closure$__219-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__16(ActiveUnit theBoat)
		{
			return theBoat.IsSubmarine & (theBoat.DBID == $VB$Local_theDBID);
		}

		[SpecialName]
		internal bool _Lambda$__18(ActiveUnit theBoat)
		{
			return theBoat.IsSubmarine & (theBoat.DBID == $VB$Local_theDBID);
		}

		static _Closure$__219-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__219-2
	{
		public int $VB$Local_theDBID;

		public _Closure$__219-2(_Closure$__219-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__20(ActiveUnit theBoat)
		{
			return theBoat.IsVehicle & (theBoat.DBID == $VB$Local_theDBID);
		}

		[SpecialName]
		internal bool _Lambda$__22(ActiveUnit theBoat)
		{
			return theBoat.IsVehicle & (theBoat.DBID == $VB$Local_theDBID);
		}

		static _Closure$__219-2()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TabControl1")]
	private DarkUITabControl _TabControl1;

	[AccessedThroughProperty("ToolStripButton1")]
	[CompilerGenerated]
	private ToolStripButton _ToolStripButton1;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripButton3")]
	private ToolStripButton _ToolStripButton3;

	[CompilerGenerated]
	[AccessedThroughProperty("TGV_Boats")]
	private DarkTreeGridView _TGV_Boats;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private Timer timer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_AbortLaunch")]
	private ToolStripButton _TSB_AbortLaunch;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_Doctrine")]
	private ToolStripButton _TSB_Doctrine;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_AssignToMission")]
	private ToolStripDropDownButton _TSB_AssignToMission;

	[CompilerGenerated]
	[AccessedThroughProperty("CMenu_BoatOps")]
	private DarkContextMenu _CMenu_BoatOps;

	[CompilerGenerated]
	[AccessedThroughProperty("LaunchIndividuallyToolStripMenuItem")]
	private DarkToolStripMenuItem _LaunchIndividuallyToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("LaunchAsGroupsToolStripMenuItem")]
	private DarkToolStripMenuItem _LaunchAsGroupsToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("AbortLaunchToolStripMenuItem")]
	private DarkToolStripMenuItem _AbortLaunchToolStripMenuItem;

	[AccessedThroughProperty("DoctrineToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _DoctrineToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("AssignToMissionToolStripMenuItem")]
	private DarkToolStripMenuItem _AssignToMissionToolStripMenuItem;

	[AccessedThroughProperty("TSB_SetReadyTime")]
	[CompilerGenerated]
	private ToolStripButton _TSB_SetReadyTime;

	[AccessedThroughProperty("TSB_Rename")]
	[CompilerGenerated]
	private ToolStripButton _TSB_Rename;

	[AccessedThroughProperty("TSB_Delete")]
	[CompilerGenerated]
	private ToolStripButton _TSB_Delete;

	[AccessedThroughProperty("SetTimeToReadyToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _SetTimeToReadyToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("RenameToolStripMenuItem")]
	private DarkToolStripMenuItem _RenameToolStripMenuItem;

	[AccessedThroughProperty("RemoveToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _RemoveToolStripMenuItem;

	[AccessedThroughProperty("TSB_Cargo")]
	[CompilerGenerated]
	private ToolStripButton _TSB_Cargo;

	[AccessedThroughProperty("Button_AddFac")]
	[CompilerGenerated]
	private ToolStripButton _Button_AddFac;

	[AccessedThroughProperty("Button_RemoveFac")]
	[CompilerGenerated]
	private ToolStripButton _Button_RemoveFac;

	[AccessedThroughProperty("btnExpandShipList")]
	[CompilerGenerated]
	private DarkUIButton _btnExpandShipList;

	[CompilerGenerated]
	[AccessedThroughProperty("btnHideUnderMaintenance")]
	private DarkUIButton _btnHideUnderMaintenance;

	public List<ActiveUnit> SelectedHosts;

	private List<ActiveUnit> list_0;

	private List<ActiveUnit> list_1;

	private List<ActiveUnit> list_2;

	private MaintainScrollPosition maintainScrollPosition_0;

	private bool bool_2;

	private HashSet<TreeGridNode> hashSet_0;

	[CompilerGenerated]
	[AccessedThroughProperty("BW_TGV_Boats")]
	private BackgroundWorker backgroundWorker_0;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	[CompilerGenerated]
	private bool bool_6;

	private Keys[] keys_0;

	internal virtual DarkUITabControl TabControl1
	{
		[CompilerGenerated]
		get
		{
			return _TabControl1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUITabControl darkUITabControl = _TabControl1;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged -= eventHandler;
			}
			_TabControl1 = value;
			darkUITabControl = _TabControl1;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("ToolStrip1")]
	internal virtual DarkToolStrip ToolStrip1 { get; set; }

	internal virtual ToolStripButton ToolStripButton1
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			ToolStripButton val = _ToolStripButton1;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ToolStripButton1 = value;
			val = _ToolStripButton1;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton ToolStripButton3
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton3;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_23;
			ToolStripButton val = _ToolStripButton3;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ToolStripButton3 = value;
			val = _ToolStripButton3;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("SplitContainer1")]
	internal virtual SplitContainer SplitContainer1 { get; set; }

	private virtual DarkTreeGridView TGV_Boats
	{
		[CompilerGenerated]
		get
		{
			return _TGV_Boats;
		}
		[CompilerGenerated]
		set
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			CollapsingEventHandler value2 = method_19;
			ExpandingEventHandler value3 = method_20;
			EventHandler eventHandler = method_25;
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_44);
			DataGridViewCellMouseEventHandler val2 = new DataGridViewCellMouseEventHandler(method_63);
			DarkTreeGridView darkTreeGridView = _TGV_Boats;
			if (darkTreeGridView != null)
			{
				darkTreeGridView.NodeCollapsing -= value2;
				darkTreeGridView.NodeExpanding -= value3;
				((DataGridView)darkTreeGridView).SelectionChanged -= eventHandler;
				((DataGridView)darkTreeGridView).CellContentClick -= val;
				((DataGridView)darkTreeGridView).ColumnHeaderMouseClick -= val2;
			}
			_TGV_Boats = value;
			darkTreeGridView = _TGV_Boats;
			if (darkTreeGridView != null)
			{
				darkTreeGridView.NodeCollapsing += value2;
				darkTreeGridView.NodeExpanding += value3;
				((DataGridView)darkTreeGridView).SelectionChanged += eventHandler;
				((DataGridView)darkTreeGridView).CellContentClick += val;
				((DataGridView)darkTreeGridView).ColumnHeaderMouseClick += val2;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

	[field: AccessedThroughProperty("TV_Facilities")]
	internal virtual DarkTreeView TV_Facilities { get; set; }

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
			EventHandler eventHandler = method_7;
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

	internal virtual ToolStripButton TSB_AbortLaunch
	{
		[CompilerGenerated]
		get
		{
			return _TSB_AbortLaunch;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			ToolStripButton val = _TSB_AbortLaunch;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_AbortLaunch = value;
			val = _TSB_AbortLaunch;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator1")]
	internal virtual ToolStripSeparator ToolStripSeparator1 { get; set; }

	internal virtual ToolStripButton TSB_Doctrine
	{
		[CompilerGenerated]
		get
		{
			return _TSB_Doctrine;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_31;
			ToolStripButton val = _TSB_Doctrine;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_Doctrine = value;
			val = _TSB_Doctrine;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripDropDownButton TSB_AssignToMission
	{
		[CompilerGenerated]
		get
		{
			return _TSB_AssignToMission;
		}
		[CompilerGenerated]
		set
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			EventHandler eventHandler = method_32;
			EventHandler eventHandler2 = method_33;
			ToolStripItemClickedEventHandler val = new ToolStripItemClickedEventHandler(method_34);
			ToolStripDropDownButton val2 = _TSB_AssignToMission;
			if (val2 != null)
			{
				((ToolStripItem)val2).Click -= eventHandler;
				((ToolStripDropDownItem)val2).DropDownOpening -= eventHandler2;
				((ToolStripDropDownItem)val2).DropDownItemClicked -= val;
			}
			_TSB_AssignToMission = value;
			val2 = _TSB_AssignToMission;
			if (val2 != null)
			{
				((ToolStripItem)val2).Click += eventHandler;
				((ToolStripDropDownItem)val2).DropDownOpening += eventHandler2;
				((ToolStripDropDownItem)val2).DropDownItemClicked += val;
			}
		}
	}

	internal virtual DarkContextMenu CMenu_BoatOps
	{
		[CompilerGenerated]
		get
		{
			return _CMenu_BoatOps;
		}
		[CompilerGenerated]
		set
		{
			CancelEventHandler cancelEventHandler = method_42;
			DarkContextMenu darkContextMenu = _CMenu_BoatOps;
			if (darkContextMenu != null)
			{
				((ToolStripDropDown)darkContextMenu).Opening -= cancelEventHandler;
			}
			_CMenu_BoatOps = value;
			darkContextMenu = _CMenu_BoatOps;
			if (darkContextMenu != null)
			{
				((ToolStripDropDown)darkContextMenu).Opening += cancelEventHandler;
			}
		}
	}

	internal virtual DarkToolStripMenuItem LaunchIndividuallyToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _LaunchIndividuallyToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_36;
			DarkToolStripMenuItem darkToolStripMenuItem = _LaunchIndividuallyToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_LaunchIndividuallyToolStripMenuItem = value;
			darkToolStripMenuItem = _LaunchIndividuallyToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	internal virtual DarkToolStripMenuItem LaunchAsGroupsToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _LaunchAsGroupsToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_37;
			DarkToolStripMenuItem darkToolStripMenuItem = _LaunchAsGroupsToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_LaunchAsGroupsToolStripMenuItem = value;
			darkToolStripMenuItem = _LaunchAsGroupsToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	internal virtual DarkToolStripMenuItem AbortLaunchToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _AbortLaunchToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_38;
			DarkToolStripMenuItem darkToolStripMenuItem = _AbortLaunchToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_AbortLaunchToolStripMenuItem = value;
			darkToolStripMenuItem = _AbortLaunchToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator2")]
	internal virtual ToolStripSeparator ToolStripSeparator2 { get; set; }

	internal virtual DarkToolStripMenuItem DoctrineToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _DoctrineToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_39;
			DarkToolStripMenuItem darkToolStripMenuItem = _DoctrineToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_DoctrineToolStripMenuItem = value;
			darkToolStripMenuItem = _DoctrineToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	internal virtual DarkToolStripMenuItem AssignToMissionToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _AssignToMissionToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = method_40;
			ToolStripItemClickedEventHandler val = new ToolStripItemClickedEventHandler(method_43);
			DarkToolStripMenuItem darkToolStripMenuItem = _AssignToMissionToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
				((ToolStripDropDownItem)darkToolStripMenuItem).DropDownItemClicked -= val;
			}
			_AssignToMissionToolStripMenuItem = value;
			darkToolStripMenuItem = _AssignToMissionToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
				((ToolStripDropDownItem)darkToolStripMenuItem).DropDownItemClicked += val;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator3")]
	internal virtual ToolStripSeparator ToolStripSeparator3 { get; set; }

	internal virtual ToolStripButton TSB_SetReadyTime
	{
		[CompilerGenerated]
		get
		{
			return _TSB_SetReadyTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_45;
			ToolStripButton val = _TSB_SetReadyTime;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_SetReadyTime = value;
			val = _TSB_SetReadyTime;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_Rename
	{
		[CompilerGenerated]
		get
		{
			return _TSB_Rename;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_47;
			ToolStripButton val = _TSB_Rename;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_Rename = value;
			val = _TSB_Rename;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_Delete
	{
		[CompilerGenerated]
		get
		{
			return _TSB_Delete;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_49;
			ToolStripButton val = _TSB_Delete;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_Delete = value;
			val = _TSB_Delete;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator4")]
	internal virtual ToolStripSeparator ToolStripSeparator4 { get; set; }

	internal virtual DarkToolStripMenuItem SetTimeToReadyToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _SetTimeToReadyToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_51;
			DarkToolStripMenuItem darkToolStripMenuItem = _SetTimeToReadyToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_SetTimeToReadyToolStripMenuItem = value;
			darkToolStripMenuItem = _SetTimeToReadyToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	internal virtual DarkToolStripMenuItem RenameToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _RenameToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_52;
			DarkToolStripMenuItem darkToolStripMenuItem = _RenameToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_RenameToolStripMenuItem = value;
			darkToolStripMenuItem = _RenameToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	internal virtual DarkToolStripMenuItem RemoveToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _RemoveToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_53;
			DarkToolStripMenuItem darkToolStripMenuItem = _RemoveToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_RemoveToolStripMenuItem = value;
			darkToolStripMenuItem = _RemoveToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_Cargo
	{
		[CompilerGenerated]
		get
		{
			return _TSB_Cargo;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_54;
			ToolStripButton val = _TSB_Cargo;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_Cargo = value;
			val = _TSB_Cargo;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Boat")]
	internal virtual TreeGridColumn Boat { get; set; }

	[field: AccessedThroughProperty("Damage")]
	internal virtual DataGridViewLinkColumn Damage { get; set; }

	[field: AccessedThroughProperty("Weapons")]
	internal virtual DataGridViewLinkColumn Weapons { get; set; }

	[field: AccessedThroughProperty("Magazines")]
	internal virtual DataGridViewLinkColumn Magazines { get; set; }

	[field: AccessedThroughProperty("Fuel")]
	internal virtual DataGridViewTextBoxColumn Fuel { get; set; }

	[field: AccessedThroughProperty("Mission")]
	internal virtual DataGridViewTextBoxColumn Mission { get; set; }

	[field: AccessedThroughProperty("Status")]
	internal virtual DataGridViewTextBoxColumn Status { get; set; }

	[field: AccessedThroughProperty("TimeToReady")]
	internal virtual DataGridViewTextBoxColumn TimeToReady { get; set; }

	[field: AccessedThroughProperty("TS_Edit")]
	internal virtual DarkToolStrip TS_Edit { get; set; }

	internal virtual ToolStripButton Button_AddFac
	{
		[CompilerGenerated]
		get
		{
			return _Button_AddFac;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_56;
			ToolStripButton val = _Button_AddFac;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_Button_AddFac = value;
			val = _Button_AddFac;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton Button_RemoveFac
	{
		[CompilerGenerated]
		get
		{
			return _Button_RemoveFac;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_57;
			ToolStripButton val = _Button_RemoveFac;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_Button_RemoveFac = value;
			val = _Button_RemoveFac;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Splitter1")]
	internal virtual Splitter Splitter1 { get; set; }

	internal virtual DarkUIButton btnExpandShipList
	{
		[CompilerGenerated]
		get
		{
			return _btnExpandShipList;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_59;
			DarkUIButton darkUIButton = _btnExpandShipList;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btnExpandShipList = value;
			darkUIButton = _btnExpandShipList;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("lblCapacity")]
	internal virtual DarkLabel lblCapacity { get; set; }

	internal virtual DarkUIButton btnHideUnderMaintenance
	{
		[CompilerGenerated]
		get
		{
			return _btnHideUnderMaintenance;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_58;
			DarkUIButton darkUIButton = _btnHideUnderMaintenance;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btnHideUnderMaintenance = value;
			darkUIButton = _btnHideUnderMaintenance;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	protected override bool RTMPEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
		[CompilerGenerated]
		set
		{
			bool_6 = value;
		}
	}

	public DockingOps()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(DockingOps_FormClosing);
		((Form)this).Load += DockingOps_Load;
		((Control)this).KeyDown += new KeyEventHandler(DockingOps_KeyDown);
		((Form)this).FormClosed += new FormClosedEventHandler(DockingOps_FormClosed);
		((Form)this).Shown += DockingOps_Shown;
		SelectedHosts = new List<ActiveUnit>();
		list_0 = new List<ActiveUnit>();
		list_1 = new List<ActiveUnit>();
		list_2 = new List<ActiveUnit>();
		maintainScrollPosition_0 = new MaintainScrollPosition();
		hashSet_0 = new HashSet<TreeGridNode>();
		vmethod_1(new BackgroundWorker());
		bool_3 = false;
		bool_4 = false;
		bool_5 = false;
		RTMPEnabled = true;
		keys_0 = (Keys[])(object)new Keys[2]
		{
			(Keys)118,
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
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected O, but got Unknown
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_050d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Unknown result type (might be due to invalid IL or missing references)
		//IL_059a: Expected O, but got Unknown
		//IL_0627: Unknown result type (might be due to invalid IL or missing references)
		//IL_0631: Expected O, but got Unknown
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1b: Expected O, but got Unknown
		//IL_0dfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e08: Expected O, but got Unknown
		//IL_0ee5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eef: Expected O, but got Unknown
		//IL_0f5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1030: Unknown result type (might be due to invalid IL or missing references)
		//IL_1424: Unknown result type (might be due to invalid IL or missing references)
		//IL_156b: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_15cc: Expected O, but got Unknown
		//IL_1649: Unknown result type (might be due to invalid IL or missing references)
		//IL_1653: Expected O, but got Unknown
		//IL_16d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_16da: Expected O, but got Unknown
		//IL_179c: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1809: Expected O, but got Unknown
		//IL_190f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1992: Unknown result type (might be due to invalid IL or missing references)
		//IL_199c: Expected O, but got Unknown
		//IL_1a26: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a30: Expected O, but got Unknown
		//IL_1a91: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9b: Expected O, but got Unknown
		//IL_1b0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b16: Expected O, but got Unknown
		//IL_1b87: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b91: Expected O, but got Unknown
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(DockingOps));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		ToolStrip1 = new DarkToolStrip();
		ToolStripButton1 = new ToolStripButton();
		ToolStripButton3 = new ToolStripButton();
		TSB_AbortLaunch = new ToolStripButton();
		ToolStripSeparator1 = new ToolStripSeparator();
		TSB_Doctrine = new ToolStripButton();
		TSB_AssignToMission = new ToolStripDropDownButton();
		ToolStripSeparator3 = new ToolStripSeparator();
		TSB_Cargo = new ToolStripButton();
		SplitContainer1 = new SplitContainer();
		lblCapacity = new DarkLabel();
		btnHideUnderMaintenance = new DarkUIButton();
		Splitter1 = new Splitter();
		btnExpandShipList = new DarkUIButton();
		TGV_Boats = new DarkTreeGridView();
		Boat = new TreeGridColumn();
		Damage = new DataGridViewLinkColumn();
		Weapons = new DataGridViewLinkColumn();
		Magazines = new DataGridViewLinkColumn();
		Fuel = new DataGridViewTextBoxColumn();
		Mission = new DataGridViewTextBoxColumn();
		Status = new DataGridViewTextBoxColumn();
		TimeToReady = new DataGridViewTextBoxColumn();
		CMenu_BoatOps = new DarkContextMenu();
		LaunchIndividuallyToolStripMenuItem = new DarkToolStripMenuItem();
		LaunchAsGroupsToolStripMenuItem = new DarkToolStripMenuItem();
		AbortLaunchToolStripMenuItem = new DarkToolStripMenuItem();
		ToolStripSeparator2 = new ToolStripSeparator();
		DoctrineToolStripMenuItem = new DarkToolStripMenuItem();
		AssignToMissionToolStripMenuItem = new DarkToolStripMenuItem();
		ToolStripSeparator4 = new ToolStripSeparator();
		SetTimeToReadyToolStripMenuItem = new DarkToolStripMenuItem();
		RenameToolStripMenuItem = new DarkToolStripMenuItem();
		RemoveToolStripMenuItem = new DarkToolStripMenuItem();
		TabPage2 = new TabPage();
		TV_Facilities = new DarkTreeView();
		TS_Edit = new DarkToolStrip();
		Button_AddFac = new ToolStripButton();
		Button_RemoveFac = new ToolStripButton();
		TSB_SetReadyTime = new ToolStripButton();
		TSB_Rename = new ToolStripButton();
		TSB_Delete = new ToolStripButton();
		Timer1 = new Timer(icontainer_1);
		((Control)TabControl1).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((Control)ToolStrip1).SuspendLayout();
		((ISupportInitialize)SplitContainer1).BeginInit();
		((Control)SplitContainer1.Panel1).SuspendLayout();
		((Control)SplitContainer1).SuspendLayout();
		((ISupportInitialize)(object)TGV_Boats).BeginInit();
		((Control)CMenu_BoatOps).SuspendLayout();
		((Control)TabPage2).SuspendLayout();
		((Control)TS_Edit).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)TabControl1).Controls.Add((Control)(object)TabPage1);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage2);
		((Control)TabControl1).Cursor = Cursors.Hand;
		((Control)TabControl1).Dock = (DockStyle)5;
		((Control)TabControl1).Font = new Font("Segoe UI", 8f);
		((TabControl)TabControl1).ItemSize = new Size(80, 20);
		((Control)TabControl1).Location = new Point(0, 0);
		((Control)TabControl1).Name = "TabControl1";
		((TabControl)TabControl1).SelectedIndex = 0;
		((Control)TabControl1).Size = new Size(852, 531);
		((Control)TabControl1).TabIndex = 1;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)ToolStrip1);
		((Control)TabPage1).Controls.Add((Control)(object)SplitContainer1);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(844, 503);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Boat Status";
		((ToolStrip)ToolStrip1).AutoSize = false;
		((ToolStrip)ToolStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)ToolStrip1).Dock = (DockStyle)2;
		((ToolStrip)ToolStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)ToolStrip1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)ToolStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[8]
		{
			(ToolStripItem)ToolStripButton1,
			(ToolStripItem)ToolStripButton3,
			(ToolStripItem)TSB_AbortLaunch,
			(ToolStripItem)ToolStripSeparator1,
			(ToolStripItem)TSB_Doctrine,
			(ToolStripItem)TSB_AssignToMission,
			(ToolStripItem)ToolStripSeparator3,
			(ToolStripItem)TSB_Cargo
		});
		((Control)ToolStrip1).Location = new Point(3, 476);
		((Control)ToolStrip1).Name = "ToolStrip1";
		((Control)ToolStrip1).Padding = new Padding(5, 0, 1, 0);
		((Control)ToolStrip1).Size = new Size(838, 24);
		((Control)ToolStrip1).TabIndex = 1;
		((Control)ToolStrip1).Text = "ToolStrip1";
		((ToolStripItem)ToolStripButton1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripButton1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripButton1).Image = (Image)componentResourceManager.GetObject("ToolStripButton1.Image");
		((ToolStripItem)ToolStripButton1).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)ToolStripButton1).Name = "ToolStripButton1";
		((ToolStripItem)ToolStripButton1).Size = new Size(130, 21);
		((ToolStripItem)ToolStripButton1).Text = "Launch individually";
		((ToolStripItem)ToolStripButton3).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripButton3).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripButton3).Image = (Image)componentResourceManager.GetObject("ToolStripButton3.Image");
		((ToolStripItem)ToolStripButton3).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)ToolStripButton3).Name = "ToolStripButton3";
		((ToolStripItem)ToolStripButton3).Size = new Size(128, 21);
		((ToolStripItem)ToolStripButton3).Text = "Launch as group(s)";
		((ToolStripItem)TSB_AbortLaunch).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_AbortLaunch).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_AbortLaunch).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_AbortLaunch).Name = "TSB_AbortLaunch";
		((ToolStripItem)TSB_AbortLaunch).Size = new Size(83, 21);
		((ToolStripItem)TSB_AbortLaunch).Text = "Abort Launch";
		((ToolStripItem)ToolStripSeparator1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripSeparator1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripSeparator1).Margin = new Padding(0, 0, 2, 0);
		((ToolStripItem)ToolStripSeparator1).Name = "ToolStripSeparator1";
		((ToolStripItem)ToolStripSeparator1).Size = new Size(6, 24);
		((ToolStripItem)TSB_Doctrine).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_Doctrine).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSB_Doctrine).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_Doctrine).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_Doctrine).Name = "TSB_Doctrine";
		((ToolStripItem)TSB_Doctrine).Size = new Size(56, 21);
		((ToolStripItem)TSB_Doctrine).Text = "Doctrine";
		((ToolStripItem)TSB_AssignToMission).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_AssignToMission).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSB_AssignToMission).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_AssignToMission).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_AssignToMission).Name = "TSB_AssignToMission";
		((ToolStripItem)TSB_AssignToMission).Size = new Size(113, 21);
		((ToolStripItem)TSB_AssignToMission).Text = "Assign to mission";
		((ToolStripItem)ToolStripSeparator3).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripSeparator3).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripSeparator3).Margin = new Padding(0, 0, 2, 0);
		((ToolStripItem)ToolStripSeparator3).Name = "ToolStripSeparator3";
		((ToolStripItem)ToolStripSeparator3).Size = new Size(6, 24);
		((ToolStripItem)TSB_Cargo).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_Cargo).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSB_Cargo).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_Cargo).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_Cargo).Name = "TSB_Cargo";
		((ToolStripItem)TSB_Cargo).Size = new Size(98, 21);
		((ToolStripItem)TSB_Cargo).Text = " Un/Load Cargo ";
		SplitContainer1.Dock = (DockStyle)5;
		SplitContainer1.FixedPanel = (FixedPanel)2;
		((Control)SplitContainer1).Location = new Point(3, 3);
		((Control)SplitContainer1).Name = "SplitContainer1";
		SplitContainer1.Orientation = (Orientation)0;
		((Control)SplitContainer1.Panel1).Controls.Add((Control)(object)lblCapacity);
		((Control)SplitContainer1.Panel1).Controls.Add((Control)(object)btnHideUnderMaintenance);
		((Control)SplitContainer1.Panel1).Controls.Add((Control)(object)Splitter1);
		((Control)SplitContainer1.Panel1).Controls.Add((Control)(object)btnExpandShipList);
		((Control)SplitContainer1.Panel1).Controls.Add((Control)(object)TGV_Boats);
		((Control)SplitContainer1).Size = new Size(838, 497);
		SplitContainer1.SplitterDistance = 464;
		((Control)SplitContainer1).TabIndex = 0;
		((Control)lblCapacity).Anchor = (AnchorStyles)10;
		((Control)lblCapacity).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblCapacity).Location = new Point(627, 441);
		((Control)lblCapacity).Name = "lblCapacity";
		((Control)lblCapacity).Size = new Size(206, 23);
		((Control)lblCapacity).TabIndex = 38;
		((Label)lblCapacity).Text = "FacilityCapacity";
		((Label)lblCapacity).TextAlign = (ContentAlignment)64;
		((ButtonBase)btnHideUnderMaintenance).BackColor = Color.Transparent;
		((Control)btnHideUnderMaintenance).ForeColor = SystemColors.Control;
		((Control)btnHideUnderMaintenance).Location = new Point(114, 438);
		((Control)btnHideUnderMaintenance).Name = "btnHideUnderMaintenance";
		((Control)btnHideUnderMaintenance).Padding = new Padding(5);
		btnHideUnderMaintenance.RoundRadius = 0;
		((Control)btnHideUnderMaintenance).Size = new Size(111, 23);
		((Control)btnHideUnderMaintenance).TabIndex = 6;
		btnHideUnderMaintenance.Text = "Hide non-available";
		((Control)btnHideUnderMaintenance).Visible = false;
		((Control)Splitter1).Location = new Point(0, 0);
		((Control)Splitter1).Name = "Splitter1";
		((Control)Splitter1).Size = new Size(3, 464);
		((Control)Splitter1).TabIndex = 0;
		Splitter1.TabStop = false;
		((Control)btnExpandShipList).Anchor = (AnchorStyles)6;
		((ButtonBase)btnExpandShipList).BackColor = Color.Transparent;
		((Control)btnExpandShipList).ForeColor = SystemColors.Control;
		((Control)btnExpandShipList).Location = new Point(9, 438);
		((Control)btnExpandShipList).Name = "btnExpandShipList";
		((Control)btnExpandShipList).Padding = new Padding(5);
		btnExpandShipList.RoundRadius = 0;
		((Control)btnExpandShipList).Size = new Size(99, 23);
		((Control)btnExpandShipList).TabIndex = 0;
		btnExpandShipList.Text = "Collapse boat List";
		((DataGridView)TGV_Boats).AllowUserToAddRows = false;
		((DataGridView)TGV_Boats).AllowUserToDeleteRows = false;
		((DataGridView)TGV_Boats).AllowUserToOrderColumns = true;
		((Control)TGV_Boats).Anchor = (AnchorStyles)15;
		((DataGridView)TGV_Boats).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)TGV_Boats).BorderStyle = (BorderStyle)2;
		((DataGridView)TGV_Boats).CellBorderStyle = (DataGridViewCellBorderStyle)4;
		((DataGridView)TGV_Boats).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 8f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)TGV_Boats).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)TGV_Boats).ColumnHeadersHeight = 30;
		((DataGridView)TGV_Boats).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[8]
		{
			(DataGridViewColumn)Boat,
			(DataGridViewColumn)Damage,
			(DataGridViewColumn)Weapons,
			(DataGridViewColumn)Magazines,
			(DataGridViewColumn)Fuel,
			(DataGridViewColumn)Mission,
			(DataGridViewColumn)Status,
			(DataGridViewColumn)TimeToReady
		});
		((Control)TGV_Boats).ContextMenuStrip = (ContextMenuStrip)(object)CMenu_BoatOps;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Window;
		val2.Font = new Font("Segoe UI", 8f);
		val2.ForeColor = SystemColors.ControlText;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)TGV_Boats).DefaultCellStyle = val2;
		((DataGridView)TGV_Boats).EditMode = (DataGridViewEditMode)4;
		((DataGridView)TGV_Boats).EnableHeadersVisualStyles = false;
		TGV_Boats.ImageList = null;
		((Control)TGV_Boats).Location = new Point(0, 0);
		((Control)TGV_Boats).Name = "TGV_Boats";
		((DataGridView)TGV_Boats).RowHeadersVisible = false;
		((DataGridView)TGV_Boats).SelectionMode = (DataGridViewSelectionMode)1;
		TGV_Boats.ShowLines = false;
		((Control)TGV_Boats).Size = new Size(838, 435);
		((Control)TGV_Boats).TabIndex = 5;
		((DataGridViewColumn)Boat).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		val3.Font = new Font("Segoe UI", 8.25f, (FontStyle)4);
		val3.ForeColor = Color.Blue;
		((DataGridViewColumn)Boat).DefaultCellStyle = val3;
		Boat.DefaultNodeImage = null;
		((DataGridViewColumn)Boat).HeaderText = "Boat (click for DB info)";
		((DataGridViewColumn)Boat).Name = "Boat";
		((DataGridViewColumn)Boat).Resizable = (DataGridViewTriState)1;
		((DataGridViewTextBoxColumn)Boat).SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Damage).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		val4.Padding = new Padding(1);
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridViewColumn)Damage).DefaultCellStyle = val4;
		((DataGridViewColumn)Damage).HeaderText = "Damage (click for details)";
		Damage.LinkColor = Color.LightBlue;
		((DataGridViewColumn)Damage).Name = "Damage";
		((DataGridViewColumn)Damage).ReadOnly = true;
		((DataGridViewColumn)Weapons).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		val5.Padding = new Padding(1);
		val5.WrapMode = (DataGridViewTriState)1;
		((DataGridViewColumn)Weapons).DefaultCellStyle = val5;
		((DataGridViewColumn)Weapons).HeaderText = "Weapons (click for details)";
		Weapons.LinkColor = Color.LightBlue;
		((DataGridViewColumn)Weapons).Name = "Weapons";
		((DataGridViewColumn)Weapons).ReadOnly = true;
		((DataGridViewColumn)Magazines).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		val6.Padding = new Padding(1);
		val6.WrapMode = (DataGridViewTriState)1;
		((DataGridViewColumn)Magazines).DefaultCellStyle = val6;
		((DataGridViewColumn)Magazines).HeaderText = "Magazines (click for details)";
		Magazines.LinkColor = Color.LightBlue;
		((DataGridViewColumn)Magazines).Name = "Magazines";
		((DataGridViewColumn)Magazines).ReadOnly = true;
		((DataGridViewColumn)Fuel).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Fuel).HeaderText = "Fuel";
		((DataGridViewColumn)Fuel).Name = "Fuel";
		((DataGridViewColumn)Fuel).ReadOnly = true;
		Fuel.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Fuel).Width = 33;
		((DataGridViewColumn)Mission).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Mission).HeaderText = "Mission";
		((DataGridViewColumn)Mission).Name = "Mission";
		((DataGridViewColumn)Mission).Resizable = (DataGridViewTriState)1;
		Mission.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Status).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Status).HeaderText = "Status";
		((DataGridViewColumn)Status).Name = "Status";
		((DataGridViewColumn)Status).Resizable = (DataGridViewTriState)1;
		Status.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Status).Width = 43;
		((DataGridViewColumn)TimeToReady).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)TimeToReady).HeaderText = "Time to ready";
		((DataGridViewColumn)TimeToReady).MinimumWidth = 77;
		((DataGridViewColumn)TimeToReady).Name = "TimeToReady";
		((DataGridViewColumn)TimeToReady).Resizable = (DataGridViewTriState)1;
		TimeToReady.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)TimeToReady).Width = 77;
		((ToolStrip)CMenu_BoatOps).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)CMenu_BoatOps).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)CMenu_BoatOps).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[10]
		{
			(ToolStripItem)LaunchIndividuallyToolStripMenuItem,
			(ToolStripItem)LaunchAsGroupsToolStripMenuItem,
			(ToolStripItem)AbortLaunchToolStripMenuItem,
			(ToolStripItem)ToolStripSeparator2,
			(ToolStripItem)DoctrineToolStripMenuItem,
			(ToolStripItem)AssignToMissionToolStripMenuItem,
			(ToolStripItem)ToolStripSeparator4,
			(ToolStripItem)SetTimeToReadyToolStripMenuItem,
			(ToolStripItem)RenameToolStripMenuItem,
			(ToolStripItem)RemoveToolStripMenuItem
		});
		((Control)CMenu_BoatOps).Name = "CMenu_BoatOps";
		((Control)CMenu_BoatOps).Size = new Size(178, 194);
		((ToolStripItem)LaunchIndividuallyToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)LaunchIndividuallyToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)LaunchIndividuallyToolStripMenuItem).Name = "LaunchIndividuallyToolStripMenuItem";
		((ToolStripItem)LaunchIndividuallyToolStripMenuItem).Size = new Size(177, 22);
		((ToolStripItem)LaunchIndividuallyToolStripMenuItem).Text = "Launch individually";
		((ToolStripItem)LaunchAsGroupsToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)LaunchAsGroupsToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)LaunchAsGroupsToolStripMenuItem).Name = "LaunchAsGroupsToolStripMenuItem";
		((ToolStripItem)LaunchAsGroupsToolStripMenuItem).Size = new Size(177, 22);
		((ToolStripItem)LaunchAsGroupsToolStripMenuItem).Text = "Launch as group(s)";
		((ToolStripItem)AbortLaunchToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)AbortLaunchToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)AbortLaunchToolStripMenuItem).Name = "AbortLaunchToolStripMenuItem";
		((ToolStripItem)AbortLaunchToolStripMenuItem).Size = new Size(177, 22);
		((ToolStripItem)AbortLaunchToolStripMenuItem).Text = "Abort Launch";
		((ToolStripItem)ToolStripSeparator2).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripSeparator2).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripSeparator2).Margin = new Padding(0, 0, 0, 1);
		((ToolStripItem)ToolStripSeparator2).Name = "ToolStripSeparator2";
		((ToolStripItem)ToolStripSeparator2).Size = new Size(174, 6);
		((ToolStripItem)DoctrineToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)DoctrineToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)DoctrineToolStripMenuItem).Name = "DoctrineToolStripMenuItem";
		((ToolStripItem)DoctrineToolStripMenuItem).Size = new Size(177, 22);
		((ToolStripItem)DoctrineToolStripMenuItem).Text = "Doctrine";
		((ToolStripItem)AssignToMissionToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)AssignToMissionToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)AssignToMissionToolStripMenuItem).Name = "AssignToMissionToolStripMenuItem";
		((ToolStripItem)AssignToMissionToolStripMenuItem).Size = new Size(177, 22);
		((ToolStripItem)AssignToMissionToolStripMenuItem).Text = "Assign to mission";
		((ToolStripItem)ToolStripSeparator4).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripSeparator4).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripSeparator4).Margin = new Padding(0, 0, 0, 1);
		((ToolStripItem)ToolStripSeparator4).Name = "ToolStripSeparator4";
		((ToolStripItem)ToolStripSeparator4).Size = new Size(174, 6);
		((ToolStripItem)SetTimeToReadyToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)SetTimeToReadyToolStripMenuItem).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((ToolStripItem)SetTimeToReadyToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)SetTimeToReadyToolStripMenuItem).Name = "SetTimeToReadyToolStripMenuItem";
		((ToolStripItem)SetTimeToReadyToolStripMenuItem).Size = new Size(177, 22);
		((ToolStripItem)SetTimeToReadyToolStripMenuItem).Text = "Set time to ready";
		((ToolStripItem)RenameToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)RenameToolStripMenuItem).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((ToolStripItem)RenameToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)RenameToolStripMenuItem).Name = "RenameToolStripMenuItem";
		((ToolStripItem)RenameToolStripMenuItem).Size = new Size(177, 22);
		((ToolStripItem)RenameToolStripMenuItem).Text = "Rename";
		((ToolStripItem)RemoveToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)RemoveToolStripMenuItem).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((ToolStripItem)RemoveToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)RemoveToolStripMenuItem).Name = "RemoveToolStripMenuItem";
		((ToolStripItem)RemoveToolStripMenuItem).Size = new Size(177, 22);
		((ToolStripItem)RemoveToolStripMenuItem).Text = "Remove";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage2).Controls.Add((Control)(object)TV_Facilities);
		((Control)TabPage2).Controls.Add((Control)(object)TS_Edit);
		TabPage2.Location = new Point(4, 24);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Padding = new Padding(3);
		((Control)TabPage2).Size = new Size(844, 503);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Docking Facilities";
		((Control)TV_Facilities).Dock = (DockStyle)5;
		((Control)TV_Facilities).Font = new Font("Verdana", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)TV_Facilities).Location = new Point(3, 3);
		TV_Facilities.MaxDragChange = 20;
		((Control)TV_Facilities).Name = "TV_Facilities";
		((Control)TV_Facilities).Size = new Size(838, 472);
		((Control)TV_Facilities).TabIndex = 7;
		((ToolStrip)TS_Edit).AutoSize = false;
		((ToolStrip)TS_Edit).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)TS_Edit).Dock = (DockStyle)2;
		((ToolStrip)TS_Edit).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)TS_Edit).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)TS_Edit).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[2]
		{
			(ToolStripItem)Button_AddFac,
			(ToolStripItem)Button_RemoveFac
		});
		((Control)TS_Edit).Location = new Point(3, 475);
		((Control)TS_Edit).Name = "TS_Edit";
		((Control)TS_Edit).Padding = new Padding(5, 0, 1, 0);
		((Control)TS_Edit).Size = new Size(838, 25);
		((Control)TS_Edit).TabIndex = 7;
		((Control)TS_Edit).Text = "ToolStrip1";
		((ToolStripItem)Button_AddFac).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)Button_AddFac).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)Button_AddFac).Image = (Image)componentResourceManager.GetObject("Button_AddFac.Image");
		((ToolStripItem)Button_AddFac).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)Button_AddFac).Name = "Button_AddFac";
		((ToolStripItem)Button_AddFac).Size = new Size(93, 24);
		((ToolStripItem)Button_AddFac).Text = "Add Facility";
		((ToolStripItem)Button_RemoveFac).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)Button_RemoveFac).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)Button_RemoveFac).Image = (Image)componentResourceManager.GetObject("Button_RemoveFac.Image");
		((ToolStripItem)Button_RemoveFac).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)Button_RemoveFac).Name = "Button_RemoveFac";
		((ToolStripItem)Button_RemoveFac).Size = new Size(122, 24);
		((ToolStripItem)Button_RemoveFac).Text = "Remove Facilities";
		((ToolStripItem)TSB_SetReadyTime).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSB_SetReadyTime).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((ToolStripItem)TSB_SetReadyTime).ForeColor = Color.IndianRed;
		((ToolStripItem)TSB_SetReadyTime).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_SetReadyTime).Name = "TSB_SetReadyTime";
		((ToolStripItem)TSB_SetReadyTime).Size = new Size(108, 22);
		((ToolStripItem)TSB_SetReadyTime).Text = "Set time to ready";
		((ToolStripItem)TSB_Rename).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSB_Rename).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((ToolStripItem)TSB_Rename).ForeColor = Color.IndianRed;
		((ToolStripItem)TSB_Rename).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_Rename).Name = "TSB_Rename";
		((ToolStripItem)TSB_Rename).Size = new Size(57, 22);
		((ToolStripItem)TSB_Rename).Text = "Rename";
		((ToolStripItem)TSB_Delete).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSB_Delete).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((ToolStripItem)TSB_Delete).ForeColor = Color.IndianRed;
		((ToolStripItem)TSB_Delete).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_Delete).Name = "TSB_Delete";
		((ToolStripItem)TSB_Delete).Size = new Size(58, 22);
		((ToolStripItem)TSB_Delete).Text = "Remove";
		Timer1.Interval = 1000;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(852, 531);
		((Control)this).Controls.Add((Control)(object)TabControl1);
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "DockingOps";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Docking Operations";
		((Control)TabControl1).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)ToolStrip1).ResumeLayout(false);
		((Control)ToolStrip1).PerformLayout();
		((Control)SplitContainer1.Panel1).ResumeLayout(false);
		((ISupportInitialize)SplitContainer1).EndInit();
		((Control)SplitContainer1).ResumeLayout(false);
		((ISupportInitialize)(object)TGV_Boats).EndInit();
		((Control)CMenu_BoatOps).ResumeLayout(false);
		((Control)TabPage2).ResumeLayout(false);
		((Control)TS_Edit).ResumeLayout(false);
		((Control)TS_Edit).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual BackgroundWorker vmethod_0()
	{
		return backgroundWorker_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_1(BackgroundWorker WithEventsValue)
	{
		DoWorkEventHandler value = method_26;
		RunWorkerCompletedEventHandler value2 = method_27;
		BackgroundWorker backgroundWorker = backgroundWorker_0;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork -= value;
			backgroundWorker.RunWorkerCompleted -= value2;
		}
		backgroundWorker_0 = WithEventsValue;
		backgroundWorker = backgroundWorker_0;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork += value;
			backgroundWorker.RunWorkerCompleted += value2;
		}
	}

	public void ReleaseReferences()
	{
		try
		{
			if (((Control)this).Visible)
			{
				((Form)this).Close();
			}
			TGV_Boats.Nodes.Clear();
			TV_Facilities.Nodes.Clear();
			SelectedHosts.Clear();
			list_0.Clear();
			list_1.Clear();
			list_2.Clear();
			((ToolStripDropDownItem)TSB_AssignToMission).DropDownItems.Clear();
			((ToolStripDropDownItem)AssignToMissionToolStripMenuItem).DropDownItems.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
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

	private void DockingOps_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (!Client.Realtime)
		{
			if (bool_2)
			{
				Client.CurrentGame.Run();
			}
		}
		else
		{
			Client.RealtimeTerminal.SendDockingHostSelectionChange(null);
		}
		((Control)MyProject.Forms.MainForm).BringToFront();
		Timer1.Stop();
	}

	private void DockingOps_Load(object sender, EventArgs e)
	{
		((DataGridView)TGV_Boats).DefaultCellStyle.BackColor = Colors.DarkBackground;
		((DataGridView)TGV_Boats).DefaultCellStyle.ForeColor = Color.White;
		((TabControl)TabControl1).TabPages[0].BackColor = Colors.DarkBackground;
		((TabControl)TabControl1).TabPages[1].BackColor = Colors.DarkBackground;
		if (!Client.Realtime)
		{
			bool_2 = Client.CurrentGame.Status == Game._GameStatus.Running;
			if (bool_2)
			{
				Client.CurrentGame.Pause();
			}
		}
		else
		{
			Client.RealtimeTerminal.SendDockingHostSelectionChange(SelectedHosts);
		}
		if (SelectedHosts.Count > 1)
		{
			((Form)this).Text = "Docking Ops - Multiple host units";
		}
		else
		{
			((Form)this).Text = "Docking Ops - " + SelectedHosts[0].Name;
		}
		method_5();
		method_12();
		((ToolStripItem)TSB_SetReadyTime).Visible = Client.AllowEditModeActions;
		((ToolStripItem)TSB_Rename).Visible = Client.AllowEditModeActions;
		((ToolStripItem)TSB_Delete).Visible = Client.AllowEditModeActions;
		((ToolStripItem)SetTimeToReadyToolStripMenuItem).Visible = Client.AllowEditModeActions;
		((ToolStripItem)RenameToolStripMenuItem).Visible = Client.AllowEditModeActions;
		((ToolStripItem)RemoveToolStripMenuItem).Visible = Client.AllowEditModeActions;
		((ToolStripItem)ToolStripSeparator4).Visible = Client.AllowEditModeActions;
		((Control)TS_Edit).Visible = Client.AllowEditModeActions;
		((ToolStripItem)TSB_Cargo).Visible = true;
		Timer1.Start();
		if (!Client.Realtime)
		{
			ActiveUnit_DockingOps.Docking += method_4;
			ActiveUnit_DockingOps.DeployedToSea += method_6;
			if (Client.CurrentGame.Status == Game._GameStatus.Running && SimConfiguration.DefaultGamePreferences.PauseOnAirDockOps == SimConfiguration.WindowPauseBehaviour.Pause)
			{
				Client.CurrentGame.Pause();
			}
			else if (Client.CurrentGame.Status == Game._GameStatus.Running && SimConfiguration.DefaultGamePreferences.PauseOnAirDockOps == SimConfiguration.WindowPauseBehaviour.SlowToRealTime)
			{
				Client.CurrentScenario.TimeCompression_Set(Scenario.enumTimeCompression.OneSec);
			}
		}
	}

	private void method_2(Group group_0, ActiveUnit activeUnit_0)
	{
		_Closure$__207-0 arg = default(_Closure$__207-0);
		_Closure$__207-0 CS$<>8__locals7 = new _Closure$__207-0(arg);
		CS$<>8__locals7.$VB$Me = this;
		CS$<>8__locals7.$VB$Local_theGroup = group_0;
		CS$<>8__locals7.$VB$Local_theUnit = activeUnit_0;
		if (!((Control)this).InvokeRequired)
		{
			foreach (ActiveUnit selectedHost in SelectedHosts)
			{
				DarkTreeView tV_Facilities = TV_Facilities;
				DarkTreeNode darkTreeNode = new DarkTreeNode(selectedHost.Name);
				tV_Facilities.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = CS$<>8__locals7.$VB$Local_theUnit;
			}
			return;
		}
		((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
		{
			CS$<>8__locals7.$VB$Me.method_2(CS$<>8__locals7.$VB$Local_theGroup, CS$<>8__locals7.$VB$Local_theUnit);
		}));
	}

	private void method_3(Group group_0, ActiveUnit activeUnit_0)
	{
		_Closure$__208-0 arg = default(_Closure$__208-0);
		_Closure$__208-0 CS$<>8__locals7 = new _Closure$__208-0(arg);
		CS$<>8__locals7.$VB$Me = this;
		CS$<>8__locals7.$VB$Local_theGroup = group_0;
		CS$<>8__locals7.$VB$Local_theUnit = activeUnit_0;
		if (((Control)this).InvokeRequired)
		{
			((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				CS$<>8__locals7.$VB$Me.method_3(CS$<>8__locals7.$VB$Local_theGroup, CS$<>8__locals7.$VB$Local_theUnit);
			}));
			return;
		}
		foreach (ActiveUnit selectedHost in SelectedHosts)
		{
			_ = selectedHost;
			DarkTreeView tV_Facilities = TV_Facilities;
			foreach (DarkTreeNode node in tV_Facilities.Nodes)
			{
				if (node.Tag == CS$<>8__locals7.$VB$Local_theUnit)
				{
					tV_Facilities.Nodes.Remove(node);
					break;
				}
			}
		}
	}

	private void method_4(ActiveUnit activeUnit_0)
	{
		foreach (ActiveUnit selectedHost in SelectedHosts)
		{
			if (!Client.Realtime)
			{
				if (!selectedHost.DockingOps.EmbarkedBoats_ReadOnly.Contains(activeUnit_0))
				{
					list_1.Add(activeUnit_0);
				}
			}
			else if (Client.RealtimeTerminal.EmbarkedOps_GetEmbarkedBoats(selectedHost).Contains(activeUnit_0))
			{
				list_1.Add(activeUnit_0);
			}
		}
	}

	public void RefreshForm()
	{
		method_8();
		method_13();
	}

	private void method_5()
	{
		vmethod_0().RunWorkerAsync();
	}

	private void method_6(ActiveUnit activeUnit_0)
	{
		list_2.Add(activeUnit_0);
	}

	public void RefreshAll()
	{
		method_8();
		method_13();
		list_1.Clear();
		list_2.Clear();
	}

	private void method_7(object sender, EventArgs e)
	{
		if (!Client.Realtime)
		{
			if (Client.CurrentGame.Status == Game._GameStatus.Running)
			{
				RefreshAll();
			}
		}
		else if (Client.RealtimeTerminal.LastGameSpeed > 0 || Client.RealtimeTerminal.EmbarkedDockingOpsNewDataReceived)
		{
			Client.RealtimeTerminal.EmbarkedDockingOpsNewDataReceived = false;
			RefreshAll();
		}
	}

	private void method_8()
	{
		string string_ = default(string);
		string string_2 = default(string);
		string string_3 = default(string);
		string string_4 = default(string);
		string string_5 = default(string);
		string string_6 = default(string);
		string string_7 = default(string);
		foreach (TreeGridNode item in method_9())
		{
			TreeGridNode treeGridNode_ = item;
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(((DataGridViewBand)treeGridNode_).Tag)) && ((object)((DataGridViewBand)treeGridNode_).Tag.GetType() == typeof(Ship) || (object)((DataGridViewBand)treeGridNode_).Tag.GetType() == typeof(Submarine) || (object)((DataGridViewBand)treeGridNode_).Tag.GetType() == typeof(Vehicle)))
			{
				ActiveUnit activeUnit = (ActiveUnit)((DataGridViewBand)treeGridNode_).Tag;
				bool num = bool_5;
				string ReasonForNot = null;
				if (!(num & (activeUnit.IsAvailableForOps(ref ReasonForNot) == 2)))
				{
					((DataGridViewRow)treeGridNode_).Visible = true;
				}
				else
				{
					((DataGridViewRow)treeGridNode_).Visible = false;
				}
				method_22(activeUnit, ref string_, ref string_2, ref string_3, ref string_4, ref string_5, ref string_6, ref string_7);
				((DataGridViewRow)treeGridNode_).SetValues(new object[8] { activeUnit.Name, string_, string_2, string_3, string_4, string_5, string_6, string_7 });
				method_21(ref treeGridNode_, activeUnit);
			}
		}
		using (List<ActiveUnit>.Enumerator enumerator2 = list_2.GetEnumerator())
		{
			_Closure$__215-0 closure$__215- = default(_Closure$__215-0);
			while (enumerator2.MoveNext())
			{
				closure$__215- = new _Closure$__215-0(closure$__215-);
				closure$__215-.$VB$Local_theAU = enumerator2.Current;
				IEnumerable<TreeGridNode> source = method_9().Where(closure$__215-._Lambda$__0);
				if (source.Count() > 0)
				{
					source.ElementAtOrDefault(0).Parent.Nodes.Remove(source.ElementAtOrDefault(0));
				}
			}
		}
		bool flag = default(bool);
		foreach (ActiveUnit item2 in list_1)
		{
			foreach (TreeGridNode node in TGV_Boats.Nodes)
			{
				TreeGridNode treeGridNode_2 = node;
				if ((object)((object)treeGridNode_2).GetType() == typeof(List<ActiveUnit>))
				{
					method_22(item2, ref string_, ref string_2, ref string_3, ref string_4, ref string_5, ref string_6, ref string_7);
					((DataGridViewBand)treeGridNode_2.Nodes.Add(item2.Name, string_, string_2, string_3, string_4, string_5, string_6, string_7)).Tag = item2;
					method_21(ref treeGridNode_2, item2);
					flag = true;
				}
			}
			if (!flag)
			{
				TreeGridNode treeGridNode = TGV_Boats.Nodes.Add("1x " + Misc.RemoveHiddenString(item2.UnitClass));
				((DataGridViewBand)treeGridNode).Tag = item2.DBID;
				method_22(item2, ref string_, ref string_2, ref string_3, ref string_4, ref string_5, ref string_6, ref string_7);
				TreeGridNode treeGridNode_3 = treeGridNode.Nodes.Add(item2.Name, string_, string_2, string_3, string_4, string_5, string_6, string_7);
				((DataGridViewBand)treeGridNode_3).Tag = item2;
				method_21(ref treeGridNode_3, item2);
			}
		}
	}

	[SpecialName]
	private ReadOnlyCollection<TreeGridNode> method_9()
	{
		List<TreeGridNode> list = new List<TreeGridNode>();
		foreach (TreeGridNode node in TGV_Boats.Nodes)
		{
			if (!list.Contains(node))
			{
				list.Add(node);
			}
			method_10(node, list);
		}
		return list.AsReadOnly();
	}

	private void method_10(TreeGridNode treeGridNode_0, List<TreeGridNode> list_3)
	{
		foreach (TreeGridNode node in treeGridNode_0.Nodes)
		{
			if (!list_3.Contains(node))
			{
				list_3.Add(node);
			}
			method_10(node, list_3);
		}
	}

	private void method_11()
	{
		TGV_Boats.Nodes.Clear();
		_Closure$__219-0 closure$__219- = default(_Closure$__219-0);
		_Closure$__219-1 closure$__219-2 = default(_Closure$__219-1);
		_Closure$__219-2 closure$__219-3 = default(_Closure$__219-2);
		foreach (ActiveUnit selectedHost in SelectedHosts)
		{
			IEnumerable<int> enumerable;
			IEnumerable<int> enumerable2;
			IEnumerable<int> enumerable3;
			if (!Client.Realtime)
			{
				enumerable = (from theBoat in selectedHost.DockingOps.EmbarkedBoats_ReadOnly
					where theBoat.IsShip
					select theBoat.DBID).Distinct();
				enumerable2 = (from theBoat in selectedHost.DockingOps.EmbarkedBoats_ReadOnly
					where theBoat.IsSubmarine
					select theBoat.DBID).Distinct();
				enumerable3 = (from theBoat in selectedHost.DockingOps.EmbarkedBoats_ReadOnly
					where theBoat.IsVehicle
					select theBoat.DBID).Distinct();
			}
			else
			{
				enumerable = (from theBoat in Client.RealtimeTerminal.EmbarkedOps_GetEmbarkedBoats(selectedHost)
					where theBoat.IsShip
					select theBoat.DBID).Distinct();
				enumerable2 = (from theBoat in Client.RealtimeTerminal.EmbarkedOps_GetEmbarkedBoats(selectedHost)
					where theBoat.IsSubmarine
					select theBoat.DBID).Distinct();
				enumerable3 = (from theBoat in Client.RealtimeTerminal.EmbarkedOps_GetEmbarkedBoats(selectedHost)
					where theBoat.IsVehicle
					select theBoat.DBID).Distinct();
			}
			foreach (int item in enumerable)
			{
				closure$__219- = new _Closure$__219-0(closure$__219-);
				closure$__219-.$VB$Local_theDBID = item;
				IEnumerable<ActiveUnit> enumerable4 = (Client.Realtime ? (from theBoat in Client.RealtimeTerminal.EmbarkedOps_GetEmbarkedBoats(selectedHost).Where(closure$__219-._Lambda$__12)
					select (theBoat)) : (from theBoat in selectedHost.DockingOps.EmbarkedBoats_ReadOnly.Where(closure$__219-._Lambda$__14)
					select (theBoat)));
				string text = Conversions.ToString(enumerable4.Count()) + "x " + Misc.RemoveHiddenString(enumerable4.ElementAtOrDefault(0).UnitClass);
				if (SelectedHosts.Count > 1)
				{
					text = text + " (" + selectedHost.Name + ")";
				}
				TreeGridNode treeGridNode = TGV_Boats.Nodes.Add(text);
				((DataGridViewRow)treeGridNode).DefaultCellStyle.ForeColor = Color.DodgerBlue;
				((DataGridViewBand)treeGridNode).Tag = enumerable4;
				treeGridNode.Nodes.Add("Temp");
			}
			foreach (int item2 in enumerable2)
			{
				closure$__219-2 = new _Closure$__219-1(closure$__219-2);
				closure$__219-2.$VB$Local_theDBID = item2;
				IEnumerable<ActiveUnit> enumerable5 = ((!Client.Realtime) ? (from theBoat in selectedHost.DockingOps.EmbarkedBoats_ReadOnly.Where(closure$__219-2._Lambda$__18)
					select (theBoat)) : (from theBoat in Client.RealtimeTerminal.EmbarkedOps_GetEmbarkedBoats(selectedHost).Where(closure$__219-2._Lambda$__16)
					select (theBoat)));
				string text = Conversions.ToString(enumerable5.Count()) + "x " + Misc.RemoveHiddenString(enumerable5.ElementAtOrDefault(0).UnitClass);
				if (SelectedHosts.Count > 1)
				{
					text = text + " (" + selectedHost.Name + ")";
				}
				TreeGridNode treeGridNode2 = TGV_Boats.Nodes.Add(text);
				((DataGridViewRow)treeGridNode2).DefaultCellStyle.ForeColor = Color.DodgerBlue;
				((DataGridViewBand)treeGridNode2).Tag = enumerable5;
				treeGridNode2.Nodes.Add("Temp");
			}
			foreach (int item3 in enumerable3)
			{
				closure$__219-3 = new _Closure$__219-2(closure$__219-3);
				closure$__219-3.$VB$Local_theDBID = item3;
				IEnumerable<ActiveUnit> enumerable6 = ((!Client.Realtime) ? (from theBoat in selectedHost.DockingOps.EmbarkedBoats_ReadOnly.Where(closure$__219-3._Lambda$__22)
					select (theBoat)) : (from theBoat in Client.RealtimeTerminal.EmbarkedOps_GetEmbarkedBoats(selectedHost).Where(closure$__219-3._Lambda$__20)
					select (theBoat)));
				string text = Conversions.ToString(enumerable6.Count()) + "x " + Misc.RemoveHiddenString(enumerable6.ElementAtOrDefault(0).UnitClass);
				if (SelectedHosts.Count > 1)
				{
					text = text + " (" + selectedHost.Name + ")";
				}
				TreeGridNode treeGridNode3 = TGV_Boats.Nodes.Add(text);
				((DataGridViewRow)treeGridNode3).DefaultCellStyle.ForeColor = Color.DodgerBlue;
				((DataGridViewBand)treeGridNode3).Tag = enumerable6;
				treeGridNode3.Nodes.Add("Temp");
			}
			foreach (TreeGridNode node in TGV_Boats.Nodes)
			{
				node.Expand();
			}
			method_61(bool_7: true);
			method_62();
		}
	}

	private void method_12()
	{
		TV_Facilities.Nodes.Clear();
		foreach (ActiveUnit selectedHost in SelectedHosts)
		{
			if (!selectedHost.IsGroup)
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(selectedHost.Name);
				TV_Facilities.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = selectedHost;
				pveSepCqokn(selectedHost, darkTreeNode);
			}
			else
			{
				IEnumerable<ActiveUnit> enumerable = from theAU in ((Group)selectedHost).Units.Values
					select (theAU) into theAU
					orderby theAU.Name
					select theAU;
				foreach (ActiveUnit item in enumerable)
				{
					if (item.DockFacilities_ReadOnly.Length > 0)
					{
						DarkTreeNode darkTreeNode = new DarkTreeNode(item.Name);
						TV_Facilities.Nodes.Add(darkTreeNode);
						darkTreeNode.Tag = item;
						pveSepCqokn(item, darkTreeNode);
					}
				}
			}
			Module1.ExpandAll(TV_Facilities);
		}
	}

	private void method_13()
	{
		((Control)TV_Facilities).SuspendLayout();
		foreach (DarkTreeNode node in TV_Facilities.Nodes)
		{
			ActiveUnit activeUnit_ = (ActiveUnit)node.Tag;
			pveSepCqokn(activeUnit_, node);
		}
		((Control)TV_Facilities).ResumeLayout();
	}

	private void pveSepCqokn(ActiveUnit activeUnit_0, DarkTreeNode darkTreeNode_0)
	{
		IEnumerable<DockFacility> enumerable = from theAF in activeUnit_0.DockFacilities_ReadOnly
			select (theAF) into theAF
			orderby theAF.Name
			select theAF;
		double num = 0.0;
		double num2 = 0.0;
		foreach (DockFacility item in enumerable)
		{
			bool flag = false;
			foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
			{
				if (node.Tag == item)
				{
					flag = true;
					method_14(item, node);
					break;
				}
			}
			if (!flag)
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(item.Name);
				darkTreeNode_0.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = item;
				darkTreeNode.Expanded = true;
				foreach (ActiveUnit value in item.HostedBoats.Values)
				{
					DarkTreeNode darkTreeNode2 = new DarkTreeNode(value.Name + "(" + Misc.RemoveHiddenString(value.UnitClass) + "): " + value.DockingOps.ConditionString + " (" + Misc.TimeString((long)Math.Round(value.DockingOps.ConditionTimer)) + ")");
					darkTreeNode.Nodes.Add(darkTreeNode2);
					darkTreeNode2.Tag = value;
				}
			}
			num += (double)(item.MaximumSingleBoatLength * item.Capacity);
			num2 += num - (double)item.TotalCapacity_Free;
		}
		((Label)lblCapacity).Text = "Occupied " + num2 + " / " + num + " ( " + Math.Round(num2 / num * 100.0) + "% )";
		List<DarkTreeNode> list = new List<DarkTreeNode>();
		foreach (DarkTreeNode node2 in darkTreeNode_0.Nodes)
		{
			if (!activeUnit_0.DockFacilities_ReadOnly.Contains((DockFacility)node2.Tag))
			{
				list.Add(node2);
			}
		}
		foreach (DarkTreeNode item2 in list)
		{
			darkTreeNode_0.Nodes.Remove(item2);
		}
	}

	private void method_14(DockFacility dockFacility_0, DarkTreeNode darkTreeNode_0)
	{
		bool flag = default(bool);
		foreach (ActiveUnit value in dockFacility_0.HostedBoats.Values)
		{
			foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
			{
				if (node.Tag == value)
				{
					flag = true;
					node.Text = value.Name + "(" + Misc.RemoveHiddenString(value.UnitClass) + "): " + value.DockingOps.ConditionString + " (" + Misc.TimeString((long)Math.Round(value.DockingOps.ConditionTimer)) + ")";
					break;
				}
			}
			if (!flag)
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(value.Name + "(" + Misc.RemoveHiddenString(value.UnitClass) + "): " + value.DockingOps.ConditionString + " (" + Misc.TimeString((long)Math.Round(value.DockingOps.ConditionTimer)) + ")");
				darkTreeNode_0.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = value;
			}
		}
		List<DarkTreeNode> list = new List<DarkTreeNode>();
		foreach (DarkTreeNode node2 in darkTreeNode_0.Nodes)
		{
			if (!dockFacility_0.HostedBoats.Values.Contains((ActiveUnit)node2.Tag))
			{
				list.Add(node2);
			}
		}
		foreach (DarkTreeNode item in list)
		{
			darkTreeNode_0.Nodes.Remove(item);
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		switch (((TabControl)TabControl1).SelectedIndex)
		{
		case 0:
			method_5();
			break;
		case 1:
			method_12();
			break;
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		method_17();
	}

	private void method_17()
	{
		method_18(bool_7: true, bool_8: false);
		switch (list_0.Count)
		{
		case 1:
			list_0[0].DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
			break;
		default:
			foreach (ActiveUnit item in list_0)
			{
				item.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
			}
			break;
		case 0:
			break;
		}
		if (Client.Realtime)
		{
			Client.RealtimeTerminal.SendLaunchEmbarkedUnitMessage(null, new List<string>(list_0.Select([SpecialName] (ActiveUnit F) => F.ObjectID)));
		}
		method_8();
	}

	private void method_18(bool bool_7, bool bool_8)
	{
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		list_0.Clear();
		foreach (TreeGridNode node in TGV_Boats.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected)
				{
					list_0.Add((ActiveUnit)((DataGridViewBand)node2).Tag);
				}
			}
		}
		if (bool_7)
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			foreach (ActiveUnit item2 in list_0)
			{
				if (item2.get_UnitSide(SetSideOnly: false) != Client.CurrentSide)
				{
					list.Add(item2);
				}
			}
			if (list.Count > 0)
			{
				DarkMessageBox.ShowWarning(Conversions.ToString(list.Count) + " of the selected boats are allied units not under your direct control.", "Allied boats selected!");
				foreach (ActiveUnit item3 in list)
				{
					list_0.Remove(item3);
				}
			}
		}
		List<ActiveUnit> list2 = new List<ActiveUnit>();
		foreach (ActiveUnit item4 in list_0)
		{
			string ReasonForNot = null;
			if (item4.IsAvailableForOps(ref ReasonForNot) != 0)
			{
				list2.Add(item4);
			}
		}
		if (list2.Count <= 0)
		{
			return;
		}
		DarkMessageBox.ShowWarning(Conversions.ToString(list2.Count) + " of the selected boats are unavailable for operations, and will not launch.", "Unavailable boats selected!");
		foreach (Aircraft item5 in list2)
		{
			list_0.Remove(item5);
		}
	}

	private void method_19(object sender, CollapsingEventArgs e)
	{
		if (e.Node.Level == 1)
		{
			hashSet_0.Remove(e.Node);
		}
	}

	private void method_20(object sender, ExpandingEventArgs e)
	{
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		e.Node.Nodes.Clear();
		if (e.Node.Level != 1)
		{
			return;
		}
		_ = ((IEnumerable<ActiveUnit>)((DataGridViewBand)e.Node).Tag).ElementAtOrDefault(0).UnitClass;
		hashSet_0.Add(e.Node);
		List<ActiveUnit> list = ((IEnumerable<ActiveUnit>)((DataGridViewBand)e.Node).Tag).ToList().OrderBy([SpecialName] (ActiveUnit theAU) => theAU.Name, new NaturalSortComparer<string[]>()).ToList()
			.ToList();
		if (bool_4)
		{
			list = list.OrderBy([SpecialName] (ActiveUnit theU) => theU.DockingOps.ConditionTimer).ToList();
		}
		string string_ = default(string);
		string string_2 = default(string);
		string string_3 = default(string);
		string string_4 = default(string);
		string string_5 = default(string);
		string string_6 = default(string);
		string string_7 = default(string);
		foreach (ActiveUnit item in list)
		{
			method_22(item, ref string_, ref string_2, ref string_3, ref string_4, ref string_5, ref string_6, ref string_7);
			TreeGridNode treeGridNode_ = e.Node.Nodes.Add(item.Name, string_, string_2, string_3, string_4, string_5, string_6, string_7);
			((DataGridViewRow)treeGridNode_).DefaultCellStyle.ForeColor = Color.LightGray;
			((DataGridViewRow)treeGridNode_).DefaultCellStyle.Font = new Font(((Control)this).Font, (FontStyle)0);
			((DataGridViewBand)treeGridNode_).Tag = item;
			method_21(ref treeGridNode_, item);
		}
	}

	private void method_21(ref TreeGridNode treeGridNode_0, ActiveUnit activeUnit_0)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		if (activeUnit_0.AI.IsAllowedToRedeploy_Damage)
		{
			((DataGridViewLinkCell)treeGridNode_0.Cells[1]).LinkColor = Color.LightGreen;
		}
		else
		{
			((DataGridViewLinkCell)treeGridNode_0.Cells[1]).LinkColor = Color.PaleVioletRed;
		}
		if (activeUnit_0.AI.IsAllowedToRedeploy_AttackWeapon && activeUnit_0.AI.IsAllowedToRedeploy_DefenceWeapon)
		{
			((DataGridViewLinkCell)treeGridNode_0.Cells[2]).LinkColor = Color.LightGreen;
			((DataGridViewLinkCell)treeGridNode_0.Cells[3]).LinkColor = Color.LightGreen;
		}
		else
		{
			((DataGridViewLinkCell)treeGridNode_0.Cells[2]).LinkColor = Color.PaleVioletRed;
			((DataGridViewLinkCell)treeGridNode_0.Cells[3]).LinkColor = Color.PaleVioletRed;
		}
		if (!activeUnit_0.AI.IsAllowedToRedeploy_Fuel)
		{
			treeGridNode_0.Cells[4].Style.ForeColor = Color.PaleVioletRed;
		}
		else
		{
			treeGridNode_0.Cells[4].Style.ForeColor = Color.LightGreen;
		}
	}

	private void method_22(ActiveUnit activeUnit_0, ref string string_0, ref string string_1, ref string string_2, ref string string_3, ref string string_4, ref string string_5, ref string string_6)
	{
		if (activeUnit_0.Damage.DamagePercent > 0f)
		{
			string_0 = string.Format("{0:0.0}", activeUnit_0.Damage.DamagePercent, 1) + "% damage, ";
		}
		else
		{
			string_0 = "No structural damage, ";
		}
		_ = activeUnit_0.Components().Count;
		int num = (from theC in activeUnit_0.Components()
			where theC.Status != PlatformComponent._ComponentStatus.Operational
			select theC).Count();
		if (num > 0)
		{
			string_0 = string_0 + Conversions.ToString(num) + " systems offline";
		}
		else
		{
			string_0 += "all systems online";
		}
		string text = "";
		string text2 = "";
		string text3 = "";
		List<WeaponRec> list = new List<WeaponRec>();
		List<WeaponRec> list2 = new List<WeaponRec>();
		List<WeaponRec> list3 = new List<WeaponRec>();
		foreach (Mount mount in activeUnit_0.Mounts)
		{
			foreach (WeaponRec mountWeapon in mount.MountWeapons)
			{
				switch (mountWeapon.get_ReferenceWeapon(Client.CurrentScenario).Type)
				{
				case Weapon._WeaponType.GuidedWeapon:
				case Weapon._WeaponType.Torpedo:
					list.Add(mountWeapon);
					break;
				default:
					list3.Add(mountWeapon);
					break;
				case Weapon._WeaponType.Rocket:
				case Weapon._WeaponType.IronBomb:
				case Weapon._WeaponType.Gun:
				case Weapon._WeaponType.Dispenser:
				case Weapon._WeaponType.DepthCharge:
				case Weapon._WeaponType.BottomMine:
				case Weapon._WeaponType.FloatingMine:
				case Weapon._WeaponType.MovingMine:
				case Weapon._WeaponType.RisingMine:
				case Weapon._WeaponType.DriftingMine:
				case Weapon._WeaponType.DummyMine:
					list2.Add(mountWeapon);
					break;
				}
			}
			if (Information.IsNothing((object)mount.MountMagazine))
			{
				continue;
			}
			foreach (WeaponRec weapon in mount.MountMagazine.Weapons)
			{
				switch (weapon.get_ReferenceWeapon(Client.CurrentScenario).Type)
				{
				case Weapon._WeaponType.GuidedWeapon:
				case Weapon._WeaponType.Torpedo:
					list.Add(weapon);
					break;
				default:
					list3.Add(weapon);
					break;
				case Weapon._WeaponType.Rocket:
				case Weapon._WeaponType.IronBomb:
				case Weapon._WeaponType.Gun:
				case Weapon._WeaponType.Dispenser:
				case Weapon._WeaponType.DepthCharge:
				case Weapon._WeaponType.BottomMine:
				case Weapon._WeaponType.FloatingMine:
				case Weapon._WeaponType.MovingMine:
				case Weapon._WeaponType.RisingMine:
				case Weapon._WeaponType.DriftingMine:
				case Weapon._WeaponType.DummyMine:
					list2.Add(weapon);
					break;
				}
			}
		}
		List<string> list4 = new List<string>();
		if (list.Count > 0)
		{
			text = "Guided: " + Conversions.ToString(list.Select([SpecialName] (WeaponRec theWR) => theWR.CurrentLoad).Sum()) + "/" + Conversions.ToString(list.Select([SpecialName] (WeaponRec theWR) => theWR.DefaultLoad).Sum());
			list4.Add(text);
		}
		if (list2.Count > 0)
		{
			text2 = "Unguided: " + Conversions.ToString(list2.Select([SpecialName] (WeaponRec theWR) => theWR.CurrentLoad).Sum()) + "/" + Conversions.ToString(list2.Select([SpecialName] (WeaponRec theWR) => theWR.DefaultLoad).Sum());
			list4.Add(text2);
		}
		if (list3.Count > 0)
		{
			text3 = "Other: " + Conversions.ToString(list3.Select([SpecialName] (WeaponRec theWR) => theWR.CurrentLoad).Sum()) + "/" + Conversions.ToString(list3.Select([SpecialName] (WeaponRec theWR) => theWR.DefaultLoad).Sum());
			list4.Add(text3);
		}
		string_1 = string.Join("\r\n", list4);
		list.Clear();
		list2.Clear();
		list3.Clear();
		list4.Clear();
		Magazine[] totalMagazines = activeUnit_0.TotalMagazines;
		foreach (Magazine magazine in totalMagazines)
		{
			foreach (WeaponRec weapon2 in magazine.Weapons)
			{
				switch (weapon2.get_ReferenceWeapon(Client.CurrentScenario).Type)
				{
				case Weapon._WeaponType.GuidedWeapon:
				case Weapon._WeaponType.Torpedo:
					list.Add(weapon2);
					break;
				default:
					list3.Add(weapon2);
					break;
				case Weapon._WeaponType.Rocket:
				case Weapon._WeaponType.IronBomb:
				case Weapon._WeaponType.Gun:
				case Weapon._WeaponType.Dispenser:
				case Weapon._WeaponType.DepthCharge:
				case Weapon._WeaponType.BottomMine:
				case Weapon._WeaponType.FloatingMine:
				case Weapon._WeaponType.MovingMine:
				case Weapon._WeaponType.RisingMine:
				case Weapon._WeaponType.DriftingMine:
				case Weapon._WeaponType.DummyMine:
					list2.Add(weapon2);
					break;
				}
			}
		}
		if (list.Count > 0)
		{
			text = "Guided: " + Conversions.ToString(list.Select([SpecialName] (WeaponRec theWR) => theWR.CurrentLoad).Sum()) + "/" + Conversions.ToString(list.Select([SpecialName] (WeaponRec theWR) => theWR.DefaultLoad).Sum());
			list4.Add(text);
		}
		if (list2.Count > 0)
		{
			text2 = "Unguided: " + Conversions.ToString(list2.Select([SpecialName] (WeaponRec theWR) => theWR.CurrentLoad).Sum()) + "/" + Conversions.ToString(list2.Select([SpecialName] (WeaponRec theWR) => theWR.DefaultLoad).Sum());
			list4.Add(text2);
		}
		if (list3.Count > 0)
		{
			text3 = "Other: " + Conversions.ToString(list3.Select([SpecialName] (WeaponRec theWR) => theWR.CurrentLoad).Sum()) + "/" + Conversions.ToString(list3.Select([SpecialName] (WeaponRec theWR) => theWR.DefaultLoad).Sum());
			list4.Add(text3);
		}
		string_2 = string.Join("\r\n", list4);
		double TotalCurrent = 0.0;
		double TotalMax = 0.0;
		string_3 = string.Format("{0:0.0}", activeUnit_0.FuelPercent(ref TotalCurrent, ref TotalMax, MissionFuel: false) * 100.0, 1) + "%";
		if (Information.IsNothing((object)activeUnit_0.ActiveMissionOrPackage()))
		{
			string_4 = "-";
		}
		else
		{
			string text4 = "";
			if (activeUnit_0.AI.IsEscort)
			{
				text4 = ", Escort";
			}
			string_4 = activeUnit_0.ActiveMissionOrPackage().Name + " (" + activeUnit_0.ActiveMissionOrPackage().get_DescriptionString(Client.CurrentScenario) + text4 + ")";
		}
		string_5 = activeUnit_0.DockingOps.ConditionString;
		if (activeUnit_0.OnboardCargo.Count() > 0 || activeUnit_0.IsOnActiveCargoMission)
		{
			int percentFull = CargoHostHelper.GetPercentFull((ICargoHost)activeUnit_0);
			string_5 += " (Cargo: ";
			if (percentFull > 0)
			{
				string_5 = string_5 + percentFull + "%)";
			}
			else
			{
				string_5 += " empty)";
			}
		}
		string_6 = Misc.TimeString((long)Math.Round(activeUnit_0.DockingOps.ConditionTimer));
	}

	private void method_23(object sender, EventArgs e)
	{
		method_24();
	}

	private void method_24()
	{
		method_18(bool_7: true, bool_8: true);
		Misc.FormIntoGroups(list_0, Client.CurrentScenario, Client.CurrentSide, Misc.GroupingLogic.MixedGroup);
		switch (list_0.Count)
		{
		case 1:
			list_0[0].DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
			break;
		default:
			foreach (ActiveUnit item in list_0)
			{
				item.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
			}
			break;
		case 0:
			break;
		}
		if (Client.Realtime)
		{
			Client.RealtimeTerminal.SendLaunchEmbarkedUnitMessage(null, null, null, new List<string>(list_0.Select([SpecialName] (ActiveUnit F) => F.ObjectID)));
		}
		method_8();
	}

	private void method_25(object sender, EventArgs e)
	{
		if (!((Control)this).Visible)
		{
			return;
		}
		list_0.Clear();
		foreach (TreeGridNode node in TGV_Boats.Nodes)
		{
			_ = ((DataGridViewRow)node).Selected;
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (!((DataGridViewRow)node2).Selected)
				{
					continue;
				}
				if (!((ActiveUnit)((DataGridViewBand)node2).Tag).IsShip)
				{
					if (((ActiveUnit)((DataGridViewBand)node2).Tag).IsSubmarine)
					{
						list_0.Add((Submarine)((DataGridViewBand)node2).Tag);
					}
					else if (((ActiveUnit)((DataGridViewBand)node2).Tag).IsVehicle)
					{
						list_0.Add((Vehicle)((DataGridViewBand)node2).Tag);
					}
				}
				else
				{
					list_0.Add((Ship)((DataGridViewBand)node2).Tag);
				}
			}
		}
		if (list_0.Count == 1 && Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
		{
			Client.SelectThisUnit(list_0[0], ThisUnitOnly: true);
		}
		if (list_0.Count > 0)
		{
			((ToolStripItem)ToolStripButton1).Enabled = true;
			((ToolStripItem)TSB_Cargo).Enabled = false;
			foreach (ICargoHost item in list_0)
			{
				if (item.GetCargo_Type() != CargoType.NoCargo)
				{
					((ToolStripItem)TSB_Cargo).Enabled = true;
				}
			}
			((ToolStripItem)ToolStripButton3).Enabled = true;
			((ToolStripItem)TSB_AbortLaunch).Enabled = true;
			((ToolStripItem)TSB_Doctrine).Enabled = true;
			((ToolStripItem)TSB_AssignToMission).Enabled = true;
			if (Client.AllowEditModeActions)
			{
				((ToolStripItem)TSB_SetReadyTime).Enabled = true;
				((ToolStripItem)TSB_Rename).Enabled = true;
				((ToolStripItem)TSB_Delete).Enabled = true;
				((ToolStripMenuItem)SetTimeToReadyToolStripMenuItem).Enabled = true;
				((ToolStripMenuItem)RenameToolStripMenuItem).Enabled = true;
				((ToolStripMenuItem)RemoveToolStripMenuItem).Enabled = true;
			}
		}
		else
		{
			((ToolStripItem)ToolStripButton1).Enabled = false;
			((ToolStripItem)TSB_Cargo).Enabled = false;
			((ToolStripItem)ToolStripButton3).Enabled = false;
			((ToolStripItem)TSB_AbortLaunch).Enabled = false;
			((ToolStripItem)TSB_Doctrine).Enabled = false;
			((ToolStripItem)TSB_AssignToMission).Enabled = false;
			if (Client.AllowEditModeActions)
			{
				((ToolStripItem)TSB_SetReadyTime).Enabled = false;
				((ToolStripItem)TSB_Rename).Enabled = false;
				((ToolStripItem)TSB_Delete).Enabled = false;
				((ToolStripMenuItem)SetTimeToReadyToolStripMenuItem).Enabled = false;
				((ToolStripMenuItem)RenameToolStripMenuItem).Enabled = false;
				((ToolStripMenuItem)RemoveToolStripMenuItem).Enabled = false;
			}
		}
		if (list_0.Count <= 1)
		{
			return;
		}
		Client.CurrentSide.SelectedUnits_Clear();
		foreach (ActiveUnit item2 in list_0)
		{
			Client.CurrentSide.SelectedUnits_Add(item2);
		}
	}

	private void method_26(object sender, DoWorkEventArgs e)
	{
		Thread.Sleep(10);
	}

	private void method_27(object sender, RunWorkerCompletedEventArgs e)
	{
		method_11();
	}

	private void DockingOps_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Invalid comparison between Unknown and I4
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Invalid comparison between Unknown and I4
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Invalid comparison between Unknown and I4
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Invalid comparison between Unknown and I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Invalid comparison between Unknown and I4
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Invalid comparison between Unknown and I4
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Invalid comparison between Unknown and I4
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 118 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if (!((Control)this).Visible || ((int)e.KeyCode != 33 && (int)e.KeyCode != 34 && (int)e.KeyCode != 38 && (int)e.KeyCode != 40 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39 && (int)e.KeyCode != 107 && (int)e.KeyCode != 109 && (int)e.KeyCode != 35 && (int)e.KeyCode != 36))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void DockingOps_FormClosed(object sender, FormClosedEventArgs e)
	{
		if (!Client.Realtime)
		{
			ActiveUnit_DockingOps.Docking -= method_4;
			ActiveUnit_DockingOps.DeployedToSea -= method_6;
		}
	}

	private void method_28(object sender, EventArgs e)
	{
		method_29();
	}

	private void method_29()
	{
		method_18(bool_7: true, bool_8: false);
		foreach (ActiveUnit item in list_0)
		{
			if (item.DockingOps.IsDeploying)
			{
				item.DockingOps.AttemptToStartDocking(item.DockingOps.CurrentHostUnit, CancelDeployment: true);
			}
		}
		if (Client.Realtime)
		{
			Client.RealtimeTerminal.SendLaunchEmbarkedUnitMessage(null, null, null, null, null, new List<string>(list_0.Select([SpecialName] (ActiveUnit F) => F.ObjectID)));
		}
		method_8();
	}

	private void method_30()
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		list_0.Clear();
		foreach (TreeGridNode node in TGV_Boats.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected)
				{
					list_0.Add((ActiveUnit)((DataGridViewBand)node2).Tag);
				}
			}
		}
		((ToolStripDropDownItem)TSB_AssignToMission).DropDownItems.Clear();
		if (list_0.Count <= 0)
		{
			return;
		}
		new ToolStripMenuItem();
		((ToolStripItem)(ToolStripMenuItem)((ToolStrip)((ToolStripDropDownItem)TSB_AssignToMission).DropDown).Items.Add("< Unassign >", (Image)null, (EventHandler)method_32)).Tag = null;
		IEnumerable<Mission> enumerable = Client.CurrentSide.Missions.OrderBy([SpecialName] (Mission theM) => theM.Name);
		foreach (Mission item in enumerable)
		{
			if (item.Category == Command_Core.Mission.MissionCategory.TaskPool || item.Category == Command_Core.Mission.MissionCategory.Package)
			{
				continue;
			}
			ToolStripMenuItem val = new ToolStripMenuItem();
			ToolStripMenuItem val2 = new ToolStripMenuItem();
			val = (ToolStripMenuItem)((ToolStrip)((ToolStripDropDownItem)TSB_AssignToMission).DropDown).Items.Add(item.Name, (Image)null, (EventHandler)method_32);
			((ToolStripItem)val).Tag = item;
			if (item.MissionClass == Command_Core.Mission._MissionClass.Strike)
			{
				val2 = (ToolStripMenuItem)((ToolStrip)((ToolStripDropDownItem)TSB_AssignToMission).DropDown).Items.Add(item.Name + " - Escort", (Image)null, (EventHandler)method_32);
				((ToolStripItem)val2).Tag = item;
			}
			if (list_0.Count != 1)
			{
				continue;
			}
			ActiveUnit activeUnit = list_0[0];
			if (item == activeUnit.ActiveMissionOrPackage())
			{
				if (item.MissionClass == Command_Core.Mission._MissionClass.Strike && activeUnit.AI.IsEscort)
				{
					val2.Checked = true;
				}
				else
				{
					val.Checked = true;
				}
			}
		}
	}

	private void method_31(object sender, EventArgs e)
	{
		method_18(bool_7: true, bool_8: false);
		if (list_0.Count > 0)
		{
			MainForm mainForm = MyProject.Forms.MainForm;
			ReadOnlyCollection<Module_Unit.Unit> theSelectedUnits = null;
			mainForm.ShowDoctrineROE(null, ref theSelectedUnits, ref list_0, UnitIsOperating: false);
		}
	}

	private void method_32(object sender, EventArgs e)
	{
	}

	private void method_33(object sender, EventArgs e)
	{
		method_30();
	}

	private void method_34(object sender, ToolStripItemClickedEventArgs e)
	{
		method_35(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void method_35(object sender, ToolStripItemClickedEventArgs e)
	{
		method_18(bool_7: true, bool_8: false);
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(e.ClickedItem.Tag)))
		{
			foreach (ActiveUnit item in list_0)
			{
				ActiveUnit theAU = item;
				Client.RemoveUnitFromMission(ref theAU);
			}
		}
		else
		{
			Mission theMission = (Mission)e.ClickedItem.Tag;
			bool isEscort = Strings.InStr(e.ClickedItem.Text, " - Escort", (CompareMethod)1) != 0;
			Client.AssignToMission(RuntimeHelpers.GetObjectValue(sender), list_0, ref theMission, ref isEscort);
		}
		RefreshForm();
	}

	private void method_36(object sender, EventArgs e)
	{
		method_17();
	}

	private void method_37(object sender, EventArgs e)
	{
		method_24();
	}

	private void method_38(object sender, EventArgs e)
	{
		method_29();
	}

	private void method_39(object sender, EventArgs e)
	{
		method_18(bool_7: true, bool_8: false);
		if (list_0.Count > 0)
		{
			MainForm mainForm = MyProject.Forms.MainForm;
			ReadOnlyCollection<Module_Unit.Unit> theSelectedUnits = null;
			mainForm.ShowDoctrineROE(null, ref theSelectedUnits, ref list_0, UnitIsOperating: false);
		}
	}

	private void method_40(object sender, EventArgs e)
	{
	}

	private void method_41()
	{
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		if (list_0.Count <= 0)
		{
			((ToolStripMenuItem)LaunchIndividuallyToolStripMenuItem).Enabled = false;
			((ToolStripMenuItem)LaunchAsGroupsToolStripMenuItem).Enabled = false;
			((ToolStripMenuItem)AbortLaunchToolStripMenuItem).Enabled = false;
			((ToolStripMenuItem)DoctrineToolStripMenuItem).Enabled = false;
			((ToolStripMenuItem)AssignToMissionToolStripMenuItem).Enabled = false;
		}
		else
		{
			((ToolStripMenuItem)LaunchIndividuallyToolStripMenuItem).Enabled = true;
			((ToolStripMenuItem)LaunchAsGroupsToolStripMenuItem).Enabled = true;
			((ToolStripMenuItem)AbortLaunchToolStripMenuItem).Enabled = true;
			((ToolStripMenuItem)DoctrineToolStripMenuItem).Enabled = true;
			((ToolStripMenuItem)AssignToMissionToolStripMenuItem).Enabled = true;
		}
		list_0.Clear();
		foreach (TreeGridNode node in TGV_Boats.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected)
				{
					list_0.Add((ActiveUnit)((DataGridViewBand)node2).Tag);
				}
			}
		}
		((ToolStripDropDownItem)AssignToMissionToolStripMenuItem).DropDownItems.Clear();
		if (list_0.Count <= 0)
		{
			return;
		}
		new ToolStripMenuItem();
		((ToolStripItem)(ToolStripMenuItem)((ToolStrip)((ToolStripDropDownItem)AssignToMissionToolStripMenuItem).DropDown).Items.Add("< Unassign >", (Image)null, (EventHandler)method_40)).Tag = null;
		IEnumerable<Mission> enumerable = Client.CurrentSide.Missions.OrderBy([SpecialName] (Mission theM) => theM.Name);
		foreach (Mission item in enumerable)
		{
			if (item.Category == Command_Core.Mission.MissionCategory.TaskPool || item.Category == Command_Core.Mission.MissionCategory.Package)
			{
				continue;
			}
			ToolStripMenuItem val = new ToolStripMenuItem();
			ToolStripMenuItem val2 = new ToolStripMenuItem();
			val = (ToolStripMenuItem)((ToolStrip)((ToolStripDropDownItem)AssignToMissionToolStripMenuItem).DropDown).Items.Add(item.Name, (Image)null, (EventHandler)method_40);
			((ToolStripItem)val).Tag = item;
			if (item.MissionClass == Command_Core.Mission._MissionClass.Strike)
			{
				val2 = (ToolStripMenuItem)((ToolStrip)((ToolStripDropDownItem)AssignToMissionToolStripMenuItem).DropDown).Items.Add(item.Name + " - Escort", (Image)null, (EventHandler)method_40);
				((ToolStripItem)val2).Tag = item;
			}
			if (list_0.Count != 1)
			{
				continue;
			}
			ActiveUnit activeUnit = list_0[0];
			if (item == activeUnit.ActiveMissionOrPackage())
			{
				if (item.MissionClass == Command_Core.Mission._MissionClass.Strike && activeUnit.AI.IsEscort)
				{
					val2.Checked = true;
				}
				else
				{
					val.Checked = true;
				}
			}
		}
	}

	private void method_42(object sender, CancelEventArgs e)
	{
		method_41();
	}

	private void method_43(object sender, ToolStripItemClickedEventArgs e)
	{
		method_35(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void method_44(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			TreeGridNode currentNode = TGV_Boats.CurrentNode;
			if (currentNode == null || ((DataGridViewBand)currentNode).Tag == null)
			{
				return;
			}
			string name = ((DataGridView)TGV_Boats).Columns[e.ColumnIndex].Name;
			if (Operators.CompareString(name, "Boat", true) == 0)
			{
				try
				{
					if ((object)((DataGridViewBand)currentNode).Tag.GetType() != typeof(Ship) && (object)((DataGridViewBand)currentNode).Tag.GetType() != typeof(Submarine) && (object)((DataGridViewBand)currentNode).Tag.GetType() != typeof(Vehicle))
					{
						ActiveUnit activeUnit;
						try
						{
							activeUnit = (ActiveUnit)((DataGridViewBand)currentNode).Tag;
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							if (e.RowIndex == -1)
							{
								ProjectData.ClearProjectError();
								return;
							}
							activeUnit = ((IEnumerable<ActiveUnit>)((DataGridViewBand)currentNode).Tag).ElementAtOrDefault(0);
							ProjectData.ClearProjectError();
						}
						if (activeUnit != null)
						{
							int dBID = activeUnit.DBID;
							if (activeUnit.IsShip)
							{
								Client.smethod_17("Ship", dBID);
							}
							else if (activeUnit.IsSubmarine)
							{
								Client.smethod_17("Submarine", dBID);
							}
							else if (activeUnit.IsVehicle)
							{
								Client.smethod_17("Ground Unit", dBID);
							}
						}
					}
					return;
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
					return;
				}
			}
			if (Operators.CompareString(name, "Damage", true) == 0)
			{
				try
				{
					ActiveUnit activeUnit2;
					try
					{
						activeUnit2 = (ActiveUnit)((DataGridViewBand)currentNode).Tag;
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						ProjectData.ClearProjectError();
						return;
					}
					if (activeUnit2 != null)
					{
						Client.theDamageControlWindow = new DamageControlWindow();
						Client.theDamageControlWindow.theSelectedUnit = activeUnit2;
						Client.theDamageControlWindow.theCurrentGame = Client.CurrentGame;
						((Control)Client.theDamageControlWindow).Show();
					}
					return;
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					ProjectData.ClearProjectError();
					return;
				}
			}
			if (Operators.CompareString(name, "Weapons", true) == 0)
			{
				try
				{
					ActiveUnit activeUnit3;
					try
					{
						activeUnit3 = (ActiveUnit)((DataGridViewBand)currentNode).Tag;
					}
					catch (Exception projectError5)
					{
						ProjectData.SetProjectError(projectError5);
						ProjectData.ClearProjectError();
						return;
					}
					if (activeUnit3 != null)
					{
						Client.theWeaponsWindow.theSelectedUnit = activeUnit3;
						((Control)Client.theWeaponsWindow).Show();
					}
					return;
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					ProjectData.ClearProjectError();
					return;
				}
			}
			if (Operators.CompareString(name, "Magazines", true) != 0)
			{
				return;
			}
			try
			{
				ActiveUnit activeUnit4;
				try
				{
					activeUnit4 = (ActiveUnit)((DataGridViewBand)currentNode).Tag;
				}
				catch (Exception projectError7)
				{
					ProjectData.SetProjectError(projectError7);
					ProjectData.ClearProjectError();
					return;
				}
				if (activeUnit4 != null)
				{
					Client.theMagazinesWindow = new Magazines();
					Client.theMagazinesWindow.SelectedUnit = activeUnit4;
					((Control)Client.theMagazinesWindow).Show();
				}
			}
			catch (Exception projectError8)
			{
				ProjectData.SetProjectError(projectError8);
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200379", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_45(object sender, EventArgs e)
	{
		method_46();
	}

	private void method_46()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (TreeGridNode node in TGV_Boats.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected)
				{
					list.Add((ActiveUnit)((DataGridViewBand)node2).Tag);
				}
			}
		}
		MyProject.Forms.TimeToReadyWindow.SelectedUnits = list;
		((Control)MyProject.Forms.TimeToReadyWindow).Show();
	}

	private void method_47(object sender, EventArgs e)
	{
		method_48();
	}

	private void method_48()
	{
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Invalid comparison between Unknown and I4
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (TreeGridNode node in TGV_Boats.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected)
				{
					list.Add((ActiveUnit)((DataGridViewBand)node2).Tag);
				}
			}
		}
		if (list.Count == 1)
		{
			MyProject.Forms.RenameObject.RenamingOption = RenameObject.E_RenamingOption.Unit_Generic;
			MyProject.Forms.RenameObject.SelectedName = list[0].Name;
			if ((int)((Form)MyProject.Forms.RenameObject).ShowDialog() == 1)
			{
				list[0].Name = MyProject.Forms.RenameObject.SelectedName;
			}
			method_8();
			method_13();
		}
	}

	private void method_49(object sender, EventArgs e)
	{
		method_50();
	}

	private void method_50()
	{
		List<TreeGridNode> list = new List<TreeGridNode>();
		foreach (TreeGridNode node in TGV_Boats.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected)
				{
					list.Add(node2);
				}
			}
		}
		foreach (TreeGridNode item in list)
		{
			ActiveUnit value = (ActiveUnit)((DataGridViewBand)item).Tag;
			value.DockingOps.HostDockFacility.HostedBoats.TryRemove(value.ObjectID, out value);
			Client.CurrentScenario.DeleteUnitImmediately(value.ObjectID, ScenEditAction: true, "Unit deleted");
			item.Parent.Nodes.Remove(item);
		}
		if (Client.CurrentGame.Status == Game._GameStatus.Paused)
		{
			MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, v: false);
		}
		method_11();
	}

	private void method_51(object sender, EventArgs e)
	{
		method_46();
	}

	private void method_52(object sender, EventArgs e)
	{
		method_48();
	}

	private void method_53(object sender, EventArgs e)
	{
		method_50();
	}

	private void method_54(object sender, EventArgs e)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		method_18(bool_7: true, bool_8: false);
		switch (list_0.Count)
		{
		case 1:
		{
			ActiveUnit activeUnit = list_0[0];
			MyProject.Forms.CargoOpsV2.CargoUnit = activeUnit;
			MyProject.Forms.CargoOpsV2.HostUnit = activeUnit.CurrentHostUnitCargoSource;
			((Control)MyProject.Forms.CargoOpsV2).Show();
			break;
		}
		default:
			DarkMessageBox.ShowError("Select one docked boat only.", "");
			break;
		case 0:
			break;
		}
		method_8();
	}

	private ActiveUnit method_55()
	{
		if (SelectedHosts.Count == 1)
		{
			return SelectedHosts.First();
		}
		if (TV_Facilities.SelectedNodes.Count == 1)
		{
			DarkTreeNode darkTreeNode = TV_Facilities.SelectedNodes.First();
			foreach (ActiveUnit selectedHost in SelectedHosts)
			{
				if (darkTreeNode.Tag == selectedHost)
				{
					return selectedHost;
				}
			}
		}
		return null;
	}

	private void method_56(object sender, EventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		ActiveUnit activeUnit = method_55();
		if (activeUnit == null)
		{
			DarkMessageBox.ShowError("Select a single hosting unit from the facilities list to add facilities.", "No Hosting Unit");
			return;
		}
		MyProject.Forms.AddHostingFacility.Mode = 1;
		MyProject.Forms.AddHostingFacility.ParentForm = (Form)(object)this;
		MyProject.Forms.AddHostingFacility.theSelectedUnit = activeUnit;
		((Control)MyProject.Forms.AddHostingFacility).Show();
	}

	private void method_57(object sender, EventArgs e)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Invalid comparison between Unknown and I4
		ActiveUnit activeUnit = null;
		if (TV_Facilities.SelectedNodes.Count > 0)
		{
			foreach (DarkTreeNode selectedNode in TV_Facilities.SelectedNodes)
			{
				if (selectedNode.Tag == null || (object)selectedNode.Tag.GetType() != typeof(DockFacility))
				{
					continue;
				}
				DockFacility dockFacility = (DockFacility)selectedNode.Tag;
				if (dockFacility.ParentPlatform == null)
				{
					continue;
				}
				bool flag = true;
				if (dockFacility.HostedBoats.Count > 0 && (int)DarkMessageBox.ShowWarning("Facility " + dockFacility.Name + " has one or more boats present. Removing this facility will delete the boats from your scenario.", "Delete Boats?", DarkDialogButton.OkCancel) == 2)
				{
					flag = false;
				}
				if (!flag)
				{
					continue;
				}
				if (dockFacility.HostedBoats.Count > 0)
				{
					foreach (ActiveUnit value in dockFacility.HostedBoats.Values)
					{
						method_6(value);
						Client.CurrentScenario.DeleteUnitImmediately(value.ObjectID, ScenEditAction: true, "Manually deleted by user", null, RegisterAsLosses: false);
					}
				}
				activeUnit = dockFacility.ParentPlatform;
				activeUnit.RemoveDockFacility(dockFacility);
			}
		}
		if (activeUnit != null)
		{
			RefreshForm();
			MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, activeUnit, v: false);
		}
	}

	private void DockingOps_Shown(object sender, EventArgs e)
	{
	}

	private void method_58(object sender, EventArgs e)
	{
		bool_5 = !bool_5;
		if (bool_5)
		{
			btnHideUnderMaintenance.Text = "Show non-available";
		}
		else
		{
			btnHideUnderMaintenance.Text = "Hide non-available";
		}
		method_8();
	}

	private void method_59(object sender, EventArgs e)
	{
		bool_3 = !bool_3;
		method_60();
	}

	private void method_60()
	{
		if (!bool_3)
		{
			TGV_Boats.CollapseAllItem();
			btnExpandShipList.Text = "Expand boat list";
		}
		else
		{
			TGV_Boats.ExpandAllItems();
			btnExpandShipList.Text = "Collapse boat list";
		}
		method_8();
	}

	private void method_61(bool bool_7)
	{
		bool_3 = bool_7;
		if (bool_3)
		{
			btnExpandShipList.Text = "Collapse boat list";
		}
		else
		{
			btnExpandShipList.Text = "Expand boat list";
		}
	}

	private void method_62()
	{
		DataGridViewColumn obj = ((DataGridView)TGV_Boats).Columns[7];
		obj.SortMode = (DataGridViewColumnSortMode)2;
		obj.HeaderCell.SortGlyphDirection = (SortOrder)2;
	}

	private void method_63(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.ColumnIndex == 7)
		{
			bool_4 = true;
		}
		else
		{
			bool_4 = false;
		}
		foreach (TreeGridNode item in method_9())
		{
			if (item.IsExpanded)
			{
				ExpandingEventArgs e2 = new ExpandingEventArgs(item);
				method_20(item, e2);
			}
		}
	}

	static DockingOps()
	{
		Class72.smethod_20();
	}
}
