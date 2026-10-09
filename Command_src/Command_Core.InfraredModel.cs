using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class InfraredModel
{
	public sealed class TInfraredDetector
	{
		public float Altitude;

		public double Lower_Wavelen;

		public double Upper_Wavelen;

		public double BandwidthFactor;

		public double Efficiency;

		public double Aperture;

		public double OwnTemp;

		public double SNRmin;

		public TInfraredDetector()
		{
			OwnTemp = 288.15;
			Aperture = 1.0;
			Altitude = 10f;
			Efficiency = 0.95;
			BandwidthFactor = 0.75;
			SNRmin = 1.0;
		}

		static TInfraredDetector()
		{
			Class72.smethod_20();
		}
	}

	public struct TInfraredTarget
	{
		public float Altitude;

		public double Temperature;

		public double Emissivity;

		public double ProjectedArea;
	}

	public sealed class TBlackBodyCurve
	{
		public int num_points;

		public double[] ltab;

		public double[] btab;

		public TBlackBodyCurve()
		{
			double[] array = new double[134]
			{
				0.0, 1000.0, 1330.0, 1420.0, 1450.0, 1600.0, 1720.0, 1810.0, 1870.0, 1960.0,
				2020.0, 2080.0, 2140.0, 2200.0, 2230.0, 2260.0, 2290.0, 2320.0, 2350.0, 2380.0,
				2410.0, 2440.0, 2500.0, 2530.0, 2590.0, 2620.0, 2680.0, 2710.0, 2770.0, 2800.0,
				2860.0, 2890.0, 2920.0, 2950.0, 2980.0, 3040.0, 3070.0, 3100.0, 3130.0, 3160.0,
				3190.0, 3220.0, 3250.0, 3280.0, 3310.0, 3340.0, 3370.0, 3400.0, 3430.0, 3460.0,
				3490.0, 3520.0, 3550.0, 3580.0, 3610.0, 3670.0, 3700.0, 3730.0, 3760.0, 3820.0,
				3850.0, 3880.0, 3910.0, 3940.0, 3970.0, 4000.0, 4030.0, 4060.0, 4090.0, 4120.0,
				4150.0, 4180.0, 4210.0, 4240.0, 4270.0, 4300.0, 4330.0, 4360.0, 4390.0, 4420.0,
				4450.0, 4480.0, 4510.0, 4540.0, 4570.0, 4600.0, 4630.0, 4660.0, 4690.0, 4720.0,
				4780.0, 4810.0, 4840.0, 4870.0, 4930.0, 4960.0, 4990.0, 5020.0, 5110.0, 5200.0,
				5290.0, 5380.0, 5470.0, 5560.0, 5650.0, 5770.0, 5890.0, 5980.0, 6100.0, 6250.0,
				6370.0, 6520.0, 6670.0, 6820.0, 6970.0, 7150.0, 7330.0, 7540.0, 7780.0, 8020.0,
				8260.0, 8560.0, 8890.0, 9250.0, 9640.0, 10120.0, 10660.0, 11320.0, 12130.0, 13150.0,
				14530.0, 16600.0, 20320.0, 32200.0
			};
			double[] array2 = new double[134]
			{
				0.0, 0.0001, 0.0055, 0.0091, 0.0107, 0.0207, 0.0319, 0.0423, 0.05, 0.0629,
				0.0723, 0.0823, 0.0928, 0.1038, 0.1095, 0.1153, 0.1212, 0.1272, 0.1333, 0.1395,
				0.1458, 0.1521, 0.165, 0.1715, 0.1847, 0.1914, 0.2048, 0.2116, 0.2252, 0.232,
				0.2456, 0.2525, 0.2593, 0.2661, 0.273, 0.2866, 0.2933, 0.3001, 0.3068, 0.3136,
				0.3203, 0.3269, 0.3335, 0.3401, 0.3467, 0.3532, 0.3597, 0.3662, 0.3726, 0.379,
				0.3853, 0.3916, 0.3978, 0.404, 0.4101, 0.4222, 0.4282, 0.4342, 0.4401, 0.4517,
				0.4574, 0.4631, 0.4687, 0.4743, 0.4798, 0.4853, 0.4907, 0.4961, 0.5014, 0.5067,
				0.5117, 0.517, 0.5221, 0.5272, 0.5321, 0.537, 0.542, 0.5468, 0.5515, 0.5563,
				0.561, 0.5656, 0.5702, 0.5747, 0.5792, 0.5836, 0.588, 0.5923, 0.5966, 0.6008,
				0.6091, 0.6132, 0.6172, 0.6212, 0.6291, 0.6329, 0.6367, 0.6404, 0.6515, 0.6621,
				0.6724, 0.6823, 0.6919, 0.7011, 0.7101, 0.7214, 0.7323, 0.7401, 0.7502, 0.762,
				0.771, 0.7817, 0.7917, 0.8013, 0.8102, 0.8204, 0.8298, 0.8402, 0.8509, 0.8609,
				0.87, 0.8804, 0.8906, 0.9006, 0.9102, 0.9204, 0.9302, 0.9402, 0.9503, 0.9602,
				0.97, 0.98, 0.99, 1.0
			};
			ltab = new double[2];
			ltab = array;
			array = null;
			btab = new double[2];
			btab = array2;
			array2 = null;
			num_points = Information.UBound((Array)ltab, 1) + 1;
		}

		internal double CalcBandwidthFactor(double LowerWavelen, double UpperWavelen, double T)
		{
			double value = LowerWavelen * T;
			double value2 = UpperWavelen * T;
			int num = Array.BinarySearch(ltab, value);
			if (num < 0)
			{
				num = Math.Max(~num - 1, 0);
			}
			int num2 = Array.BinarySearch(ltab, value2);
			if (num2 < 0)
			{
				num2 = ~num2;
			}
			return btab[num2] - btab[num];
		}

		static TBlackBodyCurve()
		{
			Class72.smethod_20();
		}
	}

	internal static bool InfraredEquation(ref TInfraredDetector Detector, ref TInfraredTarget Target, double BackgroundTemperature, double DistanceToTarget, ref Weather.WeatherProfile Env)
	{
		double num = DistanceToTarget * 1852.0;
		bool result;
		try
		{
			double num2 = Math.Sqrt(12742000.0 * (double)Detector.Altitude + Math.Pow(Detector.Altitude, 2.0));
			double num3 = Math.Sqrt(12742000.0 * (double)Target.Altitude + Math.Pow(Target.Altitude, 2.0));
			double num4 = num2 + num3;
			if (num <= num4)
			{
				double num5 = Target.ProjectedArea * Target.Emissivity * 5.6704E-08 * Math.Pow(Target.Temperature, 4.0) * Detector.BandwidthFactor * Detector.Efficiency * Detector.Aperture / (12.56637061435916 * Math.Pow(num, 2.0)) * Math.Exp((0.0 - Extinction_Coefficient(ref Detector, ref Env)) * num);
				double num6 = 1.380650424E-23 * Math.Max(BackgroundTemperature, Detector.OwnTemp);
				result = ((num5 / num6 > Detector.SNRmin) ? true : false);
			}
			else
			{
				result = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101123", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num7;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num7 = 0;
			}
			else
			{
				num7 = 0;
			}
			result = (byte)num7 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static double Extinction_Coefficient(ref TInfraredDetector Detector, ref Weather.WeatherProfile Env)
	{
		if (Detector.Upper_Wavelen <= 5.0)
		{
			return 6.7E-05;
		}
		return 0.0002;
	}

	internal static double Planck_Integral(double wavelen, double T)
	{
		double num = 0.01 / (wavelen / 1000000.0);
		double num2 = 1.438775135874089;
		double num3 = num2 * num / T;
		double num4 = Math.Pow(num3, 2.0);
		double num5 = Math.Pow(num3, 3.0);
		int num6 = (int)Math.Round(2.0 + 20.0 / num3);
		if (num6 > 256)
		{
			num6 = 256;
		}
		double num7 = 0.0;
		int num8 = num6;
		for (int i = 1; i <= num8; i++)
		{
			double num9 = 1.0 / (double)i;
			num7 += Math.Exp((double)(-i) * num3) * (num5 + (3.0 * num4 + 6.0 * (num3 + num9) * num9) * num9) * num9;
		}
		return 1.1910427590866343E-16 * Math.Pow(T / num2, 4.0) * num7;
	}

	internal static double SpectralRadiance(double Wavelength, double T)
	{
		return 119104275.90866342 / Math.Pow(Wavelength, 5.0) * (1.0 / (Math.Exp(1.9864455013852189E-19 / (Wavelength * 1.380650424E-23 * T)) - 1.0));
	}

	public static double GetRelativeIRDetectionRangeMultiplierFromMach(double mach)
	{
		double num = 2.6905;
		double num2 = -0.2857;
		return -0.2381 * mach * mach + num * mach + num2;
	}

	static InfraredModel()
	{
		Class72.smethod_20();
	}
}
