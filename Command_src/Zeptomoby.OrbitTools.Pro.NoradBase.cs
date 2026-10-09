using System;
using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools.Pro;

internal abstract class NoradBase
{
	protected readonly double m_cosio;

	protected readonly double m_sinio;

	protected readonly double m_betao2;

	protected readonly double m_betao;

	protected readonly double m_s4;

	protected readonly double m_qoms24;

	protected readonly double m_tsi;

	protected readonly double m_eta;

	protected readonly double m_eeta;

	protected readonly double m_coef;

	protected readonly double m_c1;

	protected readonly double m_c3;

	protected readonly double m_c4;

	protected readonly double m_a3ovk2;

	protected readonly double m_xmdot;

	protected readonly double m_omgdot;

	protected readonly double m_xnodot;

	protected readonly double m_xnodcf;

	protected readonly double m_coef1;

	protected readonly double m_t2cof;

	[CompilerGenerated]
	private IOrbit iorbit_0;

	protected IOrbit Orbit
	{
		[CompilerGenerated]
		get
		{
			return iorbit_0;
		}
		[CompilerGenerated]
		private set
		{
			iorbit_0 = value;
		}
	}

	public abstract EciTime GetPosition(double tsince);

	public NoradBase(IOrbit orbit)
	{
		Orbit = orbit;
		m_cosio = Math.Cos(Orbit.Elements.InclinationRad);
		double num = m_cosio * m_cosio;
		double num2 = 3.0 * num - 1.0;
		double num3 = Globals.Sqr(Orbit.Elements.Eccentricity);
		m_betao2 = 1.0 - num3;
		m_betao = Math.Sqrt(m_betao2);
		WgsModel wgsModel = Orbit.WgsModel;
		double num4 = (Orbit.SemiMajorRec * (1.0 - Orbit.Elements.Eccentricity) - 1.0) * wgsModel.Xkmper;
		double num5 = 1.0 + 120.0 / wgsModel.Xkmper;
		m_qoms24 = Math.Pow(num5 - (m_s4 = 1.0 + 78.0 / wgsModel.Xkmper), 4.0);
		if (num4 < 156.0)
		{
			m_s4 = num4 - 78.0;
			if (num4 <= 98.0)
			{
				m_s4 = 20.0;
			}
			m_qoms24 = Math.Pow((120.0 - m_s4) * 1.0 / wgsModel.Xkmper, 4.0);
			m_s4 = m_s4 / wgsModel.Xkmper + 1.0;
		}
		double num6 = 1.0 / (Globals.Sqr(Orbit.SemiMajorRec) * m_betao2 * m_betao2);
		m_tsi = 1.0 / (Orbit.SemiMajorRec - m_s4);
		m_eta = Orbit.SemiMajorRec * Orbit.Elements.Eccentricity * m_tsi;
		m_eeta = Orbit.Elements.Eccentricity * m_eta;
		double num7 = m_eta * m_eta;
		double num8 = Math.Abs(1.0 - num7);
		m_coef = m_qoms24 * Math.Pow(m_tsi, 4.0);
		m_coef1 = m_coef / Math.Pow(num8, 3.5);
		double num9 = m_coef1 * Orbit.MeanMotionRec * (Orbit.SemiMajorRec * (1.0 + 1.5 * num7 + m_eeta * (4.0 + num7)) + 0.75 * wgsModel.Ck2 * m_tsi / num8 * num2 * (8.0 + 3.0 * num7 * (8.0 + num7)));
		m_c1 = Orbit.Elements.BStar * num9;
		m_sinio = Math.Sin(Orbit.Elements.InclinationRad);
		m_a3ovk2 = (0.0 - wgsModel.J3) / wgsModel.Ck2 * Math.Pow(1.0, 3.0);
		if (Orbit.Elements.Eccentricity > 0.0001)
		{
			m_c3 = m_coef * m_tsi * m_a3ovk2 * Orbit.MeanMotionRec * 1.0 * m_sinio / Orbit.Elements.Eccentricity;
		}
		double num10 = 1.0 - num;
		m_c4 = 2.0 * Orbit.MeanMotionRec * m_coef1 * Orbit.SemiMajorRec * m_betao2 * (m_eta * (2.0 + 0.5 * num7) + Orbit.Elements.Eccentricity * (0.5 + 2.0 * num7) - 2.0 * wgsModel.Ck2 * m_tsi / (Orbit.SemiMajorRec * num8) * (-3.0 * num2 * (1.0 - 2.0 * m_eeta + num7 * (1.5 - 0.5 * m_eeta)) + 0.75 * num10 * (2.0 * num7 - m_eeta * (1.0 + num7)) * Math.Cos(2.0 * Orbit.Elements.ArgPerigeeRad)));
		double num11 = num * num;
		double num12 = 3.0 * wgsModel.Ck2 * num6 * Orbit.MeanMotionRec;
		double num13 = num12 * wgsModel.Ck2 * num6;
		double num14 = 1.25 * wgsModel.Ck4 * num6 * num6 * Orbit.MeanMotionRec;
		m_xmdot = Orbit.MeanMotionRec + 0.5 * num12 * m_betao * num2 + 0.0625 * num13 * m_betao * (13.0 - 78.0 * num + 137.0 * num11);
		double num15 = 1.0 - 5.0 * num;
		m_omgdot = -0.5 * num12 * num15 + 0.0625 * num13 * (7.0 - 114.0 * num + 395.0 * num11) + num14 * (3.0 - 36.0 * num + 49.0 * num11);
		double num16 = (0.0 - num12) * m_cosio;
		m_xnodot = num16 + (0.5 * num13 * (4.0 - 19.0 * num) + 2.0 * num14 * (3.0 - 7.0 * num)) * m_cosio;
		m_xnodcf = 3.5 * m_betao2 * num16 * m_c1;
		m_t2cof = 1.5 * m_c1;
	}

