using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Horizon
{
	public struct HorizonResult
	{
		public bool IsAboveHorizon;

		public double ElevationDeg;

		public double IntersectionLat;

		public double IntersectionLon;

		public double IntersectionAlt;
	}

	internal static float RadarHorizonNM(Module_Unit.Unit theObserver, ref float TargetAlt, Sensor theSensor)
	{
		return RadarHorizonNM(Module_Unit.Unit.DetermineAltitude_SensorObserver_Radar(theObserver, theSensor), TargetAlt);
	}

	internal static float RadarHorizonNM(Module_Unit.Unit theObserver, Module_Unit.Unit theTarget, Sensor theSensor)
	{
		float targetAltitude = Module_Unit.Unit.DetermineAltitude_SensorTarget_Radar(theTarget);
		return RadarHorizonNM(Module_Unit.Unit.DetermineAltitude_SensorObserver_Radar(theObserver, theSensor), targetAltitude);
	}

	internal static float VisualHorizonNM(Module_Unit.Unit theObserver, ref float TargetAltitude, Sensor theSensor)
	{
		return VisualHorizonNM(theObserver.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)theObserver.get_MastHeight_Visual(theSensor), TargetAltitude);
	}

	internal static float VisualHorizonNM(Module_Unit.Unit theObserver, Module_Unit.Unit theTarget, Sensor theSensor)
	{
		float detectorAltitude = theObserver.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)theObserver.get_MastHeight_Visual(theSensor);
		float targetAltitude = theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)theTarget.get_MastHeight_Visual((Sensor)null);
		return VisualHorizonNM(detectorAltitude, targetAltitude);
	}

	internal static float RealHorizonNM(float DetectorAltitude, float TargetAltitude)
	{
		double num = Math.Sqrt(12742000.0 * (double)DetectorAltitude + Math.Pow(DetectorAltitude, 2.0));
		double num2 = Math.Sqrt(12742000.0 * (double)TargetAltitude + Math.Pow(TargetAltitude, 2.0));
		return (float)((num + num2) * 0.000539957);
	}

	internal static float VisualHorizonNM(float DetectorAltitude, float TargetAltitude)
	{
		double num = Math.Sqrt(12742000.0 * (double)DetectorAltitude + Math.Pow(DetectorAltitude, 2.0));
		double num2 = Math.Sqrt(12742000.0 * (double)TargetAltitude + Math.Pow(TargetAltitude, 2.0));
		return (float)((num + num2) * 0.000539957 * 1.06);
	}

	internal static float RadarHorizonNM(float DetectorAltitude, float TargetAltitude)
	{
		double num = Math.Sqrt(12742000.0 * (double)DetectorAltitude + Math.Pow(DetectorAltitude, 2.0));
		double num2 = Math.Sqrt(12742000.0 * (double)TargetAltitude + Math.Pow(TargetAltitude, 2.0));
		return (float)((num + num2) * 0.000539957 * 1.23);
	}

	internal static float ESMHorizonNM(float DetectorAltitude, float TargetAltitude)
	{
		double num = Math.Sqrt(12742000.0 * (double)DetectorAltitude + Math.Pow(DetectorAltitude, 2.0));
		double num2 = Math.Sqrt(12742000.0 * (double)TargetAltitude + Math.Pow(TargetAltitude, 2.0));
		return (float)((num + num2) * 0.000539957 * 1.5);
	}

	public static HorizonResult OverUnderHorizonCheck(double latObs, double lonObs, double altObs, double latTgt, double lonTgt, double altTgt, double planetRadius = 6371000.0)
	{
		HorizonResult result = default(HorizonResult);
		double num = planetRadius + altObs;
		double num2 = num * Math.Cos(latObs * 0.0174532925199433) * Math.Cos(lonObs * 0.0174532925199433);
		double num3 = num * Math.Cos(latObs * 0.0174532925199433) * Math.Sin(lonObs * 0.0174532925199433);
		double num4 = num * Math.Sin(latObs * 0.0174532925199433);
		double num5 = planetRadius + altTgt;
		double num6 = num5 * Math.Cos(latTgt * 0.0174532925199433) * Math.Cos(lonTgt * 0.0174532925199433);
		double num7 = num5 * Math.Cos(latTgt * 0.0174532925199433) * Math.Sin(lonTgt * 0.0174532925199433);
		double num8 = num5 * Math.Sin(latTgt * 0.0174532925199433);
		double num9 = num3;
		double num10 = num4;
		double num11 = Math.Sqrt(num2 * num2 + num9 * num9 + num10 * num10);
		double num12 = num2 / num11;
		num9 /= num11;
		num10 /= num11;
		double num13 = num6 - num2;
		double num14 = num7 - num3;
		double num15 = num8 - num4;
		double num16 = Math.Sqrt(num13 * num13 + num14 * num14 + num15 * num15);
		num13 /= num16;
		num14 /= num16;
		num15 /= num16;
		double val = num12 * num13 + num9 * num14 + num10 * num15;
		double num17 = Math.Acos(Math.Max(-1.0, Math.Min(1.0, val)));
		double num18 = Math.Acos(planetRadius / (planetRadius + altObs));
		double num19 = 1.570796326794895 + num18 - num17;
		result.ElevationDeg = num19 * 57.2957795130823;
		result.IsAboveHorizon = num19 > 0.0;
		if (!result.IsAboveHorizon)
		{
			double num20 = 1.0;
			double num21 = 2.0 * (num2 * num13 + num3 * num14 + num4 * num15);
			double num22 = num2 * num2 + num3 * num3 + num4 * num4 - planetRadius * planetRadius;
			double num23 = num21 * num21 - 4.0 * num22;
			if (num23 >= 0.0)
			{
				double num24 = (0.0 - num21 - Math.Sqrt(num23)) / (2.0 * num20);
				double num25 = (0.0 - num21 + Math.Sqrt(num23)) / (2.0 * num20);
				double num26 = ((num24 > 0.0) ? num24 : num25);
				double num27 = num2 + num26 * num13;
				double num28 = num3 + num26 * num14;
				double num29 = num4 + num26 * num15;
				double num30 = Math.Sqrt(num27 * num27 + num28 * num28 + num29 * num29);
				result.IntersectionLat = Math.Atan2(num29, Math.Sqrt(num27 * num27 + num28 * num28)) * 57.2957795130823;
				result.IntersectionLon = Math.Atan2(num28, num27) * 57.2957795130823;
				result.IntersectionAlt = num30 - planetRadius;
			}
			else
			{
				result.IntersectionLat = double.NaN;
				result.IntersectionLon = double.NaN;
				result.IntersectionAlt = double.NaN;
			}
		}
		else
		{
			result.IntersectionLat = double.NaN;
			result.IntersectionLon = double.NaN;
			result.IntersectionAlt = double.NaN;
		}
		return result;
	}

	static Horizon()
	{
		Class72.smethod_20();
	}
}
