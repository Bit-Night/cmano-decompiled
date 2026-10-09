using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPruneType]
[DoNotObfuscateType]
[DoNotPrune]
public sealed class LuaWrapper_Flight
{
	private Mission.Flight flight_0;

	private Scenario scenario_0;

	public object fields
	{
		get
		{
			Type type = GetType();
			int num = 0;
			PropertyInfo[] properties = type.GetProperties();
			MethodInfo[] methods = type.GetMethods();
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
				foreach (MethodInfo obj in array2)
				{
					string text2 = "set_" + propertyInfo.Name;
					if (Operators.CompareString(obj.Name, text2, false) == 0)
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
	public object __obj => flight_0;

	[DoNotPrune]
	public string guid => flight_0.ObjectID;

	[DoNotPrune]
	public string name
	{
		get
		{
			return flight_0.Callsign;
		}
		set
		{
			flight_0.Callsign = value;
		}
	}

	[DoNotPrune]
	public LuaTable course
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			Waypoint[] flightPlan = flight_0.FlightPlan;
			foreach (Waypoint theWaypoint in flightPlan)
			{
				LuaWrapper_Waypoint luaWrapper_Waypoint = new LuaWrapper_Waypoint(theWaypoint, scenario_0);
				luaTable[luaTable.Keys.Count + 1] = luaWrapper_Waypoint.ToTableWrapper();
			}
			return luaTable;
		}
		set
		{
			if (value != null)
			{
				if (flight_0.FlightPlan != null && flight_0.FlightPlan.Count() != 0)
				{
					List<object> list = LuaUtility.ToArray(value.GetEnumerator());
					Dictionary<string, Waypoint> dictionary = new Dictionary<string, Waypoint>();
					Waypoint[] flightPlan = flight_0.FlightPlan;
					foreach (Waypoint waypoint in flightPlan)
					{
						dictionary.Add(waypoint.ObjectID, waypoint);
					}
					using List<object>.Enumerator enumerator = list.GetEnumerator();
					object objectValue;
					while (true)
					{
						if (enumerator.MoveNext())
						{
							objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
							if (!(objectValue is LuaTable))
							{
								break;
							}
							Waypoint value2 = new Waypoint();
							Dictionary<string, object> dictionary2 = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
							if (dictionary2.ContainsKey("GUID") && dictionary.TryGetValue(Conversions.ToString(dictionary2["GUID"]), out value2))
							{
								LuaWrapper_Waypoint.FromTable((LuaTable)objectValue, value2, scenario_0);
							}
							continue;
						}
						return;
					}
					throw new LuaError("Error at " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)));
				}
				throw new LuaError("No flightplan details available");
			}
			flight_0.ClearFlightPlan();
		}
	}

	[DoNotPrune]
	public LuaTable courseWrapper
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			Waypoint[] flightPlan = flight_0.FlightPlan;
			foreach (Waypoint theWaypoint in flightPlan)
			{
				LuaWrapper_Waypoint value = new LuaWrapper_Waypoint(theWaypoint, scenario_0);
				luaTable[luaTable.Keys.Count + 1] = value;
			}
			return luaTable;
		}
		set
		{
			if (value != null)
			{
				Waypoint[] theArray = new Waypoint[0];
				List<object> list = LuaUtility.ToArray(value.GetEnumerator());
				foreach (object item in list)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					if (objectValue is LuaWrapper_Waypoint)
					{
						Waypoint waypoint = new Waypoint();
						waypoint = ((LuaWrapper_Waypoint)objectValue).myWP;
						ArrayExtensions.Add(ref theArray, waypoint);
						continue;
					}
					throw new LuaError("Error at " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)));
				}
				flight_0.ClearFlightPlan();
				flight_0.FlightPlan = theArray;
			}
			else
			{
				flight_0.ClearFlightPlan();
			}
		}
	}

	public LuaWrapper_Flight(Mission.Flight theFlight, Scenario theScen)
	{
		flight_0 = theFlight;
		scenario_0 = theScen;
	}

	[DoNotPrune]
	public LuaTable insertWaypoint(short theIndexBefore, LuaTable theWP = null)
	{
		ActiveUnit activeUnit = flight_0.get_ReferenceUnit(scenario_0);
		Mission theMission = activeUnit.get_UnitSide(SetSideOnly: false).Missions.Where([SpecialName] (Mission m) => Operators.CompareString(m.ObjectID, flight_0.ParentMissionOrPackageObjectID, false) == 0).First();
		Waypoint waypoint = new Waypoint();
		LuaWrapper_Waypoint.FromTable(theWP, waypoint, scenario_0);
		waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
		LuaMission.MissionFlightPlanInsertWaypoint(theIndexBefore, scenario_0, activeUnit.get_UnitSide(SetSideOnly: false), theMission, flight_0, Mission.Flight.FlightElement.LeadElement, waypoint);
		return null;
	}

	[DoNotPrune]
	public LuaTable insertWaypointAfter(string theAnchor, LuaTable theWP = null)
	{
		int num = 0;
		ActiveUnit activeUnit = flight_0.get_ReferenceUnit(scenario_0);
		Mission theMission = activeUnit.get_UnitSide(SetSideOnly: false).Missions.Where([SpecialName] (Mission m) => Operators.CompareString(m.ObjectID, flight_0.ParentMissionOrPackageObjectID, false) == 0).First();
		Waypoint waypoint = new Waypoint();
		LuaWrapper_Waypoint.FromTable(theWP, waypoint, scenario_0);
		waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
		num = LuaMission.MissionFlightPlanInsertWaypointAfter(theAnchor, scenario_0, activeUnit.get_UnitSide(SetSideOnly: false), theMission, flight_0, Mission.Flight.FlightElement.LeadElement, waypoint);
		if (num != -1)
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			LuaWrapper_Waypoint luaWrapper_Waypoint = new LuaWrapper_Waypoint(flight_0.FlightPlan[num], scenario_0);
			luaTable[1] = num + 1;
			luaTable[2] = luaWrapper_Waypoint.ToTableWrapper();
			return luaTable;
		}
		return null;
	}

	[DoNotPrune]
	public LuaTable insertWaypointBefore(string theAnchor, LuaTable theWP = null)
	{
		int num = 0;
		ActiveUnit activeUnit = flight_0.get_ReferenceUnit(scenario_0);
		Mission theMission = activeUnit.get_UnitSide(SetSideOnly: false).Missions.Where([SpecialName] (Mission m) => Operators.CompareString(m.ObjectID, flight_0.ParentMissionOrPackageObjectID, false) == 0).First();
		Waypoint waypoint = new Waypoint();
		LuaWrapper_Waypoint.FromTable(theWP, waypoint, scenario_0);
		waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
		num = LuaMission.MissionFlightPlanInsertWaypointBefore(theAnchor, scenario_0, activeUnit.get_UnitSide(SetSideOnly: false), theMission, flight_0, Mission.Flight.FlightElement.LeadElement, waypoint);
		if (num != -1)
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			LuaWrapper_Waypoint luaWrapper_Waypoint = new LuaWrapper_Waypoint(flight_0.FlightPlan[num], scenario_0);
			luaTable[1] = num + 1;
			luaTable[2] = luaWrapper_Waypoint.ToTableWrapper();
			return luaTable;
		}
		return null;
	}

	[DoNotPrune]
	public object deleteWaypoint(object theIndex, bool @override = false)
	{
		ActiveUnit activeUnit = flight_0.get_ReferenceUnit(scenario_0);
		Mission theMission = activeUnit.get_UnitSide(SetSideOnly: false).Missions.Where([SpecialName] (Mission m) => Operators.CompareString(m.ObjectID, flight_0.ParentMissionOrPackageObjectID, false) == 0).First();
		Waypoint waypoint = null;
		Waypoint[] flightPlan = flight_0.FlightPlan;
		foreach (Waypoint waypoint2 in flightPlan)
		{
			if (Operators.CompareString(waypoint2.Description, Conversions.ToString(theIndex), false) != 0 && waypoint2.Type != (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), Conversions.ToString(theIndex), ignoreCase: true))
			{
				continue;
			}
			if (!@override)
			{
				string text = "";
				if (waypoint2.IsStationWaypoint())
				{
					text = "Cannot delete a Station waypoint!";
				}
				else if (!waypoint2.IsHoldWaypoint())
				{
					if (waypoint2.Type == Waypoint.WaypointType.TakeOff)
					{
						text = "Cannot delete a Take-Off waypoint!";
					}
					else if (waypoint2.Type == Waypoint.WaypointType.LandingMarshal)
					{
						text = "Cannot delete a Landing Marshal waypoint!";
					}
					else if (waypoint2.Type == Waypoint.WaypointType.Land)
					{
						text = "Cannot delete a Landing waypoint!";
					}
					else if (waypoint2.IsSplitWaypoint())
					{
						text = "Cannot delete waypoints with Split formation.";
					}
				}
				else
				{
					text = "Cannot delete a Hold waypoint!";
				}
				if (!string.IsNullOrEmpty(text))
				{
					return text;
				}
			}
			waypoint = waypoint2;
			LuaMission.MissionFlightPlanDeleteWaypoint(scenario_0, activeUnit.get_UnitSide(SetSideOnly: false), theMission, flight_0, Mission.Flight.FlightElement.LeadElement, waypoint2);
			break;
		}
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		if (waypoint != null)
		{
			LuaWrapper_Waypoint luaWrapper_Waypoint = new LuaWrapper_Waypoint(waypoint, scenario_0);
			luaTable[1] = luaWrapper_Waypoint.ToTableWrapper();
		}
		return luaTable;
	}

	[DoNotPrune]
	public object refreshWaypoints()
	{
		ActiveUnit activeUnit = flight_0.get_ReferenceUnit(scenario_0);
		Mission mission = activeUnit.get_UnitSide(SetSideOnly: false).Missions.Where([SpecialName] (Mission m) => Operators.CompareString(m.ObjectID, flight_0.ParentMissionOrPackageObjectID, false) == 0).First();
		Scenario theScen = scenario_0;
		Mission.Flight theFlight = flight_0;
		Mission.Flight flight;
		Waypoint[] theFlightplan = (flight = flight_0).FlightPlan;
		float NecessaryFuel = 0f;
		float MissionFuel = 0f;
		MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, mission, activeUnit, theFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, mission.TakeOffTime, mission.TimeOnTarget, IsMFP: false);
		flight.FlightPlan = theFlightplan;
		return null;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return string.Concat("flight {\r\n guid = '" + guid + "', \r\n name = '" + name + "', \r\n course = '" + course.ToString() + "', \r\n", "}");
	}

	static LuaWrapper_Flight()
	{
		Class72.smethod_20();
	}
}
