using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Facility : Platform, ICargoHost, ICargoClient, IAGUInteractable
{
	public enum _FacilityCategory : short
	{
		None = 1001,
		Runway = 2001,
		RunwayGrade_Taxiway = 2002,
		RunwayAccessPoint = 2003,
		Building_Surface = 3001,
		Building_Reveted = 3002,
		Building_Bunker = 3003,
		Building_Underground = 3004,
		Structure_Open = 3005,
		Structure_Reveted = 3006,
		SurfaceAndUnderground = 3007,
		Underwater = 4001,
		Water_Surface = 4050,
		Mobile_Vehicle = 5001,
		Mobile_Personnel = 5002,
		Mobile_Vehicules_Tracked = 5003,
		Mobile_Vehicules_HalfTrack = 5004,
		Mobile_Vehicule_Wheeled = 5005,
		AerostatMooring = 6001,
		AirBase = 9001
	}

	public enum FacilityType
	{
		None = 1001,
		Radar = 2001,
		ElectronicWarfare = 2101,
		SAM = 3001,
		AAA = 4001,
		Artillery = 5001,
		TowedArtillery = 5011,
		SelfPropelledArtillery = 5021,
		WheeledRocketArtillery = 5111,
		TrackedRocketArtillery = 5121,
		Mortar = 5201,
		SSM = 6001,
		Armored = 7001,
		CombinedArms = 7500,
		Infantry = 8001,
		Marines = 8011,
		AirAssault = 8021,
		Mountain = 8031,
		Airborne = 8041,
		SpecialForces = 8101,
		Mechanized = 9001,
		MechanizedAirborne = 9041,
		MechanizedWheeled = 9501,
		Motorized = 10001,
		Ammo = 11001,
		Fuel = 12001,
		Supply = 13001,
		Recon = 14001,
		AmphibiousRecon = 14011,
		AntiTank = 16001,
		Engineer = 17001,
		Headquarters = 18000
	}

	public enum SamplingPointAccessibility
	{
		Yes_Overland,
		Yes_ShallowWater,
		No
	}

	public int CombatSystemGen;

	public GlobalVariables.ArmorRating Armor_General;

	public _FacilityCategory Category;

	public float Width;

	public double Area;

	public int MastHeight;

	public int MissileDefense;

	public bool HasAimpoints;

	public int AimpointDispersalRadius;

	public CIC CIC;

	public Cargo Cargo;

	private Facility_Navigator facility_Navigator_0;

	private Facility_AI facility_AI_0;

	private Facility_Kinematics facility_Kinematics_0;

	private Facility_Sensory facility_Sensory_0;

	private Facility_Weaponry facility_Weaponry_0;

	internal new Facility_CommStuff CommStuff;

	private Facility_Damage facility_Damage_0;

	private bool? nullable_16;

	private int int_5;

	public float _CurrentCoverRating;

	public float _Suppression;

	private HashSet<AggregateGroundUnit> hashSet_0;

	private float float_8;

	private IMobileGroundUnit._MobileUnitCategory? nullable_17;

	public float Control
	{
		get
		{
			return float_8;
		}
		set
		{
			float_8 = Math.Min(Math.Max(value, 0f), 1f);
		}
	}

	public override bool RepresentsMobileGroundUnit
	{
		get
		{
			_FacilityCategory category = Category;
			if ((uint)(category - 5001) > 4u)
			{
				return false;
			}
			return true;
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

	public override float FlatSurfaceArea_m2 => (float)Area;

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
			string text2 = method_16();
			if (Operators.CompareString(text2, "None", false) != 0)
			{
				return text2 + text;
			}
			return "Radar";
		}
	}

	public override bool IsPlatform => true;

	public bool CanFireOnTheMove
	{
		get
		{
			IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = MobileUnitCategory();
			int result;
			int result2;
			if (mobileUnitCategory <= IMobileGroundUnit._MobileUnitCategory.Artillery_SSM)
			{
				if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_Gun && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_Towed && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_SSM)
				{
					result = 1;
					goto IL_0046;
				}
			}
			else if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.AAA && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.SAM)
			{
				if (mobileUnitCategory == IMobileGroundUnit._MobileUnitCategory.Surveillance)
				{
					result2 = 0;
					goto IL_004a;
				}
				result = 1;
				goto IL_0046;
			}
			result2 = 0;
			goto IL_004a;
			IL_0046:
			return (byte)result != 0;
			IL_004a:
			return (byte)result2 != 0;
		}
	}

	public override bool IsOutOfFuel => false;

	public override bool CanPhysicallyReplenishThisUnit
	{
		get
		{
			int result;
			if (TargetUnit.IsFixedFacility)
			{
				result = 0;
				goto IL_001f;
			}
			int result2;
			if (!TargetUnit.IsFacility)
			{
				if (!TargetUnit.IsVehicle)
				{
					result = 0;
					goto IL_001f;
				}
				result2 = 1;
			}
			else
			{
				result2 = 1;
			}
			return (byte)result2 != 0;
			IL_001f:
			return (byte)result != 0;
		}
	}

	public override ActiveUnit_DockingOps.ResupplyCapacity DesignatedSupplier
	{
		get
		{
			if (!_DesignatedSupplier.HasValue)
			{
				if (MobileUnitCategory() == IMobileGroundUnit._MobileUnitCategory.Supply)
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

	public override Throttle MaxPossibleThrottleSetting
	{
		get
		{
			if (!base.IsFixedFacility)
			{
				return Throttle.Flank;
			}
			return Throttle.FullStop;
		}
	}

	public override CommDevice[] Comms_ReadOnly
	{
		get
		{
			PooledList<CommDevice> pooledList = null;
			CommDevice[] result = default(CommDevice[]);
			try
			{
				if (!HasAimpoints)
				{
					result = base.Comms_ReadOnly;
					return result;
				}
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
						if (pooledList == null)
						{
							pooledList = new PooledList<CommDevice>(_Comms, Pools<CommDevice>.Local);
						}
						CommDevice commDevice = mount.CommDevices[j];
						commDevice.IsCommsInMount = true;
						pooledList.Add(commDevice);
					}
				}
				if (pooledList == null)
				{
					result = _Comms;
					return result;
				}
				CommDevice[] array = new CommDevice[pooledList.Count - 1 + 1];
				CommDevice[] array2 = pooledList.InternalArray();
				int num3 = pooledList.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					array[k] = array2[k];
				}
				result = array;
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
			finally
			{
				pooledList?.Dispose();
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
			if (MastHeight == 0 && Sensors_Cached.Where([SpecialName] (Sensor theS) => theS.Type == Sensor.Sensor_Type.PCLS).Count() > 0)
			{
				MastHeight = 25;
			}
			return MastHeight;
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
			_FacilityCategory category = Category;
			int result;
			if (category > _FacilityCategory.Building_Underground)
			{
				if (category != _FacilityCategory.SurfaceAndUnderground)
				{
					switch (category)
					{
					case _FacilityCategory.Mobile_Personnel:
						return 2;
					case _FacilityCategory.Mobile_Vehicle:
						return 4;
					}
					result = 0;
					goto IL_005a;
				}
			}
			else
			{
				if (category == _FacilityCategory.Building_Surface)
				{
					int num = default(int);
					return VisualSizeClass switch
					{
						GlobalVariables.TargetVisualSizeClass.Stealthy => 1, 
						GlobalVariables.TargetVisualSizeClass.VSmall => 4, 
						GlobalVariables.TargetVisualSizeClass.Small => 6, 
						GlobalVariables.TargetVisualSizeClass.Medium => 20, 
						GlobalVariables.TargetVisualSizeClass.Large => 30, 
						GlobalVariables.TargetVisualSizeClass.VLarge => 40, 
						_ => num, 
					};
				}
				if (category != _FacilityCategory.Building_Underground)
				{
					result = 0;
					goto IL_005a;
				}
			}
			return 0;
			IL_005a:
			return result;
		}
	}

	public new Facility_Navigator Navigator => facility_Navigator_0;

	public new Facility_AI AI => facility_AI_0;

	public new Facility_Kinematics Kinematics
	{
		get
		{
			if (facility_Kinematics_0 == null)
			{
				ActiveUnit theUnit = this;
				facility_Kinematics_0 = new Facility_Kinematics(ref theUnit);
			}
			return facility_Kinematics_0;
		}
	}

	public new Facility_Sensory Sensory
	{
		get
		{
			if (facility_Sensory_0 == null)
			{
				ActiveUnit theUnit = this;
				facility_Sensory_0 = new Facility_Sensory(ref theUnit);
			}
			return facility_Sensory_0;
		}
	}

	public new Facility_Weaponry Weaponry
	{
		get
		{
			if (facility_Weaponry_0 == null)
			{
				ActiveUnit theUnit = this;
				facility_Weaponry_0 = new Facility_Weaponry(ref theUnit);
			}
			return facility_Weaponry_0;
		}
	}

	public new Facility_Damage Damage
	{
		get
		{
			if (facility_Damage_0 == null)
			{
				ActiveUnit theUnit = this;
				facility_Damage_0 = new Facility_Damage(ref theUnit);
			}
			return facility_Damage_0;
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
			if (Category == _FacilityCategory.Water_Surface)
			{
				return false;
			}
			if (int_5 == -1)
			{
				int_5 = 0 - (base.IsUnderwater ? 1 : 0);
			}
			return int_5 != 0;
		}
	}

	public override string AnnexAndDBID => "Facility_" + Conversions.ToString(DBID);

	public override GlobalVariables.TargetVisualSizeClass VisualSizeClass
	{
		get
		{
			float num = ((ActiveUnit)this).get_DamagePts(ScenEditAction: false, (Weapon)null);
			if (num <= 5000f)
			{
				if (num > 1000f)
				{
					return GlobalVariables.TargetVisualSizeClass.Large;
				}
				if (num > 500f)
				{
					return GlobalVariables.TargetVisualSizeClass.Medium;
				}
				if (num > 150f)
				{
					return GlobalVariables.TargetVisualSizeClass.Small;
				}
				if (num > 30f)
				{
					return GlobalVariables.TargetVisualSizeClass.VSmall;
				}
				return GlobalVariables.TargetVisualSizeClass.Stealthy;
			}
			return GlobalVariables.TargetVisualSizeClass.VLarge;
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

	private protected override List<PlatformComponent> ComponentList()
	{
		List<PlatformComponent> list = base.ComponentList();
		list.Add(CIC);
		list.Add(Cargo);
		return list;
	}

	protected override GlobalVariables.ArmorRating GetArmorStructureValue()
	{
		return Armor_General;
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
		try
		{
			theWriter.WriteStartElement("Facility");
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
			if (Control < 1f)
			{
				theWriter.WriteElementString("Cont", XmlConvert.ToString(Control));
			}
			if (AutonomyLevel != DroneAutonomyLevel.Undefined)
			{
				theWriter.WriteElementString("AL", Conversions.ToString((int)AutonomyLevel));
			}
			if (CurrentHeading != 0f)
			{
				theWriter.WriteElementString("CH", XmlConvert.ToString(CurrentHeading));
			}
			if (CurrentSpeed != 0f)
			{
				theWriter.WriteElementString("CS", XmlConvert.ToString(CurrentSpeed));
			}
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
			if (((ActiveUnit)this).DesiredHeading != 0f)
			{
				theWriter.WriteElementString("DH", XmlConvert.ToString(((ActiveUnit)this).DesiredHeading));
			}
			if (DesiredSpeed != 0f)
			{
				theWriter.WriteElementString("DS", XmlConvert.ToString(DesiredSpeed));
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
			if (_Sensors.Count > 0)
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
			byte status;
			if (_Status != _ActiveUnitStatus.Unassigned)
			{
				XmlWriter obj = theWriter;
				status = (byte)_Status;
				obj.WriteElementString("Status", status.ToString());
			}
			if (_FuelState != _ActiveUnitFuelState.None)
			{
				XmlWriter obj2 = theWriter;
				status = (byte)_FuelState;
				obj2.WriteElementString("FuelState", status.ToString());
			}
			if ((byte)_WeaponState != 0)
			{
				theWriter.WriteElementString("WeaponState", ((byte)_WeaponState).ToString());
			}
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
			Doctrine.ToXML(ref theWriter, ref ParentScen);
			theWriter.WriteStartElement("CIC");
			CIC.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ParentScen);
			theWriter.WriteEndElement();
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

	public override void PostDeserializationHousekeeping_General(ref Scenario theScen, ConcurrentDictionary<string, ScenarioObject> theDictionary, List<ActiveUnit> DiscardList, bool GameIsRunning)
	{
		base.PostDeserializationHousekeeping_General(ref theScen, theDictionary, DiscardList, GameIsRunning);
		ActiveUnit_DockingOps.PostDeserializationHousekeeping(DockingOps, ref theScen, theDictionary, GameIsRunning);
		if (DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
		{
			((ActiveUnit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)((Module_Unit.Unit)this).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: true, ParentScen));
		}
	}

	private Facility()
	{
		Scenario theScen = null;
		base..ctor(ref theScen);
		CIC = new CIC(this, "Command Post");
		Cargo = new Cargo(this);
		ActiveUnit theUnit = this;
		facility_Navigator_0 = new Facility_Navigator(ref theUnit);
		theUnit = this;
		facility_AI_0 = new Facility_AI(ref theUnit);
		float_8 = 1f;
		theUnit = this;
		CommStuff = new Facility_CommStuff(ref theUnit);
		IsFacility = true;
		UnitType = GlobalVariables.ActiveUnitType.Facility;
	}

	public static List<Facility> SpawnFacilityFromCargoMountList(List<Mount> theMounts, Scenario theScen, Side theSide, bool SeparateByTypes = true)
	{
		List<Facility> list = new List<Facility>();
		checked
		{
			if (SeparateByTypes)
			{
				IEnumerable<VB$AnonymousType_5<IMobileGroundUnit._MobileUnitCategory, IEnumerable<Mount>>> enumerable = theMounts.GroupBy([SpecialName] (Mount m) => m.MobileUnitCategory, [SpecialName] (Mount m) => m, [SpecialName] (IMobileGroundUnit._MobileUnitCategory MobileUnitCategory, IEnumerable<Mount> $VB$ItAnonymous) => new VB$AnonymousType_5<IMobileGroundUnit._MobileUnitCategory, IEnumerable<Mount>>(MobileUnitCategory, $VB$ItAnonymous));
				foreach (VB$AnonymousType_5<IMobileGroundUnit._MobileUnitCategory, IEnumerable<Mount>> item in enumerable)
				{
					string text = "";
					IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = item.MobileUnitCategory;
					int num;
					int facilityDBID;
					string text2;
					if (mobileUnitCategory <= IMobileGroundUnit._MobileUnitCategory.Artillery_Gun)
					{
						if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Infantry)
						{
							if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Armor)
							{
								if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_Gun)
								{
									num = 2990;
									goto IL_0165;
								}
								facilityDBID = 2985;
								text2 = "Arty";
							}
							else
							{
								facilityDBID = 2983;
								text2 = "Armor";
							}
						}
						else
						{
							facilityDBID = 2987;
							text2 = "Inf";
						}
					}
					else if (mobileUnitCategory <= IMobileGroundUnit._MobileUnitCategory.SAM)
					{
						if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.AAA)
						{
							if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.SAM)
							{
								num = 2990;
								goto IL_0165;
							}
							facilityDBID = 2988;
							text2 = "SAM";
						}
						else
						{
							facilityDBID = 2989;
							text2 = "AAA";
						}
					}
					else if (mobileUnitCategory != (IMobileGroundUnit._MobileUnitCategory)10040)
					{
						if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.MechInfantry)
						{
							num = 2990;
							goto IL_0165;
						}
						facilityDBID = 2984;
						text2 = "Mech Inf";
					}
					else
					{
						facilityDBID = 2986;
						text2 = "Recon";
					}
					goto IL_018e;
					IL_018e:
					Facility facility = null;
					facility = theScen.AddNewFacility(theSide, facilityDBID, text + text2 + " #" + Conversions.ToString(theScen.UnitsAutoIncrement), 0.0, 0.0, IgnoreElevationCheck: true);
					facility.Mounts.Clear();
					foreach (Mount mount in item.Mounts)
					{
						facility.Mounts.Add(mount);
						mount.ParentPlatform = facility;
					}
					Sensor[] sensors_Cached = facility.Sensors_Cached;
					for (int num2 = 0; num2 < sensors_Cached.Length; num2++)
					{
						sensors_Cached[num2].ParentPlatform = facility;
					}
					ArrayExtensions.Clear(ref facility.Magazines);
					list.Add(facility);
					continue;
					IL_0165:
					facilityDBID = num;
					text2 = "Landed Detachment";
					goto IL_018e;
				}
			}
			else
			{
				Facility facility2 = null;
				facility2 = theScen.AddNewFacility(theSide, 2990, "Landed Detachment #" + Conversions.ToString(theScen.UnitsAutoIncrement), 0.0, 0.0, IgnoreElevationCheck: true);
				facility2.Mounts.Clear();
				foreach (Mount theMount in theMounts)
				{
					facility2.Mounts.Add(theMount);
					theMount.ParentPlatform = facility2;
				}
				Sensor[] sensors_Cached2 = facility2.Sensors_Cached;
				for (int num3 = 0; num3 < sensors_Cached2.Length; num3++)
				{
					sensors_Cached2[num3].ParentPlatform = facility2;
				}
				ArrayExtensions.Clear(ref facility2.Magazines);
				list.Add(facility2);
			}
			return list;
		}
	}

	public static Facility LocateOrSpawnSupplyFacilityForCargoContainers(double destinationLat, double destinationLon, Scenario theScen, Side theSide, bool unloadingFuel, bool unloadingAmmo)
	{
		Facility facility = null;
		ActiveUnit[] array = theScen.ActiveUnits_List.InternalArray();
		float num = float.MaxValue;
		float num2 = 0f;
		ActiveUnit_DockingOps.ResupplyCapacity resupplyCapacity = ActiveUnit_DockingOps.ResupplyCapacity.None;
		ActiveUnit[] array2 = array;
		foreach (ActiveUnit activeUnit in array2)
		{
			if (activeUnit == null || activeUnit.get_UnitSide(SetSideOnly: false) != theSide || !activeUnit.IsFixedFacility)
			{
				continue;
			}
			Facility facility2 = (Facility)activeUnit;
			resupplyCapacity = facility2.DesignatedSupplier;
			if (facility2.IsSingleUnitAirbase || facility2.MobileUnitCategory() == IMobileGroundUnit._MobileUnitCategory.Supply || (resupplyCapacity == ActiveUnit_DockingOps.ResupplyCapacity.FuelAndMaterial && (unloadingFuel || unloadingAmmo)) || (unloadingFuel && resupplyCapacity == ActiveUnit_DockingOps.ResupplyCapacity.Fuel) || (unloadingAmmo && resupplyCapacity == ActiveUnit_DockingOps.ResupplyCapacity.Material))
			{
				num2 = Module_Unit.RangeToPoint_Horiz(facility2, destinationLat, destinationLon);
				if (num2 < 2f && num2 < num)
				{
					facility = facility2;
					num = num2;
				}
			}
		}
		if (facility == null)
		{
			facility = theScen.AddNewFacility(theSide, 1496, "Forward Arming and Refueling Point #" + Conversions.ToString(theScen.UnitsAutoIncrement), 0.0, 0.0, IgnoreElevationCheck: true);
			facility.UnitClass = "Supply Dump";
			((ActiveUnit)facility).set_IsAutoDetectable((Side)null, value: false);
			ArrayExtensions.Clear(ref facility.Magazines);
			facility.Teleport(ref theScen, destinationLon, destinationLat);
		}
		return facility;
	}

	public static Facility SpawnAircraftOpenParkingFacilityUnit(double destinationLat, double destinationLon, Scenario theScen, Side theSide)
	{
		Facility facility = theScen.AddNewFacility(theSide, 1391, "Aircraft Unloading Point #" + Conversions.ToString(theScen.UnitsAutoIncrement), 0.0, 0.0, IgnoreElevationCheck: true);
		facility.UnitClass = "Aircraft Unloadoing Point";
		((ActiveUnit)facility).set_IsAutoDetectable((Side)null, value: false);
		facility.Teleport(ref theScen, destinationLon, destinationLat);
		return facility;
	}

	public static Facility FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, Facility existingObject = null)
	{
		Facility facility = default(Facility);
		try
		{
			facility = smethod_1(ref theNode, ref theDictionary, ref theScen, theScen.LoadStockUnits, existingObject);
		}
		catch (PlatformComponentNotFoundException projectError)
		{
			ProjectData.SetProjectError((Exception)projectError);
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			ConcurrentDictionary<string, ScenarioObject> obj = theDictionary;
			ScenarioObject value = facility;
			obj.TryRemove(innerText, out value);
			facility = smethod_1(ref theNode, ref theDictionary, ref theScen, bool_3: true, existingObject);
			string text = "";
			if (facility.IsGroupMember())
			{
				text = "(member of group: [" + ((ActiveUnit)facility).get_ParentGroup(UsingMissionPlanner: false).Name + "])";
			}
			theScen.LoadingNotices.Add("The following facility:[" + facility.Name + "]" + text + " failed to shallow-rebuild because of a component missing. The facility was instead deep-rebuilt, and instantiated in its pristine DB-stock condition. All customizations present in the facility's components (damaged components, weapon additions/removals etc. etc.) have been lost. Please re-apply any necessary customizations either manually or using an SBR script.");
			ProjectData.ClearProjectError();
		}
		return facility;
	}

	private static Facility smethod_1(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0, bool bool_3, Facility facility_0 = null)
	{
		//IL_06eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f2: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0660: Unknown result type (might be due to invalid IL or missing references)
		//IL_0667: Expected O, but got Unknown
		//IL_04af: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Expected O, but got Unknown
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Expected O, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Expected O, but got Unknown
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Expected O, but got Unknown
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_0560: Unknown result type (might be due to invalid IL or missing references)
		//IL_0567: Expected O, but got Unknown
		//IL_1476: Unknown result type (might be due to invalid IL or missing references)
		//IL_147d: Expected O, but got Unknown
		//IL_0f57: Unknown result type (might be due to invalid IL or missing references)
		Facility result = default(Facility);
		try
		{
			bool flag;
			Facility theFac;
			if (flag = facility_0 != null)
			{
				theFac = facility_0;
				theFac.Reinitialize();
			}
			else
			{
				theFac = new Facility();
			}
			theFac.ParentScen = scenario_0;
			string text = Misc.GetNodeByName(xmlNode_0.ChildNodes, "ID").InnerText;
			if (Misc.ContainsChar(text, ' '))
			{
				text = text.Replace(" ", "-");
			}
			if (concurrentDictionary_0.ContainsKey(text))
			{
				result = (Facility)concurrentDictionary_0[text];
			}
			else
			{
				theFac.ObjectID_Set(text);
				if (xmlNode_0.ChildNodes.Count == 1)
				{
					scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
					result = theFac;
				}
				else
				{
					concurrentDictionary_0.TryAdd(theFac.ObjectID, theFac);
					int num = Conversions.ToInteger(Misc.GetNodeByName(xmlNode_0.ChildNodes, "DBID").InnerText);
					try
					{
						DBFunctions.GetFacility(ref scenario_0, ref theFac, num, bool_3);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
						string objectID = theFac.ObjectID;
						ScenarioObject value = theFac;
						obj.TryRemove(objectID, out value);
						scenario_0.LoadingNotices.Add("Facility with Database ID " + Conversions.ToString(num) + " is missing from the database and has not been loaded.");
						ProjectData.ClearProjectError();
						goto end_IL_0001;
					}
					if (bool_3)
					{
						theFac.method_3(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
					}
					if (!bool_3)
					{
						foreach (XmlNode childNode in xmlNode_0.ChildNodes)
						{
							XmlNode val = childNode;
							theFac.CommonFromXML(val);
							switch (val.Name)
							{
							case "Comms":
								if (flag)
								{
									ArrayExtensions.Clear(ref theFac._Comms);
								}
								foreach (XmlNode childNode2 in val.ChildNodes)
								{
									XmlNode theNode7 = childNode2;
									CommDevice commDevice = CommDevice.FromXML(ref theNode7, ref concurrentDictionary_0, theFac);
									theFac.AddCommDevice(commDevice);
									commDevice.ParentPlatform = theFac;
								}
								break;
							case "OnboardCargo":
								if (flag)
								{
									ArrayExtensions.Clear(ref theFac.OnboardCargo);
								}
								foreach (XmlNode childNode3 in val.ChildNodes)
								{
									XmlNode theNode2 = childNode3;
									Cargo cargo = Cargo.FromXML(ref theNode2, ref concurrentDictionary_0, scenario_0, theFac);
									ArrayExtensions.Add(ref theFac.OnboardCargo, cargo);
									cargo.ParentPlatform = theFac;
								}
								break;
							case "Fuel":
								if (flag)
								{
									theFac._Fuel.Clear();
								}
								foreach (XmlNode childNode4 in val.ChildNodes)
								{
									XmlNode theNode8 = childNode4;
									FuelRec item = FuelRec.FromXML(ref theNode8, ref concurrentDictionary_0);
									theFac._Fuel.Add(item);
								}
								break;
							case "DockFacilities":
								if (flag)
								{
									ArrayExtensions.Clear(ref theFac._DockFacilities);
								}
								foreach (XmlNode childNode5 in val.ChildNodes)
								{
									XmlNode theNode5 = childNode5;
									DockFacility dockFacility = DockFacility.FromXML(ref theNode5, ref concurrentDictionary_0, ref scenario_0);
									theFac.AddDockFacility(dockFacility);
									dockFacility.ParentPlatform = theFac;
								}
								break;
							case "Sensors":
								if (flag)
								{
									theFac._Sensors.Clear();
								}
								foreach (XmlNode childNode6 in val.ChildNodes)
								{
									Sensor sensor = Sensor.FromXML(childNode6, concurrentDictionary_0, theFac);
									theFac._Sensors.Add(sensor);
									sensor.ParentPlatform = theFac;
								}
								break;
							case "Propulsion":
								if (flag)
								{
									theFac.Propulsion.Clear();
								}
								foreach (XmlNode childNode7 in val.ChildNodes)
								{
									XmlNode theNode3 = childNode7;
									ActiveUnit theParentPlatform = theFac;
									Engine engine = Engine.FromXML(ref theNode3, ref concurrentDictionary_0, ref theParentPlatform);
									theFac.Propulsion.Add(engine);
									engine.ParentPlatform = theFac;
								}
								break;
							case "AirFacilities":
								if (flag)
								{
									ArrayExtensions.Clear(ref theFac._AirFacilities);
								}
								foreach (XmlNode childNode8 in val.ChildNodes)
								{
									XmlNode theNode6 = childNode8;
									AirFacility airFacility = AirFacility.FromXML(ref theNode6, ref concurrentDictionary_0, ref scenario_0);
									theFac.AddAirFacility(airFacility);
									airFacility.ParentPlatform = theFac;
								}
								break;
							case "Magazines":
								if (flag)
								{
									ArrayExtensions.Clear(ref theFac.Magazines);
								}
								foreach (XmlNode childNode9 in val.ChildNodes)
								{
									XmlNode theNode4 = childNode9;
									Magazine magazine = Magazine.FromXML(ref theNode4, ref concurrentDictionary_0, ref scenario_0);
									theFac.AddSharedMagazine(magazine, RaiseUiEvent: false);
									magazine.ParentPlatform = theFac;
								}
								break;
							case "Mounts":
								if (flag)
								{
									theFac.Mounts.Clear();
								}
								foreach (XmlNode childNode10 in val.ChildNodes)
								{
									XmlNode theNode = childNode10;
									Mount mount = Mount.FromXML(ref theNode, ref concurrentDictionary_0, theFac);
									if (mount != null)
									{
										theFac.Mounts.Add(mount);
										mount.ParentPlatform = theFac;
									}
								}
								break;
							}
						}
					}
					foreach (XmlNode childNode11 in xmlNode_0.ChildNodes)
					{
						XmlNode theNode9 = childNode11;
						if (theFac.isLastReportedInfoXMLField(theNode9.Name))
						{
							theFac.LastReportedInfoFromXMLField(theNode9.Name, theNode9.InnerText);
							continue;
						}
						switch (theNode9.Name)
						{
						case "FSBR":
							theFac._FuelStateBefore_NeedToRefuel = (_ActiveUnitFuelState)Conversions.ToByte(theNode9.InnerText);
							break;
						case "Status":
							if (Versioned.IsNumeric((object)theNode9.InnerText))
							{
								theFac.Status = (_ActiveUnitStatus)Conversions.ToByte(theNode9.InnerText);
							}
							else
							{
								theFac.Status = (_ActiveUnitStatus)Enum.Parse(typeof(_ActiveUnitStatus), theNode9.InnerText, ignoreCase: true);
							}
							if (theFac.Status == (_ActiveUnitStatus)9)
							{
								theFac.Status = _ActiveUnitStatus.RTB;
							}
							break;
						case "AMP_OC_Speed":
							theFac._MissionPlannerOverrideCancellation_Speed = XmlConvert.ToSingle(theNode9.InnerText);
							break;
						case "Name":
							theFac.Name = theNode9.InnerText;
							break;
						case "AL":
							theFac.AutonomyLevel = (DroneAutonomyLevel)Conversions.ToInteger(theNode9.InnerText);
							break;
						case "DTN":
						case "DesiredTurnRate_Navigation":
							theFac.DesiredTurnRate_Navigation = (Waypoint.TurnRateCategory)Conversions.ToByte(theNode9.InnerText);
							break;
						case "FuelState":
							theFac._FuelState = (_ActiveUnitFuelState)Conversions.ToByte(theNode9.InnerText);
							break;
						case "DamagePts":
							if (!bool_3)
							{
								((ActiveUnit)theFac).set_DamagePts(ScenEditAction: false, (Weapon)null, XmlConvert.ToSingle(theNode9.InnerText));
							}
							break;
						case "AMP_OC_DAO":
							theFac._MissionPlannerOverrideCancellation_DesiredAltitudeOverride = Misc.ParseBool(theNode9.InnerText);
							break;
						case "OldDamagePercent":
							theFac._OldDamagePercent = XmlConvert.ToSingle(theNode9.InnerText);
							break;
						case "COA":
							theFac.ChanceOfAppearance = Conversions.ToInteger(theNode9.InnerText);
							break;
						case "PrivateSnapshotMission":
							theFac.PrivateSnapshotMission = Mission.FromXML(ref theNode9, ref concurrentDictionary_0, ref scenario_0);
							break;
						case "DesiredHeading":
						case "DH":
							((ActiveUnit)theFac).set_DesiredHeading(TurnRate.Max, XmlConvert.ToSingle(theNode9.InnerText));
							break;
						case "SBPF_ThrottleSetting":
							switch (theNode9.InnerText)
							{
							case "Loiter":
								theFac._ThrottleBefore_WaitForPathfinder = Throttle.Loiter;
								break;
							default:
								theFac._ThrottleBefore_WaitForPathfinder = (Throttle)Conversions.ToByte(theNode9.InnerText);
								break;
							case "Flank":
								theFac._ThrottleBefore_WaitForPathfinder = Throttle.Flank;
								break;
							case "Full":
								theFac._ThrottleBefore_WaitForPathfinder = Throttle.Full;
								break;
							case "Cruise":
								theFac._ThrottleBefore_WaitForPathfinder = Throttle.Cruise;
								break;
							case "FullStop":
								theFac._ThrottleBefore_WaitForPathfinder = Throttle.FullStop;
								break;
							}
							break;
						case "AirOps":
						case "ActiveUnit_AirOps":
						{
							Facility facility8 = theFac;
							ActiveUnit theParentPlatform = theFac;
							facility8._AirOps = ActiveUnit_AirOps.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "SBR":
							theFac._StatusBefore_NeedToRefuel = (_ActiveUnitStatus)Conversions.ToByte(theNode9.InnerText);
							break;
						case "SBED_DesiredSpeedOverride":
							theFac._DesiredSpeedOverrideBefore_EngagedDefensive = XmlConvert.ToSingle(theNode9.InnerText);
							break;
						case "AI":
						case "Facility_AI":
						{
							Facility facility7 = theFac;
							ActiveUnit theParentPlatform = theFac;
							facility7.facility_AI_0 = Facility_AI.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "ThrottleSetting":
							switch (theNode9.InnerText)
							{
							case "FullStop":
								theFac.ThrottleSetting = Throttle.FullStop;
								break;
							case "Loiter":
								theFac.ThrottleSetting = Throttle.Loiter;
								break;
							case "Cruise":
								theFac.ThrottleSetting = Throttle.Cruise;
								break;
							case "Full":
								theFac.ThrottleSetting = Throttle.Full;
								break;
							default:
								theFac.ThrottleSetting = (Throttle)Conversions.ToByte(theNode9.InnerText);
								break;
							case "Flank":
								theFac.ThrottleSetting = Throttle.Flank;
								break;
							}
							break;
						case "Doctrine":
							if (flag)
							{
								theFac.Doctrine = Doctrine.FromXML(scenario_0, ref theNode9, theFac, theFac.Doctrine);
							}
							else
							{
								theFac.Doctrine = Doctrine.FromXML(scenario_0, ref theNode9, theFac);
							}
							break;
						case "ActiveEnterAreaTriggers":
							if (flag)
							{
								theFac.ActiveEnterAreaTriggers.Clear();
							}
							foreach (XmlNode childNode12 in theNode9.ChildNodes)
							{
								string innerText2 = childNode12.InnerText;
								theFac.ActiveEnterAreaTriggers.Add(innerText2);
							}
							break;
						case "SBED_ThrottleSetting":
							switch (theNode9.InnerText)
							{
							case "Loiter":
								theFac._ThrottleBefore_EngagedDefensive = Throttle.Loiter;
								break;
							case "Cruise":
								theFac._ThrottleBefore_EngagedDefensive = Throttle.Cruise;
								break;
							case "Full":
								theFac._ThrottleBefore_EngagedDefensive = Throttle.Full;
								break;
							default:
								theFac._ThrottleBefore_EngagedDefensive = (Throttle)Conversions.ToByte(theNode9.InnerText);
								break;
							case "Flank":
								theFac._ThrottleBefore_EngagedDefensive = Throttle.Flank;
								break;
							case "FullStop":
								theFac._ThrottleBefore_EngagedDefensive = Throttle.FullStop;
								break;
							}
							break;
						case "WeaponState":
							theFac._WeaponState = (_ActiveUnitWeaponState)Conversions.ToSByte(theNode9.InnerText);
							break;
						case "Prof":
							theFac.Proficiency = (GlobalVariables.ProficiencyLevel)Conversions.ToInteger(theNode9.InnerText);
							break;
						case "Facility_CommStuff":
						case "CommStuff":
						{
							Facility facility6 = theFac;
							ActiveUnit theParentPlatform = theFac;
							facility6.CommStuff = Facility_CommStuff.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "AMP_OC_DSO":
							theFac._MissionPlannerOverrideCancellation_DesiredSpeedOverride = XmlConvert.ToSingle(theNode9.InnerText);
							break;
						case "Cont":
							theFac.Control = XmlConvert.ToSingle(theNode9.InnerText.Replace(",", "."));
							break;
						case "OODA_D":
							theFac.HasCustomOODA = true;
							theFac.OODA_Detection = Conversions.ToShort(theNode9.InnerText);
							break;
						case "OODA_E":
							theFac.HasCustomOODA = true;
							theFac.OODA_Evasion = Conversions.ToShort(theNode9.InnerText);
							break;
						case "AssignedMission":
							if (theNode9.HasChildNodes)
							{
								XmlNode val4 = theNode9.ChildNodes[0];
								theFac._AssignedMissionOrPackage_ID = val4.InnerText;
							}
							break;
						case "Latitude_UnitEntersAreaCheck":
							theFac.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(theNode9.InnerText);
							break;
						case "EFSAR":
							theFac.EligibleForSAR = Misc.ParseBool(theNode9.InnerText);
							break;
						case "OODA_T":
							theFac.HasCustomOODA = true;
							theFac.OODA_Targeting = Conversions.ToShort(theNode9.InnerText);
							break;
						case "Longitude":
						case "Lon":
							((ActiveUnit)theFac).set_Longitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(theNode9.InnerText.Replace(",", ".")));
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
									continue;
								}
								if (DateTime.TryParse(val3.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.None, out result2))
								{
									theFac.ActiveRemainAreaTriggers.Add(key, result2);
									continue;
								}
								string innerText = val3.InnerText;
								long result3 = default(long);
								if (long.TryParse(innerText, out result3))
								{
									result2 = DateTime.FromBinary(Conversions.ToLong(val3.InnerText));
									theFac.ActiveRemainAreaTriggers.Add(key, result2);
								}
							}
							break;
						}
						case "Facility_Sensory":
						case "Sensory":
						{
							Facility facility5 = theFac;
							ActiveUnit theParentPlatform = theFac;
							facility5.facility_Sensory_0 = Facility_Sensory.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "CustomIcon":
							theFac.CustomIcon = theNode9.InnerText;
							break;
						case "Side":
							theFac._SideName = theNode9.InnerText;
							break;
						case "AssignedTaskPool":
							if (theNode9.HasChildNodes)
							{
								XmlNode val2 = theNode9.ChildNodes[0];
								theFac._AssignedTaskPool_ID = val2.InnerText;
							}
							break;
						case "DS":
						case "DesiredSpeed":
							theFac.DesiredSpeed = XmlConvert.ToSingle(theNode9.InnerText);
							break;
						case "IBPU":
							theFac.IsBeingPickedUp = Misc.ParseBool(theNode9.InnerText);
							break;
						case "SBR_ThrottleSetting":
							switch (theNode9.InnerText)
							{
							case "Loiter":
								theFac._ThrottleBefore_NeedToRefuel = Throttle.Loiter;
								break;
							case "Cruise":
								theFac._ThrottleBefore_NeedToRefuel = Throttle.Cruise;
								break;
							case "Full":
								theFac._ThrottleBefore_NeedToRefuel = Throttle.Full;
								break;
							default:
								theFac._ThrottleBefore_NeedToRefuel = (Throttle)Conversions.ToByte(theNode9.InnerText);
								break;
							case "Flank":
								theFac._ThrottleBefore_NeedToRefuel = Throttle.Flank;
								break;
							case "FullStop":
								theFac._ThrottleBefore_NeedToRefuel = Throttle.FullStop;
								break;
							}
							break;
						case "Message":
							theFac.Message = theNode9.InnerText;
							break;
						case "Damage":
						case "Facility_Damage":
						{
							Facility facility4 = theFac;
							ActiveUnit theParentPlatform = theFac;
							facility4.facility_Damage_0 = Facility_Damage.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "DockingOps":
						case "ActiveUnit_DockingOps":
						{
							Facility facility3 = theFac;
							ActiveUnit theParentPlatform = theFac;
							facility3.DockingOps = ActiveUnit_DockingOps.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "Latitude":
						case "Lat":
							((ActiveUnit)theFac).set_Latitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(theNode9.InnerText.Replace(",", ".")));
							break;
						case "AMP_OC":
							theFac._MissionPlannerOverrideCancellation = Misc.ParseBool(theNode9.InnerText);
							break;
						case "DT":
						case "DesiredTurnRate":
							theFac.DesiredTurnRate = (TurnRate)Conversions.ToByte(theNode9.InnerText);
							break;
						case "CS":
						case "CurrentSpeed":
							theFac.CurrentSpeed = XmlConvert.ToSingle(theNode9.InnerText);
							break;
						case "SBEO":
							theFac._StatusBefore_EngagedOffensive = (_ActiveUnitStatus)Conversions.ToByte(theNode9.InnerText);
							break;
						case "Facility_Navigator":
						case "Navigator":
						{
							Facility facility2 = theFac;
							ActiveUnit theParentPlatform = theFac;
							facility2.facility_Navigator_0 = Facility_Navigator.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "SBED":
							theFac._StatusBefore_EngagedDefensive = (_ActiveUnitStatus)Conversions.ToByte(theNode9.InnerText);
							break;
						case "Facility_Weaponry":
						case "Weaponry":
						{
							Facility facility = theFac;
							ActiveUnit theParentPlatform = theFac;
							facility.facility_Weaponry_0 = Facility_Weaponry.FromXML(ref theNode9, ref concurrentDictionary_0, ref theParentPlatform);
							break;
						}
						case "SBEO_ThrottleSetting":
							switch (theNode9.InnerText)
							{
							case "FullStop":
								theFac._ThrottleBefore_EngagedOffensive = Throttle.FullStop;
								break;
							case "Loiter":
								theFac._ThrottleBefore_EngagedOffensive = Throttle.Loiter;
								break;
							case "Cruise":
								theFac._ThrottleBefore_EngagedOffensive = Throttle.Cruise;
								break;
							case "Full":
								theFac._ThrottleBefore_EngagedOffensive = Throttle.Full;
								break;
							case "Flank":
								theFac._ThrottleBefore_EngagedOffensive = Throttle.Flank;
								break;
							default:
								theFac._ThrottleBefore_EngagedOffensive = (Throttle)Conversions.ToByte(theNode9.InnerText);
								break;
							}
							break;
						case "ParentGroup":
							theFac._ParentGroup_ID = theNode9.InnerText;
							break;
						case "Kinematics":
						case "Facility_Kinematics":
							ActiveUnit_Kinematics.FromXML(theNode9, concurrentDictionary_0, theFac);
							break;
						case "CH":
						case "CurrentHeading":
							theFac.CurrentHeading = XmlConvert.ToSingle(theNode9.InnerText);
							break;
						case "IsAD":
						case "IsAutoDetectable":
							((ActiveUnit)theFac).set_IsAutoDetectable((Side)null, Misc.ParseBool(theNode9.InnerText));
							break;
						case "Longitude_UnitEntersAreaCheck":
							theFac.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(theNode9.InnerText);
							break;
						}
					}
					((ActiveUnit)theFac).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)((Module_Unit.Unit)theFac).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, theFac.ParentScen));
					theFac.EvaluateIfDumb();
					result = theFac;
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

	private string method_16()
	{
		return Category switch
		{
			_FacilityCategory.Building_Surface => "Building (Surface)", 
			_FacilityCategory.Building_Reveted => "Building (Reveted)", 
			_FacilityCategory.Building_Bunker => "Building (Bunker)", 
			_FacilityCategory.Building_Underground => "Building (Underground)", 
			_FacilityCategory.Structure_Open => "Structure (Open)", 
			_FacilityCategory.Structure_Reveted => "Structure (Reveted)", 
			_FacilityCategory.SurfaceAndUnderground => "Surface & Underground", 
			_FacilityCategory.Runway => "Runway", 
			_FacilityCategory.RunwayGrade_Taxiway => "Runway-Grade Taxiway", 
			_FacilityCategory.RunwayAccessPoint => "Runway Access Point", 
			_FacilityCategory.None => "None", 
			_FacilityCategory.Mobile_Vehicle => "Mobile Vehicle(s)", 
			_FacilityCategory.Mobile_Personnel => "Mobile Personnel", 
			_FacilityCategory.Mobile_Vehicule_Wheeled => "Wheeled Mobile Vehicule", 
			_FacilityCategory.Underwater => "Underwater", 
			_FacilityCategory.AirBase => "Air Base", 
			_FacilityCategory.AerostatMooring => "Aerostat Mooring", 
			_ => "None", 
		};
	}

	internal IMobileGroundUnit._MobileUnitCategory MobileUnitCategory()
	{
		if (!nullable_17.HasValue)
		{
			nullable_17 = MobileUnitCategory(Misc.FirstWord(UnitClass));
		}
		return nullable_17.Value;
	}

	public static IMobileGroundUnit._MobileUnitCategory MobileUnitCategory(string UnitClassString)
	{
		int result;
		switch (Misc.FirstWord(UnitClassString))
		{
		case "Mech":
			return IMobileGroundUnit._MobileUnitCategory.MechInfantry;
		case "AAA":
			return IMobileGroundUnit._MobileUnitCategory.AAA;
		case "Motor":
			return IMobileGroundUnit._MobileUnitCategory.MechInfantry;
		case "Radar":
			return IMobileGroundUnit._MobileUnitCategory.Surveillance;
		case "SSM":
			return IMobileGroundUnit._MobileUnitCategory.Artillery_SSM;
		case "SAM":
			return IMobileGroundUnit._MobileUnitCategory.SAM;
		case "Inf":
			return IMobileGroundUnit._MobileUnitCategory.Infantry;
		case "Armored":
			return IMobileGroundUnit._MobileUnitCategory.Armor;
		default:
			if (!UnitClassString.Contains("Ammo"))
			{
				if (UnitClassString.Contains("Fuel"))
				{
					result = 8000;
					goto IL_0199;
				}
				if (!UnitClassString.Contains("Supply"))
				{
					return IMobileGroundUnit._MobileUnitCategory.None;
				}
			}
			result = 8000;
			goto IL_0199;
		case "Arty":
			{
				return IMobileGroundUnit._MobileUnitCategory.Artillery_Gun;
			}
			IL_0199:
			return (IMobileGroundUnit._MobileUnitCategory)result;
		}
	}

	internal string MobileUnitCategory_String()
	{
		return MobileUnitCategory() switch
		{
			IMobileGroundUnit._MobileUnitCategory.Artillery_Towed => "Towed Artillery", 
			IMobileGroundUnit._MobileUnitCategory.Artillery_Gun => "Artillery", 
			IMobileGroundUnit._MobileUnitCategory.Armor => "Armor", 
			IMobileGroundUnit._MobileUnitCategory.None => "None", 
			IMobileGroundUnit._MobileUnitCategory.Infantry => "Infantry", 
			IMobileGroundUnit._MobileUnitCategory.MechInfantry => "Mechanized Infantry", 
			IMobileGroundUnit._MobileUnitCategory.Surveillance => "Surveillance", 
			IMobileGroundUnit._MobileUnitCategory.Engineer => "Engineer", 
			IMobileGroundUnit._MobileUnitCategory.SAM => "SAM", 
			IMobileGroundUnit._MobileUnitCategory.AAA => "AAA", 
			IMobileGroundUnit._MobileUnitCategory.Artillery_SSM => "Missile Artillery", 
			_ => throw new NotImplementedException(), 
		};
	}

	private CommDevice[] method_17()
	{
		CommDevice[] array = new CommDevice[_Comms.Length - 1 + 1];
		if (_Comms.Length > 0)
		{
			Array.Copy(_Comms, array, _Comms.Length);
		}
		return array;
	}

	public Facility(ref Scenario theScen, string theGUID = null)
		: base(ref theScen, theGUID)
	{
		CIC = new CIC(this, "Command Post");
		Cargo = new Cargo(this);
		ActiveUnit theUnit = this;
		facility_Navigator_0 = new Facility_Navigator(ref theUnit);
		theUnit = this;
		facility_AI_0 = new Facility_AI(ref theUnit);
		float_8 = 1f;
		theUnit = this;
		CommStuff = new Facility_CommStuff(ref theUnit);
		IsFacility = true;
		UnitType = GlobalVariables.ActiveUnitType.Facility;
		EvaluateIfDumb();
	}

	public override void DoTypeSpecificActions(float elapsedTime, ref LockRandom theRNG)
	{
		DockingOps.DoDockingOps(elapsedTime);
	}

	public bool IsArtillery()
	{
		IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = MobileUnitCategory();
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
		else if (mobileUnitCategory > IMobileGroundUnit._MobileUnitCategory.Artillery_Rocket_Tracked)
		{
			if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_Mortar)
			{
				if (mobileUnitCategory == IMobileGroundUnit._MobileUnitCategory.Artillery_SSM)
				{
					result2 = 1;
					goto IL_005d;
				}
				result = 0;
				goto IL_0059;
			}
		}
		else if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_Rocket_Wheeled && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_Rocket_Tracked)
		{
			result = 0;
			goto IL_0059;
		}
		result2 = 1;
		goto IL_005d;
		IL_0059:
		return (byte)result != 0;
		IL_005d:
		return (byte)result2 != 0;
	}

	public Mount PickRandomAimpoint()
	{
		IEnumerable<Mount> source = Mounts.Where([SpecialName] (Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed);
		if (source.Count() <= 0)
		{
			return null;
		}
		int index = GameGeneral.GlobalRNG.Next(0, source.Count());
		return source.ElementAtOrDefault(index);
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

	public override bool CanMoveToThisLocation(double theLat, double theLon, ref int MovementCost, bool IsPathfindingQuery, bool UsePathfindingBufferDistance, bool IgnoreMinesBehindUs, ref bool CheckNoNavZones, bool CheckForIcepack, ref bool CheckForMines, float? DistanceFromUnit, short? ProvidedElevation, ref List<ActiveUnit> ProvidedPiers, float ProximityThreshold_Deg, bool CheckIfTargetIsOutsideProsecutionArea, bool CheckDistanceToNoNavZones, ref string UserFeedback, ref bool AllowBounce)
	{
		bool result;
		try
		{
			MovementCost = 1;
			if (ParentScen.NatureSideExists() && ParentScen.GetNatureSide().CustomEnvironmentZones != null)
			{
				CustomEnvironmentZone[] customEnvironmentZones = ParentScen.GetNatureSide().CustomEnvironmentZones;
				int num = 0;
				while (num < customEnvironmentZones.Length)
				{
					CustomEnvironmentZone customEnvironmentZone = customEnvironmentZones[num];
					if (!customEnvironmentZone.HasCustomTerrain || customEnvironmentZone.TerrainType != LandCover.LandCoverType.Water || !GeoPoint.IsInsideThisArea(theLat, theLon, customEnvironmentZone.Area_AsArray))
					{
						if (!(customEnvironmentZone.HasCustomTerrainHeight & (customEnvironmentZone.TerrainHeight < 0)) || !GeoPoint.IsInsideThisArea(theLat, theLon, customEnvironmentZone.Area_AsArray))
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
			if (!double.IsNaN(theLat) && !double.IsNaN(theLon))
			{
				if (!CheckIfTargetIsOutsideProsecutionArea || Status != _ActiveUnitStatus.EngagedOffensive || ActiveMissionOrPackage() == null || ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Patrol)
				{
					goto IL_0162;
				}
				Patrol patrol = (Patrol)ActiveMissionOrPackage();
				Geopoint_Struct geopoint_Struct = new Geopoint_Struct(theLon, theLat);
				if (!((Module_Unit.Unit)this).get_IsInsideThisArea(patrol.ProsecutionArea, ParentScen, UseCache: true) || GeoPoint.IsInsideThisArea(geopoint_Struct.Latitude, geopoint_Struct.Longitude, patrol.ProsecutionArea))
				{
					goto IL_0162;
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
			IL_01be:
			if (CheckDistanceToNoNavZones)
			{
				CheckNoNavZones = DistanceToNearestNoNavZone();
			}
			if ((!CheckNoNavZones && !IsPathfindingQuery) || !IsInsideNoNavZones(theLat, theLon, ProximityThreshold_Deg))
			{
				switch (method_18(theLat, theLon, ProvidedElevation))
				{
				case SamplingPointAccessibility.No:
					CheckNoNavZones = false;
					CheckForMines = false;
					UserFeedback = "The point is not accessible.";
					result = false;
					goto end_IL_0001;
				default:
					if (!((double)Terrain.GetMaxSlope(theLat, theLon, RequestIsFromGUI: false, ParentScen) > 0.75))
					{
						break;
					}
					result = false;
					goto end_IL_0001;
				case SamplingPointAccessibility.Yes_ShallowWater:
					break;
				}
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
			goto end_IL_0001;
			IL_0162:
			if (IsPathfindingQuery || !Navigator.HasPathfindingPlottedCourse || Status == _ActiveUnitStatus.EngagedOffensive)
			{
				goto IL_01be;
			}
			float num2 = (Information.IsNothing((object)DistanceFromUnit) ? Module_Unit.RangeToPoint_Horiz(this, theLat, theLon) : DistanceFromUnit.Value);
			if (!(num2 <= ((Module_Unit.Unit)this).get_HorizMovementDistanceOnThisTime(2f)))
			{
				goto IL_01be;
			}
			CheckNoNavZones = false;
			CheckForMines = false;
			result = true;
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

	private SamplingPointAccessibility method_18(double double_0, double double_1, short? nullable_18 = null)
	{
		SamplingPointAccessibility result = default(SamplingPointAccessibility);
		try
		{
			short num;
			if (nullable_18.HasValue)
			{
				num = nullable_18.Value;
			}
			else
			{
				(bool, short?) tuple = Terrain.PointIsOverland(double_0, double_1);
				if (tuple.Item1)
				{
					result = SamplingPointAccessibility.Yes_Overland;
					return result;
				}
				num = ((!tuple.Item2.HasValue) ? Terrain.GetElevation(double_0, double_1, RequestIsFromGUI: false, ParentScen) : tuple.Item2.Value);
			}
			if (num >= 0)
			{
				result = SamplingPointAccessibility.Yes_ShallowWater;
				return result;
			}
			result = SamplingPointAccessibility.No;
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
		((ActiveUnit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)((Module_Unit.Unit)this).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: true, ParentScen));
		Kinematics.ExportLocationEvent("Teleport");
	}

	internal float GetCargo_Crew()
	{
		if (!base.IsFixedFacility)
		{
			return 0f;
		}
		return Math.Max(1000f, (float)Area);
	}

	float ICargoHost.GetCargo_Crew()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Crew
		return this.GetCargo_Crew();
	}

	internal float GetCargo_Area()
	{
		if (base.IsFixedFacility)
		{
			return Math.Max(1000f, (float)Area);
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
		if (!base.IsFixedFacility)
		{
			return CargoType.NoCargo;
		}
		return CargoType.const_5;
	}

	CargoType ICargoHost.GetCargo_Type()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Type
		return this.GetCargo_Type();
	}

	internal float GetCargo_Mass()
	{
		if (!base.IsFixedFacility)
		{
			return 0f;
		}
		return Math.Max(1000f, (float)Area);
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

	internal bool GetCargo_ParadropCapable()
	{
		return false;
	}

	bool ICargoHost.GetCargo_ParadropCapable()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_ParadropCapable
		return this.GetCargo_ParadropCapable();
	}

	internal int GetLoadTime(List<Cargo> CargoItems)
	{
		return ActiveUnit_DockingOps.DEFAULT_CARGO_LOAD_TIME;
	}

	int ICargoHost.GetLoadTime(List<Cargo> CargoItems)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetLoadTime
		return this.GetLoadTime(CargoItems);
	}

	internal int GetUnloadTime(List<Cargo> CargoItems)
	{
		return ActiveUnit_DockingOps.DEFAULT_CARGO_UNLOAD_TIME;
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
		if (HasAimpoints)
		{
			CargoType cargoType = CargoType.NoCargo;
			foreach (Mount mount in Mounts)
			{
				if (mount.IsFacilityAimpoint)
				{
					CargoType requiredCargoType = mount.GetRequiredCargoType();
					if (requiredCargoType > cargoType)
					{
						cargoType = requiredCargoType;
					}
				}
			}
			return cargoType;
		}
		return CargoType.NoCargo;
	}

	public float GetRequiredCrewSpace()
	{
		if (HasAimpoints)
		{
			float num = 0f;
			foreach (Mount mount in Mounts)
			{
				if (mount.IsFacilityAimpoint)
				{
					num += mount.GetRequiredCrewSpace();
				}
			}
			return num;
		}
		return 0f;
	}

	public float GetRequiredArea()
	{
		if (!HasAimpoints)
		{
			return 0f;
		}
		float num = 0f;
		foreach (Mount mount in Mounts)
		{
			if (mount.IsFacilityAimpoint)
			{
				num += mount.GetRequiredArea();
			}
		}
		return (float)Math.Round(num, 3);
	}

	public float GetRequiredAreaStacked(ICargoHost Host, int TotalQuantity)
	{
		return GetRequiredArea() * (float)TotalQuantity;
	}

	public float GetRequiredMass()
	{
		if (HasAimpoints)
		{
			float num = 0f;
			foreach (Mount mount in Mounts)
			{
				if (mount.IsFacilityAimpoint)
				{
					num += mount.GetRequiredMass();
				}
			}
			return (float)Math.Round(num, 3);
		}
		return 0f;
	}

	public bool GetParadropCapable()
	{
		if (!HasAimpoints)
		{
			return false;
		}
		bool result = false;
		foreach (Mount mount in Mounts)
		{
			if (mount.IsFacilityAimpoint)
			{
				if (!mount.GetParadropCapable())
				{
					result = false;
					break;
				}
				result = true;
			}
		}
		return result;
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
		if (!IsMorituri)
		{
			if (Damage.DamagePercent > 0f)
			{
				return PlatformComponent._ComponentStatus.Damaged;
			}
			return PlatformComponent._ComponentStatus.Operational;
		}
		return PlatformComponent._ComponentStatus.Destroyed;
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
		return "Facility_" + DBID;
	}

	public string CargoObjectToXML(HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		return "<Facility>" + ObjectID + "</Facility>";
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
		return false;
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
		if (c != null && c.CargoObjectActiveUnit != null)
		{
			ActiveUnit cargoObjectActiveUnit = c.CargoObjectActiveUnit;
			if (cargoObjectActiveUnit.IsFacility && cargoObjectActiveUnit.DBID == DBID)
			{
				return true;
			}
		}
		return false;
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
		int num4 = Damages.Length - 1;
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
		if (Mounts.Count > 0)
		{
			float multiplier = 1f / (float)Mounts.Count;
			foreach (Mount mount in Mounts)
			{
				AggregateGroundUnit._PopulateArmorRatingCollection(mount.ArmorRating, ref ArrayByRef, multiplier);
			}
		}
		return ArrayByRef;
	}

	public GlobalVariables.ArmorRating GetMostCommonArmorRating()
	{
		Dictionary<GlobalVariables.ArmorRating, int> dictionary = new Dictionary<GlobalVariables.ArmorRating, int>();
		foreach (Mount mount in Mounts)
		{
			if (dictionary.ContainsKey(mount.ArmorRating))
			{
				dictionary[mount.ArmorRating]++;
			}
			else
			{
				dictionary.Add(mount.ArmorRating, 1);
			}
		}
		GlobalVariables.ArmorRating result = GlobalVariables.ArmorRating.None;
		int num = 0;
		foreach (KeyValuePair<GlobalVariables.ArmorRating, int> item in dictionary)
		{
			if (item.Value > num)
			{
				result = item.Key;
				num = item.Value;
			}
		}
		return result;
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

	static Facility()
	{
		Class72.smethod_20();
	}
}
