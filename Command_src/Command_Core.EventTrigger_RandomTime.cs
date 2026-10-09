using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_RandomTime : EventTrigger
{
	public DateTime EarliestTime;

	public DateTime LatestTime;

	protected internal bool Fired;

	private DateTime? nullable_0;

	public bool isActualTimeSet => nullable_0.HasValue;

	public DateTime ActualTime
	{
		get
		{
			if (!nullable_0.HasValue)
			{
				if (LatestTime.Ticks < EarliestTime.Ticks)
				{
					double totalSeconds = new TimeSpan(EarliestTime.Ticks - LatestTime.Ticks).TotalSeconds;
					nullable_0 = LatestTime.AddSeconds(GameGeneral.GlobalRNG.Next(0, (int)Math.Round(totalSeconds)));
				}
				else
				{
					double totalSeconds = new TimeSpan(LatestTime.Ticks - EarliestTime.Ticks).TotalSeconds;
					nullable_0 = EarliestTime.AddSeconds(GameGeneral.GlobalRNG.Next(0, (int)Math.Round(totalSeconds)));
				}
			}
			return nullable_0.Value;
		}
	}

	public bool IsFulfilled
	{
		get
		{
			bool result = false;
			if (!Fired && ActualTime.CompareTo(theTime) <= 0)
			{
				result = true;
				Fired = true;
			}
			return result;
		}
	}

	public EventTrigger_RandomTime(DateTime theEarliestTime, DateTime theLatestTime)
	{
		Type = EventTriggerType.RandomTime;
		EarliestTime = theEarliestTime;
		LatestTime = theLatestTime;
		Fired = false;
	}

	private EventTrigger_RandomTime()
	{
		Type = EventTriggerType.RandomTime;
		Fired = false;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventTrigger_RandomTime");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteElementString("EarliestTime", EarliestTime.ToBinary().ToString());
			theWriter.WriteElementString("LatestTime", LatestTime.ToBinary().ToString());
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
			ex2?.Data.Add("Error at 100522", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_RandomTime FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		EventTrigger_RandomTime result;
		try
		{
			EventTrigger_RandomTime eventTrigger_RandomTime = new EventTrigger_RandomTime();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Description":
					eventTrigger_RandomTime.Description = val.InnerText;
					break;
				case "EarliestTime":
					eventTrigger_RandomTime.EarliestTime = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					break;
				case "LatestTime":
					eventTrigger_RandomTime.LatestTime = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					break;
				case "Fired":
					eventTrigger_RandomTime.Fired = true;
					break;
				case "ID":
					eventTrigger_RandomTime.ObjectID_Set(val.InnerText);
					break;
				}
			}
			result = eventTrigger_RandomTime;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100523", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new EventTrigger_RandomTime();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override EventTrigger Clone()
	{
		EventTrigger_RandomTime obj = (EventTrigger_RandomTime)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static EventTrigger_RandomTime()
	{
		Class72.smethod_20();
	}
}
