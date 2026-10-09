using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class DLZCAche
{
	public string FiringUnit_ID;

	public int Weapon_Id;

	public double FiringUnit_Lat;

	public double FiringUnit_Lon;

	public double Target_Lat;

	public double Target_Lon;

	public float Time;

	public ActiveUnit_Weaponry.DLZResultEnum ResultValue;

	public DLZCAche(string firingUnit_ID, int weapon_Id, double firingUnit_Lat, double firingUnit_Lon, double target_Lat, double target_Lon, float time, ActiveUnit_Weaponry.DLZResultEnum resultValue)
	{
		FiringUnit_ID = firingUnit_ID;
		Weapon_Id = weapon_Id;
		FiringUnit_Lat = firingUnit_Lat;
		FiringUnit_Lon = firingUnit_Lon;
		Target_Lat = target_Lat;
		Target_Lon = target_Lon;
		Time = time;
		ResultValue = resultValue;
	}

	public DLZCAche()
	{
		FiringUnit_ID = "";
		Weapon_Id = 0;
		FiringUnit_Lat = 0.0;
		FiringUnit_Lon = 0.0;
		Target_Lat = 0.0;
		Target_Lon = 0.0;
		Time = 0f;
		ResultValue = ActiveUnit_Weaponry.DLZResultEnum.None;
	}

	internal bool RenewNeeded(DLZCAche OldValue, DLZCAche NewValue)
	{
		if (Math.Abs(OldValue.FiringUnit_Lat - NewValue.FiringUnit_Lat) < (double)ActiveUnit_Weaponry.DLZ_Nm_tolerance && Math.Abs(OldValue.FiringUnit_Lon - NewValue.FiringUnit_Lon) < (double)ActiveUnit_Weaponry.DLZ_Nm_tolerance && Math.Abs(OldValue.Target_Lon - NewValue.Target_Lon) < (double)ActiveUnit_Weaponry.DLZ_Nm_tolerance && Math.Abs(OldValue.Target_Lat - NewValue.Target_Lat) < (double)ActiveUnit_Weaponry.DLZ_Nm_tolerance)
		{
			return false;
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		DLZCAche dLZCAche = (DLZCAche)obj;
		if (Weapon_Id == dLZCAche.Weapon_Id && Operators.CompareString(FiringUnit_ID, dLZCAche.FiringUnit_ID, false) == 0 && Target_Lat == dLZCAche.Target_Lat)
		{
			return Target_Lon == dLZCAche.Target_Lon;
		}
		return false;
	}

	static DLZCAche()
	{
		Class72.smethod_20();
	}
}
