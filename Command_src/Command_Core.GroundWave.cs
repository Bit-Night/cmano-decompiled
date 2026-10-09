using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class GroundWave
{
	internal static double BTLC(double H1, double H2, double F, int IP)
	{
		double num = 2.094395E-08 * F;
		double num2 = 1.0;
		double num3 = 2.0 * num * H1;
		if (IP != 2)
		{
			int num4 = 1;
			do
			{
				if (!(num3 >= 0.1))
				{
					double num5 = num3 * num3;
					num2 *= 2.0 - num5 * (0.1 + num5 * 0.003571429);
				}
				else
				{
					num2 *= 1.0 + 3.0 * (Math.Sin(num3) - num3 * Math.Cos(num3)) / num3 / num3 / num3;
				}
				num3 = 2.0 * num * H2;
				num4++;
			}
			while (num4 <= 2);
		}
		else
		{
			int num4 = 1;
			do
			{
				if (!(num3 >= 0.1))
				{
					double num5 = num3 * num3;
					num2 *= num5 * (0.2 - num5 * (0.001071429 + num5 * 0.0002645503));
				}
				else
				{
					num2 *= 1.0 + 1.5 * ((1.0 - num3 * num3) * Math.Sin(num3) - num3 * Math.Cos(num3)) / num3 / num3 / num3;
				}
				num3 = 2.0 * num * H2;
				num4++;
			}
			while (num4 <= 2);
		}
		double num6 = num * num * num2;
		if (num6 >= 1E-70)
		{
			return 169.542 + 10.0 * Math.Log10(num6);
		}
		return 1000.0;
	}

	public static void Main()
	{
		Console.WriteLine(BTLC(10.0, 10.0, 6000000.0, 1));
	}

	static GroundWave()
	{
		Class72.smethod_20();
	}
}
