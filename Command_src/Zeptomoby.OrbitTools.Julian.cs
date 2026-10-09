using System;
using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public class Julian
{
	[CompilerGenerated]
	private double double_0;

	public double Date
	{
		[CompilerGenerated]
		get
		{
			return double_0;
		}
		[CompilerGenerated]
		private set
		{
			double_0 = value;
		}
	}

	public double FromJan0_12h_1900()
	{
		return Date - 2415020.0;
	}

	public double FromJan1_00h_1900()
	{
		return Date - 2415020.5;
	}

	public double FromJan1_12h_1900()
	{
		return Date - 2415021.0;
	}

	public double FromJan1_12h_2000()
	{
		return Date - 2451545.0;
	}

	public Julian(DateTimeOffset time)
		: this(time.UtcDateTime)
	{
	}

	public Julian(DateTime utc)
	{
		double doy = (double)utc.DayOfYear + ((double)utc.Hour + ((double)utc.Minute + ((double)utc.Second + (double)utc.Millisecond / 1000.0) / 60.0) / 60.0) / 24.0;
		Initialize(utc.Year, doy);
	}

	public Julian(Julian julian)
	{
		Date = julian.Date;
	}

	public Julian(int year, double doy)
	{
		Initialize(year, doy);
	}

	public void AddDay(double day)
	{
		Date += day;
	}

	public void AddHour(double hr)
	{
		Date += hr / 24.0;
	}

	public void AddMin(double min)
	{
		Date += min / 1440.0;
	}

	public void AddSec(double sec)
	{
		Date += sec / 86400.0;
	}

	public TimeSpan Diff(Julian date)
	{
		return new TimeSpan((long)((Date - date.Date) * 864000000000.0));
	}

	protected void Initialize(int year, double doy)
	{
		if (year >= 1900 && year <= 2100)
		{
			if (doy < 1.0 || doy >= 367.0)
			{
				throw new ArgumentOutOfRangeException("doy");
			}
			year--;
			int num = year / 100;
			int num2 = 2 - num + num / 4;
			double num3 = (double)((int)(365.25 * (double)year) + 428) + 1720994.5 + (double)num2;
			Date = num3 + doy;
			return;
		}
		throw new ArgumentOutOfRangeException("year");
	}

	public double ToGmst()
	{
		double num = (Date + 0.5) % 1.0;
		double num2 = (FromJan1_12h_2000() - num) / 36525.0;
		double num3 = 24110.54841 + num2 * (8640184.812866 + num2 * (0.093104 - num2 * 6.2E-06));
		num3 = (num3 + 86636.555366976 * num) % 86400.0;
		if (num3 < 0.0)
		{
			num3 += 86400.0;
		}
		return Math.PI * 2.0 * (num3 / 86400.0);
	}

	public double ToLmst(double lon)
	{
		return (ToGmst() + lon) % (Math.PI * 2.0);
	}

	public DateTime ToTime()
	{
		int num = (int)(Date + 0.5);
		int num2 = (int)(((double)num - 1867216.25) / 36524.25);
		int num3 = num + 1 + num2 - num2 / 4 + 1524;
		int num4 = (int)(((double)num3 - 122.1) / 365.25);
		int num5 = (int)(365.25 * (double)num4);
		int num6 = (int)((double)(num3 - num5) / 30.6001);
		int year = ((((num6 <= 13) ? (num6 - 1) : (num6 - 13)) >= 3) ? (num4 - 4716) : (num4 - 4715));
		Julian julian = new Julian(year, 1.0);
		double value = Date - julian.Date;
		return new DateTime(year, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddDays(value);
	}

	static Julian()
	{
		Class72.smethod_20();
	}
}
