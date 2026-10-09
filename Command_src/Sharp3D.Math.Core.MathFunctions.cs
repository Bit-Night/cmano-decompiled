using System;

namespace Sharp3D.Math.Core;

public static class MathFunctions
{
	public delegate T VoidFunction<T>();

	public delegate T UnaryFunction<T>(T param);

	public delegate T BinaryFunction<T>(T param1, T param2);

	public delegate T TenaryFunction<T>(T param1, T param2, T param3);

	public const double PI = System.Math.PI;

	public const double TwoPI = System.Math.PI * 2.0;

	public const double SquaredPI = 9.869604401089358;

	public const double HalfPI = System.Math.PI / 2.0;

	public const float EpsilonF = 4.7683716E-07f;

	public const double EpsilonD = 8.881784197001252E-16;

	public static readonly UnaryFunction<double> DoubleSinFunction;

	public static readonly UnaryFunction<double> DoubleCosFunction;

	public static readonly UnaryFunction<double> DoubleTanFunction;

	public static readonly UnaryFunction<double> DoubleCotFunction;

	public static readonly UnaryFunction<double> DoubleSecFunction;

	public static readonly UnaryFunction<double> DoubleCscFunction;

	public static readonly UnaryFunction<ComplexD> unaryFunction_0;

	public static readonly UnaryFunction<ComplexD> unaryFunction_1;

	public static readonly UnaryFunction<ComplexD> unaryFunction_2;

	public static readonly UnaryFunction<ComplexD> unaryFunction_3;

	public static readonly UnaryFunction<ComplexD> unaryFunction_4;

	public static readonly UnaryFunction<ComplexD> unaryFunction_5;

	public static readonly UnaryFunction<double> DoubleAsinFunction;

	public static readonly UnaryFunction<double> DoubleAcosFunction;

	public static readonly UnaryFunction<double> DoubleAtanFunction;

	public static readonly UnaryFunction<double> DoubleAcotFunction;

	public static readonly UnaryFunction<double> DoubleAsecFunction;

	public static readonly UnaryFunction<double> DoubleAcscFunction;

	public static readonly UnaryFunction<ComplexD> unaryFunction_6;

	public static readonly UnaryFunction<ComplexD> unaryFunction_7;

	public static readonly UnaryFunction<ComplexD> unaryFunction_8;

	public static readonly UnaryFunction<ComplexD> unaryFunction_9;

	public static readonly UnaryFunction<ComplexD> unaryFunction_10;

	public static readonly UnaryFunction<ComplexD> unaryFunction_11;

	public static readonly UnaryFunction<double> DoubleSinhFunction;

	public static readonly UnaryFunction<double> DoubleCoshFunction;

	public static readonly UnaryFunction<double> DoubleTanhFunction;

	public static readonly UnaryFunction<double> DoubleCothFunction;

	public static readonly UnaryFunction<double> DoubleSechFunction;

	public static readonly UnaryFunction<double> DoubleCschFunction;

	public static readonly UnaryFunction<ComplexD> unaryFunction_12;

	public static readonly UnaryFunction<ComplexD> unaryFunction_13;

	public static readonly UnaryFunction<ComplexD> unaryFunction_14;

	public static readonly UnaryFunction<ComplexD> unaryFunction_15;

	public static readonly UnaryFunction<ComplexD> unaryFunction_16;

	public static readonly UnaryFunction<ComplexD> unaryFunction_17;

	public static readonly UnaryFunction<double> DoubleAsinhFunction;

	public static readonly UnaryFunction<double> DoubleAcoshFunction;

	public static readonly UnaryFunction<double> DoubleAtanhFunction;

	public static readonly UnaryFunction<double> DoubleAcothFunction;

	public static readonly UnaryFunction<double> DoubleAsechFunction;

	public static readonly UnaryFunction<double> DoubleAcschFunction;

	public static readonly UnaryFunction<ComplexD> ComplexDAsinhFunction;

	public static readonly UnaryFunction<ComplexD> ComplexDAcoshFunction;

	public static readonly UnaryFunction<ComplexD> ComplexDAtanhFunction;

	public static readonly UnaryFunction<ComplexD> ComplexDAcothFunction;

	public static readonly UnaryFunction<ComplexD> ComplexDAsechFunction;

	public static readonly UnaryFunction<ComplexD> ComplexDAcschFunction;

	public static readonly UnaryFunction<float> FloatAbsFunction;

	public static readonly UnaryFunction<double> DoubleAbsFunction;

	public static readonly UnaryFunction<int> IntAbsFunction;

	public static readonly UnaryFunction<double> DoubleSqrtFunction;

	public static int Abs(int x)
	{
		return System.Math.Abs(x);
	}

	public static float Abs(float x)
	{
		return System.Math.Abs(x);
	}

	public static double Abs(double x)
	{
		return System.Math.Abs(x);
	}

