using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Vehicle : Platform, ICargoHost, ICargoClient, IMobileGroundUnit, IAGUInteractable
{
	public enum TractionType
	{
		Undefined = 0,
		Wheeled = 4001,
		HalfTrack = 4002,
		Tracked = 4003,
		Legged = 4004
	}

	public int CombatSystemGen;

	public float Width;

	public double Area;

	public float Mass;

	public int MastHeight;

	public int MissileDefense;

	public bool HasAimpoints;

	public int MaxSeaState;

	public TractionType TractionMode;

	public int Cargo_Crew;

	public float Cargo_Area;

	public CargoType Cargo_Type;

	public float Cargo_Mass;

	public bool Cargo_ParadropCapable;

	public int Cargo_Capacity_Crew;

	public float Cargo_Capacity_Area;

	public CargoType Cargo_Capacity_Type;

	public float Cargo_Capacity_Mass;

	public float Cargo_Capacity_Towing;

	public Cargo Cargo;

	private Vehicle_Navigator vehicle_Navigator_0;

	private Vehicle_AI vehicle_AI_0;

	private Vehicle_Kinematics HwwLfeaIoh4;

	private Vehicle_Sensory vehicle_Sensory_0;

	private Vehicle_Weaponry vehicle_Weaponry_0;

	private Vehicle_CommStuff vehicle_CommStuff_0;

	private Vehicle_Damage vehicle_Damage_0;

	private bool? nullable_16;

	private bool? nullable_17;

	public float _CurrentCoverRating;

	public float _Suppression;

	public bool IsAmphibious;

	protected bool? _IsAmphibiousSeaworthy;

	private Engine engine_0;

	private IMobileGroundUnit._MobileUnitCategory? nullable_18;

	private GlobalVariables.ArmorRating armorRating_0;

	public bool IsAmphibiousSeaworthy
	{
		get
		{
			if (!_IsAmphibiousSeaworthy.HasValue)
			{
				_IsAmphibiousSeaworthy = false;
				if (IsAmphibious)
				{
					foreach (Engine item in Propulsion)
					{
						if (item.CanBeUsedOnWater())
						{
							_IsAmphibiousSeaworthy = true;
						}
					}
				}
			}
			return _IsAmphibiousSeaworthy.Value;
		}
	}

	public float CurrentCoverRating
	{
		get
		{
			return _CurrentCoverRating;
		}
		set
		{
			_CurrentCoverRating = Math.Min(Math.Max(value, 0f), 1f);
		}
	}

	public float Suppression
	{
		get
		{
			return _Suppression;
		}
		set
		{
			_Suppression = Math.Min(Math.Max(value, 0f), 1f);
		}
	}

	public override bool RepresentsMobileGroundUnit => true;

	public DockFacility.DockingPhysicalSize DockingPhysicalSize
	{
		get
		{
			if (IsAmphibious)
			{
				return DBFunctions.GetAmphibiousVehicleDockingPhysicalSize(Length);
			}
			return DockFacility.DockingPhysicalSize.None;
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

	public Ship.ShipWakeSize WakeSize
	{
		get
		{
			if (CurrentSpeed == 0f)
			{
				return Ship.ShipWakeSize.NoWake;
			}
			float currentSpeed = CurrentSpeed;
			if (currentSpeed < 10f)
			{
				return (Ship.ShipWakeSize)Math.Max(0, (int)(VisualSizeClass - 1));
			}
			if (currentSpeed < 20f)
			{
				return (Ship.ShipWakeSize)VisualSizeClass;
			}
			if (currentSpeed < 30f)
			{
				return (Ship.ShipWakeSize)Math.Min(5, (int)(VisualSizeClass + 1));
			}
			if (currentSpeed < 40f)
			{
				return (Ship.ShipWakeSize)Math.Min(5, (int)(VisualSizeClass + 2));
			}
			return (Ship.ShipWakeSize)Math.Min(5, (int)(VisualSizeClass + 3));
		}
	}

	public override float FlatSurfaceArea_m2 => (float)Area;

	public override bool IsPlatform => true;

	public bool CanFireOnTheMove
	{
		get
		{
			IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = MobileUnitCategory;
			int result;
			int result2;
			if (mobileUnitCategory > IMobileGroundUnit._MobileUnitCategory.Artillery_SSM)
			{
				if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.AAA && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.SAM)
				{
					if (mobileUnitCategory == IMobileGroundUnit._MobileUnitCategory.Surveillance)
					{
						result = 0;
						goto IL_004a;
					}
					result2 = 1;
					goto IL_0046;
				}
			}
			else if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_Gun && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_Towed && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_SSM)
			{
				result2 = 1;
				goto IL_0046;
			}
			result = 0;
			goto IL_004a;
			IL_004a:
			return (byte)result != 0;
			IL_0046:
			return (byte)result2 != 0;
		}
	}

	public override Throttle MaxPossibleThrottleSetting
	{
		get
		{
			if (base.IsFixedFacility)
			{
				return Throttle.FullStop;
			}
			return Throttle.Flank;
		}
	}

	public override CommDevice[] Comms_ReadOnly
	{
		get
		{
			CommDevice[] result = default(CommDevice[]);
			try
			{
				if (!HasAimpoints)
				{
					result = base.Comms_ReadOnly;
					return result;
				}
				CommDevice[] theArray = null;
				int num = Mounts.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Mount mount = Mounts[i];
					if (mount.Status != PlatformComponent._ComponentStatus.Operational)
					{
						continue;
					}
					int num2 = mount.CommDevices.Length - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (Information.IsNothing((object)theArray))
						{
							theArray = method_16();
						}
						CommDevice commDevice = mount.CommDevices[j];
						commDevice.IsCommsInMount = true;
						ArrayExtensions.Add(ref theArray, commDevice);
					}
				}
				if (!Information.IsNothing((object)theArray))
				{
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
				ex2?.Data.Add("Error at 100542", "");
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

	public override int MastHeight_Radar
	{
		get
		{
			if (SpecificSensor != null && SpecificSensor.MastHeight != 0)
			{
				return SpecificSensor.MastHeight;
			}
			return MastHeight;
		}
	}

	public override int MastHeight_Visual
	{
		get
		{
			int result;
			if (SpecificSensor == null)
			{
				result = 3;
			}
			else
			{
				if (SpecificSensor.MastHeight != 0)
				{
					return SpecificSensor.MastHeight;
				}
				result = 3;
			}
			return result;
		}
	}

	public new Vehicle_Navigator Navigator => vehicle_Navigator_0;

	public new Vehicle_AI AI
	{
		get
		{
			if (vehicle_AI_0 == null)
			{
				ActiveUnit theUnit = this;
				vehicle_AI_0 = new Vehicle_AI(ref theUnit);
			}
			return vehicle_AI_0;
		}
	}

	public new Vehicle_Kinematics Kinematics
	{
		get
		{
			if (HwwLfeaIoh4 == null)
			{
				ActiveUnit theUnit = this;
				HwwLfeaIoh4 = new Vehicle_Kinematics(ref theUnit);
			}
			return HwwLfeaIoh4;
		}
	}

	public new Vehicle_Sensory Sensory
	{
		get
		{
			if (vehicle_Sensory_0 == null)
			{
				ActiveUnit theUnit = this;
				vehicle_Sensory_0 = new Vehicle_Sensory(ref theUnit);
			}
			return vehicle_Sensory_0;
		}
	}

	public new Vehicle_Weaponry Weaponry
	{
		get
		{
			if (vehicle_Weaponry_0 == null)
			{
				ActiveUnit theUnit = this;
				vehicle_Weaponry_0 = new Vehicle_Weaponry(ref theUnit);
			}
			return vehicle_Weaponry_0;
		}
	}

	public new Vehicle_CommStuff CommStuff
	{
		get
		{
			if (vehicle_CommStuff_0 == null)
			{
				ActiveUnit theUnit = this;
				vehicle_CommStuff_0 = new Vehicle_CommStuff(ref theUnit);
			}
			return vehicle_CommStuff_0;
		}
	}

	public new Vehicle_Damage Damage
	{
		get
		{
			if (vehicle_Damage_0 == null)
			{
				ActiveUnit theUnit = this;
				vehicle_Damage_0 = new Vehicle_Damage(ref theUnit);
			}
			return vehicle_Damage_0;
		}
	}

	public override bool IsUnderground
	{
		get
		{
			if (!nullable_16.HasValue)
			{
				nullable_16 = base.IsUnderground;
			}
			return nullable_16.Value;
		}
	}

	public override bool IsUnderwater
	{
		get
		{
			if (!nullable_17.HasValue)
			{
				nullable_17 = base.IsUnderwater;
			}
			return nullable_17.Value;
		}
	}

	public override string AnnexAndDBID => "GroundUnit_" + Conversions.ToString(DBID);

	public override GlobalVariables.TargetVisualSizeClass VisualSizeClass
	{
		get
		{
			float cargo_Area = Cargo_Area;
			if (cargo_Area > 50f)
			{
				return GlobalVariables.TargetVisualSizeClass.VLarge;
			}
			if (cargo_Area > 25f)
			{
				return GlobalVariables.TargetVisualSizeClass.Large;
			}
			if (cargo_Area > 15f)
			{
				return GlobalVariables.TargetVisualSizeClass.Medium;
			}
			if (cargo_Area > 10f)
			{
				return GlobalVariables.TargetVisualSizeClass.Small;
			}
			if (cargo_Area > 5f)
			{
				return GlobalVariables.TargetVisualSizeClass.VSmall;
			}
			return GlobalVariables.TargetVisualSizeClass.Stealthy;
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

	public IMobileGroundUnit._MobileUnitCategory MobileUnitCategory
	{
		get
		{
			return nullable_18.Value;
		}
		set
		{
			nullable_18 = value;
		}
	}

	public override ActiveUnit_DockingOps.ResupplyCapacity DesignatedSupplier
	{
		get
		{
			if (!_DesignatedSupplier.HasValue)
			{
				if (MobileUnitCategory == IMobileGroundUnit._MobileUnitCategory.Supply)
				{
					_DesignatedSupplier = ActiveUnit_DockingOps.ResupplyCapacity.FuelAndMaterial;
				}
				else
				{
					_DesignatedSupplier = ActiveUnit_DockingOps.ResupplyCapacity.None;
				}
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
			if (!TargetUnit.IsFixedFacility)
			{
				int result;
				if (TargetUnit.IsFacility)
				{
					result = 1;
				}
				else
				{
					if (!TargetUnit.IsVehicle)
					{
						goto IL_001f;
					}
					result = 1;
				}
				return (byte)result != 0;
			}
			goto IL_001f;
			IL_001f:
			return false;
		}
	}

	public override long FuelEndurance
	{
		get
		{
			try
			{
				if (Fuel_ReadOnly.Count != 0)
				{
					if (Propulsion.Count != 0)
					{
						FuelRec fuelRec = (from theFuelrec in Fuel_ReadOnly
							select (theFuelrec) into theFuelrec
							where Propulsion[0].CanUseThisFuelType(theFuelrec.FuelType)
							select theFuelrec).ElementAtOrDefault(0);
						if (fuelRec == null)
						{
							return 0L;
						}
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

	public override _ActiveUnitFuelState IsBingoOrJoker
	{
		get
		{
			_ActiveUnitFuelState result;
			try
			{
				if (IsDrone() && AutonomyLevel < DroneAutonomyLevel.FaultEventAdaptive && ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !((ActiveUnit_CommStuff)CommStuff).IsConnectedToSideNetwork)
				{
					result = _ActiveUnitFuelState.None;
				}
				else
				{
					ActiveUnit actualDestinationHost = DockingOps.ActualDestinationHost;
					result = ((actualDestinationHost != null) ? ((!actualDestinationHost.IsMorituri) ? ((ActiveUnit)this).get_IsBingoTowardsThisDestination(actualDestinationHost, (GeoPoint)null, (Doctrine._FuelState?)null) : _ActiveUnitFuelState.None) : _ActiveUnitFuelState.None);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100768V", "");
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

	public GlobalVariables.ArmorRating Armor_General
	{
		get
		{
			return armorRating_0;
		}
		set
		{
			armorRating_0 = value;
		}
	}

	internal override void Reinitialize()
	{
		base.Reinitialize();
		ChanceOfAppearance = 0;
		CurrentHeading = 0f;
		CurrentSpeed = 0f;
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
		_Status = _ActiveUnitStatus.Unassigned;
		_FuelState = _ActiveUnitFuelState.None;
		_WeaponState = _ActiveUnitWeaponState.None;
		_AirOps = null;
		ActiveUnit theUnit = this;
		DockingOps = new ActiveUnit_DockingOps(ref theUnit);
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		if (((ActiveUnit)this).get_UnitSide(SetSideOnly: false) == null)
		{
			return;
		}
		theWriter.WriteStartElement("Vehicle");
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
				theWriter.WriteElementString("Side", ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Name);
				if (!string.IsNullOrEmpty(Message))
				{
					theWriter.WriteElementString("Message", Message);
				}
				theWriter.WriteElementString("DBID", DBID.ToString());
				theWriter.WriteElementString("DH", XmlConvert.ToString(((ActiveUnit)this).DesiredHeading));
				theWriter.WriteElementString("DS", XmlConvert.ToString(DesiredSpeed));
				theWriter.WriteElementString("DT", ((byte)DesiredTurnRate).ToString());
				theWriter.WriteElementString("DTN", ((byte)DesiredTurnRate_Navigation).ToString());
				if (_Proficiency.HasValue)
				{
					theWriter.WriteElementString("Prof", ((int)_Proficiency.Value).ToString());
				}
				theWriter.WriteElementString("ThrottleSetting", ((byte)ThrottleSetting).ToString());
				if (Sensors_Cached.Length > 0)
				{
					theWriter.WriteStartElement("Sensors");
					foreach (Sensor sensor in _Sensors)
					{
						theWriter.WriteRaw(sensor.ToXML(ObjectsAlreadySerialized));
					}
					theWriter.WriteEndElement();
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
					foreach (Engine item in Propulsion)
					{
						theWriter.WriteRaw(item.ToXML(ObjectsAlreadySerialized));
					}
					theWriter.WriteEndElement();
				}
				if (_Fuel.Count > 0)
				{
					theWriter.WriteStartElement("Fuel");
					foreach (FuelRec item2 in _Fuel)
					{
						theWriter.WriteRaw(item2.ToXML());
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
				if (Magazines.Count() > 0)
				{
					theWriter.WriteStartElement("Magazines");
					Magazine[] magazines = Magazines;
					foreach (Magazine magazine in magazines)
					{
						theWriter.WriteRaw(magazine.ToXML(ObjectsAlreadySerialized, ParentScen));
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
				XmlWriter obj = theWriter;
				byte status = (byte)_Status;
				obj.WriteElementString("Status", status.ToString());
				XmlWriter obj2 = theWriter;
				status = (byte)_FuelState;
				obj2.WriteElementString("FuelState", status.ToString());
				theWriter.WriteElementString("WeaponState", ((byte)_WeaponState).ToString());
				XmlWriter obj3 = theWriter;
				status = (byte)_StatusBefore_NeedToRefuel;
				obj3.WriteElementString("SBR", status.ToString());
				XmlWriter obj4 = theWriter;
				status = (byte)_StatusBefore_EngagedDefensive;
				obj4.WriteElementString("SBED", status.ToString());
				XmlWriter obj5 = theWriter;
				status = (byte)_StatusBefore_EngagedOffensive;
				obj5.WriteElementString("SBEO", status.ToString());
				XmlWriter obj6 = theWriter;
				status = (byte)_FuelStateBefore_NeedToRefuel;
				obj6.WriteElementString("FSBR", status.ToString());
				theWriter.WriteElementString("SBR_TF", XmlConvert.ToString(_TerrainFollowingBefore_NeedToRefuel));
				XmlWriter obj7 = theWriter;
				status = (byte)_ThrottleBefore_NeedToRefuel;
				obj7.WriteElementString("SBR_ThrottleSetting", status.ToString());
				theWriter.WriteElementString("SBED_TF", XmlConvert.ToString(_TerrainFollowingBefore_EngagedDefensive));
				XmlWriter obj8 = theWriter;
				status = (byte)_ThrottleBefore_EngagedDefensive;
				obj8.WriteElementString("SBED_ThrottleSetting", status.ToString());
				theWriter.WriteElementString("SBEO_TF", XmlConvert.ToString(_TerrainFollowingBefore_EngagedOffensive));
				XmlWriter obj9 = theWriter;
				status = (byte)_ThrottleBefore_EngagedOffensive;
				obj9.WriteElementString("SBEO_ThrottleSetting", status.ToString());
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
				Doctrine.ToXML(ref theWriter, ref ParentScen);
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
				if (AirOps != null)
				{
					_AirOps.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				}
				if (DockingOps != null)
				{
					ActiveUnit_DockingOps.ToXML(DockingOps, ref theWriter, ref ObjectsAlreadySerialized);
				}
				if (HasCustomOODA)
				{
					theWriter.WriteElementString("OODA_D", OODA_Detection.ToString());
					theWriter.WriteElementString("OODA_T", OODA_Targeting.ToString());
					theWriter.WriteElementString("OODA_E", OODA_Evasion.ToString());
				}
				theWriter.WriteEndElement();
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100540", "");
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

	private Vehicle()
	{
		Scenario theScen = null;
		base..ctor(ref theScen);
		TractionMode = TractionType.Undefined;
		Cargo = new Cargo(this);
		ActiveUnit theUnit = this;
		vehicle_Navigator_0 = new Vehicle_Navigator(ref theUnit);
		IsAmphibious = false;
		IsMobileGroundUnit = true;
		IsVehicle = true;
		UnitType = GlobalVariables.ActiveUnitType.Vehicle;
	}

	public static List<Vehicle> SpawnVehicleFromCargoMountList(List<Mount> theMounts, Scenario theScen, Side theSide)
	{
		IEnumerable<VB$AnonymousType_5<IMobileGroundUnit._MobileUnitCategory, IEnumerable<Mount>>> enumerable = theMounts.GroupBy([SpecialName] (Mount m) => m.MobileUnitCategory, [SpecialName] (Mount m) => m, [SpecialName] (IMobileGroundUnit._MobileUnitCategory MobileUnitCategory, IEnumerable<Mount> $VB$ItAnonymous) => new VB$AnonymousType_5<IMobileGroundUnit._MobileUnitCategory, IEnumerable<Mount>>(MobileUnitCategory, $VB$ItAnonymous));
		List<Vehicle> list = new List<Vehicle>();
		foreach (VB$AnonymousType_5<IMobileGroundUnit._MobileUnitCategory, IEnumerable<Mount>> item in enumerable)
		{
			string text = "";
			IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = item.MobileUnitCategory;
			int num;
			int num2;
			string text2;
			if (mobileUnitCategory <= IMobileGroundUnit._MobileUnitCategory.AAA)
			{
				if (mobileUnitCategory <= IMobileGroundUnit._MobileUnitCategory.Armor)
				{
					if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Infantry)
					{
						if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Armor)
						{
							num = 2990;
							goto IL_0177;
						}
						num2 = 2983;
						text2 = "Armor";
					}
					else
					{
						num2 = 2987;
						text2 = "Inf";
					}
				}
				else if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_Gun)
				{
					if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.AAA)
					{
						num = 2990;
						goto IL_0177;
					}
					num2 = 2989;
					text2 = "AAA";
				}
				else
				{
					num2 = 2985;
					text2 = "Arty";
				}
			}
			else if (mobileUnitCategory <= IMobileGroundUnit._MobileUnitCategory.Surveillance)
			{
				if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.SAM)
				{
					if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Surveillance)
					{
						num = 2990;
						goto IL_0177;
					}
					goto IL_0192;
				}
				num2 = 2988;
				text2 = "SAM";
			}
			else
			{
				if (mobileUnitCategory == IMobileGroundUnit._MobileUnitCategory.Recon)
				{
					goto IL_0192;
				}
				if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.MechInfantry)
				{
					num = 2990;
					goto IL_0177;
				}
				num2 = 2984;
				text2 = "Mech Inf";
			}
			goto IL_01a0;
			IL_0192:
			num2 = 2986;
			text2 = "Recon";
			goto IL_01a0;
			IL_0177:
			num2 = num;
			text2 = "Landed Detachment";
			goto IL_01a0;
			IL_01a0:
			Vehicle vehicle = null;
			vehicle = theScen.AddNewVehicle(theSide, num2, text + text2 + " #" + Conversions.ToString(theScen.UnitsAutoIncrement), 0.0, 0.0, IgnoreElevationCheck: true);
			vehicle.Mounts.Clear();
			foreach (Mount mount in item.Mounts)
			{
				vehicle.Mounts.Add(mount);
				mount.ParentPlatform = vehicle;
			}
			Sensor[] sensors_Cached = vehicle.Sensors_Cached;
			for (int num3 = 0; num3 < sensors_Cached.Length; num3 = checked(num3 + 1))
			{
				sensors_Cached[num3].ParentPlatform = vehicle;
			}
			ArrayExtensions.Clear(ref vehicle.Magazines);
			list.Add(vehicle);
		}
		return list;
	}

	public static Vehicle FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, Vehicle existingObject = null)
	{
		Vehicle vehicle = default(Vehicle);
		try
		{
			vehicle = smethod_1(ref theNode, ref theDictionary, ref theScen, theScen.LoadStockUnits, existingObject);
		}
		catch (PlatformComponentNotFoundException projectError)
		{
			ProjectData.SetProjectError((Exception)projectError);
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			ConcurrentDictionary<string, ScenarioObject> obj = theDictionary;
			ScenarioObject value = vehicle;
			obj.TryRemove(innerText, out value);
			vehicle = smethod_1(ref theNode, ref theDictionary, ref theScen, bool_3: true, existingObject);
			string text = "";
			if (vehicle.IsGroupMember())
			{
				text = "(member of group: [" + ((ActiveUnit)vehicle).get_ParentGroup(UsingMissionPlanner: false).Name + "])";
			}
			theScen.LoadingNotices.Add("The following Vehicle:[" + vehicle.Name + "]" + text + " failed to shallow-rebuild because of a component missing. The Vehicle was instead deep-rebuilt, and instantiated in its pristine DB-stock condition. All customizations present in the Vehicle's components (damaged components, weapon additions/removals etc. etc.) have been lost. Please re-apply any necessary customizations either manually or using an SBR script.");
			ProjectData.ClearProjectError();
		}
		return vehicle;
	}

	private static Vehicle smethod_1(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0, bool bool_3, Vehicle vehicle_0 = null)
	{
		//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d2: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0640: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Expected O, but got Unknown
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0496: Expected O, but got Unknown
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected O, but got Unknown
		//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c8: Expected O, but got Unknown
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Expected O, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected O, but got Unknown
		//IL_0540: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Expected O, but got Unknown
		//IL_154e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1555: Expected O, but got Unknown
		//IL_0e53: Unknown result type (might be due to invalid IL or missing references)
		Vehicle result;
		try
		{
			bool flag;
			Vehicle theVehicle;
			if (!(flag = vehicle_0 != null))
			{
				theVehicle = new Vehicle();
			}
			else
			{
				theVehicle = vehicle_0;
				theVehicle.Reinitialize();
			}
			theVehicle.ParentScen = scenario_0;
			string innerText = Misc.GetNodeByName(xmlNode_0.ChildNodes, "ID").InnerText;
			if (concurrentDictionary_0.ContainsKey(innerText))
			{
				result = (Vehicle)concurrentDictionary_0[innerText];
			}
			else
			{
				theVehicle.ObjectID_Set(innerText);
				if (xmlNode_0.ChildNodes.Count == 1)
				{
					scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
					result = theVehicle;
				}
				else
				{
					concurrentDictionary_0.TryAdd(theVehicle.ObjectID, theVehicle);
					int num = Conversions.ToInteger(Misc.GetNodeByName(xmlNode_0.ChildNodes, "DBID").InnerText);
					try
					{
						DBFunctions.GetVehicle(ref scenario_0, ref theVehicle, num, bool_3);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
						string objectID = theVehicle.ObjectID;
						ScenarioObject value = theVehicle;
						obj.TryRemove(objectID, out value);
						scenario_0.LoadingNotices.Add("Vehicle with Database ID " + Conversions.ToString(num) + " is missing from the database and has not been loaded.");
						result = null;
						ProjectData.ClearProjectError();
						goto end_IL_0001;
					}
					if (bool_3)
					{
						theVehicle.method_3(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
					}
					if (!bool_3)
					{
						foreach (XmlNode childNode in xmlNode_0.ChildNodes)
						{
							XmlNode val = childNode;
							theVehicle.CommonFromXML(val);
							switch (val.Name)
							{
							case "Comms":
								if (flag)
								{
									ArrayExtensions.Clear(ref theVehicle._Comms);
								}
								foreach (XmlNode childNode2 in val.ChildNodes)
								{
									XmlNode theNode7 = childNode2;
									CommDevice commDevice = CommDevice.FromXML(ref theNode7, ref concurrentDictionary_0, theVehicle);
									theVehicle.AddCommDevice(commDevice);
									commDevice.ParentPlatform = theVehicle;
								}
								break;
							case "OnboardCargo":
								if (flag)
								{
									ArrayExtensions.Clear(ref theVehicle.OnboardCargo);
								}
								foreach (XmlNode childNode3 in val.ChildNodes)
								{
									XmlNode theNode2 = childNode3;
									Cargo cargo = Cargo.FromXML(ref theNode2, ref concurrentDictionary_0, scenario_0, theVehicle);
									ArrayExtensions.Add(ref theVehicle.OnboardCargo, cargo);
									cargo.ParentPlatform = theVehicle;
								}
								break;
							case "Fuel":
								if (flag)
								{
									theVehicle._Fuel.Clear();
								}
								foreach (XmlNode childNode4 in val.ChildNodes)
								{
									XmlNode theNode8 = childNode4;
									FuelRec item = FuelRec.FromXML(ref theNode8, ref concurrentDictionary_0);
									theVehicle._Fuel.Add(item);
								}
								break;
							case "DockFacilities":
								if (flag)
								{
									ArrayExtensions.Clear(ref theVehicle._DockFacilities);
								}
								foreach (XmlNode childNode5 in val.ChildNodes)
								{
									XmlNode theNode5 = childNode5;
									DockFacility dockFacility = DockFacility.FromXML(ref theNode5, ref concurrentDictionary_0, ref scenario_0);
									theVehicle.AddDockFacility(dockFacility);
									dockFacility.ParentPlatform = theVehicle;
								}
								break;
							case "Sensors":
								if (flag)
								{
									theVehicle._Sensors.Clear();
								}
								foreach (XmlNode childNode6 in val.ChildNodes)
								{
									Sensor sensor = Sensor.FromXML(childNode6, concurrentDictionary_0, theVehicle);
									theVehicle._Sensors.Add(sensor);
									sensor.ParentPlatform = theVehicle;
								}
								break;
							case "Propulsion":
								if (flag)
								{
									theVehicle.Propulsion.Clear();
								}
								foreach (XmlNode childNode7 in val.ChildNodes)
								{
									XmlNode theNode3 = childNode7;
									ActiveUnit theParentPlatform = theVehicle;
									Engine engine = Engine.FromXML(ref theNode3, ref concurrentDictionary_0, ref theParentPlatform);
									theVehicle.Propulsion.Add(engine);
									engine.ParentPlatform = theVehicle;
								}
								break;
							case "AirFacilities":
								if (flag)
								{
									ArrayExtensions.Clear(ref theVehicle._AirFacilities);
								}
								foreach (XmlNode childNode8 in val.ChildNodes)
								{
									XmlNode theNode6 = childNode8;
									AirFacility airFacility = AirFacility.FromXML(ref theNode6, ref concurrentDictionary_0, ref scenario_0);
									theVehicle.AddAirFacility(airFacility);
									airFacility.ParentPlatform = theVehicle;
								}
								break;
							case "Magazines":
								if (flag)
								{
									ArrayExtensions.Clear(ref theVehicle.Magazines);
								}
								foreach (XmlNode childNode9 in val.ChildNodes)
								{
									XmlNode theNode4 = childNode9;
									Magazine magazine = Magazine.FromXML(ref theNode4, ref concurrentDictionary_0, ref scenario_0);
									theVehicle.AddSharedMagazine(magazine, RaiseUiEvent: false);
									magazine.ParentPlatform = theVehicle;
								}
								break;
							case "Mounts":
								if (flag)
								{
									theVehicle.Mounts.Clear();
								}
								foreach (XmlNode childNode10 in val.ChildNodes)
								{
									XmlNode theNode = childNode10;
									Mount mount = Mount.FromXML(ref theNode, ref concurrentDictionary_0, theVehicle);
									if (mount != null)
									{
										theVehicle.Mounts.Add(mount);
										mount.ParentPlatform = theVehicle;
									}
								}
								break;
							}
						}
					}
					foreach (XmlNode childNode11 in xmlNode_0.ChildNodes)
					{
						XmlNode theNode9 = childNode11;
						if (!theVehicle.isLastReportedInfoXMLField(theNode9.Name))
						{
							switch (theNode9.Name)
							{
							case "FSBR":
								theVehicle._FuelStateBefore_NeedToRefuel = (_ActiveUnitFuelState)Conversions.ToByte(theNode9.InnerText);
								break;
							case "Status":
								if (!Versioned.IsNumeric((object)theNode9.InnerText))
								{
									theVehicle.Status = (_ActiveUnitStatus)Enum.Parse(typeof(_ActiveUnitStatus), theNode9.InnerText, ignoreCase: true);
								}
								else
								{
									theVehicle.Status = (_ActiveUnitStatus)Conversions.ToByte(theNode9.InnerText);
								}
								if (theVehicle.Status == (_ActiveUnitStatus)9)
								{
									theVehicle.Status = _ActiveUnitStatus.RTB;
								}
								break;
							case "AMP_OC_Speed":
								theVehicle._MissionPlannerOverrideCancellation_Speed = XmlConvert.ToSingle(theNode9.InnerText);
								break;
							case "Name":
								theVehicle.Name = theNode9.InnerText;
								break;
							case "SBED_Altitude_TF":
								theVehicle._AltitudeBefore_EngagedDefensive_AGL = XmlConvert.ToSingle(theNode9.InnerText);
								break;
							case "DTN":
							case "DesiredTurnRate_Navigation":
								theVehicle.DesiredTurnRate_Navigation = (Waypoint.TurnRateCategory)Conversions.ToByte(theNode9.InnerText);
								break;
							case "AI":
							case "Vehicle_AI":
							{
								Vehicle vehicle4 = theVehicle;
								ActiveUnit theParentPlatform = theVehicle;
								vehicle4.vehicle_AI_0 = Vehicle_AI.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
								break;
							}
							case "AL":
								theVehicle.AutonomyLevel = (DroneAutonomyLevel)Conversions.ToInteger(theNode9.InnerText);
								break;
							case "TUW":
								theVehicle.TimeUnderway = XmlConvert.ToSingle(theNode9.InnerText.Replace(",", "."));
								break;
							case "FuelState":
								theVehicle._FuelState = (_ActiveUnitFuelState)Conversions.ToByte(theNode9.InnerText);
								break;
							case "Vehicle_Kinematics":
							case "Kinematics":
								ActiveUnit_Kinematics.FromXML(theNode9, concurrentDictionary_0, theVehicle);
								break;
							case "Vehicle_Damage":
							case "Damage":
							{
								Vehicle vehicle8 = theVehicle;
								ActiveUnit theParentPlatform = theVehicle;
								vehicle8.vehicle_Damage_0 = Vehicle_Damage.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
								break;
							}
							case "COA":
								theVehicle.ChanceOfAppearance = Conversions.ToInteger(theNode9.InnerText);
								break;
							case "DamagePts":
								if (!bool_3)
								{
									((ActiveUnit)theVehicle).set_DamagePts(ScenEditAction: false, (Weapon)null, XmlConvert.ToSingle(theNode9.InnerText));
								}
								break;
							case "AMP_OC_DAO":
								theVehicle._MissionPlannerOverrideCancellation_DesiredAltitudeOverride = Misc.ParseBool(theNode9.InnerText);
								break;
							case "SBED_Altitude":
								theVehicle._AltitudeBefore_EngagedDefensive = XmlConvert.ToSingle(theNode9.InnerText);
								break;
							case "OldDamagePercent":
								theVehicle._OldDamagePercent = XmlConvert.ToSingle(theNode9.InnerText);
								break;
							case "PrivateSnapshotMission":
								theVehicle.PrivateSnapshotMission = Mission.FromXML(ref theNode9, ref concurrentDictionary_0, ref scenario_0);
								break;
							case "SBR":
								theVehicle._StatusBefore_NeedToRefuel = (_ActiveUnitStatus)Conversions.ToByte(theNode9.InnerText);
								break;
							case "SBR_Altitude_TF":
								theVehicle._AltitudeBefore_NeedToRefuel_AGL = XmlConvert.ToSingle(theNode9.InnerText);
								break;
							case "DesiredHeading":
							case "DH":
								((ActiveUnit)theVehicle).set_DesiredHeading(TurnRate.Max, XmlConvert.ToSingle(theNode9.InnerText));
								break;
							case "AirOps":
							case "ActiveUnit_AirOps":
							{
								Vehicle vehicle7 = theVehicle;
								ActiveUnit theParentPlatform = theVehicle;
								vehicle7._AirOps = ActiveUnit_AirOps.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
								break;
							}
							case "ActiveEnterAreaTriggers":
								if (flag)
								{
									theVehicle.ActiveEnterAreaTriggers.Clear();
								}
								foreach (XmlNode childNode12 in theNode9.ChildNodes)
								{
									string innerText3 = childNode12.InnerText;
									theVehicle.ActiveEnterAreaTriggers.Add(innerText3);
								}
								break;
							case "SBED_ThrottleSetting":
								switch (theNode9.InnerText)
								{
								case "FullStop":
									theVehicle._ThrottleBefore_EngagedDefensive = Throttle.FullStop;
									break;
								default:
									theVehicle._ThrottleBefore_EngagedDefensive = (Throttle)Conversions.ToByte(theNode9.InnerText);
									break;
								case "Flank":
									theVehicle._ThrottleBefore_EngagedDefensive = Throttle.Flank;
									break;
								case "Full":
									theVehicle._ThrottleBefore_EngagedDefensive = Throttle.Full;
									break;
								case "Cruise":
									theVehicle._ThrottleBefore_EngagedDefensive = Throttle.Cruise;
									break;
								case "Loiter":
									theVehicle._ThrottleBefore_EngagedDefensive = Throttle.Loiter;
									break;
								}
								break;
							case "ThrottleSetting":
								switch (theNode9.InnerText)
								{
								case "Loiter":
									theVehicle.ThrottleSetting = Throttle.Loiter;
									break;
								default:
									theVehicle.ThrottleSetting = (Throttle)Conversions.ToByte(theNode9.InnerText);
									break;
								case "Flank":
									theVehicle.ThrottleSetting = Throttle.Flank;
									break;
								case "Full":
									theVehicle.ThrottleSetting = Throttle.Full;
									break;
								case "Cruise":
									theVehicle.ThrottleSetting = Throttle.Cruise;
									break;
								case "FullStop":
									theVehicle.ThrottleSetting = Throttle.FullStop;
									break;
								}
								break;
							case "WeaponState":
								theVehicle._WeaponState = (_ActiveUnitWeaponState)Conversions.ToSByte(theNode9.InnerText);
								break;
							case "Prof":
								theVehicle.Proficiency = (GlobalVariables.ProficiencyLevel)Conversions.ToInteger(theNode9.InnerText);
								break;
							case "Doctrine":
								if (!flag)
								{
									theVehicle.Doctrine = Doctrine.FromXML(scenario_0, ref theNode9, theVehicle);
								}
								else
								{
									theVehicle.Doctrine = Doctrine.FromXML(scenario_0, ref theNode9, theVehicle, theVehicle.Doctrine);
								}
								break;
							case "SBEO_TF":
								theVehicle._TerrainFollowingBefore_EngagedOffensive = Misc.ParseBool(theNode9.InnerText);
								break;
							case "Vehicle_CommStuff":
							case "CommStuff":
							{
								Vehicle vehicle6 = theVehicle;
								ActiveUnit theParentPlatform = theVehicle;
								vehicle6.vehicle_CommStuff_0 = Vehicle_CommStuff.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
								break;
							}
							case "SBED_TF":
								theVehicle._TerrainFollowingBefore_EngagedDefensive = Misc.ParseBool(theNode9.InnerText);
								break;
							case "OODA_E":
								theVehicle.HasCustomOODA = true;
								theVehicle.OODA_Evasion = Conversions.ToShort(theNode9.InnerText);
								break;
							case "AMP_OC_DSO":
								theVehicle._MissionPlannerOverrideCancellation_DesiredSpeedOverride = XmlConvert.ToSingle(theNode9.InnerText);
								break;
							case "Latitude_UnitEntersAreaCheck":
								theVehicle.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(theNode9.InnerText);
								break;
							case "OODA_D":
								theVehicle.HasCustomOODA = true;
								theVehicle.OODA_Detection = Conversions.ToShort(theNode9.InnerText);
								break;
							case "OODA_T":
								theVehicle.HasCustomOODA = true;
								theVehicle.OODA_Targeting = Conversions.ToShort(theNode9.InnerText);
								break;
							case "AssignedMission":
								if (theNode9.HasChildNodes)
								{
									XmlNode val4 = theNode9.ChildNodes[0];
									theVehicle._AssignedMissionOrPackage_ID = val4.InnerText;
								}
								break;
							case "Vehicle_Sensory":
							case "Sensory":
							{
								Vehicle vehicle5 = theVehicle;
								ActiveUnit theParentPlatform = theVehicle;
								vehicle5.vehicle_Sensory_0 = Vehicle_Sensory.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
								break;
							}
							case "EFSAR":
								theVehicle.EligibleForSAR = Misc.ParseBool(theNode9.InnerText);
								break;
							case "Side":
								theVehicle._SideName = theNode9.InnerText;
								break;
							case "Longitude":
							case "Lon":
								((ActiveUnit)theVehicle).set_Longitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(theNode9.InnerText.Replace(",", ".")));
								break;
							case "ActiveRemainAreaTriggers":
							{
								string key = null;
								DateTime result2 = DateTime.MinValue;
								foreach (XmlNode childNode13 in theNode9.ChildNodes)
								{
									XmlNode val3 = childNode13;
									if (Operators.CompareString(val3.Name, "RemainAreaTrigger", false) == 0)
									{
										key = val3.InnerText;
										result2 = DateTime.MinValue;
									}
									else if (!DateTime.TryParse(val3.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.None, out result2))
									{
										string innerText2 = val3.InnerText;
										long result3 = default(long);
										if (long.TryParse(innerText2, out result3))
										{
											result2 = DateTime.FromBinary(Conversions.ToLong(val3.InnerText));
											theVehicle.ActiveRemainAreaTriggers.Add(key, result2);
										}
									}
									else
									{
										theVehicle.ActiveRemainAreaTriggers.Add(key, result2);
									}
								}
								break;
							}
							case "DS":
							case "DesiredSpeed":
								theVehicle.DesiredSpeed = XmlConvert.ToSingle(theNode9.InnerText);
								break;
							case "IBPU":
								theVehicle.IsBeingPickedUp = Misc.ParseBool(theNode9.InnerText);
								break;
							case "CustomIcon":
								theVehicle.CustomIcon = theNode9.InnerText;
								break;
							case "AssignedTaskPool":
								if (theNode9.HasChildNodes)
								{
									XmlNode val2 = theNode9.ChildNodes[0];
									theVehicle._AssignedTaskPool_ID = val2.InnerText;
								}
								break;
							case "SBEO_Altitude":
								theVehicle._AltitudeBefore_EngagedOffensive = XmlConvert.ToSingle(theNode9.InnerText);
								break;
							case "SBR_ThrottleSetting":
								switch (theNode9.InnerText)
								{
								case "FullStop":
									theVehicle._ThrottleBefore_NeedToRefuel = Throttle.FullStop;
									break;
								case "Loiter":
									theVehicle._ThrottleBefore_NeedToRefuel = Throttle.Loiter;
									break;
								case "Cruise":
									theVehicle._ThrottleBefore_NeedToRefuel = Throttle.Cruise;
									break;
								default:
									theVehicle._ThrottleBefore_NeedToRefuel = (Throttle)Conversions.ToByte(theNode9.InnerText);
									break;
								case "Flank":
									theVehicle._ThrottleBefore_NeedToRefuel = Throttle.Flank;
									break;
								case "Full":
									theVehicle._ThrottleBefore_NeedToRefuel = Throttle.Full;
									break;
								}
								break;
							case "Message":
								theVehicle.Message = theNode9.InnerText;
								break;
							case "SBEO_Altitude_TF":
								theVehicle._AltitudeBefore_EngagedOffensive_AGL = XmlConvert.ToSingle(theNode9.InnerText);
								break;
							case "DockingOps":
							case "ActiveUnit_DockingOps":
							{
								Vehicle vehicle3 = theVehicle;
								ActiveUnit theParentPlatform = theVehicle;
								vehicle3.DockingOps = ActiveUnit_DockingOps.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
								break;
							}
							case "Latitude":
							case "Lat":
								((ActiveUnit)theVehicle).set_Latitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(theNode9.InnerText.Replace(",", ".")));
								break;
							case "SBEO":
								theVehicle._StatusBefore_EngagedOffensive = (_ActiveUnitStatus)Conversions.ToByte(theNode9.InnerText);
								break;
							case "AMP_OC":
								theVehicle._MissionPlannerOverrideCancellation = Misc.ParseBool(theNode9.InnerText);
								break;
							case "SBR_Altitude":
								theVehicle._AltitudeBefore_NeedToRefuel = XmlConvert.ToSingle(theNode9.InnerText);
								break;
							case "CS":
							case "CurrentSpeed":
								theVehicle.CurrentSpeed = XmlConvert.ToSingle(theNode9.InnerText);
								break;
							case "SBR_TF":
								theVehicle._TerrainFollowingBefore_NeedToRefuel = Misc.ParseBool(theNode9.InnerText);
								break;
							case "Vehicle_Navigator":
							case "Navigator":
							{
								Vehicle vehicle2 = theVehicle;
								ActiveUnit theParentPlatform = theVehicle;
								vehicle2.vehicle_Navigator_0 = Vehicle_Navigator.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
								break;
							}
							case "SBED":
								theVehicle._StatusBefore_EngagedDefensive = (_ActiveUnitStatus)Conversions.ToByte(theNode9.InnerText);
								break;
							case "DT":
							case "DesiredTurnRate":
								theVehicle.DesiredTurnRate = (TurnRate)Conversions.ToByte(theNode9.InnerText);
								break;
							case "ParentGroup":
								theVehicle._ParentGroup_ID = theNode9.InnerText;
								break;
							case "Vehicle_Weaponry":
							case "Weaponry":
							{
								Vehicle vehicle = theVehicle;
								ActiveUnit theParentPlatform = theVehicle;
								vehicle.vehicle_Weaponry_0 = Vehicle_Weaponry.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
								break;
							}
							case "SBEO_ThrottleSetting":
								switch (theNode9.InnerText)
								{
								case "FullStop":
									theVehicle._ThrottleBefore_EngagedOffensive = Throttle.FullStop;
									break;
								default:
									theVehicle._ThrottleBefore_EngagedOffensive = (Throttle)Conversions.ToByte(theNode9.InnerText);
									break;
								case "Flank":
									theVehicle._ThrottleBefore_EngagedOffensive = Throttle.Flank;
									break;
								case "Full":
									theVehicle._ThrottleBefore_EngagedOffensive = Throttle.Full;
									break;
								case "Cruise":
									theVehicle._ThrottleBefore_EngagedOffensive = Throttle.Cruise;
									break;
								case "Loiter":
									theVehicle._ThrottleBefore_EngagedOffensive = Throttle.Loiter;
									break;
								}
								break;
							case "CH":
							case "CurrentHeading":
								theVehicle.CurrentHeading = XmlConvert.ToSingle(theNode9.InnerText);
								break;
							case "IsAD":
							case "IsAutoDetectable":
								((ActiveUnit)theVehicle).set_IsAutoDetectable((Side)null, Misc.ParseBool(theNode9.InnerText));
								break;
							case "Longitude_UnitEntersAreaCheck":
								theVehicle.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(theNode9.InnerText);
								break;
							}
						}
						else
						{
							theVehicle.LastReportedInfoFromXMLField(theNode9.Name, theNode9.InnerText);
						}
					}
					((ActiveUnit)theVehicle).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)((Module_Unit.Unit)theVehicle).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, theVehicle.ParentScen));
					theVehicle.EvaluateIfDumb();
					result = theVehicle;
				}
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100541", "");
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

	public override void PostDeserializationHousekeeping_General(ref Scenario theScen, ConcurrentDictionary<string, ScenarioObject> theDictionary, List<ActiveUnit> DiscardList, bool GameIsRunning)
	{
		base.PostDeserializationHousekeeping_General(ref theScen, theDictionary, DiscardList, GameIsRunning);
		ActiveUnit_DockingOps.PostDeserializationHousekeeping(DockingOps, ref theScen, theDictionary, GameIsRunning);
		if (DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
		{
			((ActiveUnit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)((Module_Unit.Unit)this).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: true, theScen));
		}
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

	private protected override List<PlatformComponent> ComponentList()
	{
		List<PlatformComponent> list = base.ComponentList();
		list.Add(Cargo);
		return list;
	}

	public Vehicle(ref Scenario theScen, string theGUID = null)
		: base(ref theScen, theGUID)
	{
		TractionMode = TractionType.Undefined;
		Cargo = new Cargo(this);
		ActiveUnit theUnit = this;
		vehicle_Navigator_0 = new Vehicle_Navigator(ref theUnit);
		IsAmphibious = false;
		IsMobileGroundUnit = true;
		IsVehicle = true;
		UnitType = GlobalVariables.ActiveUnitType.Vehicle;
		EvaluateIfDumb();
	}

	public override void DoTypeSpecificActions(float elapsedTime, ref LockRandom theRNG)
	{
		DockingOps.DoDockingOps(elapsedTime);
		if (!IsOperating())
		{
			TimeUnderway = 0f;
		}
		else
		{
			TimeUnderway += elapsedTime;
		}
	}

	public Mount PickRandomAimpoint()
	{
		IEnumerable<Mount> source = Mounts.Where([SpecialName] (Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed);
		if (source.Count() > 0)
		{
			int index = GameGeneral.GlobalRNG.Next(0, source.Count());
			return source.ElementAtOrDefault(index);
		}
		return null;
	}

	public override void SetThrottle(Throttle newThrottleSetting, float? SpecificDesiredSpeed = null)
	{
		try
		{
			if (ThrottleSetting == newThrottleSetting && Information.IsNothing((object)SpecificDesiredSpeed) && !ParentScen.MinuteIsChangingOnThisPulse)
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
			if (Information.IsNothing((object)SpecificDesiredSpeed))
			{
				DesiredSpeed = Kinematics.GetMaximumSpeed(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false);
			}
			else if (!IsGroupLead() || !AI.MustSlowDownToAllowGroupFormUp())
			{
				if (Kinematics.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
				{
					float? num = SpecificDesiredSpeed;
					float num2 = Kinematics.GetMaximumSpeed(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), newThrottleSetting, ValidateAndFixAltitude: false);
					bool? flag = (num.HasValue ? new bool?(num.GetValueOrDefault() > num2) : ((bool?)null));
					bool? flag2 = (!flag) ?? flag;
					if (flag2 ?? true)
					{
						num = SpecificDesiredSpeed;
						num2 = Kinematics.GetMinimumSpeed((int)Math.Round(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), newThrottleSetting, ValidateAndFixAltitude: false);
						flag = ((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() < num2));
						if (((!flag) ?? flag) == true && flag2.HasValue)
						{
							DesiredSpeed = SpecificDesiredSpeed.Value;
							goto IL_025c;
						}
					}
					ThrottleSetting = Kinematics.GetThrottleSuitableForThisSpeed(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), SpecificDesiredSpeed.Value);
					num = SpecificDesiredSpeed;
					num2 = Kinematics.GetMaximumSpeed(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false);
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() > num2)) == true)
					{
						DesiredSpeed = Kinematics.GetMaximumSpeed(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false);
					}
				}
				else
				{
					DesiredSpeed = Kinematics.GetMaximumSpeed(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (Throttle)Kinematics.ThrottlePreset, ValidateAndFixAltitude: false);
				}
			}
			goto IL_025c;
			IL_025c:
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
			if (ParentScen.NatureSideExists() && ParentScen.GetNatureSide().CustomEnvironmentZones != null)
			{
				CustomEnvironmentZone[] customEnvironmentZones = ParentScen.GetNatureSide().CustomEnvironmentZones;
				int num = 0;
				while (num < customEnvironmentZones.Length)
				{
					CustomEnvironmentZone customEnvironmentZone = customEnvironmentZones[num];
					if (!((customEnvironmentZone.HasCustomTerrain && customEnvironmentZone.TerrainType == LandCover.LandCoverType.Water) & !IsAmphibiousSeaworthy) || !GeoPoint.IsInsideThisArea(theLat, theLon, customEnvironmentZone.Area_AsArray))
					{
						if (!(customEnvironmentZone.HasCustomTerrainHeight & (customEnvironmentZone.TerrainHeight < 0) & !IsAmphibiousSeaworthy) || !GeoPoint.IsInsideThisArea(theLat, theLon, customEnvironmentZone.Area_AsArray))
						{
							num = checked(num + 1);
							continue;
						}
						CheckNoNavZones = false;
						CheckForMines = false;
						UserFeedback = "CEZ water along the path.";
						result = false;
					}
					else
					{
						CheckNoNavZones = false;
						CheckForMines = false;
						UserFeedback = "CEZ water along the path.";
						result = false;
					}
					goto end_IL_0001;
				}
			}
			MovementCost = 1;
			if (!double.IsNaN(theLat) && !double.IsNaN(theLon))
			{
				if (!CheckIfTargetIsOutsideProsecutionArea || Status != _ActiveUnitStatus.EngagedOffensive || ActiveMissionOrPackage() == null || ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Patrol)
				{
					goto IL_0180;
				}
				Patrol patrol = (Patrol)ActiveMissionOrPackage();
				Geopoint_Struct geopoint_Struct = new Geopoint_Struct(theLon, theLat);
				if (!((Module_Unit.Unit)this).get_IsInsideThisArea(patrol.ProsecutionArea, ParentScen, UseCache: true) || GeoPoint.IsInsideThisArea(geopoint_Struct.Latitude, geopoint_Struct.Longitude, patrol.ProsecutionArea))
				{
					goto IL_0180;
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
			IL_0180:
			if (IsPathfindingQuery || !Navigator.HasPathfindingPlottedCourse || Status == _ActiveUnitStatus.EngagedOffensive)
			{
				goto IL_01dd;
			}
			float num2 = (Information.IsNothing((object)DistanceFromUnit) ? Module_Unit.RangeToPoint_Horiz(this, theLat, theLon) : DistanceFromUnit.Value);
			if (!(num2 <= ((Module_Unit.Unit)this).get_HorizMovementDistanceOnThisTime(2f)))
			{
				goto IL_01dd;
			}
			CheckNoNavZones = false;
			CheckForMines = false;
			result = true;
			goto end_IL_0001;
			IL_01dd:
			if (CheckDistanceToNoNavZones)
			{
				CheckNoNavZones = DistanceToNearestNoNavZone();
			}
			if ((CheckNoNavZones || IsPathfindingQuery) && IsInsideNoNavZones(theLat, theLon, ProximityThreshold_Deg))
			{
				CheckNoNavZones = true;
				CheckForMines = false;
				UserFeedback = "The point is inside a No-Nav Zone.";
				result = false;
			}
			else if (method_17(theLat, theLon, ProvidedElevation))
			{
				if ((double)Terrain.GetMaxSlope(theLat, theLon, RequestIsFromGUI: false, ParentScen) > 0.75)
				{
					result = false;
				}
				else
				{
					CheckNoNavZones = false;
					CheckForMines = false;
					result = true;
				}
			}
			else
			{
				CheckNoNavZones = false;
				CheckForMines = false;
				UserFeedback = "The point is not accessible.";
				result = false;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200286", ex2.Message);
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

	public override bool CanPlotCourseToThisLocation(double theLat, double theLon)
	{
		double startLat = ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null);
		double startLon = ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null);
		if (Navigator.HasPlottedCourse())
		{
			startLat = Navigator.PlottedCourse.Last().Latitude;
			startLon = Navigator.PlottedCourse.Last().Longitude;
		}
		return GroundCostBasedPathfinder.CanSolve(startLat, startLon, theLat, theLon);
	}

	private bool method_17(double double_0, double double_1, short? nullable_19 = null)
	{
		bool result = default(bool);
		try
		{
			if (ParentScen.NatureSideExists())
			{
				CustomEnvironmentZone[] customEnvironmentZones = ParentScen.GetNatureSide().CustomEnvironmentZones;
				foreach (CustomEnvironmentZone customEnvironmentZone in customEnvironmentZones)
				{
					if (customEnvironmentZone.HasCustomTerrain && GeoPoint.IsInsideThisArea(double_0, double_1, customEnvironmentZone.Area_AsArray) && customEnvironmentZone.TerrainType != LandCover.LandCoverType.Water)
					{
						result = true;
						return result;
					}
				}
			}
			int num3;
			if (!IsAmphibiousSeaworthy)
			{
				short num;
				if (!nullable_19.HasValue)
				{
					(bool, short?) tuple = Terrain.PointIsOverland(double_0, double_1);
					if (tuple.Item1)
					{
						result = true;
						return result;
					}
					num = ((!tuple.Item2.HasValue) ? Terrain.GetElevation(double_0, double_1, RequestIsFromGUI: false, ParentScen) : tuple.Item2.Value);
				}
				else
				{
					num = nullable_19.Value;
				}
				if (num <= 0)
				{
					int num2 = -415;
					if (!Information.IsNothing((object)Propulsion.Where([SpecialName] (Engine theE) => theE.CanBeUsedOnWater()).ElementAtOrDefault(0)))
					{
						result = true;
						return result;
					}
					if (num > num2 && LandCover.GetLandCoverAtThisPoint(double_0, double_1, ParentScen) != LandCover.LandCoverType.Water)
					{
						result = true;
						return result;
					}
					result = false;
					return result;
				}
			}
			else
			{
				if (IsVehicle)
				{
					result = true;
					return result;
				}
				if (Terrain.PointIsOverland(double_0, double_1).IsOverland)
				{
					num3 = 1;
					goto IL_0176;
				}
				Weather.WeatherProfile weatherProfile = Weather.get_WeatherAtThisTimeAndPlace(ParentScen, double_0, double_1, 0);
				if (MaxSeaState < weatherProfile.SeaState)
				{
					result = false;
					return result;
				}
			}
			num3 = 1;
			goto IL_0176;
			IL_0176:
			result = (byte)num3 != 0;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100544", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void Teleport(ref Scenario theScen, double Destination_Lon, double Destination_Lat)
	{
		base.Teleport(ref theScen, Destination_Lon, Destination_Lat);
		((ActiveUnit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)((Module_Unit.Unit)this).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: true, theScen));
		Kinematics.ExportLocationEvent("Teleport");
	}

	internal float GetCargo_Crew()
	{
		return Cargo_Capacity_Crew;
	}

	float ICargoHost.GetCargo_Crew()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Crew
		return this.GetCargo_Crew();
	}

	internal float GetCargo_Area()
	{
		if (Cargo_Capacity_Type == CargoType.Personnel && Cargo_Capacity_Area == 0f)
		{
			return (float)Cargo_Capacity_Crew * Mount.PersonnelArea;
		}
		return Cargo_Capacity_Area;
	}

	float ICargoHost.GetCargo_Area()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Area
		return this.GetCargo_Area();
	}

	internal CargoType GetCargo_Type()
	{
		return Cargo_Capacity_Type;
	}

	CargoType ICargoHost.GetCargo_Type()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Type
		return this.GetCargo_Type();
	}

	internal float GetCargo_Mass()
	{
		if (Cargo_Capacity_Type == CargoType.Personnel && Cargo_Capacity_Mass == 0f)
		{
			return (float)Cargo_Capacity_Crew * Mount.PersonnelMass;
		}
		return Cargo_Capacity_Mass;
	}

	float ICargoHost.GetCargo_Mass()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Mass
		return this.GetCargo_Mass();
	}

	public float GetCargo_TowingCapacity()
	{
		return Cargo_Capacity_Towing;
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
			double num = 0.0;
			int num2 = 0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			foreach (Cargo CargoItem in CargoItems)
			{
				Cargo.CargoStorageType storageType = CargoItem.StorageType;
				if (storageType == Cargo.CargoStorageType.TowedExternal)
				{
					num4 += (double)CargoItem.RequiredMass;
				}
				else
				{
					num3 += (double)CargoItem.RequiredMass;
				}
				if (CargoItem.RequiredCargoType == CargoType.Personnel)
				{
					num5 += (double)CargoItem.RequiredCrewSpace;
				}
				num2 = Math.Max(num2, CargoItem.GetAdditionalLoadTime());
			}
			if (num5 > 0.0)
			{
				num = num5 / 10.0;
			}
			if (num3 > 0.0)
			{
				num = Math.Max(num, ActiveUnit_DockingOps.GetCargoMoveTime(10.0, 60.0, num3, GetCargo_Mass()));
			}
			if (num4 > 0.0)
			{
				num = Math.Max(num, ActiveUnit_DockingOps.GetCargoMoveTime(5.0, 30.0, num4, GetCargo_TowingCapacity()));
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
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				foreach (Cargo CargoItem in CargoItems)
				{
					Cargo.CargoStorageType storageType = CargoItem.StorageType;
					if (storageType == Cargo.CargoStorageType.TowedExternal)
					{
						num3 += (double)CargoItem.RequiredMass;
					}
					else
					{
						num2 += (double)CargoItem.RequiredMass;
					}
					if (num4 > -1.0)
					{
						num4 = ((CargoItem.RequiredCargoType != CargoType.Personnel) ? (-1.0) : (num4 + (double)CargoItem.RequiredCrewSpace));
					}
				}
				if (num4 > 0.0)
				{
					num = num4 / 20.0;
				}
				if (num2 > 0.0)
				{
					num = Math.Max(num, ActiveUnit_DockingOps.GetCargoMoveTime(2.0, 60.0, num2, GetCargo_Mass()));
				}
				if (num3 > 0.0)
				{
					num = Math.Max(num, ActiveUnit_DockingOps.GetCargoMoveTime(2.0, 15.0, num3, GetCargo_TowingCapacity()));
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
		int result;
		if (Propulsion.Count > 0)
		{
			if (!PotentialCargo.IsTowable())
			{
				result = 0;
				goto IL_0034;
			}
			if (Cargo_Capacity_Towing >= PotentialCargo.GetRequiredMass() && CargoHostHelper.GetTowedCargo(this) == null)
			{
				return true;
			}
		}
		result = 0;
		goto IL_0034;
		IL_0034:
		return (byte)result != 0;
	}

	public CargoType GetRequiredCargoType()
	{
		Cargo towedCargo = CargoHostHelper.GetTowedCargo(this);
		if (towedCargo != null && towedCargo.RequiredCargoType > Cargo_Type)
		{
			return towedCargo.RequiredCargoType;
		}
		return Cargo_Type;
	}

	public float GetRequiredCrewSpace()
	{
		float num = Cargo_Crew;
		Cargo towedCargo = CargoHostHelper.GetTowedCargo(this);
		if (towedCargo != null)
		{
			num += towedCargo.RequiredCrewSpaceExternal;
		}
		return num;
	}

	public float GetRequiredArea()
	{
		float num = Cargo_Area;
		Cargo towedCargo = CargoHostHelper.GetTowedCargo(this);
		if (towedCargo != null)
		{
			num += towedCargo.RequiredAreaExternal;
		}
		return num;
	}

	public float GetRequiredAreaStacked(ICargoHost Host, int TotalQuantity)
	{
		return GetRequiredArea() * (float)TotalQuantity;
	}

	public float GetRequiredMass()
	{
		return Cargo_Mass + CargoHostHelper.GetCurrentLoadTotalMass(this, OnboardCargo);
	}

	public bool GetParadropCapable()
	{
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
		return "GroundUnit_" + DBID;
	}

	public string CargoObjectToXML(HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		return "<Vehicle>" + ObjectID + "</Vehicle>";
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
		Mission mission = ActiveMissionOrPackage();
		int result;
		if (mission == null)
		{
			result = 0;
		}
		else
		{
			if (mission.IsActive)
			{
				if (mission.MissionClass == Mission._MissionClass.Cargo && ((CargoMission)mission).AllowSelfDeliveryFromCargo && DockingOps.OriginalCargoHostUnit != null)
				{
					return false;
				}
				if (IsGroupMember() && !IsGroupLead())
				{
					ActiveUnit groupLead = ((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false).GroupLead;
					if (groupLead != null && groupLead.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo && groupLead.ActiveMissionOrPackage() == mission)
					{
						return false;
					}
				}
				return DockingOps.IsWithinRangeOfMission();
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public bool IsTowable()
	{
		if (Propulsion.Count != 0)
		{
			return false;
		}
		return GetRequiredCargoType() != CargoType.NoCargo;
	}

	public bool IsStackable()
	{
		return false;
	}

	public float GetRequiredHeight()
	{
		return 0f;
	}

	public int GetCargoQuantity()
	{
		return 1;
	}

	public bool isMatch(Cargo c)
	{
		if (c == null)
		{
			goto IL_0032;
		}
		int result;
		if (c.CargoObjectActiveUnit == null)
		{
			result = 0;
		}
		else
		{
			ActiveUnit cargoObjectActiveUnit = c.CargoObjectActiveUnit;
			if (cargoObjectActiveUnit.IsVehicle)
			{
				if (cargoObjectActiveUnit.DBID == DBID)
				{
					return true;
				}
				goto IL_0032;
			}
			result = 0;
		}
		goto IL_0033;
		IL_0032:
		result = 0;
		goto IL_0033;
		IL_0033:
		return (byte)result != 0;
	}

	public override void DoFuelConsumption(float elapsedTime)
	{
		try
		{
			if (ThrottleSetting == Throttle.FullStop || Propulsion.Count == 0 || IsOutOfFuel)
			{
				return;
			}
			if (DesiredSpeed == 0f && CurrentSpeed == 0f)
			{
				ThrottleSetting = Throttle.FullStop;
				return;
			}
			AI.SelectEngines();
			float theQuantity = FuelConsumption(ThrottleSetting, null, null, null, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false) * elapsedTime;
			FuelRec fuelRec = default(FuelRec);
			foreach (FuelRec item in Fuel_ReadOnly)
			{
				if (PrimaryEngine.CanUseThisFuelType(item.FuelType))
				{
					fuelRec = item;
					break;
				}
			}
			if (fuelRec != null)
			{
				Fuel_Subtract(theQuantity, fuelRec.FuelType);
			}
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
				fuelRec.CurrentQuantity -= theQuantity;
				return;
			}
			bool num = fuelRec.CurrentQuantity > 0f;
			fuelRec.CurrentQuantity = 0f;
			SetThrottle(Throttle.FullStop);
			if (num)
			{
				AddMessage(Name + " (" + Misc.RemoveHiddenString(UnitClass) + ") has run out of fuel and lies dead in the water!", Name + " immobilized", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
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
		if (Propulsion.Count == 0)
		{
			result = 0f;
		}
		else
		{
			AltBand altBand = null;
			try
			{
				if (Propulsion[0].Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					result = 0f;
				}
				else if (Propulsion[0].AltBands.Length != 0)
				{
					altBand = ((!Information.IsNothing((object)theAltBand)) ? theAltBand : (Information.IsNothing((object)theAltitude) ? Kinematics.GetCurrentAltBand(((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ValidateAndFixAltitude: false) : Kinematics.GetCurrentAltBand_CurrentAltitude(theAltitude.Value, null, ValidateAndFixAltitude: false)));
					if (Information.IsNothing((object)altBand))
					{
						result = 0f;
					}
					else
					{
						float num;
						float num2;
						float num3;
						switch (theThrottleSetting)
						{
						default:
							result = 0f;
							goto end_IL_001b;
						case Throttle.FullStop:
							result = 0f;
							goto end_IL_001b;
						case Throttle.Loiter:
							num = altBand.Consumption_Loiter;
							num2 = 0f;
							goto IL_0283;
						case Throttle.Cruise:
							if (Propulsion[0].AltBands[0].Consumption_Cruise > 0f)
							{
								num = altBand.Consumption_Cruise;
								num2 = altBand.Consumption_Loiter;
								goto IL_0283;
							}
							result = FuelConsumption(Throttle.Loiter, theAltBand, theSpeed, theAltitude, BingoFuelCheck, ReserveFuelQtyCalc, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
							goto end_IL_001b;
						case Throttle.Full:
							if (altBand.Speed_Full.HasValue)
							{
								float? consumption_Flank = Propulsion[0].AltBands[0].Consumption_Full;
								if (((!consumption_Flank.HasValue) ? ((bool?)null) : new bool?(consumption_Flank.GetValueOrDefault() > 0f)) == true)
								{
									num = altBand.Consumption_Full.Value;
									_ = (float)altBand.Speed_Full.Value;
									num2 = altBand.Consumption_Cruise;
									goto IL_0283;
								}
							}
							result = FuelConsumption(Throttle.Cruise, theAltBand, theSpeed, theAltitude, BingoFuelCheck, ReserveFuelQtyCalc, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
							goto end_IL_001b;
						case Throttle.Flank:
							{
								if (!altBand.Speed_Flank.HasValue)
								{
									break;
								}
								float? consumption_Flank = Propulsion[0].AltBands[0].Consumption_Flank;
								if ((consumption_Flank.HasValue ? new bool?(consumption_Flank.GetValueOrDefault() > 0f) : ((bool?)null)) != true)
								{
									break;
								}
								num = altBand.Consumption_Flank.Value;
								_ = (float)altBand.Speed_Flank.Value;
								num2 = (altBand.Speed_Full.HasValue ? altBand.Consumption_Full.Value : altBand.Consumption_Cruise);
								goto IL_0283;
							}
							IL_0283:
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
							goto end_IL_001b;
						}
						result = FuelConsumption(Throttle.Full, theAltBand, theSpeed, theAltitude, BingoFuelCheck, ReserveFuelQtyCalc, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
					}
				}
				else
				{
					result = 0f;
				}
				end_IL_001b:;
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
		return result;
	}

	internal bool IsArtillery()
	{
		IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = MobileUnitCategory;
		int result;
		int result2;
		if (mobileUnitCategory <= IMobileGroundUnit._MobileUnitCategory.Artillery_SP)
		{
			if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_Gun && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_Towed && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_SP)
			{
				result = 0;
				goto IL_0059;
			}
		}
		else if (mobileUnitCategory <= IMobileGroundUnit._MobileUnitCategory.Artillery_Rocket_Tracked)
		{
			if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_Rocket_Wheeled && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_Rocket_Tracked)
			{
				result = 0;
				goto IL_0059;
			}
		}
		else if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_Mortar)
		{
			if (mobileUnitCategory == IMobileGroundUnit._MobileUnitCategory.Artillery_SSM)
			{
				result2 = 1;
				goto IL_005d;
			}
			result = 0;
			goto IL_0059;
		}
		result2 = 1;
		goto IL_005d;
		IL_005d:
		return (byte)result2 != 0;
		IL_0059:
		return (byte)result != 0;
	}

	bool IMobileGroundUnit.IsArtillery()
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsArtillery
		return this.IsArtillery();
	}

	public void ResolveAGUDamages(float[] Damages, float CombatAgility, float DamageModifier, float AttackDirection_degrees = -1f, bool IgnoreArmorDeflection = false, bool IgnoreCoverDeflection = false, AggregateGroundUnit.DamageResolutioMethod TargetingType = AggregateGroundUnit.DamageResolutioMethod.Standard)
	{
		LockRandom random = GlobalSingleton.GetInstance().Random;
		float[] array = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
		GetCombatProtection(array);
		float unitHitPoint = AggregateGroundUnit.GetUnitHitPoint(this);
		float num = 1f;
		if (AttackDirection_degrees != -1f)
		{
			float num2 = Math.Max(Math.Abs(MathFunctions.AngularDifference(CurrentHeading, AttackDirection_degrees)) - AGU_CONFIG.Instance.DirectionalOffset_Degrees, 0f);
			num = 1f - num2 * 0.002777f;
		}
		float num3 = 0f;
		int num4 = array.Length - 1;
		for (int i = 0; i <= num4; i++)
		{
			float num5 = Damages[i] * DamageModifier;
			if (!IgnoreArmorDeflection)
			{
				num5 *= 1f - array[i];
			}
			num3 += num5;
		}
		if (!(num3 > 0f))
		{
			return;
		}
		float num6 = CombatAgility * num3;
		float num7 = num3 - num6;
		float num8 = CurrentCoverRating * (1f - AGU_CONFIG.Instance.DirectionalModifier_Defense + num * AGU_CONFIG.Instance.DirectionalModifier_Defense);
		if (IgnoreCoverDeflection)
		{
			num8 = 0f;
		}
		float num9 = Math.Min(unitHitPoint * num8, num6 * num8 + num7 * AGU_CONFIG.Instance.SuppressionFactor_IndirectFire);
		Suppression += num9 / unitHitPoint * AGU_CONFIG.Instance.SuppressionFactor;
		float num10 = num6 * (1f - num8);
		if (unitHitPoint > num10)
		{
			if (random.NextDouble() < (double)(num10 / unitHitPoint))
			{
				Destroy(ScenEditAction: false, IsFacilityAimpoint: true, DestroyUnitNow: true, "Destroyed");
			}
		}
		else
		{
			Destroy(ScenEditAction: false, IsFacilityAimpoint: true, DestroyUnitNow: true, "Destroyed");
		}
	}

	public Module_Unit.Unit GetUnit()
	{
		return this;
	}

	public float[] GetCombatProtection(float[] ArrayByRef)
	{
		return AggregateGroundUnit.GetProtectionByArmorRating(ArrayByRef, Armor_General);
	}

	public GlobalVariables.ArmorRating GetMostCommonArmorRating()
	{
		return Armor_General;
	}

	public float[] GetCombatPower(float[] ArrayByRef)
	{
		Array.Clear(ArrayByRef, 0, ArrayByRef.Length);
		float[] array = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
		float[] warheadHighest_GC = new float[array.Length - 1 + 1];
		foreach (Mount mount in Mounts)
		{
			mount.ApplyCombatPower(ArrayByRef, array, warheadHighest_GC, ParentScen);
		}
		return ArrayByRef;
	}

	public float GetAntiAirPower()
	{
		float num = default(float);
		foreach (Mount mount in Mounts)
		{
			foreach (WeaponRec mountWeapon in mount.MountWeapons)
			{
				Weapon weapon = mountWeapon.get_ReferenceWeapon(ParentScen);
				if (weapon.ValidTargets.Aircraft || weapon.ValidTargets.Helicopter)
				{
					num += 1f;
				}
			}
		}
		return num;
	}

	public void SpecialAGUAction()
	{
	}

	static Vehicle()
	{
		Class72.smethod_20();
	}
}
