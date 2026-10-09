using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Text;

namespace Command_Core;

public sealed class CargoHostHelper
{
	public static string c0000;

	public static string c1000;

	public static string c2000;

	public static string c3000;

	public static string c4000;

	public static string c5000;

	static CargoHostHelper()
	{
		Class72.smethod_20();
		c0000 = "Not Cargo Capable";
		c1000 = "Personnel (Squads, MANPADS, ATGM)";
		c2000 = "Small Cargo (Cars, AAA Guns)";
		c3000 = "Medium Cargo (APC, Towed Arty)";
		c4000 = "Large Cargo (Tank, TEL, Trailer)";
		c5000 = "Very Large Cargo (IRBM / ICBM TEL)";
	}

	public static string TroopCapacityString(ICargoHost ch)
	{
		if (ch.GetCargo_Type() != CargoType.NoCargo)
		{
			if (ch.GetCargo_Crew() == 0f)
			{
				return "None";
			}
			return ch.GetCargo_Crew() + " troops";
		}
		return "None";
	}

	public static string CargoCapacityString(ICargoHost ch)
	{
		if (ch.GetCargo_Type() != CargoType.NoCargo)
		{
			StringBuilder stringBuilder = StringBuilderCache.Allocate();
			stringBuilder.Clear();
			if (ch.GetCargo_Type() == CargoType.Personnel)
			{
				stringBuilder.Append(c1000);
			}
			else if (ch.GetCargo_Type() == CargoType.SmallCargo)
			{
				stringBuilder.Append(c2000);
			}
			else if (ch.GetCargo_Type() == CargoType.MediumCargo)
			{
				stringBuilder.Append(c3000);
			}
			else if (ch.GetCargo_Type() == CargoType.LargeCargo)
			{
				stringBuilder.Append(c4000);
			}
			else if (ch.GetCargo_Type() == CargoType.const_5)
			{
				stringBuilder.Append(c5000);
			}
			stringBuilder.Append("<br/>");
			stringBuilder.Append("Mass: ").Append(ch.GetCargo_Mass()).Append(" tons. ");
			stringBuilder.Append("<br/>");
			stringBuilder.Append("Area: ").Append(ch.GetCargo_Area()).Append(" sq m. ");
			string result = stringBuilder.ToString();
			StringBuilderCache.Free(stringBuilder);
			return result;
		}
		return "None";
	}

	public static float GetAvailableMass(ICargoHost Host, Cargo[] currentCargo)
	{
		float num = Host.GetCargo_Mass();
		if (currentCargo != null)
		{
			foreach (Cargo cargo in currentCargo)
			{
				num -= cargo.RequiredMass;
			}
		}
		return num;
	}

	public static float GetAvailableCrewSpace(ICargoHost Host, Cargo[] currentCargo)
	{
		float num = Host.GetCargo_Crew();
		if (currentCargo != null)
		{
			foreach (Cargo cargo in currentCargo)
			{
				num -= cargo.RequiredCrewSpace;
			}
		}
		return num;
	}

	public static float GetAvailableArea(ICargoHost Host, Cargo[] currentCargo)
	{
		float num = Host.GetCargo_Area();
		if (currentCargo != null)
		{
			foreach (Cargo cargo in currentCargo)
			{
				num -= cargo.RequiredArea;
			}
		}
		return num;
	}

	public static float GetCurrentLoadTotalMass(ICargoHost Host, Cargo[] currentCargo)
	{
		float num = 0f;
		if (currentCargo != null)
		{
			foreach (Cargo cargo in currentCargo)
			{
				num += cargo.RequiredMass;
			}
		}
		return num;
	}

	public static float GetCurrentLoadTotalCrewSpace(ICargoHost Host, Cargo[] currentCargo)
	{
		float num = 0f;
		if (currentCargo != null)
		{
			foreach (Cargo cargo in currentCargo)
			{
				num += cargo.RequiredCrewSpace;
			}
		}
		return num;
	}

