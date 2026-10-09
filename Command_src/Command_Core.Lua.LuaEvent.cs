using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[StandardModule]
public sealed class LuaEvent
{
	[CompilerGenerated]
	internal sealed class _Closure$__10-0
	{
		public object $VB$Local_o;

		public _Closure$__10-0(_Closure$__10-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ReferencePoint s)
		{
			if (string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__10-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__10-1
	{
		public object $VB$Local_o;

		public _Closure$__10-1(_Closure$__10-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__2(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__3(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__4(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__5(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__6(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__7(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__8(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__10-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__10-2
	{
		public object $VB$Local_o;

		public _Closure$__10-2(_Closure$__10-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__9(ReferencePoint s)
		{
			if (!string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		static _Closure$__10-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__10-3
	{
		public object $VB$Local_o;

		public _Closure$__10-3(_Closure$__10-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__10(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__11(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__12(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__13(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__14(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__15(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__16(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__17(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__10-3()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__10-4
	{
		public object $VB$Local_o;

		public _Closure$__10-4(_Closure$__10-4 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__18(ReferencePoint s)
		{
			if (!string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		static _Closure$__10-4()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__10-5
	{
		public object $VB$Local_o;

		public _Closure$__10-5(_Closure$__10-5 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__19(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__20(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__21(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__22(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__23(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__24(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__25(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__26(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__10-5()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__10-6
	{
		public object $VB$Local_o;

		public _Closure$__10-6(_Closure$__10-6 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__27(ReferencePoint s)
		{
			if (string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__10-6()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__10-7
	{
		public object $VB$Local_o;

		public _Closure$__10-7(_Closure$__10-7 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__28(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__29(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__30(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__31(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__32(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__33(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__34(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__35(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__10-7()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__12-0
	{
		public object $VB$Local_o;

		public _Closure$__12-0(_Closure$__12-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ReferencePoint s)
		{
			if (string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__12-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__12-1
	{
		public object $VB$Local_o;

		public _Closure$__12-1(_Closure$__12-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__2(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__3(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__4(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__5(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__6(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__7(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__8(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__12-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__18-0
	{
		public object $VB$Local_o;

		public _Closure$__18-0(_Closure$__18-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ReferencePoint s)
		{
			if (string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__18-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__18-1
	{
		public object $VB$Local_o;

		public _Closure$__18-1(_Closure$__18-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__2(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__3(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__4(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__5(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__6(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__7(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__8(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__18-1()
		{
			Class72.smethod_20();
		}
	}

	public static readonly string[] Keyword_Triggers_Points;

	public static readonly string[] Keyword_Triggers_RandomTime;

	public static readonly string[] Keyword_Triggers_RegularTime;

	public static readonly string[] Keyword_Triggers_ScenEnded;

	public static readonly string[] Keyword_Triggers_ScenLoaded;

	public static readonly string[] Keyword_Triggers_Time;

	public static readonly string[] Keyword_Triggers_UnitDamaged;

	public static readonly string[] Keyword_Triggers_UnitDestroyed;

	public static readonly string[] Keyword_Triggers_UnitDetected;

	public static readonly string[] Keyword_Triggers_UnitEmissions;

	public static readonly string[] Keyword_Triggers_UnitEntersArea;

	public static readonly string[] Keyword_Triggers_UnitRemainsInArea;

	public static readonly string[] Keyword_Triggers_UnitBaseStatus;

	public static readonly string[] Keyword_Triggers_UnitCargoMoved;

	public static readonly string[] Keyword_Conditions_LuaScript;

	public static readonly string[] Keyword_Conditions_ScenHasStarted;

	public static readonly string[] Keyword_Conditions_SidePosture;

	public static readonly string[] Keyword_Actions_ChangeMissionStatus;

	public static readonly string[] Keyword_Actions_EndScenario;

	public static readonly string[] Keyword_Actions_LuaScript;

	public static readonly string[] Keyword_Actions_Message;

	public static readonly string[] Keyword_Actions_Points;

	public static readonly string[] Keyword_Actions_TeleportInArea;

	public static readonly string[] Keyword_Triggers_PlayerJoinedSide;

	static LuaEvent()
	{
		Class72.smethod_20();
		Keyword_Triggers_Points = new string[7] { "Points", "EventTrigger_Points", "ID", "Description", "SideID", "PointValue", "ReachDirection" };
		Keyword_Triggers_RandomTime = new string[6] { "RandomTime", "EventTrigger_RandomTime", "ID", "Description", "EarliestTime", "LatestTime" };
		Keyword_Triggers_RegularTime = new string[5] { "RegularTime", "EventTrigger_RegularTime", "ID", "Description", "Interval" };
		Keyword_Triggers_ScenEnded = new string[4] { "ScenEnded", "EventTrigger_ScenEnded", "ID", "Description" };
		Keyword_Triggers_ScenLoaded = new string[4] { "ScenLoaded", "EventTrigger_ScenLoaded", "ID", "Description" };
		Keyword_Triggers_Time = new string[5] { "Time", "EventTrigger_Time", "ID", "Description", "Time" };
		Keyword_Triggers_UnitDamaged = new string[6] { "UnitDamaged", "EventTrigger_UnitDamaged", "ID", "Description", "DamagePercent", "TargetFilter" };
		Keyword_Triggers_UnitDestroyed = new string[5] { "UnitDestroyed", "EventTrigger_UnitDestroyed", "ID", "Description", "TargetFilter" };
		Keyword_Triggers_UnitDetected = new string[8] { "UnitDetected", "EventTrigger_UnitDetected", "ID", "Description", "Area", "TargetFilter", "DetectorSideID", "MCL" };
		Keyword_Triggers_UnitEmissions = new string[8] { "UnitEmissions", "EventTrigger_UnitEmissions", "ID", "Description", "Area", "TargetFilter", "DetectorSideID", "MCL" };
		Keyword_Triggers_UnitEntersArea = new string[10] { "UnitEntersArea", "EventTrigger_UnitEntersArea", "ID", "Description", "TargetFilter", "Area", "ETOA", "LTOA", "NOT", "ExitArea" };
		Keyword_Triggers_UnitRemainsInArea = new string[7] { "UnitRemainsInArea", "EventTrigger_UnitRemainsInArea", "ID", "Description", "TargetFilter", "Area", "TD" };
		Keyword_Triggers_UnitBaseStatus = new string[7] { "UnitBaseStatus", "EventTrigger_UnitBaseStatus", "ID", "Description", "TargetFilter", "TargetCondition", "TargetBase" };
		Keyword_Triggers_UnitCargoMoved = new string[6] { "UnitCargoMoved", "EventTrigger_UnitCargoMoved", "BaseUnit", "ID", "Description", "CargoFilter" };
		Keyword_Conditions_LuaScript = new string[5] { "LuaScript", "EventCondition_LuaScript", "ID", "Description", "ScriptText" };
		Keyword_Conditions_ScenHasStarted = new string[5] { "ScenHasStarted", "EventCondition_ScenHasStarted", "ID", "Description", "NOT" };
		Keyword_Conditions_SidePosture = new string[8] { "SidePosture", "EventCondition_SidePosture", "ID", "Description", "ObserverSideID", "TargetSideID", "TargetPosture", "NOT" };
		Keyword_Actions_ChangeMissionStatus = new string[6] { "ChangeMissionStatus", "EventAction_ChangeMissionStatus", "ID", "Description", "MissionID", "NewStatus" };
		Keyword_Actions_EndScenario = new string[3] { "EndScenario", "EventAction_EndScenario", "ID" };
		Keyword_Actions_LuaScript = new string[6] { "LuaScript", "EventAction_LuaScript", "ID", "Description", "ScriptText", "ScriptFor" };
		Keyword_Actions_Message = new string[6] { "Message", "EventAction_Message", "ID", "Description", "SideID", "Text" };
		Keyword_Actions_Points = new string[6] { "Points", "EventAction_Points", "ID", "Description", "SideID", "PointChange" };
		Keyword_Actions_TeleportInArea = new string[6] { "TeleportInArea", "EventAction_TeleportInArea", "ID", "Description", "UnitIDs", "Area" };
		Keyword_Triggers_PlayerJoinedSide = new string[4] { "PlayerJoinedSide", "EventTrigger_PlayerJoinedSide", "ID", "Description" };
	}

	public static string ScenEdit_ExecuteEventAction(string eventNameOrId, Scenario ScenarioContext)
	{
		EventAction eventAction = null;
		string b = eventNameOrId.ToLower();
		foreach (EventAction value in ScenarioContext.EventActions.Values)
		{
			if (value.Type == EventAction.EventActionType.LuaScript && (string.Equals(value.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, b, StringComparison.OrdinalIgnoreCase)))
			{
				eventAction = value;
				break;
			}
		}
		if (eventAction != null)
		{
			return ((EventAction_LuaScript)eventAction).ScriptText;
		}
		return null;
	}

	public static object ScenEdit_UpdateEvent(string eventNameOrId, LuaTable table, Scenario ScenarioContext)
	{
		bool flag = false;
		try
		{
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
			string text = eventNameOrId.ToLower();
			SimEvent simEvent = null;
			foreach (SimEvent value3 in ScenarioContext.SimEvents.Values)
			{
				if (string.Equals(value3.Description, text, StringComparison.OrdinalIgnoreCase) || Operators.CompareString(value3.ObjectID, text, false) == 0)
				{
					simEvent = value3;
					break;
				}
			}
			if (Information.IsNothing((object)simEvent))
			{
				throw new LuaError("Unable to identify the desired Event!");
			}
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			string text2 = null;
			string text3 = null;
			if (dictionary.ContainsKey("Type".ToUpper()))
			{
				string text4 = null;
				try
				{
					text2 = dictionary["Type".ToUpper()].ToString();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					throw new LuaError("Unable to parse event Type!");
				}
				switch (text2.ToUpper())
				{
				case "ADD_ACTION":
				case "REMOVE_ACTION":
				case "REPLACE_ACTION":
				{
					EventAction_LuaScript eventAction_LuaScript = new EventAction_LuaScript();
					switch (text2.ToUpper())
					{
					case "REPLACE_ACTION":
					{
						EventAction eventAction = null;
						if (!dictionary.ContainsKey("Description".ToUpper()))
						{
							break;
						}
						try
						{
							text4 = dictionary["Description".ToUpper()].ToString();
						}
						catch (Exception projectError9)
						{
							ProjectData.SetProjectError(projectError9);
							throw new LuaError("Unable to parse event Description!");
						}
						foreach (EventAction value4 in ScenarioContext.EventActions.Values)
						{
							if ((string.Equals(value4.Description, text4, StringComparison.OrdinalIgnoreCase) || string.Equals(value4.ObjectID, text4, StringComparison.OrdinalIgnoreCase)) && value4 is EventAction_LuaScript)
							{
								eventAction = value4;
								break;
							}
						}
						if (eventAction == null)
						{
							throw new LuaError("Event action not found!");
						}
						if (dictionary.ContainsKey("Script".ToUpper()))
						{
							try
							{
								text4 = dictionary["Script".ToUpper()].ToString();
							}
							catch (Exception projectError10)
							{
								ProjectData.SetProjectError(projectError10);
								throw new LuaError("Unable to parse event Script!");
							}
							eventAction_LuaScript = (EventAction_LuaScript)eventAction;
							text3 = ((EventAction_LuaScript)eventAction).ScriptText;
							((EventAction_LuaScript)eventAction).ScriptText = text4;
							flag = true;
						}
						break;
					}
					case "REMOVE_ACTION":
					{
						EventAction value2 = null;
						if (!dictionary.ContainsKey("Description".ToUpper()))
						{
							break;
						}
						try
						{
							text4 = dictionary["Description".ToUpper()].ToString();
						}
						catch (Exception projectError11)
						{
							ProjectData.SetProjectError(projectError11);
							throw new LuaError("Unable to parse event Description!");
						}
						foreach (EventAction value5 in ScenarioContext.EventActions.Values)
						{
							if ((string.Equals(value5.Description, text4, StringComparison.OrdinalIgnoreCase) || string.Equals(value5.ObjectID, text4, StringComparison.OrdinalIgnoreCase)) && value5 is EventAction_LuaScript)
							{
								value2 = value5;
								break;
							}
						}
						if (value2 == null)
						{
							throw new LuaError("Event action not found!");
						}
						simEvent.Actions.Remove(value2);
						ScenarioContext.EventActions.TryRemove(value2.ObjectID, out value2);
						eventAction_LuaScript = (EventAction_LuaScript)value2;
						flag = true;
						break;
					}
					case "ADD_ACTION":
						if (dictionary.ContainsKey("Description".ToUpper()))
						{
							try
							{
								text4 = dictionary["Description".ToUpper()].ToString();
							}
							catch (Exception projectError7)
							{
								ProjectData.SetProjectError(projectError7);
								throw new LuaError("Unable to parse event Description!");
							}
							eventAction_LuaScript.Description = text4;
						}
						if (dictionary.ContainsKey("Script".ToUpper()))
						{
							try
							{
								text4 = dictionary["Script".ToUpper()].ToString();
							}
							catch (Exception projectError8)
							{
								ProjectData.SetProjectError(projectError8);
								throw new LuaError("Unable to parse event Script!");
							}
							eventAction_LuaScript.ScriptText = text4;
						}
						if (eventAction_LuaScript.ScriptText != null)
						{
							simEvent.Actions.Add(eventAction_LuaScript);
							ScenarioContext.EventActions.TryAdd(eventAction_LuaScript.ObjectID, eventAction_LuaScript);
							flag = true;
						}
						break;
					}
					luaTable["type"] = "ACTION";
					luaTable["description"] = eventAction_LuaScript.Description;
					luaTable["guid"] = eventAction_LuaScript.ObjectID;
					if (text3 == null)
					{
						luaTable["script"] = eventAction_LuaScript.ScriptText;
					}
					else
					{
						luaTable["script"] = text3;
					}
					break;
				}
				case "ADD_CONDITION":
				case "REMOVE_CONDITION":
				case "REPLACE_CONDITION":
				{
					EventCondition_LuaScript eventCondition_LuaScript = new EventCondition_LuaScript();
					switch (text2.ToUpper())
					{
					case "ADD_CONDITION":
						if (dictionary.ContainsKey("Description".ToUpper()))
						{
							try
							{
								text4 = dictionary["Description".ToUpper()].ToString();
							}
							catch (Exception projectError5)
							{
								ProjectData.SetProjectError(projectError5);
								throw new LuaError("Unable to parse event Description!");
							}
							eventCondition_LuaScript.Description = text4;
						}
						if (dictionary.ContainsKey("Script".ToUpper()))
						{
							try
							{
								text4 = dictionary["Script".ToUpper()].ToString();
							}
							catch (Exception projectError6)
							{
								ProjectData.SetProjectError(projectError6);
								throw new LuaError("Unable to parse event Script!");
							}
							eventCondition_LuaScript.ScriptText = text4;
						}
						if (eventCondition_LuaScript.ScriptText != null)
						{
							simEvent.Conditions.Add(eventCondition_LuaScript);
							ScenarioContext.EventConditions.TryAdd(eventCondition_LuaScript.ObjectID, eventCondition_LuaScript);
							flag = true;
						}
						break;
					case "REMOVE_CONDITION":
					{
						if (!dictionary.ContainsKey("Description".ToUpper()))
						{
							break;
						}
						EventCondition value = null;
						try
						{
							text4 = dictionary["Description".ToUpper()].ToString();
						}
						catch (Exception projectError4)
						{
							ProjectData.SetProjectError(projectError4);
							throw new LuaError("Unable to parse event Description!");
						}
						foreach (EventCondition value6 in ScenarioContext.EventConditions.Values)
						{
							if ((string.Equals(value6.Description, text4, StringComparison.OrdinalIgnoreCase) || string.Equals(value6.ObjectID, text4, StringComparison.OrdinalIgnoreCase)) && value6 is EventCondition_LuaScript)
							{
								value = value6;
								break;
							}
						}
						if (value == null)
						{
							throw new LuaError("Event condition not found!");
						}
						simEvent.Conditions.Remove(value);
						ScenarioContext.EventConditions.TryRemove(value.ObjectID, out value);
						eventCondition_LuaScript = (EventCondition_LuaScript)value;
						flag = true;
						break;
					}
					case "REPLACE_CONDITION":
					{
						EventCondition eventCondition = null;
						if (!dictionary.ContainsKey("Description".ToUpper()))
						{
							break;
						}
						try
						{
							text4 = dictionary["Description".ToUpper()].ToString();
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							throw new LuaError("Unable to parse event Description!");
						}
						foreach (EventCondition value7 in ScenarioContext.EventConditions.Values)
						{
							if ((string.Equals(value7.Description, text4, StringComparison.OrdinalIgnoreCase) || string.Equals(value7.ObjectID, text4, StringComparison.OrdinalIgnoreCase)) && value7 is EventCondition_LuaScript)
							{
								eventCondition = value7;
								break;
							}
						}
						if (eventCondition != null)
						{
							if (dictionary.ContainsKey("Script".ToUpper()))
							{
								try
								{
									text4 = dictionary["Script".ToUpper()].ToString();
								}
								catch (Exception projectError3)
								{
									ProjectData.SetProjectError(projectError3);
									throw new LuaError("Unable to parse event Script!");
								}
								eventCondition_LuaScript = (EventCondition_LuaScript)eventCondition;
								text3 = ((EventCondition_LuaScript)eventCondition).ScriptText;
								((EventCondition_LuaScript)eventCondition).ScriptText = text4;
								flag = true;
							}
							break;
						}
						throw new LuaError("Event condition not found!");
					}
					}
					luaTable["type"] = "CONDITION";
					luaTable["description"] = eventCondition_LuaScript.Description;
					luaTable["guid"] = eventCondition_LuaScript.ObjectID;
					if (text3 == null)
					{
						luaTable["script"] = eventCondition_LuaScript.ScriptText;
					}
					else
					{
						luaTable["script"] = text3;
					}
					break;
				}
				}
			}
			if (luaTable.Keys.Count != 0)
			{
				return luaTable;
			}
			return flag;
		}
		catch (Exception projectError12)
		{
			ProjectData.SetProjectError(projectError12);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaWrapper_Event ScenEdit_GetEvent(string eventNameOrId, int level, Scenario ScenarioContext)
	{
		try
		{
			new HashSet<string>();
			string b = eventNameOrId.ToLower();
			LuaSandBox.Singleton().CreateTable();
			bool xml = false;
			if (level > 9)
			{
				xml = true;
				level -= 10;
			}
			SimEvent simEvent = null;
			foreach (SimEvent value in ScenarioContext.SimEvents.Values)
			{
				if (string.Equals(value.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, b, StringComparison.OrdinalIgnoreCase))
				{
					simEvent = value;
				}
			}
			if (simEvent == null)
			{
				return null;
			}
			return new LuaWrapper_Event(simEvent, level, xml, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaTable ScenEdit_GetEvents(int level, Scenario ScenarioContext)
	{
		try
		{
			new HashSet<string>();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			bool xml = false;
			if (level > 9)
			{
				xml = true;
				level -= 10;
			}
			foreach (SimEvent value2 in ScenarioContext.SimEvents.Values)
			{
				LuaWrapper_Event value = new LuaWrapper_Event(value2, level, xml, ScenarioContext);
				luaTable[luaTable.Keys.Count + 1] = value;
			}
			return luaTable;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool ScenEdit_SetSpecialAction(LuaTable table, Scenario ScenarioContext)
	{
		try
		{
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
			if (!dictionary.ContainsKey("ActionNameOrID".ToUpper()))
			{
				throw new LuaError("Missing mandatory variable 'ActionNameOrID'");
			}
			string b = dictionary["ActionNameOrID".ToUpper()].ToString();
			Side side = null;
			if (dictionary.ContainsKey("SIDE"))
			{
				string text = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, ScenarioContext);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					throw new LuaError("Can't find Side '" + text + "'");
				}
			}
			SpecialAction specialAction = null;
			if (side != null)
			{
				foreach (SpecialAction value in side.SpecialActions.Values)
				{
					if (string.Equals(value.Name, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, b, StringComparison.OrdinalIgnoreCase))
					{
						specialAction = value;
						break;
					}
				}
			}
			else
			{
				Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
				foreach (Side side2 in sides_ReadOnly)
				{
					foreach (SpecialAction value2 in side2.SpecialActions.Values)
					{
						if (string.Equals(value2.Name, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.ObjectID, b, StringComparison.OrdinalIgnoreCase))
						{
							specialAction = value2;
							side = side2;
							break;
						}
					}
				}
			}
			if (Information.IsNothing((object)specialAction))
			{
				throw new LuaError("Unable to identify the desired Special Action!");
			}
			if (dictionary.ContainsKey("NewName".ToUpper()))
			{
				string name;
				try
				{
					name = dictionary["NewName".ToUpper()].ToString();
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					throw new LuaError("Unable to parse value NewName to string!");
				}
				specialAction.Name = name;
			}
			if (dictionary.ContainsKey("Description".ToUpper()))
			{
				string description;
				try
				{
					description = dictionary["Description".ToUpper()].ToString();
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					throw new LuaError("Unable to parse value Description to string!");
				}
				specialAction.Description = description;
			}
			if (dictionary.ContainsKey("IsActive".ToUpper()))
			{
				bool isActive;
				try
				{
					isActive = Conversions.ToBoolean(dictionary["IsActive".ToUpper()].ToString());
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					throw new LuaError("Unable to parse value IsActive to true/false!");
				}
				specialAction.IsActive = isActive;
			}
			if (dictionary.ContainsKey("IsRepeatable".ToUpper()))
			{
				bool isRepeatable;
				try
				{
					isRepeatable = Conversions.ToBoolean(dictionary["IsRepeatable".ToUpper()].ToString());
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					throw new LuaError("Unable to parse IsRepeatable to true/false!");
				}
				specialAction.IsRepeatable = isRepeatable;
			}
			if (dictionary.ContainsKey("ScriptText".ToUpper()))
			{
				string scriptText;
				try
				{
					scriptText = dictionary["ScriptText".ToUpper()].ToString();
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					throw new LuaError("Unable to parse value Script to string!");
				}
				specialAction.ScriptText = scriptText;
			}
			int result;
			if (dictionary.ContainsKey("Mode".ToUpper()))
			{
				string a;
				try
				{
					a = dictionary["Mode".ToUpper()].ToString();
				}
				catch (Exception projectError7)
				{
					ProjectData.SetProjectError(projectError7);
					throw new LuaError("Unable to parse value Mode to string!");
				}
				if (string.Equals(a, "remove", StringComparison.OrdinalIgnoreCase))
				{
					side.SpecialActions.Remove(specialAction.ObjectID);
					result = 1;
					goto IL_038e;
				}
			}
			result = 1;
			goto IL_038e;
			IL_038e:
			return (byte)result != 0;
		}
		catch (Exception projectError8)
		{
			ProjectData.SetProjectError(projectError8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool ScenEdit_AddSpecialAction(LuaTable table, Scenario ScenarioContext)
	{
		try
		{
			Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
			LuaUtility.ParseUnitDict(ref dict);
			if (!dict.ContainsKey("SIDE"))
			{
				throw new LuaError("Missing mandatory variable 'Side'");
			}
			Side side = null;
			if (dict.ContainsKey("SIDE"))
			{
				string text = Conversions.ToString(dict["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dict, ScenarioContext);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					throw new LuaError("Can't find Side '" + text + "'");
				}
			}
			if (dict.ContainsKey("ActionNameOrID".ToUpper()))
			{
				string text2 = dict["ActionNameOrID".ToUpper()].ToString();
				SpecialAction specialAction = null;
				foreach (SpecialAction value in side.SpecialActions.Values)
				{
					if (string.Equals(value.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
					{
						specialAction = value;
					}
				}
				if (specialAction != null)
				{
					throw new LuaError("Special Action exists (" + text2 + ")!");
				}
				specialAction = new SpecialAction();
				specialAction.Name = text2;
				if (dict.ContainsKey("Description".ToUpper()))
				{
					string description;
					try
					{
						description = dict["Description".ToUpper()].ToString();
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						throw new LuaError("Unable to parse value Description to string!");
					}
					specialAction.Description = description;
				}
				if (dict.ContainsKey("IsActive".ToUpper()))
				{
					bool isActive;
					try
					{
						isActive = Conversions.ToBoolean(dict["IsActive".ToUpper()].ToString());
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						throw new LuaError("Unable to parse value IsActive to true/false!");
					}
					specialAction.IsActive = isActive;
				}
				if (dict.ContainsKey("IsRepeatable".ToUpper()))
				{
					bool isRepeatable;
					try
					{
						isRepeatable = Conversions.ToBoolean(dict["IsRepeatable".ToUpper()].ToString());
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						throw new LuaError("Unable to parse IsRepeatable to true/false!");
					}
					specialAction.IsRepeatable = isRepeatable;
				}
				if (dict.ContainsKey("ScriptText".ToUpper()))
				{
					string scriptText;
					try
					{
						scriptText = dict["ScriptText".ToUpper()].ToString();
					}
					catch (Exception projectError5)
					{
						ProjectData.SetProjectError(projectError5);
						throw new LuaError("Unable to parse value Script to string!");
					}
					specialAction.ScriptText = scriptText;
				}
				side.SpecialActions.Add(specialAction.ObjectID, specialAction);
				return true;
			}
			throw new LuaError("Missing mandatory variable 'ActionNameOrID'");
		}
		catch (Exception projectError6)
		{
			ProjectData.SetProjectError(projectError6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaTable ScenEdit_GetSpecialAction(LuaTable table, Scenario ScenarioContext)
	{
		try
		{
			Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
			LuaUtility.ParseUnitDict(ref dict);
			Side side = null;
			if (dict.ContainsKey("SIDE"))
			{
				string text = Conversions.ToString(dict["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dict, ScenarioContext);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					throw new LuaError("Can't find Side '" + text + "'");
				}
			}
			SpecialAction specialAction = null;
			if (dict.ContainsKey("Mode".ToUpper()))
			{
				string a;
				try
				{
					a = dict["Mode".ToUpper()].ToString();
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					throw new LuaError("Unable to parse value Mode to string!");
				}
				if (string.Equals(a, "list", StringComparison.OrdinalIgnoreCase))
				{
					LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
					Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
					foreach (Side side2 in sides_ReadOnly)
					{
						if (side != null && Operators.CompareString(side.ObjectID, side2.ObjectID, false) != 0)
						{
							continue;
						}
						foreach (SpecialAction value in side2.SpecialActions.Values)
						{
							LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
							luaTable2["guid"] = value.ObjectID;
							luaTable2["name"] = value.Name;
							luaTable2["description"] = value.Description;
							luaTable2["isActive"] = value.IsActive;
							luaTable2["IsRepeatable"] = value.IsRepeatable;
							luaTable2["ScriptText"] = value.ScriptText;
							luaTable2["side"] = side2.ObjectID;
							luaTable[luaTable.Keys.Count + 1] = luaTable2;
						}
					}
					return luaTable;
				}
			}
			if (dict.ContainsKey("ActionNameOrID".ToUpper()))
			{
				string b = dict["ActionNameOrID".ToUpper()].ToString().ToUpperInvariant();
				if (side != null)
				{
					foreach (SpecialAction value2 in side.SpecialActions.Values)
					{
						if (string.Equals(value2.Name, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.ObjectID, b, StringComparison.OrdinalIgnoreCase))
						{
							specialAction = value2;
							break;
						}
					}
				}
				else
				{
					Side[] sides_ReadOnly2 = ScenarioContext.Sides_ReadOnly;
					foreach (Side side3 in sides_ReadOnly2)
					{
						foreach (SpecialAction value3 in side3.SpecialActions.Values)
						{
							if (string.Equals(value3.Name, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value3.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value3.ObjectID, b, StringComparison.OrdinalIgnoreCase))
							{
								specialAction = value3;
								side = side3;
								break;
							}
						}
					}
				}
				if (Information.IsNothing((object)specialAction))
				{
					throw new LuaError("Unable to identify the desired Special Action!");
				}
				LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
				luaTable3["guid"] = specialAction.ObjectID;
				luaTable3["name"] = specialAction.Name;
				luaTable3["description"] = specialAction.Description;
				luaTable3["isActive"] = specialAction.IsActive;
				luaTable3["IsRepeatable"] = specialAction.IsRepeatable;
				luaTable3["ScriptText"] = specialAction.ScriptText;
				luaTable3["side"] = side.ObjectID;
				return luaTable3;
			}
			throw new LuaError("Missing mandatory variable 'ActionNameOrID'");
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static string ScenEdit_ExecuteSpecialAction(string eventNameOrId, Scenario ScenarioContext)
	{
		string text = eventNameOrId.ToLower();
		SpecialAction specialAction = null;
		Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			foreach (SpecialAction value in side.SpecialActions.Values)
			{
				if (string.Equals(value.Name, text, StringComparison.OrdinalIgnoreCase) || string.Equals(value.Description, text, StringComparison.OrdinalIgnoreCase) || Operators.CompareString(value.ObjectID, text, false) == 0)
				{
					specialAction = value;
				}
			}
		}
		return specialAction?.ScriptText;
	}

	public static object ScenEdit_SetEvent(string eventNameOrId, LuaTable table, Scenario ScenarioContext)
	{
		try
		{
			new HashSet<string>();
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
			string b = eventNameOrId.ToLower();
			string text = "update";
			SimEvent value = null;
			foreach (SimEvent value2 in ScenarioContext.SimEvents.Values)
			{
				if (string.Equals(value2.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.ObjectID, b, StringComparison.OrdinalIgnoreCase))
				{
					value = value2;
				}
			}
			if (dictionary.ContainsKey("mode".ToUpper()))
			{
				text = dictionary["mode".ToUpper()].ToString().ToLower();
			}
			switch (text)
			{
			default:
				throw new LuaError("Unknown operation!");
			case "add":
			case "update":
			case "remove":
				if (Information.IsNothing((object)value) && Operators.CompareString(text, "add", false) != 0)
				{
					throw new LuaError("Unable to identify the desired Event!");
				}
				if (Operators.CompareString(text, "add", false) == 0)
				{
					value = new SimEvent();
					value.Description = eventNameOrId;
				}
				if (dictionary.ContainsKey("NewName".ToUpper()))
				{
					string name;
					try
					{
						name = dictionary["NewName".ToUpper()].ToString();
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						throw new LuaError("Unable to parse value NewName to string!");
					}
					value.Name = name;
				}
				if (dictionary.ContainsKey("Description".ToUpper()))
				{
					string description;
					try
					{
						description = dictionary["Description".ToUpper()].ToString();
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						throw new LuaError("Unable to parse value Description to string!");
					}
					value.Description = description;
				}
				if (dictionary.ContainsKey("IsActive".ToUpper()))
				{
					bool isActive;
					try
					{
						isActive = Conversions.ToBoolean(dictionary["IsActive".ToUpper()].ToString());
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						throw new LuaError("Unable to parse value IsActive to true/false!");
					}
					value.IsActive = isActive;
				}
				if (dictionary.ContainsKey("IsShown".ToUpper()))
				{
					bool isShown;
					try
					{
						isShown = Conversions.ToBoolean(dictionary["IsShown".ToUpper()].ToString());
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						throw new LuaError("Unable to parse value IsShown to true/false!");
					}
					value.IsShown = isShown;
				}
				if (dictionary.ContainsKey("IsRepeatable".ToUpper()))
				{
					bool isRepeatable;
					try
					{
						isRepeatable = Conversions.ToBoolean(dictionary["IsRepeatable".ToUpper()].ToString());
					}
					catch (Exception projectError5)
					{
						ProjectData.SetProjectError(projectError5);
						throw new LuaError("Unable to parse IsRepeatable to true/false!");
					}
					value.IsRepeatable = isRepeatable;
				}
				if (dictionary.ContainsKey("Probability".ToUpper()))
				{
					short result = 0;
					short.TryParse(dictionary["Probability".ToUpper()].ToString(), out result);
					if (result >= 0 && result <= 100)
					{
						value.Probability = result;
					}
				}
				if (Operators.CompareString(text, "add", false) != 0)
				{
					if (Operators.CompareString(text, "remove", false) == 0)
					{
						LuaWrapper_Event result2 = new LuaWrapper_Event(value, 1, xml: true, ScenarioContext);
						ScenarioContext.SimEvents.TryRemove(value.ObjectID, out value);
						return result2;
					}
				}
				else
				{
					ScenarioContext.SimEvents.TryAdd(value.ObjectID, value);
				}
				return ScenEdit_GetEvent(eventNameOrId, 4, ScenarioContext);
			}
		}
		catch (Exception projectError6)
		{
			ProjectData.SetProjectError(projectError6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static object ScenEdit_SetTrigger(LuaTable table, Scenario ScenarioContext)
	{
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_1d5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d62: Expected O, but got Unknown
		//IL_1951: Unknown result type (might be due to invalid IL or missing references)
		//IL_1958: Expected O, but got Unknown
		//IL_1c94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c9b: Expected O, but got Unknown
		//IL_1a98: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9f: Expected O, but got Unknown
		//IL_1af6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1afd: Expected O, but got Unknown
		//IL_179e: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a5: Expected O, but got Unknown
		List<ReferencePoint> myArea = new List<ReferencePoint>();
		try
		{
			HashSet<string> hashSet = new HashSet<string>();
			Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
			dict.Add("TYPEOF", "Trigger");
			if (!dict.ContainsKey("Description".ToUpper()))
			{
				if (!dict.ContainsKey("NAME"))
				{
					throw new LuaError("Missing Trigger Description value!");
				}
				dict["Description".ToUpper()] = RuntimeHelpers.GetObjectValue(dict["NAME"]);
			}
			string text = "update";
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			string text2 = null;
			if (dict.ContainsKey("mode".ToUpper()))
			{
				text = dict["mode".ToUpper()].ToString().ToLower();
			}
			switch (text)
			{
			default:
				throw new LuaError("Unknown operation!");
			case "add":
			case "remove":
			case "update":
			case "list":
			{
				XmlDocument xml = new XmlDocument();
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				EventTrigger theEvent = null;
				switch (text)
				{
				case "update":
				{
					if (dict.ContainsKey("Description".ToUpper()))
					{
						try
						{
							text2 = dict["Description".ToUpper()].ToString();
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							throw new LuaError("Unable to parse event Description!");
						}
						foreach (EventTrigger value in ScenarioContext.EventTriggers.Values)
						{
							if (string.Equals(value.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								theEvent = value;
								break;
							}
						}
					}
					if (theEvent == null)
					{
						throw new LuaError("Trigger not found (" + text2 + ")!");
					}
					Side side = null;
					List<ReferencePoint> list = new List<ReferencePoint>();
					new HashSet<string>();
					_Closure$__10-6 closure$__10-5 = default(_Closure$__10-6);
					_Closure$__10-7 closure$__10-6 = default(_Closure$__10-7);
					_Closure$__10-4 closure$__10-3 = default(_Closure$__10-4);
					_Closure$__10-5 closure$__10-4 = default(_Closure$__10-5);
					_Closure$__10-0 closure$__10-7 = default(_Closure$__10-0);
					_Closure$__10-1 closure$__10-8 = default(_Closure$__10-1);
					_Closure$__10-2 closure$__10- = default(_Closure$__10-2);
					_Closure$__10-3 closure$__10-2 = default(_Closure$__10-3);
					foreach (string key in dict.Keys)
					{
						string string_ = key;
						switch (string_.ToUpperInvariant())
						{
						case "RENAME":
							theEvent.Description = dict["RENAME"].ToString();
							continue;
						case "TYPE":
						case "TYPEOF":
						case "MODE":
						case "DESCRIPTION":
						case "NAME":
							continue;
						}
						string string_2 = "Trigger";
						string string_3 = theEvent.Type.ToString();
						string text3 = smethod_3(ref string_, ref string_2, ref string_3);
						if (text3 != null)
						{
							switch (theEvent.Type)
							{
							case EventTrigger.EventTriggerType.UnitDestroyed:
							{
								EventTrigger_UnitDestroyed eventTrigger_UnitDestroyed = (EventTrigger_UnitDestroyed)theEvent;
								dict[string_].ToString();
								if (Operators.CompareString(text3, "TargetFilter", false) == 0)
								{
									UnitFilterObject unitFilterObject7 = smethod_1(ref dict, ScenarioContext);
									eventTrigger_UnitDestroyed.TargetFilter.TargetSide = unitFilterObject7.TargetSide;
									eventTrigger_UnitDestroyed.TargetFilter.TargetType = unitFilterObject7.TargetType;
									eventTrigger_UnitDestroyed.TargetFilter.TargetSubType = unitFilterObject7.TargetSubType;
									eventTrigger_UnitDestroyed.TargetFilter.SpecificUnitClass = unitFilterObject7.SpecificUnitClass;
									eventTrigger_UnitDestroyed.TargetFilter.SpecificUnitID = unitFilterObject7.SpecificUnitID;
								}
								break;
							}
							case EventTrigger.EventTriggerType.Points:
							{
								EventTrigger_Points eventTrigger_Points = (EventTrigger_Points)theEvent;
								string text10 = dict[string_].ToString();
								switch (text3)
								{
								case "ReachDirection":
									eventTrigger_Points.ReachDirection = (EventTrigger_Points.PointReachDirection)Conversions.ToByte(text10);
									break;
								case "PointValue":
									eventTrigger_Points.PointValue = Conversions.ToInteger(text10);
									break;
								case "SideID":
									side = PrivateMethods.ValidateSide(text10, ScenarioContext);
									if (side != null)
									{
										eventTrigger_Points.SideID = side.ObjectID;
										break;
									}
									throw new LuaError("Error in Action.Points!");
								}
								break;
							}
							case EventTrigger.EventTriggerType.Time:
							{
								EventTrigger_Time eventTrigger_Time = (EventTrigger_Time)theEvent;
								string s2 = dict[string_].ToString();
								if (Operators.CompareString(text3, "Time", false) != 0)
								{
									break;
								}
								long result8 = 0L;
								DateTime result9 = DateTime.MinValue;
								if (!long.TryParse(s2, out result8))
								{
									if (!DateTime.TryParse(s2, out result9))
									{
										throw new LuaError("Error in Trigger.Time!");
									}
									result8 = result9.ToBinary();
								}
								eventTrigger_Time.Time = result9;
								eventTrigger_Time.Fired = false;
								break;
							}
							case EventTrigger.EventTriggerType.UnitDamaged:
							{
								EventTrigger_UnitDamaged eventTrigger_UnitDamaged = (EventTrigger_UnitDamaged)theEvent;
								string text4 = dict[string_].ToString();
								if (Operators.CompareString(text3, "DamagePercent", false) == 0)
								{
									byte b = Conversions.ToByte(text4);
									if (b > 0 && b <= 100)
									{
										eventTrigger_UnitDamaged.DamagePercent = b;
									}
								}
								else if (Operators.CompareString(text3, "TargetFilter", false) == 0)
								{
									UnitFilterObject unitFilterObject = smethod_1(ref dict, ScenarioContext);
									eventTrigger_UnitDamaged.TargetFilter.TargetSide = unitFilterObject.TargetSide;
									eventTrigger_UnitDamaged.TargetFilter.TargetType = unitFilterObject.TargetType;
									eventTrigger_UnitDamaged.TargetFilter.TargetSubType = unitFilterObject.TargetSubType;
									eventTrigger_UnitDamaged.TargetFilter.SpecificUnitClass = unitFilterObject.SpecificUnitClass;
									eventTrigger_UnitDamaged.TargetFilter.SpecificUnitID = unitFilterObject.SpecificUnitID;
								}
								break;
							}
							case EventTrigger.EventTriggerType.UnitRemainsInArea:
							{
								EventTrigger_UnitRemainsInArea eventTrigger_UnitRemainsInArea = (EventTrigger_UnitRemainsInArea)theEvent;
								string text8 = dict[string_].ToString();
								switch (text3)
								{
								case "TD":
								{
									long result5 = 0L;
									if (!long.TryParse(text8, out result5))
									{
										if (Strings.Split(text8, ":", -1, (CompareMethod)0).Count() != 4)
										{
											throw new LuaError("Error in Trigger.RemainsIn TDA");
										}
										eventTrigger_UnitRemainsInArea.TimeDuration = LuaUtility.ParseDateAsSeconds(text8);
									}
									else
									{
										eventTrigger_UnitRemainsInArea.TimeDuration = Conversions.ToLong(text8);
									}
									break;
								}
								case "Area":
								{
									list.Clear();
									side = null;
									List<object> list4 = LuaUtility.ToArray(((LuaTable)dict["AREA"]).GetEnumerator());
									Side[] sides_ReadOnly3 = ScenarioContext.Sides_ReadOnly;
									foreach (Side side4 in sides_ReadOnly3)
									{
										using (List<object>.Enumerator enumerator10 = list4.GetEnumerator())
										{
											while (enumerator10.MoveNext())
											{
												closure$__10-5 = new _Closure$__10-6(closure$__10-5);
												closure$__10-5.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator10.Current);
												if (!Information.IsNothing((object)side4.RefPoints.FirstOrDefault(closure$__10-5._Lambda$__27)))
												{
													side = side4;
													break;
												}
											}
										}
										if (side != null)
										{
											break;
										}
									}
									using (List<object>.Enumerator enumerator11 = list4.GetEnumerator())
									{
										while (enumerator11.MoveNext())
										{
											closure$__10-6 = new _Closure$__10-7(closure$__10-6);
											closure$__10-6.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator11.Current);
											ReferencePoint referencePoint3 = null;
											if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__10-6._Lambda$__28)))
											{
												if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__10-6._Lambda$__30)))
												{
													referencePoint3 = side.RefPoints.First(closure$__10-6._Lambda$__31);
												}
												else if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__10-6._Lambda$__32)))
												{
													if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__10-6._Lambda$__34)))
													{
														referencePoint3 = side.RefPoints.First(closure$__10-6._Lambda$__35);
													}
												}
												else
												{
													referencePoint3 = side.RefPoints.First(closure$__10-6._Lambda$__33);
												}
											}
											else
											{
												referencePoint3 = side.RefPoints.First(closure$__10-6._Lambda$__29);
											}
											if (!Information.IsNothing((object)referencePoint3))
											{
												list.Add(referencePoint3);
												continue;
											}
											throw new LuaError("Error in Trigger.RemainsIn RP!");
										}
									}
									eventTrigger_UnitRemainsInArea.Area = list;
									break;
								}
								case "TargetFilter":
								{
									UnitFilterObject unitFilterObject5 = smethod_1(ref dict, ScenarioContext);
									eventTrigger_UnitRemainsInArea.TargetFilter.TargetSide = unitFilterObject5.TargetSide;
									eventTrigger_UnitRemainsInArea.TargetFilter.TargetType = unitFilterObject5.TargetType;
									eventTrigger_UnitRemainsInArea.TargetFilter.TargetSubType = unitFilterObject5.TargetSubType;
									eventTrigger_UnitRemainsInArea.TargetFilter.SpecificUnitClass = unitFilterObject5.SpecificUnitClass;
									eventTrigger_UnitRemainsInArea.TargetFilter.SpecificUnitID = unitFilterObject5.SpecificUnitID;
									break;
								}
								}
								break;
							}
							case EventTrigger.EventTriggerType.UnitEntersArea:
							{
								EventTrigger_UnitEntersArea eventTrigger_UnitEntersArea = (EventTrigger_UnitEntersArea)theEvent;
								string text7 = dict[string_].ToString();
								switch (text3)
								{
								case "TargetFilter":
								{
									UnitFilterObject unitFilterObject4 = smethod_1(ref dict, ScenarioContext);
									eventTrigger_UnitEntersArea.TargetFilter.TargetSide = unitFilterObject4.TargetSide;
									eventTrigger_UnitEntersArea.TargetFilter.TargetType = unitFilterObject4.TargetType;
									eventTrigger_UnitEntersArea.TargetFilter.TargetSubType = unitFilterObject4.TargetSubType;
									eventTrigger_UnitEntersArea.TargetFilter.SpecificUnitClass = unitFilterObject4.SpecificUnitClass;
									eventTrigger_UnitEntersArea.TargetFilter.SpecificUnitID = unitFilterObject4.SpecificUnitID;
									break;
								}
								case "NOT":
									eventTrigger_UnitEntersArea.Modifier_NOT = Conversions.ToBoolean(text7);
									break;
								case "ExitArea":
									eventTrigger_UnitEntersArea.Modifier_EXIT = Conversions.ToBoolean(text7);
									break;
								case "ETOA":
								case "LTOA":
								{
									long result3 = 0L;
									DateTime result4 = DateTime.MinValue;
									if (!long.TryParse(text7, out result3))
									{
										if (!DateTime.TryParse(text7, out result4))
										{
											throw new LuaError("Error in Trigger.EntersArea TOA!");
										}
										result3 = result4.ToBinary();
									}
									if (Operators.CompareString(text3, "EarliestTime", false) != 0)
									{
										eventTrigger_UnitEntersArea.dateTime_1 = result4;
									}
									else
									{
										eventTrigger_UnitEntersArea.dateTime_0 = result4;
									}
									break;
								}
								case "Area":
								{
									list.Clear();
									side = null;
									List<object> list3 = LuaUtility.ToArray(((LuaTable)dict["AREA"]).GetEnumerator());
									Side[] sides_ReadOnly2 = ScenarioContext.Sides_ReadOnly;
									foreach (Side side3 in sides_ReadOnly2)
									{
										using (List<object>.Enumerator enumerator8 = list3.GetEnumerator())
										{
											while (enumerator8.MoveNext())
											{
												closure$__10-3 = new _Closure$__10-4(closure$__10-3);
												closure$__10-3.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator8.Current);
												if (!Information.IsNothing((object)side3.RefPoints.FirstOrDefault(closure$__10-3._Lambda$__18)))
												{
													side = side3;
													break;
												}
											}
										}
										if (side != null)
										{
											break;
										}
									}
									using (List<object>.Enumerator enumerator9 = list3.GetEnumerator())
									{
										while (enumerator9.MoveNext())
										{
											closure$__10-4 = new _Closure$__10-5(closure$__10-4);
											closure$__10-4.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator9.Current);
											ReferencePoint referencePoint2 = null;
											if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__10-4._Lambda$__19)))
											{
												referencePoint2 = side.RefPoints.First(closure$__10-4._Lambda$__20);
											}
											else if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__10-4._Lambda$__21)))
											{
												referencePoint2 = side.RefPoints.First(closure$__10-4._Lambda$__22);
											}
											else if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__10-4._Lambda$__23)))
											{
												if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__10-4._Lambda$__25)))
												{
													referencePoint2 = side.RefPoints.First(closure$__10-4._Lambda$__26);
												}
											}
											else
											{
												referencePoint2 = side.RefPoints.First(closure$__10-4._Lambda$__24);
											}
											if (!Information.IsNothing((object)referencePoint2))
											{
												list.Add(referencePoint2);
												continue;
											}
											throw new LuaError("Error in Trigger.EntersArea RP!");
										}
									}
									eventTrigger_UnitEntersArea.Area = list;
									break;
								}
								}
								break;
							}
							case EventTrigger.EventTriggerType.RandomTime:
							{
								EventTrigger_RandomTime eventTrigger_RandomTime = (EventTrigger_RandomTime)theEvent;
								string s = dict[string_].ToString();
								int num7;
								if (Operators.CompareString(text3, "EarliestTime", false) == 0)
								{
									num7 = 0;
								}
								else
								{
									if (Operators.CompareString(text3, "LatestTime", false) != 0)
									{
										break;
									}
									num7 = 0;
								}
								long result6 = num7;
								DateTime result7 = DateTime.MinValue;
								if (!long.TryParse(s, out result6))
								{
									if (!DateTime.TryParse(s, out result7))
									{
										throw new LuaError("Error in Trigger.RandomTime!");
									}
									result6 = result7.ToBinary();
								}
								if (Operators.CompareString(text3, "EarliestTime", false) == 0)
								{
									eventTrigger_RandomTime.EarliestTime = result7;
								}
								else
								{
									eventTrigger_RandomTime.LatestTime = result7;
								}
								eventTrigger_RandomTime.Fired = false;
								break;
							}
							case EventTrigger.EventTriggerType.UnitDetected:
							{
								EventTrigger_UnitDetected eventTrigger_UnitDetected = (EventTrigger_UnitDetected)theEvent;
								string text9 = dict[string_].ToString();
								switch (text3)
								{
								case "TargetFilter":
								{
									UnitFilterObject unitFilterObject6 = smethod_1(ref dict, ScenarioContext);
									eventTrigger_UnitDetected.TargetFilter.TargetSide = unitFilterObject6.TargetSide;
									eventTrigger_UnitDetected.TargetFilter.TargetType = unitFilterObject6.TargetType;
									eventTrigger_UnitDetected.TargetFilter.TargetSubType = unitFilterObject6.TargetSubType;
									eventTrigger_UnitDetected.TargetFilter.SpecificUnitClass = unitFilterObject6.SpecificUnitClass;
									eventTrigger_UnitDetected.TargetFilter.SpecificUnitID = unitFilterObject6.SpecificUnitID;
									break;
								}
								case "DetectorSideID":
									side = PrivateMethods.ValidateSide(text9, ScenarioContext);
									if (side != null)
									{
										eventTrigger_UnitDetected.DetectorSideID = side.ObjectID;
										break;
									}
									throw new LuaError("Error in Trigger.UnitDetected Side!");
								case "Area":
								{
									list.Clear();
									side = null;
									List<object> list5 = LuaUtility.ToArray(((LuaTable)dict["AREA"]).GetEnumerator());
									Side[] sides_ReadOnly4 = ScenarioContext.Sides_ReadOnly;
									foreach (Side side5 in sides_ReadOnly4)
									{
										using (List<object>.Enumerator enumerator12 = list5.GetEnumerator())
										{
											while (enumerator12.MoveNext())
											{
												closure$__10-7 = new _Closure$__10-0(closure$__10-7);
												closure$__10-7.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator12.Current);
												if (!Information.IsNothing((object)side5.RefPoints.FirstOrDefault(closure$__10-7._Lambda$__0)))
												{
													side = side5;
													break;
												}
											}
										}
										if (side != null)
										{
											break;
										}
									}
									using (List<object>.Enumerator enumerator13 = list5.GetEnumerator())
									{
										while (enumerator13.MoveNext())
										{
											closure$__10-8 = new _Closure$__10-1(closure$__10-8);
											closure$__10-8.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator13.Current);
											ReferencePoint referencePoint4 = null;
											if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__10-8._Lambda$__1)))
											{
												referencePoint4 = side.RefPoints.First(closure$__10-8._Lambda$__2);
											}
											else if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__10-8._Lambda$__3)))
											{
												referencePoint4 = side.RefPoints.First(closure$__10-8._Lambda$__4);
											}
											else if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__10-8._Lambda$__5)))
											{
												if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__10-8._Lambda$__7)))
												{
													referencePoint4 = side.RefPoints.First(closure$__10-8._Lambda$__8);
												}
											}
											else
											{
												referencePoint4 = side.RefPoints.First(closure$__10-8._Lambda$__6);
											}
											if (!Information.IsNothing((object)referencePoint4))
											{
												list.Add(referencePoint4);
												continue;
											}
											throw new LuaError("Error in Trigger.UnitDetected RP!");
										}
									}
									eventTrigger_UnitDetected.Area = list;
									break;
								}
								case "MCL":
								{
									short[] array4 = (short[])Enum.GetValues(typeof(Contact_Base.IdentificationStatus));
									int num5 = 0;
									while (num5 < array4.Length)
									{
										short num6 = array4[num5];
										if (!string.Equals(text9, num6.ToString(), StringComparison.OrdinalIgnoreCase))
										{
											Contact_Base.IdentificationStatus identificationStatus = (Contact_Base.IdentificationStatus)num6;
											if (!string.Equals(text9, identificationStatus.ToString(), StringComparison.OrdinalIgnoreCase))
											{
												num5 = checked(num5 + 1);
												continue;
											}
										}
										eventTrigger_UnitDetected.MinimumClassificationLevel = (Contact_Base.IdentificationStatus)num6;
										break;
									}
									break;
								}
								}
								break;
							}
							case EventTrigger.EventTriggerType.ScenLoaded:
								dict[string_].ToString();
								break;
							case EventTrigger.EventTriggerType.RegularTime:
							{
								EventTrigger_RegularTime eventTrigger_RegularTime = (EventTrigger_RegularTime)theEvent;
								string a = dict[string_].ToString();
								int[] array2 = (int[])Enum.GetValues(typeof(EventTrigger_RegularTime.RegularTimeInterval));
								if (Operators.CompareString(text3, "Interval", false) != 0)
								{
									break;
								}
								int[] array3 = array2;
								int num3 = 0;
								while (num3 < array3.Length)
								{
									int num4 = array3[num3];
									if (!string.Equals(a, num4.ToString(), StringComparison.OrdinalIgnoreCase))
									{
										EventTrigger_RegularTime.RegularTimeInterval regularTimeInterval = (EventTrigger_RegularTime.RegularTimeInterval)num4;
										if (!string.Equals(a, regularTimeInterval.ToString(), StringComparison.OrdinalIgnoreCase))
										{
											num3 = checked(num3 + 1);
											continue;
										}
									}
									eventTrigger_RegularTime.Interval = (EventTrigger_RegularTime.RegularTimeInterval)num4;
									break;
								}
								break;
							}
							case EventTrigger.EventTriggerType.ScenEnded:
								dict[string_].ToString();
								break;
							case EventTrigger.EventTriggerType.UnitBaseStatus:
							{
								EventTrigger_UnitBaseStatus eventTrigger_UnitBaseStatus = (EventTrigger_UnitBaseStatus)theEvent;
								string text6 = dict[string_].ToString();
								switch (text3)
								{
								case "TargetBase":
									if (PrivateMethods.smethod_1(text6, ScenarioContext) != null)
									{
										eventTrigger_UnitBaseStatus.TargetBase = text6;
									}
									break;
								case "TargetCondition":
									switch (eventTrigger_UnitBaseStatus.TargetFilter.TargetType)
									{
									case GlobalVariables.ActiveUnitType.Ship:
									case GlobalVariables.ActiveUnitType.Submarine:
									{
										if (Enum.TryParse<ActiveUnit_DockingOps._DockingOpsCondition>(text6, out var result2) & Enum.IsDefined(typeof(ActiveUnit_DockingOps._DockingOpsCondition), result2))
										{
											eventTrigger_UnitBaseStatus.TargetCondition = (int)result2;
										}
										break;
									}
									case GlobalVariables.ActiveUnitType.Aircraft:
									{
										if (Enum.TryParse<Aircraft_AirOps._AirOpsCondition>(text6, out var result) & Enum.IsDefined(typeof(Aircraft_AirOps._AirOpsCondition), result))
										{
											eventTrigger_UnitBaseStatus.TargetCondition = (int)result;
										}
										break;
									}
									}
									CMANO.LuaTriggers.AddOpsHandler();
									break;
								case "TargetFilter":
								{
									UnitFilterObject unitFilterObject3 = smethod_1(ref dict, ScenarioContext);
									eventTrigger_UnitBaseStatus.TargetFilter.TargetSide = unitFilterObject3.TargetSide;
									eventTrigger_UnitBaseStatus.TargetFilter.TargetType = unitFilterObject3.TargetType;
									eventTrigger_UnitBaseStatus.TargetFilter.TargetSubType = unitFilterObject3.TargetSubType;
									eventTrigger_UnitBaseStatus.TargetFilter.SpecificUnitClass = unitFilterObject3.SpecificUnitClass;
									eventTrigger_UnitBaseStatus.TargetFilter.SpecificUnitID = unitFilterObject3.SpecificUnitID;
									break;
								}
								}
								break;
							}
							case EventTrigger.EventTriggerType.UnitEmissions:
							{
								EventTrigger_UnitEmissions eventTrigger_UnitEmissions = (EventTrigger_UnitEmissions)theEvent;
								string text5 = dict[string_].ToString();
								switch (text3)
								{
								case "TargetFilter":
								{
									UnitFilterObject unitFilterObject2 = smethod_1(ref dict, ScenarioContext);
									eventTrigger_UnitEmissions.TargetFilter.TargetSide = unitFilterObject2.TargetSide;
									eventTrigger_UnitEmissions.TargetFilter.TargetType = unitFilterObject2.TargetType;
									eventTrigger_UnitEmissions.TargetFilter.TargetSubType = unitFilterObject2.TargetSubType;
									eventTrigger_UnitEmissions.TargetFilter.SpecificUnitClass = unitFilterObject2.SpecificUnitClass;
									eventTrigger_UnitEmissions.TargetFilter.SpecificUnitID = unitFilterObject2.SpecificUnitID;
									break;
								}
								case "MCL":
								{
									short[] array = (short[])Enum.GetValues(typeof(Contact_Base.IdentificationStatus));
									int num = 0;
									while (num < array.Length)
									{
										short num2 = array[num];
										if (!string.Equals(text5, num2.ToString(), StringComparison.OrdinalIgnoreCase))
										{
											Contact_Base.IdentificationStatus identificationStatus = (Contact_Base.IdentificationStatus)num2;
											if (!string.Equals(text5, identificationStatus.ToString(), StringComparison.OrdinalIgnoreCase))
											{
												num = checked(num + 1);
												continue;
											}
										}
										eventTrigger_UnitEmissions.MinimumClassificationLevel = (Contact_Base.IdentificationStatus)num2;
										break;
									}
									break;
								}
								case "Area":
								{
									list.Clear();
									side = null;
									List<object> list2 = LuaUtility.ToArray(((LuaTable)dict["AREA"]).GetEnumerator());
									Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
									foreach (Side side2 in sides_ReadOnly)
									{
										using (List<object>.Enumerator enumerator6 = list2.GetEnumerator())
										{
											while (enumerator6.MoveNext())
											{
												closure$__10- = new _Closure$__10-2(closure$__10-);
												closure$__10-.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator6.Current);
												if (!Information.IsNothing((object)side2.RefPoints.FirstOrDefault(closure$__10-._Lambda$__9)))
												{
													side = side2;
													break;
												}
											}
										}
										if (side != null)
										{
											break;
										}
									}
									using (List<object>.Enumerator enumerator7 = list2.GetEnumerator())
									{
										while (enumerator7.MoveNext())
										{
											closure$__10-2 = new _Closure$__10-3(closure$__10-2);
											closure$__10-2.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator7.Current);
											ReferencePoint referencePoint = null;
											if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__10-2._Lambda$__10)))
											{
												if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__10-2._Lambda$__12)))
												{
													if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__10-2._Lambda$__14)))
													{
														if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__10-2._Lambda$__16)))
														{
															referencePoint = side.RefPoints.First(closure$__10-2._Lambda$__17);
														}
													}
													else
													{
														referencePoint = side.RefPoints.First(closure$__10-2._Lambda$__15);
													}
												}
												else
												{
													referencePoint = side.RefPoints.First(closure$__10-2._Lambda$__13);
												}
											}
											else
											{
												referencePoint = side.RefPoints.First(closure$__10-2._Lambda$__11);
											}
											if (!Information.IsNothing((object)referencePoint))
											{
												list.Add(referencePoint);
												continue;
											}
											throw new LuaError("Error in Trigger.UnitEmissions RP!");
										}
									}
									eventTrigger_UnitEmissions.Area = list;
									break;
								}
								case "DetectorSideID":
									side = PrivateMethods.ValidateSide(text5, ScenarioContext);
									if (side != null)
									{
										eventTrigger_UnitEmissions.DetectorSideID = side.ObjectID;
										break;
									}
									throw new LuaError("Error in Trigger.Unitemissions Side!");
								}
								break;
							}
							case EventTrigger.EventTriggerType.UnitCargoMoved:
							{
								EventTrigger_UnitCargoMoved eventTrigger_UnitCargoMoved = (EventTrigger_UnitCargoMoved)theEvent;
								dict[string_].ToString();
								if (Operators.CompareString(text3, "CargoFilter", false) == 0)
								{
									CargoFilterObject cargoFilterObject = smethod_2(ref dict, ScenarioContext);
									eventTrigger_UnitCargoMoved.TargetFilter.cargoType = cargoFilterObject.cargoType;
									eventTrigger_UnitCargoMoved.TargetFilter.SpecificCargoDBID = cargoFilterObject.SpecificCargoDBID;
									eventTrigger_UnitCargoMoved.TargetFilter.SpecificCargoObjID = cargoFilterObject.SpecificCargoObjID;
									eventTrigger_UnitCargoMoved.TargetFilter.ThresholdReceived = cargoFilterObject.ThresholdReceived;
									eventTrigger_UnitCargoMoved.TargetFilter.ThresholdSent = cargoFilterObject.ThresholdSent;
									eventTrigger_UnitCargoMoved.TargetFilter.Received = cargoFilterObject.Received;
									eventTrigger_UnitCargoMoved.TargetFilter.Sent = cargoFilterObject.Sent;
								}
								break;
							}
							default:
								throw new LuaError("Not implemented yet!");
							}
							continue;
						}
						throw new LuaError("Trigger key not found");
					}
					StringBuilder sb4 = new StringBuilder();
					StringWriter stringWriter4 = new StringWriter(sb4);
					AddUnitToSerialized(ref theEvent, hashSet);
					XmlWriter val4 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter4);
					try
					{
						theEvent.ToXML(val4, hashSet, ScenarioContext);
						val4.Flush();
					}
					finally
					{
						((IDisposable)val4)?.Dispose();
					}
					xml.LoadXml(stringWriter4.ToString());
					goto IL_1b40;
				}
				default:
					throw new LuaError("Unknown operation!");
				case "remove":
				{
					bool flag = false;
					if (dict.ContainsKey("Description".ToUpper()))
					{
						text2 = dict["Description".ToUpper()].ToString();
						foreach (EventTrigger value2 in ScenarioContext.EventTriggers.Values)
						{
							if (!string.Equals(value2.Description, text2, StringComparison.OrdinalIgnoreCase) && !string.Equals(value2.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								continue;
							}
							foreach (SimEvent value3 in ScenarioContext.SimEvents.Values)
							{
								foreach (EventTrigger trigger in value3.Triggers)
								{
									if (Operators.CompareString(trigger.ObjectID, value2.ObjectID, false) == 0)
									{
										flag = true;
										break;
									}
								}
							}
							if (!flag)
							{
								theEvent = value2;
								break;
							}
						}
					}
					if (theEvent == null)
					{
						if (!flag)
						{
							throw new LuaError("Event trigger not found (" + text2 + ")!");
						}
						throw new LuaError("Event trigger in use (" + text2 + ")!");
					}
					StringBuilder sb5 = new StringBuilder();
					StringWriter stringWriter5 = new StringWriter(sb5);
					AddUnitToSerialized(ref theEvent, hashSet);
					XmlWriter val5 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter5);
					try
					{
						theEvent.ToXML(val5, hashSet, ScenarioContext);
						val5.Flush();
					}
					finally
					{
						((IDisposable)val5)?.Dispose();
					}
					xml.LoadXml(stringWriter5.ToString());
					ScenarioContext.EventTriggers.TryRemove(theEvent.ObjectID, out theEvent);
					goto IL_1b40;
				}
				case "add":
					if (dict.ContainsKey("Description".ToUpper()))
					{
						text2 = dict["Description".ToUpper()].ToString();
						foreach (EventTrigger value4 in ScenarioContext.EventTriggers.Values)
						{
							if (string.Equals(value4.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value4.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								throw new LuaError("Existing event trigger (" + text2 + ")!");
							}
						}
					}
					if (!dict.ContainsKey("XML".ToUpper()))
					{
						dict.Add("XML", ((XmlNode)ParseDictToXML(ref dict, ScenarioContext, ref myArea)).OuterXml);
					}
					if (dict.ContainsKey("XML".ToUpper()))
					{
						try
						{
							text2 = dict["XML"].ToString();
							ConcurrentDictionary<string, ScenarioObject> theDictionary = new ConcurrentDictionary<string, ScenarioObject>();
							xml = new XmlDocument();
							xml.LoadXml(text2);
							XmlNode theNode = (XmlNode)(object)xml.DocumentElement;
							theEvent = EventTrigger.FromXML(ref theNode, ref theDictionary, ref ScenarioContext);
							smethod_0(ScenarioContext, ref theEvent, myArea);
							ScenarioContext.EventTriggers.TryAdd(theEvent.ObjectID, theEvent);
							StringBuilder sb3 = new StringBuilder();
							StringWriter stringWriter3 = new StringWriter(sb3);
							AddUnitToSerialized(ref theEvent, hashSet);
							XmlWriter val3 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter3);
							try
							{
								theEvent.ToXML(val3, hashSet, ScenarioContext);
								val3.Flush();
							}
							finally
							{
								((IDisposable)val3)?.Dispose();
							}
							xml.LoadXml(stringWriter3.ToString());
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							throw new LuaError("Unable to parse event XML!");
						}
						goto IL_1b40;
					}
					throw new LuaError("Unable to add trigger (" + text2 + ")!");
				case "list":
					{
						if (dict.ContainsKey("Description".ToUpper()))
						{
							text2 = dict["Description".ToUpper()].ToString();
							foreach (EventTrigger value5 in ScenarioContext.EventTriggers.Values)
							{
								if (string.Equals(value5.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value5.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
								{
									theEvent = value5;
									break;
								}
							}
						}
						LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
						if (theEvent == null)
						{
							foreach (EventTrigger value6 in ScenarioContext.EventTriggers.Values)
							{
								theEvent = value6;
								LuaTable luaTable4 = LuaSandBox.Singleton().CreateTable();
								StringBuilder sb = new StringBuilder();
								StringWriter stringWriter = new StringWriter(sb);
								AddUnitToSerialized(ref theEvent, hashSet);
								XmlWriter val = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter);
								try
								{
									theEvent.ToXML(val, hashSet, ScenarioContext);
									val.Flush();
								}
								finally
								{
									((IDisposable)val)?.Dispose();
								}
								xml.LoadXml(stringWriter.ToString());
								luaTable4["xml"] = xml.InnerXml;
								luaTable4[theEvent.Type.ToString()] = ParseXMLtoTable(ref xml);
								luaTable3[luaTable3.Keys.Count + 1] = luaTable4;
							}
						}
						else
						{
							LuaTable luaTable5 = LuaSandBox.Singleton().CreateTable();
							StringBuilder sb2 = new StringBuilder();
							StringWriter stringWriter2 = new StringWriter(sb2);
							AddUnitToSerialized(ref theEvent, hashSet);
							XmlWriter val2 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter2);
							try
							{
								theEvent.ToXML(val2, hashSet, ScenarioContext);
								val2.Flush();
							}
							finally
							{
								((IDisposable)val2)?.Dispose();
							}
							xml.LoadXml(stringWriter2.ToString());
							luaTable5["xml"] = xml.InnerXml;
							luaTable5[theEvent.Type.ToString()] = ParseXMLtoTable(ref xml);
							luaTable3[luaTable3.Keys.Count + 1] = luaTable5;
						}
						luaTable["triggers"] = luaTable3;
						return luaTable;
					}
					IL_1b40:
					luaTable2["xml"] = xml.InnerXml;
					luaTable2[theEvent.Type.ToString()] = ParseXMLtoTable(ref xml);
					luaTable2["mode"] = text.ToUpper();
					luaTable["triggers"] = luaTable2;
					return luaTable;
				}
			}
			}
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static object ScenEdit_SetCondition(LuaTable table, Scenario ScenarioContext)
	{
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected O, but got Unknown
		//IL_098a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0991: Expected O, but got Unknown
		//IL_09da: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e1: Expected O, but got Unknown
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Expected O, but got Unknown
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0868: Unknown result type (might be due to invalid IL or missing references)
		//IL_086f: Expected O, but got Unknown
		try
		{
			HashSet<string> objectsAlreadySerialized = new HashSet<string>();
			Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
			dict.Add("TYPEOF", "Condition");
			if (!dict.ContainsKey("Description".ToUpper()))
			{
				if (!dict.ContainsKey("NAME"))
				{
					throw new LuaError("Missing Condition Description value!");
				}
				dict["Description".ToUpper()] = RuntimeHelpers.GetObjectValue(dict["NAME"]);
			}
			string text = "update";
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			string text2 = null;
			if (dict.ContainsKey("mode".ToUpper()))
			{
				text = dict["mode".ToUpper()].ToString().ToLower();
			}
			switch (text)
			{
			default:
				throw new LuaError("Unknown operation!");
			case "add":
			case "remove":
			case "update":
			case "list":
			{
				XmlDocument xml = new XmlDocument();
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				EventCondition value = null;
				switch (text)
				{
				case "list":
				{
					if (dict.ContainsKey("Description".ToUpper()))
					{
						text2 = dict["Description".ToUpper()].ToString();
						foreach (EventCondition value2 in ScenarioContext.EventConditions.Values)
						{
							if (string.Equals(value2.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								value = value2;
								break;
							}
						}
					}
					LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
					if (value == null)
					{
						foreach (EventCondition value3 in ScenarioContext.EventConditions.Values)
						{
							LuaTable luaTable4 = LuaSandBox.Singleton().CreateTable();
							StringBuilder sb3 = new StringBuilder();
							StringWriter stringWriter3 = new StringWriter(sb3);
							XmlWriter val3 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter3);
							try
							{
								value3.ToXML(val3, objectsAlreadySerialized, ScenarioContext);
								val3.Flush();
							}
							finally
							{
								((IDisposable)val3)?.Dispose();
							}
							xml.LoadXml(stringWriter3.ToString());
							luaTable4["xml"] = xml.InnerXml;
							luaTable4[value3.Type.ToString()] = ParseXMLtoTable(ref xml);
							luaTable3[luaTable3.Keys.Count + 1] = luaTable4;
						}
					}
					else
					{
						LuaTable luaTable5 = LuaSandBox.Singleton().CreateTable();
						StringBuilder sb4 = new StringBuilder();
						StringWriter stringWriter4 = new StringWriter(sb4);
						XmlWriter val4 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter4);
						try
						{
							value.ToXML(val4, objectsAlreadySerialized, ScenarioContext);
							val4.Flush();
						}
						finally
						{
							((IDisposable)val4)?.Dispose();
						}
						xml.LoadXml(stringWriter4.ToString());
						luaTable5["xml"] = xml.InnerXml;
						luaTable5[value.Type.ToString()] = ParseXMLtoTable(ref xml);
						luaTable3[luaTable3.Keys.Count + 1] = luaTable5;
					}
					luaTable["conditions"] = luaTable3;
					return luaTable;
				}
				case "remove":
				{
					bool flag = false;
					if (dict.ContainsKey("Description".ToUpper()))
					{
						text2 = dict["Description".ToUpper()].ToString();
						foreach (EventCondition value4 in ScenarioContext.EventConditions.Values)
						{
							if (!string.Equals(value4.Description, text2, StringComparison.OrdinalIgnoreCase) && !string.Equals(value4.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								continue;
							}
							foreach (SimEvent value5 in ScenarioContext.SimEvents.Values)
							{
								foreach (EventCondition condition in value5.Conditions)
								{
									if (Operators.CompareString(condition.ObjectID, value4.ObjectID, false) == 0)
									{
										flag = true;
										break;
									}
								}
							}
							if (!flag)
							{
								value = value4;
								break;
							}
						}
					}
					if (value != null)
					{
						StringBuilder sb5 = new StringBuilder();
						StringWriter stringWriter5 = new StringWriter(sb5);
						XmlWriter val5 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter5);
						try
						{
							value.ToXML(val5, objectsAlreadySerialized, ScenarioContext);
							val5.Flush();
						}
						finally
						{
							((IDisposable)val5)?.Dispose();
						}
						xml.LoadXml(stringWriter5.ToString());
						ScenarioContext.EventConditions.TryRemove(value.ObjectID, out value);
						break;
					}
					if (flag)
					{
						throw new LuaError("Event condition in use!");
					}
					throw new LuaError("Event condition not found!");
				}
				case "update":
				{
					if (dict.ContainsKey("Description".ToUpper()))
					{
						try
						{
							text2 = dict["Description".ToUpper()].ToString();
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							throw new LuaError("Unable to parse event Description!");
						}
						foreach (EventCondition value6 in ScenarioContext.EventConditions.Values)
						{
							if (string.Equals(value6.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value6.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								value = value6;
								break;
							}
						}
					}
					if (value == null)
					{
						throw new LuaError("Condition not found");
					}
					Side side = null;
					new List<ReferencePoint>();
					new HashSet<string>();
					foreach (string key in dict.Keys)
					{
						string string_ = key;
						switch (string_.ToUpperInvariant())
						{
						case "RENAME":
							value.Description = dict["RENAME"].ToString();
							break;
						case "TYPE":
						case "TYPEOF":
						case "MODE":
						case "DESCRIPTION":
						case "NAME":
							continue;
						}
						string string_2 = "Condition";
						string string_3 = value.Type.ToString();
						string text3 = smethod_3(ref string_, ref string_2, ref string_3);
						if (text3 != null)
						{
							switch (value.Type)
							{
							case EventCondition.EventConditionType.SidePosture:
							{
								EventCondition_SidePosture eventCondition_SidePosture = (EventCondition_SidePosture)value;
								string text4 = dict[string_].ToString();
								switch (text3)
								{
								case "ObserverSideID":
									side = PrivateMethods.ValidateSide(text4, ScenarioContext);
									if (side != null)
									{
										eventCondition_SidePosture.ObserverSide_ID = side.ObjectID;
										break;
									}
									throw new LuaError("Error in Action.Message!");
								case "TargetPosture":
									eventCondition_SidePosture.TargetPosture = (Misc.PostureStance)Conversions.ToByte(text4);
									break;
								case "NOT":
									eventCondition_SidePosture.Modifier_NOT = Conversions.ToBoolean(text4);
									break;
								case "TargetSideID":
									side = PrivateMethods.ValidateSide(text4, ScenarioContext);
									if (side != null)
									{
										eventCondition_SidePosture.TargetSide_ID = side.ObjectID;
										break;
									}
									throw new LuaError("Error in Action.Message!");
								}
								break;
							}
							case EventCondition.EventConditionType.ScenHasStarted:
							{
								EventCondition_ScenHasStarted eventCondition_ScenHasStarted = (EventCondition_ScenHasStarted)value;
								string text5 = dict[string_].ToString();
								if (Operators.CompareString(text3, "NOT", false) == 0)
								{
									eventCondition_ScenHasStarted.Modifier_NOT = Conversions.ToBoolean(text5);
								}
								break;
							}
							case EventCondition.EventConditionType.LuaScript:
							{
								EventCondition_LuaScript eventCondition_LuaScript = (EventCondition_LuaScript)value;
								dict[string_].ToString();
								if (Operators.CompareString(text3, "ScriptText", false) == 0)
								{
									eventCondition_LuaScript.ScriptText = dict[string_].ToString();
								}
								break;
							}
							default:
								throw new LuaError("Not implemented yet!");
							}
							continue;
						}
						throw new LuaError("Condition key not found");
					}
					StringBuilder sb2 = new StringBuilder();
					StringWriter stringWriter2 = new StringWriter(sb2);
					XmlWriter val2 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter2);
					try
					{
						value.ToXML(val2, objectsAlreadySerialized, ScenarioContext);
						val2.Flush();
					}
					finally
					{
						((IDisposable)val2)?.Dispose();
					}
					xml.LoadXml(stringWriter2.ToString());
					break;
				}
				default:
					throw new LuaError("Unknown operation!");
				case "add":
					if (dict.ContainsKey("Description".ToUpper()))
					{
						text2 = dict["Description".ToUpper()].ToString();
						foreach (EventCondition value7 in ScenarioContext.EventConditions.Values)
						{
							if (string.Equals(value7.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value7.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								throw new LuaError("Existing event condition!");
							}
						}
						Dictionary<string, object> dictionary = dict;
						Scenario scenarioContext = ScenarioContext;
						List<ReferencePoint> myArea = null;
						dictionary.Add("XML", ((XmlNode)ParseDictToXML(ref dict, scenarioContext, ref myArea)).OuterXml);
					}
					if (dict.ContainsKey("XML".ToUpper()))
					{
						try
						{
							text2 = dict["XML".ToUpper()].ToString();
							xml = new XmlDocument();
							xml.LoadXml(text2);
							XmlNode theNode = (XmlNode)(object)xml.DocumentElement;
							ConcurrentDictionary<string, ScenarioObject> theDictionary = null;
							value = EventCondition.FromXML(ref theNode, ref theDictionary, ref ScenarioContext);
							ScenarioContext.EventConditions.TryAdd(value.ObjectID, value);
							StringBuilder sb = new StringBuilder();
							StringWriter stringWriter = new StringWriter(sb);
							XmlWriter val = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter);
							try
							{
								value.ToXML(val, objectsAlreadySerialized, ScenarioContext);
								val.Flush();
							}
							finally
							{
								((IDisposable)val)?.Dispose();
							}
							xml.LoadXml(stringWriter.ToString());
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							throw new LuaError("Unable to parse event XML!");
						}
						break;
					}
					throw new LuaError("Unable to add condition!");
				}
				luaTable2["xml"] = xml.InnerXml;
				luaTable2[value.Type.ToString()] = ParseXMLtoTable(ref xml);
				luaTable2["mode"] = text.ToUpper();
				luaTable["conditions"] = luaTable2;
				return luaTable;
			}
			}
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static object ScenEdit_SetAction(LuaTable table, Scenario ScenarioContext)
	{
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0d96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9d: Expected O, but got Unknown
		//IL_0af1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af8: Expected O, but got Unknown
		//IL_0b41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b48: Expected O, but got Unknown
		//IL_0987: Unknown result type (might be due to invalid IL or missing references)
		//IL_098e: Expected O, but got Unknown
		//IL_0cd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cde: Expected O, but got Unknown
		//IL_081f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0826: Expected O, but got Unknown
		try
		{
			HashSet<string> objectsAlreadySerialized = new HashSet<string>();
			Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
			dict.Add("TYPEOF", "Action");
			if (!dict.ContainsKey("Description".ToUpper()))
			{
				if (!dict.ContainsKey("NAME"))
				{
					throw new LuaError("Missing Action Description value!");
				}
				dict["Description".ToUpper()] = RuntimeHelpers.GetObjectValue(dict["NAME"]);
			}
			string text = "update";
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			string text2 = null;
			if (dict.ContainsKey("mode".ToUpper()))
			{
				text = dict["mode".ToUpper()].ToString().ToLower();
			}
			switch (text)
			{
			default:
				throw new LuaError("Unknown operation!");
			case "add":
			case "remove":
			case "update":
			case "list":
			{
				XmlDocument xml = new XmlDocument();
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				EventAction value = null;
				switch (text)
				{
				default:
					throw new LuaError("Unknown operation!");
				case "update":
				{
					if (dict.ContainsKey("Description".ToUpper()))
					{
						try
						{
							text2 = dict["Description".ToUpper()].ToString();
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							throw new LuaError("Unable to parse event Description!");
						}
						foreach (EventAction value2 in ScenarioContext.EventActions.Values)
						{
							if (string.Equals(value2.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								value = value2;
								break;
							}
						}
					}
					if (value == null)
					{
						throw new LuaError("Action not found (" + text2 + ")!");
					}
					ActiveUnit activeUnit = null;
					Mission mission = null;
					Side side = null;
					List<ReferencePoint> list = new List<ReferencePoint>();
					HashSet<string> hashSet = new HashSet<string>();
					_Closure$__12-0 closure$__12- = default(_Closure$__12-0);
					_Closure$__12-1 closure$__12-2 = default(_Closure$__12-1);
					foreach (string key in dict.Keys)
					{
						string string_ = key;
						switch (string_.ToUpperInvariant())
						{
						case "RENAME":
							value.Description = dict["RENAME"].ToString();
							break;
						case "TYPE":
						case "TYPEOF":
						case "MODE":
						case "DESCRIPTION":
						case "NAME":
							continue;
						}
						string string_2 = "Action";
						string string_3 = value.Type.ToString();
						string text3 = smethod_3(ref string_, ref string_2, ref string_3);
						if (text3 != null)
						{
							switch (value.Type)
							{
							case EventAction.EventActionType.Points:
							{
								EventAction_Points eventAction_Points = (EventAction_Points)value;
								string text4 = dict[string_].ToString();
								if (Operators.CompareString(text3, "SideID", false) == 0)
								{
									side = PrivateMethods.ValidateSide(text4, ScenarioContext);
									if (side == null)
									{
										throw new LuaError("Error in Action.Points!");
									}
									eventAction_Points.SideID = side.ObjectID;
								}
								else if (Operators.CompareString(text3, "PointChange", false) == 0)
								{
									eventAction_Points.PointChange = Conversions.ToInteger(text4);
								}
								break;
							}
							case EventAction.EventActionType.TeleportInArea:
							{
								EventAction_TeleportInArea eventAction_TeleportInArea = (EventAction_TeleportInArea)value;
								if (Operators.CompareString(text3, "UnitIDs", false) != 0)
								{
									if (Operators.CompareString(text3, "Area", false) != 0)
									{
										break;
									}
									list.Clear();
									side = null;
									List<object> list2 = LuaUtility.ToArray(((LuaTable)dict["AREA"]).GetEnumerator());
									Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
									foreach (Side side2 in sides_ReadOnly)
									{
										using (List<object>.Enumerator enumerator9 = list2.GetEnumerator())
										{
											while (enumerator9.MoveNext())
											{
												closure$__12- = new _Closure$__12-0(closure$__12-);
												closure$__12-.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator9.Current);
												if (!Information.IsNothing((object)side2.RefPoints.FirstOrDefault(closure$__12-._Lambda$__0)))
												{
													side = side2;
													break;
												}
											}
										}
										if (side != null)
										{
											break;
										}
									}
									using (List<object>.Enumerator enumerator10 = list2.GetEnumerator())
									{
										while (enumerator10.MoveNext())
										{
											closure$__12-2 = new _Closure$__12-1(closure$__12-2);
											closure$__12-2.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator10.Current);
											ReferencePoint referencePoint = null;
											if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__12-2._Lambda$__1)))
											{
												if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__12-2._Lambda$__3)))
												{
													if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__12-2._Lambda$__5)))
													{
														if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__12-2._Lambda$__7)))
														{
															referencePoint = side.RefPoints.First(closure$__12-2._Lambda$__8);
														}
													}
													else
													{
														referencePoint = side.RefPoints.First(closure$__12-2._Lambda$__6);
													}
												}
												else
												{
													referencePoint = side.RefPoints.First(closure$__12-2._Lambda$__4);
												}
											}
											else
											{
												referencePoint = side.RefPoints.First(closure$__12-2._Lambda$__2);
											}
											if (!Information.IsNothing((object)referencePoint))
											{
												list.Add(referencePoint);
												continue;
											}
											throw new LuaError("Invalid Action RP!");
										}
									}
									eventAction_TeleportInArea.Area = list;
									break;
								}
								hashSet.Clear();
								side = null;
								List<object> list3 = LuaUtility.ToArray(((LuaTable)dict["UNITIDS"]).GetEnumerator());
								foreach (object item in list3)
								{
									activeUnit = PrivateMethods.smethod_1(RuntimeHelpers.GetObjectValue(item).ToString(), ScenarioContext);
									if (activeUnit != null)
									{
										hashSet.Add(activeUnit.ObjectID);
										continue;
									}
									throw new LuaError("Invalid Action UnitID!");
								}
								eventAction_TeleportInArea.UnitIDs = hashSet;
								break;
							}
							case EventAction.EventActionType.Message:
							{
								EventAction_Message eventAction_Message = (EventAction_Message)value;
								string sideName = dict[string_].ToString();
								if (Operators.CompareString(text3, "SideID", false) == 0)
								{
									side = PrivateMethods.ValidateSide(sideName, ScenarioContext);
									if (side == null)
									{
										throw new LuaError("Error in Action.Message!");
									}
									eventAction_Message.SideID = side.ObjectID;
								}
								else if (Operators.CompareString(text3, "Text", false) == 0)
								{
									eventAction_Message.Text = dict[string_].ToString();
								}
								break;
							}
							case EventAction.EventActionType.ChangeMissionStatus:
							{
								EventAction_ChangeMissionStatus eventAction_ChangeMissionStatus = (EventAction_ChangeMissionStatus)value;
								string text5 = dict[string_].ToString();
								if (Operators.CompareString(text3, "MissionID", false) == 0)
								{
									mission = LuaMission.ValidateMissionBySceanrio(text5, ScenarioContext);
									eventAction_ChangeMissionStatus.MissionID = mission.ObjectID;
								}
								else if (Operators.CompareString(text3, "NewStatus", false) == 0)
								{
									eventAction_ChangeMissionStatus.NewStatus = (Mission.MissionStatus)Conversions.ToByte(text5);
								}
								break;
							}
							case EventAction.EventActionType.LuaScript:
							{
								EventAction_LuaScript eventAction_LuaScript = (EventAction_LuaScript)value;
								if (Operators.CompareString(text3, "ScriptText", false) != 0)
								{
									if (Operators.CompareString(text3, "Type", false) == 0)
									{
										eventAction_LuaScript.ScriptForType = (EventAction_LuaScript.EventAction_LuaScript_Type)Enum.Parse(typeof(EventAction_LuaScript.EventAction_LuaScript_Type), dict[string_].ToString(), ignoreCase: true);
									}
								}
								else
								{
									eventAction_LuaScript.ScriptText = dict[string_].ToString();
								}
								break;
							}
							case EventAction.EventActionType.EndScenario:
								break;
							default:
								throw new LuaError("Not implemented yet!");
							}
							continue;
						}
						throw new LuaError("Action key not found");
					}
					StringBuilder sb5 = new StringBuilder();
					StringWriter stringWriter5 = new StringWriter(sb5);
					XmlWriter val5 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter5);
					try
					{
						value.ToXML(val5, objectsAlreadySerialized, ScenarioContext);
						val5.Flush();
					}
					finally
					{
						((IDisposable)val5)?.Dispose();
					}
					xml.LoadXml(stringWriter5.ToString());
					goto IL_0b8b;
				}
				case "remove":
				{
					bool flag = false;
					if (dict.ContainsKey("Description".ToUpper()))
					{
						text2 = dict["Description".ToUpper()].ToString();
						foreach (EventAction value3 in ScenarioContext.EventActions.Values)
						{
							if (!string.Equals(value3.Description, text2, StringComparison.OrdinalIgnoreCase) && !string.Equals(value3.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								continue;
							}
							foreach (SimEvent value4 in ScenarioContext.SimEvents.Values)
							{
								foreach (EventAction action in value4.Actions)
								{
									if (Operators.CompareString(action.ObjectID, value3.ObjectID, false) == 0)
									{
										flag = true;
										break;
									}
								}
							}
							if (!flag)
							{
								value = value3;
								break;
							}
						}
					}
					if (value != null)
					{
						StringBuilder sb4 = new StringBuilder();
						StringWriter stringWriter4 = new StringWriter(sb4);
						XmlWriter val4 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter4);
						try
						{
							value.ToXML(val4, objectsAlreadySerialized, ScenarioContext);
							val4.Flush();
						}
						finally
						{
							((IDisposable)val4)?.Dispose();
						}
						xml.LoadXml(stringWriter4.ToString());
						ScenarioContext.EventActions.TryRemove(value.ObjectID, out value);
						goto IL_0b8b;
					}
					if (flag)
					{
						throw new LuaError("Event action in use (" + text2 + ")!");
					}
					throw new LuaError("Event action not found (" + text2 + ")!");
				}
				case "add":
					if (dict.ContainsKey("Description".ToUpper()))
					{
						text2 = dict["Description".ToUpper()].ToString();
						foreach (EventAction value5 in ScenarioContext.EventActions.Values)
						{
							if (string.Equals(value5.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value5.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								throw new LuaError("Existing event action (" + text2 + ")!");
							}
						}
						Dictionary<string, object> dictionary = dict;
						Scenario scenarioContext = ScenarioContext;
						List<ReferencePoint> myArea = null;
						dictionary.Add("XML", ((XmlNode)ParseDictToXML(ref dict, scenarioContext, ref myArea)).OuterXml);
					}
					if (dict.ContainsKey("XML".ToUpper()))
					{
						try
						{
							text2 = dict["XML".ToUpper()].ToString();
							xml = new XmlDocument();
							xml.LoadXml(text2);
							XmlNode theNode = (XmlNode)(object)xml.DocumentElement;
							ConcurrentDictionary<string, ScenarioObject> theDictionary = null;
							value = EventAction.FromXML(ref theNode, ref theDictionary, ref ScenarioContext);
							ScenarioContext.EventActions.TryAdd(value.ObjectID, value);
							StringBuilder sb3 = new StringBuilder();
							StringWriter stringWriter3 = new StringWriter(sb3);
							XmlWriter val3 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter3);
							try
							{
								value.ToXML(val3, objectsAlreadySerialized, ScenarioContext);
								val3.Flush();
							}
							finally
							{
								((IDisposable)val3)?.Dispose();
							}
							xml.LoadXml(stringWriter3.ToString());
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							throw new LuaError("Unable to parse event XML!");
						}
						goto IL_0b8b;
					}
					throw new LuaError("Unable to add action (" + text2 + ")!");
				case "list":
					{
						if (dict.ContainsKey("Description".ToUpper()))
						{
							text2 = dict["Description".ToUpper()].ToString();
							foreach (EventAction value6 in ScenarioContext.EventActions.Values)
							{
								if (string.Equals(value6.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value6.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
								{
									value = value6;
									break;
								}
							}
						}
						LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
						if (value == null)
						{
							foreach (EventAction value7 in ScenarioContext.EventActions.Values)
							{
								LuaTable luaTable4 = LuaSandBox.Singleton().CreateTable();
								StringBuilder sb = new StringBuilder();
								StringWriter stringWriter = new StringWriter(sb);
								XmlWriter val = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter);
								try
								{
									value7.ToXML(val, objectsAlreadySerialized, ScenarioContext);
									val.Flush();
								}
								finally
								{
									((IDisposable)val)?.Dispose();
								}
								xml.LoadXml(stringWriter.ToString());
								luaTable4["xml"] = xml.InnerXml;
								luaTable4[value7.Type.ToString()] = ParseXMLtoTable(ref xml);
								luaTable3[luaTable3.Keys.Count + 1] = luaTable4;
							}
						}
						else
						{
							LuaTable luaTable5 = LuaSandBox.Singleton().CreateTable();
							StringBuilder sb2 = new StringBuilder();
							StringWriter stringWriter2 = new StringWriter(sb2);
							XmlWriter val2 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter2);
							try
							{
								value.ToXML(val2, objectsAlreadySerialized, ScenarioContext);
								val2.Flush();
							}
							finally
							{
								((IDisposable)val2)?.Dispose();
							}
							xml.LoadXml(stringWriter2.ToString());
							luaTable5["xml"] = xml.InnerXml;
							luaTable5[value.Type.ToString()] = ParseXMLtoTable(ref xml);
							luaTable3[luaTable3.Keys.Count + 1] = luaTable5;
						}
						luaTable["actions"] = luaTable3;
						return luaTable;
					}
					IL_0b8b:
					luaTable2["xml"] = xml.InnerXml;
					luaTable2[value.Type.ToString()] = ParseXMLtoTable(ref xml);
					luaTable2["mode"] = text.ToUpper();
					luaTable["actions"] = luaTable2;
					return luaTable;
				}
			}
			}
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static object ScenEdit_SetEventTrigger(string eventNameOrId, LuaTable table, Scenario ScenarioContext)
	{
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0644: Unknown result type (might be due to invalid IL or missing references)
		//IL_064b: Expected O, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected O, but got Unknown
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0566: Expected O, but got Unknown
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Expected O, but got Unknown
		try
		{
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
			HashSet<string> objectsAlreadySerialized = new HashSet<string>();
			string b = eventNameOrId.ToLower();
			string text = "update";
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			string text2 = null;
			SimEvent simEvent = null;
			foreach (SimEvent value in ScenarioContext.SimEvents.Values)
			{
				if (string.Equals(value.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, b, StringComparison.OrdinalIgnoreCase))
				{
					simEvent = value;
					break;
				}
			}
			if (!Information.IsNothing((object)simEvent))
			{
				if (dictionary.ContainsKey("mode".ToUpper()))
				{
					text = dictionary["mode".ToUpper()].ToString().ToLower();
				}
				switch (text)
				{
				default:
					throw new LuaError("Unknown operation!");
				case "add":
				case "remove":
				case "replace":
				{
					XmlDocument xml = new XmlDocument();
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					EventTrigger eventTrigger = null;
					if (!dictionary.ContainsKey("Description".ToUpper()))
					{
						if (!dictionary.ContainsKey("NAME"))
						{
							throw new LuaError("Missing Trigger Description value!");
						}
						dictionary["Description".ToUpper()] = RuntimeHelpers.GetObjectValue(dictionary["NAME"]);
					}
					switch (text)
					{
					case "remove":
						if (dictionary.ContainsKey("Description".ToUpper()))
						{
							text2 = dictionary["Description".ToUpper()].ToString();
							foreach (EventTrigger value2 in ScenarioContext.EventTriggers.Values)
							{
								if (string.Equals(value2.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
								{
									eventTrigger = value2;
									break;
								}
							}
						}
						if (eventTrigger != null)
						{
							StringBuilder sb3 = new StringBuilder();
							StringWriter stringWriter3 = new StringWriter(sb3);
							XmlWriter val3 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter3);
							try
							{
								eventTrigger.ToXML(val3, objectsAlreadySerialized, ScenarioContext);
								val3.Flush();
							}
							finally
							{
								((IDisposable)val3)?.Dispose();
							}
							xml.LoadXml(stringWriter3.ToString());
							simEvent.Triggers.Remove(eventTrigger);
							break;
						}
						throw new LuaError("Event trigger not found (" + text2 + ")!");
					case "replace":
					{
						if (dictionary.ContainsKey("Description".ToUpper()))
						{
							try
							{
								text2 = dictionary["Description".ToUpper()].ToString();
							}
							catch (Exception projectError2)
							{
								ProjectData.SetProjectError(projectError2);
								throw new LuaError("Unable to parse event Description!");
							}
							foreach (EventTrigger value3 in ScenarioContext.EventTriggers.Values)
							{
								if (string.Equals(value3.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value3.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
								{
									eventTrigger = value3;
									break;
								}
							}
						}
						EventTrigger eventTrigger2 = null;
						if (dictionary.ContainsKey("ReplacedBy".ToUpper()))
						{
							try
							{
								text2 = dictionary["ReplacedBy".ToUpper()].ToString();
							}
							catch (Exception projectError3)
							{
								ProjectData.SetProjectError(projectError3);
								throw new LuaError("Unable to parse event ReplacedBy (" + text2 + ")!");
							}
							foreach (EventTrigger value4 in ScenarioContext.EventTriggers.Values)
							{
								if (string.Equals(value4.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value4.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
								{
									eventTrigger2 = value4;
									break;
								}
							}
						}
						if (eventTrigger != null && eventTrigger2 != null)
						{
							StringBuilder sb4 = new StringBuilder();
							StringWriter stringWriter4 = new StringWriter(sb4);
							XmlWriter val4 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter4);
							try
							{
								eventTrigger.ToXML(val4, objectsAlreadySerialized, ScenarioContext);
								val4.Flush();
							}
							finally
							{
								((IDisposable)val4)?.Dispose();
							}
							xml.LoadXml(stringWriter4.ToString());
							simEvent.Triggers.Remove(eventTrigger);
							simEvent.Triggers.Add(eventTrigger2);
							break;
						}
						throw new LuaError("Trigger not found (" + text2 + ")!");
					}
					default:
						throw new LuaError("Unknown operation!");
					case "update":
					{
						if (dictionary.ContainsKey("Description".ToUpper()))
						{
							try
							{
								text2 = dictionary["Description".ToUpper()].ToString();
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								throw new LuaError("Unable to parse event Description!");
							}
							foreach (EventTrigger value5 in ScenarioContext.EventTriggers.Values)
							{
								if (string.Equals(value5.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value5.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
								{
									eventTrigger = value5;
									break;
								}
							}
						}
						if (eventTrigger == null)
						{
							throw new LuaError("Trigger not found (" + text2 + ")!");
						}
						StringBuilder sb2 = new StringBuilder();
						StringWriter stringWriter2 = new StringWriter(sb2);
						XmlWriter val2 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter2);
						try
						{
							eventTrigger.ToXML(val2, objectsAlreadySerialized, ScenarioContext);
							val2.Flush();
						}
						finally
						{
							((IDisposable)val2)?.Dispose();
						}
						xml.LoadXml(stringWriter2.ToString());
						break;
					}
					case "add":
						if (dictionary.ContainsKey("Description".ToUpper()))
						{
							text2 = dictionary["Description".ToUpper()].ToString();
							foreach (EventTrigger value6 in ScenarioContext.EventTriggers.Values)
							{
								if (string.Equals(value6.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value6.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
								{
									eventTrigger = value6;
									break;
								}
							}
						}
						if (eventTrigger != null)
						{
							simEvent.Triggers.Add(eventTrigger);
							StringBuilder sb = new StringBuilder();
							StringWriter stringWriter = new StringWriter(sb);
							XmlWriter val = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter);
							try
							{
								eventTrigger.ToXML(val, objectsAlreadySerialized, ScenarioContext);
								val.Flush();
							}
							finally
							{
								((IDisposable)val)?.Dispose();
							}
							xml.LoadXml(stringWriter.ToString());
							break;
						}
						throw new LuaError("Event trigger not found (" + text2 + ")!");
					}
					luaTable2["xml"] = xml.InnerXml;
					luaTable2[eventTrigger.Type.ToString()] = ParseXMLtoTable(ref xml);
					luaTable2["mode"] = text.ToUpper();
					luaTable["triggers"] = luaTable2;
					return luaTable;
				}
				}
			}
			throw new LuaError("Unable to identify the desired Event!");
		}
		catch (Exception projectError4)
		{
			ProjectData.SetProjectError(projectError4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static object ScenEdit_SetEventCondition(string eventNameOrId, LuaTable table, Scenario ScenarioContext)
	{
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		//IL_0664: Unknown result type (might be due to invalid IL or missing references)
		//IL_066b: Expected O, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_056e: Expected O, but got Unknown
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Expected O, but got Unknown
		try
		{
			HashSet<string> objectsAlreadySerialized = new HashSet<string>();
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
			string b = eventNameOrId.ToLower();
			string text = "update";
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			string text2 = null;
			SimEvent simEvent = null;
			foreach (SimEvent value in ScenarioContext.SimEvents.Values)
			{
				if (string.Equals(value.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, b, StringComparison.OrdinalIgnoreCase))
				{
					simEvent = value;
				}
			}
			if (Information.IsNothing((object)simEvent))
			{
				throw new LuaError("Unable to identify the desired Event!");
			}
			if (dictionary.ContainsKey("mode".ToUpper()))
			{
				text = dictionary["mode".ToUpper()].ToString().ToLower();
			}
			switch (text)
			{
			default:
				throw new LuaError("Unknown operation!");
			case "add":
			case "remove":
			case "replace":
			{
				XmlDocument xml = new XmlDocument();
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				EventCondition eventCondition = null;
				if (!dictionary.ContainsKey("Description".ToUpper()))
				{
					if (!dictionary.ContainsKey("NAME"))
					{
						throw new LuaError("Missing Condition Description value!");
					}
					dictionary["Description".ToUpper()] = RuntimeHelpers.GetObjectValue(dictionary["NAME"]);
				}
				switch (text)
				{
				case "remove":
				{
					if (dictionary.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary["Description".ToUpper()].ToString();
						foreach (EventCondition value2 in ScenarioContext.EventConditions.Values)
						{
							if (string.Equals(value2.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventCondition = value2;
								break;
							}
						}
					}
					if (eventCondition == null)
					{
						throw new LuaError("Event trigger not found (" + text2 + ")!");
					}
					StringBuilder sb4 = new StringBuilder();
					StringWriter stringWriter4 = new StringWriter(sb4);
					XmlWriter val4 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter4);
					try
					{
						eventCondition.ToXML(val4, objectsAlreadySerialized, ScenarioContext);
						val4.Flush();
					}
					finally
					{
						((IDisposable)val4)?.Dispose();
					}
					xml.LoadXml(stringWriter4.ToString());
					simEvent.Conditions.Remove(eventCondition);
					break;
				}
				case "replace":
				{
					if (dictionary.ContainsKey("Description".ToUpper()))
					{
						try
						{
							text2 = dictionary["Description".ToUpper()].ToString();
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							throw new LuaError("Unable to parse event Description!");
						}
						foreach (EventCondition value3 in ScenarioContext.EventConditions.Values)
						{
							if (string.Equals(value3.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value3.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventCondition = value3;
								break;
							}
						}
					}
					EventCondition eventCondition2 = null;
					if (dictionary.ContainsKey("ReplacedBy".ToUpper()))
					{
						try
						{
							text2 = dictionary["ReplacedBy".ToUpper()].ToString();
						}
						catch (Exception projectError3)
						{
							ProjectData.SetProjectError(projectError3);
							throw new LuaError("Unable to parse event ReplacedBy (" + text2 + ")!");
						}
						foreach (EventCondition value4 in ScenarioContext.EventConditions.Values)
						{
							if (string.Equals(value4.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value4.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventCondition2 = value4;
								break;
							}
						}
					}
					if (eventCondition != null && eventCondition2 != null)
					{
						StringBuilder sb3 = new StringBuilder();
						StringWriter stringWriter3 = new StringWriter(sb3);
						XmlWriter val3 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter3);
						try
						{
							eventCondition.ToXML(val3, objectsAlreadySerialized, ScenarioContext);
							val3.Flush();
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
						xml.LoadXml(stringWriter3.ToString());
						simEvent.Conditions.Remove(eventCondition);
						simEvent.Conditions.Add(eventCondition2);
						break;
					}
					throw new LuaError("Trigger not found (" + text2 + ")!");
				}
				default:
					throw new LuaError("Unknown operation!");
				case "update":
				{
					if (dictionary.ContainsKey("Description".ToUpper()))
					{
						try
						{
							text2 = dictionary["Description".ToUpper()].ToString();
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							throw new LuaError("Unable to parse event Description!");
						}
						foreach (EventCondition value5 in ScenarioContext.EventConditions.Values)
						{
							if (string.Equals(value5.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value5.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventCondition = value5;
								break;
							}
						}
					}
					if (eventCondition == null)
					{
						throw new LuaError("Trigger not found (" + text2 + ")!");
					}
					StringBuilder sb2 = new StringBuilder();
					StringWriter stringWriter2 = new StringWriter(sb2);
					XmlWriter val2 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter2);
					try
					{
						eventCondition.ToXML(val2, objectsAlreadySerialized, ScenarioContext);
						val2.Flush();
					}
					finally
					{
						((IDisposable)val2)?.Dispose();
					}
					xml.LoadXml(stringWriter2.ToString());
					break;
				}
				case "add":
				{
					if (dictionary.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary["Description".ToUpper()].ToString();
						foreach (EventCondition value6 in ScenarioContext.EventConditions.Values)
						{
							if (string.Equals(value6.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value6.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventCondition = value6;
								break;
							}
						}
					}
					if (eventCondition == null)
					{
						throw new LuaError("Event trigger not found (" + text2 + ")!");
					}
					simEvent.Conditions.Add(eventCondition);
					StringBuilder sb = new StringBuilder();
					StringWriter stringWriter = new StringWriter(sb);
					XmlWriter val = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter);
					try
					{
						eventCondition.ToXML(val, objectsAlreadySerialized, ScenarioContext);
						val.Flush();
					}
					finally
					{
						((IDisposable)val)?.Dispose();
					}
					xml.LoadXml(stringWriter.ToString());
					break;
				}
				}
				luaTable2["xml"] = xml.InnerXml;
				luaTable2[eventCondition.Type.ToString()] = ParseXMLtoTable(ref xml);
				luaTable2["mode"] = text.ToUpper();
				luaTable["conditions"] = luaTable2;
				return luaTable;
			}
			}
		}
		catch (Exception projectError4)
		{
			ProjectData.SetProjectError(projectError4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static object ScenEdit_SetEventAction(string eventNameOrId, LuaTable table, Scenario ScenarioContext)
	{
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		//IL_0658: Unknown result type (might be due to invalid IL or missing references)
		//IL_065f: Expected O, but got Unknown
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Expected O, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Expected O, but got Unknown
		try
		{
			HashSet<string> objectsAlreadySerialized = new HashSet<string>();
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
			string b = eventNameOrId.ToLower();
			string text = "update";
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			string text2 = null;
			SimEvent simEvent = null;
			foreach (SimEvent value in ScenarioContext.SimEvents.Values)
			{
				if (string.Equals(value.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, b, StringComparison.OrdinalIgnoreCase))
				{
					simEvent = value;
				}
			}
			if (Information.IsNothing((object)simEvent))
			{
				throw new LuaError("Unable to identify the desired Event!");
			}
			if (dictionary.ContainsKey("mode".ToUpper()))
			{
				text = dictionary["mode".ToUpper()].ToString().ToLower();
			}
			switch (text)
			{
			default:
				throw new LuaError("Unknown operation!");
			case "add":
			case "remove":
			case "replace":
			{
				XmlDocument xml = new XmlDocument();
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				EventAction eventAction = null;
				if (!dictionary.ContainsKey("Description".ToUpper()))
				{
					if (!dictionary.ContainsKey("NAME"))
					{
						throw new LuaError("Missing Action Description value!");
					}
					dictionary["Description".ToUpper()] = RuntimeHelpers.GetObjectValue(dictionary["NAME"]);
				}
				switch (text)
				{
				case "update":
				{
					if (dictionary.ContainsKey("Description".ToUpper()))
					{
						try
						{
							text2 = dictionary["Description".ToUpper()].ToString();
						}
						catch (Exception projectError3)
						{
							ProjectData.SetProjectError(projectError3);
							throw new LuaError("Unable to parse event Description!");
						}
						foreach (EventAction value2 in ScenarioContext.EventActions.Values)
						{
							if (string.Equals(value2.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventAction = value2;
								break;
							}
						}
					}
					if (eventAction == null)
					{
						throw new LuaError("Trigger not found (" + text2 + ")!");
					}
					StringBuilder sb4 = new StringBuilder();
					StringWriter stringWriter4 = new StringWriter(sb4);
					XmlWriter val4 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter4);
					try
					{
						eventAction.ToXML(val4, objectsAlreadySerialized, ScenarioContext);
						val4.Flush();
					}
					finally
					{
						((IDisposable)val4)?.Dispose();
					}
					xml.LoadXml(stringWriter4.ToString());
					break;
				}
				case "replace":
				{
					if (dictionary.ContainsKey("Description".ToUpper()))
					{
						try
						{
							text2 = dictionary["Description".ToUpper()].ToString();
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							throw new LuaError("Unable to parse event Description!");
						}
						foreach (EventAction value3 in ScenarioContext.EventActions.Values)
						{
							if (string.Equals(value3.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value3.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventAction = value3;
								break;
							}
						}
					}
					EventAction eventAction2 = null;
					if (dictionary.ContainsKey("ReplacedBy".ToUpper()))
					{
						try
						{
							text2 = dictionary["ReplacedBy".ToUpper()].ToString();
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							throw new LuaError("Unable to parse event ReplacedBy (" + text2 + ")!");
						}
						foreach (EventAction value4 in ScenarioContext.EventActions.Values)
						{
							if (string.Equals(value4.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value4.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventAction2 = value4;
								break;
							}
						}
					}
					if (eventAction != null && eventAction2 != null)
					{
						StringBuilder sb3 = new StringBuilder();
						StringWriter stringWriter3 = new StringWriter(sb3);
						XmlWriter val3 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter3);
						try
						{
							eventAction.ToXML(val3, objectsAlreadySerialized, ScenarioContext);
							val3.Flush();
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
						xml.LoadXml(stringWriter3.ToString());
						simEvent.Actions.Remove(eventAction);
						simEvent.Actions.Add(eventAction2);
						break;
					}
					throw new LuaError("Trigger not found (" + text2 + ")!");
				}
				default:
					throw new LuaError("Unknown operation!");
				case "remove":
				{
					if (dictionary.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary["Description".ToUpper()].ToString();
						foreach (EventAction value5 in ScenarioContext.EventActions.Values)
						{
							if (string.Equals(value5.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value5.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventAction = value5;
								break;
							}
						}
					}
					if (eventAction == null)
					{
						throw new LuaError("Event trigger not found (" + text2 + ")!");
					}
					StringBuilder sb2 = new StringBuilder();
					StringWriter stringWriter2 = new StringWriter(sb2);
					XmlWriter val2 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter2);
					try
					{
						eventAction.ToXML(val2, objectsAlreadySerialized, ScenarioContext);
						val2.Flush();
					}
					finally
					{
						((IDisposable)val2)?.Dispose();
					}
					xml.LoadXml(stringWriter2.ToString());
					simEvent.Actions.Remove(eventAction);
					break;
				}
				case "add":
					if (dictionary.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary["Description".ToUpper()].ToString();
						foreach (EventAction value6 in ScenarioContext.EventActions.Values)
						{
							if (string.Equals(value6.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value6.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventAction = value6;
								break;
							}
						}
					}
					if (eventAction != null)
					{
						simEvent.Actions.Add(eventAction);
						StringBuilder sb = new StringBuilder();
						StringWriter stringWriter = new StringWriter(sb);
						XmlWriter val = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter);
						try
						{
							eventAction.ToXML(val, objectsAlreadySerialized, ScenarioContext);
							val.Flush();
						}
						finally
						{
							((IDisposable)val)?.Dispose();
						}
						xml.LoadXml(stringWriter.ToString());
						break;
					}
					throw new LuaError("Event trigger not found (" + text2 + ")!");
				}
				luaTable2["xml"] = xml.InnerXml;
				luaTable2[eventAction.Type.ToString()] = ParseXMLtoTable(ref xml);
				luaTable2["mode"] = text.ToUpper();
				luaTable["actions"] = luaTable2;
				return luaTable;
			}
			}
		}
		catch (Exception projectError4)
		{
			ProjectData.SetProjectError(projectError4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static string ToXML_ViaStringBuilder(bool MinifyText, Scenario ScenarioContext)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		StringBuilder sb = new StringBuilder();
		StringWriter stringWriter = new StringWriter(sb);
		XmlTextWriter val = new XmlTextWriter((TextWriter)stringWriter);
		if (!MinifyText)
		{
			val.Formatting = (Formatting)1;
			val.Indentation = 4;
		}
		HashSet<string> objectsAlreadySerialized = new HashSet<string>();
		((XmlWriter)val).WriteStartElement("EventTriggers");
		IEnumerator<EventTrigger> enumerator = ScenarioContext.EventTriggers.Values.GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.ToXML((XmlWriter)(object)val, objectsAlreadySerialized, ScenarioContext);
		}
		val.WriteEndElement();
		((XmlWriter)val).WriteStartElement("EventConditions");
		IEnumerator<EventCondition> enumerator2 = ScenarioContext.EventConditions.Values.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			enumerator2.Current.ToXML((XmlWriter)(object)val, objectsAlreadySerialized, ScenarioContext);
		}
		val.WriteEndElement();
		((XmlWriter)val).WriteStartElement("EventActions");
		IEnumerator<EventAction> enumerator3 = ScenarioContext.EventActions.Values.GetEnumerator();
		while (enumerator3.MoveNext())
		{
			enumerator3.Current.ToXML((XmlWriter)(object)val, objectsAlreadySerialized, ScenarioContext);
		}
		val.WriteEndElement();
		((XmlWriter)val).WriteStartElement("SimEvents");
		IEnumerator<SimEvent> enumerator4 = ScenarioContext.SimEvents.Values.GetEnumerator();
		while (enumerator4.MoveNext())
		{
			enumerator4.Current.ToXML((XmlWriter)(object)val, objectsAlreadySerialized, ScenarioContext);
		}
		val.WriteEndElement();
		Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			if (side.SpecialActions.Any())
			{
				((XmlWriter)val).WriteStartElement("SpecialActions");
				Dictionary<string, SpecialAction>.ValueCollection.Enumerator enumerator5 = side.SpecialActions.Values.GetEnumerator();
				while (enumerator5.MoveNext())
				{
					enumerator5.Current.ToXML((XmlWriter)(object)val, objectsAlreadySerialized, ScenarioContext);
				}
				val.WriteEndElement();
			}
		}
		objectsAlreadySerialized = null;
		return stringWriter.ToString();
	}

	public static LuaTable ParseXMLtoTable(ref XmlDocument xml)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected I4, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		foreach (XmlNode childNode in ((XmlNode)xml.DocumentElement).ChildNodes)
		{
			XmlNode val = childNode;
			XmlNodeType nodeType = val.NodeType;
			switch (nodeType - 1)
			{
			case 0:
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				string name;
				if (val.ChildNodes.Count <= 1)
				{
					name = val.Name;
					luaTable[name] = val.InnerXml;
					break;
				}
				LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
				foreach (XmlNode childNode2 in val.ChildNodes)
				{
					XmlNode val2 = childNode2;
					if (val2.ChildNodes.Count <= 1)
					{
						name = val2.Name;
						luaTable2[name] = val2.InnerXml;
						Information.IsNothing((object)val2.NextSibling);
						continue;
					}
					LuaTable luaTable4 = LuaSandBox.Singleton().CreateTable();
					foreach (XmlNode childNode3 in val2.ChildNodes)
					{
						XmlNode val3 = childNode3;
						name = val3.Name;
						luaTable4[val3.Name] = val3.InnerXml;
						Information.IsNothing((object)val3.NextSibling);
					}
					name = val2.Name;
					foreach (object key in luaTable3.Keys)
					{
						if (RuntimeHelpers.GetObjectValue(key).Equals(name))
						{
							name += luaTable3.Keys.Count;
							break;
						}
					}
					luaTable3[name] = luaTable4;
					luaTable2 = luaTable3;
				}
				name = val.Name;
				luaTable[name] = luaTable2;
				break;
			}
			}
		}
		return luaTable;
	}

	public static XmlDocument ParseDictToXML(ref Dictionary<string, object> dict, Scenario ScenarioContext, [Optional][DefaultParameterValue(null)] ref List<ReferencePoint> myArea)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_0b69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7b: Expected O, but got Unknown
		Side side = null;
		StringBuilder sb = new StringBuilder();
		StringWriter stringWriter = new StringWriter(sb);
		XmlTextWriter val = new XmlTextWriter((TextWriter)stringWriter);
		HashSet<string> ObjectsAlreadySerialized = new HashSet<string>();
		string text = "update";
		string string_ = null;
		string string_2 = null;
		if (dict.ContainsKey("TYPEOF"))
		{
			string_ = Conversions.ToString(dict["TYPEOF"]);
			switch (string_)
			{
			default:
				throw new LuaError("Unknown type of event!");
			case "Trigger":
			case "Condition":
			case "Action":
				break;
			}
		}
		if (dict.ContainsKey("MODE"))
		{
			text = Conversions.ToString(dict["MODE"]);
		}
		if (dict.ContainsKey("TYPE"))
		{
			string_2 = Conversions.ToString(dict["TYPE"]);
		}
		if (string_2 != null)
		{
			if (Operators.CompareString(text, "add", false) == 0)
			{
				if (!dict.ContainsKey("EarliestTime".ToUpperInvariant()))
				{
					dict["EarliestTime".ToUpperInvariant()] = ScenarioContext.StartTime;
				}
				if (!dict.ContainsKey("ETOA".ToUpperInvariant()))
				{
					dict["ETOA".ToUpperInvariant()] = ScenarioContext.StartTime;
				}
				if (!dict.ContainsKey("LatestTime".ToUpperInvariant()))
				{
					dict["LatestTime".ToUpperInvariant()] = ScenarioContext.StartTime + ScenarioContext.Duration;
				}
				if (!dict.ContainsKey("LTOA".ToUpperInvariant()))
				{
					dict["LTOA".ToUpperInvariant()] = ScenarioContext.StartTime + ScenarioContext.Duration;
				}
				if (!dict.ContainsKey("Interval".ToUpperInvariant()))
				{
					dict["Interval".ToUpperInvariant()] = EventTrigger_RegularTime.RegularTimeInterval.OneMinute.ToString();
				}
				if (dict.ContainsKey("ExitArea".ToUpperInvariant()) && string.Equals(Conversions.ToString(dict["ExitArea".ToUpperInvariant()]), "False", StringComparison.OrdinalIgnoreCase))
				{
					dict.Remove("ExitArea".ToUpperInvariant());
				}
				if (dict.ContainsKey("NOT".ToUpperInvariant()) && string.Equals(Conversions.ToString(dict["NOT".ToUpperInvariant()]), "False", StringComparison.OrdinalIgnoreCase))
				{
					dict.Remove("NOT".ToUpperInvariant());
				}
			}
			XmlTextWriter val2 = val;
			try
			{
				List<ReferencePoint> list = new List<ReferencePoint>();
				List<ActiveUnit> list2 = new List<ActiveUnit>();
				string string_3 = "Event" + string_ + "_" + string_2;
				string text2 = smethod_3(ref string_3, ref string_, ref string_2);
				((XmlWriter)val).WriteStartElement(text2);
				_Closure$__18-0 closure$__18- = default(_Closure$__18-0);
				_Closure$__18-1 closure$__18-2 = default(_Closure$__18-1);
				foreach (string key in dict.Keys)
				{
					string string_4 = key;
					switch (string_4.ToLower())
					{
					case "mode":
					case "type":
					case "typeof":
						continue;
					}
					string text3 = smethod_3(ref string_4, ref string_, ref string_2);
					string text4 = null;
					string text5 = text3;
					switch (text5)
					{
					case "Interval":
					{
						text4 = Conversions.ToString(dict[string_4]);
						string text6 = null;
						int[] array = (int[])Enum.GetValues(typeof(EventTrigger_RegularTime.RegularTimeInterval));
						int num = 0;
						while (num < array.Length)
						{
							int num2 = array[num];
							if (!string.Equals(text4, num2.ToString(), StringComparison.OrdinalIgnoreCase))
							{
								string a = text4;
								EventTrigger_RegularTime.RegularTimeInterval regularTimeInterval = (EventTrigger_RegularTime.RegularTimeInterval)num2;
								if (!string.Equals(a, regularTimeInterval.ToString(), StringComparison.OrdinalIgnoreCase))
								{
									num = checked(num + 1);
									continue;
								}
							}
							text6 = Conversions.ToString(num2);
							break;
						}
						if (text6 != null)
						{
							text4 = text6;
							goto IL_0ab3;
						}
						text3 = null;
						throw new LuaError("Can't parse Interval!");
					}
					case "TargetFilter":
					{
						UnitFilterObject unitFilterObject = smethod_1(ref dict, ScenarioContext);
						((XmlWriter)val).WriteStartElement(text3);
						unitFilterObject.ToXML((XmlWriter)(object)val, ObjectsAlreadySerialized, ScenarioContext);
						val.WriteEndElement();
						text3 = null;
						goto IL_0ab3;
					}
					case "MCL":
					{
						string text8 = null;
						text4 = Conversions.ToString(dict[string_4]);
						short[] array3 = (short[])Enum.GetValues(typeof(Contact_Base.IdentificationStatus));
						int num4 = 0;
						while (num4 < array3.Length)
						{
							short num5 = array3[num4];
							if (!string.Equals(text4, num5.ToString(), StringComparison.OrdinalIgnoreCase))
							{
								string a3 = text4;
								Contact_Base.IdentificationStatus identificationStatus = (Contact_Base.IdentificationStatus)num5;
								if (!string.Equals(a3, identificationStatus.ToString(), StringComparison.OrdinalIgnoreCase))
								{
									num4 = checked(num4 + 1);
									continue;
								}
							}
							text8 = Conversions.ToString((int)num5);
							break;
						}
						text4 = ((text8 == null) ? Conversions.ToString(0) : text8);
						goto IL_0ab3;
					}
					case "TD":
					{
						text4 = Conversions.ToString(dict[string_4]);
						long result3 = 0L;
						text4 = ((!long.TryParse(text4, out result3)) ? LuaUtility.ParseDateAsSeconds(text4).ToString() : result3.ToString());
						goto IL_0ab3;
					}
					default:
						if (Operators.CompareString(text5, (string)null, false) != 0)
						{
							text4 = Conversions.ToString(dict[string_4]);
						}
						goto IL_0ab3;
					case "UnitIDs":
					{
						list2.Clear();
						List<object> list4 = LuaUtility.ToArray(((LuaTable)dict["UNITIDS"]).GetEnumerator());
						foreach (object item in list4)
						{
							ActiveUnit activeUnit = PrivateMethods.smethod_1(RuntimeHelpers.GetObjectValue(item).ToString(), ScenarioContext);
							if (!Information.IsNothing((object)activeUnit))
							{
								list2.Add(activeUnit);
								ObjectsAlreadySerialized.Add(activeUnit.ObjectID);
								continue;
							}
							text3 = null;
							break;
						}
						if (text3 != null)
						{
							((XmlWriter)val).WriteStartElement(text3);
							foreach (ActiveUnit item2 in list2)
							{
								XmlWriter theWriter = (XmlWriter)(object)val;
								item2.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
							}
							val.WriteEndElement();
						}
						goto IL_0ab3;
					}
					case "MissionID":
					{
						text4 = Conversions.ToString(dict[string_4]);
						Mission mission = LuaMission.ValidateMissionBySceanrio(text4, ScenarioContext);
						if (mission != null)
						{
							text4 = mission.ObjectID;
							goto IL_0ab3;
						}
						text3 = null;
						throw new LuaError("Can't determine mission!");
					}
					case "TargetPosture":
					{
						text4 = Conversions.ToString(dict[string_4]);
						string text7 = null;
						byte[] array2 = (byte[])Enum.GetValues(typeof(Misc.PostureStance));
						int num3 = 0;
						while (num3 < array2.Length)
						{
							byte b = array2[num3];
							if (!string.Equals(text4, b.ToString(), StringComparison.OrdinalIgnoreCase))
							{
								string a2 = text4;
								Misc.PostureStance postureStance = (Misc.PostureStance)b;
								if (!string.Equals(a2, postureStance.ToString(), StringComparison.OrdinalIgnoreCase))
								{
									num3 = checked(num3 + 1);
									continue;
								}
							}
							text7 = Conversions.ToString(b);
							break;
						}
						text4 = ((text7 == null) ? Conversions.ToString((byte)4) : text7);
						goto IL_0ab3;
					}
					case "SideID":
					case "DetectorSideID":
					case "ObserverSideID":
					case "TargetSideID":
						text4 = Conversions.ToString(dict[string_4]);
						side = PrivateMethods.ValidateSide(text4, ScenarioContext);
						if (side != null)
						{
							text4 = side.ObjectID;
							goto IL_0ab3;
						}
						text3 = null;
						throw new LuaError("Can't determine Side!");
					case "Area":
					{
						list.Clear();
						side = null;
						List<object> list3 = LuaUtility.ToArray(((LuaTable)dict["AREA"]).GetEnumerator());
						Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
						foreach (Side side2 in sides_ReadOnly)
						{
							using (List<object>.Enumerator enumerator2 = list3.GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									closure$__18- = new _Closure$__18-0(closure$__18-);
									closure$__18-.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator2.Current);
									if (!Information.IsNothing((object)side2.RefPoints.FirstOrDefault(closure$__18-._Lambda$__0)))
									{
										side = side2;
										break;
									}
								}
							}
							if (side != null)
							{
								break;
							}
						}
						if (side == null)
						{
							throw new LuaError("Can't determine Side of RPs!");
						}
						using (List<object>.Enumerator enumerator3 = list3.GetEnumerator())
						{
							while (enumerator3.MoveNext())
							{
								closure$__18-2 = new _Closure$__18-1(closure$__18-2);
								closure$__18-2.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator3.Current);
								ReferencePoint referencePoint = null;
								if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__18-2._Lambda$__1)))
								{
									referencePoint = side.RefPoints.First(closure$__18-2._Lambda$__2);
								}
								else if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__18-2._Lambda$__3)))
								{
									if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__18-2._Lambda$__5)))
									{
										referencePoint = side.RefPoints.First(closure$__18-2._Lambda$__6);
									}
									else if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__18-2._Lambda$__7)))
									{
										referencePoint = side.RefPoints.First(closure$__18-2._Lambda$__8);
									}
								}
								else
								{
									referencePoint = side.RefPoints.First(closure$__18-2._Lambda$__4);
								}
								if (!Information.IsNothing((object)referencePoint))
								{
									list.Add(referencePoint);
								}
								else
								{
									text3 = null;
								}
							}
						}
						if (text3 != null)
						{
							((XmlWriter)val).WriteStartElement(text3);
							foreach (ReferencePoint item3 in list)
							{
								val.WriteRaw(item3.ToXML(ref ObjectsAlreadySerialized));
							}
							val.WriteEndElement();
							if (myArea != null)
							{
								myArea = list;
							}
						}
						goto IL_0ab3;
					}
					case "CargoFilter":
					{
						CargoFilterObject cargoFilterObject = smethod_2(ref dict, ScenarioContext);
						((XmlWriter)val).WriteStartElement(text3);
						cargoFilterObject.ToXML((XmlWriter)(object)val, ObjectsAlreadySerialized, ScenarioContext);
						val.WriteEndElement();
						text3 = null;
						goto IL_0ab3;
					}
					case "EarliestTime":
					case "LatestTime":
					case "Time":
					case "ETOA":
					case "LTOA":
						{
							text4 = Conversions.ToString(dict[string_4]);
							long result = 0L;
							DateTime result2 = DateTime.MinValue;
							if (!long.TryParse(text4, out result))
							{
								if (DateTime.TryParse(text4, out result2))
								{
									text4 = result2.ToBinary().ToString();
								}
								else
								{
									text3 = null;
								}
							}
							goto IL_0ab3;
						}
						IL_0ab3:
						if (text3 != null)
						{
							((XmlWriter)val).WriteElementString(text3, text4);
						}
						else if (Operators.CompareString(string_4, "XML".ToUpperInvariant(), false) == 0)
						{
							((XmlWriter)val).WriteElementString(string_4, text4);
						}
						break;
					}
				}
				val.WriteEndElement();
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
			XmlDocument val3 = new XmlDocument();
			val3.LoadXml(stringWriter.ToString());
			return val3;
		}
		throw new LuaError("Unknown subtype of " + string_);
	}

	private static void smethod_0(Scenario scenario_0, ref EventTrigger eventTrigger_0, List<ReferencePoint> list_0)
	{
		List<ReferencePoint> list = null;
		switch (eventTrigger_0.Type)
		{
		default:
			return;
		case EventTrigger.EventTriggerType.UnitEmissions:
			list = ((EventTrigger_UnitEmissions)eventTrigger_0).Area;
			break;
		case EventTrigger.EventTriggerType.UnitEntersArea:
			list = ((EventTrigger_UnitEntersArea)eventTrigger_0).Area;
			break;
		case EventTrigger.EventTriggerType.UnitRemainsInArea:
			list = ((EventTrigger_UnitRemainsInArea)eventTrigger_0).Area;
			break;
		}
		if (list_0 != null)
		{
			list = list_0;
		}
		if (list == null || list.Count == 0)
		{
			return;
		}
		foreach (ReferencePoint item in list)
		{
			if (Operators.CompareString(item._IsRelativeTo_String, "", false) == 0)
			{
				continue;
			}
			if (item.IsRelativeTo == null || Operators.CompareString(item.IsRelativeTo.ObjectID, item._IsRelativeTo_String, false) != 0)
			{
				ActiveUnit activeUnit = PrivateMethods.smethod_1(item._IsRelativeTo_String, scenario_0);
				if (activeUnit != null)
				{
					item.IsRelativeTo = activeUnit;
					item.AdjustForRelativeHooking();
				}
				if (item.IsRelativeTo == null)
				{
					Contact contact = PrivateMethods.ValidateContactBySceanrio(item._IsRelativeTo_String, scenario_0);
					if (contact != null)
					{
						item.IsRelativeTo = contact;
						item.AdjustForRelativeHooking();
					}
				}
				if (item.IsRelativeTo == null)
				{
					Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
					foreach (Side side in sides_ReadOnly)
					{
						foreach (ReferencePoint refPoint in side.RefPoints)
						{
							if (Operators.CompareString(refPoint.ObjectID, item._IsRelativeTo_String, false) == 0)
							{
								item.IsRelativeTo = refPoint;
								item.AdjustForRelativeHooking();
							}
						}
					}
				}
			}
			item._IsRelativeTo_String = "";
		}
		switch (eventTrigger_0.Type)
		{
		case EventTrigger.EventTriggerType.UnitEmissions:
			((EventTrigger_UnitEmissions)eventTrigger_0).Area = list;
			break;
		case EventTrigger.EventTriggerType.UnitEntersArea:
			((EventTrigger_UnitEntersArea)eventTrigger_0).Area = list;
			break;
		case EventTrigger.EventTriggerType.UnitRemainsInArea:
			((EventTrigger_UnitRemainsInArea)eventTrigger_0).Area = list;
			break;
		}
	}

	private static UnitFilterObject smethod_1(ref Dictionary<string, object> dictionary_0, Scenario scenario_0)
	{
		ActiveUnit activeUnit = null;
		Side side = null;
		UnitFilterObject unitFilterObject = new UnitFilterObject();
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)dictionary_0["TARGETFILTER"]).GetEnumerator());
		foreach (string key in dictionary.Keys)
		{
			string text = dictionary[key].ToString();
			switch (key.ToUpperInvariant())
			{
			case "TARGETSIDE":
				side = PrivateMethods.ValidateSide(text, scenario_0);
				if (side != null)
				{
					unitFilterObject.TargetSide = side.ObjectID;
					break;
				}
				throw new LuaError("Error in TargetFilter.Side!");
			case "TARGETTYPE":
			{
				byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
				int num = 0;
				while (num < array.Length)
				{
					byte b = array[num];
					if (!string.Equals(text, b.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						GlobalVariables.ActiveUnitType activeUnitType = (GlobalVariables.ActiveUnitType)b;
						if (!string.Equals(text, activeUnitType.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							num = checked(num + 1);
							continue;
						}
					}
					unitFilterObject.TargetType = (GlobalVariables.ActiveUnitType)b;
					break;
				}
				if (unitFilterObject.TargetType == GlobalVariables.ActiveUnitType.None)
				{
					throw new LuaError("Error in TargetFilter.Type!");
				}
				break;
			}
			case "TARGETSUBTYPE":
				unitFilterObject.TargetSubType = Conversions.ToInteger(text);
				break;
			case "SPECIFICUNITID":
				activeUnit = PrivateMethods.smethod_1(text, scenario_0);
				if (activeUnit != null)
				{
					unitFilterObject.SpecificUnitID = activeUnit.ObjectID;
					break;
				}
				throw new LuaError("Error in TargetFilter.Unit!");
			case "SPECIFICUNITCLASS":
				unitFilterObject.SpecificUnitClass = Conversions.ToInteger(text);
				break;
			}
		}
		if (unitFilterObject.SpecificUnitID == null)
		{
			if (unitFilterObject.TargetSide != null)
			{
				if (unitFilterObject.SpecificUnitClass == 0)
				{
					if (unitFilterObject.TargetSubType != 0 && unitFilterObject.TargetType == GlobalVariables.ActiveUnitType.None)
					{
						throw new LuaError("Error in TargetFilter.SubType!");
					}
				}
				else
				{
					switch (unitFilterObject.TargetType)
					{
					case GlobalVariables.ActiveUnitType.Aircraft:
						unitFilterObject.TargetSubType = DBFunctions.GetAircraftType_Int(ref scenario_0, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Ship:
						unitFilterObject.TargetSubType = DBFunctions.GetShipType_Int(ref scenario_0, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Submarine:
						unitFilterObject.TargetSubType = DBFunctions.GetSubmarineType_Int(ref scenario_0, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Facility:
						unitFilterObject.TargetSubType = DBFunctions.GetFacilityCategory_Int(ref scenario_0, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Weapon:
						unitFilterObject.TargetSubType = DBFunctions.GetWeaponType_Int(ref scenario_0, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Satellite:
						unitFilterObject.TargetSubType = DBFunctions.GetSatelliteType_Int(ref scenario_0, unitFilterObject.SpecificUnitClass);
						break;
					}
					if (unitFilterObject.TargetSubType == 0 || unitFilterObject.TargetType == GlobalVariables.ActiveUnitType.None)
					{
						throw new LuaError("Error in TargetFilter.Class!");
					}
				}
			}
		}
		else
		{
			unitFilterObject.SpecificUnitClass = activeUnit.DBID;
			unitFilterObject.TargetSubType = activeUnit.SubType;
			unitFilterObject.TargetType = activeUnit.UnitType;
			unitFilterObject.TargetSide = activeUnit.get_UnitSide(SetSideOnly: false).ObjectID;
		}
		return unitFilterObject;
	}

	private static CargoFilterObject smethod_2(ref Dictionary<string, object> dictionary_0, object object_0)
	{
		ActiveUnit activeUnit = null;
		CargoFilterObject cargoFilterObject = new CargoFilterObject();
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)dictionary_0["CARGOFILTER"]).GetEnumerator());
		foreach (string key in dictionary.Keys)
		{
			string text = dictionary[key].ToString();
			switch (key.ToUpperInvariant())
			{
			case "SPECIFICUNITID":
				cargoFilterObject.SpecificCargoObjID = activeUnit.ObjectID;
				break;
			case "TARGETLIMITSENT":
				cargoFilterObject.ThresholdSent = Conversions.ToInteger(text);
				break;
			case "TARGETRECEIVED":
				cargoFilterObject.Received = Conversions.ToInteger(text);
				break;
			case "TARGETSENT":
				cargoFilterObject.Sent = Conversions.ToInteger(text);
				break;
			case "TARGETLIMITRECEIVED":
				cargoFilterObject.ThresholdReceived = Conversions.ToInteger(text);
				break;
			case "TARGETTYPE":
			{
				int[] array = (int[])Enum.GetValues(typeof(CargoType));
				int num = 0;
				while (num < array.Length)
				{
					int num2 = array[num];
					if (!string.Equals(text, num2.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						CargoType cargoType = (CargoType)num2;
						if (!string.Equals(text, cargoType.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							num = checked(num + 1);
							continue;
						}
					}
					cargoFilterObject.cargoType = (CargoType)num2;
					break;
				}
				if (cargoFilterObject.cargoType >= CargoType.NoCargo && cargoFilterObject.cargoType <= CargoType.const_5)
				{
					break;
				}
				throw new LuaError("Error in CargoFilter.Type!");
			}
			case "SPECIFICUNITCLASS":
				cargoFilterObject.SpecificCargoDBID = Conversions.ToInteger(text);
				break;
			}
		}
		if (cargoFilterObject.SpecificCargoObjID == null && cargoFilterObject.SpecificCargoDBID == 0 && (cargoFilterObject.cargoType < CargoType.NoCargo || cargoFilterObject.cargoType > CargoType.const_5))
		{
			throw new LuaError("Error in CargoFilter.cargoType!");
		}
		return cargoFilterObject;
	}

	public static void AddUnitToSerialized(ref EventTrigger theEvent, HashSet<string> theList)
	{
		UnitFilterObject unitFilterObject = new UnitFilterObject();
		CargoFilterObject cargoFilterObject = new CargoFilterObject();
		switch (theEvent.Type)
		{
		case EventTrigger.EventTriggerType.UnitDestroyed:
			unitFilterObject = ((EventTrigger_UnitDestroyed)theEvent).TargetFilter;
			if (unitFilterObject.SpecificUnitID != null)
			{
				theList.Add(unitFilterObject.SpecificUnitID);
			}
			break;
		case EventTrigger.EventTriggerType.UnitDamaged:
			unitFilterObject = ((EventTrigger_UnitDamaged)theEvent).TargetFilter;
			if (unitFilterObject.SpecificUnitID != null)
			{
				theList.Add(unitFilterObject.SpecificUnitID);
			}
			break;
		case EventTrigger.EventTriggerType.UnitRemainsInArea:
			unitFilterObject = ((EventTrigger_UnitRemainsInArea)theEvent).TargetFilter;
			if (unitFilterObject.SpecificUnitID != null)
			{
				theList.Add(unitFilterObject.SpecificUnitID);
			}
			break;
		case EventTrigger.EventTriggerType.UnitEntersArea:
			unitFilterObject = ((EventTrigger_UnitEntersArea)theEvent).TargetFilter;
			if (unitFilterObject.SpecificUnitID != null)
			{
				theList.Add(unitFilterObject.SpecificUnitID);
			}
			break;
		case EventTrigger.EventTriggerType.UnitDetected:
			unitFilterObject = ((EventTrigger_UnitDetected)theEvent).TargetFilter;
			if (unitFilterObject.SpecificUnitID != null)
			{
				theList.Add(unitFilterObject.SpecificUnitID);
			}
			break;
		case EventTrigger.EventTriggerType.UnitBaseStatus:
			unitFilterObject = ((EventTrigger_UnitBaseStatus)theEvent).TargetFilter;
			if (unitFilterObject.SpecificUnitID != null)
			{
				theList.Add(unitFilterObject.SpecificUnitID);
			}
			break;
		case EventTrigger.EventTriggerType.UnitEmissions:
			unitFilterObject = ((EventTrigger_UnitEmissions)theEvent).TargetFilter;
			if (unitFilterObject.SpecificUnitID != null)
			{
				theList.Add(unitFilterObject.SpecificUnitID);
			}
			break;
		case EventTrigger.EventTriggerType.UnitCargoMoved:
			cargoFilterObject = ((EventTrigger_UnitCargoMoved)theEvent).TargetFilter;
			if (cargoFilterObject.SpecificCargoObjID != null)
			{
				theList.Add(cargoFilterObject.SpecificCargoObjID);
			}
			break;
		case EventTrigger.EventTriggerType.Points:
		case EventTrigger.EventTriggerType.Time:
		case EventTrigger.EventTriggerType.RandomTime:
		case EventTrigger.EventTriggerType.ScenLoaded:
		case EventTrigger.EventTriggerType.RegularTime:
		case EventTrigger.EventTriggerType.ScenEnded:
			break;
		}
	}

	private static string smethod_3(ref string string_0, ref string string_1, ref string string_2)
	{
		string result = null;
		switch (string_1)
		{
		case "Action":
		{
			string[] array5 = null;
			switch (string_2.ToLower())
			{
			case "luascript":
				array5 = Keyword_Actions_LuaScript;
				break;
			case "message":
				array5 = Keyword_Actions_Message;
				break;
			case "teleportinarea":
				array5 = Keyword_Actions_TeleportInArea;
				break;
			case "points":
				array5 = Keyword_Actions_Points;
				break;
			case "endscenario":
				array5 = Keyword_Actions_EndScenario;
				break;
			case "changemissionstatus":
				array5 = Keyword_Actions_ChangeMissionStatus;
				break;
			}
			string[] array6 = array5;
			foreach (string text3 in array6)
			{
				if (Operators.CompareString(text3.ToUpperInvariant(), string_0.ToUpperInvariant(), false) == 0)
				{
					result = text3;
					break;
				}
			}
			break;
		}
		case "Condition":
		{
			string[] array3 = null;
			switch (string_2.ToLower())
			{
			case "scenhasstarted":
				array3 = Keyword_Conditions_ScenHasStarted;
				break;
			case "sideposture":
				array3 = Keyword_Conditions_SidePosture;
				break;
			case "luascript":
				array3 = Keyword_Conditions_LuaScript;
				break;
			}
			string[] array4 = array3;
			foreach (string text2 in array4)
			{
				if (Operators.CompareString(text2.ToUpperInvariant(), string_0.ToUpperInvariant(), false) == 0)
				{
					result = text2;
					break;
				}
			}
			break;
		}
		case "Trigger":
		{
			string[] array = null;
			switch (string_2.ToLower())
			{
			case "unitbasestatus":
				array = Keyword_Triggers_UnitBaseStatus;
				break;
			case "points":
				array = Keyword_Triggers_Points;
				break;
			case "unitremainsinarea":
				array = Keyword_Triggers_UnitRemainsInArea;
				break;
			case "randomtime":
				array = Keyword_Triggers_RandomTime;
				break;
			case "scenended":
				array = Keyword_Triggers_ScenEnded;
				break;
			case "unitdamaged":
				array = Keyword_Triggers_UnitDamaged;
				break;
			case "scenloaded":
				array = Keyword_Triggers_ScenLoaded;
				break;
			case "unitcargomoved":
				array = Keyword_Triggers_UnitCargoMoved;
				break;
			case "unitentersarea":
				array = Keyword_Triggers_UnitEntersArea;
				break;
			case "unitdestroyed":
				array = Keyword_Triggers_UnitDestroyed;
				break;
			case "regulartime":
				array = Keyword_Triggers_RegularTime;
				break;
			case "time":
				array = Keyword_Triggers_Time;
				break;
			case "unitdetected":
				array = Keyword_Triggers_UnitDetected;
				break;
			case "unitemissions":
				array = Keyword_Triggers_UnitEmissions;
				break;
			case "playerjoinedside":
				array = Keyword_Triggers_PlayerJoinedSide;
				break;
			}
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (Operators.CompareString(text.ToUpperInvariant(), string_0.ToUpperInvariant(), false) == 0)
				{
					result = text;
					break;
				}
			}
			break;
		}
		}
		return result;
	}
}
