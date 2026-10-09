using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Group_Navigator : ActiveUnit_Navigator
{
	public override bool SprintDrift
	{
		get
		{
			Group obj = (Group)myUnit;
			if (Information.IsNothing((object)obj.GroupLead))
			{
				obj.DesignateGroupLead_Auto();
			}
			if (!Information.IsNothing((object)obj.GroupLead))
			{
				return obj.GroupLead.Navigator.SprintDrift;
			}
			return false;
		}
		set
		{
			Group obj = (Group)myUnit;
			if (Information.IsNothing((object)obj.GroupLead))
			{
				obj.DesignateGroupLead_Auto();
			}
			if (!Information.IsNothing((object)obj.GroupLead))
			{
				obj.GroupLead.Navigator.SprintDrift = value;
			}
		}
	}

	public override float? SprintDrift_AverageSpeed
	{
		get
		{
			Group obj = (Group)myUnit;
			if (Information.IsNothing((object)obj.GroupLead))
			{
				obj.DesignateGroupLead_Auto();
			}
			if (Information.IsNothing((object)obj.GroupLead))
			{
				return 0f;
			}
			return obj.GroupLead.Navigator.SprintDrift_AverageSpeed;
		}
		set
		{
			Group obj = (Group)myUnit;
			if (Information.IsNothing((object)obj.GroupLead))
			{
				obj.DesignateGroupLead_Auto();
			}
			if (!Information.IsNothing((object)obj.GroupLead))
			{
				obj.GroupLead.Navigator.SprintDrift_AverageSpeed = value;
			}
		}
	}

	public override GeoPoint SprintDrift_Marker
	{
		get
		{
			Group obj = (Group)myUnit;
			if (Information.IsNothing((object)obj.GroupLead))
			{
				obj.DesignateGroupLead_Auto();
			}
			if (Information.IsNothing((object)obj.GroupLead))
			{
				return new GeoPoint();
			}
			return obj.GroupLead.Navigator.SprintDrift_Marker;
		}
		set
		{
			Group obj = (Group)myUnit;
			if (Information.IsNothing((object)obj.GroupLead))
			{
				obj.DesignateGroupLead_Auto();
			}
			if (!Information.IsNothing((object)obj.GroupLead))
			{
				obj.GroupLead.Navigator.SprintDrift_Marker = value;
			}
		}
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("Group_Navigator");
			if (AvoidCavitation)
			{
				theWriter.WriteElementString("AvCav", AvoidCavitation.ToString());
			}
			theWriter.WriteStartElement("PlottedCourse");
			List<Waypoint> list = new List<Waypoint>();
			list.AddRange(PlottedCourse);
			foreach (Waypoint item in list)
			{
				if (!Information.IsNothing((object)item))
				{
					item.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				}
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("PC_PP");
			List<Waypoint> list2 = new List<Waypoint>();
			list2.AddRange(base.PlottedCourse_PrePlanned);
			foreach (Waypoint item2 in list2)
			{
				if (!Information.IsNothing((object)item2))
				{
					item2.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				}
			}
			theWriter.WriteEndElement();
			theWriter.WriteElementString("ManualPlotOverride", ManualPlotOverride.ToString());
			if (!Information.IsNothing((object)SupportMission_NextRefPoint))
			{
				theWriter.WriteStartElement("SupportMission_NextRefPoint");
				theWriter.WriteRaw(SupportMission_NextRefPoint.ToXML(ref ObjectsAlreadySerialized));
				theWriter.WriteEndElement();
			}
			if (PreviousWaypointTime.HasValue)
			{
				theWriter.WriteElementString("PreviousWaypointTime", PreviousWaypointTime.Value.ToBinary().ToString());
			}
			if (PreviousWaypointType.HasValue)
			{
				theWriter.WriteElementString("PreviousWaypointType", PreviousWaypointType.Value.ToString());
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100620", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Group_Navigator FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected O, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected O, but got Unknown
		Group_Navigator result = default(Group_Navigator);
		try
		{
			Group_Navigator group_Navigator = new Group_Navigator(ref theAU);
			group_Navigator.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "PreviousWaypointType":
					if (!Versioned.IsNumeric((object)val.InnerText))
					{
						group_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), val.InnerText, ignoreCase: true);
					}
					else
					{
						group_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Conversions.ToInteger(val.InnerText);
					}
					break;
				case "AvCav":
					group_Navigator.AvoidCavitation = Misc.ParseBool(val.InnerText);
					break;
				case "PreviousWaypointTime":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					group_Navigator.PreviousWaypointTime = value;
					break;
				}
				case "ManualPlotOverride":
					group_Navigator.ManualPlotOverride = Misc.ParseBool(val.InnerText);
					break;
				case "SupportMission_NextRefPoint":
				{
					XmlNode theNode4 = val.ChildNodes[0];
					group_Navigator.SupportMission_NextRefPoint = ReferencePoint.FromXML(ref theNode4, ref theDictionary, theAU.ParentScen);
					break;
				}
				case "PC_PP":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						Waypoint theAC2 = Waypoint.FromXML(ref theNode3, ref theDictionary, theAU.ParentScen);
						ArrayExtensions.Add(ref group_Navigator._PlottedCourse_PrePlanned, theAC2);
					}
					break;
				case "PlottedCourse":
					foreach (XmlNode childNode3 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode3;
						Waypoint theAC = Waypoint.FromXML(ref theNode2, ref theDictionary, theAU.ParentScen);
						ArrayExtensions.Add(ref group_Navigator._PlottedCourse, theAC);
					}
					break;
				}
			}
			result = group_Navigator;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100621", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void PostDeserializationHousekeeping(ref Scenario theScen, ConcurrentDictionary<string, ScenarioObject> theDictionary, bool GameIsRunning)
	{
		base.PostDeserializationHousekeeping(ref theScen, theDictionary, GameIsRunning);
		if (_PlottedCourse == null || _PlottedCourse.Count() <= 0)
		{
			return;
		}
		Waypoint waypoint = _PlottedCourse[0];
		List<ActiveUnit> list = ((Group)myUnit).Units.Values.ToList();
		foreach (ActiveUnit item in list)
		{
			if (!item.IsAircraft && !item.IsGroupLead() && item.Navigator.HasPlottedCourse() && item.Navigator.PlottedCourse[0] == waypoint)
			{
				item.Navigator.ClearPlottedCourse();
			}
		}
	}

	public Group_Navigator(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public override void ClearPlottedCourse(bool PlayerIsPlottingCourse = false, bool ClearResumeFlightPlanWaypoint = true)
	{
		base.ClearPlottedCourse(PlayerIsPlottingCourse, ClearResumeFlightPlanWaypoint);
		try
		{
			if (!myUnit.IsGroup)
			{
				return;
			}
			foreach (ActiveUnit value in ((Group)myUnit).Units.Values)
			{
				if (!value.IsGroupLead())
				{
					value.Navigator.ClearPlottedCourse(PlayerIsPlottingCourse, ClearResumeFlightPlanWaypoint);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100622", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void FollowPlottedCourse(float elapsedTime)
	{
	}

	public override void ResetTimeToNextPathfinderCheck()
	{
		try
		{
			if (!myUnit.IsGroup)
			{
				return;
			}
			foreach (ActiveUnit value in ((Group)myUnit).Units.Values)
			{
				value.Navigator.ResetTimeToNextPathfinderCheck();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void FollowSupportMissionCourse(float elapsedTime, bool IsInTransit)
	{
	}

	public override bool ExtendIfNecessary(float elapsedTime, ref Waypoint theWaypoint, double TargetLat, double TargetLon, float Buffer_Seconds, float Buffer_Distance_nm, float theTurnRate, Misc.ExtendPhase Phase = Misc.ExtendPhase.Standard)
	{
		return false;
	}

	static Group_Navigator()
	{
		Class72.smethod_20();
	}
}
