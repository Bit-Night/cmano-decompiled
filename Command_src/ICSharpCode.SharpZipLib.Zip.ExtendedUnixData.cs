using System;
using System.IO;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip;

public class ExtendedUnixData : ITaggedData
{
	[Flags]
	public enum Flags : byte
	{
		ModificationTime = 1,
		AccessTime = 2,
		CreateTime = 4
	}

	private Flags flags_0;

	private DateTime dateTime_0 = new DateTime(1970, 1, 1);

	private DateTime dateTime_1 = new DateTime(1970, 1, 1);

	private DateTime dateTime_2 = new DateTime(1970, 1, 1);

	public ushort TagID => 21589;

	public DateTime ModificationTime
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
			flags_0 |= Flags.ModificationTime;
			dateTime_0 = value;
		}
	}

	public DateTime AccessTime
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
			flags_0 |= Flags.AccessTime;
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
			flags_0 |= Flags.CreateTime;
			dateTime_2 = value;
		}
	}

	public Flags Include
	{
		get
		{
			return flags_0;
		}
		set
		{
			flags_0 = value;
		}
	}

	public void SetData(byte[] data, int index, int count)
	{
		using MemoryStream memoryStream = new MemoryStream(data, index, count, writable: false);
		flags_0 = (Flags)memoryStream.ReadByte();
		if ((flags_0 & Flags.ModificationTime) != 0)
		{
			int seconds = memoryStream.smethod_7();
			dateTime_0 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) + new TimeSpan(0, 0, 0, seconds, 0);
			if (count <= 5)
			{
				return;
			}
		}
		if ((flags_0 & Flags.AccessTime) != 0)
		{
			int seconds2 = memoryStream.smethod_7();
			dateTime_1 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) + new TimeSpan(0, 0, 0, seconds2, 0);
		}
		if ((flags_0 & Flags.CreateTime) != 0)
		{
			int seconds3 = memoryStream.smethod_7();
			dateTime_2 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) + new TimeSpan(0, 0, 0, seconds3, 0);
		}
	}

	public byte[] GetData()
	{
		using MemoryStream memoryStream = new MemoryStream();
		memoryStream.WriteByte((byte)flags_0);
		if ((flags_0 & Flags.ModificationTime) != 0)
		{
			int value = (int)(dateTime_0 - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
			memoryStream.smethod_10(value);
		}
		if ((flags_0 & Flags.AccessTime) != 0)
		{
			int value2 = (int)(dateTime_1 - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
			memoryStream.smethod_10(value2);
		}
		if ((flags_0 & Flags.CreateTime) != 0)
		{
			int value3 = (int)(dateTime_2 - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
			memoryStream.smethod_10(value3);
		}
		return memoryStream.ToArray();
	}

	public static bool IsValidValue(DateTime value)
	{
		if (value >= new DateTime(1901, 12, 13, 20, 45, 52))
		{
			return true;
		}
		return value <= new DateTime(2038, 1, 19, 3, 14, 7);
	}

	static ExtendedUnixData()
	{
		Class72.smethod_20();
	}
}
