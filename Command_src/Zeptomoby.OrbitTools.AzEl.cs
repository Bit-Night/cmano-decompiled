using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public class AzEl
{
	[CompilerGenerated]
	private double double_0;

	[CompilerGenerated]
	private double double_1;

	public double AzimuthRad
	{
		[CompilerGenerated]
		get
		{
			return double_0;
		}
		[CompilerGenerated]
		private set
		{
			double_0 = value;
		}
	}

	public double AzimuthDeg => Globals.ToDegrees(AzimuthRad);

	public double ElevationRad
	{
		[CompilerGenerated]
		get
		{
			return double_1;
		}
		[CompilerGenerated]
		private set
		{
			double_1 = value;
		}
	}

	public double ElevationDeg => Globals.ToDegrees(ElevationRad);

	public AzEl(double radAzimuth, double radElevation)
	{
		AzimuthRad = radAzimuth;
		ElevationRad = radElevation;
	}

	public virtual string ToString(bool showElevation = true, bool degrees = true)
	{
		string text = "[";
		text = (degrees ? (text + $"AZ {AzimuthDeg,5:F1}") : (text + $"AZ {AzimuthRad,4:F2}"));
		if (showElevation)
		{
			text = ((!degrees) ? (text + $" EL {ElevationRad,5:F2}") : (text + $" EL {ElevationDeg,4:F1}"));
		}
		return text + "]";
	}

	static AzEl()
	{
		Class72.smethod_20();
	}
}
