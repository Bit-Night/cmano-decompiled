using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventAction_EndScenario : EventAction
{
	public EventAction_EndScenario()
	{
		Type = EventActionType.EndScenario;
		Description = "End the scenario";
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventAction_EndScenario");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100505", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventAction_EndScenario FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		EventAction_EndScenario result;
		try
		{
			EventAction_EndScenario eventAction_EndScenario = new EventAction_EndScenario();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				string name = val.Name;
				if (Operators.CompareString(name, "ID", false) == 0)
				{
					eventAction_EndScenario.ObjectID_Set(val.InnerText);
				}
			}
			result = eventAction_EndScenario;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100506", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new EventAction_EndScenario();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void Execute(Scenario thescen, SimEvent theEv)
	{
		thescen.EndScenario();
	}

	public override EventAction Clone()
	{
		EventAction_EndScenario obj = (EventAction_EndScenario)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static EventAction_EndScenario()
	{
		Class72.smethod_20();
	}
}
