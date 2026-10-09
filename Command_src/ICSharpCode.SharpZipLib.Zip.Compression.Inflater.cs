using System;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip.Compression;

public class Inflater
{
	private static readonly int[] int_0;

	private static readonly int[] int_1;

	private static readonly int[] int_2;

	private static readonly int[] int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private bool bool_0;

	private long long_0;

	private long long_1;

	internal bool noHeader;

	private readonly StreamManipulator streamManipulator_0;

	private OutputWindow outputWindow_0;

	private ICSharpCode.SharpZipLib.Zip.Compression.InflaterDynHeader inflaterDynHeader_0;

	private InflaterHuffmanTree inflaterHuffmanTree_0;

	private InflaterHuffmanTree inflaterHuffmanTree_1;

	private Adler32 adler32_0;

	public bool IsNeedingInput => streamManipulator_0.IsNeedingInput;

	public bool IsNeedingDictionary
	{
		get
		{
			if (int_4 == 1)
			{
				return int_6 == 0;
			}
			return false;
		}
	}

	public bool IsFinished
	{
		get
		{
			if (int_4 == 12)
			{
				return outputWindow_0.GetAvailable() == 0;
			}
			return false;
		}
	}

	public int Adler
	{
		get
		{
			if (!IsNeedingDictionary)
			{
				if (adler32_0 == null)
				{
					return 0;
				}
				return (int)adler32_0.Value;
			}
			return int_5;
		}
	}

	public long TotalOut => long_0;

	public long TotalIn => long_1 - RemainingInput;

	public int RemainingInput => streamManipulator_0.AvailableBytes;

	public Inflater()
		: this(noHeader: false)
	{
	}

	public Inflater(bool noHeader)
	{
		this.noHeader = noHeader;
		if (!noHeader)
		{
			adler32_0 = new Adler32();
		}
		streamManipulator_0 = new StreamManipulator();
		outputWindow_0 = new OutputWindow();
		int_4 = (noHeader ? 2 : 0);
	}

	public void Reset()
	{
		int_4 = (noHeader ? 2 : 0);
		long_1 = 0L;
		long_0 = 0L;
		streamManipulator_0.Reset();
		outputWindow_0.Reset();
		inflaterDynHeader_0 = null;
		inflaterHuffmanTree_0 = null;
		inflaterHuffmanTree_1 = null;
		bool_0 = false;
		adler32_0?.Reset();
	}

	private bool method_0()
	{
		int num = streamManipulator_0.PeekBits(16);
		if (num >= 0)
		{
			streamManipulator_0.DropBits(16);
			num = ((num << 8) | (num >> 8)) & 0xFFFF;
			if (num % 31 == 0)
			{
				if ((num & 0xF00) != 2048)
				{
					throw new SharpZipBaseException("Compression Method unknown");
				}
				int result;
				if ((num & 0x20) != 0)
				{
					int_4 = 1;
					int_6 = 32;
					result = 1;
				}
				else
				{
					int_4 = 2;
					result = 1;
				}
				return (byte)result != 0;
			}
			throw new SharpZipBaseException("Header checksum illegal");
		}
		return false;
	}

	private bool method_1()
	{
		while (true)
		{
			if (int_6 > 0)
			{
				int num = streamManipulator_0.PeekBits(8);
				if (num < 0)
				{
					break;
				}
				streamManipulator_0.DropBits(8);
				int_5 = (int_5 << 8) | num;
				int_6 -= 8;
				continue;
			}
			return false;
		}
		return false;
	}

