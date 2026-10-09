using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class EventAction : ScenarioObject
{
	public enum EventActionType : byte
	{
		Points,
		EndScenario,
		TeleportInArea,
		Message,
		ChangeMissionStatus,
		LuaScript
	}

	public string Description;

	public EventActionType Type;

	public virtual void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		throw new NotImplementedException();
	}

	public static EventAction FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		EventAction result = default(EventAction);
		try
		{
			switch (theNode.Name)
			{
			case "EventAction_EndScenario":
				result = EventAction_EndScenario.FromXML(theNode, theDictionary, theScen);
				return result;
			case "EventAction_TeleportInArea":
				result = EventAction_TeleportInArea.FromXML(theNode, theDictionary, theScen);
				return result;
			default:
				throw new NotImplementedException();
			case "EventAction_LuaScript":
				result = EventAction_LuaScript.FromXML(theNode, theDictionary, theScen);
				return result;
			case "EventAction_ChangeMissionStatus":
				result = EventAction_ChangeMissionStatus.FromXML(theNode, theDictionary, theScen);
				return result;
			case "EventAction_Message":
				result = EventAction_Message.FromXML(theNode, theDictionary, theScen);
				return result;
			case "EventAction_Points":
				result = EventAction_Points.FromXML(theNode, theDictionary, theScen);
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100501", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual void Execute(Scenario theScen, SimEvent theEv)
	{
		throw new NotImplementedException();
	}

	public virtual void Execute(Scenario theScen)
	{
		throw new NotImplementedException();
	}

	public virtual EventAction Clone()
	{
		throw new NotImplementedException();
	}

	static EventAction()
	{
		Class72.smethod_20();
	}
}
