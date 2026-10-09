using System;
using System.Collections.Generic;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotObfuscateType]
[DoNotPrune]
[DoNotPruneType]
public class LuaWrapper_Serial
{
	protected Scenario ScenarioContext;

	private Chalk chalk_0;

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
	public int ID
	{
		get
		{
			return chalk_0.ID;
		}
		set
		{
			chalk_0.ID = value;
		}
	}

	[DoNotPrune]
	public string AssociatedMothership => chalk_0.AssociatedMothership.ObjectID;

	[DoNotPrune]
	public CargoType LargestCargoType => chalk_0.GetLargestCargo();

	[DoNotPrune]
	public float Mass => chalk_0.GetMass();

	[DoNotPrune]
	public float Area => chalk_0.GetArea();

	[DoNotPrune]
	public float PAX => chalk_0.GetCrew();

	public LuaWrapper_Serial(Scenario s, Chalk _mySerial)
	{
		ScenarioContext = s;
		chalk_0 = _mySerial;
		side_0 = _mySerial.AssociatedMothership.get_UnitSide(SetSideOnly: false);
	}

	[DoNotPrune]
	public override string ToString()
	{
		return string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat("Serial/Chalk {\r\n" + " AssociatedMothership = '" + AssociatedMothership, " ID = '", ID.ToString()), " LargestCargoType = '", LargestCargoType.ToString()), " Mass = '", Mass.ToString()), " Area = '", Area.ToString()), " PAX = '", PAX.ToString()), "\r\n"), "}");
	}

	static LuaWrapper_Serial()
	{
		Class72.smethod_20();
	}
}
