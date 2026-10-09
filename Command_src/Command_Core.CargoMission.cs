using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class CargoMission : Mission
{
	public enum CargoMissionType : byte
	{
		Delivery,
		Transfer
	}

	public List<ReferencePoint> Area;

	public List<ReferencePoint> Area_30nm_ChangeCheck;

	public List<ReferencePoint> Area_30nm_Buffered;

	public List<ReferencePoint> Area_1nm_Buffered;

	public List<ReferencePoint> Area_1nm_ChangeCheck;

	public TransportWave TransportWaveManifest;

	public List<CargoManifestItem> CargoToUnload;

	public bool InstantLoadingForNextManifest;

	public float TransitAltitude_Aircraft;

	public float StationAltitude_Aircraft;

	public ActiveUnit.Throttle TransitThrottle_Aircraft;

	public ActiveUnit.Throttle StationThrottle_Aircraft;

	public ActiveUnit.Throttle TransitThrottle_Ship;

	public ActiveUnit.Throttle StationThrottle_Ship;

	public bool RTBUponCompletion;

	public bool _IsFulfilled;

	public CargoMissionType Type;

	public ActiveUnit DestinationUnit;

	public bool MoveAllCargo;

	public bool AllowSelfDeliveryFromCargo;

	public bool AllowAllSelfDelivery;

	public bool UnpackAllContainers;

	private string string_2;

	private List<ActiveUnit> list_0;

	public List<ActiveUnit> AssignedUnits_Cached
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = Module_Mission.UnitsAssignedToMissionOrPackage(this, theScen);
			}
			return list_0;
		}
	}

	public override string DescriptionString => Type switch
	{
		CargoMissionType.Transfer => "Cargo Transfer", 
		CargoMissionType.Delivery => "Cargo Delivery", 
		_ => Type.ToString(), 
	};

	public override bool IsFulfilled()
	{
		int num = default(int);
		foreach (CargoManifestItem item in CargoToUnload)
		{
			num += item.quantity;
		}
		if (num == 0)
		{
			if (UnitsAssignedToMission.Count == 0)
			{
				return true;
			}
			foreach (KeyValuePair<ActiveUnit, ActiveUnit> item2 in UnitsAssignedToMission)
			{
				if (item2.Value.HasCargo)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public static bool IsValidDestinationUnit(Module_Unit.Unit theUnit, bool IgnorePlayerSide = false)
	{
		int result;
		if (theUnit != null)
		{
			if (!theUnit.IsActiveUnit)
			{
				result = 0;
				goto IL_008e;
			}
			ActiveUnit activeUnit = (ActiveUnit)theUnit;
			Side currentSide = activeUnit.ParentScen.GetCurrentSide();
			if (IgnorePlayerSide || activeUnit.get_UnitSide(SetSideOnly: false) == currentSide || Module_Side.IsAlliedWithThisSide(activeUnit.get_UnitSide(SetSideOnly: false), currentSide))
			{
				if (!activeUnit.IsGroup)
				{
					if (!activeUnit.IsFixedFacility && !activeUnit.IsShip)
					{
						result = 0;
						goto IL_008e;
					}
					return activeUnit is ICargoHost;
				}
				Group obj = (Group)activeUnit;
				Group.GroupType type = obj.Type;
				if (type == Group.GroupType.Installation || type - 5 <= Group.GroupType.SurfaceGroup)
				{
					return obj.CanHostCargo();
				}
			}
		}
		result = 0;
		goto IL_008e;
		IL_008e:
		return (byte)result != 0;
	}

	public override void PrePulseHousekeeping(Scenario theScen)
	{
		base.PrePulseHousekeeping(theScen);
		list_0 = null;
	}

	public override void Printout(StringBuilder PrintoutStringBuilder)
	{
		throw new NotImplementedException();
	}

	public CargoMission(Side theSide, Scenario thescen, string theName, MissionCategory theCategory, List<ReferencePoint> theArea, bool ValidateArea, ActiveUnit theDestinationUnit = null, bool theSelfDelivery = false, bool TheMoveAll = false, bool theAllSelfDelivery = false, bool theAutoUnpackContainers = false)
		: base(theSide, thescen, theName)
	{
		Area = new List<ReferencePoint>();
		Area_30nm_ChangeCheck = new List<ReferencePoint>();
		Area_30nm_Buffered = new List<ReferencePoint>();
		Area_1nm_Buffered = new List<ReferencePoint>();
		Area_1nm_ChangeCheck = new List<ReferencePoint>();
		CargoToUnload = new List<CargoManifestItem>();
		RTBUponCompletion = true;
		Type = CargoMissionType.Delivery;
		DestinationUnit = null;
		MoveAllCargo = false;
		AllowSelfDeliveryFromCargo = false;
		AllowAllSelfDelivery = false;
		UnpackAllContainers = false;
		MissionClass = _MissionClass.Cargo;
		Name = theName;
		Area = theArea;
		DestinationUnit = theDestinationUnit;
		AllowSelfDeliveryFromCargo = theSelfDelivery;
		if (AllowSelfDeliveryFromCargo)
		{
			AllowAllSelfDelivery = theAllSelfDelivery;
		}
		UnpackAllContainers = theAutoUnpackContainers;
		MoveAllCargo = TheMoveAll;
		TransitAltitude_Aircraft = 609.60004f;
		StationAltitude_Aircraft = 304.80002f;
		TransitThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
		StationThrottle_Aircraft = ActiveUnit.Throttle.Flank;
		TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
		StationThrottle_Ship = ActiveUnit.Throttle.Cruise;
		if (DestinationUnit != null)
		{
			Type = CargoMissionType.Transfer;
			TransitAltitude_Aircraft = 0f;
			StationAltitude_Aircraft = 0f;
		}
		string UserFeedback = default(string);
		if (ValidateArea && !ActiveUnit_Navigator.ValidateArea(Area, ref UserFeedback, theSide, thescen, "Cargo Mission '" + Name + "'"))
		{
			GameGeneral.SendMessageBoxToUI(UserFeedback, theSide);
		}
		Category = theCategory;
	}

	internal override void Reinitialize()
	{
		base.Reinitialize();
		Area.Clear();
		CargoToUnload.Clear();
		DestinationUnit = null;
		AllowSelfDeliveryFromCargo = false;
		AllowAllSelfDelivery = false;
		MoveAllCargo = false;
		UnpackAllContainers = false;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("CargoMission");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Name", Name);
			method_0(ref theWriter, ref ObjectsAlreadySerialized, ref theScen);
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
			XmlWriter obj = theWriter;
			byte transitThrottle_Aircraft = (byte)TransitThrottle_Aircraft;
			obj.WriteElementString("TransitThrottle_Aircraft", transitThrottle_Aircraft.ToString());
			XmlWriter obj2 = theWriter;
			transitThrottle_Aircraft = (byte)StationThrottle_Aircraft;
			obj2.WriteElementString("StationThrottle_Aircraft", transitThrottle_Aircraft.ToString());
			theWriter.WriteElementString("TransitAltitude_Aircraft", TransitAltitude_Aircraft.ToString());
			theWriter.WriteElementString("StationAltitude_Aircraft", StationAltitude_Aircraft.ToString());
			XmlWriter obj3 = theWriter;
			transitThrottle_Aircraft = (byte)TransitThrottle_Ship;
			obj3.WriteElementString("TransitThrottle_Ship", transitThrottle_Aircraft.ToString());
			XmlWriter obj4 = theWriter;
			transitThrottle_Aircraft = (byte)StationThrottle_Ship;
			obj4.WriteElementString("StationThrottle_Ship", transitThrottle_Aircraft.ToString());
			theWriter.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			theWriter.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			if (SecondaryAirBase != null)
			{
				theWriter.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				theWriter.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			Doctrine.ToXML(ref theWriter, ref theScen);
			if (Area.Count > 0)
			{
				theWriter.WriteStartElement("Area");
				foreach (ReferencePoint item in Area)
				{
					theWriter.WriteRaw(item.ToXML(ref ObjectsAlreadySerialized));
				}
				theWriter.WriteEndElement();
			}
			theWriter.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			theWriter.WriteStartElement("MountsToUnload");
			foreach (CargoManifestItem item2 in CargoToUnload)
			{
				switch (item2.objectType)
				{
				case Cargo.CargoObjectType.Mount:
					theWriter.WriteStartElement("Mount");
					break;
				case Cargo.CargoObjectType.Vehicle:
					theWriter.WriteStartElement("Vehicle");
					break;
				case Cargo.CargoObjectType.Facility:
					theWriter.WriteStartElement("Facility");
					break;
				case Cargo.CargoObjectType.CargoContainer:
					theWriter.WriteStartElement("Container");
					theWriter.WriteAttributeString("Name", item2.Name);
					break;
				case Cargo.CargoObjectType.Aircraft:
					theWriter.WriteStartElement("Aircraft");
					break;
				}
				theWriter.WriteAttributeString("DBID", item2.DBID.ToString());
				if (!string.IsNullOrEmpty(item2.ObjectID))
				{
					theWriter.WriteAttributeString("ObjectID", item2.ObjectID);
				}
				theWriter.WriteString(item2.quantity.ToString());
				theWriter.WriteEndElement();
			}
			theWriter.WriteEndElement();
			if (base.get_Status(theScen) != MissionStatus.Active)
			{
				theWriter.WriteElementString("Status", ((byte)base.get_Status(theScen)).ToString());
			}
			theWriter.WriteElementString("RTBUponCompletion", RTBUponCompletion.ToString());
			if (Type != CargoMissionType.Delivery)
			{
				XmlWriter obj5 = theWriter;
				transitThrottle_Aircraft = (byte)Type;
				obj5.WriteElementString("CargoMissionType", transitThrottle_Aircraft.ToString());
			}
			if (DestinationUnit != null)
			{
				theWriter.WriteElementString("DestinationUnit", DestinationUnit.ObjectID);
			}
			if (AllowSelfDeliveryFromCargo)
			{
				theWriter.WriteElementString("ASD", ((byte)(0u - (AllowSelfDeliveryFromCargo ? 1u : 0u))).ToString());
			}
			if (AllowAllSelfDelivery)
			{
				theWriter.WriteElementString("AASD", ((byte)(0u - (AllowAllSelfDelivery ? 1u : 0u))).ToString());
			}
			if (MoveAllCargo)
			{
				theWriter.WriteElementString("MAC", ((byte)(0u - (MoveAllCargo ? 1u : 0u))).ToString());
			}
			if (UnpackAllContainers)
			{
				theWriter.WriteElementString("UAC", ((byte)(0u - (UnpackAllContainers ? 1u : 0u))).ToString());
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200654", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private CargoMission(Side theSide, Scenario theScen, string theName)
		: base(theSide, theScen, theName)
	{
		Area = new List<ReferencePoint>();
		Area_30nm_ChangeCheck = new List<ReferencePoint>();
		Area_30nm_Buffered = new List<ReferencePoint>();
		Area_1nm_Buffered = new List<ReferencePoint>();
		Area_1nm_ChangeCheck = new List<ReferencePoint>();
		CargoToUnload = new List<CargoManifestItem>();
		RTBUponCompletion = true;
		Type = CargoMissionType.Delivery;
		DestinationUnit = null;
		MoveAllCargo = false;
		AllowSelfDeliveryFromCargo = false;
		AllowAllSelfDelivery = false;
		UnpackAllContainers = false;
		MissionClass = _MissionClass.Cargo;
	}

	public new static CargoMission FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, Mission existingObject = null)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0928: Unknown result type (might be due to invalid IL or missing references)
		//IL_092f: Expected O, but got Unknown
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Expected O, but got Unknown
		CargoMission result = default(CargoMission);
		try
		{
			bool flag;
			CargoMission cargoMission;
			if (flag = existingObject != null)
			{
				cargoMission = (CargoMission)existingObject;
				cargoMission.Reinitialize();
			}
			else
			{
				cargoMission = new CargoMission(null, theScen, "");
			}
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				Mission.FromXMLCommon(cargoMission, theNode2);
				switch (theNode2.Name)
				{
				case "START":
				{
					DateTime value2 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					cargoMission._StartTime = value2;
					break;
				}
				case "Status":
					((Mission)cargoMission).set_Status(theScen, (MissionStatus)Conversions.ToByte(theNode2.InnerText));
					break;
				case "UseFlightplan":
					cargoMission.UseFlightplans = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Name":
					cargoMission.Name = theNode2.InnerText;
					break;
				case "Area":
					if (flag)
					{
						cargoMission.Area.Clear();
					}
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						cargoMission.Area.Add(ReferencePoint.FromXML(ref theNode3, ref theDictionary, theScen));
					}
					break;
				case "SISIH":
					cargoMission.ScrubIfSideIsHuman = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TransitThrottle_Ship":
					cargoMission.TransitThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "CargoMissionType":
					cargoMission.Type = (CargoMissionType)Conversions.ToByte(theNode2.InnerText);
					break;
				case "UseFlightplansOnly":
					cargoMission.UsePreGeneratedFlightplansOnly = Misc.ParseBool(theNode2.InnerText);
					break;
				case "MAC":
					cargoMission.MoveAllCargo = true;
					break;
				case "StationThrottle_Ship":
					cargoMission.StationThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TimeOnTarget":
				{
					DateTime value4 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					cargoMission.TimeOnTarget = value4;
					break;
				}
				case "Doctrine":
					if (!flag)
					{
						cargoMission.Doctrine = Doctrine.FromXML(theScen, ref theNode2, cargoMission);
					}
					else
					{
						cargoMission.Doctrine = Doctrine.FromXML(theScen, ref theNode2, cargoMission, cargoMission.Doctrine);
					}
					break;
				case "HomeNavalbase":
					cargoMission._SecondaryNavalBaseID = theNode2.InnerText;
					break;
				case "TakeOffTime":
				{
					DateTime value3 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					cargoMission.TakeOffTime = value3;
					break;
				}
				case "ID":
					if (!theDictionary.ContainsKey(theNode2.InnerText))
					{
						cargoMission.ObjectID_Set(theNode2.InnerText);
						theDictionary.TryAdd(cargoMission.ObjectID, cargoMission);
						break;
					}
					result = (CargoMission)theDictionary[theNode2.InnerText];
					return result;
				case "ASD":
					cargoMission.AllowSelfDeliveryFromCargo = true;
					break;
				case "AASD":
					cargoMission.AllowAllSelfDelivery = true;
					break;
				case "RTBUponCompletion":
					cargoMission.RTBUponCompletion = Misc.ParseBool(theNode2.InnerText);
					break;
				case "MountsToUnload":
					if (flag)
					{
						cargoMission.CargoToUnload.Clear();
					}
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode val2 = childNode3;
						int theDBID = int.Parse(((XmlNamedNodeMap)val2.Attributes).GetNamedItem("DBID").Value);
						CargoManifestItem cargoManifestItem = null;
						string theObjectID = "";
						string text = "";
						if (((XmlNamedNodeMap)val2.Attributes).GetNamedItem("ObjectID") != null)
						{
							theObjectID = ((XmlNamedNodeMap)val2.Attributes).GetNamedItem("ObjectID").Value;
						}
						if (((XmlNamedNodeMap)val2.Attributes).GetNamedItem("Name") != null)
						{
							text = ((XmlNamedNodeMap)val2.Attributes).GetNamedItem("Name").Value;
						}
						switch (val2.Name)
						{
						case "Facility":
							cargoManifestItem = new CargoManifestItem(Cargo.CargoObjectType.Facility, theDBID, theObjectID);
							break;
						case "Container":
							cargoManifestItem = new CargoManifestItem(Cargo.CargoObjectType.CargoContainer, theDBID, theObjectID);
							break;
						case "Aircraft":
							cargoManifestItem = new CargoManifestItem(Cargo.CargoObjectType.Aircraft, theDBID, theObjectID);
							break;
						case "Vehicle":
							cargoManifestItem = new CargoManifestItem(Cargo.CargoObjectType.Vehicle, theDBID, theObjectID);
							break;
						case "Mount":
							cargoManifestItem = new CargoManifestItem(Cargo.CargoObjectType.Mount, theDBID);
							break;
						}
						if (cargoManifestItem != null)
						{
							cargoManifestItem.quantity = int.Parse(val2.InnerText);
							if (string.IsNullOrEmpty(text))
							{
								cargoManifestItem.GenerateName(theScen);
							}
							else
							{
								cargoManifestItem._Name = text;
							}
							cargoMission.CargoToUnload.Add(cargoManifestItem);
						}
					}
					break;
				case "UAC":
					cargoMission.UnpackAllContainers = true;
					break;
				case "HomeAirbase":
					cargoMission._SecondaryAirBaseID = theNode2.InnerText;
					break;
				case "DestinationUnit":
					cargoMission.string_2 = theNode2.InnerText;
					break;
				case "END":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					cargoMission._EndTime = value;
					break;
				}
				case "_Phase":
					cargoMission._Phase = (MissionPhase)Conversions.ToByte(theNode2.InnerText);
					break;
				case "PriorityWeight":
					cargoMission.PriorityWeight = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "StationAltitude_Aircraft":
					cargoMission.StationAltitude_Aircraft = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "AssignedUnitsList":
					foreach (XmlNode childNode4 in theNode2.ChildNodes)
					{
						XmlNode val = childNode4;
						cargoMission.UnitsAssignedToMissionIDs.Add(val.InnerText);
					}
					break;
				case "TransitAltitude_Aircraft":
					cargoMission.TransitAltitude_Aircraft = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "StationThrottle_Aircraft":
					cargoMission.StationThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TransitThrottle_Aircraft":
					cargoMission.TransitThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "Completion":
					cargoMission.Completion = Conversions.ToSingle(theNode2.InnerText);
					break;
				}
			}
			if (cargoMission.TransitThrottle_Aircraft == ActiveUnit.Throttle.FullStop)
			{
				cargoMission.TransitThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
			}
			if (cargoMission.StationThrottle_Aircraft == ActiveUnit.Throttle.FullStop)
			{
				cargoMission.StationThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
			}
			if (cargoMission.TransitThrottle_Ship == ActiveUnit.Throttle.FullStop)
			{
				cargoMission.TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
			}
			if (cargoMission.StationThrottle_Ship == ActiveUnit.Throttle.FullStop)
			{
				cargoMission.StationThrottle_Ship = ActiveUnit.Throttle.Cruise;
			}
			result = cargoMission;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200656", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void PostDeserializationHousekeeping(ref Scenario theScen, Side theSide, bool GameIsRunning, ref ConcurrentDictionary<string, ScenarioObject> ObjectsDictionary)
	{
		try
		{
			base.PostDeserializationHousekeeping(ref theScen, theSide, GameIsRunning, ref ObjectsDictionary);
			if (!string.IsNullOrEmpty(string_2))
			{
				DestinationUnit = theScen.ActiveUnits[string_2];
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200657", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override Mission Clone(bool DeepCloneRPs)
	{
		CargoMission cargoMission = (CargoMission)MemberwiseClone();
		cargoMission.ObjectID_Set(Guid.NewGuid().ToString());
		cargoMission.Name = "[CLONE] " + Name;
		if (Area.Count > 0)
		{
			cargoMission.Area = new ReferencePoint().CopyRefArea(ref Area, DeepCloneRPs);
		}
		if (DestinationUnit != null)
		{
			cargoMission.DestinationUnit = DestinationUnit;
		}
		cargoMission.MoveAllCargo = MoveAllCargo;
		cargoMission.AllowSelfDeliveryFromCargo = AllowSelfDeliveryFromCargo;
		cargoMission.AllowAllSelfDelivery = AllowAllSelfDelivery;
		cargoMission.CargoToUnload.Clear();
		return cargoMission;
	}

	static CargoMission()
	{
		Class72.smethod_20();
	}
}
