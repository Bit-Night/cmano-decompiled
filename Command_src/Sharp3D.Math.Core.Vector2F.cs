using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(Vector2FConverter))]
public struct Vector2F : ICloneable
{
	private float jkbyubDoese;

	private float float_0;

	public static readonly Vector2F Zero;

	public static readonly Vector2F XAxis;

	public static readonly Vector2F YAxis;

	public float X
	{
		get
		{
			return jkbyubDoese;
		}
		set
		{
			jkbyubDoese = value;
		}
	}

	public float Y
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

	public float this[int index]
	{
		get
		{
			return index switch
			{
				1 => float_0, 
				0 => jkbyubDoese, 
				_ => throw new IndexOutOfRangeException(), 
			};
		}
		set
		{
			switch (index)
			{
			default:
				throw new IndexOutOfRangeException();
			case 1:
				float_0 = value;
				break;
			case 0:
				jkbyubDoese = value;
				break;
			}
		}
	}

	public Vector2F(float x, float y)
	{
		jkbyubDoese = x;
		float_0 = y;
	}

	public Vector2F(float[] coordinates)
	{
		jkbyubDoese = coordinates[0];
		float_0 = coordinates[1];
	}

	public Vector2F(List<float> coordinates)
	{
		jkbyubDoese = coordinates[0];
		float_0 = coordinates[1];
	}

	public Vector2F(Vector2F vector)
	{
		jkbyubDoese = vector.X;
		float_0 = vector.Y;
	}

	object ICloneable.Clone()
	{
		return new Vector2F(this);
	}

	public Vector2F Clone()
	{
		return new Vector2F(this);
	}

