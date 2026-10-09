using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
public struct ComplexD : ICloneable
{
	private double double_0;

	private double double_1;

	public static readonly ComplexD Zero;

	public static readonly ComplexD One;

	public static readonly ComplexD I;

	public double Real
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

	public double Imaginary
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

	public bool IsReal => double_1 == 0.0;

	public bool IsImaginary => double_0 == 0.0;

	public double Modulus => System.Math.Sqrt(double_0 * double_0 + double_1 * double_1);

	public double ModulusSquared => double_0 * double_0 + double_1 * double_1;

	public double Argument
	{
		get
		{
			if (double_1 == 0.0 && double_0 < 0.0)
			{
				return System.Math.PI;
			}
			if (double_1 == 0.0 && double_0 >= 0.0)
			{
				return 0.0;
			}
			return System.Math.Atan2(double_1, double_0);
		}
		set
		{
			double modulus = Modulus;
			double_0 = System.Math.Cos(value) * modulus;
			double_1 = System.Math.Sin(value) * modulus;
		}
	}

	public ComplexD Conjugate
	{
		get
		{
			return new ComplexD(double_0, 0.0 - double_1);
		}
		set
		{
			this = value.Conjugate;
		}
	}

	public ComplexD(double real, double imaginary)
	{
		double_0 = real;
		double_1 = imaginary;
	}

	public ComplexD(ComplexD c)
	{
		double_0 = c.Real;
		double_1 = c.Imaginary;
	}

	object ICloneable.Clone()
	{
		return new ComplexD(this);
	}

	public ComplexD Clone()
	{
		return new ComplexD(this);
	}

	public static ComplexD Parse(string value)
	{
		Match match = new Regex("\\((?<real>.*),(?<imaginary>.*)\\)", RegexOptions.None).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new ComplexD(double.Parse(match.Result("${real}")), double.Parse(match.Result("${imaginary}")));
	}

	public static bool TryParse(string value, out ComplexD result)
	{
		Match match = new Regex("\\((?<real>.*),(?<imaginary>.*)\\)", RegexOptions.None).Match(value);
		if (match.Success)
		{
			result = new ComplexD(double.Parse(match.Result("${real}")), double.Parse(match.Result("${imaginary}")));
			return true;
		}
		result = Zero;
		return false;
	}

	public static ComplexD Add(ComplexD left, ComplexD right)
	{
		return new ComplexD(left.Real + right.Real, left.Imaginary + right.Imaginary);
	}

	public static ComplexD Add(ComplexD complex, double scalar)
	{
		return new ComplexD(complex.Real + scalar, complex.Imaginary);
	}

	public static void Add(ComplexD left, ComplexD right, ref ComplexD result)
	{
		result.Real = left.Real + right.Real;
		result.Imaginary = left.Imaginary + right.Imaginary;
	}

	public static void Add(ComplexD complex, double scalar, ref ComplexD result)
	{
		result.Real = complex.Real + scalar;
		result.Imaginary = complex.Imaginary;
	}

	public static ComplexD Subtract(ComplexD left, ComplexD right)
	{
		return new ComplexD(left.Real - right.Real, left.Imaginary - right.Imaginary);
	}

	public static ComplexD Subtract(ComplexD complex, double scalar)
	{
		return new ComplexD(complex.Real - scalar, complex.Imaginary);
	}

	public static ComplexD Subtract(double scalar, ComplexD complex)
	{
		return new ComplexD(scalar - complex.Real, complex.Imaginary);
	}

	public static void Subtract(ComplexD left, ComplexD right, ref ComplexD result)
	{
		result.Real = left.Real - right.Real;
		result.Imaginary = left.Imaginary - right.Imaginary;
	}

	public static void Subtract(ComplexD complex, double scalar, ref ComplexD result)
	{
		result.Real = complex.Real - scalar;
		result.Imaginary = complex.Imaginary;
	}

	public static void Subtract(double scalar, ComplexD complex, ref ComplexD result)
	{
		result.Real = scalar - complex.Real;
		result.Imaginary = complex.Imaginary;
	}

	public static ComplexD Multiply(ComplexD left, ComplexD right)
	{
		double real = left.Real;
		double imaginary = left.Imaginary;
		double real2 = right.Real;
		double imaginary2 = right.Imaginary;
		return new ComplexD(real * real2 - imaginary * imaginary2, real * imaginary2 + imaginary * real2);
	}

