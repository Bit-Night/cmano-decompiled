using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Cargo : PlatformComponent
{
	public enum CargoObjectType
	{
		None,
		Mount,
		Vehicle,
		Facility,
		CargoContainer,
		CargoContainerContent,
		Aircraft
	}

	public enum CargoStorageType
	{
		StoredInternal,
		StoredExternal,
		TowedExternal
	}

	public const int CARGO_TRANSFER_DISTANCE_NM = 2;

	private CargoObjectType cargoObjectType_0;

	private ICargoClient icargoClient_0;

	private string string_1;

	private CargoStorageType cargoStorageType_0;

	internal const string TOWED_CARGO_NAME_STRING = "[TOWED] ";

	internal const string HOSTED_CARGO_NAME_STRING = "[HOSTED] ";

	public const int ADDITIONAL_MINUTES_TO_LOAD_AIRCRAFT_WITHOUT_PACKED_LOADOUT = 240;

	public const float SQUARE_FEET_PER_SQUARE_METER = 10.76391f;

	public const float SHORT_TONS_PER_METRIC_TON = 1.102311f;

	public const float POUNDS_PER_KILOGRAM = 2.204623f;

	public const float GALLONS_PER_LITER = 0.2641729f;

	public CargoStorageType StorageType
	{
		get
		{
			return cargoStorageType_0;
		}
		set
		{
			cargoStorageType_0 = value;
		}
	}

	public CargoObjectType InternalObjectType => cargoObjectType_0;

	public int CargoObjectQuantity
	{
		get
		{
			if (icargoClient_0 == null)
			{
				return 0;
			}
			return icargoClient_0.GetCargoQuantity();
		}
	}

	public CargoType RequiredCargoType
	{
		get
		{
			if (icargoClient_0 == null)
			{
				return CargoType.NoCargo;
			}
			return icargoClient_0.GetRequiredCargoType();
		}
	}

	public float RequiredCrewSpace
	{
		get
		{
			if (icargoClient_0 != null)
			{
				if (cargoStorageType_0 == CargoStorageType.TowedExternal)
				{
					return 0f;
				}
				return icargoClient_0.GetRequiredCrewSpace();
			}
			return 0f;
		}
	}

	public float RequiredArea
	{
		get
		{
			if (icargoClient_0 != null)
			{
				if (cargoStorageType_0 == CargoStorageType.TowedExternal)
				{
					return 0f;
				}
				return icargoClient_0.GetRequiredArea();
			}
			return 0f;
		}
	}

	public float RequiredMass
	{
		get
		{
			if (icargoClient_0 == null)
			{
				return 0f;
			}
			return icargoClient_0.GetRequiredMass();
		}
	}

	public float RequiredAreaExternal
	{
		get
		{
			if (icargoClient_0 == null)
			{
				return 0f;
			}
			return icargoClient_0.GetRequiredArea();
		}
	}

	public float RequiredCrewSpaceExternal
	{
		get
		{
			if (icargoClient_0 == null)
			{
				return 0f;
			}
			return icargoClient_0.GetRequiredCrewSpace();
		}
	}

	public bool isParadropCapable
	{
		get
		{
			if (icargoClient_0 != null)
			{
				return icargoClient_0.GetParadropCapable();
			}
			return false;
		}
	}

	public CargoObjectType CurrentType
	{
		get
		{
			return cargoObjectType_0;
		}
		private set
		{
			cargoObjectType_0 = value;
		}
	}

	public ICargoClient GetCargoClient => icargoClient_0;

	public ActiveUnit CargoObjectActiveUnit
	{
		get
		{
			CargoObjectType cargoObjectType = cargoObjectType_0;
			if ((uint)(cargoObjectType - 2) > 1u && cargoObjectType != CargoObjectType.Aircraft)
			{
				return null;
			}
			return (ActiveUnit)icargoClient_0;
		}
	}

	public CargoContainer CargoObjectContainer
	{
		get
		{
			CargoObjectType cargoObjectType = cargoObjectType_0;
			if (cargoObjectType == CargoObjectType.CargoContainer)
			{
				return (CargoContainer)icargoClient_0;
			}
			return null;
		}
	}

	public CargoContainerContent CargoObjectContainerContents
	{
		get
		{
			CargoObjectType cargoObjectType = cargoObjectType_0;
			if (cargoObjectType == CargoObjectType.CargoContainerContent)
			{
				return (CargoContainerContent)icargoClient_0;
			}
			return null;
		}
	}

	public string CargoObjectName
	{
		get
		{
			if (icargoClient_0 != null)
			{
				if (cargoStorageType_0 == CargoStorageType.TowedExternal)
				{
					if (Name == null)
					{
						Name = "[TOWED] " + icargoClient_0.GetCargoName();
					}
					return Name;
				}
				if (cargoObjectType_0 == CargoObjectType.Aircraft)
				{
					Aircraft aircraft = (Aircraft)icargoClient_0;
					if (aircraft.AirOps.HostAirFacility != null)
					{
						Name = "[HOSTED] " + icargoClient_0.GetCargoName() + " (" + Misc.RemoveHiddenString(aircraft.UnitClass) + ")";
					}
					else
					{
						Name = icargoClient_0.GetCargoName();
					}
					return Name;
				}
				if (cargoObjectType_0 == CargoObjectType.Vehicle)
				{
					if (((ActiveUnit)icargoClient_0).DockingOps.HostDockFacility == null)
					{
						Name = icargoClient_0.GetCargoName();
					}
					else
					{
						Name = "[HOSTED] " + icargoClient_0.GetCargoName();
					}
					return Name;
				}
				return icargoClient_0.GetCargoName();
			}
			return "(No cargo)";
		}
	}

	public string CargoObjectID
	{
		get
		{
			if (icargoClient_0 == null)
			{
				return "";
			}
			return icargoClient_0.GetCargoObjectID();
		}
	}

	public int CargoObjectDBID
	{
		get
		{
			if (icargoClient_0 != null)
			{
				return icargoClient_0.imethod_0();
			}
			return 0;
		}
	}

	public _ComponentStatus CargoObjectStatus
	{
		get
		{
			if (icargoClient_0 == null)
			{
				return _ComponentStatus.Destroyed;
			}
			return icargoClient_0.GetCargoObjectStatus();
		}
	}

	public _DamageSeverityFactor CargoObjectDamageSeverity
	{
		get
		{
			if (icargoClient_0 != null)
			{
				return icargoClient_0.GetCargoObjectDamageSeverity();
			}
			return _DamageSeverityFactor.Heavy;
		}
	}

	public string CargoObjectReasonForInoperative
	{
		get
		{
			if (icargoClient_0 != null)
			{
				return icargoClient_0.GetCargoObjectReasonForInoperative();
			}
			return "None";
		}
	}

	public string CargoObjectLossString
	{
		get
		{
			if (icargoClient_0 != null)
			{
				return icargoClient_0.GetCargoObjectLossString();
			}
			return "";
		}
	}

	public override void ResetIDs()
	{
		if (icargoClient_0 != null)
		{
			icargoClient_0.imethod_1();
		}
		base.ResetIDs();
	}

	public int GetAdditionalLoadTime()
	{
		if (cargoObjectType_0 == CargoObjectType.Aircraft)
		{
			Aircraft aircraft = (Aircraft)icargoClient_0;
			int result;
			if (aircraft.Loadout != null)
			{
				if (aircraft.Loadout.Role == Loadout.LoadoutRole.PackedForCargo)
				{
					goto IL_003e;
				}
				result = 240;
			}
			else
			{
				result = 240;
			}
			return result;
		}
		goto IL_003e;
		IL_003e:
		return 0;
	}

	public int GetAdditionalUnloadTimne()
	{
		return 0;
	}

	public bool IsMatch(Cargo c)
	{
		if (c == null)
		{
			return false;
		}
		return c.cargoObjectType_0 == cargoObjectType_0 && c.CargoObjectDBID == CargoObjectDBID;
	}

	internal bool WantsToUnload()
	{
		if (icargoClient_0 != null)
		{
			return icargoClient_0.WantsToUnload();
		}
		return false;
	}

	public string ToXML(HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			if (icargoClient_0 == null)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<Cargo>");
			stringBuilder.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					stringBuilder.Append("</Cargo>");
					return stringBuilder.ToString();
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
			if (_Status != _ComponentStatus.Operational)
			{
				StringBuilder stringBuilder2 = stringBuilder.Append("<Status>");
				byte status = (byte)_Status;
				stringBuilder2.Append(status.ToString()).Append("</Status>");
			}
			if (base.DamageSeverity != _DamageSeverityFactor.Light)
			{
				stringBuilder.Append("<DamageSeverity>").Append(((byte)base.DamageSeverity).ToString()).Append("</DamageSeverity>");
			}
			if (!string.IsNullOrEmpty(Name))
			{
				stringBuilder.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			}
			stringBuilder.Append("<CurrentType>").Append((byte)cargoObjectType_0).Append("</CurrentType>");
			if (cargoStorageType_0 != CargoStorageType.StoredInternal)
			{
				stringBuilder.Append("<StorageType>").Append((byte)cargoStorageType_0).Append("</StorageType>");
			}
			stringBuilder.Append(icargoClient_0.CargoObjectToXML(ObjectsAlreadySerialized, theScen));
			stringBuilder.Append("</Cargo>");
			return stringBuilder.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100658", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return "";
	}

	public override void Destroy(Side ComponentPlatformSide, bool ScenEditAction, bool IsAimpointFacility, bool RegisterAsLosses = true)
	{
		try
		{
			if (base.Status != _ComponentStatus.Destroyed)
			{
				base.Destroy(ComponentPlatformSide, ScenEditAction, IsAimpointFacility, RegisterAsLosses);
				if (icargoClient_0 != null)
				{
					icargoClient_0.DestroyCargoObject(ComponentPlatformSide, ScenEditAction, IsAimpointFacility, DestroyUnitNow: true, "Containing Unit Destroyed", null, RegisterAsLosses);
				}
				else
				{
					_ = Debugger.IsAttached;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100678", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Cargo FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen, ActiveUnit theAU, ICargoHost theHost = null)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		try
		{
			Cargo cargo = new Cargo();
			if (theHost == null && theAU != null && theAU is ICargoHost)
			{
				theHost = (ICargoHost)theAU;
			}
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				switch (theNode2.Name)
				{
				case "ID":
					if (!Information.IsNothing((object)theDictionary))
					{
						if (theDictionary.ContainsKey(theNode2.InnerText))
						{
							return (Cargo)theDictionary[theNode2.InnerText];
						}
						cargo.ObjectID_Set(theNode2.InnerText);
						theDictionary.TryAdd(cargo.ObjectID, cargo);
					}
					break;
				case "CargoContainer":
				{
					CargoContainer cargoContainer = CargoContainer.FromXML(ref theNode2, ref theDictionary, theScen, theAU, theHost);
					cargo.icargoClient_0 = cargoContainer;
					break;
				}
				case "Mount":
				{
					Mount mount = Mount.FromXML(ref theNode2, ref theDictionary, theAU);
					mount.ParentPlatform = null;
					cargo.icargoClient_0 = mount;
					break;
				}
				case "CargoContainerContent":
				{
					CargoContainerContent cargoContainerContent = CargoContainerContent.FromXML(ref theNode2, ref theDictionary, theScen, theAU, theHost);
					cargo.icargoClient_0 = cargoContainerContent;
					break;
				}
				case "Name":
					cargo.Name = theNode2.InnerText;
					break;
				case "Status":
					switch (theNode2.InnerText)
					{
					case "Operational":
						cargo._Status = _ComponentStatus.Operational;
						break;
					case "Damaged":
						cargo._Status = _ComponentStatus.Damaged;
						break;
					default:
						cargo._Status = (_ComponentStatus)Conversions.ToByte(theNode2.InnerText);
						break;
					case "Destroyed":
						cargo._Status = _ComponentStatus.Destroyed;
						break;
					}
					break;
				case "CurrentType":
					cargo.cargoObjectType_0 = (CargoObjectType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Aircraft":
				case "Vehicle":
				case "Facility":
					cargo.string_1 = theNode2.InnerText;
					break;
				case "StorageType":
					cargo.cargoStorageType_0 = (CargoStorageType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "DamageSeverity":
					cargo.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(theNode2.InnerText);
					break;
				}
			}
			return cargo;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100659", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return null;
	}

	public void PostDeserializationHousekeeping_General(ref Scenario theScen, ConcurrentDictionary<string, ScenarioObject> theDictionary, bool GameIsRunning)
	{
		ActiveUnit value;
		if (cargoObjectType_0 != CargoObjectType.Vehicle && cargoObjectType_0 != CargoObjectType.Facility && cargoObjectType_0 != CargoObjectType.Aircraft)
		{
			if (cargoObjectType_0 == CargoObjectType.CargoContainer)
			{
				Cargo[] onboardCargo = CargoObjectContainer.OnboardCargo;
				for (int i = 0; i < onboardCargo.Length; i = checked(i + 1))
				{
					onboardCargo[i].PostDeserializationHousekeeping_General(ref theScen, theDictionary, GameIsRunning);
				}
			}
		}
		else if (!theScen.ActiveUnits.TryGetValue(string_1, out value))
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		else if (value is ICargoClient)
		{
			icargoClient_0 = (ICargoClient)value;
		}
	}

	private Cargo()
		: base(null)
	{
		cargoObjectType_0 = CargoObjectType.None;
		icargoClient_0 = null;
		cargoStorageType_0 = CargoStorageType.StoredInternal;
	}

	public Cargo(ActiveUnit theParent)
		: base(theParent)
	{
		cargoObjectType_0 = CargoObjectType.None;
		icargoClient_0 = null;
		cargoStorageType_0 = CargoStorageType.StoredInternal;
	}

	public Cargo(ActiveUnit theParent, Mount mount)
		: base(theParent)
	{
		cargoObjectType_0 = CargoObjectType.None;
		icargoClient_0 = null;
		cargoStorageType_0 = CargoStorageType.StoredInternal;
		CurrentType = CargoObjectType.Mount;
		icargoClient_0 = mount;
	}

	public Cargo(ActiveUnit theParent, Vehicle theVehicle)
		: base(theParent)
	{
		cargoObjectType_0 = CargoObjectType.None;
		icargoClient_0 = null;
		cargoStorageType_0 = CargoStorageType.StoredInternal;
		CurrentType = CargoObjectType.Vehicle;
		icargoClient_0 = theVehicle;
	}

	public Cargo(ActiveUnit theParent, Facility theFac)
		: base(theParent)
	{
		cargoObjectType_0 = CargoObjectType.None;
		icargoClient_0 = null;
		cargoStorageType_0 = CargoStorageType.StoredInternal;
		CurrentType = CargoObjectType.Facility;
		icargoClient_0 = theFac;
	}

	public Cargo(ActiveUnit theParent, Aircraft theAircraft)
		: base(theParent)
	{
		cargoObjectType_0 = CargoObjectType.None;
		icargoClient_0 = null;
		cargoStorageType_0 = CargoStorageType.StoredInternal;
		CurrentType = CargoObjectType.Aircraft;
		icargoClient_0 = theAircraft;
	}

	public Cargo(ActiveUnit theParent, ActiveUnit theUnit)
	{
		cargoObjectType_0 = CargoObjectType.None;
		icargoClient_0 = null;
		cargoStorageType_0 = CargoStorageType.StoredInternal;
		if (theUnit is Vehicle)
		{
			CurrentType = CargoObjectType.Vehicle;
		}
		else if (!(theUnit is Facility))
		{
			if (!(theUnit is Aircraft))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else
			{
				CurrentType = CargoObjectType.Aircraft;
			}
		}
		else
		{
			CurrentType = CargoObjectType.Facility;
		}
		icargoClient_0 = (ICargoClient)theUnit;
	}

	public Cargo(ActiveUnit theAU, CargoContainer theContainer, ICargoHost theParent)
	{
		cargoObjectType_0 = CargoObjectType.None;
		icargoClient_0 = null;
		cargoStorageType_0 = CargoStorageType.StoredInternal;
		CurrentType = CargoObjectType.CargoContainer;
		theContainer.Parent = theParent;
		icargoClient_0 = theContainer;
	}

	public Cargo(ActiveUnit theAU, CargoContainerContent theContents, ICargoHost theParent)
	{
		cargoObjectType_0 = CargoObjectType.None;
		icargoClient_0 = null;
		cargoStorageType_0 = CargoStorageType.StoredInternal;
		CurrentType = CargoObjectType.CargoContainerContent;
		theContents.Parent = theParent;
		icargoClient_0 = theContents;
	}

	public static Cargo CreateNewCargo(CargoObjectType objectType, int DBID, ActiveUnit parentUnit, Scenario parentScen)
	{
		Cargo result = null;
		switch (objectType)
		{
		case CargoObjectType.Mount:
			result = new Cargo(parentUnit, DBFunctions.GetMount(DBID, ref parentScen));
			break;
		case CargoObjectType.Vehicle:
		{
			SQLiteConnection theConn = parentScen.DBConnection;
			string vehicleName = DBFunctions.GetVehicleName(DBID, ref theConn);
			vehicleName = vehicleName + " #" + Conversions.ToString(parentScen.UnitsAutoIncrement);
			Vehicle vehicle = parentScen.AddNewVehicle(parentUnit.get_UnitSide(SetSideOnly: false), DBID, vehicleName, parentUnit.get_Longitude((GlobalVariables.BooleanObject)null), parentUnit.get_Latitude((GlobalVariables.BooleanObject)null), IgnoreElevationCheck: true);
			((ActiveUnit)vehicle).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, parentUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			vehicle.DockingOps.LoadIntoCargo(parentUnit);
			result = new Cargo(parentUnit, vehicle);
			break;
		}
		case CargoObjectType.Facility:
		{
			SQLiteConnection theConn = parentScen.DBConnection;
			string facilityName = DBFunctions.GetFacilityName(DBID, ref theConn);
			facilityName = facilityName + " #" + Conversions.ToString(parentScen.UnitsAutoIncrement);
			Facility facility = parentScen.AddNewFacility(parentUnit.get_UnitSide(SetSideOnly: false), DBID, facilityName, parentUnit.get_Longitude((GlobalVariables.BooleanObject)null), parentUnit.get_Latitude((GlobalVariables.BooleanObject)null), IgnoreElevationCheck: true);
			((ActiveUnit)facility).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, parentUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			facility.DockingOps.LoadIntoCargo(parentUnit);
			result = new Cargo(parentUnit, facility);
			break;
		}
		case CargoObjectType.Aircraft:
		{
			SQLiteConnection theConn = parentScen.DBConnection;
			string aircraftName = DBFunctions.GetAircraftName(DBID, ref theConn);
			aircraftName = aircraftName + " #" + Conversions.ToString(parentScen.UnitsAutoIncrement);
			Aircraft aircraft = parentScen.AddNewAircraft(parentUnit.get_UnitSide(SetSideOnly: false), aircraftName, parentUnit.get_Longitude((GlobalVariables.BooleanObject)null), parentUnit.get_Latitude((GlobalVariables.BooleanObject)null), DBID, 0, parentUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, null, IgnoreOperationalCeiling: true);
			aircraft.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, parentUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			aircraft.DockingOps.LoadIntoCargo(parentUnit);
			result = new Cargo(parentUnit, aircraft);
			break;
		}
		}
		return result;
	}

	public static List<ActiveUnit> UnloadSingleCargoAtLocation(ActiveUnit UnloadingUnit, ref Cargo[] CargoList, Cargo UnloadItem, double destinationLatitude, double destinationLongitude, Scenario ParentScenario, Side UnitSide, bool paradropOnly)
	{
		List<Cargo> list = new List<Cargo>();
		list.Add(UnloadItem);
		return UnloadCargoAtLocation(UnloadingUnit, ref CargoList, list, destinationLatitude, destinationLongitude, ParentScenario, UnitSide, paradropOnly);
	}

	public static List<ActiveUnit> UnloadCargoAtLocation(ActiveUnit UnloadingUnit, ref Cargo[] CargoList, List<Cargo> UnloadList, double destinationLatitude, double destinationLongitude, Scenario ParentScenario, Side UnitSide, bool paradropOnly, bool ByUser = false)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		Cargo[] theArray = new Cargo[0];
		List<Mount> list2 = new List<Mount>();
		List<CargoContainer> list3 = new List<CargoContainer>();
		List<Aircraft> list4 = new List<Aircraft>();
		if (UnloadList != null)
		{
			foreach (Cargo Unload in UnloadList)
			{
				if (CargoList.Contains(Unload) && (!paradropOnly || Unload.isParadropCapable))
				{
					switch (Unload.CurrentType)
					{
					case CargoObjectType.Mount:
					{
						Mount item5 = (Mount)Unload.icargoClient_0;
						list2.Add(item5);
						ArrayExtensions.Add(ref theArray, Unload);
						break;
					}
					case CargoObjectType.Vehicle:
					{
						Vehicle item4 = (Vehicle)Unload.icargoClient_0;
						list.Add(item4);
						ArrayExtensions.Add(ref theArray, Unload);
						break;
					}
					case CargoObjectType.Facility:
					{
						Facility item3 = (Facility)Unload.icargoClient_0;
						list.Add(item3);
						ArrayExtensions.Add(ref theArray, Unload);
						break;
					}
					case CargoObjectType.CargoContainer:
					{
						CargoContainer item2 = (CargoContainer)Unload.icargoClient_0;
						list3.Add(item2);
						ArrayExtensions.Add(ref theArray, Unload);
						break;
					}
					case CargoObjectType.Aircraft:
					{
						Aircraft item = (Aircraft)Unload.icargoClient_0;
						list4.Add(item);
						ArrayExtensions.Add(ref theArray, Unload);
						break;
					}
					}
				}
			}
		}
		else
		{
			Cargo[] array = CargoList;
			foreach (Cargo cargo in array)
			{
				if (!paradropOnly || cargo.isParadropCapable)
				{
					switch (cargo.cargoObjectType_0)
					{
					case CargoObjectType.Mount:
					{
						Mount item5 = (Mount)cargo.icargoClient_0;
						list2.Add(item5);
						ArrayExtensions.Add(ref theArray, cargo);
						break;
					}
					case CargoObjectType.Vehicle:
					{
						Vehicle item4 = (Vehicle)cargo.icargoClient_0;
						list.Add(item4);
						ArrayExtensions.Add(ref theArray, cargo);
						break;
					}
					case CargoObjectType.Facility:
					{
						Facility item3 = (Facility)cargo.icargoClient_0;
						list.Add(item3);
						ArrayExtensions.Add(ref theArray, cargo);
						break;
					}
					case CargoObjectType.CargoContainer:
					{
						CargoContainer item2 = (CargoContainer)cargo.icargoClient_0;
						list3.Add(item2);
						ArrayExtensions.Add(ref theArray, cargo);
						break;
					}
					case CargoObjectType.Aircraft:
					{
						Aircraft item = (Aircraft)cargo.icargoClient_0;
						list4.Add(item);
						ArrayExtensions.Add(ref theArray, cargo);
						break;
					}
					}
				}
			}
		}
		if (list2.Count > 0)
		{
			List<Facility> collection = Facility.SpawnFacilityFromCargoMountList(list2, ParentScenario, UnitSide, SeparateByTypes: false);
			list.AddRange(collection);
		}
		foreach (ActiveUnit item6 in list)
		{
			item6.Teleport(ref ParentScenario, destinationLongitude, destinationLatitude);
			item6.DockingOps.UnloadFromCargo();
		}
		if (list3.Count > 0)
		{
			bool flag = false;
			bool flag2 = false;
			List<CargoContainer> list5 = new List<CargoContainer>();
			foreach (CargoContainer item7 in list3)
			{
				if (item7.OnboardCargo.Count() == 0)
				{
					continue;
				}
				if (item7.ContainerType == CargoContainer.CargoContainerType.Tank)
				{
					flag = true;
					continue;
				}
				Cargo[] onboardCargo = item7.OnboardCargo;
				foreach (Cargo cargo2 in onboardCargo)
				{
					CargoContainerContent cargoObjectContainerContents = cargo2.CargoObjectContainerContents;
					if (cargoObjectContainerContents != null && cargoObjectContainerContents.ContentType == CargoContainerContent.CargoContainerContentType.Ammunition)
					{
						flag2 = true;
					}
					else if (cargo2.CargoObjectActiveUnit != null && !list5.Contains(item7))
					{
						list5.Add(item7);
					}
				}
			}
			if (flag || flag2)
			{
				Facility destinationUnit = Facility.LocateOrSpawnSupplyFacilityForCargoContainers(destinationLatitude, destinationLongitude, ParentScenario, UnitSide, flag, flag2);
				UnloadCargoContainersToSupplyDump(UnloadingUnit, list3, destinationUnit);
			}
			foreach (CargoContainer item8 in list5)
			{
				UnloadCargoAtLocation(UnloadingUnit, ref item8.OnboardCargo, null, destinationLatitude, destinationLongitude, ParentScenario, UnitSide, paradropOnly, ByUser);
			}
		}
		if (list4.Count > 0)
		{
			List<ActiveUnit> list6 = new List<ActiveUnit>();
			if (UnloadingUnit != null)
			{
				if (UnloadingUnit.IsFixedFacility)
				{
					list6.Add(UnloadingUnit);
				}
				if (UnloadingUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
				{
					list6.Add(UnloadingUnit.get_ParentGroup(UsingMissionPlanner: false));
				}
				foreach (ActiveUnit unit in UnloadingUnit.get_UnitSide(SetSideOnly: false).Units)
				{
					if (unit != null && unit != UnloadingUnit && (unit.get_ParentGroup(UsingMissionPlanner: false) == null || unit.get_ParentGroup(UsingMissionPlanner: false) != UnloadingUnit.get_ParentGroup(UsingMissionPlanner: false)) && unit.RangeToUnit_Horiz(UnloadingUnit) <= 2f)
					{
						list6.Add(unit);
					}
				}
			}
			foreach (Aircraft item9 in list4)
			{
				bool flag3 = false;
				foreach (ActiveUnit item10 in list6)
				{
					if (item10.AirOps.CanHostThisAircraft(item9) == AirOpsAttemptResult.Success)
					{
						item9.DockingOps.UnloadFromCargo();
						item10.AirOps.AddThisAircraft(item9, GameIsRunning: true);
						flag3 = true;
						break;
					}
				}
				if (!flag3)
				{
					Facility facility = Facility.SpawnAircraftOpenParkingFacilityUnit(destinationLatitude, destinationLongitude, ParentScenario, UnitSide);
					if (facility != null)
					{
						item9.DockingOps.UnloadFromCargo();
						facility.AirOps.AddThisAircraft(item9, GameIsRunning: true);
						list6.Add(facility);
					}
				}
			}
		}
		if (!paradropOnly && UnloadList == null)
		{
			ArrayExtensions.Clear(ref CargoList);
		}
		else
		{
			CargoList = CargoList.Except(theArray).ToArray();
		}
		return list;
	}

	public static bool UnloadCargoContainersToSupplyDump(ActiveUnit unloadingUnit, List<CargoContainer> theContainers, ActiveUnit destinationUnit, bool SaveContainers = true)
	{
		if (destinationUnit == null)
		{
			return false;
		}
		CargoContainerContent cargoContainerContent = null;
		foreach (CargoContainer theContainer in theContainers)
		{
			Cargo[] theArray = new Cargo[0];
			Cargo[] onboardCargo = theContainer.OnboardCargo;
			foreach (Cargo cargo in onboardCargo)
			{
				cargoContainerContent = cargo.CargoObjectContainerContents;
				if (cargoContainerContent != null)
				{
					if (!cargoContainerContent.TransferToUnit(unloadingUnit, destinationUnit, cargo) || cargoContainerContent.GetCargoQuantity() > 0)
					{
						ArrayExtensions.Add(ref theArray, cargo);
					}
				}
				else
				{
					ArrayExtensions.Add(ref theArray, cargo);
				}
			}
			if (SaveContainers || theArray.Count() > 0)
			{
				theContainer.OnboardCargo = theArray;
				Cargo theAC = new Cargo(destinationUnit, theContainer, (ICargoHost)destinationUnit);
				ArrayExtensions.Add(ref destinationUnit.OnboardCargo, theAC);
			}
		}
		return true;
	}

	public static bool UnloadContainerContentsToUnit(CargoContainer theContainer, List<Cargo> theCargo, ActiveUnit theUnit)
	{
		bool result = false;
		foreach (Cargo item in theCargo)
		{
			if (item.CargoObjectContainerContents == null)
			{
				ICargoHost cargoHost = (ICargoHost)theUnit;
				if (cargoHost.CanLoad(item.GetCargoClient))
				{
					theContainer.Remove(item);
					item.ParentPlatform = theUnit;
					cargoHost.Add(item);
					result = true;
				}
				continue;
			}
			CargoContainerContent cargoObjectContainerContents = item.CargoObjectContainerContents;
			Cargo[] onboardCargo = theContainer.OnboardCargo;
			foreach (Cargo cargo in onboardCargo)
			{
				if (cargo.CargoObjectContainerContents != null && cargo.CargoObjectContainerContents.isMatch(cargoObjectContainerContents))
				{
					CargoContainerContent cargoObjectContainerContents2 = cargo.CargoObjectContainerContents;
					float quantity = 1f;
					switch (cargoObjectContainerContents.ContentType)
					{
					case CargoContainerContent.CargoContainerContentType.LiquidFuel:
						quantity = ((CargoLiquidFuel)cargoObjectContainerContents).CurrentQuantity;
						break;
					case CargoContainerContent.CargoContainerContentType.Ammunition:
						quantity = cargoObjectContainerContents.GetCargoQuantity();
						break;
					}
					if (cargoObjectContainerContents2.TransferToUnit(theUnit, theUnit, cargo, quantity))
					{
						result = true;
					}
					if (cargoObjectContainerContents2.GetCargoQuantity() <= 0)
					{
						ArrayExtensions.Remove(ref theContainer.OnboardCargo, cargo);
					}
					break;
				}
			}
		}
		return result;
	}

	public static bool LoadContainerContentsFromUnit(ActiveUnit theUnit, CargoContainer theContainer, List<Cargo> theCargo)
	{
		bool result = false;
		foreach (Cargo item in theCargo)
		{
			float quantity = 1f;
			if (item.CargoObjectContainerContents != null)
			{
				CargoContainerContent cargoObjectContainerContents = item.CargoObjectContainerContents;
				switch (cargoObjectContainerContents.ContentType)
				{
				case CargoContainerContent.CargoContainerContentType.LiquidFuel:
					quantity = ((CargoLiquidFuel)cargoObjectContainerContents).CurrentQuantity;
					break;
				case CargoContainerContent.CargoContainerContentType.Ammunition:
					quantity = cargoObjectContainerContents.GetCargoQuantity();
					break;
				}
				Cargo cargo = new Cargo(theUnit, cargoObjectContainerContents, theContainer);
				if (cargoObjectContainerContents.TransferFromUnit(theContainer, theUnit, cargo, quantity))
				{
					theContainer.Add(cargo);
					result = true;
				}
			}
			else if (theContainer.CanLoad(item.GetCargoClient))
			{
				((ICargoHost)theUnit).Remove(item);
				item.ParentPlatform = theContainer.ParentPlatform;
				theContainer.Add(item);
				result = true;
			}
		}
		return result;
	}

	public static int GetFuelMassInCargo(ActiveUnit theUnit, FuelRec._FuelType DesiredFuelType)
	{
		int num = 0;
		CargoContainer cargoContainer = null;
		CargoContainerContent cargoContainerContent = null;
		CargoLiquidFuel cargoLiquidFuel = null;
		Cargo[] onboardCargo = theUnit.OnboardCargo;
		for (int i = 0; i < onboardCargo.Length; i = checked(i + 1))
		{
			cargoContainer = onboardCargo[i].CargoObjectContainer;
			if (cargoContainer == null || cargoContainer.ContainerType != CargoContainer.CargoContainerType.Tank)
			{
				continue;
			}
			cargoContainerContent = cargoContainer.CargoArray[0].CargoObjectContainerContents;
			if (cargoContainerContent != null && cargoContainerContent.ContentType == CargoContainerContent.CargoContainerContentType.LiquidFuel)
			{
				cargoLiquidFuel = (CargoLiquidFuel)cargoContainerContent;
				if (cargoLiquidFuel.FuelType == DesiredFuelType && cargoLiquidFuel.CurrentQuantity > 0f)
				{
					num += (int)Math.Round(cargoLiquidFuel.GetMassForVolume(cargoLiquidFuel.CurrentQuantity));
				}
			}
		}
		return num;
	}

	public static bool UnloadCargoFuelToUnit(ActiveUnit HostUnit, ActiveUnit DestinationUnit, FuelRec._FuelType FuelTypeToTransfer = FuelRec._FuelType.NoFuel, float FuelQuantityToTransfer = float.MaxValue)
	{
		int result;
		if (HostUnit == null)
		{
			result = 0;
		}
		else
		{
			if (DestinationUnit != null)
			{
				bool flag = FuelTypeToTransfer == FuelRec._FuelType.NoFuel;
				float num = 0f;
				float num2 = 0f;
				float num3 = 0f;
				double num4 = 0.0;
				CargoContainer cargoContainer = null;
				CargoContainerContent cargoContainerContent = null;
				CargoLiquidFuel cargoLiquidFuel = null;
				foreach (FuelRec item in DestinationUnit.Fuel_ReadOnly)
				{
					if ((!flag && item.FuelType != FuelTypeToTransfer) || !(item.CurrentQuantity < (float)item.MaxQuantity))
					{
						continue;
					}
					num = (float)item.MaxQuantity - item.CurrentQuantity;
					if (num > FuelQuantityToTransfer)
					{
						num = FuelQuantityToTransfer;
					}
					Cargo[] onboardCargo = HostUnit.OnboardCargo;
					for (int i = 0; i < onboardCargo.Length; i = checked(i + 1))
					{
						cargoContainer = onboardCargo[i].CargoObjectContainer;
						if (cargoContainer == null || cargoContainer.ContainerType != CargoContainer.CargoContainerType.Tank)
						{
							continue;
						}
						Cargo cargo = cargoContainer.CargoArray[0];
						cargoContainerContent = cargo.CargoObjectContainerContents;
						if (cargoContainerContent == null || cargoContainerContent.ContentType != CargoContainerContent.CargoContainerContentType.LiquidFuel)
						{
							continue;
						}
						cargoLiquidFuel = (CargoLiquidFuel)cargoContainerContent;
						if (cargoLiquidFuel.FuelType == item.FuelType && cargoLiquidFuel.CurrentQuantity > 0f)
						{
							num2 = cargoLiquidFuel.GetVolumeForMass(num);
							if (num2 > cargoLiquidFuel.CurrentQuantity)
							{
								num3 = cargoLiquidFuel.GetMassForVolume(cargoLiquidFuel.CurrentQuantity);
								cargoLiquidFuel.CurrentQuantity = 0f;
								item.AddFuel(num3);
								num4 += (double)num3;
							}
							else
							{
								cargoLiquidFuel.CurrentQuantity -= num2;
								item.AddFuel(num);
								num4 += (double)num;
							}
						}
						if (cargoLiquidFuel.CurrentQuantity == 0f)
						{
							cargoContainer.Remove(cargo);
						}
					}
					if (!(num4 < (double)FuelQuantityToTransfer))
					{
						break;
					}
				}
				if (num4 > 0.0)
				{
					return true;
				}
				return false;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public static int GetWeaponCountInCargo(ActiveUnit theUnit, int DesiredWeaponDBID)
	{
		return 0;
	}

	public static bool UnloadCargoWeaponsToUnit(ActiveUnit HostUnit, ActiveUnit DestinationUnit, int int_1 = -1, int WeaponQuantityToTransfer = int.MaxValue)
	{
		int result;
		if (HostUnit == null)
		{
			result = 0;
		}
		else
		{
			if (DestinationUnit != null)
			{
				bool flag = int_1 == -1;
				int num = 0;
				int num2 = 0;
				Magazine[] totalMagazines = DestinationUnit.TotalMagazines;
				foreach (Magazine magazine in totalMagazines)
				{
					foreach (WeaponRec weapon in magazine.Weapons)
					{
						if (weapon.CurrentLoad >= weapon.MaxLoad || (!flag && weapon.int_3 != int_1))
						{
							continue;
						}
						num2 = weapon.MaxLoad - weapon.CurrentLoad;
						if (num + num2 <= WeaponQuantityToTransfer)
						{
							continue;
						}
						num2 = WeaponQuantityToTransfer - num;
						if (num2 > 0)
						{
							Cargo[] onboardCargo = HostUnit.OnboardCargo;
							for (int j = 0; j < onboardCargo.Length; j = checked(j + 1))
							{
								CargoContainer cargoObjectContainer = onboardCargo[j].CargoObjectContainer;
								if (cargoObjectContainer != null && cargoObjectContainer.ContainerType != CargoContainer.CargoContainerType.Tank)
								{
									for (int k = cargoObjectContainer.CargoArray.Count() - 1; k >= 0; k += -1)
									{
										Cargo cargo = cargoObjectContainer.CargoArray[k];
										CargoContainerContent cargoObjectContainerContents = cargo.CargoObjectContainerContents;
										if (cargoObjectContainerContents != null && cargoObjectContainerContents.ContentType == CargoContainerContent.CargoContainerContentType.Ammunition)
										{
											CargoAmmunition cargoAmmunition = (CargoAmmunition)cargoObjectContainerContents;
											if (cargoAmmunition.int_1 == weapon.int_3 && cargoAmmunition.WeaponQuantity > 0)
											{
												if (num2 > cargoAmmunition.WeaponQuantity)
												{
													weapon.CurrentLoad += cargoAmmunition.WeaponQuantity;
													num += cargoAmmunition.WeaponQuantity;
													cargoAmmunition.WeaponQuantity = 0;
												}
												else
												{
													weapon.CurrentLoad += num2;
													num += num2;
													cargoAmmunition.WeaponQuantity -= num2;
												}
											}
											if (cargoAmmunition.WeaponQuantity < 1)
											{
												Cargo[] theArray = cargoObjectContainer.CargoArray;
												ArrayExtensions.Remove(ref theArray, cargo);
												cargoObjectContainer.CargoArray = theArray;
											}
										}
										if (num >= WeaponQuantityToTransfer)
										{
											break;
										}
									}
								}
								if (num >= WeaponQuantityToTransfer)
								{
									break;
								}
							}
						}
						if (num >= WeaponQuantityToTransfer)
						{
							break;
						}
					}
				}
				if (num > 0)
				{
					return true;
				}
				return false;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public static List<CargoManifestItem> GenerateCargoManifest(List<Cargo> CargoList, bool GroupActiveUnits = false)
	{
		List<CargoManifestItem> list = new List<CargoManifestItem>();
		if (CargoList != null)
		{
			foreach (Cargo Cargo in CargoList)
			{
				CargoManifestItem.Add(Cargo, list, GroupActiveUnits);
			}
		}
		return list;
	}

	public static List<CargoManifestItem> GenerateCargoManifest(ActiveUnit cargoSource, bool IncludeSelf = true, bool GroupActiveUnits = false, bool GroupManifest = false)
	{
		List<CargoManifestItem> list = new List<CargoManifestItem>();
		checked
		{
			if (cargoSource != null)
			{
				if (cargoSource.IsGroup && GroupManifest)
				{
					Group obj = (Group)cargoSource;
					foreach (ActiveUnit value in obj.Units.Values)
					{
						Cargo[] onboardCargo = value.OnboardCargo;
						for (int i = 0; i < onboardCargo.Length; i++)
						{
							CargoManifestItem.Add(onboardCargo[i], list, GroupActiveUnits);
						}
					}
				}
				else
				{
					Cargo[] onboardCargo2 = cargoSource.OnboardCargo;
					for (int j = 0; j < onboardCargo2.Length; j++)
					{
						CargoManifestItem.Add(onboardCargo2[j], list, GroupActiveUnits);
					}
				}
			}
			if (IncludeSelf)
			{
				if (cargoSource is Vehicle)
				{
					Vehicle vehicle = (Vehicle)cargoSource;
					if (vehicle.GetRequiredCargoType() != CargoType.NoCargo)
					{
						CargoManifestItem.Add(new Cargo(null, vehicle), list);
					}
				}
				else if (cargoSource is Facility)
				{
					Facility facility = (Facility)cargoSource;
					if (facility.GetRequiredCargoType() != CargoType.NoCargo)
					{
						CargoManifestItem.Add(new Cargo(null, facility), list);
					}
				}
				foreach (Mount mount in cargoSource.Mounts)
				{
					if (mount.Cargo_Type != CargoType.NoCargo)
					{
						CargoManifestItem.Add(new Cargo(cargoSource, mount), list);
					}
				}
			}
			return list;
		}
	}

	public static string CargoMassLabel(bool USUnits)
	{
		return "tons";
	}

	public static string CargoSmallMassLabel(bool USUnits)
	{
		if (!USUnits)
		{
			return "kilograms";
		}
		return "pounds";
	}

	public static string CargoDistanceLabel(bool USUnits)
	{
		if (!USUnits)
		{
			return "meters";
		}
		return "feet";
	}

	public static string CargoAreaLabel(bool USUnits)
	{
		if (!USUnits)
		{
			return "sq.m.";
		}
		return "sq.ft.";
	}

	public static string CargoLiquidVolumeLabel(bool USUnits)
	{
		if (USUnits)
		{
			return "gallons";
		}
		return "liters";
	}

	public static float InputValueDistance(float inVal, bool USUnits)
	{
		if (!USUnits)
		{
			return inVal;
		}
		return inVal * 0.3048f;
	}

	public static float DisplayValueArea(float SquareMeters, bool USUnits)
	{
		if (USUnits)
		{
			return SquareMeters * 10.76391f;
		}
		return SquareMeters;
	}

	public static float InputValueArea(float inVal, bool USUnits)
	{
		if (!USUnits)
		{
			return inVal;
		}
		return inVal / 10.76391f;
	}

	public static float DisplayValueMass(float metricTons, bool USUnits)
	{
		if (USUnits)
		{
			return metricTons * 1.102311f;
		}
		return metricTons;
	}

	public static float InputValueMass(float inVal, bool USUnits)
	{
		if (USUnits)
		{
			return inVal / 1.102311f;
		}
		return inVal;
	}

	public static float DisplayValueSmallMass(float kg, bool USUnits)
	{
		if (!USUnits)
		{
			return kg;
		}
		return kg * 2.204623f;
	}

	public static float InputValueSmallMass(float inVal, bool USUnits)
	{
		if (!USUnits)
		{
			return inVal;
		}
		return inVal / 2.204623f;
	}

	public static float InputValueLiquidVolume(float inVal, bool USUnits)
	{
		if (!USUnits)
		{
			return inVal;
		}
		return inVal / 0.2641729f;
	}

	public static float DisplayValueLiquidVolume(float liters, bool USUnits)
	{
		if (!USUnits)
		{
			return liters;
		}
		return liters * 0.2641729f;
	}

	public static string CanUnloadToMap(ActiveUnit theUnit)
	{
		if (theUnit != null && theUnit is ICargoHost)
		{
			if (!theUnit.IsOperating())
			{
				return "The unit is currently hosted by another unit.";
			}
			ICargoHost cargoHost = (ICargoHost)theUnit;
			if (cargoHost.CargoArray.Count() == 0)
			{
				return "The unit is not currently carrying cargo.";
			}
			if (!theUnit.IsAircraft)
			{
				if (!theUnit.IsShip)
				{
					if (!theUnit.IsVehicle)
					{
						if (!theUnit.IsFixedFacility)
						{
							return "Unsupported unit type.";
						}
						if (Module_Unit.IsOverLand(theUnit))
						{
							return "Ok";
						}
						return "The facility is not on land.";
					}
					if (Module_Unit.IsOverLand(theUnit))
					{
						return "Ok";
					}
					return "The ground unit is not currently on land.";
				}
				if (!theUnit.DockingOps.CanUnloadCargoOverBeach())
				{
					return "The ship cannot unload cargo directly to the shore.";
				}
				if (theUnit.DockingOps.FindPossibleUnloadLocations().Count > 0)
				{
					return "Ok";
				}
				return "The ship is too far from land (more than 2nm) to unload cargo ashore.";
			}
			Aircraft aircraft = (Aircraft)theUnit;
			if (!Module_Unit.IsOverLand(aircraft))
			{
				return "The aircraft is not curently over land.";
			}
			if (!aircraft.IsHelicopter)
			{
				if (cargoHost.GetCargo_ParadropCapable())
				{
					Cargo[] cargoArray = cargoHost.CargoArray;
					int num = 0;
					while (true)
					{
						if (num < cargoArray.Length)
						{
							if (cargoArray[num].isParadropCapable)
							{
								break;
							}
							num = checked(num + 1);
							continue;
						}
						return "None of the cargo on board can be paradropped.";
					}
					return "Ok";
				}
				return "The aircraft's loadout is not capable of cargo paradrop.";
			}
			return "Ok";
		}
		return "The unit is not cargo capable.";
	}

	public static List<ActiveUnit> GetPossibleTransferDestinations(ActiveUnit theUnit)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		if (theUnit != null && (theUnit.IsVehicle || theUnit.IsFixedFacility))
		{
			List<ActiveUnit> list2 = new List<ActiveUnit>();
			bool isFixedFacility = theUnit.IsFixedFacility;
			Side[] sides_ReadOnly = theUnit.ParentScen.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				if (side == theUnit.get_UnitSide(SetSideOnly: false) || Module_Side.IsAlliedWithThisSide(side, theUnit.get_UnitSide(SetSideOnly: false)))
				{
					list2.AddRange(side.Units);
				}
			}
			foreach (ActiveUnit item in list2)
			{
				if (item != theUnit && item.IsOperating() && item is ICargoHost && ((ICargoHost)item).GetCargo_Type() != CargoType.NoCargo && (item.IsFixedFacility || (item.IsVehicle && isFixedFacility)))
				{
					if (theUnit.IsFixedFacility && item.IsFixedFacility && theUnit.get_ParentGroup(UsingMissionPlanner: false) != null && theUnit.get_ParentGroup(UsingMissionPlanner: false) == item.get_ParentGroup(UsingMissionPlanner: false))
					{
						list.Add(item);
					}
					else if (item.RangeToUnit_Horiz(theUnit) < 2f)
					{
						list.Add(item);
					}
				}
			}
		}
		return list;
	}

	public static ActiveUnit GetGroupCargoDestinationUnit(Group theGroup, ActiveUnit theUnit, Cargo theCargo)
	{
		if (theGroup != null && theUnit != null && theCargo != null)
		{
			List<ActiveUnit> list = theGroup.Units.Values.ToList();
			ActiveUnit activeUnit = null;
			ActiveUnit activeUnit2 = null;
			float num = float.MaxValue;
			if (theUnit.ActiveMissionOrPackage() != null && theUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Cargo)
			{
				activeUnit = ((CargoMission)theUnit.ActiveMissionOrPackage()).DestinationUnit;
			}
			foreach (ActiveUnit item in list)
			{
				if (item == theUnit || item.IsMorituri)
				{
					continue;
				}
				if (item != activeUnit)
				{
					if (item is ICargoHost && ((ICargoHost)item).CanLoad(theCargo.GetCargoClient))
					{
						if (item.OnboardCargo.Count() > 0)
						{
							return item;
						}
						float num2 = item.RangeToUnit_Horiz(theUnit);
						if (num2 < num)
						{
							activeUnit2 = item;
							num = num2;
						}
					}
					continue;
				}
				return item;
			}
			if (activeUnit2 == null)
			{
				activeUnit2 = ((list.Count <= 0) ? theGroup : list[0]);
			}
			return activeUnit2;
		}
		return null;
	}

	static Cargo()
	{
		Class72.smethod_20();
	}
}
