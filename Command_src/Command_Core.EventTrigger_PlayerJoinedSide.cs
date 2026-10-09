using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_PlayerJoinedSide : EventTrigger
{
	public bool IsFulfilled => true;

	public EventTrigger_PlayerJoinedSide()
	{
		Type = EventTriggerType.PlayerJoinedSide;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventTrigger_PlayerJoinedSide");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10052014", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_PlayerJoinedSide FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		EventTrigger_PlayerJoinedSide result;
		try
		{
			EventTrigger_PlayerJoinedSide eventTrigger_PlayerJoinedSide = new EventTrigger_PlayerJoinedSide();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				string name = val.Name;
				if (Operators.CompareString(name, "ID", false) == 0)
				{
					eventTrigger_PlayerJoinedSide.ObjectID_Set(val.InnerText);
				}
				else if (Operators.CompareString(name, "Description", false) == 0)
				{
					eventTrigger_PlayerJoinedSide.Description = val.InnerText;
				}
			}
			result = eventTrigger_PlayerJoinedSide;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10052114", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new EventTrigger_PlayerJoinedSide();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override EventTrigger Clone()
	{
		EventTrigger_PlayerJoinedSide obj = (EventTrigger_PlayerJoinedSide)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static EventTrigger_PlayerJoinedSide()
	{
		Class72.smethod_20();
	}
}
