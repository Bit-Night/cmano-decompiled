using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[StandardModule]
public sealed class LuaMission
{
	[CompilerGenerated]
	internal sealed class _Closure$__12-0
	{
		public object $VB$Local_o;

		public _Closure$__12-0(_Closure$__12-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__1(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__2(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__3(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__4(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__5(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__6(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__7(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__12-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__16-0
	{
		public object $VB$Local_o;

		public _Closure$__16-0(_Closure$__16-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__1(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__2(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__3(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__4(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__5(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__6(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__7(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__16-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__16-1
	{
		public object $VB$Local_o;

		public _Closure$__16-1(_Closure$__16-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__8(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__9(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__10(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__11(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__12(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__13(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__14(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__15(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__16-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__16-2
	{
		public object $VB$Local_o;

		public _Closure$__16-2(_Closure$__16-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__16(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__17(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__18(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__19(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__20(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__21(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__22(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__23(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__16-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__16-3
	{
		public object $VB$Local_o;

		public _Closure$__16-3(_Closure$__16-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__24(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__25(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__26(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__27(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__28(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__29(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__30(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__31(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__16-3()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__16-4
	{
		public object $VB$Local_o;

		public _Closure$__16-4(_Closure$__16-4 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__32(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__33(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__34(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__35(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__36(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__37(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__38(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__39(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__16-4()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__16-5
	{
		public object $VB$Local_o;

		public _Closure$__16-5(_Closure$__16-5 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__40(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__41(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__42(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__43(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__44(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__45(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__46(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__47(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__16-5()
		{
			Class72.smethod_20();
		}
	}

	public const string Doctrine_UseReplenishment = "use_refuel_unrep";

	public static readonly string[] Mission_Tanker;

	public static readonly string[] Mission_Support;

	public static readonly string[] Mission_Strike;

	public static readonly string[] Mission_Cargo;

	public static readonly string[] Mission_Mining;

	public static readonly string[] Mission_MineClearing;

	public static readonly string[] Mission_Patrol;

	public static readonly string[] Mission_Ferry;

	static LuaMission()
	{
		Class72.smethod_20();
		Mission_Tanker = new string[11]
		{
			"TankerUsage", "TankerMissionList", "LaunchMissionWithoutTankersInPlace", "TankerMinNumber_Total", "TankerMinNumber_Airborne", "TankerMinNumber_Station", "MaxReceiversInQueuePerTanker_Airborne", "FuelQtyToStartLookingForTanker_Airborne", "TankerMaxDistance_Airborne", "TankerFollowsReceivers",
			"KeepOnMissionWithoutTankersInPlace"
		};
		Mission_Support = new string[46]
		{
			"OneThirdRule", "OnStation", "TransitThrottleAircraft", "TransitAltitudeAircraft", "TransitTerrainFollowingAircraft", "StationThrottleAircraft", "StationAltitudeAircraft", "StationTerrainFollowingAircraft", "TransitThrottleSubmarine", "TransitDepthSubmarine",
			"StationThrottleSubmarine", "StationDepthSubmarine", "TransitThrottleShip", "StationThrottleShip", "FlightSize", "MinAircraftReq", "UseFlightSize", "GroupSize", "UseGroupSize", "Zone",
			"LoopType", "OnStation", "OneTimeOnly", "ActiveEMCON", "TankerOneTime", "TankerMaxReceivers", "UseFlightplan", "UseFlightplansOnly", "IncludeInATO", "Course",
			"TransitThrottleFacility", "StationThrottleShipFacility", "CCEnable", "CCAllowQRA", "CCFlightGenMethod", "CCStationTime", "CCOverlap", "StationDepthSubmarinePreset", "TransitDepthSubmarinePreset", "UseStationDepthSubmarinePreset",
			"UseTransitDepthSubmarinePreset", "StationAltitudePreset", "TransitAltitudePreset", "UseStationAltitudePreset", "UseTransitAltitudePreset", "StationGroupingType"
		};
		Mission_Strike = new string[50]
		{
			"Type", "EscortFlightSizeShooter", "EscortMinShooter", "EscortMaxShooter", "EscortResponseRadius", "EscortResponseRadiusSead", "EscortUseFlightSize", "EscortFlightSizeNonShooter", "EscortMinNonShooter", "EscortMaxNonShooter",
			"EscortGroupSize", "EscortUs<ContinousCoverage_NumberOfFlightsNeededToAllowQRA>eGroupSize", "StrikeOneTimeOnly", "StrikeMinimumTrigger", "StrikeMax", "StrikeFlightSize", "StrikeMinAircraftReq", "StrikeUseFlightSize", "StrikeGroupSize", "StrikeUseGroupSize",
			"StrikeAutoPlanner", "StrikePrePlan", "StrikeRadarUsage", "StrikeMinDist", "StrikeMaxDist", "UseFlightplan", "UseFlightplansOnly", "IncludeInATO", "EscortFormationCruise", "EscortFormationAttack",
			"EscortTransitThrottle", "EscortTransitAltitude", "EscortTransitTerrainFollowing", "StrikeFormationCruise", "StrikeFormationAttack", "StrikeMinDistAircraft", "StrikeMaxDistAircraft", "StrikeMinDistShip", "StrikeMaxDistShip", "FlightsToInvestigate",
			"FlightsToEngage", "WingmanEngageDistance", "BoatsToInvestigate", "BoatsToEngage", "GroupMemberEngageDistance", "PrePlannedOnly", "FocusOnStrike", "OffAxisAttack", "AttackMethod", "SplitDistance"
		};
		Mission_Cargo = new string[21]
		{
			"OneThirdRule", "Type", "TransitThrottleAircraft", "TransitAltitudeAircraft", "StationThrottleAircraft", "StationAltitudeAircraft", "TransitThrottleSubmarine", "TransitDepthSubmarine", "StationThrottleSubmarine", "StationDepthSubmarine",
			"TransitThrottleShip", "StationThrottleShip", "UseFlightSize", "UseGroupSize", "Zone", "IsFulfilled", "DestinationUnitID", "MoveAllCargo", "AllowGroundUnitSelfDeliveryFromCargo", "AllGroundUnitAttemptSelfDelivery",
			"AutomaticallyUnpackContainersAtDestination"
		};
		Mission_Mining = new string[32]
		{
			"OneThirdRule", "TransitThrottleAircraft", "TransitAltitudeAircraft", "TransitTerrainFollowingAircraft", "StationThrottleAircraft", "StationAltitudeAircraft", "StationTerrainFollowingAircraft", "TransitThrottleSubmarine", "TransitDepthSubmarine", "StationThrottleSubmarine",
			"StationDepthSubmarine", "TransitThrottleShip", "StationThrottleShip", "FlightSize", "MinAircraftReq", "UseFlightSize", "GroupSize", "UseGroupSize", "Zone", "ArmingDelay",
			"StationDepthSubmarinePreset", "TransitDepthSubmarinePreset", "UseStationDepthSubmarinePreset", "UseTransitDepthSubmarinePreset", "StationAltitudePreset", "TransitAltitudePreset", "UseStationAltitudePreset", "UseTransitAltitudePreset", "MinesLaidInSet", "MinesLaidInterval",
			"MinesLaidMethod", "MinesLaidSetInterval"
		};
		Mission_MineClearing = new string[28]
		{
			"OneThirdRule", "LoopType", "TransitThrottleAircraft", "TransitAltitudeAircraft", "TransitTerrainFollowingAircraft", "StationThrottleAircraft", "StationAltitudeAircraft", "StationTerrainFollowingAircraft", "TransitThrottleSubmarine", "TransitDepthSubmarine",
			"StationThrottleSubmarine", "StationDepthSubmarine", "TransitThrottleShip", "StationThrottleShip", "FlightSize", "MinAircraftReq", "UseFlightSize", "GroupSize", "UseGroupSize", "Zone",
			"StationDepthSubmarinePreset", "TransitDepthSubmarinePreset", "UseStationDepthSubmarinePreset", "UseTransitDepthSubmarinePreset", "StationAltitudePreset", "TransitAltitudePreset", "UseStationAltitudePreset", "UseTransitAltitudePreset"
		};
		Mission_Patrol = new string[66]
		{
			"Type", "OneThirdRule", "CheckOPA", "CheckWWR", "ActiveEMCON", "OnStation", "LoopType", "TransitThrottleAircraft", "TransitAltitudeAircraft", "TransitTerrainFollowingAircraft",
			"StationThrottleAircraft", "StationAltitudeAircraft", "StationTerrainFollowingAircraft", "AttackThrottleAircraft", "AttackAltitudeAircraft", "AttackTerrainFollowingAircraft", "AttackDistanceAircraft", "TransitThrottleSubmarine", "TransitDepthSubmarine", "StationThrottleSubmarine",
			"StationDepthSubmarine", "AttackThrottleSubmarine", "AttackDepthSubmarine", "AttackDistanceSubmarine", "TransitDepthSubmarine_Preset", "AttackDepthSubmarine_Preset", "StationDepthSubmarine_Preset", "TransitThrottleShip", "StationThrottleShip", "AttackThrottleShip",
			"AttackDistanceShip", "SprintDrift", "AvoidCavitation", "FlightSize", "MinAircraftReq", "UseFlightSize", "GroupSize", "UseGroupSize", "ProsecutionZone", "PatrolZone",
			"TransitThrottleFacility", "StationThrottleFacility", "UseFlightplan", "UseFlightplansOnly", "IncludeInATO", "FormationCruise", "FormationAttack", "FlightsToInvestigate", "FlightsToEngage", "WingmanEngageDistance",
			"BoatsToInvestigate", "BoatsToEngage", "GroupMemberEngageDistance", "StationDepthSubmarinePreset", "TransitDepthSubmarinePreset", "AttackDepthSubmarine_Preset", "UseStationDepthSubmarinePreset", "UseTransitDepthSubmarinePreset", "UseAttackDepthSubmarinePreset", "StationAltitudePreset",
			"TransitAltitudePreset", "AttackAltitudePreset", "UseStationAltitudePreset", "UseTransitAltitudePreset", "UseAttackAltitudePreset", "StationGroupingType"
		};
		Mission_Ferry = new string[7] { "FerryBehavior", "FerryThrottleAircraft", "FerryAltitudeAircraft", "FerryTerrainFollowingAircraft", "FlightSize", "MinAircraftReq", "UseFlightSize" };
	}

	public static LuaTable ScenEdit_GetMissions(string SideID, Scenario ScenarioContext)
	{
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		Side side = null;
		try
		{
			side = LuaUtility.QuerySideObject(SideID, ScenarioContext);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (!(ex2 is LuaError))
			{
				throw new LuaError("Side not found");
			}
			throw;
		}
		if (side != null)
		{
			foreach (Mission mission in side.Missions)
			{
				luaTable[luaTable.Keys.Count + 1] = new LuaWrapper_Mission(mission, ScenarioContext);
			}
		}
		return luaTable;
	}

	public static LuaWrapper_Mission ScenEdit_GetMission(string SideName, string MissionNameOrID, Scenario ScenarioContext)
	{
		Mission mission = null;
		Side side = null;
		new List<ReferencePoint>();
		side = PrivateMethods.ValidateSide(SideName, ScenarioContext);
		if (side != null)
		{
			mission = ValidateMissionBySide(MissionNameOrID, side);
			if (mission == null)
			{
				throw new LuaError("missing mission " + MissionNameOrID);
			}
			return new LuaWrapper_Mission(mission, ScenarioContext);
		}
		throw new LuaError("missing side:    " + SideName);
	}

	public static LuaWrapper_Mission ScenEdit_AddMission(string SideName, string MissionNameOrID, string MissionType, LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		LuaSandBox.Singleton().CreateTable();
		Scenario theScen = ScenarioContext;
		ActiveUnit activeUnit = null;
		Mission mission = null;
		Mission mission2 = null;
		Side side = null;
		List<ReferencePoint> theCourse = new List<ReferencePoint>();
		try
		{
			side = PrivateMethods.ValidateSide(SideName, theScen);
			if (side != null)
			{
				mission = ValidateMissionBySide(MissionNameOrID, side);
				if (Information.IsNothing((object)mission))
				{
					string text = null;
					int num;
					if (dictionary.ContainsKey("TYPE"))
					{
						text = Conversions.ToString(dictionary["TYPE"]);
						num = 0;
					}
					else
					{
						num = 0;
					}
					Mission.MissionCategory result = (Mission.MissionCategory)num;
					if (dictionary.ContainsKey("CATEGORY") && (!Enum.TryParse<Mission.MissionCategory>(Conversions.ToString(dictionary["CATEGORY"]), ignoreCase: true, out result) || !Enum.IsDefined(typeof(Mission.MissionCategory), result)))
					{
						throw new LuaError("Unknown mission category " + Conversions.ToString(dictionary["CATEGORY"]));
					}
					if (dictionary.ContainsKey("DESTINATION"))
					{
						activeUnit = PrivateMethods.smethod_1(Conversions.ToString(dictionary["DESTINATION"]), theScen);
					}
					if (dictionary.ContainsKey("ZONE"))
					{
						List<object> list = LuaUtility.ToArray(((LuaTable)dictionary["ZONE"]).GetEnumerator());
						using List<object>.Enumerator enumerator = list.GetEnumerator();
						_Closure$__12-0 closure$__12- = default(_Closure$__12-0);
						while (enumerator.MoveNext())
						{
							closure$__12- = new _Closure$__12-0(closure$__12-);
							closure$__12-.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator.Current);
							ReferencePoint referencePoint = null;
							if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__12-._Lambda$__0)))
							{
								referencePoint = side.RefPoints.First(closure$__12-._Lambda$__1);
							}
							else if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__12-._Lambda$__2)))
							{
								referencePoint = side.RefPoints.First(closure$__12-._Lambda$__3);
							}
							else if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__12-._Lambda$__4)))
							{
								if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__12-._Lambda$__6)))
								{
									referencePoint = side.RefPoints.First(closure$__12-._Lambda$__7);
								}
							}
							else
							{
								referencePoint = side.RefPoints.First(closure$__12-._Lambda$__5);
							}
							if (!Information.IsNothing((object)referencePoint))
							{
								theCourse.Add(referencePoint);
							}
						}
					}
					if (text == null && (string.Equals(MissionType, "STRIKE", StringComparison.OrdinalIgnoreCase) || string.Equals(MissionType, "PATROL", StringComparison.OrdinalIgnoreCase)))
					{
						throw new LuaError("Missing type of strike/patrol mission");
					}
					if (result == Mission.MissionCategory.Package && dictionary.ContainsKey("POOL"))
					{
						mission2 = ValidateMissionBySide(Conversions.ToString(dictionary["POOL"]), side);
						if (mission2 == null || mission2.Category != Mission.MissionCategory.TaskPool)
						{
							throw new LuaError("Missing parent task pool for package");
						}
					}
					if (result != Mission.MissionCategory.Mission && result != Mission.MissionCategory.Package)
					{
						TaskPool taskPool = new TaskPool(ref side, ref theScen, MissionNameOrID, Mission.MissionCategory.TaskPool);
						side.Missions_Add(taskPool);
						return new LuaWrapper_Mission(taskPool, ScenarioContext);
					}
					switch (MissionType.ToUpperInvariant())
					{
					case "PATROL":
						switch (text.ToUpperInvariant())
						{
						case "SEAD":
							mission = new Patrol(side, theScen, MissionNameOrID, result, theCourse, GlobalVariables.PatrolType.SEAD, ValidateArea: false);
							break;
						case "SeaControl":
						case "SEA":
							mission = new Patrol(side, theScen, MissionNameOrID, result, theCourse, GlobalVariables.PatrolType.SeaControl, ValidateArea: false);
							break;
						case "ASW":
						case "SUB":
							mission = new Patrol(side, theScen, MissionNameOrID, result, theCourse, GlobalVariables.PatrolType.ASW, ValidateArea: false);
							break;
						case "SUR_SEA":
						case "ASuW_Naval":
						case "NAVAL":
							mission = new Patrol(side, theScen, MissionNameOrID, result, theCourse, GlobalVariables.PatrolType.ASuW_Naval, ValidateArea: false);
							break;
						case "AIR":
						case "AAW":
							mission = new Patrol(side, theScen, MissionNameOrID, result, theCourse, GlobalVariables.PatrolType.AAW, ValidateArea: false);
							break;
						case "MIXED":
						case "SUR_MIXED":
						case "ASuW_Mixed":
							mission = new Patrol(side, theScen, MissionNameOrID, result, theCourse, GlobalVariables.PatrolType.ASuW_Mixed, ValidateArea: false);
							break;
						default:
							throw new LuaError("missing mission sub-type");
						case "SUR_LAND":
						case "ASuW_Land":
						case "LAND":
							mission = new Patrol(side, theScen, MissionNameOrID, result, theCourse, GlobalVariables.PatrolType.ASuW_Land, ValidateArea: false);
							break;
						}
						goto IL_09e1;
					case "CARGO":
						mission = new CargoMission(side, theScen, MissionNameOrID, result, theCourse, ValidateArea: false, activeUnit);
						goto IL_09e1;
					case "MINING":
						mission = new MiningMission(side, theScen, MissionNameOrID, result, theCourse, ValidateArea: false);
						goto IL_09e1;
					case "FERRY":
						if (activeUnit == null)
						{
							throw new LuaError("missing destination");
						}
						mission = new FerryMission(side, theScen, MissionNameOrID, result, activeUnit);
						goto IL_09e1;
					case "MINECLEARING":
						mission = new MineClearingMission(side, theScen, MissionNameOrID, result, theCourse, ValidateArea: false);
						goto IL_09e1;
					case "STRIKE":
						switch (text.ToUpperInvariant())
						{
						case "SEA":
						case "Maritime_Strike":
						case "SUR_SEA":
						case "NAVAL":
							mission = new Strike(side, theScen, MissionNameOrID, result, Strike.StrikeType.Maritime_Strike);
							mission.Name = MissionNameOrID;
							break;
						case "Land_Strike":
						case "SUR_LAND":
						case "LAND":
							mission = new Strike(side, theScen, MissionNameOrID, result, Strike.StrikeType.Land_Strike);
							mission.Name = MissionNameOrID;
							break;
						case "ASW":
						case "SUB":
						case "Sub_Strike":
							mission = new Strike(side, theScen, MissionNameOrID, result, Strike.StrikeType.Sub_Strike);
							mission.Name = MissionNameOrID;
							break;
						default:
							throw new LuaError("missing mission sub-type");
						case "AIR":
						case "Air_Intercept":
						case "AAW":
							mission = new Strike(side, theScen, MissionNameOrID, result, Strike.StrikeType.Air_Intercept);
							mission.Name = MissionNameOrID;
							break;
						}
						goto IL_09e1;
					case "SUPPORT":
						mission = new SupportMission(ref side, ref theScen, MissionNameOrID, result, ref theCourse, ValidateArea: false);
						goto IL_09e1;
					default:
						{
							throw new LuaError("missing mission type");
						}
						IL_09e1:
						if (result == Mission.MissionCategory.Package)
						{
							mission.set_ParentTaskPoolID(side, mission2.ObjectID);
							((TaskPool)mission2).PackageList.Add(mission);
							((TaskPool)mission2).PackageList_IDs.Add(mission.ObjectID);
						}
						side.Missions_Add(mission);
						return new LuaWrapper_Mission(mission, ScenarioContext);
					}
				}
				throw new LuaError("Existing mission " + MissionNameOrID);
			}
			throw new LuaError("missing side " + SideName);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool ScenEdit_DeleteMission(string SideName, string MissionNameOrID, Scenario ScenarioContext)
	{
		Mission mission = null;
		Side side = null;
		new List<ReferencePoint>();
		side = PrivateMethods.ValidateSide(SideName, ScenarioContext);
		if (side == null)
		{
			throw new LuaError("missing side " + SideName);
		}
		mission = ValidateMissionBySide(MissionNameOrID, side);
		if (mission == null)
		{
			throw new LuaError("missing mission " + MissionNameOrID);
		}
		foreach (ActiveUnit unit in side.Units)
		{
			if (!Information.IsNothing((object)unit.ActiveMissionOrPackage()) && Operators.CompareString(unit.ActiveMissionOrPackage().ObjectID, mission.ObjectID, false) == 0)
			{
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				unit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
			}
		}
		side.Missions_Remove(mission);
		return true;
	}

	public static LuaTable ScenEdit_ExportMission(string SideName, string MissionNameOrID, Scenario theScen)
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		Mission mission = null;
		Side side = null;
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		int num = 1;
		side = PrivateMethods.ValidateSide(SideName, theScen);
		if (side == null)
		{
			throw new LuaError("missing side " + SideName);
		}
		mission = ValidateMissionBySide(MissionNameOrID, side);
		if (Information.IsNothing((object)mission))
		{
			throw new LuaError("Mission " + MissionNameOrID + " Not found!");
		}
		int num2;
		if (!Directory.Exists(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults"))
		{
			Directory.CreateDirectory(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults");
			num2 = 6;
		}
		else
		{
			num2 = 6;
		}
		string[] array = new string[num2];
		array[0] = GameGeneral.TopLevelWritablePath;
		array[1] = Conversions.ToString(Path.DirectorySeparatorChar);
		array[2] = "Defaults";
		array[3] = Conversions.ToString(Path.DirectorySeparatorChar);
		array[4] = MissionNameOrID;
		array[5] = ".xml";
		FileStream fileStream = File.Create(string.Concat(array));
		XmlWriterSettings val = new XmlWriterSettings();
		using (MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream())
		{
			XmlWriter val2 = XmlWriter.Create((Stream)memoryStream, val);
			try
			{
				Mission mission2 = mission;
				XmlWriter theWriter = val2;
				HashSet<string> ObjectsAlreadySerialized = null;
				mission2.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref theScen);
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
			fileStream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Position);
			fileStream.Close();
		}
		luaTable[num] = mission.ObjectID;
		num++;
		return luaTable;
	}

	public static LuaTable ScenEdit_ImportMission(string SideName, string MissionNameOrID, Scenario theScen)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		Side side = null;
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		int num = 1;
		side = PrivateMethods.ValidateSide(SideName, theScen);
		if (side == null)
		{
			throw new LuaError("missing side " + SideName);
		}
		try
		{
			FileStream fileStream = new FileStream(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults" + Conversions.ToString(Path.DirectorySeparatorChar) + MissionNameOrID + ".xml", FileMode.Open, FileAccess.Read);
			XmlDocument val = new XmlDocument();
			ConcurrentDictionary<string, ScenarioObject> theDictionary = new ConcurrentDictionary<string, ScenarioObject>();
			using (fileStream)
			{
				try
				{
					val.Load((Stream)fileStream);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					GameGeneral.SendMessageBoxToUI("File Is improperly formatted, read failed!", side);
					ProjectData.ClearProjectError();
				}
			}
			fileStream.Close();
			foreach (XmlNode childNode in ((XmlNode)val).ChildNodes)
			{
				XmlNode theNode = childNode;
				Mission mission = Mission.FromXML(ref theNode, ref theDictionary, ref theScen);
				if (!Information.IsNothing((object)mission))
				{
					side.Missions_Add(mission);
					luaTable[num] = mission.ObjectID;
					num++;
				}
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			GameGeneral.SendMessageBoxToUI("Unable to find directory Or file!", side);
			ProjectData.ClearProjectError();
		}
		return luaTable;
	}

	public static LuaWrapper_Mission ScenEdit_SetMission(string SideName, string MissionNameOrID, LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		LuaSandBox.Singleton().CreateTable();
		Mission mission = null;
		Side side = null;
		side = PrivateMethods.ValidateSide(SideName, ScenarioContext);
		if (side != null)
		{
			mission = ValidateMissionBySide(MissionNameOrID, side);
			if (mission == null)
			{
				throw new LuaError("missing mission: " + MissionNameOrID);
			}
			if (dictionary.ContainsKey("NEWNAME"))
			{
				string name;
				try
				{
					name = dictionary["NEWNAME"].ToString();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					throw new LuaError("Unable to parse value NewName to string!");
				}
				mission.Name = name;
			}
			string text = "DDMMYYYY";
			string text2 = "MMDDYYYY";
			string text3 = "YYYYMMDD";
			string text4 = text;
			if (dictionary.ContainsKey("DATEFORMAT"))
			{
				string text5 = Conversions.ToString(dictionary["DATEFORMAT"]);
				if (Operators.CompareString(text5, text, false) != 0 && Operators.CompareString(text5, text2, false) != 0 && Operators.CompareString(text5, text3, false) != 0)
				{
					throw new LuaError("Invalid date format '" + text5 + "'");
				}
				text4 = text5;
			}
			if (dictionary.ContainsKey("STARTTIME"))
			{
				DateTime? value = null;
				try
				{
					string text6 = dictionary["STARTTIME"].ToString();
					if (text6.Length > 0)
					{
						string text7 = text4;
						if (Operators.CompareString(text7, text, false) == 0)
						{
							value = LuaUtility.ParseDateTime_String(text6, LuaUtility.DateFormat.DDMMYYYY);
						}
						else if (Operators.CompareString(text7, text2, false) != 0)
						{
							if (Operators.CompareString(text7, text3, false) == 0)
							{
								value = LuaUtility.ParseDateTime_String(text6, LuaUtility.DateFormat.YYYYMMDD);
							}
						}
						else
						{
							value = LuaUtility.ParseDateTime_String(text6, LuaUtility.DateFormat.MMDDYYYY);
						}
					}
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					throw new LuaError("Unable to parse value StartTime!");
				}
				mission.StartTime_Set(value, ScenarioContext);
			}
			if (dictionary.ContainsKey("ENDTIME"))
			{
				DateTime? value2 = null;
				try
				{
					string text8 = dictionary["ENDTIME"].ToString();
					if (text8.Length > 0)
					{
						string text9 = text4;
						if (Operators.CompareString(text9, text, false) == 0)
						{
							value2 = LuaUtility.ParseDateTime_String(text8, LuaUtility.DateFormat.DDMMYYYY);
						}
						else if (Operators.CompareString(text9, text2, false) == 0)
						{
							value2 = LuaUtility.ParseDateTime_String(text8, LuaUtility.DateFormat.MMDDYYYY);
						}
						else if (Operators.CompareString(text9, text3, false) == 0)
						{
							value2 = LuaUtility.ParseDateTime_String(text8, LuaUtility.DateFormat.YYYYMMDD);
						}
					}
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					throw new LuaError("Unable to parse value EndTime!");
				}
				mission.EndTime_Set(value2, ScenarioContext);
			}
			if (dictionary.ContainsKey("ISACTIVE"))
			{
				bool? flag = null;
				Mission.MissionStatus value3 = mission.get_Status(ScenarioContext);
				try
				{
					flag = LuaUtility.ParseBoolean(dictionary["ISACTIVE"].ToString());
					if (flag.HasValue)
					{
						bool? flag2 = flag;
						flag2 = flag2;
						value3 = ((flag2 != true) ? Mission.MissionStatus.Inactive : Mission.MissionStatus.Active);
					}
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					throw new LuaError("Unable to parse value IsActive!");
				}
				if (flag.HasValue)
				{
					mission.set_Status(ScenarioContext, value3);
				}
			}
			if (dictionary.ContainsKey("SISH"))
			{
				bool? flag3 = null;
				try
				{
					flag3 = LuaUtility.ParseBoolean(dictionary["SISH"].ToString());
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					throw new LuaError("Unable to parse value SISH!");
				}
				if (flag3.HasValue)
				{
					mission.ScrubIfSideIsHuman = flag3.Value;
				}
			}
			if (dictionary.ContainsKey("ONDEACTIVATEUNASSIGN"))
			{
				bool? flag4 = null;
				try
				{
					flag4 = LuaUtility.ParseBoolean(dictionary["ONDEACTIVATEUNASSIGN"].ToString());
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					throw new LuaError("Unable to parse value ONDEACTIVATEUNASSIGN!");
				}
				if (flag4.HasValue)
				{
					mission.Deactivation_UnassignUnits = flag4.Value;
				}
			}
			if (dictionary.ContainsKey("ONDEACTIVATERTB"))
			{
				bool? flag5 = null;
				try
				{
					flag5 = LuaUtility.ParseBoolean(dictionary["ONDEACTIVATERTB"].ToString());
				}
				catch (Exception projectError7)
				{
					ProjectData.SetProjectError(projectError7);
					throw new LuaError("Unable to parse value ONDEACTIVATERTB!");
				}
				if (flag5.HasValue)
				{
					mission.Deactivation_OrderRTB = flag5.Value;
				}
			}
			if (dictionary.ContainsKey("ONDEACTIVATEDELETE"))
			{
				bool? flag6 = null;
				try
				{
					flag6 = LuaUtility.ParseBoolean(dictionary["ONDEACTIVATEDELETE"].ToString());
				}
				catch (Exception projectError8)
				{
					ProjectData.SetProjectError(projectError8);
					throw new LuaError("Unable to parse value ONDEACTIVATEDELETE!");
				}
				if (flag6.HasValue)
				{
					mission.Deactivation_DeleteMission = flag6.Value;
				}
			}
			if (dictionary.ContainsKey("TAKEOFFTIME"))
			{
				if (!string.Equals(Conversions.ToString(dictionary["TAKEOFFTIME"]), "CLEAR", StringComparison.OrdinalIgnoreCase))
				{
					string text10 = null;
					text10 = ((!dictionary.ContainsKey("TAKEOFFDATE")) ? Conversions.ToString(dictionary["TAKEOFFTIME"]) : (Conversions.ToString(dictionary["TAKEOFFDATE"]) + " " + Conversions.ToString(dictionary["TAKEOFFTIME"])));
					try
					{
						DateTime? dateTime = null;
						string text11 = text4;
						if (Operators.CompareString(text11, text, false) == 0)
						{
							dateTime = LuaUtility.ParseDateTime_String(text10, LuaUtility.DateFormat.DDMMYYYY);
						}
						else if (Operators.CompareString(text11, text2, false) == 0)
						{
							dateTime = LuaUtility.ParseDateTime_String(text10, LuaUtility.DateFormat.MMDDYYYY);
						}
						else if (Operators.CompareString(text11, text3, false) == 0)
						{
							dateTime = LuaUtility.ParseDateTime_String(text10, LuaUtility.DateFormat.YYYYMMDD);
						}
						if (dateTime.HasValue)
						{
							mission.TakeOffTime = dateTime.Value;
						}
					}
					catch (Exception projectError9)
					{
						ProjectData.SetProjectError(projectError9);
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					mission.TakeOffTime = null;
				}
			}
			if (dictionary.ContainsKey("TIMEONTARGET"))
			{
				if (!string.Equals(Conversions.ToString(dictionary["TIMEONTARGET"]), "CLEAR", StringComparison.OrdinalIgnoreCase))
				{
					string text12 = null;
					text12 = (dictionary.ContainsKey("DATEONTARGET") ? (Conversions.ToString(dictionary["DATEONTARGET"]) + " " + Conversions.ToString(dictionary["TIMEONTARGET"])) : Conversions.ToString(dictionary["TIMEONTARGET"]));
					try
					{
						DateTime? timeOnTarget = null;
						string text13 = text4;
						if (Operators.CompareString(text13, text, false) == 0)
						{
							timeOnTarget = LuaUtility.ParseDateTime_String(text12, LuaUtility.DateFormat.DDMMYYYY);
						}
						else if (Operators.CompareString(text13, text2, false) == 0)
						{
							timeOnTarget = LuaUtility.ParseDateTime_String(text12, LuaUtility.DateFormat.MMDDYYYY);
						}
						else if (Operators.CompareString(text13, text3, false) == 0)
						{
							timeOnTarget = LuaUtility.ParseDateTime_String(text12, LuaUtility.DateFormat.YYYYMMDD);
						}
						if (timeOnTarget.HasValue)
						{
							mission.TimeOnTarget = timeOnTarget;
						}
					}
					catch (Exception projectError10)
					{
						ProjectData.SetProjectError(projectError10);
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					mission.TimeOnTarget = null;
				}
			}
			if (dictionary.ContainsKey("SUBTYPE"))
			{
				try
				{
					string text14 = dictionary["SUBTYPE"].ToString();
					switch (mission.MissionClass)
					{
					default:
						throw new LuaError("can't change mission sub-type");
					case Mission._MissionClass.Cargo:
					{
						string text15 = text14.ToUpperInvariant();
						if (Operators.CompareString(text15, "DELIVERY", false) != 0)
						{
							if (Operators.CompareString(text15, "TRANSFER", false) != 0)
							{
								throw new LuaError("missing mission sub-type");
							}
							((CargoMission)mission).Type = CargoMission.CargoMissionType.Transfer;
						}
						else
						{
							((CargoMission)mission).Type = CargoMission.CargoMissionType.Delivery;
						}
						break;
					}
					case Mission._MissionClass.Patrol:
						switch (text14.ToUpperInvariant())
						{
						case "SeaControl":
						case "SEA":
							((Patrol)mission).Type = GlobalVariables.PatrolType.SeaControl;
							break;
						case "SUB":
						case "ASW":
							((Patrol)mission).Type = GlobalVariables.PatrolType.ASW;
							break;
						case "SEAD":
							((Patrol)mission).Type = GlobalVariables.PatrolType.SEAD;
							break;
						case "AIR":
						case "AAW":
							((Patrol)mission).Type = GlobalVariables.PatrolType.AAW;
							break;
						case "SUR_MIXED":
						case "MIXED":
						case "ASuW_Mixed":
							((Patrol)mission).Type = GlobalVariables.PatrolType.ASuW_Mixed;
							break;
						case "ASuW_Land":
						case "LAND":
						case "SUR_LAND":
							((Patrol)mission).Type = GlobalVariables.PatrolType.ASuW_Land;
							break;
						default:
							throw new LuaError("missing mission sub-type");
						case "NAVAL":
						case "SUR_SEA":
						case "ASuW_Naval":
							((Patrol)mission).Type = GlobalVariables.PatrolType.ASuW_Naval;
							break;
						}
						break;
					case Mission._MissionClass.Strike:
						switch (text14.ToUpperInvariant())
						{
						case "Maritime_Strike":
						case "SEA":
							((Strike)mission).Type = Strike.StrikeType.Maritime_Strike;
							break;
						case "Air_Intercept":
						case "AIR":
							((Strike)mission).Type = Strike.StrikeType.Air_Intercept;
							break;
						case "Land_Strike":
						case "LAND":
							((Strike)mission).Type = Strike.StrikeType.Land_Strike;
							break;
						default:
							throw new LuaError("missing mission sub-type");
						case "SUB":
						case "Sub_Strike":
							((Strike)mission).Type = Strike.StrikeType.Sub_Strike;
							break;
						}
						break;
					}
				}
				catch (Exception projectError11)
				{
					ProjectData.SetProjectError(projectError11);
					throw new LuaError("Unable to parse mission subType!");
				}
			}
			if (dictionary.ContainsKey("use_refuel_unrep".ToUpperInvariant()))
			{
				if (Operators.CompareString(Conversions.ToString(dictionary["use_refuel_unrep".ToUpperInvariant()]).ToLower(), "inherit", false) == 0)
				{
					mission.Doctrine.set_UseReplenishment(ScenarioContext, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UseUnderwayRefuelAndReplenishment?)null);
				}
				else
				{
					if (!Enum.TryParse<Doctrine._UseUnderwayRefuelAndReplenishment>(Conversions.ToString(dictionary["use_refuel_unrep".ToUpperInvariant()]), ignoreCase: true, out var result) || !Enum.IsDefined(typeof(Doctrine._UseUnderwayRefuelAndReplenishment), result))
					{
						throw new LuaError("Can't understand '" + Conversions.ToString(dictionary["use_refuel_unrep"]) + "' as use_refuel_unrep allowed values are: '0','1','2' which correspond to Always Excl Tankers, Never, Always Incl Tankers");
					}
					mission.Doctrine.set_UseReplenishment(ScenarioContext, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UseUnderwayRefuelAndReplenishment?)result);
				}
			}
			string[] mission_Tanker = Mission_Tanker;
			for (int i = 0; i < mission_Tanker.Length; i = checked(i + 1))
			{
				string text16 = mission_Tanker[i];
				text16 = text16.ToUpperInvariant();
				string text17 = text16;
				if (Operators.CompareString(text17, "TankerUsage".ToUpperInvariant(), false) != 0)
				{
					if (Operators.CompareString(text17, "LaunchMissionWithoutTankersInPlace".ToUpperInvariant(), false) != 0)
					{
						if (Operators.CompareString(text17, "KeepOnMissionWithoutTankersInPlace".ToUpperInvariant(), false) == 0)
						{
							if (dictionary.ContainsKey(text16))
							{
								bool? flag7 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary[text16]));
								if (!Information.IsNothing((object)flag7))
								{
									mission.KeepOnMissionWithoutTankersInPlace = flag7.Value;
								}
							}
						}
						else if (Operators.CompareString(text17, "TankerMissionList".ToUpperInvariant(), false) != 0)
						{
							if (Operators.CompareString(text17, "TankerMinNumber_Total".ToUpperInvariant(), false) == 0)
							{
								if (dictionary.ContainsKey(text16) && mission.TankerUsage == Mission.TankerMethod.Mission)
								{
									int tankerMinNumber_Total = Conversions.ToInteger(dictionary[text16]);
									mission.TankerMinNumber_Total = tankerMinNumber_Total;
								}
							}
							else if (Operators.CompareString(text17, "TankerMinNumber_Airborne".ToUpperInvariant(), false) != 0)
							{
								if (Operators.CompareString(text17, "TankerMinNumber_Station".ToUpperInvariant(), false) == 0)
								{
									if (dictionary.ContainsKey(text16) && mission.TankerUsage == Mission.TankerMethod.Mission)
									{
										int tankerMinNumber_Station = Conversions.ToInteger(dictionary[text16]);
										mission.TankerMinNumber_Station = tankerMinNumber_Station;
									}
								}
								else if (Operators.CompareString(text17, "MaxReceiversInQueuePerTanker_Airborne".ToUpperInvariant(), false) != 0)
								{
									if (Operators.CompareString(text17, "FuelQtyToStartLookingForTanker_Airborne".ToUpperInvariant(), false) != 0)
									{
										if (Operators.CompareString(text17, "TankerMaxDistance_Airborne".ToUpperInvariant(), false) != 0)
										{
											if (Operators.CompareString(text17, "TankerFollowsReceivers".ToUpperInvariant(), false) == 0 && dictionary.ContainsKey(text16))
											{
												mission.TankerFollowsReceivers = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary[text16])).Value;
											}
										}
										else if (dictionary.ContainsKey(text16))
										{
											int num = ((Operators.CompareString(Conversions.ToString(dictionary[text16]).ToLower(), "internal", false) == 0) ? int.MaxValue : Conversions.ToInteger(dictionary[text16]));
											int num2 = num;
											if (num2 < 100)
											{
												num = 50;
											}
											else if (num2 < 250)
											{
												num = 100;
											}
											else if (num2 < 500)
											{
												num = 250;
											}
											else if (num2 < 1000)
											{
												num = 500;
											}
											mission.TankerMaxDistance_Airborne = num;
										}
									}
									else if (dictionary.ContainsKey(text16))
									{
										int num3 = Conversions.ToInteger(dictionary[text16]);
										if (num3 > 0 && num3 < 100)
										{
											mission.FuelQtyToStartLookingForTanker_Airborne = num3;
										}
									}
								}
								else if (dictionary.ContainsKey(text16))
								{
									int maxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(dictionary[text16]);
									mission.MaxReceiversInQueuePerTanker_Airborne = maxReceiversInQueuePerTanker_Airborne;
								}
							}
							else if (dictionary.ContainsKey(text16) && mission.TankerUsage == Mission.TankerMethod.Mission)
							{
								int tankerMinNumber_Airborne = Conversions.ToInteger(dictionary[text16]);
								mission.TankerMinNumber_Airborne = tankerMinNumber_Airborne;
							}
						}
						else
						{
							if (!dictionary.ContainsKey(text16) || mission.TankerUsage != Mission.TankerMethod.Mission)
							{
								continue;
							}
							List<object> list = LuaUtility.ToArray(((LuaTable)dictionary[text16]).GetEnumerator());
							mission.TankerMissions.Clear();
							foreach (object item in list)
							{
								Mission mission2 = ValidateMissionBySceanrio(Conversions.ToString(RuntimeHelpers.GetObjectValue(item)), ScenarioContext);
								if (mission2 != null && mission2.MissionClass == Mission._MissionClass.Support)
								{
									mission.TankerMissions.Add(mission2);
								}
							}
						}
					}
					else if (dictionary.ContainsKey(text16))
					{
						bool? flag8 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary[text16]));
						if (!Information.IsNothing((object)flag8))
						{
							mission.LaunchMissionWithoutTankersInPlace = flag8.Value;
						}
					}
				}
				else if (dictionary.ContainsKey(text16))
				{
					Mission.TankerMethod result2 = Mission.TankerMethod.Automatic;
					if (Enum.TryParse<Mission.TankerMethod>(Conversions.ToString(dictionary[text16]), ignoreCase: true, out result2) && Enum.IsDefined(typeof(Mission.TankerMethod), result2))
					{
						mission.TankerUsage = result2;
					}
				}
			}
			checked
			{
				switch (mission.MissionClass)
				{
				case Mission._MissionClass.Strike:
				{
					Strike strike = (Strike)mission;
					string[] mission_Strike = Mission_Strike;
					for (int num15 = 0; num15 < mission_Strike.Length; num15++)
					{
						string text27 = mission_Strike[num15];
						text27 = text27.ToUpperInvariant();
						if (!dictionary.ContainsKey(text27))
						{
							continue;
						}
						object objectValue8 = RuntimeHelpers.GetObjectValue(dictionary[text27]);
						string text28 = text27;
						if (Operators.CompareString(text28, "EscortFlightSizeShooter".ToUpperInvariant(), false) == 0)
						{
							string text21 = Conversions.ToString(objectValue8);
							strike.Escort_FlightSize_Shooter = setFlightSize(ref text21);
						}
						else if (Operators.CompareString(text28, "EscortFlightSizeNonShooter".ToUpper(), false) != 0)
						{
							if (Operators.CompareString(text28, "EscortMaxNonShooter".ToUpperInvariant(), false) == 0)
							{
								string text21 = Conversions.ToString(objectValue8);
								strike.MaximumNumberOfAircraft_Escorts_NonShooter = setFlightQty(ref text21);
							}
							else if (Operators.CompareString(text28, "EscortMaxShooter".ToUpperInvariant(), false) == 0)
							{
								string text21 = Conversions.ToString(objectValue8);
								strike.MaximumNumberOfAircraft_Escorts_Shooter = setFlightQty(ref text21);
							}
							else if (Operators.CompareString(text28, "EscortMinShooter".ToUpperInvariant(), false) != 0)
							{
								if (Operators.CompareString(text28, "EscortMinNonShooter".ToUpperInvariant(), false) != 0)
								{
									if (Operators.CompareString(text28, "EscortResponseRadius".ToUpperInvariant(), false) == 0)
									{
										strike.Escort_ResponseRadius = Conversions.ToInteger(objectValue8);
									}
									else if (Operators.CompareString(text28, "EscortResponseRadiusSead".ToUpperInvariant(), false) == 0)
									{
										strike.Escort_ResponseRadius_SEAD = Conversions.ToInteger(objectValue8);
									}
									else if (Operators.CompareString(text28, "EscortUseFlightSize".ToUpperInvariant(), false) != 0)
									{
										if (Operators.CompareString(text28, "EscortGroupSize".ToUpperInvariant(), false) == 0)
										{
											string text21 = Conversions.ToString(objectValue8);
											strike.Escort_GroupSize = setGroupSize(ref text21);
										}
										else if (Operators.CompareString(text28, "EscortUseGroupSize".ToUpperInvariant(), false) != 0)
										{
											if (Operators.CompareString(text28, "EscortResponseRadiusSead".ToUpperInvariant(), false) == 0)
											{
												strike.Escort_ResponseRadius_SEAD = Conversions.ToInteger(objectValue8);
											}
											else if (Operators.CompareString(text28, "StrikeOneTimeOnly".ToUpperInvariant(), false) != 0)
											{
												if (Operators.CompareString(text28, "StrikeMinimumTrigger".ToUpperInvariant(), false) == 0)
												{
													string text21 = Conversions.ToString(objectValue8);
													Misc.PostureStance postureStance = setStance(ref text21);
													if (postureStance == Misc.PostureStance.Hostile || postureStance == Misc.PostureStance.Unfriendly || postureStance == Misc.PostureStance.Unknown)
													{
														strike.MinimumContactStanceToTrigger = postureStance;
													}
												}
												else if (Operators.CompareString(text28, "StrikeMax".ToUpperInvariant(), false) == 0)
												{
													string text21 = Conversions.ToString(objectValue8);
													strike.MaxFlightNumber_Strike = setFlightQty(ref text21);
												}
												else if (Operators.CompareString(text28, "StrikeMinAircraftReq".ToUpperInvariant(), false) != 0)
												{
													if (Operators.CompareString(text28, "StrikeFlightSize".ToUpperInvariant(), false) == 0)
													{
														string text21 = Conversions.ToString(objectValue8);
														strike.FlightSize = setFlightSize(ref text21);
													}
													else if (Operators.CompareString(text28, "StrikeUseFlightSize".ToUpperInvariant(), false) == 0)
													{
														strike.UseFlightSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue8)).Value;
													}
													else if (Operators.CompareString(text28, "StrikeGroupSize".ToUpperInvariant(), false) != 0)
													{
														if (Operators.CompareString(text28, "StrikeUseGroupSize".ToUpperInvariant(), false) != 0)
														{
															if (Operators.CompareString(text28, "StrikeAutoPlanner".ToUpperInvariant(), false) != 0 && Operators.CompareString(text28, "OffAxisAttack".ToUpperInvariant(), false) != 0)
															{
																if (Operators.CompareString(text28, "StrikePrePlan".ToUpperInvariant(), false) == 0)
																{
																	strike.RTB_When_Target_Destroyed = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue8)).Value;
																}
																else if (Operators.CompareString(text28, "StrikeRadarUsage".ToUpperInvariant(), false) == 0)
																{
																	string text21 = Conversions.ToString(objectValue8);
																	strike.RadarBehaviour = setRadarUse(ref text21);
																}
																else if (Operators.CompareString(text28, "strikeMinDist".ToUpperInvariant(), false) != 0 && Operators.CompareString(text28, "strikeMinDistAircraft".ToUpperInvariant(), false) != 0)
																{
																	if (Operators.CompareString(text28, "strikeMaxDist".ToUpperInvariant(), false) != 0 && Operators.CompareString(text28, "strikeMaxDistAircraft".ToUpperInvariant(), false) != 0)
																	{
																		if (Operators.CompareString(text28, "strikeMinDistShip".ToUpperInvariant(), false) != 0)
																		{
																			if (Operators.CompareString(text28, "strikeMaxDistShip".ToUpperInvariant(), false) != 0)
																			{
																				Mission._AircraftFormationType result29;
																				if (Operators.CompareString(text28, "strikeformationcruise".ToUpperInvariant(), false) == 0)
																				{
																					if (Enum.TryParse<Mission._AircraftFormationType>(Conversions.ToString(objectValue8), ignoreCase: true, out var result20) && Enum.IsDefined(typeof(Mission._AircraftFormationType), result20))
																					{
																						strike.Formation_Cruise = result20;
																					}
																				}
																				else if (Operators.CompareString(text28, "strikeformationattack".ToUpperInvariant(), false) == 0)
																				{
																					if (Enum.TryParse<Mission._AircraftFormationType>(Conversions.ToString(objectValue8), ignoreCase: true, out var result21) && Enum.IsDefined(typeof(Mission._AircraftFormationType), result21))
																					{
																						strike.Formation_Attack = result21;
																					}
																				}
																				else if (Operators.CompareString(text28, "escortformationcruise".ToUpperInvariant(), false) != 0)
																				{
																					if (Operators.CompareString(text28, "escortformationattack".ToUpperInvariant(), false) == 0)
																					{
																						if (Enum.TryParse<Mission._AircraftFormationType>(Conversions.ToString(objectValue8), ignoreCase: true, out var result22) && Enum.IsDefined(typeof(Mission._AircraftFormationType), result22))
																						{
																							strike.Escort_Formation_Attack = result22;
																						}
																					}
																					else if (Operators.CompareString(text28, "flightstoinvestigate".ToUpperInvariant(), false) != 0)
																					{
																						if (Operators.CompareString(text28, "flightstoengage".ToUpperInvariant(), false) != 0)
																						{
																							if (Operators.CompareString(text28, "wingmanengagedistance".ToUpperInvariant(), false) == 0)
																							{
																								int result23 = 0;
																								int.TryParse(Conversions.ToString(objectValue8), out result23);
																								strike.Escort_WingmanEngageDistance = result23;
																							}
																							else if (Operators.CompareString(text28, "boatstoinvestigate".ToUpperInvariant(), false) == 0)
																							{
																								if (Enum.TryParse<Mission._GroupQty>(Conversions.ToString(objectValue8), ignoreCase: true, out var result24) && Enum.IsDefined(typeof(Mission._GroupQty), result24))
																								{
																									strike.Escort_NumberOfBoats_Investigate = result24;
																								}
																							}
																							else if (Operators.CompareString(text28, "boatstoengage".ToUpperInvariant(), false) == 0)
																							{
																								if (Enum.TryParse<Mission._GroupQty>(Conversions.ToString(objectValue8), ignoreCase: true, out var result25) && Enum.IsDefined(typeof(Mission._GroupQty), result25))
																								{
																									strike.Escort_NumberOfBoats_Engage = result25;
																								}
																							}
																							else if (Operators.CompareString(text28, "groupmemberengagedistance".ToUpperInvariant(), false) == 0)
																							{
																								int result26 = 0;
																								int.TryParse(Conversions.ToString(objectValue8), out result26);
																								strike.Escort_GroupMemberEngageDistance = result26;
																							}
																							else if (Operators.CompareString(text28, "EscortTransitThrottle".ToUpperInvariant(), false) != 0)
																							{
																								if (Operators.CompareString(text28, "EscortTransitAltitude".ToUpperInvariant(), false) == 0)
																								{
																									object? objectValue9 = RuntimeHelpers.GetObjectValue(objectValue8);
																									ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset = null;
																									float? num16 = LuaUtility.QueryAltitudeObject(objectValue9, ref AltitudePreset);
																									if (num16.HasValue && (object)num16.GetType() == typeof(float))
																									{
																										strike.Escort_TransitAltitude = num16;
																									}
																								}
																								else if (Operators.CompareString(text28, "EscortTransitTerrainFollowing".ToUpperInvariant(), false) != 0)
																								{
																									if (Operators.CompareString(text28, "PrePlannedOnly".ToUpperInvariant(), false) == 0)
																									{
																										strike.RTB_When_Target_Destroyed = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue8)).Value;
																									}
																									else if (Operators.CompareString(text28, "FocusOnStrike".ToUpperInvariant(), false) != 0)
																									{
																										Mission._AttackMethod result28;
																										if (Operators.CompareString(text28, "AttackMethod".ToUpperInvariant(), false) != 0)
																										{
																											if (Operators.CompareString(text28, "SplitDistance".ToUpperInvariant(), false) == 0 && Enum.TryParse<Mission._SplitDistance>(Conversions.ToString(objectValue8), ignoreCase: true, out var result27) && Enum.IsDefined(typeof(Mission._SplitDistance), result27))
																											{
																												strike.SplitDistance = result27;
																											}
																										}
																										else if (Enum.TryParse<Mission._AttackMethod>(Conversions.ToString(objectValue8), ignoreCase: true, out result28) && Enum.IsDefined(typeof(Mission._AttackMethod), result28))
																										{
																											strike.AttackMethod = result28;
																										}
																									}
																									else
																									{
																										strike.Doctrine.SetElementState(Doctrine.DoctrineItem_E.StrikeMemberFocus, Convert.ToInt32(RuntimeHelpers.GetObjectValue(objectValue8)));
																									}
																								}
																								else
																								{
																									strike.Escort_TransitTerrainFollowing = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue8)).Value;
																								}
																							}
																							else
																							{
																								strike.Escort_TransitThrottle = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue8));
																							}
																						}
																						else
																						{
																							string text21 = Conversions.ToString(objectValue8);
																							strike.Escort_NumberOfFlights_Engage = setFlightQty(ref text21);
																						}
																					}
																					else
																					{
																						string text21 = Conversions.ToString(objectValue8);
																						strike.Escort_NumberOfFlights_Investigate = setFlightQty(ref text21);
																					}
																				}
																				else if (Enum.TryParse<Mission._AircraftFormationType>(Conversions.ToString(objectValue8), ignoreCase: true, out result29) && Enum.IsDefined(typeof(Mission._AircraftFormationType), result29))
																				{
																					strike.Escort_Formation_Cruise = result29;
																				}
																			}
																			else
																			{
																				strike.MaxResponseRadius_Ship = Conversions.ToInteger(objectValue8);
																			}
																		}
																		else
																		{
																			strike.MinResponseRadius_Ship = Conversions.ToInteger(objectValue8);
																		}
																	}
																	else
																	{
																		strike.MaxResponseRadius_Aircraft = Conversions.ToInteger(objectValue8);
																	}
																}
																else
																{
																	strike.MinResponseRadius_Aircraft = Conversions.ToInteger(objectValue8);
																}
															}
															else
															{
																strike.UsePlanner = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue8)).Value;
															}
														}
														else
														{
															strike.UseGroupSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue8)).Value;
														}
													}
													else
													{
														string text21 = Conversions.ToString(objectValue8);
														strike.GroupSize = setGroupSize(ref text21);
													}
												}
												else
												{
													string text21 = Conversions.ToString(objectValue8);
													strike.MinimumNumberOfAircraft = setFlightQty(ref text21);
												}
											}
											else
											{
												strike.OneTimeOnly = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue8)).Value;
											}
										}
										else
										{
											strike.UseGroupSizeHardLimit_Escort = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue8)).Value;
										}
									}
									else
									{
										strike.UseFlightSizeHardLimit_Escort = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue8)).Value;
									}
								}
								else
								{
									string text21 = Conversions.ToString(objectValue8);
									strike.MinimumNumberOfAircraft_Escorts_NonShooter = setFlightQty(ref text21);
								}
							}
							else
							{
								string text21 = Conversions.ToString(objectValue8);
								strike.MinimumNumberOfAircraft_Escorts_Shooter = setFlightQty(ref text21);
							}
						}
						else
						{
							string text21 = Conversions.ToString(objectValue8);
							strike.Escort_FlightSize_NonShooter = setFlightSize(ref text21);
						}
					}
					break;
				}
				case Mission._MissionClass.Patrol:
				{
					Patrol patrol = (Patrol)mission;
					string[] mission_Patrol = Mission_Patrol;
					_Closure$__16-0 closure$__16-2 = default(_Closure$__16-0);
					_Closure$__16-1 closure$__16-3 = default(_Closure$__16-1);
					for (int k = 0; k < mission_Patrol.Length; k++)
					{
						string text20 = mission_Patrol[k];
						text20 = text20.ToUpperInvariant();
						if (!dictionary.ContainsKey(text20))
						{
							continue;
						}
						object objectValue4 = RuntimeHelpers.GetObjectValue(dictionary[text20]);
						string text21 = text20;
						if (Operators.CompareString(text21, "OneThirdRule".ToUpperInvariant(), false) == 0)
						{
							patrol.OneThirdRule = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
							continue;
						}
						if (Operators.CompareString(text21, "StationGroupingType".ToUpperInvariant(), false) != 0)
						{
							if (Operators.CompareString(text21, "OnStation".ToUpperInvariant(), false) == 0)
							{
								patrol.MinimumNumberOnStation = Conversions.ToInteger(objectValue4);
							}
							else if (Operators.CompareString(text21, "CheckOPA".ToUpperInvariant(), false) == 0)
							{
								patrol.set_InvestigateOutsidePatrolArea(ScenarioContext, LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value);
							}
							else if (Operators.CompareString(text21, "CheckWWR".ToUpperInvariant(), false) != 0)
							{
								if (Operators.CompareString(text21, "ActiveEMCON".ToUpperInvariant(), false) != 0)
								{
									if (Operators.CompareString(text21, "LoopType".ToUpperInvariant(), false) == 0)
									{
										if (Enum.TryParse<Patrol.PatrolMovementStyle>(Conversions.ToString(objectValue4), ignoreCase: true, out var result3) && Enum.IsDefined(typeof(Patrol.PatrolMovementStyle), result3))
										{
											patrol.MovementStyle = result3;
										}
									}
									else if (Operators.CompareString(text21, "TransitThrottleAircraft".ToUpperInvariant(), false) != 0)
									{
										if (Operators.CompareString(text21, "TransitAltitudeAircraft".ToUpperInvariant(), false) == 0)
										{
											ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset2 = ActiveUnit_AI.AircraftAltitudePreset.None;
											float? num6 = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue4), ref AltitudePreset2);
											if (!num6.HasValue && AltitudePreset2.HasValue && AltitudePreset2.Value != ActiveUnit_AI.AircraftAltitudePreset.None)
											{
												patrol.TransitAltitude_Preset = AltitudePreset2;
												patrol.UseTransitAltitude_Preset = true;
											}
											else if ((object)num6.GetType() == typeof(float))
											{
												patrol.TransitAltitude_Aircraft = num6;
												patrol.UseTransitAltitude_Preset = false;
												patrol.TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
											}
										}
										else if (Operators.CompareString(text21, "TransitTerrainFollowingAircraft".ToUpperInvariant(), false) == 0)
										{
											patrol.TransitTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
										}
										else if (Operators.CompareString(text21, "StationThrottleAircraft".ToUpperInvariant(), false) == 0)
										{
											patrol.StationThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4));
										}
										else if (Operators.CompareString(text21, "StationAltitudeAircraft".ToUpperInvariant(), false) != 0)
										{
											if (Operators.CompareString(text21, "StationTerrainFollowingAircraft".ToUpperInvariant(), false) != 0)
											{
												if (Operators.CompareString(text21, "AttackThrottleAircraft".ToUpperInvariant(), false) == 0)
												{
													patrol.AttackThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4));
												}
												else if (Operators.CompareString(text21, "AttackAltitudeAircraft".ToUpperInvariant(), false) != 0)
												{
													if (Operators.CompareString(text21, "AttackTerrainFollowingAircraft".ToUpperInvariant(), false) == 0)
													{
														patrol.AttackTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
													}
													else if (Operators.CompareString(text21, "UseTransitAltitudePreset".ToUpperInvariant(), false) == 0)
													{
														patrol.UseTransitAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
													}
													else if (Operators.CompareString(text21, "UseStationAltitudePreset".ToUpperInvariant(), false) == 0)
													{
														patrol.UseStationAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
													}
													else if (Operators.CompareString(text21, "UseAttackAltitudePreset".ToUpperInvariant(), false) != 0)
													{
														if (Operators.CompareString(text21, "TransitAltitudePreset".ToUpperInvariant(), false) != 0)
														{
															if (Operators.CompareString(text21, "StationAltitudePreset".ToUpperInvariant(), false) != 0)
															{
																if (Operators.CompareString(text21, "AttackAltitudePreset".ToUpperInvariant(), false) == 0)
																{
																	patrol.AttackAltitude_Preset = LuaUtility.QueryAltitudePresetObject(Conversions.ToString(objectValue4)).Value;
																	if (patrol.AttackAltitude_Preset.HasValue && patrol.AttackAltitude_Preset.Value != ActiveUnit_AI.AircraftAltitudePreset.None)
																	{
																		patrol.AttackAltitude_Aircraft = null;
																		patrol.UseAttackAltitude_Preset = true;
																	}
																	else
																	{
																		patrol.AttackAltitude_Aircraft = null;
																		patrol.AttackAltitude_Preset = null;
																		patrol.UseAttackAltitude_Preset = null;
																	}
																}
																else if (Operators.CompareString(text21, "AttackDistanceAircraft".ToUpperInvariant(), false) == 0)
																{
																	int result4 = 0;
																	int.TryParse(Conversions.ToString(objectValue4), out result4);
																	patrol.AttackDistance_Aircraft = result4;
																}
																else if (Operators.CompareString(text21, "TransitThrottleSubmarine".ToUpperInvariant(), false) == 0)
																{
																	patrol.TransitThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4)).Value;
																}
																else if (Operators.CompareString(text21, "TransitDepthSubmarine".ToUpperInvariant(), false) != 0)
																{
																	if (Operators.CompareString(text21, "StationThrottleSubmarine".ToUpperInvariant(), false) == 0)
																	{
																		patrol.StationThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4)).Value;
																	}
																	else if (Operators.CompareString(text21, "StationDepthSubmarine".ToUpperInvariant(), false) == 0)
																	{
																		patrol.StationDepth_Submarine = LuaUtility.QueryDepthObject(RuntimeHelpers.GetObjectValue(objectValue4));
																		patrol.UseStationDepth_Submarine_Preset = false;
																		patrol.StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
																	}
																	else if (Operators.CompareString(text21, "AttackThrottleSubmarine".ToUpperInvariant(), false) != 0)
																	{
																		if (Operators.CompareString(text21, "AttackDepthSubmarine".ToUpperInvariant(), false) == 0)
																		{
																			patrol.AttackDepth_Submarine = LuaUtility.QueryDepthObject(RuntimeHelpers.GetObjectValue(objectValue4));
																			patrol.UseAttackDepth_Submarine_Preset = false;
																			patrol.AttackDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
																		}
																		else if (Operators.CompareString(text21, "StationDepthSubmarinePreset".ToUpperInvariant(), false) != 0)
																		{
																			if (Operators.CompareString(text21, "AttackDepthSubmarinePreset".ToUpperInvariant(), false) == 0)
																			{
																				patrol.AttackDepth_Submarine_Preset = LuaUtility.QueryDepthPresetObject(Conversions.ToString(objectValue4)).Value;
																			}
																			else if (Operators.CompareString(text21, "TransitDepthSubmarinePreset".ToUpperInvariant(), false) == 0)
																			{
																				patrol.TransitDepth_Submarine_Preset = LuaUtility.QueryDepthPresetObject(Conversions.ToString(objectValue4)).Value;
																			}
																			else if (Operators.CompareString(text21, "useAttackDepthSubmarinePreset".ToUpperInvariant(), false) == 0)
																			{
																				patrol.UseAttackDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
																			}
																			else if (Operators.CompareString(text21, "useTransitDepthSubmarinePreset".ToUpperInvariant(), false) != 0)
																			{
																				if (Operators.CompareString(text21, "useStationDepthSubmarinePreset".ToUpperInvariant(), false) == 0)
																				{
																					patrol.UseStationDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
																				}
																				else if (Operators.CompareString(text21, "AttackDistanceSubmarine".ToUpperInvariant(), false) == 0)
																				{
																					int result5 = 0;
																					int.TryParse(Conversions.ToString(objectValue4), out result5);
																					patrol.AttackDistance_Submarine = result5;
																				}
																				else if (Operators.CompareString(text21, "TransitThrottleShip".ToUpperInvariant(), false) != 0)
																				{
																					if (Operators.CompareString(text21, "StationThrottleShip".ToUpperInvariant(), false) == 0)
																					{
																						patrol.StationThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4)).Value;
																					}
																					else if (Operators.CompareString(text21, "AttackThrottleShip".ToUpperInvariant(), false) != 0)
																					{
																						if (Operators.CompareString(text21, "AttackDistanceShip".ToUpperInvariant(), false) == 0)
																						{
																							int result6 = 0;
																							int.TryParse(Conversions.ToString(objectValue4), out result6);
																							patrol.AttackDistance_Ship = result6;
																						}
																						else if (Operators.CompareString(text21, "GroupSize".ToUpperInvariant(), false) != 0)
																						{
																							if (Operators.CompareString(text21, "FlightSize".ToUpperInvariant(), false) != 0)
																							{
																								if (Operators.CompareString(text21, "MinAircraftReq".ToUpperInvariant(), false) == 0)
																								{
																									string _value = Conversions.ToString(objectValue4);
																									patrol.MinimumNumberOfAircraft = setFlightQty(ref _value);
																								}
																								else if (Operators.CompareString(text21, "UseFlightSize".ToUpperInvariant(), false) != 0)
																								{
																									if (Operators.CompareString(text21, "UseGroupSize".ToUpperInvariant(), false) != 0)
																									{
																										if (Operators.CompareString(text21, "PatrolZone".ToUpperInvariant(), false) == 0)
																										{
																											List<ReferencePoint> list4 = new List<ReferencePoint>();
																											List<object> list5 = LuaUtility.ToArray(((LuaTable)dictionary["PATROLZONE"]).GetEnumerator());
																											using (List<object>.Enumerator enumerator3 = list5.GetEnumerator())
																											{
																												while (enumerator3.MoveNext())
																												{
																													closure$__16-2 = new _Closure$__16-0(closure$__16-2);
																													closure$__16-2.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator3.Current);
																													ReferencePoint referencePoint2 = null;
																													if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-2._Lambda$__0)))
																													{
																														referencePoint2 = side.RefPoints.First(closure$__16-2._Lambda$__1);
																													}
																													else if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-2._Lambda$__2)))
																													{
																														referencePoint2 = side.RefPoints.First(closure$__16-2._Lambda$__3);
																													}
																													else if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-2._Lambda$__4)))
																													{
																														referencePoint2 = side.RefPoints.First(closure$__16-2._Lambda$__5);
																													}
																													else if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-2._Lambda$__6)))
																													{
																														referencePoint2 = side.RefPoints.First(closure$__16-2._Lambda$__7);
																													}
																													if (!Information.IsNothing((object)referencePoint2))
																													{
																														list4.Add(referencePoint2);
																													}
																												}
																											}
																											patrol.PatrolArea = list4;
																										}
																										else if (Operators.CompareString(text21, "ProsecutionZone".ToUpperInvariant(), false) == 0)
																										{
																											List<ReferencePoint> list6 = new List<ReferencePoint>();
																											List<object> list7 = LuaUtility.ToArray(((LuaTable)dictionary["ProsecutionZone".ToUpper()]).GetEnumerator());
																											using (List<object>.Enumerator enumerator4 = list7.GetEnumerator())
																											{
																												while (enumerator4.MoveNext())
																												{
																													closure$__16-3 = new _Closure$__16-1(closure$__16-3);
																													closure$__16-3.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator4.Current);
																													ReferencePoint referencePoint3 = null;
																													if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-3._Lambda$__8)))
																													{
																														if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-3._Lambda$__10)))
																														{
																															referencePoint3 = side.RefPoints.First(closure$__16-3._Lambda$__11);
																														}
																														else if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-3._Lambda$__12)))
																														{
																															referencePoint3 = side.RefPoints.First(closure$__16-3._Lambda$__13);
																														}
																														else if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-3._Lambda$__14)))
																														{
																															referencePoint3 = side.RefPoints.First(closure$__16-3._Lambda$__15);
																														}
																													}
																													else
																													{
																														referencePoint3 = side.RefPoints.First(closure$__16-3._Lambda$__9);
																													}
																													if (!Information.IsNothing((object)referencePoint3))
																													{
																														list6.Add(referencePoint3);
																													}
																												}
																											}
																											patrol.ProsecutionArea = list6;
																										}
																										else if (Operators.CompareString(text21, "transitthrottlefacility".ToUpperInvariant(), false) != 0)
																										{
																											if (Operators.CompareString(text21, "stationthrottlefacility".ToUpperInvariant(), false) != 0)
																											{
																												Mission._AircraftFormationType result12;
																												if (Operators.CompareString(text21, "formationcruise".ToUpperInvariant(), false) == 0)
																												{
																													if (Enum.TryParse<Mission._AircraftFormationType>(Conversions.ToString(objectValue4), ignoreCase: true, out var result7) && Enum.IsDefined(typeof(Mission._AircraftFormationType), result7))
																													{
																														patrol.Formation_Cruise = result7;
																													}
																												}
																												else if (Operators.CompareString(text21, "formationattack".ToUpperInvariant(), false) != 0)
																												{
																													if (Operators.CompareString(text21, "flightstoinvestigate".ToUpperInvariant(), false) == 0)
																													{
																														string _value = Conversions.ToString(objectValue4);
																														patrol.NumberOfFlights_Investigate = setFlightQty(ref _value);
																													}
																													else if (Operators.CompareString(text21, "flightstoengage".ToUpperInvariant(), false) != 0)
																													{
																														Mission._GroupQty result11;
																														if (Operators.CompareString(text21, "wingmanengagedistance".ToUpperInvariant(), false) == 0)
																														{
																															int result8 = 0;
																															int.TryParse(Conversions.ToString(objectValue4), out result8);
																															patrol.WingmanEngageDistance = result8;
																														}
																														else if (Operators.CompareString(text21, "boatstoinvestigate".ToUpperInvariant(), false) != 0)
																														{
																															if (Operators.CompareString(text21, "boatstoengage".ToUpperInvariant(), false) == 0)
																															{
																																if (Enum.TryParse<Mission._GroupQty>(Conversions.ToString(objectValue4), ignoreCase: true, out var result9) && Enum.IsDefined(typeof(Mission._GroupQty), result9))
																																{
																																	patrol.NumberOfBoats_Engage = result9;
																																}
																															}
																															else if (Operators.CompareString(text21, "groupmemberengagedistance".ToUpperInvariant(), false) == 0)
																															{
																																int result10 = 0;
																																int.TryParse(Conversions.ToString(objectValue4), out result10);
																																patrol.GroupMemberEngageDistance = result10;
																															}
																															else if (Operators.CompareString(text21, "SprintDrift".ToUpperInvariant(), false) == 0)
																															{
																																patrol.SprintAndDrift = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
																															}
																															else if (Operators.CompareString(text21, "AvoidCavitation".ToUpperInvariant(), false) == 0)
																															{
																																patrol.AvoidCavitation = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
																															}
																														}
																														else if (Enum.TryParse<Mission._GroupQty>(Conversions.ToString(objectValue4), ignoreCase: true, out result11) && Enum.IsDefined(typeof(Mission._GroupQty), result11))
																														{
																															patrol.NumberOfBoats_Investigate = result11;
																														}
																													}
																													else
																													{
																														string _value = Conversions.ToString(objectValue4);
																														patrol.NumberOfFlights_Engage = setFlightQty(ref _value);
																													}
																												}
																												else if (Enum.TryParse<Mission._AircraftFormationType>(Conversions.ToString(objectValue4), ignoreCase: true, out result12) && Enum.IsDefined(typeof(Mission._AircraftFormationType), result12))
																												{
																													patrol.Formation_Attack = result12;
																												}
																											}
																											else
																											{
																												patrol.StationThrottle_Facility = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4)).Value;
																											}
																										}
																										else
																										{
																											patrol.TransitThrottle_Facility = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4)).Value;
																										}
																									}
																									else
																									{
																										patrol.UseGroupSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
																									}
																								}
																								else
																								{
																									patrol.UseFlightSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
																								}
																							}
																							else
																							{
																								string _value = Conversions.ToString(objectValue4);
																								patrol.FlightSize = setFlightSize(ref _value);
																							}
																						}
																						else
																						{
																							string _value = Conversions.ToString(objectValue4);
																							patrol.GroupSize = setGroupSize(ref _value);
																						}
																					}
																					else
																					{
																						patrol.AttackThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4));
																					}
																				}
																				else
																				{
																					patrol.TransitThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4)).Value;
																				}
																			}
																			else
																			{
																				patrol.UseTransitDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
																			}
																		}
																		else
																		{
																			patrol.StationDepth_Submarine_Preset = LuaUtility.QueryDepthPresetObject(Conversions.ToString(objectValue4)).Value;
																		}
																	}
																	else
																	{
																		patrol.AttackThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4));
																	}
																}
																else
																{
																	patrol.TransitDepth_Submarine = LuaUtility.QueryDepthObject(RuntimeHelpers.GetObjectValue(objectValue4));
																	patrol.UseTransitDepth_Submarine_Preset = false;
																	patrol.TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
																}
															}
															else
															{
																patrol.StationAltitude_Preset = LuaUtility.QueryAltitudePresetObject(Conversions.ToString(objectValue4)).Value;
																if (patrol.StationAltitude_Preset.HasValue && patrol.StationAltitude_Preset.Value != ActiveUnit_AI.AircraftAltitudePreset.None)
																{
																	patrol.StationAltitude_Aircraft = null;
																	patrol.UseStationAltitude_Preset = true;
																}
																else
																{
																	patrol.StationAltitude_Aircraft = null;
																	patrol.StationAltitude_Preset = null;
																	patrol.UseStationAltitude_Preset = null;
																}
															}
														}
														else
														{
															patrol.TransitAltitude_Preset = LuaUtility.QueryAltitudePresetObject(Conversions.ToString(objectValue4)).Value;
															if (patrol.TransitAltitude_Preset.HasValue && patrol.TransitAltitude_Preset.Value != ActiveUnit_AI.AircraftAltitudePreset.None)
															{
																patrol.TransitAltitude_Aircraft = null;
																patrol.UseTransitAltitude_Preset = true;
															}
															else
															{
																patrol.TransitAltitude_Aircraft = null;
																patrol.TransitAltitude_Preset = null;
																patrol.UseTransitAltitude_Preset = null;
															}
														}
													}
													else
													{
														patrol.UseAttackAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
													}
												}
												else
												{
													ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset3 = ActiveUnit_AI.AircraftAltitudePreset.None;
													float? num7 = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue4), ref AltitudePreset3);
													if (!num7.HasValue && AltitudePreset3.HasValue && AltitudePreset3.Value != ActiveUnit_AI.AircraftAltitudePreset.None)
													{
														patrol.AttackAltitude_Preset = AltitudePreset3;
														patrol.UseAttackAltitude_Preset = true;
													}
													else if ((object)num7.GetType() == typeof(float))
													{
														patrol.AttackAltitude_Aircraft = num7;
														patrol.UseAttackAltitude_Preset = false;
														patrol.AttackAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
													}
												}
											}
											else
											{
												patrol.StationTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
											}
										}
										else
										{
											ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset4 = ActiveUnit_AI.AircraftAltitudePreset.None;
											float? num8 = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue4), ref AltitudePreset4);
											if (!num8.HasValue && AltitudePreset4.HasValue && AltitudePreset4.Value != ActiveUnit_AI.AircraftAltitudePreset.None)
											{
												patrol.StationAltitude_Preset = AltitudePreset4;
												patrol.UseStationAltitude_Preset = true;
											}
											else if ((object)num8.GetType() == typeof(float))
											{
												patrol.StationAltitude_Aircraft = num8;
												patrol.UseStationAltitude_Preset = false;
												patrol.StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
											}
										}
									}
									else
									{
										patrol.TransitThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4));
									}
								}
								else
								{
									patrol.ActiveEMCONOnlyInPatrolOrProsecutionArea = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
								}
							}
							else
							{
								patrol.set_InvestigateWithinWeaponRange(ScenarioContext, LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value);
							}
							continue;
						}
						Mission.OneThirdGroupingType result13 = Mission.OneThirdGroupingType.ByLoadout;
						bool flag9 = false;
						foreach (ActiveUnit value5 in patrol.UnitsAssignedToMission.Values)
						{
							if (value5.IsAircraft)
							{
								flag9 = true;
								break;
							}
						}
						if (Enum.TryParse<Mission.OneThirdGroupingType>(Conversions.ToString(objectValue4), ignoreCase: true, out result13) && Enum.IsDefined(typeof(Mission.OneThirdGroupingType), result13))
						{
							if (result13 == Mission.OneThirdGroupingType.ByLoadout && !flag9)
							{
								result13 = Mission.OneThirdGroupingType.ByUnitClass;
							}
							patrol.OneThirdGrouping = result13;
						}
					}
					break;
				}
				case Mission._MissionClass.Support:
				{
					SupportMission supportMission = (SupportMission)mission;
					string[] mission_Support = Mission_Support;
					_Closure$__16-2 closure$__16-5 = default(_Closure$__16-2);
					for (int m = 0; m < mission_Support.Length; m++)
					{
						string text24 = mission_Support[m];
						text24 = text24.ToUpperInvariant();
						if (!dictionary.ContainsKey(text24))
						{
							continue;
						}
						object objectValue6 = RuntimeHelpers.GetObjectValue(dictionary[text24]);
						string _value = text24;
						if (Operators.CompareString(_value, "LoopType".ToUpperInvariant(), false) == 0)
						{
							SupportMission.SupportMissionNavigationLoopType result15 = SupportMission.SupportMissionNavigationLoopType.ContinousLoop;
							if (Enum.TryParse<SupportMission.SupportMissionNavigationLoopType>(Conversions.ToString(objectValue6), ignoreCase: true, out result15) && Enum.IsDefined(typeof(SupportMission.SupportMissionNavigationLoopType), result15))
							{
								supportMission.NavigationLoopType = result15;
							}
						}
						else if (Operators.CompareString(_value, "OneTimeOnly".ToUpperInvariant(), false) == 0)
						{
							supportMission.OneTimeOnly = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
						}
						else if (Operators.CompareString(_value, "OneThirdRule".ToUpperInvariant(), false) != 0)
						{
							if (Operators.CompareString(_value, "StationGroupingType".ToUpperInvariant(), false) == 0)
							{
								Mission.OneThirdGroupingType result16 = Mission.OneThirdGroupingType.ByLoadout;
								bool flag10 = false;
								foreach (ActiveUnit value6 in supportMission.UnitsAssignedToMission.Values)
								{
									if (value6.IsAircraft)
									{
										flag10 = true;
										break;
									}
								}
								if (Enum.TryParse<Mission.OneThirdGroupingType>(Conversions.ToString(objectValue6), ignoreCase: true, out result16) && Enum.IsDefined(typeof(Mission.OneThirdGroupingType), result16))
								{
									if (result16 == Mission.OneThirdGroupingType.ByLoadout && !flag10)
									{
										result16 = Mission.OneThirdGroupingType.ByUnitClass;
									}
									supportMission.OneThirdGrouping = result16;
								}
							}
							else if (Operators.CompareString(_value, "ActiveEMCON".ToUpperInvariant(), false) == 0)
							{
								supportMission.ActiveEMCONOnlyOnStation = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
							}
							else if (Operators.CompareString(_value, "TankerOneTime".ToUpperInvariant(), false) != 0)
							{
								if (Operators.CompareString(_value, "TankerMaxReceivers".ToUpperInvariant(), false) == 0)
								{
									supportMission.A2AR_MaxNumberOfReceiversPerTanker = Conversions.ToInteger(objectValue6);
								}
								else if (Operators.CompareString(_value, "OnStation".ToUpperInvariant(), false) == 0)
								{
									supportMission.MinimumNumberOnStation = Conversions.ToInteger(objectValue6);
								}
								else if (Operators.CompareString(_value, "TransitThrottleAircraft".ToUpperInvariant(), false) != 0)
								{
									if (Operators.CompareString(_value, "TransitAltitudeAircraft".ToUpperInvariant(), false) != 0)
									{
										if (Operators.CompareString(_value, "TransitTerrainFollowingAircraft".ToUpperInvariant(), false) != 0)
										{
											if (Operators.CompareString(_value, "StationThrottleAircraft".ToUpperInvariant(), false) != 0)
											{
												if (Operators.CompareString(_value, "StationAltitudeAircraft".ToUpperInvariant(), false) != 0)
												{
													if (Operators.CompareString(_value, "StationTerrainFollowingAircraft".ToUpperInvariant(), false) == 0)
													{
														supportMission.StationTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
													}
													else if (Operators.CompareString(_value, "UseTransitAltitudePreset".ToUpperInvariant(), false) == 0)
													{
														supportMission.UseTransitAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
													}
													else if (Operators.CompareString(_value, "TransitAltitudePreset".ToUpperInvariant(), false) == 0)
													{
														supportMission.TransitAltitude_Preset = LuaUtility.QueryAltitudePresetObject(Conversions.ToString(objectValue6)).Value;
													}
													else if (Operators.CompareString(_value, "UseStationAltitudePreset".ToUpperInvariant(), false) != 0)
													{
														if (Operators.CompareString(_value, "StationAltitudePreset".ToUpperInvariant(), false) != 0)
														{
															if (Operators.CompareString(_value, "TransitThrottleSubmarine".ToUpperInvariant(), false) != 0)
															{
																if (Operators.CompareString(_value, "TransitDepthSubmarine".ToUpperInvariant(), false) == 0)
																{
																	supportMission.TransitDepth_Submarine = LuaUtility.QueryDepthObject(RuntimeHelpers.GetObjectValue(objectValue6));
																	supportMission.UseTransitDepth_Submarine_Preset = false;
																	supportMission.TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
																}
																else if (Operators.CompareString(_value, "StationThrottleSubmarine".ToUpperInvariant(), false) == 0)
																{
																	supportMission.StationThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue6)).Value;
																}
																else if (Operators.CompareString(_value, "StationDepthSubmarine".ToUpperInvariant(), false) != 0)
																{
																	if (Operators.CompareString(_value, "StationDepthSubmarinePreset".ToUpperInvariant(), false) != 0)
																	{
																		if (Operators.CompareString(_value, "TransitDepthSubmarinePreset".ToUpperInvariant(), false) == 0)
																		{
																			supportMission.TransitDepth_Submarine_Preset = LuaUtility.QueryDepthPresetObject(Conversions.ToString(objectValue6)).Value;
																		}
																		else if (Operators.CompareString(_value, "UseStationDepthSubmarinePreset".ToUpperInvariant(), false) == 0)
																		{
																			supportMission.UseStationDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
																		}
																		else if (Operators.CompareString(_value, "UseTransitDepthSubmarinePreset".ToUpperInvariant(), false) != 0)
																		{
																			if (Operators.CompareString(_value, "TransitThrottleShip".ToUpperInvariant(), false) != 0)
																			{
																				if (Operators.CompareString(_value, "StationThrottleShip".ToUpperInvariant(), false) != 0)
																				{
																					if (Operators.CompareString(_value, "GroupSize".ToUpperInvariant(), false) != 0)
																					{
																						if (Operators.CompareString(_value, "FlightSize".ToUpperInvariant(), false) != 0)
																						{
																							if (Operators.CompareString(_value, "MinAircraftReq".ToUpperInvariant(), false) != 0)
																							{
																								if (Operators.CompareString(_value, "UseFlightSize".ToUpperInvariant(), false) == 0)
																								{
																									supportMission.UseFlightSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
																								}
																								else if (Operators.CompareString(_value, "UseGroupSize".ToUpperInvariant(), false) != 0)
																								{
																									if (Operators.CompareString(_value, "Zone".ToUpperInvariant(), false) != 0 && Operators.CompareString(_value, "Course".ToUpperInvariant(), false) != 0)
																									{
																										switch (_value)
																										{
																										case "stationthrottleshipfacility":
																											supportMission.StationThrottle_Facility = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue6)).Value;
																											break;
																										case "ccenable":
																											supportMission.ContinousCoverage_Enable = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
																											break;
																										case "ccflightgenmethod":
																										{
																											Mission._ContinousCoverageMethod result18 = Mission._ContinousCoverageMethod.Dynamic;
																											if (Enum.TryParse<Mission._ContinousCoverageMethod>(Conversions.ToString(objectValue6), ignoreCase: true, out result18) && Enum.IsDefined(typeof(Mission._ContinousCoverageMethod), result18))
																											{
																												supportMission.ContinousCoverage_QRAFlightGenerationMethod = result18;
																											}
																											break;
																										}
																										case "ccstationtime":
																										{
																											Mission._ContinousCoverageStationTime result19 = Mission._ContinousCoverageStationTime.min_15;
																											if (Enum.TryParse<Mission._ContinousCoverageStationTime>(Conversions.ToString(objectValue6), ignoreCase: true, out result19) && Enum.IsDefined(typeof(Mission._ContinousCoverageStationTime), result19))
																											{
																												supportMission.ContinousCoverage_StationTime = result19;
																											}
																											break;
																										}
																										case "ccoverlap":
																										{
																											Mission._ContinousCoverageOverlap result17 = Mission._ContinousCoverageOverlap.None;
																											if (Enum.TryParse<Mission._ContinousCoverageOverlap>(Conversions.ToString(objectValue6), ignoreCase: true, out result17) && Enum.IsDefined(typeof(Mission._ContinousCoverageOverlap), result17))
																											{
																												supportMission.ContinousCoverage_Overlap = result17;
																											}
																											break;
																										}
																										case "ccallowqra":
																											supportMission.ContinousCoverage_QRAEnable = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
																											break;
																										case "transitthrottlefacility":
																											supportMission.TransitThrottle_Facility = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue6)).Value;
																											break;
																										}
																										continue;
																									}
																									List<ReferencePoint> list10 = new List<ReferencePoint>();
																									List<object> list11 = LuaUtility.ToArray(((LuaTable)dictionary["ZONE"]).GetEnumerator());
																									using (List<object>.Enumerator enumerator8 = list11.GetEnumerator())
																									{
																										while (enumerator8.MoveNext())
																										{
																											closure$__16-5 = new _Closure$__16-2(closure$__16-5);
																											closure$__16-5.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator8.Current);
																											ReferencePoint referencePoint5 = null;
																											if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-5._Lambda$__16)))
																											{
																												if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-5._Lambda$__18)))
																												{
																													referencePoint5 = side.RefPoints.First(closure$__16-5._Lambda$__19);
																												}
																												else if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-5._Lambda$__20)))
																												{
																													referencePoint5 = side.RefPoints.First(closure$__16-5._Lambda$__21);
																												}
																												else if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-5._Lambda$__22)))
																												{
																													referencePoint5 = side.RefPoints.First(closure$__16-5._Lambda$__23);
																												}
																											}
																											else
																											{
																												referencePoint5 = side.RefPoints.First(closure$__16-5._Lambda$__17);
																											}
																											if (!Information.IsNothing((object)referencePoint5))
																											{
																												list10.Add(referencePoint5);
																											}
																										}
																									}
																									supportMission.NavigationCourse = list10;
																								}
																								else
																								{
																									supportMission.UseGroupSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
																								}
																							}
																							else
																							{
																								string _value2 = Conversions.ToString(objectValue6);
																								supportMission.MinimumNumberOfAircraft = setFlightQty(ref _value2);
																							}
																						}
																						else
																						{
																							string _value2 = Conversions.ToString(objectValue6);
																							supportMission.FlightSize = setFlightSize(ref _value2);
																						}
																					}
																					else
																					{
																						string _value2 = Conversions.ToString(objectValue6);
																						supportMission.GroupSize = setGroupSize(ref _value2);
																					}
																				}
																				else
																				{
																					supportMission.StationThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue6)).Value;
																				}
																			}
																			else
																			{
																				supportMission.TransitThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue6)).Value;
																			}
																		}
																		else
																		{
																			supportMission.UseTransitDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
																		}
																	}
																	else
																	{
																		supportMission.StationDepth_Submarine_Preset = LuaUtility.QueryDepthPresetObject(Conversions.ToString(objectValue6)).Value;
																	}
																}
																else
																{
																	supportMission.StationDepth_Submarine = LuaUtility.QueryDepthObject(RuntimeHelpers.GetObjectValue(objectValue6));
																	supportMission.UseStationDepth_Submarine_Preset = false;
																	supportMission.StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
																}
															}
															else
															{
																supportMission.TransitThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue6)).Value;
															}
														}
														else
														{
															supportMission.StationAltitude_Preset = LuaUtility.QueryAltitudePresetObject(Conversions.ToString(objectValue6)).Value;
														}
													}
													else
													{
														supportMission.UseStationAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
													}
													continue;
												}
												ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset7 = ActiveUnit_AI.AircraftAltitudePreset.None;
												float? num11 = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue6), ref AltitudePreset7);
												if (num11.HasValue)
												{
													if ((object)num11.GetType() == typeof(float))
													{
														supportMission.StationAltitude_Aircraft = num11.Value;
														supportMission.UseStationAltitude_Preset = false;
														supportMission.StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
													}
												}
												else
												{
													supportMission.StationAltitude_Preset = AltitudePreset7;
													supportMission.UseStationAltitude_Preset = true;
												}
											}
											else
											{
												supportMission.StationThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue6));
											}
										}
										else
										{
											supportMission.TransitTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
										}
										continue;
									}
									ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset8 = ActiveUnit_AI.AircraftAltitudePreset.None;
									float? num12 = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue6), ref AltitudePreset8);
									if (num12.HasValue)
									{
										if ((object)num12.GetType() == typeof(float))
										{
											supportMission.TransitAltitude_Aircraft = num12.Value;
											supportMission.UseTransitAltitude_Preset = false;
											supportMission.TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
										}
									}
									else
									{
										supportMission.TransitAltitude_Preset = AltitudePreset8;
										supportMission.UseTransitAltitude_Preset = true;
									}
								}
								else
								{
									supportMission.TransitThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue6));
								}
							}
							else
							{
								supportMission.A2AR_OneTankingCycleOnly = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
							}
						}
						else
						{
							supportMission.OneThirdRule = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
						}
					}
					break;
				}
				case Mission._MissionClass.Ferry:
				{
					FerryMission ferryMission = (FerryMission)mission;
					string[] mission_Ferry = Mission_Ferry;
					for (int num17 = 0; num17 < mission_Ferry.Length; num17++)
					{
						string text29 = mission_Ferry[num17];
						text29 = text29.ToUpperInvariant();
						if (!dictionary.ContainsKey(text29))
						{
							continue;
						}
						object objectValue10 = RuntimeHelpers.GetObjectValue(dictionary[text29]);
						string _value2 = text29;
						if (Operators.CompareString(_value2, "FerryBehavior".ToUpperInvariant(), false) != 0)
						{
							if (Operators.CompareString(_value2, "FerryThrottleAircraft".ToUpperInvariant(), false) != 0)
							{
								if (Operators.CompareString(_value2, "FerryAltitudeAircraft".ToUpperInvariant(), false) == 0)
								{
									object? objectValue11 = RuntimeHelpers.GetObjectValue(objectValue10);
									ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset = null;
									float? num18 = LuaUtility.QueryAltitudeObject(objectValue11, ref AltitudePreset);
									if (num18.HasValue && (object)num18.GetType() == typeof(float))
									{
										ferryMission.FerryAltitude_Aircraft = num18.Value;
									}
								}
								else if (Operators.CompareString(_value2, "FerryTerrainFollowingAircraft".ToUpperInvariant(), false) != 0)
								{
									if (Operators.CompareString(_value2, "FlightSize".ToUpperInvariant(), false) != 0)
									{
										if (Operators.CompareString(_value2, "MinAircraftReq".ToUpperInvariant(), false) != 0)
										{
											if (Operators.CompareString(_value2, "UseFlightSize".ToUpperInvariant(), false) == 0)
											{
												ferryMission.UseFlightSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue10)).Value;
											}
										}
										else
										{
											string text26 = Conversions.ToString(objectValue10);
											ferryMission.MinimumNumberOfAircraft = setFlightQty(ref text26);
										}
									}
									else
									{
										string text26 = Conversions.ToString(objectValue10);
										ferryMission.FlightSize = setFlightSize(ref text26);
									}
								}
								else
								{
									ferryMission.FerryTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue10)).Value;
								}
							}
							else
							{
								ferryMission.FerryThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue10));
							}
						}
						else
						{
							FerryMission.FerryMissionBehavior result30 = FerryMission.FerryMissionBehavior.OneWay;
							if (Enum.TryParse<FerryMission.FerryMissionBehavior>(Conversions.ToString(objectValue10), ignoreCase: true, out result30) && Enum.IsDefined(typeof(FerryMission.FerryMissionBehavior), result30))
							{
								ferryMission.Behavior = result30;
							}
						}
					}
					break;
				}
				case Mission._MissionClass.Mining:
				{
					MiningMission miningMission = (MiningMission)mission;
					string[] mission_Mining = Mission_Mining;
					_Closure$__16-3 closure$__16-6 = default(_Closure$__16-3);
					for (int n = 0; n < mission_Mining.Length; n++)
					{
						string text25 = mission_Mining[n];
						text25 = text25.ToUpperInvariant();
						if (!dictionary.ContainsKey(text25))
						{
							continue;
						}
						object objectValue7 = RuntimeHelpers.GetObjectValue(dictionary[text25]);
						string text26 = text25;
						if (Operators.CompareString(text26, "OneThirdRule".ToUpperInvariant(), false) != 0)
						{
							if (Operators.CompareString(text26, "ArmingDelay".ToUpperInvariant(), false) != 0)
							{
								if (Operators.CompareString(text26, "TransitThrottleAircraft".ToUpperInvariant(), false) == 0)
								{
									miningMission.TransitThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue7));
								}
								else if (Operators.CompareString(text26, "TransitAltitudeAircraft".ToUpperInvariant(), false) == 0)
								{
									ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset9 = ActiveUnit_AI.AircraftAltitudePreset.None;
									float? num13 = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue7), ref AltitudePreset9);
									if (!num13.HasValue)
									{
										miningMission.TransitAltitude_Preset = AltitudePreset9;
										miningMission.UseTransitAltitude_Preset = true;
									}
									else if ((object)num13.GetType() == typeof(float))
									{
										miningMission.TransitAltitude_Aircraft = num13.Value;
										miningMission.UseTransitAltitude_Preset = false;
										miningMission.TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
									}
								}
								else if (Operators.CompareString(text26, "TransitTerrainFollowingAircraft".ToUpperInvariant(), false) == 0)
								{
									miningMission.TransitTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue7)).Value;
								}
								else if (Operators.CompareString(text26, "StationThrottleAircraft".ToUpperInvariant(), false) == 0)
								{
									miningMission.StationThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue7));
								}
								else if (Operators.CompareString(text26, "StationAltitudeAircraft".ToUpperInvariant(), false) != 0)
								{
									if (Operators.CompareString(text26, "StationTerrainFollowingAircraft".ToUpperInvariant(), false) == 0)
									{
										miningMission.StationTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue7)).Value;
									}
									else if (Operators.CompareString(text26, "UseTransitAltitudePreset".ToUpperInvariant(), false) == 0)
									{
										miningMission.UseTransitAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue7)).Value;
									}
									else if (Operators.CompareString(text26, "TransitAltitudePreset".ToUpperInvariant(), false) != 0)
									{
										if (Operators.CompareString(text26, "UseStationAltitudePreset".ToUpperInvariant(), false) != 0)
										{
											if (Operators.CompareString(text26, "StationAltitudePreset".ToUpperInvariant(), false) != 0)
											{
												if (Operators.CompareString(text26, "TransitThrottleSubmarine".ToUpperInvariant(), false) == 0)
												{
													miningMission.TransitThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue7)).Value;
												}
												else if (Operators.CompareString(text26, "TransitDepthSubmarine".ToUpperInvariant(), false) == 0)
												{
													miningMission.TransitDepth_Submarine = LuaUtility.QueryDepthObject(RuntimeHelpers.GetObjectValue(objectValue7));
													miningMission.UseTransitDepth_Submarine_Preset = false;
													miningMission.TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
												}
												else if (Operators.CompareString(text26, "StationThrottleSubmarine".ToUpperInvariant(), false) != 0)
												{
													if (Operators.CompareString(text26, "StationDepthSubmarine".ToUpperInvariant(), false) == 0)
													{
														miningMission.StationDepth_Submarine = LuaUtility.QueryDepthObject(RuntimeHelpers.GetObjectValue(objectValue7));
														miningMission.UseStationDepth_Submarine_Preset = false;
														miningMission.StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
													}
													else if (Operators.CompareString(text26, "StationDepthSubmarinePreset".ToUpperInvariant(), false) == 0)
													{
														miningMission.StationDepth_Submarine_Preset = LuaUtility.QueryDepthPresetObject(Conversions.ToString(objectValue7)).Value;
													}
													else if (Operators.CompareString(text26, "TransitDepthSubmarinePreset".ToUpperInvariant(), false) != 0)
													{
														if (Operators.CompareString(text26, "UseStationDepthSubmarinePreset".ToUpperInvariant(), false) == 0)
														{
															miningMission.UseStationDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue7)).Value;
														}
														else if (Operators.CompareString(text26, "UseTransitDepthSubmarinePreset".ToUpperInvariant(), false) != 0)
														{
															if (Operators.CompareString(text26, "TransitThrottleShip".ToUpperInvariant(), false) != 0)
															{
																if (Operators.CompareString(text26, "StationThrottleShip".ToUpperInvariant(), false) == 0)
																{
																	miningMission.StationThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue7)).Value;
																}
																else if (Operators.CompareString(text26, "GroupSize".ToUpperInvariant(), false) == 0)
																{
																	string text23 = Conversions.ToString(objectValue7);
																	miningMission.GroupSize = setGroupSize(ref text23);
																}
																else if (Operators.CompareString(text26, "FlightSize".ToUpperInvariant(), false) == 0)
																{
																	string text23 = Conversions.ToString(objectValue7);
																	miningMission.FlightSize = setFlightSize(ref text23);
																}
																else if (Operators.CompareString(text26, "MinAircraftReq".ToUpperInvariant(), false) == 0)
																{
																	string text23 = Conversions.ToString(objectValue7);
																	miningMission.MinimumNumberOfAircraft = setFlightQty(ref text23);
																}
																else if (Operators.CompareString(text26, "UseFlightSize".ToUpperInvariant(), false) == 0)
																{
																	miningMission.UseFlightSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue7)).Value;
																}
																else if (Operators.CompareString(text26, "UseGroupSize".ToUpperInvariant(), false) != 0)
																{
																	if (Operators.CompareString(text26, "Zone".ToUpperInvariant(), false) != 0)
																	{
																		if (Operators.CompareString(text26, "MinesLaidInSet".ToUpperInvariant(), false) != 0)
																		{
																			if (Operators.CompareString(text26, "MinesLaidInterval".ToUpperInvariant(), false) != 0)
																			{
																				if (Operators.CompareString(text26, "MinesLaidSetInterval".ToUpperInvariant(), false) != 0)
																				{
																					if (Operators.CompareString(text26, "MinesLaidMethod".ToUpperInvariant(), false) == 0)
																					{
																						miningMission.MinesLaidMethod = Conversions.ToByte(objectValue7);
																					}
																				}
																				else
																				{
																					miningMission.MinesLaidSetInterval = Conversions.ToInteger(objectValue7);
																				}
																			}
																			else
																			{
																				miningMission.MinesLaidInterval = Conversions.ToInteger(objectValue7);
																			}
																		}
																		else
																		{
																			miningMission.MinesLaidInSets = Conversions.ToInteger(objectValue7);
																		}
																		continue;
																	}
																	List<ReferencePoint> list12 = new List<ReferencePoint>();
																	List<object> list13 = LuaUtility.ToArray(((LuaTable)dictionary["ZONE"]).GetEnumerator());
																	using (List<object>.Enumerator enumerator9 = list13.GetEnumerator())
																	{
																		while (enumerator9.MoveNext())
																		{
																			closure$__16-6 = new _Closure$__16-3(closure$__16-6);
																			closure$__16-6.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator9.Current);
																			ReferencePoint referencePoint6 = null;
																			if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-6._Lambda$__24)))
																			{
																				if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-6._Lambda$__26)))
																				{
																					referencePoint6 = side.RefPoints.First(closure$__16-6._Lambda$__27);
																				}
																				else if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-6._Lambda$__28)))
																				{
																					if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-6._Lambda$__30)))
																					{
																						referencePoint6 = side.RefPoints.First(closure$__16-6._Lambda$__31);
																					}
																				}
																				else
																				{
																					referencePoint6 = side.RefPoints.First(closure$__16-6._Lambda$__29);
																				}
																			}
																			else
																			{
																				referencePoint6 = side.RefPoints.First(closure$__16-6._Lambda$__25);
																			}
																			if (!Information.IsNothing((object)referencePoint6))
																			{
																				list12.Add(referencePoint6);
																			}
																		}
																	}
																	miningMission.Area = list12;
																}
																else
																{
																	miningMission.UseGroupSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue7)).Value;
																}
															}
															else
															{
																miningMission.TransitThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue7)).Value;
															}
														}
														else
														{
															miningMission.UseTransitDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue7)).Value;
														}
													}
													else
													{
														miningMission.TransitDepth_Submarine_Preset = LuaUtility.QueryDepthPresetObject(Conversions.ToString(objectValue7)).Value;
													}
												}
												else
												{
													miningMission.StationThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue7)).Value;
												}
											}
											else
											{
												miningMission.StationAltitude_Preset = LuaUtility.QueryAltitudePresetObject(Conversions.ToString(objectValue7)).Value;
											}
										}
										else
										{
											miningMission.UseStationAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue7)).Value;
										}
									}
									else
									{
										miningMission.TransitAltitude_Preset = LuaUtility.QueryAltitudePresetObject(Conversions.ToString(objectValue7)).Value;
									}
								}
								else
								{
									ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset10 = ActiveUnit_AI.AircraftAltitudePreset.None;
									float? num14 = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue7), ref AltitudePreset10);
									if (!num14.HasValue)
									{
										miningMission.StationAltitude_Preset = AltitudePreset10;
										miningMission.UseStationAltitude_Preset = true;
									}
									else if ((object)num14.GetType() == typeof(float))
									{
										miningMission.StationAltitude_Aircraft = num14.Value;
										miningMission.UseStationAltitude_Preset = false;
										miningMission.StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
									}
								}
							}
							else
							{
								miningMission.ArmDelay = LuaUtility.ParseDateAsSeconds(Conversions.ToString(objectValue7));
							}
						}
						else
						{
							miningMission.OneThirdRule = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue7)).Value;
						}
					}
					break;
				}
				case Mission._MissionClass.MineClearing:
				{
					MineClearingMission mineClearingMission = (MineClearingMission)mission;
					string[] mission_MineClearing = Mission_MineClearing;
					_Closure$__16-4 closure$__16-4 = default(_Closure$__16-4);
					for (int l = 0; l < mission_MineClearing.Length; l++)
					{
						string text22 = mission_MineClearing[l];
						text22 = text22.ToUpperInvariant();
						if (!dictionary.ContainsKey(text22))
						{
							continue;
						}
						object objectValue5 = RuntimeHelpers.GetObjectValue(dictionary[text22]);
						string text23 = text22;
						if (Operators.CompareString(text23, "OneThirdRule".ToUpperInvariant(), false) != 0)
						{
							Mission.MissionMovementStyle result14;
							if (Operators.CompareString(text23, "LoopType".ToUpperInvariant(), false) != 0)
							{
								if (Operators.CompareString(text23, "TransitThrottleAircraft".ToUpperInvariant(), false) == 0)
								{
									mineClearingMission.TransitThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue5));
								}
								else if (Operators.CompareString(text23, "TransitAltitudeAircraft".ToUpperInvariant(), false) == 0)
								{
									ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset5 = ActiveUnit_AI.AircraftAltitudePreset.None;
									float? num9 = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue5), ref AltitudePreset5);
									if (!num9.HasValue)
									{
										mineClearingMission.TransitAltitude_Preset = AltitudePreset5;
										mineClearingMission.UseTransitAltitude_Preset = true;
									}
									else if ((object)num9.GetType() == typeof(float))
									{
										mineClearingMission.TransitAltitude_Aircraft = num9.Value;
										mineClearingMission.UseTransitAltitude_Preset = false;
										mineClearingMission.TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
									}
								}
								else if (Operators.CompareString(text23, "TransitTerrainFollowingAircraft".ToUpperInvariant(), false) == 0)
								{
									mineClearingMission.TransitTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
								}
								else if (Operators.CompareString(text23, "StationThrottleAircraft".ToUpperInvariant(), false) != 0)
								{
									if (Operators.CompareString(text23, "StationAltitudeAircraft".ToUpperInvariant(), false) != 0)
									{
										if (Operators.CompareString(text23, "StationTerrainFollowingAircraft".ToUpperInvariant(), false) == 0)
										{
											mineClearingMission.StationTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
										}
										else if (Operators.CompareString(text23, "UseTransitAltitudePreset".ToUpperInvariant(), false) != 0)
										{
											if (Operators.CompareString(text23, "TransitAltitudePreset".ToUpperInvariant(), false) == 0)
											{
												mineClearingMission.TransitAltitude_Preset = LuaUtility.QueryAltitudePresetObject(Conversions.ToString(objectValue5)).Value;
											}
											else if (Operators.CompareString(text23, "UseStationAltitudePreset".ToUpperInvariant(), false) == 0)
											{
												mineClearingMission.UseStationAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
											}
											else if (Operators.CompareString(text23, "StationAltitudePreset".ToUpperInvariant(), false) == 0)
											{
												mineClearingMission.StationAltitude_Preset = LuaUtility.QueryAltitudePresetObject(Conversions.ToString(objectValue5)).Value;
											}
											else if (Operators.CompareString(text23, "TransitThrottleSubmarine".ToUpperInvariant(), false) != 0)
											{
												if (Operators.CompareString(text23, "TransitDepthSubmarine".ToUpperInvariant(), false) == 0)
												{
													mineClearingMission.TransitDepth_Submarine = LuaUtility.QueryDepthObject(RuntimeHelpers.GetObjectValue(objectValue5));
													mineClearingMission.UseTransitDepth_Submarine_Preset = false;
													mineClearingMission.TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
												}
												else if (Operators.CompareString(text23, "StationThrottleSubmarine".ToUpperInvariant(), false) != 0)
												{
													if (Operators.CompareString(text23, "StationDepthSubmarine".ToUpperInvariant(), false) != 0)
													{
														if (Operators.CompareString(text23, "StationDepthSubmarinePreset".ToUpperInvariant(), false) != 0)
														{
															if (Operators.CompareString(text23, "TransitDepthSubmarinePreset".ToUpperInvariant(), false) != 0)
															{
																if (Operators.CompareString(text23, "UseStationDepthSubmarinePreset".ToUpperInvariant(), false) == 0)
																{
																	mineClearingMission.UseStationDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
																}
																else if (Operators.CompareString(text23, "UseTransitDepthSubmarinePreset".ToUpperInvariant(), false) == 0)
																{
																	mineClearingMission.UseTransitDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
																}
																else if (Operators.CompareString(text23, "TransitThrottleShip".ToUpperInvariant(), false) != 0)
																{
																	if (Operators.CompareString(text23, "StationThrottleShip".ToUpperInvariant(), false) == 0)
																	{
																		mineClearingMission.StationThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue5)).Value;
																	}
																	else if (Operators.CompareString(text23, "FlightSize".ToUpperInvariant(), false) == 0)
																	{
																		string text19 = Conversions.ToString(objectValue5);
																		mineClearingMission.FlightSize = setFlightSize(ref text19);
																	}
																	else if (Operators.CompareString(text23, "MinAircraftReq".ToUpperInvariant(), false) == 0)
																	{
																		string text19 = Conversions.ToString(objectValue5);
																		mineClearingMission.MinimumNumberOfAircraft = setFlightQty(ref text19);
																	}
																	else if (Operators.CompareString(text23, "UseFlightSize".ToUpperInvariant(), false) != 0)
																	{
																		if (Operators.CompareString(text23, "UseGroupSize".ToUpperInvariant(), false) != 0)
																		{
																			if (Operators.CompareString(text23, "Zone".ToUpperInvariant(), false) != 0)
																			{
																				continue;
																			}
																			List<ReferencePoint> list8 = new List<ReferencePoint>();
																			List<object> list9 = LuaUtility.ToArray(((LuaTable)dictionary["ZONE"]).GetEnumerator());
																			using (List<object>.Enumerator enumerator6 = list9.GetEnumerator())
																			{
																				while (enumerator6.MoveNext())
																				{
																					closure$__16-4 = new _Closure$__16-4(closure$__16-4);
																					closure$__16-4.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator6.Current);
																					ReferencePoint referencePoint4 = null;
																					if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-4._Lambda$__32)))
																					{
																						referencePoint4 = side.RefPoints.First(closure$__16-4._Lambda$__33);
																					}
																					else if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-4._Lambda$__34)))
																					{
																						referencePoint4 = side.RefPoints.First(closure$__16-4._Lambda$__35);
																					}
																					else if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-4._Lambda$__36)))
																					{
																						referencePoint4 = side.RefPoints.First(closure$__16-4._Lambda$__37);
																					}
																					else if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-4._Lambda$__38)))
																					{
																						referencePoint4 = side.RefPoints.First(closure$__16-4._Lambda$__39);
																					}
																					if (!Information.IsNothing((object)referencePoint4))
																					{
																						list8.Add(referencePoint4);
																					}
																				}
																			}
																			mineClearingMission.Area = list8;
																		}
																		else
																		{
																			mineClearingMission.UseGroupSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
																		}
																	}
																	else
																	{
																		mineClearingMission.UseFlightSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
																	}
																}
																else
																{
																	mineClearingMission.TransitThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue5)).Value;
																}
															}
															else
															{
																mineClearingMission.TransitDepth_Submarine_Preset = LuaUtility.QueryDepthPresetObject(Conversions.ToString(objectValue5)).Value;
															}
														}
														else
														{
															mineClearingMission.StationDepth_Submarine_Preset = LuaUtility.QueryDepthPresetObject(Conversions.ToString(objectValue5)).Value;
														}
													}
													else
													{
														mineClearingMission.StationDepth_Submarine = LuaUtility.QueryDepthObject(RuntimeHelpers.GetObjectValue(objectValue5));
														mineClearingMission.UseStationDepth_Submarine_Preset = false;
														mineClearingMission.StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
													}
												}
												else
												{
													mineClearingMission.StationThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue5)).Value;
												}
											}
											else
											{
												mineClearingMission.TransitThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue5)).Value;
											}
										}
										else
										{
											mineClearingMission.UseTransitAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
										}
									}
									else
									{
										ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset6 = ActiveUnit_AI.AircraftAltitudePreset.None;
										float? num10 = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue5), ref AltitudePreset6);
										if (!num10.HasValue)
										{
											mineClearingMission.StationAltitude_Preset = AltitudePreset6;
											mineClearingMission.UseStationAltitude_Preset = true;
										}
										else if ((object)num10.GetType() == typeof(float))
										{
											mineClearingMission.StationAltitude_Aircraft = num10.Value;
											mineClearingMission.UseStationAltitude_Preset = false;
											mineClearingMission.StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
										}
									}
								}
								else
								{
									mineClearingMission.StationThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue5));
								}
							}
							else if (Enum.TryParse<Mission.MissionMovementStyle>(Conversions.ToString(objectValue5), ignoreCase: true, out result14) && Enum.IsDefined(typeof(Mission.MissionMovementStyle), result14))
							{
								mineClearingMission.MovementStyle = result14;
							}
						}
						else
						{
							mineClearingMission.OneThirdRule = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
						}
					}
					break;
				}
				case Mission._MissionClass.Cargo:
				{
					CargoMission cargoMission = (CargoMission)mission;
					string[] mission_Cargo = Mission_Cargo;
					_Closure$__16-5 closure$__16- = default(_Closure$__16-5);
					for (int j = 0; j < mission_Cargo.Length; j++)
					{
						string text18 = mission_Cargo[j];
						text18 = text18.ToUpperInvariant();
						if (!dictionary.ContainsKey(text18))
						{
							continue;
						}
						object objectValue = RuntimeHelpers.GetObjectValue(dictionary[text18]);
						string text19 = text18;
						if (Operators.CompareString(text19, "TransitThrottleAircraft".ToUpperInvariant(), false) != 0)
						{
							if (Operators.CompareString(text19, "TransitAltitudeAircraft".ToUpperInvariant(), false) != 0)
							{
								if (Operators.CompareString(text19, "StationThrottleAircraft".ToUpperInvariant(), false) == 0)
								{
									cargoMission.StationThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue)).Value;
								}
								else if (Operators.CompareString(text19, "StationAltitudeAircraft".ToUpperInvariant(), false) == 0)
								{
									object? objectValue2 = RuntimeHelpers.GetObjectValue(objectValue);
									ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset = null;
									float? num4 = LuaUtility.QueryAltitudeObject(objectValue2, ref AltitudePreset);
									if (num4.HasValue && (object)num4.GetType() == typeof(float))
									{
										cargoMission.StationAltitude_Aircraft = num4.Value;
									}
								}
								else if (Operators.CompareString(text19, "UseFlightSize".ToUpperInvariant(), false) != 0)
								{
									if (Operators.CompareString(text19, "TransitThrottleShip".ToUpperInvariant(), false) != 0)
									{
										if (Operators.CompareString(text19, "StationThrottleShip".ToUpperInvariant(), false) == 0)
										{
											cargoMission.StationThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue)).Value;
										}
										else if (Operators.CompareString(text19, "UseGroupSize".ToUpperInvariant(), false) != 0)
										{
											if (Operators.CompareString(text19, "Zone".ToUpperInvariant(), false) == 0)
											{
												List<ReferencePoint> list2 = new List<ReferencePoint>();
												List<object> list3 = LuaUtility.ToArray(((LuaTable)dictionary["ZONE"]).GetEnumerator());
												using (List<object>.Enumerator enumerator2 = list3.GetEnumerator())
												{
													while (enumerator2.MoveNext())
													{
														closure$__16- = new _Closure$__16-5(closure$__16-);
														closure$__16-.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator2.Current);
														ReferencePoint referencePoint = null;
														if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-._Lambda$__40)))
														{
															referencePoint = side.RefPoints.First(closure$__16-._Lambda$__41);
														}
														else if (Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-._Lambda$__42)))
														{
															if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-._Lambda$__44)))
															{
																referencePoint = side.RefPoints.First(closure$__16-._Lambda$__45);
															}
															else if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__16-._Lambda$__46)))
															{
																referencePoint = side.RefPoints.First(closure$__16-._Lambda$__47);
															}
														}
														else
														{
															referencePoint = side.RefPoints.First(closure$__16-._Lambda$__43);
														}
														if (!Information.IsNothing((object)referencePoint))
														{
															list2.Add(referencePoint);
														}
													}
												}
												cargoMission.Area = list2;
											}
											else if (Operators.CompareString(text19, "DestinationUnitID".ToUpperInvariant(), false) != 0)
											{
												if (Operators.CompareString(text19, "MoveAllCargo".ToUpperInvariant(), false) != 0)
												{
													if (Operators.CompareString(text19, "AllowGroundUnitSelfDeliveryFromCargo".ToUpperInvariant(), false) == 0)
													{
														cargoMission.AllowSelfDeliveryFromCargo = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue)).Value;
														if (!cargoMission.AllowSelfDeliveryFromCargo)
														{
															cargoMission.AllowAllSelfDelivery = false;
														}
													}
													else if (Operators.CompareString(text19, "AllGroundUnitAttemptSelfDelivery".ToUpperInvariant(), false) != 0)
													{
														if (Operators.CompareString(text19, "AutomaticallyUnpackContainersAtDestination".ToUpperInvariant(), false) == 0 && cargoMission.Type == CargoMission.CargoMissionType.Transfer)
														{
															cargoMission.UnpackAllContainers = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue)).Value;
														}
													}
													else
													{
														cargoMission.AllowAllSelfDelivery = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue)).Value;
														if (cargoMission.AllowAllSelfDelivery)
														{
															cargoMission.AllowSelfDeliveryFromCargo = true;
														}
													}
												}
												else
												{
													cargoMission.MoveAllCargo = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue)).Value;
												}
											}
											else
											{
												string key = Conversions.ToString(objectValue);
												ActiveUnit value4 = null;
												if (ScenarioContext.ActiveUnits.TryGetValue(key, out value4))
												{
													cargoMission.DestinationUnit = value4;
												}
											}
										}
										else
										{
											cargoMission.UseGroupSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue)).Value;
										}
									}
									else
									{
										cargoMission.TransitThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue)).Value;
									}
								}
								else
								{
									cargoMission.UseFlightSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue)).Value;
								}
							}
							else
							{
								object? objectValue3 = RuntimeHelpers.GetObjectValue(objectValue);
								ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset = null;
								float? num5 = LuaUtility.QueryAltitudeObject(objectValue3, ref AltitudePreset);
								if (num5.HasValue && (object)num5.GetType() == typeof(float))
								{
									cargoMission.TransitAltitude_Aircraft = num5.Value;
								}
							}
						}
						else
						{
							cargoMission.TransitThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue)).Value;
						}
					}
					break;
				}
				}
				mission.UpdateFlightPlanUseForTakeOffAndTargetTimes();
				return new LuaWrapper_Mission(mission, ScenarioContext);
			}
		}
		throw new LuaError("missing side: " + SideName);
	}

	public static LuaTable ScenEdit_AssignUnitAsTarget(LuaTable AUNameOrIDOrTable, string MissionNameOrID, Scenario ScenarioContext, ActiveUnit UnitX)
	{
		Module_Unit.Unit unit = null;
		Mission mission = null;
		Side side = null;
		string text = null;
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
		int num = 1;
		if (AUNameOrIDOrTable is string)
		{
			text = Conversions.ToString((object)AUNameOrIDOrTable);
		}
		else
		{
			if (!(AUNameOrIDOrTable is LuaTable))
			{
				return luaTable2;
			}
			luaTable = AUNameOrIDOrTable;
		}
		if (Operators.CompareString(text, "UnitX", false) != 0)
		{
			if (!Information.IsNothing((object)text))
			{
				unit = PrivateMethods.smethod_1(text, ScenarioContext);
				if (unit == null)
				{
					unit = PrivateMethods.ValidateContactBySceanrio(text, ScenarioContext);
					if (unit == null)
					{
						return luaTable2;
					}
				}
			}
		}
		else if (!Information.IsNothing((object)UnitX))
		{
			unit = UnitX;
		}
		mission = ValidateMissionBySceanrio(MissionNameOrID, ScenarioContext);
		if (mission == null)
		{
			return luaTable2;
		}
		if (mission.MissionClass != Mission._MissionClass.Strike)
		{
			return luaTable2;
		}
		Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
		foreach (Side side2 in sides_ReadOnly)
		{
			foreach (Mission mission2 in side2.Missions)
			{
				if (Operators.CompareString(mission2.ObjectID, mission.ObjectID, false) == 0)
				{
					side = side2;
					break;
				}
			}
		}
		if (!Information.IsNothing((object)text))
		{
			luaTable[num] = unit.ObjectID;
		}
		List<object> list = LuaUtility.ToArray(luaTable.GetEnumerator());
		foreach (object item in list)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(item);
			if (!(objectValue is string))
			{
				continue;
			}
			string string_ = Conversions.ToString(objectValue);
			unit = PrivateMethods.smethod_1(string_, ScenarioContext);
			if (unit == null)
			{
				unit = PrivateMethods.ValidateContactBySceanrio(string_, ScenarioContext);
				if (unit == null)
				{
					continue;
				}
			}
			if (mission.MissionClass != Mission._MissionClass.Strike || unit.get_UnitSide(SetSideOnly: false) == side || Module_Side.IsAlliedWithThisSide(side, unit.get_UnitSide(SetSideOnly: false)))
			{
				continue;
			}
			if (unit.IsGroup)
			{
				bool flag = false;
				foreach (ActiveUnit value in ((Group)unit).Units.Values)
				{
					if (((Strike)mission).AddToSpecificTargets(value))
					{
						luaTable2[num] = value.ObjectID;
						num++;
						flag = true;
					}
				}
				if (flag)
				{
				}
				continue;
			}
			if (unit.IsActiveUnit)
			{
				if (((Strike)mission).AddToSpecificTargets(unit))
				{
					luaTable2[num] = unit.ObjectID;
					num++;
				}
				continue;
			}
			Contact contact = (Contact)unit;
			if (!Information.IsNothing((object)contact.ActualUnit) && side.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID))
			{
				foreach (ActiveUnit value2 in ((Group)contact.ActualUnit).Units.Values)
				{
					if (((Strike)mission).AddToSpecificTargets(value2))
					{
						luaTable2[num] = value2.ObjectID;
						num++;
					}
				}
			}
			else if (!side.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID) && ((Strike)mission).AddToSpecificTargets(contact))
			{
				luaTable2[num] = unit.ObjectID;
				num++;
			}
		}
		return luaTable2;
	}

	public static LuaTable ScenEdit_RemoveUnitAsTarget(LuaTable AUNameOrIDOrTable, string MissionNameOrID, Scenario ScenarioContext, ActiveUnit UnitX)
	{
		Module_Unit.Unit unit = null;
		Mission mission = null;
		Side side = null;
		string text = null;
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
		int num = 1;
		if (!(AUNameOrIDOrTable is string))
		{
			if (!(AUNameOrIDOrTable is LuaTable))
			{
				return luaTable2;
			}
			luaTable = AUNameOrIDOrTable;
		}
		else
		{
			text = Conversions.ToString((object)AUNameOrIDOrTable);
		}
		if (Operators.CompareString(text, "UnitX", false) == 0)
		{
			if (!Information.IsNothing((object)UnitX))
			{
				unit = UnitX;
			}
		}
		else if (!Information.IsNothing((object)text))
		{
			unit = PrivateMethods.smethod_1(text, ScenarioContext);
			if (unit == null)
			{
				unit = PrivateMethods.ValidateContactBySceanrio(text, ScenarioContext);
				if (unit == null)
				{
					return luaTable2;
				}
			}
		}
		mission = ValidateMissionBySceanrio(MissionNameOrID, ScenarioContext);
		if (mission != null)
		{
			if (mission.MissionClass != Mission._MissionClass.Strike)
			{
				return luaTable2;
			}
			Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
			foreach (Side side2 in sides_ReadOnly)
			{
				foreach (Mission mission2 in side2.Missions)
				{
					if (Operators.CompareString(mission2.ObjectID, mission.ObjectID, false) == 0)
					{
						side = side2;
						break;
					}
				}
			}
			if (!Information.IsNothing((object)text))
			{
				luaTable[num] = unit.ObjectID;
				if (side.BaseContacts.ContainsKey(unit.ObjectID))
				{
					foreach (Contact baseContacts_ in side.BaseContacts_List)
					{
						if (Operators.CompareString(baseContacts_.ActualUnit.ObjectID, unit.ObjectID, false) == 0)
						{
							num++;
							luaTable[num] = baseContacts_.ObjectID;
						}
					}
					foreach (ActiveUnit value in ((Group)unit).Units.Values)
					{
						if (!side.Contacts.ContainsKey(value.ObjectID))
						{
							continue;
						}
						foreach (Contact contacts_ in side.Contacts_List)
						{
							if (Operators.CompareString(contacts_.ActualUnit.ObjectID, value.ObjectID, false) == 0)
							{
								num++;
								luaTable[num] = contacts_.ObjectID;
							}
						}
					}
				}
				else if (side.Contacts.ContainsKey(unit.ObjectID))
				{
					foreach (Contact contacts_2 in side.Contacts_List)
					{
						if (Operators.CompareString(contacts_2.ActualUnit.ObjectID, unit.ObjectID, false) == 0)
						{
							num++;
							luaTable[num] = contacts_2.ObjectID;
						}
					}
				}
			}
			List<object> list = LuaUtility.ToArray(luaTable.GetEnumerator());
			foreach (object item in list)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				if (!(objectValue is string))
				{
					continue;
				}
				string string_ = Conversions.ToString(objectValue);
				unit = PrivateMethods.smethod_1(string_, ScenarioContext);
				if (unit == null)
				{
					unit = PrivateMethods.ValidateContactBySceanrio(string_, ScenarioContext);
					if (unit == null)
					{
						continue;
					}
				}
				if (mission.MissionClass != Mission._MissionClass.Strike || unit.get_UnitSide(SetSideOnly: false) == side || Module_Side.IsAlliedWithThisSide(side, unit.get_UnitSide(SetSideOnly: false)))
				{
					continue;
				}
				if (unit.IsGroup)
				{
					foreach (ActiveUnit value2 in ((Group)unit).Units.Values)
					{
						if (((Strike)mission).RemoveFromSpecificTargets(value2))
						{
							luaTable2[num] = value2.ObjectID;
							num++;
						}
					}
				}
				else if (!unit.IsActiveUnit)
				{
					Contact contact = (Contact)unit;
					if (!Information.IsNothing((object)contact.ActualUnit) && side.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID))
					{
						foreach (ActiveUnit value3 in ((Group)contact.ActualUnit).Units.Values)
						{
							if (((Strike)mission).RemoveFromSpecificTargets(value3))
							{
								luaTable2[num] = value3.ObjectID;
								num++;
							}
						}
					}
					else if (!side.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID) && ((Strike)mission).RemoveFromSpecificTargets(contact))
					{
						luaTable2[num] = unit.ObjectID;
						num++;
					}
				}
				else if (((Strike)mission).RemoveFromSpecificTargets(unit))
				{
					luaTable2[num] = unit.ObjectID;
					num++;
				}
			}
			return luaTable2;
		}
		return luaTable2;
	}

	public static LuaTable ScenEdit_CreateMissionFlightPlan(string SideName, string MissionNameOrID, LuaTable table, Scenario ScenarioContext)
	{
		Mission mission = null;
		Side side = null;
		side = PrivateMethods.ValidateSide(SideName, ScenarioContext);
		if (side != null)
		{
			mission = ValidateMissionBySide(MissionNameOrID, side);
			if (mission == null)
			{
				throw new LuaError("missing mission " + MissionNameOrID);
			}
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
			string text = "DDMMYYYY";
			string text2 = "MMDDYYYY";
			string text3 = "YYYYMMDD";
			string text4 = text3;
			if (dictionary.ContainsKey("DATEFORMAT"))
			{
				string text5 = Conversions.ToString(dictionary["DATEFORMAT"]);
				if (Operators.CompareString(text5, text, false) != 0 && Operators.CompareString(text5, text2, false) != 0 && Operators.CompareString(text5, text3, false) != 0)
				{
					throw new LuaError("Invalid date format '" + text5 + "'");
				}
				text4 = text5;
			}
			if (dictionary.ContainsKey("TAKEOFFTIME"))
			{
				if (string.Equals(Conversions.ToString(dictionary["TAKEOFFTIME"]), "CLEAR", StringComparison.OrdinalIgnoreCase))
				{
					mission.TakeOffTime = null;
				}
				else
				{
					string text6 = null;
					text6 = (dictionary.ContainsKey("TAKEOFFDATE") ? (Conversions.ToString(dictionary["TAKEOFFDATE"]) + " " + Conversions.ToString(dictionary["TAKEOFFTIME"])) : Conversions.ToString(dictionary["TAKEOFFTIME"]));
					try
					{
						DateTime? takeOffTime = null;
						string text7 = text4;
						if (Operators.CompareString(text7, text, false) != 0)
						{
							if (Operators.CompareString(text7, text2, false) != 0)
							{
								if (Operators.CompareString(text7, text3, false) == 0)
								{
									takeOffTime = LuaUtility.ParseDateTime_String(text6, LuaUtility.DateFormat.YYYYMMDD);
								}
							}
							else
							{
								takeOffTime = LuaUtility.ParseDateTime_String(text6, LuaUtility.DateFormat.MMDDYYYY);
							}
						}
						else
						{
							takeOffTime = LuaUtility.ParseDateTime_String(text6, LuaUtility.DateFormat.DDMMYYYY);
						}
						if (takeOffTime.HasValue)
						{
							mission.TakeOffTime = takeOffTime;
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
			if (dictionary.ContainsKey("TIMEONTARGET"))
			{
				if (!string.Equals(Conversions.ToString(dictionary["TIMEONTARGET"]), "CLEAR", StringComparison.OrdinalIgnoreCase))
				{
					string text8 = null;
					text8 = ((!dictionary.ContainsKey("DATEONTARGET")) ? Conversions.ToString(dictionary["TIMEONTARGET"]) : (Conversions.ToString(dictionary["DATEONTARGET"]) + " " + Conversions.ToString(dictionary["TIMEONTARGET"])));
					try
					{
						DateTime? timeOnTarget = null;
						string text9 = text4;
						if (Operators.CompareString(text9, text, false) == 0)
						{
							timeOnTarget = LuaUtility.ParseDateTime_String(text8, LuaUtility.DateFormat.DDMMYYYY);
						}
						else if (Operators.CompareString(text9, text2, false) == 0)
						{
							timeOnTarget = LuaUtility.ParseDateTime_String(text8, LuaUtility.DateFormat.MMDDYYYY);
						}
						else if (Operators.CompareString(text9, text3, false) == 0)
						{
							timeOnTarget = LuaUtility.ParseDateTime_String(text8, LuaUtility.DateFormat.YYYYMMDD);
						}
						if (timeOnTarget.HasValue)
						{
							mission.TimeOnTarget = timeOnTarget;
						}
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					mission.TimeOnTarget = null;
				}
			}
			mission.UseFlightplans = true;
			if (Operators.CompareString(CoreClientCode.GenerateMissionFlightPlans_Core(ScenarioContext, side, mission, mission.FlightSize), "OK", false) != 0)
			{
				return null;
			}
			if (dictionary.ContainsKey("LOCATION_TAKEOFF"))
			{
				Conversions.ToString(dictionary["LOCATION_TAKEOFF"]);
			}
			if (dictionary.ContainsKey("LOCATION_LANDING"))
			{
				Conversions.ToString(dictionary["LOCATION_LANDING"]);
			}
			if (mission.FlightList == null || mission.FlightList.Count == 0)
			{
				return null;
			}
			foreach (Mission.Flight flight in mission.FlightList)
			{
				if (flight.get_Status(ScenarioContext) == Mission._FlightStatus.None && flight.FlightPlan.Count() <= 0)
				{
					CoreClientCode.GenerateMissionFlightPlanFull_Core(ScenarioContext, side, mission, flight);
				}
			}
			return new LuaWrapper_Mission(mission, ScenarioContext).flightlist;
		}
		throw new LuaError("missing side:    " + SideName);
	}

	public static Mission ValidateMissionBySceanrio(string MissionNameOrID, Scenario theScen)
	{
		Mission result = null;
		Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			foreach (Mission mission in side.Missions)
			{
				if (Operators.CompareString(mission.Name, MissionNameOrID, false) != 0 && Operators.CompareString(mission.ObjectID, MissionNameOrID, false) != 0)
				{
					if (string.Equals(mission.Name, MissionNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(mission.ObjectID, MissionNameOrID, StringComparison.OrdinalIgnoreCase))
					{
						result = mission;
						return result;
					}
					continue;
				}
				result = mission;
				return result;
			}
		}
		return result;
	}

	public static Mission ValidateMissionBySide(string MissionNameOrID, Side theSide)
	{
		Mission result = null;
		foreach (Mission mission in theSide.Missions)
		{
			if (string.Equals(mission.Name, MissionNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(mission.ObjectID, MissionNameOrID, StringComparison.OrdinalIgnoreCase))
			{
				result = mission;
				break;
			}
		}
		return result;
	}

	public static Mission._FlightSize setFlightSize(ref string _value)
	{
		int result = 0;
		int.TryParse(_value, out result);
		Mission._FlightSize flightSize = 0;
		int num = result;
		if (num < 2)
		{
			return 1;
		}
		if (num < 3)
		{
			return 2;
		}
		if (num < 4)
		{
			return 3;
		}
		if (num < 5)
		{
			return 4;
		}
		if (num < 7)
		{
			return 6;
		}
		return 1;
	}

	public static Mission._FlightQty setFlightQty(ref string _value)
	{
		if (Operators.CompareString(_value.ToLower(), "all", false) != 0)
		{
			int result = 0;
			int.TryParse(_value, out result);
			Mission._FlightQty flightQty = Mission._FlightQty.NoPreferences;
			int num = result;
			return (num != 0) ? ((num < 2) ? Mission._FlightQty.Flight_x1 : ((num < 3) ? Mission._FlightQty.Flight_x2 : ((num < 4) ? Mission._FlightQty.Flight_x3 : ((num < 5) ? Mission._FlightQty.Flight_x4 : ((num < 7) ? Mission._FlightQty.Flight_x6 : ((num < 9) ? Mission._FlightQty.Flight_x8 : ((num >= 13) ? Mission._FlightQty.All : Mission._FlightQty.Flight_x12))))))) : Mission._FlightQty.NoPreferences;
		}
		return Mission._FlightQty.All;
	}

	public static Mission._GroupSize setGroupSize(ref string _value)
	{
		if (Operators.CompareString(_value.ToLower(), "all", false) == 0)
		{
			return 0;
		}
		int result = 0;
		int.TryParse(_value, out result);
		Mission._GroupSize groupSize = 0;
		int num = result;
		return (num < 2) ? ((Mission._GroupSize)1) : ((num < 3) ? ((Mission._GroupSize)2) : ((num < 4) ? ((Mission._GroupSize)3) : ((num < 5) ? ((Mission._GroupSize)4) : ((num < 7) ? ((Mission._GroupSize)6) : ((Mission._GroupSize)1)))));
	}

	public static Misc.PostureStance setStance(ref string _value)
	{
		string text = _value.ToLower();
		uint num = <PrivateImplementationDetails>{A835D9A0-0EE4-445E-BC69-5FEB38C502A4}.ComputeStringHash(text);
		int result;
		int result2;
		int result3;
		int result4;
		int result5;
		if (num <= 2094259269)
		{
			if (num > 873244444)
			{
				if (num > 906799682)
				{
					if (num != 923577301)
					{
						if (num != 2094259269)
						{
							result = 4;
							goto IL_01fb;
						}
						if (Operators.CompareString(text, "unfriendly", false) == 0)
						{
							result2 = 2;
							goto IL_01a9;
						}
					}
					else if (Operators.CompareString(text, "2", false) == 0)
					{
						result2 = 2;
						goto IL_01a9;
					}
				}
				else if (num != 890022063)
				{
					if (num != 906799682)
					{
						result = 4;
						goto IL_01fb;
					}
					if (Operators.CompareString(text, "3", false) == 0)
					{
						result3 = 3;
						goto IL_0168;
					}
				}
				else if (Operators.CompareString(text, "0", false) == 0)
				{
					result4 = 0;
					goto IL_01be;
				}
				goto IL_01fa;
			}
			if (num != 9542285)
			{
				if (num != 822911587)
				{
					if (num == 873244444)
					{
						if (Operators.CompareString(text, "1", false) == 0)
						{
							result5 = 1;
							goto IL_01f7;
						}
						goto IL_01fa;
					}
					result = 4;
				}
				else
				{
					if (Operators.CompareString(text, "4", false) == 0)
					{
						goto IL_014f;
					}
					result = 4;
				}
			}
			else
			{
				if (Operators.CompareString(text, "hostile", false) == 0)
				{
					result3 = 3;
					goto IL_0168;
				}
				result = 4;
			}
		}
		else if (num <= 2608177081u)
		{
			if (num != 2353732312u)
			{
				if (num == 2587575632u)
				{
					if (Operators.CompareString(text, "h'", false) == 0)
					{
						result3 = 3;
						goto IL_0168;
					}
					goto IL_01fa;
				}
				if (num != 2608177081u)
				{
					result = 4;
				}
				else
				{
					if (Operators.CompareString(text, "unknown", false) == 0)
					{
						goto IL_014f;
					}
					result = 4;
				}
			}
			else
			{
				if (Operators.CompareString(text, "neutral", false) == 0)
				{
					goto IL_01bd;
				}
				result = 4;
			}
		}
		else if (num > 3809224601u)
		{
			if (num != 3943445553u)
			{
				if (num == 4027333648u)
				{
					if (Operators.CompareString(text, "u", false) == 0)
					{
						result2 = 2;
						goto IL_01a9;
					}
					goto IL_01fa;
				}
				result = 4;
			}
			else
			{
				if (Operators.CompareString(text, "n", false) == 0)
				{
					goto IL_01bd;
				}
				result = 4;
			}
		}
		else
		{
			if (num == 3453284734u)
			{
				if (Operators.CompareString(text, "friendly", false) == 0)
				{
					result5 = 1;
					goto IL_01f7;
				}
				goto IL_01fa;
			}
			if (num != 3809224601u)
			{
				result = 4;
			}
			else
			{
				if (Operators.CompareString(text, "f", false) == 0)
				{
					result5 = 1;
					goto IL_01f7;
				}
				result = 4;
			}
		}
		goto IL_01fb;
		IL_01fa:
		result = 4;
		goto IL_01fb;
		IL_01be:
		return (Misc.PostureStance)result4;
		IL_0168:
		return (Misc.PostureStance)result3;
		IL_01a9:
		return (Misc.PostureStance)result2;
		IL_01fb:
		return (Misc.PostureStance)result;
		IL_014f:
		return Misc.PostureStance.Unknown;
		IL_01f7:
		return (Misc.PostureStance)result5;
		IL_01bd:
		result4 = 0;
		goto IL_01be;
	}

	public static Mission._RadarBehaviour setRadarUse(ref string _value)
	{
		string text = _value.ToLower();
		int result;
		if (Operators.CompareString(text, "None".ToLower(), false) == 0)
		{
			result = 0;
		}
		else
		{
			if (Operators.CompareString(text, "0", false) != 0)
			{
				int result2;
				if (Operators.CompareString(text, "UseMissionEMCON".ToLower(), false) != 0)
				{
					if (Operators.CompareString(text, "1", false) != 0)
					{
						if (Operators.CompareString(text, "ActiveOnIP".ToLower(), false) != 0 && Operators.CompareString(text, "2", false) != 0)
						{
							if (Operators.CompareString(text, "ActiveOnAttackIngressAndIP".ToLower(), false) != 0 && Operators.CompareString(text, "3", false) != 0)
							{
								return Mission._RadarBehaviour.None;
							}
							return Mission._RadarBehaviour.ActiveOnAttackIngressAndIP;
						}
						return Mission._RadarBehaviour.ActiveOnIP;
					}
					result2 = 1;
				}
				else
				{
					result2 = 1;
				}
				return (Mission._RadarBehaviour)result2;
			}
			result = 0;
		}
		return (Mission._RadarBehaviour)result;
	}

	public static void MissionFlightPlanDeleteWaypoint(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, Mission.Flight.FlightElement theFlightElement, Waypoint theWaypoint)
	{
		if (theWaypoint == null)
		{
			return;
		}
		foreach (ActiveUnit unit in theSide.Units)
		{
			if (!unit.Navigator.HasPlottedCourse())
			{
				continue;
			}
			if (!unit.Navigator.PlottedCourse.Contains(theWaypoint))
			{
				if (!Information.IsNothing((object)theWaypoint.Waypoint_LeadElementWingman) && unit.Navigator.PlottedCourse.Contains(theWaypoint.Waypoint_LeadElementWingman))
				{
					unit.Navigator.RemoveWaypoint_Soft(theWaypoint.Waypoint_LeadElementWingman, RemoveWingmanWaypoints: false);
				}
				else if (!Information.IsNothing((object)theWaypoint.Waypoint_SecondElement) && unit.Navigator.PlottedCourse.Contains(theWaypoint.Waypoint_SecondElement))
				{
					unit.Navigator.RemoveWaypoint_Soft(theWaypoint.Waypoint_SecondElement, RemoveWingmanWaypoints: false);
				}
				else if (!Information.IsNothing((object)theWaypoint.Waypoint_SecondElementWingman) && unit.Navigator.PlottedCourse.Contains(theWaypoint.Waypoint_SecondElementWingman))
				{
					unit.Navigator.RemoveWaypoint_Soft(theWaypoint.Waypoint_SecondElementWingman, RemoveWingmanWaypoints: false);
				}
				else if (!Information.IsNothing((object)theWaypoint.Waypoint_ThirdElement) && unit.Navigator.PlottedCourse.Contains(theWaypoint.Waypoint_ThirdElement))
				{
					unit.Navigator.RemoveWaypoint_Soft(theWaypoint.Waypoint_ThirdElement, RemoveWingmanWaypoints: false);
				}
				else if (!Information.IsNothing((object)theWaypoint.Waypoint_ThirdElementWingman) && unit.Navigator.PlottedCourse.Contains(theWaypoint.Waypoint_ThirdElementWingman))
				{
					unit.Navigator.RemoveWaypoint_Soft(theWaypoint.Waypoint_ThirdElementWingman, RemoveWingmanWaypoints: false);
				}
			}
			else
			{
				unit.Navigator.RemoveWaypoint_Soft(theWaypoint, RemoveWingmanWaypoints: true);
			}
		}
		ActiveUnit_Navigator.RemoveWaypoint_Hard(theScen, theMission, theFlight, theWaypoint);
	}

	public static void MissionFlightPlanInsertWaypoint(short theIndexBefore, Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, Mission.Flight.FlightElement theFlightElement, Waypoint theWaypoint)
	{
		if (theWaypoint == null)
		{
			return;
		}
		int num = 0;
		Waypoint waypoint = null;
		Waypoint waypoint2 = null;
		Waypoint[] flightPlan = theFlight.FlightPlan;
		int num2 = 0;
		int num3;
		while (true)
		{
			if (num2 < flightPlan.Length)
			{
				Waypoint waypoint3 = flightPlan[num2];
				if (Operators.CompareString(waypoint3.Description, Conversions.ToString((int)theIndexBefore), false) != 0 && waypoint3.Type != (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), Conversions.ToString((int)theIndexBefore), ignoreCase: true))
				{
					num++;
					num2 = checked(num2 + 1);
					continue;
				}
				waypoint = waypoint3;
				waypoint2 = theFlight.FlightPlan[num - 1];
				CoreClientCode.ChangeFightPlanInsertWaypoint_Core(theScen, theSide, theMission, theFlight, Mission.Flight.FlightElement.LeadElement, waypoint2);
				num3 = 0;
				break;
			}
			num3 = 0;
			break;
		}
		num = num3;
		if (waypoint == null)
		{
			return;
		}
		Waypoint[] flightPlan2 = theFlight.FlightPlan;
		int num4 = 0;
		while (true)
		{
			if (num4 < flightPlan2.Length)
			{
				if (flightPlan2[num4] == waypoint2)
				{
					break;
				}
				num++;
				num4 = checked(num4 + 1);
				continue;
			}
			return;
		}
		UpdateFlightPlanWaypointValues(ref theFlight.FlightPlan[num + 1], ref theWaypoint);
		ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
		Mission.Flight flight;
		Waypoint[] theFlightplan = (flight = theFlight).FlightPlan;
		float NecessaryFuel = 0f;
		float MissionFuel = 0f;
		MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission, theAU, theFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
		flight.FlightPlan = theFlightplan;
	}

	public static int MissionFlightPlanInsertWaypointAfter(string theAnchor, Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, Mission.Flight.FlightElement theFlightElement, Waypoint theWaypoint)
	{
		int result;
		if (theWaypoint != null)
		{
			int num = 0;
			Waypoint waypoint = null;
			Waypoint[] flightPlan = theFlight.FlightPlan;
			int num2 = 0;
			int num3;
			while (true)
			{
				if (num2 < flightPlan.Length)
				{
					Waypoint waypoint2 = flightPlan[num2];
					if (!string.Equals(waypoint2.ObjectID, theAnchor, StringComparison.OrdinalIgnoreCase) && waypoint2.Type != (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), theAnchor, ignoreCase: true))
					{
						num2 = checked(num2 + 1);
						continue;
					}
					waypoint = waypoint2;
					CoreClientCode.ChangeFightPlanInsertWaypoint_Core(theScen, theSide, theMission, theFlight, Mission.Flight.FlightElement.LeadElement, waypoint);
					num3 = 0;
					break;
				}
				num3 = 0;
				break;
			}
			num = num3;
			if (waypoint == null)
			{
				result = -1;
			}
			else
			{
				Waypoint[] flightPlan2 = theFlight.FlightPlan;
				for (int i = 0; i < flightPlan2.Length; i = checked(i + 1))
				{
					if (flightPlan2[i] != waypoint)
					{
						num++;
						continue;
					}
					UpdateFlightPlanWaypointValues(ref theFlight.FlightPlan[num + 1], ref theWaypoint);
					ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
					Mission.Flight flight;
					Waypoint[] theFlightplan = (flight = theFlight).FlightPlan;
					float NecessaryFuel = 0f;
					float MissionFuel = 0f;
					MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission, theAU, theFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
					flight.FlightPlan = theFlightplan;
					return num + 1;
				}
				result = -1;
			}
		}
		else
		{
			result = -1;
		}
		return result;
	}

	public static int MissionFlightPlanInsertWaypointBefore(string theAnchor, Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, Mission.Flight.FlightElement theFlightElement, Waypoint theWaypoint)
	{
		int result;
		if (theWaypoint != null)
		{
			int num = 0;
			Waypoint waypoint = null;
			Waypoint waypoint2 = null;
			Waypoint[] flightPlan = theFlight.FlightPlan;
			int num2 = 0;
			int num3;
			while (true)
			{
				if (num2 < flightPlan.Length)
				{
					Waypoint waypoint3 = flightPlan[num2];
					if (!string.Equals(waypoint3.ObjectID, theAnchor, StringComparison.OrdinalIgnoreCase) && waypoint3.Type != (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), theAnchor, ignoreCase: true))
					{
						waypoint2 = waypoint3;
						num2 = checked(num2 + 1);
						continue;
					}
					waypoint = waypoint3;
					CoreClientCode.ChangeFightPlanInsertWaypoint_Core(theScen, theSide, theMission, theFlight, Mission.Flight.FlightElement.LeadElement, waypoint2);
					num3 = 0;
					break;
				}
				num3 = 0;
				break;
			}
			num = num3;
			if (waypoint != null)
			{
				Waypoint[] flightPlan2 = theFlight.FlightPlan;
				for (int i = 0; i < flightPlan2.Length; i = checked(i + 1))
				{
					if (flightPlan2[i] != waypoint2)
					{
						num++;
						continue;
					}
					UpdateFlightPlanWaypointValues(ref theFlight.FlightPlan[num - 1], ref theWaypoint);
					ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
					Mission.Flight flight;
					Waypoint[] theFlightplan = (flight = theFlight).FlightPlan;
					float NecessaryFuel = 0f;
					float MissionFuel = 0f;
					MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission, theAU, theFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
					flight.FlightPlan = theFlightplan;
					return num - 1;
				}
				result = -1;
				goto IL_0133;
			}
		}
		result = -1;
		goto IL_0133;
		IL_0133:
		return result;
	}

	public static void UpdateFlightPlanWaypointValues(ref Waypoint oldWP, ref Waypoint newWP)
	{
		if (oldWP.Latitude != newWP.Latitude)
		{
			oldWP.Latitude = newWP.Latitude;
		}
		if (oldWP.Longitude != newWP.Longitude)
		{
			oldWP.Longitude = newWP.Longitude;
		}
		if (oldWP.AltitudePreset != newWP.AltitudePreset)
		{
			oldWP.AltitudePreset = newWP.AltitudePreset;
		}
		if (oldWP.DepthPreset != newWP.DepthPreset)
		{
			oldWP.DepthPreset = newWP.DepthPreset;
		}
		if (oldWP.ThrottlePreset != newWP.ThrottlePreset)
		{
			oldWP.ThrottlePreset = newWP.ThrottlePreset;
		}
		float? desiredAltitude = oldWP.DesiredAltitude;
		float? desiredAltitude2 = newWP.DesiredAltitude;
		if (((desiredAltitude.HasValue & desiredAltitude2.HasValue) ? new bool?(desiredAltitude.GetValueOrDefault() != desiredAltitude2.GetValueOrDefault()) : ((bool?)null)) == true)
		{
			oldWP.DesiredAltitude = newWP.DesiredAltitude;
		}
		desiredAltitude2 = oldWP.DesiredAltitude_TerrainFollowing;
		desiredAltitude = newWP.DesiredAltitude_TerrainFollowing;
		if (((desiredAltitude2.HasValue & desiredAltitude.HasValue) ? new bool?(desiredAltitude2.GetValueOrDefault() != desiredAltitude.GetValueOrDefault()) : ((bool?)null)) == true)
		{
			oldWP.DesiredAltitude_TerrainFollowing = newWP.DesiredAltitude_TerrainFollowing;
		}
		desiredAltitude = oldWP.DesiredSpeed;
		desiredAltitude2 = newWP.DesiredSpeed;
		if (((!(desiredAltitude.HasValue & desiredAltitude2.HasValue)) ? ((bool?)null) : new bool?(desiredAltitude.GetValueOrDefault() != desiredAltitude2.GetValueOrDefault())) == true)
		{
			oldWP.DesiredSpeed = newWP.DesiredSpeed;
		}
		if (oldWP.TerrainFollowing != newWP.TerrainFollowing)
		{
			oldWP.TerrainFollowing = newWP.TerrainFollowing;
		}
		if (Operators.CompareString(oldWP.Name, newWP.Name, false) != 0)
		{
			oldWP.Name = newWP.Name;
		}
		if (Operators.CompareString(oldWP.Description, newWP.Description, false) != 0)
		{
			oldWP.Description = newWP.Description;
		}
		if (oldWP.Type != newWP.Type)
		{
			oldWP.Type = newWP.Type;
		}
	}
}
