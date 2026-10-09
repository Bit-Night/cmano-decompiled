using System;
using CSMaterial;

namespace Sharp3D.Math.Core;

[Serializable]
public sealed class Transform3D : ICloneable
{
	public enum Axis
	{
		X,
		Y,
		Z
	}

	private Matrix4D matrix4D_0 = Matrix4D.Identity;

	public static readonly Transform3D Identity;

	public Matrix4D Matrix
	{
		get
		{
			return matrix4D_0;
		}
		set
		{
			matrix4D_0 = value;
		}
	}

	public Matrix4D MatrixRot => new Matrix4D(matrix4D_0.M11, matrix4D_0.M12, matrix4D_0.M13, 0.0, matrix4D_0.M21, matrix4D_0.M22, matrix4D_0.M23, 0.0, matrix4D_0.M31, matrix4D_0.M32, matrix4D_0.M33, 0.0, matrix4D_0.M41, matrix4D_0.M42, matrix4D_0.M43, 1.0);

	public Vector3D Rotations => new Vector3D(System.Math.Atan2(matrix4D_0.M32, matrix4D_0.M33) * 180.0 / System.Math.PI, System.Math.Asin(0.0 - matrix4D_0.M31) * 180.0 / System.Math.PI, System.Math.Atan2(matrix4D_0.M21, matrix4D_0.M11) * 180.0 / System.Math.PI);

	public Transform3D()
	{
	}

	public Transform3D(Matrix4D mat)
	{
		matrix4D_0 = mat.Clone();
	}

	public Transform3D(Transform3D transf)
	{
		matrix4D_0 = transf.matrix4D_0.Clone();
	}

	public Vector3D transform(Vector3D vec)
	{
		Vector4D vector4D = matrix4D_0 * new Vector4D(vec.X, vec.Y, vec.Z, 1.0);
		return new Vector3D(vector4D.X, vector4D.Y, vector4D.Z);
	}

	public Vector3D transformRot(Vector3D vec)
	{
		Vector4D vector4D = MatrixRot * new Vector4D(vec.X, vec.Y, vec.Z, 1.0);
		return new Vector3D(vector4D.X, vector4D.Y, vector4D.Z);
	}

	public Transform3D Inverse()
	{
		double m = matrix4D_0.M11;
		double m2 = matrix4D_0.M12;
		double m3 = matrix4D_0.M13;
		double m4 = matrix4D_0.M14;
		double m5 = matrix4D_0.M21;
		double m6 = matrix4D_0.M22;
		double m7 = matrix4D_0.M23;
		double m8 = matrix4D_0.M24;
		double m9 = matrix4D_0.M31;
		double m10 = matrix4D_0.M32;
		double m11 = matrix4D_0.M33;
		double m12 = matrix4D_0.M34;
		double num = m * m6;
		double num2 = m * m10;
		double num3 = m5 * m2;
		double num4 = m5 * m10;
		double num5 = m9 * m2;
		double num6 = m9 * m6;
		double num7 = num * m11 - num2 * m7 - num3 * m11 + num4 * m3 + num5 * m7 - num6 * m3;
		if (num7 == 0.0)
		{
			throw new Exception("Matrix determinant is 0.0");
		}
		double num8 = 1.0 / num7;
		double num9 = m10 * m3;
		double num10 = m2 * m7;
		double num11 = m6 * m3;
		double num12 = m9 * m3;
		double num13 = m * m7;
		double num14 = m5 * m3;
		double num15 = m * m8;
		double num16 = m5 * m4;
		double num17 = m9 * m4;
		double m13 = (m6 * m11 - m10 * m7) * num8;
		double m14 = (0.0 - (m2 * m11 - num9)) * num8;
		double m15 = (num10 - num11) * num8;
		double m16 = (0.0 - (num10 * m12 - m2 * m8 * m11 - num11 * m12 + m6 * m4 * m11 + num9 * m8 - m10 * m4 * m7)) * num8;
		double m17 = (0.0 - (m5 * m11 - m9 * m7)) * num8;
		double m18 = (m * m11 - num12) * num8;
		double m19 = (0.0 - (num13 - num14)) * num8;
		double m20 = (num13 * m12 - num15 * m11 - num14 * m12 + num16 * m11 + num12 * m8 - num17 * m7) * num8;
		double m21 = (num4 - num6) * num8;
		double m22 = (0.0 - (num2 - num5)) * num8;
		double m23 = (num - num3) * num8;
		double m24 = (0.0 - (num * m12 - num15 * m10 - num3 * m12 + num16 * m10 + num5 * m8 - num17 * m6)) * num8;
		return new Transform3D(new Matrix4D(m13, m14, m15, m16, m17, m18, m19, m20, m21, m22, m23, m24, 0.0, 0.0, 0.0, 1.0));
	}

	object ICloneable.Clone()
	{
		return new Transform3D(this);
	}

	public Transform3D Clone()
	{
		return new Transform3D(this);
	}

