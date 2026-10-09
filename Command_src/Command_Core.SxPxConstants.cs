using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class SxPxConstants
{
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct vector
	{
		public double[] v;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct tle_ascii
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public string[] l;
	}

	public sealed class sgp_data
	{
		protected string _ObjectName;

		public int revnum;

		public double epoch;

		public double julian_epoch;

		public double xno;

		protected double _a;

		public double bstar;

		public double xincl;

		public double eo;

		public double xmo;

		public double omegao;

		public double xnodeo;

		public double xndt2o;

		public double xndd6o;

		public string catnr;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public char[] elset;

		public int ideep;

		public string ObjectName
		{
			get
			{
				return _ObjectName;
			}
			set
			{
				_ObjectName = value;
			}
		}

		public int OrbitNumberAtEpoch
		{
			get
			{
				return revnum;
			}
			set
			{
				revnum = value;
			}
		}

		public double OrbitalPeriod_s
		{
			get
			{
				return 86400.0 / (xno / 0.0043633231299858265);
			}
			set
			{
				xno = 86400.0 / value * 0.0043633231299858265;
				_a = Math.Pow(Math.Sqrt(398600441800000.0) * value / 6.28318530717959, 2.0 / 3.0);
			}
		}

		protected double RevsPerDay => xno / 0.0043633231299858265;

		public double Ideal_SemiMajorAxis_km
		{
			get
			{
				_a = Math.Pow(Math.Sqrt(398600441800000.0) * (86400.0 / (xno / 0.0043633231299858265)) / 6.28318530717959, 2.0 / 3.0);
				return _a / 1000.0;
			}
			set
			{
				_a = value * 1000.0;
				xno = 376.99111843077543 / (6.28318530717959 * Math.Sqrt(_a * _a * _a / 398600441800000.0));
			}
		}

		public double ApA => _a / 1000.0 * (1.0 + Eccentricity) - 6378.135;

		public double PeA => _a / 1000.0 * (1.0 - Eccentricity) - 6378.135;

		public double RadiationPressureCoeff_BSTAR
		{
			get
			{
				return bstar;
			}
			set
			{
				bstar = value;
			}
		}

		public double Inclination
		{
			get
			{
				return xincl * 57.2957795130823;
			}
			set
			{
				if (value == 0.0)
				{
					xincl = 1.74532925199433E-12;
				}
				else
				{
					xincl = value * 0.0174532925199433;
				}
			}
		}

		public double Eccentricity
		{
			get
			{
				return eo;
			}
			set
			{
				try
				{
					if (value < 0.0 || value >= 1.0)
					{
						throw new Exception("Incorrect eccentricity value");
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200264", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
				if (value == 0.0)
				{
					eo = 1E-06;
				}
				else
				{
					eo = value;
				}
			}
		}

		public double MeanAnomaly
		{
			get
			{
				return xmo * 57.2957795130823;
			}
			set
			{
				xmo = value * 0.0174532925199433;
			}
		}

		public double AgP
		{
			get
			{
				return omegao * 57.2957795130823;
			}
			set
			{
				omegao = value * 0.0174532925199433;
			}
		}

		public double MeanRightAscensionAscendingNode
		{
			get
			{
				return xnodeo * 57.2957795130823;
			}
			set
			{
				xnodeo = value * 0.0174532925199433;
			}
		}

		public double FirstDerivativeOfMeanMotion
		{
			get
			{
				return xndt2o;
			}
			set
			{
				xndt2o = value;
			}
		}

		public double SecondDerivativeOfMeanMotion
		{
			get
			{
				return xndd6o;
			}
			set
			{
				xndd6o = value;
			}
		}

		public sgp_data()
		{
			elset = new char[3];
		}

		public void SetApogeeAndPerigee(double ApA, double PeA)
		{
			double num = (ApA + 6378.135) * 1000.0;
			double num2 = (PeA + 6378.135) * 1000.0;
			Eccentricity = (num - num2) / (num + num2);
			_a = (num + num2) / 2.0;
			xno = 376.99111843077543 / (6.28318530717959 * Math.Sqrt(_a * _a * _a / 398600441800000.0));
		}

		public void method_0()
		{
			double num = Math.Pow(Math.Sqrt(1434962880.0 / SxPxMath.cube(6378.135)) / xno, 2.0 / 3.0);
			double num2 = 0.00081196185 * (3.0 * SxPxMath.sqr(Math.Cos(xincl)) - 1.0) / Math.Pow(1.0 - SxPxMath.sqr(eo), 1.5);
			double num3 = num2 / SxPxMath.sqr(num);
			double x = num * (1.0 - num3 * (1.0 / 3.0 + num3 * (1.0 + 1.654320987654321 * num3)));
			double num4 = num2 / SxPxMath.sqr(x);
			double num5 = xno / (1.0 + num4);
			if (6.28318530717958 / num5 < 225.0)
			{
				ideep = 0;
			}
			else
			{
				ideep = 1;
			}
		}

		static sgp_data()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct val_deep_init
	{
		public double eosq;

		public double sinio;

		public double cosio;

		public double betao;

		public double aodp;

		public double theta2;

		public double sing;

		public double cosg;

		public double betao2;

		public double xmdot;

		public double omgdot;

		public double xnodott;

		public double xnodpp;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct val_deep_sec
	{
		public double xmdf;

		public double omgadf;

		public double xnode;

		public double emm;

		public double xincc;

		public double xnn;

		public double tsince;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct val_deep_per
	{
		public double e;

		public double xincc;

		public double omgadf;

		public double xnode;

		public double xmam;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct geodetic_t
	{
		public double lat;

		public double lon;

		public double alt;

		public double theta;
	}

	public const int _SGP0 = 0;

	public const int _SGP4 = 1;

	public const int _SDP4 = 2;

	public const int _SGP8 = 3;

	public const int _SDP8 = 4;

	public const double SidRotPeriod = 86164.09;

	public const double DaySeconds = 86400.0;

	public const double _xmnpda = 1440.0;

	public const double _secday = 86400.0;

	public const double _omega_E = 1.00273790934;

	public const double _tothrd = 2.0 / 3.0;

	public const double J2 = 0.0010826158;

	public const double XJ3 = -2.53881E-06;

	public const double _J4value = -1.65597E-06;

	public const double _e6a = 1E-06;

	public const double _pio2 = 1.570796326794895;

	public const double _2pi = 6.28318530717958;

	public const double _ae = 1.0;

	public const double ge = 398600.8;

	public const double xkmper = 6378.135;

	public const double CK2 = 0.0005413079;

	public const double CK4 = 6.209887499999999E-07;

	public const double F = 0.003352779454167505;

	public const double EPOCH_JAN1_12H_2000 = 2451545.0;

	static SxPxConstants()
	{
		Class72.smethod_20();
	}
}
