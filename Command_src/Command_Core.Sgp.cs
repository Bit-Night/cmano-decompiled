using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Sgp
{
	public static void sgp0(double tsince, ref SxPxConstants.vector pos, ref SxPxConstants.vector vel, SxPxConstants.sgp_data satdata)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		double num11 = 0.0;
		double num12 = 0.0;
		double num13 = 0.0;
		double num14 = 0.0;
		double num15 = 0.0;
		double num16 = 0.0;
		double num17 = 0.0;
		double num18 = 0.0;
		double num19 = 0.0;
		double num20 = 0.0;
		double num21 = 0.0;
		double num22 = 0.0;
		double num23 = 0.0;
		double num24 = 0.0;
		double num25 = 0.0;
		double num26 = 0.0;
		double num27 = 0.0;
		double num28 = 0.0;
		double num29 = 0.0;
		double num30 = 0.0;
		double num31 = 0.0;
		double num32 = 0.0;
		double num33 = 0.0;
		double num34 = 0.0;
		double num35 = 0.0;
		SxPxConstants.vector vector = default(SxPxConstants.vector);
		vector.v = new double[4];
		SxPxConstants.vector vector2 = default(SxPxConstants.vector);
		vector2.v = new double[4];
		SxPxConstants.vector vector3 = default(SxPxConstants.vector);
		vector3.v = new double[4];
		SxPxConstants.vector vector4 = default(SxPxConstants.vector);
		vector4.v = new double[4];
		pos.v = new double[4];
		vel.v = new double[4];
		num35 = Math.Sqrt(1434962880.0 / SxPxMath.cube(6378.135));
		num19 = num35 / satdata.xno;
		num = Math.Pow(num19, 2.0 / 3.0);
		num2 = Math.Cos(satdata.xincl);
		num3 = Math.Sin(satdata.xincl);
		num4 = 0.00081196185 * (3.0 * SxPxMath.sqr(num2) - 1.0) / (SxPxMath.sqr(num) * Math.Pow(1.0 - SxPxMath.sqr(satdata.eo), 1.5));
		double num36 = num * (1.0 - 1.0 / 3.0 * num4 - SxPxMath.sqr(num4) - 1.654320987654321 * SxPxMath.sqr(num4) * num4);
		num5 = num36 * (1.0 - SxPxMath.sqr(satdata.eo));
		num6 = num36 * (1.0 - satdata.eo);
		num7 = satdata.xmo + satdata.omegao + satdata.xnodeo;
		num8 = -0.0016239237 * (satdata.xno * num2) / SxPxMath.sqr(num5);
		num9 = 0.00081196185 * (satdata.xno * (5.0 * SxPxMath.sqr(num2) - 1.0)) / SxPxMath.sqr(num5);
		num10 = satdata.xno + 2.0 * satdata.xndt2o * tsince + 3.0 * satdata.xndd6o * SxPxMath.sqr(tsince);
		num10 = satdata.xno / num10;
		num11 = num36 * Math.Pow(num10, 2.0 / 3.0);
		num12 = ((!(num11 > num6)) ? 1E-06 : (1.0 - num6 / num11));
		num13 = num11 * (1.0 - SxPxMath.sqr(num12));
		num14 = satdata.xnodeo + num8 * tsince;
		num15 = satdata.omegao + num9 * tsince;
		double num37 = num7 + (satdata.xno + num9 + num8) * tsince + satdata.xndt2o * SxPxMath.sqr(tsince) + satdata.xndd6o * SxPxMath.sqr(tsince) * tsince;
		num16 = num12 * Math.Sin(num15) - -2.53881E-06 * num3 / (0.0021652316 * num13);
		num17 = num12 * Math.Cos(num15);
		num19 = -2.53881E-06 * num17 * num3 * (3.0 + 5.0 * num2);
		num20 = 0.0043304632 * num13 * (1.0 + num2);
		num10 = num37 - num19 / num20;
		double x = SxPxMath.fmod2p(ref num10) - num14;
		num18 = SxPxMath.fmod2p(ref x);
		num10 = num18;
		int num38 = 1;
		do
		{
			num19 = num18 - num16 * Math.Cos(num10) + num17 * Math.Sin(num10) - num10;
			num20 = 1.0 - num16 * Math.Sin(num10) - num17 * Math.Cos(num10);
			num21 = num19 / num20 + num10;
			num19 = num10;
			num10 = num21;
			num38++;
		}
		while ((num38 <= 10) & (Math.Abs(num21 - num19) > 1E-06));
		num22 = num17 * Math.Cos(num21) + num16 * Math.Sin(num21);
		num23 = num17 * Math.Sin(num21) - num16 * Math.Cos(num21);
		num24 = SxPxMath.sqr(num17) + SxPxMath.sqr(num16);
		num25 = num11 * (1.0 - num24);
		num26 = num11 * (1.0 - num22);
		num27 = num35 * Math.Sqrt(num11) * num23 / num26;
		num28 = num35 * Math.Sqrt(num25) / num26;
		num29 = num11 / num26 * (Math.Sin(num21) - num16 - num17 * num23 / (1.0 + Math.Sqrt(1.0 - num24)));
		num30 = num11 / num26 * (Math.Cos(num21) - num17 + num16 * num23 / (1.0 + Math.Sqrt(1.0 - num24)));
		num18 = SxPxMath.actan(ref num29, ref num30);
		num32 = num26 + 0.00027065395 * (SxPxMath.sqr(num3) / num25) * Math.Cos(2.0 * num18);
		num33 = num18 - 0.000135326975 * (Math.Sin(2.0 * num18) * (7.0 * SxPxMath.sqr(num2) - 1.0)) / SxPxMath.sqr(num25);
		num34 = num14 + 0.00081196185 * (num2 * Math.Sin(2.0 * num18)) / SxPxMath.sqr(num25);
		num31 = satdata.xincl + 0.00081196185 * (num3 * num2 * Math.Cos(2.0 * num18)) / SxPxMath.sqr(num25);
		vector.v[0] = (0.0 - Math.Sin(num34)) * Math.Cos(num31);
		vector.v[1] = Math.Cos(num34) * Math.Cos(num31);
		vector.v[2] = Math.Sin(num31);
		vector2.v[0] = Math.Cos(num34);
		vector2.v[1] = Math.Sin(num34);
		vector2.v[2] = 0.0;
		for (num38 = 0; num38 < 3; num38++)
		{
			vector3.v[num38] = vector.v[num38] * Math.Sin(num33) + vector2.v[num38] * Math.Cos(num33);
			vector4.v[num38] = vector.v[num38] * Math.Cos(num33) - vector2.v[num38] * Math.Sin(num33);
		}
		for (num38 = 0; num38 < 3; num38++)
		{
			pos.v[num38] = num32 * vector3.v[num38];
			vel.v[num38] = num27 * vector3.v[num38] + num28 * vector4.v[num38];
		}
	}

	public static void sgp0call(double time, ref SxPxConstants.vector pos, ref SxPxConstants.vector vel, SxPxConstants.sgp_data satdata)
	{
		sgp0((time - satdata.julian_epoch) * 1440.0, ref pos, ref vel, satdata);
	}

	static Sgp()
	{
		Class72.smethod_20();
	}
}
