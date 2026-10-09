using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Sgp4Sdp4
{
	public static void sgp4(double tsince, ref SxPxConstants.vector pos, ref SxPxConstants.vector vel, SxPxConstants.sgp_data satdata)
	{
		SxPxConstants.vector vector = default(SxPxConstants.vector);
		vector.v = new double[4];
		SxPxConstants.vector vector2 = default(SxPxConstants.vector);
		vector2.v = new double[4];
		SxPxConstants.vector vector3 = default(SxPxConstants.vector);
		vector3.v = new double[4];
		SxPxConstants.vector vector4 = default(SxPxConstants.vector);
		vector4.v = new double[4];
		double eo = satdata.eo;
		double xno = satdata.xno;
		double xincl = satdata.xincl;
		double bstar = satdata.bstar;
		double xmo = satdata.xmo;
		double omegao = satdata.omegao;
		double xnodeo = satdata.xnodeo;
		double num = 1.0122292801892716;
		double num2 = Math.Sqrt(0.005530438215158448);
		double x = num2 / xno;
		double num3 = Math.Pow(x, 2.0 / 3.0);
		double num4 = Math.Cos(xincl);
		double num5 = Math.Sin(xincl);
		Math.Sin(omegao);
		double num6 = Math.Cos(omegao);
		double num7 = Math.Sin(xmo);
		double num8 = Math.Cos(xmo);
		double num9 = num4 * num4;
		double num10 = num9 * num9;
		double num11 = 3.0 * num9 - 1.0;
		double num12 = 1.0 - num9;
		double num13 = 1.0 - 5.0 * num9;
		double num14 = 7.0 * num9 - 1.0;
		double num15 = eo * eo;
		double num16 = 1.0 - num15;
		double num17 = Math.Sqrt(num16);
		double num18 = num3 * num3;
		double num19 = num17 * num16;
		double num20 = 0.00081196185 * num11 / (num18 * num19);
		double num21 = num3 * (1.0 - num20 * (1.0 / 3.0 + num20 * (1.0 + 1.654320987654321 * num20)));
		double num22 = num21 * num21;
		double num23 = 0.00081196185 * num11 / (num22 * num19);
		double num24 = xno / (1.0 + num23);
		double num25 = num21 / (1.0 - num23);
		int num26 = 0;
		if (num25 * (1.0 - eo) / 1.0 < 1.034492841559484)
		{
			num26 = 1;
		}
		double num27 = num;
		double num28 = 1.8802791590153552E-09;
		double num29 = (num25 * (1.0 - eo) - 1.0) * 6378.135;
		if (num29 < 156.0)
		{
			num27 = num29 - 78.0;
			if (num29 <= 98.0)
			{
				num27 = 20.0;
			}
			double num30 = (120.0 - num27) * 1.0 / 6378.135;
			num28 = num30 * num30 * num30 * num30;
			num27 = num27 / 6378.135 + 1.0;
		}
		double num31 = num25 * num25;
		double num32 = num16 * num16;
		double num33 = 1.0 / (num31 * num32);
		double num34 = 1.0 / (num25 - num27);
		double num35 = num25 * eo * num34;
		double num36 = num35 * num35;
		double num37 = eo * num35;
		double num38 = Math.Abs(1.0 - num36);
		double num39 = num34 * num34 * num34 * num34;
		double num40 = num28 * num39;
		double num41 = num38 * num38 * num38 * Math.Sqrt(num38);
		double num42 = num40 / num41;
		double num43 = num42 * num24 * (num25 * (1.0 + 1.5 * num36 + num37 * (4.0 + num36)) + 0.000405980925 * num34 / num38 * num11 * (8.0 + 3.0 * num36 * (8.0 + num36)));
		double num44 = bstar * num43;
		double num45 = 0.004690140306468833;
		double num46 = num40 * num34 * num45 * num24 * 1.0 * num5 / eo;
		double num47 = 2.0 * num24 * num42 * num25 * num16 * (num35 * (2.0 + 0.5 * num36) + eo * (0.5 + 2.0 * num36) - 0.0010826158 * num34 / (num25 * num38) * (-3.0 * num11 * (1.0 - 2.0 * num37 + num36 * (1.5 - 0.5 * num37)) + 0.75 * num12 * (2.0 * num36 - num37 * (1.0 + num36)) * Math.Cos(2.0 * omegao)));
		double num48 = 2.0 * num42 * num25 * num16 * (1.0 + 2.75 * (num36 + num37) + num37 * num36);
		double num49 = 0.0016239237 * num33 * num24;
		x = num49 * 0.0005413079 * num33;
		double num50 = 7.762359374999998E-07 * num33 * num33 * num24;
		double num51 = num24 + 0.5 * num49 * num17 * num11 + 0.0625 * x * num17 * (13.0 - 78.0 * num9 + 137.0 * num10);
		double num52 = -0.5 * num49 * num13 + 0.0625 * x * (7.0 - 114.0 * num9 + 395.0 * num10) + num50 * (3.0 - 36.0 * num9 + 49.0 * num10);
		double num53 = (0.0 - num49) * num4;
		double num54 = num53 + (0.5 * x * (4.0 - 19.0 * num9) + 2.0 * num50 * (3.0 - 7.0 * num9)) * num4;
		double num55 = bstar * num46 * num6;
		double num56 = -2.0 / 3.0 * num40 * bstar * 1.0 / num37;
		double num57 = 3.5 * num16 * num53 * num44;
		double num58 = 1.5 * num44;
		double num59 = 0.0005862675383086041 * num5 * (3.0 + 5.0 * num4) / (1.0 + num4);
		double num60 = 0.0011725350766172082 * num5;
		double num61 = (1.0 + num35 * num8) * (1.0 + num35 * num8) * (1.0 + num35 * num8);
		double num62 = num7;
		double num63 = 0.0;
		double num64 = 0.0;
		double num65 = 0.0;
		double num66 = 0.0;
		double num67 = 0.0;
		double num68 = 0.0;
		double num69 = 0.0;
		if (num26 == 0)
		{
			num63 = num44 * num44;
			num64 = 4.0 * num25 * num34 * num63;
			double num70 = num64 * num34 * num44 / 3.0;
			num65 = (17.0 * num25 + num27) * num70;
			num66 = 0.5 * num70 * num25 * num34 * (221.0 * num25 + 31.0 * num27) * num44;
			num67 = num64 + 2.0 * num63;
			num68 = 0.25 * (3.0 * num65 + num44 * (12.0 * num64 + 10.0 * num63));
			num69 = 0.2 * (3.0 * num66 + 12.0 * num44 * num65 + 6.0 * num64 * num64 + 15.0 * num63 * (2.0 * num64 + num63));
		}
		double num71 = xmo + num51 * tsince;
		double num72 = omegao + num52 * tsince;
		double num73 = xnodeo + num54 * tsince;
		double num74 = num72;
		double num75 = num71;
		double num76 = tsince * tsince;
		double num77 = num73 + num57 * num76;
		double num78 = 1.0 - num44 * tsince;
		double num79 = bstar * num47 * tsince;
		double num80 = num58 * num76;
		if (num26 == 0)
		{
			double num81 = num55 * tsince;
			double num82 = num56 * ((1.0 + num35 * Math.Cos(num71)) * (1.0 + num35 * Math.Cos(num71)) * (1.0 + num35 * Math.Cos(num71)) - num61);
			double num83 = num81 + num82;
			num75 = num71 + num83;
			num74 = num72 - num83;
			double num84 = num76 * tsince;
			double num85 = tsince * num84;
			num78 = num78 - num64 * num76 - num65 * num84 - num66 * num85;
			num79 += bstar * num48 * (Math.Sin(num75) - num62);
			num80 = num80 + num67 * num84 + num85 * (num68 + tsince * num69);
		}
		double num86 = num25 * num78 * num78;
		double num87 = eo - num79;
		double num88 = num75 + num74 + num77 + num24 * num80;
		double num89 = Math.Sqrt(1.0 - num87 * num87);
		double num90 = num2 / (num86 * Math.Sqrt(num86));
		double num91 = Math.Sin(num74);
		double num92 = Math.Cos(num74);
		double num93 = num87 * num92;
		double num94 = 1.0 / (num86 * num89 * num89);
		double num95 = num94 * num59 * num93;
		double num96 = num94 * num60;
		double num97 = num88 + num95;
		double num98 = num87 * num91 + num96;
		double x2 = num97 - num77;
		double num99 = SxPxMath.fmod2p(ref x2);
		x = num99;
		int num100 = 1;
		double num101;
		double num102;
		double num103;
		double num104;
		double num105;
		double num106;
		double num107;
		do
		{
			num101 = Math.Sin(x);
			num102 = Math.Cos(x);
			num50 = num93 * num101;
			num103 = num98 * num102;
			num104 = num93 * num102;
			num105 = num98 * num101;
			num106 = (num99 - num103 + num50 - x) / (1.0 - num104 - num105) + x;
			num107 = x;
			x = num106;
			num100++;
		}
		while ((num100 <= 10) & (Math.Abs(num106 - num107) > 1E-06));
		double num108 = num104 + num105;
		double num109 = num50 - num103;
		double num110 = num93 * num93 + num98 * num98;
		num94 = 1.0 - num110;
		double num111 = num86 * num94;
		double num112 = num86 * (1.0 - num108);
		num49 = 1.0 / num112;
		double num113 = num2 * Math.Sqrt(num86) * num109 * num49;
		double num114 = num2 * Math.Sqrt(num111) * num49;
		x = num86 * num49;
		double num115 = Math.Sqrt(num94);
		num50 = 1.0 / (1.0 + num115);
		double cosx = x * (num102 - num93 + num98 * num109 * num50);
		double sinx = x * (num101 - num98 - num93 * num109 * num50);
		double num116 = SxPxMath.actan(ref sinx, ref cosx);
		double num117 = 2.0 * sinx * cosx;
		double num118 = 2.0 * cosx * cosx - 1.0;
		num94 = 1.0 / num111;
		num49 = 0.0005413079 * num94;
		x = num49 * num94;
		double num119 = num112 * (1.0 - 1.5 * x * num115 * num11) + 0.5 * num49 * num12 * num118;
		double num120 = num116 - 0.25 * x * num14 * num117;
		double num121 = num77 + 1.5 * x * num4 * num117;
		double num122 = xincl + 1.5 * x * num4 * num5 * num118;
		double num123 = num113 - num90 * num49 * num12 * num117;
		double num124 = num114 + num90 * num49 * (num12 * num118 + 1.5 * num11);
		double num125 = Math.Sin(num121);
		double num126 = Math.Cos(num121);
		double num127 = Math.Sin(num122);
		double num128 = Math.Cos(num122);
		double num129 = Math.Sin(num120);
		double num130 = Math.Cos(num120);
		vector.v[0] = (0.0 - num125) * num128;
		vector.v[1] = num126 * num128;
		vector.v[2] = num127;
		vector2.v[0] = num126;
		vector2.v[1] = num125;
		vector2.v[2] = 0.0;
		num100 = 0;
		do
		{
			vector3.v[num100] = vector.v[num100] * num129 + vector2.v[num100] * num130;
			vector4.v[num100] = vector.v[num100] * num130 - vector2.v[num100] * num129;
			num100++;
		}
		while (num100 <= 2);
		num100 = 0;
		do
		{
			pos.v[num100] = num119 * vector3.v[num100];
			vel.v[num100] = num123 * vector3.v[num100] + num124 * vector4.v[num100];
			num100++;
		}
		while (num100 <= 2);
	}

	public static void sdp4(ref double tsince, ref SxPxConstants.vector pos, ref SxPxConstants.vector vel, ref SxPxConstants.sgp_data satdata)
	{
		SxPxConstants.vector vector = default(SxPxConstants.vector);
		vector.v = new double[4];
		SxPxConstants.vector vector2 = default(SxPxConstants.vector);
		vector2.v = new double[4];
		SxPxConstants.vector vector3 = default(SxPxConstants.vector);
		vector3.v = new double[4];
		SxPxConstants.vector vector4 = default(SxPxConstants.vector);
		vector4.v = new double[4];
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
		double num36 = 0.0;
		double num37 = 0.0;
		double num38 = 0.0;
		double num39 = 0.0;
		double num40 = 0.0;
		double num41 = 0.0;
		double num42 = 0.0;
		double num43 = 0.0;
		double emm = 0.0;
		double xincc = 0.0;
		double num44 = 0.0;
		double num45 = 0.0;
		num45 = 1.0122292801892716;
		num44 = Math.Sqrt(1434962880.0 / SxPxMath.cube(6378.135));
		double num46 = SxPxMath.sqr(SxPxMath.sqr(0.006584997024992489));
		num29 = num44 / satdata.xno;
		num = Math.Pow(num29, 2.0 / 3.0);
		num13 = Math.Cos(satdata.xincl);
		num31 = SxPxMath.sqr(num13);
		num36 = 3.0 * num31 - 1.0;
		num17 = SxPxMath.sqr(satdata.eo);
		num7 = 1.0 - num17;
		num6 = Math.Sqrt(num7);
		num14 = 0.00081196185 * num36 / (SxPxMath.sqr(num) * num6 * num7);
		num3 = num * (1.0 - num14 * (1.0 / 3.0 + num14 * (1.0 + 1.654320987654321 * num14)));
		num15 = 0.00081196185 * num36 / (SxPxMath.sqr(num3) * num6 * num7);
		num43 = satdata.xno / (1.0 + num15);
		num4 = num3 / (1.0 - num15);
		num25 = num45;
		num24 = num46;
		num21 = (num4 * (1.0 - satdata.eo) - 1.0) * 6378.135;
		if (num21 < 156.0)
		{
			num25 = num21 - 78.0;
			if (num21 <= 98.0)
			{
				num25 = 20.0;
			}
			num24 = Math.Pow((120.0 - num25) * 1.0 / 6378.135, 4.0);
			num25 = num25 / 6378.135 + 1.0;
		}
		num22 = 1.0 / (SxPxMath.sqr(num4) * SxPxMath.sqr(num7));
		num26 = Math.Sin(satdata.omegao);
		num12 = Math.Cos(satdata.omegao);
		num33 = 1.0 / (num4 - num25);
		num18 = num4 * satdata.eo * num33;
		num19 = SxPxMath.sqr(num18);
		num16 = satdata.eo * num18;
		num23 = Math.Abs(1.0 - num19);
		num11 = num24 * Math.Pow(num33, 4.0) / Math.Pow(num23, 3.5);
		num9 = num11 * num43 * (num4 * (1.0 + 1.5 * num19 + num16 * (4.0 + num19)) + 0.000405980925 * num33 / num23 * num36 * (8.0 + 3.0 * num19 * (8.0 + num19)));
		num8 = satdata.bstar * num9;
		num27 = Math.Sin(satdata.xincl);
		num2 = 0.004690140306468833 * Math.Pow(1.0, 3.0);
		num35 = 1.0 - num31;
		num10 = 2.0 * num43 * num11 * num4 * num7 * (num18 * (2.0 + 0.5 * num19) + satdata.eo * (0.5 + 2.0 * num19) - 0.0010826158 * num33 / (num4 * num23) * (-3.0 * num36 * (1.0 - 2.0 * num16 + num19 * (1.5 - 0.5 * num16)) + 0.75 * num35 * (2.0 * num19 - num16 * (1.0 + num19)) * Math.Cos(2.0 * satdata.omegao)));
		num32 = SxPxMath.sqr(num31);
		num28 = 0.0016239237 * num22 * num43;
		num29 = num28 * 0.0005413079 * num22;
		num30 = 7.762359374999998E-07 * num22 * num22 * num43;
		num40 = num43 + 0.5 * num28 * num6 * num36 + 0.0625 * num29 * num6 * (13.0 - 78.0 * num31 + 137.0 * num32);
		num34 = 1.0 - 5.0 * num31;
		num20 = -0.5 * num28 * num34 + 0.0625 * num29 * (7.0 - 114.0 * num31 + 395.0 * num32) + num30 * (3.0 - 36.0 * num31 + 49.0 * num32);
		num38 = (0.0 - num28) * num13;
		num42 = num38 + (0.5 * num29 * (4.0 - 19.0 * num31) + 2.0 * num30 * (3.0 - 7.0 * num31)) * num13;
		num41 = 3.5 * num7 * num38 * num8;
		double num47 = 1.5 * num8;
		num39 = 0.125 * num2 * num27 * (3.0 + 5.0 * num13) / (1.0 + num13);
		num5 = 0.25 * num2 * num27;
		num37 = 7.0 * num31 - 1.0;
		SxPxConstants.val_deep_init values = default(SxPxConstants.val_deep_init);
		values.eosq = num17;
		values.sinio = num27;
		values.cosio = num13;
		values.betao = num6;
		values.aodp = num4;
		values.theta2 = num31;
		values.sing = num26;
		values.cosg = num12;
		values.betao2 = num7;
		values.xmdot = num40;
		values.omgdot = num20;
		values.xnodott = num42;
		values.xnodpp = num43;
		Sgp_Deep.call_dpinit(ref values, ref satdata);
		num17 = values.eosq;
		num27 = values.sinio;
		num13 = values.cosio;
		num6 = values.betao;
		num4 = values.aodp;
		num31 = values.theta2;
		num26 = values.sing;
		num12 = values.cosg;
		num7 = values.betao2;
		num40 = values.xmdot;
		num20 = values.omgdot;
		num42 = values.xnodott;
		num43 = values.xnodpp;
		double xmdf = satdata.xmo + num40 * tsince;
		double omgadf = satdata.omegao + num20 * tsince;
		double num48 = satdata.xnodeo + num42 * tsince;
		double num49 = SxPxMath.sqr(tsince);
		double xnode = num48 + num41 * num49;
		double x = 1.0 - num8 * tsince;
		double num50 = satdata.bstar * num10 * tsince;
		double num51 = num47 * num49;
		double xnn = num43;
		SxPxConstants.val_deep_sec values2 = default(SxPxConstants.val_deep_sec);
		values2.xmdf = xmdf;
		values2.omgadf = omgadf;
		values2.xnode = xnode;
		values2.emm = emm;
		values2.xincc = xincc;
		values2.xnn = xnn;
		values2.tsince = tsince;
		Sgp_Deep.call_dpsec(ref values2, ref satdata);
		xmdf = values2.xmdf;
		omgadf = values2.omgadf;
		xnode = values2.xnode;
		emm = values2.emm;
		xincc = values2.xincc;
		xnn = values2.xnn;
		tsince = values2.tsince;
		double num52 = Math.Pow(num44 / xnn, 2.0 / 3.0) * SxPxMath.sqr(x);
		double e = emm - num50;
		double xmam = xmdf + num43 * num51;
		SxPxConstants.val_deep_per values3 = default(SxPxConstants.val_deep_per);
		values3.e = e;
		values3.xincc = xincc;
		values3.omgadf = omgadf;
		values3.xnode = xnode;
		values3.xmam = xmam;
		Sgp_Deep.call_dpper(ref values3, ref satdata);
		e = values3.e;
		xincc = values3.xincc;
		omgadf = values3.omgadf;
		xnode = values3.xnode;
		xmam = values3.xmam;
		double num53 = xmam + omgadf + xnode;
		double x2 = Math.Sqrt(1.0 - SxPxMath.sqr(e));
		xnn = num44 / Math.Pow(num52, 1.5);
		double num54 = e * Math.Cos(omgadf);
		double num55 = 1.0 / (num52 * SxPxMath.sqr(x2));
		double num56 = num55 * num39 * num54;
		double num57 = num55 * num5;
		double num58 = num53 + num56;
		double num59 = e * Math.Sin(omgadf) + num57;
		double x3 = num58 - xnode;
		double num60 = SxPxMath.fmod2p(ref x3);
		num29 = num60;
		int num61 = 1;
		double num62;
		double num63;
		double num64;
		double num65;
		double num66;
		double num67;
		double num68;
		do
		{
			num62 = Math.Sin(num29);
			num63 = Math.Cos(num29);
			num30 = num54 * num62;
			num64 = num59 * num63;
			num65 = num54 * num63;
			num66 = num59 * num62;
			num67 = (num60 - num64 + num30 - num29) / (1.0 - num65 - num66) + num29;
			num68 = num29;
			num29 = num67;
			num61++;
		}
		while ((num61 <= 10) & (Math.Abs(num67 - num68) > 1E-06));
		double num69 = num65 + num66;
		double num70 = num30 - num64;
		double num71 = SxPxMath.sqr(num54) + SxPxMath.sqr(num59);
		num55 = 1.0 - num71;
		double num72 = num52 * num55;
		double num73 = num52 * (1.0 - num69);
		num28 = 1.0 / num73;
		double num74 = num44 * Math.Sqrt(num52) * num70 * num28;
		double num75 = num44 * Math.Sqrt(num72) * num28;
		num29 = num52 * num28;
		double num76 = Math.Sqrt(num55);
		num30 = 1.0 / (1.0 + num76);
		double cosx = num29 * (num63 - num54 + num59 * num70 * num30);
		double sinx = num29 * (num62 - num59 - num54 * num70 * num30);
		double num77 = SxPxMath.actan(ref sinx, ref cosx);
		double num78 = 2.0 * sinx * cosx;
		double num79 = 2.0 * SxPxMath.sqr(cosx) - 1.0;
		num55 = 1.0 / num72;
		num28 = 0.0005413079 * num55;
		num29 = num28 * num55;
		double num80 = num73 * (1.0 - 1.5 * num29 * num76 * num36) + 0.5 * num28 * num35 * num79;
		double num81 = num77 - 0.25 * num29 * num37 * num78;
		double num82 = xnode + 1.5 * num29 * num13 * num78;
		double num83 = xincc + 1.5 * num29 * num13 * num27 * num79;
		double num84 = num74 - xnn * num28 * num35 * num78;
		double num85 = num75 + xnn * num28 * (num35 * num79 + 1.5 * num36);
		vector.v[0] = (0.0 - Math.Sin(num82)) * Math.Cos(num83);
		vector.v[1] = Math.Cos(num82) * Math.Cos(num83);
		vector.v[2] = Math.Sin(num83);
		vector2.v[0] = Math.Cos(num82);
		vector2.v[1] = Math.Sin(num82);
		vector2.v[2] = 0.0;
		for (num61 = 0; num61 < 3; num61++)
		{
			vector3.v[num61] = vector.v[num61] * Math.Sin(num81) + vector2.v[num61] * Math.Cos(num81);
			vector4.v[num61] = vector.v[num61] * Math.Cos(num81) - vector2.v[num61] * Math.Sin(num81);
		}
		for (num61 = 0; num61 < 3; num61++)
		{
			pos.v[num61] = num80 * vector3.v[num61];
			vel.v[num61] = num84 * vector3.v[num61] + num85 * vector4.v[num61];
		}
	}

	public static void sgp4call(double time, ref SxPxConstants.vector pos, ref SxPxConstants.vector vel, SxPxConstants.sgp_data satdata)
	{
		double tsince = (time - satdata.julian_epoch) * 1440.0;
		if (satdata.ideep != 0)
		{
			sdp4(ref tsince, ref pos, ref vel, ref satdata);
		}
		else
		{
			sgp4(tsince, ref pos, ref vel, satdata);
		}
	}

	static Sgp4Sdp4()
	{
		Class72.smethod_20();
	}
}
