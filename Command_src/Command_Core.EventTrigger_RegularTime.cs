using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_RegularTime : EventTrigger
{
	public enum RegularTimeInterval
	{
		OneSecond,
		FiveSeconds,
		FifteenSeconds,
		ThirtySeconds,
		OneMinute,
		FiveMinutes,
		FifteenMinutes,
		ThirtyMinutes,
		OneHour,
		SixHours,
		TwelveHours,
		TwentyFourHours,
		EveryPulse
	}

	public RegularTimeInterval Interval;

	public bool IsFulfilled => Interval switch
	{
		RegularTimeInterval.OneSecond => theScen.SecondIsChangingOnThisPulse, 
		RegularTimeInterval.FiveSeconds => theScen.FifthSecondIsChangingOnThisPulse, 
		RegularTimeInterval.FifteenSeconds => theScen.FifteenthSecondIsChangingOnThisPulse, 
		RegularTimeInterval.ThirtySeconds => theScen.ThirtiethSecondIsChangingOnThisPulse, 
		RegularTimeInterval.OneMinute => theScen.MinuteIsChangingOnThisPulse, 
		RegularTimeInterval.FiveMinutes => theScen.FifthMinuteIsChangingOnThisPulse, 
		RegularTimeInterval.FifteenMinutes => theScen.FifteenthMinuteIsChangingOnThisPulse, 
		RegularTimeInterval.ThirtyMinutes => theScen.ThirtiethMinuteIsChangingOnThisPulse, 
		RegularTimeInterval.OneHour => theScen.HourIsChangingOnThisPulse, 
		RegularTimeInterval.SixHours => theScen.SixHourIsChangingOnThisPulse, 
		RegularTimeInterval.TwelveHours => theScen.TwelveHourIsChangingOnThisPulse, 
		RegularTimeInterval.TwentyFourHours => theScen.TwentyFourHourIsChangingOnThisPulse, 
		RegularTimeInterval.EveryPulse => true, 
		_ => false, 
	};

	public EventTrigger_RegularTime(RegularTimeInterval theInterval)
	{
		Type = EventTriggerType.RegularTime;
		Interval = theInterval;
	}

	public EventTrigger_RegularTime()
	{
		Type = EventTriggerType.RegularTime;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventTrigger_RegularTime");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			int interval = (int)Interval;
			theWriter.WriteElementString("Interval", interval.ToString());
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100320968409868", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_RegularTime FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		EventTrigger_RegularTime result = default(EventTrigger_RegularTime);
		try
		{
			EventTrigger_RegularTime eventTrigger_RegularTime = new EventTrigger_RegularTime();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Interval":
					eventTrigger_RegularTime.Interval = (RegularTimeInterval)Conversions.ToInteger(val.InnerText);
					break;
				case "Description":
					eventTrigger_RegularTime.Description = val.InnerText;
					break;
				case "ID":
					eventTrigger_RegularTime.ObjectID_Set(val.InnerText);
					break;
				}
			}
			result = eventTrigger_RegularTime;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10004356945678578882", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override EventTrigger Clone()
	{
		EventTrigger_RegularTime obj = (EventTrigger_RegularTime)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static EventTrigger_RegularTime()
	{
		Class72.smethod_20();
	}
}
