using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(Vector3DConverter))]
public struct Vector3D : ICloneable
{
	private double double_0;

	private double double_1;

	private double double_2;

	public static readonly Vector3D Zero;

	public static readonly Vector3D XAxis;

	public static readonly Vector3D YAxis;

	public static readonly Vector3D ZAxis;

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

	public double Z
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

	public double this[int index]
	{
		get
		{
			return index switch
			{
				0 => double_0, 
				1 => double_1, 
				2 => double_2, 
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
				double_0 = value;
				break;
			case 1:
				double_1 = value;
				break;
			case 2:
				double_2 = value;
				break;
			}
		}
	}

	public Vector3D(double x, double y, double z)
	{
		double_0 = x;
		double_1 = y;
		double_2 = z;
	}

	public Vector3D(double[] coordinates)
	{
		double_0 = coordinates[0];
		double_1 = coordinates[1];
		double_2 = coordinates[2];
	}

	public Vector3D(List<double> coordinates)
	{
		double_0 = coordinates[0];
		double_1 = coordinates[1];
		double_2 = coordinates[2];
	}

	public Vector3D(Vector3D vector)
	{
		double_0 = vector.X;
		double_1 = vector.Y;
		double_2 = vector.Z;
	}

	object ICloneable.Clone()
	{
		return new Vector3D(this);
	}

	public Vector3D Clone()
	{
		return new Vector3D(this);
	}

