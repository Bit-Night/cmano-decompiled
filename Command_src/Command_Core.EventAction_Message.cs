using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventAction_Message : EventAction
{
	public string SideID;

	public string Text;

	public EventAction_Message()
	{
		Type = EventActionType.Message;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventAction_Message");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteElementString("SideID", SideID);
			theWriter.WriteElementString("Text", Text);
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100507", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventAction_Message FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		EventAction_Message result;
		try
		{
			EventAction_Message eventAction_Message = new EventAction_Message();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "SideID":
					eventAction_Message.SideID = val.InnerText;
					break;
				case "Text":
					eventAction_Message.Text = val.InnerText;
					break;
				case "Description":
					eventAction_Message.Description = val.InnerText;
					break;
				case "ID":
					eventAction_Message.ObjectID_Set(val.InnerText);
					break;
				}
			}
			result = eventAction_Message;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100508", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new EventAction_Message();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void Execute(Scenario thescen, SimEvent theEv)
	{
		try
		{
			Side[] sides_ReadOnly = thescen.Sides_ReadOnly;
			int num = 0;
			Side side;
			while (true)
			{
				if (num < sides_ReadOnly.Length)
				{
					side = sides_ReadOnly[num];
					if (Operators.CompareString(side.ObjectID, SideID, false) == 0)
					{
						break;
					}
					num = checked(num + 1);
					continue;
				}
				return;
			}
			thescen.AddMessage(Text, Text, LoggedMessage.MessageType.SpecialMessage, 0, null, side);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100509", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override EventAction Clone()
	{
		EventAction_Message obj = (EventAction_Message)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static EventAction_Message()
	{
		Class72.smethod_20();
	}
}
