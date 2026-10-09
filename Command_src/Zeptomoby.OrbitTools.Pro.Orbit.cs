using System;
using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools.Pro;

public class Orbit : IOrbit
{
	[CompilerGenerated]
	private OrbitalElements orbitalElements_0;

	[CompilerGenerated]
	private WgsModel wgsModel_0;

	[CompilerGenerated]
	private NoradBase noradBase_0;

	[CompilerGenerated]
	private double double_0;

	[CompilerGenerated]
	private double double_1;

	[CompilerGenerated]
	private double double_2;

	[CompilerGenerated]
	private double double_3;

	[CompilerGenerated]
	private double double_4;

	private TimeSpan? nullable_0;

	public OrbitalElements Elements
	{
		[CompilerGenerated]
		get
		{
			return orbitalElements_0;
		}
		[CompilerGenerated]
		set
		{
			orbitalElements_0 = value;
		}
	}

	public Julian Epoch => Elements.Epoch;

	public DateTime EpochTime => Epoch.ToTime();

	public WgsModel WgsModel
	{
		[CompilerGenerated]
		get
		{
			return wgsModel_0;
		}
		[CompilerGenerated]
		private set
		{
			wgsModel_0 = value;
		}
	}

	public double SemiMajorRec
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

	public double SemiMinorRec
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

	public double MajorRec => 2.0 * SemiMajorRec;

	public double MinorRec => 2.0 * SemiMinorRec;

	public double MeanMotionRec
	{
		[CompilerGenerated]
		get
		{
			return double_2;
		}
		[CompilerGenerated]
		private set
		{
			double_2 = value;
		}
	}

	public double PerigeeKmRec
	{
		[CompilerGenerated]
		get
		{
			return double_3;
		}
		[CompilerGenerated]
		private set
		{
			double_3 = value;
		}
	}

	public double ApogeeKmRec
	{
		[CompilerGenerated]
		get
		{
			return double_4;
		}
		[CompilerGenerated]
		private set
		{
			double_4 = value;
		}
	}

	public string SatName => Elements.SatelliteName;

	public string SatNameLong => SatName + " #" + SatNoradId;

	public string SatNoradId => Elements.NoradIdStr;

	public string SatDesignator => Elements.IntlDesignatorStr;

	public TimeSpan Period
	{
		get
		{
			if (!nullable_0.HasValue)
			{
				if (MeanMotionRec == 0.0)
				{
					nullable_0 = new TimeSpan(0, 0, 0);
				}
				else
				{
					double num = Math.PI * 2.0 / MeanMotionRec * 60.0;
					int milliseconds = (int)((num - (double)(int)num) * 1000.0);
					nullable_0 = new TimeSpan(0, 0, 0, (int)num, milliseconds);
				}
			}
			return nullable_0.Value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private NoradBase method_1()
	{
		return noradBase_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_2(NoradBase noradBase_1)
	{
		noradBase_0 = noradBase_1;
	}

	public Orbit(OrbitalElements elem, WgsModel wgsModel)
	{
		Elements = elem;
		WgsModel = wgsModel;
		double num = elem.MeanMotion * (Math.PI * 2.0) / 1440.0;
		double num2 = Math.Pow(WgsModel.Xke / num, 2.0 / 3.0);
		double eccentricity = elem.Eccentricity;
		double inclinationRad = elem.InclinationRad;
		double num3 = 1.5 * WgsModel.Ck2 * (3.0 * Globals.Sqr(Math.Cos(inclinationRad)) - 1.0) / Math.Pow(1.0 - eccentricity * eccentricity, 1.5);
		double num4 = num3 / (num2 * num2);
		double num5 = num2 * (1.0 - num4 * (1.0 / 3.0 + num4 * (1.0 + 1.654320987654321 * num4)));
		double num6 = num3 / (num5 * num5);
		MeanMotionRec = num / (1.0 + num6);
		SemiMajorRec = Math.Pow(WgsModel.Xke / MeanMotionRec, 2.0 / 3.0);
		SemiMinorRec = SemiMajorRec * Math.Sqrt(1.0 - eccentricity * eccentricity);
		PerigeeKmRec = WgsModel.Xkmper * (SemiMajorRec * (1.0 - eccentricity) - 1.0);
		ApogeeKmRec = WgsModel.Xkmper * (SemiMajorRec * (1.0 + eccentricity) - 1.0);
		if (Period.TotalMinutes >= 225.0)
		{
			method_2(new NoradSDP4(this));
		}
		else
		{
			method_2(new NoradSGP4(this));
		}
	}

	public EciTime PositionEci(double mpe)
	{
		EciTime position = method_1().GetPosition(mpe);
		double num = WgsModel.Xkmper / 1.0;
		position.ScalePosVector(num);
		position.ScaleVelVector(num * (1.0 / 60.0));
		return position;
	}

	public EciTime PositionEci(DateTimeOffset time)
	{
		return PositionEci(method_9(time).TotalMinutes);
	}

	[Obsolete("Use overloaded method PositionEci(DateTimeOffset)")]
	public EciTime PositionEci(DateTime utc)
	{
		return PositionEci(method_8(utc).TotalMinutes);
	}

	[Obsolete("Use overloaded method TPlusEpoch(DateTimeOffset)")]
	public TimeSpan method_8(DateTime utc)
	{
		return utc - EpochTime;
	}

	public TimeSpan method_9(DateTimeOffset time)
	{
		return time - EpochTime;
	}

	public TimeSpan method_10()
	{
		return method_9(DateTimeOffset.UtcNow);
	}

	static Orbit()
	{
		Class72.smethod_20();
	}
}
