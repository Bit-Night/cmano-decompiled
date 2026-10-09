using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public struct Matrix4D : ICloneable
{
	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private double double_4;

	private double double_5;

	private double double_6;

	private double double_7;

	private double double_8;

	private double double_9;

	private double double_10;

	private double double_11;

	private double double_12;

	private double double_13;

	private double double_14;

	private double double_15;

	public static readonly Matrix4D Zero;

	public static readonly Matrix4D Identity;

	public double M11
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public double M12
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public double M13
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public double M14
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public double M21
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public double M22
	{
		get
		{
			return double_5;
		}
		set
		{
			double_5 = value;
		}
	}

	public double M23
	{
		get
		{
			return double_6;
		}
		set
		{
			double_6 = value;
		}
	}

	public double M24
	{
		get
		{
			return double_7;
		}
		set
		{
			double_7 = value;
		}
	}

	public double M31
	{
		get
		{
			return double_8;
		}
		set
		{
			double_8 = value;
		}
	}

	public double M32
	{
		get
		{
			return double_9;
		}
		set
		{
			double_9 = value;
		}
	}

	public double M33
	{
		get
		{
			return double_10;
		}
		set
		{
			double_10 = value;
		}
	}

	public double M34
	{
		get
		{
			return double_11;
		}
		set
		{
			double_11 = value;
		}
	}

	public double M41
	{
		get
		{
			return double_12;
		}
		set
		{
			double_12 = value;
		}
	}

	public double M42
	{
		get
		{
			return double_13;
		}
		set
		{
			double_13 = value;
		}
	}

	public double M43
	{
		get
		{
			return double_14;
		}
		set
		{
			double_14 = value;
		}
	}

	public double M44
	{
		get
		{
			return double_15;
		}
		set
		{
			double_15 = value;
		}
	}

	public double Trace => double_0 + double_5 + double_10 + double_15;

	public unsafe double this[int index]
	{
		get
		{
			if (index < 0 || index >= 16)
			{
				throw new IndexOutOfRangeException("Invalid matrix index!");
			}
			fixed (double* ptr = &double_0)
			{
				return ptr[index];
			}
		}
		set
		{
			if (index < 0 || index >= 16)
			{
				throw new IndexOutOfRangeException("Invalid matrix index!");
			}
			fixed (double* ptr = &double_0)
			{
				ptr[index] = value;
			}
		}
	}

	public double this[int row, int column]
	{
		get
		{
			return this[(row - 1) * 4 + (column - 1)];
		}
		set
		{
			this[(row - 1) * 4 + (column - 1)] = value;
		}
	}

	public Matrix4D(double m11, double m12, double m13, double m14, double m21, double m22, double m23, double m24, double m31, double m32, double m33, double m34, double m41, double m42, double m43, double m44)
	{
		double_0 = m11;
		double_1 = m12;
		double_2 = m13;
		double_3 = m14;
		double_4 = m21;
		double_5 = m22;
		double_6 = m23;
		double_7 = m24;
		double_8 = m31;
		double_9 = m32;
		double_10 = m33;
		double_11 = m34;
		double_12 = m41;
		double_13 = m42;
		double_14 = m43;
		double_15 = m44;
	}

	public Matrix4D(double[] elements)
	{
		double_0 = elements[0];
		double_1 = elements[1];
		double_2 = elements[2];
		double_3 = elements[3];
		double_4 = elements[4];
		double_5 = elements[5];
		double_6 = elements[6];
		double_7 = elements[7];
		double_8 = elements[8];
		double_9 = elements[9];
		double_10 = elements[10];
		double_11 = elements[11];
		double_12 = elements[12];
		double_13 = elements[13];
		double_14 = elements[14];
		double_15 = elements[15];
	}

	public Matrix4D(List<double> elements)
	{
		double_0 = elements[0];
		double_1 = elements[1];
		double_2 = elements[2];
		double_3 = elements[3];
		double_4 = elements[4];
		double_5 = elements[5];
		double_6 = elements[6];
		double_7 = elements[7];
		double_8 = elements[8];
		double_9 = elements[9];
		double_10 = elements[10];
		double_11 = elements[11];
		double_12 = elements[12];
		double_13 = elements[13];
		double_14 = elements[14];
		double_15 = elements[15];
	}

	public Matrix4D(Vector4D column1, Vector4D column2, Vector4D column3, Vector4D column4)
	{
		double_0 = column1.X;
		double_1 = column2.X;
		double_2 = column3.X;
		double_3 = column4.X;
		double_4 = column1.Y;
		double_5 = column2.Y;
		double_6 = column3.Y;
		double_7 = column4.Y;
		double_8 = column1.Z;
		double_9 = column2.Z;
		double_10 = column3.Z;
		double_11 = column4.Z;
		double_12 = column1.W;
		double_13 = column2.W;
		double_14 = column3.W;
		double_15 = column4.W;
	}

	public Matrix4D(Vector3D column1, Vector3D column2, Vector3D column3, Vector3D column4)
	{
		double_0 = column1.X;
		double_1 = column2.X;
		double_2 = column3.X;
		double_3 = column4.X;
		double_4 = column1.Y;
		double_5 = column2.Y;
		double_6 = column3.Y;
		double_7 = column4.Y;
		double_8 = column1.Z;
		double_9 = column2.Z;
		double_10 = column3.Z;
		double_11 = column4.Z;
		double_12 = 0.0;
		double_13 = 0.0;
		double_14 = 0.0;
		double_15 = 1.0;
	}

	public Matrix4D(Matrix4D m)
	{
		double_0 = m.M11;
		double_1 = m.M12;
		double_2 = m.M13;
		double_3 = m.M14;
		double_4 = m.M21;
		double_5 = m.M22;
		double_6 = m.M23;
		double_7 = m.M24;
		double_8 = m.M31;
		double_9 = m.M32;
		double_10 = m.M33;
		double_11 = m.M34;
		double_12 = m.M41;
		double_13 = m.M42;
		double_14 = m.M43;
		double_15 = m.M44;
	}

	object ICloneable.Clone()
	{
		return new Matrix4D(this);
	}

	public Matrix4D Clone()
	{
		return new Matrix4D(this);
	}

	public static Matrix4D Parse(string value)
	{
		Match match = new Regex("4x4\\s*\\[(?<m11>.*),(?<m12>.*),(?<m13>.*),(?<m14>.*),(?<m21>.*),(?<m22>.*),(?<m23>.*),(?<m24>.*),(?<m31>.*),(?<m32>.*),(?<m33>.*),(?<m34>.*),(?<m41>.*),(?<m42>.*),(?<m43>.*),(?<m44>.*)\\]", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Matrix4D(double.Parse(match.Result("${m11}")), double.Parse(match.Result("${m12}")), double.Parse(match.Result("${m13}")), double.Parse(match.Result("${m14}")), double.Parse(match.Result("${m21}")), double.Parse(match.Result("${m22}")), double.Parse(match.Result("${m23}")), double.Parse(match.Result("${m24}")), double.Parse(match.Result("${m31}")), double.Parse(match.Result("${m32}")), double.Parse(match.Result("${m33}")), double.Parse(match.Result("${m34}")), double.Parse(match.Result("${m41}")), double.Parse(match.Result("${m42}")), double.Parse(match.Result("${m43}")), double.Parse(match.Result("${m44}")));
	}

	public static bool TryParse(string value, out Matrix4D result)
	{
		Match match = new Regex("4x4\\s*\\[(?<m11>.*),(?<m12>.*),(?<m13>.*),(?<m14>.*),(?<m21>.*),(?<m22>.*),(?<m23>.*),(?<m24>.*),(?<m31>.*),(?<m32>.*),(?<m33>.*),(?<m34>.*),(?<m41>.*),(?<m42>.*),(?<m43>.*),(?<m44>.*)\\]", RegexOptions.Singleline).Match(value);
		if (!match.Success)
		{
			result = Zero;
			return false;
		}
		result = new Matrix4D(double.Parse(match.Result("${m11}")), double.Parse(match.Result("${m12}")), double.Parse(match.Result("${m13}")), double.Parse(match.Result("${m14}")), double.Parse(match.Result("${m21}")), double.Parse(match.Result("${m22}")), double.Parse(match.Result("${m23}")), double.Parse(match.Result("${m24}")), double.Parse(match.Result("${m31}")), double.Parse(match.Result("${m32}")), double.Parse(match.Result("${m33}")), double.Parse(match.Result("${m34}")), double.Parse(match.Result("${m41}")), double.Parse(match.Result("${m42}")), double.Parse(match.Result("${m43}")), double.Parse(match.Result("${m44}")));
		return true;
	}

	public static Matrix4D Add(Matrix4D left, Matrix4D right)
	{
		return new Matrix4D(left.M11 + right.M11, left.M12 + right.M12, left.M13 + right.M13, left.M14 + right.M14, left.M21 + right.M21, left.M22 + right.M22, left.M23 + right.M23, left.M24 + right.M24, left.M31 + right.M31, left.M32 + right.M32, left.M33 + right.M33, left.M34 + right.M34, left.M41 + right.M41, left.M42 + right.M42, left.M43 + right.M43, left.M44 + right.M44);
	}

	public static Matrix4D Add(Matrix4D matrix, double scalar)
	{
		return new Matrix4D(matrix.M11 + scalar, matrix.M12 + scalar, matrix.M13 + scalar, matrix.M14 + scalar, matrix.M21 + scalar, matrix.M22 + scalar, matrix.M23 + scalar, matrix.M24 + scalar, matrix.M31 + scalar, matrix.M32 + scalar, matrix.M33 + scalar, matrix.M34 + scalar, matrix.M41 + scalar, matrix.M42 + scalar, matrix.M43 + scalar, matrix.M44 + scalar);
	}

	public static void Add(Matrix4D left, Matrix4D right, ref Matrix4D result)
	{
		result.M11 = left.M11 + right.M11;
		result.M12 = left.M12 + right.M12;
		result.M13 = left.M13 + right.M13;
		result.M14 = left.M14 + right.M14;
		result.M21 = left.M21 + right.M21;
		result.M22 = left.M22 + right.M22;
		result.M23 = left.M23 + right.M23;
		result.M24 = left.M24 + right.M24;
		result.M31 = left.M31 + right.M31;
		result.M32 = left.M32 + right.M32;
		result.M33 = left.M33 + right.M33;
		result.M34 = left.M34 + right.M34;
		result.M41 = left.M41 + right.M41;
		result.M42 = left.M42 + right.M42;
		result.M43 = left.M43 + right.M43;
		result.M44 = left.M44 + right.M44;
	}

	public static void Add(Matrix4D matrix, double scalar, ref Matrix4D result)
	{
		result.M11 = matrix.M11 + scalar;
		result.M12 = matrix.M12 + scalar;
		result.M13 = matrix.M13 + scalar;
		result.M14 = matrix.M14 + scalar;
		result.M21 = matrix.M21 + scalar;
		result.M22 = matrix.M22 + scalar;
		result.M23 = matrix.M23 + scalar;
		result.M24 = matrix.M24 + scalar;
		result.M31 = matrix.M31 + scalar;
		result.M32 = matrix.M32 + scalar;
		result.M33 = matrix.M33 + scalar;
		result.M34 = matrix.M34 + scalar;
		result.M41 = matrix.M41 + scalar;
		result.M42 = matrix.M42 + scalar;
		result.M43 = matrix.M43 + scalar;
		result.M44 = matrix.M44 + scalar;
	}

	public static Matrix4D Subtract(Matrix4D left, Matrix4D right)
	{
		return new Matrix4D(left.M11 - right.M11, left.M12 - right.M12, left.M13 - right.M13, left.M14 - right.M14, left.M21 - right.M21, left.M22 - right.M22, left.M23 - right.M23, left.M24 - right.M24, left.M31 - right.M31, left.M32 - right.M32, left.M33 - right.M33, left.M34 - right.M34, left.M41 - right.M41, left.M42 - right.M42, left.M43 - right.M43, left.M44 - right.M44);
	}

	public static Matrix4D Subtract(Matrix4D matrix, double scalar)
	{
		return new Matrix4D(matrix.M11 - scalar, matrix.M12 - scalar, matrix.M13 - scalar, matrix.M14 - scalar, matrix.M21 - scalar, matrix.M22 - scalar, matrix.M23 - scalar, matrix.M24 - scalar, matrix.M31 - scalar, matrix.M32 - scalar, matrix.M33 - scalar, matrix.M34 - scalar, matrix.M41 - scalar, matrix.M42 - scalar, matrix.M43 - scalar, matrix.M44 - scalar);
	}

	public static void Subtract(Matrix4D left, Matrix4D right, ref Matrix4D result)
	{
		result.M11 = left.M11 - right.M11;
		result.M12 = left.M12 - right.M12;
		result.M13 = left.M13 - right.M13;
		result.M14 = left.M14 - right.M14;
		result.M21 = left.M21 - right.M21;
		result.M22 = left.M22 - right.M22;
		result.M23 = left.M23 - right.M23;
		result.M24 = left.M24 - right.M24;
		result.M31 = left.M31 - right.M31;
		result.M32 = left.M32 - right.M32;
		result.M33 = left.M33 - right.M33;
		result.M34 = left.M34 - right.M34;
		result.M41 = left.M41 - right.M41;
		result.M42 = left.M42 - right.M42;
		result.M43 = left.M43 - right.M43;
		result.M44 = left.M44 - right.M44;
	}

	public static void Subtract(Matrix4D matrix, double scalar, ref Matrix4D result)
	{
		result.M11 = matrix.M11 - scalar;
		result.M12 = matrix.M12 - scalar;
		result.M13 = matrix.M13 - scalar;
		result.M14 = matrix.M14 - scalar;
		result.M21 = matrix.M21 - scalar;
		result.M22 = matrix.M22 - scalar;
		result.M23 = matrix.M23 - scalar;
		result.M24 = matrix.M24 - scalar;
		result.M31 = matrix.M31 - scalar;
		result.M32 = matrix.M32 - scalar;
		result.M33 = matrix.M33 - scalar;
		result.M34 = matrix.M34 - scalar;
		result.M41 = matrix.M41 - scalar;
		result.M42 = matrix.M42 - scalar;
		result.M43 = matrix.M43 - scalar;
		result.M44 = matrix.M44 - scalar;
	}

	public static Matrix4D Multiply(Matrix4D left, Matrix4D right)
	{
		return new Matrix4D(left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31 + left.M14 * right.M41, left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32 + left.M14 * right.M42, left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33 + left.M14 * right.M43, left.M11 * right.M14 + left.M12 * right.M24 + left.M13 * right.M34 + left.M14 * right.M44, left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31 + left.M24 * right.M41, left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32 + left.M24 * right.M42, left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33 + left.M24 * right.M43, left.M21 * right.M14 + left.M22 * right.M24 + left.M23 * right.M34 + left.M24 * right.M44, left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31 + left.M34 * right.M41, left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32 + left.M34 * right.M42, left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33 + left.M34 * right.M43, left.M31 * right.M14 + left.M32 * right.M24 + left.M33 * right.M34 + left.M34 * right.M44, left.M41 * right.M11 + left.M42 * right.M21 + left.M43 * right.M31 + left.M44 * right.M41, left.M41 * right.M12 + left.M42 * right.M22 + left.M43 * right.M32 + left.M44 * right.M42, left.M41 * right.M13 + left.M42 * right.M23 + left.M43 * right.M33 + left.M44 * right.M43, left.M41 * right.M14 + left.M42 * right.M24 + left.M43 * right.M34 + left.M44 * right.M44);
	}

	public static void Multiply(Matrix4D left, Matrix4D right, ref Matrix4D result)
	{
		result.M11 = left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31 + left.M14 * right.M41;
		result.M12 = left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32 + left.M14 * right.M42;
		result.M13 = left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33 + left.M14 * right.M43;
		result.M14 = left.M11 * right.M14 + left.M12 * right.M24 + left.M13 * right.M34 + left.M14 * right.M44;
		result.M21 = left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31 + left.M24 * right.M41;
		result.M22 = left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32 + left.M24 * right.M42;
		result.M23 = left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33 + left.M24 * right.M43;
		result.M24 = left.M21 * right.M14 + left.M22 * right.M24 + left.M23 * right.M34 + left.M24 * right.M44;
		result.M31 = left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31 + left.M34 * right.M41;
		result.M32 = left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32 + left.M34 * right.M42;
		result.M33 = left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33 + left.M34 * right.M43;
		result.M34 = left.M31 * right.M14 + left.M32 * right.M24 + left.M33 * right.M34 + left.M34 * right.M44;
		result.M41 = left.M41 * right.M11 + left.M42 * right.M21 + left.M43 * right.M31 + left.M44 * right.M41;
		result.M42 = left.M41 * right.M12 + left.M42 * right.M22 + left.M43 * right.M32 + left.M44 * right.M42;
		result.M43 = left.M41 * right.M13 + left.M42 * right.M23 + left.M43 * right.M33 + left.M44 * right.M43;
		result.M44 = left.M41 * right.M14 + left.M42 * right.M24 + left.M43 * right.M34 + left.M44 * right.M44;
	}

	public static Vector4D Transform(Matrix4D matrix, Vector4D vector)
	{
		return new Vector4D(matrix.M11 * vector.X + matrix.M12 * vector.Y + matrix.M13 * vector.Z + matrix.M14 * vector.W, matrix.M21 * vector.X + matrix.M22 * vector.Y + matrix.M23 * vector.Z + matrix.M24 * vector.W, matrix.M31 * vector.X + matrix.M32 * vector.Y + matrix.M33 * vector.Z + matrix.M34 * vector.W, matrix.M41 * vector.X + matrix.M42 * vector.Y + matrix.M43 * vector.Z + matrix.M44 * vector.W);
	}

	public static void Transform(Matrix4D matrix, Vector4D vector, ref Vector4D result)
	{
		result.X = matrix.M11 * vector.X + matrix.M12 * vector.Y + matrix.M13 * vector.Z + matrix.M14 * vector.W;
		result.Y = matrix.M21 * vector.X + matrix.M22 * vector.Y + matrix.M23 * vector.Z + matrix.M24 * vector.W;
		result.Z = matrix.M31 * vector.X + matrix.M32 * vector.Y + matrix.M33 * vector.Z + matrix.M34 * vector.W;
		result.W = matrix.M41 * vector.X + matrix.M42 * vector.Y + matrix.M43 * vector.Z + matrix.M44 * vector.W;
	}

	public static Matrix4D Transpose(Matrix4D m)
	{
		Matrix4D result = new Matrix4D(m);
		result.Transpose();
		return result;
	}

	public override int GetHashCode()
	{
		return double_0.GetHashCode() ^ double_1.GetHashCode() ^ double_2.GetHashCode() ^ double_3.GetHashCode() ^ double_4.GetHashCode() ^ double_5.GetHashCode() ^ double_6.GetHashCode() ^ double_7.GetHashCode() ^ double_8.GetHashCode() ^ double_9.GetHashCode() ^ double_10.GetHashCode() ^ double_11.GetHashCode() ^ double_12.GetHashCode() ^ double_13.GetHashCode() ^ double_14.GetHashCode() ^ double_15.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Matrix4D matrix4D)
		{
			if (double_0 == matrix4D.M11 && double_1 == matrix4D.M12 && double_2 == matrix4D.M13 && double_3 == matrix4D.M14 && double_4 == matrix4D.M21 && double_5 == matrix4D.M22 && double_6 == matrix4D.M23 && double_7 == matrix4D.M24 && double_8 == matrix4D.M31 && double_9 == matrix4D.M32 && double_10 == matrix4D.M33 && double_11 == matrix4D.M34 && double_12 == matrix4D.M41 && double_13 == matrix4D.M42 && double_14 == matrix4D.M43)
			{
				return double_15 == matrix4D.M44;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "4x4[{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}]", double_0, double_1, double_2, double_3, double_4, double_5, double_6, double_7, double_8, double_9, double_10, double_11, double_12, double_13, double_14, double_15);
	}

	public double GetDeterminant()
	{
		return double_3 * double_6 * double_9 * double_12 - double_2 * double_7 * double_9 * double_12 - double_3 * double_5 * double_10 * double_12 + double_1 * double_7 * double_10 * double_12 + double_2 * double_5 * double_11 * double_12 - double_1 * double_6 * double_11 * double_12 - double_3 * double_6 * double_8 * double_13 + double_2 * double_7 * double_8 * double_13 + double_3 * double_4 * double_10 * double_13 - double_0 * double_7 * double_10 * double_13 - double_2 * double_4 * double_11 * double_13 + double_0 * double_6 * double_11 * double_13 + double_3 * double_5 * double_8 * double_14 - double_1 * double_7 * double_8 * double_14 - double_3 * double_4 * double_9 * double_14 + double_0 * double_7 * double_9 * double_14 + double_1 * double_4 * double_11 * double_14 - double_0 * double_5 * double_11 * double_14 - double_2 * double_5 * double_8 * double_15 + double_1 * double_6 * double_8 * double_15 + double_2 * double_4 * double_9 * double_15 - double_0 * double_6 * double_9 * double_15 - double_1 * double_4 * double_10 * double_15 + double_0 * double_5 * double_10 * double_15;
	}

	public void Transpose()
	{
		MathFunctions.Swap(ref double_1, ref double_4);
		MathFunctions.Swap(ref double_2, ref double_8);
		MathFunctions.Swap(ref double_3, ref double_12);
		MathFunctions.Swap(ref double_6, ref double_9);
		MathFunctions.Swap(ref double_7, ref double_13);
		MathFunctions.Swap(ref double_11, ref double_14);
	}

	public static bool operator ==(Matrix4D left, Matrix4D right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Matrix4D left, Matrix4D right)
	{
		return !object.Equals(left, right);
	}

	public static Matrix4D operator +(Matrix4D left, Matrix4D right)
	{
		return Add(left, right);
	}

	public static Matrix4D operator +(Matrix4D matrix, double scalar)
	{
		return Add(matrix, scalar);
	}

	public static Matrix4D operator +(double scalar, Matrix4D matrix)
	{
		return Add(matrix, scalar);
	}

	public static Matrix4D operator -(Matrix4D left, Matrix4D right)
	{
		return Subtract(left, right);
	}

	public static Matrix4D operator -(Matrix4D matrix, double scalar)
	{
		return Subtract(matrix, scalar);
	}

	public static Matrix4D operator *(Matrix4D left, Matrix4D right)
	{
		return Multiply(left, right);
	}

	public static Vector4D operator *(Matrix4D matrix, Vector4D vector)
	{
		return Transform(matrix, vector);
	}

	static Matrix4D()
	{
		Class72.smethod_20();
		Zero = new Matrix4D(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
		Identity = new Matrix4D(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
	}
}
