using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscateType]
public sealed class LuaWrapper_Device_Weapon
{
	protected Scenario ScenarioContext;

	protected Weapon theWeapon;

	public object fields
	{
		get
		{
			Type obj = GetType();
			int num = 0;
			PropertyInfo[] properties = obj.GetProperties();
			MethodInfo[] methods = obj.GetMethods();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				if (propertyInfo.Name.StartsWith("__") || propertyInfo.Name.StartsWith("fields"))
				{
					continue;
				}
				string text = "";
				bool flag = false;
				if (propertyInfo.MemberType == MemberTypes.Method)
				{
					text = ":";
				}
				else if (propertyInfo.MemberType == MemberTypes.Property)
				{
					text = ".";
				}
				MethodInfo[] array2 = methods;
				foreach (MethodInfo obj2 in array2)
				{
					string text2 = "set_" + propertyInfo.Name;
					if (Operators.CompareString(obj2.Name, text2, false) == 0)
					{
						flag = true;
					}
				}
				num++;
				dictionary.Add("property_" + num, text + propertyInfo.Name + " , " + propertyInfo.PropertyType.Name + " , " + flag + " , " + propertyInfo.CanRead);
			}
			num = 0;
			MethodInfo[] array3 = methods;
			foreach (MethodInfo methodInfo in array3)
			{
				if (!methodInfo.Name.StartsWith("get_") && !methodInfo.Name.StartsWith("set_") && !methodInfo.Name.StartsWith("ToString") && !methodInfo.IsHideBySig)
				{
					string text3 = "";
					if (methodInfo.MemberType == MemberTypes.Method)
					{
						text3 = ":";
					}
					else if (methodInfo.MemberType == MemberTypes.Property)
					{
						text3 = ".";
					}
					num++;
					dictionary.Add("method_" + num, text3 + methodInfo.Name + " , " + methodInfo.ReturnType.ToString());
				}
			}
			if (dictionary.Count == 0)
			{
				return null;
			}
			LuaUtility.FromDict(dictionary, luaTable);
			return luaTable;
		}
	}

	[DoNotPrune]
	public object __obj => theWeapon;

	[DoNotPrune]
	public int dbid => theWeapon.DBID;

	[DoNotPrune]
	public string name => theWeapon.Name;

	[DoNotPrune]
	public int type => (int)theWeapon.UnitType;

	[DoNotPrune]
	public string guid => theWeapon.ObjectID;

	[DoNotPrune]
	public object validTargetList
	{
		get
		{
			new Dictionary<string, object>();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (theWeapon.ValidTargets_Description.Count == 0)
			{
				return null;
			}
			LuaUtility.FromList(theWeapon.ValidTargets_Description, luaTable);
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable OODA
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			luaTable["detection"] = theWeapon.OODA_Detection;
			luaTable["targeting"] = theWeapon.OODA_Targeting;
			luaTable["evasion"] = theWeapon.OODA_Evasion;
			return luaTable;
		}
	}

	[DoNotPrune]
	public string classname => theWeapon.UnitClass;

	[DoNotPrune]
	public string subtype
	{
		get
		{
			if ((int)theWeapon.UnitType <= 0)
			{
				return "None";
			}
			return theWeapon.SubTypeDescription.ToString();
		}
	}

	[DoNotPrune]
	public int subtypeN
	{
		get
		{
			if ((int)theWeapon.UnitType <= 0)
			{
				return 0;
			}
			return theWeapon.SubType;
		}
	}

	[DoNotPrune]
	public int guidance => (int)theWeapon.Guidance;

	[DoNotPrune]
	public bool usingBoostCoastModel => theWeapon.UsesBoostCoastModel.Value;

	[DoNotPrune]
	public string fuelType
	{
		get
		{
			if (theWeapon.Fuel_ReadOnly[0] == null)
			{
				return "";
			}
			return theWeapon.Fuel_ReadOnly[0].FuelType.ToString();
		}
	}

	[DoNotPrune]
	public int fuel
	{
		get
		{
			if (theWeapon.UsesBoostCoastModel.Value)
			{
				bool assumeAirLaunch = DBFunctions.CheckWeaponIsInAircraftLoadouts(ScenarioContext.DBConnection, theWeapon.DBID) || theWeapon.MinLaunchAlt_AGL > 0f || theWeapon.MinLaunchAlt_ASL > 0f;
				Weapon.RecalculateWeaponFlightEnergyIfNecessary(theWeapon, ScenarioContext, assumeAirLaunch, null);
				return theWeapon.TotalBurnTime;
			}
			return theWeapon.FuelCapacityMax;
		}
	}

	[DoNotPrune]
	public int? endurance
	{
		get
		{
			if (!theWeapon.UsesBoostCoastModel.Value)
			{
				return null;
			}
			bool assumeAirLaunch = DBFunctions.CheckWeaponIsInAircraftLoadouts(ScenarioContext.DBConnection, theWeapon.DBID) || theWeapon.MinLaunchAlt_AGL > 0f || theWeapon.MinLaunchAlt_ASL > 0f;
			Weapon.RecalculateWeaponFlightEnergyIfNecessary(theWeapon, ScenarioContext, assumeAirLaunch, null);
			return theWeapon.FlightEndurance;
		}
	}

	[DoNotPrune]
	public LuaTable ranges
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
			luaTable2["min"] = theWeapon.MinAirRange;
			luaTable2["max"] = theWeapon.MaxAirRange;
			luaTable["air"] = luaTable2;
			luaTable2 = LuaSandBox.Singleton().CreateTable();
			luaTable2["min"] = theWeapon.MinLandRange;
			luaTable2["max"] = theWeapon.MaxLandRange;
			luaTable["land"] = luaTable2;
			luaTable2 = LuaSandBox.Singleton().CreateTable();
			luaTable2["min"] = theWeapon.MinSubsurfaceRange;
			luaTable2["max"] = theWeapon.MaxSubsurfaceRange;
			luaTable["subsurface"] = luaTable2;
			luaTable2 = LuaSandBox.Singleton().CreateTable();
			luaTable2["min"] = theWeapon.MinSurfaceRange;
			luaTable2["max"] = theWeapon.MaxSurfaceRange;
			luaTable["surface"] = luaTable2;
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable launchLimits
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
			luaTable2["min"] = theWeapon.MinLaunchAlt_AGL;
			luaTable2["max"] = theWeapon.MaxLaunchAlt_AGL;
			luaTable["alt_agl"] = luaTable2;
			luaTable2 = LuaSandBox.Singleton().CreateTable();
			luaTable2["min"] = theWeapon.MinLaunchAlt_ASL;
			luaTable2["max"] = theWeapon.MaxLaunchAlt_ASL;
			luaTable["alt_asl"] = luaTable2;
			luaTable2 = LuaSandBox.Singleton().CreateTable();
			luaTable2["min"] = theWeapon.MinLaunchSpeed;
			luaTable2["max"] = theWeapon.MaxLaunchSpeed;
			luaTable["speed"] = luaTable2;
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable targetLimits
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
			luaTable2["min"] = theWeapon.MinTargetAlt_AGL;
			luaTable2["max"] = theWeapon.MaxTargetAlt_AGL;
			luaTable["alt_agl"] = luaTable2;
			luaTable2 = LuaSandBox.Singleton().CreateTable();
			luaTable2["min"] = theWeapon.MinTargetAlt_ASL;
			luaTable2["max"] = theWeapon.MaxTargetAlt_ASL;
			luaTable["alt_asl"] = luaTable2;
			luaTable2 = LuaSandBox.Singleton().CreateTable();
			luaTable2["min"] = theWeapon.MinTargetSpeed;
			luaTable2["max"] = theWeapon.MaxTargetSpeed;
			luaTable["speed"] = luaTable2;
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable warheads
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (theWeapon.Warheads.Count() != 0)
			{
				Warhead[] array = theWeapon.Warheads;
				foreach (Warhead warhead in array)
				{
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					luaTable2["dbid"] = warhead.DBID;
					luaTable2["dp"] = warhead.DP;
					luaTable2["name"] = warhead.Name;
					luaTable2["numof"] = warhead.NumberOfWarheads;
					luaTable2["type"] = (int)warhead.Type;
					luaTable[luaTable.Keys.Count + 1] = luaTable2;
				}
				return luaTable;
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable sensors
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (Sensor item in theWeapon.WeaponSensors())
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["dbid"] = item.DBID;
				luaTable2["name"] = item.Name;
				luaTable2["type"] = (short)item.Type;
				luaTable2["role"] = (long)item.Role;
				luaTable2["maxrange"] = item.maxRange;
				luaTable[luaTable.Keys.Count + 1] = luaTable2;
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable directors
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (theWeapon.Directors.Count > 0)
			{
				foreach (int director in theWeapon.Directors)
				{
					SQLiteConnection sqliteConnection_ = ScenarioContext.DBConnection;
					Sensor sensor = DBFunctions.GetSensor(director, ref sqliteConnection_);
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					luaTable2["dbid"] = sensor.DBID;
					luaTable2["name"] = sensor.Name;
					luaTable2["type"] = (short)sensor.Type;
					luaTable2["role"] = (long)sensor.Role;
					luaTable2["maxrange"] = sensor.maxRange;
					luaTable[luaTable.Keys.Count + 1] = luaTable2;
				}
			}
			return luaTable;
		}
	}

	public LuaWrapper_Device_Weapon(Weapon a, Scenario s)
	{
		ScenarioContext = s;
		theWeapon = a;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return (("weapon {\r\n name = '" + name + "', \r\n dbid = '" + dbid + "', \r\n type = '" + type + "', \r\n subtype = '" + subtype + "', \r\n") ?? "") + "}";
	}

	static LuaWrapper_Device_Weapon()
	{
		Class72.smethod_20();
	}
}
