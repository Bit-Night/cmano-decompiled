using System;
using System.Runtime.CompilerServices;

namespace ICSharpCode.SharpZipLib.Checksum;

public sealed class BZip2Crc : IChecksum
{
	private static readonly uint[] uint_0;

	private uint uint_1;

	public long Value => ~uint_1;

	public BZip2Crc()
	{
		Reset();
	}

	public void Reset()
	{
		uint_1 = uint.MaxValue;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Update(int bval)
	{
		uint_1 = uint_0[(byte)(((uint_1 >> 24) & 0xFF) ^ bval)] ^ (uint_1 << 8);
	}

	public void Update(byte[] buffer)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		Update(buffer, 0, buffer.Length);
	}

	public void Update(ArraySegment<byte> segment)
	{
		Update(segment.Array, segment.Offset, segment.Count);
	}

	private void Update(byte[] data, int offset, int count)
	{
		int num = count % 16;
		int num2 = offset + count - num;
		while (offset != num2)
		{
			uint_1 = CrcUtilities.UpdateDataForNormalPoly(data, offset, uint_0, uint_1);
			offset += 16;
		}
		if (num != 0)
		{
			method_0(data, offset, num2 + num);
		}
	}

	private void method_0(byte[] byte_0, int int_0, int int_1)
	{
		while (int_0 != int_1)
		{
			Update(byte_0[int_0++]);
		}
	}

	static BZip2Crc()
	{
		Class72.smethod_20();
		uint_0 = CrcUtilities.GenerateSlicingLookupTable(79764919u, isReversed: false);
	}
}
