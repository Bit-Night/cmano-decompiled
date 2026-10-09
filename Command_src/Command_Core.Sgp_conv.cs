using System;

namespace Command_Core;

public sealed class Sgp_conv
{
	public static double double_value(char[] c1, int pos, int len)
	{
		double num = 0.0;
		int i = 0;
		int num2 = 0;
		for (; i < len; i++)
		{
			switch (c1[i + pos])
			{
			case '.':
				num2 = len - i - 1;
				break;
			case '0':
				num *= 10.0;
				break;
			case '1':
				num *= 10.0;
				num += 1.0;
				break;
			case '2':
				num *= 10.0;
				num += 2.0;
				break;
			case '3':
				num *= 10.0;
				num += 3.0;
				break;
			case '4':
				num *= 10.0;
				num += 4.0;
				break;
			case '5':
				num *= 10.0;
				num += 5.0;
				break;
			case '6':
				num *= 10.0;
				num += 6.0;
				break;
			case '7':
				num *= 10.0;
				num += 7.0;
				break;
			case '8':
				num *= 10.0;
				num += 8.0;
				break;
			case '9':
				num *= 10.0;
				num += 9.0;
				break;
			}
		}
		return num / Math.Pow(10.0, num2);
	}

	public static int integer_value(char[] c1, int pos, int len)
	{
		int num = 0;
		for (int i = 0; i < len; i++)
		{
			switch (c1[i + pos])
			{
			case '0':
				num *= 10;
				break;
			case '1':
				num *= 10;
				num++;
				break;
			case '2':
				num *= 10;
				num += 2;
				break;
			case '3':
				num *= 10;
				num += 3;
				break;
			case '4':
				num *= 10;
				num += 4;
				break;
			case '5':
				num *= 10;
				num += 5;
				break;
			case '6':
				num *= 10;
				num += 6;
				break;
			case '7':
				num *= 10;
				num += 7;
				break;
			case '8':
				num *= 10;
				num += 8;
				break;
			case '9':
				num *= 10;
				num += 9;
				break;
			}
		}
		return num;
	}

	public static void Convert_Satellite_Data(ref SxPxConstants.tle_ascii tle, ref SxPxConstants.sgp_data data)
	{
		data.ObjectName = tle.l[0];
		data.epoch = double_value(tle.l[1].ToCharArray(), 18, 14);
		data.julian_epoch = SxPxTime.Julian_Date_of_Epoch(ref data.epoch);
		data.xndt2o = double_value(tle.l[1].ToCharArray(), 33, 10);
		data.xndd6o = double_value(tle.l[1].ToCharArray(), 44, 6) * 1E-05;
		int num = integer_value(tle.l[1].ToCharArray(), 50, 2);
		data.bstar = double_value(tle.l[1].ToCharArray(), 53, 6) * 1E-05;
		int num2 = integer_value(tle.l[1].ToCharArray(), 59, 2);
		Array.Copy(tle.l[1].ToCharArray(), 65, data.elset, 0, 3);
		data.xincl = double_value(tle.l[2].ToCharArray(), 8, 8);
		data.xnodeo = double_value(tle.l[2].ToCharArray(), 17, 8);
		data.eo = double_value(tle.l[2].ToCharArray(), 26, 7) * 1E-07;
		data.omegao = double_value(tle.l[2].ToCharArray(), 34, 8);
		data.xmo = double_value(tle.l[2].ToCharArray(), 43, 8);
		data.xno = double_value(tle.l[2].ToCharArray(), 52, 11);
		data.catnr = tle.l[2].ToString().Substring(2, 5);
		data.revnum = integer_value(tle.l[2].ToCharArray(), 63, 5);
		data.xndd6o *= Math.Pow(10.0, -num);
		data.bstar = data.bstar * Math.Pow(10.0, -num2) / 1.0;
		data.xnodeo = SxPxMath.radians(ref data.xnodeo);
		data.omegao = SxPxMath.radians(ref data.omegao);
		data.xmo = SxPxMath.radians(ref data.xmo);
		data.xincl = SxPxMath.radians(ref data.xincl);
		data.xno = data.xno * 2.0 * 3.14159265358979 / 1440.0;
		data.xndt2o = data.xndt2o * 2.0 * 3.14159265358979 / SxPxMath.sqr(1440.0);
		data.xndd6o = data.xndd6o * 2.0 * 3.14159265358979 / SxPxMath.cube(1440.0);
		double num3 = Math.Pow(Math.Sqrt(1434962880.0 / SxPxMath.cube(6378.135)) / data.xno, 2.0 / 3.0);
		double num4 = 0.00081196185 * (3.0 * SxPxMath.sqr(Math.Cos(data.xincl)) - 1.0) / Math.Pow(1.0 - SxPxMath.sqr(data.eo), 1.5);
		double num5 = num4 / SxPxMath.sqr(num3);
		double x = num3 * (1.0 - num5 * (1.0 / 3.0 + num5 * (1.0 + 1.654320987654321 * num5)));
		double num6 = num4 / SxPxMath.sqr(x);
		double num7 = data.xno / (1.0 + num6);
		if (6.28318530717958 / num7 >= 225.0)
		{
			data.ideep = 1;
		}
		else
		{
			data.ideep = 0;
		}
	}

	public static void Convert_Sat_State(ref SxPxConstants.vector p, ref SxPxConstants.vector v)
	{
		for (int i = 0; i < 3; i++)
		{
			p.v[i] = p.v[i] * 6378.135;
			v.v[i] = v.v[i] * 6378.135 / 60.0;
		}
		SxPxMath.Magnitude(ref p);
		SxPxMath.Magnitude(ref v);
	}

	public static int sgp(int mode, double time, SxPxConstants.tle_ascii tle, SxPxConstants.vector pos, SxPxConstants.vector vel)
	{
		SxPxConstants.sgp_data data = new SxPxConstants.sgp_data();
		Convert_Satellite_Data(ref tle, ref data);
		switch (mode)
		{
		default:
			return -1;
		case 0:
			Sgp.sgp0call(time, ref pos, ref vel, data);
			break;
		case 1:
		case 2:
			Sgp4Sdp4.sgp4call(time, ref pos, ref vel, data);
			break;
		case 3:
		case 4:
			Sgp8Sdp8.sgp8call(ref time, ref pos, ref vel, ref data);
			break;
		}
		Convert_Sat_State(ref pos, ref vel);
		return 0;
	}

	static Sgp_conv()
	{
		Class72.smethod_20();
	}
}
