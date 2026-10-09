using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class MiningMission : Mission
{
	public class MiningInformation
	{
		private int? nullable_0;

		private int? nullable_1;

		private int? nullable_2;

		private byte? nullable_3;

		public bool StartedMining;

		public UnguidedWeapon LastMineLocal;

		public UnguidedWeapon LastMineSet;

		public int? Sequence
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

		public int? Spacing
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

		public int? SpacingSet
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

		public byte? Method
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

		public MiningInformation(UnguidedWeapon theLastMineLocal, int? theNumberInSet, int? theSpacing, byte? theMethod, int? theSpacingSet = null)
		{
			StartedMining = false;
			LastMineLocal = null;
			LastMineSet = null;
			nullable_0 = theNumberInSet;
			nullable_1 = theSpacing;
			nullable_2 = theSpacingSet;
			nullable_3 = theMethod;
			LastMineLocal = theLastMineLocal;
			StartedMining = false;
		}

		public MiningInformation()
		{
			StartedMining = false;
			LastMineLocal = null;
			LastMineSet = null;
			StartedMining = false;
		}

		public void ResetMiningInfo(ActiveUnit unit, MiningMission mission)
		{
			nullable_0 = mission.MinesLaidInSets;
			nullable_1 = mission.MinesLaidInterval;
			nullable_2 = mission.MinesLaidSetInterval;
			nullable_3 = mission.MinesLaidMethod;
			LastMineSet = LastMineLocal;
			LastMineLocal = null;
		}

		public void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
		{
			try
			{
				theWriter.WriteStartElement("MiningInformation");
				theWriter.WriteElementString("StartedMining", StartedMining.ToString());
				if (nullable_3.HasValue)
				{
					theWriter.WriteElementString("MinesLaidMethod", nullable_3.ToString());
				}
				if (nullable_0.HasValue)
				{
					theWriter.WriteElementString("MinesLaidInSets", nullable_0.ToString());
				}
				if (nullable_1.HasValue)
				{
					theWriter.WriteElementString("MinesLaidInterval", nullable_1.ToString());
				}
				if (nullable_2.HasValue)
				{
					theWriter.WriteElementString("MinesLaidSetInterval", nullable_2.ToString());
				}
				if (LastMineLocal != null)
				{
					theWriter.WriteElementString("LastMineLocal", LastMineLocal.ObjectID);
				}
				if (LastMineSet != null)
				{
					theWriter.WriteElementString("LastMineSet", LastMineSet.ObjectID);
				}
				theWriter.WriteEndElement();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100637", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static MiningInformation FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ActiveUnit_AI theAI)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			MiningInformation result;
			try
			{
				MiningInformation miningInformation = new MiningInformation();
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode val = childNode;
					switch (val.Name)
					{
					case "MinesLaidMethod":
						miningInformation.nullable_3 = Conversions.ToByte(val.InnerText);
						break;
					case "StartedMining":
						miningInformation.StartedMining = Misc.ParseBool(val.InnerText);
						break;
					case "MinesLaidInterval":
						miningInformation.nullable_1 = Conversions.ToInteger(val.InnerText);
						break;
					case "MinesLaidInSets":
						miningInformation.nullable_0 = Conversions.ToInteger(val.InnerText);
						break;
					case "LastMineSet":
						if (theDictionary.ContainsKey(val.InnerText))
						{
							miningInformation.LastMineSet = (UnguidedWeapon)theDictionary[val.InnerText];
						}
						break;
					case "LastMineLocal":
						if (theDictionary.ContainsKey(val.InnerText))
						{
							miningInformation.LastMineLocal = (UnguidedWeapon)theDictionary[val.InnerText];
						}
						break;
					case "MinesLaidSetInterval":
						miningInformation.nullable_2 = Conversions.ToInteger(val.InnerText);
						break;
					}
				}
				result = miningInformation;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100638", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = null;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		static MiningInformation()
		{
			Class72.smethod_20();
		}
	}

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

	public Patrol.PatrolMovementStyle MovementStyle;

	public bool OneThirdRule;

	public long ArmDelay;

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

	public _AircraftFormationType Formation_Cruise;

	public _AircraftFormationType Formation_Attack;

	public int? MinesLaidInSets;

	public int? MinesLaidInterval;

	public int? MinesLaidSetInterval;

	public byte? MinesLaidMethod;

	public override string DescriptionString => "Mining Mission";

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
		MinesLaidInSets = null;
		MinesLaidInterval = null;
		MinesLaidMethod = null;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("MiningMission");
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
			theWriter.WriteElementString("OTR", OneThirdRule.ToString());
			theWriter.WriteElementString("AD", ArmDelay.ToString());
			if (SecondaryAirBase != null)
			{
				theWriter.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				theWriter.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			theWriter.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			theWriter.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			theWriter.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			theWriter.WriteElementString("IncludeInATO", IncludeInATO.ToString());
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
			XmlWriter obj = theWriter;
			byte transitThrottle_Submarine = (byte)TransitThrottle_Submarine;
			obj.WriteElementString("TransitThrottle_Submarine", transitThrottle_Submarine.ToString());
			XmlWriter obj2 = theWriter;
			transitThrottle_Submarine = (byte)StationThrottle_Submarine;
			obj2.WriteElementString("StationThrottle_Submarine", transitThrottle_Submarine.ToString());
			if (TransitDepth_Submarine.HasValue)
			{
				theWriter.WriteElementString("TransitDepth_Submarine", TransitDepth_Submarine.Value.ToString());
			}
			if (StationDepth_Submarine.HasValue)
			{
				theWriter.WriteElementString("StationDepth_Submarine", StationDepth_Submarine.Value.ToString());
			}
			XmlWriter obj3 = theWriter;
			transitThrottle_Submarine = (byte)TransitThrottle_Ship;
			obj3.WriteElementString("TransitThrottle_Ship", transitThrottle_Submarine.ToString());
			XmlWriter obj4 = theWriter;
			transitThrottle_Submarine = (byte)StationThrottle_Ship;
			obj4.WriteElementString("StationThrottle_Ship", transitThrottle_Submarine.ToString());
			XmlWriter obj5 = theWriter;
			transitThrottle_Submarine = (byte)TransitThrottle_Facility;
			obj5.WriteElementString("TransitThrottle_Facility", transitThrottle_Submarine.ToString());
			XmlWriter obj6 = theWriter;
			transitThrottle_Submarine = (byte)StationThrottle_Facility;
			obj6.WriteElementString("StationThrottle_Facility", transitThrottle_Submarine.ToString());
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
			theWriter.WriteElementString("FlightSize", ((int)base.FlightSize).ToString());
			theWriter.WriteElementString("GroupSize", ((int)GroupSize).ToString());
			XmlWriter obj7 = theWriter;
			int formation_Cruise = (int)Formation_Cruise;
			obj7.WriteElementString("Formation_Cruise", formation_Cruise.ToString());
			XmlWriter obj8 = theWriter;
			formation_Cruise = (int)Formation_Attack;
			obj8.WriteElementString("Formation_Attack", formation_Cruise.ToString());
			XmlWriter obj9 = theWriter;
			formation_Cruise = (int)MinimumNumberOfAircraft;
			obj9.WriteElementString("MinAircraftReq", formation_Cruise.ToString());
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
			if (MinesLaidInSets.HasValue)
			{
				theWriter.WriteElementString("MinesLaidInSets", MinesLaidInSets.ToString());
			}
			if (MinesLaidInterval.HasValue)
			{
				theWriter.WriteElementString("MinesLaidInterval", MinesLaidInterval.ToString());
			}
			if (MinesLaidMethod.HasValue)
			{
				theWriter.WriteElementString("MinesLaidMethod", MinesLaidMethod.ToString());
			}
			if (MinesLaidSetInterval.HasValue)
			{
				theWriter.WriteElementString("MinesLaidSetInterval", MinesLaidSetInterval.ToString());
			}
			XmlWriter obj11 = theWriter;
			formation_Cruise = (int)MovementStyle;
			obj11.WriteElementString("MovementStyle", formation_Cruise.ToString());
			XmlWriter obj12 = theWriter;
			formation_Cruise = (int)OneThirdGrouping;
			obj12.WriteElementString("OneThirdStrictness", formation_Cruise.ToString());
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
			ex2?.Data.Add("Error at 100637", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static MiningMission FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, Mission existingObject = null)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0978: Unknown result type (might be due to invalid IL or missing references)
		//IL_097f: Expected O, but got Unknown
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Expected O, but got Unknown
		//IL_0dd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd9: Expected O, but got Unknown
		MiningMission result;
		try
		{
			bool flag;
			MiningMission miningMission;
			int num;
			if (!(flag = existingObject != null))
			{
				miningMission = new MiningMission(null, theScen, "");
				num = 0;
			}
			else
			{
				miningMission = (MiningMission)existingObject;
				miningMission.Reinitialize();
				num = 0;
			}
			bool flag2 = (byte)num != 0;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				Mission.FromXMLCommon(miningMission, theNode2);
				switch (theNode2.Name)
				{
				case "Status":
					((Mission)miningMission).set_Status(theScen, (MissionStatus)Conversions.ToByte(theNode2.InnerText));
					break;
				case "TransitTerrainFollowing_Aircraft":
					miningMission.TransitTerrainFollowing_Aircraft = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TransitDepth_Submarine_Preset":
					miningMission.TransitDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "Name":
					miningMission.Name = theNode2.InnerText;
					break;
				case "START":
				{
					DateTime value2 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					miningMission._StartTime = value2;
					break;
				}
				case "SISIH":
					miningMission.ScrubIfSideIsHuman = Misc.ParseBool(theNode2.InnerText);
					break;
				case "UseFlightplan":
					miningMission.UseFlightplans = Misc.ParseBool(theNode2.InnerText);
					break;
				case "IncludeInATO":
					miningMission.IncludeInATO = Misc.ParseBool(theNode2.InnerText);
					flag2 = true;
					break;
				case "UseGroupSizeHardLimit":
					miningMission.UseGroupSizeHardLimit = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Area":
					if (flag)
					{
						miningMission.Area.Clear();
					}
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						miningMission.Area.Add(ReferencePoint.FromXML(ref theNode3, ref theDictionary, theScen));
					}
					break;
				case "AD":
					miningMission.ArmDelay = Conversions.ToLong(theNode2.InnerText);
					break;
				case "TankerMinNumber_Airborne":
					miningMission.TankerMinNumber_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MinesLaidSetInterval":
					miningMission.MinesLaidSetInterval = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TankerMaxDistance_Airborne":
					miningMission.TankerMaxDistance_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "UseTransitDepth_Submarine_Preset":
					miningMission.UseTransitDepth_Submarine_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "LaunchMissionWithoutTankersInPlace":
					miningMission.LaunchMissionWithoutTankersInPlace = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TransitThrottle_Ship":
					miningMission.TransitThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "UseFlightplansOnly":
					miningMission.UsePreGeneratedFlightplansOnly = Misc.ParseBool(theNode2.InnerText);
					break;
				case "OTR":
				case "OneThirdRule":
					miningMission.OneThirdRule = Misc.ParseBool(theNode2.InnerText);
					break;
				case "EmptySlotsList":
					miningMission.EmptySlotsList = EmptyAircraftSlot.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "TankerMinNumber_Total":
					miningMission.TankerMinNumber_Total = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "StationThrottle_Ship":
					miningMission.StationThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TimeOnTarget":
				{
					DateTime value4 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					miningMission.TimeOnTarget = value4;
					break;
				}
				case "Doctrine":
					if (flag)
					{
						miningMission.Doctrine = Doctrine.FromXML(theScen, ref theNode2, miningMission, miningMission.Doctrine);
					}
					else
					{
						miningMission.Doctrine = Doctrine.FromXML(theScen, ref theNode2, miningMission);
					}
					break;
				case "HomeNavalbase":
					miningMission._SecondaryNavalBaseID = theNode2.InnerText;
					break;
				case "TakeOffTime":
				{
					DateTime value3 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					miningMission.TakeOffTime = value3;
					break;
				}
				case "ID":
					if (!theDictionary.ContainsKey(theNode2.InnerText))
					{
						miningMission.ObjectID_Set(theNode2.InnerText);
						theDictionary.TryAdd(miningMission.ObjectID, miningMission);
						break;
					}
					result = (MiningMission)theDictionary[theNode2.InnerText];
					goto end_IL_0001;
				case "StationThrottle_Facility":
					miningMission.StationThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TankerMinNumber_Station":
					miningMission.TankerMinNumber_Station = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "FuelQtyToStartLookingForTanker_Airborne":
					miningMission.FuelQtyToStartLookingForTanker_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "FlightList":
					miningMission.FlightList = Flight.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "FlightSize":
					miningMission.FlightSize = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MinesLaidInSets":
					miningMission.MinesLaidInSets = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TankerMissionList":
					if (flag)
					{
						miningMission.TankerMissions_IDs.Clear();
					}
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode val2 = childNode3;
						miningMission.TankerMissions_IDs.Add(val2.InnerText);
					}
					break;
				case "HomeAirbase":
					miningMission._SecondaryAirBaseID = theNode2.InnerText;
					break;
				case "UseFlightSizeHardLimit":
					miningMission.UseFlightSizeHardLimit = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TransitDepth_Submarine":
					miningMission.TransitDepth_Submarine = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "UseTransitAltitude_Preset":
					miningMission.UseTransitAltitude_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TransitThrottle_Facility":
					miningMission.TransitThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TransitAltitude_Preset":
					miningMission.TransitAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "MovementStyle":
					miningMission.MovementStyle = (Patrol.PatrolMovementStyle)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Category":
					miningMission.Category = (MissionCategory)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "END":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					miningMission._EndTime = value;
					break;
				}
				case "Formation_Attack":
					miningMission.Formation_Attack = (_AircraftFormationType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MinesLaidInterval":
					miningMission.MinesLaidInterval = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "KeepOnMissionWithoutTankersInPlace":
					miningMission.KeepOnMissionWithoutTankersInPlace = Misc.ParseBool(theNode2.InnerText);
					break;
				case "_Phase":
					miningMission._Phase = (MissionPhase)Conversions.ToByte(theNode2.InnerText);
					break;
				case "PriorityWeight":
					miningMission.PriorityWeight = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "OneThirdStrictness":
					miningMission.OneThirdGrouping = (OneThirdGroupingType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "UseStationDepth_Submarine_Preset":
					miningMission.UseStationDepth_Submarine_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "AssignedUnitsList":
					foreach (XmlNode childNode4 in theNode2.ChildNodes)
					{
						XmlNode val = childNode4;
						miningMission.UnitsAssignedToMissionIDs.Add(val.InnerText);
					}
					break;
				case "StationDepth_Submarine_Preset":
					miningMission.StationDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TankerUsage":
					miningMission.TankerUsage = (TankerMethod)Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationThrottle_Submarine":
					miningMission.StationThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationThrottle":
				case "StationThrottle_Aircraft":
					miningMission.StationThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationAltitude_Aircraft":
				case "StationAltitude":
					miningMission.StationAltitude_Aircraft = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "TankerFollowsReceivers":
					miningMission.TankerFollowsReceivers = Misc.ParseBool(theNode2.InnerText);
					break;
				case "GroupSize":
					miningMission.GroupSize = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TransitAltitude":
				case "TransitAltitude_Aircraft":
					miningMission.TransitAltitude_Aircraft = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "MinAircraftReq":
					miningMission.MinimumNumberOfAircraft = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Formation_Cruise":
					miningMission.Formation_Cruise = (_AircraftFormationType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "UseStationAltitude_Preset":
					miningMission.UseStationAltitude_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "StationAltitude_Preset":
					miningMission.StationAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "Completion":
					miningMission.Completion = Conversions.ToSingle(theNode2.InnerText);
					break;
				case "TransitThrottle_Submarine":
					miningMission.TransitThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationTerrainFollowing_Aircraft":
					miningMission.StationTerrainFollowing_Aircraft = Misc.ParseBool(theNode2.InnerText);
					break;
				case "MaxReceiversInQueuePerTanker_Airborne":
					miningMission.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MinesLaidMethod":
					miningMission.MinesLaidMethod = Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationDepth_Submarine":
					miningMission.StationDepth_Submarine = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "TransitThrottle":
				case "TransitThrottle_Aircraft":
					miningMission.TransitThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				}
			}
			if (miningMission.TransitThrottle_Submarine == ActiveUnit.Throttle.FullStop)
			{
				miningMission.TransitTerrainFollowing_Aircraft = false;
				miningMission.StationTerrainFollowing_Aircraft = false;
				miningMission.TransitThrottle_Submarine = ActiveUnit.Throttle.Cruise;
				miningMission.StationThrottle_Submarine = ActiveUnit.Throttle.Loiter;
				miningMission.TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
				miningMission.StationThrottle_Ship = ActiveUnit.Throttle.Loiter;
				miningMission.TransitThrottle_Facility = ActiveUnit.Throttle.Cruise;
				miningMission.StationThrottle_Facility = ActiveUnit.Throttle.Loiter;
			}
			if (miningMission.TransitAltitude_Aircraft.HasValue && miningMission.UseTransitAltitude_Preset == true)
			{
				miningMission.UseTransitAltitude_Preset = false;
				miningMission.TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			if (miningMission.StationAltitude_Aircraft.HasValue && miningMission.UseStationAltitude_Preset == true)
			{
				miningMission.UseStationAltitude_Preset = false;
				miningMission.StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			if (miningMission.TransitDepth_Submarine.HasValue && miningMission.UseTransitDepth_Submarine_Preset == true)
			{
				miningMission.UseTransitDepth_Submarine_Preset = false;
				miningMission.TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (miningMission.StationDepth_Submarine.HasValue && miningMission.UseStationDepth_Submarine_Preset == true)
			{
				miningMission.UseStationDepth_Submarine_Preset = false;
				miningMission.StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (miningMission.Doctrine.ReplenishmentSelection_Inherits())
			{
				miningMission.Doctrine.set_ReplenishmentSelection(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UnderwayRefuelAndReplenishmentSelection?)Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
			}
			if (!flag2)
			{
				miningMission.IncludeInATO = true;
			}
			result = miningMission;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100638", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new MiningMission(null, theScen, "");
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private MiningMission(Side theSide, Scenario theScen, string theName)
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
		MinesLaidInSets = null;
		MinesLaidInterval = null;
		MinesLaidSetInterval = null;
		MinesLaidMethod = null;
		IsMission = true;
		MissionClass = _MissionClass.Mining;
		OneThirdGrouping = OneThirdGroupingType.ByLoadout;
	}

	public MiningMission(Side theSide, Scenario theScen, string theName, MissionCategory theCategory, List<ReferencePoint> theArea, bool ValidateArea)
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
		MinesLaidInSets = null;
		MinesLaidInterval = null;
		MinesLaidSetInterval = null;
		MinesLaidMethod = null;
		IsMission = true;
		Name = theName;
		MissionClass = _MissionClass.Mining;
		Category = theCategory;
		Area = theArea;
		OneThirdRule = true;
		ArmDelay = 7200L;
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
		base.FlightSize = 4;
		GroupSize = 1;
		UseFlightSizeHardLimit = true;
		IncludeInATO = true;
		string UserFeedback = default(string);
		if (ValidateArea && !ActiveUnit_Navigator.ValidateArea(Area, ref UserFeedback, theSide, theScen, "Mining Mission '" + Name + "'"))
		{
			GameGeneral.SendMessageBoxToUI(UserFeedback, theSide);
		}
		Doctrine.set_ReplenishmentSelection(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UnderwayRefuelAndReplenishmentSelection?)Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
		Doctrine.set_WithdrawAttackThreshold(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WeaponQuantityThreshold?)Doctrine._WeaponQuantityThreshold.Exhausted);
		OneThirdGrouping = OneThirdGroupingType.ByLoadout;
	}

	public override void Printout(StringBuilder PrintoutStringBuilder)
	{
		throw new NotImplementedException();
	}

	public override Mission Clone(bool DeepCloneRPs)
	{
		MiningMission obj = (MiningMission)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Name = "[CLONE] " + Name;
		obj.Area = new ReferencePoint().CopyRefArea(ref Area, DeepCloneRPs);
		return obj;
	}

	static MiningMission()
	{
		Class72.smethod_20();
	}
}
