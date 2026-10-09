using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public struct Matrix2D : ICloneable
{
	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	public static readonly Matrix2D Zero;

	public static readonly Matrix2D Identity;

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

	public double M21
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

	public double M22
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

	public double Trace => double_0 + double_3;

	public unsafe double this[int index]
	{
		get
		{
			if (index < 0 || index >= 4)
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
			if (index < 0 || index >= 4)
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
			return this[(row - 1) * 2 + (column - 1)];
		}
		set
		{
			this[(row - 1) * 2 + (column - 1)] = value;
		}
	}

	public Matrix2D(double m11, double m12, double m21, double m22)
	{
		double_0 = m11;
		double_1 = m12;
		double_2 = m21;
		double_3 = m22;
	}

	public Matrix2D(double[] elements)
	{
		double_0 = elements[0];
		double_1 = elements[1];
		double_2 = elements[2];
		double_3 = elements[3];
	}

	public Matrix2D(List<double> elements)
	{
		double_0 = elements[0];
		double_1 = elements[1];
		double_2 = elements[2];
		double_3 = elements[3];
	}

	public Matrix2D(Vector2D column1, Vector2D column2)
	{
		double_0 = column1.X;
		double_1 = column2.X;
		double_2 = column1.Y;
		double_3 = column2.Y;
	}

	public Matrix2D(Matrix2D m)
	{
		double_0 = m.M11;
		double_1 = m.M12;
		double_2 = m.M21;
		double_3 = m.M22;
	}

	object ICloneable.Clone()
	{
		return new Matrix2D(this);
	}

	public Matrix2D Clone()
	{
		return new Matrix2D(this);
	}

	public static Matrix2D Parse(string value)
	{
		Match match = new Regex("2x2\\s*\\[(?<m11>.*),(?<m12>.*),(?<m21>.*),(?<m22>.*)\\]", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Matrix2D(double.Parse(match.Result("${m11}")), double.Parse(match.Result("${m12}")), double.Parse(match.Result("${m21}")), double.Parse(match.Result("${m22}")));
	}

	public static bool TryParse(string value, out Matrix2D result)
	{
		Match match = new Regex("2x2\\s*\\[(?<m11>.*),(?<m12>.*),(?<m21>.*),(?<m22>.*)\\]", RegexOptions.Singleline).Match(value);
		if (!match.Success)
		{
			result = Zero;
			return false;
		}
		result = new Matrix2D(double.Parse(match.Result("${m11}")), double.Parse(match.Result("${m12}")), double.Parse(match.Result("${m21}")), double.Parse(match.Result("${m22}")));
		return true;
	}

	public static Matrix2D Add(Matrix2D left, Matrix2D right)
	{
		return new Matrix2D(left.M11 + right.M11, left.M12 + right.M12, left.M21 + right.M21, left.M22 + right.M22);
	}

	public static Matrix2D Add(Matrix2D matrix, double scalar)
	{
		return new Matrix2D(matrix.M11 + scalar, matrix.M12 + scalar, matrix.M21 + scalar, matrix.M22 + scalar);
	}

	public static void Add(Matrix2D left, Matrix2D right, ref Matrix2D result)
	{
		result.M11 = left.M11 + right.M11;
		result.M12 = left.M12 + right.M12;
		result.M21 = left.M21 + right.M21;
		result.M22 = left.M22 + right.M22;
	}

	public static void Add(Matrix2D matrix, double scalar, ref Matrix2D result)
	{
		result.M11 = matrix.M11 + scalar;
		result.M12 = matrix.M12 + scalar;
		result.M21 = matrix.M21 + scalar;
		result.M22 = matrix.M22 + scalar;
	}

	public static Matrix2D Subtract(Matrix2D left, Matrix2D right)
	{
		return new Matrix2D(left.M11 - right.M11, left.M12 - right.M12, left.M21 - right.M21, left.M22 - right.M22);
	}

	public static Matrix2D Subtract(Matrix2D matrix, double scalar)
	{
		return new Matrix2D(matrix.M11 - scalar, matrix.M12 - scalar, matrix.M21 - scalar, matrix.M22 - scalar);
	}

	public static void Subtract(Matrix2D left, Matrix2D right, ref Matrix2D result)
	{
		result.M11 = left.M11 - right.M11;
		result.M12 = left.M12 - right.M12;
		result.M21 = left.M21 - right.M21;
		result.M22 = left.M22 - right.M22;
	}

	public static void Subtract(Matrix2D matrix, double scalar, ref Matrix2D result)
	{
		result.M11 = matrix.M11 - scalar;
		result.M12 = matrix.M12 - scalar;
		result.M21 = matrix.M21 - scalar;
		result.M22 = matrix.M22 - scalar;
	}

	public static Matrix2D Multiply(Matrix2D left, Matrix2D right)
	{
		return new Matrix2D(left.M11 * right.M11 + left.M12 * right.M21, left.M11 * right.M12 + left.M12 * right.M22, left.M21 * right.M11 + left.M22 * right.M21, left.M21 * right.M12 + left.M22 * right.M22);
	}

	public static void Multiply(Matrix2D left, Matrix2D right, ref Matrix2D result)
	{
		result.M11 = left.M11 * right.M11 + left.M12 * right.M21;
		result.M12 = left.M11 * right.M12 + left.M12 * right.M22;
		result.M21 = left.M21 * right.M11 + left.M22 * right.M21;
		result.M22 = left.M21 * right.M12 + left.M22 * right.M22;
	}

	public static Vector2D Transform(Matrix2D matrix, Vector2D vector)
	{
		return new Vector2D(matrix.M11 * vector.X + matrix.M12 * vector.Y, matrix.M21 * vector.X + matrix.M22 * vector.Y);
	}

	public static void Transform(Matrix2D matrix, Vector2D vector, ref Vector2D result)
	{
		result.X = matrix.M11 * vector.X + matrix.M12 * vector.Y;
		result.Y = matrix.M21 * vector.X + matrix.M22 * vector.Y;
	}

	public static Matrix2D Transpose(Matrix2D m)
	{
		Matrix2D result = new Matrix2D(m);
		result.Transpose();
		return result;
	}

	public override int GetHashCode()
	{
		return double_0.GetHashCode() ^ double_1.GetHashCode() ^ double_2.GetHashCode() ^ double_3.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Matrix2D matrix2D)
		{
			if (double_0 == matrix2D.M11 && double_1 == matrix2D.M12 && double_2 == matrix2D.M21)
			{
				return double_3 == matrix2D.M22;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "2x2[{0}, {1}, {2}, {3}]", double_0, double_1, double_2, double_3);
	}

	public double GetDeterminant()
	{
		return double_0 * double_3 - double_1 * double_2;
	}

	public void Transpose()
	{
		MathFunctions.Swap(ref double_1, ref double_2);
	}

	public static bool operator ==(Matrix2D left, Matrix2D right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Matrix2D left, Matrix2D right)
	{
		return !object.Equals(left, right);
	}

	public static Matrix2D operator +(Matrix2D left, Matrix2D right)
	{
		return Add(left, right);
	}

	public static Matrix2D operator +(Matrix2D matrix, double scalar)
	{
		return Add(matrix, scalar);
	}

	public static Matrix2D operator +(double scalar, Matrix2D matrix)
	{
		return Add(matrix, scalar);
	}

	public static Matrix2D operator -(Matrix2D left, Matrix2D right)
	{
		return Subtract(left, right);
	}

	public static Matrix2D operator -(Matrix2D matrix, double scalar)
	{
		return Subtract(matrix, scalar);
	}

	public static Matrix2D operator *(Matrix2D left, Matrix2D right)
	{
		return Multiply(left, right);
	}

	public static Vector2D operator *(Matrix2D matrix, Vector2D vector)
	{
		return Transform(matrix, vector);
	}

	static Matrix2D()
	{
		Class72.smethod_20();
		Zero = new Matrix2D(0.0, 0.0, 0.0, 0.0);
		Identity = new Matrix2D(1.0, 0.0, 0.0, 1.0);
	}
}
