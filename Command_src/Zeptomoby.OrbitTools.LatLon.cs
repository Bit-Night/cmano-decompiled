using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public class LatLon
{
	[CompilerGenerated]
	private double double_0;

	[CompilerGenerated]
	private double double_1;

	public double LatitudeRad
	{
		[CompilerGenerated]
		get
		{
			return double_0;
		}
		[CompilerGenerated]
		protected set
		{
			double_0 = value;
		}
	}

	public double LongitudeRad
	{
		[CompilerGenerated]
		get
		{
			return double_1;
		}
		[CompilerGenerated]
		protected set
		{
			double_1 = value;
		}
	}

	public double LatitudeDeg => Globals.ToDegrees(LatitudeRad);

	public double LongitudeDeg => Globals.ToDegrees(LongitudeRad);

	public LatLon(double radLat, double radLon)
	{
		LatitudeRad = radLat;
		LongitudeRad = radLon;
	}

	static LatLon()
	{
		Class72.smethod_20();
	}
}
