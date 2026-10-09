using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class CargoAmmunition : CargoContainerContent
{
	public int int_1;

	public int WeaponQuantity;

	public CargoAmmunition()
	{
		ContentType = CargoContainerContentType.Ammunition;
	}

	public CargoAmmunition(CargoAmmunition CopyMe)
		: base(CopyMe)
	{
		int_1 = CopyMe.int_1;
		WeaponQuantity = CopyMe.WeaponQuantity;
	}

	public CargoAmmunition(int dbid, int quantity, Scenario scen)
	{
		ContentType = CargoContainerContentType.Ammunition;
		int_1 = dbid;
		WeaponQuantity = quantity;
		SQLiteConnection sqliteConnection_ = scen.DBConnection;
		CargoAmmunition CargoData = this;
		DBFunctions.GetWeaponCargoData(ref sqliteConnection_, dbid, ref CargoData);
	}

	public override bool TransferToUnit(ActiveUnit UnloadingUnit, ActiveUnit DestinationUnit, Cargo Cargo = null, float Quantity = 0f)
	{
		int magazineDBID = 1423;
		Magazine[] sharedMagazines = DestinationUnit.SharedMagazines;
		Magazine magazine = null;
		WeaponRec weaponRec = null;
		if (Quantity == 0f || Quantity > (float)WeaponQuantity)
		{
			Quantity = WeaponQuantity;
		}
		int num = (int)Math.Round(Quantity);
		int num2 = 0;
		int num3 = 0;
		Magazine[] array = sharedMagazines;
		foreach (Magazine magazine2 in array)
		{
			if (magazine2.ParentPlatform != DestinationUnit)
			{
				continue;
			}
			foreach (WeaponRec item in magazine2.Weapons.ToList())
			{
				if (item.int_3 == int_1)
				{
					num2 = item.MaxLoad - item.CurrentLoad;
					if (num2 >= num)
					{
						num3 = num;
						weaponRec = item;
						magazine = magazine2;
						break;
					}
					if (!DestinationUnit.IsFixedFacility && num2 > num3)
					{
						num3 = num2;
						weaponRec = item;
						magazine = magazine2;
					}
				}
			}
		}
		if (num3 > 0)
		{
			num = num3;
		}
		if (DestinationUnit.IsFixedFacility)
		{
			if (magazine == null)
			{
				magazine = DBFunctions.GetMagazine(magazineDBID, ref DestinationUnit.ParentScen, LoadComponents: false);
				((Platform)DestinationUnit).AddSharedMagazine(magazine);
			}
			if (weaponRec == null)
			{
				weaponRec = new WeaponRec(ref DestinationUnit.ParentScen, int_1, 0, 10000, magazine.ROF, 1, ExcludeOptionalWeapons: false, AircraftInternalWeapons: false);
				magazine.Weapons.Add(weaponRec);
			}
		}
		if (weaponRec == null)
		{
			return false;
		}
		weaponRec.CurrentLoad += num;
		WeaponQuantity -= num;
		return true;
	}

	public override bool TransferFromUnit(CargoContainer theContainer, ActiveUnit FromUnit, Cargo Cargo = null, float Quantity = 0f)
	{
		Magazine[] sharedMagazines = FromUnit.SharedMagazines;
		if (Quantity == 0f || Quantity > (float)WeaponQuantity)
		{
			Quantity = WeaponQuantity;
		}
		int num = (int)Math.Round(Quantity);
		Magazine[] array = sharedMagazines;
		foreach (Magazine magazine in array)
		{
			foreach (WeaponRec item in magazine.Weapons.ToList())
			{
				if (item.int_3 == int_1 && item.CurrentLoad > 0)
				{
					item.CurrentLoad -= num;
					if (item.CurrentLoad >= 0)
					{
						num = 0;
						break;
					}
					num = -1 * item.CurrentLoad;
					item.CurrentLoad = 0;
				}
			}
			if (num < 1)
			{
				break;
			}
		}
		if (num > 0)
		{
			WeaponQuantity -= num;
		}
		if (WeaponQuantity > 0)
		{
			return true;
		}
		return false;
	}

	public override void DestroyCargoObject(Side ComponentPlatformSide, bool ScenEditAction, bool IsFacilityAimpoint, bool DestroyUnitNow, string theReason, string WhatCausedIt = null, bool RegisterAsLosses = true)
	{
		if (WeaponQuantity > 0 && RegisterAsLosses)
		{
			ComponentPlatformSide.AAR.AddToWeaponsLost(int_1, WeaponQuantity);
		}
		WeaponQuantity = 0;
	}

	public override float GetRequiredCrewSpace()
	{
		return (float)WeaponQuantity * Crew;
	}

	public override float GetRequiredArea()
	{
		if (IsStackable() && Parent != null && Parent.CanStackCargo())
		{
			return GetRequiredAreaStacked(Parent, WeaponQuantity);
		}
		return (float)WeaponQuantity * Area;
	}

	public override float GetRequiredAreaStacked(ICargoHost Host, int TotalQuantity)
	{
		int num = (int)Math.Floor(Host.GetCargo_Height() / Height);
		if (num < 2)
		{
			return Area * (float)TotalQuantity;
		}
		if (TotalQuantity <= num)
		{
			return Area;
		}
		return (float)(int)Math.Ceiling((double)TotalQuantity / (double)num) * Area;
	}

	public override float GetRequiredMass()
	{
		return (float)WeaponQuantity * Mass;
	}

	public override string GetCargoName()
	{
		string text = WeaponQuantity + "x " + Name;
		if (WeaponQuantity > 1 && IsStackable() && Parent != null && Parent.CanStackCargo() && Parent.GetCargo_Height() >= 2f * GetRequiredHeight())
		{
			text += " (Stacked)";
		}
		return text;
	}

	public override int imethod_0()
	{
		return int_1;
	}

	public override string GetCargoObjectLossString()
	{
		return "Weapon_" + int_1;
	}

	public override bool IsStackable()
	{
		return Height > 0f;
	}

	public override float GetRequiredHeight()
	{
		return Height;
	}

	public override int GetCargoQuantity()
	{
		return WeaponQuantity;
	}

	public override bool isMatch(Cargo c)
	{
		if (c.CargoObjectContainerContents != null && c.CargoObjectContainerContents.ContentType == CargoContainerContentType.Ammunition && ((CargoAmmunition)c.CargoObjectContainerContents).int_1 == int_1)
		{
			return true;
		}
		return false;
	}

	public override bool isMatch(CargoContainerContent c)
	{
		if (c.ContentType == CargoContainerContentType.Ammunition && ((CargoAmmunition)c).int_1 == int_1)
		{
			return true;
		}
		return false;
	}

	public override bool isExactMatch(CargoContainerContent c)
	{
		if (c.ContentType == CargoContainerContentType.Ammunition)
		{
			CargoAmmunition cargoAmmunition = (CargoAmmunition)c;
			if (cargoAmmunition.int_1 == int_1 && cargoAmmunition.WeaponQuantity == WeaponQuantity)
			{
				return true;
			}
		}
		return false;
	}

	public override float GetQuantityDifference(CargoContainerContent c)
	{
		if (isMatch(c))
		{
			return WeaponQuantity - ((CargoAmmunition)c).WeaponQuantity;
		}
		return 0f;
	}

	public override void SetQuantity(float theQuantity)
	{
		WeaponQuantity = (int)Math.Round(theQuantity);
	}

	internal string SubclassToXML(HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		return "<WDBID>" + int_1 + "</WDBID><WNUM>" + WeaponQuantity + "</WNUM>";
	}

	public void SubclassFromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		foreach (XmlNode childNode in theNode.ChildNodes)
		{
			XmlNode val = childNode;
			try
			{
				string name = val.Name;
				if (Operators.CompareString(name, "WDBID", false) == 0)
				{
					int_1 = Conversions.ToInteger(val.InnerText);
				}
				else if (Operators.CompareString(name, "WNUM", false) == 0)
				{
					WeaponQuantity = Conversions.ToInteger(val.InnerText);
				}
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

	static CargoAmmunition()
	{
		Class72.smethod_20();
	}
}
