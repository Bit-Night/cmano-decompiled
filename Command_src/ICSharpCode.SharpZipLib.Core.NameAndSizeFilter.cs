using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Core;

[Obsolete("Use ExtendedPathFilter instead")]
public class NameAndSizeFilter : PathFilter
{
	private long long_0;

	private long long_1 = long.MaxValue;

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

	public NameAndSizeFilter(string filter, long minSize, long maxSize)
		: base(filter)
	{
		MinSize = minSize;
		MaxSize = maxSize;
	}

	public override bool IsMatch(string name)
	{
		bool result;
		if (result = base.IsMatch(name))
		{
			long length = new FileInfo(name).Length;
			result = MinSize <= length && MaxSize >= length;
		}
		return result;
	}

	static NameAndSizeFilter()
	{
		Class72.smethod_20();
	}
}
