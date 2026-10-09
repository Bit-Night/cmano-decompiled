using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression;

public class PendingBuffer
{
	private readonly byte[] aljyZjNiXip;

	private int int_0;

	private int int_1;

	private uint uint_0;

	private int int_2;

	public int BitCount => int_2;

	public bool IsFlushed => int_1 == 0;

	public PendingBuffer()
		: this(4096)
	{
	}

	public PendingBuffer(int bufferSize)
	{
		aljyZjNiXip = new byte[bufferSize];
	}

	public void Reset()
	{
		int_2 = 0;
		int_1 = 0;
		int_0 = 0;
	}

	public void WriteByte(int value)
	{
		aljyZjNiXip[int_1++] = (byte)value;
	}

	public void WriteShort(int value)
	{
		aljyZjNiXip[int_1++] = (byte)value;
		aljyZjNiXip[int_1++] = (byte)(value >> 8);
	}

	public void WriteInt(int value)
	{
		aljyZjNiXip[int_1++] = (byte)value;
		aljyZjNiXip[int_1++] = (byte)(value >> 8);
		aljyZjNiXip[int_1++] = (byte)(value >> 16);
		aljyZjNiXip[int_1++] = (byte)(value >> 24);
	}

	public void WriteBlock(byte[] block, int offset, int length)
	{
		Array.Copy(block, offset, aljyZjNiXip, int_1, length);
		int_1 += length;
	}

	public void AlignToByte()
	{
		if (int_2 > 0)
		{
			aljyZjNiXip[int_1++] = (byte)uint_0;
			if (int_2 > 8)
			{
				aljyZjNiXip[int_1++] = (byte)(uint_0 >> 8);
			}
		}
		uint_0 = 0u;
		int_2 = 0;
	}

	public void WriteBits(int b, int count)
	{
		uint_0 |= (uint)(b << int_2);
		int_2 += count;
		if (int_2 >= 16)
		{
			aljyZjNiXip[int_1++] = (byte)uint_0;
			aljyZjNiXip[int_1++] = (byte)(uint_0 >> 8);
			uint_0 >>= 16;
			int_2 -= 16;
		}
	}

	public void WriteShortMSB(int s)
	{
		aljyZjNiXip[int_1++] = (byte)(s >> 8);
		aljyZjNiXip[int_1++] = (byte)s;
	}

	public int Flush(byte[] output, int offset, int length)
	{
		if (int_2 >= 8)
		{
			aljyZjNiXip[int_1++] = (byte)uint_0;
			uint_0 >>= 8;
			int_2 -= 8;
		}
		if (length <= int_1 - int_0)
		{
			Array.Copy(aljyZjNiXip, int_0, output, offset, length);
			int_0 += length;
		}
		else
		{
			length = int_1 - int_0;
			Array.Copy(aljyZjNiXip, int_0, output, offset, length);
			int_0 = 0;
			int_1 = 0;
		}
		return length;
	}

	public byte[] ToByteArray()
	{
		AlignToByte();
		byte[] array = new byte[int_1 - int_0];
		Array.Copy(aljyZjNiXip, int_0, array, 0, array.Length);
		int_0 = 0;
		int_1 = 0;
		return array;
	}

	static PendingBuffer()
	{
		Class72.smethod_20();
	}
}
