using System.Collections.Generic;

namespace Command_Core;

public interface ICargoHost
{
	Cargo[] CargoArray { get; set; }

	float GetCargo_Crew();

	float GetCargo_Area();

	CargoType GetCargo_Type();

	float GetCargo_Mass();

	float GetCargo_TowingCapacity();

	bool GetCargo_ParadropCapable();

	int GetLoadTime(List<Cargo> CargoItems);

	int GetUnloadTime(List<Cargo> CargoItems);

	bool CanLoad(ICargoClient PotentialCargo);

	bool CanTow(ICargoClient PotentialCargo);

	bool Add(Cargo c);

	bool Remove(Cargo c);

	float GetCargo_MassAvailable();

	bool CanStackCargo();

	float GetCargo_Height();
}
