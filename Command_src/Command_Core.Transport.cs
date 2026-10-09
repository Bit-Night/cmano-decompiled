using System.Collections.Generic;
using System.Linq;

namespace Command_Core;

public class Transport
{
	public ActiveUnit ActualTransport;

	public float AreaCapacity;

	public float MassCapacity;

	public float CrewCapacity;

	public CargoType MaxSize;

	public float CurrentArea;

	public float CurretMass;

	public float currentCrew;

	public LandingType LandingType;

	public Dictionary<ChalkUnit, ChalkUnit> CurrentCargo;

	public List<TransportWave> Waves;

	internal (float AreaTaken, float MassTaken, float CrewTaken) GetUnitAllocationProportion(ChalkUnit chalkunit)
	{
		float item = 0f;
		if (chalkunit.Unit.RequiredArea != 0f && AreaCapacity != 0f)
		{
			item = chalkunit.Unit.RequiredArea / AreaCapacity;
		}
		float item2 = 0f;
		if (chalkunit.Unit.RequiredMass != 0f && MassCapacity != 0f)
		{
			item2 = chalkunit.Unit.RequiredMass / MassCapacity;
		}
		float item3 = 0f;
		if (chalkunit.Unit.RequiredCrewSpace != 0f && CrewCapacity != 0f)
		{
			item3 = chalkunit.Unit.RequiredCrewSpace / CrewCapacity;
		}
		return (AreaTaken: item, MassTaken: item2, CrewTaken: item3);
	}

	public Transport(ActiveUnit _ActualTransport)
	{
		CurrentCargo = new Dictionary<ChalkUnit, ChalkUnit>();
		Waves = new List<TransportWave>();
		ICargoHost cargoHost = (ICargoHost)_ActualTransport;
		ActualTransport = _ActualTransport;
		AreaCapacity = cargoHost.GetCargo_Area();
		MassCapacity = cargoHost.GetCargo_Mass();
		CrewCapacity = cargoHost.GetCargo_Crew();
		MaxSize = cargoHost.GetCargo_Type();
		if (!_ActualTransport.IsBoat && !_ActualTransport.IsShip)
		{
			if (_ActualTransport.IsAircraft)
			{
				LandingType = LandingType.Airborne;
			}
			else
			{
				LandingType = LandingType.Unassigned;
			}
		}
		else
		{
			LandingType = LandingType.Amphibious;
		}
	}

	internal AddCargoReturnValue AddSerialCargoToTransport(Chalk Serial, LandingZoneWrapper landingZone, Dictionary<Chalk, List<UnitLineWrapper>> ChalkContainer, bool CanAddWave = true, int MaxWaves = -1)
	{
		int num;
		if (Waves.Count != 0)
		{
			num = 2;
		}
		else
		{
			Waves.Add(new TransportWave(this, Waves.Count + 1, landingZone));
			num = 2;
		}
		AddCargoReturnValue addCargoReturnValue = (AddCargoReturnValue)num;
		foreach (TransportWave item in Waves.ToList())
		{
			AddCargoReturnValue addCargoReturnValue2 = item.TryAddCargo(Serial, landingZone, ChalkContainer);
			if (addCargoReturnValue2 == AddCargoReturnValue.CurrentlyImpossible && addCargoReturnValue == AddCargoReturnValue.Impossible)
			{
				addCargoReturnValue = AddCargoReturnValue.CurrentlyImpossible;
			}
			else if (addCargoReturnValue2 == AddCargoReturnValue.Success && addCargoReturnValue != AddCargoReturnValue.Success)
			{
				addCargoReturnValue = AddCargoReturnValue.Success;
				break;
			}
		}
		switch (addCargoReturnValue)
		{
		case AddCargoReturnValue.CurrentlyImpossible:
		{
			int result;
			if (CanAddWave)
			{
				if (Waves.Count < MaxWaves)
				{
					Waves.Add(new TransportWave(this, Waves.Count + 1, landingZone));
					return Waves.ElementAt(Waves.Count - 1).TryAddCargo(Serial, landingZone, ChalkContainer);
				}
				result = 1;
			}
			else
			{
				result = 1;
			}
			return (AddCargoReturnValue)result;
		}
		case AddCargoReturnValue.Impossible:
			return addCargoReturnValue;
		default:
			return AddCargoReturnValue.Impossible;
		case AddCargoReturnValue.Success:
			return addCargoReturnValue;
		}
	}

	internal AddCargoReturnValue AddCargo(ChalkUnit _Cargo, bool CanAddWave = true, int MaxWaves = -1)
	{
		int num;
		if (Waves.Count == 0)
		{
			Waves.Add(new TransportWave(this, Waves.Count + 1, _Cargo.LandingZone));
			num = 2;
		}
		else
		{
			num = 2;
		}
		AddCargoReturnValue addCargoReturnValue = (AddCargoReturnValue)num;
		foreach (TransportWave item in Waves.ToList())
		{
			AddCargoReturnValue addCargoReturnValue2 = item.TryAddCargo(_Cargo);
			if (addCargoReturnValue2 == AddCargoReturnValue.CurrentlyImpossible && addCargoReturnValue == AddCargoReturnValue.Impossible)
			{
				addCargoReturnValue = AddCargoReturnValue.CurrentlyImpossible;
			}
			else if (addCargoReturnValue2 == AddCargoReturnValue.Success && addCargoReturnValue != AddCargoReturnValue.Success)
			{
				addCargoReturnValue = AddCargoReturnValue.Success;
				break;
			}
		}
		switch (addCargoReturnValue)
		{
		case AddCargoReturnValue.CurrentlyImpossible:
			if (CanAddWave && Waves.Count < MaxWaves)
			{
				Waves.Add(new TransportWave(this, Waves.Count + 1, _Cargo.LandingZone));
				return Waves.ElementAt(Waves.Count - 1).TryAddCargo(_Cargo);
			}
			return AddCargoReturnValue.CurrentlyImpossible;
		case AddCargoReturnValue.Impossible:
			return addCargoReturnValue;
		default:
			return AddCargoReturnValue.Impossible;
		case AddCargoReturnValue.Success:
			return addCargoReturnValue;
		}
	}

	public void RemoveCargo(ChalkUnit _Cargo)
	{
		if (CurrentCargo.ContainsKey(_Cargo))
		{
			CurrentCargo.Remove(_Cargo);
		}
	}

	static Transport()
	{
		Class72.smethod_20();
	}
}
