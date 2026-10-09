using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class PhysicalConstants
{
	public const string ModuleVersion = "Version 0.10";

	public const double FreeFallG = 9.81;

	public const double GGRAV = 6.67259E-11;

	public const double MassEarth = 5.973698968E+24;

	public const double GM_Earth = 398600441800000.0;

	public const double Boltzmann_K = 1.380650424E-23;

	public const double Stefan_Boltzmann_sigma = 5.6704E-08;

	public const double Planck = 6.6260689633E-34;

	public const double c_vacuum = 299792458.0;

	public const double RadiusEarth_km = 6371.0;

	public const float RadiusEarth_nm = 3441.6865f;

	public const double RadiusEarth_m = 6371008.8;

	public const float AtmosphericAltitude_m = 100000f;

	public const double FreeSpaceGHzKm = 92.4477832218834;

	public const double NM_TO_METERS = 1852.0;

	public const double METERS_TO_NM = 0.000539957;

	public const double RAD_TO_DEG = 57.2957795130823;

	public const double DEG_TO_RAD = 0.0174532925199433;

	public const int DEG_TO_NM = 60;

	public const double KNOTS_TO_MPERSEC = 0.514444;

	public const double KNOTS_TO_KPH = 1.852;

	public const double KNOTS_TO_MPH = 1.15078;

	public const double MPERSEC_TO_KNOTS = 1.94384;

	public const double KPH_TO_KNOTS = 0.539957;

	public const double MPH_TO_KNOTS = 0.868976;

	public const double HALFPI = 1.5707963267949;

	public const double FORTPI = 0.785398163397448;

	public const double PI = 3.14159265358979;

	public const double TWOPI = 6.28318530717959;

	public const double SPI = 3.14159265359;

	public const double ONEPI = 3.14159265358979;

	public const double KelvinOffset = 273.15;

	public const double STANDARD_DELTA_N = 39.0;

	public const double STANDARD_N_0 = 339.0;

	public const double STANDARD_REL_HUMIDITY = 86.17;

	public const double STANDARD_PRESSURE = 1013.25;

	public const int STANDARD_TEMP = 15;

	public const int STANDARD_DAYNIGHTTEMPMODIFIER = 10;

	public const double Reference_1_DP_At_1_meter_Damage = 1356750.0;

	public const double Kg_TNT_per_DP = 1.0;

	public const int Single_MINEXPONENT = -125;

	public const int Double_MINEXPONENT = -1021;

	public const int Single_MAXEXPONENT = 128;

	public const int Double_MAXEXPONENT = 1024;

	public const int Single_BASE = 2;

	public const int Double_BASE = 2;

	public const int Single_Mantissa = 24;

	public const int Double_Mantissa = 53;

	public const double DL = double.MaxValue;

	public const int SPEEDOFSOUND_AIR_SL = 661;

	public const int SPEEDOFSOUND_WATER = 2916;

	public const int SPEEDOFSOUND_ROCK = 5832;

	internal static double FreeFallG_AtAltitude(int theAltitude_meters)
	{
		return 9.81 * Math.Pow(6371000.0 / (double)(6371000 + theAltitude_meters), 2.0);
	}

	static PhysicalConstants()
	{
		Class72.smethod_20();
	}
}
