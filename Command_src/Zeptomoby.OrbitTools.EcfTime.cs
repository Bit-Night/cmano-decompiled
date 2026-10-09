using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public class EcfTime : Ecf
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
		protected set
		{
			julian_0 = value;
		}
	}

	public EcfTime(Vector pos, Vector vel, Julian date, WgsModel ellipsoid)
		: base(pos, vel, ellipsoid)
	{
		Date = date;
	}

	public EcfTime(Ecf ecf, Julian date)
		: base(ecf)
	{
		Date = date;
	}

	public EcfTime(Eci eci, Julian date, WgsModel ellipsoid)
		: base(eci, date, ellipsoid)
	{
		Date = date;
	}

	public EcfTime(EciTime eci, WgsModel ellipsoid)
		: this(eci, eci.Date, ellipsoid)
	{
	}

	public EcfTime(Geo geo, Julian date)
		: base(geo)
	{
		Date = date;
	}

	public EcfTime(GeoTime geo)
		: this(geo, geo.Date)
	{
	}

	static EcfTime()
	{
		Class72.smethod_20();
	}
}
