using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Command_Core.Lua;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_UnitBaseStatus : EventTrigger
{
	public UnitFilterObject TargetFilter;

	public object TargetCondition;

	public ActiveUnit CulpritUnit;

	public string TargetBase;

	public string TargetBaseSide;

	public bool IsFulfilled
	{
		get
		{
			bool flag = false;
			GlobalVariables.ActiveUnitType unitType = theUnit.UnitType;
			if (TargetBase != null && TargetBase.Length > 0)
			{
				string text = null;
				switch (unitType)
				{
				case GlobalVariables.ActiveUnitType.Ship:
				case GlobalVariables.ActiveUnitType.Submarine:
					if (theUnit.DockingOps.CurrentHostUnit != null)
					{
						text = theUnit.DockingOps.CurrentHostUnit.ObjectID;
					}
					else if (theUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false) == null)
					{
					}
					break;
				case GlobalVariables.ActiveUnitType.Aircraft:
					if (((Aircraft_AirOps)theUnit.AirOps).CurrentHostUnit != null)
					{
						text = ((Aircraft_AirOps)theUnit.AirOps).CurrentHostUnit.ObjectID;
					}
					else
					{
						((Aircraft_AirOps)theUnit.AirOps).get_AssignedHostUnit(PickNewAssignedHost: false);
					}
					break;
				}
				if (text != null)
				{
					ActiveUnit activeUnit = PrivateMethods.smethod_1(TargetBase, theUnit.ParentScen);
					int result;
					if (activeUnit == null)
					{
						result = 0;
					}
					else
					{
						if (Operators.CompareString(text, activeUnit.ObjectID, false) == 0)
						{
							goto IL_00cf;
						}
						result = 0;
					}
					return (byte)result != 0;
				}
			}
			goto IL_00cf;
			IL_00cf:
			if (TargetFilter.MatchesThisUnit(theUnit))
			{
				if (TargetCondition == null)
				{
					flag = false;
				}
				else
				{
					switch (theUnit.UnitType)
					{
					case GlobalVariables.ActiveUnitType.Ship:
					case GlobalVariables.ActiveUnitType.Submarine:
						if ((uint)theUnit.DockingOps.Condition == Conversions.ToByte(TargetCondition))
						{
							flag = true;
						}
						break;
					case GlobalVariables.ActiveUnitType.Aircraft:
						if ((uint)((Aircraft_AirOps)theUnit.AirOps).Condition == Conversions.ToByte(TargetCondition))
						{
							flag = true;
						}
						break;
					}
				}
			}
			else
			{
				flag = false;
			}
			if (flag)
			{
				CulpritUnit = theUnit;
			}
			return flag;
		}
	}

	public EventTrigger_UnitBaseStatus()
	{
		TargetFilter = new UnitFilterObject();
		TargetBase = null;
		TargetBaseSide = null;
		Type = EventTriggerType.UnitBaseStatus;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventTrigger_UnitBaseStatus");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteStartElement("TargetFilter");
			TargetFilter.ToXML(theWriter, ObjectsAlreadySerialized, theScen);
			theWriter.WriteEndElement();
			if (TargetCondition != null)
			{
				theWriter.WriteElementString("TargetCondition", Conversions.ToByte(TargetCondition).ToString());
			}
			if (TargetBase != null)
			{
				theWriter.WriteElementString("TargetBase", TargetBase);
			}
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

	public static EventTrigger_UnitBaseStatus FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		EventTrigger_UnitBaseStatus result3;
		try
		{
			EventTrigger_UnitBaseStatus eventTrigger_UnitBaseStatus = new EventTrigger_UnitBaseStatus();
			object obj = null;
			eventTrigger_UnitBaseStatus.TargetCondition = null;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Description":
					eventTrigger_UnitBaseStatus.Description = val.InnerText;
					break;
				case "TargetFilter":
					eventTrigger_UnitBaseStatus.TargetFilter = UnitFilterObject.FromXML(val, theDictionary, theScen);
					break;
				case "TargetBase":
					eventTrigger_UnitBaseStatus.TargetBase = val.InnerText;
					break;
				case "TargetCondition":
					obj = val.InnerText;
					break;
				case "ID":
					eventTrigger_UnitBaseStatus.ObjectID_Set(val.InnerText);
					break;
				}
			}
			if (obj != null)
			{
				switch (eventTrigger_UnitBaseStatus.TargetFilter.TargetType)
				{
				case GlobalVariables.ActiveUnitType.Ship:
				case GlobalVariables.ActiveUnitType.Submarine:
				{
					if (Enum.TryParse<ActiveUnit_DockingOps._DockingOpsCondition>(Conversions.ToString(obj), out var result2) & Enum.IsDefined(typeof(ActiveUnit_DockingOps._DockingOpsCondition), result2))
					{
						eventTrigger_UnitBaseStatus.TargetCondition = (byte)result2;
					}
					break;
				}
				case GlobalVariables.ActiveUnitType.Aircraft:
				{
					if (Enum.TryParse<Aircraft_AirOps._AirOpsCondition>(Conversions.ToString(obj), out var result) & Enum.IsDefined(typeof(Aircraft_AirOps._AirOpsCondition), result))
					{
						eventTrigger_UnitBaseStatus.TargetCondition = (byte)result;
					}
					break;
				}
				}
			}
			CMANO.LuaTriggers.AddOpsHandler();
			result3 = eventTrigger_UnitBaseStatus;
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
			result3 = new EventTrigger_UnitBaseStatus();
			ProjectData.ClearProjectError();
		}
		return result3;
	}

	public override EventTrigger Clone()
	{
		EventTrigger_UnitBaseStatus obj = (EventTrigger_UnitBaseStatus)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		obj.TargetFilter = TargetFilter.Clone();
		obj.TargetBase = TargetBase;
		return obj;
	}

	static EventTrigger_UnitBaseStatus()
	{
		Class72.smethod_20();
	}
}
