using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
public struct ComplexF : ICloneable
{
	private float float_0;

	private float float_1;

	public static readonly ComplexF Zero;

	public static readonly ComplexF One;

	public static readonly ComplexF I;

	public float Real
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

	public float Imaginary
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

	public bool IsReal => (double)float_1 == 0.0;

	public bool IsImaginary => (double)float_0 == 0.0;

	public float Modulus => (float)System.Math.Sqrt(float_0 * float_0 + float_1 * float_1);

	public float ModulusSquared => float_0 * float_0 + float_1 * float_1;

	public float Argument
	{
		get
		{
			if ((double)float_1 == 0.0 && (double)float_0 < 0.0)
			{
				return (float)System.Math.PI;
			}
			if ((double)float_1 == 0.0 && (double)float_0 >= 0.0)
			{
				return 0f;
			}
			return (float)System.Math.Atan2(float_1, float_0);
		}
		set
		{
			float modulus = Modulus;
			float_0 = (float)System.Math.Cos(value) * modulus;
			float_1 = (float)System.Math.Sin(value) * modulus;
		}
	}

	public ComplexF Conjugate
	{
		get
		{
			return new ComplexF(float_0, 0f - float_1);
		}
		set
		{
			this = value.Conjugate;
		}
	}

	public ComplexF(float real, float imaginary)
	{
		float_0 = real;
		float_1 = imaginary;
	}

	public ComplexF(ComplexF c)
	{
		float_0 = c.Real;
		float_1 = c.Imaginary;
	}

	object ICloneable.Clone()
	{
		return new ComplexF(this);
	}

	public ComplexF Clone()
	{
		return new ComplexF(this);
	}

	public static ComplexF Parse(string value)
	{
		Match match = new Regex("\\((?<real>.*),(?<imaginary>.*)\\)", RegexOptions.None).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new ComplexF(float.Parse(match.Result("${real}")), float.Parse(match.Result("${imaginary}")));
	}

	public static bool TryParse(string value, out ComplexF result)
	{
		Match match = new Regex("\\((?<real>.*),(?<imaginary>.*)\\)", RegexOptions.None).Match(value);
		if (match.Success)
		{
			result = new ComplexF(float.Parse(match.Result("${real}")), float.Parse(match.Result("${imaginary}")));
			return true;
		}
		result = Zero;
		return false;
	}

	public static ComplexF Add(ComplexF left, ComplexF right)
	{
		return new ComplexF(left.Real + right.Real, left.Imaginary + right.Imaginary);
	}

	public static ComplexF Add(ComplexF complex, float scalar)
	{
		return new ComplexF(complex.Real + scalar, complex.Imaginary);
	}

	public static void Add(ComplexF left, ComplexF right, ref ComplexF result)
	{
		result.Real = left.Real + right.Real;
		result.Imaginary = left.Imaginary + right.Imaginary;
	}

	public static void Add(ComplexF complex, float scalar, ref ComplexF result)
	{
		result.Real = complex.Real + scalar;
		result.Imaginary = complex.Imaginary;
	}

	public static ComplexF Subtract(ComplexF left, ComplexF right)
	{
		return new ComplexF(left.Real - right.Real, left.Imaginary - right.Imaginary);
	}

	public static ComplexF Subtract(ComplexF complex, float scalar)
	{
		return new ComplexF(complex.Real - scalar, complex.Imaginary);
	}

	public static ComplexF Subtract(float scalar, ComplexF complex)
	{
		return new ComplexF(scalar - complex.Real, complex.Imaginary);
	}

	public static void Subtract(ComplexF left, ComplexF right, ref ComplexF result)
	{
		result.Real = left.Real - right.Real;
		result.Imaginary = left.Imaginary - right.Imaginary;
	}

	public static void Subtract(ComplexF complex, float scalar, ref ComplexF result)
	{
		result.Real = complex.Real - scalar;
		result.Imaginary = complex.Imaginary;
	}

	public static void Subtract(float scalar, ComplexF complex, ref ComplexF result)
	{
		result.Real = scalar - complex.Real;
		result.Imaginary = complex.Imaginary;
	}

	public static ComplexF Multiply(ComplexF left, ComplexF right)
	{
		float real = left.Real;
		float imaginary = left.Imaginary;
		float real2 = right.Real;
		float imaginary2 = right.Imaginary;
		return new ComplexF(real * real2 - imaginary * imaginary2, real * imaginary2 + imaginary * real2);
	}

