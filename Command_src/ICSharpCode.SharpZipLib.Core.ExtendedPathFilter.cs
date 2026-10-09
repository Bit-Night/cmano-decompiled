using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Core;

public class ExtendedPathFilter : PathFilter
{
	private long long_0;

	private long long_1 = long.MaxValue;

	private DateTime dateTime_0 = DateTime.MinValue;

	private DateTime dateTime_1 = DateTime.MaxValue;

	public long MinSize
	{
		get
		{
			return long_0;
		}
		set
		{
			if (value < 0L || long_1 < value)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			long_0 = value;
		}
	}

	public long MaxSize
	{
		get
		{
			return long_1;
		}
		set
		{
			if (value < 0L || long_0 > value)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			long_1 = value;
		}
	}

	public DateTime MinDate
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			if (value > dateTime_1)
			{
				throw new ArgumentOutOfRangeException("value", "Exceeds MaxDate");
			}
			dateTime_0 = value;
		}
	}

	public DateTime MaxDate
	{
		get
		{
			return dateTime_1;
		}
		set
		{
			if (dateTime_0 > value)
			{
				throw new ArgumentOutOfRangeException("value", "Exceeds MinDate");
			}
			dateTime_1 = value;
		}
	}

	public ExtendedPathFilter(string filter, long minSize, long maxSize)
		: base(filter)
	{
		MinSize = minSize;
		MaxSize = maxSize;
	}

	public ExtendedPathFilter(string filter, DateTime minDate, DateTime maxDate)
		: base(filter)
	{
		MinDate = minDate;
		MaxDate = maxDate;
	}

	public ExtendedPathFilter(string filter, long minSize, long maxSize, DateTime minDate, DateTime maxDate)
		: base(filter)
	{
		MinSize = minSize;
		MaxSize = maxSize;
		MinDate = minDate;
		MaxDate = maxDate;
	}

	public override bool IsMatch(string name)
	{
		bool result;
		if (result = base.IsMatch(name))
		{
			FileInfo fileInfo = new FileInfo(name);
			result = MinSize <= fileInfo.Length && MaxSize >= fileInfo.Length && MinDate <= fileInfo.LastWriteTime && MaxDate >= fileInfo.LastWriteTime;
		}
		return result;
	}

	static ExtendedPathFilter()
	{
		Class72.smethod_20();
	}
}