	public static ComplexD Multiply(ComplexD complex, double scalar)
	{
		return new ComplexD(complex.Real * scalar, complex.Imaginary * scalar);
	}

	public static void Multiply(ComplexD left, ComplexD right, ref ComplexD result)
	{
		double real = left.Real;
		double imaginary = left.Imaginary;
		double real2 = right.Real;
		double imaginary2 = right.Imaginary;
		result.Real = real * real2 - imaginary * imaginary2;
		result.Imaginary = real * imaginary2 + imaginary * real2;
	}

	public static void Multiply(ComplexD complex, double scalar, ref ComplexD result)
	{
		result.Real = complex.Real * scalar;
		result.Imaginary = complex.Imaginary * scalar;
	}

	public static ComplexD Divide(ComplexD left, ComplexD right)
	{
		double real = left.Real;
		double imaginary = left.Imaginary;
		double real2 = right.Real;
		double imaginary2 = right.Imaginary;
		double num = real2 * real2 + imaginary2 * imaginary2;
		if (num == 0.0)
		{
			throw new DivideByZeroException();
		}
		double num2 = 1.0 / num;
		return new ComplexD((real * real2 + imaginary * imaginary2) * num2, (imaginary * real2 - real * imaginary2) * num2);
	}

	public static ComplexD Divide(ComplexD complex, double scalar)
	{
		if (scalar == 0.0)
		{
			throw new DivideByZeroException();
		}
		return new ComplexD(complex.Real / scalar, complex.Imaginary / scalar);
	}

	public static ComplexD Divide(double scalar, ComplexD complex)
	{
		if (complex.Real == 0.0 || complex.Imaginary == 0.0)
		{
			throw new DivideByZeroException();
		}
		return new ComplexD(scalar / complex.Real, scalar / complex.Imaginary);
	}

	public static void Divide(ComplexD left, ComplexD right, ref ComplexD result)
	{
		double real = left.Real;
		double imaginary = left.Imaginary;
		double real2 = right.Real;
		double imaginary2 = right.Imaginary;
		double num = real2 * real2 + imaginary2 * imaginary2;
		if (num == 0.0)
		{
			throw new DivideByZeroException();
		}
		double num2 = 1.0 / num;
		result.Real = (real * real2 + imaginary * imaginary2) * num2;
		result.Imaginary = (imaginary * real2 - real * imaginary2) * num2;
	}

	public static void Divide(ComplexD complex, double scalar, ref ComplexD result)
	{
		if (scalar == 0.0)
		{
			throw new DivideByZeroException();
		}
		result.Real = complex.Real / scalar;
		result.Imaginary = complex.Imaginary / scalar;
	}

	public static void Divide(double scalar, ComplexD complex, ref ComplexD result)
	{
		if (complex.Real == 0.0 || complex.Imaginary == 0.0)
		{
			throw new DivideByZeroException();
		}
		result.Real = scalar / complex.Real;
		result.Imaginary = scalar / complex.Imaginary;
	}

	public static ComplexD Negate(ComplexD complex)
	{
		return new ComplexD(0.0 - complex.Real, 0.0 - complex.Imaginary);
	}

	public static bool ApproxEqual(ComplexD left, ComplexD right)
	{
		return ApproxEqual(left, right, 8.881784197001252E-16);
	}

	public static bool ApproxEqual(ComplexD left, ComplexD right, double tolerance)
	{
		if (System.Math.Abs(left.Real - right.Real) > tolerance)
		{
			return false;
		}
		return System.Math.Abs(left.Imaginary - right.Imaginary) <= tolerance;
	}

	public static ComplexD Sqrt(ComplexD complex)
	{
		ComplexD zero = Zero;
		if (complex.Real == 0.0 && complex.Imaginary == 0.0)
		{
			return zero;
		}
		if (!complex.IsReal)
		{
			double modulus = complex.Modulus;
			zero.Real = System.Math.Sqrt(0.5 * (modulus + complex.Real));
			zero.Imaginary = System.Math.Sqrt(0.5 * (modulus - complex.Real));
			if (complex.Imaginary < 0.0)
			{
				zero.Imaginary = 0.0 - zero.Imaginary;
			}
		}
		else
		{
			zero.Real = ((complex.Real > 0.0) ? System.Math.Sqrt(complex.Real) : System.Math.Sqrt(0.0 - complex.Real));
			zero.Imaginary = 0.0;
		}
		return zero;
	}

