using System;
using System.Collections.Generic;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotObfuscateType]
[DoNotPrune]
[DoNotPruneType]
public class LuaWrapper_Operation
{
	protected Scenario ScenarioContext;

	private Operation operation_0;

	private Side side_0;

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
				dictionary.Add("property_" + num, text + propertyInfo.Name + " , " + propertyInfo.PropertyType.Name + " , " + flag);
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
	public LuaWrapper_Mission LHourMission
	{
		get
		{
			if (operation_0.LHourMission == null)
			{
				return null;
			}
			return new LuaWrapper_Mission(operation_0.LHourMission, ScenarioContext);
		}
		set
		{
			operation_0.LHourMission = LuaMission.ValidateMissionBySide(value.guid, side_0);
		}
	}

	[DoNotPrune]
	public LuaWrapper_Mission HHourMission
	{
		get
		{
			if (operation_0.HHourMission == null)
			{
				return null;
			}
			return new LuaWrapper_Mission(operation_0.HHourMission, ScenarioContext);
		}
		set
		{
			operation_0.HHourMission = LuaMission.ValidateMissionBySide(value.guid, side_0);
		}
	}

	[DoNotPrune]
	public string HHour
	{
		get
		{
			return operation_0.HHour.ToString();
		}
		set
		{
			try
			{
				if (value.Length > 0)
				{
					operation_0.HHour = Conversions.ToDate(value);
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
	public string LHour
	{
		get
		{
			return operation_0.LHour.ToString();
		}
		set
		{
			try
			{
				if (value.Length > 0)
				{
					operation_0.LHour = Conversions.ToDate(value);
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
	public string HHourEffectiveStartTime => operation_0.HHourEffectiveStartTime.ToString();

	[DoNotPrune]
	public string LHourEffectiveStartTime => operation_0.LHourEffectiveStartTime.ToString();

	[DoNotPrune]
	public bool H_LHourAreRelative
	{
		get
		{
			return operation_0.H_LHourAreRelative;
		}
		set
		{
			operation_0.H_LHourAreRelative = value;
		}
	}

	public LuaWrapper_Operation(Scenario s, Operation _operation, Side _Side)
	{
		ScenarioContext = s;
		operation_0 = _operation;
		side_0 = _Side;
	}

	[DoNotPrune]
	public override string ToString()
	{
		string text = "Operation {\r\n";
		text = (Information.IsNothing((object)LHourMission) ? (text + " LHourMission = NULL'") : (text + " LHourMission = '" + LHourMission.ToString()));
		text += "\r\n";
		text = (Information.IsNothing((object)HHourMission) ? (text + " HHourMission = NULL'") : (text + " HHourMission = '" + HHourMission.ToString()));
		text += "\r\n";
		text = ((!string.IsNullOrEmpty(HHour)) ? (text + " HHour = '" + HHour) : (text + " HHour = N/D'"));
		text += "\r\n";
		text = (string.IsNullOrEmpty(LHour) ? (text + " LHour = N/D'") : (text + " LHour = '" + LHour));
		text += "\r\n";
		text = ((!string.IsNullOrEmpty(HHourEffectiveStartTime)) ? (text + " HHourEffectiveStartTime = '" + HHourEffectiveStartTime) : (text + " HHourEffectiveStartTime = N/D'"));
		text = ((!string.IsNullOrEmpty(LHourEffectiveStartTime)) ? (text + " LHourEffectiveStartTime = '" + LHourEffectiveStartTime) : (text + " LHourEffectiveStartTime = N/D'"));
		text = text + " H_LHourAreRelative = '" + H_LHourAreRelative;
		text += "\r\n";
		return text + "}";
	}

	static LuaWrapper_Operation()
	{
		Class72.smethod_20();
	}
}
