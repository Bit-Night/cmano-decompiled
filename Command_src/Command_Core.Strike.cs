using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Collections.Pooled;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Strike : Mission
{
	public enum StrikeType
	{
		Air_Intercept,
		Land_Strike,
		Maritime_Strike,
		Sub_Strike
	}

	[CompilerGenerated]
	internal sealed class _Closure$__54-0
	{
		public string $VB$Local_targetId;

		public _Closure$__54-0(_Closure$__54-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_targetId = arg0.$VB$Local_targetId;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Module_Unit.Unit x)
		{
			return Operators.CompareString(x.ObjectID, $VB$Local_targetId, false) == 0;
		}

		static _Closure$__54-0()
		{
			Class72.smethod_20();
		}
	}

	public StrikeType Type;

	internal HashSet<Module_Unit.Unit> SpecificTargets;

	private List<string> list_0;

	private List<string> list_1;

	public bool UsePlanner;

	public Doctrine Doctrine_Escorts;

	public _FlightQty MinimumNumberOfAircraft;

	public _FlightQty MinimumNumberOfAircraft_Escorts_Shooter;

	public _FlightQty MinimumNumberOfAircraft_Escorts_NonShooter;

	public _FlightQty MaxFlightNumber_Strike;

	public _FlightQty MaximumNumberOfAircraft_Escorts_Shooter;

	public _FlightQty MaximumNumberOfAircraft_Escorts_NonShooter;

	public _AircraftFormationType Formation_Cruise;

	public _AircraftFormationType Formation_Attack;

	public _BingoFuelSetting BingoFuel;

	public _TargeteeringMethod TargeteeringMethod;

	public _FlightSize Escort_FlightSize_Shooter;

	public _FlightSize Escort_FlightSize_NonShooter;

	public _AircraftFormationType Escort_Formation_Cruise;

	public _AircraftFormationType Escort_Formation_Attack;

	public ActiveUnit.Throttle? Escort_TransitThrottle;

	public ActiveUnit.Throttle? Escort_AttackThrottle;

	public bool Escort_TransitTerrainFollowing;

	public bool Escort_AttackTerrainFollowing;

	public _GroupSize Escort_GroupSize;

	public float? Escort_TransitAltitude;

	public float? Escort_AttackAltitude;

	public int Escort_ResponseRadius;

	public int Escort_ResponseRadius_SEAD;

	public _FlightQty Escort_NumberOfFlights_Investigate;

	public _FlightQty Escort_NumberOfFlights_Engage;

	public int Escort_WingmanEngageDistance;

	public _GroupQty Escort_NumberOfBoats_Investigate;

	public _GroupQty Escort_NumberOfBoats_Engage;

	public int Escort_GroupMemberEngageDistance;

	public int MinResponseRadius_Aircraft;

	public int MaxResponseRadius_Aircraft;

	public int MinResponseRadius_Ship;

	public int MaxResponseRadius_Ship;

	public bool OneTimeOnly;

	public bool OneTimeOnlyFlown;

	public _RadarBehaviour RadarBehaviour;

	public bool RTB_When_Target_Destroyed;

	public bool UseFlightSizeHardLimit_Escort;

	public bool UseGroupSizeHardLimit_Escort;

	public _AttackMethod AttackMethod;

	public _SplitDistance SplitDistance;

	public Misc.PostureStance MinimumContactStanceToTrigger;

	internal bool WRASatisfied;

	public bool FocusEntirelyOnStrikeTargets
	{
		get
		{
			if (theAU != null)
			{
				return theAU.Doctrine.GetElementState(Doctrine.DoctrineItem_E.StrikeMemberFocus).Value switch
				{
					2 => true, 
					1 => SpecificTargets.Count > 0, 
					_ => false, 
				};
			}
			return false;
		}
	}

	public int TargetCount
	{
		get
		{
			if (SpecificTargets != null)
			{
				return SpecificTargets.Count;
			}
			SpecificTargets = new HashSet<Module_Unit.Unit>();
			return 0;
		}
	}

	public override string DescriptionString => Type switch
	{
		StrikeType.Air_Intercept => "Air Intercept", 
		StrikeType.Land_Strike => "Land Strike", 
		StrikeType.Maritime_Strike => "Maritime Strike", 
		StrikeType.Sub_Strike => "ASW Strike", 
		_ => throw new NotImplementedException(), 
	};

	public bool AddToSpecificTargets(Module_Unit.Unit u, bool automaticallyAquired = false)
	{
		if (automaticallyAquired)
		{
			if (!list_1.Contains(u.ObjectID))
			{
				list_1.Add(u.ObjectID);
			}
		}
		else if (list_1.Contains(u.ObjectID))
		{
			list_1.Remove(u.ObjectID);
		}
		return SpecificTargets.Add(u);
	}

	public bool RemoveFromSpecificTargets(Module_Unit.Unit u)
	{
		if (list_1.Contains(u.ObjectID))
		{
			list_1.Remove(u.ObjectID);
		}
		return SpecificTargets.Remove(u);
	}

	public void ClearSpecificTargets()
	{
		SpecificTargets.Clear();
		list_1.Clear();
	}

	public void ForceSpecificTargets(List<Module_Unit.Unit> l)
	{
		SpecificTargets = new HashSet<Module_Unit.Unit>(l);
		List<string> list = new List<string>();
		using (List<string>.Enumerator enumerator = list_1.GetEnumerator())
		{
			_Closure$__54-0 closure$__54- = default(_Closure$__54-0);
			while (enumerator.MoveNext())
			{
				closure$__54- = new _Closure$__54-0(closure$__54-);
				closure$__54-.$VB$Local_targetId = enumerator.Current;
				if (!SpecificTargets.Any(closure$__54-._Lambda$__0))
				{
					list.Add(closure$__54-.$VB$Local_targetId);
				}
			}
		}
		foreach (string item in list)
		{
			list_1.Remove(item);
		}
	}

	public bool SpecificTargetWasAutomaticallyAdded(Module_Unit.Unit u)
	{
		return list_1.Contains(u.ObjectID);
	}

	public override void ReleaseReferences()
	{
		try
		{
			base.ReleaseReferences();
			SpecificTargets = null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	internal override void Reinitialize()
	{
		base.Reinitialize();
		ClearSpecificTargets();
		list_0.Clear();
		UsePlanner = false;
		Escort_TransitThrottle = null;
		Escort_AttackThrottle = null;
		Escort_TransitAltitude = null;
		Escort_AttackAltitude = null;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("Strike");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Name", Name);
			theWriter.WriteElementString("Category", ((byte)Category).ToString());
			XmlWriter obj = theWriter;
			int type = (int)Type;
			obj.WriteElementString("Type", type.ToString());
			method_0(ref theWriter, ref ObjectsAlreadySerialized, ref theScen);
			Doctrine.ToXML(ref theWriter, ref theScen);
			Doctrine_Escorts.ToXML(ref theWriter, ref theScen, "Doctrine_Escorts");
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
			if (Deactivation_UnassignUnits)
			{
				theWriter.WriteElementString("Deactivation_UnassignUnits", Deactivation_UnassignUnits.ToString());
			}
			if (Deactivation_OrderRTB)
			{
				theWriter.WriteElementString("CheckBox_OrderRTB", Deactivation_OrderRTB.ToString());
			}
			if (Deactivation_DeleteMission)
			{
				theWriter.WriteElementString("CheckBox_DeleteMission", Deactivation_DeleteMission.ToString());
			}
			if (ScrubIfSideIsHuman)
			{
				theWriter.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			}
			if (UseFlightplans)
			{
				theWriter.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			}
			if (UsePreGeneratedFlightplansOnly)
			{
				theWriter.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			}
			if (IncludeInATO)
			{
				theWriter.WriteElementString("IncludeInATO", IncludeInATO.ToString());
			}
			if (SecondaryAirBase != null)
			{
				theWriter.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				theWriter.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			if (SpecificTargets.Count > 0)
			{
				theWriter.WriteStartElement("SpecificTargets");
				foreach (Module_Unit.Unit specificTarget in SpecificTargets)
				{
					if (!Information.IsNothing((object)specificTarget))
					{
						theWriter.WriteElementString("ID", specificTarget.ObjectID);
					}
				}
				theWriter.WriteEndElement();
			}
			if (list_1.Count > 0)
			{
				theWriter.WriteStartElement("STIDTHBAA");
				foreach (string item in list_1)
				{
					if (!Information.IsNothing((object)item))
					{
						theWriter.WriteElementString("ID", item);
					}
				}
				theWriter.WriteEndElement();
			}
			theWriter.WriteElementString("MCSTT", Conversions.ToString((byte)MinimumContactStanceToTrigger));
			if (base.get_Status(theScen) != MissionStatus.Active)
			{
				theWriter.WriteElementString("Status", ((byte)base.get_Status(theScen)).ToString());
			}
			if (UsePlanner)
			{
				theWriter.WriteElementString("UP", UsePlanner.ToString());
			}
			if ((int)base.FlightSize != 0)
			{
				theWriter.WriteElementString("FlightSize", ((int)base.FlightSize).ToString());
			}
			if ((int)GroupSize != 0)
			{
				theWriter.WriteElementString("GroupSize", ((int)GroupSize).ToString());
			}
			XmlWriter obj2 = theWriter;
			type = (int)Formation_Cruise;
			obj2.WriteElementString("Formation_Cruise", type.ToString());
			XmlWriter obj3 = theWriter;
			type = (int)Formation_Attack;
			obj3.WriteElementString("Formation_Attack", type.ToString());
			XmlWriter obj4 = theWriter;
			type = (int)BingoFuel;
			obj4.WriteElementString("Bingo", type.ToString());
			XmlWriter obj5 = theWriter;
			type = (int)TargeteeringMethod;
			obj5.WriteElementString("TargeteeringMethod", type.ToString());
			theWriter.WriteElementString("Escort_FlightSize_Shooter", ((int)Escort_FlightSize_Shooter).ToString());
			theWriter.WriteElementString("Escort_FlightSize_NonShooter", ((int)Escort_FlightSize_NonShooter).ToString());
			XmlWriter obj6 = theWriter;
			type = (int)Escort_Formation_Cruise;
			obj6.WriteElementString("Escort_Formation_Cruise", type.ToString());
			XmlWriter obj7 = theWriter;
			type = (int)Escort_Formation_Attack;
			obj7.WriteElementString("Escort_Formation_Attack", type.ToString());
			if (Escort_TransitThrottle.HasValue)
			{
				theWriter.WriteElementString("Escort_TransitThrottle", ((byte)Escort_TransitThrottle.Value).ToString());
			}
			if (Escort_AttackThrottle.HasValue)
			{
				theWriter.WriteElementString("Escort_StationThrottle", ((byte)Escort_AttackThrottle.Value).ToString());
			}
			if (Escort_TransitAltitude.HasValue)
			{
				theWriter.WriteElementString("Escort_TransitAltitude", Escort_TransitAltitude.Value.ToString());
			}
			if (Escort_AttackAltitude.HasValue)
			{
				theWriter.WriteElementString("Escort_StationAltitude", Escort_AttackAltitude.Value.ToString());
			}
			theWriter.WriteElementString("Escort_TransitTerrainFollowing", Escort_TransitTerrainFollowing.ToString());
			theWriter.WriteElementString("Escort_AttackTerrainFollowing", Escort_AttackTerrainFollowing.ToString());
			theWriter.WriteElementString("Escort_ResponseRadius", Escort_ResponseRadius.ToString());
			theWriter.WriteElementString("Escort_ResponseRadius_SEAD", Escort_ResponseRadius_SEAD.ToString());
			theWriter.WriteElementString("Escort_GroupSize", ((int)Escort_GroupSize).ToString());
			XmlWriter obj8 = theWriter;
			type = (int)MinimumNumberOfAircraft;
			obj8.WriteElementString("MinAircraftReq_Strikers", type.ToString());
			XmlWriter obj9 = theWriter;
			type = (int)MaxFlightNumber_Strike;
			obj9.WriteElementString("MaxFlightNumber_Strike", type.ToString());
			XmlWriter obj10 = theWriter;
			type = (int)MinimumNumberOfAircraft_Escorts_Shooter;
			obj10.WriteElementString("MinAircraftReq_Escorts_Shooter", type.ToString());
			XmlWriter obj11 = theWriter;
			type = (int)MaximumNumberOfAircraft_Escorts_Shooter;
			obj11.WriteElementString("MaxAircraftToFly_Escort_Shooter", type.ToString());
			XmlWriter obj12 = theWriter;
			type = (int)MinimumNumberOfAircraft_Escorts_NonShooter;
			obj12.WriteElementString("MinAircraftReq_Escorts_NonShooter", type.ToString());
			XmlWriter obj13 = theWriter;
			type = (int)MaximumNumberOfAircraft_Escorts_NonShooter;
			obj13.WriteElementString("MaxAircraftToFly_Escort_NonShooter", type.ToString());
			theWriter.WriteElementString("MinResponseRadius_Aircraft", MinResponseRadius_Aircraft.ToString());
			theWriter.WriteElementString("MaxResponseRadius_Aircraft", MaxResponseRadius_Aircraft.ToString());
			theWriter.WriteElementString("MinResponseRadius_Ship", MinResponseRadius_Ship.ToString());
			theWriter.WriteElementString("MaxResponseRadius_Ship", MaxResponseRadius_Ship.ToString());
			theWriter.WriteElementString("PrePlannedOnly", RTB_When_Target_Destroyed.ToString());
			theWriter.WriteElementString("OneTimeOnly", OneTimeOnly.ToString());
			theWriter.WriteElementString("OneTimeOnlyFlown", OneTimeOnlyFlown.ToString());
			XmlWriter obj14 = theWriter;
			type = (int)RadarBehaviour;
			obj14.WriteElementString("RadarBehaviour", type.ToString());
			XmlWriter obj15 = theWriter;
			type = (int)AttackMethod;
			obj15.WriteElementString("AttackMethod", type.ToString());
			XmlWriter obj16 = theWriter;
			type = (int)SplitDistance;
			obj16.WriteElementString("SplitDistance", type.ToString());
			theWriter.WriteElementString("UseFlightSizeHardLimit", UseFlightSizeHardLimit.ToString());
			theWriter.WriteElementString("UseFlightSizeHardLimit_Escort", UseFlightSizeHardLimit_Escort.ToString());
			theWriter.WriteElementString("UseGroupSizeHardLimit", UseGroupSizeHardLimit.ToString());
			theWriter.WriteElementString("UseGroupSizeHardLimit_Escort", UseGroupSizeHardLimit_Escort.ToString());
			XmlWriter obj17 = theWriter;
			byte tankerUsage = (byte)TankerUsage;
			obj17.WriteElementString("TankerUsage", tankerUsage.ToString());
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
			XmlWriter obj18 = theWriter;
			type = (int)Escort_NumberOfFlights_Investigate;
			obj18.WriteElementString("Escort_NumberOfFlights_Investigate", type.ToString());
			XmlWriter obj19 = theWriter;
			type = (int)Escort_NumberOfFlights_Engage;
			obj19.WriteElementString("Escort_NumberOfFlights_Engage", type.ToString());
			theWriter.WriteElementString("Escort_WingmanEngageDistance", Escort_WingmanEngageDistance.ToString());
			XmlWriter obj20 = theWriter;
			type = (int)Escort_NumberOfBoats_Investigate;
			obj20.WriteElementString("Escort_NumberOfBoats_Investigate", type.ToString());
			XmlWriter obj21 = theWriter;
			type = (int)Escort_NumberOfBoats_Engage;
			obj21.WriteElementString("Escort_NumberOfBoats_Engage", type.ToString());
			theWriter.WriteElementString("Escort_GroupMemberEngageDistance", Escort_GroupMemberEngageDistance.ToString());
			theWriter.WriteElementString("FlightPlanPreventShotgunRTB", FlightPlanPreventShotgunRTB.ToString());
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
			ex2?.Data.Add("Error at 100646", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Strike(Side theSide, Scenario theScen, string theName)
		: base(theSide, theScen, theName)
	{
		SpecificTargets = new HashSet<Module_Unit.Unit>();
		list_0 = new List<string>();
		list_1 = new List<string>();
		AttackMethod = _AttackMethod.Formation_SingleAim;
		SplitDistance = _SplitDistance.Typical_20nm;
		WRASatisfied = false;
		IsMission = true;
		MissionClass = _MissionClass.Strike;
	}

	public static Strike FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen, Mission existingObject = null)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_1347: Unknown result type (might be due to invalid IL or missing references)
		//IL_134e: Expected O, but got Unknown
		//IL_0c63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6a: Expected O, but got Unknown
		//IL_070b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0712: Expected O, but got Unknown
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Expected O, but got Unknown
		Strike result;
		try
		{
			bool flag;
			Strike strike;
			int num;
			if (!(flag = existingObject != null))
			{
				strike = new Strike(null, theScen, "");
				num = 0;
			}
			else
			{
				strike = (Strike)existingObject;
				strike.Reinitialize();
				num = 0;
			}
			bool flag2 = (byte)num != 0;
			bool? flag3 = default(bool?);
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				Mission.FromXMLCommon(strike, theNode2);
				switch (theNode2.Name)
				{
				case "OneTimeOnly":
					strike.OneTimeOnly = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Status":
					((Mission)strike).set_Status(theScen, (MissionStatus)Conversions.ToByte(theNode2.InnerText));
					break;
				case "RadarBehaviour":
					strike.RadarBehaviour = (_RadarBehaviour)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Name":
					strike.Name = theNode2.InnerText;
					break;
				case "START":
				{
					DateTime value3 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					strike._StartTime = value3;
					break;
				}
				case "SISIH":
					strike.ScrubIfSideIsHuman = Misc.ParseBool(theNode2.InnerText);
					break;
				case "UseFlightplan":
					strike.UseFlightplans = Misc.ParseBool(theNode2.InnerText);
					break;
				case "IncludeInATO":
					strike.IncludeInATO = Misc.ParseBool(theNode2.InnerText);
					flag2 = true;
					break;
				case "TankerMinNumber_Airborne":
					strike.TankerMinNumber_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Escort_TransitAltitude":
				case "TAO":
					strike.Escort_TransitAltitude = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "UseGroupSizeHardLimit":
					strike.UseGroupSizeHardLimit = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Escort_TransitTerrainFollowing":
					strike.Escort_TransitTerrainFollowing = Misc.ParseBool(theNode2.InnerText);
					break;
				case "STIDTHBAA":
					if (flag)
					{
						strike.list_1.Clear();
					}
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode val4 = childNode2;
						strike.list_1.Add(val4.InnerText);
					}
					break;
				case "Escort_NumberOfBoats_Investigate":
					strike.Escort_NumberOfBoats_Investigate = (_GroupQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TankerMaxDistance_Airborne":
					strike.TankerMaxDistance_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "UseFlightplansOnly":
					strike.UsePreGeneratedFlightplansOnly = Misc.ParseBool(theNode2.InnerText);
					break;
				case "LaunchMissionWithoutTankersInPlace":
					strike.LaunchMissionWithoutTankersInPlace = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TimeOnTarget":
				{
					DateTime value4 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					strike.TimeOnTarget = value4;
					break;
				}
				case "EmptySlotsList":
					strike.EmptySlotsList = EmptyAircraftSlot.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "TankerMinNumber_Total":
					strike.TankerMinNumber_Total = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "HomeNavalbase":
					strike._SecondaryNavalBaseID = theNode2.InnerText;
					break;
				case "Escort_GroupMemberEngageDistance":
					strike.Escort_GroupMemberEngageDistance = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MinResponseRadius_Ship":
					strike.MinResponseRadius_Ship = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "SpecificTargets":
					if (flag)
					{
						strike.ClearSpecificTargets();
						strike.list_0.Clear();
					}
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode val3 = childNode3;
						if (Operators.CompareString(val3.Name, "Contact", false) == 0)
						{
							Contact u = Contact.FromXML(val3.InnerText, ref theDictionary);
							strike.AddToSpecificTargets(u);
						}
						else
						{
							strike.list_0.Add(val3.InnerText);
						}
					}
					break;
				case "Doctrine_Escorts":
					if (flag)
					{
						strike.Doctrine_Escorts = Doctrine.FromXML(theScen, ref theNode2, strike, strike.Doctrine_Escorts);
					}
					else
					{
						strike.Doctrine_Escorts = Doctrine.FromXML(theScen, ref theNode2, strike);
					}
					break;
				case "Escort_GroupSize":
					strike.Escort_GroupSize = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TakeOffTime":
				{
					DateTime value2 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					strike.TakeOffTime = value2;
					break;
				}
				case "ID":
					if (!theDictionary.ContainsKey(theNode2.InnerText))
					{
						strike.ObjectID_Set(theNode2.InnerText);
						theDictionary.TryAdd(strike.ObjectID, strike);
						break;
					}
					result = (Strike)theDictionary[theNode2.InnerText];
					goto end_IL_0001;
				case "Doctrine":
					if (flag)
					{
						strike.Doctrine = Doctrine.FromXML(theScen, ref theNode2, strike, strike.Doctrine);
					}
					else
					{
						strike.Doctrine = Doctrine.FromXML(theScen, ref theNode2, strike);
					}
					break;
				case "UP":
					strike.UsePlanner = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Escort_TransitThrottle":
					strike.Escort_TransitThrottle = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "MaxResponseRadius_Ship":
					strike.MaxResponseRadius_Ship = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TankerMinNumber_Station":
					strike.TankerMinNumber_Station = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "OAO":
				case "Escort_StationAltitude":
					strike.Escort_AttackAltitude = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "Escort_ResponseRadius_SEAD":
					strike.Escort_ResponseRadius_SEAD = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "FlightList":
					strike.FlightList = Flight.FromXML(ref theNode2, ref theDictionary, theScen);
					break;
				case "PatrolThrottle":
				case "Escort_StationThrottle":
					strike.Escort_AttackThrottle = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
					break;
				case "FuelQtyToStartLookingForTanker_Airborne":
					strike.FuelQtyToStartLookingForTanker_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MCSTT":
				case "MinimumContactStanceToTrigger":
					strike.MinimumContactStanceToTrigger = (Misc.PostureStance)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TankerMissionList":
					if (flag)
					{
						strike.TankerMissions_IDs.Clear();
					}
					foreach (XmlNode childNode4 in theNode2.ChildNodes)
					{
						XmlNode val2 = childNode4;
						strike.TankerMissions_IDs.Add(val2.InnerText);
					}
					break;
				case "MaxFlightNumber_Strike":
				case "MaxAircraftToFly_Strikers":
					strike.MaxFlightNumber_Strike = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Escort_AttackTerrainFollowing":
					strike.Escort_AttackTerrainFollowing = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Escort_ResponseRadius":
					strike.Escort_ResponseRadius = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "FlightSize":
					strike.FlightSize = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Escort_FlightSize_NonShooter":
					strike.Escort_FlightSize_NonShooter = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "HomeAirbase":
					strike._SecondaryAirBaseID = theNode2.InnerText;
					break;
				case "UseFlightSizeHardLimit":
					strike.UseFlightSizeHardLimit = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Formation_Attack":
					strike.Formation_Attack = (_AircraftFormationType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Category":
					strike.Category = (MissionCategory)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "END":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					strike._EndTime = value;
					break;
				}
				case "PriorityWeight":
					strike.PriorityWeight = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MinAircraftReq_Escorts":
				case "MinAircraftReq_Escorts_Shooter":
					strike.MinimumNumberOfAircraft_Escorts_Shooter = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Escort_Formation_Cruise":
					strike.Escort_Formation_Cruise = (_AircraftFormationType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MaxAircraftToFly_Escort":
				case "MaxAircraftToFly_Escort_Shooter":
					strike.MaximumNumberOfAircraft_Escorts_Shooter = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "SplitDistance":
					strike.SplitDistance = (_SplitDistance)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "KeepOnMissionWithoutTankersInPlace":
					strike.KeepOnMissionWithoutTankersInPlace = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Escort_NumberOfFlights_Engage":
					strike.Escort_NumberOfFlights_Engage = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "_Phase":
					strike._Phase = (MissionPhase)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TargeteeringMethod":
					strike.TargeteeringMethod = (_TargeteeringMethod)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Escort_WingmanEngageDistance":
					strike.Escort_WingmanEngageDistance = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Escort_Formation_Attack":
					strike.Escort_Formation_Attack = (_AircraftFormationType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "PrePlannedOnly":
					strike.RTB_When_Target_Destroyed = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Escort_FlightSize_Shooter":
				case "Escort_FlightSize_Preferred":
					strike.Escort_FlightSize_Shooter = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Escort_NumberOfFlights_Investigate":
					strike.Escort_NumberOfFlights_Investigate = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MinAircraftReq_Escorts_NonShooter":
					strike.MinimumNumberOfAircraft_Escorts_NonShooter = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Type":
					if (Versioned.IsNumeric((object)theNode2.InnerText))
					{
						strike.Type = (StrikeType)Conversions.ToInteger(theNode2.InnerText);
					}
					else
					{
						strike.Type = (StrikeType)Enum.Parse(typeof(StrikeType), theNode2.InnerText, ignoreCase: true);
					}
					break;
				case "Escort_NumberOfBoats_Engage":
					strike.Escort_NumberOfBoats_Engage = (_GroupQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "AssignedUnitsList":
					foreach (XmlNode childNode5 in theNode2.ChildNodes)
					{
						XmlNode val = childNode5;
						strike.UnitsAssignedToMissionIDs.Add(val.InnerText);
					}
					break;
				case "OneTimeOnlyFlown":
					strike.OneTimeOnlyFlown = Misc.ParseBool(theNode2.InnerText);
					break;
				case "MinResponseRadius":
				case "MinResponseRadius_Aircraft":
					strike.MinResponseRadius_Aircraft = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TankerUsage":
					strike.TankerUsage = (TankerMethod)Conversions.ToByte(theNode2.InnerText);
					break;
				case "MinAircraftReq_Strikers":
					strike.MinimumNumberOfAircraft = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MaxResponseRadius_Aircraft":
				case "MaxResponseRadius":
					strike.MaxResponseRadius_Aircraft = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TankerFollowsReceivers":
					strike.TankerFollowsReceivers = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Bingo":
					strike.BingoFuel = (_BingoFuelSetting)Conversions.ToByte(theNode2.InnerText);
					break;
				case "Formation_Cruise":
					strike.Formation_Cruise = (_AircraftFormationType)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "UseGroupSizeHardLimit_Escort":
					strike.UseGroupSizeHardLimit_Escort = Misc.ParseBool(theNode2.InnerText);
					break;
				case "GroupSize":
					strike.GroupSize = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MaxAircraftToFly_Escort_NonShooter":
					strike.MaximumNumberOfAircraft_Escorts_NonShooter = (_FlightQty)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "FlightPlanPreventShotgunRTB":
					strike.FlightPlanPreventShotgunRTB = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Completion":
					strike.Completion = Conversions.ToSingle(theNode2.InnerText);
					break;
				case "UseFlightSizeHardLimit_Escort":
					strike.UseFlightSizeHardLimit_Escort = Misc.ParseBool(theNode2.InnerText);
					break;
				case "FocusEntirelyOnStrikeTargets":
					flag3 = Misc.ParseBool(theNode2.InnerText);
					break;
				case "AttackMethod":
					strike.AttackMethod = (_AttackMethod)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MaxReceiversInQueuePerTanker_Airborne":
					strike.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(theNode2.InnerText);
					break;
				}
			}
			if (strike.FlightSize == 0 && strike.Type == StrikeType.Sub_Strike)
			{
				strike.Doctrine.set_WeaponControlStatus_Submarine(theScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)Doctrine._WCS.Free);
			}
			if (strike.RadarBehaviour == _RadarBehaviour.None)
			{
				if (strike.TargetCount > 0 || strike.list_0.Count > 0)
				{
					strike.RTB_When_Target_Destroyed = true;
				}
				strike.OneTimeOnly = false;
				strike.OneTimeOnlyFlown = false;
			}
			if (strike.RadarBehaviour == _RadarBehaviour.None)
			{
				if (strike.Type == StrikeType.Maritime_Strike)
				{
					strike.RadarBehaviour = _RadarBehaviour.ActiveOnAttackIngressAndIP;
				}
				else
				{
					strike.RadarBehaviour = _RadarBehaviour.UseMissionEMCON;
				}
			}
			if (strike.Escort_FlightSize_Shooter == 0)
			{
				strike.Escort_FlightSize_Shooter = 2;
				strike.Escort_FlightSize_NonShooter = 1;
				strike.Doctrine_Escorts.WinchesterShotgunRTB = Doctrine._WeaponStateRTB.YesLastUnit;
				strike.Doctrine_Escorts.EMCON_Inherits = false;
				strike.Doctrine_Escorts.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Active, theScen);
			}
			byte? b = (byte?)strike.Escort_TransitThrottle;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
			{
				strike.Escort_TransitThrottle = ActiveUnit.Throttle.Cruise;
			}
			b = (byte?)strike.Escort_AttackThrottle;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
			{
				strike.Escort_AttackThrottle = ActiveUnit.Throttle.Full;
			}
			if (strike.Escort_ResponseRadius == 0)
			{
				strike.Escort_ResponseRadius = 80;
			}
			if (strike.Escort_ResponseRadius_SEAD == 0)
			{
				strike.Escort_ResponseRadius_SEAD = 30;
			}
			if (strike.Doctrine.ReplenishmentSelection_Inherits())
			{
				strike.Doctrine.set_ReplenishmentSelection(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UnderwayRefuelAndReplenishmentSelection?)Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
			}
			if (!flag2)
			{
				switch (strike.Type)
				{
				default:
					strike.IncludeInATO = true;
					break;
				case StrikeType.Sub_Strike:
					strike.IncludeInATO = false;
					break;
				case StrikeType.Air_Intercept:
					strike.IncludeInATO = false;
					break;
				}
			}
			if (strike.Escort_NumberOfFlights_Investigate == _FlightQty.NoPreferences)
			{
				strike.Escort_NumberOfFlights_Investigate = _FlightQty.Flight_x1;
				strike.Escort_NumberOfFlights_Engage = _FlightQty.All;
				strike.Escort_WingmanEngageDistance = 5;
				strike.Escort_NumberOfBoats_Investigate = _GroupQty.All;
				strike.Escort_NumberOfBoats_Engage = _GroupQty.All;
				strike.Escort_GroupMemberEngageDistance = 5;
			}
			if (flag3.HasValue && flag3.Value)
			{
				strike.Doctrine.SetElementState(Doctrine.DoctrineItem_E.StrikeMemberFocus, 1);
			}
			if (strike.Type != StrikeType.Air_Intercept && strike.list_0 != null && strike.list_0.Count > 0)
			{
				int? elementState = strike.Doctrine.GetElementState(Doctrine.DoctrineItem_E.StrikeMemberFocus);
				if ((elementState.HasValue ? new bool?(elementState.GetValueOrDefault() == 0) : ((bool?)null)) == true)
				{
					Doctrine.DoctrineItem element = strike.Doctrine.GetElement(Doctrine.DoctrineItem_E.StrikeMemberFocus);
					if (element != null && element.IsInheriting)
					{
						element.set_CurrentState(ConsiderInheritance: false, (int?)1);
					}
				}
			}
			result = strike;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100648", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Strike(null, theScen, "");
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Strike(Side theSide, Scenario theScen, string theName, MissionCategory theCategory, StrikeType theType)
		: base(theSide, theScen, theName)
	{
		SpecificTargets = new HashSet<Module_Unit.Unit>();
		list_0 = new List<string>();
		list_1 = new List<string>();
		AttackMethod = _AttackMethod.Formation_SingleAim;
		SplitDistance = _SplitDistance.Typical_20nm;
		WRASatisfied = false;
		IsMission = true;
		MissionClass = _MissionClass.Strike;
		List<ActiveUnit> DoctrineSelectedUnits = null;
		Doctrine_Escorts = new Doctrine(theScen, this, ref DoctrineSelectedUnits);
		Category = theCategory;
		Type = theType;
		Name = theName;
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
			Doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Passive, theScen);
			base.FlightSize = 4;
			IncludeInATO = true;
			break;
		case StrikeType.Sub_Strike:
			Doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Passive, theScen);
			Doctrine.set_BehaviorTowardsAmbigousTarget(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._BehaviorTowardsTargetAmbiguity?)Doctrine._BehaviorTowardsTargetAmbiguity.Optimistic);
			Doctrine.set_WeaponControlStatus_Submarine(theScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)value);
			base.FlightSize = 1;
			IncludeInATO = false;
			break;
		case StrikeType.Air_Intercept:
			Doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Active, theScen);
			base.FlightSize = 2;
			IncludeInATO = false;
			break;
		}
		GroupSize = 1;
		OneTimeOnly = false;
		OneTimeOnlyFlown = false;
		if (theType == StrikeType.Maritime_Strike)
		{
			RadarBehaviour = _RadarBehaviour.ActiveOnAttackIngressAndIP;
		}
		else
		{
			RadarBehaviour = _RadarBehaviour.UseMissionEMCON;
		}
		Escort_FlightSize_Shooter = 2;
		Escort_FlightSize_NonShooter = 1;
		Escort_TransitThrottle = ActiveUnit.Throttle.Cruise;
		Escort_AttackThrottle = ActiveUnit.Throttle.Full;
		Escort_TransitTerrainFollowing = false;
		Escort_AttackTerrainFollowing = false;
		Escort_ResponseRadius = 80;
		Escort_ResponseRadius_SEAD = 30;
		Doctrine.WinchesterShotgunRTB = Doctrine._WeaponStateRTB.YesLastUnit;
		Doctrine_Escorts.WinchesterShotgunRTB = Doctrine._WeaponStateRTB.YesLastUnit;
		Doctrine_Escorts.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Active, theScen);
		Doctrine.set_ReplenishmentSelection(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UnderwayRefuelAndReplenishmentSelection?)Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
		Doctrine_Escorts.set_ReplenishmentSelection(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UnderwayRefuelAndReplenishmentSelection?)Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
		if (Type == StrikeType.Air_Intercept)
		{
			Doctrine.set_ShootTourists(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseShootTourists?)Doctrine._UseShootTourists.Yes);
		}
		Escort_NumberOfFlights_Investigate = _FlightQty.Flight_x1;
		Escort_NumberOfFlights_Engage = _FlightQty.All;
		Escort_WingmanEngageDistance = 5;
		Escort_NumberOfBoats_Investigate = _GroupQty.All;
		Escort_NumberOfBoats_Engage = _GroupQty.All;
		Escort_GroupMemberEngageDistance = 5;
		MinimumContactStanceToTrigger = Misc.PostureStance.Unknown;
		TargeteeringMethod = _TargeteeringMethod.Mission;
	}

	public override void PostDeserializationHousekeeping(ref Scenario theScen, Side theSide, bool GameIsRunning, ref ConcurrentDictionary<string, ScenarioObject> ObjectsDictionary)
	{
		try
		{
			if (list_0.Count > 0)
			{
				PooledSet<string> pooledSet = new PooledSet<string>(list_0);
				foreach (ActiveUnit activeUnits_ in theScen.ActiveUnits_List)
				{
					if (activeUnits_ != null && pooledSet.Contains(activeUnits_.ObjectID))
					{
						AddToSpecificTargets(activeUnits_);
						if (base.IsActive && theSide.get_ConsidersThisSideToBe(activeUnits_.get_UnitSide(SetSideOnly: false), (Scenario)null) != Misc.PostureStance.Hostile)
						{
							theSide.set_ConsidersThisSideToBe(activeUnits_.get_UnitSide(SetSideOnly: false), (Scenario)null, Misc.PostureStance.Hostile);
						}
					}
				}
				foreach (Contact contacts_ in theSide.Contacts_List)
				{
					if (pooledSet.Contains(contacts_.ObjectID))
					{
						AddToSpecificTargets(contacts_);
						if (base.IsActive && contacts_.get_Stance(theSide) != Misc.PostureStance.Hostile)
						{
							contacts_.set_Stance(theSide, MarkManually: false, Misc.PostureStance.Hostile);
						}
					}
				}
				pooledSet.Dispose();
			}
			base.PostDeserializationHousekeeping(ref theScen, theSide, GameIsRunning, ref ObjectsDictionary);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100649", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void Printout(StringBuilder PrintoutStringBuilder)
	{
		throw new NotImplementedException();
	}

	public override Mission Clone(bool DeepCloneRPs)
	{
		Strike obj = (Strike)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Name = "[CLONE] " + Name;
		List<Module_Unit.Unit> collection = SpecificTargets.OrderBy([SpecialName] (Module_Unit.Unit theUnit) => theUnit.Name).ToList();
		obj.SpecificTargets = new HashSet<Module_Unit.Unit>(collection);
		obj.list_1 = new List<string>(list_1);
		return obj;
	}

	static Strike()
	{
		Class72.smethod_20();
	}
}
