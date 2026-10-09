using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_UnitCargoMoved : EventTrigger
{
	public CargoFilterObject TargetFilter;

	public CargoTracker cargotrk;

	public ActiveUnit BaseUnit;

	public bool ClearValues;

	public bool IsFulfilled
	{
		get
		{
			bool result = false;
			if (TargetFilter.ThresholdReceived > 0 && TargetFilter.Received >= TargetFilter.ThresholdReceived)
			{
				result = true;
			}
			else if (TargetFilter.ThresholdSent > 0 && TargetFilter.Sent >= TargetFilter.ThresholdSent)
			{
				result = true;
			}
			return result;
		}
	}

	public bool postEvent
	{
		get
		{
			int result;
			if (BaseUnit.OnboardCargo.Count() > 0)
			{
				if (TargetFilter.Received >= TargetFilter.ThresholdReceived)
				{
					TargetFilter.Received -= TargetFilter.ThresholdReceived;
				}
				if (TargetFilter.Sent >= TargetFilter.ThresholdSent)
				{
					TargetFilter.Sent -= TargetFilter.ThresholdSent;
					result = 1;
					goto IL_007f;
				}
			}
			result = 1;
			goto IL_007f;
			IL_007f:
			return (byte)result != 0;
		}
	}

	public void updateTrigger()
	{
		int num = 0;
		int num2 = 0;
		while (num < Scenario.CargoMovement.Count)
		{
			num2 = Scenario.CargoMovement.FindIndex(num, Scenario.CargoMovement.Count - num, [SpecialName] ((string, CargoTracker) x) => Operators.CompareString(x.Item1, BaseUnit.ObjectID, false) == 0);
			if (num2 != -1)
			{
				cargotrk = Scenario.CargoMovement.ElementAt(num2).Item2;
				if (TargetFilter.MatchesThisCargo(cargotrk._cargo))
				{
					TargetFilter.Received += cargotrk._loaded;
					TargetFilter.Sent += cargotrk._unloaded;
				}
				num = num2 + 1;
				continue;
			}
			break;
		}
	}

	public EventTrigger_UnitCargoMoved()
	{
		TargetFilter = new CargoFilterObject();
		Type = EventTriggerType.UnitCargoMoved;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventTrigger_UnitCargoMoved");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteStartElement("CargoFilter");
			TargetFilter.ToXML(theWriter, ObjectsAlreadySerialized, theScen);
			theWriter.WriteEndElement();
			theWriter.WriteElementString("BaseUnit", BaseUnit.ObjectID);
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100530", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_UnitCargoMoved FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		EventTrigger_UnitCargoMoved result;
		try
		{
			EventTrigger_UnitCargoMoved eventTrigger_UnitCargoMoved = new EventTrigger_UnitCargoMoved();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					eventTrigger_UnitCargoMoved.ObjectID_Set(val.InnerText);
					break;
				case "BaseUnit":
					eventTrigger_UnitCargoMoved.BaseUnit = theScen.ActiveUnits[val.InnerText];
					break;
				case "CargoFilter":
					eventTrigger_UnitCargoMoved.TargetFilter = CargoFilterObject.FromXML(val, theDictionary, theScen);
					break;
				case "Description":
					eventTrigger_UnitCargoMoved.Description = val.InnerText;
					break;
				}
			}
			result = eventTrigger_UnitCargoMoved;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100531", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new EventTrigger_UnitCargoMoved();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override EventTrigger Clone()
	{
		EventTrigger_UnitCargoMoved obj = (EventTrigger_UnitCargoMoved)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		obj.TargetFilter = TargetFilter.Clone();
		return obj;
	}

	static EventTrigger_UnitCargoMoved()
	{
		Class72.smethod_20();
	}
}
