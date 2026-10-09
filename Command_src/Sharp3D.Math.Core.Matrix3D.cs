using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public struct Matrix3D : ICloneable
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

	public static readonly Matrix3D Zero;

	public static readonly Matrix3D Identity;

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

	public double M21
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

	public double M22
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

	public double M23
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

	public double M31
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

	public double M32
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

	public double M33
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

	public double Trace => double_0 + double_4 + double_8;

	public unsafe double this[int index]
	{
		get
		{
			if (index < 0 || index >= 9)
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
			if (index < 0 || index >= 9)
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
			return this[(row - 1) * 3 + (column - 1)];
		}
		set
		{
			this[(row - 1) * 3 + (column - 1)] = value;
		}
	}

	public Matrix3D(double m11, double m12, double m13, double m21, double m22, double m23, double m31, double m32, double m33)
	{
		double_0 = m11;
		double_1 = m12;
		double_2 = m13;
		double_3 = m21;
		double_4 = m22;
		double_5 = m23;
		double_6 = m31;
		double_7 = m32;
		double_8 = m33;
	}

	public Matrix3D(double[] elements)
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
	}

	public Matrix3D(List<double> elements)
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
	}

	public Matrix3D(Vector3D column1, Vector3D column2, Vector3D column3)
	{
		double_0 = column1.X;
		double_1 = column2.X;
		double_2 = column3.X;
		double_3 = column1.Y;
		double_4 = column2.Y;
		double_5 = column3.Y;
		double_6 = column1.Z;
		double_7 = column2.Z;
		double_8 = column3.Z;
	}

	public Matrix3D(Matrix3D m)
	{
		double_0 = m.M11;
		double_1 = m.M12;
		double_2 = m.M13;
		double_3 = m.M21;
		double_4 = m.M22;
		double_5 = m.M23;
		double_6 = m.M31;
		double_7 = m.M32;
		double_8 = m.M33;
	}

	object ICloneable.Clone()
	{
		return new Matrix3D(this);
	}

	public Matrix3D Clone()
	{
		return new Matrix3D(this);
	}

	public static Matrix3D Parse(string value)
	{
		Match match = new Regex("3x3\\s*\\[(?<m11>.*),(?<m12>.*),(?<m13>.*),(?<m21>.*),(?<m22>.*),(?<m23>.*),(?<m31>.*),(?<m32>.*),(?<m33>.*)\\]", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Matrix3D(double.Parse(match.Result("${m11}")), double.Parse(match.Result("${m12}")), double.Parse(match.Result("${m13}")), double.Parse(match.Result("${m21}")), double.Parse(match.Result("${m22}")), double.Parse(match.Result("${m23}")), double.Parse(match.Result("${m31}")), double.Parse(match.Result("${m32}")), double.Parse(match.Result("${m33}")));
	}

	public static bool TryParse(string value, out Matrix3D result)
	{
		Match match = new Regex("3x3\\s*\\[(?<m11>.*),(?<m12>.*),(?<m13>.*),(?<m21>.*),(?<m22>.*),(?<m23>.*),(?<m31>.*),(?<m32>.*),(?<m33>.*)\\]", RegexOptions.Singleline).Match(value);
		if (match.Success)
		{
			result = new Matrix3D(double.Parse(match.Result("${m11}")), double.Parse(match.Result("${m12}")), double.Parse(match.Result("${m13}")), double.Parse(match.Result("${m21}")), double.Parse(match.Result("${m22}")), double.Parse(match.Result("${m23}")), double.Parse(match.Result("${m31}")), double.Parse(match.Result("${m32}")), double.Parse(match.Result("${m33}")));
			return true;
		}
		result = Zero;
		return false;
	}

	public static Matrix3D Add(Matrix3D left, Matrix3D right)
	{
		return new Matrix3D(left.M11 + right.M11, left.M12 + right.M12, left.M13 + right.M13, left.M21 + right.M21, left.M22 + right.M22, left.M23 + right.M23, left.M31 + right.M31, left.M32 + right.M32, left.M33 + right.M33);
	}

	public static Matrix3D Add(Matrix3D matrix, double scalar)
	{
		return new Matrix3D(matrix.M11 + scalar, matrix.M12 + scalar, matrix.M13 + scalar, matrix.M21 + scalar, matrix.M22 + scalar, matrix.M23 + scalar, matrix.M31 + scalar, matrix.M32 + scalar, matrix.M33 + scalar);
	}

	public static void Add(Matrix3D left, Matrix3D right, ref Matrix3D result)
	{
		result.M11 = left.M11 + right.M11;
		result.M12 = left.M12 + right.M12;
		result.M13 = left.M13 + right.M13;
		result.M21 = left.M21 + right.M21;
		result.M22 = left.M22 + right.M22;
		result.M23 = left.M23 + right.M23;
		result.M31 = left.M31 + right.M31;
		result.M32 = left.M32 + right.M32;
		result.M33 = left.M33 + right.M33;
	}

	public static void Add(Matrix3D matrix, double scalar, ref Matrix3D result)
	{
		result.M11 = matrix.M11 + scalar;
		result.M12 = matrix.M12 + scalar;
		result.M13 = matrix.M13 + scalar;
		result.M21 = matrix.M21 + scalar;
		result.M22 = matrix.M22 + scalar;
		result.M23 = matrix.M23 + scalar;
		result.M31 = matrix.M31 + scalar;
		result.M32 = matrix.M32 + scalar;
		result.M33 = matrix.M33 + scalar;
	}

	public static Matrix3D Subtract(Matrix3D left, Matrix3D right)
	{
		return new Matrix3D(left.M11 - right.M11, left.M12 - right.M12, left.M13 - right.M13, left.M21 - right.M21, left.M22 - right.M22, left.M23 - right.M23, left.M31 - right.M31, left.M32 - right.M32, left.M33 - right.M33);
	}

	public static Matrix3D Subtract(Matrix3D matrix, double scalar)
	{
		return new Matrix3D(matrix.M11 - scalar, matrix.M12 - scalar, matrix.M13 - scalar, matrix.M21 - scalar, matrix.M22 - scalar, matrix.M23 - scalar, matrix.M31 - scalar, matrix.M32 - scalar, matrix.M33 - scalar);
	}

	public static void Subtract(Matrix3D left, Matrix3D right, ref Matrix3D result)
	{
		result.M11 = left.M11 - right.M11;
		result.M12 = left.M12 - right.M12;
		result.M13 = left.M13 - right.M13;
		result.M21 = left.M21 - right.M21;
		result.M22 = left.M22 - right.M22;
		result.M23 = left.M23 - right.M23;
		result.M31 = left.M31 - right.M31;
		result.M32 = left.M32 - right.M32;
		result.M33 = left.M33 - right.M33;
	}

	public static void Subtract(Matrix3D matrix, double scalar, ref Matrix3D result)
	{
		result.M11 = matrix.M11 - scalar;
		result.M12 = matrix.M12 - scalar;
		result.M13 = matrix.M13 - scalar;
		result.M21 = matrix.M21 - scalar;
		result.M22 = matrix.M22 - scalar;
		result.M23 = matrix.M23 - scalar;
		result.M31 = matrix.M31 - scalar;
		result.M32 = matrix.M32 - scalar;
		result.M33 = matrix.M33 - scalar;
	}

	public static Matrix3D Multiply(Matrix3D left, Matrix3D right)
	{
		return new Matrix3D(left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31, left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32, left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33, left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31, left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32, left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33, left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31, left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32, left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33);
	}

	public static void Multiply(Matrix3D left, Matrix3D right, ref Matrix3D result)
	{
		result.M11 = left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31;
		result.M12 = left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32;
		result.M13 = left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33;
		result.M21 = left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31;
		result.M22 = left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32;
		result.M23 = left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33;
		result.M31 = left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31;
		result.M32 = left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32;
		result.M33 = left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33;
	}

	public static Vector3D Transform(Matrix3D matrix, Vector3D vector)
	{
		return new Vector3D(matrix.M11 * vector.X + matrix.M12 * vector.Y + matrix.M13 * vector.Z, matrix.M21 * vector.X + matrix.M22 * vector.Y + matrix.M23 * vector.Z, matrix.M31 * vector.X + matrix.M32 * vector.Y + matrix.M33 * vector.Z);
	}

	public static void Transform(Matrix3D matrix, Vector3D vector, ref Vector3D result)
	{
		result.X = matrix.M11 * vector.X + matrix.M12 * vector.Y + matrix.M13 * vector.Z;
		result.Y = matrix.M21 * vector.X + matrix.M22 * vector.Y + matrix.M23 * vector.Z;
		result.Z = matrix.M31 * vector.X + matrix.M32 * vector.Y + matrix.M33 * vector.Z;
	}

	public static Matrix3D Transpose(Matrix3D m)
	{
		Matrix3D result = new Matrix3D(m);
		result.Transpose();
		return result;
	}

	public static Matrix3D Inverse(Matrix3D m)
	{
		double num = 1.0 / m.GetDeterminant();
		return new Matrix3D(num * (m.double_8 * m.double_4 - m.double_7 * m.double_5), (0.0 - num) * (m.double_8 * m.double_1 - m.double_7 * m.double_2), num * (m.double_5 * m.double_1 - m.double_4 * m.double_2), (0.0 - num) * (m.double_8 * m.double_3 - m.double_6 * m.double_5), num * (m.double_8 * m.double_0 - m.double_6 * m.double_2), (0.0 - num) * (m.double_5 * m.double_0 - m.double_3 * m.double_2), num * (m.double_7 * m.double_3 - m.double_6 * m.double_4), (0.0 - num) * (m.double_7 * m.double_0 - m.double_6 * m.double_1), num * (m.double_4 * m.double_0 - m.double_3 * m.double_1));
	}

	public override int GetHashCode()
	{
		return double_0.GetHashCode() ^ double_1.GetHashCode() ^ double_2.GetHashCode() ^ double_3.GetHashCode() ^ double_4.GetHashCode() ^ double_5.GetHashCode() ^ double_6.GetHashCode() ^ double_7.GetHashCode() ^ double_8.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Matrix3D matrix3D))
		{
			return false;
		}
		if (double_0 == matrix3D.M11 && double_1 == matrix3D.M12 && double_2 == matrix3D.M13 && double_3 == matrix3D.M21 && double_4 == matrix3D.M22 && double_5 == matrix3D.M23 && double_6 == matrix3D.M31 && double_7 == matrix3D.M32)
		{
			return double_8 == matrix3D.M33;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "3x3[{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}]", double_0, double_1, double_2, double_3, double_4, double_5, double_6, double_7, double_8);
	}

	public double GetDeterminant()
	{
		return double_0 * double_4 * double_8 + double_1 * double_5 * double_6 + double_2 * double_3 * double_7 - double_2 * double_4 * double_6 - double_0 * double_5 * double_7 - double_1 * double_3 * double_8;
	}

	public void Transpose()
	{
		MathFunctions.Swap(ref double_1, ref double_3);
		MathFunctions.Swap(ref double_2, ref double_6);
		MathFunctions.Swap(ref double_5, ref double_7);
	}

	public static bool operator ==(Matrix3D left, Matrix3D right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Matrix3D left, Matrix3D right)
	{
		return !object.Equals(left, right);
	}

	public static Matrix3D operator +(Matrix3D left, Matrix3D right)
	{
		return Add(left, right);
	}

	public static Matrix3D operator +(Matrix3D matrix, double scalar)
	{
		return Add(matrix, scalar);
	}

	public static Matrix3D operator +(double scalar, Matrix3D matrix)
	{
		return Add(matrix, scalar);
	}

	public static Matrix3D operator -(Matrix3D left, Matrix3D right)
	{
		return Subtract(left, right);
	}

	public static Matrix3D operator -(Matrix3D matrix, double scalar)
	{
		return Subtract(matrix, scalar);
	}

	public static Matrix3D operator *(Matrix3D left, Matrix3D right)
	{
		return Multiply(left, right);
	}

	public static Vector3D operator *(Matrix3D matrix, Vector3D vector)
	{
		return Transform(matrix, vector);
	}

	static Matrix3D()
	{
		Class72.smethod_20();
		Zero = new Matrix3D(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
		Identity = new Matrix3D(1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0);
	}
}
