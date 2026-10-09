using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Collections.Pooled;
using Command_Core;
using Command.My;
using DarkUI.Config;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AttackTarget : DarkSecondaryFormBase, GInterface0
{
	[CompilerGenerated]
	internal sealed class _Closure$__243-0
	{
		public ActiveUnit $VB$Local_theAttacker;

		public Func<Warhead, int> $I0;

		public _Closure$__243-0(_Closure$__243-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAttacker = arg0.$VB$Local_theAttacker;
			}
		}

		[SpecialName]
		internal int _Lambda$__0(Warhead CW)
		{
			return CW.get_CarriedWeapon($VB$Local_theAttacker.ParentScen).DBID;
		}

		static _Closure$__243-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("TabControl4")]
	[CompilerGenerated]
	private DarkUITabControl _TabControl4;

	[CompilerGenerated]
	[AccessedThroughProperty("LB_Targets")]
	private DarkListView _LB_Targets;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_Allocations_ByAttackersOnly")]
	private DarkTreeView _TV_Allocations_ByAttackersOnly;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_Allocations_ByAnyone")]
	private DarkTreeView _TV_Allocations_ByAnyone;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private Timer timer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("TabControl2")]
	private DarkUITabControl _TabControl2;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_Allocations_ToTargetsOnly")]
	private DarkTreeView _TV_Allocations_ToTargetsOnly;

	[AccessedThroughProperty("TV_Allocations_ToAnyone")]
	[CompilerGenerated]
	private DarkTreeView _TV_Allocations_ToAnyone;

	[AccessedThroughProperty("LB_Attackers")]
	[CompilerGenerated]
	private DarkListView _LB_Attackers;

	[AccessedThroughProperty("TV_AvailableWeapons")]
	[CompilerGenerated]
	private DarkTreeView _TV_AvailableWeapons;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Allocate")]
	private DarkUIButton _Button_Allocate;

	[AccessedThroughProperty("Button_AllocateAllWeapons")]
	[CompilerGenerated]
	private DarkUIButton _Button_AllocateAllWeapons;

	[AccessedThroughProperty("Button_UnitWRA")]
	[CompilerGenerated]
	private DarkUIButton _Button_UnitWRA;

	[AccessedThroughProperty("Button_AddAttacker")]
	[CompilerGenerated]
	private DarkUIButton _Button_AddAttacker;

	[AccessedThroughProperty("Button_AddTarget")]
	[CompilerGenerated]
	private DarkUIButton _Button_AddTarget;

	[AccessedThroughProperty("Button_RemoveAttacker")]
	[CompilerGenerated]
	private DarkUIButton _Button_RemoveAttacker;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RemoveTargets")]
	private DarkUIButton _Button_RemoveTargets;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AllocateSalvo")]
	private DarkUIButton _Button_AllocateSalvo;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RemoveWeapons_Target")]
	private DarkUIButton _Button_RemoveWeapons_Target;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RemoveWeapons_Attacker")]
	private DarkUIButton _Button_RemoveWeapons_Attacker;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AllowTimeout")]
	private DarkCheckBox _CB_AllowTimeout;

	[AccessedThroughProperty("CB_ShowAutomaticFireInfo")]
	[CompilerGenerated]
	private DarkCheckBox _CB_ShowAutomaticFireInfo;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ClearCourse_Attacker")]
	private DarkUIButton _Button_ClearCourse_Attacker;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_PlotCourse_Attacker")]
	private DarkUIButton _Button_PlotCourse_Attacker;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ClearCourse_Target")]
	private DarkUIButton _Button_ClearCourse_Target;

	[AccessedThroughProperty("Button_PlotCourse_Target")]
	[CompilerGenerated]
	private DarkUIButton _Button_PlotCourse_Target;

	[AccessedThroughProperty("TSMI_HighAltitudeDetonation")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _TSMI_HighAltitudeDetonation;

	[AccessedThroughProperty("Button_Execute")]
	[CompilerGenerated]
	private DarkUIButton _Button_Execute;

	[CompilerGenerated]
	private bool bool_2;

	protected bool IsRefreshing;

	private bool bool_3;

	public List<Contact> Targets;

	public List<ActiveUnit> Attackers;

	private List<ActiveUnit> list_0;

	private int int_0;

	private List<Contact> list_1;

	private int int_1;

	private DarkTreeNode darkTreeNode_0;

	private int? nullable_0;

	private int int_2;

	private bool bool_4;

	private bool bool_5;

	private string string_0;

	private WeaponSalvo weaponSalvo_0;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private Keys[] keys_0;

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	internal virtual DarkUITabControl TabControl4
	{
		[CompilerGenerated]
		get
		{
			return _TabControl4;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_36;
			DarkUITabControl darkUITabControl = _TabControl4;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged -= eventHandler;
			}
			_TabControl4 = value;
			darkUITabControl = _TabControl4;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Tab_Target_BySelected")]
	internal virtual TabPage Tab_Target_BySelected { get; set; }

	[field: AccessedThroughProperty("Tab_Target_ByAnyone")]
	internal virtual TabPage Tab_Target_ByAnyone { get; set; }

	internal virtual DarkListView LB_Targets
	{
		[CompilerGenerated]
		get
		{
			return _LB_Targets;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_16;
			DarkListView darkListView = _LB_Targets;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
			}
			_LB_Targets = value;
			darkListView = _LB_Targets;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

	internal virtual DarkTreeView TV_Allocations_ByAttackersOnly
	{
		[CompilerGenerated]
		get
		{
			return _TV_Allocations_ByAttackersOnly;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(method_46);
			MouseEventHandler val2 = new MouseEventHandler(method_53);
			EventHandler value2 = method_56;
			DarkTreeView darkTreeView = _TV_Allocations_ByAttackersOnly;
			if (darkTreeView != null)
			{
				((Control)darkTreeView).MouseClick -= val;
				((Control)darkTreeView).MouseDoubleClick -= val2;
				darkTreeView.SelectedNodesChanged -= value2;
			}
			_TV_Allocations_ByAttackersOnly = value;
			darkTreeView = _TV_Allocations_ByAttackersOnly;
			if (darkTreeView != null)
			{
				((Control)darkTreeView).MouseClick += val;
				((Control)darkTreeView).MouseDoubleClick += val2;
				darkTreeView.SelectedNodesChanged += value2;
			}
		}
	}

	internal virtual DarkTreeView TV_Allocations_ByAnyone
	{
		[CompilerGenerated]
		get
		{
			return _TV_Allocations_ByAnyone;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Expected O, but got Unknown
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(method_45);
			MouseEventHandler val2 = new MouseEventHandler(method_54);
			EventHandler value2 = method_58;
			DarkTreeView darkTreeView = _TV_Allocations_ByAnyone;
			if (darkTreeView != null)
			{
				((Control)darkTreeView).MouseClick -= val;
				((Control)darkTreeView).MouseDoubleClick -= val2;
				darkTreeView.SelectedNodesChanged -= value2;
			}
			_TV_Allocations_ByAnyone = value;
			darkTreeView = _TV_Allocations_ByAnyone;
			if (darkTreeView != null)
			{
				((Control)darkTreeView).MouseClick += val;
				((Control)darkTreeView).MouseDoubleClick += val2;
				darkTreeView.SelectedNodesChanged += value2;
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
			EventHandler eventHandler = method_3;
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

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	internal virtual DarkUITabControl TabControl2
	{
		[CompilerGenerated]
		get
		{
			return _TabControl2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			DarkUITabControl darkUITabControl = _TabControl2;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged -= eventHandler;
			}
			_TabControl2 = value;
			darkUITabControl = _TabControl2;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Tab_Attacker_ToSelectedOnly")]
	internal virtual TabPage Tab_Attacker_ToSelectedOnly { get; set; }

	internal virtual DarkTreeView TV_Allocations_ToTargetsOnly
	{
		[CompilerGenerated]
		get
		{
			return _TV_Allocations_ToTargetsOnly;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(method_48);
			MouseEventHandler val2 = new MouseEventHandler(method_50);
			EventHandler value2 = method_55;
			DarkTreeView darkTreeView = _TV_Allocations_ToTargetsOnly;
			if (darkTreeView != null)
			{
				((Control)darkTreeView).MouseClick -= val;
				((Control)darkTreeView).MouseDoubleClick -= val2;
				darkTreeView.SelectedNodesChanged -= value2;
			}
			_TV_Allocations_ToTargetsOnly = value;
			darkTreeView = _TV_Allocations_ToTargetsOnly;
			if (darkTreeView != null)
			{
				((Control)darkTreeView).MouseClick += val;
				((Control)darkTreeView).MouseDoubleClick += val2;
				darkTreeView.SelectedNodesChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Tab_Attacker_ToAnyone")]
	internal virtual TabPage Tab_Attacker_ToAnyone { get; set; }

	internal virtual DarkTreeView TV_Allocations_ToAnyone
	{
		[CompilerGenerated]
		get
		{
			return _TV_Allocations_ToAnyone;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(method_47);
			MouseEventHandler val2 = new MouseEventHandler(method_51);
			EventHandler value2 = method_57;
			DarkTreeView darkTreeView = _TV_Allocations_ToAnyone;
			if (darkTreeView != null)
			{
				((Control)darkTreeView).MouseClick -= val;
				((Control)darkTreeView).MouseDoubleClick -= val2;
				darkTreeView.SelectedNodesChanged -= value2;
			}
			_TV_Allocations_ToAnyone = value;
			darkTreeView = _TV_Allocations_ToAnyone;
			if (darkTreeView != null)
			{
				((Control)darkTreeView).MouseClick += val;
				((Control)darkTreeView).MouseDoubleClick += val2;
				darkTreeView.SelectedNodesChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual DarkListView LB_Attackers
	{
		[CompilerGenerated]
		get
		{
			return _LB_Attackers;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_15;
			DarkListView darkListView = _LB_Attackers;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
			}
			_LB_Attackers = value;
			darkListView = _LB_Attackers;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	internal virtual DarkTreeView TV_AvailableWeapons
	{
		[CompilerGenerated]
		get
		{
			return _TV_AvailableWeapons;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(method_29);
			EventHandler value2 = method_52;
			DarkTreeView darkTreeView = _TV_AvailableWeapons;
			if (darkTreeView != null)
			{
				((Control)darkTreeView).MouseDoubleClick -= val;
				darkTreeView.SelectedNodesChanged -= value2;
			}
			_TV_AvailableWeapons = value;
			darkTreeView = _TV_AvailableWeapons;
			if (darkTreeView != null)
			{
				((Control)darkTreeView).MouseDoubleClick += val;
				darkTreeView.SelectedNodesChanged += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_Allocate
	{
		[CompilerGenerated]
		get
		{
			return _Button_Allocate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_24;
			DarkUIButton darkUIButton = _Button_Allocate;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Allocate = value;
			darkUIButton = _Button_Allocate;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_AllocateAllWeapons
	{
		[CompilerGenerated]
		get
		{
			return _Button_AllocateAllWeapons;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_26;
			DarkUIButton darkUIButton = _Button_AllocateAllWeapons;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_AllocateAllWeapons = value;
			darkUIButton = _Button_AllocateAllWeapons;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_UnitWRA
	{
		[CompilerGenerated]
		get
		{
			return _Button_UnitWRA;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			DarkUIButton darkUIButton = _Button_UnitWRA;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_UnitWRA = value;
			darkUIButton = _Button_UnitWRA;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_AddAttacker
	{
		[CompilerGenerated]
		get
		{
			return _Button_AddAttacker;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			DarkUIButton darkUIButton = _Button_AddAttacker;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_AddAttacker = value;
			darkUIButton = _Button_AddAttacker;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_AddTarget
	{
		[CompilerGenerated]
		get
		{
			return _Button_AddTarget;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkUIButton darkUIButton = _Button_AddTarget;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_AddTarget = value;
			darkUIButton = _Button_AddTarget;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_RemoveAttacker
	{
		[CompilerGenerated]
		get
		{
			return _Button_RemoveAttacker;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = bgnLjhMuiIh;
			DarkUIButton darkUIButton = _Button_RemoveAttacker;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_RemoveAttacker = value;
			darkUIButton = _Button_RemoveAttacker;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_RemoveTargets
	{
		[CompilerGenerated]
		get
		{
			return _Button_RemoveTargets;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkUIButton darkUIButton = _Button_RemoveTargets;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_RemoveTargets = value;
			darkUIButton = _Button_RemoveTargets;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_AllocateSalvo
	{
		[CompilerGenerated]
		get
		{
			return _Button_AllocateSalvo;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			DarkUIButton darkUIButton = _Button_AllocateSalvo;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_AllocateSalvo = value;
			darkUIButton = _Button_AllocateSalvo;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_RemoveWeapons_Target
	{
		[CompilerGenerated]
		get
		{
			return _Button_RemoveWeapons_Target;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			DarkUIButton darkUIButton = _Button_RemoveWeapons_Target;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_RemoveWeapons_Target = value;
			darkUIButton = _Button_RemoveWeapons_Target;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_RemoveWeapons_Attacker
	{
		[CompilerGenerated]
		get
		{
			return _Button_RemoveWeapons_Attacker;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_27;
			DarkUIButton darkUIButton = _Button_RemoveWeapons_Attacker;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_RemoveWeapons_Attacker = value;
			darkUIButton = _Button_RemoveWeapons_Attacker;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1 { get; set; }

	[field: AccessedThroughProperty("TableLayoutPanel2")]
	internal virtual TableLayoutPanel TableLayoutPanel2 { get; set; }

	[field: AccessedThroughProperty("TableLayoutPanel3")]
	internal virtual TableLayoutPanel TableLayoutPanel3 { get; set; }

	[field: AccessedThroughProperty("Panel1")]
	internal virtual Panel Panel1 { get; set; }

	[field: AccessedThroughProperty("Panel2")]
	internal virtual Panel Panel2 { get; set; }

	[field: AccessedThroughProperty("Panel3")]
	internal virtual Panel Panel3 { get; set; }

	[field: AccessedThroughProperty("Panel4")]
	internal virtual Panel Panel4 { get; set; }

	[field: AccessedThroughProperty("Panel5")]
	internal virtual Panel Panel5 { get; set; }

	internal virtual DarkCheckBox CB_AllowTimeout
	{
		[CompilerGenerated]
		get
		{
			return _CB_AllowTimeout;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_37;
			DarkCheckBox darkCheckBox = _CB_AllowTimeout;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_AllowTimeout = value;
			darkCheckBox = _CB_AllowTimeout;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_ShowAutomaticFireInfo
	{
		[CompilerGenerated]
		get
		{
			return _CB_ShowAutomaticFireInfo;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_38;
			DarkCheckBox darkCheckBox = _CB_ShowAutomaticFireInfo;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_ShowAutomaticFireInfo = value;
			darkCheckBox = _CB_ShowAutomaticFireInfo;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ClearCourse_Attacker
	{
		[CompilerGenerated]
		get
		{
			return _Button_ClearCourse_Attacker;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_40;
			DarkUIButton darkUIButton = _Button_ClearCourse_Attacker;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ClearCourse_Attacker = value;
			darkUIButton = _Button_ClearCourse_Attacker;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_PlotCourse_Attacker
	{
		[CompilerGenerated]
		get
		{
			return _Button_PlotCourse_Attacker;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_39;
			DarkUIButton darkUIButton = _Button_PlotCourse_Attacker;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_PlotCourse_Attacker = value;
			darkUIButton = _Button_PlotCourse_Attacker;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ClearCourse_Target
	{
		[CompilerGenerated]
		get
		{
			return _Button_ClearCourse_Target;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_42;
			DarkUIButton darkUIButton = _Button_ClearCourse_Target;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ClearCourse_Target = value;
			darkUIButton = _Button_ClearCourse_Target;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_PlotCourse_Target
	{
		[CompilerGenerated]
		get
		{
			return _Button_PlotCourse_Target;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_41;
			DarkUIButton darkUIButton = _Button_PlotCourse_Target;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_PlotCourse_Target = value;
			darkUIButton = _Button_PlotCourse_Target;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("SalvoContextMenu")]
	internal virtual DarkContextMenu SalvoContextMenu { get; set; }

	[field: AccessedThroughProperty("NUD_NumberOfWeapons")]
	internal virtual DarkNumericUpDown NUD_NumberOfWeapons { get; set; }

	internal virtual DarkToolStripMenuItem TSMI_HighAltitudeDetonation
	{
		[CompilerGenerated]
		get
		{
			return _TSMI_HighAltitudeDetonation;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_43;
			DarkToolStripMenuItem darkToolStripMenuItem = _TSMI_HighAltitudeDetonation;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_TSMI_HighAltitudeDetonation = value;
			darkToolStripMenuItem = _TSMI_HighAltitudeDetonation;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("SplitContainerOuter")]
	internal virtual SplitContainer SplitContainerOuter { get; set; }

	[field: AccessedThroughProperty("SplitContainerInner")]
	internal virtual SplitContainer SplitContainerInner { get; set; }

	internal virtual DarkUIButton Button_Execute
	{
		[CompilerGenerated]
		get
		{
			return _Button_Execute;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_59;
			DarkUIButton darkUIButton = _Button_Execute;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Execute = value;
			darkUIButton = _Button_Execute;
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
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
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
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Expected O, but got Unknown
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Expected O, but got Unknown
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Expected O, but got Unknown
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Expected O, but got Unknown
		//IL_054b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Expected O, but got Unknown
		//IL_0592: Unknown result type (might be due to invalid IL or missing references)
		//IL_0605: Unknown result type (might be due to invalid IL or missing references)
		//IL_060f: Expected O, but got Unknown
		//IL_069d: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a7: Expected O, but got Unknown
		//IL_0736: Unknown result type (might be due to invalid IL or missing references)
		//IL_0740: Expected O, but got Unknown
		//IL_077d: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fd: Expected O, but got Unknown
		//IL_083a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0962: Unknown result type (might be due to invalid IL or missing references)
		//IL_096c: Expected O, but got Unknown
		//IL_09a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2a: Expected O, but got Unknown
		//IL_0a67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ace: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad8: Expected O, but got Unknown
		//IL_0b6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b79: Expected O, but got Unknown
		//IL_0c0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c14: Expected O, but got Unknown
		//IL_0c90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9a: Expected O, but got Unknown
		//IL_0cac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb6: Expected O, but got Unknown
		//IL_0e61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e6b: Expected O, but got Unknown
		//IL_0f09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f13: Expected O, but got Unknown
		//IL_0f50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd1: Expected O, but got Unknown
		//IL_100e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1080: Unknown result type (might be due to invalid IL or missing references)
		//IL_108a: Expected O, but got Unknown
		//IL_112b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1135: Expected O, but got Unknown
		//IL_1172: Unknown result type (might be due to invalid IL or missing references)
		//IL_11fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1204: Expected O, but got Unknown
		//IL_128a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1294: Expected O, but got Unknown
		//IL_1307: Unknown result type (might be due to invalid IL or missing references)
		//IL_1311: Expected O, but got Unknown
		//IL_138d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1397: Expected O, but got Unknown
		//IL_13a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b3: Expected O, but got Unknown
		//IL_13c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_13cf: Expected O, but got Unknown
		//IL_14ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f7: Expected O, but got Unknown
		//IL_1535: Unknown result type (might be due to invalid IL or missing references)
		//IL_15af: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b9: Expected O, but got Unknown
		//IL_15f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1671: Unknown result type (might be due to invalid IL or missing references)
		//IL_167b: Expected O, but got Unknown
		//IL_16bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_175c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1766: Expected O, but got Unknown
		//IL_1825: Unknown result type (might be due to invalid IL or missing references)
		//IL_1897: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a1: Expected O, but got Unknown
		//IL_194c: Unknown result type (might be due to invalid IL or missing references)
		//IL_19be: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c8: Expected O, but got Unknown
		//IL_1a46: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a50: Expected O, but got Unknown
		//IL_1bbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bc8: Expected O, but got Unknown
		//IL_1c06: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c8b: Expected O, but got Unknown
		//IL_1ccc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d46: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d50: Expected O, but got Unknown
		//IL_1d8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e37: Expected O, but got Unknown
		//IL_1ef6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f68: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f72: Expected O, but got Unknown
		//IL_201d: Unknown result type (might be due to invalid IL or missing references)
		//IL_208f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2099: Expected O, but got Unknown
		//IL_2117: Unknown result type (might be due to invalid IL or missing references)
		//IL_2121: Expected O, but got Unknown
		//IL_2412: Unknown result type (might be due to invalid IL or missing references)
		//IL_241c: Expected O, but got Unknown
		//IL_2458: Unknown result type (might be due to invalid IL or missing references)
		icontainer_1 = new Container();
		Timer1 = new Timer(icontainer_1);
		TableLayoutPanel1 = new TableLayoutPanel();
		Panel1 = new Panel();
		Button_RemoveAttacker = new DarkUIButton();
		Label1 = new DarkLabel();
		LB_Attackers = new DarkListView();
		Button_UnitWRA = new DarkUIButton();
		Button_AddAttacker = new DarkUIButton();
		Panel5 = new Panel();
		Button_RemoveTargets = new DarkUIButton();
		Button_AddTarget = new DarkUIButton();
		LB_Targets = new DarkListView();
		Label3 = new DarkLabel();
		TableLayoutPanel2 = new TableLayoutPanel();
		Panel2 = new Panel();
		CB_ShowAutomaticFireInfo = new DarkCheckBox();
		CB_AllowTimeout = new DarkCheckBox();
		Button_AllocateSalvo = new DarkUIButton();
		Button_AllocateAllWeapons = new DarkUIButton();
		Label5 = new DarkLabel();
		Button_Allocate = new DarkUIButton();
		NUD_NumberOfWeapons = new DarkNumericUpDown();
		TV_AvailableWeapons = new DarkTreeView();
		TableLayoutPanel3 = new TableLayoutPanel();
		Panel3 = new Panel();
		Button_ClearCourse_Attacker = new DarkUIButton();
		Button_PlotCourse_Attacker = new DarkUIButton();
		Button_RemoveWeapons_Attacker = new DarkUIButton();
		TabControl2 = new DarkUITabControl();
		Tab_Attacker_ToSelectedOnly = new TabPage();
		TV_Allocations_ToTargetsOnly = new DarkTreeView();
		Tab_Attacker_ToAnyone = new TabPage();
		TV_Allocations_ToAnyone = new DarkTreeView();
		Label2 = new DarkLabel();
		Panel4 = new Panel();
		Button_ClearCourse_Target = new DarkUIButton();
		Button_RemoveWeapons_Target = new DarkUIButton();
		Button_PlotCourse_Target = new DarkUIButton();
		TabControl4 = new DarkUITabControl();
		Tab_Target_BySelected = new TabPage();
		TV_Allocations_ByAttackersOnly = new DarkTreeView();
		Tab_Target_ByAnyone = new TabPage();
		TV_Allocations_ByAnyone = new DarkTreeView();
		Label4 = new DarkLabel();
		SalvoContextMenu = new DarkContextMenu();
		TSMI_HighAltitudeDetonation = new DarkToolStripMenuItem();
		SplitContainerOuter = new SplitContainer();
		SplitContainerInner = new SplitContainer();
		Button_Execute = new DarkUIButton();
		((Control)TableLayoutPanel1).SuspendLayout();
		((Control)Panel1).SuspendLayout();
		((Control)Panel5).SuspendLayout();
		((Control)TableLayoutPanel2).SuspendLayout();
		((Control)Panel2).SuspendLayout();
		((ISupportInitialize)NUD_NumberOfWeapons).BeginInit();
		((Control)TableLayoutPanel3).SuspendLayout();
		((Control)Panel3).SuspendLayout();
		((Control)TabControl2).SuspendLayout();
		((Control)Tab_Attacker_ToSelectedOnly).SuspendLayout();
		((Control)Tab_Attacker_ToAnyone).SuspendLayout();
		((Control)Panel4).SuspendLayout();
		((Control)TabControl4).SuspendLayout();
		((Control)Tab_Target_BySelected).SuspendLayout();
		((Control)Tab_Target_ByAnyone).SuspendLayout();
		((Control)SalvoContextMenu).SuspendLayout();
		((ISupportInitialize)SplitContainerOuter).BeginInit();
		((Control)SplitContainerOuter.Panel1).SuspendLayout();
		((Control)SplitContainerOuter.Panel2).SuspendLayout();
		((Control)SplitContainerOuter).SuspendLayout();
		((ISupportInitialize)SplitContainerInner).BeginInit();
		((Control)SplitContainerInner.Panel1).SuspendLayout();
		((Control)SplitContainerInner.Panel2).SuspendLayout();
		((Control)SplitContainerInner).SuspendLayout();
		((Control)this).SuspendLayout();
		TableLayoutPanel1.ColumnCount = 1;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)1, 20f));
		TableLayoutPanel1.Controls.Add((Control)(object)Panel1, 0, 0);
		TableLayoutPanel1.Controls.Add((Control)(object)Panel5, 0, 1);
		((Control)TableLayoutPanel1).Dock = (DockStyle)5;
		((Control)TableLayoutPanel1).Location = new Point(0, 0);
		((Control)TableLayoutPanel1).Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 2;
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 50f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 50f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 20f));
		((Control)TableLayoutPanel1).Size = new Size(322, 661);
		((Control)TableLayoutPanel1).TabIndex = 17;
		((Control)Panel1).Anchor = (AnchorStyles)15;
		((Control)Panel1).Controls.Add((Control)(object)Button_RemoveAttacker);
		((Control)Panel1).Controls.Add((Control)(object)Label1);
		((Control)Panel1).Controls.Add((Control)(object)LB_Attackers);
		((Control)Panel1).Controls.Add((Control)(object)Button_UnitWRA);
		((Control)Panel1).Controls.Add((Control)(object)Button_AddAttacker);
		((Control)Panel1).Location = new Point(3, 3);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(316, 324);
		((Control)Panel1).TabIndex = 0;
		((Control)Button_RemoveAttacker).Anchor = (AnchorStyles)14;
		((ButtonBase)Button_RemoveAttacker).BackColor = Color.Transparent;
		((Control)Button_RemoveAttacker).Font = new Font("Segoe UI", 10f);
		((Control)Button_RemoveAttacker).ForeColor = SystemColors.Control;
		((Control)Button_RemoveAttacker).Location = new Point(-1, 302);
		((Control)Button_RemoveAttacker).Name = "Button_RemoveAttacker";
		((Control)Button_RemoveAttacker).Padding = new Padding(5);
		Button_RemoveAttacker.RoundRadius = 0;
		((Control)Button_RemoveAttacker).Size = new Size(317, 23);
		((Control)Button_RemoveAttacker).TabIndex = 11;
		Button_RemoveAttacker.Text = "Remove selected unit(s) from list";
		((Control)Label1).Anchor = (AnchorStyles)15;
		Label1.AutoSize = true;
		((Control)Label1).Font = new Font("Segoe UI", 12f);
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(0, 0);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(123, 21);
		((Control)Label1).TabIndex = 1;
		((Label)Label1).Text = "Attacking unit(s)";
		((Control)LB_Attackers).Anchor = (AnchorStyles)15;
		((Control)LB_Attackers).Font = new Font("Segoe UI", 9f);
		LB_Attackers.ItemHeight = 15;
		((Control)LB_Attackers).Location = new Point(0, 25);
		((Control)LB_Attackers).Name = "LB_Attackers";
		LB_Attackers.RelatedInfos = null;
		((Control)LB_Attackers).Size = new Size(315, 230);
		((Control)LB_Attackers).TabIndex = 2;
		((Control)Button_UnitWRA).Anchor = (AnchorStyles)14;
		((ButtonBase)Button_UnitWRA).BackColor = Color.Transparent;
		((Control)Button_UnitWRA).Font = new Font("Segoe UI", 10f);
		((Control)Button_UnitWRA).ForeColor = SystemColors.Control;
		((Control)Button_UnitWRA).Location = new Point(-1, 256);
		((Control)Button_UnitWRA).Name = "Button_UnitWRA";
		((Control)Button_UnitWRA).Padding = new Padding(5);
		Button_UnitWRA.RoundRadius = 0;
		((Control)Button_UnitWRA).Size = new Size(317, 23);
		((Control)Button_UnitWRA).TabIndex = 8;
		Button_UnitWRA.Text = "Weapon Release Authorization (WRA)";
		((Control)Button_AddAttacker).Anchor = (AnchorStyles)14;
		((ButtonBase)Button_AddAttacker).BackColor = Color.Transparent;
		((Control)Button_AddAttacker).Font = new Font("Segoe UI", 10f);
		((Control)Button_AddAttacker).ForeColor = SystemColors.Control;
		((Control)Button_AddAttacker).Location = new Point(-1, 279);
		((Control)Button_AddAttacker).Name = "Button_AddAttacker";
		((Control)Button_AddAttacker).Padding = new Padding(5);
		Button_AddAttacker.RoundRadius = 0;
		((Control)Button_AddAttacker).Size = new Size(317, 23);
		((Control)Button_AddAttacker).TabIndex = 9;
		Button_AddAttacker.Text = "Add selected unit(s) from tactical map";
		((Control)Panel5).Anchor = (AnchorStyles)15;
		((Control)Panel5).Controls.Add((Control)(object)Button_RemoveTargets);
		((Control)Panel5).Controls.Add((Control)(object)Button_AddTarget);
		((Control)Panel5).Controls.Add((Control)(object)LB_Targets);
		((Control)Panel5).Controls.Add((Control)(object)Label3);
		((Control)Panel5).Location = new Point(3, 333);
		((Control)Panel5).Name = "Panel5";
		((Control)Panel5).Size = new Size(316, 325);
		((Control)Panel5).TabIndex = 4;
		((Control)Button_RemoveTargets).Anchor = (AnchorStyles)14;
		((ButtonBase)Button_RemoveTargets).BackColor = Color.Transparent;
		((Control)Button_RemoveTargets).Font = new Font("Segoe UI", 10f);
		((Control)Button_RemoveTargets).ForeColor = SystemColors.Control;
		((Control)Button_RemoveTargets).Location = new Point(-1, 303);
		((Control)Button_RemoveTargets).Name = "Button_RemoveTargets";
		((Control)Button_RemoveTargets).Padding = new Padding(5);
		Button_RemoveTargets.RoundRadius = 0;
		((Control)Button_RemoveTargets).Size = new Size(317, 23);
		((Control)Button_RemoveTargets).TabIndex = 12;
		Button_RemoveTargets.Text = "Remove selected target(s) from list";
		((Control)Button_AddTarget).Anchor = (AnchorStyles)14;
		((ButtonBase)Button_AddTarget).BackColor = Color.Transparent;
		((Control)Button_AddTarget).Font = new Font("Segoe UI", 10f);
		((Control)Button_AddTarget).ForeColor = SystemColors.Control;
		((Control)Button_AddTarget).Location = new Point(-1, 280);
		((Control)Button_AddTarget).Name = "Button_AddTarget";
		((Control)Button_AddTarget).Padding = new Padding(5);
		Button_AddTarget.RoundRadius = 0;
		((Control)Button_AddTarget).Size = new Size(317, 23);
		((Control)Button_AddTarget).TabIndex = 10;
		Button_AddTarget.Text = "Add selected targets(s) from tactical map";
		((Control)LB_Targets).Anchor = (AnchorStyles)15;
		((Control)LB_Targets).Font = new Font("Segoe UI", 9f);
		LB_Targets.ItemHeight = 15;
		((Control)LB_Targets).Location = new Point(0, 25);
		LB_Targets.MultiSelect = true;
		((Control)LB_Targets).Name = "LB_Targets";
		LB_Targets.RelatedInfos = null;
		((Control)LB_Targets).Size = new Size(315, 254);
		((Control)LB_Targets).TabIndex = 4;
		((Control)Label3).Anchor = (AnchorStyles)15;
		Label3.AutoSize = true;
		((Control)Label3).Font = new Font("Segoe UI", 12f);
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(0, 0);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(142, 21);
		((Control)Label3).TabIndex = 3;
		((Label)Label3).Text = "Selectable target(s)";
		TableLayoutPanel2.ColumnCount = 1;
		TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle((SizeType)1, 20f));
		TableLayoutPanel2.Controls.Add((Control)(object)Panel2, 0, 0);
		TableLayoutPanel2.Controls.Add((Control)(object)Button_Execute, 0, 1);
		((Control)TableLayoutPanel2).Dock = (DockStyle)5;
		((Control)TableLayoutPanel2).Location = new Point(0, 0);
		((Control)TableLayoutPanel2).Name = "TableLayoutPanel2";
		TableLayoutPanel2.RowCount = 2;
		TableLayoutPanel2.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		TableLayoutPanel2.RowStyles.Add(new RowStyle((SizeType)1, 32f));
		((Control)TableLayoutPanel2).Size = new Size(348, 661);
		((Control)TableLayoutPanel2).TabIndex = 18;
		((Control)Panel2).Anchor = (AnchorStyles)15;
		((Control)Panel2).Controls.Add((Control)(object)CB_ShowAutomaticFireInfo);
		((Control)Panel2).Controls.Add((Control)(object)CB_AllowTimeout);
		((Control)Panel2).Controls.Add((Control)(object)Button_AllocateSalvo);
		((Control)Panel2).Controls.Add((Control)(object)Button_AllocateAllWeapons);
		((Control)Panel2).Controls.Add((Control)(object)Label5);
		((Control)Panel2).Controls.Add((Control)(object)Button_Allocate);
		((Control)Panel2).Controls.Add((Control)(object)NUD_NumberOfWeapons);
		((Control)Panel2).Controls.Add((Control)(object)TV_AvailableWeapons);
		((Control)Panel2).Location = new Point(3, 3);
		((Control)Panel2).Name = "Panel2";
		((Control)Panel2).Size = new Size(342, 623);
		((Control)Panel2).TabIndex = 1;
		((Control)CB_ShowAutomaticFireInfo).Location = new Point(167, 4);
		((Control)CB_ShowAutomaticFireInfo).Name = "CB_ShowAutomaticFireInfo";
		((Control)CB_ShowAutomaticFireInfo).Size = new Size(190, 17);
		((Control)CB_ShowAutomaticFireInfo).TabIndex = 15;
		((ButtonBase)CB_ShowAutomaticFireInfo).Text = "Show Automatic Fire Information";
		((Control)CB_AllowTimeout).Anchor = (AnchorStyles)14;
		((Control)CB_AllowTimeout).Font = new Font("Segoe UI", 8f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)CB_AllowTimeout).Location = new Point(74, 599);
		((Control)CB_AllowTimeout).MaximumSize = new Size(350, 0);
		((Control)CB_AllowTimeout).Name = "CB_AllowTimeout";
		((Control)CB_AllowTimeout).Size = new Size(180, 15);
		((Control)CB_AllowTimeout).TabIndex = 14;
		((ButtonBase)CB_AllowTimeout).Text = "Allow automatic salvo timeout";
		((Control)Button_AllocateSalvo).Anchor = (AnchorStyles)14;
		((ButtonBase)Button_AllocateSalvo).BackColor = Color.Transparent;
		((Control)Button_AllocateSalvo).Font = new Font("Segoe UI", 10f);
		((Control)Button_AllocateSalvo).ForeColor = SystemColors.Control;
		((Control)Button_AllocateSalvo).Location = new Point(-1, 541);
		((Control)Button_AllocateSalvo).Name = "Button_AllocateSalvo";
		((Control)Button_AllocateSalvo).Padding = new Padding(5);
		Button_AllocateSalvo.RoundRadius = 0;
		((Control)Button_AllocateSalvo).Size = new Size(347, 23);
		((Control)Button_AllocateSalvo).TabIndex = 13;
		Button_AllocateSalvo.Text = "Allocate one salvo to selected target(s)";
		((Control)Button_AllocateAllWeapons).Anchor = (AnchorStyles)14;
		((ButtonBase)Button_AllocateAllWeapons).BackColor = Color.Transparent;
		((Control)Button_AllocateAllWeapons).Font = new Font("Segoe UI", 10f);
		((Control)Button_AllocateAllWeapons).ForeColor = SystemColors.Control;
		((Control)Button_AllocateAllWeapons).Location = new Point(-1, 570);
		((Control)Button_AllocateAllWeapons).Name = "Button_AllocateAllWeapons";
		((Control)Button_AllocateAllWeapons).Padding = new Padding(5);
		Button_AllocateAllWeapons.RoundRadius = 0;
		((Control)Button_AllocateAllWeapons).Size = new Size(347, 23);
		((Control)Button_AllocateAllWeapons).TabIndex = 6;
		Button_AllocateAllWeapons.Text = "Allocate all weapons of this type";
		((Control)Label5).Anchor = (AnchorStyles)15;
		Label5.AutoSize = true;
		((Control)Label5).Font = new Font("Segoe UI", 12f);
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(0, 0);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(132, 21);
		((Control)Label5).TabIndex = 3;
		((Label)Label5).Text = "Suitable weapons";
		((Control)Button_Allocate).Anchor = (AnchorStyles)14;
		((ButtonBase)Button_Allocate).BackColor = Color.Transparent;
		((Control)Button_Allocate).Font = new Font("Segoe UI", 10f);
		((Control)Button_Allocate).ForeColor = SystemColors.Control;
		((Control)Button_Allocate).Location = new Point(-1, 509);
		((Control)Button_Allocate).Name = "Button_Allocate";
		((Control)Button_Allocate).Padding = new Padding(5);
		Button_Allocate.RoundRadius = 0;
		((Control)Button_Allocate).Size = new Size(268, 26);
		((Control)Button_Allocate).TabIndex = 5;
		Button_Allocate.Text = "Allocate weapons to selected target(s):";
		((Control)NUD_NumberOfWeapons).Anchor = (AnchorStyles)10;
		((UpDownBase)NUD_NumberOfWeapons).BackColor = Color.FromArgb(69, 73, 74);
		((UpDownBase)NUD_NumberOfWeapons).BorderStyle = (BorderStyle)1;
		((Control)NUD_NumberOfWeapons).Font = new Font("Segoe UI", 10f);
		((UpDownBase)NUD_NumberOfWeapons).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)NUD_NumberOfWeapons).Location = new Point(268, 509);
		((Control)NUD_NumberOfWeapons).Name = "NUD_NumberOfWeapons";
		((Control)NUD_NumberOfWeapons).Size = new Size(76, 25);
		((Control)NUD_NumberOfWeapons).TabIndex = 7;
		((Control)TV_AvailableWeapons).Anchor = (AnchorStyles)15;
		((Control)TV_AvailableWeapons).Font = new Font("Segoe UI", 9f);
		((Control)TV_AvailableWeapons).Location = new Point(0, 25);
		TV_AvailableWeapons.MaxDragChange = 20;
		((Control)TV_AvailableWeapons).Name = "TV_AvailableWeapons";
		((Control)TV_AvailableWeapons).Size = new Size(347, 478);
		((Control)TV_AvailableWeapons).TabIndex = 4;
		TableLayoutPanel3.ColumnCount = 1;
		TableLayoutPanel3.ColumnStyles.Add(new ColumnStyle((SizeType)1, 20f));
		TableLayoutPanel3.Controls.Add((Control)(object)Panel3, 0, 0);
		TableLayoutPanel3.Controls.Add((Control)(object)Panel4, 0, 1);
		((Control)TableLayoutPanel3).Dock = (DockStyle)5;
		((Control)TableLayoutPanel3).Location = new Point(0, 0);
		((Control)TableLayoutPanel3).Name = "TableLayoutPanel3";
		TableLayoutPanel3.RowCount = 2;
		TableLayoutPanel3.RowStyles.Add(new RowStyle((SizeType)2, 50f));
		TableLayoutPanel3.RowStyles.Add(new RowStyle((SizeType)2, 50f));
		TableLayoutPanel3.RowStyles.Add(new RowStyle((SizeType)1, 20f));
		((Control)TableLayoutPanel3).Size = new Size(324, 661);
		((Control)TableLayoutPanel3).TabIndex = 19;
		((Control)Panel3).Anchor = (AnchorStyles)15;
		((Control)Panel3).Controls.Add((Control)(object)Button_ClearCourse_Attacker);
		((Control)Panel3).Controls.Add((Control)(object)Button_PlotCourse_Attacker);
		((Control)Panel3).Controls.Add((Control)(object)Button_RemoveWeapons_Attacker);
		((Control)Panel3).Controls.Add((Control)(object)TabControl2);
		((Control)Panel3).Controls.Add((Control)(object)Label2);
		((Control)Panel3).Location = new Point(3, 3);
		((Control)Panel3).Name = "Panel3";
		((Control)Panel3).Size = new Size(318, 324);
		((Control)Panel3).TabIndex = 2;
		((Control)Button_ClearCourse_Attacker).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ClearCourse_Attacker).BackColor = Color.Transparent;
		((Control)Button_ClearCourse_Attacker).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_ClearCourse_Attacker).ForeColor = SystemColors.Control;
		((Control)Button_ClearCourse_Attacker).Location = new Point(80, 302);
		((Control)Button_ClearCourse_Attacker).Name = "Button_ClearCourse_Attacker";
		((Control)Button_ClearCourse_Attacker).Padding = new Padding(5);
		Button_ClearCourse_Attacker.RoundRadius = 0;
		((Control)Button_ClearCourse_Attacker).Size = new Size(76, 23);
		((Control)Button_ClearCourse_Attacker).TabIndex = 17;
		Button_ClearCourse_Attacker.Text = "Clear course";
		((Control)Button_PlotCourse_Attacker).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_PlotCourse_Attacker).BackColor = Color.Transparent;
		((Control)Button_PlotCourse_Attacker).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_PlotCourse_Attacker).ForeColor = SystemColors.Control;
		((Control)Button_PlotCourse_Attacker).Location = new Point(0, 302);
		((Control)Button_PlotCourse_Attacker).Name = "Button_PlotCourse_Attacker";
		((Control)Button_PlotCourse_Attacker).Padding = new Padding(5);
		Button_PlotCourse_Attacker.RoundRadius = 0;
		((Control)Button_PlotCourse_Attacker).Size = new Size(76, 23);
		((Control)Button_PlotCourse_Attacker).TabIndex = 16;
		Button_PlotCourse_Attacker.Text = "Plot course";
		((Control)Button_RemoveWeapons_Attacker).Anchor = (AnchorStyles)10;
		((ButtonBase)Button_RemoveWeapons_Attacker).BackColor = Color.Transparent;
		((Control)Button_RemoveWeapons_Attacker).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_RemoveWeapons_Attacker).ForeColor = SystemColors.Control;
		((Control)Button_RemoveWeapons_Attacker).Location = new Point(206, 302);
		((Control)Button_RemoveWeapons_Attacker).Name = "Button_RemoveWeapons_Attacker";
		((Control)Button_RemoveWeapons_Attacker).Padding = new Padding(5);
		Button_RemoveWeapons_Attacker.RoundRadius = 0;
		((Control)Button_RemoveWeapons_Attacker).Size = new Size(112, 23);
		((Control)Button_RemoveWeapons_Attacker).TabIndex = 15;
		Button_RemoveWeapons_Attacker.Text = "De-allocate selected";
		((Control)TabControl2).Anchor = (AnchorStyles)15;
		((Control)TabControl2).Controls.Add((Control)(object)Tab_Attacker_ToSelectedOnly);
		((Control)TabControl2).Controls.Add((Control)(object)Tab_Attacker_ToAnyone);
		((Control)TabControl2).Cursor = Cursors.Hand;
		((Control)TabControl2).Font = new Font("Segoe UI", 10f);
		((TabControl)TabControl2).ItemSize = new Size(80, 20);
		((Control)TabControl2).Location = new Point(0, 25);
		((Control)TabControl2).Name = "TabControl2";
		((TabControl)TabControl2).SelectedIndex = 0;
		((Control)TabControl2).Size = new Size(318, 276);
		((Control)TabControl2).TabIndex = 2;
		Tab_Attacker_ToSelectedOnly.BackColor = Color.FromArgb(60, 63, 65);
		((Control)Tab_Attacker_ToSelectedOnly).Controls.Add((Control)(object)TV_Allocations_ToTargetsOnly);
		Tab_Attacker_ToSelectedOnly.Location = new Point(4, 24);
		((Control)Tab_Attacker_ToSelectedOnly).Name = "Tab_Attacker_ToSelectedOnly";
		((Control)Tab_Attacker_ToSelectedOnly).Padding = new Padding(3);
		((Control)Tab_Attacker_ToSelectedOnly).Size = new Size(310, 248);
		Tab_Attacker_ToSelectedOnly.TabIndex = 0;
		Tab_Attacker_ToSelectedOnly.Text = "To selected target only";
		((Control)TV_Allocations_ToTargetsOnly).BackColor = Color.FromArgb(60, 63, 65);
		((Control)TV_Allocations_ToTargetsOnly).Dock = (DockStyle)5;
		((Control)TV_Allocations_ToTargetsOnly).Font = new Font("Segoe UI", 9f);
		((Control)TV_Allocations_ToTargetsOnly).Location = new Point(3, 3);
		TV_Allocations_ToTargetsOnly.MaxDragChange = 20;
		((Control)TV_Allocations_ToTargetsOnly).Name = "TV_Allocations_ToTargetsOnly";
		((Control)TV_Allocations_ToTargetsOnly).Size = new Size(304, 242);
		((Control)TV_Allocations_ToTargetsOnly).TabIndex = 5;
		Tab_Attacker_ToAnyone.BackColor = Color.FromArgb(60, 63, 65);
		((Control)Tab_Attacker_ToAnyone).Controls.Add((Control)(object)TV_Allocations_ToAnyone);
		Tab_Attacker_ToAnyone.Location = new Point(4, 24);
		((Control)Tab_Attacker_ToAnyone).Name = "Tab_Attacker_ToAnyone";
		((Control)Tab_Attacker_ToAnyone).Padding = new Padding(3);
		((Control)Tab_Attacker_ToAnyone).Size = new Size(310, 248);
		Tab_Attacker_ToAnyone.TabIndex = 1;
		Tab_Attacker_ToAnyone.Text = "To anyone";
		((Control)TV_Allocations_ToAnyone).BackColor = Color.FromArgb(60, 63, 65);
		((Control)TV_Allocations_ToAnyone).Dock = (DockStyle)5;
		((Control)TV_Allocations_ToAnyone).Font = new Font("Segoe UI", 9f);
		((Control)TV_Allocations_ToAnyone).Location = new Point(3, 3);
		TV_Allocations_ToAnyone.MaxDragChange = 20;
		((Control)TV_Allocations_ToAnyone).Name = "TV_Allocations_ToAnyone";
		((Control)TV_Allocations_ToAnyone).Size = new Size(304, 242);
		((Control)TV_Allocations_ToAnyone).TabIndex = 6;
		((Control)Label2).Anchor = (AnchorStyles)15;
		Label2.AutoSize = true;
		((Control)Label2).Font = new Font("Segoe UI", 12f);
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(0, 0);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(297, 21);
		((Control)Label2).TabIndex = 3;
		((Label)Label2).Text = "Weapons allocated by selected attacker(s)";
		((Control)Panel4).Anchor = (AnchorStyles)15;
		((Control)Panel4).Controls.Add((Control)(object)Button_ClearCourse_Target);
		((Control)Panel4).Controls.Add((Control)(object)Button_RemoveWeapons_Target);
		((Control)Panel4).Controls.Add((Control)(object)Button_PlotCourse_Target);
		((Control)Panel4).Controls.Add((Control)(object)TabControl4);
		((Control)Panel4).Controls.Add((Control)(object)Label4);
		((Control)Panel4).Location = new Point(3, 333);
		((Control)Panel4).Name = "Panel4";
		((Control)Panel4).Size = new Size(318, 325);
		((Control)Panel4).TabIndex = 3;
		((Control)Button_ClearCourse_Target).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ClearCourse_Target).BackColor = Color.Transparent;
		((Control)Button_ClearCourse_Target).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_ClearCourse_Target).ForeColor = SystemColors.Control;
		((Control)Button_ClearCourse_Target).Location = new Point(80, 302);
		((Control)Button_ClearCourse_Target).Name = "Button_ClearCourse_Target";
		((Control)Button_ClearCourse_Target).Padding = new Padding(5);
		Button_ClearCourse_Target.RoundRadius = 0;
		((Control)Button_ClearCourse_Target).Size = new Size(76, 23);
		((Control)Button_ClearCourse_Target).TabIndex = 19;
		Button_ClearCourse_Target.Text = "Clear course";
		((Control)Button_RemoveWeapons_Target).Anchor = (AnchorStyles)10;
		((ButtonBase)Button_RemoveWeapons_Target).BackColor = Color.Transparent;
		((Control)Button_RemoveWeapons_Target).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_RemoveWeapons_Target).ForeColor = SystemColors.Control;
		((Control)Button_RemoveWeapons_Target).Location = new Point(206, 302);
		((Control)Button_RemoveWeapons_Target).Name = "Button_RemoveWeapons_Target";
		((Control)Button_RemoveWeapons_Target).Padding = new Padding(5);
		Button_RemoveWeapons_Target.RoundRadius = 0;
		((Control)Button_RemoveWeapons_Target).Size = new Size(112, 23);
		((Control)Button_RemoveWeapons_Target).TabIndex = 14;
		Button_RemoveWeapons_Target.Text = "De-allocate selected";
		((Control)Button_PlotCourse_Target).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_PlotCourse_Target).BackColor = Color.Transparent;
		((Control)Button_PlotCourse_Target).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_PlotCourse_Target).ForeColor = SystemColors.Control;
		((Control)Button_PlotCourse_Target).Location = new Point(0, 302);
		((Control)Button_PlotCourse_Target).Name = "Button_PlotCourse_Target";
		((Control)Button_PlotCourse_Target).Padding = new Padding(5);
		Button_PlotCourse_Target.RoundRadius = 0;
		((Control)Button_PlotCourse_Target).Size = new Size(76, 23);
		((Control)Button_PlotCourse_Target).TabIndex = 18;
		Button_PlotCourse_Target.Text = "Plot course";
		((Control)TabControl4).Anchor = (AnchorStyles)15;
		((Control)TabControl4).Controls.Add((Control)(object)Tab_Target_BySelected);
		((Control)TabControl4).Controls.Add((Control)(object)Tab_Target_ByAnyone);
		((Control)TabControl4).Cursor = Cursors.Hand;
		((Control)TabControl4).Font = new Font("Segoe UI", 10f);
		((TabControl)TabControl4).ItemSize = new Size(80, 20);
		((Control)TabControl4).Location = new Point(0, 25);
		((Control)TabControl4).Name = "TabControl4";
		((TabControl)TabControl4).SelectedIndex = 0;
		((Control)TabControl4).Size = new Size(318, 277);
		((Control)TabControl4).TabIndex = 2;
		Tab_Target_BySelected.BackColor = Color.FromArgb(60, 63, 65);
		((Control)Tab_Target_BySelected).Controls.Add((Control)(object)TV_Allocations_ByAttackersOnly);
		Tab_Target_BySelected.Location = new Point(4, 24);
		((Control)Tab_Target_BySelected).Name = "Tab_Target_BySelected";
		((Control)Tab_Target_BySelected).Padding = new Padding(3);
		((Control)Tab_Target_BySelected).Size = new Size(310, 249);
		Tab_Target_BySelected.TabIndex = 0;
		Tab_Target_BySelected.Text = "By selected attacker(s) only";
		((Control)TV_Allocations_ByAttackersOnly).BackColor = Color.FromArgb(60, 63, 65);
		((Control)TV_Allocations_ByAttackersOnly).Dock = (DockStyle)5;
		((Control)TV_Allocations_ByAttackersOnly).Font = new Font("Segoe UI", 9f);
		((Control)TV_Allocations_ByAttackersOnly).Location = new Point(3, 3);
		TV_Allocations_ByAttackersOnly.MaxDragChange = 20;
		((Control)TV_Allocations_ByAttackersOnly).Name = "TV_Allocations_ByAttackersOnly";
		((Control)TV_Allocations_ByAttackersOnly).Size = new Size(304, 243);
		((Control)TV_Allocations_ByAttackersOnly).TabIndex = 6;
		Tab_Target_ByAnyone.BackColor = Color.FromArgb(60, 63, 65);
		((Control)Tab_Target_ByAnyone).Controls.Add((Control)(object)TV_Allocations_ByAnyone);
		Tab_Target_ByAnyone.Location = new Point(4, 24);
		((Control)Tab_Target_ByAnyone).Name = "Tab_Target_ByAnyone";
		((Control)Tab_Target_ByAnyone).Padding = new Padding(3);
		((Control)Tab_Target_ByAnyone).Size = new Size(310, 249);
		Tab_Target_ByAnyone.TabIndex = 1;
		Tab_Target_ByAnyone.Text = "By anyone";
		((Control)TV_Allocations_ByAnyone).BackColor = Color.FromArgb(60, 63, 65);
		((Control)TV_Allocations_ByAnyone).Dock = (DockStyle)5;
		((Control)TV_Allocations_ByAnyone).Font = new Font("Segoe UI", 9f);
		((Control)TV_Allocations_ByAnyone).Location = new Point(3, 3);
		TV_Allocations_ByAnyone.MaxDragChange = 20;
		((Control)TV_Allocations_ByAnyone).Name = "TV_Allocations_ByAnyone";
		((Control)TV_Allocations_ByAnyone).Size = new Size(304, 243);
		((Control)TV_Allocations_ByAnyone).TabIndex = 7;
		((Control)Label4).Anchor = (AnchorStyles)15;
		Label4.AutoSize = true;
		((Control)Label4).Font = new Font("Segoe UI", 12f);
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(0, 0);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(263, 21);
		((Control)Label4).TabIndex = 3;
		((Label)Label4).Text = "Weapons allocated to selected target";
		((ToolStrip)SalvoContextMenu).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)SalvoContextMenu).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)SalvoContextMenu).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[1] { (ToolStripItem)TSMI_HighAltitudeDetonation });
		((Control)SalvoContextMenu).Name = "ContextMenuStrip1";
		((Control)SalvoContextMenu).Size = new Size(251, 26);
		((ToolStripItem)TSMI_HighAltitudeDetonation).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSMI_HighAltitudeDetonation).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSMI_HighAltitudeDetonation).Name = "TSMI_HighAltitudeDetonation";
		((ToolStripItem)TSMI_HighAltitudeDetonation).Size = new Size(250, 22);
		((ToolStripItem)TSMI_HighAltitudeDetonation).Text = "Special: High Altitude Detonation";
		((Control)SplitContainerOuter).Anchor = (AnchorStyles)15;
		((Control)SplitContainerOuter).Location = new Point(0, 0);
		((Control)SplitContainerOuter).Name = "SplitContainerOuter";
		((Control)SplitContainerOuter.Panel1).Controls.Add((Control)(object)TableLayoutPanel1);
		SplitContainerOuter.Panel1MinSize = 322;
		((Control)SplitContainerOuter.Panel2).Controls.Add((Control)(object)SplitContainerInner);
		SplitContainerOuter.Panel2MinSize = 670;
		((Control)SplitContainerOuter).Size = new Size(1008, 661);
		SplitContainerOuter.SplitterDistance = 322;
		((Control)SplitContainerOuter).TabIndex = 1;
		((Control)SplitContainerInner).Anchor = (AnchorStyles)15;
		((Control)SplitContainerInner).Location = new Point(0, 0);
		((Control)SplitContainerInner).Name = "SplitContainerInner";
		((Control)SplitContainerInner.Panel1).Controls.Add((Control)(object)TableLayoutPanel2);
		SplitContainerInner.Panel1MinSize = 348;
		((Control)SplitContainerInner.Panel2).Controls.Add((Control)(object)TableLayoutPanel3);
		SplitContainerInner.Panel2MinSize = 324;
		((Control)SplitContainerInner).Size = new Size(676, 661);
		SplitContainerInner.SplitterDistance = 348;
		((Control)SplitContainerInner).TabIndex = 0;
		((Control)Button_Execute).Anchor = (AnchorStyles)15;
		((Control)Button_Execute).Font = new Font("Segoe UI", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Button_Execute).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_Execute).Location = new Point(0, 629);
		((Control)Button_Execute).Margin = new Padding(0);
		((Control)Button_Execute).MaximumSize = new Size(0, 32);
		((Control)Button_Execute).MinimumSize = new Size(0, 32);
		((Control)Button_Execute).Name = "Button_Execute";
		Button_Execute.RoundRadius = 0;
		((Control)Button_Execute).Size = new Size(348, 32);
		((Control)Button_Execute).TabIndex = 2;
		Button_Execute.Text = "EXECUTE";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1008, 661);
		((Control)this).Controls.Add((Control)(object)SplitContainerOuter);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "AttackTarget";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Weapon Allocation";
		((Control)TableLayoutPanel1).ResumeLayout(false);
		((Control)Panel1).ResumeLayout(false);
		((Control)Panel1).PerformLayout();
		((Control)Panel5).ResumeLayout(false);
		((Control)Panel5).PerformLayout();
		((Control)TableLayoutPanel2).ResumeLayout(false);
		((Control)Panel2).ResumeLayout(false);
		((Control)Panel2).PerformLayout();
		((ISupportInitialize)NUD_NumberOfWeapons).EndInit();
		((Control)TableLayoutPanel3).ResumeLayout(false);
		((Control)Panel3).ResumeLayout(false);
		((Control)Panel3).PerformLayout();
		((Control)TabControl2).ResumeLayout(false);
		((Control)Tab_Attacker_ToSelectedOnly).ResumeLayout(false);
		((Control)Tab_Attacker_ToAnyone).ResumeLayout(false);
		((Control)Panel4).ResumeLayout(false);
		((Control)Panel4).PerformLayout();
		((Control)TabControl4).ResumeLayout(false);
		((Control)Tab_Target_BySelected).ResumeLayout(false);
		((Control)Tab_Target_ByAnyone).ResumeLayout(false);
		((Control)SalvoContextMenu).ResumeLayout(false);
		((Control)SplitContainerOuter.Panel1).ResumeLayout(false);
		((Control)SplitContainerOuter.Panel2).ResumeLayout(false);
		((ISupportInitialize)SplitContainerOuter).EndInit();
		((Control)SplitContainerOuter).ResumeLayout(false);
		((Control)SplitContainerInner.Panel1).ResumeLayout(false);
		((Control)SplitContainerInner.Panel2).ResumeLayout(false);
		((ISupportInitialize)SplitContainerInner).EndInit();
		((Control)SplitContainerInner).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	public void ReleaseReferences()
	{
		try
		{
			if (((Control)this).Visible)
			{
				((Form)this).Close();
			}
			Targets.Clear();
			Attackers.Clear();
			list_0.Clear();
			list_1.Clear();
			weaponSalvo_0 = null;
			LB_Attackers.Items.Clear();
			LB_Targets.Items.Clear();
			TV_Allocations_ToTargetsOnly.Nodes.Clear();
			TV_Allocations_ToAnyone.Nodes.Clear();
			TV_Allocations_ByAttackersOnly.Nodes.Clear();
			TV_AvailableWeapons.Nodes.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void AttackTarget_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (Client.CurrentUserAction != Client.UserAction.PlottingCourseForSalvo)
		{
			method_60();
		}
		if (bool_4 && Client.CurrentUserAction != Client.UserAction.PlottingCourseForSalvo)
		{
			Client.CurrentGame.Run();
		}
		((Control)MyProject.Forms.MainForm.WorldWindow1).Focus();
		((Control)MyProject.Forms.MainForm).BringToFront();
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

	private void method_2()
	{
		Color darkBackground = Colors.DarkBackground;
		Color backColor = ((Control)SplitContainerOuter.Panel1).BackColor;
		Color backColor2 = ((Control)SplitContainerOuter.Panel2).BackColor;
		((Control)SplitContainerOuter.Panel1).BackColor = darkBackground;
		((Control)SplitContainerOuter.Panel2).BackColor = darkBackground;
		((Control)SplitContainerOuter).BackColor = darkBackground;
		((Control)SplitContainerOuter.Panel1).BackColor = backColor;
		((Control)SplitContainerOuter.Panel2).BackColor = backColor2;
		backColor = ((Control)SplitContainerInner.Panel1).BackColor;
		backColor2 = ((Control)SplitContainerInner.Panel2).BackColor;
		((Control)SplitContainerInner.Panel1).BackColor = darkBackground;
		((Control)SplitContainerInner.Panel2).BackColor = darkBackground;
		((Control)SplitContainerInner).BackColor = darkBackground;
		((Control)SplitContainerInner.Panel1).BackColor = backColor;
		((Control)SplitContainerInner.Panel2).BackColor = backColor2;
	}

	public void ClearToAndBySelectionIndexes()
	{
		int_3 = -1;
		int_4 = -1;
		int_5 = -1;
		int_6 = -1;
	}

	public void LoadForm()
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IsRefreshing = true;
			bool_4 = Client.CurrentGame.Status == Game._GameStatus.Running;
			if (bool_4)
			{
				Client.CurrentGame.Pause();
			}
			ClearToAndBySelectionIndexes();
			method_2();
			ListAttackers();
			ListTargets();
			if (Targets.Count > 0 && Attackers.Count > 0 && TV_AvailableWeapons.Nodes.Count > 0)
			{
				bool_5 = false;
				TV_AvailableWeapons.SelectNode(TV_AvailableWeapons.Nodes[0]);
				((Control)TV_AvailableWeapons).Select();
				bool_5 = true;
			}
			bool_5 = false;
			((CheckBox)CB_AllowTimeout).Checked = SimConfiguration.DefaultGamePreferences.SalvoTimeout;
			((CheckBox)CB_ShowAutomaticFireInfo).Checked = SimConfiguration.DefaultGamePreferences.ShowAutomaticFireInfo;
			bool_5 = true;
			new ToolTip().SetToolTip((Control)(object)CB_AllowTimeout, "Enable automatic salvo cancellation when last weapon in first volley impacts, or after 40 seconds if weapons cannot be fired. Note! Disabling salvo cancellation will not drop salvos until all weapons have been fired, and may prevent other units from automatically firing at a contact should it move out of firing parameters!");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			IsRefreshing = false;
		}
	}

	public void RefreshForm()
	{
		if (((Control)this).IsDisposed || IsRefreshing)
		{
			return;
		}
		IsRefreshing = true;
		try
		{
			VbeLjqceUwl();
			method_11();
			method_5();
			if (list_0 == null && Attackers.Count > 0)
			{
				list_0.Add(Attackers[0]);
				list_1.Add(Targets[0]);
			}
			List<ActiveUnit> list = new List<ActiveUnit>();
			foreach (ActiveUnit attacker in Attackers)
			{
				if (attacker == null || attacker.IsMorituri || (attacker.IsShip && ((Ship)attacker).IsSinking))
				{
					list.Add(attacker);
				}
				if (!attacker.IsOperating())
				{
					list.Add(attacker);
				}
			}
			if (list.Count > 0)
			{
				foreach (ActiveUnit item in list)
				{
					Attackers.Remove(item);
				}
				ListAttackers();
			}
			List<Contact> list2 = new List<Contact>();
			foreach (Contact target in Targets)
			{
				if (target != null)
				{
					ActiveUnit actualUnit = target.ActualUnit;
					if (actualUnit == null || !actualUnit.IsMorituri)
					{
						continue;
					}
				}
				list2.Add(target);
			}
			if (list2.Count > 0)
			{
				foreach (Contact item2 in list2)
				{
					Targets.Remove(item2);
					ListTargets();
				}
			}
			HkpLjwXryng();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			IsRefreshing = false;
		}
	}

	private void AttackTarget_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		Timer1.Interval = 1000;
		Timer1.Start();
		LoadForm();
	}

	private void method_3(object sender, EventArgs e)
	{
		if (!((Control)this).Visible)
		{
			return;
		}
		if (Client.Realtime)
		{
			if (Client.RealtimeTerminal.LastGameSpeed > 0)
			{
				List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
				if (list_0.Count > 0)
				{
					list.Add(list_0[0]);
					Client.RealtimeTerminal.RequestUpdateOnActiveUnits(list);
				}
				if (list_1.Count > 0)
				{
					list.Clear();
					list.Add(list_1[0]);
					Client.RealtimeTerminal.RequestUpdateOnContacts(list);
				}
				RefreshForm();
			}
		}
		else if (Client.CurrentGame.Status == Game._GameStatus.Running)
		{
			RefreshForm();
		}
	}

	private void method_4()
	{
		DarkTreeNode darkTreeNode = null;
		Button_RemoveWeapons_Attacker.Enabled = false;
		bool flag = false;
		bool flag2 = false;
		if (((TabControl)TabControl2).SelectedIndex != 0)
		{
			if (TV_Allocations_ToAnyone.SelectedNodes.Count > 0)
			{
				darkTreeNode = TV_Allocations_ToAnyone.SelectedNodes[0];
			}
		}
		else if (TV_Allocations_ToTargetsOnly.SelectedNodes.Count > 0)
		{
			darkTreeNode = TV_Allocations_ToTargetsOnly.SelectedNodes[0];
		}
		if (darkTreeNode != null && darkTreeNode.Tag != null)
		{
			if ((object)darkTreeNode.Tag.GetType() == typeof(WeaponSalvo))
			{
				Button_RemoveWeapons_Attacker.Enabled = true;
				weaponSalvo_0 = (WeaponSalvo)darkTreeNode.Tag;
				flag = weaponSalvo_0.PlottedCourse.Count() > 0;
				flag2 = weaponSalvo_0.get_ReferenceWeapon(Client.CurrentScenario).SupportsWaypoints;
			}
			else if (darkTreeNode.Tag is ActiveUnit && darkTreeNode.Nodes.Count > 0)
			{
				Button_RemoveWeapons_Attacker.Enabled = true;
			}
		}
		Button_PlotCourse_Attacker.Enabled = flag2;
		Button_ClearCourse_Attacker.Enabled = flag2 && flag;
		darkTreeNode = null;
		Button_RemoveWeapons_Target.Enabled = false;
		flag = false;
		flag2 = false;
		if (((TabControl)TabControl4).SelectedIndex == 0)
		{
			if (TV_Allocations_ByAttackersOnly.SelectedNodes.Count > 0)
			{
				darkTreeNode = TV_Allocations_ByAttackersOnly.SelectedNodes[0];
			}
		}
		else if (TV_Allocations_ByAnyone.SelectedNodes.Count > 0)
		{
			darkTreeNode = TV_Allocations_ByAnyone.SelectedNodes[0];
		}
		if (darkTreeNode != null && darkTreeNode.Tag != null)
		{
			if ((object)darkTreeNode.Tag.GetType() == typeof(WeaponSalvo))
			{
				Button_RemoveWeapons_Target.Enabled = true;
				weaponSalvo_0 = (WeaponSalvo)darkTreeNode.Tag;
				flag = weaponSalvo_0.PlottedCourse.Count() > 0;
				flag2 = weaponSalvo_0.get_ReferenceWeapon(Client.CurrentScenario).SupportsWaypoints;
			}
			else if (darkTreeNode.Tag is ActiveUnit && darkTreeNode.Nodes.Count > 0)
			{
				Button_RemoveWeapons_Target.Enabled = true;
			}
		}
		Button_PlotCourse_Target.Enabled = flag2;
		Button_ClearCourse_Target.Enabled = flag2 && flag;
	}

	private void method_5()
	{
		method_30();
		if (((TabControl)TabControl2).SelectedIndex == 0)
		{
			method_6();
		}
		else
		{
			method_7();
		}
		if (((TabControl)TabControl4).SelectedIndex != 0)
		{
			method_9();
		}
		else
		{
			method_8();
		}
		method_4();
	}

	public void ListAttackers()
	{
		LB_Attackers.Items.Clear();
		List<ActiveUnit> list = new List<ActiveUnit>();
		List<ActiveUnit> list2 = new List<ActiveUnit>();
		Attackers = Attackers.OrderBy([SpecialName] (ActiveUnit theAu) => theAu.Name).ToList();
		foreach (ActiveUnit attacker in Attackers)
		{
			if (!attacker.IsGroup)
			{
				continue;
			}
			foreach (ActiveUnit value in ((Group)attacker).Units.Values)
			{
				Side currentSide = Client.CurrentSide;
				string ReasonWhyNot = null;
				if (GameGeneral.CanIssueOrdersToThisUnit(currentSide, value, IncludeSonobuoys: false, ref ReasonWhyNot, Client.CurrentMapProfile.IsolatedPOVObjectID) && !Attackers.Contains(value))
				{
					list.Add(value);
				}
			}
			list2.Add(attacker);
		}
		foreach (ActiveUnit item in list2)
		{
			Attackers.Remove(item);
		}
		foreach (ActiveUnit item2 in list)
		{
			Attackers.Add(item2);
		}
		foreach (ActiveUnit attacker2 in Attackers)
		{
			DarkListItem darkListItem = new DarkListItem();
			darkListItem.Text = attacker2.Name + " (" + Misc.RemoveHiddenString(attacker2.UnitClass) + ")";
			darkListItem.Tag = attacker2;
			LB_Attackers.Items.Add(darkListItem);
		}
		if (LB_Attackers.Items.Count > 0)
		{
			if (int_0 <= LB_Attackers.Items.Count - 1)
			{
				LB_Attackers.SelectItem(int_0);
			}
			else
			{
				LB_Attackers.SelectItem(LB_Attackers.Items.Count - 1);
			}
		}
	}

	public void ListTargets()
	{
		LB_Targets.Items.Clear();
		Targets = Targets.OrderBy([SpecialName] (Contact theC) => theC.Name).ToList();
		string text2 = default(string);
		foreach (Contact target in Targets)
		{
			string text = "";
			if (target.Recon_HostedUnits(Client.CurrentSide).Count > 0)
			{
				Dictionary<string, int> dictionary = new Dictionary<string, int>();
				foreach (Contact.HostedUnitReconRecord item in target.Recon_HostedUnits(Client.CurrentSide))
				{
					switch (item.IDStatus)
					{
					case Contact_Base.IdentificationStatus.Unknown:
						text2 = "Unknown unit";
						break;
					case Contact_Base.IdentificationStatus.KnownDomain:
					{
						text2 = (Client.CurrentScenario.ActiveUnits.TryGetValue(item.UnitID, out var value4) ? (Misc.ToEnglishString(value4.VisualSizeClass) + " " + value4.UnitType_String) : "Unknown unit");
						break;
					}
					case Contact_Base.IdentificationStatus.KnownType:
					{
						text2 = (Client.CurrentScenario.ActiveUnits.TryGetValue(item.UnitID, out var value2) ? (Misc.ToEnglishString(value2.VisualSizeClass) + " " + value2.SubTypeDescription) : "Unknown unit");
						break;
					}
					case Contact_Base.IdentificationStatus.KnownClass:
					{
						text2 = (Client.CurrentScenario.ActiveUnits.TryGetValue(item.UnitID, out var value3) ? value3.UnitClass : "Unknown unit");
						break;
					}
					case Contact_Base.IdentificationStatus.PreciseID:
					{
						text2 = (Client.CurrentScenario.ActiveUnits.TryGetValue(item.UnitID, out var value) ? value.Name : "Unknown unit");
						break;
					}
					}
					text2 = text2 + " (Last Recon: " + Conversions.ToString(Interaction.IIf(item.ReconAge > 0f, (object)(Misc.TimeString((long)Math.Round(item.ReconAge), 0, ReturnNo: false, ReturnZero: true) + " ago)"), (object)"Now)"));
					if (dictionary.ContainsKey(text2))
					{
						dictionary[text2]++;
					}
					else
					{
						dictionary.Add(text2, 1);
					}
				}
				List<string> list = new List<string>();
				foreach (KeyValuePair<string, int> item2 in dictionary)
				{
					list.Add(Conversions.ToString(item2.Value) + "x " + item2.Key);
				}
				text = " - " + string.Join(" - ", list);
			}
			DarkListItem darkListItem = new DarkListItem();
			darkListItem.Text = target.Name + text;
			darkListItem.Tag = target;
			LB_Targets.Items.Add(darkListItem);
		}
		if (LB_Targets.Items.Count > 0)
		{
			if (int_1 > LB_Targets.Items.Count - 1)
			{
				LB_Targets.SelectItem(LB_Targets.Items.Count - 1);
			}
			else
			{
				LB_Targets.SelectItem(int_1);
			}
		}
	}

	private void method_6()
	{
		TV_Allocations_ToTargetsOnly.Nodes.Clear();
		if (list_0.Count == 0 || list_1.Count != 1)
		{
			return;
		}
		foreach (ActiveUnit item in list_0)
		{
			ActiveUnit theAttacker = item;
			DarkTreeNode darkTreeNode = new DarkTreeNode();
			darkTreeNode.Text = "By: " + theAttacker.Name;
			darkTreeNode.Tag = theAttacker;
			TV_Allocations_ToTargetsOnly.Nodes.Add(darkTreeNode);
			PooledList<WeaponSalvo> pooledList = theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvosFromThisUnitToThisTarget(ref theAttacker, list_1[0], Client.Realtime);
			if (pooledList != null)
			{
				foreach (WeaponSalvo item2 in pooledList)
				{
					WeaponSalvo.Shooter[] shootersList = item2.ShootersList;
					foreach (WeaponSalvo.Shooter shooter in shootersList)
					{
						if (Operators.CompareString(theAttacker.ObjectID, shooter.ShooterObjectID, true) != 0)
						{
							continue;
						}
						if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
						{
							string text = ((shooter.QuantityAssigned <= 2147473647) ? (Conversions.ToString(shooter.QuantityAssigned - shooter.QuantityFired) + "x ") : "All weapons ");
							DarkTreeNode darkTreeNode2 = new DarkTreeNode();
							string_0 = "";
							Weapon.WeaponSpecialMode activeSpecialMode = item2.ActiveSpecialMode;
							if (activeSpecialMode == Weapon.WeaponSpecialMode.HighAltitudeDetonation)
							{
								string_0 += "[HIGH ALT]";
							}
							if (item2.PlottedCourse.Count() > 0)
							{
								ref string reference = ref string_0;
								reference = reference + "[" + Conversions.ToString(item2.PlottedCourse.Count()) + " legs]";
							}
							darkTreeNode2.Text = "Alloc: " + string_0 + " " + text + item2.get_ReferenceWeapon(theAttacker.ParentScen).Name;
							darkTreeNode2.Tag = item2;
							darkTreeNode.Nodes.Add(darkTreeNode2);
						}
						if (shooter.QuantityFired > 0)
						{
							DarkTreeNode darkTreeNode3 = new DarkTreeNode();
							darkTreeNode3.Text = "Fired: " + Conversions.ToString(shooter.QuantityFired) + "x " + item2.get_ReferenceWeapon(theAttacker.ParentScen).Name;
							darkTreeNode.Nodes.Add(darkTreeNode3);
						}
					}
				}
				pooledList.Dispose();
			}
			darkTreeNode.Expanded = true;
		}
		if (int_3 < 0 || TV_Allocations_ToTargetsOnly.SelectedNodes.Count != 0)
		{
			return;
		}
		foreach (DarkTreeNode node in TV_Allocations_ToTargetsOnly.Nodes)
		{
			if (node.VisibleIndex != int_4)
			{
				continue;
			}
			foreach (DarkTreeNode node2 in node.Nodes)
			{
				if (node2.VisibleIndex == int_3)
				{
					TV_Allocations_ToTargetsOnly.SelectNode(node2);
					break;
				}
			}
		}
	}

	private void method_7()
	{
		TV_Allocations_ToAnyone.Nodes.Clear();
		if (list_0.Count == 0)
		{
			return;
		}
		foreach (ActiveUnit item in list_0)
		{
			ActiveUnit theAttacker = item;
			DarkTreeNode darkTreeNode = new DarkTreeNode();
			darkTreeNode.Text = "By: " + theAttacker.Name;
			darkTreeNode.Tag = theAttacker;
			TV_Allocations_ToAnyone.Nodes.Add(darkTreeNode);
			List<WeaponSalvo> list = theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvosFromThisUnitToAnyTarget(ref theAttacker);
			foreach (WeaponSalvo item2 in list)
			{
				WeaponSalvo.Shooter[] shootersList = item2.ShootersList;
				foreach (WeaponSalvo.Shooter shooter in shootersList)
				{
					if (Operators.CompareString(theAttacker.ObjectID, shooter.ShooterObjectID, true) == 0)
					{
						if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
						{
							string text = ((shooter.QuantityAssigned > 2147473647) ? "All weapons " : (Conversions.ToString(shooter.QuantityAssigned - shooter.QuantityFired) + "x "));
							DarkTreeNode darkTreeNode2 = new DarkTreeNode();
							darkTreeNode2.Text = (item2.ManualFire ? "*" : "") + "Allocated to " + item2.Target.Name + ": " + text + item2.get_ReferenceWeapon(theAttacker.ParentScen).Name;
							darkTreeNode2.Tag = item2;
							darkTreeNode.Nodes.Add(darkTreeNode2);
						}
						if (shooter.QuantityFired > 0)
						{
							DarkTreeNode darkTreeNode3 = new DarkTreeNode();
							darkTreeNode3.Text = "Fired at " + item2.Target.Name + ": " + Conversions.ToString(shooter.QuantityFired) + "x " + item2.get_ReferenceWeapon(theAttacker.ParentScen).Name;
							darkTreeNode.Nodes.Add(darkTreeNode3);
						}
					}
				}
			}
			darkTreeNode.Expanded = true;
		}
		if (int_3 < 0 || TV_Allocations_ToAnyone.SelectedNodes.Count != 0)
		{
			return;
		}
		foreach (DarkTreeNode node in TV_Allocations_ToAnyone.Nodes)
		{
			if (node.VisibleIndex != int_4)
			{
				continue;
			}
			foreach (DarkTreeNode node2 in node.Nodes)
			{
				if (node2.VisibleIndex == int_3)
				{
					TV_Allocations_ToAnyone.SelectNode(node2);
					break;
				}
			}
		}
	}

	private void method_8()
	{
		TV_Allocations_ByAttackersOnly.Nodes.Clear();
		if (list_0.Count == 0 || list_1.Count != 1)
		{
			return;
		}
		foreach (ActiveUnit item in list_0)
		{
			ActiveUnit theAttacker = item;
			DarkTreeNode darkTreeNode = new DarkTreeNode();
			darkTreeNode.Text = "By: " + theAttacker.Name;
			darkTreeNode.Tag = theAttacker;
			TV_Allocations_ByAttackersOnly.Nodes.Add(darkTreeNode);
			PooledList<WeaponSalvo> pooledList = theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvosFromThisUnitToThisTarget(ref theAttacker, list_1[0], Client.Realtime);
			if (pooledList != null)
			{
				foreach (WeaponSalvo item2 in pooledList)
				{
					WeaponSalvo.Shooter[] shootersList = item2.ShootersList;
					foreach (WeaponSalvo.Shooter shooter in shootersList)
					{
						if (Operators.CompareString(theAttacker.ObjectID, shooter.ShooterObjectID, true) != 0)
						{
							continue;
						}
						if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
						{
							string text = ((shooter.QuantityAssigned <= 2147473647) ? (Conversions.ToString(shooter.QuantityAssigned - shooter.QuantityFired) + "x ") : "All weapons ");
							string_0 = "";
							Weapon.WeaponSpecialMode activeSpecialMode = item2.ActiveSpecialMode;
							if (activeSpecialMode == Weapon.WeaponSpecialMode.HighAltitudeDetonation)
							{
								string_0 += "[HIGH ALT]";
							}
							if (item2.PlottedCourse.Count() > 0)
							{
								ref string reference = ref string_0;
								reference = reference + "[" + Conversions.ToString(item2.PlottedCourse.Count()) + " legs]";
							}
							DarkTreeNode darkTreeNode2 = new DarkTreeNode();
							darkTreeNode2.Text = "Alloc: " + string_0 + text + item2.get_ReferenceWeapon(theAttacker.ParentScen).Name;
							darkTreeNode2.Tag = item2;
							darkTreeNode.Nodes.Add(darkTreeNode2);
						}
						if (shooter.QuantityFired > 0)
						{
							DarkTreeNode darkTreeNode3 = new DarkTreeNode();
							darkTreeNode3.Text = "Fired: " + Conversions.ToString(shooter.QuantityFired) + "x " + item2.get_ReferenceWeapon(theAttacker.ParentScen).Name;
							darkTreeNode.Nodes.Add(darkTreeNode3);
						}
					}
				}
				pooledList.Dispose();
			}
			darkTreeNode.Expanded = true;
		}
		if (int_5 < 0 || TV_Allocations_ByAttackersOnly.SelectedNodes.Count != 0)
		{
			return;
		}
		foreach (DarkTreeNode node in TV_Allocations_ByAttackersOnly.Nodes)
		{
			if (node.VisibleIndex != int_6)
			{
				continue;
			}
			foreach (DarkTreeNode node2 in node.Nodes)
			{
				if (node2.VisibleIndex == int_5)
				{
					TV_Allocations_ByAttackersOnly.SelectNode(node2);
					break;
				}
			}
		}
	}

	private void method_9()
	{
		TV_Allocations_ByAnyone.Nodes.Clear();
		foreach (ActiveUnit activeUnits_ in Client.CurrentScenario.ActiveUnits_List)
		{
			ActiveUnit theAttacker = activeUnits_;
			if (theAttacker == null || theAttacker.IsWeapon || theAttacker.IsGroup)
			{
				continue;
			}
			PooledList<WeaponSalvo> pooledList = theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvosFromThisUnitToThisTarget(ref theAttacker, list_1[0], Client.Realtime);
			if (pooledList == null)
			{
				continue;
			}
			if (pooledList.Count > 0)
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode();
				darkTreeNode.Text = "By: " + theAttacker.Name;
				darkTreeNode.Tag = theAttacker;
				TV_Allocations_ByAnyone.Nodes.Add(darkTreeNode);
				foreach (WeaponSalvo item in pooledList)
				{
					WeaponSalvo.Shooter[] shootersList = item.ShootersList;
					foreach (WeaponSalvo.Shooter shooter in shootersList)
					{
						if (Operators.CompareString(theAttacker.ObjectID, shooter.ShooterObjectID, true) != 0)
						{
							continue;
						}
						if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
						{
							string text = ((shooter.QuantityAssigned > 2147473647) ? "All weapons " : (Conversions.ToString(shooter.QuantityAssigned - shooter.QuantityFired) + "x "));
							string_0 = "";
							Weapon.WeaponSpecialMode activeSpecialMode = item.ActiveSpecialMode;
							if (activeSpecialMode == Weapon.WeaponSpecialMode.HighAltitudeDetonation)
							{
								string_0 += "[HIGH ALT]";
							}
							if (item.PlottedCourse.Count() > 0)
							{
								ref string reference = ref string_0;
								reference = reference + "[" + Conversions.ToString(item.PlottedCourse.Count()) + " legs]";
							}
							DarkTreeNode darkTreeNode2 = new DarkTreeNode();
							darkTreeNode2.Text = "Alloc: " + string_0 + text + item.get_ReferenceWeapon(theAttacker.ParentScen).Name;
							darkTreeNode2.Tag = item;
							darkTreeNode.Nodes.Add(darkTreeNode2);
						}
						if (shooter.QuantityFired > 0)
						{
							DarkTreeNode darkTreeNode3 = new DarkTreeNode();
							darkTreeNode3.Text = "Fired: " + Conversions.ToString(shooter.QuantityFired) + "x " + item.get_ReferenceWeapon(theAttacker.ParentScen).Name;
							darkTreeNode.Nodes.Add(darkTreeNode3);
						}
					}
				}
				darkTreeNode.Expanded = true;
			}
			pooledList.Dispose();
		}
		if (int_5 >= 0 && TV_Allocations_ByAnyone.SelectedNodes.Count == 0)
		{
			foreach (DarkTreeNode node in TV_Allocations_ByAnyone.Nodes)
			{
				if (node.VisibleIndex != int_6)
				{
					continue;
				}
				foreach (DarkTreeNode node2 in node.Nodes)
				{
					if (node2.VisibleIndex == int_5)
					{
						TV_Allocations_ByAnyone.SelectNode(node2);
						break;
					}
				}
			}
		}
		((Control)TV_Allocations_ByAnyone).Refresh();
	}

	private void method_10()
	{
		if (TV_AvailableWeapons.SelectedNodes.Count == 0)
		{
			Button_Allocate.Enabled = false;
			Button_AllocateAllWeapons.Enabled = false;
			Button_AllocateSalvo.Enabled = false;
			return;
		}
		if (list_0.Count <= 0)
		{
			Button_Allocate.Enabled = false;
			Button_AllocateAllWeapons.Enabled = false;
			Button_AllocateSalvo.Enabled = false;
			return;
		}
		if (list_1.Count == 1)
		{
			Button_AllocateAllWeapons.Enabled = true;
		}
		else
		{
			Button_AllocateAllWeapons.Enabled = false;
		}
		Weapon theWeapon = (((object)TV_AvailableWeapons.SelectedNodes[0].Tag.GetType() != typeof(string)) ? ((Weapon)TV_AvailableWeapons.SelectedNodes[0].Tag) : ((Weapon)TV_AvailableWeapons.SelectedNodes[0].ParentNode.Tag));
		if (list_1.Count > 0)
		{
			if (list_0[0].Doctrine.WRA_RelevantWeapon(ref theWeapon))
			{
				Button_AllocateSalvo.Enabled = true;
			}
			else
			{
				Button_AllocateSalvo.Enabled = false;
			}
			Button_Allocate.Enabled = true;
		}
		else
		{
			Button_AllocateSalvo.Enabled = false;
			Button_Allocate.Enabled = false;
		}
	}

	private void method_11()
	{
		int x = TV_AvailableWeapons.Viewport.X;
		int y = TV_AvailableWeapons.Viewport.Y;
		TV_AvailableWeapons.Nodes.Clear();
		method_10();
		if (list_0.Count != 1)
		{
			((Control)TV_AvailableWeapons).Enabled = false;
		}
		else if (list_1.Count != 0)
		{
			if (list_1.Count > 1)
			{
				int num = 0;
				Contact_Base.ContactType type = default(Contact_Base.ContactType);
				foreach (Contact item in list_1)
				{
					if (num != 0)
					{
						if (type != item.Type)
						{
							((Control)TV_AvailableWeapons).Enabled = false;
							return;
						}
					}
					else
					{
						type = item.Type;
					}
					num++;
				}
			}
			((Control)TV_AvailableWeapons).Enabled = true;
			foreach (ActiveUnit item2 in list_0)
			{
				Weapon[] array = item2.Weaponry.AllDistinctWeaponsAboard_Actual().ToArray();
				foreach (Weapon weapon_ in array)
				{
					method_12(item2, weapon_);
				}
			}
			if (nullable_0.HasValue && TV_AvailableWeapons.SelectedNodes.Count == 0)
			{
				foreach (DarkTreeNode node in TV_AvailableWeapons.Nodes)
				{
					if (node.VisibleIndex == int_2)
					{
						foreach (DarkTreeNode node2 in node.Nodes)
						{
							if (node2.VisibleIndex == nullable_0.Value)
							{
								bool_5 = false;
								TV_AvailableWeapons.SelectNode(node2);
								bool_5 = true;
								break;
							}
						}
					}
					if (TV_AvailableWeapons.SelectedNodes.Count != 0)
					{
						break;
					}
				}
			}
			if (Client.CurrentGame.Status == Game._GameStatus.Running || (Client.Realtime && Client.RealtimeTerminal.LastGameSpeed > 0))
			{
				TV_AvailableWeapons.ScrollTo(new Point(x, y));
			}
		}
		else
		{
			((Control)TV_AvailableWeapons).Enabled = false;
		}
	}

	private void method_12(ActiveUnit activeUnit_0, Weapon weapon_0)
	{
		if (!weapon_0.IsWeaponPallet)
		{
			List<Contact> list;
			Contact theTarget = (list = list_1)[0];
			GlobalVariables.BooleanObject TargetIsDestroyed = default(GlobalVariables.BooleanObject);
			bool num = weapon_0.IsNominallySuitableForThisTarget(activeUnit_0, ref theTarget, ref TargetIsDestroyed);
			list[0] = theTarget;
			if (!num)
			{
				return;
			}
		}
		method_13(activeUnit_0, weapon_0);
	}

	private void method_13(ActiveUnit activeUnit_0, Weapon weapon_0)
	{
		_Closure$__243-0 arg = default(_Closure$__243-0);
		_Closure$__243-0 CS$<>8__locals32 = new _Closure$__243-0(arg);
		CS$<>8__locals32.$VB$Local_theAttacker = activeUnit_0;
		bool manualFire = true;
		int dBID = weapon_0.DBID;
		int num = CS$<>8__locals32.$VB$Local_theAttacker.Weaponry.TotalAvailableInventoryForThisWeapon(dBID, IncludeNonOperationalMountsAndMags: true);
		int num2 = 0;
		if (CS$<>8__locals32.$VB$Local_theAttacker.IsWeapon)
		{
			Weapon weapon = (Weapon)CS$<>8__locals32.$VB$Local_theAttacker;
			foreach (WeaponRec weaponWeapon in weapon.WeaponWeapons)
			{
				if (weaponWeapon.int_3 == dBID)
				{
					num2 = weaponWeapon.MaxLoad - weaponWeapon.CurrentLoad;
				}
			}
		}
		else
		{
			List<WeaponSalvo> list = CS$<>8__locals32.$VB$Local_theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvosFromThisUnitToAnyTarget(ref CS$<>8__locals32.$VB$Local_theAttacker);
			foreach (WeaponSalvo item5 in list)
			{
				if (item5.int_1 != dBID)
				{
					continue;
				}
				WeaponSalvo.Shooter[] shootersList = item5.ShootersList;
				foreach (WeaponSalvo.Shooter shooter in shootersList)
				{
					if (Operators.CompareString(CS$<>8__locals32.$VB$Local_theAttacker.ObjectID, shooter.ShooterObjectID, true) == 0)
					{
						num2 += shooter.QuantityAssigned;
					}
				}
			}
		}
		string text = Conversions.ToString(num) + "x " + Misc.RemoveHiddenString(weapon_0.Name);
		if (num2 > 2147473647)
		{
			text += " (All weapons allocated)";
		}
		else if (num2 > 0)
		{
			text = text + " (" + Conversions.ToString(num2) + "x allocated)";
		}
		DarkTreeNode darkTreeNode = new DarkTreeNode(text);
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		darkTreeNode.Tag = weapon_0;
		TV_AvailableWeapons.Nodes.Add(darkTreeNode);
		Waypoint[] explicitCourse = ((weaponSalvo_0 != null) ? weaponSalvo_0.PlottedCourse : null);
		int? ASL_atFiringUnit = default(int?);
		foreach (Mount mount in CS$<>8__locals32.$VB$Local_theAttacker.Mounts)
		{
			int num3 = CS$<>8__locals32.$VB$Local_theAttacker.Weaponry.HowManyOfThisWeaponOnMountTotal(mount, dBID);
			if (num3 <= 0)
			{
				continue;
			}
			ActiveUnit_Weaponry weaponry = CS$<>8__locals32.$VB$Local_theAttacker.Weaponry;
			Contact theTarget = list_1[0];
			Sensor SuitableDirectorSensor = null;
			string item = weaponry.CanThisWeaponEngageThisTarget(weapon_0, theTarget, ref ASL_atFiringUnit, manualFire, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: true, mount, ref SuitableDirectorSensor, DLZCheckRequested: true, explicitCourse).EvaluationString;
			if (!string.IsNullOrEmpty(item))
			{
				if (dictionary.ContainsKey(item))
				{
					dictionary[item] += num3;
				}
				else
				{
					dictionary.Add(item, num3);
				}
			}
		}
		if (CS$<>8__locals32.$VB$Local_theAttacker.IsAircraft)
		{
			if (weapon_0.IsWeaponPallet)
			{
				{
					foreach (IGrouping<int, Warhead> item6 in (from CW in weapon_0.Warheads
						group CW by CW.get_CarriedWeapon(CS$<>8__locals32.$VB$Local_theAttacker.ParentScen).DBID).ToList())
					{
						if (item6.ElementAtOrDefault(0).get_CarriedWeapon(CS$<>8__locals32.$VB$Local_theAttacker.ParentScen) == null)
						{
							continue;
						}
						if (!Information.IsNothing((object)((Aircraft)CS$<>8__locals32.$VB$Local_theAttacker).Loadout))
						{
							int num4 = CS$<>8__locals32.$VB$Local_theAttacker.Weaponry.HowManyOfThisWeaponOnLoadout(((Aircraft)CS$<>8__locals32.$VB$Local_theAttacker).Loadout, item6.ElementAtOrDefault(0).get_CarriedWeapon(CS$<>8__locals32.$VB$Local_theAttacker.ParentScen).DBID, weapon_0.DBID, CS$<>8__locals32.$VB$Local_theAttacker.ParentScen);
							if (num4 > 0)
							{
								ActiveUnit_Weaponry weaponry2 = CS$<>8__locals32.$VB$Local_theAttacker.Weaponry;
								Weapon theWeapon = item6.ElementAtOrDefault(0).get_CarriedWeapon(CS$<>8__locals32.$VB$Local_theAttacker.ParentScen);
								Contact theTarget2 = list_1[0];
								Sensor SuitableDirectorSensor = null;
								string item2 = weaponry2.CanThisWeaponEngageThisTarget(theWeapon, theTarget2, ref ASL_atFiringUnit, manualFire, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: true, null, ref SuitableDirectorSensor, DLZCheckRequested: true, explicitCourse).EvaluationString;
								if (!string.IsNullOrEmpty(item2))
								{
									if (!dictionary.ContainsKey(item2))
									{
										dictionary.Add(item2, num4);
									}
									else
									{
										dictionary[item2] += num4;
									}
								}
							}
						}
						method_14(CS$<>8__locals32.$VB$Local_theAttacker, item6.ElementAtOrDefault(0).get_CarriedWeapon(CS$<>8__locals32.$VB$Local_theAttacker.ParentScen), dictionary, darkTreeNode, weapon_0);
					}
					return;
				}
			}
			if (((Aircraft)CS$<>8__locals32.$VB$Local_theAttacker).Loadout != null)
			{
				int num5 = CS$<>8__locals32.$VB$Local_theAttacker.Weaponry.HowManyOfThisWeaponOnLoadout(((Aircraft)CS$<>8__locals32.$VB$Local_theAttacker).Loadout, dBID);
				if (num5 > 0)
				{
					ActiveUnit_Weaponry weaponry3 = CS$<>8__locals32.$VB$Local_theAttacker.Weaponry;
					Contact theTarget3 = list_1[0];
					Sensor SuitableDirectorSensor = null;
					string item3 = weaponry3.CanThisWeaponEngageThisTarget(weapon_0, theTarget3, ref ASL_atFiringUnit, manualFire, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: true, null, ref SuitableDirectorSensor, DLZCheckRequested: true, explicitCourse).EvaluationString;
					if (!string.IsNullOrEmpty(item3))
					{
						if (!dictionary.ContainsKey(item3))
						{
							dictionary.Add(item3, num5);
						}
						else
						{
							dictionary[item3] += num5;
						}
					}
				}
			}
		}
		if (CS$<>8__locals32.$VB$Local_theAttacker.IsWeapon && ((Weapon)CS$<>8__locals32.$VB$Local_theAttacker).IsWeaponPallet)
		{
			foreach (WeaponRec weaponWeapon2 in ((Weapon)CS$<>8__locals32.$VB$Local_theAttacker).WeaponWeapons)
			{
				int currentLoad = weaponWeapon2.CurrentLoad;
				if (currentLoad > 0)
				{
					ActiveUnit_Weaponry weaponry4 = CS$<>8__locals32.$VB$Local_theAttacker.Weaponry;
					Weapon theWeapon2 = weaponWeapon2.get_ReferenceWeapon(CS$<>8__locals32.$VB$Local_theAttacker.ParentScen);
					Contact theTarget4 = list_1[0];
					Sensor SuitableDirectorSensor = null;
					string item4 = weaponry4.CanThisWeaponEngageThisTarget(theWeapon2, theTarget4, ref ASL_atFiringUnit, manualFire, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: true, null, ref SuitableDirectorSensor, DLZCheckRequested: true, explicitCourse).EvaluationString;
					if (!string.IsNullOrEmpty(item4))
					{
						if (!dictionary.ContainsKey(item4))
						{
							dictionary.Add(item4, currentLoad);
						}
						else
						{
							dictionary[item4] += currentLoad;
						}
					}
				}
			}
			return;
		}
		method_14(CS$<>8__locals32.$VB$Local_theAttacker, weapon_0, dictionary, darkTreeNode);
	}

	private void method_14(ActiveUnit activeUnit_0, Weapon weapon_0, Dictionary<string, int> dictionary_0, DarkTreeNode darkTreeNode_1, Weapon weapon_1 = null)
	{
		weapon_0.FiringParent = activeUnit_0;
		int num = 0;
		num = ((weapon_1 != null) ? activeUnit_0.get_UnitSide(SetSideOnly: false).NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref activeUnit_0, weapon_1) : activeUnit_0.get_UnitSide(SetSideOnly: false).NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref activeUnit_0, weapon_0));
		int num2 = activeUnit_0.Weaponry.HowManyOfThisWeaponOnMagazines(weapon_0.DBID);
		if (num2 > 0)
		{
			dictionary_0.Add("Weapon is on magazines", num2);
		}
		bool flag;
		string text;
		Contact theTarget;
		Doctrine._WCS wCSForThisTargetType;
		string text2;
		string text3 = default(string);
		float? num3;
		int? num4;
		string text4;
		string text5;
		if (SimConfiguration.DefaultGamePreferences.ShowAutomaticFireInfo)
		{
			flag = true;
			text = "";
			text = ((weapon_1 != null) ? "Automatic fire with pallettized weapon is not allowed" : "Automatic fire is not allowed");
			theTarget = list_1[0];
			wCSForThisTargetType = activeUnit_0.Weaponry.GetWCSForThisTargetType(theTarget.Type);
			text2 = wCSForThisTargetType switch
			{
				Doctrine._WCS.Free => (weapon_1 == null) ? "WEAPONS FREE" : "PALLETTIZED WEAPONS FREE", 
				Doctrine._WCS.Tight => (weapon_1 == null) ? "WEAPONS TIGHT" : "PALLETTIZED WEAPONS TIGHT", 
				_ => (weapon_1 != null) ? "PALLETTIZED WEAPONS HOLD" : "WEAPONS HOLD", 
			};
			Doctrine._WRA_WeaponTargetType targetType = Contact.WRA_DetermineTargetType(ref theTarget, null, ref GlobalVariables.ObjectFalse);
			GlobalVariables.BooleanObject EmitterClassificable = null;
			Contact.WRA_DetermineTargetType(ref theTarget, null, ref EmitterClassificable);
			Doctrine._WRA_WeaponTargetType theTargetType = Contact.WRA_DetermineTargetType(ref theTarget, weapon_0, ref EmitterClassificable);
			Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_0, ref theTarget, ref theTargetType, activeUnit_0.get_UnitSide(SetSideOnly: false).ObjectID);
			if (list_1[0].ActualUnit != null)
			{
				text3 = " Target type is " + Doctrine.WRA_TargetType_String(theTarget, targetType, EmitterClassificable.ToBoolean());
			}
			Doctrine doctrine = activeUnit_0.Doctrine;
			Doctrine doctrine2 = activeUnit_0.Doctrine;
			Scenario parentScen = activeUnit_0.ParentScen;
			int dBID = weapon_0.DBID;
			float? TargetType_InheritedFiringRange = null;
			float? TargetType_UnspecifiedFiringRange = null;
			num3 = doctrine.WRA_FiringRange_AnyTargetType(doctrine2, parentScen, dBID, wRA_WeaponTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedFiringRange, ref TargetType_UnspecifiedFiringRange);
			if (Information.IsNothing((object)num3))
			{
				num3 = (float)Doctrine.WRA_FiringRange_GetDefaultFiringRange(activeUnit_0.ParentScen, weapon_0.DBID, wRA_WeaponTargetType);
			}
			TargetType_UnspecifiedFiringRange = num3;
			bool? flag2 = (TargetType_UnspecifiedFiringRange.HasValue ? new bool?(TargetType_UnspecifiedFiringRange.GetValueOrDefault() == 0f) : ((bool?)null));
			if (((!flag2) ?? flag2) == true)
			{
				Doctrine doctrine3 = activeUnit_0.Doctrine;
				Scenario parentScen2 = activeUnit_0.ParentScen;
				Weapon theWeapon = weapon_0;
				int? TargetType_InheritedWeaponQty = null;
				int? TargetType_UnspecifiedWeaponQty = null;
				num4 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine3, parentScen2, theWeapon, wRA_WeaponTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedWeaponQty, ref TargetType_UnspecifiedWeaponQty);
				if (Information.IsNothing((object)num4))
				{
					num4 = 0;
				}
			}
			else
			{
				num4 = 0;
			}
			if (!Information.IsNothing((object)num4))
			{
				TargetType_UnspecifiedFiringRange = num3;
				text4 = (((TargetType_UnspecifiedFiringRange.HasValue ? new bool?(TargetType_UnspecifiedFiringRange.GetValueOrDefault() == 0f) : ((bool?)null)) != true) ? (Doctrine.WRA_WeaponQty_String(num4, activeUnit_0, theTarget, weapon_0) + ". ") : "");
				int? TargetType_UnspecifiedWeaponQty = num4;
				flag2 = ((!TargetType_UnspecifiedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() == 0));
				if (flag2 ?? true)
				{
					TargetType_UnspecifiedFiringRange = num3;
					bool? flag3 = ((!TargetType_UnspecifiedFiringRange.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedFiringRange.GetValueOrDefault() == 0f));
					if (((!flag3) ?? flag3) == true && flag2.HasValue)
					{
						text5 = "";
						goto IL_039b;
					}
				}
				text5 = activeUnit_0.Doctrine.WRA_FiringRange_String(num3) + ". ";
			}
			else
			{
				text4 = ((weapon_1 == null) ? "Do not use weapon type against this target type" : "Do not use the pallettized weapon type against this target type");
				text5 = "";
			}
			goto IL_039b;
		}
		goto IL_06b3;
		IL_06b3:
		foreach (KeyValuePair<string, int> item in dictionary_0)
		{
			if (weapon_1 != null)
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode();
				string key = item.Key;
				string text6 = Conversions.ToString(item.Value);
				if (string.CompareOrdinal(key, "OK") != 0)
				{
					darkTreeNode.Text = text6 + "x " + weapon_0.Name + " can NOT fire. " + key + " (" + Conversions.ToString(num) + "x allocated)";
					darkTreeNode.ForeColor = Color.IndianRed;
				}
				else
				{
					int num5 = activeUnit_0.get_UnitSide(SetSideOnly: false).NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref activeUnit_0, weapon_0);
					darkTreeNode.Text = text6 + "x " + weapon_0.Name + " can FIRE (manual weapon allocation)  (" + Conversions.ToString(num5) + "x allocated)";
					darkTreeNode.ForeColor = Color.LightGreen;
				}
				darkTreeNode.Tag = weapon_0;
				darkTreeNode_1.Nodes.Add(darkTreeNode);
			}
			else
			{
				DarkTreeNode darkTreeNode2 = new DarkTreeNode();
				string key2 = item.Key;
				string text7 = Conversions.ToString(item.Value);
				if (string.CompareOrdinal(key2, "OK") == 0)
				{
					darkTreeNode2.Text = text7 + "x can FIRE (manual weapon allocation)";
					darkTreeNode2.ForeColor = Color.LightGreen;
				}
				else
				{
					darkTreeNode2.Text = text7 + "x can NOT fire. " + key2;
					darkTreeNode2.ForeColor = Color.IndianRed;
				}
				darkTreeNode2.Tag = weapon_0;
				darkTreeNode_1.Nodes.Add(darkTreeNode2);
			}
		}
		darkTreeNode_1.Expanded = true;
		return;
		IL_039b:
		if (theTarget.Type != Contact_Base.ContactType.ActivationPoint)
		{
			switch (theTarget.get_Stance(activeUnit_0.get_UnitSide(SetSideOnly: false)))
			{
			case Misc.PostureStance.Hostile:
				if (wCSForThisTargetType == Doctrine._WCS.Hold)
				{
					flag = false;
					text = ((weapon_1 == null) ? "Automatic fire is NOT allowed, Weapon Control Status (WCS) is WEAPONS HOLD" : "Automatic fire is NOT allowed, Weapon Control Status for pallettized weapon (WCS) is WEAPONS HOLD");
				}
				break;
			case Misc.PostureStance.Unfriendly:
			case Misc.PostureStance.Unknown:
				switch (wCSForThisTargetType)
				{
				case Doctrine._WCS.Tight:
					flag = false;
					text = ((weapon_1 == null) ? "Automatic fire is NOT allowed, Weapon Control Status (WCS) is WEAPONS TIGHT and target is not identified as Hostile" : "Automatic fire is NOT allowed, Weapon Control Status for pallettized weapon (WCS) is WEAPONS TIGHT and target is not identified as Hostile");
					break;
				case Doctrine._WCS.Hold:
					flag = false;
					text = ((weapon_1 == null) ? "Automatic fire is NOT allowed, Weapon Control Status (WCS) is WEAPONS HOLD" : "Automatic fire is NOT allowed, Weapon Control Status for pallkettized weapon (WCS) is WEAPONS HOLD");
					break;
				}
				break;
			}
		}
		else
		{
			flag = false;
			text = ((weapon_1 == null) ? "Automatic fire is NOT possible, target is Bearing Only Launch (BOL) point or Impact point!" : "Automatic fire with pallettized weapon is NOT possible, target is Bearing Only Launch (BOL) point or Impact point!");
		}
		if (flag)
		{
			float? TargetType_UnspecifiedFiringRange = num3;
			if ((TargetType_UnspecifiedFiringRange.HasValue ? new bool?(TargetType_UnspecifiedFiringRange.GetValueOrDefault() == 0f) : ((bool?)null)) == true)
			{
				flag = false;
				text = ((weapon_1 != null) ? ("Automatic fire is NOT allowed, Weapon Release Authorization (WRA) for the pallettized weapon says " + text5) : ("Automatic fire is NOT allowed, Weapon Release Authorization (WRA) says " + text5));
			}
			else
			{
				int? TargetType_UnspecifiedWeaponQty = num4;
				if ((TargetType_UnspecifiedWeaponQty.HasValue ? new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() == 0) : ((bool?)null)) == true)
				{
					flag = false;
					text = ((weapon_1 != null) ? ("Automatic fire is NOT allowed, Weapon Release Authorization (WRA) for the pallettized weapon says " + text4) : ("Automatic fire is NOT allowed, Weapon Release Authorization (WRA) says " + text4));
				}
			}
		}
		if (activeUnit_0.IsAircraft && weapon_0.Type == Weapon._WeaponType.Gun && list_1[0].isSurfaceOrLandContact)
		{
			Doctrine._GunStrafeGroundTargets? gunStrafeGroundTargets = default(Doctrine._GunStrafeGroundTargets?);
			if (Information.IsNothing((object)gunStrafeGroundTargets))
			{
				gunStrafeGroundTargets = activeUnit_0.Doctrine.get_GunStrafing(activeUnit_0.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			}
			byte? b = (byte?)gunStrafeGroundTargets;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
			{
				flag = false;
				text = "Automatic fire is NOT possible, doctrine says 'Do not use guns against ground and ship targets'";
			}
		}
		if (flag)
		{
			if (dictionary_0.ContainsKey("OK"))
			{
				text = ((weapon_1 == null) ? "Automatic fire is allowed." : "Automatic fire with the pallettized weapon is allowed.");
			}
			else
			{
				flag = false;
				text = ((weapon_1 != null) ? ("Automatic fire with the pallettized weapon is NOT possible, " + dictionary_0.Keys.ElementAtOrDefault(0)) : ("Automatic fire is NOT possible, " + dictionary_0.Keys.ElementAtOrDefault(0)));
			}
		}
		DarkTreeNode darkTreeNode3 = new DarkTreeNode();
		darkTreeNode3.Text = text;
		darkTreeNode3.Tag = "";
		if (!flag)
		{
			darkTreeNode3.ForeColor = Color.IndianRed;
		}
		else
		{
			darkTreeNode3.ForeColor = Color.LightGreen;
		}
		darkTreeNode_1.Nodes.Add(darkTreeNode3);
		DarkTreeNode darkTreeNode4 = new DarkTreeNode();
		darkTreeNode4.Text = "Weapon Control Status (WCS): " + text2;
		darkTreeNode4.Tag = "";
		darkTreeNode4.ForeColor = Color.DarkGray;
		darkTreeNode_1.Nodes.Add(darkTreeNode4);
		DarkTreeNode darkTreeNode5 = new DarkTreeNode();
		darkTreeNode5.Text = "Weapon Release Authorization (WRA): " + text4 + text5 + text3;
		darkTreeNode5.Tag = "";
		darkTreeNode5.ForeColor = Color.DarkGray;
		darkTreeNode_1.Nodes.Add(darkTreeNode5);
		goto IL_06b3;
	}

	private void method_15(object sender, EventArgs e)
	{
		ClearToAndBySelectionIndexes();
		list_0.Clear();
		foreach (DarkListItem selectedItem in LB_Attackers.SelectedItems)
		{
			list_0.Add((ActiveUnit)selectedItem.Tag);
			list_0.Last().ParentScen = Client.CurrentScenario;
		}
		if (list_0.Count == 1)
		{
			Button_UnitWRA.Enabled = true;
		}
		else
		{
			Button_UnitWRA.Enabled = false;
		}
		if (bool_5)
		{
			if (LB_Attackers.SelectedIndices.Count > 0)
			{
				int_0 = LB_Attackers.SelectedIndices[0];
			}
			method_11();
			method_5();
			((Control)TV_AvailableWeapons).Refresh();
			((Control)TV_Allocations_ByAttackersOnly).Refresh();
			((Control)TV_Allocations_ByAnyone).Refresh();
			((Control)TV_Allocations_ToTargetsOnly).Refresh();
			((Control)TV_Allocations_ToAnyone).Refresh();
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		ClearToAndBySelectionIndexes();
		list_1.Clear();
		foreach (DarkListItem selectedItem in LB_Targets.SelectedItems)
		{
			list_1.Add((Contact)selectedItem.Tag);
		}
		if (bool_5)
		{
			if (LB_Targets.SelectedIndices.Count != 0)
			{
				int_1 = LB_Targets.SelectedIndices[0];
			}
			method_11();
			method_5();
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		ClearToAndBySelectionIndexes();
		method_5();
	}

	private void AttackTarget_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Invalid comparison between Unknown and I4
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Invalid comparison between Unknown and I4
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Invalid comparison between Unknown and I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Invalid comparison between Unknown and I4
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Invalid comparison between Unknown and I4
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Invalid comparison between Unknown and I4
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Invalid comparison between Unknown and I4
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Invalid comparison between Unknown and I4
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Invalid comparison between Unknown and I4
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 112 && (int)e.Modifiers == 65536 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr SendMessage(IntPtr intptr_0, int int_7, IntPtr intptr_1, IntPtr intptr_2);

	public AttackTarget()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(AttackTarget_FormClosing);
		((Form)this).Load += AttackTarget_Load;
		((Control)this).KeyDown += new KeyEventHandler(AttackTarget_KeyDown);
		RTMPEnabled = true;
		IsRefreshing = false;
		Targets = new List<Contact>();
		Attackers = new List<ActiveUnit>();
		list_0 = new List<ActiveUnit>();
		list_1 = new List<Contact>();
		bool_5 = true;
		int_3 = -1;
		int_4 = -1;
		int_5 = -1;
		int_6 = -1;
		keys_0 = (Keys[])(object)new Keys[2]
		{
			(Keys)112,
			(Keys)27
		};
		InitializeComponent_1();
	}

	private void VbeLjqceUwl()
	{
		try
		{
			SendMessage(((Control)this).Handle, 11, new IntPtr(0), IntPtr.Zero);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200372", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void HkpLjwXryng(bool bool_6 = true)
	{
		try
		{
			SendMessage(((Control)this).Handle, 11, new IntPtr(-1), IntPtr.Zero);
			if (bool_6)
			{
				((Control)this).Refresh();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200373", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_18(object sender, EventArgs e)
	{
		if (list_0.Count == 1)
		{
			DoctrineForm obj = new DoctrineForm
			{
				Subject = list_0[0]
			};
			((TabControl)obj.TabControl1A).SelectedIndex = 2;
			((Control)obj).Show();
		}
	}

	private void method_19(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)Client.SelectedUnit) || Information.IsNothing((object)Client.SelectedUnit.get_UnitSide(SetSideOnly: false)) || ((Client.CurrentSide.SelectedUnits.Count <= 0 || Information.IsNothing((object)Client.SelectedUnit)) && (Client.CurrentSide.SelectedUnits.Count != 0 || Information.IsNothing((object)Client.SelectedUnit) || !Information.IsNothing((object)Client.SelectedWaypoint))))
		{
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in Client.CurrentSide.SelectedUnits)
		{
			if (selectedUnit.IsActiveUnit && !selectedUnit.IsWeapon && selectedUnit.get_UnitSide(SetSideOnly: false) == Client.CurrentSide)
			{
				ActiveUnit item = (ActiveUnit)selectedUnit;
				if (!Attackers.Contains(item))
				{
					Attackers.Add(item);
				}
			}
		}
		ListAttackers();
	}

	private void bgnLjhMuiIh(object sender, EventArgs e)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		if (list_0.Count > 0)
		{
			foreach (ActiveUnit item in list_0)
			{
				list.Add(item);
			}
		}
		foreach (ActiveUnit item2 in list)
		{
			Attackers.Remove(item2);
		}
		list_0.Clear();
		ListAttackers();
		method_11();
	}

	private void method_20(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)Client.SelectedUnit) || Client.CurrentSide.SelectedUnits.Count <= 0 || Information.IsNothing((object)Client.SelectedUnit))
		{
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in Client.CurrentSide.SelectedUnits)
		{
			if (selectedUnit.IsContact())
			{
				Contact item = (Contact)selectedUnit;
				if (!Targets.Contains(item))
				{
					Targets.Add(item);
				}
			}
		}
		ListTargets();
	}

	private void method_21(object sender, EventArgs e)
	{
		List<Contact> list = new List<Contact>();
		if (list_1.Count > 0)
		{
			foreach (Contact item in list_1)
			{
				list.Add(item);
			}
		}
		foreach (Contact item2 in list)
		{
			Targets.Remove(item2);
		}
		list_1.Clear();
		ListTargets();
		method_11();
	}

	private void method_22(object sender, EventArgs e)
	{
		if (TV_AvailableWeapons.SelectedNodes.Count == 0)
		{
			return;
		}
		DarkTreeNode darkTreeNode = TV_AvailableWeapons.SelectedNodes[0];
		Weapon weapon_ = (((object)darkTreeNode.Tag.GetType() != typeof(string)) ? ((Weapon)darkTreeNode.Tag) : ((Weapon)darkTreeNode.ParentNode.Tag));
		foreach (Contact item in list_1)
		{
			Contact contact_ = item;
			List<ActiveUnit> list;
			ActiveUnit activeUnit_ = (list = list_0)[0];
			method_23(ref activeUnit_, ref contact_, ref weapon_);
			list[0] = activeUnit_;
		}
		method_11();
		method_5();
	}

	private void method_23(ref ActiveUnit activeUnit_0, ref Contact contact_0, ref Weapon weapon_0, bool bool_6 = false)
	{
		try
		{
			Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType;
			if (!weapon_0.ValidTargets.Radar)
			{
				Weapon theW = weapon_0;
				GlobalVariables.BooleanObject EmitterClassificable = null;
				wRA_WeaponTargetType = Contact.WRA_DetermineTargetType(ref contact_0, theW, ref EmitterClassificable);
			}
			else
			{
				wRA_WeaponTargetType = Doctrine._WRA_WeaponTargetType.Emitter_Unspecified;
			}
			if (activeUnit_0.IsAircraft)
			{
				WeaponRec[] weapons = ((Aircraft)activeUnit_0).Loadout.Weapons;
				foreach (WeaponRec weaponRec in weapons)
				{
					if (!weaponRec.get_ReferenceWeapon(activeUnit_0.ParentScen).IsWeaponPallet)
					{
						continue;
					}
					if (weaponRec.get_ReferenceWeapon(activeUnit_0.ParentScen).WeaponWeapons.Count == 0)
					{
						weaponRec.get_ReferenceWeapon(activeUnit_0.ParentScen).InitializeWeaponWeaponsPallet();
					}
					foreach (WeaponRec weaponWeapon in weaponRec.get_ReferenceWeapon(activeUnit_0.ParentScen).WeaponWeapons)
					{
						if (weaponWeapon.int_3 == weapon_0.DBID)
						{
							weapon_0 = weaponRec.get_ReferenceWeapon(activeUnit_0.ParentScen);
						}
					}
				}
			}
			int? num = default(int?);
			int? TargetType_InheritedWeaponQty;
			if (weapon_0.IsWeaponPallet)
			{
				if (weapon_0.WeaponWeapons.Count == 0)
				{
					weapon_0.InitializeWeaponWeaponsPallet();
				}
				int? theWeaponQty_ToFire = default(int?);
				foreach (WeaponRec weaponWeapon2 in weapon_0.WeaponWeapons)
				{
					Doctrine doctrine = activeUnit_0.Doctrine;
					Scenario parentScen = activeUnit_0.ParentScen;
					Weapon theWeapon = weaponWeapon2.get_ReferenceWeapon(activeUnit_0.ParentScen);
					Doctrine._WRA_WeaponTargetType selectedNodeTargetType = wRA_WeaponTargetType;
					TargetType_InheritedWeaponQty = null;
					int? TargetType_UnspecifiedWeaponQty = null;
					num = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine, parentScen, theWeapon, selectedNodeTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedWeaponQty, ref TargetType_UnspecifiedWeaponQty);
					TargetType_UnspecifiedWeaponQty = num;
					if ((TargetType_UnspecifiedWeaponQty.HasValue ? new bool?(TargetType_UnspecifiedWeaponQty == -99) : ((bool?)null)) == true)
					{
						num = int.MaxValue;
					}
					if (!num.HasValue)
					{
						continue;
					}
					TargetType_UnspecifiedWeaponQty = num;
					if ((TargetType_UnspecifiedWeaponQty.HasValue ? new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() < 0) : ((bool?)null)) == true)
					{
						num = activeUnit_0.get_UnitSide(SetSideOnly: false).ConvertSalvoWeaponQty_To_ActualQuantity(theWeaponQty_ToFire, ref activeUnit_0, ref contact_0, ref weapon_0);
						TargetType_UnspecifiedWeaponQty = num;
						if (((!TargetType_UnspecifiedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedWeaponQty == -99)) == true)
						{
							num = int.MaxValue;
						}
					}
					if (!num.HasValue)
					{
						return;
					}
					TargetType_UnspecifiedWeaponQty = num;
					if (((!TargetType_UnspecifiedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() == 0)) != true)
					{
						TargetType_UnspecifiedWeaponQty = num;
						if ((TargetType_UnspecifiedWeaponQty.HasValue ? new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() == 0) : ((bool?)null)) != true)
						{
							List<ActiveUnit> list;
							ActiveUnit activeUnit_1 = (list = list_0)[0];
							Weapon weapon_1 = weaponWeapon2.get_ReferenceWeapon(activeUnit_0.ParentScen);
							int int_ = num.Value;
							method_25(ref activeUnit_1, ref contact_0, ref weapon_1, ref int_, weapon_0);
							list[0] = activeUnit_1;
							break;
						}
					}
					return;
				}
			}
			else
			{
				Doctrine doctrine2 = activeUnit_0.Doctrine;
				Scenario parentScen2 = activeUnit_0.ParentScen;
				Weapon theWeapon2 = weapon_0;
				Doctrine._WRA_WeaponTargetType selectedNodeTargetType2 = wRA_WeaponTargetType;
				int? TargetType_UnspecifiedWeaponQty = null;
				TargetType_InheritedWeaponQty = null;
				num = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine2, parentScen2, theWeapon2, selectedNodeTargetType2, FindInheritedValuesOnly: false, ref TargetType_UnspecifiedWeaponQty, ref TargetType_InheritedWeaponQty);
			}
			if (Information.IsNothing((object)num))
			{
				return;
			}
			TargetType_InheritedWeaponQty = num;
			if ((TargetType_InheritedWeaponQty.HasValue ? new bool?(TargetType_InheritedWeaponQty.GetValueOrDefault() == 0) : ((bool?)null)) == true)
			{
				return;
			}
			TargetType_InheritedWeaponQty = num;
			if ((TargetType_InheritedWeaponQty.HasValue ? new bool?(TargetType_InheritedWeaponQty == -99) : ((bool?)null)) == true)
			{
				num = int.MaxValue;
			}
			else
			{
				TargetType_InheritedWeaponQty = num;
				if ((TargetType_InheritedWeaponQty.HasValue ? new bool?(TargetType_InheritedWeaponQty.GetValueOrDefault() < 0) : ((bool?)null)) == true)
				{
					num = activeUnit_0.get_UnitSide(SetSideOnly: false).ConvertSalvoWeaponQty_To_ActualQuantity(num, ref activeUnit_0, ref contact_0, ref weapon_0);
				}
			}
			int num2 = ((!weapon_0.IsWeaponPallet) ? activeUnit_0.Weaponry.TotalAvailableInventoryForThisWeapon(weapon_0.DBID, IncludeNonOperationalMountsAndMags: false) : activeUnit_0.Weaponry.TotalAvailableInventoryForThisWeapon(weapon_0.DBID, IncludeNonOperationalMountsAndMags: false, weapon_0));
			num2 -= activeUnit_0.get_UnitSide(SetSideOnly: false).NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref activeUnit_0, weapon_0);
			TargetType_InheritedWeaponQty = num;
			if ((TargetType_InheritedWeaponQty.HasValue ? new bool?(TargetType_InheritedWeaponQty.GetValueOrDefault() > num2) : ((bool?)null)) == true)
			{
				num = num2;
			}
			TargetType_InheritedWeaponQty = num;
			if (((!TargetType_InheritedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_InheritedWeaponQty.GetValueOrDefault() > 0)) == true)
			{
				if (!Client.Realtime)
				{
					activeUnit_0.AI.TargetThisContact(contact_0, AddedManually: true, PriorityTarget: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc);
					ActiveUnit_Weaponry weaponry = activeUnit_0.Weaponry;
					Contact theTarget = contact_0;
					int dBID = weapon_0.DBID;
					int value = num.Value;
					Doctrine._GunStrafeGroundTargets? GunStrafingSalvo = null;
					weaponry.CreateSalvo(theTarget, dBID, value, IsManual: true, ref GunStrafingSalvo, WeaponSalvo.SCHEDULE_AS_MANUAL, CreatingSalvoForPalletWeapon: false, bool_6, RebuildSalvoCache: true);
				}
				else
				{
					Client.RealtimeTerminal.SendCreateWeaponSalvoAction(activeUnit_0, contact_0, weapon_0.DBID, num.Value, WeaponSalvo.SCHEDULE_AS_MANUAL, creatingSalvoForPallettdWeapon: false, bool_6, rebuildSalvoCache: true);
				}
				MyProject.Forms.MainForm.MapRender_Tactical();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 101234", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_24(object sender, EventArgs e)
	{
		int int_ = Convert.ToInt32(((NumericUpDown)NUD_NumberOfWeapons).Value);
		if (!Versioned.IsNumeric((object)((NumericUpDown)NUD_NumberOfWeapons).Value) || decimal.Compare(((NumericUpDown)NUD_NumberOfWeapons).Value, 0m) <= 0 || TV_AvailableWeapons.SelectedNodes.Count == 0)
		{
			return;
		}
		DarkTreeNode darkTreeNode = TV_AvailableWeapons.SelectedNodes[0];
		Weapon weapon_ = (((object)darkTreeNode.Tag.GetType() != typeof(string)) ? ((Weapon)darkTreeNode.Tag) : ((Weapon)darkTreeNode.ParentNode.Tag));
		foreach (Contact item in list_1)
		{
			Contact contact_ = item;
			if (darkTreeNode.ParentNode != null)
			{
				Weapon weapon = (Weapon)darkTreeNode.ParentNode.Tag;
				if (!weapon.IsWeaponPallet)
				{
					List<ActiveUnit> list;
					ActiveUnit activeUnit_ = (list = list_0)[0];
					method_25(ref activeUnit_, ref contact_, ref weapon_, ref int_);
					list[0] = activeUnit_;
				}
				else
				{
					List<ActiveUnit> list;
					ActiveUnit activeUnit_ = (list = list_0)[0];
					method_25(ref activeUnit_, ref contact_, ref weapon_, ref int_, weapon);
					list[0] = activeUnit_;
				}
			}
			else
			{
				List<ActiveUnit> list;
				ActiveUnit activeUnit_ = (list = list_0)[0];
				method_25(ref activeUnit_, ref contact_, ref weapon_, ref int_);
				list[0] = activeUnit_;
			}
		}
		method_11();
		method_5();
	}

	private void method_25(ref ActiveUnit activeUnit_0, ref Contact contact_0, ref Weapon weapon_0, ref int int_7, Weapon weapon_1 = null)
	{
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			int num = activeUnit_0.Weaponry.TotalAvailableInventoryForThisWeapon(weapon_0.DBID, IncludeNonOperationalMountsAndMags: false, weapon_1) - activeUnit_0.get_UnitSide(SetSideOnly: false).NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref activeUnit_0, weapon_0);
			int num2;
			if (int_7 > num)
			{
				int_7 = num;
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			int num3 = num2;
			if (activeUnit_0.IsAircraft)
			{
				WeaponRec[] weapons = ((Aircraft)activeUnit_0).Loadout.Weapons;
				foreach (WeaponRec weaponRec in weapons)
				{
					if (!weaponRec.get_ReferenceWeapon(activeUnit_0.ParentScen).IsWeaponPallet)
					{
						continue;
					}
					if (weaponRec.get_ReferenceWeapon(activeUnit_0.ParentScen).WeaponWeapons.Count == 0)
					{
						weaponRec.get_ReferenceWeapon(activeUnit_0.ParentScen).InitializeWeaponWeaponsPallet();
					}
					foreach (WeaponRec weaponWeapon in weaponRec.get_ReferenceWeapon(activeUnit_0.ParentScen).WeaponWeapons)
					{
						if (weaponWeapon.int_3 == weapon_0.DBID)
						{
							weapon_1 = weaponRec.get_ReferenceWeapon(activeUnit_0.ParentScen);
							num3 = weaponRec.CurrentLoad;
						}
					}
				}
			}
			int dBID = weapon_0.DBID;
			int num4 = 0;
			int num5 = 0;
			if (weapon_1 != null)
			{
				int numberOfUnallocatedSubWeaponsInExsitingSalvos = activeUnit_0.Weaponry.GetNumberOfUnallocatedSubWeaponsInExsitingSalvos(weapon_1.DBID, weapon_0.DBID);
				int num6 = 0;
				num4 = weapon_1.WeaponWeapons.FirstOrDefault().CurrentLoad;
				for (num6 = numberOfUnallocatedSubWeaponsInExsitingSalvos - int_7; num6 < 0; num6 += num4)
				{
					if (num4 <= 0)
					{
						break;
					}
				}
				if (num6 > 0)
				{
					DarkMessageBox.ShowWarning("the WHOLE pallet will be dropped even if the pallet contains unallocated weapon(s) " + num6 + " weapon(s) unallocated", "Pallet contains unallocated weapon(s)");
				}
			}
			if (int_7 <= 0)
			{
				return;
			}
			int mustRefreshMainForm;
			if (weapon_1 != null)
			{
				int num7 = 0;
				while (num5 <= num3)
				{
					num7 += num4;
					num5++;
					if (num7 >= int_7)
					{
						break;
					}
				}
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendCreateWeaponSalvoAction(activeUnit_0, contact_0, weapon_0.DBID, int_7, WeaponSalvo.SCHEDULE_AS_PALLETIZED_WEAPON, creatingSalvoForPallettdWeapon: false, creatingSalvoForPallettizedWeapon: true, rebuildSalvoCache: true);
					mustRefreshMainForm = 1;
				}
				else
				{
					activeUnit_0.AI.TargetThisContact(contact_0, AddedManually: true, PriorityTarget: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc);
					ActiveUnit_Weaponry weaponry = activeUnit_0.Weaponry;
					Contact theTarget = contact_0;
					int dBID2 = weapon_0.DBID;
					int theWeaponQty = int_7;
					Doctrine._GunStrafeGroundTargets? GunStrafingSalvo = null;
					weaponry.CreateSalvo(theTarget, dBID2, theWeaponQty, IsManual: true, ref GunStrafingSalvo, WeaponSalvo.SCHEDULE_AS_PALLETIZED_WEAPON, CreatingSalvoForPalletWeapon: false, CreatingSalvoForPallettizedWeapon: true, RebuildSalvoCache: true);
					mustRefreshMainForm = 1;
				}
			}
			else if (weapon_0.IsWeaponPallet && weapon_1 == null)
			{
				if (weapon_0.WeaponWeapons.Count == 0)
				{
					weapon_0.InitializeWeaponWeaponsPallet();
				}
				dBID = weapon_0.WeaponWeapons[0].int_3;
				int_7 *= weapon_0.WeaponWeapons[0].CurrentLoad;
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendCreateWeaponSalvoAction(activeUnit_0, contact_0, dBID, int_7, WeaponSalvo.SCHEDULE_AS_PALLETIZED_WEAPON, creatingSalvoForPallettdWeapon: false, creatingSalvoForPallettizedWeapon: true, rebuildSalvoCache: true);
					mustRefreshMainForm = 1;
				}
				else
				{
					activeUnit_0.AI.TargetThisContact(contact_0, AddedManually: true, PriorityTarget: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc);
					ActiveUnit_Weaponry weaponry2 = activeUnit_0.Weaponry;
					Contact theTarget2 = contact_0;
					int theWeaponDBID = dBID;
					int theWeaponQty2 = int_7;
					Doctrine._GunStrafeGroundTargets? GunStrafingSalvo = null;
					weaponry2.CreateSalvo(theTarget2, theWeaponDBID, theWeaponQty2, IsManual: true, ref GunStrafingSalvo, WeaponSalvo.SCHEDULE_AS_PALLETIZED_WEAPON, CreatingSalvoForPalletWeapon: false, CreatingSalvoForPallettizedWeapon: true, RebuildSalvoCache: true);
					mustRefreshMainForm = 1;
				}
			}
			else if (Client.Realtime)
			{
				Client.RealtimeTerminal.SendCreateWeaponSalvoAction(activeUnit_0, contact_0, weapon_0.DBID, int_7, WeaponSalvo.SCHEDULE_AS_MANUAL, creatingSalvoForPallettdWeapon: false, creatingSalvoForPallettizedWeapon: false, rebuildSalvoCache: true);
				mustRefreshMainForm = 1;
			}
			else
			{
				activeUnit_0.AI.TargetThisContact(contact_0, AddedManually: true, PriorityTarget: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc);
				ActiveUnit_Weaponry weaponry3 = activeUnit_0.Weaponry;
				Contact theTarget3 = contact_0;
				int dBID3 = weapon_0.DBID;
				int theWeaponQty3 = int_7;
				Doctrine._GunStrafeGroundTargets? GunStrafingSalvo = null;
				weaponry3.CreateSalvo(theTarget3, dBID3, theWeaponQty3, IsManual: true, ref GunStrafingSalvo, WeaponSalvo.SCHEDULE_AS_MANUAL, CreatingSalvoForPalletWeapon: false, CreatingSalvoForPallettizedWeapon: false, RebuildSalvoCache: true);
				mustRefreshMainForm = 1;
			}
			Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 101235", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_26(object sender, EventArgs e)
	{
		try
		{
			if (TV_AvailableWeapons.SelectedNodes.Count == 0)
			{
				return;
			}
			DarkTreeNode darkTreeNode = TV_AvailableWeapons.SelectedNodes[0];
			Weapon weapon = (((object)darkTreeNode.Tag.GetType() != typeof(string)) ? ((Weapon)darkTreeNode.Tag) : ((Weapon)darkTreeNode.ParentNode.Tag));
			int num = list_0[0].Weaponry.TotalAvailableInventoryForThisWeapon(weapon.DBID, IncludeNonOperationalMountsAndMags: false);
			int num2 = num;
			Side side = list_0[0].get_UnitSide(SetSideOnly: false);
			List<ActiveUnit> list;
			ActiveUnit theAttacker = (list = list_0)[0];
			int num3 = side.NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref theAttacker, weapon);
			list[0] = theAttacker;
			num = num2 - num3;
			if (num > 0)
			{
				bool flag = false;
				if (list_0[0].IsAircraft)
				{
					WeaponRec[] weapons = ((Aircraft)list_0[0]).Loadout.Weapons;
					foreach (WeaponRec weaponRec in weapons)
					{
						if (!weaponRec.get_ReferenceWeapon(list_0[0].ParentScen).IsWeaponPallet)
						{
							continue;
						}
						if (weaponRec.get_ReferenceWeapon(list_0[0].ParentScen).WeaponWeapons.Count == 0)
						{
							weaponRec.get_ReferenceWeapon(list_0[0].ParentScen).InitializeWeaponWeaponsPallet();
						}
						foreach (WeaponRec weaponWeapon in weaponRec.get_ReferenceWeapon(list_0[0].ParentScen).WeaponWeapons)
						{
							if (weaponWeapon.int_3 == weapon.DBID)
							{
								flag = true;
								Weapon weapon2 = weaponRec.get_ReferenceWeapon(list_0[0].ParentScen);
								int currentLoad = weaponRec.CurrentLoad;
								if (Client.Realtime)
								{
									Client.RealtimeTerminal.SendCreateWeaponSalvoAction(list_0[0], list_1[0], weapon2.DBID, currentLoad, WeaponSalvo.SCHEDULE_AS_MANUAL, creatingSalvoForPallettdWeapon: false, creatingSalvoForPallettizedWeapon: true);
									continue;
								}
								list_0[0].AI.TargetThisContact(list_1[0], AddedManually: true, PriorityTarget: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc);
								ActiveUnit_Weaponry weaponry = list_0[0].Weaponry;
								Contact theTarget = list_1[0];
								int dBID = weapon2.DBID;
								Doctrine._GunStrafeGroundTargets? GunStrafingSalvo = null;
								weaponry.CreateSalvo(theTarget, dBID, currentLoad, IsManual: true, ref GunStrafingSalvo, WeaponSalvo.SCHEDULE_AS_MANUAL, CreatingSalvoForPalletWeapon: false, CreatingSalvoForPallettizedWeapon: false, RebuildSalvoCache: true);
							}
						}
					}
				}
				int mustRefreshMainForm;
				if (!flag)
				{
					if (Client.Realtime)
					{
						Client.RealtimeTerminal.SendCreateWeaponSalvoAction(list_0[0], list_1[0], weapon.DBID, num, WeaponSalvo.SCHEDULE_AS_MANUAL, creatingSalvoForPallettdWeapon: false, creatingSalvoForPallettizedWeapon: true);
						mustRefreshMainForm = 1;
					}
					else
					{
						list_0[0].AI.TargetThisContact(list_1[0], AddedManually: true, PriorityTarget: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc);
						ActiveUnit_Weaponry weaponry2 = list_0[0].Weaponry;
						Contact theTarget2 = list_1[0];
						int dBID2 = weapon.DBID;
						int theWeaponQty = num;
						Doctrine._GunStrafeGroundTargets? GunStrafingSalvo = null;
						weaponry2.CreateSalvo(theTarget2, dBID2, theWeaponQty, IsManual: true, ref GunStrafingSalvo, WeaponSalvo.SCHEDULE_AS_MANUAL, CreatingSalvoForPalletWeapon: false, CreatingSalvoForPallettizedWeapon: false, RebuildSalvoCache: true);
						mustRefreshMainForm = 1;
					}
				}
				else
				{
					mustRefreshMainForm = 1;
				}
				Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
			}
			method_11();
			method_5();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 101236", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_27(object sender, EventArgs e)
	{
		if (((TabControl)TabControl2).SelectedIndex != 0)
		{
			method_33(bool_6: true);
		}
		else
		{
			method_32(bool_6: true);
		}
	}

	private void method_28(object sender, EventArgs e)
	{
		if (((TabControl)TabControl4).SelectedIndex != 0)
		{
			method_35(bool_6: true);
		}
		else
		{
			method_34(bool_6: true);
		}
	}

	private void method_29(object sender, MouseEventArgs e)
	{
		try
		{
			if (TV_AvailableWeapons.SelectedNodes.Count != 0 && list_1.Count <= 1)
			{
				if ((object)TV_AvailableWeapons.SelectedNodes[0].Tag.GetType() == typeof(string))
				{
					_ = (Weapon)TV_AvailableWeapons.SelectedNodes[0].ParentNode.Tag;
				}
				else
				{
					_ = (Weapon)TV_AvailableWeapons.SelectedNodes[0].Tag;
				}
				decimal value = ((NumericUpDown)NUD_NumberOfWeapons).Value;
				((NumericUpDown)NUD_NumberOfWeapons).Value = 1m;
				method_24(Button_Allocate, null);
				((NumericUpDown)NUD_NumberOfWeapons).Value = value;
				Client.MustRefreshMainForm = true;
				method_11();
				method_5();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 101237", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_30()
	{
		if (list_0.Count <= 0)
		{
			return;
		}
		list_0 = list_0.Where([SpecialName] (ActiveUnit x) => x.get_UnitSide(SetSideOnly: false) != null).ToList();
		foreach (WeaponSalvo item in list_0[0].get_UnitSide(SetSideOnly: false).WeaponSalvos.ToList())
		{
			if (item.ShootersList.Length == 0 && item.WpnQuantityAssigned == 0 && item.WpnQuantityFired == 0)
			{
				list_0[0].get_UnitSide(SetSideOnly: false).RemoveWeaponSalvo(item);
			}
		}
	}

	private void method_31(DarkTreeNode darkTreeNode_1)
	{
		if (darkTreeNode_1 == null)
		{
			return;
		}
		ActiveUnit activeUnit = (ActiveUnit)darkTreeNode_1.Tag;
		foreach (DarkTreeNode node in darkTreeNode_1.Nodes)
		{
			if (node == null || node.Tag == null || (object)node.Tag.GetType() != typeof(WeaponSalvo))
			{
				continue;
			}
			WeaponSalvo weaponSalvo = (WeaponSalvo)node.Tag;
			WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
			foreach (WeaponSalvo.Shooter shooter in shootersList)
			{
				if (Operators.CompareString(shooter.ShooterObjectID, activeUnit.ObjectID, true) == 0 && shooter.QuantityAssigned - shooter.QuantityFired > 0)
				{
					shooter.QuantityAssigned = shooter.QuantityFired;
					if (Client.Realtime)
					{
						Client.RealtimeTerminal.SendCancelWeaponSalvoAction(activeUnit, activeUnit.get_UnitSide(SetSideOnly: false), weaponSalvo, shooter.QuantityAssigned);
						continue;
					}
					Side side = list_0[0].get_UnitSide(SetSideOnly: false);
					Scenario theScen = Client.CurrentScenario;
					side.AttemptToRemoveWeaponSalvo(ref theScen, weaponSalvo, byUser: true);
				}
			}
		}
		method_11();
		method_5();
	}

	private void method_32(bool bool_6)
	{
		if (TV_Allocations_ToTargetsOnly.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag)))
		{
			return;
		}
		if (!(TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag is ActiveUnit))
		{
			if ((object)TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			WeaponSalvo weaponSalvo = (WeaponSalvo)TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag;
			if (Information.IsNothing((object)weaponSalvo))
			{
				return;
			}
			WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
			foreach (WeaponSalvo.Shooter shooter in shootersList)
			{
				foreach (ActiveUnit item in list_0)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, item.ObjectID, true) == 0 && shooter.QuantityAssigned - shooter.QuantityFired > 0)
					{
						if (bool_6)
						{
							shooter.QuantityAssigned = shooter.QuantityFired;
						}
						else
						{
							shooter.QuantityAssigned--;
						}
						if (Client.Realtime)
						{
							Client.RealtimeTerminal.SendCancelWeaponSalvoAction(item, item.get_UnitSide(SetSideOnly: false), weaponSalvo, shooter.QuantityAssigned);
							continue;
						}
						Side side = list_0[0].get_UnitSide(SetSideOnly: false);
						Scenario theScen = Client.CurrentScenario;
						side.AttemptToRemoveWeaponSalvo(ref theScen, weaponSalvo);
					}
				}
			}
			method_11();
			method_5();
		}
		else
		{
			method_31(TV_Allocations_ToTargetsOnly.SelectedNodes[0]);
		}
	}

	private void method_33(bool bool_6)
	{
		if (TV_Allocations_ToAnyone.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ToAnyone.SelectedNodes[0].Tag)))
		{
			return;
		}
		if (!(TV_Allocations_ToAnyone.SelectedNodes[0].Tag is ActiveUnit))
		{
			if ((object)TV_Allocations_ToAnyone.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			WeaponSalvo weaponSalvo = (WeaponSalvo)TV_Allocations_ToAnyone.SelectedNodes[0].Tag;
			if (Information.IsNothing((object)weaponSalvo))
			{
				return;
			}
			WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
			foreach (WeaponSalvo.Shooter shooter in shootersList)
			{
				foreach (ActiveUnit item in list_0)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, item.ObjectID, true) == 0 && shooter.QuantityAssigned - shooter.QuantityFired > 0)
					{
						if (bool_6)
						{
							shooter.QuantityAssigned = shooter.QuantityFired;
						}
						else
						{
							shooter.QuantityAssigned--;
						}
						if (Client.Realtime)
						{
							Client.RealtimeTerminal.SendCancelWeaponSalvoAction(item, item.get_UnitSide(SetSideOnly: false), weaponSalvo, shooter.QuantityAssigned);
							continue;
						}
						Side side = list_0[0].get_UnitSide(SetSideOnly: false);
						Scenario theScen = Client.CurrentScenario;
						side.AttemptToRemoveWeaponSalvo(ref theScen, weaponSalvo);
					}
				}
			}
			method_11();
			method_5();
		}
		else
		{
			method_31(TV_Allocations_ToAnyone.SelectedNodes[0]);
		}
	}

	private void method_34(bool bool_6)
	{
		if (TV_Allocations_ByAttackersOnly.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag)))
		{
			return;
		}
		if (TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag is ActiveUnit)
		{
			method_31(TV_Allocations_ByAttackersOnly.SelectedNodes[0]);
		}
		else
		{
			if ((object)TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			WeaponSalvo weaponSalvo = (WeaponSalvo)TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag;
			if (Information.IsNothing((object)weaponSalvo))
			{
				return;
			}
			ActiveUnit activeUnit = list_0[0];
			WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
			foreach (WeaponSalvo.Shooter shooter in shootersList)
			{
				if (Operators.CompareString(shooter.ShooterObjectID, activeUnit.ObjectID, true) == 0 && shooter.QuantityAssigned - shooter.QuantityFired > 0)
				{
					if (!bool_6)
					{
						shooter.QuantityAssigned--;
					}
					else
					{
						shooter.QuantityAssigned = shooter.QuantityFired;
					}
					if (!Client.Realtime)
					{
						Side side = list_0[0].get_UnitSide(SetSideOnly: false);
						Scenario theScen = Client.CurrentScenario;
						side.AttemptToRemoveWeaponSalvo(ref theScen, weaponSalvo);
					}
					else
					{
						Client.RealtimeTerminal.SendCancelWeaponSalvoAction(activeUnit, activeUnit.get_UnitSide(SetSideOnly: false), weaponSalvo, shooter.QuantityAssigned);
					}
				}
			}
			method_11();
			method_5();
		}
	}

	private void method_35(bool bool_6)
	{
		if (TV_Allocations_ByAnyone.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ByAnyone.SelectedNodes[0].Tag)))
		{
			return;
		}
		if (!(TV_Allocations_ByAnyone.SelectedNodes[0].Tag is ActiveUnit))
		{
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ByAnyone.SelectedNodes[0].ParentNode.Tag)) || (object)TV_Allocations_ByAnyone.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			WeaponSalvo weaponSalvo = (WeaponSalvo)TV_Allocations_ByAnyone.SelectedNodes[0].Tag;
			if (Information.IsNothing((object)weaponSalvo))
			{
				return;
			}
			ActiveUnit activeUnit = (ActiveUnit)TV_Allocations_ByAnyone.SelectedNodes[0].ParentNode.Tag;
			WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
			foreach (WeaponSalvo.Shooter shooter in shootersList)
			{
				if (Operators.CompareString(shooter.ShooterObjectID, activeUnit.ObjectID, true) == 0 && shooter.QuantityAssigned - shooter.QuantityFired > 0)
				{
					if (!bool_6)
					{
						shooter.QuantityAssigned--;
					}
					else
					{
						shooter.QuantityAssigned = shooter.QuantityFired;
					}
					if (!Client.Realtime)
					{
						Side side = list_0[0].get_UnitSide(SetSideOnly: false);
						Scenario theScen = Client.CurrentScenario;
						side.AttemptToRemoveWeaponSalvo(ref theScen, weaponSalvo);
					}
					else
					{
						Client.RealtimeTerminal.SendCancelWeaponSalvoAction(activeUnit, activeUnit.get_UnitSide(SetSideOnly: false), weaponSalvo, shooter.QuantityAssigned);
					}
				}
			}
			method_11();
			method_5();
		}
		else
		{
			method_31(TV_Allocations_ByAnyone.SelectedNodes[0]);
		}
	}

	private void method_36(object sender, EventArgs e)
	{
		ClearToAndBySelectionIndexes();
		method_5();
	}

	private void method_37(object sender, EventArgs e)
	{
		if (bool_5)
		{
			SimConfiguration.DefaultGamePreferences.SalvoTimeout = ((CheckBox)CB_AllowTimeout).Checked;
		}
	}

	private void method_38(object sender, EventArgs e)
	{
		if (bool_5)
		{
			SimConfiguration.DefaultGamePreferences.ShowAutomaticFireInfo = ((CheckBox)CB_ShowAutomaticFireInfo).Checked;
			method_11();
		}
	}

	private void method_39(object sender, EventArgs e)
	{
		WeaponSalvo weaponSalvo;
		if (((TabControl)TabControl2).SelectedIndex != 0)
		{
			if (TV_Allocations_ToAnyone.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ToAnyone.SelectedNodes[0].Tag)) || (object)TV_Allocations_ToAnyone.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			weaponSalvo = (WeaponSalvo)TV_Allocations_ToAnyone.SelectedNodes[0].Tag;
			if (Information.IsNothing((object)weaponSalvo))
			{
				return;
			}
		}
		else
		{
			if (TV_Allocations_ToTargetsOnly.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag)) || (object)TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			weaponSalvo = (WeaponSalvo)TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag;
			if (Information.IsNothing((object)weaponSalvo))
			{
				return;
			}
		}
		Client.SelectedSalvoForPlotCourse = weaponSalvo;
		Client.CurrentUserAction = Client.UserAction.PlottingCourseForSalvo;
	}

	private void method_40(object sender, EventArgs e)
	{
		WeaponSalvo weaponSalvo;
		if (((TabControl)TabControl2).SelectedIndex != 0)
		{
			if (TV_Allocations_ToAnyone.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ToAnyone.SelectedNodes[0].Tag)) || (object)TV_Allocations_ToAnyone.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			weaponSalvo = (WeaponSalvo)TV_Allocations_ToAnyone.SelectedNodes[0].Tag;
			if (Information.IsNothing((object)weaponSalvo))
			{
				return;
			}
		}
		else
		{
			if (TV_Allocations_ToTargetsOnly.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag)) || (object)TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			weaponSalvo = (WeaponSalvo)TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag;
			if (Information.IsNothing((object)weaponSalvo))
			{
				return;
			}
		}
		if (!Information.IsNothing((object)weaponSalvo))
		{
			ArrayExtensions.Clear(ref weaponSalvo.PlottedCourse);
			if (Client.Realtime)
			{
				Client.RealtimeTerminal.SendSalvoCourseUpdate(Client.CurrentSide, weaponSalvo);
			}
			RefreshForm();
		}
	}

	private void method_41(object sender, EventArgs e)
	{
		WeaponSalvo weaponSalvo;
		if (((TabControl)TabControl4).SelectedIndex != 0)
		{
			if (TV_Allocations_ByAnyone.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ByAnyone.SelectedNodes[0].Tag)) || (object)TV_Allocations_ByAnyone.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			weaponSalvo = (WeaponSalvo)TV_Allocations_ByAnyone.SelectedNodes[0].Tag;
			if (Information.IsNothing((object)weaponSalvo))
			{
				return;
			}
		}
		else
		{
			if (TV_Allocations_ByAttackersOnly.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag)) || (object)TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			weaponSalvo = (WeaponSalvo)TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag;
			if (Information.IsNothing((object)weaponSalvo))
			{
				return;
			}
		}
		Client.SelectedSalvoForPlotCourse = weaponSalvo;
		Client.CurrentUserAction = Client.UserAction.PlottingCourseForSalvo;
	}

	private void method_42(object sender, EventArgs e)
	{
		WeaponSalvo weaponSalvo;
		if (((TabControl)TabControl4).SelectedIndex == 0)
		{
			if (TV_Allocations_ByAttackersOnly.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag)) || (object)TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			weaponSalvo = (WeaponSalvo)TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag;
			if (Information.IsNothing((object)weaponSalvo))
			{
				return;
			}
		}
		else
		{
			if (TV_Allocations_ByAnyone.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ByAnyone.SelectedNodes[0].Tag)) || (object)TV_Allocations_ByAnyone.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			weaponSalvo = (WeaponSalvo)TV_Allocations_ByAnyone.SelectedNodes[0].Tag;
			if (Information.IsNothing((object)weaponSalvo))
			{
				return;
			}
		}
		if (!Information.IsNothing((object)weaponSalvo))
		{
			ArrayExtensions.Clear(ref weaponSalvo.PlottedCourse);
			if (Client.Realtime)
			{
				Client.RealtimeTerminal.SendSalvoCourseUpdate(Client.CurrentSide, weaponSalvo);
			}
			RefreshForm();
		}
	}

	private void method_43(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)weaponSalvo_0))
		{
			((ToolStripMenuItem)TSMI_HighAltitudeDetonation).Checked = !((ToolStripMenuItem)TSMI_HighAltitudeDetonation).Checked;
			if (!((ToolStripMenuItem)TSMI_HighAltitudeDetonation).Checked)
			{
				weaponSalvo_0.ActiveSpecialMode = Weapon.WeaponSpecialMode.None;
			}
			else
			{
				weaponSalvo_0.ActiveSpecialMode = Weapon.WeaponSpecialMode.HighAltitudeDetonation;
			}
			RefreshForm();
		}
	}

	private void method_44()
	{
		Weapon weapon = weaponSalvo_0.get_ReferenceWeapon(Client.CurrentScenario);
		((ToolStripMenuItem)TSMI_HighAltitudeDetonation).Enabled = weapon.ValidSpecialModes.Contains(Weapon.WeaponSpecialMode.HighAltitudeDetonation);
		((ToolStripMenuItem)TSMI_HighAltitudeDetonation).Checked = weaponSalvo_0.ActiveSpecialMode == Weapon.WeaponSpecialMode.HighAltitudeDetonation;
	}

	private void method_45(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)e.Button == 2097152)
		{
			method_49(TV_Allocations_ByAnyone, e);
		}
	}

	private void method_46(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)e.Button == 2097152)
		{
			method_49(TV_Allocations_ByAttackersOnly, e);
		}
	}

	private void method_47(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)e.Button == 2097152)
		{
			method_49(TV_Allocations_ToAnyone, e);
		}
	}

	private void method_48(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)e.Button == 2097152)
		{
			method_49(TV_Allocations_ToTargetsOnly, e);
		}
	}

	private void method_49(DarkTreeView darkTreeView_0, MouseEventArgs mouseEventArgs_0)
	{
		if (darkTreeView_0.SelectedNodes.Count != 0 && darkTreeView_0.SelectedNodes[0].Tag != null && (object)darkTreeView_0.SelectedNodes[0].Tag.GetType() == typeof(WeaponSalvo))
		{
			weaponSalvo_0 = (WeaponSalvo)darkTreeView_0.SelectedNodes[0].Tag;
			method_44();
			((ToolStripDropDown)SalvoContextMenu).Show((Control)(object)darkTreeView_0, mouseEventArgs_0.X, mouseEventArgs_0.Y);
		}
	}

	private void method_50(object sender, MouseEventArgs e)
	{
		method_32(bool_6: false);
	}

	private void method_51(object sender, MouseEventArgs e)
	{
		method_33(bool_6: false);
	}

	private void method_52(object sender, EventArgs e)
	{
		if (bool_5 && TV_AvailableWeapons.SelectedNodes.Count > 0)
		{
			nullable_0 = TV_AvailableWeapons.SelectedNodes[0].VisibleIndex;
			if (!Information.IsNothing((object)TV_AvailableWeapons.SelectedNodes[0].ParentNode))
			{
				int_2 = TV_AvailableWeapons.SelectedNodes[0].ParentNode.VisibleIndex;
			}
		}
		method_10();
	}

	private void method_53(object sender, MouseEventArgs e)
	{
		method_34(bool_6: false);
	}

	private void method_54(object sender, MouseEventArgs e)
	{
		method_35(bool_6: false);
	}

	private void method_55(object sender, EventArgs e)
	{
		if (TV_Allocations_ToTargetsOnly.SelectedNodes.Count > 0)
		{
			int_3 = TV_Allocations_ToTargetsOnly.SelectedNodes[0].VisibleIndex;
			if (!Information.IsNothing((object)TV_Allocations_ToTargetsOnly.SelectedNodes[0].ParentNode))
			{
				int_4 = TV_Allocations_ToTargetsOnly.SelectedNodes[0].ParentNode.VisibleIndex;
			}
		}
		method_4();
	}

	private void method_56(object sender, EventArgs e)
	{
		if (TV_Allocations_ByAttackersOnly.SelectedNodes.Count > 0)
		{
			int_5 = TV_Allocations_ByAttackersOnly.SelectedNodes[0].VisibleIndex;
			if (!Information.IsNothing((object)TV_Allocations_ByAttackersOnly.SelectedNodes[0].ParentNode))
			{
				int_6 = TV_Allocations_ByAttackersOnly.SelectedNodes[0].ParentNode.VisibleIndex;
			}
		}
		method_4();
	}

	private void method_57(object sender, EventArgs e)
	{
		if (TV_Allocations_ToAnyone.SelectedNodes.Count > 0)
		{
			int_3 = TV_Allocations_ToAnyone.SelectedNodes[0].VisibleIndex;
			if (!Information.IsNothing((object)TV_Allocations_ToAnyone.SelectedNodes[0].ParentNode))
			{
				int_4 = TV_Allocations_ToAnyone.SelectedNodes[0].ParentNode.VisibleIndex;
			}
		}
		method_4();
	}

	private void method_58(object sender, EventArgs e)
	{
		if (TV_Allocations_ByAnyone.SelectedNodes.Count > 0)
		{
			int_5 = TV_Allocations_ByAnyone.SelectedNodes[0].VisibleIndex;
			if (!Information.IsNothing((object)TV_Allocations_ByAnyone.SelectedNodes[0].ParentNode))
			{
				int_6 = TV_Allocations_ByAnyone.SelectedNodes[0].ParentNode.VisibleIndex;
			}
		}
		method_4();
	}

	private void method_59(object sender, EventArgs e)
	{
		method_60();
	}

	private void method_60()
	{
		if (!Client.Realtime)
		{
			if (Client.CurrentSide != null)
			{
				Client.CurrentSide.ExecuteManualSalvos();
			}
		}
		else
		{
			Client.RealtimeTerminal.SendExecuteManualSalvosUpdate(Client.CurrentSide);
		}
	}

	static AttackTarget()
	{
		Class72.smethod_20();
	}
}