	public static ComplexF Multiply(ComplexF complex, float scalar)
	{
		return new ComplexF(complex.Real * scalar, complex.Imaginary * scalar);
	}

	public static void Multiply(ComplexF left, ComplexF right, ref ComplexF result)
	{
		float real = left.Real;
		float imaginary = left.Imaginary;
		float real2 = right.Real;
		float imaginary2 = right.Imaginary;
		result.Real = real * real2 - imaginary * imaginary2;
		result.Imaginary = real * imaginary2 + imaginary * real2;
	}

	public static void Multiply(ComplexF complex, float scalar, ref ComplexF result)
	{
		result.Real = complex.Real * scalar;
		result.Imaginary = complex.Imaginary * scalar;
	}

	public static ComplexF Divide(ComplexF left, ComplexF right)
	{
		float real = left.Real;
		float imaginary = left.Imaginary;
		float real2 = right.Real;
		float imaginary2 = right.Imaginary;
		float num = real2 * real2 + imaginary2 * imaginary2;
		if (num == 0f)
		{
			throw new DivideByZeroException();
		}
		float num2 = 1f / num;
		return new ComplexF((real * real2 + imaginary * imaginary2) * num2, (imaginary * real2 - real * imaginary2) * num2);
	}

	public static ComplexF Divide(ComplexF complex, float scalar)
	{
		if (scalar == 0f)
		{
			throw new DivideByZeroException();
		}
		return new ComplexF(complex.Real / scalar, complex.Imaginary / scalar);
	}

	public static ComplexF Divide(float scalar, ComplexF complex)
	{
		if (complex.Real == 0f || complex.Imaginary == 0f)
		{
			throw new DivideByZeroException();
		}
		return new ComplexF(scalar / complex.Real, scalar / complex.Imaginary);
	}

	public static void Divide(ComplexF left, ComplexF right, ref ComplexF result)
	{
		float real = left.Real;
		float imaginary = left.Imaginary;
		float real2 = right.Real;
		float imaginary2 = right.Imaginary;
		float num = real2 * real2 + imaginary2 * imaginary2;
		if (num == 0f)
		{
			throw new DivideByZeroException();
		}
		float num2 = 1f / num;
		result.Real = (real * real2 + imaginary * imaginary2) * num2;
		result.Imaginary = (imaginary * real2 - real * imaginary2) * num2;
	}

	public static void Divide(ComplexF complex, float scalar, ref ComplexF result)
	{
		if (scalar == 0f)
		{
			throw new DivideByZeroException();
		}
		result.Real = complex.Real / scalar;
		result.Imaginary = complex.Imaginary / scalar;
	}

	public static void Divide(float scalar, ComplexF complex, ref ComplexF result)
	{
		if (complex.Real == 0f || complex.Imaginary == 0f)
		{
			throw new DivideByZeroException();
		}
		result.Real = scalar / complex.Real;
		result.Imaginary = scalar / complex.Imaginary;
	}

	public static ComplexF Negate(ComplexF complex)
	{
		return new ComplexF(0f - complex.Real, 0f - complex.Imaginary);
	}

	public static bool ApproxEqual(ComplexF left, ComplexF right)
	{
		return ApproxEqual(left, right, 4.7683716E-07f);
	}

	public static bool ApproxEqual(ComplexF left, ComplexF right, float tolerance)
	{
		if (System.Math.Abs(left.Real - right.Real) > tolerance)
		{
			return false;
		}
		return System.Math.Abs(left.Imaginary - right.Imaginary) <= tolerance;
	}

	public static ComplexF Sqrt(ComplexF complex)
	{
		ComplexF zero = Zero;
		if (complex.Real == 0f && complex.Imaginary == 0f)
		{
			return zero;
		}
		if (complex.IsReal)
		{
			zero.Real = ((complex.Real > 0f) ? ((float)System.Math.Sqrt(complex.Real)) : ((float)System.Math.Sqrt(0f - complex.Real)));
			zero.Imaginary = 0f;
		}
		else
		{
			float modulus = complex.Modulus;
			zero.Real = (float)System.Math.Sqrt(0.5f * (modulus + complex.Real));
			zero.Imaginary = (float)System.Math.Sqrt(0.5f * (modulus - complex.Real));
			if (complex.Imaginary < 0f)
			{
				zero.Imaginary = 0f - zero.Imaginary;
			}
		}
		return zero;
	}

