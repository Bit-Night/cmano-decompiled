namespace Aced.Compression;

internal sealed class AcedConsts
{
	internal const int ChunkShift = 17;

	internal const int ChunkCapacity = 32768;

	internal const int BlockSize = 8192;

	internal const int MaxLength = 17010;

	internal const int MaxDistance = 524288;

	internal const int InitPosValue = -524289;

	internal const int CharCount = 320;

	internal const int FirstLengthChar = 256;

	internal const int FirstCharWithExBit = 272;

	internal const int CharTreeSize = 640;

	internal const int DistCount = 64;

	internal const int FirstDistWithExBit = 5;

	internal const int DistTreeSize = 128;

	internal const int MaxBits = 14;

	internal const int ChLenCount = 20;

	internal const int ChLenTreeSize = 40;

	internal const int MaxChLenBits = 7;

	internal static readonly int[] CharExBitLength;

	internal static readonly int[] CharExBitBase;

	internal static readonly int[] DistExBitLength;

	internal static readonly int[] DistExBitBase;

	internal static readonly int[] ChLenExBitLength;

	private AcedConsts()
	{
	}

	static AcedConsts()
	{
		Class72.smethod_20();
		CharExBitLength = new int[48]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1, 2, 2, 2, 2,
			2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
			2, 2, 3, 3, 3, 3, 3, 3, 3, 3,
			4, 4, 4, 4, 6, 6, 8, 14
		};
		CharExBitBase = new int[48]
		{
			19, 21, 23, 25, 27, 29, 31, 33, 35, 37,
			39, 41, 43, 45, 47, 49, 51, 55, 59, 63,
			67, 71, 75, 79, 83, 87, 91, 95, 99, 103,
			107, 111, 115, 123, 131, 139, 147, 155, 163, 171,
			179, 195, 211, 227, 243, 307, 371, 627
		};
		DistExBitLength = new int[64]
		{
			0, 0, 0, 0, 0, 1, 1, 1, 1, 1,
			1, 1, 2, 2, 2, 2, 3, 3, 3, 3,
			4, 4, 4, 4, 5, 5, 5, 5, 6, 6,
			6, 6, 7, 7, 7, 7, 8, 8, 8, 8,
			9, 9, 9, 9, 10, 10, 10, 10, 11, 11,
			11, 11, 12, 12, 12, 12, 14, 14, 15, 15,
			16, 16, 17, 17
		};
		DistExBitBase = new int[64]
		{
			0, 0, 0, 1, 2, 3, 5, 7, 9, 11,
			13, 15, 17, 21, 25, 29, 33, 41, 49, 57,
			65, 81, 97, 113, 129, 161, 193, 225, 257, 321,
			385, 449, 513, 641, 769, 897, 1025, 1281, 1537, 1793,
			2049, 2561, 3073, 3585, 4097, 5121, 6145, 7169, 8193, 10241,
			12289, 14337, 16385, 20481, 24577, 28673, 32769, 49153, 65537, 98305,
			131073, 196609, 262145, 393217
		};
		ChLenExBitLength = new int[20]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 1, 2, 3, 7
		};
	}
}
