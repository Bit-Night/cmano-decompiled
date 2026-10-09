using System;
using CSMaterial.ExWorldWind;

namespace ExWorldWind;

public struct Quaternion4d
{
	public double X;

	public double Y;

	public double Z;

	public double W;

	public Quaternion4d(double x, double y, double z, double w)
	{
		X = x;
		Y = y;
		Z = z;
		W = w;
	}

	public override int GetHashCode()
	{
		return (int)(X / Y / Z / W);
	}

	public override bool Equals(object obj)
	{
		if (obj is Quaternion4d)
		{
			return (Quaternion4d)obj == this;
		}
		return false;
	}

	public static Quaternion4d EulerToQuaternion(double yaw, double pitch, double roll)
	{
		double num = Math.Cos(yaw * 0.5);
		double num2 = Math.Cos(pitch * 0.5);
		double num3 = Math.Cos(roll * 0.5);
		double num4 = Math.Sin(yaw * 0.5);
		double num5 = Math.Sin(pitch * 0.5);
		double num6 = Math.Sin(roll * 0.5);
		double w = num * num2 * num3 + num4 * num5 * num6;
		double x = num4 * num2 * num3 - num * num5 * num6;
		double y = num * num5 * num3 + num4 * num2 * num6;
		double z = num * num2 * num6 - num4 * num5 * num3;
		return new Quaternion4d(x, y, z, w);
	}

	public static Point3d QuaternionToEuler(Quaternion4d q)
	{
		double w = q.W;
		double x = q.X;
		double y = q.Y;
		double z = q.Z;
		double x2 = Math.Atan2(2.0 * (y * z + w * x), w * w - x * x - y * y + z * z);
		double y2 = Math.Asin(-2.0 * (x * z - w * y));
		double z2 = Math.Atan2(2.0 * (x * y + w * z), w * w + x * x - y * y - z * z);
		return new Point3d(x2, y2, z2);
	}

