using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Submarine : Platform, IBoat, ICargoHost
{
	public enum ConventionalSubmarineEngineType : byte
	{
		Diesel,
		Electric,
		AIP
	}

	public struct _Flags
	{
		public bool AnechoicCoating;

		public bool NoLaunchTransient;

		public bool ShroudedPropulsor;

		public bool AdvancedPropulsor;

		public bool DoubleHull;

		public bool ShockResistant;

		public bool LowConstructionStandards;

		public bool NonmagneticHull;

		public bool bool_0;

		public bool UsesLiOnBattery;

		public bool HasSnorkel;

		public bool HasLateralThrusters;
	}

	public enum _SubmarineCategory
	{
		None = 1001,
		Submarine = 2001,
		Biologics = 2002,
		FalseTarget = 2003
	}

	public enum _SubmarineType
	{
		None = 1001,
		SSQ = 1900,
		AGSS = 2001,
		APSS = 2002,
		SS = 2003,
		SSB = 2004,
		SSBN = 2005,
		SSG = 2006,
		SSGN = 2007,
		SSK = 2008,
		SSM = 2009,
		SSN = 2010,
		SSP = 2011,
		SSR = 2012,
		SSRN = 2013,
		SDV = 3001,
		ROV = 4001,
		UUV = 4002,
		UUGlider = 4003,
		Biologics = 9001,
		FalseTarget = 9002
	}

	[CompilerGenerated]
	internal sealed class _Closure$__137-0
	{
		public FuelRec._FuelType $VB$Local_FuelTypeToConsume;

		public _Closure$__137-0(_Closure$__137-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_FuelTypeToConsume = arg0.$VB$Local_FuelTypeToConsume;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(FuelRec theRec)
		{
			return theRec.FuelType == $VB$Local_FuelTypeToConsume;
		}

		static _Closure$__137-0()
		{
			Class72.smethod_20();
		}
	}

	public int CombatSystemGen;

	public _Flags Flags;

	public PressureHull PressureHull;

	public Rudder Rudder;

	public CIC CIC;

	public Cargo Cargo;

	public _SubmarineCategory Category;

	public _SubmarineType Type;

	public DockFacility.DockingPhysicalSize DockingPhysicalSize;

	public int MaxDepth;

	public int RepairCapacity;

	public float Beam;

	public float Draft;

	public float Height;

	public short ROVControlRadius_m;

	private Dictionary<int, Engine> dictionary_0;

	private Engine engine_0;

	private int int_5;

	private Submarine_Navigator submarine_Navigator_0;

	private Submarine_AI submarine_AI_0;

	private Submarine_Kinematics submarine_Kinematics_0;

	private Submarine_Sensory submarine_Sensory_0;

	private Submarine_Weaponry submarine_Weaponry_0;

	private Submarine_CommStuff submarine_CommStuff_0;

	private Submarine_Damage submarine_Damage_0;

	private bool? nullable_16;

	public static int CommsEstablishDepth;

	public static int MaxTorpedoWireSpeed;

	public float Cargo_Crew;

	public float Cargo_Area;

	public CargoType Cargo_Type;

	public float Cargo_Mass;

	private float float_8;

	private float float_9;

	private float float_10;

	public override bool RepresentsMobileGroundUnit => false;

	public override bool UseSubmerisbleUnitUI => true;

	public override bool SupportsAltitude_Control => true;

	public override bool SupportsAttitude_Pitch => true;

	public bool IsBiological => Type == _SubmarineType.Biologics;

	public bool IsFalseTarget => Type == _SubmarineType.FalseTarget;

	public override ActiveUnit_DockingOps.ResupplyCapacity DesignatedSupplier
	{
		get
		{
			if (!_DesignatedSupplier.HasValue)
			{
				_DesignatedSupplier = ActiveUnit_DockingOps.ResupplyCapacity.None;
			}
			return _DesignatedSupplier.Value;
		}
		set
		{
			_DesignatedSupplier = value;
		}
	}

	public override float FlatSurfaceArea_m2 => Length * Beam;

	public override bool IsPlatform => true;

	public string Type_Description => Type.ToString();

	public override string AnnexAndDBID => "Submarine_" + Conversions.ToString(DBID);

	public override _ActiveUnitFuelState IsBingoOrJoker
	{
		get
		{
			_ActiveUnitFuelState result;
			try
			{
				if (IsNuke)
				{
					result = _ActiveUnitFuelState.None;
				}
				else if (IsDrone() && AutonomyLevel < DroneAutonomyLevel.FaultEventAdaptive && ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !((ActiveUnit_CommStuff)CommStuff).IsConnectedToSideNetwork)
				{
					result = _ActiveUnitFuelState.None;
				}
				else if (IsTetheredROV && Fuel_ReadOnly.Count == 0)
				{
					result = _ActiveUnitFuelState.None;
				}
				else
				{
					ActiveUnit actualDestinationHost = DockingOps.ActualDestinationHost;
					result = ((actualDestinationHost != null) ? ((!actualDestinationHost.IsMorituri) ? this.get_IsBingoTowardsThisDestination(actualDestinationHost, (GeoPoint)null, (Doctrine._FuelState?)null) : _ActiveUnitFuelState.None) : _ActiveUnitFuelState.None);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100801", "");
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
				result = (_ActiveUnitFuelState)num;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public override _ActiveUnitFuelState IsBingoTowardsThisDestination
	{
		get
		{
			_ActiveUnitFuelState result = default(_ActiveUnitFuelState);
			try
			{
				Engine theEngine = null;
				Engine.EngineType engineType = ((Propulsion.Where([SpecialName] (Engine theE) => theE.Type == Engine.EngineType.Diesel).Count() <= 0) ? Engine.EngineType.Electric : Engine.EngineType.Diesel);
				int num = Propulsion.Count - 1;
				int theEngineNo = default(int);
				for (int num2 = 0; num2 <= num; num2++)
				{
					Engine engine = Propulsion[num2];
					if (engine.Type == engineType)
					{
						theEngine = engine;
						theEngineNo = num2;
						break;
					}
				}
				float num3 = Math.Max(-20f, Kinematics.GetMinimumAltitude());
				float num4 = Kinematics.GetMaximumSpeed(num3, Throttle.Cruise, theEngine, theEngineNo, ValidateAndFixAltitude: false);
				float num5 = this.get_FuelEndurance(Throttle.Cruise, (AltBand)null, (float?)num4, (float?)num3, theEngine, theEngineNo);
				if (num5 <= 900f)
				{
					result = _ActiveUnitFuelState.IsBingo;
					return result;
				}
				float num6 = RangeToUnit_Horiz(theDestination);
				if ((double)(num5 * (num4 / 3600f)) >= (double)num6 * 1.1)
				{
					result = _ActiveUnitFuelState.None;
					return result;
				}
				result = _ActiveUnitFuelState.IsBingo;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100802", "");
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

	public Dictionary<int, Engine> SelectedEngines
	{
		get
		{
			if (dictionary_0 == null)
			{
				dictionary_0 = AI.SelectEngines();
			}
			return dictionary_0;
		}
		set
		{
			dictionary_0 = value;
		}
	}

	public Engine PrimaryEngine
	{
		get
		{
			if (engine_0 == null)
			{
				AI.SelectEngines();
			}
			return engine_0;
		}
		set
		{
			engine_0 = value;
		}
	}

	public int PrimaryEngineNo
	{
		get
		{
			if (engine_0 == null)
			{
				AI.SelectEngines();
			}
			return int_5;
		}
		set
		{
			int_5 = value;
		}
	}

	public override float DesiredSpeed
	{
		get
		{
			return base.DesiredSpeed;
		}
		set
		{
			if (!Kinematics.DesiredSpeedOverride.HasValue && value > (float)MaxTorpedoWireSpeed && Status != _ActiveUnitStatus.EngagedDefensive && Weaponry.IsGuidingWireTorpedoes)
			{
				value = MaxTorpedoWireSpeed;
			}
			if (Navigator.AvoidCavitation && Status != _ActiveUnitStatus.EngagedDefensive)
			{
				float num = Math.Min(Kinematics.CavitationSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), Kinematics.CavitationSpeed(DesiredAltitude));
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

	public override float DesiredAltitude
	{
		get
		{
			return base.DesiredAltitude;
		}
		set
		{
			float desiredAltitude = DesiredAltitude;
			if (!(Math.Round(DesiredAltitude) >= -20.0) && Damage.FireIntensity > ActiveUnit_Damage.FireIntensityLevel.Minor)
			{
				value = -20f;
			}
			if (Damage.FloodIntensity > ActiveUnit_Damage.FloodingIntensityLevel.Minor)
			{
				value = 0f;
			}
			if (desiredAltitude != value && Math.Round(value) < -20.0)
			{
				StopRechargingBatteries();
			}
			float num = ((Module_Unit.Unit)this).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentScen);
			if (value < num + 1f)
			{
				value = num + 1f;
			}
			base.DesiredAltitude = value;
		}
	}

	public override bool IsOutOfFuel
	{
		get
		{
			if (!IsNuke)
			{
				if (Fuel_ReadOnly.Count != 0)
				{
					return base.IsOutOfFuel;
				}
				return false;
			}
			return false;
		}
	}

	public Ship.ShipWakeSize WakeSize
	{
		get
		{
			if (CurrentSpeed == 0f)
			{
				return Ship.ShipWakeSize.NoWake;
			}
			if (!IsSurfaced)
			{
				if (!IsAtPeriscopeDepth)
				{
					return Ship.ShipWakeSize.NoWake;
				}
				return Ship.ShipWakeSize.VSmall;
			}
			return Ship.ShipWakeSize.Small;
		}
	}

	public new Submarine_Navigator Navigator
	{
		get
		{
			if (submarine_Navigator_0 == null)
			{
				ActiveUnit theUnit = this;
				submarine_Navigator_0 = new Submarine_Navigator(ref theUnit);
			}
			return submarine_Navigator_0;
		}
	}

	public new Submarine_AI AI => submarine_AI_0;

	public new Submarine_Kinematics Kinematics
	{
		get
		{
			if (Information.IsNothing((object)submarine_Kinematics_0))
			{
				ActiveUnit theUnit = this;
				submarine_Kinematics_0 = new Submarine_Kinematics(ref theUnit);
			}
			return submarine_Kinematics_0;
		}
	}

	public new Submarine_Sensory Sensory
	{
		get
		{
			if (submarine_Sensory_0 == null)
			{
				ActiveUnit theUnit = this;
				submarine_Sensory_0 = new Submarine_Sensory(ref theUnit);
			}
			return submarine_Sensory_0;
		}
	}

	public new Submarine_Weaponry Weaponry
	{
		get
		{
			if (submarine_Weaponry_0 == null)
			{
				ActiveUnit theUnit = this;
				submarine_Weaponry_0 = new Submarine_Weaponry(ref theUnit);
			}
			return submarine_Weaponry_0;
		}
	}

	public new Submarine_CommStuff CommStuff
	{
		get
		{
			if (submarine_CommStuff_0 == null)
			{
				ActiveUnit theUnit = this;
				submarine_CommStuff_0 = new Submarine_CommStuff(ref theUnit);
			}
			return submarine_CommStuff_0;
		}
	}

	public new Submarine_Damage Damage
	{
		get
		{
			if (submarine_Damage_0 == null)
			{
				ActiveUnit theUnit = this;
				submarine_Damage_0 = new Submarine_Damage(ref theUnit);
			}
			return submarine_Damage_0;
		}
	}

	public bool IsTetheredROV
	{
		get
		{
			if (Type == _SubmarineType.ROV)
			{
				return ROVControlRadius_m > 0;
			}
			return false;
		}
	}

	public bool IsNuke
	{
		get
		{
			bool value = default(bool);
			try
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
				value = nullable_16.Value;
				return value;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100803", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return value;
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
			return (int)Math.Round(22f + this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
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
			return (int)Math.Round(22f + this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		}
	}

	public override Throttle MaxPossibleThrottleSetting
	{
		get
		{
			AltBand currentAltBand = Kinematics.GetCurrentAltBand(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ValidateAndFixAltitude: false);
			if (currentAltBand.Consumption_Flank.HasValue && currentAltBand.Speed_Flank.HasValue)
			{
				return Throttle.Flank;
			}
			return Throttle.Full;
		}
	}

	public bool IsSurfaced => this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= -5f;

	public bool IsAtPeriscopeDepth
	{
		get
		{
			if (Math.Round(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < -20.0)
			{
				return false;
			}
			return Math.Round(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < -5.0;
		}
	}

	public override GlobalVariables.TargetVisualSizeClass VisualSizeClass
	{
		get
		{
			if (this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= -5f)
			{
				float length = Length;
				if (length > 150f)
				{
					return GlobalVariables.TargetVisualSizeClass.VLarge;
				}
				if (length > 100f)
				{
					return GlobalVariables.TargetVisualSizeClass.Large;
				}
				if (length > 60f)
				{
					return GlobalVariables.TargetVisualSizeClass.Medium;
				}
				if (length > 35f)
				{
					return GlobalVariables.TargetVisualSizeClass.Small;
				}
				return GlobalVariables.TargetVisualSizeClass.VSmall;
			}
			if (this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= -20f)
			{
				return GlobalVariables.TargetVisualSizeClass.Stealthy;
			}
			GlobalVariables.TargetVisualSizeClass result = default(GlobalVariables.TargetVisualSizeClass);
			return result;
		}
	}

	public override int SafeDistanceAgainstUnknownMine_meters
	{
		get
		{
			int result;
			if (Type != _SubmarineType.ROV)
			{
				if (Type != _SubmarineType.UUV)
				{
					return ((ActiveUnit)this).get_SafeDistanceAgainstUnknownMine_meters(UsePathfindingBufferDistance);
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

	public override float CurrentAltitude
	{
		get
		{
			return ((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null);
		}
		set
		{
			((ActiveUnit)this).set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, value);
			if (IsDLZconstruct)
			{
				return;
			}
			ActiveUnit_CommStuff.ReasonForGoingOffGrid? reasonForGoingOffGrid = ReasonForGoingOffGridDueToDepth();
			if (!reasonForGoingOffGrid.HasValue)
			{
				return;
			}
			switch (reasonForGoingOffGrid.Value)
			{
			case ActiveUnit_CommStuff.ReasonForGoingOffGrid.None:
				((ActiveUnit_CommStuff)CommStuff).set_IsConnectedToSideNetwork(ActiveUnit_CommStuff.ReasonForGoingOffGrid.None, value: true);
				if (CommStuff.HasBeenSummonedToReestablishComms)
				{
					CommStuff.HasBeenSummonedToReestablishComms = false;
					AI.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
					DesiredAltitude = CommsEstablishDepth;
					Status = _ActiveUnitStatus.Unassigned;
				}
				break;
			case ActiveUnit_CommStuff.ReasonForGoingOffGrid.AllCommDevicesDisabled:
				((ActiveUnit_CommStuff)CommStuff).set_IsConnectedToSideNetwork(ActiveUnit_CommStuff.ReasonForGoingOffGrid.AllCommDevicesDisabled, value: false);
				break;
			case ActiveUnit_CommStuff.ReasonForGoingOffGrid.DivingDeep:
				((ActiveUnit_CommStuff)CommStuff).set_IsConnectedToSideNetwork(ActiveUnit_CommStuff.ReasonForGoingOffGrid.DivingDeep, value: false);
				break;
			case ActiveUnit_CommStuff.ReasonForGoingOffGrid.ChangeOfInternalStatus:
				break;
			}
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
			if (ParentScen.FifteenthSecondIsChangingOnThisPulse && value > (float)MaxTorpedoWireSpeed)
			{
				Weaponry.BreakTorpedoWires(Submarine_Weaponry.TorpedoWireBreakReason.ExcessiveSpeed);
			}
		}
	}

	public override float DesiredHeading
	{
		set
		{
			((ActiveUnit)this).set_DesiredHeading(theTurnRate, value);
			if (ParentScen.FifteenthSecondIsChangingOnThisPulse && value == 0f)
			{
				Weaponry.BreakTorpedoWires(Submarine_Weaponry.TorpedoWireBreakReason.ExcessiveTurnRate);
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

	public new long FuelEndurance
	{
		get
		{
			if (IsNuke)
			{
				return long.MaxValue;
			}
			if (theThrottle != Throttle.FullStop)
			{
				if (IsTetheredROV && Fuel_ReadOnly.Count == 0)
				{
					return long.MaxValue;
				}
				if (Type != _SubmarineType.Biologics && Type != _SubmarineType.FalseTarget)
				{
					FuelRec fuelRec = null;
					float num = 0f;
					FuelRec._FuelType fuelType = AI.SelectFuelTypeToConsume(theEngine);
					foreach (FuelRec item in Fuel_ReadOnly)
					{
						if (item.CurrentQuantity > num && item.FuelType == fuelType)
						{
							fuelRec = item;
							num = item.CurrentQuantity;
						}
					}
					if (fuelRec == null)
					{
						return 0L;
					}
					float num2 = method_17(theThrottle, theAltBand, theSpeed, theAltitude, theEngine, theEngineNo);
					if (num2 == 0f)
					{
						if (fuelRec.CurrentQuantity == 0f)
						{
							return 0L;
						}
						return long.MaxValue;
					}
					return (long)Math.Round(fuelRec.CurrentQuantity / num2);
				}
				return long.MaxValue;
			}
			return 2147483647L;
		}
	}

	public bool IsAIP
	{
		get
		{
			foreach (FuelRec item in _Fuel)
			{
				if (item.FuelType == FuelRec._FuelType.AirIndepedent)
				{
					return true;
				}
			}
			return false;
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

	public bool IsDedicatedTankerOrUNREP => Type == _SubmarineType.APSS;

	static Submarine()
	{
		Class72.smethod_20();
		CommsEstablishDepth = -40;
		MaxTorpedoWireSpeed = 10;
	}

	private Submarine()
	{
		Scenario theScen = null;
		base..ctor(ref theScen);
		Flags = default(_Flags);
		PressureHull = new PressureHull(this);
		Rudder = new Rudder(this);
		CIC = new CIC(this, "Conn / CIC");
		Cargo = new Cargo(this);
		ActiveUnit theUnit = this;
		submarine_AI_0 = new Submarine_AI(ref theUnit);
		IsSubmarine = true;
		IsBoat = true;
		UnitType = GlobalVariables.ActiveUnitType.Submarine;
	}

	private protected override List<PlatformComponent> ComponentList()
	{
		List<PlatformComponent> list = base.ComponentList();
		list.Add(PressureHull);
		list.Add(Rudder);
		list.Add(CIC);
		list.Add(Cargo);
		return list;
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

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			if (((ActiveUnit)this).get_UnitSide(SetSideOnly: false) == null)
			{
				return;
			}
			theWriter.WriteStartElement("Submarine");
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
			theWriter.WriteElementString("CA", XmlConvert.ToString(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
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
			if (_Proficiency.HasValue)
			{
				theWriter.WriteElementString("Prof", ((int)_Proficiency.Value).ToString());
			}
			theWriter.WriteElementString("ThrottleSetting", ((byte)ThrottleSetting).ToString());
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
				theWriter.WriteElementString("IBPU", XmlConvert.ToString(EligibleForSAR));
			}
			if (IsBeingPickedUp)
			{
				theWriter.WriteElementString("IBPU", XmlConvert.ToString(IsBeingPickedUp));
			}
			if (AirFacilities_ReadOnly.Length > 0)
			{
				theWriter.WriteStartElement("AirFacilities");
				AirFacility[] airFacilities_ReadOnly = AirFacilities_ReadOnly;
				foreach (AirFacility airFacility in airFacilities_ReadOnly)
				{
					theWriter.WriteRaw(airFacility.ToXML(ObjectsAlreadySerialized));
				}
				theWriter.WriteEndElement();
			}
			if (DockFacilities_ReadOnly.Length > 0)
			{
				theWriter.WriteStartElement("DockFacilities");
				DockFacility[] dockFacilities_ReadOnly = DockFacilities_ReadOnly;
				foreach (DockFacility dockFacility in dockFacilities_ReadOnly)
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
			theWriter.WriteStartElement("PressureHull");
			PressureHull.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ParentScen);
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Rudder");
			Rudder.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ParentScen);
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("CIC");
			CIC.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ParentScen);
			theWriter.WriteEndElement();
			Navigator.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.WriteStartElement("Submarine_AI");
			AI.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Submarine_Kinematics");
			Kinematics.ToXML(ref theWriter);
			theWriter.WriteEndElement();
			Sensory.ToXML(ref theWriter);
			Weaponry.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.WriteStartElement("Submarine_CommStuff");
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
			ex2?.Data.Add("Error at 100799", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Submarine FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, Submarine existingObject = null)
	{
		Submarine submarine = default(Submarine);
		try
		{
			submarine = smethod_1(ref theNode, ref theDictionary, ref theScen, theScen.LoadStockUnits, existingObject);
		}
		catch (PlatformComponentNotFoundException projectError)
		{
			ProjectData.SetProjectError((Exception)projectError);
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			ConcurrentDictionary<string, ScenarioObject> obj = theDictionary;
			ScenarioObject value = submarine;
			obj.TryRemove(innerText, out value);
			submarine = smethod_1(ref theNode, ref theDictionary, ref theScen, bool_3: true, existingObject);
			string text = "";
			if (submarine.IsGroupMember())
			{
				text = "(member of group: [" + ((ActiveUnit)submarine).get_ParentGroup(UsingMissionPlanner: false).Name + "])";
			}
			theScen.LoadingNotices.Add("The following submarine:[" + submarine.Name + "]" + text + " failed to shallow-rebuild because of a component missing. The submarine was instead deep-rebuilt, and instantiated in its pristine DB-stock condition. All customizations present in the submarine's components (damaged components, weapon additions/removals etc. etc.) have been lost. Please re-apply any necessary customizations either manually or using an SBR script.");
			ProjectData.ClearProjectError();
		}
		if (Information.IsNothing((object)submarine))
		{
			string innerText2 = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			ConcurrentDictionary<string, ScenarioObject> obj2 = theDictionary;
			ScenarioObject value = new Submarine();
			obj2.TryRemove(innerText2, out value);
		}
		return submarine;
	}

	private static Submarine smethod_1(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0, bool bool_3, Submarine submarine_0 = null)
	{
		//IL_0780: Unknown result type (might be due to invalid IL or missing references)
		//IL_0787: Expected O, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_06f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fe: Expected O, but got Unknown
		//IL_0546: Unknown result type (might be due to invalid IL or missing references)
		//IL_054d: Expected O, but got Unknown
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_0678: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Expected O, but got Unknown
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Expected O, but got Unknown
		//IL_05f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Expected O, but got Unknown
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		//IL_163b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1642: Expected O, but got Unknown
		//IL_0ffc: Unknown result type (might be due to invalid IL or missing references)
		Submarine result = default(Submarine);
		try
		{
			bool flag;
			Submarine theSub;
			if (flag = submarine_0 != null)
			{
				theSub = submarine_0;
				theSub.Reinitialize();
			}
			else
			{
				theSub = new Submarine();
			}
			theSub.ParentScen = scenario_0;
			string text = Misc.GetNodeByName(xmlNode_0.ChildNodes, "ID").InnerText;
			if (Misc.ContainsChar(text, ' '))
			{
				text = text.Replace(" ", "-");
			}
			if (concurrentDictionary_0.ContainsKey(text))
			{
				result = (Submarine)concurrentDictionary_0[text];
			}
			else
			{
				theSub.ObjectID_Set(text);
				if (xmlNode_0.ChildNodes.Count == 1)
				{
					scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
					result = theSub;
				}
				else
				{
					concurrentDictionary_0.TryAdd(theSub.ObjectID, theSub);
					int num = Conversions.ToInteger(Misc.GetNodeByName(xmlNode_0.ChildNodes, "DBID").InnerText);
					try
					{
						DBFunctions.GetSubmarine(ref scenario_0, ref theSub, num, bool_3);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
						string objectID = theSub.ObjectID;
						ScenarioObject value = theSub;
						obj.TryRemove(objectID, out value);
						scenario_0.LoadingNotices.Add("Submarine with Database ID " + Conversions.ToString(num) + " is missing from the database and has not been loaded.");
						ProjectData.ClearProjectError();
						goto end_IL_0001;
					}
					if (bool_3)
					{
						theSub.method_3(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
					}
					if (!bool_3)
					{
						foreach (XmlNode childNode in xmlNode_0.ChildNodes)
						{
							XmlNode theNode = childNode;
							theSub.CommonFromXML(theNode);
							switch (theNode.Name)
							{
							case "Comms":
								if (flag)
								{
									ArrayExtensions.Clear(ref theSub._Comms);
								}
								foreach (XmlNode childNode2 in theNode.ChildNodes)
								{
									XmlNode theNode9 = childNode2;
									CommDevice commDevice = CommDevice.FromXML(ref theNode9, ref concurrentDictionary_0, theSub);
									theSub.AddCommDevice(commDevice);
									commDevice.ParentPlatform = theSub;
								}
								break;
							case "CIC":
								theSub.CIC = CIC.FromXML(ref theNode, ref concurrentDictionary_0, theSub);
								break;
							case "OnboardCargo":
								if (flag)
								{
									ArrayExtensions.Clear(ref theSub.OnboardCargo);
								}
								foreach (XmlNode childNode3 in theNode.ChildNodes)
								{
									XmlNode theNode6 = childNode3;
									Cargo cargo = Cargo.FromXML(ref theNode6, ref concurrentDictionary_0, scenario_0, theSub);
									ArrayExtensions.Add(ref theSub.OnboardCargo, cargo);
									cargo.ParentPlatform = theSub;
								}
								break;
							case "Fuel":
								if (flag)
								{
									theSub._Fuel.Clear();
								}
								foreach (XmlNode childNode4 in theNode.ChildNodes)
								{
									XmlNode theNode4 = childNode4;
									FuelRec item = FuelRec.FromXML(ref theNode4, ref concurrentDictionary_0);
									theSub._Fuel.Add(item);
								}
								break;
							case "PressureHull":
								theSub.PressureHull = PressureHull.FromXML(ref theNode, ref concurrentDictionary_0, theSub);
								break;
							case "DockFacilities":
								if (flag)
								{
									ArrayExtensions.Clear(ref theSub._DockFacilities);
								}
								foreach (XmlNode childNode5 in theNode.ChildNodes)
								{
									XmlNode theNode7 = childNode5;
									DockFacility dockFacility = DockFacility.FromXML(ref theNode7, ref concurrentDictionary_0, ref scenario_0);
									theSub.AddDockFacility(dockFacility);
									dockFacility.ParentPlatform = theSub;
								}
								break;
							case "Rudder":
								theSub.Rudder = Rudder.FromXML(ref theNode, ref concurrentDictionary_0);
								theSub.Rudder.ParentPlatform = theSub;
								break;
							case "Sensors":
								if (flag)
								{
									theSub._Sensors.Clear();
								}
								foreach (XmlNode childNode6 in theNode.ChildNodes)
								{
									Sensor sensor = Sensor.FromXML(childNode6, concurrentDictionary_0, theSub);
									theSub._Sensors.Add(sensor);
									sensor.ParentPlatform = theSub;
								}
								break;
							case "Propulsion":
								if (flag)
								{
									theSub.Propulsion.Clear();
								}
								foreach (XmlNode childNode7 in theNode.ChildNodes)
								{
									XmlNode theNode8 = childNode7;
									ActiveUnit theParentPlatform = theSub;
									Engine engine = Engine.FromXML(ref theNode8, ref concurrentDictionary_0, ref theParentPlatform);
									theSub.Propulsion.Add(engine);
									engine.ParentPlatform = theSub;
								}
								break;
							case "AirFacilities":
								if (flag)
								{
									ArrayExtensions.Clear(ref theSub._AirFacilities);
								}
								foreach (XmlNode childNode8 in theNode.ChildNodes)
								{
									XmlNode theNode5 = childNode8;
									AirFacility airFacility = AirFacility.FromXML(ref theNode5, ref concurrentDictionary_0, ref scenario_0);
									theSub.AddAirFacility(airFacility);
									airFacility.ParentPlatform = theSub;
								}
								break;
							case "Magazines":
								if (flag)
								{
									ArrayExtensions.Clear(ref theSub.Magazines);
								}
								foreach (XmlNode childNode9 in theNode.ChildNodes)
								{
									XmlNode theNode3 = childNode9;
									Magazine magazine = Magazine.FromXML(ref theNode3, ref concurrentDictionary_0, ref scenario_0);
									theSub.AddSharedMagazine(magazine, RaiseUiEvent: false);
									magazine.ParentPlatform = theSub;
								}
								break;
							case "Mounts":
								if (flag)
								{
									theSub.Mounts.Clear();
								}
								foreach (XmlNode childNode10 in theNode.ChildNodes)
								{
									XmlNode theNode2 = childNode10;
									Mount mount = Mount.FromXML(ref theNode2, ref concurrentDictionary_0, theSub);
									theSub.Mounts.Add(mount);
									mount.ParentPlatform = theSub;
								}
								break;
							}
						}
					}
					bool flag2 = false;
					foreach (XmlNode childNode11 in xmlNode_0.ChildNodes)
					{
						XmlNode theNode10 = childNode11;
						if (!theSub.isLastReportedInfoXMLField(theNode10.Name))
						{
							switch (theNode10.Name)
							{
							case "Submarine_Damage":
							{
								Submarine submarine8 = theSub;
								ActiveUnit theParentPlatform = theSub;
								submarine8.submarine_Damage_0 = Submarine_Damage.FromXML(ref theNode10, ref concurrentDictionary_0, ref theParentPlatform);
								break;
							}
							case "Status":
								if (!Versioned.IsNumeric((object)theNode10.InnerText))
								{
									theSub.Status = (_ActiveUnitStatus)Enum.Parse(typeof(_ActiveUnitStatus), theNode10.InnerText, ignoreCase: true);
								}
								else if (Conversions.ToByte(theNode10.InnerText) == 18)
								{
									flag2 = true;
								}
								else
								{
									theSub.Status = (_ActiveUnitStatus)Conversions.ToByte(theNode10.InnerText);
								}
								if (theSub.Status == (_ActiveUnitStatus)9)
								{
									theSub.Status = _ActiveUnitStatus.RTB;
								}
								break;
							case "AMP_OC_Speed":
								theSub._MissionPlannerOverrideCancellation_Speed = XmlConvert.ToSingle(theNode10.InnerText);
								break;
							case "Name":
								theSub.Name = theNode10.InnerText;
								break;
							case "FSBR":
								theSub._FuelStateBefore_NeedToRefuel = (_ActiveUnitFuelState)Conversions.ToByte(theNode10.InnerText);
								break;
							case "DesiredTurnRate_Navigation":
							case "DTN":
								theSub.DesiredTurnRate_Navigation = (Waypoint.TurnRateCategory)Conversions.ToByte(theNode10.InnerText);
								break;
							case "SBED_Altitude_TF":
								theSub._AltitudeBefore_EngagedDefensive_AGL = XmlConvert.ToSingle(theNode10.InnerText);
								break;
							case "SBPF_TF":
								theSub._TerrainFollowingBefore_WaitForPathfinder = Misc.ParseBool(theNode10.InnerText);
								break;
							case "AL":
								theSub.AutonomyLevel = (DroneAutonomyLevel)Conversions.ToInteger(theNode10.InnerText);
								break;
							case "TUW":
								theSub.TimeUnderway = XmlConvert.ToSingle(theNode10.InnerText.Replace(",", "."));
								break;
							case "FuelState":
								theSub._FuelState = (_ActiveUnitFuelState)Conversions.ToByte(theNode10.InnerText);
								break;
							case "DamagePts":
								if (!bool_3)
								{
									((ActiveUnit)theSub).set_DamagePts(ScenEditAction: false, (Weapon)null, XmlConvert.ToSingle(theNode10.InnerText));
								}
								break;
							case "Submarine_Kinematics":
								ActiveUnit_Kinematics.FromXML(theNode10, concurrentDictionary_0, theSub);
								break;
							case "SBED_Altitude":
								theSub._AltitudeBefore_EngagedDefensive = XmlConvert.ToSingle(theNode10.InnerText);
								break;
							case "OldDamagePercent":
								theSub._OldDamagePercent = XmlConvert.ToSingle(theNode10.InnerText);
								break;
							case "COA":
								theSub.ChanceOfAppearance = Conversions.ToInteger(theNode10.InnerText);
								break;
							case "AMP_OC_DAO":
								theSub._MissionPlannerOverrideCancellation_DesiredAltitudeOverride = Misc.ParseBool(theNode10.InnerText);
								break;
							case "Submarine_AI":
							{
								Submarine submarine7 = theSub;
								ActiveUnit theParentPlatform = theSub;
								submarine7.submarine_AI_0 = Submarine_AI.FromXML(ref theNode10, ref concurrentDictionary_0, ref theParentPlatform);
								break;
							}
							case "PrivateSnapshotMission":
								theSub.PrivateSnapshotMission = Mission.FromXML(ref theNode10, ref concurrentDictionary_0, ref scenario_0);
								break;
							case "DesiredHeading":
							case "DH":
								theSub.set_DesiredHeading(TurnRate.Max, XmlConvert.ToSingle(theNode10.InnerText));
								break;
							case "SBPF_ThrottleSetting":
								switch (theNode10.InnerText)
								{
								case "FullStop":
									theSub._ThrottleBefore_WaitForPathfinder = Throttle.FullStop;
									break;
								case "Loiter":
									theSub._ThrottleBefore_WaitForPathfinder = Throttle.Loiter;
									break;
								case "Cruise":
									theSub._ThrottleBefore_WaitForPathfinder = Throttle.Cruise;
									break;
								case "Full":
									theSub._ThrottleBefore_WaitForPathfinder = Throttle.Full;
									break;
								case "Flank":
									theSub._ThrottleBefore_WaitForPathfinder = Throttle.Flank;
									break;
								default:
									theSub._ThrottleBefore_WaitForPathfinder = (Throttle)Conversions.ToByte(theNode10.InnerText);
									break;
								}
								break;
							case "SBR":
								theSub._StatusBefore_NeedToRefuel = (_ActiveUnitStatus)Conversions.ToByte(theNode10.InnerText);
								break;
							case "SBR_Altitude_TF":
								theSub._AltitudeBefore_NeedToRefuel_AGL = XmlConvert.ToSingle(theNode10.InnerText);
								break;
							case "SBPF_Altitude_TF":
								theSub._AltitudeBefore_WaitForPathfinder_AGL = XmlConvert.ToSingle(theNode10.InnerText);
								break;
							case "SBED_DesiredSpeedOverride":
								theSub._DesiredSpeedOverrideBefore_EngagedDefensive = XmlConvert.ToSingle(theNode10.InnerText);
								break;
							case "ActiveUnit_AirOps":
							{
								Submarine submarine6 = theSub;
								ActiveUnit theParentPlatform = theSub;
								submarine6._AirOps = ActiveUnit_AirOps.FromXML(ref theNode10, ref concurrentDictionary_0, ref theParentPlatform);
								break;
							}
							case "ActiveEnterAreaTriggers":
								if (flag)
								{
									theSub.ActiveEnterAreaTriggers.Clear();
								}
								foreach (XmlNode childNode12 in theNode10.ChildNodes)
								{
									string innerText2 = childNode12.InnerText;
									theSub.ActiveEnterAreaTriggers.Add(innerText2);
								}
								break;
							case "SBED_ThrottleSetting":
								switch (theNode10.InnerText)
								{
								case "Cruise":
									theSub._ThrottleBefore_EngagedDefensive = Throttle.Cruise;
									break;
								case "Full":
									theSub._ThrottleBefore_EngagedDefensive = Throttle.Full;
									break;
								default:
									theSub._ThrottleBefore_EngagedDefensive = (Throttle)Conversions.ToByte(theNode10.InnerText);
									break;
								case "Flank":
									theSub._ThrottleBefore_EngagedDefensive = Throttle.Flank;
									break;
								case "Loiter":
									theSub._ThrottleBefore_EngagedDefensive = Throttle.Loiter;
									break;
								case "FullStop":
									theSub._ThrottleBefore_EngagedDefensive = Throttle.FullStop;
									break;
								}
								break;
							case "ThrottleSetting":
								switch (theNode10.InnerText)
								{
								case "FullStop":
									theSub.ThrottleSetting = Throttle.FullStop;
									break;
								case "Cruise":
									theSub.ThrottleSetting = Throttle.Cruise;
									break;
								case "Full":
									theSub.ThrottleSetting = Throttle.Full;
									break;
								case "Flank":
									theSub.ThrottleSetting = Throttle.Flank;
									break;
								default:
									theSub.ThrottleSetting = (Throttle)Conversions.ToByte(theNode10.InnerText);
									break;
								case "Loiter":
									theSub.ThrottleSetting = Throttle.Loiter;
									break;
								}
								break;
							case "WeaponState":
								theSub._WeaponState = (_ActiveUnitWeaponState)Conversions.ToSByte(theNode10.InnerText);
								break;
							case "Prof":
								theSub.Proficiency = (GlobalVariables.ProficiencyLevel)Conversions.ToInteger(theNode10.InnerText);
								break;
							case "Doctrine":
								if (!flag)
								{
									theSub.Doctrine = Doctrine.FromXML(scenario_0, ref theNode10, theSub);
								}
								else
								{
									theSub.Doctrine = Doctrine.FromXML(scenario_0, ref theNode10, theSub, theSub.Doctrine);
								}
								break;
							case "SBEO_TF":
								theSub._TerrainFollowingBefore_EngagedOffensive = Misc.ParseBool(theNode10.InnerText);
								break;
							case "SBED_TF":
								theSub._TerrainFollowingBefore_EngagedDefensive = Misc.ParseBool(theNode10.InnerText);
								break;
							case "OODA_E":
								theSub.HasCustomOODA = true;
								theSub.OODA_Evasion = Conversions.ToShort(theNode10.InnerText);
								break;
							case "AMP_OC_DSO":
								theSub._MissionPlannerOverrideCancellation_DesiredSpeedOverride = XmlConvert.ToSingle(theNode10.InnerText);
								break;
							case "Submarine_Weaponry":
							{
								Submarine submarine5 = theSub;
								ActiveUnit theParentPlatform = theSub;
								submarine5.submarine_Weaponry_0 = Submarine_Weaponry.FromXML(ref theNode10, ref concurrentDictionary_0, ref theParentPlatform);
								break;
							}
							case "Latitude_UnitEntersAreaCheck":
								theSub.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(theNode10.InnerText);
								break;
							case "OODA_D":
								theSub.HasCustomOODA = true;
								theSub.OODA_Detection = Conversions.ToShort(theNode10.InnerText);
								break;
							case "DA":
							case "DesiredAltitude":
								theSub.DesiredAltitude = XmlConvert.ToSingle(theNode10.InnerText);
								break;
							case "CurrentAltitude":
							case "CA":
								theSub.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, XmlConvert.ToSingle(theNode10.InnerText));
								break;
							case "OODA_T":
								theSub.HasCustomOODA = true;
								theSub.OODA_Targeting = Conversions.ToShort(theNode10.InnerText);
								break;
							case "AssignedMission":
								if (theNode10.HasChildNodes)
								{
									XmlNode val3 = theNode10.ChildNodes[0];
									theSub._AssignedMissionOrPackage_ID = val3.InnerText;
								}
								break;
							case "ActiveRemainAreaTriggers":
							{
								if (flag)
								{
									theSub.ActiveRemainAreaTriggers.Clear();
								}
								string key = null;
								DateTime result2 = DateTime.MinValue;
								foreach (XmlNode childNode13 in theNode10.ChildNodes)
								{
									XmlNode val2 = childNode13;
									if (Operators.CompareString(val2.Name, "RemainAreaTrigger", false) != 0)
									{
										if (DateTime.TryParse(val2.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.None, out result2))
										{
											theSub.ActiveRemainAreaTriggers.Add(key, result2);
											continue;
										}
										string innerText = val2.InnerText;
										long result3 = default(long);
										if (long.TryParse(innerText, out result3))
										{
											result2 = DateTime.FromBinary(Conversions.ToLong(val2.InnerText));
											theSub.ActiveRemainAreaTriggers.Add(key, result2);
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
							case "Sensory":
							{
								Submarine submarine4 = theSub;
								ActiveUnit theParentPlatform = theSub;
								submarine4.submarine_Sensory_0 = Submarine_Sensory.FromXML(ref theNode10, ref concurrentDictionary_0, ref theParentPlatform);
								break;
							}
							case "EFSAR":
								theSub.EligibleForSAR = Misc.ParseBool(theNode10.InnerText);
								break;
							case "CustomIcon":
								theSub.CustomIcon = theNode10.InnerText;
								break;
							case "Side":
								theSub._SideName = theNode10.InnerText;
								break;
							case "Longitude":
							case "Lon":
								((ActiveUnit)theSub).set_Longitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(theNode10.InnerText));
								break;
							case "DS":
							case "DesiredSpeed":
								theSub.DesiredSpeed = XmlConvert.ToSingle(theNode10.InnerText);
								break;
							case "IBPU":
								theSub.IsBeingPickedUp = Misc.ParseBool(theNode10.InnerText);
								break;
							case "Submarine_CommStuff":
							{
								Submarine submarine3 = theSub;
								ActiveUnit theParentPlatform = theSub;
								submarine3.submarine_CommStuff_0 = Submarine_CommStuff.FromXML(ref theNode10, ref concurrentDictionary_0, ref theParentPlatform);
								break;
							}
							case "SBEO_Altitude":
								theSub._AltitudeBefore_EngagedOffensive = XmlConvert.ToSingle(theNode10.InnerText);
								break;
							case "SBPF_Altitude":
								theSub._AltitudeBefore_WaitForPathfinder = XmlConvert.ToSingle(theNode10.InnerText);
								break;
							case "Message":
								theSub.Message = theNode10.InnerText;
								break;
							case "SBEO_Altitude_TF":
								theSub._AltitudeBefore_EngagedOffensive_AGL = XmlConvert.ToSingle(theNode10.InnerText);
								break;
							case "AssignedTaskPool":
								if (theNode10.HasChildNodes)
								{
									XmlNode val = theNode10.ChildNodes[0];
									theSub._AssignedTaskPool_ID = val.InnerText;
								}
								break;
							case "Latitude":
							case "Lat":
								((ActiveUnit)theSub).set_Latitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(theNode10.InnerText));
								break;
							case "SBR_ThrottleSetting":
								switch (theNode10.InnerText)
								{
								case "Loiter":
									theSub._ThrottleBefore_NeedToRefuel = Throttle.Loiter;
									break;
								case "Cruise":
									theSub._ThrottleBefore_NeedToRefuel = Throttle.Cruise;
									break;
								default:
									theSub._ThrottleBefore_NeedToRefuel = (Throttle)Conversions.ToByte(theNode10.InnerText);
									break;
								case "Flank":
									theSub._ThrottleBefore_NeedToRefuel = Throttle.Flank;
									break;
								case "Full":
									theSub._ThrottleBefore_NeedToRefuel = Throttle.Full;
									break;
								case "FullStop":
									theSub._ThrottleBefore_NeedToRefuel = Throttle.FullStop;
									break;
								}
								break;
							case "AMP_OC":
								theSub._MissionPlannerOverrideCancellation = Misc.ParseBool(theNode10.InnerText);
								break;
							case "SBR_Altitude":
								theSub._AltitudeBefore_NeedToRefuel = XmlConvert.ToSingle(theNode10.InnerText);
								break;
							case "ActiveUnit_DockingOps":
							{
								Submarine submarine2 = theSub;
								ActiveUnit theParentPlatform = theSub;
								submarine2.DockingOps = ActiveUnit_DockingOps.FromXML(ref theNode10, ref concurrentDictionary_0, ref theParentPlatform);
								break;
							}
							case "SBR_TF":
								theSub._TerrainFollowingBefore_NeedToRefuel = Misc.ParseBool(theNode10.InnerText);
								break;
							case "SBEO":
								theSub._StatusBefore_EngagedOffensive = (_ActiveUnitStatus)Conversions.ToByte(theNode10.InnerText);
								break;
							case "SBED":
								theSub._StatusBefore_EngagedDefensive = (_ActiveUnitStatus)Conversions.ToByte(theNode10.InnerText);
								break;
							case "DT":
							case "DesiredTurnRate":
								theSub.DesiredTurnRate = (TurnRate)Conversions.ToByte(theNode10.InnerText);
								break;
							case "CS":
							case "CurrentSpeed":
								theSub.CurrentSpeed = XmlConvert.ToSingle(theNode10.InnerText);
								break;
							case "Longitude_UnitEntersAreaCheck":
								theSub.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(theNode10.InnerText);
								break;
							case "ParentGroup":
								theSub._ParentGroup_ID = theNode10.InnerText;
								break;
							case "SBEO_ThrottleSetting":
								switch (theNode10.InnerText)
								{
								case "FullStop":
									theSub._ThrottleBefore_EngagedOffensive = Throttle.FullStop;
									break;
								case "Full":
									theSub._ThrottleBefore_EngagedOffensive = Throttle.Full;
									break;
								case "Flank":
									theSub._ThrottleBefore_EngagedOffensive = Throttle.Flank;
									break;
								default:
									theSub._ThrottleBefore_EngagedOffensive = (Throttle)Conversions.ToByte(theNode10.InnerText);
									break;
								case "Cruise":
									theSub._ThrottleBefore_EngagedOffensive = Throttle.Cruise;
									break;
								case "Loiter":
									theSub._ThrottleBefore_EngagedOffensive = Throttle.Loiter;
									break;
								}
								break;
							case "CH":
							case "CurrentHeading":
								theSub.CurrentHeading = XmlConvert.ToSingle(theNode10.InnerText);
								break;
							case "Submarine_Navigator":
							{
								Submarine submarine = theSub;
								ActiveUnit theParentPlatform = theSub;
								submarine.submarine_Navigator_0 = Submarine_Navigator.FromXML(ref theNode10, ref concurrentDictionary_0, ref theParentPlatform);
								break;
							}
							case "IsAD":
							case "IsAutoDetectable":
								((ActiveUnit)theSub).set_IsAutoDetectable((Side)null, Misc.ParseBool(theNode10.InnerText));
								break;
							}
						}
						else
						{
							theSub.LastReportedInfoFromXMLField(theNode10.Name, theNode10.InnerText);
						}
					}
					float maximumAltitude = theSub.Kinematics.GetMaximumAltitude();
					float minimumAltitude = theSub.Kinematics.GetMinimumAltitude();
					if (theSub.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > maximumAltitude)
					{
						theSub.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, maximumAltitude);
					}
					else if (theSub.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < minimumAltitude)
					{
						theSub.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, minimumAltitude);
					}
					if (theSub.DesiredAltitude > maximumAltitude)
					{
						theSub.DesiredAltitude = maximumAltitude;
					}
					else if (theSub.DesiredAltitude < minimumAltitude)
					{
						theSub.DesiredAltitude = minimumAltitude;
					}
					if (flag2)
					{
						theSub.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries;
					}
					result = theSub;
				}
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100800", "");
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

	internal bool IsCavitating()
	{
		if (CurrentSpeed > 0f)
		{
			return DesiredSpeed >= (float)Kinematics.CavitationSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		}
		return false;
	}

	bool IBoat.IsCavitating()
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsCavitating
		return this.IsCavitating();
	}

	public override void DoTypeSpecificActions(float elapsedTime, ref LockRandom theRNG)
	{
		try
		{
			if ((Type == _SubmarineType.ROV || Type == _SubmarineType.UUV) && ActiveMissionOrPackage() != null && ActiveMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing && IsOperating() && base.HasMineDisposalCharges)
			{
				bool flag = false;
				foreach (Sensor mineCountermeasure in MineCountermeasures)
				{
					if (mineCountermeasure.IsExplosiveMineNeutralizer && mineCountermeasure.Status == PlatformComponent._ComponentStatus.Operational)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					WeaponState = _ActiveUnitWeaponState.IsWinchester;
					DockingOps.AttemptToRTB(ManuallyOrdered: false, _ActiveUnitStatus.RTB, GroupMembersRTB: false, _ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
					return;
				}
			}
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100804", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void PostDeserializationHousekeeping_General(ref Scenario theScen, ConcurrentDictionary<string, ScenarioObject> theDictionary, List<ActiveUnit> DiscardList, bool GameIsRunning)
	{
		base.PostDeserializationHousekeeping_General(ref theScen, theDictionary, DiscardList, GameIsRunning);
		ActiveUnit_DockingOps.PostDeserializationHousekeeping(DockingOps, ref theScen, theDictionary, GameIsRunning);
	}

	public override void SetThrottle(Throttle newThrottleSetting, float? SpecificDesiredSpeed = null)
	{
		try
		{
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
					DesiredSpeed = Kinematics.GetMaximumSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), newThrottleSetting, ValidateAndFixAltitude: false);
				}
				else
				{
					DesiredSpeed = SpecificDesiredSpeed.Value;
				}
			}
			RaiseEvent_ChangedThrottleSetting(this, newThrottleSetting);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200583", ex2.Message);
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
					goto IL_0085;
				}
				Patrol patrol = (Patrol)ActiveMissionOrPackage();
				if (!((Module_Unit.Unit)this).get_IsInsideThisArea(patrol.ProsecutionArea, ParentScen, UseCache: true) || GeoPoint.IsInsideThisArea(theLat, theLon, patrol.ProsecutionArea))
				{
					goto IL_0085;
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
			IL_0085:
			if (CheckDistanceToNoNavZones)
			{
				CheckNoNavZones = DistanceToNearestNoNavZone();
			}
			if (GeoPoint.get_IsInCanal(theLat, theLon))
			{
				CheckNoNavZones = false;
				CheckForMines = false;
				result = true;
			}
			else if ((CheckNoNavZones || IsPathfindingQuery) && IsInsideNoNavZones(theLat, theLon, ProximityThreshold_Deg))
			{
				CheckNoNavZones = true;
				CheckForMines = false;
				UserFeedback = "The point is inside a No-Nav Zone.";
				result = false;
			}
			else if (GeoPoint.IsInPierLane(theLat, theLon, ParentScen))
			{
				CheckNoNavZones = false;
				CheckForMines = false;
				result = true;
			}
			else if (method_16(theLat, theLon, IsPathfindingQuery, UsePathfindingBufferDistance, IgnoreMinesBehindUs, CheckForIcepack, ref CheckForMines, ProvidedElevation, ref UserFeedback, ref AllowBounce))
			{
				CheckNoNavZones = false;
				CheckForMines = false;
				result = true;
			}
			else
			{
				CheckNoNavZones = false;
				CheckForMines = false;
				result = false;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200283", ex2.Message);
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

	public override void Destroy(bool ScenEditAction, bool IsAimpointFacility, bool DestroyUnitNow, string theReason, string WhatCausedIt = null, bool RegisterAsLosses = true)
	{
		try
		{
			IsBeingDestroyed = true;
			DockingOps.HostDockFacility = null;
			if (!IsOperating() && !ScenEditAction)
			{
				ParentScen.AddMessage(Name + " has been destroyed!", Name + " is destroyed!", LoggedMessage.MessageType.UnitLost, 0, ObjectID, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			PreDestructionHousekeeping(ScenEditAction, TriggeredBySinking: false, Damage.DamagePercent, DestroyUnitNow, RegisterAsLosses);
			Side[] sides_ReadOnly = ParentScen.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
			{
				sides_ReadOnly[i].HandleUnitDestruction(this, ScenEditAction);
			}
			foreach (Weapon item in ParentScen.AllWeaponsAlive)
			{
				List<Contact> list = new List<Contact>();
				Contact[] targets_ReadOnly = ((ActiveUnit)item).AI.Targets_ReadOnly;
				foreach (Contact contact in targets_ReadOnly)
				{
					if (contact.ActualUnit == this)
					{
						list.Add(contact);
					}
				}
				foreach (Contact item2 in list)
				{
					((ActiveUnit)item).AI.DropTarget(item2);
				}
			}
			if (DockFacilities_ReadOnly.Length > 0)
			{
				foreach (ActiveUnit item3 in DockingOps.EmbarkedBoats_ReadOnly)
				{
					item3.Destroy(ScenEditAction, IsAimpointFacility, DestroyUnitNow, "Destroyed as the object it is docked to is being destroyed", "Host Destruction");
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
				ParentScen.DestroyThisUnit(this, theReason);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100807", "");
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

	public override void Determine_IsMCMPlatform()
	{
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

	private bool method_16(double double_0, double double_1, bool bool_3, bool bool_4, bool bool_5, bool bool_6, ref bool bool_7, short? nullable_17, ref string string_4, ref bool bool_8)
	{
		bool result;
		short num;
		int num2;
		if (!nullable_17.HasValue)
		{
			(bool, short?) tuple = Terrain.PointIsOverland(double_0, double_1);
			if (tuple.Item1)
			{
				result = false;
				goto IL_01cc;
			}
			if (!tuple.Item2.HasValue)
			{
				num = Terrain.GetElevation(double_0, double_1, RequestIsFromGUI: false, ParentScen);
				num2 = -10;
			}
			else
			{
				num = tuple.Item2.Value;
				num2 = -10;
			}
		}
		else
		{
			num = nullable_17.Value;
			num2 = -10;
		}
		short num3 = (short)num2;
		try
		{
			int num4;
			if (num > num3)
			{
				bool_8 = false;
				result = false;
			}
			else
			{
				if (!bool_7)
				{
					num4 = 1;
					goto IL_0180;
				}
				bool flag = false;
				if (this.get_SafeDistanceAgainstUnknownMine_meters(bool_4) > 0 && ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Contacts_NonAU.Count > 0)
				{
					foreach (string item in ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Contacts_NonAU)
					{
						UnguidedWeapon value = null;
						ParentScen.UnguidedWeapons.TryGetValue(item, out value);
						if (value == null || !value.IsMine)
						{
							continue;
						}
						short num5 = (short)((ActiveUnit)this).get_SafeDistanceAgainstKnownMineType_meters(value.Type, bool_4);
						if (!bool_3)
						{
							if (bool_5)
							{
								continue;
							}
							UnguidedWeapon myUnit = value;
							string feedbackMessage = "";
							if (!(Math.Abs(Module_Unit.AngleOffThisUnitsBoresight(myUnit, this, DistinguishBetweenStarboardAndPort: true, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)) <= 45f))
							{
								continue;
							}
						}
						if (!(Math2.CalcDist(double_0, double_1, ((Module_Unit.Unit)value).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)value).get_Longitude((GlobalVariables.BooleanObject)null)) * 1852f >= (float)num5))
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					num4 = 1;
					goto IL_0180;
				}
				bool_7 = true;
				string_4 = "A mine is too close.";
				result = false;
			}
			goto end_IL_005d;
			IL_0180:
			result = (byte)num4 != 0;
			end_IL_005d:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100808", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			string_4 = "Error!";
			result = false;
			ProjectData.ClearProjectError();
		}
		goto IL_01cc;
		IL_01cc:
		return result;
	}

	public Submarine(ref Scenario theScen, string theGUID = null)
		: base(ref theScen, theGUID)
	{
		Flags = default(_Flags);
		PressureHull = new PressureHull(this);
		Rudder = new Rudder(this);
		CIC = new CIC(this, "Conn / CIC");
		Cargo = new Cargo(this);
		ActiveUnit theUnit = this;
		submarine_AI_0 = new Submarine_AI(ref theUnit);
		IsSubmarine = true;
		IsBoat = true;
		UnitType = GlobalVariables.ActiveUnitType.Submarine;
	}

	public ActiveUnit_CommStuff.ReasonForGoingOffGrid? ReasonForGoingOffGridDueToDepth()
	{
		return (IsTetheredROV || IsBiological || IsFalseTarget || !ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticSubComms)) ? ((ActiveUnit_CommStuff.ReasonForGoingOffGrid?)null) : ((this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= (float)CommsEstablishDepth && CommStuff.CommsDeviceAvailable && CommStuff.ReasonForBeingOffGrid != ActiveUnit_CommStuff.ReasonForGoingOffGrid.ChangeOfInternalStatus) ? new ActiveUnit_CommStuff.ReasonForGoingOffGrid?(ActiveUnit_CommStuff.ReasonForGoingOffGrid.None) : (CommStuff.CommsDeviceAvailable ? new ActiveUnit_CommStuff.ReasonForGoingOffGrid?(ActiveUnit_CommStuff.ReasonForGoingOffGrid.DivingDeep) : new ActiveUnit_CommStuff.ReasonForGoingOffGrid?(ActiveUnit_CommStuff.ReasonForGoingOffGrid.AllCommDevicesDisabled)));
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
				else if (((Submarine)activeUnits_).Type == _SubmarineType.UUV && activeUnits_.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: true) == this)
				{
					Mission.MissionAssignmentAttemptResult Result2 = Mission.MissionAssignmentAttemptResult.None;
					activeUnits_.Set_AssignedMissionOrPackage(value, SetMissionOnly, IgnoreCommsState, ref Result2);
				}
			}
			if (value != null && value.Doctrine.EMCON(ParentScen).Radar() == Doctrine.EMCONSettings._EMCONSetting.Active && Doctrine.EMCON_Inherits && Doctrine.EMCON(ParentScen).Radar() != Doctrine.EMCONSettings._EMCONSetting.Active)
			{
				Doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Passive, ParentScen);
				AddMessage("Submarine: " + Name + " was assigned to mission: " + value.Name + " which includes radar EMCON Active. Because the submarine is set to inherit this setting, and to avoid radiating at periscope or shallower depth, the submarine will override this EMCON directive and switch to passive instead. If you do indeed wish for this submarine to radiate, you must manually enforce this EMCON.", "Submarine: " + Name + " was assigned to mission: " + value.Name + " which includes radar EMCON Active.", LoggedMessage.MessageType.SpecialMessage, 0);
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

	public override void DoFuelConsumption(float elapsedTime)
	{
		try
		{
			if (IsNuke || Fuel_ReadOnly.Count == 0 || (ThrottleSetting == Throttle.FullStop && IsNuke))
			{
				return;
			}
			SelectedEngines = AI.SelectEngines();
			_Closure$__137-0 closure$__137- = default(_Closure$__137-0);
			FuelRec fuelRec = default(FuelRec);
			foreach (KeyValuePair<int, Engine> selectedEngine in SelectedEngines)
			{
				closure$__137- = new _Closure$__137-0(closure$__137-);
				Engine value = selectedEngine.Value;
				int key = selectedEngine.Key;
				closure$__137-.$VB$Local_FuelTypeToConsume = AI.SelectFuelTypeToConsume(value);
				if (closure$__137-.$VB$Local_FuelTypeToConsume != FuelRec._FuelType.Battery)
				{
					if ((from theRec in Fuel_ReadOnly.Where(closure$__137-._Lambda$__0)
						select (theRec)).ElementAtOrDefault(0).CurrentQuantity == 0f)
					{
						continue;
					}
					if (fuelRec == null)
					{
						fuelRec = (from theRec in Fuel_ReadOnly
							where theRec.FuelType == FuelRec._FuelType.Battery
							select (theRec)).ElementAtOrDefault(0);
					}
					if (fuelRec != null && fuelRec.PercentFull >= 1f)
					{
						continue;
					}
				}
				float num = ((closure$__137-.$VB$Local_FuelTypeToConsume != FuelRec._FuelType.AirIndepedent) ? method_17(ThrottleSetting, null, (int)Math.Round(DesiredSpeed), this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), value, key) : method_17(Throttle.Loiter, null, null, null, value, key));
				float theQuantity = num * elapsedTime;
				Fuel_Subtract(theQuantity, closure$__137-.$VB$Local_FuelTypeToConsume);
				if (value.Type == Engine.EngineType.Diesel)
				{
					RechargeBatteries(value, fuelRec, elapsedTime);
				}
				else if (value.Type == Engine.EngineType.AIP)
				{
					RechargeBatteries(value, fuelRec, elapsedTime);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100809", "");
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
			FuelRec fuelRec = (from theRec in Fuel_ReadOnly
				where theRec.FuelType == theType
				select (theRec)).ElementAtOrDefault(0);
			if (fuelRec.CurrentQuantity > theQuantity)
			{
				fuelRec.SubtractFuel(theQuantity);
				return;
			}
			bool flag = fuelRec.CurrentQuantity > 0f;
			fuelRec.CurrentQuantity = 0f;
			if (Fuel_ReadOnly.Where([SpecialName] (FuelRec theFR) => theFR.CurrentQuantity > 0f).Count() == 0)
			{
				SetThrottle(Throttle.FullStop);
				if (flag)
				{
					AddMessage(Name + " (" + Misc.RemoveHiddenString(UnitClass) + ") has run out of fuel and lies dead in the water!", Name + " ran out of fuel!", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
					Kinematics.DesiredSpeedOverride = null;
				}
			}
			else if (flag)
			{
				SetThrottle(Throttle.Loiter);
				AddMessage(Name + " (" + Misc.RemoveHiddenString(UnitClass) + ") has run out of fuel, attempting to use alternative propulsion.", Name + " switching propulsion", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
				Kinematics.DesiredSpeedOverride = null;
				Kinematics.DesiredAltitudeOverride = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100810", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void StopRechargingBatteries()
	{
		if (DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
		{
			DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Underway;
		}
	}

	public void RechargeBatteries(Engine theEngine, FuelRec BatteryFuel, float elapsedTime)
	{
		try
		{
			if (BatteryFuel == null || (theEngine.Type == Engine.EngineType.Diesel && Math.Round(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < -20.0) || (theEngine.Type != Engine.EngineType.Diesel && theEngine.Type != Engine.EngineType.AIP))
			{
				return;
			}
			if (theEngine.Type == Engine.EngineType.Diesel && !Flags.HasSnorkel && !IsSurfaced)
			{
				StopRechargingBatteries();
				return;
			}
			float num = default(float);
			if (theEngine.Type == Engine.EngineType.Diesel)
			{
				if (DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
				{
					DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries;
				}
				num = (float)((double)BatteryFuel.MaxQuantity / 60.0 / 8.0);
				if (Flags.UsesLiOnBattery)
				{
					num = (float)(1.25 * (double)num);
				}
				float num2 = BatteryFuel.CurrentQuantity / (float)BatteryFuel.MaxQuantity;
				num = ((num2 < 0.25f) ? (num * 2f) : ((num2 < 0.5f) ? ((float)((double)num * 1.5)) : ((!(num2 < 0.75f)) ? ((float)((double)num * 0.5)) : ((float)((double)num * 0.77)))));
			}
			else if (theEngine.Type == Engine.EngineType.AIP)
			{
				Engine engine = Propulsion.Where([SpecialName] (Engine theE) => theE.Type == Engine.EngineType.Electric).ElementAtOrDefault(0);
				if (engine == null)
				{
					engine = Propulsion.Where([SpecialName] (Engine theE) => theE.Type == Engine.EngineType.AIP).ElementAtOrDefault(0);
				}
				num = ((engine == null) ? 1f : ((!(engine.AltBands[0].Consumption_Loiter > 0f)) ? 1f : engine.AltBands[0].Consumption_Loiter));
				if (BatteryFuel.CurrentQuantity <= 0f)
				{
					BatteryFuel.CurrentQuantity = 0.0001f;
				}
			}
			if (theEngine.Status == PlatformComponent._ComponentStatus.Damaged)
			{
				num /= 2f;
			}
			BatteryFuel.CurrentQuantity += num / 60f * elapsedTime;
			if (BatteryFuel.CurrentQuantity > (float)BatteryFuel.MaxQuantity)
			{
				BatteryFuel.CurrentQuantity = BatteryFuel.MaxQuantity;
			}
			if (BatteryFuel.CurrentQuantity == (float)BatteryFuel.MaxQuantity)
			{
				StopRechargingBatteries();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100811", "");
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
		if (!IsNuke && !IsBiological)
		{
			return method_17(theThrottleSetting, null, (int)Math.Round(DesiredSpeed), this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), PrimaryEngine, PrimaryEngineNo);
		}
		return 0f;
	}

	private float method_17(Throttle throttle_0, AltBand altBand_0, float? nullable_17, float? nullable_18, Engine engine_1, int int_6)
	{
		float result;
		if (!IsNuke && !IsBiological)
		{
			if (engine_1 != null)
			{
				if (Propulsion.Count == 0)
				{
					result = 0f;
				}
				else
				{
					AltBand altBand = null;
					AltBand altBand2 = null;
					try
					{
						if (engine_1.Status == PlatformComponent._ComponentStatus.Destroyed)
						{
							result = 0f;
						}
						else if (engine_1.AltBands.Length != 0)
						{
							altBand = ((altBand_0 != null) ? altBand_0 : (nullable_18.HasValue ? Kinematics.GetCurrentAltBand_CurrentAltitude(nullable_18.Value, engine_1, ValidateAndFixAltitude: false) : Kinematics.GetCurrentAltBand(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ValidateAndFixAltitude: false)));
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
							float num6;
							float? consumption_Flank;
							switch (throttle_0)
							{
							default:
								result = 0f;
								goto end_IL_003a;
							case Throttle.FullStop:
								result = 0f;
								goto end_IL_003a;
							case Throttle.Loiter:
								num = altBand.Consumption_Loiter;
								num2 = 0f;
								goto IL_0252;
							case Throttle.Cruise:
								if (engine_1.AltBands[0].Consumption_Cruise > 0f)
								{
									num = altBand.Consumption_Cruise;
									num2 = altBand.Consumption_Loiter;
									goto IL_0252;
								}
								result = method_17(Throttle.Loiter, altBand_0, nullable_17, nullable_18, engine_1, int_6);
								goto end_IL_003a;
							case Throttle.Full:
								if (altBand.Speed_Full.HasValue)
								{
									consumption_Flank = engine_1.AltBands[0].Consumption_Full;
									if ((consumption_Flank.HasValue ? new bool?(consumption_Flank.GetValueOrDefault() > 0f) : ((bool?)null)) == true)
									{
										num = altBand.Consumption_Full.Value;
										_ = (float)altBand.Speed_Full.Value;
										num2 = altBand.Consumption_Cruise;
										goto IL_0252;
									}
								}
								result = method_17(Throttle.Cruise, altBand_0, nullable_17, nullable_18, engine_1, int_6);
								goto end_IL_003a;
							case Throttle.Flank:
								{
									if (!altBand.Speed_Flank.HasValue)
									{
										break;
									}
									consumption_Flank = engine_1.AltBands[0].Consumption_Flank;
									if ((consumption_Flank.HasValue ? new bool?(consumption_Flank.GetValueOrDefault() > 0f) : ((bool?)null)) != true)
									{
										break;
									}
									num = altBand.Consumption_Flank.Value;
									_ = (float)altBand.Speed_Flank.Value;
									num2 = ((!altBand.Speed_Full.HasValue) ? altBand.Consumption_Cruise : altBand.Consumption_Full.Value);
									goto IL_0252;
								}
								IL_05a3:
								result = num3 / 60f;
								goto end_IL_003a;
								IL_0252:
								num3 = num;
								if (!nullable_17.HasValue || !nullable_18.HasValue)
								{
									goto IL_05a3;
								}
								if (altBand == Kinematics.HighestAltBand(engine_1))
								{
									goto IL_0482;
								}
								if (engine_1.AltBands.Length != 0)
								{
									altBand2 = Kinematics.HighestAltBand(engine_1);
									float num4;
									float num5;
									switch (throttle_0)
									{
									default:
										result = 0f;
										goto end_IL_003a;
									case Throttle.FullStop:
										num4 = 0f;
										num5 = 0f;
										goto IL_03a6;
									case Throttle.Loiter:
										num4 = altBand2.Consumption_Loiter;
										num5 = 0f;
										goto IL_03a6;
									case Throttle.Cruise:
										num4 = altBand2.Consumption_Cruise;
										num5 = altBand2.Consumption_Loiter;
										goto IL_03a6;
									case Throttle.Full:
										if (!altBand2.Speed_Full.HasValue)
										{
											throw new Exception("Submarine has full throttle but no fuel consumption params exist in database!");
										}
										num4 = altBand2.Consumption_Full.Value;
										_ = (float)altBand2.Speed_Full.Value;
										num5 = altBand2.Consumption_Cruise;
										goto IL_03a6;
									case Throttle.Flank:
										{
											if (!altBand2.Speed_Flank.HasValue)
											{
												num4 = num;
												num5 = num2;
											}
											else
											{
												num4 = altBand2.Consumption_Flank.Value;
												_ = (float)altBand2.Speed_Flank.Value;
												num5 = ((!altBand2.Speed_Full.HasValue) ? altBand2.Consumption_Cruise : altBand2.Consumption_Full.Value);
											}
											goto IL_03a6;
										}
										IL_03a6:
										if (num4 != num)
										{
											consumption_Flank = nullable_18;
											float minAlt = altBand.MinAlt;
											if ((consumption_Flank.HasValue ? new bool?(consumption_Flank.GetValueOrDefault() != minAlt) : ((bool?)null)) == true)
											{
												float value = ((nullable_18 - altBand.MinAlt) / (altBand.MaxAlt - altBand.MinAlt)).Value;
												value = Math.Abs(value);
												num += (num4 - num) * value;
												num3 = num;
												num2 += (num5 - num2) * value;
											}
										}
										break;
									}
									goto IL_0482;
								}
								result = 0f;
								goto end_IL_003a;
								IL_0482:
								num6 = Kinematics.GetMaximumSpeed(nullable_18.Value, throttle_0, engine_1, int_6, ValidateAndFixAltitude: false);
								consumption_Flank = nullable_17;
								if ((consumption_Flank.HasValue ? new bool?(consumption_Flank.GetValueOrDefault() < num6) : ((bool?)null)) == true)
								{
									float num7 = Kinematics.GetMaximumSpeed(nullable_18.Value, throttle_0 - 1, engine_1, int_6, ValidateAndFixAltitude: false);
									consumption_Flank = nullable_17;
									float value2;
									if (((!consumption_Flank.HasValue) ? ((bool?)null) : new bool?(consumption_Flank.GetValueOrDefault() >= num7)) == true)
									{
										value2 = ((nullable_17 - num7) / (num6 - num7)).Value;
										value2 = Math.Abs(value2);
									}
									else
									{
										value2 = 0f;
									}
									num3 = num2 + (num - num2) * value2;
								}
								goto IL_05a3;
							}
							result = method_17(Throttle.Full, altBand_0, nullable_17, nullable_18, engine_1, int_6);
						}
						else
						{
							result = 0f;
						}
						end_IL_003a:;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200349", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						result = 0.001f;
						ProjectData.ClearProjectError();
					}
				}
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
		return result;
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

	public override void ActualHorizMovement(float elapsedTime, bool SimplifiedCalcs_DLZ)
	{
		if (CurrentSpeed == 0f)
		{
			return;
		}
		Longitude_old = ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null);
		Latitude_old = ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null);
		try
		{
			float num = ((Module_Unit.Unit)this).get_HorizMovementDistanceOnThisTime(elapsedTime);
			double out_lon = default(double);
			double out_lat = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(Longitude_old, Latitude_old, ref out_lon, ref out_lat, num, CurrentHeading);
			if (double.IsNaN(out_lat))
			{
				out_lat = Latitude_old;
			}
			if (double.IsNaN(out_lon))
			{
				out_lon = Longitude_old;
			}
			if (IsPlatform)
			{
				bool CheckForMines = false;
				bool CheckNoNavZones = true;
				bool AllowBounce = true;
				double theLat = out_lat;
				double theLon = out_lon;
				int MovementCost = 0;
				string UserFeedback = "";
				List<ActiveUnit> ProvidedPiers = default(List<ActiveUnit>);
				if (CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: true, ref UserFeedback, ref AllowBounce))
				{
					((ActiveUnit)this).set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
					((ActiveUnit)this).set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
					if (ParentScen.MinuteIsChangingOnThisPulse)
					{
						Navigator.GetNearestAccessibleSpotHeading = null;
					}
				}
				else if (!CheckForMines && !CheckNoNavZones)
				{
					double latitude_old = Latitude_old;
					double longitude_old = Longitude_old;
					MovementCost = 0;
					UserFeedback = "";
					if (!CanMoveToThisLocation(latitude_old, longitude_old, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: true, ref UserFeedback, ref AllowBounce))
					{
						if (Navigator.GetNearestAccessibleSpot(((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), ref out_lat, ref out_lon, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, 0f, ref ProvidedPiers, ManouverTowardsTarget: false))
						{
							Navigator.GetNearestAccessibleSpotHeading = Math2.CalcAzimuth(((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon);
							CurrentHeading = Navigator.GetNearestAccessibleSpotHeading.Value;
						}
					}
					else
					{
						CurrentHeading = Bounce(CurrentHeading, num, bool_0: false);
						Geodesic_EdWilliams.CalcPoint_Williams(((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, num, CurrentHeading);
						if (ParentScen.MinuteIsChangingOnThisPulse)
						{
							double theLat2 = out_lat;
							double theLon2 = out_lon;
							MovementCost = 0;
							bool CheckNoNavZones2 = false;
							UserFeedback = "";
							bool AllowBounce2 = false;
							double DestLat = default(double);
							double DestLon = default(double);
							if (!CanMoveToThisLocation(theLat2, theLon2, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref CheckNoNavZones2, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce2) && Navigator.GetNearestAccessibleSpot(((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), ref DestLat, ref DestLon, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, 0f, ref ProvidedPiers, ManouverTowardsTarget: false))
							{
								out_lat = DestLat;
								out_lon = DestLon;
							}
							Navigator.GetNearestAccessibleSpotHeading = null;
						}
					}
				}
				else
				{
					if (!ParentScen.MinuteIsChangingOnThisPulse && !Information.IsNothing((object)Navigator.GetNearestAccessibleSpotHeading))
					{
						CurrentHeading = Navigator.GetNearestAccessibleSpotHeading.Value;
					}
					else
					{
						if (CheckForMines && Navigator.HasPathfindingPlottedCourse)
						{
							Navigator.ClearPathfindingWaypoints();
						}
						double DestLat2 = default(double);
						double DestLon2 = default(double);
						if (Navigator.GetNearestAccessibleSpot(out_lat, out_lon, ref DestLat2, ref DestLon2, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, 0f, ref ProvidedPiers, ManouverTowardsTarget: false))
						{
							Navigator.GetNearestAccessibleSpotHeading = Math2.CalcAzimuth(((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), DestLat2, DestLon2);
							CurrentHeading = Navigator.GetNearestAccessibleSpotHeading.Value;
							Navigator.ResetTimeToNextPathfinderCheck();
						}
					}
					((ActiveUnit)this).set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
					((ActiveUnit)this).set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
				}
			}
			((ActiveUnit)this).set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
			((ActiveUnit)this).set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
			if (double.IsNaN(((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null)))
			{
				((ActiveUnit)this).set_Latitude((GlobalVariables.BooleanObject)null, Latitude_old);
			}
			if (double.IsNaN(((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null)))
			{
				((ActiveUnit)this).set_Longitude((GlobalVariables.BooleanObject)null, Longitude_old);
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
}
