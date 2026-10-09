using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotObfuscateType]
[DoNotPrune]
[DoNotPruneType]
public sealed class LuaWrapper_Mission
{
	private Mission mission_0;

	private Scenario scenario_0;

	private Side side_0;

	[DoNotPrune]
	public int PriorityWeight
	{
		get
		{
			return mission_0.PriorityWeight;
		}
		set
		{
			mission_0.PriorityWeight = value;
		}
	}

	[DoNotPrune]
	public string OperationName
	{
		get
		{
			return mission_0.OperationName;
		}
		set
		{
			mission_0.OperationName = value;
		}
	}

	[DoNotPrune]
	public float Completion
	{
		get
		{
			return mission_0.Completion;
		}
		set
		{
			mission_0.Completion = value;
		}
	}

	[DoNotPrune]
	public MissionPhase Phase
	{
		get
		{
			return mission_0.get_Phase(scenario_0, side_0);
		}
		set
		{
			mission_0.set_Phase(scenario_0, side_0, value);
		}
	}

	[DoNotPrune]
	public int MissionStartTrigger_Time
	{
		get
		{
			return mission_0.MissionStartTrigger_Time;
		}
		set
		{
			mission_0.MissionStartTrigger_Time = value;
		}
	}

	[DoNotPrune]
	public bool MissionStartTrigger_Time_Enabled
	{
		get
		{
			return mission_0.MissionStartTrigger_Time_Enabled;
		}
		set
		{
			mission_0.MissionStartTrigger_Time_Enabled = value;
		}
	}

	[DoNotPrune]
	public bool MissionStartTrigger_Time_LastResult => mission_0.MissionStartTrigger_Time_LastResult;

	[DoNotPrune]
	public bool MissionStartTrigger_Time_Operator
	{
		get
		{
			return mission_0.MissionStartTrigger_Time_Operator;
		}
		set
		{
			mission_0.MissionStartTrigger_Time_Operator = value;
		}
	}

