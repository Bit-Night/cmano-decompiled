using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Aircraft : Platform, ICargoHost, ICargoClient, IFlier, IAGUInteractable
{
	public enum CockpitVisibility
	{
		None,
		Excellent,
		Average,
		Poor
	}

	public enum NATO_UAS_ClassificationEnum
	{
		Undefined,
		Class1_Micro,
		Class1_Mini,
		Class1_Small,
		Class2,
		Class3
	}

	public enum _BombsightTech : byte
	{
		Basic,
		Ballistic,
		Computing,
		Advanced
	}

	public enum _AircraftCategory : short
	{
		None = 1001,
		FixedWing = 2001,
		CarrierCapable = 2002,
		Helicopter = 2003,
		Tiltrotor = 2004,
		AirShip = 2006,
		SeaPlane = 2007,
		Amphibian = 2008
	}

	public enum _AircraftFuselageStructure
	{
		None = 0,
		LowSubsonicFighter = 9101,
		HighSubsonicFighter = 9102,
		LowSupersonicFighter = 9103,
		HighSupersonicFighter = 9104,
		LowSubsonicAttackAircraft = 9111,
		HighSubsonicAttackAircraft = 9112,
		LowSupersonicAttackAircraft = 9113,
		HighSupersonicAttackAircraft = 9114,
		LowSubsonicBomber = 9121,
		HighSubsonicBomber = 9122,
		LowSupersonicBomber = 9123,
		HighSupersonicBomber = 9124,
		HighAltitudeSlowSpeedRecon = 9185,
		HighAltitudeHighSpeedRecon = 9186,
		LowSubsonicCivilianStandards = 9191,
		HighSubsonicCivilianStandards = 9192,
		Airship = 9199
	}

	public enum _AircraftType
	{
		None = 1001,
		Fighter = 2001,
		Multirole = 2002,
		ASAT = 2101,
		AirborneLaserPlatform = 2102,
		Attack = 3001,
		WildWeasel = 3002,
		Bomber = 3101,
		CAS = 3401,
		OECM = 4001,
		AEW = 4002,
		AirborneCP = 4003,
		SAR = 4101,
		MCM = 4201,
		ASW = 6001,
		MPA = 6002,
		ForwardObserver = 7001,
		AreaSurveillance = 7002,
		Recon = 7003,
		ELINT = 7004,
		SIGINT = 7005,
		Transport = 7101,
		Cargo = 7201,
		Commercial = 7301,
		Civilian = 7302,
		Utility = 7401,
		Utility_Naval = 7402,
		Tanker = 8001,
		Trainer = 8101,
		TargetTowing = 8102,
		TargetDrone = 8103,
		UAV = 8201,
		UCAV = 8202,
		AirShip = 8901,
		AeroStat = 8902,
		Blimp = 8903
	}

	public static float EMERGENCY_LANDING_DISTANCE_NM;

	public static float UAVSizeClass1FixedFuelConsumption;

	public static string UAVSizeClass1FuelUnitOfMeasurementString;

	public int CockpitGen;

	public float Agility_Nominal;

	public _AircraftType Type;

	public _AircraftCategory Category;

	public _AircraftFuselageStructure FuselageStructure;

	public int TotalEndurance;

	public float AirborneTime;

	public float Span;

	public float Height;

	private Loadout loadout_0;

	internal float FuelOffLoadRate;

	internal float FuelOnLoadRate;

	public float G_StrainAccumulated;

	public float G_Tolerance;

	public bool ShouldDropSonobuoysOnThisPulse;

	public GlobalVariables.ArmorRating Armor_Cockpit;

	public GlobalVariables.ArmorRating Armor_Fuselage;

	public GlobalVariables.ArmorRating Armor_Powerplant;

	public bool ProbeRefuelling;

	public bool BoomRefuelling;

	public bool CenterlineDrogue;

	public bool WingDrogue;

	public bool CenterlineBoom;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	public bool bool_6;

	public bool FlyByWire;

	public bool HasBlipEnhancer;

	public bool HasHelmetMountedSight;

	public GlobalVariables.AircraftSizeClass Size;

	public GlobalVariables.RunwayLengthClass RunwayLengthNeeded;

	public _BombsightTech BombSightTech;

	public bool SuperManouverable;

	public bool NightNavigationCapable;

	public bool NightNavigationAttackCapable;

	public bool RCSS_ActiveCancellation;

	public bool RCSS_SShapedIntakes;

	public bool RCSS_ExposedFanBlockers;

	public bool IRSS_ShieldedExhaustAntiStrela;

	public bool IRSS_MaskedExhaust;

	public bool IRSS_MaskedExhaust_Slit;

	public bool IRSS_PeakTempReduction;

	public bool RCCS_StealthPylons;

	public float FuelState_DistanceToBase;

	public ActiveUnit FuelState_Destination;

	public float FuelState_RemainingFuelToBingo;

	public float FuelState_RemainingFuelToJoker;

	public CockpitVisibility VisibilityForward;

	public CockpitVisibility VisibilitySideways;

	public CockpitVisibility VisibilityAft;

	private Aircraft_Navigator aircraft_Navigator_0;

	private Aircraft_AI aircraft_AI_0;

	private Aircraft_Kinematics aircraft_Kinematics_0;

	private Aircraft_Sensory aircraft_Sensory_0;

	private Aircraft_Weaponry aircraft_Weaponry_0;

	private Aircraft_CommStuff aircraft_CommStuff_0;

	private Aircraft_Damage aircraft_Damage_0;

	private Aircraft_AirOps aircraft_AirOps_0;

	internal bool HasFBW;

	public int Cargo_Crew;

	public float Cargo_Area;

	public CargoType Cargo_Type;

	public float Cargo_Mass;

	public bool Cargo_ParadropCapable;

	private float? nullable_16;

	internal Loadout Loadout
	{
		get
		{
			return loadout_0;
		}
		set
		{
			loadout_0 = value;
			Sensors_Cached = null;
			MineCountermeasures = null;
		}
	}

	public override int MastHeight_Radar
	{
		get
		{
			int result;
			if (SpecificSensor == null)
			{
				result = 0;
			}
			else
			{
				if (SpecificSensor.MastHeight != 0)
				{
					return SpecificSensor.MastHeight;
				}
				result = 0;
			}
			return result;
		}
	}

	public override int MastHeight_Visual
	{
		get
		{
			int result;
			if (SpecificSensor != null)
			{
				if (SpecificSensor.MastHeight != 0)
				{
					return SpecificSensor.MastHeight;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return result;
		}
	}

	public override float MAX_Exhaustion
	{
		get
		{
			float num = 0f;
			float num2 = 0f;
			if (TotalEndurance > 0)
			{
				num2 = TotalEndurance;
				num2 *= 60f;
				if (num2 > 0f)
				{
					return num2;
				}
			}
			else
			{
				if (num == 0f)
				{
					switch (Type)
					{
					case _AircraftType.Fighter:
					case _AircraftType.Multirole:
					case _AircraftType.Attack:
						if ((Crew == 1) | (Crew == 2))
						{
							num = 57600f;
						}
						break;
					case _AircraftType.Bomber:
					case _AircraftType.AEW:
					case _AircraftType.AirborneCP:
						num = 172800f;
						break;
					case _AircraftType.MPA:
					case _AircraftType.Tanker:
						num = 86400f;
						break;
					case _AircraftType.Transport:
						if ((Crew > 15) & (Size == GlobalVariables.AircraftSizeClass.VLarge))
						{
							num = 345600f;
						}
						break;
					}
				}
				if (num == 0f)
				{
					switch (Type)
					{
					case _AircraftType.TargetDrone:
						return float.MaxValue;
					case _AircraftType.None:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return float.MaxValue;
					case _AircraftType.AirShip:
					case _AircraftType.AeroStat:
					case _AircraftType.Blimp:
						return float.MaxValue;
					case _AircraftType.UCAV:
						return float.MaxValue;
					case _AircraftType.UAV:
						return float.MaxValue;
					}
					switch (Size)
					{
					case GlobalVariables.AircraftSizeClass.Medium:
						num = 28800f;
						break;
					case GlobalVariables.AircraftSizeClass.None:
						num = float.MaxValue;
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						break;
					case GlobalVariables.AircraftSizeClass.UAS_Class1_Micro:
						num = float.MaxValue;
						break;
					case GlobalVariables.AircraftSizeClass.UAS_Class1_Mini:
						num = 21600f;
						break;
					case GlobalVariables.AircraftSizeClass.UAS_Class1_Small:
						num = 21600f;
						break;
					case GlobalVariables.AircraftSizeClass.UAS_Class2:
						num = 21600f;
						break;
					case GlobalVariables.AircraftSizeClass.Small:
						num = 21600f;
						break;
					case GlobalVariables.AircraftSizeClass.VLarge:
						num = 172800f;
						break;
					case GlobalVariables.AircraftSizeClass.Large:
						num = 86400f;
						break;
					}
				}
			}
			GlobalVariables.ProficiencyLevel? proficiency = Proficiency;
			int? num3 = (int?)proficiency;
			if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() == 0)) != true)
			{
				num3 = (int?)proficiency;
				if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 1)) == true)
				{
					num *= 1.2f;
				}
				else
				{
					num3 = (int?)proficiency;
					if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 2)) != true)
					{
						num3 = (int?)proficiency;
						if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 3)) != true)
						{
							num3 = (int?)proficiency;
							if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 4)) == true)
							{
								num *= 1.8f;
							}
						}
						else
						{
							num *= 1.6f;
						}
					}
					else
					{
						num *= 1.4f;
					}
				}
			}
			else
			{
				num *= 1f;
			}
			return num;
		}
	}

	public override float Current_Exhaustion => AirborneTime;

	public override bool SupportsAltitude_Control => true;

	public override bool SupportsAttitude_Pitch
	{
		get
		{
			if (_SupportsAttitudePitch == -1)
			{
				if (!IsLighterThanAir && !IsAirship && !IsHelicopter)
				{
					_SupportsAttitudePitch = 1;
				}
				else
				{
					_SupportsAttitudePitch = 0;
				}
			}
			return _SupportsAttitudePitch != 0;
		}
	}

	public override float FlatSurfaceArea_m2 => Length * Span;

	public string Type_Description => Type switch
	{
		_AircraftType.Civilian => "Civilian", 
		_AircraftType.Commercial => "Commercial", 
		_AircraftType.Cargo => "Cargo", 
		_AircraftType.Transport => "Transport", 
		_AircraftType.ForwardObserver => "Forward Observer", 
		_AircraftType.AreaSurveillance => "Area Surveillance", 
		_AircraftType.Recon => "Recon", 
		_AircraftType.ELINT => "Electronic Intelligence (ELINT)", 
		_AircraftType.SIGINT => "Signals Intelligence (SIGINT)", 
		_AircraftType.MPA => "Maritime Patrol Aircraft (MPA)", 
		_AircraftType.UAV => "Unmanned Aerial Vehicle (UAV)", 
		_AircraftType.Trainer => "Trainer", 
		_AircraftType.TargetTowing => "Target Towing", 
		_AircraftType.TargetDrone => "Target Drone", 
		_AircraftType.AirShip => "Airship", 
		_AircraftType.AeroStat => "Aerostat", 
		_AircraftType.Blimp => "Blimp/Balloon", 
		_AircraftType.UCAV => "Unmanned Combat Aerial Vehicle (UCAV)", 
		_AircraftType.Tanker => "Tanker (Air Refueling)", 
		_AircraftType.Utility_Naval => "Naval Utility", 
		_AircraftType.Utility => "Utility", 
		_AircraftType.ASW => "Anti-Submarine Warfare (ASW)", 
		_AircraftType.MCM => "Mine Sweeper (MCM)", 
		_AircraftType.SAR => "Search And Rescue (SAR)", 
		_AircraftType.OECM => "Electronic Warfare", 
		_AircraftType.AEW => "Airborne Early Warning (AEW)", 
		_AircraftType.AirborneCP => "Airborne Command Post (ACP)", 
		_AircraftType.CAS => "Battlefield Air Interdiction (BAI/CAS)", 
		_AircraftType.Bomber => "Bomber", 
		_AircraftType.WildWeasel => "Wild Weasel", 
		_AircraftType.Multirole => "Multirole (Fighter/Attack)", 
		_AircraftType.Fighter => "Fighter", 
		_AircraftType.None => "None", 
		_AircraftType.Attack => "Attack", 
		_AircraftType.AirborneLaserPlatform => "Airborne Laser Platform", 
		_AircraftType.ASAT => "Anti-Satellite Interceptor (ASAT)", 
		_ => Type.ToString(), 
	};

	public override bool HasSystemsRunning
	{
		get
		{
			if (!IsOperating())
			{
				int result;
				switch (AirOps.Condition)
				{
				case Aircraft_AirOps._AirOpsCondition.Readying:
					result = 0;
					break;
				default:
					return true;
				case Aircraft_AirOps._AirOpsCondition.Parked:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
			return true;
		}
	}

	public override int SafeDistanceAgainstUnknownMine_meters => 0;

	public override int SafeDistanceAgainstKnownMineType_meters => 0;

	public override _ActiveUnitStatus Status
	{
		get
		{
			return base.Status;
		}
		set
		{
			try
			{
				if (value != Status && value == _ActiveUnitStatus.RTB && (FuelState == _ActiveUnitFuelState.IsBingo || FuelState == _ActiveUnitFuelState.IsJoker))
				{
					DisconnectTankerClients("has reached Bingo or Joker fuel");
				}
				if (!IsInsideNoNavZones(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), 0f) || _Status != _ActiveUnitStatus.OnPlottedCourse)
				{
					base.Status = value;
					if (value == _ActiveUnitStatus.Refuelling)
					{
						AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Refuelling;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100352", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public bool HasBuddyStore
	{
		get
		{
			if (Loadout != null)
			{
				WeaponRec[] weapons = Loadout.Weapons;
				for (int i = 0; i < weapons.Length; i = checked(i + 1))
				{
					if (weapons[i].get_ReferenceWeapon(ParentScen).Type == Weapon._WeaponType.BuddyStore)
					{
						return true;
					}
				}
				return false;
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

	public override bool CanPhysicallyReplenishThisUnit
	{
		get
		{
			bool result = default(bool);
			try
			{
				if (!TargetUnit.IsAircraft)
				{
					result = false;
					return result;
				}
				Aircraft aircraft = (Aircraft)TargetUnit;
				if (CenterlineBoom && aircraft.BoomRefuelling)
				{
					result = true;
					return result;
				}
				if ((CenterlineDrogue || WingDrogue) && aircraft.ProbeRefuelling)
				{
					result = true;
					return result;
				}
				int num;
				if (!aircraft.ProbeRefuelling)
				{
					num = 0;
				}
				else if (Loadout == null)
				{
					num = 0;
				}
				else
				{
					WeaponRec[] weapons = Loadout.Weapons;
					for (int i = 0; i < weapons.Length; i = checked(i + 1))
					{
						if (weapons[i].get_ReferenceWeapon(ParentScen).Type == Weapon._WeaponType.BuddyStore)
						{
							result = true;
							return result;
						}
					}
					num = 0;
				}
				result = (byte)num != 0;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100353", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public override bool HasEnoughFuelToReplenishThisUnit
	{
		get
		{
			bool result = default(bool);
			try
			{
				PooledList<FuelRec> fuel_ReadOnly = Fuel_ReadOnly;
				int num2;
				if (fuel_ReadOnly != null)
				{
					int num = default(int);
					foreach (FuelRec item in fuel_ReadOnly)
					{
						if (item != null)
						{
							num = (int)Math.Round(((float)num + item?.CurrentQuantity).Value);
						}
					}
					fuel_ReadOnly.Dispose();
					num2 = 0;
				}
				else
				{
					num2 = 0;
				}
				ActiveUnit actualDestinationHost = AirOps.ActualDestinationHost;
				if (actualDestinationHost != null)
				{
					float theDistance = RangeToUnit_Horiz(actualDestinationHost);
					Aircraft_Navigator navigator = Navigator;
					bool theAltitude_TerrainFollowing = false;
					float bingoFuelAltitude = navigator.GetBingoFuelAltitude(ref theAltitude_TerrainFollowing);
					float value = Kinematics.GetMaximumSpeed(bingoFuelAltitude, Throttle.Cruise, ValidateAndFixAltitude: false);
					_ = (int)Math.Round(Kinematics.FuelNecessaryForThisDistance(theDistance, Throttle.Cruise, bingoFuelAltitude, value, CombatRadiusCalc: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false));
				}
				_ = (int)Math.Round(Kinematics.ReserveFuel);
				theAO.get_A2AR_Tanker_FuelReservation(TargetUnit, TargetUnit.get_ParentGroup(UsingMissionPlanner: false), TargetUnitIsAlreadyRefuelClient);
				result = true;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100354", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool IsLighterThanAir => Category == _AircraftCategory.AirShip;

	public bool IsAirship
	{
		get
		{
			if (Category == _AircraftCategory.AirShip)
			{
				return Type == _AircraftType.AirShip;
			}
			return false;
		}
	}

	public bool IsMooredBaloon
	{
		get
		{
			if (Category == _AircraftCategory.AirShip)
			{
				return Type == _AircraftType.AeroStat;
			}
			return false;
		}
	}

	public bool IsTanker
	{
		get
		{
			if (Type == _AircraftType.Tanker)
			{
				return true;
			}
			if (Loadout != null)
			{
				if (Loadout.Role == Loadout.LoadoutRole.AirRefueling)
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public override float DesiredAltitude
	{
		get
		{
			return base.DesiredAltitude;
		}
		set
		{
			if (!HasLostControlPulse_CACHED && value < 6.0959997f)
			{
				value = 6.0959997f;
			}
			base.DesiredAltitude = value;
		}
	}

	public override float DesiredAltitude_AGL
	{
		get
		{
			return base.DesiredAltitude_AGL;
		}
		set
		{
			if (value == 0f)
			{
				bool_5 = false;
				if (DesiredAltitude == 0f)
				{
					DesiredAltitude = DesiredAltitude_AGL + (float)Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ParentScen);
				}
			}
			base.DesiredAltitude_AGL = value;
			if (!bool_5)
			{
				return;
			}
			if (!Module_Unit.IsOverLand(this))
			{
				DesiredAltitude = value;
				return;
			}
			short elevation = Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ParentScen);
			DesiredAltitude = value + (float)elevation;
			if (TerrainFollowingType == TerrainFollowMode.IgnoreLandCover || !ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects))
			{
				return;
			}
			(LandCover.LandCoverType, int) landCoverAndHeightAtThisPoint = LandCover.GetLandCoverAndHeightAtThisPoint(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), ParentScen, ParentScen.GetNatureSide());
			switch (TerrainFollowingType)
			{
			case TerrainFollowMode.AboveLandCover:
				if (value < (float)landCoverAndHeightAtThisPoint.Item2)
				{
					DesiredAltitude = elevation + landCoverAndHeightAtThisPoint.Item2 + 1;
				}
				break;
			case TerrainFollowMode.WithinLandCover:
				if (landCoverAndHeightAtThisPoint.Item2 > 2 && value < (float)landCoverAndHeightAtThisPoint.Item2)
				{
					DesiredAltitude = elevation + landCoverAndHeightAtThisPoint.Item2 - 1;
				}
				break;
			}
		}
	}

	public override double Longitude
	{
		get
		{
			if ((_HintIsOperating == null) ? IsOperating() : (_HintIsOperating == GlobalVariables.ObjectTrue))
			{
				return _Longitude;
			}
			return AirOps.CurrentHostUnit?.get_Longitude((GlobalVariables.BooleanObject)null) ?? 0.0;
		}
		set
		{
			_Longitude = value;
		}
	}

	public override CommDevice[] Comms_ReadOnly
	{
		get
		{
			CommDevice[] result = default(CommDevice[]);
			try
			{
				if (Loadout != null)
				{
					CommDevice[] theArray = null;
					int num = Loadout.Weapons.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						Weapon weapon = Loadout.Weapons[i].get_ReferenceWeapon(ParentScen);
						if (weapon.Type != Weapon._WeaponType.SensorPod)
						{
							continue;
						}
						int num2 = weapon.Comms_ReadOnly.Length - 1;
						for (int j = 0; j <= num2; j++)
						{
							if (theArray == null)
							{
								theArray = method_16();
							}
							CommDevice commDevice = weapon.Comms_ReadOnly[j];
							commDevice.IsCommsInMount = true;
							ArrayExtensions.Add(ref theArray, commDevice);
						}
					}
					if (theArray == null)
					{
						result = _Comms;
						return result;
					}
					result = theArray;
					return result;
				}
				result = _Comms;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100355", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public override Throttle MaxPossibleThrottleSetting
	{
		get
		{
			if (!method_17())
			{
				return Throttle.Full;
			}
			return Throttle.Flank;
		}
	}

	public override GlobalVariables.TargetVisualSizeClass VisualSizeClass
	{
		get
		{
			float length = Length;
			if (length > 40f)
			{
				return GlobalVariables.TargetVisualSizeClass.VLarge;
			}
			if (length > 30f)
			{
				return GlobalVariables.TargetVisualSizeClass.Large;
			}
			if (length > 25f)
			{
				return GlobalVariables.TargetVisualSizeClass.Medium;
			}
			if (length > 10f)
			{
				return GlobalVariables.TargetVisualSizeClass.Small;
			}
			if (length > 5f)
			{
				return GlobalVariables.TargetVisualSizeClass.VSmall;
			}
			return GlobalVariables.TargetVisualSizeClass.Stealthy;
		}
	}

	public override string AnnexAndDBID => "Aircraft_" + Conversions.ToString(DBID);

	public bool CanHover
	{
		get
		{
			_AircraftCategory category = Category;
			if ((uint)(category - 2003) <= 1u)
			{
				return true;
			}
			if (!bool_7)
			{
				return false;
			}
			return RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.VTOL;
		}
	}

	public override float DesiredRoll
	{
		get
		{
			return base.DesiredRoll;
		}
		set
		{
			base.DesiredRoll = value;
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

	public override float Attitude_Pitch
	{
		get
		{
			return base.Attitude_Pitch;
		}
		set
		{
			base.Attitude_Pitch = value;
		}
	}

	public override float Attitude_Roll
	{
		get
		{
			return base.Attitude_Roll;
		}
		set
		{
			base.Attitude_Roll = value;
		}
	}

	public override float CurrentSpeed
	{
		get
		{
			return base.CurrentSpeed;
		}
		set
		{
			base.CurrentSpeed = value;
		}
	}

	public override float CurrentAltitude
	{
		get
		{
			if ((HintUnitOperating != null) ? (HintUnitOperating == GlobalVariables.ObjectTrue) : IsOperating())
			{
				return ((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
			return AirOps.CurrentHostUnit?.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) ?? ((float)Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ParentScen));
		}
		set
		{
			try
			{
				if (DoSanityCheck)
				{
					int num = ((Module_Unit.Unit)this).get_LandElevation(AGL: true, RequestIsFromGUI: false, Force: false, ParentScen);
					if (value < (float)(num + 1))
					{
						if (!HasLostControlPulse_CACHED)
						{
							value = num + 1;
							if (Attitude_Pitch < 0f)
							{
								Attitude_Pitch = 0f;
							}
						}
						else
						{
							Destroy(ScenEditAction: false, IsAimpointFacility: false, DestroyUnitNow: true, "Crashed on the ground (blinded crew)", "Crashed on the ground (blinded crew)");
						}
					}
				}
				((ActiveUnit)this).set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, value);
				if (Loadout != null)
				{
					WeaponRec[] weapons = Loadout.Weapons;
					for (int i = 0; i < weapons.Length; i = checked(i + 1))
					{
						weapons[i].get_ReferenceWeapon(ParentScen).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, value);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101196", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public override long FuelEndurance
	{
		get
		{
			long result;
			try
			{
				if (Type == _AircraftType.AeroStat)
				{
					result = long.MaxValue;
				}
				else
				{
					PooledList<FuelRec> fuel_ReadOnly = Fuel_ReadOnly;
					float num = default(float);
					foreach (FuelRec item in fuel_ReadOnly)
					{
						if (item != null)
						{
							num += item.CurrentQuantity;
						}
					}
					fuel_ReadOnly.Dispose();
					if (theThrottle == Throttle.FullStop)
					{
						result = 2147483647L;
					}
					else
					{
						float num2 = FuelConsumption(theThrottle, theAltBand, theSpeed, theAltitude, BingoFuelCheck: false, ReserveFuelQtyCalc: false, CombatRadiusCheck: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
						result = ((num2 != 0f) ? ((long)Math.Round(num / num2)) : long.MaxValue);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100356", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num3;
				if (!Debugger.IsAttached)
				{
					num3 = int.MaxValue;
				}
				else
				{
					Debugger.Break();
					num3 = int.MaxValue;
				}
				result = num3;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool IsOnOutboundLeg
	{
		get
		{
			int result;
			switch (Status)
			{
			default:
				result = 0;
				goto IL_0041;
			case _ActiveUnitStatus.EngagedOffensive:
			case _ActiveUnitStatus.EngagedDefensive:
			case _ActiveUnitStatus.RTB:
			case (_ActiveUnitStatus)9:
			case _ActiveUnitStatus.RTB_Manual:
				result = 0;
				goto IL_0041;
			case _ActiveUnitStatus.Unassigned:
			case _ActiveUnitStatus.OnPlottedCourse:
			case _ActiveUnitStatus.OnAttackRun:
			case _ActiveUnitStatus.OnPatrol:
			case _ActiveUnitStatus.Tasked:
			case _ActiveUnitStatus.FormingUp:
			case _ActiveUnitStatus.OnSupportMission:
				{
					return true;
				}
				IL_0041:
				return (byte)result != 0;
			}
		}
	}

	public bool IsOnReturnLeg
	{
		get
		{
			_ActiveUnitStatus status = Status;
			int result;
			int result2;
			if (status <= _ActiveUnitStatus.OnFerryMission)
			{
				if (status != _ActiveUnitStatus.RTB && status != _ActiveUnitStatus.RTB_Manual && status != _ActiveUnitStatus.OnFerryMission)
				{
					result = 0;
					goto IL_003f;
				}
			}
			else if (status <= _ActiveUnitStatus.RTB_CalledOff)
			{
				if (status != _ActiveUnitStatus.RTB_MissionOver && status - 19 > _ActiveUnitStatus.OnPlottedCourse)
				{
					result = 0;
					goto IL_003f;
				}
			}
			else if (status != _ActiveUnitStatus.RTB_CommsLost)
			{
				if (status == _ActiveUnitStatus.RTB_Exhaustion)
				{
					result2 = 1;
					goto IL_0043;
				}
				result = 0;
				goto IL_003f;
			}
			result2 = 1;
			goto IL_0043;
			IL_0043:
			return (byte)result2 != 0;
			IL_003f:
			return (byte)result != 0;
		}
	}

	public override _ActiveUnitFuelState IsBingoTowardsThisDestination
	{
		get
		{
			float num = float.MaxValue;
			List<Waypoint> WaypointList = new List<Waypoint>();
			PooledList<FuelRec> pooledList = null;
			_ActiveUnitFuelState result = default(_ActiveUnitFuelState);
			try
			{
				if (theDestination != null)
				{
					pooledList = Fuel_ReadOnly;
					if (pooledList.Count != 0)
					{
						if (IntermediatePoint == null)
						{
							float num2 = RangeToRefuelingDestinationUnit(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), theDestination);
							if (!float.IsNaN(num2))
							{
								FuelState_DistanceToBase = num2;
								FuelState_Destination = theDestination;
								goto IL_00a6;
							}
							result = _ActiveUnitFuelState.None;
						}
						else
						{
							float num3 = RangeToRefuelingDestinationUnit(IntermediatePoint.Latitude, IntermediatePoint.Longitude, theDestination);
							if (!float.IsNaN(num3))
							{
								float num4 = Module_Unit.RangeToPoint_Horiz(this, IntermediatePoint);
								FuelState_DistanceToBase = num4 + num3;
								FuelState_Destination = theDestination;
								goto IL_00a6;
							}
							result = _ActiveUnitFuelState.None;
						}
					}
					else
					{
						result = _ActiveUnitFuelState.IsBingo;
					}
				}
				else
				{
					FuelState_DistanceToBase = 0f;
					FuelState_Destination = null;
					result = _ActiveUnitFuelState.None;
				}
				goto end_IL_0010;
				IL_0136:
				bool? obj;
				bool? flag = (bool?)obj;
				if (flag ?? true)
				{
					int? num5 = (int?)((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false)?.GroupLead.Navigator.PlottedCourse.LastOrDefault()?.Type;
					if (((!num5.HasValue) ? ((bool?)null) : new bool?(num5 == 18)) == true && flag.HasValue)
					{
						goto IL_01f6;
					}
				}
				goto IL_0b67;
				IL_0956:
				float leg_FuelRequired;
				int num6 = default(int);
				float num7;
				if (WaypointList.Count != 0)
				{
					leg_FuelRequired = WaypointList[num6].Leg_FuelRequired;
					num7 = WaypointList[num6].Leg_Distance_Straight + WaypointList[num6].Leg_Distance_Turn;
					num = Module_Unit.RangeToPoint_Horiz(this, WaypointList[num6]);
					goto IL_099e;
				}
				result = _ActiveUnitFuelState.None;
				goto end_IL_0010;
				IL_0bdf:
				double num8 = Kinematics.CurrentRangeAtBingoThrottleAltitudeDepth(theFuelStateDoctrine);
				byte? b;
				if (this.get_FuelEndurance(Throttle.Cruise, (AltBand)null, (float?)null, (float?)null) <= 900L)
				{
					result = _ActiveUnitFuelState.IsBingo;
				}
				else
				{
					int num9 = (int)Math.Round(Math.Min(2000.0, (double)pooledList[0].MaxQuantity * 0.05));
					if (pooledList[0].CurrentQuantity < (float)num9)
					{
						result = _ActiveUnitFuelState.IsBingo;
					}
					else
					{
						if (theDestination.IsAircraft)
						{
							if (((Aircraft)theDestination).IsTanker)
							{
								num8 *= 0.9;
							}
						}
						else if (ThrottleSetting == Throttle.Flank)
						{
							num8 *= 0.9;
						}
						else if (Loadout != null && Loadout.Role == Loadout.LoadoutRole.AirRefueling)
						{
							num8 *= 0.9;
						}
						if (num8 >= (double)FuelState_DistanceToBase)
						{
							result = ((FuelState == _ActiveUnitFuelState.IsBingo && !(num8 * 0.9 >= (double)FuelState_DistanceToBase)) ? _ActiveUnitFuelState.IsBingo : _ActiveUnitFuelState.None);
						}
						else
						{
							b = (byte?)theFuelStateDoctrine;
							result = ((((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true) ? _ActiveUnitFuelState.IsBingo : ((FuelState_RemainingFuelToBingo <= 0f) ? _ActiveUnitFuelState.IsBingo : _ActiveUnitFuelState.IsJoker));
						}
					}
				}
				goto end_IL_0010;
				IL_00a6:
				if (!theDestination.IsAircraft)
				{
					if (Navigator.HasFlightPlan)
					{
						Waypoint? waypoint = Navigator.PlottedCourse.LastOrDefault();
						if (waypoint != null && waypoint.Type == Waypoint.WaypointType.Land)
						{
							goto IL_01f6;
						}
					}
					int value;
					if (IsGroupWingman())
					{
						if (((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false)?.GroupLead != null)
						{
							obj = ((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false)?.GroupLead.Navigator.HasFlightPlan;
							goto IL_0136;
						}
						value = 0;
					}
					else
					{
						value = 0;
					}
					obj = (byte)value != 0;
					goto IL_0136;
				}
				goto IL_0b67;
				IL_0acd:
				float num11;
				float num12;
				float num10 = default(float);
				if (num10 < num11)
				{
					FuelState_RemainingFuelToBingo = 0f;
					FuelState_RemainingFuelToJoker = 0f;
					result = _ActiveUnitFuelState.IsBingo;
				}
				else if (num12 < num11)
				{
					FuelState_RemainingFuelToBingo = num10 - num11;
					FuelState_RemainingFuelToJoker = 0f;
					result = _ActiveUnitFuelState.IsJoker;
				}
				else
				{
					FuelState_RemainingFuelToBingo = num10 - num11;
					FuelState_RemainingFuelToJoker = num12 - num11;
					result = ((FuelState == _ActiveUnitFuelState.IsBingo && !((double)num10 * 0.9 >= (double)num11)) ? _ActiveUnitFuelState.IsBingo : _ActiveUnitFuelState.None);
				}
				goto end_IL_0010;
				IL_0b67:
				if (IntermediatePoint != null)
				{
					float num13 = RangeToRefuelingDestinationUnit(IntermediatePoint.Latitude, IntermediatePoint.Longitude, theDestination);
					if (!float.IsNaN(num13))
					{
						float num14 = Module_Unit.RangeToPoint_Horiz(this, IntermediatePoint);
						FuelState_DistanceToBase = num14 + num13;
						FuelState_Destination = theDestination;
						goto IL_0bdf;
					}
					result = _ActiveUnitFuelState.None;
				}
				else
				{
					float num15 = RangeToRefuelingDestinationUnit(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), theDestination);
					if (!float.IsNaN(num15))
					{
						FuelState_DistanceToBase = num15;
						FuelState_Destination = theDestination;
						goto IL_0bdf;
					}
					result = _ActiveUnitFuelState.None;
				}
				goto end_IL_0010;
				IL_01f6:
				Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = Doctrine.get_UseReplenishment(ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
				Waypoint.WaypointType? previousWaypointType;
				Aircraft aircraft;
				if (Navigator.HasFlightPlan && Navigator.PlottedCourse.Count() > 0)
				{
					if (!IsGroupWingman())
					{
						Waypoint[] plottedCourse = Navigator.PlottedCourse;
						foreach (Waypoint waypoint2 in plottedCourse)
						{
							if (waypoint2.Type == Waypoint.WaypointType.PathfindingPoint)
							{
								continue;
							}
							WaypointList.Add(waypoint2);
							bool? obj2;
							if (useUnderwayRefuelAndReplenishment.HasValue)
							{
								b = (byte?)useUnderwayRefuelAndReplenishment;
								obj2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
							}
							else
							{
								obj2 = false;
							}
							flag = obj2;
							if (flag ?? true)
							{
								b = (byte?)waypoint2.GetDoctrine(ParentScen).get_UseReplenishment(ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
								bool? flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
								if (((!flag2) ?? flag2) == true && flag.HasValue)
								{
									break;
								}
							}
						}
						previousWaypointType = Navigator.PreviousWaypointType;
						aircraft = this;
					}
					else
					{
						Waypoint[] plottedCourse2 = Navigator.PlottedCourse;
						foreach (Waypoint waypoint3 in plottedCourse2)
						{
							if (waypoint3.Type != Waypoint.WaypointType.PathfindingPoint)
							{
								WaypointList.Add(waypoint3);
							}
						}
						Waypoint waypoint4 = WaypointList.LastOrDefault();
						bool flag3 = false;
						Waypoint[] flightPlan = ((ActiveUnit_Navigator)Navigator).get_Flight(HierarchySearch: true).FlightPlan;
						foreach (Waypoint waypoint5 in flightPlan)
						{
							if (flag3)
							{
								WaypointList.Add(waypoint5);
							}
							else if (waypoint5.FlightFormation != Waypoint.Formation.Split && waypoint5.HasWingmanWaypoints())
							{
								if (waypoint5.Waypoint_LeadElementWingman != null && waypoint5.Waypoint_LeadElementWingman == waypoint4)
								{
									flag3 = true;
									continue;
								}
								if (waypoint5.Waypoint_SecondElement != null && waypoint5.Waypoint_SecondElement == waypoint4)
								{
									flag3 = true;
									continue;
								}
								if (waypoint5.Waypoint_SecondElementWingman != null && waypoint5.Waypoint_SecondElementWingman == waypoint4)
								{
									flag3 = true;
									continue;
								}
								if (waypoint5.Waypoint_ThirdElement != null && waypoint5.Waypoint_ThirdElement == waypoint4)
								{
									flag3 = true;
									continue;
								}
								if (waypoint5.Waypoint_ThirdElementWingman != null && waypoint5.Waypoint_ThirdElementWingman == waypoint4)
								{
									flag3 = true;
									continue;
								}
							}
							bool? obj3;
							if (!useUnderwayRefuelAndReplenishment.HasValue)
							{
								obj3 = false;
							}
							else
							{
								b = (byte?)useUnderwayRefuelAndReplenishment;
								obj3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
							}
							flag = obj3;
							if (flag ?? true)
							{
								b = (byte?)waypoint5.GetDoctrine(ParentScen).get_UseReplenishment(ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
								bool? flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
								if (((!flag2) ?? flag2) == true && flag.HasValue)
								{
									break;
								}
							}
						}
						previousWaypointType = Navigator.PreviousWaypointType;
						aircraft = this;
					}
				}
				else
				{
					Waypoint[] plottedCourse3 = ((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse;
					foreach (Waypoint waypoint6 in plottedCourse3)
					{
						if (waypoint6.Type == Waypoint.WaypointType.PathfindingPoint)
						{
							continue;
						}
						WaypointList.Add(waypoint6);
						bool? obj4;
						if (useUnderwayRefuelAndReplenishment.HasValue)
						{
							b = (byte?)useUnderwayRefuelAndReplenishment;
							obj4 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
						}
						else
						{
							obj4 = false;
						}
						flag = obj4;
						if (flag ?? true)
						{
							b = (byte?)waypoint6.GetDoctrine(ParentScen).get_UseReplenishment(ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
							bool? flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
							if (((!flag2) ?? flag2) == true && flag.HasValue)
							{
								break;
							}
						}
					}
					previousWaypointType = ((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PreviousWaypointType;
					aircraft = (Aircraft)((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false).GroupLead;
				}
				if (WaypointList.Count != 0)
				{
					if (WaypointList[0].Type == Waypoint.WaypointType.StationEnd && WaypointList.Count > 1)
					{
						num = Module_Unit.RangeToPoint_Horiz(this, WaypointList[1]);
						leg_FuelRequired = WaypointList[1].Leg_FuelRequired;
						num7 = WaypointList[1].Leg_Distance_Straight + WaypointList[1].Leg_Distance_Turn;
						num6 = 1;
						goto IL_099e;
					}
					bool? obj5;
					if (!previousWaypointType.HasValue)
					{
						obj5 = false;
					}
					else
					{
						int? num5 = (int?)previousWaypointType;
						obj5 = ((!num5.HasValue) ? ((bool?)null) : new bool?(num5 == 24));
					}
					bool? flag4 = obj5;
					bool? flag5 = obj5;
					bool? flag2;
					flag4 = (flag2 = ((flag5.HasValue && flag4 != true) ? new bool?(false) : (WaypointList[0].IsStationStartWaypoint() & flag4)));
					flag = ((flag4.HasValue && flag2 != true) ? new bool?(false) : ((WaypointList.Count > 1) & flag2));
					if ((flag ?? true) && WaypointList[1].Type == Waypoint.WaypointType.StationEnd && flag.HasValue)
					{
						num = Module_Unit.RangeToPoint_Horiz(this, WaypointList[2]);
						if (WaypointList.Count != 0)
						{
							leg_FuelRequired = WaypointList[2].Leg_FuelRequired;
							num7 = WaypointList[2].Leg_Distance_Straight + WaypointList[2].Leg_Distance_Turn;
							num6 = 2;
							goto IL_099e;
						}
						result = _ActiveUnitFuelState.None;
					}
					else
					{
						if (base.IsRTB_Or_CalledOff || aircraft == null)
						{
							goto IL_0956;
						}
						aircraft.Navigator.EgressToRejoinPoint_RemoveWaypoints(ref WaypointList, ForceObjectiveWaypointRemoval: false, IsBingoCheck: true);
						aircraft.AirOps.SwitchToNearestWaypoint(ref WaypointList, ForceObjectiveWaypointRemoval: false, IsBingoCheck: true);
						if (aircraft.Status != _ActiveUnitStatus.RTB)
						{
							num6 = 0;
							goto IL_0956;
						}
					}
				}
				else
				{
					result = _ActiveUnitFuelState.None;
				}
				goto end_IL_0010;
				IL_099e:
				num11 = 0f;
				if (num7 > 0f)
				{
					num11 = leg_FuelRequired / num7 * num;
				}
				if (WaypointList.Count >= num6 + 1)
				{
					int num16 = num6 + 1;
					int num17 = WaypointList.Count - 1;
					for (int m = num16; m <= num17; m++)
					{
						Waypoint waypoint7 = WaypointList[m];
						num11 += waypoint7.Leg_FuelRequired;
					}
				}
				foreach (FuelRec item in pooledList)
				{
					num10 += item.CurrentQuantity;
				}
				num10 -= Kinematics.ReserveFuel;
				num12 = num10 - Kinematics.JokerFuel;
				if (!(num10 < 0f))
				{
					goto IL_0acd;
				}
				b = (byte?)theFuelStateDoctrine;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
				{
					goto IL_0acd;
				}
				FuelState_RemainingFuelToBingo = 0f;
				FuelState_RemainingFuelToJoker = 0f;
				result = _ActiveUnitFuelState.IsBingo;
				end_IL_0010:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100359", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num18;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num18 = 0;
				}
				else
				{
					num18 = 0;
				}
				result = (_ActiveUnitFuelState)num18;
				ProjectData.ClearProjectError();
			}
			finally
			{
				pooledList?.Dispose();
			}
			return result;
		}
	}

	public override _ActiveUnitFuelState IsBingoOrJoker => IsBingoOrJoker_IsUsingTankerAsReference().Item1;

	public override double Latitude
	{
		get
		{
			if (!((_HintIsOperating != null) ? (_HintIsOperating == GlobalVariables.ObjectTrue) : IsOperating()))
			{
				return AirOps.CurrentHostUnit?.get_Latitude((GlobalVariables.BooleanObject)null) ?? 0.0;
			}
			return _Latitude;
		}
		set
		{
			_Latitude = value;
		}
	}

	public bool CanTakeOffVertically
	{
		get
		{
			_AircraftCategory category = Category;
			if ((uint)(category - 2003) > 1u)
			{
				return RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.VTOL;
			}
			return true;
		}
	}

	public bool CanLandVertically
	{
		get
		{
			_AircraftCategory category = Category;
			if ((uint)(category - 2003) <= 1u)
			{
				return true;
			}
			return RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.VTOL;
		}
	}

	public bool CanRefuelOnAir
	{
		get
		{
			if (!ProbeRefuelling)
			{
				return BoomRefuelling;
			}
			return true;
		}
	}

	public List<(string, int, float)> FuelByTank
	{
		get
		{
			List<(string, int, float)> result;
			try
			{
				List<(string, int, float)> list = new List<(string, int, float)>();
				if (Loadout != null)
				{
					WeaponRec[] weapons = Loadout.Weapons;
					foreach (WeaponRec weaponRec in weapons)
					{
						if (weaponRec.get_ReferenceWeapon(ParentScen).IsFuelTank || (weaponRec.get_ReferenceWeapon(ParentScen).IsSensorPod && weaponRec.get_ReferenceWeapon(ParentScen).FuelCapacityMax > 0))
						{
							int currentLoad = weaponRec.CurrentLoad;
							for (int j = 1; j <= currentLoad; j++)
							{
								list.Add((weaponRec.ObjectID, j, weaponRec.get_ReferenceWeapon(ParentScen).Fuel_ReadOnly[0].CurrentQuantity));
							}
						}
					}
				}
				result = list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100361", "FuelByTank");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<(string, int, float)>();
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public override PooledList<FuelRec> Fuel_ReadOnly
	{
		get
		{
			PooledList<FuelRec> pooledList = new PooledList<FuelRec>(Pools<FuelRec>.Local);
			PooledList<FuelRec> result;
			try
			{
				if (_Fuel != null && _Fuel.Count > 0)
				{
					pooledList.AddRange(_Fuel);
				}
				if (Loadout != null)
				{
					WeaponRec[] weapons = Loadout.Weapons;
					foreach (WeaponRec weaponRec in weapons)
					{
						Weapon._WeaponType weaponType = DBFunctions.GetWeaponType(weaponRec.int_3, ParentScen);
						if ((uint)(weaponType - 3001) > 1u && weaponType != Weapon._WeaponType.FerryTank)
						{
							continue;
						}
						Weapon weapon = weaponRec.get_ReferenceWeapon(ParentScen);
						if (weapon.FuelCapacityMax > 0)
						{
							int currentLoad = weaponRec.CurrentLoad;
							for (int j = 1; j <= currentLoad; j++)
							{
								pooledList.Add(weapon.Fuel_ReadOnly[0]);
							}
						}
					}
				}
				result = pooledList;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100361", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new PooledList<FuelRec>();
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public override int FuelCapacityMax
	{
		get
		{
			int result;
			try
			{
				PooledList<FuelRec> fuel_ReadOnly = Fuel_ReadOnly;
				int num = default(int);
				foreach (FuelRec item in fuel_ReadOnly)
				{
					num += item.MaxQuantity;
				}
				fuel_ReadOnly.Dispose();
				result = num;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100362", "");
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
				result = num2;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public override int FuelCapacityCurrent
	{
		get
		{
			int result;
			try
			{
				PooledList<FuelRec> fuel_ReadOnly = Fuel_ReadOnly;
				int num = default(int);
				foreach (FuelRec item in fuel_ReadOnly)
				{
					num = (int)Math.Round((float)num + item.CurrentQuantity);
				}
				fuel_ReadOnly.Dispose();
				result = num;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100363", "");
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
				result = num2;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public new Aircraft_Navigator Navigator => aircraft_Navigator_0;

	public new Aircraft_AI AI => aircraft_AI_0;

	public new Aircraft_Kinematics Kinematics => aircraft_Kinematics_0;

	public new Aircraft_Sensory Sensory
	{
		get
		{
			if (aircraft_Sensory_0 == null)
			{
				ActiveUnit theUnit = this;
				aircraft_Sensory_0 = new Aircraft_Sensory(ref theUnit);
			}
			return aircraft_Sensory_0;
		}
	}

	public new Aircraft_Weaponry Weaponry
	{
		get
		{
			if (aircraft_Weaponry_0 == null)
			{
				ActiveUnit theUnit = this;
				aircraft_Weaponry_0 = new Aircraft_Weaponry(ref theUnit);
			}
			return aircraft_Weaponry_0;
		}
	}

	public new Aircraft_CommStuff CommStuff
	{
		get
		{
			if (aircraft_CommStuff_0 == null)
			{
				ActiveUnit theUnit = this;
				aircraft_CommStuff_0 = new Aircraft_CommStuff(ref theUnit);
			}
			return aircraft_CommStuff_0;
		}
	}

	public new Aircraft_Damage Damage
	{
		get
		{
			if (aircraft_Damage_0 == null)
			{
				ActiveUnit theUnit = this;
				aircraft_Damage_0 = new Aircraft_Damage(ref theUnit);
			}
			return aircraft_Damage_0;
		}
	}

	public new Aircraft_AirOps AirOps
	{
		get
		{
			if (aircraft_AirOps_0 == null)
			{
				ActiveUnit theUnit = this;
				aircraft_AirOps_0 = new Aircraft_AirOps(ref theUnit);
			}
			return aircraft_AirOps_0;
		}
	}

	public string LoadoutName
	{
		get
		{
			if (Loadout != null)
			{
				return Loadout.Name;
			}
			return "Nothing";
		}
	}

	public int LoadoutDBID
	{
		get
		{
			if (Loadout == null)
			{
				return 0;
			}
			return Loadout.DBID;
		}
	}

	public override List<Sensor> MineCountermeasures
	{
		get
		{
			List<Sensor> result;
			try
			{
				if (_MineCountermeasures != null)
				{
					result = _MineCountermeasures;
				}
				else
				{
					List<Sensor> list = new List<Sensor>();
					if (base.MineCountermeasures != null)
					{
						list.AddRange(base.MineCountermeasures);
					}
					if (Mounts != null)
					{
						foreach (Mount mount in Mounts)
						{
							if (mount == null)
							{
								continue;
							}
							Sensor[] sensors_ReadOnly = mount.Sensors_ReadOnly;
							foreach (Sensor sensor in sensors_ReadOnly)
							{
								if (sensor != null && sensor.IsMineCountermeasure)
								{
									list.Add(sensor);
								}
							}
						}
					}
					if (Loadout != null)
					{
						PooledList<Sensor> pooledList = Loadout.Sensors(ParentScen);
						if (pooledList != null && pooledList.Count > 0)
						{
							foreach (Sensor item in pooledList)
							{
								if (item != null && item.IsMineCountermeasure)
								{
									list.Add(item);
								}
							}
							pooledList.Dispose();
						}
						if (Loadout.Weapons != null)
						{
							WeaponRec[] weapons = Loadout.Weapons;
							foreach (WeaponRec weaponRec in weapons)
							{
								if (weaponRec.CurrentLoad <= 0 || weaponRec.get_ReferenceWeapon(ParentScen).MineCountermeasures == null)
								{
									continue;
								}
								foreach (Sensor mineCountermeasure in weaponRec.get_ReferenceWeapon(ParentScen).MineCountermeasures)
								{
									if (mineCountermeasure != null && mineCountermeasure.IsMineCountermeasure)
									{
										list.Add(mineCountermeasure);
									}
								}
							}
						}
					}
					_MineCountermeasures = list;
					result = _MineCountermeasures;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100364", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<Sensor>();
				ProjectData.ClearProjectError();
			}
			return result;
		}
		set
		{
			_MineCountermeasures = value;
		}
	}

	public bool IsTiltrotor
	{
		get
		{
			_AircraftCategory category = Category;
			if (category == _AircraftCategory.Tiltrotor)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsHelicopter
	{
		get
		{
			_AircraftCategory category = Category;
			if ((uint)(category - 2003) <= 1u)
			{
				return true;
			}
			return false;
		}
	}

	public bool TerrainFollowingCapability
	{
		get
		{
			bool result;
			try
			{
				if (Loadout != null)
				{
					WeaponRec[] weapons = Loadout.Weapons;
					int num = 0;
					while (num < weapons.Length)
					{
						WeaponRec weaponRec = weapons[num];
						if (weaponRec.get_ReferenceWeapon(ParentScen).Type != Weapon._WeaponType.SensorPod || !weaponRec.get_ReferenceWeapon(ParentScen).Flags.Pod_TerrainFollowing)
						{
							num = checked(num + 1);
							continue;
						}
						result = true;
						goto end_IL_0001;
					}
				}
				result = bool_4;
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100365", "");
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
		set
		{
			bool_4 = value;
		}
	}

	public bool TerrainAvoidanceCapability
	{
		get
		{
			bool result;
			try
			{
				if (Loadout != null)
				{
					WeaponRec[] weapons = Loadout.Weapons;
					int num = 0;
					while (num < weapons.Length)
					{
						WeaponRec weaponRec = weapons[num];
						if (weaponRec.get_ReferenceWeapon(ParentScen).Type != Weapon._WeaponType.SensorPod || !weaponRec.get_ReferenceWeapon(ParentScen).Flags.Pod_TerrainAvoidance)
						{
							num = checked(num + 1);
							continue;
						}
						result = true;
						goto end_IL_0001;
					}
				}
				result = bool_3;
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100365", "");
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
		set
		{
			bool_3 = value;
		}
	}

	public override bool DesiredAltitude_UseTerrainFollowing
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
			if (!bool_5)
			{
				TerrainFollowingType = TerrainFollowMode.IgnoreLandCover;
			}
		}
	}

	public float? MinimumSafeHeight
	{
		get
		{
			float? result;
			try
			{
				if (!nullable_16.HasValue)
				{
					double num = this.get_Latitude(GlobalVariables.ObjectTrue);
					double num2 = this.get_Longitude(GlobalVariables.ObjectTrue);
					int num3 = ((Module_Unit.Unit)this).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentScen);
					if (num3 < 0)
					{
						num3 = 0;
					}
					bool flag = num3 > 0;
					Weather.WeatherProfile weatherProfile = Weather.get_WeatherAtThisTimeAndPlace(ParentScen, num, num2, (int)Math.Round(this.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue)));
					DateTime time = ParentScen.Time;
					bool flag2 = SunModule.GetTimeOfDay(ParentScen, time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, UseCurrentScenarioTime: true, num, num2, 0.0) == Weather.TTimeOfDayType.tod_Day;
					if (base.LandCoverMaskingCapability && TerrainFollowingType == TerrainFollowMode.WithinLandCover && this.get_DesiredAltitude_UseTerrainFollowing((ActiveUnit)this))
					{
						float num4 = method_18(flag, flag2, weatherProfile.SeaState);
						if (ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects))
						{
							(LandCover.LandCoverType, int) landCoverAndHeightAtThisPoint = LandCover.GetLandCoverAndHeightAtThisPoint(num, num2, ParentScen, ParentScen.GetNatureSide());
							if (landCoverAndHeightAtThisPoint.Item2 > 2 && num4 < (float)landCoverAndHeightAtThisPoint.Item2)
							{
								num4 = landCoverAndHeightAtThisPoint.Item2 - 1;
							}
						}
						if (bool_7)
						{
							return num4;
						}
						return (float)num3 + num4;
					}
					bool terrainFollowingCapability = TerrainFollowingCapability;
					bool terrainAvoidanceCapability = TerrainAvoidanceCapability;
					float num5 = default(float);
					if (flag)
					{
						if (flag2)
						{
							switch (Category)
							{
							default:
								if (!terrainAvoidanceCapability)
								{
									if (!terrainFollowingCapability)
									{
										num5 = 152.4f;
										switch (weatherProfile.SeaState)
										{
										default:
											throw new NotImplementedException();
										case 0:
										{
											if (!(weatherProfile.RainfallRate < 5f) || Size > GlobalVariables.AircraftSizeClass.Large)
											{
												break;
											}
											GlobalVariables.ProficiencyLevel? proficiency6 = Proficiency;
											int? num6 = (int?)proficiency6;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() == 0)) == true)
											{
												break;
											}
											num6 = (int?)proficiency6;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 1)) == true)
											{
												break;
											}
											num6 = (int?)proficiency6;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 2)) != true)
											{
												num6 = (int?)proficiency6;
												if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 3)) == true)
												{
													num5 = 91.44f;
													break;
												}
												num6 = (int?)proficiency6;
												if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 4)) == true)
												{
													num5 = 60.96f;
												}
											}
											else
											{
												num5 = 121.92f;
											}
											break;
										}
										case 1:
										{
											if (!(weatherProfile.RainfallRate < 5f) || Size > GlobalVariables.AircraftSizeClass.Large)
											{
												break;
											}
											GlobalVariables.ProficiencyLevel? proficiency5 = Proficiency;
											int? num6 = (int?)proficiency5;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() == 0)) == true)
											{
												break;
											}
											num6 = (int?)proficiency5;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 1)) == true)
											{
												break;
											}
											num6 = (int?)proficiency5;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 2)) != true)
											{
												num6 = (int?)proficiency5;
												if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 3)) == true)
												{
													num5 = 91.44f;
													break;
												}
												num6 = (int?)proficiency5;
												if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 4)) == true)
												{
													num5 = 60.96f;
												}
											}
											else
											{
												num5 = 121.92f;
											}
											break;
										}
										case 2:
										{
											if (!(weatherProfile.RainfallRate < 5f) || Size > GlobalVariables.AircraftSizeClass.Large)
											{
												break;
											}
											GlobalVariables.ProficiencyLevel? proficiency2 = Proficiency;
											int? num6 = (int?)proficiency2;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() == 0)) == true)
											{
												break;
											}
											num6 = (int?)proficiency2;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 1)) == true)
											{
												break;
											}
											num6 = (int?)proficiency2;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 2)) == true)
											{
												num5 = 121.92f;
												break;
											}
											num6 = (int?)proficiency2;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 3)) == true)
											{
												num5 = 91.44f;
												break;
											}
											num6 = (int?)proficiency2;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 4)) == true)
											{
												num5 = 60.96f;
											}
											break;
										}
										case 3:
										{
											if (!(weatherProfile.RainfallRate < 5f) || Size > GlobalVariables.AircraftSizeClass.Large)
											{
												break;
											}
											GlobalVariables.ProficiencyLevel? proficiency3 = Proficiency;
											int? num6 = (int?)proficiency3;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() == 0)) == true)
											{
												break;
											}
											num6 = (int?)proficiency3;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 1)) == true)
											{
												break;
											}
											num6 = (int?)proficiency3;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 2)) == true)
											{
												num5 = 121.92f;
												break;
											}
											num6 = (int?)proficiency3;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 3)) != true)
											{
												num6 = (int?)proficiency3;
												if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 4)) == true)
												{
													num5 = 60.96f;
												}
											}
											else
											{
												num5 = 91.44f;
											}
											break;
										}
										case 4:
										{
											if (!(weatherProfile.RainfallRate < 5f) || Size > GlobalVariables.AircraftSizeClass.Large)
											{
												break;
											}
											GlobalVariables.ProficiencyLevel? proficiency4 = Proficiency;
											int? num6 = (int?)proficiency4;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() == 0)) == true)
											{
												break;
											}
											num6 = (int?)proficiency4;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 1)) == true)
											{
												break;
											}
											num6 = (int?)proficiency4;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 2)) == true)
											{
												num5 = 121.92f;
												break;
											}
											num6 = (int?)proficiency4;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 3)) == true)
											{
												num5 = 91.44f;
												break;
											}
											num6 = (int?)proficiency4;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 4)) == true)
											{
												num5 = 60.96f;
											}
											break;
										}
										case 5:
										{
											if (!(weatherProfile.RainfallRate < 5f) || Size > GlobalVariables.AircraftSizeClass.Large)
											{
												break;
											}
											GlobalVariables.ProficiencyLevel? proficiency = Proficiency;
											int? num6 = (int?)proficiency;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() == 0)) == true)
											{
												break;
											}
											num6 = (int?)proficiency;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 1)) == true)
											{
												break;
											}
											num6 = (int?)proficiency;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 2)) != true)
											{
												num6 = (int?)proficiency;
												if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 3)) == true)
												{
													num5 = 91.44f;
													break;
												}
												num6 = (int?)proficiency;
												if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 4)) == true)
												{
													num5 = 60.96f;
												}
											}
											else
											{
												num5 = 121.92f;
											}
											break;
										}
										case 6:
										case 7:
										case 8:
										case 9:
										case 10:
											break;
										}
									}
									else
									{
										num5 = 60.96f;
									}
								}
								else
								{
									num5 = 91.44f;
								}
								break;
							case _AircraftCategory.Tiltrotor:
								num5 = ThrottleSetting switch
								{
									Throttle.FullStop => 15.24f, 
									Throttle.Loiter => 15.24f, 
									_ => terrainAvoidanceCapability ? 91.44f : ((!terrainFollowingCapability) ? 152.4f : 60.96f), 
								};
								break;
							case _AircraftCategory.Helicopter:
								switch (weatherProfile.SeaState)
								{
								case 0:
									num5 = ThrottleSetting switch
									{
										Throttle.Loiter => 15.24f, 
										Throttle.FullStop => 15.24f, 
										_ => 30.48f, 
									};
									break;
								case 1:
									num5 = ThrottleSetting switch
									{
										Throttle.FullStop => 15.24f, 
										Throttle.Loiter => 15.24f, 
										_ => 30.48f, 
									};
									break;
								case 2:
									num5 = ThrottleSetting switch
									{
										Throttle.Loiter => 15.24f, 
										Throttle.FullStop => 15.24f, 
										_ => 30.48f, 
									};
									break;
								case 3:
									num5 = ThrottleSetting switch
									{
										Throttle.FullStop => 15.24f, 
										Throttle.Loiter => 15.24f, 
										_ => 30.48f, 
									};
									break;
								case 4:
									num5 = ThrottleSetting switch
									{
										Throttle.Loiter => 15.24f, 
										Throttle.FullStop => 15.24f, 
										_ => 30.48f, 
									};
									break;
								case 5:
									num5 = ThrottleSetting switch
									{
										Throttle.Loiter => 15.24f, 
										Throttle.FullStop => 15.24f, 
										_ => 45.72f, 
									};
									break;
								case 6:
									num5 = ThrottleSetting switch
									{
										Throttle.FullStop => 15.24f, 
										Throttle.Loiter => 15.24f, 
										_ => 45.72f, 
									};
									break;
								case 7:
									num5 = ThrottleSetting switch
									{
										Throttle.Loiter => 15.24f, 
										Throttle.FullStop => 15.24f, 
										_ => 60.96f, 
									};
									break;
								case 8:
									num5 = ThrottleSetting switch
									{
										Throttle.Loiter => 15.24f, 
										Throttle.FullStop => 15.24f, 
										_ => 60.96f, 
									};
									break;
								case 9:
									num5 = ThrottleSetting switch
									{
										Throttle.FullStop => 15.24f, 
										Throttle.Loiter => 15.24f, 
										_ => 60.96f, 
									};
									break;
								case 10:
									num5 = ThrottleSetting switch
									{
										Throttle.Loiter => 15.24f, 
										Throttle.FullStop => 15.24f, 
										_ => 60.96f, 
									};
									break;
								}
								break;
							}
						}
						else
						{
							_AircraftCategory category = Category;
							num5 = (((uint)(category - 2003) <= 1u) ? (ThrottleSetting switch
							{
								Throttle.Loiter => 15.24f, 
								Throttle.FullStop => 15.24f, 
								_ => terrainAvoidanceCapability ? 91.44f : ((!terrainFollowingCapability) ? 152.4f : 60.96f), 
							}) : (terrainAvoidanceCapability ? 91.44f : (terrainFollowingCapability ? 60.96f : 304.8f)));
						}
					}
					else if (flag2)
					{
						_AircraftCategory category2 = Category;
						if ((uint)(category2 - 2003) <= 1u)
						{
							switch (weatherProfile.SeaState)
							{
							case 0:
								num5 = 15.24f;
								break;
							case 1:
								num5 = 15.24f;
								break;
							case 2:
								num5 = 15.24f;
								break;
							case 3:
								num5 = 15.24f;
								break;
							case 4:
								num5 = 15.24f;
								break;
							case 5:
								num5 = 15.24f;
								break;
							case 6:
								num5 = ThrottleSetting switch
								{
									Throttle.FullStop => 15.24f, 
									Throttle.Loiter => 15.24f, 
									_ => 30.48f, 
								};
								break;
							case 7:
								num5 = ThrottleSetting switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 30.48f, 
								};
								break;
							case 8:
								num5 = ThrottleSetting switch
								{
									Throttle.FullStop => 15.24f, 
									Throttle.Loiter => 15.24f, 
									_ => 60.96f, 
								};
								break;
							case 9:
								num5 = ThrottleSetting switch
								{
									Throttle.FullStop => 15.24f, 
									Throttle.Loiter => 15.24f, 
									_ => 60.96f, 
								};
								break;
							case 10:
								num5 = ThrottleSetting switch
								{
									Throttle.FullStop => 15.24f, 
									Throttle.Loiter => 15.24f, 
									_ => 60.96f, 
								};
								break;
							}
						}
						else if (!terrainAvoidanceCapability && !terrainFollowingCapability)
						{
							num5 = 91.44f;
							switch (weatherProfile.SeaState)
							{
							default:
								throw new NotImplementedException();
							case 0:
							{
								if (!(weatherProfile.RainfallRate < 5f) || Size > GlobalVariables.AircraftSizeClass.Large)
								{
									break;
								}
								GlobalVariables.ProficiencyLevel? proficiency11 = Proficiency;
								int? num6 = (int?)proficiency11;
								if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() == 0)) != true)
								{
									num6 = (int?)proficiency11;
									if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 1)) != true)
									{
										num6 = (int?)proficiency11;
										if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 2)) != true)
										{
											num6 = (int?)proficiency11;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 3)) != true)
											{
												num6 = (int?)proficiency11;
												if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 4)) == true)
												{
													num5 = 24.383999f;
												}
											}
											else
											{
												num5 = 24.383999f;
											}
										}
										else
										{
											num5 = 24.383999f;
										}
									}
									else
									{
										num5 = 30.48f;
									}
								}
								else
								{
									num5 = 45.72f;
								}
								break;
							}
							case 1:
							{
								if (!(weatherProfile.RainfallRate < 5f) || Size > GlobalVariables.AircraftSizeClass.Large)
								{
									break;
								}
								GlobalVariables.ProficiencyLevel? proficiency12 = Proficiency;
								int? num6 = (int?)proficiency12;
								if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() == 0)) != true)
								{
									num6 = (int?)proficiency12;
									if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 1)) != true)
									{
										num6 = (int?)proficiency12;
										if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 2)) != true)
										{
											num6 = (int?)proficiency12;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 3)) != true)
											{
												num6 = (int?)proficiency12;
												if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 4)) == true)
												{
													num5 = 24.383999f;
												}
											}
											else
											{
												num5 = 24.383999f;
											}
										}
										else
										{
											num5 = 24.383999f;
										}
									}
									else
									{
										num5 = 30.48f;
									}
								}
								else
								{
									num5 = 45.72f;
								}
								break;
							}
							case 2:
							{
								if (!(weatherProfile.RainfallRate < 5f) || Size > GlobalVariables.AircraftSizeClass.Large)
								{
									break;
								}
								GlobalVariables.ProficiencyLevel? proficiency8 = Proficiency;
								int? num6 = (int?)proficiency8;
								if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() == 0)) == true)
								{
									num5 = 45.72f;
									break;
								}
								num6 = (int?)proficiency8;
								if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 1)) == true)
								{
									num5 = 30.48f;
									break;
								}
								num6 = (int?)proficiency8;
								if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 2)) == true)
								{
									num5 = 24.383999f;
									break;
								}
								num6 = (int?)proficiency8;
								if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 3)) != true)
								{
									num6 = (int?)proficiency8;
									if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 4)) == true)
									{
										num5 = 24.383999f;
									}
								}
								else
								{
									num5 = 24.383999f;
								}
								break;
							}
							case 3:
							{
								if (!(weatherProfile.RainfallRate < 5f) || Size > GlobalVariables.AircraftSizeClass.Large)
								{
									break;
								}
								GlobalVariables.ProficiencyLevel? proficiency10 = Proficiency;
								int? num6 = (int?)proficiency10;
								if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() == 0)) == true)
								{
									num5 = 45.72f;
									break;
								}
								num6 = (int?)proficiency10;
								if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 1)) == true)
								{
									num5 = 30.48f;
									break;
								}
								num6 = (int?)proficiency10;
								if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 2)) == true)
								{
									num5 = 24.383999f;
									break;
								}
								num6 = (int?)proficiency10;
								if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 3)) == true)
								{
									num5 = 24.383999f;
									break;
								}
								num6 = (int?)proficiency10;
								if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 4)) == true)
								{
									num5 = 24.383999f;
								}
								break;
							}
							case 4:
							{
								if (!(weatherProfile.RainfallRate < 5f) || Size > GlobalVariables.AircraftSizeClass.Large)
								{
									break;
								}
								GlobalVariables.ProficiencyLevel? proficiency9 = Proficiency;
								int? num6 = (int?)proficiency9;
								if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() == 0)) != true)
								{
									num6 = (int?)proficiency9;
									if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 1)) != true)
									{
										num6 = (int?)proficiency9;
										if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 2)) != true)
										{
											num6 = (int?)proficiency9;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 3)) != true)
											{
												num6 = (int?)proficiency9;
												if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 4)) == true)
												{
													num5 = 24.383999f;
												}
											}
											else
											{
												num5 = 24.383999f;
											}
										}
										else
										{
											num5 = 24.383999f;
										}
									}
									else
									{
										num5 = 30.48f;
									}
								}
								else
								{
									num5 = 45.72f;
								}
								break;
							}
							case 5:
							{
								if (!(weatherProfile.RainfallRate < 5f) || Size > GlobalVariables.AircraftSizeClass.Large)
								{
									break;
								}
								GlobalVariables.ProficiencyLevel? proficiency7 = Proficiency;
								int? num6 = (int?)proficiency7;
								if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() == 0)) != true)
								{
									num6 = (int?)proficiency7;
									if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 1)) != true)
									{
										num6 = (int?)proficiency7;
										if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 2)) != true)
										{
											num6 = (int?)proficiency7;
											if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 3)) != true)
											{
												num6 = (int?)proficiency7;
												if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 4)) == true)
												{
													num5 = 24.383999f;
												}
											}
											else
											{
												num5 = 30.48f;
											}
										}
										else
										{
											num5 = 30.48f;
										}
									}
									else
									{
										num5 = 45.72f;
									}
								}
								else
								{
									num5 = 45.72f;
								}
								break;
							}
							case 6:
							case 7:
							case 8:
							case 9:
							case 10:
								break;
							}
						}
						else
						{
							num5 = 30.48f;
							switch (weatherProfile.SeaState)
							{
							default:
								throw new NotImplementedException();
							case 8:
								num5 = 60.96f;
								break;
							case 9:
								num5 = 60.96f;
								break;
							case 10:
								num5 = 60.96f;
								break;
							case 0:
							case 1:
							case 2:
							case 3:
							case 4:
							case 5:
							case 6:
							case 7:
								break;
							}
						}
					}
					else
					{
						_AircraftCategory category3 = Category;
						if ((uint)(category3 - 2003) <= 1u)
						{
							switch (weatherProfile.SeaState)
							{
							case 0:
								num5 = ThrottleSetting switch
								{
									Throttle.FullStop => 15.24f, 
									Throttle.Loiter => 15.24f, 
									_ => 30.48f, 
								};
								break;
							case 1:
								num5 = ThrottleSetting switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 30.48f, 
								};
								break;
							case 2:
								num5 = ThrottleSetting switch
								{
									Throttle.FullStop => 15.24f, 
									Throttle.Loiter => 15.24f, 
									_ => 30.48f, 
								};
								break;
							case 3:
								num5 = ThrottleSetting switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 30.48f, 
								};
								break;
							case 4:
								num5 = ThrottleSetting switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 30.48f, 
								};
								break;
							case 5:
								num5 = ThrottleSetting switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 30.48f, 
								};
								break;
							case 6:
								num5 = ThrottleSetting switch
								{
									Throttle.FullStop => 15.24f, 
									Throttle.Loiter => 15.24f, 
									_ => 30.48f, 
								};
								break;
							case 7:
								num5 = ThrottleSetting switch
								{
									Throttle.FullStop => 15.24f, 
									Throttle.Loiter => 15.24f, 
									_ => 60.96f, 
								};
								break;
							case 8:
								num5 = ThrottleSetting switch
								{
									Throttle.FullStop => 15.24f, 
									Throttle.Loiter => 15.24f, 
									_ => 60.96f, 
								};
								break;
							case 9:
								num5 = ThrottleSetting switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 60.96f, 
								};
								break;
							case 10:
								num5 = ThrottleSetting switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 60.96f, 
								};
								break;
							}
						}
						else if (!terrainAvoidanceCapability && !terrainFollowingCapability)
						{
							num5 = 91.44f;
							switch (weatherProfile.SeaState)
							{
							default:
								throw new NotImplementedException();
							case 0:
							case 1:
							case 2:
							case 3:
							case 4:
							case 5:
							case 6:
							case 7:
							case 8:
							case 9:
							case 10:
								break;
							}
						}
						else
						{
							num5 = 30.48f;
							switch (weatherProfile.SeaState)
							{
							default:
								throw new NotImplementedException();
							case 8:
								num5 = 60.96f;
								break;
							case 9:
								num5 = 60.96f;
								break;
							case 10:
								num5 = 60.96f;
								break;
							case 0:
							case 1:
							case 2:
							case 3:
							case 4:
							case 5:
							case 6:
							case 7:
								break;
							}
						}
					}
					if (bool_7)
					{
						return num5;
					}
					return (float)num3 + num5;
				}
				return nullable_16;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100366", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = 15.24f;
				ProjectData.ClearProjectError();
			}
			return result;
		}
		set
		{
			try
			{
				nullable_16 = value;
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
	}

	public override float Fuel_FreeLoad
	{
		get
		{
			float result = default(float);
			try
			{
				float num = default(float);
				foreach (FuelRec item in Fuel_ReadOnly)
				{
					num += (float)item.MaxQuantity - item.CurrentQuantity;
				}
				result = num;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100369", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public override bool IsPlatform => true;

	public int CurrentNonEmptyWeight
	{
		get
		{
			int num = 0;
			int num2;
			if (Loadout != null)
			{
				num = Loadout.PayloadWeight;
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			int num3 = num2;
			PooledList<FuelRec> fuel_ReadOnly = Fuel_ReadOnly;
			FuelRec[] array = fuel_ReadOnly.InternalArray();
			int num4 = fuel_ReadOnly.Count - 1;
			for (int i = 0; i <= num4; i++)
			{
				FuelRec fuelRec = array[i];
				if (fuelRec != null)
				{
					num3 += (int)Math.Round(fuelRec.CurrentQuantity);
				}
			}
			fuel_ReadOnly.Dispose();
			return num + num3;
		}
	}

	public int AirshowWeight
	{
		get
		{
			int num = 0;
			FuelRec[] array = _Fuel.InternalArray();
			int num2 = _Fuel.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				FuelRec fuelRec = array[i];
				num += (int)Math.Round((double)fuelRec.CurrentQuantity * 0.6);
			}
			return EmptyWeight + num;
		}
	}

	public float WeightFraction
	{
		get
		{
			if (CurrentNonEmptyWeight != 0)
			{
				int num = EmptyWeight + CurrentNonEmptyWeight;
				int num2 = MaxWeight - AirshowWeight;
				float num3 = (float)Math.Min(0.99, (double)(num - AirshowWeight) / (double)num2);
				if (num3 < 0f)
				{
					num3 = 0f;
				}
				return num3;
			}
			return 0f;
		}
	}

	public override float DamagePts
	{
		get
		{
			return ((ActiveUnit)this).get_DamagePts(ScenEditAction, theWeapon);
		}
		set
		{
			bool flag = value != ((ActiveUnit)this).get_DamagePts(ScenEditAction: false, (Weapon)null);
			float damagePercent = Damage.DamagePercent;
			((ActiveUnit)this).set_DamagePts(ScenEditAction, theWeapon, value);
			float damagePercent2 = Damage.DamagePercent;
			if (!flag || ScenEditAction)
			{
				return;
			}
			float num = DamageThresholdForAbort();
			if (damagePercent < num * 100f && damagePercent2 >= num * 100f && !IsBeingDestroyed && !IsMorituri)
			{
				if (!GlobalVariables.AI_REWORK)
				{
					AirOps.AttemptToRTB(ManuallyOrdered: false, _ActiveUnitStatus.RTB, GroupMembersRTB: false, _ActiveUnitStatus.RTB_Group, DetachFromGroup: true, ClearPlottedCourse: true);
				}
				else
				{
					AI.StatusRelatedEvents.method_0(manuallyOrdered: false, _ActiveUnitStatus.RTB, groupMembersRTB: false, _ActiveUnitStatus.RTB_Group, detachFromGroup: true, clearPlottedCourse: true);
				}
				Weaponry.JettisonOrdnance(ExecuteImmediately: false, JettisonDropTanks: true, JettisonUnguidedAG: true, JettisonGuidedAG: true, bool_12: false, JettisonPod: false, JettisonInternalWeapons: false);
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

	public override bool RepresentsMobileGroundUnit => false;

	public float CurrentCoverRating
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public float Suppression
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	static Aircraft()
	{
		Class72.smethod_20();
		EMERGENCY_LANDING_DISTANCE_NM = 20f;
		UAVSizeClass1FixedFuelConsumption = 0.01666666f;
		UAVSizeClass1FuelUnitOfMeasurementString = "min";
	}

	public float GetAntiAirPower()
	{
		throw new NotImplementedException();
	}

	public override bool IsExhausted()
	{
		if (Crew == 0)
		{
			return false;
		}
		return Current_Exhaustion >= MAX_Exhaustion;
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
		bool_5 = false;
		Loadout = null;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		if (((ActiveUnit)this).get_UnitSide(SetSideOnly: false) == null)
		{
			return;
		}
		theWriter.WriteStartElement("Aircraft");
		theWriter.WriteElementString("ID", ObjectID);
		if (!ObjectsAlreadySerialized.Contains(ObjectID))
		{
			ObjectsAlreadySerialized.Add(ObjectID);
			try
			{
				method_2(ref theWriter);
				theWriter.WriteElementString("Name", Name.Replace("\0", "").Replace("\u0010", ""));
				if (ChanceOfAppearance != 0)
				{
					theWriter.WriteElementString("COA", Conversions.ToString(ChanceOfAppearance));
				}
				if (AutonomyLevel != DroneAutonomyLevel.Undefined)
				{
					theWriter.WriteElementString("AL", Conversions.ToString((int)AutonomyLevel));
				}
				theWriter.WriteElementString("CH", XmlConvert.ToString(CurrentHeading));
				theWriter.WriteElementString("CS", XmlConvert.ToString(CurrentSpeed));
				theWriter.WriteElementString("CA", XmlConvert.ToString(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
				theWriter.WriteElementString("Lon", XmlConvert.ToString(_Longitude));
				theWriter.WriteElementString("Lat", XmlConvert.ToString(_Latitude));
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
				theWriter.WriteElementString("Side", ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Name);
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
				if (DesiredAltitude_AGL != 0f)
				{
					theWriter.WriteElementString("DesiredAltitude_TerrainFollowing", XmlConvert.ToString(DesiredAltitude_AGL));
				}
				if (this.get_DesiredAltitude_UseTerrainFollowing((ActiveUnit)this))
				{
					theWriter.WriteElementString("TerrainFollowing", this.get_DesiredAltitude_UseTerrainFollowing((ActiveUnit)this).ToString());
					if (TerrainFollowingType != TerrainFollowMode.IgnoreLandCover)
					{
						XmlWriter obj = theWriter;
						int terrainFollowingType = (int)TerrainFollowingType;
						obj.WriteElementString("TerrainFollowingType", terrainFollowingType.ToString());
					}
				}
				XmlWriter obj2 = theWriter;
				byte flightRole = (byte)FlightRole;
				obj2.WriteElementString("FlightRole", flightRole.ToString());
				theWriter.WriteElementString("Thr", ((byte)ThrottleSetting).ToString());
				theWriter.WriteElementString("AbnTime", XmlConvert.ToString(AirborneTime));
				if (_Proficiency.HasValue)
				{
					theWriter.WriteElementString("Prof", ((int)_Proficiency.Value).ToString());
				}
				if (Sensors_Cached.Length > 0)
				{
					theWriter.WriteStartElement("Sensors");
					foreach (Sensor sensor in _Sensors)
					{
						theWriter.WriteRaw(sensor.ToXML(ObjectsAlreadySerialized));
					}
					theWriter.WriteEndElement();
					if (Loadout != null)
					{
						PooledList<Sensor> pooledList = Loadout.Sensors(ParentScen);
						if (pooledList != null && pooledList.Count > 0)
						{
							theWriter.WriteStartElement("PoddedSensors");
							foreach (Sensor item in pooledList)
							{
								HashSet<string> objectsAlreadySerialized = new HashSet<string>();
								theWriter.WriteRaw(item.ToXML(objectsAlreadySerialized));
							}
							theWriter.WriteEndElement();
							pooledList.Dispose();
						}
					}
				}
				if (Comms_ReadOnly.Length > 0)
				{
					theWriter.WriteStartElement("Comms");
					CommDevice[] comms = _Comms;
					foreach (CommDevice commDevice in comms)
					{
						theWriter.WriteRaw(commDevice.ToXML(ref ObjectsAlreadySerialized));
					}
					theWriter.WriteEndElement();
				}
				if (Propulsion.Count > 0)
				{
					theWriter.WriteStartElement("Propulsion");
					foreach (Engine item2 in Propulsion)
					{
						theWriter.WriteRaw(item2.ToXML(ObjectsAlreadySerialized));
					}
					theWriter.WriteEndElement();
				}
				if (_Fuel.Count > 0)
				{
					theWriter.WriteStartElement("Fuel");
					foreach (FuelRec item3 in _Fuel)
					{
						theWriter.WriteRaw(item3.ToXML());
					}
					theWriter.WriteEndElement();
				}
				if (Mounts.Count > 0)
				{
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
				}
				if (OnboardCargo.Count() > 0)
				{
					theWriter.WriteStartElement("OnboardCargo");
					Cargo[] onboardCargo = OnboardCargo;
					foreach (Cargo cargo in onboardCargo)
					{
						theWriter.WriteRaw(cargo.ToXML(ObjectsAlreadySerialized, ParentScen));
					}
					theWriter.WriteEndElement();
				}
				XmlWriter obj3 = theWriter;
				flightRole = (byte)_Status;
				obj3.WriteElementString("Status", flightRole.ToString());
				XmlWriter obj4 = theWriter;
				flightRole = (byte)_FuelState;
				obj4.WriteElementString("FuelState", flightRole.ToString());
				theWriter.WriteElementString("WeaponState", ((byte)_WeaponState).ToString());
				if (_StatusBefore_NeedToRefuel != _ActiveUnitStatus.Unassigned)
				{
					XmlWriter obj5 = theWriter;
					flightRole = (byte)_StatusBefore_NeedToRefuel;
					obj5.WriteElementString("SBR", flightRole.ToString());
				}
				if (_StatusBefore_EngagedDefensive != _ActiveUnitStatus.Unassigned)
				{
					XmlWriter obj6 = theWriter;
					flightRole = (byte)_StatusBefore_EngagedDefensive;
					obj6.WriteElementString("SBED", flightRole.ToString());
				}
				if (_StatusBefore_EngagedOffensive != _ActiveUnitStatus.Unassigned)
				{
					XmlWriter obj7 = theWriter;
					flightRole = (byte)_StatusBefore_EngagedOffensive;
					obj7.WriteElementString("SBEO", flightRole.ToString());
				}
				if (_FuelStateBefore_NeedToRefuel != _ActiveUnitFuelState.None)
				{
					XmlWriter obj8 = theWriter;
					flightRole = (byte)_FuelStateBefore_NeedToRefuel;
					obj8.WriteElementString("FSBR", flightRole.ToString());
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
				XmlWriter obj9 = theWriter;
				flightRole = (byte)_ThrottleBefore_NeedToRefuel;
				obj9.WriteElementString("SBR_ThrottleSetting", flightRole.ToString());
				theWriter.WriteElementString("SBED_Altitude", XmlConvert.ToString(_AltitudeBefore_EngagedDefensive));
				if (_AltitudeBefore_EngagedDefensive_AGL.HasValue)
				{
					theWriter.WriteElementString("SBED_Altitude_TF", XmlConvert.ToString(_AltitudeBefore_EngagedDefensive_AGL.Value));
				}
				theWriter.WriteElementString("SBED_TF", XmlConvert.ToString(_TerrainFollowingBefore_EngagedDefensive));
				XmlWriter obj10 = theWriter;
				flightRole = (byte)_ThrottleBefore_EngagedDefensive;
				obj10.WriteElementString("SBED_ThrottleSetting", flightRole.ToString());
				if (_DesiredSpeedOverrideBefore_EngagedDefensive.HasValue)
				{
					theWriter.WriteElementString("SBED_DesiredSpeedOverride", XmlConvert.ToString(_DesiredSpeedOverrideBefore_EngagedDefensive.Value));
				}
				theWriter.WriteElementString("SBEO_Altitude", XmlConvert.ToString(_AltitudeBefore_EngagedOffensive));
				theWriter.WriteElementString("SBEO_Altitude_TF", XmlConvert.ToString(_AltitudeBefore_EngagedOffensive_AGL));
				theWriter.WriteElementString("SBEO_TF", XmlConvert.ToString(_TerrainFollowingBefore_EngagedOffensive));
				if (_ThrottleBefore_EngagedOffensive != Throttle.FullStop)
				{
					XmlWriter obj11 = theWriter;
					flightRole = (byte)_ThrottleBefore_EngagedOffensive;
					obj11.WriteElementString("SBEO_ThrottleSetting", flightRole.ToString());
				}
				theWriter.WriteElementString("SBPF_Altitude", XmlConvert.ToString(_AltitudeBefore_WaitForPathfinder));
				theWriter.WriteElementString("SBPF_Altitude_TF", XmlConvert.ToString(_AltitudeBefore_WaitForPathfinder_AGL));
				theWriter.WriteElementString("SBPF_TF", XmlConvert.ToString(_TerrainFollowingBefore_WaitForPathfinder));
				XmlWriter obj12 = theWriter;
				flightRole = (byte)_ThrottleBefore_WaitForPathfinder;
				obj12.WriteElementString("SBPF_ThrottleSetting", flightRole.ToString());
				theWriter.WriteElementString("AMP_OC", _MissionPlannerOverrideCancellation.ToString());
				if (_MissionPlannerOverrideCancellation_DesiredSpeedOverride.HasValue)
				{
					theWriter.WriteElementString("AMP_OC_DSO", _MissionPlannerOverrideCancellation_DesiredSpeedOverride.ToString());
				}
				theWriter.WriteElementString("AMP_OC_DAO", _MissionPlannerOverrideCancellation_DesiredAltitudeOverride.ToString());
				theWriter.WriteElementString("AMP_OC_Speed", XmlConvert.ToString(_MissionPlannerOverrideCancellation_Speed));
				theWriter.WriteElementString("DamagePts", XmlConvert.ToString(this.get_DamagePts(ScenEditAction: false, (Weapon)null)));
				theWriter.WriteElementString("OldDamagePercent", XmlConvert.ToString(_OldDamagePercent));
				if (EligibleForSAR)
				{
					theWriter.WriteElementString("EFSAR", XmlConvert.ToString(EligibleForSAR));
				}
				if (IsBeingPickedUp)
				{
					theWriter.WriteElementString("IBPU", XmlConvert.ToString(IsBeingPickedUp));
				}
				if (Attitude_Pitch != 0f)
				{
					theWriter.WriteElementString("Pitch", XmlConvert.ToString(Attitude_Pitch));
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
				Doctrine.ToXML(ref theWriter, ref ParentScen);
				if (Loadout != null)
				{
					theWriter.WriteStartElement("Loadout");
					theWriter.WriteRaw(Loadout.ToXML(ref ObjectsAlreadySerialized, ParentScen));
					theWriter.WriteEndElement();
				}
				Navigator.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteStartElement("AI");
				if (AI.myUnit == null)
				{
					AI.myUnit = this;
				}
				AI.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteEndElement();
				theWriter.WriteStartElement("Kinematics");
				Kinematics.ToXML(ref theWriter);
				theWriter.WriteEndElement();
				Sensory.ToXML(ref theWriter);
				Weaponry.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteStartElement("CommStuff");
				CommStuff.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteEndElement();
				Damage.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				AirOps.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				if (HasCustomOODA)
				{
					theWriter.WriteElementString("OODA_D", OODA_Detection.ToString());
					theWriter.WriteElementString("OODA_T", OODA_Targeting.ToString());
					theWriter.WriteElementString("OODA_E", OODA_Evasion.ToString());
				}
				if (DockingOps != null && DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
				{
					ActiveUnit_DockingOps.ToXML(DockingOps, ref theWriter, ref ObjectsAlreadySerialized);
				}
				theWriter.WriteEndElement();
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100348", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		theWriter.WriteEndElement();
	}

	private Aircraft()
	{
		Scenario theScen = null;
		base..ctor(ref theScen);
		G_Tolerance = 45f;
		ShouldDropSonobuoysOnThisPulse = false;
		Armor_Cockpit = GlobalVariables.ArmorRating.None;
		Armor_Fuselage = GlobalVariables.ArmorRating.None;
		Armor_Powerplant = GlobalVariables.ArmorRating.None;
		FuelState_RemainingFuelToBingo = 0f;
		FuelState_RemainingFuelToJoker = 0f;
		VisibilityForward = CockpitVisibility.Excellent;
		VisibilitySideways = CockpitVisibility.Excellent;
		VisibilityAft = CockpitVisibility.Excellent;
		ActiveUnit theUnit = this;
		aircraft_Navigator_0 = new Aircraft_Navigator(ref theUnit);
		theUnit = this;
		aircraft_AI_0 = new Aircraft_AI(ref theUnit);
		theUnit = this;
		aircraft_Kinematics_0 = new Aircraft_Kinematics(ref theUnit);
		Cargo_Crew = 0;
		Cargo_Area = 0f;
		Cargo_Type = CargoType.NoCargo;
		Cargo_Mass = 0f;
		Cargo_ParadropCapable = false;
		IsAircraft = true;
		UnitType = GlobalVariables.ActiveUnitType.Aircraft;
		theUnit = this;
		aircraft_AirOps_0 = new Aircraft_AirOps(ref theUnit);
	}

	public static Aircraft FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, Aircraft existingObject = null)
	{
		Aircraft aircraft = default(Aircraft);
		try
		{
			aircraft = smethod_1(ref theNode, ref theDictionary, ref theScen, theScen.LoadStockUnits, existingObject);
		}
		catch (PlatformComponentNotFoundException projectError)
		{
			ProjectData.SetProjectError((Exception)projectError);
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			ConcurrentDictionary<string, ScenarioObject> obj = theDictionary;
			ScenarioObject value = aircraft;
			obj.TryRemove(innerText, out value);
			aircraft = smethod_1(ref theNode, ref theDictionary, ref theScen, bool_7: true, existingObject);
			string text = "";
			if (aircraft.IsGroupMember())
			{
				text = "(member of group: [" + ((ActiveUnit)aircraft).get_ParentGroup(UsingMissionPlanner: false).Name + "])";
			}
			theScen.LoadingNotices.Add("The following aircraft:[" + aircraft.Name + "]" + text + " failed to shallow-rebuild because of a component missing. The aircraft was instead deep-rebuilt, and instantiated in its pristine DB-stock condition. All customizations present in the aircraft's components (damaged components, weapon additions/removals etc. etc.) have been lost. Please re-apply any necessary customizations either manually or using an SBR script.");
			if (aircraft.IsUnderground)
			{
				aircraft.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)(Terrain.GetElevation(aircraft.get_Latitude((GlobalVariables.BooleanObject)null), aircraft.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, aircraft.ParentScen) + 1));
			}
			ProjectData.ClearProjectError();
		}
		return aircraft;
	}

	private static Aircraft smethod_1(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0, bool bool_7, Aircraft aircraft_0 = null)
	{
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_0780: Unknown result type (might be due to invalid IL or missing references)
		//IL_0787: Expected O, but got Unknown
		//IL_0701: Unknown result type (might be due to invalid IL or missing references)
		//IL_0715: Expected O, but got Unknown
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Expected O, but got Unknown
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Expected O, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		//IL_0692: Unknown result type (might be due to invalid IL or missing references)
		//IL_0699: Expected O, but got Unknown
		//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Expected O, but got Unknown
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		//IL_0612: Unknown result type (might be due to invalid IL or missing references)
		//IL_0619: Expected O, but got Unknown
		//IL_1947: Unknown result type (might be due to invalid IL or missing references)
		//IL_194e: Expected O, but got Unknown
		//IL_11ca: Unknown result type (might be due to invalid IL or missing references)
		Sensor[] theArray = new Sensor[0];
		bool flag;
		Aircraft theAircraft;
		if (flag = aircraft_0 != null)
		{
			theAircraft = aircraft_0;
			theAircraft.Reinitialize();
		}
		else
		{
			theAircraft = new Aircraft();
		}
		try
		{
			theAircraft.ParentScen = scenario_0;
			string text = Misc.GetNodeByName(xmlNode_0.ChildNodes, "ID").InnerText;
			if (Misc.ContainsChar(text, ' '))
			{
				text = text.Replace(" ", "-");
			}
			if (!concurrentDictionary_0.ContainsKey(text))
			{
				theAircraft.ObjectID_Set(text);
				if (xmlNode_0.ChildNodes.Count == 1)
				{
					try
					{
						scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 42138756217059872635", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					return theAircraft;
				}
				concurrentDictionary_0.TryAdd(theAircraft.ObjectID, theAircraft);
				int num = Conversions.ToInteger(Misc.GetNodeByName(xmlNode_0.ChildNodes, "DBID").InnerText);
				try
				{
					DBFunctions.GetAircraft(ref scenario_0, ref theAircraft, num, bool_7);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
					string objectID = theAircraft.ObjectID;
					ScenarioObject value = theAircraft;
					obj.TryRemove(objectID, out value);
					scenario_0.LoadingNotices.Add("Aircraft with Database ID " + Conversions.ToString(num) + " is missing from the database and has not been loaded.");
					ProjectData.ClearProjectError();
					goto end_IL_0021;
				}
				if (bool_7)
				{
					theAircraft.method_3(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
				}
				if (!bool_7)
				{
					foreach (XmlNode childNode in xmlNode_0.ChildNodes)
					{
						XmlNode val = childNode;
						theAircraft.CommonFromXML(val);
						switch (val.Name)
						{
						case "Comms":
						{
							if (flag)
							{
								ArrayExtensions.Clear(ref theAircraft._Comms);
							}
							int num2 = val.ChildNodes.Count - 1;
							for (int i = 0; i <= num2; i++)
							{
								XmlNode theNode4 = val.ChildNodes[i];
								CommDevice commDevice = CommDevice.FromXML(ref theNode4, ref concurrentDictionary_0, theAircraft);
								if (commDevice.DBID == 0)
								{
									Aircraft theAircraft2 = new Aircraft(ref scenario_0);
									theAircraft2.ParentScen = scenario_0;
									DBFunctions.GetAircraft(ref scenario_0, ref theAircraft2, num);
									try
									{
										commDevice = theAircraft2.Comms_ReadOnly[i];
										theAircraft2 = null;
									}
									catch (Exception ex3)
									{
										ProjectData.SetProjectError(ex3);
										Exception ex4 = ex3;
										ex4?.Data.Add("Error at 200018", ex4.Message);
										GameGeneral.WriteExceptionsToLog(ex4);
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										ProjectData.ClearProjectError();
										continue;
									}
								}
								concurrentDictionary_0.TryAdd(commDevice.ObjectID, commDevice);
								theAircraft.AddCommDevice(commDevice);
								commDevice.ParentPlatform = theAircraft;
							}
							break;
						}
						case "OnboardCargo":
							if (flag)
							{
								ArrayExtensions.Clear(ref theAircraft.OnboardCargo);
							}
							foreach (XmlNode childNode2 in val.ChildNodes)
							{
								XmlNode theNode7 = childNode2;
								Cargo cargo = Cargo.FromXML(ref theNode7, ref concurrentDictionary_0, scenario_0, theAircraft);
								ArrayExtensions.Add(ref theAircraft.OnboardCargo, cargo);
								cargo.ParentPlatform = theAircraft;
							}
							break;
						case "Fuel":
							if (flag)
							{
								theAircraft._Fuel.Clear();
							}
							foreach (XmlNode childNode3 in val.ChildNodes)
							{
								XmlNode theNode5 = childNode3;
								FuelRec item = FuelRec.FromXML(ref theNode5, ref concurrentDictionary_0);
								theAircraft._Fuel.Add(item);
							}
							break;
						case "DockFacilities":
							if (flag)
							{
								ArrayExtensions.Clear(ref theAircraft._DockFacilities);
							}
							foreach (XmlNode childNode4 in val.ChildNodes)
							{
								XmlNode theNode2 = childNode4;
								DockFacility dockFacility = DockFacility.FromXML(ref theNode2, ref concurrentDictionary_0, ref scenario_0);
								theAircraft.AddDockFacility(dockFacility);
								dockFacility.ParentPlatform = theAircraft;
							}
							break;
						case "Sensors":
							if (flag)
							{
								theAircraft._Sensors.Clear();
							}
							foreach (XmlNode childNode5 in val.ChildNodes)
							{
								Sensor sensor = Sensor.FromXML(childNode5, concurrentDictionary_0, theAircraft);
								theAircraft._Sensors.Add(sensor);
								sensor.ParentPlatform = theAircraft;
							}
							break;
						case "Propulsion":
							if (flag)
							{
								theAircraft.Propulsion.Clear();
							}
							foreach (XmlNode childNode6 in val.ChildNodes)
							{
								XmlNode theNode6 = childNode6;
								ActiveUnit theParentPlatform = theAircraft;
								Engine engine = Engine.FromXML(ref theNode6, ref concurrentDictionary_0, ref theParentPlatform);
								theAircraft.Propulsion.Add(engine);
								engine.ParentPlatform = theAircraft;
							}
							break;
						case "AirFacilities":
							if (flag)
							{
								ArrayExtensions.Clear(ref theAircraft._AirFacilities);
							}
							foreach (XmlNode childNode7 in val.ChildNodes)
							{
								XmlNode theNode3 = childNode7;
								AirFacility airFacility = AirFacility.FromXML(ref theNode3, ref concurrentDictionary_0, ref scenario_0);
								theAircraft.AddAirFacility(airFacility);
								airFacility.ParentPlatform = theAircraft;
							}
							break;
						case "Mounts":
							if (flag)
							{
								theAircraft.Mounts.Clear();
							}
							foreach (XmlNode childNode8 in val.ChildNodes)
							{
								XmlNode theNode = childNode8;
								Mount mount = Mount.FromXML(ref theNode, ref concurrentDictionary_0, theAircraft);
								theAircraft.Mounts.Add(mount);
								mount.ParentPlatform = theAircraft;
							}
							break;
						case "PoddedSensors":
							foreach (XmlNode childNode9 in val.ChildNodes)
							{
								ConcurrentDictionary<string, ScenarioObject> theDictionary = new ConcurrentDictionary<string, ScenarioObject>();
								Sensor theAC = Sensor.FromXML(childNode9, theDictionary, theAircraft);
								ArrayExtensions.Add(ref theArray, theAC);
							}
							break;
						}
					}
				}
				bool excludeOptionalWeapons = default(bool);
				foreach (XmlNode childNode10 in xmlNode_0.ChildNodes)
				{
					XmlNode theNode8 = childNode10;
					if (!theAircraft.isLastReportedInfoXMLField(theNode8.Name))
					{
						switch (theNode8.Name)
						{
						case "FSBR":
							theAircraft._FuelStateBefore_NeedToRefuel = (_ActiveUnitFuelState)Conversions.ToByte(theNode8.InnerText);
							break;
						case "Status":
							if (!Versioned.IsNumeric((object)theNode8.InnerText))
							{
								theAircraft._Status = (_ActiveUnitStatus)Enum.Parse(typeof(_ActiveUnitStatus), theNode8.InnerText, ignoreCase: true);
							}
							else
							{
								theAircraft._Status = (_ActiveUnitStatus)Conversions.ToByte(theNode8.InnerText);
							}
							if (theAircraft._Status == (_ActiveUnitStatus)9)
							{
								theAircraft.Status = _ActiveUnitStatus.RTB;
							}
							if (theAircraft._Status != _ActiveUnitStatus.Refuelling && theAircraft._Status != _ActiveUnitStatus.HeadingToRefuelPoint)
							{
								if (theAircraft._Status == _ActiveUnitStatus.EngagedDefensive)
								{
									if (theAircraft._StatusBefore_EngagedDefensive == _ActiveUnitStatus.Unassigned)
									{
										theAircraft._StatusBefore_EngagedDefensive = _ActiveUnitStatus.Unassigned;
										theAircraft._ThrottleBefore_EngagedDefensive = Throttle.Cruise;
										theAircraft._AltitudeBefore_EngagedDefensive = theAircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
										theAircraft._AltitudeBefore_EngagedDefensive_AGL = 0f;
										theAircraft._TerrainFollowingBefore_EngagedDefensive = false;
									}
								}
								else if (theAircraft._Status == _ActiveUnitStatus.EngagedOffensive)
								{
									if (theAircraft._StatusBefore_EngagedOffensive == _ActiveUnitStatus.Unassigned)
									{
										theAircraft._StatusBefore_EngagedOffensive = _ActiveUnitStatus.Unassigned;
										theAircraft._ThrottleBefore_EngagedOffensive = Throttle.Cruise;
										theAircraft._AltitudeBefore_EngagedOffensive = theAircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
										theAircraft._AltitudeBefore_EngagedOffensive_AGL = 0f;
										theAircraft._TerrainFollowingBefore_EngagedOffensive = false;
									}
								}
								else if (theAircraft._Status == _ActiveUnitStatus.WaitForPathfinder && theAircraft._StatusBefore_EngagedOffensive == _ActiveUnitStatus.Unassigned)
								{
									theAircraft._StatusBefore_EngagedOffensive = _ActiveUnitStatus.Unassigned;
									theAircraft._ThrottleBefore_EngagedOffensive = Throttle.Cruise;
									theAircraft._AltitudeBefore_EngagedOffensive = theAircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
									theAircraft._AltitudeBefore_EngagedOffensive_AGL = 0f;
									theAircraft._TerrainFollowingBefore_EngagedOffensive = false;
								}
							}
							else if (theAircraft._StatusBefore_NeedToRefuel == _ActiveUnitStatus.Unassigned)
							{
								theAircraft._StatusBefore_NeedToRefuel = _ActiveUnitStatus.Unassigned;
								theAircraft._ThrottleBefore_NeedToRefuel = Throttle.Cruise;
								theAircraft._AltitudeBefore_NeedToRefuel = theAircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
								theAircraft._AltitudeBefore_NeedToRefuel_AGL = 0f;
								theAircraft._TerrainFollowingBefore_NeedToRefuel = false;
							}
							break;
						case "AMP_OC_Speed":
							theAircraft._MissionPlannerOverrideCancellation_Speed = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "Name":
							theAircraft.Name = theNode8.InnerText;
							break;
						case "DesiredTurnRate_Navigation":
						case "DTN":
							theAircraft.DesiredTurnRate_Navigation = (Waypoint.TurnRateCategory)Conversions.ToByte(theNode8.InnerText);
							break;
						case "SBED_Altitude_TF":
							if (XmlConvert.ToSingle(theNode8.InnerText) != 0f)
							{
								theAircraft._AltitudeBefore_EngagedDefensive_AGL = XmlConvert.ToSingle(theNode8.InnerText);
							}
							break;
						case "SBPF_TF":
							theAircraft._TerrainFollowingBefore_WaitForPathfinder = Misc.ParseBool(theNode8.InnerText);
							break;
						case "AL":
							theAircraft.AutonomyLevel = (DroneAutonomyLevel)Conversions.ToInteger(theNode8.InnerText);
							break;
						case "FlightRole":
							theAircraft.FlightRole = (Mission.Flight.FlightElement)Conversions.ToByte(theNode8.InnerText);
							break;
						case "FuelState":
							theAircraft._FuelState = (_ActiveUnitFuelState)Conversions.ToByte(theNode8.InnerText);
							break;
						case "DamagePts":
						{
							if (bool_7)
							{
								break;
							}
							float num3 = XmlConvert.ToSingle(theNode8.InnerText);
							if ((int)Math.Round(num3) <= 50 && (int)Math.Round(num3) <= theAircraft.InitialDP)
							{
								if ((int)Math.Round(num3) != 0)
								{
									theAircraft.set_DamagePts(ScenEditAction: false, (Weapon)null, num3);
								}
								else
								{
									theAircraft.set_DamagePts(ScenEditAction: false, (Weapon)null, (float)theAircraft.InitialDP);
								}
							}
							else
							{
								theAircraft.set_DamagePts(ScenEditAction: false, (Weapon)null, (float)theAircraft.InitialDP);
							}
							break;
						}
						case "OldDamagePercent":
							theAircraft._OldDamagePercent = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "COA":
							theAircraft.ChanceOfAppearance = Conversions.ToInteger(theNode8.InnerText);
							break;
						case "AMP_OC_DAO":
							theAircraft._MissionPlannerOverrideCancellation_DesiredAltitudeOverride = Misc.ParseBool(theNode8.InnerText);
							break;
						case "SBED_Altitude":
							theAircraft._AltitudeBefore_EngagedDefensive = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "PrivateSnapshotMission":
							theAircraft.PrivateSnapshotMission = Mission.FromXML(ref theNode8, ref concurrentDictionary_0, ref scenario_0);
							break;
						case "SBPF_Altitude_TF":
							theAircraft._AltitudeBefore_WaitForPathfinder_AGL = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "DesiredHeading":
						case "DH":
							((ActiveUnit)theAircraft).set_DesiredHeading(TurnRate.Max, XmlConvert.ToSingle(theNode8.InnerText));
							break;
						case "SBPF_ThrottleSetting":
							switch (theNode8.InnerText)
							{
							case "FullStop":
								theAircraft._ThrottleBefore_WaitForPathfinder = Throttle.FullStop;
								break;
							default:
								theAircraft._ThrottleBefore_WaitForPathfinder = (Throttle)Conversions.ToByte(theNode8.InnerText);
								break;
							case "Flank":
								theAircraft._ThrottleBefore_WaitForPathfinder = Throttle.Flank;
								break;
							case "Full":
								theAircraft._ThrottleBefore_WaitForPathfinder = Throttle.Full;
								break;
							case "Cruise":
								theAircraft._ThrottleBefore_WaitForPathfinder = Throttle.Cruise;
								break;
							case "Loiter":
								theAircraft._ThrottleBefore_WaitForPathfinder = Throttle.Loiter;
								break;
							}
							break;
						case "SBED_DesiredSpeedOverride":
							theAircraft._DesiredSpeedOverrideBefore_EngagedDefensive = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "SBR":
							theAircraft._StatusBefore_NeedToRefuel = (_ActiveUnitStatus)Conversions.ToByte(theNode8.InnerText);
							break;
						case "SBR_Altitude_TF":
							theAircraft._AltitudeBefore_NeedToRefuel_AGL = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "ActiveEnterAreaTriggers":
							if (flag)
							{
								theAircraft.ActiveEnterAreaTriggers.Clear();
							}
							foreach (XmlNode childNode11 in theNode8.ChildNodes)
							{
								string innerText2 = childNode11.InnerText;
								theAircraft.ActiveEnterAreaTriggers.Add(innerText2);
							}
							break;
						case "SBED_ThrottleSetting":
							switch (theNode8.InnerText)
							{
							case "Loiter":
								theAircraft._ThrottleBefore_EngagedDefensive = Throttle.Loiter;
								break;
							case "Cruise":
								theAircraft._ThrottleBefore_EngagedDefensive = Throttle.Cruise;
								break;
							case "Full":
								theAircraft._ThrottleBefore_EngagedDefensive = Throttle.Full;
								break;
							default:
								theAircraft._ThrottleBefore_EngagedDefensive = (Throttle)Conversions.ToByte(theNode8.InnerText);
								break;
							case "Flank":
								theAircraft._ThrottleBefore_EngagedDefensive = Throttle.Flank;
								break;
							case "FullStop":
								theAircraft._ThrottleBefore_EngagedDefensive = Throttle.FullStop;
								break;
							}
							break;
						case "Thr":
						case "ThrottleSetting":
							switch (theNode8.InnerText)
							{
							case "Loiter":
								theAircraft.ThrottleSetting = Throttle.Loiter;
								break;
							case "Flank":
								theAircraft.ThrottleSetting = Throttle.Flank;
								break;
							default:
								theAircraft.ThrottleSetting = (Throttle)Conversions.ToByte(theNode8.InnerText);
								break;
							case "Full":
								theAircraft.ThrottleSetting = Throttle.Full;
								break;
							case "Cruise":
								theAircraft.ThrottleSetting = Throttle.Cruise;
								break;
							case "FullStop":
								theAircraft.ThrottleSetting = Throttle.FullStop;
								break;
							}
							if (theAircraft.ThrottleSetting == Throttle.FullStop && !theAircraft.get_CanHover(bool_7: false))
							{
								theAircraft.ThrottleSetting = Throttle.Cruise;
							}
							break;
						case "Prof":
							theAircraft.Proficiency = (GlobalVariables.ProficiencyLevel)Conversions.ToInteger(theNode8.InnerText);
							break;
						case "Doctrine":
							if (flag)
							{
								theAircraft.Doctrine = Doctrine.FromXML(scenario_0, ref theNode8, theAircraft, theAircraft.Doctrine);
							}
							else
							{
								theAircraft.Doctrine = Doctrine.FromXML(scenario_0, ref theNode8, theAircraft);
							}
							break;
						case "SBEO_TF":
							theAircraft._TerrainFollowingBefore_EngagedOffensive = Misc.ParseBool(theNode8.InnerText);
							break;
						case "WeaponState":
							theAircraft._WeaponState = (_ActiveUnitWeaponState)Conversions.ToSByte(theNode8.InnerText);
							break;
						case "SBED_TF":
							theAircraft._TerrainFollowingBefore_EngagedDefensive = Misc.ParseBool(theNode8.InnerText);
							break;
						case "Damage":
						case "Aircraft_Damage":
						{
							Aircraft aircraft8 = theAircraft;
							ActiveUnit theParentPlatform = theAircraft;
							aircraft8.aircraft_Damage_0 = Aircraft_Damage.FromXML(ref theNode8, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "AMP_OC_DSO":
							theAircraft._MissionPlannerOverrideCancellation_DesiredSpeedOverride = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "Latitude_UnitEntersAreaCheck":
							theAircraft.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(theNode8.InnerText);
							break;
						case "OODA_D":
							theAircraft.HasCustomOODA = true;
							theAircraft.OODA_Detection = Conversions.ToShort(theNode8.InnerText);
							break;
						case "OODA_E":
							theAircraft.HasCustomOODA = true;
							theAircraft.OODA_Evasion = Conversions.ToShort(theNode8.InnerText);
							break;
						case "DA":
						case "DesiredAltitude":
							theAircraft.DesiredAltitude = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "Pitch":
							theAircraft.Attitude_Pitch = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "CurrentAltitude":
						case "CA":
							theAircraft.set_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null, XmlConvert.ToSingle(theNode8.InnerText));
							break;
						case "AssignedMission":
							if (theNode8.HasChildNodes)
							{
								XmlNode val5 = theNode8.ChildNodes[0];
								theAircraft._AssignedMissionOrPackage_ID = val5.InnerText;
							}
							break;
						case "Kinematics":
						case "Aircraft_Kinematics":
							ActiveUnit_Kinematics.FromXML(theNode8, concurrentDictionary_0, theAircraft);
							break;
						case "Aircraft_Sensory":
						case "Sensory":
						{
							Aircraft aircraft7 = theAircraft;
							ActiveUnit theParentPlatform = theAircraft;
							aircraft7.aircraft_Sensory_0 = Aircraft_Sensory.FromXML(ref theNode8, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "EFSAR":
							theAircraft.EligibleForSAR = Misc.ParseBool(theNode8.InnerText);
							break;
						case "OODA_T":
							theAircraft.HasCustomOODA = true;
							theAircraft.OODA_Targeting = Conversions.ToShort(theNode8.InnerText);
							break;
						case "ActiveRemainAreaTriggers":
						{
							string key = null;
							DateTime result = DateTime.MinValue;
							foreach (XmlNode childNode12 in theNode8.ChildNodes)
							{
								XmlNode val4 = childNode12;
								if (Operators.CompareString(val4.Name, "RemainAreaTrigger", false) == 0)
								{
									key = val4.InnerText;
									result = DateTime.MinValue;
									continue;
								}
								if (DateTime.TryParse(val4.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
								{
									theAircraft.ActiveRemainAreaTriggers.Add(key, result);
									continue;
								}
								string innerText = val4.InnerText;
								long result2 = default(long);
								if (long.TryParse(innerText, out result2))
								{
									result = DateTime.FromBinary(Conversions.ToLong(val4.InnerText));
									theAircraft.ActiveRemainAreaTriggers.Add(key, result);
								}
							}
							break;
						}
						case "TerrainFollowing":
							theAircraft.set_DesiredAltitude_UseTerrainFollowing((ActiveUnit)theAircraft, Misc.ParseBool(theNode8.InnerText));
							break;
						case "AirOps":
						case "Aircraft_AirOps":
						{
							Aircraft aircraft6 = theAircraft;
							ActiveUnit theParentPlatform = theAircraft;
							aircraft6.aircraft_AirOps_0 = Aircraft_AirOps.FromXML(ref theNode8, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "Side":
							theAircraft._SideName = theNode8.InnerText;
							break;
						case "CommStuff":
						case "Aircraft_CommStuff":
						{
							Aircraft aircraft5 = theAircraft;
							ActiveUnit theParentPlatform = theAircraft;
							aircraft5.aircraft_CommStuff_0 = Aircraft_CommStuff.FromXML(ref theNode8, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "Longitude":
						case "Lon":
							theAircraft._Longitude = XmlConvert.ToDouble(theNode8.InnerText.Replace(",", "."));
							break;
						case "DesiredAltitude_TerrainFollowing":
							theAircraft.DesiredAltitude_AGL = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "CustomIcon":
							theAircraft.CustomIcon = theNode8.InnerText;
							break;
						case "IBPU":
							theAircraft.IsBeingPickedUp = Misc.ParseBool(theNode8.InnerText);
							break;
						case "AI":
						case "Aircraft_AI":
						{
							Aircraft aircraft4 = theAircraft;
							ActiveUnit theParentPlatform = theAircraft;
							aircraft4.aircraft_AI_0 = Aircraft_AI.FromXML(ref theNode8, ref concurrentDictionary_0, ref theParentPlatform);
							if (theAircraft.get_DesiredAltitude_UseTerrainFollowing((ActiveUnit)theAircraft) && theAircraft.DesiredAltitude_AGL == 0f)
							{
								theAircraft.DesiredAltitude_AGL = 60.96f;
							}
							break;
						}
						case "SBEO_Altitude":
							theAircraft._AltitudeBefore_EngagedOffensive = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "SBPF_Altitude":
							theAircraft._AltitudeBefore_WaitForPathfinder = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "DS":
						case "DesiredSpeed":
							theAircraft.DesiredSpeed = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "Message":
							theAircraft.Message = theNode8.InnerText;
							break;
						case "SBEO_Altitude_TF":
							theAircraft._AltitudeBefore_EngagedOffensive_AGL = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "AssignedTaskPool":
							if (theNode8.HasChildNodes)
							{
								XmlNode val3 = theNode8.ChildNodes[0];
								theAircraft._AssignedTaskPool_ID = val3.InnerText;
							}
							break;
						case "DockingOps":
						case "ActiveUnit_DockingOps":
						{
							Aircraft aircraft3 = theAircraft;
							ActiveUnit theParentPlatform = theAircraft;
							aircraft3.DockingOps = ActiveUnit_DockingOps.FromXML(ref theNode8, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "Latitude":
						case "Lat":
							theAircraft._Latitude = XmlConvert.ToDouble(theNode8.InnerText.Replace(",", "."));
							break;
						case "SBR_ThrottleSetting":
							switch (theNode8.InnerText)
							{
							case "FullStop":
								theAircraft._ThrottleBefore_NeedToRefuel = Throttle.FullStop;
								break;
							case "Loiter":
								theAircraft._ThrottleBefore_NeedToRefuel = Throttle.Loiter;
								break;
							case "Cruise":
								theAircraft._ThrottleBefore_NeedToRefuel = Throttle.Cruise;
								break;
							case "Flank":
								theAircraft._ThrottleBefore_NeedToRefuel = Throttle.Flank;
								break;
							default:
								theAircraft._ThrottleBefore_NeedToRefuel = (Throttle)Conversions.ToByte(theNode8.InnerText);
								break;
							case "Full":
								theAircraft._ThrottleBefore_NeedToRefuel = Throttle.Full;
								break;
							}
							break;
						case "AMP_OC":
							theAircraft._MissionPlannerOverrideCancellation = Misc.ParseBool(theNode8.InnerText);
							break;
						case "SBR_Altitude":
							theAircraft._AltitudeBefore_NeedToRefuel = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "SBR_TF":
							theAircraft._TerrainFollowingBefore_NeedToRefuel = Misc.ParseBool(theNode8.InnerText);
							break;
						case "SBEO":
							theAircraft._StatusBefore_EngagedOffensive = (_ActiveUnitStatus)Conversions.ToByte(theNode8.InnerText);
							break;
						case "SBED":
							theAircraft._StatusBefore_EngagedDefensive = (_ActiveUnitStatus)Conversions.ToByte(theNode8.InnerText);
							break;
						case "DT":
						case "DesiredTurnRate":
							theAircraft.DesiredTurnRate = (TurnRate)Conversions.ToByte(theNode8.InnerText);
							break;
						case "CS":
						case "CurrentSpeed":
							theAircraft.CurrentSpeed = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "Aircraft_Weaponry":
						case "Weaponry":
						{
							Aircraft aircraft2 = theAircraft;
							ActiveUnit theParentPlatform = theAircraft;
							aircraft2.aircraft_Weaponry_0 = Aircraft_Weaponry.FromXML(ref theNode8, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "SBEO_ThrottleSetting":
							switch (theNode8.InnerText)
							{
							case "Loiter":
								theAircraft._ThrottleBefore_EngagedOffensive = Throttle.Loiter;
								break;
							default:
								theAircraft._ThrottleBefore_EngagedOffensive = (Throttle)Conversions.ToByte(theNode8.InnerText);
								break;
							case "Flank":
								theAircraft._ThrottleBefore_EngagedOffensive = Throttle.Flank;
								break;
							case "Full":
								theAircraft._ThrottleBefore_EngagedOffensive = Throttle.Full;
								break;
							case "Cruise":
								theAircraft._ThrottleBefore_EngagedOffensive = Throttle.Cruise;
								break;
							case "FullStop":
								theAircraft._ThrottleBefore_EngagedOffensive = Throttle.FullStop;
								break;
							}
							break;
						case "Aircraft_Navigator":
						case "Navigator":
						{
							Aircraft aircraft = theAircraft;
							ActiveUnit theParentPlatform = theAircraft;
							aircraft.aircraft_Navigator_0 = Aircraft_Navigator.FromXML(ref theNode8, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "Longitude_UnitEntersAreaCheck":
							theAircraft.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(theNode8.InnerText);
							break;
						case "Loadout":
							if (bool_7)
							{
								theAircraft.Loadout = Loadout.FromXML(theNode8.ChildNodes[0], concurrentDictionary_0, ref theAircraft, ref scenario_0);
								if (theAircraft.Loadout != null && theAircraft.Loadout.NoOptionalWeapons)
								{
									excludeOptionalWeapons = true;
								}
								theAircraft.Loadout = null;
								int loadoutID = Conversions.ToInteger(Misc.GetNodeByName(theNode8.ChildNodes[0].ChildNodes, "DBID").InnerText);
								DBFunctions.GetLoadout(ref theAircraft, loadoutID, excludeOptionalWeapons);
							}
							else
							{
								theAircraft.Loadout = Loadout.FromXML(theNode8.ChildNodes[0], concurrentDictionary_0, ref theAircraft, ref scenario_0);
							}
							theAircraft.Kinematics.DetermineReserveFuelQty(Deserializing: true);
							break;
						case "ParentGroup":
							theAircraft._ParentGroup_ID = theNode8.InnerText;
							break;
						case "TerrainFollowingType":
							theAircraft.TerrainFollowingType = (TerrainFollowMode)Conversions.ToInteger(theNode8.InnerText);
							break;
						case "AirborneTime":
						case "AbnTime":
							theAircraft.AirborneTime = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "CH":
						case "CurrentHeading":
							theAircraft.CurrentHeading = XmlConvert.ToSingle(theNode8.InnerText);
							break;
						case "IsAD":
						case "IsAutoDetectable":
							((ActiveUnit)theAircraft).set_IsAutoDetectable((Side)null, Misc.ParseBool(theNode8.InnerText));
							break;
						}
					}
					else
					{
						theAircraft.LastReportedInfoFromXMLField(theNode8.Name, theNode8.InnerText);
					}
				}
				float maximumAltitude = theAircraft.Kinematics.GetMaximumAltitude();
				if (theAircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > maximumAltitude)
				{
					theAircraft.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, maximumAltitude);
				}
				if (theAircraft.DesiredAltitude > maximumAltitude)
				{
					theAircraft.DesiredAltitude = maximumAltitude;
				}
				if (!bool_7 && theArray.Length > 0)
				{
					try
					{
						Sensor[] array = theArray;
						foreach (Sensor sensor2 in array)
						{
							Sensor[] sensors_Cached = theAircraft.Sensors_Cached;
							foreach (Sensor sensor3 in sensors_Cached)
							{
								if (sensor3.DBID == sensor2.DBID && sensor2.IsActive())
								{
									sensor3.GoActive();
								}
							}
						}
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception ex6 = ex5;
						ex6?.Data.Add("Error at 200019", ex6.Message);
						GameGeneral.WriteExceptionsToLog(ex6);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				return theAircraft;
			}
			return (Aircraft)concurrentDictionary_0[text];
			end_IL_0021:;
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 100350", "");
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
		Aircraft result3 = default(Aircraft);
		return result3;
	}

	public override float Attitude_Pitch_Derived()
	{
		if (!IsHelicopter)
		{
			return base.Attitude_Pitch_Derived();
		}
		float num = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - base.Altitude_old;
		if (num > 0f)
		{
			return 5f;
		}
		if (num < 0f)
		{
			return -5f;
		}
		return 0f;
	}

	public override void Determine_IsMCMPlatform()
	{
		if (Type != _AircraftType.MCM)
		{
			Loadout loadout = Loadout;
			if (loadout == null || loadout.Role != Loadout.LoadoutRole.MineSweeping)
			{
				IsMCMPlatform_ThisPulse = 0;
				return;
			}
		}
		IsMCMPlatform_ThisPulse = 1;
	}

	public override void Determine_IsMineLayingPlatform()
	{
		Loadout loadout = Loadout;
		if (loadout != null && loadout.Role == Loadout.LoadoutRole.NavalMineLaying)
		{
			IsMineLayingPlatform_ThisPulse = 1;
		}
		else
		{
			IsMineLayingPlatform_ThisPulse = 0;
		}
	}

	public override bool IsHostedInExposedSpace()
	{
		if (!IsOperating())
		{
			if (AirOps.HostAirFacility != null)
			{
				if (AirOps.HostAirFacility.IsOpenAirFacility)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public override void PostDeserializationHousekeeping_General(ref Scenario theScen, ConcurrentDictionary<string, ScenarioObject> theDictionary, List<ActiveUnit> DiscardList, bool GameIsRunning)
	{
		try
		{
			base.PostDeserializationHousekeeping_General(ref theScen, theDictionary, DiscardList, GameIsRunning);
			if (DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
			{
				ActiveUnit_DockingOps.PostDeserializationHousekeeping(DockingOps, ref theScen, theDictionary, GameIsRunning);
			}
			if (AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Parked && AirOps.CurrentHostUnit == null && AirOps.HostAirFacility == null && DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
			{
				((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Units.Remove(this);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100351", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DisconnectTankerClients(string reason)
	{
		try
		{
			if (!IsTanker)
			{
				return;
			}
			string text = "";
			if (Operators.CompareString(Name, UnitClass, false) != 0)
			{
				text = " (" + UnitClass + ")";
			}
			AddMessage(Name + text + " " + reason + " , clients will be disconnected from tanker.", Name + " will disconnect clients!", LoggedMessage.MessageType.UnitAIEmergency, 0, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
			List<string> list = new List<string>();
			list.AddRange(aircraft_AirOps_0.RefuellingQueue.Keys);
			if (list.Count > 0)
			{
				AddMessage(Name + text + " " + reason + " , clients will be dropped from refuelling queue.", Name + " will drop refuelling queue.", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
				foreach (string item in list)
				{
					if (ParentScen.ActiveUnits.ContainsKey(item))
					{
						Aircraft aircraft = (Aircraft)ParentScen.ActiveUnits[item];
						aircraft.aircraft_AirOps_0.DisconnectFromTanker();
					}
					else
					{
						aircraft_AirOps_0.RefuellingQueue.Remove(item);
					}
				}
			}
			List<KeyValuePair<string, Aircraft_AirOps.GEnum0>> list2 = new List<KeyValuePair<string, Aircraft_AirOps.GEnum0>>();
			list2.AddRange(aircraft_AirOps_0.A2AR_Connections);
			if (list2.Count <= 0)
			{
				return;
			}
			AddMessage(Name + text + " " + reason + " , clients will be disconnected from tanker.", Name + " will disconnect clients!", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
			foreach (KeyValuePair<string, Aircraft_AirOps.GEnum0> item2 in list2)
			{
				if (ParentScen.ActiveUnits.ContainsKey(item2.Key))
				{
					Aircraft aircraft = (Aircraft)ParentScen.ActiveUnits[item2.Key];
					aircraft.aircraft_AirOps_0.DisconnectFromTanker();
					if (aircraft.IsOnActiveMission && (aircraft.IsGroupLead() || !aircraft.IsGroupMember()))
					{
						List<Mission> theSelectedMissions = null;
						if (AssignedMissionOrPackage() != null)
						{
							theSelectedMissions = new List<Mission> { AssignedMissionOrPackage() };
						}
						Aircraft_AirOps aircraft_AirOps = aircraft.aircraft_AirOps_0;
						GeoPoint intermediateTargetPoint = aircraft.AI.IntermediateTargetPointForRefuelCalcs();
						bool IsManual = false;
						ActiveUnit theSelectedTanker = null;
						string UserFeedback = "";
						bool IsRTB = ((ActiveUnit)aircraft).IsRTB;
						bool MissionPlanner_PostponedRefuelling = false;
						aircraft_AirOps.AttemptToScheduleRefuel(intermediateTargetPoint, Doctrine._UnderwayRefuelAndReplenishmentSelection.PickNearest, ref IsManual, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref IsRTB, ref MissionPlanner_PostponedRefuelling, Aircraft_AirOps.RefuelScheduleReason.RescheduleAfterDisconnect);
					}
				}
				else
				{
					aircraft_AirOps_0.A2AR_Connections.Remove(item2.Key);
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

	public override int IsAvailableForOps(ref string ReasonForNot)
	{
		if (Loadout == null)
		{
			return 4;
		}
		int result;
		if (Loadout.Role != Loadout.LoadoutRole.PackedForCargo)
		{
			if (DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
			{
				if (Loadout.Role == Loadout.LoadoutRole.Unavailable)
				{
					return 2;
				}
				if (Loadout.Role == Loadout.LoadoutRole.Reserve)
				{
					return 3;
				}
				_ActiveUnitWeaponState activeUnitWeaponState = Weaponry.IsWinchesterOrShotgun();
				if (activeUnitWeaponState != _ActiveUnitWeaponState.None && activeUnitWeaponState != _ActiveUnitWeaponState.IgnoreWinchesterAndShotgun)
				{
					return 1;
				}
				return 0;
			}
			result = 4;
		}
		else
		{
			result = 4;
		}
		return result;
	}

	public string QuickTurnaroundString()
	{
		if (Loadout == null)
		{
			return "-";
		}
		if (!Loadout.QuickTurnaround)
		{
			return "-";
		}
		int? elementState = Doctrine.GetElementState(Doctrine.DoctrineItem_E.QuickTurnAroundForAircraft);
		int? num = elementState;
		if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) != true)
		{
			num = elementState;
			if ((num.HasValue ? new bool?(num == 1) : ((bool?)null)) == true)
			{
				Loadout loadout = Loadout;
				if (!loadout.IsAAW && !loadout.IsSupportOrPatrol && !loadout.IsASW)
				{
					return "Disabled (Doctrine)";
				}
			}
			Aircraft_AirOps airOps = AirOps;
			if (!airOps.QuickTurnaround_Enabled)
			{
				return "-";
			}
			return "Enabled, " + Misc.Description(Loadout.QuickTurnaround_TimeofDay) + ": " + Conversions.ToString(airOps.QuickTurnaround_SortiesFlown) + " / " + Conversions.ToString(airOps.QuickTurnaround_SortiesTotal) + " sorties, " + Misc.TimeString((long)Math.Round(airOps.QuickTurnaround_AirborneTime_Flown), 0, ReturnNo: false, ReturnZero: true) + " / " + Misc.TimeString(Loadout.QuickTurnaround_AirborneTime * 60, 0, ReturnNo: true) + " flying time, " + Misc.TimeString(airOps.QuickTurnaround_TimePentalty * 60, 0, ReturnNo: true) + " downtime";
		}
		return "Disabled (Doctrine)";
	}

	private CommDevice[] method_16()
	{
		CommDevice[] array = new CommDevice[_Comms.Length - 1 + 1];
		if (_Comms.Length > 0)
		{
			Array.Copy(_Comms, array, _Comms.Length);
		}
		return array;
	}

	public override void SetThrottle(Throttle newThrottleSetting, float? SpecificDesiredSpeed = null)
	{
		try
		{
			if (newThrottleSetting == Throttle.Flank && !method_17())
			{
				newThrottleSetting = Throttle.Full;
			}
			if (!IsHelicopter && newThrottleSetting == Throttle.FullStop)
			{
				newThrottleSetting = Throttle.Loiter;
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
				if (SpecificDesiredSpeed.HasValue)
				{
					if (Kinematics.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && !Navigator.IsManouveringToFormationStation)
					{
						DesiredSpeed = Kinematics.GetMaximumSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (Throttle)Kinematics.ThrottlePreset, ValidateAndFixAltitude: false);
					}
					else
					{
						float? num = SpecificDesiredSpeed;
						float num2 = Kinematics.GetMaximumSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), newThrottleSetting, ValidateAndFixAltitude: false);
						bool? flag = ((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() > num2));
						bool? flag2 = (!flag) ?? flag;
						if (flag2 ?? true)
						{
							num = SpecificDesiredSpeed;
							num2 = Kinematics.GetMinimumSpeed((int)Math.Round(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), newThrottleSetting, ValidateAndFixAltitude: false);
							flag = (num.HasValue ? new bool?(num.GetValueOrDefault() < num2) : ((bool?)null));
							if (((!flag) ?? flag) == true && flag2.HasValue)
							{
								DesiredSpeed = SpecificDesiredSpeed.Value;
								ThrottleSetting = Kinematics.GetThrottleSuitableForThisSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), SpecificDesiredSpeed.Value);
								goto IL_0293;
							}
						}
						ThrottleSetting = Kinematics.GetThrottleSuitableForThisSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), SpecificDesiredSpeed.Value);
						num = SpecificDesiredSpeed;
						num2 = Kinematics.GetMaximumSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false);
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() > num2)) == true)
						{
							DesiredSpeed = Kinematics.GetMaximumSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false);
						}
					}
				}
				else
				{
					DesiredSpeed = Kinematics.GetMaximumSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false);
				}
			}
			goto IL_0293;
			IL_0293:
			RaiseEvent_ChangedThrottleSetting(this, ThrottleSetting);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100357", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	private bool method_17()
	{
		bool result = default(bool);
		try
		{
			AltBand[] altBands = Propulsion[0].AltBands;
			foreach (AltBand altBand in altBands)
			{
				if (altBand.Consumption_Flank.HasValue && altBand.Speed_Flank.HasValue)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100358", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float RangeToRefuelingDestinationUnit(double startLat, double startLon, ActiveUnit theDestination)
	{
		float num = 0f;
		Geopoint_Struct thePoint = new Geopoint_Struct(startLon, startLat);
		if (theDestination.HasRunwaysOrPads)
		{
			if (!IsHelicopter && !IsDrone())
			{
				Geopoint_Struct landingQueueAssemblyPoint = theDestination.AirOps.LandingQueueAssemblyPoint;
				float num2 = Math2.CalcDist(thePoint.Latitude, thePoint.Longitude, landingQueueAssemblyPoint.Latitude, landingQueueAssemblyPoint.Longitude);
				float num3 = Math2.CalcDist(theDestination.get_Latitude((GlobalVariables.BooleanObject)null), theDestination.get_Longitude((GlobalVariables.BooleanObject)null), landingQueueAssemblyPoint.Latitude, landingQueueAssemblyPoint.Longitude);
				num = num2 + num3;
			}
			else
			{
				num = Module_Unit.RangeToPoint_Horiz(theDestination, thePoint);
			}
		}
		else if (theDestination.IsAircraft && ((Aircraft)theDestination).IsTanker)
		{
			num = Module_Unit.RangeToPoint_Horiz(theDestination, thePoint);
			Geopoint_Struct thePoint2 = default(Geopoint_Struct);
			if (theDestination.Navigator.HasPlottedCourse())
			{
				thePoint2 = theDestination.Navigator.PlottedCourse.First().ToGeopoint_Struct();
				if (!thePoint2.HasZeroCoords && thePoint2.RangeToPoint_Horiz(thePoint.Longitude, thePoint.Latitude) > num)
				{
					float num4 = num;
					Aircraft_Kinematics kinematics = Kinematics;
					Aircraft_Navigator navigator = Navigator;
					bool theAltitude_TerrainFollowing = false;
					float num5 = num4 / (float)kinematics.GetMaximumSpeed(navigator.GetBingoFuelAltitude(ref theAltitude_TerrainFollowing), Navigator.GetBingoFuelThrottle(), ValidateAndFixAltitude: false) * theDestination.CurrentSpeed;
					float num6 = Module_Unit.RangeToPoint_Horiz(theDestination, thePoint2);
					if (num5 < num6)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(theDestination.get_Longitude((GlobalVariables.BooleanObject)null), theDestination.get_Latitude((GlobalVariables.BooleanObject)null), ref thePoint2.Longitude, ref thePoint2.Latitude, num5, Math2.CalcAzimuth(theDestination.get_Latitude((GlobalVariables.BooleanObject)null), theDestination.get_Longitude((GlobalVariables.BooleanObject)null), thePoint2.Latitude, thePoint2.Latitude));
					}
				}
			}
			else if (theDestination.AssignedMissionOrPackage() != null && theDestination.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support)
			{
				SupportMission supportMission = (SupportMission)theDestination.AssignedMissionOrPackage();
				if (supportMission.NavigationCourse.Count > 0)
				{
					thePoint2 = supportMission.NavigationCourse.OrderByDescending([SpecialName] (ReferencePoint rp) => rp.RangeToPoint_Horiz(thePoint.Longitude, thePoint.Latitude)).First().ToGeopoint_Struct();
				}
			}
			if (!thePoint2.HasZeroCoords)
			{
				num = thePoint2.RangeToPoint_Horiz(thePoint.Longitude, thePoint.Latitude);
			}
		}
		else
		{
			num = Module_Unit.RangeToPoint_Horiz(theDestination, thePoint);
		}
		return num;
	}

	public (_ActiveUnitFuelState, bool) IsBingoOrJoker_IsUsingTankerAsReference()
	{
		(_ActiveUnitFuelState, bool) result;
		try
		{
			Doctrine._FuelState? bingoJoker = Doctrine.BingoJoker;
			if (IsLighterThanAir)
			{
				return (_ActiveUnitFuelState.None, false);
			}
			if (IsDrone() && AutonomyLevel < DroneAutonomyLevel.FaultEventAdaptive && ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !((ActiveUnit_CommStuff)CommStuff).IsConnectedToSideNetwork)
			{
				return (_ActiveUnitFuelState.None, false);
			}
			Aircraft aircraft = null;
			bool? flag = null;
			ActiveUnit actualDestinationHost = AirOps.ActualDestinationHost;
			if (AirOps.Condition != Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel && AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Refuelling)
			{
				if (IsDrone() && AutonomyLevel < DroneAutonomyLevel.BattlespaceCognizant && !((ActiveUnit_CommStuff)CommStuff).IsConnectedToSideNetwork)
				{
					flag = false;
				}
				else if (ActiveMissionOrPackage() != null)
				{
					Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = Doctrine.get_UseReplenishment(ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
					byte? b = (byte?)useUnderwayRefuelAndReplenishment;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
					{
						b = (byte?)useUnderwayRefuelAndReplenishment;
						if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true && IsTanker)
						{
							flag = false;
						}
					}
					else if (!Navigator.IsOnAutoPlannerPlottedCourse)
					{
						int value;
						if (!IsGroupWingman())
						{
							value = 0;
						}
						else
						{
							ActiveUnit groupLead = ((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false).GroupLead;
							if (groupLead == null)
							{
								value = 0;
							}
							else
							{
								ActiveUnit_Navigator navigator = groupLead.Navigator;
								if (navigator != null)
								{
									if (navigator.IsOnAutoPlannerPlottedCourse)
									{
										goto IL_01f0;
									}
									value = 0;
								}
								else
								{
									value = 0;
								}
							}
						}
						flag = (byte)value != 0;
					}
				}
				goto IL_01f0;
			}
			aircraft = AirOps.A2AR_Destination;
			flag = true;
			goto IL_061f;
			IL_01f0:
			if (!flag.HasValue && CanRefuelOnAir)
			{
				bool flag2 = false;
				if (Type == _AircraftType.Tanker && ActiveMissionOrPackage() != null)
				{
					Mission._MissionClass missionClass = ActiveMissionOrPackage().MissionClass;
					if (missionClass != Mission._MissionClass.Strike)
					{
						flag2 = true;
					}
				}
				if (!flag2)
				{
					Aircraft_AirOps airOps = AirOps;
					bool IsManual = false;
					ActiveUnit ManuallySelectedUnit = null;
					string UserFeedback = "";
					List<Aircraft> potentialTankers = airOps.GetPotentialTankers(ref IsManual, ref ManuallySelectedUnit, MustBeAbleToReachItDirectly: true, null, ref UserFeedback);
					if (potentialTankers.Count != 0)
					{
						if (!IsOnReturnLeg)
						{
							if (!Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun && (!IsGroupMember() || ((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false).GroupLead == null || !((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun))
							{
								aircraft = potentialTankers.OrderBy([SpecialName] (Aircraft theTanker) => Module_Unit.RangeToUnit_Horiz_Angular(this, theTanker)).ElementAtOrDefault(0);
								byte? b = (byte?)bingoJoker;
								bool? flag3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 13));
								flag = ((((!flag3) ?? flag3) != true) ? (((RangeToUnit_Horiz(aircraft) < RangeToUnit_Horiz(actualDestinationHost)) & (this.get_IsBingoTowardsThisDestination(actualDestinationHost, (GeoPoint)null, (Doctrine._FuelState?)null) == _ActiveUnitFuelState.IsBingo)) ? new bool?(true) : new bool?(false)) : ((!((double)RangeToUnit_Horiz(aircraft) * 0.7 < (double)RangeToUnit_Horiz(actualDestinationHost))) ? new bool?(false) : new bool?(true)));
							}
							else
							{
								int value2;
								double num;
								if (Navigator.HasFlightPlan && Navigator.PlottedCourse.Count() > 0 && Navigator.PlottedCourse[Navigator.PlottedCourse.Count() - 1].Type == Waypoint.WaypointType.Land)
								{
									num = Module_Unit.RangeToPoint_Horiz(this, Navigator.PlottedCourse[0]);
									int num2 = Navigator.PlottedCourse.Count() - 1;
									for (int num3 = 1; num3 <= num2; num3++)
									{
										Waypoint waypoint;
										try
										{
											waypoint = Navigator.PlottedCourse[num3];
										}
										catch (Exception projectError)
										{
											ProjectData.SetProjectError(projectError);
											ProjectData.ClearProjectError();
											continue;
										}
										num += (double)(waypoint.Leg_Distance_Straight + waypoint.Leg_Distance_Turn);
									}
									value2 = 0;
								}
								else
								{
									num = RangeToUnit_Horiz(actualDestinationHost);
									value2 = 0;
								}
								flag = (byte)value2 != 0;
								aircraft = potentialTankers[0];
								if (potentialTankers.Count == 1)
								{
									if (((double)RangeToUnit_Horiz(potentialTankers[0]) < num) & (this.get_IsBingoTowardsThisDestination(actualDestinationHost, (GeoPoint)null, (Doctrine._FuelState?)null) == _ActiveUnitFuelState.IsBingo))
									{
										flag = true;
									}
								}
								else
								{
									double num4 = RangeToUnit_Horiz(potentialTankers[0]);
									if (num4 < num)
									{
										flag = true;
									}
									foreach (Aircraft item in potentialTankers)
									{
										if (item != potentialTankers[0])
										{
											double num5 = RangeToUnit_Horiz(item);
											if (!(num5 > num) && num5 < num4)
											{
												aircraft = item;
												flag = true;
											}
										}
									}
								}
								if (Navigator.HasFlightPlan)
								{
									Waypoint? waypoint2 = Navigator.PlottedCourse.FirstOrDefault();
									if (waypoint2 != null && waypoint2.Type == Waypoint.WaypointType.Refuel)
									{
										goto IL_061f;
									}
								}
								float num6 = (float)this.get_FuelEndurance(ThrottleSetting, (AltBand)null, (float?)CurrentSpeed, (float?)this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) * CurrentSpeed / 3600f;
								num = RangeToUnit_Horiz(actualDestinationHost);
								if ((double)num6 - num > 50.0)
								{
									flag = false;
								}
							}
						}
						else
						{
							flag = false;
						}
					}
					else
					{
						flag = false;
					}
				}
			}
			goto IL_061f;
			IL_061f:
			if (flag != true)
			{
				_ActiveUnitFuelState activeUnitFuelState = this.get_IsBingoTowardsThisDestination(actualDestinationHost, (GeoPoint)null, bingoJoker);
				if (activeUnitFuelState == _ActiveUnitFuelState.IsBingo || activeUnitFuelState == _ActiveUnitFuelState.IsJoker)
				{
					Aircraft_AirOps airOps2 = AirOps;
					if (airOps2.A2AR_Destination != null)
					{
						airOps2.DisconnectFromTanker();
					}
					if (AirOps.Condition != Aircraft_AirOps._AirOpsCondition.EmergencyLanding && FuelState_DistanceToBase <= EMERGENCY_LANDING_DISTANCE_NM)
					{
						float num7 = (float)this.get_FuelEndurance(ThrottleSetting, (AltBand)null, (float?)CurrentSpeed, (float?)this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) * CurrentSpeed / 3600f;
						if ((double)FuelState_DistanceToBase >= (double)num7 * 1.5)
						{
							if (!Navigator.HasPlottedCourse())
							{
								if (GlobalVariables.AI_REWORK)
								{
									AI.StatusRelatedEvents.method_0(manuallyOrdered: false, _ActiveUnitStatus.RTB, groupMembersRTB: false, _ActiveUnitStatus.Unassigned, detachFromGroup: true, clearPlottedCourse: true, Aircraft_AirOps._AirOpsCondition.EmergencyLanding);
								}
								else
								{
									AirOps.AttemptToRTB(ManuallyOrdered: false, _ActiveUnitStatus.RTB, GroupMembersRTB: false, _ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
									AirOps.Condition = Aircraft_AirOps._AirOpsCondition.EmergencyLanding;
								}
							}
							else if (Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.LandingMarshal || Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.Land)
							{
								if (GlobalVariables.AI_REWORK)
								{
									AI.StatusRelatedEvents.method_0(manuallyOrdered: false, _ActiveUnitStatus.RTB, groupMembersRTB: false, _ActiveUnitStatus.Unassigned, detachFromGroup: true, clearPlottedCourse: true, Aircraft_AirOps._AirOpsCondition.EmergencyLanding);
								}
								else
								{
									AirOps.AttemptToRTB(ManuallyOrdered: false, _ActiveUnitStatus.RTB, GroupMembersRTB: false, _ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
									AirOps.Condition = Aircraft_AirOps._AirOpsCondition.EmergencyLanding;
								}
							}
						}
					}
				}
				return (activeUnitFuelState, false);
			}
			return (this.get_IsBingoTowardsThisDestination((ActiveUnit)aircraft, (GeoPoint)null, bingoJoker), true);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200329", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = (_ActiveUnitFuelState.None, false);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void forceMaxInternalFuelCapacity(float theQty)
	{
		FuelRec fuelRec = _Fuel[0];
		fuelRec.CurrentQuantity = theQty;
		fuelRec.MaxQuantity = (int)Math.Round(theQty);
	}

	public void FuelCapacitySet(float theQty)
	{
		try
		{
			FuelRec fuelRec = _Fuel[0];
			if (theQty < (float)fuelRec.MaxQuantity)
			{
				fuelRec.CurrentQuantity = theQty;
				theQty = 0f;
			}
			else
			{
				fuelRec.CurrentQuantity = fuelRec.MaxQuantity;
				theQty -= (float)fuelRec.MaxQuantity;
			}
			if (Loadout == null)
			{
				return;
			}
			WeaponRec[] weapons = Loadout.Weapons;
			foreach (WeaponRec weaponRec in weapons)
			{
				if (!weaponRec.get_ReferenceWeapon(ParentScen).IsFuelTank)
				{
					continue;
				}
				FuelRec fuelRec2 = weaponRec.get_ReferenceWeapon(ParentScen).Fuel_ReadOnly[0];
				FuelRec fuelRec3 = new FuelRec(0, (short)fuelRec2.FuelType);
				int currentLoad = weaponRec.CurrentLoad;
				fuelRec3.MaxQuantity = fuelRec2.MaxQuantity * currentLoad;
				if (theQty < (float)fuelRec3.MaxQuantity)
				{
					if (theQty > 0f)
					{
						fuelRec2.CurrentQuantity = theQty / (float)currentLoad;
						theQty = 0f;
					}
					else
					{
						fuelRec2.CurrentQuantity = 0f;
					}
				}
				else
				{
					fuelRec2.CurrentQuantity = fuelRec2.MaxQuantity;
					theQty -= (float)fuelRec3.MaxQuantity;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101227", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal List<WeaponRec> FetchJettisonableFuelTanks()
	{
		List<WeaponRec> list = new List<WeaponRec>();
		WeaponRec[] weapons = Loadout.Weapons;
		foreach (WeaponRec weaponRec in weapons)
		{
			if (weaponRec.get_ReferenceWeapon(ParentScen).IsFuelTank)
			{
				list.Add(weaponRec);
			}
		}
		return list;
	}

	internal static NATO_UAS_ClassificationEnum UAVSizeClassification(int theWeight)
	{
		if (theWeight >= 10)
		{
			if (theWeight >= 15)
			{
				if (theWeight < 150)
				{
					return NATO_UAS_ClassificationEnum.Class1_Small;
				}
				if (theWeight < 600)
				{
					return NATO_UAS_ClassificationEnum.Class2;
				}
				return NATO_UAS_ClassificationEnum.Class3;
			}
			return NATO_UAS_ClassificationEnum.Class1_Mini;
		}
		return NATO_UAS_ClassificationEnum.Class1_Micro;
	}

	internal bool isUAVSizeClass1AndHasDBProvidedEndurance()
	{
		NATO_UAS_ClassificationEnum nATO_UAS_ClassificationEnum = UAVSizeClassification(MaxWeight);
		if (TotalEndurance > 0)
		{
			if (nATO_UAS_ClassificationEnum != NATO_UAS_ClassificationEnum.Class1_Micro && nATO_UAS_ClassificationEnum != NATO_UAS_ClassificationEnum.Class1_Mini)
			{
				return nATO_UAS_ClassificationEnum == NATO_UAS_ClassificationEnum.Class1_Small;
			}
			return true;
		}
		return false;
	}

	private float method_18(bool bool_7, bool bool_8, int int_5)
	{
		float num = 3.0479999f;
		switch (Category)
		{
		default:
			num = ((!bool_7) ? ((!bool_8) ? ((!TerrainFollowingCapability && !TerrainAvoidanceCapability) ? (num * 6f) : ((int_5 < 8) ? (num * 2f) : (num * 4f))) : ((!TerrainFollowingCapability && !TerrainAvoidanceCapability) ? (num * 6f) : ((int_5 < 8) ? (num * 2f) : (num * 4f)))) : (bool_8 ? (TerrainFollowingCapability ? (num * 4f) : ((!TerrainAvoidanceCapability) ? (num * 10f) : (num * 6f))) : ((!TerrainFollowingCapability) ? ((!TerrainAvoidanceCapability) ? (num * 20f) : (num * 6f)) : (num * 4f))));
			break;
		case _AircraftCategory.Tiltrotor:
			if (ThrottleSetting > Throttle.Loiter)
			{
				if (bool_7)
				{
					num = ((!bool_8) ? ((!TerrainFollowingCapability) ? (TerrainAvoidanceCapability ? (num * 6f) : (num * 10f)) : (num * 4f)) : (TerrainFollowingCapability ? (num * 4f) : (TerrainAvoidanceCapability ? (num * 6f) : (num * 10f))));
				}
				else if (!bool_8)
				{
					num = ((int_5 < 7) ? (num * 2f) : (num * 4f));
				}
				else if (int_5 >= 6)
				{
					num *= 4f;
				}
				else if (int_5 >= 8)
				{
					num *= 3f;
				}
			}
			break;
		case _AircraftCategory.Helicopter:
			if (ThrottleSetting > Throttle.Loiter)
			{
				if (bool_7)
				{
					num = ((!bool_8) ? (TerrainFollowingCapability ? (num * 4f) : (TerrainAvoidanceCapability ? (num * 6f) : (num * 10f))) : ((int_5 < 7) ? ((int_5 < 5) ? (num * 2f) : (num * 3f)) : (num * 4f)));
				}
				else if (!bool_8)
				{
					num = ((int_5 < 7) ? (num * 2f) : (num * 4f));
				}
				else if (int_5 >= 6)
				{
					num *= 4f;
				}
				else if (int_5 >= 8)
				{
					num *= 3f;
				}
			}
			break;
		}
		return num;
	}

	public Aircraft(ref Scenario theScen, string theGUID = null)
		: base(ref theScen, theGUID)
	{
		G_Tolerance = 45f;
		ShouldDropSonobuoysOnThisPulse = false;
		Armor_Cockpit = GlobalVariables.ArmorRating.None;
		Armor_Fuselage = GlobalVariables.ArmorRating.None;
		Armor_Powerplant = GlobalVariables.ArmorRating.None;
		FuelState_RemainingFuelToBingo = 0f;
		FuelState_RemainingFuelToJoker = 0f;
		VisibilityForward = CockpitVisibility.Excellent;
		VisibilitySideways = CockpitVisibility.Excellent;
		VisibilityAft = CockpitVisibility.Excellent;
		ActiveUnit theUnit = this;
		aircraft_Navigator_0 = new Aircraft_Navigator(ref theUnit);
		theUnit = this;
		aircraft_AI_0 = new Aircraft_AI(ref theUnit);
		theUnit = this;
		aircraft_Kinematics_0 = new Aircraft_Kinematics(ref theUnit);
		Cargo_Crew = 0;
		Cargo_Area = 0f;
		Cargo_Type = CargoType.NoCargo;
		Cargo_Mass = 0f;
		Cargo_ParadropCapable = false;
		IsAircraft = true;
		UnitType = GlobalVariables.ActiveUnitType.Aircraft;
		theUnit = this;
		aircraft_AirOps_0 = new Aircraft_AirOps(ref theUnit);
	}

	public static int smethod_2(int theLength)
	{
		if (theLength < 20)
		{
			return 100;
		}
		if (theLength < 50)
		{
			return 200;
		}
		if (theLength < 100)
		{
			return 400;
		}
		if (theLength < 120)
		{
			return 800;
		}
		if (theLength < 150)
		{
			return 1600;
		}
		return 3200;
	}

	public override void Destroy(bool ScenEditAction, bool IsAimpointFacility, bool DestroyUnitNow, string theReason, string WhatCausedIt = null, bool RegisterAsLosses = true)
	{
		try
		{
			IsBeingDestroyed = true;
			AirOps.HostAirFacility = null;
			if (AirOps.Condition == Aircraft_AirOps._AirOpsCondition.OffloadingFuel)
			{
				List<KeyValuePair<string, Aircraft_AirOps.GEnum0>> list = new List<KeyValuePair<string, Aircraft_AirOps.GEnum0>>();
				list.AddRange(aircraft_AirOps_0.A2AR_Connections);
				foreach (KeyValuePair<string, Aircraft_AirOps.GEnum0> item in list)
				{
					if (ParentScen.ActiveUnits.ContainsKey(item.Key))
					{
						ActiveUnit activeUnit = ParentScen.ActiveUnits[item.Key];
						if (activeUnit != null)
						{
							((Aircraft)activeUnit).aircraft_AirOps_0.DisconnectFromTanker();
						}
					}
				}
				List<string> list2 = new List<string>();
				list2.AddRange(aircraft_AirOps_0.RefuellingQueue.Keys);
				foreach (string item2 in list2)
				{
					aircraft_AirOps_0.RefuellingQueue.Remove(item2);
				}
			}
			foreach (ActiveUnit activeUnits_ in ParentScen.ActiveUnits_List)
			{
				if (activeUnits_ != null)
				{
					if (activeUnits_.AirOps.LandingQueue_ReadOnly.Contains(this))
					{
						activeUnits_.AirOps.LandingQueue_RemoveAircraft(this);
					}
					if (activeUnits_.IsAircraft && ((Aircraft)activeUnits_).AirOps.RefuellingQueue != null && ((Aircraft)activeUnits_).AirOps.RefuellingQueue.Count > 0)
					{
						((Aircraft)activeUnits_).AirOps.RefuellingQueue.Remove(ObjectID);
					}
				}
			}
			base.Destroy(ScenEditAction, IsAimpointFacility, DestroyUnitNow, theReason, WhatCausedIt);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100367", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void Teleport(ref Scenario theScen, double Destination_Lon, double Destination_Lat)
	{
		base.Teleport(ref theScen, Destination_Lon, Destination_Lat);
		Kinematics.ExportLocationEvent("Teleport");
	}

	public override void DoTypeSpecificActions(float elapsedTime, ref LockRandom theRNG)
	{
		AirOps.DoAirOps(elapsedTime);
	}

	public override bool AttemptToSetNewAssignedHost(ActiveUnit DestinationUnit, bool ForceRTB = false, bool OutputFeedback = false)
	{
		if (DestinationUnit == this)
		{
			return false;
		}
		bool flag = !DestinationUnit.IsGroup;
		bool flag2 = false;
		bool flag3 = false;
		if (DestinationUnit.IsGroup)
		{
			if (((Group)DestinationUnit).Type == Group.GroupType.AirBase)
			{
				flag3 = true;
			}
			else
			{
				flag2 = true;
			}
		}
		if (IsDrone() && ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !((ActiveUnit_CommStuff)CommStuff).IsConnectedToSideNetwork)
		{
			if (AutonomyLevel < DroneAutonomyLevel.BattlespaceCognizant)
			{
				string text = "Failed to set " + DestinationUnit.Name + " as the new base for " + Name + ". Reason: This is a disconnected drone with insufficient autonomy level.";
				if (OutputFeedback)
				{
					GameGeneral.SendMessageBoxToUI(text, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false), "Failed to re-base " + Name, GameGeneral.MessageBoxMessageType.Warning);
				}
				ParentScen.AddMessage(text, "Failed to re-base " + Name, LoggedMessage.MessageType.DockingOps, 5, ObjectID, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false));
				return false;
			}
			if (flag && !flag3 && AutonomyLevel < DroneAutonomyLevel.FullyAutonomous)
			{
				string text2 = "Failed to set " + DestinationUnit.Name + " as the new base for " + Name + ". Reason: The unit is a disconnected drone with insufficient autonomy level.";
				if (OutputFeedback)
				{
					GameGeneral.SendMessageBoxToUI(text2, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false), "Failed to re-base " + Name, GameGeneral.MessageBoxMessageType.Warning);
				}
				ParentScen.AddMessage(text2, "Failed to re-base " + Name, LoggedMessage.MessageType.DockingOps, 5, ObjectID, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false));
				return false;
			}
		}
		string text3 = "";
		if (Operators.CompareString(Name, UnitClass, false) != 0)
		{
			text3 = " (" + UnitClass + ")";
		}
		if (!flag && !flag3)
		{
			if (flag2)
			{
				Module_Unit.Unit unit = null;
				foreach (ActiveUnit value in ((Group)DestinationUnit).Units.Values)
				{
					if (AirOps.ThisUnitCanHostMe(value, HumanFeedbackNeeded: false).ResponseBoolean)
					{
						AirOps.set_AssignedHostUnit(PickNewAssignedHost: false, value);
						unit = value;
						break;
					}
				}
				if (unit == null)
				{
					ParentScen.AddMessage("Failed to set " + DestinationUnit.Name + " as the new base for " + Name + text3, Name + " failed to set new base", LoggedMessage.MessageType.AirOps, 5, ObjectID, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
					return false;
				}
				ParentScen.AddMessage(DestinationUnit.Name + " is now the base for " + Name + text3, Name + " has new base", LoggedMessage.MessageType.AirOps, 5, ObjectID, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
				return true;
			}
			return false;
		}
		(bool, string) tuple = AirOps.ThisUnitCanHostMe(DestinationUnit, HumanFeedbackNeeded: true);
		if (tuple.Item1)
		{
			AirOps.set_AssignedHostUnit(PickNewAssignedHost: false, DestinationUnit);
			if (ForceRTB)
			{
				AI.ReturnToBase(1f);
			}
			ParentScen.AddMessage(DestinationUnit.Name + " is now the base for " + Name + text3, Name + " has new base", LoggedMessage.MessageType.AirOps, 5, ObjectID, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
			return true;
		}
		string text4 = "Failed to set " + DestinationUnit.Name + " as the new base for " + Name + text3 + ". Reason: " + tuple.Item2;
		if (OutputFeedback)
		{
			GameGeneral.SendMessageBoxToUI(text4, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false), "Failed to re-base " + Name, GameGeneral.MessageBoxMessageType.Warning);
		}
		ParentScen.AddMessage(text4, Name + " failed to set new base", LoggedMessage.MessageType.AirOps, 5, ObjectID, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
		return false;
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
					goto IL_009b;
				}
				Patrol patrol = (Patrol)ActiveMissionOrPackage();
				Geopoint_Struct geopoint_Struct = new Geopoint_Struct(theLon, theLat);
				if (!((Module_Unit.Unit)this).get_IsInsideThisArea(patrol.ProsecutionArea, ParentScen, UseCache: true) || GeoPoint.IsInsideThisArea(geopoint_Struct.Latitude, geopoint_Struct.Longitude, patrol.ProsecutionArea))
				{
					goto IL_009b;
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
			goto end_IL_0001;
			IL_009b:
			if (CheckDistanceToNoNavZones)
			{
				CheckNoNavZones = DistanceToNearestNoNavZone();
			}
			if ((!CheckNoNavZones && !IsPathfindingQuery) || !IsInsideNoNavZones(theLat, theLon, ProximityThreshold_Deg))
			{
				CheckNoNavZones = false;
				CheckForMines = false;
				result = true;
			}
			else
			{
				CheckNoNavZones = true;
				CheckForMines = false;
				UserFeedback = "The point is inside a No-Nav Zone.";
				result = false;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200284", ex2.Message);
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

	internal bool IsParked()
	{
		return AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Parked;
	}

	public override bool IsParkedAndReady()
	{
		if (AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Parked)
		{
			return AirOps.ConditionTimer == 0f;
		}
		return false;
	}

	internal bool IsReadyForTakeOff()
	{
		if (AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Parked && AirOps.ConditionTimer == 0f)
		{
			return true;
		}
		if (AirOps.Condition == Aircraft_AirOps._AirOpsCondition.HoldingForAvailableRunway)
		{
			return true;
		}
		if (AirOps.Condition == Aircraft_AirOps._AirOpsCondition.HoldingForAvailableTransit)
		{
			return true;
		}
		return false;
	}

	public override bool IsParkedAndReadying()
	{
		if (!((AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Parked) | (AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying)))
		{
			return false;
		}
		return AirOps.ConditionTimer > 0f;
	}

	public override bool IsOperating()
	{
		bool result;
		try
		{
			int num;
			switch (aircraft_AirOps_0.Condition)
			{
			default:
				num = 0;
				goto IL_007b;
			case Aircraft_AirOps._AirOpsCondition.Parked:
			case Aircraft_AirOps._AirOpsCondition.TaxyingToTakeOff:
			case Aircraft_AirOps._AirOpsCondition.TaxyingToPark:
			case Aircraft_AirOps._AirOpsCondition.TakingOff:
			case Aircraft_AirOps._AirOpsCondition.Landing_PostTouchdown:
			case Aircraft_AirOps._AirOpsCondition.Readying:
			case Aircraft_AirOps._AirOpsCondition.HoldingForAvailableTransit:
			case Aircraft_AirOps._AirOpsCondition.HoldingForAvailableRunway:
			case Aircraft_AirOps._AirOpsCondition.PreparingToLaunch:
			case Aircraft_AirOps._AirOpsCondition.TaxyingToFlightDeck:
				num = 0;
				goto IL_007b;
			case Aircraft_AirOps._AirOpsCondition.Airborne:
			case Aircraft_AirOps._AirOpsCondition.Landing_PreTouchdown:
			case Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue:
			case Aircraft_AirOps._AirOpsCondition.RTB:
			case Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel:
			case Aircraft_AirOps._AirOpsCondition.Refuelling:
			case Aircraft_AirOps._AirOpsCondition.OffloadingFuel:
			case Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar:
			case Aircraft_AirOps._AirOpsCondition.EmergencyLanding:
			case Aircraft_AirOps._AirOpsCondition.const_19:
			case Aircraft_AirOps._AirOpsCondition.BVRCrank:
			case Aircraft_AirOps._AirOpsCondition.Dogfight:
			case Aircraft_AirOps._AirOpsCondition.TransferringCargo:
			case Aircraft_AirOps._AirOpsCondition.BVRDrag:
			case Aircraft_AirOps._AirOpsCondition.HoldingPattern_CommsLost:
				{
					result = true;
					break;
				}
				IL_007b:
				result = (byte)num != 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
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

	public override void Fuel_Subtract(float theQuantity, FuelRec._FuelType theType)
	{
		try
		{
			if (theQuantity == 0f)
			{
				return;
			}
			float num = theQuantity;
			foreach (FuelRec item in Fuel_ReadOnly)
			{
				if (num == 0f)
				{
					break;
				}
				if (Operators.CompareString(item.ObjectID, _Fuel[0].ObjectID, false) != 0 && item.FuelType == theType)
				{
					if (item.CurrentQuantity > num)
					{
						item.SubtractFuel(num);
						num = 0f;
					}
					else
					{
						num -= item.CurrentQuantity;
						item.CurrentQuantity = 0f;
					}
				}
			}
			if (num == 0f)
			{
				return;
			}
			FuelRec fuelRec = _Fuel[0];
			if (fuelRec.CurrentQuantity > num)
			{
				fuelRec.SubtractFuel(num);
				return;
			}
			string text = "";
			if (Operators.CompareString(Name, UnitClass, false) != 0)
			{
				text = " (" + UnitClass + ")";
			}
			double TotalCurrent = 0.0;
			double TotalMax = 0.0;
			FuelPercent(ref TotalCurrent, ref TotalMax, MissionFuel: false);
			AddMessage(Name + text + " has run out of fuel and crashed!", Name + " has ditched!", LoggedMessage.MessageType.UnitLost, 1, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
			ParentScen.DestroyThisUnit(this, "Out of fuel, crashed.", "Out of Fuel");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100370", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void Fuel_Add(float theQuantity, FuelRec._FuelType theType)
	{
		try
		{
			float num = theQuantity;
			FuelRec fuelRec = _Fuel[0];
			float num2 = (float)fuelRec.MaxQuantity - fuelRec.CurrentQuantity;
			if (num2 > num)
			{
				fuelRec.AddFuel(num);
				num = 0f;
			}
			else
			{
				fuelRec.CurrentQuantity = fuelRec.MaxQuantity;
				num -= num2;
			}
			if (num == 0f || Loadout == null)
			{
				return;
			}
			WeaponRec[] weapons = Loadout.Weapons;
			foreach (WeaponRec weaponRec in weapons)
			{
				if (weaponRec.get_ReferenceWeapon(ParentScen).IsFuelTank && num > 0f)
				{
					FuelRec fuelRec2 = weaponRec.get_ReferenceWeapon(ParentScen).Fuel_ReadOnly[0];
					FuelRec fuelRec3 = new FuelRec(0, (short)fuelRec2.FuelType);
					int currentLoad = weaponRec.CurrentLoad;
					fuelRec3.CurrentQuantity = fuelRec2.CurrentQuantity * (float)currentLoad;
					fuelRec3.MaxQuantity = fuelRec2.MaxQuantity * currentLoad;
					num2 = (float)fuelRec3.MaxQuantity - fuelRec3.CurrentQuantity;
					if (num2 > num)
					{
						fuelRec3.CurrentQuantity += num;
						num = 0f;
					}
					else
					{
						fuelRec3.CurrentQuantity = fuelRec3.MaxQuantity;
						num -= num2;
					}
					fuelRec2.CurrentQuantity = fuelRec3.CurrentQuantity / (float)currentLoad;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100371", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void DoFuelConsumption(float elapsedTime)
	{
		try
		{
			if ((AirborneTime > 0f) & !IsParked())
			{
				if (Propulsion.Where([SpecialName] (Engine theE) => theE.Status == PlatformComponent._ComponentStatus.Operational).Count() == 0)
				{
					AddMessage(Name + " (" + UnitClass + ") has no functioning engines and is being abandoned!", Name + " bailing out!", LoggedMessage.MessageType.UnitLost, 0, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
					ParentScen.DestroyThisUnit(this, "No functioning engines, crashed.", "Weapon Interaction");
				}
				float theQuantity = FuelConsumption(ThrottleSetting, null, (int)Math.Round(DesiredSpeed), this.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue), BingoFuelCheck: false, ReserveFuelQtyCalc: false, CombatRadiusCheck: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false) * elapsedTime;
				Fuel_Subtract(theQuantity, FuelRec._FuelType.AviationFuel);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100372", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public float DamageThresholdForAbort()
	{
		switch (Type)
		{
		default:
			return 0.1f;
		case _AircraftType.CAS:
			return 0.5f;
		case _AircraftType.Fighter:
		case _AircraftType.Attack:
			return 0.3f;
		}
	}

	internal List<WeaponRec> FetchJettisonable(Weapon._WeaponType OrdnanceType)
	{
		if (Information.IsNothing((object)Loadout))
		{
			return null;
		}
		List<WeaponRec> list = new List<WeaponRec>();
		if (OrdnanceType == Weapon._WeaponType.DropTank)
		{
			WeaponRec[] weapons = Loadout.Weapons;
			foreach (WeaponRec weaponRec in weapons)
			{
				if (weaponRec.get_ReferenceWeapon(ParentScen).IsFuelTank && weaponRec.CurrentLoad > 0)
				{
					list.Add(weaponRec);
				}
			}
		}
		return list;
	}

	private int method_19()
	{
		int num = Loadout.PayloadWeight;
		switch (Loadout.Role)
		{
		case Loadout.LoadoutRole.Cargo:
			num = (int)Math.Round(1000f * CargoHostHelper.GetCurrentLoadTotalMass(this, OnboardCargo));
			break;
		case Loadout.LoadoutRole.Paratroopers:
		case Loadout.LoadoutRole.Troop_Transport:
		{
			float currentLoadTotalCrewSpace = CargoHostHelper.GetCurrentLoadTotalCrewSpace(this, OnboardCargo);
			num = ((currentLoadTotalCrewSpace > 0f) ? ((int)Math.Round((float)num * currentLoadTotalCrewSpace / GetCargo_Crew())) : 0);
			break;
		}
		}
		return num;
	}

	public override float FuelConsumption(Throttle theThrottleSetting, AltBand theAltBand, float? theSpeed, float? theAltitude, bool BingoFuelCheck, bool ReserveFuelQtyCalc, bool CombatRadiusCheck, bool ValidateThrottleSelection, bool FlightplanFuelEstimate)
	{
		AltBand altBand = null;
		AltBand altBand2 = null;
		float result;
		if (Propulsion.Count != 0)
		{
			try
			{
				float num;
				bool flag = default(bool);
				float num2 = default(float);
				float num3;
				if (isUAVSizeClass1AndHasDBProvidedEndurance())
				{
					result = UAVSizeClass1FixedFuelConsumption;
				}
				else
				{
					PooledList<Engine> pooledList = new PooledList<Engine>(Pools<Engine>.Local);
					foreach (Engine item in Propulsion)
					{
						if (item.Status == PlatformComponent._ComponentStatus.Operational)
						{
							pooledList.Add(item);
						}
					}
					if (pooledList.Count != 0)
					{
						Engine engine = pooledList[0];
						pooledList.Dispose();
						if (engine.AltBands.Length != 0)
						{
							altBand = ((theAltBand != null) ? theAltBand : ((!theAltitude.HasValue) ? Kinematics.GetCurrentAltBand(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ValidateAndFixAltitude: false) : Kinematics.GetCurrentAltBand_CurrentAltitude(theAltitude.Value, null, ValidateAndFixAltitude: false)));
							if (altBand == null)
							{
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								throw new Exception();
							}
							switch (theThrottleSetting)
							{
							default:
								result = 0f;
								goto end_IL_0016;
							case Throttle.FullStop:
								if (altBand.Speed_Full.HasValue)
								{
									num = altBand.Consumption_Full.Value;
									flag = true;
									break;
								}
								throw new Exception("Aircraft has full throttle but no full-throttle consumption params exists in database!");
							case Throttle.Loiter:
								num = altBand.Consumption_Loiter;
								if (!this.get_CanHover(bool_7: false))
								{
									flag = true;
								}
								else
								{
									num2 = altBand.Consumption_Full.Value;
								}
								break;
							case Throttle.Cruise:
								num = altBand.Consumption_Cruise;
								num2 = altBand.Consumption_Loiter;
								break;
							case Throttle.Full:
								if (!altBand.Speed_Full.HasValue)
								{
									if (!ValidateThrottleSelection)
									{
										throw new Exception("Aircraft has military throttle but no fuel consumption params exist in database!");
									}
									num = altBand.Consumption_Cruise;
									num2 = altBand.Consumption_Loiter;
									theThrottleSetting = Throttle.Cruise;
								}
								else
								{
									num = altBand.Consumption_Full.Value;
									_ = (float)altBand.Speed_Full.Value;
									num2 = altBand.Consumption_Cruise;
								}
								break;
							case Throttle.Flank:
								if (!altBand.Speed_Flank.HasValue)
								{
									if (!ValidateThrottleSelection)
									{
										throw new Exception("Aircraft has afterburner throttle but no fuel consumption params exist in database!");
									}
									if (!altBand.Speed_Full.HasValue)
									{
										num = altBand.Consumption_Cruise;
										num2 = altBand.Consumption_Loiter;
										theThrottleSetting = Throttle.Cruise;
									}
									else
									{
										num = altBand.Consumption_Full.Value;
										_ = (float)altBand.Speed_Full.Value;
										num2 = altBand.Consumption_Cruise;
										theThrottleSetting = Throttle.Full;
									}
								}
								else
								{
									num = altBand.Consumption_Flank.Value;
									_ = (float)altBand.Speed_Flank.Value;
									num2 = (altBand.Speed_Full.HasValue ? altBand.Consumption_Full.Value : altBand.Consumption_Cruise);
								}
								break;
							}
							num3 = num;
							if (!theSpeed.HasValue || !theAltitude.HasValue)
							{
								goto IL_0771;
							}
							if (altBand == Kinematics.HighestAltBand(engine))
							{
								goto IL_060d;
							}
							AltBand[] altBands = engine.AltBands;
							if (altBands.Length != 0)
							{
								PooledList<AltBand> pooledList2 = new PooledList<AltBand>(Pools<AltBand>.Local);
								AltBand[] array = altBands;
								foreach (AltBand altBand3 in array)
								{
									if (altBand3.MinAlt >= altBand.MaxAlt)
									{
										pooledList2.Add(altBand3);
									}
								}
								switch (pooledList2.Count)
								{
								case 0:
									altBand2 = null;
									break;
								default:
								{
									float num4 = float.MaxValue;
									foreach (AltBand item2 in pooledList2)
									{
										if (item2.MaxAlt < num4)
										{
											altBand2 = item2;
											num4 = item2.MaxAlt;
										}
									}
									break;
								}
								case 1:
									altBand2 = pooledList2[0];
									break;
								}
								pooledList2.Dispose();
								if (altBand2 != null)
								{
									float num5 = default(float);
									float num6 = default(float);
									float? num7;
									float minAlt;
									switch (theThrottleSetting)
									{
									default:
										result = 0f;
										goto end_IL_0016;
									case Throttle.FullStop:
										if (!altBand2.Speed_Full.HasValue)
										{
											throw new Exception("Helicopter is at Full Stop throttle but no full-throttle consumption params exists in database!");
										}
										num5 = altBand.Consumption_Full.Value;
										goto IL_051b;
									case Throttle.Loiter:
										num5 = altBand2.Consumption_Loiter;
										if (!flag)
										{
											num6 = altBand2.Consumption_Full.Value;
										}
										goto IL_051b;
									case Throttle.Cruise:
										num5 = altBand2.Consumption_Cruise;
										num6 = altBand2.Consumption_Loiter;
										goto IL_051b;
									case Throttle.Full:
										if (!altBand2.Speed_Full.HasValue)
										{
											if (!ValidateThrottleSelection)
											{
												throw new Exception("Aircraft has military throttle but no fuel consumption params exist in database!");
											}
											num = altBand.Consumption_Cruise;
											num2 = altBand.Consumption_Loiter;
											theThrottleSetting = Throttle.Cruise;
										}
										else
										{
											num5 = altBand2.Consumption_Full.Value;
											_ = (float)altBand2.Speed_Full.Value;
											num6 = altBand2.Consumption_Cruise;
										}
										goto IL_051b;
									case Throttle.Flank:
										{
											if (!altBand2.Speed_Flank.HasValue)
											{
												if (!ValidateThrottleSelection)
												{
													throw new Exception("Aircraft has afterburner throttle but no fuel consumption params exist in database!");
												}
												if (altBand.Speed_Full.HasValue)
												{
													num = altBand.Consumption_Full.Value;
													_ = (float)altBand.Speed_Full.Value;
													num2 = altBand.Consumption_Cruise;
													theThrottleSetting = Throttle.Full;
												}
												else
												{
													num = altBand.Consumption_Cruise;
													num2 = altBand.Consumption_Loiter;
													theThrottleSetting = Throttle.Cruise;
												}
											}
											else
											{
												num5 = altBand2.Consumption_Flank.Value;
												_ = (float)altBand2.Speed_Flank.Value;
												num6 = (altBand2.Speed_Full.HasValue ? altBand2.Consumption_Full.Value : altBand2.Consumption_Cruise);
											}
											goto IL_051b;
										}
										IL_051b:
										if (num == num5)
										{
											break;
										}
										num7 = theAltitude;
										minAlt = altBand.MinAlt;
										if (((!num7.HasValue) ? ((bool?)null) : new bool?(num7.GetValueOrDefault() != minAlt)) == true)
										{
											float value = ((theAltitude - altBand.MinAlt) / (altBand.MaxAlt - altBand.MinAlt)).Value;
											value = Math.Abs(value);
											num += (num5 - num) * value;
											num3 = num;
											if (!flag)
											{
												num2 += (num6 - num2) * value;
											}
										}
										break;
									}
								}
								goto IL_060d;
							}
							result = 0f;
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
				}
				goto end_IL_0016;
				IL_0771:
				int num11;
				if (Loadout != null)
				{
					float weightDragModifier = Loadout.WeightDragModifier;
					int num8 = 0;
					int num9 = ((!FlightplanFuelEstimate) ? method_19() : Loadout.PayloadWeight_TakeOff);
					if (num9 > 0 && weightDragModifier > 0f)
					{
						if (BingoFuelCheck && Loadout.PayloadWeightDroppable > 0 && ActiveMissionOrPackage() != null && ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && !AI.IsEscort)
						{
							Strike strike = (Strike)ActiveMissionOrPackage();
							if (strike.BingoFuel != Mission._BingoFuelSetting.UseLoadoutSetting)
							{
								if (strike.BingoFuel == Mission._BingoFuelSetting.ExpendJettison)
								{
									num8 = Loadout.PayloadWeightDroppable;
								}
							}
							else if (Loadout != null && Loadout.get_MissionProfile(ParentScen).DropBombsAtMaxRange)
							{
								num8 = Loadout.PayloadWeightDroppable;
							}
						}
						if (ReserveFuelQtyCalc && ActiveMissionOrPackage() != null && ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && !AI.IsEscort)
						{
							Strike strike2 = (Strike)ActiveMissionOrPackage();
							if (strike2.BingoFuel == Mission._BingoFuelSetting.UseLoadoutSetting)
							{
								if (Loadout != null && Loadout.get_MissionProfile(ParentScen).DropBombsAtMaxRange)
								{
									num8 = Loadout.PayloadWeightDroppable;
								}
							}
							else if (strike2.BingoFuel == Mission._BingoFuelSetting.ExpendJettison)
							{
								num8 = Loadout.PayloadWeightDroppable;
							}
						}
						if (CombatRadiusCheck && ActiveMissionOrPackage() != null && ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && !AI.IsEscort)
						{
							Strike strike3 = (Strike)ActiveMissionOrPackage();
							if (strike3.BingoFuel != Mission._BingoFuelSetting.UseLoadoutSetting)
							{
								if (strike3.BingoFuel == Mission._BingoFuelSetting.ExpendJettison)
								{
									if (!FlightplanFuelEstimate)
									{
										num8 = Loadout.PayloadWeightDroppable;
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
									}
									else
									{
										num8 = Loadout.PayloadWeightDroppable_TakeOff;
									}
								}
							}
							else if (Loadout != null && Loadout.get_MissionProfile(ParentScen).DropBombsAtMaxRange)
							{
								if (!FlightplanFuelEstimate)
								{
									num8 = Loadout.PayloadWeightDroppable;
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
								}
								else
								{
									num8 = Loadout.PayloadWeightDroppable_TakeOff;
								}
							}
						}
						float num10 = weightDragModifier * (num3 * (float)(num9 - num8)) / 100f;
						num3 += num10;
						num11 = 0;
						goto IL_09bb;
					}
				}
				num11 = 0;
				goto IL_09bb;
				IL_060d:
				if (!flag && (!this.get_CanHover(bool_7: false) || !(DesiredSpeed <= (float)Kinematics.GetMaximumSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Throttle.Loiter, ValidateAndFixAltitude: false))))
				{
					float num12 = Kinematics.GetMaximumSpeed(theAltitude.Value, theThrottleSetting, ValidateAndFixAltitude: false);
					float? num7 = theSpeed;
					if ((num7.HasValue ? new bool?(num7.GetValueOrDefault() < num12) : ((bool?)null)) == true)
					{
						float num13 = Kinematics.GetMaximumSpeed(theAltitude.Value, theThrottleSetting - 1, ValidateAndFixAltitude: false);
						num7 = theSpeed;
						float value2;
						if ((num7.HasValue ? new bool?(num7.GetValueOrDefault() >= num13) : ((bool?)null)) == true)
						{
							value2 = ((theSpeed - num13) / (num12 - num13)).Value;
							value2 = Math.Abs(value2);
						}
						else
						{
							value2 = 0f;
						}
						num3 = ((num13 != 0f) ? (num2 + (num - num2) * value2) : (num2 + (num - num2) * value2));
					}
				}
				goto IL_0771;
				IL_09bb:
				int num14 = num11;
				foreach (Engine item3 in Propulsion)
				{
					if (item3.Status == PlatformComponent._ComponentStatus.Operational)
					{
						num14++;
					}
				}
				double num15 = (double)num14 / (double)Propulsion.Count;
				num3 = (float)((double)num3 * num15);
				result = num3 / 60f;
				end_IL_0016:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				ex?.Data.Add("Error at 100373", "");
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

	public static string LoadoutWeaponStateDescirption(int LoadoutID, int WeaponStateID, Loadout.LoadoutRole LoadoutRole, Scenario theScen)
	{
		switch (WeaponStateID)
		{
		case 2002:
			if ((uint)(LoadoutRole - 2001) <= 6u)
			{
				return "Winchester: Return to base when mission-specific weapons have been expended. Allow targets of opportunity with air-to-air guns.";
			}
			return "Winchester: Return to base when mission-specific weapons have been expended. Disengage immediately.";
		case 2001:
			return "Winchester: Return to base when mission-specific weapons have been expended. Disengage immediately.";
		case 4002:
			return "Shotgun: Return to base when 25% of relevant weapons have been expended. Allow targets of opportunity, including air-to-air guns.";
		case 4001:
			return "Shotgun: Return to base when 25% of relevant weapons have been expended. Disengage immediately.";
		case 3001:
			if ((uint)(LoadoutRole - 2001) > 6u)
			{
				return "Shotgun: Return to base when all Stand-Off weapons have been expended. Disengage immediately.";
			}
			return "Shotgun: Return to base when all BVR weapons have been expended. Disengage immediately.";
		case 3002:
			if ((uint)(LoadoutRole - 2001) > 6u)
			{
				return "Shotgun: Return to base when all Stand-Off weapons have been expended. Allow easy targets of opportunity with Strike weapons.";
			}
			return "Shotgun: Return to base when all BVR weapons have been expended. Allow easy targets of opportunity with WVR weapons. No air-to-air guns.";
		case 3003:
			if ((uint)(LoadoutRole - 2001) > 6u)
			{
				return "Shotgun: Return to base when all Stand-Off weapons have been expended. Allow easy targets of opportunity with Strike weapons.";
			}
			return "Shotgun: Return to base when all BVR weapons have been expended. Allow easy targets of opportunity with WVR weapons, and air-to-air guns.";
		case 4012:
			return "Shotgun: Return to base when 50% of relevant weapons have been expended. Allow targets of opportunity, including air-to-air guns.";
		case 4011:
			return "Shotgun: Return to base when 50% of relevant weapons have been expended. Disengage immediately.";
		case 5001:
			if ((uint)(LoadoutRole - 2001) <= 6u)
			{
				return "Shotgun: Return to base after one engagement with BVR weapons. Disengage immediately.";
			}
			return "Shotgun: Return to base after one engagement with Stand-Off weapons. Disengage immediately.";
		case 5002:
			if ((uint)(LoadoutRole - 2001) > 6u)
			{
				return "Shotgun: Return to base after one engagement with Stand-Off weapons. Allow easy targets of opportunity with Strike weapons.";
			}
			return "Shotgun: Return to base after one engagement with BVR weapons. Allow easy targets of opportunity with WVR weapons. No air-to-air guns.";
		case 5003:
			if ((uint)(LoadoutRole - 2001) <= 6u)
			{
				return "Shotgun: Return to base after one engagement with BVR weapons. Allow easy targets of opportunity with WVR weapons, and air-to-air guns.";
			}
			return "Shotgun: Return to base after one engagement with Stand-Off weapons. Allow easy targets of opportunity with Strike weapons.";
		case 5005:
			if ((uint)(LoadoutRole - 2001) > 6u)
			{
				return "Shotgun: Return to base after one engagement with both Stand-Off and Strike weapons.";
			}
			return "Shotgun: Return to base after one engagement with both BVR and WVR weapons. No air-to-air guns.";
		case 5006:
			if ((uint)(LoadoutRole - 2001) > 6u)
			{
				return "Shotgun: Return to base after one engagement with both Stand-Off and Strike weapons.";
			}
			return "Shotgun: Return to base after one engagement with both BVR and WVR weapons. Allow easy targets of opportunity with air-to-air guns.";
		default:
		{
			SQLiteConnection theConn = theScen.DBConnection;
			return DBFunctions.GetLoadoutWeaponStateDescription(LoadoutID, WeaponStateID, ref theConn, theScen, DescriptionFromDatabase: true, LoadoutRole);
		}
		case 5011:
			if ((uint)(LoadoutRole - 2001) <= 6u)
			{
				return "Shotgun: Return to base after one engagement with WVR. Disengage immediately.";
			}
			return "Shotgun: Return to base after one engagement with Strike weapons. Disengage immediately.";
		case 5012:
			if ((uint)(LoadoutRole - 2001) <= 6u)
			{
				return "Shotgun: Return to base after one engagement with WVR weapons. Allow targets of opportunity with air-to-air guns.";
			}
			return "Shotgun: Return to base after one engagement with Strike weapons.";
		case 4022:
			return "Shotgun: Return to base when 75% of relevant weapons have been expended. Allow targets of opportunity, including air-to-air guns.";
		case 4021:
			return "Shotgun: Return to base when 75% of relevant weapons have been expended. Disengage immediately.";
		}
	}

	internal float GetCargo_Crew()
	{
		if (Loadout != null && Loadout.Role != Loadout.LoadoutRole.PackedForCargo)
		{
			return Loadout.Cargo_Crew;
		}
		return 0f;
	}

	float ICargoHost.GetCargo_Crew()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Crew
		return this.GetCargo_Crew();
	}

	internal float GetCargo_Area()
	{
		if (Loadout != null && Loadout.Role != Loadout.LoadoutRole.PackedForCargo)
		{
			return Loadout.GetCargoArea();
		}
		return 0f;
	}

	float ICargoHost.GetCargo_Area()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Area
		return this.GetCargo_Area();
	}

	internal CargoType GetCargo_Type()
	{
		int result;
		if (Loadout == null)
		{
			result = 0;
		}
		else
		{
			if (Loadout.Role != Loadout.LoadoutRole.PackedForCargo)
			{
				return Loadout.Cargo_Type;
			}
			result = 0;
		}
		return (CargoType)result;
	}

	CargoType ICargoHost.GetCargo_Type()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Type
		return this.GetCargo_Type();
	}

	internal float GetCargo_Mass()
	{
		if (Loadout != null && Loadout.Role != Loadout.LoadoutRole.PackedForCargo)
		{
			return Loadout.GetCargoMass();
		}
		return 0f;
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
		if (Loadout != null && Loadout.Role != Loadout.LoadoutRole.PackedForCargo)
		{
			return CargoHostHelper.GetAvailableMass(this, OnboardCargo);
		}
		return 0f;
	}

	internal bool GetCargo_ParadropCapable()
	{
		int result;
		if (Loadout == null)
		{
			result = 0;
		}
		else
		{
			if (Loadout.Role != Loadout.LoadoutRole.PackedForCargo)
			{
				return Loadout.Cargo_ParadropCapable;
			}
			result = 0;
		}
		return (byte)result != 0;
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
		int result;
		if (CargoItems == null)
		{
			result = 0;
		}
		else
		{
			if (CargoItems.Count > 0)
			{
				double num = 0.0;
				int num2 = 0;
				double num3 = 0.0;
				double num4 = 0.0;
				foreach (Cargo CargoItem in CargoItems)
				{
					num3 += (double)CargoItem.RequiredMass;
					if (CargoItem.RequiredCargoType == CargoType.Personnel)
					{
						num4 += (double)CargoItem.RequiredCrewSpace;
					}
					num2 = Math.Max(num2, CargoItem.GetAdditionalLoadTime());
				}
				if (num4 > 0.0)
				{
					num = num4 / 10.0;
				}
				if (num3 > 0.0)
				{
					num = Math.Max(num, ActiveUnit_DockingOps.GetCargoMoveTime(10.0, 60.0, num3, GetCargo_Mass()));
				}
				num += (double)num2;
				return (int)Math.Round(num * 60.0);
			}
			result = 0;
		}
		return result;
	}

	int ICargoHost.GetLoadTime(List<Cargo> CargoItems)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetLoadTime
		return this.GetLoadTime(CargoItems);
	}

	internal int GetUnloadTime(List<Cargo> CargoItems)
	{
		if (CargoItems != null && CargoItems.Count > 0)
		{
			double num = ActiveUnit_DockingOps.DEFAULT_CARGO_UNLOAD_TIME;
			double num2 = 0.0;
			double num3 = default(double);
			foreach (Cargo CargoItem in CargoItems)
			{
				num3 += (double)CargoItem.RequiredMass;
				if (num2 > -1.0)
				{
					num2 = ((CargoItem.RequiredCargoType != CargoType.Personnel) ? (-1.0) : (num2 + (double)CargoItem.RequiredCrewSpace));
				}
			}
			num = ((!(num2 > 0.0)) ? ActiveUnit_DockingOps.GetCargoMoveTime(2.0, 60.0, num3, GetCargo_Mass()) : (num2 / 20.0));
			return (int)Math.Round(num * 60.0);
		}
		return 0;
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

	public CargoType GetRequiredCargoType()
	{
		int result;
		if (Loadout == null)
		{
			result = 0;
		}
		else
		{
			if (AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Readying)
			{
				if (Loadout.Role == Loadout.LoadoutRole.PackedForCargo)
				{
					return Loadout.Cargo_Type;
				}
				if (Loadout.Role == Loadout.LoadoutRole.Reserve)
				{
					return Cargo_Type;
				}
			}
			result = 0;
		}
		return (CargoType)result;
	}

	public float GetRequiredCrewSpace()
	{
		if (Loadout != null && Loadout.Role == Loadout.LoadoutRole.PackedForCargo)
		{
			return Loadout.Cargo_Crew;
		}
		return Cargo_Crew;
	}

	public float GetRequiredArea()
	{
		if (Loadout != null && Loadout.Role == Loadout.LoadoutRole.PackedForCargo)
		{
			return Loadout.Cargo_Area;
		}
		return Cargo_Area;
	}

	public float GetRequiredMass()
	{
		if (Loadout != null && Loadout.Role == Loadout.LoadoutRole.PackedForCargo)
		{
			return Loadout.Cargo_Mass;
		}
		return Cargo_Mass;
	}

	public bool GetParadropCapable()
	{
		if (Loadout != null && Loadout.Role == Loadout.LoadoutRole.PackedForCargo)
		{
			return Loadout.Cargo_ParadropCapable;
		}
		return Cargo_ParadropCapable;
	}

	public string GetCargoName()
	{
		return Name;
	}

	public string GetCargoObjectID()
	{
		return ObjectID;
	}

	public int imethod_0()
	{
		return DBID;
	}

	public PlatformComponent._ComponentStatus GetCargoObjectStatus()
	{
		if (IsMorituri)
		{
			return PlatformComponent._ComponentStatus.Destroyed;
		}
		if (Damage.DamagePercent > 0f)
		{
			return PlatformComponent._ComponentStatus.Damaged;
		}
		return PlatformComponent._ComponentStatus.Operational;
	}

	public PlatformComponent._DamageSeverityFactor GetCargoObjectDamageSeverity()
	{
		float damagePercent = Damage.DamagePercent;
		if (damagePercent > 66f)
		{
			return PlatformComponent._DamageSeverityFactor.Heavy;
		}
		if (damagePercent > 33f)
		{
			return PlatformComponent._DamageSeverityFactor.Medium;
		}
		return PlatformComponent._DamageSeverityFactor.Light;
	}

	public string GetCargoObjectReasonForInoperative()
	{
		return "None";
	}

	public string GetCargoObjectLossString()
	{
		return "Aircraft_" + DBID;
	}

	public string CargoObjectToXML(HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		return "<Aircraft>" + ObjectID + "</Aircraft>";
	}

	public void imethod_1()
	{
		ResetIDs();
	}

	public void DestroyCargoObject(Side ComponentPlatformSide, bool ScenEditAction, bool IsFacilityAimpoint, bool DestroyUnitNow, string theReason, string WhatCausedIt = null, bool RegisterAsLosses = true)
	{
		Destroy(ScenEditAction, Module_ActiveUnit.IsAimpointFacility(this), DestroyUnitNow, theReason, WhatCausedIt, RegisterAsLosses);
	}

	public bool WantsToUnload()
	{
		return false;
	}

	public bool IsTowable()
	{
		return false;
	}

	public bool IsStackable()
	{
		return false;
	}

	public float GetRequiredHeight()
	{
		return Height;
	}

	public float GetRequiredAreaStacked(ICargoHost Host, int TotalQuantity)
	{
		return GetRequiredArea() * (float)TotalQuantity;
	}

	public bool isMatch(Cargo c)
	{
		if (c != null && c.CargoObjectActiveUnit != null)
		{
			ActiveUnit cargoObjectActiveUnit = c.CargoObjectActiveUnit;
			if (cargoObjectActiveUnit.IsAircraft && cargoObjectActiveUnit.DBID == DBID)
			{
				return true;
			}
		}
		return false;
	}

	public int GetCargoQuantity()
	{
		return 1;
	}

	internal override PooledList<Sensor> GetAllSensors()
	{
		PooledList<Sensor> pooledList = new PooledList<Sensor>(Pools<Sensor>.Local);
		foreach (Sensor sensor2 in _Sensors)
		{
			if (!sensor2.IsMineCountermeasure)
			{
				pooledList.Add(sensor2);
			}
		}
		int num = Mounts.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			Sensor[] sensors_ReadOnly = Mounts[i].Sensors_ReadOnly;
			foreach (Sensor sensor in sensors_ReadOnly)
			{
				if (!sensor.IsMineCountermeasure)
				{
					sensor.IsSensorInMount = true;
					pooledList.Add(sensor);
				}
			}
		}
		if (Loadout != null)
		{
			PooledList<Sensor> pooledList2 = Loadout.Sensors(ParentScen);
			if (pooledList2 != null && pooledList2.Count > 0)
			{
				foreach (Sensor item in pooledList2)
				{
					item.IsSensorInLoadout = true;
					pooledList.Add(item);
				}
				pooledList2.Dispose();
			}
			HashSet<int> hashSet = new HashSet<int>();
			if (Loadout.Weapons != null)
			{
				WeaponRec[] weapons = Loadout.Weapons;
				foreach (WeaponRec weaponRec in weapons)
				{
					if (weaponRec.CurrentLoad <= 0)
					{
						continue;
					}
					Weapon weapon = weaponRec.get_ReferenceWeapon(ParentScen);
					if (!weapon.CanActAsSensor && weapon.Type != Weapon._WeaponType.HeliTowedPackage)
					{
						continue;
					}
					foreach (Sensor item2 in weapon.WeaponSensors())
					{
						if (weapon.Type != Weapon._WeaponType.SensorPod && weapon.Type != Weapon._WeaponType.HeliTowedPackage)
						{
							if (!hashSet.Contains(item2.DBID))
							{
								hashSet.Add(item2.DBID);
								item2.IsSensorInLoadout = true;
								pooledList.Add(item2);
								if (item2.ScanInterval < 10)
								{
									item2.ScanInterval = 10;
								}
							}
						}
						else
						{
							pooledList.Add(item2);
							item2.IsSensorInLoadout = true;
						}
					}
				}
			}
		}
		return pooledList;
	}

	public override void ActualHorizMovement(float elapsedTime, bool SimplifiedCalcs_DLZ)
	{
		if (CurrentSpeed == 0f)
		{
			return;
		}
		Longitude_old = this.get_Longitude((GlobalVariables.BooleanObject)null);
		Latitude_old = this.get_Latitude((GlobalVariables.BooleanObject)null);
		try
		{
			float num = (IsActiveUnit ? ((ActiveUnit)this).Kinematics.HorizMovementDistanceOnThisTime(elapsedTime) : ((Module_Unit.Unit)this).get_HorizMovementDistanceOnThisTime(elapsedTime));
			double out_lon = default(double);
			double out_lat = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(Longitude_old, Latitude_old, ref out_lon, ref out_lat, num, CurrentHeading);
			if (double.IsNaN(out_lat))
			{
				out_lat = Latitude_old;
			}
			int num2;
			if (!double.IsNaN(out_lon))
			{
				num2 = 0;
			}
			else
			{
				out_lon = Longitude_old;
				num2 = 0;
			}
			bool CheckForMines = (byte)num2 != 0;
			bool CheckNoNavZones = true;
			bool AllowBounce = true;
			double theLat = out_lat;
			double theLon = out_lon;
			int MovementCost = 0;
			string UserFeedback = "";
			List<ActiveUnit> ProvidedPiers = default(List<ActiveUnit>);
			if (CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: true, ref UserFeedback, ref AllowBounce))
			{
				this.set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
				this.set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
				if (ParentScen.MinuteIsChangingOnThisPulse)
				{
					((ActiveUnit)this).Navigator.GetNearestAccessibleSpotHeading = null;
				}
			}
			else if (!CheckForMines)
			{
				if (CheckNoNavZones)
				{
					this.set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
					this.set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
					if (ParentScen.MinuteIsChangingOnThisPulse | IsInsideNoNavZones(out_lat, out_lon, 2f))
					{
						((ActiveUnit)this).Navigator.GetNearestAccessibleSpotHeading = null;
						method_20(ref out_lon, ref out_lat, num, ref ProvidedPiers, ref CheckForMines, ref CheckNoNavZones, ref AllowBounce);
					}
				}
				else
				{
					method_20(ref out_lon, ref out_lat, num, ref ProvidedPiers, ref CheckForMines, ref CheckNoNavZones, ref AllowBounce);
				}
			}
			else
			{
				if (!ParentScen.MinuteIsChangingOnThisPulse && !Information.IsNothing((object)((ActiveUnit)this).Navigator.GetNearestAccessibleSpotHeading))
				{
					CurrentHeading = ((ActiveUnit)this).Navigator.GetNearestAccessibleSpotHeading.Value;
				}
				else
				{
					if (CheckForMines && ((ActiveUnit)this).Navigator.HasPathfindingPlottedCourse)
					{
						((ActiveUnit)this).Navigator.ClearPathfindingWaypoints();
					}
					double DestLat = default(double);
					double DestLon = default(double);
					if (((ActiveUnit)this).Navigator.GetNearestAccessibleSpot(out_lat, out_lon, ref DestLat, ref DestLon, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, 0f, ref ProvidedPiers, ManouverTowardsTarget: false))
					{
						((ActiveUnit)this).Navigator.GetNearestAccessibleSpotHeading = Math2.CalcAzimuth(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), DestLat, DestLon);
						CurrentHeading = ((ActiveUnit)this).Navigator.GetNearestAccessibleSpotHeading.Value;
						((ActiveUnit)this).Navigator.ResetTimeToNextPathfinderCheck();
					}
				}
				this.set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
				this.set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
			}
			this.set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
			this.set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
			if (double.IsNaN(this.get_Latitude((GlobalVariables.BooleanObject)null)))
			{
				this.set_Latitude((GlobalVariables.BooleanObject)null, Latitude_old);
			}
			if (double.IsNaN(this.get_Longitude((GlobalVariables.BooleanObject)null)))
			{
				this.set_Longitude((GlobalVariables.BooleanObject)null, Longitude_old);
			}
			if (!SimplifiedCalcs_DLZ)
			{
				CacheOldPosAndNextPos(elapsedTime);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100875", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_20(ref double double_0, ref double double_1, float float_8, ref List<ActiveUnit> list_2, ref bool bool_7, ref bool bool_8, ref bool bool_9)
	{
		double latitude_old = Latitude_old;
		double longitude_old = Longitude_old;
		int MovementCost = 0;
		string UserFeedback = "";
		if (CanMoveToThisLocation(latitude_old, longitude_old, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref bool_8, CheckForIcepack: true, ref bool_7, null, null, ref list_2, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: true, ref UserFeedback, ref bool_9))
		{
			bool_9 = true;
		}
		if (!bool_9)
		{
			return;
		}
		CurrentHeading = Bounce(CurrentHeading, float_8, bool_0: false);
		Geodesic_EdWilliams.CalcPoint_Williams(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null), ref double_0, ref double_1, float_8, CurrentHeading);
		if (ParentScen.MinuteIsChangingOnThisPulse | IsInsideNoNavZones(double_1, double_0, 2f))
		{
			double theLat = double_1;
			double theLon = double_0;
			MovementCost = 0;
			bool CheckNoNavZones = false;
			UserFeedback = "";
			bool AllowBounce = false;
			double DestLat = default(double);
			double DestLon = default(double);
			if (!CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref CheckNoNavZones, CheckForIcepack: true, ref bool_7, null, null, ref list_2, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce) && ((ActiveUnit)this).Navigator.GetNearestAccessibleSpot(double_1, double_0, ref DestLat, ref DestLon, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, 0f, ref list_2, ManouverTowardsTarget: false))
			{
				double_1 = DestLat;
				double_0 = DestLon;
				((ActiveUnit)this).Navigator.ResetTimeToNextPathfinderCheck();
			}
			((ActiveUnit)this).Navigator.GetNearestAccessibleSpotHeading = null;
		}
	}

	internal bool DivertForEmergencyLanding()
	{
		List<ActiveUnit> list = new List<ActiveUnit>(ParentScen.ActiveUnits_List);
		List<ActiveUnit> list2 = new List<ActiveUnit>();
		foreach (ActiveUnit item in list)
		{
			if (item.get_UnitSide(SetSideOnly: false) != ((ActiveUnit)this).get_UnitSide(SetSideOnly: false) && !Module_Side.IsAlliedWithThisSide(((ActiveUnit)this).get_UnitSide(SetSideOnly: false), item.get_UnitSide(SetSideOnly: false)))
			{
				continue;
			}
			if (item.IsFixedFacility && item.get_ParentGroup(UsingMissionPlanner: false) != null && item.get_ParentGroup(UsingMissionPlanner: false).Type == Group.GroupType.AirBase)
			{
				Group obj = item.get_ParentGroup(UsingMissionPlanner: false);
				if (!list2.Contains(obj) && AirOps.ThisUnitCanHostMe(obj, HumanFeedbackNeeded: false).ResponseBoolean)
				{
					list2.Add(obj);
				}
			}
			else if ((item.IsSingleUnitAirbase || item.IsShip) && AirOps.ThisUnitCanHostMe(item, HumanFeedbackNeeded: false).ResponseBoolean)
			{
				list2.Add(item);
			}
		}
		int result;
		if (list2.Count > 1)
		{
			ActiveUnit activeUnit = list2.OrderBy([SpecialName] (ActiveUnit u) => u.RangeToUnit_Horiz(this)).First();
			if (AirOps.get_AssignedHostUnit(PickNewAssignedHost: false) != activeUnit)
			{
				AttemptToSetNewAssignedHost(activeUnit, ForceRTB: true);
				if (AirOps.get_AssignedHostUnit(PickNewAssignedHost: false) == activeUnit)
				{
					string text = "";
					if (Operators.CompareString(Name, UnitClass, false) != 0)
					{
						text = " (" + UnitClass + ")";
					}
					AddMessage(Name + text + " diverting to new base to land: " + activeUnit.Name + ".", Name + " emergency diversion!", LoggedMessage.MessageType.UnitAIEmergency, 0, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
					result = 0;
					goto IL_01d6;
				}
			}
		}
		result = 0;
		goto IL_01d6;
		IL_01d6:
		return (byte)result != 0;
	}

	public void ResolveAGUDamages(float[] Damages, float CombatAgility, float DamageModifier, float AttackDirection_degrees = -1f, bool IgnoreArmorDeflection = false, bool IgnoreCoverDeflection = false, AggregateGroundUnit.DamageResolutioMethod TargetingType = AggregateGroundUnit.DamageResolutioMethod.Standard)
	{
		if (!Helper.RollDice(1f / Agility_Nominal + 2f))
		{
			Notification_Bark.Create(this, "Missed by Manpad", Color.Yellow);
			return;
		}
		Destroy(ScenEditAction: false, IsAimpointFacility: false, DestroyUnitNow: true, "Destroyed by Manpad");
		Notification_Bark.Create(this, "Destroyed by Manpad", Color.Red);
	}

	public Module_Unit.Unit GetUnit()
	{
		return this;
	}

	public float[] GetCombatProtection(float[] ArrayByRef)
	{
		float[] result = default(float[]);
		return result;
	}

	public GlobalVariables.ArmorRating GetMostCommonArmorRating()
	{
		GlobalVariables.ArmorRating result = default(GlobalVariables.ArmorRating);
		return result;
	}

	public float[] GetCombatPower(float[] ArrayByRef)
	{
		float[] result = default(float[]);
		return result;
	}

	public void SpecialAGUAction()
	{
	}

	internal bool isSuicide()
	{
		PooledDictionary<int, Weapon> pooledDictionary = default(PooledDictionary<int, Weapon>);
		try
		{
			pooledDictionary = Weaponry.AllDistinctWeaponsAboard_Potential(IncludeAviationMags: true);
			foreach (KeyValuePair<int, Weapon> item in pooledDictionary)
			{
				if (item.Value.Type == Weapon._WeaponType.ContactBomb_Suicide)
				{
					return true;
				}
			}
			return false;
		}
		finally
		{
			pooledDictionary.Dispose();
		}
	}
}
