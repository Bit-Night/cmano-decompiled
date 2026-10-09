namespace Command_Core;

public sealed class UnitExporterState
{
	public Geopoint_Struct Location;

	public float Heading;

	public float Pitch;

	public ActiveUnit._ActiveUnitStatus status;

	public Aircraft_AirOps._AirOpsCondition? AirOps;

	public ActiveUnit_DockingOps._DockingOpsCondition? DockOps;

	public Mission AssignedMission;

	public float? DamagePercentage;

	public ActiveUnit_Damage.FireIntensityLevel? Fire;

	public ActiveUnit_Damage.FloodingIntensityLevel? Flood;

	public UnitExporterState(Module_Unit.Unit TheUnit)
	{
		Location = new Geopoint_Struct(TheUnit.get_Longitude((GlobalVariables.BooleanObject)null), TheUnit.get_Latitude((GlobalVariables.BooleanObject)null), TheUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		Heading = TheUnit.CurrentHeading;
		Pitch = TheUnit.Attitude_Pitch;
		if (!TheUnit.IsActiveUnit)
		{
			status = ActiveUnit._ActiveUnitStatus.Unassigned;
			DamagePercentage = null;
			Fire = null;
			Flood = null;
			DockOps = null;
		}
		else
		{
			ActiveUnit activeUnit = (ActiveUnit)TheUnit;
			status = activeUnit.Status;
			DamagePercentage = activeUnit.Damage.DamagePercent;
			Fire = activeUnit.Damage.FireIntensity;
			Flood = activeUnit.Damage.FloodIntensity;
			DockOps = activeUnit.DockingOps.Condition;
		}
		if (!TheUnit.IsAircraft)
		{
			AirOps = null;
			return;
		}
		Aircraft aircraft = (Aircraft)TheUnit;
		AirOps = aircraft.AirOps.Condition;
	}

	internal bool IsEqual(Module_Unit.Unit CurrentUnit)
	{
		if (CurrentUnit.get_Longitude(GlobalVariables.ObjectTrue) != Location.Longitude)
		{
			return false;
		}
		if (CurrentUnit.get_Latitude(GlobalVariables.ObjectTrue) != Location.Latitude)
		{
			return false;
		}
		if (CurrentUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) != Location.Altitude)
		{
			return false;
		}
		if (CurrentUnit.CurrentHeading != Heading)
		{
			return false;
		}
		if (CurrentUnit.Attitude_Pitch != Pitch)
		{
			return false;
		}
		if (CurrentUnit.IsAircraft)
		{
			byte condition = (byte)((Aircraft)CurrentUnit).AirOps.Condition;
			byte? b = (byte?)AirOps;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(condition != b.GetValueOrDefault())) == true)
			{
				return false;
			}
		}
		int result;
		if (!CurrentUnit.IsActiveUnit)
		{
			result = 1;
		}
		else
		{
			ActiveUnit activeUnit = (ActiveUnit)CurrentUnit;
			if (activeUnit.Status != status)
			{
				return false;
			}
			byte condition = (byte)activeUnit.DockingOps.Condition;
			byte? b = (byte?)DockOps;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(condition != b.GetValueOrDefault())) == true)
			{
				return false;
			}
			float damagePercent = activeUnit.Damage.DamagePercent;
			float? damagePercentage = DamagePercentage;
			if (((!damagePercentage.HasValue) ? ((bool?)null) : new bool?(damagePercent != damagePercentage.GetValueOrDefault())) == true)
			{
				return false;
			}
			condition = (byte)activeUnit.Damage.FireIntensity;
			b = (byte?)Fire;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(condition != b.GetValueOrDefault())) == true)
			{
				return false;
			}
			condition = (byte)activeUnit.Damage.FloodIntensity;
			b = (byte?)Flood;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(condition != b.GetValueOrDefault())) == true)
			{
				return false;
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	static UnitExporterState()
	{
		Class72.smethod_20();
	}
}
