using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
public struct QuaternionD : ICloneable
{
	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	public static readonly QuaternionD Zero;

	public static readonly QuaternionD Identity;

	public static readonly QuaternionD XAxis;

	public static readonly QuaternionD YAxis;

	public static readonly QuaternionD ZAxis;

	public static readonly QuaternionD WAxis;

	public double W
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

	public double X
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

	public double Y
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

	public double Z
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

	public double Modulus => System.Math.Sqrt(double_0 * double_0 + double_1 * double_1 + double_2 * double_2 + double_3 * double_3);

	public double ModulusSquared => double_0 * double_0 + double_1 * double_1 + double_2 * double_2 + double_3 * double_3;

	public QuaternionD Conjugate
	{
		get
		{
			return new QuaternionD(double_0, 0.0 - double_1, 0.0 - double_2, 0.0 - double_3);
		}
		set
		{
			this = value.Conjugate;
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

	public QuaternionD(double w, double x, double y, double z)
	{
		double_0 = w;
		double_1 = x;
		double_2 = y;
		double_3 = z;
	}

	public QuaternionD(double[] coordinates)
	{
		double_0 = coordinates[0];
		double_1 = coordinates[1];
		double_2 = coordinates[2];
		double_3 = coordinates[3];
	}

	public QuaternionD(QuaternionD quaternion)
	{
		double_0 = quaternion.W;
		double_1 = quaternion.X;
		double_2 = quaternion.Y;
		double_3 = quaternion.Z;
	}

	object ICloneable.Clone()
	{
		return new QuaternionD(this);
	}

	public QuaternionD Clone()
	{
		return new QuaternionD(this);
	}

	public static QuaternionD Parse(string value)
	{
		Match match = new Regex("\\((?<w>.*),(?<x>.*),(?<y>.*),(?<z>.*)\\)", RegexOptions.None).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new QuaternionD(double.Parse(match.Result("${w}")), double.Parse(match.Result("${x}")), double.Parse(match.Result("${y}")), double.Parse(match.Result("${z}")));
	}

	public static bool TryParse(string value, out QuaternionD result)
	{
		Match match = new Regex("\\((?<w>.*),(?<x>.*),(?<y>.*),(?<z>.*)\\)", RegexOptions.None).Match(value);
		if (!match.Success)
		{
			result = Zero;
			return false;
		}
		result = new QuaternionD(double.Parse(match.Result("${x}")), double.Parse(match.Result("${y}")), double.Parse(match.Result("${z}")), double.Parse(match.Result("${w}")));
		return true;
	}

	public static QuaternionD Add(QuaternionD left, QuaternionD right)
	{
		return new QuaternionD(left.W + right.W, left.X + right.X, left.Y + right.Y, left.Z + right.Z);
	}

	public static void Add(QuaternionD left, QuaternionD right, ref QuaternionD result)
	{
		result.W = left.W + right.W;
		result.X = left.X + right.X;
		result.Y = left.Y + right.Y;
		result.Z = left.Z + right.Z;
	}

	public static QuaternionD Subtract(QuaternionD left, QuaternionD right)
	{
		return new QuaternionD(left.W - right.W, left.X - right.X, left.Y - right.Y, left.Z - right.Z);
	}

	public static void Subtract(QuaternionD left, QuaternionD right, ref QuaternionD result)
	{
		result.W = left.W - right.W;
		result.X = left.X - right.X;
		result.Y = left.Y - right.Y;
		result.Z = left.Z - right.Z;
	}

	public static QuaternionD Multiply(QuaternionD left, QuaternionD right)
	{
		return new QuaternionD
		{
			W = left.W * right.W - left.X * right.X - left.Y * right.Y - left.Z * right.Z,
			X = left.W * right.X + left.X * right.W + left.Y * right.Z - left.Z * right.Y,
			Y = left.W * right.Y + left.Y * right.W + left.Z * right.X - left.X * right.Z,
			Z = left.W * right.Z + left.Z * right.W + left.X * right.Y - left.Y * right.X
		};
	}

	public static void Multiply(QuaternionD left, QuaternionD right, ref QuaternionD result)
	{
		result.W = left.W * right.W - left.X * right.X - left.Y * right.Y - left.Z * right.Z;
		result.X = left.W * right.X + left.X * right.W + left.Y * right.Z - left.Z * right.Y;
		result.Y = left.W * right.Y + left.Y * right.W + left.Z * right.X - left.X * right.Z;
		result.Z = left.W * right.Z + left.Z * right.W + left.X * right.Y - left.Y * right.X;
	}

	public static QuaternionD Multiply(QuaternionD quaternion, double scalar)
	{
		QuaternionD result = new QuaternionD(quaternion);
		result.W *= scalar;
		result.X *= scalar;
		result.Y *= scalar;
		result.Z *= scalar;
		return result;
	}

	public static void Multiply(QuaternionD quaternion, double scalar, ref QuaternionD result)
	{
		result.W = quaternion.W * scalar;
		result.X = quaternion.X * scalar;
		result.Y = quaternion.Y * scalar;
		result.Z = quaternion.Z * scalar;
	}

	public static QuaternionD Divide(QuaternionD quaternion, double scalar)
	{
		if (scalar == 0.0)
		{
			throw new DivideByZeroException("Dividing quaternion by zero");
		}
		QuaternionD result = new QuaternionD(quaternion);
		result.W /= scalar;
		result.X /= scalar;
		result.Y /= scalar;
		result.Z /= scalar;
		return result;
	}

	public static void Divide(QuaternionD quaternion, double scalar, ref QuaternionD result)
	{
		if (scalar == 0.0)
		{
			throw new DivideByZeroException("Dividing quaternion by zero");
		}
		result.W = quaternion.W / scalar;
		result.X = quaternion.X / scalar;
		result.Y = quaternion.Y / scalar;
		result.Z = quaternion.Z / scalar;
	}

	public static double DotProduct(QuaternionD left, QuaternionD right)
	{
		return left.W * right.W + left.X * right.X + left.Y * right.Y + left.Z * right.Z;
	}

	public static QuaternionD Log(QuaternionD quaternion)
	{
		QuaternionD result = new QuaternionD(0.0, 0.0, 0.0, 0.0);
		if (MathFunctions.Abs(quaternion.W) < 1.0)
		{
			double num = System.Math.Acos(quaternion.W);
			double num2 = System.Math.Sin(num);
			if (MathFunctions.Abs(num2) < 0.0)
			{
				result.X = quaternion.X;
				result.Y = quaternion.Y;
				result.Z = quaternion.Z;
			}
			else
			{
				double num3 = num / num2;
				result.X = num3 * quaternion.X;
				result.Y = num3 * quaternion.Y;
				result.Z = num3 * quaternion.Z;
			}
		}
		return result;
	}

	public QuaternionD Exp(QuaternionD quaternion)
	{
		QuaternionD result = new QuaternionD(0.0, 0.0, 0.0, 0.0);
		double num = System.Math.Sqrt(quaternion.X * quaternion.X + quaternion.Y * quaternion.Y + quaternion.Z * quaternion.Z);
		double num2 = System.Math.Sin(num);
		if (MathFunctions.Abs(num2) > 0.0)
		{
			double num3 = num / num2;
			result.X = num3 * quaternion.X;
			result.Y = num3 * quaternion.Y;
			result.Z = num3 * quaternion.Z;
		}
		else
		{
			result.X = quaternion.X;
			result.Y = quaternion.Y;
			result.Z = quaternion.Z;
		}
		return result;
	}

	public void Inverse()
	{
		double modulusSquared = ModulusSquared;
		if (modulusSquared <= 0.0)
		{
			throw new QuaternionNotInvertibleException("Quaternion " + ToString() + " is not invertable");
		}
		double num = 1.0 / modulusSquared;
		double_0 *= num;
		double_1 *= 0.0 - num;
		double_2 *= 0.0 - num;
		double_3 *= 0.0 - num;
	}

	public void Normalize()
	{
		double modulus = Modulus;
		if (modulus == 0.0)
		{
			throw new DivideByZeroException("Trying to normalize a quaternion with modulus of zero.");
		}
		double_0 /= modulus;
		double_1 /= modulus;
		double_2 /= modulus;
		double_3 /= modulus;
	}

	public void ClampZero(double tolerance)
	{
		double_1 = MathFunctions.Clamp(double_1, 0.0, tolerance);
		double_2 = MathFunctions.Clamp(double_2, 0.0, tolerance);
		double_3 = MathFunctions.Clamp(double_3, 0.0, tolerance);
		double_0 = MathFunctions.Clamp(double_0, 0.0, tolerance);
	}

	public void ClampZero()
	{
		double_1 = MathFunctions.Clamp(double_1, 0.0);
		double_2 = MathFunctions.Clamp(double_2, 0.0);
		double_3 = MathFunctions.Clamp(double_3, 0.0);
		double_0 = MathFunctions.Clamp(double_0, 0.0);
	}

	public override int GetHashCode()
	{
		return double_0.GetHashCode() ^ double_1.GetHashCode() ^ double_2.GetHashCode() ^ double_3.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is QuaternionD quaternionD)
		{
			if (double_0 == quaternionD.W && double_1 == quaternionD.X && double_2 == quaternionD.Y)
			{
				return double_3 == quaternionD.Z;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1}, {2}, {3})", double_0, double_1, double_2, double_3);
	}

	public static bool operator ==(QuaternionD left, QuaternionD right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(QuaternionD left, QuaternionD right)
	{
		return !object.Equals(left, right);
	}

	public static QuaternionD operator +(QuaternionD left, QuaternionD right)
	{
		return Add(left, right);
	}

	public static QuaternionD operator -(QuaternionD left, QuaternionD right)
	{
		return Subtract(left, right);
	}

	public static QuaternionD operator *(QuaternionD left, QuaternionD right)
	{
		return Multiply(left, right);
	}

	public static QuaternionD operator *(QuaternionD quaternion, double scalar)
	{
		return Multiply(quaternion, scalar);
	}

	public static QuaternionD operator *(double scalar, QuaternionD quaternion)
	{
		return Multiply(quaternion, scalar);
	}

	public static QuaternionD operator /(QuaternionD quaternion, double scalar)
	{
		return Divide(quaternion, scalar);
	}

	public static QuaternionD operator /(double scalar, QuaternionD quaternion)
	{
		return Multiply(quaternion, 1.0 / scalar);
	}

	public static explicit operator double[](QuaternionD quaternion)
	{
		return new double[4] { quaternion.W, quaternion.X, quaternion.Y, quaternion.Z };
	}

	static QuaternionD()
	{
		Class72.smethod_20();
		Zero = new QuaternionD(0.0, 0.0, 0.0, 0.0);
		Identity = new QuaternionD(1.0, 0.0, 0.0, 0.0);
		XAxis = new QuaternionD(0.0, 1.0, 0.0, 0.0);
		YAxis = new QuaternionD(0.0, 0.0, 1.0, 0.0);
		ZAxis = new QuaternionD(0.0, 0.0, 0.0, 1.0);
		WAxis = new QuaternionD(1.0, 0.0, 0.0, 0.0);
	}
}
