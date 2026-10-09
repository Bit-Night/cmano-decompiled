using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Command_Core;
using ServiceStack.Text;

namespace CommandNetcode.RT;

public class MissionHelper
{
	public static bool smethod_0(Mission mission, Scenario scen, Side side, XmlNode node, ConcurrentDictionary<string, ScenarioObject> dict)
	{
		foreach (ReferencePoint refPoint in side.RefPoints)
		{
			dict.TryAdd(refPoint.ObjectID, refPoint);
		}
		foreach (Contact contacts_ in side.Contacts_List)
		{
			dict.TryAdd(contacts_.ObjectID, contacts_);
		}
		foreach (ActiveUnit activeUnits_ in scen.ActiveUnits_List)
		{
			dict.TryAdd(activeUnits_.ObjectID, activeUnits_);
		}
		foreach (Mission mission2 in side.Missions)
		{
			if (mission2.ObjectID != mission.ObjectID)
			{
				dict.TryAdd(mission2.ObjectID, mission2);
			}
		}
		Mission.FromXML(ref node, ref dict, ref scen, mission);
		mission.PostDeserializationHousekeeping(ref scen, side, GameIsRunning: true, ref dict);
		return true;
	}

	public static string smethod_1(Mission mission, Scenario scen, Side side)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		string text = "";
		StringBuilder stringBuilder = StringBuilderCache.Allocate();
		XmlWriter theWriter = (XmlWriter)new XmlTextWriter((TextWriter)new StringWriter(stringBuilder));
		HashSet<string> ObjectsAlreadySerialized = new HashSet<string>();
		foreach (ReferencePoint refPoint in side.RefPoints)
		{
			ObjectsAlreadySerialized.Add(refPoint.ObjectID);
		}
		foreach (Contact contacts_ in side.Contacts_List)
		{
			ObjectsAlreadySerialized.Add(contacts_.ObjectID);
		}
		foreach (ActiveUnit activeUnits_ in scen.ActiveUnits_List)
		{
			ObjectsAlreadySerialized.Add(activeUnits_.ObjectID);
		}
		foreach (Mission mission2 in side.Missions)
		{
			if (mission2.ObjectID != mission.ObjectID)
			{
				ObjectsAlreadySerialized.Add(mission2.ObjectID);
			}
		}
		mission.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref scen);
		theWriter.Flush();
		text = stringBuilder.ToString();
		StringBuilderCache.Free(stringBuilder);
		return text;
	}

	public static Mission CreateNewMissionFromXML(Scenario scen, Side side, XmlNode node, ConcurrentDictionary<string, ScenarioObject> dict, bool useGeneratedID)
	{
		Mission mission = null;
		Mission.MissionCategory theCategory = Mission.MissionCategory.Mission;
		XmlNode nodeByName = Command_Core.Misc.GetNodeByName(node.ChildNodes, "Category");
		if (nodeByName != null)
		{
			theCategory = (Mission.MissionCategory)int.Parse(nodeByName.InnerText);
		}
		string innerText = Command_Core.Misc.GetNodeByName(node.ChildNodes, "Name").InnerText;
		int num = 0;
		List<ReferencePoint> theCourse = new List<ReferencePoint>();
		nodeByName = Command_Core.Misc.GetNodeByName(node.ChildNodes, "Type");
		if (nodeByName != null)
		{
			num = int.Parse(nodeByName.InnerText);
		}
		switch (node.Name)
		{
		case "MineClearingMission":
			mission = new MineClearingMission(side, scen, innerText, theCategory, theCourse, ValidateArea: false);
			goto IL_0215;
		case "Strike":
			mission = new Strike(side, scen, innerText, theCategory, (Strike.StrikeType)num);
			goto IL_0215;
		case "Patrol":
			mission = new Patrol(side, scen, innerText, theCategory, theCourse, (GlobalVariables.PatrolType)num, ValidateArea: false);
			goto IL_0215;
		case "TaskPool":
			mission = new TaskPool(ref side, ref scen, innerText, theCategory);
			goto IL_0215;
		case "FireMission":
			mission = new FireMission(side, scen, innerText, theCategory);
			goto IL_0215;
		case "FerryMission":
			mission = new FerryMission(side, scen, innerText, theCategory, null);
			goto IL_0215;
		case "CargoMission":
			mission = new CargoMission(side, scen, innerText, theCategory, theCourse, ValidateArea: false);
			goto IL_0215;
		case "MiningMission":
			mission = new MiningMission(side, scen, innerText, theCategory, theCourse, ValidateArea: false);
			goto IL_0215;
		case "SupportMission":
			mission = new SupportMission(ref side, ref scen, innerText, theCategory, ref theCourse, ValidateArea: false);
			goto IL_0215;
		default:
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new NotImplementedException();
			}
			IL_0215:
			if (mission != null)
			{
				string objectID = mission.ObjectID;
				smethod_0(mission, scen, side, node, dict);
				if (useGeneratedID)
				{
					mission.ObjectID = objectID;
				}
			}
			return mission;
		}
	}

	public static Mission FindMissionByID(IEnumerable<Mission> list, string missionID)
	{
		Mission result = null;
		if (list != null && list.Count() > 0 && !string.IsNullOrEmpty(missionID))
		{
			IEnumerable<Mission> source = list.Where((Mission M) => M.ObjectID == missionID);
			if (source.Count() > 0)
			{
				result = source.First();
			}
		}
		return result;
	}

	public static Mission.Flight FindMissionFlightByID(Mission mission, string flightID)
	{
		if (mission != null)
		{
			foreach (Mission.Flight flight in mission.FlightList)
			{
				if (flight.ObjectID == flightID)
				{
					return flight;
				}
			}
		}
		return null;
	}

	public static List<ActiveUnit> ResyncFlightPlans(Scenario scen, Side side, Mission mission)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		if (scen != null && side != null && mission != null)
		{
			if (mission.FlightList.Count >= 1)
			{
				foreach (ActiveUnit unit in side.Units)
				{
					if (unit.IsAircraft && unit.ActiveMissionOrPackage() == mission)
					{
						Aircraft aircraft = (Aircraft)unit;
						Mission.Flight flight = ((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: false);
						Mission.Flight flight2 = null;
						if (flight != null)
						{
							foreach (Mission.Flight flight3 in mission.FlightList)
							{
								if (flight3.ObjectID == flight.ObjectID)
								{
									((ActiveUnit_Navigator)aircraft.Navigator).set_Flight(HierarchySearch: false, flight3);
									flight2 = flight3;
									break;
								}
							}
						}
						if (flight2 != null)
						{
							list.Add(unit);
							for (int i = 0; i < aircraft.Navigator.PlottedCourse.Count(); i++)
							{
								if (aircraft.Navigator.PlottedCourse[i] != null && aircraft.Navigator.PlottedCourse[i].Category == Waypoint.WaypointCategory.FlightPlan)
								{
									Waypoint[] flightPlan = flight2.FlightPlan;
									foreach (Waypoint waypoint in flightPlan)
									{
										if (aircraft.Navigator.PlottedCourse[i].ObjectID == waypoint.ObjectID)
										{
											aircraft.Navigator.PlottedCourse[i] = waypoint;
											break;
										}
									}
								}
							}
						}
					}
				}
				return list;
			}
			return list;
		}
		return list;
	}

	public static Mission.Flight FindFlightUsingThisWaypoint(Scenario scen, Side side, string waypointID)
	{
		if (scen != null && side != null && !string.IsNullOrEmpty(waypointID))
		{
			foreach (Mission mission in side.Missions)
			{
				foreach (Mission.Flight flight in mission.FlightList)
				{
					Waypoint[] flightPlan = flight.FlightPlan;
					for (int i = 0; i < flightPlan.Length; i++)
					{
						if (flightPlan[i].ObjectID == waypointID)
						{
							return flight;
						}
					}
				}
			}
		}
		return null;
	}

	public static Waypoint FindFlightPlanWaypointByID(Scenario scen, Side side, string waypointID)
	{
		if (scen != null && side != null && !string.IsNullOrEmpty(waypointID))
		{
			foreach (Mission mission in side.Missions)
			{
				foreach (Mission.Flight flight in mission.FlightList)
				{
					Waypoint[] flightPlan = flight.FlightPlan;
					foreach (Waypoint waypoint in flightPlan)
					{
						if (waypoint.ObjectID == waypointID)
						{
							return waypoint;
						}
					}
				}
			}
		}
		return null;
	}

	public static Module_Unit.Unit FindUnitUsingThisFlightPlanWaypoint(Scenario scen, Side side, string waypointID)
	{
		return FindFlightUsingThisWaypoint(scen, side, waypointID)?.get_ReferenceUnit(scen);
	}

	public static List<ActiveUnit> GetUnitsAssignedToMission(Scenario scen, Side side, Mission mission)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		if (scen != null && side != null && mission != null)
		{
			foreach (ActiveUnit unit in side.Units)
			{
				if (unit.ActiveMissionOrPackage() == mission)
				{
					list.Add(unit);
				}
			}
			return list;
		}
		return list;
	}

	static MissionHelper()
	{
		Class72.smethod_20();
	}
}
