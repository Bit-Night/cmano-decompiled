using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Geodesic_Vincenty
{
	public struct TEllipsoid
	{
		public string Name;

		public double a;

		public double RFLAT;
	}

	public struct TCoord
	{
		public double Lat;

		public double Lon;

		public TCoord(double theLat, double theLon)
		{
			this = default(TCoord);
			Lat = theLat;
			Lon = theLon;
		}

		static TCoord()
		{
			Class72.smethod_20();
		}
	}

	public struct PointD
	{
		public double X;

		public double Y;

		public PointD(double X, double Y)
		{
			this = default(PointD);
			this.X = X;
			this.Y = Y;
		}

		static PointD()
		{
			Class72.smethod_20();
		}
	}

	public sealed class TLocalTM
	{
		protected double OriginLatR;

		protected double OriginLongR;

		protected double _OriginLat;

		protected double _OriginLong;

		protected double _FalseNorthing;

		protected double _FalseEasting;

		protected double _DeltaEasting;

		protected double _DeltaNorthing;

		protected double _ScaleFactor;

		protected double _ap;

		protected double _bp;

		protected double _cp;

		protected double _dp;

		protected double _ep;

		protected double _Es;

		protected double _Ebs;

		protected double _a;

		protected double _f;

		protected double _b;

		public TCoord Origin
		{
			get
			{
				return new TCoord
				{
					Lat = _OriginLat,
					Lon = _OriginLong
				};
			}
			set
			{
				if (value.Lat != _OriginLat)
				{
				}
			}
		}

		public double OriginLat => _OriginLat;

		public double OriginLong => _OriginLong;

		protected void Init(double OriginLat, double OriginLong)
		{
			_b = _a * (1.0 - _f);
			double Y = default(double);
			if (method_0(5156.620156177406, 90.0, ref _DeltaEasting, ref _DeltaNorthing, Allow_DEG_MAX_DELTA_LONG: false) && method_0(0.0, 90.0, ref _DeltaEasting, ref Y, Allow_DEG_MAX_DELTA_LONG: false))
			{
				_OriginLat = OriginLat;
				OriginLatR = OriginLat * 0.0174532925199433;
				double num = AdjustAngle(OriginLong);
				OriginLongR = num * 0.0174532925199433;
				_OriginLong = num;
			}
		}

		public TLocalTM()
		{
			OriginLatR = 0.0;
			OriginLongR = 0.0;
			_OriginLat = 0.0;
			_OriginLong = 0.0;
			_FalseNorthing = 0.0;
			_FalseEasting = 0.0;
			_ScaleFactor = 1.0;
			_ap = 6367449.1458008;
			_bp = 16038.508696861;
			_cp = 16.832613334334;
			_dp = 0.021984404273757;
			_ep = 3.1148371319283E-05;
			_Es = 0.00669437999014138;
			_Ebs = 0.0067394967565869;
			_a = 6378137.0;
			_f = 0.0033528106647474805;
			Init(0.0, 0.0);
		}

		public TLocalTM(double OriginLat, double OriginLong)
		{
			OriginLatR = 0.0;
			OriginLongR = 0.0;
			_OriginLat = 0.0;
			_OriginLong = 0.0;
			_FalseNorthing = 0.0;
			_FalseEasting = 0.0;
			_ScaleFactor = 1.0;
			_ap = 6367449.1458008;
			_bp = 16038.508696861;
			_cp = 16.832613334334;
			_dp = 0.021984404273757;
			_ep = 3.1148371319283E-05;
			_Es = 0.00669437999014138;
			_Ebs = 0.0067394967565869;
			_a = 6378137.0;
			_f = 0.0033528106647474805;
			Init(OriginLat, OriginLong);
		}

		public TLocalTM(TCoord Origin)
		{
			OriginLatR = 0.0;
			OriginLongR = 0.0;
			_OriginLat = 0.0;
			_OriginLong = 0.0;
			_FalseNorthing = 0.0;
			_FalseEasting = 0.0;
			_ScaleFactor = 1.0;
			_ap = 6367449.1458008;
			_bp = 16038.508696861;
			_cp = 16.832613334334;
			_dp = 0.021984404273757;
			_ep = 3.1148371319283E-05;
			_Es = 0.00669437999014138;
			_Ebs = 0.0067394967565869;
			_a = 6378137.0;
			_f = 0.0033528106647474805;
			Init(Origin.Lat, Origin.Lon);
		}

		public TLocalTM(PointF Origin)
		{
			OriginLatR = 0.0;
			OriginLongR = 0.0;
			_OriginLat = 0.0;
			_OriginLong = 0.0;
			_FalseNorthing = 0.0;
			_FalseEasting = 0.0;
			_ScaleFactor = 1.0;
			_ap = 6367449.1458008;
			_bp = 16038.508696861;
			_cp = 16.832613334334;
			_dp = 0.021984404273757;
			_ep = 3.1148371319283E-05;
			_Es = 0.00669437999014138;
			_Ebs = 0.0067394967565869;
			_a = 6378137.0;
			_f = 0.0033528106647474805;
			Init(Origin.Y, Origin.X);
		}

		public TLocalTM(ref PointD Origin)
		{
			OriginLatR = 0.0;
			OriginLongR = 0.0;
			_OriginLat = 0.0;
			_OriginLong = 0.0;
			_FalseNorthing = 0.0;
			_FalseEasting = 0.0;
			_ScaleFactor = 1.0;
			_ap = 6367449.1458008;
			_bp = 16038.508696861;
			_cp = 16.832613334334;
			_dp = 0.021984404273757;
			_ep = 3.1148371319283E-05;
			_Es = 0.00669437999014138;
			_Ebs = 0.0067394967565869;
			_a = 6378137.0;
			_f = 0.0033528106647474805;
			Init(Origin.Y, Origin.X);
		}

		internal bool method_0(double LatitudeD, double LongitudeD, ref double X, ref double Y, bool Allow_DEG_MAX_DELTA_LONG)
		{
			int num = 0;
			double num2 = LatitudeD;
			if (Math.Abs(num2) > 89.99999999999999)
			{
				num2 = ((!(num2 > 0.0)) ? (-89.99999999999999) : 89.99999999999999);
			}
			double num3 = num2 * 0.0174532925199433;
			if (num2 < -89.99999999999999 || num2 > 89.99999999999999)
			{
				num++;
			}
			while (LongitudeD > 180.0 || LongitudeD < -180.0)
			{
				LongitudeD = Math2.NormalizeLongitude(LongitudeD);
			}
			double num4 = LongitudeD * 0.0174532925199433;
			if (num4 > 3.14159265358979)
			{
				num4 -= 6.28318530717958;
			}
			if (num4 < OriginLongR - 1.570796326794897 || num4 > OriginLongR + 1.570796326794897)
			{
				double num5 = ((!(num4 < 0.0)) ? num4 : (num4 + 6.28318530717958));
				double num6 = ((!(OriginLongR < 0.0)) ? OriginLongR : (OriginLongR + 6.28318530717958));
				if (Allow_DEG_MAX_DELTA_LONG)
				{
					double num7 = 3.141592653589794;
					if (num5 < num6 - num7 || num5 > num6 + num7)
					{
						num += 2;
					}
				}
				else if (num5 < num6 - 1.570796326794897 || num5 > num6 + 1.570796326794897)
				{
					num += 2;
				}
			}
			if (num == 0)
			{
				double num8 = num4 - OriginLongR;
				if (Math.Abs(num8) > 0.15707963267948968)
				{
					num += 512;
				}
				if (num8 > 3.14159265358979)
				{
					num8 -= 6.28318530717958;
				}
				if (num8 < -3.14159265358979)
				{
					num8 += 6.28318530717958;
				}
				if (Math.Abs(num8) < 1E-60)
				{
					num8 = 0.0;
				}
				double num9 = Math.Sin(num3);
				double num10 = Math.Cos(num3);
				double num11 = num10 * num10;
				double num12 = num11 * num10;
				double num13 = num12 * num11;
				double num14 = num13 * num11;
				double num15 = Math.Tan(num3);
				double num16 = num15 * num15;
				double num17 = num16 * num15 * num15;
				double num18 = num17 * num15 * num15;
				double num19 = _Ebs * num11;
				double num20 = num19 * num19;
				double num21 = num20 * num19;
				double num22 = num21 * num19;
				double num23 = SPHSN(num3);
				double num24 = SPHTMD(num3);
				double num25 = SPHTMD(OriginLatR);
				double num26 = (num24 - num25) * _ScaleFactor;
				double num27 = num23 * num9 * num10 * _ScaleFactor / 2.0;
				double num28 = num23 * num9 * num12 * _ScaleFactor * (5.0 - num16 + 9.0 * num19 + 4.0 * num20) / 24.0;
				double num29 = num23 * num9 * num13 * _ScaleFactor * (61.0 - 58.0 * num16 + num17 + 270.0 * num19 - 330.0 * num16 * num19 + 445.0 * num20 + 324.0 * num21 - 680.0 * num16 * num20 + 88.0 * num22 - 600.0 * num16 * num21 - 192.0 * num16 * num22) / 720.0;
				double num30 = num23 * num9 * num14 * _ScaleFactor * (1385.0 - 3111.0 * num16 + 543.0 * num17 - num18) / 40320.0;
				double num31 = num8 * num8;
				double num32 = num31 * num8;
				double num33 = num31 * num31;
				double num34 = num33 * num8;
				double num35 = num33 * num31;
				double num36 = num35 * num8;
				double num37 = num33 * num33;
				Y = _FalseNorthing + num26 + num31 * num27 + num33 * num28 + num35 * num29 + num37 * num30;
				double num38 = num23 * num10 * _ScaleFactor;
				double num39 = num23 * num12 * _ScaleFactor * (1.0 - num16 + num19) / 6.0;
				double num40 = num23 * num13 * _ScaleFactor * (5.0 - 18.0 * num16 + num17 + 14.0 * num19 - 58.0 * num16 * num19 + 13.0 * num20 + 4.0 * num21 - 64.0 * num16 * num20 - 24.0 * num16 * num21) / 120.0;
				double num41 = num23 * num14 * _ScaleFactor * (61.0 - 479.0 * num16 + 179.0 * num17 - num18) / 5040.0;
				X = _FalseEasting + num8 * num38 + num32 * num39 + num34 * num40 + num36 * num41;
				return true;
			}
			return false;
		}

		protected double SPHSR(double LatitudeR)
		{
			double num = DENOM(LatitudeR);
			return _a * (1.0 - _Es) / (num * num * num);
		}

		protected double DENOM(double LatitudeR)
		{
			double num = Math.Sin(LatitudeR);
			return Math.Sqrt(1.0 - _Es * (num * num));
		}

		protected double SPHSN(double LatitudeR)
		{
			double num = Math.Sin(LatitudeR);
			return _a / Math.Sqrt(1.0 - _Es * (num * num));
		}

		protected double SPHTMD(double LatitudeR)
		{
			return _ap * LatitudeR - _bp * Math.Sin(2.0 * LatitudeR) + _cp * Math.Sin(4.0 * LatitudeR) - _dp * Math.Sin(6.0 * LatitudeR) + _ep * Math.Sin(8.0 * LatitudeR);
		}

		internal bool method_1(double X, double Y, ref double LatitudeD, ref double LongitudeD)
		{
			int num = 0;
			if ((X < _FalseEasting - _DeltaEasting) | (X > _FalseEasting + _DeltaEasting))
			{
				num += 4;
			}
			if ((Y < _FalseNorthing - _DeltaNorthing) | (Y > _FalseNorthing + _DeltaNorthing))
			{
				num += 8;
			}
			if (num == 0)
			{
				double num2 = _ap * OriginLatR - _bp * Math.Sin(2.0 * OriginLatR) + _cp * Math.Sin(4.0 * OriginLatR) - _dp * Math.Sin(6.0 * OriginLatR) + _ep * Math.Sin(8.0 * OriginLatR) + (Y - _FalseNorthing) / _ScaleFactor;
				double num3 = SPHSR(0.0);
				double num4 = num2 / num3;
				int num5 = 0;
				double num6;
				do
				{
					num6 = SPHTMD(num4);
					num3 = SPHSR(num4);
					num4 += (num2 - num6) / num3;
					num5++;
				}
				while (num5 <= 4);
				num3 = SPHSR(num4);
				double num7 = SPHSN(num4);
				Math.Sin(num4);
				double num8 = Math.Cos(num4);
				double num9 = Math.Tan(num4);
				double num10 = num9 * num9;
				double num11 = num10 * num10;
				double num12 = num11 * num10;
				double num13 = _Ebs * (num8 * num8);
				double num14 = num13 * num13;
				double num15 = num14 * num13;
				double num16 = num15 * num13;
				double num17 = X - _FalseEasting;
				if (Math.Abs(num17) < 0.0001)
				{
					num17 = 0.0;
				}
				double num18 = _ScaleFactor * _ScaleFactor;
				double num19 = num18 * _ScaleFactor;
				double num20 = num18 * num18;
				double num21 = num20 * _ScaleFactor;
				double num22 = num20 * num18;
				double num23 = num22 * _ScaleFactor;
				double num24 = num20 * num20;
				double num25 = num7 * num7;
				double num26 = num25 * num7;
				double num27 = num26 * num25;
				double num28 = num27 * num25;
				double num29 = num17 * num17;
				double num30 = num29 * num17;
				double num31 = num29 * num29;
				double num32 = num31 * num17;
				double num33 = num31 * num29;
				double num34 = num33 * num17;
				double num35 = num31 * num31;
				num6 = num9 / (2.0 * num3 * num7 * num18);
				double num36 = num9 * (5.0 + 3.0 * num10 + num13 - 4.0 * num14 - 9.0 * num10 * num13) / (24.0 * num3 * num26 * num20);
				double num37 = num9 * (61.0 + 90.0 * num10 + 46.0 * num13 + 45.0 * num11 - 252.0 * num10 * num13 - 3.0 * num14 + 100.0 * num15 - 66.0 * num10 * num14 - 90.0 * num11 * num13 + 88.0 * num16 + 225.0 * num11 * num14 + 84.0 * num10 * num15 - 192.0 * num10 * num16) / (720.0 * num3 * num27 * num22);
				double num38 = num9 * (1385.0 + 3633.0 * num10 + 4095.0 * num11 + 1575.0 * num12) / (40320.0 * num3 * num28 * num24);
				double num39 = num4 - num29 * num6 + num31 * num36 - num33 * num37 + num35 * num38;
				double num40 = 1.0 / (num7 * num8 * _ScaleFactor);
				double num41 = (1.0 + 2.0 * num10 + num13) / (6.0 * num26 * num8 * num19);
				double num42 = (5.0 + 6.0 * num13 + 28.0 * num10 - 3.0 * num14 + 8.0 * num10 * num13 + 24.0 * num11 - 4.0 * num15 + 4.0 * num10 * num14 + 24.0 * num10 * num15) / (120.0 * num27 * num8 * num21);
				double num43 = (61.0 + 662.0 * num10 + 1320.0 * num11 + 720.0 * num12) / (5040.0 * num28 * num8 * num23);
				double num44 = num17 * num40 - num30 * num41 + num32 * num42 - num34 * num43;
				double angle = OriginLongR + num44;
				if (Math.Abs(num39) > 1.570796326794897)
				{
					num += 8;
				}
				if (Math.Abs(num44) > 0.15707963267948968 * Math.Cos(num39 * 0.0174532925199433))
				{
					num += 512;
				}
				if (num39 > 10000000000.0)
				{
					num += 512;
				}
				LatitudeD = num39 * 57.2957795130823;
				LongitudeD = AdjustAngle(angle) * 57.2957795130823;
				return true;
			}
			return false;
		}

		public void ReprojectToTargetTM(ref TLocalTM Tgt, double X, double Y, ref double X_N, ref double Y_N)
		{
			double LatitudeD = default(double);
			double LongitudeD = default(double);
			if (method_1(X, Y, ref LatitudeD, ref LongitudeD))
			{
				Tgt.method_0(LatitudeD, LongitudeD, ref X_N, ref Y_N, Allow_DEG_MAX_DELTA_LONG: false);
			}
		}

		public PointD ReprojectToTargetTM(ref TLocalTM Tgt, ref PointD OldCoord)
		{
			PointD GeoCoord = method_3(ref OldCoord);
			return Tgt.method_5(ref GeoCoord);
		}

		internal PointF method_2(PointF TMCoord)
		{
			double LatitudeD = default(double);
			double LongitudeD = default(double);
			return method_1(TMCoord.X, TMCoord.Y, ref LatitudeD, ref LongitudeD) ? new PointF((float)LongitudeD, (float)LatitudeD) : default(PointF);
		}

		public PointD method_3(ref PointD TMCoord)
		{
			double LatitudeD = default(double);
			double LongitudeD = default(double);
			return method_1(TMCoord.X, TMCoord.Y, ref LatitudeD, ref LongitudeD) ? new PointD(LongitudeD, LatitudeD) : default(PointD);
		}

		internal TCoord TM2GeodeticEx(ref PointD TMCoord)
		{
			double LatitudeD = default(double);
			double LongitudeD = default(double);
			if (!method_1(TMCoord.X, TMCoord.Y, ref LatitudeD, ref LongitudeD))
			{
				return default(TCoord);
			}
			return new TCoord
			{
				Lat = LatitudeD,
				Lon = LongitudeD
			};
		}

		internal PointF method_4(PointF GeoCoord)
		{
			double X = default(double);
			double Y = default(double);
			return method_0(GeoCoord.Y, GeoCoord.X, ref X, ref Y, Allow_DEG_MAX_DELTA_LONG: false) ? new PointF((float)X, (float)Y) : default(PointF);
		}

		public PointD method_5(ref PointD GeoCoord, bool Allow_DEG_MAX_DELTA_LONG = false)
		{
			double X = default(double);
			double Y = default(double);
			return (!method_0(GeoCoord.Y, GeoCoord.X, ref X, ref Y, Allow_DEG_MAX_DELTA_LONG)) ? default(PointD) : new PointD(X, Y);
		}

		public PointD method_6(ref double GeoCoordX_Lon, ref double GeoCoordY_Lat, bool Allow_DEG_MAX_DELTA_LONG = false)
		{
			double X = default(double);
			double Y = default(double);
			return method_0(GeoCoordY_Lat, GeoCoordX_Lon, ref X, ref Y, Allow_DEG_MAX_DELTA_LONG) ? new PointD(X, Y) : default(PointD);
		}

		internal PointD Geodetic2TMEx(TCoord GeoCoord)
		{
			double X = default(double);
			double Y = default(double);
			return (!method_0(GeoCoord.Lat, GeoCoord.Lon, ref X, ref Y, Allow_DEG_MAX_DELTA_LONG: false)) ? default(PointD) : new PointD(X, Y);
		}

		static TLocalTM()
		{
			Class72.smethod_20();
		}
	}

	public struct Point3D
	{
		public double X;

		public double Y;

		public double Z;

		public Point3D(double X, double Y, double Z)
		{
			this = default(Point3D);
			this.X = X;
			this.Y = Y;
			this.Z = Z;
		}

		public static Point3D operator -(Point3D LHS, Point3D RHS)
		{
			return new Point3D
			{
				X = LHS.X - RHS.X,
				Y = LHS.Y - RHS.Y,
				Z = LHS.Z - RHS.Z
			};
		}

		public static Point3D operator +(Point3D LHS, Point3D RHS)
		{
			return new Point3D
			{
				X = LHS.X + RHS.X,
				Y = LHS.Y + RHS.Y,
				Z = LHS.Z + RHS.Z
			};
		}

		public static double operator *(Point3D LHS, Point3D RHS)
		{
			return LHS.X * RHS.X + LHS.Y * RHS.Y + LHS.Z * RHS.Z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Point3D operator *(Point3D LHS, double multiplier)
		{
			return new Point3D(LHS.X * multiplier, LHS.Y * multiplier, LHS.Z * multiplier);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Point3D operator /(Point3D LHS, double divisor)
		{
			return new Point3D(LHS.X / divisor, LHS.Y / divisor, LHS.Z / divisor);
		}

		public static Point3D operator *(double LHS, Point3D RHS)
		{
			return new Point3D
			{
				X = LHS * RHS.X,
				Y = LHS * RHS.Y,
				Z = LHS * RHS.Z
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Dot(Point3D LHS, Point3D RHS)
		{
			return LHS.X * RHS.X + LHS.Y * RHS.Y + LHS.Z * RHS.Z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Point3D Cross(Point3D LHS, Point3D RHS)
		{
			return new Point3D(LHS.Y * RHS.Z - LHS.Z * RHS.Y, LHS.Z * RHS.X - LHS.X * RHS.Z, LHS.X * RHS.Y - LHS.Y * RHS.X);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal double Length()
		{
			return Math.Sqrt(X * X + Y * Y + Z * Z);
		}

		static Point3D()
		{
			Class72.smethod_20();
		}
	}

	public struct TAzElRange
	{
		public double Elevation;

		public double Azimouth;

		public double RangeKM;

		public double RangeNM
		{
			get
			{
				return RangeKM * 1000.0 / 1852.0;
			}
			set
			{
				RangeKM = value * 1852.0 / 1000.0;
			}
		}

		static TAzElRange()
		{
			Class72.smethod_20();
		}
	}

	public delegate void ForwardGeoSolution(double Coord1_A, double Coord2_A, ref double Coord1_B, ref double Coord2_B, double AzimouthAB_Degrees, double DistanceAB);

	public delegate void InverseGeoSolution(double Coord1_A, double Coord2_A, double Coord1_B, double Coord2_B, ref double AzimouthAB_Degrees, ref double AzimouthBA_Degrees, ref double DistanceAB);

	private delegate double Delegate2(double x, double[] @params);

	public const double DTOL = 1E-12;

	public const double NEW_DTOL = 1E-10;

	public const double WGS84_A = 6378137.0;

	public const double WGS84_RFLAT = 298.257223563;

	public const string ModuleVersion = "Version 3.22";

	public const string ModuleCredits = "Credits: T.Vincenty, \r\n'Direct and inverse solutions of geodesics of nested equations'. \r\nSurvey Review XXII, 176, April 1975. Pp.88-93.\r\nP.S.Zakatov. Kurs vysshei geodezii. 4th ed. M., 1976.\r\nU.S. Army Topographic Engineering Center, Geospatial Information Division 7701 Telegraph Road Alexandria, VA  22310-3864 - for TransMerc code\r\nGerald Evenden (proj code) and Frank Warmerdam (proj copyright holder)\r\nParts of code: (C) Dimitris V. Dranidis, 2009\r\nBrent minimization routine: AlgLib, (C) Bochkanov Sergey 09.04.2007";

	public const int TRANMERC_NO_ERROR = 0;

	public const int TRANMERC_LAT_ERROR = 1;

	public const int TRANMERC_LON_ERROR = 2;

	public const int TRANMERC_EASTING_ERROR = 4;

	public const int TRANMERC_NORTHING_ERROR = 8;

	public const int TRANMERC_ORIGIN_LAT_ERROR = 16;

	public const int TRANMERC_CENT_MER_ERROR = 32;

	public const int TRANMERC_A_ERROR = 64;

	public const int TRANMERC_INV_F_ERROR = 128;

	public const int TRANMERC_SCALE_FACTOR_ERROR = 256;

	public const int TRANMERC_LON_WARNING = 512;

	public const int STEREO_NO_ERROR = 0;

	public const int STEREO_LAT_ERROR = 1;

	public const int STEREO_LON_ERROR = 2;

	public const int STEREO_ORIGIN_LAT_ERROR = 4;

	public const int STEREO_CENT_MER_ERROR = 8;

	public const int STEREO_EASTING_ERROR = 16;

	public const int STEREO_NORTHING_ERROR = 32;

	public const int STEREO_A_ERROR = 64;

	public const int STEREO_INV_F_ERROR = 128;

	public static PointF CPointF(ref PointD V)
	{
		return new PointF((float)V.X, (float)V.Y);
	}

	internal static PointD CPointD(PointF V)
	{
		return new PointD(V.X, V.Y);
	}

	public static void VelToVector(double Velocity, double Heading, ref double Vx, ref double Vy)
	{
		Vx = Velocity * (463.0 / 900.0) * Math.Sin(Heading * 0.0174532925199433);
		Vy = Velocity * (463.0 / 900.0) * Math.Cos(Heading * 0.0174532925199433);
	}

	internal static double ClosureRate(double _Lat1, double _Lon1, double _Velocity1, double _Course1, double _Lat2, double _Lon2, double _Velocity2, double _Course2)
	{
		TLocalTM tLocalTM = new TLocalTM(_Lat1, _Lon1);
		double num = 0.0;
		double num2 = 0.0;
		double X = default(double);
		double Y = default(double);
		if (tLocalTM.method_0(_Lat2, _Lon2, ref X, ref Y, Allow_DEG_MAX_DELTA_LONG: false))
		{
			double num3 = num - X;
			double num4 = num2 - Y;
			double Vx = default(double);
			double Vy = default(double);
			VelToVector(_Velocity1, _Course1, ref Vx, ref Vy);
			double Vx2 = default(double);
			double Vy2 = default(double);
			VelToVector(_Velocity2, _Course2, ref Vx2, ref Vy2);
			double num5 = Vx - Vx2;
			double num6 = Vy - Vy2;
			double num7 = ((!(num3 == 0.0 && num4 == 0.0)) ? ((0.0 - (num3 * num5 + num4 * num6)) / Math.Sqrt(num3 * num3 + num4 * num4)) : (0.0 - Math.Sqrt(num5 * num5 + num6 * num6)));
			return num7 * 3600.0 / 1852.0;
		}
		return 0.0;
	}

	public static double arccos2(double x, double y)
	{
		if (x != 0.0 && y != 0.0)
		{
			if (!(y <= 0.0))
			{
				return Math.Acos(x / y);
			}
			if (y < 0.0)
			{
				return 3.14159265358979 + Math.Acos(x / y);
			}
		}
		return 0.0;
	}

	internal static Point3D ApproxSphericalToCartesian(double Latitude, double Longitude, double AltitudeM)
	{
		Point3D result = default(Point3D);
		double num = Longitude * 0.0174532925199433;
		double num2 = Latitude * 0.0174532925199433;
		double num3 = AltitudeM + 6371000.0;
		double num4 = num3 * Math.Cos(num2);
		result.X = num4 * Math.Cos(num);
		result.Y = num4 * Math.Sin(num);
		result.Z = num3 * Math.Sin(num2);
		return result;
	}

	public static void ApproxSphericalToCartesian(double Latitude, double Longitude, double AltitudeM, ref double X, ref double Y, ref double Z)
	{
		double num = AltitudeM + 6371000.0;
		double num2 = num * Math.Cos(Latitude * 0.0174532925199433);
		X = num2 * Math.Cos(Longitude * 0.0174532925199433);
		Y = num2 * Math.Sin(Longitude * 0.0174532925199433);
		Z = num * Math.Sin(Latitude * 0.0174532925199433);
	}

	public static void ApproxCartesianToSpherical(double X, double Y, double Z, ref double Lat, ref double Lon, ref double Alt)
	{
		double num = Math.Sqrt(X * X + Y * Y + Z * Z);
		Lon = Math.Atan2(Y, X) * 57.2957795130823;
		Lat = Math.Asin(Z / num) * 57.2957795130823;
		Alt = num - 6371000.0;
	}

	public static void PartitionArc(double Lat, double Lon, double RadiusNM, double CenterHeading, double AngleSpread, int NumPoints, ref Point3D[] ZonePoints)
	{
		double num = AdjustAngle(CenterHeading) - AngleSpread / 2.0;
		double num2 = Lat * 0.0174532925199433;
		double num3 = Lon * 0.0174532925199433;
		double num4 = RadiusNM * 1852.0 / 1000.0 / 6371.0;
		ZonePoints = new Point3D[NumPoints - 1 + 1];
		double num5 = AngleSpread / (double)(NumPoints - 1);
		int num6 = NumPoints - 1;
		for (int i = 0; i <= num6; i++)
		{
			double num7 = num + (double)i * num5;
			double d = num7 * 0.0174532925199433;
			double num8 = Math.Asin(Math.Sin(num2) * Math.Cos(num4) + Math.Cos(d) * Math.Sin(num4) * Math.Cos(num2));
			double num9 = Math.Cos(num4) - Math.Sin(num2) * Math.Sin(num8);
			double num10 = Math.Cos(num2) * Math.Cos(num8);
			double num11;
			for (num11 = ((Math.Abs(num7) < 0.001 && num4 > 1.5707963267949 - num2) ? (num3 + 3.14159265358979) : ((Math.Abs(num7 - 180.0) < 0.001 && num4 > 1.5707963267949 + num2) ? (num3 + 3.14159265358979) : ((Math.Abs(num9 / num10) > 1.0) ? num3 : ((!(180.0 - num7 >= 0.0)) ? (num3 + arccos2(num9, num10)) : (num3 - arccos2(num9, num10)))))); num11 < -3.14159265358979; num11 += 6.28318530717959)
			{
			}
			while (num11 > 3.14159265358979)
			{
				num11 -= 6.28318530717959;
			}
			ZonePoints[i].Y = (float)(num8 * 57.2957795130823);
			ZonePoints[i].X = (float)(num11 * 57.2957795130823);
		}
	}

	public static void PartitionCircle(double Lat, double Lon, double RadiusNM, int NumPoints, ref Point3D[] ZonePoints)
	{
		double num = Lat * 0.0174532925199433;
		double num2 = Lon * 0.0174532925199433;
		double num3 = RadiusNM * 1852.0 / 1000.0 / 6371.0;
		ZonePoints = new Point3D[NumPoints + 1];
		double num4 = 360.0 / (double)NumPoints;
		int num5 = NumPoints - 1;
		for (int i = 0; i <= num5; i++)
		{
			double num6 = (double)i * num4;
			double d = num6 * 0.0174532925199433;
			double num7 = Math.Asin(Math.Sin(num) * Math.Cos(num3) + Math.Cos(d) * Math.Sin(num3) * Math.Cos(num));
			double num8 = Math.Cos(num3) - Math.Sin(num) * Math.Sin(num7);
			double num9 = Math.Cos(num) * Math.Cos(num7);
			double num10;
			for (num10 = ((num6 == 0.0 && num3 > 1.5707963267949 - num) ? (num2 + 3.14159265358979) : ((num6 == 180.0 && num3 > 1.5707963267949 + num) ? (num2 + 3.14159265358979) : ((!(Math.Abs(num8 / num9) <= 1.0)) ? num2 : ((!(180.0 - num6 >= 0.0)) ? (num2 + arccos2(num8, num9)) : (num2 - arccos2(num8, num9)))))); num10 < -3.14159265358979; num10 += 6.28318530717959)
			{
			}
			while (num10 > 3.14159265358979)
			{
				num10 -= 6.28318530717959;
			}
			ZonePoints[i].Y = (float)(num7 * 57.2957795130823);
			ZonePoints[i].X = (float)(num10 * 57.2957795130823);
		}
		ZonePoints[NumPoints] = ZonePoints[0];
	}

	internal static GraphicsPath CircleZone(double Lat, double Lon, double RadiusNM, int NumPoints)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		GraphicsPath val = new GraphicsPath();
		double num = Lat * 0.0174532925199433;
		double num2 = Lon * 0.0174532925199433;
		double num3 = RadiusNM * 1852.0 / 1000.0 / 6371.0;
		PointF[] array = new PointF[NumPoints + 1];
		double num4 = 360.0 / (double)NumPoints;
		int num5 = NumPoints - 1;
		for (int i = 0; i <= num5; i++)
		{
			double num6 = (double)i * num4;
			double d = num6 * 0.0174532925199433;
			double num7 = Math.Asin(Math.Sin(num) * Math.Cos(num3) + Math.Cos(d) * Math.Sin(num3) * Math.Cos(num));
			double num8 = Math.Cos(num3) - Math.Sin(num) * Math.Sin(num7);
			double num9 = Math.Cos(num) * Math.Cos(num7);
			double num10;
			for (num10 = ((num6 == 0.0 && num3 > 1.5707963267949 - num) ? (num2 + 3.14159265358979) : ((num6 == 180.0 && num3 > 1.5707963267949 + num) ? (num2 + 3.14159265358979) : ((Math.Abs(num8 / num9) > 1.0) ? num2 : ((!(180.0 - num6 >= 0.0)) ? (num2 + arccos2(num8, num9)) : (num2 - arccos2(num8, num9)))))); num10 < -3.14159265358979; num10 += 6.28318530717959)
			{
			}
			while (num10 > 3.14159265358979)
			{
				num10 -= 6.28318530717959;
			}
			array[i].Y = (float)(num7 * 57.2957795130823);
			array[i].X = (float)(num10 * 57.2957795130823);
		}
		array[NumPoints] = array[0];
		val.AddLines(array);
		return val;
	}

	public static void GenericCoverageZone(double SatLat, double SatLon, double SatAltKm, int NumPoints, ref Point3D[] ZonePoints)
	{
		double num = SatLat * 0.0174532925199433;
		double num2 = SatLon * 0.0174532925199433;
		double num3 = 12742.0 * Math.Acos(6371.0 / (6371.0 + SatAltKm));
		double num4 = 0.5 * num3 / 6371.0;
		ZonePoints = new Point3D[NumPoints - 1 + 1];
		double num5 = 360.0 / (double)NumPoints;
		int num6 = NumPoints - 1;
		for (int i = 0; i <= num6; i++)
		{
			double num7 = (double)i * num5;
			double d = num7 * 0.0174532925199433;
			double num8 = Math.Asin(Math.Sin(num) * Math.Cos(num4) + Math.Cos(d) * Math.Sin(num4) * Math.Cos(num));
			double num9 = Math.Cos(num4) - Math.Sin(num) * Math.Sin(num8);
			double num10 = Math.Cos(num) * Math.Cos(num8);
			double num11;
			for (num11 = ((num7 == 0.0 && num4 > 1.5707963267949 - num) ? (num2 + 3.14159265358979) : ((num7 == 180.0 && num4 > 1.5707963267949 + num) ? (num2 + 3.14159265358979) : ((Math.Abs(num9 / num10) > 1.0) ? num2 : ((!(180.0 - num7 >= 0.0)) ? (num2 + arccos2(num9, num10)) : (num2 - arccos2(num9, num10)))))); num11 < -3.14159265358979; num11 += 6.28318530717959)
			{
			}
			while (num11 > 3.14159265358979)
			{
				num11 -= 6.28318530717959;
			}
			ZonePoints[i].Y = num8 * 57.2957795130823;
			ZonePoints[i].X = num11 * 57.2957795130823;
		}
	}

	internal static double ApproxElevation(double ObserverLat, double ObserverLon, double ObserverAltM, double TgtLat, double TgtLon, double TgtAltM)
	{
		double num = 6371000.0;
		Point3D point3D = ApproxSphericalToCartesian(TgtLat, TgtLon, TgtAltM);
		Point3D point3D2 = ApproxSphericalToCartesian(ObserverLat, ObserverLon, ObserverAltM);
		Point3D rHS = point3D - point3D2;
		double d = Point3D.Dot(point3D, point3D2) / ((TgtAltM + num) * (ObserverAltM + num));
		double d2 = Point3D.Dot(point3D, rHS) / ((TgtAltM + num) * rHS.Length());
		return 90.0 - (Math.Acos(d) + Math.Acos(d2)) * 57.2957795130823;
	}

	public static void ApproxElevationRange(double ObserverLat, double ObserverLon, double ObserverAltM, double TgtLat, double TgtLon, double TgtAltM, ref double Elevation, ref double RangeKm)
	{
		double num = 6371000.0;
		Point3D point3D = ApproxSphericalToCartesian(TgtLat, TgtLon, TgtAltM);
		Point3D point3D2 = ApproxSphericalToCartesian(ObserverLat, ObserverLon, ObserverAltM);
		Point3D rHS = point3D - point3D2;
		double d = Point3D.Dot(point3D, point3D2) / ((TgtAltM + num) * (ObserverAltM + num));
		double num2 = rHS.Length();
		double d2 = Point3D.Dot(point3D, rHS) / ((TgtAltM + num) * num2);
		RangeKm = num2 / 1000.0;
		Elevation = 90.0 - (Math.Acos(d) + Math.Acos(d2)) * 57.2957795130823;
	}

	internal static double adjlon(double Lon)
	{
		if (Math.Abs(Lon) <= 3.14159265359)
		{
			return Lon;
		}
		Lon += 3.14159265358979;
		Lon -= 6.28318530717959 * Math.Floor(Lon / 6.28318530717959);
		Lon -= 3.14159265358979;
		return Lon;
	}

	internal static double AdjustAngle(double Angle)
	{
		double num = Angle;
		if (Math.Abs(Angle) <= 180.0)
		{
			return Angle;
		}
		num += 180.0;
		num -= 360.0 * Math.Floor(num / 360.0);
		return num - 180.0;
	}

	public static void fw_geod_wgs84_2(double Lat1, double Lon1, ref double Lat2, ref double Lon2, double al12, double dist)
	{
		TCoord Pt = default(TCoord);
		Pt.Lat = Lat1;
		Pt.Lon = Lon1;
		TCoord Ret = default(TCoord);
		fw_geod_wgs84(ref Pt, ref Ret, al12, dist);
		Lat2 = Ret.Lat;
		Lon2 = Ret.Lon;
	}

	public static void fw_vincenty_wgs84_2(double Lat1, double Lon1, ref double Lat2, ref double Lon2, double al12, double dist)
	{
		fw_vincenty_wgs84(Lat1, Lon1, ref Lat2, ref Lon2, al12, dist);
	}

	public static void smethod_0(ref double Lat, ref double Lon, ref double GCC_X, ref double GCC_Y, ref double GCC_Z)
	{
		double num = Math.Cos(Lat * 0.0174532925199433);
		double num2 = Math.Sin(Lat * 0.0174532925199433);
		double num3 = 40680631590769.0;
		double num4 = 40408299984661.445;
		double num5 = Math.Sqrt(num3 * num * num + num4 * num2 * num2);
		GCC_X = num3 * num * Math.Cos(Lon * 0.0174532925199433) / num5;
		GCC_Y = num3 * num * Math.Sin(Lon * 0.0174532925199433) / num5;
		GCC_Z = num4 * num2 / num5;
	}

	internal static Point3D smethod_1(TCoord C, double Alt = 0.0)
	{
		double num = Math.Cos(C.Lat * 0.0174532925199433);
		double num2 = Math.Sin(C.Lat * 0.0174532925199433);
		double num3 = 40680631590769.0;
		double num4 = 40408299984661.445;
		double num5 = Math.Sqrt(num3 * num * num + num4 * num2 * num2);
		return new Point3D
		{
			X = num3 * num * Math.Cos(C.Lon * 0.0174532925199433) / num5,
			Y = num3 * num * Math.Sin(C.Lon * 0.0174532925199433) / num5,
			Z = num4 * num2 / num5
		};
	}

	internal static double SlantRangeNM(TCoord C1, TCoord C2, double Alt1, double Alt2)
	{
		Point3D point3D = smethod_1(C1, Alt1);
		Point3D point3D2 = smethod_1(C2, Alt2);
		return Math.Sqrt((point3D.X - point3D2.X) * (point3D.X - point3D2.X) + (point3D.Y - point3D2.Y) * (point3D.Y - point3D2.Y) + (point3D.Z - point3D2.Z) * (point3D.Z - point3D2.Z)) / 1852.0;
	}

	internal static double SphericalRangeNM(ref double Lat1, ref double Lon1, ref double Lat2, ref double Lon2)
	{
		double GCC_X = default(double);
		double GCC_Y = default(double);
		double GCC_Z = default(double);
		smethod_0(ref Lat1, ref Lon1, ref GCC_X, ref GCC_Y, ref GCC_Z);
		double GCC_X2 = default(double);
		double GCC_Y2 = default(double);
		double GCC_Z2 = default(double);
		smethod_0(ref Lat2, ref Lon2, ref GCC_X2, ref GCC_Y2, ref GCC_Z2);
		return Math.Sqrt((GCC_X - GCC_X2) * (GCC_X - GCC_X2) + (GCC_Y - GCC_Y2) * (GCC_Y - GCC_Y2) + (GCC_Z - GCC_Z2) * (GCC_Z - GCC_Z2)) / 1852.0;
	}

	internal static double ApproxGrazingAngle(double GroundRangeNM, double SrcH, double TgtH)
	{
		double d = GroundRangeNM * 1852.0 / 6371000.0;
		double num = 6371000.0 + TgtH;
		double num2 = 6371000.0 + SrcH;
		double num3 = num * num;
		double num4 = num2 * num2;
		double num5 = Math.Sqrt(num3 + num4 - 2.0 * num * num2 * Math.Cos(d));
		return Math.Acos((num5 * num5 + num3 - num4) / (2.0 * num5 * num)) * 57.2957795130823 - 90.0;
	}

	public static void PartitionGeodesic(double Lat1, double Lon1, double Alt1, double Lat2, double Lon2, double Alt2, int NumSegments, ref Point3D[] AllPoints)
	{
		if (NumSegments == 0)
		{
			throw new Exception("zero numsegments");
		}
		if (Lat1 == Lat2 && Lon1 == Lon2 && Alt1 == Alt2)
		{
			AllPoints = new Point3D[1];
			AllPoints[0].X = Lon1;
			AllPoints[0].Y = Lat1;
			AllPoints[0].Z = Alt1;
			return;
		}
		double num = (Alt2 - Alt1) / (double)NumSegments;
		if (!(Lat1 == Lat2 && Lon1 == Lon2))
		{
			double al = default(double);
			double al2 = default(double);
			double dist = default(double);
			inv_vincenty_wgs84_2(Lat1, Lon1, Lat2, Lon2, ref al, ref al2, ref dist);
			double dist2 = dist / (double)NumSegments;
			AllPoints = new Point3D[NumSegments + 1];
			AllPoints[0].X = Lon1;
			AllPoints[0].Y = Lat1;
			AllPoints[0].Z = Alt1;
			int num2 = NumSegments - 1;
			double Lat3 = default(double);
			double Lon3 = default(double);
			for (int i = 1; i <= num2; i++)
			{
				fw_vincenty_wgs84(Lat1, Lon1, ref Lat3, ref Lon3, al, dist2);
				AllPoints[i].X = Lon3;
				AllPoints[i].Y = Lat3;
				AllPoints[i].Z = num * (double)i + Alt1;
				inv_vincenty_wgs84_2(Lat3, Lon3, Lat2, Lon2, ref al, ref al2, ref dist);
				dist2 = dist / (double)(NumSegments - i);
			}
			AllPoints[NumSegments].X = Lon2;
			AllPoints[NumSegments].Y = Lat2;
			AllPoints[NumSegments].Z = Alt2;
		}
		else
		{
			AllPoints = new Point3D[NumSegments + 1];
			AllPoints[0].X = Lon1;
			AllPoints[0].Y = Lat1;
			AllPoints[0].Z = Alt1;
			for (int i = 1; i <= NumSegments; i++)
			{
				AllPoints[i].X = Lon1;
				AllPoints[i].Y = Lat1;
				AllPoints[i].Z = num * (double)i + Alt1;
			}
		}
	}

	internal static double SphericalDistanceDegrees(double latA, double lonA, double latB, double lonB)
	{
		double num = latA * 0.0174532925199433;
		double num2 = latB * 0.0174532925199433;
		double num3 = lonA * 0.0174532925199433;
		double num4 = lonB * 0.0174532925199433;
		return Math.Acos(Math.Cos(num) * Math.Cos(num2) * Math.Cos(num3 - num4) + Math.Sin(num) * Math.Sin(num2)) * 57.2957795130823;
	}

	internal static double Cosec(double x)
	{
		return 1.0 / Math.Sin(x);
	}

	internal static double Sec(double x)
	{
		return 1.0 / Math.Cos(x);
	}

	public static void CircleFromPoint(double Lat, double Lon, double RadiusNM, int NumPoints, ref Point3D[] CirclePoints)
	{
		if (NumPoints >= 3)
		{
			double lon = AdjustAngle(Lon);
			CirclePoints = new Point3D[NumPoints - 1 + 1];
			double num = 0.0;
			double num2 = 360.0 / (double)NumPoints;
			int num3 = NumPoints - 1;
			for (int i = 0; i <= num3; i++)
			{
				CirclePoints[i].Z = 0.0;
				fw_vincenty_wgs84(Lat, lon, ref CirclePoints[i].Y, ref CirclePoints[i].X, num, RadiusNM);
				num += num2;
			}
			return;
		}
		throw new Exception("insufficient numpoints");
	}

	public static void PartitionGreatCircle(double Lat1, double Lon1, double Alt1, double Lat2, double Lon2, double Alt2, int NumSegments, ref Point3D[] AllPoints)
	{
		if (NumSegments != 0)
		{
			if (Lat1 == Lat2 && Lon1 == Lon2 && Alt1 == Alt2)
			{
				AllPoints = new Point3D[1];
				AllPoints[0].X = Lon1;
				AllPoints[0].Y = Lat1;
				AllPoints[0].Z = Alt1;
				return;
			}
			double num = (Alt2 - Alt1) / (double)NumSegments;
			if (!(Lat1 == Lat2 && Lon1 == Lon2))
			{
				double num2 = SphericalDistanceDegrees(Lat1, Lon1, Lat2, Lon2) * 0.0174532925199433;
				double num3 = Lon1 * 0.0174532925199433;
				double num4 = Lon2 * 0.0174532925199433;
				double num5 = Lat1 * 0.0174532925199433;
				double num6 = Lat2 * 0.0174532925199433;
				AllPoints = new Point3D[NumSegments + 1];
				AllPoints[0].X = Lon1;
				AllPoints[0].Y = Lat1;
				AllPoints[0].Z = Alt1;
				if (num3 == num4)
				{
					double num7 = (num6 - num5) / (double)NumSegments;
					int num8 = NumSegments - 1;
					for (int i = 1; i <= num8; i++)
					{
						AllPoints[i].X = Lon1;
						AllPoints[i].Y = (num5 + num7 * (double)i) * 57.2957795130823;
						AllPoints[i].Z = num * (double)i + Alt1;
					}
				}
				else
				{
					double num9 = Math.Sin(num2);
					double num10 = Math.Cos(num5);
					double num11 = Math.Cos(num6);
					int num12 = NumSegments - 1;
					for (int i = 1; i <= num12; i++)
					{
						double num13 = (double)i / (double)NumSegments;
						double num14 = Math.Sin((1.0 - num13) * num2) / num9;
						double num15 = Math.Sin(num13 * num2) / num9;
						double num16 = num14 * num10 * Math.Cos(num3) + num15 * num11 * Math.Cos(num4);
						double num17 = num14 * num10 * Math.Sin(num3) + num15 * num11 * Math.Sin(num4);
						double y = Math.Atan2(num14 * Math.Sin(num5) + num15 * Math.Sin(num6), Math.Sqrt(num16 * num16 + num17 * num17)) * 57.2957795130823;
						double x = Math.Atan2(num17, num16) * 57.2957795130823;
						AllPoints[i].X = x;
						AllPoints[i].Y = y;
						AllPoints[i].Z = num * (double)i + Alt1;
					}
				}
				AllPoints[NumSegments].X = Lon2;
				AllPoints[NumSegments].Y = Lat2;
				AllPoints[NumSegments].Z = Alt2;
			}
			else
			{
				AllPoints = new Point3D[NumSegments + 1];
				AllPoints[0].X = Lon1;
				AllPoints[0].Y = Lat1;
				AllPoints[0].Z = Alt1;
				for (int i = 1; i <= NumSegments; i++)
				{
					AllPoints[i].X = Lon1;
					AllPoints[i].Y = Lat1;
					AllPoints[i].Z = num * (double)i + Alt1;
				}
			}
			return;
		}
		throw new Exception("zero numsegments");
	}

	public static void PartitionGreatCircle(double Lat1, double Lon1, double Lat2, double Lon2, int NumSegments, ref double[] Latitudes, ref double[] Longitudes)
	{
		if (NumSegments == 0)
		{
			throw new Exception("zero numsegments");
		}
		if (Lat1 == Lat2 && Lon1 == Lon2)
		{
			Latitudes = new double[1];
			Longitudes = new double[1];
			Longitudes[0] = Lon1;
			Latitudes[0] = Lat1;
			return;
		}
		double num = SphericalDistanceDegrees(Lat1, Lon1, Lat2, Lon2) * 0.0174532925199433;
		double num2 = Lon1 * 0.0174532925199433;
		double num3 = Lon2 * 0.0174532925199433;
		double num4 = Lat1 * 0.0174532925199433;
		double num5 = Lat2 * 0.0174532925199433;
		Latitudes = new double[NumSegments + 1];
		Longitudes = new double[NumSegments + 1];
		Longitudes[0] = Lon1;
		Latitudes[0] = Lat1;
		if (num2 == num3)
		{
			double num6 = (num5 - num4) / (double)NumSegments;
			int num7 = NumSegments - 1;
			for (int i = 1; i <= num7; i++)
			{
				Longitudes[i] = Lon1;
				Latitudes[i] = (num4 + num6 * (double)i) * 57.2957795130823;
			}
		}
		else
		{
			double num8 = Math.Sin(num);
			double num9 = Math.Cos(num4);
			double num10 = Math.Cos(num5);
			int num11 = NumSegments - 1;
			for (int i = 1; i <= num11; i++)
			{
				double num12 = (double)i / (double)NumSegments;
				double num13 = Math.Sin((1.0 - num12) * num) / num8;
				double num14 = Math.Sin(num12 * num) / num8;
				double num15 = num13 * num9 * Math.Cos(num2) + num14 * num10 * Math.Cos(num3);
				double num16 = num13 * num9 * Math.Sin(num2) + num14 * num10 * Math.Sin(num3);
				double num17 = Math.Atan2(num13 * Math.Sin(num4) + num14 * Math.Sin(num5), Math.Sqrt(num15 * num15 + num16 * num16)) * 57.2957795130823;
				double num18 = Math.Atan2(num16, num15) * 57.2957795130823;
				Longitudes[i] = num18;
				Latitudes[i] = num17;
			}
		}
		Longitudes[NumSegments] = Lon2;
		Latitudes[NumSegments] = Lat2;
	}

	internal static double ApproxSlantRangeNM(double GroundRangeNM, double H1, double H2)
	{
		double d = GroundRangeNM * 1852.0 / 6371000.0;
		double num = 6371000.0 + H1;
		double num2 = 6371000.0 + H2;
		return Math.Sqrt(num * num + num2 * num2 - 2.0 * num * num2 * Math.Cos(d)) / 1852.0;
	}

	public static void fw_geod_wgs84(ref TCoord Pt, ref TCoord Ret, double al12, double dist)
	{
		double num = 6378137.0;
		double num2 = 0.0033528106647474805;
		double num3 = 0.0008382026661868701;
		double num4 = 1852.0;
		double num5 = dist * num4;
		double a = Pt.Lat * 0.0174532925199433;
		double num6 = Pt.Lon * 0.0174532925199433;
		double lon = al12 * 0.0174532925199433;
		lon = adjlon(lon);
		bool flag = Math.Abs(lon) > 1.5707963267949;
		double num7 = 1.0 + num2;
		double num8 = Math.Atan(num7 * Math.Tan(a));
		double num9 = Math.Cos(num8);
		double num10 = Math.Sin(num8);
		double num11 = Math.Sin(lon);
		bool flag2;
		double num12;
		double num13;
		if (Math.Abs(num11) < 1E-09)
		{
			flag2 = true;
			num11 = 0.0;
			num12 = ((!(Math.Abs(lon) < 1.5707963267949)) ? (-1.0) : 1.0);
			num13 = 0.0;
		}
		else
		{
			flag2 = false;
			num12 = Math.Cos(lon);
			num13 = num9 * num11;
		}
		double num14 = num9 * num12;
		double num15;
		double num16;
		double num17;
		double num18;
		if (flag2)
		{
			num15 = 0.0;
			num16 = num3;
			num17 = 1.0 - num16;
			num17 *= num17;
			num18 = num16 / num17;
		}
		else
		{
			num15 = num2 * num13;
			num16 = num3 * (1.0 - num13 * num13);
			num17 = (1.0 - num16) * (1.0 - num16 - num15 * num13);
			num18 = (1.0 + 0.5 * num15 * num13) * num16 / num17;
		}
		double a2;
		if (!flag2)
		{
			a2 = ((!(Math.Abs(num13) > 1.0)) ? Math.Acos(num13) : 0.0);
			a2 = ((Math.Sin(a2) != 0.0) ? (num10 / Math.Sin(a2)) : 0.0);
			a2 = ((!(Math.Abs(a2) > 1.0)) ? Math.Acos(a2) : 0.0);
		}
		else
		{
			a2 = 1.5707963267949 - num8;
		}
		double num19 = num5 / (num17 * num);
		if (flag)
		{
			num19 = 0.0 - num19;
		}
		double num20 = 2.0 * (a2 - num19);
		double num21 = Math.Cos(num20 + num19);
		double num22 = Math.Sin(num19);
		double num23 = num16 * num16 * num22 * Math.Cos(num19) * (2.0 * num21 * num21 - 1.0);
		double num24 = num19 + num23 - 2.0 * num18 * num21 * (1.0 - 2.0 * num18 * Math.Cos(num20)) * num22;
		double d = a2 + a2 - num24;
		double num25 = Math.Cos(num24);
		double num26 = Math.Sin(num24);
		if (flag)
		{
			num26 = 0.0 - num26;
		}
		double num27 = num14 * num25 - num10 * num26;
		double num28;
		double num29;
		if (!flag2)
		{
			num27 = Math.Atan(num13 / num27);
			if (num27 > 0.0)
			{
				num27 += 3.14159265358979;
			}
			if (lon < 0.0)
			{
				num27 -= 3.14159265358979;
			}
			num27 = adjlon(num27);
			num28 = Math.Atan((0.0 - (num10 * num25 + num14 * num26)) * Math.Sin(num27) / (num7 * num13));
			num29 = Math.Atan2(num26 * num11, num9 * num25 - num10 * num26 * num12);
			num29 = (flag ? (num29 + num15 * ((1.0 - num16) * num24 + num16 * num26 * Math.Cos(d))) : (num29 - num15 * ((1.0 - num16) * num24 - num16 * num26 * Math.Cos(d))));
		}
		else
		{
			num28 = Math.Atan(Math.Tan(1.5707963267949 + a2 - num24) / num7);
			if (num27 > 0.0)
			{
				num27 = 3.14159265358979;
				if (flag)
				{
					num29 = 3.14159265358979;
				}
				else
				{
					num28 = 0.0 - num28;
					num29 = 0.0;
				}
			}
			else
			{
				num27 = 0.0;
				if (flag)
				{
					num28 = 0.0 - num28;
					num29 = 0.0;
				}
				else
				{
					num29 = 3.14159265358979;
				}
			}
		}
		double lon2 = num6 + num29;
		lon2 = adjlon(lon2);
		Ret.Lat = num28 * 57.2957795130823;
		Ret.Lon = lon2 * 57.2957795130823;
	}

	public static void fw_vincenty_wgs84(ref TCoord Pt, ref TCoord Ret, double al12, double dist)
	{
		fw_vincenty_wgs84(Pt.Lat, Pt.Lon, ref Ret.Lat, ref Ret.Lon, al12, dist);
	}

	public static void fw_vincenty_wgs84(double Lat1, double Lon1, ref double Lat2, ref double Lon2, double al12, double dist)
	{
		if (dist == 0.0)
		{
			Lat2 = Lat1;
			Lon2 = Lon1;
			return;
		}
		double num = 6378137.0;
		double num2 = 0.0033528106647474805;
		double num3 = 6356752.314245179;
		double num4 = 1852.0;
		double num5 = dist * num4;
		double a = Lat1 * 0.0174532925199433;
		double num6 = Lon1 * 0.0174532925199433;
		double lon = al12 * 0.0174532925199433;
		lon = adjlon(lon);
		double num7 = Math.Atan(0.9966471893352525 * Math.Tan(a));
		double num8 = Math.Cos(num7);
		double num9 = Math.Sin(num7);
		double num10 = ((Math.Cos(lon) != 0.0) ? Math.Atan2(Math.Tan(num7), Math.Cos(lon)) : 0.0);
		double num11 = num8 * Math.Sin(lon);
		double num12 = 1.0 - num11 * num11;
		double num13 = num12 * (num * num - num3 * num3) / (num3 * num3);
		double num14 = 1.0 + num13 / 16384.0 * (4096.0 + num13 * (-768.0 + num13 * (320.0 - 175.0 * num13)));
		double num15 = num13 / 1024.0 * (256.0 + num13 * (-128.0 + num13 * (74.0 - 47.0 * num13)));
		double num16 = num5 / (num3 * num14);
		double num17 = Math.Cos(num16);
		double num18 = Math.Sin(num16);
		int num19 = 1;
		double num20;
		do
		{
			num20 = Math.Cos(2.0 * num10 + num16);
			double num21 = num15 * num18 * (num20 + 0.25 * num15 * (num17 * (-1.0 + 2.0 * num20 * num20) - 0.166666666666666 * num15 * num20 * (-3.0 + 4.0 * num18 * num18) * (-3.0 + 4.0 * num20 * num20)));
			num16 = num5 / (num3 * num14) + num21;
			num17 = Math.Cos(num16);
			num18 = Math.Sin(num16);
			if (!(Math.Abs(num21) >= 1E-10))
			{
				break;
			}
			num19++;
		}
		while (num19 <= 5);
		double num22 = num9 * num18 - num8 * num17 * Math.Cos(lon);
		double num23 = Math.Atan2(num9 * num17 + num8 * num18 * Math.Cos(lon), (1.0 - num2) * Math.Sqrt(num11 * num11 + num22 * num22));
		double num24 = Math.Atan2(num18 * Math.Sin(lon), num8 * num17 - num9 * num18 * Math.Cos(lon));
		double num25 = num2 / 16.0 * (1.0 - num11 * num11) * (4.0 + num2 * (4.0 - 3.0 * num12));
		double num26 = num24 - (1.0 - num25) * num2 * num11 * (num16 + num25 * num18 * (num20 + num25 * num17 * (-1.0 + 2.0 * num20 * num20)));
		double num27 = num6 + num26;
		Lat2 = num23 * 57.2957795130823;
		Lon2 = num27 * 57.2957795130823;
		if (Lon2 == 360.0)
		{
			Lon2 = 0.0;
		}
		double num28 = Math.Atan2(num11, (0.0 - num9) * num18 + num8 * num17 * Math.Cos(lon));
		if (num28 < 0.0)
		{
			num28 += 6.28318530717959;
		}
		if ((Lat1 == 90.0 || Lat1 == -90.0) && Lon1 != -180.0 && Lon1 != 180.0)
		{
			Lat2 = 0.0 - Lat2;
		}
	}

	public static void inv_vincenty_wgs84_2(double Lat1, double Lon1, double Lat2, double Lon2, ref double al12, ref double al21, ref double dist)
	{
		TCoord pt = default(TCoord);
		pt.Lat = Lat1;
		pt.Lon = Lon1;
		TCoord pt2 = default(TCoord);
		pt2.Lat = Lat2;
		pt2.Lon = Lon2;
		inv_vincenty_wgs84(pt, pt2, ref al12, ref al21, ref dist);
	}

	internal static double MetersAlongTheParallel(double DeltaLon, double Lat)
	{
		if (Math.Abs(Lat) == 90.0)
		{
			return 0.0;
		}
		double num = DeltaLon * 0.0174532925199433;
		double num2 = Lat * 0.0174532925199433;
		double num3 = 6378137.0;
		double num4 = 0.006694379990141316;
		double num5 = Math.Sin(num2);
		return num3 * Math.Cos(num2) / Math.Sqrt(1.0 - num4 * (num5 * num5)) * num;
	}

	public static void offsets_wgs84(double Lat1, double Lon1, double Lat2, double Lon2, ref double dist_lon, ref double dist_lat)
	{
		double al = default(double);
		double al2 = default(double);
		double dist = default(double);
		inv_vincenty_wgs84_2(Lat1, Lon1, Lat2, Lon1, ref al, ref al2, ref dist);
		dist_lat = dist * 1852.0;
		dist_lon = MetersAlongTheParallel(Lon2 - Lon1, Lat1);
	}

	public static void inv_geod_wgs84_2(double Lat1, double Lon1, double Lat2, double Lon2, ref double al12, ref double al21, ref double dist)
	{
		TCoord pt = default(TCoord);
		pt.Lat = Lat1;
		pt.Lon = Lon1;
		TCoord pt2 = default(TCoord);
		pt2.Lat = Lat2;
		pt2.Lon = Lon2;
		inv_geod_wgs84(pt, pt2, ref al12, ref al21, ref dist);
	}

	public static void inv_geod_wgs84(TCoord Pt1, TCoord Pt2, ref double al12, ref double al21, ref double dist)
	{
		double num = 6378137.0;
		double num2 = 1852.0;
		double num3 = Pt1.Lat * 0.0174532925199433;
		double num4 = Pt2.Lat * 0.0174532925199433;
		double a = Pt1.Lon * 0.0174532925199433;
		double a2 = Pt2.Lon * 0.0174532925199433;
		double num5 = 0.0016764053323737402;
		double num6 = 0.0008382026661868701;
		double num7 = 1.756459274006944E-07;
		double num8 = Math.Atan(1.0033528106647476 * Math.Tan(a));
		double num9 = Math.Atan(1.0033528106647476 * Math.Tan(a2));
		double num10 = 0.5 * (num8 + num9);
		double num11 = 0.5 * (num9 - num8);
		double num12 = adjlon(num4 - num3);
		double a3 = 0.5 * num12;
		if ((Math.Abs(num12) < 1E-12) & (Math.Abs(num11) < 1E-12))
		{
			al12 = 0.0;
			al21 = 0.0;
			dist = 0.0;
			return;
		}
		double num13 = Math.Sin(a3);
		double num14 = Math.Cos(num10);
		double num15 = Math.Sin(num10);
		double num16 = Math.Cos(num11);
		double num17 = Math.Sin(num11);
		double num18 = num17 * num17 + (num16 * num16 - num15 * num15) * num13 * num13;
		double num19 = 1.0 - num18 - num18;
		double num20 = Math.Acos(num19);
		double num21 = num19 + num19;
		double num22 = Math.Sin(num20);
		double num23 = num15 * num16;
		num23 *= (num23 + num23) / (1.0 - num18);
		double num24 = num17 * num14;
		num24 *= (num24 + num24) / num18;
		double num25 = num23 + num24;
		num23 -= num24;
		num24 = num20 / num22;
		double num26 = 4.0 * num24 * num24;
		double num27 = num26 * num21;
		double num28 = num26 + num26;
		double num29 = num * num22 * (num24 - num6 * (num24 * num25 - num23) + num7 * (num25 * (num27 + (num24 - 0.5 * (num27 - num21)) * num25) - num23 * (num28 + num21 * num23) + num26 * num25 * num23));
		double num30 = Math.Tan(0.5 * (num12 - 0.25 * (num23 + num23 - num21 * (4.0 - num25)) * (num5 * num24 + num7 * (32.0 * num24 - (20.0 * num24 - num27) * num25 - (num28 + 4.0) * num23)) * Math.Tan(num12)));
		double num31 = Math.Atan2(num17, num30 * num14);
		double num32 = Math.Atan2(num16, num30 * num15);
		double num33 = adjlon(6.28318530717959 + num32 - num31);
		double num34 = adjlon(6.28318530717959 - num32 - num31);
		dist = num29 / num2;
		al12 = num33 * 57.2957795130823;
		al21 = num34 * 57.2957795130823;
	}

	public static void inv_vincenty_wgs84(TCoord Pt1, TCoord Pt2, ref double al12, ref double al21, ref double dist)
	{
		inv_vincenty_wgs84(Pt1.Lat, Pt1.Lon, Pt2.Lat, Pt2.Lon, ref al12, ref al21, ref dist);
	}

	public static void inv_vincenty_wgs84(double Lat1, double Lon1, double Lat2, double Lon2, ref double al12, ref double al21, ref double dist)
	{
		double num = 6378137.0;
		double num2 = 0.0033528106647474805;
		double num3 = 6356752.314245179;
		double a = Lat1 * 0.0174532925199433;
		double num4 = Lon1 * 0.0174532925199433;
		double a2 = Lat2 * 0.0174532925199433;
		double num5 = Lon2 * 0.0174532925199433 - num4;
		double num13;
		double num14;
		double num6;
		double num12;
		if (Math.Abs(Math.Abs(Lat1) - 90.0) < 1E-12)
		{
			if (Math.Abs(Math.Abs(Lat2) - 90.0) < 1E-12)
			{
				if (Math.Abs(Lat1 - Lat2) < 2E-12)
				{
					al12 = 0.0;
					al21 = 180.0;
					dist = 0.0;
					return;
				}
				if (Lat1 > 0.0)
				{
					al12 = 180.0;
					al21 = 0.0;
				}
				else
				{
					al12 = 0.0;
					al21 = 180.0;
				}
				num6 = (num - num3) / (num + num3);
				double num7 = num6 * num6;
				double num8 = 1.0 + num7 / 4.0;
				double num9 = num7 * num7;
				num8 += num9 / 64.0;
				double num10 = num9 * num7;
				num8 += num10 / 256.0;
				double num11 = num9 * num9;
				num8 += num11 * 25.0 / 16384.0;
				num12 = 3.14159265358979 * (num + num3) * num8 / 2.0;
				dist = num12 / 1852.0;
				return;
			}
			num13 = Math.Atan((1.0 - num2) * Math.Tan(a2));
			num14 = 1.5707963267949 * (double)MathFunctions.Sign(Lat1);
		}
		else
		{
			num13 = ((!(Math.Abs(Math.Abs(Lat2) - 90.0) < 1E-12)) ? Math.Atan((1.0 - num2) * Math.Tan(a2)) : (1.5707963267949 * (double)MathFunctions.Sign(Lat2)));
			num14 = Math.Atan((1.0 - num2) * Math.Tan(a));
		}
		double num15 = Math.Cos(num14);
		double num16 = Math.Cos(num13);
		double num17 = Math.Sin(num14);
		double num18 = Math.Sin(num13);
		num6 = num5;
		int num19 = 1;
		double num22;
		double num23;
		double d2;
		double num25;
		double num26;
		double num29 = default(double);
		do
		{
			double num20 = num16 * Math.Sin(num6);
			double num21 = num15 * num18 - num17 * num16 * Math.Cos(num6);
			double d = num20 * num20 + num21 * num21;
			num22 = num17 * num18 + num15 * num16 * Math.Cos(num6);
			num23 = Math.Sqrt(d);
			d2 = num23 / num22;
			double num24 = num15 * num16 * Math.Sin(num6) / num23;
			num25 = 1.0 - num24 * num24;
			num26 = ((Math.Abs(num25) < double.Epsilon) ? num22 : (num22 - 2.0 * num17 * num18 / num25));
			double num27 = num2 / 16.0 * (1.0 - num24 * num24) * (4.0 + num2 * (4.0 - 3.0 * num25));
			double num28 = num5 + (1.0 - num27) * num2 * num24 * (num29 + num27 * num23 * (num26 + num27 * num22 * (-1.0 + 2.0 * num26 * num26)));
			if (Math.Abs(num28 - num6) < 1E-12)
			{
				break;
			}
			num6 = num28;
			num19++;
		}
		while (num19 <= 5);
		double num30 = num25 * (num * num - num3 * num3) / (num3 * num3);
		double num31 = 1.0 + num30 / 16384.0 * (4096.0 + num30 * (-768.0 + num30 * (320.0 - 175.0 * num30)));
		double num32 = num30 / 1024.0 * (256.0 + num30 * (-128.0 + num30 * (74.0 - 47.0 * num30)));
		num29 = Math.Atan(d2);
		double num33 = num32 * num23 * (num26 + 0.25 * num32 * (num22 * (-1.0 + 2.0 * num26 * num26) - 1.0 / 6.0 * num32 * num26 * (-3.0 + 4.0 * num23 * num23) * (-3.0 + 4.0 * num26 * num26)));
		num12 = num3 * num31 * (num29 - num33);
		if (num12 < 0.0)
		{
			num12 = 0.0 - num12;
		}
		dist = num12 / 1852.0;
		double lon = Math.Atan(num16 * Math.Sin(num6) / (num15 * num18 - num17 * num16 * Math.Cos(num6)));
		lon = adjlon(lon);
		double num34 = Math.Atan(num15 * Math.Sin(num6) / ((0.0 - num17) * num16 + num15 * num18 * Math.Cos(num6)));
		num34 = adjlon(num34 - 3.14159265358979);
		al12 = 57.2957795130823 * lon;
		al21 = 57.2957795130823 * num34;
		if (dist < 0.0 || double.IsNaN(dist))
		{
			dist = GreatCircleDistance(Lat1, Lon1, Lat2, Lon2);
		}
	}

	internal static double GreatCircleDistance(double Lat1, double Lon1, double Lat2, double Lon2)
	{
		return Math.Acos(Math.Cos(Lat1 * 0.0174532925199433) * Math.Cos(Lat2 * 0.0174532925199433) * Math.Cos((Lon1 - Lon2) * 0.0174532925199433) + Math.Sin(Lat1 * 0.0174532925199433) * Math.Sin(Lat2 * 0.0174532925199433)) * 6371.0 * 1000.0 / 1852.0;
	}

	internal static double GCRatioAtKnownDistance(double Lat1, double Lon1, double Lat2, double Lon2, double distNM)
	{
		double num = distNM * 1852.0 / 6371000.0;
		double num2 = Lat2 - Lat1;
		double num3 = Lon2 - Lon1;
		if (Math.Abs(num3) < double.Epsilon)
		{
			if (Math.Abs(num2) < double.Epsilon)
			{
				try
				{
					throw new Exception("this distance is beyond the boundaries of the line segment");
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200265", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
			}
			return num * 57.2957795130823 / num2;
		}
		if (Math.Abs(num2) < double.Epsilon)
		{
			return num * 57.2957795130823 / num3;
		}
		double num4 = num2 / num3;
		double num5 = Lat1 * 0.0174532925199433;
		double num6 = Math.Cos(num5);
		double num7 = Math.Sin(num5);
		double double_ = num3 * 0.0174532925199433;
		double num8 = Math.Cos(num);
		double[] double_2 = new double[5] { num8, num6, num5, num4, num7 };
		return smethod_3(DhlyyWsknbA, 0.0, double_, 1E-06, double_2) * 57.2957795130823 / num3;
	}

	private static double DhlyyWsknbA(double double_0, object object_0)
	{
		double num = ((double[])object_0)[0];
		double num2 = ((double[])object_0)[1] * Math.Cos(((double[])object_0)[2] + ((double[])object_0)[3] * double_0) * Math.Cos(double_0) + ((double[])object_0)[4] * Math.Sin(((double[])object_0)[2] + ((double[])object_0)[3] * double_0);
		double num3 = num - num2;
		return num3 * num3;
	}

	private static double smethod_2(double double_0, double double_1)
	{
		if (double_1 <= 0.0)
		{
			return 0.0 - Math.Abs(double_0);
		}
		return Math.Abs(double_0);
	}

	private static double smethod_3(Delegate2 delegate2_0, double double_0, double double_1, double double_2, double[] double_3)
	{
		int num = 0;
		double num2 = 0.381966;
		double num3 = 0.5 * (double_0 + double_1);
		double num4 = ((!(double_0 < double_1)) ? double_1 : double_0);
		double num5 = ((!(double_0 > double_1)) ? double_1 : double_0);
		double num6 = num3;
		double num7 = num6;
		double num8 = num6;
		double num9 = 0.0;
		double num10 = delegate2_0(num8, double_3);
		double num11 = num10;
		double num12 = num10;
		num = 1;
		double num18 = default(double);
		do
		{
			double num13 = 0.5 * (num4 + num5);
			if (!(Math.Abs(num8 - num13) > double_2 * 2.0 - 0.5 * (num5 - num4)))
			{
				break;
			}
			double num19;
			if (Math.Abs(num9) > double_2)
			{
				double num14 = (num8 - num7) * (num10 - num11);
				double num15 = (num8 - num6) * (num10 - num12);
				double num16 = (num8 - num6) * num15 - (num8 - num7) * num14;
				num15 = 2.0 * (num15 - num14);
				if (num15 > 0.0)
				{
					num16 = 0.0 - num16;
				}
				num15 = Math.Abs(num15);
				double num17 = num9;
				num9 = num18;
				if (!(Math.Abs(num16) >= Math.Abs(0.5 * num15 * num17)) && !(num16 <= num15 * (num4 - num8)) && !(num16 >= num15 * (num5 - num8)))
				{
					num18 = num16 / num15;
					num19 = num8 + num18;
					if (num19 - num4 < double_2 * 2.0 || num5 - num19 < double_2 * 2.0)
					{
						num18 = smethod_2(double_2, num13 - num8);
					}
				}
				else
				{
					num9 = ((!(num8 >= num13)) ? (num5 - num8) : (num4 - num8));
					num18 = num2 * num9;
				}
			}
			else
			{
				num9 = ((!(num8 >= num13)) ? (num5 - num8) : (num4 - num8));
				num18 = num2 * num9;
			}
			num19 = ((!(Math.Abs(num18) >= double_2)) ? (num8 + smethod_2(double_2, num18)) : (num8 + num18));
			double num20 = delegate2_0(num19, double_3);
			if (num20 <= num10)
			{
				if (num19 >= num8)
				{
					num4 = num8;
				}
				else
				{
					num5 = num8;
				}
				num6 = num7;
				num11 = num12;
				num7 = num8;
				num12 = num10;
				num8 = num19;
				num10 = num20;
			}
			else
			{
				if (num19 < num8)
				{
					num4 = num19;
				}
				else
				{
					num5 = num19;
				}
				if (!(num20 <= num12) && num7 != num8)
				{
					if (num20 <= num11 || num6 == num8 || num6 == 2.0)
					{
						num6 = num19;
						num11 = num20;
					}
				}
				else
				{
					num6 = num7;
					num11 = num12;
					num7 = num19;
					num12 = num20;
				}
			}
			num++;
		}
		while (num <= 100);
		return num8;
	}

	internal static double GreatCircleCentralAngle(double Lat1, double Lon1, double Lat2, double Lon2)
	{
		return Math.Acos(Math.Cos(Lat1 * 0.0174532925199433) * Math.Cos(Lat2 * 0.0174532925199433) * Math.Cos((Lon1 - Lon2) * 0.0174532925199433) + Math.Sin(Lat1 * 0.0174532925199433) * Math.Sin(Lat2 * 0.0174532925199433));
	}

	public static void fw_greatcircle(double Lat1, double Lon1, ref double Lat2, ref double Lon2, double al12, double dist)
	{
		double num = 6371000.0;
		double num2 = 1852.0;
		double num3 = dist * num2;
		double a = ((Math.Abs(Math.Abs(Lat1) - 90.0) >= 1E-09) ? (Lat1 * 0.0174532925199433) : ((!(Lat1 > 0.0)) ? ((Lat1 + 1E-09) * 0.0174532925199433) : ((Lat1 - 1E-09) * 0.0174532925199433)));
		double num4 = Lon1 * 0.0174532925199433;
		double lon = al12 * 0.0174532925199433;
		lon = adjlon(lon);
		bool flag = Math.Abs(lon) > 1.5707963267949;
		double num5 = 1.0;
		double num6 = Math.Atan(num5 * Math.Tan(a));
		double num7 = Math.Cos(num6);
		double num8 = Math.Sin(num6);
		double num9 = Math.Sin(lon);
		bool flag2;
		double num10;
		double num11;
		if (Math.Abs(num9) < 1E-09)
		{
			flag2 = true;
			num9 = 0.0;
			num10 = ((!(Math.Abs(lon) < 1.5707963267949)) ? (-1.0) : 1.0);
			num11 = 0.0;
		}
		else
		{
			flag2 = false;
			num10 = Math.Cos(lon);
			num11 = num7 * num9;
		}
		double num12 = num7 * num10;
		double num13;
		double num14;
		if (flag2)
		{
			num13 = 0.0;
			num14 = 0.0;
		}
		else
		{
			num13 = 0.0;
			num14 = 0.0;
		}
		double a2;
		if (!flag2)
		{
			a2 = ((!(Math.Abs(num11) > 1.0)) ? Math.Acos(num11) : 0.0);
			a2 = ((Math.Sin(a2) != 0.0) ? (num8 / Math.Sin(a2)) : 0.0);
			a2 = ((!(Math.Abs(a2) > 1.0)) ? Math.Acos(a2) : 0.0);
		}
		else
		{
			a2 = 1.5707963267949 - num6;
		}
		double num15 = num3 / num;
		if (flag)
		{
			num15 = 0.0 - num15;
		}
		Math.Cos(2.0 * (a2 - num15) + num15);
		Math.Sin(num15);
		double num16 = num15;
		double d = a2 + a2 - num16;
		double num17 = Math.Cos(num16);
		double num18 = Math.Sin(num16);
		if (flag)
		{
			num18 = 0.0 - num18;
		}
		double num19 = num12 * num17 - num8 * num18;
		double num20;
		double num21;
		if (flag2)
		{
			num20 = Math.Atan(Math.Tan(1.5707963267949 + a2 - num16) / num5);
			if (num19 > 0.0)
			{
				num19 = 3.14159265358979;
				if (flag)
				{
					num21 = 3.14159265358979;
				}
				else
				{
					num20 = 0.0 - num20;
					num21 = 0.0;
				}
			}
			else
			{
				num19 = 0.0;
				if (!flag)
				{
					num21 = 3.14159265358979;
				}
				else
				{
					num20 = 0.0 - num20;
					num21 = 0.0;
				}
			}
		}
		else
		{
			num19 = Math.Atan(num11 / num19);
			if (num19 > 0.0)
			{
				num19 += 3.14159265358979;
			}
			if (lon < 0.0)
			{
				num19 -= 3.14159265358979;
			}
			num19 = adjlon(num19);
			num20 = Math.Atan((0.0 - (num8 * num17 + num12 * num18)) * Math.Sin(num19) / (num5 * num11));
			num21 = Math.Atan2(num18 * num9, num7 * num17 - num8 * num18 * num10);
			num21 = (flag ? (num21 + num13 * ((1.0 - num14) * num16 + num14 * num18 * Math.Cos(d))) : (num21 - num13 * ((1.0 - num14) * num16 - num14 * num18 * Math.Cos(d))));
		}
		double lon2 = num4 + num21;
		lon2 = adjlon(lon2);
		Lat2 = num20 * 57.2957795130823;
		Lon2 = lon2 * 57.2957795130823;
	}

	public static void SolveSphericalTriangleSummit(double Lat1, double Lon1, double Lat2, double Lon2, double TotalDiversionDistanceNM, double DiversionDirection, ref double LatS, ref double LonS)
	{
		double num = TotalDiversionDistanceNM * 1852.0 / 6371000.0;
		double num2 = GreatCircleCentralAngle(Lat1, Lon1, Lat2, Lon2);
		double num3 = DiversionDirection * 0.0174532925199433;
		double al = default(double);
		double al2 = default(double);
		double dist = default(double);
		inv_vincenty_wgs84_2(Lat1, Lon1, Lat2, Lon2, ref al, ref al2, ref dist);
		double num4 = Math.Abs(num3 - al * 0.0174532925199433);
		double num5 = (num2 + num) / 2.0;
		Math.Sin(num5);
		Math.Sin(num5 - num2);
		Math.Cos(num4 / 2.0);
		Math.Sin(num4 / 2.0);
	}

	private static void Main()
	{
		LockRandom lockRandom = new LockRandom();
		int num = 1;
		double X = default(double);
		double Y = default(double);
		double LatitudeD = default(double);
		double LongitudeD = default(double);
		do
		{
			double num2 = lockRandom.NextDouble() * 180.0 - 90.0;
			double num3 = lockRandom.NextDouble() * 360.0 - 180.0;
			double num4 = -90.0;
			double num5 = num3 + lockRandom.NextDouble() * 18.0 - 9.0;
			TLocalTM tLocalTM = new TLocalTM(num2, num3);
			if (tLocalTM.method_0(num4, num5, ref X, ref Y, Allow_DEG_MAX_DELTA_LONG: false))
			{
				Console.WriteLine(Conversions.ToString(X) + " " + Conversions.ToString(Y));
				if (tLocalTM.method_1(X, Y, ref LatitudeD, ref LongitudeD))
				{
					Console.WriteLine(Conversions.ToString(num2) + " " + Conversions.ToString(num3) + " " + Conversions.ToString(num4) + " " + Conversions.ToString(num5) + " " + Conversions.ToString(LatitudeD) + " " + Conversions.ToString(LongitudeD));
					num++;
					continue;
				}
				break;
			}
			break;
		}
		while (num <= 100000);
	}

	static Geodesic_Vincenty()
	{
		Class72.smethod_20();
	}
}
