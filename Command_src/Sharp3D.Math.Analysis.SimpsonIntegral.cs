using System;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Analysis;

public sealed class SimpsonIntegral : ICloneable, IFloatIntegrator, IDoubleIntegrator
{
	private int int_0 = 100;

	public int Steps => int_0;

	public SimpsonIntegral()
	{
	}

	public SimpsonIntegral(int steps)
	{
		int_0 = steps;
	}

	public SimpsonIntegral(SimpsonIntegral simpson)
	{
		int_0 = simpson.int_0;
	}

	object ICloneable.Clone()
	{
		return new SimpsonIntegral(this);
	}

	public SimpsonIntegral Clone()
	{
		return new SimpsonIntegral(this);
	}

	public float Integrate(MathFunctions.UnaryFunction<float> f, float a, float b)
	{
		if (a <= b)
		{
			float num = 0f;
			float num2 = (b - a) / (float)int_0;
			float num3 = num2 / 3f;
			for (int i = 0; i < int_0; i += 2)
			{
				num += (f(a + (float)i * num2) + 4f * f(a + (float)(i + 1) * num2) + f(a + (float)(i + 2) * num2)) * num3;
			}
			return num;
		}
		return 0f - Integrate(f, b, a);
	}

	public double Integrate(MathFunctions.UnaryFunction<double> f, double a, double b)
	{
		if (a > b)
		{
			return 0.0 - Integrate(f, b, a);
		}
		double num = 0.0;
		double num2 = (b - a) / (double)int_0;
		double num3 = num2 / 3.0;
		for (int i = 0; i < int_0; i += 2)
		{
			num += (f(a + (double)i * num2) + 4.0 * f(a + (double)(i + 1) * num2) + f(a + (double)(i + 2) * num2)) * num3;
		}
		return num;
	}

	static SimpsonIntegral()
	{
		Class72.smethod_20();
	}
}
