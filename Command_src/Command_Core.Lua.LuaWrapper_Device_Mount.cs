using System;
using System.Collections.Generic;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscateType]
public sealed class LuaWrapper_Device_Mount
{
	protected Scenario ScenarioContext;

	protected Mount theMount;

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
			if (dictionary.Count != 0)
			{
				LuaUtility.FromDict(dictionary, luaTable);
				return luaTable;
			}
			return null;
		}
	}

	[DoNotPrune]
	public object __obj => theMount;

	[DoNotPrune]
	public int dbid => theMount.DBID;

	[DoNotPrune]
	public string name => theMount.Name;

	[DoNotPrune]
	public string guid => theMount.ObjectID;

	[DoNotPrune]
	public int armor => (int)theMount.ArmorRating;

	[DoNotPrune]
	public int rof => theMount.ROF;

	[DoNotPrune]
	public int capacity => theMount.MaxCapacity;

	[DoNotPrune]
	public LuaTable weapons
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (WeaponRec mountWeapon in theMount.MountWeapons)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["wpn_guid"] = mountWeapon.ObjectID;
				luaTable2["wpn_current"] = mountWeapon.CurrentLoad;
				luaTable2["wpn_maxcap"] = mountWeapon.MaxLoad;
				luaTable2["wpn_default"] = mountWeapon.DefaultLoad;
				luaTable2["wpn_dbid"] = mountWeapon.int_3;
				luaTable2["wpn_name"] = mountWeapon.get_ReferenceWeapon(ScenarioContext).Name;
				luaTable[luaTable.Keys.Count + 1] = luaTable2;
			}
			return luaTable;
		}
	}

	public LuaWrapper_Device_Mount(Mount a, Scenario s)
	{
		ScenarioContext = s;
		theMount = a;
	}

	[DoNotPrune]
	public override string ToString()
	{
		string text = "mount {\r\n name = '" + name + "', \r\n dbid = '" + dbid + "', \r\n";
		if (theMount.MountWeapons != null)
		{
			text = text + " weapons = '" + theMount.MountWeapons.Count + "', \r\n";
		}
		return text + "}";
	}

	[DoNotPrune]
	public int setExactWeaponQuantity(string wpn_guid, int quantity)
	{
		int num = quantity;
		foreach (WeaponRec mountWeapon in theMount.MountWeapons)
		{
			if (Operators.CompareString(mountWeapon.ObjectID, wpn_guid, false) == 0)
			{
				if (num < 0)
				{
					num = 0;
				}
				if ((double)num / (double)mountWeapon.Multiple > (double)mountWeapon.MaxLoad)
				{
					num = mountWeapon.MaxLoad;
				}
				mountWeapon.CurrentLoad = 0;
				Mount mount = theMount;
				int theQty_FullyLoadedCells = 0;
				int theQty_PartiallyLoadedCells = 0;
				int num2 = mount.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells);
				if ((double)num / (double)mountWeapon.Multiple > (double)(theMount.MaxCapacity - num2))
				{
					num = theMount.MaxCapacity - num2 * mountWeapon.Multiple;
				}
				mountWeapon.CurrentLoad = num;
				return mountWeapon.CurrentLoad;
			}
		}
		return 0;
	}

	static LuaWrapper_Device_Mount()
	{
		Class72.smethod_20();
	}
}
