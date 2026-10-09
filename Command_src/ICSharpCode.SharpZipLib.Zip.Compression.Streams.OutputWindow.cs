using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams;

public class OutputWindow
{
	private byte[] byte_0 = new byte[32768];

	private int int_0;

	private int int_1;

	public void Write(int value)
	{
		if (int_1++ == 32768)
		{
			throw new InvalidOperationException("Window full");
		}
		byte_0[int_0++] = (byte)value;
		int_0 &= 32767;
	}

	private void method_0(int int_2, int int_3, int int_4)
	{
		while (int_3-- > 0)
		{
			byte_0[int_0++] = byte_0[int_2++];
			int_0 &= 32767;
			int_2 &= 0x7FFF;
		}
	}

	public void Repeat(int length, int distance)
	{
		if ((int_1 += length) > 32768)
		{
			throw new InvalidOperationException("Window full");
		}
		int num = (int_0 - distance) & 0x7FFF;
		int num2 = 32768 - length;
		if (num <= num2 && int_0 < num2)
		{
			if (length <= distance)
			{
				Array.Copy(byte_0, num, byte_0, int_0, length);
				int_0 += length;
			}
			else
			{
				while (length-- > 0)
				{
					byte_0[int_0++] = byte_0[num++];
				}
			}
		}
		else
		{
			method_0(num, length, distance);
		}
	}

	public int CopyStored(StreamManipulator input, int length)
	{
		length = Math.Min(Math.Min(length, 32768 - int_1), input.AvailableBytes);
		int num = 32768 - int_0;
		int num2;
		if (length > num)
		{
			num2 = input.CopyBytes(byte_0, int_0, num);
			if (num2 == num)
			{
				num2 += input.CopyBytes(byte_0, 0, length - num);
			}
		}
		else
		{
			num2 = input.CopyBytes(byte_0, int_0, length);
		}
		int_0 = (int_0 + num2) & 0x7FFF;
		int_1 += num2;
		return num2;
	}

	public void CopyDict(byte[] dictionary, int offset, int length)
	{
		if (dictionary == null)
		{
			throw new ArgumentNullException("dictionary");
		}
		if (int_1 > 0)
		{
			throw new InvalidOperationException();
		}
		if (length > 32768)
		{
			offset += length - 32768;
			length = 32768;
		}
		Array.Copy(dictionary, offset, byte_0, 0, length);
		int_0 = length & 0x7FFF;
	}

	public int GetFreeSpace()
	{
		return 32768 - int_1;
	}

	public int GetAvailable()
	{
		return int_1;
	}

	public int CopyOutput(byte[] output, int offset, int len)
	{
		int num = int_0;
		if (len <= int_1)
		{
			num = (int_0 - int_1 + len) & 0x7FFF;
		}
		else
		{
			len = int_1;
		}
		int num2 = len;
		int num3 = len - num;
		if (num3 > 0)
		{
			Array.Copy(byte_0, 32768 - num3, output, offset, num3);
			offset += num3;
			len = num;
		}
		Array.Copy(byte_0, num - len, output, offset, len);
		int_1 -= num2;
		if (int_1 < 0)
		{
			throw new InvalidOperationException();
		}
		return num2;
	}

	public void Reset()
	{
		int_0 = 0;
		int_1 = 0;
	}

	static OutputWindow()
	{
		Class72.smethod_20();
	}
}