	public static Vector2F Parse(string value)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*)\\)", RegexOptions.Singleline).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Vector2F(float.Parse(match.Result("${x}")), float.Parse(match.Result("${y}")));
	}

	public static bool TryParse(string value, out Vector2F result)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*)\\)", RegexOptions.Singleline).Match(value);
		if (match.Success)
		{
			result = new Vector2F(float.Parse(match.Result("${x}")), float.Parse(match.Result("${y}")));
			return true;
		}
		result = Zero;
		return false;
	}

	public static Vector2F Add(Vector2F left, Vector2F right)
	{
		return new Vector2F(left.X + right.X, left.Y + right.Y);
	}

	public static Vector2F Add(Vector2F vector, float scalar)
	{
		return new Vector2F(vector.X + scalar, vector.Y + scalar);
	}

	public static void Add(Vector2F left, Vector2F right, ref Vector2F result)
	{
		result.X = left.X + right.X;
		result.Y = left.Y + right.Y;
	}

	public static void Add(Vector2F vector, float scalar, ref Vector2F result)
	{
		result.X = vector.X + scalar;
		result.Y = vector.Y + scalar;
	}

	public static Vector2F Subtract(Vector2F left, Vector2F right)
	{
		return new Vector2F(left.X - right.X, left.Y - right.Y);
	}

	public static Vector2F Subtract(Vector2F vector, float scalar)
	{
		return new Vector2F(vector.X - scalar, vector.Y - scalar);
	}

	public static Vector2F Subtract(float scalar, Vector2F vector)
	{
		return new Vector2F(scalar - vector.X, scalar - vector.Y);
	}

	public static void Subtract(Vector2F left, Vector2F right, ref Vector2F result)
	{
		result.X = left.X - right.X;
		result.Y = left.Y - right.Y;
	}

	public static void Subtract(Vector2F vector, float scalar, ref Vector2F result)
	{
		result.X = vector.X - scalar;
		result.Y = vector.Y - scalar;
	}

	public static void Subtract(float scalar, Vector2F vector, ref Vector2F result)
	{
		result.X = scalar - vector.X;
		result.Y = scalar - vector.Y;
	}

	public static Vector2F Divide(Vector2F left, Vector2F right)
	{
		return new Vector2F(left.X / right.X, left.Y / right.Y);
	}

	public static Vector2F Divide(Vector2F vector, float scalar)
	{
		return new Vector2F(vector.X / scalar, vector.Y / scalar);
	}

	public static Vector2F Divide(float scalar, Vector2F vector)
	{
		return new Vector2F(scalar / vector.X, scalar / vector.Y);
	}

	public static void Divide(Vector2F left, Vector2F right, ref Vector2F result)
	{
		result.X = left.X / right.X;
		result.Y = left.Y / right.Y;
	}

	public static void Divide(Vector2F vector, float scalar, ref Vector2F result)
	{
		result.X = vector.X / scalar;
		result.Y = vector.Y / scalar;
	}

	public static void Divide(float scalar, Vector2F vector, ref Vector2F result)
	{
		result.X = scalar / vector.X;
		result.Y = scalar / vector.Y;
	}

	public static Vector2F Multiply(Vector2F vector, float scalar)
	{
		return new Vector2F(vector.X * scalar, vector.Y * scalar);
	}

	public static void Multiply(Vector2F vector, float scalar, ref Vector2F result)
	{
		result.X = vector.X * scalar;
		result.Y = vector.Y * scalar;
	}

	public static float DotProduct(Vector2F left, Vector2F right)
	{
		return left.X * right.X + left.Y * right.Y;
	}

	public static float KrossProduct(Vector2F left, Vector2F right)
	{
		return left.X * right.Y - left.Y * right.X;
	}

	public static Vector2F Negate(Vector2F vector)
	{
		return new Vector2F(0f - vector.X, 0f - vector.Y);
	}

	public static bool ApproxEqual(Vector2F left, Vector2F right)
	{
		return ApproxEqual(left, right, 4.7683716E-07f);
	}

	public static bool ApproxEqual(Vector2F left, Vector2F right, float tolerance)
	{
		if (System.Math.Abs(left.X - right.X) <= tolerance)
		{
			return System.Math.Abs(left.Y - right.Y) <= tolerance;
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
		jkbyubDoese /= length;
		float_0 /= length;
	}

	public float GetLength()
	{
		return (float)System.Math.Sqrt(jkbyubDoese * jkbyubDoese + float_0 * float_0);
	}

	public float GetLengthSquared()
	{
		return jkbyubDoese * jkbyubDoese + float_0 * float_0;
	}

	public void ClampZero(float tolerance)
	{
		jkbyubDoese = MathFunctions.Clamp(jkbyubDoese, 0f, tolerance);
		float_0 = MathFunctions.Clamp(float_0, 0f, tolerance);
	}

	public void ClampZero()
	{
		jkbyubDoese = MathFunctions.Clamp(jkbyubDoese, 0f);
		float_0 = MathFunctions.Clamp(float_0, 0f);
	}

	public override int GetHashCode()
	{
		return jkbyubDoese.GetHashCode() ^ float_0.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Vector2F vector2F))
		{
			return false;
		}
		if (jkbyubDoese == vector2F.X)
		{
			return float_0 == vector2F.Y;
		}
		return false;
	}

	public override string ToString()
	{
		return $"({jkbyubDoese}, {float_0})";
	}

	public static bool operator ==(Vector2F left, Vector2F right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Vector2F left, Vector2F right)
	{
		return !object.Equals(left, right);
	}

	public static bool operator >(Vector2F left, Vector2F right)
	{
		if (left.jkbyubDoese <= right.jkbyubDoese)
		{
			return false;
		}
		return left.float_0 > right.float_0;
	}

	public static bool operator <(Vector2F left, Vector2F right)
	{
		if (left.jkbyubDoese >= right.jkbyubDoese)
		{
			return false;
		}
		return left.float_0 < right.float_0;
	}

	public static bool operator >=(Vector2F left, Vector2F right)
	{
		if (left.jkbyubDoese < right.jkbyubDoese)
		{
			return false;
		}
		return left.float_0 >= right.float_0;
	}

	public static bool operator <=(Vector2F left, Vector2F right)
	{
		if (left.jkbyubDoese > right.jkbyubDoese)
		{
			return false;
		}
		return left.float_0 <= right.float_0;
	}

	public static Vector2F operator -(Vector2F vector)
	{
		return Negate(vector);
	}

	public static Vector2F operator +(Vector2F left, Vector2F right)
	{
		return Add(left, right);
	}

	public static Vector2F operator +(Vector2F vector, float scalar)
	{
		return Add(vector, scalar);
	}

	public static Vector2F operator +(float scalar, Vector2F vector)
	{
		return Add(vector, scalar);
	}

	public static Vector2F operator -(Vector2F left, Vector2F right)
	{
		return Subtract(left, right);
	}

	public static Vector2F operator -(Vector2F vector, float scalar)
	{
		return Subtract(vector, scalar);
	}

	public static Vector2F operator -(float scalar, Vector2F vector)
	{
		return Subtract(scalar, vector);
	}

	public static Vector2F operator *(Vector2F vector, float scalar)
	{
		return Multiply(vector, scalar);
	}

	public static Vector2F operator *(float scalar, Vector2F vector)
	{
		return Multiply(vector, scalar);
	}

	public static Vector2F operator /(Vector2F vector, float scalar)
	{
		return Divide(vector, scalar);
	}

	public static Vector2F operator /(float scalar, Vector2F vector)
	{
		return Divide(scalar, vector);
	}

	public static explicit operator float[](Vector2F vector)
	{
		return new float[2] { vector.X, vector.Y };
	}

	public static explicit operator List<float>(Vector2F vector)
	{
		return new List<float>(2) { vector.X, vector.Y };
	}

	public static explicit operator LinkedList<float>(Vector2F vector)
	{
		LinkedList<float> linkedList = new LinkedList<float>();
		linkedList.AddLast(vector.X);
		linkedList.AddLast(vector.Y);
		return linkedList;
	}

	static Vector2F()
	{
		Class72.smethod_20();
		Zero = new Vector2F(0f, 0f);
		XAxis = new Vector2F(1f, 0f);
		YAxis = new Vector2F(0f, 1f);
	}
}
