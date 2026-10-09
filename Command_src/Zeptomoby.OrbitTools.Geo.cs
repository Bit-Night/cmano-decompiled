using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public class Geo : LatLon
{
	[CompilerGenerated]
	private double double_2;

	[CompilerGenerated]
	private WgsModel wgsModel_0;

	public double Altitude
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

	public WgsModel WgsModel
	{
		[CompilerGenerated]
		get
		{
			return wgsModel_0;
		}
		[CompilerGenerated]
		set
		{
			wgsModel_0 = value;
		}
	}

	public Geo(Geo geo)
		: base(geo.LatitudeRad, geo.LongitudeRad)
	{
		Altitude = geo.Altitude;
		WgsModel = geo.WgsModel;
	}

	public Geo(double radLat, double radLon, double kmAlt, WgsModel ellipsoid)
		: base(radLat, radLon)
	{
		Altitude = kmAlt;
		WgsModel = ellipsoid;
	}

	public Geo(Ecf ecf)
		: this(ecf.Position, Globals.AcTan(ecf.Position.Y, ecf.Position.X), ecf.WgsModel)
	{
	}

	public Geo(Eci eci, Julian date, WgsModel ellipsoid)
		: this(eci.Position, (Globals.AcTan(eci.Position.Y, eci.Position.X) - date.ToGmst()) % (Math.PI * 2.0), ellipsoid)
	{
	}

	private Geo(Vector pos, double theta, WgsModel ellipsoid)
		: base(0.0, 0.0)
	{
		theta %= Math.PI * 2.0;
		if (theta < 0.0)
		{
			theta += Math.PI * 2.0;
		}
		double num = Math.Sqrt(Globals.Sqr(pos.X) + Globals.Sqr(pos.Y));
		double num2 = ellipsoid.F * (2.0 - ellipsoid.F);
		double num3 = Globals.AcTan(pos.Z, num);
		double num4;
		double num5;
		do
		{
			num4 = num3;
			num5 = 1.0 / Math.Sqrt(1.0 - num2 * Globals.Sqr(Math.Sin(num4)));
			num3 = Globals.AcTan(pos.Z + ellipsoid.Xkmper * num5 * num2 * Math.Sin(num4), num);
		}
		while (Math.Abs(num3 - num4) > 1E-07);
		base.LatitudeRad = num3;
		base.LongitudeRad = theta;
		Altitude = num / Math.Cos(num3) - ellipsoid.Xkmper * num5;
		WgsModel = ellipsoid;
	}

	public double Distance(Geo p2)
	{
		Julian date = new Julian(2012, 1.0);
		EciTime eciTime = new EciTime(this, date);
		Eci p3 = new EciTime(p2, date);
		return eciTime.Distance(p3);
	}

	public override string ToString()
	{
		bool flag = base.LatitudeRad >= 0.0;
		bool flag2 = base.LongitudeRad >= 0.0;
		return string.Concat(string.Format(CultureInfo.CurrentCulture, "{0:00.0}{1} ", Math.Abs(base.LatitudeDeg), (!flag) ? 'S' : 'N') + string.Format(CultureInfo.CurrentCulture, "{0:000.0}{1} ", Math.Abs(base.LongitudeDeg), (!flag2) ? 'W' : 'E'), string.Format(CultureInfo.CurrentCulture, "{0:F0}m", Altitude * 1000.0));
	}

	static Geo()
	{
		Class72.smethod_20();
	}
}
