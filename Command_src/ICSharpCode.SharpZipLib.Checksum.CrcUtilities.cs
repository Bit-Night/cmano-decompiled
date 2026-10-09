using System.Runtime.CompilerServices;

namespace ICSharpCode.SharpZipLib.Checksum;

internal static class CrcUtilities
{
	internal const int SlicingDegree = 16;

	internal static uint[] GenerateSlicingLookupTable(uint polynomial, bool isReversed)
	{
		uint[] array = new uint[4096];
		uint num = (isReversed ? 1u : 2147483648u);
		for (int i = 0; i < 256; i++)
		{
			uint num2 = (uint)(isReversed ? i : (i << 24));
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 8; k++)
				{
					num2 = ((!isReversed) ? (((num2 & num) != 0) ? (polynomial ^ (num2 << 1)) : (num2 << 1)) : (((num2 & num) == 1) ? (polynomial ^ (num2 >> 1)) : (num2 >> 1)));
				}
				array[256 * j + i] = num2;
			}
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static uint UpdateDataForNormalPoly(byte[] input, int offset, uint[] crcTable, uint checkValue)
	{
		byte byte_ = (byte)((byte)(checkValue >> 24) ^ input[offset]);
		byte byte_2 = (byte)((byte)(checkValue >> 16) ^ input[offset + 1]);
		byte byte_3 = (byte)((byte)(checkValue >> 8) ^ input[offset + 2]);
		byte byte_4 = (byte)((byte)checkValue ^ input[offset + 3]);
		return smethod_0(input, offset, crcTable, byte_, byte_2, byte_3, byte_4);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static uint UpdateDataForReversedPoly(byte[] input, int offset, uint[] crcTable, uint checkValue)
	{
		byte byte_ = (byte)((byte)checkValue ^ input[offset]);
		byte byte_2 = (byte)((byte)(checkValue >>= 8) ^ input[offset + 1]);
		byte byte_3 = (byte)((byte)(checkValue >>= 8) ^ input[offset + 2]);
		byte byte_4 = (byte)((byte)(checkValue >>= 8) ^ input[offset + 3]);
		return smethod_0(input, offset, crcTable, byte_, byte_2, byte_3, byte_4);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static uint smethod_0(object object_0, int int_0, object object_1, byte byte_0, byte byte_1, byte byte_2, byte byte_3)
	{
		uint num = ((uint[])object_1)[byte_0 + 3840] ^ ((uint[])object_1)[byte_1 + 3584];
		uint num2 = ((uint[])object_1)[byte_2 + 3328] ^ ((uint[])object_1)[byte_3 + 3072];
		uint num3 = ((uint[])object_1)[((byte[])object_0)[int_0 + 4] + 2816] ^ ((uint[])object_1)[((byte[])object_0)[int_0 + 5] + 2560];
		num ^= ((uint[])object_1)[((byte[])object_0)[int_0 + 9] + 1536];
		uint num4 = num3 ^ ((uint[])object_1)[((byte[])object_0)[int_0 + 6] + 2304] ^ ((uint[])object_1)[((byte[])object_0)[int_0 + 7] + 2048] ^ ((uint[])object_1)[((byte[])object_0)[int_0 + 8] + 1792];
		num2 ^= ((uint[])object_1)[((byte[])object_0)[int_0 + 13] + 512];
		return num4 ^ ((uint[])object_1)[((byte[])object_0)[int_0 + 10] + 1280] ^ ((uint[])object_1)[((byte[])object_0)[int_0 + 11] + 1024] ^ ((uint[])object_1)[((byte[])object_0)[int_0 + 12] + 768] ^ num ^ ((uint[])object_1)[((byte[])object_0)[int_0 + 14] + 256] ^ ((uint[])object_1)[((byte[])object_0)[int_0 + 15]] ^ num2;
	}

	static CrcUtilities()
	{
		Class72.smethod_20();
	}
}
