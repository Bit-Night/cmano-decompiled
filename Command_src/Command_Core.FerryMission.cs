using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class FerryMission : Mission
{
	public enum FerryMissionBehavior : byte
	{
		OneWay,
		Cycle,
		Random
	}

	private FerryMissionBehavior ferryMissionBehavior_0;

	private ActiveUnit activeUnit_0;

	private string string_2;

	public _FlightQty MinimumNumberOfAircraft;

	public ActiveUnit.Throttle? FerryThrottle_Aircraft;

	public float? FerryAltitude_Aircraft;

	public bool FerryTerrainFollowing_Aircraft;

	public ActiveUnit.Throttle? FerryThrottle_Ship;

	public ActiveUnit.Throttle? FerryThrottle_Submarine;

	public float? FerryAltitude_Submarine;

	public _AircraftFormationType Formation_Cruise;

	public FerryMissionBehavior Behavior
	{
		get
		{
			return ferryMissionBehavior_0;
		}
		set
		{
			ferryMissionBehavior_0 = value;
		}
	}

	public override string DescriptionString
	{
		get
		{
			string text = "Ferry Mission";
			if (!Information.IsNothing((object)this.get_NominalDestinationHost(theScen)))
			{
				text = text + " - Destination: " + this.get_NominalDestinationHost(theScen).Name;
			}
			return text + " (" + ferryMissionBehavior_0.ToString() + ")";
		}
	}

	public ActiveUnit NominalDestinationHost
	{
		get
		{
			if (activeUnit_0 == null)
			{
				if (!string.IsNullOrEmpty(string_2))
				{
					theScen.ActiveUnits.TryGetValue(string_2, out activeUnit_0);
				}
				return activeUnit_0;
			}
			return activeUnit_0;
		}
		set
		{
			activeUnit_0 = value;
			if (activeUnit_0 != null)
			{
				string_2 = activeUnit_0.ObjectID;
			}
			else
			{
				string_2 = string.Empty;
			}
		}
	}

	internal override void Reinitialize()
	{
		base.Reinitialize();
		FerryThrottle_Aircraft = null;
		FerryAltitude_Aircraft = null;
		FerryThrottle_Ship = null;
		FerryThrottle_Submarine = null;
		FerryAltitude_Submarine = null;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("FerryMission");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Name", Name);
			theWriter.WriteElementString("Category", ((byte)Category).ToString());
			method_0(ref theWriter, ref ObjectsAlreadySerialized, ref theScen);
			XmlWriter obj = theWriter;
			byte b = (byte)ferryMissionBehavior_0;
			obj.WriteElementString("Behavior", b.ToString());
			Doctrine.ToXML(ref theWriter, ref theScen);
			if (_StartTime.HasValue)
			{
				theWriter.WriteElementString("START", _StartTime.Value.ToBinary().ToString());
			}
			if (_EndTime.HasValue)
			{
				theWriter.WriteElementString("END", _EndTime.Value.ToBinary().ToString());
			}
			if (_TakeOffTime.HasValue)
			{
				theWriter.WriteElementString("TakeOffTime", _TakeOffTime.Value.ToBinary().ToString());
			}
			if (_TimeOnTarget.HasValue)
			{
				theWriter.WriteElementString("TimeOnTarget", _TimeOnTarget.Value.ToBinary().ToString());
			}
			theWriter.WriteElementString("Deactivation_UnassignUnits", Deactivation_UnassignUnits.ToString());
			theWriter.WriteElementString("CheckBox_OrderRTB", Deactivation_OrderRTB.ToString());
			theWriter.WriteElementString("CheckBox_DeleteMission", Deactivation_DeleteMission.ToString());
			theWriter.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			theWriter.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			theWriter.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			theWriter.WriteElementString("IncludeInATO", IncludeInATO.ToString());
			theWriter.WriteElementString("NDH", string_2);
			if (base.get_Status(theScen) != MissionStatus.Active)
			{
				theWriter.WriteElementString("Status", ((byte)base.get_Status(theScen)).ToString());
			}
			if (FerryThrottle_Aircraft.HasValue)
			{
				theWriter.WriteElementString("FerryThrottle_Aircraft", Conversions.ToString((int)FerryThrottle_Aircraft.Value));
			}
			if (FerryAltitude_Aircraft.HasValue)
			{
				theWriter.WriteElementString("FerryAltitude_Aircraft", FerryAltitude_Aircraft.Value.ToString());
			}
			theWriter.WriteElementString("FerryTerrainFollowing_Aircraft", FerryTerrainFollowing_Aircraft.ToString());
			if (FerryThrottle_Ship.HasValue)
			{
				theWriter.WriteElementString("FerryThrottle_Ship", Conversions.ToString((int)FerryThrottle_Ship.Value));
			}
			if (FerryThrottle_Submarine.HasValue)
			{
				theWriter.WriteElementString("FerryThrottle_Submarine", Conversions.ToString((int)FerryThrottle_Submarine.Value));
			}
			if (FerryAltitude_Submarine.HasValue)
			{
				theWriter.WriteElementString("FerryAltitude_Submarine", FerryAltitude_Submarine.Value.ToString());
			}
			theWriter.WriteElementString("FlightSize", ((int)base.FlightSize).ToString());
			XmlWriter obj2 = theWriter;
			int formation_Cruise = (int)Formation_Cruise;
			obj2.WriteElementString("Formation_Cruise", formation_Cruise.ToString());
			XmlWriter obj3 = theWriter;
			formation_Cruise = (int)MinimumNumberOfAircraft;
			obj3.WriteElementString("MinAircraftReq", formation_Cruise.ToString());
			theWriter.WriteElementString("UseFlightSizeHardLimit", UseFlightSizeHardLimit.ToString());
			if (SecondaryAirBase != null)
			{
				theWriter.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				theWriter.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			XmlWriter obj4 = theWriter;
			b = (byte)TankerUsage;
			obj4.WriteElementString("TankerUsage", b.ToString());
			theWriter.WriteStartElement("TankerMissionList");
			foreach (Mission tankerMission in TankerMissions)
			{
				if (!Information.IsNothing((object)tankerMission))
				{
					theWriter.WriteElementString("ID", tankerMission.ObjectID);
				}
			}
			theWriter.WriteEndElement();
			if (LaunchMissionWithoutTankersInPlace)
			{
				theWriter.WriteElementString("LaunchMissionWithoutTankersInPlace", LaunchMissionWithoutTankersInPlace.ToString());
			}
			theWriter.WriteElementString("KeepOnMissionWithoutTankersInPlace", KeepOnMissionWithoutTankersInPlace.ToString());
			theWriter.WriteElementString("TankerMinNumber_Total", TankerMinNumber_Total.ToString());
			theWriter.WriteElementString("TankerMinNumber_Airborne", TankerMinNumber_Airborne.ToString());
			theWriter.WriteElementString("TankerMinNumber_Station", TankerMinNumber_Station.ToString());
			theWriter.WriteElementString("MaxReceiversInQueuePerTanker_Airborne", MaxReceiversInQueuePerTanker_Airborne.ToString());
			theWriter.WriteElementString("FuelQtyToStartLookingForTanker_Airborne", FuelQtyToStartLookingForTanker_Airborne.ToString());
			theWriter.WriteElementString("TankerMaxDistance_Airborne", TankerMaxDistance_Airborne.ToString());
			theWriter.WriteElementString("TankerFollowsReceivers", TankerFollowsReceivers.ToString());
			if (HasFlights())
			{
				Flight.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref theScen, ref FlightList);
			}
			if (!Information.IsNothing((object)EmptySlotsList) && EmptySlotsList.Count > 0)
			{
				EmptyAircraftSlot.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref theScen, ref EmptySlotsList);
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100633", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private FerryMission(Side theSide, Scenario theScen, string theNAme)
		: base(theSide, theScen, theNAme)
	{
		IsMission = true;
		MissionClass = _MissionClass.Ferry;
	}

	public static FerryMission FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen, Mission existingObject = null)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0b09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b10: Expected O, but got Unknown
		//IL_079a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a1: Expected O, but got Unknown
		FerryMission result;
		try
		{
			bool flag;
			FerryMission ferryMission;
			int num;
			if (!(flag = existingObject != null))
			{
				ferryMission = new FerryMission(null, theScen, "");
				num = 0;
			}
			else
			{
				ferryMission = (FerryMission)existingObject;
				ferryMission.Reinitialize();
				num = 0;
			}
			bool flag2 = (byte)num != 0;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				Mission.FromXMLCommon(ferryMission, theNode2);
				switch (theNode2.Name)
				{
				case "Name":
					ferryMission.Name = theNode2.InnerText;
					break;
				case "START":
				{
					DateTime value4 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					ferryMission._StartTime = value4;
					break;
				}
				case "Status":
					((Mission)ferryMission).set_Status(theScen, (MissionStatus)Conversions.ToByte(theNode2.InnerText));
					break;
				case "SISIH":
					ferryMission.ScrubIfSideIsHuman = Misc.ParseBool(theNode2.InnerText);
					break;
				case "UseFlightplan":
					ferryMission.UseFlightplans = Misc.ParseBool(theNode2.InnerText);
					break;
				case "IncludeInATO":
					ferryMission.IncludeInATO = Misc.ParseBool(theNode2.InnerText);
					flag2 = true;
					break;
				case "TankerMaxDistance_Airborne":
					ferryMission.TankerMaxDistance_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TankerMinNumber_Airborne":
					ferryMission.TankerMinNumber_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Behavior":
					ferryMission.ferryMissionBehavior_0 = (FerryMissionBehavior)Conversions.ToByte(theNode2.InnerText);
					break;
				case "UseFlightplansOnly":
					ferryMission.UsePreGeneratedFlightplansOnly = Misc.ParseBool(theNode2.InnerText);
					break;
				case "LaunchMissionWithoutTankersInPlace":
					ferryMission.LaunchMissionWithoutTankersInPlace = Misc.ParseBool(theNode2.InnerText);
					break;
				case "EmptySlotsList":
					ferryMission.EmptySlotsList = EmptyAircraftSlot.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "TankerMinNumber_Total":
					ferryMission.TankerMinNumber_Total = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Doctrine":
					if (flag)
					{
						ferryMission.Doctrine = Doctrine.FromXML(theScen, ref theNode2, ferryMission, ferryMission.Doctrine);
					}
					else
					{
						ferryMission.Doctrine = Doctrine.FromXML(theScen, ref theNode2, ferryMission);
					}
					break;
				case "HomeNavalbase":
					ferryMission._SecondaryNavalBaseID = theNode2.InnerText;
					break;
				case "TimeOnTarget":
				{
					DateTime value3 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					ferryMission.TimeOnTarget = value3;
					break;
				}
				case "TakeOffTime":
				{
					DateTime value2 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					ferryMission.TakeOffTime = value2;
					break;
				}
				case "ID":
					if (!theDictionary.ContainsKey(theNode2.InnerText))
					{
						ferryMission.ObjectID_Set(theNode2.InnerText);
						theDictionary.TryAdd(ferryMission.ObjectID, ferryMission);
						break;
					}
					result = (FerryMission)theDictionary[theNode2.InnerText];
					goto end_IL_0001;
				case "TankerMinNumber_Station":
					ferryMission.TankerMinNumber_Station = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "FerryAltitude_Submarine":
					ferryMission.FerryAltitude_Submarine = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "CheckBox_OrderRTB":
					ferryMission.Deactivation_OrderRTB = Misc.ParseBool(theNode2.InnerText);
					break;
				case "FerryTerrainFollowing_Aircraft":
					ferryMission.FerryTerrainFollowing_Aircraft = Misc.ParseBool(theNode2.InnerText);
					break;
				case "FlightList":
					ferryMission.FlightList = Flight.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "FerryThrottle":
				case "FerryThrottle_Aircraft":
					ferryMission.FerryThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "Deactivation_UnassignUnits":
					ferryMission.Deactivation_UnassignUnits = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TankerMissionList":
					if (flag)
					{
						ferryMission.TankerMissions_IDs.Clear();
					}
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode val2 = childNode2;
						ferryMission.TankerMissions_IDs.Add(val2.InnerText);
					}
					break;
				case "FerryThrottle_Ship":
					ferryMission.FerryThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "FuelQtyToStartLookingForTanker_Airborne":
					ferryMission.FuelQtyToStartLookingForTanker_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "HomeAirbase":
					ferryMission._SecondaryAirBaseID = theNode2.InnerText;
					break;
				case "UseFlightSizeHardLimit":
					ferryMission.UseFlightSizeHardLimit = Misc.ParseBool(theNode2.InnerText);
					break;
				case "FlightSize":
					ferryMission.FlightSize = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Category":
					ferryMission.Category = (MissionCategory)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "END":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					ferryMission._EndTime = value;
					break;
				}
				case "PriorityWeight":
					ferryMission.PriorityWeight = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "NDH":
				case "NominalDestinationHost":
					ferryMission.string_2 = theNode2.InnerText;
					break;
				case "CheckBox_DeleteMission":
					ferryMission.Deactivation_DeleteMission = Misc.ParseBool(theNode2.InnerText);
					break;
				case "KeepOnMissionWithoutTankersInPlace":
					ferryMission.KeepOnMissionWithoutTankersInPlace = Misc.ParseBool(theNode2.InnerText);
					break;
				case "_Phase":
					ferryMission._Phase = (MissionPhase)Conversions.ToByte(theNode2.InnerText);
					break;
				case "FerryAltitude":
				case "FerryAltitude_Aircraft":
					ferryMission.FerryAltitude_Aircraft = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "AssignedUnitsList":
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode val = childNode3;
						ferryMission.UnitsAssignedToMissionIDs.Add(val.InnerText);
					}
					break;
				case "MinAircraftReq":
					ferryMission.MinimumNumberOfAircraft = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TankerFollowsReceivers":
					ferryMission.TankerFollowsReceivers = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TankerUsage":
					ferryMission.TankerUsage = (TankerMethod)Conversions.ToByte(theNode2.InnerText);
					break;
				case "Completion":
					ferryMission.Completion = Conversions.ToSingle(theNode2.InnerText);
					break;
				case "Formation_Cruise":
					ferryMission.Formation_Cruise = (_AircraftFormationType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "FerryThrottle_Submarine":
					ferryMission.FerryThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "MaxReceiversInQueuePerTanker_Airborne":
					ferryMission.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				}
			}
			byte? b = (byte?)ferryMission.FerryThrottle_Aircraft;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
			{
				ferryMission.FerryThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
			}
			if (ferryMission.Doctrine.ReplenishmentSelection_Inherits())
			{
				ferryMission.Doctrine.set_ReplenishmentSelection(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UnderwayRefuelAndReplenishmentSelection?)Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
			}
			if (!flag2)
			{
				ferryMission.IncludeInATO = false;
			}
			result = ferryMission;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100634", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new FerryMission(null, theScen, "");
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public FerryMission(Side theSide, Scenario theScen, string theName, MissionCategory theCategory, ActiveUnit theDestination)
		: base(theSide, theScen, theName)
	{
		IsMission = true;
		MissionClass = _MissionClass.Ferry;
		Name = theName;
		Category = theCategory;
		this.set_NominalDestinationHost(theScen, theDestination);
		FerryThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
		base.FlightSize = 4;
		UseFlightSizeHardLimit = true;
		IncludeInATO = false;
		Doctrine.set_ReplenishmentSelection(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UnderwayRefuelAndReplenishmentSelection?)Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
	}

	public override void Printout(StringBuilder PrintoutStringBuilder)
	{
		throw new NotImplementedException();
	}

	public override Mission Clone(bool DeepCloneRPs)
	{
		FerryMission obj = (FerryMission)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static FerryMission()
	{
		Class72.smethod_20();
	}
}