	public static ComplexD Log(ComplexD complex)
	{
		ComplexD zero = Zero;
		if (complex.Real > 0.0 && complex.Imaginary == 0.0)
		{
			zero.Real = System.Math.Log(complex.Real);
			zero.Imaginary = 0.0;
		}
		else if (complex.Real == 0.0)
		{
			if (complex.Imaginary > 0.0)
			{
				zero.Real = System.Math.Log(complex.Imaginary);
				zero.Imaginary = System.Math.PI / 2.0;
			}
			else
			{
				zero.Real = System.Math.Log(0.0 - complex.Imaginary);
				zero.Imaginary = -System.Math.PI / 2.0;
			}
		}
		else
		{
			zero.Real = System.Math.Log(complex.Modulus);
			zero.Imaginary = System.Math.Atan2(complex.Imaginary, complex.Real);
		}
		return zero;
	}

	public static ComplexD Exp(ComplexD complex)
	{
		ComplexD zero = Zero;
		double num = System.Math.Exp(complex.Real);
		zero.Real = num * System.Math.Cos(complex.Imaginary);
		zero.Imaginary = num * System.Math.Sin(complex.Imaginary);
		return zero;
	}

	public static ComplexD Pow(ComplexD complex, ComplexD power)
	{
		return Exp(Multiply(power, Log(complex)));
	}

	public static ComplexD Square(ComplexD complex)
	{
		if (complex.IsReal)
		{
			return new ComplexD(complex.Real * complex.Real, 0.0);
		}
		double real = complex.Real;
		double imaginary = complex.Imaginary;
		return new ComplexD(real * real - imaginary * imaginary, 2.0 * real * imaginary);
	}

	public static ComplexD Sin(ComplexD complex)
	{
		ComplexD zero = Zero;
		if (!complex.IsReal)
		{
			zero.Real = System.Math.Sin(complex.Real) * System.Math.Cosh(complex.Imaginary);
			zero.Imaginary = System.Math.Cos(complex.Real) * System.Math.Sinh(complex.Imaginary);
		}
		else
		{
			zero.Real = System.Math.Sin(complex.Real);
			zero.Imaginary = 0.0;
		}
		return zero;
	}

	public static ComplexD Cos(ComplexD complex)
	{
		ComplexD zero = Zero;
		if (complex.IsReal)
		{
			zero.Real = System.Math.Cos(complex.Real);
			zero.Imaginary = 0.0;
		}
		else
		{
			zero.Real = System.Math.Cos(complex.Real) * System.Math.Cosh(complex.Imaginary);
			zero.Imaginary = (0.0 - System.Math.Sin(complex.Real)) * System.Math.Sinh(complex.Imaginary);
		}
		return zero;
	}

	public static ComplexD Tan(ComplexD complex)
	{
		ComplexD zero = Zero;
		if (complex.IsReal)
		{
			zero.Real = System.Math.Tan(complex.Real);
			zero.Imaginary = 0.0;
		}
		else
		{
			double num = System.Math.Cos(complex.Real);
			double num2 = System.Math.Sinh(complex.Imaginary);
			double num3 = num * num + num2 * num2;
			zero.Real = System.Math.Sin(complex.Real) * num / num3;
			zero.Imaginary = num2 * System.Math.Cosh(complex.Imaginary) / num3;
		}
		return zero;
	}

	public static ComplexD Cot(ComplexD complex)
	{
		ComplexD zero = Zero;
		if (complex.IsReal)
		{
			zero.Real = MathFunctions.Cot(complex.Real);
		}
		else
		{
			double num = System.Math.Sin(complex.Real);
			double num2 = System.Math.Sinh(complex.Imaginary);
			double num3 = num * num + num2 * num2;
			zero.Real = num * System.Math.Cos(complex.Real) / num3;
			zero.Imaginary = (0.0 - num2) * System.Math.Cosh(complex.Imaginary) / num3;
		}
		return zero;
	}

	public static ComplexD Sec(ComplexD complex)
	{
		ComplexD zero = Zero;
		if (!complex.IsReal)
		{
			double num = MathFunctions.Cos(complex.Real);
			double num2 = MathFunctions.Sinh(complex.Imaginary);
			double num3 = num * num + num2 * num2;
			zero.Real = num * MathFunctions.Cosh(complex.Imaginary) / num3;
			zero.Imaginary = MathFunctions.Sin(complex.Real) * num2 / num3;
		}
		else
		{
			zero.Real = MathFunctions.Sec(complex.Real);
		}
		return zero;
	}

