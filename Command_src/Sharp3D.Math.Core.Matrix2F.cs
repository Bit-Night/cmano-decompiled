using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public struct Matrix2F : ICloneable
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	public static readonly Matrix2F Zero;

	public static readonly Matrix2F Identity;

	public float M11
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public float M12
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public float M21
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	public float M22
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	public float Trace => float_0 + float_3;

	public unsafe float this[int index]
	{
		get
		{
			if (index < 0 || index >= 4)
			{
				throw new IndexOutOfRangeException("Invalid matrix index!");
			}
			fixed (float* ptr = &float_0)
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
			fixed (float* ptr = &float_0)
			{
				ptr[index] = value;
			}
		}
	}

	public float this[int row, int column]
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

	public Matrix2F(float m11, float m12, float m21, float m22)
	{
		float_0 = m11;
		float_1 = m12;
		float_2 = m21;
		float_3 = m22;
	}

	public Matrix2F(float[] elements)
	{
		float_0 = elements[0];
		float_1 = elements[1];
		float_2 = elements[2];
		float_3 = elements[3];
	}

	public Matrix2F(List<float> elements)
	{
		float_0 = elements[0];
		float_1 = elements[1];
		float_2 = elements[2];
		float_3 = elements[3];
	}

	public Matrix2F(Vector2F column1, Vector2F column2)
	{
		float_0 = column1.X;
		float_1 = column2.X;
		float_2 = column1.Y;
		float_3 = column2.Y;
	}

	public Matrix2F(Matrix2F m)
	{
		float_0 = m.M11;
		float_1 = m.M12;
		float_2 = m.M21;
		float_3 = m.M22;
	}

	object ICloneable.Clone()
	{
		return new Matrix2F(this);
	}

	public Matrix2F Clone()
	{
		return new Matrix2F(this);
	}

	public static Matrix2F Parse(string value)
	{
		Match match = new Regex("2x2\\s*\\[(?<m11>.*),(?<m12>.*),(?<m21>.*),(?<m22>.*)\\]", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Matrix2F(float.Parse(match.Result("${m11}")), float.Parse(match.Result("${m12}")), float.Parse(match.Result("${m21}")), float.Parse(match.Result("${m22}")));
	}

	public static bool TryParse(string value, out Matrix2F result)
	{
		Match match = new Regex("2x2\\s*\\[(?<m11>.*),(?<m12>.*),(?<m21>.*),(?<m22>.*)\\]", RegexOptions.Singleline).Match(value);
		if (match.Success)
		{
			result = new Matrix2F(float.Parse(match.Result("${m11}")), float.Parse(match.Result("${m12}")), float.Parse(match.Result("${m21}")), float.Parse(match.Result("${m22}")));
			return true;
		}
		result = Zero;
		return false;
	}

	public static Matrix2F Add(Matrix2F left, Matrix2F right)
	{
		return new Matrix2F(left.M11 + right.M11, left.M12 + right.M12, left.M21 + right.M21, left.M22 + right.M22);
	}

	public static Matrix2F Add(Matrix2F matrix, float scalar)
	{
		return new Matrix2F(matrix.M11 + scalar, matrix.M12 + scalar, matrix.M21 + scalar, matrix.M22 + scalar);
	}

	public static void Add(Matrix2F left, Matrix2F right, ref Matrix2F result)
	{
		result.M11 = left.M11 + right.M11;
		result.M12 = left.M12 + right.M12;
		result.M21 = left.M21 + right.M21;
		result.M22 = left.M22 + right.M22;
	}

	public static void Add(Matrix2F matrix, float scalar, ref Matrix2F result)
	{
		result.M11 = matrix.M11 + scalar;
		result.M12 = matrix.M12 + scalar;
		result.M21 = matrix.M21 + scalar;
		result.M22 = matrix.M22 + scalar;
	}

	public static Matrix2F Subtract(Matrix2F left, Matrix2F right)
	{
		return new Matrix2F(left.M11 - right.M11, left.M12 - right.M12, left.M21 - right.M21, left.M22 - right.M22);
	}

	public static Matrix2F Subtract(Matrix2F matrix, float scalar)
	{
		return new Matrix2F(matrix.M11 - scalar, matrix.M12 - scalar, matrix.M21 - scalar, matrix.M22 - scalar);
	}

	public static void Subtract(Matrix2F left, Matrix2F right, ref Matrix2F result)
	{
		result.M11 = left.M11 - right.M11;
		result.M12 = left.M12 - right.M12;
		result.M21 = left.M21 - right.M21;
		result.M22 = left.M22 - right.M22;
	}

	public static void Subtract(Matrix2F matrix, float scalar, ref Matrix2F result)
	{
		result.M11 = matrix.M11 - scalar;
		result.M12 = matrix.M12 - scalar;
		result.M21 = matrix.M21 - scalar;
		result.M22 = matrix.M22 - scalar;
	}

	public static Matrix2F Multiply(Matrix2F left, Matrix2F right)
	{
		return new Matrix2F(left.M11 * right.M11 + left.M12 * right.M21, left.M11 * right.M12 + left.M12 * right.M22, left.M21 * right.M11 + left.M22 * right.M21, left.M21 * right.M12 + left.M22 * right.M22);
	}

	public static void Multiply(Matrix2F left, Matrix2F right, ref Matrix2F result)
	{
		result.M11 = left.M11 * right.M11 + left.M12 * right.M21;
		result.M12 = left.M11 * right.M12 + left.M12 * right.M22;
		result.M21 = left.M21 * right.M11 + left.M22 * right.M21;
		result.M22 = left.M21 * right.M12 + left.M22 * right.M22;
	}

	public static Vector2F Transform(Matrix2F matrix, Vector2F vector)
	{
		return new Vector2F(matrix.M11 * vector.X + matrix.M12 * vector.Y, matrix.M21 * vector.X + matrix.M22 * vector.Y);
	}

	public static void Transform(Matrix2F matrix, Vector2F vector, ref Vector2F result)
	{
		result.X = matrix.M11 * vector.X + matrix.M12 * vector.Y;
		result.Y = matrix.M21 * vector.X + matrix.M22 * vector.Y;
	}

	public static Matrix2F Transpose(Matrix2F m)
	{
		Matrix2F result = new Matrix2F(m);
		result.Transpose();
		return result;
	}

	public override int GetHashCode()
	{
		return float_0.GetHashCode() ^ float_1.GetHashCode() ^ float_2.GetHashCode() ^ float_3.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Matrix2F matrix2F))
		{
			return false;
		}
		if (float_0 == matrix2F.M11 && float_1 == matrix2F.M12 && float_2 == matrix2F.M21)
		{
			return float_3 == matrix2F.M22;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "2x2[{0}, {1}, {2}, {3}]", float_0, float_1, float_2, float_3);
	}

	public float GetDeterminant()
	{
		return float_0 * float_3 - float_1 * float_2;
	}

	public void Transpose()
	{
		MathFunctions.Swap(ref float_1, ref float_2);
	}

	public static bool operator ==(Matrix2F left, Matrix2F right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Matrix2F left, Matrix2F right)
	{
		return !object.Equals(left, right);
	}

	public static Matrix2F operator +(Matrix2F left, Matrix2F right)
	{
		return Add(left, right);
	}

	public static Matrix2F operator +(Matrix2F matrix, float scalar)
	{
		return Add(matrix, scalar);
	}

	public static Matrix2F operator +(float scalar, Matrix2F matrix)
	{
		return Add(matrix, scalar);
	}

	public static Matrix2F operator -(Matrix2F left, Matrix2F right)
	{
		return Subtract(left, right);
	}

	public static Matrix2F operator -(Matrix2F matrix, float scalar)
	{
		return Subtract(matrix, scalar);
	}

	public static Matrix2F operator *(Matrix2F left, Matrix2F right)
	{
		return Multiply(left, right);
	}

	public static Vector2F operator *(Matrix2F matrix, Vector2F vector)
	{
		return Transform(matrix, vector);
	}

	static Matrix2F()
	{
		Class72.smethod_20();
		Zero = new Matrix2F(0f, 0f, 0f, 0f);
		Identity = new Matrix2F(1f, 0f, 0f, 1f);
	}
}