	private bool method_2()
	{
		int num = outputWindow_0.GetFreeSpace();
		while (num >= 258)
		{
			switch (int_4)
			{
			case 7:
			{
				int symbol;
				while (((symbol = inflaterHuffmanTree_0.GetSymbol(streamManipulator_0)) & -256) == 0)
				{
					outputWindow_0.Write(symbol);
					if (--num < 258)
					{
						return true;
					}
				}
				if (symbol >= 257)
				{
					try
					{
						int_7 = int_0[symbol - 257];
						int_6 = int_1[symbol - 257];
					}
					catch (Exception)
					{
						throw new SharpZipBaseException("Illegal rep length code");
					}
					goto case 8;
				}
				if (symbol >= 0)
				{
					inflaterHuffmanTree_1 = null;
					inflaterHuffmanTree_0 = null;
					int_4 = 2;
					return true;
				}
				return false;
			}
			case 8:
				if (int_6 > 0)
				{
					int_4 = 8;
					int num3 = streamManipulator_0.PeekBits(int_6);
					if (num3 < 0)
					{
						return false;
					}
					streamManipulator_0.DropBits(int_6);
					int_7 += num3;
				}
				int_4 = 9;
				goto case 9;
			case 9:
			{
				int symbol = inflaterHuffmanTree_1.GetSymbol(streamManipulator_0);
				if (symbol >= 0)
				{
					try
					{
						int_8 = int_2[symbol];
						int_6 = int_3[symbol];
					}
					catch (Exception)
					{
						throw new SharpZipBaseException("Illegal rep dist code");
					}
					goto case 10;
				}
				return false;
			}
			case 10:
				if (int_6 > 0)
				{
					int_4 = 10;
					int num2 = streamManipulator_0.PeekBits(int_6);
					if (num2 < 0)
					{
						return false;
					}
					streamManipulator_0.DropBits(int_6);
					int_8 += num2;
				}
				break;
			default:
				throw new SharpZipBaseException("Inflater unknown mode");
			}
			outputWindow_0.Repeat(int_7, int_8);
			num -= int_7;
			int_4 = 7;
		}
		return true;
	}

	private bool method_3()
	{
		while (true)
		{
			if (int_6 > 0)
			{
				int num = streamManipulator_0.PeekBits(8);
				if (num < 0)
				{
					break;
				}
				streamManipulator_0.DropBits(8);
				int_5 = (int_5 << 8) | num;
				int_6 -= 8;
				continue;
			}
			if ((int)(adler32_0?.Value).Value != int_5)
			{
				throw new SharpZipBaseException("Adler chksum doesn't match: " + (int)(adler32_0?.Value).Value + " vs. " + int_5);
			}
			int_4 = 12;
			return false;
		}
		return false;
	}

	private bool method_4()
	{
		switch (int_4)
		{
		default:
			throw new SharpZipBaseException("Inflater.Decode unknown mode");
		case 0:
			return method_0();
		case 1:
			return method_1();
		case 2:
		{
			if (bool_0)
			{
				if (noHeader)
				{
					int_4 = 12;
					return false;
				}
				streamManipulator_0.SkipToByteBoundary();
				int_6 = 32;
				int_4 = 11;
				return true;
			}
			int num3 = streamManipulator_0.PeekBits(3);
			if (num3 < 0)
			{
				return false;
			}
			streamManipulator_0.DropBits(3);
			bool_0 |= (num3 & 1) != 0;
			int result;
			switch (num3 >> 1)
			{
			default:
				throw new SharpZipBaseException("Unknown block type " + num3);
			case 0:
				streamManipulator_0.SkipToByteBoundary();
				int_4 = 3;
				result = 1;
				break;
			case 1:
				inflaterHuffmanTree_0 = InflaterHuffmanTree.defLitLenTree;
				inflaterHuffmanTree_1 = InflaterHuffmanTree.defDistTree;
				int_4 = 7;
				result = 1;
				break;
			case 2:
				inflaterDynHeader_0 = new ICSharpCode.SharpZipLib.Zip.Compression.InflaterDynHeader(streamManipulator_0);
				int_4 = 6;
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
		case 3:
			if ((int_9 = streamManipulator_0.PeekBits(16)) >= 0)
			{
				streamManipulator_0.DropBits(16);
				int_4 = 4;
				goto case 4;
			}
			return false;
		case 4:
		{
			int num2 = streamManipulator_0.PeekBits(16);
			if (num2 >= 0)
			{
				streamManipulator_0.DropBits(16);
				if (num2 != (int_9 ^ 0xFFFF))
				{
					throw new SharpZipBaseException("broken uncompressed block");
				}
				int_4 = 5;
				goto case 5;
			}
			return false;
		}
		case 5:
		{
			int num = outputWindow_0.CopyStored(streamManipulator_0, int_9);
			int_9 -= num;
			if (int_9 != 0)
			{
				return !streamManipulator_0.IsNeedingInput;
			}
			int_4 = 2;
			return true;
		}
		case 6:
			if (!inflaterDynHeader_0.AttemptRead())
			{
				return false;
			}
			inflaterHuffmanTree_0 = inflaterDynHeader_0.LiteralLengthTree;
			inflaterHuffmanTree_1 = inflaterDynHeader_0.DistanceTree;
			int_4 = 7;
			goto case 7;
		case 7:
		case 8:
		case 9:
		case 10:
			return method_2();
		case 11:
			return method_3();
		case 12:
			return false;
		}
	}

	public void SetDictionary(byte[] buffer)
	{
		SetDictionary(buffer, 0, buffer.Length);
	}

	public void SetDictionary(byte[] buffer, int index, int count)
	{
		if (buffer != null)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (IsNeedingDictionary)
			{
				adler32_0?.Update(new ArraySegment<byte>(buffer, index, count));
				if (adler32_0 != null && (int)adler32_0.Value != int_5)
				{
					throw new SharpZipBaseException("Wrong adler checksum");
				}
				adler32_0?.Reset();
				outputWindow_0.CopyDict(buffer, index, count);
				int_4 = 2;
				return;
			}
			throw new InvalidOperationException("Dictionary is not needed");
		}
		throw new ArgumentNullException("buffer");
	}

	public void SetInput(byte[] buffer)
	{
		SetInput(buffer, 0, buffer.Length);
	}

	public void SetInput(byte[] buffer, int index, int count)
	{
		streamManipulator_0.SetInput(buffer, index, count);
		long_1 += count;
	}

	public int Inflate(byte[] buffer)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		return Inflate(buffer, 0, buffer.Length);
	}

