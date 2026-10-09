using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventCondition_LuaScript : EventCondition
{
	public string ScriptText;

	public override bool IsTrue
	{
		get
		{
			bool result = false;
			try
			{
				object[] array = theScen.Scenario_LuaSandbox.RunScript(ScriptText, RunInteractively: false, Description);
				int result2;
				if (array == null)
				{
					result2 = 0;
				}
				else
				{
					if (array.Count() > 0)
					{
						if (!bool.TryParse(array.ElementAt(0).ToString(), out result))
						{
							return false;
						}
						return result;
					}
					result2 = 0;
				}
				return (byte)result2 != 0;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101318", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public EventCondition_LuaScript()
	{
		Type = EventConditionType.LuaScript;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventCondition_LuaScript");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteElementString("ScriptText", ScriptText);
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101319", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventCondition_LuaScript FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		EventCondition_LuaScript result = default(EventCondition_LuaScript);
		try
		{
			EventCondition_LuaScript eventCondition_LuaScript = new EventCondition_LuaScript();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Description":
					eventCondition_LuaScript.Description = val.InnerText;
					break;
				case "ScriptText":
					eventCondition_LuaScript.ScriptText = val.InnerText;
					break;
				case "ID":
					eventCondition_LuaScript.ObjectID_Set(val.InnerText);
					break;
				}
			}
			result = eventCondition_LuaScript;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101320", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override EventCondition Clone()
	{
		EventCondition_LuaScript obj = (EventCondition_LuaScript)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static EventCondition_LuaScript()
	{
		Class72.smethod_20();
	}
}
