using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class FastTrig
{
	internal static double Sin_LowPrecision(double x)
	{
		if (x < -3.14159265)
		{
			x += 6.28318531;
		}
		else if (x > 3.14159265)
		{
			x -= 6.28318531;
		}
		if (x < 0.0)
		{
			return 1.27323954 * x + 0.405284735 * x * x;
		}
		return 1.27323954 * x - 0.405284735 * x * x;
	}

	internal static double Cos_LowPrecision(double x)
	{
		if (x < -3.14159265)
		{
			x += 6.28318531;
		}
		else if (x > 3.14159265)
		{
			x -= 6.28318531;
		}
		x += 1.57079632;
		if (x > 3.14159265)
		{
			x -= 6.28318531;
		}
		if (x < 0.0)
		{
			return 1.27323954 * x + 0.405284735 * x * x;
		}
		return 1.27323954 * x - 0.405284735 * x * x;
	}

	internal static double Sin_HighPrecision_Deg(double x)
	{
		return Sin_HighPrecision_Rad(x * 0.0174532925199433);
	}

	internal static double Cos_HighPrecision_Deg(double x)
	{
		return Cos_HighPrecision_Rad(x * 0.0174532925199433);
	}

	internal static double Sin_HighPrecision_Rad(double x)
	{
		if (x < -3.14159265)
		{
			x += 6.28318531;
		}
		else if (x > 3.14159265)
		{
			x -= 6.28318531;
		}
		double num;
		if (x < 0.0)
		{
			num = 1.27323954 * x + 0.405284735 * x * x;
			if (num < 0.0)
			{
				return 0.225 * (num * (0.0 - num) - num) + num;
			}
			return 0.225 * (num * num - num) + num;
		}
		num = 1.27323954 * x - 0.405284735 * x * x;
		if (num < 0.0)
		{
			return 0.225 * (num * (0.0 - num) - num) + num;
		}
		return 0.225 * (num * num - num) + num;
	}

	internal static double Cos_HighPrecision_Rad(double x)
	{
		if (x < -3.14159265)
		{
			x += 6.28318531;
		}
		else if (x > 3.14159265)
		{
			x -= 6.28318531;
		}
		x += 1.57079632;
		if (x > 3.14159265)
		{
			x -= 6.28318531;
		}
		double num;
		if (x < 0.0)
		{
			num = 1.27323954 * x + 0.405284735 * x * x;
			if (num < 0.0)
			{
				return 0.225 * (num * (0.0 - num) - num) + num;
			}
			return 0.225 * (num * num - num) + num;
		}
		num = 1.27323954 * x - 0.405284735 * x * x;
		if (num < 0.0)
		{
			return 0.225 * (num * (0.0 - num) - num) + num;
		}
		return 0.225 * (num * num - num) + num;
	}

	internal static double Sin_parabola(double x)
	{
		return 0.0 - (1.2732394933700562 * x + -0.40528473258018494 * x * ((x < 0.0) ? (0.0 - x) : x));
	}

	static FastTrig()
	{
		Class72.smethod_20();
	}
}