	public static int[] Abs(int[] array)
	{
		int[] array2 = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = Abs(array[i]);
		}
		return array2;
	}

	public static float[] Abs(float[] array)
	{
		float[] array2 = new float[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = Abs(array[i]);
		}
		return array2;
	}

	public static double[] Abs(double[] array)
	{
		double[] array2 = new double[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = Abs(array[i]);
		}
		return array2;
	}

	public static double Clamp(double value, double calmpedValue, double tolerance)
	{
		if (!(tolerance <= Abs(value - calmpedValue)))
		{
			return calmpedValue;
		}
		return value;
	}

	public static double Clamp(double value, double calmpedValue)
	{
		if (!(8.881784197001252E-16 > Abs(value - calmpedValue)))
		{
			return value;
		}
		return calmpedValue;
	}

	public static float Clamp(float value, float calmpedValue, float tolerance)
	{
		if (!(tolerance > Abs(value - calmpedValue)))
		{
			return value;
		}
		return calmpedValue;
	}

	public static float Clamp(float value, float calmpedValue)
	{
		if (!(4.7683716E-07f <= Abs(value - calmpedValue)))
		{
			return calmpedValue;
		}
		return value;
	}

	public static double Sin(double value)
	{
		return System.Math.Sin(value);
	}

	public static float Sin(float value)
	{
		return (float)System.Math.Sin(value);
	}

	public static ComplexD Sin(ComplexD value)
	{
		return ComplexD.Sin(value);
	}

	public static double Cos(double value)
	{
		return System.Math.Cos(value);
	}

	public static float Cos(float value)
	{
		return (float)System.Math.Cos(value);
	}

	public static ComplexD Cos(ComplexD value)
	{
		return ComplexD.Cos(value);
	}

	public static double Tan(double value)
	{
		return System.Math.Tan(value);
	}

	public static float Tan(float value)
	{
		return (float)System.Math.Tan(value);
	}

	public static ComplexD Tan(ComplexD value)
	{
		return ComplexD.Tan(value);
	}

	public static double Cot(double value)
	{
		return 1.0 / System.Math.Tan(value);
	}

	public static float Cot(float value)
	{
		return (float)(1.0 / System.Math.Tan(value));
	}

	public static ComplexD Cot(ComplexD value)
	{
		return ComplexD.Cot(value);
	}

	public static double Sec(double value)
	{
		return 1.0 / System.Math.Cos(value);
	}

	public static float Sec(float value)
	{
		return (float)(1.0 / System.Math.Cos(value));
	}

	public static ComplexD Sec(ComplexD value)
	{
		return ComplexD.Sec(value);
	}

	public static double Csc(double value)
	{
		return 1.0 / System.Math.Sin(value);
	}

	public static float Csc(float value)
	{
		return (float)(1.0 / System.Math.Sin(value));
	}

	public static ComplexD Csc(ComplexD value)
	{
		return ComplexD.Csc(value);
	}

	public static double Asin(double value)
	{
		return System.Math.Asin(value);
	}

	public static ComplexD Asin(ComplexD value)
	{
		return ComplexD.Asin(value);
	}

	public static double Acos(double value)
	{
		return System.Math.Acos(value);
	}

	public static ComplexD Acos(ComplexD value)
	{
		return ComplexD.Acos(value);
	}

	public static double Atan(double value)
	{
		return System.Math.Atan(value);
	}

	public static ComplexD Atan(ComplexD value)
	{
		return ComplexD.Atan(value);
	}

	public static double Acot(double value)
	{
		return System.Math.Atan(1.0 / value);
	}

	public static ComplexD Acot(ComplexD value)
	{
		return ComplexD.Acot(value);
	}

	public static double Asec(double value)
	{
		return System.Math.Acos(1.0 / value);
	}

	public static ComplexD Asec(ComplexD value)
	{
		return ComplexD.Asec(value);
	}

	public static double Acsc(double value)
	{
		return System.Math.Asin(1.0 / value);
	}

	public static ComplexD Acsc(ComplexD value)
	{
		return ComplexD.Acsc(value);
	}

	public static double Sinh(double value)
	{
		return System.Math.Sinh(value);
	}

	public static ComplexD Sinh(ComplexD value)
	{
		return ComplexD.Sinh(value);
	}

	public static double Cosh(double value)
	{
		return System.Math.Cosh(value);
	}

	public static ComplexD Cosh(ComplexD value)
	{
		return ComplexD.Cosh(value);
	}

	public static double Tanh(double value)
	{
		return System.Math.Tanh(value);
	}

	public static ComplexD Tanh(ComplexD value)
	{
		return ComplexD.Tanh(value);
	}

	public static double Coth(double value)
	{
		return 1.0 / System.Math.Tanh(value);
	}

	public static ComplexD Coth(ComplexD value)
	{
		return ComplexD.Coth(value);
	}

	public static double Sech(double value)
	{
		return 1.0 / Cosh(value);
	}

	public static ComplexD Sech(ComplexD value)
	{
		return ComplexD.Sech(value);
	}

	public static double Csch(double value)
	{
		return 1.0 / Sinh(value);
	}

	public static ComplexD Csch(ComplexD value)
	{
		return ComplexD.Csch(value);
	}

	public static double Asinh(double value)
	{
		return System.Math.Log(value + System.Math.Sqrt(value * value + 1.0), System.Math.E);
	}

	public static ComplexD Asinh(ComplexD value)
	{
		return ComplexD.Asinh(value);
	}

	public static double Acosh(double value)
	{
		return System.Math.Log(value + System.Math.Sqrt(value - 1.0) * System.Math.Sqrt(value + 1.0), System.Math.E);
	}

	public static ComplexD Acosh(ComplexD value)
	{
		return ComplexD.Acosh(value);
	}

	public static double Atanh(double value)
	{
		return 0.5 * System.Math.Log((1.0 + value) / (1.0 - value), System.Math.E);
	}

	public static ComplexD Atanh(ComplexD value)
	{
		return ComplexD.Atanh(value);
	}

	public static double Acoth(double value)
	{
		return 0.5 * System.Math.Log((value + 1.0) / (value - 1.0), System.Math.E);
	}

	public static ComplexD Acoth(ComplexD value)
	{
		return ComplexD.Acoth(value);
	}

	public static double Asech(double value)
	{
		return Acosh(1.0 / value);
	}

	public static ComplexD Asech(ComplexD value)
	{
		return ComplexD.Asech(value);
	}

	public static double Acsch(double value)
	{
		return Asinh(1.0 / value);
	}

	public static ComplexD Acsch(ComplexD value)
	{
		return ComplexD.Acsch(value);
	}

	public static bool ApproxEquals(float a, float b)
	{
		return System.Math.Abs(a - b) <= 4.7683716E-07f;
	}

	public static bool ApproxEquals(float a, float b, float tolerance)
	{
		return System.Math.Abs(a - b) <= tolerance;
	}

	public static bool ApproxEquals(double a, double b)
	{
		return System.Math.Abs(a - b) <= 8.881784197001252E-16;
	}

	public static bool ApproxEquals(double a, double b, double tolerance)
	{
		return System.Math.Abs(a - b) <= tolerance;
	}

	public static void Swap<T>(ref T lhs, ref T rhs)
	{
		T val = lhs;
		lhs = rhs;
		rhs = val;
	}

	static MathFunctions()
	{
		Class72.smethod_20();
		DoubleSinFunction = Sin;
		DoubleCosFunction = Cos;
		DoubleTanFunction = Tan;
		DoubleCotFunction = Cot;
		DoubleSecFunction = Sec;
		DoubleCscFunction = Csc;
		unaryFunction_0 = Sin;
		unaryFunction_1 = Cos;
		unaryFunction_2 = Tan;
		unaryFunction_3 = Cot;
		unaryFunction_4 = Sec;
		unaryFunction_5 = Csc;
		DoubleAsinFunction = Asin;
		DoubleAcosFunction = Acos;
		DoubleAtanFunction = Atan;
		DoubleAcotFunction = Acot;
		DoubleAsecFunction = Asec;
		DoubleAcscFunction = Acsc;
		unaryFunction_6 = Asin;
		unaryFunction_7 = Acos;
		unaryFunction_8 = Atan;
		unaryFunction_9 = Acot;
		unaryFunction_10 = Asec;
		unaryFunction_11 = Acsc;
		DoubleSinhFunction = Sinh;
		DoubleCoshFunction = Cosh;
		DoubleTanhFunction = Tanh;
		DoubleCothFunction = Coth;
		DoubleSechFunction = Sech;
		DoubleCschFunction = Csch;
		unaryFunction_12 = Sinh;
		unaryFunction_13 = Cosh;
		unaryFunction_14 = Tanh;
		unaryFunction_15 = Coth;
		unaryFunction_16 = Sech;
		unaryFunction_17 = Csch;
		DoubleAsinhFunction = Asinh;
		DoubleAcoshFunction = Acosh;
		DoubleAtanhFunction = Atanh;
		DoubleAcothFunction = Acoth;
		DoubleAsechFunction = Asech;
		DoubleAcschFunction = Acsch;
		ComplexDAsinhFunction = Asinh;
		ComplexDAcoshFunction = Acosh;
		ComplexDAtanhFunction = Atanh;
		ComplexDAcothFunction = Acoth;
		ComplexDAsechFunction = Asech;
		ComplexDAcschFunction = Acsch;
		FloatAbsFunction = System.Math.Abs;
		DoubleAbsFunction = System.Math.Abs;
		IntAbsFunction = System.Math.Abs;
		DoubleSqrtFunction = System.Math.Sqrt;
	}
}
