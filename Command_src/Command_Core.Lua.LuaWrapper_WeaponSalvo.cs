using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

public sealed class LuaWrapper_WeaponSalvo
{
	protected Scenario ScenarioContext;

	protected WeaponSalvo theWeapon;

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
	public object __obj => theWeapon;

	[DoNotPrune]
	public int dbid => theWeapon.int_1;

	[DoNotPrune]
	public Contact target => theWeapon.Target;

	[DoNotPrune]
	public DateTime scheduledFireTime => theWeapon.ScheduledFireTime;

	[DoNotPrune]
	public string specialMode => theWeapon.ActiveSpecialMode.ToString();

	[DoNotPrune]
	public int qtyAssigned => theWeapon.WpnQuantityAssigned;

	[DoNotPrune]
	public int qtyToFire => theWeapon.MaxNumberOfWeapons;

	[DoNotPrune]
	public int qtyOfShooters => theWeapon.MaxNumberOfShooters;

	[DoNotPrune]
	public bool manualFire => theWeapon.ManualFire;

	[DoNotPrune]
	public bool multiMountFire => theWeapon.FireSimultaneouslyFromMultipleMounts;

	[DoNotPrune]
	public LuaTable shooters
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			WeaponSalvo.Shooter[] shootersList = theWeapon.ShootersList;
			foreach (WeaponSalvo.Shooter shooter in shootersList)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["shooter"] = shooter.ShooterObjectID;
				luaTable2["qtyAssigned"] = shooter.QuantityAssigned;
				luaTable2["qtyFired"] = shooter.QuantityFired;
				luaTable[num] = luaTable2;
				num++;
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable course
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			Waypoint[] plottedCourse = theWeapon.PlottedCourse;
			foreach (Waypoint waypoint in plottedCourse)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2 = LuaWrapper_Waypoint.ToTable(waypoint, ScenarioContext);
				LuaWrapper_Waypoint value = new LuaWrapper_Waypoint(waypoint, ScenarioContext);
				luaTable2["WayPoint"] = value;
				luaTable[num] = luaTable2;
				num++;
			}
			return luaTable;
		}
		set
		{
			if (value == null)
			{
				ArrayExtensions.Clear(ref theWeapon.PlottedCourse);
				return;
			}
			ArrayExtensions.Clear(ref theWeapon.PlottedCourse);
			List<object> list = LuaUtility.ToArray(value.GetEnumerator());
			using List<object>.Enumerator enumerator = list.GetEnumerator();
			object objectValue;
			while (true)
			{
				if (enumerator.MoveNext())
				{
					objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
					if (!(objectValue is LuaTable))
					{
						break;
					}
					Waypoint waypoint = new Waypoint(0.0, 0.0, 0f, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Manual, Waypoint.WaypointCategory.PlottedCourse);
					if (LuaWrapper_Waypoint.FromTable((LuaTable)objectValue, waypoint, ScenarioContext))
					{
						ArrayExtensions.Add(ref theWeapon.PlottedCourse, waypoint);
					}
					continue;
				}
				return;
			}
			throw new LuaError("Error at " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)));
		}
	}

	public LuaWrapper_WeaponSalvo(WeaponSalvo a, Scenario s)
	{
		ScenarioContext = s;
		theWeapon = a;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return (("weapon {\r\n dbid = '" + dbid + "', \r\n target = '" + target.ObjectID.ToString() + "', \r\n scheduled = '" + scheduledFireTime.ToString() + "', \r\n") ?? "") + "}";
	}

	static LuaWrapper_WeaponSalvo()
	{
		Class72.smethod_20();
	}
}
