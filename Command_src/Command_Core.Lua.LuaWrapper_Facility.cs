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
public sealed class LuaWrapper_Facility
{
	protected DockFacility dock;

	protected AirFacility air;

	protected Scenario ScenarioContext;

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
			if (dictionary.Count == 0)
			{
				return null;
			}
			LuaUtility.FromDict(dictionary, luaTable);
			return luaTable;
		}
	}

	[DoNotPrune]
	public object __au
	{
		get
		{
			if (air == null)
			{
				if (dock == null)
				{
					return null;
				}
				return dock;
			}
			return air;
		}
	}

	[DoNotPrune]
	public string guid
	{
		get
		{
			if (air != null)
			{
				return air.ObjectID;
			}
			if (dock != null)
			{
				return dock.ObjectID;
			}
			return null;
		}
	}

	[DoNotPrune]
	public int dbid
	{
		get
		{
			if (air == null)
			{
				if (dock != null)
				{
					return dock.DBID;
				}
				return 0;
			}
			return air.DBID;
		}
	}

	[DoNotPrune]
	public string name
	{
		get
		{
			if (air != null)
			{
				return air.Name;
			}
			if (dock == null)
			{
				return null;
			}
			return dock.Name;
		}
	}

	[DoNotPrune]
	public int type
	{
		get
		{
			if (air == null)
			{
				if (dock != null)
				{
					return (int)dock.Type;
				}
				return 0;
			}
			return (int)air.AirFacType;
		}
	}

	[DoNotPrune]
	public int capacity
	{
		get
		{
			if (air != null)
			{
				return air.Capacity;
			}
			if (dock != null)
			{
				return dock.Capacity;
			}
			return 0;
		}
		set
		{
			if (air == null)
			{
				if (dock != null)
				{
					dock.Capacity = (byte)value;
				}
			}
			else
			{
				air.Capacity = value;
			}
		}
	}

	[DoNotPrune]
	public string status
	{
		get
		{
			if (air == null)
			{
				if (dock == null)
				{
					return null;
				}
				return dock.Status.ToString();
			}
			return air.Status.ToString();
		}
	}

	public LuaWrapper_Facility(object a, Scenario s)
	{
		dock = null;
		air = null;
		if ((object)a.GetType() == typeof(AirFacility))
		{
			air = (AirFacility)a;
		}
		else if ((object)a.GetType() == typeof(DockFacility))
		{
			dock = (DockFacility)a;
		}
		ScenarioContext = s;
	}

	static LuaWrapper_Facility()
	{
		Class72.smethod_20();
	}
}
