using System;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Physics
{
	private static float[] float_0;

	static Physics()
	{
		Class72.smethod_20();
		float_0 = new float[100000];
	}

	internal static double air_incident_overpressure_psi(double weight_kgTNT, double distance_meters)
	{
		double x = weight_kgTNT * 2.204622915;
		double num = Math.Log(distance_meters * 3.280839895 / Math.Pow(x, 1.0 / 3.0)) / Math.Log(10.0);
		double num2 = -0.756579301809 + 1.3503424993 * num;
		double y = 1.9422502013 - 1.695898874 * num2 - 0.154159376846 * Math.Pow(num2, 2.0) + 0.5140607305 * Math.Pow(num2, 3.0) + 0.0988534365274 * Math.Pow(num2, 4.0) - 0.293912623038 * Math.Pow(num2, 5.0) - 0.0268112345019 * Math.Pow(num2, 6.0) + 0.10909749642 * Math.Pow(num2, 7.0) + 0.0016284676311 * Math.Pow(num2, 8.0) - 0.0214631030242 * Math.Pow(num2, 9.0) + 0.0001456723382 * Math.Pow(num2, 10.0) + 0.00167847752266 * Math.Pow(num2, 11.0);
		return Math.Pow(10.0, y);
	}

	internal static float ComputeMach(double theAltitude, double theSpeed)
	{
		double num = 1718.0;
		double num2 = theAltitude / 0.3048;
		double num3 = ((num2 <= 36152.0) ? (518.6 - 3.56 * num2 / 1000.0) : ((num2 >= 36152.0 && num2 <= 82345.0) ? 389.98 : ((num2 >= 82345.0 && num2 <= 155348.0) ? (389.98 + 1.645 * (num2 - 82345.0) / 1000.0) : ((num2 >= 155348.0 && num2 <= 175346.0) ? 508.788 : ((num2 >= 175346.0 && num2 <= 262448.0) ? (508.788 - 2.46888 * (num2 - 175346.0) / 1000.0) : 508.788)))));
		double num4 = Math.Sqrt(1.4 * num * num3);
		num4 = num4 * 60.0 / 88.0;
		num4 *= 0.8689755962687;
		return (float)(theSpeed / num4);
	}

	public static double ConvertMachToMetersPerSecond(double machNumber, double altitudeInMeters)
	{
		double num = CalculateSpeedOfSound(altitudeInMeters);
		return machNumber * num;
	}

	public static double CalculateSpeedOfSound(double altitudeInMeters)
	{
		double num = 288.15 + -0.0065 * altitudeInMeters;
		return Math.Sqrt(401.87 * num);
	}

	internal static double CalculateDynamicPressure(int altitude_metres, double speed_mpersec)
	{
		double num = CalculateStandardAirDensity(altitude_metres);
		return 0.5 * num * Math.Pow(speed_mpersec, 2.0);
	}

	internal static double ConvertPascalsToPsf(double pressureInPascals)
	{
		return pressureInPascals * 0.0208854342;
	}

	public static float CalculateStandardAirDensity(float altitude)
	{
		try
		{
			if (altitude > 99999f)
			{
				return 0f;
			}
			if (altitude < 0f)
			{
				altitude = 0f;
			}
			float num = float_0[(int)Math.Round(altitude)];
			if (num != 0f)
			{
				return num;
			}
			Weather.TAtmosphere tAtmosphere = Weather.Standard_Atmosphere_AtThisAltitude(Weather.TAtmosphereType.atm_ITU_R_Ref_Std, altitude / 1000f);
			float num2 = (float)(tAtmosphere.Pressure * 100.0 / (287.058 * tAtmosphere.Temperature) + tAtmosphere.Rho / 1000.0);
			float_0[(int)Math.Round(altitude)] = num2;
			return num2;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}
}