	public static ComplexD Csc(ComplexD complex)
	{
		ComplexD zero = Zero;
		if (complex.IsReal)
		{
			zero.Real = MathFunctions.Csc(complex.Real);
		}
		else
		{
			double num = MathFunctions.Sin(complex.Real);
			double num2 = MathFunctions.Sinh(complex.Imaginary);
			double num3 = num * num + num2 * num2;
			zero.Real = num * MathFunctions.Cosh(complex.Imaginary) / num3;
			zero.Imaginary = (0.0 - MathFunctions.Cos(complex.Real)) * num2 / num3;
		}
		return zero;
	}

	public static ComplexD Asin(ComplexD complex)
	{
		ComplexD complex2 = Subtract(1.0, Square(complex));
		complex2 = Sqrt(complex2);
		complex2 = Add(complex2, Multiply(I, complex));
		complex2 = Log(complex2);
		return Multiply(Negate(I), complex2);
	}

	public static ComplexD Acos(ComplexD complex)
	{
		ComplexD complex2 = Subtract(1.0, Square(complex));
		complex2 = Sqrt(complex2);
		complex2 = Multiply(I, complex2);
		complex2 = Add(complex, complex2);
		complex2 = Log(complex2);
		return Multiply(Negate(I), complex2);
	}

	public static ComplexD Atan(ComplexD complex)
	{
		ComplexD complexD = new ComplexD(0.0 - complex.Imaginary, complex.Real);
		return Multiply(new ComplexD(0.0, 0.5), Subtract(Log(Subtract(1.0, complexD)), Log(1.0 + complexD)));
	}

	public static ComplexD Acot(ComplexD complex)
	{
		ComplexD complexD = new ComplexD(0.0 - complex.Imaginary, complex.Real);
		return Add(Multiply(new ComplexD(0.0, 0.5), Subtract(Log(1.0 + complexD), Log(Subtract(1.0, complexD)))), System.Math.PI / 2.0);
	}

	public static ComplexD Asec(ComplexD complex)
	{
		ComplexD complexD = Divide(1.0, complex);
		return Multiply(Negate(I), Log(Add(complexD, Multiply(I, Sqrt(Subtract(1.0, Square(complexD)))))));
	}

	public static ComplexD Acsc(ComplexD complex)
	{
		ComplexD complexD = Divide(1.0, complex);
		return Multiply(Negate(I), Log(Add(Multiply(I, complexD), Sqrt(Subtract(1.0, Square(complexD))))));
	}

	public static ComplexD Sinh(ComplexD complex)
	{
		if (!complex.IsReal)
		{
			return new ComplexD(System.Math.Sinh(complex.Real) * System.Math.Cos(complex.Imaginary), System.Math.Cosh(complex.Real) * System.Math.Sin(complex.Imaginary));
		}
		return new ComplexD(System.Math.Sinh(complex.Real), 0.0);
	}

	public static ComplexD Cosh(ComplexD complex)
	{
		if (!complex.IsReal)
		{
			return new ComplexD(System.Math.Cosh(complex.Real) * System.Math.Cos(complex.Imaginary), System.Math.Sinh(complex.Real) * System.Math.Sin(complex.Imaginary));
		}
		return new ComplexD(System.Math.Cosh(complex.Real), 0.0);
	}

	public static ComplexD Tanh(ComplexD complex)
	{
		if (!complex.IsReal)
		{
			double num = System.Math.Cos(complex.Imaginary);
			double num2 = System.Math.Sinh(complex.Real);
			double num3 = num * num + num2 * num2;
			return new ComplexD(num2 * System.Math.Cosh(complex.Real) / num3, num * System.Math.Sin(complex.Imaginary) / num3);
		}
		return new ComplexD(System.Math.Tanh(complex.Real), 0.0);
	}

	public static ComplexD Coth(ComplexD complex)
	{
		if (complex.IsReal)
		{
			return new ComplexD(MathFunctions.Coth(complex.Real), 0.0);
		}
		double num = 0.0 - System.Math.Sin(complex.Imaginary);
		double num2 = System.Math.Sinh(complex.Real);
		double num3 = num * num + num2 * num2;
		return new ComplexD(num2 * System.Math.Cosh(complex.Real) / num3, num * System.Math.Cos(complex.Imaginary) / num3);
	}

