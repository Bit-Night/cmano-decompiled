using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscateType]
public sealed class LuaWrapper_Device_Sensor
{
	protected Scenario ScenarioContext;

	protected Sensor theSensor;

	public object fields
	{
		get
		{
			Type obj = GetType();
			int num = 0;
			PropertyInfo[] array = obj.GetProperties();
			MethodInfo[] methods = obj.GetMethods();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			PropertyInfo[] array2 = array;
			foreach (PropertyInfo propertyInfo in array2)
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
				MethodInfo[] array3 = methods;
				foreach (MethodInfo obj2 in array3)
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
			MethodInfo[] array4 = methods;
			foreach (MethodInfo methodInfo in array4)
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
	public object __obj => theSensor;

	[DoNotPrune]
	public int dbid => theSensor.DBID;

	[DoNotPrune]
	public string name => theSensor.Name;

	[DoNotPrune]
	public string guid => theSensor.ObjectID;

	[DoNotPrune]
	public short type => (short)theSensor.Type;

	[DoNotPrune]
	public long role => (long)theSensor.Role;

	[DoNotPrune]
	public LuaTable ranges
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			luaTable["min"] = theSensor.minRange;
			luaTable["max"] = theSensor.maxRange;
			return luaTable;
		}
	}

	[DoNotPrune]
	public int scaninterval => theSensor.ScanInterval;

	[DoNotPrune]
	public LuaTable altitudes
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			luaTable["min"] = theSensor.MinAltitude_ASL;
			luaTable["max"] = theSensor.MaxAltitude_ASL;
			return luaTable;
		}
	}

	public float MaxElevationAngle
	{
		get
		{
			return theSensor.MaxElevationAngle;
		}
		set
		{
			theSensor.MaxElevationAngle = value;
		}
	}

	public float MinElevationAngle
	{
		get
		{
			return theSensor.MinElevationAngle;
		}
		set
		{
			theSensor.MinElevationAngle = value;
		}
	}

	[DoNotPrune]
	public LuaTable bands
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (theSensor.Type == Sensor.Sensor_Type.Radar)
			{
				if (theSensor.SearchFreqs.Length > 0)
				{
					stringBuilder.Append(string.Join(" / ", theSensor.SearchFreqs.Select([SpecialName] (Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
					luaTable["radarSearchBands"] = stringBuilder.ToString();
				}
				if (theSensor.IlluminationFreqs.Length > 0)
				{
					stringBuilder.Append(string.Join(" / ", theSensor.IlluminationFreqs.Select([SpecialName] (Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
					luaTable["radarIllumBands"] = stringBuilder.ToString();
				}
			}
			if ((theSensor.IsOECM || theSensor.IsDECM || theSensor.IsSonar) && theSensor.SearchFreqs.Length > 0)
			{
				stringBuilder.Append(string.Join(" / ", theSensor.SearchFreqs.Select([SpecialName] (Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
				luaTable["otherSearchBands"] = stringBuilder.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable properties
	{
		get
		{
			new StringBuilder();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			List<string> list = new List<string>();
			list = DBFunctions.GetSensorFlagDescriptions(theSensor.DBID, ScenarioContext.DBConnection);
			foreach (string item in list)
			{
				luaTable[luaTable.Keys.Count + 1] = item;
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable abilities
	{
		get
		{
			new StringBuilder();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			List<string> list = new List<string>();
			list = DBFunctions.GetSensorCapabilitiesDescriptions(theSensor.DBID, ScenarioContext.DBConnection);
			if (theSensor.Type == Sensor.Sensor_Type.ESM)
			{
				list.Add("Air Search");
				list.Add("Surface Search");
			}
			if (theSensor.Codes.NCTR_JEM)
			{
				list.Add("NCTR - JEM");
			}
			if (theSensor.Codes.NCTR_NBILST)
			{
				list.Add("NCTR - NBILST");
			}
			if (theSensor.Type == Sensor.Sensor_Type.ESM && theSensor.ESM_PreciseEmitterID)
			{
				list.Add("Specific Emitter ID");
			}
			foreach (string item in list)
			{
				luaTable[luaTable.Keys.Count + 1] = item;
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public string technology
	{
		get
		{
			if (theSensor.TechGeneration < (GlobalVariables.TechGenerationClass)2000)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(DBFunctions.Get_Sensor_Generation_String(ref ScenarioContext, (int)theSensor.TechGeneration) + " Technology");
			return stringBuilder.ToString();
		}
	}

	public LuaWrapper_Device_Sensor(Sensor a, Scenario s)
	{
		ScenarioContext = s;
		theSensor = a;
	}

	[DoNotPrune]
	public LuaTable RangeAgainstTarget(LuaWrapper_ActiveUnit_SE DetectorUnit, LuaWrapper_ActiveUnit_SE theDetectedUnit)
	{
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		luaTable["maxIR"] = theSensor.MaxDetectionRangeOnThisTarget_IR(DetectorUnit.au, theDetectedUnit.au);
		luaTable["maxVisual"] = theSensor.MaxDetectionRangeOnThisTarget_Visual(DetectorUnit.au, theDetectedUnit.au, ConsiderTerrainEffects_DetectorAndTarget: true, ConsiderTerrainEffects_BlockageOnLOSPath: true, ConsiderWeather: true);
		return luaTable;
	}

	[DoNotPrune]
	public object IsPreciseCheck(LuaWrapper_ActiveUnit_SE DetectorUnit, LuaWrapper_ActiveUnit_SE theDetectedUnit)
	{
		object obj = null;
		float detectionRange = Module_Unit.RangeToUnit_Slant(DetectorUnit.au, theDetectedUnit.au);
		obj = theSensor.get_IsPrecise(detectionRange);
		Conversions.ToBoolean(obj);
		return obj;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return (("sensor {\r\n name = '" + name + "', \r\n dbid = '" + dbid + "', \r\n") ?? "") + "}";
	}

	static LuaWrapper_Device_Sensor()
	{
		Class72.smethod_20();
	}
}
