using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools.Pro;

internal class NoradSDP4 : NoradBase
{
	internal sealed class SecularIntegrator
	{
		private readonly double double_0;

		private readonly double double_1;

		private readonly double double_2;

		private readonly double double_3;

		private readonly double double_4;

		private readonly double double_5;

		private readonly double double_6;

		private readonly double double_7;

		private readonly double double_8;

		private readonly double double_9;

		private readonly double cyseOifSjry;

		private readonly double double_10;

		private readonly double double_11;

		private readonly double double_12;

		private readonly double double_13;

		private readonly double double_14;

		[CompilerGenerated]
		private Dictionary<int, ResultSums> dictionary_0;

		private object object_0 = new object();

		private readonly bool bool_0;

		private readonly double double_15;

		private readonly double siteOhlIiCf;

		private Dictionary<int, ResultSums> Cache
		{
			[CompilerGenerated]
			get
			{
				return dictionary_0;
			}
			[CompilerGenerated]
			set
			{
				dictionary_0 = value;
			}
		}

		private SecularIntegrator(double xfact, double xlamo, double mm)
		{
			double_13 = xfact;
			double_15 = xlamo;
			siteOhlIiCf = mm;
		}

		public SecularIntegrator(double xfact, double xlamo, double mm, double del1, double del2, double del3)
			: this(xfact, xlamo, mm)
		{
			double_0 = del1;
			double_1 = del2;
			double_2 = del3;
			bool_0 = true;
			method_0();
		}

		public SecularIntegrator(double xfact, double xlamo, double mm, double d2201, double d2211, double d3210, double d3222, double d4410, double d4422, double d5220, double d5232, double d5421, double d5433, double omegaq, double omgdot)
			: this(xfact, xlamo, mm)
		{
			double_3 = d2201;
			double_4 = d2211;
			double_5 = d3210;
			double_6 = d3222;
			double_7 = d4410;
			double_8 = d4422;
			double_9 = d5220;
			cyseOifSjry = d5232;
			double_10 = d5421;
			double_11 = d5433;
			double_12 = omegaq;
			double_14 = omgdot;
			method_0();
		}

		private void method_0()
		{
			lock (object_0)
			{
				Cache = new Dictionary<int, ResultSums>();
				double double_ = 0.0;
				double double_2 = 0.0;
				double double_3 = 0.0;
				method_1(double_15, siteOhlIiCf, 0.0, ref double_, ref double_2, ref double_3);
				Cache[0] = new ResultSums(double_15, siteOhlIiCf, double_, double_2, double_3);
			}
		}

		private void method_1(double double_16, double double_17, double double_18, ref double double_19, ref double double_20, ref double double_21)
		{
			if (!bool_0)
			{
				double num = double_12 + double_14 * double_18;
				double num2 = num + num;
				double num3 = double_16 + double_16;
				double_19 = double_3 * Math.Sin(num2 + double_16 - 5.7686396) + double_4 * Math.Sin(double_16 - 5.7686396) + double_5 * Math.Sin(num + double_16 - 0.95240898) + double_6 * Math.Sin(0.0 - num + double_16 - 0.95240898) + double_7 * Math.Sin(num2 + num3 - 1.8014998) + double_8 * Math.Sin(num3 - 1.8014998) + double_9 * Math.Sin(num + double_16 - 1.050833) + cyseOifSjry * Math.Sin(0.0 - num + double_16 - 1.050833) + double_10 * Math.Sin(num + num3 - 4.4108898) + double_11 * Math.Sin(0.0 - num + num3 - 4.4108898);
				double_20 = double_3 * Math.Cos(num2 + double_16 - 5.7686396) + double_4 * Math.Cos(double_16 - 5.7686396) + double_5 * Math.Cos(num + double_16 - 0.95240898) + double_6 * Math.Cos(0.0 - num + double_16 - 0.95240898) + double_9 * Math.Cos(num + double_16 - 1.050833) + cyseOifSjry * Math.Cos(0.0 - num + double_16 - 1.050833) + 2.0 * (double_7 * Math.Cos(num2 + num3 - 1.8014998) + double_8 * Math.Cos(num3 - 1.8014998) + double_10 * Math.Cos(num + num3 - 4.4108898) + double_11 * Math.Cos(0.0 - num + num3 - 4.4108898));
			}
			else
			{
				double_19 = double_0 * Math.Sin(double_16 - 0.13130908) + double_1 * Math.Sin(2.0 * (double_16 - 2.8843198)) + double_2 * Math.Sin(3.0 * (double_16 - 0.37448087));
				double_20 = double_0 * Math.Cos(double_16 - 0.13130908) + 2.0 * double_1 * Math.Cos(2.0 * (double_16 - 2.8843198)) + 3.0 * double_2 * Math.Cos(3.0 * (double_16 - 0.37448087));
			}
			double_21 = double_17 + double_13;
			double_20 *= double_21;
		}

