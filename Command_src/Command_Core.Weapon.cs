using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using DarkUI.Collections;
using Easy.Common;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;
using ThreadSafeCollections;

namespace Command_Core;

public class Weapon : ActiveUnit, IFlier
{
	public delegate void WeaponImpactEventHandler(Scenario theScen, Weapon theWeapon, Module_Unit.Unit theTarget, bool DirectHit);

	public enum _WeaponType : short
	{
		None = 1001,
		GuidedWeapon = 2001,
		Rocket = 2002,
		IronBomb = 2003,
		Gun = 2004,
		Decoy_Expendable = 2005,
		Decoy_Towed = 2006,
		Decoy_Vehicle = 2007,
		TrainingRound = 2008,
		Dispenser = 2009,
		ContactBomb_Suicide = 2010,
		ContactBomb_Sabotage = 2011,
		GuidedProjectile = 2012,
		SmallArms = 2013,
		UAV_Expendable = 2014,
		SensorPod = 3001,
		DropTank = 3002,
		BuddyStore = 3003,
		FerryTank = 3004,
		Torpedo = 4001,
		DepthCharge = 4002,
		Sonobuoy = 4003,
		BottomMine = 4004,
		MooredMine = 4005,
		FloatingMine = 4006,
		MovingMine = 4007,
		RisingMine = 4008,
		DriftingMine = 4009,
		AttachedMine = 4010,
		DummyMine = 4011,
		GuidedDepthCharge = 4012,
		HeliTowedPackage = 4101,
		Aircraft = 4102,
		Ship = 4103,
		Submarine = 4104,
		Satellite = 4105,
		GroundUnit = 4106,
		BallisticMissile = 5000,
		RV = 5001,
		PalletWeapon = 5002,
		Laser = 6001,
		Microwave = 6002,
		LaserDazzler = 6003,
		HGV = 8001,
		GlideVehicle = 8002,
		HypersonicCruiseMissile = 8003,
		Cargo = 9001,
		Troops = 9002,
		Paratroops = 9003
	}

	public enum WeaponGuidanceType
	{
		Undetermined,
		SemiActive,
		Inertial_Plus_SemiActive,
		Datalink_Plus_SemiActive,
		Passive,
		Inertial_Plus_Passive,
		DataLink_Plus_Passive,
		Active,
		Datalink_Plus_Active,
		Inertial_Plus_Active,
		CommandGuided_Datalinked,
		TVM,
		BeamRiding,
		Inertial,
		SemiActive_Plus_Active,
		TimesharedSemiActive_Plus_Active
	}

	public enum WeaponSearchPatternType : byte
	{
		None,
		Snake,
		Circle
	}

	public enum DetonationMedium : byte
	{
		Air,
		Surface,
		Underwater,
		Underground,
		Space
	}

	public struct WeaponFlags
	{
		public enum AttitudeControlEnum
		{
			None,
			Aerodynamic,
			NonAerodynamic,
			Combined
		}

		public bool IlluminateAtLaunch;

		public bool LauncherOccupiedDuringGuidance;

		public bool TerminalIllumination;

		public bool SupportsBuddyIllumination;

		public bool HomeOnJam;

		public bool SternChase_AAM;

		public bool RearAspect_AAM;

		public bool AllAspect_AAM;

		public bool HOB_AAM;

		public bool NoDivingTargetMod;

		public bool CapableVsSeaskimmer;

		public bool ARMTargetMemory;

		public bool LoiterCapability;

		public bool ParachuteLoiter;

		public bool SearchPattern;

		public bool DriveThroughLogic;

		public bool BearingOnlyLaunch;

		public bool IsBallisticMissile;

		public bool IsMultiStageMissile;

		public bool TerrainFollowing;

		public bool C_RAM;

		public bool LOAL;

		public bool LOAL_CEC;

		public bool Pod_TerrainAvoidance;

		public bool Pod_TerrainFollowing;

		public bool Pod_DayOnlyNavigation;

		public bool Pod_DayOnlyNavigationAttack;

		public bool Pod_NightNavigation;

		public bool Pod_NightNavigationAttack;

		public bool Pod_ReconDayOnly;

		public bool Pod_ReconNight;

		public bool Navigation_INS;

		public bool Navigation_INS_GPS;

		public bool Navigation_TERCOM;

		public bool Navigation_AltitudeControl;

		public bool PreBriefedTargetOnly;

		public bool UsesImagingSeeker;

		public bool Mine_ContactFuze;

		public bool Mine_SimpleMagneticFuze;

		public bool Mine_TotalFieldMagnetometerFuze;

		public bool Mine_PassiveBroadBandAcousticFuze;

		public bool Mine_PassiveNarrowBandAcousticFuze;

		public bool Mine_PressureFuze;

		public bool Mine_SeismicFuze;

		public bool Mine_DelayCounter;

		public bool Mine_ArmingDelay;

		public bool Mine_TargetDiscriminationAndIdentification;

		public bool Mine_RemoteControlled;

		public bool Warhead_SingleRV;

		public bool Warhead_MRV;

		public bool Warhead_MIRV;

		public bool CapableVsMobileTarget;

		public bool IsRetardedWeapon;

		public bool Torpedo_StraightRunning;

		public bool Torpedo_WakeHoming;

		public bool Torpedo_StraightRunningTimeDetonation;

		public bool Torpedo_PatternRunning;

		public bool LevelCruiseFlight;

		public bool TerminalManeuver_PopUp;

		public bool TerminalManeuver_ZigZag;

		public bool TerminalManeuver_Random;

		public bool ReAttack_Capability;

		public AttitudeControlEnum AttitudeControl;

		public bool Navigation_GPS;

		public bool Navigation_GLONASS;

		public bool Navigation_Beidou;

		public bool Navigation_NavIC;

		public bool Fuze_Impact;

		public bool Fuze_Barometric_Altimeter;

		public bool Fuze_Proximity;

		public bool Fuze_Combination;

		public bool Fuze_ShockFactor_Under_Keel_Optimized;

		public bool DepressedBallisticTrajectory;
	}

	private class Class9 : IComparer<ActiveUnit>
	{
		private readonly Module_Unit.Unit unit_0;

		public Class9(Module_Unit.Unit unit_1)
		{
			unit_0 = unit_1;
		}

		public int Compare(ActiveUnit x, ActiveUnit y)
		{
			return x.RangeToUnit_Horiz(unit_0).CompareTo(y.RangeToUnit_Horiz(unit_0));
		}

		static Class9()
		{
			Class72.smethod_20();
		}
	}

	public enum ActionToUndertake
	{
		None,
		GoAutonomous,
		SelfDestruct
	}

	public enum AerospaceObjectControlType
	{
		Aerodynamic,
		NonAerodynamic,
		Combined
	}

	public enum GEnum1
	{
		None,
		WW2eraManualDeadReckoning,
		WW2eraSextant,
		INS_1950s,
		INS_1960s,
		INS_1970s,
		INS_1980s,
		INS_1990s_TacticalWeapon,
		INS_1990s_StrategicWeapon,
		INS_1990s_MEMSBased
	}

	public enum WeaponSpecialMode
	{
		None,
		HighAltitudeDetonation
	}

	[CompilerGenerated]
	internal sealed class _Closure$__203-0
	{
		public Warhead $VB$Local_theWH;

		public Weapon $VB$Me;

		public _Closure$__203-0(_Closure$__203-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theWH = arg0.$VB$Local_theWH;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(WeaponRec theCW)
		{
			return theCW.get_ReferenceWeapon($VB$Me.ParentScen).DBID == $VB$Local_theWH.get_CarriedWeapon($VB$Me.ParentScen).DBID;
		}

		[SpecialName]
		internal bool _Lambda$__1(Warhead theW)
		{
			return theW.get_CarriedWeapon($VB$Me.ParentScen).DBID == $VB$Local_theWH.get_CarriedWeapon($VB$Me.ParentScen).DBID;
		}

		static _Closure$__203-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__205-0
	{
		public Warhead $VB$Local_theWH;

		public Weapon $VB$Me;

		public _Closure$__205-0(_Closure$__205-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theWH = arg0.$VB$Local_theWH;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(WeaponRec theCW)
		{
			if (theCW != null)
			{
				return theCW.get_ReferenceWeapon($VB$Me.ParentScen).DBID == $VB$Local_theWH.get_CarriedWeapon($VB$Me.ParentScen).DBID;
			}
			return false;
		}

		[SpecialName]
		internal bool _Lambda$__1(Warhead w)
		{
			return w.get_CarriedWeapon($VB$Me.ParentScen).DBID == $VB$Local_theWH.get_CarriedWeapon($VB$Me.ParentScen).DBID;
		}

		static _Closure$__205-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__402-0
	{
		public Side $VB$Local_theSide;

		public Contact $VB$Local_theTarget;

		public Weapon $VB$Me;

		public _Closure$__402-0(_Closure$__402-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theSide = arg0.$VB$Local_theSide;
				$VB$Local_theTarget = arg0.$VB$Local_theTarget;
			}
		}

		[SpecialName]
		internal int _Lambda$__0(int theCandidateKey)
		{
			return $VB$Me.method_23($VB$Local_theSide, $VB$Local_theTarget, theCandidateKey);
		}

		static _Closure$__402-0()
		{
			Class72.smethod_20();
		}
	}

	private _WeaponType _WeaponType_0;

	private GlobalVariables.TechGenerationClass techGenerationClass_0;

	public float Span;

	public float Diameter;

	public int CEP_Surface_Nominal;

	private int int_5;

	public int CEP_Land_Nominal;

	private int int_6;

	public float CruiseAltitude_AGL;

	public float CruiseAltitude_ASL;

	public int Waypoints;

	public int IlluminationTime;

	public int AirPOK;

	public int SurfPOK;

	public int LandPOK;

	public int SubPOK;

	public int MaxLaunchSpeed;

	public int MinLaunchSpeed;

	internal Doctrine.WRA_Weapon SingularWeaponWRA;

	internal bool IsFullyAutonomous;

	internal bool IsSemiAutonomous;

	internal bool GuidanceHasSemiActivePhase;

	internal bool GuidanceHasDataLink;

	internal bool ReportedDatalinkLostConnectionIssue;

	internal FixedSizeQueue<bool> RecentPNTChecks;

	private bool? nullable_16;

	private float? nullable_17;

	private float? nullable_18;

	public bool IsFuelTank;

	public bool IsWeaponPallet;

	public bool IsTrainingRound;

	public bool IsHGV;

	public bool IsReEntryVehicle;

	public bool IsSoftKill;

	internal bool IsUnderGNSSDenialThisPulse;

	private float float_8;

	private float float_9;

	private float float_10;

	private float float_11;

	private float float_12;

	private float float_13;

	private float float_14;

	private float float_15;

	private float float_16;

	private float float_17;

	private float float_18;

	private float float_19;

	private float float_20;

	private float float_21;

	private float float_22;

	private float float_23;

	private int int_7;

	private int int_8;

	public float SnapUpDown;

	public string TextDescription;

	public WeaponTargets ValidTargets;

	public Warhead[] Warheads;

	public List<int> Directors;

	protected float _BlindTime;

	protected float _DatalinkRetargetTime;

	public WeaponFlags Flags;

	private ActiveUnit activeUnit_0;

	protected string _FiringParent_ID;

	private ActiveUnit activeUnit_1;

	protected string _DataLinkParent_ID;

	public WeaponSearchPatternType SearchPatternType;

	private WeaponGuidanceType weaponGuidanceType_0;

	public GeoPoint LaunchPoint;

	internal float LaunchSpeed;

	public float TimeSinceLaunch;

	public float TimeSinceBurnout;

	internal float _TimeToDetonate;

	public bool CanActAsSensor;

	private Sensor sensor_1;

	protected string _SensorIlluminatingForMe_ObjectID;

	public KeyValuePair<int, EmissionContainer> ARM_SpecifiedEMission;

	public bool ARM_SpecifiedEmissionIsMandatory;

	internal bool ImpactsOnThisPulse_ActualUnit;

	internal bool ImpactsOnThisPulse_Contact;

	[AccessedThroughProperty("WeaponWeapons")]
	[CompilerGenerated]
	private ObservableList<WeaponRec> observableList_3;

	public List<WeaponSpecialMode> ValidSpecialModes;

	private float float_24;

	public int TotalBurnTime;

	public int? FlightEndurance;

	public Lazy<bool> IsMIRVedMissile;

	public Lazy<bool> IsMRVedMissile;

	public Lazy<bool> UsesBoostCoastModel;

	public Lazy<bool> IsNuke;

	protected Weapon_Navigator _Navigator;

	private Weapon_AI weapon_AI_0;

	private Weapon_Kinematics weapon_Kinematics_0;

	private Weapon_Sensory weapon_Sensory_0;

	private Weapon_CommStuff weapon_CommStuff_0;

	private Weapon_Damage weapon_Damage_0;

	protected ActiveUnit _IlluminatorUnit;

	[CompilerGenerated]
	private static WeaponImpactEventHandler weaponImpactEventHandler_0;

	internal bool DetonationOccurs;

	public const float ParachuteLoiterPitch = -85f;

	public const float ParachuteLoiterDescentMetersPerSecond = 50f;

	public double check;

	internal int _BurnoutWeight_DB;

	private bool? nullable_19;

	private bool bool_3;

	private bool bool_4;

	private bool? nullable_20;

	internal bool _LaunchSpeedDependentBurnoutSpeedsSet;

	private bool? nullable_21;

	internal WeaponGuidanceType? CachedGuidance;

	public Lazy<bool> HasRVs;

	public static float StandOffMaxRange;

	public bool BOL_Capable
	{
		get
		{
			if (Flags.BearingOnlyLaunch)
			{
				return true;
			}
			return Type == _WeaponType.Gun || Type == _WeaponType.Rocket;
		}
	}

	public _WeaponType Type
	{
		get
		{
			return _WeaponType_0;
		}
		set
		{
			_WeaponType_0 = value;
			IsFuelTank = value == _WeaponType.DropTank || value == _WeaponType.FerryTank;
			IsWeaponPallet = value == _WeaponType.PalletWeapon;
			IsDecoy = value == _WeaponType.Decoy_Expendable || value == _WeaponType.Decoy_Towed || value == _WeaponType.Decoy_Vehicle;
			IsTrainingRound = value == _WeaponType.TrainingRound;
			IsHGV = value == _WeaponType.HGV;
			IsReEntryVehicle = IsHGV || value == _WeaponType.RV;
			IsSoftKill = value == _WeaponType.Decoy_Expendable || value == _WeaponType.SensorPod || value == _WeaponType.Decoy_Towed || value == _WeaponType.Decoy_Vehicle;
		}
	}

	public float MaxLandRange
	{
		get
		{
			if (!IsWeaponPallet)
			{
				return float_8;
			}
			if (WeaponWeapons == null || WeaponWeapons.Count == 0)
			{
				InitializeWeaponWeaponsPallet();
			}
			return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MaxLandRange;
		}
		set
		{
			float_8 = value;
		}
	}

	public float MinLandRange
	{
		get
		{
			if (!IsWeaponPallet)
			{
				return float_9;
			}
			if (WeaponWeapons == null || WeaponWeapons.Count == 0)
			{
				InitializeWeaponWeaponsPallet();
			}
			return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MinLandRange;
		}
		set
		{
			float_9 = value;
		}
	}

	public float MaxAirRange
	{
		get
		{
			if (!IsWeaponPallet)
			{
				return float_10;
			}
			if (WeaponWeapons == null || WeaponWeapons.Count == 0)
			{
				InitializeWeaponWeaponsPallet();
			}
			return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MaxAirRange;
		}
		set
		{
			float_10 = value;
		}
	}

	public float MinAirRange
	{
		get
		{
			if (IsWeaponPallet)
			{
				if (WeaponWeapons == null || WeaponWeapons.Count == 0)
				{
					InitializeWeaponWeaponsPallet();
				}
				return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MinAirRange;
			}
			return float_11;
		}
		set
		{
			float_11 = value;
		}
	}

	public float MaxSurfaceRange
	{
		get
		{
			if (!IsWeaponPallet)
			{
				return float_12;
			}
			if (WeaponWeapons == null || WeaponWeapons.Count == 0)
			{
				InitializeWeaponWeaponsPallet();
			}
			return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MaxSurfaceRange;
		}
		set
		{
			float_12 = value;
		}
	}

	public float MinSurfaceRange
	{
		get
		{
			if (!IsWeaponPallet)
			{
				return float_13;
			}
			if (WeaponWeapons == null || WeaponWeapons.Count == 0)
			{
				InitializeWeaponWeaponsPallet();
			}
			return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MinSurfaceRange;
		}
		set
		{
			float_13 = value;
		}
	}

	public float MaxSubsurfaceRange
	{
		get
		{
			if (IsWeaponPallet)
			{
				if (WeaponWeapons == null || WeaponWeapons.Count == 0)
				{
					InitializeWeaponWeaponsPallet();
				}
				return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MaxSubsurfaceRange;
			}
			return float_14;
		}
		set
		{
			float_14 = value;
		}
	}

	public float MinSubsurfaceRange
	{
		get
		{
			if (!IsWeaponPallet)
			{
				return float_15;
			}
			if (WeaponWeapons == null || WeaponWeapons.Count == 0)
			{
				InitializeWeaponWeaponsPallet();
			}
			return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MinSubsurfaceRange;
		}
		set
		{
			float_15 = value;
		}
	}

	public float MinLaunchAlt_AGL
	{
		get
		{
			if (IsWeaponPallet)
			{
				if (WeaponWeapons == null || WeaponWeapons.Count == 0)
				{
					InitializeWeaponWeaponsPallet();
				}
				return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MinLaunchAlt_AGL;
			}
			return float_16;
		}
		set
		{
			float_16 = value;
		}
	}

	public float MaxLaunchAlt_AGL
	{
		get
		{
			if (IsWeaponPallet)
			{
				if (WeaponWeapons == null || WeaponWeapons.Count == 0)
				{
					InitializeWeaponWeaponsPallet();
				}
				return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MaxLaunchAlt_AGL;
			}
			return float_17;
		}
		set
		{
			float_17 = value;
		}
	}

	public float MinTargetAlt_AGL
	{
		get
		{
			if (!IsWeaponPallet)
			{
				return float_18;
			}
			if (WeaponWeapons == null || WeaponWeapons.Count == 0)
			{
				InitializeWeaponWeaponsPallet();
			}
			return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MinTargetAlt_AGL;
		}
		set
		{
			float_18 = value;
		}
	}

	public float MaxTargetAlt_AGL
	{
		get
		{
			if (!IsWeaponPallet)
			{
				return float_19;
			}
			if (WeaponWeapons == null || WeaponWeapons.Count == 0)
			{
				InitializeWeaponWeaponsPallet();
			}
			return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MaxTargetAlt_AGL;
		}
		set
		{
			float_19 = value;
		}
	}

	public float MinLaunchAlt_ASL
	{
		get
		{
			if (!IsWeaponPallet)
			{
				return float_20;
			}
			if (WeaponWeapons == null || WeaponWeapons.Count == 0)
			{
				InitializeWeaponWeaponsPallet();
			}
			return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MinLaunchAlt_ASL;
		}
		set
		{
			float_20 = value;
		}
	}

	public float MaxLaunchAlt_ASL
	{
		get
		{
			if (!IsWeaponPallet)
			{
				return float_21;
			}
			if (WeaponWeapons == null || WeaponWeapons.Count == 0)
			{
				InitializeWeaponWeaponsPallet();
			}
			return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MaxLaunchAlt_ASL;
		}
		set
		{
			float_21 = value;
		}
	}

	public float MinTargetAlt_ASL
	{
		get
		{
			if (!IsWeaponPallet)
			{
				return float_22;
			}
			if (WeaponWeapons == null || WeaponWeapons.Count == 0)
			{
				InitializeWeaponWeaponsPallet();
			}
			return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MinTargetAlt_ASL;
		}
		set
		{
			float_22 = value;
		}
	}

	public float MaxTargetAlt_ASL
	{
		get
		{
			if (IsWeaponPallet)
			{
				if (WeaponWeapons == null || WeaponWeapons.Count == 0)
				{
					InitializeWeaponWeaponsPallet();
				}
				return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MaxTargetAlt_ASL;
			}
			return float_23;
		}
		set
		{
			float_23 = value;
		}
	}

	public int MinTargetSpeed
	{
		get
		{
			if (!IsWeaponPallet)
			{
				return int_7;
			}
			if (WeaponWeapons == null || WeaponWeapons.Count == 0)
			{
				InitializeWeaponWeaponsPallet();
			}
			return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MinTargetSpeed;
		}
		set
		{
			int_7 = value;
		}
	}

	public int MaxTargetSpeed
	{
		get
		{
			if (!IsWeaponPallet)
			{
				return int_8;
			}
			if (WeaponWeapons == null || WeaponWeapons.Count == 0)
			{
				InitializeWeaponWeaponsPallet();
			}
			return WeaponWeapons[0].get_ReferenceWeapon(ParentScen).MaxTargetSpeed;
		}
		set
		{
			int_8 = value;
		}
	}

	public virtual ObservableList<WeaponRec> WeaponWeapons
	{
		[CompilerGenerated]
		get
		{
			return observableList_3;
		}
		[CompilerGenerated]
		set
		{
			observableList_3 = value;
		}
	}

	public override bool UseAerialUnitUI
	{
		get
		{
			int result;
			if (base.IsMobileDecoy_Air)
			{
				result = 1;
			}
			else
			{
				if (!base.isUAV)
				{
					return false;
				}
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	public override bool SupportsAltitude_Control => Flags.Navigation_AltitudeControl;

	public override bool SupportsAttitude_Pitch
	{
		get
		{
			if (!bool_4)
			{
				bool_3 = Type == _WeaponType.RV || Type == _WeaponType.GuidedWeapon || IsBallisticMissile || IsWeaponPallet;
				bool_4 = true;
			}
			return bool_3;
		}
	}

	public override float DesiredPitch
	{
		get
		{
			return base.DesiredPitch;
		}
		set
		{
			base.DesiredPitch = value;
		}
	}

	internal float InfiniteGlideAngle
	{
		get
		{
			switch (Type)
			{
			case _WeaponType.GuidedProjectile:
				return -30f;
			case _WeaponType.GuidedWeapon:
				return -5f;
			case _WeaponType.Rocket:
			case _WeaponType.Gun:
				return -30f;
			default:
				return 0f;
			case _WeaponType.HGV:
				return -70f;
			case _WeaponType.BallisticMissile:
			case _WeaponType.RV:
				return -80f;
			case _WeaponType.Torpedo:
				return -85f;
			}
		}
	}

	internal float TimeToReseek
	{
		get
		{
			return float_24;
		}
		set
		{
			float_24 = value;
		}
	}

	public GlobalVariables.TechGenerationClass TechGeneration
	{
		get
		{
			if (techGenerationClass_0 == GlobalVariables.TechGenerationClass.None && Sensors_Cached.Length > 0)
			{
				GlobalVariables.TechGenerationClass techGeneration = Sensors_Cached[0].TechGeneration;
				if (GlobalVariables.TechGenerationClass.const_17 >= techGeneration && techGeneration >= GlobalVariables.TechGenerationClass.const_2)
				{
					techGenerationClass_0 = techGeneration;
				}
			}
			return techGenerationClass_0;
		}
		set
		{
			techGenerationClass_0 = value;
		}
	}

	public override float CurrentAltitude
	{
		get
		{
			return base.get_CurrentAltitude(DoSanityCheck, GlobalVariables.ObjectTrue);
		}
		set
		{
			if (DoSanityCheck && IsGuidedWeapon() && value < 6.0959997f)
			{
				value = 6.0959997f;
			}
			base.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, value);
		}
	}

	public Sensor[] TerminalGuidingSensors
	{
		get
		{
			switch (Guidance)
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return null;
			case WeaponGuidanceType.SemiActive:
			case WeaponGuidanceType.Inertial_Plus_SemiActive:
			case WeaponGuidanceType.Datalink_Plus_SemiActive:
			case WeaponGuidanceType.CommandGuided_Datalinked:
			case WeaponGuidanceType.TVM:
			case WeaponGuidanceType.BeamRiding:
				return new Sensor[1] { SensorProvidingFireControlForMe };
			case WeaponGuidanceType.Inertial:
				return null;
			case WeaponGuidanceType.Passive:
			case WeaponGuidanceType.Inertial_Plus_Passive:
			case WeaponGuidanceType.DataLink_Plus_Passive:
			case WeaponGuidanceType.Active:
			case WeaponGuidanceType.Datalink_Plus_Active:
			case WeaponGuidanceType.Inertial_Plus_Active:
			case WeaponGuidanceType.SemiActive_Plus_Active:
			case WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
				return _Sensors.ToArray();
			}
		}
	}

	public override bool DesiredAltitude_UseTerrainFollowing
	{
		get
		{
			return _TerrainFollowing;
		}
		set
		{
			_TerrainFollowing = value;
		}
	}

	public bool NeedsVisualLOSBeforeLaunch
	{
		get
		{
			WeaponGuidanceType guidance = Guidance;
			if ((uint)(guidance - 1) > 1u && (uint)(guidance - 4) > 1u && guidance != WeaponGuidanceType.BeamRiding)
			{
				return false;
			}
			if (Sensors_Cached.Length <= 0)
			{
				return false;
			}
			Sensor.Sensor_Type type = Sensors_Cached[0].Type;
			if ((uint)(type - 2003) > 1u && type != Sensor.Sensor_Type.LaserSpotTracker)
			{
				return false;
			}
			int result2;
			if (IsSurfaceContact)
			{
				int result;
				if (Flags.Navigation_INS)
				{
					result = 0;
				}
				else if (Flags.Navigation_INS_GPS)
				{
					result = 0;
				}
				else
				{
					if (!Flags.Navigation_TERCOM)
					{
						result2 = 1;
						goto IL_008d;
					}
					result = 0;
				}
				return (byte)result != 0;
			}
			result2 = 1;
			goto IL_008d;
			IL_008d:
			return (byte)result2 != 0;
		}
	}

	public List<string> ValidTargets_Description
	{
		get
		{
			List<string> list = new List<string>();
			if (ValidTargets.Aircraft)
			{
				list.Add("Aircraft");
			}
			if (ValidTargets.Helicopter)
			{
				list.Add("Helicopters");
			}
			if (ValidTargets.Submarine)
			{
				list.Add("Submarines");
			}
			if (ValidTargets.SurfaceVessel)
			{
				list.Add("Surface Ships");
			}
			if (ValidTargets.LandStructure_Hard)
			{
				list.Add("Land Structures (Hard)");
			}
			if (ValidTargets.LandStructure_Soft)
			{
				list.Add("Land Structures (Soft)");
			}
			if (ValidTargets.MobileTarget_Hard)
			{
				list.Add("Mobile Units (Hard)");
			}
			if (ValidTargets.MobileTarget_Soft)
			{
				list.Add("Mobile Units (Soft)");
			}
			if (ValidTargets.Radar)
			{
				list.Add("Radars");
			}
			if (ValidTargets.Runway)
			{
				list.Add("Runways");
			}
			if (ValidTargets.Mine)
			{
				list.Add("Mines");
			}
			if (ValidTargets.Missile)
			{
				list.Add("Missiles & Guided Bombs");
			}
			if (ValidTargets.Torpedo)
			{
				list.Add("Torpedoes");
			}
			return list;
		}
	}

	public string Type_Description => Misc.ToEnglishString(Type);

	public override CommDevice[] Comms_ReadOnly
	{
		get
		{
			if (Type == _WeaponType.Sonobuoy)
			{
				return _Comms;
			}
			return base.Comms_ReadOnly;
		}
	}

	public bool IsLongFlightCruiseMissile
	{
		get
		{
			int result;
			if (base.IsMissile)
			{
				if (!IsASuW_Land && !IsASuW_Naval)
				{
					result = 0;
					goto IL_0069;
				}
				if (CruiseAltitude_AGL != 0f && Propulsion.Count > 0 && Propulsion[0].AltBands.Length == 1 && Fuel_ReadOnly[0].MaxQuantity > 600)
				{
					return true;
				}
			}
			result = 0;
			goto IL_0069;
			IL_0069:
			return (byte)result != 0;
		}
	}

	public bool SupportsWaypoints
	{
		get
		{
			int result2;
			if (!IsHGV)
			{
				if (!method_16())
				{
					int result;
					if (Type == _WeaponType.GuidedWeapon)
					{
						if (Propulsion.Count > 0 && Propulsion[0].Type == Engine.EngineType.WeaponCoast && !IsDecoy)
						{
							return false;
						}
						if (!IsASuW_Land && !IsASuW_Naval)
						{
							result = 0;
						}
						else
						{
							if (Waypoints > 0)
							{
								return true;
							}
							result = 0;
						}
					}
					else
					{
						if (IsDecoy || base.isUAV)
						{
							return Waypoints > 0;
						}
						result = 0;
					}
					return (byte)result != 0;
				}
				result2 = 1;
			}
			else
			{
				result2 = 1;
			}
			return (byte)result2 != 0;
		}
	}

	public bool IsChaffBundle
	{
		get
		{
			if (!nullable_20.HasValue)
			{
				nullable_20 = Type == _WeaponType.Decoy_Expendable && Name.ToLower().Contains("chaff");
			}
			return nullable_20.Value;
		}
	}

	public bool IsMine
	{
		get
		{
			int result;
			switch (Type)
			{
			case _WeaponType.DummyMine:
				result = 1;
				break;
			default:
				return false;
			case _WeaponType.BottomMine:
			case _WeaponType.MooredMine:
			case _WeaponType.FloatingMine:
			case _WeaponType.MovingMine:
			case _WeaponType.RisingMine:
			case _WeaponType.DriftingMine:
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
	}

	public bool IsUnguidedBallisticWeapon
	{
		get
		{
			if (Guidance != WeaponGuidanceType.Inertial)
			{
				return false;
			}
			_WeaponType type = Type;
			int result;
			if (type > _WeaponType.DriftingMine)
			{
				if (type != _WeaponType.RV && (uint)(type - 9001) > 2u)
				{
					result = 0;
					goto IL_0047;
				}
			}
			else if ((uint)(type - 2002) > 2u && (uint)(type - 4002) > 7u)
			{
				result = 0;
				goto IL_0047;
			}
			return true;
			IL_0047:
			return (byte)result != 0;
		}
	}

	public bool IsPalletizedWeapon
	{
		get
		{
			int result;
			if (FiringParent == null)
			{
				result = 0;
			}
			else
			{
				if (FiringParent.IsPalletWeapon)
				{
					return true;
				}
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public float DP_Total
	{
		get
		{
			float num = 0f;
			Warhead[] warheads = Warheads;
			foreach (Warhead warhead in warheads)
			{
				num += warhead.DP;
			}
			return num;
		}
	}

	public float MaxDownRange
	{
		get
		{
			float result;
			try
			{
				float num = ReleaseAltitude_ASL - ReleaseAltitude_AGL;
				bool num2 = MinLaunchAlt_ASL != 0f && ReleaseAltitude_ASL < MinLaunchAlt_ASL;
				bool flag = MaxLaunchAlt_ASL != 0f && ReleaseAltitude_ASL > MaxLaunchAlt_ASL;
				bool flag2 = MinLaunchAlt_AGL != 0f && ReleaseAltitude_AGL < MinLaunchAlt_AGL;
				bool flag3 = MaxLaunchAlt_AGL != 0f && ReleaseAltitude_AGL > MaxLaunchAlt_AGL;
				float num3 = MinLaunchAlt_AGL;
				if (num3 == 0f && MinLaunchAlt_ASL != 0f)
				{
					num3 = MinLaunchAlt_ASL - num;
				}
				float num4 = MaxLaunchAlt_AGL;
				if (num4 == 0f && MaxLaunchAlt_ASL != 0f)
				{
					num4 = MaxLaunchAlt_ASL - num;
				}
				float num5 = method_21(theContactType);
				if (!num2 && !flag2)
				{
					if (!flag && !flag3)
					{
						if (num4 == 0f && num3 == 0f)
						{
							result = num5;
						}
						else
						{
							float val = (ReleaseAltitude_AGL - num3) / (num4 - num3);
							val = Math.Max(0f, Math.Min(1f, val));
							bool flag4 = true;
							float num6;
							switch (Type)
							{
							default:
								flag4 = false;
								num6 = 1f;
								break;
							case _WeaponType.Rocket:
								num6 = 0.7f;
								break;
							case _WeaponType.IronBomb:
								num6 = 0.5f;
								break;
							case _WeaponType.Gun:
								num6 = 0.8f;
								break;
							}
							if (flag4)
							{
								float num7 = num6 + (1f - num6) * val;
								result = Math.Max(num5, method_21(Contact_Base.ContactType.Submarine)) * num7;
							}
							else
							{
								result = Math.Max(num5, method_21(Contact_Base.ContactType.Submarine));
							}
						}
					}
					else
					{
						result = num5;
					}
				}
				else
				{
					result = -1f;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100884", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = 0f;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public float MaxRange_NoTargetType
	{
		get
		{
			float num = 0f;
			float num2 = (IsWeaponPallet ? MaxAirRange : float_10);
			float num3 = ((!IsWeaponPallet) ? float_12 : MaxSurfaceRange);
			float num4 = ((!IsWeaponPallet) ? float_8 : MaxLandRange);
			float num5 = ((!IsWeaponPallet) ? float_14 : MaxSubsurfaceRange);
			num = ((num2 < num) ? num : num2);
			num = ((num3 < num) ? num : num3);
			num = ((num4 < num) ? num : num4);
			return (num5 < num) ? num : num5;
		}
	}

	public float MinRange_NoTargetType => Math.Max(MinAirRange, Math.Max(MinSurfaceRange, Math.Max(MinLandRange, MinSubsurfaceRange)));

	public float AcceptableCrossRangeAmbiguity
	{
		get
		{
			float result;
			try
			{
				switch (Guidance)
				{
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new NotImplementedException();
				case WeaponGuidanceType.Inertial_Plus_SemiActive:
				case WeaponGuidanceType.Datalink_Plus_SemiActive:
				case WeaponGuidanceType.Passive:
				case WeaponGuidanceType.Inertial_Plus_Passive:
				case WeaponGuidanceType.DataLink_Plus_Passive:
				case WeaponGuidanceType.Active:
				case WeaponGuidanceType.Datalink_Plus_Active:
				case WeaponGuidanceType.Inertial_Plus_Active:
					result = ((_Sensors.Count != 0) ? _Sensors.OrderByDescending([SpecialName] (Sensor theS) => theS.Swath_Total).ElementAtOrDefault(0).Swath_Total : 0f);
					break;
				case WeaponGuidanceType.Inertial:
					if (Warheads.Length == 0)
					{
						result = 0f;
						break;
					}
					if (Warheads[0].Type == Warhead.WarheadType.Weapon)
					{
						Weapon weapon = Warheads[0].get_CarriedWeapon(ParentScen);
						if (weapon._Sensors.Count > 0)
						{
							result = weapon._Sensors[0].Swath_Total;
							break;
						}
						if (weapon.Warheads.Length <= 0)
						{
							result = 0f;
							break;
						}
						if (weapon.Warheads[0].IsExplosive)
						{
							DetonationMedium theMedium;
							switch (weapon.Type)
							{
							default:
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								throw new NotImplementedException();
							case _WeaponType.GuidedWeapon:
							case _WeaponType.Rocket:
							case _WeaponType.IronBomb:
							case _WeaponType.Gun:
							case _WeaponType.GuidedProjectile:
							case _WeaponType.BallisticMissile:
							case _WeaponType.RV:
							case _WeaponType.HGV:
								theMedium = DetonationMedium.Air;
								break;
							case _WeaponType.Torpedo:
							case _WeaponType.DepthCharge:
							case _WeaponType.BottomMine:
							case _WeaponType.MooredMine:
							case _WeaponType.FloatingMine:
							case _WeaponType.MovingMine:
							case _WeaponType.RisingMine:
							case _WeaponType.DriftingMine:
								theMedium = DetonationMedium.Underwater;
								break;
							}
							result = Explosion.GetCutoffRange_Blast_nm(weapon.Warheads[0].DP, theMedium);
							break;
						}
					}
					result = 0f;
					break;
				case WeaponGuidanceType.SemiActive:
				case WeaponGuidanceType.CommandGuided_Datalinked:
				case WeaponGuidanceType.TVM:
				case WeaponGuidanceType.BeamRiding:
				case WeaponGuidanceType.SemiActive_Plus_Active:
				case WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
					result = 0f;
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100885", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = 0f;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool IsContactExplosive
	{
		get
		{
			int result;
			switch (Type)
			{
			case _WeaponType.AttachedMine:
				result = 1;
				break;
			default:
				return false;
			case _WeaponType.ContactBomb_Suicide:
			case _WeaponType.ContactBomb_Sabotage:
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
	}

	public float AcceptableDownRangeAmbiguity
	{
		get
		{
			float result;
			try
			{
				if (!IsContactExplosive)
				{
					switch (Guidance)
					{
					default:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new NotImplementedException();
					case WeaponGuidanceType.Inertial_Plus_SemiActive:
					case WeaponGuidanceType.Datalink_Plus_SemiActive:
					case WeaponGuidanceType.Passive:
					case WeaponGuidanceType.Inertial_Plus_Passive:
					case WeaponGuidanceType.DataLink_Plus_Passive:
					case WeaponGuidanceType.Active:
					case WeaponGuidanceType.Datalink_Plus_Active:
					case WeaponGuidanceType.Inertial_Plus_Active:
						result = MaxRange_NoTargetType;
						break;
					case WeaponGuidanceType.Inertial:
						if (Warheads.Length != 0)
						{
							if (Warheads[0].Type == Warhead.WarheadType.Weapon)
							{
								Weapon weapon = Warheads[0].get_CarriedWeapon(ParentScen);
								if (weapon._Sensors.Count > 0)
								{
									result = weapon._Sensors[0].Swath_Total;
									break;
								}
								if (weapon.Warheads.Length <= 0)
								{
									result = 0f;
									break;
								}
								if (weapon.Warheads[0].IsExplosive)
								{
									DetonationMedium theMedium;
									switch (weapon.Type)
									{
									default:
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										throw new NotImplementedException();
									case _WeaponType.GuidedWeapon:
									case _WeaponType.Rocket:
									case _WeaponType.IronBomb:
									case _WeaponType.Gun:
									case _WeaponType.BallisticMissile:
									case _WeaponType.RV:
									case _WeaponType.HGV:
										theMedium = DetonationMedium.Air;
										break;
									case _WeaponType.Torpedo:
									case _WeaponType.DepthCharge:
									case _WeaponType.BottomMine:
									case _WeaponType.MooredMine:
									case _WeaponType.FloatingMine:
									case _WeaponType.MovingMine:
									case _WeaponType.RisingMine:
									case _WeaponType.DriftingMine:
										theMedium = DetonationMedium.Underwater;
										break;
									}
									result = Explosion.GetCutoffRange_Blast_nm(weapon.Warheads[0].DP, theMedium);
									break;
								}
							}
							if (Warheads[0].IsExplosive)
							{
								DetonationMedium theMedium2;
								switch (Type)
								{
								default:
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									throw new NotImplementedException();
								case _WeaponType.GuidedWeapon:
								case _WeaponType.Rocket:
								case _WeaponType.IronBomb:
								case _WeaponType.Gun:
								case _WeaponType.GuidedProjectile:
								case _WeaponType.BallisticMissile:
								case _WeaponType.RV:
								case _WeaponType.HGV:
									theMedium2 = DetonationMedium.Air;
									break;
								case _WeaponType.Torpedo:
								case _WeaponType.DepthCharge:
								case _WeaponType.BottomMine:
								case _WeaponType.MooredMine:
								case _WeaponType.FloatingMine:
								case _WeaponType.MovingMine:
								case _WeaponType.RisingMine:
								case _WeaponType.DriftingMine:
								case _WeaponType.AttachedMine:
									theMedium2 = DetonationMedium.Underwater;
									break;
								}
								result = Explosion.GetCutoffRange_Blast_nm(Warheads[0].DP, theMedium2);
							}
							else
							{
								result = 0f;
							}
						}
						else
						{
							result = 0f;
						}
						break;
					case WeaponGuidanceType.SemiActive:
					case WeaponGuidanceType.CommandGuided_Datalinked:
					case WeaponGuidanceType.TVM:
					case WeaponGuidanceType.BeamRiding:
					case WeaponGuidanceType.SemiActive_Plus_Active:
					case WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
						result = 0f;
						break;
					}
				}
				else
				{
					result = 0f;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200294", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = 0f;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool HasManInTheLoop
	{
		get
		{
			int result;
			switch (Guidance)
			{
			default:
				result = 0;
				goto IL_004f;
			case WeaponGuidanceType.Inertial_Plus_SemiActive:
			case WeaponGuidanceType.Passive:
			case WeaponGuidanceType.Inertial_Plus_Passive:
			case WeaponGuidanceType.Active:
			case WeaponGuidanceType.Inertial_Plus_Active:
			case WeaponGuidanceType.TVM:
			case WeaponGuidanceType.Inertial:
				result = 0;
				goto IL_004f;
			case WeaponGuidanceType.SemiActive:
			case WeaponGuidanceType.Datalink_Plus_SemiActive:
			case WeaponGuidanceType.DataLink_Plus_Passive:
			case WeaponGuidanceType.Datalink_Plus_Active:
			case WeaponGuidanceType.CommandGuided_Datalinked:
			case WeaponGuidanceType.BeamRiding:
			case WeaponGuidanceType.SemiActive_Plus_Active:
			case WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
				{
					if (Information.IsNothing((object)DataLinkParent))
					{
						return false;
					}
					return true;
				}
				IL_004f:
				return (byte)result != 0;
			}
		}
	}

	public bool IsBrilliantWeapon
	{
		get
		{
			foreach (Sensor sensor in _Sensors)
			{
				if (sensor.Codes.Classification)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool IsArmed
	{
		get
		{
			bool result;
			try
			{
				WeaponGuidanceType guidance = Guidance;
				if (guidance == WeaponGuidanceType.Inertial)
				{
					if (Navigator.Has_NonPathfind_NonFP_PlottedCourse())
					{
						Waypoint waypoint = Navigator.PlottedCourse[Navigator.PlottedCourse.Count() - 1];
						float num = Math2.CalcDist(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), waypoint.Latitude, waypoint.Longitude);
						float num2 = Math2.CalcDist(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), LaunchPoint.Latitude, LaunchPoint.Longitude);
						result = num < num2;
					}
					else
					{
						result = true;
					}
				}
				else
				{
					result = true;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100887", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num3;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num3 = 0;
				}
				else
				{
					num3 = 0;
				}
				result = (byte)num3 != 0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public WeaponGuidanceType Guidance
	{
		get
		{
			if (weaponGuidanceType_0 == WeaponGuidanceType.Undetermined)
			{
				DetermineGuidance();
			}
			return weaponGuidanceType_0;
		}
		set
		{
			weaponGuidanceType_0 = value;
			switch (weaponGuidanceType_0)
			{
			case WeaponGuidanceType.SemiActive:
				IsFullyAutonomous = false;
				IsSemiAutonomous = false;
				GuidanceHasDataLink = false;
				GuidanceHasSemiActivePhase = true;
				break;
			case WeaponGuidanceType.Inertial_Plus_SemiActive:
				IsFullyAutonomous = false;
				IsSemiAutonomous = false;
				GuidanceHasDataLink = false;
				GuidanceHasSemiActivePhase = true;
				break;
			case WeaponGuidanceType.Datalink_Plus_SemiActive:
				IsFullyAutonomous = false;
				IsSemiAutonomous = false;
				GuidanceHasDataLink = true;
				GuidanceHasSemiActivePhase = true;
				break;
			case WeaponGuidanceType.Passive:
				IsFullyAutonomous = true;
				IsSemiAutonomous = false;
				GuidanceHasDataLink = false;
				GuidanceHasSemiActivePhase = false;
				break;
			case WeaponGuidanceType.Inertial_Plus_Passive:
				IsFullyAutonomous = true;
				IsSemiAutonomous = false;
				GuidanceHasDataLink = false;
				GuidanceHasSemiActivePhase = false;
				break;
			case WeaponGuidanceType.DataLink_Plus_Passive:
				IsFullyAutonomous = false;
				IsSemiAutonomous = true;
				GuidanceHasDataLink = true;
				GuidanceHasSemiActivePhase = false;
				break;
			case WeaponGuidanceType.Active:
				IsFullyAutonomous = true;
				IsSemiAutonomous = false;
				GuidanceHasDataLink = false;
				GuidanceHasSemiActivePhase = false;
				break;
			case WeaponGuidanceType.Datalink_Plus_Active:
				IsFullyAutonomous = false;
				IsSemiAutonomous = true;
				GuidanceHasDataLink = true;
				GuidanceHasSemiActivePhase = false;
				break;
			case WeaponGuidanceType.Inertial_Plus_Active:
				IsFullyAutonomous = true;
				IsSemiAutonomous = false;
				GuidanceHasDataLink = false;
				GuidanceHasSemiActivePhase = false;
				break;
			case WeaponGuidanceType.CommandGuided_Datalinked:
				IsFullyAutonomous = false;
				IsSemiAutonomous = false;
				GuidanceHasSemiActivePhase = true;
				GuidanceHasDataLink = true;
				break;
			case WeaponGuidanceType.BeamRiding:
				IsFullyAutonomous = false;
				IsSemiAutonomous = false;
				GuidanceHasDataLink = false;
				GuidanceHasSemiActivePhase = true;
				break;
			case WeaponGuidanceType.Inertial:
				IsFullyAutonomous = true;
				IsSemiAutonomous = false;
				GuidanceHasDataLink = false;
				GuidanceHasSemiActivePhase = false;
				break;
			case WeaponGuidanceType.SemiActive_Plus_Active:
				IsFullyAutonomous = false;
				IsSemiAutonomous = true;
				GuidanceHasDataLink = false;
				GuidanceHasSemiActivePhase = true;
				break;
			case WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
				IsFullyAutonomous = false;
				IsSemiAutonomous = true;
				GuidanceHasDataLink = false;
				GuidanceHasSemiActivePhase = true;
				break;
			case WeaponGuidanceType.TVM:
				break;
			}
		}
	}

	public Sensor SensorProvidingFireControlForMe
	{
		get
		{
			return sensor_1;
		}
		set
		{
			sensor_1 = value;
		}
	}

	public bool IsRemoteControllable => CommStuff.CommLinksEstablished_ReadOnly.Length > 0;

	public int CEP_Surface
	{
		get
		{
			return int_5;
		}
		set
		{
			int_5 = value;
		}
	}

	public int CEP_Land
	{
		get
		{
			return int_6;
		}
		set
		{
			int_6 = value;
		}
	}

	public ActiveUnit FiringParent
	{
		get
		{
			return activeUnit_0;
		}
		set
		{
			activeUnit_0 = value;
			if (value == null)
			{
				_FiringParent_ID = null;
			}
			else
			{
				_FiringParent_ID = value.ObjectID;
			}
		}
	}

	public ActiveUnit DataLinkParent
	{
		get
		{
			ActiveUnit activeUnit = activeUnit_1;
			if (activeUnit != null && activeUnit.IsMorituri)
			{
				return null;
			}
			return activeUnit_1;
		}
		set
		{
			if (value != null)
			{
				activeUnit_1 = value;
			}
			else if (!PlayerIsPlottingCourse)
			{
				CommDevice[] comms_ReadOnly = Comms_ReadOnly;
				for (int i = 0; i < comms_ReadOnly.Length; i = checked(i + 1))
				{
					comms_ReadOnly[i].OccupiedChannels = 0;
				}
				DetermineGuidance();
				activeUnit_1 = null;
			}
		}
	}

	public float MaxRangeForThisTarget
	{
		get
		{
			float result;
			try
			{
				float num = 0f;
				if (!IsWeaponPallet)
				{
					if (ManualFire || theDoc == null || theShooter == null || Type != _WeaponType.Gun || !theTarget.isSurfaceOrLandContact || !theShooter.IsAircraft)
					{
						goto IL_00b2;
					}
					byte? b = (byte?)theDoc.get_GunStrafing(ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
					{
						goto IL_00b2;
					}
					result = 0f;
				}
				else
				{
					InitializeWeaponWeaponsPallet();
					foreach (WeaponRec weaponWeapon in WeaponWeapons)
					{
						float num2 = 0f;
						num2 = weaponWeapon.get_ReferenceWeapon(theShooter.ParentScen).get_MaxRangeForThisTarget(theShooter, theTarget, CheckWRA, theDoc, ManualFire);
						if (num2 > num)
						{
							num = num2;
						}
					}
					result = num;
				}
				goto end_IL_0001;
				IL_00b2:
				if (theTarget.ActualUnit == null)
				{
					result = (IsAAWCapable ? method_21(Contact_Base.ContactType.Air) : (IsShip ? method_21(Contact_Base.ContactType.Surface) : (IsFacility ? method_21(Contact_Base.ContactType.Facility_Fixed) : (IsSubmarine ? method_21(Contact_Base.ContactType.Submarine) : MaxRange_NoTargetType))));
				}
				else
				{
					ActiveUnit actualUnit = theTarget.ActualUnit;
					float num3 = ((actualUnit == null) ? method_21(theTarget.Type) : ((actualUnit.IsSubmarine && ((Submarine)actualUnit).IsSurfaced) ? ((method_21(Contact_Base.ContactType.Submarine) != 0f) ? method_21(Contact_Base.ContactType.Submarine) : method_21(Contact_Base.ContactType.Surface)) : ((actualUnit.IsFacility && ((Facility)actualUnit).Category == Facility._FacilityCategory.Water_Surface) ? Math.Max(method_21(Contact_Base.ContactType.Facility_Fixed), method_21(Contact_Base.ContactType.Surface)) : ((!actualUnit.IsAircraft || !((Aircraft)actualUnit).IsLighterThanAir) ? method_21(theTarget.Type) : Math.Max(method_21(Contact_Base.ContactType.Air), method_21(Contact_Base.ContactType.Surface))))));
					if (CheckWRA && num3 > 0f && theDoc != null)
					{
						Weapon theWeapon = this;
						if (theDoc.WRA_RelevantWeapon(ref theWeapon))
						{
							theWeapon = this;
							GlobalVariables.BooleanObject EmitterClassificable = null;
							Doctrine._WRA_WeaponTargetType theTargetType = Contact.WRA_DetermineTargetType(ref theTarget, this, ref EmitterClassificable);
							Doctrine._WRA_WeaponTargetType selectedNodeTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref theWeapon, ref theTarget, ref theTargetType, theShooter.get_UnitSide(SetSideOnly: false).ObjectID);
							Scenario parentScen = ParentScen;
							int? TargetType_InheritedWeaponQty = null;
							int? TargetType_UnspecifiedWeaponQty = null;
							if ((Doctrine.WRA_WeaponQty_AnyTargetType(theDoc, parentScen, this, selectedNodeTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedWeaponQty, ref TargetType_UnspecifiedWeaponQty) ?? 0) == 0)
							{
								num3 = 0f;
							}
							if (num3 > 0f)
							{
								Scenario parentScen2 = ParentScen;
								int dBID = DBID;
								float? TargetType_InheritedFiringRange = null;
								float? TargetType_UnspecifiedFiringRange = null;
								float? num4 = theDoc.WRA_FiringRange_AnyTargetType(theDoc, parentScen2, dBID, selectedNodeTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedFiringRange, ref TargetType_UnspecifiedFiringRange);
								bool hasValue = num4.HasValue;
								float num5 = num4 ?? (-1f);
								if (hasValue)
								{
									if (num5 == 0f)
									{
										num3 = 0f;
									}
									else
									{
										float num6 = num5;
										if (num6 == -95f)
										{
											num3 = (float)((double)num3 * 0.25);
										}
										else if (num6 == -96f)
										{
											num3 = (float)((double)num3 * 0.5);
										}
										else if (num6 == -97f)
										{
											num3 = (float)((double)num3 * 0.75);
										}
										if (num5 > 0f && num5 < num3)
										{
											num3 = num5;
										}
									}
								}
							}
						}
					}
					result = num3;
				}
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200582", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = 0f;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public float BlindTime
	{
		get
		{
			return _BlindTime;
		}
		set
		{
			_BlindTime = value;
			if (!(_BlindTime > 5f) || (!Information.IsNothing((object)DataLinkParent) && Guidance != WeaponGuidanceType.TVM))
			{
				return;
			}
			switch (Guidance)
			{
			case WeaponGuidanceType.SemiActive_Plus_Active:
			case WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
				GoAutonomous(clearPrimaryTarget: true, clearDatalink: true);
				return;
			case WeaponGuidanceType.Inertial_Plus_SemiActive:
				return;
			}
			if (IsAAWCapable)
			{
				if (IsNuke.Value && AI.PrimaryTarget != null)
				{
					if (Module_Unit.RangeToUnit_Slant(this, AI.PrimaryTarget) < LaunchPoint.RangeToPoint_Slant(new Geopoint_Struct(((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null))) / 2f)
					{
						AddMessage("Weapon: " + Name + " is running blind for more than " + Conversions.ToString((int)Math.Round(_BlindTime)) + " sec and is armed - detonating.", "Weapon detonating", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
						double theLat = this.get_Latitude((GlobalVariables.BooleanObject)null);
						double theLon = this.get_Longitude((GlobalVariables.BooleanObject)null);
						float theAlt = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
						LockRandom theRNG = GameGeneral.GlobalRNG;
						Detonate(theLat, theLon, theAlt, ref theRNG, Detonation_AddMessage: false);
					}
					else
					{
						AddMessage("Weapon: " + Name + " is running blind for more than " + Conversions.ToString((int)Math.Round(_BlindTime)) + " sec... self-destructing.", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
						ParentScen.DestroyThisUnit(this, "Weapon has been blinded");
					}
				}
				else
				{
					AddMessage("Weapon: " + Name + " is running blind for more than " + Conversions.ToString((int)Math.Round(_BlindTime)) + " sec... self-destructing.", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
					ParentScen.DestroyThisUnit(this, "Weapon has been blinded");
				}
			}
			else
			{
				AddMessage("Weapon: " + Name + " is running blind for more than " + Conversions.ToString((int)Math.Round(_BlindTime)) + " sec... missed target.", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
	}

	public float DatalinkRetargetTime
	{
		get
		{
			return _DatalinkRetargetTime;
		}
		set
		{
			_DatalinkRetargetTime = value;
		}
	}

	public override bool IsPlatform => false;

	public new Weapon_Navigator Navigator => _Navigator;

	public new virtual Weapon_AI AI => weapon_AI_0;

	public new virtual Weapon_Kinematics Kinematics
	{
		get
		{
			if (weapon_Kinematics_0 == null)
			{
				ActiveUnit theUnit = this;
				weapon_Kinematics_0 = new Weapon_Kinematics(ref theUnit);
			}
			return weapon_Kinematics_0;
		}
	}

	public new Weapon_Sensory Sensory
	{
		get
		{
			if (weapon_Sensory_0 == null)
			{
				ActiveUnit theUnit = this;
				weapon_Sensory_0 = new Weapon_Sensory(ref theUnit);
			}
			return weapon_Sensory_0;
		}
	}

	public new Weapon_CommStuff CommStuff
	{
		get
		{
			if (weapon_CommStuff_0 == null)
			{
				ActiveUnit theUnit = this;
				weapon_CommStuff_0 = new Weapon_CommStuff(ref theUnit);
			}
			return weapon_CommStuff_0;
		}
	}

	public new Weapon_Damage Damage
	{
		get
		{
			if (weapon_Damage_0 == null)
			{
				ActiveUnit theUnit = this;
				weapon_Damage_0 = new Weapon_Damage(ref theUnit);
			}
			return weapon_Damage_0;
		}
	}

	public override string AnnexAndDBID => "Weapon_" + Conversions.ToString(DBID);

	public sealed override double Longitude
	{
		get
		{
			return _Longitude;
		}
		set
		{
			_Longitude = value;
		}
	}

	public sealed override double Latitude
	{
		get
		{
			return _Latitude;
		}
		set
		{
			_Latitude = value;
		}
	}

	public bool IsASuW_Land
	{
		get
		{
			if (ValidTargets == null)
			{
				return false;
			}
			int result;
			if (ValidTargets.LandStructure_Hard)
			{
				result = 1;
			}
			else if (ValidTargets.LandStructure_Soft)
			{
				result = 1;
			}
			else
			{
				if (!ValidTargets.MobileTarget_Hard)
				{
					if (ValidTargets.MobileTarget_Soft)
					{
						result = 1;
						goto IL_0061;
					}
					if (!ValidTargets.Runway)
					{
						return ValidTargets.Radar;
					}
				}
				result = 1;
			}
			goto IL_0061;
			IL_0061:
			return (byte)result != 0;
		}
	}

	public bool IsASuW_Naval
	{
		get
		{
			if (ValidTargets != null)
			{
				if (ValidTargets.SurfaceVessel)
				{
					return true;
				}
				return ValidTargets.Radar;
			}
			return false;
		}
	}

	public bool IsASW
	{
		get
		{
			if (ValidTargets == null)
			{
				return false;
			}
			return ValidTargets.Submarine;
		}
	}

	public bool IsAntiradar => ValidTargets.Radar;

	public override bool IsBallisticMissile => Type switch
	{
		_WeaponType.HGV => false, 
		_WeaponType.RV => false, 
		_WeaponType.BallisticMissile => true, 
		_ => Flags.IsBallisticMissile, 
	};

	public bool IsAAWOriented
	{
		get
		{
			if (!IsAAWCapable)
			{
				return false;
			}
			if (Doctrine.WRA == null)
			{
				Weapon theWeapon = this;
				Doctrine doctrine;
				ConcurrentPagedArray<Doctrine.WRA_Weapon> theWRA = (doctrine = Doctrine).WRA;
				DBFunctions.PopulateWeaponWRA(ref theWeapon, ref theWRA);
				doctrine.WRA = theWRA;
			}
			Doctrine.WRA_Weapon wRA_Weapon = Doctrine.WRA.Values.ElementAtOrDefault(0);
			foreach (Doctrine.WRA_FiringDoctrineEntry value in wRA_Weapon.WRA_WeaponTargets.Values)
			{
				int? weaponQty = value.WeaponQty;
				if ((weaponQty.HasValue ? new bool?(weaponQty.GetValueOrDefault() > 0) : ((bool?)null)) == true)
				{
					Doctrine._WRA_WeaponTargetType targetType = value.TargetType;
					if (targetType == Doctrine._WRA_WeaponTargetType.Air_Contact_Unknown_Type)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	public bool IsAAWCapable
	{
		get
		{
			if (!IsDecoy)
			{
				if (ValidTargets != null)
				{
					return ValidTargets.Missile || ValidTargets.Aircraft;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsAAW_GuidedMissile
	{
		get
		{
			if (Type != _WeaponType.GuidedWeapon)
			{
				return false;
			}
			return ValidTargets != null && (ValidTargets.Missile || ValidTargets.Aircraft);
		}
	}

	public bool IsAAW_GuidedMissile_ARH
	{
		get
		{
			if (!IsAAW_GuidedMissile)
			{
				return false;
			}
			bool flag = default(bool);
			foreach (Sensor sensor in _Sensors)
			{
				if (sensor.Type == Sensor.Sensor_Type.Radar)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				return true;
			}
			return false;
		}
	}

	public bool CanBeDestroyedByNuke
	{
		get
		{
			_WeaponType type = Type;
			int result;
			if (type <= _WeaponType.Decoy_Vehicle)
			{
				if (type == _WeaponType.GuidedWeapon)
				{
					goto IL_0065;
				}
				if (type == _WeaponType.Decoy_Vehicle)
				{
					goto IL_0071;
				}
				result = 0;
			}
			else
			{
				switch (type)
				{
				case _WeaponType.Torpedo:
					goto IL_0065;
				case _WeaponType.DepthCharge:
				case _WeaponType.AttachedMine:
					goto IL_0069;
				case _WeaponType.BottomMine:
				case _WeaponType.MooredMine:
				case _WeaponType.FloatingMine:
				case _WeaponType.MovingMine:
				case _WeaponType.RisingMine:
				case _WeaponType.DriftingMine:
				case _WeaponType.DummyMine:
					return true;
				case _WeaponType.UAV_Expendable:
				case _WeaponType.Sonobuoy:
					goto IL_0071;
				}
				result = 0;
			}
			goto IL_006a;
			IL_0065:
			return true;
			IL_0069:
			result = 0;
			goto IL_006a;
			IL_006a:
			return (byte)result != 0;
			IL_0071:
			return true;
		}
	}

	public bool IsASAT => ValidTargets.Satellite;

	public bool IsMaRV
	{
		get
		{
			int result;
			if (IsReEntryVehicle)
			{
				if (HasTerminalGuidance)
				{
					return true;
				}
				if (Flags.AttitudeControl != WeaponFlags.AttitudeControlEnum.None)
				{
					return true;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public bool Is_LOAL_capable
	{
		get
		{
			WeaponGuidanceType guidance = Guidance;
			int result;
			if ((uint)(guidance - 2) <= 1u)
			{
				result = 1;
			}
			else
			{
				if ((uint)(guidance - 5) > 4u)
				{
					return false;
				}
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	public int OptimumBurstHeight_AGL
	{
		get
		{
			if (Warheads.Length != 0)
			{
				if (!Warheads[0].get_IsAirburst(this, theTarget))
				{
					return 0;
				}
				if (theTarget == null)
				{
					return 0;
				}
				if (IsNuke.Value)
				{
					if (theTarget.IsSubmarine)
					{
						if (((Submarine)theTarget).IsSurfaced)
						{
							return 220;
						}
						return -100;
					}
					if (theTarget.IsAircraft || theTarget.IsMissile || theTarget.IsSatellite)
					{
						return (int)Math.Round(theTarget.CurrentAltitude_AGL);
					}
				}
				if (!Warheads[0].get_IsAirburst(this, theTarget))
				{
					return 0;
				}
				Warhead.WarheadType type = Warheads[0].Type;
				int result;
				if (type <= Warhead.WarheadType.Nuclear)
				{
					switch (type)
					{
					default:
						result = 0;
						break;
					case Warhead.WarheadType.Nuclear:
						return (int)Math.Round(Math.Pow(Warheads[0].DP / 1000000f, 1.0 / 3.0) * 220.0);
					case Warhead.WarheadType.SemiAP:
					case Warhead.WarheadType.HESH:
					case Warhead.WarheadType.HardTargetPenetrator:
						result = 0;
						break;
					case Warhead.WarheadType.FAE:
						return 1;
					case Warhead.WarheadType.Fragmentation:
					case Warhead.WarheadType.ContinuousRod:
					case Warhead.WarheadType.SuperFrag:
					case Warhead.WarheadType.Fragmentation_ABM:
						return (int)Math.Round((double)(Explosion.GetCutoffRange_Frag_nm(Warheads[0].DP, DetonationMedium.Air, Warheads[0].Type) * 1852f) * 0.5);
					case Warhead.WarheadType.HE_BlastFrag:
						return (int)Math.Round((double)(Explosion.GetCutoffRange_Blast_nm(Warheads[0].DP, DetonationMedium.Air) * 1852f) * 0.5);
					}
				}
				else
				{
					if ((uint)(type - 6001) <= 2u || type == Warhead.WarheadType.Cluster_SmartSubs)
					{
						return 800;
					}
					if (type == Warhead.WarheadType.EMP_Omni)
					{
						return (int)Math.Round(3055.8);
					}
					result = 0;
				}
				return result;
			}
			return 0;
		}
	}

	public DetonationMedium DetonationTransmissionMedium
	{
		get
		{
			if (CurrentAltitude_AGL < 0f && theTarget.CurrentAltitude_AGL < 0f && Module_Unit.IsOverLand(this) && Module_Unit.IsOverLand(theTarget))
			{
				return DetonationMedium.Underground;
			}
			if (this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 0f && !Module_Unit.IsOverLand(this) && theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 0f && !Module_Unit.IsOverLand(theTarget))
			{
				return DetonationMedium.Underwater;
			}
			int result;
			if (!(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 100000f))
			{
				if (!(theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 100000f))
				{
					return DetonationMedium.Air;
				}
				result = 4;
			}
			else
			{
				result = 4;
			}
			return (DetonationMedium)result;
		}
	}

	public bool isLoiterCapable
	{
		get
		{
			if (!Flags.LoiterCapability)
			{
				return Flags.ParachuteLoiter;
			}
			return true;
		}
	}

	public bool CanParachuteLoiter
	{
		get
		{
			if (Flags.ParachuteLoiter && TimeSinceBurnout == 0f)
			{
				return (ThrottleSetting != Throttle.FullStop) | IsWeaponPallet;
			}
			return false;
		}
	}

	public bool IsParachuteLoitering
	{
		get
		{
			if (Flags.ParachuteLoiter && ThrottleSetting == Throttle.FullStop)
			{
				return CurrentAltitude_AGL > 0f;
			}
			return false;
		}
	}

	public override GlobalVariables.TargetVisualSizeClass VisualSizeClass
	{
		get
		{
			float length = Length;
			if (length > 10f)
			{
				return GlobalVariables.TargetVisualSizeClass.VLarge;
			}
			if (length > 5f)
			{
				return GlobalVariables.TargetVisualSizeClass.Large;
			}
			if (length > 3.5f)
			{
				return GlobalVariables.TargetVisualSizeClass.Medium;
			}
			if (length > 2.5f)
			{
				return GlobalVariables.TargetVisualSizeClass.Small;
			}
			if (length > 1.5f)
			{
				return GlobalVariables.TargetVisualSizeClass.VSmall;
			}
			return GlobalVariables.TargetVisualSizeClass.Stealthy;
		}
	}

	public bool IsLaserShot
	{
		get
		{
			if (Warheads.Length > 0)
			{
				Warhead.WarheadType type = Warheads[0].Type;
				if ((uint)(type - 9101) > 3u)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}

	public bool IsSonarCountermeasure
	{
		get
		{
			int result;
			if (!IsDecoy)
			{
				result = 0;
			}
			else
			{
				if (!base.IsMobileDecoy)
				{
					XSection[] xSections_ReadOnly = base.XSections_ReadOnly;
					int num = 0;
					int result2;
					while (true)
					{
						if (num < xSections_ReadOnly.Length)
						{
							XSection xSection = xSections_ReadOnly[num];
							if (xSection.SignatureType == XSection._SignatureType.ActiveSonar || xSection.SignatureType == XSection._SignatureType.HullSonar_PassiveOnly_VLF)
							{
								if (xSection.get_Front((ActiveUnit)this) > -10000f || xSection.get_Side((ActiveUnit)this) > -10000f)
								{
									result2 = 1;
									break;
								}
								if (!(xSection.get_Rear((ActiveUnit)this) <= -10000f))
								{
									result2 = 1;
									break;
								}
							}
							num = checked(num + 1);
							continue;
						}
						return false;
					}
					return (byte)result2 != 0;
				}
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public bool IsRadarCountermeasure
	{
		get
		{
			if (!nullable_21.HasValue)
			{
				nullable_21 = false;
				if (IsDecoy && !base.IsMobileDecoy)
				{
					XSection[] xSections_ReadOnly = base.XSections_ReadOnly;
					foreach (XSection xSection in xSections_ReadOnly)
					{
						if ((xSection.SignatureType == XSection._SignatureType.Radar_A_D || xSection.SignatureType == XSection._SignatureType.Radar_E_M) && (xSection.get_Front((ActiveUnit)this) > -10000f || xSection.get_Side((ActiveUnit)this) > -10000f || !(xSection.get_Rear((ActiveUnit)this) <= -10000f)))
						{
							nullable_21 = true;
							break;
						}
					}
				}
				else
				{
					nullable_21 = false;
				}
			}
			return nullable_21.Value;
		}
	}

	public bool IsIRCountermeasure
	{
		get
		{
			if (IsDecoy && !base.IsMobileDecoy)
			{
				XSection[] xSections_ReadOnly = base.XSections_ReadOnly;
				int num = 0;
				int result;
				while (true)
				{
					if (num < xSections_ReadOnly.Length)
					{
						XSection xSection = xSections_ReadOnly[num];
						XSection._SignatureType signatureType = xSection.SignatureType;
						if ((uint)(signatureType - 4001) <= 1u)
						{
							if (xSection.get_Front((ActiveUnit)this) > -10000f || xSection.get_Side((ActiveUnit)this) > -10000f)
							{
								result = 1;
								break;
							}
							if (!(xSection.get_Rear((ActiveUnit)this) <= -10000f))
							{
								result = 1;
								break;
							}
						}
						num = checked(num + 1);
						continue;
					}
					return false;
				}
				return (byte)result != 0;
			}
			return false;
		}
	}

	public bool IsSmokeGrenade
	{
		get
		{
			int result;
			if (!IsDecoy)
			{
				result = 0;
			}
			else
			{
				if (!base.IsMobileDecoy)
				{
					XSection[] xSections_ReadOnly = base.XSections_ReadOnly;
					int num = 0;
					int result2;
					while (true)
					{
						if (num < xSections_ReadOnly.Length)
						{
							XSection xSection = xSections_ReadOnly[num];
							XSection._SignatureType signatureType = xSection.SignatureType;
							if ((uint)(signatureType - 3001) <= 1u)
							{
								if (xSection.get_Front((ActiveUnit)this) > 0f || xSection.get_Side((ActiveUnit)this) > 0f)
								{
									result2 = 1;
									break;
								}
								if (!(xSection.get_Rear((ActiveUnit)this) <= 0f))
								{
									result2 = 1;
									break;
								}
							}
							num = checked(num + 1);
							continue;
						}
						return false;
					}
					return (byte)result2 != 0;
				}
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public bool IsVisualCountermeasure
	{
		get
		{
			if (IsDecoy && !base.IsMobileDecoy)
			{
				XSection[] xSections_ReadOnly = base.XSections_ReadOnly;
				int num = 0;
				int result;
				while (true)
				{
					if (num < xSections_ReadOnly.Length)
					{
						XSection xSection = xSections_ReadOnly[num];
						XSection._SignatureType signatureType = xSection.SignatureType;
						if ((uint)(signatureType - 3001) <= 1u)
						{
							if (xSection.get_Front((ActiveUnit)this) > -10000f || xSection.get_Side((ActiveUnit)this) > -10000f)
							{
								result = 1;
								break;
							}
							if (!(xSection.get_Rear((ActiveUnit)this) <= -10000f))
							{
								result = 1;
								break;
							}
						}
						num = checked(num + 1);
						continue;
					}
					return false;
				}
				return (byte)result != 0;
			}
			return false;
		}
	}

	public bool IsChaff_CM_SG
	{
		get
		{
			int result;
			if (!IsRadarCountermeasure)
			{
				if (IsSonarCountermeasure)
				{
					result = 1;
				}
				else if (IsVisualCountermeasure)
				{
					result = 1;
				}
				else
				{
					if (!IsSmokeGrenade)
					{
						return IsChaffBundle;
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
	}

	public bool IsSensorPod => Type == _WeaponType.SensorPod;

	public bool IsSensorPodWithFuelTank
	{
		get
		{
			if (Type == _WeaponType.SensorPod)
			{
				return FuelCapacityMax > 0;
			}
			return false;
		}
	}

	public override float CurrentAltitude_AGL => this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - (float)Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ParentScen);

	public bool HasGoneAutonomous
	{
		get
		{
			if (IsFullyAutonomous)
			{
				return !Navigator.HasPlottedCourse();
			}
			if (!IsSemiAutonomous)
			{
				return false;
			}
			return DataLinkParent == null;
		}
	}

	public bool HasTorpedoPayload
	{
		get
		{
			bool result;
			try
			{
				Warhead[] warheads = Warheads;
				int num = 0;
				while (true)
				{
					if (num < warheads.Length)
					{
						Warhead warhead = warheads[num];
						if (!warhead.IsTorpedo)
						{
							if (warhead.Type != Warhead.WarheadType.Weapon || !warhead.get_CarriedWeapon(ParentScen).IsTorpedo)
							{
								num = checked(num + 1);
								continue;
							}
							result = true;
							break;
						}
						result = true;
						break;
					}
					result = false;
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100929", "");
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
				result = (byte)num2 != 0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool IsDualModeARM
	{
		get
		{
			bool result;
			try
			{
				if (ValidTargets.Radar)
				{
					if (_Sensors.Count >= 2)
					{
						foreach (Sensor sensor in _Sensors)
						{
							if (sensor.Type == Sensor.Sensor_Type.ESM)
							{
								continue;
							}
							result = true;
							goto end_IL_0001;
						}
						result = false;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					result = false;
				}
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100956", "");
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
				result = (byte)num != 0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public string WeaponGuidanceTypeString
	{
		get
		{
			string text = "";
			string text2 = "";
			bool flag = default(bool);
			if (Flags.Navigation_INS)
			{
				text = "Inertial (INS)";
				flag = true;
			}
			else if (!Flags.Navigation_INS_GPS)
			{
				if (Flags.Navigation_TERCOM)
				{
					text = "Terrain Comparison (TERCOM)";
					flag = true;
				}
				else if (!Flags.RearAspect_AAM)
				{
					if (Flags.SternChase_AAM)
					{
						text = "Stern-Chase";
						flag = true;
					}
					else if (Flags.AllAspect_AAM)
					{
						text = "All-Aspect";
						flag = true;
					}
					else if (!Flags.HOB_AAM)
					{
						if (!Flags.Torpedo_PatternRunning)
						{
							if (!Flags.Torpedo_StraightRunningTimeDetonation)
							{
								if (Flags.Torpedo_StraightRunning)
								{
									text = "Straight-Running";
									flag = true;
								}
								else if (Flags.Torpedo_WakeHoming)
								{
									text = "Wake-Homing (WH)";
									flag = true;
								}
							}
							else
							{
								text = "Straight-Running Time Detonation";
								flag = true;
							}
						}
						else
						{
							text = "Pattern-Running";
							flag = true;
						}
					}
					else
					{
						text = "All-Aspect, High Off-Boresight";
						flag = true;
					}
				}
				else
				{
					text = "Rear-Aspect";
					flag = true;
				}
			}
			else
			{
				text = "GPS-Updated Inertial (INS)";
				flag = true;
			}
			switch (Guidance)
			{
			case WeaponGuidanceType.SemiActive:
				text = "Semi-Active";
				if (Directors.Count <= 0)
				{
					break;
				}
				foreach (int director in Directors)
				{
					SQLiteConnection sqliteConnection_ = ParentScen.DBConnection;
					Sensor sensor = DBFunctions.GetSensor(director, ref sqliteConnection_);
					if (sensor.Type != Sensor.Sensor_Type.Radar)
					{
						if (sensor.Type == Sensor.Sensor_Type.LaserDesignator)
						{
							text += " Laser Homing (SALH)";
							break;
						}
						continue;
					}
					text += " Radar Homing (SARH)";
					break;
				}
				break;
			case WeaponGuidanceType.Inertial_Plus_SemiActive:
				text = "Inertial (INS) mid-course plus Semi-Active";
				if (Directors.Count > 0)
				{
					foreach (int director2 in Directors)
					{
						SQLiteConnection sqliteConnection_ = ParentScen.DBConnection;
						Sensor sensor3 = DBFunctions.GetSensor(director2, ref sqliteConnection_);
						if (sensor3.Type != Sensor.Sensor_Type.Radar)
						{
							if (sensor3.Type == Sensor.Sensor_Type.LaserDesignator)
							{
								text += " Laser Homing (SALH)";
								break;
							}
							continue;
						}
						text += " Radar Homing (SARH)";
						break;
					}
				}
				text += " terminal guidance";
				break;
			case WeaponGuidanceType.Datalink_Plus_SemiActive:
				text = "Datalink (DL/INS) mid-course plus Semi-Active";
				if (Directors.Count > 0)
				{
					foreach (int director3 in Directors)
					{
						SQLiteConnection sqliteConnection_ = ParentScen.DBConnection;
						Sensor sensor2 = DBFunctions.GetSensor(director3, ref sqliteConnection_);
						if (sensor2.Type != Sensor.Sensor_Type.Radar)
						{
							if (sensor2.Type == Sensor.Sensor_Type.LaserDesignator)
							{
								text += " Laser Homing (SALH)";
								break;
							}
							continue;
						}
						text += " Radar Homing (SARH)";
						break;
					}
				}
				if (_Sensors.Count > 0)
				{
					foreach (Sensor sensor4 in _Sensors)
					{
						if (sensor4.Type == Sensor.Sensor_Type.Infrared)
						{
							text2 = " with Infrared (IR) backup seeker";
						}
						else if (sensor4.Type == Sensor.Sensor_Type.Visual)
						{
							text2 = " with Electro-Optical (EO) backup seeker";
						}
					}
				}
				text = text + " terminal guidance" + text2;
				break;
			case WeaponGuidanceType.Passive:
				if (flag)
				{
					text += " mid-course plus ";
				}
				text += "Passive";
				if (_Sensors.Count > 0)
				{
					foreach (Sensor sensor5 in _Sensors)
					{
						if (sensor5.Type != Sensor.Sensor_Type.Infrared)
						{
							if (sensor5.Type != Sensor.Sensor_Type.Visual)
							{
								if (sensor5.Type == Sensor.Sensor_Type.ESM)
								{
									text += " Radar Homing";
									break;
								}
								continue;
							}
							text += " Electro-Optical (EO)";
							break;
						}
						text += " Infrared (IR)";
						break;
					}
				}
				if (flag)
				{
					text += " terminal guidance";
				}
				break;
			case WeaponGuidanceType.Inertial_Plus_Passive:
				text = "Inertial (INS) mid-course plus Passive";
				if (_Sensors.Count > 0)
				{
					foreach (Sensor sensor6 in _Sensors)
					{
						if (sensor6.Type != Sensor.Sensor_Type.Infrared)
						{
							if (sensor6.Type != Sensor.Sensor_Type.Visual)
							{
								if (sensor6.Type == Sensor.Sensor_Type.ESM)
								{
									text += " Radar Homing (ARM)";
									break;
								}
								continue;
							}
							text += " Electro-Optical (EO)";
							break;
						}
						text += " Infrared (IR)";
						break;
					}
				}
				text += " terminal guidance";
				break;
			case WeaponGuidanceType.DataLink_Plus_Passive:
				if (flag)
				{
					text += " and ";
				}
				if (Type == _WeaponType.GuidedWeapon)
				{
					text += "Datalink (DL/INS) mid-course plus Passive";
				}
				else if (Type == _WeaponType.Torpedo)
				{
					text += "Wire-Guidance mid-course plus Passive";
				}
				if (_Sensors.Count > 0)
				{
					foreach (Sensor sensor7 in _Sensors)
					{
						if (sensor7.Type == Sensor.Sensor_Type.Radar)
						{
							text += " Radar Homing (ARH)";
							break;
						}
					}
				}
				text += " terminal guidance";
				break;
			case WeaponGuidanceType.Active:
				if (flag)
				{
					text += " mid-course plus ";
				}
				text += "Active";
				if (_Sensors.Count > 0)
				{
					foreach (Sensor sensor8 in _Sensors)
					{
						if (sensor8.Type == Sensor.Sensor_Type.Radar)
						{
							text += " Radar Homing (ARH)";
							break;
						}
					}
				}
				if (flag)
				{
					text += " terminal guidance";
				}
				break;
			case WeaponGuidanceType.Datalink_Plus_Active:
				if (flag)
				{
					text += " and ";
				}
				if (Type == _WeaponType.GuidedWeapon)
				{
					text += "Datalink (DL/INS) mid-course plus Active";
				}
				else if (Type == _WeaponType.Torpedo)
				{
					text += "Wire-Guidance mid-course plus Active";
				}
				if (_Sensors.Count > 0)
				{
					foreach (Sensor sensor9 in _Sensors)
					{
						if (sensor9.Type == Sensor.Sensor_Type.Radar)
						{
							text += " Radar Homing (ARH)";
						}
						else if (sensor9.Type == Sensor.Sensor_Type.Infrared)
						{
							text2 = " with Infrared (IR) backup seeker";
						}
						else if (sensor9.Type == Sensor.Sensor_Type.Visual)
						{
							text2 = " with Electro-Optical (EO) backup seeker";
						}
					}
				}
				text = text + " terminal guidance" + text2;
				break;
			case WeaponGuidanceType.Inertial_Plus_Active:
				text = "Inertial (INS) mid-course plus Active";
				if (_Sensors.Count > 0)
				{
					foreach (Sensor sensor10 in _Sensors)
					{
						if (sensor10.Type == Sensor.Sensor_Type.Radar)
						{
							text += " Radar Homing (ARH)";
						}
						else if (sensor10.Type == Sensor.Sensor_Type.Infrared)
						{
							text2 = " with Infrared (IR) backup seeker";
						}
						else if (sensor10.Type == Sensor.Sensor_Type.Visual)
						{
							text2 = " with Electro-Optical (EO) backup seeker";
						}
						else if (sensor10.Type == Sensor.Sensor_Type.ESM && ValidTargets.Radar)
						{
							text2 = " with anti-radar (ARM) backup seeker";
						}
					}
				}
				text = text + " terminal guidance" + text2;
				break;
			case WeaponGuidanceType.CommandGuided_Datalinked:
				text = "Command-Guided";
				break;
			case WeaponGuidanceType.TVM:
				text = "Track Via Missile (TVM)";
				break;
			case WeaponGuidanceType.BeamRiding:
				text = "Beam Riding";
				break;
			case WeaponGuidanceType.Inertial:
				text = "Inertially Guided";
				break;
			case WeaponGuidanceType.SemiActive_Plus_Active:
				text = "Semi-Active (SARH) mid-course Plus Active";
				if (_Sensors.Count > 0)
				{
					foreach (Sensor sensor11 in _Sensors)
					{
						if (sensor11.Type == Sensor.Sensor_Type.Radar)
						{
							text += " Radar Homing (ARH)";
							break;
						}
					}
				}
				text += " terminal guidance";
				break;
			case WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
				text = "Time-Shared Semi-Active (TSARH) mid-course Plus Active";
				if (_Sensors.Count > 0)
				{
					foreach (Sensor sensor12 in _Sensors)
					{
						if (sensor12.Type == Sensor.Sensor_Type.Radar)
						{
							text += " Radar Homing (ARH)";
							break;
						}
					}
				}
				text += " terminal guidance";
				break;
			}
			return text;
		}
	}

	public bool HasTerminalGuidance
	{
		get
		{
			WeaponGuidanceType guidance = Guidance;
			if (guidance == WeaponGuidanceType.Inertial)
			{
				return false;
			}
			return true;
		}
	}

	public float? MinimumSafeHeight
	{
		get
		{
			float? result;
			try
			{
				int num = ((Module_Unit.Unit)this).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentScen);
				bool num2 = num > 0;
				float num3 = ((!num2) ? 9.144f : 18.288f);
				if (IsHGV)
				{
					num3 = 1000f;
				}
				if (num2 && !bool_5)
				{
					return (float)num + num3;
				}
				return num3;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100891", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = 0f;
				ProjectData.ClearProjectError();
			}
			return result;
		}
		set
		{
		}
	}

	public static event WeaponImpactEventHandler WeaponImpact
	{
		[CompilerGenerated]
		add
		{
			WeaponImpactEventHandler weaponImpactEventHandler = weaponImpactEventHandler_0;
			WeaponImpactEventHandler weaponImpactEventHandler2;
			do
			{
				weaponImpactEventHandler2 = weaponImpactEventHandler;
				WeaponImpactEventHandler value2 = (WeaponImpactEventHandler)Delegate.Combine(weaponImpactEventHandler2, value);
				weaponImpactEventHandler = Interlocked.CompareExchange(ref weaponImpactEventHandler_0, value2, weaponImpactEventHandler2);
			}
			while ((object)weaponImpactEventHandler != weaponImpactEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WeaponImpactEventHandler weaponImpactEventHandler = weaponImpactEventHandler_0;
			WeaponImpactEventHandler weaponImpactEventHandler2;
			do
			{
				weaponImpactEventHandler2 = weaponImpactEventHandler;
				WeaponImpactEventHandler value2 = (WeaponImpactEventHandler)Delegate.Remove(weaponImpactEventHandler2, value);
				weaponImpactEventHandler = Interlocked.CompareExchange(ref weaponImpactEventHandler_0, value2, weaponImpactEventHandler2);
			}
			while ((object)weaponImpactEventHandler != weaponImpactEventHandler2);
		}
	}

	static Weapon()
	{
		Class72.smethod_20();
		StandOffMaxRange = 6f;
	}

	public override float GetSpeedForETACalculation(float travelDistance_nm)
	{
		if (MaxPossibleThrottleSetting > Throttle.Cruise)
		{
			float altitude = Kinematics.GetMaximumAltitude();
			if (CruiseAltitude_ASL != 0f)
			{
				altitude = CruiseAltitude_ASL;
			}
			else if (CruiseAltitude_AGL != 0f)
			{
				altitude = CruiseAltitude_AGL;
			}
			return Kinematics.GetMaximumSpeed(altitude, Throttle.Cruise, ValidateAndFixAltitude: false, ConsiderDamage: false);
		}
		return base.MaxSpeed;
	}

	internal bool method_16()
	{
		int result;
		if (Warheads.Count() <= 0)
		{
			result = 0;
		}
		else
		{
			Weapon weapon = Warheads[0].get_CarriedWeapon(ParentScen);
			if (weapon == null)
			{
				result = 0;
			}
			else
			{
				if (weapon.IsHGV)
				{
					return true;
				}
				result = 0;
			}
		}
		return (byte)result != 0;
	}

	public bool IsBallisticTargetManeuvering()
	{
		if (this is BallisticMissile)
		{
			return ((BallisticMissile)this).IsPerformingTerminalManeuvers;
		}
		if (Module_Unit.IsWithinAtmosphere(this))
		{
			int result;
			if (_Sensors.Count <= 0)
			{
				if (!IsHGV)
				{
					goto IL_0039;
				}
				result = 1;
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
		goto IL_0039;
		IL_0039:
		bool result2 = default(bool);
		return result2;
	}

	internal float BodyDragCoefficient(float theAltitude, float theSpeed)
	{
		if (IsAAW_GuidedMissile)
		{
			return DragCoefficient_AAWmissile(this, theAltitude, theSpeed, Length, Diameter);
		}
		if (!IsReEntryVehicle)
		{
		}
		return 0.35f;
	}

	internal static float DragCoefficient_AAWmissile(Weapon theWeapon, float theAltitude_m, float theSpeed_kts, float theLength, float theDiameter)
	{
		float num = Physics.ComputeMach(theAltitude_m, theSpeed_kts);
		double num2 = ((!(num > 1f)) ? (0.12 + 0.13 * Math.Pow(num, 2.0)) : (0.25 / (double)num));
		double num3 = 0.0;
		if (num > 1f)
		{
			ObservableList<Sensor> observableList = theWeapon.WeaponSensors();
			float num4;
			if (observableList.Count > 0)
			{
				switch (observableList[0].Type)
				{
				case Sensor.Sensor_Type.Visual:
				case Sensor.Sensor_Type.Infrared:
				case Sensor.Sensor_Type.LaserSpotTracker:
					num4 = 0.9f;
					break;
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					num4 = 2.5f;
					break;
				case Sensor.Sensor_Type.Radar:
				case Sensor.Sensor_Type.SemiActive:
				case Sensor.Sensor_Type.Terminal_SemiActive:
					num4 = 2.5f;
					break;
				}
			}
			else
			{
				num4 = 5f;
			}
			num3 = (1.59 + 1.83 / Math.Pow(num, 2.0)) * Math.Pow(Math.Atan(0.5 / (double)num4), 1.69);
		}
		double num5 = theLength / theDiameter;
		double num6 = theLength * 3.28084f;
		double num7 = Physics.ConvertPascalsToPsf(Physics.CalculateDynamicPressure((int)Math.Round(theAltitude_m), (double)theSpeed_kts * 0.514444));
		double num8 = 0.053 * num5 * Math.Pow((double)num / (num7 * num6), 0.2);
		double num9 = ((theWeapon.Flags.AttitudeControl == WeaponFlags.AttitudeControlEnum.NonAerodynamic) ? 0.0 : ((!(num > 1f)) ? ((num2 + num3 + num8) * 0.1) : ((num2 + num3 + num8) * 0.3)));
		return (float)(num2 + num3 + num8 + num9);
	}

	internal int BurnoutWeight()
	{
		if (_BurnoutWeight_DB > 0)
		{
			return _BurnoutWeight_DB;
		}
		return DBFunctions.EstimateWeaponBurnoutWeight(this);
	}

	public bool IsASCMwithoutTFcapability()
	{
		if (ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.ASCMTerrainFollowingRestriction))
		{
			int result;
			if (Type == _WeaponType.GuidedWeapon)
			{
				if (!IsASuW_Naval)
				{
					result = 0;
				}
				else
				{
					if (!IsASuW_Land)
					{
						int result2;
						if (Sensors_Cached.Count() <= 0)
						{
							result2 = 0;
						}
						else
						{
							if (Sensors_Cached[0].TechGeneration < GlobalVariables.TechGenerationClass.const_12)
							{
								return true;
							}
							result2 = 0;
						}
						return (byte)result2 != 0;
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
		return false;
	}

	public bool method_17()
	{
		if (Guidance != WeaponGuidanceType.Inertial)
		{
			return false;
		}
		if (((ActiveUnit)this).get_UnitSide(SetSideOnly: false) == null)
		{
			return false;
		}
		if (!Flags.Navigation_GPS && !Flags.Navigation_GLONASS && !Flags.Navigation_Beidou && !Flags.Navigation_NavIC)
		{
			return false;
		}
		bool flag = default(bool);
		if (Flags.Navigation_GPS)
		{
			flag = true;
			if (((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Enablers.GNSS_GPS)
			{
				flag = true;
				bool flag2 = false;
				bool flag3 = false;
				foreach (Zone standardZone in ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).StandardZones)
				{
					if (GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), standardZone.Area_AsArray))
					{
						if (!standardZone.Enablers.GNSS_GPS)
						{
							flag3 = true;
						}
						else
						{
							flag2 = true;
						}
					}
				}
				if (!flag2)
				{
					if (flag3)
					{
						flag = false;
					}
				}
				else
				{
					flag = true;
				}
			}
			else
			{
				flag = false;
				foreach (Zone standardZone2 in ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).StandardZones)
				{
					if (standardZone2.Enablers.GNSS_GPS && GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), standardZone2.Area_AsArray))
					{
						flag = true;
						break;
					}
				}
			}
			if (flag && method_18(GNSS.GNSSSystem.GPS_L1_CA))
			{
				flag = false;
			}
		}
		bool flag4 = default(bool);
		if (Flags.Navigation_GLONASS)
		{
			flag4 = true;
			if (!((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Enablers.GNSS_GLONASS)
			{
				flag4 = false;
				foreach (Zone standardZone3 in ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).StandardZones)
				{
					if (standardZone3.Enablers.GNSS_GLONASS && GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), standardZone3.Area_AsArray))
					{
						flag4 = true;
						break;
					}
				}
			}
			else
			{
				flag4 = true;
				bool flag5 = false;
				bool flag6 = false;
				foreach (Zone standardZone4 in ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).StandardZones)
				{
					if (GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), standardZone4.Area_AsArray))
					{
						if (!standardZone4.Enablers.GNSS_GLONASS)
						{
							flag6 = true;
						}
						else
						{
							flag5 = true;
						}
					}
				}
				if (!flag5)
				{
					if (flag6)
					{
						flag4 = false;
					}
				}
				else
				{
					flag4 = true;
				}
			}
			if (flag4 && method_18(GNSS.GNSSSystem.GLONASS_L1))
			{
				flag4 = false;
			}
		}
		bool flag7 = default(bool);
		if (Flags.Navigation_Beidou)
		{
			flag7 = true;
			if (!((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Enablers.GNSS_BeiDou)
			{
				flag7 = false;
				foreach (Zone standardZone5 in ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).StandardZones)
				{
					if (standardZone5.Enablers.GNSS_BeiDou && GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), standardZone5.Area_AsArray))
					{
						flag7 = true;
						break;
					}
				}
			}
			else
			{
				flag7 = true;
				bool flag8 = false;
				bool flag9 = false;
				foreach (Zone standardZone6 in ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).StandardZones)
				{
					if (GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), standardZone6.Area_AsArray))
					{
						if (!standardZone6.Enablers.GNSS_BeiDou)
						{
							flag9 = true;
						}
						else
						{
							flag8 = true;
						}
					}
				}
				if (flag8)
				{
					flag7 = true;
				}
				else if (flag9)
				{
					flag7 = false;
				}
			}
			if (flag7 && method_18(GNSS.GNSSSystem.BEIDOU_B1I))
			{
				flag7 = false;
			}
		}
		bool flag10 = default(bool);
		if (Flags.Navigation_NavIC)
		{
			flag10 = true;
			if (!((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Enablers.GNSS_NavIC)
			{
				flag10 = false;
				foreach (Zone standardZone7 in ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).StandardZones)
				{
					if (standardZone7.Enablers.GNSS_NavIC && GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), standardZone7.Area_AsArray))
					{
						flag10 = true;
						break;
					}
				}
			}
			else
			{
				flag10 = true;
				bool flag11 = false;
				bool flag12 = false;
				foreach (Zone standardZone8 in ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).StandardZones)
				{
					if (GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), standardZone8.Area_AsArray))
					{
						if (standardZone8.Enablers.GNSS_NavIC)
						{
							flag11 = true;
						}
						else
						{
							flag12 = true;
						}
					}
				}
				if (flag11)
				{
					flag10 = true;
				}
				else if (flag12)
				{
					flag10 = false;
				}
			}
			if (flag10 && method_18(GNSS.GNSSSystem.NAVIC_L5))
			{
				flag10 = false;
			}
		}
		int result;
		if (flag)
		{
			result = 0;
		}
		else if (flag4)
		{
			result = 0;
		}
		else if (flag7)
		{
			result = 0;
		}
		else
		{
			if (!flag10)
			{
				return true;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	private bool method_18(GNSS.GNSSSystem gnsssystem_0)
	{
		PooledList<double> pooledList = null;
		PooledList<double> pooledList2 = null;
		bool result;
		try
		{
			foreach (KeyValuePair<string, ActiveUnit> activeUnit in ParentScen.ActiveUnits)
			{
				ActiveUnit value = activeUnit.Value;
				if (value == null || value.IsGroup || !value.IsOperating())
				{
					continue;
				}
				Sensor[] sensors_Cached = value.Sensors_Cached;
				foreach (Sensor sensor in sensors_Cached)
				{
					if (sensor.IsGNSSJammer && sensor.IsActive() && GNSS.GNSSJammerType(sensor) == gnsssystem_0 && Module_Unit.Has_Radar_LOS_ToUnit(value, sensor, this, ref ParentScen))
					{
						if (pooledList == null)
						{
							pooledList = new PooledList<double>(Pools<double>.Local);
						}
						pooledList.Add(sensor.ECM_PeakPower);
						if (pooledList2 == null)
						{
							pooledList2 = new PooledList<double>(Pools<double>.Local);
						}
						pooledList2.Add(Module_Unit.RangeToUnit_Slant(value, this, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue));
					}
				}
			}
			if (pooledList != null && pooledList.Count > 0)
			{
				double num = GNSS.ComputeMultiJammerDisruptionProbability(pooledList, pooledList2, gnsssystem_0);
				result = ((GameGeneral.GlobalRNG.NextDouble() < num) ? true : false);
			}
			else
			{
				result = false;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
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
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		finally
		{
			pooledList?.Dispose();
			pooledList2?.Dispose();
		}
		return result;
	}

	public override void Teleport(ref Scenario theScen, double Destination_Lon, double Destination_Lat)
	{
		base.Teleport(ref theScen, Destination_Lon, Destination_Lat);
		Kinematics.ExportLocationEvent("Teleport");
	}

	internal bool WasAirLaunched()
	{
		if (!nullable_19.HasValue)
		{
			try
			{
				if (FiringParent == null)
				{
					return false;
				}
				nullable_19 = FiringParent.IsAircraft || FiringParent.IsMissile;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				nullable_19 = false;
				ProjectData.ClearProjectError();
			}
		}
		return nullable_19.Value;
	}

	private bool method_19()
	{
		if (!SupportsAttitude_Pitch)
		{
			return false;
		}
		if (!IsABMOptimized())
		{
			if (!IsBallisticMissile && Propulsion.Count != 0)
			{
				if (IsAAWCapable)
				{
					Engine.EngineType? engineType = Propulsion[0]?.Type;
					short? num = (short?)engineType;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2001)) != true)
					{
						num = (short?)engineType;
						bool? flag2;
						bool? flag = (flag2 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 2004)));
						bool? obj;
						bool? flag3;
						if (flag.HasValue && flag2 == true)
						{
							obj = true;
						}
						else
						{
							num = (short?)engineType;
							flag = (flag3 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 2003)));
							obj = ((!flag.HasValue) ? ((bool?)null) : ((flag3 == true) | flag2));
						}
						bool? flag4 = obj;
						flag3 = obj;
						bool? obj2;
						bool? flag5;
						if (flag3.HasValue && flag4 == true)
						{
							obj2 = true;
						}
						else
						{
							num = (short?)engineType;
							flag3 = (flag5 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 2005)));
							obj2 = ((!flag3.HasValue) ? ((bool?)null) : ((flag5 == true) | flag4));
						}
						bool? flag6 = obj2;
						flag5 = obj2;
						bool? obj3;
						bool? flag7;
						if (flag5.HasValue && flag6 == true)
						{
							obj3 = true;
						}
						else
						{
							num = (short?)engineType;
							flag5 = (flag7 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 4001)));
							obj3 = ((!flag5.HasValue) ? ((bool?)null) : ((flag7 == true) | flag6));
						}
						flag7 = obj3;
						if (flag7 != true)
						{
							return true;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	internal bool IsABMOptimized()
	{
		if (ValidTargets.Missile)
		{
			if (ValidTargets.Missile && !ValidTargets.Aircraft && !ValidTargets.Helicopter)
			{
				return true;
			}
			try
			{
				if (ParentScen.Cache_WeaponIsABMOptimized == null)
				{
					lock (this)
					{
						if (ParentScen.Cache_WeaponIsABMOptimized == null)
						{
							string theQuery = "SELECT MAX(ID) FROM DataWeapon";
							int maxKey = Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(ParentScen.DBConnection), theQuery));
							ParentScen.Cache_WeaponIsABMOptimized = new ConcurrentPagedArray<bool>(maxKey);
						}
					}
				}
				if (ParentScen.Cache_WeaponIsABMOptimized.TryGetValue(DBID, out var value))
				{
					return value;
				}
				if (Doctrine.WRA == null)
				{
					Weapon theWeapon = this;
					Doctrine doctrine;
					ConcurrentPagedArray<Doctrine.WRA_Weapon> theWRA = (doctrine = Doctrine).WRA;
					DBFunctions.PopulateWeaponWRA(ref theWeapon, ref theWRA);
					doctrine.WRA = theWRA;
				}
				Doctrine.WRA_Weapon wRA_Weapon = Doctrine.WRA.Values.ElementAtOrDefault(0);
				bool flag = false;
				bool flag2 = false;
				foreach (Doctrine.WRA_FiringDoctrineEntry value2 in wRA_Weapon.WRA_WeaponTargets.Values)
				{
					int? weaponQty = value2.WeaponQty;
					if (((!weaponQty.HasValue) ? ((bool?)null) : new bool?(weaponQty.GetValueOrDefault() > 0)) == true)
					{
						switch (value2.TargetType)
						{
						case Doctrine._WRA_WeaponTargetType.Guided_Weapon_Ballistic:
							flag = true;
							break;
						case Doctrine._WRA_WeaponTargetType.Air_Contact_Unknown_Type:
							flag2 = true;
							break;
						}
					}
				}
				int num;
				if (flag)
				{
					if (!flag2)
					{
						value = true;
						goto IL_01c5;
					}
					num = 0;
				}
				else
				{
					num = 0;
				}
				value = (byte)num != 0;
				goto IL_01c5;
				IL_01c5:
				ParentScen.Cache_WeaponIsABMOptimized[DBID] = value;
				return value;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 23453209860112", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		return false;
	}

	internal bool IsABMCapable()
	{
		if (ValidTargets.Missile)
		{
			try
			{
				if (ParentScen.Cache_WeaponIsABMCapable == null)
				{
					lock (this)
					{
						if (ParentScen.Cache_WeaponIsABMCapable == null)
						{
							string theQuery = "SELECT MAX(ID) FROM DataWeapon";
							int maxKey = Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(ParentScen.DBConnection), theQuery));
							ParentScen.Cache_WeaponIsABMCapable = new ConcurrentPagedArray<bool>(maxKey);
						}
					}
				}
				if (ParentScen.Cache_WeaponIsABMCapable.TryGetValue(DBID, out var value))
				{
					return value;
				}
				if (Doctrine.WRA == null)
				{
					Weapon theWeapon = this;
					Doctrine doctrine;
					ConcurrentPagedArray<Doctrine.WRA_Weapon> theWRA = (doctrine = Doctrine).WRA;
					DBFunctions.PopulateWeaponWRA(ref theWeapon, ref theWRA);
					doctrine.WRA = theWRA;
				}
				Doctrine.WRA_Weapon wRA_Weapon = Doctrine.WRA.Values.ElementAtOrDefault(0);
				foreach (Doctrine.WRA_FiringDoctrineEntry value2 in wRA_Weapon.WRA_WeaponTargets.Values)
				{
					int? weaponQty = value2.WeaponQty;
					if ((weaponQty.HasValue ? new bool?(weaponQty.GetValueOrDefault() > 0) : ((bool?)null)) == true)
					{
						Doctrine._WRA_WeaponTargetType targetType = value2.TargetType;
						if (targetType == Doctrine._WRA_WeaponTargetType.Guided_Weapon_Ballistic)
						{
							value = true;
						}
					}
				}
				ParentScen.Cache_WeaponIsABMCapable[DBID] = value;
				return value;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 23453209860112", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		return false;
	}

	private bool method_20()
	{
		if (!IsASuW_Land && !IsASuW_Naval)
		{
			return false;
		}
		if (CruiseAltitude_AGL > 0f && CruiseAltitude_AGL < 1000f)
		{
			return true;
		}
		return false;
	}

	public override void ResetIDs()
	{
		base.ResetIDs();
		Warhead[] warheads = Warheads;
		for (int i = 0; i < warheads.Length; i = checked(i + 1))
		{
			warheads[i].ResetIDs();
		}
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			if ((((ActiveUnit)this).get_UnitSide(SetSideOnly: false) == null) & (Name == null))
			{
				return;
			}
			theWriter.WriteStartElement("Weapon");
			theWriter.WriteElementString("ID", ObjectID);
			if (!ObjectsAlreadySerialized.Contains(ObjectID))
			{
				ObjectsAlreadySerialized.Add(ObjectID);
				theWriter.WriteElementString("Name", Name.Replace("\0", "").Replace("\u0010", ""));
				theWriter.WriteElementString("CH", XmlConvert.ToString(CurrentHeading));
				theWriter.WriteElementString("CS", XmlConvert.ToString(CurrentSpeed));
				theWriter.WriteElementString("CA", XmlConvert.ToString(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
				theWriter.WriteElementString("ImpactAltitude", XmlConvert.ToString(ImpactAltitude));
				theWriter.WriteElementString("Lon", XmlConvert.ToString(this.get_Longitude((GlobalVariables.BooleanObject)null)));
				theWriter.WriteElementString("Lat", XmlConvert.ToString(this.get_Latitude((GlobalVariables.BooleanObject)null)));
				LastReportedInfoToXML(ref theWriter);
				if (Attitude_Pitch != 0f)
				{
					theWriter.WriteElementString("Pitch", XmlConvert.ToString(Attitude_Pitch));
				}
				if (Attitude_Roll != 0f)
				{
					theWriter.WriteElementString("Roll", XmlConvert.ToString(Attitude_Roll));
				}
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
				theWriter.WriteElementString("CEP_Surface", Conversions.ToString(XmlConvert.ToDouble(Conversions.ToString(CEP_Surface))));
				theWriter.WriteElementString("CEP_Land", Conversions.ToString(XmlConvert.ToDouble(Conversions.ToString(CEP_Land))));
				if (((ActiveUnit)this).get_UnitSide(SetSideOnly: false) == null)
				{
					Side[] sides_ReadOnly = ParentScen.Sides_ReadOnly;
					foreach (Side side in sides_ReadOnly)
					{
						if (side.Units.Contains(this))
						{
							_UnitSide = side;
							break;
						}
					}
				}
				if (((ActiveUnit)this).get_UnitSide(SetSideOnly: false) != null)
				{
					theWriter.WriteElementString("Side", ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Name);
				}
				if (!string.IsNullOrEmpty(Message))
				{
					theWriter.WriteElementString("Message", Message);
				}
				theWriter.WriteElementString("DBID", DBID.ToString());
				if (((ActiveUnit)this).DesiredHeading != 0f)
				{
					theWriter.WriteElementString("DH", XmlConvert.ToString(((ActiveUnit)this).DesiredHeading));
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
				if (this.get_DesiredAltitude_UseTerrainFollowing((ActiveUnit)this))
				{
					theWriter.WriteElementString("TerrainFollowing", this.get_DesiredAltitude_UseTerrainFollowing((ActiveUnit)this).ToString());
				}
				if (ThrottleSetting != Throttle.FullStop)
				{
					theWriter.WriteElementString("TS", ((byte)ThrottleSetting).ToString());
				}
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
				foreach (Engine item2 in Propulsion)
				{
					theWriter.WriteRaw(item2.ToXML(ObjectsAlreadySerialized));
				}
				theWriter.WriteEndElement();
				theWriter.WriteStartElement("Fuel");
				foreach (FuelRec item3 in _Fuel)
				{
					theWriter.WriteRaw(item3.ToXML());
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
				if (_AltitudeBefore_NeedToRefuel != 0f)
				{
					theWriter.WriteElementString("SBR_Altitude", XmlConvert.ToString(_AltitudeBefore_NeedToRefuel));
				}
				if (_AltitudeBefore_NeedToRefuel_AGL != 0f)
				{
					theWriter.WriteElementString("SBR_Altitude_TF", XmlConvert.ToString(_AltitudeBefore_NeedToRefuel_AGL));
				}
				theWriter.WriteElementString("SBR_TF", XmlConvert.ToString(_TerrainFollowingBefore_NeedToRefuel));
				XmlWriter obj7 = theWriter;
				status = (byte)_ThrottleBefore_NeedToRefuel;
				obj7.WriteElementString("SBR_ThrottleSetting", status.ToString());
				theWriter.WriteElementString("SBED_Altitude", XmlConvert.ToString(_AltitudeBefore_EngagedDefensive));
				if (_AltitudeBefore_EngagedDefensive_AGL.HasValue)
				{
					theWriter.WriteElementString("SBED_Altitude_TF", XmlConvert.ToString(_AltitudeBefore_EngagedDefensive_AGL.Value));
				}
				theWriter.WriteElementString("SBED_TF", XmlConvert.ToString(_TerrainFollowingBefore_EngagedDefensive));
				XmlWriter obj8 = theWriter;
				status = (byte)_ThrottleBefore_EngagedDefensive;
				obj8.WriteElementString("SBED_ThrottleSetting", status.ToString());
				if (_DesiredSpeedOverrideBefore_EngagedDefensive.HasValue)
				{
					theWriter.WriteElementString("SBED_DesiredSpeedOverride", XmlConvert.ToString(_DesiredSpeedOverrideBefore_EngagedDefensive.Value));
				}
				theWriter.WriteElementString("SBEO_Altitude", XmlConvert.ToString(_AltitudeBefore_EngagedOffensive));
				theWriter.WriteElementString("SBEO_Altitude_TF", XmlConvert.ToString(_AltitudeBefore_EngagedOffensive_AGL));
				theWriter.WriteElementString("SBEO_TF", XmlConvert.ToString(_TerrainFollowingBefore_EngagedOffensive));
				if (_ThrottleBefore_EngagedOffensive != Throttle.FullStop)
				{
					XmlWriter obj9 = theWriter;
					status = (byte)_ThrottleBefore_EngagedOffensive;
					obj9.WriteElementString("SBEO_ThrottleSetting", status.ToString());
				}
				theWriter.WriteElementString("SBPF_Altitude", XmlConvert.ToString(_AltitudeBefore_WaitForPathfinder));
				theWriter.WriteElementString("SBPF_Altitude_TF", XmlConvert.ToString(_AltitudeBefore_WaitForPathfinder_AGL));
				theWriter.WriteElementString("SBPF_TF", XmlConvert.ToString(_TerrainFollowingBefore_WaitForPathfinder));
				XmlWriter obj10 = theWriter;
				status = (byte)_ThrottleBefore_WaitForPathfinder;
				obj10.WriteElementString("SBPF_ThrottleSetting", status.ToString());
				theWriter.WriteElementString("AMP_OC", _MissionPlannerOverrideCancellation.ToString());
				if (!Information.IsNothing((object)_MissionPlannerOverrideCancellation_DesiredSpeedOverride))
				{
					theWriter.WriteElementString("AMP_OC_DSO", _MissionPlannerOverrideCancellation_DesiredSpeedOverride.ToString());
				}
				theWriter.WriteElementString("AMP_OC_DAO", _MissionPlannerOverrideCancellation_DesiredAltitudeOverride.ToString());
				theWriter.WriteElementString("AMP_OC_Speed", XmlConvert.ToString(_MissionPlannerOverrideCancellation_Speed));
				if (TimeToReseek > 0f)
				{
					theWriter.WriteElementString("TTReseek", XmlConvert.ToString(TimeToReseek));
				}
				if (CruiseAltitude_ASL != 0f)
				{
					theWriter.WriteElementString("CruiseAltitude_ASL", XmlConvert.ToString(CruiseAltitude_ASL));
				}
				FixedSizeQueue<bool> recentPNTChecks = RecentPNTChecks;
				if (recentPNTChecks != null && recentPNTChecks.Count > 0)
				{
					theWriter.WriteStartElement("RecentPNTChecks");
					foreach (bool recentPNTCheck in RecentPNTChecks)
					{
						theWriter.WriteElementString("Item", recentPNTCheck.ToString());
					}
					theWriter.WriteEndElement();
				}
				theWriter.WriteElementString("DamagePts", XmlConvert.ToString(((ActiveUnit)this).get_DamagePts(ScenEditAction: false, (Weapon)null)));
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
				if (_DockFacilities.Length > 0)
				{
					theWriter.WriteStartElement("DockFacilities");
					DockFacility[] dockFacilities = _DockFacilities;
					foreach (DockFacility dockFacility in dockFacilities)
					{
						theWriter.WriteRaw(dockFacility.ToXML(ObjectsAlreadySerialized));
					}
					theWriter.WriteEndElement();
				}
				if (!Information.IsNothing((object)_AssignedMissionOrPackage))
				{
					theWriter.WriteElementString("AssignedMission", _AssignedMissionOrPackage.ObjectID);
				}
				if (!Information.IsNothing((object)AssignedTaskPool))
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
				if (base.get_IsAutoDetectable((Side)null))
				{
					theWriter.WriteElementString("IsAD", base.get_IsAutoDetectable((Side)null).ToString());
				}
				Doctrine.ToXML(ref theWriter, ref ParentScen);
				theWriter.WriteStartElement("Warheads");
				Warhead[] warheads = Warheads;
				for (int n = 0; n < warheads.Length; n = checked(n + 1))
				{
					warheads[n].ToXML(ref theWriter);
				}
				theWriter.WriteEndElement();
				theWriter.WriteElementString("BT", _BlindTime.ToString());
				theWriter.WriteElementString("DRT", _DatalinkRetargetTime.ToString());
				if (DataLinkParent != null)
				{
					theWriter.WriteElementString("DataLinkParent", DataLinkParent.ObjectID);
				}
				if (FiringParent != null)
				{
					theWriter.WriteElementString("FiringParent", FiringParent.ObjectID);
				}
				if (SearchPatternType != WeaponSearchPatternType.None)
				{
					XmlWriter obj11 = theWriter;
					status = (byte)SearchPatternType;
					obj11.WriteElementString("SearchPatternType", status.ToString());
				}
				theWriter.WriteElementString("Guidance", ((int)Guidance).ToString());
				if (LaunchPoint != null)
				{
					theWriter.WriteStartElement("LaunchPoint");
					theWriter.WriteRaw(LaunchPoint.ToXML(ObjectsAlreadySerialized));
					theWriter.WriteEndElement();
				}
				if (LaunchSpeed > 0f)
				{
					theWriter.WriteElementString("LaunchSpeed", LaunchSpeed.ToString(CultureInfo.InvariantCulture));
				}
				if (TimeSinceLaunch > 0f)
				{
					theWriter.WriteElementString("TSL", XmlConvert.ToString(TimeSinceLaunch));
				}
				if (TimeSinceBurnout > 0f)
				{
					theWriter.WriteElementString("TSB", XmlConvert.ToString(TimeSinceBurnout));
				}
				theWriter.WriteElementString("TTD", XmlConvert.ToString(_TimeToDetonate));
				if (!Information.IsNothing((object)sensor_1))
				{
					theWriter.WriteElementString("SIFM", sensor_1.ObjectID);
				}
				if (!Information.IsNothing((object)ARM_SpecifiedEMission.Value))
				{
					theWriter.WriteStartElement("ARM_SE");
					theWriter.WriteElementString("Emission" + ARM_SpecifiedEMission.Key, ARM_SpecifiedEMission.Value.ToString());
					theWriter.WriteEndElement();
				}
				if (IsWeaponPallet && WeaponWeapons.Count == 0)
				{
					Warhead[] warheads2 = Warheads;
					_Closure$__203-0 closure$__203- = default(_Closure$__203-0);
					for (int num = 0; num < warheads2.Length; num = checked(num + 1))
					{
						closure$__203- = new _Closure$__203-0(closure$__203-);
						closure$__203-.$VB$Me = this;
						closure$__203-.$VB$Local_theWH = warheads2[num];
						if (closure$__203-.$VB$Local_theWH.get_CarriedWeapon(ParentScen) != null && WeaponWeapons.Where(closure$__203-._Lambda$__0).Count() <= 0)
						{
							int num2 = Warheads.Where(closure$__203-._Lambda$__1).Count();
							WeaponRec item = new WeaponRec(ref ParentScen, closure$__203-.$VB$Local_theWH.get_CarriedWeapon(ParentScen).DBID, num2, num2, 1, 1, ExcludeOptionalWeapons: false, AircraftInternalWeapons: false);
							WeaponWeapons.Add(item);
						}
					}
				}
				if (WeaponWeapons.Count > 0)
				{
					theWriter.WriteStartElement("WeaponWeapons");
					foreach (WeaponRec weaponWeapon in WeaponWeapons)
					{
						theWriter.WriteRaw(weaponWeapon.ToXML(ObjectsAlreadySerialized, ParentScen));
					}
					theWriter.WriteEndElement();
				}
				theWriter.WriteElementString("ARM_SEIM", ARM_SpecifiedEmissionIsMandatory.ToString());
				if (!Information.IsNothing((object)_IlluminatorUnit))
				{
					theWriter.WriteElementString("IlluminatorUnit", _IlluminatorUnit.ObjectID);
				}
				Navigator.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteStartElement("Weapon_AI");
				AI.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteEndElement();
				theWriter.WriteStartElement("Weapon_Kinematics");
				Kinematics.ToXML(ref theWriter);
				theWriter.WriteEndElement();
				Sensory.ToXML(ref theWriter);
				CommStuff.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				Damage.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				if (WasAirLaunched())
				{
					theWriter.WriteElementString("WasAirLaunched", "True");
				}
				if (WasAirLaunched())
				{
					theWriter.WriteElementString("WasAirLaunched", "True");
				}
				theWriter.WriteEndElement();
			}
			else
			{
				theWriter.WriteEndElement();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100881", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static Weapon FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		Weapon weapon = default(Weapon);
		try
		{
			weapon = FromXML_Private(theNode, theDictionary, theScen, theScen.LoadStockUnits);
		}
		catch (PlatformComponentNotFoundException projectError)
		{
			ProjectData.SetProjectError((Exception)projectError);
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			ConcurrentDictionary<string, ScenarioObject> obj = theDictionary;
			ScenarioObject value = weapon;
			obj.TryRemove(innerText, out value);
			weapon = FromXML_Private(theNode, theDictionary, theScen, LoadStockComponents_Force: true);
			string text = "";
			if (weapon.IsGroupMember())
			{
				text = "(member of group: [" + ((ActiveUnit)weapon).get_ParentGroup(UsingMissionPlanner: false).Name + "])";
			}
			theScen.LoadingNotices.Add("The following weapon:[" + weapon.Name + "]" + text + " failed to shallow-rebuild because of a component missing. The weapon was instead deep-rebuilt, and instantiated in its pristine DB-stock condition. All customizations present in the weapon's components (damaged components, additions/removals etc. etc.) have been lost. Please re-apply any necessary customizations either manually or using an SBR script.");
			ProjectData.ClearProjectError();
		}
		return weapon;
	}

	public void InitializeWeaponWeaponsPallet()
	{
		if (WeaponWeapons.Count != 0)
		{
			return;
		}
		Warhead[] warheads = Warheads;
		_Closure$__205-0 closure$__205- = default(_Closure$__205-0);
		for (int i = 0; i < warheads.Length; i = checked(i + 1))
		{
			closure$__205- = new _Closure$__205-0(closure$__205-);
			closure$__205-.$VB$Me = this;
			closure$__205-.$VB$Local_theWH = warheads[i];
			if (closure$__205-.$VB$Local_theWH.get_CarriedWeapon(ParentScen) != null && WeaponWeapons.Where(closure$__205-._Lambda$__0).Count() <= 0)
			{
				int num = Warheads.Where(closure$__205-._Lambda$__1).Count();
				WeaponRec item = new WeaponRec(ref ParentScen, closure$__205-.$VB$Local_theWH.get_CarriedWeapon(ParentScen).DBID, num, num, 1, 1, ExcludeOptionalWeapons: false, AircraftInternalWeapons: false);
				WeaponWeapons.Add(item);
			}
		}
	}

	protected static void LoadSavedComponents(Weapon theW, Scenario theScen, XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Expected O, but got Unknown
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Expected O, but got Unknown
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		foreach (XmlNode childNode in theNode.ChildNodes)
		{
			XmlNode val = childNode;
			switch (val.Name)
			{
			case "AirFacilities":
				foreach (XmlNode childNode2 in val.ChildNodes)
				{
					XmlNode theNode5 = childNode2;
					AirFacility airFacility = AirFacility.FromXML(ref theNode5, ref theDictionary, ref theScen);
					theW.AddAirFacility(airFacility);
					airFacility.ParentPlatform = theW;
				}
				break;
			case "Mounts":
				foreach (XmlNode childNode3 in val.ChildNodes)
				{
					XmlNode theNode8 = childNode3;
					Mount mount = Mount.FromXML(ref theNode8, ref theDictionary, theW);
					theW.Mounts.Add(mount);
					mount.ParentPlatform = theW;
				}
				break;
			case "Sensors":
				foreach (XmlNode childNode4 in val.ChildNodes)
				{
					Sensor sensor = Sensor.FromXML(childNode4, theDictionary, theW);
					theW._Sensors.Add(sensor);
					sensor.ParentPlatform = theW;
				}
				break;
			case "Propulsion":
				foreach (XmlNode childNode5 in val.ChildNodes)
				{
					XmlNode theNode7 = childNode5;
					ActiveUnit theParentPlatform = theW;
					Engine engine = Engine.FromXML(ref theNode7, ref theDictionary, ref theParentPlatform);
					theW.Propulsion.Add(engine);
					engine.ParentPlatform = theW;
				}
				break;
			case "Fuel":
				foreach (XmlNode childNode6 in val.ChildNodes)
				{
					XmlNode theNode6 = childNode6;
					FuelRec item2 = FuelRec.FromXML(ref theNode6, ref theDictionary);
					theW._Fuel.Add(item2);
				}
				break;
			case "Comms":
			{
				int num = val.ChildNodes.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					XmlNode theNode4 = val.ChildNodes[i];
					CommDevice commDevice = CommDevice.FromXML(ref theNode4, ref theDictionary, theW);
					if (commDevice.DBID == 0)
					{
						Weapon weapon = new Weapon(theScen);
						weapon.ParentScen = theScen;
						DBFunctions.GetWeapon(theScen.DBConnection, weapon, theW.DBID, theScen);
						try
						{
							commDevice = weapon.Comms_ReadOnly[i];
							weapon = null;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 101179", "");
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						theDictionary.TryAdd(commDevice.ObjectID, commDevice);
					}
					if (theW.Type == _WeaponType.Sonobuoy)
					{
						commDevice.ParentSpecific = false;
					}
					theW.AddCommDevice(commDevice);
					commDevice.ParentPlatform = theW;
				}
				break;
			}
			case "OnboardCargo":
				foreach (XmlNode childNode7 in val.ChildNodes)
				{
					XmlNode theNode3 = childNode7;
					Cargo cargo = Cargo.FromXML(ref theNode3, ref theDictionary, theScen, theW);
					ArrayExtensions.Add(ref theW.OnboardCargo, cargo);
					cargo.ParentPlatform = theW;
				}
				break;
			case "WeaponWeapons":
				foreach (XmlNode childNode8 in val.ChildNodes)
				{
					XmlNode theNode2 = childNode8;
					WeaponRec item = WeaponRec.FromXML(ref theNode2, ref theDictionary, ref theScen);
					theW.WeaponWeapons.Add(item);
				}
				break;
			}
		}
	}

	protected static Weapon FromXML_Private(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen, bool LoadStockComponents_Force)
	{
		Weapon result;
		try
		{
			XmlNode nodeByName = Misc.GetNodeByName(theNode.ChildNodes, "DBID");
			int num = default(int);
			if (nodeByName != null)
			{
				num = Conversions.ToInteger(nodeByName.InnerText);
				switch (DBFunctions.GetWeaponType(num, theScen))
				{
				case _WeaponType.GuidedProjectile:
					result = GuidedProjectile.FromXML_Private(theNode, theDictionary, theScen, LoadStockComponents_Force);
					goto end_IL_0001;
				case _WeaponType.Rocket:
					result = UnguidedRocket.FromXML_Private(theNode, theDictionary, theScen, LoadStockComponents_Force);
					goto end_IL_0001;
				case _WeaponType.HGV:
					result = HGV.FromXML_Private(theNode, theDictionary, theScen, LoadStockComponents_Force);
					goto end_IL_0001;
				case _WeaponType.BallisticMissile:
					result = BallisticMissile.FromXML_Private(theNode, theDictionary, theScen, LoadStockComponents_Force);
					goto end_IL_0001;
				case _WeaponType.Torpedo:
					result = Torpedo.FromXML_Private(theNode, theDictionary, theScen, LoadStockComponents_Force);
					goto end_IL_0001;
				}
			}
			Weapon weapon = new Weapon(theScen);
			weapon.ParentScen = theScen;
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			if (!theDictionary.ContainsKey(innerText))
			{
				weapon.ObjectID_Set(innerText);
				if (theNode.ChildNodes.Count == 1)
				{
					theScen.UnitsForLateInstantiation.Add(theNode);
					result = weapon;
				}
				else
				{
					theDictionary.TryAdd(weapon.ObjectID, weapon);
					DBFunctions.GetWeapon(theScen.DBConnection, weapon, num, theScen, LoadStockComponents_Force);
					weapon.DBID = num;
					if (weapon.IsHGV)
					{
						weapon.CruiseAltitude_ASL = 100000f;
					}
					if (LoadStockComponents_Force)
					{
						weapon.method_3(ref theNode, ref theDictionary, ref theScen);
					}
					if (!LoadStockComponents_Force)
					{
						LoadSavedComponents(weapon, theScen, theNode, theDictionary);
					}
					LoadMutableProperties(weapon, theScen, theNode, theDictionary);
					float maximumAltitude = weapon.Kinematics.GetMaximumAltitude();
					float minimumAltitude = weapon.Kinematics.GetMinimumAltitude();
					if (weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > maximumAltitude && (weapon.Type == _WeaponType.GuidedWeapon || weapon.Type == _WeaponType.Torpedo))
					{
						weapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, maximumAltitude);
					}
					else if (weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < minimumAltitude && (weapon.Type == _WeaponType.GuidedWeapon || weapon.Type == _WeaponType.Torpedo))
					{
						weapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, minimumAltitude);
					}
					if (weapon.DesiredAltitude > maximumAltitude && (weapon.Type == _WeaponType.GuidedWeapon || weapon.Type == _WeaponType.Torpedo))
					{
						weapon.DesiredAltitude = maximumAltitude;
					}
					else if (weapon.DesiredAltitude < minimumAltitude && (weapon.Type == _WeaponType.GuidedWeapon || weapon.Type == _WeaponType.Torpedo))
					{
						weapon.DesiredAltitude = minimumAltitude;
					}
					weapon.EvaluateIfDumb();
					if (weapon.IsWeaponPallet && weapon.WeaponWeapons.Count == 0)
					{
						weapon.InitializeWeaponWeaponsPallet();
					}
					if (weapon.IsReEntryVehicle && !weapon.HasTerminalGuidance && weapon.Navigator.PlottedCourse.Count() == 1 && weapon.AI.PrimaryTarget != null && weapon.AI.PrimaryTarget_Type == Contact_Base.ContactType.Aimpoint)
					{
						weapon.Navigator.PlottedCourse[0].Altitude = ((Module_Unit.Unit)weapon.AI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					}
					result = weapon;
				}
			}
			else
			{
				result = (Weapon)theDictionary[innerText];
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100882", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Weapon(theScen);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	protected static void LoadMutableProperties(Weapon theW, Scenario theScen, XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_118f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1196: Expected O, but got Unknown
		//IL_0e7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_126b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1272: Expected O, but got Unknown
		//IL_0f5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f66: Expected O, but got Unknown
		//IL_0947: Unknown result type (might be due to invalid IL or missing references)
		foreach (XmlNode childNode in theNode.ChildNodes)
		{
			XmlNode theNode2 = childNode;
			if (theW.isLastReportedInfoXMLField(theNode2.Name))
			{
				theW.LastReportedInfoFromXMLField(theNode2.Name, theNode2.InnerText);
				continue;
			}
			switch (theNode2.Name)
			{
			case "Name":
				theW.Name = theNode2.InnerText;
				break;
			case "FSBR":
				theW._FuelStateBefore_NeedToRefuel = (_ActiveUnitFuelState)Conversions.ToByte(theNode2.InnerText);
				break;
			case "Status":
				if (Versioned.IsNumeric((object)theNode2.InnerText))
				{
					theW.Status = (_ActiveUnitStatus)Conversions.ToByte(theNode2.InnerText);
				}
				else
				{
					theW.Status = (_ActiveUnitStatus)Enum.Parse(typeof(_ActiveUnitStatus), theNode2.InnerText, ignoreCase: true);
				}
				if (theW.Status == (_ActiveUnitStatus)9)
				{
					theW.Status = _ActiveUnitStatus.RTB;
				}
				break;
			case "AMP_OC_Speed":
				theW._MissionPlannerOverrideCancellation_Speed = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "SBED_Altitude_TF":
				theW._AltitudeBefore_EngagedDefensive_AGL = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "SBPF_TF":
				theW._TerrainFollowingBefore_WaitForPathfinder = Misc.ParseBool(theNode2.InnerText);
				break;
			case "DRT":
				theW._DatalinkRetargetTime = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
				break;
			case "FuelState":
				theW._FuelState = (_ActiveUnitFuelState)Conversions.ToByte(theNode2.InnerText);
				break;
			case "Weapon_AI":
				Weapon_AI.FromXML(theNode2, theDictionary, theW);
				if (theW.get_DesiredAltitude_UseTerrainFollowing((ActiveUnit)theW) && theW.DesiredAltitude_AGL == 0f)
				{
					theW.DesiredAltitude_AGL = 60.96f;
				}
				break;
			case "CruiseAltitude_ASL":
				theW.CruiseAltitude_ASL = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "DamagePts":
				((ActiveUnit)theW).set_DamagePts(ScenEditAction: false, (Weapon)null, XmlConvert.ToSingle(theNode2.InnerText));
				break;
			case "IlluminatorUnit":
				theW._IlluminatorUnit = ActiveUnit.FromXML(ref theNode2, ref theDictionary, ref theScen);
				break;
			case "Weapon_Navigator":
			{
				ActiveUnit theAU = theW;
				theW._Navigator = Weapon_Navigator.FromXML(ref theNode2, ref theDictionary, ref theAU);
				break;
			}
			case "TSB":
				theW.TimeSinceBurnout = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "Weapon_CommStuff":
			{
				ActiveUnit theAU = theW;
				theW.weapon_CommStuff_0 = Weapon_CommStuff.FromXML(ref theNode2, ref theDictionary, ref theAU);
				break;
			}
			case "SBED_Altitude":
				theW._AltitudeBefore_EngagedDefensive = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "AMP_OC_DAO":
				theW._MissionPlannerOverrideCancellation_DesiredAltitudeOverride = Misc.ParseBool(theNode2.InnerText);
				break;
			case "TSL":
				theW.TimeSinceLaunch = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "SBPF_ThrottleSetting":
				switch (theNode2.InnerText)
				{
				case "Full":
					theW._ThrottleBefore_WaitForPathfinder = Throttle.Full;
					break;
				case "Flank":
					theW._ThrottleBefore_WaitForPathfinder = Throttle.Flank;
					break;
				default:
					theW._ThrottleBefore_WaitForPathfinder = (Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "Cruise":
					theW._ThrottleBefore_WaitForPathfinder = Throttle.Cruise;
					break;
				case "Loiter":
					theW._ThrottleBefore_WaitForPathfinder = Throttle.Loiter;
					break;
				case "FullStop":
					theW._ThrottleBefore_WaitForPathfinder = Throttle.FullStop;
					break;
				}
				break;
			case "DesiredHeading":
			case "DH":
				((ActiveUnit)theW).set_DesiredHeading(TurnRate.Max, XmlConvert.ToSingle(theNode2.InnerText));
				break;
			case "BT":
			case "BlindTime":
				theW._BlindTime = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
				break;
			case "SBR":
				theW._StatusBefore_NeedToRefuel = (_ActiveUnitStatus)Conversions.ToByte(theNode2.InnerText);
				break;
			case "SBR_Altitude_TF":
				theW._AltitudeBefore_NeedToRefuel_AGL = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "SBPF_Altitude_TF":
				theW._AltitudeBefore_WaitForPathfinder_AGL = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "SBED_DesiredSpeedOverride":
				theW._DesiredSpeedOverrideBefore_EngagedDefensive = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "SIFM":
			case "SensorIlluminatingForMe":
				theW._SensorIlluminatingForMe_ObjectID = theNode2.InnerText;
				break;
			case "DataLinkParent":
				theW._DataLinkParent_ID = theNode2.InnerText;
				break;
			case "ActiveEnterAreaTriggers":
				foreach (XmlNode childNode2 in theNode2.ChildNodes)
				{
					string innerText2 = childNode2.InnerText;
					theW.ActiveEnterAreaTriggers.Add(innerText2);
				}
				break;
			case "SBED_ThrottleSetting":
				switch (theNode2.InnerText)
				{
				case "FullStop":
					theW._ThrottleBefore_EngagedDefensive = Throttle.FullStop;
					break;
				case "Loiter":
					theW._ThrottleBefore_EngagedDefensive = Throttle.Loiter;
					break;
				case "Full":
					theW._ThrottleBefore_EngagedDefensive = Throttle.Full;
					break;
				case "Flank":
					theW._ThrottleBefore_EngagedDefensive = Throttle.Flank;
					break;
				default:
					theW._ThrottleBefore_EngagedDefensive = (Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "Cruise":
					theW._ThrottleBefore_EngagedDefensive = Throttle.Cruise;
					break;
				}
				break;
			case "TS":
			case "ThrottleSetting":
				switch (theNode2.InnerText)
				{
				case "FullStop":
					theW.ThrottleSetting = Throttle.FullStop;
					break;
				case "Cruise":
					theW.ThrottleSetting = Throttle.Cruise;
					break;
				case "Full":
					theW.ThrottleSetting = Throttle.Full;
					break;
				case "Flank":
					theW.ThrottleSetting = Throttle.Flank;
					break;
				default:
					theW.ThrottleSetting = (Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "Loiter":
					theW.ThrottleSetting = Throttle.Loiter;
					break;
				}
				break;
			case "SBEO_TF":
				theW._TerrainFollowingBefore_EngagedOffensive = Misc.ParseBool(theNode2.InnerText);
				break;
			case "WeaponState":
				theW._WeaponState = (_ActiveUnitWeaponState)Conversions.ToSByte(theNode2.InnerText);
				break;
			case "Doctrine":
				theW.Doctrine = Doctrine.FromXML(theScen, ref theNode2, theW);
				break;
			case "Weapon_Kinematics":
				ActiveUnit_Kinematics.FromXML(theNode2, theDictionary, theW);
				break;
			case "AMP_OC_DSO":
				theW._MissionPlannerOverrideCancellation_DesiredSpeedOverride = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "SBED_TF":
				theW._TerrainFollowingBefore_EngagedDefensive = Misc.ParseBool(theNode2.InnerText);
				break;
			case "Pitch":
				theW.Attitude_Pitch = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "CurrentAltitude":
			case "CA":
				theW.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, XmlConvert.ToSingle(theNode2.InnerText));
				break;
			case "Latitude_UnitEntersAreaCheck":
				theW.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(theNode2.InnerText);
				break;
			case "AssignedMission":
				if (theNode2.HasChildNodes)
				{
					XmlNode val4 = theNode2.ChildNodes[0];
					theW._AssignedMissionOrPackage_ID = val4.InnerText;
				}
				break;
			case "DA":
			case "DesiredAltitude":
				theW.DesiredAltitude = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "TerrainFollowing":
				theW.set_DesiredAltitude_UseTerrainFollowing((ActiveUnit)theW, Misc.ParseBool(theNode2.InnerText));
				break;
			case "RecentPNTChecks":
				theW.RecentPNTChecks = new FixedSizeQueue<bool>(50);
				foreach (XmlNode childNode3 in theNode2.ChildNodes)
				{
					bool item = bool.Parse(childNode3.InnerText);
					theW.RecentPNTChecks.Enqueue(item);
				}
				break;
			case "WasAirLaunched":
				theW.nullable_19 = Conversions.ToBoolean(theNode2.InnerText);
				break;
			case "ActiveRemainAreaTriggers":
			{
				string key2 = null;
				DateTime result = DateTime.MinValue;
				foreach (XmlNode childNode4 in theNode2.ChildNodes)
				{
					XmlNode val3 = childNode4;
					if (Operators.CompareString(val3.Name, "RemainAreaTrigger", false) != 0)
					{
						if (!DateTime.TryParse(val3.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
						{
							string innerText = val3.InnerText;
							long result2 = default(long);
							if (long.TryParse(innerText, out result2))
							{
								result = DateTime.FromBinary(Conversions.ToLong(val3.InnerText));
								theW.ActiveRemainAreaTriggers.Add(key2, result);
							}
						}
						else
						{
							theW.ActiveRemainAreaTriggers.Add(key2, result);
						}
					}
					else
					{
						key2 = val3.InnerText;
						result = DateTime.MinValue;
					}
				}
				break;
			}
			case "Roll":
				theW.Attitude_Roll = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "FiringParent":
				theW._FiringParent_ID = theNode2.InnerText;
				break;
			case "Side":
				theW._SideName = theNode2.InnerText;
				break;
			case "Longitude":
			case "Lon":
				theW.set_Longitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(theNode2.InnerText));
				break;
			case "LaunchPoint":
			{
				XmlNode val2 = theNode2.FirstChild;
				theW.LaunchPoint = GeoPoint.FromXML(ref val2, ref theDictionary);
				break;
			}
			case "TTD":
			case "TimeToDetonate":
				theNode2.InnerText = theNode2.InnerText.Replace(",", ".");
				theW._TimeToDetonate = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "ARM_SpecifiedEmission":
			case "ARM_SE":
				foreach (XmlNode childNode5 in theNode2.ChildNodes)
				{
					XmlNode val = childNode5;
					int key = Conversions.ToInteger(val.Name.Remove(0, 8));
					XmlNode val2;
					string SourceString = (val2 = val).InnerText;
					EmissionContainer value = EmissionContainer.FromString(ref SourceString);
					val2.InnerText = SourceString;
					theW.ARM_SpecifiedEMission = new KeyValuePair<int, EmissionContainer>(key, value);
				}
				break;
			case "SearchPatternType":
				theW.SearchPatternType = (WeaponSearchPatternType)Conversions.ToByte(theNode2.InnerText);
				break;
			case "Warheads":
				foreach (XmlNode childNode6 in theNode2.ChildNodes)
				{
					XmlNode theNode3 = childNode6;
					Warhead theAC = Warhead.FromXML(ref theNode3, ref theDictionary);
					ArrayExtensions.Add(ref theW.Warheads, theAC);
				}
				break;
			case "DS":
			case "DesiredSpeed":
				theW.DesiredSpeed = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "TTReseek":
				theW.TimeToReseek = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "CEP_Land":
				theW.CEP_Land = Conversions.ToInteger(theNode2.InnerText);
				break;
			case "SBEO_Altitude":
				theW._AltitudeBefore_EngagedOffensive = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "SBPF_Altitude":
				theW._AltitudeBefore_WaitForPathfinder = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "SBR_ThrottleSetting":
				switch (theNode2.InnerText)
				{
				case "Loiter":
					theW._ThrottleBefore_NeedToRefuel = Throttle.Loiter;
					break;
				case "Cruise":
					theW._ThrottleBefore_NeedToRefuel = Throttle.Cruise;
					break;
				default:
					theW._ThrottleBefore_NeedToRefuel = (Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "Flank":
					theW._ThrottleBefore_NeedToRefuel = Throttle.Flank;
					break;
				case "Full":
					theW._ThrottleBefore_NeedToRefuel = Throttle.Full;
					break;
				case "FullStop":
					theW._ThrottleBefore_NeedToRefuel = Throttle.FullStop;
					break;
				}
				break;
			case "Message":
				theW.Message = theNode2.InnerText;
				break;
			case "SBEO_Altitude_TF":
				theW._AltitudeBefore_EngagedOffensive_AGL = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "CEP":
			case "CEP_Surface":
				theW.CEP_Surface = Conversions.ToInteger(theNode2.InnerText);
				break;
			case "SBR_Altitude":
				theW._AltitudeBefore_NeedToRefuel = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "Latitude":
			case "Lat":
				theW.set_Latitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(theNode2.InnerText));
				break;
			case "SBR_TF":
				theW._TerrainFollowingBefore_NeedToRefuel = Misc.ParseBool(theNode2.InnerText);
				break;
			case "SBEO":
				theW._StatusBefore_EngagedOffensive = (_ActiveUnitStatus)Conversions.ToByte(theNode2.InnerText);
				break;
			case "AMP_OC":
				theW._MissionPlannerOverrideCancellation = Misc.ParseBool(theNode2.InnerText);
				break;
			case "SBED":
				theW._StatusBefore_EngagedDefensive = (_ActiveUnitStatus)Conversions.ToByte(theNode2.InnerText);
				break;
			case "Weapon_Sensory":
			{
				ActiveUnit theAU = theW;
				theW.weapon_Sensory_0 = Weapon_Sensory.FromXML(ref theNode2, ref theDictionary, ref theAU);
				break;
			}
			case "CS":
			case "CurrentSpeed":
				theW.CurrentSpeed = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "ImpactAltitude":
				theW.ImpactAltitude = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "ARM_SEIM":
			case "ARM_SpecifiedEmissionIsMandatory":
				theW.ARM_SpecifiedEmissionIsMandatory = Misc.ParseBool(theNode2.InnerText);
				break;
			case "SBEO_ThrottleSetting":
				switch (theNode2.InnerText)
				{
				case "FullStop":
					theW._ThrottleBefore_EngagedOffensive = Throttle.FullStop;
					break;
				case "Loiter":
					theW._ThrottleBefore_EngagedOffensive = Throttle.Loiter;
					break;
				case "Cruise":
					theW._ThrottleBefore_EngagedOffensive = Throttle.Cruise;
					break;
				case "Full":
					theW._ThrottleBefore_EngagedOffensive = Throttle.Full;
					break;
				case "Flank":
					theW._ThrottleBefore_EngagedOffensive = Throttle.Flank;
					break;
				default:
					theW._ThrottleBefore_EngagedOffensive = (Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				}
				break;
			case "Longitude_UnitEntersAreaCheck":
				theW.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(theNode2.InnerText);
				break;
			case "LaunchSpeed":
				theW.LaunchSpeed = float.Parse(theNode2.InnerText, CultureInfo.InvariantCulture);
				break;
			case "ParentGroup":
				theW._ParentGroup_ID = theNode2.InnerText;
				break;
			case "CH":
			case "CurrentHeading":
				theW.CurrentHeading = XmlConvert.ToSingle(theNode2.InnerText);
				break;
			case "Weapon_Damage":
			{
				ActiveUnit theAU = theW;
				theW.weapon_Damage_0 = Weapon_Damage.FromXML(ref theNode2, ref theDictionary, ref theAU);
				break;
			}
			case "IsAD":
			case "IsAutoDetectable":
				((ActiveUnit)theW).set_IsAutoDetectable((Side)null, Misc.ParseBool(theNode2.InnerText));
				break;
			}
		}
	}

	public override void PostDeserializationHousekeeping_General(ref Scenario theScen, ConcurrentDictionary<string, ScenarioObject> theDictionary, List<ActiveUnit> DiscardList, bool GameIsRunning)
	{
		try
		{
			base.PostDeserializationHousekeeping_General(ref theScen, theDictionary, DiscardList, GameIsRunning);
			if (!Information.IsNothing((object)_DataLinkParent_ID))
			{
				theScen.ActiveUnits.TryGetValue(_DataLinkParent_ID, out activeUnit_1);
			}
			if (!Information.IsNothing((object)_FiringParent_ID))
			{
				theScen.ActiveUnits.TryGetValue(_FiringParent_ID, out activeUnit_0);
			}
			if (!Information.IsNothing((object)_SensorIlluminatingForMe_ObjectID))
			{
				foreach (ActiveUnit value in theScen.ActiveUnits.Values)
				{
					Sensor[] sensors_Cached = value.Sensors_Cached;
					foreach (Sensor sensor in sensors_Cached)
					{
						if (string.CompareOrdinal(sensor.ObjectID, _SensorIlluminatingForMe_ObjectID) == 0)
						{
							sensor_1 = sensor;
							return;
						}
					}
				}
			}
			if (AI.PrimaryTarget != null && AI.PrimaryTarget.ActualUnit == null)
			{
				Contact primaryTarget = AI.PrimaryTarget;
				Side theSide = ((ActiveUnit)this).get_UnitSide(SetSideOnly: false);
				primaryTarget.PostDeserializationHousekeeping(ref theScen, ref theDictionary, ref theSide);
				((ActiveUnit)this).set_UnitSide(SetSideOnly: false, theSide);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100883", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public ObservableList<Sensor> WeaponSensors()
	{
		return _Sensors;
	}

	public override Sensor[] Sensors_ReadOnly()
	{
		return _Sensors.ToArray();
	}

	internal float ArmorPenetrationPercent(GlobalVariables.ArmorRating theArmor, GlobalVariables.TargetVisualSizeClass TargetSize)
	{
		Warhead warhead = Warheads[0];
		if (theArmor == GlobalVariables.ArmorRating.None && Type == _WeaponType.Gun)
		{
			switch (TargetSize)
			{
			case GlobalVariables.TargetVisualSizeClass.Stealthy:
				return 100f;
			case GlobalVariables.TargetVisualSizeClass.Small:
			{
				Warhead.WarheadCaliber caliber2 = warhead.Caliber;
				if ((uint)(caliber2 - 2001) > 1u)
				{
					return 100f;
				}
				break;
			}
			case GlobalVariables.TargetVisualSizeClass.Medium:
			{
				Warhead.WarheadCaliber caliber3 = warhead.Caliber;
				if ((uint)(caliber3 - 2001) > 2u)
				{
					return 100f;
				}
				break;
			}
			case GlobalVariables.TargetVisualSizeClass.Large:
			case GlobalVariables.TargetVisualSizeClass.VLarge:
			{
				Warhead.WarheadCaliber caliber = warhead.Caliber;
				if ((uint)(caliber - 2001) > 3u)
				{
					return 100f;
				}
				break;
			}
			}
		}
		short num = default(short);
		switch (warhead.Type)
		{
		case Warhead.WarheadType.Incendiary:
			num = 0;
			break;
		case Warhead.WarheadType.SuperFrag:
		case Warhead.WarheadType.Fragmentation_ABM:
			switch (theArmor)
			{
			case GlobalVariables.ArmorRating.Armor_Handgun:
				num = 100;
				break;
			case GlobalVariables.ArmorRating.None:
				num = 100;
				break;
			case GlobalVariables.ArmorRating.Armor_HMG:
				num = 80;
				break;
			case GlobalVariables.ArmorRating.Armor_Rifle:
				num = 90;
				break;
			case GlobalVariables.ArmorRating.RHA_25mm:
				num = 60;
				break;
			case GlobalVariables.ArmorRating.RHA_20mm:
				num = 70;
				break;
			case GlobalVariables.ArmorRating.Light:
				num = 30;
				break;
			case GlobalVariables.ArmorRating.Medium:
				return 0f;
			case GlobalVariables.ArmorRating.Heavy:
				return 0f;
			case GlobalVariables.ArmorRating.Special:
				return 0f;
			case GlobalVariables.ArmorRating.RHA_35mm:
				num = 40;
				break;
			case GlobalVariables.ArmorRating.RHA_30mm:
				num = 50;
				break;
			}
			break;
		case Warhead.WarheadType.Weapon:
			return Warheads[0].get_CarriedWeapon(ParentScen).ArmorPenetrationPercent(theArmor, TargetSize);
		case Warhead.WarheadType.Nuclear:
			num = 0;
			break;
		case Warhead.WarheadType.HEAT:
		case Warhead.WarheadType.Torpedo_ASWOptimized:
		case Warhead.WarheadType.Cluster_AT:
			num = theArmor switch
			{
				GlobalVariables.ArmorRating.Medium => 60, 
				GlobalVariables.ArmorRating.Heavy => 35, 
				GlobalVariables.ArmorRating.Special => 15, 
				_ => 100, 
			};
			break;
		case Warhead.WarheadType.Fragmentation:
		case Warhead.WarheadType.ContinuousRod:
		case Warhead.WarheadType.Cluster_AP:
		{
			GlobalVariables.ArmorRating armorRating = theArmor;
			int num2;
			if (armorRating <= GlobalVariables.ArmorRating.Armor_HMG)
			{
				if (armorRating <= GlobalVariables.ArmorRating.Armor_Handgun)
				{
					if (armorRating == GlobalVariables.ArmorRating.None || armorRating == GlobalVariables.ArmorRating.Armor_Handgun)
					{
						num = 100;
						break;
					}
					num2 = 0;
				}
				else
				{
					if (armorRating == GlobalVariables.ArmorRating.Armor_Rifle || armorRating == GlobalVariables.ArmorRating.Armor_HMG)
					{
						num = 90;
						break;
					}
					num2 = 0;
				}
			}
			else if (armorRating <= GlobalVariables.ArmorRating.RHA_25mm)
			{
				if (armorRating == GlobalVariables.ArmorRating.RHA_20mm)
				{
					num = 80;
					break;
				}
				if (armorRating == GlobalVariables.ArmorRating.RHA_25mm)
				{
					num = 70;
					break;
				}
				num2 = 0;
			}
			else
			{
				if (armorRating == GlobalVariables.ArmorRating.RHA_30mm)
				{
					num = 60;
					break;
				}
				if (armorRating == GlobalVariables.ArmorRating.RHA_35mm)
				{
					num = 55;
					break;
				}
				if (armorRating == GlobalVariables.ArmorRating.Light)
				{
					num = 50;
					break;
				}
				num2 = 0;
			}
			num = (short)num2;
			break;
		}
		case Warhead.WarheadType.Laser_COIL:
		case Warhead.WarheadType.Laser_CarbonDioxide:
		case Warhead.WarheadType.Laser_DeuteriumFluoride:
		case Warhead.WarheadType.Laser_SolidStateFiber:
			switch (theArmor)
			{
			case GlobalVariables.ArmorRating.Armor_Handgun:
				num = 80;
				break;
			case GlobalVariables.ArmorRating.None:
				num = 100;
				break;
			case GlobalVariables.ArmorRating.Armor_HMG:
				num = 50;
				break;
			case GlobalVariables.ArmorRating.Armor_Rifle:
				num = 60;
				break;
			case GlobalVariables.ArmorRating.RHA_25mm:
				num = 30;
				break;
			case GlobalVariables.ArmorRating.RHA_20mm:
				num = 40;
				break;
			default:
				return 0f;
			case GlobalVariables.ArmorRating.RHA_35mm:
				num = 10;
				break;
			case GlobalVariables.ArmorRating.RHA_30mm:
				num = 20;
				break;
			}
			break;
		case Warhead.WarheadType.ArmorPiercing:
		case Warhead.WarheadType.SemiAP:
		case Warhead.WarheadType.HardTargetPenetrator:
		case Warhead.WarheadType.LongRodPenetrator:
			switch (warhead.ExplosivesType)
			{
			default:
				switch (theArmor)
				{
				default:
					return 100f;
				case GlobalVariables.ArmorRating.Special:
					num = 50;
					break;
				case GlobalVariables.ArmorRating.Heavy:
					num = 80;
					break;
				}
				break;
			case Warhead.WarheadExplosivesType.KineticEnergy:
				switch (theArmor)
				{
				case GlobalVariables.ArmorRating.Armor_Handgun:
					num = 90;
					break;
				case GlobalVariables.ArmorRating.None:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.Armor_HMG:
					num = 70;
					break;
				case GlobalVariables.ArmorRating.Armor_Rifle:
					num = 80;
					break;
				case GlobalVariables.ArmorRating.RHA_25mm:
					num = 50;
					break;
				case GlobalVariables.ArmorRating.RHA_20mm:
					num = 60;
					break;
				case GlobalVariables.ArmorRating.Light:
					num = 20;
					break;
				case GlobalVariables.ArmorRating.Medium:
					return 0f;
				case GlobalVariables.ArmorRating.Heavy:
					return 0f;
				case GlobalVariables.ArmorRating.Special:
					return 0f;
				case GlobalVariables.ArmorRating.RHA_35mm:
					num = 30;
					break;
				case GlobalVariables.ArmorRating.RHA_30mm:
					num = 40;
					break;
				}
				break;
			case Warhead.WarheadExplosivesType.LongRodPenetrator_LightArmor:
				switch (theArmor)
				{
				case GlobalVariables.ArmorRating.Armor_Handgun:
					num = 85;
					break;
				case GlobalVariables.ArmorRating.None:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.Armor_HMG:
					num = 75;
					break;
				case GlobalVariables.ArmorRating.Armor_Rifle:
					num = 80;
					break;
				case GlobalVariables.ArmorRating.RHA_25mm:
					num = 65;
					break;
				case GlobalVariables.ArmorRating.RHA_20mm:
					num = 70;
					break;
				case GlobalVariables.ArmorRating.Light:
					num = 50;
					break;
				case GlobalVariables.ArmorRating.Medium:
					num = 20;
					break;
				case GlobalVariables.ArmorRating.Heavy:
					return 0f;
				case GlobalVariables.ArmorRating.Special:
					return 0f;
				case GlobalVariables.ArmorRating.RHA_35mm:
					num = 55;
					break;
				case GlobalVariables.ArmorRating.RHA_30mm:
					num = 60;
					break;
				}
				break;
			case Warhead.WarheadExplosivesType.LongRodPenetrator_MediumArmor:
				switch (theArmor)
				{
				case GlobalVariables.ArmorRating.Armor_Handgun:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.None:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.Armor_HMG:
					num = 95;
					break;
				case GlobalVariables.ArmorRating.Armor_Rifle:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.RHA_25mm:
					num = 85;
					break;
				case GlobalVariables.ArmorRating.RHA_20mm:
					num = 90;
					break;
				case GlobalVariables.ArmorRating.Light:
					num = 70;
					break;
				case GlobalVariables.ArmorRating.Medium:
					num = 50;
					break;
				case GlobalVariables.ArmorRating.Heavy:
					num = 20;
					break;
				case GlobalVariables.ArmorRating.Special:
					return 0f;
				case GlobalVariables.ArmorRating.RHA_35mm:
					num = 75;
					break;
				case GlobalVariables.ArmorRating.RHA_30mm:
					num = 80;
					break;
				}
				break;
			case Warhead.WarheadExplosivesType.LongRodPenetrator_HeavyArmor:
				switch (theArmor)
				{
				case GlobalVariables.ArmorRating.Armor_Handgun:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.None:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.Armor_HMG:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.Armor_Rifle:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.RHA_25mm:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.RHA_20mm:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.Light:
					num = 85;
					break;
				case GlobalVariables.ArmorRating.Medium:
					num = 80;
					break;
				case GlobalVariables.ArmorRating.Heavy:
					num = 50;
					break;
				case GlobalVariables.ArmorRating.Special:
					num = 20;
					break;
				case GlobalVariables.ArmorRating.RHA_35mm:
					num = 90;
					break;
				case GlobalVariables.ArmorRating.RHA_30mm:
					num = 95;
					break;
				}
				break;
			case Warhead.WarheadExplosivesType.LongRodPenetrator_SpecialArmor:
				switch (theArmor)
				{
				default:
					return 100f;
				case GlobalVariables.ArmorRating.Special:
					num = 50;
					break;
				case GlobalVariables.ArmorRating.Heavy:
					num = 80;
					break;
				}
				break;
			}
			break;
		case Warhead.WarheadType.HE_BlastFrag:
		case Warhead.WarheadType.Torpedo:
		case Warhead.WarheadType.DepthCharge:
		case Warhead.WarheadType.Cluster_SmartSubs:
			num = theArmor switch
			{
				GlobalVariables.ArmorRating.Light => 90, 
				GlobalVariables.ArmorRating.Medium => 40, 
				GlobalVariables.ArmorRating.Heavy => 20, 
				GlobalVariables.ArmorRating.Special => 5, 
				_ => 100, 
			};
			break;
		}
		int num3 = GameGeneral.GlobalRNG.Next(num - 15, num + 16);
		if (num3 > 100)
		{
			return 100f;
		}
		if (num3 < 0)
		{
			return 0f;
		}
		return num3;
	}

	public void GetBoresightLimit(ActiveUnit FiringPlatform, Contact Target, ref float BoresightLimit, ref bool bool_5)
	{
		BoresightLimit = 0f;
		bool_5 = false;
		switch (Type)
		{
		case _WeaponType.Torpedo:
			BoresightLimit = 90f;
			break;
		case _WeaponType.DepthCharge:
			BoresightLimit = 20f;
			break;
		case _WeaponType.Sonobuoy:
			BoresightLimit = 4f;
			break;
		case _WeaponType.GuidedWeapon:
			BoresightLimit = 40f;
			if (IsLongFlightCruiseMissile)
			{
				BoresightLimit = 180f;
			}
			if (Flags.HOB_AAM)
			{
				BoresightLimit += 20f;
			}
			if (FiringPlatform.IsAircraft && ((Aircraft)FiringPlatform).HasHelmetMountedSight)
			{
				BoresightLimit += 30f;
			}
			if (FiringPlatform.IsAircraft)
			{
				bool_5 = true;
			}
			if (Target.IsSubmergedContact)
			{
				BoresightLimit = 90f;
			}
			break;
		case _WeaponType.Rocket:
			BoresightLimit = 30f;
			break;
		case _WeaponType.IronBomb:
		case _WeaponType.BottomMine:
		case _WeaponType.MooredMine:
		case _WeaponType.FloatingMine:
		case _WeaponType.MovingMine:
		case _WeaponType.RisingMine:
		case _WeaponType.DriftingMine:
		case _WeaponType.DummyMine:
			BoresightLimit = 30f;
			break;
		case _WeaponType.Gun:
			BoresightLimit = 8f;
			if (FiringPlatform.IsAircraft)
			{
				bool_5 = true;
			}
			break;
		default:
			BoresightLimit = 20f;
			break;
		case _WeaponType.Decoy_Vehicle:
		case _WeaponType.UAV_Expendable:
			BoresightLimit = 135f;
			break;
		}
		if (FiringPlatform.IsAircraft && (Target.isSurfaceOrLandContact | Target.IsSubmergedContact))
		{
			if (Guidance == WeaponGuidanceType.Inertial || Is_LOAL_capable)
			{
				bool_5 = false;
			}
			WeaponGuidanceType guidance = Guidance;
			if (guidance == WeaponGuidanceType.SemiActive || (uint)(guidance - 14) <= 1u)
			{
				bool_5 = false;
			}
		}
	}

	public bool IsMortarRound()
	{
		return Name.ToLower().Contains("mortar");
	}

	[SpecialName]
	private float method_21(Contact_Base.ContactType theTargetType)
	{
		switch (theTargetType)
		{
		case Contact_Base.ContactType.Air:
		case Contact_Base.ContactType.Missile:
		case Contact_Base.ContactType.Orbital:
			return MaxAirRange;
		case Contact_Base.ContactType.Submarine:
		case Contact_Base.ContactType.Torpedo:
			return MaxSubsurfaceRange;
		case Contact_Base.ContactType.Decoy_Air:
			return MaxAirRange;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new NotImplementedException();
		case Contact_Base.ContactType.Surface:
		case Contact_Base.ContactType.UndeterminedNaval:
		case Contact_Base.ContactType.Mine:
		case Contact_Base.ContactType.ActivationPoint:
			return MaxSurfaceRange;
		case Contact_Base.ContactType.Aimpoint:
		case Contact_Base.ContactType.Facility_Fixed:
		case Contact_Base.ContactType.Facility_Mobile:
		case Contact_Base.ContactType.AggregateGroundUnit:
			return MaxLandRange;
		}
	}

	private bool method_22()
	{
		if (Warheads.Length == 0)
		{
			return false;
		}
		if (!Warheads[0].get_IsNuclear(ParentScen))
		{
			return false;
		}
		return true;
	}

	internal bool IsBVR()
	{
		return MaxAirRange > 15f;
	}

	internal bool IsWVR()
	{
		if (Type != _WeaponType.GuidedWeapon)
		{
			return false;
		}
		return MaxAirRange <= 15f;
	}

	public static bool IsStandOff(Scenario TheScen, float range)
	{
		return new Weapon(TheScen)
		{
			MaxSurfaceRange = range,
			MaxLandRange = range,
			MaxSubsurfaceRange = range
		}.IsStandOff();
	}

	internal bool IsStandOff()
	{
		return Math.Max(MaxSurfaceRange, Math.Max(MaxLandRange, MaxSubsurfaceRange)) >= StandOffMaxRange;
	}

	internal bool IsUnpoweredAirWeapon()
	{
		int result;
		if (IsGuidedWeapon())
		{
			if (Propulsion.Count == 1)
			{
				return Propulsion[0].Type == Engine.EngineType.WeaponCoast;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	internal bool IsAerialASWGuidedWeapon()
	{
		if (ValidTargets.Submarine)
		{
			_WeaponType type = Type;
			if (type == _WeaponType.GuidedWeapon)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public override bool IsOperating()
	{
		return !IsMorituri;
	}

	public void DeployLoiterParachute()
	{
		ThrottleSetting = Throttle.FullStop;
		CurrentSpeed = 97.192f;
		Attitude_Pitch = -85f;
		DesiredPitch = -85f;
		DesiredSpeed = CurrentSpeed;
	}

	public void ReleaseFromLoiterParachute()
	{
		ThrottleSetting = Throttle.Cruise;
		CurrentSpeed = Kinematics.StallSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
	}

	public static void RecalculateWeaponFlightEnergyIfNecessary(Weapon theWeapon, Scenario theScen, bool AssumeAirLaunch, float? AssumedAirLaunchSpeed, Action<string> theLogger = null)
	{
		try
		{
			if (theWeapon.UsesBoostCoastModel.Value)
			{
				if (!theScen.Cache_BurnTimesForBoostCoastWeapons.TryGetValue(theWeapon.DBID, out (int, int) value))
				{
					value = DBValidation.CalculateWeaponBurnTime(theWeapon.DBID, theScen, AssumeAirLaunch);
					theScen.Cache_BurnTimesForBoostCoastWeapons.TryAdd(theWeapon.DBID, value);
					theWeapon.TotalBurnTime = value.Item1;
					theWeapon.FlightEndurance = value.Item2;
				}
				else
				{
					theWeapon.TotalBurnTime = value.Item1;
					theWeapon.FlightEndurance = value.Item2;
				}
				if (AssumeAirLaunch && AssumedAirLaunchSpeed.HasValue && theScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.VariableBurnoutSpeed) && !theWeapon._LaunchSpeedDependentBurnoutSpeedsSet)
				{
					theWeapon.Kinematics.AdjustLaunchSpeedDependentBurnoutSpeedPerBand_ALTERNATE(theWeapon.TotalBurnTime, (int)Math.Round(AssumedAirLaunchSpeed.Value));
				}
			}
			else if (theWeapon.SupportsAttitude_Pitch && theWeapon.Type == _WeaponType.GuidedWeapon && (!theWeapon.IsBallisticMissile || !theWeapon.HasRVs.Value) && !theScen.FeatureCompatibility.get_GuidedWeaponsPitchAttitude(theScen.DBConnection))
			{
				int num;
				if (theScen.Cache_FuelForPitchEnabledWeapons.ContainsKey(theWeapon.DBID))
				{
					num = theScen.Cache_FuelForPitchEnabledWeapons[theWeapon.DBID];
				}
				else
				{
					num = DBValidation.CalculateWeaponFuel(theWeapon.DBID, theScen, AssumeAirLaunch);
					theScen.Cache_FuelForPitchEnabledWeapons.TryAdd(theWeapon.DBID, num);
				}
				if (theWeapon.Fuel_ReadOnly.Count > 0 && (float)num > theWeapon.Fuel_ReadOnly[0].CurrentQuantity)
				{
					theWeapon.Fuel_ReadOnly[0].CurrentQuantity = num;
					theWeapon.Fuel_ReadOnly[0].MaxQuantity = num;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 982223654768635", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Weapon GetNewWeapon(ref Scenario theScen, int int_9, bool bool_5, string theGUID = null)
	{
		Weapon result;
		try
		{
			if (!(int_9 == 0 || int_9 == -1))
			{
				Weapon weapon = DBFunctions.GetWeaponType(int_9, theScen) switch
				{
					_WeaponType.GuidedProjectile => new GuidedProjectile(ref theScen), 
					_WeaponType.Rocket => new UnguidedRocket(ref theScen), 
					_WeaponType.HGV => new HGV(ref theScen), 
					_WeaponType.BallisticMissile => new BallisticMissile(theScen), 
					_WeaponType.Torpedo => new Torpedo(ref theScen), 
					_ => new Weapon(theScen), 
				};
				weapon.ParentScen = theScen;
				weapon.IsWeapon = true;
				weapon.IsDLZconstruct = bool_5;
				DBFunctions.GetWeapon(theScen.DBConnection, weapon, int_9, theScen);
				if (weapon.DBID == -1)
				{
					result = null;
				}
				else
				{
					if (weapon.IsHGV && weapon.CruiseAltitude_ASL > 100000f)
					{
						weapon.CruiseAltitude_ASL = 100000f;
					}
					if (weapon.Type == _WeaponType.RV)
					{
						weapon.MinSurfaceRange = 1f;
					}
					if (weapon.Type == _WeaponType.Sonobuoy && weapon._Sensors.Count > 0 && weapon._Sensors[0].HasActiveModeOnly)
					{
						weapon._Sensors[0].GoActive(RaiseEvents: false);
					}
					if (weapon.IsBallisticMissile && weapon.IsNuke.Value)
					{
						weapon.ValidSpecialModes.Add(WeaponSpecialMode.HighAltitudeDetonation);
					}
					if (!string.IsNullOrEmpty(theGUID))
					{
						weapon.ObjectID_Set(theGUID);
					}
					else
					{
						weapon.ObjectID_Set(IDGenerator.Instance.Next.ToLower());
					}
					result = weapon;
				}
			}
			else
			{
				result = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ex2?.Data.Add("Error at 100902", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Weapon(Scenario theScen, string string_4 = null)
		: base(theScen, null)
	{
		ReportedDatalinkLostConnectionIssue = false;
		nullable_16 = null;
		nullable_17 = null;
		nullable_18 = null;
		IsFuelTank = false;
		IsWeaponPallet = false;
		IsTrainingRound = false;
		IsHGV = false;
		IsReEntryVehicle = false;
		Warheads = new Warhead[0];
		Directors = new List<int>();
		Flags = default(WeaponFlags);
		weaponGuidanceType_0 = WeaponGuidanceType.Undetermined;
		WeaponWeapons = new ObservableList<WeaponRec>();
		ValidSpecialModes = new List<WeaponSpecialMode>();
		IsMIRVedMissile = new Lazy<bool>(method_24);
		IsMRVedMissile = new Lazy<bool>(method_25);
		UsesBoostCoastModel = new Lazy<bool>(method_19);
		IsNuke = new Lazy<bool>(method_22);
		ActiveUnit theUnit = this;
		_Navigator = new Weapon_Navigator(ref theUnit);
		weapon_AI_0 = new Weapon_AI(this);
		DetonationOccurs = false;
		check = 0.0;
		_LaunchSpeedDependentBurnoutSpeedsSet = false;
		CachedGuidance = null;
		HasRVs = new Lazy<bool>(method_43);
		if (string.IsNullOrEmpty(string_4))
		{
			ObjectID_Set(IDGenerator.Instance.Next.ToLower());
		}
		IsWeapon = true;
		UnitType = GlobalVariables.ActiveUnitType.Weapon;
		EvaluateIfDumb();
	}

	public static bool WeaponIsNonRivalrous(int int_9, ref Scenario theScen)
	{
		if (!theScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LimitedSonobuoysInMagazines))
		{
			return WeaponIsFuelTank(int_9, ref theScen) || WeaponIsSonobuoy(int_9, ref theScen) || WeaponIsGunPodAmmo(int_9, ref theScen) || WeaponIsCargo(int_9, ref theScen);
		}
		return WeaponIsFuelTank(int_9, ref theScen) || WeaponIsGunPodAmmo(int_9, ref theScen) || WeaponIsCargo(int_9, ref theScen);
	}

	public static bool WeaponIsFuelTank(int int_9, ref Scenario theScen)
	{
		SQLiteConnection sqliteConnection_ = theScen.DBConnection;
		_WeaponType weaponType = DBFunctions.GetWeaponType(int_9, ref sqliteConnection_);
		if (weaponType != _WeaponType.DropTank)
		{
			return weaponType == _WeaponType.FerryTank;
		}
		return true;
	}

	public static bool WeaponIsCargo(int int_9, ref Scenario theScen)
	{
		SQLiteConnection sqliteConnection_ = theScen.DBConnection;
		_WeaponType weaponType = DBFunctions.GetWeaponType(int_9, ref sqliteConnection_);
		if (weaponType != _WeaponType.Cargo && weaponType != _WeaponType.Paratroops)
		{
			return weaponType == _WeaponType.Troops;
		}
		return true;
	}

	public static bool WeaponIsSonobuoy(int int_9, ref Scenario theScen)
	{
		SQLiteConnection sqliteConnection_ = theScen.DBConnection;
		return DBFunctions.GetWeaponType(int_9, ref sqliteConnection_) == _WeaponType.Sonobuoy;
	}

	public static bool WeaponIsGunPodAmmo(int int_9, ref Scenario theScen)
	{
		SQLiteConnection sqliteConnection_ = theScen.DBConnection;
		return DBFunctions.GetWeaponType(int_9, ref sqliteConnection_) == _WeaponType.Gun;
	}

	private int method_23(Side side_0, Contact contact_0, int int_9)
	{
		int result;
		try
		{
			if (side_0 != null)
			{
				List<ActiveUnit> source;
				lock (side_0.Units)
				{
					source = new List<ActiveUnit>(side_0.Units);
				}
				result = (from theAU in source
					select (theAU) into theW
					where theW.IsWeapon
					select (theW) into theW
					where theW.AI.PrimaryTarget == contact_0 && ((Weapon)theW).ARM_SpecifiedEMission.Key == int_9
					select theW).Count();
			}
			else
			{
				result = 0;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100903", "");
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
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float[] GetCombatPowerMatrix()
	{
		float[] array = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
		float[] array2 = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
		Warhead[] warheads = Warheads;
		for (int i = 0; i < warheads.Length; i = checked(i + 1))
		{
			warheads[i].GetCombatPower(array2);
			int num = array.Length - 1;
			for (int j = 0; j <= num; j++)
			{
				array[j] += array2[j];
			}
		}
		return array;
	}

	public bool ARM_DetermineEmissionToTrack(TObservableDictionary<int, EmissionContainer> TargetEmissions, Side theSide, Contact theTarget, bool ShootAtTurnedOffRadar, ref Random theRNG)
	{
		_Closure$__402-0 arg = default(_Closure$__402-0);
		_Closure$__402-0 CS$<>8__locals19 = new _Closure$__402-0(arg);
		CS$<>8__locals19.$VB$Me = this;
		CS$<>8__locals19.$VB$Local_theSide = theSide;
		CS$<>8__locals19.$VB$Local_theTarget = theTarget;
		int count = TargetEmissions.Count;
		bool result;
		try
		{
			float num = (ShootAtTurnedOffRadar ? 36000f : 20f);
			List<int> list = new List<int>();
			int num2 = count - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3;
				EmissionContainer emissionContainer;
				try
				{
					num3 = TargetEmissions.Keys.ElementAtOrDefault(i);
					emissionContainer = TargetEmissions[num3];
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
					continue;
				}
				if (!(emissionContainer.Age <= num) && !CS$<>8__locals19.$VB$Local_theTarget.IsAutoDetection)
				{
					continue;
				}
				if (!emissionContainer.IsIllumination)
				{
					int num4 = num3;
					SQLiteConnection sqliteConnection_ = ParentScen.DBConnection;
					if (!DBFunctions.GetSensor(num4, ref sqliteConnection_).IsPureIlluminator)
					{
						continue;
					}
				}
				list.Add(num3);
			}
			if (list.Count > 0)
			{
				foreach (int item in list)
				{
					if (method_23(CS$<>8__locals19.$VB$Local_theSide, CS$<>8__locals19.$VB$Local_theTarget, item) != 0)
					{
						continue;
					}
					ARM_SpecifiedEMission = new KeyValuePair<int, EmissionContainer>(item, TargetEmissions[item]);
					result = true;
					goto end_IL_0023;
				}
			}
			List<int> list2 = new List<int>();
			int num5 = count - 1;
			for (int j = 0; j <= num5; j++)
			{
				int num3;
				EmissionContainer emissionContainer;
				try
				{
					num3 = TargetEmissions.Keys.ElementAtOrDefault(j);
					emissionContainer = TargetEmissions[num3];
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
					continue;
				}
				if (emissionContainer.Age <= num || CS$<>8__locals19.$VB$Local_theTarget.IsAutoDetection)
				{
					int num6 = num3;
					SQLiteConnection sqliteConnection_ = ParentScen.DBConnection;
					if (DBFunctions.GetSensor(num6, ref sqliteConnection_).IsGroundBasedFireControlRadar)
					{
						list2.Add(num3);
					}
				}
			}
			if (list2.Count > 0)
			{
				foreach (int item2 in list2)
				{
					if (method_23(CS$<>8__locals19.$VB$Local_theSide, CS$<>8__locals19.$VB$Local_theTarget, item2) != 0)
					{
						continue;
					}
					ARM_SpecifiedEMission = new KeyValuePair<int, EmissionContainer>(item2, TargetEmissions[item2]);
					result = true;
					goto end_IL_0023;
				}
			}
			List<int> list3 = new List<int>();
			int num7 = count - 1;
			for (int k = 0; k <= num7; k++)
			{
				int num3;
				EmissionContainer emissionContainer;
				try
				{
					num3 = TargetEmissions.Keys.ElementAtOrDefault(k);
					emissionContainer = TargetEmissions[num3];
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					ProjectData.ClearProjectError();
					continue;
				}
				if (emissionContainer.Age <= num || CS$<>8__locals19.$VB$Local_theTarget.IsAutoDetection)
				{
					int num8 = num3;
					SQLiteConnection sqliteConnection_ = ParentScen.DBConnection;
					if (DBFunctions.GetSensor(num8, ref sqliteConnection_).IsGroundBasedAirSearchRadar)
					{
						list3.Add(num3);
					}
				}
			}
			if (list3.Count > 0)
			{
				foreach (int item3 in list3)
				{
					if (method_23(CS$<>8__locals19.$VB$Local_theSide, CS$<>8__locals19.$VB$Local_theTarget, item3) != 0)
					{
						continue;
					}
					ARM_SpecifiedEMission = new KeyValuePair<int, EmissionContainer>(item3, TargetEmissions[item3]);
					result = true;
					goto end_IL_0023;
				}
			}
			if (Flags.HomeOnJam)
			{
				List<int> list4 = new List<int>();
				int num9 = count - 1;
				for (int l = 0; l <= num9; l++)
				{
					int num3;
					EmissionContainer emissionContainer;
					try
					{
						num3 = TargetEmissions.Keys.ElementAtOrDefault(l);
						emissionContainer = TargetEmissions[num3];
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						ProjectData.ClearProjectError();
						continue;
					}
					if (emissionContainer.Age <= num || CS$<>8__locals19.$VB$Local_theTarget.IsAutoDetection)
					{
						int num10 = num3;
						SQLiteConnection sqliteConnection_ = ParentScen.DBConnection;
						Sensor sensor = DBFunctions.GetSensor(num10, ref sqliteConnection_);
						if (sensor.IsGroundBasedOECM || sensor.IsGNSSJammer)
						{
							list4.Add(num3);
						}
					}
				}
				if (list4.Count > 0)
				{
					foreach (int item4 in list4)
					{
						if (method_23(CS$<>8__locals19.$VB$Local_theSide, CS$<>8__locals19.$VB$Local_theTarget, item4) != 0)
						{
							continue;
						}
						ARM_SpecifiedEMission = new KeyValuePair<int, EmissionContainer>(item4, TargetEmissions[item4]);
						result = true;
						goto end_IL_0023;
					}
				}
			}
			List<int> list5 = new List<int>();
			int num11 = count - 1;
			for (int m = 0; m <= num11; m++)
			{
				int num3;
				EmissionContainer emissionContainer;
				try
				{
					num3 = TargetEmissions.Keys.ElementAtOrDefault(m);
					emissionContainer = TargetEmissions[num3];
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					ProjectData.ClearProjectError();
					continue;
				}
				if (!(emissionContainer.Age <= num) && !CS$<>8__locals19.$VB$Local_theTarget.IsAutoDetection)
				{
					continue;
				}
				if (!TargetEmissions[num3].IsIllumination)
				{
					int num12 = num3;
					SQLiteConnection sqliteConnection_ = ParentScen.DBConnection;
					Sensor sensor2 = DBFunctions.GetSensor(num12, ref sqliteConnection_);
					if (!sensor2.IsGroundBasedAirSearchRadar && !sensor2.IsGroundBasedFireControlRadar && !sensor2.IsPureIlluminator)
					{
						if (Flags.HomeOnJam && sensor2.IsGroundBasedOECM)
						{
							list5.Add(num3);
						}
						else if (sensor2.Capabilities.SurfaceSearch || sensor2.Capabilities.MissileApproachWarning || sensor2.Capabilities.SpaceSearch_ABM)
						{
							list5.Add(num3);
						}
					}
					else
					{
						list5.Add(num3);
					}
				}
				else
				{
					list5.Add(num3);
				}
			}
			if (list5.Count > 0)
			{
				IEnumerable<int> source = list5.OrderBy([SpecialName] (int theCandidateKey) => CS$<>8__locals19.$VB$Me.method_23(CS$<>8__locals19.$VB$Local_theSide, CS$<>8__locals19.$VB$Local_theTarget, theCandidateKey));
				ARM_SpecifiedEMission = new KeyValuePair<int, EmissionContainer>(source.ElementAtOrDefault(0), TargetEmissions[source.ElementAtOrDefault(0)]);
				result = true;
			}
			else
			{
				result = false;
			}
			end_IL_0023:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100904", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num13;
			if (!Debugger.IsAttached)
			{
				num13 = 0;
			}
			else
			{
				Debugger.Break();
				num13 = 0;
			}
			result = (byte)num13 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void DoTypeSpecificActions(float elapsedTime, ref LockRandom theRNG)
	{
		if (Weaponry == null)
		{
			return;
		}
		try
		{
			if (Type == _WeaponType.Sonobuoy || IsMorituri || IsBeingDestroyed)
			{
				return;
			}
			TimeToReseek -= elapsedTime;
			if (TimeToReseek > 0f)
			{
				return;
			}
			if (TimeToReseek < 0f)
			{
				TimeToReseek = 0f;
			}
			switch (Guidance)
			{
			case WeaponGuidanceType.SemiActive:
				try
				{
					method_35(elapsedTime);
				}
				catch (Exception ex27)
				{
					ProjectData.SetProjectError(ex27);
					Exception ex28 = ex27;
					ex28?.Data.Add("Error at 100908", "");
					GameGeneral.WriteExceptionsToLog(ex28);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.Inertial_Plus_SemiActive:
				try
				{
					method_36(elapsedTime);
				}
				catch (Exception ex29)
				{
					ProjectData.SetProjectError(ex29);
					Exception ex30 = ex29;
					ex30?.Data.Add("Error at 100922", "");
					GameGeneral.WriteExceptionsToLog(ex30);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.Datalink_Plus_SemiActive:
				try
				{
					WeaponLogic_DatalinkedWeapons(elapsedTime);
					method_37(elapsedTime);
				}
				catch (Exception ex25)
				{
					ProjectData.SetProjectError(ex25);
					Exception ex26 = ex25;
					ex26?.Data.Add("Error at 100917", "");
					GameGeneral.WriteExceptionsToLog(ex26);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.Passive:
				try
				{
					if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() && GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: false, DropPlottedCourse: true, elapsedTime))
					{
						return;
					}
				}
				catch (Exception ex19)
				{
					ProjectData.SetProjectError(ex19);
					Exception ex20 = ex19;
					ex20?.Data.Add("Error at 100914", "");
					GameGeneral.WriteExceptionsToLog(ex20);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.Inertial_Plus_Passive:
				try
				{
					if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon())
					{
						if (GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: false, DropPlottedCourse: false, elapsedTime))
						{
							return;
						}
						HandleReachingActivationPoint();
					}
				}
				catch (Exception ex21)
				{
					ProjectData.SetProjectError(ex21);
					Exception ex22 = ex21;
					ex22?.Data.Add("Error at 100921", "");
					GameGeneral.WriteExceptionsToLog(ex22);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.DataLink_Plus_Passive:
				try
				{
					WeaponLogic_DatalinkedWeapons(elapsedTime);
					HandleReachingActivationPoint();
				}
				catch (Exception ex17)
				{
					ProjectData.SetProjectError(ex17);
					Exception ex18 = ex17;
					ex18?.Data.Add("Error at 100916", "");
					GameGeneral.WriteExceptionsToLog(ex18);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.Active:
				try
				{
					if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() && GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: false, DropPlottedCourse: true, elapsedTime))
					{
						return;
					}
					if (!Navigator.Has_NonPathfind_NonFP_PlottedCourse())
					{
						foreach (Sensor sensor2 in _Sensors)
						{
							if (sensor2.CanBeActive && !sensor2.IsActive())
							{
								sensor2.GoActive();
							}
						}
					}
					else
					{
						HandleReachingActivationPoint();
					}
				}
				catch (Exception ex23)
				{
					ProjectData.SetProjectError(ex23);
					Exception ex24 = ex23;
					ex24?.Data.Add("Error at 100913", "");
					GameGeneral.WriteExceptionsToLog(ex24);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.Datalink_Plus_Active:
				try
				{
					if (_Sensors.Count > 0 && _Sensors[0].IsActive())
					{
						float overShootDegrees = 60f;
						if (AI.PrimaryTarget != null && AI.PrimaryTarget.IsBallisticTarget())
						{
							overShootDegrees = method_32();
						}
						else if (isLoiterCapable)
						{
							overShootDegrees = 180f;
						}
						if (GuidanceLogic_DatalinkParentNotAvailable(elapsedTime))
						{
							if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() && GuidanceLogic_Overshoot(overShootDegrees, DropPrimaryTarget: true, DropDatalinkConnection: false, DropPlottedCourse: true, elapsedTime))
							{
								return;
							}
						}
						else if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_DatalinkedWeapon(elapsedTime) && GuidanceLogic_Overshoot(overShootDegrees, DropPrimaryTarget: true, DropDatalinkConnection: true, DropPlottedCourse: true, elapsedTime))
						{
							return;
						}
					}
					else
					{
						WeaponLogic_DatalinkedWeapons(elapsedTime);
					}
					HandleReachingActivationPoint();
				}
				catch (Exception ex15)
				{
					ProjectData.SetProjectError(ex15);
					Exception ex16 = ex15;
					ex16?.Data.Add("Error at 100915", "");
					GameGeneral.WriteExceptionsToLog(ex16);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.Inertial_Plus_Active:
				try
				{
					if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon())
					{
						if (GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: false, DropPlottedCourse: false, elapsedTime))
						{
							return;
						}
						if (_Sensors.Count > 0 && !_Sensors[0].IsActive())
						{
							HandleReachingActivationPoint();
						}
					}
				}
				catch (Exception ex11)
				{
					ProjectData.SetProjectError(ex11);
					Exception ex12 = ex11;
					ex12?.Data.Add("Error at 100920", "");
					GameGeneral.WriteExceptionsToLog(ex12);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.CommandGuided_Datalinked:
				try
				{
					WeaponLogic_DatalinkedWeapons(elapsedTime);
				}
				catch (Exception ex13)
				{
					ProjectData.SetProjectError(ex13);
					Exception ex14 = ex13;
					ex14?.Data.Add("Error at 100919", "");
					GameGeneral.WriteExceptionsToLog(ex14);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.TVM:
				try
				{
					method_33(elapsedTime);
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception ex10 = ex9;
					ex10?.Data.Add("Error at 100918", "");
					GameGeneral.WriteExceptionsToLog(ex10);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.BeamRiding:
				try
				{
					if (method_29(elapsedTime))
					{
						return;
					}
					Sensor sensorProvidingFireControlForMe2 = SensorProvidingFireControlForMe;
					if (Information.IsNothing((object)sensorProvidingFireControlForMe2))
					{
						AI.PrimaryTarget = null;
						AddMessage("Weapon: " + Name + " no longer receives guidance signals.", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
						return;
					}
					if (sensorProvidingFireControlForMe2.TargetsTrackedForFireControl_Readonly.Contains(AI.PrimaryTarget))
					{
						if (!sensorProvidingFireControlForMe2.IsActive())
						{
							AI.PrimaryTarget = null;
							AddMessage("Weapon: " + Name + " no longer receives guidance signals.", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
							return;
						}
						if (myTargetDoesNotExist() && !Information.IsNothing((object)sensorProvidingFireControlForMe2))
						{
							AttemptRetargeting_Beamrider(elapsedTime);
							return;
						}
						if (myTargetDoesNotExist())
						{
							BlindTime += elapsedTime;
							return;
						}
						BlindTime = 0f;
						AI.PrimaryTarget.Age = 0f;
						break;
					}
					AI.PrimaryTarget = null;
					AddMessage("Weapon: " + Name + " no longer receives guidance signals.", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
					return;
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at 100912", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.Inertial:
				if (ParentScen.SecondIsChangingOnThisPulse && UsesGNSSTerminalGuidance())
				{
					if (RecentPNTChecks == null)
					{
						RecentPNTChecks = new FixedSizeQueue<bool>(50);
					}
					if (!IsUnderGNSSDenialThisPulse)
					{
						Scenario.enumTimeCompression timeCompression = ParentScen.TimeCompression;
						if (timeCompression == Scenario.enumTimeCompression.Coarse_FiveSecSlice)
						{
							short num = 1;
							do
							{
								RecentPNTChecks.Enqueue(item: true);
								num++;
							}
							while (num <= 5);
						}
						else
						{
							RecentPNTChecks.Enqueue(item: true);
						}
					}
					else
					{
						Scenario.enumTimeCompression timeCompression2 = ParentScen.TimeCompression;
						if (timeCompression2 == Scenario.enumTimeCompression.Coarse_FiveSecSlice)
						{
							short num2 = 1;
							do
							{
								RecentPNTChecks.Enqueue(item: false);
								num2++;
							}
							while (num2 <= 5);
						}
						else
						{
							RecentPNTChecks.Enqueue(item: false);
						}
					}
				}
				method_30();
				break;
			case WeaponGuidanceType.SemiActive_Plus_Active:
				try
				{
					if (_Sensors.Count > 0 && _Sensors[0].IsActive())
					{
						if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() && GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: true, DropPlottedCourse: true, elapsedTime))
						{
							return;
						}
						break;
					}
					if ((double)Module_Unit.RangeToUnit_Slant(this, AI.PrimaryTarget) <= (double)_Sensors[0].maxRange * 0.8)
					{
						GoAutonomous(clearPrimaryTarget: false, clearDatalink: true, clearPlottedCourse: true);
						break;
					}
					if (BlindTime > 5f)
					{
						GoAutonomous(clearPrimaryTarget: false, clearDatalink: true, clearPlottedCourse: true);
						break;
					}
					if (method_29(elapsedTime))
					{
						return;
					}
					Sensor sensorProvidingFireControlForMe = SensorProvidingFireControlForMe;
					if (!Information.IsNothing((object)sensorProvidingFireControlForMe))
					{
						if (sensorProvidingFireControlForMe.TargetsTrackedForFireControl_Readonly.Contains(AI.PrimaryTarget))
						{
							if (sensorProvidingFireControlForMe.IsActive() || AttemptBuddyIllumination())
							{
								goto IL_0974;
							}
							BlindTime += elapsedTime;
						}
						else
						{
							if (AttemptBuddyIllumination())
							{
								goto IL_0974;
							}
							BlindTime += elapsedTime;
						}
					}
					else
					{
						if (AttemptBuddyIllumination())
						{
							goto IL_0974;
						}
						BlindTime += elapsedTime;
					}
					break;
					IL_0974:
					if (BlindTime > 0f)
					{
						BlindTime = 0f;
					}
					if (method_31(90f) || GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: true, DropPlottedCourse: true, elapsedTime))
					{
						return;
					}
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ex6?.Data.Add("Error at 100909", "");
					GameGeneral.WriteExceptionsToLog(ex6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
				try
				{
					if (_Sensors.Count > 0 && _Sensors[0].IsActive())
					{
						if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() && GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: true, DropPlottedCourse: true, elapsedTime))
						{
							return;
						}
						break;
					}
					if ((double)Module_Unit.RangeToUnit_Slant(this, AI.PrimaryTarget) <= (double)_Sensors[0].maxRange * 0.8)
					{
						GoAutonomous(clearPrimaryTarget: false, clearDatalink: true, clearPlottedCourse: true);
						break;
					}
					if (BlindTime > 5f)
					{
						GoAutonomous(clearPrimaryTarget: false, clearDatalink: true, clearPlottedCourse: true);
						break;
					}
					if (method_29(elapsedTime))
					{
						return;
					}
					bool flag = default(bool);
					if (!Information.IsNothing((object)DataLinkParent))
					{
						try
						{
							List<ActiveUnit> list = null;
							LOSCheckResult? LOS_Exists_Visual = null;
							bool? LOS_Exists_Radar = null;
							bool? LOS_Exists_RadarSW = null;
							bool? LOS_Exists_Sonar = null;
							bool? LOS_Exists_ESM = null;
							bool? LOS_Exists_ESM_SW = null;
							Sensor[] sensors_Cached = DataLinkParent.Sensors_Cached;
							Dictionary<int, EmissionContainer> DetectedEmissions = default(Dictionary<int, EmissionContainer>);
							foreach (Sensor sensor in sensors_Cached)
							{
								if (sensor.IsActive())
								{
									if (sensor.Type == Sensor.Sensor_Type.Radar && list == null)
									{
										list = DataLinkParent.Sensory.get_JammerUnitsAffectingMe(FactorHavingActiveRadars: false);
									}
									ActiveUnit dataLinkParent = DataLinkParent;
									ActiveUnit actualUnit = AI.PrimaryTarget.ActualUnit;
									List<Geopoint_Struct> UncertaintyArea = null;
									if (sensor.CanDetectTarget(Sensor.DetectionAttemptType.SpecificTargetTracking, dataLinkParent, actualUnit, ref UncertaintyArea, Module_Unit.RangeToUnit_Slant(DataLinkParent, AI.PrimaryTarget), ref DetectedEmissions, list, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar, ref LOS_Exists_ESM, ref LOS_Exists_ESM_SW))
									{
										flag = true;
										break;
									}
								}
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 100910", "");
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (!flag)
					{
						BlindTime += elapsedTime;
						break;
					}
					if (BlindTime > 0f)
					{
						BlindTime = 0f;
					}
					if (!method_31(90f) && !GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: true, DropPlottedCourse: true, elapsedTime))
					{
						break;
					}
					return;
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at 100911", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			}
		}
		catch (Exception ex31)
		{
			ProjectData.SetProjectError(ex31);
			Exception ex32 = ex31;
			ex32?.Data.Add("Error at 100907", "");
			GameGeneral.WriteExceptionsToLog(ex32);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (DatalinkRetargetTime > 0f && !Information.IsNothing((object)AI.PrimaryTarget))
		{
			DatalinkRetargetTime = 0f;
		}
		if (!Information.IsNothing((object)ARM_SpecifiedEMission) && !Information.IsNothing((object)ARM_SpecifiedEMission.Value))
		{
			ARM_SpecifiedEMission.Value.Age = ARM_SpecifiedEMission.Value.Age + elapsedTime;
		}
		int num3;
		if (_Latitude == _Latitude && _Longitude == this.get_Longitude((GlobalVariables.BooleanObject)null))
		{
			num3 = -32768;
		}
		else
		{
			_ = Debugger.IsAttached;
			Destroy(ScenEditAction: true, IsAimpointFacility: false, DestroyUnitNow: true, "NaN Coords", null, RegisterAsLosses: false);
			num3 = -32768;
		}
		short num4 = (short)num3;
		if (_Latitude == _Latitude && _Longitude == this.get_Longitude((GlobalVariables.BooleanObject)null))
		{
			num4 = Terrain.GetElevation(_Latitude, _Longitude, RequestIsFromGUI: false, ParentScen);
			if (this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)num4 && !method_20() && !(ImpactsOnThisPulse_ActualUnit | ImpactsOnThisPulse_Contact))
			{
				base.EndgameReport.AddEndGameMessage(hit: false, "Has smashed into the ground");
				double theLat = this.get_Latitude((GlobalVariables.BooleanObject)null);
				double theLon = this.get_Longitude((GlobalVariables.BooleanObject)null);
				float theAlt = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				LockRandom theRNG2 = GameGeneral.GlobalRNG;
				Detonate(theLat, theLon, theAlt, ref theRNG2, Detonation_AddMessage: true);
				return;
			}
		}
		try
		{
			if (IsBallisticMissile)
			{
				((BallisticMissile)this).DeployRVsIfApplicable(elapsedTime);
			}
			else if (!IsWeaponPallet && Warheads.Length > 0 && Warheads[0].Type == Warhead.WarheadType.Weapon && !HasTorpedoPayload && !Warheads[0].get_CarriedWeapon(ParentScen).IsNuke.Value)
			{
				Weapon weapon = Warheads[0].get_CarriedWeapon(ParentScen);
				ActiveUnit_Weaponry weaponry = Weaponry;
				Contact primaryTarget = AI.PrimaryTarget;
				int? ASL_atFiringUnit = (int)Math.Round(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				Sensor SuitableDirectorSensor = null;
				if (weaponry.CanThisWeaponEngageThisTarget(weapon, primaryTarget, ref ASL_atFiringUnit, ManualFire: false, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, null, ref SuitableDirectorSensor).EvaluationEnum == ActiveUnit_Weaponry.WeaponPrefireChecklistEvaluation.OK)
				{
					DeployChildWeapon(this, weapon, AI.PrimaryTarget, elapsedTime, SwitchTarget: true);
					ParentScen?.DestroyThisUnit(this, "All child weapons are away!", "Sub-munitions Expended");
					return;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (Warheads.Any() && Warheads[0].IsEMP)
		{
			float num5 = 5f;
			try
			{
				double? num6 = default(double?);
				double? num7 = default(double?);
				if (!Information.IsNothing((object)AI.PrimaryTarget))
				{
					num6 = ((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
					num7 = ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
				}
				else if (Navigator.HasPlottedCourse())
				{
					num6 = Navigator.PlottedCourse[0].Latitude;
					num7 = Navigator.PlottedCourse[0].Longitude;
				}
				switch (Warheads[0].Type)
				{
				case Warhead.WarheadType.EMP_Omni:
					if (num6.HasValue && num7.HasValue)
					{
						float num8 = Module_Unit.RangeToPoint_Horiz(this, num6.Value, num7.Value);
						if ((double)num8 <= (double)num5 * 0.33)
						{
							Detonate(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ref theRNG, Detonation_AddMessage: true);
							return;
						}
						if (num8 <= num5 && !Information.IsNothing((object)AI.PrimaryTarget) && !Information.IsNothing((object)AI.PrimaryTarget.ActualUnit))
						{
							DesiredAltitude = ImpactAltitude;
							Kinematics.DesiredAltitudeOverride = true;
						}
					}
					break;
				case Warhead.WarheadType.EMP_Directed:
					if (!num6.HasValue || !num7.HasValue)
					{
						break;
					}
					if (!((double)Module_Unit.RangeToPoint_Horiz(this, num6.Value, num7.Value) <= 0.25))
					{
						return;
					}
					if (!Information.IsNothing((object)AI.PrimaryTarget))
					{
						if (!Information.IsNothing((object)AI.PrimaryTarget.ActualUnit))
						{
							AI.PrimaryTarget.ActualUnit.Damage.method_5(0.9f);
						}
						AI.DropTarget(AI.PrimaryTarget);
						AI.PrimaryTarget = null;
						Navigator.ClearPlottedCourse();
					}
					if (AI.Targets_ReadOnly.Length != 0)
					{
						AI.PrimaryTarget = AI.Targets_ReadOnly.OrderBy([SpecialName] (Contact theC) => Module_Unit.RangeToUnit_Horiz_Angular(this, theC)).ElementAtOrDefault(0);
					}
					else
					{
						ParentScen?.DestroyThisUnit(this, "Directed EMP weapon ran out of targets to engage, self-destructed.", "Self-destruct");
					}
					return;
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		try
		{
			if ((AI.PrimaryTarget != null && ImpactsOnThisPulse_ActualUnit) || ImpactsOnThisPulse_Contact)
			{
				if (base.IsMobileDecoy)
				{
					if (Navigator.Has_NonPathfind_NonFP_PlottedCourse())
					{
						Navigator.ClearPlottedCourse();
					}
					return;
				}
				if (HasTorpedoPayload && (AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine || AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint || AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint))
				{
					if (!Navigator.HasPlottedCourse())
					{
						double lon = ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
						double lat = ((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
						double out_lon = this.get_Longitude((GlobalVariables.BooleanObject)null);
						double out_lat = this.get_Latitude((GlobalVariables.BooleanObject)null);
						Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, -0.2f, CurrentHeading);
						this.set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
						this.set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
					}
					else
					{
						double longitude = Navigator.PlottedCourse[0].Longitude;
						double latitude = Navigator.PlottedCourse[0].Latitude;
						double out_lat = this.get_Longitude((GlobalVariables.BooleanObject)null);
						double out_lon = this.get_Latitude((GlobalVariables.BooleanObject)null);
						Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref out_lat, ref out_lon, -0.2f, CurrentHeading);
						this.set_Latitude((GlobalVariables.BooleanObject)null, out_lon);
						this.set_Longitude((GlobalVariables.BooleanObject)null, out_lat);
					}
					method_27();
					return;
				}
				if (method_26())
				{
					method_28();
					return;
				}
				if (Warheads.Length > 0 && Warheads[0].get_IsNuclear(ParentScen))
				{
					if (!Information.IsNothing((object)AI.PrimaryTarget) && !Information.IsNothing((object)AI.PrimaryTarget.ActualUnit))
					{
						ActiveUnit actualUnit2 = AI.PrimaryTarget.ActualUnit;
						Scenario parentScen = ParentScen;
						List<string> PointDefenceMessages = null;
						ResolveImpact(actualUnit2, parentScen, IsPointDefenceMode: false, ref PointDefenceMessages);
						if (!IsMorituri)
						{
							Detonate(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ref theRNG, Detonation_AddMessage: true);
						}
					}
					else if (Information.IsNothing((object)AI.PrimaryTarget))
					{
						if (!Navigator.HasPlottedCourse())
						{
							Detonate(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), ImpactAltitude, ref theRNG, Detonation_AddMessage: true);
						}
						else
						{
							Detonate(Navigator.PlottedCourse[0].Latitude, Navigator.PlottedCourse[0].Longitude, ImpactAltitude, ref theRNG, Detonation_AddMessage: true);
						}
					}
					else if (AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint && Navigator.HasPlottedCourse() && Navigator.PlottedCourse.First().Altitude > 9000f)
					{
						Detonate(((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), Navigator.PlottedCourse.First().Altitude, ref theRNG, Detonation_AddMessage: true);
					}
					else
					{
						Detonate(((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ImpactAltitude, ref theRNG, Detonation_AddMessage: true);
					}
					return;
				}
				if (AI.PrimaryTarget != null && AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint)
				{
					if (Warheads.Any() && Warheads[0].get_IsAirburst(this, AI.PrimaryTarget.ActualUnit))
					{
						Detonate(((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ImpactAltitude, ref theRNG, Detonation_AddMessage: true);
					}
					else
					{
						float MissDistanceFromTargetingPoint_m = default(float);
						float MissBearingFromTargetPoint = default(float);
						Impact_CEP_MissDistanceAndDirection(AI.PrimaryTarget.ActualUnit, ref ParentScen, ref MissDistanceFromTargetingPoint_m, ref MissBearingFromTargetPoint, ref theRNG);
						double out_lon2 = default(double);
						double out_lat2 = default(double);
						Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon2, ref out_lat2, MissDistanceFromTargetingPoint_m / 1852f, MissBearingFromTargetPoint);
						foreach (ActiveUnit item in ParentScen?.ActiveUnits_List)
						{
							if (item != null && Module_Unit.RangeToPoint_Horiz_Angular(item, ref out_lat2, ref out_lon2) < Misc.AngularDistance_5nm)
							{
								float missDistance_m = Math2.CalcDist(out_lat2, out_lon2, item.get_Latitude((GlobalVariables.BooleanObject)null), item.get_Longitude((GlobalVariables.BooleanObject)null)) * 1852f;
								if (CheckForDirectHit(item, out_lat2, out_lon2, missDistance_m, LaunchPoint, MaxRange_NoTargetType, IsUnguidedWeapon: false))
								{
									base.EndgameReport.AddEndGameMessage(hit: true, "Has impacted " + item.Name);
									Impact(item, null);
									ParentScen?.DestroyThisUnit(this, "Has impacted " + item.Name + ". ", "Impact / Detonation");
									return;
								}
							}
						}
						short elevation = Terrain.GetElevation(out_lat2, out_lon2, RequestIsFromGUI: false, ParentScen);
						if (Warheads.Length > 0 && (Warheads[0].Type == Warhead.WarheadType.Cluster_Penetrator || Warheads[0].Type == Warhead.WarheadType.HardTargetPenetrator))
						{
							elevation -= 10;
							base.EndgameReport.AddEndGameMessage(hit: false, "Impacted surface, penetrated and detonated");
							Detonate(out_lat2, out_lon2, elevation, ref theRNG, Detonation_AddMessage: false);
						}
						else
						{
							base.EndgameReport.AddEndGameMessage(hit: false, "Impacted surface");
							Detonate(out_lat2, out_lon2, elevation, ref theRNG, Detonation_AddMessage: false);
						}
					}
				}
				else if (ImpactsOnThisPulse_ActualUnit)
				{
					if (AI.PrimaryTarget != null)
					{
						if (AI.PrimaryTarget.get_IsDestroyed(ParentScen))
						{
							if (AI.PrimaryTarget.IsGroundContact)
							{
								Detonate(((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ImpactAltitude, ref theRNG, Detonation_AddMessage: true);
							}
							return;
						}
						if (AI.PrimaryTarget.ActualUnit != null && AI.PrimaryTarget.ActualUnit.Weaponry != null)
						{
							ActiveUnit_Weaponry weaponry2 = AI.PrimaryTarget.ActualUnit.Weaponry;
							Weapon AttackWeapon = this;
							weaponry2.ResolvePointDefence(elapsedTime, ref AttackWeapon);
							if (!IsMorituri && !(TimeToReseek > 0f))
							{
								Detonate(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ref theRNG, Detonation_AddMessage: true);
							}
						}
						else
						{
							if (AI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint && Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ParentScen?.DestroyThisUnit(this, "Weapon destroyed.", "Weapon Interaction");
						}
					}
				}
				else
				{
					if (Guidance != WeaponGuidanceType.Inertial && (Information.IsNothing((object)AI.PrimaryTarget) || !AI.PrimaryTarget.IsGroundContact))
					{
						AI.DropTarget(AI.PrimaryTarget);
						return;
					}
					if (AI.PrimaryTarget != null)
					{
						Detonate(((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ImpactAltitude, ref theRNG, Detonation_AddMessage: true);
					}
					else if (!Navigator.HasPlottedCourse())
					{
						Detonate(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ParentScen), ref theRNG, Detonation_AddMessage: true);
					}
					else
					{
						Waypoint waypoint = Navigator.PlottedCourse[0];
						Detonate(waypoint.Latitude, waypoint.Longitude, ImpactAltitude, ref theRNG, Detonation_AddMessage: true);
					}
				}
			}
			if (_TimeToDetonate > 0f)
			{
				_TimeToDetonate -= elapsedTime;
				if (_TimeToDetonate <= 0f)
				{
					Detonate(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentScen), ref theRNG, Detonation_AddMessage: true);
				}
			}
			if (IsReEntryVehicle)
			{
				return;
			}
			if (num4 == short.MinValue)
			{
				num4 = Terrain.GetElevation(_Latitude, _Longitude, RequestIsFromGUI: false, ParentScen);
			}
			if (this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)num4)
			{
				if (this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= Kinematics.GetMaximumAltitude() && !method_20())
				{
					base.EndgameReport.AddEndGameMessage(hit: false, "Has smashed into the ground");
					double theLat2 = this.get_Latitude((GlobalVariables.BooleanObject)null);
					double theLon2 = this.get_Longitude((GlobalVariables.BooleanObject)null);
					float theAlt2 = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					LockRandom theRNG2 = GameGeneral.GlobalRNG;
					Detonate(theLat2, theLon2, theAlt2, ref theRNG2, Detonation_AddMessage: true);
				}
				else if (!IsASCMwithoutTFcapability())
				{
					this.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)(Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ParentScen) + 1));
				}
				else
				{
					base.EndgameReport.AddEndGameMessage(hit: false, "Has smashed into the ground (no TF!)");
					double theLat3 = this.get_Latitude((GlobalVariables.BooleanObject)null);
					double theLon3 = this.get_Longitude((GlobalVariables.BooleanObject)null);
					float theAlt3 = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					LockRandom theRNG2 = GameGeneral.GlobalRNG;
					Detonate(theLat3, theLon3, theAlt3, ref theRNG2, Detonation_AddMessage: true);
				}
			}
		}
		catch (Exception ex33)
		{
			ProjectData.SetProjectError(ex33);
			Exception ex34 = ex33;
			ex34?.Data.Add("Error at 100925", "");
			GameGeneral.WriteExceptionsToLog(ex34);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool UsesGNSSTerminalGuidance()
	{
		if (!Flags.Navigation_GPS && !Flags.Navigation_INS_GPS)
		{
			return false;
		}
		return Sensors_Cached.Length == 0;
	}

	public void ReleaseMIRVs(List<Warhead> tempList, float elapsedTime, ref int? ASL)
	{
		int num = Warheads.Length - 1;
		int num2 = 0;
		Warhead warhead;
		Weapon weapon;
		int num3;
		Contact contact = default(Contact);
		while (true)
		{
			if (num2 <= num)
			{
				warhead = Warheads[num2];
				weapon = warhead.get_CarriedWeapon(ParentScen);
				float maximumAltitude = weapon.Kinematics.GetMaximumAltitude();
				if (maximumAltitude == 0f || !(maximumAltitude < this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))
				{
					Weapon newWeapon = GetNewWeapon(ref ParentScen, DBID, bool_5: false);
					num3 = num2 + newWeapon.Warheads.Length - Warheads.Length;
					if (AI.PrimaryTarget == null)
					{
						contact = ((weapon._Sensors.Count <= 0) ? ((Contact)new AimpointContact(Navigator.PlottedCourse.Last().Latitude, Navigator.PlottedCourse.Last().Longitude)) : ((Contact)new ActivationPointContact(Navigator.PlottedCourse.Last().Latitude, Navigator.PlottedCourse.Last().Longitude)));
					}
					else if (!AI.PrimaryTarget.get_IsDestroyed(ParentScen))
					{
						contact = ((!weapon.IsReEntryVehicle) ? AI.PrimaryTarget : new AimpointContact(((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)));
					}
					else if (Navigator.HasPlottedCourse())
					{
						contact = ((weapon._Sensors.Count <= 0) ? ((Contact)new AimpointContact(Navigator.PlottedCourse.Last().Latitude, Navigator.PlottedCourse.Last().Longitude)) : ((Contact)new ActivationPointContact(Navigator.PlottedCourse.Last().Latitude, Navigator.PlottedCourse.Last().Longitude)));
					}
					ActiveUnit_Weaponry weaponry = Weaponry;
					Contact theTarget = contact;
					Sensor SuitableDirectorSensor = null;
					if (weaponry.CanThisWeaponEngageThisTarget(weapon, theTarget, ref ASL, ManualFire: false, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, null, ref SuitableDirectorSensor).EvaluationEnum == ActiveUnit_Weaponry.WeaponPrefireChecklistEvaluation.OK)
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			return;
		}
		if (num3 == 0)
		{
			DeployChildWeapon(this, weapon, contact, elapsedTime, SwitchTarget: true);
		}
		else
		{
			try
			{
				if (AI.Targets_ReadOnly.Length > 0)
				{
					if (num3 - 1 < AI.Targets_ReadOnly.Length)
					{
						if (weapon.IsReEntryVehicle)
						{
							AimpointContact theTarget2 = new AimpointContact(((Module_Unit.Unit)AI.Targets_ReadOnly[num3 - 1]).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.Targets_ReadOnly[num3 - 1]).get_Longitude((GlobalVariables.BooleanObject)null));
							DeployChildWeapon(this, weapon, theTarget2, elapsedTime, SwitchTarget: false);
						}
						else
						{
							DeployChildWeapon(this, weapon, AI.Targets_ReadOnly[num3 - 1], elapsedTime, SwitchTarget: false);
						}
					}
					else
					{
						DeployChildWeapon(this, weapon, contact, elapsedTime, SwitchTarget: false);
					}
				}
				else
				{
					DeployChildWeapon(this, weapon, contact, elapsedTime, SwitchTarget: false);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				DeployChildWeapon(this, weapon, AI.PrimaryTarget, elapsedTime, SwitchTarget: false);
				ex2?.Data.Add("Error at 200047", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		tempList.Add(warhead);
	}

	public List<Module_Unit.Unit> DeployChildWeapon(Weapon theParentWeapon, Weapon theChildWeapon, Contact theTarget, float elapsedTime, bool SwitchTarget)
	{
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
		WeaponRec theWeaponRec = new WeaponRec(ref ParentScen, theChildWeapon.DBID, 1, 1, 1, 1, ExcludeOptionalWeapons: false, AircraftInternalWeapons: false);
		Contact theTarget2 = theParentWeapon.AI.PrimaryTarget;
		if (theTarget2 == null)
		{
			theTarget2 = theTarget;
		}
		WeaponSalvo theWeaponSalvo = default(WeaponSalvo);
		if (theTarget2 != null)
		{
			foreach (WeaponSalvo weaponSalvo in ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).WeaponSalvos)
			{
				WeaponSalvo theSalvo = weaponSalvo;
				if (theSalvo == null || theSalvo.ShootersList.Length == 0 || theSalvo.int_1 != theChildWeapon.DBID || theSalvo.Target != theTarget2)
				{
					continue;
				}
				if (theParentWeapon != null && theParentWeapon.FiringParent != null)
				{
					bool flag = false;
					WeaponSalvo.Shooter[] shootersList = theSalvo.ShootersList;
					for (int i = 0; i < shootersList.Length; i = checked(i + 1))
					{
						if (Operators.CompareString(shootersList[i].ShooterObjectID, theParentWeapon.FiringParent.ObjectID, false) == 0)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						int value = 1;
						if (theParentWeapon.Warheads != null && theParentWeapon.Warheads.Count() > 1)
						{
							value = theParentWeapon.Warheads.Count();
						}
						theParentWeapon.FiringParent.get_UnitSide(SetSideOnly: false).AddShooterToExistingSalvo(ref theSalvo, value, 1, value, theManualFire: false, ref theParentWeapon.FiringParent.ObjectID);
					}
				}
				theWeaponSalvo = theSalvo;
				break;
			}
		}
		if (theWeaponSalvo == null)
		{
			string theShooterObjectID = null;
			int num = 1;
			if (theParentWeapon != null && theParentWeapon.FiringParent != null)
			{
				theShooterObjectID = theParentWeapon.FiringParent.ObjectID;
			}
			if (theParentWeapon.Warheads != null && theParentWeapon.Warheads.Count() > 1)
			{
				num = theParentWeapon.Warheads.Count();
			}
			ref int dBID = ref theChildWeapon.DBID;
			int theQuantity_Assigned = num;
			bool theManualFire = false;
			theWeaponSalvo = new WeaponSalvo(ref dBID, 1, 1, theQuantity_Assigned, ref theTarget2, ref theManualFire, theShooterObjectID, 1, theFireSimultaneouslyFromMultipleMounts: false, DateTime.MinValue);
			((ActiveUnit)this).get_UnitSide(SetSideOnly: false).AddWeaponSalvo(theWeaponSalvo);
		}
		ActiveUnit_Weaponry weaponry = Weaponry;
		int NumberOfWeaponsFired = 0;
		list = weaponry.FireWeapon_Normal(elapsedTime, ref theWeaponRec, theTarget, ref NumberOfWeaponsFired, 0, 0f, Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, 0L, ref theWeaponSalvo);
		foreach (Module_Unit.Unit item in list)
		{
			if (item.IsWeapon && ((Weapon)item).IsReEntryVehicle && !((Weapon)item).IsHGV)
			{
				((Weapon)item).CruiseAltitude_ASL = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
		}
		if (SwitchTarget)
		{
			foreach (Module_Unit.Unit item2 in list)
			{
				if (!(item2 is ActiveUnit))
				{
					continue;
				}
				ActiveUnit activeUnit = (ActiveUnit)item2;
				foreach (ActiveUnit activeUnits_ in ParentScen.ActiveUnits_List)
				{
					if (activeUnits_ == null)
					{
						continue;
					}
					foreach (Contact value3 in activeUnits_.Sensory.Contacts_Local_ReadOnly.Values)
					{
						if (value3.ActualUnit != null && value3.ActualUnit == this)
						{
							activeUnits_.Sensory.NewContactsQueue_Local.AddIfNotExistsElseUpdate(activeUnit.ObjectID, value3);
							activeUnits_.Sensory.DroppedContactsQueue_Local.AddIfNotExistsElseUpdate(ObjectID, value3);
							ArrayExtensions.Clear(ref value3.FutureBallisticPath);
						}
					}
				}
				Side[] sides_ReadOnly = ParentScen.Sides_ReadOnly;
				foreach (Side side in sides_ReadOnly)
				{
					if (side.Contacts.ContainsKey(ObjectID))
					{
						side.Contacts.TryGetValue(ObjectID, out var value2);
						if (value2 != null)
						{
							value2.ActualUnit = activeUnit;
							value2._ActualUnitID = activeUnit.ObjectID;
							side.Contacts.Add(activeUnit.ObjectID, value2);
							side.Contacts.Remove(ObjectID);
							ArrayExtensions.Clear(ref value2.FutureBallisticPath);
						}
					}
				}
			}
		}
		return list;
	}

	private bool method_24()
	{
		if (IsBallisticMissile)
		{
			return Flags.Warhead_MIRV;
		}
		return false;
	}

	private bool method_25()
	{
		if (IsBallisticMissile)
		{
			return Flags.Warhead_MRV;
		}
		return false;
	}

	public bool AttemptBuddyIllumination()
	{
		bool result;
		try
		{
			bool? flag = FiringParent?.IsMobileGroundUnit;
			if ((!flag) ?? false)
			{
				goto IL_00eb;
			}
			ActiveUnit firingParent = FiringParent;
			if (firingParent == null || !firingParent.IsGroupMember() || !flag.HasValue)
			{
				goto IL_00eb;
			}
			List<ActiveUnit> list = FetchAvailableIlluminators_VehicleGroup(new List<ActiveUnit>(FiringParent?.get_ParentGroup(UsingMissionPlanner: false).Units.Values), AI.PrimaryTarget);
			if (list.Count <= 0)
			{
				result = false;
			}
			else
			{
				ActiveUnit_Sensory sensory = list[0].Sensory;
				Contact primaryTarget = AI.PrimaryTarget;
				flag = null;
				bool? LOS_Exists_RadarSW = null;
				LOSCheckResult? LOS_Exists_Visual = null;
				bool? LOS_Exists_Sonar = null;
				sensory.IlluminateThisContactForThisWeapon(primaryTarget, this, ref flag, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar);
				result = true;
			}
			goto end_IL_0001;
			IL_00eb:
			int num;
			if (Flags.SupportsBuddyIllumination)
			{
				PooledList<ActiveUnit> pooledList = FetchAvailableBuddyIlluminatorUnits(((ActiveUnit)this).get_UnitSide(SetSideOnly: false), AI.PrimaryTarget);
				if (pooledList == null)
				{
					num = 0;
					goto IL_017b;
				}
				if (pooledList.Count <= 0)
				{
					num = 0;
					goto IL_017b;
				}
				ActiveUnit_Sensory sensory2 = pooledList[0].Sensory;
				Contact primaryTarget2 = AI.PrimaryTarget;
				bool? LOS_Exists_Sonar = null;
				bool? LOS_Exists_RadarSW = null;
				LOSCheckResult? LOS_Exists_Visual = null;
				flag = null;
				sensory2.IlluminateThisContactForThisWeapon(primaryTarget2, this, ref LOS_Exists_Sonar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref flag);
				pooledList.Dispose();
				result = true;
			}
			else
			{
				result = false;
			}
			goto end_IL_0001;
			IL_017b:
			result = (byte)num != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100927", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void Detonate(double theLat, double theLon, float theAlt, ref LockRandom theRNG, bool Detonation_AddMessage)
	{
		try
		{
			if (Type == _WeaponType.Sonobuoy)
			{
				return;
			}
			string whatCausedDestruction = "Impact / Detonation";
			float num = BasePoK_AnyTarget();
			int num2 = theRNG.Next(1, 101);
			DetonationOccurs = (float)num2 < num;
			StringBuilder stringBuilder = new StringBuilder();
			string text;
			float MissDistanceFromTargetingPoint_m = default(float);
			float MissBearingFromTargetPoint = default(float);
			if (!DetonationOccurs)
			{
				if (IsWeaponPallet)
				{
					text = "Reached the ground and was self destroyed";
					whatCausedDestruction = "Impact / Detonation";
					base.EndgameReport.AddEndGameMessage(hit: false, text);
				}
				else
				{
					text = "Has malfunctioned";
					whatCausedDestruction = "Malfunction";
					base.EndgameReport.AddEndGameMessage(hit: false, text);
				}
			}
			else if (!Impact_CEP_MissDistanceAndDirection(null, ref ParentScen, ref MissDistanceFromTargetingPoint_m, ref MissBearingFromTargetPoint, ref theRNG))
			{
				text = ((Warheads.Count() > 0 && Warheads[0].IsCluster) ? "Dispensing submunitions" : ((AI.PrimaryTarget != null) ? ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? ("Has detonated, " + Conversions.ToString(Math.Round(new decimal((int)Math.Round(MissDistanceFromTargetingPoint_m)), 1)) + "m from intended target point") : ("Has detonated, " + Conversions.ToString(Math.Round(new decimal((int)Math.Round(MissDistanceFromTargetingPoint_m * 3.28084f)), 1)) + "ft from intended target point")) : ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? ("Impacts surface, " + Conversions.ToString(Math.Round(new decimal((int)Math.Round(MissDistanceFromTargetingPoint_m)), 1)) + "m from intended target point") : ("Impacts surface, " + Conversions.ToString(Math.Round(new decimal((int)Math.Round(MissDistanceFromTargetingPoint_m * 3.28084f)), 1)) + "ft from intended target point"))));
				if (Warheads.Length > 0)
				{
					ref Scenario parentScen = ref ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = AI).PrimaryTarget;
					new Explosion(ref parentScen, this, ref thePrimaryTarget, theLon, theLat, theLon, theLat, CurrentHeading, theAlt, Type, Warheads[0].DP, Warheads[0].DP, Warheads[0].Type, Warheads[0].ExplosivesType, null, null, null, null, null, Warheads[0].ClusterBombDispersionAreaLength, Warheads[0].ClusterBombDispersionAreaWidth, Warheads[0].NumberOfWarheads);
					aI.PrimaryTarget = thePrimaryTarget;
				}
			}
			else
			{
				short elevation = Terrain.GetElevation(theLat, theLon, RequestIsFromGUI: false, ParentScen);
				double out_lon = default(double);
				double out_lat = default(double);
				Geodesic_EdWilliams.CalcPoint_Williams(theLon, theLat, ref out_lon, ref out_lat, MissDistanceFromTargetingPoint_m / 1852f, MissBearingFromTargetPoint);
				float num3 = Terrain.GetElevation(out_lat, out_lon, RequestIsFromGUI: false, ParentScen);
				if (num3 != (float)elevation)
				{
					theAlt = theAlt + num3 - (float)elevation;
				}
				text = ((Warheads.Count() > 0 && Warheads[0].IsCluster) ? "Dispensing submunitions" : ((AI.PrimaryTarget == null) ? (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("Impacts surface, " + Conversions.ToString(Math.Round(new decimal((int)Math.Round(MissDistanceFromTargetingPoint_m * 3.28084f)), 1)) + "ft from intended target point") : ("Impacts surface, " + Conversions.ToString(Math.Round(new decimal((int)Math.Round(MissDistanceFromTargetingPoint_m)), 1)) + "m from intended target point")) : ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? ("Has detonated, " + Conversions.ToString(Math.Round(new decimal((int)Math.Round(MissDistanceFromTargetingPoint_m)), 1)) + "m from intended target point") : ("Has detonated, " + Conversions.ToString(Math.Round(new decimal((int)Math.Round(MissDistanceFromTargetingPoint_m * 3.28084f)), 1)) + "ft from intended target point"))));
				if (Warheads.Length > 0)
				{
					ref Scenario parentScen2 = ref ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = AI).PrimaryTarget;
					new Explosion(ref parentScen2, this, ref thePrimaryTarget, out_lon, out_lat, out_lon, out_lat, CurrentHeading, theAlt, Type, Warheads[0].DP, Warheads[0].DP, Warheads[0].Type, Warheads[0].ExplosivesType, null, null, null, null, null, Warheads[0].ClusterBombDispersionAreaLength, Warheads[0].ClusterBombDispersionAreaWidth, Warheads[0].NumberOfWarheads);
					aI.PrimaryTarget = thePrimaryTarget;
				}
			}
			if (Detonation_AddMessage)
			{
				base.EndgameReport.AddEndGameMessage(hit: false, text);
			}
			ParentScen.DestroyThisUnit(this, text, whatCausedDestruction);
			stringBuilder.Append(text);
			if (AI.PrimaryTarget != null)
			{
				if (AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint)
				{
					_ = AI.PrimaryTarget;
				}
				else
				{
					_ = AI.PrimaryTarget.ActualUnit;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101338", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected virtual void HandleReachingActivationPoint()
	{
		if (Guidance == WeaponGuidanceType.Inertial)
		{
			return;
		}
		bool clearDatalink = (AI.PrimaryTarget == null || !AI.PrimaryTarget.IsBallisticTarget()) && !Flags.LoiterCapability;
		if (Navigator.Has_NonPathfind_NonFP_PlottedCourse())
		{
			return;
		}
		if (AI.PrimaryTarget != null && AI.PrimaryTarget.ActualUnit != null && AI.PrimaryTarget.IsAir_Missile_Orbital_Contact && DataLinkParent != null)
		{
			Sensory.ActivateTerminalSensors();
			if (AI.PrimaryTarget.LastDetections.Where([SpecialName] (Contact.Detection_Struct theDet) => Operators.CompareString(theDet.DetectorUnitID, ObjectID, false) == 0).Count() > 0)
			{
				GoAutonomous(AI.PrimaryTarget != null && AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint, clearDatalink);
			}
		}
		else
		{
			GoAutonomous(AI.PrimaryTarget != null && AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint, clearDatalink);
		}
	}

	internal void GoAutonomous(bool clearPrimaryTarget = false, bool clearDatalink = false, bool clearPlottedCourse = false)
	{
		try
		{
			if (!(_DatalinkRetargetTime > 0f) || Guidance != WeaponGuidanceType.Datalink_Plus_SemiActive)
			{
				_BlindTime = 0f;
			}
			if (!Information.IsNothing((object)AI.PrimaryTarget))
			{
				_DatalinkRetargetTime = 0f;
			}
			if (clearPrimaryTarget)
			{
				Weapon_AI aI = AI;
				ActiveUnit theAU = this;
				aI.ClearAllTargets(ref theAU);
				if (!Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					((ActiveUnit)this).set_DesiredHeading(TurnRate.Max, CurrentHeading);
				}
			}
			if (clearDatalink)
			{
				ClearAllComms();
				DetermineGuidance();
				if (weaponGuidanceType_0 == WeaponGuidanceType.Inertial && !Information.IsNothing((object)AI.PrimaryTarget) && Navigator.PlottedCourse.Length == 0)
				{
					Navigator.AddWaypoint(((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
				}
			}
			if (clearPlottedCourse && Guidance != WeaponGuidanceType.Inertial)
			{
				Navigator.ClearPlottedCourse();
			}
			if (!Navigator.Has_NonPathfind_NonFP_PlottedCourse() && !PlayerIsPlottingCourse)
			{
				Sensory.ActivateTerminalSensors();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100928", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ClearAllComms()
	{
		if (DataLinkParent != null)
		{
			DataLinkParent = null;
		}
		_Comms = new CommDevice[0];
	}

	public void ClearAllSensors()
	{
		if (_Sensors.Count > 0)
		{
			_Sensors.Clear();
			Sensors_Cached = null;
			MineCountermeasures = null;
		}
	}

	[SpecialName]
	private bool method_26()
	{
		bool result;
		try
		{
			Warhead[] warheads = Warheads;
			int num = 0;
			while (true)
			{
				if (num < warheads.Length)
				{
					Warhead warhead = warheads[num];
					if (warhead.Type != Warhead.WarheadType.DepthCharge)
					{
						if (warhead.Type != Warhead.WarheadType.Weapon || warhead.get_CarriedWeapon(ParentScen).Type != _WeaponType.DepthCharge)
						{
							num = checked(num + 1);
							continue;
						}
						result = true;
						break;
					}
					result = true;
					break;
				}
				result = false;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100930", "");
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
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_27()
	{
		List<Warhead> list = new List<Warhead>();
		try
		{
			Warhead[] warheads = Warheads;
			foreach (Warhead warhead in warheads)
			{
				if (warhead.get_CarriedWeapon(ParentScen) != null && warhead.get_CarriedWeapon(ParentScen).IsTorpedo)
				{
					Weapon theWeapon = GetNewWeapon(ref ParentScen, (int)Math.Round(warhead.DP), bool_5: false);
					theWeapon.set_Latitude((GlobalVariables.BooleanObject)null, this.get_Latitude((GlobalVariables.BooleanObject)null));
					theWeapon.set_Longitude((GlobalVariables.BooleanObject)null, this.get_Longitude((GlobalVariables.BooleanObject)null));
					theWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, -20f);
					theWeapon.CurrentHeading = CurrentHeading;
					((ActiveUnit)theWeapon).set_DesiredHeading(TurnRate.Max, theWeapon.CurrentHeading);
					theWeapon.LaunchPoint = new GeoPoint(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null));
					((ActiveUnit)theWeapon).set_UnitSide(SetSideOnly: false, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false));
					theWeapon.SetThrottle(theWeapon.MaxPossibleThrottleSetting);
					theWeapon.AI.PrimaryTarget = AI.PrimaryTarget;
					theWeapon.FiringParent = FiringParent;
					theWeapon.SearchPatternType = WeaponSearchPatternType.Circle;
					if (!ParentScen.ActiveUnits.ContainsKey(theWeapon.ObjectID))
					{
						ParentScen.AddThisUnit(theWeapon);
					}
					list.Add(warhead);
					Weapon_AI aI;
					Contact theNewTarget = (aI = theWeapon.AI).PrimaryTarget;
					CreateSalvo_Airborne(ref theWeapon, ref theNewTarget, ParentScen);
					aI.PrimaryTarget = theNewTarget;
				}
			}
			foreach (Warhead item in list)
			{
				ArrayExtensions.Remove(ref Warheads, item);
			}
			if (Warheads.Length == 0 || AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine)
			{
				ParentScen.DestroyThisUnit(this, "Torpedo payload has been released, self-destructing", "Sub-munitions Expended");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100931", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_28()
	{
		List<Warhead> list = new List<Warhead>();
		try
		{
			Warhead[] warheads = Warheads;
			foreach (Warhead warhead in warheads)
			{
				if (Information.IsNothing((object)warhead.get_CarriedWeapon(ParentScen)) || warhead.get_CarriedWeapon(ParentScen).Type != _WeaponType.DepthCharge)
				{
					continue;
				}
				UnguidedWeapon unguidedWeapon = new UnguidedWeapon(warhead.get_CarriedWeapon(ParentScen), AI.PrimaryTarget, this, this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null));
				unguidedWeapon.CEP_Surface = warhead.get_CarriedWeapon(ParentScen).CEP_Surface_Nominal;
				unguidedWeapon.CurrentHeading = AI.BearingToUnit_True(AI.PrimaryTarget);
				unguidedWeapon.set_UnitSide(SetSideOnly: false, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false));
				unguidedWeapon.FiringParent = activeUnit_0;
				if (!Information.IsNothing((object)activeUnit_0))
				{
					unguidedWeapon.FiringParent_ID = activeUnit_0.ObjectID;
				}
				if (warhead.get_CarriedWeapon(ParentScen).IsNuke.Value)
				{
					if ((float)GameGeneral.GlobalRNG.Next(1, 101) < unguidedWeapon.SubPOK)
					{
						unguidedWeapon.Detonate(ParentScen);
					}
				}
				else
				{
					ParentScen.UnguidedWeapons.AddOrUpdate(unguidedWeapon.ObjectID, unguidedWeapon);
				}
				list.Add(warhead);
			}
			foreach (Warhead item in list)
			{
				ArrayExtensions.Remove(ref Warheads, item);
			}
			if (Warheads.Length == 0 || AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine)
			{
				ParentScen.DestroyThisUnit(this, "Torpedo payload has been released, self-destructing", "Sub-munitions Expended");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100932", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected bool GuidanceLogic_DestroyedFiringParent()
	{
		return false;
	}

	public void GoDumb(bool ComputeTerminalPoint = true)
	{
		try
		{
			if (Guidance == WeaponGuidanceType.SemiActive)
			{
				Flags.IlluminateAtLaunch = false;
				Flags.TerminalIllumination = false;
				foreach (ActiveUnit value in ParentScen.ActiveUnits.Values)
				{
					Sensor[] sensors_Cached = value.Sensors_Cached;
					foreach (Sensor sensor in sensors_Cached)
					{
						if (sensor != null && sensor.SemiActiveWeaponsGuided.Contains(this))
						{
							sensor.SemiActiveWeaponsGuided.Remove(this);
							SensorProvidingFireControlForMe = null;
						}
						if (sensor != null && sensor.SemiActiveWeaponsGuided.Count == 0)
						{
							sensor.StopTrackingTarget(AI.PrimaryTarget);
						}
					}
				}
			}
			if (_Comms.Count() > 0 && (AI.PrimaryTarget_Type == Contact_Base.ContactType.Surface || AI.PrimaryTarget_Type == Contact_Base.ContactType.Submarine || AI.PrimaryTarget_Type == Contact_Base.ContactType.Facility_Fixed || AI.PrimaryTarget_Type == Contact_Base.ContactType.Facility_Mobile || AI.PrimaryTarget_Type == Contact_Base.ContactType.AggregateGroundUnit))
			{
				if (Information.IsNothing((object)AI.PrimaryTarget))
				{
					AimpointContact primaryTarget = new AimpointContact(AI.PrimaryTarget_LastKnown_Lat, AI.PrimaryTarget_LastKnown_Lon);
					AI.PrimaryTarget = primaryTarget;
				}
				else
				{
					AimpointContact primaryTarget2 = new AimpointContact(((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
					AI.PrimaryTarget = primaryTarget2;
				}
			}
			else
			{
				ClearAllSensors();
				ClearAllComms();
				DetermineGuidance();
				if (Guidance == WeaponGuidanceType.Inertial && ComputeTerminalPoint)
				{
					Navigator.ComputeTerminalPoint(Kinematics.GetMaximumSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false), IsAirdroppedTorpedo: false);
				}
			}
			if (Flags.ReAttack_Capability)
			{
				Flags.ReAttack_Capability = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100933", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected bool GuidanceLogic_DatalinkParentNotAvailable(float elapsedTime)
	{
		bool result;
		try
		{
			int num;
			if (!IsAAWCapable && Type != _WeaponType.Torpedo && Navigator.Has_NonPathfind_NonFP_PlottedCourse())
			{
				result = false;
			}
			else
			{
				if (DataLinkParent == null || DataLinkParent.IsMorituri)
				{
					CommStuff.CheckCommsAndDataLinks(elapsedTime, null);
				}
				if (DataLinkParent != null && !DataLinkParent.IsMorituri)
				{
					if (!DataLinkParent.IsShip)
					{
						num = 0;
						goto IL_0085;
					}
					if (!((Ship)DataLinkParent).IsSinking)
					{
						num = 0;
						goto IL_0085;
					}
					GoAutonomous(clearPrimaryTarget: false, clearDatalink: true);
					result = true;
				}
				else
				{
					int num2;
					if (Guidance == WeaponGuidanceType.TVM)
					{
						GoAutonomous(clearPrimaryTarget: true, clearDatalink: true, clearPlottedCourse: true);
						num2 = 1;
					}
					else
					{
						GoAutonomous(clearPrimaryTarget: false, clearDatalink: true);
						num2 = 1;
					}
					result = (byte)num2 != 0;
				}
			}
			goto end_IL_0001;
			IL_0085:
			result = (byte)num != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100934", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (!Debugger.IsAttached)
			{
				num3 = 0;
			}
			else
			{
				Debugger.Break();
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	protected virtual bool GuidanceLogic_DestroyedOrVanishedPrimaryTarget_DatalinkedWeapon(float elapsedTime)
	{
		bool result;
		try
		{
			int num;
			if (!myTargetDoesNotExist())
			{
				if (AI.PrimaryTarget != null && !AI.PrimaryTarget.get_IsDestroyed(ParentScen))
				{
					if (!(AI.PrimaryTarget.Age > 30f))
					{
						goto IL_00c1;
					}
					if (!AI.PrimaryTarget.IsAir_Missile_Orbital_Contact)
					{
						num = 0;
						goto IL_00c2;
					}
					if (Navigator.Has_NonPathfind_NonFP_PlottedCourse())
					{
						goto IL_00c1;
					}
					int num2;
					if (HasGoneAutonomous)
					{
						num2 = 1;
					}
					else
					{
						GoAutonomous(clearPrimaryTarget: true, clearDatalink: true);
						AddMessage("Weapon: " + Name + " is not receiving firm target updates from parent unit... Going autonomous.", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
						num2 = 1;
					}
					result = (byte)num2 != 0;
				}
				else
				{
					AttemptRetargeting_Datalink(elapsedTime, 60f);
					result = true;
				}
			}
			else
			{
				AttemptRetargeting_Datalink(elapsedTime, 60f);
				result = true;
			}
			goto end_IL_0001;
			IL_00c2:
			result = (byte)num != 0;
			goto end_IL_0001;
			IL_00c1:
			num = 0;
			goto IL_00c2;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100935", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num3 = 0;
			}
			else
			{
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool method_29(float float_25)
	{
		bool result;
		try
		{
			if (myTargetDoesNotExist())
			{
				int num;
				if (base.HasInfraredSensor)
				{
					num = 1;
				}
				else
				{
					BlindTime += float_25;
					num = 1;
				}
				result = (byte)num != 0;
			}
			else if (!AI.PrimaryTarget.get_IsDestroyed(ParentScen))
			{
				result = false;
			}
			else
			{
				int num2;
				if (AI.PrimaryTarget.isSurfaceOrLandContact)
				{
					num2 = 1;
				}
				else if (!Information.IsNothing((object)DataLinkParent))
				{
					base.EndgameReport.AddEndGameMessage(hit: false, "Had its target destroyed in the terminal illumination phase, attempt retargeting...");
					AttemptRetargeting_Datalink(float_25, 60f);
					num2 = 1;
				}
				else
				{
					base.EndgameReport.AddEndGameMessage(hit: false, "Had its target destroyed...");
					GoAutonomous(clearPrimaryTarget: true, clearDatalink: true, clearPlottedCourse: true);
					num2 = 1;
				}
				result = (byte)num2 != 0;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100936", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (!Debugger.IsAttached)
			{
				num3 = 0;
			}
			else
			{
				Debugger.Break();
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	protected bool GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon()
	{
		bool result;
		try
		{
			int num;
			if (!Navigator.Has_NonPathfind_NonFP_PlottedCourse())
			{
				if (Information.IsNothing((object)AI.PrimaryTarget))
				{
					if (Information.IsNothing((object)AI.PrimaryTarget))
					{
						goto IL_00bc;
					}
					if (!IsTorpedo)
					{
						num = 0;
						goto IL_00bd;
					}
					if (!(AI.PrimaryTarget.Age > 600f))
					{
						goto IL_00bc;
					}
					AddMessage("Weapon: " + Name + " is not receiving firm target updates from parent unit... Going autonomous.", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
					result = true;
				}
				else
				{
					if (!AI.PrimaryTarget.get_IsDestroyed(ParentScen))
					{
						goto IL_00bc;
					}
					GoAutonomous(clearPrimaryTarget: true, clearDatalink: true);
					result = true;
				}
			}
			else
			{
				result = false;
			}
			goto end_IL_0001;
			IL_00bd:
			result = (byte)num != 0;
			goto end_IL_0001;
			IL_00bc:
			num = 0;
			goto IL_00bd;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100937", "");
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
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool method_30()
	{
		bool result;
		try
		{
			int num;
			if (AI.PrimaryTarget == null)
			{
				num = 0;
				goto IL_0149;
			}
			if (AI.PrimaryTarget_Type != Contact_Base.ContactType.Surface && AI.PrimaryTarget_Type != Contact_Base.ContactType.Submarine && AI.PrimaryTarget_Type != Contact_Base.ContactType.Facility_Fixed && AI.PrimaryTarget_Type != Contact_Base.ContactType.Facility_Mobile && AI.PrimaryTarget_Type != Contact_Base.ContactType.AggregateGroundUnit)
			{
				num = 0;
				goto IL_0149;
			}
			if (myTargetDoesNotExist())
			{
				AimpointContact primaryTarget = new AimpointContact(AI.PrimaryTarget_LastKnown_Lat, AI.PrimaryTarget_LastKnown_Lon);
				if ((AI.PrimaryTarget_LastKnown_Lat == 0.0) & (AI.PrimaryTarget_LastKnown_Lon == 0.0))
				{
					AI.PrimaryTarget_LastKnown_Lat = ((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
					AI.PrimaryTarget_LastKnown_Lon = ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
					primaryTarget = new AimpointContact(((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
				}
				AI.PrimaryTarget = primaryTarget;
				result = true;
			}
			else
			{
				if (!AI.PrimaryTarget.get_IsDestroyed(ParentScen))
				{
					num = 0;
					goto IL_0149;
				}
				AimpointContact primaryTarget2 = new AimpointContact(((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
				AI.PrimaryTarget = primaryTarget2;
				result = true;
			}
			goto end_IL_0001;
			IL_0149:
			result = (byte)num != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101297", "");
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
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	protected bool GuidanceLogic_Overshoot(float OverShootDegrees, bool DropPrimaryTarget, bool DropDatalinkConnection, bool DropPlottedCourse, float elapsedTime)
	{
		bool result;
		if (!Flags.ReAttack_Capability)
		{
			try
			{
				if (Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					result = false;
				}
				else
				{
					if (AI.PrimaryTarget == null || !HasTorpedoPayload)
					{
						goto IL_007f;
					}
					int num;
					if (AI.PrimaryTarget.Type != Contact_Base.ContactType.Submarine && AI.PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint)
					{
						if (AI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint)
						{
							goto IL_007f;
						}
						num = 0;
					}
					else
					{
						num = 0;
					}
					result = (byte)num != 0;
				}
				goto end_IL_0011;
				IL_0271:
				int num2;
				result = (byte)num2 != 0;
				goto end_IL_0011;
				IL_012f:
				float num3 = ((AI.PrimaryTarget.ActualUnit == null) ? MathFunctions.GetRelativeBearing(CurrentHeading, AI.BearingToUnit_True(AI.PrimaryTarget)) : MathFunctions.GetRelativeBearing(CurrentHeading, AI.BearingToUnit_True(AI.PrimaryTarget.ActualUnit)));
				if (!(360f - OverShootDegrees > num3) || !(num3 > OverShootDegrees) || ImpactsOnThisPulse_ActualUnit)
				{
					num2 = 0;
					goto IL_0271;
				}
				if (DataLinkParent != null)
				{
					if (RangeToUnit_Horiz(DataLinkParent, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) < 2f)
					{
						result = false;
					}
					else
					{
						AttemptRetargeting_Datalink(elapsedTime, OverShootDegrees);
						result = true;
					}
				}
				else if (FiringParent != null && RangeToUnit_Horiz(FiringParent, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) < 2f)
				{
					result = false;
				}
				else
				{
					if (AI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint)
					{
						AddMessage("Weapon: " + Name + " overshot its target...", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
					GoAutonomous(DropPrimaryTarget, DropDatalinkConnection, DropPlottedCourse);
					result = true;
				}
				goto end_IL_0011;
				IL_007f:
				Contact primaryTarget = AI.PrimaryTarget;
				bool? flag = ((primaryTarget != null) ? new bool?(primaryTarget.Type == Contact_Base.ContactType.Aimpoint) : ((bool?)null));
				if (((!flag) ?? flag) != true)
				{
					num2 = 0;
					goto IL_0271;
				}
				if ((double)RangeToUnit_Horiz(AI.PrimaryTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) < 0.3)
				{
					result = false;
				}
				else
				{
					if (!IsTorpedo || !Flags.SearchPattern)
					{
						goto IL_012f;
					}
					Weapon_AI aI = AI;
					Weapon theWeapon = this;
					if (aI.PrimaryTargetLocated(ref theWeapon))
					{
						goto IL_012f;
					}
					result = false;
				}
				end_IL_0011:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100938", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num4;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num4 = 0;
				}
				else
				{
					num4 = 0;
				}
				result = (byte)num4 != 0;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	internal bool IsDeployablePlatform()
	{
		_WeaponType type = Type;
		if ((uint)(type - 4102) <= 4u)
		{
			return true;
		}
		return false;
	}

	private bool method_31(float float_25)
	{
		bool result;
		if (Information.IsNothing((object)DataLinkParent) && Information.IsNothing((object)FiringParent))
		{
			result = false;
		}
		else if (!Information.IsNothing((object)AI.PrimaryTarget.ActualUnit))
		{
			try
			{
				int num;
				if (!AI.PrimaryTarget.ActualUnit.IsAircraft && !AI.PrimaryTarget.ActualUnit.IsWeapon)
				{
					num = 0;
					goto IL_0295;
				}
				float relativeBearing = default(float);
				if ((double)RangeToUnit_Horiz(AI.PrimaryTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) < 0.3)
				{
					result = false;
				}
				else if (DataLinkParent == null)
				{
					if (FiringParent == null)
					{
						goto IL_016b;
					}
					if (!(RangeToUnit_Horiz(FiringParent, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) < 2f))
					{
						relativeBearing = MathFunctions.GetRelativeBearing(CurrentHeading, Math2.CalcAzimuth(FiringParent.get_Latitude((GlobalVariables.BooleanObject)null), FiringParent.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null)));
						goto IL_016b;
					}
					result = false;
				}
				else
				{
					if (!(RangeToUnit_Horiz(DataLinkParent, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) < 2f))
					{
						relativeBearing = MathFunctions.GetRelativeBearing(CurrentHeading, Math2.CalcAzimuth(DataLinkParent.get_Latitude((GlobalVariables.BooleanObject)null), DataLinkParent.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null)));
						goto IL_016b;
					}
					result = false;
				}
				goto end_IL_003c;
				IL_0295:
				result = (byte)num != 0;
				goto end_IL_003c;
				IL_016b:
				if (!(relativeBearing > float_25) || !(relativeBearing < 360f - float_25) || ImpactsOnThisPulse_ActualUnit)
				{
					num = 0;
					goto IL_0295;
				}
				int num2;
				if (Guidance != WeaponGuidanceType.SemiActive_Plus_Active && Guidance != WeaponGuidanceType.TimesharedSemiActive_Plus_Active)
				{
					if (_Sensors.Count != 1 && Guidance != WeaponGuidanceType.TVM)
					{
						AddMessage("Weapon: " + Name + " can no longer see reflected energy from target (engagement geometry issue)... Switching to backup seeker", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
						GoAutonomous(clearPrimaryTarget: false, clearDatalink: true, clearPlottedCourse: true);
						num2 = 1;
					}
					else
					{
						AddMessage("Weapon: " + Name + " can no longer see reflected energy from target (engagement geometry issue)...", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
						GoAutonomous(clearPrimaryTarget: true, clearDatalink: true, clearPlottedCourse: true);
						num2 = 1;
					}
				}
				else
				{
					AddMessage("Weapon: " + Name + " can no longer see reflected energy from its target (engagement geometry issue)... switching to onboard seeker", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
					GoAutonomous(clearPrimaryTarget: false, clearDatalink: true, clearPlottedCourse: true);
					num2 = 1;
				}
				result = (byte)num2 != 0;
				end_IL_003c:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100939", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num3;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num3 = 0;
				}
				else
				{
					num3 = 0;
				}
				result = (byte)num3 != 0;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	private float method_32()
	{
		float result = 60f;
		if (DataLinkParent != null && AI.PrimaryTarget != null && AI.PrimaryTarget.IsBallisticTarget())
		{
			result = 120f;
			Geopoint_Struct geopoint_Struct = Navigator.ComputeInterceptPoint_ABM(AI.PrimaryTarget);
			if (!geopoint_Struct.HasZeroCoords && Math.Abs(((ActiveUnit)this).DesiredHeading - Module_Unit.BearingToPoint_True(this, geopoint_Struct.Latitude, geopoint_Struct.Longitude)) < 60f)
			{
				result = 180f;
			}
		}
		return result;
	}

	protected virtual void WeaponLogic_DatalinkedWeapons(float elapsedTime)
	{
		try
		{
			if (GuidanceLogic_DatalinkParentNotAvailable(elapsedTime) || GuidanceLogic_DestroyedOrVanishedPrimaryTarget_DatalinkedWeapon(elapsedTime))
			{
				return;
			}
			float overShootDegrees = 60f;
			if (AI.PrimaryTarget != null)
			{
				if (!AI.PrimaryTarget.IsBallisticTarget())
				{
					if (isLoiterCapable)
					{
						overShootDegrees = 180f;
					}
				}
				else
				{
					overShootDegrees = method_32();
				}
			}
			GuidanceLogic_Overshoot(overShootDegrees, DropPrimaryTarget: true, DropDatalinkConnection: true, DropPlottedCourse: true, elapsedTime);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100941", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public List<ActiveUnit> FetchAvailableIlluminators_VehicleGroup(List<ActiveUnit> CandidateUnits, Contact theTarget)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		List<ActiveUnit> result;
		try
		{
			Sensor sensor = default(Sensor);
			if (_IlluminatorUnit != null && theTarget != null)
			{
				ActiveUnit_Sensory sensory = _IlluminatorUnit.Sensory;
				Contact theContact = theTarget;
				ref Sensor suitableIlluminator = ref sensor;
				bool? LOS_Exists_Radar = null;
				bool? LOS_Exists_RadarSW = null;
				LOSCheckResult? LOS_Exists_Visual = null;
				bool? LOS_Exists_Sonar = null;
				if (sensory.CanIlluminateThisContactForThisWeapon(theContact, this, ref suitableIlluminator, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar))
				{
					list.Add(_IlluminatorUnit);
				}
			}
			if (theTarget != null)
			{
				IEnumerable<ActiveUnit> collection = from theAU in CandidateUnits.Where([SpecialName] (ActiveUnit theAU) =>
					{
						ActiveUnit_Sensory sensory2 = theAU.Sensory;
						Contact theContact2 = theTarget;
						Weapon theWeapon = this;
						ref Sensor suitableIlluminator2 = ref sensor;
						bool? LOS_Exists_Radar2 = null;
						bool? LOS_Exists_RadarSW2 = null;
						LOSCheckResult? LOS_Exists_Visual2 = null;
						bool? LOS_Exists_Sonar2 = null;
						return sensory2.CanIlluminateThisContactForThisWeapon(theContact2, theWeapon, ref suitableIlluminator2, ref LOS_Exists_Radar2, ref LOS_Exists_RadarSW2, ref LOS_Exists_Visual2, ref LOS_Exists_Sonar2);
					})
					orderby Module_Unit.RangeToPoint_Horiz_Angular(theAU, new GeoPoint(((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null)))
					select theAU;
				list.AddRange(collection);
			}
			result = list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100942", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = list;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public PooledList<ActiveUnit> FetchAvailableBuddyIlluminatorUnits(Side theSide, Contact theTarget)
	{
		PooledList<ActiveUnit> pooledList = default(PooledList<ActiveUnit>);
		PooledList<ActiveUnit> result;
		try
		{
			Sensor SuitableIlluminator = default(Sensor);
			if (_IlluminatorUnit != null && theTarget != null)
			{
				ActiveUnit_Sensory sensory = _IlluminatorUnit.Sensory;
				bool? LOS_Exists_Radar = null;
				bool? LOS_Exists_RadarSW = null;
				LOSCheckResult? LOS_Exists_Visual = null;
				bool? LOS_Exists_Sonar = null;
				if (sensory.CanIlluminateThisContactForThisWeapon(theTarget, this, ref SuitableIlluminator, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar))
				{
					if (pooledList == null)
					{
						pooledList = new PooledList<ActiveUnit>();
					}
					pooledList.Add(_IlluminatorUnit);
				}
			}
			if (Flags.SupportsBuddyIllumination && theSide != null && theTarget != null)
			{
				if (_IlluminatorUnit != null)
				{
					if (pooledList == null)
					{
						pooledList = new PooledList<ActiveUnit>();
					}
					pooledList.Add(_IlluminatorUnit);
				}
				int count = theSide.Units.Count;
				ActiveUnit[] array = theSide.Units.InternalArray();
				int num = count - 1;
				for (int i = 0; i <= num; i++)
				{
					ActiveUnit activeUnit = array[i];
					if (activeUnit == null)
					{
						continue;
					}
					ActiveUnit_Sensory sensory2 = activeUnit.Sensory;
					bool? LOS_Exists_Sonar = null;
					bool? LOS_Exists_RadarSW = null;
					LOSCheckResult? LOS_Exists_Visual = null;
					bool? LOS_Exists_Radar = null;
					if (sensory2.CanIlluminateThisContactForThisWeapon(theTarget, this, ref SuitableIlluminator, ref LOS_Exists_Sonar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Radar))
					{
						if (pooledList == null)
						{
							pooledList = new PooledList<ActiveUnit>();
						}
						pooledList.Add(activeUnit);
					}
				}
				pooledList?.Sort(new Class9(theTarget));
			}
			result = pooledList;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100942", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = pooledList;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_33(float float_25)
	{
		try
		{
			if (Type == _WeaponType.Sonobuoy || GuidanceLogic_DatalinkParentNotAvailable(float_25) || GuidanceLogic_DestroyedOrVanishedPrimaryTarget_DatalinkedWeapon(float_25))
			{
				return;
			}
			if (!method_34())
			{
				BlindTime = 0f;
				AI.PrimaryTarget.Age = 0f;
				Module_Unit.ClosureSpeed(this, AI.PrimaryTarget, CurrentSpeed, CurrentHeading);
				if (ImpactsOnThisPulse_ActualUnit || ImpactsOnThisPulse_Contact)
				{
					if (AI.PrimaryTarget.get_IsDestroyed(ParentScen))
					{
						return;
					}
					if (Information.IsNothing((object)DataLinkParent) || Information.IsNothing((object)SensorProvidingFireControlForMe))
					{
						PooledList<ActiveUnit> pooledList = FetchAvailableBuddyIlluminatorUnits(((ActiveUnit)this).get_UnitSide(SetSideOnly: false), AI.PrimaryTarget);
						if (pooledList != null && pooledList.Count > 0)
						{
							foreach (ActiveUnit item in pooledList)
							{
								if (item != null)
								{
									ActiveUnit_Sensory sensory = item.Sensory;
									Contact primaryTarget = AI.PrimaryTarget;
									bool? LOS_Exists_Radar = null;
									bool? LOS_Exists_RadarSW = null;
									LOSCheckResult? LOS_Exists_Visual = null;
									bool? LOS_Exists_Sonar = null;
									sensory.IlluminateThisContactForThisWeapon(primaryTarget, this, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar);
									break;
								}
							}
							pooledList.Dispose();
						}
						else
						{
							Contact_Base.ContactType type = AI.PrimaryTarget.Type;
							if (type > Contact_Base.ContactType.Missile && type != Contact_Base.ContactType.Orbital)
							{
								CEP_Surface = 3 * CEP_Surface;
								CEP_Land = 3 * CEP_Land;
								SurfPOK = (int)Math.Round((double)SurfPOK / 3.0);
								LandPOK = (int)Math.Round((double)LandPOK / 3.0);
								SubPOK = (int)Math.Round((double)SubPOK / 3.0);
							}
							else if (_Sensors.Count == 1)
							{
								base.EndgameReport.AddEndGameMessage(hit: false, "Cannot have its target illuminated...");
								AI.PrimaryTarget = null;
								return;
							}
						}
					}
				}
				if (!DataLinkParent.Sensory.IsIlluminatingThisContact(AI.PrimaryTarget))
				{
					ActiveUnit_Sensory sensory2 = DataLinkParent.Sensory;
					Contact primaryTarget2 = AI.PrimaryTarget;
					bool? LOS_Exists_Sonar = null;
					bool? LOS_Exists_RadarSW = null;
					LOSCheckResult? LOS_Exists_Visual = null;
					bool? LOS_Exists_Radar = null;
					Sensor SuitableIlluminator = default(Sensor);
					if (sensory2.CanIlluminateThisContactForThisWeapon(primaryTarget2, this, ref SuitableIlluminator, ref LOS_Exists_Sonar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Radar))
					{
						ActiveUnit_Sensory sensory3 = DataLinkParent.Sensory;
						Contact primaryTarget3 = AI.PrimaryTarget;
						LOS_Exists_Radar = null;
						LOS_Exists_RadarSW = null;
						LOS_Exists_Visual = null;
						LOS_Exists_Sonar = null;
						sensory3.IlluminateThisContactForThisWeapon(primaryTarget3, this, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar);
					}
				}
				if (!method_31(90f))
				{
					GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: true, DropPlottedCourse: true, float_25);
				}
			}
			else
			{
				BlindTime += float_25;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100943", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_34()
	{
		bool result;
		try
		{
			bool flag;
			if (!Information.IsNothing((object)AI.PrimaryTarget))
			{
				if (!Information.IsNothing((object)AI.PrimaryTarget.ActualUnit))
				{
					Sensor sensorProvidingFireControlForMe = SensorProvidingFireControlForMe;
					flag = false;
					int num;
					if (Information.IsNothing((object)sensorProvidingFireControlForMe))
					{
						num = 1;
					}
					else
					{
						if (sensorProvidingFireControlForMe.Status == PlatformComponent._ComponentStatus.Operational)
						{
							Weapon_AI aI;
							Contact theTarget = (aI = AI).PrimaryTarget;
							bool num2 = sensorProvidingFireControlForMe.IsTrackingThisTargetForFireControl(ref theTarget);
							aI.PrimaryTarget = theTarget;
							if (!num2)
							{
								flag = true;
							}
							ActiveUnit parentPlatform = sensorProvidingFireControlForMe.ParentPlatform;
							theTarget = (aI = AI).PrimaryTarget;
							ref Scenario parentScen = ref ParentScen;
							float targetSlantRange = Module_Unit.RangeToUnit_Slant(sensorProvidingFireControlForMe.ParentPlatform, AI.PrimaryTarget.ActualUnit);
							bool isShip = sensorProvidingFireControlForMe.ParentPlatform.IsShip;
							bool isShip2 = sensorProvidingFireControlForMe.ParentPlatform.IsShip;
							bool? LOS_Exists_Radar = null;
							bool? LOS_Exists_RadarSW = null;
							LOSCheckResult? LOS_Exists_Visual = null;
							bool? LOS_Exists_Sonar = null;
							Sensor.SensorDetectionCheckResult num3 = sensorProvidingFireControlForMe.CanIlluminateTarget(parentPlatform, ref theTarget, ref parentScen, targetSlantRange, null, isShip, isShip2, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar);
							aI.PrimaryTarget = theTarget;
							if (num3 != Sensor.SensorDetectionCheckResult.Success)
							{
								flag = true;
							}
							goto IL_011b;
						}
						num = 1;
					}
					flag = (byte)num != 0;
					goto IL_011b;
				}
				result = true;
			}
			else
			{
				result = true;
			}
			goto end_IL_0001;
			IL_011b:
			if (flag)
			{
				if (!Information.IsNothing((object)FiringParent))
				{
					ActiveUnit_Sensory sensory = FiringParent.Sensory;
					Contact primaryTarget = AI.PrimaryTarget;
					bool? LOS_Exists_Sonar = null;
					bool? LOS_Exists_RadarSW = null;
					LOSCheckResult? LOS_Exists_Visual = null;
					bool? LOS_Exists_Radar = null;
					if (sensory.IlluminateThisContactForThisWeapon(primaryTarget, this, ref LOS_Exists_Sonar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Radar))
					{
						flag = false;
					}
				}
				if (flag && AttemptBuddyIllumination())
				{
					flag = false;
				}
			}
			result = flag;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100944", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num4;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num4 = 0;
			}
			else
			{
				num4 = 0;
			}
			result = (byte)num4 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_35(float float_25)
	{
		try
		{
			if (method_29(float_25))
			{
				return;
			}
			if (!method_34())
			{
				BlindTime = 0f;
				AI.PrimaryTarget.Age = 0f;
			}
			else
			{
				BlindTime += float_25;
			}
			if (ImpactsOnThisPulse_ActualUnit || ImpactsOnThisPulse_Contact)
			{
				if (AI.PrimaryTarget.get_IsDestroyed(ParentScen))
				{
					return;
				}
				if ((double)BlindTime > 0.5)
				{
					Contact_Base.ContactType type = AI.PrimaryTarget.Type;
					if (type > Contact_Base.ContactType.Missile && type != Contact_Base.ContactType.Orbital)
					{
						CEP_Surface = 200 * CEP_Surface * (int)Math.Round(BlindTime);
						CEP_Land = 200 * CEP_Land * (int)Math.Round(BlindTime);
						base.EndgameReport.AddEndGameMessage(hit: false, "Cannot have its target illuminated... will impact with severe accuracy reduction");
						return;
					}
					if (_Sensors.Count == 1)
					{
						base.EndgameReport.AddEndGameMessage(hit: false, "Cannot have its target illuminated...");
						AI.PrimaryTarget = null;
						return;
					}
				}
			}
			if (!method_31(90f))
			{
				GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: true, DropPlottedCourse: true, float_25);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100945", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_36(float float_25)
	{
		try
		{
			if (Navigator.HasPlottedCourse() || method_29(float_25))
			{
				return;
			}
			float closureSpeed = Module_Unit.ClosureSpeed(this, AI.PrimaryTarget, CurrentSpeed, CurrentHeading);
			if (method_34())
			{
				BlindTime += float_25;
			}
			else
			{
				BlindTime = 0f;
				AI.PrimaryTarget.Age = 0f;
			}
			if (ImpactsOnThisPulse_ActualUnit || ImpactsOnThisPulse_Contact)
			{
				if (AI.PrimaryTarget.get_IsDestroyed(ParentScen))
				{
					return;
				}
				if ((double)BlindTime > 0.5)
				{
					Contact_Base.ContactType type = AI.PrimaryTarget.Type;
					if (type > Contact_Base.ContactType.Missile && type != Contact_Base.ContactType.Orbital)
					{
						CEP_Surface = 200 * CEP_Surface;
						CEP_Land = 200 * CEP_Land;
						base.EndgameReport.AddEndGameMessage(hit: false, "Cannot have its target illuminated... will impact with severe accuracy reduction");
						return;
					}
					if (_Sensors.Count == 1)
					{
						base.EndgameReport.AddEndGameMessage(hit: false, "Cannot have its target illuminated...");
						AI.PrimaryTarget = null;
						return;
					}
				}
			}
			if (ETA_To_Location(closureSpeed, RangeToUnit_Horiz(AI.PrimaryTarget)) <= (float)Math.Max(10, IlluminationTime))
			{
				if (AI.PrimaryTarget.get_IsDestroyed(ParentScen))
				{
					return;
				}
				bool flag;
				if (!(flag = Information.IsNothing((object)DataLinkParent)))
				{
					if (!DataLinkParent.Sensory.IsIlluminatingThisContact(AI.PrimaryTarget))
					{
						method_34();
					}
				}
				else if (flag)
				{
					PooledList<ActiveUnit> pooledList = FetchAvailableBuddyIlluminatorUnits(((ActiveUnit)this).get_UnitSide(SetSideOnly: false), AI.PrimaryTarget);
					if (pooledList != null)
					{
						foreach (ActiveUnit item in pooledList)
						{
							if (item != null)
							{
								ActiveUnit_Sensory sensory = item.Sensory;
								Contact primaryTarget = AI.PrimaryTarget;
								bool? LOS_Exists_Radar = null;
								bool? LOS_Exists_RadarSW = null;
								LOSCheckResult? LOS_Exists_Visual = null;
								bool? LOS_Exists_Sonar = null;
								sensory.IlluminateThisContactForThisWeapon(primaryTarget, this, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar);
								break;
							}
						}
						pooledList.Dispose();
					}
				}
			}
			if (!method_31(90f) && Guidance != WeaponGuidanceType.Datalink_Plus_SemiActive)
			{
				GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: true, DropPlottedCourse: true, float_25);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100946", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_37(float float_25)
	{
		try
		{
			if (method_29(float_25))
			{
				return;
			}
			float closureSpeed = Module_Unit.ClosureSpeed(this, AI.PrimaryTarget, CurrentSpeed, CurrentHeading);
			if (ImpactsOnThisPulse_ActualUnit || ImpactsOnThisPulse_Contact)
			{
				if (AI.PrimaryTarget.get_IsDestroyed(ParentScen))
				{
					return;
				}
				if ((double)BlindTime > 0.5)
				{
					Contact_Base.ContactType type = AI.PrimaryTarget.Type;
					if (type > Contact_Base.ContactType.Missile && type != Contact_Base.ContactType.Orbital)
					{
						CEP_Surface = 200 * CEP_Surface;
						CEP_Land = 200 * CEP_Land;
						base.EndgameReport.AddEndGameMessage(hit: false, "Cannot have its target illuminated... will impact with severe accuracy reduction");
						return;
					}
					if (_Sensors.Count == 1)
					{
						base.EndgameReport.AddEndGameMessage(hit: false, "Cannot have its target illuminated...");
						AI.PrimaryTarget = null;
						return;
					}
				}
			}
			if (ETA_To_Location(closureSpeed, RangeToUnit_Horiz(AI.PrimaryTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)) <= (float)Math.Max(10, IlluminationTime))
			{
				if (AI.PrimaryTarget.get_IsDestroyed(ParentScen))
				{
					return;
				}
				bool flag = false;
				bool flag2;
				if (!(flag2 = DataLinkParent == null))
				{
					if (!DataLinkParent.Sensory.IsIlluminatingThisContact(AI.PrimaryTarget))
					{
						flag = method_34();
					}
				}
				else if (flag2)
				{
					PooledList<ActiveUnit> pooledList = FetchAvailableBuddyIlluminatorUnits(((ActiveUnit)this).get_UnitSide(SetSideOnly: false), AI.PrimaryTarget);
					if (pooledList != null)
					{
						foreach (ActiveUnit item in pooledList)
						{
							if (item != null)
							{
								ActiveUnit_Sensory sensory = item.Sensory;
								Contact primaryTarget = AI.PrimaryTarget;
								bool? LOS_Exists_Radar = null;
								bool? LOS_Exists_RadarSW = null;
								LOSCheckResult? LOS_Exists_Visual = null;
								bool? LOS_Exists_Sonar = null;
								sensory.IlluminateThisContactForThisWeapon(primaryTarget, this, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar);
								break;
							}
						}
						pooledList.Dispose();
					}
				}
				if (flag)
				{
					BlindTime += float_25;
				}
				else
				{
					BlindTime = 0f;
					AI.PrimaryTarget.Age = 0f;
				}
			}
			if (!method_31(90f) && Guidance != WeaponGuidanceType.Datalink_Plus_SemiActive)
			{
				GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: true, DropPlottedCourse: true, float_25);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100946", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CreateSalvo_Airborne(ref Weapon theWeapon, ref Contact theNewTarget, Scenario theScen)
	{
		try
		{
			foreach (WeaponSalvo weaponSalvo in ((ActiveUnit)theWeapon).get_UnitSide(SetSideOnly: false).WeaponSalvos)
			{
				WeaponSalvo theSalvo = weaponSalvo;
				if (theSalvo.Target != theNewTarget || theSalvo.int_1 != theWeapon.DBID)
				{
					continue;
				}
				WeaponSalvo.Shooter[] shootersList = theSalvo.ShootersList;
				foreach (WeaponSalvo.Shooter shooter in shootersList)
				{
					if (!Information.IsNothing((object)theWeapon.FiringParent) && Operators.CompareString(shooter.ShooterObjectID, theWeapon.FiringParent.ObjectID, false) == 0)
					{
						if (shooter.QuantityAssigned < int.MaxValue)
						{
							shooter.QuantityAssigned++;
						}
						if (shooter.QuantityFired < int.MaxValue)
						{
							shooter.QuantityFired++;
						}
						theSalvo.WeaponList.TryAdd(theWeapon.ObjectID, 0);
						if (theSalvo.MaxNumberOfWeapons != int.MaxValue)
						{
							theSalvo.MaxNumberOfWeapons++;
						}
						return;
					}
				}
				if (Information.IsNothing((object)theWeapon.FiringParent))
				{
					Side side = ((ActiveUnit)theWeapon).get_UnitSide(SetSideOnly: false);
					int? theToFireQuantity = 1;
					int? theAvailableQuantity = 1;
					string theShooterObjectID = "12456789";
					side.AddShooterToExistingSalvo(ref theSalvo, theToFireQuantity, 1, theAvailableQuantity, theManualFire: false, ref theShooterObjectID);
				}
				else
				{
					((ActiveUnit)theWeapon).get_UnitSide(SetSideOnly: false).AddShooterToExistingSalvo(ref theSalvo, 1, 1, 1, theManualFire: false, ref theWeapon.FiringParent.ObjectID);
				}
			}
			if (theWeapon.FiringParent == null)
			{
				Side side2 = ((ActiveUnit)theWeapon).get_UnitSide(SetSideOnly: false);
				int? theQuantity_ToFire = 1;
				int? theQuantity_Available = 1;
				string theShooterObjectID = "123456789";
				int? theShooterQty = 1;
				side2.AssignSalvoToTarget(theScen, ref theWeapon, ref theNewTarget, theQuantity_ToFire, 1, theQuantity_Available, theManualFire: false, ref theShooterObjectID, ref theShooterQty, DateTime.MinValue, DateTime.MinValue).WeaponList.TryAdd(theWeapon.ObjectID, 0);
			}
			else
			{
				Side side3 = ((ActiveUnit)theWeapon).get_UnitSide(SetSideOnly: false);
				int? theQuantity_ToFire2 = 1;
				int? theQuantity_Available2 = 1;
				ref string objectID = ref theWeapon.FiringParent.ObjectID;
				int? theShooterQty = 1;
				side3.AssignSalvoToTarget(theScen, ref theWeapon, ref theNewTarget, theQuantity_ToFire2, 1, theQuantity_Available2, theManualFire: false, ref objectID, ref theShooterQty, DateTime.MinValue, DateTime.MinValue).WeaponList.TryAdd(theWeapon.ObjectID, 0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 98332154365", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void AttemptRetargeting_Datalink(float elapsedTime, float OvershootThreshold_deg)
	{
		try
		{
			if (Type == _WeaponType.Sonobuoy)
			{
				return;
			}
			Contact contact = null;
			if (!Information.IsNothing((object)AI.PrimaryTarget))
			{
				contact = AI.PrimaryTarget;
				Weapon_AI aI = AI;
				ActiveUnit theAU = this;
				aI.ClearAllTargets(ref theAU);
				if (!Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					((ActiveUnit)this).set_DesiredHeading(TurnRate.Max, CurrentHeading);
				}
			}
			DatalinkRetargetTime += elapsedTime;
			double num = Math.Round(DatalinkRetargetTime, 1);
			if (num != 0.1 && num != 1.0 && num != 6.0 && num != 11.0 && (!(num > 11.0) || AI.PrimaryTarget_Type != Contact_Base.ContactType.ActivationPoint || num % 15.0 != 0.0))
			{
				return;
			}
			List<Contact> list = new List<Contact>();
			List<Contact> list2 = new List<Contact>();
			if (!Information.IsNothing((object)AI.PrimaryTarget_Type) && (AI.PrimaryTarget_Type == Contact_Base.ContactType.Air || AI.PrimaryTarget_Type == Contact_Base.ContactType.Missile || AI.PrimaryTarget_Type == Contact_Base.ContactType.Submarine || AI.PrimaryTarget_Type == Contact_Base.ContactType.Torpedo))
			{
				((ActiveUnit)this).get_UnitSide(SetSideOnly: false).RemoveWeaponFromSalvos(ref ParentScen, ref ObjectID);
			}
			if (DataLinkParent == null)
			{
				DatalinkRetargetTime = 0f;
				if (!HasGoneAutonomous)
				{
					GoAutonomous(clearPrimaryTarget: true, clearDatalink: true);
				}
				if (Guidance == WeaponGuidanceType.Datalink_Plus_Active)
				{
					if (!ReportedDatalinkLostConnectionIssue)
					{
						ReportedDatalinkLostConnectionIssue = true;
						AddMessage("Weapon: " + Name + " lost datalink connection... going autonomous.", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
				}
				else if (!ReportedDatalinkLostConnectionIssue)
				{
					ReportedDatalinkLostConnectionIssue = true;
					AddMessage("Weapon: " + Name + " lost datalink connection...", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
					AI.PrimaryTarget = null;
				}
				return;
			}
			Contact[] targets_ReadOnly = DataLinkParent.AI.Targets_ReadOnly;
			foreach (Contact contact2 in targets_ReadOnly)
			{
				string feedbackMessage = "";
				float value = Module_Unit.AngleOffThisUnitsBoresight(contact2, this, DistinguishBetweenStarboardAndPort: true, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
				if (Math.Abs(value) > OvershootThreshold_deg || contact == contact2)
				{
					continue;
				}
				bool? obj;
				if (contact2.get_Stance(DataLinkParent.get_UnitSide(SetSideOnly: false)) == Misc.PostureStance.Hostile)
				{
					obj = false;
				}
				else
				{
					byte? b = (byte?)DataLinkParent.Doctrine.get_WeaponControlStatus_Air(DataLinkParent.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
					bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0));
					obj = (!flag) ?? flag;
				}
				bool? flag2 = obj;
				if ((!((!flag2) ?? false) && !contact2.IsSubmergedContact && flag2.HasValue) || !DataLinkParent.AI.IsClearedToEngageThisTarget(contact2) || (!(Math.Abs(value) <= 20f) && !contact2.IsBallisticTarget() && !contact2.IsOrbitalContact))
				{
					continue;
				}
				float num2 = ((contact2.CurrentSpeed != 0f) ? Module_Unit.ClosureSpeed(this, contact2, CurrentSpeed, CurrentHeading) : CurrentSpeed);
				if (RangeToUnit_Horiz(contact2, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) / (num2 / 3600f) < 3f)
				{
					continue;
				}
				try
				{
					if (DataLinkParent == null || Operators.CompareString(DataLinkParent.Weaponry.CanThisWeaponEngageThisTarget_AttemptRetargeting(this, contact2), "OK", false) != 0)
					{
						continue;
					}
					goto IL_048f;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200048", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					goto IL_048f;
				}
				IL_048f:
				if (!Information.IsNothing((object)AI.PrimaryTarget_Type) && contact2.Type == AI.PrimaryTarget_Type)
				{
					list.Add(contact2);
				}
				else
				{
					list2.Add(contact2);
				}
			}
			Weapon theWeapon;
			Contact theNewTarget;
			Weapon_AI aI2;
			switch (list.Count)
			{
			case 1:
				BlindTime = 0f;
				DatalinkRetargetTime = 0f;
				AI.PrimaryTarget = list[0];
				theWeapon = this;
				theNewTarget = (aI2 = AI).PrimaryTarget;
				CreateSalvo_Airborne(ref theWeapon, ref theNewTarget, ParentScen);
				aI2.PrimaryTarget = theNewTarget;
				AddMessage("Weapon: " + Name + " has only one alternative target to be redirected to: " + AI.PrimaryTarget.Name, "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
				return;
			case 0:
				AddMessage("Weapon: " + Name + " has no eligible alternative target to be redirected to...", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
				switch (list2.Count)
				{
				default:
				{
					BlindTime = 0f;
					DatalinkRetargetTime = 0f;
					IEnumerable<Contact> source = from theC in list2
						orderby theC.IncomingGuidedWeapons.Length, Module_Unit.RangeToUnit_Horiz_Angular(this, theC, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)
						select theC;
					AI.PrimaryTarget = source.ElementAtOrDefault(0);
					theWeapon = this;
					theNewTarget = (aI2 = AI).PrimaryTarget;
					CreateSalvo_Airborne(ref theWeapon, ref theNewTarget, ParentScen);
					aI2.PrimaryTarget = theNewTarget;
					if (!Information.IsNothing((object)contact) && contact == AI.PrimaryTarget)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						AddMessage("Weapon: " + Name + " has been redirected to new target: " + AI.PrimaryTarget.Name, "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
					break;
				}
				case 1:
					BlindTime = 0f;
					DatalinkRetargetTime = 0f;
					AI.PrimaryTarget = list2[0];
					theWeapon = this;
					theNewTarget = (aI2 = AI).PrimaryTarget;
					CreateSalvo_Airborne(ref theWeapon, ref theNewTarget, ParentScen);
					aI2.PrimaryTarget = theNewTarget;
					AddMessage("Weapon: " + Name + " has only one alternative (secondary) target to be redirected to: " + AI.PrimaryTarget.Name, "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
					break;
				case 0:
					if (AI.PrimaryTarget_Type != Contact_Base.ContactType.Surface && AI.PrimaryTarget_Type != Contact_Base.ContactType.Submarine && AI.PrimaryTarget_Type != Contact_Base.ContactType.Facility_Fixed && AI.PrimaryTarget_Type != Contact_Base.ContactType.Facility_Mobile && AI.PrimaryTarget_Type != Contact_Base.ContactType.AggregateGroundUnit)
					{
						if (!(DatalinkRetargetTime >= 11f))
						{
							break;
						}
						if (IsAAWCapable)
						{
							GoAutonomous(clearPrimaryTarget: true, clearDatalink: true, clearPlottedCourse: true);
							if (Guidance != WeaponGuidanceType.Active && Guidance != WeaponGuidanceType.Passive && Guidance != WeaponGuidanceType.SemiActive_Plus_Active && Guidance != WeaponGuidanceType.TimesharedSemiActive_Plus_Active && _Sensors.Count <= 1)
							{
								AddMessage("Weapon: " + Name + " has no eligible alternative target to be redirected to...", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
							}
							else
							{
								AddMessage("Weapon: " + Name + " has no eligible alternative target to be redirected to... going autonomous.", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
							}
						}
						else if (AI.PrimaryTarget_Type != Contact_Base.ContactType.ActivationPoint)
						{
							GoAutonomous(clearPrimaryTarget: true, clearDatalink: true, clearPlottedCourse: true);
							return;
						}
					}
					else
					{
						if (_Sensors.Count > 0 && ValidTargets.Radar && Is_LOAL_capable)
						{
							GoAutonomous(clearPrimaryTarget: true, clearDatalink: true, clearPlottedCourse: true);
							return;
						}
						GoDumb();
					}
					break;
				}
				if (!Information.IsNothing((object)AI.PrimaryTarget) && Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					Navigator.ComputeTerminalPoint(Kinematics.GetMaximumSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false), IsAirdroppedTorpedo: false);
					if (Navigator.Has_NonPathfind_NonFP_PlottedCourse())
					{
						((ActiveUnit)this).set_DesiredHeading(TurnRate.Max, Math2.CalcAzimuth(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), Navigator.PlottedCourse[0].Latitude, Navigator.PlottedCourse[0].Longitude));
					}
				}
				return;
			}
			BlindTime = 0f;
			DatalinkRetargetTime = 0f;
			IEnumerable<Contact> source2 = from theC in list
				orderby theC.IncomingGuidedWeapons.Length, Module_Unit.RangeToUnit_Horiz_Angular(this, theC, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)
				select theC;
			AI.PrimaryTarget = source2.ElementAtOrDefault(0);
			theWeapon = this;
			theNewTarget = (aI2 = AI).PrimaryTarget;
			CreateSalvo_Airborne(ref theWeapon, ref theNewTarget, ParentScen);
			aI2.PrimaryTarget = theNewTarget;
			if (!Information.IsNothing((object)contact) && contact == AI.PrimaryTarget)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else
			{
				AddMessage("Weapon: " + Name + " has been redirected to new target: " + AI.PrimaryTarget.Name, "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100947", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AttemptRetargeting_Beamrider(float elapsedTime)
	{
		try
		{
			ActiveUnit parentPlatform = SensorProvidingFireControlForMe.ParentPlatform;
			if (!Information.IsNothing((object)AI.PrimaryTarget))
			{
				Weapon_AI aI = AI;
				ActiveUnit theAU = this;
				aI.ClearAllTargets(ref theAU);
				if (!Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					((ActiveUnit)this).set_DesiredHeading(TurnRate.Max, CurrentHeading);
				}
			}
			DatalinkRetargetTime += elapsedTime;
			double num = Math.Round(DatalinkRetargetTime, 1);
			if (num != 0.1 && num != 1.0 && num != 6.0 && num != 11.0)
			{
				return;
			}
			List<Contact> list = new List<Contact>();
			Contact[] targets_ReadOnly = parentPlatform.AI.Targets_ReadOnly;
			foreach (Contact contact in targets_ReadOnly)
			{
				float relativeBearing = MathFunctions.GetRelativeBearing(CurrentHeading, Math2.CalcAzimuth(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null)));
				if (!(340f > relativeBearing) || !(relativeBearing > 20f))
				{
					list.Add(contact);
				}
			}
			switch (list.Count)
			{
			default:
			{
				DatalinkRetargetTime = 0f;
				AI.PrimaryTarget = AI.GetNearestTarget(list);
				Weapon theWeapon = this;
				Weapon_AI aI2;
				Contact theNewTarget = (aI2 = AI).PrimaryTarget;
				CreateSalvo_Airborne(ref theWeapon, ref theNewTarget, ParentScen);
				aI2.PrimaryTarget = theNewTarget;
				break;
			}
			case 1:
			{
				DatalinkRetargetTime = 0f;
				AI.PrimaryTarget = list[0];
				Weapon theWeapon = this;
				Weapon_AI aI2;
				Contact theNewTarget = (aI2 = AI).PrimaryTarget;
				CreateSalvo_Airborne(ref theWeapon, ref theNewTarget, ParentScen);
				aI2.PrimaryTarget = theNewTarget;
				break;
			}
			case 0:
				if (DatalinkRetargetTime >= 11f)
				{
					DatalinkRetargetTime = 0f;
					AI.PrimaryTarget = null;
					AddMessage("Weapon: " + Name + " has no eligible alternative target to be redirected to...", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100948", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool IsNominallySuitableForThisTarget(ActiveUnit theAttackingUnit, ref Contact theTarget, ref GlobalVariables.BooleanObject TargetIsDestroyed)
	{
		bool result;
		if (theTarget != null)
		{
			if (theTarget.ActualUnit == null)
			{
				result = BOL_Capable;
			}
			else
			{
				Scenario parentScen = theTarget.ActualUnit.ParentScen;
				bool flag = false;
				if (theTarget == null)
				{
					result = false;
				}
				else
				{
					try
					{
						if (IsWeaponPallet)
						{
							Warhead[] warheads = Warheads;
							int num = 0;
							while (num < warheads.Length)
							{
								Warhead warhead = warheads[num];
								if (warhead.get_CarriedWeapon(parentScen) == null)
								{
									num = checked(num + 1);
									continue;
								}
								result = warhead.get_CarriedWeapon(parentScen).IsNominallySuitableForThisTarget(theAttackingUnit, ref theTarget, ref TargetIsDestroyed);
								goto end_IL_0038;
							}
						}
						if (!IsFuelTank)
						{
							if (theTarget.Type != Contact_Base.ContactType.Aimpoint && theTarget.Type != Contact_Base.ContactType.ActivationPoint)
							{
								switch (theTarget.Type)
								{
								case Contact_Base.ContactType.Air:
									result = MaxAirRange > 0f;
									break;
								case Contact_Base.ContactType.Surface:
									result = MaxSurfaceRange > 0f;
									break;
								case Contact_Base.ContactType.Submarine:
								{
									ActiveUnit actualUnit = theTarget.ActualUnit;
									result = ((actualUnit == null || actualUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) != 0f) ? (MaxSubsurfaceRange > 0f) : (!(MaxSurfaceRange <= 0f) || MaxSubsurfaceRange > 0f));
									break;
								}
								default:
									if (IsDecoy && Type != _WeaponType.Decoy_Vehicle)
									{
										Contact_Base.ContactType type = theTarget.Type;
										if (type != Contact_Base.ContactType.Missile && type - 9 > Contact_Base.ContactType.Missile)
										{
											result = false;
											break;
										}
										ActiveUnit actualUnit2 = theTarget.ActualUnit;
										if (actualUnit2 != null)
										{
											if (actualUnit2.IsWeapon)
											{
												foreach (Sensor sensor in ((Weapon)actualUnit2)._Sensors)
												{
													if (method_38(sensor))
													{
														if (TargetIsDestroyed == null)
														{
															TargetIsDestroyed = Misc.ToBooleanObject(theTarget.get_IsDestroyed(parentScen));
														}
														result = TargetIsDestroyed == GlobalVariables.ObjectFalse;
														goto end_IL_00b8;
													}
												}
											}
											result = false;
										}
										else
										{
											result = false;
										}
										break;
									}
									if (ValidTargets.Radar)
									{
										if (theTarget.HasDetectedEmissions)
										{
											int num2 = 0;
											int[] array = theTarget.DetectedEmissions.Keys.ToArray();
											foreach (int key in array)
											{
												try
												{
													if (theTarget.DetectedEmissions[key].Age < 30f || Flags.ARMTargetMemory || theTarget.IsAutoDetection)
													{
														num2++;
													}
												}
												catch (Exception projectError)
												{
													ProjectData.SetProjectError(projectError);
													ProjectData.ClearProjectError();
												}
											}
											if (num2 > 0)
											{
												if (MaxAirRange > 0f)
												{
													if (theTarget.Type == Contact_Base.ContactType.Air)
													{
														if (TargetIsDestroyed == null)
														{
															TargetIsDestroyed = Misc.ToBooleanObject(theTarget.get_IsDestroyed(parentScen));
														}
														result = TargetIsDestroyed == GlobalVariables.ObjectFalse;
														break;
													}
												}
												else if (MaxSurfaceRange > 0f && (theTarget.Type == Contact_Base.ContactType.Facility_Fixed || theTarget.Type == Contact_Base.ContactType.Facility_Mobile || theTarget.Type == Contact_Base.ContactType.Surface || theTarget.Type == Contact_Base.ContactType.AggregateGroundUnit))
												{
													if (TargetIsDestroyed == null)
													{
														TargetIsDestroyed = Misc.ToBooleanObject(theTarget.get_IsDestroyed(parentScen));
													}
													result = TargetIsDestroyed == GlobalVariables.ObjectFalse;
													break;
												}
											}
										}
										else if (theTarget.ActualUnit != null)
										{
											if (theTarget.IDStatus >= Contact_Base.IdentificationStatus.KnownClass && theTarget.ActualUnit.Sensors_Cached.Where([SpecialName] (Sensor theS) => theS.Type == Sensor.Sensor_Type.Radar && theS.Status == PlatformComponent._ComponentStatus.Operational).Count() > 0)
											{
												if (TargetIsDestroyed == null)
												{
													TargetIsDestroyed = Misc.ToBooleanObject(theTarget.get_IsDestroyed(parentScen));
												}
												result = TargetIsDestroyed == GlobalVariables.ObjectFalse;
												break;
											}
											if (!ValidTargets.MultipleTypes)
											{
												result = false;
												break;
											}
										}
										else if (!ValidTargets.MultipleTypes)
										{
											result = false;
											break;
										}
									}
									switch (theTarget.Type)
									{
									case Contact_Base.ContactType.Air:
										switch (theTarget.IDStatus)
										{
										default:
											if (theTarget.ActualUnit != null)
											{
												if (!theTarget.ActualUnit.IsAircraft)
												{
													if (ValidTargets.Aircraft)
													{
														flag = true;
													}
												}
												else if (((Aircraft)theTarget.ActualUnit).IsLighterThanAir)
												{
													if (IsAAWCapable)
													{
														flag = true;
													}
													if ((IsASuW_Land || IsASuW_Naval) && Type == _WeaponType.GuidedWeapon)
													{
														flag = true;
													}
												}
												else if (ValidTargets.Aircraft)
												{
													flag = true;
												}
												break;
											}
											result = false;
											goto end_IL_0400;
										case Contact_Base.IdentificationStatus.KnownDomain:
											result = IsAAWCapable;
											goto end_IL_0400;
										case Contact_Base.IdentificationStatus.Unknown:
											result = IsAAWCapable;
											goto end_IL_0400;
										}
										goto default;
									case Contact_Base.ContactType.Missile:
										if (theTarget.ActualUnit != null)
										{
											if (theTarget.ActualUnit.IsMissile && ValidTargets.Missile)
											{
												flag = true;
											}
											if ((object)theTarget.ActualUnit.GetType() == typeof(UnguidedRocket) && ValidTargets.RAMB)
											{
												flag = true;
											}
											if (IsLaserShot)
											{
												if (TargetIsDestroyed == null)
												{
													TargetIsDestroyed = Misc.ToBooleanObject(theTarget.get_IsDestroyed(parentScen));
												}
												result = TargetIsDestroyed == GlobalVariables.ObjectFalse;
												break;
											}
											if (((Weapon)theTarget.ActualUnit).IsAAWCapable)
											{
												if (((Weapon)(theTarget?.ActualUnit))?.AI?.PrimaryTarget?.ActualUnit != null)
												{
													bool? flag3;
													bool? flag2 = (flag3 = ((Weapon)theTarget.ActualUnit)?.AI?.PrimaryTarget?.ActualUnit?.IsShip);
													bool? obj;
													if (flag2.HasValue && flag3 == true)
													{
														obj = true;
													}
													else
													{
														bool? flag4 = (flag2 = ((Weapon)theTarget.ActualUnit)?.AI?.PrimaryTarget?.ActualUnit?.IsSubmarine);
														bool? obj2;
														bool? flag5;
														if (flag4.HasValue && flag2 != true)
														{
															obj2 = false;
														}
														else
														{
															flag4 = (flag5 = ((Submarine)(((Weapon)theTarget.ActualUnit)?.AI?.PrimaryTarget?.ActualUnit))?.IsSurfaced);
															obj2 = ((!flag4.HasValue) ? ((bool?)null) : ((flag5 == true) & flag2));
														}
														bool? flag6 = obj2;
														flag5 = obj2;
														obj = ((!flag5.HasValue) ? ((bool?)null) : ((flag6 == true) | flag3));
													}
													bool? flag7 = obj;
													if (((!flag7) ?? flag7) == true)
													{
														flag = false;
													}
												}
												else
												{
													flag = false;
												}
											}
											goto default;
										}
										result = false;
										break;
									case Contact_Base.ContactType.Surface:
									{
										if (ValidTargets.SurfaceVessel)
										{
											flag = true;
										}
										ActiveUnit actualUnit3 = theTarget.ActualUnit;
										if (actualUnit3 == null)
										{
											result = false;
											break;
										}
										if (ValidTargets.Submarine && actualUnit3.IsSubmarine && actualUnit3.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) == 0f)
										{
											flag = true;
										}
										goto default;
									}
									case Contact_Base.ContactType.Submarine:
										if (ValidTargets.Submarine)
										{
											flag = true;
										}
										if (((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) == 0f && ValidTargets.SurfaceVessel)
										{
											flag = true;
										}
										goto default;
									case Contact_Base.ContactType.Aimpoint:
										result = ValidTargets.LandStructure_Hard || ValidTargets.LandStructure_Soft || ValidTargets.Runway;
										break;
									case Contact_Base.ContactType.Orbital:
										result = ValidTargets.Satellite;
										break;
									case Contact_Base.ContactType.Facility_Fixed:
										if (theTarget.ActualUnit != null)
										{
											if (!theTarget.ActualUnit.IsUnderwater)
											{
												switch (((Facility)theTarget.ActualUnit).Category)
												{
												default:
													result = ValidTargets.LandStructure_Hard || ValidTargets.LandStructure_Soft;
													break;
												case Facility._FacilityCategory.AirBase:
													result = false;
													break;
												case Facility._FacilityCategory.Water_Surface:
													result = ValidTargets.LandStructure_Hard || ValidTargets.LandStructure_Soft || ValidTargets.SurfaceVessel;
													break;
												case Facility._FacilityCategory.Runway:
												case Facility._FacilityCategory.RunwayGrade_Taxiway:
												case Facility._FacilityCategory.RunwayAccessPoint:
													result = ValidTargets.Runway;
													break;
												}
												break;
											}
											_WeaponType type2 = Type;
											if ((uint)(type2 - 4001) <= 1u)
											{
												if (TargetIsDestroyed == null)
												{
													TargetIsDestroyed = Misc.ToBooleanObject(theTarget.get_IsDestroyed(parentScen));
												}
												result = TargetIsDestroyed == GlobalVariables.ObjectFalse;
											}
											else
											{
												result = false;
											}
										}
										else
										{
											result = false;
										}
										break;
									case Contact_Base.ContactType.Facility_Mobile:
										result = ValidTargets.MobileTarget_Hard || ValidTargets.MobileTarget_Soft || ((ValidTargets.LandStructure_Hard || ValidTargets.LandStructure_Soft) && theTarget.CurrentSpeed == 0f);
										break;
									case Contact_Base.ContactType.Torpedo:
										result = ValidTargets.Torpedo;
										break;
									case Contact_Base.ContactType.Decoy_Air:
										if (ValidTargets.Aircraft && theTarget.DetectedEmissions.Count != 0)
										{
											foreach (KeyValuePair<int, EmissionContainer> detectedEmission in theTarget.DetectedEmissions)
											{
												if (detectedEmission.Value.get_AssociatedSensor(detectedEmission.Key, parentScen).IsOECM)
												{
													flag = true;
												}
											}
										}
										goto default;
									default:
										if (!flag)
										{
											result = false;
											break;
										}
										if (TargetIsDestroyed == null)
										{
											TargetIsDestroyed = Misc.ToBooleanObject(theTarget.get_IsDestroyed(parentScen));
										}
										result = TargetIsDestroyed == GlobalVariables.ObjectFalse;
										break;
									case Contact_Base.ContactType.ActivationPoint:
										{
											result = ValidTargets.SurfaceVessel;
											break;
										}
										end_IL_0400:
										break;
									}
									break;
								case Contact_Base.ContactType.Facility_Fixed:
									result = MaxLandRange > 0f && ValidTargets.FixedFacility();
									break;
								case Contact_Base.ContactType.Facility_Mobile:
								case Contact_Base.ContactType.AggregateGroundUnit:
									{
										result = ((theTarget.CurrentSpeed != 0f) ? (MaxLandRange > 0f && ValidTargets.MobileFacility()) : (MaxLandRange > 0f));
										break;
									}
									end_IL_00b8:
									break;
								}
							}
							else
							{
								int num3;
								switch (Type)
								{
								case _WeaponType.HeliTowedPackage:
									num3 = 0;
									break;
								default:
									if (TargetIsDestroyed == null)
									{
										TargetIsDestroyed = Misc.ToBooleanObject(theTarget.get_IsDestroyed(parentScen));
									}
									result = TargetIsDestroyed == GlobalVariables.ObjectFalse;
									goto end_IL_0038;
								case _WeaponType.Decoy_Expendable:
								case _WeaponType.Decoy_Towed:
								case _WeaponType.TrainingRound:
								case _WeaponType.SensorPod:
								case _WeaponType.DropTank:
								case _WeaponType.BuddyStore:
								case _WeaponType.FerryTank:
									num3 = 0;
									break;
								}
								result = (byte)num3 != 0;
							}
						}
						else
						{
							result = false;
						}
						end_IL_0038:;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200276", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						int num4;
						if (!Debugger.IsAttached)
						{
							num4 = 0;
						}
						else
						{
							Debugger.Break();
							num4 = 0;
						}
						result = (byte)num4 != 0;
						ProjectData.ClearProjectError();
					}
				}
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	internal bool IsWithinMaxRangeOfTarget(float TargetRange, Contact theTarget)
	{
		return method_21(theTarget.Type) >= TargetRange;
	}

	public bool CanBeFiredOnAmbigousTarget(Contact theTarget, bool GunDirectorFound)
	{
		bool result;
		try
		{
			if (!theTarget.isSurfaceOrLandContact && !theTarget.ActualUnit.IsSubmarine && !theTarget.ActualUnit.IsTorpedo)
			{
				goto IL_00de;
			}
			if (Is_LOAL_capable)
			{
				WeaponGuidanceType guidance = Guidance;
				result = (uint)(guidance - 2) > 1u;
			}
			else if (!Flags.BearingOnlyLaunch)
			{
				if (!ValidTargets.Radar)
				{
					if (!Flags.IlluminateAtLaunch)
					{
						_WeaponType type = Type;
						if ((uint)(type - 2002) > 2u)
						{
							if (Comms_ReadOnly.Count() <= 0 || _Sensors.Count <= 0)
							{
								goto IL_00cd;
							}
							int num;
							if (theTarget.IsGroundContact)
							{
								num = 1;
							}
							else if (theTarget.isSurfaceOrLandContact)
							{
								num = 1;
							}
							else
							{
								if (!theTarget.IsSubmergedContact)
								{
									goto IL_00cd;
								}
								num = 1;
							}
							result = (byte)num != 0;
						}
						else
						{
							int num2;
							switch (theTarget.Type)
							{
							case Contact_Base.ContactType.AggregateGroundUnit:
								num2 = 1;
								break;
							case Contact_Base.ContactType.Surface:
								result = false;
								goto end_IL_0001;
							default:
								result = GunDirectorFound;
								goto end_IL_0001;
							case Contact_Base.ContactType.Submarine:
							case Contact_Base.ContactType.Aimpoint:
							case Contact_Base.ContactType.Facility_Fixed:
							case Contact_Base.ContactType.Facility_Mobile:
							case Contact_Base.ContactType.Torpedo:
								num2 = 1;
								break;
							}
							result = (byte)num2 != 0;
						}
					}
					else
					{
						result = true;
					}
				}
				else
				{
					result = true;
				}
			}
			else
			{
				result = true;
			}
			goto end_IL_0001;
			IL_00cd:
			if (Guidance != WeaponGuidanceType.Inertial)
			{
				goto IL_00de;
			}
			result = true;
			goto end_IL_0001;
			IL_00de:
			result = false;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100950", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num3 = 0;
			}
			else
			{
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal bool IsWithinMinRangeOfTarget(Contact theTarget)
	{
		float num = MinRangeForTarget(theTarget);
		if (num == 0f)
		{
			return false;
		}
		if (IsGuidedOrUnguidedGun())
		{
			return num > Module_Unit.RangeToUnit_Slant(this, theTarget, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
		}
		return num > RangeToUnit_Horiz(theTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
	}

	internal bool IsWithinMinRangeOfTarget(float TargetRange, Contact theTarget)
	{
		int result;
		switch (theTarget.Type)
		{
		default:
			result = 0;
			goto IL_00a5;
		case Contact_Base.ContactType.Surface:
		case Contact_Base.ContactType.UndeterminedNaval:
			return MinSurfaceRange > TargetRange;
		case Contact_Base.ContactType.Aimpoint:
		case Contact_Base.ContactType.ActivationPoint:
			if (!Module_Unit.IsOverLand(theTarget) && (MaxSurfaceRange != 0f || MaxLandRange <= 0f))
			{
				return MinSurfaceRange > TargetRange;
			}
			return MinLandRange > TargetRange;
		case Contact_Base.ContactType.Air:
		case Contact_Base.ContactType.Missile:
		case Contact_Base.ContactType.Orbital:
			return MinAirRange > TargetRange;
		case Contact_Base.ContactType.Facility_Fixed:
		case Contact_Base.ContactType.Facility_Mobile:
		case Contact_Base.ContactType.AggregateGroundUnit:
			return MinLandRange > TargetRange;
		case Contact_Base.ContactType.Torpedo:
			result = 0;
			goto IL_00a5;
		case Contact_Base.ContactType.Submarine:
		case Contact_Base.ContactType.Mine:
			{
				return MinSubsurfaceRange > TargetRange;
			}
			IL_00a5:
			return (byte)result != 0;
		}
	}

	internal float MinRangeForTarget(Contact theTarget)
	{
		switch (theTarget.Type)
		{
		case Contact_Base.ContactType.Surface:
		case Contact_Base.ContactType.UndeterminedNaval:
			return MinSurfaceRange;
		case Contact_Base.ContactType.Air:
		case Contact_Base.ContactType.Missile:
		case Contact_Base.ContactType.Orbital:
			return MinAirRange;
		case Contact_Base.ContactType.Facility_Fixed:
		case Contact_Base.ContactType.Facility_Mobile:
		case Contact_Base.ContactType.AggregateGroundUnit:
			return MinLandRange;
		default:
			return 0f;
		case Contact_Base.ContactType.Submarine:
		case Contact_Base.ContactType.Mine:
			return MinSubsurfaceRange;
		}
	}

	internal bool AboutToImpact(Module_Unit.Unit theTarget, float elapsedTime, bool CheckDistranceBasedOnClosureSpeed = false)
	{
		bool result;
		try
		{
			float attitude_Pitch = Attitude_Pitch;
			if (AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint && Guidance != WeaponGuidanceType.Inertial)
			{
				result = false;
			}
			else
			{
				if (AI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint)
				{
					goto IL_00b7;
				}
				if (!IsAAWCapable)
				{
					if ((!IsASuW_Naval && !IsASuW_Land) || Guidance == WeaponGuidanceType.Inertial || AI.PrimaryTarget_Type == Contact_Base.ContactType.Surface || AI.PrimaryTarget_Type == Contact_Base.ContactType.Submarine || AI.PrimaryTarget_Type == Contact_Base.ContactType.Facility_Fixed || AI.PrimaryTarget_Type == Contact_Base.ContactType.Facility_Mobile || AI.PrimaryTarget_Type == Contact_Base.ContactType.AggregateGroundUnit)
					{
						goto IL_00b7;
					}
					result = false;
				}
				else
				{
					result = false;
				}
			}
			goto end_IL_0001;
			IL_04a7:
			bool flag = default(bool);
			if (!flag)
			{
				goto IL_07ec;
			}
			float num2;
			float num3;
			if (Warheads.Length > 0 && Warheads[0].IsCluster)
			{
				result = true;
			}
			else if (base.IsMissile && AI.PrimaryTarget.IsSubmergedContact)
			{
				result = true;
			}
			else if (base.IsMissile && Warheads.Count() > 0 && (Warheads[0].Type == Warhead.WarheadType.Weapon || Warheads[0].Type == Warhead.WarheadType.Nuclear) && !Module_Unit.IsOverLand(this))
			{
				result = true;
			}
			else if (SupportsAttitude_Pitch)
			{
				if ((int)Math.Round(ImpactAltitude) == (int)Math.Round(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))
				{
					result = true;
				}
				else
				{
					double num = (double)((num2 - 1f) * num3) * 1852.0;
					if ((double)Math.Abs(ImpactAltitude - this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < (double)RangeToUnit_Horiz(theTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) * 1852.0 + num)
					{
						result = true;
					}
					else
					{
						if (!(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < ImpactAltitude))
						{
							goto IL_0600;
						}
						int num4;
						if (!AI.PrimaryTarget.IsLandContact)
						{
							if (!AI.PrimaryTarget.isSurfaceOrLandContact)
							{
								goto IL_0600;
							}
							num4 = 1;
						}
						else
						{
							num4 = 1;
						}
						result = (byte)num4 != 0;
					}
				}
			}
			else
			{
				float minimumAltitude = Kinematics.GetMinimumAltitude();
				result = (base.IsMissile && ImpactAltitude < minimumAltitude && this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= minimumAltitude + 25f) || (!(ImpactAltitude > Kinematics.GetMaximumAltitude()) && !(ImpactAltitude < minimumAltitude));
			}
			goto end_IL_0001;
			IL_00b7:
			if (!Flags.ReAttack_Capability)
			{
				goto IL_00f4;
			}
			float num5 = Module_Unit.BearingToPoint_Relative(this, theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null));
			if (!(num5 > 90f) || !(num5 < 270f))
			{
				goto IL_00f4;
			}
			result = false;
			goto end_IL_0001;
			IL_0600:
			float attitude_Pitch2 = Attitude_Pitch;
			if ((int)Math.Round(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < (int)Math.Round(ImpactAltitude))
			{
				if (DesiredPitch > 0f)
				{
					Attitude_Pitch = DesiredPitch;
				}
				float num6 = Kinematics.ClimbRate_Actual(attitude_Pitch2) * num2;
				if (num6 * 2f >= ImpactAltitude - this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
				{
					result = true;
				}
				else
				{
					if (!theTarget.SupportsAttitude_Pitch || !(theTarget.Attitude_Pitch < 0f))
					{
						goto IL_07ec;
					}
					float num7 = (float)((double)theTarget.CurrentSpeed * Math2.Sind(theTarget.Attitude_Pitch) * (double)num2);
					if (!(num6 - num7 >= ImpactAltitude - this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))
					{
						goto IL_07ec;
					}
					result = true;
				}
			}
			else if ((int)Math.Round(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) > (int)Math.Round(ImpactAltitude))
			{
				if (DesiredPitch < 0f)
				{
					Attitude_Pitch = DesiredPitch;
				}
				float num8 = Kinematics.DiveRate_Actual(attitude_Pitch2) * num2;
				if (num8 * 2f >= this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - ImpactAltitude)
				{
					result = true;
				}
				else
				{
					if (!theTarget.SupportsAttitude_Pitch || !(theTarget.Attitude_Pitch > 0f))
					{
						goto IL_07ec;
					}
					float num9 = (float)((double)theTarget.CurrentSpeed * Math2.Sind(theTarget.Attitude_Pitch) * (double)num2);
					if (!(num8 + num9 >= this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - ImpactAltitude))
					{
						goto IL_07ec;
					}
					result = true;
				}
			}
			else
			{
				result = true;
			}
			goto end_IL_0001;
			IL_07ec:
			Attitude_Pitch = attitude_Pitch;
			result = false;
			goto end_IL_0001;
			IL_00f4:
			if (RangeToUnit_Horiz(theTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) > 10f)
			{
				result = false;
			}
			else
			{
				num2 = 1f;
				if (elapsedTime != 0.1f)
				{
					num2 += elapsedTime;
				}
				float num10 = default(float);
				if (IsTorpedo || Guidance != WeaponGuidanceType.Inertial)
				{
					num10 = Module_Unit.ClosureSpeed(this, theTarget, Module_Unit.CurrentSpeed_Horizontal(this), CurrentHeading);
				}
				num3 = num10 / 3600f;
				if (Navigator.HasPlottedCourse() && ((Guidance == WeaponGuidanceType.Inertial && !IsTorpedo) || (!Information.IsNothing((object)AI.PrimaryTarget.Type) && HasTorpedoPayload && (AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine || AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint || AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint))))
				{
					Waypoint thePoint = Navigator.PlottedCourse[Navigator.PlottedCourse.Count() - 1];
					float num11 = Module_Unit.RangeToPoint_Horiz(this, thePoint, GlobalVariables.ObjectTrue);
					float num12 = CurrentSpeed / 3600f * num2;
					if (num11 <= num12)
					{
						flag = true;
						num3 = num12;
					}
					goto IL_04a7;
				}
				if (!(num3 >= 0f))
				{
					goto IL_04a7;
				}
				if (!IsTorpedo || (!theTarget.IsSubmarine && (!theTarget.IsContact() || !((Contact)theTarget).IsSubmergedContact)) || !(Math.Abs(Math.Abs(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) - Math.Abs(theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) > 15f))
				{
					float distance_NM = theTarget.get_HorizMovementDistanceOnThisTime(num2);
					double out_lon = default(double);
					double out_lat = default(double);
					Geodesic_EdWilliams.CalcPoint_Williams(theTarget.get_Longitude((GlobalVariables.BooleanObject)null), theTarget.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, distance_NM, theTarget.CurrentHeading);
					float num13 = Math2.CalcDist(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon);
					float num14 = Module_Unit.CurrentSpeed_Horizontal(this) / 3600f * num2;
					if (num13 <= num14)
					{
						flag = true;
					}
					else if (num13 - num14 < 0.5f * num2)
					{
						float num15 = 0.1f;
						int num16 = Math.Max((int)Math.Round(num2 / num15), 1);
						float distance_NM2 = theTarget.get_HorizMovementDistanceOnThisTime(num15);
						float distance_NM3 = Module_Unit.CurrentSpeed_Horizontal(this) / 3600f * num15;
						double out_lat2 = theTarget.get_Latitude((GlobalVariables.BooleanObject)null);
						double out_lon2 = theTarget.get_Longitude((GlobalVariables.BooleanObject)null);
						double out_lat3 = this.get_Latitude((GlobalVariables.BooleanObject)null);
						double out_lon3 = this.get_Longitude((GlobalVariables.BooleanObject)null);
						float num17 = Math2.CalcDist(out_lat3, out_lon3, out_lat2, out_lon2);
						int num18 = num16;
						for (int i = 0; i <= num18; i++)
						{
							Geodesic_EdWilliams.CalcPoint_Williams(out_lon2, out_lat2, ref out_lon2, ref out_lat2, distance_NM2, theTarget.CurrentHeading);
							Geodesic_EdWilliams.CalcPoint_Williams(out_lon3, out_lat3, ref out_lon3, ref out_lat3, distance_NM3, CurrentHeading);
							float num19 = Math2.CalcDist(out_lat3, out_lon3, out_lat2, out_lon2);
							if (num19 <= num17)
							{
								num17 = num19;
								continue;
							}
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						float distance_NM4 = ((Module_Unit.Unit)this).get_HorizMovementDistanceOnThisTime(num2);
						float bearing = Math2.CalcAzimuth(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon);
						double out_lon4 = default(double);
						double out_lat4 = default(double);
						Geodesic_EdWilliams.CalcPoint_Williams(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon4, ref out_lat4, distance_NM4, bearing);
						float num20 = Math2.CalcDist(theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null), out_lat4, out_lon4);
						float num21 = Math.Abs((num3 - Module_Unit.CurrentSpeed_Horizontal(this) / 3600f) * num2);
						if (num20 <= num21)
						{
							flag = true;
						}
					}
					if (!flag && CheckDistranceBasedOnClosureSpeed && num13 <= num3 * num2)
					{
						flag = true;
					}
					if (!flag && SupportsAttitude_Pitch && Attitude_Pitch < -60f)
					{
						float num22 = Module_Unit.CurrentSpeed_Vertical(this, ParentScen);
						if (num2 < 1f)
						{
							num22 *= num2;
						}
						if (this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num22 <= ImpactAltitude && num13 - num14 < 1f)
						{
							flag = true;
						}
					}
					goto IL_04a7;
				}
				result = false;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100951", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num23;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num23 = 0;
			}
			else
			{
				num23 = 0;
			}
			result = (byte)num23 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool AboutToImpact_Contact(float elapsedTime)
	{
		bool result;
		try
		{
			result = AI.PrimaryTarget != null && AboutToImpact(AI.PrimaryTarget, elapsedTime);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100952", "");
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

	public virtual bool AboutToImpact_ActualTarget(float elapsedTime)
	{
		if (AI.PrimaryTarget != null)
		{
			if (AI.PrimaryTarget.ActualUnit != null)
			{
				if (AI.PrimaryTarget.get_IsDestroyed(ParentScen))
				{
					return false;
				}
				return AboutToImpact(AI.PrimaryTarget.ActualUnit, elapsedTime, CheckDistranceBasedOnClosureSpeed: true);
			}
			return false;
		}
		return false;
	}

	private bool method_38(Sensor sensor_2)
	{
		int result;
		if (!sensor_2.IsSonar)
		{
			switch (sensor_2.Type)
			{
			default:
				result = 0;
				goto IL_009a;
			case Sensor.Sensor_Type.LaserDesignator:
			case Sensor.Sensor_Type.LaserSpotTracker:
			case Sensor.Sensor_Type.LaserRangefinder:
				return IsSmokeGrenade;
			case Sensor.Sensor_Type.Radar:
				return IsRadarCountermeasure;
			case Sensor.Sensor_Type.SemiActive:
				if (Information.IsNothing((object)sensor_2.ParentPlatform))
				{
					result = 0;
				}
				else
				{
					if (!Information.IsNothing((object)((Weapon)sensor_2.ParentPlatform).SensorProvidingFireControlForMe) && ((Weapon)sensor_2.ParentPlatform).SensorProvidingFireControlForMe.Type == Sensor.Sensor_Type.Radar)
					{
						return IsRadarCountermeasure;
					}
					result = 0;
				}
				goto IL_009a;
			case Sensor.Sensor_Type.Visual:
				return IsVisualCountermeasure;
			case Sensor.Sensor_Type.Infrared:
				{
					return IsIRCountermeasure;
				}
				IL_009a:
				return (byte)result != 0;
			}
		}
		return IsSonarCountermeasure;
	}

	private bool method_39(ref Weapon weapon_0, ref Sensor sensor_2, ref ActiveUnit activeUnit_2, ref List<string> list_2)
	{
		bool result;
		try
		{
			if (sensor_2.IsNeutralized == true)
			{
				result = false;
			}
			else
			{
				StringBuilder stringBuilder = StringBuilderCache.Allocate();
				if (sensor_2 != null)
				{
					float num = BasePoK_AnyTarget();
					if (weapon_0.AI.PrimaryTarget != null)
					{
						float num3 = default(float);
						if (IsRadarCountermeasure && TechGeneration == GlobalVariables.TechGenerationClass.NotApplicable)
						{
							if (weapon_0.AI.PrimaryTarget.ActualUnit != null)
							{
								float num2 = GlobalSingleton.GetInstance().ChaffEffectivnessConstants[sensor_2.TechGeneration].ShipSize[weapon_0.AI.PrimaryTarget.ActualUnit.VisualSizeClass];
								num3 = ((num2 == 0f) ? num : num2);
							}
						}
						else if (TechGeneration == GlobalVariables.TechGenerationClass.NotApplicable)
						{
							num3 = num;
						}
						else if (IsIRCountermeasure)
						{
							int num4 = TechGeneration - sensor_2.TechGeneration;
							if (num4 < 0)
							{
								num3 = num - 10f;
							}
							else if (num4 == 0)
							{
								num3 = num;
							}
							else if (num4 > 0)
							{
								num3 = num + 5f;
							}
						}
						else
						{
							int num5 = TechGeneration - sensor_2.TechGeneration;
							if (num5 < -3)
							{
								num3 = num - 15f;
							}
							else if (num5 == -3)
							{
								num3 = num - 10f;
							}
							else if (num5 == -2)
							{
								num3 = num - 5f;
							}
							else if (num5 == -1)
							{
								num3 = num;
							}
							else if (num5 == 0)
							{
								num3 = num;
							}
							else if (num5 == 1)
							{
								num3 = num;
							}
							else if (num5 == 2)
							{
								num3 = num + 5f;
							}
							else if (num5 == 3)
							{
								num3 = num + 10f;
							}
							else if (num5 > 3)
							{
								num3 = num + 15f;
							}
						}
						if (num3 < 0f)
						{
							num3 = 0f;
						}
						stringBuilder.Append("Decoy (" + UnitClass + "; Tech: " + Misc.ToEnglishString(TechGeneration) + ") from " + activeUnit_2.Name + " is attempting to seduce sensor: " + Misc.RemoveHiddenString(sensor_2.Name) + " (Tech: " + Misc.ToEnglishString(sensor_2.TechGeneration) + ")(Guiding weapon: " + weapon_0.Name + "). Final probability: " + Conversions.ToString(Math.Round(num3, 2)) + "%. ");
						if (!weapon_0.Flags.UsesImagingSeeker)
						{
							int num6 = GameGeneral.GlobalRNG.Next(1, 101);
							string messageSummary;
							bool flag;
							if ((float)num6 <= num3)
							{
								stringBuilder.Append("Result: " + Conversions.ToString(num6) + " - SUCCESS");
								messageSummary = Misc.RemoveHiddenString(Name) + " spoofed " + Misc.RemoveHiddenString(sensor_2.Name);
								sensor_2.IsNeutralized = true;
								flag = true;
							}
							else
							{
								stringBuilder.Append("Result: " + Conversions.ToString(num6) + " - FAILURE");
								messageSummary = Misc.RemoveHiddenString(Name) + " failed to spoof " + Misc.RemoveHiddenString(sensor_2.Name);
								sensor_2.IsNeutralized = false;
								flag = false;
							}
							ParentScen.AddMessage(stringBuilder.ToString(), messageSummary, LoggedMessage.MessageType.WeaponEndgame, 10, ObjectID, null, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
							if (list_2 != null)
							{
								list_2.Add(stringBuilder.ToString());
							}
							StringBuilderCache.Free(stringBuilder);
							result = flag;
						}
						else
						{
							stringBuilder.Append("FAIL: The weapon uses imaging seeker");
							ParentScen.AddMessage(stringBuilder.ToString(), Misc.RemoveHiddenString(Name) + " failed to spoof " + Misc.RemoveHiddenString(sensor_2.Name), LoggedMessage.MessageType.WeaponEndgame, 10, ObjectID, null, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
							int num7;
							if (list_2 == null)
							{
								num7 = 0;
							}
							else
							{
								list_2.Add(stringBuilder.ToString());
								num7 = 0;
							}
							result = (byte)num7 != 0;
						}
					}
					else
					{
						result = false;
					}
				}
				else
				{
					result = false;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100953", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num8;
			if (!Debugger.IsAttached)
			{
				num8 = 0;
			}
			else
			{
				Debugger.Break();
				num8 = 0;
			}
			result = (byte)num8 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool ResolveDecoyAttempt(ref Weapon AttackingWeapon, ref ActiveUnit theUnit, ref List<string> PointDefenceMessages)
	{
		bool result;
		try
		{
			if (AttackingWeapon.Guidance == WeaponGuidanceType.TVM)
			{
				Sensor sensor_ = AttackingWeapon.SensorProvidingFireControlForMe;
				result = sensor_ != null && method_39(ref AttackingWeapon, ref sensor_, ref theUnit, ref PointDefenceMessages);
			}
			else
			{
				bool flag = default(bool);
				foreach (Sensor sensor in AttackingWeapon._Sensors)
				{
					Sensor sensor_2 = sensor;
					if (sensor_2 != null && method_38(sensor_2) && method_39(ref AttackingWeapon, ref sensor_2, ref theUnit, ref PointDefenceMessages))
					{
						flag = true;
					}
				}
				result = flag;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100954", "");
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
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private double method_40(double double_0)
	{
		if (double_0 > 180.0)
		{
			double_0 = -360.0 + double_0;
		}
		double_0 = Math.Abs(double_0);
		if (double_0 > 90.0)
		{
			double_0 = 180.0 - double_0;
		}
		double num = 0.5;
		return 1.0 - double_0 * num / 90.0;
	}

	internal static double GetCrossingTargetModifier(double impactAngleDeg, double targetSpeedKnots, double interceptorSpeedKnots, double rangeNm, int agilityScore, StringBuilder theSB)
	{
		if (rangeNm <= 0.0)
		{
			return 1.0;
		}
		impactAngleDeg = Math.Max(0.0, Math.Min(180.0, impactAngleDeg));
		theSB.Append("Intercept angle " + Conversions.ToString((int)Math.Round(impactAngleDeg)) + " deg, tgt " + Conversions.ToString((int)Math.Round(targetSpeedKnots)) + " kts, intc " + Conversions.ToString((int)Math.Round(interceptorSpeedKnots)) + " kts. ");
		double a = impactAngleDeg * Math.PI / 180.0;
		double num = targetSpeedKnots * Math.Sin(a) / rangeNm * (180.0 / Math.PI) / 3600.0;
		theSB.Append("LOS rate " + Conversions.ToString(Math.Round(num, 2)) + " deg/s. ");
		double[] array = new double[8] { 1.0, 5.0, 10.0, 20.0, 30.0, 60.0, 90.0, 120.0 };
		double[] array2 = new double[8] { 1.0, 0.97, 0.93, 0.85, 0.74, 0.55, 0.38, 0.22 };
		double num2;
		if (num <= array[0])
		{
			num2 = array2[0];
		}
		else if (num >= array[^1])
		{
			num2 = array2[^1];
		}
		else
		{
			num2 = array2[^1];
			int num3 = array.Length - 2;
			for (int i = 0; i <= num3; i++)
			{
				if (num >= array[i] && !(num > array[i + 1]))
				{
					double num4 = (num - array[i]) / (array[i + 1] - array[i]);
					num2 = array2[i] + num4 * (array2[i + 1] - array2[i]);
					break;
				}
			}
		}
		double num5 = 10.0 * Math.Exp((double)agilityScore * 0.2);
		double x = Math.Pow(num, 0.8) / num5;
		double num6 = 1.0 / (1.0 + Math.Pow(x, 0.8));
		double num7 = num2 * num6;
		if (impactAngleDeg > 120.0)
		{
			num7 *= 0.9;
		}
		num7 = Math.Max(0.05, Math.Min(1.0, num7));
		theSB.Append("AgilityScore " + Conversions.ToString(agilityScore) + ", CrossingMod " + Conversions.ToString(Math.Round(num2, 2)) + ", KinMod " + Conversions.ToString(Math.Round(num6, 2)) + ". ");
		theSB.Append("PH reduced by " + Conversions.ToString((int)Math.Round(100.0 * (1.0 - num7))) + "%. ");
		return num7;
	}

	private static double smethod_1(GlobalVariables.TechGenerationClass techGenerationClass_1)
	{
		if (techGenerationClass_1 >= GlobalVariables.TechGenerationClass.const_4 && techGenerationClass_1 <= GlobalVariables.TechGenerationClass.const_5)
		{
			return 0.6;
		}
		if (techGenerationClass_1 >= GlobalVariables.TechGenerationClass.const_6 && techGenerationClass_1 <= GlobalVariables.TechGenerationClass.const_7)
		{
			return 0.8;
		}
		if (techGenerationClass_1 >= GlobalVariables.TechGenerationClass.const_8 && techGenerationClass_1 <= GlobalVariables.TechGenerationClass.const_9)
		{
			return 1.0;
		}
		if (techGenerationClass_1 >= GlobalVariables.TechGenerationClass.const_10 && techGenerationClass_1 <= GlobalVariables.TechGenerationClass.const_11)
		{
			return 1.2;
		}
		if (techGenerationClass_1 >= GlobalVariables.TechGenerationClass.const_12 && techGenerationClass_1 <= GlobalVariables.TechGenerationClass.const_13)
		{
			return 1.4;
		}
		if (techGenerationClass_1 >= GlobalVariables.TechGenerationClass.const_14 && techGenerationClass_1 <= GlobalVariables.TechGenerationClass.const_15)
		{
			return 1.7;
		}
		if (techGenerationClass_1 >= GlobalVariables.TechGenerationClass.const_16 && techGenerationClass_1 <= GlobalVariables.TechGenerationClass.const_17)
		{
			return 2.0;
		}
		return 1.0;
	}

	private static double smethod_2(WeaponFlags.AttitudeControlEnum attitudeControlEnum_0)
	{
		return attitudeControlEnum_0 switch
		{
			WeaponFlags.AttitudeControlEnum.Aerodynamic => 1.0, 
			WeaponFlags.AttitudeControlEnum.NonAerodynamic => 1.6, 
			WeaponFlags.AttitudeControlEnum.Combined => 1.3, 
			_ => 1.0, 
		};
	}

	public virtual bool ResolveImpact(ActiveUnit theTarget, Scenario theScen, bool IsPointDefenceMode, ref List<string> PointDefenceMessages)
	{
		bool result;
		if (this == null)
		{
			result = false;
		}
		else if (!IsMorituri)
		{
			LockRandom theRNG = GameGeneral.GlobalRNG;
			try
			{
				StringBuilder stringBuilder = StringBuilderCache.Allocate();
				bool flag = false;
				bool flag2 = false;
				if (!HasTerminalGuidance || SensorProvidingFireControlForMe != null || Guidance == WeaponGuidanceType.CommandGuided_Datalinked)
				{
					goto IL_0168;
				}
				bool flag3 = false;
				Sensor[] terminalGuidingSensors = TerminalGuidingSensors;
				if (terminalGuidingSensors != null)
				{
					Sensor[] array = terminalGuidingSensors;
					foreach (Sensor sensor in array)
					{
						if (sensor != null && sensor.Status == PlatformComponent._ComponentStatus.Operational)
						{
							flag3 = true;
							break;
						}
					}
				}
				if (flag3)
				{
					goto IL_0168;
				}
				if (IsNuke.Value)
				{
					stringBuilder.Append("Weapon: " + Name + " has no functioning sensors for terminal guidance... salvage-detonating nuclear warhead.");
					Detonate(((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ImpactAltitude, ref theRNG, Detonation_AddMessage: true);
				}
				else
				{
					stringBuilder.Append("Weapon: " + Name + " has no functioning sensors for terminal guidance... clean miss.");
				}
				_ = Misc.RemoveHiddenString(Name) + " missed " + theTarget.Name;
				base.EndgameReport.AddEndGameMessage(hit: false, stringBuilder.ToString());
				if (PointDefenceMessages != null)
				{
					PointDefenceMessages.Add(stringBuilder.ToString());
				}
				ExportResolveImpactEvent(theTarget, ImpactWillOccur: false, HitResultsInKill: false, stringBuilder);
				StringBuilderCache.Free(stringBuilder);
				result = false;
				goto end_IL_001b;
				IL_0c86:
				float num2;
				if (theTarget.IsAerospaceUnit && theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 0f && !Flags.CapableVsSeaskimmer)
				{
					double num = Math.Round(SeaSkimmerModifier(theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), 2);
					if (num > 0.0)
					{
						num2 = (float)((double)num2 - num);
						stringBuilder.Append("Sea-skimmer modifier: -" + Conversions.ToString(num) + "%. ");
					}
				}
				if (MaxTargetSpeed > 0 && (theTarget.IsMissile || (object)theTarget.GetType() == typeof(UnguidedRocket)))
				{
					num2 = ModifierVsTargetSpeed((int)Math.Round(num2), this, theTarget, stringBuilder);
				}
				if (theTarget.IsAerospaceUnit)
				{
					string feedbackMessage = "";
					float num3 = Module_Unit.AngleOffThisUnitsBoresight(this, theTarget, DistinguishBetweenStarboardAndPort: false, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
					XSection xSection = Sensor.smethod_0(theTarget, XSection._SignatureType.Radar_E_M);
					XSection xSection2 = Sensor.smethod_0(theTarget, XSection._SignatureType.IR_Detect);
					bool flag4 = false;
					if (xSection.isDBInvisible(theTarget) | xSection2.isDBInvisible(theTarget))
					{
						flag4 = true;
					}
					float targetSignature_Radar_dbsm = default(float);
					float targetSignature_IR = default(float);
					if (!(num3 >= 315f) && num3 > 45f)
					{
						if ((num3 >= 45f && num3 <= 135f) || (num3 >= 225f && num3 <= 315f))
						{
							targetSignature_Radar_dbsm = xSection.get_Side(theTarget);
							targetSignature_IR = xSection2.get_Side(theTarget);
						}
						else if (num3 >= 135f && num3 <= 225f)
						{
							targetSignature_Radar_dbsm = xSection.get_Rear(theTarget);
							targetSignature_IR = xSection2.get_Rear(theTarget);
						}
					}
					else
					{
						targetSignature_Radar_dbsm = xSection.get_Front(theTarget);
						targetSignature_IR = xSection2.get_Front(theTarget);
					}
					if (flag4)
					{
						targetSignature_Radar_dbsm = 0f;
						targetSignature_IR = 0f;
					}
					num2 = ModifierVsTargetSignature((int)Math.Round(num2), FiringParent, this, theTarget, TerminalGuidingSensors?.FirstOrDefault(), targetSignature_Radar_dbsm, targetSignature_IR, stringBuilder);
				}
				if (theTarget.IsAerospaceUnit)
				{
					double impactAngleDeg;
					float num4;
					if (FiringParent == null)
					{
						impactAngleDeg = Math2.AngleOffThisUnitsBoresight_3D(theTarget, LaunchPoint.Latitude, LaunchPoint.Longitude, LaunchPoint.Altitude);
						num4 = Module_Unit.RangeToPoint_Slant(theTarget, LaunchPoint);
					}
					else
					{
						impactAngleDeg = Module_Unit.AngleOffThisUnitsBoresight_3D(FiringParent, theTarget);
						num4 = Module_Unit.RangeToUnit_Slant(FiringParent, theTarget);
					}
					double crossingTargetModifier = GetCrossingTargetModifier(impactAngleDeg, theTarget.CurrentSpeed, CurrentSpeed, num4, KinMod.GetKinModTier(this).AgilityScore, stringBuilder);
					num2 = (float)((double)num2 * crossingTargetModifier);
				}
				if (theTarget.IsMissile && (IsPointDefenceMode || Module_Unit.RangeToPoint_Horiz(this, LaunchPoint) <= 2f))
				{
					Weapon weapon = (Weapon)theTarget;
					if (weapon.AI.PrimaryTarget != null && weapon.RangeToUnit_Horiz(weapon.AI.PrimaryTarget) < 2f)
					{
						if (!weapon.Flags.TerminalManeuver_PopUp)
						{
							if (!weapon.Flags.TerminalManeuver_ZigZag)
							{
								if (weapon.Flags.TerminalManeuver_Random)
								{
									stringBuilder.Append("Target is missile with random terminal manouver - hit probability reduced by 50%. ");
									num2 = (float)((double)num2 * 0.5);
								}
							}
							else
							{
								stringBuilder.Append("Target is missile with zig-zag terminal manouver - hit probability reduced by 33%. ");
								num2 = (float)((double)num2 * 0.66);
							}
						}
						else
						{
							stringBuilder.Append("Target is missile with pop-up terminal manouver - hit probability reduced by 25%. ");
							num2 = (float)((double)num2 * 0.75);
						}
					}
				}
				if (theTarget.IsTorpedo)
				{
					stringBuilder.Append("Target is torpedo - hit probability halved. ");
					num2 = (float)((double)num2 * 0.5);
				}
				if (num2 < 5f)
				{
					num2 = 5f;
				}
				if (num2 > 95f)
				{
					num2 = 95f;
				}
				stringBuilder.Append("Final PH: " + Conversions.ToString((int)Math.Round(num2)) + "% ");
				int num5 = theRNG.Next(1, 101);
				if ((float)num5 <= num2)
				{
					stringBuilder.Append("Result: " + Conversions.ToString(num5) + " - HIT");
					flag = true;
				}
				else
				{
					stringBuilder.Append("Result: " + Conversions.ToString(num5));
					if (!Flags.ReAttack_Capability)
					{
						stringBuilder.Append(" - MISS");
						if (Warheads.Length > 0 && theTarget.IsFacility && Warheads[0].IsExplosive)
						{
							float num6 = default(float);
							num6 = theRNG.Next(0, 359);
							float num7 = theRNG.Next(1, 50);
							stringBuilder.Append(" (Near miss: " + Conversions.ToString(num7) + "m)");
							ActiveUnit_Damage damage = theTarget.Damage;
							GeoPoint launchPoint = LaunchPoint;
							float bearingFromImpact = num6;
							string feedbackMessage = "";
							damage.ResolveDamageFromWeapon(this, launchPoint, num7, bearingFromImpact, null, null, null, null, ref feedbackMessage, DirectHit: false, null);
						}
					}
					else
					{
						float num8 = num2 / 4f;
						if ((float)theRNG.Next(1, 101) < num8)
						{
							stringBuilder.Append(" - MISS - NO REATTACK (DUD)");
						}
						else
						{
							stringBuilder.Append(" - MISS - REATTACK");
							PrepareForReattack(theTarget);
							flag2 = true;
						}
					}
				}
				if (!flag)
				{
					_ = Misc.RemoveHiddenString(Name) + " missed " + theTarget.Name;
				}
				else
				{
					_ = Misc.RemoveHiddenString(Name) + " impacted " + theTarget.Name;
				}
				base.EndgameReport.AddEndGameMessage(flag, stringBuilder.ToString());
				if (flag2)
				{
					base.EndgameReport.ReportEndgameAfterReattackTriggered(ParentScen);
				}
				if (PointDefenceMessages != null)
				{
					PointDefenceMessages.Add(stringBuilder.ToString());
				}
				if (!flag)
				{
					ExportResolveImpactEvent(theTarget, ImpactWillOccur: false, HitResultsInKill: false, stringBuilder);
				}
				else
				{
					Impact(theTarget, stringBuilder);
				}
				StringBuilderCache.Free(stringBuilder);
				if (flag || !flag2)
				{
					ParentScen?.DestroyThisUnit(this, $"Weapon has been destroyed though interaction with {theTarget.Name}, export WeaponEndgame data for more information.", "Impact / Detonation");
				}
				result = flag;
				goto end_IL_001b;
				IL_03e5:
				string text = (string.IsNullOrEmpty(Name) ? UnitClass : Name);
				float num9 = default(float);
				if ((float)theRNG.Next(1, 101) < num9 && IsNuke.Value)
				{
					StringBuilderCache.Free(stringBuilder);
					Detonate(((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ImpactAltitude, ref theRNG, Detonation_AddMessage: true);
					result = false;
				}
				else
				{
					_WeaponType type = Type;
					if (type == _WeaponType.Gun)
					{
						stringBuilder.Append("Gun (" + text + ") Is attacking " + theTarget.Name + " With a base PH Of " + Conversions.ToString(Math.Round(num9, 2)) + "%. ");
					}
					else
					{
						string text2 = ((!theTarget.IsAircraft || Operators.CompareString(theTarget.Name, theTarget.UnitClass, false) == 0) ? theTarget.Name : (theTarget.Name + " (" + theTarget.UnitClass + ")"));
						stringBuilder.Append("Weapon: " + Name + " is attacking " + text2 + " with a base PH of " + Conversions.ToString(Math.Round(num9, 2)) + "%. ");
					}
					if (!theTarget.IsAerospaceUnit)
					{
						num2 = num9;
						goto IL_0c86;
					}
					if (!theTarget.IsBeingDestroyed && !theTarget.IsMorituri)
					{
						if ((base.IsMissile || IsGuidedProjectile) && (!theTarget.IsAircraft || !((Aircraft)theTarget).IsLighterThanAir) && Flags.AttitudeControl != WeaponFlags.AttitudeControlEnum.NonAerodynamic)
						{
							if (UsesBoostCoastModel.Value)
							{
								float num10 = CurrentSpeed / (float)Kinematics.GetMaximumSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
								float num11 = Kinematics.MinimumDesiredAverageSpeedMultiplier();
								if (num10 < num11)
								{
									float num12 = 1f;
									float num13 = 1f + (num10 / num11 - 1f) * num12;
									float num14 = num9 * num13;
									float num15 = num9 - num14;
									switch (Flags.AttitudeControl)
									{
									case WeaponFlags.AttitudeControlEnum.Combined:
										num9 -= num15 / 2f;
										if (float.IsNaN(num9))
										{
											num9 = 0f;
										}
										stringBuilder.Append("PH adjusted for weapon speed: " + Conversions.ToString((int)Math.Round(num9)) + "% (combined attitude control). ");
										break;
									case WeaponFlags.AttitudeControlEnum.Aerodynamic:
										num9 = num14;
										if (float.IsNaN(num9))
										{
											num9 = 0f;
										}
										stringBuilder.Append("PH adjusted for weapon speed: " + Conversions.ToString((int)Math.Round(num9)) + "% (pure-aerodynamic attitude control). ");
										break;
									}
								}
							}
							else
							{
								float num16 = Module_Unit.RangeToPoint_Horiz(this, LaunchPoint) / MaxAirRange;
								float num17;
								if (Propulsion.Count > 0)
								{
									Engine.EngineType type2 = Propulsion[0].Type;
									num17 = ((type2 == Engine.EngineType.Rocket_BoostCoast || (uint)(type2 - 5003) <= 2u) ? 0.5f : 0.75f);
								}
								else
								{
									num17 = 0.75f;
								}
								if (num16 > num17)
								{
									float num18 = num9 * num17 + num9 * (1f - num17) * (1f - (num16 - num17) / (1f - num17));
									float num19 = num9 - num18;
									switch (Flags.AttitudeControl)
									{
									case WeaponFlags.AttitudeControlEnum.Combined:
										num9 -= num19 / 2f;
										if (float.IsNaN(num9))
										{
											num9 = 0f;
										}
										stringBuilder.Append("PH adjusted for distance: " + Conversions.ToString((int)Math.Round(num9)) + "% (combined attitude control). ");
										break;
									case WeaponFlags.AttitudeControlEnum.Aerodynamic:
										num9 = num18;
										if (float.IsNaN(num9))
										{
											num9 = 0f;
										}
										stringBuilder.Append("PH adjusted for distance: " + Conversions.ToString((int)Math.Round(num9)) + "% (pure-aerodynamic attitude control). ");
										break;
									}
								}
							}
						}
						if (!theTarget.IsMissile)
						{
							if (MaxTargetSpeed > 0)
							{
								float num20 = default(float);
								if (theTarget.CurrentSpeed > (float)MaxTargetSpeed)
								{
									num20 = 50f;
								}
								else if ((double)theTarget.CurrentSpeed > (double)MaxTargetSpeed * 0.8)
								{
									num20 = 25f;
								}
								else if ((double)theTarget.CurrentSpeed > (double)MaxTargetSpeed * 0.7)
								{
									num20 = 15f;
								}
								else if ((double)theTarget.CurrentSpeed > (double)MaxTargetSpeed * 0.6)
								{
									num20 = 10f;
								}
								else if ((double)theTarget.CurrentSpeed > (double)MaxTargetSpeed * 0.5)
								{
									num20 = 5f;
								}
								if (num20 != 0f)
								{
									num9 = (int)Math.Round(num9 - num20);
									if (num9 < 0f)
									{
										num9 = 0f;
									}
									stringBuilder.Append("PH adjusted for actual target speed (").Append((int)Math.Round(theTarget.CurrentSpeed)).Append(" kts): ")
										.Append(Math.Round(num9, 1))
										.Append("%. ");
								}
							}
							if (MinTargetSpeed >= 0)
							{
								float num21 = default(float);
								if ((float)MinTargetSpeed > theTarget.CurrentSpeed)
								{
									num21 = 5f;
								}
								else if ((double)MinTargetSpeed > (double)theTarget.CurrentSpeed * 0.8)
								{
									num21 = 10f;
								}
								else if ((double)MinTargetSpeed > (double)theTarget.CurrentSpeed * 0.7)
								{
									num21 = 15f;
								}
								else if ((double)MinTargetSpeed > (double)theTarget.CurrentSpeed * 0.6)
								{
									num21 = 25f;
								}
								else if ((double)MinTargetSpeed > (double)theTarget.CurrentSpeed * 0.5)
								{
									num21 = 50f;
								}
								if (num21 != 0f)
								{
									num9 = (int)Math.Round(num9 - num21);
									if (num9 < 0f)
									{
										num9 = 0f;
									}
									stringBuilder.Append("PH adjusted for actual target speed (").Append((int)Math.Round(theTarget.CurrentSpeed)).Append(" kts): ")
										.Append(Math.Round(num9, 1))
										.Append("%. ");
								}
							}
						}
						if (theTarget.IsAircraft && !((Aircraft)theTarget).IsLighterThanAir && ((Aircraft)theTarget).Crew > 0 && ((Aircraft)theTarget).Agility_Nominal > 0f)
						{
							if (AI.PrimaryTarget.ActualUnit != null && AI.PrimaryTarget.ActualUnit.get_UnitSide(SetSideOnly: false).HasDetectedThisUnit(this))
							{
								float num22 = ((Aircraft)theTarget).Kinematics.get_ActualAgility(stringBuilder);
								string feedbackMessage = "";
								float num23 = Module_Unit.AngleOffThisUnitsBoresight(this, theTarget, DistinguishBetweenStarboardAndPort: false, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
								if (!(num23 >= 345f) && num23 > 15f)
								{
									if ((num23 >= 15f && num23 <= 60f) || (num23 <= 345f && num23 >= 300f))
									{
										num22 = (float)((double)num22 * 0.7);
										stringBuilder.Append("Agility adjusted for forward-oblique impact effect: " + Conversions.ToString(Math.Round(num22, 1)) + ". ");
									}
									else if ((num23 >= 60f && num23 <= 110f) || (num23 <= 300f && num23 >= 250f))
									{
										num22 = num22;
										stringBuilder.Append("High-deflection impact (no effect on agility). ");
									}
									else if ((num23 >= 110f && num23 <= 165f) || (num23 <= 250f && num23 >= 195f))
									{
										num22 = (float)((double)num22 * 0.85);
										stringBuilder.Append("Agility adjusted for rear-oblique impact effect: " + Conversions.ToString(Math.Round(num22, 1)) + ". ");
									}
									else
									{
										num22 = (float)((double)num22 * 0.5);
										stringBuilder.Append("Agility adjusted for tail-on impact effect: " + Conversions.ToString(Math.Round(num22, 1)) + ". ");
									}
								}
								else
								{
									num22 = (float)((double)num22 * 0.6);
									stringBuilder.Append("Agility adjusted for head-on impact effect: " + Conversions.ToString(Math.Round(num22, 1)) + ". ");
								}
								num22 = (float)Math.Round(num22, 1);
								stringBuilder.Append("Final agility modifier: -" + Conversions.ToString((int)Math.Round(num22 * 10f)) + "%. ");
								num2 = num9 - num22 * 10f;
							}
							else
							{
								num2 = num9;
							}
						}
						else
						{
							num2 = num9;
						}
						goto IL_0c86;
					}
					StringBuilderCache.Free(stringBuilder);
					result = false;
				}
				goto end_IL_001b;
				IL_0168:
				if (!theTarget.IsAircraft)
				{
					if (theTarget.IsWeapon)
					{
						if (!theTarget.IsMissile && (object)theTarget.GetType() != typeof(UnguidedRocket))
						{
							if (!theTarget.IsMobileDecoy_Air && !theTarget.isUAV)
							{
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
							}
							else
							{
								num9 = AirPOK;
							}
						}
						else
						{
							num9 = AirPOK;
						}
						goto IL_03e5;
					}
					if (theTarget.IsSatellite)
					{
						num9 = AirPOK;
						goto IL_03e5;
					}
					if (!theTarget.IsShip)
					{
						if (theTarget.IsSubmarine)
						{
							if (theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) != 0f)
							{
								num9 = SubPOK;
								goto IL_03e5;
							}
							if (IsTorpedo)
							{
								num9 = Math.Max(SubPOK, SurfPOK);
								goto IL_03e5;
							}
							bool flag5;
							if (flag5 = Impact_CEP(theTarget, ref theScen, ref theRNG))
							{
								ParentScen?.DestroyThisUnit(this, $"Weapon impacted {theTarget.Name}", "Impact / Detonation");
							}
							else
							{
								ParentScen?.DestroyThisUnit(this, $"Weapon missed {theTarget.Name}", "Missed");
							}
							StringBuilderCache.Free(stringBuilder);
							result = flag5;
						}
						else
						{
							if (!theTarget.IsFacility && !theTarget.IsMobileGroundUnit)
							{
								goto IL_03e5;
							}
							bool num24 = Impact_CEP(theTarget, ref theScen, ref theRNG);
							StringBuilderCache.Free(stringBuilder);
							result = num24;
						}
					}
					else
					{
						bool flag6;
						if (flag6 = Impact_CEP(theTarget, ref theScen, ref theRNG))
						{
							ParentScen?.DestroyThisUnit(this, $"Weapon impacted {theTarget.Name}", "Impact / Detonation");
						}
						else
						{
							ParentScen?.DestroyThisUnit(this, $"Weapon missed {theTarget.Name}", "Missed");
						}
						StringBuilderCache.Free(stringBuilder);
						result = flag6;
					}
				}
				else
				{
					if (!((Aircraft)theTarget).IsLighterThanAir)
					{
						num9 = AirPOK;
						goto IL_03e5;
					}
					if (IsAAWCapable)
					{
						num9 = AirPOK;
						goto IL_03e5;
					}
					bool flag7;
					if (!(flag7 = Impact_CEP(theTarget, ref theScen, ref theRNG)))
					{
						ParentScen?.DestroyThisUnit(this, $"Weapon missed {theTarget.Name}", "Missed");
					}
					else
					{
						ParentScen?.DestroyThisUnit(this, $"Weapon impacted {theTarget.Name}", "Impact / Detonation");
					}
					StringBuilderCache.Free(stringBuilder);
					result = flag7;
				}
				end_IL_001b:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100955", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num25;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num25 = 0;
				}
				else
				{
					num25 = 0;
				}
				result = (byte)num25 != 0;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	public void ExportResolveImpactEvent(Module_Unit.Unit theTarget, bool ImpactWillOccur, bool HitResultsInKill, StringBuilder AttackMessage)
	{
		try
		{
			if (ParentScen == null)
			{
				return;
			}
			IEventExporter[] array = ParentScen?.ApplicableEventExporters;
			foreach (IEventExporter eventExporter in array)
			{
				if (!eventExporter.IsOperating || !eventExporter.ExportWeaponEndgame)
				{
					continue;
				}
				PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
				if (ParentScen.MonteCarloIteration > 0)
				{
					pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(ParentScen.Title, typeof(string), 500));
					pooledDictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(ParentScen.MonteCarloIteration, typeof(int)));
				}
				pooledDictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(ParentScen.TimelineID, typeof(string), 40));
				if (!eventExporter.UseZeroHour)
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(ParentScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + ParentScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				else
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(ParentScen.Time.Subtract(ParentScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				pooledDictionary.Add("WeaponID", new IEventExporter.EventNotificationParameter(ObjectID, typeof(string), 40));
				pooledDictionary.Add("WeaponName", new IEventExporter.EventNotificationParameter(Name, typeof(string), 500));
				pooledDictionary.Add("WeaponSide", new IEventExporter.EventNotificationParameter(((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Name, typeof(string), 500));
				if (FiringParent != null)
				{
					pooledDictionary.Add("ParentFiringUnitID", new IEventExporter.EventNotificationParameter(FiringParent.ObjectID, typeof(string), 40));
					pooledDictionary.Add("ParentFiringUnitName", new IEventExporter.EventNotificationParameter(FiringParent.Name, typeof(string), 500));
				}
				else
				{
					pooledDictionary.Add("ParentFiringUnitID", new IEventExporter.EventNotificationParameter("-", typeof(string), 40));
					pooledDictionary.Add("ParentFiringUnitName", new IEventExporter.EventNotificationParameter("-", typeof(string), 500));
				}
				if (theTarget == null)
				{
					pooledDictionary.Add("TargetID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					pooledDictionary.Add("TargetName", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					pooledDictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					pooledDictionary.Add("TargetLongitude", new IEventExporter.EventNotificationParameter(string.Empty, typeof(double)));
					pooledDictionary.Add("TargetLatitude", new IEventExporter.EventNotificationParameter(string.Empty, typeof(double)));
					pooledDictionary.Add("TargetAltitude_ASL_m", new IEventExporter.EventNotificationParameter(string.Empty, typeof(float)));
					pooledDictionary.Add("TargetAltitude_AGL_m", new IEventExporter.EventNotificationParameter(string.Empty, typeof(float)));
				}
				else
				{
					pooledDictionary.Add("TargetID", new IEventExporter.EventNotificationParameter(theTarget.ObjectID, typeof(string), 40));
					pooledDictionary.Add("TargetName", new IEventExporter.EventNotificationParameter(theTarget.Name, typeof(string), 500));
					if (!Information.IsNothing((object)theTarget.get_UnitSide(SetSideOnly: false)))
					{
						pooledDictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter(theTarget.get_UnitSide(SetSideOnly: false).Name, typeof(string), 500));
					}
					else
					{
						pooledDictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter("-", typeof(string), 500));
					}
					pooledDictionary.Add("TargetLongitude", new IEventExporter.EventNotificationParameter(theTarget.get_Longitude((GlobalVariables.BooleanObject)null), typeof(double)));
					pooledDictionary.Add("TargetLatitude", new IEventExporter.EventNotificationParameter(theTarget.get_Latitude((GlobalVariables.BooleanObject)null), typeof(double)));
					pooledDictionary.Add("TargetAltitude_ASL_m", new IEventExporter.EventNotificationParameter(theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), typeof(float)));
					pooledDictionary.Add("TargetAltitude_AGL_m", new IEventExporter.EventNotificationParameter(theTarget.CurrentAltitude_AGL, typeof(float)));
				}
				pooledDictionary.Add("DistanceFromFiringUnit_Horiz", new IEventExporter.EventNotificationParameter(Conversions.ToString(Interaction.IIf(FiringParent != null, (object)RangeToUnit_Horiz(FiringParent), (object)"")), typeof(float)));
				if (ImpactWillOccur)
				{
					if (!HitResultsInKill)
					{
						pooledDictionary.Add("Result", new IEventExporter.EventNotificationParameter("HIT", typeof(string), 10));
					}
					else
					{
						pooledDictionary.Add("Result", new IEventExporter.EventNotificationParameter("KILL", typeof(string), 10));
					}
				}
				else
				{
					pooledDictionary.Add("Result", new IEventExporter.EventNotificationParameter("MISS", typeof(string), 10));
				}
				if (Information.IsNothing((object)AttackMessage))
				{
					pooledDictionary.Add("EndgameMessage", new IEventExporter.EventNotificationParameter("-", typeof(string)));
				}
				else
				{
					pooledDictionary.Add("EndgameMessage", new IEventExporter.EventNotificationParameter(Strings.Trim(AttackMessage.ToString()), typeof(string)));
				}
				eventExporter.ExportEvent(IEventExporter.ExportedEventType.WeaponEndgame, pooledDictionary, ParentScen);
			}
			ISimConnector[] activeSimConnectors = SimConnect_General.ActiveSimConnectors;
			foreach (ISimConnector simConnector in activeSimConnectors)
			{
				if (!simConnector.ExportWeaponImpactOrDetonation)
				{
					continue;
				}
				Dictionary<string, (Type, string)> dictionary = new Dictionary<string, (Type, string)>();
				dictionary.Add("TimelineID", (typeof(string), ParentScen.TimelineID));
				dictionary.Add("Time", (typeof(DateTime), ParentScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + ParentScen.Time.Millisecond.ToString("D3")));
				dictionary.Add("Longitude", (typeof(double), Conversions.ToString(this.get_Longitude((GlobalVariables.BooleanObject)null))));
				dictionary.Add("Latitude", (typeof(double), Conversions.ToString(this.get_Latitude((GlobalVariables.BooleanObject)null))));
				dictionary.Add("Altitude", (typeof(float), Conversions.ToString(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))));
				dictionary.Add("WeaponID", (typeof(string), ObjectID));
				dictionary.Add("WeaponDBID", (typeof(string), Conversions.ToString(DBID)));
				dictionary.Add("WeaponCourse", (typeof(string), CurrentHeading.ToString()));
				dictionary.Add("WeaponSpeed_Horiz", (typeof(string), Module_Unit.CurrentSpeed_Horizontal(this).ToString()));
				dictionary.Add("WeaponSpeed_Vert", (typeof(string), Module_Unit.CurrentSpeed_Vertical(this, ParentScen).ToString()));
				if (FiringParent != null)
				{
					dictionary.Add("FiringUnitID", (typeof(string), FiringParent.ObjectID));
				}
				if (!Information.IsNothing((object)theTarget))
				{
					dictionary.Add("TargetID", (typeof(string), theTarget.ObjectID));
				}
				if (ImpactWillOccur)
				{
					if (HitResultsInKill)
					{
						dictionary.Add("Result", (typeof(string), "KILL"));
					}
					else
					{
						dictionary.Add("Result", (typeof(string), "HIT"));
					}
				}
				else
				{
					dictionary.Add("Result", (typeof(string), "MISS"));
				}
				dictionary.Add("EventType", (typeof(string), "WeaponImpact"));
				simConnector.ExportInfo(ISimConnector.ExportedInfoType.WeaponImpactOrDetonation, dictionary, ParentScen);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101329", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static bool CheckForDirectHit(ActiveUnit theTarget, double ImpactLat, double ImpactLon, float MissDistance_m, GeoPoint theLaunchPoint, float theWeaponMaxRange, bool IsUnguidedWeapon)
	{
		bool result;
		try
		{
			if (!theTarget.IsShip)
			{
				if (!theTarget.IsSubmarine)
				{
					if (!theTarget.IsFacility)
					{
						if (theTarget.IsAggregatedUnit)
						{
							result = AGU_CONFIG.Instance.WeaponImpactDirectHitThreshold_Meter >= MissDistance_m && Helper.RollDice(AGU_CONFIG.Instance.WeaponImpactDirectHitBaseProbability);
						}
						else if (theTarget.IsMobileGroundUnit)
						{
							result = ((theTarget.Length >= MissDistance_m) ? true : false);
						}
						else if (theTarget.IsAircraft && ((Aircraft)theTarget).IsLighterThanAir)
						{
							if (((Aircraft)theTarget).Length / 2f < MissDistance_m)
							{
								result = false;
							}
							else
							{
								Geopoint_Struct[] rectangularArea = Math2.GetRectangularArea(theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null), ((Aircraft)theTarget).Length, ((Aircraft)theTarget).Span, theTarget.CurrentHeading);
								result = (GeoPoint.IsInsideThisArea(ImpactLat, ImpactLon, rectangularArea) ? true : false);
							}
						}
						else
						{
							result = false;
						}
					}
					else if (!((Facility)theTarget).HasAimpoints)
					{
						if (Math.Max(((Facility)theTarget).Length, ((Facility)theTarget).Width) / 2f < MissDistance_m)
						{
							result = false;
						}
						else
						{
							Geopoint_Struct[] rectangularArea2 = Math2.GetRectangularArea(theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null), ((Facility)theTarget).Length, ((Facility)theTarget).Width, theTarget.CurrentHeading);
							result = (GeoPoint.IsInsideThisArea(ImpactLat, ImpactLon, rectangularArea2) ? true : false);
						}
					}
					else
					{
						result = (int)Math.Round(MissDistance_m) <= 4;
					}
				}
				else if (((Submarine)theTarget).Length / 2f < MissDistance_m)
				{
					result = false;
				}
				else if (((Submarine)theTarget).Length / 2f > MissDistance_m && ((Submarine)theTarget).Beam / 2f > MissDistance_m)
				{
					result = true;
				}
				else
				{
					Geopoint_Struct[] rectangularArea3 = Math2.GetRectangularArea(theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null), ((Submarine)theTarget).Length, ((Submarine)theTarget).Beam, theTarget.CurrentHeading);
					result = (GeoPoint.IsInsideThisArea(ImpactLat, ImpactLon, rectangularArea3) ? true : false);
				}
			}
			else if (((Ship)theTarget).Length / 2f < MissDistance_m)
			{
				result = false;
			}
			else
			{
				Geopoint_Struct[] rectangularArea4 = Math2.GetRectangularArea(theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null), ((Ship)theTarget).Length, ((Ship)theTarget).Beam, theTarget.CurrentHeading);
				result = (GeoPoint.IsInsideThisArea(ImpactLat, ImpactLon, rectangularArea4) ? true : false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100957", "");
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
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void RaiseEvent_WeaponImpact(Scenario theScen, Weapon theWeapon, Module_Unit.Unit theTarget, bool DirectHit)
	{
		weaponImpactEventHandler_0?.Invoke(theScen, theWeapon, theTarget, DirectHit);
	}

	internal float BasePoK_ThisTarget(ref ActiveUnit theTarget)
	{
		if (theTarget != null)
		{
			if (!theTarget.IsShip && (!theTarget.IsSubmarine || !((Submarine)theTarget).IsSurfaced))
			{
				if (theTarget.IsAircraft && ((Aircraft)theTarget).IsLighterThanAir)
				{
					return Math.Max(AirPOK, SurfPOK);
				}
				if (theTarget.IsFacility && ((Facility)theTarget).Category == Facility._FacilityCategory.Water_Surface)
				{
					return Math.Max(SurfPOK, LandPOK);
				}
				if (!theTarget.IsFacility && !theTarget.IsMobileGroundUnit)
				{
					if (!theTarget.IsSubmarine && !theTarget.IsTorpedo)
					{
						return 0f;
					}
					return SubPOK;
				}
				return LandPOK;
			}
			return SurfPOK;
		}
		return 0f;
	}

	internal float BasePoK_AnyTarget()
	{
		return Math.Max(AirPOK, Math.Max(SurfPOK, Math.Max(LandPOK, SubPOK)));
	}

	protected bool Impact_CEP(ActiveUnit theTarget, ref Scenario theScen, ref LockRandom theRNG)
	{
		bool result;
		try
		{
			bool flag2;
			double out_lon2 = default(double);
			double out_lat2 = default(double);
			float num2;
			float bearingFromImpact;
			bool flag3;
			float num3 = default(float);
			bool flag4;
			string text;
			if (theScen == null)
			{
				result = false;
			}
			else
			{
				float num = BasePoK_ThisTarget(ref theTarget);
				bool flag = (float)theRNG.Next(1, 101) < num;
				text = "";
				flag2 = false;
				float MissDistanceFromTargetingPoint_m = default(float);
				float MissBearingFromTargetPoint = default(float);
				if (!Impact_CEP_MissDistanceAndDirection(theTarget, ref theScen, ref MissDistanceFromTargetingPoint_m, ref MissBearingFromTargetPoint, ref theRNG))
				{
					text = "Missed " + theTarget.Name;
					base.EndgameReport.AddEndGameMessage(hit: false, text);
					result = false;
				}
				else
				{
					double out_lat = default(double);
					double out_lon = default(double);
					double lat = default(double);
					double lon = default(double);
					if (!((Guidance == WeaponGuidanceType.Inertial) & !Module_ActiveUnit.IsAimpointFacility(theTarget)))
					{
						if (!Module_ActiveUnit.IsAimpointFacility(theTarget))
						{
							if (AI.PrimaryTarget.Age == 0f && AI.PrimaryTarget.ActualUnit != null)
							{
								out_lat = AI.PrimaryTarget.ActualUnit.get_Latitude((GlobalVariables.BooleanObject)null);
								out_lon = AI.PrimaryTarget.ActualUnit.get_Longitude((GlobalVariables.BooleanObject)null);
							}
							else
							{
								out_lat = ((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
								out_lon = ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
							}
						}
						else
						{
							Mount mount;
							if (ARM_SpecifiedEMission.Value != null)
							{
								List<Mount> list = new List<Mount>();
								List<Mount> list2 = new List<Mount>();
								foreach (Mount mount2 in theTarget.Mounts)
								{
									Sensor[] sensors_ReadOnly = mount2.Sensors_ReadOnly;
									foreach (Sensor sensor in sensors_ReadOnly)
									{
										if (sensor.DBID == ARM_SpecifiedEMission.Key || sensor.MasqueradeAs == ARM_SpecifiedEMission.Key)
										{
											list.Add(mount2);
											if (sensor.IsActive())
											{
												list2.Add(mount2);
											}
										}
									}
								}
								mount = ((list2.Count > 0) ? list2[theRNG.Next(0, list2.Count)] : ((list.Count <= 0) ? ((Facility)theTarget).PickRandomAimpoint() : list[theRNG.Next(0, list.Count)]));
							}
							else
							{
								mount = ((Facility)theTarget).PickRandomAimpoint();
							}
							if (mount != null)
							{
								Geodesic_EdWilliams.CalcPoint_Williams(theTarget.get_Longitude((GlobalVariables.BooleanObject)null), theTarget.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, mount.AimpointOffset_Distance / 1852f, mount.AimpointOffset_Bearing);
								lat = out_lat;
								lon = out_lon;
							}
							else if (AI.PrimaryTarget.Age == 0f && AI.PrimaryTarget.ActualUnit != null)
							{
								out_lat = AI.PrimaryTarget.ActualUnit.get_Latitude((GlobalVariables.BooleanObject)null);
								out_lon = AI.PrimaryTarget.ActualUnit.get_Longitude((GlobalVariables.BooleanObject)null);
							}
							else
							{
								out_lat = ((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
								out_lon = ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
							}
						}
					}
					else if (Navigator.Has_NonPathfind_NonFP_PlottedCourse())
					{
						out_lat = Navigator.PlottedCourse[Navigator.PlottedCourse.Count() - 1].Latitude;
						out_lon = Navigator.PlottedCourse[Navigator.PlottedCourse.Count() - 1].Longitude;
						lat = out_lat;
						lon = out_lon;
					}
					Geodesic_EdWilliams.CalcPoint_Williams(out_lon, out_lat, ref out_lon2, ref out_lat2, (double)MissDistanceFromTargetingPoint_m * 0.000539957, MissBearingFromTargetPoint);
					num2 = (Module_ActiveUnit.IsAimpointFacility(theTarget) ? ((float)((double)Math2.CalcDist(out_lat2, out_lon2, lat, lon) * 1852.0)) : ((float)((double)Math2.CalcDist(out_lat2, out_lon2, theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null)) * 1852.0)));
					bearingFromImpact = Math2.CalcAzimuth(theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null), out_lat2, out_lon2);
					flag3 = !Warheads[0].get_IsAirburst(this, theTarget) && CheckForDirectHit(theTarget, out_lat2, out_lon2, num2, LaunchPoint, MaxRange_NoTargetType, IsUnguidedWeapon: false);
					if (flag3 && !Flags.Fuze_ShockFactor_Under_Keel_Optimized)
					{
						weaponImpactEventHandler_0?.Invoke(ParentScen, this, theTarget, DirectHit: false);
					}
					if (Warheads.Length <= 0 || !Warheads[0].IsCluster)
					{
						if (Warheads[0].IsExplosive)
						{
							if (flag)
							{
								if (!flag3)
								{
									if (!Module_ActiveUnit.IsAimpointFacility(theTarget))
									{
										if (Warheads[0].get_IsAirburst(this, theTarget))
										{
											string text2 = "Airbursted off ";
											if (IsUnderwater || IsUnderground || CurrentAltitude_AGL == 0f)
											{
												text2 = "Missed ";
											}
											text = ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? (text2 + theTarget.Name + " by " + Conversions.ToString(Math.Max(1, (int)Math.Round(num2))) + "m") : (text2 + theTarget.Name + " by " + Conversions.ToString(Math.Max(1, (int)Math.Round(num2 * 3.28084f))) + "ft"));
											base.EndgameReport.AddEndGameMessage(hit: false, text);
										}
										else
										{
											text = ((!(num2 < 926f)) ? ("Missed " + theTarget.Name + " by " + Conversions.ToString(Math.Round(num2 / 1852f, 1)) + "nm") : ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? ("Missed " + theTarget.Name + " by " + Conversions.ToString(Math.Max(1, (int)Math.Round(num2))) + "m") : ("Missed " + theTarget.Name + " by " + Conversions.ToString(Math.Max(1, (int)Math.Round(num2 * 3.28084f))) + "ft")));
											base.EndgameReport.AddEndGameMessage(hit: false, text);
										}
									}
									if (!IsTorpedo)
									{
										if (ImpactAltitude != 0f)
										{
											num3 = ImpactAltitude;
										}
										else
										{
											Warhead obj = Warheads[0];
											if (obj != null && obj.get_IsAirburst(this, theTarget))
											{
												num3 = Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ParentScen) + this.get_OptimumBurstHeight_AGL(theTarget);
											}
										}
									}
									else
									{
										num3 = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
									}
									if (num3 >= 0f)
									{
										flag4 = true;
									}
									else
									{
										int num4;
										if (Warheads[0].get_IsNuclear(ParentScen))
										{
											num4 = 1;
										}
										else if (IsTorpedo)
										{
											num4 = 1;
										}
										else
										{
											if (!Warheads[0].get_IsAirburst(this, theTarget))
											{
												flag4 = false;
												goto IL_0969;
											}
											num4 = 1;
										}
										flag4 = (byte)num4 != 0;
									}
									goto IL_0969;
								}
								if (!Warheads[0].get_IsAirburst(this, theTarget))
								{
									if (Flags.Fuze_ShockFactor_Under_Keel_Optimized && theTarget.IsShip)
									{
										text = "Detonated directly under target: " + theTarget.Name;
										double theLat = theTarget.get_Latitude((GlobalVariables.BooleanObject)null);
										double theLon = theTarget.get_Longitude((GlobalVariables.BooleanObject)null);
										float theAlt = 0f - (((Ship)theTarget).Draft + 10f);
										LockRandom theRNG2 = GameGeneral.GlobalRNG;
										Detonate(theLat, theLon, theAlt, ref theRNG2, Detonation_AddMessage: true);
									}
									else
									{
										Impact(theTarget, null);
										flag2 = true;
									}
								}
								else if (base.IsMissile && IsAAWCapable && (theTarget.IsShip || theTarget.IsFacility))
								{
									if (theTarget.VisualSizeClass > GlobalVariables.TargetVisualSizeClass.VSmall)
									{
										Impact(theTarget, null);
										flag2 = true;
									}
									else
									{
										text = "Airbursted directly on top of " + theTarget.Name;
										base.EndgameReport.AddEndGameMessage(hit: true, text);
										ActiveUnit_Damage damage = theTarget.Damage;
										GeoPoint launchPoint = LaunchPoint;
										string PreferredAimpoint = "";
										damage.ResolveDamageFromWeapon(this, launchPoint, num2, bearingFromImpact, null, null, null, null, ref PreferredAimpoint, flag3, null);
									}
								}
								else
								{
									text = "Airbursted directly on top of " + theTarget.Name;
									base.EndgameReport.AddEndGameMessage(hit: true, text);
									ActiveUnit_Damage damage2 = theTarget.Damage;
									GeoPoint launchPoint2 = LaunchPoint;
									string PreferredAimpoint = "";
									damage2.ResolveDamageFromWeapon(this, launchPoint2, num2, bearingFromImpact, null, null, null, null, ref PreferredAimpoint, flag3, null);
								}
							}
							else
							{
								text = "Has malfunctioned";
								base.EndgameReport.AddEndGameMessage(hit: false, text);
								ParentScen.DestroyThisUnit(this, text, "Malfunction");
							}
						}
						else if (!flag)
						{
							text = "Has malfunctioned";
							base.EndgameReport.AddEndGameMessage(hit: false, text);
							ParentScen.DestroyThisUnit(this, text, "Malfunction");
						}
						else if (flag3)
						{
							Impact(theTarget, null);
							flag2 = true;
						}
						else if (!Warheads[0].get_IsAirburst(this, theTarget))
						{
							text = ((!(num2 > 926f)) ? ("Missed " + theTarget.Name + " by " + Conversions.ToString(Math.Round(num2 / 1852f, 1)) + "nm") : ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? ("Missed " + theTarget.Name + " by " + Conversions.ToString(Math.Max(1, (int)Math.Round(num2))) + "m") : ("Missed " + theTarget.Name + " by " + Conversions.ToString(Math.Max(1, (int)Math.Round(num2 * 3.28084f))) + "ft")));
							base.EndgameReport.AddEndGameMessage(hit: false, text);
						}
						else
						{
							text = ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? ("Airbursted off " + theTarget.Name + " by " + Conversions.ToString(Math.Max(1, (int)Math.Round(num2))) + "m") : ("Airbursted off " + theTarget.Name + " by " + Conversions.ToString(Math.Max(1, (int)Math.Round(num2 * 3.28084f))) + "ft"));
							base.EndgameReport.AddEndGameMessage(hit: false, text);
						}
						goto IL_0da8;
					}
					int num5;
					if (!flag)
					{
						text = "Has malfunctioned";
						base.EndgameReport.AddEndGameMessage(hit: false, text);
						ParentScen.DestroyThisUnit(this, text, "Malfunction");
						num5 = 0;
					}
					else
					{
						float theAltitude = Math.Max(0, (int)Terrain.GetElevation(out_lat2, out_lon2, RequestIsFromGUI: false, theScen)) + this.get_OptimumBurstHeight_AGL(theTarget);
						bool flag5 = false;
						Warhead[] warheads = Warheads;
						foreach (Warhead warhead in warheads)
						{
							if (warhead.IsCluster)
							{
								Weapon_AI aI;
								Contact thePrimaryTarget = (aI = AI).PrimaryTarget;
								Explosion explosion = new Explosion(ref theScen, this, ref thePrimaryTarget, out_lon2, out_lat2, out_lon2, out_lat2, CurrentHeading, theAltitude, Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, null, null, warhead.ClusterBombDispersionAreaLength, warhead.ClusterBombDispersionAreaWidth, warhead.NumberOfWarheads);
								aI.PrimaryTarget = thePrimaryTarget;
								explosion.CurrentHeading = CurrentHeading;
								Geopoint_Struct[] theArea = explosion.get_ClusterFallBox(1f);
								if (((Module_Unit.Unit)theTarget).get_IsInsideThisArea(theArea, theScen, UseCache: false))
								{
									flag5 = true;
								}
							}
						}
						text = (flag5 ? ("Impacted " + theTarget.Name + ", dispensing submunitions") : ((!((double)num2 < 926.0)) ? ("Missed " + theTarget.Name + " by " + Conversions.ToString(Math.Round(num2 / 1852f, 1)) + "nm, dispensing submunitions") : ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? ("Missed " + theTarget.Name + " by " + Conversions.ToString(Math.Max(1, (int)Math.Round(num2))) + "m, dispensing submunitions") : ("Missed " + theTarget.Name + " by " + Conversions.ToString(Math.Max(1, (int)Math.Round(num2 * 3.28084f))) + "ft, dispensing submunitions"))));
						base.EndgameReport.AddEndGameMessage(hit: false, text);
						num5 = 0;
					}
					result = (byte)num5 != 0;
				}
			}
			goto end_IL_0001;
			IL_0969:
			if (flag4)
			{
				if (Warheads[0].get_IsAirburst(this, theTarget))
				{
					double theLat2 = out_lat2;
					double theLon2 = out_lon2;
					float theAlt2 = num3;
					LockRandom theRNG2 = GameGeneral.GlobalRNG;
					Detonate(theLat2, theLon2, theAlt2, ref theRNG2, Detonation_AddMessage: true);
					flag2 = true;
				}
				else
				{
					ActiveUnit_Damage damage3 = theTarget.Damage;
					GeoPoint launchPoint3 = LaunchPoint;
					float num6 = default(float);
					float distanceFromImpact_meters = num2 - num6;
					string PreferredAimpoint = "";
					damage3.ResolveDamageFromWeapon(this, launchPoint3, distanceFromImpact_meters, bearingFromImpact, null, null, null, null, ref PreferredAimpoint, flag3, null);
				}
			}
			goto IL_0da8;
			IL_0da8:
			if (!flag2)
			{
				ExportResolveImpactEvent(theTarget, ImpactWillOccur: false, HitResultsInKill: false, new StringBuilder(text));
			}
			result = flag3;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100958", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num7;
			if (!Debugger.IsAttached)
			{
				num7 = 0;
			}
			else
			{
				Debugger.Break();
				num7 = 0;
			}
			result = (byte)num7 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool Impact_CEP_MissDistanceAndDirection(ActiveUnit theTarget, ref Scenario theScen, ref float MissDistanceFromTargetingPoint_m, ref float MissBearingFromTargetPoint, ref LockRandom theRNG)
	{
		if (nullable_16.HasValue)
		{
			MissDistanceFromTargetingPoint_m = nullable_17.Value;
			MissBearingFromTargetPoint = nullable_18.Value;
		}
		else
		{
			nullable_16 = Impact_CEP_MissDistanceAndDirection_uncachedInternal(theTarget, ref theScen, ref MissDistanceFromTargetingPoint_m, ref MissBearingFromTargetPoint, ref theRNG);
			nullable_17 = MissDistanceFromTargetingPoint_m;
			nullable_18 = MissBearingFromTargetPoint;
		}
		return nullable_16.Value;
	}

	private GEnum1 method_41()
	{
		if (Guidance != WeaponGuidanceType.Inertial)
		{
			return GEnum1.None;
		}
		int result;
		switch (Type)
		{
		case _WeaponType.Gun:
			result = 9;
			break;
		default:
			if (MaxRange_NoTargetType > 162f)
			{
				return GEnum1.INS_1990s_StrategicWeapon;
			}
			return GEnum1.INS_1990s_TacticalWeapon;
		case _WeaponType.Rocket:
			result = 9;
			break;
		}
		return (GEnum1)result;
	}

	private float method_42(int int_9, bool bool_5)
	{
		GEnum1 gEnum = method_41();
		float num;
		switch (gEnum)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return 0f;
		case GEnum1.INS_1990s_TacticalWeapon:
			num = (float)((double)int_9 / 3600.0 * 0.5);
			break;
		case GEnum1.INS_1990s_StrategicWeapon:
			num = (float)((double)int_9 / 3600.0 * 0.05);
			break;
		case GEnum1.INS_1990s_MEMSBased:
			num = (float)((double)int_9 / 3600.0 * 5.0);
			break;
		}
		float num2 = (float)(GameGeneral.GlobalRNG.NextDouble() * (double)num);
		if (bool_5)
		{
			ParentScen.AddMessage("Weapon: " + Name + " has been without a GNSS update for " + Misc.TimeString(int_9) + ". Weapon has INS: " + Misc.ToEnglishString(gEnum) + ". Max drift: " + Conversions.ToString(Math.Round((double)num * 1852.0)) + "m. Actual drift (CEP increase): " + Conversions.ToString(Math.Round((double)num2 * 1852.0)) + "m", "Weapon INS drift: " + Conversions.ToString(Math.Round((double)num2 * 1852.0)) + "m", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
		}
		return (float)((double)num2 * 1852.0);
	}

	public bool Impact_CEP_MissDistanceAndDirection_uncachedInternal(ActiveUnit theTarget, ref Scenario theScen, ref float MissDistanceFromTargetingPoint_m, ref float MissBearingFromTargetPoint, ref LockRandom theRNG)
	{
		bool result;
		try
		{
			float num = ((theTarget == null) ? ((float)Math.Max(CEP_Land, CEP_Surface)) : (theTarget.IsFacility ? ((float)CEP_Land) : ((float)CEP_Surface)));
			if (Guidance != WeaponGuidanceType.Inertial || theTarget == null)
			{
				goto IL_0241;
			}
			if (!Navigator.HasPlottedCourse())
			{
				goto IL_00b3;
			}
			Waypoint waypoint = Navigator.PlottedCourse.Last();
			double num2 = Geodesic_Haversine.Distance_Horiz_Approx_nm(waypoint.Latitude, waypoint.Longitude, theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null));
			double num3 = 0.01 + (double)(CurrentSpeed / 3600f * 1.1f);
			if (!(num2 > num3))
			{
				goto IL_00b3;
			}
			result = false;
			goto end_IL_0001;
			IL_03f0:
			MissBearingFromTargetPoint = (float)(theRNG.NextDouble() * 359.99);
			double num4 = theRNG.NextDouble();
			if (num4 <= 0.5)
			{
				MissDistanceFromTargetingPoint_m = (float)((double)theRNG.Next(0, 101) / 100.0 * (double)num);
			}
			else if (num4 < 0.937)
			{
				MissDistanceFromTargetingPoint_m = (float)((double)num + (double)num * theRNG.NextDouble());
			}
			else
			{
				MissDistanceFromTargetingPoint_m = (float)((double)(2f * num) + (double)num * theRNG.NextDouble());
			}
			if (ARM_SpecifiedEMission.Value == null)
			{
				goto IL_04d6;
			}
			int num5;
			if (theTarget == null)
			{
				num5 = 1;
			}
			else
			{
				if (!(theTarget.CurrentSpeed > 0f) || !(ARM_SpecifiedEMission.Value.Age > 1f))
				{
					goto IL_04d6;
				}
				MissDistanceFromTargetingPoint_m += ARM_SpecifiedEMission.Value.Age / 3600f * theTarget.CurrentSpeed * 1852f;
				num5 = 1;
			}
			goto IL_04d7;
			IL_04d6:
			num5 = 1;
			goto IL_04d7;
			IL_00b3:
			float num6 = theTarget.Kinematics.GetMaximumSpeed(theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Throttle.Flank, ValidateAndFixAltitude: false);
			float num7 = ((!(num6 > 0f)) ? 0f : (theTarget.CurrentSpeed / num6));
			num = (theTarget.IsFacility ? ((float)CEP_Land + (float)CEP_Land * num7) : ((float)CEP_Surface + (float)CEP_Surface * num7));
			if (UsesGNSSTerminalGuidance())
			{
				int num8 = 0;
				foreach (bool recentPNTCheck in RecentPNTChecks)
				{
					if (recentPNTCheck)
					{
						num8++;
					}
				}
				double num9 = (double)num8 / (double)RecentPNTChecks.Count;
				num = Math.Max(num, (float)GNSS.EstimateCurrentAccuracyKF(num, RecentPNTChecks));
				ParentScen.AddMessage("Weapon: " + Name + " has a " + Conversions.ToString((int)Math.Round(num9 * 100.0)) + "% rate on recent GNSS updates - CEP adjusted to: " + Conversions.ToString(Math.Round(num, 1)) + "m", "Weapon accuracy", LoggedMessage.MessageType.WeaponEndgame, 0, ObjectID, null, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			goto IL_0241;
			IL_0241:
			if (!ValidTargets.Radar)
			{
				goto IL_03f0;
			}
			if (ARM_SpecifiedEMission.Value != null)
			{
				if (!(ARM_SpecifiedEMission.Value.Age <= 1f))
				{
					if (!Flags.ARMTargetMemory)
					{
						float num10 = Math.Min(ARM_SpecifiedEMission.Value.Age, (float)Fuel_ReadOnly[0].MaxQuantity - Fuel_ReadOnly[0].CurrentQuantity);
						num += num10 * 20f;
					}
					else
					{
						num = Math.Min(num * 5f, num + ARM_SpecifiedEMission.Value.Age * 100f);
					}
				}
				int key = ARM_SpecifiedEMission.Key;
				SQLiteConnection sqliteConnection_ = ParentScen.DBConnection;
				Sensor sensor = DBFunctions.GetSensor(key, ref sqliteConnection_);
				float num11 = 1f;
				Sensor.FrequencyBand frequencyBand = Sensor.FrequencyBand.A_Band;
				Sensor.RadioElectronicFrequency[] searchFreqs = sensor.SearchFreqs;
				foreach (Sensor.RadioElectronicFrequency radioElectronicFrequency in searchFreqs)
				{
					if (Conversion.Int((long)radioElectronicFrequency.Band) > 1001L && Conversion.Int((long)radioElectronicFrequency.Band) <= 1013L && Conversion.Int((long)radioElectronicFrequency.Band) > Conversion.Int((long)frequencyBand))
					{
						frequencyBand = radioElectronicFrequency.Band;
					}
				}
				switch (frequencyBand)
				{
				case Sensor.FrequencyBand.A_Band:
					num11 = 1.6f;
					break;
				case Sensor.FrequencyBand.B_Band:
					num11 = 1.2f;
					break;
				}
				num *= num11;
				goto IL_03f0;
			}
			if (IsDualModeARM || isLoiterCapable)
			{
				goto IL_03f0;
			}
			base.EndgameReport.AddEndGameMessage(hit: false, "Had no emission lock and no alternative sensor.... clean miss");
			result = false;
			goto end_IL_0001;
			IL_04d7:
			result = (byte)num5 != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101339", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num12;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num12 = 0;
			}
			else
			{
				num12 = 0;
			}
			result = (byte)num12 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool IsGuidedOrUnguidedGun()
	{
		int result;
		switch (Type)
		{
		case _WeaponType.GuidedProjectile:
			result = 1;
			break;
		default:
			return false;
		case _WeaponType.Gun:
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	public void Impact(ActiveUnit theTarget, StringBuilder AttackMessageSB)
	{
		try
		{
			Geopoint_Struct location = theTarget.Location;
			bool flag = false;
			Geopoint_Struct geopoint_Struct;
			if (theTarget.IsAerospaceUnit)
			{
				geopoint_Struct = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(this, CurrentSpeed, theTarget).InterceptPoint;
				if (geopoint_Struct.HasZeroCoords)
				{
					geopoint_Struct = theTarget.Location;
				}
				else
				{
					flag = true;
					theTarget.set_Latitude((GlobalVariables.BooleanObject)null, geopoint_Struct.Latitude);
					theTarget.set_Longitude((GlobalVariables.BooleanObject)null, geopoint_Struct.Longitude);
				}
			}
			else
			{
				geopoint_Struct = theTarget.Location;
			}
			this.set_Latitude((GlobalVariables.BooleanObject)null, geopoint_Struct.Latitude);
			this.set_Longitude((GlobalVariables.BooleanObject)null, geopoint_Struct.Longitude);
			if (AttackMessageSB != null)
			{
				AttackMessageSB.Append("\r\n");
			}
			else
			{
				AttackMessageSB = new StringBuilder();
			}
			string text = "";
			if (!IsDecoy)
			{
				weaponImpactEventHandler_0?.Invoke(ParentScen, this, theTarget, DirectHit: true);
				new WeaponImpact(ref theTarget.ParentScen, theTarget.get_Longitude((GlobalVariables.BooleanObject)null), theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Command_Core.WeaponImpact.ImpactType.Kinetic, DBID);
			}
			if (!IsNuke.Value)
			{
				bool flag2 = false;
				int num;
				Weapon weapon = default(Weapon);
				if (!theTarget.IsWeapon)
				{
					num = 0;
				}
				else
				{
					weapon = (Weapon)theTarget;
					flag2 = (weapon.IsReEntryVehicle || weapon.IsBallisticMissile) && !weapon.IsHGV;
					num = 0;
				}
				bool flag3 = (byte)num != 0;
				if (!flag2)
				{
					if (!theTarget.IsAircraft && !theTarget.IsMissile)
					{
						text = ((!theTarget.IsFacility) ? ("Has impacted " + theTarget.Name) : ((!((Facility)theTarget).HasAimpoints) ? ("Has impacted " + theTarget.Name) : ""));
						AttackMessageSB.Append(text);
						ActiveUnit_Damage damage = theTarget.Damage;
						GeoPoint launchPoint = LaunchPoint;
						string PreferredAimpoint = "";
						damage.ResolveDamageFromWeapon(this, launchPoint, 0f, 0f, null, null, null, null, ref PreferredAimpoint, DirectHit: true, null);
						flag3 = theTarget.IsMorituri;
					}
					else
					{
						ActiveUnit_Damage damage2 = theTarget.Damage;
						GeoPoint launchPoint2 = LaunchPoint;
						string PreferredAimpoint = "";
						damage2.ResolveDamageFromWeapon(this, launchPoint2, 0f, 0f, null, null, null, null, ref PreferredAimpoint, DirectHit: true, null);
						flag3 = theTarget.IsMorituri;
					}
				}
				else
				{
					switch (Warheads[0].Type)
					{
					default:
					{
						text += "Conventional warhead: 15% chance of outright destruction, 30% chance of significant deviation. ";
						int num4 = GameGeneral.GlobalRNG.Next(1, 101);
						int num5 = num4;
						if (num5 <= 15)
						{
							text = text + "RESULT: " + Conversions.ToString(num4) + ". Target destroyed outright";
							flag3 = true;
						}
						else if (num5 <= 30)
						{
							text = text + "RESULT: " + Conversions.ToString(num4) + ". Significant trajectory deviation (CEP of target weapon tripled)";
							weapon.CEP_Land *= 3;
							weapon.CEP_Surface *= 3;
							theTarget.ParentScen.AddMessage(text, Name + " impacted " + theTarget.Name + " - major deflection", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, theTarget.Location);
							flag3 = false;
						}
						else
						{
							text = text + "RESULT: " + Conversions.ToString(num4) + ". Minor trajectory deviation (CEP of target weapon multipled by 1.5)";
							weapon.CEP_Land = (int)Math.Round((double)weapon.CEP_Land * 1.5);
							weapon.CEP_Surface = (int)Math.Round((double)weapon.CEP_Surface * 1.5);
							theTarget.ParentScen.AddMessage(text, Name + " impacted " + theTarget.Name + " - minor deflection", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, theTarget.Location);
							flag3 = false;
						}
						break;
					}
					case Warhead.WarheadType.Fragmentation_ABM:
					{
						text += "ABM-optimized fragmentation warhead: 30% chance of outright destruction, 60% chance of significant deviation. ";
						int num2 = GameGeneral.GlobalRNG.Next(1, 101);
						int num3 = num2;
						if (num3 <= 30)
						{
							text = text + "RESULT: " + Conversions.ToString(num2) + ". Target destroyed outright. ";
							flag3 = true;
						}
						else if (num3 <= 60)
						{
							text = text + "RESULT: " + Conversions.ToString(num2) + ". Significant trajectory deviation (CEP of target weapon tripled)";
							weapon.CEP_Land *= 3;
							weapon.CEP_Surface *= 3;
							theTarget.ParentScen.AddMessage(text, Name + " impacted " + theTarget.Name + " - major deflection", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, theTarget.Location);
							flag3 = false;
						}
						else
						{
							text = text + "RESULT: " + Conversions.ToString(num2) + ". Minor trajectory deviation (CEP of target weapon multipled by 1.5)";
							weapon.CEP_Land = (int)Math.Round((double)weapon.CEP_Land * 1.5);
							weapon.CEP_Surface = (int)Math.Round((double)weapon.CEP_Surface * 1.5);
							theTarget.ParentScen.AddMessage(text, Name + " impacted " + theTarget.Name + " - minor deflection", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, theTarget.Location);
							flag3 = false;
						}
						break;
					}
					case Warhead.WarheadType.ArmorPiercing:
					case Warhead.WarheadType.Kinetic:
						text += "Hit-To-Kill warhead: Target destroyed outright. ";
						flag3 = true;
						break;
					}
					AttackMessageSB.Append(text);
					if (flag3)
					{
						ActiveUnit_Damage damage3 = theTarget.Damage;
						GeoPoint launchPoint3 = LaunchPoint;
						string PreferredAimpoint = "";
						damage3.ResolveDamageFromWeapon(this, launchPoint3, 0f, 0f, null, null, null, null, ref PreferredAimpoint, DirectHit: true, null);
					}
				}
				ExportResolveImpactEvent(theTarget, ImpactWillOccur: true, flag3, AttackMessageSB);
				if (Operators.CompareString(text, "", false) != 0)
				{
					base.EndgameReport.AddEndGameMessage(hit: true, text);
				}
				if (flag && !flag3)
				{
					theTarget.set_Latitude((GlobalVariables.BooleanObject)null, location.Latitude);
					theTarget.set_Longitude((GlobalVariables.BooleanObject)null, location.Longitude);
				}
			}
			else
			{
				double theLat = this.get_Latitude((GlobalVariables.BooleanObject)null);
				double theLon = this.get_Longitude((GlobalVariables.BooleanObject)null);
				float theAlt = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				LockRandom theRNG = GameGeneral.GlobalRNG;
				Detonate(theLat, theLon, theAlt, ref theRNG, Detonation_AddMessage: true);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100959", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool HasMandatoryDatalink()
	{
		CommDevice[] comms_ReadOnly = Comms_ReadOnly;
		int num = 0;
		while (true)
		{
			if (num < comms_ReadOnly.Length)
			{
				if (!comms_ReadOnly[num].IsOptional)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return false;
		}
		return true;
	}

	public override void Destroy(bool ScenEditAction, bool IsAimpointFacility, bool DestroyUnitNow, string theReason, string WhatCausedIt = null, bool RegisterAsLosses = true)
	{
		if (ParentScen == null)
		{
			return;
		}
		IsBeingDestroyed = true;
		try
		{
			if (AI.PrimaryTarget != null && !AI.PrimaryTarget.get_IsDestroyed(ParentScen) && AI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint && AI.PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint && AI.PrimaryTarget.ActualUnit != null)
			{
				if (AI.PrimaryTarget.ActualUnit.AI.Threats_ReadOnly != null)
				{
					foreach (Contact item in AI.PrimaryTarget.ActualUnit.AI.Threats_ReadOnly)
					{
						if (item?.ActualUnit == this)
						{
							AI.PrimaryTarget.ActualUnit.AI.DropThreat(item);
							break;
						}
					}
				}
				AI.PrimaryTarget.ActualUnit.AI.PrimaryThreat = null;
			}
			foreach (ActiveUnit value in ParentScen.ActiveUnits.Values)
			{
				if (value == null)
				{
					continue;
				}
				if (value.IsWeapon)
				{
					foreach (Sensor item2 in ((Weapon)value).WeaponSensors())
					{
						if (item2 != null && item2.SemiActiveWeaponsGuided.Contains(this))
						{
							item2.SemiActiveWeaponsGuided.Remove(this);
							SensorProvidingFireControlForMe = null;
						}
						if (item2 != null && item2.SemiActiveWeaponsGuided.Count == 0)
						{
							item2.StopTrackingTarget(AI.PrimaryTarget);
						}
					}
					continue;
				}
				Sensor[] sensors_Cached = value.Sensors_Cached;
				foreach (Sensor sensor in sensors_Cached)
				{
					if (sensor != null && sensor.SemiActiveWeaponsGuided.Contains(this))
					{
						sensor.SemiActiveWeaponsGuided.Remove(this);
						SensorProvidingFireControlForMe = null;
					}
					if (sensor != null && sensor.SemiActiveWeaponsGuided.Count == 0)
					{
						sensor.StopTrackingTarget(AI.PrimaryTarget);
					}
				}
			}
			ClearAllComms();
			base.Destroy(ScenEditAction, IsAimpointFacility, DestroyUnitNow, theReason, WhatCausedIt, RegisterAsLosses);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200343", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DetermineGuidance(bool IgnoreChace = false)
	{
		if (!IgnoreChace && CachedGuidance.HasValue)
		{
			Guidance = CachedGuidance.Value;
		}
		else if (Type != _WeaponType.Decoy_Vehicle && Type != _WeaponType.UAV_Expendable)
		{
			if (!Flags.IlluminateAtLaunch)
			{
				if (Directors.Count > 0 && Comms_ReadOnly.Count() == 0 && !Flags.TerminalIllumination && base.HasRadarSensor)
				{
					Guidance = WeaponGuidanceType.TimesharedSemiActive_Plus_Active;
					if (!IgnoreChace)
					{
						CachedGuidance = Guidance;
					}
				}
				else if (!Flags.TerminalIllumination)
				{
					if (!base.HasRadarSensor && !HasActiveCapableSonarSensor())
					{
						if (HasPassiveSensor() && Type != _WeaponType.Microwave)
						{
							if (!Flags.BearingOnlyLaunch && !Flags.Navigation_INS && !Flags.Navigation_INS_GPS && !Flags.Navigation_TERCOM)
							{
								if (Comms_ReadOnly.Count() != 0)
								{
									Guidance = WeaponGuidanceType.DataLink_Plus_Passive;
									if (!IgnoreChace)
									{
										CachedGuidance = Guidance;
									}
								}
								else
								{
									Guidance = WeaponGuidanceType.Passive;
									if (!IgnoreChace)
									{
										CachedGuidance = Guidance;
									}
								}
							}
							else
							{
								if (Comms_ReadOnly.Count() != 0)
								{
									Guidance = WeaponGuidanceType.DataLink_Plus_Passive;
								}
								else
								{
									Guidance = WeaponGuidanceType.Inertial_Plus_Passive;
								}
								if (!IgnoreChace)
								{
									CachedGuidance = Guidance;
								}
							}
						}
						else if (Comms_ReadOnly.Count() <= 0)
						{
							Guidance = WeaponGuidanceType.Inertial;
							if (!IgnoreChace)
							{
								CachedGuidance = Guidance;
							}
						}
						else
						{
							Guidance = WeaponGuidanceType.CommandGuided_Datalinked;
							if (!IgnoreChace)
							{
								CachedGuidance = Guidance;
							}
						}
					}
					else if (Flags.BearingOnlyLaunch)
					{
						if (Comms_ReadOnly.Count() == 0)
						{
							Guidance = WeaponGuidanceType.Inertial_Plus_Active;
						}
						else
						{
							Guidance = WeaponGuidanceType.Datalink_Plus_Active;
						}
						if (!IgnoreChace)
						{
							CachedGuidance = Guidance;
						}
					}
					else
					{
						if (Comms_ReadOnly.Count() != 0)
						{
							Guidance = WeaponGuidanceType.Datalink_Plus_Active;
						}
						else
						{
							Guidance = WeaponGuidanceType.Active;
						}
						if (!IgnoreChace)
						{
							CachedGuidance = Guidance;
						}
					}
				}
				else
				{
					if (Comms_ReadOnly.Count() != 0)
					{
						Guidance = WeaponGuidanceType.Datalink_Plus_SemiActive;
					}
					else if (!base.HasInfraredSensor)
					{
						Guidance = WeaponGuidanceType.Inertial_Plus_SemiActive;
					}
					else if (!Flags.BearingOnlyLaunch && !Flags.Navigation_INS && !Flags.Navigation_INS_GPS && !Flags.Navigation_TERCOM)
					{
						Guidance = WeaponGuidanceType.Passive;
					}
					else
					{
						Guidance = WeaponGuidanceType.Inertial_Plus_Passive;
					}
					if (!IgnoreChace)
					{
						CachedGuidance = Guidance;
					}
				}
			}
			else if (_Sensors.Count > 0)
			{
				switch (_Sensors[0].Type)
				{
				case Sensor.Sensor_Type.LaserSpotTracker:
					Guidance = WeaponGuidanceType.SemiActive;
					break;
				case Sensor.Sensor_Type.SemiActive:
					Guidance = WeaponGuidanceType.SemiActive;
					break;
				case Sensor.Sensor_Type.Radar:
					Guidance = WeaponGuidanceType.SemiActive_Plus_Active;
					break;
				}
				if (!IgnoreChace)
				{
					CachedGuidance = Guidance;
				}
			}
			else if (Comms_ReadOnly.Count() > 0)
			{
				Guidance = WeaponGuidanceType.TVM;
				if (!IgnoreChace)
				{
					CachedGuidance = Guidance;
				}
			}
			else
			{
				Guidance = WeaponGuidanceType.BeamRiding;
				if (!IgnoreChace)
				{
					CachedGuidance = Guidance;
				}
			}
		}
		else
		{
			Guidance = WeaponGuidanceType.Inertial;
		}
	}

	internal float SeaSkimmerModifier(float theAltitude)
	{
		if (theAltitude >= 91.44f)
		{
			return 0f;
		}
		if (theAltitude >= 60.96f)
		{
			return 5f;
		}
		if (theAltitude >= 30.48f)
		{
			return 15f;
		}
		return 30f;
	}

	public override void DoFuelConsumption(float elapsedTime)
	{
		try
		{
			if (IsParachuteLoitering)
			{
				return;
			}
			if (UsesBoostCoastModel.Value && TotalBurnTime == 0)
			{
				RecalculateWeaponFlightEnergyIfNecessary(this, ParentScen, WasAirLaunched(), LaunchSpeed);
			}
			if (UsesBoostCoastModel.Value)
			{
				if (!(TimeSinceLaunch > (float)TotalBurnTime))
				{
					return;
				}
				int num = Kinematics.StallSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				if (!(CurrentSpeed < (float)num))
				{
					return;
				}
				if (IsNuke.Value && !IsAAWCapable)
				{
					double theLat = this.get_Latitude((GlobalVariables.BooleanObject)null);
					double theLon = this.get_Longitude((GlobalVariables.BooleanObject)null);
					float theAlt = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					LockRandom theRNG = GameGeneral.GlobalRNG;
					Detonate(theLat, theLon, theAlt, ref theRNG, Detonation_AddMessage: true);
				}
				else
				{
					string text = "Has run out of energy... self-destructing";
					if (Type != _WeaponType.Sonobuoy)
					{
						base.EndgameReport.AddEndGameMessage(hit: false, text);
					}
					ParentScen.DestroyThisUnit(this, text);
				}
			}
			else
			{
				if (Fuel_ReadOnly.Count == 0)
				{
					return;
				}
				if (LaunchPoint != null && Type != _WeaponType.Sonobuoy && Type != _WeaponType.Torpedo && (double)Module_Unit.RangeToPoint_Horiz(this, LaunchPoint) > (double)MaxRange_NoTargetType * 1.25)
				{
					base.EndgameReport.AddEndGameMessage(hit: false, "Has run out of energy... self-destructing");
					ParentScen.DestroyThisUnit(this, "Run out of energy, self destructing");
					return;
				}
				if (_Fuel[0].CurrentQuantity == 0f)
				{
					if (SupportsAttitude_Pitch)
					{
						if (!Module_Unit.IsWithinAtmosphere(this))
						{
							if (IsBallisticMissile || IsReEntryVehicle || IsHGV)
							{
								return;
							}
						}
						else if (Attitude_Pitch < InfiniteGlideAngle)
						{
							return;
						}
					}
					if (!IsNuke.Value || IsAAWCapable)
					{
						if (Type != _WeaponType.Sonobuoy)
						{
							base.EndgameReport.AddEndGameMessage(hit: false, "Has run out of energy... self-destructing");
						}
						ParentScen.DestroyThisUnit(this, Message, "Out of Fuel");
						return;
					}
					double theLat2 = this.get_Latitude((GlobalVariables.BooleanObject)null);
					double theLon2 = this.get_Longitude((GlobalVariables.BooleanObject)null);
					float theAlt2 = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					LockRandom theRNG = GameGeneral.GlobalRNG;
					Detonate(theLat2, theLon2, theAlt2, ref theRNG, Detonation_AddMessage: true);
				}
				float num2 = FuelConsumption(ThrottleSetting, null, null, null, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
				_Fuel[0].SubtractFuel(elapsedTime * num2);
				if (_Fuel[0].CurrentQuantity < 0f)
				{
					_Fuel[0].CurrentQuantity = 0f;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100961", "");
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
		try
		{
			if (Propulsion.Count == 0)
			{
				result = 1f;
			}
			else
			{
				AltBand altBand;
				if (theAltBand == null)
				{
					if (!theAltitude.HasValue)
					{
						if (double.IsNaN(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) && FiringParent != null)
						{
							this.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, FiringParent.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
						}
						altBand = Kinematics.GetCurrentAltBand(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ValidateAndFixAltitude: false);
					}
					else
					{
						altBand = Kinematics.GetCurrentAltBand(theAltitude.Value, ValidateAndFixAltitude: false);
					}
				}
				else
				{
					altBand = theAltBand;
				}
				if (altBand == null)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new Exception();
				}
				result = theThrottleSetting switch
				{
					Throttle.Loiter => (!Information.IsNothing((object)altBand.Consumption_Loiter)) ? Math.Max(1f, altBand.Consumption_Loiter) : 0f, 
					Throttle.Cruise => altBand.Consumption_Cruise, 
					Throttle.Full => altBand.Consumption_Full.HasValue ? altBand.Consumption_Full.Value : altBand.Consumption_Cruise, 
					Throttle.Flank => altBand.Consumption_Flank.HasValue ? altBand.Consumption_Flank.Value : (altBand.Consumption_Full.HasValue ? altBand.Consumption_Full.Value : altBand.Consumption_Cruise), 
					_ => 0f, 
				};
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100962", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static float ModifierVsTargetSpeed_ABM_ASAT(int SourceAirPOK, Weapon theW, ActiveUnit theTarget, StringBuilder AttackMessage)
	{
		double num = theTarget.CurrentSpeed / (float)theW.MaxTargetSpeed;
		if (num <= 1.0)
		{
			return SourceAirPOK;
		}
		double num2 = (double)SourceAirPOK * Math.Exp(-12.0 * (num - 1.0));
		AttackMessage.Append(" PH adjusted for larger-than-max-design target speed (" + Conversions.ToString(theW.MaxTargetSpeed) + " vs " + Conversions.ToString((int)Math.Round(theTarget.CurrentSpeed)) + " kts): " + Conversions.ToString((int)Math.Round(num2)) + "%. ");
		return (float)num2;
	}

	public static float ModifierVsTargetSpeed(int SourceAirPOK, Weapon theW, ActiveUnit theTarget, StringBuilder AttackMessage)
	{
		float result;
		if (!theTarget.IsSatellite && (!theTarget.IsWeapon || !((Weapon)theTarget).IsBallisticMissile) && !((Weapon)theTarget).IsReEntryVehicle)
		{
			float num = 0f;
			int num2 = ((theW.MaxTargetSpeed > 0) ? theW.MaxTargetSpeed : 700);
			_ = theW.MinTargetSpeed;
			try
			{
				num = ((theTarget.CurrentSpeed > (float)num2) ? 50f : (((double)theTarget.CurrentSpeed > (double)num2 * 0.8) ? 25f : (((double)theTarget.CurrentSpeed > (double)num2 * 0.7) ? 15f : (((double)theTarget.CurrentSpeed > (double)num2 * 0.6) ? 10f : (((double)theTarget.CurrentSpeed > (double)num2 * 0.5) ? 5f : ((!((double)theTarget.CurrentSpeed > (double)num2 * 0.25)) ? (-20f) : (-10f)))))));
				if (theW.MinTargetSpeed >= 0)
				{
					if ((float)theW.MinTargetSpeed > theTarget.CurrentSpeed)
					{
						num = 5f;
					}
					else if ((double)theW.MinTargetSpeed > (double)theTarget.CurrentSpeed * 0.8)
					{
						num = Math.Max(num, 10f);
					}
					else if ((double)theW.MinTargetSpeed > (double)theTarget.CurrentSpeed * 0.7)
					{
						num = Math.Max(num, 15f);
					}
					else if ((double)theW.MinTargetSpeed > (double)theTarget.CurrentSpeed * 0.6)
					{
						num = Math.Max(num, 25f);
					}
					else if ((double)theW.MinTargetSpeed > (double)theTarget.CurrentSpeed * 0.5)
					{
						num = Math.Max(num, 50f);
					}
				}
				if (num != 0f)
				{
					AttackMessage.Append(" Target speed modifier: " + Conversions.ToString(-(int)Math.Round(num)) + "%. ");
				}
				result = Math.Max(1f, (float)SourceAirPOK - num);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100963", "");
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
			result = ModifierVsTargetSpeed_ABM_ASAT(SourceAirPOK, theW, theTarget, AttackMessage);
		}
		return result;
	}

	public static float ModifierVsTargetSignature(int SourceAirPOK, ActiveUnit FiringUnit, Weapon theW, ActiveUnit theTarget, Sensor theGuidingSensor, float TargetSignature_Radar_dbsm, float TargetSignature_IR, StringBuilder AttackMessage)
	{
		float num = default(float);
		if (theGuidingSensor != null)
		{
			switch (theGuidingSensor.Type)
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				num = 0f;
				break;
			case Sensor.Sensor_Type.LaserDesignator:
				num = 0f;
				break;
			case Sensor.Sensor_Type.ESM:
				num = 0f;
				break;
			case Sensor.Sensor_Type.Radar:
			case Sensor.Sensor_Type.SemiActive:
			{
				float num2 = (float)new RadarModel.TTarget
				{
					RCS = TargetSignature_Radar_dbsm
				}.RCS_m2;
				if (num2 > 1f)
				{
					num = 0f;
					break;
				}
				if (num2 > 0.1f)
				{
					GlobalVariables.TechGenerationClass techGeneration7 = theGuidingSensor.TechGeneration;
					if (techGeneration7 <= GlobalVariables.TechGenerationClass.const_4)
					{
						num = 40f;
					}
					else if (techGeneration7 <= GlobalVariables.TechGenerationClass.const_6)
					{
						num = 25f;
					}
					else if (techGeneration7 <= GlobalVariables.TechGenerationClass.const_8)
					{
						num = 15f;
					}
					else if (techGeneration7 <= GlobalVariables.TechGenerationClass.const_10)
					{
						num = 10f;
					}
					else if (techGeneration7 <= GlobalVariables.TechGenerationClass.const_12)
					{
						num = 5f;
					}
					break;
				}
				if (num2 > 0.01f)
				{
					GlobalVariables.TechGenerationClass techGeneration8 = theGuidingSensor.TechGeneration;
					if (techGeneration8 <= GlobalVariables.TechGenerationClass.const_4)
					{
						num = 50f;
					}
					else if (techGeneration8 <= GlobalVariables.TechGenerationClass.const_6)
					{
						num = 35f;
					}
					else if (techGeneration8 <= GlobalVariables.TechGenerationClass.const_8)
					{
						num = 20f;
					}
					else if (techGeneration8 <= GlobalVariables.TechGenerationClass.const_10)
					{
						num = 10f;
					}
					else if (techGeneration8 <= GlobalVariables.TechGenerationClass.const_12)
					{
						num = 5f;
					}
					break;
				}
				GlobalVariables.TechGenerationClass techGeneration9 = theGuidingSensor.TechGeneration;
				if (techGeneration9 <= GlobalVariables.TechGenerationClass.const_4)
				{
					num = 60f;
				}
				else if (techGeneration9 <= GlobalVariables.TechGenerationClass.const_6)
				{
					num = 45f;
				}
				else if (techGeneration9 <= GlobalVariables.TechGenerationClass.const_8)
				{
					num = 30f;
				}
				else if (techGeneration9 <= GlobalVariables.TechGenerationClass.const_10)
				{
					num = 20f;
				}
				else if (techGeneration9 <= GlobalVariables.TechGenerationClass.const_12)
				{
					num = 15f;
				}
				else if (techGeneration9 <= GlobalVariables.TechGenerationClass.const_14)
				{
					num = 10f;
				}
				else if (techGeneration9 <= GlobalVariables.TechGenerationClass.const_16)
				{
					num = 5f;
				}
				break;
			}
			case Sensor.Sensor_Type.Visual:
				switch (theTarget.VisualSizeClass)
				{
				case GlobalVariables.TargetVisualSizeClass.Stealthy:
				{
					GlobalVariables.TechGenerationClass techGeneration5 = theGuidingSensor.TechGeneration;
					if (techGeneration5 <= GlobalVariables.TechGenerationClass.const_4)
					{
						num = 60f;
					}
					else if (techGeneration5 <= GlobalVariables.TechGenerationClass.const_6)
					{
						num = 45f;
					}
					else if (techGeneration5 <= GlobalVariables.TechGenerationClass.const_8)
					{
						num = 30f;
					}
					else if (techGeneration5 <= GlobalVariables.TechGenerationClass.const_10)
					{
						num = 20f;
					}
					else if (techGeneration5 <= GlobalVariables.TechGenerationClass.const_12)
					{
						num = 15f;
					}
					else if (techGeneration5 <= GlobalVariables.TechGenerationClass.const_14)
					{
						num = 10f;
					}
					else if (techGeneration5 <= GlobalVariables.TechGenerationClass.const_16)
					{
						num = 5f;
					}
					break;
				}
				case GlobalVariables.TargetVisualSizeClass.VSmall:
				{
					GlobalVariables.TechGenerationClass techGeneration6 = theGuidingSensor.TechGeneration;
					if (techGeneration6 <= GlobalVariables.TechGenerationClass.const_4)
					{
						num = 50f;
					}
					else if (techGeneration6 <= GlobalVariables.TechGenerationClass.const_6)
					{
						num = 35f;
					}
					else if (techGeneration6 <= GlobalVariables.TechGenerationClass.const_8)
					{
						num = 20f;
					}
					else if (techGeneration6 <= GlobalVariables.TechGenerationClass.const_10)
					{
						num = 10f;
					}
					else if (techGeneration6 <= GlobalVariables.TechGenerationClass.const_12)
					{
						num = 5f;
					}
					break;
				}
				case GlobalVariables.TargetVisualSizeClass.Small:
				{
					GlobalVariables.TechGenerationClass techGeneration4 = theGuidingSensor.TechGeneration;
					if (techGeneration4 <= GlobalVariables.TechGenerationClass.const_4)
					{
						num = 40f;
					}
					else if (techGeneration4 <= GlobalVariables.TechGenerationClass.const_6)
					{
						num = 25f;
					}
					else if (techGeneration4 <= GlobalVariables.TechGenerationClass.const_8)
					{
						num = 15f;
					}
					else if (techGeneration4 <= GlobalVariables.TechGenerationClass.const_10)
					{
						num = 10f;
					}
					else if (techGeneration4 <= GlobalVariables.TechGenerationClass.const_12)
					{
						num = 5f;
					}
					break;
				}
				case GlobalVariables.TargetVisualSizeClass.Medium:
					num = 9f;
					break;
				case GlobalVariables.TargetVisualSizeClass.Large:
					num = 3f;
					break;
				}
				break;
			case Sensor.Sensor_Type.Infrared:
			{
				if (TargetSignature_IR > 1f)
				{
					num = 0f;
					break;
				}
				if (TargetSignature_IR > 0.5f)
				{
					GlobalVariables.TechGenerationClass techGeneration = theGuidingSensor.TechGeneration;
					if (techGeneration <= GlobalVariables.TechGenerationClass.const_4)
					{
						num = 40f;
					}
					else if (techGeneration <= GlobalVariables.TechGenerationClass.const_6)
					{
						num = 25f;
					}
					else if (techGeneration <= GlobalVariables.TechGenerationClass.const_8)
					{
						num = 15f;
					}
					else if (techGeneration <= GlobalVariables.TechGenerationClass.const_10)
					{
						num = 10f;
					}
					else if (techGeneration <= GlobalVariables.TechGenerationClass.const_12)
					{
						num = 5f;
					}
					break;
				}
				if (TargetSignature_IR > 0.25f)
				{
					GlobalVariables.TechGenerationClass techGeneration2 = theGuidingSensor.TechGeneration;
					if (techGeneration2 <= GlobalVariables.TechGenerationClass.const_4)
					{
						num = 50f;
					}
					else if (techGeneration2 <= GlobalVariables.TechGenerationClass.const_6)
					{
						num = 35f;
					}
					else if (techGeneration2 <= GlobalVariables.TechGenerationClass.const_8)
					{
						num = 20f;
					}
					else if (techGeneration2 <= GlobalVariables.TechGenerationClass.const_10)
					{
						num = 10f;
					}
					else if (techGeneration2 <= GlobalVariables.TechGenerationClass.const_12)
					{
						num = 5f;
					}
					break;
				}
				GlobalVariables.TechGenerationClass techGeneration3 = theGuidingSensor.TechGeneration;
				if (techGeneration3 <= GlobalVariables.TechGenerationClass.const_4)
				{
					num = 60f;
				}
				else if (techGeneration3 <= GlobalVariables.TechGenerationClass.const_6)
				{
					num = 45f;
				}
				else if (techGeneration3 <= GlobalVariables.TechGenerationClass.const_8)
				{
					num = 30f;
				}
				else if (techGeneration3 <= GlobalVariables.TechGenerationClass.const_10)
				{
					num = 20f;
				}
				else if (techGeneration3 <= GlobalVariables.TechGenerationClass.const_12)
				{
					num = 15f;
				}
				else if (techGeneration3 <= GlobalVariables.TechGenerationClass.const_14)
				{
					num = 10f;
				}
				else if (techGeneration3 <= GlobalVariables.TechGenerationClass.const_16)
				{
					num = 5f;
				}
				break;
			}
			}
			if (num != 0f)
			{
				AttackMessage.Append(" Target signature modifier: " + Conversions.ToString(-(int)Math.Round(num)) + "% (Director [" + theGuidingSensor.Name + "] has tech-gen: " + Misc.ToEnglishString(theGuidingSensor.TechGeneration) + "). ");
			}
		}
		float num3 = Math.Max(1f, (float)SourceAirPOK - num);
		bool? obj;
		if (theGuidingSensor != null)
		{
			obj = false;
		}
		else
		{
			bool? flag = FiringUnit?.IsAircraft;
			obj = (!flag) ?? flag;
		}
		bool? flag2 = obj;
		if ((flag2 ?? true) && theW.IsUnguidedBallisticWeapon && flag2.HasValue)
		{
			num3 -= 60f;
			AttackMessage.Append(" Weapon has been fired without director control (manual backup?). Hit probability reduced by 60%.");
		}
		return num3;
	}

	public void PrepareForReattack(Module_Unit.Unit OriginalTarget)
	{
		Module_Unit.BearingToUnit_True(this, OriginalTarget);
		_ = (double)RangeToUnit_Horiz(OriginalTarget);
		float num = ETA_To_Unit(OriginalTarget);
		TimeToReseek = Math.Max(num * 2f, 15f);
		SearchPatternType = WeaponSearchPatternType.Circle;
		foreach (Sensor sensor in _Sensors)
		{
			sensor.IsNeutralized = null;
		}
	}

	private bool method_43()
	{
		int result2;
		if (!IsMIRVedMissile.Value)
		{
			if (!IsMRVedMissile.Value)
			{
				int result;
				if (Warheads.Length > 0 && Warheads[0].Type == Warhead.WarheadType.Weapon)
				{
					if (Warheads[0].get_CarriedWeapon(ParentScen).IsReEntryVehicle)
					{
						return true;
					}
					result = 0;
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}
			result2 = 1;
		}
		else
		{
			result2 = 1;
		}
		return (byte)result2 != 0;
	}

	private static bool smethod_3(object object_0, string string_4, string string_5, CommDevice.EnumCommLatency enumCommLatency_0)
	{
		int result;
		if (string.IsNullOrEmpty(string_5))
		{
			result = 1;
		}
		else
		{
			DateTime lastUpdate = ((ActiveUnit)object_0).CommStuff.GetContactGradeInfo(((ScenarioObject)(object)string_4).ObjectID).LastUpdate;
			CommDevice.GetLatencyInSeconds(EnumCommExtensions.GetQualityID(enumCommLatency_0));
			if ((((ActiveUnit)object_0).ParentScen.Time - lastUpdate).TotalSeconds > (double)enumCommLatency_0)
			{
				return false;
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	public float ShockDamage_KE()
	{
		float result;
		try
		{
			switch (Type)
			{
			case _WeaponType.GuidedProjectile:
			{
				float num = (float)((double)CurrentSpeed * 0.514444);
				result = (float)(0.5 * (double)EmptyWeight * Math.Pow(num, 2.0) / 100.0 / 15000.0);
				break;
			}
			case _WeaponType.Rocket:
			{
				float num = 300f;
				result = (float)(0.5 * (double)EmptyWeight * Math.Pow(300.0, 2.0) / 100.0 / 15000.0);
				break;
			}
			case _WeaponType.IronBomb:
			{
				float num = 200f;
				result = (float)(0.5 * (double)EmptyWeight * Math.Pow(200.0, 2.0) / 100.0 / 15000.0);
				break;
			}
			case _WeaponType.Gun:
			{
				float num = (float)((double)CurrentSpeed * 0.514444);
				result = (float)(0.5 * (double)EmptyWeight * Math.Pow(num, 2.0) / 100.0 / 15000.0);
				break;
			}
			default:
				result = 0f;
				break;
			case _WeaponType.HGV:
			{
				float num2 = Math.Max(Math.Max(MaxWeight, BurnoutWeight()), Math.Max(EmptyWeight, MaxPayloadWeight));
				if (num2 == 0f && Warheads.Any())
				{
					num2 = Warheads[0].DP;
				}
				float num = (float)((double)CurrentSpeed * 0.514444);
				result = (float)(0.5 * (double)num2 * Math.Pow(num, 2.0) / 100.0 / 15000.0);
				break;
			}
			case _WeaponType.GuidedWeapon:
			case _WeaponType.Torpedo:
			{
				float num = (float)((double)CurrentSpeed * 0.514444);
				result = (float)(0.5 * (double)EmptyWeight * Math.Pow(num, 2.0) / 100.0 / 15000.0);
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100979", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
