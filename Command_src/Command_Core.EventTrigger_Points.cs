using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_Points : EventTrigger
{
	public enum PointReachDirection : byte
	{
		GoOver,
		MatchExactly,
		GoUnder
	}

	public string SideID;

	public int PointValue;

	public PointReachDirection ReachDirection;

	public bool IsFulfilled
	{
		get
		{
			if (Operators.CompareString(theSide.ObjectID, SideID, false) != 0)
			{
				return false;
			}
			return ReachDirection switch
			{
				PointReachDirection.GoOver => (oldValue < PointValue) & (PointValue <= newValue), 
				PointReachDirection.MatchExactly => newValue == PointValue, 
				PointReachDirection.GoUnder => (oldValue > PointValue) & (PointValue >= newValue), 
				_ => false, 
			};
		}
	}

	public EventTrigger_Points()
	{
		Type = EventTriggerType.Points;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventTrigger_Points");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteElementString("SideID", SideID);
			theWriter.WriteElementString("PointValue", PointValue.ToString());
			byte reachDirection = (byte)ReachDirection;
			theWriter.WriteElementString("ReachDirection", reachDirection.ToString());
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100520", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_Points FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		EventTrigger_Points result = default(EventTrigger_Points);
		try
		{
			EventTrigger_Points eventTrigger_Points = new EventTrigger_Points();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					eventTrigger_Points.ObjectID_Set(val.InnerText);
					break;
				case "Description":
					eventTrigger_Points.Description = val.InnerText;
					break;
				case "SideID":
					eventTrigger_Points.SideID = val.InnerText;
					break;
				case "PointValue":
					eventTrigger_Points.PointValue = Conversions.ToInteger(val.InnerText);
					break;
				case "ReachDirection":
					eventTrigger_Points.ReachDirection = (PointReachDirection)Conversions.ToByte(val.InnerText);
					break;
				}
			}
			result = eventTrigger_Points;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100521", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override EventTrigger Clone()
	{
		EventTrigger_Points obj = (EventTrigger_Points)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static EventTrigger_Points()
	{
		Class72.smethod_20();
	}
}