	public static Transform3D Translation(Vector3D vecTrans)
	{
		Matrix4D identity = Matrix4D.Identity;
		identity.M14 = vecTrans.X;
		identity.M24 = vecTrans.Y;
		identity.M34 = vecTrans.Z;
		return new Transform3D(identity);
	}

	public static Transform3D Rotation(Axis axis, double angle)
	{
		double num = angle * CSMath.PI_dividedBy_180;
		double num2 = System.Math.Cos(num);
		double num3 = System.Math.Sin(num);
		Matrix4D identity = Matrix4D.Identity;
		switch (axis)
		{
		case Axis.X:
		{
			double m = (identity.M33 = num2);
			identity.M22 = m;
			identity.M32 = num3;
			identity.M23 = 0.0 - num3;
			break;
		}
		case Axis.Y:
		{
			double m = (identity.M33 = num2);
			identity.M11 = m;
			identity.M31 = num3;
			identity.M13 = 0.0 - num3;
			break;
		}
		case Axis.Z:
		{
			double m = (identity.M22 = num2);
			identity.M11 = m;
			identity.M21 = num3;
			identity.M12 = 0.0 - num3;
			break;
		}
		}
		return new Transform3D(identity);
	}

	public static Transform3D RotationX(double angle)
	{
		double num = angle * CSMath.PI_dividedBy_180;
		return new Transform3D(new Matrix4D(1.0, 0.0, 0.0, 0.0, 0.0, System.Math.Cos(num), 0.0 - System.Math.Sin(num), 0.0, 0.0, System.Math.Sin(num), System.Math.Cos(num), 0.0, 0.0, 0.0, 0.0, 1.0));
	}

	public static Transform3D RotationY(double angle)
	{
		double num = angle * CSMath.PI_dividedBy_180;
		return new Transform3D(new Matrix4D(System.Math.Cos(num), 0.0, System.Math.Sin(num), 0.0, 0.0, 1.0, 0.0, 0.0, 0.0 - System.Math.Sin(num), 0.0, System.Math.Cos(num), 0.0, 0.0, 0.0, 0.0, 1.0));
	}

	public static Transform3D RotationZ(double angle)
	{
		double num = angle * CSMath.PI_dividedBy_180;
		return new Transform3D(new Matrix4D(System.Math.Cos(num), 0.0 - System.Math.Sin(num), 0.0, 0.0, System.Math.Sin(num), System.Math.Cos(num), 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0));
	}

	public static Transform3D Rotation(Vector3D u, double angle)
	{
		u.Normalize();
		double num = angle * System.Math.PI;
		double num2 = System.Math.Cos(num);
		double num3 = System.Math.Sin(num);
		Matrix4D identity = Matrix4D.Identity;
		identity.M11 = u.X * u.X + (1.0 - u.X * u.X) * num2;
		identity.M12 = u.X * u.Y * (1.0 - num2) - u.Z * num3;
		identity.M13 = u.X * u.Z * (1.0 - num2) + u.Y * num3;
		identity.M21 = u.Y * u.X * (1.0 - num2) + u.Z * num3;
		identity.M22 = u.Y * u.Y * (1.0 - u.Y * u.Y) * num2;
		identity.M21 = u.Y * u.Z * (1.0 - num2) - u.X * num3;
		identity.M31 = u.Z * u.X * (1.0 - num2) + u.Y * num3;
		identity.M32 = u.Z * u.Y * (1.0 - num2) + u.X * num3;
		identity.M33 = u.Z * u.Z * (1.0 - u.Z * u.Z) * num2;
		return new Transform3D(identity);
	}

	public static Transform3D Perspective(double d)
	{
		Matrix4D identity = Matrix4D.Identity;
		identity.M43 = 1.0 / d;
		return new Transform3D(identity);
	}

	public static Transform3D OrthographicProjection(Vector3D viewportMin, Vector3D viewportMax, double[] sizeMin, double[] sizeMax)
	{
		Matrix4D identity = Matrix4D.Identity;
		identity.M11 = (sizeMax[0] - sizeMin[0]) / (viewportMax.X - viewportMin.X);
		identity.M22 = (sizeMax[1] - sizeMin[1]) / (viewportMax.Y - viewportMin.Y);
		identity.M33 = (sizeMax[2] - sizeMin[2]) / (viewportMax.Z - viewportMin.Z);
		identity.M14 = (sizeMin[0] * viewportMax.X - sizeMax[0] * viewportMin.X) / (viewportMax.X - viewportMin.X);
		identity.M24 = (sizeMin[1] * viewportMax.Y - sizeMax[1] * viewportMin.Y) / (viewportMax.Y - viewportMin.Y);
		identity.M34 = (sizeMin[2] * viewportMax.Z - sizeMax[2] * viewportMin.Z) / (viewportMax.Z - viewportMin.Z);
		return new Transform3D(identity);
	}

	public static Transform3D operator *(Transform3D transf1, Transform3D transf2)
	{
		return new Transform3D(transf1.matrix4D_0 * transf2.matrix4D_0);
	}

	static Transform3D()
	{
		Class72.smethod_20();
		Identity = new Transform3D(Matrix4D.Identity);
	}
}