		public void Integrate(ref double xl, ref double xn, double tsince)
		{
			double num = 0.0;
			double num2 = 0.0;
			double double_ = 0.0;
			double double_2 = 0.0;
			double double_3 = 0.0;
			double num3 = 0.0;
			int num4 = (int)(tsince / 720.0);
			lock (object_0)
			{
				if (!Cache.ContainsKey(num4))
				{
					int num5 = (((double)num4 >= 0.0) ? 1 : (-1));
					int num6 = num4 - num5;
					while (!Cache.ContainsKey(num6))
					{
						num6 -= num5;
					}
					ResultSums resultSums = Cache[num6];
					num = resultSums.m_xli;
					num2 = resultSums.m_xni;
					double_ = resultSums.m_xndot;
					double_3 = resultSums.m_xldot;
					double_2 = resultSums.m_xnddt;
					double num7 = 720.0 * (double)num5;
					num3 = num7 * (double)Math.Abs(num6);
					for (int i = num6 + num5; Math.Abs(i) <= Math.Abs(num4); i += num5)
					{
						num = num + double_3 * num7 + double_ * 259200.0;
						num2 = num2 + double_ * num7 + double_2 * 259200.0;
						num3 += num7;
						method_1(num, num2, num3, ref double_, ref double_2, ref double_3);
						Cache[i] = new ResultSums(num, num2, double_, double_2, double_3);
					}
				}
				else
				{
					ResultSums resultSums2 = Cache[num4];
					num = resultSums2.m_xli;
					num2 = resultSums2.m_xni;
					double_ = resultSums2.m_xndot;
					double_3 = resultSums2.m_xldot;
					double_2 = resultSums2.m_xnddt;
					num3 = (double)num4 * 720.0;
				}
			}
			double num8 = tsince - num3;
			double num9 = num8 * num8 / 2.0;
			xn = num2 + double_ * num8 + double_2 * num9;
			xl = num + double_3 * num8 + double_ * num9;
		}

		static SecularIntegrator()
		{
			Class72.smethod_20();
		}
	}

	internal class ResultSums
	{
		public double m_xli;

		public double m_xni;

		public double m_xndot;

		public double m_xnddt;

		public double m_xldot;

		public ResultSums(double xli, double xni, double xndot, double xnddt, double xldot)
		{
			m_xli = xli;
			m_xni = xni;
			m_xndot = xndot;
			m_xnddt = xnddt;
			m_xldot = xldot;
		}

		static ResultSums()
		{
			Class72.smethod_20();
		}
	}

	private readonly double double_0;

	private readonly double double_1;

	private readonly double double_2;

	private readonly double double_3;

	private readonly double double_4;

	private readonly double double_5;

	private readonly double double_6;

	private readonly double double_7;

	private readonly double double_8;

	private readonly double GfxeigccXjl;

	private readonly double double_9;

	private readonly double double_10;

	private readonly double double_11;

	private readonly double sgIeiQyjpNS;

	private readonly double double_12;

	private readonly double double_13;

	private readonly double double_14;

	private readonly double double_15;

	private readonly double double_16;

	private readonly double double_17;

	private readonly double double_18;

	private readonly double double_19;

	private readonly double double_20;

	private readonly double double_21;

	private readonly double double_22;

	private readonly double double_23;

	private readonly double double_24;

	private readonly double double_25;

	private readonly double double_26;

	private readonly double jPxeifAgFjD;

	private readonly double XcjeibRikqY;

	private readonly double double_27;

	private readonly double double_28;

	private readonly double double_29;

	private readonly double double_30;

	private readonly bool bool_0;

