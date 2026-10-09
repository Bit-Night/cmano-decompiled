using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public class EciTime : Eci
{
	[CompilerGenerated]
	private readonly Julian julian_0;

	public Julian Date
	{
		[CompilerGenerated]
		get
		{
			return julian_0;
		}
	}

	public EciTime(Vector pos, Vector vel, Julian date)
		: base(pos, vel)
	{
		julian_0 = date;
	}

	public EciTime(Eci eci, Julian date)
		: this(eci.Position, eci.Velocity, date)
	{
	}

	public EciTime(Geo geo, Julian date)
		: base(geo, date)
	{
		julian_0 = date;
	}

	public EciTime(GeoTime geo)
		: this(geo, geo.Date)
	{
	}

	public EciTime(Ecf ecf, Julian date)
		: base(ecf, date)
	{
		julian_0 = date;
	}

	public EciTime(EcfTime ecf)
		: this(ecf, ecf.Date)
	{
	}

	static EciTime()
	{
		Class72.smethod_20();
	}
}
