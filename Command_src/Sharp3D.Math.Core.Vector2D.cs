using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(Vector2DConverter))]
public struct Vector2D : ICloneable
{
	private double double_0;

	private double double_1;

	public static readonly Vector2D Zero;

	public static readonly Vector2D XAxis;

	public static readonly Vector2D YAxis;

	public double X
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

	public double Y
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

	public double this[int index]
	{
		get
		{
			return index switch
			{
				0 => double_0, 
				1 => double_1, 
				_ => throw new IndexOutOfRangeException(), 
			};
		}
		set
		{
			switch (index)
			{
			case 0:
				double_0 = value;
				break;
			default:
				throw new IndexOutOfRangeException();
			case 1:
				double_1 = value;
				break;
			}
		}
	}

	public Vector2D(double x, double y)
	{
		double_0 = x;
		double_1 = y;
	}

	public Vector2D(double[] coordinates)
	{
		double_0 = coordinates[0];
		double_1 = coordinates[1];
	}

	public Vector2D(List<double> coordinates)
	{
		double_0 = coordinates[0];
		double_1 = coordinates[1];
	}

	public Vector2D(Vector2D vector)
	{
		double_0 = vector.X;
		double_1 = vector.Y;
	}

	object ICloneable.Clone()
	{
		return new Vector2D(this);
	}

	public Vector2D Clone()
	{
		return new Vector2D(this);
	}