	private readonly bool bool_1;

	private readonly SecularIntegrator secularIntegrator_0;

	public NoradSDP4(IOrbit orbit)
		: base(orbit)
	{
		double num = Math.Sin(base.Orbit.Elements.ArgPerigeeRad);
		double num2 = Math.Cos(base.Orbit.Elements.ArgPerigeeRad);
		bool_0 = false;
		bool_1 = false;
		Julian epoch = base.Orbit.Elements.Epoch;
		double_28 = epoch.ToGmst();
		double eccentricity = base.Orbit.Elements.Eccentricity;
		double num3 = 1.0 / base.Orbit.SemiMajorRec;
		double meanAnomalyRad = base.Orbit.Elements.MeanAnomalyRad;
		double num4 = m_omgdot + m_xnodot;
		double num5 = Math.Sin(base.Orbit.Elements.RAANodeRad);
		double num6 = Math.Cos(base.Orbit.Elements.RAANodeRad);
		double_24 = base.Orbit.Elements.ArgPerigeeRad;
		double num7 = epoch.FromJan0_12h_1900();
		double num8 = 4.523602 - 0.00092422029 * num7;
		double num9 = Math.Sin(num8);
		double num10 = Math.Cos(num8);
		double num11 = 0.91375164 - 0.03568096 * num10;
		double num12 = Math.Sqrt(1.0 - num11 * num11);
		double num13 = 0.089683511 * num9 / num12;
		double num14 = Math.Sqrt(1.0 - num13 * num13);
		double num15 = 4.7199672 + 0.2299715 * num7;
		double num16 = 5.8351514 + 0.001944368 * num7;
		double_22 = (num15 - num16) % (Math.PI * 2.0);
		double y = 0.39785416 * num9 / num12;
		double x = num14 * num10 + 0.91744867 * num13 * num9;
		double num17 = Math.Atan2(y, x) + num16 - num8;
		double num18 = Math.Cos(num17);
		double num19 = Math.Sin(num17);
		double_23 = 6.2565837 + 0.017201977 * num7;
		double_23 %= Math.PI * 2.0;
		double num20 = 0.1945905;
		double num21 = -0.98088458;
		double num22 = 0.91744867;
		double num23 = 0.39785416;
		double num24 = num6;
		double num25 = num5;
		double num26 = 2.9864797E-06;
		double num27 = 1.19459E-05;
		double num28 = 0.01675;
		double num29 = 1.0 / base.Orbit.MeanMotionRec;
		double num30 = 0.0;
		double num31 = 0.0;
		double num32 = 0.0;
		double num33 = 0.0;
		double num34 = 0.0;
		double num35 = Globals.Sqr(base.Orbit.Elements.Eccentricity);
		for (int i = 1; i <= 2; i++)
		{
			double num36 = num20 * num24 + num21 * num22 * num25;
			double num37 = (0.0 - num21) * num24 + num20 * num22 * num25;
			double num38 = (0.0 - num20) * num25 + num21 * num22 * num24;
			double num39 = num21 * num23;
			double num40 = num21 * num25 + num20 * num22 * num24;
			double num41 = num20 * num23;
			double num42 = m_cosio * num38 + m_sinio * num39;
			double num43 = m_cosio * num40 + m_sinio * num41;
			double num44 = (0.0 - m_sinio) * num38 + m_cosio * num39;
			double num45 = (0.0 - m_sinio) * num40 + m_cosio * num41;
			double num46 = num36 * num2 + num42 * num;
			double num47 = num37 * num2 + num43 * num;
			double num48 = (0.0 - num36) * num + num42 * num2;
			double num49 = (0.0 - num37) * num + num43 * num2;
			double num50 = num44 * num;
			double num51 = num45 * num;
			double num52 = num44 * num2;
			double num53 = num45 * num2;
			double num54 = 12.0 * num46 * num46 - 3.0 * num48 * num48;
			double num55 = 24.0 * num46 * num47 - 6.0 * num48 * num49;
			double num56 = 12.0 * num47 * num47 - 3.0 * num49 * num49;
			double num57 = 3.0 * (num36 * num36 + num42 * num42) + num54 * num35;
			double num58 = 6.0 * (num36 * num37 + num42 * num43) + num55 * num35;
			double num59 = 3.0 * (num37 * num37 + num43 * num43) + num56 * num35;
			double num60 = -6.0 * num36 * num44 + num35 * (-24.0 * num46 * num52 - 6.0 * num48 * num50);
			double num61 = -6.0 * (num36 * num45 + num37 * num44) + num35 * (-24.0 * (num47 * num52 + num46 * num53) - 6.0 * (num48 * num51 + num49 * num50));
			double num62 = -6.0 * num37 * num45 + num35 * (-24.0 * num47 * num53 - 6.0 * num49 * num51);
			double num63 = 6.0 * num42 * num44 + num35 * (24.0 * num46 * num50 - 6.0 * num48 * num52);
			double num64 = 6.0 * (num43 * num44 + num42 * num45) + num35 * (24.0 * (num47 * num50 + num46 * num51) - 6.0 * (num49 * num52 + num48 * num53));
			double num65 = 6.0 * num43 * num45 + num35 * (24.0 * num47 * num51 - 6.0 * num49 * num53);
			num57 = num57 + num57 + m_betao2 * num54;
			num58 = num58 + num58 + m_betao2 * num55;
			num59 = num59 + num59 + m_betao2 * num56;
			double num66 = num26 * num29;
			double num67 = -0.5 * num66 / m_betao;
			double num68 = num66 * m_betao;
			double num69 = -15.0 * eccentricity * num68;
			double num70 = num46 * num48 + num47 * num49;
			double num71 = num47 * num48 + num46 * num49;
			double num72 = num47 * num49 - num46 * num48;
			num30 = num69 * num27 * num70;
			num31 = num67 * num27 * (num60 + num62);
			num32 = (0.0 - num27) * num66 * (num57 + num59 - 14.0 - 6.0 * num35);
			num33 = num68 * num27 * (num54 + num56 - 6.0);
			num34 = ((!(base.Orbit.Elements.InclinationRad < 0.052359877)) ? ((0.0 - num27) * num67 * (num63 + num65)) : 0.0);
			double_1 = 2.0 * num69 * num71;
			double_0 = 2.0 * num69 * num72;
			double_17 = 2.0 * num67 * num61;
			double_18 = 2.0 * num67 * (num62 - num60);
			double_19 = -2.0 * num66 * num58;
			double_20 = -2.0 * num66 * (num59 - num57);
			double_21 = -2.0 * num66 * (-21.0 - 9.0 * num35) * num28;
			double_12 = 2.0 * num68 * num55;
			double_13 = 2.0 * num68 * (num56 - num54);
			double_14 = -18.0 * num68 * num28;
			double_15 = -2.0 * num67 * num64;
			double_16 = -2.0 * num67 * (num65 - num63);
			if (i == 1)
			{
				double_25 = num30;
				XcjeibRikqY = num31;
				double_27 = num32;
				jPxeifAgFjD = ((num34 == 0.0) ? 0.0 : (num34 / m_sinio));
				double_26 = num33 - m_cosio * jPxeifAgFjD;
				double_2 = double_1;
				GfxeigccXjl = double_17;
				double_10 = double_19;
				double_4 = double_12;
				double_7 = double_15;
				double_3 = double_0;
				double_9 = double_18;
				double_11 = double_20;
				double_5 = double_13;
				double_8 = double_16;
				sgIeiQyjpNS = double_21;
				double_6 = double_14;
				num20 = num18;
				num21 = num19;
				num22 = num11;
				num23 = num12;
				num24 = num14 * num6 + num13 * num5;
				num25 = num5 * num14 - num6 * num13;
				num27 = 0.00015835218;
				num26 = 4.7968065E-07;
				num28 = 0.0549;
			}
		}
		double_25 += num30;
		XcjeibRikqY += num31;
		double_27 += num32;
		double_26 = double_26 + num33 - ((num34 == 0.0) ? 0.0 : (m_cosio / m_sinio * num34));
		jPxeifAgFjD += ((num34 == 0.0) ? 0.0 : (num34 / m_sinio));
		bool_0 = false;
		bool_1 = false;
		if (base.Orbit.MeanMotionRec > 0.0034906585 && base.Orbit.MeanMotionRec < 0.0052359877)
		{
			bool_0 = true;
			bool_1 = true;
			double num73 = 1.0 + num35 * (-2.5 + 0.8125 * num35);
			double num74 = 1.0 + 2.0 * num35;
			double num75 = 1.0 + num35 * (-6.0 + 6.60937 * num35);
			double num76 = 0.75 * (1.0 + m_cosio) * (1.0 + m_cosio);
			double num77 = 0.9375 * m_sinio * m_sinio * (1.0 + 3.0 * m_cosio) - 0.75 * (1.0 + m_cosio);
			double num78 = 1.0 + m_cosio;
			num78 = 1.875 * num78 * num78 * num78;
			double num79 = 3.0 * Globals.Sqr(base.Orbit.MeanMotionRec) * num3 * num3;
			double del = 2.0 * num79 * num76 * num73 * 1.7891679E-06;
			double del2 = 3.0 * num79 * num78 * num75 * 2.2123015E-07 * num3;
			num79 = num79 * num77 * num74 * 2.1460748E-06 * num3;
			double_30 = (meanAnomalyRad + base.Orbit.Elements.RAANodeRad + base.Orbit.Elements.ArgPerigeeRad - double_28) % (Math.PI * 2.0);
			double num80 = m_xmdot + num4 - 0.0043752690880113;
			num80 = num80 + double_27 + double_26 + jPxeifAgFjD;
			double_29 = num80 - base.Orbit.MeanMotionRec;
			secularIntegrator_0 = new SecularIntegrator(double_29, double_30, base.Orbit.MeanMotionRec, num79, del, del2);
		}
		else if (base.Orbit.MeanMotionRec >= 0.00826 && base.Orbit.MeanMotionRec <= 0.00924 && eccentricity >= 0.5)
		{
			bool_0 = true;
			double num81 = eccentricity * num35;
			double num82 = -0.306 - (eccentricity - 0.64) * 0.44;
			double num83;
			double num74;
			double num84;
			double num85;
			double num86;
			double num87;
			if (eccentricity <= 0.65)
			{
				num83 = 3.616 - 13.247 * eccentricity + 16.29 * num35;
				num74 = -19.302 + 117.39 * eccentricity - 228.419 * num35 + 156.591 * num81;
				num84 = -18.9068 + 109.7927 * eccentricity - 214.6334 * num35 + 146.5816 * num81;
				num85 = -41.122 + 242.694 * eccentricity - 471.094 * num35 + 313.953 * num81;
				num86 = -146.407 + 841.88 * eccentricity - 1629.014 * num35 + 1083.435 * num81;
				num87 = -532.114 + 3017.977 * eccentricity - 5740.032 * num35 + 3708.276 * num81;
			}
			else
			{
				num83 = -72.099 + 331.819 * eccentricity - 508.738 * num35 + 266.724 * num81;
				num74 = -346.844 + 1582.851 * eccentricity - 2415.925 * num35 + 1246.113 * num81;
				num84 = -342.585 + 1554.908 * eccentricity - 2366.899 * num35 + 1215.972 * num81;
				num85 = -1052.797 + 4758.686 * eccentricity - 7193.992 * num35 + 3651.957 * num81;
				num86 = -3581.69 + 16178.11 * eccentricity - 24462.77 * num35 + 12422.52 * num81;
				num87 = ((!(eccentricity <= 0.715)) ? (-5149.66 + 29936.92 * eccentricity - 54087.36 * num35 + 31324.56 * num81) : (1464.74 - 4664.75 * eccentricity + 3763.64 * num35));
			}
			double num88;
			double num89;
			double num90;
			if (eccentricity < 0.7)
			{
				num88 = -919.2277 + 4988.61 * eccentricity - 9064.77 * num35 + 5542.21 * num81;
				num89 = -822.71072 + 4568.6173 * eccentricity - 8491.4146 * num35 + 5337.524 * num81;
				num90 = -853.666 + 4690.25 * eccentricity - 8624.77 * num35 + 5341.4 * num81;
			}
			else
			{
				num88 = -37995.78 + 161616.52 * eccentricity - 229838.2 * num35 + 109377.94 * num81;
				num89 = -51752.104 + 218913.95 * eccentricity - 309468.16 * num35 + 146349.42 * num81;
				num90 = -40023.88 + 170470.89 * eccentricity - 242699.48 * num35 + 115605.82 * num81;
			}
			double num91 = m_sinio * m_sinio;
			double num92 = m_cosio * m_cosio;
			double num76 = 0.75 * (1.0 + 2.0 * m_cosio + num92);
			double num93 = 1.5 * num91;
			double num94 = 1.875 * m_sinio * (1.0 - 2.0 * m_cosio - 3.0 * num92);
			double num95 = -1.875 * m_sinio * (1.0 + 2.0 * m_cosio - 3.0 * num92);
			double num96 = 35.0 * num91 * num76;
			double num97 = 39.375 * num91 * num91;
			double num98 = 9.84375 * m_sinio * (num91 * (1.0 - 2.0 * m_cosio - 5.0 * num92) + 0.33333333 * (-2.0 + 4.0 * m_cosio + 6.0 * num92));
			double num99 = m_sinio * (4.92187512 * num91 * (-2.0 - 4.0 * m_cosio + 10.0 * num92) + 6.56250012 * (1.0 + 2.0 * m_cosio - 3.0 * num92));
			double num100 = 29.53125 * m_sinio * (2.0 - 8.0 * m_cosio + num92 * (-12.0 + 8.0 * m_cosio + 10.0 * num92));
			double num101 = 29.53125 * m_sinio * (-2.0 - 8.0 * m_cosio + num92 * (12.0 + 8.0 * m_cosio - 10.0 * num92));
			double num102 = Globals.Sqr(base.Orbit.MeanMotionRec);
			double num103 = num3 * num3;
			double num104 = 3.0 * num102 * num103;
			double num105 = num104 * 1.7891679E-06;
			double d = num105 * num76 * num82;
			double d2 = num105 * num93 * num83;
			num104 *= num3;
			double num106 = num104 * 3.7393792E-07;
			double d3 = num106 * num94 * num74;
			double d4 = num106 * num95 * num84;
			num104 *= num3;
			double num107 = 2.0 * num104 * 7.3636953E-09;
			double d5 = num107 * num96 * num85;
			double d6 = num107 * num97 * num86;
			num104 *= num3;
			double num108 = num104 * 1.1428639E-07;
			double d7 = num108 * num98 * num87;
			double d8 = num108 * num99 * num90;
			double num109 = 2.0 * num104 * 2.1765803E-09;
			double d9 = num109 * num100 * num89;
			double d10 = num109 * num101 * num88;
			double_30 = meanAnomalyRad + base.Orbit.Elements.RAANodeRad + base.Orbit.Elements.RAANodeRad - double_28 - double_28;
			double num80 = m_xmdot + m_xnodot + m_xnodot - 0.0043752690880113 - 0.0043752690880113;
			num80 = num80 + double_27 + jPxeifAgFjD + jPxeifAgFjD;
			double_29 = num80 - base.Orbit.MeanMotionRec;
			secularIntegrator_0 = new SecularIntegrator(double_29, double_30, base.Orbit.MeanMotionRec, d, d2, d3, d4, d5, d6, d7, d8, d9, d10, double_24, m_omgdot);
		}
	}

