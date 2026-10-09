using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

public sealed class CMANO
{
	public sealed class LuaFunctionArg
	{
		internal string name;

		internal LuaFunction func;

		internal List<object> args;

		public LuaFunctionArg(string myName, LuaFunction myfunc, List<object> myArg)
		{
			args = new List<object>();
			func = myfunc;
			args = myArg;
			name = myName;
		}

		static LuaFunctionArg()
		{
			Class72.smethod_20();
		}
	}

	public sealed class LuaTriggers
	{
		internal LuaTriggers()
		{
		}

		public static void ClearOldLuaFunction(string func_name)
		{
			LuaFunction luaFunction = null;
			LuaTable luaTable = null;
			try
			{
				LuaSandBox luaSandBox = LuaSandBox.Singleton();
				if (luaSandBox == null)
				{
					return;
				}
				object objectValue = RuntimeHelpers.GetObjectValue(luaSandBox.SB_Lua()[func_name]);
				if (objectValue is LuaFunction)
				{
					try
					{
						luaFunction = LuaSandBox.Singleton().SB_Lua().GetFunction(func_name);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
				else if (objectValue is LuaTable)
				{
					try
					{
						luaTable = LuaSandBox.Singleton().SB_Lua().GetTable(func_name);
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						_ = Debugger.IsAttached;
						ProjectData.ClearProjectError();
					}
				}
				if (luaFunction != null)
				{
					LuaSandBox.Singleton().SB_Lua().DoString(func_name + "=nil");
				}
				if (luaTable != null)
				{
					LuaSandBox.Singleton().SB_Lua().DoString(func_name + "={}");
				}
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				ProjectData.ClearProjectError();
			}
		}

		public static void AddOpsHandler()
		{
			Aircraft_AirOps.AirOpsStatusChange -= OnStatusChangeEvent;
			ActiveUnit_DockingOps.DockingOpsStatusChange -= OnStatusChangeEvent;
			Aircraft_AirOps.AirOpsStatusChange += OnStatusChangeEvent;
			ActiveUnit_DockingOps.DockingOpsStatusChange += OnStatusChangeEvent;
		}

		public static void OnStatusChangeEvent(ActiveUnit theUnit, object oldStatus)
		{
			if (scenario_0 == null)
			{
				scenario_0 = theUnit.ParentScen;
			}
			if (scenario_0.EventTriggers == null)
			{
				return;
			}
			List<EventTrigger> list = new List<EventTrigger>();
			foreach (EventTrigger value in scenario_0.EventTriggers.Values)
			{
				if (value.Type == EventTrigger.EventTriggerType.UnitBaseStatus && ((EventTrigger_UnitBaseStatus)value).get_IsFulfilled(theUnit, RuntimeHelpers.GetObjectValue(oldStatus)))
				{
					list.Add(value);
				}
			}
			if (list.Count > 0)
			{
				scenario_0.FireEvents(list);
			}
		}

		static LuaTriggers()
		{
			Class72.smethod_20();
		}
	}

	private static Scenario scenario_0;

	internal static List<LuaFunctionArg> LuaFunctionList;

	private string string_0;

	private static List<(ActiveUnit, object)> list_0;

	public static LuaTriggers triggers;

	private static LockObject lockObject_0;

	public string test
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	static CMANO()
	{
		Class72.smethod_20();
		LuaFunctionList = new List<LuaFunctionArg>();
		list_0 = new List<(ActiveUnit, object)>();
		triggers = new LuaTriggers();
		lockObject_0 = new LockObject();
	}

	public static void StatusChanged(ActiveUnit theUnit, object oldStatus)
	{
		list_0.Add((theUnit, oldStatus));
	}

	public static void HandleScenarioChanging()
	{
		LuaFunctionList.Clear();
	}

	public static object[] CallFunctionSynchronously(LuaFunction theLuaFunction, object[] ParametersArray)
	{
		try
		{
			lock (lockObject_0)
			{
				return theLuaFunction.Call(ParametersArray);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_ = Debugger.IsAttached;
			throw;
		}
	}

	internal CMANO(Scenario ScenarioContext)
	{
		scenario_0 = ScenarioContext;
	}

	public void AddLuaFuction(string name, LuaTable param)
	{
		LuaFunction function = LuaSandBox.Singleton().SB_Lua().GetFunction(name);
		List<object> myArg = LuaUtility.ToArray(param.GetEnumerator());
		if (function == null)
		{
			return;
		}
		LuaFunctionArg luaFunctionArg = new LuaFunctionArg(name, function, myArg);
		LuaFunctionArg luaFunctionArg2 = null;
		foreach (LuaFunctionArg luaFunction in LuaFunctionList)
		{
			if (Operators.CompareString(luaFunction.name, luaFunctionArg.name, false) == 0 && !luaFunction.args.Except(luaFunctionArg.args).Union(luaFunction.args.Except(luaFunctionArg.args)).Any())
			{
				LuaFunctionList.Remove(luaFunction);
				break;
			}
		}
		if (luaFunctionArg != null)
		{
			LuaFunctionList.Add(luaFunctionArg);
		}
	}

	public void RemoveLuaFuction(string name, LuaTable param = null)
	{
		if (!((name == null) | (Operators.CompareString(name, "", false) == 0)))
		{
			LuaFunction function = LuaSandBox.Singleton().SB_Lua().GetFunction(name);
			if (function == null)
			{
				return;
			}
			List<object> myArg = LuaUtility.ToArray(param.GetEnumerator());
			LuaFunctionArg luaFunctionArg = new LuaFunctionArg(name, function, myArg);
			LuaFunctionArg luaFunctionArg2 = null;
			foreach (LuaFunctionArg luaFunction in LuaFunctionList)
			{
				if (Operators.CompareString(luaFunction.name, luaFunctionArg.name, false) == 0 && !luaFunction.args.Except(luaFunctionArg.args).Union(luaFunction.args.Except(luaFunctionArg.args)).Any())
				{
					LuaFunctionList.Remove(luaFunction);
					luaFunctionArg = null;
					break;
				}
			}
			if (luaFunctionArg == null)
			{
				return;
			}
			List<LuaFunctionArg> luaFunctionList = LuaFunctionList;
			{
				foreach (LuaFunctionArg item in luaFunctionList)
				{
					if (Operators.CompareString(item.name, luaFunctionArg.name, false) == 0)
					{
						LuaFunctionList.Remove(item);
					}
				}
				return;
			}
		}
		LuaFunctionList.Clear();
	}

	internal string NewTest()
	{
		test = "abcdf";
		return test;
	}

	private static UnitFilterObject smethod_0(ref Dictionary<string, object> dictionary_0, Scenario scenario_1)
	{
		try
		{
			ActiveUnit activeUnit = null;
			Side side = null;
			UnitFilterObject unitFilterObject = new UnitFilterObject();
			foreach (string key in dictionary_0.Keys)
			{
				string text = dictionary_0[key].ToString();
				switch (key.ToUpperInvariant())
				{
				case "TARGETTYPE":
				{
					byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
					int num = 0;
					while (num < array.Length)
					{
						byte b = array[num];
						if (!string.Equals(text, b.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							GlobalVariables.ActiveUnitType activeUnitType = (GlobalVariables.ActiveUnitType)b;
							if (!string.Equals(text, activeUnitType.ToString(), StringComparison.OrdinalIgnoreCase))
							{
								num = checked(num + 1);
								continue;
							}
						}
						unitFilterObject.TargetType = (GlobalVariables.ActiveUnitType)b;
						break;
					}
					if (unitFilterObject.TargetType != GlobalVariables.ActiveUnitType.None)
					{
						break;
					}
					throw new LuaError("Error in TargetFilter.Type!", "CMANO.CreateTargetTrigger");
				}
				case "SPECIFICUNITCLASS":
					unitFilterObject.SpecificUnitClass = Conversions.ToInteger(text);
					break;
				case "SPECIFICUNIT":
				case "SPECIFICUNITID":
					activeUnit = PrivateMethods.smethod_1(text, scenario_1);
					if (activeUnit != null)
					{
						unitFilterObject.SpecificUnitID = activeUnit.ObjectID;
						break;
					}
					throw new LuaError("Error in TargetFilter.Unit!", "CMANO.CreateTargetTrigger");
				case "TARGETSUBTYPE":
					unitFilterObject.TargetSubType = Conversions.ToInteger(text);
					break;
				case "TARGETSIDE":
					side = PrivateMethods.ValidateSide(text, scenario_1);
					if (side == null)
					{
						if (Operators.CompareString(text.ToUpper(), "ANY", false) == 0)
						{
							unitFilterObject.TargetSide = "";
							break;
						}
						if (Operators.CompareString(text.ToUpper(), "PLAYERSIDE", false) != 0)
						{
							throw new LuaError("Error in TargetFilter.Side!", "CMANO.CreateTargetTrigger");
						}
						unitFilterObject.TargetSide = scenario_1.GetCurrentSide().ObjectID;
					}
					else
					{
						unitFilterObject.TargetSide = side.ObjectID;
					}
					break;
				}
			}
			if (!string.IsNullOrEmpty(unitFilterObject.SpecificUnitID))
			{
				unitFilterObject.SpecificUnitClass = activeUnit.DBID;
				unitFilterObject.TargetSubType = activeUnit.SubType;
				unitFilterObject.TargetType = activeUnit.UnitType;
				unitFilterObject.TargetSide = activeUnit.get_UnitSide(SetSideOnly: false).ObjectID;
			}
			else
			{
				if (unitFilterObject.TargetSide == null)
				{
					throw new LuaError("Error in TargetFilter.TargetSide!", "CMANO.CreateTargetTrigger");
				}
				if (unitFilterObject.SpecificUnitClass == 0)
				{
					if (unitFilterObject.TargetSubType != 0 && unitFilterObject.TargetType == GlobalVariables.ActiveUnitType.None)
					{
						throw new LuaError("Error in TargetFilter.SubType!", "CMANO.CreateTargetTrigger");
					}
				}
				else
				{
					switch (unitFilterObject.TargetType)
					{
					case GlobalVariables.ActiveUnitType.Aircraft:
						unitFilterObject.TargetSubType = DBFunctions.GetAircraftType_Int(ref scenario_1, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Ship:
						unitFilterObject.TargetSubType = DBFunctions.GetShipType_Int(ref scenario_1, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Submarine:
						unitFilterObject.TargetSubType = DBFunctions.GetSubmarineType_Int(ref scenario_1, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Facility:
						unitFilterObject.TargetSubType = DBFunctions.GetFacilityCategory_Int(ref scenario_1, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Weapon:
						unitFilterObject.TargetSubType = DBFunctions.GetWeaponType_Int(ref scenario_1, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Satellite:
						unitFilterObject.TargetSubType = DBFunctions.GetSatelliteType_Int(ref scenario_1, unitFilterObject.SpecificUnitClass);
						break;
					}
					if (unitFilterObject.TargetSubType == 0 || unitFilterObject.TargetType == GlobalVariables.ActiveUnitType.None)
					{
						throw new LuaError("Error in TargetFilter.Class!", "CMANO.CreateTargetTrigger");
					}
				}
			}
			return unitFilterObject;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return null;
	}
}
