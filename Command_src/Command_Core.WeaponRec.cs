using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using Command_Core.DAL;
using Cysharp.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class WeaponRec : ScenarioObject
{
	public delegate void CurrentLoadChangedEventHandler(string WeaponRecObjectID);

	public int? WRecDBID;

	public int DefaultLoad;

	private int int_1;

	public int MaxLoad;

	private int int_2;

	public int Multiple;

	private Weapon weapon_0;

	internal Weapon._WeaponType WeaponType;

	public bool OptionalWeapons;

	public bool InternalWeapons;

	public int int_3;

	public float TimeToFire;

	public Mount ParentMount;

	[CompilerGenerated]
	private static CurrentLoadChangedEventHandler currentLoadChangedEventHandler_0;

	private Weapon._WeaponType? nullable_0;

	public int CurrentLoad
	{
		get
		{
			return int_1;
		}
		set
		{
			bool num = value != int_1;
			int_1 = value;
			if (!num)
			{
				return;
			}
			try
			{
				currentLoadChangedEventHandler_0?.Invoke(ObjectID);
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
		}
	}

	public bool HasManualReloadPriority => theMount.ReloadPriority.Contains(int_3);

	public Weapon ReferenceWeapon
	{
		get
		{
			if (weapon_0 == null)
			{
				if (this.get_IsUnguidedWeapon(theScen))
				{
					weapon_0 = theScen.Cache_GetWeapon(int_3);
				}
				else
				{
					weapon_0 = Weapon.GetNewWeapon(ref theScen, int_3, bool_5: false);
				}
			}
			return weapon_0;
		}
	}

	public bool IsUnguidedWeapon
	{
		get
		{
			int num = int_3;
			SQLiteConnection sqliteConnection_ = theScen.DBConnection;
			Weapon._WeaponType weaponType = DBFunctions.GetWeaponType(num, ref sqliteConnection_);
			int result;
			int result2;
			if (weaponType > Weapon._WeaponType.DepthCharge)
			{
				if ((uint)(weaponType - 6001) <= 2u)
				{
					result = 1;
					goto IL_004e;
				}
				if ((uint)(weaponType - 9002) > 1u)
				{
					result2 = 0;
					goto IL_004a;
				}
			}
			else if ((uint)(weaponType - 2002) > 2u && weaponType != Weapon._WeaponType.DepthCharge)
			{
				result2 = 0;
				goto IL_004a;
			}
			result = 1;
			goto IL_004e;
			IL_004a:
			return (byte)result2 != 0;
			IL_004e:
			return (byte)result != 0;
		}
	}

	public float ReloadTime => int_2;

	public static event CurrentLoadChangedEventHandler CurrentLoadChanged
	{
		[CompilerGenerated]
		add
		{
			CurrentLoadChangedEventHandler currentLoadChangedEventHandler = currentLoadChangedEventHandler_0;
			CurrentLoadChangedEventHandler currentLoadChangedEventHandler2;
			do
			{
				currentLoadChangedEventHandler2 = currentLoadChangedEventHandler;
				CurrentLoadChangedEventHandler value2 = (CurrentLoadChangedEventHandler)Delegate.Combine(currentLoadChangedEventHandler2, value);
				currentLoadChangedEventHandler = Interlocked.CompareExchange(ref currentLoadChangedEventHandler_0, value2, currentLoadChangedEventHandler2);
			}
			while ((object)currentLoadChangedEventHandler != currentLoadChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CurrentLoadChangedEventHandler currentLoadChangedEventHandler = currentLoadChangedEventHandler_0;
			CurrentLoadChangedEventHandler currentLoadChangedEventHandler2;
			do
			{
				currentLoadChangedEventHandler2 = currentLoadChangedEventHandler;
				CurrentLoadChangedEventHandler value2 = (CurrentLoadChangedEventHandler)Delegate.Remove(currentLoadChangedEventHandler2, value);
				currentLoadChangedEventHandler = Interlocked.CompareExchange(ref currentLoadChangedEventHandler_0, value2, currentLoadChangedEventHandler2);
			}
			while ((object)currentLoadChangedEventHandler != currentLoadChangedEventHandler2);
		}
	}

	public override void ResetIDs()
	{
		base.ResetIDs();
		if (weapon_0 != null)
		{
			weapon_0.ResetIDs();
		}
	}

	internal Weapon._WeaponType StoreType(Scenario theScen)
	{
		if (!nullable_0.HasValue)
		{
			if (weapon_0 != null)
			{
				nullable_0 = weapon_0.Type;
				return nullable_0.Value;
			}
			Weapon._WeaponType weaponType = DBFunctions.GetWeaponType(int_3, theScen);
			nullable_0 = weaponType;
			return nullable_0.Value;
		}
		return nullable_0.Value;
	}

	public string ToXML(HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		Utf16ValueStringBuilder utf16ValueStringBuilder = ZString.CreateStringBuilder();
		try
		{
			utf16ValueStringBuilder.Append("<WRec>");
			utf16ValueStringBuilder.Append("<ID>");
			utf16ValueStringBuilder.Append(ObjectID);
			utf16ValueStringBuilder.Append("</ID>");
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					utf16ValueStringBuilder.Append("</WRec>");
					return utf16ValueStringBuilder.ToString();
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
			if (DefaultLoad != 0)
			{
				utf16ValueStringBuilder.Append("<DL>");
				utf16ValueStringBuilder.Append(DefaultLoad.ToString());
				utf16ValueStringBuilder.Append("</DL>");
			}
			if (CurrentLoad != 0)
			{
				utf16ValueStringBuilder.Append("<CL>");
				utf16ValueStringBuilder.Append(CurrentLoad.ToString());
				utf16ValueStringBuilder.Append("</CL>");
			}
			if (MaxLoad != 0)
			{
				utf16ValueStringBuilder.Append("<ML>");
				utf16ValueStringBuilder.Append(MaxLoad.ToString());
				utf16ValueStringBuilder.Append("</ML>");
			}
			if (int_2 != 0)
			{
				utf16ValueStringBuilder.Append("<ROF>");
				utf16ValueStringBuilder.Append(int_2.ToString());
				utf16ValueStringBuilder.Append("</ROF>");
			}
			if (OptionalWeapons)
			{
				utf16ValueStringBuilder.Append("<OW>");
				utf16ValueStringBuilder.Append("True");
				utf16ValueStringBuilder.Append("</OW>");
			}
			if (InternalWeapons)
			{
				utf16ValueStringBuilder.Append("<IW>");
				utf16ValueStringBuilder.Append("True");
				utf16ValueStringBuilder.Append("</IW>");
			}
			if (Multiple != 1)
			{
				utf16ValueStringBuilder.Append("<Mult>");
				utf16ValueStringBuilder.Append(Multiple.ToString());
				utf16ValueStringBuilder.Append("</Mult>");
			}
			utf16ValueStringBuilder.Append("<WeapID>");
			utf16ValueStringBuilder.Append(int_3.ToString());
			utf16ValueStringBuilder.Append("</WeapID>");
			if (TimeToFire != 0f)
			{
				utf16ValueStringBuilder.Append("<TTF>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(TimeToFire));
				utf16ValueStringBuilder.Append("</TTF>");
			}
			if (WRecDBID.HasValue)
			{
				utf16ValueStringBuilder.Append("<RecID>");
				utf16ValueStringBuilder.Append(WRecDBID.Value.ToString());
				utf16ValueStringBuilder.Append("</RecID>");
			}
			Weapon._WeaponType weaponType = StoreType(theScen);
			if (weaponType == Weapon._WeaponType.FerryTank || weaponType == Weapon._WeaponType.DropTank || weaponType == Weapon._WeaponType.SensorPod)
			{
				Weapon weapon = this.get_ReferenceWeapon(theScen);
				if (weapon.FuelCapacityMax > 0)
				{
					utf16ValueStringBuilder.Append("<FuelTank>");
					utf16ValueStringBuilder.Append(XmlConvert.ToString(weapon.Fuel_ReadOnly[0].CurrentQuantity));
					utf16ValueStringBuilder.Append("</FuelTank>");
				}
			}
			utf16ValueStringBuilder.Append("</WRec>");
			string result = utf16ValueStringBuilder.ToString();
			utf16ValueStringBuilder.Dispose();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1013249583745892137", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static WeaponRec FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		WeaponRec result;
		try
		{
			WeaponRec weaponRec = new WeaponRec();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "RecDBID":
					weaponRec.WRecDBID = Conversions.ToInteger(val.InnerText);
					break;
				case "IW":
					weaponRec.InternalWeapons = Misc.ParseBool(val.InnerText);
					break;
				case "ID":
					weaponRec.ObjectID_Set(val.InnerText);
					break;
				case "ML":
				case "MaxLoad":
					weaponRec.MaxLoad = Conversions.ToInteger(val.InnerText);
					break;
				case "ROF":
					weaponRec.int_2 = Conversions.ToInteger(val.InnerText);
					break;
				case "CurrentLoad":
				case "CL":
					weaponRec.int_1 = Conversions.ToInteger(val.InnerText);
					break;
				case "OW":
					weaponRec.OptionalWeapons = Misc.ParseBool(val.InnerText);
					break;
				case "TTF":
				case "TimeToFire":
					weaponRec.TimeToFire = XmlConvert.ToSingle(val.InnerText);
					break;
				case "FuelTank":
				{
					Weapon weapon = weaponRec.get_ReferenceWeapon(theScen);
					if (weapon.IsFuelTank || weapon.IsSensorPodWithFuelTank)
					{
						weapon.Fuel_ReadOnly[0].CurrentQuantity = XmlConvert.ToSingle(val.InnerText);
					}
					break;
				}
				case "DL":
				case "DefaultLoad":
					weaponRec.DefaultLoad = Conversions.ToInteger(val.InnerText);
					break;
				case "WeapID":
				case "WeaponDBID":
					weaponRec.int_3 = Conversions.ToInteger(val.InnerText);
					break;
				case "Mult":
				case "Multiple":
					weaponRec.Multiple = Conversions.ToInteger(val.InnerText);
					break;
				}
			}
			result = weaponRec;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101076", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new WeaponRec();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private WeaponRec()
	{
		Multiple = 1;
		OptionalWeapons = false;
		InternalWeapons = false;
	}

	public void DestroyWeaponRec()
	{
		weapon_0 = null;
	}

	public void ResetTimeToFire()
	{
		if (int_2 >= 0)
		{
			TimeToFire = int_2;
		}
		else
		{
			TimeToFire = 30 * -int_2;
		}
	}

	public WeaponRec(ref Scenario theScen, int theWeaponDBID, int theDefaultLoad, int theMaxLoad, int theROF, int theMultiple, bool ExcludeOptionalWeapons, bool AircraftInternalWeapons)
	{
		Multiple = 1;
		OptionalWeapons = false;
		InternalWeapons = false;
		DefaultLoad = theDefaultLoad;
		int_1 = DefaultLoad;
		MaxLoad = theMaxLoad;
		int_2 = theROF;
		Multiple = theMultiple;
		TimeToFire = 0f;
		int_3 = theWeaponDBID;
		OptionalWeapons = ExcludeOptionalWeapons;
		InternalWeapons = AircraftInternalWeapons;
	}

	static WeaponRec()
	{
		Class72.smethod_20();
	}
}
