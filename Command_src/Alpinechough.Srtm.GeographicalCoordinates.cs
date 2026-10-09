using System;

namespace Alpinechough.Srtm;

public sealed class GeographicalCoordinates : IGeographicalCoordinates
{
	private double double_0;

	private double double_1;

	public double Latitude
	{
		get
		{
			return double_0;
		}
		set
		{
			if (value < -90.0 || value > 90.0)
			{
				throw new ArgumentOutOfRangeException();
			}
			double_0 = value;
		}
	}

	public double Longitude
	{
		get
		{
			return double_1;
		}
		set
		{
			if (value > 180.0 || value <= -180.0)
			{
				throw new ArgumentOutOfRangeException();
			}
			double_1 = value;
		}
	}

	public GeographicalCoordinates()
	{
	}

	public GeographicalCoordinates(double latitude, double longitude)
	{
		Latitude = latitude;
		Longitude = longitude;
	}

	public GeographicalCoordinates(int latitudeDegrees, int latitudeMinutes, int latitudeSeconds, char latitudeDirection, int longitudeDegrees, int longitudeMinutes, int longitudeSeconds, char longitudeDirection)
		: this(((double)latitudeDegrees + (double)latitudeMinutes / 60.0 + (double)latitudeSeconds / 3600.0) * ((!(latitudeDirection.ToString().ToUpper() == "N")) ? (-1.0) : 1.0), ((double)longitudeDegrees + (double)longitudeMinutes / 60.0 + (double)longitudeSeconds / 3600.0) * ((!(longitudeDirection.ToString().ToUpper() == "W")) ? (-1.0) : 1.0))
	{
		switch (latitudeDirection)
		{
		default:
			throw new ArgumentException();
		case 'N':
		case 'S':
		case 'n':
		case 's':
			switch (longitudeDirection)
			{
			default:
				throw new ArgumentException();
			case 'E':
			case 'W':
			case 'e':
			case 'w':
				break;
			}
			break;
		}
	}

	public GeographicalCoordinates(GeographicalCoordinates geographicalCoordinates)
		: this(geographicalCoordinates.Latitude, geographicalCoordinates.Longitude)
	{
	}

	public override string ToString()
	{
		return $"{Latitude:0.000000}°, {Longitude:0.000000}°";
	}

	static GeographicalCoordinates()
	{
		Class72.smethod_20();
	}
}