	private void method_0(ref double double_31, ref double double_32, ref double double_33, ref double double_34, ref double double_35, ref double double_36, double double_37)
	{
		double_31 += double_27 * double_37;
		double_32 += double_26 * double_37;
		double_33 += jPxeifAgFjD * double_37;
		double_34 += double_25 * double_37;
		double_35 += XcjeibRikqY * double_37;
		if (bool_0)
		{
			double xl = 0.0;
			secularIntegrator_0.Integrate(ref xl, ref double_36, double_37);
			double num = 0.0 - double_33 + double_28 + double_37 * 0.0043752690880113;
			double_31 = xl - double_32 + num;
			if (!bool_1)
			{
				double_31 = xl + num + num;
			}
		}
	}

	private void method_1(ref double double_31, ref double double_32, ref double double_33, ref double double_34, ref double double_35, double double_36)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = double_23 + 1.19459E-05 * double_36;
		double num8 = num7 + 0.0335 * Math.Sin(num7);
		double num9 = Math.Sin(num8);
		double num10 = 0.5 * num9 * num9 - 0.25;
		double num11 = -0.5 * num9 * Math.Cos(num8);
		double num12 = double_2 * num10 + double_3 * num11;
		double num13 = GfxeigccXjl * num10 + double_9 * num11;
		double num14 = double_10 * num10 + double_11 * num11 + sgIeiQyjpNS * num9;
		num = double_4 * num10 + double_5 * num11 + double_6 * num9;
		double num15 = double_7 * num10 + double_8 * num11;
		num7 = double_22 + 0.00015835218 * double_36;
		num8 = num7 + 0.1098 * Math.Sin(num7);
		num9 = Math.Sin(num8);
		num10 = 0.5 * num9 * num9 - 0.25;
		num11 = -0.5 * num9 * Math.Cos(num8);
		double num16 = double_1 * num10 + double_0 * num11;
		double num17 = double_17 * num10 + double_18 * num11;
		double num18 = double_19 * num10 + double_20 * num11 + double_21 * num9;
		num6 = double_12 * num10 + double_13 * num11 + double_14 * num9;
		num2 = double_15 * num10 + double_16 * num11;
		num3 = num12 + num16;
		num4 = num13 + num17;
		num5 = num14 + num18;
		double num19 = num + num6;
		double num20 = num15 + num2;
		double_32 += num4;
		double_31 += num3;
		if (double_32 >= 0.2)
		{
			double num21 = Math.Sin(double_32);
			double num22 = Math.Cos(double_32);
			num20 /= num21;
			num19 -= num22 * num20;
			double_33 += num19;
			double_34 += num20;
			double_35 += num5;
			return;
		}
		double num23 = Math.Sin(double_32);
		double num24 = Math.Cos(double_32);
		double num25 = Math.Sin(double_34);
		double num26 = Math.Cos(double_34);
		double num27 = num23 * num25;
		double num28 = num23 * num26;
		double num29 = num20 * num26 + num4 * num24 * num25;
		double num30 = (0.0 - num20) * num25 + num4 * num24 * num26;
		num27 += num29;
		num28 += num30;
		double_34 %= Math.PI * 2.0;
		if (double_34 < 0.0)
		{
			double_34 += Math.PI * 2.0;
		}
		double num31 = double_35 + double_33 + num24 * double_34;
		double num32 = num5 + num19 - num4 * double_34 * num23;
		num31 += num32;
		double num33 = double_34;
		double_34 = Math.Atan2(num27, num28);
		if (double_34 < 0.0)
		{
			double_34 += Math.PI * 2.0;
		}
		if (Math.Abs(num33 - double_34) > Math.PI)
		{
			double_34 += Math.PI * 2.0 * ((double_34 < num33) ? 1.0 : (-1.0));
		}
		double_35 += num5;
		double_33 = num31 - double_35 - num24 * double_34;
	}

	public override EciTime GetPosition(double tsince)
	{
		OrbitalElements elements = base.Orbit.Elements;
		double double_ = elements.MeanAnomalyRad + m_xmdot * tsince;
		double double_2 = elements.ArgPerigeeRad + m_omgdot * tsince;
		double num = elements.RAANodeRad + m_xnodot * tsince;
		double num2 = tsince * tsince;
		double double_3 = num + m_xnodcf * num2;
		double double_4 = base.Orbit.MeanMotionRec;
		double double_5 = elements.Eccentricity;
		double double_6 = elements.InclinationRad;
		method_0(ref double_, ref double_2, ref double_3, ref double_5, ref double_6, ref double_4, tsince);
		double x = 1.0 - m_c1 * tsince;
		double a = Math.Pow(base.Orbit.WgsModel.Xke / double_4, 2.0 / 3.0) * Globals.Sqr(x);
		double double_7 = double_5 - elements.BStar * m_c4 * tsince;
		double num3 = double_ + base.Orbit.MeanMotionRec * (m_t2cof * num2);
		double_3 %= Math.PI * 2.0;
		double_2 %= Math.PI * 2.0;
		num3 %= Math.PI * 2.0;
		method_1(ref double_7, ref double_6, ref double_2, ref double_3, ref num3, tsince);
		double xl = num3 + double_2 + double_3;
		return FinalPosition(double_6, double_2, double_7, a, xl, double_3, tsince);
	}

	static NoradSDP4()
	{
		Class72.smethod_20();
	}
}
