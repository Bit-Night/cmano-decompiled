using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventAction_ChangeMissionStatus : EventAction
{
	public string MissionID;

	public Mission.MissionStatus NewStatus;

	public EventAction_ChangeMissionStatus()
	{
		Type = EventActionType.ChangeMissionStatus;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventAction_ChangeMissionStatus");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteElementString("MissionID", MissionID);
			byte newStatus = (byte)NewStatus;
			theWriter.WriteElementString("NewStatus", newStatus.ToString());
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100502", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventAction_ChangeMissionStatus FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		EventAction_ChangeMissionStatus eventAction_ChangeMissionStatus = new EventAction_ChangeMissionStatus();
		EventAction_ChangeMissionStatus result;
		try
		{
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					eventAction_ChangeMissionStatus.ObjectID_Set(val.InnerText);
					break;
				case "Description":
					eventAction_ChangeMissionStatus.Description = val.InnerText;
					break;
				case "MissionID":
					eventAction_ChangeMissionStatus.MissionID = val.InnerText;
					break;
				case "NewStatus":
					eventAction_ChangeMissionStatus.NewStatus = (Mission.MissionStatus)Conversions.ToByte(val.InnerText);
					break;
				}
			}
			result = eventAction_ChangeMissionStatus;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100503", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new EventAction_ChangeMissionStatus();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void Execute(Scenario thescen, SimEvent theEv)
	{
		try
		{
			Side[] sides_ReadOnly = thescen.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				foreach (Mission mission in side.Missions)
				{
					if (string.CompareOrdinal(mission.ObjectID, MissionID) == 0)
					{
						mission.set_Status(thescen, NewStatus);
						break;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100504", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override EventAction Clone()
	{
		EventAction_ChangeMissionStatus obj = (EventAction_ChangeMissionStatus)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static EventAction_ChangeMissionStatus()
	{
		Class72.smethod_20();
	}
}
