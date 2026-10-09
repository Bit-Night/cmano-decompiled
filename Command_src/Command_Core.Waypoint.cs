using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Waypoint : GeoPoint
{
	public sealed class FlightPlanSegment
	{
		public double StartLatitude;

		public double StartLongitude;

		public double EndLatitude;

		public double EndLongitude;

		public FlightPlanSegment(ref double theStartLatitude, double theStartLongitude, double theEndLatitude, double theEndLongitude)
		{
			StartLatitude = theStartLatitude;
			StartLongitude = theStartLongitude;
			EndLatitude = theEndLatitude;
			EndLongitude = theEndLongitude;
		}

		public FlightPlanSegment()
		{
		}

		static FlightPlanSegment()
		{
			Class72.smethod_20();
		}
	}

	public enum WaypointType
	{
		ManualPlottedCourseWaypoint,
		PatrolStation,
		TerminalPoint,
		LocalizationRun,
		PathfindingPoint,
		Assemble,
		TurningPoint,
		InitialPoint,
		Split,
		Formate,
		Target,
		LandingMarshal,
		StrikeIngress,
		StrikeEgress,
		Refuel,
		TakeOff,
		Marshal,
		WeaponLaunch,
		Land,
		WeaponTarget,
		StationStart_Racetrack,
		StationStart_FigureEight,
		StationStart_Area,
		StationStart_RaceTrackRandom,
		StationEnd,
		PickupPoint,
		HoldStart,
		HoldEnd,
		Launch,
		Activation,
		Termination,
		DropOffPoint
	}

	public enum WaypointCategory
	{
		PlottedCourse,
		FlightPlan,
		WeaponRoute
	}

	public enum WaypointCreator : byte
	{
		Pathfinder,
		Navigator,
		Manual,
		MissionPlanner
	}

	public enum TurnRateCategory : byte
	{
		StandardRateTurn,
		HalfStandardRateTurn,
		DoubleStandardRateTurn,
		FlatTurn,
		TwoGTurn,
		const_5,
		const_6
	}

	public enum FixedFree
	{
		Free,
		Fixed,
		Bound,
		Relative,
		None
	}

	public enum Formation
	{
		Spread = 0,
		Trail_1nm = 1,
		Split = 100
	}

	public enum SpeedToT
	{
		No,
		Yes_DownOnly,
		Yes_UpOrDown_Military,
		Yes_UpOrDown_Afterburner
	}

	public WaypointType Type;

	public WaypointCategory Category;

	public string Description;

	public bool IsManualEditable;

	private ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0;

	private ActiveUnit_AI.AircraftAltitudePreset aircraftAltitudePreset_0;

	private ActiveUnit_AI.SubmarineDepthPreset submarineDepthPreset_0;

	private bool bool_0;

	private float? nullable_0;

	public ActiveUnit.TerrainFollowMode TerrainFollowingType;

	public string EventActionID;

	private int int_1;

	public float ActualSpeed;

	private float? nullable_1;

	public bool OvershootWaypoint;

	private float? nullable_2;

	private float? nullable_3;

	private bool bool_1;

	public bool? SprintDrift;

	public float? SprintDrift_AverageSpeed;

	public bool? AvoidCavitation;

	public WaypointCreator Creator;

	private DateTime? nullable_4;

	public DateTime? Time_Zulu_Weapon;

	public DateTime? Time_Local;

	public DateTime? Time_Local_Weapon;

	public Weather.TTimeOfDayType TimeOfDay;

	public FixedFree TimeFixed;

	public FixedFree SpeedFixed;

	public SpeedToT SpeedAdjustmentToT;

	public Formation FlightFormation;

	public float Leg_FuelRequired;

	private float float_1;

	private float float_2;

	public float Leg_Time_Turn;

	private float float_3;

	public float Leg_TotalTime;

	public float Leg_Time_ErrorMargin;

	public float Leg_Distance_Straight;

	public float Leg_Distance_Turn;

	public float Leg_Speed_Straight;

	public float Leg_Speed_Turn;

	public float Leg_TotalDistance;

	public bool Leg_PreviousWaypointIsFixedSpeed;

	public bool Leg_TwoWaypointsAgoIsFixedSpeed;

	public Waypoint Waypoint_LeadElementWingman;

	public Waypoint Waypoint_SecondElement;

	public Waypoint Waypoint_SecondElementWingman;

	public Waypoint Waypoint_ThirdElement;

	public Waypoint Waypoint_ThirdElementWingman;

	public float Leg_FuelRemaining_LeadElementWingman;

	public float Leg_FuelRemaining_SecondElement;

	public float Leg_FuelRemaining_SecondElementWingman;

	public float Leg_FuelRemaining_ThirdElement;

	public float Leg_FuelRemaining_ThirdElementWingman;

	public float Leg_TotalDistance_LeadElementWingman;

	public float Leg_TotalDistance_SecondElement;

	public float Leg_TotalDistance_SecondElementWingman;

	public float Leg_TotalDistance_ThirdElement;

	public float Leg_TotalDistance_ThirdElementWingman;

	public float Hold_Time;

	public float Station_Time;

	public float SpacingManeuver_Time;

	public float Separation_Time;

	public Mission._AttackMethod AttackMethod;

	public TurnRateCategory TurnRate_Navigation;

	public Mission.TankerMethod TankerUsage;

	public List<string> TankerMissions_IDs;

	public List<Mission> TankerMissions;

	public int MaxReceiversInQueuePerTanker_Airborne;

	public int TankerMaxDistance_Airborne;

	public bool TankerFollowsReceivers;

	public int TankerFollowsReceivers_NumberOfWaypoints;

	public List<FlightPlanSegment> FlightplanPointsList;

	public GeoPoint RaceTrackHelperPoint;

	public int PreferredWeaponID;

	public string PreferredWeaponName;

	public float PreferredWeaponSpeed;

	public float PreferredWeaponAltitude;

	public float PreferredWeaponRange;

	public Mission._TargeteeringMethod TargeteeringMethod;

	public WriteLockedList<Mission.TargeteeringEntry> TargeteeringList;

	public WriteLockedList<Mission.TargeteeringEntry> TargeteeringList_LeadElementWingman;

	public WriteLockedList<Mission.TargeteeringEntry> TargeteeringList_SecondElement;

	public WriteLockedList<Mission.TargeteeringEntry> TargeteeringList_SecondElementWingman;

	public WriteLockedList<Mission.TargeteeringEntry> TargeteeringList_ThirdElement;

	public WriteLockedList<Mission.TargeteeringEntry> TargeteeringList_ThirdElementWingman;

	public ConcurrentBag<Mission.WeaponeeringEntry> WeaponeeringList;

	public ConcurrentBag<Mission.WeaponeeringEntry> WeaponeeringList_LeadElementWingman;

	public ConcurrentBag<Mission.WeaponeeringEntry> WeaponeeringList_SecondElement;

	public ConcurrentBag<Mission.WeaponeeringEntry> WeaponeeringList_SecondElementWingman;

	public ConcurrentBag<Mission.WeaponeeringEntry> WeaponeeringList_ThirdElement;

	public ConcurrentBag<Mission.WeaponeeringEntry> WeaponeeringList_ThirdElementWingman;

	private Doctrine doctrine_0;

	public int ReferenceWeapon_ID
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public float? DesiredSpeed
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

	public float? DesiredAltitude
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

	public float? DesiredAltitude_TerrainFollowing
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

	public DateTime? Time_Zulu
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

	public float Leg_FuelRemaining
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public float Leg_Time_Straight
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	public float Leg_Time_Weapon
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	public bool HasDoctrine => doctrine_0 != null;

	public float? DesiredSpeedOverride
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

	public bool DesiredAltitudeOverride
	{
		get
		{
			return bool_1;
		}
		set
		{
			if (!value)
			{
				TerrainFollowing = false;
			}
			bool_1 = value;
		}
	}

	public ActiveUnit_AI.AircraftAltitudePreset AltitudePreset
	{
		get
		{
			return aircraftAltitudePreset_0;
		}
		set
		{
			aircraftAltitudePreset_0 = value;
			if (value != ActiveUnit_AI.AircraftAltitudePreset.None)
			{
				DesiredAltitudeOverride = true;
			}
		}
	}

	public ActiveUnit_AI.SubmarineDepthPreset DepthPreset
	{
		get
		{
			return submarineDepthPreset_0;
		}
		set
		{
			submarineDepthPreset_0 = value;
			if (value != ActiveUnit_AI.SubmarineDepthPreset.None)
			{
				DesiredAltitudeOverride = true;
			}
		}
	}

	public ActiveUnit_Kinematics.UnitThrottlePreset ThrottlePreset
	{
		get
		{
			return unitThrottlePreset_0;
		}
		set
		{
			unitThrottlePreset_0 = value;
		}
	}

	public bool TerrainFollowing
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (value && !DesiredAltitudeOverride)
			{
				DesiredAltitudeOverride = true;
			}
			bool_0 = value;
		}
	}

	public static string WaypointTypeString => theWaypointType switch
	{
		WaypointType.TerminalPoint => "Terminal Point", 
		WaypointType.Assemble => "Assemble", 
		WaypointType.TurningPoint => "Turning Point", 
		WaypointType.InitialPoint => "Initial Point (IP)", 
		WaypointType.Split => "Split", 
		WaypointType.Formate => "Formate", 
		WaypointType.Target => "Target", 
		WaypointType.LandingMarshal => "Landing Marshal Point", 
		WaypointType.StrikeIngress => "Turning Point (Ingress)", 
		WaypointType.StrikeEgress => "Turning Point (Egress)", 
		WaypointType.Refuel => "Refuel", 
		WaypointType.TakeOff => "Take-Off", 
		WaypointType.Marshal => "Marshal", 
		WaypointType.WeaponLaunch => "Weapon Launch", 
		WaypointType.Land => "Land", 
		WaypointType.WeaponTarget => "Weapon Target", 
		WaypointType.StationStart_Racetrack => "Station Start (Racetrack)", 
		WaypointType.StationStart_FigureEight => "Station Start (Figure Eight)", 
		WaypointType.StationStart_Area => "Station Start (Area)", 
		WaypointType.StationStart_RaceTrackRandom => "Station Start (Racetrack + Random)", 
		WaypointType.StationEnd => "Station End", 
		WaypointType.HoldStart => "Hold Start", 
		WaypointType.HoldEnd => "Hold End", 
		WaypointType.Launch => "Launch", 
		WaypointType.Activation => "Activation", 
		WaypointType.Termination => "Termination", 
		_ => "None", 
	};

	public static string FormationString => theWaypointType switch
	{
		Formation.Split => "Split", 
		Formation.Trail_1nm => "1nm Trail", 
		Formation.Spread => "Spread", 
		_ => "None", 
	};

	public static string TurnRateString => theTurnRate switch
	{
		TurnRateCategory.StandardRateTurn => "Standard Rate, 3 degrees per second", 
		TurnRateCategory.HalfStandardRateTurn => "Half Standard Rate, 1.5 degrees per second", 
		TurnRateCategory.DoubleStandardRateTurn => "Double Standard Rate, 6 degrees per second", 
		TurnRateCategory.FlatTurn => "Flat turn (no bank angle), 0.6 degrees per second", 
		TurnRateCategory.TwoGTurn => "2G turn, 60 degree bank angle", 
		TurnRateCategory.const_5 => "3G turn, 70 degree bank angle", 
		TurnRateCategory.const_6 => "4G turn, 75 degree bank angle", 
		_ => "None", 
	};

	public static string SpeedToTString => theWaypointSetting switch
	{
		SpeedToT.No => "No", 
		SpeedToT.Yes_DownOnly => "Yes, down only", 
		SpeedToT.Yes_UpOrDown_Military => "Yes, down or up (max: Military)", 
		SpeedToT.Yes_UpOrDown_Afterburner => "Yes, down or up (max: Afterburner)", 
		_ => "None", 
	};

	public static Waypoint Move_Distance_NM_Bearing(Waypoint toMove, double distance, double bearing)
	{
		double latitude = toMove.Latitude;
		double longitude = toMove.Longitude;
		double num = bearing * (Math.PI / 180.0);
		double num2 = distance / 3441.6865234375;
		double num3 = latitude * (Math.PI / 180.0);
		double num4 = longitude * (Math.PI / 180.0);
		double num5 = Math.Asin(Math.Sin(num3) * Math.Cos(num2) + Math.Cos(num3) * Math.Sin(num2) * Math.Cos(num));
		double num6 = num4 + Math.Atan2(Math.Sin(num) * Math.Sin(num2) * Math.Cos(num3), Math.Cos(num2) - Math.Sin(num3) * Math.Sin(num5));
		num5 *= 180.0 / Math.PI;
		num6 *= 180.0 / Math.PI;
		toMove.Latitude = num5;
		toMove.Longitude = num6;
		return toMove;
	}

	public Doctrine GetDoctrine(Scenario ScenarioContext, bool AutoPopulate = true)
	{
		if (doctrine_0 == null && AutoPopulate)
		{
			List<ActiveUnit> DoctrineSelectedUnits = null;
			doctrine_0 = new Doctrine(ScenarioContext, this, ref DoctrineSelectedUnits);
		}
		return doctrine_0;
	}

	public void setAARTOAllowed(Scenario ScenarioContext, Mission theMission)
	{
		Doctrine doctrine = GetDoctrine(ScenarioContext);
		doctrine.set_UseReplenishment(ScenarioContext, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, theMission.Doctrine.get_UseReplenishment(ScenarioContext, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false));
		doctrine_0 = doctrine;
	}

	internal new void Reinitialize()
	{
		nullable_1 = null;
		DesiredAltitude_TerrainFollowing = null;
		DesiredSpeed = null;
		nullable_3 = null;
		Description = "";
		IsManualEditable = false;
		SprintDrift = null;
		SprintDrift_AverageSpeed = null;
		AvoidCavitation = null;
		Time_Zulu = null;
		Time_Zulu_Weapon = null;
		Time_Local = null;
		Time_Local_Weapon = null;
		TankerMissions.Clear();
		TankerMissions_IDs.Clear();
		FlightplanPointsList = null;
		PreferredWeaponName = "";
		Waypoint_LeadElementWingman = null;
		Waypoint_SecondElement = null;
		Waypoint_SecondElementWingman = null;
		Waypoint_ThirdElement = null;
		Waypoint_ThirdElementWingman = null;
		RaceTrackHelperPoint = null;
		doctrine_0 = null;
		TargeteeringList = null;
		TargeteeringList_LeadElementWingman = null;
		TargeteeringList_SecondElement = null;
		TargeteeringList_SecondElementWingman = null;
		TargeteeringList_ThirdElement = null;
		TargeteeringList_ThirdElementWingman = null;
		WeaponeeringList = null;
		WeaponeeringList_LeadElementWingman = null;
		WeaponeeringList_SecondElement = null;
		WeaponeeringList_SecondElementWingman = null;
		WeaponeeringList_ThirdElement = null;
		WeaponeeringList_ThirdElementWingman = null;
	}

	public void ToXML(ref XmlWriter theWriter, [Optional][DefaultParameterValue(null)] ref HashSet<string> ObjectsAlreadySerialized, string WPName = "WPoint")
	{
		try
		{
			theWriter.WriteStartElement(WPName);
			theWriter.WriteElementString("ID", ObjectID);
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					theWriter.WriteEndElement();
					return;
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
			theWriter.WriteElementString("Lon", XmlConvert.ToString(base.Longitude));
			theWriter.WriteElementString("Lat", XmlConvert.ToString(base.Latitude));
			if (base.Altitude != 0f)
			{
				theWriter.WriteElementString("Alt", XmlConvert.ToString(base.Altitude));
			}
			if (DesiredAltitude.HasValue)
			{
				theWriter.WriteElementString("DesiredAltitude", DesiredAltitude.ToString());
			}
			if (DesiredAltitude_TerrainFollowing.HasValue)
			{
				theWriter.WriteElementString("DesiredAltitude_TerrainFollowing", DesiredAltitude_TerrainFollowing.ToString());
			}
			int terrainFollowingType;
			if (TerrainFollowingType != ActiveUnit.TerrainFollowMode.IgnoreLandCover)
			{
				XmlWriter obj = theWriter;
				terrainFollowingType = (int)TerrainFollowingType;
				obj.WriteElementString("TFT", terrainFollowingType.ToString());
			}
			if (DesiredSpeed.HasValue)
			{
				theWriter.WriteElementString("DesiredSpeed", DesiredSpeed.ToString());
			}
			if (!string.IsNullOrEmpty(Name))
			{
				theWriter.WriteElementString("Name", Name.ToString());
			}
			if (Creator != WaypointCreator.Pathfinder)
			{
				XmlWriter obj2 = theWriter;
				terrainFollowingType = (int)Creator;
				obj2.WriteElementString("Creator", terrainFollowingType.ToString());
			}
			XmlWriter obj3 = theWriter;
			terrainFollowingType = (int)Type;
			obj3.WriteElementString("Type", terrainFollowingType.ToString());
			if (Category != WaypointCategory.PlottedCourse)
			{
				XmlWriter obj4 = theWriter;
				terrainFollowingType = (int)Category;
				obj4.WriteElementString("Category", terrainFollowingType.ToString());
			}
			if (!string.IsNullOrEmpty(Description))
			{
				theWriter.WriteElementString("Description", Description.ToString());
			}
			theWriter.WriteElementString("ThrottlePreset", ((byte)ThrottlePreset).ToString());
			if (AltitudePreset != ActiveUnit_AI.AircraftAltitudePreset.None)
			{
				theWriter.WriteElementString("AltitudePreset", ((byte)AltitudePreset).ToString());
			}
			if (DepthPreset != ActiveUnit_AI.SubmarineDepthPreset.None)
			{
				theWriter.WriteElementString("DepthPreset", ((byte)DepthPreset).ToString());
			}
			if (TurnRate_Navigation != TurnRateCategory.StandardRateTurn)
			{
				XmlWriter obj5 = theWriter;
				byte turnRate_Navigation = (byte)TurnRate_Navigation;
				obj5.WriteElementString("TurnRate", turnRate_Navigation.ToString());
			}
			if (IsManualEditable)
			{
				theWriter.WriteElementString("IME", true.ToString());
			}
			if (TerrainFollowing)
			{
				theWriter.WriteElementString("TerrainFollowing", TerrainFollowing.ToString());
			}
			if (nullable_3.HasValue)
			{
				theWriter.WriteElementString("DSO", nullable_3.ToString());
			}
			if (bool_1)
			{
				theWriter.WriteElementString("DAO", bool_1.ToString());
			}
			if (SprintDrift.HasValue)
			{
				theWriter.WriteElementString("SprintDrift", SprintDrift.ToString());
			}
			if (SprintDrift_AverageSpeed.HasValue)
			{
				theWriter.WriteElementString("SprintDrift_AverageSpeed", SprintDrift_AverageSpeed.Value.ToString());
			}
			if (AvoidCavitation.HasValue)
			{
				theWriter.WriteElementString("AvoidCavitation", AvoidCavitation.ToString());
			}
			if (Time_Zulu.HasValue)
			{
				theWriter.WriteElementString("Time_Zulu", Time_Zulu.Value.ToBinary().ToString());
			}
			if (Time_Zulu_Weapon.HasValue)
			{
				theWriter.WriteElementString("Time_Zulu_Weapon", Time_Zulu_Weapon.Value.ToBinary().ToString());
			}
			if (Time_Local.HasValue)
			{
				theWriter.WriteElementString("Time_Local", Time_Local.Value.ToBinary().ToString());
			}
			if (Time_Local_Weapon.HasValue)
			{
				theWriter.WriteElementString("Time_Local_Weapon", Time_Local_Weapon.Value.ToBinary().ToString());
			}
			if (TimeOfDay != Weather.TTimeOfDayType.tod_Day)
			{
				XmlWriter obj6 = theWriter;
				byte turnRate_Navigation = (byte)TimeOfDay;
				obj6.WriteElementString("TimeOfDay", turnRate_Navigation.ToString());
			}
			if (TimeFixed != FixedFree.Free)
			{
				XmlWriter obj7 = theWriter;
				terrainFollowingType = (int)TimeFixed;
				obj7.WriteElementString("TimeFixed", terrainFollowingType.ToString());
			}
			if (SpeedFixed != FixedFree.Free)
			{
				XmlWriter obj8 = theWriter;
				terrainFollowingType = (int)SpeedFixed;
				obj8.WriteElementString("SpeedFixed", terrainFollowingType.ToString());
			}
			if (FlightFormation != Formation.Spread)
			{
				XmlWriter obj9 = theWriter;
				terrainFollowingType = (int)FlightFormation;
				obj9.WriteElementString("FlightFormation", terrainFollowingType.ToString());
			}
			if (SpeedAdjustmentToT != SpeedToT.No)
			{
				XmlWriter obj10 = theWriter;
				terrainFollowingType = (int)SpeedAdjustmentToT;
				obj10.WriteElementString("SpeedAdjustmentToT", terrainFollowingType.ToString());
			}
			if (!string.IsNullOrEmpty(EventActionID))
			{
				theWriter.WriteElementString("EventActionID", EventActionID.ToString());
			}
			if (TankerUsage != Mission.TankerMethod.Automatic)
			{
				XmlWriter obj11 = theWriter;
				byte turnRate_Navigation = (byte)TankerUsage;
				obj11.WriteElementString("TankerUsage", turnRate_Navigation.ToString());
			}
			if (TankerMissions.Count > 0)
			{
				theWriter.WriteStartElement("TankerMissionList");
				foreach (Mission tankerMission in TankerMissions)
				{
					if (!Information.IsNothing((object)tankerMission))
					{
						theWriter.WriteElementString("ID", tankerMission.ObjectID);
					}
				}
				theWriter.WriteEndElement();
			}
			if (MaxReceiversInQueuePerTanker_Airborne > 0)
			{
				theWriter.WriteElementString("MaxReceiversInQueuePerTanker_Airborne", MaxReceiversInQueuePerTanker_Airborne.ToString());
			}
			if (TankerFollowsReceivers)
			{
				theWriter.WriteElementString("TankerFollowsReceivers", TankerFollowsReceivers.ToString());
			}
			if (TankerFollowsReceivers_NumberOfWaypoints > 0)
			{
				theWriter.WriteElementString("TankerFollowsReceivers_NumberOfWaypoints", TankerFollowsReceivers_NumberOfWaypoints.ToString());
			}
			if (Leg_FuelRequired != 0f)
			{
				theWriter.WriteElementString("Leg_FuelRequired", Leg_FuelRequired.ToString());
			}
			if (Leg_FuelRemaining != 0f)
			{
				theWriter.WriteElementString("Leg_FuelRemaining", Leg_FuelRemaining.ToString());
			}
			if (Leg_Time_Turn != 0f)
			{
				theWriter.WriteElementString("Leg_Time_Turn", Leg_Time_Turn.ToString());
			}
			if (Leg_Time_Straight != 0f)
			{
				theWriter.WriteElementString("Leg_Time_Straight", Leg_Time_Straight.ToString());
			}
			if (Leg_Time_Weapon != 0f)
			{
				theWriter.WriteElementString("Leg_Time_Weapon", Leg_Time_Weapon.ToString());
			}
			if (Leg_TotalTime != 0f)
			{
				theWriter.WriteElementString("Leg_TotalTime", Leg_TotalTime.ToString());
			}
			if (Leg_Time_ErrorMargin != 0f)
			{
				theWriter.WriteElementString("Leg_Time_ErrorMargin", Leg_Time_ErrorMargin.ToString());
			}
			if (Leg_Distance_Straight != 0f)
			{
				theWriter.WriteElementString("Leg_Distance", Leg_Distance_Straight.ToString());
			}
			if (Leg_TotalDistance != 0f)
			{
				theWriter.WriteElementString("Leg_TotalDistance", Leg_TotalDistance.ToString());
			}
			if (Hold_Time != 0f)
			{
				theWriter.WriteElementString("Hold_Time", Hold_Time.ToString());
			}
			if (Station_Time != 0f)
			{
				theWriter.WriteElementString("Station_Time", Station_Time.ToString());
			}
			if (SpacingManeuver_Time != 0f)
			{
				theWriter.WriteElementString("SpacingManeuver_Time", SpacingManeuver_Time.ToString());
			}
			if (!Information.IsNothing((object)FlightplanPointsList) && FlightplanPointsList.Count > 0)
			{
				theWriter.WriteStartElement("FlightplanPointsList");
				foreach (FlightPlanSegment flightplanPoints in FlightplanPointsList)
				{
					if (!Information.IsNothing((object)flightplanPoints))
					{
						theWriter.WriteStartElement("FlightPlanSegment");
						theWriter.WriteElementString("StartLatitude", flightplanPoints.StartLatitude.ToString());
						theWriter.WriteElementString("StartLongitude", flightplanPoints.StartLongitude.ToString());
						theWriter.WriteElementString("EndLatitude", flightplanPoints.EndLatitude.ToString());
						theWriter.WriteElementString("EndLongitude", flightplanPoints.EndLongitude.ToString());
						theWriter.WriteEndElement();
					}
				}
				theWriter.WriteEndElement();
			}
			if (PreferredWeaponID != 0)
			{
				theWriter.WriteElementString("PreferredWeaponID", PreferredWeaponID.ToString());
			}
			if (!string.IsNullOrEmpty(PreferredWeaponName))
			{
				theWriter.WriteElementString("PreferredWeaponName", PreferredWeaponName.ToString());
			}
			if (PreferredWeaponSpeed != 0f)
			{
				theWriter.WriteElementString("PreferredWeaponSpeed", PreferredWeaponSpeed.ToString());
			}
			if (PreferredWeaponAltitude != 0f)
			{
				theWriter.WriteElementString("PreferredWeaponAltitude", PreferredWeaponAltitude.ToString());
			}
			if (PreferredWeaponRange != 0f)
			{
				theWriter.WriteElementString("PreferredWeaponRange", PreferredWeaponRange.ToString());
			}
			if (!Information.IsNothing((object)Waypoint_LeadElementWingman))
			{
				theWriter.WriteStartElement("WP_LeadElementWingman");
				Waypoint_LeadElementWingman.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)Waypoint_SecondElement))
			{
				theWriter.WriteStartElement("WP_SecondElement");
				Waypoint_SecondElement.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)Waypoint_SecondElementWingman))
			{
				theWriter.WriteStartElement("WP_SecondElementWingman");
				Waypoint_SecondElementWingman.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)Waypoint_ThirdElement))
			{
				theWriter.WriteStartElement("WP_ThirdElement");
				Waypoint_ThirdElement.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)Waypoint_ThirdElementWingman))
			{
				theWriter.WriteStartElement("WP_ThirdElementWingman");
				Waypoint_ThirdElementWingman.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteEndElement();
			}
			if (Leg_FuelRemaining_LeadElementWingman > 0f)
			{
				theWriter.WriteElementString("Leg_FuelRemaining_LeadElementWingman", Leg_FuelRemaining_LeadElementWingman.ToString());
			}
			if (Leg_FuelRemaining_SecondElement > 0f)
			{
				theWriter.WriteElementString("Leg_FuelRemaining_SecondElement", Leg_FuelRemaining_SecondElement.ToString());
			}
			if (Leg_FuelRemaining_SecondElementWingman > 0f)
			{
				theWriter.WriteElementString("Leg_FuelRemaining_SecondElementWingman", Leg_FuelRemaining_SecondElementWingman.ToString());
			}
			if (Leg_FuelRemaining_ThirdElement > 0f)
			{
				theWriter.WriteElementString("Leg_FuelRemaining_ThirdElement", Leg_FuelRemaining_ThirdElement.ToString());
			}
			if (Leg_FuelRemaining_ThirdElementWingman > 0f)
			{
				theWriter.WriteElementString("Leg_FuelRemaining_ThirdElementWingman", Leg_FuelRemaining_ThirdElementWingman.ToString());
			}
			if (Leg_TotalDistance_LeadElementWingman > 0f)
			{
				theWriter.WriteElementString("Leg_TotalDistance_LeadElementWingman", Leg_TotalDistance_LeadElementWingman.ToString());
			}
			if (Leg_TotalDistance_SecondElement > 0f)
			{
				theWriter.WriteElementString("Leg_TotalDistance_SecondElement", Leg_TotalDistance_SecondElement.ToString());
			}
			if (Leg_TotalDistance_SecondElementWingman > 0f)
			{
				theWriter.WriteElementString("Leg_TotalDistance_SecondElementWingman", Leg_TotalDistance_SecondElementWingman.ToString());
			}
			if (Leg_TotalDistance_ThirdElement > 0f)
			{
				theWriter.WriteElementString("Leg_TotalDistance_ThirdElement", Leg_TotalDistance_ThirdElement.ToString());
			}
			if (Leg_TotalDistance_ThirdElementWingman > 0f)
			{
				theWriter.WriteElementString("Leg_TotalDistance_ThirdElementWingman", Leg_TotalDistance_ThirdElementWingman.ToString());
			}
			XmlWriter obj12 = theWriter;
			terrainFollowingType = (int)AttackMethod;
			obj12.WriteElementString("AttackMethod", terrainFollowingType.ToString());
			if (Separation_Time > 0f)
			{
				theWriter.WriteElementString("AttackMethod_Time", Separation_Time.ToString());
			}
			if (!Information.IsNothing((object)RaceTrackHelperPoint))
			{
				theWriter.WriteStartElement("RaceTrackHelperPoint");
				theWriter.WriteRaw(RaceTrackHelperPoint.ToXML(ObjectsAlreadySerialized));
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)doctrine_0))
			{
				Doctrine doctrine = doctrine_0;
				Scenario theScen = null;
				doctrine.ToXML(ref theWriter, ref theScen);
			}
			theWriter.WriteElementString("ReferenceWeapon", ReferenceWeapon_ID.ToString());
			theWriter.WriteElementString("TargeteeringMethod", ((byte)TargeteeringMethod).ToString());
			if (!Information.IsNothing((object)TargeteeringList))
			{
				theWriter.WriteStartElement("TargeteeringList");
				foreach (Mission.TargeteeringEntry targeteering in TargeteeringList)
				{
					Mission.TargeteeringEntry theEntry = targeteering;
					if (!Information.IsNothing((object)theEntry))
					{
						Mission.TargeteeringEntry.ToXML(ref theWriter, ref theEntry);
					}
				}
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)TargeteeringList_LeadElementWingman))
			{
				theWriter.WriteStartElement("TargeteeringList_LeadElementWingman");
				foreach (Mission.TargeteeringEntry item in TargeteeringList_LeadElementWingman)
				{
					Mission.TargeteeringEntry theEntry2 = item;
					if (!Information.IsNothing((object)theEntry2))
					{
						Mission.TargeteeringEntry.ToXML(ref theWriter, ref theEntry2);
					}
				}
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)TargeteeringList_SecondElement))
			{
				theWriter.WriteStartElement("TargeteeringList_SecondElement");
				foreach (Mission.TargeteeringEntry item2 in TargeteeringList_SecondElement)
				{
					Mission.TargeteeringEntry theEntry3 = item2;
					if (!Information.IsNothing((object)theEntry3))
					{
						Mission.TargeteeringEntry.ToXML(ref theWriter, ref theEntry3);
					}
				}
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)TargeteeringList_SecondElementWingman))
			{
				theWriter.WriteStartElement("TargeteeringList_SecondElementWingman");
				foreach (Mission.TargeteeringEntry item3 in TargeteeringList_SecondElementWingman)
				{
					Mission.TargeteeringEntry theEntry4 = item3;
					if (!Information.IsNothing((object)theEntry4))
					{
						Mission.TargeteeringEntry.ToXML(ref theWriter, ref theEntry4);
					}
				}
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)TargeteeringList_ThirdElement))
			{
				theWriter.WriteStartElement("TargeteeringList_ThirdElement");
				foreach (Mission.TargeteeringEntry item4 in TargeteeringList_ThirdElement)
				{
					Mission.TargeteeringEntry theEntry5 = item4;
					if (!Information.IsNothing((object)theEntry5))
					{
						Mission.TargeteeringEntry.ToXML(ref theWriter, ref theEntry5);
					}
				}
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)TargeteeringList_ThirdElementWingman))
			{
				theWriter.WriteStartElement("TargeteeringList_ThirdElementWingman");
				foreach (Mission.TargeteeringEntry item5 in TargeteeringList_ThirdElementWingman)
				{
					Mission.TargeteeringEntry theEntry6 = item5;
					if (!Information.IsNothing((object)theEntry6))
					{
						Mission.TargeteeringEntry.ToXML(ref theWriter, ref theEntry6);
					}
				}
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)WeaponeeringList))
			{
				theWriter.WriteStartElement("WeaponeeringList");
				foreach (Mission.WeaponeeringEntry weaponeering in WeaponeeringList)
				{
					Mission.WeaponeeringEntry theEntry7 = weaponeering;
					if (!Information.IsNothing((object)theEntry7))
					{
						Mission.WeaponeeringEntry.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref theEntry7);
					}
				}
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)WeaponeeringList_LeadElementWingman))
			{
				theWriter.WriteStartElement("WeaponeeringList_LeadElementWingman");
				foreach (Mission.WeaponeeringEntry item6 in WeaponeeringList_LeadElementWingman)
				{
					Mission.WeaponeeringEntry theEntry8 = item6;
					if (!Information.IsNothing((object)theEntry8))
					{
						Mission.WeaponeeringEntry.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref theEntry8);
					}
				}
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)WeaponeeringList_SecondElement))
			{
				theWriter.WriteStartElement("WeaponeeringList_SecondElement");
				foreach (Mission.WeaponeeringEntry item7 in WeaponeeringList_SecondElement)
				{
					Mission.WeaponeeringEntry theEntry9 = item7;
					if (!Information.IsNothing((object)theEntry9))
					{
						Mission.WeaponeeringEntry.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref theEntry9);
					}
				}
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)WeaponeeringList_SecondElementWingman))
			{
				theWriter.WriteStartElement("WeaponeeringList_SecondElementWingman");
				foreach (Mission.WeaponeeringEntry item8 in WeaponeeringList_SecondElementWingman)
				{
					Mission.WeaponeeringEntry theEntry10 = item8;
					if (!Information.IsNothing((object)theEntry10))
					{
						Mission.WeaponeeringEntry.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref theEntry10);
					}
				}
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)WeaponeeringList_ThirdElement))
			{
				theWriter.WriteStartElement("WeaponeeringList_ThirdElement");
				foreach (Mission.WeaponeeringEntry item9 in WeaponeeringList_ThirdElement)
				{
					Mission.WeaponeeringEntry theEntry11 = item9;
					if (!Information.IsNothing((object)theEntry11))
					{
						Mission.WeaponeeringEntry.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref theEntry11);
					}
				}
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)WeaponeeringList_ThirdElementWingman))
			{
				theWriter.WriteStartElement("WeaponeeringList_ThirdElementWingman");
				foreach (Mission.WeaponeeringEntry item10 in WeaponeeringList_ThirdElementWingman)
				{
					Mission.WeaponeeringEntry theEntry12 = item10;
					if (!Information.IsNothing((object)theEntry12))
					{
						Mission.WeaponeeringEntry.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref theEntry12);
					}
				}
				theWriter.WriteEndElement();
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100587", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static Waypoint FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen, Waypoint existingObject = null)
	{
		//IL_1e76: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e7d: Expected O, but got Unknown
		//IL_1b6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b72: Expected O, but got Unknown
		//IL_173e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1745: Expected O, but got Unknown
		//IL_0eb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec0: Expected O, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_1f32: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f39: Expected O, but got Unknown
		//IL_1822: Unknown result type (might be due to invalid IL or missing references)
		//IL_1829: Expected O, but got Unknown
		//IL_13a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a7: Expected O, but got Unknown
		//IL_1031: Unknown result type (might be due to invalid IL or missing references)
		//IL_1038: Expected O, but got Unknown
		//IL_0e44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4b: Expected O, but got Unknown
		//IL_0ae4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aeb: Expected O, but got Unknown
		//IL_1d19: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d20: Expected O, but got Unknown
		//IL_1c19: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c20: Expected O, but got Unknown
		//IL_1add: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae4: Expected O, but got Unknown
		//IL_18d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_18dd: Expected O, but got Unknown
		//IL_07e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ee: Expected O, but got Unknown
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Expected O, but got Unknown
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Expected O, but got Unknown
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected O, but got Unknown
		//IL_0fc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc7: Expected O, but got Unknown
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Expected O, but got Unknown
		Waypoint result;
		try
		{
			bool flag;
			Waypoint waypoint;
			int num;
			if (flag = existingObject != null)
			{
				waypoint = existingObject;
				waypoint.Reinitialize();
				num = 0;
			}
			else
			{
				waypoint = new Waypoint();
				num = 0;
			}
			bool flag2 = (byte)num != 0;
			XmlNode theNode2 = theNode.FirstChild;
			bool flag3 = default(bool);
			bool flag5 = default(bool);
			bool flag4 = default(bool);
			while (true)
			{
				if (theNode2 != null)
				{
					switch (theNode2.Name)
					{
					case "TimeFixed":
						waypoint.TimeFixed = (FixedFree)Conversions.ToInteger(theNode2.InnerText);
						break;
					case "RaceTrackHelperPoint":
						foreach (XmlNode childNode in theNode2.ChildNodes)
						{
							XmlNode theNode13 = childNode;
							waypoint.RaceTrackHelperPoint = GeoPoint.FromXML(ref theNode13, ref theDictionary);
						}
						break;
					case "Leg_FuelRemaining":
						waypoint.Leg_FuelRemaining = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "AttackMethod_Time":
						waypoint.Separation_Time = Conversions.ToSingle(theNode2.InnerText);
						break;
					case "Leg_TotalDistance_SecondElement":
						waypoint.Leg_TotalDistance_SecondElement = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "TargeteeringList":
						waypoint.TargeteeringList = new WriteLockedList<Mission.TargeteeringEntry>();
						foreach (XmlNode childNode2 in theNode2.ChildNodes)
						{
							XmlNode theNode20 = childNode2;
							Mission.TargeteeringEntry item12 = Mission.TargeteeringEntry.FromXML(ref theNode20);
							waypoint.TargeteeringList.Add(item12);
						}
						break;
					case "TurnRate":
						waypoint.TurnRate_Navigation = (TurnRateCategory)Conversions.ToByte(theNode2.InnerText);
						break;
					case "EventActionID":
						waypoint.EventActionID = theNode2.InnerText;
						break;
					case "WP_ThirdElement":
						foreach (XmlNode childNode3 in theNode2.ChildNodes)
						{
							XmlNode theNode18 = childNode3;
							waypoint.Waypoint_ThirdElement = FromXML(ref theNode18, ref theDictionary, theScen);
						}
						break;
					case "Time_Local":
					{
						DateTime value4 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
						waypoint.Time_Local = value4;
						break;
					}
					case "Name":
						waypoint.Name = theNode2.InnerText;
						break;
					case "FlightplanPointsList":
						waypoint.FlightplanPointsList = new List<FlightPlanSegment>();
						foreach (XmlNode childNode4 in theNode2.ChildNodes)
						{
							XmlNode val2 = childNode4;
							FlightPlanSegment flightPlanSegment = new FlightPlanSegment();
							foreach (XmlNode childNode5 in val2.ChildNodes)
							{
								XmlNode val3 = childNode5;
								switch (val3.Name)
								{
								case "StartLongitude":
									flightPlanSegment.StartLongitude = XmlConvert.ToDouble(val3.InnerText.Replace(",", "."));
									break;
								case "EndLatitude":
									flightPlanSegment.EndLatitude = XmlConvert.ToDouble(val3.InnerText.Replace(",", "."));
									break;
								case "EndLongitude":
									flightPlanSegment.EndLongitude = XmlConvert.ToDouble(val3.InnerText.Replace(",", "."));
									break;
								case "StartLatitude":
									flightPlanSegment.StartLatitude = XmlConvert.ToDouble(val3.InnerText.Replace(",", "."));
									break;
								}
							}
							waypoint.FlightplanPointsList.Add(flightPlanSegment);
						}
						break;
					case "PreferredWeaponRange":
						waypoint.PreferredWeaponRange = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "DesiredSpeedOverride":
					case "DSO":
						if (Operators.CompareString(theNode2.InnerText, false.ToString(), false) != 0)
						{
							waypoint.nullable_3 = XmlConvert.ToSingle(theNode2.InnerText);
						}
						else
						{
							waypoint.nullable_3 = null;
						}
						break;
					case "ReferenceWeapon":
						waypoint.ReferenceWeapon_ID = Conversions.ToInteger(theNode2.InnerText.ToString());
						break;
					case "TankerMaxDistance_Airborne":
						waypoint.TankerMaxDistance_Airborne = Conversions.ToInteger(theNode2.InnerText);
						break;
					case "Station_Time":
						waypoint.Station_Time = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "SonarActive":
						flag2 = true;
						flag3 = Misc.ParseBool(theNode2.InnerText);
						break;
					case "Leg_TotalDistance_SecondElementWingman":
						waypoint.Leg_TotalDistance_SecondElementWingman = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "WeaponeeringList_LeadElementWingman":
						waypoint.WeaponeeringList_LeadElementWingman = new ConcurrentBag<Mission.WeaponeeringEntry>();
						foreach (XmlNode childNode6 in theNode2.ChildNodes)
						{
							XmlNode theNode9 = childNode6;
							Mission.WeaponeeringEntry item4 = Mission.WeaponeeringEntry.FromXML(ref theNode9, ref theScen, ref theDictionary);
							waypoint.WeaponeeringList_LeadElementWingman.Add(item4);
						}
						break;
					case "TimeOfDay":
						if (Operators.CompareString(theNode2.InnerText, "", false) != 0)
						{
							waypoint.TimeOfDay = (Weather.TTimeOfDayType)Conversions.ToByte(theNode2.InnerText);
						}
						else
						{
							waypoint.TimeOfDay = Weather.TTimeOfDayType.tod_Day;
						}
						break;
					case "SprintDrift_AverageSpeed":
						waypoint.SprintDrift_AverageSpeed = Conversions.ToSingle(theNode2.InnerText);
						break;
					case "Hold_Time":
						waypoint.Hold_Time = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "ID":
					{
						if (!theDictionary.TryGetValue(theNode2.InnerText, out var value5))
						{
							waypoint.ObjectID_Set(theNode2.InnerText);
							break;
						}
						result = (Waypoint)value5;
						goto end_IL_0025;
					}
					case "Doctrine":
						if (flag)
						{
							waypoint.doctrine_0 = Doctrine.FromXML(theScen, ref theNode2, waypoint, waypoint.GetDoctrine(theScen));
						}
						else
						{
							waypoint.doctrine_0 = Doctrine.FromXML(theScen, ref theNode2, waypoint);
						}
						break;
					case "Description":
						waypoint.Description = theNode2.InnerText;
						break;
					case "Leg_FuelRemaining_SecondElementWingman":
						waypoint.Leg_FuelRemaining_SecondElementWingman = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "ECMActive":
						flag2 = true;
						flag5 = Misc.ParseBool(theNode2.InnerText);
						break;
					case "Leg_Time_ErrorMargin":
						waypoint.Leg_Time_ErrorMargin = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "WeaponeeringList_ThirdElement":
						waypoint.WeaponeeringList_ThirdElement = new ConcurrentBag<Mission.WeaponeeringEntry>();
						foreach (XmlNode childNode7 in theNode2.ChildNodes)
						{
							XmlNode theNode19 = childNode7;
							Mission.WeaponeeringEntry item11 = Mission.WeaponeeringEntry.FromXML(ref theNode19, ref theScen, ref theDictionary);
							waypoint.WeaponeeringList_ThirdElement.Add(item11);
						}
						break;
					case "PreferredWeaponName":
						waypoint.PreferredWeaponName = theNode2.InnerText;
						break;
					case "Leg_TotalDistance_LeadElementWingman":
						waypoint.Leg_TotalDistance_LeadElementWingman = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "Leg_TotalTime":
						waypoint.Leg_TotalTime = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "Leg_FuelRemaining_SecondElement":
						waypoint.Leg_FuelRemaining_SecondElement = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "DepthPreset":
						waypoint.DepthPreset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(theNode2.InnerText);
						break;
					case "RadarActive":
						flag2 = true;
						flag4 = Misc.ParseBool(theNode2.InnerText);
						break;
					case "Altitude":
					case "Alt":
						waypoint.Altitude = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "DesiredAltitude":
						if (Operators.CompareString(theNode2.InnerText, false.ToString(), false) != 0)
						{
							waypoint.DesiredAltitude = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						}
						else
						{
							waypoint.DesiredAltitude = null;
						}
						break;
					case "SpeedAdjustmentToT":
						waypoint.SpeedAdjustmentToT = (SpeedToT)Conversions.ToInteger(theNode2.InnerText);
						break;
					case "Time_Zulu":
					{
						DateTime value3 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
						waypoint.Time_Zulu = value3;
						break;
					}
					case "TargeteeringList_SecondElementWingman":
						waypoint.TargeteeringList_SecondElementWingman = new WriteLockedList<Mission.TargeteeringEntry>();
						foreach (XmlNode childNode8 in theNode2.ChildNodes)
						{
							XmlNode theNode17 = childNode8;
							Mission.TargeteeringEntry item10 = Mission.TargeteeringEntry.FromXML(ref theNode17);
							waypoint.TargeteeringList_SecondElementWingman.Add(item10);
						}
						break;
					case "TargeteeringList_LeadElementWingman":
						waypoint.TargeteeringList_LeadElementWingman = new WriteLockedList<Mission.TargeteeringEntry>();
						foreach (XmlNode childNode9 in theNode2.ChildNodes)
						{
							XmlNode theNode16 = childNode9;
							Mission.TargeteeringEntry item9 = Mission.TargeteeringEntry.FromXML(ref theNode16);
							waypoint.TargeteeringList_LeadElementWingman.Add(item9);
						}
						break;
					case "SpacingManeuver_Time":
						waypoint.SpacingManeuver_Time = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "TankerMissionList":
						if (flag)
						{
							waypoint.TankerMissions_IDs.Clear();
						}
						foreach (XmlNode childNode10 in theNode2.ChildNodes)
						{
							XmlNode val = childNode10;
							waypoint.TankerMissions_IDs.Add(val.InnerText);
						}
						break;
					case "TargeteeringList_ThirdElementWingman":
						waypoint.TargeteeringList_ThirdElementWingman = new WriteLockedList<Mission.TargeteeringEntry>();
						foreach (XmlNode childNode11 in theNode2.ChildNodes)
						{
							XmlNode theNode15 = childNode11;
							Mission.TargeteeringEntry item8 = Mission.TargeteeringEntry.FromXML(ref theNode15);
							waypoint.TargeteeringList_ThirdElementWingman.Add(item8);
						}
						break;
					case "TerrainFollowing":
						waypoint.TerrainFollowing = Misc.ParseBool(theNode2.InnerText);
						break;
					case "Leg_FuelRequired":
						waypoint.Leg_FuelRequired = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "Leg_TotalDistance":
						waypoint.Leg_TotalDistance = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "Time_Zulu_Weapon":
					{
						DateTime value2 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
						waypoint.Time_Zulu_Weapon = value2;
						break;
					}
					case "Leg_FuelRemaining_LeadElementWingman":
						waypoint.Leg_FuelRemaining_LeadElementWingman = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "Lon":
						waypoint.Longitude = XmlConvert.ToDouble(theNode2.InnerText.Replace(",", "."));
						break;
					case "AltitudePreset":
						waypoint.AltitudePreset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(theNode2.InnerText);
						break;
					case "SpeedFixed":
						waypoint.SpeedFixed = (FixedFree)Conversions.ToInteger(theNode2.InnerText);
						break;
					case "DesiredAltitude_TerrainFollowing":
						if (Operators.CompareString(theNode2.InnerText, false.ToString(), false) != 0)
						{
							waypoint.DesiredAltitude_TerrainFollowing = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						}
						else
						{
							waypoint.DesiredAltitude_TerrainFollowing = null;
						}
						break;
					case "Time_Local_Weapon":
					{
						DateTime value = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
						waypoint.Time_Local_Weapon = value;
						break;
					}
					case "TargeteeringList_SecondElement":
						waypoint.TargeteeringList_SecondElement = new WriteLockedList<Mission.TargeteeringEntry>();
						foreach (XmlNode childNode12 in theNode2.ChildNodes)
						{
							XmlNode theNode14 = childNode12;
							Mission.TargeteeringEntry item7 = Mission.TargeteeringEntry.FromXML(ref theNode14);
							waypoint.TargeteeringList_SecondElement.Add(item7);
						}
						break;
					case "DesiredSpeed":
						if (Operators.CompareString(theNode2.InnerText, false.ToString(), false) != 0)
						{
							waypoint.DesiredSpeed = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						}
						else
						{
							waypoint.DesiredSpeed = null;
						}
						break;
					case "Lat":
						waypoint.Latitude = XmlConvert.ToDouble(theNode2.InnerText.Replace(",", "."));
						break;
					case "Leg_FuelRemaining_ThirdElement":
						waypoint.Leg_FuelRemaining_ThirdElement = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "Category":
						waypoint.Category = (WaypointCategory)Conversions.ToInteger(theNode2.InnerText);
						break;
					case "PreferredWeaponID":
						waypoint.PreferredWeaponID = Conversions.ToInteger(theNode2.InnerText);
						break;
					case "DAO":
					case "DesiredAltitudeOverride":
						waypoint.bool_1 = Misc.ParseBool(theNode2.InnerText);
						break;
					case "TankerFollowsReceivers_NumberOfWaypoints":
						waypoint.TankerFollowsReceivers_NumberOfWaypoints = Conversions.ToInteger(theNode2.InnerText);
						break;
					case "AvoidCavitation":
						waypoint.AvoidCavitation = Misc.ParseBool(theNode2.InnerText);
						break;
					case "PreferredWeaponSpeed":
						waypoint.PreferredWeaponSpeed = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "Leg_Time_Weapon":
						waypoint.Leg_Time_Weapon = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "Leg_FuelRemaining_ThirdElementWingman":
						waypoint.Leg_FuelRemaining_ThirdElementWingman = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "TargeteeringMethod":
						waypoint.TargeteeringMethod = (Mission._TargeteeringMethod)Conversions.ToByte(theNode2.InnerText);
						break;
					case "WeaponeeringList_ThirdElementWingman":
						waypoint.WeaponeeringList_ThirdElementWingman = new ConcurrentBag<Mission.WeaponeeringEntry>();
						foreach (XmlNode childNode13 in theNode2.ChildNodes)
						{
							XmlNode theNode12 = childNode13;
							Mission.WeaponeeringEntry item6 = Mission.WeaponeeringEntry.FromXML(ref theNode12, ref theScen, ref theDictionary);
							waypoint.WeaponeeringList_ThirdElementWingman.Add(item6);
						}
						break;
					case "SprintDrift":
						waypoint.SprintDrift = Misc.ParseBool(theNode2.InnerText);
						break;
					case "WP_LeadElementWingman":
						foreach (XmlNode childNode14 in theNode2.ChildNodes)
						{
							XmlNode theNode11 = childNode14;
							waypoint.Waypoint_LeadElementWingman = FromXML(ref theNode11, ref theDictionary, theScen);
						}
						break;
					case "IsManualEditable":
					case "IME":
						waypoint.IsManualEditable = true;
						break;
					case "WeaponeeringList_SecondElementWingman":
						waypoint.WeaponeeringList_SecondElementWingman = new ConcurrentBag<Mission.WeaponeeringEntry>();
						foreach (XmlNode childNode15 in theNode2.ChildNodes)
						{
							XmlNode theNode10 = childNode15;
							Mission.WeaponeeringEntry item5 = Mission.WeaponeeringEntry.FromXML(ref theNode10, ref theScen, ref theDictionary);
							waypoint.WeaponeeringList_SecondElementWingman.Add(item5);
						}
						break;
					case "Leg_Time_Turn":
						waypoint.Leg_Time_Turn = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "Type":
						if (!Versioned.IsNumeric((object)theNode2.InnerText))
						{
							waypoint.Type = (WaypointType)Enum.Parse(typeof(WaypointType), theNode2.InnerText, ignoreCase: true);
						}
						else
						{
							waypoint.Type = (WaypointType)Conversions.ToInteger(theNode2.InnerText);
						}
						if (waypoint.Type == WaypointType.Split)
						{
							waypoint.Type = WaypointType.StrikeIngress;
						}
						else if (waypoint.Type == WaypointType.Formate)
						{
							waypoint.Type = WaypointType.StrikeEgress;
						}
						break;
					case "Leg_TotalDistance_ThirdElementWingman":
						waypoint.Leg_TotalDistance_ThirdElementWingman = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "TankerUsage":
						waypoint.TankerUsage = (Mission.TankerMethod)Conversions.ToByte(theNode2.InnerText);
						break;
					case "FlightFormation":
						waypoint.FlightFormation = (Formation)Conversions.ToInteger(theNode2.InnerText);
						break;
					case "WP_SecondElementWingman":
						foreach (XmlNode childNode16 in theNode2.ChildNodes)
						{
							XmlNode theNode8 = childNode16;
							waypoint.Waypoint_SecondElementWingman = FromXML(ref theNode8, ref theDictionary, theScen);
						}
						break;
					case "TankerFollowsReceivers":
						waypoint.TankerFollowsReceivers = Misc.ParseBool(theNode2.InnerText);
						break;
					case "WP_SecondElement":
						foreach (XmlNode childNode17 in theNode2.ChildNodes)
						{
							XmlNode theNode7 = childNode17;
							waypoint.Waypoint_SecondElement = FromXML(ref theNode7, ref theDictionary, theScen);
						}
						break;
					case "WeaponeeringList_SecondElement":
						waypoint.WeaponeeringList_SecondElement = new ConcurrentBag<Mission.WeaponeeringEntry>();
						foreach (XmlNode childNode18 in theNode2.ChildNodes)
						{
							XmlNode theNode6 = childNode18;
							Mission.WeaponeeringEntry item3 = Mission.WeaponeeringEntry.FromXML(ref theNode6, ref theScen, ref theDictionary);
							waypoint.WeaponeeringList_SecondElement.Add(item3);
						}
						break;
					case "PreferredWeaponAltitude":
						waypoint.PreferredWeaponAltitude = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "ThrottlePreset":
						waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)Conversions.ToByte(theNode2.InnerText);
						break;
					case "WeaponeeringList":
						waypoint.WeaponeeringList = new ConcurrentBag<Mission.WeaponeeringEntry>();
						foreach (XmlNode childNode19 in theNode2.ChildNodes)
						{
							XmlNode theNode5 = childNode19;
							Mission.WeaponeeringEntry item2 = Mission.WeaponeeringEntry.FromXML(ref theNode5, ref theScen, ref theDictionary);
							waypoint.WeaponeeringList.Add(item2);
						}
						break;
					case "Leg_TotalDistance_ThirdElement":
						waypoint.Leg_TotalDistance_ThirdElement = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "Leg_Distance":
						waypoint.Leg_Distance_Straight = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "TFT":
						waypoint.TerrainFollowingType = (ActiveUnit.TerrainFollowMode)Conversions.ToInteger(theNode2.InnerText);
						break;
					case "MaxReceiversInQueuePerTanker_Airborne":
						waypoint.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(theNode2.InnerText);
						break;
					case "WP_ThirdElementWingman":
						foreach (XmlNode childNode20 in theNode2.ChildNodes)
						{
							XmlNode theNode4 = childNode20;
							waypoint.Waypoint_ThirdElementWingman = FromXML(ref theNode4, ref theDictionary, theScen);
						}
						break;
					case "AttackMethod":
						waypoint.AttackMethod = (Mission._AttackMethod)Conversions.ToInteger(theNode2.InnerText);
						break;
					case "TargeteeringList_ThirdElement":
						waypoint.TargeteeringList_ThirdElement = new WriteLockedList<Mission.TargeteeringEntry>();
						foreach (XmlNode childNode21 in theNode2.ChildNodes)
						{
							XmlNode theNode3 = childNode21;
							Mission.TargeteeringEntry item = Mission.TargeteeringEntry.FromXML(ref theNode3);
							waypoint.TargeteeringList_ThirdElement.Add(item);
						}
						break;
					case "Creator":
						waypoint.Creator = (WaypointCreator)Conversions.ToByte(theNode2.InnerText);
						break;
					case "Leg_Time_Straight":
						waypoint.Leg_Time_Straight = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					}
					theNode2 = theNode2.NextSibling;
					continue;
				}
				if (waypoint.TerrainFollowing && Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
				{
					waypoint.DesiredAltitude_TerrainFollowing = 60.96f;
				}
				if (flag2 && waypoint.HasDoctrine)
				{
					Doctrine doctrine = waypoint.GetDoctrine(theScen);
					if (!Information.IsNothing((object)doctrine))
					{
						if (flag4)
						{
							doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Active, theScen);
						}
						else
						{
							doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Passive, theScen);
						}
						if (!flag3)
						{
							doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Passive, theScen);
						}
						else
						{
							doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Active, theScen);
						}
						if (!flag5)
						{
							doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Passive, theScen);
						}
						else
						{
							doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Active, theScen);
						}
					}
				}
				if ((waypoint.Latitude != 0.0) & (waypoint.Longitude != 0.0))
				{
					theDictionary.TryAdd(waypoint.ObjectID, waypoint);
				}
				result = waypoint;
				break;
				continue;
				end_IL_0025:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100588", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Waypoint();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Waypoint()
	{
		unitThrottlePreset_0 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
		aircraftAltitudePreset_0 = ActiveUnit_AI.AircraftAltitudePreset.None;
		submarineDepthPreset_0 = ActiveUnit_AI.SubmarineDepthPreset.None;
		TerrainFollowingType = ActiveUnit.TerrainFollowMode.IgnoreLandCover;
		EventActionID = null;
		OvershootWaypoint = true;
		Hold_Time = 0f;
		Station_Time = 0f;
		SpacingManeuver_Time = 0f;
		Separation_Time = 0f;
		AttackMethod = Mission._AttackMethod.None;
		TankerMissions_IDs = new List<string>();
		TankerMissions = new List<Mission>();
		MaxReceiversInQueuePerTanker_Airborne = 0;
		TankerMaxDistance_Airborne = int.MaxValue;
		TankerFollowsReceivers = true;
		TankerFollowsReceivers_NumberOfWaypoints = 0;
		IsWaypoint = true;
	}

	public Waypoint(double theLongitude, double theLatitude, float theAltitude, WaypointType theType, WaypointCreator theCreator, WaypointCategory theCategory, bool _Overshoot = true)
	{
		unitThrottlePreset_0 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
		aircraftAltitudePreset_0 = ActiveUnit_AI.AircraftAltitudePreset.None;
		submarineDepthPreset_0 = ActiveUnit_AI.SubmarineDepthPreset.None;
		TerrainFollowingType = ActiveUnit.TerrainFollowMode.IgnoreLandCover;
		EventActionID = null;
		OvershootWaypoint = true;
		Hold_Time = 0f;
		Station_Time = 0f;
		SpacingManeuver_Time = 0f;
		Separation_Time = 0f;
		AttackMethod = Mission._AttackMethod.None;
		TankerMissions_IDs = new List<string>();
		TankerMissions = new List<Mission>();
		MaxReceiversInQueuePerTanker_Airborne = 0;
		TankerMaxDistance_Airborne = int.MaxValue;
		TankerFollowsReceivers = true;
		TankerFollowsReceivers_NumberOfWaypoints = 0;
		IsWaypoint = true;
		base.Longitude = theLongitude;
		base.Latitude = theLatitude;
		base.Altitude = theAltitude;
		Type = theType;
		Creator = theCreator;
		Category = theCategory;
		OvershootWaypoint = _Overshoot;
	}

	public static Waypoint CopyWaypoint(ref Scenario theScen, ref Waypoint theOriginalWaypoint, bool CopyWingmanWaypoints, bool CopyFlightplanPointsList, ref Doctrine FlightLeadDoctrine)
	{
		Waypoint waypoint = new Waypoint();
		waypoint.Type = theOriginalWaypoint.Type;
		waypoint.Category = theOriginalWaypoint.Category;
		waypoint.Description = theOriginalWaypoint.Description;
		waypoint.Name = theOriginalWaypoint.Name;
		waypoint.doctrine_0 = theOriginalWaypoint.GetDoctrine(theScen);
		waypoint.Longitude = theOriginalWaypoint.Longitude;
		waypoint.Latitude = theOriginalWaypoint.Latitude;
		waypoint.Altitude = theOriginalWaypoint.Altitude;
		waypoint.unitThrottlePreset_0 = theOriginalWaypoint.unitThrottlePreset_0;
		waypoint.aircraftAltitudePreset_0 = theOriginalWaypoint.aircraftAltitudePreset_0;
		waypoint.submarineDepthPreset_0 = theOriginalWaypoint.submarineDepthPreset_0;
		waypoint.DesiredSpeed = theOriginalWaypoint.DesiredSpeed;
		waypoint.DesiredAltitude = theOriginalWaypoint.DesiredAltitude;
		waypoint.nullable_3 = theOriginalWaypoint.nullable_3;
		waypoint.bool_1 = theOriginalWaypoint.bool_1;
		waypoint.ActualSpeed = theOriginalWaypoint.ActualSpeed;
		waypoint.TerrainFollowing = theOriginalWaypoint.TerrainFollowing;
		waypoint.DesiredAltitude_TerrainFollowing = theOriginalWaypoint.DesiredAltitude_TerrainFollowing;
		waypoint.SprintDrift = theOriginalWaypoint.SprintDrift;
		waypoint.SprintDrift_AverageSpeed = theOriginalWaypoint.SprintDrift_AverageSpeed;
		waypoint.AvoidCavitation = theOriginalWaypoint.AvoidCavitation;
		waypoint.Time_Zulu = theOriginalWaypoint.Time_Zulu;
		waypoint.Time_Zulu_Weapon = theOriginalWaypoint.Time_Zulu_Weapon;
		waypoint.Time_Local = theOriginalWaypoint.Time_Local;
		waypoint.Time_Local_Weapon = theOriginalWaypoint.Time_Local_Weapon;
		waypoint.TimeOfDay = theOriginalWaypoint.TimeOfDay;
		waypoint.TimeFixed = theOriginalWaypoint.TimeFixed;
		waypoint.SpeedFixed = theOriginalWaypoint.SpeedFixed;
		waypoint.FlightFormation = theOriginalWaypoint.FlightFormation;
		waypoint.SpeedAdjustmentToT = theOriginalWaypoint.SpeedAdjustmentToT;
		waypoint.TankerUsage = theOriginalWaypoint.TankerUsage;
		waypoint.TankerMissions_IDs = theOriginalWaypoint.TankerMissions_IDs;
		waypoint.TankerMissions = theOriginalWaypoint.TankerMissions;
		waypoint.MaxReceiversInQueuePerTanker_Airborne = theOriginalWaypoint.MaxReceiversInQueuePerTanker_Airborne;
		waypoint.TankerMaxDistance_Airborne = theOriginalWaypoint.TankerMaxDistance_Airborne;
		waypoint.TankerFollowsReceivers = theOriginalWaypoint.TankerFollowsReceivers;
		waypoint.TankerFollowsReceivers_NumberOfWaypoints = theOriginalWaypoint.TankerFollowsReceivers_NumberOfWaypoints;
		waypoint.Leg_FuelRequired = theOriginalWaypoint.Leg_FuelRequired;
		waypoint.Leg_FuelRemaining = theOriginalWaypoint.Leg_FuelRemaining;
		waypoint.Leg_Time_Straight = theOriginalWaypoint.Leg_Time_Straight;
		waypoint.Leg_Time_Turn = theOriginalWaypoint.Leg_Time_Turn;
		waypoint.Leg_Time_Weapon = theOriginalWaypoint.Leg_Time_Weapon;
		waypoint.Leg_TotalTime = theOriginalWaypoint.Leg_TotalTime;
		waypoint.Leg_Time_ErrorMargin = theOriginalWaypoint.Leg_Time_ErrorMargin;
		waypoint.Leg_Distance_Straight = theOriginalWaypoint.Leg_Distance_Straight;
		waypoint.Leg_TotalDistance = theOriginalWaypoint.Leg_TotalDistance;
		waypoint.Leg_Distance_Turn = theOriginalWaypoint.Leg_Distance_Turn;
		waypoint.Leg_Speed_Straight = theOriginalWaypoint.Leg_Speed_Straight;
		waypoint.Leg_Speed_Turn = theOriginalWaypoint.Leg_Speed_Turn;
		waypoint.Leg_PreviousWaypointIsFixedSpeed = theOriginalWaypoint.Leg_PreviousWaypointIsFixedSpeed;
		waypoint.Leg_TwoWaypointsAgoIsFixedSpeed = theOriginalWaypoint.Leg_TwoWaypointsAgoIsFixedSpeed;
		waypoint.TurnRate_Navigation = theOriginalWaypoint.TurnRate_Navigation;
		waypoint.Hold_Time = theOriginalWaypoint.Hold_Time;
		waypoint.Station_Time = theOriginalWaypoint.Station_Time;
		waypoint.SpacingManeuver_Time = theOriginalWaypoint.SpacingManeuver_Time;
		waypoint.PreferredWeaponID = theOriginalWaypoint.PreferredWeaponID;
		waypoint.PreferredWeaponName = theOriginalWaypoint.PreferredWeaponName;
		waypoint.PreferredWeaponSpeed = theOriginalWaypoint.PreferredWeaponSpeed;
		waypoint.PreferredWeaponAltitude = theOriginalWaypoint.PreferredWeaponAltitude;
		waypoint.PreferredWeaponRange = theOriginalWaypoint.PreferredWeaponRange;
		waypoint.ReferenceWeapon_ID = theOriginalWaypoint.ReferenceWeapon_ID;
		waypoint.AttackMethod = theOriginalWaypoint.AttackMethod;
		waypoint.Separation_Time = theOriginalWaypoint.Separation_Time;
		waypoint.TargeteeringMethod = theOriginalWaypoint.TargeteeringMethod;
		waypoint.TargeteeringList = theOriginalWaypoint.TargeteeringList;
		waypoint.WeaponeeringList = theOriginalWaypoint.WeaponeeringList;
		if (CopyWingmanWaypoints)
		{
			waypoint.Waypoint_LeadElementWingman = theOriginalWaypoint.Waypoint_LeadElementWingman;
			waypoint.Waypoint_SecondElement = theOriginalWaypoint.Waypoint_SecondElement;
			waypoint.Waypoint_SecondElementWingman = theOriginalWaypoint.Waypoint_SecondElementWingman;
			waypoint.Waypoint_ThirdElement = theOriginalWaypoint.Waypoint_ThirdElement;
			waypoint.Waypoint_ThirdElementWingman = theOriginalWaypoint.Waypoint_ThirdElementWingman;
		}
		if (CopyFlightplanPointsList)
		{
			waypoint.FlightplanPointsList = theOriginalWaypoint.FlightplanPointsList;
		}
		waypoint.Creator = theOriginalWaypoint.Creator;
		waypoint.IsManualEditable = theOriginalWaypoint.IsManualEditable;
		waypoint.RaceTrackHelperPoint = theOriginalWaypoint.RaceTrackHelperPoint;
		return waypoint;
	}

	public void SplitWaypoint(ref Scenario ParentScen, ref Mission._FlightSize theFlightSize, ref Waypoint thePrevWaypoint, ref Waypoint theNextWaypoint, bool OverwriteExistingWingmanWaypoints)
	{
		try
		{
			if (Information.IsNothing((object)thePrevWaypoint) || Information.IsNothing((object)theNextWaypoint))
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			Mission._FlightSize flightSize = theFlightSize;
			if (!(flightSize == 2))
			{
				if (!(flightSize == 3))
				{
					if (flightSize == 4)
					{
						if (OverwriteExistingWingmanWaypoints || Information.IsNothing((object)Waypoint_LeadElementWingman))
						{
							Waypoint_LeadElementWingman = new Waypoint();
							Waypoint theOriginalWaypoint = this;
							Doctrine FlightLeadDoctrine = GetDoctrine(ParentScen);
							Waypoint_LeadElementWingman = CopyWaypoint(ref ParentScen, ref theOriginalWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
							Waypoint_LeadElementWingman.SpeedFixed = FixedFree.Free;
							Waypoint_LeadElementWingman.TimeFixed = FixedFree.Free;
							flag = true;
						}
						if (OverwriteExistingWingmanWaypoints || Information.IsNothing((object)Waypoint_SecondElement))
						{
							Waypoint_SecondElement = new Waypoint();
							Waypoint theOriginalWaypoint = this;
							Doctrine FlightLeadDoctrine = GetDoctrine(ParentScen);
							Waypoint_SecondElement = CopyWaypoint(ref ParentScen, ref theOriginalWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
							Waypoint_SecondElement.SpeedFixed = FixedFree.Free;
							Waypoint_SecondElement.TimeFixed = FixedFree.Free;
							flag2 = true;
						}
						if (OverwriteExistingWingmanWaypoints || Information.IsNothing((object)Waypoint_SecondElementWingman))
						{
							Waypoint_SecondElementWingman = new Waypoint();
							Waypoint theOriginalWaypoint = this;
							Doctrine FlightLeadDoctrine = GetDoctrine(ParentScen);
							Waypoint_SecondElementWingman = CopyWaypoint(ref ParentScen, ref theOriginalWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
							Waypoint_SecondElementWingman.SpeedFixed = FixedFree.Free;
							Waypoint_SecondElementWingman.TimeFixed = FixedFree.Free;
							flag3 = true;
						}
						Waypoint_ThirdElement = null;
						Waypoint_ThirdElementWingman = null;
					}
					else if (flightSize == 6)
					{
						if (OverwriteExistingWingmanWaypoints || Information.IsNothing((object)Waypoint_LeadElementWingman))
						{
							Waypoint_LeadElementWingman = new Waypoint();
							Waypoint theOriginalWaypoint = this;
							Doctrine FlightLeadDoctrine = GetDoctrine(ParentScen);
							Waypoint_LeadElementWingman = CopyWaypoint(ref ParentScen, ref theOriginalWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
							Waypoint_LeadElementWingman.SpeedFixed = FixedFree.Free;
							Waypoint_LeadElementWingman.TimeFixed = FixedFree.Free;
							flag = true;
						}
						if (OverwriteExistingWingmanWaypoints || Information.IsNothing((object)Waypoint_SecondElement))
						{
							Waypoint_SecondElement = new Waypoint();
							Waypoint theOriginalWaypoint = this;
							Doctrine FlightLeadDoctrine = GetDoctrine(ParentScen);
							Waypoint_SecondElement = CopyWaypoint(ref ParentScen, ref theOriginalWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
							Waypoint_SecondElement.SpeedFixed = FixedFree.Free;
							Waypoint_SecondElement.TimeFixed = FixedFree.Free;
							flag2 = true;
						}
						if (OverwriteExistingWingmanWaypoints || Information.IsNothing((object)Waypoint_SecondElementWingman))
						{
							Waypoint_SecondElementWingman = new Waypoint();
							Waypoint theOriginalWaypoint = this;
							Doctrine FlightLeadDoctrine = GetDoctrine(ParentScen);
							Waypoint_SecondElementWingman = CopyWaypoint(ref ParentScen, ref theOriginalWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
							Waypoint_SecondElementWingman.SpeedFixed = FixedFree.Free;
							Waypoint_SecondElementWingman.TimeFixed = FixedFree.Free;
							flag3 = true;
						}
						if (OverwriteExistingWingmanWaypoints || Information.IsNothing((object)Waypoint_ThirdElement))
						{
							Waypoint_ThirdElement = new Waypoint();
							Waypoint theOriginalWaypoint = this;
							Doctrine FlightLeadDoctrine = GetDoctrine(ParentScen);
							Waypoint_ThirdElement = CopyWaypoint(ref ParentScen, ref theOriginalWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
							Waypoint_ThirdElement.SpeedFixed = FixedFree.Free;
							Waypoint_ThirdElement.TimeFixed = FixedFree.Free;
							flag4 = true;
						}
						if (OverwriteExistingWingmanWaypoints || Information.IsNothing((object)Waypoint_ThirdElementWingman))
						{
							Waypoint_ThirdElementWingman = new Waypoint();
							Waypoint theOriginalWaypoint = this;
							Doctrine FlightLeadDoctrine = GetDoctrine(ParentScen);
							Waypoint_ThirdElementWingman = CopyWaypoint(ref ParentScen, ref theOriginalWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
							Waypoint_ThirdElementWingman.SpeedFixed = FixedFree.Free;
							Waypoint_ThirdElementWingman.TimeFixed = FixedFree.Free;
							flag5 = true;
						}
					}
				}
				else
				{
					if (OverwriteExistingWingmanWaypoints || Information.IsNothing((object)Waypoint_LeadElementWingman))
					{
						Waypoint_LeadElementWingman = new Waypoint();
						Waypoint theOriginalWaypoint = this;
						Doctrine FlightLeadDoctrine = GetDoctrine(ParentScen);
						Waypoint_LeadElementWingman = CopyWaypoint(ref ParentScen, ref theOriginalWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
						Waypoint_LeadElementWingman.SpeedFixed = FixedFree.Free;
						Waypoint_LeadElementWingman.TimeFixed = FixedFree.Free;
						flag = true;
					}
					if (OverwriteExistingWingmanWaypoints || Information.IsNothing((object)Waypoint_SecondElement))
					{
						Waypoint_SecondElement = new Waypoint();
						Waypoint theOriginalWaypoint = this;
						Doctrine FlightLeadDoctrine = GetDoctrine(ParentScen);
						Waypoint_SecondElement = CopyWaypoint(ref ParentScen, ref theOriginalWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
						Waypoint_SecondElement.SpeedFixed = FixedFree.Free;
						Waypoint_SecondElement.TimeFixed = FixedFree.Free;
						flag2 = true;
					}
					Waypoint_SecondElementWingman = null;
					Waypoint_ThirdElement = null;
					Waypoint_ThirdElementWingman = null;
				}
			}
			else
			{
				if (OverwriteExistingWingmanWaypoints || Information.IsNothing((object)Waypoint_LeadElementWingman))
				{
					Waypoint_LeadElementWingman = new Waypoint();
					Waypoint theOriginalWaypoint = this;
					Doctrine FlightLeadDoctrine = GetDoctrine(ParentScen);
					Waypoint_LeadElementWingman = CopyWaypoint(ref ParentScen, ref theOriginalWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
					Waypoint_LeadElementWingman.SpeedFixed = FixedFree.Free;
					Waypoint_LeadElementWingman.TimeFixed = FixedFree.Free;
					flag = true;
				}
				Waypoint_SecondElement = null;
				Waypoint_SecondElementWingman = null;
				Waypoint_ThirdElement = null;
				Waypoint_ThirdElementWingman = null;
			}
			if (theNextWaypoint.FlightFormation != Formation.Split)
			{
				if (!Information.IsNothing((object)Waypoint_LeadElementWingman) && Information.IsNothing((object)theNextWaypoint.Waypoint_LeadElementWingman))
				{
					theNextWaypoint.Waypoint_LeadElementWingman = new Waypoint();
					Waypoint obj = theNextWaypoint;
					Doctrine FlightLeadDoctrine = GetDoctrine(ParentScen);
					obj.Waypoint_LeadElementWingman = CopyWaypoint(ref ParentScen, ref theNextWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
					theNextWaypoint.Waypoint_LeadElementWingman.SpeedFixed = FixedFree.Free;
				}
				if (!Information.IsNothing((object)Waypoint_SecondElement) && Information.IsNothing((object)theNextWaypoint.Waypoint_SecondElement))
				{
					theNextWaypoint.Waypoint_SecondElement = new Waypoint();
					Waypoint obj2 = theNextWaypoint;
					Doctrine FlightLeadDoctrine = GetDoctrine(ParentScen);
					obj2.Waypoint_SecondElement = CopyWaypoint(ref ParentScen, ref theNextWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
					theNextWaypoint.Waypoint_SecondElement.SpeedFixed = FixedFree.Free;
				}
				if (!Information.IsNothing((object)Waypoint_SecondElementWingman) && Information.IsNothing((object)theNextWaypoint.Waypoint_SecondElementWingman))
				{
					theNextWaypoint.Waypoint_SecondElementWingman = new Waypoint();
					Waypoint obj3 = theNextWaypoint;
					Doctrine FlightLeadDoctrine = GetDoctrine(ParentScen);
					obj3.Waypoint_SecondElementWingman = CopyWaypoint(ref ParentScen, ref theNextWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
					theNextWaypoint.Waypoint_SecondElementWingman.SpeedFixed = FixedFree.Free;
				}
				if (!Information.IsNothing((object)Waypoint_ThirdElement) && Information.IsNothing((object)theNextWaypoint.Waypoint_ThirdElement))
				{
					theNextWaypoint.Waypoint_ThirdElement = new Waypoint();
					Waypoint obj4 = theNextWaypoint;
					Doctrine FlightLeadDoctrine = GetDoctrine(ParentScen);
					obj4.Waypoint_ThirdElement = CopyWaypoint(ref ParentScen, ref theNextWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
					theNextWaypoint.Waypoint_ThirdElement.SpeedFixed = FixedFree.Free;
				}
				if (!Information.IsNothing((object)Waypoint_ThirdElementWingman) && Information.IsNothing((object)theNextWaypoint.Waypoint_ThirdElementWingman))
				{
					theNextWaypoint.Waypoint_ThirdElementWingman = new Waypoint();
					Waypoint obj5 = theNextWaypoint;
					Doctrine FlightLeadDoctrine = GetDoctrine(ParentScen);
					obj5.Waypoint_ThirdElementWingman = CopyWaypoint(ref ParentScen, ref theNextWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
					theNextWaypoint.Waypoint_ThirdElementWingman.SpeedFixed = FixedFree.Free;
				}
			}
			float num = Math2.CalcAzimuth(thePrevWaypoint.Latitude, thePrevWaypoint.Longitude, base.Latitude, base.Longitude);
			if (Type != WaypointType.Target && Type != WaypointType.WeaponTarget)
			{
				if (flag && !Information.IsNothing((object)Waypoint_LeadElementWingman))
				{
					float bearing = Math2.NormalizeBearing(num + 90f);
					float distance_NM = 3f;
					double longitude = base.Longitude;
					double latitude = base.Latitude;
					Waypoint theOriginalWaypoint;
					double out_lon = (theOriginalWaypoint = Waypoint_LeadElementWingman).Longitude;
					Waypoint waypoint_LeadElementWingman;
					double out_lat = (waypoint_LeadElementWingman = Waypoint_LeadElementWingman).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref out_lon, ref out_lat, distance_NM, bearing);
					waypoint_LeadElementWingman.Latitude = out_lat;
					theOriginalWaypoint.Longitude = out_lon;
				}
				if (flag2 && !Information.IsNothing((object)Waypoint_SecondElement))
				{
					float bearing = Math2.NormalizeBearing(num + 90f);
					float distance_NM = 6f;
					double longitude2 = base.Longitude;
					double latitude2 = base.Latitude;
					Waypoint waypoint_LeadElementWingman;
					double out_lat = (waypoint_LeadElementWingman = Waypoint_SecondElement).Longitude;
					Waypoint theOriginalWaypoint;
					double out_lon = (theOriginalWaypoint = Waypoint_SecondElement).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude2, latitude2, ref out_lat, ref out_lon, distance_NM, bearing);
					theOriginalWaypoint.Latitude = out_lon;
					waypoint_LeadElementWingman.Longitude = out_lat;
				}
				if (flag3 && !Information.IsNothing((object)Waypoint_SecondElementWingman))
				{
					float bearing = Math2.NormalizeBearing(num + 90f);
					float distance_NM = 9f;
					double longitude3 = base.Longitude;
					double latitude3 = base.Latitude;
					Waypoint theOriginalWaypoint;
					double out_lon = (theOriginalWaypoint = Waypoint_SecondElementWingman).Longitude;
					Waypoint waypoint_LeadElementWingman;
					double out_lat = (waypoint_LeadElementWingman = Waypoint_SecondElementWingman).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude3, latitude3, ref out_lon, ref out_lat, distance_NM, bearing);
					waypoint_LeadElementWingman.Latitude = out_lat;
					theOriginalWaypoint.Longitude = out_lon;
				}
				if (flag4 && !Information.IsNothing((object)Waypoint_ThirdElement))
				{
					float bearing = Math2.NormalizeBearing(num + 90f);
					float distance_NM = 12f;
					double longitude4 = base.Longitude;
					double latitude4 = base.Latitude;
					Waypoint waypoint_LeadElementWingman;
					double out_lat = (waypoint_LeadElementWingman = Waypoint_ThirdElement).Longitude;
					Waypoint theOriginalWaypoint;
					double out_lon = (theOriginalWaypoint = Waypoint_ThirdElement).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude4, latitude4, ref out_lat, ref out_lon, distance_NM, bearing);
					theOriginalWaypoint.Latitude = out_lon;
					waypoint_LeadElementWingman.Longitude = out_lat;
				}
				if (flag5 && !Information.IsNothing((object)Waypoint_ThirdElementWingman))
				{
					float bearing = Math2.NormalizeBearing(num + 90f);
					float distance_NM = 15f;
					double longitude5 = base.Longitude;
					double latitude5 = base.Latitude;
					Waypoint theOriginalWaypoint;
					double out_lon = (theOriginalWaypoint = Waypoint_ThirdElementWingman).Longitude;
					Waypoint waypoint_LeadElementWingman;
					double out_lat = (waypoint_LeadElementWingman = Waypoint_ThirdElementWingman).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude5, latitude5, ref out_lon, ref out_lat, distance_NM, bearing);
					waypoint_LeadElementWingman.Latitude = out_lat;
					theOriginalWaypoint.Longitude = out_lon;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool HasWingmanWaypoints()
	{
		int result;
		if (!Information.IsNothing((object)Waypoint_LeadElementWingman))
		{
			result = 1;
		}
		else if (!Information.IsNothing((object)Waypoint_SecondElement))
		{
			result = 1;
		}
		else if (Information.IsNothing((object)Waypoint_SecondElementWingman))
		{
			if (!Information.IsNothing((object)Waypoint_ThirdElement))
			{
				result = 1;
			}
			else
			{
				if (Information.IsNothing((object)Waypoint_ThirdElementWingman))
				{
					return false;
				}
				result = 1;
			}
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	internal bool IsSplitWaypoint()
	{
		int result;
		if (!HasWingmanWaypoints())
		{
			result = 0;
		}
		else
		{
			if (FlightFormation == Formation.Split)
			{
				return true;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	internal bool IsFormateWaypoint()
	{
		if (HasWingmanWaypoints() && FlightFormation != Formation.Split)
		{
			return true;
		}
		return false;
	}

	public void FormateWaypoint(ref Waypoint thePrevWaypoint, ref Waypoint theNextWaypoint)
	{
		try
		{
			if (!Information.IsNothing((object)thePrevWaypoint) && !Information.IsNothing((object)theNextWaypoint))
			{
				if (thePrevWaypoint.IsSplitWaypoint())
				{
					if (!Information.IsNothing((object)Waypoint_LeadElementWingman))
					{
						Waypoint_LeadElementWingman.Latitude = base.Latitude;
						Waypoint_LeadElementWingman.Longitude = base.Longitude;
						Waypoint_LeadElementWingman.SpeedFixed = FixedFree.Free;
						Waypoint_LeadElementWingman.DesiredSpeed = DesiredSpeed;
						Waypoint_LeadElementWingman.DesiredSpeedOverride = DesiredSpeedOverride;
						Waypoint_LeadElementWingman.ThrottlePreset = ThrottlePreset;
					}
					if (!Information.IsNothing((object)Waypoint_SecondElement))
					{
						Waypoint_SecondElement.Latitude = base.Latitude;
						Waypoint_SecondElement.Longitude = base.Longitude;
						Waypoint_SecondElement.SpeedFixed = FixedFree.Free;
						Waypoint_SecondElement.DesiredSpeed = DesiredSpeed;
						Waypoint_SecondElement.DesiredSpeedOverride = DesiredSpeedOverride;
						Waypoint_SecondElement.ThrottlePreset = ThrottlePreset;
					}
					if (!Information.IsNothing((object)Waypoint_SecondElementWingman))
					{
						Waypoint_SecondElementWingman.Latitude = base.Latitude;
						Waypoint_SecondElementWingman.Longitude = base.Longitude;
						Waypoint_SecondElementWingman.SpeedFixed = FixedFree.Free;
						Waypoint_SecondElementWingman.DesiredSpeed = DesiredSpeed;
						Waypoint_SecondElementWingman.DesiredSpeedOverride = DesiredSpeedOverride;
						Waypoint_SecondElementWingman.ThrottlePreset = ThrottlePreset;
					}
					if (!Information.IsNothing((object)Waypoint_ThirdElement))
					{
						Waypoint_ThirdElement.Latitude = base.Latitude;
						Waypoint_ThirdElement.Longitude = base.Longitude;
						Waypoint_ThirdElement.SpeedFixed = FixedFree.Free;
						Waypoint_ThirdElement.DesiredSpeed = DesiredSpeed;
						Waypoint_ThirdElement.DesiredSpeedOverride = DesiredSpeedOverride;
						Waypoint_ThirdElement.ThrottlePreset = ThrottlePreset;
					}
					if (!Information.IsNothing((object)Waypoint_ThirdElementWingman))
					{
						Waypoint_ThirdElementWingman.Latitude = base.Latitude;
						Waypoint_ThirdElementWingman.Longitude = base.Longitude;
						Waypoint_ThirdElementWingman.SpeedFixed = FixedFree.Free;
						Waypoint_ThirdElementWingman.DesiredSpeed = DesiredSpeed;
						Waypoint_ThirdElementWingman.DesiredSpeedOverride = DesiredSpeedOverride;
						Waypoint_ThirdElementWingman.ThrottlePreset = ThrottlePreset;
					}
				}
				else
				{
					Waypoint_LeadElementWingman = null;
					Waypoint_SecondElement = null;
					Waypoint_SecondElementWingman = null;
					Waypoint_ThirdElement = null;
					Waypoint_ThirdElementWingman = null;
				}
				if (theNextWaypoint.IsFormateWaypoint())
				{
					theNextWaypoint.Waypoint_LeadElementWingman = null;
					theNextWaypoint.Waypoint_SecondElement = null;
					theNextWaypoint.Waypoint_SecondElementWingman = null;
					theNextWaypoint.Waypoint_ThirdElement = null;
					theNextWaypoint.Waypoint_ThirdElementWingman = null;
				}
			}
			else
			{
				Waypoint_LeadElementWingman = null;
				Waypoint_SecondElement = null;
				Waypoint_SecondElementWingman = null;
				Waypoint_ThirdElement = null;
				Waypoint_ThirdElementWingman = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void FollowAltitudePreset()
	{
		if (Information.IsNothing((object)this) || !DesiredAltitudeOverride)
		{
			return;
		}
		switch (AltitudePreset)
		{
		case ActiveUnit_AI.AircraftAltitudePreset.None:
			DesiredAltitude = null;
			DesiredAltitude_TerrainFollowing = null;
			break;
		case ActiveUnit_AI.AircraftAltitudePreset.MinAltitude:
			DesiredAltitude = 0f;
			DesiredAltitude_TerrainFollowing = 0f;
			break;
		case ActiveUnit_AI.AircraftAltitudePreset.Low1000:
			if (!TerrainFollowing)
			{
				DesiredAltitude = 304.8f;
				DesiredAltitude_TerrainFollowing = null;
			}
			else
			{
				DesiredAltitude = null;
				DesiredAltitude_TerrainFollowing = 304.8f;
			}
			break;
		case ActiveUnit_AI.AircraftAltitudePreset.Low2000:
			if (TerrainFollowing)
			{
				DesiredAltitude = null;
				DesiredAltitude_TerrainFollowing = 609.6f;
			}
			else
			{
				DesiredAltitude = 609.6f;
				DesiredAltitude_TerrainFollowing = null;
			}
			break;
		case ActiveUnit_AI.AircraftAltitudePreset.const_4:
			if (!TerrainFollowing)
			{
				DesiredAltitude = 3657.6f;
				DesiredAltitude_TerrainFollowing = null;
			}
			else
			{
				DesiredAltitude = null;
				DesiredAltitude_TerrainFollowing = 3657.6f;
			}
			break;
		case ActiveUnit_AI.AircraftAltitudePreset.const_5:
			if (TerrainFollowing)
			{
				DesiredAltitude = null;
				DesiredAltitude_TerrainFollowing = 7620f;
			}
			else
			{
				DesiredAltitude = 7620f;
				DesiredAltitude_TerrainFollowing = null;
			}
			break;
		case ActiveUnit_AI.AircraftAltitudePreset.const_6:
			if (TerrainFollowing)
			{
				DesiredAltitude = null;
				DesiredAltitude_TerrainFollowing = 10972.8f;
			}
			else
			{
				DesiredAltitude = 10972.8f;
				DesiredAltitude_TerrainFollowing = null;
			}
			break;
		case ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude:
			DesiredAltitude = null;
			DesiredAltitude_TerrainFollowing = null;
			break;
		}
	}

	public void FollowDepthPreset(Scenario TheScen)
	{
		if (!Information.IsNothing((object)this) && DesiredAltitudeOverride)
		{
			switch (DepthPreset)
			{
			case ActiveUnit_AI.SubmarineDepthPreset.None:
				DesiredAltitude = null;
				break;
			case ActiveUnit_AI.SubmarineDepthPreset.Periscope:
				DesiredAltitude = -20f;
				break;
			case ActiveUnit_AI.SubmarineDepthPreset.Shallow:
				DesiredAltitude = -40f;
				break;
			case ActiveUnit_AI.SubmarineDepthPreset.OverLayer:
				DesiredAltitude = OverLayerDepth(this, TheScen);
				break;
			case ActiveUnit_AI.SubmarineDepthPreset.UnderLayer:
				DesiredAltitude = UnderLayerDepth(this, TheScen);
				break;
			case ActiveUnit_AI.SubmarineDepthPreset.MaxDepth:
				DesiredAltitude = 0f;
				break;
			case ActiveUnit_AI.SubmarineDepthPreset.Surface:
				DesiredAltitude = 0f;
				break;
			}
		}
	}

	public static float OverLayerDepth(Waypoint myWaypoint, Scenario TheScen)
	{
		return SonarModel.GetThermalLayerAtThisLocation(myWaypoint.Latitude, myWaypoint.Longitude, Terrain.GetElevation(myWaypoint.Latitude, myWaypoint.Longitude, RequestIsFromGUI: false, TheScen), TheScen).Ceiling + 10;
	}

	public static float UnderLayerDepth(Waypoint myWaypoint, Scenario TheScen)
	{
		return SonarModel.GetThermalLayerAtThisLocation(myWaypoint.Latitude, myWaypoint.Longitude, Terrain.GetElevation(myWaypoint.Latitude, myWaypoint.Longitude, RequestIsFromGUI: false, TheScen), TheScen).Floor - 10;
	}

	public static void ComboBoxDataSource_WaypointType(ref DataTable theComboBoxDataSource_WaypointType)
	{
		if (!theComboBoxDataSource_WaypointType.Columns.Contains("ID"))
		{
			theComboBoxDataSource_WaypointType.Columns.Add("ID", typeof(int));
		}
		if (!theComboBoxDataSource_WaypointType.Columns.Contains("Description"))
		{
			theComboBoxDataSource_WaypointType.Columns.Add("Description", typeof(string));
		}
		theComboBoxDataSource_WaypointType.Rows.Add(0, Waypoint.get_WaypointTypeString(WaypointType.TakeOff));
		theComboBoxDataSource_WaypointType.Rows.Add(1, Waypoint.get_WaypointTypeString(WaypointType.Assemble));
		theComboBoxDataSource_WaypointType.Rows.Add(2, Waypoint.get_WaypointTypeString(WaypointType.TurningPoint));
		theComboBoxDataSource_WaypointType.Rows.Add(3, Waypoint.get_WaypointTypeString(WaypointType.Refuel));
		theComboBoxDataSource_WaypointType.Rows.Add(4, Waypoint.get_WaypointTypeString(WaypointType.StrikeIngress));
		theComboBoxDataSource_WaypointType.Rows.Add(5, Waypoint.get_WaypointTypeString(WaypointType.InitialPoint));
		theComboBoxDataSource_WaypointType.Rows.Add(6, Waypoint.get_WaypointTypeString(WaypointType.WeaponLaunch));
		theComboBoxDataSource_WaypointType.Rows.Add(7, Waypoint.get_WaypointTypeString(WaypointType.Target));
		theComboBoxDataSource_WaypointType.Rows.Add(8, Waypoint.get_WaypointTypeString(WaypointType.WeaponTarget));
		theComboBoxDataSource_WaypointType.Rows.Add(9, Waypoint.get_WaypointTypeString(WaypointType.StrikeEgress));
		theComboBoxDataSource_WaypointType.Rows.Add(10, Waypoint.get_WaypointTypeString(WaypointType.LandingMarshal));
		theComboBoxDataSource_WaypointType.Rows.Add(11, Waypoint.get_WaypointTypeString(WaypointType.Land));
		theComboBoxDataSource_WaypointType.Rows.Add(12, Waypoint.get_WaypointTypeString(WaypointType.StationStart_Racetrack));
		theComboBoxDataSource_WaypointType.Rows.Add(13, Waypoint.get_WaypointTypeString(WaypointType.StationStart_RaceTrackRandom));
		theComboBoxDataSource_WaypointType.Rows.Add(14, Waypoint.get_WaypointTypeString(WaypointType.StationStart_FigureEight));
		theComboBoxDataSource_WaypointType.Rows.Add(15, Waypoint.get_WaypointTypeString(WaypointType.StationStart_Area));
		theComboBoxDataSource_WaypointType.Rows.Add(16, Waypoint.get_WaypointTypeString(WaypointType.StationEnd));
		theComboBoxDataSource_WaypointType.Rows.Add(17, Waypoint.get_WaypointTypeString(WaypointType.HoldStart));
		theComboBoxDataSource_WaypointType.Rows.Add(18, Waypoint.get_WaypointTypeString(WaypointType.HoldEnd));
	}

	public static int? WaypointTypeSelection_To_WaypointType(ref object Type)
	{
		int? result;
		try
		{
			switch (Conversions.ToInteger(Type))
			{
			default:
				result = null;
				break;
			case 0:
				return 15;
			case 1:
				return 5;
			case 2:
				return 6;
			case 3:
				return 14;
			case 4:
				return 12;
			case 5:
				return 7;
			case 6:
				return 17;
			case 7:
				return 10;
			case 8:
				return 19;
			case 9:
				return 13;
			case 10:
				return 11;
			case 11:
				return 18;
			case 12:
				return 20;
			case 13:
				return 23;
			case 14:
				return 21;
			case 15:
				return 22;
			case 16:
				return 24;
			case 17:
				return 26;
			case 18:
				return 27;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101300", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 6;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static int WaypointType_To_WaypointTypeSelection(object Type)
	{
		int result;
		try
		{
			int num;
			switch (Conversions.ToInteger(Type))
			{
			default:
				num = 0;
				goto IL_00d1;
			case 5:
				result = 1;
				break;
			case 6:
				result = 2;
				break;
			case 7:
				result = 5;
				break;
			case 10:
				result = 7;
				break;
			case 11:
				result = 10;
				break;
			case 12:
				result = 4;
				break;
			case 13:
				result = 9;
				break;
			case 14:
				result = 3;
				break;
			case 15:
				result = 0;
				break;
			case 17:
				result = 6;
				break;
			case 18:
				result = 11;
				break;
			case 19:
				result = 8;
				break;
			case 20:
				result = 12;
				break;
			case 21:
				result = 14;
				break;
			case 22:
				result = 15;
				break;
			case 23:
				result = 13;
				break;
			case 24:
				result = 16;
				break;
			case 8:
			case 9:
			case 16:
			case 25:
				num = 0;
				goto IL_00d1;
			case 26:
				result = 17;
				break;
			case 27:
				{
					result = 18;
					break;
				}
				IL_00d1:
				result = num;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101303", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (!Debugger.IsAttached)
			{
				num2 = 2;
			}
			else
			{
				Debugger.Break();
				num2 = 2;
			}
			result = num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void ComboBoxDataSource_WaypointType_WeaponRoute(ref DataTable theComboBoxDataSource_WaypointType)
	{
		if (!theComboBoxDataSource_WaypointType.Columns.Contains("ID"))
		{
			theComboBoxDataSource_WaypointType.Columns.Add("ID", typeof(int));
		}
		if (!theComboBoxDataSource_WaypointType.Columns.Contains("Description"))
		{
			theComboBoxDataSource_WaypointType.Columns.Add("Description", typeof(string));
		}
		theComboBoxDataSource_WaypointType.Rows.Add(0, Waypoint.get_WaypointTypeString(WaypointType.Launch));
		theComboBoxDataSource_WaypointType.Rows.Add(1, Waypoint.get_WaypointTypeString(WaypointType.TurningPoint));
		theComboBoxDataSource_WaypointType.Rows.Add(2, Waypoint.get_WaypointTypeString(WaypointType.TerminalPoint));
		theComboBoxDataSource_WaypointType.Rows.Add(3, Waypoint.get_WaypointTypeString(WaypointType.Activation));
		theComboBoxDataSource_WaypointType.Rows.Add(4, Waypoint.get_WaypointTypeString(WaypointType.Termination));
		theComboBoxDataSource_WaypointType.Rows.Add(5, Waypoint.get_WaypointTypeString(WaypointType.HoldStart));
		theComboBoxDataSource_WaypointType.Rows.Add(6, Waypoint.get_WaypointTypeString(WaypointType.HoldEnd));
	}

	public static int? WaypointTypeSelection_To_WaypointType_WeaponRoute(ref object Type)
	{
		int? result;
		try
		{
			switch (Conversions.ToInteger(Type))
			{
			default:
				result = null;
				break;
			case 0:
				return 28;
			case 1:
				return 6;
			case 2:
				return 2;
			case 3:
				return 29;
			case 4:
				return 30;
			case 5:
				return 26;
			case 6:
				return 27;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 6;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static int WaypointType_To_WaypointTypeSelection_WeaponRoute(object Type)
	{
		int result;
		try
		{
			result = Conversions.ToInteger(Type) switch
			{
				26 => 5, 
				27 => 6, 
				28 => 0, 
				29 => 3, 
				30 => 4, 
				6 => 1, 
				2 => 2, 
				_ => 1, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 1;
			}
			else
			{
				num = 1;
			}
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void ComboBoxDataSource_Formation(ref DataTable theComboBoxDataSource_Formation)
	{
		if (!theComboBoxDataSource_Formation.Columns.Contains("ID"))
		{
			theComboBoxDataSource_Formation.Columns.Add("ID", typeof(int));
		}
		if (!theComboBoxDataSource_Formation.Columns.Contains("Description"))
		{
			theComboBoxDataSource_Formation.Columns.Add("Description", typeof(string));
		}
		theComboBoxDataSource_Formation.Rows.Add(0, Waypoint.get_FormationString(Formation.Spread));
		theComboBoxDataSource_Formation.Rows.Add(1, Waypoint.get_FormationString(Formation.Trail_1nm));
		theComboBoxDataSource_Formation.Rows.Add(2, Waypoint.get_FormationString(Formation.Split));
	}

	public static void ComboBoxDataSource_TurnRate(ref DataTable theComboBoxDataSource_TurnRate)
	{
		if (!theComboBoxDataSource_TurnRate.Columns.Contains("ID"))
		{
			theComboBoxDataSource_TurnRate.Columns.Add("ID", typeof(int));
		}
		if (!theComboBoxDataSource_TurnRate.Columns.Contains("Description"))
		{
			theComboBoxDataSource_TurnRate.Columns.Add("Description", typeof(string));
		}
		theComboBoxDataSource_TurnRate.Rows.Add(0, Waypoint.get_TurnRateString(TurnRateCategory.StandardRateTurn));
		theComboBoxDataSource_TurnRate.Rows.Add(1, Waypoint.get_TurnRateString(TurnRateCategory.HalfStandardRateTurn));
		theComboBoxDataSource_TurnRate.Rows.Add(2, Waypoint.get_TurnRateString(TurnRateCategory.DoubleStandardRateTurn));
		theComboBoxDataSource_TurnRate.Rows.Add(3, Waypoint.get_TurnRateString(TurnRateCategory.FlatTurn));
		theComboBoxDataSource_TurnRate.Rows.Add(4, Waypoint.get_TurnRateString(TurnRateCategory.TwoGTurn));
		theComboBoxDataSource_TurnRate.Rows.Add(5, Waypoint.get_TurnRateString(TurnRateCategory.const_5));
		theComboBoxDataSource_TurnRate.Rows.Add(6, Waypoint.get_TurnRateString(TurnRateCategory.const_6));
	}

	public static int? FormationSelection_To_Formation(ref object Type)
	{
		int? result = default(int?);
		try
		{
			switch (Conversions.ToInteger(Type))
			{
			default:
				result = null;
				break;
			case 0:
				result = 0;
				return result;
			case 1:
				result = 1;
				return result;
			case 2:
				result = 100;
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101301", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static int? TurnRateSelection_To_TurnRate(ref object Type)
	{
		int? result = default(int?);
		try
		{
			switch (Conversions.ToInteger(Type))
			{
			default:
				result = null;
				break;
			case 0:
				result = 0;
				return result;
			case 1:
				result = 1;
				return result;
			case 2:
				result = 2;
				return result;
			case 3:
				result = 3;
				return result;
			case 4:
				result = 4;
				return result;
			case 5:
				result = 5;
				return result;
			case 6:
				result = 6;
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200642", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static int Formation_To_FormationSelection(object Type)
	{
		int result;
		try
		{
			result = Conversions.ToInteger(Type) switch
			{
				0 => 0, 
				100 => 2, 
				1 => 1, 
				_ => 0, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 0;
			}
			else
			{
				num = 0;
			}
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void ComboBoxDataSource_SpeedToT(ref DataTable theComboBoxDataSource_SpeedToT)
	{
		if (!theComboBoxDataSource_SpeedToT.Columns.Contains("ID"))
		{
			theComboBoxDataSource_SpeedToT.Columns.Add("ID", typeof(int));
		}
		if (!theComboBoxDataSource_SpeedToT.Columns.Contains("Description"))
		{
			theComboBoxDataSource_SpeedToT.Columns.Add("Description", typeof(string));
		}
		theComboBoxDataSource_SpeedToT.Rows.Add(0, Waypoint.get_SpeedToTString(SpeedToT.No));
		theComboBoxDataSource_SpeedToT.Rows.Add(1, Waypoint.get_SpeedToTString(SpeedToT.Yes_DownOnly));
		theComboBoxDataSource_SpeedToT.Rows.Add(2, Waypoint.get_SpeedToTString(SpeedToT.Yes_UpOrDown_Military));
		theComboBoxDataSource_SpeedToT.Rows.Add(3, Waypoint.get_SpeedToTString(SpeedToT.Yes_UpOrDown_Afterburner));
	}

	public static int? SpeedToTSelection_To_SpeedToT(ref object Type)
	{
		int? result = default(int?);
		try
		{
			switch (Conversions.ToInteger(Type))
			{
			default:
				result = null;
				break;
			case 0:
				result = 0;
				return result;
			case 1:
				result = 1;
				return result;
			case 2:
				result = 2;
				return result;
			case 3:
				result = 3;
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static int SpeedToT_To_FormationSpeedToT(object Type)
	{
		int result;
		try
		{
			result = Conversions.ToInteger(Type) switch
			{
				0 => 0, 
				1 => 1, 
				2 => 2, 
				3 => 3, 
				_ => 0, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 0;
			}
			else
			{
				num = 0;
			}
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal bool IsStationWaypoint()
	{
		WaypointType type = Type;
		if ((uint)(type - 20) <= 4u)
		{
			return true;
		}
		return false;
	}

	internal bool IsStationStartWaypoint()
	{
		WaypointType type = Type;
		if ((uint)(type - 20) <= 3u)
		{
			return true;
		}
		return false;
	}

	internal bool IsStationEndWaypoint()
	{
		WaypointType type = Type;
		if (type == WaypointType.StationEnd)
		{
			return true;
		}
		return false;
	}

	internal bool IsHoldStartWaypoint()
	{
		WaypointType type = Type;
		if (type == WaypointType.HoldStart)
		{
			return true;
		}
		return false;
	}

	internal bool IsHoldEndWaypoint()
	{
		WaypointType type = Type;
		if (type == WaypointType.HoldEnd)
		{
			return true;
		}
		return false;
	}

	internal bool IsHoldWaypoint()
	{
		WaypointType type = Type;
		if ((uint)(type - 26) <= 1u)
		{
			return true;
		}
		return false;
	}

	internal bool IsHoldOrAssembleWaypoint()
	{
		WaypointType type = Type;
		if (type != WaypointType.Assemble && (uint)(type - 26) > 1u)
		{
			return false;
		}
		return true;
	}

	internal bool IsExclusivelyStrikeIngressWaypoint()
	{
		WaypointType type = Type;
		int result;
		int result2;
		if (type <= WaypointType.StrikeIngress)
		{
			if (type != WaypointType.InitialPoint && type != WaypointType.StrikeIngress)
			{
				result = 0;
				goto IL_0026;
			}
		}
		else if (type != WaypointType.TakeOff)
		{
			if (type == WaypointType.WeaponLaunch)
			{
				result2 = 1;
				goto IL_002a;
			}
			result = 0;
			goto IL_0026;
		}
		result2 = 1;
		goto IL_002a;
		IL_0026:
		return (byte)result != 0;
		IL_002a:
		return (byte)result2 != 0;
	}

	internal bool IsExclusivelyStrikeTargetWaypoint()
	{
		int result;
		switch (Type)
		{
		case WaypointType.WeaponTarget:
			result = 1;
			break;
		default:
			return false;
		case WaypointType.Target:
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	internal bool IsExclusivelyStrikeEgressWaypoint()
	{
		int result;
		switch (Type)
		{
		case WaypointType.Land:
			result = 1;
			break;
		default:
			return false;
		case WaypointType.LandingMarshal:
		case WaypointType.StrikeEgress:
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	public void PostDeserializationHousekeeping(ref Scenario theScen, Side theSide, bool GameIsRunning)
	{
		try
		{
			if (TankerMissions_IDs.Count <= 0)
			{
				return;
			}
			Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				foreach (Mission mission in side.Missions)
				{
					if (TankerMissions_IDs.Contains(mission.ObjectID))
					{
						TankerMissions.Add(mission);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static Waypoint()
	{
		Class72.smethod_20();
	}
}