	[DoNotPrune]
	public LuaTable MissionStartTrigger_MissionCompleted
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			List<Mission> list = new List<Mission>();
			list = mission_0.MissionStartTrigger_MissionCompleted.Values.ToList();
			int num = 1;
			foreach (Mission item in list)
			{
				luaTable[num] = item.ObjectID;
				num++;
			}
			return luaTable;
		}
		set
		{
			List<object> list = LuaUtility.ToArray(value.GetEnumerator());
			mission_0.MissionStartTrigger_MissionCompleted.Clear();
			foreach (object item in list)
			{
				string text = Conversions.ToString(RuntimeHelpers.GetObjectValue(item));
				Mission mission = LuaMission.ValidateMissionBySceanrio(text, scenario_0);
				if (mission != null && Operators.CompareString(mission.ObjectID, text, false) == 0 && !mission_0.MissionStartTrigger_MissionCompleted.ContainsKey(mission))
				{
					mission_0.MissionStartTrigger_MissionCompleted.Add(mission, mission);
				}
			}
		}
	}

	[DoNotPrune]
	public bool MissionStartTrigger_MissionCompleted_Enabled
	{
		get
		{
			return mission_0.MissionStartTrigger_MissionCompleted_Enabled;
		}
		set
		{
			mission_0.MissionStartTrigger_MissionCompleted_Enabled = value;
		}
	}

	[DoNotPrune]
	public bool MissionStartTrigger_MissionCompleted_LastResult => mission_0.MissionStartTrigger_MissionCompleted_LastResult;

	[DoNotPrune]
	public bool MissionStartTrigger_MissionCompleted_Operator
	{
		get
		{
			return mission_0.MissionStartTrigger_MissionCompleted_Operator;
		}
		set
		{
			mission_0.MissionStartTrigger_MissionCompleted_Operator = value;
		}
	}

	[DoNotPrune]
	public string MissionStartTrigger_LUADescription
	{
		get
		{
			return mission_0.MissionStartTrigger_LUADescription;
		}
		set
		{
			mission_0.MissionStartTrigger_LUADescription = value;
		}
	}

	[DoNotPrune]
	public string MissionStartTrigger_LUA
	{
		get
		{
			return mission_0.MissionStartTrigger_LUA;
		}
		set
		{
			mission_0.MissionStartTrigger_LUA = value;
		}
	}

	[DoNotPrune]
	public bool MissionStartTrigger_LUA_Enabled
	{
		get
		{
			return mission_0.MissionStartTrigger_LUA_Enabled;
		}
		set
		{
			mission_0.MissionStartTrigger_LUA_Enabled = value;
		}
	}

	[DoNotPrune]
	public bool MissionStartTrigger_LUA_LastResult => mission_0.MissionStartTrigger_LUA_LastResult;

	[DoNotPrune]
	public bool MissionStartTrigger_LUA_Operator
	{
		get
		{
			return mission_0.MissionStartTrigger_LUA_Operator;
		}
		set
		{
			mission_0.MissionStartTrigger_LUA_Operator = value;
		}
	}

	[DoNotPrune]
	public int MissionCompletedTrigger_ElapsedTime
	{
		get
		{
			return (int)Math.Round(mission_0.MissionCompletedTrigger_ElapsedTime);
		}
		set
		{
			mission_0.MissionCompletedTrigger_ElapsedTime = value;
		}
	}

	[DoNotPrune]
	public int MissionCompletedTrigger_ElapsedTime_Current
	{
		get
		{
			return (int)Math.Round(mission_0.MissionCompletedTrigger_ElapsedTime_Current);
		}
		set
		{
			mission_0.MissionCompletedTrigger_ElapsedTime_Current = value;
		}
	}

	[DoNotPrune]
	public bool MissionCompletedTrigger_ElapsedTime_Enabled
	{
		get
		{
			return mission_0.MissionCompletedTrigger_ElapsedTime_Enabled;
		}
		set
		{
			mission_0.MissionCompletedTrigger_ElapsedTime_Enabled = value;
		}
	}

	[DoNotPrune]
	public bool MissionCompletedTrigger_ElapsedTime_LastResult => mission_0.MissionCompletedTrigger_ElapsedTime_LastResult;

	[DoNotPrune]
	public bool MissionCompletedTrigger_ElapsedTime_Operator
	{
		get
		{
			return mission_0.MissionCompletedTrigger_ElapsedTime_Operator;
		}
		set
		{
			mission_0.MissionCompletedTrigger_ElapsedTime_Operator = value;
		}
	}

	[DoNotPrune]
	public string MissionCompletedTrigger_LUADescription
	{
		get
		{
			return mission_0.MissionCompletedTrigger_LUADescription;
		}
		set
		{
			mission_0.MissionCompletedTrigger_LUADescription = value;
		}
	}

	[DoNotPrune]
	public string MissionCompletedTrigger_LUA
	{
		get
		{
			return mission_0.MissionCompletedTrigger_LUA;
		}
		set
		{
			mission_0.MissionCompletedTrigger_LUA = value;
		}
	}

	[DoNotPrune]
	public bool MissionCompletedTrigger_LUA_Enabled
	{
		get
		{
			return mission_0.MissionCompletedTrigger_LUA_Enabled;
		}
		set
		{
			mission_0.MissionCompletedTrigger_LUA_Enabled = value;
		}
	}

	[DoNotPrune]
	public bool MissionCompletedTrigger_LUA_LastResult => mission_0.MissionCompletedTrigger_LUA_LastResult;

	[DoNotPrune]
	public bool MissionCompletedTrigger_LUA_Operator
	{
		get
		{
			return mission_0.MissionCompletedTrigger_LUA_Operator;
		}
		set
		{
			mission_0.MissionCompletedTrigger_LUA_Operator = value;
		}
	}

	[DoNotPrune]
	public int EstimatedExecutionTime => mission_0.EstimatedExecutionTime;

	public object fields
	{
		get
		{
			Type obj = GetType();
			int num = 0;
			PropertyInfo[] properties = obj.GetProperties();
			MethodInfo[] methods = obj.GetMethods();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				if (propertyInfo.Name.StartsWith("__") || propertyInfo.Name.StartsWith("fields"))
				{
					continue;
				}
				string text = "";
				bool flag = false;
				if (propertyInfo.MemberType == MemberTypes.Method)
				{
					text = ":";
				}
				else if (propertyInfo.MemberType == MemberTypes.Property)
				{
					text = ".";
				}
				MethodInfo[] array2 = methods;
				foreach (MethodInfo obj2 in array2)
				{
					string text2 = "set_" + propertyInfo.Name;
					if (Operators.CompareString(obj2.Name, text2, false) == 0)
					{
						flag = true;
					}
				}
				num++;
				dictionary.Add("property_" + num, text + propertyInfo.Name + " , " + propertyInfo.PropertyType.Name + " , " + flag + " , " + propertyInfo.CanRead);
			}
			num = 0;
			MethodInfo[] array3 = methods;
			foreach (MethodInfo methodInfo in array3)
			{
				if (!methodInfo.Name.StartsWith("get_") && !methodInfo.Name.StartsWith("set_") && !methodInfo.Name.StartsWith("ToString") && !methodInfo.IsHideBySig)
				{
					string text3 = "";
					if (methodInfo.MemberType == MemberTypes.Method)
					{
						text3 = ":";
					}
					else if (methodInfo.MemberType == MemberTypes.Property)
					{
						text3 = ".";
					}
					num++;
					dictionary.Add("method_" + num, text3 + methodInfo.Name + " , " + methodInfo.ReturnType.ToString());
				}
			}
			if (dictionary.Count != 0)
			{
				LuaUtility.FromDict(dictionary, luaTable);
				return luaTable;
			}
			return null;
		}
	}

	[DoNotPrune]
	public LuaWrapper_Doctrine doctrine
	{
		get
		{
			if (mission_0.Doctrine != null)
			{
				return new LuaWrapper_Doctrine(mission_0.Doctrine, scenario_0);
			}
			return null;
		}
	}

	[DoNotPrune]
	public object __obj => mission_0;

	[DoNotPrune]
	public string guid => mission_0.ObjectID;

	[DoNotPrune]
	public string name
	{
		get
		{
			return mission_0.Name;
		}
		set
		{
			mission_0.Name = value;
		}
	}

	[DoNotPrune]
	public object isactive
	{
		get
		{
			return mission_0.get_Status(scenario_0) == Mission.MissionStatus.Active;
		}
		set
		{
			try
			{
				bool? flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value));
				if (flag.HasValue)
				{
					bool? flag2 = flag;
					flag2 = flag2;
					if (flag2 == true)
					{
						mission_0.set_Status(scenario_0, Mission.MissionStatus.Active);
					}
					else
					{
						mission_0.set_Status(scenario_0, Mission.MissionStatus.Inactive);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new LuaError(ex2.Message);
			}
		}
	}

	[DoNotPrune]
	public string side => side_0.Name;

	[DoNotPrune]
	public string endtime
	{
		get
		{
			return mission_0.EndTime.ToString();
		}
		set
		{
			try
			{
				if (value.Length <= 0)
				{
					mission_0.EndTime_Set(null, scenario_0);
				}
				else
				{
					mission_0.EndTime_Set(LuaUtility.ParseDateTime_String(value, LuaUtility.DateFormat.DDMMYYYY), scenario_0);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public bool OnDeactivateUnassign
	{
		get
		{
			return mission_0.Deactivation_UnassignUnits;
		}
		set
		{
			try
			{
				mission_0.Deactivation_UnassignUnits = LuaUtility.ParseBoolean(value).Value;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public bool OnDeactivateRTB
	{
		get
		{
			return mission_0.Deactivation_OrderRTB;
		}
		set
		{
			try
			{
				mission_0.Deactivation_OrderRTB = LuaUtility.ParseBoolean(value).Value;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public bool OnDeactivateDelete
	{
		get
		{
			return mission_0.Deactivation_DeleteMission;
		}
		set
		{
			try
			{
				mission_0.Deactivation_DeleteMission = LuaUtility.ParseBoolean(value).Value;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public string starttime
	{
		get
		{
			return mission_0.StartTime.ToString();
		}
		set
		{
			try
			{
				if (value.Length <= 0)
				{
					mission_0.StartTime_Set(null, scenario_0);
				}
				else
				{
					mission_0.StartTime_Set(LuaUtility.ParseDateTime_String(value, LuaUtility.DateFormat.DDMMYYYY), scenario_0);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public Mission._MissionClass type => mission_0.MissionClass;

	[DoNotPrune]
	public string typeS => mission_0.MissionClass.ToString();

	[DoNotPrune]
	public object subtype
	{
		get
		{
			return mission_0.get_DescriptionString(scenario_0);
		}
		set
		{
			throw new LuaError("Cannot set this property. Please use ScenEdit_Set.");
		}
	}

	[DoNotPrune]
	public object SISH
	{
		get
		{
			return mission_0.ScrubIfSideIsHuman;
		}
		set
		{
			mission_0.ScrubIfSideIsHuman = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value)).Value;
		}
	}

	[DoNotPrune]
	public object __mission => mission_0;

	[DoNotPrune]
	public LuaTable unitlist
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			List<ActiveUnit> list = new List<ActiveUnit>();
			list = Module_Mission.UnitsAssignedToMissionOrPackage(mission_0, scenario_0);
			int num = 1;
			foreach (ActiveUnit item in list)
			{
				luaTable[num] = item.ObjectID;
				num++;
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property. Please use ScenEdit_Set.");
		}
	}

	[DoNotPrune]
	public LuaTable targetlist
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (mission_0.MissionClass == Mission._MissionClass.Strike)
			{
				IReadOnlyCollection<Module_Unit.Unit> specificTargets = ((Strike)mission_0).SpecificTargets;
				int num = 1;
				foreach (Module_Unit.Unit item in specificTargets)
				{
					luaTable[num] = item.ObjectID;
					num++;
				}
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property. Please use ScenEdit_AssignUnitAsTarget.");
		}
	}

	[DoNotPrune]
	public LuaTable aar
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = null;
			useUnderwayRefuelAndReplenishment = mission_0.Doctrine.get_UseReplenishment(scenario_0, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
			if (useUnderwayRefuelAndReplenishment.HasValue)
			{
				luaTable["Doctrine_UseReplenishment"] = useUnderwayRefuelAndReplenishment.ToString();
			}
			string[] mission_Tanker = LuaMission.Mission_Tanker;
			foreach (string text in mission_Tanker)
			{
				switch (text)
				{
				case "MaxReceiversInQueuePerTanker_Airborne":
					luaTable[text] = mission_0.MaxReceiversInQueuePerTanker_Airborne;
					break;
				case "TankerFollowsReceivers":
					luaTable[text] = mission_0.TankerFollowsReceivers;
					break;
				case "TankerUsage":
					luaTable[text] = mission_0.TankerUsage.ToString();
					break;
				case "KeepOnMissionWithoutTankersInPlace":
					luaTable[text] = mission_0.KeepOnMissionWithoutTankersInPlace;
					break;
				case "TankerMissionList":
				{
					if (mission_0.TankerUsage != Mission.TankerMethod.Mission)
					{
						break;
					}
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					foreach (Mission tankerMission in mission_0.TankerMissions)
					{
						luaTable2[1] = tankerMission.Name;
					}
					luaTable[text] = luaTable2;
					break;
				}
				case "FuelQtyToStartLookingForTanker_Airborne":
					luaTable[text] = mission_0.FuelQtyToStartLookingForTanker_Airborne;
					break;
				case "TankerMaxDistance_Airborne":
					if (mission_0.TankerMaxDistance_Airborne >= 1000)
					{
						luaTable[text] = "internal";
					}
					else
					{
						luaTable[text] = mission_0.TankerMaxDistance_Airborne;
					}
					break;
				case "TankerMinNumber_Airborne":
					if (mission_0.TankerUsage == Mission.TankerMethod.Mission)
					{
						luaTable[text] = mission_0.TankerMinNumber_Airborne;
					}
					break;
				case "TankerMinNumber_Station":
					if (mission_0.TankerUsage == Mission.TankerMethod.Mission)
					{
						luaTable[text] = mission_0.TankerMinNumber_Station;
					}
					break;
				case "TankerMinNumber_Total":
					if (mission_0.TankerUsage == Mission.TankerMethod.Mission)
					{
						luaTable[text] = mission_0.TankerMinNumber_Total;
					}
					break;
				case "LaunchMissionWithoutTankersInPlace":
					luaTable[text] = mission_0.LaunchMissionWithoutTankersInPlace;
					break;
				}
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property. Please use ScenEdit_SetMission().");
		}
	}

	[DoNotPrune]
	public LuaTable ferrymission
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (mission_0.MissionClass == Mission._MissionClass.Ferry)
			{
				FerryMission ferryMission = (FerryMission)mission_0;
				string[] mission_Ferry = LuaMission.Mission_Ferry;
				foreach (string text in mission_Ferry)
				{
					switch (text)
					{
					case "FerryAltitudeAircraft":
						luaTable[text] = ferryMission.FerryAltitude_Aircraft.ToString();
						break;
					case "MinAircraftReq":
						luaTable[text] = ferryMission.MinimumNumberOfAircraft.ToString();
						break;
					case "FerryThrottleAircraft":
						luaTable[text] = ferryMission.FerryThrottle_Aircraft.ToString();
						break;
					case "FlightSize":
						luaTable[text] = ferryMission.FlightSize.ToString();
						break;
					case "FerryTerrainFollowingAircraft":
						ferryMission.FerryTerrainFollowing_Aircraft.ToString();
						break;
					case "FerryBehavior":
						luaTable[text] = ferryMission.Behavior.ToString();
						break;
					case "UseFlightSize":
						luaTable[text] = ferryMission.UseFlightSizeHardLimit.ToString();
						break;
					}
				}
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property. Please use ScenEdit_SetMission().");
		}
	}

	[DoNotPrune]
	public LuaTable mineclearmission
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (mission_0.MissionClass == Mission._MissionClass.MineClearing)
			{
				MineClearingMission mineClearingMission = (MineClearingMission)mission_0;
				string[] mission_MineClearing = LuaMission.Mission_MineClearing;
				foreach (string text in mission_MineClearing)
				{
					switch (text)
					{
					case "GroupSize":
						luaTable[text] = mineClearingMission.GroupSize.ToString();
						break;
					case "MinAircraftReq":
						luaTable[text] = mineClearingMission.MinimumNumberOfAircraft.ToString();
						break;
					case "TransitThrottleAircraft":
						luaTable[text] = mineClearingMission.TransitThrottle_Aircraft;
						break;
					case "TransitTerrainFollowingAircraft":
						luaTable[text] = mineClearingMission.TransitTerrainFollowing_Aircraft;
						break;
					case "usestationaltitudepreset":
						luaTable[text] = mineClearingMission.UseStationAltitude_Preset;
						break;
					case "StationThrottleAircraft":
						luaTable[text] = mineClearingMission.StationThrottle_Aircraft;
						break;
					case "TransitDepthSubmarine":
						luaTable[text] = mineClearingMission.TransitDepth_Submarine;
						break;
					case "Zone":
					{
						LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
						int num = 1;
						foreach (ReferencePoint item in mineClearingMission.Area)
						{
							LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
							luaTable3["name"] = item.Name;
							luaTable2[num] = luaTable3;
							num++;
						}
						luaTable[text] = luaTable2;
						break;
					}
					case "transitaltitudepreset":
						luaTable[text] = mineClearingMission.TransitAltitude_Preset;
						break;
					case "StationThrottleSubmarine":
						luaTable[text] = mineClearingMission.StationThrottle_Submarine;
						break;
					case "transitdepthsubmarinepreset":
						luaTable[text] = mineClearingMission.TransitDepth_Submarine_Preset;
						break;
					case "TransitThrottleShip":
						luaTable[text] = mineClearingMission.TransitThrottle_Ship;
						break;
					case "transitdepthsubmarinepresetuse":
						luaTable[text] = mineClearingMission.UseTransitDepth_Submarine_Preset;
						break;
					case "FlightSize":
						luaTable[text] = mineClearingMission.FlightSize.ToString();
						break;
					case "UseGroupSize":
						luaTable[text] = mineClearingMission.UseGroupSizeHardLimit;
						break;
					case "StationAltitudeAircraft":
						luaTable[text] = mineClearingMission.StationAltitude_Aircraft;
						break;
					case "stationdepthsubmarinepreset":
						luaTable[text] = mineClearingMission.StationDepth_Submarine_Preset;
						break;
					case "TransitAltitudeAircraft":
						luaTable[text] = mineClearingMission.TransitAltitude_Aircraft;
						break;
					case "StationTerrainFollowingAircraft":
						luaTable[text] = mineClearingMission.StationTerrainFollowing_Aircraft;
						break;
					case "StationThrottleShip":
						luaTable[text] = mineClearingMission.StationThrottle_Ship;
						break;
					case "stationdepthsubmarinepresetuse":
						luaTable[text] = mineClearingMission.UseStationDepth_Submarine_Preset;
						break;
					case "StationDepthSubmarine":
						luaTable[text] = mineClearingMission.StationDepth_Submarine;
						break;
					case "UseFlightSize":
						luaTable[text] = mineClearingMission.UseFlightSizeHardLimit;
						break;
					case "stationaltitudepreset":
						luaTable[text] = mineClearingMission.StationAltitude_Preset;
						break;
					case "LoopType":
						luaTable[text] = mineClearingMission.MovementStyle;
						break;
					case "TransitThrottleSubmarine":
						luaTable[text] = mineClearingMission.TransitThrottle_Submarine;
						break;
					case "usetransitaltitudepreset":
						luaTable[text] = mineClearingMission.UseTransitAltitude_Preset;
						break;
					case "OneThirdRule":
						luaTable[text] = mineClearingMission.OneThirdRule;
						break;
					}
				}
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property. Please use ScenEdit_SetMission().");
		}
	}

	[DoNotPrune]
	public LuaTable minemission
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (mission_0.MissionClass == Mission._MissionClass.Mining)
			{
				MiningMission miningMission = (MiningMission)mission_0;
				string[] mission_Mining = LuaMission.Mission_Mining;
				foreach (string text in mission_Mining)
				{
					switch (text)
					{
					case "StationDepthSubmarine":
						luaTable[text] = miningMission.StationDepth_Submarine;
						break;
					case "UseFlightSize":
						luaTable[text] = miningMission.UseFlightSizeHardLimit;
						break;
					case "stationaltitudepreset":
						luaTable[text] = miningMission.StationAltitude_Preset;
						break;
					case "OneThirdRule":
						luaTable[text] = miningMission.OneThirdRule;
						break;
					case "TransitThrottleSubmarine":
						luaTable[text] = miningMission.TransitThrottle_Submarine;
						break;
					case "stationdepthsubmarinepreset":
						luaTable[text] = miningMission.StationDepth_Submarine_Preset;
						break;
					case "usetransitaltitudepreset":
						luaTable[text] = miningMission.UseTransitAltitude_Preset;
						break;
					case "StationTerrainFollowingAircraft":
						luaTable[text] = miningMission.StationTerrainFollowing_Aircraft;
						break;
					case "UseGroupSize":
						luaTable[text] = miningMission.UseGroupSizeHardLimit;
						break;
					case "StationAltitudeAircraft":
						luaTable[text] = miningMission.StationAltitude_Aircraft;
						break;
					case "stationdepthsubmarinepresetuse":
						luaTable[text] = miningMission.UseStationDepth_Submarine_Preset;
						break;
					case "TransitAltitudeAircraft":
						luaTable[text] = miningMission.TransitAltitude_Aircraft;
						break;
					case "StationThrottleSubmarine":
						luaTable[text] = miningMission.StationThrottle_Submarine;
						break;
					case "StationThrottleShip":
						luaTable[text] = miningMission.StationThrottle_Ship;
						break;
					case "ArmingDelay":
					{
						TimeSpan timeSpan = TimeSpan.FromSeconds((double)miningMission.ArmDelay);
						string value = $"{timeSpan.Days:D2}d:{timeSpan.Hours:D2}h:{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s";
						luaTable[text] = value;
						break;
					}
					case "Zone":
					{
						LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
						int num = 1;
						foreach (ReferencePoint item in miningMission.Area)
						{
							LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
							luaTable3["name"] = item.Name;
							luaTable2[num] = luaTable3;
							num++;
						}
						luaTable[text] = luaTable2;
						break;
					}
					case "transitaltitudepreset":
						luaTable[text] = miningMission.TransitAltitude_Preset;
						break;
					case "transitdepthsubmarinepresetuse":
						luaTable[text] = miningMission.UseTransitDepth_Submarine_Preset;
						break;
					case "FlightSize":
						luaTable[text] = miningMission.FlightSize.ToString();
						break;
					case "transitdepthsubmarinepreset":
						luaTable[text] = miningMission.TransitDepth_Submarine_Preset;
						break;
					case "TransitThrottleShip":
						luaTable[text] = miningMission.TransitThrottle_Ship;
						break;
					case "usestationaltitudepreset":
						luaTable[text] = miningMission.UseStationAltitude_Preset;
						break;
					case "StationThrottleAircraft":
						luaTable[text] = miningMission.StationThrottle_Aircraft;
						break;
					case "TransitDepthSubmarine":
						luaTable[text] = miningMission.TransitDepth_Submarine;
						break;
					case "TransitThrottleAircraft":
						luaTable[text] = miningMission.TransitThrottle_Aircraft;
						break;
					case "TransitTerrainFollowingAircraft":
						luaTable[text] = miningMission.TransitTerrainFollowing_Aircraft;
						break;
					case "GroupSize":
						luaTable[text] = miningMission.GroupSize.ToString();
						break;
					case "MinAircraftReq":
						luaTable[text] = miningMission.MinimumNumberOfAircraft.ToString();
						break;
					}
				}
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property. Please use ScenEdit_SetMission().");
		}
	}

	[DoNotPrune]
	public LuaTable supportmission
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (mission_0.MissionClass == Mission._MissionClass.Support)
			{
				SupportMission supportMission = (SupportMission)mission_0;
				string[] mission_Support = LuaMission.Mission_Support;
				foreach (string text in mission_Support)
				{
					switch (text.ToLower())
					{
					case "onetimeonly":
						luaTable[text] = supportMission.OneTimeOnly;
						break;
					case "transitthrottlesubmarine":
						luaTable[text] = supportMission.TransitThrottle_Submarine;
						break;
					case "tankeronetime":
						luaTable[text] = supportMission.A2AR_OneTankingCycleOnly;
						break;
					case "ccenable":
						luaTable[text] = supportMission.ContinousCoverage_Enable;
						break;
					case "stationthrottleaircraft":
						luaTable[text] = supportMission.StationThrottle_Aircraft;
						break;
					case "transitdepthsubmarinepreset":
						luaTable[text] = supportMission.TransitDepth_Submarine_Preset;
						break;
					case "transitdepthsubmarinepresetuse":
						luaTable[text] = supportMission.UseTransitDepth_Submarine_Preset;
						break;
					case "ccallowqra":
						luaTable[text] = supportMission.ContinousCoverage_QRAEnable;
						break;
					case "transitthrottlefacility":
						luaTable[text] = supportMission.TransitThrottle_Facility;
						break;
					case "usestationaltitudepreset":
						luaTable[text] = supportMission.UseStationAltitude_Preset;
						break;
					case "stationthrottleship":
						luaTable[text] = supportMission.StationThrottle_Ship;
						break;
					case "transitdepthsubmarine":
						luaTable[text] = supportMission.TransitDepth_Submarine;
						break;
					case "minaircraftreq":
						luaTable[text] = supportMission.MinimumNumberOfAircraft.ToString();
						break;
					case "transitthrottleship":
						luaTable[text] = supportMission.TransitThrottle_Ship;
						break;
					case "ccoverlap":
						luaTable[text] = supportMission.ContinousCoverage_Overlap;
						break;
					case "activeemcon":
						luaTable[text] = supportMission.ActiveEMCONOnlyOnStation;
						break;
					case "stationthrottleshipfacility":
						luaTable[text] = supportMission.StationThrottle_Facility;
						break;
					case "tankermaxreceivers":
						luaTable[text] = supportMission.A2AR_MaxNumberOfReceiversPerTanker;
						break;
					case "stationgroupingtype":
						luaTable[text] = supportMission.OneThirdGrouping;
						break;
					case "ccflightgenmethod":
						luaTable[text] = supportMission.ContinousCoverage_QRAFlightGenerationMethod;
						break;
					case "onstation":
						luaTable[text] = supportMission.MinimumNumberOnStation;
						break;
					case "onethirdrule":
						luaTable[text] = supportMission.OneThirdRule;
						break;
					case "usegroupsize":
						luaTable[text] = supportMission.UseGroupSizeHardLimit;
						break;
					case "stationaltitudepreset":
						luaTable[text] = supportMission.StationAltitude_Preset;
						break;
					case "transitaltitudeaircraft":
						luaTable[text] = supportMission.TransitAltitude_Aircraft;
						break;
					case "zone":
					{
						LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
						int num = 1;
						foreach (ReferencePoint item in supportMission.NavigationCourse)
						{
							LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
							luaTable3["name"] = item.Name;
							luaTable2[num] = luaTable3;
							num++;
						}
						luaTable[text] = luaTable2;
						break;
					}
					case "useflightsize":
						luaTable[text] = supportMission.UseFlightSizeHardLimit;
						break;
					case "transitthrottleaircraft":
						luaTable[text] = supportMission.TransitThrottle_Aircraft;
						break;
					case "stationterrainfollowingaircraft":
						luaTable[text] = supportMission.StationTerrainFollowing_Aircraft;
						break;
					case "stationdepthsubmarinepreset":
						luaTable[text] = supportMission.StationDepth_Submarine_Preset;
						break;
					case "usetransitaltitudepreset":
						luaTable[text] = supportMission.UseTransitAltitude_Preset;
						break;
					case "transitaltitudepreset":
						luaTable[text] = supportMission.TransitAltitude_Preset;
						break;
					case "flightsize":
						luaTable[text] = supportMission.FlightSize.ToString();
						break;
					case "ccstationtime":
						luaTable[text] = supportMission.ContinousCoverage_StationTime;
						break;
					case "stationaltitudeaircraft":
						luaTable[text] = supportMission.StationAltitude_Aircraft;
						break;
					case "stationdepthsubmarine":
						luaTable[text] = supportMission.StationDepth_Submarine;
						break;
					case "stationthrottlesubmarine":
						luaTable[text] = supportMission.StationThrottle_Submarine;
						break;
					case "stationdepthsubmarinepresetuse":
						luaTable[text] = supportMission.UseStationDepth_Submarine_Preset;
						break;
					case "looptype":
						luaTable[text] = supportMission.NavigationLoopType;
						break;
					case "transitterrainfollowingaircraft":
						luaTable[text] = supportMission.TransitTerrainFollowing_Aircraft;
						break;
					case "groupsize":
						luaTable[text] = supportMission.GroupSize.ToString();
						break;
					}
				}
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property. Please use ScenEdit_SetMission().");
		}
	}

	[DoNotPrune]
	public LuaTable patrolmission
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (mission_0.MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol patrol = (Patrol)mission_0;
				string[] mission_Patrol = LuaMission.Mission_Patrol;
				foreach (string text in mission_Patrol)
				{
					switch (text.ToLower())
					{
					case "attackaltitudeaircraft":
						luaTable[text] = patrol.AttackAltitude_Aircraft;
						break;
					case "onstation":
						luaTable[text] = patrol.MinimumNumberOnStation;
						break;
					case "stationgroupingtype":
						luaTable[text] = patrol.OneThirdGrouping;
						break;
					case "boatstoinvestigate":
						luaTable[text] = patrol.NumberOfBoats_Investigate;
						break;
					case "attackdistanceaircraft":
						luaTable[text] = patrol.AttackDistance_Aircraft;
						break;
					case "usestationaltitudepreset":
						luaTable[text] = patrol.UseStationAltitude_Preset;
						break;
					case "checkwwr":
						luaTable[text] = patrol.get_InvestigateWithinWeaponRange(scenario_0);
						break;
					case "attackdistancesubmarine":
						luaTable[text] = patrol.AttackDistance_Submarine;
						break;
					case "transitthrottleship":
						luaTable[text] = patrol.TransitThrottle_Ship;
						break;
					case "activeemcon":
						luaTable[text] = patrol.ActiveEMCONOnlyInPatrolOrProsecutionArea;
						break;
					case "transitdepthsubmarine":
						luaTable[text] = patrol.TransitDepth_Submarine;
						break;
					case "minaircraftreq":
						luaTable[text] = patrol.MinimumNumberOfAircraft.ToString();
						break;
					case "stationthrottleship":
						luaTable[text] = patrol.StationThrottle_Ship;
						break;
					case "attackdepthsubmarinepresetuse":
						luaTable[text] = patrol.UseAttackDepth_Submarine_Preset;
						break;
					case "transitdepthsubmarinepreset":
						luaTable[text] = patrol.TransitDepth_Submarine_Preset;
						break;
					case "transitdepthsubmarinepresetuse":
						luaTable[text] = patrol.UseTransitDepth_Submarine_Preset;
						break;
					case "attackdepthsubmarine":
						luaTable[text] = patrol.AttackDepth_Submarine;
						break;
					case "transitthrottlesubmarine":
						luaTable[text] = patrol.TransitThrottle_Submarine;
						break;
					case "stationthrottleaircraft":
						luaTable[text] = patrol.StationThrottle_Aircraft;
						break;
					case "boatstoengage":
						luaTable[text] = patrol.NumberOfBoats_Engage;
						break;
					case "patrolzone":
					{
						LuaTable luaTable4 = LuaSandBox.Singleton().CreateTable();
						int num2 = 1;
						foreach (ReferencePoint item in patrol.PatrolArea)
						{
							LuaTable luaTable5 = LuaSandBox.Singleton().CreateTable();
							luaTable5["name"] = item.Name;
							luaTable4[num2] = luaTable5;
							num2++;
						}
						luaTable[text] = luaTable4;
						break;
					}
					case "flightstoengage":
						luaTable[text] = patrol.NumberOfFlights_Engage;
						break;
					case "attackterrainfollowingaircraft":
						luaTable[text] = patrol.AttackTerrainFollowing_Aircraft;
						break;
					case "transitaltitudepreset":
						luaTable[text] = patrol.TransitAltitude_Preset;
						break;
					case "flightsize":
						luaTable[text] = patrol.FlightSize.ToString();
						break;
					case "checkopa":
						luaTable[text] = patrol.get_InvestigateOutsidePatrolArea(scenario_0);
						break;
					case "stationaltitudeaircraft":
						luaTable[text] = patrol.StationAltitude_Aircraft;
						break;
					case "stationdepthsubmarine":
						luaTable[text] = patrol.StationDepth_Submarine;
						break;
					case "stationdepthsubmarinepresetuse":
						luaTable[text] = patrol.UseStationDepth_Submarine_Preset;
						break;
					case "type":
						luaTable[text] = patrol.Type;
						break;
					case "attackaltitudepreset":
						luaTable[text] = patrol.AttackAltitude_Preset;
						break;
					case "stationthrottlesubmarine":
						luaTable[text] = patrol.StationThrottle_Submarine;
						break;
					case "looptype":
						luaTable[text] = patrol.MovementStyle;
						break;
					case "attackthrottlesubmarine":
						luaTable[text] = patrol.AttackThrottle_Submarine;
						break;
					case "transitterrainfollowingaircraft":
						luaTable[text] = patrol.TransitTerrainFollowing_Aircraft;
						break;
					case "usetransitaltitudepreset":
						luaTable[text] = patrol.UseTransitAltitude_Preset;
						break;
					case "useflightsize":
						luaTable[text] = patrol.UseFlightSizeHardLimit;
						break;
					case "transitthrottleaircraft":
						luaTable[text] = patrol.TransitThrottle_Aircraft;
						break;
					case "groupsize":
						luaTable[text] = patrol.GroupSize.ToString();
						break;
					case "stationterrainfollowingaircraft":
						luaTable[text] = patrol.StationTerrainFollowing_Aircraft;
						break;
					case "groupmemberengagedistance":
						luaTable[text] = patrol.GroupMemberEngageDistance;
						break;
					case "stationdepthsubmarinepreset":
						luaTable[text] = patrol.StationDepth_Submarine_Preset;
						break;
					case "wingmanengagedistance":
						luaTable[text] = patrol.WingmanEngageDistance;
						break;
					case "transitaltitudeaircraft":
						luaTable[text] = patrol.TransitAltitude_Aircraft;
						break;
					case "attackthrottleaircraft":
						luaTable[text] = patrol.AttackThrottle_Aircraft;
						break;
					case "attackthrottleship":
						luaTable[text] = patrol.AttackThrottle_Ship;
						break;
					case "flightstoinvestigate":
						luaTable[text] = patrol.NumberOfFlights_Investigate;
						break;
					case "attackdistanceship":
						luaTable[text] = patrol.AttackDistance_Ship;
						break;
					case "attackdepthsubmarinepreset":
						luaTable[text] = patrol.AttackDepth_Submarine_Preset;
						break;
					case "sprintdrift":
						if (patrol.SprintAndDrift)
						{
							luaTable[text] = patrol.SprintAndDrift;
						}
						break;
					case "prosecutionzone":
					{
						LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
						int num = 1;
						foreach (ReferencePoint item2 in patrol.ProsecutionArea)
						{
							LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
							luaTable3["name"] = item2.Name;
							luaTable2[num] = luaTable3;
							num++;
						}
						luaTable[text] = luaTable2;
						break;
					}
					case "useattackaltitudepreset":
						luaTable[text] = patrol.UseAttackAltitude_Preset;
						break;
					case "onethirdrule":
						luaTable[text] = patrol.OneThirdRule;
						break;
					case "usegroupsize":
						luaTable[text] = patrol.UseGroupSizeHardLimit;
						break;
					case "avoidcavitation":
						if (patrol.AvoidCavitation)
						{
							luaTable[text] = patrol.AvoidCavitation;
						}
						break;
					case "stationaltitudepreset":
						luaTable[text] = patrol.StationAltitude_Preset;
						break;
					}
				}
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property. Please use ScenEdit_SetMission().");
		}
	}

	[DoNotPrune]
	public LuaTable strikemission
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
			if (mission_0.MissionClass == Mission._MissionClass.Strike)
			{
				Strike strike = (Strike)mission_0;
				string[] mission_Strike = LuaMission.Mission_Strike;
				foreach (string text in mission_Strike)
				{
					switch (text.ToLower())
					{
					case "flightstoengage":
						luaTable2[text] = strike.Escort_NumberOfFlights_Engage;
						break;
					case "escortgroupsize":
						luaTable2[text] = (int)strike.Escort_GroupSize;
						break;
					case "escorttransitaltitude":
						luaTable2[text] = strike.Escort_TransitAltitude;
						break;
					case "escortresponseradiussead":
						luaTable2[text] = strike.Escort_ResponseRadius_SEAD;
						break;
					case "escortflightsizenonshooter":
						luaTable2[text] = (int)strike.Escort_FlightSize_NonShooter;
						break;
					case "type":
						luaTable2[text] = strike.Type;
						break;
					case "escorttransitthrottle":
						luaTable2[text] = strike.Escort_TransitThrottle;
						break;
					case "escortmaxshooter":
						luaTable2[text] = strike.MaximumNumberOfAircraft_Escorts_Shooter.ToString();
						break;
					case "boatstoengage":
						luaTable2[text] = strike.Escort_NumberOfBoats_Engage;
						break;
					case "escortflightsizeshooter":
						luaTable2[text] = (int)strike.Escort_FlightSize_Shooter;
						break;
					case "boatstoinvestigate":
						luaTable2[text] = strike.Escort_NumberOfBoats_Investigate;
						break;
					case "escorttransitterrainfollowing":
						luaTable2[text] = strike.Escort_TransitTerrainFollowing;
						break;
					case "escortminshooter":
						luaTable2[text] = strike.MinimumNumberOfAircraft_Escorts_Shooter.ToString();
						break;
					case "wingmanengagedistance":
						luaTable2[text] = strike.Escort_WingmanEngageDistance;
						break;
					case "escortresponseradius":
						luaTable2[text] = strike.Escort_ResponseRadius;
						break;
					case "escortmaxnonshooter":
						luaTable2[text] = strike.MaximumNumberOfAircraft_Escorts_NonShooter.ToString();
						break;
					case "flightstoinvestigate":
						luaTable2[text] = strike.Escort_NumberOfFlights_Investigate;
						break;
					case "escortminnonshooter":
						luaTable2[text] = strike.MinimumNumberOfAircraft_Escorts_NonShooter.ToString();
						break;
					case "escortusegroupsize":
						luaTable2[text] = strike.UseGroupSizeHardLimit_Escort;
						break;
					case "escortformationattack":
						luaTable2[text] = strike.Escort_Formation_Attack;
						break;
					case "escortformationcruise":
						luaTable2[text] = strike.Escort_Formation_Cruise;
						break;
					case "escortuseflightsize":
						luaTable2[text] = strike.UseFlightSizeHardLimit_Escort;
						break;
					case "groupmemberengagedistance":
						luaTable2[text] = strike.Escort_GroupMemberEngageDistance;
						break;
					}
				}
				luaTable["Escort"] = luaTable2;
				luaTable2 = LuaSandBox.Singleton().CreateTable();
				string[] mission_Strike2 = LuaMission.Mission_Strike;
				foreach (string text2 in mission_Strike2)
				{
					switch (text2.ToLower())
					{
					case "attackmethod":
						luaTable2[text2] = strike.AttackMethod;
						break;
					case "strikemindistship":
						luaTable2[text2] = strike.MinResponseRadius_Ship;
						break;
					case "focusonstrike":
						luaTable2[text2] = strike.Doctrine.GetElementState(Doctrine.DoctrineItem_E.StrikeMemberFocus).Value;
						break;
					case "strikeformationattack":
						luaTable2[text2] = strike.Formation_Attack;
						break;
					case "includeinato":
						luaTable2[text2] = strike.IncludeInATO;
						break;
					case "type":
						luaTable2[text2] = strike.Type;
						break;
					case "strikeflightsize":
						luaTable2[text2] = (int)strike.FlightSize;
						break;
					case "strikeautoplanner":
						luaTable2[text2] = strike.UsePlanner;
						break;
					case "splitdistance":
						luaTable2[text2] = strike.SplitDistance;
						break;
					case "strikeonetimeonly":
						luaTable2[text2] = strike.OneTimeOnly;
						break;
					case "strikepreplan":
						luaTable2[text2] = strike.RTB_When_Target_Destroyed;
						break;
					case "strikegroupsize":
						luaTable2[text2] = (int)strike.GroupSize;
						break;
					case "preplannedonly":
						luaTable2[text2] = strike.RTB_When_Target_Destroyed;
						break;
					case "strikeminimumtrigger":
						luaTable2[text2] = strike.MinimumContactStanceToTrigger;
						break;
					case "useflightplan":
						luaTable2[text2] = strike.UseFlightplans;
						break;
					case "useflightplansonly":
						luaTable2[text2] = strike.UsePreGeneratedFlightplansOnly;
						break;
					case "strikemax":
						luaTable2[text2] = strike.MaxFlightNumber_Strike.ToString();
						break;
					case "strikemaxdistship":
						luaTable2[text2] = strike.MaxResponseRadius_Ship;
						break;
					case "offaxisattack":
						luaTable2[text2] = strike.UsePlanner;
						break;
					case "strikeformationcruise":
						luaTable2[text2] = strike.Formation_Cruise;
						break;
					case "strikemindistaircraft":
						luaTable2[text2] = strike.MinResponseRadius_Aircraft;
						break;
					case "strikeuseflightsize":
						luaTable2[text2] = strike.UseFlightSizeHardLimit;
						break;
					case "strikeusegroupsize":
						luaTable2[text2] = strike.UseGroupSizeHardLimit;
						break;
					case "strikemaxdistaircraft":
						luaTable2[text2] = strike.MaxResponseRadius_Aircraft;
						break;
					case "strikeminaircraftreq":
						luaTable2[text2] = strike.MinimumNumberOfAircraft.ToString();
						break;
					}
				}
				luaTable["Strike"] = luaTable2;
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property. Please use ScenEdit_SetMission().");
		}
	}

	[DoNotPrune]
	public LuaTable cargomission
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (mission_0.MissionClass == Mission._MissionClass.Cargo)
			{
				CargoMission cargoMission = (CargoMission)mission_0;
				string[] mission_Cargo = LuaMission.Mission_Cargo;
				foreach (string text in mission_Cargo)
				{
					switch (text)
					{
					case "UseFlightSize":
						luaTable[text] = cargoMission.UseFlightSizeHardLimit;
						break;
					case "IsFulfilled":
						luaTable[text] = cargoMission.IsFulfilled();
						break;
					case "UseGroupSize":
						luaTable[text] = cargoMission.UseGroupSizeHardLimit;
						break;
					case "StationAltitudeAircraft":
						luaTable[text] = cargoMission.StationAltitude_Aircraft;
						break;
					case "AutomaticallyUnpackContainersAtDestination":
						luaTable[text] = cargoMission.UnpackAllContainers;
						break;
					case "TransitAltitudeAircraft":
						luaTable[text] = cargoMission.TransitAltitude_Aircraft;
						break;
					case "StationThrottleShip":
						luaTable[text] = cargoMission.StationThrottle_Ship;
						break;
					case "MoveAllCargo":
						luaTable[text] = cargoMission.MoveAllCargo;
						break;
					case "Zone":
					{
						if (cargoMission.Area.Count == 0)
						{
							luaTable[text] = "(NONE)";
							break;
						}
						LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
						int num = 1;
						foreach (ReferencePoint item in cargoMission.Area)
						{
							LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
							luaTable3["name"] = item.Name;
							luaTable2[num] = luaTable3;
							num++;
						}
						luaTable[text] = luaTable2;
						break;
					}
					case "AllGroundUnitAttemptSelfDelivery":
						luaTable[text] = cargoMission.AllowAllSelfDelivery;
						break;
					case "StationThrottleAircraft":
						luaTable[text] = cargoMission.StationThrottle_Aircraft;
						break;
					case "TransitThrottleShip":
						luaTable[text] = cargoMission.TransitThrottle_Ship;
						break;
					case "Type":
						luaTable[text] = cargoMission.Type;
						break;
					case "AllowGroundUnitSelfDeliveryFromCargo":
						luaTable[text] = cargoMission.AllowSelfDeliveryFromCargo;
						break;
					case "DestinationUnitID":
						if (cargoMission.DestinationUnit == null)
						{
							luaTable[text] = "(NONE)";
						}
						else
						{
							luaTable[text] = cargoMission.DestinationUnit.ObjectID;
						}
						break;
					case "TransitThrottleAircraft":
						luaTable[text] = cargoMission.TransitThrottle_Aircraft;
						break;
					}
				}
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property. Please use ScenEdit_SetMission().");
		}
	}

	[DoNotPrune]
	public LuaTable flightlist
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (Mission.Flight flight in mission_0.FlightList)
			{
				luaTable[luaTable.Keys.Count + 1] = new LuaWrapper_Flight(flight, scenario_0);
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property. Please use ScenEdit_Set.");
		}
	}

	[DoNotPrune]
	public string TimeOnTargetStation
	{
		get
		{
			return mission_0.TimeOnTarget.ToString();
		}
		set
		{
			try
			{
				if (value.Length > 0)
				{
					mission_0.TimeOnTarget = LuaUtility.ParseDateTime_String(value, LuaUtility.DateFormat.DDMMYYYY);
				}
				else
				{
					mission_0.TimeOnTarget = null;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			mission_0.UpdateFlightPlanUseForTakeOffAndTargetTimes();
		}
	}

	[DoNotPrune]
	public string TakeOffTime
	{
		get
		{
			return mission_0.TakeOffTime.ToString();
		}
		set
		{
			try
			{
				if (value.Length <= 0)
				{
					mission_0.TakeOffTime = null;
				}
				else
				{
					mission_0.TakeOffTime = LuaUtility.ParseDateTime_String(value, LuaUtility.DateFormat.DDMMYYYY);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			mission_0.UpdateFlightPlanUseForTakeOffAndTargetTimes();
		}
	}

	[DoNotPrune]
	public string parentTaskPool => mission_0.get_ParentTaskPoolID(side_0);

	[DoNotPrune]
	public LuaTable packagelist
	{
		get
		{
			if (mission_0.Category == Mission.MissionCategory.TaskPool)
			{
				LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
				foreach (Mission package in ((TaskPool)mission_0).PackageList)
				{
					luaTable[luaTable.Keys.Count + 1] = new LuaWrapper_Mission(package, scenario_0);
				}
				return luaTable;
			}
			return null;
		}
	}

	[DoNotPrune]
	public LuaTable assignedCargo
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (mission_0.MissionClass == Mission._MissionClass.Cargo)
			{
				List<CargoManifestItem> cargoToUnload = ((CargoMission)mission_0).CargoToUnload;
				int num = 1;
				foreach (CargoManifestItem item in cargoToUnload)
				{
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					luaTable2["type"] = (int)item.objectType;
					luaTable2["dbid"] = item.DBID;
					if (item.objectType == Cargo.CargoObjectType.Mount)
					{
						luaTable2["guid"] = "";
					}
					else
					{
						luaTable2["guid"] = item.ObjectID;
					}
					luaTable2["quantity"] = item.quantity;
					luaTable[num] = luaTable2;
					num++;
				}
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property. Please use addAssignedCargo / removeAssignedCargo methods.");
		}
	}

	public LuaWrapper_Mission(Mission theMission, Scenario theScen)
	{
		mission_0 = theMission;
		scenario_0 = theScen;
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			foreach (Mission mission in side.Missions)
			{
				if (Operators.CompareString(mission.ObjectID, mission_0.ObjectID, false) == 0)
				{
					side_0 = side;
					break;
				}
			}
		}
	}

	[DoNotPrune]
	public override string ToString()
	{
		return string.Concat("mission {\r\n guid = '" + guid + "', \r\n name = '" + name + "', \r\n side = '" + side + "', \r\n type = '" + type.ToString() + "', \r\n subtype = '" + subtype.ToString() + "', \r\n isactive = '" + isactive.ToString() + "', \r\n starttime = '" + starttime + "', \r\n endtime = '" + endtime + "', \r\n SISH = '" + SISH.ToString() + "', \r\n aar = '" + aar.ToString() + "',\r\n unitlist = '" + unitlist.ToString() + "',\r\n", "}");
	}

	public LuaTable addAssignedCargo(int cargoType, int DBID, string ObjectID)
	{
		if (mission_0.MissionClass != Mission._MissionClass.Cargo)
		{
			throw new LuaError("Mission is not a cargo mission.");
		}
		CargoManifestItem cargoManifestItem = null;
		switch (cargoType)
		{
		case 1:
			throw new LuaError("Please use the addAssignedCargoMount method to add a mount cargo entry.");
		case 4:
			if (string.IsNullOrEmpty(ObjectID))
			{
				throw new LuaError("To add a cargo container to the assigned cargo list you must specify the container's ObjectID.");
			}
			cargoManifestItem = new CargoManifestItem((Cargo.CargoObjectType)cargoType, DBID, ObjectID);
			break;
		default:
			throw new LuaError("Unrecognized cargo object type.");
		case 2:
		case 3:
		case 6:
			cargoManifestItem = new CargoManifestItem((Cargo.CargoObjectType)cargoType, DBID, ObjectID);
			break;
		}
		if (cargoManifestItem != null)
		{
			cargoManifestItem.GenerateName(scenario_0);
			CargoMission cargoMission = (CargoMission)mission_0;
			CargoManifestItem.Add(cargoManifestItem, cargoMission.CargoToUnload);
		}
		return assignedCargo;
	}

	public LuaTable removeAssignedCargo(int cargoType, int DBID, string ObjectID)
	{
		if (mission_0.MissionClass != Mission._MissionClass.Cargo)
		{
			throw new LuaError("Mission is not a cargo mission.");
		}
		if (cargoType == 1)
		{
			throw new LuaError("Please use the removeAssignedCargoMount method to remove a mount cargo entry.");
		}
		CargoManifestItem cargoManifestItem = null;
		switch (cargoType)
		{
		case 1:
			throw new LuaError("Please use the addAssignedCargoMount method to add a mount cargo entry.");
		default:
			throw new LuaError("Unrecognized cargo object type.");
		case 2:
		case 3:
		case 4:
		case 6:
			cargoManifestItem = new CargoManifestItem((Cargo.CargoObjectType)cargoType, DBID, ObjectID);
			if (cargoManifestItem != null)
			{
				CargoMission cargoMission = (CargoMission)mission_0;
				CargoManifestItem.Remove(cargoManifestItem, cargoMission.CargoToUnload);
			}
			return assignedCargo;
		}
	}

	public LuaTable addAssignedCargoMount(int DBID, int quantity)
	{
		if (mission_0.MissionClass != Mission._MissionClass.Cargo)
		{
			throw new LuaError("Mission is not a cargo mission.");
		}
		CargoMission cargoMission = (CargoMission)mission_0;
		CargoManifestItem.Add(new CargoManifestItem(Cargo.CargoObjectType.Mount, DBID)
		{
			quantity = quantity
		}, cargoMission.CargoToUnload);
		return assignedCargo;
	}

	public LuaTable removeAssignedCargoMount(int DBID, int Quantity)
	{
		if (mission_0.MissionClass != Mission._MissionClass.Cargo)
		{
			throw new LuaError("Mission is not a cargo mission.");
		}
		CargoMission cargoMission = (CargoMission)mission_0;
		CargoManifestItem cargoManifestItem = new CargoManifestItem(Cargo.CargoObjectType.Mount, DBID);
		cargoManifestItem.GenerateName(scenario_0);
		cargoManifestItem.quantity = Quantity;
		CargoManifestItem.Remove(cargoManifestItem, cargoMission.CargoToUnload);
		return assignedCargo;
	}

	public LuaTable createFlightPlans(LuaTable table)
	{
		return LuaMission.ScenEdit_CreateMissionFlightPlan(side_0.ObjectID, mission_0.ObjectID, table, scenario_0);
	}

	public void updateWPtimes()
	{
		MissionPlanner.Update_Mission_times(scenario_0, mission_0);
	}

	static LuaWrapper_Mission()
	{
		Class72.smethod_20();
	}
}
