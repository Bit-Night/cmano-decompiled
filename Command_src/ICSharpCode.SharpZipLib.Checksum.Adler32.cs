using System;

namespace ICSharpCode.SharpZipLib.Checksum;

public sealed class Adler32 : IChecksum
{
	private static readonly uint uint_0;

	private uint uint_1;

	public long Value => uint_1;

	public Adler32()
	{
		Reset();
	}

	public void Reset()
	{
		uint_1 = 1u;
	}

	public void Update(int bval)
	{
		uint num = uint_1 & 0xFFFF;
		uint num2 = uint_1 >> 16;
		num = (uint)((int)num + (bval & 0xFF)) % uint_0;
		num2 = (num + num2) % uint_0;
		uint_1 = (num2 << 16) + num;
	}

	public void Update(byte[] buffer)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		Update(new ArraySegment<byte>(buffer, 0, buffer.Length));
	}

	public void Update(ArraySegment<byte> segment)
	{
		uint num = uint_1 & 0xFFFF;
		uint num2 = uint_1 >> 16;
		int num3 = segment.Count;
		int offset = segment.Offset;
		while (num3 > 0)
		{
			int num4 = 3800;
			if (3800 > num3)
			{
				num4 = num3;
			}
			num3 -= num4;
			while (--num4 >= 0)
			{
				num += (uint)(segment.Array[offset++] & 0xFF);
				num2 += num;
			}
			num %= uint_0;
			num2 %= uint_0;
		}
		uint_1 = (num2 << 16) | num;
	}

	static Adler32()
	{
		Class72.smethod_20();
		uint_0 = 65521u;
	}
}
