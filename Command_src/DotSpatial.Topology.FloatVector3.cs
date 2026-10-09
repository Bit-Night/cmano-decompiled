using System;

namespace DotSpatial.Topology;

public struct FloatVector3
{
	public float X;

	public float Y;

	public float Z;

	public float Length => Convert.ToSingle(Math.Sqrt(X * X + Y * Y + Z * Z));

	public float LengthSq => Convert.ToSingle(X * X + Y * Y + Z * Z);

	public FloatVector3(CoordinateF coord)
	{
		X = coord.X;
		Y = coord.Y;
		Z = coord.Z;
	}

	public FloatVector3(float xValue, float yValue, float zValue)
	{
		X = xValue;
		Y = yValue;
		Z = zValue;
	}

	public FloatVector3(Coordinate coord)
	{
		X = Convert.ToSingle(coord.X);
		Y = Convert.ToSingle(coord.Y);
		Z = Convert.ToSingle(coord.Z);
	}

	public override bool Equals(object obj)
	{
		if (obj is FloatVector3 floatVector && floatVector.X == X && floatVector.Y == Y && floatVector.Z == Z)
		{
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static FloatVector3 Add(FloatVector3 lhs, FloatVector3 rhs)
	{
		return new FloatVector3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
	}

	public void Add(FloatVector3 vector)
	{
		X += vector.X;
		Y += vector.Y;
		Z += vector.Z;
	}

	public static FloatVector3 Subtract(FloatVector3 lhs, FloatVector3 rhs)
	{
		return new FloatVector3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
	}

	public void Subtract(FloatVector3 vector)
	{
		X -= vector.X;
		Y -= vector.Y;
		Z -= vector.Z;
	}

	public static FloatVector3 CrossProduct(FloatVector3 lhs, FloatVector3 rhs)
	{
		return new FloatVector3
		{
			X = lhs.Y * rhs.Z - lhs.Z * rhs.Y,
			Y = lhs.Z * rhs.X - lhs.X * rhs.Z,
			Z = lhs.X * rhs.Y - lhs.Y * rhs.X
		};
	}

	public static float Dot(FloatVector3 lhs, FloatVector3 rhs)
	{
		return lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;
	}

	public static FloatVector3 Multiply(FloatVector3 source, float scalar)
	{
		return new FloatVector3(source.X * scalar, source.Y * scalar, source.Z * scalar);
	}

	public void Multiply(float scalar)
	{
		X *= scalar;
		Y *= scalar;
		Z *= scalar;
	}

	public void Normalize()
	{
		float length = Length;
		X /= length;
		Y /= length;
		Z /= length;
	}

	public static FloatVector3 operator +(FloatVector3 lhs, FloatVector3 rhs)
	{
		FloatVector3 result = default(FloatVector3);
		result.X = lhs.X + rhs.X;
		result.Y = lhs.Y + rhs.Y;
		result.Z = lhs.Z + rhs.Z;
		return result;
	}

	public static bool operator ==(FloatVector3 lhs, FloatVector3 rhs)
	{
		if (lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z)
		{
			return true;
		}
		return false;
	}

	public static bool operator !=(FloatVector3 lhs, FloatVector3 rhs)
	{
		if (lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z)
		{
			return false;
		}
		return true;
	}

	public static FloatVector3 operator ^(FloatVector3 lhs, FloatVector3 rhs)
	{
		return new FloatVector3
		{
			X = lhs.Y * rhs.Z - lhs.Z * rhs.Y,
			Y = lhs.Z * rhs.X - lhs.X * rhs.Z,
			Z = lhs.X * rhs.Y - lhs.Y * rhs.X
		};
	}

	public static FloatVector3 operator /(FloatVector3 lhs, FloatVector3 rhs)
	{
		FloatVector3 result = default(FloatVector3);
		if (rhs.X > 0f)
		{
			result.X = lhs.X / rhs.X;
		}
		if (rhs.Y > 0f)
		{
			result.Y = lhs.Y / rhs.Y;
		}
		if (rhs.Z > 0f)
		{
			result.Z = lhs.Z / rhs.Z;
		}
		return result;
	}

	public static FloatVector3 operator /(FloatVector3 lhs, float scalar)
	{
		if (scalar == 0f)
		{
			throw new ArgumentException("Divisor cannot be 0.");
		}
		FloatVector3 result = default(FloatVector3);
		result.X = lhs.X / scalar;
		result.Y = lhs.Y / scalar;
		result.Z = lhs.Z / scalar;
		return result;
	}

	public static float operator *(FloatVector3 lhs, FloatVector3 rhs)
	{
		return lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;
	}

	public static FloatVector3 operator *(float scalar, FloatVector3 rhs)
	{
		FloatVector3 result = default(FloatVector3);
		result.X = scalar * rhs.X;
		result.Y = scalar * rhs.Y;
		result.Z = scalar * rhs.Z;
		return result;
	}

	public static FloatVector3 operator *(FloatVector3 lhs, float scalar)
	{
		FloatVector3 result = default(FloatVector3);
		result.X = lhs.X * scalar;
		result.Y = lhs.Y * scalar;
		result.Z = lhs.Z * scalar;
		return result;
	}

	public static FloatVector3 operator -(FloatVector3 lhs, FloatVector3 rhs)
	{
		FloatVector3 result = default(FloatVector3);
		result.X = lhs.X - rhs.X;
		result.Y = lhs.Y - rhs.Y;
		result.Z = lhs.Z - rhs.Z;
		return result;
	}

	static FloatVector3()
	{
		Class72.smethod_20();
	}
}
