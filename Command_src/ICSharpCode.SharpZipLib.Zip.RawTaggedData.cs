using System;

namespace ICSharpCode.SharpZipLib.Zip;

public class RawTaggedData : ITaggedData
{
	private ushort ushort_0;

	private byte[] byte_0;

	public ushort TagID
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	public byte[] Data
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public RawTaggedData(ushort tag)
	{
		ushort_0 = tag;
	}

	public void SetData(byte[] data, int offset, int count)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		byte_0 = new byte[count];
		Array.Copy(data, offset, byte_0, 0, count);
	}

	public byte[] GetData()
	{
		return byte_0;
	}

	static RawTaggedData()
	{
		Class72.smethod_20();
	}
}
