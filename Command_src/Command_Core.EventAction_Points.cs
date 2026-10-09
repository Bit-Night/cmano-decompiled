using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventAction_Points : EventAction
{
	public string SideID;

	public int PointChange;

	public EventAction_Points()
	{
		Type = EventActionType.Points;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventAction_Points");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteElementString("SideID", SideID);
			theWriter.WriteElementString("PointChange", PointChange.ToString());
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100510", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventAction_Points FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		EventAction_Points result = default(EventAction_Points);
		try
		{
			EventAction_Points eventAction_Points = new EventAction_Points();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					eventAction_Points.ObjectID_Set(val.InnerText);
					break;
				case "Description":
					eventAction_Points.Description = val.InnerText;
					break;
				case "SideID":
					eventAction_Points.SideID = val.InnerText;
					break;
				case "PointChange":
					eventAction_Points.PointChange = Conversions.ToInteger(val.InnerText);
					break;
				}
			}
			result = eventAction_Points;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100511", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
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
			side.get_TotalScore(thescen, "Event Action: '" + Description + "' has been fired (part of Event: '" + theEv.Description + "')") += PointChange;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100512", "");
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
		EventAction_Points obj = (EventAction_Points)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static EventAction_Points()
	{
		Class72.smethod_20();
	}
}
