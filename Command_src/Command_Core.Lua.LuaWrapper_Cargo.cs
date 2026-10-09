using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscateType]
public sealed class LuaWrapper_Cargo
{
	internal Cargo cargo;

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
			if (dictionary.Count == 0)
			{
				return null;
			}
			LuaUtility.FromDict(dictionary, luaTable);
			return luaTable;
		}
	}

	[DoNotPrune]
	public object __obj => cargo;

	[DoNotPrune]
	public string guid => cargo.CargoObjectID;

	[DoNotPrune]
	public int type => (int)cargo.CurrentType;

	[DoNotPrune]
	public int storageType => (int)cargo.StorageType;

	[DoNotPrune]
	public int dbid => cargo.CargoObjectDBID;

	[DoNotPrune]
	public string name
	{
		get
		{
			if (!string.IsNullOrEmpty(cargo.Name))
			{
				return cargo.Name;
			}
			return cargo.CargoObjectName;
		}
	}

	[DoNotPrune]
	public int requiredSize => (int)cargo.RequiredCargoType;

	[DoNotPrune]
	public float requiredMass => cargo.RequiredMass;

	[DoNotPrune]
	public float requiredArea => cargo.RequiredAreaExternal;

	[DoNotPrune]
	public int requiredPAX => (int)Math.Round(cargo.RequiredCrewSpaceExternal);

	[DoNotPrune]
	public float requiredAreaAsStored => cargo.RequiredArea;

	[DoNotPrune]
	public int requiredPAXAsStored => (int)Math.Round(cargo.RequiredCrewSpace);

	[DoNotPrune]
	public bool isParadropCapable => cargo.isParadropCapable;

	[DoNotPrune]
	public LuaWrapper_ActiveUnit unit
	{
		get
		{
			ActiveUnit cargoObjectActiveUnit = cargo.CargoObjectActiveUnit;
			if (cargoObjectActiveUnit != null)
			{
				return new LuaWrapper_ActiveUnit(cargoObjectActiveUnit, ScenarioContext);
			}
			return null;
		}
	}

	[DoNotPrune]
	public LuaTable containerCargo
	{
		get
		{
			CargoContainer cargoObjectContainer = this.cargo.CargoObjectContainer;
			if (cargoObjectContainer == null)
			{
				return null;
			}
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (cargoObjectContainer.OnboardCargo.Count() > 0)
			{
				Cargo[] onboardCargo = cargoObjectContainer.OnboardCargo;
				foreach (Cargo cargo in onboardCargo)
				{
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					CargoContainerContent cargoObjectContainerContents = cargo.CargoObjectContainerContents;
					luaTable2["name"] = cargo.CargoObjectName;
					luaTable2["Type"] = (int)cargo.CurrentType;
					luaTable2["dbid"] = cargo.CargoObjectDBID;
					luaTable2["guid"] = cargo.CargoObjectID;
					luaTable2["area"] = cargo.RequiredArea;
					luaTable2["pax"] = cargo.RequiredCrewSpace;
					luaTable2["mass"] = cargo.RequiredMass;
					if (cargoObjectContainerContents != null)
					{
						luaTable2["contentType"] = (int)cargoObjectContainerContents.ContentType;
						switch (cargoObjectContainerContents.ContentType)
						{
						case CargoContainerContent.CargoContainerContentType.LiquidFuel:
						{
							CargoLiquidFuel cargoLiquidFuel = (CargoLiquidFuel)cargoObjectContainerContents;
							luaTable2["fuelType"] = (int)cargoLiquidFuel.FuelType;
							luaTable2["fuelQuantity"] = cargoLiquidFuel.CurrentQuantity;
							break;
						}
						case CargoContainerContent.CargoContainerContentType.Ammunition:
						{
							CargoAmmunition cargoAmmunition = (CargoAmmunition)cargoObjectContainerContents;
							luaTable2["weaponDBID"] = cargoAmmunition.int_1;
							luaTable2["weaponQuantity"] = cargoAmmunition.WeaponQuantity;
							break;
						}
						}
					}
					luaTable[luaTable.Keys.Count + 1] = luaTable2;
				}
			}
			return luaTable;
		}
	}

	public LuaWrapper_Cargo(Cargo c, Scenario s)
	{
		cargo = c;
		ScenarioContext = s;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return string.Concat("cargo {\r\n name = '" + name + "', \r\n type = '" + type + "', \r\n dbid = '" + dbid + "', \r\n guid = '" + guid.ToString() + "', \r\n storageType = '" + storageType + "', \r\n size = '" + storageType + "', \r\n mass = '" + requiredMass + "', \r\n area = '" + requiredArea + "', \r\n pax = '" + requiredPAX + "', \r\n isParadropCapable = '" + isParadropCapable + "', \r\n", "}");
	}

	public LuaWrapper_Cargo createContainerContentCustom(string name, int size, float mass, float area, float volume)
	{
		if (cargo.CurrentType == Cargo.CargoObjectType.CargoContainer)
		{
			CargoContainer cargoObjectContainer = cargo.CargoObjectContainer;
			if (cargoObjectContainer != null)
			{
				CargoContainerContent cargoContainerContent = new CargoContainerContent();
				cargoContainerContent.Name = name;
				cargoContainerContent.Mass = mass;
				cargoContainerContent.Area = area;
				cargoContainerContent.Volume = volume;
				cargoContainerContent.Size = (CargoType)size;
				if (cargoObjectContainer.CanLoad(cargoContainerContent))
				{
					Cargo c = new Cargo(cargoObjectContainer.ParentPlatform, cargoContainerContent, cargoObjectContainer);
					cargoObjectContainer.Add(c);
					return new LuaWrapper_Cargo(c, ScenarioContext);
				}
			}
		}
		return null;
	}

	public LuaWrapper_Cargo createContainerContentFuel(int fuelType, float fuelLiters)
	{
		if (this.cargo.CurrentType == Cargo.CargoObjectType.CargoContainer)
		{
			CargoContainer cargoObjectContainer = this.cargo.CargoObjectContainer;
			if (cargoObjectContainer != null && cargoObjectContainer.ContainerType == CargoContainer.CargoContainerType.Tank)
			{
				CargoLiquidFuel cargoLiquidFuel = new CargoLiquidFuel();
				cargoLiquidFuel.FuelType = (FuelRec._FuelType)fuelType;
				cargoLiquidFuel.CurrentQuantity = fuelLiters;
				Cargo cargo = null;
				if (cargoObjectContainer.CargoArray.Count() > 0)
				{
					cargo = cargoObjectContainer.CargoArray[0];
					cargoObjectContainer.Remove(cargo);
				}
				if (cargoObjectContainer.CanLoad(cargoLiquidFuel) && cargoLiquidFuel.CurrentQuantity > 0f)
				{
					Cargo c = new Cargo(cargoObjectContainer.ParentPlatform, cargoLiquidFuel, cargoObjectContainer);
					cargoObjectContainer.Add(c);
					return new LuaWrapper_Cargo(c, ScenarioContext);
				}
			}
		}
		return null;
	}

	public LuaWrapper_Cargo createContainerContentAmmunition(int int_0, int quantity)
	{
		if (cargo.CurrentType == Cargo.CargoObjectType.CargoContainer)
		{
			CargoContainer cargoObjectContainer = cargo.CargoObjectContainer;
			if (cargoObjectContainer != null)
			{
				CargoAmmunition cargoAmmunition = new CargoAmmunition(int_0, quantity, ScenarioContext);
				if (cargoObjectContainer.CanLoad(cargoAmmunition))
				{
					Cargo c = new Cargo(cargoObjectContainer.ParentPlatform, cargoAmmunition, cargoObjectContainer);
					cargoObjectContainer.Add(c);
					return new LuaWrapper_Cargo(c, ScenarioContext);
				}
			}
		}
		return null;
	}

	public LuaWrapper_Cargo addContainerContentUnit(string UnitID)
	{
		if (this.cargo.CurrentType == Cargo.CargoObjectType.CargoContainer)
		{
			CargoContainer cargoObjectContainer = this.cargo.CargoObjectContainer;
			if (cargoObjectContainer != null && !string.IsNullOrEmpty(UnitID))
			{
				ActiveUnit value = null;
				if (ScenarioContext.ActiveUnits.TryGetValue(UnitID, out value) && value is ICargoClient && cargoObjectContainer.CanLoad((ICargoClient)value))
				{
					if (value.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo && value.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false) != null)
					{
						ActiveUnit activeUnit = value.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false);
						List<Cargo> list = activeUnit.OnboardCargo.ToList();
						ICargoHost cargoHost = null;
						Cargo cargo = null;
						foreach (Cargo item in list)
						{
							if (item.CargoObjectActiveUnit != value)
							{
								if (item.CargoObjectContainer == null)
								{
									continue;
								}
								List<Cargo> list2 = item.CargoObjectContainer.OnboardCargo.ToList();
								foreach (Cargo item2 in list2)
								{
									if (item2.CargoObjectActiveUnit == value)
									{
										cargoHost = item.CargoObjectContainer;
										cargo = item2;
										break;
									}
								}
								continue;
							}
							cargoHost = (ICargoHost)activeUnit;
							cargo = item;
							break;
						}
						if (cargoHost != null && cargo != null)
						{
							cargoHost.Remove(cargo);
						}
					}
					if (cargoObjectContainer.ParentPlatform != null && cargoObjectContainer.ParentPlatform is ICargoHost)
					{
						_ = (ICargoHost)cargoObjectContainer.ParentPlatform;
					}
					else if (cargoObjectContainer.Parent != null)
					{
					}
					Cargo c = new Cargo(null, value);
					value.DockingOps.LoadIntoCargo(cargoObjectContainer.ParentPlatform);
					cargoObjectContainer.Add(c);
					return new LuaWrapper_Cargo(c, ScenarioContext);
				}
			}
		}
		return null;
	}

	public bool deleteContainerContents(string contentGuid)
	{
		int result;
		if (this.cargo.CurrentType == Cargo.CargoObjectType.CargoContainer)
		{
			CargoContainer cargoObjectContainer = this.cargo.CargoObjectContainer;
			if (cargoObjectContainer == null)
			{
				result = 0;
				goto IL_0060;
			}
			Cargo[] onboardCargo = cargoObjectContainer.OnboardCargo;
			foreach (Cargo cargo in onboardCargo)
			{
				if (Operators.CompareString(cargo.CargoObjectID, contentGuid, false) == 0)
				{
					ArrayExtensions.Remove(ref cargoObjectContainer.OnboardCargo, cargo);
					return true;
				}
			}
		}
		result = 0;
		goto IL_0060;
		IL_0060:
		return (byte)result != 0;
	}

	static LuaWrapper_Cargo()
	{
		Class72.smethod_20();
	}
}
