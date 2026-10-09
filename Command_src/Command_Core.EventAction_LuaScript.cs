using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventAction_LuaScript : EventAction
{
	public enum EventAction_LuaScript_Type : byte
	{
		EventAction,
		WaypointAction
	}

	public string ScriptText;

	public EventAction_LuaScript_Type ScriptForType;

	public EventAction_LuaScript()
	{
		Type = EventActionType.LuaScript;
		ScriptForType = EventAction_LuaScript_Type.EventAction;
	}

	public EventAction_LuaScript(EventAction_LuaScript_Type NonEventAction)
	{
		Type = EventActionType.LuaScript;
		ScriptForType = NonEventAction;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventAction_LuaScript");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteElementString("ScriptText", ScriptText);
			byte scriptForType = (byte)ScriptForType;
			theWriter.WriteElementString("ScriptFor", scriptForType.ToString());
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101317", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventAction_LuaScript FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		EventAction_LuaScript result;
		try
		{
			EventAction_LuaScript eventAction_LuaScript = new EventAction_LuaScript();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					eventAction_LuaScript.ObjectID_Set(val.InnerText);
					break;
				case "Description":
					eventAction_LuaScript.Description = val.InnerText;
					break;
				case "ScriptFor":
					eventAction_LuaScript.ScriptForType = (EventAction_LuaScript_Type)Enum.Parse(typeof(EventAction_LuaScript_Type), val.InnerText, ignoreCase: true);
					break;
				case "Type":
					eventAction_LuaScript.ScriptForType = (EventAction_LuaScript_Type)Enum.Parse(typeof(EventAction_LuaScript_Type), val.InnerText, ignoreCase: true);
					break;
				case "ScriptText":
					eventAction_LuaScript.ScriptText = val.InnerText;
					break;
				}
			}
			result = eventAction_LuaScript;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101315", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new EventAction_LuaScript();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void Execute(Scenario thescen, SimEvent theEv)
	{
		try
		{
			thescen.Scenario_LuaSandbox.RunScript(ScriptText, RunInteractively: false, theEv.Description);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			thescen.AddMessage("Lua script execution error: " + ex2.Source + " " + ex2.Message, "Lua script error!", LoggedMessage.MessageType.EventEngine, 0, null);
			ex2?.Data.Add("Error at 101316", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			_ = Debugger.IsAttached;
			ProjectData.ClearProjectError();
		}
	}

	public override void Execute(Scenario thescen)
	{
		try
		{
			thescen.Scenario_LuaSandbox.RunScript(ScriptText, RunInteractively: false, Description);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			thescen.AddMessage("Lua script execution error: " + ex2.Source + " " + ex2.Message, "Lua script error!", LoggedMessage.MessageType.EventEngine, 0, null);
			ex2?.Data.Add("Error at 101316b", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			_ = Debugger.IsAttached;
			ProjectData.ClearProjectError();
		}
	}

	public override EventAction Clone()
	{
		EventAction_LuaScript obj = (EventAction_LuaScript)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static EventAction_LuaScript()
	{
		Class72.smethod_20();
	}
}