	public static Quaternion4d operator +(Quaternion4d a, Quaternion4d b)
	{
		return new Quaternion4d(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
	}

	public static Quaternion4d operator -(Quaternion4d a, Quaternion4d b)
	{
		return new Quaternion4d(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
	}

	public static Quaternion4d operator *(Quaternion4d a, Quaternion4d b)
	{
		return new Quaternion4d(a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y, a.W * b.Y + a.Y * b.W + a.Z * b.X - a.X * b.Z, a.W * b.Z + a.Z * b.W + a.X * b.Y - a.Y * b.X, a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z);
	}

	public static Quaternion4d operator *(double s, Quaternion4d q)
	{
		return new Quaternion4d(s * q.X, s * q.Y, s * q.Z, s * q.W);
	}

	public static Quaternion4d operator *(Quaternion4d q, double s)
	{
		return new Quaternion4d(s * q.X, s * q.Y, s * q.Z, s * q.W);
	}

	public static Quaternion4d operator *(Point3d v, Quaternion4d q)
	{
		return new Quaternion4d(v.X * q.W + v.Y * q.Z - v.Z * q.Y, v.Y * q.W + v.Z * q.X - v.X * q.Z, v.Z * q.W + v.X * q.Y - v.Y * q.X, (0.0 - v.X) * q.X - v.Y * q.Y - v.Z * q.Z);
	}

	public static Quaternion4d operator /(Quaternion4d q, double s)
	{
		return q * (1.0 / s);
	}

	public Quaternion4d Conjugate()
	{
		return new Quaternion4d(0.0 - X, 0.0 - Y, 0.0 - Z, W);
	}

	public static double Norm2(Quaternion4d q)
	{
		return q.X * q.X + q.Y * q.Y + q.Z * q.Z + q.W * q.W;
	}

	public static double Abs(Quaternion4d q)
	{
		return Math.Sqrt(Norm2(q));
	}

	public static Quaternion4d operator /(Quaternion4d a, Quaternion4d b)
	{
		return a * (b.Conjugate() / Abs(b));
	}

	public static bool operator ==(Quaternion4d a, Quaternion4d b)
	{
		if (a.X == b.X && a.Y == b.Y && a.Z == b.Z)
		{
			return a.W == b.W;
		}
		return false;
	}

	public static bool operator !=(Quaternion4d a, Quaternion4d b)
	{
		if (a.X == b.X && a.Y == b.Y && a.Z == b.Z)
		{
			return a.W != b.W;
		}
		return true;
	}

	public static double Dot(Quaternion4d a, Quaternion4d b)
	{
		return a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;
	}

	public void Normalize()
	{
		double num = Length();
		X /= num;
		Y /= num;
		Z /= num;
		W /= num;
	}

	public double Length()
	{
		return Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
	}

	public static Quaternion4d Slerp(Quaternion4d q0, Quaternion4d q1, double t)
	{
		double num = q0.X * q1.X + q0.Y * q1.Y + q0.Z * q1.Z + q0.W * q1.W;
		double num2;
		double num3;
		double num4;
		double num5;
		if (num < 0.0)
		{
			num = 0.0 - num;
			num2 = 0.0 - q1.X;
			num3 = 0.0 - q1.Y;
			num4 = 0.0 - q1.Z;
			num5 = 0.0 - q1.W;
		}
		else
		{
			num2 = q1.X;
			num3 = q1.Y;
			num4 = q1.Z;
			num5 = q1.W;
		}
		double num8;
		double num9;
		if (1.0 - num > double.Epsilon)
		{
			double num6 = Math.Acos(num);
			double num7 = Math.Sin(num6);
			num8 = Math.Sin((1.0 - t) * num6) / num7;
			num9 = Math.Sin(t * num6) / num7;
		}
		else
		{
			num8 = 1.0 - t;
			num9 = t;
		}
		return new Quaternion4d
		{
			X = num8 * q0.X + num9 * num2,
			Y = num8 * q0.Y + num9 * num3,
			Z = num8 * q0.Z + num9 * num4,
			W = num8 * q0.W + num9 * num5
		};
	}

	public Quaternion4d Ln()
	{
		return Ln(this);
	}

	public static Quaternion4d Ln(Quaternion4d q)
	{
		double num = 0.0;
		double num2 = Math.Sqrt(q.X * q.X + q.Y * q.Y + q.Z * q.Z);
		double num3 = Math.Atan2(num2, q.W);
		num = ((!(Math.Abs(num2) < double.Epsilon)) ? (num3 / num2) : 0.0);
		q.X *= num;
		q.Y *= num;
		q.Z *= num;
		q.W = 0.0;
		return q;
	}

	public static Quaternion4d Exp(Quaternion4d q)
	{
		double num = Math.Sqrt(q.X * q.X + q.Y * q.Y + q.Z * q.Z);
		double num2 = ((!(Math.Abs(num) >= double.Epsilon)) ? 1.0 : (Math.Sin(num) / num));
		q.X *= num2;
		q.Y *= num2;
		q.Z *= num2;
		q.W = Math.Cos(num);
		return q;
	}

	public Quaternion4d Exp()
	{
		return Ln(this);
	}

	public static Quaternion4d Squad(Quaternion4d q1, Quaternion4d a, Quaternion4d b, Quaternion4d c, double t)
	{
		return Slerp(Slerp(q1, c, t), Slerp(a, b, t), 2.0 * t * (1.0 - t));
	}

	public static void SquadSetup(ref Quaternion4d outA, ref Quaternion4d outB, ref Quaternion4d outC, Quaternion4d q0, Quaternion4d q1, Quaternion4d q2, Quaternion4d q3)
	{
		q0 += q1;
		q0.Normalize();
		q2 += q1;
		q2.Normalize();
		q3 += q1;
		q3.Normalize();
		q1.Normalize();
		outA = q1 * Exp(-0.25 * (Ln(Exp(q1) * q2) + Ln(Exp(q1) * q0)));
		outB = q2 * Exp(-0.25 * (Ln(Exp(q2) * q3) + Ln(Exp(q2) * q1)));
		outC = q2;
	}

	static Quaternion4d()
	{
		Class72.smethod_20();
	}
}
