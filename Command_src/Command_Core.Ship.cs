using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Ship : Platform, IBoat, ICargoHost
{
	public struct _Flags
	{
		public bool PassiveOrSingleStabilizers;

		public bool DualOrTripleStabilizers;

		public bool ShockResistant;

		public bool bool_0;

		public bool CivilianConstruction;

		public bool AviationVessel;

		public bool AluminumConstruction;

		public bool PrairieMasker;

		public bool AdvancedQuieting;

		public bool MCM_DegaussedSteelHull;

		public bool MCM_OnboardDegaussingGear;

		public bool MCM_WoodenHull;

		public bool MCM_GRPHull;

		public bool LowConstructionStandards;

		public bool AllAluminumConstruction;

		public bool AluminumSuperstructureOnly;

		public bool WoodenHullConstruction;

		public bool GRP_Construction;

		public bool Hovercraft_SES;

		public bool CatamaranTrimaranMultihull;

		public bool bool_1;

		public bool BuiltToMercantileStandards;

		public bool CanLaunchCargoDirectlyToSea;

		public bool WaterjetPropulsion;
	}

	public enum _ShipCategory
	{
		None = 1001,
		AviationShip = 2001,
		SurfaceCombatant = 2002,
		Amphibious = 2003,
		Auxiliary = 2004,
		Merchant = 2005,
		Civilian = 2006,
		SurfaceCombatantAviation = 2007,
		MobileOffshoreBase = 2008
	}

	public enum _ShipType
	{
		None = 1001,
		CV = 2001,
		CVA = 2002,
		CVB = 2003,
		CVE = 2004,
		CVGH = 2005,
		CVH = 2006,
		CVL = 2007,
		CVN = 2008,
		SeaplaneCarrier = 2009,
		CVS = 2010,
		AVT = 2011,
		CVM = 2012,
		B = 3001,
		BB = 3002,
		BBC = 3003,
		BBG = 3004,
		BBH = 3005,
		BCGN = 3006,
		BM = 3007,
		C = 3101,
		CA = 3102,
		CAG = 3103,
		CB = 3104,
		CBG = 3105,
		CG = 3106,
		CGH = 3107,
		CGN = 3108,
		CL = 3109,
		CLAA = 3110,
		CLC = 3111,
		CLG = 3112,
		CLH = 3113,
		CS = 3114,
		D = 3201,
		DD = 3202,
		DDG = 3203,
		DDH = 3204,
		DDK = 3205,
		DDR = 3206,
		DE = 3207,
		DEG = 3208,
		DER = 3209,
		DL = 3210,
		DLG = 3211,
		DM = 3212,
		F = 3301,
		FF = 3302,
		FFG = 3303,
		FFL = 3304,
		PF = 3305,
		LCS = 3306,
		OPV = 3307,
		USV = 3308,
		PB = 3401,
		PC1 = 3402,
		PC2 = 3403,
		PCE = 3404,
		PCF = 3405,
		PCFG = 3406,
		PG1 = 3407,
		PG2 = 3408,
		PGM = 3409,
		PH = 3410,
		PHM = 3411,
		PHT = 3412,
		PT = 3413,
		PTS = 3414,
		MTB = 3415,
		WHEC = 3416,
		WMEC = 3417,
		WPB = 3418,
		WPG = 3419,
		MCDV = 3420,
		WMEC2 = 3421,
		WMSL = 3422,
		WMSM = 3423,
		AGF2 = 4000,
		AGC = 4001,
		LCAC = 4002,
		LCC = 4003,
		LCM = 4004,
		LCP = 4005,
		LCT = 4006,
		LCU = 4007,
		LCVP = 4008,
		LFR = 4009,
		LHA = 4010,
		LHD = 4011,
		LKA = 4012,
		LPD = 4013,
		LPH = 4014,
		LSD = 4015,
		LSH = 4016,
		LSL = 4017,
		LSM = 4018,
		LSMR = 4019,
		LST = 4020,
		LSU = 4021,
		LSV = 4022,
		LCI = 4023,
		LSDV = 4024,
		LCPA = 4025,
		EPF = 4026,
		ESD = 4027,
		ESB = 4028,
		A = 5001,
		AD = 5002,
		AE = 5003,
		AF = 5004,
		AFS = 5005,
		AG = 5006,
		AGB = 5007,
		AGF = 5008,
		AGI = 5009,
		AGMR = 5010,
		AGOR = 5011,
		AGOS = 5012,
		AGR = 5013,
		AGS = 5014,
		AGTR = 5015,
		AH = 5016,
		AK = 5017,
		AKA = 5018,
		AKE = 5019,
		AKR = 5020,
		AKS = 5021,
		AO = 5022,
		AOE = 5023,
		AOL = 5024,
		AOR = 5025,
		AOT = 5026,
		APA = 5027,
		APD = 5028,
		AR = 5029,
		AS_ = 5030,
		ATC = 5031,
		ATA = 5032,
		ATS = 5033,
		AV = 5034,
		AX = 5035,
		ASR = 5036,
		AP = 5037,
		DSV = 5038,
		AGM = 5039,
		AD2 = 5040,
		DTV = 5041,
		GPV = 5042,
		AGL = 5043,
		ATLS = 5044,
		TAGOS = 5101,
		TAH = 5102,
		TAK = 5103,
		TAKE = 5104,
		TAKR = 5105,
		TAO1 = 5106,
		TAO2 = 5107,
		TMLP = 5108,
		MCD = 6001,
		MCM = 6002,
		MCS = 6003,
		MHC = 6004,
		ML = 6005,
		MSC = 6006,
		MSF = 6007,
		MSI = 6008,
		MSO = 6010,
		MST = 6011,
		MHI = 6012,
		MM = 6013,
		YAG = 7001,
		YRT = 7002,
		YRM = 7003,
		Civilian = 9001,
		Merchant = 9002,
		Platform = 9003,
		NGSBuoy = 9004,
		BottomFixedArraySonar = 9005,
		MooredSonobuoy = 9006,
		Special = 9007,
		SmallWatercraft = 9008,
		MOB = 9011
	}

	public enum ShipWakeSize : byte
	{
		NoWake,
		VSmall,
		Small,
		Medium,
		Large,
		VLarge
	}

	public int CombatSystemGen;

	public _ShipCategory Category;

	public _ShipType Type;

	public GlobalVariables.ArmorRating Armor_Bridge;

	public GlobalVariables.ArmorRating Armor_Engineering;

	public GlobalVariables.ArmorRating Armor_Belt;

	public GlobalVariables.ArmorRating Armor_Bulkhead;

	public GlobalVariables.ArmorRating Armor_Deck;

	public GlobalVariables.ArmorRating Armor_CIC;

	public GlobalVariables.ArmorRating Armor_Rudder;

	public DockFacility.DockingPhysicalSize DockingPhysicalSize;

	public byte MaxSeaState;

	public short RepairCapacity;

	public short TroopCapacity;

	public int CargoCapacity;

	public short MissileDefense;

	public float Beam;

	public float Draft;

	public float Height;

	public float Cargo_Crew;

	public float Cargo_Area;

	public CargoType Cargo_Type;

	public float Cargo_Mass;

	public _Flags Flags;

	public Rudder Rudder;

	public CIC CIC;

	private Ship_Navigator ship_Navigator_0;

	private Ship_AI ship_AI_0;

	private Ship_Kinematics ship_Kinematics_0;

	private Ship_Sensory ship_Sensory_0;

	private Ship_Weaponry ship_Weaponry_0;

	private Ship_CommStuff ship_CommStuff_0;

	private Ship_Damage ship_Damage_0;

	private bool? nullable_16;

	private float float_8;

	private float float_9;

	private float float_10;

	public const float SMALL_CRAFT_MAX_LENGTH = 13f;

	public const float SMALL_CRAFT_MAX_DRAFT = 0.7f;

	public override bool RepresentsMobileGroundUnit => false;

	public override float CurrentAltitude_AGL
	{
		get
		{
			GlobalVariables.BooleanObject hintIsOperating = Misc.ToBooleanObject(IsOperating());
			return (short)(-Terrain.GetElevation(((ActiveUnit)this).get_Latitude(hintIsOperating), ((ActiveUnit)this).get_Longitude(hintIsOperating), RequestIsFromGUI: false, ParentScen));
		}
	}

	public override float FlatSurfaceArea_m2 => Length * Beam;

	public GlobalVariables.ArmorRating MinCitadelArmor => (GlobalVariables.ArmorRating)Math.Min((short)Armor_Belt, (short)Armor_Deck);

	public GlobalVariables.ArmorRating MaxCitadelArmor => (GlobalVariables.ArmorRating)Math.Max((short)Armor_Belt, (short)Armor_Deck);

	public string Type_Description
	{
		get
		{
			GlobalVariables.BooleanObject RadarClassificable = null;
			string text = "";
			ActiveUnit theAU = this;
			Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = Doctrine.WRA_DetermineTargetType(ref theAU, null, ref RadarClassificable);
			if (RadarClassificable == GlobalVariables.ObjectTrue)
			{
				text = ((wRA_WeaponTargetType != Doctrine._WRA_WeaponTargetType.Emitter_Jammer) ? " + Radar" : " + Jammer");
			}
			string text2 = Type.ToString();
			if (Operators.CompareString(text2, "None", false) == 0)
			{
				return "Radar";
			}
			return text2 + text;
		}
	}

	public override int SafeDistanceAgainstUnknownMine_meters
	{
		get
		{
			if (IsMCMPlatform_ThisPulse == -1)
			{
				Determine_IsMCMPlatform();
			}
			if (IsMCMPlatform_ThisPulse == 0)
			{
				if (!UsePathfindingBufferDistance)
				{
					return ((ActiveUnit)this).get_SafeDistanceAgainstUnknownMine_meters(UsePathfindingBufferDistance);
				}
				return ((ActiveUnit)this).get_SafeDistanceAgainstUnknownMine_meters(UsePathfindingBufferDistance) * 3;
			}
			if (UsePathfindingBufferDistance)
			{
				return Math.Max((int)Math.Round((double)((ActiveUnit)this).get_SafeDistanceAgainstUnknownMine_meters(UsePathfindingBufferDistance) * 0.3), 1000);
			}
			return (int)Math.Round((double)((ActiveUnit)this).get_SafeDistanceAgainstUnknownMine_meters(UsePathfindingBufferDistance) * 0.1);
		}
	}

	public override _ActiveUnitStatus Status
	{
		get
		{
			return base.Status;
		}
		set
		{
			_ = value != Status;
			base.Status = value;
		}
	}

	public override float DesiredHeading => ((ActiveUnit)this).DesiredHeading;

	public override float DesiredSpeed
	{
		get
		{
			return base.DesiredSpeed;
		}
		set
		{
			if (Navigator.AvoidCavitation && Status != _ActiveUnitStatus.EngagedDefensive)
			{
				float num = Kinematics.CavitationSpeed(0f);
				if (value >= num)
				{
					value = (float)((double)num - 0.1);
				}
			}
			if (value != DesiredSpeed)
			{
				base.DesiredSpeed = value;
			}
		}
	}

	public ShipWakeSize WakeSize
	{
		get
		{
			if (CurrentSpeed == 0f)
			{
				return ShipWakeSize.NoWake;
			}
			if (Type == _ShipType.LCAC && !Module_Unit.IsOverLand(this))
			{
				return ShipWakeSize.VLarge;
			}
			float currentSpeed = CurrentSpeed;
			if (currentSpeed < 10f)
			{
				return (ShipWakeSize)Math.Max(0, (int)(VisualSizeClass - 1));
			}
			if (currentSpeed < 20f)
			{
				return (ShipWakeSize)VisualSizeClass;
			}
			if (currentSpeed < 30f)
			{
				return (ShipWakeSize)Math.Min(5, (int)(VisualSizeClass + 1));
			}
			if (currentSpeed < 40f)
			{
				return (ShipWakeSize)Math.Min(5, (int)(VisualSizeClass + 2));
			}
			return (ShipWakeSize)Math.Min(5, (int)(VisualSizeClass + 3));
		}
	}

	public new Ship_Navigator Navigator => ship_Navigator_0;

	public new Ship_AI AI => ship_AI_0;

	public new Ship_Kinematics Kinematics
	{
		get
		{
			if (ship_Kinematics_0 == null)
			{
				ActiveUnit theUnit = this;
				ship_Kinematics_0 = new Ship_Kinematics(ref theUnit);
			}
			return ship_Kinematics_0;
		}
	}

	public new Ship_Sensory Sensory
	{
		get
		{
			if (ship_Sensory_0 == null)
			{
				ActiveUnit theUnit = this;
				ship_Sensory_0 = new Ship_Sensory(ref theUnit);
			}
			return ship_Sensory_0;
		}
	}

	public new Ship_Weaponry Weaponry
	{
		get
		{
			if (ship_Weaponry_0 == null)
			{
				ActiveUnit theUnit = this;
				ship_Weaponry_0 = new Ship_Weaponry(ref theUnit);
			}
			return ship_Weaponry_0;
		}
	}

	public new Ship_CommStuff CommStuff
	{
		get
		{
			if (ship_CommStuff_0 == null)
			{
				ActiveUnit theUnit = this;
				ship_CommStuff_0 = new Ship_CommStuff(ref theUnit);
			}
			return ship_CommStuff_0;
		}
	}

	public new Ship_Damage Damage
	{
		get
		{
			if (ship_Damage_0 == null)
			{
				ActiveUnit theUnit = this;
				ship_Damage_0 = new Ship_Damage(ref theUnit);
			}
			return ship_Damage_0;
		}
	}

	public override int MastHeight_Radar
	{
		get
		{
			if (SpecificSensor != null && SpecificSensor.MastHeight != 0)
			{
				return SpecificSensor.MastHeight;
			}
			return VisualSizeClass switch
			{
				GlobalVariables.TargetVisualSizeClass.Stealthy => 3, 
				GlobalVariables.TargetVisualSizeClass.VSmall => 7, 
				GlobalVariables.TargetVisualSizeClass.Small => 14, 
				GlobalVariables.TargetVisualSizeClass.Medium => 25, 
				GlobalVariables.TargetVisualSizeClass.Large => 40, 
				GlobalVariables.TargetVisualSizeClass.VLarge => 50, 
				_ => 0, 
			};
		}
	}

	public override int MastHeight_Visual
	{
		get
		{
			if (SpecificSensor != null && SpecificSensor.MastHeight != 0)
			{
				return SpecificSensor.MastHeight;
			}
			return VisualSizeClass switch
			{
				GlobalVariables.TargetVisualSizeClass.Stealthy => 2, 
				GlobalVariables.TargetVisualSizeClass.VSmall => 6, 
				GlobalVariables.TargetVisualSizeClass.Small => 10, 
				GlobalVariables.TargetVisualSizeClass.Medium => 15, 
				GlobalVariables.TargetVisualSizeClass.Large => 20, 
				GlobalVariables.TargetVisualSizeClass.VLarge => 25, 
				_ => 0, 
			};
		}
	}

	public bool IsNuke
	{
		get
		{
			if (!nullable_16.HasValue)
			{
				nullable_16 = false;
				foreach (Engine item in Propulsion)
				{
					if (item.Type == Engine.EngineType.Nuclear)
					{
						nullable_16 = true;
						break;
					}
				}
			}
			return nullable_16.Value;
		}
	}

	public bool IsSinking => ((ActiveUnit)this).get_DamagePts(ScenEditAction: false, (Weapon)null) <= 0f;

	public override GlobalVariables.TargetVisualSizeClass VisualSizeClass
	{
		get
		{
			float length = Length;
			if (length <= 280f)
			{
				if (length > 220f)
				{
					return GlobalVariables.TargetVisualSizeClass.Large;
				}
				if (length > 120f)
				{
					return GlobalVariables.TargetVisualSizeClass.Medium;
				}
				if (length > 45f)
				{
					return GlobalVariables.TargetVisualSizeClass.Small;
				}
				if (length > 10f)
				{
					return GlobalVariables.TargetVisualSizeClass.VSmall;
				}
				return GlobalVariables.TargetVisualSizeClass.Stealthy;
			}
			return GlobalVariables.TargetVisualSizeClass.VLarge;
		}
	}

	public override bool IsPlatform => true;

	public bool IsIcebreaker => Type == _ShipType.AGB;

	public override string AnnexAndDBID => "Ship_" + Conversions.ToString(DBID);

	public override long FuelEndurance
	{
		get
		{
			try
			{
				if (Fuel_ReadOnly.Count != 0)
				{
					FuelRec fuelRec = (from theFuelrec in Fuel_ReadOnly
						select (theFuelrec) into theFuelrec
						where Propulsion[0].CanUseThisFuelType(theFuelrec.FuelType)
						select theFuelrec).ElementAtOrDefault(0);
					if (!Information.IsNothing((object)fuelRec))
					{
						float currentQuantity = fuelRec.CurrentQuantity;
						if (currentQuantity == 0f)
						{
							return 0L;
						}
						if (theThrottle == Throttle.FullStop)
						{
							return 2147483647L;
						}
						float num = FuelConsumption(theThrottle, theAltBand, theSpeed, theAltitude, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
						if (num == 0f)
						{
							return long.MaxValue;
						}
						return (long)Math.Round(currentQuantity / num);
					}
					return 0L;
				}
				return 0L;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100766", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return 0L;
		}
	}

	public override _ActiveUnitFuelState IsBingoTowardsThisDestination
	{
		get
		{
			_ActiveUnitFuelState result;
			try
			{
				if (this.get_FuelEndurance(Throttle.Cruise, (AltBand)null, (float?)null, (float?)null) <= 900L)
				{
					result = _ActiveUnitFuelState.IsBingo;
				}
				else
				{
					float num = RangeToUnit_Horiz(theDestination);
					result = (((double)Kinematics.CurrentRangeAtBingoThrottleAltitudeDepth(null) < (double)num * 1.1) ? _ActiveUnitFuelState.IsBingo : _ActiveUnitFuelState.None);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100767", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num2;
				if (!Debugger.IsAttached)
				{
					num2 = 0;
				}
				else
				{
					Debugger.Break();
					num2 = 0;
				}
				result = (_ActiveUnitFuelState)num2;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public override _ActiveUnitFuelState IsBingoOrJoker
	{
		get
		{
			_ActiveUnitFuelState result;
			try
			{
				if (!IsNuke)
				{
					if (IsDrone() && AutonomyLevel < DroneAutonomyLevel.FaultEventAdaptive && ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !((ActiveUnit_CommStuff)CommStuff).IsConnectedToSideNetwork)
					{
						result = _ActiveUnitFuelState.None;
					}
					else
					{
						ActiveUnit actualDestinationHost = DockingOps.ActualDestinationHost;
						result = ((actualDestinationHost != null) ? ((!actualDestinationHost.IsMorituri) ? this.get_IsBingoTowardsThisDestination(actualDestinationHost, (GeoPoint)null, (Doctrine._FuelState?)null) : _ActiveUnitFuelState.None) : _ActiveUnitFuelState.None);
					}
				}
				else
				{
					result = _ActiveUnitFuelState.None;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100768", "");
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
				result = (_ActiveUnitFuelState)num;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public override bool CanPhysicallyReplenishThisUnit
	{
		get
		{
			if (TargetUnit.IsAircraft)
			{
				return false;
			}
			if (UNREP_Capabilities.Refuel_Port_Out > 0)
			{
				return true;
			}
			if (UNREP_Capabilities.Refuel_Starboard_Out > 0)
			{
				return true;
			}
			if (UNREP_Capabilities.Refuel_Astern_Out > 0)
			{
				return true;
			}
			return false;
		}
	}

	public override ActiveUnit_DockingOps.ResupplyCapacity DesignatedSupplier
	{
		get
		{
			if (!_DesignatedSupplier.HasValue)
			{
				_DesignatedSupplier = ActiveUnit_DockingOps.ResupplyCapacity.FuelAndMaterial;
			}
			return _DesignatedSupplier.Value;
		}
		set
		{
			_DesignatedSupplier = value;
		}
	}

	public override bool CanPhysicallyReplenishOtherUnits
	{
		get
		{
			if (UNREP_Capabilities.Refuel_Port_Out <= 0)
			{
				if (UNREP_Capabilities.Refuel_Starboard_Out <= 0)
				{
					if (UNREP_Capabilities.Refuel_Astern_Out <= 0)
					{
						return false;
					}
					return true;
				}
				return true;
			}
			return true;
		}
	}

	public override bool IsOutOfFuel
	{
		get
		{
			bool result;
			try
			{
				if (IsNuke)
				{
					result = false;
				}
				else if (Propulsion.Count != 0)
				{
					FuelRec fuelRec = (from theFuelrec in Fuel_ReadOnly
						select (theFuelrec) into theFuelrec
						where Propulsion[0].CanUseThisFuelType(theFuelrec.FuelType)
						select theFuelrec).ElementAtOrDefault(0);
					result = Information.IsNothing((object)fuelRec) || fuelRec.CurrentQuantity == 0f || Fuel_ReadOnly[0].CurrentQuantity == 0f;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100769", "");
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
	}

	public float Displacement_Empty
	{
		get
		{
			return float_8;
		}
		set
		{
			float_8 = value;
		}
	}

	public float Displacement_Standard
	{
		get
		{
			return float_9;
		}
		set
		{
			float_9 = value;
		}
	}

	public float Displacement_Full
	{
		get
		{
			return float_10;
		}
		set
		{
			float_10 = value;
		}
	}

	public bool IsDedicatedTankerOrUNREP
	{
		get
		{
			int result;
			switch (Type)
			{
			default:
				result = 0;
				goto IL_00b0;
			case _ShipType.AGB:
			case _ShipType.AGF:
			case _ShipType.AGI:
			case _ShipType.AGMR:
			case _ShipType.AGOR:
			case _ShipType.AGOS:
			case _ShipType.AGR:
			case _ShipType.AGS:
			case _ShipType.AGTR:
			case _ShipType.AH:
			case _ShipType.APD:
			case _ShipType.AR:
			case _ShipType.ATC:
			case _ShipType.ATA:
			case _ShipType.ATS:
				result = 0;
				goto IL_00b0;
			case _ShipType.LKA:
			case _ShipType.AD:
			case _ShipType.AE:
			case _ShipType.AF:
			case _ShipType.AFS:
			case _ShipType.AG:
			case _ShipType.AK:
			case _ShipType.AKA:
			case _ShipType.AKE:
			case _ShipType.AKR:
			case _ShipType.AKS:
			case _ShipType.AO:
			case _ShipType.AOE:
			case _ShipType.AOL:
			case _ShipType.AOR:
			case _ShipType.AOT:
			case _ShipType.APA:
			case _ShipType.AS_:
			case _ShipType.AV:
			case _ShipType.TAK:
			case _ShipType.TAKE:
			case _ShipType.TAKR:
			case _ShipType.TAO1:
			case _ShipType.TAO2:
			case _ShipType.TMLP:
				{
					return true;
				}
				IL_00b0:
				return (byte)result != 0;
			}
		}
	}

	public Cargo[] CargoArray
	{
		get
		{
			return OnboardCargo;
		}
		set
		{
			OnboardCargo = value;
		}
	}

	private Ship()
	{
		Scenario theScen = null;
		base..ctor(ref theScen);
		Flags = default(_Flags);
		Rudder = new Rudder(this);
		CIC = new CIC(this, "Bridge / CIC");
		ActiveUnit theUnit = this;
		ship_Navigator_0 = new Ship_Navigator(ref theUnit);
		theUnit = this;
		ship_AI_0 = new Ship_AI(ref theUnit);
		IsShip = true;
		IsBoat = true;
		UnitType = GlobalVariables.ActiveUnitType.Ship;
	}

	internal override void Reinitialize()
	{
		base.Reinitialize();
		ChanceOfAppearance = 0;
		LastReportedInfoReinitialize();
		Longitude__UnitEntersAreaCheck = null;
		Latitude__UnitEntersAreaCheck = null;
		ActiveEnterAreaTriggers.Clear();
		_DesiredHeading = 0f;
		_DesiredSpeed = 0f;
		_DesiredAltitude = 0f;
		_DesiredTurnRate = TurnRate.Max;
		_DesiredTurnRate_Navigation = Waypoint.TurnRateCategory.StandardRateTurn;
		ArrayExtensions.Clear(ref Magazines);
		ArrayExtensions.Clear(ref OnboardCargo);
		ArrayExtensions.Clear(ref _AirFacilities);
		ArrayExtensions.Clear(ref _DockFacilities);
		_DestroyEventsChecked = false;
	}

	private protected override List<PlatformComponent> ComponentList()
	{
		List<PlatformComponent> list = base.ComponentList();
		list.Add(Rudder);
		list.Add(CIC);
		return list;
	}

	protected override GlobalVariables.ArmorRating GetArmorStructureValue()
	{
		return MinCitadelArmor;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			if (((ActiveUnit)this).get_UnitSide(SetSideOnly: false) == null)
			{
				return;
			}
			theWriter.WriteStartElement("Ship");
			theWriter.WriteElementString("ID", ObjectID);
			if (ObjectsAlreadySerialized.Contains(ObjectID))
			{
				theWriter.WriteEndElement();
				return;
			}
			ObjectsAlreadySerialized.Add(ObjectID);
			method_2(ref theWriter);
			theWriter.WriteElementString("Name", Name.Replace("\0", "").Replace("\u0010", ""));
			if (ChanceOfAppearance != 0)
			{
				theWriter.WriteElementString("COA", Conversions.ToString(ChanceOfAppearance));
			}
			if (TimeUnderway != 0f)
			{
				theWriter.WriteElementString("TUW", Conversions.ToString(TimeUnderway));
			}
			if (AutonomyLevel != DroneAutonomyLevel.Undefined)
			{
				theWriter.WriteElementString("AL", Conversions.ToString((int)AutonomyLevel));
			}
			theWriter.WriteElementString("CH", XmlConvert.ToString(CurrentHeading));
			theWriter.WriteElementString("CS", XmlConvert.ToString(CurrentSpeed));
			theWriter.WriteElementString("CA", XmlConvert.ToString(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
			theWriter.WriteElementString("Lon", XmlConvert.ToString(((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null)));
			theWriter.WriteElementString("Lat", XmlConvert.ToString(((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
			LastReportedInfoToXML(ref theWriter);
			if (Longitude__UnitEntersAreaCheck.HasValue)
			{
				theWriter.WriteElementString("Longitude_UnitEntersAreaCheck", XmlConvert.ToString(Longitude__UnitEntersAreaCheck.Value));
			}
			if (Latitude__UnitEntersAreaCheck.HasValue)
			{
				theWriter.WriteElementString("Latitude_UnitEntersAreaCheck", XmlConvert.ToString(Latitude__UnitEntersAreaCheck.Value));
			}
			if (ActiveEnterAreaTriggers.Count > 0)
			{
				theWriter.WriteStartElement("ActiveEnterAreaTriggers");
				foreach (string activeEnterAreaTrigger in ActiveEnterAreaTriggers)
				{
					theWriter.WriteElementString("ActiveEnterAreaTrigger", activeEnterAreaTrigger);
				}
				theWriter.WriteEndElement();
			}
			if (ActiveRemainAreaTriggers.Count > 0)
			{
				theWriter.WriteStartElement("ActiveRemainAreaTriggers");
				foreach (KeyValuePair<string, DateTime> activeRemainAreaTrigger in ActiveRemainAreaTriggers)
				{
					theWriter.WriteElementString("RemainAreaTrigger", activeRemainAreaTrigger.Key.ToString());
					theWriter.WriteElementString("RemainAreaStartTime", activeRemainAreaTrigger.Value.ToBinary().ToString());
				}
				theWriter.WriteEndElement();
			}
			if (_Proficiency.HasValue)
			{
				theWriter.WriteElementString("Prof", ((int)_Proficiency.Value).ToString());
			}
			theWriter.WriteElementString("Side", ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Name);
			if (!string.IsNullOrEmpty(Message))
			{
				theWriter.WriteElementString("Message", Message);
			}
			theWriter.WriteElementString("DBID", DBID.ToString());
			if (DesiredHeading != 0f)
			{
				theWriter.WriteElementString("DH", XmlConvert.ToString(DesiredHeading));
			}
			if (DesiredSpeed != 0f)
			{
				theWriter.WriteElementString("DS", XmlConvert.ToString(DesiredSpeed));
			}
			if (DesiredAltitude != 0f)
			{
				theWriter.WriteElementString("DA", XmlConvert.ToString(DesiredAltitude));
			}
			if (DesiredTurnRate != TurnRate.Max)
			{
				theWriter.WriteElementString("DT", ((byte)DesiredTurnRate).ToString());
			}
			if (DesiredTurnRate_Navigation != Waypoint.TurnRateCategory.StandardRateTurn)
			{
				theWriter.WriteElementString("DTN", ((byte)DesiredTurnRate_Navigation).ToString());
			}
			theWriter.WriteElementString("TS", ((byte)ThrottleSetting).ToString());
			theWriter.WriteStartElement("Sensors");
			foreach (Sensor sensor in _Sensors)
			{
				theWriter.WriteRaw(sensor.ToXML(ObjectsAlreadySerialized));
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Comms");
			CommDevice[] comms = _Comms;
			foreach (CommDevice commDevice in comms)
			{
				theWriter.WriteRaw(commDevice.ToXML(ref ObjectsAlreadySerialized));
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Propulsion");
			foreach (Engine item in Propulsion)
			{
				theWriter.WriteRaw(item.ToXML(ObjectsAlreadySerialized));
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Fuel");
			foreach (FuelRec item2 in _Fuel)
			{
				theWriter.WriteRaw(item2.ToXML());
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Mounts");
			foreach (Mount mount in Mounts)
			{
				if (mount.ParentPlatform == null)
				{
					mount.ParentPlatform = this;
				}
				theWriter.WriteRaw(mount.ToXML(ref ObjectsAlreadySerialized, ParentScen));
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Magazines");
			Magazine[] magazines = Magazines;
			foreach (Magazine magazine in magazines)
			{
				theWriter.WriteRaw(magazine.ToXML(ObjectsAlreadySerialized, ParentScen));
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("OnboardCargo");
			Cargo[] onboardCargo = OnboardCargo;
			foreach (Cargo cargo in onboardCargo)
			{
				theWriter.WriteRaw(cargo.ToXML(ObjectsAlreadySerialized, ParentScen));
			}
			theWriter.WriteEndElement();
			XmlWriter obj = theWriter;
			byte status = (byte)_Status;
			obj.WriteElementString("Status", status.ToString());
			XmlWriter obj2 = theWriter;
			status = (byte)_FuelState;
			obj2.WriteElementString("FuelState", status.ToString());
			theWriter.WriteElementString("WeaponState", ((byte)_WeaponState).ToString());
			if (_StatusBefore_NeedToRefuel != _ActiveUnitStatus.Unassigned)
			{
				XmlWriter obj3 = theWriter;
				status = (byte)_StatusBefore_NeedToRefuel;
				obj3.WriteElementString("SBR", status.ToString());
			}
			if (_StatusBefore_EngagedDefensive != _ActiveUnitStatus.Unassigned)
			{
				XmlWriter obj4 = theWriter;
				status = (byte)_StatusBefore_EngagedDefensive;
				obj4.WriteElementString("SBED", status.ToString());
			}
			if (_StatusBefore_EngagedOffensive != _ActiveUnitStatus.Unassigned)
			{
				XmlWriter obj5 = theWriter;
				status = (byte)_StatusBefore_EngagedOffensive;
				obj5.WriteElementString("SBEO", status.ToString());
			}
			if (_FuelStateBefore_NeedToRefuel != _ActiveUnitFuelState.None)
			{
				XmlWriter obj6 = theWriter;
				status = (byte)_FuelStateBefore_NeedToRefuel;
				obj6.WriteElementString("FSBR", status.ToString());
			}
			theWriter.WriteElementString("SBR_TF", XmlConvert.ToString(_TerrainFollowingBefore_NeedToRefuel));
			XmlWriter obj7 = theWriter;
			status = (byte)_ThrottleBefore_NeedToRefuel;
			obj7.WriteElementString("SBR_ThrottleSetting", status.ToString());
			theWriter.WriteElementString("SBED_TF", XmlConvert.ToString(_TerrainFollowingBefore_EngagedDefensive));
			XmlWriter obj8 = theWriter;
			status = (byte)_ThrottleBefore_EngagedDefensive;
			obj8.WriteElementString("SBED_ThrottleSetting", status.ToString());
			if (_DesiredSpeedOverrideBefore_EngagedDefensive.HasValue)
			{
				theWriter.WriteElementString("SBED_DesiredSpeedOverride", XmlConvert.ToString(_DesiredSpeedOverrideBefore_EngagedDefensive.Value));
			}
			theWriter.WriteElementString("SBEO_TF", XmlConvert.ToString(_TerrainFollowingBefore_EngagedOffensive));
			if (_ThrottleBefore_EngagedOffensive != Throttle.FullStop)
			{
				XmlWriter obj9 = theWriter;
				status = (byte)_ThrottleBefore_EngagedOffensive;
				obj9.WriteElementString("SBEO_ThrottleSetting", status.ToString());
			}
			theWriter.WriteElementString("SBPF_TF", XmlConvert.ToString(_TerrainFollowingBefore_WaitForPathfinder));
			XmlWriter obj10 = theWriter;
			status = (byte)_ThrottleBefore_WaitForPathfinder;
			obj10.WriteElementString("SBPF_ThrottleSetting", status.ToString());
			theWriter.WriteElementString("AMP_OC", _MissionPlannerOverrideCancellation.ToString());
			if (_MissionPlannerOverrideCancellation_DesiredSpeedOverride.HasValue)
			{
				theWriter.WriteElementString("AMP_OC_DSO", _MissionPlannerOverrideCancellation_DesiredSpeedOverride.ToString());
			}
			theWriter.WriteElementString("AMP_OC_DAO", _MissionPlannerOverrideCancellation_DesiredAltitudeOverride.ToString());
			theWriter.WriteElementString("AMP_OC_Speed", XmlConvert.ToString(_MissionPlannerOverrideCancellation_Speed));
			theWriter.WriteElementString("DamagePts", XmlConvert.ToString(((ActiveUnit)this).get_DamagePts(ScenEditAction: false, (Weapon)null)));
			theWriter.WriteElementString("OldDamagePercent", XmlConvert.ToString(_OldDamagePercent));
			if (EligibleForSAR)
			{
				theWriter.WriteElementString("EFSAR", XmlConvert.ToString(EligibleForSAR));
			}
			if (IsBeingPickedUp)
			{
				theWriter.WriteElementString("IBPU", XmlConvert.ToString(IsBeingPickedUp));
			}
			if (_AirFacilities.Length > 0)
			{
				theWriter.WriteStartElement("AirFacilities");
				AirFacility[] airFacilities = _AirFacilities;
				foreach (AirFacility airFacility in airFacilities)
				{
					theWriter.WriteRaw(airFacility.ToXML(ObjectsAlreadySerialized));
				}
				theWriter.WriteEndElement();
			}
			if (_DockFacilities.Count() > 0)
			{
				theWriter.WriteStartElement("DockFacilities");
				DockFacility[] dockFacilities = _DockFacilities;
				foreach (DockFacility dockFacility in dockFacilities)
				{
					theWriter.WriteRaw(dockFacility.ToXML(ObjectsAlreadySerialized));
				}
				theWriter.WriteEndElement();
			}
			if (ActiveMissionOrPackage() != null)
			{
				theWriter.WriteElementString("AssignedMission", _AssignedMissionOrPackage.ObjectID);
			}
			if (AssignedTaskPool != null)
			{
				theWriter.WriteElementString("AssignedTaskPool", _AssignedTaskPool.ObjectID);
			}
			if (PrivateSnapshotMission != null)
			{
				theWriter.WriteStartElement("PrivateSnapshotMission");
				PrivateSnapshotMission.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref ParentScen);
				theWriter.WriteEndElement();
			}
			if (((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false) != null)
			{
				theWriter.WriteElementString("ParentGroup", _ParentGroup.ObjectID);
			}
			if (((ActiveUnit)this).get_IsAutoDetectable((Side)null))
			{
				theWriter.WriteElementString("IsAD", ((ActiveUnit)this).get_IsAutoDetectable((Side)null).ToString());
			}
			if (_DestroyEventsChecked)
			{
				theWriter.WriteElementString("DEC", _DestroyEventsChecked.ToString());
			}
			Doctrine.ToXML(ref theWriter, ref ParentScen);
			theWriter.WriteStartElement("Rudder");
			Rudder.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ParentScen);
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("CIC");
			CIC.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ParentScen);
			theWriter.WriteEndElement();
			Navigator.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.WriteStartElement("Ship_AI");
			if (AI.myUnit == null)
			{
				AI.myUnit = this;
			}
			AI.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Ship_Kinematics");
			Kinematics.ToXML(ref theWriter);
			theWriter.WriteEndElement();
			Sensory.ToXML(ref theWriter);
			Weaponry.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.WriteStartElement("Ship_CommStuff");
			CommStuff.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.WriteEndElement();
			Damage.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			AirOps.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			ActiveUnit_DockingOps.ToXML(DockingOps, ref theWriter, ref ObjectsAlreadySerialized);
			if (HasCustomOODA)
			{
				theWriter.WriteElementString("OODA_D", OODA_Detection.ToString());
				theWriter.WriteElementString("OODA_T", OODA_Targeting.ToString());
				theWriter.WriteElementString("OODA_E", OODA_Evasion.ToString());
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100761", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static Ship FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, Ship existingObject = null)
	{
		Ship ship = default(Ship);
		try
		{
			ship = smethod_1(ref theNode, ref theDictionary, ref theScen, theScen.LoadStockUnits, existingObject);
		}
		catch (PlatformComponentNotFoundException projectError)
		{
			ProjectData.SetProjectError((Exception)projectError);
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			ConcurrentDictionary<string, ScenarioObject> obj = theDictionary;
			ScenarioObject value = ship;
			obj.TryRemove(innerText, out value);
			ship = smethod_1(ref theNode, ref theDictionary, ref theScen, bool_3: true, existingObject);
			string text = "";
			if (ship.IsGroupMember())
			{
				text = "(member of group: [" + ((ActiveUnit)ship).get_ParentGroup(UsingMissionPlanner: false).Name + "])";
			}
			theScen.LoadingNotices.Add("The following ship:[" + ship.Name + "]" + text + " failed to shallow-rebuild because of a component missing. The ship was instead deep-rebuilt, and instantiated in its pristine DB-stock condition. All customizations present in the ship's components (damaged components, weapon additions/removals etc. etc.) have been lost. Please re-apply any necessary customizations either manually or using an SBR script.");
			ProjectData.ClearProjectError();
		}
		return ship;
	}

	private static Ship smethod_1(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0, bool bool_3, Ship ship_0 = null)
	{
		//IL_0758: Unknown result type (might be due to invalid IL or missing references)
		//IL_075f: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_06cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d4: Expected O, but got Unknown
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0512: Expected O, but got Unknown
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		//IL_064e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0655: Expected O, but got Unknown
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected O, but got Unknown
		//IL_05bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Expected O, but got Unknown
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected O, but got Unknown
		//IL_15e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ec: Expected O, but got Unknown
		//IL_1143: Unknown result type (might be due to invalid IL or missing references)
		Ship result;
		try
		{
			bool flag;
			Ship theShip;
			if (!(flag = ship_0 != null))
			{
				theShip = new Ship();
			}
			else
			{
				theShip = ship_0;
				theShip.Reinitialize();
			}
			theShip.ParentScen = scenario_0;
			string text = Misc.GetNodeByName(xmlNode_0.ChildNodes, "ID").InnerText;
			if (Misc.ContainsChar(text, ' '))
			{
				text = text.Replace(" ", "-");
			}
			if (!concurrentDictionary_0.ContainsKey(text))
			{
				theShip.ObjectID_Set(text);
				if (xmlNode_0.ChildNodes.Count == 1)
				{
					scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
					result = theShip;
				}
				else
				{
					concurrentDictionary_0.TryAdd(theShip.ObjectID, theShip);
					int num = Conversions.ToInteger(Misc.GetNodeByName(xmlNode_0.ChildNodes, "DBID").InnerText);
					try
					{
						DBFunctions.GetShip(ref scenario_0, ref theShip, num, bool_3);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
						string objectID = theShip.ObjectID;
						ScenarioObject value = theShip;
						obj.TryRemove(objectID, out value);
						scenario_0.LoadingNotices.Add("Ship with Database ID " + Conversions.ToString(num) + " is missing from the database and has not been loaded.");
						result = null;
						ProjectData.ClearProjectError();
						goto end_IL_0001;
					}
					if (bool_3)
					{
						theShip.method_3(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
					}
					if (!bool_3)
					{
						foreach (XmlNode childNode in xmlNode_0.ChildNodes)
						{
							XmlNode theNode = childNode;
							theShip.CommonFromXML(theNode);
							switch (theNode.Name)
							{
							case "CIC":
								theShip.CIC = CIC.FromXML(ref theNode, ref concurrentDictionary_0, theShip);
								break;
							case "OnboardCargo":
								if (flag)
								{
									ArrayExtensions.Clear(ref theShip.OnboardCargo);
								}
								foreach (XmlNode childNode2 in theNode.ChildNodes)
								{
									XmlNode theNode6 = childNode2;
									Cargo cargo = Cargo.FromXML(ref theNode6, ref concurrentDictionary_0, scenario_0, theShip);
									ArrayExtensions.Add(ref theShip.OnboardCargo, cargo);
									cargo.ParentPlatform = theShip;
								}
								break;
							case "Fuel":
								if (flag)
								{
									theShip._Fuel.Clear();
								}
								foreach (XmlNode childNode3 in theNode.ChildNodes)
								{
									XmlNode theNode3 = childNode3;
									FuelRec item = FuelRec.FromXML(ref theNode3, ref concurrentDictionary_0);
									theShip._Fuel.Add(item);
								}
								break;
							case "DockFacilities":
								if (flag)
								{
									ArrayExtensions.Clear(ref theShip._DockFacilities);
								}
								foreach (XmlNode childNode4 in theNode.ChildNodes)
								{
									XmlNode theNode5 = childNode4;
									DockFacility dockFacility = DockFacility.FromXML(ref theNode5, ref concurrentDictionary_0, ref scenario_0);
									theShip.AddDockFacility(dockFacility);
									dockFacility.ParentPlatform = theShip;
								}
								break;
							case "Comms":
								if (flag)
								{
									ArrayExtensions.Clear(ref theShip._Comms);
								}
								foreach (XmlNode childNode5 in theNode.ChildNodes)
								{
									XmlNode theNode8 = childNode5;
									CommDevice commDevice = CommDevice.FromXML(ref theNode8, ref concurrentDictionary_0, theShip);
									theShip.AddCommDevice(commDevice);
									commDevice.ParentPlatform = theShip;
								}
								break;
							case "Rudder":
								theShip.Rudder = Rudder.FromXML(ref theNode, ref concurrentDictionary_0);
								theShip.Rudder.ParentPlatform = theShip;
								break;
							case "Sensors":
								if (flag)
								{
									theShip._Sensors.Clear();
								}
								foreach (XmlNode childNode6 in theNode.ChildNodes)
								{
									Sensor sensor = Sensor.FromXML(childNode6, concurrentDictionary_0, theShip);
									theShip._Sensors.Add(sensor);
									sensor.ParentPlatform = theShip;
								}
								break;
							case "Propulsion":
								if (flag)
								{
									theShip.Propulsion.Clear();
								}
								foreach (XmlNode childNode7 in theNode.ChildNodes)
								{
									XmlNode theNode9 = childNode7;
									ActiveUnit theParentPlatform = theShip;
									Engine engine = Engine.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
									theShip.Propulsion.Add(engine);
									engine.ParentPlatform = theShip;
								}
								break;
							case "AirFacilities":
								if (flag)
								{
									ArrayExtensions.Clear(ref theShip._AirFacilities);
								}
								foreach (XmlNode childNode8 in theNode.ChildNodes)
								{
									XmlNode theNode7 = childNode8;
									AirFacility airFacility = AirFacility.FromXML(ref theNode7, ref concurrentDictionary_0, ref scenario_0);
									theShip.AddAirFacility(airFacility);
									airFacility.ParentPlatform = theShip;
									if (airFacility.DBID == -1)
									{
										theShip.bool_2 = true;
									}
								}
								break;
							case "Magazines":
								if (flag)
								{
									ArrayExtensions.Clear(ref theShip.Magazines);
								}
								foreach (XmlNode childNode9 in theNode.ChildNodes)
								{
									XmlNode theNode4 = childNode9;
									Magazine magazine = Magazine.FromXML(ref theNode4, ref concurrentDictionary_0, ref scenario_0);
									theShip.AddSharedMagazine(magazine, RaiseUiEvent: false);
									magazine.ParentPlatform = theShip;
								}
								break;
							case "Mounts":
								if (flag)
								{
									theShip.Mounts.Clear();
								}
								foreach (XmlNode childNode10 in theNode.ChildNodes)
								{
									XmlNode theNode2 = childNode10;
									Mount mount = Mount.FromXML(ref theNode2, ref concurrentDictionary_0, theShip);
									if (mount != null)
									{
										theShip.Mounts.Add(mount);
										mount.ParentPlatform = theShip;
									}
								}
								break;
							}
						}
					}
					foreach (XmlNode childNode11 in xmlNode_0.ChildNodes)
					{
						XmlNode theNode10 = childNode11;
						if (theShip.isLastReportedInfoXMLField(theNode10.Name))
						{
							theShip.LastReportedInfoFromXMLField(theNode10.Name, theNode10.InnerText);
							continue;
						}
						switch (theNode10.Name)
						{
						case "Status":
							if (Versioned.IsNumeric((object)theNode10.InnerText))
							{
								theShip.Status = (_ActiveUnitStatus)Conversions.ToByte(theNode10.InnerText);
							}
							else
							{
								theShip.Status = (_ActiveUnitStatus)Enum.Parse(typeof(_ActiveUnitStatus), theNode10.InnerText, ignoreCase: true);
							}
							if (theShip.Status == (_ActiveUnitStatus)9)
							{
								theShip.Status = _ActiveUnitStatus.RTB;
							}
							break;
						case "Name":
							theShip.Name = theNode10.InnerText;
							break;
						case "FSBR":
							theShip._FuelStateBefore_NeedToRefuel = (_ActiveUnitFuelState)Conversions.ToByte(theNode10.InnerText);
							break;
						case "AMP_OC_Speed":
							theShip._MissionPlannerOverrideCancellation_Speed = XmlConvert.ToSingle(theNode10.InnerText);
							break;
						case "SBPF_TF":
							theShip._TerrainFollowingBefore_WaitForPathfinder = Misc.ParseBool(theNode10.InnerText);
							break;
						case "DTN":
						case "DesiredTurnRate_Navigation":
							theShip.DesiredTurnRate_Navigation = (Waypoint.TurnRateCategory)Conversions.ToByte(theNode10.InnerText);
							break;
						case "AL":
							theShip.AutonomyLevel = (DroneAutonomyLevel)Conversions.ToInteger(theNode10.InnerText);
							break;
						case "FuelState":
							theShip._FuelState = (_ActiveUnitFuelState)Conversions.ToByte(theNode10.InnerText);
							break;
						case "Ship_Navigator":
						{
							Ship ship8 = theShip;
							ActiveUnit theParentPlatform = theShip;
							ship8.ship_Navigator_0 = Ship_Navigator.FromXML(ref theNode10, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "TUW":
							theShip.TimeUnderway = XmlConvert.ToSingle(theNode10.InnerText.Replace(",", "."));
							break;
						case "COA":
							theShip.ChanceOfAppearance = Conversions.ToInteger(theNode10.InnerText);
							break;
						case "DamagePts":
							if (!bool_3)
							{
								((ActiveUnit)theShip).set_DamagePts(ScenEditAction: true, (Weapon)null, XmlConvert.ToSingle(theNode10.InnerText));
							}
							break;
						case "AMP_OC_DAO":
							theShip._MissionPlannerOverrideCancellation_DesiredAltitudeOverride = Misc.ParseBool(theNode10.InnerText);
							break;
						case "OldDamagePercent":
							theShip._OldDamagePercent = XmlConvert.ToSingle(theNode10.InnerText);
							break;
						case "Ship_Weaponry":
						{
							Ship ship7 = theShip;
							ActiveUnit theParentPlatform = theShip;
							ship7.ship_Weaponry_0 = Ship_Weaponry.FromXML(ref theNode10, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "SBPF_ThrottleSetting":
							switch (theNode10.InnerText)
							{
							case "Loiter":
								theShip._ThrottleBefore_WaitForPathfinder = Throttle.Loiter;
								break;
							case "Cruise":
								theShip._ThrottleBefore_WaitForPathfinder = Throttle.Cruise;
								break;
							case "Flank":
								theShip._ThrottleBefore_WaitForPathfinder = Throttle.Flank;
								break;
							default:
								theShip._ThrottleBefore_WaitForPathfinder = (Throttle)Conversions.ToByte(theNode10.InnerText);
								break;
							case "Full":
								theShip._ThrottleBefore_WaitForPathfinder = Throttle.Full;
								break;
							case "FullStop":
								theShip._ThrottleBefore_WaitForPathfinder = Throttle.FullStop;
								break;
							}
							break;
						case "PrivateSnapshotMission":
							theShip.PrivateSnapshotMission = Mission.FromXML(ref theNode10, ref concurrentDictionary_0, ref scenario_0);
							break;
						case "SBR":
							theShip._StatusBefore_NeedToRefuel = (_ActiveUnitStatus)Conversions.ToByte(theNode10.InnerText);
							break;
						case "DesiredHeading":
						case "DH":
							((ActiveUnit)theShip).set_DesiredHeading(TurnRate.Max, XmlConvert.ToSingle(theNode10.InnerText));
							break;
						case "Ship_CommStuff":
						{
							Ship ship6 = theShip;
							ActiveUnit theParentPlatform = theShip;
							ship6.ship_CommStuff_0 = Ship_CommStuff.FromXML(ref theNode10, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "DEC":
							theShip._DestroyEventsChecked = Misc.ParseBool(theNode10.InnerText);
							break;
						case "ActiveUnit_AirOps":
						{
							Ship ship5 = theShip;
							ActiveUnit theParentPlatform = theShip;
							ship5._AirOps = ActiveUnit_AirOps.FromXML(ref theNode10, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "SBED_ThrottleSetting":
							switch (theNode10.InnerText)
							{
							case "Loiter":
								theShip._ThrottleBefore_EngagedDefensive = Throttle.Loiter;
								break;
							case "Cruise":
								theShip._ThrottleBefore_EngagedDefensive = Throttle.Cruise;
								break;
							default:
								theShip._ThrottleBefore_EngagedDefensive = (Throttle)Conversions.ToByte(theNode10.InnerText);
								break;
							case "Flank":
								theShip._ThrottleBefore_EngagedDefensive = Throttle.Flank;
								break;
							case "Full":
								theShip._ThrottleBefore_EngagedDefensive = Throttle.Full;
								break;
							case "FullStop":
								theShip._ThrottleBefore_EngagedDefensive = Throttle.FullStop;
								break;
							}
							break;
						case "TS":
						case "ThrottleSetting":
							switch (theNode10.InnerText)
							{
							case "FullStop":
								theShip.ThrottleSetting = Throttle.FullStop;
								break;
							case "Flank":
								theShip.ThrottleSetting = Throttle.Flank;
								break;
							default:
								theShip.ThrottleSetting = (Throttle)Conversions.ToByte(theNode10.InnerText);
								break;
							case "Full":
								theShip.ThrottleSetting = Throttle.Full;
								break;
							case "Cruise":
								theShip.ThrottleSetting = Throttle.Cruise;
								break;
							case "Loiter":
								theShip.ThrottleSetting = Throttle.Loiter;
								break;
							}
							break;
						case "SBED_DesiredSpeedOverride":
							theShip._DesiredSpeedOverrideBefore_EngagedDefensive = XmlConvert.ToSingle(theNode10.InnerText);
							break;
						case "Doctrine":
							if (!flag)
							{
								theShip.Doctrine = Doctrine.FromXML(scenario_0, ref theNode10, theShip);
							}
							else
							{
								theShip.Doctrine = Doctrine.FromXML(scenario_0, ref theNode10, theShip, theShip.Doctrine);
							}
							break;
						case "ActiveEnterAreaTriggers":
							if (flag)
							{
								theShip.ActiveEnterAreaTriggers.Clear();
							}
							foreach (XmlNode childNode12 in theNode10.ChildNodes)
							{
								string innerText2 = childNode12.InnerText;
								theShip.ActiveEnterAreaTriggers.Add(innerText2);
							}
							break;
						case "SBEO_TF":
							theShip._TerrainFollowingBefore_EngagedOffensive = Misc.ParseBool(theNode10.InnerText);
							break;
						case "WeaponState":
							theShip._WeaponState = (_ActiveUnitWeaponState)Conversions.ToSByte(theNode10.InnerText);
							break;
						case "Prof":
							theShip.Proficiency = (GlobalVariables.ProficiencyLevel)Conversions.ToInteger(theNode10.InnerText);
							break;
						case "SBED_TF":
							theShip._TerrainFollowingBefore_EngagedDefensive = Misc.ParseBool(theNode10.InnerText);
							break;
						case "OODA_E":
							theShip.HasCustomOODA = true;
							theShip.OODA_Evasion = Conversions.ToShort(theNode10.InnerText);
							break;
						case "AMP_OC_DSO":
							theShip._MissionPlannerOverrideCancellation_DesiredSpeedOverride = XmlConvert.ToSingle(theNode10.InnerText);
							break;
						case "CurrentAltitude":
						case "CA":
							((ActiveUnit)theShip).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, XmlConvert.ToSingle(theNode10.InnerText.Replace(",", ".")));
							break;
						case "Latitude_UnitEntersAreaCheck":
							theShip.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(theNode10.InnerText);
							break;
						case "OODA_D":
							theShip.HasCustomOODA = true;
							theShip.OODA_Detection = Conversions.ToShort(theNode10.InnerText);
							break;
						case "AssignedMission":
							if (theNode10.HasChildNodes)
							{
								XmlNode val3 = theNode10.ChildNodes[0];
								theShip._AssignedMissionOrPackage_ID = val3.InnerText;
							}
							break;
						case "Ship_Sensory":
						case "Sensory":
						{
							Ship ship4 = theShip;
							ActiveUnit theParentPlatform = theShip;
							ship4.ship_Sensory_0 = Ship_Sensory.FromXML(ref theNode10, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "EFSAR":
							theShip.EligibleForSAR = Misc.ParseBool(theNode10.InnerText);
							break;
						case "OODA_T":
							theShip.HasCustomOODA = true;
							theShip.OODA_Targeting = Conversions.ToShort(theNode10.InnerText);
							break;
						case "Longitude":
						case "Lon":
							((ActiveUnit)theShip).set_Longitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(theNode10.InnerText.Replace(",", ".")));
							break;
						case "ActiveRemainAreaTriggers":
						{
							string key = null;
							DateTime result2 = DateTime.MinValue;
							foreach (XmlNode childNode13 in theNode10.ChildNodes)
							{
								XmlNode val2 = childNode13;
								if (Operators.CompareString(val2.Name, "RemainAreaTrigger", false) != 0)
								{
									if (DateTime.TryParse(val2.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.None, out result2))
									{
										theShip.ActiveRemainAreaTriggers.Add(key, result2);
										continue;
									}
									string innerText = val2.InnerText;
									long result3 = default(long);
									if (long.TryParse(innerText, out result3))
									{
										result2 = DateTime.FromBinary(Conversions.ToLong(val2.InnerText));
										theShip.ActiveRemainAreaTriggers.Add(key, result2);
									}
								}
								else
								{
									key = val2.InnerText;
									result2 = DateTime.MinValue;
								}
							}
							break;
						}
						case "IBPU":
							theShip.IsBeingPickedUp = Misc.ParseBool(theNode10.InnerText);
							break;
						case "CustomIcon":
							theShip.CustomIcon = theNode10.InnerText;
							break;
						case "Side":
							theShip._SideName = theNode10.InnerText;
							break;
						case "AssignedTaskPool":
							if (theNode10.HasChildNodes)
							{
								XmlNode val = theNode10.ChildNodes[0];
								theShip._AssignedTaskPool_ID = val.InnerText;
							}
							break;
						case "DS":
						case "DesiredSpeed":
							theShip.DesiredSpeed = XmlConvert.ToSingle(theNode10.InnerText);
							break;
						case "Latitude":
						case "Lat":
							((ActiveUnit)theShip).set_Latitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(theNode10.InnerText.Replace(",", ".")));
							break;
						case "SBR_ThrottleSetting":
							switch (theNode10.InnerText)
							{
							case "Loiter":
								theShip._ThrottleBefore_NeedToRefuel = Throttle.Loiter;
								break;
							case "Full":
								theShip._ThrottleBefore_NeedToRefuel = Throttle.Full;
								break;
							default:
								theShip._ThrottleBefore_NeedToRefuel = (Throttle)Conversions.ToByte(theNode10.InnerText);
								break;
							case "Flank":
								theShip._ThrottleBefore_NeedToRefuel = Throttle.Flank;
								break;
							case "Cruise":
								theShip._ThrottleBefore_NeedToRefuel = Throttle.Cruise;
								break;
							case "FullStop":
								theShip._ThrottleBefore_NeedToRefuel = Throttle.FullStop;
								break;
							}
							break;
						case "Message":
							theShip.Message = theNode10.InnerText;
							break;
						case "Ship_AI":
						{
							Ship ship3 = theShip;
							ActiveUnit theParentPlatform = theShip;
							ship3.ship_AI_0 = Ship_AI.FromXML(ref theNode10, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "ActiveUnit_DockingOps":
						{
							Ship ship2 = theShip;
							ActiveUnit theParentPlatform = theShip;
							ship2.DockingOps = ActiveUnit_DockingOps.FromXML(ref theNode10, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "SBEO":
							theShip._StatusBefore_EngagedOffensive = (_ActiveUnitStatus)Conversions.ToByte(theNode10.InnerText);
							break;
						case "AMP_OC":
							theShip._MissionPlannerOverrideCancellation = Misc.ParseBool(theNode10.InnerText);
							break;
						case "Ship_Kinematics":
							ActiveUnit_Kinematics.FromXML(theNode10, concurrentDictionary_0, theShip);
							break;
						case "CS":
						case "CurrentSpeed":
							theShip.CurrentSpeed = XmlConvert.ToSingle(theNode10.InnerText.Replace(",", "."));
							break;
						case "SBR_TF":
							theShip._TerrainFollowingBefore_NeedToRefuel = Misc.ParseBool(theNode10.InnerText);
							break;
						case "SBEO_ThrottleSetting":
							switch (theNode10.InnerText)
							{
							case "Cruise":
								theShip._ThrottleBefore_EngagedOffensive = Throttle.Cruise;
								break;
							case "Flank":
								theShip._ThrottleBefore_EngagedOffensive = Throttle.Flank;
								break;
							default:
								theShip._ThrottleBefore_EngagedOffensive = (Throttle)Conversions.ToByte(theNode10.InnerText);
								break;
							case "Full":
								theShip._ThrottleBefore_EngagedOffensive = Throttle.Full;
								break;
							case "Loiter":
								theShip._ThrottleBefore_EngagedOffensive = Throttle.Loiter;
								break;
							case "FullStop":
								theShip._ThrottleBefore_EngagedOffensive = Throttle.FullStop;
								break;
							}
							break;
						case "SBED":
							theShip._StatusBefore_EngagedDefensive = (_ActiveUnitStatus)Conversions.ToByte(theNode10.InnerText);
							break;
						case "DT":
						case "DesiredTurnRate":
							theShip.DesiredTurnRate = (TurnRate)Conversions.ToByte(theNode10.InnerText);
							break;
						case "ParentGroup":
							theShip._ParentGroup_ID = theNode10.InnerText;
							break;
						case "Ship_Damage":
						{
							Ship ship = theShip;
							ActiveUnit theParentPlatform = theShip;
							ship.ship_Damage_0 = Ship_Damage.FromXML(ref theNode10, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "CH":
						case "CurrentHeading":
							theShip.CurrentHeading = XmlConvert.ToSingle(theNode10.InnerText.Replace(",", "."));
							break;
						case "IsAD":
						case "IsAutoDetectable":
							((ActiveUnit)theShip).set_IsAutoDetectable((Side)null, Misc.ParseBool(theNode10.InnerText));
							break;
						case "Longitude_UnitEntersAreaCheck":
							theShip.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(theNode10.InnerText);
							break;
						}
					}
					result = theShip;
				}
			}
			else
			{
				result = (Ship)concurrentDictionary_0[text];
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100762", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Ship();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void Set_AssignedMissionOrPackage(Mission value, bool SetMissionOnly, bool IgnoreCommsState, [Optional][DefaultParameterValue(0)] ref Mission.MissionAssignmentAttemptResult Result)
	{
		try
		{
			base.Set_AssignedMissionOrPackage(value, SetMissionOnly, IgnoreCommsState, ref Result);
			if (Result != Mission.MissionAssignmentAttemptResult.Success)
			{
				return;
			}
			foreach (ActiveUnit activeUnits_ in ParentScen.ActiveUnits_List)
			{
				if (activeUnits_ == null || !activeUnits_.IsSubmarine)
				{
					continue;
				}
				if (((Submarine)activeUnits_).IsTetheredROV)
				{
					if (activeUnits_.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: true) == this)
					{
						Mission.MissionAssignmentAttemptResult Result2 = Mission.MissionAssignmentAttemptResult.None;
						activeUnits_.Set_AssignedMissionOrPackage(value, SetMissionOnly, IgnoreCommsState, ref Result2);
					}
				}
				else if (((Submarine)activeUnits_).Type == Submarine._SubmarineType.UUV && activeUnits_.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: true) == this)
				{
					Mission.MissionAssignmentAttemptResult Result2 = Mission.MissionAssignmentAttemptResult.None;
					activeUnits_.Set_AssignedMissionOrPackage(value, SetMissionOnly, IgnoreCommsState, ref Result2);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100763", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool IsPurposeDesignedMCMPlatform()
	{
		int result;
		switch (Type)
		{
		default:
			result = 0;
			goto IL_0047;
		case _ShipType.ML:
		case (_ShipType)6009:
			result = 0;
			goto IL_0047;
		case _ShipType.MCDV:
		case _ShipType.MCD:
		case _ShipType.MCM:
		case _ShipType.MCS:
		case _ShipType.MHC:
		case _ShipType.MSC:
		case _ShipType.MSF:
		case _ShipType.MSI:
		case _ShipType.MSO:
			{
				return true;
			}
			IL_0047:
			return (byte)result != 0;
		}
	}

	public override void Determine_IsMCMPlatform()
	{
		if (IsPurposeDesignedMCMPlatform())
		{
			IsMCMPlatform_ThisPulse = 1;
			return;
		}
		List<Sensor> mineCountermeasures = MineCountermeasures;
		if (mineCountermeasures != null && mineCountermeasures.Count > 0)
		{
			IsMCMPlatform_ThisPulse = 1;
			return;
		}
		Sensor[] sensors_Cached = Sensors_Cached;
		int num = 0;
		while (true)
		{
			if (num < sensors_Cached.Length)
			{
				Sensor sensor = sensors_Cached[num];
				if (sensor != null && sensor.IsMineHuntingSensor)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			IsMCMPlatform_ThisPulse = 0;
			return;
		}
		IsMCMPlatform_ThisPulse = 1;
	}

	public override void Determine_IsMineLayingPlatform()
	{
		foreach (Mount mount in Mounts)
		{
			foreach (WeaponRec mountWeapon in mount.MountWeapons)
			{
				Weapon weapon = ParentScen.Cache_GetWeapon(mountWeapon.int_3);
				if (weapon != null && weapon.IsMine && mount.Status == PlatformComponent._ComponentStatus.Operational && mountWeapon.CurrentLoad != 0)
				{
					IsMineLayingPlatform_ThisPulse = 1;
					return;
				}
			}
		}
		IsMineLayingPlatform_ThisPulse = 0;
	}

	public override void PostDeserializationHousekeeping_General(ref Scenario theScen, ConcurrentDictionary<string, ScenarioObject> theDictionary, List<ActiveUnit> DiscardList, bool GameIsRunning)
	{
		base.PostDeserializationHousekeeping_General(ref theScen, theDictionary, DiscardList, GameIsRunning);
		ActiveUnit_DockingOps.PostDeserializationHousekeeping(DockingOps, ref theScen, theDictionary, GameIsRunning);
	}

	public override void DoTypeSpecificActions(float elapsedTime, ref LockRandom theRNG)
	{
		DockingOps.DoDockingOps(elapsedTime);
		if (IsOperating())
		{
			TimeUnderway += elapsedTime;
		}
		else
		{
			TimeUnderway = 0f;
		}
	}

	public override void SetThrottle(Throttle newThrottleSetting, float? SpecificDesiredSpeed = null)
	{
		try
		{
			if (!Kinematics.DesiredSpeedOverride.HasValue && !SpecificDesiredSpeed.HasValue && ((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false) != null && ((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false).GroupLead != null && ((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false).GroupLead != this && ((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredSpeed > 0f && Navigator.HaveReachedFormationStation())
			{
				DesiredSpeed = ((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredSpeed;
				ThrottleSetting = Kinematics.GetThrottleSuitableForThisSpeed(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), DesiredSpeed);
				return;
			}
			if (ThrottleSetting == newThrottleSetting && !SpecificDesiredSpeed.HasValue && !ParentScen.MinuteIsChangingOnThisPulse)
			{
				return;
			}
			if ((int)newThrottleSetting > 4)
			{
				newThrottleSetting = Throttle.Flank;
			}
			if ((int)newThrottleSetting < 0)
			{
				newThrottleSetting = Throttle.FullStop;
			}
			if (newThrottleSetting > MaxPossibleThrottleSetting)
			{
				newThrottleSetting = MaxPossibleThrottleSetting;
			}
			ThrottleSetting = newThrottleSetting;
			if (!IsGroup)
			{
				if (!SpecificDesiredSpeed.HasValue)
				{
					DesiredSpeed = Kinematics.GetMaximumSpeed(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false);
				}
				else if (IsGroupLead() && AI.MustSlowDownToAllowGroupFormUp())
				{
					DesiredSpeed = SpecificDesiredSpeed.Value;
				}
				else if (Kinematics.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
				{
					float? num = SpecificDesiredSpeed;
					float num2 = Kinematics.GetMaximumSpeed(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), newThrottleSetting, ValidateAndFixAltitude: false);
					bool? flag = ((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() > num2));
					bool? flag2 = (!flag) ?? flag;
					if (flag2 ?? true)
					{
						num = SpecificDesiredSpeed;
						num2 = Kinematics.GetMinimumSpeed((int)Math.Round(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), newThrottleSetting, ValidateAndFixAltitude: false);
						flag = ((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() < num2));
						if (((!flag) ?? flag) == true && flag2.HasValue)
						{
							DesiredSpeed = SpecificDesiredSpeed.Value;
							goto IL_031e;
						}
					}
					ThrottleSetting = Kinematics.GetThrottleSuitableForThisSpeed(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), SpecificDesiredSpeed.Value);
					num = SpecificDesiredSpeed;
					num2 = Kinematics.GetMaximumSpeed(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false);
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() > num2) : ((bool?)null)) == true)
					{
						DesiredSpeed = Kinematics.GetMaximumSpeed(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false);
					}
				}
				else
				{
					DesiredSpeed = Kinematics.GetMaximumSpeed(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (Throttle)Kinematics.ThrottlePreset, ValidateAndFixAltitude: false);
				}
			}
			goto IL_031e;
			IL_031e:
			RaiseEvent_ChangedThrottleSetting(this, ThrottleSetting);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100034957377", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override bool CanMoveToThisLocation(double theLat, double theLon, ref int MovementCost, bool IsPathfindingQuery, bool UsePathfindingBufferDistance, bool IgnoreMinesBehindUs, ref bool CheckNoNavZones, bool CheckForIcepack, ref bool CheckForMines, float? DistanceFromUnit, short? ProvidedElevation, ref List<ActiveUnit> ProvidedPiers, float ProximityThreshold_Deg, bool CheckIfTargetIsOutsideProsecutionArea, bool CheckDistanceToNoNavZones, ref string UserFeedback, ref bool AllowBounce)
	{
		bool result;
		try
		{
			MovementCost = 1;
			if (!double.IsNaN(theLat) && !double.IsNaN(theLon))
			{
				if (!CheckIfTargetIsOutsideProsecutionArea || Status != _ActiveUnitStatus.EngagedOffensive || ActiveMissionOrPackage() == null || ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Patrol)
				{
					goto IL_010d;
				}
				Patrol patrol = (Patrol)ActiveMissionOrPackage();
				Geopoint_Struct geopoint_Struct = new Geopoint_Struct(theLon, theLat);
				if (!((Module_Unit.Unit)this).get_IsInsideThisArea(patrol.ProsecutionArea, ParentScen, UseCache: true) || GeoPoint.IsInsideThisArea(geopoint_Struct.Latitude, geopoint_Struct.Longitude, patrol.ProsecutionArea))
				{
					goto IL_010d;
				}
				CheckNoNavZones = false;
				CheckForMines = false;
				UserFeedback = "The target has left the prosecution area.";
				result = false;
			}
			else
			{
				CheckNoNavZones = false;
				CheckForMines = false;
				UserFeedback = "Unknown.";
				result = false;
			}
			goto end_IL_0033;
			IL_0266:
			int num;
			result = (byte)num != 0;
			goto end_IL_0033;
			IL_0186:
			if (!method_16(theLat, theLon, CheckForIcepack, ProvidedElevation, ref ProvidedPiers))
			{
				CheckNoNavZones = false;
				CheckForMines = false;
				UserFeedback = "The unit cannot sail on land.";
				result = false;
			}
			else
			{
				bool flag = false;
				UnguidedWeapon unguidedWeapon = null;
				if (((ActiveUnit)this).get_UnitSide(SetSideOnly: false) != null)
				{
					if (((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Contacts_NonAU.Count > 0)
					{
						Parallel.ForEach(((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Contacts_NonAU.ToList(), [SpecialName] (string theID, ParallelLoopState loopstate) =>
						{
							if (theID != null)
							{
								UnguidedWeapon value = null;
								ParentScen.UnguidedWeapons.TryGetValue(theID, out value);
								if (value != null && value.IsMine)
								{
									short num3 = (short)((ActiveUnit)this).get_SafeDistanceAgainstKnownMineType_meters(value.Type, UsePathfindingBufferDistance);
									string feedbackMessage = "";
									Math.Abs(Module_Unit.AngleOffThisUnitsBoresight(value, this, DistinguishBetweenStarboardAndPort: true, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue));
									if (!IsPathfindingQuery)
									{
										if (IgnoreMinesBehindUs)
										{
											return;
										}
										UnguidedWeapon myUnit = value;
										Ship observerUnit = this;
										string feedbackMessage2 = "";
										if (!(Math.Abs(Module_Unit.AngleOffThisUnitsBoresight(myUnit, observerUnit, DistinguishBetweenStarboardAndPort: true, ref feedbackMessage2)) <= 45f))
										{
											return;
										}
									}
									if (Math2.CalcDist(theLat, theLon, ((Module_Unit.Unit)value).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)value).get_Longitude((GlobalVariables.BooleanObject)null)) * 1852f < (float)num3)
									{
										if (IsMineLayingPlatform_ThisPulse == -1)
										{
											Determine_IsMineLayingPlatform();
										}
										if ((IsMineLayingPlatform_ThisPulse == 0 || !base.IsOnActiveMiningMission || !(value.TimeToDetonate > 0f)) && (!((value.TimeToDetonate > 3600f) & (value.FiringParent_ID != null)) || !string.Equals(value.FiringParent_ID, ObjectID, StringComparison.OrdinalIgnoreCase)))
										{
											flag = true;
											unguidedWeapon = value;
											loopstate.Stop();
										}
									}
								}
							}
						});
					}
					if (flag)
					{
						CheckNoNavZones = false;
						CheckForMines = true;
						if (IsMCMPlatform_ThisPulse == -1)
						{
							Determine_IsMCMPlatform();
						}
						if (IsMCMPlatform_ThisPulse == 0)
						{
							Mission mission = ActiveMissionOrPackage();
							if (mission == null || mission.MissionClass != Mission._MissionClass.MineClearing)
							{
								UserFeedback = "The unit is not a mine sweeper or mine hunter, and known mines are too close.";
								num = 0;
								goto IL_0266;
							}
						}
						UserFeedback = "A mine is too close.";
						num = 0;
						goto IL_0266;
					}
				}
				CheckNoNavZones = false;
				CheckForMines = false;
				result = true;
			}
			goto end_IL_0033;
			IL_010d:
			if (CheckDistanceToNoNavZones)
			{
				CheckNoNavZones = DistanceToNearestNoNavZone();
			}
			if (!CheckNoNavZones && !IsPathfindingQuery)
			{
				goto IL_0186;
			}
			string firstZoneName = null;
			if (!IsInsideNoNavZones(theLat, theLon, ProximityThreshold_Deg, ref firstZoneName))
			{
				goto IL_0186;
			}
			CheckNoNavZones = true;
			CheckForMines = false;
			UserFeedback = "The point is inside a No-Nav Zone.";
			int num2;
			if (firstZoneName != null)
			{
				UserFeedback = UserFeedback + " (" + firstZoneName + ")";
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			result = (byte)num2 != 0;
			end_IL_0033:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200285", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			CheckNoNavZones = false;
			CheckForMines = false;
			UserFeedback = "Error.";
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool method_16(double double_0, double double_1, bool bool_3, short? nullable_17, ref List<ActiveUnit> list_2)
	{
		bool result;
		try
		{
			int num;
			if (Type == _ShipType.LCAC)
			{
				LandCover.LandCoverType landCoverAtThisPoint = LandCover.GetLandCoverAtThisPoint(double_0, double_1, ParentScen);
				result = landCoverAtThisPoint != LandCover.LandCoverType.Deciduous_Broadleaf_forest && landCoverAtThisPoint != LandCover.LandCoverType.Deciduous_Needleleaf_forest && landCoverAtThisPoint != LandCover.LandCoverType.Evergreen_Broadleaf_forest && landCoverAtThisPoint != LandCover.LandCoverType.Evergreen_Needleleaf_forest && landCoverAtThisPoint != LandCover.LandCoverType.Mixed_forest;
			}
			else if (!GeoPoint.get_IsInCanal(double_0, double_1))
			{
				if (GeoPoint.IsInPierLane(double_0, double_1, ParentScen))
				{
					result = true;
				}
				else
				{
					if (!bool_3)
					{
						num = -2;
						goto IL_0086;
					}
					if (IsIcebreaker)
					{
						num = -2;
						goto IL_0086;
					}
					if (!SeaIceProvider.PointIsUnderIce(double_1, double_0))
					{
						num = -2;
						goto IL_0086;
					}
					result = false;
				}
			}
			else
			{
				result = true;
			}
			goto end_IL_0001;
			IL_0086:
			short num2 = (short)num;
			short num3;
			if (nullable_17.HasValue)
			{
				num3 = nullable_17.Value;
				goto IL_0146;
			}
			Scenario parentScen = ParentScen;
			if (parentScen != null && parentScen.NatureSideExists())
			{
				CustomEnvironmentZone[] customEnvironmentZones = ParentScen.GetNatureSide().CustomEnvironmentZones;
				int num4 = 0;
				while (num4 < customEnvironmentZones.Length)
				{
					CustomEnvironmentZone customEnvironmentZone = customEnvironmentZones[num4];
					if (!customEnvironmentZone.HasCustomTerrain || !GeoPoint.IsInsideThisArea(double_0, double_1, customEnvironmentZone.Area_AsArray) || customEnvironmentZone.TerrainType != LandCover.LandCoverType.Water)
					{
						num4 = checked(num4 + 1);
						continue;
					}
					result = true;
					goto end_IL_0001;
				}
			}
			(bool, short?) tuple = Terrain.PointIsOverland(double_0, double_1);
			if (!tuple.Item1)
			{
				num3 = ((!tuple.Item2.HasValue) ? Terrain.GetElevation(double_0, double_1, RequestIsFromGUI: false, ParentScen) : tuple.Item2.Value);
				goto IL_0146;
			}
			result = false;
			goto end_IL_0001;
			IL_0146:
			result = ((num3 < num2) ? true : false);
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100765", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num5;
			if (!Debugger.IsAttached)
			{
				num5 = 0;
			}
			else
			{
				Debugger.Break();
				num5 = 0;
			}
			result = (byte)num5 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void DoFuelConsumption(float elapsedTime)
	{
		try
		{
			if (IsNuke || ThrottleSetting == Throttle.FullStop || (!Navigator.HasPlottedCourse() && CurrentSpeed == 0f) || IsOutOfFuel)
			{
				return;
			}
			float theQuantity = FuelConsumption(ThrottleSetting, null, null, null, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false) * elapsedTime;
			FuelRec fuelRec = default(FuelRec);
			foreach (FuelRec item in Fuel_ReadOnly)
			{
				if (Propulsion[0].CanUseThisFuelType(item.FuelType))
				{
					fuelRec = item;
					break;
				}
			}
			Fuel_Subtract(theQuantity, fuelRec.FuelType);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100770", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void Fuel_Subtract(float theQuantity, FuelRec._FuelType theType)
	{
		try
		{
			if (theQuantity == 0f)
			{
				return;
			}
			FuelRec fuelRec = (from theFuelrec in Fuel_ReadOnly
				select (theFuelrec) into theFuelrec
				where theFuelrec.FuelType == theType
				select theFuelrec).ElementAtOrDefault(0);
			if (fuelRec.CurrentQuantity > theQuantity)
			{
				fuelRec.SubtractFuel(theQuantity);
				return;
			}
			bool num = fuelRec.CurrentQuantity > 0f;
			fuelRec.CurrentQuantity = 0f;
			SetThrottle(Throttle.FullStop);
			if (num)
			{
				AddMessage(Name + " (" + Misc.RemoveHiddenString(UnitClass) + ") has run out of fuel and lies dead in the water!", Name + "ran out of fuel!", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100771", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override float FuelConsumption(Throttle theThrottleSetting, AltBand theAltBand, float? theSpeed, float? theAltitude, bool BingoFuelCheck, bool ReserveFuelQtyCalc, bool ExcludeDroppablePayload, bool ValidateThrottleSelection, bool FlightplanFuelEstimate)
	{
		float result;
		if (Propulsion.Count != 0)
		{
			AltBand altBand = null;
			try
			{
				if (Propulsion[0].Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					result = 0f;
				}
				else if (Propulsion[0].AltBands.Length == 0)
				{
					result = 0f;
				}
				else
				{
					altBand = ((theAltBand != null) ? theAltBand : ((!theAltitude.HasValue) ? Kinematics.GetCurrentAltBand(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ValidateAndFixAltitude: false) : Kinematics.GetCurrentAltBand_CurrentAltitude(theAltitude.Value, null, ValidateAndFixAltitude: false)));
					if (altBand == null)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new Exception();
					}
					float num;
					float num2;
					float num3;
					switch (theThrottleSetting)
					{
					default:
						result = 0f;
						goto end_IL_0012;
					case Throttle.FullStop:
						result = 0f;
						goto end_IL_0012;
					case Throttle.Loiter:
						num = altBand.Consumption_Loiter;
						num2 = 0f;
						goto IL_0260;
					case Throttle.Cruise:
						if (Propulsion[0].AltBands[0].Consumption_Cruise > 0f)
						{
							num = altBand.Consumption_Cruise;
							num2 = altBand.Consumption_Loiter;
							goto IL_0260;
						}
						result = FuelConsumption(Throttle.Loiter, theAltBand, theSpeed, theAltitude, BingoFuelCheck, ReserveFuelQtyCalc, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
						goto end_IL_0012;
					case Throttle.Full:
						if (altBand.Speed_Full.HasValue)
						{
							float? consumption_Flank = Propulsion[0].AltBands[0].Consumption_Full;
							if ((consumption_Flank.HasValue ? new bool?(consumption_Flank.GetValueOrDefault() > 0f) : ((bool?)null)) == true)
							{
								num = altBand.Consumption_Full.Value;
								_ = (float)altBand.Speed_Full.Value;
								num2 = altBand.Consumption_Cruise;
								goto IL_0260;
							}
						}
						result = FuelConsumption(Throttle.Cruise, theAltBand, theSpeed, theAltitude, BingoFuelCheck, ReserveFuelQtyCalc, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
						goto end_IL_0012;
					case Throttle.Flank:
						{
							if (!altBand.Speed_Flank.HasValue)
							{
								break;
							}
							float? consumption_Flank = Propulsion[0].AltBands[0].Consumption_Flank;
							if (((!consumption_Flank.HasValue) ? ((bool?)null) : new bool?(consumption_Flank.GetValueOrDefault() > 0f)) != true)
							{
								break;
							}
							num = altBand.Consumption_Flank.Value;
							_ = (float)altBand.Speed_Flank.Value;
							num2 = ((!altBand.Speed_Full.HasValue) ? altBand.Consumption_Cruise : altBand.Consumption_Full.Value);
							goto IL_0260;
						}
						IL_0260:
						num3 = num;
						if (theSpeed.HasValue)
						{
							float num4 = Kinematics.GetMaximumSpeed(theAltitude.Value, theThrottleSetting, ValidateAndFixAltitude: false);
							float? consumption_Flank = theSpeed;
							if ((consumption_Flank.HasValue ? new bool?(consumption_Flank.GetValueOrDefault() < num4) : ((bool?)null)) == true)
							{
								float num5 = Kinematics.GetMaximumSpeed(theAltitude.Value, theThrottleSetting - 1, ValidateAndFixAltitude: false);
								consumption_Flank = theSpeed;
								float num6;
								if (((!consumption_Flank.HasValue) ? ((bool?)null) : new bool?(consumption_Flank.GetValueOrDefault() >= num5)) != true)
								{
									num6 = 0f;
								}
								else
								{
									num6 = ((theSpeed - num5) / (num4 - num5)).Value;
									num6 = Math.Abs(num6);
								}
								num3 = num2 + (num - num2) * num6;
							}
						}
						result = num3 / 60f;
						goto end_IL_0012;
					}
					result = FuelConsumption(Throttle.Full, theAltBand, theSpeed, theAltitude, BingoFuelCheck, ReserveFuelQtyCalc, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
				}
				end_IL_0012:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101253", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = 0f;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = 0f;
		}
		return result;
	}

	public void CommenceSinking(float OldDamagePercent, string WhatCausedDestruction = null)
	{
		AddMessage(Name + " is sinking!!!", Name + " sinking!!!", LoggedMessage.MessageType.UnitLost, 1, new Geopoint_Struct(((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
		Kinematics.ExportLocationEvent("CommenceSinking");
		ParentScen.ExportUnitDestructionEvent(this, "Ship has suffered catastrophic structural damage and is sinking.", WhatCausedDestruction);
		IsBeingDestroyed = true;
		PreDestructionHousekeeping(ScenEditAction: false, TriggeredBySinking: true, OldDamagePercent, DestroyUnitNow: true);
	}

	public override void Destroy(bool ScenEditAction, bool IsAimpointFacility, bool DestroyUnitNow, string theReason, string WhatCausedIt = null, bool RegisterAsLosses = true)
	{
		bool triggeredBySinking = false;
		try
		{
			IsBeingDestroyed = true;
			DockingOps.HostDockFacility = null;
			if (!IsOperating() && !ScenEditAction)
			{
				ParentScen?.AddMessage(Name + " has been destroyed!", Name + " destroyed!", LoggedMessage.MessageType.UnitLost, 0, ObjectID, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			PreDestructionHousekeeping(ScenEditAction, triggeredBySinking, Damage.DamagePercent, DestroyUnitNow, RegisterAsLosses);
			if (!IsSinking && !ScenEditAction)
			{
				ParentScen?.AddMessage(Name + " has been destroyed!", Name + " destroyed!", LoggedMessage.MessageType.UnitLost, 0, ObjectID, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			List<Side> list = new List<Side>(ParentScen?.Sides_ReadOnly);
			foreach (Side item in list)
			{
				item.HandleUnitDestruction(this, ScenEditAction);
			}
			foreach (Weapon item2 in ParentScen?.AllWeaponsAlive)
			{
				List<Contact> list2 = new List<Contact>();
				Contact[] targets_ReadOnly = ((ActiveUnit)item2).AI.Targets_ReadOnly;
				foreach (Contact contact in targets_ReadOnly)
				{
					if (contact.ActualUnit == this)
					{
						list2.Add(contact);
					}
				}
				foreach (Contact item3 in list2)
				{
					((ActiveUnit)item2).AI.DropTarget(item3);
				}
			}
			if (DockFacilities_ReadOnly.Length > 0)
			{
				foreach (ActiveUnit item4 in DockingOps.EmbarkedBoats_ReadOnly)
				{
					item4.Destroy(ScenEditAction, IsAimpointFacility, DestroyUnitNow, "Destroyed as the object it is docked to is being destroyed", "Host Destruction", RegisterAsLosses);
				}
			}
			if (AirFacilities_ReadOnly.Length > 0)
			{
				foreach (Aircraft item5 in AirOps.EmbarkedAircraft_ReadOnly)
				{
					item5.Destroy(ScenEditAction, IsAimpointFacility, DestroyUnitNow, "Destroyed as the object it is landed on is being destroyed", "Host Destruction", RegisterAsLosses);
				}
			}
			if (IsGroupMember())
			{
				((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false).Units.Remove(ObjectID);
			}
			if (ScenEditAction)
			{
				DeleteImmediately();
			}
			else if (!DestroyUnitNow)
			{
				DeleteImmediately();
			}
			else
			{
				ParentScen?.DestroyThisUnit(this, theReason);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100772", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Ship(ref Scenario theScen, string theGUID = null)
		: base(ref theScen, theGUID)
	{
		Flags = default(_Flags);
		Rudder = new Rudder(this);
		CIC = new CIC(this, "Bridge / CIC");
		ActiveUnit theUnit = this;
		ship_Navigator_0 = new Ship_Navigator(ref theUnit);
		theUnit = this;
		ship_AI_0 = new Ship_AI(ref theUnit);
		IsShip = true;
		IsBoat = true;
		UnitType = GlobalVariables.ActiveUnitType.Ship;
	}

	public override void Teleport(ref Scenario theScen, double Destination_Lon, double Destination_Lat)
	{
		base.Teleport(ref theScen, Destination_Lon, Destination_Lat);
		Kinematics.ExportLocationEvent("Teleport");
	}

	internal float GetCargo_Crew()
	{
		return Cargo_Crew;
	}

	float ICargoHost.GetCargo_Crew()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Crew
		return this.GetCargo_Crew();
	}

	internal float GetCargo_Area()
	{
		if (Cargo_Type == CargoType.Personnel && Cargo_Area == 0f)
		{
			return (float)Math.Round(Cargo_Crew * Mount.PersonnelArea, 2);
		}
		return Cargo_Area;
	}

	float ICargoHost.GetCargo_Area()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Area
		return this.GetCargo_Area();
	}

	internal CargoType GetCargo_Type()
	{
		return Cargo_Type;
	}

	CargoType ICargoHost.GetCargo_Type()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Type
		return this.GetCargo_Type();
	}

	internal float GetCargo_Mass()
	{
		if (Cargo_Type == CargoType.Personnel && Cargo_Mass == 0f)
		{
			return (float)Math.Round(Cargo_Crew * Mount.PersonnelMass, 1);
		}
		return Cargo_Mass;
	}

	float ICargoHost.GetCargo_Mass()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Mass
		return this.GetCargo_Mass();
	}

	public float GetCargo_TowingCapacity()
	{
		return 0f;
	}

	public float GetCargo_MassAvailable()
	{
		return CargoHostHelper.GetAvailableMass(this, OnboardCargo);
	}

	internal bool GetCargo_ParadropCapable()
	{
		return false;
	}

	bool ICargoHost.GetCargo_ParadropCapable()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_ParadropCapable
		return this.GetCargo_ParadropCapable();
	}

	internal bool CanStackCargo()
	{
		return false;
	}

	bool ICargoHost.CanStackCargo()
	{
		//ILSpy generated this explicit interface implementation from .override directive in CanStackCargo
		return this.CanStackCargo();
	}

	public float GetCargo_Height()
	{
		return 0f;
	}

	internal int GetLoadTime(List<Cargo> CargoItems)
	{
		if (CargoItems != null && CargoItems.Count > 0)
		{
			double num = ActiveUnit_DockingOps.DEFAULT_CARGO_LOAD_TIME;
			int num2 = 0;
			double num3 = default(double);
			foreach (Cargo CargoItem in CargoItems)
			{
				num3 += (double)CargoItem.RequiredMass;
				num2 = Math.Max(num2, CargoItem.GetAdditionalLoadTime());
			}
			switch (Type)
			{
			case _ShipType.AKR:
			case _ShipType.TAKR:
			{
				double maximumTime2 = Math.Max(10.0, 0.3 * (double)GetCargo_Mass());
				num = ActiveUnit_DockingOps.GetCargoMoveTime(10.0, maximumTime2, num3, GetCargo_Mass());
				break;
			}
			case _ShipType.LCAC:
				num = ActiveUnit_DockingOps.GetCargoMoveTime(5.0, 60.0, num3, GetCargo_Mass());
				break;
			case _ShipType.LCM:
			case _ShipType.LCP:
			case _ShipType.LCT:
			case _ShipType.LCU:
			case _ShipType.LCVP:
				num = ActiveUnit_DockingOps.GetCargoMoveTime(10.0, 60.0, num3, GetCargo_Mass());
				break;
			default:
				if (!IsSmallCraft())
				{
					double maximumTime = Math.Max(ActiveUnit_DockingOps.DEFAULT_CARGO_LOAD_TIME, 0.6 * (double)GetCargo_Mass());
					num = ActiveUnit_DockingOps.GetCargoMoveTime(ActiveUnit_DockingOps.DEFAULT_CARGO_LOAD_TIME, maximumTime, num3, GetCargo_Mass());
				}
				else
				{
					num = ActiveUnit_DockingOps.GetCargoMoveTime(5.0, 60.0, num3, GetCargo_Mass());
				}
				break;
			case _ShipType.LSH:
			case _ShipType.LSM:
			case _ShipType.LST:
			case _ShipType.LSU:
			case _ShipType.LSV:
				num = ActiveUnit_DockingOps.GetCargoMoveTime(10.0, 90.0, num3, GetCargo_Mass());
				break;
			}
			num += (double)num2;
			return (int)Math.Round(num * 60.0);
		}
		return 0;
	}

	int ICargoHost.GetLoadTime(List<Cargo> CargoItems)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetLoadTime
		return this.GetLoadTime(CargoItems);
	}

	internal int GetUnloadTime(List<Cargo> CargoItems)
	{
		int result;
		if (CargoItems == null)
		{
			result = 0;
		}
		else
		{
			if (CargoItems.Count > 0)
			{
				double num = ActiveUnit_DockingOps.DEFAULT_CARGO_UNLOAD_TIME;
				double num2 = default(double);
				foreach (Cargo CargoItem in CargoItems)
				{
					num2 += (double)CargoItem.RequiredMass;
				}
				switch (Type)
				{
				case _ShipType.AKR:
				case _ShipType.TAKR:
				{
					double maximumTime2 = Math.Max(10.0, 0.25 * (double)GetCargo_Mass());
					num = ActiveUnit_DockingOps.GetCargoMoveTime(10.0, maximumTime2, num2, GetCargo_Mass());
					break;
				}
				case _ShipType.LCAC:
					num = ActiveUnit_DockingOps.GetCargoMoveTime(8.5, 11.5, num2, GetCargo_Mass());
					break;
				case _ShipType.LCM:
				case _ShipType.LCP:
				case _ShipType.LCT:
				case _ShipType.LCU:
				case _ShipType.LCVP:
					num = ActiveUnit_DockingOps.GetCargoMoveTime(5.0, 15.0, num2, GetCargo_Mass());
					break;
				default:
					if (!IsSmallCraft())
					{
						double maximumTime = Math.Max(ActiveUnit_DockingOps.DEFAULT_CARGO_UNLOAD_TIME, 0.6 * (double)GetCargo_Mass());
						num = ActiveUnit_DockingOps.GetCargoMoveTime(ActiveUnit_DockingOps.DEFAULT_CARGO_UNLOAD_TIME, maximumTime, num2, GetCargo_Mass());
					}
					else
					{
						num = ActiveUnit_DockingOps.GetCargoMoveTime(2.5, 30.0, num2, GetCargo_Mass());
					}
					break;
				case _ShipType.LSH:
				case _ShipType.LSM:
				case _ShipType.LST:
				case _ShipType.LSU:
				case _ShipType.LSV:
					num = ActiveUnit_DockingOps.GetCargoMoveTime(10.0, 30.0, num2, GetCargo_Mass());
					break;
				}
				return (int)Math.Round(num * 60.0);
			}
			result = 0;
		}
		return result;
	}

	int ICargoHost.GetUnloadTime(List<Cargo> CargoItems)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetUnloadTime
		return this.GetUnloadTime(CargoItems);
	}

	public bool CanLoad(ICargoClient PotentialCargo)
	{
		return CargoHostHelper.CanLoad(this, OnboardCargo, PotentialCargo);
	}

	internal bool IsSmallCraft()
	{
		if (Length < 13f)
		{
			return Draft < 0.7f;
		}
		return false;
	}

	public bool Add(Cargo c)
	{
		return CargoHostHelper.Add(this, c);
	}

	public bool Remove(Cargo c)
	{
		return CargoHostHelper.Remove(this, c);
	}

	public bool CanTow(ICargoClient PotentialCargo)
	{
		return false;
	}

	internal bool IsCavitating()
	{
		if (Type == _ShipType.LCAC)
		{
			return false;
		}
		return CurrentSpeed > 0f && DesiredSpeed >= (float)Kinematics.CavitationSpeed(0f);
	}

	bool IBoat.IsCavitating()
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsCavitating
		return this.IsCavitating();
	}

	static Ship()
	{
		Class72.smethod_20();
	}
}
