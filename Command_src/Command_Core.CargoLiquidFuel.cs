using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class CargoLiquidFuel : CargoContainerContent
{
	public const float DENSITY_AVIATION_FUEL = 0.8f;

	public const float DENSITY_DIESEL_FUEL = 0.85f;

	public const float DENSITY_OIL_FUEL = 0.875f;

	public const float DENSITY_GAS_FUEL = 0.875f;

	public const float DENSITY_GASOLINE_FUEL = 0.75f;

	public FuelRec._FuelType FuelType;

	public float CurrentQuantity;

	public CargoLiquidFuel()
	{
		ContentType = CargoContainerContentType.LiquidFuel;
	}

	public CargoLiquidFuel(short theType, float theQuantity)
	{
		FuelType = (FuelRec._FuelType)theType;
		CurrentQuantity = theQuantity;
	}

	public CargoLiquidFuel(CargoLiquidFuel Copyme)
		: base(Copyme)
	{
		FuelType = Copyme.FuelType;
		CurrentQuantity = Copyme.CurrentQuantity;
	}

	public override bool TransferToUnit(ActiveUnit UnloadingUnit, ActiveUnit DestinationUnit, Cargo Cargo = null, float Quantity = 0f)
	{
		FuelRec fuelRec = null;
		List<FuelRec> list = DestinationUnit.Fuel_ReadOnly.ToList();
		if (Quantity == 0f || Quantity > CurrentQuantity)
		{
			Quantity = CurrentQuantity;
		}
		float massForVolume = GetMassForVolume(Quantity);
		foreach (FuelRec item in list)
		{
			if (item.FuelType == FuelType)
			{
				fuelRec = item;
				break;
			}
		}
		if (fuelRec == null && DestinationUnit.IsFixedFacility)
		{
			fuelRec = new FuelRec(0, (short)FuelType);
			DestinationUnit.AddFuelRec(fuelRec);
		}
		if (fuelRec != null)
		{
			fuelRec.AddFuel(massForVolume);
			if (fuelRec.CurrentQuantity > (float)fuelRec.MaxQuantity)
			{
				if (DestinationUnit.IsFixedFacility)
				{
					fuelRec.MaxQuantity = (int)Math.Round(fuelRec.CurrentQuantity) + 1;
				}
				else
				{
					float fuelMass = fuelRec.CurrentQuantity - (float)fuelRec.MaxQuantity;
					Quantity = GetVolumeForMass(fuelMass);
					fuelRec.CurrentQuantity = fuelRec.MaxQuantity;
				}
			}
			CurrentQuantity -= Quantity;
			return true;
		}
		return false;
	}

	public override bool TransferFromUnit(CargoContainer theContainer, ActiveUnit FromUnit, Cargo Cargo = null, float Quantity = 0f)
	{
		List<FuelRec> list = FromUnit.Fuel_ReadOnly.ToList();
		if (Quantity == 0f || Quantity > CurrentQuantity)
		{
			Quantity = CurrentQuantity;
		}
		GetMassForVolume(Quantity);
		foreach (FuelRec item in list)
		{
			if (item.FuelType == FuelType)
			{
				item.CurrentQuantity -= Quantity;
				if (!(item.CurrentQuantity < 0f))
				{
					Quantity = 0f;
					break;
				}
				Quantity = -1f * item.CurrentQuantity;
				item.CurrentQuantity = 0f;
			}
		}
		if (Quantity > 0f)
		{
			CurrentQuantity -= Quantity;
		}
		if (CurrentQuantity > 0f)
		{
			return true;
		}
		return false;
	}

	public override float GetRequiredMass()
	{
		float num = CurrentQuantity / 1000f;
		return FuelType switch
		{
			FuelRec._FuelType.DieselFuel => num * 0.85f, 
			FuelRec._FuelType.OilFuel => num * 0.875f, 
			FuelRec._FuelType.GasFuel => num * 0.875f, 
			FuelRec._FuelType.Gasoline => num * 0.75f, 
			FuelRec._FuelType.AviationFuel => num * 0.8f, 
			_ => num, 
		};
	}

	public override string GetCargoName()
	{
		switch (FuelType)
		{
		case FuelRec._FuelType.DieselFuel:
			Name = "Diesel Fuel";
			break;
		case FuelRec._FuelType.OilFuel:
			Name = "Oil Fuel";
			break;
		case FuelRec._FuelType.GasFuel:
			Name = "Gas Fuel";
			break;
		case FuelRec._FuelType.Gasoline:
			Name = "Gasoline";
			break;
		case FuelRec._FuelType.AviationFuel:
			Name = "Aviation Fuel";
			break;
		}
		int num = (int)Math.Round(CurrentQuantity);
		if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
		{
			num = (int)Math.Round(Cargo.DisplayValueLiquidVolume(CurrentQuantity, USUnits: true));
			Name = Name + " (" + num + " gallons)";
		}
		else
		{
			Name = Name + " (" + num + " liters)";
		}
		return Name;
	}

	public override int GetCargoQuantity()
	{
		return (int)Math.Round(CurrentQuantity + 0.5f);
	}

	public override bool isMatch(Cargo c)
	{
		int result;
		if (c.CargoObjectContainerContents != null)
		{
			if (c.CargoObjectContainerContents.ContentType == CargoContainerContentType.LiquidFuel && ((CargoLiquidFuel)c.CargoObjectContainerContents).FuelType == FuelType)
			{
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public override bool isMatch(CargoContainerContent c)
	{
		if (c.ContentType == CargoContainerContentType.LiquidFuel && ((CargoLiquidFuel)c).FuelType == FuelType)
		{
			return true;
		}
		return false;
	}

	public override bool isExactMatch(CargoContainerContent c)
	{
		if (c.ContentType == CargoContainerContentType.LiquidFuel)
		{
			CargoLiquidFuel cargoLiquidFuel = (CargoLiquidFuel)c;
			if (cargoLiquidFuel.FuelType == FuelType && cargoLiquidFuel.CurrentQuantity == CurrentQuantity)
			{
				return true;
			}
		}
		return false;
	}

	public override float GetQuantityDifference(CargoContainerContent c)
	{
		if (!isMatch(c))
		{
			return 0f;
		}
		return CurrentQuantity - ((CargoLiquidFuel)c).CurrentQuantity;
	}

	public override void SetQuantity(float theQuantity)
	{
		CurrentQuantity = theQuantity;
	}

	internal string SubclassToXML(HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		string[] obj = new string[5] { "<FT>", null, null, null, null };
		int fuelType = (int)FuelType;
		obj[1] = fuelType.ToString();
		obj[2] = "</FT><CQ>";
		obj[3] = XmlConvert.ToString(CurrentQuantity);
		obj[4] = "</CQ>";
		return string.Concat(obj);
	}

	public void SubclassFromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		foreach (XmlNode childNode in theNode.ChildNodes)
		{
			XmlNode val = childNode;
			try
			{
				string name = val.Name;
				if (Operators.CompareString(name, "FT", false) == 0)
				{
					FuelType = (FuelRec._FuelType)Conversions.ToShort(val.InnerText);
				}
				else if (Operators.CompareString(name, "CQ", false) == 0)
				{
					CurrentQuantity = XmlConvert.ToSingle(val.InnerText);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	internal float GetVolumeForMass(float fuelMass)
	{
		float result = 0f;
		if (fuelMass > 0f)
		{
			switch (FuelType)
			{
			case FuelRec._FuelType.DieselFuel:
				result = fuelMass / 0.85f;
				break;
			case FuelRec._FuelType.OilFuel:
				result = fuelMass / 0.875f;
				break;
			case FuelRec._FuelType.GasFuel:
				result = fuelMass / 0.875f;
				break;
			case FuelRec._FuelType.Gasoline:
				result = fuelMass / 0.75f;
				break;
			case FuelRec._FuelType.AviationFuel:
				result = fuelMass / 0.8f;
				break;
			}
		}
		return result;
	}

	internal float GetMassForVolume(float fuelVolume)
	{
		float result = 0f;
		if (fuelVolume > 0f)
		{
			switch (FuelType)
			{
			case FuelRec._FuelType.DieselFuel:
				result = fuelVolume * 0.85f;
				break;
			case FuelRec._FuelType.OilFuel:
				result = fuelVolume * 0.875f;
				break;
			case FuelRec._FuelType.GasFuel:
				result = fuelVolume * 0.875f;
				break;
			case FuelRec._FuelType.Gasoline:
				result = fuelVolume * 0.75f;
				break;
			case FuelRec._FuelType.AviationFuel:
				result = fuelVolume * 0.8f;
				break;
			}
		}
		return result;
	}

	static CargoLiquidFuel()
	{
		Class72.smethod_20();
	}
}
