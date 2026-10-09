using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public sealed class GeoTime : Geo
{
	[CompilerGenerated]
	private Julian julian_0;

	public Julian Date
	{
		[CompilerGenerated]
		get
		{
			return julian_0;
		}
		[CompilerGenerated]
		private set
		{
			julian_0 = value;
		}
	}

	public GeoTime(double radLat, double radLon, double kmAlt, Julian date, WgsModel ellipsoid)
		: base(radLat, radLon, kmAlt, ellipsoid)
	{
		Date = date;
	}

	public GeoTime(Geo geo, Julian date)
		: base(geo)
	{
		Date = date;
	}

	public GeoTime(EciTime eci, WgsModel ellipsoid)
		: base(eci, eci.Date, ellipsoid)
	{
		Date = eci.Date;
	}

	public GeoTime(Eci eci, Julian date, WgsModel ellipsoid)
		: base(eci, date, ellipsoid)
	{
		Date = date;
	}

	public GeoTime(Ecf ecf, Julian date)
		: base(ecf)
	{
		Date = date;
	}

	public GeoTime(EcfTime ecf)
		: this(ecf, ecf.Date)
	{
	}

	static GeoTime()
	{
		Class72.smethod_20();
	}
}
