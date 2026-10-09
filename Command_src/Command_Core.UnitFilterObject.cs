using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class UnitFilterObject : ScenarioObject
{
	public string TargetSide;

	public GlobalVariables.ActiveUnitType TargetType;

	public int TargetSubType;

	public int SpecificUnitClass;

	public string SpecificUnitID;

	public bool ShowAllTypes;

	public UnitFilterObject()
	{
		ShowAllTypes = false;
	}

	public void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteElementString("ID", ObjectID);
			if (!string.IsNullOrEmpty(TargetSide))
			{
				theWriter.WriteElementString("TargetSide", TargetSide);
			}
			int targetType = (int)TargetType;
			theWriter.WriteElementString("TargetType", targetType.ToString());
			theWriter.WriteElementString("TargetSubType", TargetSubType.ToString());
			if (ShowAllTypes)
			{
				theWriter.WriteElementString("ShowAllTypes", ShowAllTypes.ToString());
			}
			if (SpecificUnitClass != 0)
			{
				theWriter.WriteElementString("SpecificUnitClass", SpecificUnitClass.ToString());
			}
			if (!string.IsNullOrEmpty(SpecificUnitID))
			{
				theWriter.WriteElementString("SpecificUnitID", SpecificUnitID);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101070", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static UnitFilterObject FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		UnitFilterObject result;
		try
		{
			UnitFilterObject unitFilterObject = new UnitFilterObject();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "SpecificUnitClass":
					unitFilterObject.SpecificUnitClass = Conversions.ToInteger(val.InnerText);
					break;
				case "ID":
					unitFilterObject.ObjectID_Set(val.InnerText);
					break;
				case "TargetSubType":
					unitFilterObject.TargetSubType = Conversions.ToInteger(val.InnerText);
					break;
				case "ShowAllTypes":
					unitFilterObject.ShowAllTypes = Misc.ParseBool(val.InnerText);
					break;
				case "TargetSide":
					unitFilterObject.TargetSide = val.InnerText;
					break;
				case "TargetType":
					unitFilterObject.TargetType = (GlobalVariables.ActiveUnitType)Conversions.ToByte(val.InnerText);
					break;
				case "SpecificUnit":
					if (val.HasChildNodes)
					{
						XmlNode theNode2 = val.ChildNodes[0];
						ActiveUnit activeUnit = ActiveUnit.FromXML(ref theNode2, ref theDictionary, ref theScen);
						if (activeUnit != null)
						{
							unitFilterObject.SpecificUnitID = activeUnit.ObjectID;
						}
					}
					break;
				case "SpecificUnitID":
					unitFilterObject.SpecificUnitID = val.InnerText;
					break;
				}
			}
			result = unitFilterObject;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101071", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new UnitFilterObject();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool MatchesThisUnit(ActiveUnit theUnit)
	{
		if (!string.IsNullOrEmpty(TargetSide))
		{
			if (theUnit.get_UnitSide(SetSideOnly: false) == null)
			{
				return false;
			}
			if (string.CompareOrdinal(theUnit.get_UnitSide(SetSideOnly: false).ObjectID, TargetSide) != 0)
			{
				return false;
			}
		}
		switch (TargetType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			if (!theUnit.IsAircraft)
			{
				return false;
			}
			goto default;
		case GlobalVariables.ActiveUnitType.Ship:
			if (!theUnit.IsShip)
			{
				return false;
			}
			goto default;
		case GlobalVariables.ActiveUnitType.Submarine:
			if (!theUnit.IsSubmarine)
			{
				return false;
			}
			goto default;
		case GlobalVariables.ActiveUnitType.Facility:
			if (!theUnit.IsFacility)
			{
				return false;
			}
			goto default;
		case GlobalVariables.ActiveUnitType.Aimpoint:
			return false;
		case GlobalVariables.ActiveUnitType.Weapon:
			if (!theUnit.IsWeapon)
			{
				return false;
			}
			goto default;
		case GlobalVariables.ActiveUnitType.Satellite:
			if (!theUnit.IsSatellite)
			{
				return false;
			}
			goto default;
		default:
			if (TargetSubType != 0)
			{
				if (theUnit.IsAircraft && ((Aircraft)theUnit).Type != (Aircraft._AircraftType)TargetSubType)
				{
					return false;
				}
				if (theUnit.IsShip && ((Ship)theUnit).Type != (Ship._ShipType)TargetSubType)
				{
					return false;
				}
				if (theUnit.IsSubmarine && ((Submarine)theUnit).Type != (Submarine._SubmarineType)TargetSubType)
				{
					return false;
				}
				if (theUnit.IsFacility && (int)((Facility)theUnit).Category != TargetSubType)
				{
					return false;
				}
				if (theUnit.IsWeapon && (int)((Weapon)theUnit).Type != TargetSubType)
				{
					return false;
				}
				if (theUnit.IsSatellite && ((Satellite)theUnit).Type != (Satellite._SatelliteType)TargetSubType)
				{
					return false;
				}
				if (SpecificUnitClass != 0)
				{
					if (SpecificUnitClass != theUnit.DBID)
					{
						return false;
					}
					if (!string.IsNullOrEmpty(SpecificUnitID))
					{
						if (Operators.CompareString(SpecificUnitID, theUnit.ObjectID, false) != 0)
						{
							return false;
						}
						return true;
					}
					return true;
				}
				return true;
			}
			return true;
		}
	}

	public bool MatchesThisUnit(UnguidedWeapon theUnit)
	{
		if (!string.IsNullOrEmpty(TargetSide))
		{
			if (theUnit.get_UnitSide(SetSideOnly: false) == null)
			{
				return false;
			}
			if (string.CompareOrdinal(theUnit.get_UnitSide(SetSideOnly: false).ObjectID, TargetSide) != 0)
			{
				return false;
			}
		}
		GlobalVariables.ActiveUnitType targetType = TargetType;
		if (targetType == GlobalVariables.ActiveUnitType.Weapon)
		{
			if (!theUnit.IsMine)
			{
				return false;
			}
			if (TargetSubType == 0)
			{
				return true;
			}
			if ((int)theUnit.Type != TargetSubType)
			{
				return false;
			}
			if (SpecificUnitClass != 0)
			{
				if (Operators.CompareString("Weapon_" + Conversions.ToString(SpecificUnitClass), theUnit.AnnexAndDBID, false) != 0)
				{
					return false;
				}
				return true;
			}
			return true;
		}
		return false;
	}

	public UnitFilterObject Clone()
	{
		return (UnitFilterObject)MemberwiseClone();
	}

	static UnitFilterObject()
	{
		Class72.smethod_20();
	}
}
