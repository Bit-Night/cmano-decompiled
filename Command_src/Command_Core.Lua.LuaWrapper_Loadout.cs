using System;
using System.Collections.Generic;
using System.Reflection;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotObfuscateType]
[DoNotPrune]
[DoNotPruneType]
public sealed class LuaWrapper_Loadout
{
	protected Scenario ScenarioContext;

	protected Loadout LoadOut;

	public object fields
	{
		get
		{
			Type type = GetType();
			int num = 0;
			PropertyInfo[] properties = type.GetProperties();
			MethodInfo[] methods = type.GetMethods();
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
				foreach (MethodInfo obj in array2)
				{
					string text2 = "set_" + propertyInfo.Name;
					if (Operators.CompareString(obj.Name, text2, false) == 0)
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
	public object __obj => LoadOut;

	[DoNotPrune]
	public int dbid => LoadOut.DBID;

	[DoNotPrune]
	public string name => LoadOut.Name;

	[DoNotPrune]
	public LuaTable roles
	{
		get
		{
			if (LoadOut != null)
			{
				LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
				luaTable["role"] = (int)LoadOut.Role;
				luaTable["TOD"] = (short)LoadOut.TimeOfDay;
				luaTable["weather"] = (short)LoadOut.Weather;
				return luaTable;
			}
			return null;
		}
	}

	[DoNotPrune]
	public LuaTable weapons
	{
		get
		{
			if (LoadOut != null)
			{
				LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
				WeaponRec[] array = LoadOut.Weapons;
				foreach (WeaponRec weaponRec in array)
				{
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					luaTable2["wpn_guid"] = weaponRec.ObjectID;
					luaTable2["wpn_current"] = weaponRec.CurrentLoad;
					luaTable2["wpn_maxcap"] = weaponRec.MaxLoad;
					luaTable2["wpn_default"] = weaponRec.DefaultLoad;
					luaTable2["wpn_dbid"] = weaponRec.int_3;
					luaTable2["wpn_name"] = weaponRec.get_ReferenceWeapon(ScenarioContext).Name;
					luaTable2["wpn_type"] = (int)DBFunctions.GetWeaponType(weaponRec.int_3, ScenarioContext);
					luaTable[luaTable.Keys.Count + 1] = luaTable2;
				}
				return luaTable;
			}
			return null;
		}
	}

	[DoNotPrune]
	public object quickTurnaround
	{
		get
		{
			if (LoadOut == null)
			{
				return null;
			}
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			luaTable["state"] = LoadOut.QuickTurnaround;
			if (LoadOut.QuickTurnaround)
			{
				luaTable["readytime"] = LoadOut.QuickTurnaround_ReadyTime;
				luaTable["maxsorties"] = LoadOut.QuickTurnaround_MaxSorties;
				luaTable["extratime"] = LoadOut.QuickTurnaround_AdditionalTimePenalty;
				luaTable["airborne"] = LoadOut.QuickTurnaround_AirborneTime;
				luaTable["tod"] = (short)LoadOut.QuickTurnaround_TimeofDay;
			}
			return luaTable;
		}
		set
		{
			try
			{
				Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)value).GetEnumerator());
				foreach (string key in dictionary.Keys)
				{
					switch (key)
					{
					case "READYTIME":
						LoadOut.QuickTurnaround_ReadyTime = Conversions.ToInteger(dictionary[key]);
						break;
					case "AIRBORNE":
						LoadOut.QuickTurnaround_AirborneTime = Conversions.ToInteger(dictionary[key]);
						break;
					case "TOD":
					{
						if (Enum.TryParse<Loadout._LoadoutDayNight>(Conversions.ToString(dictionary["TOD"]), out var result))
						{
							LoadOut.QuickTurnaround_TimeofDay = result;
						}
						break;
					}
					case "EXTRATIME":
						LoadOut.QuickTurnaround_AdditionalTimePenalty = Conversions.ToInteger(dictionary[key]);
						break;
					case "MAXSORTIES":
						LoadOut.QuickTurnaround_MaxSorties = Conversions.ToInteger(dictionary[key]);
						break;
					case "STATE":
						LoadOut.QuickTurnaround = Conversions.ToBoolean(dictionary[key]);
						break;
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public object additionalData
	{
		get
		{
			if (LoadOut == null)
			{
				return null;
			}
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			luaTable["readytime"] = LoadOut.ReadyTime;
			luaTable["readytime_sustained"] = LoadOut.ReadyTime_Sustained;
			return luaTable;
		}
		set
		{
			try
			{
				Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)value).GetEnumerator());
				foreach (string key in dictionary.Keys)
				{
					if (Operators.CompareString(key, "READYTIME", false) != 0)
					{
						if (Operators.CompareString(key, "READYTIME_SUSTAINED", false) == 0)
						{
							LoadOut.ReadyTime_Sustained = Conversions.ToInteger(dictionary[key]);
						}
					}
					else
					{
						LoadOut.ReadyTime = Conversions.ToInteger(dictionary[key]);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public LuaWrapper_Loadout(Loadout a, Scenario s)
	{
		LoadOut = a;
		ScenarioContext = s;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return (("loadout {\r\n name = '" + name + "', \r\n dbid = '" + dbid + "', \r\n roles = '{" + LoadOut.Role.ToString() + "," + LoadOut.TimeOfDay.ToString() + "," + LoadOut.Weather.ToString() + "}\r\n weapons = '" + weapons.ToString() + "', \r\n") ?? "") + "}";
	}

	[DoNotPrune]
	public int setExactWeaponQuantity(string wpn_guid, int quantity)
	{
		int num = quantity;
		WeaponRec[] array = LoadOut.Weapons;
		int num2 = 0;
		WeaponRec weaponRec;
		while (true)
		{
			if (num2 < array.Length)
			{
				weaponRec = array[num2];
				if (Operators.CompareString(weaponRec.ObjectID, wpn_guid, false) == 0)
				{
					break;
				}
				num2 = checked(num2 + 1);
				continue;
			}
			return 0;
		}
		if (num < 0)
		{
			num = 0;
		}
		if ((double)num / (double)weaponRec.Multiple > (double)weaponRec.MaxLoad)
		{
			num = weaponRec.MaxLoad;
		}
		if (weaponRec.ParentMount != null)
		{
			weaponRec.CurrentLoad = 0;
			Mount parentMount = weaponRec.ParentMount;
			int theQty_FullyLoadedCells = 0;
			int theQty_PartiallyLoadedCells = 0;
			int num3 = parentMount.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells);
			if ((double)num / (double)weaponRec.Multiple > (double)(weaponRec.ParentMount.MaxCapacity - num3))
			{
				num = weaponRec.ParentMount.MaxCapacity - num3 * weaponRec.Multiple;
			}
		}
		if (num < 0)
		{
			num = 0;
		}
		weaponRec.CurrentLoad = num;
		return weaponRec.CurrentLoad;
	}

	static LuaWrapper_Loadout()
	{
		Class72.smethod_20();
	}
}
