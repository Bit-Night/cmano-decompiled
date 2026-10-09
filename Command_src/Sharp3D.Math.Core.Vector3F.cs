using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(Vector3FConverter))]
public struct Vector3F : ICloneable
{
	private float float_0;

	private float float_1;

	private float float_2;

	public static readonly Vector3F Zero;

	public static readonly Vector3F XAxis;

	public static readonly Vector3F YAxis;

	public static readonly Vector3F ZAxis;

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

	public float this[int index]
	{
		get
		{
			return index switch
			{
				0 => float_0, 
				1 => float_1, 
				2 => float_2, 
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
			}
		}
	}

	public Vector3F(float x, float y, float z)
	{
		float_0 = x;
		float_1 = y;
		float_2 = z;
	}

	public Vector3F(float[] coordinates)
	{
		float_0 = coordinates[0];
		float_1 = coordinates[1];
		float_2 = coordinates[2];
	}

	public Vector3F(List<float> coordinates)
	{
		float_0 = coordinates[0];
		float_1 = coordinates[1];
		float_2 = coordinates[2];
	}

	public Vector3F(Vector3F vector)
	{
		float_0 = vector.X;
		float_1 = vector.Y;
		float_2 = vector.Z;
	}

	object ICloneable.Clone()
	{
		return new Vector3F(this);
	}

	public Vector3F Clone()
	{
		return new Vector3F(this);
	}

