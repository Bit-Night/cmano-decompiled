using System;
using System.Collections.Generic;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPrune]
[DoNotObfuscateType]
[DoNotPruneType]
public sealed class LuaWrapper_Device_Magazine
{
	internal Magazine mag;

	protected Scenario ScenarioContext;

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
	public object __obj => mag;

	[DoNotPrune]
	public string guid => mag.ObjectID;

	[DoNotPrune]
	public string parentunitguid
	{
		get
		{
			if (mag.ParentPlatform != null)
			{
				return mag.ParentPlatform.ObjectID;
			}
			return null;
		}
	}

	[DoNotPrune]
	public int dbid => mag.DBID;

	[DoNotPrune]
	public string name => mag.Name;

	[DoNotPrune]
	public int armor => (int)mag.Armor;

	[DoNotPrune]
	public int rof => mag.ROF;

	[DoNotPrune]
	public int capacity => mag.Capacity;

	[DoNotPrune]
	public bool isaviationmagazine => mag.IsAviationMag;

	[DoNotPrune]
	public LuaTable weapons
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (WeaponRec weapon in mag.Weapons)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["wpn_guid"] = weapon.ObjectID;
				luaTable2["wpn_current"] = weapon.CurrentLoad;
				luaTable2["wpn_maxcap"] = weapon.MaxLoad;
				luaTable2["wpn_default"] = weapon.DefaultLoad;
				luaTable2["wpn_dbid"] = weapon.int_3;
				luaTable2["wpn_name"] = weapon.get_ReferenceWeapon(ScenarioContext).Name;
				luaTable[luaTable.Keys.Count + 1] = luaTable2;
			}
			return luaTable;
		}
	}

	public LuaWrapper_Device_Magazine(Magazine m, Scenario s)
	{
		mag = m;
		ScenarioContext = s;
	}

	[DoNotPrune]
	public override string ToString()
	{
		string text = "magazine {\r\n name = '" + name + "', \r\n dbid = '" + dbid + "', \r\n guid = '" + guid.ToString() + "', \r\n armor = '" + armor + "', \r\n rof = '" + rof + "', \r\n capacity = '" + capacity + "', \r\n isaviationmagazine = '" + isaviationmagazine + "', \r\n";
		if (mag.Weapons != null)
		{
			text = text + " weapons = '" + mag.Weapons.Count + "', \r\n";
		}
		return text + "}";
	}

	[DoNotPrune]
	public int setExactWeaponQuantity(string wpn_guid, int quantity)
	{
		int num = quantity;
		foreach (WeaponRec weapon in mag.Weapons)
		{
			if (Operators.CompareString(weapon.ObjectID, wpn_guid, false) == 0)
			{
				if (num < 0)
				{
					num = 0;
				}
				if ((double)num / (double)weapon.Multiple > (double)weapon.MaxLoad)
				{
					num = weapon.MaxLoad;
				}
				weapon.CurrentLoad = 0;
				Magazine magazine = mag;
				int theQty_FullyLoadedCells = 0;
				int theQty_PartiallyLoadedCells = 0;
				int num2 = magazine.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells);
				if ((double)num / (double)weapon.Multiple > (double)(mag.Capacity - num2))
				{
					num = mag.Capacity - num2 * weapon.Multiple;
				}
				if (num < 0)
				{
					num = 0;
				}
				weapon.CurrentLoad = num;
				return weapon.CurrentLoad;
			}
		}
		return 0;
	}

	static LuaWrapper_Device_Magazine()
	{
		Class72.smethod_20();
	}
}
