using System.Collections.Generic;
using System.Data.SQLite;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[DoNotObfuscateType]
[DoNotPruneType]
[DoNotPrune]
public sealed class CargoManifestItem
{
	public Cargo.CargoObjectType objectType;

	public int DBID;

	public int quantity;

	public string _Name;

	public string ObjectID;

	public string Name
	{
		get
		{
			if (objectType == Cargo.CargoObjectType.Mount)
			{
				return Conversions.ToString(quantity) + "x " + _Name;
			}
			return _Name;
		}
	}

	public string NameNoQuantity => _Name;

	public void GenerateName(Scenario parentScenario)
	{
		if (!string.IsNullOrEmpty(_Name))
		{
			return;
		}
		if (parentScenario != null)
		{
			if (!string.IsNullOrEmpty(ObjectID) && parentScenario.ActiveUnits.ContainsKey(ObjectID))
			{
				_Name = parentScenario.ActiveUnits[ObjectID].Name;
				return;
			}
			switch (objectType)
			{
			case Cargo.CargoObjectType.Mount:
				_Name = DBFunctions.GetMountName(DBID, ref parentScenario);
				break;
			case Cargo.CargoObjectType.Vehicle:
			{
				int dBID4 = DBID;
				SQLiteConnection theConn = parentScenario.DBConnection;
				_Name = DBFunctions.GetVehicleName(dBID4, ref theConn);
				break;
			}
			case Cargo.CargoObjectType.Facility:
			{
				int dBID3 = DBID;
				SQLiteConnection theConn = parentScenario.DBConnection;
				_Name = DBFunctions.GetFacilityName(dBID3, ref theConn);
				break;
			}
			case Cargo.CargoObjectType.CargoContainer:
			{
				int dBID2 = DBID;
				SQLiteConnection theConn = parentScenario.DBConnection;
				_Name = DBFunctions.GetCargoContainerName(dBID2, ref theConn);
				break;
			}
			case Cargo.CargoObjectType.Aircraft:
			{
				int dBID = DBID;
				SQLiteConnection theConn = parentScenario.DBConnection;
				_Name = DBFunctions.GetAircraftName(dBID, ref theConn);
				break;
			}
			case Cargo.CargoObjectType.CargoContainerContent:
				break;
			}
		}
		else
		{
			_Name = "(unknown)";
		}
	}

	public CargoManifestItem(Cargo c)
	{
		objectType = c.CurrentType;
		DBID = c.CargoObjectDBID;
		quantity = 1;
		_Name = c.CargoObjectName;
		if (objectType != Cargo.CargoObjectType.Mount)
		{
			ObjectID = c.CargoObjectID;
		}
	}

	public CargoManifestItem(Cargo.CargoObjectType theType, int theDBID, string theObjectID = "")
	{
		objectType = theType;
		DBID = theDBID;
		quantity = 1;
		ObjectID = theObjectID;
	}

	public CargoManifestItem(CargoManifestItem CloneThis)
	{
		objectType = CloneThis.objectType;
		DBID = CloneThis.DBID;
		quantity = CloneThis.quantity;
		_Name = CloneThis._Name;
		ObjectID = CloneThis.ObjectID;
	}

	public static void Add(Cargo c, List<CargoManifestItem> manifest, bool GroupActiveUnits = false)
	{
		if (c == null || manifest == null)
		{
			return;
		}
		CargoManifestItem item;
		if (!GroupActiveUnits && c.InternalObjectType != Cargo.CargoObjectType.Mount)
		{
			item = new CargoManifestItem(c);
			manifest.Add(item);
			return;
		}
		item = FindMatch(c, manifest);
		if (item != null)
		{
			item.quantity++;
			return;
		}
		item = new CargoManifestItem(c);
		if (GroupActiveUnits && c.CargoObjectActiveUnit != null)
		{
			item._Name = c.CargoObjectActiveUnit.UnitClass;
			item.ObjectID = null;
		}
		manifest.Add(item);
	}

	public static void Add(CargoManifestItem item, List<CargoManifestItem> manifest)
	{
		if (item == null || manifest == null)
		{
			return;
		}
		if (item.objectType == Cargo.CargoObjectType.Mount)
		{
			CargoManifestItem cargoManifestItem = FindMatch(item, manifest);
			if (cargoManifestItem != null)
			{
				cargoManifestItem.quantity += item.quantity;
				return;
			}
			cargoManifestItem = new CargoManifestItem(item.objectType, item.DBID, item.ObjectID);
			cargoManifestItem.quantity = item.quantity;
			cargoManifestItem._Name = item._Name;
			manifest.Add(cargoManifestItem);
		}
		else
		{
			CargoManifestItem cargoManifestItem = new CargoManifestItem(item.objectType, item.DBID, item.ObjectID);
			cargoManifestItem._Name = item._Name;
			manifest.Add(cargoManifestItem);
		}
	}

	public static bool Remove(Cargo c, List<CargoManifestItem> manifest)
	{
		int result;
		if (c == null)
		{
			result = 0;
		}
		else if (manifest == null)
		{
			result = 0;
		}
		else
		{
			CargoManifestItem cargoManifestItem = FindMatch(c, manifest);
			if (cargoManifestItem != null)
			{
				cargoManifestItem.quantity--;
				int result2;
				if (cargoManifestItem.quantity >= 1)
				{
					result2 = 1;
				}
				else
				{
					manifest.Remove(cargoManifestItem);
					result2 = 1;
				}
				return (byte)result2 != 0;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool Remove(CargoManifestItem item, List<CargoManifestItem> manifest)
	{
		int result;
		if (item != null)
		{
			if (manifest == null)
			{
				result = 0;
			}
			else
			{
				CargoManifestItem cargoManifestItem = FindMatch(item, manifest);
				if (cargoManifestItem != null)
				{
					cargoManifestItem.quantity -= item.quantity;
					int result2;
					if (cargoManifestItem.quantity < 1)
					{
						manifest.Remove(cargoManifestItem);
						result2 = 1;
					}
					else
					{
						result2 = 1;
					}
					return (byte)result2 != 0;
				}
				result = 0;
			}
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public bool IsMatch(Cargo c)
	{
		if (c != null && c.CurrentType == objectType && c.CargoObjectDBID == DBID)
		{
			if (!string.IsNullOrEmpty(ObjectID) && !string.IsNullOrEmpty(c.CargoObjectID))
			{
				return Operators.CompareString(c.CargoObjectID, ObjectID, false) == 0;
			}
			return true;
		}
		return false;
	}

	public bool IsMatch(CargoManifestItem c)
	{
		if (c != null)
		{
			return c.objectType == objectType && c.DBID == DBID;
		}
		return false;
	}

	public static CargoManifestItem FindMatch(Cargo c, List<CargoManifestItem> manifest)
	{
		if (c != null && manifest != null)
		{
			foreach (CargoManifestItem item in manifest)
			{
				if (item.IsMatch(c))
				{
					return item;
				}
			}
		}
		return null;
	}

	public static CargoManifestItem FindMatch(CargoManifestItem item, List<CargoManifestItem> manifest)
	{
		if (item != null && manifest != null)
		{
			foreach (CargoManifestItem item2 in manifest)
			{
				if (item2.objectType == item.objectType && item2.DBID == item.DBID && (string.IsNullOrEmpty(item2.ObjectID) || string.IsNullOrEmpty(item.ObjectID) || Operators.CompareString(item2.ObjectID, item.ObjectID, false) == 0))
				{
					return item2;
				}
			}
		}
		return null;
	}

	static CargoManifestItem()
	{
		Class72.smethod_20();
	}
}
