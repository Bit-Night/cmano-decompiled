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
public sealed class LuaWrapper_Geopoint
{
	private GeoPoint geoPoint_0;

	private Scenario scenario_0;

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
	public string objectid => geoPoint_0.ObjectID;

	[DoNotPrune]
	public string name
	{
		get
		{
			return geoPoint_0.Name;
		}
		set
		{
			geoPoint_0.Name = value;
		}
	}

	[DoNotPrune]
	public double latitude
	{
		get
		{
			return geoPoint_0.Latitude;
		}
		set
		{
			double? num = LuaUtility.QueryLatitudeObject(value);
			if (!num.HasValue)
			{
				throw new LuaError("Can't pass nil in as latitude.");
			}
			geoPoint_0.Latitude = num.Value;
		}
	}

	[DoNotPrune]
	public double longitude
	{
		get
		{
			return geoPoint_0.Longitude;
		}
		set
		{
			double? num = LuaUtility.QueryLongitudeObject(value);
			if (!num.HasValue)
			{
				throw new LuaError("Can't pass nil in as longitude.");
			}
			geoPoint_0.Longitude = num.Value;
		}
	}

	[DoNotPrune]
	public float altitude
	{
		get
		{
			return geoPoint_0.Altitude;
		}
		set
		{
			geoPoint_0.Altitude = value;
		}
	}

	public LuaWrapper_Geopoint(GeoPoint theGeopoint, Scenario theScen)
	{
		geoPoint_0 = theGeopoint;
		scenario_0 = theScen;
	}

	static LuaWrapper_Geopoint()
	{
		Class72.smethod_20();
	}
}
