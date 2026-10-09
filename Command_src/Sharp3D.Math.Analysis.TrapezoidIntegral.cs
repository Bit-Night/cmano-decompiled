using System;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Analysis;

public sealed class TrapezoidIntegral : ICloneable, IDoubleIntegrator
{
	public enum Method
	{
		Default,
		MidPoint
	}

	private double double_0;

	private int int_0;

	private Method m_method_0;

	public double Accuracy
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

	public int MaxIterations
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public Method IntegrationMethod
	{
		get
		{
			return this.m_method_0;
		}
		set
		{
			this.m_method_0 = value;
		}
	}

	public TrapezoidIntegral()
	{
		double_0 = 0.0001;
		int_0 = int.MaxValue;
		this.m_method_0 = Method.Default;
	}

	public TrapezoidIntegral(double accuracy, int maxIterations, Method method)
	{
		double_0 = accuracy;
		int_0 = maxIterations;
		this.m_method_0 = method;
	}

	public TrapezoidIntegral(TrapezoidIntegral integrator)
	{
		double_0 = integrator.double_0;
		int_0 = integrator.int_0;
		this.m_method_0 = integrator.m_method_0;
	}

	private double method_0(MathFunctions.UnaryFunction<double> unaryFunction_0, double double_1, double double_2, double double_3, int int_1)
	{
		double num = 0.0;
		double num2 = (double_2 - double_1) / (double)int_1;
		double num3 = double_1 + num2 / 2.0;
		int num4 = 0;
		while (num4 < int_1)
		{
			num += unaryFunction_0(num3);
			num4++;
			num3 += num2;
		}
		return (double_3 + num2 * num) / 2.0;
	}

	private double method_1(MathFunctions.UnaryFunction<double> unaryFunction_0, double double_1, double double_2, double double_3, int int_1)
	{
		double num = 0.0;
		double num2 = (double_2 - double_1) / (double)int_1;
		double num3 = num2 * 0.0;
		double num4 = double_1 + num2 / 6.0;
		int num5 = 0;
		while (num5 < int_1)
		{
			num += unaryFunction_0(num4) + unaryFunction_0(num4 + num3);
			num5++;
			num4 += num2;
		}
		return (double_3 + num2 * num) / 3.0;
	}

	object ICloneable.Clone()
	{
		return new TrapezoidIntegral(this);
	}

	public TrapezoidIntegral Clone()
	{
		return new TrapezoidIntegral(this);
	}

	public double Integrate(MathFunctions.UnaryFunction<double> f, double a, double b)
	{
		if (a == b)
		{
			return 0.0;
		}
		if (a > b)
		{
			return 0.0 - Integrate(f, b, a);
		}
		int num = 1;
		double num2 = (f(a) + f(b)) * (b - a) / 2.0;
		double num3 = 0.0;
		int num4 = 1;
		while (true)
		{
			Method method = this.m_method_0;
			if (method != Method.Default)
			{
				if (method == Method.MidPoint)
				{
					num3 = method_1(f, a, b, num2, num);
					num *= 3;
				}
			}
			else
			{
				num3 = method_0(f, a, b, num2, num);
				num *= 2;
			}
			if (!(System.Math.Abs(num3 - num2) > double_0))
			{
				break;
			}
			num2 = num3;
			num4++;
			if (num4 >= int_0)
			{
				throw new MathException("Max number of iterations reached.");
			}
		}
		return num3;
	}

	static TrapezoidIntegral()
	{
		Class72.smethod_20();
	}
}