	public static ComplexF Log(ComplexF complex)
	{
		ComplexF zero = Zero;
		if ((double)complex.Real > 0.0 && (double)complex.Imaginary == 0.0)
		{
			zero.Real = (float)System.Math.Log(complex.Real);
			zero.Imaginary = 0f;
		}
		else if (complex.Real == 0f)
		{
			if (complex.Imaginary > 0f)
			{
				zero.Real = (float)System.Math.Log(complex.Imaginary);
				zero.Imaginary = (float)System.Math.PI / 2f;
			}
			else
			{
				zero.Real = (float)System.Math.Log(0f - complex.Imaginary);
				zero.Imaginary = -(float)System.Math.PI / 2f;
			}
		}
		else
		{
			zero.Real = (float)System.Math.Log(complex.Modulus);
			zero.Imaginary = (float)System.Math.Atan2(complex.Imaginary, complex.Real);
		}
		return zero;
	}

	public static ComplexF Exp(ComplexF complex)
	{
		ComplexF zero = Zero;
		float num = (float)System.Math.Exp(complex.Real);
		zero.Real = num * (float)System.Math.Cos(complex.Imaginary);
		zero.Imaginary = num * (float)System.Math.Sin(complex.Imaginary);
		return zero;
	}

	public static ComplexF Pow(ComplexF complex, ComplexF power)
	{
		return Exp(Multiply(power, Log(complex)));
	}

	public static ComplexF Square(ComplexF complex)
	{
		if (!complex.IsReal)
		{
			float real = complex.Real;
			float imaginary = complex.Imaginary;
			return new ComplexF(real * real - imaginary * imaginary, 2f * real * imaginary);
		}
		return new ComplexF(complex.Real * complex.Real, 0f);
	}

	public static ComplexF Sin(ComplexF complex)
	{
		ComplexF zero = Zero;
		if (!complex.IsReal)
		{
			zero.Real = (float)(System.Math.Sin(complex.Real) * System.Math.Cosh(complex.Imaginary));
			zero.Imaginary = (float)(System.Math.Cos(complex.Real) * System.Math.Sinh(complex.Imaginary));
		}
		else
		{
			zero.Real = (float)System.Math.Sin(complex.Real);
			zero.Imaginary = 0f;
		}
		return zero;
	}

	public static ComplexF Cos(ComplexF complex)
	{
		ComplexF zero = Zero;
		if (!complex.IsReal)
		{
			zero.Real = (float)(System.Math.Cos(complex.Real) * System.Math.Cosh(complex.Imaginary));
			zero.Imaginary = (float)((0.0 - System.Math.Sin(complex.Real)) * System.Math.Sinh(complex.Imaginary));
		}
		else
		{
			zero.Real = (float)System.Math.Cos(complex.Real);
			zero.Imaginary = 0f;
		}
		return zero;
	}

	public static ComplexF Tan(ComplexF complex)
	{
		ComplexF zero = Zero;
		if (!complex.IsReal)
		{
			float num = (float)System.Math.Cos(complex.Real);
			float num2 = (float)System.Math.Sinh(complex.Imaginary);
			float num3 = num * num + num2 * num2;
			zero.Real = (float)System.Math.Sin(complex.Real) * num / num3;
			zero.Imaginary = num2 * (float)System.Math.Cosh(complex.Imaginary) / num3;
		}
		else
		{
			zero.Real = (float)System.Math.Tan(complex.Real);
			zero.Imaginary = 0f;
		}
		return zero;
	}

	public static ComplexF Cot(ComplexF complex)
	{
		ComplexF zero = Zero;
		if (!complex.IsReal)
		{
			float num = (float)System.Math.Sin(complex.Real);
			float num2 = (float)System.Math.Sinh(complex.Imaginary);
			float num3 = num * num + num2 * num2;
			zero.Real = num * (float)System.Math.Cos(complex.Real) / num3;
			zero.Imaginary = (0f - num2) * (float)System.Math.Cosh(complex.Imaginary) / num3;
		}
		else
		{
			zero.Real = MathFunctions.Cot(complex.Real);
		}
		return zero;
	}

	public static ComplexF Sec(ComplexF complex)
	{
		ComplexF zero = Zero;
		if (complex.IsReal)
		{
			zero.Real = MathFunctions.Sec(complex.Real);
		}
		else
		{
			float num = MathFunctions.Cos(complex.Real);
			float num2 = (float)MathFunctions.Sinh(complex.Imaginary);
			float num3 = num * num + num2 * num2;
			zero.Real = num * (float)MathFunctions.Cosh(complex.Imaginary) / num3;
			zero.Imaginary = MathFunctions.Sin(complex.Real) * num2 / num3;
		}
		return zero;
	}

