using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace OpenDis.Core;

public class DataStream : IDisposable
{
	private Endian endian_0;

	[CompilerGenerated]
	private MemoryStream memoryStream_0;

	[CompilerGenerated]
	private byte[] byte_0;

	[CompilerGenerated]
	private int int_0;

	public Endian Endian
	{
		get
		{
			return endian_0;
		}
		set
		{
			endian_0 = value;
		}
	}

	public MemoryStream Stream
	{
		[CompilerGenerated]
		get
		{
			return memoryStream_0;
		}
		[CompilerGenerated]
		set
		{
			memoryStream_0 = value;
		}
	}

	public byte[] StreamByteArray
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		set
		{
			byte_0 = value;
		}
	}

	public int StreamCounter
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public DataStream()
	{
		endian_0 = (BitConverter.IsLittleEndian ? Endian.Little : Endian.Big);
		Stream = new MemoryStream();
	}

	public void Append(byte[] data)
	{
		Stream.Seek(Stream.Length, SeekOrigin.Begin);
		Stream.Write(data, 0, data.Length);
	}

	public void Append(byte data)
	{
		Stream.Seek(Stream.Length, SeekOrigin.Begin);
		Stream.WriteByte(data);
	}

	public void Clear()
	{
		StreamCounter = 0;
		Stream = new MemoryStream();
	}

	public byte[] ConvertToBytes()
	{
		return ReturnByteArray(Stream.GetBuffer(), 0, (int)Stream.Length);
	}

	public void Dispose()
	{
		if (Stream != null)
		{
			try
			{
				Stream.Close();
				Stream.Dispose();
			}
			catch
			{
			}
		}
	}

	public static byte[] ReturnByteArray(byte[] byteStream, int startIndex, int sizeOfData)
	{
		byte[] array = new byte[sizeOfData];
		Array.Copy(byteStream, startIndex, array, 0, sizeOfData);
		return array;
	}

	static DataStream()
	{
		Class72.smethod_20();
	}
}
