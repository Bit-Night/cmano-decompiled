using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventCondition_ScenHasStarted : EventCondition
{
	public bool Modifier_NOT;

	public override bool IsTrue
	{
		get
		{
			bool result;
			try
			{
				result = (Modifier_NOT ? (!theScen.HasStarted) : theScen.HasStarted);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101321", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num = 0;
				}
				else
				{
					num = 0;
				}
				result = (byte)num != 0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public EventCondition_ScenHasStarted()
	{
		Type = EventConditionType.ScenHasStarted;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventCondition_ScenHasStarted");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			if (Modifier_NOT)
			{
				theWriter.WriteElementString("NOT", 1.ToString());
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101322", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventCondition_ScenHasStarted FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		EventCondition_ScenHasStarted result;
		try
		{
			EventCondition_ScenHasStarted eventCondition_ScenHasStarted = new EventCondition_ScenHasStarted();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					eventCondition_ScenHasStarted.ObjectID_Set(val.InnerText);
					break;
				case "NOT":
					eventCondition_ScenHasStarted.Modifier_NOT = true;
					break;
				case "Description":
					eventCondition_ScenHasStarted.Description = val.InnerText;
					break;
				}
			}
			result = eventCondition_ScenHasStarted;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101323", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new EventCondition_ScenHasStarted();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override EventCondition Clone()
	{
		EventCondition_ScenHasStarted obj = (EventCondition_ScenHasStarted)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static EventCondition_ScenHasStarted()
	{
		Class72.smethod_20();
	}
}
