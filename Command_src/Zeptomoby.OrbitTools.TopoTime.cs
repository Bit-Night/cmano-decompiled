using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public sealed class TopoTime : Topo
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

	public TopoTime(Topo topo, Julian date)
		: base(topo.AzimuthRad, topo.ElevationRad, topo.Range, topo.RangeRate)
	{
		Date = date;
	}

	public TopoTime(double radAz, double radEl, double range, double rangeRate, Julian date)
		: base(radAz, radEl, range, rangeRate)
	{
		Date = date;
	}

	static TopoTime()
	{
		Class72.smethod_20();
	}
}
