using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public class Wgs72 : WgsModel
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

	public override double J2 => 0.0010826158;

	public override double J3 => -2.53881E-06;

	public override double J4 => -1.65597E-06;

	public override double F => 0.003352779454167505;

	public Wgs72()
		: base(398600.8, 6378.135)
	{
	}

	static Wgs72()
	{
		Class72.smethod_20();
		wgsModel_0 = new Wgs72();
	}
}
