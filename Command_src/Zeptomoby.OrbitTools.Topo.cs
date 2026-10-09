using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public class Topo : AzEl
{
	[CompilerGenerated]
	private double double_2;

	[CompilerGenerated]
	private double double_3;

	public double Range
	{
		[CompilerGenerated]
		get
		{
			return double_2;
		}
		[CompilerGenerated]
		set
		{
			double_2 = value;
		}
	}

	public double RangeRate
	{
		[CompilerGenerated]
		get
		{
			return double_3;
		}
		[CompilerGenerated]
		set
		{
			double_3 = value;
		}
	}

	public Topo(double radAzimuth, double radElevation, double kmRange, double kpsRangeRate)
		: base(radAzimuth, radElevation)
	{
		Range = kmRange;
		RangeRate = kpsRangeRate;
	}

	static Topo()
	{
		Class72.smethod_20();
	}
}
