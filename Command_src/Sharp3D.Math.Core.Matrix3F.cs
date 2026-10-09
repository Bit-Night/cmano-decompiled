using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public struct Matrix3F : ICloneable
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private float float_6;

	private float float_7;

	private float float_8;

	public static readonly Matrix3F Zero;

	public static readonly Matrix3F Identity;

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

	public float M13
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

	public float M21
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

	public float M22
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	public float M23
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
		}
	}

	public float M31
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = value;
		}
	}

	public float M32
	{
		get
		{
			return float_7;
		}
		set
		{
			float_7 = value;
		}
	}

	public float M33
	{
		get
		{
			return float_8;
		}
		set
		{
			float_8 = value;
		}
	}

	public float Trace => float_0 + float_4 + float_8;

	public unsafe float this[int index]
	{
		get
		{
			if (index < 0 || index >= 9)
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
			if (index < 0 || index >= 9)
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
			return this[(row - 1) * 3 + (column - 1)];
		}
		set
		{
			this[(row - 1) * 3 + (column - 1)] = value;
		}
	}

	public Matrix3F(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
	{
		float_0 = m11;
		float_1 = m12;
		float_2 = m13;
		float_3 = m21;
		float_4 = m22;
		float_5 = m23;
		float_6 = m31;
		float_7 = m32;
		float_8 = m33;
	}

	public Matrix3F(float[] elements)
	{
		float_0 = elements[0];
		float_1 = elements[1];
		float_2 = elements[2];
		float_3 = elements[3];
		float_4 = elements[4];
		float_5 = elements[5];
		float_6 = elements[6];
		float_7 = elements[7];
		float_8 = elements[8];
	}

	public Matrix3F(List<float> elements)
	{
		float_0 = elements[0];
		float_1 = elements[1];
		float_2 = elements[2];
		float_3 = elements[3];
		float_4 = elements[4];
		float_5 = elements[5];
		float_6 = elements[6];
		float_7 = elements[7];
		float_8 = elements[8];
	}

	public Matrix3F(Vector3F column1, Vector3F column2, Vector3F column3)
	{
		float_0 = column1.X;
		float_1 = column2.X;
		float_2 = column3.X;
		float_3 = column1.Y;
		float_4 = column2.Y;
		float_5 = column3.Y;
		float_6 = column1.Z;
		float_7 = column2.Z;
		float_8 = column3.Z;
	}

	public Matrix3F(Matrix3F m)
	{
		float_0 = m.M11;
		float_1 = m.M12;
		float_2 = m.M13;
		float_3 = m.M21;
		float_4 = m.M22;
		float_5 = m.M23;
		float_6 = m.M31;
		float_7 = m.M32;
		float_8 = m.M33;
	}

	object ICloneable.Clone()
	{
		return new Matrix3F(this);
	}

	public Matrix3F Clone()
	{
		return new Matrix3F(this);
	}

	public static Matrix3F Parse(string value)
	{
		Match match = new Regex("3x3\\s*\\[(?<m11>.*),(?<m12>.*),(?<m13>.*),(?<m21>.*),(?<m22>.*),(?<m23>.*),(?<m31>.*),(?<m32>.*),(?<m33>.*)\\]", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Matrix3F(float.Parse(match.Result("${m11}")), float.Parse(match.Result("${m12}")), float.Parse(match.Result("${m13}")), float.Parse(match.Result("${m21}")), float.Parse(match.Result("${m22}")), float.Parse(match.Result("${m23}")), float.Parse(match.Result("${m31}")), float.Parse(match.Result("${m32}")), float.Parse(match.Result("${m33}")));
	}

	public static bool TryParse(string value, out Matrix3F result)
	{
		Match match = new Regex("3x3\\s*\\[(?<m11>.*),(?<m12>.*),(?<m13>.*),(?<m21>.*),(?<m22>.*),(?<m23>.*),(?<m31>.*),(?<m32>.*),(?<m33>.*)\\]", RegexOptions.Singleline).Match(value);
		if (!match.Success)
		{
			result = Zero;
			return false;
		}
		result = new Matrix3F(float.Parse(match.Result("${m11}")), float.Parse(match.Result("${m12}")), float.Parse(match.Result("${m13}")), float.Parse(match.Result("${m21}")), float.Parse(match.Result("${m22}")), float.Parse(match.Result("${m23}")), float.Parse(match.Result("${m31}")), float.Parse(match.Result("${m32}")), float.Parse(match.Result("${m33}")));
		return true;
	}

	public static Matrix3F Add(Matrix3F left, Matrix3F right)
	{
		return new Matrix3F(left.M11 + right.M11, left.M12 + right.M12, left.M13 + right.M13, left.M21 + right.M21, left.M22 + right.M22, left.M23 + right.M23, left.M31 + right.M31, left.M32 + right.M32, left.M33 + right.M33);
	}

	public static Matrix3F Add(Matrix3F matrix, float scalar)
	{
		return new Matrix3F(matrix.M11 + scalar, matrix.M12 + scalar, matrix.M13 + scalar, matrix.M21 + scalar, matrix.M22 + scalar, matrix.M23 + scalar, matrix.M31 + scalar, matrix.M32 + scalar, matrix.M33 + scalar);
	}

	public static void Add(Matrix3F left, Matrix3F right, ref Matrix3F result)
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

	public static void Add(Matrix3F matrix, float scalar, ref Matrix3F result)
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

	public static Matrix3F Subtract(Matrix3F left, Matrix3F right)
	{
		return new Matrix3F(left.M11 - right.M11, left.M12 - right.M12, left.M13 - right.M13, left.M21 - right.M21, left.M22 - right.M22, left.M23 - right.M23, left.M31 - right.M31, left.M32 - right.M32, left.M33 - right.M33);
	}

	public static Matrix3F Subtract(Matrix3F matrix, float scalar)
	{
		return new Matrix3F(matrix.M11 - scalar, matrix.M12 - scalar, matrix.M13 - scalar, matrix.M21 - scalar, matrix.M22 - scalar, matrix.M23 - scalar, matrix.M31 - scalar, matrix.M32 - scalar, matrix.M33 - scalar);
	}

	public static void Subtract(Matrix3F left, Matrix3F right, ref Matrix3F result)
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

	public static void Subtract(Matrix3F matrix, float scalar, ref Matrix3F result)
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

	public static Matrix3F Multiply(Matrix3F left, Matrix3F right)
	{
		return new Matrix3F(left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31, left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32, left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33, left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31, left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32, left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33, left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31, left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32, left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33);
	}

	public static void Multiply(Matrix3F left, Matrix3F right, ref Matrix3F result)
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

	public static Vector3F Transform(Matrix3F matrix, Vector3F vector)
	{
		return new Vector3F(matrix.M11 * vector.X + matrix.M12 * vector.Y + matrix.M13 * vector.Z, matrix.M21 * vector.X + matrix.M22 * vector.Y + matrix.M23 * vector.Z, matrix.M31 * vector.X + matrix.M32 * vector.Y + matrix.M33 * vector.Z);
	}

	public static void Transform(Matrix3F matrix, Vector3F vector, ref Vector3F result)
	{
		result.X = matrix.M11 * vector.X + matrix.M12 * vector.Y + matrix.M13 * vector.Z;
		result.Y = matrix.M21 * vector.X + matrix.M22 * vector.Y + matrix.M23 * vector.Z;
		result.Z = matrix.M31 * vector.X + matrix.M32 * vector.Y + matrix.M33 * vector.Z;
	}

	public static Matrix3F Transpose(Matrix3F m)
	{
		Matrix3F result = new Matrix3F(m);
		result.Transpose();
		return result;
	}

	public override int GetHashCode()
	{
		return float_0.GetHashCode() ^ float_1.GetHashCode() ^ float_2.GetHashCode() ^ float_3.GetHashCode() ^ float_4.GetHashCode() ^ float_5.GetHashCode() ^ float_6.GetHashCode() ^ float_7.GetHashCode() ^ float_8.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Matrix3F matrix3F)
		{
			if (float_0 == matrix3F.M11 && float_1 == matrix3F.M12 && float_2 == matrix3F.M13 && float_3 == matrix3F.M21 && float_4 == matrix3F.M22 && float_5 == matrix3F.M23 && float_6 == matrix3F.M31 && float_7 == matrix3F.M32)
			{
				return float_8 == matrix3F.M33;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "3x3[{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}]", float_0, float_1, float_2, float_3, float_4, float_5, float_6, float_7, float_8);
	}

	public float GetDeterminant()
	{
		return float_0 * float_4 * float_8 + float_1 * float_5 * float_6 + float_2 * float_3 * float_7 - float_2 * float_4 * float_6 - float_0 * float_5 * float_7 - float_1 * float_3 * float_8;
	}

	public void Transpose()
	{
		MathFunctions.Swap(ref float_1, ref float_3);
		MathFunctions.Swap(ref float_2, ref float_6);
		MathFunctions.Swap(ref float_5, ref float_7);
	}

	public static bool operator ==(Matrix3F left, Matrix3F right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Matrix3F left, Matrix3F right)
	{
		return !object.Equals(left, right);
	}

	public static Matrix3F operator +(Matrix3F left, Matrix3F right)
	{
		return Add(left, right);
	}

	public static Matrix3F operator +(Matrix3F matrix, float scalar)
	{
		return Add(matrix, scalar);
	}

	public static Matrix3F operator +(float scalar, Matrix3F matrix)
	{
		return Add(matrix, scalar);
	}

	public static Matrix3F operator -(Matrix3F left, Matrix3F right)
	{
		return Subtract(left, right);
	}

	public static Matrix3F operator -(Matrix3F matrix, float scalar)
	{
		return Subtract(matrix, scalar);
	}

	public static Matrix3F operator *(Matrix3F left, Matrix3F right)
	{
		return Multiply(left, right);
	}

	public static Vector3F operator *(Matrix3F matrix, Vector3F vector)
	{
		return Transform(matrix, vector);
	}

	static Matrix3F()
	{
		Class72.smethod_20();
		Zero = new Matrix3F(0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);
		Identity = new Matrix3F(1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 1f);
	}
}
