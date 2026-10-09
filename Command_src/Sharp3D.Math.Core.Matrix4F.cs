using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public struct Matrix4F : ICloneable
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

	private float float_9;

	private float float_10;

	private float float_11;

	private float float_12;

	private float float_13;

	private float float_14;

	private float float_15;

	public static readonly Matrix4F Zero;

	public static readonly Matrix4F Identity;

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

	public float M14
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

	public float M21
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

	public float M22
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

	public float M23
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

	public float M24
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

	public float M31
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

	public float M32
	{
		get
		{
			return float_9;
		}
		set
		{
			float_9 = value;
		}
	}

	public float M33
	{
		get
		{
			return float_10;
		}
		set
		{
			float_10 = value;
		}
	}

	public float M34
	{
		get
		{
			return float_11;
		}
		set
		{
			float_11 = value;
		}
	}

	public float M41
	{
		get
		{
			return float_12;
		}
		set
		{
			float_12 = value;
		}
	}

	public float M42
	{
		get
		{
			return float_13;
		}
		set
		{
			float_13 = value;
		}
	}

	public float M43
	{
		get
		{
			return float_14;
		}
		set
		{
			float_14 = value;
		}
	}

	public float M44
	{
		get
		{
			return float_15;
		}
		set
		{
			float_15 = value;
		}
	}

	public float Trace => float_0 + float_5 + float_10 + float_15;

	public unsafe float this[int index]
	{
		get
		{
			if (index < 0 || index >= 16)
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
			if (index < 0 || index >= 16)
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
			return this[(row - 1) * 4 + (column - 1)];
		}
		set
		{
			this[(row - 1) * 4 + (column - 1)] = value;
		}
	}

	public Matrix4F(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)
	{
		float_0 = m11;
		float_1 = m12;
		float_2 = m13;
		float_3 = m14;
		float_4 = m21;
		float_5 = m22;
		float_6 = m23;
		float_7 = m24;
		float_8 = m31;
		float_9 = m32;
		float_10 = m33;
		float_11 = m34;
		float_12 = m41;
		float_13 = m42;
		float_14 = m43;
		float_15 = m44;
	}

	public Matrix4F(float[] elements)
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
		float_9 = elements[9];
		float_10 = elements[10];
		float_11 = elements[11];
		float_12 = elements[12];
		float_13 = elements[13];
		float_14 = elements[14];
		float_15 = elements[15];
	}

	public Matrix4F(List<float> elements)
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
		float_9 = elements[9];
		float_10 = elements[10];
		float_11 = elements[11];
		float_12 = elements[12];
		float_13 = elements[13];
		float_14 = elements[14];
		float_15 = elements[15];
	}

	public Matrix4F(Vector4F column1, Vector4F column2, Vector4F column3, Vector4F column4)
	{
		float_0 = column1.X;
		float_1 = column2.X;
		float_2 = column3.X;
		float_3 = column4.X;
		float_4 = column1.Y;
		float_5 = column2.Y;
		float_6 = column3.Y;
		float_7 = column4.Y;
		float_8 = column1.Z;
		float_9 = column2.Z;
		float_10 = column3.Z;
		float_11 = column4.Z;
		float_12 = column1.W;
		float_13 = column2.W;
		float_14 = column3.W;
		float_15 = column4.W;
	}

	public Matrix4F(Matrix4F m)
	{
		float_0 = m.M11;
		float_1 = m.M12;
		float_2 = m.M13;
		float_3 = m.M14;
		float_4 = m.M21;
		float_5 = m.M22;
		float_6 = m.M23;
		float_7 = m.M24;
		float_8 = m.M31;
		float_9 = m.M32;
		float_10 = m.M33;
		float_11 = m.M34;
		float_12 = m.M41;
		float_13 = m.M42;
		float_14 = m.M43;
		float_15 = m.M44;
	}

	object ICloneable.Clone()
	{
		return new Matrix4F(this);
	}

	public Matrix4F Clone()
	{
		return new Matrix4F(this);
	}

	public static Matrix4F Parse(string value)
	{
		Match match = new Regex("4x4\\s*\\[(?<m11>.*),(?<m12>.*),(?<m13>.*),(?<m14>.*),(?<m21>.*),(?<m22>.*),(?<m23>.*),(?<m24>.*),(?<m31>.*),(?<m32>.*),(?<m33>.*),(?<m34>.*),(?<m41>.*),(?<m42>.*),(?<m43>.*),(?<m44>.*)\\]", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Matrix4F(float.Parse(match.Result("${m11}")), float.Parse(match.Result("${m12}")), float.Parse(match.Result("${m13}")), float.Parse(match.Result("${m14}")), float.Parse(match.Result("${m21}")), float.Parse(match.Result("${m22}")), float.Parse(match.Result("${m23}")), float.Parse(match.Result("${m24}")), float.Parse(match.Result("${m31}")), float.Parse(match.Result("${m32}")), float.Parse(match.Result("${m33}")), float.Parse(match.Result("${m34}")), float.Parse(match.Result("${m41}")), float.Parse(match.Result("${m42}")), float.Parse(match.Result("${m43}")), float.Parse(match.Result("${m44}")));
	}

	public static bool TryParse(string value, out Matrix4F result)
	{
		Match match = new Regex("4x4\\s*\\[(?<m11>.*),(?<m12>.*),(?<m13>.*),(?<m14>.*),(?<m21>.*),(?<m22>.*),(?<m23>.*),(?<m24>.*),(?<m31>.*),(?<m32>.*),(?<m33>.*),(?<m34>.*),(?<m41>.*),(?<m42>.*),(?<m43>.*),(?<m44>.*)\\]", RegexOptions.Singleline).Match(value);
		if (match.Success)
		{
			result = new Matrix4F(float.Parse(match.Result("${m11}")), float.Parse(match.Result("${m12}")), float.Parse(match.Result("${m13}")), float.Parse(match.Result("${m14}")), float.Parse(match.Result("${m21}")), float.Parse(match.Result("${m22}")), float.Parse(match.Result("${m23}")), float.Parse(match.Result("${m24}")), float.Parse(match.Result("${m31}")), float.Parse(match.Result("${m32}")), float.Parse(match.Result("${m33}")), float.Parse(match.Result("${m34}")), float.Parse(match.Result("${m41}")), float.Parse(match.Result("${m42}")), float.Parse(match.Result("${m43}")), float.Parse(match.Result("${m44}")));
			return true;
		}
		result = Zero;
		return false;
	}

	public static Matrix4F Add(Matrix4F left, Matrix4F right)
	{
		return new Matrix4F(left.M11 + right.M11, left.M12 + right.M12, left.M13 + right.M13, left.M14 + right.M14, left.M21 + right.M21, left.M22 + right.M22, left.M23 + right.M23, left.M24 + right.M24, left.M31 + right.M31, left.M32 + right.M32, left.M33 + right.M33, left.M34 + right.M34, left.M41 + right.M41, left.M42 + right.M42, left.M43 + right.M43, left.M44 + right.M44);
	}

	public static Matrix4F Add(Matrix4F matrix, float scalar)
	{
		return new Matrix4F(matrix.M11 + scalar, matrix.M12 + scalar, matrix.M13 + scalar, matrix.M14 + scalar, matrix.M21 + scalar, matrix.M22 + scalar, matrix.M23 + scalar, matrix.M24 + scalar, matrix.M31 + scalar, matrix.M32 + scalar, matrix.M33 + scalar, matrix.M34 + scalar, matrix.M41 + scalar, matrix.M42 + scalar, matrix.M43 + scalar, matrix.M44 + scalar);
	}

	public static void Add(Matrix4F left, Matrix4F right, ref Matrix4F result)
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

	public static void Add(Matrix4F matrix, float scalar, ref Matrix4F result)
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

	public static Matrix4F Subtract(Matrix4F left, Matrix4F right)
	{
		return new Matrix4F(left.M11 - right.M11, left.M12 - right.M12, left.M13 - right.M13, left.M14 - right.M14, left.M21 - right.M21, left.M22 - right.M22, left.M23 - right.M23, left.M24 - right.M24, left.M31 - right.M31, left.M32 - right.M32, left.M33 - right.M33, left.M34 - right.M34, left.M41 - right.M41, left.M42 - right.M42, left.M43 - right.M43, left.M44 - right.M44);
	}

	public static Matrix4F Subtract(Matrix4F matrix, float scalar)
	{
		return new Matrix4F(matrix.M11 - scalar, matrix.M12 - scalar, matrix.M13 - scalar, matrix.M14 - scalar, matrix.M21 - scalar, matrix.M22 - scalar, matrix.M23 - scalar, matrix.M24 - scalar, matrix.M31 - scalar, matrix.M32 - scalar, matrix.M33 - scalar, matrix.M34 - scalar, matrix.M41 - scalar, matrix.M42 - scalar, matrix.M43 - scalar, matrix.M44 - scalar);
	}

	public static void Subtract(Matrix4F left, Matrix4F right, ref Matrix4F result)
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

	public static void Subtract(Matrix4F matrix, float scalar, ref Matrix4F result)
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

	public static Matrix4F Multiply(Matrix4F left, Matrix4F right)
	{
		return new Matrix4F(left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31 + left.M14 * right.M41, left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32 + left.M14 * right.M42, left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33 + left.M14 * right.M43, left.M11 * right.M14 + left.M12 * right.M24 + left.M13 * right.M34 + left.M14 * right.M44, left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31 + left.M24 * right.M41, left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32 + left.M24 * right.M42, left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33 + left.M24 * right.M43, left.M21 * right.M14 + left.M22 * right.M24 + left.M23 * right.M34 + left.M24 * right.M44, left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31 + left.M34 * right.M41, left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32 + left.M34 * right.M42, left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33 + left.M34 * right.M43, left.M31 * right.M14 + left.M32 * right.M24 + left.M33 * right.M34 + left.M34 * right.M44, left.M41 * right.M11 + left.M42 * right.M21 + left.M43 * right.M31 + left.M44 * right.M41, left.M41 * right.M12 + left.M42 * right.M22 + left.M43 * right.M32 + left.M44 * right.M42, left.M41 * right.M13 + left.M42 * right.M23 + left.M43 * right.M33 + left.M44 * right.M43, left.M41 * right.M14 + left.M42 * right.M24 + left.M43 * right.M34 + left.M44 * right.M44);
	}

	public static void Multiply(Matrix4F left, Matrix4F right, ref Matrix4F result)
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

	public static Vector4F Transform(Matrix4F matrix, Vector4F vector)
	{
		return new Vector4F(matrix.M11 * vector.X + matrix.M12 * vector.Y + matrix.M13 * vector.Z + matrix.M14 * vector.W, matrix.M21 * vector.X + matrix.M22 * vector.Y + matrix.M23 * vector.Z + matrix.M24 * vector.W, matrix.M31 * vector.X + matrix.M32 * vector.Y + matrix.M33 * vector.Z + matrix.M34 * vector.W, matrix.M41 * vector.X + matrix.M42 * vector.Y + matrix.M43 * vector.Z + matrix.M44 * vector.W);
	}

	public static void Transform(Matrix4F matrix, Vector4F vector, ref Vector4F result)
	{
		result.X = matrix.M11 * vector.X + matrix.M12 * vector.Y + matrix.M13 * vector.Z + matrix.M14 * vector.W;
		result.Y = matrix.M21 * vector.X + matrix.M22 * vector.Y + matrix.M23 * vector.Z + matrix.M24 * vector.W;
		result.Z = matrix.M31 * vector.X + matrix.M32 * vector.Y + matrix.M33 * vector.Z + matrix.M34 * vector.W;
		result.W = matrix.M41 * vector.X + matrix.M42 * vector.Y + matrix.M43 * vector.Z + matrix.M44 * vector.W;
	}

	public static Matrix4F Transpose(Matrix4F m)
	{
		Matrix4F result = new Matrix4F(m);
		result.Transpose();
		return result;
	}

	public override int GetHashCode()
	{
		return float_0.GetHashCode() ^ float_1.GetHashCode() ^ float_2.GetHashCode() ^ float_3.GetHashCode() ^ float_4.GetHashCode() ^ float_5.GetHashCode() ^ float_6.GetHashCode() ^ float_7.GetHashCode() ^ float_8.GetHashCode() ^ float_9.GetHashCode() ^ float_10.GetHashCode() ^ float_11.GetHashCode() ^ float_12.GetHashCode() ^ float_13.GetHashCode() ^ float_14.GetHashCode() ^ float_15.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Matrix4F matrix4F)
		{
			if (float_0 == matrix4F.M11 && float_1 == matrix4F.M12 && float_2 == matrix4F.M13 && float_3 == matrix4F.M14 && float_4 == matrix4F.M21 && float_5 == matrix4F.M22 && float_6 == matrix4F.M23 && float_7 == matrix4F.M24 && float_8 == matrix4F.M31 && float_9 == matrix4F.M32 && float_10 == matrix4F.M33 && float_11 == matrix4F.M34 && float_12 == matrix4F.M41 && float_13 == matrix4F.M42 && float_14 == matrix4F.M43)
			{
				return float_15 == matrix4F.M44;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "4x4[{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}]", float_0, float_1, float_2, float_3, float_4, float_5, float_6, float_7, float_8, float_9, float_10, float_11, float_12, float_13, float_14, float_15);
	}

	public float GetDeterminant()
	{
		return float_3 * float_6 * float_9 * float_12 - float_2 * float_7 * float_9 * float_12 - float_3 * float_5 * float_10 * float_12 + float_1 * float_7 * float_10 * float_12 + float_2 * float_5 * float_11 * float_12 - float_1 * float_6 * float_11 * float_12 - float_3 * float_6 * float_8 * float_13 + float_2 * float_7 * float_8 * float_13 + float_3 * float_4 * float_10 * float_13 - float_0 * float_7 * float_10 * float_13 - float_2 * float_4 * float_11 * float_13 + float_0 * float_6 * float_11 * float_13 + float_3 * float_5 * float_8 * float_14 - float_1 * float_7 * float_8 * float_14 - float_3 * float_4 * float_9 * float_14 + float_0 * float_7 * float_9 * float_14 + float_1 * float_4 * float_11 * float_14 - float_0 * float_5 * float_11 * float_14 - float_2 * float_5 * float_8 * float_15 + float_1 * float_6 * float_8 * float_15 + float_2 * float_4 * float_9 * float_15 - float_0 * float_6 * float_9 * float_15 - float_1 * float_4 * float_10 * float_15 + float_0 * float_5 * float_10 * float_15;
	}

	public void Transpose()
	{
		MathFunctions.Swap(ref float_1, ref float_4);
		MathFunctions.Swap(ref float_2, ref float_8);
		MathFunctions.Swap(ref float_3, ref float_12);
		MathFunctions.Swap(ref float_6, ref float_9);
		MathFunctions.Swap(ref float_7, ref float_13);
		MathFunctions.Swap(ref float_11, ref float_14);
	}

	public static bool operator ==(Matrix4F left, Matrix4F right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Matrix4F left, Matrix4F right)
	{
		return !object.Equals(left, right);
	}

	public static Matrix4F operator +(Matrix4F left, Matrix4F right)
	{
		return Add(left, right);
	}

	public static Matrix4F operator +(Matrix4F matrix, float scalar)
	{
		return Add(matrix, scalar);
	}

	public static Matrix4F operator +(float scalar, Matrix4F matrix)
	{
		return Add(matrix, scalar);
	}

	public static Matrix4F operator -(Matrix4F left, Matrix4F right)
	{
		return Subtract(left, right);
	}

	public static Matrix4F operator -(Matrix4F matrix, float scalar)
	{
		return Subtract(matrix, scalar);
	}

	public static Matrix4F operator *(Matrix4F left, Matrix4F right)
	{
		return Multiply(left, right);
	}

	public static Vector4F operator *(Matrix4F matrix, Vector4F vector)
	{
		return Transform(matrix, vector);
	}

	static Matrix4F()
	{
		Class72.smethod_20();
		Zero = new Matrix4F(0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);
		Identity = new Matrix4F(1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f);
	}
}
