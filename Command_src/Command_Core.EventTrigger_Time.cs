using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_Time : EventTrigger
{
	public DateTime Time;

	protected internal bool Fired;

	public bool IsFulfilled
	{
		get
		{
			if (!Fired)
			{
				bool result = false;
				if (!Fired && Time.CompareTo(theTime) <= 0)
				{
					result = true;
					Fired = true;
				}
				return result;
			}
			return true;
		}
	}

	public EventTrigger_Time(DateTime theTime)
	{
		Type = EventTriggerType.Time;
		Time = theTime;
		Fired = false;
	}

	private EventTrigger_Time()
	{
		Type = EventTriggerType.Time;
		Fired = false;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventTrigger_Time");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteElementString("Time", Time.ToBinary().ToString());
			if (Fired)
			{
				theWriter.WriteElementString("Fired", 1.ToString());
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100524", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_Time FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		EventTrigger_Time result;
		try
		{
			EventTrigger_Time eventTrigger_Time = new EventTrigger_Time();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					eventTrigger_Time.ObjectID_Set(val.InnerText);
					break;
				case "Description":
					eventTrigger_Time.Description = val.InnerText;
					break;
				case "Fired":
					eventTrigger_Time.Fired = true;
					break;
				case "Time":
					eventTrigger_Time.Time = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					break;
				}
			}
			result = eventTrigger_Time;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100525", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new EventTrigger_Time();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override EventTrigger Clone()
	{
		EventTrigger_Time obj = (EventTrigger_Time)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static EventTrigger_Time()
	{
		Class72.smethod_20();
	}
}