	public static ComplexD Sech(ComplexD complex)
	{
		if (!complex.IsReal)
		{
			ComplexD complexD = Exp(complex);
			return Divide(2.0 * complexD, Add(Square(complexD), 1.0));
		}
		return new ComplexD(MathFunctions.Sech(complex.Real), 0.0);
	}

	public static ComplexD Csch(ComplexD complex)
	{
		if (!complex.IsReal)
		{
			ComplexD complexD = Exp(complex);
			return Divide(2.0 * complexD, Subtract(Square(complexD), 1.0));
		}
		return new ComplexD(MathFunctions.Csch(complex.Real), 0.0);
	}

	public static ComplexD Asinh(ComplexD complex)
	{
		ComplexD right = Sqrt(Add(Square(complex), 1.0));
		return Log(Add(complex, right));
	}

	public static ComplexD Acosh(ComplexD complex)
	{
		ComplexD right = Multiply(Sqrt(Subtract(complex, 1.0)), Sqrt(Add(complex, 1.0)));
		right = Add(complex, right);
		return Log(right);
	}

	public static ComplexD Atanh(ComplexD complex)
	{
		return 0.5 * Subtract(Log(1.0 + complex), Log(Subtract(1.0, complex)));
	}

	public static ComplexD Acoth(ComplexD complex)
	{
		return 0.5 * Subtract(Log(Add(complex, 1.0)), Log(Subtract(complex, 1.0)));
	}

	public static ComplexD Asech(ComplexD complex)
	{
		ComplexD complexD = Divide(1.0, complex);
		return Log(Add(complexD, Multiply(Sqrt(Subtract(complexD, 1.0)), Sqrt(Add(complexD, 1.0)))));
	}

	public static ComplexD Acsch(ComplexD complex)
	{
		ComplexD complexD = Divide(1.0, complex);
		return Log(Add(complexD, Multiply(Square(Subtract(complexD, 1.0)), Square(Add(complexD, 1.0)))));
	}

	public void Normalize()
	{
		double modulus = Modulus;
		if (modulus == 0.0)
		{
			throw new DivideByZeroException("Can not normalize a complex number that is zero.");
		}
		double_0 /= modulus;
		double_1 /= modulus;
	}

	public override int GetHashCode()
	{
		return double_0.GetHashCode() ^ double_1.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is ComplexD complexD))
		{
			return false;
		}
		if (Real == complexD.Real)
		{
			return Imaginary == complexD.Imaginary;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1})", double_0, double_1);
	}

	public static bool operator ==(ComplexD left, ComplexD right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(ComplexD left, ComplexD right)
	{
		return !object.Equals(left, right);
	}

	public static ComplexD operator -(ComplexD complex)
	{
		return Negate(complex);
	}

	public static ComplexD operator +(ComplexD left, ComplexD right)
	{
		return Add(left, right);
	}

	public static ComplexD operator +(ComplexD complex, double scalar)
	{
		return Add(complex, scalar);
	}

	public static ComplexD operator +(double scalar, ComplexD complex)
	{
		return Add(complex, scalar);
	}

	public static ComplexD operator -(ComplexD left, ComplexD right)
	{
		return Subtract(left, right);
	}

	public static ComplexD operator -(ComplexD complex, double scalar)
	{
		return Subtract(complex, scalar);
	}

	public static ComplexD operator -(double scalar, ComplexD complex)
	{
		return Subtract(scalar, complex);
	}

	public static ComplexD operator *(ComplexD left, ComplexD right)
	{
		return Multiply(left, right);
	}

	public static ComplexD operator *(double scalar, ComplexD complex)
	{
		return Multiply(complex, scalar);
	}

	public static ComplexD operator *(ComplexD complex, double scalar)
	{
		return Multiply(complex, scalar);
	}

	public static ComplexD operator /(ComplexD left, ComplexD right)
	{
		return Divide(left, right);
	}

	public static ComplexD operator /(ComplexD complex, double scalar)
	{
		return Divide(complex, scalar);
	}

	public static ComplexD operator /(double scalar, ComplexD complex)
	{
		return Divide(scalar, complex);
	}

	static ComplexD()
	{
		Class72.smethod_20();
		Zero = new ComplexD(0.0, 0.0);
		One = new ComplexD(1.0, 0.0);
		I = new ComplexD(0.0, 1.0);
	}
}