	protected EciTime FinalPosition(double incl, double omega, double e, double a, double xl, double xnode, double tsince)
	{
		if (e * e > 1.0)
		{
			throw new PropagationException("Error in elements data");
		}
		WgsModel wgsModel = Orbit.WgsModel;
		double num = wgsModel.Xke / Math.Pow(a, 1.5);
		double num2 = 1.0 - e * e;
		double num3 = e * Math.Cos(omega);
		double num4 = 1.0 / (a * num2);
		double num5 = Math.Sin(incl);
		double num6 = Math.Cos(incl);
		double num7 = 0.25 * m_a3ovk2 * num5;
		double num8 = 0.125 * m_a3ovk2 * num5 * (3.0 + 5.0 * num6);
		num8 = ((!(Math.Abs(1.0 + num6) > 1.5E-12)) ? (num8 / 1.5E-12) : (num8 / (1.0 + num6)));
		double num9 = num4 * num8 * num3;
		double num10 = num4 * num7;
		double num11 = xl + num9;
		double num12 = e * Math.Sin(omega) + num10;
		double num13 = (num11 - xnode) % (Math.PI * 2.0);
		double num14 = num13;
		double num15 = 0.0;
		double num16 = 0.0;
		double num17 = double.PositiveInfinity;
		int num18 = 0;
		while (!(Math.Abs(num17) <= 1E-12) && num18 < 10)
		{
			num15 = Math.Sin(num14);
			num16 = Math.Cos(num14);
			num17 = (num13 - num12 * num16 + num3 * num15 - num14) / (1.0 - num3 * num16 - num12 * num15);
			if (num18 == 0)
			{
				if (num17 > 0.0)
				{
					num17 = Math.Min(num17, e);
				}
				else if (num17 < 0.0)
				{
					num17 = Math.Max(num17, 0.0 - e);
				}
			}
			num14 += num17;
			num18++;
		}
		double num19 = num3 * num16 + num12 * num15;
		double num20 = num3 * num15 - num12 * num16;
		double num21 = num3 * num3 + num12 * num12;
		num4 = 1.0 - num21;
		double num22 = a * num4;
		double num23 = a * (1.0 - num19);
		double num24 = 1.0 / num23;
		double num25 = wgsModel.Xke * Math.Sqrt(a) * num20 * num24;
		double num26 = wgsModel.Xke * Math.Sqrt(num22) * num24;
		double num27 = a * num24;
		double num28 = Math.Sqrt(num4);
		double num29 = 1.0 / (1.0 + num28);
		double num30 = num27 * (num16 - num3 + num12 * num20 * num29);
		double num31 = num27 * (num15 - num12 - num3 * num20 * num29);
		double num32 = Globals.AcTan(num31, num30);
		double num33 = 2.0 * num30 * num31;
		double num34 = 1.0 - 2.0 * num31 * num31;
		num4 = 1.0 / num22;
		num24 = wgsModel.Ck2 * num4;
		num27 = num24 * num4;
		double num35 = num6 * num6;
		double num36 = 3.0 * num35 - 1.0;
		double num37 = 1.0 - num35;
		double num38 = 7.0 * num35 - 1.0;
		double num39 = num23 * (1.0 - 1.5 * num27 * num28 * num36) + 0.5 * num24 * num37 * num34;
		double num40 = num32 - 0.25 * num27 * num38 * num33;
		double num41 = xnode + 1.5 * num27 * num6 * num33;
		double num42 = incl + 1.5 * num27 * num6 * num5 * num34;
		double num43 = num25 - num * num24 * num37 * num33;
		double num44 = num26 + num * num24 * (num37 * num34 + 1.5 * num36);
		double num45 = Math.Sin(num40);
		double num46 = Math.Cos(num40);
		double num47 = Math.Sin(num42);
		double num48 = Math.Cos(num42);
		double num49 = Math.Sin(num41);
		double num50 = Math.Cos(num41);
		double num51 = (0.0 - num49) * num48;
		double num52 = num50 * num48;
		double num53 = num51 * num45 + num50 * num46;
		double num54 = num52 * num45 + num49 * num46;
		double num55 = num47 * num45;
		double num56 = num51 * num46 - num50 * num45;
		double num57 = num52 * num46 - num49 * num45;
		double num58 = num47 * num46;
		double x = num39 * num53;
		double y = num39 * num54;
		double z = num39 * num55;
		Vector vector = new Vector(x, y, z);
		Julian julian = new Julian(Orbit.Elements.Epoch);
		julian.AddMin(tsince);
		if (vector.Magnitude() * (wgsModel.Xkmper / 1.0) < wgsModel.Xkmper)
		{
			throw new DecayException(julian, Orbit.SatName);
		}
		double x2 = num43 * num53 + num44 * num56;
		double y2 = num43 * num54 + num44 * num57;
		double z2 = num43 * num55 + num44 * num58;
		Vector vel = new Vector(x2, y2, z2);
		return new EciTime(vector, vel, julian);
	}

	static NoradBase()
	{
		Class72.smethod_20();
	}
}
