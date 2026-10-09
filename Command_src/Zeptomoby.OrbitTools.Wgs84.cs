using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public class Wgs84 : WgsModel
{
	[CompilerGenerated]
	private static readonly WgsModel wgsModel_0;

	public static WgsModel Ellipsoid
	{
		[CompilerGenerated]
		get
		{
			return wgsModel_0;
		}
	}

	public override double J2 => 0.00108262998905;

	public override double J3 => -2.53215306E-06;

	public override double J4 => -1.61098761E-06;

	public override double F => 0.0033528106647474805;

	public Wgs84()
		: base(398600.5, 6378.137)
	{
	}

	static Wgs84()
	{
		Class72.smethod_20();
		wgsModel_0 = new Wgs84();
	}
}
