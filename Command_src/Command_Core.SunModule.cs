using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class SunModule
{
	public struct SpaData
	{
		public int year;

		public int month;

		public int day;

		public int hour;

		public int minute;

		public double second;

		public double latitude;

		public double longitude;

		public double elevation;

		public double pressure;

		public double temperature;

		public double slope;

		public double azm_rotation;

		public double delta_ut1;

		public double delta_t;

		public double zenith;

		public double azimuth;

		public double incidence;

		public double suntransit;

		public double sunrise;

		public double sunset;

		public double elevation_angle => 90.0 - zenith;

		public static SpaData WithDefaults()
		{
			SpaData result = default(SpaData);
			result.pressure = 1013.0;
			result.temperature = 12.0;
			result.slope = 0.0;
			result.azm_rotation = 0.0;
			result.delta_ut1 = 0.0;
			result.delta_t = 67.0;
			return result;
		}

		static SpaData()
		{
			Class72.smethod_20();
		}
	}

	public sealed class TerminatorClassifier
	{
		private readonly double double_0;

		private readonly double double_1;

		private readonly double double_2;

		private readonly double double_3;

		private readonly double double_4;

		public TerminatorClassifier(DateTime utcTime)
		{
			SpaData spa = SpaData.WithDefaults();
			spa.year = utcTime.Year;
			spa.month = utcTime.Month;
			spa.day = utcTime.Day;
			spa.hour = utcTime.Hour;
			spa.minute = utcTime.Minute;
			spa.second = utcTime.Second;
			spa.latitude = 0.0;
			spa.longitude = 0.0;
			int num = SPA_Calculate(ref spa);
			if (num == 0)
			{
				SpaData spa2 = SpaData.WithDefaults();
				spa2.year = utcTime.Year;
				spa2.month = utcTime.Month;
				spa2.day = utcTime.Day;
				spa2.hour = utcTime.Hour;
				spa2.minute = utcTime.Minute;
				spa2.second = utcTime.Second;
				spa2.latitude = 0.0;
				spa2.longitude = 90.0;
				SPA_Calculate(ref spa2);
				SpaData spa3 = SpaData.WithDefaults();
				spa3.year = utcTime.Year;
				spa3.month = utcTime.Month;
				spa3.day = utcTime.Day;
				spa3.hour = utcTime.Hour;
				spa3.minute = utcTime.Minute;
				spa3.second = utcTime.Second;
				spa3.latitude = 90.0;
				spa3.longitude = 0.0;
				SPA_Calculate(ref spa3);
				double_0 = Math.Sin(smethod_8(spa.elevation_angle));
				double_1 = Math.Sin(smethod_8(spa2.elevation_angle));
				double_2 = Math.Sin(smethod_8(spa3.elevation_angle));
				double num2 = Math.Sqrt(double_0 * double_0 + double_1 * double_1 + double_2 * double_2);
				if (num2 > 1E-09)
				{
					double_0 /= num2;
					double_1 /= num2;
					double_2 /= num2;
				}
				double_3 = Math.Sin(smethod_8(-5.0 / 6.0));
				double_4 = Math.Sin(smethod_8(-12.0));
				return;
			}
			throw new ArgumentOutOfRangeException($"TerminatorClassifier: SPA_Calculate returned error code {num} for {utcTime:O}");
		}

		public Weather.TTimeOfDayType Classify(double latDeg, double lonDeg)
		{
			double num = smethod_8(latDeg);
			double num2 = smethod_8(lonDeg);
			double num3 = Math.Cos(num);
			double num4 = num3 * Math.Cos(num2);
			double num5 = num3 * Math.Sin(num2);
			double num6 = Math.Sin(num);
			double num7 = double_0 * num4 + double_1 * num5 + double_2 * num6;
			if (num7 < double_3)
			{
				if (num7 >= double_4)
				{
					return Weather.TTimeOfDayType.tod_Twilight;
				}
				return Weather.TTimeOfDayType.tod_Night;
			}
			return Weather.TTimeOfDayType.tod_Day;
		}

		static TerminatorClassifier()
		{
			Class72.smethod_20();
		}
	}

	public sealed class TerminatorClassifierCache
	{
		private sealed class Class13
		{
			public readonly long Key;

			public readonly TerminatorClassifier terminatorClassifier_0;

			public Class13 rUxypDbwoBJ;

			public Class13 class13_0;

			public Class13(long long_0, TerminatorClassifier terminatorClassifier_1)
			{
				Key = long_0;
				terminatorClassifier_0 = terminatorClassifier_1;
			}

			static Class13()
			{
				Class72.smethod_20();
			}
		}

		public const int DefaultCapacity = 32;

		public const int DefaultResolutionSecs = 60;

		private readonly int int_0;

		private readonly int int_1;

		private readonly Dictionary<long, Class13> dictionary_0;

		private Class13 class13_0;

		private Class13 class13_1;

		private readonly LockObject lockObject_0;

		public int Count
		{
			get
			{
				lock (lockObject_0)
				{
					return dictionary_0.Count;
				}
			}
		}

		public TerminatorClassifierCache(int capacity = 32, int resolutionSecs = 60)
		{
			lockObject_0 = new LockObject();
			int_0 = Math.Max(1, capacity);
			int_1 = Math.Max(1, resolutionSecs);
			dictionary_0 = new Dictionary<long, Class13>(int_0);
		}

		public TerminatorClassifier GetOrCreate(long key)
		{
			Class13 value = null;
			if (dictionary_0.TryGetValue(key, out value))
			{
				return value.terminatorClassifier_0;
			}
			TerminatorClassifier terminatorClassifier = new TerminatorClassifier(method_3(key));
			lock (lockObject_0)
			{
				Class13 value2 = null;
				if (!dictionary_0.TryGetValue(key, out value2))
				{
					Class13 @class = new Class13(key, terminatorClassifier);
					method_0(@class);
					dictionary_0[key] = @class;
					if (dictionary_0.Count > int_0)
					{
						Class13 class2 = class13_1;
						method_2(class2);
						dictionary_0.Remove(class2.Key);
					}
					return terminatorClassifier;
				}
				method_1(value2);
				return value2.terminatorClassifier_0;
			}
		}

		public void Clear()
		{
			lock (lockObject_0)
			{
				dictionary_0.Clear();
				class13_0 = null;
				class13_1 = null;
			}
		}

		private void method_0(Class13 class13_2)
		{
			class13_2.rUxypDbwoBJ = null;
			class13_2.class13_0 = class13_0;
			if (class13_0 != null)
			{
				class13_0.rUxypDbwoBJ = class13_2;
			}
			class13_0 = class13_2;
			if (class13_1 == null)
			{
				class13_1 = class13_2;
			}
		}

		private void method_1(Class13 class13_2)
		{
			if (class13_2 != class13_0)
			{
				method_2(class13_2);
				method_0(class13_2);
			}
		}

		private void method_2(Class13 class13_2)
		{
			if (class13_2.rUxypDbwoBJ == null)
			{
				class13_0 = class13_2.class13_0;
			}
			else
			{
				class13_2.rUxypDbwoBJ.class13_0 = class13_2.class13_0;
			}
			if (class13_2.class13_0 == null)
			{
				class13_1 = class13_2.rUxypDbwoBJ;
			}
			else
			{
				class13_2.class13_0.rUxypDbwoBJ = class13_2.rUxypDbwoBJ;
			}
			class13_2.rUxypDbwoBJ = null;
			class13_2.class13_0 = null;
		}

		internal long QuantiseToKey(int y, int mo, int d, int h, int mn, int s)
		{
			long num = (14L - mo) / 12L;
			long num2 = y + 4800L - num;
			long num3 = mo + 12L * num - 3L;
			return ((d + (153L * num3 + 2L) / 5L + 365L * num2 + num2 / 4L - num2 / 100L + num2 / 400L - 32045L - 2440588L) * 86400L + h * 3600L + mn * 60L + s) / int_1;
		}

		private DateTime method_3(long long_0)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds((double)long_0 * (double)int_1);
		}

		static TerminatorClassifierCache()
		{
			Class72.smethod_20();
		}
	}

	public const double TwilightDegrees = -12.0;

	private static readonly TerminatorClassifierCache terminatorClassifierCache_0;

	static SunModule()
	{
		Class72.smethod_20();
		terminatorClassifierCache_0 = new TerminatorClassifierCache();
	}

	public static int SPA_Calculate(ref SpaData spa)
	{
		int num = smethod_7(ref spa);
		if (num != 0)
		{
			return num;
		}
		double num2 = smethod_1(spa.year, spa.month, spa.day, spa.hour, spa.minute, spa.second, spa.delta_ut1);
		double num3 = num2 + spa.delta_t / 86400.0;
		double num4 = (num2 - 2451545.0) / 36525.0;
		double num5 = (num3 - 2451545.0) / 36525.0;
		double double_ = num5 / 10.0;
		double num6 = smethod_2(double_);
		double num7 = smethod_3(double_);
		double num8 = smethod_4(double_);
		double num9 = num6 + 180.0;
		double double_2 = 0.0 - num7;
		double double_3 = 0.0;
		double double_4 = 0.0;
		smethod_5(num5, ref double_3, ref double_4);
		double double_5 = smethod_6(double_) / 3600.0 + double_4;
		double num10 = -20.4898 / (num8 * 3600.0);
		double double_6 = num9 + double_3 + num10;
		double num11 = smethod_8(double_2);
		double num12 = smethod_8(double_5);
		double num13 = smethod_8(double_6);
		double double_7 = smethod_9(Math.Atan2(Math.Sin(num13) * Math.Cos(num12) - Math.Tan(num11) * Math.Sin(num12), Math.Cos(num13)));
		double_7 = smethod_10(double_7);
		double num14 = smethod_9(Math.Asin(Math.Sin(num11) * Math.Cos(num12) + Math.Cos(num11) * Math.Sin(num12) * Math.Sin(num13)));
		double num15 = smethod_10(280.46061837 + 360.98564736629 * (num2 - 2451545.0) + 0.000387933 * num4 * num4 - num4 * num4 * num4 / 38710000.0) + double_3 * Math.Cos(smethod_8(double_5));
		double num16 = smethod_10(num15 + spa.longitude - double_7);
		if (num16 > 180.0)
		{
			num16 -= 360.0;
		}
		double double_8 = 8.794 / (3600.0 * num8);
		double num17 = Math.Atan(0.99664719 * Math.Tan(smethod_8(spa.latitude)));
		double num18 = Math.Cos(num17) + spa.elevation / 6378140.0 * Math.Cos(smethod_8(spa.latitude));
		double num19 = 0.99664719 * Math.Sin(num17) + spa.elevation / 6378140.0 * Math.Sin(smethod_8(spa.latitude));
		double num20 = smethod_9(Math.Atan2((0.0 - num18) * Math.Sin(smethod_8(double_8)) * Math.Sin(smethod_8(num16)), Math.Cos(smethod_8(num14)) - num18 * Math.Sin(smethod_8(double_8)) * Math.Cos(smethod_8(num16))));
		double double_9 = smethod_9(Math.Atan2((Math.Sin(smethod_8(num14)) - num19 * Math.Sin(smethod_8(double_8))) * Math.Cos(smethod_8(num20)), Math.Cos(smethod_8(num14)) - num18 * Math.Sin(smethod_8(double_8)) * Math.Cos(smethod_8(num16))));
		double double_10 = num16 - num20;
		double num21 = smethod_8(spa.latitude);
		double num22 = smethod_8(double_9);
		double num23 = smethod_8(double_10);
		double num24 = smethod_9(Math.Asin(Math.Sin(num21) * Math.Sin(num22) + Math.Cos(num21) * Math.Cos(num22) * Math.Cos(num23)));
		double num25 = 0.0;
		if (num24 >= -0.8333699999999999)
		{
			double num26 = Math.Tan(smethod_8(num24 + 10.3 / (num24 + 5.11)));
			if (Math.Abs(num26) > 1E-12)
			{
				num25 = spa.pressure / 1010.0 * (283.0 / (273.0 + spa.temperature)) * 1.02 / (60.0 * num26);
			}
		}
		double num27 = num24 + num25;
		spa.zenith = 90.0 - num27;
		double double_11 = Math.Atan2(Math.Sin(num23), Math.Cos(num23) * Math.Sin(num21) - Math.Tan(num22) * Math.Cos(num21));
		spa.azimuth = smethod_10(smethod_9(double_11) + 180.0);
		double num28 = smethod_8(spa.zenith);
		double num29 = smethod_8(spa.slope);
		double num30 = smethod_8(spa.azm_rotation);
		spa.incidence = smethod_9(Math.Acos(Math.Cos(num28) * Math.Cos(num29) + Math.Sin(num29) * Math.Sin(num28) * Math.Cos(smethod_8(spa.azimuth) - Math.PI - num30)));
		smethod_0(ref spa, num2, num5, num15, num14, double_7);
		return 0;
	}

	private static void smethod_0(ref SpaData spaData_0, double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		double num = smethod_8(spaData_0.latitude);
		double num2 = smethod_8(double_3);
		double num3 = (Math.Sin(smethod_8(-0.8333)) - Math.Sin(num) * Math.Sin(num2)) / (Math.Cos(num) * Math.Cos(num2));
		if (num3 < -1.0)
		{
			spaData_0.sunrise = -1.0;
			spaData_0.sunset = -1.0;
			spaData_0.suntransit = 12.0;
			return;
		}
		if (num3 > 1.0)
		{
			spaData_0.sunrise = -1.0;
			spaData_0.sunset = -1.0;
			spaData_0.suntransit = 12.0;
			return;
		}
		double num4 = smethod_9(Math.Acos(num3));
		double num5 = (double_4 - spaData_0.longitude - double_2) / 360.0;
		num5 -= (double)RadarModel.Floor(num5);
		spaData_0.suntransit = num5 * 24.0;
		spaData_0.sunrise = (num5 - num4 / 360.0) * 24.0;
		spaData_0.sunset = (num5 + num4 / 360.0) * 24.0;
	}

	private static double smethod_1(int int_0, int int_1, int int_2, int int_3, int int_4, double double_0, double double_1)
	{
		if (int_1 <= 2)
		{
			int_0--;
			int_1 += 12;
		}
		long num = (long)((double)int_0 / 100.0);
		long num2 = 2L - num + (long)((double)num / 4.0);
		double num3 = (double)int_2 + ((double)int_3 + ((double)int_4 + (double_0 + double_1) / 60.0) / 60.0) / 24.0;
		return (double)((long)(365.25 * (double)(int_0 + 4716)) + (long)(30.6001 * (double)(int_1 + 1))) + num3 + (double)num2 - 1524.5;
	}

	private static double smethod_2(double double_0)
	{
		double num = 175347046.0 + 3341656.0 * Math.Cos(3.1415926 + 6283.07585 * double_0) + 34894.0 * Math.Cos(3.14159 + 12566.1517 * double_0) + 3497.0 * Math.Cos(5.791 + 5753.3849 * double_0) + 3418.0 * Math.Cos(5.4828 + 3.5231 * double_0) + 3136.0 * Math.Cos(0.649 + 77713.7715 * double_0) + 2676.0 * Math.Cos(1.8197 + 7860.4194 * double_0) + 2343.0 * Math.Cos(0.3517 + 3930.2097 * double_0) + 1324.0 * Math.Cos(0.7425 + 11506.7698 * double_0) + 1273.0 * Math.Cos(2.0371 + 529.691 * double_0) + 1199.0 * Math.Cos(1.1096 + 1577.3435 * double_0) + 990.0 * Math.Cos(5.233 + 5884.927 * double_0) + 902.0 * Math.Cos(2.045 + 26.298 * double_0) + 857.0 * Math.Cos(3.508 + 398.149 * double_0) + 780.0 * Math.Cos(1.179 + 5223.694 * double_0) + 753.0 * Math.Cos(2.533 + 5507.553 * double_0) + 505.0 * Math.Cos(4.583 + 18849.228 * double_0) + 492.0 * Math.Cos(4.205 + 775.523 * double_0) + 357.0 * Math.Cos(2.92 + 0.067 * double_0) + 317.0 * Math.Cos(5.849 + 11790.629 * double_0) + 284.0 * Math.Cos(1.899 + 796.298 * double_0) + 271.0 * Math.Cos(0.315 + 10977.079 * double_0) + 243.0 * Math.Cos(0.345 + 5486.778 * double_0) + 206.0 * Math.Cos(4.806 + 2544.314 * double_0) + 205.0 * Math.Cos(1.869 + 5573.143 * double_0) + 202.0 * Math.Cos(2.458 + 6069.777 * double_0) + 156.0 * Math.Cos(0.833 + 213.299 * double_0) + 132.0 * Math.Cos(3.411 + 2942.463 * double_0) + 126.0 * Math.Cos(1.083 + 20.775 * double_0) + 115.0 * Math.Cos(0.645 + 0.98 * double_0) + 103.0 * Math.Cos(0.636 + 4694.003 * double_0) + 99.0 * Math.Cos(6.21 + 15720.84 * double_0) + 98.0 * Math.Cos(0.68 + 7084.9 * double_0) + 86.0 * Math.Cos(5.98 + 11243.69 * double_0) + 86.0 * Math.Cos(1.27 + 161000.69 * double_0) + 65.0 * Math.Cos(1.43 + 17260.15 * double_0) + 63.0 * Math.Cos(1.05 + 5088.63 * double_0) + 57.0 * Math.Cos(3.44 + 796.3 * double_0) + 56.0 * Math.Cos(4.39 + 10447.39 * double_0) + 49.0 * Math.Cos(0.49 + 5614.73 * double_0) + 45.0 * Math.Cos(5.2 + 12036.46 * double_0) + 43.0 * Math.Cos(1.42 + 2942.46 * double_0) + 39.0 * Math.Cos(2.95 + 9830.51 * double_0) + 38.0 * Math.Cos(0.56 + 4690.48 * double_0) + 37.0 * Math.Cos(1.87 + 7058.6 * double_0) + 32.0 * Math.Cos(1.78 + 4292.33 * double_0) + 29.0 * Math.Cos(3.4 + 20426.57 * double_0) + 28.0 * Math.Cos(1.21 + 5746.27 * double_0) + 27.0 * Math.Cos(2.21 + 9225.54 * double_0) + 27.0 * Math.Cos(5.18 + 1059.38 * double_0) + 25.0 * Math.Cos(3.16 + 10213.29 * double_0);
		double num2 = 628331966747.0 + 206059.0 * Math.Cos(2.678235 + 6283.07585 * double_0) + 4303.0 * Math.Cos(2.6351 + 12566.1517 * double_0) + 425.0 * Math.Cos(1.59 + 3.523 * double_0) + 119.0 * Math.Cos(5.796 + 26.298 * double_0) + 109.0 * Math.Cos(2.966 + 1577.344 * double_0) + 93.0 * Math.Cos(2.59 + 18849.23 * double_0) + 72.0 * Math.Cos(1.14 + 529.69 * double_0) + 68.0 * Math.Cos(1.87 + 398.15 * double_0) + 67.0 * Math.Cos(4.41 + 5507.55 * double_0) + 59.0 * Math.Cos(2.89 + 5223.69 * double_0) + 56.0 * Math.Cos(2.17 + 155.42 * double_0) + 45.0 * Math.Cos(0.4 + 796.3 * double_0) + 36.0 * Math.Cos(0.47 + 775.52 * double_0) + 29.0 * Math.Cos(2.65 + 7.11 * double_0) + 21.0 * Math.Cos(5.34 + 0.98 * double_0) + 19.0 * Math.Cos(1.85 + 5486.78 * double_0) + 19.0 * Math.Cos(4.97 + 213.3 * double_0) + 17.0 * Math.Cos(2.99 + 6275.96 * double_0) + 16.0 * Math.Cos(0.03 + 2544.31 * double_0) + 16.0 * Math.Cos(1.43 + 2146.17 * double_0) + 15.0 * Math.Cos(1.21 + 10977.08 * double_0) + 12.0 * Math.Cos(2.83 + 1748.02 * double_0) + 12.0 * Math.Cos(3.26 + 5088.63 * double_0) + 12.0 * Math.Cos(5.27 + 1194.45 * double_0) + 12.0 * Math.Cos(2.08 + 4694.0 * double_0) + 11.0 * Math.Cos(0.77 + 553.57 * double_0) + 10.0 * Math.Cos(1.3 + 6286.6 * double_0) + 10.0 * Math.Cos(4.24 + 1349.87 * double_0) + 9.0 * Math.Cos(2.7 + 242.73 * double_0) + 9.0 * Math.Cos(5.64 + 951.72 * double_0) + 8.0 * Math.Cos(5.3 + 2352.87 * double_0) + 6.0 * Math.Cos(2.65 + 9437.76 * double_0) + 6.0 * Math.Cos(4.67 + 4690.48 * double_0);
		double num3 = 52919.0 + 8720.0 * Math.Cos(1.0721 + 6283.0758 * double_0) + 309.0 * Math.Cos(0.867 + 12566.152 * double_0) + 27.0 * Math.Cos(0.05 + 3.52 * double_0) + 16.0 * Math.Cos(5.19 + 26.3 * double_0) + 16.0 * Math.Cos(3.68 + 155.42 * double_0) + 10.0 * Math.Cos(0.76 + 18849.23 * double_0) + 9.0 * Math.Cos(2.06 + 77713.77 * double_0) + 7.0 * Math.Cos(0.83 + 775.52 * double_0) + 5.0 * Math.Cos(4.66 + 1577.34 * double_0) + 4.0 * Math.Cos(1.03 + 7.11 * double_0) + 4.0 * Math.Cos(3.44 + 5573.14 * double_0) + 3.0 * Math.Cos(5.14 + 796.3 * double_0) + 3.0 * Math.Cos(6.05 + 5507.55 * double_0) + 3.0 * Math.Cos(1.19 + 242.73 * double_0) + 3.0 * Math.Cos(6.12 + 529.69 * double_0) + 3.0 * Math.Cos(0.31 + 398.15 * double_0) + 3.0 * Math.Cos(2.28 + 553.57 * double_0) + 2.0 * Math.Cos(4.38 + 5223.69 * double_0) + 2.0 * Math.Cos(3.75 + 0.98 * double_0);
		double num4 = 289.0 + 35.0 * Math.Cos(5.47 + 6283.076 * double_0) + 17.0 * Math.Cos(3.69 + 12566.15 * double_0) + 3.0 * Math.Cos(5.2 + 155.42 * double_0) + 1.0 * Math.Cos(4.72 + 3.52 * double_0) + 1.0 * Math.Cos(5.3 + 18849.23 * double_0) + 1.0 * Math.Cos(5.97 + 242.73 * double_0);
		double num5 = 114.0 + 8.0 * Math.Cos(4.13 + 6283.08 * double_0) + 1.0 * Math.Cos(3.84 + 12566.15 * double_0);
		double num6 = 1.0 * Math.Cos(3.14);
		return smethod_10(smethod_9((num + num2 * double_0 + num3 * Math.Pow(double_0, 2.0) + num4 * Math.Pow(double_0, 3.0) + num5 * Math.Pow(double_0, 4.0) + num6 * Math.Pow(double_0, 5.0)) / 100000000.0));
	}

	private static double smethod_3(double double_0)
	{
		double num = 280.0 * Math.Cos(3.199 + 84334.662 * double_0) + 102.0 * Math.Cos(5.422 + 5507.553 * double_0) + 80.0 * Math.Cos(3.88 + 5223.69 * double_0) + 44.0 * Math.Cos(3.7 + 2352.87 * double_0) + 32.0 * Math.Cos(4.0 + 1577.34 * double_0);
		double num2 = 9.0 * Math.Cos(3.9 + 5507.55 * double_0) + 6.0 * Math.Cos(1.73 + 5223.69 * double_0);
		return smethod_9((num + num2 * double_0) / 100000000.0);
	}

	private static double smethod_4(double double_0)
	{
		double num = 100013989.0 + 1670700.0 * Math.Cos(3.0984635 + 6283.07585 * double_0) + 13956.0 * Math.Cos(3.05525 + 12566.1517 * double_0) + 3084.0 * Math.Cos(5.1985 + 77713.7715 * double_0) + 1628.0 * Math.Cos(1.1739 + 5753.3849 * double_0) + 1576.0 * Math.Cos(2.8469 + 7860.4194 * double_0) + 925.0 * Math.Cos(5.453 + 11506.77 * double_0) + 542.0 * Math.Cos(4.564 + 3930.21 * double_0) + 472.0 * Math.Cos(3.661 + 5884.927 * double_0) + 346.0 * Math.Cos(0.964 + 5507.553 * double_0) + 329.0 * Math.Cos(5.9 + 5223.694 * double_0) + 307.0 * Math.Cos(0.299 + 5573.143 * double_0) + 243.0 * Math.Cos(4.273 + 11790.629 * double_0) + 212.0 * Math.Cos(5.847 + 1577.344 * double_0) + 186.0 * Math.Cos(5.022 + 10977.079 * double_0) + 175.0 * Math.Cos(3.012 + 18849.228 * double_0) + 110.0 * Math.Cos(5.055 + 5486.778 * double_0) + 98.0 * Math.Cos(0.89 + 6069.78 * double_0) + 86.0 * Math.Cos(5.69 + 15720.84 * double_0) + 86.0 * Math.Cos(1.27 + 161000.69 * double_0) + 65.0 * Math.Cos(0.27 + 17260.15 * double_0) + 63.0 * Math.Cos(0.92 + 529.69 * double_0) + 57.0 * Math.Cos(2.01 + 83996.85 * double_0) + 56.0 * Math.Cos(5.24 + 71430.7 * double_0) + 49.0 * Math.Cos(3.25 + 2544.31 * double_0) + 47.0 * Math.Cos(2.58 + 775.52 * double_0) + 45.0 * Math.Cos(5.54 + 9437.76 * double_0) + 43.0 * Math.Cos(6.01 + 10447.39 * double_0) + 39.0 * Math.Cos(5.36 + 5573.14 * double_0) + 38.0 * Math.Cos(2.39 + 1748.02 * double_0) + 37.0 * Math.Cos(0.83 + 7084.9 * double_0) + 37.0 * Math.Cos(4.9 + 14712.32 * double_0) + 36.0 * Math.Cos(1.67 + 4694.0 * double_0) + 35.0 * Math.Cos(1.84 + 4690.48 * double_0) + 33.0 * Math.Cos(0.24 + 6275.96 * double_0) + 32.0 * Math.Cos(0.18 + 12139.55 * double_0);
		double num2 = 103019.0 * Math.Cos(1.10749 + 6283.07585 * double_0) + 1721.0 * Math.Cos(1.0644 + 12566.1517 * double_0) + 702.0 * Math.Cos(3.142 + 0.0 * double_0) + 32.0 * Math.Cos(1.02 + 18849.23 * double_0) + 31.0 * Math.Cos(2.84 + 5507.55 * double_0) + 25.0 * Math.Cos(1.32 + 5223.69 * double_0) + 18.0 * Math.Cos(1.42 + 1577.34 * double_0) + 10.0 * Math.Cos(5.91 + 10977.08 * double_0) + 9.0 * Math.Cos(1.42 + 6275.96 * double_0) + 9.0 * Math.Cos(0.27 + 5486.78 * double_0);
		double num3 = 4359.0 * Math.Cos(5.7846 + 6283.0758 * double_0) + 124.0 * Math.Cos(5.579 + 12566.152 * double_0) + 12.0 * Math.Cos(3.14 + 0.0 * double_0) + 9.0 * Math.Cos(3.63 + 77713.77 * double_0) + 6.0 * Math.Cos(1.87 + 5573.14 * double_0) + 3.0 * Math.Cos(5.47 + 18849.23 * double_0);
		double num4 = 145.0 * Math.Cos(4.273 + 6283.076 * double_0) + 7.0 * Math.Cos(3.92 + 12566.15 * double_0);
		double num5 = 4.0 * Math.Cos(2.56 + 6283.08 * double_0);
		return (num + num2 * double_0 + num3 * Math.Pow(double_0, 2.0) + num4 * Math.Pow(double_0, 3.0) + num5 * Math.Pow(double_0, 4.0)) / 100000000.0;
	}

	private static void smethod_5(double double_0, ref double double_1, ref double double_2)
	{
		double num = 297.85036 + 445267.11148 * double_0 - 0.0019142 * Math.Pow(double_0, 2.0) + Math.Pow(double_0, 3.0) / 189474.0;
		double num2 = 357.52772 + 35999.05034 * double_0 - 0.0001603 * Math.Pow(double_0, 2.0) - Math.Pow(double_0, 3.0) / 300000.0;
		double num3 = 134.96298 + 477198.867398 * double_0 + 0.0086972 * Math.Pow(double_0, 2.0) + Math.Pow(double_0, 3.0) / 56250.0;
		double num4 = 93.27191 + 483202.017538 * double_0 - 0.0036825 * Math.Pow(double_0, 2.0) + Math.Pow(double_0, 3.0) / 327270.0;
		double num5 = 125.04452 - 1934.136261 * double_0 + 0.0020708 * Math.Pow(double_0, 2.0) + Math.Pow(double_0, 3.0) / 450000.0;
		int[,] array = new int[63, 9]
		{
			{ 0, 0, 0, 0, 1, -171996, -174, 92025, 89 },
			{ -2, 0, 0, 2, 2, -13187, -1, 5736, -31 },
			{ 0, 0, 0, 2, 2, -2274, 0, 977, -5 },
			{ 0, 0, 0, 0, 2, 2062, 2, -895, 5 },
			{ 0, 1, 0, 0, 0, 1426, -34, 54, -1 },
			{ 0, 0, 1, 0, 0, 712, 1, -7, 0 },
			{ -2, 1, 0, 2, 2, -517, 12, 224, -6 },
			{ 0, 0, 0, 2, 1, -386, -4, 200, 0 },
			{ 0, 0, 1, 2, 2, -301, 0, 129, -1 },
			{ -2, -1, 0, 2, 2, 217, -5, -95, 3 },
			{ -2, 0, 1, 0, 0, -158, 0, 0, 0 },
			{ -2, 0, 0, 2, 1, 129, 1, -70, 0 },
			{ 0, 0, -1, 2, 2, 123, 0, -53, 0 },
			{ 2, 0, 0, 0, 0, 63, 0, 0, 0 },
			{ 0, 0, 1, 0, 1, 63, 1, -33, 0 },
			{ 2, 0, -1, 2, 2, -59, 0, 26, 0 },
			{ 0, 0, -1, 0, 1, -58, -1, 32, 0 },
			{ 0, 0, 1, 2, 1, -51, 0, 27, 0 },
			{ -2, 0, 2, 0, 0, 48, 0, 0, 0 },
			{ 0, 0, -2, 2, 1, 46, 0, -24, 0 },
			{ 2, 0, 0, 2, 2, -38, 0, 16, 0 },
			{ 0, 0, 2, 2, 2, -31, 0, 13, 0 },
			{ 0, 0, 2, 0, 0, 29, 0, 0, 0 },
			{ -2, 0, 1, 2, 2, 29, 0, -12, 0 },
			{ 0, 0, 0, 2, 0, 26, 0, 0, 0 },
			{ -2, 0, 0, 2, 0, -22, 0, 0, 0 },
			{ 0, 0, -1, 2, 1, 21, 0, -10, 0 },
			{ 0, 2, 0, 0, 0, 17, -1, 0, 0 },
			{ 2, 0, -1, 0, 1, 16, 0, -8, 0 },
			{ -2, 2, 0, 2, 2, -16, 1, 7, 0 },
			{ 0, 1, 0, 0, 1, -15, 0, 9, 0 },
			{ -2, 0, 1, 0, 1, -13, 0, 7, 0 },
			{ 0, -1, 0, 0, 1, -12, 0, 6, 0 },
			{ 0, 0, 2, -2, 0, 11, 0, 0, 0 },
			{ 2, 0, -1, 2, 1, -10, 0, 5, 0 },
			{ 2, 0, 1, 2, 2, -8, 0, 3, 0 },
			{ 0, 1, 0, 2, 2, 7, 0, -3, 0 },
			{ -2, 1, 1, 0, 0, -7, 0, 0, 0 },
			{ 0, -1, 0, 2, 2, -7, 0, 3, 0 },
			{ 2, 0, 0, 2, 1, -7, 0, 3, 0 },
			{ 2, 0, 1, 0, 0, 6, 0, 0, 0 },
			{ -2, 0, 2, 2, 2, 6, 0, -3, 0 },
			{ -2, 0, 1, 2, 1, 6, 0, -3, 0 },
			{ 2, 0, -2, 0, 1, -6, 0, 3, 0 },
			{ 2, 0, 0, 0, 1, -6, 0, 3, 0 },
			{ 0, -1, 1, 0, 0, 5, 0, 0, 0 },
			{ -2, -1, 0, 2, 1, -5, 0, 3, 0 },
			{ -2, 0, 0, 0, 1, -5, 0, 3, 0 },
			{ 0, 0, 2, 2, 1, -5, 0, 3, 0 },
			{ -2, 0, 2, 0, 1, 4, 0, 0, 0 },
			{ -2, 1, 0, 2, 1, 4, 0, 0, 0 },
			{ 0, 0, 1, -2, 0, 4, 0, 0, 0 },
			{ -1, 0, 1, 0, 0, -4, 0, 0, 0 },
			{ -2, 1, 0, 0, 0, -4, 0, 0, 0 },
			{ 1, 0, 0, 0, 0, -4, 0, 0, 0 },
			{ 0, 0, 1, 2, 0, 3, 0, 0, 0 },
			{ 0, 0, -2, 2, 2, -3, 0, 1, 0 },
			{ -1, -1, 1, 0, 0, -3, 0, 0, 0 },
			{ 0, 1, 1, 0, 0, -3, 0, 0, 0 },
			{ 0, -1, 1, 2, 2, -3, 0, 1, 0 },
			{ 2, -1, -1, 2, 2, -3, 0, 1, 0 },
			{ 0, 0, 3, 2, 2, -3, 0, 1, 0 },
			{ 2, -1, 0, 2, 2, -3, 0, 1, 0 }
		};
		double[] array2 = new double[5] { num, num2, num3, num4, num5 };
		double num6 = 0.0;
		double num7 = 0.0;
		int upperBound = array.GetUpperBound(0);
		for (int i = 0; i <= upperBound; i++)
		{
			double num8 = 0.0;
			int num9 = 0;
			do
			{
				num8 += (double)array[i, num9] * array2[num9];
				num9++;
			}
			while (num9 <= 4);
			double num10 = smethod_8(num8);
			num6 += ((double)array[i, 5] + (double)array[i, 6] * double_0) * Math.Sin(num10);
			num7 += ((double)array[i, 7] + (double)array[i, 8] * double_0) * Math.Cos(num10);
		}
		double_1 = num6 / 36000000.0;
		double_2 = num7 / 36000000.0;
	}

	private static double smethod_6(double double_0)
	{
		double num = double_0 / 10.0;
		return 84381.448 - 4680.93 * num - 1.55 * Math.Pow(num, 2.0) + 1999.25 * Math.Pow(num, 3.0) - 51.38 * Math.Pow(num, 4.0) - 249.67 * Math.Pow(num, 5.0) - 39.05 * Math.Pow(num, 6.0) + 7.12 * Math.Pow(num, 7.0) + 27.87 * Math.Pow(num, 8.0) + 5.79 * Math.Pow(num, 9.0) + 2.45 * Math.Pow(num, 10.0);
	}

	private static int smethod_7(ref SpaData spaData_0)
	{
		int result;
		if (spaData_0.year < -2000)
		{
			result = 1;
		}
		else
		{
			if (spaData_0.year <= 6000)
			{
				int result7;
				if (spaData_0.month >= 1)
				{
					if (spaData_0.month <= 12)
					{
						int result6;
						if (spaData_0.day >= 1)
						{
							if (spaData_0.day <= 31)
							{
								int result5;
								if (spaData_0.hour >= 0)
								{
									if (spaData_0.hour <= 23)
									{
										int result4;
										if (spaData_0.minute >= 0)
										{
											if (spaData_0.minute <= 59)
											{
												int result3;
												if (!(spaData_0.second < 0.0))
												{
													if (!(spaData_0.second >= 60.0))
													{
														if (Math.Abs(spaData_0.latitude) > 90.0)
														{
															return 7;
														}
														if (Math.Abs(spaData_0.longitude) > 180.0)
														{
															return 8;
														}
														if (spaData_0.elevation < -6500000.0)
														{
															return 9;
														}
														int result2;
														if (!(spaData_0.pressure < 0.0))
														{
															if (!(spaData_0.pressure > 5000.0))
															{
																if (Math.Abs(spaData_0.temperature) > 273.0)
																{
																	return 13;
																}
																return 0;
															}
															result2 = 12;
														}
														else
														{
															result2 = 12;
														}
														return result2;
													}
													result3 = 6;
												}
												else
												{
													result3 = 6;
												}
												return result3;
											}
											result4 = 5;
										}
										else
										{
											result4 = 5;
										}
										return result4;
									}
									result5 = 4;
								}
								else
								{
									result5 = 4;
								}
								return result5;
							}
							result6 = 3;
						}
						else
						{
							result6 = 3;
						}
						return result6;
					}
					result7 = 2;
				}
				else
				{
					result7 = 2;
				}
				return result7;
			}
			result = 1;
		}
		return result;
	}

	private static double smethod_8(double double_0)
	{
		return double_0 * Math.PI / 180.0;
	}

	private static double smethod_9(double double_0)
	{
		return double_0 * 180.0 / Math.PI;
	}

	private static double smethod_10(double double_0)
	{
		double num = double_0 / 360.0;
		double num2 = 360.0 * (num - (double)RadarModel.Floor(num));
		if (num2 < 0.0)
		{
			num2 += 360.0;
		}
		return num2;
	}

	internal static Weather.TTimeOfDayType GetTOD_2(DateTime DT, ref Geodesic_Vincenty.TCoord Location, double ObserverHeight = 0.0)
	{
		return GetTimeOfDay(null, DT.Year, DT.Month, DT.Day, DT.Hour, DT.Minute, DT.Second, UseCurrentScenarioTime: false, Location.Lat, Location.Lon, ObserverHeight);
	}

	internal static Weather.TTimeOfDayType GetTOD_2(DateTime DT, double dLatitude, double dLongitude, double dObserverHeight)
	{
		return GetTimeOfDay(null, DT.Year, DT.Month, DT.Day, DT.Hour, DT.Minute, DT.Second, UseCurrentScenarioTime: false, dLatitude, dLongitude, dObserverHeight);
	}

	internal static Weather.TTimeOfDayType GetTimeOfDay(Scenario theScen, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond, bool UseCurrentScenarioTime, double dLatitude, double dLongitude, double dObserverHeight)
	{
		long key = terminatorClassifierCache_0.QuantiseToKey(iYear, iMonth, iDay, iHour, iMinute, iSecond);
		return terminatorClassifierCache_0.GetOrCreate(key).Classify(dLatitude, dLongitude);
	}

	internal static string GetTimeOfDay_String(Weather.TTimeOfDayType TOD, DateTime theTime, double theLon, bool theDST, string theDST_Start, string theDST_End)
	{
		switch (TOD)
		{
		default:
			return "-";
		case Weather.TTimeOfDayType.tod_Day:
			return "Day";
		case Weather.TTimeOfDayType.tod_Twilight:
			if (Misc.LocalTime(theTime, theLon, theDST, theDST_Start, theDST_End).Hour < 12)
			{
				return "Dawn";
			}
			return "Dusk";
		case Weather.TTimeOfDayType.tod_Night:
			return "Night";
		}
	}

	internal static Weather.TTimeOfDayType GetTimeOfDayTypeFromLocalTime(DateTime localTime)
	{
		TimeSpan timeSpan = TimeSpan.FromHours(6.0);
		TimeSpan timeSpan2 = TimeSpan.FromHours(18.0);
		TimeSpan timeSpan3 = TimeSpan.FromHours(20.0);
		TimeSpan timeSpan4 = TimeSpan.FromHours(22.0);
		TimeSpan timeOfDay = localTime.TimeOfDay;
		if (timeOfDay >= timeSpan && timeOfDay < timeSpan2)
		{
			return Weather.TTimeOfDayType.tod_Day;
		}
		if (timeOfDay >= timeSpan2 && timeOfDay < timeSpan3)
		{
			return Weather.TTimeOfDayType.tod_Twilight;
		}
		if ((!(timeOfDay >= timeSpan3) || !(timeOfDay < timeSpan4)) && !(timeOfDay < timeSpan))
		{
			return Weather.TTimeOfDayType.tod_Twilight;
		}
		return Weather.TTimeOfDayType.tod_Night;
	}
}
