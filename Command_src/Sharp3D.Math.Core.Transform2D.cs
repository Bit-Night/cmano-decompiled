using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using CSMaterial;

namespace Sharp3D.Math.Core;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[TypeConverter(typeof(ExpandableObjectConverter))]
public sealed class Transform2D : ICloneable
{
	private Matrix3D matrix3D_0 = Matrix3D.Identity;

	public static readonly Transform2D Identity;

	public static readonly Transform2D ReflectionX;

	public static readonly Transform2D ReflectionY;

	private static readonly double double_0;

	public Matrix3D Matrix
	{
		get
		{
			return matrix3D_0;
		}
		set
		{
			matrix3D_0 = value;
		}
	}

	public bool HasReflection => matrix3D_0.M11 * matrix3D_0.M22 * matrix3D_0.M33 < 0.0;

	public Vector2D TranslationVector => new Vector2D(matrix3D_0.M13, matrix3D_0.M23);

	public double RotationAngle
	{
		get
		{
			double num = System.Math.Acos(matrix3D_0.M11) * 180.0 / double_0;
			if (System.Math.Sin(num) * matrix3D_0.M21 < 0.0)
			{
				num = 360.0 - num;
			}
			return num;
		}
	}

	public Transform2D()
	{
	}

	public Transform2D(Matrix3D mat)
	{
		matrix3D_0 = mat.Clone();
	}

	public Transform2D(Transform2D transf)
	{
		matrix3D_0 = transf.matrix3D_0.Clone();
	}

	public Vector2D transform(Vector2D vec)
	{
		Vector3D vector3D = matrix3D_0 * new Vector3D(vec.X, vec.Y, 1.0);
		return new Vector2D(vector3D.X, vector3D.Y);
	}

	public double transform(double angle)
	{
		if (matrix3D_0.M21 > 0.0)
		{
			if (matrix3D_0.M11 <= 0.0)
			{
				return angle + 180.0 - System.Math.Asin(matrix3D_0.M21) * 180.0 / double_0;
			}
			return angle + System.Math.Asin(matrix3D_0.M21) * 180.0 / double_0;
		}
		if (matrix3D_0.M11 > 0.0)
		{
			return angle + System.Math.Asin(matrix3D_0.M21) * 180.0 / double_0;
		}
		return angle + 180.0 - System.Math.Asin(matrix3D_0.M21) * 180.0 / double_0;
	}

	public Transform2D Inverse()
	{
		return new Transform2D(Matrix3D.Inverse(matrix3D_0));
	}

	object ICloneable.Clone()
	{
		return new Transform2D(this);
	}

	public Transform2D Clone()
	{
		return new Transform2D(this);
	}

	public static Transform2D Translation(Vector2D vecTrans)
	{
		Matrix3D identity = Matrix3D.Identity;
		identity.M13 = vecTrans.X;
		identity.M23 = vecTrans.Y;
		return new Transform2D(identity);
	}

	public static Transform2D Rotation(double angle)
	{
		double num = angle * CSMath.PI_dividedBy_180;
		double num2 = System.Math.Cos(num);
		double num3 = System.Math.Sin(num);
		return new Transform2D(new Matrix3D(new Vector3D(num2, num3, 0.0), new Vector3D(0.0 - num3, num2, 0.0), Vector3D.ZAxis));
	}

	public static Transform2D Rotation(Vector2D pt, double angle)
	{
		double num = angle * CSMath.PI_dividedBy_180;
		double num2 = System.Math.Cos(num);
		double num3 = System.Math.Sin(num);
		return new Transform2D(new Matrix3D(Vector3D.Zero, Vector3D.Zero, new Vector3D(pt.X, pt.Y, 0.0)) * new Matrix3D(new Vector3D(num2, num3, 0.0), new Vector3D(0.0 - num3, num2, 0.0), Vector3D.Zero) * new Matrix3D(Vector3D.Zero, Vector3D.Zero, new Vector3D(0.0 - pt.X, 0.0 - pt.Y, 0.0)));
	}

	public static Transform2D operator *(Transform2D transf1, Transform2D transf2)
	{
		return new Transform2D(transf1.matrix3D_0 * transf2.matrix3D_0);
	}

	static Transform2D()
	{
		Class72.smethod_20();
		Identity = new Transform2D(Matrix3D.Identity);
		ReflectionX = new Transform2D(new Matrix3D(new double[9] { 1.0, 0.0, 0.0, 0.0, -1.0, 0.0, 0.0, 0.0, 1.0 }));
		ReflectionY = new Transform2D(new Matrix3D(new double[9] { -1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0 }));
		double_0 = System.Math.PI;
	}
}