	public static ComplexF Csc(ComplexF complex)
	{
		ComplexF zero = Zero;
		if (!complex.IsReal)
		{
			float num = MathFunctions.Sin(complex.Real);
			float num2 = (float)MathFunctions.Sinh(complex.Imaginary);
			float num3 = num * num + num2 * num2;
			zero.Real = num * (float)MathFunctions.Cosh(complex.Imaginary) / num3;
			zero.Imaginary = (0f - MathFunctions.Cos(complex.Real)) * num2 / num3;
		}
		else
		{
			zero.Real = MathFunctions.Csc(complex.Real);
		}
		return zero;
	}

	public static ComplexF Asin(ComplexF complex)
	{
		ComplexF complex2 = Subtract(1f, Square(complex));
		complex2 = Sqrt(complex2);
		complex2 = Add(complex2, Multiply(I, complex));
		complex2 = Log(complex2);
		return Multiply(Negate(I), complex2);
	}

	public static ComplexF Acos(ComplexF complex)
	{
		ComplexF complex2 = Subtract(1f, Square(complex));
		complex2 = Sqrt(complex2);
		complex2 = Multiply(I, complex2);
		complex2 = Add(complex, complex2);
		complex2 = Log(complex2);
		return Multiply(Negate(I), complex2);
	}

	public static ComplexF Atan(ComplexF complex)
	{
		ComplexF complexF = new ComplexF(0f - complex.Imaginary, complex.Real);
		return Multiply(new ComplexF(0f, 0.5f), Subtract(Log(Subtract(1f, complexF)), Log(1f + complexF)));
	}

	public static ComplexF Acot(ComplexF complex)
	{
		ComplexF complexF = new ComplexF(0f - complex.Imaginary, complex.Real);
		return Add(Multiply(new ComplexF(0f, 0.5f), Subtract(Log(1f + complexF), Log(Subtract(1f, complexF)))), (float)System.Math.PI / 2f);
	}

	public static ComplexF Asec(ComplexF complex)
	{
		ComplexF complexF = Divide(1f, complex);
		return Multiply(Negate(I), Log(Add(complexF, Multiply(I, Sqrt(Subtract(1f, Square(complexF)))))));
	}

	public static ComplexF Acsc(ComplexF complex)
	{
		ComplexF complexF = Divide(1f, complex);
		return Multiply(Negate(I), Log(Add(Multiply(I, complexF), Sqrt(Subtract(1f, Square(complexF))))));
	}

	public static ComplexF Sinh(ComplexF complex)
	{
		if (complex.IsReal)
		{
			return new ComplexF((float)System.Math.Sinh(complex.Real), 0f);
		}
		return new ComplexF((float)(System.Math.Sinh(complex.Real) * System.Math.Cos(complex.Imaginary)), (float)(System.Math.Cosh(complex.Real) * System.Math.Sin(complex.Imaginary)));
	}

	public static ComplexF Cosh(ComplexF complex)
	{
		if (!complex.IsReal)
		{
			return new ComplexF((float)(System.Math.Cosh(complex.Real) * System.Math.Cos(complex.Imaginary)), (float)(System.Math.Sinh(complex.Real) * System.Math.Sin(complex.Imaginary)));
		}
		return new ComplexF((float)System.Math.Cosh(complex.Real), 0f);
	}

	public static ComplexF Tanh(ComplexF complex)
	{
		if (!complex.IsReal)
		{
			float num = (float)System.Math.Cos(complex.Imaginary);
			float num2 = (float)System.Math.Sinh(complex.Real);
			float num3 = num * num + num2 * num2;
			return new ComplexF(num2 * (float)System.Math.Cosh(complex.Real) / num3, num * (float)System.Math.Sin(complex.Imaginary) / num3);
		}
		return new ComplexF((float)System.Math.Tanh(complex.Real), 0f);
	}

	public static ComplexF Coth(ComplexF complex)
	{
		if (complex.IsReal)
		{
			return new ComplexF((float)MathFunctions.Coth(complex.Real), 0f);
		}
		float num = 0f - (float)System.Math.Sin(complex.Imaginary);
		float num2 = (float)System.Math.Sinh(complex.Real);
		float num3 = num * num + num2 * num2;
		return new ComplexF(num2 * (float)System.Math.Cosh(complex.Real) / num3, num * (float)System.Math.Cos(complex.Imaginary) / num3);
	}

