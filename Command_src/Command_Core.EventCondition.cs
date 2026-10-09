using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Xml;

namespace Command_Core;

public class EventCondition : ScenarioObject
{
	public enum EventConditionType : byte
	{
		SidePosture,
		ScenHasStarted,
		LuaScript
	}

	public string Description;

	public EventConditionType Type;

	public virtual bool IsTrue
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public virtual void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		throw new NotImplementedException();
	}

	public static EventCondition FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		return theNode.Name switch
		{
			"EventCondition_ScenHasStarted" => EventCondition_ScenHasStarted.FromXML(theNode, theDictionary, theScen), 
			"EventCondition_LuaScript" => EventCondition_LuaScript.FromXML(theNode, theDictionary, theScen), 
			"EventCondition_SidePosture" => EventCondition_SidePosture.FromXML(theNode, theDictionary, theScen), 
			_ => throw new NotImplementedException(), 
		};
	}

	public virtual EventCondition Clone()
	{
		throw new NotImplementedException();
	}

	static EventCondition()
	{
		Class72.smethod_20();
	}
}
