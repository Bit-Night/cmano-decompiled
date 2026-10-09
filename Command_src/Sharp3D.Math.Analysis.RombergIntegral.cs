using System;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Analysis;

public sealed class RombergIntegral : IFloatIntegrator, IDoubleIntegrator, ICloneable
{
	private int int_0 = 5;

	private double[,] double_0;

	private float[,] float_0;

	public int Order
	{
		get
		{
			return int_0;
		}
		set
		{
			if (int_0 != value)
			{
				int_0 = value;
				float_0 = null;
				double_0 = null;
			}
		}
	}

	public RombergIntegral()
	{
	}

	public RombergIntegral(int order)
	{
		int_0 = order;
	}

	public RombergIntegral(RombergIntegral r)
	{
		int_0 = r.Order;
	}

	public double Integrate(MathFunctions.UnaryFunction<double> f, double a, double b)
	{
		if (double_0 == null || double_0.GetLength(1) == int_0)
		{
			double_0 = new double[1, int_0];
		}
		if (a > b)
		{
			return Integrate(f, b, a);
		}
		double num = b - a;
		double_0[0, 0] = 0.5 * num * (f(a) + f(b));
		int num2 = 2;
		int num3 = 1;
		while (num2 <= int_0)
		{
			double num4 = 0.0;
			for (int i = 1; i <= num3; i++)
			{
				num4 += f(a + num * ((double)i - 0.5));
			}
			double_0[1, 0] = 0.5 * (double_0[0, 0] + num * num4);
			int num5 = 1;
			int num6 = 4;
			while (num5 < num2)
			{
				double_0[1, num5] = ((double)num6 * double_0[1, num5 - 1] - double_0[0, num5 - 1]) / (double)(num6 - 1);
				num5++;
				num6 *= 4;
			}
			for (int j = 0; j < num2; j++)
			{
				double_0[0, j] = double_0[1, j];
			}
			num2++;
			num3 *= 2;
			num /= 2.0;
		}
		return double_0[0, int_0 - 1];
	}

	public float Integrate(MathFunctions.UnaryFunction<float> f, float a, float b)
	{
		if (float_0 == null || float_0.GetLength(1) == int_0)
		{
			float_0 = new float[1, int_0];
		}
		if (a > b)
		{
			return Integrate(f, b, a);
		}
		float num = b - a;
		float_0[0, 0] = 0.5f * num * (f(a) + f(b));
		int num2 = 2;
		int num3 = 1;
		while (num2 <= int_0)
		{
			float num4 = 0f;
			for (int i = 1; i <= num3; i++)
			{
				num4 += f(a + num * ((float)i - 0.5f));
			}
			float_0[1, 0] = 0.5f * (float_0[0, 0] + num * num4);
			int num5 = 1;
			int num6 = 4;
			while (num5 < num2)
			{
				float_0[1, num5] = ((float)num6 * float_0[1, num5 - 1] - float_0[0, num5 - 1]) / (float)(num6 - 1);
				num5++;
				num6 *= 4;
			}
			for (int j = 0; j < num2; j++)
			{
				float_0[0, j] = float_0[1, j];
			}
			num2++;
			num3 *= 2;
			num /= 2f;
		}
		return float_0[0, int_0 - 1];
	}

	object ICloneable.Clone()
	{
		return new RombergIntegral(this);
	}

	public RombergIntegral Clone()
	{
		return new RombergIntegral(this);
	}

	static RombergIntegral()
	{
		Class72.smethod_20();
	}
}
