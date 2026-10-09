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
public sealed class LuaEnuNames
{
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
	public LuaTable Condition_Air
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(Aircraft_AirOps._AirOpsCondition));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string field = b.ToString();
				Aircraft_AirOps._AirOpsCondition airOpsCondition = (Aircraft_AirOps._AirOpsCondition)b;
				luaTable[field] = airOpsCondition.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable Condition_Dock
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(ActiveUnit_DockingOps._DockingOpsCondition));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string field = b.ToString();
				ActiveUnit_DockingOps._DockingOpsCondition dockingOpsCondition = (ActiveUnit_DockingOps._DockingOpsCondition)b;
				luaTable[field] = dockingOpsCondition.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable Throttle
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(ActiveUnit.Throttle));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string field = b.ToString();
				ActiveUnit.Throttle throttle = (ActiveUnit.Throttle)b;
				luaTable[field] = throttle.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable Depth
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(ActiveUnit_AI.SubmarineDepthPreset));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string field = b.ToString();
				ActiveUnit_AI.SubmarineDepthPreset submarineDepthPreset = (ActiveUnit_AI.SubmarineDepthPreset)b;
				luaTable[field] = submarineDepthPreset.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable Altitude
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(ActiveUnit_AI.AircraftAltitudePreset));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string field = b.ToString();
				ActiveUnit_AI.AircraftAltitudePreset aircraftAltitudePreset = (ActiveUnit_AI.AircraftAltitudePreset)b;
				luaTable[field] = aircraftAltitudePreset.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable ContactType
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(Contact_Base.ContactType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string field = b.ToString();
				Contact_Base.ContactType contactType = (Contact_Base.ContactType)b;
				luaTable[field] = contactType.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable Proficiency
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int[] array = (int[])Enum.GetValues(typeof(GlobalVariables.ProficiencyLevel));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				int num = array[i];
				string field = num.ToString();
				GlobalVariables.ProficiencyLevel proficiencyLevel = (GlobalVariables.ProficiencyLevel)num;
				luaTable[field] = proficiencyLevel.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable PatrolType
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.PatrolType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string field = b.ToString();
				GlobalVariables.PatrolType patrolType = (GlobalVariables.PatrolType)b;
				luaTable[field] = patrolType.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable StrikeType
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int[] array = (int[])Enum.GetValues(typeof(Strike.StrikeType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				int num = array[i];
				string field = num.ToString();
				Strike.StrikeType strikeType = (Strike.StrikeType)num;
				luaTable[field] = strikeType.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable UnitType
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string field = b.ToString();
				GlobalVariables.ActiveUnitType activeUnitType = (GlobalVariables.ActiveUnitType)b;
				luaTable[field] = activeUnitType.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable FuelType
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			short[] array = (short[])Enum.GetValues(typeof(FuelRec._FuelType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				short num = array[i];
				string field = num.ToString();
				FuelRec._FuelType fuelType = (FuelRec._FuelType)num;
				luaTable[field] = fuelType.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable FuelState
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			short[] array = (short[])Enum.GetValues(typeof(FuelRec._FuelType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				short num = array[i];
				string field = num.ToString();
				FuelRec._FuelType fuelType = (FuelRec._FuelType)num;
				luaTable[field] = fuelType.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable guidanceType
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(Weapon.WeaponGuidanceType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string field = b.ToString();
				Weapon.WeaponGuidanceType weaponGuidanceType = (Weapon.WeaponGuidanceType)b;
				luaTable[field] = weaponGuidanceType.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable sensorType
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			short[] array = (short[])Enum.GetValues(typeof(Sensor.Sensor_Type));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				short num = array[i];
				string field = num.ToString();
				Sensor.Sensor_Type sensor_Type = (Sensor.Sensor_Type)num;
				luaTable[field] = sensor_Type.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable sensorRole
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			long[] array = (long[])Enum.GetValues(typeof(Sensor.Sensor_Role));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				long num = array[i];
				string field = num.ToString();
				Sensor.Sensor_Role sensor_Role = (Sensor.Sensor_Role)num;
				luaTable[field] = sensor_Role.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable warheadType
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int[] array = (int[])Enum.GetValues(typeof(Warhead.WarheadType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				int num = array[i];
				string field = num.ToString();
				Warhead.WarheadType warheadType = (Warhead.WarheadType)num;
				luaTable[field] = warheadType.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable missionType
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int[] array = (int[])Enum.GetValues(typeof(Mission._MissionClass));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				int num = array[i];
				luaTable[num.ToString()] = ((Mission._MissionClass)num/*cast due to .constrained prefix*/).ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable loadoutRole
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int[] array = (int[])Enum.GetValues(typeof(Loadout.LoadoutRole));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				int num = array[i];
				string field = num.ToString();
				Loadout.LoadoutRole loadoutRole = (Loadout.LoadoutRole)num;
				luaTable[field] = loadoutRole.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable loadoutWeather
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			short[] array = (short[])Enum.GetValues(typeof(Loadout._LoadoutWeather));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				short num = array[i];
				string field = num.ToString();
				Loadout._LoadoutWeather loadoutWeather = (Loadout._LoadoutWeather)num;
				luaTable[field] = loadoutWeather.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable loadoutTOD
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			short[] array = (short[])Enum.GetValues(typeof(Loadout._LoadoutDayNight));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				short num = array[i];
				string field = num.ToString();
				Loadout._LoadoutDayNight loadoutDayNight = (Loadout._LoadoutDayNight)num;
				luaTable[field] = loadoutDayNight.ToString();
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	internal LuaTable Doctrine(string type)
	{
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		switch (type.ToLower())
		{
		case "fuelstate":
		{
			byte[] array4 = (byte[])Enum.GetValues(typeof(Doctrine._FuelState));
			for (int l = 0; l < array4.Length; l = checked(l + 1))
			{
				byte b = array4[l];
				string field4 = b.ToString();
				Doctrine._FuelState fuelState = (Doctrine._FuelState)b;
				luaTable[field4] = fuelState.ToString();
			}
			break;
		}
		case "weaponstate":
		{
			int[] array2 = (int[])Enum.GetValues(typeof(Doctrine._WeaponState));
			for (int j = 0; j < array2.Length; j = checked(j + 1))
			{
				int num2 = array2[j];
				string field2 = num2.ToString();
				Doctrine._WeaponState weaponState = (Doctrine._WeaponState)num2;
				luaTable[field2] = weaponState.ToString();
			}
			break;
		}
		case "rechargebattery":
		{
			int[] array3 = (int[])Enum.GetValues(typeof(Doctrine._RechargeBatteryPercentage));
			for (int k = 0; k < array3.Length; k = checked(k + 1))
			{
				int num3 = array3[k];
				string field3 = num3.ToString();
				Doctrine._RechargeBatteryPercentage rechargeBatteryPercentage = (Doctrine._RechargeBatteryPercentage)num3;
				luaTable[field3] = rechargeBatteryPercentage.ToString();
			}
			break;
		}
		case "wratargettype":
		{
			int[] array = (int[])Enum.GetValues(typeof(Doctrine._WRA_WeaponTargetType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				int num = array[i];
				string field = num.ToString();
				Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = (Doctrine._WRA_WeaponTargetType)num;
				luaTable[field] = wRA_WeaponTargetType.ToString();
			}
			break;
		}
		}
		return luaTable;
	}

	static LuaEnuNames()
	{
		Class72.smethod_20();
	}
}
