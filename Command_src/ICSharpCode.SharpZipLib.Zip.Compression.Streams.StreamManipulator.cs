using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams;

public class StreamManipulator
{
	private byte[] byte_0;

	private int int_0;

	private int int_1;

	private uint uint_0;

	private int int_2;

	public int AvailableBits => int_2;

	public int AvailableBytes => int_1 - int_0 + (int_2 >> 3);

	public bool IsNeedingInput => int_0 == int_1;

	public int PeekBits(int bitCount)
	{
		if (int_2 < bitCount)
		{
			if (int_0 == int_1)
			{
				return -1;
			}
			uint_0 |= (uint)(((byte_0[int_0++] & 0xFF) | ((byte_0[int_0++] & 0xFF) << 8)) << int_2);
			int_2 += 16;
		}
		return (int)(uint_0 & ((1 << bitCount) - 1));
	}

	public bool TryGetBits(int bitCount, ref int output, int outputOffset = 0)
	{
		int num = PeekBits(bitCount);
		if (num >= 0)
		{
			output = num + outputOffset;
			DropBits(bitCount);
			return true;
		}
		return false;
	}

	public bool TryGetBits(int bitCount, ref byte[] array, int index)
	{
		int num = PeekBits(bitCount);
		if (num < 0)
		{
			return false;
		}
		array[index] = (byte)num;
		DropBits(bitCount);
		return true;
	}

	public void DropBits(int bitCount)
	{
		uint_0 >>= bitCount;
		int_2 -= bitCount;
	}

	public int GetBits(int bitCount)
	{
		int num = PeekBits(bitCount);
		if (num >= 0)
		{
			DropBits(bitCount);
		}
		return num;
	}

	public void SkipToByteBoundary()
	{
		uint_0 >>= int_2 & 7;
		int_2 &= -8;
	}

	public int CopyBytes(byte[] output, int offset, int length)
	{
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if ((int_2 & 7) != 0)
		{
			throw new InvalidOperationException("Bit buffer is not byte aligned!");
		}
		int num = 0;
		while (int_2 > 0 && length > 0)
		{
			output[offset++] = (byte)uint_0;
			uint_0 >>= 8;
			int_2 -= 8;
			length--;
			num++;
		}
		if (length != 0)
		{
			int num2 = int_1 - int_0;
			if (length > num2)
			{
				length = num2;
			}
			Array.Copy(byte_0, int_0, output, offset, length);
			int_0 += length;
			if (((int_0 - int_1) & 1) != 0)
			{
				uint_0 = (uint)(byte_0[int_0++] & 0xFF);
				int_2 = 8;
			}
			return num + length;
		}
		return num;
	}

	public void Reset()
	{
		uint_0 = 0u;
		int_2 = 0;
		int_1 = 0;
		int_0 = 0;
	}

	public void SetInput(byte[] buffer, int offset, int count)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset < 0)
		{
			throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count", "Cannot be negative");
		}
		if (int_0 < int_1)
		{
			throw new InvalidOperationException("Old input was not completely processed");
		}
		int num = offset + count;
		if (offset <= num && num <= buffer.Length)
		{
			if ((count & 1) != 0)
			{
				uint_0 |= (uint)((buffer[offset++] & 0xFF) << int_2);
				int_2 += 8;
			}
			byte_0 = buffer;
			int_0 = offset;
			int_1 = num;
			return;
		}
		throw new ArgumentOutOfRangeException("count");
	}

	static StreamManipulator()
	{
		Class72.smethod_20();
	}
}
