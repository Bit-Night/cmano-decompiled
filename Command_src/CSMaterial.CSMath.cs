using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Spatial.Euclidean;

namespace CSMaterial;

public static class CSMath
{
	public struct Vector3
	{
		public double x;

		public double y;

		public double z;

		public double len => Math.Sqrt(x * x + y * y + z * z);

		public Vector3(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public Vector3(Sphere3 s)
		{
			x = s.r * Math.Cos(s.theta) * Math.Cos(s.phi);
			y = s.r * Math.Sin(s.theta);
			z = s.r * Math.Cos(s.theta) * Math.Sin(s.phi);
		}

		public DenseVector ToDV()
		{
			return new DenseVector(3)
			{
				[0] = x,
				[1] = y,
				[2] = z
			};
		}

		static Vector3()
		{
			Class72.smethod_20();
		}
	}

	public struct Sphere3
	{
		public double r;

		public double theta;

		public double phi;

		public Sphere3(double r, double theta, double phi)
		{
			this.r = r;
			this.theta = theta;
			this.phi = phi;
		}

		public Sphere3(Vector3 v)
		{
			r = v.len;
			theta = Math.Acos(v.z / r);
			phi = Math.Atan2(v.y, v.x);
		}

		static Sphere3()
		{
			Class72.smethod_20();
		}
	}

	public static double PI_dividedBy_180;

	public static double Const_180_dividedBy_PI;

	public static double ClosureRateApprox(double Lat1, double Lon1, double Asl1, double Vel1, double Heading1, double Lat2, double Lon2, double Asl2, double Vel2, double Heading2)
	{
		DenseVector denseVector = new Vector3(new Sphere3(6371000.0 + Asl1, 0.0174532925199433 * Lat1, 0.0174532925199433 * Lon1)).ToDV();
		DenseVector denseVector2 = new Vector3(new Sphere3(6371000.0 + Asl2, 0.0174532925199433 * Lat2, 0.0174532925199433 * Lon2)).ToDV();
		DenseVector denseVector3 = denseVector2 - denseVector;
		DenseVector denseVector4 = new Vector3(0.0, Vel1 * (463.0 / 900.0) * Math.Cos(0.0174532925199433 * Heading1), Vel1 * (463.0 / 900.0) * Math.Sin(0.0174532925199433 * Heading1)).ToDV();
		DenseVector denseVector5 = new Vector3(0.0, Vel2 * (463.0 / 900.0) * Math.Cos(0.0174532925199433 * Heading2), Vel2 * (463.0 / 900.0) * Math.Sin(0.0174532925199433 * Heading2)).ToDV();
		Matrix<double> matrix = Matrix3D.RotationTo(UnitVector3D.XAxis, new UnitVector3D(denseVector.Values));
		Matrix<double> matrix2 = Matrix3D.RotationTo(UnitVector3D.XAxis, new UnitVector3D(denseVector2.Values));
		Vector<double> vector = matrix * denseVector4;
		Vector<double> vector2 = matrix2 * denseVector5;
		return (vector - vector2).DotProduct(denseVector3) / denseVector3.L2Norm() * 3600.0 / 1852.0;
	}

	public static bool IsFinite(double value)
	{
		if (value <= double.NegativeInfinity)
		{
			return false;
		}
		return value < double.PositiveInfinity;
	}

	public static bool IsFinite(float value)
	{
		if (value <= float.NegativeInfinity)
		{
			return false;
		}
		return value < float.PositiveInfinity;
	}

	static CSMath()
	{
		Class72.smethod_20();
		PI_dividedBy_180 = Math.PI / 180.0;
		Const_180_dividedBy_PI = 180.0 / Math.PI;
	}
}
