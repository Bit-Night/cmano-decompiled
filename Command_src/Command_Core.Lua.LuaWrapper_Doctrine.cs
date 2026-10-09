using System;
using System.Collections.Generic;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPruneType]
[DoNotObfuscateType]
[DoNotPrune]
public sealed class LuaWrapper_Doctrine
{
	protected Doctrine doc;

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
	public object __obj => doc;

	[DoNotPrune]
	public LuaTable TargetPriority
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (doc != null && ScenarioContext != null)
			{
				List<Doctrine.PriorityTargetEntry> priorityTargetList = doc.PriorityTargetList;
				if (priorityTargetList != null && priorityTargetList.Count > 0)
				{
					foreach (Doctrine.PriorityTargetEntry item in priorityTargetList)
					{
						LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
						luaTable2["type"] = (int)item.Type;
						if (item.SubType < Doctrine.PriorityTargetEntry.FACILITY_SUBTYPE_OFFSET_INDEX)
						{
							luaTable2["subtype"] = item.SubType;
							luaTable2["isfixedfacilitysubtype"] = false;
						}
						else
						{
							luaTable2["subtype"] = item.SubType - Doctrine.PriorityTargetEntry.FACILITY_SUBTYPE_OFFSET_INDEX;
							luaTable2["isfixedfacilitysubtype"] = true;
						}
						luaTable2["dbid"] = item.DBID;
						luaTable2["priority"] = (int)item.Priority;
						luaTable[luaTable.Keys.Count + 1] = luaTable2;
					}
				}
			}
			return luaTable;
		}
	}

	public LuaWrapper_Doctrine(Doctrine a, Scenario s)
	{
		doc = a;
		ScenarioContext = s;
	}

	[DoNotPrune]
	public LuaTable method_0(string type)
	{
		return LuaSandBox.Singleton().CreateTable();
	}

	public LuaTable deleteTargetPriorityEntry(int index)
	{
		if (doc != null && ScenarioContext != null)
		{
			doc.DeletePriorityTargetListEntry(index);
		}
		return TargetPriority;
	}

	public LuaTable addTargetPriorityEntry(int type, int subtype, bool isfixedfacilitysubtype, int dbid, int index)
	{
		if (doc != null && ScenarioContext != null)
		{
			if (type == 0)
			{
				throw new LuaError("Invalid unit type for Target Priority entry.");
			}
			GlobalVariables.ActiveUnitType activeUnitType = (GlobalVariables.ActiveUnitType)type;
			if (subtype != 0)
			{
				bool flag = false;
				switch (activeUnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					foreach (object value in Enum.GetValues(typeof(Aircraft._AircraftType)))
					{
						if (Conversions.ToInteger(value) == subtype)
						{
							flag = true;
							break;
						}
					}
					break;
				case GlobalVariables.ActiveUnitType.Ship:
					foreach (object value2 in Enum.GetValues(typeof(Ship._ShipType)))
					{
						if (Conversions.ToInteger(value2) == subtype)
						{
							flag = true;
							break;
						}
					}
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					foreach (object value3 in Enum.GetValues(typeof(Submarine._SubmarineType)))
					{
						if (Conversions.ToInteger(value3) == subtype)
						{
							flag = true;
							break;
						}
					}
					break;
				case GlobalVariables.ActiveUnitType.Facility:
					if (isfixedfacilitysubtype)
					{
						foreach (object value4 in Enum.GetValues(typeof(Facility._FacilityCategory)))
						{
							if (Conversions.ToShort(value4) == subtype)
							{
								flag = true;
								break;
							}
						}
						break;
					}
					foreach (object value5 in Enum.GetValues(typeof(IMobileGroundUnit._MobileUnitCategory)))
					{
						if (Conversions.ToInteger(value5) == subtype)
						{
							flag = true;
							break;
						}
					}
					break;
				case GlobalVariables.ActiveUnitType.Weapon:
					if (subtype == 2001)
					{
						flag = true;
					}
					break;
				default:
					throw new LuaError("Invalid unit type for Target Priority entry.");
				case GlobalVariables.ActiveUnitType.Vehicle:
					foreach (object value6 in Enum.GetValues(typeof(IMobileGroundUnit._MobileUnitCategory)))
					{
						if (Conversions.ToInteger(value6) == subtype)
						{
							flag = true;
							break;
						}
					}
					break;
				}
				if (!flag)
				{
					throw new LuaError("Invalid unit sub-type for Target Priority entry.");
				}
				if (isfixedfacilitysubtype)
				{
					subtype += Doctrine.PriorityTargetEntry.FACILITY_SUBTYPE_OFFSET_INDEX;
				}
			}
			if (doc.PriorityTargetList == null || doc.PriorityTargetList.Count == 0)
			{
				doc.CreatePriorityTargetList();
			}
			doc.AddPriorityTargetListEntry(activeUnitType, subtype, dbid, index);
			doc.SortPriorityTargetList();
		}
		return TargetPriority;
	}

	static LuaWrapper_Doctrine()
	{
		Class72.smethod_20();
	}
}
