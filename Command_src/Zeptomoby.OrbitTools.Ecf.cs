using System;
using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public class Ecf : EcBase
{
	[CompilerGenerated]
	private WgsModel wgsModel_0;

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

	public Ecf(Vector pos, Vector vel, WgsModel ellipsoid)
		: base(pos, vel)
	{
		WgsModel = ellipsoid;
	}

	public Ecf(Ecf ecf)
		: this(ecf.Position, ecf.Velocity, ecf.WgsModel)
	{
	}

	public Ecf(Geo geo)
	{
		WgsModel = geo.WgsModel;
		double num = Globals.Sqr(WgsModel.Xkmper);
		double num2 = (1.0 - WgsModel.F) * WgsModel.Xkmper;
		double num3 = (num - num2 * num2) / num;
		double num4 = Math.Sin(geo.LatitudeRad);
		double num5 = Math.Cos(geo.LatitudeRad);
		double num6 = Math.Sin(geo.LongitudeRad);
		double num7 = Math.Cos(geo.LongitudeRad);
		double num8 = WgsModel.Xkmper / Math.Sqrt(1.0 - num3 * num4 * num4);
		double x = (num8 + geo.Altitude) * num5 * num7;
		double y = (num8 + geo.Altitude) * num5 * num6;
		double z = (num8 + geo.Altitude - num3 * num8) * num4;
		base.Position = new Vector(x, y, z);
		base.Velocity = new Vector();
		double num9 = 7.292115855228083E-05;
		base.Velocity.X = -7.292115855228083E-05 * base.Position.Y;
		base.Velocity.Y = num9 * base.Position.X;
		base.Velocity.Z = 0.0;
		base.Velocity.W = Math.Sqrt(Globals.Sqr(base.Velocity.X) + Globals.Sqr(base.Velocity.Y));
	}

	public Ecf(Eci eci, Julian date, WgsModel ellipsoid)
		: this(eci.Position, eci.Velocity, ellipsoid)
	{
		double num = date.ToGmst();
		base.Position.RotateZ(0.0 - num);
		base.Velocity.RotateZ(0.0 - num);
		Vector vector = FrameVelocity(base.Position, ellipsoid);
		base.Velocity.X -= vector.X;
		base.Velocity.Y -= vector.Y;
	}

	public static Vector FrameVelocity(Vector pos, WgsModel ellipsoid)
	{
		double y = Math.PI * (2.0 * ellipsoid.Xkmper) / 86400.0 * 1.00273790934;
		Vector vector = new Vector(0.0, y, 0.0);
		Vector vector2 = new Vector(pos.X, pos.Y, 0.0);
		vector.Scale(vector2.Magnitude() / ellipsoid.Xkmper);
		double num = Math.Asin(vector2.Y / vector2.Magnitude());
		if (vector2.X < 0.0)
		{
			num = ((!(vector2.Y > 0.0)) ? (-Math.PI - num) : (Math.PI - num));
		}
		vector.RotateZ(num);
		return vector;
	}

	public double Distance(Ecf p2)
	{
		return Distance((EcBase)p2);
	}

	static Ecf()
	{
		Class72.smethod_20();
	}
}
