using System.Collections.Generic;

namespace Command_Core;

public sealed class DLZResultData
{
	public List<TrajectoryPoint> TargetFutureBallisticPath;

	public List<GStruct0> WeaponTrack;

	public List<GStruct0> TargetFutureBallisticTrack;

	public List<GStruct0> TargetTrack;

	public List<GStruct0> InterceptPointTrack;

	public DLZResultData()
	{
		WeaponTrack = new List<GStruct0>();
		TargetTrack = new List<GStruct0>();
		InterceptPointTrack = new List<GStruct0>();
	}

	public void InsertData(double time, Weapon theWeapon, Contact theTargetContact, Geopoint_Struct theInterceptPoint)
	{
		InterceptPointTrack.Add(new GStruct0
		{
			Alt = theInterceptPoint.Altitude,
			Lat = theInterceptPoint.Latitude,
			Lon = theInterceptPoint.Longitude,
			Time = time
		});
		InsertData(time, theWeapon, theTargetContact);
	}

	public void InsertData(double time, Weapon theWeapon, Contact theTargetContact)
	{
		WeaponTrack.Add(new GStruct0
		{
			Alt = theWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null),
			Lat = theWeapon.get_Latitude((GlobalVariables.BooleanObject)null),
			Lon = theWeapon.get_Longitude((GlobalVariables.BooleanObject)null),
			Time = time
		});
		TargetTrack.Add(new GStruct0
		{
			Alt = ((Module_Unit.Unit)theTargetContact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null),
			Lat = ((Module_Unit.Unit)theTargetContact).get_Latitude((GlobalVariables.BooleanObject)null),
			Lon = ((Module_Unit.Unit)theTargetContact).get_Longitude((GlobalVariables.BooleanObject)null),
			Time = time
		});
	}

	static DLZResultData()
	{
		Class72.smethod_20();
	}
}
