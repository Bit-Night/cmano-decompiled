using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using Command_Core;

namespace CommandNetcode.RT;

public class DoctrineHelper
{
	public enum DoctrineSubject : short
	{
		None = -1,
		ActiveUnit,
		HostUnit,
		Group,
		Side,
		Waypoint,
		Mission,
		MissionEscort
	}

	public static DoctrineSubject GetSubjectType(ScenarioObject subject)
	{
		int result;
		if (subject == null)
		{
			result = -1;
		}
		else
		{
			if (subject.IsActiveUnit)
			{
				AirFacility[] airFacilities_ReadOnly = ((ActiveUnit)subject).AirFacilities_ReadOnly;
				for (int i = 0; i < airFacilities_ReadOnly.Length; i++)
				{
					if (airFacilities_ReadOnly[i].HostedAircraft.Count() > 0)
					{
						return DoctrineSubject.HostUnit;
					}
				}
				return DoctrineSubject.ActiveUnit;
			}
			if (subject.IsGroup)
			{
				return DoctrineSubject.Group;
			}
			if (subject.IsWaypoint)
			{
				return DoctrineSubject.Waypoint;
			}
			if (subject.IsMission)
			{
				return DoctrineSubject.Mission;
			}
			if (subject.GetType().Equals(typeof(Side)))
			{
				return DoctrineSubject.Side;
			}
			result = -1;
		}
		return (DoctrineSubject)result;
	}

	public static bool GetSubjectTypeAndDoctrine(Scenario scen, ScenarioObject subject, out DoctrineSubject subjectType, out Doctrine subjectDoctrine)
	{
		subjectType = DoctrineSubject.None;
		subjectDoctrine = null;
		if (subject != null)
		{
			subjectType = GetSubjectType(subject);
			switch (subjectType)
			{
			case DoctrineSubject.ActiveUnit:
			case DoctrineSubject.HostUnit:
				subjectDoctrine = ((ActiveUnit)subject).Doctrine;
				break;
			case DoctrineSubject.Group:
				subjectDoctrine = ((Group)subject).Doctrine;
				break;
			case DoctrineSubject.Side:
				subjectDoctrine = ((Side)subject).Doctrine;
				break;
			case DoctrineSubject.Waypoint:
				subjectDoctrine = ((Waypoint)subject).GetDoctrine(scen);
				break;
			case DoctrineSubject.Mission:
				subjectDoctrine = ((Mission)subject).Doctrine;
				break;
			case DoctrineSubject.MissionEscort:
				subjectDoctrine = ((Strike)subject).Doctrine_Escorts;
				break;
			}
		}
		return subjectDoctrine != null;
	}

	public static bool UpdateDoctrineFromXML(Scenario scen, string subjectID, DoctrineSubject subjectType, string string_0, out Doctrine doctrine)
	{
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		doctrine = null;
		ScenarioObject theSubject = null;
		switch (subjectType)
		{
		case DoctrineSubject.ActiveUnit:
		case DoctrineSubject.HostUnit:
		case DoctrineSubject.Group:
		{
			ActiveUnit value = null;
			if (scen.ActiveUnits.TryGetValue(subjectID, out value))
			{
				doctrine = value.Doctrine;
				theSubject = value;
			}
			break;
		}
		case DoctrineSubject.Side:
		{
			Side side = Array.Find(scen.Sides_ReadOnly, (Side S) => S.ObjectID == subjectID);
			if (side != null)
			{
				doctrine = side.Doctrine;
				theSubject = side;
			}
			break;
		}
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case DoctrineSubject.Mission:
		case DoctrineSubject.MissionEscort:
		{
			Side currentSide = scen.GetCurrentSide();
			if (currentSide == null || currentSide.Missions.Count <= 0)
			{
				break;
			}
			Mission mission = MissionHelper.FindMissionByID(currentSide.Missions, subjectID);
			if (mission == null)
			{
				break;
			}
			theSubject = mission;
			if (subjectType == DoctrineSubject.MissionEscort)
			{
				if (mission.GetType().Equals(typeof(Strike)))
				{
					Strike strike = (Strike)mission;
					doctrine = strike.Doctrine_Escorts;
				}
			}
			else
			{
				doctrine = mission.Doctrine;
			}
			break;
		}
		}
		if (doctrine != null)
		{
			XmlNode theNode = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(string_0)));
			Doctrine.FromXML(scen, ref theNode, theSubject, doctrine, reinitializeObject: true);
			return true;
		}
		return false;
	}

	static DoctrineHelper()
	{
		Class72.smethod_20();
	}
}
