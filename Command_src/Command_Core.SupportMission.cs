using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class SupportMission : Mission
{
	public enum SupportMissionNavigationLoopType : byte
	{
		ContinousLoop,
		SingleLoop
	}

	public SupportMissionNavigationLoopType NavigationLoopType;

	public List<ReferencePoint> NavigationCourse;

	public List<ReferencePoint> NavigationCourse_ChangeCheck;

	public List<ReferencePoint> NavigationCourse_2nm_ChangeCheck;

	public List<ReferencePoint> NavigationCourse_2nm_Buffered;

	public List<ReferencePoint> NavigationCourse_10nm_ChangeCheck;

	public List<ReferencePoint> NavigationCourse_10nm_Buffered;

	public bool OneThirdRule;

	public int MinimumNumberOnStation;

	public bool OneTimeOnly;

	public bool A2AR_OneTankingCycleOnly;

	public int A2AR_MaxNumberOfReceiversPerTanker;

	public _FlightQty MinimumNumberOfAircraft;

	public ActiveUnit.Throttle? TransitThrottle_Aircraft;

	public ActiveUnit.Throttle? StationThrottle_Aircraft;

	public float? TransitAltitude_Aircraft;

	public float? StationAltitude_Aircraft;

	public bool TransitTerrainFollowing_Aircraft;

	public bool StationTerrainFollowing_Aircraft;

	public ActiveUnit.Throttle TransitThrottle_Submarine;

	public ActiveUnit.Throttle StationThrottle_Submarine;

	public float? TransitDepth_Submarine;

	public float? StationDepth_Submarine;

	private ActiveUnit_AI.AircraftAltitudePreset? nullable_0;

	private ActiveUnit_AI.AircraftAltitudePreset? nullable_1;

	private bool? nullable_2;

	private bool? nullable_3;

	private ActiveUnit_AI.SubmarineDepthPreset? nullable_4;

	private ActiveUnit_AI.SubmarineDepthPreset? nullable_5;

	private bool? nullable_6;

	private bool? nullable_7;

	public ActiveUnit.Throttle TransitThrottle_Ship;

	public ActiveUnit.Throttle StationThrottle_Ship;

	public ActiveUnit.Throttle TransitThrottle_Facility;

	public ActiveUnit.Throttle StationThrottle_Facility;

	public bool ActiveEMCONOnlyOnStation;

	public _AircraftFormationType Formation_Cruise;

	public bool MarkAsSatisfiedUponReachingDestination;

	public bool RTBUponCompletion;

	public bool ContinousCoverage_Enable;

	public List<ContinousCoverageStation> ContinousCoverage_Stations;

	public _ContinousCoverageMethod ContinousCoverage_FlightGenerationMethod;

	public _ContinousCoverageStationTime ContinousCoverage_StationTime;

	public _ContinousCoverageOverlap ContinousCoverage_Overlap;

	public _ContinousCoverageDuration ContinousCoverage_Duration;

	public bool ContinousCoverage_QRAEnable;

	public List<ContinousCoverageStation> ContinousCoverage_QRAs;

	public _ContinousCoverageMethod ContinousCoverage_QRAFlightGenerationMethod;

	public _FlightQty ContinousCoverage_QRANumberOfFlights;

	public _FlightQty ContinousCoverage_NumberOfFlightsNeededToAllowQRA;

	public override string DescriptionString => "Support mission";

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
		NavigationCourse.Clear();
		MinimumNumberOnStation = 0;
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
		ContinousCoverage_Stations = null;
		ContinousCoverage_QRAs = null;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("SupportMission");
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
			theWriter.WriteStartElement("NavigationCourse");
			foreach (ReferencePoint item in NavigationCourse)
			{
				theWriter.WriteRaw(item.ToXML(ref ObjectsAlreadySerialized));
			}
			theWriter.WriteEndElement();
			XmlWriter obj = theWriter;
			int navigationLoopType = (int)NavigationLoopType;
			obj.WriteElementString("NLT", navigationLoopType.ToString());
			theWriter.WriteElementString("OTR", OneThirdRule.ToString());
			if (MinimumNumberOnStation > 0)
			{
				theWriter.WriteElementString("MNOS", MinimumNumberOnStation.ToString());
			}
			theWriter.WriteElementString("OTO", OneTimeOnly.ToString());
			theWriter.WriteElementString("AEOOS", ActiveEMCONOnlyOnStation.ToString());
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
			if (base.get_Status(theScen) != MissionStatus.Active)
			{
				theWriter.WriteElementString("Status", ((byte)base.get_Status(theScen)).ToString());
			}
			Doctrine.ToXML(ref theWriter, ref theScen);
			theWriter.WriteElementString("FlightSize", ((int)base.FlightSize).ToString());
			theWriter.WriteElementString("GroupSize", ((int)GroupSize).ToString());
			XmlWriter obj8 = theWriter;
			navigationLoopType = (int)Formation_Cruise;
			obj8.WriteElementString("Formation_Cruise", navigationLoopType.ToString());
			theWriter.WriteElementString("A2AR_MaxNumberOfReceiversPerTanker", A2AR_MaxNumberOfReceiversPerTanker.ToString());
			theWriter.WriteElementString("A2AR_OneTankingCycleOnly", A2AR_OneTankingCycleOnly.ToString());
			XmlWriter obj9 = theWriter;
			navigationLoopType = (int)MinimumNumberOfAircraft;
			obj9.WriteElementString("MinAircraftReq", navigationLoopType.ToString());
			theWriter.WriteElementString("UseFlightSizeHardLimit", UseFlightSizeHardLimit.ToString());
			theWriter.WriteElementString("UseGroupSizeHardLimit", UseGroupSizeHardLimit.ToString());
			XmlWriter obj10 = theWriter;
			transitThrottle_Submarine = (byte)TankerUsage;
			obj10.WriteElementString("TankerUsage", transitThrottle_Submarine.ToString());
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
			theWriter.WriteElementString("MarkAsSatisfiedUponReachingDestination", MarkAsSatisfiedUponReachingDestination.ToString());
			theWriter.WriteElementString("RTBUponCompletion", RTBUponCompletion.ToString());
			theWriter.WriteElementString("ContinousCoverage_Enable", ContinousCoverage_Enable.ToString());
			theWriter.WriteElementString("ContinousCoverage_AllowQRA", ContinousCoverage_QRAEnable.ToString());
			XmlWriter obj11 = theWriter;
			navigationLoopType = (int)ContinousCoverage_FlightGenerationMethod;
			obj11.WriteElementString("ContinousCoverage_FlightGenerationMethod", navigationLoopType.ToString());
			XmlWriter obj12 = theWriter;
			navigationLoopType = (int)ContinousCoverage_StationTime;
			obj12.WriteElementString("ContinousCoverage_StationTime", navigationLoopType.ToString());
			XmlWriter obj13 = theWriter;
			navigationLoopType = (int)ContinousCoverage_Overlap;
			obj13.WriteElementString("ContinousCoverage_Overlap", navigationLoopType.ToString());
			XmlWriter obj14 = theWriter;
			navigationLoopType = (int)ContinousCoverage_Duration;
			obj14.WriteElementString("ContinousCoverage_Duration", navigationLoopType.ToString());
			if (!Information.IsNothing((object)ContinousCoverage_Stations) && ContinousCoverage_Stations.Count > 0)
			{
				ContinousCoverageStation.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref theScen, ref ContinousCoverage_Stations);
			}
			if (!Information.IsNothing((object)ContinousCoverage_QRAs) && ContinousCoverage_QRAs.Count > 0)
			{
				ContinousCoverageStation.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref theScen, ref ContinousCoverage_QRAs);
			}
			XmlWriter obj15 = theWriter;
			navigationLoopType = (int)ContinousCoverage_QRANumberOfFlights;
			obj15.WriteElementString("ContinousCoverage_QRANumberOfFlights", navigationLoopType.ToString());
			XmlWriter obj16 = theWriter;
			navigationLoopType = (int)ContinousCoverage_QRAFlightGenerationMethod;
			obj16.WriteElementString("ContinousCoverage_QRAFlightGenerationMethod", navigationLoopType.ToString());
			XmlWriter obj17 = theWriter;
			navigationLoopType = (int)ContinousCoverage_NumberOfFlightsNeededToAllowQRA;
			obj17.WriteElementString("ContinousCoverage_NumberOfFlightsNeededToAllowQRA", navigationLoopType.ToString());
			XmlWriter obj18 = theWriter;
			navigationLoopType = (int)OneThirdGrouping;
			obj18.WriteElementString("OneThirdStrictness", navigationLoopType.ToString());
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
			ex2?.Data.Add("Error at 100650", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static SupportMission FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, Mission existingObject = null)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_117a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1181: Expected O, but got Unknown
		//IL_09f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fb: Expected O, but got Unknown
		//IL_0b54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5b: Expected O, but got Unknown
		SupportMission result = default(SupportMission);
		try
		{
			bool flag;
			SupportMission supportMission;
			int num;
			if (!(flag = existingObject != null))
			{
				Side theSide = null;
				List<ReferencePoint> theCourse = null;
				supportMission = new SupportMission(ref theSide, ref theScen, "", MissionCategory.Mission, ref theCourse, ValidateArea: false);
				num = 0;
			}
			else
			{
				supportMission = (SupportMission)existingObject;
				supportMission.Reinitialize();
				num = 0;
			}
			bool flag2 = (byte)num != 0;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				Mission.FromXMLCommon(supportMission, theNode2);
				switch (theNode2.Name)
				{
				case "Status":
					((Mission)supportMission).set_Status(theScen, (MissionStatus)Conversions.ToByte(theNode2.InnerText));
					break;
				case "TransitDepth_Submarine_Preset":
					supportMission.TransitDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "ContinousCoverage_QRANumberOfFlights":
					supportMission.ContinousCoverage_QRANumberOfFlights = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "OTO":
					supportMission.OneTimeOnly = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Name":
					supportMission.Name = theNode2.InnerText;
					break;
				case "START":
				{
					DateTime value2 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					supportMission._StartTime = value2;
					break;
				}
				case "TransitTerrainFollowing_Aircraft":
					supportMission.TransitTerrainFollowing_Aircraft = Misc.ParseBool(theNode2.InnerText);
					break;
				case "UseFlightplan":
					supportMission.UseFlightplans = Misc.ParseBool(theNode2.InnerText);
					break;
				case "IncludeInATO":
					supportMission.IncludeInATO = Misc.ParseBool(theNode2.InnerText);
					flag2 = true;
					break;
				case "CCSList":
					supportMission.ContinousCoverage_Stations = ContinousCoverageStation.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "UseGroupSizeHardLimit":
					supportMission.UseGroupSizeHardLimit = Misc.ParseBool(theNode2.InnerText);
					break;
				case "ContinousCoverage_Overlap":
					supportMission.ContinousCoverage_Overlap = (_ContinousCoverageOverlap)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "SISIH":
					supportMission.ScrubIfSideIsHuman = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TankerMinNumber_Airborne":
					supportMission.TankerMinNumber_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TankerMaxDistance_Airborne":
					supportMission.TankerMaxDistance_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MarkAsSatisfiedUponReachingDestination":
					supportMission.MarkAsSatisfiedUponReachingDestination = Misc.ParseBool(theNode2.InnerText);
					break;
				case "LaunchMissionWithoutTankersInPlace":
					supportMission.LaunchMissionWithoutTankersInPlace = Misc.ParseBool(theNode2.InnerText);
					break;
				case "A2AR_MaxNumberOfReceiversPerTanker":
					supportMission.A2AR_MaxNumberOfReceiversPerTanker = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TransitThrottle_Ship":
					supportMission.TransitThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "OTR":
				case "OneThirdRule":
					supportMission.OneThirdRule = Misc.ParseBool(theNode2.InnerText);
					break;
				case "UseTransitDepth_Submarine_Preset":
					supportMission.UseTransitDepth_Submarine_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TankerMinNumber_Total":
					supportMission.TankerMinNumber_Total = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MNOS":
					supportMission.MinimumNumberOnStation = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "UseFlightplansOnly":
					supportMission.UsePreGeneratedFlightplansOnly = Misc.ParseBool(theNode2.InnerText);
					break;
				case "StationThrottle_Ship":
					supportMission.StationThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TimeOnTarget":
				{
					DateTime value4 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					supportMission.TimeOnTarget = value4;
					break;
				}
				case "EmptySlotsList":
					supportMission.EmptySlotsList = EmptyAircraftSlot.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "Doctrine":
					if (flag)
					{
						supportMission.Doctrine = Doctrine.FromXML(theScen, ref theNode2, supportMission, supportMission.Doctrine);
					}
					else
					{
						supportMission.Doctrine = Doctrine.FromXML(theScen, ref theNode2, supportMission);
					}
					break;
				case "HomeNavalbase":
					supportMission._SecondaryNavalBaseID = theNode2.InnerText;
					break;
				case "TakeOffTime":
				{
					DateTime value3 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					supportMission.TakeOffTime = value3;
					break;
				}
				case "ContinousCoverage_Enable":
					supportMission.ContinousCoverage_Enable = Misc.ParseBool(theNode2.InnerText);
					break;
				case "ID":
					if (!theDictionary.ContainsKey(theNode2.InnerText))
					{
						supportMission.ObjectID_Set(theNode2.InnerText);
						theDictionary.TryAdd(supportMission.ObjectID, supportMission);
						break;
					}
					result = (SupportMission)theDictionary[theNode2.InnerText];
					return result;
				case "StationThrottle_Facility":
					supportMission.StationThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TankerMinNumber_Station":
					supportMission.TankerMinNumber_Station = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "AEOOS":
					supportMission.ActiveEMCONOnlyOnStation = Misc.ParseBool(theNode2.InnerText);
					break;
				case "QRAs":
					supportMission.ContinousCoverage_QRAs = ContinousCoverageStation.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "NavigationCourse":
					supportMission.NavigationCourse = new List<ReferencePoint>();
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						supportMission.NavigationCourse.Add(ReferencePoint.FromXML(ref theNode3, ref theDictionary, theScen));
					}
					break;
				case "A2AR_OneTankingCycleOnly":
					supportMission.A2AR_OneTankingCycleOnly = Misc.ParseBool(theNode2.InnerText);
					break;
				case "ContinousCoverage_NumberOfFlightsNeededToAllowQRA":
					supportMission.ContinousCoverage_NumberOfFlightsNeededToAllowQRA = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "FlightList":
					supportMission.FlightList = Flight.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "TankerMissionList":
					if (flag)
					{
						supportMission.TankerMissions_IDs.Clear();
					}
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode val2 = childNode3;
						supportMission.TankerMissions_IDs.Add(val2.InnerText);
					}
					break;
				case "FuelQtyToStartLookingForTanker_Airborne":
					supportMission.FuelQtyToStartLookingForTanker_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "ContinousCoverage_QRAFlightGenerationMethod":
					supportMission.ContinousCoverage_QRAFlightGenerationMethod = (_ContinousCoverageMethod)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "FlightSize":
					supportMission.FlightSize = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "RTBUponCompletion":
					supportMission.RTBUponCompletion = Misc.ParseBool(theNode2.InnerText);
					break;
				case "NLT":
					supportMission.NavigationLoopType = (SupportMissionNavigationLoopType)Conversions.ToByte(theNode2.InnerText);
					break;
				case "UseTransitAltitude_Preset":
					supportMission.UseTransitAltitude_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "HomeAirbase":
					supportMission._SecondaryAirBaseID = theNode2.InnerText;
					break;
				case "UseFlightSizeHardLimit":
					supportMission.UseFlightSizeHardLimit = Misc.ParseBool(theNode2.InnerText);
					break;
				case "ContinousCoverage_FlightGenerationMethod":
					supportMission.ContinousCoverage_FlightGenerationMethod = (_ContinousCoverageMethod)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TransitAltitude_Preset":
					supportMission.TransitAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TransitDepth_Submarine":
					supportMission.TransitDepth_Submarine = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "Category":
					supportMission.Category = (MissionCategory)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "END":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					supportMission._EndTime = value;
					break;
				}
				case "TransitThrottle_Facility":
					supportMission.TransitThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "KeepOnMissionWithoutTankersInPlace":
					supportMission.KeepOnMissionWithoutTankersInPlace = Misc.ParseBool(theNode2.InnerText);
					break;
				case "_Phase":
					supportMission._Phase = (MissionPhase)Conversions.ToByte(theNode2.InnerText);
					break;
				case "PriorityWeight":
					supportMission.PriorityWeight = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "ContinousCoverage_Duration":
					supportMission.ContinousCoverage_Duration = (_ContinousCoverageDuration)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "UseStationDepth_Submarine_Preset":
					supportMission.UseStationDepth_Submarine_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "ContinousCoverage_StationTime":
					supportMission.ContinousCoverage_StationTime = (_ContinousCoverageStationTime)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "StationDepth_Submarine_Preset":
					supportMission.StationDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "OneThirdStrictness":
					supportMission.OneThirdGrouping = (OneThirdGroupingType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TankerUsage":
					supportMission.TankerUsage = (TankerMethod)Conversions.ToByte(theNode2.InnerText);
					break;
				case "AssignedUnitsList":
					foreach (XmlNode childNode4 in theNode2.ChildNodes)
					{
						XmlNode val = childNode4;
						supportMission.UnitsAssignedToMissionIDs.Add(val.InnerText);
					}
					break;
				case "StationThrottle_Submarine":
					supportMission.StationThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationThrottle":
				case "LTh":
				case "StationThrottle_Aircraft":
					supportMission.StationThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "MinAircraftReq":
					supportMission.MinimumNumberOfAircraft = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "LAO":
				case "StationAltitude_Aircraft":
				case "StationAltitude":
					supportMission.StationAltitude_Aircraft = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "TankerFollowsReceivers":
					supportMission.TankerFollowsReceivers = Misc.ParseBool(theNode2.InnerText);
					break;
				case "UseStationAltitude_Preset":
					supportMission.UseStationAltitude_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "GroupSize":
					supportMission.GroupSize = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TAO":
				case "TransitAltitude":
				case "TransitAltitude_Aircraft":
					supportMission.TransitAltitude_Aircraft = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "Completion":
					supportMission.Completion = Conversions.ToSingle(theNode2.InnerText);
					break;
				case "TransitThrottle_Submarine":
					supportMission.TransitThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "Formation_Cruise":
					supportMission.Formation_Cruise = (_AircraftFormationType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MaxReceiversInQueuePerTanker_Airborne":
					supportMission.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "ContinousCoverage_AllowQRA":
					supportMission.ContinousCoverage_QRAEnable = Misc.ParseBool(theNode2.InnerText);
					break;
				case "StationAltitude_Preset":
					supportMission.StationAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationDepth_Submarine":
					supportMission.StationDepth_Submarine = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "TTh":
				case "TransitThrottle":
				case "TransitThrottle_Aircraft":
					supportMission.TransitThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationTerrainFollowing_Aircraft":
					supportMission.StationTerrainFollowing_Aircraft = Misc.ParseBool(theNode2.InnerText);
					break;
				}
			}
			if (supportMission.TransitThrottle_Submarine == ActiveUnit.Throttle.FullStop)
			{
				supportMission.TransitTerrainFollowing_Aircraft = false;
				supportMission.StationTerrainFollowing_Aircraft = false;
				supportMission.TransitThrottle_Submarine = ActiveUnit.Throttle.Cruise;
				supportMission.StationThrottle_Submarine = ActiveUnit.Throttle.Loiter;
				supportMission.TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
				supportMission.StationThrottle_Ship = ActiveUnit.Throttle.Loiter;
				supportMission.TransitThrottle_Facility = ActiveUnit.Throttle.Cruise;
				supportMission.StationThrottle_Facility = ActiveUnit.Throttle.Loiter;
			}
			if (supportMission.Doctrine.ReplenishmentSelection_Inherits())
			{
				supportMission.Doctrine.set_ReplenishmentSelection(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UnderwayRefuelAndReplenishmentSelection?)Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
			}
			if (supportMission.TransitAltitude_Aircraft.HasValue && supportMission.UseTransitAltitude_Preset == true)
			{
				supportMission.UseTransitAltitude_Preset = false;
				supportMission.TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			if (supportMission.StationAltitude_Aircraft.HasValue && supportMission.UseStationAltitude_Preset == true)
			{
				supportMission.UseStationAltitude_Preset = false;
				supportMission.StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			if (supportMission.TransitDepth_Submarine.HasValue && supportMission.UseTransitDepth_Submarine_Preset == true)
			{
				supportMission.UseTransitDepth_Submarine_Preset = false;
				supportMission.TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (supportMission.StationDepth_Submarine.HasValue && supportMission.UseStationDepth_Submarine_Preset == true)
			{
				supportMission.UseStationDepth_Submarine_Preset = false;
				supportMission.StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (!flag2)
			{
				supportMission.IncludeInATO = true;
			}
			if (supportMission.ContinousCoverage_QRANumberOfFlights == _FlightQty.NoPreferences)
			{
				supportMission.ContinousCoverage_Enable = false;
				supportMission.ContinousCoverage_FlightGenerationMethod = _ContinousCoverageMethod.Dynamic;
				supportMission.ContinousCoverage_StationTime = _ContinousCoverageStationTime.min_45;
				supportMission.ContinousCoverage_Overlap = _ContinousCoverageOverlap.Min_2;
				supportMission.ContinousCoverage_Duration = _ContinousCoverageDuration.hr_6;
				supportMission.ContinousCoverage_QRAEnable = false;
				supportMission.ContinousCoverage_QRAFlightGenerationMethod = _ContinousCoverageMethod.Dynamic;
				supportMission.ContinousCoverage_QRANumberOfFlights = _FlightQty.Flight_x1;
				supportMission.ContinousCoverage_NumberOfFlightsNeededToAllowQRA = _FlightQty.Flight_x2;
			}
			result = supportMission;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100651", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public SupportMission(ref Side theSide, ref Scenario theScen, string theName, MissionCategory theCategory, ref List<ReferencePoint> theCourse, bool ValidateArea)
		: base(theSide, theScen, theName)
	{
		NavigationCourse = new List<ReferencePoint>();
		NavigationCourse_ChangeCheck = new List<ReferencePoint>();
		NavigationCourse_2nm_ChangeCheck = new List<ReferencePoint>();
		NavigationCourse_2nm_Buffered = new List<ReferencePoint>();
		NavigationCourse_10nm_ChangeCheck = new List<ReferencePoint>();
		NavigationCourse_10nm_Buffered = new List<ReferencePoint>();
		RTBUponCompletion = true;
		IsMission = true;
		MissionClass = _MissionClass.Support;
		Name = theName;
		Category = theCategory;
		NavigationCourse = theCourse;
		NavigationLoopType = SupportMissionNavigationLoopType.ContinousLoop;
		TransitThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
		StationThrottle_Aircraft = ActiveUnit.Throttle.Loiter;
		TransitTerrainFollowing_Aircraft = false;
		StationTerrainFollowing_Aircraft = false;
		TransitThrottle_Submarine = ActiveUnit.Throttle.Cruise;
		StationThrottle_Submarine = ActiveUnit.Throttle.Loiter;
		TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
		StationThrottle_Ship = ActiveUnit.Throttle.Loiter;
		TransitThrottle_Facility = ActiveUnit.Throttle.Cruise;
		StationThrottle_Facility = ActiveUnit.Throttle.Loiter;
		IncludeInATO = true;
		OneThirdRule = true;
		TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.LoadoutAltitude;
		StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.LoadoutAltitude;
		UseTransitAltitude_Preset = true;
		UseStationAltitude_Preset = true;
		TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
		StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
		UseTransitDepth_Submarine_Preset = true;
		UseStationDepth_Submarine_Preset = true;
		base.FlightSize = 1;
		UseFlightSizeHardLimit = true;
		Doctrine.set_ReplenishmentSelection(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UnderwayRefuelAndReplenishmentSelection?)Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
		GroupSize = 1;
		ContinousCoverage_Enable = false;
		ContinousCoverage_FlightGenerationMethod = _ContinousCoverageMethod.Dynamic;
		ContinousCoverage_StationTime = _ContinousCoverageStationTime.min_45;
		ContinousCoverage_Overlap = _ContinousCoverageOverlap.Min_2;
		ContinousCoverage_Duration = _ContinousCoverageDuration.hr_6;
		ContinousCoverage_QRAEnable = false;
		ContinousCoverage_QRAFlightGenerationMethod = _ContinousCoverageMethod.Dynamic;
		ContinousCoverage_QRANumberOfFlights = _FlightQty.Flight_x1;
		ContinousCoverage_NumberOfFlightsNeededToAllowQRA = _FlightQty.Flight_x2;
		OneThirdGrouping = OneThirdGroupingType.ByLoadout;
	}

	public override void Printout(StringBuilder PrintoutStringBuilder)
	{
		throw new NotImplementedException();
	}

	public override Mission Clone(bool DeepCloneRPs)
	{
		SupportMission obj = (SupportMission)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Name = "[CLONE] " + Name;
		obj.NavigationCourse = new ReferencePoint().CopyRefArea(ref NavigationCourse, DeepCloneRPs);
		return obj;
	}

	static SupportMission()
	{
		Class72.smethod_20();
	}
}
