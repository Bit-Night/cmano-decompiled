using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class MineClearingMission : Mission
{
	public List<ReferencePoint> Area;

	public List<ReferencePoint> Area_ChangeCheck;

	public List<ReferencePoint> Area_1nm_ChangeCheck;

	public List<ReferencePoint> Area_2nm_ChangeCheck;

	public List<ReferencePoint> Area_5nm_ChangeCheck;

	public List<ReferencePoint> Area_10nm_ChangeCheck;

	public List<ReferencePoint> Area_30nm_ChangeCheck;

	public List<ReferencePoint> Area_1nm_Buffered;

	public List<ReferencePoint> Area_2nm_Buffered;

	public List<ReferencePoint> Area_5nm_Buffered;

	public List<ReferencePoint> Area_10nm_Buffered;

	public List<ReferencePoint> Area_30nm_Buffered;

	public bool OneThirdRule;

	public _FlightQty MinimumNumberOfAircraft;

	public ActiveUnit.Throttle? TransitThrottle_Aircraft;

	public ActiveUnit.Throttle? StationThrottle_Aircraft;

	public float? TransitAltitude_Aircraft;

	public float? StationAltitude_Aircraft;

	public bool TransitTerrainFollowing_Aircraft;

	public bool StationTerrainFollowing_Aircraft;

	private ActiveUnit_AI.AircraftAltitudePreset? nullable_0;

	private ActiveUnit_AI.AircraftAltitudePreset? nullable_1;

	private bool? nullable_2;

	private bool? nullable_3;

	private ActiveUnit_AI.SubmarineDepthPreset? nullable_4;

	private ActiveUnit_AI.SubmarineDepthPreset? nullable_5;

	private bool? nullable_6;

	private bool? nullable_7;

	public ActiveUnit.Throttle TransitThrottle_Submarine;

	public ActiveUnit.Throttle StationThrottle_Submarine;

	public float? TransitDepth_Submarine;

	public float? StationDepth_Submarine;

	public ActiveUnit.Throttle TransitThrottle_Ship;

	public ActiveUnit.Throttle StationThrottle_Ship;

	public ActiveUnit.Throttle TransitThrottle_Facility;

	public ActiveUnit.Throttle StationThrottle_Facility;

	public _AircraftFormationType Formation_Cruise;

	public _AircraftFormationType Formation_Attack;

	public MissionMovementStyle MovementStyle;

	public override string DescriptionString => "Mine-clearing Mission";

	public ActiveUnit_AI.AircraftAltitudePreset? TransitAltitude_Preset
	{
		get
		{
			return nullable_0;
		}
		set
		{
			nullable_0 = value;
		}
	}

	public ActiveUnit_AI.AircraftAltitudePreset? StationAltitude_Preset
	{
		get
		{
			return nullable_1;
		}
		set
		{
			nullable_1 = value;
		}
	}

	public bool? UseTransitAltitude_Preset
	{
		get
		{
			return nullable_2;
		}
		set
		{
			nullable_2 = value;
		}
	}

	public bool? UseStationAltitude_Preset
	{
		get
		{
			return nullable_3;
		}
		set
		{
			nullable_3 = value;
		}
	}

	public bool? UseStationDepth_Submarine_Preset
	{
		get
		{
			return nullable_7;
		}
		set
		{
			nullable_7 = value;
		}
	}

	public bool? UseTransitDepth_Submarine_Preset
	{
		get
		{
			return nullable_6;
		}
		set
		{
			nullable_6 = value;
		}
	}

	public ActiveUnit_AI.SubmarineDepthPreset? StationDepth_Submarine_Preset
	{
		get
		{
			return nullable_5;
		}
		set
		{
			nullable_5 = value;
		}
	}

	public ActiveUnit_AI.SubmarineDepthPreset? TransitDepth_Submarine_Preset
	{
		get
		{
			return nullable_4;
		}
		set
		{
			nullable_4 = value;
		}
	}

	internal override void Reinitialize()
	{
		base.Reinitialize();
		Area.Clear();
		TransitThrottle_Aircraft = null;
		StationThrottle_Aircraft = null;
		TransitAltitude_Aircraft = null;
		StationAltitude_Aircraft = null;
		TransitDepth_Submarine = null;
		StationDepth_Submarine = null;
		UseStationAltitude_Preset = null;
		UseTransitAltitude_Preset = null;
		StationAltitude_Preset = null;
		TransitAltitude_Preset = null;
		TransitDepth_Submarine_Preset = null;
		StationDepth_Submarine_Preset = null;
		UseTransitDepth_Submarine_Preset = null;
		UseStationDepth_Submarine_Preset = null;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("MineClearingMission");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Name", Name);
			theWriter.WriteElementString("Category", ((byte)Category).ToString());
			method_0(ref theWriter, ref ObjectsAlreadySerialized, ref theScen);
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
			theWriter.WriteStartElement("Area");
			foreach (ReferencePoint item in Area)
			{
				theWriter.WriteRaw(item.ToXML(ref ObjectsAlreadySerialized));
			}
			theWriter.WriteEndElement();
			XmlWriter obj = theWriter;
			int movementStyle = (int)MovementStyle;
			obj.WriteElementString("MovementStyle", movementStyle.ToString());
			theWriter.WriteElementString("OTR", OneThirdRule.ToString());
			theWriter.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			theWriter.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			theWriter.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			theWriter.WriteElementString("IncludeInATO", IncludeInATO.ToString());
			if (SecondaryAirBase != null)
			{
				theWriter.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				theWriter.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			if (base.get_Status(theScen) != MissionStatus.Active)
			{
				theWriter.WriteElementString("Status", ((byte)base.get_Status(theScen)).ToString());
			}
			Doctrine.ToXML(ref theWriter, ref theScen);
			if (TransitThrottle_Aircraft.HasValue)
			{
				theWriter.WriteElementString("TransitThrottle_Aircraft", Conversions.ToString((int)TransitThrottle_Aircraft.Value));
			}
			if (StationThrottle_Aircraft.HasValue)
			{
				theWriter.WriteElementString("StationThrottle_Aircraft", Conversions.ToString((int)StationThrottle_Aircraft.Value));
			}
			if (TransitAltitude_Aircraft.HasValue)
			{
				theWriter.WriteElementString("TransitAltitude_Aircraft", TransitAltitude_Aircraft.Value.ToString());
			}
			if (StationAltitude_Aircraft.HasValue)
			{
				theWriter.WriteElementString("StationAltitude_Aircraft", StationAltitude_Aircraft.Value.ToString());
			}
			theWriter.WriteElementString("TransitTerrainFollowing_Aircraft", TransitTerrainFollowing_Aircraft.ToString());
			theWriter.WriteElementString("StationTerrainFollowing_Aircraft", StationTerrainFollowing_Aircraft.ToString());
			XmlWriter obj2 = theWriter;
			byte transitThrottle_Submarine = (byte)TransitThrottle_Submarine;
			obj2.WriteElementString("TransitThrottle_Submarine", transitThrottle_Submarine.ToString());
			XmlWriter obj3 = theWriter;
			transitThrottle_Submarine = (byte)StationThrottle_Submarine;
			obj3.WriteElementString("StationThrottle_Submarine", transitThrottle_Submarine.ToString());
			if (TransitDepth_Submarine.HasValue)
			{
				theWriter.WriteElementString("TransitDepth_Submarine", TransitDepth_Submarine.Value.ToString());
			}
			if (StationDepth_Submarine.HasValue)
			{
				theWriter.WriteElementString("StationDepth_Submarine", StationDepth_Submarine.Value.ToString());
			}
			XmlWriter obj4 = theWriter;
			transitThrottle_Submarine = (byte)TransitThrottle_Ship;
			obj4.WriteElementString("TransitThrottle_Ship", transitThrottle_Submarine.ToString());
			XmlWriter obj5 = theWriter;
			transitThrottle_Submarine = (byte)StationThrottle_Ship;
			obj5.WriteElementString("StationThrottle_Ship", transitThrottle_Submarine.ToString());
			XmlWriter obj6 = theWriter;
			transitThrottle_Submarine = (byte)TransitThrottle_Facility;
			obj6.WriteElementString("TransitThrottle_Facility", transitThrottle_Submarine.ToString());
			XmlWriter obj7 = theWriter;
			transitThrottle_Submarine = (byte)StationThrottle_Facility;
			obj7.WriteElementString("StationThrottle_Facility", transitThrottle_Submarine.ToString());
			theWriter.WriteElementString("FlightSize", ((int)base.FlightSize).ToString());
			theWriter.WriteElementString("GroupSize", ((int)GroupSize).ToString());
			XmlWriter obj8 = theWriter;
			movementStyle = (int)Formation_Cruise;
			obj8.WriteElementString("Formation_Cruise", movementStyle.ToString());
			XmlWriter obj9 = theWriter;
			movementStyle = (int)Formation_Attack;
			obj9.WriteElementString("Formation_Attack", movementStyle.ToString());
			XmlWriter obj10 = theWriter;
			movementStyle = (int)MinimumNumberOfAircraft;
			obj10.WriteElementString("MinAircraftReq", movementStyle.ToString());
			theWriter.WriteElementString("UseFlightSizeHardLimit", UseFlightSizeHardLimit.ToString());
			theWriter.WriteElementString("UseGroupSizeHardLimit", UseGroupSizeHardLimit.ToString());
			if (UseStationAltitude_Preset.HasValue)
			{
				theWriter.WriteElementString("UseStationAltitude_Preset", ((byte)(0u - (UseStationAltitude_Preset.Value ? 1u : 0u))).ToString());
			}
			if (UseTransitAltitude_Preset.HasValue)
			{
				theWriter.WriteElementString("UseTransitAltitude_Preset", ((byte)(0u - (UseTransitAltitude_Preset.Value ? 1u : 0u))).ToString());
			}
			if (StationAltitude_Preset.HasValue)
			{
				theWriter.WriteElementString("StationAltitude_Preset", ((byte)StationAltitude_Preset.Value).ToString());
			}
			if (TransitAltitude_Preset.HasValue)
			{
				theWriter.WriteElementString("TransitAltitude_Preset", ((byte)TransitAltitude_Preset.Value).ToString());
			}
			if (TransitDepth_Submarine_Preset.HasValue)
			{
				theWriter.WriteElementString("TransitDepth_Submarine_Preset", ((byte)TransitDepth_Submarine_Preset.Value).ToString());
			}
			if (StationDepth_Submarine_Preset.HasValue)
			{
				theWriter.WriteElementString("StationDepth_Submarine_Preset", ((byte)StationDepth_Submarine_Preset.Value).ToString());
			}
			if (UseTransitDepth_Submarine_Preset.HasValue)
			{
				theWriter.WriteElementString("UseTransitDepth_Submarine_Preset", UseTransitDepth_Submarine_Preset.Value.ToString());
			}
			if (UseStationDepth_Submarine_Preset.HasValue)
			{
				theWriter.WriteElementString("UseStationDepth_Submarine_Preset", UseStationDepth_Submarine_Preset.Value.ToString());
			}
			XmlWriter obj11 = theWriter;
			transitThrottle_Submarine = (byte)TankerUsage;
			obj11.WriteElementString("TankerUsage", transitThrottle_Submarine.ToString());
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
			XmlWriter obj12 = theWriter;
			movementStyle = (int)OneThirdGrouping;
			obj12.WriteElementString("OneThirdStrictness", movementStyle.ToString());
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
			ex2?.Data.Add("Error at 100635", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static MineClearingMission FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, Mission existingObject = null)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0d32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d39: Expected O, but got Unknown
		//IL_0908: Unknown result type (might be due to invalid IL or missing references)
		//IL_090f: Expected O, but got Unknown
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Expected O, but got Unknown
		MineClearingMission result = default(MineClearingMission);
		try
		{
			bool flag;
			MineClearingMission mineClearingMission;
			int num;
			if (!(flag = existingObject != null))
			{
				mineClearingMission = new MineClearingMission(null, theScen, "");
				num = 0;
			}
			else
			{
				mineClearingMission = (MineClearingMission)existingObject;
				mineClearingMission.Reinitialize();
				num = 0;
			}
			bool flag2 = (byte)num != 0;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				Mission.FromXMLCommon(mineClearingMission, theNode2);
				switch (theNode2.Name)
				{
				case "Status":
					((Mission)mineClearingMission).set_Status(theScen, (MissionStatus)Conversions.ToByte(theNode2.InnerText));
					break;
				case "TransitTerrainFollowing_Aircraft":
					mineClearingMission.TransitTerrainFollowing_Aircraft = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TransitDepth_Submarine_Preset":
					mineClearingMission.TransitDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "Name":
					mineClearingMission.Name = theNode2.InnerText;
					break;
				case "START":
				{
					DateTime value3 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					mineClearingMission._StartTime = value3;
					break;
				}
				case "SISIH":
					mineClearingMission.ScrubIfSideIsHuman = Misc.ParseBool(theNode2.InnerText);
					break;
				case "UseFlightplan":
					mineClearingMission.UseFlightplans = Misc.ParseBool(theNode2.InnerText);
					break;
				case "IncludeInATO":
					mineClearingMission.IncludeInATO = Misc.ParseBool(theNode2.InnerText);
					flag2 = true;
					break;
				case "UseGroupSizeHardLimit":
					mineClearingMission.UseGroupSizeHardLimit = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Area":
					if (flag)
					{
						mineClearingMission.Area.Clear();
					}
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						mineClearingMission.Area.Add(ReferencePoint.FromXML(ref theNode3, ref theDictionary, theScen));
					}
					break;
				case "TankerMinNumber_Airborne":
					mineClearingMission.TankerMinNumber_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TransitThrottle_Ship":
					mineClearingMission.TransitThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TankerMaxDistance_Airborne":
					mineClearingMission.TankerMaxDistance_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "OTR":
				case "OneThirdRule":
					mineClearingMission.OneThirdRule = Misc.ParseBool(theNode2.InnerText);
					break;
				case "UseTransitDepth_Submarine_Preset":
					mineClearingMission.UseTransitDepth_Submarine_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "LaunchMissionWithoutTankersInPlace":
					mineClearingMission.LaunchMissionWithoutTankersInPlace = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TankerMinNumber_Total":
					mineClearingMission.TankerMinNumber_Total = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "UseFlightplansOnly":
					mineClearingMission.UsePreGeneratedFlightplansOnly = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TimeOnTarget":
				{
					DateTime value4 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					mineClearingMission.TimeOnTarget = value4;
					break;
				}
				case "EmptySlotsList":
					mineClearingMission.EmptySlotsList = EmptyAircraftSlot.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "HomeNavalbase":
					mineClearingMission._SecondaryNavalBaseID = theNode2.InnerText;
					break;
				case "StationThrottle_Ship":
					mineClearingMission.StationThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "ID":
					if (!theDictionary.ContainsKey(theNode2.InnerText))
					{
						mineClearingMission.ObjectID_Set(theNode2.InnerText);
						theDictionary.TryAdd(mineClearingMission.ObjectID, mineClearingMission);
						break;
					}
					result = (MineClearingMission)theDictionary[theNode2.InnerText];
					return result;
				case "Doctrine":
					if (flag)
					{
						mineClearingMission.Doctrine = Doctrine.FromXML(theScen, ref theNode2, mineClearingMission, mineClearingMission.Doctrine);
					}
					else
					{
						mineClearingMission.Doctrine = Doctrine.FromXML(theScen, ref theNode2, mineClearingMission);
					}
					break;
				case "TankerMinNumber_Station":
					mineClearingMission.TankerMinNumber_Station = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TakeOffTime":
				{
					DateTime value2 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					mineClearingMission.TakeOffTime = value2;
					break;
				}
				case "StationThrottle_Facility":
					mineClearingMission.StationThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "FuelQtyToStartLookingForTanker_Airborne":
					mineClearingMission.FuelQtyToStartLookingForTanker_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "FlightList":
					mineClearingMission.FlightList = Flight.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "UseFlightSizeHardLimit":
					mineClearingMission.UseFlightSizeHardLimit = Misc.ParseBool(theNode2.InnerText);
					break;
				case "FlightSize":
					mineClearingMission.FlightSize = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TankerMissionList":
					if (flag)
					{
						mineClearingMission.TankerMissions_IDs.Clear();
					}
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode val2 = childNode3;
						mineClearingMission.TankerMissions_IDs.Add(val2.InnerText);
					}
					break;
				case "UseTransitAltitude_Preset":
					mineClearingMission.UseTransitAltitude_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "HomeAirbase":
					mineClearingMission._SecondaryAirBaseID = theNode2.InnerText;
					break;
				case "TransitAltitude_Preset":
					mineClearingMission.TransitAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TransitDepth_Submarine":
					mineClearingMission.TransitDepth_Submarine = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "END":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					mineClearingMission._EndTime = value;
					break;
				}
				case "TransitThrottle_Facility":
					mineClearingMission.TransitThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "Formation_Attack":
					mineClearingMission.Formation_Attack = (_AircraftFormationType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MovementStyle":
					mineClearingMission.MovementStyle = (MissionMovementStyle)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Category":
					mineClearingMission.Category = (MissionCategory)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "_Phase":
					mineClearingMission._Phase = (MissionPhase)Conversions.ToByte(theNode2.InnerText);
					break;
				case "PriorityWeight":
					mineClearingMission.PriorityWeight = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "UseStationDepth_Submarine_Preset":
					mineClearingMission.UseStationDepth_Submarine_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "KeepOnMissionWithoutTankersInPlace":
					mineClearingMission.KeepOnMissionWithoutTankersInPlace = Misc.ParseBool(theNode2.InnerText);
					break;
				case "OneThirdStrictness":
					mineClearingMission.OneThirdGrouping = (OneThirdGroupingType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "AssignedUnitsList":
					foreach (XmlNode childNode4 in theNode2.ChildNodes)
					{
						XmlNode val = childNode4;
						mineClearingMission.UnitsAssignedToMissionIDs.Add(val.InnerText);
					}
					break;
				case "StationDepth_Submarine_Preset":
					mineClearingMission.StationDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TankerUsage":
					mineClearingMission.TankerUsage = (TankerMethod)Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationThrottle_Submarine":
					mineClearingMission.StationThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationThrottle":
				case "StationThrottle_Aircraft":
					mineClearingMission.StationThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationAltitude_Aircraft":
				case "StationAltitude":
					mineClearingMission.StationAltitude_Aircraft = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "TankerFollowsReceivers":
					mineClearingMission.TankerFollowsReceivers = Misc.ParseBool(theNode2.InnerText);
					break;
				case "GroupSize":
					mineClearingMission.GroupSize = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TransitAltitude":
				case "TransitAltitude_Aircraft":
					mineClearingMission.TransitAltitude_Aircraft = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "MinAircraftReq":
					mineClearingMission.MinimumNumberOfAircraft = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Formation_Cruise":
					mineClearingMission.Formation_Cruise = (_AircraftFormationType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "UseStationAltitude_Preset":
					mineClearingMission.UseStationAltitude_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Completion":
					mineClearingMission.Completion = Conversions.ToSingle(theNode2.InnerText);
					break;
				case "TransitThrottle_Submarine":
					mineClearingMission.TransitThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "MaxReceiversInQueuePerTanker_Airborne":
					mineClearingMission.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "StationAltitude_Preset":
					mineClearingMission.StationAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationDepth_Submarine":
					mineClearingMission.StationDepth_Submarine = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "TransitThrottle":
				case "TransitThrottle_Aircraft":
					mineClearingMission.TransitThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationTerrainFollowing_Aircraft":
					mineClearingMission.StationTerrainFollowing_Aircraft = Misc.ParseBool(theNode2.InnerText);
					break;
				}
			}
			if (mineClearingMission.TransitThrottle_Submarine == ActiveUnit.Throttle.FullStop)
			{
				mineClearingMission.TransitTerrainFollowing_Aircraft = false;
				mineClearingMission.StationTerrainFollowing_Aircraft = false;
				mineClearingMission.TransitThrottle_Submarine = ActiveUnit.Throttle.Cruise;
				mineClearingMission.StationThrottle_Submarine = ActiveUnit.Throttle.Loiter;
				mineClearingMission.TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
				mineClearingMission.StationThrottle_Ship = ActiveUnit.Throttle.Loiter;
				mineClearingMission.TransitThrottle_Facility = ActiveUnit.Throttle.Cruise;
				mineClearingMission.StationThrottle_Facility = ActiveUnit.Throttle.Loiter;
			}
			if (mineClearingMission.Doctrine.ReplenishmentSelection_Inherits())
			{
				mineClearingMission.Doctrine.set_ReplenishmentSelection(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UnderwayRefuelAndReplenishmentSelection?)Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
			}
			if (mineClearingMission.TransitAltitude_Aircraft.HasValue && mineClearingMission.UseTransitAltitude_Preset == true)
			{
				mineClearingMission.UseTransitAltitude_Preset = false;
				mineClearingMission.TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			if (mineClearingMission.StationAltitude_Aircraft.HasValue && mineClearingMission.UseStationAltitude_Preset == true)
			{
				mineClearingMission.UseStationAltitude_Preset = false;
				mineClearingMission.StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			if (mineClearingMission.TransitDepth_Submarine.HasValue && mineClearingMission.UseTransitDepth_Submarine_Preset == true)
			{
				mineClearingMission.UseTransitDepth_Submarine_Preset = false;
				mineClearingMission.TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (mineClearingMission.StationDepth_Submarine.HasValue && mineClearingMission.UseStationDepth_Submarine_Preset == true)
			{
				mineClearingMission.UseStationDepth_Submarine_Preset = false;
				mineClearingMission.StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (!flag2)
			{
				mineClearingMission.IncludeInATO = false;
			}
			result = mineClearingMission;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100636", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private MineClearingMission(Side theSide, Scenario theScen, string theName)
		: base(theSide, theScen, theName)
	{
		Area = new List<ReferencePoint>();
		Area_ChangeCheck = new List<ReferencePoint>();
		Area_1nm_ChangeCheck = new List<ReferencePoint>();
		Area_2nm_ChangeCheck = new List<ReferencePoint>();
		Area_5nm_ChangeCheck = new List<ReferencePoint>();
		Area_10nm_ChangeCheck = new List<ReferencePoint>();
		Area_30nm_ChangeCheck = new List<ReferencePoint>();
		Area_1nm_Buffered = new List<ReferencePoint>();
		Area_2nm_Buffered = new List<ReferencePoint>();
		Area_5nm_Buffered = new List<ReferencePoint>();
		Area_10nm_Buffered = new List<ReferencePoint>();
		Area_30nm_Buffered = new List<ReferencePoint>();
		IsMission = true;
		MissionClass = _MissionClass.MineClearing;
		OneThirdGrouping = OneThirdGroupingType.ByLoadout;
	}

	public MineClearingMission(Side theSide, Scenario theScen, string theName, MissionCategory theCategory, List<ReferencePoint> theArea, bool ValidateArea)
		: base(theSide, theScen, theName)
	{
		Area = new List<ReferencePoint>();
		Area_ChangeCheck = new List<ReferencePoint>();
		Area_1nm_ChangeCheck = new List<ReferencePoint>();
		Area_2nm_ChangeCheck = new List<ReferencePoint>();
		Area_5nm_ChangeCheck = new List<ReferencePoint>();
		Area_10nm_ChangeCheck = new List<ReferencePoint>();
		Area_30nm_ChangeCheck = new List<ReferencePoint>();
		Area_1nm_Buffered = new List<ReferencePoint>();
		Area_2nm_Buffered = new List<ReferencePoint>();
		Area_5nm_Buffered = new List<ReferencePoint>();
		Area_10nm_Buffered = new List<ReferencePoint>();
		Area_30nm_Buffered = new List<ReferencePoint>();
		IsMission = true;
		Name = theName;
		MissionClass = _MissionClass.MineClearing;
		Category = theCategory;
		Area = theArea;
		OneThirdRule = true;
		StationThrottle_Aircraft = ActiveUnit.Throttle.Loiter;
		TransitThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
		TransitTerrainFollowing_Aircraft = false;
		StationTerrainFollowing_Aircraft = false;
		TransitThrottle_Submarine = ActiveUnit.Throttle.Cruise;
		StationThrottle_Submarine = ActiveUnit.Throttle.Loiter;
		TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
		StationThrottle_Ship = ActiveUnit.Throttle.Loiter;
		TransitThrottle_Facility = ActiveUnit.Throttle.Cruise;
		StationThrottle_Facility = ActiveUnit.Throttle.Loiter;
		TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.LoadoutAltitude;
		StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.LoadoutAltitude;
		UseTransitAltitude_Preset = true;
		UseStationAltitude_Preset = true;
		TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
		StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
		UseTransitDepth_Submarine_Preset = true;
		UseStationDepth_Submarine_Preset = true;
		Doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Active, theScen);
		base.FlightSize = 1;
		UseFlightSizeHardLimit = true;
		IncludeInATO = false;
		string UserFeedback = default(string);
		if (ValidateArea && !ActiveUnit_Navigator.ValidateArea(Area, ref UserFeedback, theSide, theScen, "Mine Clearing Mission '" + Name + "'"))
		{
			GameGeneral.SendMessageBoxToUI(UserFeedback, theSide);
		}
		Doctrine.set_ReplenishmentSelection(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UnderwayRefuelAndReplenishmentSelection?)Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
		GroupSize = 1;
		OneThirdGrouping = OneThirdGroupingType.ByLoadout;
	}

	public override void Printout(StringBuilder PrintoutStringBuilder)
	{
		throw new NotImplementedException();
	}

	public override Mission Clone(bool DeepCloneRPs)
	{
		MineClearingMission obj = (MineClearingMission)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Name = "[CLONE] " + Name;
		obj.Area = new ReferencePoint().CopyRefArea(ref Area, DeepCloneRPs);
		return obj;
	}

	static MineClearingMission()
	{
		Class72.smethod_20();
	}
}
