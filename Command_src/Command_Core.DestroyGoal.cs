using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class DestroyGoal : ScenarioGoal
{
	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("DestroyGoal");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteElementString("NeedsToBeChecked", NeedsToBeChecked.ToString());
			theWriter.WriteElementString("IsRepeatable", IsRepeatable.ToString());
			theWriter.WriteElementString("GoalPoints", GoalPoints.ToString());
			if (!string.IsNullOrEmpty(TargetSide))
			{
				theWriter.WriteElementString("TargetSide", TargetSide);
			}
			XmlWriter obj = theWriter;
			int targetType = (int)TargetType;
			obj.WriteElementString("TargetType", targetType.ToString());
			theWriter.WriteElementString("TargetSubType", TargetSubType.ToString());
			if (SpecificUnitClass != 0)
			{
				theWriter.WriteElementString("SpecificUnitClass", SpecificUnitClass.ToString());
			}
			if (!Information.IsNothing((object)SpecificUnit))
			{
				theWriter.WriteStartElement("SpecificUnit");
				SpecificUnit.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteEndElement();
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100756", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static DestroyGoal FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		DestroyGoal result;
		try
		{
			DestroyGoal destroyGoal = new DestroyGoal();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "IsRepeatable":
					destroyGoal.IsRepeatable = Misc.ParseBool(val.InnerText);
					break;
				case "TargetType":
					destroyGoal.TargetType = (GlobalVariables.ActiveUnitType)Conversions.ToByte(val.InnerText);
					break;
				case "SpecificUnit":
					if (val.HasChildNodes)
					{
						XmlNode theNode2 = val.ChildNodes[0];
						destroyGoal.SpecificUnit = ActiveUnit.FromXML(ref theNode2, ref theDictionary, ref theScen);
					}
					break;
				case "TargetSide":
					destroyGoal.TargetSide = val.InnerText;
					break;
				case "NeedsToBeChecked":
					destroyGoal.NeedsToBeChecked = Misc.ParseBool(val.InnerText);
					break;
				case "SpecificUnitClass":
					if (Versioned.IsNumeric((object)val.InnerText))
					{
						destroyGoal.SpecificUnitClass = Conversions.ToInteger(val.InnerText);
					}
					else
					{
						destroyGoal.SpecificUnitClass = DBFunctions.GetActiveUnitIDByName(val.InnerText, destroyGoal.TargetType, theScen.DBConnection);
					}
					break;
				case "Description":
					destroyGoal.Description = val.InnerText;
					break;
				case "ID":
					destroyGoal.ObjectID_Set(val.InnerText);
					break;
				case "GoalPoints":
					destroyGoal.GoalPoints = Conversions.ToInteger(val.InnerText);
					break;
				case "TargetSubType":
					destroyGoal.TargetSubType = Conversions.ToInteger(val.InnerText);
					break;
				}
			}
			result = destroyGoal;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100757", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new DestroyGoal();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool IsFulfilled(ActiveUnit theDestroyedUnit)
	{
		bool result;
		try
		{
			if (string.IsNullOrEmpty(TargetSide))
			{
				goto IL_0044;
			}
			if (Information.IsNothing((object)theDestroyedUnit.get_UnitSide(SetSideOnly: false)))
			{
				result = false;
			}
			else
			{
				if (Operators.CompareString(theDestroyedUnit.get_UnitSide(SetSideOnly: false).ObjectID, TargetSide, false) == 0)
				{
					goto IL_0044;
				}
				result = false;
			}
			goto end_IL_0001;
			IL_0044:
			switch (TargetType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				if (!theDestroyedUnit.IsAircraft)
				{
					result = false;
					break;
				}
				goto default;
			case GlobalVariables.ActiveUnitType.Ship:
				if (!theDestroyedUnit.IsShip)
				{
					result = false;
					break;
				}
				goto default;
			case GlobalVariables.ActiveUnitType.Submarine:
				if (!theDestroyedUnit.IsSubmarine)
				{
					result = false;
					break;
				}
				goto default;
			case GlobalVariables.ActiveUnitType.Facility:
				if (!theDestroyedUnit.IsFacility)
				{
					result = false;
					break;
				}
				goto default;
			case GlobalVariables.ActiveUnitType.Aimpoint:
				result = false;
				break;
			case GlobalVariables.ActiveUnitType.Weapon:
				if (!theDestroyedUnit.IsWeapon)
				{
					result = false;
					break;
				}
				goto default;
			default:
				result = TargetSubType == 0 || ((!theDestroyedUnit.IsAircraft || ((Aircraft)theDestroyedUnit).Type == (Aircraft._AircraftType)TargetSubType) && (!theDestroyedUnit.IsShip || ((Ship)theDestroyedUnit).Type == (Ship._ShipType)TargetSubType) && (!theDestroyedUnit.IsSubmarine || ((Submarine)theDestroyedUnit).Type == (Submarine._SubmarineType)TargetSubType) && (!theDestroyedUnit.IsFacility || (int)((Facility)theDestroyedUnit).Category == TargetSubType) && (!theDestroyedUnit.IsWeapon || (int)((Weapon)theDestroyedUnit).Type == TargetSubType) && (SpecificUnitClass == 0 || (SpecificUnitClass == theDestroyedUnit.DBID && (Information.IsNothing((object)SpecificUnit) || ((SpecificUnit == theDestroyedUnit) ? true : false)))));
				break;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100758", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (!Debugger.IsAttached)
			{
				num = 0;
			}
			else
			{
				Debugger.Break();
				num = 0;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static DestroyGoal()
	{
		Class72.smethod_20();
	}
}
