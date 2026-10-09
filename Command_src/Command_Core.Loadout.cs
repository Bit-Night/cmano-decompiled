using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using Cysharp.Text;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Loadout : ScenarioObject
{
	public delegate void LoadoutWeaponRecordAddedEventHandler(string LoadoutObjectID, string WeaponRecObjectID);

	public delegate void LoadoutWeaponRecordRemovedEventHandler(string LoadoutObjectID, string WeaponRecObjectID);

	public enum LoadoutRole
	{
		None = 1001,
		Intercept_BVR = 2001,
		Intercept_WVR = 2002,
		AirSuperiority_BVR = 2003,
		AirSuperiority_WVR = 2004,
		PointDefence_BVR = 2005,
		PointDefence_WVR = 2006,
		GunsOnly = 2007,
		AntiSatellite_Intercept = 2101,
		AirborneLaser = 2102,
		LandNaval_Strike = 3001,
		LandNaval_Standoff = 3002,
		LandNaval_SEAD_ARM = 3003,
		LandNaval_SEAD_TALD = 3004,
		LandNaval_DEAD = 3005,
		LandOnly_Strike = 3101,
		LandOnly_Standoff = 3102,
		LandOnly_SEAD_ARM = 3103,
		LandOnly_SEAD_TALD = 3104,
		LandOnly_DEAD = 3105,
		NavalOnly_Strike = 3201,
		NavalOnly_Standoff = 3202,
		NavalOnly_SEAD_ARM = 3203,
		NavalOnly_SEAD_TALD = 3204,
		NavalOnly_DEAD = 3205,
		BAI_CAS = 3401,
		Buddy_Illumination = 3501,
		OECM = 4001,
		AEW = 4002,
		CommandPost = 4003,
		ChaffLaying = 4004,
		SearchAndRescue = 4101,
		CombatSearchAndRescue = 4102,
		MineSweeping = 4201,
		MineRecon = 4202,
		NavalMineLaying = 4301,
		ASW_Patrol = 6001,
		ASW_Attack = 6002,
		Forward_Observer = 7001,
		Area_Surveillance = 7002,
		Armed_Recon = 7003,
		Unarmed_Recon = 7004,
		Maritime_Surveillance = 7005,
		Paratroopers = 7101,
		Troop_Transport = 7102,
		Cargo = 7201,
		AirRefueling = 8001,
		Training = 8101,
		TargetTow = 8102,
		TargetDrone = 8103,
		Ferry = 9001,
		Unavailable = 9002,
		Reserve = 9003,
		ArmedFerry = 9004,
		PackedForCargo = 9005
	}

	public enum _LoadoutWeather : short
	{
		None = 1001,
		AllWeather = 2001,
		LimitedAllWeather = 2002,
		ClearWeather = 2003
	}

	public enum _LoadoutDayNight : short
	{
		None = 1001,
		DayNight = 2001,
		NightOnly = 2002,
		DayOnly = 2003
	}

	private struct Struct13
	{
		public int int_0;

		public int Quantity;
	}

	public int DBID;

	public string Comments;

	public int ROF;

	public int MaxCapacity;

	public int ReadyTime;

	public int ReadyTime_Sustained;

	public WeaponRec[] Weapons;

	public LoadoutRole Role;

	public _LoadoutDayNight TimeOfDay;

	public _LoadoutWeather Weather;

	public float WeightDragModifier;

	public int CombatRadius;

	public short TimeOnStation_Minutes;

	public int PayloadWeight;

	public int PayloadWeightDroppable;

	public int PayloadWeight_TakeOff;

	public int PayloadWeightDroppable_TakeOff;

	public bool NoOptionalWeapons;

	private AircraftMissionProfile aircraftMissionProfile_0;

	public bool RequiresBuddyIllumination;

	public bool QuickTurnaround;

	public int QuickTurnaround_ReadyTime;

	public int QuickTurnaround_MaxSorties;

	public int QuickTurnaround_AdditionalTimePenalty;

	public int QuickTurnaround_AirborneTime;

	public _LoadoutDayNight QuickTurnaround_TimeofDay;

	public Doctrine._WeaponState WinchesterShotgun;

	public bool Hypothetical;

	public int Cargo_Crew;

	public float Cargo_Area;

	public CargoType Cargo_Type;

	public float Cargo_Mass;

	public bool Cargo_ParadropCapable;

	[CompilerGenerated]
	private static LoadoutWeaponRecordAddedEventHandler loadoutWeaponRecordAddedEventHandler_0;

	[CompilerGenerated]
	private static LoadoutWeaponRecordRemovedEventHandler loadoutWeaponRecordRemovedEventHandler_0;

	public bool IsAAW
	{
		get
		{
			LoadoutRole role = Role;
			int result;
			if ((uint)(role - 2001) <= 5u)
			{
				result = 1;
			}
			else
			{
				if (role != LoadoutRole.AntiSatellite_Intercept)
				{
					return false;
				}
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	public bool IsASW
	{
		get
		{
			LoadoutRole role = Role;
			if ((uint)(role - 6001) <= 1u)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsSEAD
	{
		get
		{
			LoadoutRole role = Role;
			int result;
			if ((uint)(role - 3003) <= 2u)
			{
				result = 1;
			}
			else if ((uint)(role - 3103) <= 2u)
			{
				result = 1;
			}
			else
			{
				if ((uint)(role - 3203) > 2u)
				{
					return false;
				}
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	public bool IsCargo => IsCargoLoadoutRole((int)Role);

	public bool IsSupportOrPatrol
	{
		get
		{
			LoadoutRole role = Role;
			int result;
			int result2;
			if (role <= LoadoutRole.NavalMineLaying)
			{
				if ((uint)(role - 4001) > 2u)
				{
					if (role != LoadoutRole.SearchAndRescue && role != LoadoutRole.NavalMineLaying)
					{
						result = 0;
						goto IL_0050;
					}
					goto IL_0053;
				}
				result2 = 1;
			}
			else if ((uint)(role - 7001) <= 1u)
			{
				result2 = 1;
			}
			else
			{
				if (role == LoadoutRole.Unarmed_Recon)
				{
					goto IL_0053;
				}
				if (role != LoadoutRole.AirRefueling)
				{
					result = 0;
					goto IL_0050;
				}
				result2 = 1;
			}
			goto IL_0054;
			IL_0053:
			result2 = 1;
			goto IL_0054;
			IL_0054:
			return (byte)result2 != 0;
			IL_0050:
			return (byte)result != 0;
		}
	}

	public bool IsSurveillanceOrRecon
	{
		get
		{
			int result;
			switch (Role)
			{
			case LoadoutRole.Unarmed_Recon:
				result = 1;
				break;
			default:
				return false;
			case LoadoutRole.Forward_Observer:
			case LoadoutRole.Area_Surveillance:
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
	}

	public bool IsStrike
	{
		get
		{
			int result;
			switch (Role)
			{
			case LoadoutRole.LandNaval_Strike:
			case LoadoutRole.LandNaval_Standoff:
			case LoadoutRole.LandNaval_SEAD_ARM:
			case LoadoutRole.LandNaval_SEAD_TALD:
			case LoadoutRole.LandNaval_DEAD:
				result = 1;
				break;
			case LoadoutRole.NavalOnly_Strike:
			case LoadoutRole.NavalOnly_Standoff:
			case LoadoutRole.NavalOnly_SEAD_ARM:
			case LoadoutRole.NavalOnly_SEAD_TALD:
			case LoadoutRole.NavalOnly_DEAD:
				result = 1;
				break;
			case LoadoutRole.ASW_Attack:
				result = 1;
				break;
			default:
				return false;
			case LoadoutRole.LandOnly_Strike:
			case LoadoutRole.LandOnly_Standoff:
			case LoadoutRole.LandOnly_SEAD_ARM:
			case LoadoutRole.LandOnly_SEAD_TALD:
			case LoadoutRole.LandOnly_DEAD:
			case LoadoutRole.BAI_CAS:
			case LoadoutRole.NavalMineLaying:
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
	}

	public int CurrentCapacity
	{
		get
		{
			int result;
			try
			{
				WeaponRec[] weapons = Weapons;
				int num = default(int);
				foreach (WeaponRec weaponRec in weapons)
				{
					num += (int)Math.Round(Math.Round((double)weaponRec.CurrentLoad / (double)weaponRec.Multiple, 0));
				}
				result = num;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101010", "");
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

	public AircraftMissionProfile MissionProfile
	{
		get
		{
			if (Information.IsNothing((object)aircraftMissionProfile_0))
			{
				int dBID = DBID;
				SQLiteConnection theConn = theScen.DBConnection;
				aircraftMissionProfile_0 = DBFunctions.GetLoadoutMissionProfile(dBID, ref theConn, theScen);
			}
			return aircraftMissionProfile_0;
		}
	}

	public static event LoadoutWeaponRecordAddedEventHandler LoadoutWeaponRecordAdded
	{
		[CompilerGenerated]
		add
		{
			LoadoutWeaponRecordAddedEventHandler loadoutWeaponRecordAddedEventHandler = loadoutWeaponRecordAddedEventHandler_0;
			LoadoutWeaponRecordAddedEventHandler loadoutWeaponRecordAddedEventHandler2;
			do
			{
				loadoutWeaponRecordAddedEventHandler2 = loadoutWeaponRecordAddedEventHandler;
				LoadoutWeaponRecordAddedEventHandler value2 = (LoadoutWeaponRecordAddedEventHandler)Delegate.Combine(loadoutWeaponRecordAddedEventHandler2, value);
				loadoutWeaponRecordAddedEventHandler = Interlocked.CompareExchange(ref loadoutWeaponRecordAddedEventHandler_0, value2, loadoutWeaponRecordAddedEventHandler2);
			}
			while ((object)loadoutWeaponRecordAddedEventHandler != loadoutWeaponRecordAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LoadoutWeaponRecordAddedEventHandler loadoutWeaponRecordAddedEventHandler = loadoutWeaponRecordAddedEventHandler_0;
			LoadoutWeaponRecordAddedEventHandler loadoutWeaponRecordAddedEventHandler2;
			do
			{
				loadoutWeaponRecordAddedEventHandler2 = loadoutWeaponRecordAddedEventHandler;
				LoadoutWeaponRecordAddedEventHandler value2 = (LoadoutWeaponRecordAddedEventHandler)Delegate.Remove(loadoutWeaponRecordAddedEventHandler2, value);
				loadoutWeaponRecordAddedEventHandler = Interlocked.CompareExchange(ref loadoutWeaponRecordAddedEventHandler_0, value2, loadoutWeaponRecordAddedEventHandler2);
			}
			while ((object)loadoutWeaponRecordAddedEventHandler != loadoutWeaponRecordAddedEventHandler2);
		}
	}

	public static event LoadoutWeaponRecordRemovedEventHandler LoadoutWeaponRecordRemoved
	{
		[CompilerGenerated]
		add
		{
			LoadoutWeaponRecordRemovedEventHandler loadoutWeaponRecordRemovedEventHandler = loadoutWeaponRecordRemovedEventHandler_0;
			LoadoutWeaponRecordRemovedEventHandler loadoutWeaponRecordRemovedEventHandler2;
			do
			{
				loadoutWeaponRecordRemovedEventHandler2 = loadoutWeaponRecordRemovedEventHandler;
				LoadoutWeaponRecordRemovedEventHandler value2 = (LoadoutWeaponRecordRemovedEventHandler)Delegate.Combine(loadoutWeaponRecordRemovedEventHandler2, value);
				loadoutWeaponRecordRemovedEventHandler = Interlocked.CompareExchange(ref loadoutWeaponRecordRemovedEventHandler_0, value2, loadoutWeaponRecordRemovedEventHandler2);
			}
			while ((object)loadoutWeaponRecordRemovedEventHandler != loadoutWeaponRecordRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LoadoutWeaponRecordRemovedEventHandler loadoutWeaponRecordRemovedEventHandler = loadoutWeaponRecordRemovedEventHandler_0;
			LoadoutWeaponRecordRemovedEventHandler loadoutWeaponRecordRemovedEventHandler2;
			do
			{
				loadoutWeaponRecordRemovedEventHandler2 = loadoutWeaponRecordRemovedEventHandler;
				LoadoutWeaponRecordRemovedEventHandler value2 = (LoadoutWeaponRecordRemovedEventHandler)Delegate.Remove(loadoutWeaponRecordRemovedEventHandler2, value);
				loadoutWeaponRecordRemovedEventHandler = Interlocked.CompareExchange(ref loadoutWeaponRecordRemovedEventHandler_0, value2, loadoutWeaponRecordRemovedEventHandler2);
			}
			while ((object)loadoutWeaponRecordRemovedEventHandler != loadoutWeaponRecordRemovedEventHandler2);
		}
	}

	public float GetCargoMass()
	{
		if (Cargo_Crew > 0 && Cargo_Mass == 0f)
		{
			return (float)Math.Round((float)Cargo_Crew * Mount.PersonnelMass, 1);
		}
		return Cargo_Mass;
	}

	public float GetCargoArea()
	{
		if (Cargo_Crew > 0 && Cargo_Area == 0f)
		{
			return (float)Math.Round((float)Cargo_Crew * Mount.PersonnelArea, 2);
		}
		return Cargo_Area;
	}

	public string ToXML(ref HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		Utf16ValueStringBuilder utf16ValueStringBuilder = ZString.CreateStringBuilder();
		try
		{
			utf16ValueStringBuilder.Append("<Loadout>");
			utf16ValueStringBuilder.Append("<ID>");
			utf16ValueStringBuilder.Append(ObjectID);
			utf16ValueStringBuilder.Append("</ID>");
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					utf16ValueStringBuilder.Append("</Loadout>");
					return utf16ValueStringBuilder.ToString();
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
			utf16ValueStringBuilder.Append("<DBID>");
			utf16ValueStringBuilder.Append(DBID.ToString());
			utf16ValueStringBuilder.Append("</DBID>");
			if (!string.IsNullOrEmpty(Name))
			{
				utf16ValueStringBuilder.Append("<Name>");
				utf16ValueStringBuilder.Append(SecurityElement.Escape(Name));
				utf16ValueStringBuilder.Append("</Name>");
			}
			utf16ValueStringBuilder.Append("<ROF>");
			utf16ValueStringBuilder.Append(ROF);
			utf16ValueStringBuilder.Append("</ROF>");
			if (MaxCapacity != 0)
			{
				utf16ValueStringBuilder.Append("<MC>");
				utf16ValueStringBuilder.Append(MaxCapacity);
				utf16ValueStringBuilder.Append("</MC>");
			}
			if (ReadyTime != 0)
			{
				utf16ValueStringBuilder.Append("<RT>");
				utf16ValueStringBuilder.Append(ReadyTime);
				utf16ValueStringBuilder.Append("</RT>");
			}
			if (NoOptionalWeapons)
			{
				utf16ValueStringBuilder.Append("<NOW>True</NOW>");
			}
			utf16ValueStringBuilder.Append("<Weaps>");
			WeaponRec[] weapons = Weapons;
			foreach (WeaponRec weaponRec in weapons)
			{
				utf16ValueStringBuilder.Append(weaponRec.ToXML(ObjectsAlreadySerialized, theScen));
			}
			utf16ValueStringBuilder.Append("</Weaps>");
			utf16ValueStringBuilder.Append("<Role>");
			utf16ValueStringBuilder.Append((int)Role);
			utf16ValueStringBuilder.Append("</Role>");
			if (PayloadWeight != 0)
			{
				utf16ValueStringBuilder.Append("<PayloadWeight>");
				utf16ValueStringBuilder.Append(PayloadWeight);
				utf16ValueStringBuilder.Append("</PayloadWeight>");
			}
			if (PayloadWeightDroppable != 0)
			{
				utf16ValueStringBuilder.Append("<PayloadWeightDroppable>");
				utf16ValueStringBuilder.Append(PayloadWeightDroppable);
				utf16ValueStringBuilder.Append("</PayloadWeightDroppable>");
			}
			if (PayloadWeight_TakeOff != 0)
			{
				utf16ValueStringBuilder.Append("<PayloadWeight_TakeOff>");
				utf16ValueStringBuilder.Append(PayloadWeight_TakeOff);
				utf16ValueStringBuilder.Append("</PayloadWeight_TakeOff>");
			}
			if (PayloadWeightDroppable_TakeOff != 0)
			{
				utf16ValueStringBuilder.Append("<PayloadWeightDroppable_TakeOff>");
				utf16ValueStringBuilder.Append(PayloadWeightDroppable_TakeOff);
				utf16ValueStringBuilder.Append("</PayloadWeightDroppable_TakeOff>");
			}
			if (WeightDragModifier != 0f)
			{
				utf16ValueStringBuilder.Append("<WeightDragModifier>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(WeightDragModifier));
				utf16ValueStringBuilder.Append("</WeightDragModifier>");
			}
			if (CombatRadius != 0)
			{
				utf16ValueStringBuilder.Append("<CombatRadius>");
				utf16ValueStringBuilder.Append(CombatRadius);
				utf16ValueStringBuilder.Append("</CombatRadius>");
			}
			if (TimeOnStation_Minutes != 0)
			{
				utf16ValueStringBuilder.Append("<TimeOnStation_Minutes>");
				utf16ValueStringBuilder.Append(TimeOnStation_Minutes);
				utf16ValueStringBuilder.Append("</TimeOnStation_Minutes>");
			}
			if (QuickTurnaround)
			{
				utf16ValueStringBuilder.Append("<QT>True</QT>");
			}
			if (QuickTurnaround_ReadyTime != 0)
			{
				utf16ValueStringBuilder.Append("<QT_ReadyTime>");
				utf16ValueStringBuilder.Append(QuickTurnaround_ReadyTime);
				utf16ValueStringBuilder.Append("</QT_ReadyTime>");
			}
			if (QuickTurnaround_AirborneTime != 0)
			{
				utf16ValueStringBuilder.Append("<QT_AirborneTime>");
				utf16ValueStringBuilder.Append(QuickTurnaround_AirborneTime);
				utf16ValueStringBuilder.Append("</QT_AirborneTime>");
			}
			if (QuickTurnaround_MaxSorties != 0)
			{
				utf16ValueStringBuilder.Append("<QT_MaxSorties>");
				utf16ValueStringBuilder.Append(QuickTurnaround_MaxSorties);
				utf16ValueStringBuilder.Append("</QT_MaxSorties>");
			}
			if (QuickTurnaround_AdditionalTimePenalty != 0)
			{
				utf16ValueStringBuilder.Append("<QT_AdditionalTimePenalty>");
				utf16ValueStringBuilder.Append(QuickTurnaround_AdditionalTimePenalty);
				utf16ValueStringBuilder.Append("</QT_AdditionalTimePenalty>");
			}
			utf16ValueStringBuilder.Append("<QT_TimeofDay>");
			utf16ValueStringBuilder.Append((int)QuickTurnaround_TimeofDay);
			utf16ValueStringBuilder.Append("</QT_TimeofDay>");
			utf16ValueStringBuilder.Append("<WinchesterShotgun>");
			utf16ValueStringBuilder.Append((int)WinchesterShotgun);
			utf16ValueStringBuilder.Append("</WinchesterShotgun>");
			utf16ValueStringBuilder.Append("</Loadout>");
			string result = utf16ValueStringBuilder.ToString();
			utf16ValueStringBuilder.Dispose();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101007", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private Loadout()
	{
		Weapons = new WeaponRec[0];
		NoOptionalWeapons = false;
	}

	public static Loadout FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Aircraft theAC, ref Scenario theScen)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0690: Unknown result type (might be due to invalid IL or missing references)
		//IL_0697: Expected O, but got Unknown
		Loadout result;
		try
		{
			Loadout theLoadout = new Loadout();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "QuickTurnaround_ReadyTime":
				case "QT_ReadyTime":
					theLoadout.QuickTurnaround_ReadyTime = Conversions.ToInteger(val.InnerText);
					break;
				case "Name":
					theLoadout.Name = val.InnerText;
					break;
				case "PayloadWeight":
					theLoadout.PayloadWeight = Conversions.ToInteger(val.InnerText);
					break;
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						theLoadout.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(theLoadout.ObjectID, theLoadout);
						break;
					}
					result = (Loadout)theDictionary[val.InnerText];
					goto end_IL_0001;
				case "PayloadWeightDroppable":
					theLoadout.PayloadWeightDroppable = Conversions.ToInteger(val.InnerText);
					break;
				case "PayloadWeightDroppable_TakeOff":
					theLoadout.PayloadWeightDroppable_TakeOff = Conversions.ToInteger(val.InnerText);
					break;
				case "ROF":
					theLoadout.ROF = Conversions.ToInteger(val.InnerText);
					break;
				case "QuickTurnaround_AdditionalTimePenalty":
				case "QT_AdditionalTimePenalty":
					theLoadout.QuickTurnaround_AdditionalTimePenalty = Conversions.ToInteger(val.InnerText);
					break;
				case "CombatRadius":
					theLoadout.CombatRadius = Conversions.ToInteger(val.InnerText);
					break;
				case "PayloadWeight_TakeOff":
					theLoadout.PayloadWeight_TakeOff = Conversions.ToInteger(val.InnerText);
					break;
				case "DBID":
					theLoadout.DBID = Conversions.ToInteger(val.InnerText);
					break;
				case "QuickTurnaround_AirborneTime":
				case "QT_AirborneTime":
					theLoadout.QuickTurnaround_AirborneTime = Conversions.ToInteger(val.InnerText);
					break;
				case "QuickTurnaround_MaxSorties":
				case "QT_MaxSorties":
					theLoadout.QuickTurnaround_MaxSorties = Conversions.ToInteger(val.InnerText);
					break;
				case "RT":
				case "ReadyTime":
					theLoadout.ReadyTime = Conversions.ToInteger(val.InnerText);
					break;
				case "Role":
					if (Versioned.IsNumeric((object)val.InnerText))
					{
						theLoadout.Role = (LoadoutRole)Conversions.ToInteger(val.InnerText);
					}
					else
					{
						theLoadout.Role = (LoadoutRole)Enum.Parse(typeof(LoadoutRole), val.InnerText, ignoreCase: true);
					}
					break;
				case "WeightDragModifier":
					theLoadout.WeightDragModifier = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "WinchesterShotgun":
					theLoadout.WinchesterShotgun = (Doctrine._WeaponState)Conversions.ToInteger(val.InnerText);
					break;
				case "NOW":
					theLoadout.NoOptionalWeapons = Misc.ParseBool(val.InnerText);
					break;
				case "Weapons":
				case "Weaps":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode2;
						WeaponRec theRec = WeaponRec.FromXML(ref theNode2, ref theDictionary, ref theScen);
						theLoadout.AddWeaponRec(theRec);
					}
					break;
				case "QT":
				case "QuickTurnaround":
					theLoadout.QuickTurnaround = Misc.ParseBool(val.InnerText);
					break;
				case "QuickTurnaround_TimeofDay":
				case "QT_TimeofDay":
					if (!Versioned.IsNumeric((object)val.InnerText))
					{
						theLoadout.QuickTurnaround_TimeofDay = (_LoadoutDayNight)Enum.Parse(typeof(_LoadoutDayNight), val.InnerText, ignoreCase: true);
					}
					else
					{
						theLoadout.QuickTurnaround_TimeofDay = (_LoadoutDayNight)Conversions.ToShort(val.InnerText);
					}
					break;
				case "TimeOnStation_Minutes":
					theLoadout.TimeOnStation_Minutes = Conversions.ToShort(val.InnerText);
					break;
				case "Sensors":
				case "Sens":
				{
					if (!val.HasChildNodes)
					{
						break;
					}
					WeaponRec[] weapons = DBFunctions.GetLoadout(ref theScen, theLoadout.DBID, theLoadout.NoOptionalWeapons, GetPayloadWeight: false).Weapons;
					foreach (WeaponRec weaponRec in weapons)
					{
						if (weaponRec.get_ReferenceWeapon(theScen).Type == Weapon._WeaponType.SensorPod)
						{
							theLoadout.AddWeaponRec(weaponRec);
						}
					}
					break;
				}
				case "MC":
				case "MaxCapacity":
					theLoadout.MaxCapacity = Conversions.ToInteger(val.InnerText);
					break;
				}
			}
			if (theLoadout.PayloadWeight == 0)
			{
				DBFunctions.GetLoadoutPayloadWeight(ref theScen, ref theLoadout);
			}
			if (theLoadout.PayloadWeight > 0 && theLoadout.PayloadWeight_TakeOff == 0)
			{
				DBFunctions.GetLoadoutPayloadTakeOffWeight_Static(ref theScen, ref theLoadout);
			}
			if (theLoadout.WinchesterShotgun == Doctrine._WeaponState.LoadoutSetting)
			{
				theLoadout.WinchesterShotgun = Doctrine._WeaponState.Winchester;
			}
			Loadout loadout = DBFunctions.GetLoadout(ref theScen, theLoadout.DBID, ExcludeOptionalWeapons: false, GetPayloadWeight: false);
			theLoadout.Cargo_Type = loadout.Cargo_Type;
			theLoadout.Cargo_Area = loadout.Cargo_Area;
			theLoadout.Cargo_Crew = loadout.Cargo_Crew;
			theLoadout.Cargo_Mass = loadout.Cargo_Mass;
			theLoadout.Cargo_ParadropCapable = loadout.Cargo_ParadropCapable;
			result = theLoadout;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101008", "");
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

	internal PooledList<Sensor> Sensors(Scenario theScen)
	{
		PooledList<Sensor> pooledList = null;
		PooledList<Sensor> result;
		try
		{
			int num = Weapons.Length;
			if (num > 0)
			{
				int num2 = num - 1;
				for (int i = 0; i <= num2; i++)
				{
					WeaponRec weaponRec = Weapons[i];
					if (weaponRec.CurrentLoad <= 0)
					{
						continue;
					}
					if (weaponRec.WeaponType == (Weapon._WeaponType)0 || weaponRec.WeaponType == Weapon._WeaponType.None)
					{
						weaponRec.WeaponType = DBFunctions.GetWeaponType(weaponRec.int_3, theScen);
					}
					if (weaponRec.WeaponType != Weapon._WeaponType.SensorPod)
					{
						continue;
					}
					ObservableList<Sensor> observableList = weaponRec.get_ReferenceWeapon(theScen).WeaponSensors();
					foreach (Sensor item in observableList)
					{
						if (pooledList == null)
						{
							pooledList = new PooledList<Sensor>();
						}
						pooledList.Add(item);
					}
				}
				result = pooledList;
			}
			else
			{
				result = pooledList;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101009", "");
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

	public static bool IsCargoLoadoutRole(int theRole)
	{
		int result;
		switch (theRole)
		{
		case 7201:
			result = 1;
			break;
		default:
			return false;
		case 7101:
		case 7102:
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	public Loadout(int LoadoutID, string theName, int theROF, int theCapacity, int theReadyTime, int theReadyTime_Sustained, LoadoutRole theRole, _LoadoutDayNight theTOD, _LoadoutWeather theWeather, float theWeightDrag, int theCombatRadius, short theTimeOnStationMinutes, bool theReBuddyIllum, bool ExcludeOptionalWeapons, bool theQuickTurnaround, int theQuickTurnaround_ReadyTime, int theQuickTurnaround_MaxSorties, int theQuickTurnaround_AdditionalTimePenalty, int theQuickTurnaround_AirborneTime, _LoadoutDayNight theQuickTurnaround_TimeofDay, Doctrine._WeaponState theWinchesterShotgun)
	{
		Weapons = new WeaponRec[0];
		NoOptionalWeapons = false;
		DBID = LoadoutID;
		Name = theName;
		ROF = theROF;
		MaxCapacity = theCapacity;
		ReadyTime = theReadyTime;
		ReadyTime_Sustained = theReadyTime_Sustained;
		Weapons = new WeaponRec[0];
		Role = theRole;
		TimeOfDay = theTOD;
		Weather = theWeather;
		WeightDragModifier = theWeightDrag;
		CombatRadius = theCombatRadius;
		TimeOnStation_Minutes = theTimeOnStationMinutes;
		RequiresBuddyIllumination = theReBuddyIllum;
		NoOptionalWeapons = ExcludeOptionalWeapons;
		QuickTurnaround = theQuickTurnaround;
		QuickTurnaround_ReadyTime = theQuickTurnaround_ReadyTime;
		QuickTurnaround_MaxSorties = theQuickTurnaround_MaxSorties;
		QuickTurnaround_AdditionalTimePenalty = theQuickTurnaround_AdditionalTimePenalty;
		QuickTurnaround_AirborneTime = theQuickTurnaround_AirborneTime;
		QuickTurnaround_TimeofDay = theQuickTurnaround_TimeofDay;
		WinchesterShotgun = theWinchesterShotgun;
	}

	public void AddWeaponRec(WeaponRec theRec)
	{
		ArrayExtensions.Add(ref Weapons, theRec);
		loadoutWeaponRecordAddedEventHandler_0?.Invoke(ObjectID, theRec.ObjectID);
	}

	public void RemoveWeaponRec(WeaponRec therec)
	{
		ArrayExtensions.Remove(ref Weapons, therec);
		loadoutWeaponRecordRemovedEventHandler_0?.Invoke(ObjectID, therec.ObjectID);
	}

	public void ClearAllWeapons()
	{
		List<WeaponRec> list = Weapons.ToList();
		ArrayExtensions.Clear(ref Weapons);
		foreach (WeaponRec item in list)
		{
			loadoutWeaponRecordRemovedEventHandler_0?.Invoke(ObjectID, item.ObjectID);
		}
	}

	internal string GetRoleString()
	{
		string text = default(string);
		return Role switch
		{
			LoadoutRole.NavalMineLaying => "Naval Minelaying", 
			LoadoutRole.MineRecon => "Mine Recon", 
			LoadoutRole.MineSweeping => "Minesweeping", 
			LoadoutRole.Forward_Observer => "Forward Observer", 
			LoadoutRole.Area_Surveillance => "Area Surveillance", 
			LoadoutRole.Armed_Recon => "Armed Recon", 
			LoadoutRole.Unarmed_Recon => "Unarmed Recon", 
			LoadoutRole.Maritime_Surveillance => "Maritime Surveillance", 
			LoadoutRole.ASW_Attack => "ASW Attack", 
			LoadoutRole.ASW_Patrol => "ASW Patrol", 
			LoadoutRole.Cargo => "Cargo", 
			LoadoutRole.Troop_Transport => "Troop Transport", 
			LoadoutRole.Paratroopers => "Paratroopers", 
			LoadoutRole.Ferry => "Ferry", 
			LoadoutRole.Unavailable => "Unavailable", 
			LoadoutRole.Reserve => "Reserve", 
			LoadoutRole.ArmedFerry => "Armed Ferry", 
			LoadoutRole.PackedForCargo => "Packed for Cargo", 
			LoadoutRole.Training => "training", 
			LoadoutRole.TargetTow => "Target Tow", 
			LoadoutRole.TargetDrone => "Target Drone", 
			LoadoutRole.AirRefueling => "Air Refueling", 
			LoadoutRole.LandOnly_Strike => "Land Only Strike", 
			LoadoutRole.LandOnly_Standoff => "Land Only Standoff", 
			LoadoutRole.LandOnly_SEAD_ARM => "Land Only SEAD ARM", 
			LoadoutRole.LandOnly_SEAD_TALD => "Land Only SEAD TALD", 
			LoadoutRole.LandOnly_DEAD => "Land Only DEAD", 
			LoadoutRole.LandNaval_Strike => "Land/Naval Strike", 
			LoadoutRole.LandNaval_Standoff => "Land/Naval Standoff", 
			LoadoutRole.LandNaval_SEAD_ARM => "Land/Naval SEAD ARM", 
			LoadoutRole.LandNaval_SEAD_TALD => "Land/Naval SEAD TALD", 
			LoadoutRole.LandNaval_DEAD => "Land/Naval DEAD", 
			LoadoutRole.AirborneLaser => "Airborne Laser", 
			LoadoutRole.AntiSatellite_Intercept => "Anti-Satellite Intercept", 
			LoadoutRole.Intercept_BVR => "Intercept BVR", 
			LoadoutRole.Intercept_WVR => "Intercept WVR", 
			LoadoutRole.AirSuperiority_BVR => "Air Superiority BVR", 
			LoadoutRole.AirSuperiority_WVR => "Air Superiority WVR", 
			LoadoutRole.PointDefence_BVR => "Point Defence BVR", 
			LoadoutRole.PointDefence_WVR => "Point Defence WVR", 
			LoadoutRole.GunsOnly => "Guns Only", 
			LoadoutRole.None => "None", 
			LoadoutRole.Buddy_Illumination => "Buddy Illumination", 
			LoadoutRole.BAI_CAS => "BAI CAS", 
			LoadoutRole.NavalOnly_Strike => "Naval Only Strike", 
			LoadoutRole.NavalOnly_Standoff => "Naval Only Standoff", 
			LoadoutRole.NavalOnly_SEAD_ARM => "Naval Only SEAD ARM", 
			LoadoutRole.NavalOnly_SEAD_TALD => "Naval Only SEAD TALD", 
			LoadoutRole.NavalOnly_DEAD => "Naval Only DEAD", 
			LoadoutRole.CombatSearchAndRescue => "Combat, Search and Rescue", 
			LoadoutRole.SearchAndRescue => "Search and Rescue", 
			LoadoutRole.OECM => "OECM", 
			LoadoutRole.AEW => "AEW", 
			LoadoutRole.CommandPost => "Command Post", 
			LoadoutRole.ChaffLaying => "Chaff Laying", 
			_ => text, 
		};
	}

	private List<Struct13> method_0(WeaponRec[] weaponRec_0)
	{
		List<Struct13> list = new List<Struct13>();
		int num = weaponRec_0.Count() - 1;
		Struct13 @struct = default(Struct13);
		for (int i = 0; i <= num; i++)
		{
			if (weaponRec_0[i].CurrentLoad <= 0)
			{
				continue;
			}
			bool flag = false;
			int num2 = list.Count - 1;
			int j;
			for (j = 0; j <= num2; j++)
			{
				@struct = list[j];
				if (@struct.int_0 > weaponRec_0[i].int_3)
				{
					break;
				}
				if (@struct.int_0 == weaponRec_0[i].int_3)
				{
					flag = true;
					@struct.Quantity += weaponRec_0[i].CurrentLoad;
					list[j] = @struct;
					break;
				}
			}
			if (!flag)
			{
				@struct.int_0 = weaponRec_0[i].int_3;
				@struct.Quantity = weaponRec_0[i].CurrentLoad;
				list.Insert(j, @struct);
			}
		}
		return list;
	}

	internal bool HasIdenticalWeapons(Scenario theScenario, int otherLoadoutID, bool excludeOptionalWeapons)
	{
		Loadout theLoadout = new Loadout(otherLoadoutID, "tempLoadout", 1, 1, 1, 1, LoadoutRole.None, _LoadoutDayNight.DayOnly, _LoadoutWeather.None, 0f, 0, 0, theReBuddyIllum: false, excludeOptionalWeapons, theQuickTurnaround: false, 0, 0, 0, 0, _LoadoutDayNight.DayNight, Doctrine._WeaponState.LoadoutSetting);
		DBFunctions.GetLoadoutWeapons(ref theScenario, ref theLoadout, otherLoadoutID, excludeOptionalWeapons);
		if (Weapons.Count() == 0 && theLoadout.Weapons.Count() == 0)
		{
			return false;
		}
		List<Struct13> list = new List<Struct13>();
		List<Struct13> list2 = new List<Struct13>();
		list = method_0(Weapons);
		list2 = method_0(theLoadout.Weapons);
		if (list.Count != list2.Count)
		{
			return false;
		}
		int num = Weapons.Count() - 1;
		int num2 = 0;
		while (true)
		{
			if (num2 <= num)
			{
				if (list[num2].int_0 == list2[num2].int_0)
				{
					if (list[num2].Quantity != list2[num2].Quantity)
					{
						break;
					}
					num2++;
					continue;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	static Loadout()
	{
		Class72.smethod_20();
	}
}
