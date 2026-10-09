using System;
using System.Collections.Generic;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotObfuscateType]
[DoNotPruneType]
[DoNotPrune]
public sealed class LuaWrapper_Group
{
	protected Group au;

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
	public LuaWrapper_Doctrine doctrine
	{
		get
		{
			if (au.Doctrine == null)
			{
				return null;
			}
			return new LuaWrapper_Doctrine(au.Doctrine, ScenarioContext);
		}
	}

	[DoNotPrune]
	public object __obj => au;

	[DoNotPrune]
	public string type => au.Type.ToString();

	[DoNotPrune]
	public string guid => au.ObjectID;

	[DoNotPrune]
	public string name
	{
		get
		{
			return au.Name;
		}
		set
		{
			au.Name = value;
		}
	}

	[DoNotPrune]
	public string side => au.get_UnitSide(SetSideOnly: false).Name;

	[DoNotPrune]
	public string lead
	{
		get
		{
			return au.GroupLead?.ObjectID;
		}
		set
		{
			Scenario scenarioContext = ScenarioContext;
			Group obj;
			Side Side = (obj = au).get_UnitSide(SetSideOnly: false);
			ActiveUnit activeUnit = LuaUtility.ValidAsUnit(value, scenarioContext, ref Side);
			obj.set_UnitSide(SetSideOnly: false, Side);
			ActiveUnit activeUnit2 = activeUnit;
			if (Information.IsNothing((object)activeUnit2))
			{
				return;
			}
			using IEnumerator<ActiveUnit> enumerator = au.Units.Values.GetEnumerator();
			do
			{
				if (!enumerator.MoveNext())
				{
					return;
				}
			}
			while (enumerator.Current != activeUnit2);
			au.SetGroupLead(activeUnit2);
		}
	}

	[DoNotPrune]
	public bool leadSlowsDown
	{
		get
		{
			return au.Kinematics.LeadAllowedToSlowDown;
		}
		set
		{
			au.Kinematics.LeadAllowedToSlowDown = value;
		}
	}

	[DoNotPrune]
	public LuaTable unitlist
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
			list = au.ToList();
			int num = 1;
			foreach (Module_Unit.Unit item in list)
			{
				luaTable[num] = item.ObjectID;
				num++;
			}
			return luaTable;
		}
	}

	public LuaWrapper_Group(Group a, Scenario s)
	{
		au = a;
		ScenarioContext = s;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return string.Concat("group {\r\n guid = '" + guid + "', \r\n name = '" + name + "', \r\n side = '" + side + "', \r\n type = '" + type.ToString() + "', \r\n unitlist = '" + unitlist.ToString() + "',\r\n", "}");
	}

	static LuaWrapper_Group()
	{
		Class72.smethod_20();
	}
}