	public static Vector2D Parse(string value)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*)\\)", RegexOptions.Singleline).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Vector2D(double.Parse(match.Result("${x}")), double.Parse(match.Result("${y}")));
	}

	public static bool TryParse(string value, out Vector2D result)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*)\\)", RegexOptions.Singleline).Match(value);
		if (match.Success)
		{
			result = new Vector2D(double.Parse(match.Result("${x}")), double.Parse(match.Result("${y}")));
			return true;
		}
		result = Zero;
		return false;
	}

	public static Vector2D Add(Vector2D left, Vector2D right)
	{
		return new Vector2D(left.X + right.X, left.Y + right.Y);
	}

	public static Vector2D Add(Vector2D vector, double scalar)
	{
		return new Vector2D(vector.X + scalar, vector.Y + scalar);
	}

	public static void Add(Vector2D left, Vector2D right, ref Vector2D result)
	{
		result.X = left.X + right.X;
		result.Y = left.Y + right.Y;
	}

	public static void Add(Vector2D vector, double scalar, ref Vector2D result)
	{
		result.X = vector.X + scalar;
		result.Y = vector.Y + scalar;
	}

	public static Vector2D Subtract(Vector2D left, Vector2D right)
	{
		return new Vector2D(left.X - right.X, left.Y - right.Y);
	}

	public static Vector2D Subtract(Vector2D vector, double scalar)
	{
		return new Vector2D(vector.X - scalar, vector.Y - scalar);
	}

	public static Vector2D Subtract(double scalar, Vector2D vector)
	{
		return new Vector2D(scalar - vector.X, scalar - vector.Y);
	}

	public static void Subtract(Vector2D left, Vector2D right, ref Vector2D result)
	{
		result.X = left.X - right.X;
		result.Y = left.Y - right.Y;
	}

	public static void Subtract(Vector2D vector, double scalar, ref Vector2D result)
	{
		result.X = vector.X - scalar;
		result.Y = vector.Y - scalar;
	}

	public static void Subtract(double scalar, Vector2D vector, ref Vector2D result)
	{
		result.X = scalar - vector.X;
		result.Y = scalar - vector.Y;
	}

	public static Vector2D Divide(Vector2D left, Vector2D right)
	{
		return new Vector2D(left.X / right.X, left.Y / right.Y);
	}

	public static Vector2D Divide(Vector2D vector, double scalar)
	{
		return new Vector2D(vector.X / scalar, vector.Y / scalar);
	}

	public static Vector2D Divide(double scalar, Vector2D vector)
	{
		return new Vector2D(scalar / vector.X, scalar / vector.Y);
	}

	public static void Divide(Vector2D left, Vector2D right, ref Vector2D result)
	{
		result.X = left.X / right.X;
		result.Y = left.Y / right.Y;
	}

	public static void Divide(Vector2D vector, double scalar, ref Vector2D result)
	{
		result.X = vector.X / scalar;
		result.Y = vector.Y / scalar;
	}

	public static void Divide(double scalar, Vector2D vector, ref Vector2D result)
	{
		result.X = scalar / vector.X;
		result.Y = scalar / vector.Y;
	}

	public static Vector2D Multiply(Vector2D vector, double scalar)
	{
		return new Vector2D(vector.X * scalar, vector.Y * scalar);
	}

	public static void Multiply(Vector2D vector, double scalar, ref Vector2D result)
	{
		result.X = vector.X * scalar;
		result.Y = vector.Y * scalar;
	}

	public static double DotProduct(Vector2D left, Vector2D right)
	{
		return left.X * right.X + left.Y * right.Y;
	}

	public static double KrossProduct(Vector2D left, Vector2D right)
	{
		return left.X * right.Y - left.Y * right.X;
	}

	public static Vector2D Negate(Vector2D vector)
	{
		return new Vector2D(0.0 - vector.X, 0.0 - vector.Y);
	}

	public static bool ApproxEqual(Vector2D left, Vector2D right)
	{
		return ApproxEqual(left, right, 8.881784197001252E-16);
	}

	public static bool ApproxEqual(Vector2D left, Vector2D right, double tolerance)
	{
		if (System.Math.Abs(left.X - right.X) > tolerance)
		{
			return false;
		}
		return System.Math.Abs(left.Y - right.Y) <= tolerance;
	}

	public void Normalize()
	{
		double length = GetLength();
		if (length == 0.0)
		{
			throw new DivideByZeroException("Trying to normalize a vector with length of zero.");
		}
		double_0 /= length;
		double_1 /= length;
	}

	public double GetLength()
	{
		return System.Math.Sqrt(double_0 * double_0 + double_1 * double_1);
	}

	public double GetLengthSquared()
	{
		return double_0 * double_0 + double_1 * double_1;
	}

	public void ClampZero(double tolerance)
	{
		double_0 = MathFunctions.Clamp(double_0, 0.0, tolerance);
		double_1 = MathFunctions.Clamp(double_1, 0.0, tolerance);
	}

	public void ClampZero()
	{
		double_0 = MathFunctions.Clamp(double_0, 0.0);
		double_1 = MathFunctions.Clamp(double_1, 0.0);
	}

	public override int GetHashCode()
	{
		return double_0.GetHashCode() ^ double_1.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Vector2D vector2D))
		{
			return false;
		}
		if (double_0 == vector2D.X)
		{
			return double_1 == vector2D.Y;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1})", double_0, double_1);
	}

	public static bool operator ==(Vector2D left, Vector2D right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Vector2D left, Vector2D right)
	{
		return !object.Equals(left, right);
	}

	public static bool operator >(Vector2D left, Vector2D right)
	{
		if (left.double_0 <= right.double_0)
		{
			return false;
		}
		return left.double_1 > right.double_1;
	}

	public static bool operator <(Vector2D left, Vector2D right)
	{
		if (left.double_0 >= right.double_0)
		{
			return false;
		}
		return left.double_1 < right.double_1;
	}

	public static bool operator >=(Vector2D left, Vector2D right)
	{
		if (left.double_0 >= right.double_0)
		{
			return left.double_1 >= right.double_1;
		}
		return false;
	}

	public static bool operator <=(Vector2D left, Vector2D right)
	{
		if (left.double_0 <= right.double_0)
		{
			return left.double_1 <= right.double_1;
		}
		return false;
	}

	public static Vector2D operator -(Vector2D vector)
	{
		return Negate(vector);
	}

	public static Vector2D operator +(Vector2D left, Vector2D right)
	{
		return Add(left, right);
	}

	public static Vector2D operator +(Vector2D vector, double scalar)
	{
		return Add(vector, scalar);
	}

	public static Vector2D operator +(double scalar, Vector2D vector)
	{
		return Add(vector, scalar);
	}

	public static Vector2D operator -(Vector2D left, Vector2D right)
	{
		return Subtract(left, right);
	}

	public static Vector2D operator -(Vector2D vector, double scalar)
	{
		return Subtract(vector, scalar);
	}

	public static Vector2D operator -(double scalar, Vector2D vector)
	{
		return Subtract(scalar, vector);
	}

	public static Vector2D operator *(Vector2D vector, double scalar)
	{
		return Multiply(vector, scalar);
	}

	public static Vector2D operator *(double scalar, Vector2D vector)
	{
		return Multiply(vector, scalar);
	}

	public static Vector2D operator /(Vector2D vector, double scalar)
	{
		return Divide(vector, scalar);
	}

	public static Vector2D operator /(double scalar, Vector2D vector)
	{
		return Divide(scalar, vector);
	}

	public static explicit operator double[](Vector2D vector)
	{
		return new double[2] { vector.X, vector.Y };
	}

	public static explicit operator List<double>(Vector2D vector)
	{
		return new List<double>(2) { vector.X, vector.Y };
	}

	public static explicit operator LinkedList<double>(Vector2D vector)
	{
		LinkedList<double> linkedList = new LinkedList<double>();
		linkedList.AddLast(vector.X);
		linkedList.AddLast(vector.Y);
		return linkedList;
	}

	static Vector2D()
	{
		Class72.smethod_20();
		Zero = new Vector2D(0.0, 0.0);
		XAxis = new Vector2D(1.0, 0.0);
		YAxis = new Vector2D(0.0, 1.0);
	}
}
