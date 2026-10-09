using System;
using System.IO;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip;

public class NTTaggedData : ITaggedData
{
	private DateTime dateTime_0 = DateTime.FromFileTimeUtc(0L);

	private DateTime dateTime_1 = DateTime.FromFileTimeUtc(0L);

	private DateTime dateTime_2 = DateTime.FromFileTimeUtc(0L);

	public ushort TagID => 10;

	public DateTime LastModificationTime
	{
		get
		{
			return dateTime_1;
		}
		set
		{
			if (!IsValidValue(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			dateTime_1 = value;
		}
	}

	public DateTime CreateTime
	{
		get
		{
			return dateTime_2;
		}
		set
		{
			if (!IsValidValue(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			dateTime_2 = value;
		}
	}

	public DateTime LastAccessTime
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			if (!IsValidValue(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			dateTime_0 = value;
		}
	}

	public void SetData(byte[] data, int index, int count)
	{
		using MemoryStream memoryStream = new MemoryStream(data, index, count, writable: false);
		memoryStream.smethod_7();
		int num2;
		while (true)
		{
			if (memoryStream.Position < memoryStream.Length)
			{
				int num = memoryStream.smethod_6();
				num2 = memoryStream.smethod_6();
				if (num == 1)
				{
					break;
				}
				memoryStream.Seek(num2, SeekOrigin.Current);
				continue;
			}
			return;
		}
		if (num2 >= 24)
		{
			long fileTime = memoryStream.smethod_8();
			dateTime_1 = DateTime.FromFileTimeUtc(fileTime);
			long fileTime2 = memoryStream.smethod_8();
			dateTime_0 = DateTime.FromFileTimeUtc(fileTime2);
			long fileTime3 = memoryStream.smethod_8();
			dateTime_2 = DateTime.FromFileTimeUtc(fileTime3);
		}
	}

	public byte[] GetData()
	{
		using MemoryStream memoryStream = new MemoryStream();
		memoryStream.smethod_10(0);
		ByteOrderStreamExtensions.WriteLEShort(memoryStream, 1);
		ByteOrderStreamExtensions.WriteLEShort(memoryStream, 24);
		memoryStream.smethod_12(dateTime_1.ToFileTimeUtc());
		memoryStream.smethod_12(dateTime_0.ToFileTimeUtc());
		memoryStream.smethod_12(dateTime_2.ToFileTimeUtc());
		return memoryStream.ToArray();
	}

	public static bool IsValidValue(DateTime value)
	{
		bool result = true;
		try
		{
			value.ToFileTimeUtc();
		}
		catch
		{
			result = false;
		}
		return result;
	}

	static NTTaggedData()
	{
		Class72.smethod_20();
	}
}
