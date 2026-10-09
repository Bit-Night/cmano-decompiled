using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class CargoFilterObject : ScenarioObject
{
	public CargoType cargoType;

	public Cargo.CargoObjectType SpecificObjectType;

	public int SpecificCargoDBID;

	public string SpecificCargoObjID;

	public int ThresholdReceived;

	public int ThresholdSent;

	public int Received;

	public int Sent;

	public CargoFilterObject()
	{
		ThresholdReceived = 0;
		ThresholdSent = 0;
		Received = 0;
		Sent = 0;
		cargoType = CargoType.NoCargo;
		SpecificObjectType = Cargo.CargoObjectType.None;
	}

	public void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteElementString("ID", ObjectID);
			if (cargoType > CargoType.NoCargo)
			{
				int num = (int)cargoType;
				theWriter.WriteElementString("TargetType", num.ToString());
			}
			if (SpecificObjectType > Cargo.CargoObjectType.None)
			{
				int num = (int)SpecificObjectType;
				theWriter.WriteElementString("SpecificObjectType", num.ToString());
			}
			if (SpecificCargoDBID > 0)
			{
				theWriter.WriteElementString("SpecificUnitClass", SpecificCargoDBID.ToString());
			}
			if (!string.IsNullOrEmpty(SpecificCargoObjID))
			{
				theWriter.WriteElementString("SpecificUnitID", SpecificCargoObjID);
			}
			theWriter.WriteElementString("TargetLimitReceived", ThresholdReceived.ToString());
			theWriter.WriteElementString("TargetLimitSent", ThresholdSent.ToString());
			theWriter.WriteElementString("TargetReceived", Received.ToString());
			theWriter.WriteElementString("TargetSent", Sent.ToString());
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

	public static CargoFilterObject FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		CargoFilterObject result;
		try
		{
			CargoFilterObject cargoFilterObject = new CargoFilterObject();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "SpecificUnitClass":
					cargoFilterObject.SpecificCargoDBID = Conversions.ToInteger(val.InnerText);
					break;
				case "TargetLimitReceived":
					cargoFilterObject.ThresholdReceived = Conversions.ToInteger(val.InnerText);
					break;
				case "ID":
					cargoFilterObject.ObjectID_Set(val.InnerText);
					break;
				case "TargetSent":
					cargoFilterObject.Sent = Conversions.ToInteger(val.InnerText);
					break;
				case "TargetType":
					cargoFilterObject.cargoType = (CargoType)Conversions.ToInteger(val.InnerText);
					break;
				case "TargetReceived":
					cargoFilterObject.Received = Conversions.ToInteger(val.InnerText);
					break;
				case "TargetLimitSent":
					cargoFilterObject.ThresholdSent = Conversions.ToInteger(val.InnerText);
					break;
				case "SpecificUnitID":
					cargoFilterObject.SpecificCargoObjID = val.InnerText;
					if (val.HasChildNodes)
					{
						XmlNode theNode2 = val.ChildNodes[0];
						ActiveUnit activeUnit = ActiveUnit.FromXML(ref theNode2, ref theDictionary, ref theScen);
						if (activeUnit != null)
						{
							cargoFilterObject.SpecificCargoObjID = activeUnit.ObjectID;
						}
					}
					break;
				case "SpecificObjectType":
					cargoFilterObject.SpecificObjectType = (Cargo.CargoObjectType)Conversions.ToInteger(val.InnerText);
					break;
				}
			}
			result = cargoFilterObject;
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
			result = new CargoFilterObject();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool MatchesThisCargo(Cargo cargo_item)
	{
		if (SpecificObjectType > Cargo.CargoObjectType.None && cargo_item.CurrentType != SpecificObjectType)
		{
			return false;
		}
		if (cargoType > CargoType.NoCargo && cargo_item.RequiredCargoType != cargoType)
		{
			return false;
		}
		if (SpecificCargoDBID != 0)
		{
			if (cargo_item.CargoObjectDBID != SpecificCargoDBID)
			{
				return false;
			}
			if (!string.IsNullOrEmpty(SpecificCargoObjID))
			{
				if (Operators.CompareString(SpecificCargoObjID, cargo_item.CargoObjectID, false) != 0)
				{
					return false;
				}
				return true;
			}
			return true;
		}
		return true;
	}

	public CargoFilterObject Clone()
	{
		return (CargoFilterObject)MemberwiseClone();
	}

	static CargoFilterObject()
	{
		Class72.smethod_20();
	}
}
