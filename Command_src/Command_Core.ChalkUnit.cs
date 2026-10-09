using System.Collections.Generic;

namespace Command_Core;

public class ChalkUnit
{
	public Cargo Unit;

	public Chalk AssociatedChalk;

	public int Priority;

	public LandingZoneWrapper LandingZone;

	public int Wave;

	public Transport CurrentTransport;

	public Dictionary<string, TransportAvailability> TransportAvailable;

	public string TransportErrorMessage;

	public string TransportErrorMessagTooltip;

	public bool IsAmphibious
	{
		get
		{
			if (Unit.CurrentType == Cargo.CargoObjectType.Vehicle && ((Vehicle)Unit.CargoObjectActiveUnit).IsAmphibiousSeaworthy)
			{
				return true;
			}
			return false;
		}
	}

	internal bool IsTransportAllowed(Transport TheTransport)
	{
		if (LandingZone != null)
		{
			if (LandingZone.LandingZoneType != LandingType.Unassigned)
			{
				return TheTransport.LandingType == LandingZone.LandingZoneType;
			}
			return false;
		}
		return false;
	}

	internal bool IsTransportAllowed(ActiveUnit TheTransport)
	{
		if (LandingZone == null)
		{
			return false;
		}
		int num;
		LandingType landingType;
		if (TheTransport.IsBoat)
		{
			num = 1;
		}
		else
		{
			if (!TheTransport.IsShip)
			{
				landingType = (TheTransport.IsAircraft ? LandingType.Airborne : LandingType.Unassigned);
				goto IL_0031;
			}
			num = 1;
		}
		landingType = (LandingType)num;
		goto IL_0031;
		IL_0031:
		if (LandingZone.LandingZoneType != LandingType.Unassigned)
		{
			return landingType == LandingZone.LandingZoneType;
		}
		return false;
	}

	public ChalkUnit(Chalk _tChalk, Cargo _tChalkUnit, int _tPriority, int _tWave, ActiveUnit _tCurrentTransport, bool _isSubEntry, LandingZoneWrapper _LandingZoneWrapper)
	{
		TransportAvailable = new Dictionary<string, TransportAvailability>();
		TransportErrorMessage = "";
		TransportErrorMessagTooltip = "";
		Unit = _tChalkUnit;
		AssociatedChalk = _tChalk;
		Wave = _tWave;
		LandingZone = _LandingZoneWrapper;
	}

	public ChalkUnit(Cargo _tChalkUnit)
	{
		TransportAvailable = new Dictionary<string, TransportAvailability>();
		TransportErrorMessage = "";
		TransportErrorMessagTooltip = "";
		Unit = _tChalkUnit;
	}

	static ChalkUnit()
	{
		Class72.smethod_20();
	}
}
