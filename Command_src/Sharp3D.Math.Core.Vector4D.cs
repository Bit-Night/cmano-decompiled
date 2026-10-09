using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
[TypeConverter(typeof(Vector4DConverter))]
public struct Vector4D : ICloneable
{
	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	public static readonly Vector4D Zero;

	public static readonly Vector4D XAxis;

	public static readonly Vector4D YAxis;

	public static readonly Vector4D ZAxis;

	public static readonly Vector4D WAxis;

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

	public double W
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

	public double this[int index]
	{
		get
		{
			return index switch
			{
				0 => double_0, 
				1 => double_1, 
				2 => double_2, 
				3 => double_3, 
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
			case 3:
				double_3 = value;
				break;
			}
		}
	}

	public Vector4D(double x, double y, double z, double w)
	{
		double_0 = x;
		double_1 = y;
		double_2 = z;
		double_3 = w;
	}

	public Vector4D(double[] coordinates)
	{
		double_0 = coordinates[0];
		double_1 = coordinates[1];
		double_2 = coordinates[2];
		double_3 = coordinates[3];
	}

	public Vector4D(List<double> coordinates)
	{
		double_0 = coordinates[0];
		double_1 = coordinates[1];
		double_2 = coordinates[2];
		double_3 = coordinates[3];
	}

	public Vector4D(Vector4D vector)
	{
		double_0 = vector.X;
		double_1 = vector.Y;
		double_2 = vector.Z;
		double_3 = vector.W;
	}

	object ICloneable.Clone()
	{
		return new Vector4D(this);
	}

	public Vector4D Clone()
	{
		return new Vector4D(this);
	}

