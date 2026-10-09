using System;
using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public class Site : IEciObject
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private Geo geo_0;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		private set
		{
			string_0 = value;
		}
	}

	public double LatitudeRad => Geo.LatitudeRad;

	public double LongitudeRad => Geo.LongitudeRad;

	public double LatitudeDeg => Geo.LatitudeDeg;

	public double LongitudeDeg => Geo.LongitudeDeg;

	public double Altitude => Geo.Altitude;

	public WgsModel WgsModel => Geo.WgsModel;

	public Geo Geo
	{
		[CompilerGenerated]
		get
		{
			return geo_0;
		}
		[CompilerGenerated]
		private set
		{
			geo_0 = value;
		}
	}

	public Site(double degLat, double degLon, double kmAlt, WgsModel model, string name = "")
	{
		Geo = new Geo(Globals.ToRadians(degLat), Globals.ToRadians(degLon), kmAlt, model);
		Name = name;
	}

	public Site(Geo geo)
	{
		Geo = new Geo(geo);
	}

	public EciTime PositionEci(Julian time)
	{
		return new EciTime(Geo, time);
	}

	public EciTime PositionEci(DateTimeOffset time)
	{
		return new EciTime(Geo, new Julian(time));
	}

	public EciTime PositionEci(DateTime utc)
	{
		return new EciTime(Geo, new Julian(utc));
	}

	public TopoTime GetLookAngle(EciTime eci)
	{
		Julian date = eci.Date;
		EciTime eciTime = PositionEci(date);
		Vector vector = new Vector(eci.Velocity.X - eciTime.Velocity.X, eci.Velocity.Y - eciTime.Velocity.Y, eci.Velocity.Z - eciTime.Velocity.Z);
		double x = eci.Position.X - eciTime.Position.X;
		double num = eci.Position.Y - eciTime.Position.Y;
		double num2 = eci.Position.Z - eciTime.Position.Z;
		double w = Math.Sqrt(Globals.Sqr(x) + Globals.Sqr(num) + Globals.Sqr(num2));
		Vector vector2 = new Vector(x, num, num2, w);
		double num3 = date.ToLmst(LongitudeRad);
		double num4 = Math.Sin(LatitudeRad);
		double num5 = Math.Cos(LatitudeRad);
		double num6 = Math.Sin(num3);
		double num7 = Math.Cos(num3);
		double num8 = num4 * num7 * vector2.X + num4 * num6 * vector2.Y - num5 * vector2.Z;
		double num9 = (0.0 - num6) * vector2.X + num7 * vector2.Y;
		double num10 = num5 * num7 * vector2.X + num5 * num6 * vector2.Y + num4 * vector2.Z;
		double num11 = Math.Atan((0.0 - num9) / num8);
		if (num8 > 0.0)
		{
			num11 += Math.PI;
		}
		if (num11 < 0.0)
		{
			num11 += Math.PI * 2.0;
		}
		double radEl = Math.Asin(num10 / vector2.W);
		double rangeRate = (vector2.X * vector.X + vector2.Y * vector.Y + vector2.Z * vector.Z) / vector2.W;
		return new TopoTime(num11, radEl, vector2.W, rangeRate, eci.Date);
	}

	public override string ToString()
	{
		return Geo.ToString();
	}

	static Site()
	{
		Class72.smethod_20();
	}
}
