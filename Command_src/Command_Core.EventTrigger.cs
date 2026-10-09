using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public abstract class EventTrigger : ScenarioObject
{
	public enum EventTriggerType : byte
	{
		UnitDestroyed,
		Points,
		Time,
		UnitDamaged,
		UnitRemainsInArea,
		UnitEntersArea,
		RandomTime,
		UnitDetected,
		ScenLoaded,
		RegularTime,
		ScenEnded,
		UnitBaseStatus,
		UnitEmissions,
		UnitCargoMoved,
		PlayerJoinedSide
	}

	public string Description;

	public EventTriggerType Type;

	public EventTrigger()
	{
	}

	public virtual void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		throw new NotImplementedException();
	}

	public static EventTrigger FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		EventTrigger result;
		try
		{
			switch (theNode.Name)
			{
			case "EventTrigger_PlayerJoinedSide":
				result = EventTrigger_PlayerJoinedSide.FromXML(theNode, theDictionary, theScen);
				break;
			case "EventTrigger_Time":
				result = EventTrigger_Time.FromXML(theNode, theDictionary, theScen);
				break;
			case "EventTrigger_UnitCargoMoved":
				result = EventTrigger_UnitCargoMoved.FromXML(theNode, theDictionary, theScen);
				break;
			case "EventTrigger_RandomTime":
				result = EventTrigger_RandomTime.FromXML(theNode, theDictionary, theScen);
				break;
			case "EventTrigger_UnitRemainsInArea":
			case "EventTrigger_UnitInArea":
				result = EventTrigger_UnitRemainsInArea.FromXML(theNode, theDictionary, theScen);
				break;
			case "EventTrigger_ScenEnded":
				result = EventTrigger_ScenEnded.FromXML(theNode, theDictionary, theScen);
				break;
			case "EventTrigger_UnitEntersArea":
				result = EventTrigger_UnitEntersArea.FromXML(theNode, theDictionary, theScen);
				break;
			case "EventTrigger_Points":
				result = EventTrigger_Points.FromXML(theNode, theDictionary, theScen);
				break;
			case "EventTrigger_RegularTime":
				result = EventTrigger_RegularTime.FromXML(theNode, theDictionary, theScen);
				break;
			case "EventTrigger_UnitBaseStatus":
				result = EventTrigger_UnitBaseStatus.FromXML(theNode, theDictionary, theScen);
				break;
			case "EventTrigger_UnitDestroyed":
				result = EventTrigger_UnitDestroyed.FromXML(theNode, theDictionary, theScen);
				break;
			case "EventTrigger_UnitDetected":
				result = EventTrigger_UnitDetected.FromXML(theNode, theDictionary, theScen);
				break;
			case "EventTrigger_UnitEmissions":
				result = EventTrigger_UnitEmissions.FromXML(theNode, theDictionary, theScen);
				break;
			case "EventTrigger_ScenLoaded":
				result = EventTrigger_ScenLoaded.FromXML(theNode, theDictionary, theScen);
				break;
			default:
				throw new NotImplementedException();
			case "EventTrigger_UnitDamaged":
				result = EventTrigger_UnitDamaged.FromXML(theNode, theDictionary, theScen);
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100519", "");
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

	public virtual EventTrigger Clone()
	{
		throw new NotImplementedException();
	}

	static EventTrigger()
	{
		Class72.smethod_20();
	}
}
