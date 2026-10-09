using System;
using System.Runtime.CompilerServices;

namespace OpenDis.Core;

public static class DisTime
{
	public static uint DisAbsoluteTimestamp => (Convert.ToUInt32(smethod_0()) << 1) | 1;

	public static uint DisRelativeTimestamp => (Convert.ToUInt32(smethod_0()) << 1) & 0xFFFFFFFEu;

	public static uint NpsTimestamp
	{
		get
		{
			DateTime now = DateTime.Now;
			DateTime dateTime = now;
			dateTime = dateTime.AddMilliseconds(-now.Millisecond).AddMinutes(-now.Minute).AddSeconds(-now.Second)
				.AddDays(1 - now.DayOfYear);
			return Convert.ToUInt32(now.Subtract(dateTime).TotalMilliseconds / 10.0);
		}
	}

	public static uint UnixTimestamp
	{
		get
		{
			DateTime utcNow = DateTime.UtcNow;
			DateTime value = new DateTime(1970, 1, 1);
			return Convert.ToUInt32(utcNow.Subtract(value).TotalSeconds);
		}
	}

	[SpecialName]
	private static int smethod_0()
	{
		DateTime now = DateTime.Now;
		DateTime dateTime = now;
		dateTime = dateTime.AddMilliseconds(-now.Millisecond).AddMinutes(-now.Minute).AddSeconds(-now.Second);
		return Convert.ToInt32(now.Subtract(dateTime).TotalMilliseconds / 3600000.0 * 2147483647.0);
	}

	public static int DisTimeUnitsSinceTopOfHour_CustomTime(int seconds)
	{
		return Convert.ToInt32(new TimeSpan(0, 0, seconds).TotalMilliseconds / 3600000.0 * 2147483647.0);
	}

	public static double DisTimeUnitsSinceTopOfHour_ToMilliSeconds(long theDisTimeUnitsSinceTopOfHour)
	{
		return (double)theDisTimeUnitsSinceTopOfHour * 3600.0 * 1000.0 / 2147483647.0;
	}

	static DisTime()
	{
		Class72.smethod_20();
	}
}
