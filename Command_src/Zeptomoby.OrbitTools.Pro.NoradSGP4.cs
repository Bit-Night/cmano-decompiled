using System;

namespace Zeptomoby.OrbitTools.Pro;

internal class NoradSGP4 : NoradBase
{
	private readonly double double_0;

	private readonly double double_1;

	private readonly double double_2;

	private readonly double double_3;

	private readonly double double_4;

	public NoradSGP4(IOrbit orbit)
		: base(orbit)
	{
		double num = m_eta * m_eta;
		double_0 = 2.0 * m_coef1 * base.Orbit.SemiMajorRec * m_betao2 * (1.0 + 2.75 * (num + m_eeta) + m_eeta * num);
		double_1 = base.Orbit.Elements.BStar * m_c3 * Math.Cos(base.Orbit.Elements.ArgPerigeeRad);
		if (base.Orbit.Elements.Eccentricity > 0.0001)
		{
			double_2 = -2.0 / 3.0 * m_coef * base.Orbit.Elements.BStar * 1.0 / m_eeta;
		}
		double_3 = Math.Pow(1.0 + m_eta * Math.Cos(base.Orbit.Elements.MeanAnomalyRad), 3.0);
		double_4 = Math.Sin(base.Orbit.Elements.MeanAnomalyRad);
	}

	public override EciTime GetPosition(double tsince)
	{
		bool flag = false;
		if (base.Orbit.SemiMajorRec * (1.0 - base.Orbit.Elements.Eccentricity) / 1.0 < 220.0 / base.Orbit.WgsModel.Xkmper + 1.0)
		{
			flag = true;
		}
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		if (!flag)
		{
			double num7 = m_c1 * m_c1;
			num = 4.0 * base.Orbit.SemiMajorRec * m_tsi * num7;
			double num8 = num * m_tsi * m_c1 / 3.0;
			num2 = (17.0 * base.Orbit.SemiMajorRec + m_s4) * num8;
			num3 = 0.5 * num8 * base.Orbit.SemiMajorRec * m_tsi * (221.0 * base.Orbit.SemiMajorRec + 31.0 * m_s4) * m_c1;
			num4 = num + 2.0 * num7;
			num5 = 0.25 * (3.0 * num2 + m_c1 * (12.0 * num + 10.0 * num7));
			num6 = 0.2 * (3.0 * num3 + 12.0 * m_c1 * num2 + 6.0 * num * num + 15.0 * num7 * (2.0 * num + num7));
		}
		double num9 = base.Orbit.Elements.MeanAnomalyRad + m_xmdot * tsince;
		double num10 = base.Orbit.Elements.ArgPerigeeRad + m_omgdot * tsince;
		double num11 = base.Orbit.Elements.RAANodeRad + m_xnodot * tsince;
		double num12 = num10;
		double num13 = num9;
		double num14 = tsince * tsince;
		double num15 = num11 + m_xnodcf * num14;
		double num16 = 1.0 - m_c1 * tsince;
		double num17 = base.Orbit.Elements.BStar * m_c4 * tsince;
		double num18 = m_t2cof * num14;
		if (!flag)
		{
			double num19 = double_1 * tsince;
			double num20 = double_2 * (Math.Pow(1.0 + m_eta * Math.Cos(num9), 3.0) - double_3);
			double num21 = num19 + num20;
			num13 = num9 + num21;
			num12 = num10 - num21;
			double num22 = num14 * tsince;
			double num23 = tsince * num22;
			num16 = num16 - num * num14 - num2 * num22 - num3 * num23;
			num17 += base.Orbit.Elements.BStar * double_0 * (Math.Sin(num13) - double_4);
			num18 = num18 + num4 * num22 + num23 * (num5 + tsince * num6);
		}
		double num24 = base.Orbit.Elements.Eccentricity - num17;
		if (num24 >= 1.0 || num24 < -0.001)
		{
			throw new DecayException(base.Orbit.EpochTime.AddMinutes(tsince), base.Orbit.SatName);
		}
		num24 = Math.Max(num24, 1E-06);
		double a = base.Orbit.SemiMajorRec * Globals.Sqr(num16);
		double xl = num13 + num12 + num15 + base.Orbit.MeanMotionRec * num18;
		return FinalPosition(base.Orbit.Elements.InclinationRad, num12, num24, a, xl, num15, tsince);
	}

	static NoradSGP4()
	{
		Class72.smethod_20();
	}
}
