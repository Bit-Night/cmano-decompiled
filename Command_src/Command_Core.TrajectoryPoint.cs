using System;

namespace Command_Core;

public struct TrajectoryPoint
{
	public double Longitude;

	public double Latitude;

	public float Altitude;

	public DateTime TimeZulu;

	private long long_0;

	public bool HasZeroCoords
	{
		get
		{
			if (Longitude == 0.0)
			{
				return Latitude == 0.0;
			}
			return false;
		}
	}

	public TrajectoryPoint(double theLon, double theLat, float theAlt, DateTime theTime)
	{
		this = default(TrajectoryPoint);
		Longitude = theLon;
		Latitude = theLat;
		Altitude = theAlt;
		TimeZulu = theTime;
		long_0 = TimeZulu.Ticks;
	}

	internal GeoPoint ToGeoPoint()
	{
		return new GeoPoint(Longitude, Latitude, Altitude);
	}

	internal Geopoint_Struct ToGeoPointStruct()
	{
		return new Geopoint_Struct(Longitude, Latitude, Altitude);
	}

	public ReferencePoint ToReferencePoint()
	{
		return new ReferencePoint(Longitude, Latitude);
	}

	public float RangeToPoint_Horiz(double thePoint_Lon, double thePoint_Lat)
	{
		return Math2.CalcDist(Latitude, Longitude, thePoint_Lat, thePoint_Lon);
	}

	public static TrajectoryPoint Interpolate(TrajectoryPoint PreviousPoint, TrajectoryPoint NextPoint, DateTime theTime)
	{
		TrajectoryPoint result = NextPoint;
		double totalMilliseconds = (NextPoint.TimeZulu - theTime).TotalMilliseconds;
		if (totalMilliseconds < 1.0)
		{
			return NextPoint;
		}
		double totalMilliseconds2 = (NextPoint.TimeZulu - PreviousPoint.TimeZulu).TotalMilliseconds;
		if (totalMilliseconds2 >= totalMilliseconds)
		{
			double num = 1.0 - totalMilliseconds / totalMilliseconds2;
			float bearing = Math2.CalcAzimuth(PreviousPoint.Latitude, PreviousPoint.Longitude, NextPoint.Latitude, NextPoint.Longitude);
			double distance_NM = num * (double)PreviousPoint.RangeToPoint_Horiz(NextPoint.Longitude, NextPoint.Latitude);
			Geodesic_EdWilliams.CalcPoint_Williams(PreviousPoint.Longitude, PreviousPoint.Latitude, ref result.Longitude, ref result.Latitude, distance_NM, bearing);
			result.Altitude = PreviousPoint.Altitude + (float)(num * (double)(NextPoint.Altitude - PreviousPoint.Altitude));
			return result;
		}
		return NextPoint;
	}

	public static TrajectoryPoint? GetExactPointAtTime(TrajectoryPoint[] TrajectoryList, TrajectoryPoint InitialPosition, DateTime theTime)
	{
		TrajectoryPoint previousPoint = InitialPosition;
		long ticks = theTime.Ticks;
		int num = TrajectoryList.Length - 1;
		TrajectoryPoint? result = default(TrajectoryPoint?);
		for (int i = 0; i <= num; i++)
		{
			TrajectoryPoint trajectoryPoint = TrajectoryList[i];
			if (trajectoryPoint.long_0 < ticks)
			{
				previousPoint = trajectoryPoint;
				continue;
			}
			result = Interpolate(previousPoint, trajectoryPoint, theTime);
			break;
		}
		return result;
	}

	static TrajectoryPoint()
	{
		Class72.smethod_20();
	}
}