	public static bool CanLoad(ICargoHost Host, Cargo[] CurrentCargo, ICargoClient PotentialCargo)
	{
		if (PotentialCargo.GetRequiredCargoType() <= Host.GetCargo_Type())
		{
			float num = Host.GetCargo_Mass();
			float num2 = Host.GetCargo_Area();
			float num3 = Host.GetCargo_Crew();
			bool flag = Host.CanStackCargo() && PotentialCargo.IsStackable() && Host.GetCargo_Height() >= 2f * PotentialCargo.GetRequiredHeight();
			int num4 = 0;
			if (CurrentCargo != null)
			{
				foreach (Cargo cargo in CurrentCargo)
				{
					num -= cargo.RequiredMass;
					num3 -= cargo.RequiredCrewSpace;
					if (flag && PotentialCargo.isMatch(cargo))
					{
						num4 += cargo.CargoObjectQuantity;
					}
					else
					{
						num2 -= cargo.RequiredArea;
					}
				}
			}
			if (num >= PotentialCargo.GetRequiredMass() && num3 >= PotentialCargo.GetRequiredCrewSpace())
			{
				float num5 = PotentialCargo.GetRequiredArea();
				if (flag)
				{
					num5 = PotentialCargo.GetRequiredAreaStacked(Host, num4 + PotentialCargo.GetCargoQuantity());
				}
				if (num2 >= num5)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool Add(ICargoHost Host, Cargo c)
	{
		if (Host.CargoArray.Contains(c))
		{
			return false;
		}
		Cargo[] theArray = Host.CargoArray;
		ArrayExtensions.Add(ref theArray, c);
		Host.CargoArray = theArray;
		return true;
	}

	public static bool Remove(ICargoHost Host, Cargo c)
	{
		if (Host.CargoArray.Contains(c))
		{
			Cargo[] theArray = Host.CargoArray;
			ArrayExtensions.Remove(ref theArray, c);
			Host.CargoArray = theArray;
			return true;
		}
		return false;
	}

	public static Cargo GetTowedCargo(ICargoHost Host)
	{
		Cargo[] cargoArray = Host.CargoArray;
		foreach (Cargo cargo in cargoArray)
		{
			if (cargo.StorageType == Cargo.CargoStorageType.TowedExternal)
			{
				return cargo;
			}
		}
		return null;
	}

	public static int GetPercentFull(ICargoHost Host)
	{
		int num = 0;
		if (Host.CargoArray.Count() > 0)
		{
			int num2 = (int)Math.Round(100f * (1f - GetAvailableMass(Host, Host.CargoArray) / Host.GetCargo_Mass()));
			num = num2;
			if (num < 100)
			{
				num2 = (int)Math.Round(100f * (1f - GetAvailableCrewSpace(Host, Host.CargoArray) / Host.GetCargo_Crew()));
				if (num2 > num)
				{
					num = num2;
				}
				if (num < 100)
				{
					num2 = (int)Math.Round(100f * (1f - GetAvailableArea(Host, Host.CargoArray) / Host.GetCargo_Area()));
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
		}
		return num;
	}

	public static string CanUnloadUnitAtPresentPosition(ActiveUnit Host, Cargo unloadCargo)
	{
		if (Host.DockingOps.CurrentHostUnit == null)
		{
			if (Host.IsAircraft && ((Aircraft)Host).AirOps.CurrentHostUnit != null)
			{
				return "Use the Air Ops window to transfer cargo for hosted aircraft.";
			}
			if (Host.OnboardCargo.Contains(unloadCargo))
			{
				bool flag = Module_Unit.IsOverLand(Host);
				if (Host.IsAircraft)
				{
					if (flag)
					{
						Aircraft aircraft = (Aircraft)Host;
						if (!aircraft.IsHelicopter)
						{
							if (aircraft.GetCargo_ParadropCapable())
							{
								if (!unloadCargo.isParadropCapable)
								{
									return "This aircraft can paradrop cargo but the specified cargo item cannot be paradropped.";
								}
								return "Ok";
							}
							return "This aircraft's current loadout cannot paradrop cargo.";
						}
						return "Ok";
					}
					return "Aircraft must be over land to unload cargo.";
				}
				if (Host.IsFixedFacility)
				{
					if (!flag)
					{
						return "Facilities must be on land to unload cargo.";
					}
					return "Ok";
				}
				if (Host.IsVehicle)
				{
					if (!flag)
					{
						return "Vehicles must be on land to unload cargo.";
					}
					return "Ok";
				}
				if (Host.IsShip)
				{
					ActiveUnit cargoObjectActiveUnit = unloadCargo.CargoObjectActiveUnit;
					if (((Ship)Host).Flags.CanLaunchCargoDirectlyToSea && cargoObjectActiveUnit.IsVehicle && ((Vehicle)cargoObjectActiveUnit).IsAmphibiousSeaworthy)
					{
						return "Ok";
					}
					if (Host.DockingOps.CanUnloadCargoOverBeach())
					{
						if (Host.DockingOps.FindPossibleUnloadLocations().Count == 0)
						{
							return "This ship can unload cargo to shore but is currently too far from shore (beyond 2nm.)";
						}
						return "Ok";
					}
					if (Host.DockFacilities_ReadOnly.Count() > 0 && cargoObjectActiveUnit.IsVehicle && ((Vehicle)cargoObjectActiveUnit).IsAmphibiousSeaworthy)
					{
						Vehicle vehicle = (Vehicle)cargoObjectActiveUnit;
						if (Host.DockingOps.CanHostThisBoat((short)Math.Round(vehicle.Length), vehicle.DockingPhysicalSize) != DockingOpsAttemptResult.Success)
						{
							return "This ship does not have any docking facilities that can host that amphibious vehicle. Dock at a port facility to unload it.";
						}
						ActiveUnit_DockingOps dockingOps = Host.DockingOps;
						DockFacility bestFacility = null;
						if (!dockingOps.CanHostThisBoat(cargoObjectActiveUnit, ref bestFacility))
						{
							return "All of this ship's docking facilities that can host that amphibious vehicle are full.";
						}
						return "Ok";
					}
					return "Host ship must dock at a port facility to unload the specified cargo item.";
				}
			}
			return "Host unit cannot unload cargo at present location.";
		}
		return "Use the Docking Ops window to transfer cargo for docked units.";
	}

	public static Cargo FindMatchingCargo(List<Cargo> theCargoList, CargoManifestItem theManifestItem)
	{
		if (theCargoList == null || theManifestItem == null)
		{
			return null;
		}
		foreach (Cargo theCargo in theCargoList)
		{
			if (theManifestItem.IsMatch(theCargo))
			{
				return theCargo;
			}
		}
		return null;
	}
}
