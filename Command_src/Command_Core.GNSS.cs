using System;
using System.Linq;
using Collections.Pooled;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
internal sealed class GNSS
{
	public enum GNSSSystem
	{
		GPS_L1_CA,
		GPS_L1_M,
		GLONASS_L1,
		BEIDOU_B1I,
		NAVIC_L5
	}

	public static GNSSSystem GNSSJammerType(Sensor theS)
	{
		if (theS.Name.Contains("GPS"))
		{
			return GNSSSystem.GPS_L1_CA;
		}
		if (!theS.Name.Contains("GLONASS"))
		{
			if (!theS.Name.Contains("Beidou"))
			{
				if (!theS.Name.Contains("NavIC"))
				{
					return GNSSSystem.GPS_L1_CA;
				}
				return GNSSSystem.NAVIC_L5;
			}
			return GNSSSystem.BEIDOU_B1I;
		}
		return GNSSSystem.GLONASS_L1;
	}

	public static double ComputeRequiredRangeToJam(double jammerPowerWatts, double desiredProbability, GNSSSystem system, double extraLossDb = 45.0)
	{
		if (jammerPowerWatts <= 0.0)
		{
			throw new ArgumentException("jammerPowerWatts must be > 0");
		}
		desiredProbability = Math.Max(1E-08, Math.Min(0.99999999, desiredProbability));
		double num = 300000000.0;
		double num2 = 1852.0;
		double num3 = 0.5;
		double num4;
		double num5;
		double num6;
		switch (system)
		{
		default:
			throw new ArgumentException("Unsupported GNSS system");
		case GNSSSystem.GPS_L1_CA:
			num4 = 1575420000.0;
			num5 = -160.0;
			num6 = 10.0;
			break;
		case GNSSSystem.GPS_L1_M:
			num4 = 1575420000.0;
			num5 = -155.0;
			num6 = 15.0;
			break;
		case GNSSSystem.GLONASS_L1:
			num4 = 1602000000.0;
			num5 = -158.0;
			num6 = 12.0;
			break;
		case GNSSSystem.BEIDOU_B1I:
			num4 = 1561098000.0;
			num5 = -158.0;
			num6 = 12.0;
			break;
		case GNSSSystem.NAVIC_L5:
			num4 = 1176450000.0;
			num5 = -157.0;
			num6 = 14.0;
			break;
		}
		double num7 = num / num4;
		double num8 = 10.0 * Math.Log10(jammerPowerWatts) - extraLossDb;
		double d = 1.0 / desiredProbability - 1.0;
		double num9 = num6 - 1.0 / num3 * Math.Log(d);
		double num10 = num5 + num9;
		if (num10 > num8)
		{
			return double.NaN;
		}
		double num11 = num8 - num10;
		return num7 / (Math.PI * 4.0) * Math.Pow(10.0, num11 / 20.0) / num2;
	}

	public static double ComputeMultiJammerDisruptionProbability(PooledList<double> jammerPowersWatts, PooledList<double> slantRangesNM, GNSSSystem system, double extraLossDb = 45.0)
	{
		if (jammerPowersWatts != null && slantRangesNM != null)
		{
			if (jammerPowersWatts.Count != slantRangesNM.Count)
			{
				throw new ArgumentException("jammerPowersWatts and slantRangesNM must have the same length.");
			}
			if (jammerPowersWatts.Count != 0)
			{
				double num = 300000000.0;
				double num2 = 1852.0;
				double num3 = 0.5;
				double num4;
				double num5;
				double num6;
				switch (system)
				{
				default:
					throw new ArgumentException("Unsupported GNSS system");
				case GNSSSystem.GPS_L1_CA:
					num4 = 1575420000.0;
					num5 = -160.0;
					num6 = 10.0;
					break;
				case GNSSSystem.GPS_L1_M:
					num4 = 1575420000.0;
					num5 = -155.0;
					num6 = 15.0;
					break;
				case GNSSSystem.GLONASS_L1:
					num4 = 1602000000.0;
					num5 = -158.0;
					num6 = 12.0;
					break;
				case GNSSSystem.BEIDOU_B1I:
					num4 = 1561098000.0;
					num5 = -158.0;
					num6 = 12.0;
					break;
				case GNSSSystem.NAVIC_L5:
					num4 = 1176450000.0;
					num5 = -157.0;
					num6 = 14.0;
					break;
				}
				double num7 = num / num4;
				double num8 = Math.Pow(10.0, (0.0 - extraLossDb) / 10.0);
				double num9 = 0.0;
				int num10 = jammerPowersWatts.Count - 1;
				for (int i = 0; i <= num10; i++)
				{
					double num11 = jammerPowersWatts.InternalArray()[i];
					double num12 = slantRangesNM.InternalArray()[i] * num2;
					if (!(num11 <= 0.0) && !(num12 <= 0.0))
					{
						double num13 = Math.Pow(num7 / (Math.PI * 4.0 * num12), 2.0);
						double num14 = num11 * num8 * num13;
						if (!double.IsNaN(num14) && num14 > 0.0)
						{
							num9 += num14;
						}
					}
				}
				if (num9 <= 0.0)
				{
					return 0.0;
				}
				double num15 = 10.0 * Math.Log10(num9) - num5;
				double num16 = (0.0 - num3) * (num15 - num6);
				double val;
				try
				{
					val = 1.0 / (1.0 + Math.Exp(num16));
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val = ((num16 > 0.0) ? 0.0 : 1.0);
					ProjectData.ClearProjectError();
				}
				return Math.Min(1.0, Math.Max(0.0, val));
			}
			return 0.0;
		}
		throw new ArgumentNullException("Input arrays must not be null.");
	}

	public static double EstimateCurrentAccuracyKF(double nominalAccuracy, FixedSizeQueue<bool> pntChecks, double epochSec = 1.0, int windowForQuality = 10, double sigmaAccel = 3.0, double posDriftPerSec = 1.0, double qualityInflationFactor = 10.0)
	{
		if (pntChecks != null && pntChecks.Count != 0)
		{
			double num = nominalAccuracy * nominalAccuracy;
			double num2 = nominalAccuracy * nominalAccuracy;
			int num3 = pntChecks.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				double num4 = sigmaAccel * sigmaAccel * (epochSec * epochSec * epochSec) / 3.0;
				double num5 = posDriftPerSec * epochSec * (posDriftPerSec * epochSec);
				double num6 = num4 + num5;
				num += num6;
				if (!pntChecks.ElementAtOrDefault(i))
				{
					continue;
				}
				int num7 = Math.Max(0, i - windowForQuality + 1);
				int num8 = i - num7 + 1;
				int num9 = 0;
				int num10 = i;
				for (int j = num7; j <= num10; j++)
				{
					if (pntChecks.ElementAtOrDefault(j))
					{
						num9++;
					}
				}
				double num11 = (double)num9 / (double)num8;
				double num12 = 0.02;
				if (num11 < num12)
				{
					num11 = num12;
				}
				double num13 = num2 * (1.0 + (1.0 - num11) * qualityInflationFactor);
				double num14 = num / (num + num13);
				num = (1.0 - num14) * num;
				double num15 = num2 * 0.25;
				if (num < num15)
				{
					num = num15;
				}
			}
			return Math.Sqrt(num);
		}
		return nominalAccuracy;
	}

	static GNSS()
	{
		Class72.smethod_20();
	}
}
