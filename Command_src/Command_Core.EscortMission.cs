using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EscortMission : Mission
{
	public string EscortTargetMissionID;

	public string EscortTargetUnitID;

	public _FlightQty MinimumNumberOfAircraft;

	public ActiveUnit.Throttle? TransitThrottle;

	public ActiveUnit.Throttle? AttackThrottle_Aircraft;

	public float? TransitAltitude_Aircraft;

	public float? AttackAltitude_Aircraft;

	public bool TransitTerrainFollowing_Aircraft;

	public bool AttackTerrainFollowing_Aircraft;

	public _AircraftFormationType Formation_Cruise;

	public _AircraftFormationType Formation_Attack;

	public EscortMission(ref Side theSide, ref Scenario theScen, string theName)
		: base(theSide, theScen, theName)
	{
		IsMission = true;
		Name = theName;
		MissionClass = _MissionClass.Escort;
	}

	internal override void Reinitialize()
	{
		base.Reinitialize();
		TransitThrottle = null;
		AttackThrottle_Aircraft = null;
		TransitAltitude_Aircraft = null;
		AttackAltitude_Aircraft = null;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("Mission");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Name", Name);
			theWriter.WriteElementString("Category", ((byte)Category).ToString());
			Doctrine.ToXML(ref theWriter, ref theScen);
			theWriter.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			theWriter.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			theWriter.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			theWriter.WriteElementString("ETMID", EscortTargetMissionID);
			if (base.get_Status(theScen) != MissionStatus.Active)
			{
				theWriter.WriteElementString("Status", ((byte)base.get_Status(theScen)).ToString());
			}
			if (TransitThrottle.HasValue)
			{
				theWriter.WriteElementString("TransitThrottle_Aircraft", Conversions.ToString((int)TransitThrottle.Value));
			}
			if (AttackThrottle_Aircraft.HasValue)
			{
				theWriter.WriteElementString("StationThrottle_Aircraft", Conversions.ToString((int)AttackThrottle_Aircraft.Value));
			}
			if (TransitAltitude_Aircraft.HasValue)
			{
				theWriter.WriteElementString("TransitAltitude_Aircraft", TransitAltitude_Aircraft.Value.ToString());
			}
			if (AttackAltitude_Aircraft.HasValue)
			{
				theWriter.WriteElementString("StationAltitude_Aircraft", AttackAltitude_Aircraft.Value.ToString());
			}
			theWriter.WriteElementString("TransitTerrainFollowing_Aircraft", TransitTerrainFollowing_Aircraft.ToString());
			theWriter.WriteElementString("AttackTerrainFollowing_Aircraft", AttackTerrainFollowing_Aircraft.ToString());
			theWriter.WriteElementString("FlightSize", ((int)base.FlightSize).ToString());
			XmlWriter obj = theWriter;
			int formation_Cruise = (int)Formation_Cruise;
			obj.WriteElementString("Formation_Cruise", formation_Cruise.ToString());
			XmlWriter obj2 = theWriter;
			formation_Cruise = (int)Formation_Attack;
			obj2.WriteElementString("Formation_Attack", formation_Cruise.ToString());
			XmlWriter obj3 = theWriter;
			formation_Cruise = (int)MinimumNumberOfAircraft;
			obj3.WriteElementString("MinAircraftReq", formation_Cruise.ToString());
			theWriter.WriteElementString("UseFlightSizeHardLimit", UseFlightSizeHardLimit.ToString());
			if (SecondaryAirBase != null)
			{
				theWriter.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				theWriter.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			XmlWriter obj4 = theWriter;
			byte tankerUsage = (byte)TankerUsage;
			obj4.WriteElementString("TankerUsage", tankerUsage.ToString());
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
			ex2?.Data.Add("Error at 100631", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static EscortMission FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, Mission existingObject = null)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Expected O, but got Unknown
		EscortMission result = default(EscortMission);
		try
		{
			bool flag;
			EscortMission escortMission;
			if (flag = existingObject != null)
			{
				escortMission = (EscortMission)existingObject;
				escortMission.Reinitialize();
			}
			else
			{
				Side theSide = null;
				escortMission = new EscortMission(ref theSide, ref theScen, "");
			}
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				switch (theNode2.Name)
				{
				case "TransitTerrainFollowing_Aircraft":
					escortMission.TransitTerrainFollowing_Aircraft = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Status":
					((Mission)escortMission).set_Status(theScen, (MissionStatus)Conversions.ToByte(theNode2.InnerText));
					break;
				case "UseFlightplan":
					escortMission.UseFlightplans = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Name":
					escortMission.Name = theNode2.InnerText;
					break;
				case "ETMID":
					escortMission.EscortTargetMissionID = theNode2.InnerText;
					break;
				case "SISIH":
					escortMission.ScrubIfSideIsHuman = Misc.ParseBool(theNode2.InnerText);
					break;
				case "LaunchMissionWithoutTankersInPlace":
					escortMission.LaunchMissionWithoutTankersInPlace = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TankerMaxDistance_Airborne":
					escortMission.TankerMaxDistance_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TankerMinNumber_Airborne":
					escortMission.TankerMinNumber_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TankerMinNumber_Total":
					escortMission.TankerMinNumber_Total = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "UseFlightplansOnly":
					escortMission.UsePreGeneratedFlightplansOnly = Misc.ParseBool(theNode2.InnerText);
					break;
				case "AttackTerrainFollowing_Aircraft":
					escortMission.AttackTerrainFollowing_Aircraft = Misc.ParseBool(theNode2.InnerText);
					break;
				case "EmptySlotsList":
					escortMission.EmptySlotsList = EmptyAircraftSlot.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "Doctrine":
					if (flag)
					{
						escortMission.Doctrine = Doctrine.FromXML(theScen, ref theNode2, escortMission, escortMission.Doctrine);
					}
					else
					{
						escortMission.Doctrine = Doctrine.FromXML(theScen, ref theNode2, escortMission);
					}
					break;
				case "TankerMinNumber_Station":
					escortMission.TankerMinNumber_Station = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "ID":
					if (!theDictionary.ContainsKey(theNode2.InnerText))
					{
						escortMission.ObjectID_Set(theNode2.InnerText);
						theDictionary.TryAdd(escortMission.ObjectID, escortMission);
						break;
					}
					result = (EscortMission)theDictionary[theNode2.InnerText];
					return result;
				case "TankerMissionList":
					if (flag)
					{
						escortMission.TankerMissions_IDs.Clear();
					}
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode val = childNode2;
						escortMission.TankerMissions_IDs.Add(val.InnerText);
					}
					break;
				case "FuelQtyToStartLookingForTanker_Airborne":
					escortMission.FuelQtyToStartLookingForTanker_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "UseFlightSizeHardLimit":
					escortMission.UseFlightSizeHardLimit = Misc.ParseBool(theNode2.InnerText);
					break;
				case "FlightSize":
					escortMission.FlightSize = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Category":
					escortMission.Category = (MissionCategory)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "AttackAltitude_Aircraft":
				case "AttackAltitude":
					escortMission.AttackAltitude_Aircraft = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "AttackThrottle":
				case "AttackThrottle_Aircraft":
					escortMission.AttackThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "Formation_Attack":
					escortMission.Formation_Attack = (_AircraftFormationType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "KeepOnMissionWithoutTankersInPlace":
					escortMission.KeepOnMissionWithoutTankersInPlace = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TankerFollowsReceivers":
					escortMission.TankerFollowsReceivers = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TankerUsage":
					escortMission.TankerUsage = (TankerMethod)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TransitAltitude":
				case "TransitAltitude_Aircraft":
					escortMission.TransitAltitude_Aircraft = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "MinAircraftReq":
					escortMission.MinimumNumberOfAircraft = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TransitThrottle":
				case "TransitThrottle_Aircraft":
					escortMission.TransitThrottle = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "MaxReceiversInQueuePerTanker_Airborne":
					escortMission.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Formation_Cruise":
					escortMission.Formation_Cruise = (_AircraftFormationType)Conversions.ToInteger(theNode2.InnerText);
					break;
				}
			}
			result = escortMission;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100632", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void Printout(StringBuilder PrintoutStringBuilder)
	{
		throw new NotImplementedException();
	}

	public override Mission Clone(bool DeepCloneRPs)
	{
		EscortMission obj = (EscortMission)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static EscortMission()
	{
		Class72.smethod_20();
	}
}