	public static Vector4D Parse(string value)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*),(?<z>.*),(?<w>.*)\\)", RegexOptions.Singleline).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Vector4D(double.Parse(match.Result("${x}")), double.Parse(match.Result("${y}")), double.Parse(match.Result("${z}")), double.Parse(match.Result("${w}")));
	}

	public static bool TryParse(string value, out Vector4D result)
	{
		Match match = new Regex("\\((?<x>.*),(?<y>.*),(?<z>.*),(?<w>.*)\\)", RegexOptions.Singleline).Match(value);
		if (match.Success)
		{
			result = new Vector4D(double.Parse(match.Result("${x}")), double.Parse(match.Result("${y}")), double.Parse(match.Result("${z}")), double.Parse(match.Result("${w}")));
			return true;
		}
		result = Zero;
		return false;
	}

	public static Vector4D Add(Vector4D left, Vector4D right)
	{
		return new Vector4D(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
	}

	public static Vector4D Add(Vector4D vector, double scalar)
	{
		return new Vector4D(vector.X + scalar, vector.Y + scalar, vector.Z + scalar, vector.W + scalar);
	}

	public static void Add(Vector4D left, Vector4D right, ref Vector4D result)
	{
		result.X = left.X + right.X;
		result.Y = left.Y + right.Y;
		result.Z = left.Z + right.Z;
		result.W = left.W + right.W;
	}

	public static void Add(Vector4D vector, double scalar, ref Vector4D result)
	{
		result.X = vector.X + scalar;
		result.Y = vector.Y + scalar;
		result.Z = vector.Z + scalar;
		result.W = vector.W + scalar;
	}

	public static Vector4D Subtract(Vector4D left, Vector4D right)
	{
		return new Vector4D(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
	}

	public static Vector4D Subtract(Vector4D vector, double scalar)
	{
		return new Vector4D(vector.X - scalar, vector.Y - scalar, vector.Z - scalar, vector.W - scalar);
	}

	public static Vector4D Subtract(double scalar, Vector4D vector)
	{
		return new Vector4D(scalar - vector.X, scalar - vector.Y, scalar - vector.Z, scalar - vector.W);
	}

	public static void Subtract(Vector4D left, Vector4D right, ref Vector4D result)
	{
		result.X = left.X - right.X;
		result.Y = left.Y - right.Y;
		result.Z = left.Z - right.Z;
		result.W = left.W - right.W;
	}

	public static void Subtract(Vector4D vector, double scalar, ref Vector4D result)
	{
		result.X = vector.X - scalar;
		result.Y = vector.Y - scalar;
		result.Z = vector.Z - scalar;
		result.W = vector.W - scalar;
	}

	public static void Subtract(double scalar, Vector4D vector, ref Vector4D result)
	{
		result.X = scalar - vector.X;
		result.Y = scalar - vector.Y;
		result.Z = scalar - vector.Z;
		result.W = scalar - vector.W;
	}

	public static Vector4D Divide(Vector4D left, Vector4D right)
	{
		return new Vector4D(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
	}

	public static Vector4D Divide(Vector4D vector, double scalar)
	{
		return new Vector4D(vector.X / scalar, vector.Y / scalar, vector.Z / scalar, vector.W / scalar);
	}

	public static Vector4D Divide(double scalar, Vector4D vector)
	{
		return new Vector4D(scalar / vector.X, scalar / vector.Y, scalar / vector.Z, scalar / vector.W);
	}

	public static void Divide(Vector4D left, Vector4D right, ref Vector4D result)
	{
		result.X = left.X / right.X;
		result.Y = left.Y / right.Y;
		result.Z = left.Z / right.Z;
		result.W = left.W / right.W;
	}

	public static void Divide(Vector4D vector, double scalar, ref Vector4D result)
	{
		result.X = vector.X / scalar;
		result.Y = vector.Y / scalar;
		result.Z = vector.Z / scalar;
		result.W = vector.W / scalar;
	}

	public static void Divide(double scalar, Vector4D vector, ref Vector4D result)
	{
		result.X = scalar / vector.X;
		result.Y = scalar / vector.Y;
		result.Z = scalar / vector.Z;
		result.W = scalar / vector.W;
	}

	public static Vector4D Multiply(Vector4D vector, double scalar)
	{
		return new Vector4D(vector.X * scalar, vector.Y * scalar, vector.Z * scalar, vector.W * scalar);
	}

	public static void Multiply(Vector4D vector, double scalar, ref Vector4D result)
	{
		result.X = vector.X * scalar;
		result.Y = vector.Y * scalar;
		result.Z = vector.Z * scalar;
		result.W = vector.W * scalar;
	}

	public static double DotProduct(Vector4D left, Vector4D right)
	{
		return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
	}

	public static Vector4D Negate(Vector4D vector)
	{
		return new Vector4D(0.0 - vector.X, 0.0 - vector.Y, 0.0 - vector.Z, 0.0 - vector.W);
	}

	public static bool ApproxEqual(Vector4D left, Vector4D right)
	{
		return ApproxEqual(left, right, 8.881784197001252E-16);
	}

	public static bool ApproxEqual(Vector4D left, Vector4D right, double tolerance)
	{
		if (System.Math.Abs(left.X - right.X) <= tolerance && System.Math.Abs(left.Y - right.Y) <= tolerance && System.Math.Abs(left.Z - right.Z) <= tolerance)
		{
			return System.Math.Abs(left.W - right.W) <= tolerance;
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
		double_3 /= length;
	}

	public double GetLength()
	{
		return System.Math.Sqrt(double_0 * double_0 + double_1 * double_1 + double_2 * double_2 + double_3 * double_3);
	}

	public double GetLengthSquared()
	{
		return double_0 * double_0 + double_1 * double_1 + double_2 * double_2 + double_3 * double_3;
	}

	public void ClampZero(double tolerance)
	{
		double_0 = MathFunctions.Clamp(double_0, 0.0, tolerance);
		double_1 = MathFunctions.Clamp(double_1, 0.0, tolerance);
		double_2 = MathFunctions.Clamp(double_2, 0.0, tolerance);
		double_3 = MathFunctions.Clamp(double_3, 0.0, tolerance);
	}

	public void ClampZero()
	{
		double_0 = MathFunctions.Clamp(double_0, 0.0);
		double_1 = MathFunctions.Clamp(double_1, 0.0);
		double_2 = MathFunctions.Clamp(double_2, 0.0);
		double_3 = MathFunctions.Clamp(double_3, 0.0);
	}

	public override int GetHashCode()
	{
		return double_0.GetHashCode() ^ double_1.GetHashCode() ^ double_2.GetHashCode() ^ double_3.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Vector4D vector4D)
		{
			if (double_0 == vector4D.X && double_1 == vector4D.Y && double_2 == vector4D.Z)
			{
				return double_3 == vector4D.W;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1}, {2}, {3})", double_0, double_1, double_2, double_3);
	}

	public static bool operator ==(Vector4D left, Vector4D right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Vector4D left, Vector4D right)
	{
		return !object.Equals(left, right);
	}

	public static bool operator >(Vector4D left, Vector4D right)
	{
		if (left.double_0 > right.double_0 && left.double_1 > right.double_1 && left.double_2 > right.double_2)
		{
			return left.double_3 > right.double_3;
		}
		return false;
	}

	public static bool operator <(Vector4D left, Vector4D right)
	{
		if (left.double_0 < right.double_0 && left.double_1 < right.double_1 && left.double_2 < right.double_2)
		{
			return left.double_3 < right.double_3;
		}
		return false;
	}

	public static bool operator >=(Vector4D left, Vector4D right)
	{
		if (left.double_0 >= right.double_0 && left.double_1 >= right.double_1 && left.double_2 >= right.double_2)
		{
			return left.double_3 >= right.double_3;
		}
		return false;
	}

	public static bool operator <=(Vector4D left, Vector4D right)
	{
		if (left.double_0 <= right.double_0 && left.double_1 <= right.double_1 && left.double_2 <= right.double_2)
		{
			return left.double_3 <= right.double_3;
		}
		return false;
	}

	public static Vector4D operator -(Vector4D vector)
	{
		return Negate(vector);
	}

	public static Vector4D operator +(Vector4D left, Vector4D right)
	{
		return Add(left, right);
	}

	public static Vector4D operator +(Vector4D vector, double scalar)
	{
		return Add(vector, scalar);
	}

	public static Vector4D operator +(double scalar, Vector4D vector)
	{
		return Add(vector, scalar);
	}

	public static Vector4D operator -(Vector4D left, Vector4D right)
	{
		return Subtract(left, right);
	}

	public static Vector4D operator -(Vector4D vector, double scalar)
	{
		return Subtract(vector, scalar);
	}

	public static Vector4D operator -(double scalar, Vector4D vector)
	{
		return Subtract(scalar, vector);
	}

	public static Vector4D operator *(Vector4D vector, double scalar)
	{
		return Multiply(vector, scalar);
	}

	public static Vector4D operator *(double scalar, Vector4D vector)
	{
		return Multiply(vector, scalar);
	}

	public static Vector4D operator /(Vector4D vector, double scalar)
	{
		return Divide(vector, scalar);
	}

	public static Vector4D operator /(double scalar, Vector4D vector)
	{
		return Divide(scalar, vector);
	}

	public static explicit operator double[](Vector4D vector)
	{
		return new double[4] { vector.X, vector.Y, vector.Z, vector.W };
	}

	public static explicit operator List<double>(Vector4D vector)
	{
		return new List<double>(4) { vector.X, vector.Y, vector.Z, vector.W };
	}

	public static explicit operator LinkedList<double>(Vector4D vector)
	{
		LinkedList<double> linkedList = new LinkedList<double>();
		linkedList.AddLast(vector.X);
		linkedList.AddLast(vector.Y);
		linkedList.AddLast(vector.Z);
		linkedList.AddLast(vector.W);
		return linkedList;
	}

	static Vector4D()
	{
		Class72.smethod_20();
		Zero = new Vector4D(0.0, 0.0, 0.0, 0.0);
		XAxis = new Vector4D(1.0, 0.0, 0.0, 0.0);
		YAxis = new Vector4D(0.0, 1.0, 0.0, 0.0);
		ZAxis = new Vector4D(0.0, 0.0, 1.0, 0.0);
		WAxis = new Vector4D(0.0, 0.0, 0.0, 1.0);
	}
}
