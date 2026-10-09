using System;

namespace Zeptomoby.OrbitTools;

public class Eci : EcBase
{
	public Eci()
		: this(new Vector(), new Vector())
	{
	}

	public Eci(Vector pos)
		: this(pos, new Vector())
	{
	}

	public Eci(Vector pos, Vector vel)
		: base(pos, vel)
	{
	}

	public Eci(Eci eci)
		: base(eci.Position, eci.Velocity)
	{
	}

	public Eci(Ecf ecf, Julian date)
		: base(ecf.Position, ecf.Velocity)
	{
		double radians = date.ToGmst();
		base.Position.RotateZ(radians);
		base.Velocity.RotateZ(radians);
		Vector vector = Ecf.FrameVelocity(base.Position, ecf.WgsModel);
		base.Velocity.X += vector.X;
		base.Velocity.Y += vector.Y;
	}

	public Eci(Geo geo, Julian date)
	{
		double latitudeRad = geo.LatitudeRad;
		double longitudeRad = geo.LongitudeRad;
		double altitude = geo.Altitude;
		double num = date.ToLmst(longitudeRad);
		double num2 = 1.0 / Math.Sqrt(1.0 + geo.WgsModel.F * (geo.WgsModel.F - 2.0) * Globals.Sqr(Math.Sin(latitudeRad)));
		double num3 = Globals.Sqr(1.0 - geo.WgsModel.F) * num2;
		double num4 = (geo.WgsModel.Xkmper * num2 + altitude) * Math.Cos(latitudeRad);
		base.Position = new Vector();
		base.Position.X = num4 * Math.Cos(num);
		base.Position.Y = num4 * Math.Sin(num);
		base.Position.Z = (geo.WgsModel.Xkmper * num3 + altitude) * Math.Sin(latitudeRad);
		base.Position.W = Math.Sqrt(Globals.Sqr(base.Position.X) + Globals.Sqr(base.Position.Y) + Globals.Sqr(base.Position.Z));
		base.Velocity = new Vector();
		double num5 = 7.292115855228083E-05;
		base.Velocity.X = -7.292115855228083E-05 * base.Position.Y;
		base.Velocity.Y = num5 * base.Position.X;
		base.Velocity.Z = 0.0;
		base.Velocity.W = Math.Sqrt(Globals.Sqr(base.Velocity.X) + Globals.Sqr(base.Velocity.Y));
	}

	public double Distance(Eci p2)
	{
		return Distance((EcBase)p2);
	}

	static Eci()
	{
		Class72.smethod_20();
	}
}