	public static Vector3F Parse(string value)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*),(?<z>.*)\\)", RegexOptions.Singleline).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Vector3F(float.Parse(match.Result("${x}")), float.Parse(match.Result("${y}")), float.Parse(match.Result("${z}")));
	}

	public static bool TryParse(string value, out Vector3F result)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*),(?<z>.*)\\)", RegexOptions.Singleline).Match(value);
		if (!match.Success)
		{
			result = Zero;
			return false;
		}
		result = new Vector3F(float.Parse(match.Result("${x}")), float.Parse(match.Result("${y}")), float.Parse(match.Result("${z}")));
		return true;
	}

	public static Vector3F Add(Vector3F left, Vector3F right)
	{
		return new Vector3F(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
	}

	public static Vector3F Add(Vector3F vector, float scalar)
	{
		return new Vector3F(vector.X + scalar, vector.Y + scalar, vector.Z + scalar);
	}

	public static void Add(Vector3F left, Vector3F right, ref Vector3F result)
	{
		result.X = left.X + right.X;
		result.Y = left.Y + right.Y;
		result.Z = left.Z + right.Z;
	}

	public static void Add(Vector3F vector, float scalar, ref Vector3F result)
	{
		result.X = vector.X + scalar;
		result.Y = vector.Y + scalar;
		result.Z = vector.Z + scalar;
	}

	public static Vector3F Subtract(Vector3F left, Vector3F right)
	{
		return new Vector3F(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
	}

	public static Vector3F Subtract(Vector3F vector, float scalar)
	{
		return new Vector3F(vector.X - scalar, vector.Y - scalar, vector.Z - scalar);
	}

	public static Vector3F Subtract(float scalar, Vector3F vector)
	{
		return new Vector3F(scalar - vector.X, scalar - vector.Y, scalar - vector.Z);
	}

	public static void Subtract(Vector3F left, Vector3F right, ref Vector3F result)
	{
		result.X = left.X - right.X;
		result.Y = left.Y - right.Y;
		result.Z = left.Z - right.Z;
	}

	public static void Subtract(Vector3F vector, float scalar, ref Vector3F result)
	{
		result.X = vector.X - scalar;
		result.Y = vector.Y - scalar;
		result.Z = vector.Z - scalar;
	}

	public static void Subtract(float scalar, Vector3F vector, ref Vector3F result)
	{
		result.X = scalar - vector.X;
		result.Y = scalar - vector.Y;
		result.Z = scalar - vector.Z;
	}

	public static Vector3F Divide(Vector3F left, Vector3F right)
	{
		return new Vector3F(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
	}

	public static Vector3F Divide(Vector3F vector, float scalar)
	{
		return new Vector3F(vector.X / scalar, vector.Y / scalar, vector.Z / scalar);
	}

	public static Vector3F Divide(float scalar, Vector3F vector)
	{
		return new Vector3F(scalar / vector.X, scalar / vector.Y, scalar / vector.Z);
	}

	public static void Divide(Vector3F left, Vector3F right, ref Vector3F result)
	{
		result.X = left.X / right.X;
		result.Y = left.Y / right.Y;
		result.Z = left.Z / right.Z;
	}

	public static void Divide(Vector3F vector, float scalar, ref Vector3F result)
	{
		result.X = vector.X / scalar;
		result.Y = vector.Y / scalar;
		result.Z = vector.Z / scalar;
	}

	public static void Divide(float scalar, Vector3F vector, ref Vector3F result)
	{
		result.X = scalar / vector.X;
		result.Y = scalar / vector.Y;
		result.Z = scalar / vector.Z;
	}

	public static Vector3F Multiply(Vector3F vector, float scalar)
	{
		return new Vector3F(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
	}

	public static void Multiply(Vector3F vector, float scalar, ref Vector3F result)
	{
		result.X = vector.X * scalar;
		result.Y = vector.Y * scalar;
		result.Z = vector.Z * scalar;
	}

	public static float DotProduct(Vector3F left, Vector3F right)
	{
		return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
	}

	public static Vector3F CrossProduct(Vector3F left, Vector3F right)
	{
		return new Vector3F(left.Y * right.Z - left.Z * right.Y, left.Z * right.X - left.X * right.Z, left.X * right.Y - left.Y * right.X);
	}

	public static void CrossProduct(Vector3F left, Vector3F right, ref Vector3F result)
	{
		result.X = left.Y * right.Z - left.Z * right.Y;
		result.Y = left.Z * right.X - left.X * right.Z;
		result.Z = left.X * right.Y - left.Y * right.X;
	}

	public static Vector3F Negate(Vector3F vector)
	{
		return new Vector3F(0f - vector.X, 0f - vector.Y, 0f - vector.Z);
	}

	public static bool ApproxEqual(Vector3F left, Vector3F right)
	{
		return ApproxEqual(left, right, 4.7683716E-07f);
	}

	public static bool ApproxEqual(Vector3F left, Vector3F right, float tolerance)
	{
		if (System.Math.Abs(left.X - right.X) <= tolerance && System.Math.Abs(left.Y - right.Y) <= tolerance)
		{
			return System.Math.Abs(left.Z - right.Z) <= tolerance;
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
	}

	public float GetLength()
	{
		return (float)System.Math.Sqrt(float_0 * float_0 + float_1 * float_1 + float_2 * float_2);
	}

	public float GetLengthSquared()
	{
		return float_0 * float_0 + float_1 * float_1 + float_2 * float_2;
	}

	public void ClampZero(float tolerance)
	{
		float_0 = MathFunctions.Clamp(float_0, 0f, tolerance);
		float_1 = MathFunctions.Clamp(float_1, 0f, tolerance);
		float_2 = MathFunctions.Clamp(float_2, 0f, tolerance);
	}

	public void ClampZero()
	{
		float_0 = MathFunctions.Clamp(float_0, 0f);
		float_1 = MathFunctions.Clamp(float_1, 0f);
		float_2 = MathFunctions.Clamp(float_2, 0f);
	}

	public override int GetHashCode()
	{
		return float_0.GetHashCode() ^ float_1.GetHashCode() ^ float_2.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Vector3F vector3F)
		{
			if (float_0 == vector3F.X && float_1 == vector3F.Y)
			{
				return float_2 == vector3F.Z;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return $"({float_0}, {float_1}, {float_2})";
	}

	public static bool operator ==(Vector3F left, Vector3F right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Vector3F left, Vector3F right)
	{
		return !object.Equals(left, right);
	}

	public static bool operator >(Vector3F left, Vector3F right)
	{
		if (left.float_0 > right.float_0 && left.float_1 > right.float_1)
		{
			return left.float_2 > right.float_2;
		}
		return false;
	}

	public static bool operator <(Vector3F left, Vector3F right)
	{
		if (left.float_0 < right.float_0 && left.float_1 < right.float_1)
		{
			return left.float_2 < right.float_2;
		}
		return false;
	}

	public static bool operator >=(Vector3F left, Vector3F right)
	{
		if (left.float_0 >= right.float_0 && left.float_1 >= right.float_1)
		{
			return left.float_2 >= right.float_2;
		}
		return false;
	}

	public static bool operator <=(Vector3F left, Vector3F right)
	{
		if (left.float_0 <= right.float_0 && left.float_1 <= right.float_1)
		{
			return left.float_2 <= right.float_2;
		}
		return false;
	}

	public static Vector3F operator -(Vector3F vector)
	{
		return Negate(vector);
	}

	public static Vector3F operator +(Vector3F left, Vector3F right)
	{
		return Add(left, right);
	}

	public static Vector3F operator +(Vector3F vector, float scalar)
	{
		return Add(vector, scalar);
	}

	public static Vector3F operator +(float scalar, Vector3F vector)
	{
		return Add(vector, scalar);
	}

	public static Vector3F operator -(Vector3F left, Vector3F right)
	{
		return Subtract(left, right);
	}

	public static Vector3F operator -(Vector3F vector, float scalar)
	{
		return Subtract(vector, scalar);
	}

	public static Vector3F operator -(float scalar, Vector3F vector)
	{
		return Subtract(scalar, vector);
	}

	public static Vector3F operator *(Vector3F vector, float scalar)
	{
		return Multiply(vector, scalar);
	}

	public static Vector3F operator *(float scalar, Vector3F vector)
	{
		return Multiply(vector, scalar);
	}

	public static Vector3F operator /(Vector3F vector, float scalar)
	{
		return Divide(vector, scalar);
	}

	public static Vector3F operator /(float scalar, Vector3F vector)
	{
		return Divide(scalar, vector);
	}

	public static explicit operator float[](Vector3F vector)
	{
		return new float[3] { vector.X, vector.Y, vector.Z };
	}

	public static explicit operator List<float>(Vector3F vector)
	{
		return new List<float>(3) { vector.X, vector.Y, vector.Z };
	}

	public static explicit operator LinkedList<float>(Vector3F vector)
	{
		LinkedList<float> linkedList = new LinkedList<float>();
		linkedList.AddLast(vector.X);
		linkedList.AddLast(vector.Y);
		linkedList.AddLast(vector.Z);
		return linkedList;
	}

	static Vector3F()
	{
		Class72.smethod_20();
		Zero = new Vector3F(0f, 0f, 0f);
		XAxis = new Vector3F(1f, 0f, 0f);
		YAxis = new Vector3F(0f, 1f, 0f);
		ZAxis = new Vector3F(0f, 0f, 1f);
	}
}
