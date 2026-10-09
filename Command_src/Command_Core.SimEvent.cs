using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class SimEvent : ScenarioObject
{
	public string Description;

	public bool IsRepeatable;

	public bool IsActive;

	public bool IsShown;

	public short Probability;

	public List<EventTrigger> Triggers;

	public List<EventCondition> Conditions;

	public List<EventAction> Actions;

	public bool ConditionsAreMet
	{
		get
		{
			if (Conditions.Count == 0)
			{
				return true;
			}
			foreach (EventCondition condition in Conditions)
			{
				if (!condition.get_IsTrue(theScen, this))
				{
					return false;
				}
			}
			return true;
		}
	}

	public void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("SimEvent");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteElementString("IsRepeatable", IsRepeatable.ToString());
			theWriter.WriteElementString("IsActive", IsActive.ToString());
			theWriter.WriteElementString("IsShown", IsShown.ToString());
			theWriter.WriteElementString("Probability", Probability.ToString());
			theWriter.WriteStartElement("Triggers");
			foreach (EventTrigger trigger in Triggers)
			{
				if (!Information.IsNothing((object)trigger))
				{
					theWriter.WriteElementString("Trigger", trigger.ObjectID);
				}
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Conditions");
			foreach (EventCondition condition in Conditions)
			{
				if (!Information.IsNothing((object)condition))
				{
					theWriter.WriteElementString("Condition", condition.ObjectID);
				}
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Actions");
			foreach (EventAction action in Actions)
			{
				if (!Information.IsNothing((object)action))
				{
					theWriter.WriteElementString("Action", action.ObjectID);
				}
			}
			theWriter.WriteEndElement();
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100538", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static SimEvent FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		SimEvent result = default(SimEvent);
		try
		{
			SimEvent simEvent = new SimEvent();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Triggers":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode val4 = childNode2;
						EventTrigger item3 = theScen.EventTriggers[val4.InnerText];
						simEvent.Triggers.Add(item3);
					}
					break;
				case "Actions":
					foreach (XmlNode childNode3 in val.ChildNodes)
					{
						XmlNode val3 = childNode3;
						EventAction item2 = theScen.EventActions[val3.InnerText];
						simEvent.Actions.Add(item2);
					}
					break;
				case "IsActive":
					simEvent.IsActive = Misc.ParseBool(val.InnerText);
					break;
				case "IsRepeatable":
					simEvent.IsRepeatable = Misc.ParseBool(val.InnerText);
					break;
				case "Description":
					simEvent.Description = val.InnerText;
					break;
				case "Probability":
					simEvent.Probability = Conversions.ToShort(val.InnerText);
					break;
				case "IsShown":
					simEvent.IsShown = Misc.ParseBool(val.InnerText);
					break;
				case "ID":
					simEvent.ObjectID_Set(val.InnerText);
					break;
				case "Conditions":
					foreach (XmlNode childNode4 in val.ChildNodes)
					{
						XmlNode val2 = childNode4;
						EventCondition item = theScen.EventConditions[val2.InnerText];
						simEvent.Conditions.Add(item);
					}
					break;
				}
			}
			result = simEvent;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100539", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public SimEvent()
	{
		Triggers = new List<EventTrigger>();
		Conditions = new List<EventCondition>();
		Actions = new List<EventAction>();
		IsActive = true;
		IsRepeatable = false;
		IsShown = true;
		Probability = 100;
	}

	public SimEvent Clone()
	{
		SimEvent obj = (SimEvent)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		obj.Triggers = new List<EventTrigger>();
		obj.Triggers.AddRange(Triggers);
		obj.Conditions = new List<EventCondition>();
		obj.Conditions.AddRange(Conditions);
		obj.Actions = new List<EventAction>();
		obj.Actions.AddRange(Actions);
		return obj;
	}

	static SimEvent()
	{
		Class72.smethod_20();
	}
}
