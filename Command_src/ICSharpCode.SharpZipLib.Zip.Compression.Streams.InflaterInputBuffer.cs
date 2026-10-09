using System;
using System.IO;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams;

public class InflaterInputBuffer
{
	private int int_0;

	private byte[] byte_0;

	private int int_1;

	private byte[] byte_1;

	private byte[] byte_2;

	private int int_2;

	private ICryptoTransform icryptoTransform_0;

	private Stream stream_0;

	public int RawLength => int_0;

	public byte[] RawData => byte_0;

	public int ClearTextLength => int_1;

	public byte[] ClearText => byte_1;

	public int Available
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public ICryptoTransform CryptoTransform
	{
		set
		{
			icryptoTransform_0 = value;
			if (icryptoTransform_0 == null)
			{
				byte_1 = byte_0;
				int_1 = int_0;
				return;
			}
			if (byte_0 == byte_1)
			{
				if (byte_2 == null)
				{
					byte_2 = new byte[byte_0.Length];
				}
				byte_1 = byte_2;
			}
			int_1 = int_0;
			if (int_2 > 0)
			{
				icryptoTransform_0.TransformBlock(byte_0, int_0 - int_2, int_2, byte_1, int_0 - int_2);
			}
		}
	}

	public InflaterInputBuffer(Stream stream)
		: this(stream, 4096)
	{
	}

	public InflaterInputBuffer(Stream stream, int bufferSize)
	{
		stream_0 = stream;
		if (bufferSize < 1024)
		{
			bufferSize = 1024;
		}
		byte_0 = new byte[bufferSize];
		byte_1 = byte_0;
	}

	public void SetInflaterInput(Inflater inflater)
	{
		if (int_2 > 0)
		{
			inflater.SetInput(byte_1, int_1 - int_2, int_2);
			int_2 = 0;
		}
	}

	public void Fill()
	{
		int_0 = 0;
		int num = byte_0.Length;
		while (num > 0 && stream_0.CanRead)
		{
			int num2 = stream_0.Read(byte_0, int_0, num);
			if (num2 <= 0)
			{
				break;
			}
			int_0 += num2;
			num -= num2;
		}
		if (icryptoTransform_0 == null)
		{
			int_1 = int_0;
		}
		else
		{
			int_1 = icryptoTransform_0.TransformBlock(byte_0, 0, int_0, byte_1, 0);
		}
		int_2 = int_1;
	}

	public int ReadRawBuffer(byte[] buffer)
	{
		return ReadRawBuffer(buffer, 0, buffer.Length);
	}

	public int ReadRawBuffer(byte[] outBuffer, int offset, int length)
	{
		if (length >= 0)
		{
			int num = offset;
			int num2 = length;
			while (true)
			{
				if (num2 > 0)
				{
					if (int_2 <= 0)
					{
						Fill();
						if (int_2 <= 0)
						{
							break;
						}
					}
					int num3 = Math.Min(num2, int_2);
					Array.Copy(byte_0, int_0 - int_2, outBuffer, num, num3);
					num += num3;
					num2 -= num3;
					int_2 -= num3;
					continue;
				}
				return length;
			}
			return 0;
		}
		throw new ArgumentOutOfRangeException("length");
	}

	public int ReadClearTextBuffer(byte[] outBuffer, int offset, int length)
	{
		if (length >= 0)
		{
			int num = offset;
			int num2 = length;
			while (true)
			{
				if (num2 > 0)
				{
					if (int_2 <= 0)
					{
						Fill();
						if (int_2 <= 0)
						{
							break;
						}
					}
					int num3 = Math.Min(num2, int_2);
					Array.Copy(byte_1, int_1 - int_2, outBuffer, num, num3);
					num += num3;
					num2 -= num3;
					int_2 -= num3;
					continue;
				}
				return length;
			}
			return 0;
		}
		throw new ArgumentOutOfRangeException("length");
	}

	public byte ReadLeByte()
	{
		if (int_2 <= 0)
		{
			Fill();
			if (int_2 <= 0)
			{
				throw new ZipException("EOF in header");
			}
		}
		byte result = byte_0[int_0 - int_2];
		int_2--;
		return result;
	}

	public int ReadLeShort()
	{
		return ReadLeByte() | (ReadLeByte() << 8);
	}

	public int ReadLeInt()
	{
		return ReadLeShort() | (ReadLeShort() << 16);
	}

	public long ReadLeLong()
	{
		return (uint)ReadLeInt() | ((long)ReadLeInt() << 32);
	}

	static InflaterInputBuffer()
	{
		Class72.smethod_20();
	}
}
