using System.Collections.Generic;
using System.Linq;

namespace Command_Core;

public class TransportWave
{
	public Transport AssociatedTransport;

	public Dictionary<ChalkUnit, ChalkUnit> UnitsInWave;

	public int Wave;

	public CargoMission AssociatedMission;

	public bool IsFirstWave;

	public bool Complete;

	public LandingZoneWrapper LandingZone;

	public TransportWave(Transport _AssociatedTransport, int _Wave, LandingZoneWrapper _LandingZone)
	{
		UnitsInWave = new Dictionary<ChalkUnit, ChalkUnit>();
		LandingZone = _LandingZone;
		AssociatedTransport = _AssociatedTransport;
		Wave = _Wave;
	}

	internal AddCargoReturnValue TryAddCargo(Chalk ChalkToAdd, LandingZoneWrapper TheLandingZone, Dictionary<Chalk, List<UnitLineWrapper>> ChalkContainer)
	{
		if (!Complete)
		{
			float num = AssociatedTransport.AreaCapacity - GetAreaTaken();
			float num2 = AssociatedTransport.MassCapacity - GetMassTaken();
			float num3 = AssociatedTransport.CrewCapacity - GetCrewTaken();
			string transportErrorMessage = "";
			AddCargoReturnValue addCargoReturnValue;
			if (ChalkToAdd.GetLargestCargo() > AssociatedTransport.MaxSize)
			{
				transportErrorMessage = "Exceeds max cargo size";
				addCargoReturnValue = AddCargoReturnValue.Impossible;
			}
			else if (ChalkToAdd.GetCrew() > AssociatedTransport.CrewCapacity)
			{
				transportErrorMessage = "Exceeds max PAX";
				addCargoReturnValue = AddCargoReturnValue.Impossible;
			}
			else if (ChalkToAdd.GetArea() > AssociatedTransport.AreaCapacity)
			{
				transportErrorMessage = "Exceeds max area";
				addCargoReturnValue = AddCargoReturnValue.Impossible;
			}
			else if (ChalkToAdd.GetMass() > AssociatedTransport.MassCapacity)
			{
				transportErrorMessage = "Exceeds max mass";
				addCargoReturnValue = AddCargoReturnValue.Impossible;
			}
			else
			{
				addCargoReturnValue = AddCargoReturnValue.Success;
			}
			if (addCargoReturnValue != AddCargoReturnValue.Impossible)
			{
				int result;
				if (TheLandingZone == LandingZone && !(ChalkToAdd.GetArea() > num) && !(ChalkToAdd.GetCrew() > num3))
				{
					if (!(ChalkToAdd.GetMass() > num2))
					{
						foreach (UnitLineWrapper item in ChalkContainer[ChalkToAdd])
						{
							if (!UnitsInWave.ContainsKey(item.ChalkUnit))
							{
								item.ChalkUnit.TransportErrorMessage = transportErrorMessage;
								UnitsInWave.Add(item.ChalkUnit, item.ChalkUnit);
								item.ChalkUnit.CurrentTransport = AssociatedTransport;
								item.ChalkUnit.Wave = Wave;
							}
						}
						return AddCargoReturnValue.Success;
					}
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (AddCargoReturnValue)result;
			}
			foreach (UnitLineWrapper item2 in ChalkContainer[ChalkToAdd])
			{
				item2.ChalkUnit.TransportErrorMessage = transportErrorMessage;
			}
			return AddCargoReturnValue.Impossible;
		}
		return AddCargoReturnValue.CurrentlyImpossible;
	}

	internal AddCargoReturnValue TryAddCargo(ChalkUnit CargoToAdd)
	{
		if (!Complete)
		{
			float num = AssociatedTransport.AreaCapacity - GetAreaTaken();
			float num2 = AssociatedTransport.MassCapacity - GetMassTaken();
			float num3 = AssociatedTransport.CrewCapacity - GetCrewTaken();
			CargoToAdd.TransportErrorMessage = "";
			if (CargoToAdd.Unit.RequiredCargoType > AssociatedTransport.MaxSize)
			{
				CargoToAdd.TransportErrorMessage = "Exceeds max cargo size";
				return AddCargoReturnValue.Impossible;
			}
			if (CargoToAdd.Unit.RequiredCrewSpace > AssociatedTransport.CrewCapacity)
			{
				CargoToAdd.TransportErrorMessage = "Exceeds max PAX";
				return AddCargoReturnValue.Impossible;
			}
			if (CargoToAdd.Unit.RequiredArea > AssociatedTransport.AreaCapacity)
			{
				CargoToAdd.TransportErrorMessage = "Exceeds max area";
				return AddCargoReturnValue.Impossible;
			}
			if (CargoToAdd.Unit.RequiredMass > AssociatedTransport.MassCapacity)
			{
				CargoToAdd.TransportErrorMessage = "Exceeds max mass";
				return AddCargoReturnValue.Impossible;
			}
			int result;
			if (CargoToAdd.LandingZone == LandingZone && !(CargoToAdd.Unit.RequiredArea > num) && !(CargoToAdd.Unit.RequiredCrewSpace > num3))
			{
				if (CargoToAdd.Unit.RequiredMass <= num2)
				{
					if (UnitsInWave.ContainsKey(CargoToAdd))
					{
						return AddCargoReturnValue.Impossible;
					}
					UnitsInWave.Add(CargoToAdd, CargoToAdd);
					CargoToAdd.CurrentTransport = AssociatedTransport;
					CargoToAdd.Wave = Wave;
					return AddCargoReturnValue.Success;
				}
				result = 1;
			}
			else
			{
				result = 1;
			}
			return (AddCargoReturnValue)result;
		}
		return AddCargoReturnValue.CurrentlyImpossible;
	}

	internal Zone GetLandingZone()
	{
		if (UnitsInWave.Count == 0)
		{
			return null;
		}
		return UnitsInWave.Keys.ElementAt(0).LandingZone.LandingZone;
	}

	internal float GetAreaTaken()
	{
		float num = 0f;
		foreach (KeyValuePair<ChalkUnit, ChalkUnit> item in UnitsInWave)
		{
			num += item.Value.Unit.RequiredArea;
		}
		return num;
	}

	internal float GetMassTaken()
	{
		float num = 0f;
		foreach (KeyValuePair<ChalkUnit, ChalkUnit> item in UnitsInWave)
		{
			num += item.Value.Unit.RequiredMass;
		}
		return num;
	}

	internal float GetCrewTaken()
	{
		float num = 0f;
		foreach (KeyValuePair<ChalkUnit, ChalkUnit> item in UnitsInWave)
		{
			num += item.Value.Unit.RequiredCrewSpace;
		}
		return num;
	}

	static TransportWave()
	{
		Class72.smethod_20();
	}
}