	public static ComplexF Sech(ComplexF complex)
	{
		if (!complex.IsReal)
		{
			ComplexF complexF = Exp(complex);
			return Divide(2f * complexF, Add(Square(complexF), 1f));
		}
		return new ComplexF((float)MathFunctions.Sech(complex.Real), 0f);
	}

	public static ComplexF Csch(ComplexF complex)
	{
		if (!complex.IsReal)
		{
			ComplexF complexF = Exp(complex);
			return Divide(2f * complexF, Subtract(Square(complexF), 1f));
		}
		return new ComplexF((float)MathFunctions.Csch(complex.Real), 0f);
	}

	public static ComplexF Asinh(ComplexF complex)
	{
		ComplexF right = Sqrt(Add(Square(complex), 1f));
		return Log(Add(complex, right));
	}

	public static ComplexF Acosh(ComplexF complex)
	{
		ComplexF right = Multiply(Sqrt(Subtract(complex, 1f)), Sqrt(Add(complex, 1f)));
		right = Add(complex, right);
		return Log(right);
	}

	public static ComplexF Atanh(ComplexF complex)
	{
		return 0.5f * Subtract(Log(1f + complex), Log(Subtract(1f, complex)));
	}

	public static ComplexF Acoth(ComplexF complex)
	{
		return 0.5f * Subtract(Log(Add(complex, 1f)), Log(Subtract(complex, 1f)));
	}

	public static ComplexF Asech(ComplexF complex)
	{
		ComplexF complexF = Divide(1f, complex);
		return Log(Add(complexF, Multiply(Sqrt(Subtract(complexF, 1f)), Sqrt(Add(complexF, 1f)))));
	}

	public static ComplexF Acsch(ComplexF complex)
	{
		ComplexF complexF = Divide(1f, complex);
		return Log(Add(complexF, Multiply(Square(Subtract(complexF, 1f)), Square(Add(complexF, 1f)))));
	}

	public void Normalize()
	{
		float modulus = Modulus;
		if (modulus == 0f)
		{
			throw new DivideByZeroException("Can not normalize a complex number that is zero.");
		}
		float_0 /= modulus;
		float_1 /= modulus;
	}

	public override int GetHashCode()
	{
		return float_0.GetHashCode() ^ float_1.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is ComplexF complexF)
		{
			if (Real == complexF.Real)
			{
				return Imaginary == complexF.Imaginary;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1})", float_0, float_1);
	}

	public static bool operator ==(ComplexF left, ComplexF right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(ComplexF left, ComplexF right)
	{
		return !object.Equals(left, right);
	}

	public static ComplexF operator -(ComplexF complex)
	{
		return Negate(complex);
	}

	public static ComplexF operator +(ComplexF left, ComplexF right)
	{
		return Add(left, right);
	}

	public static ComplexF operator +(ComplexF complex, float scalar)
	{
		return Add(complex, scalar);
	}

	public static ComplexF operator +(float scalar, ComplexF complex)
	{
		return Add(complex, scalar);
	}

	public static ComplexF operator -(ComplexF left, ComplexF right)
	{
		return Subtract(left, right);
	}

	public static ComplexF operator -(ComplexF complex, float scalar)
	{
		return Subtract(complex, scalar);
	}

	public static ComplexF operator -(float scalar, ComplexF complex)
	{
		return Subtract(scalar, complex);
	}

	public static ComplexF operator *(ComplexF left, ComplexF right)
	{
		return Multiply(left, right);
	}

	public static ComplexF operator *(float scalar, ComplexF complex)
	{
		return Multiply(complex, scalar);
	}

	public static ComplexF operator *(ComplexF complex, float scalar)
	{
		return Multiply(complex, scalar);
	}

	public static ComplexF operator /(ComplexF left, ComplexF right)
	{
		return Divide(left, right);
	}

	public static ComplexF operator /(ComplexF complex, float scalar)
	{
		return Divide(complex, scalar);
	}

	public static ComplexF operator /(float scalar, ComplexF complex)
	{
		return Divide(scalar, complex);
	}

	static ComplexF()
	{
		Class72.smethod_20();
		Zero = new ComplexF(0f, 0f);
		One = new ComplexF(1f, 0f);
		I = new ComplexF(0f, 1f);
	}
}