	public static Vector3D Parse(string value)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*),(?<z>.*)\\)", RegexOptions.Singleline).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		return new Vector3D(double.Parse(match.Result("${x}"), NumberStyles.Number, invariantCulture), double.Parse(match.Result("${y}"), NumberStyles.Number, invariantCulture), double.Parse(match.Result("${z}"), NumberStyles.Number, invariantCulture));
	}

	public static bool TryParse(string value, out Vector3D result)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*),(?<z>.*)\\)", RegexOptions.Singleline).Match(value);
		if (match.Success)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			result = new Vector3D(double.Parse(match.Result("${x}"), NumberStyles.Number, invariantCulture), double.Parse(match.Result("${y}"), NumberStyles.Number, invariantCulture), double.Parse(match.Result("${z}"), NumberStyles.Number, invariantCulture));
			return true;
		}
		result = Zero;
		return false;
	}

	public static Vector3D Add(Vector3D left, Vector3D right)
	{
		return new Vector3D(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
	}

	public static Vector3D Add(Vector3D vector, double scalar)
	{
		return new Vector3D(vector.X + scalar, vector.Y + scalar, vector.Z + scalar);
	}

	public static void Add(Vector3D left, Vector3D right, ref Vector3D result)
	{
		result.X = left.X + right.X;
		result.Y = left.Y + right.Y;
		result.Z = left.Z + right.Z;
	}

	public static void Add(Vector3D vector, double scalar, ref Vector3D result)
	{
		result.X = vector.X + scalar;
		result.Y = vector.Y + scalar;
		result.Z = vector.Z + scalar;
	}

	public static Vector3D Subtract(Vector3D left, Vector3D right)
	{
		return new Vector3D(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
	}

	public static Vector3D Subtract(Vector3D vector, double scalar)
	{
		return new Vector3D(vector.X - scalar, vector.Y - scalar, vector.Z - scalar);
	}

	public static Vector3D Subtract(double scalar, Vector3D vector)
	{
		return new Vector3D(scalar - vector.X, scalar - vector.Y, scalar - vector.Z);
	}

	public static void Subtract(Vector3D left, Vector3D right, ref Vector3D result)
	{
		result.X = left.X - right.X;
		result.Y = left.Y - right.Y;
		result.Z = left.Z - right.Z;
	}

	public static void Subtract(Vector3D vector, double scalar, ref Vector3D result)
	{
		result.X = vector.X - scalar;
		result.Y = vector.Y - scalar;
		result.Z = vector.Z - scalar;
	}

	public static void Subtract(double scalar, Vector3D vector, ref Vector3D result)
	{
		result.X = scalar - vector.X;
		result.Y = scalar - vector.Y;
		result.Z = scalar - vector.Z;
	}

	public static Vector3D Divide(Vector3D left, Vector3D right)
	{
		return new Vector3D(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
	}

	public static Vector3D Divide(Vector3D vector, double scalar)
	{
		return new Vector3D(vector.X / scalar, vector.Y / scalar, vector.Z / scalar);
	}

	public static Vector3D Divide(double scalar, Vector3D vector)
	{
		return new Vector3D(scalar / vector.X, scalar / vector.Y, scalar / vector.Z);
	}

	public static void Divide(Vector3D left, Vector3D right, ref Vector3D result)
	{
		result.X = left.X / right.X;
		result.Y = left.Y / right.Y;
		result.Z = left.Z / right.Z;
	}

	public static void Divide(Vector3D vector, double scalar, ref Vector3D result)
	{
		result.X = vector.X / scalar;
		result.Y = vector.Y / scalar;
		result.Z = vector.Z / scalar;
	}

	public static void Divide(double scalar, Vector3D vector, ref Vector3D result)
	{
		result.X = scalar / vector.X;
		result.Y = scalar / vector.Y;
		result.Z = scalar / vector.Z;
	}

	public static Vector3D Multiply(Vector3D vector, double scalar)
	{
		return new Vector3D(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
	}

	public static void Multiply(Vector3D vector, double scalar, ref Vector3D result)
	{
		result.X = vector.X * scalar;
		result.Y = vector.Y * scalar;
		result.Z = vector.Z * scalar;
	}

	public static double DotProduct(Vector3D left, Vector3D right)
	{
		return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
	}

	public static Vector3D CrossProduct(Vector3D left, Vector3D right)
	{
		return new Vector3D(left.Y * right.Z - left.Z * right.Y, left.Z * right.X - left.X * right.Z, left.X * right.Y - left.Y * right.X);
	}

	public static void CrossProduct(Vector3D left, Vector3D right, ref Vector3D result)
	{
		result.X = left.Y * right.Z - left.Z * right.Y;
		result.Y = left.Z * right.X - left.X * right.Z;
		result.Z = left.X * right.Y - left.Y * right.X;
	}

	public static Vector3D Negate(Vector3D vector)
	{
		return new Vector3D(0.0 - vector.X, 0.0 - vector.Y, 0.0 - vector.Z);
	}

	public static bool ApproxEqual(Vector3D left, Vector3D right)
	{
		return ApproxEqual(left, right, 8.881784197001252E-16);
	}

	public static bool ApproxEqual(Vector3D left, Vector3D right, double tolerance)
	{
		if (System.Math.Abs(left.X - right.X) <= tolerance && System.Math.Abs(left.Y - right.Y) <= tolerance)
		{
			return System.Math.Abs(left.Z - right.Z) <= tolerance;
		}
		return false;
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
		double_2 /= length;
	}

	public double GetLength()
	{
		return System.Math.Sqrt(double_0 * double_0 + double_1 * double_1 + double_2 * double_2);
	}

	public double GetLengthSquared()
	{
		return double_0 * double_0 + double_1 * double_1 + double_2 * double_2;
	}

	public void ClampZero(double tolerance)
	{
		double_0 = MathFunctions.Clamp(double_0, 0.0, tolerance);
		double_1 = MathFunctions.Clamp(double_1, 0.0, tolerance);
		double_2 = MathFunctions.Clamp(double_2, 0.0, tolerance);
	}

	public void ClampZero()
	{
		double_0 = MathFunctions.Clamp(double_0, 0.0);
		double_1 = MathFunctions.Clamp(double_1, 0.0);
		double_2 = MathFunctions.Clamp(double_2, 0.0);
	}

	public override int GetHashCode()
	{
		return double_0.GetHashCode() ^ double_1.GetHashCode() ^ double_2.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Vector3D vector3D)
		{
			if (double_0 == vector3D.X && double_1 == vector3D.Y)
			{
				return double_2 == vector3D.Z;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1}, {2})", double_0, double_1, double_2);
	}

	public static bool operator ==(Vector3D left, Vector3D right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Vector3D left, Vector3D right)
	{
		return !object.Equals(left, right);
	}

	public static bool operator >(Vector3D left, Vector3D right)
	{
		if (left.double_0 > right.double_0 && left.double_1 > right.double_1)
		{
			return left.double_2 > right.double_2;
		}
		return false;
	}

	public static bool operator <(Vector3D left, Vector3D right)
	{
		if (left.double_0 < right.double_0 && left.double_1 < right.double_1)
		{
			return left.double_2 < right.double_2;
		}
		return false;
	}

	public static bool operator >=(Vector3D left, Vector3D right)
	{
		if (left.double_0 >= right.double_0 && left.double_1 >= right.double_1)
		{
			return left.double_2 >= right.double_2;
		}
		return false;
	}

	public static bool operator <=(Vector3D left, Vector3D right)
	{
		if (left.double_0 <= right.double_0 && left.double_1 <= right.double_1)
		{
			return left.double_2 <= right.double_2;
		}
		return false;
	}

	public static Vector3D operator -(Vector3D vector)
	{
		return Negate(vector);
	}

	public static Vector3D operator +(Vector3D left, Vector3D right)
	{
		return Add(left, right);
	}

	public static Vector3D operator +(Vector3D vector, double scalar)
	{
		return Add(vector, scalar);
	}

	public static Vector3D operator +(double scalar, Vector3D vector)
	{
		return Add(vector, scalar);
	}

	public static Vector3D operator -(Vector3D left, Vector3D right)
	{
		return Subtract(left, right);
	}

	public static Vector3D operator -(Vector3D vector, double scalar)
	{
		return Subtract(vector, scalar);
	}

	public static Vector3D operator -(double scalar, Vector3D vector)
	{
		return Subtract(scalar, vector);
	}

	public static Vector3D operator *(Vector3D vector, double scalar)
	{
		return Multiply(vector, scalar);
	}

	public static Vector3D operator *(double scalar, Vector3D vector)
	{
		return Multiply(vector, scalar);
	}

	public static Vector3D operator /(Vector3D vector, double scalar)
	{
		return Divide(vector, scalar);
	}

	public static Vector3D operator /(double scalar, Vector3D vector)
	{
		return Divide(scalar, vector);
	}

	public static explicit operator double[](Vector3D vector)
	{
		return new double[3] { vector.X, vector.Y, vector.Z };
	}

	public static explicit operator List<double>(Vector3D vector)
	{
		return new List<double>(3) { vector.X, vector.Y, vector.Z };
	}

	public static explicit operator LinkedList<double>(Vector3D vector)
	{
		LinkedList<double> linkedList = new LinkedList<double>();
		linkedList.AddLast(vector.X);
		linkedList.AddLast(vector.Y);
		linkedList.AddLast(vector.Z);
		return linkedList;
	}

	static Vector3D()
	{
		Class72.smethod_20();
		Zero = new Vector3D(0.0, 0.0, 0.0);
		XAxis = new Vector3D(1.0, 0.0, 0.0);
		YAxis = new Vector3D(0.0, 1.0, 0.0);
		ZAxis = new Vector3D(0.0, 0.0, 1.0);
	}
}
