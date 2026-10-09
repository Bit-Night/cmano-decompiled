using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class LandingPlan
{
	public int ID;

	public Side Side;

	public string Name;

	public Dictionary<Mission, Mission> Missions;

	public List<string> _SerializedMissionsGUIDS;

	public List<UnitLineWrapper> UnitLineWrappers;

	public List<LandingZoneWrapper> LandingZoneWrappers;

	public Dictionary<ActiveUnit, Transport> AllowedTransport;

	public bool Rebuilt;

	public LandingPlan(Side _Side, List<Mission> _Missions, string _Name)
	{
		Missions = new Dictionary<Mission, Mission>();
		_SerializedMissionsGUIDS = new List<string>();
		UnitLineWrappers = new List<UnitLineWrapper>();
		LandingZoneWrappers = new List<LandingZoneWrapper>();
		AllowedTransport = new Dictionary<ActiveUnit, Transport>();
		Side = _Side;
		ID = method_1() + 1;
		Name = _Name;
		AddMissions(_Missions);
		method_0();
	}

	public LandingPlan(Side _Side)
	{
		Missions = new Dictionary<Mission, Mission>();
		_SerializedMissionsGUIDS = new List<string>();
		UnitLineWrappers = new List<UnitLineWrapper>();
		LandingZoneWrappers = new List<LandingZoneWrapper>();
		AllowedTransport = new Dictionary<ActiveUnit, Transport>();
		Side = _Side;
	}

	internal bool HasBeenGenerated()
	{
		return Missions.Count > 0;
	}

	public void AddMission(Mission MissionsToAdd)
	{
		if (Missions.ContainsKey(MissionsToAdd))
		{
			MissionsToAdd.LandingPlan = this;
		}
		else
		{
			Missions.Add(MissionsToAdd, MissionsToAdd);
		}
	}

	public void AddMissions(List<Mission> MissionsToAdd)
	{
		foreach (Mission item in MissionsToAdd)
		{
			AddMission(item);
		}
	}

	private void method_0()
	{
		foreach (KeyValuePair<Mission, Mission> item in Missions.ToList())
		{
			item.Key.LandingPlan = this;
		}
	}

	private int method_1()
	{
		int num = 0;
		foreach (LandingPlan landingPlan in Side.LandingPlans)
		{
			if (landingPlan.ID > num)
			{
				num = landingPlan.ID;
			}
		}
		return num;
	}

	public void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("LandingPlans");
			theWriter.WriteElementString("LocalID", ID.ToString());
			theWriter.WriteElementString("Name", Name.ToString());
			theWriter.WriteStartElement("Missions");
			foreach (Mission value in Missions.Values)
			{
				theWriter.WriteElementString("Mission_ObjectID", value.ObjectID);
			}
			theWriter.WriteEndElement();
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at LandingPlanner_000", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static LandingPlan FromXML(ref XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Side TheSide, ref Scenario theScen)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		LandingPlan result;
		try
		{
			LandingPlan landingPlan = new LandingPlan(TheSide);
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Name":
					landingPlan.Name = val.InnerText;
					break;
				case "Missions":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode val2 = childNode2;
						landingPlan._SerializedMissionsGUIDS.Add(val2.InnerText);
					}
					break;
				case "LocalID":
					landingPlan.ID = Conversions.ToInteger(val.InnerText);
					break;
				}
			}
			result = landingPlan;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at LandingPlanner_001", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static LandingPlan()
	{
		Class72.smethod_20();
	}
}