	public int Inflate(byte[] buffer, int offset, int count)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (count >= 0)
		{
			if (offset >= 0)
			{
				if (offset + count > buffer.Length)
				{
					throw new ArgumentException("count exceeds buffer bounds");
				}
				if (count == 0)
				{
					int result;
					if (IsFinished)
					{
						result = 0;
					}
					else
					{
						method_4();
						result = 0;
					}
					return result;
				}
				int num = 0;
				do
				{
					if (int_4 == 11)
					{
						continue;
					}
					int num2 = outputWindow_0.CopyOutput(buffer, offset, count);
					if (num2 > 0)
					{
						adler32_0?.Update(new ArraySegment<byte>(buffer, offset, num2));
						offset += num2;
						num += num2;
						long_0 += num2;
						count -= num2;
						if (count == 0)
						{
							return num;
						}
					}
				}
				while (method_4() || (outputWindow_0.GetAvailable() > 0 && int_4 != 11));
				return num;
			}
			throw new ArgumentOutOfRangeException("offset", "offset cannot be negative");
		}
		throw new ArgumentOutOfRangeException("count", "count cannot be negative");
	}

	static Inflater()
	{
		Class72.smethod_20();
		int_0 = new int[29]
		{
			3, 4, 5, 6, 7, 8, 9, 10, 11, 13,
			15, 17, 19, 23, 27, 31, 35, 43, 51, 59,
			67, 83, 99, 115, 131, 163, 195, 227, 258
		};
		int_1 = new int[29]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
			1, 1, 2, 2, 2, 2, 3, 3, 3, 3,
			4, 4, 4, 4, 5, 5, 5, 5, 0
		};
		int_2 = new int[30]
		{
			1, 2, 3, 4, 5, 7, 9, 13, 17, 25,
			33, 49, 65, 97, 129, 193, 257, 385, 513, 769,
			1025, 1537, 2049, 3073, 4097, 6145, 8193, 12289, 16385, 24577
		};
		int_3 = new int[30]
		{
			0, 0, 0, 0, 1, 1, 2, 2, 3, 3,
			4, 4, 5, 5, 6, 6, 7, 7, 8, 8,
			9, 9, 10, 10, 11, 11, 12, 12, 13, 13
		};
	}
}
