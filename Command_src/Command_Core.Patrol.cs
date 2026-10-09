using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Patrol : Mission, IRecurringMission
{
	public enum PatrolMovementStyle
	{
		RandomWithinArea,
		RepeatableLoop,
		ChainsawLoop
	}

	public GlobalVariables.PatrolType Type;

	public List<ReferencePoint> PatrolArea;

	public List<ReferencePoint> PatrolArea_ChangeCheck;

	public List<ReferencePoint> PatrolArea_2nm_ChangeCheck;

	public List<ReferencePoint> PatrolArea_5nm_ChangeCheck;

	public List<ReferencePoint> PatrolArea_10nm_ChangeCheck;

	public List<ReferencePoint> PatrolArea_30nm_ChangeCheck;

	public List<ReferencePoint> PatrolArea_2nm_Buffered;

	public List<ReferencePoint> PatrolArea_5nm_Buffered;

	public List<ReferencePoint> PatrolArea_10nm_Buffered;

	public List<ReferencePoint> PatrolArea_30nm_Buffered;

	public List<ReferencePoint> ProsecutionArea;

	public List<ReferencePoint> ProsecutionArea_ChangeCheck;

	public List<ReferencePoint> ProsecutionArea_2nm_ChangeCheck;

	public List<ReferencePoint> ProsecutionArea_5nm_ChangeCheck;

	public List<ReferencePoint> ProsecutionArea_2nm_Buffered;

	public List<ReferencePoint> ProsecutionArea_5nm_Buffered;

	public bool OneThirdRule;

	public int MinimumNumberOnStation;

	private bool bool_0;

	private bool bool_1;

	public bool ActiveEMCONOnlyInPatrolOrProsecutionArea;

	public bool SprintAndDrift;

	public bool AvoidCavitation;

	private PatrolMovementStyle patrolMovementStyle_0;

	public _FlightQty MinimumNumberOfAircraft;

	private ActiveUnit.Throttle? nullable_0;

	private ActiveUnit.Throttle? nullable_1;

	private ActiveUnit.Throttle? nullable_2;

	private float? nullable_3;

	private float? nullable_4;

	private float? nullable_5;

	private float? nullable_6;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private ActiveUnit_AI.AircraftAltitudePreset? nullable_7;

	private ActiveUnit_AI.AircraftAltitudePreset? nullable_8;

	private ActiveUnit_AI.AircraftAltitudePreset? nullable_9;

	private bool? nullable_10;

	private bool? nullable_11;

	private bool? nullable_12;

	private ActiveUnit.Throttle throttle_0;

	private ActiveUnit.Throttle throttle_1;

	private ActiveUnit.Throttle? nullable_13;

	private float? nullable_14;

	private float? nullable_15;

	private float? nullable_16;

	private float? nullable_17;

	private ActiveUnit_AI.SubmarineDepthPreset? nullable_18;

	private ActiveUnit_AI.SubmarineDepthPreset? nullable_19;

	private ActiveUnit_AI.SubmarineDepthPreset? nullable_20;

	private bool? nullable_21;

	private bool? nullable_22;

	private bool? nullable_23;

	private ActiveUnit.Throttle throttle_2;

	private ActiveUnit.Throttle throttle_3;

	private ActiveUnit.Throttle? nullable_24;

	private float? nullable_25;

	private ActiveUnit.Throttle throttle_4;

	private ActiveUnit.Throttle throttle_5;

	private ActiveUnit.Throttle? nullable_26;

	public _AircraftFormationType Formation_Cruise;

	public _AircraftFormationType Formation_Attack;

	public _FlightQty NumberOfFlights_Investigate;

	public _FlightQty NumberOfFlights_Engage;

	public int WingmanEngageDistance;

	public _GroupQty NumberOfBoats_Investigate;

	public _GroupQty NumberOfBoats_Engage;

	public int GroupMemberEngageDistance;

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

	public PatrolMovementStyle MovementStyle
	{
		get
		{
			return patrolMovementStyle_0;
		}
		set
		{
			if (value == PatrolMovementStyle.ChainsawLoop && (base.TakeOffTime.HasValue | base.TimeOnTarget.HasValue))
			{
				TemporaryChainsawFPCompatibilityHandler(setChainsaw: true);
			}
			patrolMovementStyle_0 = value;
		}
	}

	public bool HasProsecutionArea => ProsecutionArea.Count > 2;

	public bool InvestigateOutsidePatrolArea
	{
		get
		{
			return bool_0;
		}
		set
		{
			try
			{
				bool_0 = value;
				if (value)
				{
					return;
				}
				ActiveUnit[] array = theScen.ActiveUnits_List.InternalArray();
				foreach (ActiveUnit activeUnit in array)
				{
					if (activeUnit == null || activeUnit.ActiveMissionOrPackage() == null || activeUnit.ActiveMissionOrPackage() != this)
					{
						continue;
					}
					Contact[] targets_ReadOnly = activeUnit.AI.Targets_ReadOnly;
					foreach (Contact contact in targets_ReadOnly)
					{
						if (!activeUnit.Weaponry.IsGuidingWeaponsOntoThisContact(contact) && activeUnit.AI.TargetingBehaviorForThisTarget(contact, null) == ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted && !((Module_Unit.Unit)contact).get_IsInsideThisArea(PatrolArea, theScen, UseCache: true))
						{
							activeUnit.AI.DropTarget(contact);
						}
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100645", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public bool InvestigateWithinWeaponRange
	{
		get
		{
			return bool_1;
		}
		set
		{
			try
			{
				bool_1 = value;
				if (value)
				{
					return;
				}
				bool flag = this.get_InvestigateOutsidePatrolArea(theScen);
				bool hasProsecutionArea = HasProsecutionArea;
				if (flag && !hasProsecutionArea)
				{
					return;
				}
				List<ActiveUnit> list = theScen.ActiveUnits_List.ToList();
				foreach (ActiveUnit item in list)
				{
					if (item == null || item.ActiveMissionOrPackage() == null || item.ActiveMissionOrPackage() != this)
					{
						continue;
					}
					Contact[] targets_ReadOnly = item.AI.Targets_ReadOnly;
					if (targets_ReadOnly.Count() <= 0)
					{
						continue;
					}
					Contact[] array = targets_ReadOnly;
					foreach (Contact contact in array)
					{
						if (item.AI.TargetingBehaviorForThisTarget(contact, null) != ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted || item.Weaponry.IsGuidingWeaponsOntoThisContact(contact))
						{
							continue;
						}
						if (flag)
						{
							if (!hasProsecutionArea || ((Module_Unit.Unit)contact).get_IsInsideThisArea(PatrolArea, theScen, UseCache: true) || ((Module_Unit.Unit)contact).get_IsInsideThisArea(ProsecutionArea, theScen, UseCache: true))
							{
								continue;
							}
						}
						else if (((Module_Unit.Unit)contact).get_IsInsideThisArea(PatrolArea, theScen, UseCache: true))
						{
							continue;
						}
						item.AI.DropTarget(contact);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101296", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public override string DescriptionString => Type switch
	{
		GlobalVariables.PatrolType.ASW => "ASW Patrol", 
		GlobalVariables.PatrolType.ASuW_Naval => "ASuW Patrol (Naval)", 
		GlobalVariables.PatrolType.AAW => "AAW Patrol", 
		GlobalVariables.PatrolType.ASuW_Land => "ASuW Patrol (Ground)", 
		GlobalVariables.PatrolType.ASuW_Mixed => "ASuW Patrol (Mixed)", 
		GlobalVariables.PatrolType.SEAD => "SEAD Patrol", 
		GlobalVariables.PatrolType.SeaControl => "Sea Control Patrol", 
		_ => Type.ToString(), 
	};

	public Group ParentGroup
	{
		get
		{
			foreach (Group group in theScen.Groups)
			{
				if (group.Patrols.Contains(this))
				{
					return group;
				}
			}
			return null;
		}
	}

	public ActiveUnit.Throttle? TransitThrottle_Aircraft
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

	public ActiveUnit.Throttle? StationThrottle_Aircraft
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

	public ActiveUnit.Throttle? AttackThrottle_Aircraft
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

	public float? TransitAltitude_Aircraft
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

	public float? StationAltitude_Aircraft
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

	public float? AttackAltitude_Aircraft
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

	public float? AttackDistance_Aircraft
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

	public bool TransitTerrainFollowing_Aircraft
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool StationTerrainFollowing_Aircraft
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool AttackTerrainFollowing_Aircraft
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public ActiveUnit.Throttle TransitThrottle_Submarine
	{
		get
		{
			return throttle_0;
		}
		set
		{
			throttle_0 = value;
		}
	}

	public ActiveUnit.Throttle StationThrottle_Submarine
	{
		get
		{
			return throttle_1;
		}
		set
		{
			throttle_1 = value;
		}
	}

	public ActiveUnit.Throttle? AttackThrottle_Submarine
	{
		get
		{
			return nullable_13;
		}
		set
		{
			nullable_13 = value;
		}
	}

	public float? TransitDepth_Submarine
	{
		get
		{
			return nullable_14;
		}
		set
		{
			nullable_14 = value;
		}
	}

	public float? StationDepth_Submarine
	{
		get
		{
			return nullable_15;
		}
		set
		{
			nullable_15 = value;
		}
	}

	public float? AttackDepth_Submarine
	{
		get
		{
			return nullable_16;
		}
		set
		{
			nullable_16 = value;
		}
	}

	public bool? UseStationDepth_Submarine_Preset
	{
		get
		{
			return nullable_22;
		}
		set
		{
			nullable_22 = value;
		}
	}

	public bool? UseAttackDepth_Submarine_Preset
	{
		get
		{
			return nullable_23;
		}
		set
		{
			nullable_23 = value;
		}
	}

	public bool? UseTransitDepth_Submarine_Preset
	{
		get
		{
			return nullable_21;
		}
		set
		{
			nullable_21 = value;
		}
	}

	public ActiveUnit_AI.SubmarineDepthPreset? StationDepth_Submarine_Preset
	{
		get
		{
			return nullable_19;
		}
		set
		{
			nullable_19 = value;
		}
	}

	public ActiveUnit_AI.SubmarineDepthPreset? AttackDepth_Submarine_Preset
	{
		get
		{
			return nullable_20;
		}
		set
		{
			nullable_20 = value;
		}
	}

	public ActiveUnit_AI.SubmarineDepthPreset? TransitDepth_Submarine_Preset
	{
		get
		{
			return nullable_18;
		}
		set
		{
			nullable_18 = value;
		}
	}

	public float? AttackDistance_Submarine
	{
		get
		{
			return nullable_17;
		}
		set
		{
			nullable_17 = value;
		}
	}

	public bool? UseTransitAltitude_Preset
	{
		get
		{
			return nullable_10;
		}
		set
		{
			nullable_10 = value;
		}
	}

	public bool? UseStationAltitude_Preset
	{
		get
		{
			return nullable_11;
		}
		set
		{
			nullable_11 = value;
		}
	}

	public bool? UseAttackAltitude_Preset
	{
		get
		{
			return nullable_12;
		}
		set
		{
			nullable_12 = value;
		}
	}

	public ActiveUnit_AI.AircraftAltitudePreset? TransitAltitude_Preset
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

	public ActiveUnit_AI.AircraftAltitudePreset? StationAltitude_Preset
	{
		get
		{
			return nullable_8;
		}
		set
		{
			nullable_8 = value;
		}
	}

	public ActiveUnit_AI.AircraftAltitudePreset? AttackAltitude_Preset
	{
		get
		{
			return nullable_9;
		}
		set
		{
			nullable_9 = value;
		}
	}

	public ActiveUnit.Throttle TransitThrottle_Ship
	{
		get
		{
			return throttle_2;
		}
		set
		{
			throttle_2 = value;
		}
	}

	public ActiveUnit.Throttle StationThrottle_Ship
	{
		get
		{
			return throttle_3;
		}
		set
		{
			throttle_3 = value;
		}
	}

	public ActiveUnit.Throttle? AttackThrottle_Ship
	{
		get
		{
			return nullable_24;
		}
		set
		{
			nullable_24 = value;
		}
	}

	public float? AttackDistance_Ship
	{
		get
		{
			return nullable_25;
		}
		set
		{
			nullable_25 = value;
		}
	}

	public ActiveUnit.Throttle TransitThrottle_Facility
	{
		get
		{
			return throttle_4;
		}
		set
		{
			throttle_4 = value;
		}
	}

	public ActiveUnit.Throttle StationThrottle_Facility
	{
		get
		{
			return throttle_5;
		}
		set
		{
			throttle_5 = value;
		}
	}

	public ActiveUnit.Throttle? AttackThrottle_Facility
	{
		get
		{
			return nullable_26;
		}
		set
		{
			nullable_26 = value;
		}
	}

	internal override void Reinitialize()
	{
		base.Reinitialize();
		PatrolArea.Clear();
		ProsecutionArea.Clear();
		MinimumNumberOnStation = 0;
		TransitThrottle_Aircraft = null;
		StationThrottle_Aircraft = null;
		AttackThrottle_Aircraft = null;
		TransitAltitude_Aircraft = null;
		StationAltitude_Aircraft = null;
		AttackAltitude_Aircraft = null;
		AttackDistance_Aircraft = null;
		UseAttackAltitude_Preset = null;
		UseStationAltitude_Preset = null;
		UseTransitAltitude_Preset = null;
		AttackAltitude_Preset = null;
		StationAltitude_Preset = null;
		TransitAltitude_Preset = null;
		AttackThrottle_Submarine = null;
		TransitDepth_Submarine = null;
		StationDepth_Submarine = null;
		AttackDepth_Submarine = null;
		AttackDistance_Submarine = null;
		AttackDepth_Submarine_Preset = null;
		TransitDepth_Submarine_Preset = null;
		StationDepth_Submarine_Preset = null;
		UseTransitDepth_Submarine_Preset = null;
		UseStationDepth_Submarine_Preset = null;
		UseAttackDepth_Submarine_Preset = null;
		AttackThrottle_Ship = null;
		AttackDistance_Ship = null;
		AttackThrottle_Facility = null;
		ContinousCoverage_Stations = null;
		ContinousCoverage_QRAs = null;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("Patrol");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Name", Name);
			theWriter.WriteElementString("Category", ((byte)Category).ToString());
			XmlWriter obj = theWriter;
			int type = (int)Type;
			obj.WriteElementString("Type", type.ToString());
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
			List<ReferencePoint> patrolArea = PatrolArea;
			if (patrolArea != null && patrolArea.Count > 0)
			{
				theWriter.WriteStartElement("PatrolArea");
				foreach (ReferencePoint item in PatrolArea)
				{
					theWriter.WriteRaw(item.ToXML(ref ObjectsAlreadySerialized));
				}
				theWriter.WriteEndElement();
			}
			List<ReferencePoint> prosecutionArea = ProsecutionArea;
			if (prosecutionArea != null && prosecutionArea.Count > 0)
			{
				theWriter.WriteStartElement("ProsecutionArea");
				foreach (ReferencePoint item2 in ProsecutionArea)
				{
					theWriter.WriteRaw(item2.ToXML(ref ObjectsAlreadySerialized));
				}
				theWriter.WriteEndElement();
			}
			theWriter.WriteElementString("OTR", OneThirdRule.ToString());
			if (MinimumNumberOnStation > 0)
			{
				theWriter.WriteElementString("MNOS", MinimumNumberOnStation.ToString());
			}
			theWriter.WriteElementString("IOPA", bool_0.ToString());
			theWriter.WriteElementString("IWWR", bool_1.ToString());
			theWriter.WriteElementString("AEOIPA", ActiveEMCONOnlyInPatrolOrProsecutionArea.ToString());
			theWriter.WriteElementString("SAD", SprintAndDrift.ToString());
			theWriter.WriteElementString("AvCav", AvoidCavitation.ToString());
			if (SecondaryAirBase != null)
			{
				theWriter.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				theWriter.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			if (TransitThrottle_Aircraft.HasValue)
			{
				theWriter.WriteElementString("TransitThrottle_Aircraft", ((byte)TransitThrottle_Aircraft.Value).ToString());
			}
			if (StationThrottle_Aircraft.HasValue)
			{
				theWriter.WriteElementString("StationThrottle_Aircraft", ((byte)StationThrottle_Aircraft.Value).ToString());
			}
			if (AttackThrottle_Aircraft.HasValue)
			{
				theWriter.WriteElementString("AttackThrottle_Aircraft", ((byte)AttackThrottle_Aircraft.Value).ToString());
			}
			if (TransitAltitude_Aircraft.HasValue)
			{
				theWriter.WriteElementString("TransitAltitude_Aircraft", TransitAltitude_Aircraft.Value.ToString());
			}
			if (StationAltitude_Aircraft.HasValue)
			{
				theWriter.WriteElementString("StationAltitude_Aircraft", StationAltitude_Aircraft.Value.ToString());
			}
			if (AttackAltitude_Aircraft.HasValue)
			{
				theWriter.WriteElementString("AttackAltitude_Aircraft", AttackAltitude_Aircraft.Value.ToString());
			}
			if (AttackDistance_Aircraft.HasValue)
			{
				theWriter.WriteElementString("AttackDistance_Aircraft", AttackDistance_Aircraft.Value.ToString());
			}
			if (UseAttackAltitude_Preset.HasValue)
			{
				theWriter.WriteElementString("UseAttackAltitude_Preset", ((byte)(0u - (UseAttackAltitude_Preset.Value ? 1u : 0u))).ToString());
			}
			if (UseStationAltitude_Preset.HasValue)
			{
				theWriter.WriteElementString("UseStationAltitude_Preset", ((byte)(0u - (UseStationAltitude_Preset.Value ? 1u : 0u))).ToString());
			}
			if (UseTransitAltitude_Preset.HasValue)
			{
				theWriter.WriteElementString("UseTransitAltitude_Preset", ((byte)(0u - (UseTransitAltitude_Preset.Value ? 1u : 0u))).ToString());
			}
			if (AttackAltitude_Preset.HasValue)
			{
				theWriter.WriteElementString("AttackAltitude_Preset", ((byte)AttackAltitude_Preset.Value).ToString());
			}
			if (StationAltitude_Preset.HasValue)
			{
				theWriter.WriteElementString("StationAltitude_Preset", ((byte)StationAltitude_Preset.Value).ToString());
			}
			if (TransitAltitude_Preset.HasValue)
			{
				theWriter.WriteElementString("TransitAltitude_Preset", ((byte)TransitAltitude_Preset.Value).ToString());
			}
			theWriter.WriteElementString("TransitTerrainFollowing_Aircraft", TransitTerrainFollowing_Aircraft.ToString());
			theWriter.WriteElementString("StationTerrainFollowing_Aircraft", StationTerrainFollowing_Aircraft.ToString());
			theWriter.WriteElementString("AttackTerrainFollowing_Aircraft", AttackTerrainFollowing_Aircraft.ToString());
			theWriter.WriteElementString("TransitThrottle_Submarine", ((byte)TransitThrottle_Submarine).ToString());
			theWriter.WriteElementString("StationThrottle_Submarine", ((byte)StationThrottle_Submarine).ToString());
			if (AttackThrottle_Submarine.HasValue)
			{
				theWriter.WriteElementString("AttackThrottle_Submarine", ((byte)AttackThrottle_Submarine.Value).ToString());
			}
			if (TransitDepth_Submarine.HasValue)
			{
				theWriter.WriteElementString("TransitDepth_Submarine", TransitDepth_Submarine.Value.ToString());
			}
			if (StationDepth_Submarine.HasValue)
			{
				theWriter.WriteElementString("StationDepth_Submarine", StationDepth_Submarine.Value.ToString());
			}
			if (AttackDepth_Submarine.HasValue)
			{
				theWriter.WriteElementString("AttackDepth_Submarine", AttackDepth_Submarine.Value.ToString());
			}
			if (AttackDistance_Submarine.HasValue)
			{
				theWriter.WriteElementString("AttackDistance_Submarine", AttackDistance_Submarine.Value.ToString());
			}
			if (AttackDepth_Submarine_Preset.HasValue)
			{
				theWriter.WriteElementString("AttackDepth_Submarine_Preset", ((byte)AttackDepth_Submarine_Preset.Value).ToString());
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
			if (UseAttackDepth_Submarine_Preset.HasValue)
			{
				theWriter.WriteElementString("UseAttackDepth_Submarine_Preset", UseAttackDepth_Submarine_Preset.Value.ToString());
			}
			theWriter.WriteElementString("TransitThrottle_Ship", ((byte)TransitThrottle_Ship).ToString());
			theWriter.WriteElementString("StationThrottle_Ship", ((byte)StationThrottle_Ship).ToString());
			if (AttackThrottle_Ship.HasValue)
			{
				theWriter.WriteElementString("AttackThrottle_Ship", ((byte)AttackThrottle_Ship.Value).ToString());
			}
			if (AttackDistance_Ship.HasValue)
			{
				theWriter.WriteElementString("AttackDistance_Ship", AttackDistance_Ship.Value.ToString());
			}
			theWriter.WriteElementString("TransitThrottle_Facility", ((byte)TransitThrottle_Facility).ToString());
			theWriter.WriteElementString("StationThrottle_Facility", ((byte)StationThrottle_Facility).ToString());
			if (AttackThrottle_Facility.HasValue)
			{
				theWriter.WriteElementString("AttackThrottle_Facility", ((byte)AttackThrottle_Facility.Value).ToString());
			}
			theWriter.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			theWriter.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			theWriter.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			theWriter.WriteElementString("IncludeInATO", IncludeInATO.ToString());
			if (base.get_Status(theScen) != MissionStatus.Active)
			{
				theWriter.WriteElementString("Status", ((byte)base.get_Status(theScen)).ToString());
			}
			theWriter.WriteElementString("FlightSize", ((int)base.FlightSize).ToString());
			theWriter.WriteElementString("GroupSize", ((int)GroupSize).ToString());
			XmlWriter obj2 = theWriter;
			type = (int)Formation_Cruise;
			obj2.WriteElementString("Formation_Cruise", type.ToString());
			XmlWriter obj3 = theWriter;
			type = (int)Formation_Attack;
			obj3.WriteElementString("Formation_Attack", type.ToString());
			XmlWriter obj4 = theWriter;
			type = (int)MinimumNumberOfAircraft;
			obj4.WriteElementString("MinAircraftReq", type.ToString());
			theWriter.WriteElementString("UseFlightSizeHardLimit", UseFlightSizeHardLimit.ToString());
			theWriter.WriteElementString("UseGroupSizeHardLimit", UseGroupSizeHardLimit.ToString());
			XmlWriter obj5 = theWriter;
			byte tankerUsage = (byte)TankerUsage;
			obj5.WriteElementString("TankerUsage", tankerUsage.ToString());
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
			XmlWriter obj6 = theWriter;
			type = (int)NumberOfFlights_Investigate;
			obj6.WriteElementString("NumberOfFlights_Investigate", type.ToString());
			XmlWriter obj7 = theWriter;
			type = (int)NumberOfFlights_Engage;
			obj7.WriteElementString("NumberOfFlights_Engage", type.ToString());
			theWriter.WriteElementString("WingmanEngageDistance", WingmanEngageDistance.ToString());
			XmlWriter obj8 = theWriter;
			type = (int)NumberOfBoats_Investigate;
			obj8.WriteElementString("NumberOfBoats_Investigate", type.ToString());
			XmlWriter obj9 = theWriter;
			type = (int)NumberOfBoats_Engage;
			obj9.WriteElementString("NumberOfBoats_Engage", type.ToString());
			theWriter.WriteElementString("GroupMemberEngageDistance", GroupMemberEngageDistance.ToString());
			theWriter.WriteElementString("ContinousCoverage_Enable", ContinousCoverage_Enable.ToString());
			theWriter.WriteElementString("ContinousCoverage_AllowQRA", ContinousCoverage_QRAEnable.ToString());
			XmlWriter obj10 = theWriter;
			type = (int)ContinousCoverage_FlightGenerationMethod;
			obj10.WriteElementString("ContinousCoverage_FlightGenerationMethod", type.ToString());
			XmlWriter obj11 = theWriter;
			type = (int)ContinousCoverage_StationTime;
			obj11.WriteElementString("ContinousCoverage_StationTime", type.ToString());
			XmlWriter obj12 = theWriter;
			type = (int)ContinousCoverage_Overlap;
			obj12.WriteElementString("ContinousCoverage_Overlap", type.ToString());
			XmlWriter obj13 = theWriter;
			type = (int)ContinousCoverage_Duration;
			obj13.WriteElementString("ContinousCoverage_Duration", type.ToString());
			if (!Information.IsNothing((object)ContinousCoverage_Stations) && ContinousCoverage_Stations.Count > 0)
			{
				theWriter.WriteStartElement("CCSList");
				ContinousCoverageStation.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref theScen, ref ContinousCoverage_Stations);
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)ContinousCoverage_QRAs) && ContinousCoverage_QRAs.Count > 0)
			{
				theWriter.WriteStartElement("QRAs");
				ContinousCoverageStation.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref theScen, ref ContinousCoverage_QRAs);
				theWriter.WriteEndElement();
			}
			XmlWriter obj14 = theWriter;
			type = (int)ContinousCoverage_QRANumberOfFlights;
			obj14.WriteElementString("ContinousCoverage_QRANumberOfFlights", type.ToString());
			XmlWriter obj15 = theWriter;
			type = (int)ContinousCoverage_QRAFlightGenerationMethod;
			obj15.WriteElementString("ContinousCoverage_QRAFlightGenerationMethod", type.ToString());
			XmlWriter obj16 = theWriter;
			type = (int)ContinousCoverage_NumberOfFlightsNeededToAllowQRA;
			obj16.WriteElementString("ContinousCoverage_NumberOfFlightsNeededToAllowQRA", type.ToString());
			theWriter.WriteElementString("MovementStyle", ((int)MovementStyle).ToString());
			XmlWriter obj17 = theWriter;
			type = (int)OneThirdGrouping;
			obj17.WriteElementString("OneThirdStrictness", type.ToString());
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
			ex2?.Data.Add("Error at 100643", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Patrol FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, Mission existingObject = null)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_1726: Unknown result type (might be due to invalid IL or missing references)
		//IL_172d: Expected O, but got Unknown
		//IL_0fb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbe: Expected O, but got Unknown
		//IL_085b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0862: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		Patrol result;
		try
		{
			bool flag;
			Patrol patrol;
			int num;
			if (!(flag = existingObject != null))
			{
				patrol = new Patrol(null, theScen, "");
				num = 0;
			}
			else
			{
				patrol = (Patrol)existingObject;
				patrol.Reinitialize();
				num = 0;
			}
			bool flag2 = (byte)num != 0;
			patrol.StationThrottle_Aircraft = ActiveUnit.Throttle.Loiter;
			patrol.bool_1 = true;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				Mission.FromXMLCommon(patrol, theNode2);
				switch (theNode2.Name)
				{
				case "PatrolArea":
					if (flag)
					{
						patrol.PatrolArea.Clear();
					}
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode theNode4 = childNode2;
						patrol.PatrolArea.Add(ReferencePoint.FromXML(ref theNode4, ref theDictionary, theScen));
					}
					break;
				case "Status":
					((Mission)patrol).set_Status(theScen, (MissionStatus)Conversions.ToByte(theNode2.InnerText));
					break;
				case "AttackAltitude_Preset":
					patrol.AttackAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "ContinousCoverage_QRANumberOfFlights":
					patrol.ContinousCoverage_QRANumberOfFlights = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TransitTerrainFollowing_Aircraft":
					patrol.TransitTerrainFollowing_Aircraft = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TransitDepth_Submarine_Preset":
					patrol.TransitDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "CCSList":
					patrol.ContinousCoverage_Stations = ContinousCoverageStation.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "Name":
					patrol.Name = theNode2.InnerText;
					break;
				case "START":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					patrol._StartTime = value;
					break;
				}
				case "UseFlightplan":
					patrol.UseFlightplans = Misc.ParseBool(theNode2.InnerText);
					break;
				case "IncludeInATO":
					patrol.IncludeInATO = Misc.ParseBool(theNode2.InnerText);
					flag2 = true;
					break;
				case "NumberOfBoats_Engage":
					patrol.NumberOfBoats_Engage = (_GroupQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "SISIH":
					patrol.ScrubIfSideIsHuman = Misc.ParseBool(theNode2.InnerText);
					break;
				case "UseGroupSizeHardLimit":
					patrol.UseGroupSizeHardLimit = Misc.ParseBool(theNode2.InnerText);
					break;
				case "ContinousCoverage_Overlap":
					patrol.ContinousCoverage_Overlap = (_ContinousCoverageOverlap)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "WingmanEngageDistance":
					patrol.WingmanEngageDistance = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TankerMinNumber_Airborne":
					patrol.TankerMinNumber_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TankerMaxDistance_Airborne":
					patrol.TankerMaxDistance_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "SAD":
					patrol.SprintAndDrift = Misc.ParseBool(theNode2.InnerText);
					break;
				case "GroupMemberEngageDistance":
					patrol.GroupMemberEngageDistance = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TransitThrottle_Ship":
					patrol.TransitThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "LaunchMissionWithoutTankersInPlace":
					patrol.LaunchMissionWithoutTankersInPlace = Misc.ParseBool(theNode2.InnerText);
					break;
				case "IWWR":
					patrol.bool_1 = Misc.ParseBool(theNode2.InnerText);
					break;
				case "OTR":
				case "OneThirdRule":
					patrol.OneThirdRule = Misc.ParseBool(theNode2.InnerText);
					break;
				case "UseTransitDepth_Submarine_Preset":
					patrol.UseTransitDepth_Submarine_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "MNOS":
					patrol.MinimumNumberOnStation = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "AttackThrottle_Facility":
					patrol.AttackThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "UseFlightplansOnly":
					patrol.UsePreGeneratedFlightplansOnly = Misc.ParseBool(theNode2.InnerText);
					break;
				case "ProsecutionArea":
					if (flag)
					{
						patrol.ProsecutionArea.Clear();
					}
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode3;
						patrol.ProsecutionArea.Add(ReferencePoint.FromXML(ref theNode3, ref theDictionary, theScen));
					}
					break;
				case "TankerMinNumber_Total":
					patrol.TankerMinNumber_Total = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TimeOnTarget":
				{
					DateTime value4 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					patrol.TimeOnTarget = value4;
					break;
				}
				case "EmptySlotsList":
					patrol.EmptySlotsList = EmptyAircraftSlot.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "HomeNavalbase":
					patrol._SecondaryNavalBaseID = theNode2.InnerText;
					break;
				case "StationThrottle_Ship":
					patrol.StationThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "AttackTerrainFollowing_Aircraft":
					patrol.AttackTerrainFollowing_Aircraft = Misc.ParseBool(theNode2.InnerText);
					break;
				case "AvCav":
					patrol.AvoidCavitation = Misc.ParseBool(theNode2.InnerText);
					break;
				case "ID":
					if (!theDictionary.ContainsKey(theNode2.InnerText))
					{
						patrol.ObjectID_Set(theNode2.InnerText);
						theDictionary.TryAdd(patrol.ObjectID, patrol);
						break;
					}
					result = (Patrol)theDictionary[theNode2.InnerText];
					goto end_IL_0001;
				case "Doctrine":
					if (flag)
					{
						patrol.Doctrine = Doctrine.FromXML(theScen, ref theNode2, patrol, patrol.Doctrine);
					}
					else
					{
						patrol.Doctrine = Doctrine.FromXML(theScen, ref theNode2, patrol);
					}
					break;
				case "TakeOffTime":
				{
					DateTime value3 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					patrol.TakeOffTime = value3;
					break;
				}
				case "ContinousCoverage_Enable":
					patrol.ContinousCoverage_Enable = Misc.ParseBool(theNode2.InnerText);
					break;
				case "AttackDistance_Submarine":
					patrol.AttackDistance_Submarine = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "AttackThrottle_Ship":
					patrol.AttackThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationThrottle_Facility":
					patrol.StationThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TankerMinNumber_Station":
					patrol.TankerMinNumber_Station = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "NumberOfFlights_Engage":
					patrol.NumberOfFlights_Engage = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "AttackThrottle_Submarine":
					patrol.AttackThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "UseAttackAltitude_Preset":
					patrol.UseAttackAltitude_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "AttackDepth_Submarine":
					patrol.AttackDepth_Submarine = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "QRAs":
					patrol.ContinousCoverage_QRAs = ContinousCoverageStation.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "AttackAltitude_Aircraft":
					patrol.AttackAltitude_Aircraft = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "FlightList":
					patrol.FlightList = Flight.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "FuelQtyToStartLookingForTanker_Airborne":
					patrol.FuelQtyToStartLookingForTanker_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "ContinousCoverage_NumberOfFlightsNeededToAllowQRA":
					patrol.ContinousCoverage_NumberOfFlightsNeededToAllowQRA = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "FlightSize":
					patrol.FlightSize = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TankerMissionList":
					if (flag)
					{
						patrol.TankerMissions_IDs.Clear();
					}
					foreach (XmlNode childNode4 in theNode2.ChildNodes)
					{
						XmlNode val2 = childNode4;
						patrol.TankerMissions_IDs.Add(val2.InnerText);
					}
					break;
				case "UseFlightSizeHardLimit":
					patrol.UseFlightSizeHardLimit = Misc.ParseBool(theNode2.InnerText);
					break;
				case "ContinousCoverage_QRAFlightGenerationMethod":
					patrol.ContinousCoverage_QRAFlightGenerationMethod = (_ContinousCoverageMethod)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "AttackDistance_Aircraft":
					patrol.AttackDistance_Aircraft = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "UseTransitAltitude_Preset":
					patrol.UseTransitAltitude_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "HomeAirbase":
					patrol._SecondaryAirBaseID = theNode2.InnerText;
					break;
				case "TransitDepth_Submarine":
					patrol.TransitDepth_Submarine = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "NumberOfFlights_Investigate":
					patrol.NumberOfFlights_Investigate = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "ContinousCoverage_FlightGenerationMethod":
					patrol.ContinousCoverage_FlightGenerationMethod = (_ContinousCoverageMethod)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TransitAltitude_Preset":
					patrol.TransitAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "END":
				{
					DateTime value2 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					patrol._EndTime = value2;
					break;
				}
				case "TransitThrottle_Facility":
					patrol.TransitThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "UseAttackDepth_Submarine_Preset":
					patrol.UseAttackDepth_Submarine_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "AttackDistance_Ship":
					patrol.AttackDistance_Ship = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "Category":
					patrol.Category = (MissionCategory)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Formation_Attack":
					patrol.Formation_Attack = (_AircraftFormationType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MovementStyle":
					patrol.MovementStyle = (PatrolMovementStyle)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "AttackThrottle_Aircraft":
					patrol.AttackThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "_Phase":
					patrol._Phase = (MissionPhase)Conversions.ToByte(theNode2.InnerText);
					break;
				case "PriorityWeight":
					patrol.PriorityWeight = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "ContinousCoverage_StationTime":
					patrol.ContinousCoverage_StationTime = (_ContinousCoverageStationTime)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "KeepOnMissionWithoutTankersInPlace":
					patrol.KeepOnMissionWithoutTankersInPlace = Misc.ParseBool(theNode2.InnerText);
					break;
				case "UseStationDepth_Submarine_Preset":
					patrol.UseStationDepth_Submarine_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "NumberOfBoats_Investigate":
					patrol.NumberOfBoats_Investigate = (_GroupQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Type":
					if (!Versioned.IsNumeric((object)theNode2.InnerText))
					{
						patrol.Type = (GlobalVariables.PatrolType)Enum.Parse(typeof(GlobalVariables.PatrolType), theNode2.InnerText, ignoreCase: true);
					}
					else
					{
						patrol.Type = (GlobalVariables.PatrolType)Conversions.ToByte(theNode2.InnerText);
					}
					break;
				case "ContinousCoverage_Duration":
					patrol.ContinousCoverage_Duration = (_ContinousCoverageDuration)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "InvestigateOutsidePatrolArea":
				case "IOPA":
					patrol.bool_0 = Misc.ParseBool(theNode2.InnerText);
					break;
				case "OneThirdStrictness":
					patrol.OneThirdGrouping = (OneThirdGroupingType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "AssignedUnitsList":
					foreach (XmlNode childNode5 in theNode2.ChildNodes)
					{
						XmlNode val = childNode5;
						patrol.UnitsAssignedToMissionIDs.Add(val.InnerText);
					}
					break;
				case "StationDepth_Submarine_Preset":
					patrol.StationDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TankerUsage":
					patrol.TankerUsage = (TankerMethod)Conversions.ToByte(theNode2.InnerText);
					break;
				case "AEOIPA":
				case "ActiveEMCONOnlyInPatrolArea":
					patrol.ActiveEMCONOnlyInPatrolOrProsecutionArea = Misc.ParseBool(theNode2.InnerText);
					break;
				case "AttackDepth_Submarine_Preset":
					patrol.AttackDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationThrottle_Submarine":
					patrol.StationThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationThrottle":
				case "PatrolThrottle":
				case "StationThrottle_Aircraft":
					patrol.StationThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "MinAircraftReq":
					patrol.MinimumNumberOfAircraft = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "OAO":
				case "StationAltitude_Aircraft":
				case "StationAltitude":
					patrol.StationAltitude_Aircraft = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "TankerFollowsReceivers":
					patrol.TankerFollowsReceivers = Misc.ParseBool(theNode2.InnerText);
					break;
				case "GroupSize":
					patrol.GroupSize = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TAO":
				case "TransitAltitude":
				case "TransitAltitude_Aircraft":
					patrol.TransitAltitude_Aircraft = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "Formation_Cruise":
					patrol.Formation_Cruise = (_AircraftFormationType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "UseStationAltitude_Preset":
					patrol.UseStationAltitude_Preset = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Completion":
					patrol.Completion = Conversions.ToSingle(theNode2.InnerText);
					break;
				case "TransitThrottle_Submarine":
					patrol.TransitThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "ContinousCoverage_AllowQRA":
					patrol.ContinousCoverage_QRAEnable = Misc.ParseBool(theNode2.InnerText);
					break;
				case "StationAltitude_Preset":
					patrol.StationAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "StationTerrainFollowing_Aircraft":
					patrol.StationTerrainFollowing_Aircraft = Misc.ParseBool(theNode2.InnerText);
					break;
				case "MaxReceiversInQueuePerTanker_Airborne":
					patrol.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "StationDepth_Submarine":
					patrol.StationDepth_Submarine = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "TransitThrottle":
				case "TransitThrottle_Aircraft":
					patrol.TransitThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				}
			}
			if (patrol.FlightSize == 0)
			{
				Patrol patrol2 = patrol;
				if (patrol2.Type == GlobalVariables.PatrolType.SEAD)
				{
					patrol.Doctrine.set_ShootTourists(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseShootTourists?)Doctrine._UseShootTourists.No);
				}
				if (patrol2.Type == GlobalVariables.PatrolType.ASW || patrol2.Type == GlobalVariables.PatrolType.ASuW_Mixed || patrol2.Type == GlobalVariables.PatrolType.ASuW_Naval)
				{
					patrol.Doctrine.set_WeaponControlStatus_Submarine(theScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)Doctrine._WCS.Free);
				}
			}
			byte? b = (byte?)patrol.TransitThrottle_Aircraft;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
			{
				patrol.TransitThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
			}
			if (patrol.TransitThrottle_Submarine == ActiveUnit.Throttle.FullStop)
			{
				if (patrol.Type == GlobalVariables.PatrolType.ASW)
				{
					patrol.Doctrine.WinchesterShotgunRTB = Doctrine._WeaponStateRTB.No;
					patrol.Doctrine.BingoJokerRTB = Doctrine._FuelStateRTB.YesFirstUnit;
				}
				else
				{
					patrol.Doctrine.WinchesterShotgunRTB = Doctrine._WeaponStateRTB.YesLastUnit;
					patrol.Doctrine.BingoJokerRTB = Doctrine._FuelStateRTB.YesFirstUnit;
				}
				patrol.AttackThrottle_Aircraft = null;
				patrol.TransitTerrainFollowing_Aircraft = false;
				patrol.StationTerrainFollowing_Aircraft = false;
				patrol.AttackTerrainFollowing_Aircraft = false;
				patrol.TransitThrottle_Submarine = ActiveUnit.Throttle.Cruise;
				patrol.StationThrottle_Submarine = ActiveUnit.Throttle.Loiter;
				patrol.AttackThrottle_Submarine = null;
				patrol.TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
				patrol.StationThrottle_Ship = ActiveUnit.Throttle.Loiter;
				patrol.AttackThrottle_Ship = null;
				patrol.TransitThrottle_Facility = ActiveUnit.Throttle.Cruise;
				patrol.StationThrottle_Facility = ActiveUnit.Throttle.Loiter;
				patrol.AttackThrottle_Facility = null;
			}
			if (patrol.Doctrine.ReplenishmentSelection_Inherits())
			{
				patrol.Doctrine.set_ReplenishmentSelection(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UnderwayRefuelAndReplenishmentSelection?)Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
			}
			if (patrol.TransitAltitude_Aircraft.HasValue && (!patrol.TransitAltitude_Preset.HasValue || patrol.TransitAltitude_Preset.Value != ActiveUnit_AI.AircraftAltitudePreset.Custom))
			{
				patrol.UseTransitAltitude_Preset = false;
				patrol.TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			else
			{
				bool? flag4;
				bool? flag3 = (flag4 = !patrol.UseTransitAltitude_Preset);
				bool? obj;
				if (flag3.HasValue && flag4 != true)
				{
					obj = false;
				}
				else
				{
					b = (byte?)patrol.TransitAltitude_Preset;
					bool? flag5;
					flag3 = (flag5 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() != 0)));
					obj = ((!flag3.HasValue) ? ((bool?)null) : ((flag5 == true) & flag4));
				}
				bool? flag6 = obj;
				if (flag6 ?? true)
				{
					b = (byte?)patrol.TransitAltitude_Preset;
					if (((!b.HasValue) ? ((bool?)null) : new bool?((uint)b.GetValueOrDefault() < 8u)) == true && flag6.HasValue)
					{
						patrol.UseTransitAltitude_Preset = true;
					}
				}
			}
			if (patrol.StationAltitude_Aircraft.HasValue && (!patrol.StationAltitude_Preset.HasValue || patrol.StationAltitude_Preset.Value != ActiveUnit_AI.AircraftAltitudePreset.Custom))
			{
				patrol.UseStationAltitude_Preset = false;
				patrol.StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			else
			{
				bool? flag5;
				bool? flag3 = (flag5 = !patrol.UseStationAltitude_Preset);
				bool? obj2;
				if (flag3.HasValue && flag5 != true)
				{
					obj2 = false;
				}
				else
				{
					b = (byte?)patrol.StationAltitude_Preset;
					bool? flag4;
					flag3 = (flag4 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() != 0)));
					obj2 = ((!flag3.HasValue) ? ((bool?)null) : ((flag4 == true) & flag5));
				}
				bool? flag6 = obj2;
				if (flag6 ?? true)
				{
					b = (byte?)patrol.StationAltitude_Preset;
					if (((!b.HasValue) ? ((bool?)null) : new bool?((uint)b.GetValueOrDefault() < 8u)) == true && flag6.HasValue)
					{
						patrol.UseStationAltitude_Preset = true;
					}
				}
			}
			if (patrol.AttackAltitude_Aircraft.HasValue && (!patrol.AttackAltitude_Preset.HasValue || patrol.AttackAltitude_Preset.Value != ActiveUnit_AI.AircraftAltitudePreset.Custom))
			{
				patrol.UseAttackAltitude_Preset = false;
				patrol.AttackAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			else
			{
				bool? flag4;
				bool? flag3 = (flag4 = !patrol.UseAttackAltitude_Preset);
				bool? obj3;
				if (flag3.HasValue && flag4 != true)
				{
					obj3 = false;
				}
				else
				{
					b = (byte?)patrol.AttackAltitude_Preset;
					bool? flag5;
					flag3 = (flag5 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() != 0)));
					obj3 = ((!flag3.HasValue) ? ((bool?)null) : ((flag5 == true) & flag4));
				}
				bool? flag6 = obj3;
				if (flag6 ?? true)
				{
					b = (byte?)patrol.AttackAltitude_Preset;
					if (((!b.HasValue) ? ((bool?)null) : new bool?((uint)b.GetValueOrDefault() < 8u)) == true && flag6.HasValue)
					{
						patrol.UseAttackAltitude_Preset = true;
					}
				}
			}
			if (patrol.TransitDepth_Submarine.HasValue && patrol.UseTransitDepth_Submarine_Preset == true)
			{
				patrol.UseTransitDepth_Submarine_Preset = false;
				patrol.TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (patrol.StationDepth_Submarine.HasValue && patrol.UseStationDepth_Submarine_Preset == true)
			{
				patrol.UseStationDepth_Submarine_Preset = false;
				patrol.StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (patrol.AttackDepth_Submarine.HasValue && patrol.UseAttackDepth_Submarine_Preset == true)
			{
				patrol.UseAttackDepth_Submarine_Preset = false;
				patrol.AttackDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (!flag2)
			{
				switch (patrol.Type)
				{
				default:
					patrol.IncludeInATO = false;
					break;
				case GlobalVariables.PatrolType.ASW:
					patrol.IncludeInATO = false;
					break;
				case GlobalVariables.PatrolType.ASuW_Naval:
					patrol.IncludeInATO = true;
					break;
				case GlobalVariables.PatrolType.AAW:
					patrol.IncludeInATO = true;
					break;
				case GlobalVariables.PatrolType.ASuW_Land:
					patrol.IncludeInATO = true;
					break;
				case GlobalVariables.PatrolType.ASuW_Mixed:
					patrol.IncludeInATO = true;
					break;
				case GlobalVariables.PatrolType.SEAD:
					patrol.IncludeInATO = true;
					break;
				}
			}
			if (patrol.NumberOfFlights_Investigate == _FlightQty.NoPreferences)
			{
				switch (patrol.Type)
				{
				default:
					patrol.NumberOfFlights_Investigate = _FlightQty.Flight_x1;
					patrol.NumberOfFlights_Engage = _FlightQty.All;
					patrol.WingmanEngageDistance = 5;
					patrol.NumberOfBoats_Investigate = _GroupQty.Group_x1;
					patrol.NumberOfBoats_Engage = _GroupQty.All;
					patrol.GroupMemberEngageDistance = 5;
					break;
				case GlobalVariables.PatrolType.ASW:
					patrol.NumberOfFlights_Investigate = _FlightQty.Flight_x2;
					patrol.NumberOfFlights_Engage = _FlightQty.Flight_x2;
					patrol.WingmanEngageDistance = 5;
					patrol.NumberOfBoats_Investigate = _GroupQty.Group_x2;
					patrol.NumberOfBoats_Engage = _GroupQty.Group_x2;
					patrol.GroupMemberEngageDistance = 5;
					break;
				case GlobalVariables.PatrolType.ASuW_Naval:
					patrol.NumberOfFlights_Investigate = _FlightQty.Flight_x1;
					patrol.NumberOfFlights_Engage = _FlightQty.All;
					patrol.WingmanEngageDistance = 5;
					patrol.NumberOfBoats_Investigate = _GroupQty.Group_x1;
					patrol.NumberOfBoats_Engage = _GroupQty.All;
					patrol.GroupMemberEngageDistance = 5;
					break;
				case GlobalVariables.PatrolType.AAW:
					patrol.NumberOfFlights_Investigate = _FlightQty.Flight_x1;
					patrol.NumberOfFlights_Engage = _FlightQty.All;
					patrol.WingmanEngageDistance = 5;
					patrol.NumberOfBoats_Investigate = _GroupQty.Group_x1;
					patrol.NumberOfBoats_Engage = _GroupQty.All;
					patrol.GroupMemberEngageDistance = 5;
					break;
				case GlobalVariables.PatrolType.ASuW_Land:
					patrol.NumberOfFlights_Investigate = _FlightQty.Flight_x1;
					patrol.NumberOfFlights_Engage = _FlightQty.All;
					patrol.WingmanEngageDistance = 5;
					patrol.NumberOfBoats_Investigate = _GroupQty.Group_x1;
					patrol.NumberOfBoats_Engage = _GroupQty.All;
					patrol.GroupMemberEngageDistance = 5;
					break;
				case GlobalVariables.PatrolType.ASuW_Mixed:
					patrol.NumberOfFlights_Investigate = _FlightQty.Flight_x1;
					patrol.NumberOfFlights_Engage = _FlightQty.All;
					patrol.WingmanEngageDistance = 5;
					patrol.NumberOfBoats_Investigate = _GroupQty.Group_x1;
					patrol.NumberOfBoats_Engage = _GroupQty.All;
					patrol.GroupMemberEngageDistance = 5;
					break;
				case GlobalVariables.PatrolType.SEAD:
					patrol.NumberOfFlights_Investigate = _FlightQty.Flight_x1;
					patrol.NumberOfFlights_Engage = _FlightQty.All;
					patrol.WingmanEngageDistance = 5;
					patrol.NumberOfBoats_Investigate = _GroupQty.Group_x1;
					patrol.NumberOfBoats_Engage = _GroupQty.All;
					patrol.GroupMemberEngageDistance = 5;
					break;
				}
			}
			if (patrol.ContinousCoverage_QRANumberOfFlights == _FlightQty.NoPreferences)
			{
				patrol.ContinousCoverage_Enable = false;
				patrol.ContinousCoverage_FlightGenerationMethod = _ContinousCoverageMethod.Dynamic;
				patrol.ContinousCoverage_StationTime = _ContinousCoverageStationTime.min_45;
				patrol.ContinousCoverage_Overlap = _ContinousCoverageOverlap.Min_2;
				patrol.ContinousCoverage_Duration = _ContinousCoverageDuration.hr_6;
				patrol.ContinousCoverage_QRAEnable = false;
				patrol.ContinousCoverage_QRAFlightGenerationMethod = _ContinousCoverageMethod.Dynamic;
				patrol.ContinousCoverage_QRANumberOfFlights = _FlightQty.Flight_x1;
				patrol.ContinousCoverage_NumberOfFlightsNeededToAllowQRA = _FlightQty.Flight_x2;
			}
			result = patrol;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100644", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Patrol(null, theScen, "");
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private Patrol(Side theSide, Scenario theScen, string theName)
		: base(theSide, theScen, theName)
	{
		PatrolArea = new List<ReferencePoint>();
		PatrolArea_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_2nm_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_5nm_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_10nm_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_30nm_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_2nm_Buffered = new List<ReferencePoint>();
		PatrolArea_5nm_Buffered = new List<ReferencePoint>();
		PatrolArea_10nm_Buffered = new List<ReferencePoint>();
		PatrolArea_30nm_Buffered = new List<ReferencePoint>();
		ProsecutionArea = new List<ReferencePoint>();
		ProsecutionArea_ChangeCheck = new List<ReferencePoint>();
		ProsecutionArea_2nm_ChangeCheck = new List<ReferencePoint>();
		ProsecutionArea_5nm_ChangeCheck = new List<ReferencePoint>();
		ProsecutionArea_2nm_Buffered = new List<ReferencePoint>();
		ProsecutionArea_5nm_Buffered = new List<ReferencePoint>();
		IsMission = true;
		MissionClass = _MissionClass.Patrol;
		OneThirdGrouping = OneThirdGroupingType.ByLoadout;
	}

	public Patrol(Side theSide, Scenario theScen, string theName, MissionCategory theCategory, List<ReferencePoint> theArea, GlobalVariables.PatrolType theType, bool ValidateArea)
		: base(theSide, theScen, theName)
	{
		PatrolArea = new List<ReferencePoint>();
		PatrolArea_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_2nm_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_5nm_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_10nm_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_30nm_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_2nm_Buffered = new List<ReferencePoint>();
		PatrolArea_5nm_Buffered = new List<ReferencePoint>();
		PatrolArea_10nm_Buffered = new List<ReferencePoint>();
		PatrolArea_30nm_Buffered = new List<ReferencePoint>();
		ProsecutionArea = new List<ReferencePoint>();
		ProsecutionArea_ChangeCheck = new List<ReferencePoint>();
		ProsecutionArea_2nm_ChangeCheck = new List<ReferencePoint>();
		ProsecutionArea_5nm_ChangeCheck = new List<ReferencePoint>();
		ProsecutionArea_2nm_Buffered = new List<ReferencePoint>();
		ProsecutionArea_5nm_Buffered = new List<ReferencePoint>();
		IsMission = true;
		MissionClass = _MissionClass.Patrol;
		Name = theName;
		Category = theCategory;
		PatrolArea = theArea;
		Type = theType;
		OneThirdRule = true;
		StationThrottle_Aircraft = ActiveUnit.Throttle.Loiter;
		TransitThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
		AttackThrottle_Aircraft = null;
		TransitTerrainFollowing_Aircraft = false;
		StationTerrainFollowing_Aircraft = false;
		AttackTerrainFollowing_Aircraft = false;
		TransitThrottle_Submarine = ActiveUnit.Throttle.Cruise;
		StationThrottle_Submarine = ActiveUnit.Throttle.Loiter;
		AttackThrottle_Submarine = null;
		TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
		StationThrottle_Ship = ActiveUnit.Throttle.Loiter;
		AttackThrottle_Ship = null;
		TransitThrottle_Facility = ActiveUnit.Throttle.Cruise;
		StationThrottle_Facility = ActiveUnit.Throttle.Loiter;
		AttackThrottle_Facility = null;
		TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
		StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
		AttackDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Shallow;
		TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.LoadoutAltitude;
		StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.LoadoutAltitude;
		AttackAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.LoadoutAltitude;
		UseTransitAltitude_Preset = true;
		UseStationAltitude_Preset = true;
		UseAttackAltitude_Preset = true;
		UseStationDepth_Submarine_Preset = true;
		UseTransitDepth_Submarine_Preset = true;
		UseAttackDepth_Submarine_Preset = true;
		bool_0 = true;
		bool_1 = true;
		SprintAndDrift = false;
		AvoidCavitation = false;
		UseFlightSizeHardLimit = true;
		Doctrine._WCS value = Doctrine._WCS.Free;
		if (theScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticSubComms))
		{
			byte? b = (byte?)Doctrine.get_WeaponControlStatus_Submarine(theScen, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() != 0)) == true)
			{
				value = Doctrine._WCS.Tight;
			}
		}
		switch (Type)
		{
		default:
			Doctrine.WinchesterShotgunRTB = Doctrine._WeaponStateRTB.YesLastUnit;
			Doctrine.BingoJokerRTB = Doctrine._FuelStateRTB.YesFirstUnit;
			base.FlightSize = 1;
			IncludeInATO = false;
			break;
		case GlobalVariables.PatrolType.ASW:
			Doctrine.WinchesterShotgunRTB = Doctrine._WeaponStateRTB.No;
			Doctrine.BingoJokerRTB = Doctrine._FuelStateRTB.YesFirstUnit;
			Doctrine.set_BehaviorTowardsAmbigousTarget(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._BehaviorTowardsTargetAmbiguity?)Doctrine._BehaviorTowardsTargetAmbiguity.Optimistic);
			Doctrine.set_WeaponControlStatus_Submarine(theScen, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)value);
			SprintAndDrift = true;
			base.FlightSize = 1;
			IncludeInATO = false;
			break;
		case GlobalVariables.PatrolType.ASuW_Naval:
			Doctrine.WinchesterShotgunRTB = Doctrine._WeaponStateRTB.YesLastUnit;
			Doctrine.BingoJokerRTB = Doctrine._FuelStateRTB.YesFirstUnit;
			Doctrine.set_WeaponControlStatus_Submarine(theScen, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)value);
			base.FlightSize = 1;
			IncludeInATO = true;
			break;
		case GlobalVariables.PatrolType.AAW:
			Doctrine.WinchesterShotgunRTB = Doctrine._WeaponStateRTB.YesLastUnit;
			Doctrine.BingoJokerRTB = Doctrine._FuelStateRTB.YesFirstUnit;
			base.FlightSize = 2;
			IncludeInATO = true;
			break;
		case GlobalVariables.PatrolType.ASuW_Land:
			Doctrine.WinchesterShotgunRTB = Doctrine._WeaponStateRTB.YesLastUnit;
			Doctrine.BingoJokerRTB = Doctrine._FuelStateRTB.YesFirstUnit;
			base.FlightSize = 2;
			IncludeInATO = true;
			break;
		case GlobalVariables.PatrolType.ASuW_Mixed:
			Doctrine.WinchesterShotgunRTB = Doctrine._WeaponStateRTB.YesLastUnit;
			Doctrine.BingoJokerRTB = Doctrine._FuelStateRTB.YesFirstUnit;
			Doctrine.set_WeaponControlStatus_Submarine(theScen, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)value);
			base.FlightSize = 2;
			IncludeInATO = true;
			break;
		case GlobalVariables.PatrolType.SEAD:
			Doctrine.WinchesterShotgunRTB = Doctrine._WeaponStateRTB.YesLastUnit;
			Doctrine.BingoJokerRTB = Doctrine._FuelStateRTB.YesFirstUnit;
			base.FlightSize = 2;
			IncludeInATO = true;
			break;
		}
		GroupSize = 1;
		Doctrine.set_IgnorePlottedCourse(theScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)Doctrine._UseIgnorePlottedCourse.Yes);
		Doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Active, theScen);
		Doctrine.set_ReplenishmentSelection(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UnderwayRefuelAndReplenishmentSelection?)Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
		switch (Type)
		{
		default:
			NumberOfFlights_Investigate = _FlightQty.Flight_x1;
			NumberOfFlights_Engage = _FlightQty.All;
			WingmanEngageDistance = 5;
			NumberOfBoats_Investigate = _GroupQty.Group_x1;
			NumberOfBoats_Engage = _GroupQty.All;
			GroupMemberEngageDistance = 5;
			break;
		case GlobalVariables.PatrolType.ASW:
			NumberOfFlights_Investigate = _FlightQty.Flight_x2;
			NumberOfFlights_Engage = _FlightQty.Flight_x2;
			WingmanEngageDistance = 5;
			NumberOfBoats_Investigate = _GroupQty.Group_x2;
			NumberOfBoats_Engage = _GroupQty.Group_x2;
			GroupMemberEngageDistance = 5;
			break;
		case GlobalVariables.PatrolType.ASuW_Naval:
			NumberOfFlights_Investigate = _FlightQty.Flight_x1;
			NumberOfFlights_Engage = _FlightQty.All;
			WingmanEngageDistance = 5;
			NumberOfBoats_Investigate = _GroupQty.Group_x1;
			NumberOfBoats_Engage = _GroupQty.All;
			GroupMemberEngageDistance = 5;
			break;
		case GlobalVariables.PatrolType.AAW:
			NumberOfFlights_Investigate = _FlightQty.Flight_x1;
			NumberOfFlights_Engage = _FlightQty.All;
			WingmanEngageDistance = 5;
			NumberOfBoats_Investigate = _GroupQty.Group_x1;
			NumberOfBoats_Engage = _GroupQty.All;
			GroupMemberEngageDistance = 5;
			break;
		case GlobalVariables.PatrolType.ASuW_Land:
			NumberOfFlights_Investigate = _FlightQty.Flight_x1;
			NumberOfFlights_Engage = _FlightQty.All;
			WingmanEngageDistance = 5;
			NumberOfBoats_Investigate = _GroupQty.Group_x1;
			NumberOfBoats_Engage = _GroupQty.All;
			GroupMemberEngageDistance = 5;
			break;
		case GlobalVariables.PatrolType.ASuW_Mixed:
			NumberOfFlights_Investigate = _FlightQty.Flight_x1;
			NumberOfFlights_Engage = _FlightQty.All;
			WingmanEngageDistance = 5;
			NumberOfBoats_Investigate = _GroupQty.Group_x1;
			NumberOfBoats_Engage = _GroupQty.All;
			GroupMemberEngageDistance = 5;
			break;
		case GlobalVariables.PatrolType.SEAD:
			NumberOfFlights_Investigate = _FlightQty.Flight_x1;
			NumberOfFlights_Engage = _FlightQty.All;
			WingmanEngageDistance = 5;
			NumberOfBoats_Investigate = _GroupQty.Group_x1;
			NumberOfBoats_Engage = _GroupQty.All;
			GroupMemberEngageDistance = 5;
			break;
		}
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
		string UserFeedback = default(string);
		if (ValidateArea && !ActiveUnit_Navigator.ValidateArea(PatrolArea, ref UserFeedback, theSide, theScen, "Patrol Mission '" + Name + "'"))
		{
			GameGeneral.SendMessageBoxToUI(UserFeedback, theSide);
		}
	}

	public override void Printout(StringBuilder PrintoutStringBuilder)
	{
		throw new NotImplementedException();
	}

	public override Mission Clone(bool DeepCloneRPs)
	{
		Patrol patrol = (Patrol)MemberwiseClone();
		patrol.ObjectID_Set(Guid.NewGuid().ToString());
		patrol.Name = "[CLONE] " + Name;
		if (PatrolArea != null)
		{
			patrol.PatrolArea = new ReferencePoint().CopyRefArea(ref PatrolArea, DeepCloneRPs);
		}
		if (ProsecutionArea != null)
		{
			patrol.ProsecutionArea = new ReferencePoint().CopyRefArea(ref ProsecutionArea, DeepCloneRPs);
		}
		return patrol;
	}

	internal bool TargetIsInRelevantMissionSpace(Contact primaryTarget)
	{
		int result;
		if (primaryTarget != null)
		{
			if (primaryTarget.ActualUnit == null)
			{
				result = 0;
			}
			else
			{
				if (HasProsecutionArea && this.get_InvestigateOutsidePatrolArea(primaryTarget.ActualUnit.ParentScen) && ((Module_Unit.Unit)primaryTarget).get_IsInsideThisArea(ProsecutionArea, primaryTarget.ActualUnit.ParentScen, UseCache: true))
				{
					return true;
				}
				if (((Module_Unit.Unit)primaryTarget).get_IsInsideThisArea(PatrolArea, primaryTarget.ActualUnit.ParentScen, UseCache: true))
				{
					return true;
				}
				result = 0;
			}
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	static Patrol()
	{
		Class72.smethod_20();
	}
}
