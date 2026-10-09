using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class DateTimeHelper
{
	public enum ParseDateTimeResult
	{
		Ok,
		BadDate,
		BadTime
	}

	public static int ParseDate(string strDate, ref DateTime dtOut)
	{
		if (!DateTime.TryParse(strDate, out dtOut))
		{
			return 1;
		}
		return 0;
	}

	public static int ParseTime(string strTime, ref DateTime dtOut)
	{
		if (DateTime.TryParse(strTime, out dtOut))
		{
			return 0;
		}
		return 2;
	}

	public static int ParseDateAndTime(string strDate, string strTime, ref DateTime dtOut)
	{
		int num = 0;
		DateTime dtOut2 = default(DateTime);
		num = ParseDate(strDate, ref dtOut2);
		if (num == 0)
		{
			num = ParseTime(strTime, ref dtOut2);
			if (num == 0 && !DateTime.TryParse(strDate + " " + strTime, out dtOut))
			{
				num = 2;
			}
		}
		return num;
	}

	static DateTimeHelper()
	{
		Class72.smethod_20();
	}
}
