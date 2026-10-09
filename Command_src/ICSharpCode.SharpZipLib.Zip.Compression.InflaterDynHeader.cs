using System;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip.Compression;

internal class InflaterDynHeader
{
	private static readonly int[] int_0;

	private readonly StreamManipulator streamManipulator_0;

	private readonly IEnumerator<bool> ienumerator_0;

	private readonly IEnumerable<bool> ienumerable_0;

	private byte[] byte_0 = new byte[316];

	private InflaterHuffmanTree inflaterHuffmanTree_0;

	private InflaterHuffmanTree inflaterHuffmanTree_1;

	private int int_1;

	private int int_2;

	private int int_3;

	public InflaterHuffmanTree LiteralLengthTree => inflaterHuffmanTree_0 ?? throw new StreamDecodingException("Header properties were accessed before header had been successfully read");

	public InflaterHuffmanTree DistanceTree => inflaterHuffmanTree_1 ?? throw new StreamDecodingException("Header properties were accessed before header had been successfully read");

	public bool AttemptRead()
	{
		if (!ienumerator_0.MoveNext())
		{
			return true;
		}
		return ienumerator_0.Current;
	}

	public InflaterDynHeader(StreamManipulator input)
	{
		streamManipulator_0 = input;
		ienumerable_0 = method_0();
		ienumerator_0 = ienumerable_0.GetEnumerator();
	}

	private IEnumerable<bool> method_0()
	{
		while (!streamManipulator_0.TryGetBits(5, ref int_1, 257))
		{
			yield return false;
		}
		while (!streamManipulator_0.TryGetBits(5, ref int_2, 1))
		{
			yield return false;
		}
		while (!streamManipulator_0.TryGetBits(4, ref int_3, 4))
		{
			yield return false;
		}
		int dataCodeCount = int_1 + int_2;
		if (int_1 > 286)
		{
			throw new ValueOutOfRangeException("litLenCodeCount");
		}
		if (int_2 <= 30)
		{
			if (int_3 > 19)
			{
				throw new ValueOutOfRangeException("metaCodeCount");
			}
			for (int i = 0; i < int_3; i++)
			{
				while (!streamManipulator_0.TryGetBits(3, ref byte_0, int_0[i]))
				{
					yield return false;
				}
			}
			InflaterHuffmanTree metaCodeTree = new InflaterHuffmanTree(byte_0);
			int index = 0;
			while (true)
			{
				if (index < dataCodeCount)
				{
					int symbol;
					while ((symbol = metaCodeTree.GetSymbol(streamManipulator_0)) < 0)
					{
						yield return false;
					}
					if (symbol < 16)
					{
						byte_0[index++] = (byte)symbol;
						continue;
					}
					int i = 0;
					byte codeLength;
					if (symbol == 16)
					{
						if (index == 0)
						{
							throw new StreamDecodingException("Cannot repeat previous code length when no other code length has been read");
						}
						codeLength = byte_0[index - 1];
						while (!streamManipulator_0.TryGetBits(2, ref i, 3))
						{
							yield return false;
						}
					}
					else if (symbol == 17)
					{
						codeLength = 0;
						while (!streamManipulator_0.TryGetBits(3, ref i, 3))
						{
							yield return false;
						}
					}
					else
					{
						codeLength = 0;
						while (!streamManipulator_0.TryGetBits(7, ref i, 11))
						{
							yield return false;
						}
					}
					if (index + i > dataCodeCount)
					{
						break;
					}
					while (i-- > 0)
					{
						byte_0[index++] = codeLength;
					}
					continue;
				}
				if (byte_0[256] != 0)
				{
					inflaterHuffmanTree_0 = new InflaterHuffmanTree(new ArraySegment<byte>(byte_0, 0, int_1));
					inflaterHuffmanTree_1 = new InflaterHuffmanTree(new ArraySegment<byte>(byte_0, int_1, int_2));
					yield return true;
					yield break;
				}
				throw new StreamDecodingException("Inflater dynamic header end-of-block code missing");
			}
			throw new StreamDecodingException("Cannot repeat code lengths past total number of data code lengths");
		}
		throw new ValueOutOfRangeException("distanceCodeCount");
	}

	static InflaterDynHeader()
	{
		Class72.smethod_20();
		int_0 = new int[19]
		{
			16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
			11, 4, 12, 3, 13, 2, 14, 1, 15
		};
	}
}
