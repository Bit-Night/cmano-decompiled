using System;
using System.Runtime.CompilerServices;

namespace ICSharpCode.SharpZipLib.Checksum;

public sealed class Crc32 : IChecksum
{
	private static readonly uint uint_0;

	private static readonly uint uint_1;

	private static readonly uint[] uint_2;

	private uint uint_3;

	public long Value => uint_3 ^ uint_1;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static uint ComputeCrc32(uint oldCrc, byte bval)
	{
		return uint_2[(oldCrc ^ bval) & 0xFF] ^ (oldCrc >> 8);
	}

	public Crc32()
	{
		Reset();
	}

	public void Reset()
	{
		uint_3 = uint_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Update(int bval)
	{
		uint_3 = uint_2[(uint_3 ^ bval) & 0xFFL] ^ (uint_3 >> 8);
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
			uint_3 = CrcUtilities.UpdateDataForReversedPoly(data, offset, uint_2, uint_3);
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

	static Crc32()
	{
		Class72.smethod_20();
		uint_0 = uint.MaxValue;
		uint_1 = uint.MaxValue;
		uint_2 = CrcUtilities.GenerateSlicingLookupTable(3988292384u, isReversed: true);
	}
}
