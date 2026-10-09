using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_ScenEnded : EventTrigger
{
	public bool IsFulfilled
	{
		get
		{
			_ = theScen.HasEnded;
			return true;
		}
	}

	public EventTrigger_ScenEnded()
	{
		Type = EventTriggerType.ScenEnded;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventTrigger_ScenEnded");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100520", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_ScenEnded FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		EventTrigger_ScenEnded result;
		try
		{
			EventTrigger_ScenEnded eventTrigger_ScenEnded = new EventTrigger_ScenEnded();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				string name = val.Name;
				if (Operators.CompareString(name, "ID", false) != 0)
				{
					if (Operators.CompareString(name, "Description", false) == 0)
					{
						eventTrigger_ScenEnded.Description = val.InnerText;
					}
				}
				else
				{
					eventTrigger_ScenEnded.ObjectID_Set(val.InnerText);
				}
			}
			result = eventTrigger_ScenEnded;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100521", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new EventTrigger_ScenEnded();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override EventTrigger Clone()
	{
		EventTrigger_ScenEnded obj = (EventTrigger_ScenEnded)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static EventTrigger_ScenEnded()
	{
		Class72.smethod_20();
	}
}
