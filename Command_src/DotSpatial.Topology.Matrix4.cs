using System;
using CSMaterial;

namespace DotSpatial.Topology;

public class Matrix4 : MatrixD, IMatrix4, IMatrixD, IMatrix
{
	public static Matrix4 Identity => new Matrix4();

	public Matrix4()
		: base(4)
	{
		base.Values[0, 0] = 1.0;
		base.Values[1, 1] = 1.0;
		base.Values[2, 2] = 1.0;
		base.Values[3, 3] = 1.0;
	}

	public IMatrix4 RotateX(double degrees)
	{
		Matrix4 inMatrix = RotationX(degrees);
		return Multiply(inMatrix) as IMatrix4;
	}

	public IMatrix4 RotateY(double degrees)
	{
		Matrix4 inMatrix = RotationY(degrees);
		return Multiply(inMatrix) as IMatrix4;
	}

	public IMatrix4 RotateZ(double degrees)
	{
		Matrix4 inMatrix = RotationZ(degrees);
		return Multiply(inMatrix) as IMatrix4;
	}

	public IMatrix4 Translate(double x, double y, double z)
	{
		Matrix4 inMatrix = Translation(x, y, z);
		return Multiply(inMatrix) as IMatrix4;
	}

	public static Matrix4 RotationX(double degrees)
	{
		Matrix4 matrix = new Matrix4();
		double num = degrees * CSMath.PI_dividedBy_180;
		double[,] values = matrix.Values;
		values[1, 1] = Math.Cos(num);
		values[2, 1] = 0.0 - Math.Sin(num);
		values[1, 2] = Math.Sin(num);
		values[2, 2] = Math.Cos(num);
		return matrix;
	}

	public static Matrix4 RotationY(double degrees)
	{
		Matrix4 matrix = new Matrix4();
		double num = degrees * CSMath.PI_dividedBy_180;
		double[,] values = matrix.Values;
		values[0, 0] = Math.Cos(num);
		values[0, 2] = 0.0 - Math.Sin(num);
		values[2, 0] = Math.Sin(num);
		values[2, 2] = Math.Cos(num);
		return matrix;
	}

	public static Matrix4 RotationZ(double degrees)
	{
		Matrix4 matrix = new Matrix4();
		double num = degrees * CSMath.PI_dividedBy_180;
		double[,] values = matrix.Values;
		values[0, 0] = Math.Cos(num);
		values[0, 1] = 0.0 - Math.Sin(num);
		values[1, 0] = Math.Sin(num);
		values[1, 1] = Math.Cos(num);
		return matrix;
	}

	public static Matrix4 Translation(double x, double y, double z)
	{
		Matrix4 matrix = new Matrix4();
		double[,] values = matrix.Values;
		values[3, 0] = x;
		values[3, 1] = y;
		values[3, 2] = z;
		return matrix;
	}

	static Matrix4()
	{
		Class72.smethod_20();
	}
}
