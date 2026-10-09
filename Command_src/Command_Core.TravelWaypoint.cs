using System;

namespace Command_Core;

public sealed class TravelWaypoint
{
	public DateTime TimeStamp;

	public Geopoint_Struct position;

	public float CurrentSpeed;

	public float CurrentHeading;

	private float float_0;

	public TravelWaypoint()
	{
	}

	public TravelWaypoint(Geopoint_Struct _GeoPoint, DateTime _DateTime, float _CurrentSpeed, float _CurrentHeading)
	{
		TimeStamp = _DateTime;
		position = _GeoPoint;
		CurrentSpeed = _CurrentSpeed;
		CurrentHeading = _CurrentHeading;
	}

	public void CopyDataToWeapon(ref Weapon UnitToChange)
	{
		UnitToChange.CurrentSpeed = CurrentSpeed;
		UnitToChange.CurrentHeading = CurrentHeading;
		UnitToChange.set_Longitude((GlobalVariables.BooleanObject)null, position.Longitude);
		UnitToChange.set_Latitude((GlobalVariables.BooleanObject)null, position.Latitude);
		UnitToChange.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, position.Altitude);
	}

	public void CopyDataToContact(ref Contact UnitToChange)
	{
		UnitToChange.CurrentSpeed = CurrentSpeed;
		UnitToChange.CurrentHeading = CurrentHeading;
		((Module_Unit.Unit)UnitToChange).set_Longitude((GlobalVariables.BooleanObject)null, position.Longitude);
		((Module_Unit.Unit)UnitToChange).set_Latitude((GlobalVariables.BooleanObject)null, position.Latitude);
		((Module_Unit.Unit)UnitToChange).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, position.Altitude);
	}

	static TravelWaypoint()
	{
		Class72.smethod_20();
	}
}
