using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
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
public sealed class AirOps : DarkSecondaryFormBase, GInterface0
{
	[CompilerGenerated]
	internal sealed class _Closure$__324-0
	{
		public Aircraft $VB$Local_theAircraft;

		public AirOps $VB$Me;

		public _Closure$__324-0(_Closure$__324-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAircraft = arg0.$VB$Local_theAircraft;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$Me.method_8($VB$Local_theAircraft);
		}

		static _Closure$__324-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__330-0
	{
		public Aircraft $VB$Local_myAC;

		public _Closure$__330-0(_Closure$__330-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_myAC = arg0.$VB$Local_myAC;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(TreeGridNode theNode)
		{
			if (theNode != null)
			{
				return ((DataGridViewBand)theNode).Tag == $VB$Local_myAC;
			}
			return false;
		}

		static _Closure$__330-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__335-0
	{
		public int $VB$Local_theDBID;

		public _Closure$__335-0(_Closure$__335-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(Aircraft AC)
		{
			return AC.DBID == $VB$Local_theDBID;
		}

		[SpecialName]
		internal bool _Lambda$__4(Aircraft AC)
		{
			return AC.DBID == $VB$Local_theDBID;
		}

		static _Closure$__335-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__395-0
	{
		public List<Aircraft> $VB$Local_theCol;

		public _Closure$__395-2 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__395-0(_Closure$__395-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theCol = arg0.$VB$Local_theCol;
			}
		}

		[SpecialName]
		internal void _Lambda$__6()
		{
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Expected O, but got Unknown
			using List<Aircraft>.Enumerator enumerator = $VB$Local_theCol.GetEnumerator();
			_Closure$__395-3 closure$__395- = default(_Closure$__395-3);
			_Closure$__395-1 closure$__395-2 = default(_Closure$__395-1);
			while (enumerator.MoveNext())
			{
				closure$__395- = new _Closure$__395-3(closure$__395-)
				{
					$VB$NonLocal_$VB$Closure_3 = this,
					$VB$Local_theAC = enumerator.Current
				};
				closure$__395-2 = new _Closure$__395-1(closure$__395-2)
				{
					$VB$NonLocal_$VB$Closure_4 = closure$__395-
				};
				if (Information.IsNothing((object)closure$__395-2.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.Loadout))
				{
					closure$__395-2.$VB$Local_theLoadoutName = "No Loadout";
				}
				else
				{
					closure$__395-2.$VB$Local_theLoadoutName = closure$__395-2.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.Loadout.Name;
				}
				if (Information.IsNothing((object)closure$__395-2.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.ActiveMissionOrPackage()))
				{
					if (Information.IsNothing((object)closure$__395-2.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.AssignedTaskPool))
					{
						closure$__395-2.$VB$Local_MissionText = "-";
					}
					else
					{
						closure$__395-2.$VB$Local_MissionText = closure$__395-2.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.AssignedTaskPool.Name + " (Task Pool)";
					}
				}
				else
				{
					string text = "";
					if (closure$__395-2.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.AI.IsEscort)
					{
						text = ", Escort";
					}
					closure$__395-2.$VB$Local_MissionText = closure$__395-2.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.ActiveMissionOrPackage().Name + " (" + closure$__395-2.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.ActiveMissionOrPackage().get_DescriptionString(Client.CurrentScenario) + text + ")";
				}
				closure$__395-2.$VB$Local_theName = closure$__395-2.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.Name;
				if (((ActiveUnit)closure$__395-2.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC).get_UnitSide(SetSideOnly: false) != Client.CurrentSide)
				{
					closure$__395-2.$VB$Local_theName = closure$__395-2.$VB$Local_theName + " (" + ((ActiveUnit)closure$__395-2.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC).get_UnitSide(SetSideOnly: false).Name + ")";
				}
				((Control)$VB$NonLocal_$VB$Closure_2.$VB$Me.TGV_Aircraft).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__395-2._Lambda$__7));
				bool bool_ = $VB$NonLocal_$VB$Closure_2.$VB$Me.bool_6;
				Aircraft aircraft = closure$__395-2.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC;
				string ReasonForNot = null;
				if (!(bool_ & (aircraft.IsAvailableForOps(ref ReasonForNot) == 2)))
				{
					((DataGridViewRow)closure$__395-2.$VB$Local_theNode).Visible = true;
				}
				else
				{
					((DataGridViewRow)closure$__395-2.$VB$Local_theNode).Visible = false;
				}
				if (closure$__395-2.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.Loadout != null && closure$__395-2.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.LoadoutDBID > 0)
				{
					closure$__395-2.$VB$Local_theNode.Cells[3].Style.Font = new Font("Segoe UI", 8.25f, (FontStyle)4);
				}
			}
		}

		static _Closure$__395-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__395-1
	{
		public TreeGridNode $VB$Local_theNode;

		public string $VB$Local_theName;

		public string $VB$Local_MissionText;

		public string $VB$Local_theLoadoutName;

		public _Closure$__395-3 $VB$NonLocal_$VB$Closure_4;

		public _Closure$__395-1(_Closure$__395-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theNode = arg0.$VB$Local_theNode;
				$VB$Local_theName = arg0.$VB$Local_theName;
				$VB$Local_MissionText = arg0.$VB$Local_MissionText;
				$VB$Local_theLoadoutName = arg0.$VB$Local_theLoadoutName;
			}
		}

		[SpecialName]
		internal void _Lambda$__7()
		{
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			TreeGridNodeCollection nodes = $VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_e.Node.Nodes;
			object[] obj = new object[6]
			{
				$VB$Local_theName,
				$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.AirOps.ConditionString,
				$VB$Local_MissionText,
				Misc.RemoveHiddenString($VB$Local_theLoadoutName),
				null,
				null
			};
			long seconds = (long)Math.Round($VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.AirOps.ConditionTimer);
			Aircraft aircraft = $VB$NonLocal_$VB$Closure_4.$VB$Local_theAC;
			string ReasonForNot = null;
			obj[4] = Misc.TimeString(seconds, aircraft.IsAvailableForOps(ref ReasonForNot));
			obj[5] = $VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.QuickTurnaroundString();
			$VB$Local_theNode = nodes.Add(obj);
			((DataGridViewRow)$VB$Local_theNode).DefaultCellStyle.Font = new Font(((Control)$VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Me).Font, (FontStyle)0);
			$VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Me.method_71($VB$Local_theNode, $VB$NonLocal_$VB$Closure_4.$VB$Local_theAC);
			((DataGridViewBand)$VB$Local_theNode).Tag = $VB$NonLocal_$VB$Closure_4.$VB$Local_theAC;
		}

		static _Closure$__395-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__395-2
	{
		public ExpandedEventArgs $VB$Local_e;

		public AirOps $VB$Me;

		public _Closure$__395-2(_Closure$__395-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_e = arg0.$VB$Local_e;
			}
		}

		static _Closure$__395-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__395-3
	{
		public Aircraft $VB$Local_theAC;

		public _Closure$__395-0 $VB$NonLocal_$VB$Closure_3;

		public _Closure$__395-3(_Closure$__395-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAC = arg0.$VB$Local_theAC;
			}
		}

		static _Closure$__395-3()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TabControl1")]
	private DarkUITabControl _TabControl1;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private Timer timer_0;

	[AccessedThroughProperty("TSL_LaunchIndividually")]
	[CompilerGenerated]
	private ToolStripButton jRoStfyvQl6;

	[CompilerGenerated]
	[AccessedThroughProperty("TSL_ReadyAC")]
	private ToolStripButton _TSL_ReadyAC;

	[CompilerGenerated]
	[AccessedThroughProperty("TSL_LaunchAsGroup")]
	private ToolStripButton _TSL_LaunchAsGroup;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer2")]
	private Timer timer_1;

	[AccessedThroughProperty("TGV_Aircraft")]
	[CompilerGenerated]
	private DarkTreeGridView _TGV_Aircraft;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_AbortLaunch")]
	private ToolStripButton _TSB_AbortLaunch;

	[CompilerGenerated]
	[AccessedThroughProperty("DGV_LoadoutItems")]
	private DarkDataGridView _DGV_LoadoutItems;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_SetReadyTime")]
	private ToolStripButton _TSB_SetReadyTime;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_Rename")]
	private ToolStripButton cUrStUbRyk0;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_Delete")]
	private ToolStripButton _TSB_Delete;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_NumberOfSorties")]
	private DarkUIComboBox _Combo_NumberOfSorties;

	[CompilerGenerated]
	[AccessedThroughProperty("CMenu_AirOps")]
	private ContextMenuStrip _CMenu_Unit;

	[AccessedThroughProperty("TSMI_Doctrine")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _TSMI_Doctrine;

	[CompilerGenerated]
	[AccessedThroughProperty("TSMI_AssignToMission")]
	private DarkToolStripMenuItem _TSMI_AssignToMission;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_AssignToMission")]
	private ToolStripDropDownButton _TSB_AssignToMission;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_Doctrine")]
	private ToolStripButton _TSB_Doctrine;

	[CompilerGenerated]
	[AccessedThroughProperty("LaunchIndividuallyToolStripMenuItem")]
	private DarkToolStripMenuItem _LaunchIndividuallyToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("LaunchAsGroupsToolStripMenuItem")]
	private DarkToolStripMenuItem _LaunchAsGroupsToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("ReadyArmToolStripMenuItem")]
	private DarkToolStripMenuItem _ReadyArmToolStripMenuItem;

	[AccessedThroughProperty("AbortLaunchToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _AbortLaunchToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("SetTimeToReadyToolStripMenuItem")]
	private DarkToolStripMenuItem _SetTimeToReadyToolStripMenuItem;

	[AccessedThroughProperty("RenameToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _RenameToolStripMenuItem;

	[AccessedThroughProperty("RemoveToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _RemoveToolStripMenuItem;

	[AccessedThroughProperty("AddLoadoutToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _AddLoadoutToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_Cargo")]
	private ToolStripButton _TSB_Cargo;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_QuickTurnaround")]
	private DarkCheckBox _CB_QuickTurnaround;

	[AccessedThroughProperty("Button_AddFac")]
	[CompilerGenerated]
	private ToolStripButton _Button_AddFac;

	[AccessedThroughProperty("Button_RemoveFac")]
	[CompilerGenerated]
	private ToolStripButton _Button_RemoveFac;

	[CompilerGenerated]
	[AccessedThroughProperty("btnEXPCOL")]
	private DarkUIButton darkUIButton_0;

	[CompilerGenerated]
	[AccessedThroughProperty("btnHideShowMaintenance")]
	private DarkUIButton _btnHideShowMaintenance;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_AddHostedUnit")]
	private ToolStripButton _TSB_AddHostedUnit;

	[CompilerGenerated]
	private bool bool_2;

	public HashSet<string> SelectedHosts_IDs;

	private HashSet<string> hashSet_0;

	private string string_0;

	private List<Aircraft> list_0;

	private List<Aircraft> list_1;

	private MaintainScrollPosition maintainScrollPosition_0;

	private bool bool_3;

	private List<int> list_2;

	private int int_0;

	private DataTable dataTable_0;

	private DataTable dataTable_1;

	private DataTable dataTable_2;

	private int int_1;

	private bool bool_4;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private bool bool_5;

	private bool bool_6;

	private Dictionary<int, int> dictionary_0;

	[CompilerGenerated]
	[AccessedThroughProperty("BW_TGV_Aircraft")]
	private BackgroundWorker backgroundWorker_0;

	private Keys[] keys_0;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	[CompilerGenerated]
	private bool bool_10;

	private bool bool_11;

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
			EventHandler eventHandler = method_21;
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

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

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
			EventHandler eventHandler = method_11;
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

	[field: AccessedThroughProperty("Facilities")]
	internal virtual TreeGridColumn Facilities { get; set; }

	[field: AccessedThroughProperty("theStatus")]
	internal virtual TreeGridColumn theStatus { get; set; }

	internal virtual ToolStripButton TSL_LaunchIndividually
	{
		[CompilerGenerated]
		get
		{
			return jRoStfyvQl6;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			ToolStripButton val = jRoStfyvQl6;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			jRoStfyvQl6 = value;
			val = jRoStfyvQl6;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSL_ReadyAC
	{
		[CompilerGenerated]
		get
		{
			return _TSL_ReadyAC;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_25;
			ToolStripButton val = _TSL_ReadyAC;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSL_ReadyAC = value;
			val = _TSL_ReadyAC;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSL_LaunchAsGroup
	{
		[CompilerGenerated]
		get
		{
			return _TSL_LaunchAsGroup;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_29;
			ToolStripButton val = _TSL_LaunchAsGroup;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSL_LaunchAsGroup = value;
			val = _TSL_LaunchAsGroup;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TV_Facilities")]
	internal virtual DarkTreeView TV_Facilities { get; set; }

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
			timer_1 = value;
		}
	}

	private virtual DarkTreeGridView TGV_Aircraft
	{
		[CompilerGenerated]
		get
		{
			return _TGV_Aircraft;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_27);
			CollapsingEventHandler value2 = method_28;
			EventHandler eventHandler = method_35;
			ExpandedEventHandler value3 = method_70;
			DataGridViewCellMouseEventHandler val2 = new DataGridViewCellMouseEventHandler(method_79);
			DarkTreeGridView darkTreeGridView = _TGV_Aircraft;
			if (darkTreeGridView != null)
			{
				((DataGridView)darkTreeGridView).CellContentClick -= val;
				darkTreeGridView.NodeCollapsing -= value2;
				((DataGridView)darkTreeGridView).SelectionChanged -= eventHandler;
				darkTreeGridView.NodeExpanded -= value3;
				((DataGridView)darkTreeGridView).ColumnHeaderMouseClick -= val2;
			}
			_TGV_Aircraft = value;
			darkTreeGridView = _TGV_Aircraft;
			if (darkTreeGridView != null)
			{
				((DataGridView)darkTreeGridView).CellContentClick += val;
				darkTreeGridView.NodeCollapsing += value2;
				((DataGridView)darkTreeGridView).SelectionChanged += eventHandler;
				darkTreeGridView.NodeExpanded += value3;
				((DataGridView)darkTreeGridView).ColumnHeaderMouseClick += val2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator1")]
	internal virtual ToolStripSeparator ToolStripSeparator1 { get; set; }

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
			EventHandler eventHandler = method_33;
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

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label_Loadout")]
	internal virtual DarkLabel Label_Loadout { get; set; }

	internal virtual DarkDataGridView DGV_LoadoutItems
	{
		[CompilerGenerated]
		get
		{
			return _DGV_LoadoutItems;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_7);
			DarkDataGridView darkDataGridView = _DGV_LoadoutItems;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellContentClick -= val;
			}
			_DGV_LoadoutItems = value;
			darkDataGridView = _DGV_LoadoutItems;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellContentClick += val;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

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
			EventHandler eventHandler = method_42;
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
			return cUrStUbRyk0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_40;
			ToolStripButton val = cUrStUbRyk0;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			cUrStUbRyk0 = value;
			val = cUrStUbRyk0;
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
			EventHandler eventHandler = method_44;
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

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	[field: AccessedThroughProperty("Label_QuickTurnaroundInfo")]
	internal virtual DarkLabel Label_QuickTurnaroundInfo { get; set; }

	internal virtual DarkUIComboBox Combo_NumberOfSorties
	{
		[CompilerGenerated]
		get
		{
			return _Combo_NumberOfSorties;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_46;
			DarkUIComboBox darkUIComboBox = _Combo_NumberOfSorties;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_Combo_NumberOfSorties = value;
			darkUIComboBox = _Combo_NumberOfSorties;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator2")]
	internal virtual ToolStripSeparator ToolStripSeparator2 { get; set; }

	internal virtual ContextMenuStrip CMenu_AirOps
	{
		[CompilerGenerated]
		get
		{
			return _CMenu_Unit;
		}
		[CompilerGenerated]
		set
		{
			CancelEventHandler cancelEventHandler = method_67;
			ContextMenuStrip val = _CMenu_Unit;
			if (val != null)
			{
				((ToolStripDropDown)val).Opening -= cancelEventHandler;
			}
			_CMenu_Unit = value;
			val = _CMenu_Unit;
			if (val != null)
			{
				((ToolStripDropDown)val).Opening += cancelEventHandler;
			}
		}
	}

	internal virtual DarkToolStripMenuItem TSMI_Doctrine
	{
		[CompilerGenerated]
		get
		{
			return _TSMI_Doctrine;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_59;
			DarkToolStripMenuItem darkToolStripMenuItem = _TSMI_Doctrine;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_TSMI_Doctrine = value;
			darkToolStripMenuItem = _TSMI_Doctrine;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	internal virtual DarkToolStripMenuItem TSMI_AssignToMission
	{
		[CompilerGenerated]
		get
		{
			return _TSMI_AssignToMission;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = method_60;
			ToolStripItemClickedEventHandler val = new ToolStripItemClickedEventHandler(method_68);
			DarkToolStripMenuItem darkToolStripMenuItem = _TSMI_AssignToMission;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
				((ToolStripDropDownItem)darkToolStripMenuItem).DropDownItemClicked -= val;
			}
			_TSMI_AssignToMission = value;
			darkToolStripMenuItem = _TSMI_AssignToMission;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
				((ToolStripDropDownItem)darkToolStripMenuItem).DropDownItemClicked += val;
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
			EventHandler eventHandler = method_50;
			EventHandler eventHandler2 = method_51;
			ToolStripItemClickedEventHandler val = new ToolStripItemClickedEventHandler(method_52);
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
			EventHandler eventHandler = method_54;
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
			EventHandler eventHandler = method_55;
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
			EventHandler eventHandler = method_56;
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

	internal virtual DarkToolStripMenuItem ReadyArmToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _ReadyArmToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_57;
			DarkToolStripMenuItem darkToolStripMenuItem = _ReadyArmToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_ReadyArmToolStripMenuItem = value;
			darkToolStripMenuItem = _ReadyArmToolStripMenuItem;
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
			EventHandler eventHandler = method_58;
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

	[field: AccessedThroughProperty("ToolStripSeparator3")]
	internal virtual ToolStripSeparator ToolStripSeparator3 { get; set; }

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
			EventHandler eventHandler = method_61;
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
			EventHandler eventHandler = method_62;
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
			EventHandler eventHandler = method_63;
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

	internal virtual DarkToolStripMenuItem AddLoadoutToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _AddLoadoutToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_65;
			DarkToolStripMenuItem darkToolStripMenuItem = _AddLoadoutToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_AddLoadoutToolStripMenuItem = value;
			darkToolStripMenuItem = _AddLoadoutToolStripMenuItem;
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
			EventHandler eventHandler = method_69;
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

	[field: AccessedThroughProperty("ToolStrip1")]
	internal virtual DarkToolStrip ToolStrip1 { get; set; }

	internal virtual DarkCheckBox CB_QuickTurnaround
	{
		[CompilerGenerated]
		get
		{
			return _CB_QuickTurnaround;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_48;
			DarkCheckBox darkCheckBox = _CB_QuickTurnaround;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_QuickTurnaround = value;
			darkCheckBox = _CB_QuickTurnaround;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("Aircraft")]
	internal virtual TreeGridColumn Aircraft { get; set; }

	[field: AccessedThroughProperty("Status")]
	internal virtual DataGridViewTextBoxColumn Status { get; set; }

	[field: AccessedThroughProperty("Mission")]
	internal virtual DataGridViewTextBoxColumn Mission { get; set; }

	[field: AccessedThroughProperty("Loadout")]
	internal virtual DataGridViewTextBoxColumn Loadout { get; set; }

	[field: AccessedThroughProperty("TimeToReady")]
	internal virtual DataGridViewTextBoxColumn TimeToReady { get; set; }

	[field: AccessedThroughProperty("QuickTurnaroundDescription")]
	internal virtual DataGridViewTextBoxColumn QuickTurnaroundDescription { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1 { get; set; }

	[field: AccessedThroughProperty("ComponentID")]
	internal virtual DataGridViewTextBoxColumn ComponentID { get; set; }

	[field: AccessedThroughProperty("Column_Description")]
	internal virtual DataGridViewLinkColumn Column_Description { get; set; }

	[field: AccessedThroughProperty("Available")]
	internal virtual DataGridViewTextBoxColumn Available { get; set; }

	[field: AccessedThroughProperty("AvailableTotal")]
	internal virtual DataGridViewTextBoxColumn AvailableTotal { get; set; }

	[field: AccessedThroughProperty("FloodAlert")]
	internal virtual ToolStripLabel FloodAlert { get; set; }

	[field: AccessedThroughProperty("TSL_SHIPONFIRE")]
	internal virtual ToolStripLabel TSL_SHIPONFIRE { get; set; }

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
			EventHandler eventHandler = method_74;
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
			EventHandler eventHandler = method_75;
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

	internal virtual DarkUIButton btnEXPCOL
	{
		[CompilerGenerated]
		get
		{
			return darkUIButton_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_76;
			DarkUIButton darkUIButton = darkUIButton_0;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			darkUIButton_0 = value;
			darkUIButton = darkUIButton_0;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton btnHideShowMaintenance
	{
		[CompilerGenerated]
		get
		{
			return _btnHideShowMaintenance;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_78;
			DarkUIButton darkUIButton = _btnHideShowMaintenance;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btnHideShowMaintenance = value;
			darkUIButton = _btnHideShowMaintenance;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("lblCapacity")]
	internal virtual DarkLabel lblCapacity { get; set; }

	internal virtual ToolStripButton TSB_AddHostedUnit
	{
		[CompilerGenerated]
		get
		{
			return _TSB_AddHostedUnit;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_80;
			ToolStripButton val = _TSB_AddHostedUnit;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_AddHostedUnit = value;
			val = _TSB_AddHostedUnit;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
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

	public bool AddingUnit
	{
		[CompilerGenerated]
		get
		{
			return bool_10;
		}
		[CompilerGenerated]
		set
		{
			bool_10 = value;
		}
	}

	public AirOps()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(AirOps_FormClosing);
		((Form)this).Shown += AirOps_Shown;
		((Control)this).KeyDown += new KeyEventHandler(AirOps_KeyDown);
		((Form)this).FormClosed += new FormClosedEventHandler(AirOps_FormClosed);
		((Form)this).Load += AirOps_Load;
		RTMPEnabled = true;
		SelectedHosts_IDs = new HashSet<string>();
		hashSet_0 = new HashSet<string>();
		list_0 = new List<Aircraft>();
		list_1 = new List<Aircraft>();
		maintainScrollPosition_0 = new MaintainScrollPosition();
		list_2 = new List<int>();
		dataTable_0 = new DataTable();
		dataTable_1 = new DataTable();
		dataTable_2 = new DataTable();
		bool_6 = false;
		dictionary_0 = new Dictionary<int, int>();
		vmethod_1(new BackgroundWorker());
		keys_0 = (Keys[])(object)new Keys[2]
		{
			(Keys)117,
			(Keys)27
		};
		bool_7 = false;
		bool_8 = false;
		bool_9 = false;
		AddingUnit = false;
		bool_11 = false;
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
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected O, but got Unknown
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected O, but got Unknown
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected O, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Expected O, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_076a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0774: Expected O, but got Unknown
		//IL_07e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ee: Expected O, but got Unknown
		//IL_085e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0868: Expected O, but got Unknown
		//IL_08d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e2: Expected O, but got Unknown
		//IL_0c0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dfa: Expected O, but got Unknown
		//IL_16df: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e9: Expected O, but got Unknown
		//IL_1790: Unknown result type (might be due to invalid IL or missing references)
		//IL_179a: Expected O, but got Unknown
		//IL_1b55: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b5f: Expected O, but got Unknown
		//IL_1c3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c48: Expected O, but got Unknown
		//IL_1d37: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d41: Expected O, but got Unknown
		//IL_20fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2175: Unknown result type (might be due to invalid IL or missing references)
		//IL_217f: Expected O, but got Unknown
		//IL_21d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_21dd: Expected O, but got Unknown
		//IL_2439: Unknown result type (might be due to invalid IL or missing references)
		//IL_25a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2606: Unknown result type (might be due to invalid IL or missing references)
		//IL_2610: Expected O, but got Unknown
		//IL_26a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_26b3: Expected O, but got Unknown
		//IL_2749: Unknown result type (might be due to invalid IL or missing references)
		//IL_2753: Expected O, but got Unknown
		//IL_27e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_27f3: Expected O, but got Unknown
		//IL_2889: Unknown result type (might be due to invalid IL or missing references)
		//IL_2893: Expected O, but got Unknown
		//IL_2962: Unknown result type (might be due to invalid IL or missing references)
		//IL_2abc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b40: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b4a: Expected O, but got Unknown
		//IL_2bd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bdf: Expected O, but got Unknown
		icontainer_1 = new Container();
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AirOps));
		CMenu_AirOps = new ContextMenuStrip(icontainer_1);
		LaunchIndividuallyToolStripMenuItem = new DarkToolStripMenuItem();
		LaunchAsGroupsToolStripMenuItem = new DarkToolStripMenuItem();
		ReadyArmToolStripMenuItem = new DarkToolStripMenuItem();
		AbortLaunchToolStripMenuItem = new DarkToolStripMenuItem();
		ToolStripSeparator3 = new ToolStripSeparator();
		TSMI_Doctrine = new DarkToolStripMenuItem();
		TSMI_AssignToMission = new DarkToolStripMenuItem();
		ToolStripSeparator4 = new ToolStripSeparator();
		SetTimeToReadyToolStripMenuItem = new DarkToolStripMenuItem();
		RenameToolStripMenuItem = new DarkToolStripMenuItem();
		RemoveToolStripMenuItem = new DarkToolStripMenuItem();
		AddLoadoutToolStripMenuItem = new DarkToolStripMenuItem();
		Facilities = new TreeGridColumn();
		theStatus = new TreeGridColumn();
		Timer1 = new Timer(icontainer_1);
		Timer2 = new Timer(icontainer_1);
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		CB_QuickTurnaround = new DarkCheckBox();
		Combo_NumberOfSorties = new DarkUIComboBox();
		Label_QuickTurnaroundInfo = new DarkLabel();
		btnEXPCOL = new DarkUIButton();
		btnHideShowMaintenance = new DarkUIButton();
		lblCapacity = new DarkLabel();
		Label3 = new DarkLabel();
		Label7 = new DarkLabel();
		Label8 = new DarkLabel();
		Label6 = new DarkLabel();
		Label1 = new DarkLabel();
		Label5 = new DarkLabel();
		Label4 = new DarkLabel();
		Label2 = new DarkLabel();
		Label_Loadout = new DarkLabel();
		DGV_LoadoutItems = new DarkDataGridView();
		ComponentID = new DataGridViewTextBoxColumn();
		Column_Description = new DataGridViewLinkColumn();
		Available = new DataGridViewTextBoxColumn();
		AvailableTotal = new DataGridViewTextBoxColumn();
		TGV_Aircraft = new DarkTreeGridView();
		Aircraft = new TreeGridColumn();
		Status = new DataGridViewTextBoxColumn();
		Mission = new DataGridViewTextBoxColumn();
		Loadout = new DataGridViewTextBoxColumn();
		TimeToReady = new DataGridViewTextBoxColumn();
		QuickTurnaroundDescription = new DataGridViewTextBoxColumn();
		ToolStrip1 = new DarkToolStrip();
		FloodAlert = new ToolStripLabel();
		TSL_SHIPONFIRE = new ToolStripLabel();
		TSL_LaunchIndividually = new ToolStripButton();
		TSL_LaunchAsGroup = new ToolStripButton();
		TSL_ReadyAC = new ToolStripButton();
		TSB_AbortLaunch = new ToolStripButton();
		ToolStripSeparator2 = new ToolStripSeparator();
		TSB_Doctrine = new ToolStripButton();
		TSB_AssignToMission = new ToolStripDropDownButton();
		ToolStripSeparator1 = new ToolStripSeparator();
		TSB_SetReadyTime = new ToolStripButton();
		TSB_Rename = new ToolStripButton();
		TSB_Delete = new ToolStripButton();
		TSB_AddHostedUnit = new ToolStripButton();
		TSB_Cargo = new ToolStripButton();
		TabPage2 = new TabPage();
		TV_Facilities = new DarkTreeView();
		TS_Edit = new DarkToolStrip();
		Button_AddFac = new ToolStripButton();
		Button_RemoveFac = new ToolStripButton();
		((Control)CMenu_AirOps).SuspendLayout();
		((Control)TabControl1).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((ISupportInitialize)(object)DGV_LoadoutItems).BeginInit();
		((ISupportInitialize)(object)TGV_Aircraft).BeginInit();
		((Control)ToolStrip1).SuspendLayout();
		((Control)TabPage2).SuspendLayout();
		((Control)TS_Edit).SuspendLayout();
		((Control)this).SuspendLayout();
		((ToolStrip)CMenu_AirOps).ImageScalingSize = new Size(24, 24);
		((ToolStrip)CMenu_AirOps).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[12]
		{
			(ToolStripItem)LaunchIndividuallyToolStripMenuItem,
			(ToolStripItem)LaunchAsGroupsToolStripMenuItem,
			(ToolStripItem)ReadyArmToolStripMenuItem,
			(ToolStripItem)AbortLaunchToolStripMenuItem,
			(ToolStripItem)ToolStripSeparator3,
			(ToolStripItem)TSMI_Doctrine,
			(ToolStripItem)TSMI_AssignToMission,
			(ToolStripItem)ToolStripSeparator4,
			(ToolStripItem)SetTimeToReadyToolStripMenuItem,
			(ToolStripItem)RenameToolStripMenuItem,
			(ToolStripItem)RemoveToolStripMenuItem,
			(ToolStripItem)AddLoadoutToolStripMenuItem
		});
		((Control)CMenu_AirOps).Name = "CMenu_Unit";
		((Control)CMenu_AirOps).Size = new Size(205, 232);
		((ToolStripItem)LaunchIndividuallyToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)LaunchIndividuallyToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)LaunchIndividuallyToolStripMenuItem).Name = "LaunchIndividuallyToolStripMenuItem";
		((ToolStripItem)LaunchIndividuallyToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)LaunchIndividuallyToolStripMenuItem).Text = "Launch individually";
		((ToolStripItem)LaunchAsGroupsToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)LaunchAsGroupsToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)LaunchAsGroupsToolStripMenuItem).Name = "LaunchAsGroupsToolStripMenuItem";
		((ToolStripItem)LaunchAsGroupsToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)LaunchAsGroupsToolStripMenuItem).Text = "Launch as group(s)";
		((ToolStripItem)ReadyArmToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ReadyArmToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ReadyArmToolStripMenuItem).Name = "ReadyArmToolStripMenuItem";
		((ToolStripItem)ReadyArmToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)ReadyArmToolStripMenuItem).Text = "Ready / Arm";
		((ToolStripItem)AbortLaunchToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)AbortLaunchToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)AbortLaunchToolStripMenuItem).Name = "AbortLaunchToolStripMenuItem";
		((ToolStripItem)AbortLaunchToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)AbortLaunchToolStripMenuItem).Text = "Abort Launch";
		((ToolStripItem)ToolStripSeparator3).Name = "ToolStripSeparator3";
		((ToolStripItem)ToolStripSeparator3).Size = new Size(201, 6);
		((ToolStripItem)TSMI_Doctrine).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSMI_Doctrine).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSMI_Doctrine).Name = "TSMI_Doctrine";
		((ToolStripItem)TSMI_Doctrine).Size = new Size(204, 24);
		((ToolStripItem)TSMI_Doctrine).Text = "Doctrine";
		((ToolStripItem)TSMI_AssignToMission).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSMI_AssignToMission).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSMI_AssignToMission).Name = "TSMI_AssignToMission";
		((ToolStripItem)TSMI_AssignToMission).Size = new Size(204, 24);
		((ToolStripItem)TSMI_AssignToMission).Text = "Assign to mission";
		((ToolStripItem)ToolStripSeparator4).Name = "ToolStripSeparator4";
		((ToolStripItem)ToolStripSeparator4).Size = new Size(201, 6);
		((ToolStripItem)SetTimeToReadyToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)SetTimeToReadyToolStripMenuItem).Font = new Font("Segoe UI", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)SetTimeToReadyToolStripMenuItem).ForeColor = Color.IndianRed;
		((ToolStripItem)SetTimeToReadyToolStripMenuItem).Name = "SetTimeToReadyToolStripMenuItem";
		((ToolStripItem)SetTimeToReadyToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)SetTimeToReadyToolStripMenuItem).Text = "Set time to ready";
		((ToolStripItem)RenameToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)RenameToolStripMenuItem).Font = new Font("Segoe UI", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)RenameToolStripMenuItem).ForeColor = Color.IndianRed;
		((ToolStripItem)RenameToolStripMenuItem).Name = "RenameToolStripMenuItem";
		((ToolStripItem)RenameToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)RenameToolStripMenuItem).Text = "Rename";
		((ToolStripItem)RemoveToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)RemoveToolStripMenuItem).Font = new Font("Segoe UI", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)RemoveToolStripMenuItem).ForeColor = Color.IndianRed;
		((ToolStripItem)RemoveToolStripMenuItem).Name = "RemoveToolStripMenuItem";
		((ToolStripItem)RemoveToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)RemoveToolStripMenuItem).Text = "Remove";
		((ToolStripItem)AddLoadoutToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)AddLoadoutToolStripMenuItem).Font = new Font("Segoe UI", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)AddLoadoutToolStripMenuItem).ForeColor = Color.IndianRed;
		((ToolStripItem)AddLoadoutToolStripMenuItem).Name = "AddLoadoutToolStripMenuItem";
		((ToolStripItem)AddLoadoutToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)AddLoadoutToolStripMenuItem).Text = "Add loadout to magazine";
		((DataGridViewColumn)Facilities).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		Facilities.DefaultNodeImage = null;
		((DataGridViewColumn)Facilities).HeaderText = "Facilities & Aircraft";
		((DataGridViewColumn)Facilities).MinimumWidth = 8;
		((DataGridViewColumn)Facilities).Name = "Facilities";
		((DataGridViewColumn)Facilities).ReadOnly = true;
		((DataGridViewColumn)Facilities).Resizable = (DataGridViewTriState)1;
		((DataGridViewTextBoxColumn)Facilities).SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)theStatus).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		theStatus.DefaultNodeImage = null;
		((DataGridViewColumn)theStatus).HeaderText = "Status";
		((DataGridViewColumn)theStatus).MinimumWidth = 8;
		((DataGridViewColumn)theStatus).Name = "theStatus";
		((DataGridViewColumn)theStatus).ReadOnly = true;
		((DataGridViewTextBoxColumn)theStatus).SortMode = (DataGridViewColumnSortMode)0;
		Timer1.Interval = 1000;
		((Control)TabControl1).Controls.Add((Control)(object)TabPage1);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage2);
		((Control)TabControl1).Cursor = Cursors.Hand;
		((Control)TabControl1).Dock = (DockStyle)5;
		((TabControl)TabControl1).ItemSize = new Size(80, 20);
		((Control)TabControl1).Location = new Point(0, 0);
		((Control)TabControl1).Name = "TabControl1";
		((TabControl)TabControl1).SelectedIndex = 0;
		((Control)TabControl1).Size = new Size(1290, 571);
		((Control)TabControl1).TabIndex = 0;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)TabPage1).Controls.Add((Control)(object)Label3);
		((Control)TabPage1).Controls.Add((Control)(object)Label7);
		((Control)TabPage1).Controls.Add((Control)(object)Label8);
		((Control)TabPage1).Controls.Add((Control)(object)Label6);
		((Control)TabPage1).Controls.Add((Control)(object)Label1);
		((Control)TabPage1).Controls.Add((Control)(object)Label5);
		((Control)TabPage1).Controls.Add((Control)(object)Label4);
		((Control)TabPage1).Controls.Add((Control)(object)Label2);
		((Control)TabPage1).Controls.Add((Control)(object)Label_Loadout);
		((Control)TabPage1).Controls.Add((Control)(object)DGV_LoadoutItems);
		((Control)TabPage1).Controls.Add((Control)(object)TGV_Aircraft);
		((Control)TabPage1).Controls.Add((Control)(object)ToolStrip1);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(1282, 543);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Aircraft Status";
		((Control)FlowLayoutPanel1).Anchor = (AnchorStyles)14;
		((Control)FlowLayoutPanel1).BackColor = Color.FromArgb(60, 63, 65);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)CB_QuickTurnaround);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Combo_NumberOfSorties);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Label_QuickTurnaroundInfo);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)btnEXPCOL);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)btnHideShowMaintenance);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)lblCapacity);
		((Control)FlowLayoutPanel1).Location = new Point(3, 309);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(1276, 31);
		((Control)FlowLayoutPanel1).TabIndex = 36;
		((Control)CB_QuickTurnaround).Anchor = (AnchorStyles)4;
		((Control)CB_QuickTurnaround).Location = new Point(3, 6);
		((Control)CB_QuickTurnaround).Name = "CB_QuickTurnaround";
		((Control)CB_QuickTurnaround).Size = new Size(148, 17);
		((Control)CB_QuickTurnaround).TabIndex = 32;
		((ButtonBase)CB_QuickTurnaround).Text = "Enable Quick Turnaround";
		((Control)Combo_NumberOfSorties).Anchor = (AnchorStyles)4;
		((ComboBox)Combo_NumberOfSorties).BackColor = Color.FromArgb(60, 63, 65);
		((ComboBox)Combo_NumberOfSorties).DrawMode = (DrawMode)1;
		((ComboBox)Combo_NumberOfSorties).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_NumberOfSorties).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_NumberOfSorties).FormattingEnabled = true;
		((Control)Combo_NumberOfSorties).Location = new Point(157, 3);
		((Control)Combo_NumberOfSorties).Name = "Combo_NumberOfSorties";
		((Control)Combo_NumberOfSorties).Size = new Size(166, 24);
		((Control)Combo_NumberOfSorties).TabIndex = 33;
		((Control)Label_QuickTurnaroundInfo).Anchor = (AnchorStyles)4;
		Label_QuickTurnaroundInfo.AutoSize = true;
		((Control)Label_QuickTurnaroundInfo).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_QuickTurnaroundInfo).Location = new Point(329, 5);
		((Control)Label_QuickTurnaroundInfo).Name = "Label_QuickTurnaroundInfo";
		((Control)Label_QuickTurnaroundInfo).Size = new Size(0, 20);
		((Control)Label_QuickTurnaroundInfo).TabIndex = 34;
		((ButtonBase)btnEXPCOL).BackColor = Color.Transparent;
		((Button)btnEXPCOL).DialogResult = (DialogResult)0;
		((Control)btnEXPCOL).Dock = (DockStyle)4;
		((Control)btnEXPCOL).ForeColor = SystemColors.Control;
		((Control)btnEXPCOL).Location = new Point(335, 3);
		((Control)btnEXPCOL).Name = "btnEXPCOL";
		btnEXPCOL.RoundRadius = 0;
		((Control)btnEXPCOL).Size = new Size(133, 24);
		((Control)btnEXPCOL).TabIndex = 35;
		btnEXPCOL.Text = "Expand Aircraft List";
		((ButtonBase)btnHideShowMaintenance).BackColor = Color.Transparent;
		((Button)btnHideShowMaintenance).DialogResult = (DialogResult)0;
		((Control)btnHideShowMaintenance).Dock = (DockStyle)4;
		((Control)btnHideShowMaintenance).ForeColor = SystemColors.Control;
		((Control)btnHideShowMaintenance).Location = new Point(474, 3);
		((Control)btnHideShowMaintenance).Name = "btnHideShowMaintenance";
		btnHideShowMaintenance.RoundRadius = 0;
		((Control)btnHideShowMaintenance).Size = new Size(114, 24);
		((Control)btnHideShowMaintenance).TabIndex = 36;
		btnHideShowMaintenance.Text = "Hide non-available";
		((Control)lblCapacity).Anchor = (AnchorStyles)8;
		lblCapacity.AutoSize = true;
		((Control)lblCapacity).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblCapacity).Location = new Point(594, 5);
		((Control)lblCapacity).Name = "lblCapacity";
		((Control)lblCapacity).Size = new Size(111, 20);
		((Control)lblCapacity).TabIndex = 37;
		((Label)lblCapacity).Text = "FacilityCapacity";
		((Label)lblCapacity).TextAlign = (ContentAlignment)64;
		((Control)Label3).Anchor = (AnchorStyles)6;
		Label3.AutoSize = true;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(655, 412);
		((Control)Label3).MaximumSize = new Size(400, 40);
		((Control)Label3).MinimumSize = new Size(400, 40);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(400, 40);
		((Control)Label3).TabIndex = 35;
		((Label)Label3).Text = "WeaponState";
		((Control)Label7).Anchor = (AnchorStyles)6;
		Label7.AutoSize = true;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(655, 483);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(173, 20);
		((Control)Label7).TabIndex = 31;
		((Label)Label7).Text = "NumberOfLoadoutsTotal";
		((Control)Label8).Anchor = (AnchorStyles)6;
		Label8.AutoSize = true;
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(655, 498);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(281, 20);
		((Control)Label8).TabIndex = 30;
		((Label)Label8).Text = "NumberOfLoadoutsTotal_MandatoryOnly";
		((Control)Label6).Anchor = (AnchorStyles)6;
		Label6.AutoSize = true;
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(655, 468);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(190, 20);
		((Control)Label6).TabIndex = 29;
		((Label)Label6).Text = "NumberOfLoadoutsOnBase";
		((Control)Label1).Anchor = (AnchorStyles)6;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(655, 373);
		((Control)Label1).MaximumSize = new Size(400, 38);
		((Control)Label1).MinimumSize = new Size(400, 38);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(400, 38);
		((Control)Label1).TabIndex = 28;
		((Label)Label1).Text = "RangeProfile";
		((Control)Label5).Anchor = (AnchorStyles)6;
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(655, 453);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(104, 20);
		((Control)Label5).TabIndex = 27;
		((Label)Label5).Text = "AttackAltitude";
		((Control)Label4).Anchor = (AnchorStyles)6;
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(655, 358);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(84, 20);
		((Control)Label4).TabIndex = 26;
		((Label)Label4).Text = "TimeOfDay";
		((Control)Label2).Anchor = (AnchorStyles)6;
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(655, 343);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(170, 20);
		((Control)Label2).TabIndex = 24;
		((Label)Label2).Text = "LoadoutRoleDescription";
		((Control)Label_Loadout).Anchor = (AnchorStyles)6;
		Label_Loadout.AutoSize = true;
		((Control)Label_Loadout).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Loadout).Location = new Point(3, 347);
		((Control)Label_Loadout).Name = "Label_Loadout";
		((Control)Label_Loadout).Size = new Size(117, 20);
		((Control)Label_Loadout).TabIndex = 23;
		((Label)Label_Loadout).Text = "Loadout Details:";
		((DataGridView)DGV_LoadoutItems).AllowUserToAddRows = false;
		((DataGridView)DGV_LoadoutItems).AllowUserToDeleteRows = false;
		((DataGridView)DGV_LoadoutItems).AllowUserToOrderColumns = true;
		((Control)DGV_LoadoutItems).Anchor = (AnchorStyles)6;
		((DataGridView)DGV_LoadoutItems).AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)6;
		((DataGridView)DGV_LoadoutItems).AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)7;
		((DataGridView)DGV_LoadoutItems).BackgroundColor = Color.FromArgb(43, 43, 43);
		((DataGridView)DGV_LoadoutItems).BorderStyle = (BorderStyle)2;
		((Control)DGV_LoadoutItems).CausesValidation = false;
		((DataGridView)DGV_LoadoutItems).CellBorderStyle = (DataGridViewCellBorderStyle)4;
		((DataGridView)DGV_LoadoutItems).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(66, 77, 95);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.LightGray;
		val2.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_LoadoutItems).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV_LoadoutItems).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DGV_LoadoutItems).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[4]
		{
			(DataGridViewColumn)ComponentID,
			(DataGridViewColumn)Column_Description,
			(DataGridViewColumn)Available,
			(DataGridViewColumn)AvailableTotal
		});
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.Font = new Font("Segoe UI", 9f);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_LoadoutItems).DefaultCellStyle = val3;
		((DataGridView)DGV_LoadoutItems).EditMode = (DataGridViewEditMode)4;
		((DataGridView)DGV_LoadoutItems).EnableHeadersVisualStyles = false;
		((Control)DGV_LoadoutItems).Location = new Point(3, 363);
		((DataGridView)DGV_LoadoutItems).MultiSelect = false;
		((Control)DGV_LoadoutItems).Name = "DGV_LoadoutItems";
		((DataGridView)DGV_LoadoutItems).RowHeadersVisible = false;
		((DataGridView)DGV_LoadoutItems).RowHeadersWidth = 20;
		val4.BackColor = Color.FromArgb(60, 63, 65);
		val4.ForeColor = Color.LightGray;
		val4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val4.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_LoadoutItems).RowsDefaultCellStyle = val4;
		((DataGridView)DGV_LoadoutItems).RowTemplate.Height = 15;
		((DataGridView)DGV_LoadoutItems).RowTemplate.Resizable = (DataGridViewTriState)2;
		((DataGridView)DGV_LoadoutItems).ScrollBars = (ScrollBars)2;
		((DataGridView)DGV_LoadoutItems).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_LoadoutItems).Size = new Size(650, 149);
		((Control)DGV_LoadoutItems).TabIndex = 22;
		((DataGridViewColumn)ComponentID).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)ComponentID).DataPropertyName = "ComponentID";
		((DataGridViewColumn)ComponentID).HeaderText = "ID";
		((DataGridViewColumn)ComponentID).MinimumWidth = 8;
		((DataGridViewColumn)ComponentID).Name = "ComponentID";
		ComponentID.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)ComponentID).Visible = false;
		((DataGridViewColumn)Column_Description).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		((DataGridViewColumn)Column_Description).DataPropertyName = "Item";
		((DataGridViewColumn)Column_Description).HeaderText = "Stores (click for info)";
		Column_Description.LinkBehavior = (LinkBehavior)2;
		Column_Description.LinkColor = Color.LightBlue;
		((DataGridViewColumn)Column_Description).MinimumWidth = 470;
		((DataGridViewColumn)Column_Description).Name = "Column_Description";
		((DataGridViewColumn)Column_Description).ReadOnly = true;
		((DataGridViewColumn)Column_Description).Resizable = (DataGridViewTriState)1;
		Column_Description.TrackVisitedState = false;
		((DataGridViewColumn)Column_Description).Width = 470;
		((DataGridViewColumn)Available).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Available).DataPropertyName = "Available";
		((DataGridViewColumn)Available).HeaderText = "# Available, Magazines";
		((DataGridViewColumn)Available).MinimumWidth = 90;
		((DataGridViewColumn)Available).Name = "Available";
		((DataGridViewColumn)Available).ReadOnly = true;
		Available.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Available).ToolTipText = "The number of weapons available in the base's ammo dump";
		((DataGridViewColumn)AvailableTotal).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)AvailableTotal).DataPropertyName = "AvailableTotal";
		((DataGridViewColumn)AvailableTotal).HeaderText = "# Available, Mags + A/C";
		((DataGridViewColumn)AvailableTotal).MinimumWidth = 90;
		((DataGridViewColumn)AvailableTotal).Name = "AvailableTotal";
		((DataGridViewColumn)AvailableTotal).ReadOnly = true;
		AvailableTotal.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)AvailableTotal).ToolTipText = "The total number of weapons available including those mounted on the currently selected aircraft";
		((DataGridView)TGV_Aircraft).AllowUserToAddRows = false;
		((DataGridView)TGV_Aircraft).AllowUserToDeleteRows = false;
		((DataGridView)TGV_Aircraft).AllowUserToOrderColumns = true;
		((Control)TGV_Aircraft).Anchor = (AnchorStyles)15;
		((DataGridView)TGV_Aircraft).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)TGV_Aircraft).BorderStyle = (BorderStyle)2;
		((DataGridView)TGV_Aircraft).CellBorderStyle = (DataGridViewCellBorderStyle)4;
		((DataGridView)TGV_Aircraft).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)1;
		val5.Alignment = (DataGridViewContentAlignment)16;
		val5.BackColor = Color.FromArgb(66, 77, 95);
		val5.Font = new Font("Segoe UI", 9f);
		val5.ForeColor = Color.LightGray;
		val5.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val5.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val5.WrapMode = (DataGridViewTriState)1;
		((DataGridView)TGV_Aircraft).ColumnHeadersDefaultCellStyle = val5;
		((DataGridView)TGV_Aircraft).ColumnHeadersHeight = 33;
		((DataGridView)TGV_Aircraft).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[6]
		{
			(DataGridViewColumn)Aircraft,
			(DataGridViewColumn)Status,
			(DataGridViewColumn)Mission,
			(DataGridViewColumn)Loadout,
			(DataGridViewColumn)TimeToReady,
			(DataGridViewColumn)QuickTurnaroundDescription
		});
		((Control)TGV_Aircraft).ContextMenuStrip = CMenu_AirOps;
		val6.Alignment = (DataGridViewContentAlignment)16;
		val6.BackColor = Color.FromArgb(60, 63, 65);
		val6.Font = new Font("Segoe UI", 9f);
		val6.ForeColor = Color.LightGray;
		val6.SelectionBackColor = SystemColors.Highlight;
		val6.SelectionForeColor = SystemColors.HighlightText;
		val6.WrapMode = (DataGridViewTriState)2;
		((DataGridView)TGV_Aircraft).DefaultCellStyle = val6;
		((DataGridView)TGV_Aircraft).EditMode = (DataGridViewEditMode)4;
		((DataGridView)TGV_Aircraft).EnableHeadersVisualStyles = false;
		TGV_Aircraft.ImageList = null;
		((Control)TGV_Aircraft).Location = new Point(3, 3);
		((Control)TGV_Aircraft).Name = "TGV_Aircraft";
		((DataGridView)TGV_Aircraft).RowHeadersVisible = false;
		((DataGridView)TGV_Aircraft).RowHeadersWidth = 20;
		((DataGridView)TGV_Aircraft).SelectionMode = (DataGridViewSelectionMode)1;
		TGV_Aircraft.ShowLines = false;
		((Control)TGV_Aircraft).Size = new Size(1276, 300);
		((Control)TGV_Aircraft).TabIndex = 7;
		((DataGridViewColumn)Aircraft).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		val.Font = new Font("Segoe UI", 8.25f, (FontStyle)4);
		val.ForeColor = Color.Blue;
		((DataGridViewColumn)Aircraft).DefaultCellStyle = val;
		Aircraft.DefaultNodeImage = null;
		((DataGridViewColumn)Aircraft).HeaderText = "Aircraft (click for info)";
		((DataGridViewColumn)Aircraft).MinimumWidth = 8;
		((DataGridViewColumn)Aircraft).Name = "Aircraft";
		((DataGridViewColumn)Aircraft).ReadOnly = true;
		((DataGridViewColumn)Aircraft).Resizable = (DataGridViewTriState)1;
		((DataGridViewTextBoxColumn)Aircraft).SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Status).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Status).FillWeight = 50f;
		((DataGridViewColumn)Status).HeaderText = "Status";
		((DataGridViewColumn)Status).MinimumWidth = 8;
		((DataGridViewColumn)Status).Name = "Status";
		((DataGridViewColumn)Status).ReadOnly = true;
		((DataGridViewColumn)Status).Resizable = (DataGridViewTriState)1;
		Status.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Mission).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Mission).FillWeight = 50f;
		((DataGridViewColumn)Mission).HeaderText = "Mission";
		((DataGridViewColumn)Mission).MinimumWidth = 8;
		((DataGridViewColumn)Mission).Name = "Mission";
		((DataGridViewColumn)Mission).ReadOnly = true;
		((DataGridViewColumn)Mission).Resizable = (DataGridViewTriState)1;
		Mission.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Loadout).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Loadout).HeaderText = "Loadout";
		((DataGridViewColumn)Loadout).MinimumWidth = 8;
		((DataGridViewColumn)Loadout).Name = "Loadout";
		((DataGridViewColumn)Loadout).ReadOnly = true;
		((DataGridViewColumn)Loadout).Resizable = (DataGridViewTriState)1;
		Loadout.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)TimeToReady).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)TimeToReady).FillWeight = 40f;
		((DataGridViewColumn)TimeToReady).HeaderText = "Time to ready";
		((DataGridViewColumn)TimeToReady).MinimumWidth = 8;
		((DataGridViewColumn)TimeToReady).Name = "TimeToReady";
		((DataGridViewColumn)TimeToReady).ReadOnly = true;
		((DataGridViewColumn)TimeToReady).Resizable = (DataGridViewTriState)1;
		TimeToReady.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)QuickTurnaroundDescription).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)QuickTurnaroundDescription).FillWeight = 40f;
		((DataGridViewColumn)QuickTurnaroundDescription).HeaderText = "Quick Turnaround";
		((DataGridViewColumn)QuickTurnaroundDescription).MinimumWidth = 97;
		((DataGridViewColumn)QuickTurnaroundDescription).Name = "QuickTurnaroundDescription";
		((DataGridViewColumn)QuickTurnaroundDescription).ReadOnly = true;
		((DataGridViewColumn)QuickTurnaroundDescription).Resizable = (DataGridViewTriState)1;
		QuickTurnaroundDescription.SortMode = (DataGridViewColumnSortMode)0;
		((ToolStrip)ToolStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)ToolStrip1).Dock = (DockStyle)2;
		((ToolStrip)ToolStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)ToolStrip1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)ToolStrip1).ImageScalingSize = new Size(20, 20);
		((ToolStrip)ToolStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[15]
		{
			(ToolStripItem)FloodAlert,
			(ToolStripItem)TSL_SHIPONFIRE,
			(ToolStripItem)TSL_LaunchIndividually,
			(ToolStripItem)TSL_LaunchAsGroup,
			(ToolStripItem)TSL_ReadyAC,
			(ToolStripItem)TSB_AbortLaunch,
			(ToolStripItem)ToolStripSeparator2,
			(ToolStripItem)TSB_Doctrine,
			(ToolStripItem)TSB_AssignToMission,
			(ToolStripItem)ToolStripSeparator1,
			(ToolStripItem)TSB_SetReadyTime,
			(ToolStripItem)TSB_Rename,
			(ToolStripItem)TSB_Delete,
			(ToolStripItem)TSB_AddHostedUnit,
			(ToolStripItem)TSB_Cargo
		});
		((Control)ToolStrip1).Location = new Point(3, 513);
		((Control)ToolStrip1).Name = "ToolStrip1";
		((Control)ToolStrip1).Padding = new Padding(1, 0, 2, 0);
		((Control)ToolStrip1).Size = new Size(1276, 27);
		((ToolStrip)ToolStrip1).Stretch = true;
		((Control)ToolStrip1).TabIndex = 1;
		((Control)ToolStrip1).Text = "ToolStrip1";
		FloodAlert.ActiveLinkColor = Color.Blue;
		((ToolStripItem)FloodAlert).BackColor = Color.Black;
		((ToolStripItem)FloodAlert).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((ToolStripItem)FloodAlert).ForeColor = Color.DodgerBlue;
		((ToolStripItem)FloodAlert).Name = "FloodAlert";
		((ToolStripItem)FloodAlert).Size = new Size(0, 24);
		((ToolStripItem)TSL_SHIPONFIRE).BackColor = Color.Black;
		((ToolStripItem)TSL_SHIPONFIRE).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((ToolStripItem)TSL_SHIPONFIRE).ForeColor = Color.Red;
		((ToolStripItem)TSL_SHIPONFIRE).Name = "TSL_SHIPONFIRE";
		((ToolStripItem)TSL_SHIPONFIRE).Size = new Size(0, 24);
		((ToolStripItem)TSL_LaunchIndividually).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSL_LaunchIndividually).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSL_LaunchIndividually).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSL_LaunchIndividually).Name = "TSL_LaunchIndividually";
		((ToolStripItem)TSL_LaunchIndividually).Size = new Size(139, 24);
		((ToolStripItem)TSL_LaunchIndividually).Text = "Launch individually";
		((ToolStripItem)TSL_LaunchAsGroup).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSL_LaunchAsGroup).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSL_LaunchAsGroup).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSL_LaunchAsGroup).Name = "TSL_LaunchAsGroup";
		((ToolStripItem)TSL_LaunchAsGroup).Size = new Size(137, 24);
		((ToolStripItem)TSL_LaunchAsGroup).Text = "Launch as group(s)";
		((ToolStripItem)TSL_ReadyAC).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSL_ReadyAC).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSL_ReadyAC).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSL_ReadyAC).Name = "TSL_ReadyAC";
		((ToolStripItem)TSL_ReadyAC).Size = new Size(96, 24);
		((ToolStripItem)TSL_ReadyAC).Text = "Ready / Arm";
		((ToolStripItem)TSB_AbortLaunch).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_AbortLaunch).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_AbortLaunch).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_AbortLaunch).Name = "TSB_AbortLaunch";
		((ToolStripItem)TSB_AbortLaunch).Size = new Size(101, 24);
		((ToolStripItem)TSB_AbortLaunch).Text = "Abort Launch";
		((ToolStripItem)ToolStripSeparator2).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripSeparator2).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripSeparator2).Margin = new Padding(0, 0, 2, 0);
		((ToolStripItem)ToolStripSeparator2).Name = "ToolStripSeparator2";
		((ToolStripItem)ToolStripSeparator2).Size = new Size(6, 27);
		((ToolStripItem)TSB_Doctrine).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_Doctrine).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_Doctrine).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_Doctrine).Name = "TSB_Doctrine";
		((ToolStripItem)TSB_Doctrine).Size = new Size(70, 24);
		((ToolStripItem)TSB_Doctrine).Text = "Doctrine";
		((ToolStripItem)TSB_AssignToMission).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_AssignToMission).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSB_AssignToMission).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_AssignToMission).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_AssignToMission).Name = "TSB_AssignToMission";
		((ToolStripItem)TSB_AssignToMission).Size = new Size(138, 24);
		((ToolStripItem)TSB_AssignToMission).Text = "Assign to mission";
		((ToolStripItem)ToolStripSeparator1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripSeparator1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripSeparator1).Margin = new Padding(0, 0, 2, 0);
		((ToolStripItem)ToolStripSeparator1).Name = "ToolStripSeparator1";
		((ToolStripItem)ToolStripSeparator1).Size = new Size(6, 27);
		((ToolStripItem)TSB_SetReadyTime).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_SetReadyTime).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSB_SetReadyTime).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((ToolStripItem)TSB_SetReadyTime).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_SetReadyTime).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_SetReadyTime).Name = "TSB_SetReadyTime";
		((ToolStripItem)TSB_SetReadyTime).Size = new Size(133, 24);
		((ToolStripItem)TSB_SetReadyTime).Text = "Set time to ready";
		((ToolStripItem)TSB_Rename).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_Rename).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSB_Rename).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((ToolStripItem)TSB_Rename).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_Rename).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_Rename).Name = "TSB_Rename";
		((ToolStripItem)TSB_Rename).Size = new Size(70, 24);
		((ToolStripItem)TSB_Rename).Text = "Rename";
		((ToolStripItem)TSB_Delete).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_Delete).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSB_Delete).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((ToolStripItem)TSB_Delete).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_Delete).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_Delete).Name = "TSB_Delete";
		((ToolStripItem)TSB_Delete).Size = new Size(70, 24);
		((ToolStripItem)TSB_Delete).Text = "Remove";
		((ToolStripItem)TSB_AddHostedUnit).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_AddHostedUnit).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSB_AddHostedUnit).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((ToolStripItem)TSB_AddHostedUnit).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_AddHostedUnit).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_AddHostedUnit).Name = "TSB_AddHostedUnit";
		((ToolStripItem)TSB_AddHostedUnit).Size = new Size(76, 24);
		((ToolStripItem)TSB_AddHostedUnit).Text = "Add Unit";
		((ToolStripItem)TSB_Cargo).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_Cargo).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSB_Cargo).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((ToolStripItem)TSB_Cargo).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_Cargo).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_Cargo).Name = "TSB_Cargo";
		((ToolStripItem)TSB_Cargo).Size = new Size(85, 24);
		((ToolStripItem)TSB_Cargo).Text = "Cargo Ops";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage2).Controls.Add((Control)(object)TV_Facilities);
		((Control)TabPage2).Controls.Add((Control)(object)TS_Edit);
		TabPage2.Location = new Point(4, 24);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Padding = new Padding(3);
		((Control)TabPage2).Size = new Size(1282, 543);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Air Facilities";
		((Control)TV_Facilities).Dock = (DockStyle)5;
		((Control)TV_Facilities).Location = new Point(3, 3);
		TV_Facilities.MaxDragChange = 20;
		((Control)TV_Facilities).Name = "TV_Facilities";
		((Control)TV_Facilities).Size = new Size(1276, 510);
		((Control)TV_Facilities).TabIndex = 7;
		((ToolStrip)TS_Edit).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)TS_Edit).Dock = (DockStyle)2;
		((ToolStrip)TS_Edit).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)TS_Edit).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)TS_Edit).ImageScalingSize = new Size(20, 20);
		((ToolStrip)TS_Edit).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[2]
		{
			(ToolStripItem)Button_AddFac,
			(ToolStripItem)Button_RemoveFac
		});
		((Control)TS_Edit).Location = new Point(3, 513);
		((Control)TS_Edit).Name = "TS_Edit";
		((Control)TS_Edit).Padding = new Padding(5, 0, 1, 0);
		((Control)TS_Edit).Size = new Size(1276, 27);
		((Control)TS_Edit).TabIndex = 7;
		((Control)TS_Edit).Text = "ToolStrip2";
		((ToolStripItem)Button_AddFac).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)Button_AddFac).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)Button_AddFac).Image = (Image)componentResourceManager.GetObject("Button_AddFac.Image");
		((ToolStripItem)Button_AddFac).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)Button_AddFac).Name = "Button_AddFac";
		((ToolStripItem)Button_AddFac).Size = new Size(110, 24);
		((ToolStripItem)Button_AddFac).Text = "Add Facility";
		((ToolStripItem)Button_RemoveFac).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)Button_RemoveFac).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)Button_RemoveFac).Image = (Image)componentResourceManager.GetObject("Button_RemoveFac.Image");
		((ToolStripItem)Button_RemoveFac).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)Button_RemoveFac).Name = "Button_RemoveFac";
		((ToolStripItem)Button_RemoveFac).Size = new Size(147, 24);
		((ToolStripItem)Button_RemoveFac).Text = "Remove Facilities";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1290, 571);
		((Control)this).Controls.Add((Control)(object)TabControl1);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "AirOps";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Air Ops";
		((Control)CMenu_AirOps).ResumeLayout(false);
		((Control)TabControl1).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)TabPage1).PerformLayout();
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((Control)FlowLayoutPanel1).PerformLayout();
		((ISupportInitialize)(object)DGV_LoadoutItems).EndInit();
		((ISupportInitialize)(object)TGV_Aircraft).EndInit();
		((Control)ToolStrip1).ResumeLayout(false);
		((Control)ToolStrip1).PerformLayout();
		((Control)TabPage2).ResumeLayout(false);
		((Control)TabPage2).PerformLayout();
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
		DoWorkEventHandler value = method_31;
		RunWorkerCompletedEventHandler value2 = method_32;
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
			list_0.Clear();
			list_1.Clear();
			TV_Facilities.Nodes.Clear();
			TGV_Aircraft.Nodes.Clear();
			((ToolStripDropDownItem)TSB_AssignToMission).DropDownItems.Clear();
			((ToolStripDropDownItem)TSMI_AssignToMission).DropDownItems.Clear();
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
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		Keys[] array = keys_0;
		foreach (Keys val in array)
		{
			if (keyData == val)
			{
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
		}
		return false;
	}

	private void AirOps_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (!Client.Realtime)
		{
			if (bool_3)
			{
				Client.CurrentGame.Run();
			}
		}
		else
		{
			Client.RealtimeTerminal.SendAirHostSelectionChange(null);
		}
		((Control)MyProject.Forms.MainForm).BringToFront();
		Timer1.Stop();
	}

	[SpecialName]
	private List<ActiveUnit> method_2()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (string selectedHosts_ID in SelectedHosts_IDs)
		{
			if (!string.IsNullOrEmpty(selectedHosts_ID) && Client.CurrentScenario.ActiveUnits.TryGetValue(selectedHosts_ID, out var value))
			{
				list.Add(value);
			}
		}
		return list;
	}

	[SpecialName]
	private ReadOnlyCollection<ActiveUnit> method_3()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (string item in hashSet_0)
		{
			if (!string.IsNullOrEmpty(item) && Client.CurrentScenario.ActiveUnits.TryGetValue(item, out var value))
			{
				list.Add(value);
			}
		}
		return list.AsReadOnly();
	}

	private void method_4(Group group_0, ActiveUnit activeUnit_0)
	{
		foreach (ActiveUnit item in method_2())
		{
			if (item == group_0)
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(activeUnit_0.Name);
				TV_Facilities.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = activeUnit_0;
			}
		}
	}

	private void method_5(Group group_0, ActiveUnit activeUnit_0)
	{
		foreach (ActiveUnit item in method_2())
		{
			if (item != group_0)
			{
				continue;
			}
			foreach (DarkTreeNode node in TV_Facilities.Nodes)
			{
				if (node.Tag == activeUnit_0)
				{
					TV_Facilities.Nodes.Remove(node);
					break;
				}
			}
		}
	}

	private Dictionary<int, int> method_6(ref ActiveUnit activeUnit_0)
	{
		List<Aircraft> list = new List<Aircraft>();
		if (!Information.IsNothing((object)activeUnit_0))
		{
			if (!Client.Realtime)
			{
				foreach (Aircraft item in activeUnit_0.AirOps.EmbarkedAircraft_ReadOnly)
				{
					list.Add(item);
				}
			}
			else
			{
				foreach (Aircraft item2 in Client.RealtimeTerminal.EmbarkedOps_GetEmbarkedAircraft(activeUnit_0))
				{
					list.Add(item2);
				}
			}
			if (list.Count != 0)
			{
				SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
				bool UnlimitedAirWeapons = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
				return DBFunctions.GetSelectedAircraftTotalWeaponQty(list, ref sqliteConnection_, ref UnlimitedAirWeapons);
			}
			return null;
		}
		return null;
	}

	private void method_7(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex != -1 && (object)((DataGridView)DGV_LoadoutItems).Columns[e.ColumnIndex].CellType == typeof(DataGridViewLinkCell))
		{
			int selectedObjectID = Conversions.ToInteger(((DataGridView)DGV_LoadoutItems).Rows[e.RowIndex].Cells["ComponentID"].Value);
			Client.smethod_17("Weapon", selectedObjectID);
		}
	}

	private void method_8(Aircraft aircraft_0)
	{
		_Closure$__324-0 arg = default(_Closure$__324-0);
		_Closure$__324-0 CS$<>8__locals8 = new _Closure$__324-0(arg);
		CS$<>8__locals8.$VB$Me = this;
		CS$<>8__locals8.$VB$Local_theAircraft = aircraft_0;
		if (((Control)this).InvokeRequired)
		{
			((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				CS$<>8__locals8.$VB$Me.method_8(CS$<>8__locals8.$VB$Local_theAircraft);
			}));
			return;
		}
		foreach (ActiveUnit item in method_2())
		{
			if (!Client.Realtime)
			{
				if (item.AirOps.EmbarkedAircraft_ReadOnly.Contains(CS$<>8__locals8.$VB$Local_theAircraft))
				{
					list_0.Add(CS$<>8__locals8.$VB$Local_theAircraft);
				}
			}
			else if (Client.RealtimeTerminal.EmbarkedOps_GetEmbarkedAircraft(item).Contains(CS$<>8__locals8.$VB$Local_theAircraft))
			{
				list_0.Add(CS$<>8__locals8.$VB$Local_theAircraft);
			}
		}
	}

	public void RefreshForm()
	{
		method_12();
		method_18();
	}

	private void method_9()
	{
		vmethod_0().RunWorkerAsync();
	}

	private void method_10(Aircraft aircraft_0)
	{
		if (!((Control)this).InvokeRequired)
		{
			list_1.Add(aircraft_0);
			return;
		}
		((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
		{
			method_10(aircraft_0);
		}));
	}

	private void method_11(object sender, EventArgs e)
	{
		if (!Client.Realtime)
		{
			if (Client.CurrentGame.Status == Game._GameStatus.Running)
			{
				RefreshAll();
			}
		}
		else if (Client.RealtimeTerminal.LastGameSpeed > 0 || Client.RealtimeTerminal.EmbarkedAirOpsNewDataReceived)
		{
			Client.RealtimeTerminal.EmbarkedAirOpsNewDataReceived = false;
			RefreshAll();
		}
	}

	public void RefreshAll()
	{
		method_12();
		method_18();
		list_0.Clear();
		list_1.Clear();
	}

	private void method_12()
	{
		if (!((Control)TGV_Aircraft).Enabled)
		{
			return;
		}
		((Control)TGV_Aircraft).Enabled = false;
		((Control)TGV_Aircraft).SuspendLayout();
		if (Client.Realtime)
		{
			List<Aircraft> list = new List<Aircraft>();
			foreach (TreeGridNode node in TGV_Aircraft.Nodes)
			{
				if (((DataGridViewBand)node).Tag != null && ((DataGridViewBand)node).Tag is IEnumerable<Aircraft>)
				{
					list.AddRange(((IEnumerable<Aircraft>)((DataGridViewBand)node).Tag).ToList());
				}
			}
			List<Aircraft> list2 = new List<Aircraft>();
			foreach (ActiveUnit item in method_2())
			{
				list2.AddRange(Client.RealtimeTerminal.EmbarkedOps_GetEmbarkedAircraft(item));
			}
			list_1 = list.Except(list2).ToList();
			list_0 = list2.Except(list).ToList();
		}
		try
		{
			_Closure$__330-0 closure$__330- = default(_Closure$__330-0);
			foreach (Aircraft item2 in list_1)
			{
				closure$__330- = new _Closure$__330-0(closure$__330-);
				closure$__330-.$VB$Local_myAC = item2;
				IEnumerable<TreeGridNode> source = method_14().Where(closure$__330-._Lambda$__0);
				if (source.Count() > 0)
				{
					TreeGridNode parent = source.ElementAtOrDefault(0).Parent;
					List<Aircraft> list3 = ((IEnumerable<Aircraft>)((DataGridViewBand)parent).Tag).ToList();
					if (list3.Count < 2)
					{
						parent.Parent.Nodes.Remove(parent);
						continue;
					}
					parent.Nodes.Remove(source.ElementAtOrDefault(0));
					list3.Remove(closure$__330-.$VB$Local_myAC);
					((DataGridViewBand)parent).Tag = list3;
				}
			}
			foreach (TreeGridNode item3 in method_14())
			{
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(((DataGridViewBand)item3).Tag)) && (object)((DataGridViewBand)item3).Tag.GetType() == typeof(Aircraft))
				{
					Aircraft aircraft = (Aircraft)((DataGridViewBand)item3).Tag;
					bool num = bool_6;
					string ReasonForNot = null;
					if (!(num & (aircraft.IsAvailableForOps(ref ReasonForNot) == 2)))
					{
						((DataGridViewRow)item3).Visible = true;
					}
					else
					{
						((DataGridViewRow)item3).Visible = false;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200111", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			foreach (Aircraft item4 in list_0)
			{
				bool flag = false;
				foreach (TreeGridNode node2 in TGV_Aircraft.Nodes)
				{
					if (((DataGridViewBand)node2).Tag != null && Operators.CompareString(((IEnumerable<Aircraft>)((DataGridViewBand)node2).Tag).ElementAtOrDefault(0).DBID.ToString(), item4.DBID.ToString(), true) == 0)
					{
						((DataGridViewBand)node2.Nodes.Add()).Tag = item4;
						List<Aircraft> list4 = ((IEnumerable<Aircraft>)((DataGridViewBand)node2).Tag).ToList();
						list4.Add(item4);
						((DataGridViewBand)node2).Tag = list4;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					IEnumerable<Aircraft> tag = new Aircraft[1] { item4 };
					TreeGridNode treeGridNode = TGV_Aircraft.Nodes.Add();
					((DataGridViewBand)treeGridNode).Tag = tag;
					((DataGridViewBand)treeGridNode.Nodes.Add()).Tag = item4;
				}
			}
			if (bool_5)
			{
				method_38();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 200112", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			foreach (TreeGridNode item5 in method_14())
			{
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(((DataGridViewBand)item5).Tag)))
				{
					continue;
				}
				if ((object)((DataGridViewBand)item5).Tag.GetType() == typeof(Aircraft))
				{
					Aircraft aircraft2 = (Aircraft)((DataGridViewBand)item5).Tag;
					string text;
					if (Information.IsNothing((object)aircraft2.Loadout))
					{
						text = "Nothing";
					}
					else
					{
						text = aircraft2.Loadout.Name;
						if (aircraft2.GetCargo_Type() > CargoType.NoCargo)
						{
							int percentFull = CargoHostHelper.GetPercentFull(aircraft2);
							text += " (Cargo: ";
							text = ((percentFull >= 1) ? (text + percentFull + "%)") : (text + "empty)"));
						}
					}
					string text2;
					if (Information.IsNothing((object)aircraft2.ActiveMissionOrPackage()))
					{
						text2 = ((!Information.IsNothing((object)aircraft2.AssignedTaskPool)) ? (aircraft2.AssignedTaskPool.Name + " (Task Pool)") : "-");
					}
					else
					{
						string text3 = "";
						int num2;
						if (aircraft2.AI.IsEscort)
						{
							text3 = ", Escort";
							num2 = 5;
						}
						else
						{
							num2 = 5;
						}
						string[] array = new string[num2];
						array[0] = aircraft2.ActiveMissionOrPackage().Name;
						array[1] = " (";
						array[2] = aircraft2.ActiveMissionOrPackage().get_DescriptionString(Client.CurrentScenario);
						array[3] = text3;
						array[4] = ")";
						text2 = string.Concat(array);
					}
					Aircraft_AirOps airOps = aircraft2.AirOps;
					string text4 = aircraft2.Name;
					if (((ActiveUnit)aircraft2).get_UnitSide(SetSideOnly: false) != Client.CurrentSide)
					{
						text4 = text4 + " (" + ((ActiveUnit)aircraft2).get_UnitSide(SetSideOnly: false).Name + ")";
					}
					object[] obj = new object[6]
					{
						text4,
						airOps.ConditionString,
						text2,
						Misc.RemoveHiddenString(text),
						null,
						null
					};
					long seconds = (long)Math.Round(airOps.ConditionTimer);
					string ReasonForNot = null;
					obj[4] = Misc.TimeString(seconds, aircraft2.IsAvailableForOps(ref ReasonForNot));
					obj[5] = aircraft2.QuickTurnaroundString();
					((DataGridViewRow)item5).SetValues(obj);
					method_71(item5, aircraft2);
					continue;
				}
				item5.Cells[0].Value = "";
				List<Aircraft> list5 = ((IEnumerable<Aircraft>)((DataGridViewBand)item5).Tag).ToList();
				if (list5.Count > 0)
				{
					Aircraft aircraft3 = list5.FirstOrDefault();
					Aircraft_AirOps airOps2 = aircraft3.AirOps;
					if (airOps2.CurrentHostUnit != null)
					{
						item5.Cells[0].Value = Conversions.ToString(list5.Count) + "x " + Misc.RemoveHiddenString(aircraft3.UnitClass) + " (" + airOps2.CurrentHostUnit.Name + ")";
					}
				}
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 200279", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			((Form)this).Close();
			ProjectData.ClearProjectError();
			return;
		}
		((Control)TGV_Aircraft).ResumeLayout();
		((Control)TGV_Aircraft).Enabled = true;
	}

	private void method_13()
	{
		DataGridViewColumn obj = ((DataGridView)TGV_Aircraft).Columns[3];
		obj.SortMode = (DataGridViewColumnSortMode)2;
		obj.HeaderCell.SortGlyphDirection = (SortOrder)2;
		DataGridViewColumn obj2 = ((DataGridView)TGV_Aircraft).Columns[4];
		obj2.SortMode = (DataGridViewColumnSortMode)2;
		obj2.HeaderCell.SortGlyphDirection = (SortOrder)2;
	}

	[SpecialName]
	private ReadOnlyCollection<TreeGridNode> method_14()
	{
		ReadOnlyCollection<TreeGridNode> result;
		try
		{
			List<TreeGridNode> list = new List<TreeGridNode>();
			foreach (TreeGridNode node in TGV_Aircraft.Nodes)
			{
				if (!list.Contains(node))
				{
					list.Add(node);
				}
				method_15(node, list);
			}
			result = list.AsReadOnly();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101133", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<TreeGridNode>().AsReadOnly();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_15(TreeGridNode treeGridNode_0, List<TreeGridNode> list_3)
	{
		foreach (TreeGridNode node in treeGridNode_0.Nodes)
		{
			if (!list_3.Contains(node))
			{
				list_3.Add(node);
			}
			method_15(node, list_3);
		}
	}

	private void method_16()
	{
		try
		{
			TGV_Aircraft.Nodes.Clear();
			_Closure$__335-0 closure$__335- = default(_Closure$__335-0);
			foreach (ActiveUnit item in method_2())
			{
				IEnumerable<int> enumerable = ((!Client.Realtime) ? item.AirOps.EmbarkedAircraft_ReadOnly.Select([SpecialName] (Aircraft AC) => AC.DBID).Distinct() : (from AC in Client.RealtimeTerminal.EmbarkedOps_GetEmbarkedAircraft(item)
					select AC.DBID).Distinct());
				foreach (int item2 in enumerable)
				{
					closure$__335- = new _Closure$__335-0(closure$__335-);
					closure$__335-.$VB$Local_theDBID = item2;
					IEnumerable<Aircraft> enumerable2 = (Client.Realtime ? (from AC in Client.RealtimeTerminal.EmbarkedOps_GetEmbarkedAircraft(item).Where(closure$__335-._Lambda$__2)
						select (AC)) : (from AC in item.AirOps.EmbarkedAircraft_ReadOnly.Where(closure$__335-._Lambda$__4)
						select (AC)));
					TreeGridNode treeGridNode = TGV_Aircraft.Nodes.Add(Conversions.ToString(enumerable2.Count()) + "x " + Misc.RemoveHiddenString(enumerable2.ElementAtOrDefault(0).UnitClass) + " (" + item.Name + ")");
					((DataGridViewBand)treeGridNode).Tag = enumerable2;
					((DataGridViewRow)treeGridNode).DefaultCellStyle.ForeColor = Color.DodgerBlue;
					treeGridNode.Nodes.Add("Temp");
				}
				foreach (int item3 in list_2)
				{
					foreach (TreeGridNode node in TGV_Aircraft.Nodes)
					{
						try
						{
							if (((IEnumerable<Aircraft>)((DataGridViewBand)node).Tag).ElementAtOrDefault(0).DBID == item3)
							{
								node.Expand();
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 200121", ex2.Message);
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
				}
			}
			if (TGV_Aircraft.Nodes.Count > 0)
			{
				TGV_Aircraft.Nodes[0].Expand();
			}
			method_77(TGV_Aircraft.Nodes.Count == 1);
			method_13();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 101134", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_17()
	{
		try
		{
			TV_Facilities.Nodes.Clear();
			foreach (ActiveUnit item in method_2())
			{
				if (item.IsGroup)
				{
					Group.GroupType type = ((Group)item).Type;
					if (type == Group.GroupType.AirBase)
					{
						DarkTreeNode darkTreeNode = new DarkTreeNode(item.Name);
						TV_Facilities.Nodes.Add(darkTreeNode);
						darkTreeNode.Tag = item;
						method_19((Group)item, darkTreeNode);
						continue;
					}
					IEnumerable<ActiveUnit> enumerable = from theAU in ((Group)item).Units.Values
						select (theAU) into theAU
						orderby theAU.Name
						select theAU;
					foreach (ActiveUnit item2 in enumerable)
					{
						if (item2.AirFacilities_ReadOnly.Length > 0)
						{
							DarkTreeNode darkTreeNode = new DarkTreeNode(item2.Name);
							TV_Facilities.Nodes.Add(darkTreeNode);
							darkTreeNode.Tag = item2;
							method_19(item2, darkTreeNode);
						}
					}
				}
				else
				{
					DarkTreeNode darkTreeNode = new DarkTreeNode(item.Name);
					TV_Facilities.Nodes.Add(darkTreeNode);
					darkTreeNode.Tag = item;
					method_19(item, darkTreeNode);
				}
			}
			Module1.ExpandAll(TV_Facilities);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101135", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_18()
	{
		((Control)TV_Facilities).SuspendLayout();
		foreach (ActiveUnit item in method_2())
		{
			_ = item;
			foreach (DarkTreeNode node in TV_Facilities.Nodes)
			{
				ActiveUnit activeUnit_ = (ActiveUnit)node.Tag;
				method_19(activeUnit_, node);
			}
		}
		((Control)TV_Facilities).ResumeLayout();
	}

	private void method_19(ActiveUnit activeUnit_0, DarkTreeNode darkTreeNode_0)
	{
		IEnumerable<AirFacility> enumerable = from theAF in activeUnit_0.AirFacilities_ReadOnly
			select (theAF) into theAF
			orderby theAF.Name
			select theAF;
		double num = 0.0;
		double num2 = 0.0;
		foreach (AirFacility item in enumerable)
		{
			bool flag = false;
			foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
			{
				if (node.Tag == item)
				{
					flag = true;
					method_20(item, node);
					break;
				}
			}
			if (!flag)
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(item.Name);
				darkTreeNode_0.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = item;
				darkTreeNode.Expanded = true;
				foreach (Aircraft value in item.HostedAircraft.Values)
				{
					string[] obj = new string[8]
					{
						value.Name,
						" (",
						Misc.RemoveHiddenString(value.UnitClass),
						"): ",
						value.AirOps.ConditionString,
						" (",
						null,
						null
					};
					long seconds = (long)Math.Round(value.AirOps.ConditionTimer);
					string ReasonForNot = null;
					obj[6] = Misc.TimeString(seconds, value.IsAvailableForOps(ref ReasonForNot));
					obj[7] = ")";
					DarkTreeNode darkTreeNode2 = new DarkTreeNode(string.Concat(obj));
					darkTreeNode.Nodes.Add(darkTreeNode2);
					darkTreeNode2.Tag = value;
					darkTreeNode2.Expanded = true;
				}
			}
			num += (double)item.ParkingSpace_Total;
			num2 = num2 + (double)item.ParkingSpace_Total - (double)item.ParkingSpace_Free;
		}
		((Label)lblCapacity).Text = "Occupied " + num2 + " / " + num + " ( " + Math.Round(num2 / num * 100.0) + "% )";
		List<DarkTreeNode> list = new List<DarkTreeNode>();
		foreach (DarkTreeNode node2 in darkTreeNode_0.Nodes)
		{
			if (!activeUnit_0.AirFacilities_ReadOnly.Contains((AirFacility)node2.Tag))
			{
				list.Add(node2);
			}
		}
		foreach (DarkTreeNode item2 in list)
		{
			darkTreeNode_0.Nodes.Remove(item2);
		}
	}

	private void method_20(AirFacility airFacility_0, DarkTreeNode darkTreeNode_0)
	{
		try
		{
			bool flag = default(bool);
			foreach (Aircraft value in airFacility_0.HostedAircraft.Values)
			{
				foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
				{
					if (node.Tag == value)
					{
						flag = true;
						node.Text = value.Name + " (" + Misc.RemoveHiddenString(value.UnitClass) + "): " + value.AirOps.ConditionString + " (" + Misc.TimeString((long)Math.Round(value.AirOps.ConditionTimer)) + ")";
						break;
					}
				}
				if (!flag)
				{
					string[] obj = new string[8]
					{
						value.Name,
						" (",
						Misc.RemoveHiddenString(value.UnitClass),
						"): ",
						value.AirOps.ConditionString,
						" (",
						null,
						null
					};
					long seconds = (long)Math.Round(value.AirOps.ConditionTimer);
					string ReasonForNot = null;
					obj[6] = Misc.TimeString(seconds, value.IsAvailableForOps(ref ReasonForNot));
					obj[7] = ")";
					DarkTreeNode darkTreeNode = new DarkTreeNode(string.Concat(obj));
					darkTreeNode_0.Nodes.Add(darkTreeNode);
					darkTreeNode.Tag = value;
				}
			}
			List<DarkTreeNode> list = new List<DarkTreeNode>();
			foreach (DarkTreeNode node2 in darkTreeNode_0.Nodes)
			{
				if (!airFacility_0.HostedAircraft.Values.Contains((Aircraft)node2.Tag))
				{
					list.Add(node2);
				}
			}
			foreach (DarkTreeNode item in list)
			{
				darkTreeNode_0.Nodes.Remove(item);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200122B", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			ProjectData.ClearProjectError();
		}
	}

	private void method_21(object sender, EventArgs e)
	{
	}

	private void method_22(object sender, EventArgs e)
	{
		method_23(bool_12: true);
	}

	private void method_23(bool bool_12 = false)
	{
		if (Client.Realtime)
		{
			Client.RealtimeTerminal.SendLaunchEmbarkedUnitMessage(new List<string>(from F in method_3()
				select F.ObjectID));
			return;
		}
		method_24(bool_12: true, bool_13: true, bool_14: true, bool_15: true, bool_16: true);
		switch (method_3().Count)
		{
		case 1:
			((Aircraft)method_3()[0]).AirOps.AttemptToMoveToRunway(ActualAirlaunchPreparation: true, bool_12);
			break;
		default:
			foreach (Aircraft item in method_3())
			{
				item.AirOps.AttemptToMoveToRunway(ActualAirlaunchPreparation: true, bool_12);
			}
			break;
		case 0:
			break;
		}
		method_12();
	}

	private void method_24(bool bool_12, bool bool_13, bool bool_14, bool bool_15, bool bool_16)
	{
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Unknown result type (might be due to invalid IL or missing references)
		hashSet_0.Clear();
		foreach (TreeGridNode node in TGV_Aircraft.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected)
				{
					hashSet_0.Add(((Aircraft)((DataGridViewBand)node2).Tag).ObjectID);
				}
			}
		}
		if (bool_12)
		{
			List<Aircraft> list = new List<Aircraft>();
			foreach (Aircraft item in method_3())
			{
				string ReasonForNot = null;
				if (item.IsAvailableForOps(ref ReasonForNot) == 2)
				{
					list.Add(item);
				}
			}
			if (list.Count > 0)
			{
				DarkMessageBox.ShowWarning(Conversions.ToString(list.Count) + " of the selected aircraft are unavailable for operations, and will not launch.", "Unavailable aircraft selected!");
				foreach (Aircraft item2 in list)
				{
					hashSet_0.Remove(item2.ObjectID);
				}
			}
		}
		if (bool_13)
		{
			List<Aircraft> list2 = new List<Aircraft>();
			foreach (Aircraft item3 in method_3())
			{
				if (((ActiveUnit)item3).get_UnitSide(SetSideOnly: false) != Client.CurrentSide)
				{
					list2.Add(item3);
				}
			}
			if (list2.Count > 0)
			{
				DarkMessageBox.ShowWarning(Conversions.ToString(list2.Count) + " of the selected aircraft are allied units not under your direct control.", "Allied aircraft selected!");
				foreach (Aircraft item4 in list2)
				{
					hashSet_0.Remove(item4.ObjectID);
				}
			}
		}
		if (bool_14)
		{
			List<Aircraft> list3 = new List<Aircraft>();
			foreach (Aircraft item5 in method_3())
			{
				if (item5.IsOperating())
				{
					list3.Add(item5);
				}
			}
			if (list3.Count > 0)
			{
				DarkMessageBox.ShowWarning(Conversions.ToString(list3.Count) + " of the selected aircraft are already airborne.", "Airborne aircraft selected!");
				foreach (Aircraft item6 in list3)
				{
					hashSet_0.Remove(item6.ObjectID);
				}
			}
		}
		if (bool_15)
		{
			List<Aircraft> list4 = new List<Aircraft>();
			foreach (Aircraft item7 in method_3())
			{
				if (Information.IsNothing((object)item7.Loadout))
				{
					list4.Add(item7);
				}
			}
			if (list4.Count > 0)
			{
				DarkMessageBox.ShowWarning(Conversions.ToString(list4.Count) + " of the selected aircraft do not have a loadout, and will not launch.", "Aircraft with no loadout selected!");
				foreach (Aircraft item8 in list4)
				{
					hashSet_0.Remove(item8.ObjectID);
				}
			}
		}
		if (!bool_16)
		{
			return;
		}
		List<Aircraft> list5 = new List<Aircraft>();
		foreach (Aircraft item9 in method_3())
		{
			if (!Information.IsNothing((object)item9.Loadout))
			{
				string ReasonForNot = null;
				if (item9.IsAvailableForOps(ref ReasonForNot) == 3)
				{
					list5.Add(item9);
				}
			}
		}
		if (list5.Count <= 0)
		{
			return;
		}
		DarkMessageBox.ShowWarning(Conversions.ToString(list5.Count) + " of the selected aircraft have a reserve loadout, and will not launch.", "Aircraft with reserve loadout selected!");
		foreach (Aircraft item10 in list5)
		{
			hashSet_0.Remove(item10.ObjectID);
		}
	}

	private void method_25(object sender, EventArgs e)
	{
		method_26();
	}

	private void method_26()
	{
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		hashSet_0.Clear();
		foreach (TreeGridNode node in TGV_Aircraft.Nodes)
		{
			if (((DataGridViewRow)node).Selected)
			{
				foreach (Aircraft item in (IEnumerable<Aircraft>)((DataGridViewBand)node).Tag)
				{
					if (item.AirOps.CanBeRearmedRightNow())
					{
						hashSet_0.Add(item.ObjectID);
					}
				}
			}
			if (method_3().Count > 0)
			{
				break;
			}
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected && (((Aircraft)((DataGridViewBand)node2).Tag).AirOps.CanBeRearmedRightNow() | (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)))
				{
					hashSet_0.Add(((Aircraft)((DataGridViewBand)node2).Tag).ObjectID);
				}
			}
			if (method_3().Count > 0)
			{
				break;
			}
		}
		if (!Client.AllowEditModeActions)
		{
			List<Aircraft> list = new List<Aircraft>();
			foreach (Aircraft item2 in method_3())
			{
				string ReasonForNot = null;
				if (item2.IsAvailableForOps(ref ReasonForNot) == 2)
				{
					list.Add(item2);
				}
			}
			if (list.Count > 0)
			{
				DarkMessageBox.ShowWarning(Conversions.ToString(list.Count) + " of the selected aircraft are unavailable for operations, and will not be readied.", "Unavailable aircraft selected!");
				foreach (Aircraft item3 in list)
				{
					hashSet_0.Remove(item3.ObjectID);
				}
			}
		}
		List<Aircraft> list2 = new List<Aircraft>();
		foreach (Aircraft item4 in method_3())
		{
			if (((ActiveUnit)item4).get_UnitSide(SetSideOnly: false) != Client.CurrentSide)
			{
				list2.Add(item4);
			}
		}
		if (list2.Count > 0)
		{
			DarkMessageBox.ShowWarning(Conversions.ToString(list2.Count) + " of the selected aircraft are allied units not under your direct control.", "Allied aircraft selected!");
			foreach (Aircraft item5 in list2)
			{
				hashSet_0.Remove(item5.ObjectID);
			}
		}
		List<Aircraft> list3 = new List<Aircraft>();
		foreach (Aircraft item6 in method_3())
		{
			if (item6.IsOperating())
			{
				list3.Add(item6);
			}
		}
		int num;
		if (list3.Count <= 0)
		{
			num = 0;
		}
		else
		{
			DarkMessageBox.ShowWarning(Conversions.ToString(list3.Count) + " of the selected aircraft are already airborne.", "Airborne aircraft selected!");
			foreach (Aircraft item7 in list3)
			{
				hashSet_0.Remove(item7.ObjectID);
			}
			num = 0;
		}
		int num2 = num;
		List<Aircraft> list4 = new List<Aircraft>();
		foreach (Aircraft item8 in method_3())
		{
			if (num2 != 0)
			{
				if (item8.DBID != num2)
				{
					list4.Add(item8);
				}
			}
			else
			{
				num2 = item8.DBID;
			}
		}
		if (list4.Count > 0)
		{
			DarkMessageBox.ShowWarning(Conversions.ToString(list4.Count) + " of the selected aircraft are of a different type, and will not be readied.", "Different aircraft types selected!");
			foreach (Aircraft item9 in list4)
			{
				hashSet_0.Remove(item9.ObjectID);
			}
		}
		if (method_3().Count <= 0)
		{
			return;
		}
		if (!Information.IsNothing((object)MyProject.Forms.ReadyAircraft.SelectedAircraft))
		{
			MyProject.Forms.ReadyAircraft.SelectedAircraft.Clear();
		}
		else
		{
			MyProject.Forms.ReadyAircraft.SelectedAircraft = new List<Aircraft>();
		}
		foreach (ActiveUnit item10 in method_3())
		{
			MyProject.Forms.ReadyAircraft.SelectedAircraft.Add((Aircraft)item10);
		}
		if (!Information.IsNothing((object)((Aircraft)method_3()[0]).Loadout))
		{
			MyProject.Forms.ReadyAircraft.SelectedLoadout = ((Aircraft)method_3()[0]).Loadout.DBID;
		}
		else
		{
			MyProject.Forms.ReadyAircraft.SelectedLoadout = 0;
		}
		((Control)MyProject.Forms.ReadyAircraft).Show();
	}

	private void method_27(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			TreeGridNode currentNode = TGV_Aircraft.CurrentNode;
			if (currentNode == null || ((DataGridViewBand)currentNode).Tag == null || e.RowIndex == -1)
			{
				return;
			}
			string name = ((DataGridView)TGV_Aircraft).Columns[e.ColumnIndex].Name;
			if (Operators.CompareString(name, "Aircraft", true) != 0)
			{
				if (Operators.CompareString(name, "Loadout", true) != 0)
				{
					return;
				}
				ActiveUnit activeUnit = null;
				try
				{
					activeUnit = (ActiveUnit)((DataGridViewBand)currentNode).Tag;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				if (activeUnit != null && (object)((DataGridViewBand)currentNode).Tag.GetType() == typeof(Aircraft))
				{
					int int32_ = ((Aircraft)activeUnit).LoadoutDBID;
					if (int32_ >= 1)
					{
						Client.smethod_17("Aircraft", activeUnit.DBID, "Loadout" + Conversions.ToString(int32_));
					}
				}
			}
			else if ((object)((DataGridViewBand)currentNode).Tag.GetType() != typeof(Aircraft))
			{
				int dBID = ((IEnumerable<Aircraft>)((DataGridViewBand)currentNode).Tag).ElementAtOrDefault(0).DBID;
				Client.smethod_17("Aircraft", dBID);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200122", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_28(object sender, CollapsingEventArgs e)
	{
		if (e.Node.Level == 1)
		{
			list_2.Remove(((IEnumerable<Aircraft>)((DataGridViewBand)e.Node).Tag).ElementAtOrDefault(0).DBID);
		}
	}

	private void method_29(object sender, EventArgs e)
	{
		method_30();
	}

	private void method_30()
	{
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Invalid comparison between Unknown and I4
		if (Client.Realtime)
		{
			Client.RealtimeTerminal.SendLaunchEmbarkedUnitMessage(null, null, new List<string>(from F in method_3()
				select F.ObjectID));
			return;
		}
		method_24(bool_12: true, bool_13: true, bool_14: true, bool_15: true, bool_16: true);
		if ((from AU in method_3()
			select ((Aircraft)AU).LoadoutDBID).Distinct().Count() > 1 && (int)DarkMessageBox.ShowInformation("There are different types of aircraft in the current selection. Do you want to :" + Environment.NewLine + "-[yes] Enforce a wing with homogenous types of aircrafts, thus splitting it into multiple wings " + Environment.NewLine + "-[No] Force the entire selection into a mixed group ?", "Confirm", DarkDialogButton.YesNo) == 6)
		{
			Misc.FormIntoGroups(method_3().ToList(), Client.CurrentScenario, Client.CurrentSide, Misc.GroupingLogic.SplitByType);
		}
		else
		{
			Misc.FormIntoGroups(method_3().ToList(), Client.CurrentScenario, Client.CurrentSide, Misc.GroupingLogic.MixedGroup);
		}
		switch (method_3().Count)
		{
		case 1:
			((Aircraft)method_3()[0]).AirOps.AttemptToMoveToRunway(ActualAirlaunchPreparation: true);
			break;
		default:
			foreach (Aircraft item in method_3())
			{
				item.AirOps.AttemptToMoveToRunway(ActualAirlaunchPreparation: true);
			}
			break;
		case 0:
			break;
		}
		method_12();
	}

	private void method_31(object sender, DoWorkEventArgs e)
	{
		Thread.Sleep(100);
	}

	private void method_32(object sender, RunWorkerCompletedEventArgs e)
	{
		method_16();
	}

	private void AirOps_Shown(object sender, EventArgs e)
	{
		if (Client.Realtime)
		{
			Client.RealtimeTerminal.SendAirHostSelectionChange(SelectedHosts_IDs.ToList());
		}
		if (method_2().Count > 1)
		{
			((Form)this).Text = "Air Ops - Multiple host units";
		}
		else
		{
			((Form)this).Text = "Air Ops - " + method_2()[0].Name;
		}
		method_9();
		method_17();
		((ToolStripItem)TSB_SetReadyTime).Visible = Client.AllowEditModeActions;
		((ToolStripItem)TSB_Rename).Visible = Client.AllowEditModeActions;
		((ToolStripItem)TSB_Delete).Visible = Client.AllowEditModeActions;
		((Control)TS_Edit).Visible = Client.AllowEditModeActions;
		((ToolStripItem)TSB_AddHostedUnit).Visible = Client.AllowEditModeActions;
		((ToolStripItem)TSB_Cargo).Visible = true;
		((ToolStripItem)TSL_SHIPONFIRE).Visible = false;
		((ToolStripItem)FloodAlert).Visible = false;
		((ToolStripItem)ToolStripSeparator1).Visible = Client.AllowEditModeActions;
		Timer1.Start();
		if (!Client.Realtime)
		{
			Aircraft_AirOps.TookOff += method_10;
			Aircraft_AirOps.Landing += method_8;
			Group.UnitAdded += method_4;
			Group.UnitRemoved += method_5;
			AddUnit.theAddedUnitChanged += method_81;
		}
	}

	private void method_33(object sender, EventArgs e)
	{
		method_34();
	}

	private void method_34()
	{
		if (Client.Realtime)
		{
			Client.RealtimeTerminal.SendLaunchEmbarkedUnitMessage(null, null, null, null, new List<string>(from F in method_3()
				select F.ObjectID));
			return;
		}
		method_24(bool_12: false, bool_13: true, bool_14: true, bool_15: false, bool_16: false);
		foreach (ActiveUnit item in method_3())
		{
			Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)item.AirOps;
			aircraft_AirOps.QueuedTakeOff = false;
			if (aircraft_AirOps.IsTakingOff)
			{
				aircraft_AirOps.AttemptToPark(NormalLandingSequence: true, RearmRefuel: false, AbortLaunch: true);
				if (item.Navigator.HasFlight)
				{
					item.Navigator.get_Flight(HierarchySearch: true).set_Status(Client.CurrentScenario, Command_Core.Mission._FlightStatus.None);
				}
			}
			if (item.IsGroupMember())
			{
				item.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
			}
		}
		method_12();
	}

	private void method_35(object sender, EventArgs e)
	{
		hashSet_0.Clear();
		bool flag = default(bool);
		foreach (TreeGridNode node in TGV_Aircraft.Nodes)
		{
			if (((DataGridViewRow)node).Selected)
			{
				flag = true;
			}
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected)
				{
					hashSet_0.Add(((Aircraft)((DataGridViewBand)node2).Tag).ObjectID);
				}
			}
		}
		if (method_3().Count > 0)
		{
			string objectID = ((Aircraft_AirOps)method_3()[0].AirOps).CurrentHostUnit.ObjectID;
			if (Operators.CompareString(string_0, objectID, true) != 0)
			{
				ActiveUnit activeUnit_ = Client.CurrentScenario.ActiveUnits[objectID];
				dictionary_0 = method_6(ref activeUnit_);
				string_0 = activeUnit_.ObjectID;
			}
		}
		if (!flag)
		{
			int count = method_3().Count;
			if (count == 1)
			{
				Aircraft SelectedAircraft = (Aircraft)method_3()[0];
				if (!Information.IsNothing((object)SelectedAircraft.Loadout))
				{
					if (!SelectedAircraft.IsOperating())
					{
						int dBID = SelectedAircraft.DBID;
						Dictionary<int, int> selectedAircraftTotalWeaponQty = dictionary_0;
						SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
						Scenario currentScenario = Client.CurrentScenario;
						bool UnlimitedAirWeapons = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
						Scenario CurrentScenario = Client.CurrentScenario;
						dataTable_0 = DBFunctions.LoadoutsForThisAircraft_DT(dBID, selectedAircraftTotalWeaponQty, ref sqliteConnection_, currentScenario, ref UnlimitedAirWeapons, ref CurrentScenario, ref SelectedAircraft, ref SelectedAircraft.Loadout.DBID, ref SelectedAircraft.Loadout.NoOptionalWeapons);
						int dBID2 = SelectedAircraft.DBID;
						Dictionary<int, int> selectedAircraftTotalWeaponQty2 = dictionary_0;
						sqliteConnection_ = Client.CurrentScenario.DBConnection;
						Scenario currentScenario2 = Client.CurrentScenario;
						UnlimitedAirWeapons = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
						CurrentScenario = Client.CurrentScenario;
						int num = 0;
						bool ExcludeOptionalWeapons = false;
						dataTable_2 = DBFunctions.LoadoutsForThisAircraft_DT(dBID2, selectedAircraftTotalWeaponQty2, ref sqliteConnection_, currentScenario2, ref UnlimitedAirWeapons, ref CurrentScenario, ref SelectedAircraft, ref num, ref ExcludeOptionalWeapons);
					}
					else if (!Information.IsNothing((object)dataTable_0))
					{
						dataTable_0.Rows.Clear();
						dataTable_2.Rows.Clear();
					}
				}
				else if (!Information.IsNothing((object)dataTable_0))
				{
					dataTable_0.Rows.Clear();
					int dBID3 = SelectedAircraft.DBID;
					Dictionary<int, int> selectedAircraftTotalWeaponQty3 = dictionary_0;
					SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
					Scenario currentScenario3 = Client.CurrentScenario;
					bool ExcludeOptionalWeapons = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
					Scenario CurrentScenario = Client.CurrentScenario;
					int num = 0;
					bool UnlimitedAirWeapons = false;
					dataTable_2 = DBFunctions.LoadoutsForThisAircraft_DT(dBID3, selectedAircraftTotalWeaponQty3, ref sqliteConnection_, currentScenario3, ref ExcludeOptionalWeapons, ref CurrentScenario, ref SelectedAircraft, ref num, ref UnlimitedAirWeapons);
				}
				if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
				{
					Client.SelectThisUnit(SelectedAircraft, ThisUnitOnly: true);
				}
			}
			else if (!Information.IsNothing((object)dataTable_0))
			{
				dataTable_0.Rows.Clear();
				dataTable_2.Rows.Clear();
			}
		}
		else if (!Information.IsNothing((object)dataTable_0))
		{
			dataTable_0.Rows.Clear();
			dataTable_2.Rows.Clear();
		}
		if (!Information.IsNothing((object)dataTable_0))
		{
			if (method_3().Count > 0)
			{
				method_39((Aircraft)method_3()[0]);
			}
			else
			{
				method_39(null);
			}
		}
		if (method_3().Count > 1)
		{
			Client.CurrentSide.SelectedUnits_Clear();
			foreach (ActiveUnit item in method_3())
			{
				Client.CurrentSide.SelectedUnits_Add(item);
			}
		}
		method_37();
		method_38();
	}

	private void method_36(bool bool_12, string string_1 = "All")
	{
		if (Operators.CompareString(string_1, "All", true) == 0)
		{
			((ToolStripItem)TSL_LaunchIndividually).Enabled = bool_12;
			((ToolStripItem)TSL_ReadyAC).Enabled = bool_12;
			((ToolStripItem)TSL_LaunchAsGroup).Enabled = bool_12;
			((ToolStripItem)TSB_AbortLaunch).Enabled = bool_12;
			((ToolStripItem)TSB_Doctrine).Enabled = bool_12;
			((ToolStripItem)TSB_AssignToMission).Enabled = bool_12;
			((ToolStripItem)TSB_Cargo).Enabled = bool_12;
			if (Client.AllowEditModeActions)
			{
				((ToolStripItem)TSB_SetReadyTime).Enabled = true;
				((ToolStripItem)TSB_Rename).Enabled = true;
				((ToolStripItem)TSB_Delete).Enabled = true;
				((ToolStripItem)TSB_AddHostedUnit).Enabled = true;
			}
			((Control)CMenu_AirOps).Enabled = bool_12;
		}
	}

	private void method_37()
	{
		((ToolStripItem)TSL_SHIPONFIRE).Visible = false;
		((ToolStripItem)FloodAlert).Visible = false;
		if (method_3().Count <= 0)
		{
			((ToolStripItem)TSB_Cargo).Enabled = false;
			((ToolStripItem)TSL_LaunchIndividually).Enabled = false;
			((ToolStripItem)TSL_ReadyAC).Enabled = false;
			((ToolStripItem)TSL_LaunchAsGroup).Enabled = false;
			((ToolStripItem)TSB_AbortLaunch).Enabled = false;
			((ToolStripItem)TSB_Doctrine).Enabled = false;
			((ToolStripItem)TSB_AssignToMission).Enabled = false;
			if (Client.AllowEditModeActions)
			{
				((ToolStripItem)TSB_SetReadyTime).Enabled = false;
				((ToolStripItem)TSB_Rename).Enabled = true;
				((ToolStripItem)TSB_Delete).Enabled = true;
				((ToolStripItem)TSB_AddHostedUnit).Enabled = true;
			}
			return;
		}
		ActiveUnit currentHostUnit = ((Aircraft_AirOps)method_3()[0].AirOps).CurrentHostUnit;
		if (currentHostUnit.IsShip)
		{
			if (currentHostUnit.Damage.FireIntensity > ActiveUnit_Damage.FireIntensityLevel.Minor)
			{
				((ToolStripItem)TSL_SHIPONFIRE).Visible = true;
				((ToolStripItem)TSL_SHIPONFIRE).Text = "MAJOR FIRE - NO AIR OPS";
				method_36(bool_12: false);
				return;
			}
			if (currentHostUnit.Damage.FloodIntensity > ActiveUnit_Damage.FloodingIntensityLevel.Minor)
			{
				((ToolStripItem)FloodAlert).Visible = true;
				((ToolStripItem)FloodAlert).Text = "MAJOR FLOOD - NO AIR OPS";
				method_36(bool_12: false);
				return;
			}
			if (currentHostUnit.Damage.FloodIntensity != ActiveUnit_Damage.FloodingIntensityLevel.NoFlooding && ((Aircraft)method_3()[0]).get_CanHover(bool_7: true))
			{
				((ToolStripItem)FloodAlert).Visible = true;
				((ToolStripItem)FloodAlert).Text = "Minor FLOOD - VTOL ONLY";
				method_36(bool_12: true);
				return;
			}
		}
		((ToolStripItem)TSL_LaunchIndividually).Enabled = true;
		((ToolStripItem)TSL_ReadyAC).Enabled = true;
		((ToolStripItem)TSL_LaunchAsGroup).Enabled = true;
		((ToolStripItem)TSB_AbortLaunch).Enabled = true;
		((ToolStripItem)TSB_Doctrine).Enabled = true;
		((ToolStripItem)TSB_AssignToMission).Enabled = true;
		if (Client.AllowEditModeActions)
		{
			((ToolStripItem)TSB_SetReadyTime).Enabled = true;
			((ToolStripItem)TSB_Rename).Enabled = true;
			((ToolStripItem)TSB_Delete).Enabled = true;
			((ToolStripItem)TSB_AddHostedUnit).Enabled = true;
		}
		((ToolStripItem)TSB_Cargo).Enabled = bool_11;
	}

	private void method_38()
	{
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Invalid comparison between Unknown and I4
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Invalid comparison between Unknown and I4
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_046a: Invalid comparison between Unknown and I4
		bool flag = true;
		int num = 0;
		bool? flag2 = default(bool?);
		int? num4 = default(int?);
		if (method_3().Count > 0)
		{
			int? num2 = default(int?);
			foreach (Aircraft item in method_3())
			{
				num++;
				if (((ActiveUnit)item).get_UnitSide(SetSideOnly: false) == Client.CurrentSide)
				{
					if (num == 1 && !Information.IsNothing((object)item.Loadout))
					{
						num2 = item.Loadout.DBID;
					}
					int? elementState = item.Doctrine.GetElementState(Doctrine.DoctrineItem_E.QuickTurnAroundForAircraft);
					int? num3 = elementState;
					if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 2)) != true)
					{
						num3 = elementState;
						int dBID;
						if ((num3.HasValue ? new bool?(num3 == 1) : ((bool?)null)) == true)
						{
							if (Information.IsNothing((object)item.Loadout))
							{
								flag = false;
								break;
							}
							Loadout loadout = item.Loadout;
							if (!loadout.IsAAW && !loadout.IsSupportOrPatrol && !loadout.IsASW)
							{
								flag = false;
								break;
							}
						}
						else if (!Information.IsNothing((object)num2))
						{
							if (Information.IsNothing((object)item.Loadout))
							{
								flag = false;
								break;
							}
							num3 = num2;
							dBID = item.Loadout.DBID;
							if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() != dBID)) == true)
							{
								flag = false;
								break;
							}
						}
						else if (Information.IsNothing((object)num2))
						{
							flag = false;
							break;
						}
						if (!Information.IsNothing((object)item.Loadout))
						{
							if (!item.Loadout.QuickTurnaround)
							{
								flag = false;
								break;
							}
							byte? b = (byte?)item.Doctrine.get_AirOpsTempo(item.ParentScen, MultipleUnits: false, UnitIsOperating: false, ViaDoctrineForm: false, ViaRightColumn: false);
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
							{
								int_1 = item.Loadout.ReadyTime_Sustained;
							}
							else
							{
								int_1 = item.Loadout.ReadyTime;
							}
							bool_4 = item.Loadout.QuickTurnaround;
							int_3 = item.Loadout.QuickTurnaround_ReadyTime;
							int_2 = item.Loadout.QuickTurnaround_AirborneTime;
							int_4 = item.Loadout.QuickTurnaround_MaxSorties;
							int_5 = item.Loadout.QuickTurnaround_AdditionalTimePenalty;
							if (!bool_4)
							{
								flag = false;
								break;
							}
						}
						Aircraft_AirOps airOps = item.AirOps;
						if (Information.IsNothing((object)flag2))
						{
							if (num == 1)
							{
								flag2 = airOps.QuickTurnaround_Enabled;
								num4 = airOps.QuickTurnaround_SortiesTotal;
							}
							continue;
						}
						bool quickTurnaround_Enabled = airOps.QuickTurnaround_Enabled;
						if (((!flag2.HasValue) ? ((bool?)null) : new bool?(quickTurnaround_Enabled != (flag2 == true))) == true)
						{
							flag2 = null;
						}
						dBID = airOps.QuickTurnaround_SortiesTotal;
						bool? flag3 = (num4.HasValue ? new bool?(dBID != num4.GetValueOrDefault()) : ((bool?)null));
						if ((flag3 ?? true) && !Information.IsNothing((object)num4) && flag3.HasValue)
						{
							num4 = null;
						}
						continue;
					}
					flag = false;
					break;
				}
				flag = false;
				break;
			}
		}
		else
		{
			flag = false;
		}
		bool_5 = false;
		if (!flag)
		{
			((Control)CB_QuickTurnaround).Enabled = false;
			if ((int)((CheckBox)CB_QuickTurnaround).CheckState == 2)
			{
				((CheckBox)CB_QuickTurnaround).CheckState = (CheckState)0;
			}
			else
			{
				((CheckBox)CB_QuickTurnaround).Checked = false;
			}
			method_49(int_4);
		}
		else
		{
			((Control)CB_QuickTurnaround).Enabled = true;
			if (!Information.IsNothing((object)flag2))
			{
				if (flag2 != true)
				{
					if ((int)((CheckBox)CB_QuickTurnaround).CheckState == 2)
					{
						((CheckBox)CB_QuickTurnaround).CheckState = (CheckState)0;
					}
					else
					{
						((CheckBox)CB_QuickTurnaround).Checked = false;
					}
					method_49(int_4);
					((Control)Combo_NumberOfSorties).Enabled = false;
					((Control)Label_QuickTurnaroundInfo).Enabled = false;
					((Label)Label_QuickTurnaroundInfo).Text = "";
				}
				else
				{
					if ((int)((CheckBox)CB_QuickTurnaround).CheckState == 2)
					{
						((CheckBox)CB_QuickTurnaround).CheckState = (CheckState)1;
					}
					else
					{
						((CheckBox)CB_QuickTurnaround).Checked = true;
					}
					method_49(num4);
					((Control)Combo_NumberOfSorties).Enabled = true;
					((Control)Label_QuickTurnaroundInfo).Enabled = true;
					if (!Information.IsNothing((object)num4))
					{
						((Label)Label_QuickTurnaroundInfo).Text = QuickTurnaroundPenaltyText();
					}
					else
					{
						((Label)Label_QuickTurnaroundInfo).Text = "";
					}
				}
			}
			else
			{
				((CheckBox)CB_QuickTurnaround).CheckState = (CheckState)2;
				method_49(num4);
				((Control)Combo_NumberOfSorties).Enabled = false;
				((Control)Label_QuickTurnaroundInfo).Enabled = true;
				((Label)Label_QuickTurnaroundInfo).Text = "Selection includes aircraft with and without the Quick Turnaround option set.";
			}
		}
		bool_5 = true;
	}

	private void method_39(Aircraft aircraft_0)
	{
		new SQLiteHelper(Client.CurrentScenario.DBConnection);
		try
		{
			bool_11 = false;
			if (dataTable_0.Rows.Count > 0 && Conversions.ToInteger(dataTable_0.AsEnumerable().ElementAtOrDefault(0)["ID"]) > 4)
			{
				((Label)Label1).Text = "Range and Profile: " + dataTable_0.AsEnumerable().ElementAtOrDefault(0)["RangeProfileDescription"].ToString();
				((Label)Label2).Text = Conversions.ToString(dataTable_0.AsEnumerable().ElementAtOrDefault(0)["LoadoutRoleDescription"]);
				((Label)Label4).Text = "Capabilities: " + dataTable_0.AsEnumerable().ElementAtOrDefault(0)["TimeofDay"].ToString() + ", " + dataTable_0.AsEnumerable().ElementAtOrDefault(0)["Weather"].ToString() + " capable";
				Doctrine._WeaponState value = aircraft_0.Doctrine.get_WinchesterShotgun(Client.CurrentScenario, MultipleUnits: false, UnitIsOperating: false, ViaDoctrineForm: false, ViaRightColumn: false).Value;
				if (value != Doctrine._WeaponState.LoadoutSetting)
				{
					string text = Command_Core.Aircraft.LoadoutWeaponStateDescirption(Conversions.ToInteger(dataTable_0.AsEnumerable().ElementAtOrDefault(0)["ID"]), (int)value, (Loadout.LoadoutRole)Conversions.ToInteger(dataTable_0.AsEnumerable().ElementAtOrDefault(0)["LoadoutRole"]), Client.CurrentScenario);
					string text2 = Conversions.ToString(dataTable_0.AsEnumerable().ElementAtOrDefault(0)["WinchesterShotgunDescription"]);
					if (string.CompareOrdinal(text2, text) != 0)
					{
						((Label)Label3).Text = "Effective pre-briefed weapon state " + text + Environment.NewLine + "Loadout's default weapon state " + text2;
					}
					else
					{
						((Label)Label3).Text = "Pre-briefed weapon state" + text2;
					}
				}
				else
				{
					((Label)Label3).Text = "Pre-briefed weapon state " + Conversions.ToString(dataTable_0.AsEnumerable().ElementAtOrDefault(0)["WinchesterShotgunDescription"]);
				}
				((Label)Label5).Text = "Attack Altitude: " + dataTable_0.AsEnumerable().ElementAtOrDefault(0)["AttackAltitude"].ToString();
				((Label)Label6).Text = "Loadouts available in magazines: " + dataTable_0.AsEnumerable().ElementAtOrDefault(0)["NumberOfLoadouts"].ToString();
				((Label)Label7).Text = "Loadouts available, incl. weapons mounted on all aircraft: " + dataTable_0.AsEnumerable().ElementAtOrDefault(0)["NumberOfLoadoutsIncludingMountedWeapons"].ToString();
				((Label)Label8).Text = "Loadouts available, same as above excl. optional weapons: " + dataTable_0.AsEnumerable().ElementAtOrDefault(0)["NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly"].ToString();
				((Label)Label_Loadout).Text = "Loadout Details: " + dataTable_0.AsEnumerable().ElementAtOrDefault(0)["Name"].ToString();
				int loadoutID = Conversions.ToInteger(dataTable_0.AsEnumerable().ElementAtOrDefault(0)["ID"]);
				SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
				dataTable_1 = DBFunctions.ItemsForThisLoadout(loadoutID, ref sqliteConnection_, ref aircraft_0.Loadout.NoOptionalWeapons);
				dataTable_1.Columns.Add("Available");
				dataTable_1.Columns.Add("AvailableTotal");
				foreach (DataRow row in dataTable_1.Rows)
				{
					int key = Conversions.ToInteger(row["ComponentID"]);
					int int_ = Conversions.ToInteger(row["ComponentID"]);
					Scenario theScen = Client.CurrentScenario;
					if (Weapon.WeaponIsNonRivalrous(int_, ref theScen))
					{
						row["Available"] = "-";
						row["AvailableTotal"] = "-";
					}
					else if (!Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
					{
						int num = ((Aircraft)((DataGridViewBand)((DataGridView)TGV_Aircraft).SelectedRows[0]).Tag).AirOps.CurrentHostUnit.Weaponry.HowManyOfThisWeaponOnMagazines(key);
						int num2 = 0;
						if (!Information.IsNothing((object)dictionary_0) && dictionary_0.ContainsKey(key))
						{
							num2 = dictionary_0[key];
						}
						row["Available"] = num;
						row["AvailableTotal"] = num + num2;
					}
					else
					{
						row["Available"] = "Unlimited";
						row["AvailableTotal"] = "Unlimited";
					}
					row["Item"] = Misc.RemoveHiddenString(Conversions.ToString(row["Item"]));
				}
				if (aircraft_0 != null && ((ICargoHost)aircraft_0).GetCargo_Type() > CargoType.NoCargo)
				{
					bool_11 = true;
				}
			}
			else
			{
				((Label)Label1).Text = "";
				((Label)Label2).Text = "";
				((Label)Label4).Text = "";
				((Label)Label3).Text = "";
				((Label)Label5).Text = "";
				((Label)Label6).Text = "";
				((Label)Label7).Text = "";
				((Label)Label8).Text = "";
				((Label)Label_Loadout).Text = "Loadout Details: None Selected";
				dataTable_1.Rows.Clear();
			}
			if (!bool_11 && dataTable_2.Rows.Count > 0 && (dataTable_0.Rows.Count == 0 || Conversions.ToInteger(dataTable_0.AsEnumerable().ElementAtOrDefault(0)["LoadoutRole"]) != 9002))
			{
				foreach (DataRow row2 in dataTable_2.Rows)
				{
					if (Command_Core.Loadout.IsCargoLoadoutRole(Conversions.ToInteger(row2["LoadoutRole"])))
					{
						bool_11 = true;
						break;
					}
				}
			}
			((DataGridView)DGV_LoadoutItems).AutoGenerateColumns = false;
			((DataGridView)DGV_LoadoutItems).DataSource = dataTable_1;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101136", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void AirOps_KeyDown(object sender, KeyEventArgs e)
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
		else if ((int)e.KeyCode == 117 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if (!((Control)this).Visible || ((int)e.KeyCode != 33 && (int)e.KeyCode != 34 && (int)e.KeyCode != 38 && (int)e.KeyCode != 40 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39 && (int)e.KeyCode != 107 && (int)e.KeyCode != 109 && (int)e.KeyCode != 35 && (int)e.KeyCode != 36))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_40(object sender, EventArgs e)
	{
		method_41();
	}

	private void method_41()
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Invalid comparison between Unknown and I4
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (TreeGridNode node in TGV_Aircraft.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected)
				{
					list.Add((Aircraft)((DataGridViewBand)node2).Tag);
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
			method_12();
			method_18();
			_ = TGV_Aircraft.Nodes.Count;
		}
	}

	private void method_42(object sender, EventArgs e)
	{
		method_43();
	}

	private void method_43()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (TreeGridNode node in TGV_Aircraft.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected)
				{
					list.Add((Aircraft)((DataGridViewBand)node2).Tag);
				}
			}
		}
		MyProject.Forms.TimeToReadyWindow.SelectedUnits = list;
		((Control)MyProject.Forms.TimeToReadyWindow).Show();
	}

	private void method_44(object sender, EventArgs e)
	{
		method_45();
	}

	private void method_45()
	{
		try
		{
			List<TreeGridNode> list = new List<TreeGridNode>();
			foreach (TreeGridNode node in TGV_Aircraft.Nodes)
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
				Aircraft aircraft = (Aircraft)((DataGridViewBand)item).Tag;
				aircraft.AirOps.HostAirFacility.HostedAircraft.Remove(aircraft.ObjectID);
				Client.CurrentScenario.DeleteUnitImmediately(aircraft.ObjectID, ScenEditAction: true, "Aircraft deleted");
				item.Parent.Nodes.Remove(item);
			}
			if (Client.CurrentGame.Status == Game._GameStatus.Paused)
			{
				MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, v: false);
			}
			method_16();
			if (((Control)Client.AirTaskingOrderWindow).Visible)
			{
				Client.AirTaskingOrderWindow.LoadWindow();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 260112", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_46(object sender, EventArgs e)
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Invalid comparison between Unknown and I4
		((Label)Label_QuickTurnaroundInfo).Text = QuickTurnaroundPenaltyText();
		if (bool_5)
		{
			foreach (Aircraft item in method_3())
			{
				Aircraft theAC = item;
				Aircraft_AirOps theAO = theAC.AirOps;
				if (theAO.QuickTurnaround_SortiesFlown < ((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2)
				{
					if (((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2 <= theAC.Loadout.QuickTurnaround_MaxSorties)
					{
						theAO.QuickTurnaround_SortiesTotal = ((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2;
					}
				}
				else if ((int)DarkMessageBox.ShowWarning("Aircraft " + theAC.Name + " had flow equal or more sorties than the selected Max Number of Sorties. Do you want to change to this number and stand down?", "Change Max Number of Sorties and Stand Down?", DarkDialogButton.YesNo) == 6)
				{
					theAO.UpdateQuickTurnaroundSettings_StepDown(ref theAO, ref theAC);
					if (((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2 <= theAC.Loadout.QuickTurnaround_MaxSorties)
					{
						theAO.QuickTurnaround_SortiesTotal = ((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2;
					}
				}
			}
		}
		RefreshForm();
	}

	public string QuickTurnaroundPenaltyText()
	{
		if (((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2 <= int_4)
		{
			return Conversions.ToString(((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2) + " sorties @ " + Misc.TimeString(int_2 * 60) + " maximum airborne time and " + Misc.TimeString(int_3 * 60) + " turnaround, with " + Misc.TimeString(int_1 * 60) + " standdown ready time";
		}
		return "";
	}

	private void method_47(int? nullable_0)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Invalid comparison between Unknown and I4
		((ComboBox)Combo_NumberOfSorties).BeginUpdate();
		((ComboBox)Combo_NumberOfSorties).Items.Clear();
		((ComboBox)Combo_NumberOfSorties).SelectedIndex = -1;
		if ((int)((CheckBox)CB_QuickTurnaround).CheckState != 2 && ((CheckBox)CB_QuickTurnaround).Checked)
		{
			int num = int_4;
			for (int i = 2; i <= num; i++)
			{
				if (i == int_4)
				{
					((ComboBox)Combo_NumberOfSorties).Items.Add((object)(Conversions.ToString(i) + " Sorties (Maximum)"));
				}
				else
				{
					((ComboBox)Combo_NumberOfSorties).Items.Add((object)(Conversions.ToString(i) + " Sorties"));
				}
			}
			if (!Information.IsNothing((object)nullable_0) && ((ComboBox)Combo_NumberOfSorties).Items.Count > 0)
			{
				Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)method_3()[0].AirOps;
				if (aircraft_AirOps.QuickTurnaround_SortiesTotal == 0)
				{
					((ComboBox)Combo_NumberOfSorties).SelectedIndex = int_4 - 2;
				}
				else if (((ComboBox)Combo_NumberOfSorties).Items.Count >= aircraft_AirOps.QuickTurnaround_SortiesTotal - 2)
				{
					try
					{
						((ComboBox)Combo_NumberOfSorties).SelectedIndex = aircraft_AirOps.QuickTurnaround_SortiesTotal - 2;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						((ComboBox)Combo_NumberOfSorties).SelectedIndex = 0;
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					((ComboBox)Combo_NumberOfSorties).SelectedIndex = ((ComboBox)Combo_NumberOfSorties).Items.Count - 1;
				}
			}
			else
			{
				((ComboBox)Combo_NumberOfSorties).Items.Add((object)"Various");
				((ComboBox)Combo_NumberOfSorties).SelectedIndex = ((ComboBox)Combo_NumberOfSorties).Items.Count - 1;
			}
		}
		((ComboBox)Combo_NumberOfSorties).EndUpdate();
	}

	private void method_48(object sender, EventArgs e)
	{
		if (bool_5)
		{
			method_49(int_4);
		}
		RefreshForm();
	}

	private void method_49(int? nullable_0)
	{
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Invalid comparison between Unknown and I4
		if (((CheckBox)CB_QuickTurnaround).Checked)
		{
			((Control)Combo_NumberOfSorties).Enabled = true;
			method_47(nullable_0);
			((Control)Label_QuickTurnaroundInfo).Enabled = true;
			((Label)Label_QuickTurnaroundInfo).Text = QuickTurnaroundPenaltyText();
			if (!bool_5)
			{
				return;
			}
			{
				foreach (Aircraft item in method_3())
				{
					item.AirOps.QuickTurnaround_Enabled = true;
				}
				return;
			}
		}
		((Control)Combo_NumberOfSorties).Enabled = false;
		method_47(nullable_0);
		((Control)Label_QuickTurnaroundInfo).Enabled = false;
		((Label)Label_QuickTurnaroundInfo).Text = "";
		if (!bool_5)
		{
			return;
		}
		foreach (Aircraft item2 in method_3())
		{
			Aircraft theAC = item2;
			Aircraft_AirOps theAO = theAC.AirOps;
			if (theAO.QuickTurnaround_SortiesFlown <= 0)
			{
				theAO.QuickTurnaround_Enabled = false;
				theAO.UpdateQuickTurnaroundSettings_StepDown(ref theAO, ref theAC);
			}
			else if ((int)DarkMessageBox.ShowWarning("Aircraft " + theAC.Name + " had Quick Turnaround enabled previously and has flown at least one Quick Turnaround Sortie. Do you want to disable Quick Turnaround and stand down?", "Disable Quick Turnaround and Stand Down?", DarkDialogButton.YesNo) == 6)
			{
				theAO.QuickTurnaround_Enabled = false;
				theAO.UpdateQuickTurnaroundSettings_StepDown(ref theAO, ref theAC);
			}
		}
	}

	private void AirOps_FormClosed(object sender, FormClosedEventArgs e)
	{
		Aircraft_AirOps.TookOff -= method_10;
		Aircraft_AirOps.Landing -= method_8;
		Group.UnitAdded -= method_4;
		Group.UnitRemoved -= method_5;
	}

	private void method_50(object sender, EventArgs e)
	{
	}

	private void method_51(object sender, EventArgs e)
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		hashSet_0.Clear();
		foreach (TreeGridNode node in TGV_Aircraft.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected)
				{
					hashSet_0.Add(((Aircraft)((DataGridViewBand)node2).Tag).ObjectID);
				}
			}
		}
		((ToolStripDropDownItem)TSB_AssignToMission).DropDownItems.Clear();
		if (method_3().Count <= 0)
		{
			return;
		}
		new ToolStripMenuItem();
		((ToolStripItem)(ToolStripMenuItem)((ToolStrip)((ToolStripDropDownItem)TSB_AssignToMission).DropDown).Items.Add("< Unassign >", (Image)null, (EventHandler)method_50)).Tag = null;
		IEnumerable<Mission> enumerable = Client.CurrentSide.Missions.OrderBy([SpecialName] (Mission theM) => theM.Name);
		foreach (Mission item in enumerable)
		{
			ToolStripMenuItem val = new ToolStripMenuItem();
			ToolStripMenuItem val2 = new ToolStripMenuItem();
			val = (ToolStripMenuItem)((ToolStrip)((ToolStripDropDownItem)TSB_AssignToMission).DropDown).Items.Add(item.Name, (Image)null, (EventHandler)method_50);
			((ToolStripItem)val).Tag = item;
			if (item.MissionClass == Command_Core.Mission._MissionClass.Strike)
			{
				val2 = (ToolStripMenuItem)((ToolStrip)((ToolStripDropDownItem)TSB_AssignToMission).DropDown).Items.Add(item.Name + " - Escort", (Image)null, (EventHandler)method_50);
				((ToolStripItem)val2).Tag = item;
			}
			if (method_3().Count != 1)
			{
				continue;
			}
			ActiveUnit activeUnit = method_3()[0];
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

	private void method_52(object sender, ToolStripItemClickedEventArgs e)
	{
		method_53(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void method_53(object sender, ToolStripItemClickedEventArgs e)
	{
		method_24(bool_12: false, bool_13: true, bool_14: true, bool_15: false, bool_16: false);
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(e.ClickedItem.Tag)))
		{
			foreach (ActiveUnit item in method_3())
			{
				ActiveUnit theAU = item;
				Client.RemoveUnitFromMission(ref theAU);
			}
		}
		else
		{
			Mission theMission = (Mission)e.ClickedItem.Tag;
			bool isEscort = Strings.InStr(e.ClickedItem.Text, " - Escort", (CompareMethod)1) != 0;
			Client.AssignToMission(RuntimeHelpers.GetObjectValue(sender), method_3(), ref theMission, ref isEscort);
			foreach (ActiveUnit item2 in method_3())
			{
				ActiveUnit theSelectedUnit = item2;
				MissionPlanner.CheckRangeToMissionTargets_LoadoutRadius(theSelectedUnit.ParentScen, theMission, ref theSelectedUnit);
			}
		}
		RefreshForm();
	}

	private void method_54(object sender, EventArgs e)
	{
		method_24(bool_12: false, bool_13: true, bool_14: true, bool_15: false, bool_16: false);
		if (method_3().Count > 0)
		{
			MainForm mainForm = MyProject.Forms.MainForm;
			ReadOnlyCollection<Module_Unit.Unit> theSelectedUnits = null;
			List<ActiveUnit> theSelectedActiveUnit = method_3().ToList();
			mainForm.ShowDoctrineROE(null, ref theSelectedUnits, ref theSelectedActiveUnit, UnitIsOperating: false);
		}
	}

	private void method_55(object sender, EventArgs e)
	{
		method_23();
	}

	private void method_56(object sender, EventArgs e)
	{
		method_30();
	}

	private void method_57(object sender, EventArgs e)
	{
		method_26();
	}

	private void method_58(object sender, EventArgs e)
	{
		method_34();
	}

	private void method_59(object sender, EventArgs e)
	{
		method_24(bool_12: false, bool_13: true, bool_14: true, bool_15: false, bool_16: false);
		if (method_3().Count > 0)
		{
			MainForm mainForm = MyProject.Forms.MainForm;
			ReadOnlyCollection<Module_Unit.Unit> theSelectedUnits = null;
			List<ActiveUnit> theSelectedActiveUnit = method_3().ToList();
			mainForm.ShowDoctrineROE(null, ref theSelectedUnits, ref theSelectedActiveUnit, UnitIsOperating: false);
		}
	}

	private void method_60(object sender, EventArgs e)
	{
	}

	private void method_61(object sender, EventArgs e)
	{
		method_43();
	}

	private void method_62(object sender, EventArgs e)
	{
		method_41();
	}

	private void method_63(object sender, EventArgs e)
	{
		method_45();
	}

	private void method_64()
	{
		try
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			foreach (TreeGridNode node in TGV_Aircraft.Nodes)
			{
				foreach (TreeGridNode node2 in node.Nodes)
				{
					if (((DataGridViewRow)node2).Selected)
					{
						list.Add((Aircraft)((DataGridViewBand)node2).Tag);
						break;
					}
				}
				if (list.Count > 0)
				{
					break;
				}
			}
			int num = 1;
			Aircraft aircraft = (Aircraft)list[0];
			if (aircraft.Loadout == null || aircraft.LoadoutDBID == 0)
			{
				return;
			}
			Scenario theScen = Client.CurrentScenario;
			Loadout loadout = DBFunctions.GetLoadout(ref theScen, aircraft.LoadoutDBID, ExcludeOptionalWeapons: false, GetPayloadWeight: true);
			ActiveUnit currentHostUnit = aircraft.AirOps.CurrentHostUnit;
			WeaponRec[] weapons = loadout.Weapons;
			foreach (WeaponRec weaponRec in weapons)
			{
				weaponRec.MaxLoad *= num;
				weaponRec.CurrentLoad *= num;
				int num2 = 0;
				int num3 = 0;
				if (weaponRec.CurrentLoad <= 0)
				{
					continue;
				}
				int currentLoad = weaponRec.CurrentLoad;
				for (int j = 1; j <= currentLoad; j++)
				{
					if (Operators.CompareString(currentHostUnit.Weaponry.AddWeaponToMagazines(weaponRec.int_3, PriorityToAviationMags: true, AllowAddingNewWeaponRec: true), "OK", true) != 0)
					{
						num3++;
					}
					else
					{
						num2++;
					}
				}
			}
			if (list.Count > 0)
			{
				method_39((Aircraft)list[0]);
			}
			else
			{
				method_39(null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1732", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_65(object sender, EventArgs e)
	{
		method_64();
	}

	private void method_66()
	{
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected O, but got Unknown
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Expected O, but got Unknown
		((ToolStripItem)SetTimeToReadyToolStripMenuItem).Visible = Client.AllowEditModeActions;
		((ToolStripItem)RenameToolStripMenuItem).Visible = Client.AllowEditModeActions;
		((ToolStripItem)RemoveToolStripMenuItem).Visible = Client.AllowEditModeActions;
		((ToolStripItem)AddLoadoutToolStripMenuItem).Visible = Client.AllowEditModeActions;
		((ToolStripItem)ToolStripSeparator4).Visible = Client.AllowEditModeActions;
		if (method_3().Count <= 0)
		{
			((ToolStripMenuItem)LaunchIndividuallyToolStripMenuItem).Enabled = false;
			((ToolStripMenuItem)LaunchAsGroupsToolStripMenuItem).Enabled = false;
			((ToolStripMenuItem)ReadyArmToolStripMenuItem).Enabled = false;
			((ToolStripMenuItem)AbortLaunchToolStripMenuItem).Enabled = false;
			((ToolStripMenuItem)TSMI_Doctrine).Enabled = false;
			((ToolStripMenuItem)TSMI_AssignToMission).Enabled = false;
			if (Client.AllowEditModeActions)
			{
				((ToolStripMenuItem)SetTimeToReadyToolStripMenuItem).Enabled = false;
				((ToolStripMenuItem)RenameToolStripMenuItem).Enabled = false;
				((ToolStripMenuItem)RemoveToolStripMenuItem).Enabled = false;
				((ToolStripMenuItem)AddLoadoutToolStripMenuItem).Enabled = false;
			}
		}
		else
		{
			((ToolStripMenuItem)LaunchIndividuallyToolStripMenuItem).Enabled = true;
			((ToolStripMenuItem)LaunchAsGroupsToolStripMenuItem).Enabled = true;
			((ToolStripMenuItem)ReadyArmToolStripMenuItem).Enabled = true;
			((ToolStripMenuItem)AbortLaunchToolStripMenuItem).Enabled = true;
			((ToolStripMenuItem)TSMI_Doctrine).Enabled = true;
			((ToolStripMenuItem)TSMI_AssignToMission).Enabled = true;
			if (Client.AllowEditModeActions)
			{
				((ToolStripMenuItem)SetTimeToReadyToolStripMenuItem).Enabled = true;
				((ToolStripMenuItem)RenameToolStripMenuItem).Enabled = true;
				((ToolStripMenuItem)RemoveToolStripMenuItem).Enabled = true;
				((ToolStripMenuItem)AddLoadoutToolStripMenuItem).Enabled = true;
			}
		}
		hashSet_0.Clear();
		foreach (TreeGridNode node in TGV_Aircraft.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected)
				{
					hashSet_0.Add(((Aircraft)((DataGridViewBand)node2).Tag).ObjectID);
				}
			}
		}
		((ToolStripDropDownItem)TSMI_AssignToMission).DropDownItems.Clear();
		if (method_3().Count <= 0)
		{
			return;
		}
		new ToolStripMenuItem();
		((ToolStripItem)(ToolStripMenuItem)((ToolStrip)((ToolStripDropDownItem)TSMI_AssignToMission).DropDown).Items.Add("< Unassign >", (Image)null, (EventHandler)method_60)).Tag = null;
		IEnumerable<Mission> enumerable = Client.CurrentSide.Missions.OrderBy([SpecialName] (Mission theM) => theM.Name);
		foreach (Mission item in enumerable)
		{
			ToolStripMenuItem val = new ToolStripMenuItem();
			ToolStripMenuItem val2 = new ToolStripMenuItem();
			val = (ToolStripMenuItem)((ToolStrip)((ToolStripDropDownItem)TSMI_AssignToMission).DropDown).Items.Add(item.Name, (Image)null, (EventHandler)method_60);
			((ToolStripItem)val).Tag = item;
			if (item.MissionClass == Command_Core.Mission._MissionClass.Strike)
			{
				val2 = (ToolStripMenuItem)((ToolStrip)((ToolStripDropDownItem)TSMI_AssignToMission).DropDown).Items.Add(item.Name + " - Escort", (Image)null, (EventHandler)method_60);
				((ToolStripItem)val2).Tag = item;
			}
			if (method_3().Count != 1)
			{
				continue;
			}
			ActiveUnit activeUnit = method_3()[0];
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

	private void method_67(object sender, CancelEventArgs e)
	{
		method_66();
	}

	private void method_68(object sender, ToolStripItemClickedEventArgs e)
	{
		method_53(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void AirOps_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		if (Client.CurrentGame.Status == Game._GameStatus.Running && SimConfiguration.DefaultGamePreferences.PauseOnAirDockOps == SimConfiguration.WindowPauseBehaviour.Pause)
		{
			Client.CurrentGame.Pause();
		}
		else if (Client.CurrentGame.Status == Game._GameStatus.Running && SimConfiguration.DefaultGamePreferences.PauseOnAirDockOps == SimConfiguration.WindowPauseBehaviour.SlowToRealTime)
		{
			Client.CurrentScenario.TimeCompression_Set(Scenario.enumTimeCompression.OneSec);
		}
	}

	private void method_69(object sender, EventArgs e)
	{
		hashSet_0.Clear();
		foreach (TreeGridNode node in TGV_Aircraft.Nodes)
		{
			if (((DataGridViewRow)node).Selected)
			{
				foreach (Aircraft item in (IEnumerable<Aircraft>)((DataGridViewBand)node).Tag)
				{
					if (item.AirOps.CanBeRearmedRightNow())
					{
						hashSet_0.Add(item.ObjectID);
					}
				}
			}
			if (method_3().Count > 0)
			{
				break;
			}
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected && ((Aircraft)((DataGridViewBand)node2).Tag).AirOps.CanBeRearmedRightNow())
				{
					hashSet_0.Add(((Aircraft)((DataGridViewBand)node2).Tag).ObjectID);
				}
			}
			if (method_3().Count > 0)
			{
				break;
			}
		}
		if (method_3().Count == 1)
		{
			MyProject.Forms.CargoOpsV2.CargoUnit = method_3()[0];
			MyProject.Forms.CargoOpsV2.HostUnit = ((Aircraft)method_3()[0]).AirOps.CurrentHostUnit;
			((Control)MyProject.Forms.CargoOpsV2).Show();
		}
	}

	private void method_70(object sender, ExpandedEventArgs e)
	{
		_Closure$__395-2 closure$__395- = new _Closure$__395-2(closure$__395-);
		closure$__395-.$VB$Me = this;
		closure$__395-.$VB$Local_e = e;
		closure$__395-.$VB$Local_e.Node.Nodes.Clear();
		if (closure$__395-.$VB$Local_e.Node.Level != 1)
		{
			return;
		}
		_Closure$__395-0 arg = default(_Closure$__395-0);
		_Closure$__395-0 CS$<>8__locals14 = new _Closure$__395-0(arg);
		CS$<>8__locals14.$VB$NonLocal_$VB$Closure_2 = closure$__395-;
		int dBID = ((IEnumerable<Aircraft>)((DataGridViewBand)CS$<>8__locals14.$VB$NonLocal_$VB$Closure_2.$VB$Local_e.Node).Tag).ElementAtOrDefault(0).DBID;
		if (!list_2.Contains(dBID))
		{
			list_2.Add(dBID);
		}
		if (bool_8)
		{
			CS$<>8__locals14.$VB$Local_theCol = ((IEnumerable<Aircraft>)((DataGridViewBand)CS$<>8__locals14.$VB$NonLocal_$VB$Closure_2.$VB$Local_e.Node).Tag).Select([SpecialName] (Aircraft theAC) => theAC).ToList();
			CS$<>8__locals14.$VB$Local_theCol.Sort([SpecialName] (Aircraft theAirc, Aircraft theAirc2) => theAirc.AirOps.ConditionTimer.CompareTo(theAirc2.AirOps.ConditionTimer));
		}
		else if (!bool_9)
		{
			CS$<>8__locals14.$VB$Local_theCol = ((IEnumerable<Aircraft>)((DataGridViewBand)CS$<>8__locals14.$VB$NonLocal_$VB$Closure_2.$VB$Local_e.Node).Tag).Select([SpecialName] (Aircraft theAC) => theAC).OrderBy([SpecialName] (Aircraft theAirc) => theAirc.Name, new NaturalSortComparer<string[]>()).ToList();
		}
		else
		{
			CS$<>8__locals14.$VB$Local_theCol = ((IEnumerable<Aircraft>)((DataGridViewBand)CS$<>8__locals14.$VB$NonLocal_$VB$Closure_2.$VB$Local_e.Node).Tag).Select([SpecialName] (Aircraft theAC) => theAC).ToList();
			CS$<>8__locals14.$VB$Local_theCol.Sort([SpecialName] (Aircraft theAirc, Aircraft theAirc2) => theAirc.LoadoutName.CompareTo(theAirc2.LoadoutName));
		}
		Task.Factory.StartNew([SpecialName] () =>
		{
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Expected O, but got Unknown
			using List<Aircraft>.Enumerator enumerator = CS$<>8__locals14.$VB$Local_theCol.GetEnumerator();
			_Closure$__395-3 closure$__395-2 = default(_Closure$__395-3);
			_Closure$__395-1 closure$__395-3 = default(_Closure$__395-1);
			while (enumerator.MoveNext())
			{
				closure$__395-2 = new _Closure$__395-3(closure$__395-2);
				closure$__395-2.$VB$NonLocal_$VB$Closure_3 = CS$<>8__locals14;
				closure$__395-2.$VB$Local_theAC = enumerator.Current;
				closure$__395-3 = new _Closure$__395-1(closure$__395-3);
				closure$__395-3.$VB$NonLocal_$VB$Closure_4 = closure$__395-2;
				if (Information.IsNothing((object)closure$__395-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.Loadout))
				{
					closure$__395-3.$VB$Local_theLoadoutName = "No Loadout";
				}
				else
				{
					closure$__395-3.$VB$Local_theLoadoutName = closure$__395-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.Loadout.Name;
				}
				if (Information.IsNothing((object)closure$__395-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.ActiveMissionOrPackage()))
				{
					if (Information.IsNothing((object)closure$__395-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.AssignedTaskPool))
					{
						closure$__395-3.$VB$Local_MissionText = "-";
					}
					else
					{
						closure$__395-3.$VB$Local_MissionText = closure$__395-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.AssignedTaskPool.Name + " (Task Pool)";
					}
				}
				else
				{
					string text = "";
					if (closure$__395-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.AI.IsEscort)
					{
						text = ", Escort";
					}
					closure$__395-3.$VB$Local_MissionText = closure$__395-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.ActiveMissionOrPackage().Name + " (" + closure$__395-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.ActiveMissionOrPackage().get_DescriptionString(Client.CurrentScenario) + text + ")";
				}
				closure$__395-3.$VB$Local_theName = closure$__395-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.Name;
				if (((ActiveUnit)closure$__395-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC).get_UnitSide(SetSideOnly: false) != Client.CurrentSide)
				{
					closure$__395-3.$VB$Local_theName = closure$__395-3.$VB$Local_theName + " (" + ((ActiveUnit)closure$__395-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC).get_UnitSide(SetSideOnly: false).Name + ")";
				}
				((Control)CS$<>8__locals14.$VB$NonLocal_$VB$Closure_2.$VB$Me.TGV_Aircraft).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__395-3._Lambda$__7));
				bool num = CS$<>8__locals14.$VB$NonLocal_$VB$Closure_2.$VB$Me.bool_6;
				Aircraft aircraft = closure$__395-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC;
				string ReasonForNot = null;
				if (!(num & (aircraft.IsAvailableForOps(ref ReasonForNot) == 2)))
				{
					((DataGridViewRow)closure$__395-3.$VB$Local_theNode).Visible = true;
				}
				else
				{
					((DataGridViewRow)closure$__395-3.$VB$Local_theNode).Visible = false;
				}
				if (closure$__395-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.Loadout != null && closure$__395-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theAC.LoadoutDBID > 0)
				{
					closure$__395-3.$VB$Local_theNode.Cells[3].Style.Font = new Font("Segoe UI", 8.25f, (FontStyle)4);
				}
			}
		});
	}

	private void method_71(TreeGridNode treeGridNode_0, Aircraft aircraft_0)
	{
		string ReasonForNot;
		if (aircraft_0.AirOps.ConditionTimer == 0f)
		{
			ReasonForNot = null;
			if (aircraft_0.IsAvailableForOps(ref ReasonForNot) == 0)
			{
				((DataGridViewRow)treeGridNode_0).DefaultCellStyle.ForeColor = Color.LightGreen;
				return;
			}
		}
		ReasonForNot = null;
		if (aircraft_0.IsAvailableForOps(ref ReasonForNot) == 0)
		{
			((DataGridViewRow)treeGridNode_0).DefaultCellStyle.ForeColor = Color.Orange;
		}
		else
		{
			((DataGridViewRow)treeGridNode_0).DefaultCellStyle.ForeColor = Color.IndianRed;
		}
	}

	private void method_72(object sender, EventArgs e)
	{
	}

	private ActiveUnit method_73()
	{
		if (method_2().Count == 1)
		{
			return method_2().First();
		}
		if (TV_Facilities.SelectedNodes.Count == 1)
		{
			DarkTreeNode darkTreeNode = TV_Facilities.SelectedNodes.First();
			foreach (ActiveUnit item in method_2())
			{
				if (darkTreeNode.Tag == item)
				{
					return item;
				}
			}
		}
		return null;
	}

	private void method_74(object sender, EventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		ActiveUnit activeUnit = method_73();
		if (activeUnit == null)
		{
			DarkMessageBox.ShowError("Select a single hosting unit from the facilities list to add facilities.", "No Hosting Unit");
			return;
		}
		MyProject.Forms.AddHostingFacility.Mode = 0;
		MyProject.Forms.AddHostingFacility.ParentForm = (Form)(object)this;
		MyProject.Forms.AddHostingFacility.theSelectedUnit = activeUnit;
		((Control)MyProject.Forms.AddHostingFacility).Show();
	}

	private void method_75(object sender, EventArgs e)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Invalid comparison between Unknown and I4
		ActiveUnit activeUnit = null;
		if (TV_Facilities.SelectedNodes.Count > 0)
		{
			foreach (DarkTreeNode selectedNode in TV_Facilities.SelectedNodes)
			{
				if (selectedNode.Tag == null || (object)selectedNode.Tag.GetType() != typeof(AirFacility))
				{
					continue;
				}
				AirFacility airFacility = (AirFacility)selectedNode.Tag;
				if (airFacility.ParentPlatform == null)
				{
					continue;
				}
				bool flag = true;
				if (airFacility.HostedAircraft.Count > 0 && (int)DarkMessageBox.ShowWarning("Facility " + airFacility.Name + " has one or more aircraft present. Removing this facility will delete the aircraft from your scenario.", "Delete Aircraft?", DarkDialogButton.OkCancel) == 2)
				{
					flag = false;
				}
				if (!flag)
				{
					continue;
				}
				if (airFacility.HostedAircraft.Count > 0)
				{
					foreach (Aircraft value in airFacility.HostedAircraft.Values)
					{
						method_10(value);
						Client.CurrentScenario.DeleteUnitImmediately(value.ObjectID, ScenEditAction: true, "Manually deleted by user", null, RegisterAsLosses: false);
					}
				}
				activeUnit = airFacility.ParentPlatform;
				activeUnit.RemoveAirFacility(airFacility);
			}
		}
		if (activeUnit != null)
		{
			RefreshForm();
			MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, activeUnit, v: false);
		}
	}

	private void method_76(object sender, EventArgs e)
	{
		bool_7 = !bool_7;
		PgqStaGwvq0();
	}

	private void PgqStaGwvq0()
	{
		if (!bool_7)
		{
			TGV_Aircraft.CollapseAllItem();
			btnEXPCOL.Text = "Expand aircraft list";
		}
		else
		{
			TGV_Aircraft.ExpandAllItems();
			btnEXPCOL.Text = "Collapse aircraft list";
		}
		method_12();
	}

	private void method_77(bool bool_12)
	{
		bool_7 = bool_12;
		if (!bool_7)
		{
			btnEXPCOL.Text = "Expand aircraft list";
		}
		else
		{
			btnEXPCOL.Text = "Collapse aircraft list";
		}
	}

	private void method_78(object sender, EventArgs e)
	{
		bool_6 = !bool_6;
		if (bool_6)
		{
			btnHideShowMaintenance.Text = "Show non-available";
		}
		else
		{
			btnHideShowMaintenance.Text = "Hide non-available";
		}
		method_12();
	}

	private void method_79(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.ColumnIndex == 4)
		{
			bool_8 = true;
			bool_9 = false;
		}
		else if (e.ColumnIndex == 3)
		{
			bool_8 = false;
			bool_9 = true;
		}
		else
		{
			bool_8 = false;
			bool_9 = false;
		}
		foreach (TreeGridNode item in method_14())
		{
			if (item.IsExpanded)
			{
				ExpandedEventArgs e2 = new ExpandedEventArgs(item);
				method_70(item, e2);
			}
		}
	}

	private void method_80(object sender, EventArgs e)
	{
		AddUnit.CalledFromAirOps = true;
		Client.CurrentUserAction = Client.UserAction.AddingPlatform;
		((Control)MyProject.Forms.AddUnit).Show();
	}

	private void method_81(ActiveUnit activeUnit_0)
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		if (!AddUnit.CalledFromAirOps)
		{
			return;
		}
		foreach (DarkTreeNode node in TV_Facilities.Nodes)
		{
			ActiveUnit activeUnit = (ActiveUnit)node.Tag;
			if (!activeUnit_0.IsAircraft)
			{
				break;
			}
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(node.Tag)) || activeUnit.AirOps == null)
			{
				continue;
			}
			if (activeUnit.AirOps.CanHostThisAircraft((Aircraft)activeUnit_0) != AirOpsAttemptResult.Success)
			{
				if (Client.CurrentSide.IsHumanControlled)
				{
					DarkMessageBox.ShowError("The Unit " + activeUnit_0.Name + " Cannot be hosted", "Unit cannot be hosted");
				}
				continue;
			}
			((Aircraft)activeUnit_0).AirOps.HostAirFacility = null;
			activeUnit.AirOps.AddThisAircraft((Aircraft)activeUnit_0, GameIsRunning: false);
			int num;
			if (GlobalVariables.AI_REWORK)
			{
				num = 1;
			}
			else
			{
				activeUnit_0.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				num = 1;
			}
			flag = (byte)num != 0;
			break;
		}
		if (!flag)
		{
			Client.CurrentScenario.DeleteUnitImmediately(activeUnit_0.ObjectID, ScenEditAction: true, activeUnit_0.Name + " Unit could not be hosted");
			return;
		}
		((Control)TGV_Aircraft).Enabled = true;
		method_8((Aircraft)activeUnit_0);
		method_17();
		RefreshAll();
	}

	static AirOps()
	{
		Class72.smethod_20();
	}
}
