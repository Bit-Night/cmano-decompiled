using System;
using System.Runtime.InteropServices;
using CSMaterial;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class SatelliteLinkModel
{
	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_Agaz@32(double freq, double Elevation, double Temperature, double Rho);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_Anuages@24(double freq, double Elevation, double TCC);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_Apluie@64(double lat, double freq, double Elevation, double Unavailability, double hstation, double rainheight, double rainintensity, double polarization);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_Scintillation@56(double Nwet, double freq, double Elevation, double Unavailability, double hstation, double eta, double Diam);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_coindice_refraction@16(double latitude, double longitude);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_contenu_eau_liquide@24(double Latitude, double Longitude, double Unavailability);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_hauteur_pluie@16(double latitude, double longitude);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_intensite_pluie@24(double latitude, double longitude, double Unavailability);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_temperature@16(double latitude, double longitude);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_vapeur_d_eau@16(double latitude, double longitude);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_contenu_vapeur_eau@24(double latitude, double longitude, double Indispo);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_Agaz_depassee@40(double Freq, double Elevation, double Temperature, double IWVC, double Rho);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern long _version@0();

	internal static double TotalAbsorption(double FreqGHz, double TerminalAltitude, double Reliability, double Elevation, double Latitude, double Longitude, double Polarization, double AntennaEfficiency, double AntennaDiameter)
	{
		if (!(AntennaEfficiency < 0.0) && AntennaEfficiency <= 100.0)
		{
			if (!(Reliability > 99.0) && Reliability >= 50.0)
			{
				if (Elevation < 1.0)
				{
					return double.MaxValue;
				}
				double num = _Calcule_Agaz@32(FreqGHz, Elevation * 0.0174532925199433, _Calcule_temperature@16(Latitude, Longitude), _Calcule_vapeur_d_eau@16(Latitude, Longitude));
				double unavailability = 100.0 - Reliability;
				double num2 = _Calcule_Apluie@64(Latitude, FreqGHz, Elevation * 0.0174532925199433, unavailability, TerminalAltitude / 1000.0, _Calcule_hauteur_pluie@16(Latitude, Longitude), _Calcule_intensite_pluie@24(Latitude, Longitude, unavailability), Polarization);
				double num3 = _Calcule_Anuages@24(FreqGHz, Elevation * 0.0174532925199433, _Calcule_contenu_eau_liquide@24(Latitude, Longitude, unavailability));
				double x = _Calcule_Scintillation@56(_Calcule_coindice_refraction@16(Latitude, Longitude), FreqGHz, Elevation * 0.0174532925199433, unavailability, TerminalAltitude / 1000.0, AntennaEfficiency / 100.0, AntennaDiameter);
				return num + Math.Sqrt(Math.Pow(num2 + num3, 2.0) + Math.Pow(x, 2.0));
			}
			throw new Exception("Reliability must be in [50.0;99.9]");
		}
		throw new Exception("Antenna efficiency must be in [0;100]");
	}

	internal static double FreeSpaceLinkLoss_dB(double FreqGHz, double RangeKm)
	{
		return 92.4477832218834 + 20.0 * Math.Log10(FreqGHz) + 20.0 * Math.Log10(RangeKm);
	}

	internal static double TotalLoss_dB_Loc(double TermLat, double TermLon, double TerminalAltitudeM, double SatLat, double SatLon, double SatAltitudeM, double FreqGHz, double Reliability, double Polarization, double AntennaEfficiency, double AntennaDiameter)
	{
		double Elevation = default(double);
		double RangeKm = default(double);
		Geodesic_Vincenty.ApproxElevationRange(TermLat, TermLon, TerminalAltitudeM, SatLat, SatLon, SatAltitudeM, ref Elevation, ref RangeKm);
		return TotalAbsorption(FreqGHz, TerminalAltitudeM, Reliability, Elevation, TermLat, TermLon, Polarization, AntennaEfficiency, AntennaDiameter) + FreeSpaceLinkLoss_dB(FreqGHz, RangeKm);
	}

	internal static double TotalLoss_dB_LocDish(double TermLat, double TermLon, double TerminalAltitudeM, double SatLat, double SatLon, double SatAltitudeM, double FreqGHz, double Reliability, double Polarization, double AntennaGain_dB)
	{
		double num = Math.Pow(10.0, AntennaGain_dB / 10.0);
		double antennaDiameter = 299792458.0 / (FreqGHz * 1000000000.0) / Math.Sqrt(Math.Pow(3.14159265358979, 2.0) / num);
		double Elevation = default(double);
		double RangeKm = default(double);
		Geodesic_Vincenty.ApproxElevationRange(TermLat, TermLon, TerminalAltitudeM, SatLat, SatLon, SatAltitudeM, ref Elevation, ref RangeKm);
		return TotalAbsorption(FreqGHz, TerminalAltitudeM, Reliability, Elevation, TermLat, TermLon, Polarization, 100.0, antennaDiameter) + FreeSpaceLinkLoss_dB(FreqGHz, RangeKm);
	}

	internal static double TotalLoss_dB(double FreqGHz, double RangeKm, double TerminalAltitude, double Reliability, double Elevation, double Latitude, double Longitude, double Polarization, double AntennaEfficiency, double AntennaDiameter)
	{
		return TotalAbsorption(FreqGHz, TerminalAltitude, Reliability, Elevation, Latitude, Longitude, Polarization, AntennaEfficiency, AntennaDiameter) + FreeSpaceLinkLoss_dB(FreqGHz, RangeKm);
	}

	public static void Main()
	{
		Console.WriteLine(_Calcule_Agaz@32(30.0, 38.4 * CSMath.PI_dividedBy_180, _Calcule_temperature@16(43.4, 1.4), _Calcule_vapeur_d_eau@16(43.4, 1.4)));
		Console.WriteLine(TotalLoss_dB(21.0, 37901.8, 300.0, 99.0, 30.0, 43.4, 1.4, 45.0, 70.0, 2.4));
		double freqGHz = 30.0;
		double num = 0.009993081933333333;
		double num2 = 2.0;
		do
		{
			double num3 = Math.Pow(3.14159265358979, 2.0) / Math.Pow(num / num2, 2.0) / 0.7;
			double antennaDiameter = num / Math.Sqrt(Math.Pow(3.14159265358979, 2.0) / num3);
			Console.WriteLine(num2 + " " + TotalLoss_dB_LocDish(21.0, 5.0, 300.0, 25.0, 5.0, 300000.0, freqGHz, 99.0, 45.0, num2) + " " + Conversions.ToString(TotalLoss_dB_Loc(21.0, 5.0, 300.0, 25.0, 5.0, 300000.0, freqGHz, 99.0, 45.0, 70.0, antennaDiameter)));
			num2 += 0.1;
		}
		while (num2 <= 10.0);
		double num4 = -180.0;
		do
		{
			num2 = -90.0;
			int num5 = 5;
			while (true)
			{
				string[] array = new string[num5];
				array[0] = num2.ToString();
				array[1] = " ";
				array[2] = num4.ToString();
				array[3] = " ";
				array[4] = _Calcule_hauteur_pluie@16(num2, num4).ToString();
				Console.WriteLine(string.Concat(array));
				num2 += 1.0;
				if (!(num2 <= 90.0))
				{
					break;
				}
				num5 = 5;
			}
			num4 += 1.0;
		}
		while (!(num4 > 180.0));
	}

	static SatelliteLinkModel()
	{
		Class72.smethod_20();
	}
}
