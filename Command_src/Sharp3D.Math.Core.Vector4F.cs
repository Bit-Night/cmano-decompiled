using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(Vector4FConverter))]
public struct Vector4F : ICloneable
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	public static readonly Vector4F Zero;

	public static readonly Vector4F XAxis;

	public static readonly Vector4F YAxis;

	public static readonly Vector4F ZAxis;

	public static readonly Vector4F WAxis;

	public float X
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

	public float Y
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

	public float Z
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

	public float W
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

	public float this[int index]
	{
		get
		{
			return index switch
			{
				0 => float_0, 
				1 => float_1, 
				2 => float_2, 
				3 => float_3, 
				_ => throw new IndexOutOfRangeException(), 
			};
		}
		set
		{
			switch (index)
			{
			default:
				throw new IndexOutOfRangeException();
			case 0:
				float_0 = value;
				break;
			case 1:
				float_1 = value;
				break;
			case 2:
				float_2 = value;
				break;
			case 3:
				float_3 = value;
				break;
			}
		}
	}

	public Vector4F(float x, float y, float z, float w)
	{
		float_0 = x;
		float_1 = y;
		float_2 = z;
		float_3 = w;
	}

	public Vector4F(float[] coordinates)
	{
		float_0 = coordinates[0];
		float_1 = coordinates[1];
		float_2 = coordinates[2];
		float_3 = coordinates[3];
	}

	public Vector4F(List<float> coordinates)
	{
		float_0 = coordinates[0];
		float_1 = coordinates[1];
		float_2 = coordinates[2];
		float_3 = coordinates[3];
	}

	public Vector4F(Vector4F vector)
	{
		float_0 = vector.X;
		float_1 = vector.Y;
		float_2 = vector.Z;
		float_3 = vector.W;
	}

	object ICloneable.Clone()
	{
		return new Vector4F(this);
	}

	public Vector4F Clone()
	{
		return new Vector4F(this);
	}

	public static Vector4F Parse(string value)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*),(?<z>.*),(?<w>.*)\\)", RegexOptions.Singleline).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Vector4F(float.Parse(match.Result("${x}")), float.Parse(match.Result("${y}")), float.Parse(match.Result("${z}")), float.Parse(match.Result("${w}")));
	}

	public static bool TryParse(string value, out Vector4F result)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*),(?<z>.*),(?<w>.*)\\)", RegexOptions.Singleline).Match(value);
		if (!match.Success)
		{
			result = Zero;
			return false;
		}
		result = new Vector4F(float.Parse(match.Result("${x}")), float.Parse(match.Result("${y}")), float.Parse(match.Result("${z}")), float.Parse(match.Result("${w}")));
		return true;
	}

	public static Vector4F Add(Vector4F left, Vector4F right)
	{
		return new Vector4F(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
	}

	public static Vector4F Add(Vector4F vector, float scalar)
	{
		return new Vector4F(vector.X + scalar, vector.Y + scalar, vector.Z + scalar, vector.W + scalar);
	}

	public static void Add(Vector4F left, Vector4F right, ref Vector4F result)
	{
		result.X = left.X + right.X;
		result.Y = left.Y + right.Y;
		result.Z = left.Z + right.Z;
		result.W = left.W + right.W;
	}

	public static void Add(Vector4F vector, float scalar, ref Vector4F result)
	{
		result.X = vector.X + scalar;
		result.Y = vector.Y + scalar;
		result.Z = vector.Z + scalar;
		result.W = vector.W + scalar;
	}

	public static Vector4F Subtract(Vector4F left, Vector4F right)
	{
		return new Vector4F(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
	}

	public static Vector4F Subtract(Vector4F vector, float scalar)
	{
		return new Vector4F(vector.X - scalar, vector.Y - scalar, vector.Z - scalar, vector.W - scalar);
	}

	public static Vector4F Subtract(float scalar, Vector4F vector)
	{
		return new Vector4F(scalar - vector.X, scalar - vector.Y, scalar - vector.Z, scalar - vector.W);
	}

	public static void Subtract(Vector4F left, Vector4F right, ref Vector4F result)
	{
		result.X = left.X - right.X;
		result.Y = left.Y - right.Y;
		result.Z = left.Z - right.Z;
		result.W = left.W - right.W;
	}

	public static void Subtract(Vector4F vector, float scalar, ref Vector4F result)
	{
		result.X = vector.X - scalar;
		result.Y = vector.Y - scalar;
		result.Z = vector.Z - scalar;
		result.W = vector.W - scalar;
	}

	public static void Subtract(float scalar, Vector4F vector, ref Vector4F result)
	{
		result.X = scalar - vector.X;
		result.Y = scalar - vector.Y;
		result.Z = scalar - vector.Z;
		result.W = scalar - vector.W;
	}

	public static Vector4F Divide(Vector4F left, Vector4F right)
	{
		return new Vector4F(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
	}

	public static Vector4F Divide(Vector4F vector, float scalar)
	{
		return new Vector4F(vector.X / scalar, vector.Y / scalar, vector.Z / scalar, vector.W / scalar);
	}

	public static Vector4F Divide(float scalar, Vector4F vector)
	{
		return new Vector4F(scalar / vector.X, scalar / vector.Y, scalar / vector.Z, scalar / vector.W);
	}

	public static void Divide(Vector4F left, Vector4F right, ref Vector4F result)
	{
		result.X = left.X / right.X;
		result.Y = left.Y / right.Y;
		result.Z = left.Z / right.Z;
		result.W = left.W / right.W;
	}

	public static void Divide(Vector4F vector, float scalar, ref Vector4F result)
	{
		result.X = vector.X / scalar;
		result.Y = vector.Y / scalar;
		result.Z = vector.Z / scalar;
		result.W = vector.W / scalar;
	}

	public static void Divide(float scalar, Vector4F vector, ref Vector4F result)
	{
		result.X = scalar / vector.X;
		result.Y = scalar / vector.Y;
		result.Z = scalar / vector.Z;
		result.W = scalar / vector.W;
	}

	public static Vector4F Multiply(Vector4F vector, float scalar)
	{
		return new Vector4F(vector.X * scalar, vector.Y * scalar, vector.Z * scalar, vector.W * scalar);
	}

	public static void Multiply(Vector4F vector, float scalar, ref Vector4F result)
	{
		result.X = vector.X * scalar;
		result.Y = vector.Y * scalar;
		result.Z = vector.Z * scalar;
		result.W = vector.W * scalar;
	}

	public static float DotProduct(Vector4F left, Vector4F right)
	{
		return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
	}

	public static Vector4F Negate(Vector4F vector)
	{
		return new Vector4F(0f - vector.X, 0f - vector.Y, 0f - vector.Z, 0f - vector.W);
	}

	public static bool ApproxEqual(Vector4F left, Vector4F right)
	{
		return ApproxEqual(left, right, 4.7683716E-07f);
	}

	public static bool ApproxEqual(Vector4F left, Vector4F right, float tolerance)
	{
		if (System.Math.Abs(left.X - right.X) <= tolerance && System.Math.Abs(left.Y - right.Y) <= tolerance && System.Math.Abs(left.Z - right.Z) <= tolerance)
		{
			return System.Math.Abs(left.W - right.W) <= tolerance;
		}
		return false;
	}

	public void Normalize()
	{
		float length = GetLength();
		if (length == 0f)
		{
			throw new DivideByZeroException("Trying to normalize a vector with length of zero.");
		}
		float_0 /= length;
		float_1 /= length;
		float_2 /= length;
		float_3 /= length;
	}

	public float GetLength()
	{
		return (float)System.Math.Sqrt(float_0 * float_0 + float_1 * float_1 + float_2 * float_2 + float_3 * float_3);
	}

	public float GetLengthSquared()
	{
		return float_0 * float_0 + float_1 * float_1 + float_2 * float_2 + float_3 * float_3;
	}

	public void ClampZero(float tolerance)
	{
		float_0 = MathFunctions.Clamp(float_0, 0f, tolerance);
		float_1 = MathFunctions.Clamp(float_1, 0f, tolerance);
		float_2 = MathFunctions.Clamp(float_2, 0f, tolerance);
		float_3 = MathFunctions.Clamp(float_3, 0f, tolerance);
	}

	public void ClampZero()
	{
		float_0 = MathFunctions.Clamp(float_0, 0f);
		float_1 = MathFunctions.Clamp(float_1, 0f);
		float_2 = MathFunctions.Clamp(float_2, 0f);
		float_3 = MathFunctions.Clamp(float_3, 0f);
	}

	public override int GetHashCode()
	{
		return float_0.GetHashCode() ^ float_1.GetHashCode() ^ float_2.GetHashCode() ^ float_3.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Vector4F vector4F))
		{
			return false;
		}
		if (float_0 == vector4F.X && float_1 == vector4F.Y && float_2 == vector4F.Z)
		{
			return float_3 == vector4F.W;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1}, {2}, {3})", float_0, float_1, float_2, float_3);
	}

	public static bool operator ==(Vector4F left, Vector4F right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Vector4F left, Vector4F right)
	{
		return !object.Equals(left, right);
	}

	public static bool operator >(Vector4F left, Vector4F right)
	{
		if (left.float_0 > right.float_0 && left.float_1 > right.float_1 && left.float_2 > right.float_2)
		{
			return left.float_3 > right.float_3;
		}
		return false;
	}

	public static bool operator <(Vector4F left, Vector4F right)
	{
		if (left.float_0 < right.float_0 && left.float_1 < right.float_1 && left.float_2 < right.float_2)
		{
			return left.float_3 < right.float_3;
		}
		return false;
	}

	public static bool operator >=(Vector4F left, Vector4F right)
	{
		if (left.float_0 >= right.float_0 && left.float_1 >= right.float_1 && left.float_2 >= right.float_2)
		{
			return left.float_3 >= right.float_3;
		}
		return false;
	}

	public static bool operator <=(Vector4F left, Vector4F right)
	{
		if (left.float_0 <= right.float_0 && left.float_1 <= right.float_1 && left.float_2 <= right.float_2)
		{
			return left.float_3 <= right.float_3;
		}
		return false;
	}

	public static Vector4F operator -(Vector4F vector)
	{
		return Negate(vector);
	}

	public static Vector4F operator +(Vector4F left, Vector4F right)
	{
		return Add(left, right);
	}

	public static Vector4F operator +(Vector4F vector, float scalar)
	{
		return Add(vector, scalar);
	}

	public static Vector4F operator +(float scalar, Vector4F vector)
	{
		return Add(vector, scalar);
	}

	public static Vector4F operator -(Vector4F left, Vector4F right)
	{
		return Subtract(left, right);
	}

	public static Vector4F operator -(Vector4F vector, float scalar)
	{
		return Subtract(vector, scalar);
	}

	public static Vector4F operator -(float scalar, Vector4F vector)
	{
		return Subtract(scalar, vector);
	}

	public static Vector4F operator *(Vector4F vector, float scalar)
	{
		return Multiply(vector, scalar);
	}

	public static Vector4F operator *(float scalar, Vector4F vector)
	{
		return Multiply(vector, scalar);
	}

	public static Vector4F operator /(Vector4F vector, float scalar)
	{
		return Divide(vector, scalar);
	}

	public static Vector4F operator /(float scalar, Vector4F vector)
	{
		return Divide(scalar, vector);
	}

	public static explicit operator float[](Vector4F vector)
	{
		return new float[4] { vector.X, vector.Y, vector.Z, vector.W };
	}

	public static explicit operator List<float>(Vector4F vector)
	{
		return new List<float>(4) { vector.X, vector.Y, vector.Z, vector.W };
	}

	public static explicit operator LinkedList<float>(Vector4F vector)
	{
		LinkedList<float> linkedList = new LinkedList<float>();
		linkedList.AddLast(vector.X);
		linkedList.AddLast(vector.Y);
		linkedList.AddLast(vector.Z);
		linkedList.AddLast(vector.W);
		return linkedList;
	}

	static Vector4F()
	{
		Class72.smethod_20();
		Zero = new Vector4F(0f, 0f, 0f, 0f);
		XAxis = new Vector4F(1f, 0f, 0f, 0f);
		YAxis = new Vector4F(0f, 1f, 0f, 0f);
		ZAxis = new Vector4F(0f, 0f, 1f, 0f);
		WAxis = new Vector4F(0f, 0f, 0f, 1f);
	}
}
