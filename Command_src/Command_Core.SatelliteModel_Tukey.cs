using System;
using System.ComponentModel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class SatelliteModel_Tukey
{
	public sealed class TSatellite
	{
		public SxPxConstants.sgp_data SatData;

		[Category("Classical ephemeris")]
		public double Eccentricity
		{
			get
			{
				return SatData.Eccentricity;
			}
			set
			{
				SatData.Eccentricity = value;
				SatData.method_0();
			}
		}

		[Category("Classical ephemeris")]
		public double SemiMajorAxis
		{
			get
			{
				return SatData.Ideal_SemiMajorAxis_km;
			}
			set
			{
				SatData.Ideal_SemiMajorAxis_km = value;
				SatData.method_0();
			}
		}

		[Category("Decay parameters")]
		public double BSTAR
		{
			get
			{
				return SatData.RadiationPressureCoeff_BSTAR;
			}
			set
			{
				SatData.RadiationPressureCoeff_BSTAR = value;
			}
		}

		[Category("Classical ephemeris")]
		public double MeanAnomaly
		{
			get
			{
				return SatData.MeanAnomaly;
			}
			set
			{
				SatData.MeanAnomaly = value;
			}
		}

		[Category("Derived parameters")]
		public double ApogeeAltitude_km => SatData.ApA;

		[Category("Derived parameters")]
		public double PerigeeAltitude_km => SatData.PeA;

		[Category("Derived parameters")]
		public double OrbitalPeriod_s
		{
			get
			{
				return SatData.OrbitalPeriod_s;
			}
			set
			{
				SatData.OrbitalPeriod_s = value;
				SatData.method_0();
			}
		}

		[Category("Classical ephemeris")]
		public DateTime EphemerisDate
		{
			get
			{
				int num = RadarModel.Floor(SatData.epoch * 0.001);
				num = ((num < 57) ? (num + 2000) : (num + 1900));
				double num2 = SatData.epoch - (double)RadarModel.Floor(SatData.epoch * 0.001) * 1000.0;
				return new DateTime(num, 1, 1, 0, 0, 0).AddDays(num2 - 1.0);
			}
			set
			{
				int num = ((value.Year >= 2000) ? (value.Year - 2000) : (value.Year - 1900));
				SatData.epoch = (double)num * 1000.0 + (double)value.DayOfYear + value.TimeOfDay.TotalSeconds / 86400.0;
				SatData.julian_epoch = SxPxTime.Julian_Date_of_Epoch(ref SatData.epoch);
			}
		}

		[Category("Classical ephemeris")]
		public double Inclination
		{
			get
			{
				return SatData.Inclination;
			}
			set
			{
				SatData.Inclination = value;
			}
		}

		[Category("Classical ephemeris")]
		public double RAAscendingNode
		{
			get
			{
				return SatData.MeanRightAscensionAscendingNode;
			}
			set
			{
				SatData.MeanRightAscensionAscendingNode = value;
			}
		}

		[Category("Classical ephemeris")]
		public double ArgPerigee
		{
			get
			{
				return SatData.AgP;
			}
			set
			{
				SatData.AgP = value;
			}
		}

		[Category("Identification")]
		public string ObjectName
		{
			get
			{
				return SatData.ObjectName;
			}
			set
			{
				SatData.ObjectName = value;
			}
		}

		[Category("Identification")]
		public string NORADNumber
		{
			get
			{
				return SatData.catnr;
			}
			set
			{
				SatData.catnr = value;
			}
		}

		[Category("Identification")]
		public string ElementSetNumber
		{
			get
			{
				return new string(SatData.elset);
			}
			set
			{
				SatData.elset = value.ToCharArray();
			}
		}

		[Category("Identification")]
		public int OrbitNumberAtEpoch
		{
			get
			{
				return SatData.OrbitNumberAtEpoch;
			}
			set
			{
				SatData.OrbitNumberAtEpoch = value;
			}
		}

		[Category("Decay parameters")]
		public double FirstDerivativeOfMeanMotion
		{
			get
			{
				return SatData.xndt2o;
			}
			set
			{
				SatData.xndt2o = value;
			}
		}

		[Category("Decay parameters")]
		public double SecondDerivativeOfMeanMotion
		{
			get
			{
				return SatData.xndd6o;
			}
			set
			{
				SatData.xndd6o = value;
			}
		}

		public TSatellite(SxPxConstants.tle_ascii V)
		{
			SatData = new SxPxConstants.sgp_data();
			Sgp_conv.Convert_Satellite_Data(ref V, ref SatData);
		}

		public TSatellite()
		{
			SatData = new SxPxConstants.sgp_data();
			SatData.bstar = 0.0;
			NORADNumber = "XXXXX";
			SatData.xmo = 0.0;
			SatData.xndd6o = 0.0;
			SatData.xndt2o = 0.0;
			ArgPerigee = 0.0;
			RAAscendingNode = 0.0;
			EphemerisDate = DateAndTime.Now;
			Inclination = 63.4;
			SetApogeeAndPerigee(300.0, 300.0);
		}

		public void ReInit(double Inc, double ApA, double PeA)
		{
			Inclination = Inc;
			SetApogeeAndPerigee(ApA, PeA);
			EphemerisDate = new DateTime(1900, 1, 1);
		}

		public void ReInit(double Inc, double ApA, double PeA, double ArgP)
		{
			Inclination = Inc;
			SetApogeeAndPerigee(ApA, PeA);
			ArgPerigee = ArgP;
		}

		public void method_0(string[] V)
		{
			if (V.Length < 2)
			{
				throw new Exception("Two-line elements must include at least *three* lines: name of the sat comes first.");
			}
			SxPxConstants.tle_ascii tle = default(SxPxConstants.tle_ascii);
			tle.l = new string[3];
			tle.l[0] = V[0];
			tle.l[1] = V[1];
			tle.l[2] = V[2];
			Sgp_conv.Convert_Satellite_Data(ref tle, ref SatData);
		}

		public TSatellite(string[] V)
		{
			SatData = new SxPxConstants.sgp_data();
			method_0(V);
		}

		internal double SSO_Inclination()
		{
			double num = Math.Pow(SemiMajorAxis * 1000.0, 3.5);
			double eccentricity = Eccentricity;
			double num2 = eccentricity * eccentricity;
			double num3 = 1.0 - num2;
			double num4 = num3 * num3;
			double num5 = Math.Sqrt(398600441800000.0);
			double num6 = num * num4 * (2.0 / 3.0) * 0.01720279125572669 / (-11954461775405058.0 / Math.PI * num5);
			if (Math.Abs(num6) <= 1.0)
			{
				return Math.Acos(num6) * 57.2957795130823;
			}
			return 0.0;
		}

		internal double NodalPrecessionRate()
		{
			double eccentricity = Eccentricity;
			double num = 1.0 - eccentricity * eccentricity;
			double num2 = num * num;
			double num3 = Math.Pow(SemiMajorAxis * 1000.0, 3.5);
			double num4 = Math.Sqrt(398600441800000.0);
			double num5 = -66062905679.126045 * num4 * Math.Cos(Inclination * 0.0174532925199433) / (num3 * num2);
			return 57.2957795130823 * num5 * 86400.0;
		}

		public void Predict_Position(DateTime TrackTime, bool IsUTC, ref double Lat, ref double Lon, ref double AltKm, ref double Velocity)
		{
			SxPxConstants.vector pos = default(SxPxConstants.vector);
			pos.v = new double[4];
			SxPxConstants.vector vel = default(SxPxConstants.vector);
			vel.v = new double[4];
			int hours = 8;
			TimeZone currentTimeZone = TimeZone.CurrentTimeZone;
			DateTime dateTime;
			if (!IsUTC)
			{
				currentTimeZone.GetUtcOffset(TrackTime);
				if (currentTimeZone.IsDaylightSavingTime(TrackTime))
				{
					hours = 7;
				}
				dateTime = currentTimeZone.ToUniversalTime(TrackTime);
			}
			else
			{
				dateTime = TrackTime;
			}
			dateTime = dateTime.Subtract(new TimeSpan(0, hours, 0, 0));
			double num = SxPxTime.Julian_Date(ref dateTime);
			Sgp4Sdp4.sgp4call(num, ref pos, ref vel, SatData);
			Sgp_conv.Convert_Sat_State(ref pos, ref vel);
			SxPxConstants.geodetic_t geodetic = default(SxPxConstants.geodetic_t);
			SxPxMath.Calculate_LatLonAlt(num - SatData.julian_epoch, ref pos, ref geodetic);
			Lat = SxPxMath.Degrees(geodetic.lat);
			Lon = SxPxMath.modulus(SxPxMath.Degrees(geodetic.lon), 360.0);
			AltKm = geodetic.alt;
			Velocity = vel.v[3];
			Lon = Math2.NormalizeLongitude(Lon);
		}

		public void SetApogeeAndPerigee(double ApA, double PeA)
		{
			SatData.SetApogeeAndPerigee(ApA, PeA);
			SatData.method_0();
		}

		static TSatellite()
		{
			Class72.smethod_20();
		}
	}

	public const double Earth_J2_notide = 0.00108262668;

	public const double Earth_J2_tide = 0.0010826359;

	public const double EquatorialRadius = 6378165.0;

	public const double ProgradeCriticalInclination = 63.434948822922;

	public const double RetrogradeCriticalInclination = 116.565051177078;

	public static void gettestdata(ref SxPxConstants.tle_ascii satdata)
	{
		satdata.l = new string[3];
		satdata.l[0] = "INTELSAT 603 (IS-603)";
		satdata.l[1] = "1 20523U 90021A   07349.98446615 -.00000136  00000-0  10000-3 0  1975";
		satdata.l[2] = "2 20523   5.0107  74.6594 0004309 254.3507  89.6748  1.00271715 57967";
	}

	internal static double NodalPrecessionRate(double ApR, double PeR, double Inclination)
	{
		double num = Eccentricity(ApR, PeR);
		double num2 = 1.0 - num * num;
		double num3 = num2 * num2;
		double x = (ApR + PeR) / 2.0;
		double num4 = -66062905679.126045 * Math.Sqrt(398600441800000.0) * Math.Cos(Inclination * 0.0174532925199433) / (Math.Pow(x, 3.5) * num3);
		return 57.2957795130823 * num4 * 86400.0;
	}

	internal static double SSO_Inclination(double ApR, double PeR)
	{
		double num = Eccentricity(ApR, PeR);
		double num2 = 1.0 - num * num;
		double num3 = num2 * num2;
		double num4 = Math.Pow((ApR + PeR) / 2.0, 3.5);
		double num5 = -1.3273758684974296E-07 * (num4 * num3) / (44041937119.417366 * Math.Sqrt(398600441800000.0));
		if (Math.Abs(num5) > 1.0)
		{
			return 0.0;
		}
		return Math.Acos(num5) * 57.2957795130823;
	}

	public static void SSO_Inclination_And_Apogee(double PeR, int TrackRevisitDelay_Days, int NumRevsPerRevisitCycle, ref double ApR, ref double Inclination)
	{
		double num = Math.Pow((double)(TrackRevisitDelay_Days * 86400) / (double)NumRevsPerRevisitCycle * Math.Sqrt(398600441800000.0) / 6.28318530717959, 2.0 / 3.0);
		ApR = 2.0 * num - PeR;
		double num2 = Eccentricity(ApR, PeR);
		double num3 = 1.0 - num2 * num2;
		double num4 = num3 * num3;
		double num5 = Math.Pow(num, 3.5);
		double num6 = -1.3273758684974296E-07 * (num5 * num4) / (44041937119.417366 * Math.Sqrt(398600441800000.0));
		if (Math.Abs(num6) <= 1.0)
		{
			Inclination = Math.Acos(num6) * 57.2957795130823;
		}
		else
		{
			Inclination = 0.0;
		}
	}

	internal static double SemiMajorAxis(double ApR, double PeR)
	{
		return (ApR + PeR) / 2.0;
	}

	internal static double Eccentricity(double ApR, double PeR)
	{
		return (ApR - PeR) / (ApR + PeR);
	}

	internal static double OrbitalPeriod(double ApR, double PeR)
	{
		double num = (ApR + PeR) / 2.0;
		return 6.28318530717959 * Math.Sqrt(num * num * num / 398600441800000.0);
	}

	public static void Main()
	{
		Console.WriteLine(SSO_Inclination(6948165.0, 6648165.0));
		double ApR = default(double);
		double Inclination = default(double);
		SSO_Inclination_And_Apogee(6648165.0, 3, 33, ref ApR, ref Inclination);
		Console.WriteLine((ApR - 6378165.0) / 1000.0);
		Console.WriteLine(Inclination);
	}

	static SatelliteModel_Tukey()
	{
		Class72.smethod_20();
	}
}
