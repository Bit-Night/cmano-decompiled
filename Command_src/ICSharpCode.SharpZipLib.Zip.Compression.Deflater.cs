using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression;

public class Deflater
{
	public enum CompressionLevel
	{
		BEST_COMPRESSION = 9,
		BEST_SPEED = 1,
		DEFAULT_COMPRESSION = -1,
		NO_COMPRESSION = 0,
		DEFLATED = 8
	}

	public const int BEST_COMPRESSION = 9;

	public const int BEST_SPEED = 1;

	public const int DEFAULT_COMPRESSION = -1;

	public const int NO_COMPRESSION = 0;

	public const int DEFLATED = 8;

	private int int_0;

	private bool bool_0;

	private int lpYyEvoReyP;

	private long long_0;

	private DeflaterPending deflaterPending_0;

	private DeflaterEngine deflaterEngine_0;

	public int Adler => deflaterEngine_0.Adler;

	public long TotalIn => deflaterEngine_0.TotalIn;

	public long TotalOut => long_0;

	public bool IsFinished
	{
		get
		{
			if (lpYyEvoReyP == 30)
			{
				return deflaterPending_0.IsFlushed;
			}
			return false;
		}
	}

	public bool IsNeedingInput => deflaterEngine_0.NeedsInput();

	public Deflater()
		: this(-1, noZlibHeaderOrFooter: false)
	{
	}

	public Deflater(int level)
		: this(level, noZlibHeaderOrFooter: false)
	{
	}

	public Deflater(int level, bool noZlibHeaderOrFooter)
	{
		switch (level)
		{
		case -1:
			level = 6;
			break;
		default:
			throw new ArgumentOutOfRangeException("level");
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
			break;
		}
		deflaterPending_0 = new DeflaterPending();
		deflaterEngine_0 = new DeflaterEngine(deflaterPending_0, noZlibHeaderOrFooter);
		bool_0 = noZlibHeaderOrFooter;
		SetStrategy(DeflateStrategy.Default);
		SetLevel(level);
		Reset();
	}

	public void Reset()
	{
		lpYyEvoReyP = (bool_0 ? 16 : 0);
		long_0 = 0L;
		deflaterPending_0.Reset();
		deflaterEngine_0.Reset();
	}

	public void Flush()
	{
		lpYyEvoReyP |= 4;
	}

	public void Finish()
	{
		lpYyEvoReyP |= 12;
	}

	public void SetInput(byte[] input)
	{
		SetInput(input, 0, input.Length);
	}

	public void SetInput(byte[] input, int offset, int count)
	{
		if ((lpYyEvoReyP & 8) != 0)
		{
			throw new InvalidOperationException("Finish() already called");
		}
		deflaterEngine_0.SetInput(input, offset, count);
	}

	public void SetLevel(int level)
	{
		if (level == -1)
		{
			level = 6;
		}
		else if (level < 0 || level > 9)
		{
			throw new ArgumentOutOfRangeException("level");
		}
		if (int_0 != level)
		{
			int_0 = level;
			deflaterEngine_0.SetLevel(level);
		}
	}

	public int GetLevel()
	{
		return int_0;
	}

	public void SetStrategy(DeflateStrategy strategy)
	{
		deflaterEngine_0.Strategy = strategy;
	}

	public int Deflate(byte[] output)
	{
		return Deflate(output, 0, output.Length);
	}

	public int Deflate(byte[] output, int offset, int length)
	{
		int num = length;
		if (lpYyEvoReyP == 127)
		{
			throw new InvalidOperationException("Deflater closed");
		}
		int num3;
		int num2;
		if (lpYyEvoReyP < 16)
		{
			num2 = 30720;
			num3 = int_0 - 1 >> 1;
			int num4;
			if (num3 >= 0)
			{
				if (num3 <= 3)
				{
					goto IL_0042;
				}
				num4 = 3;
			}
			else
			{
				num4 = 3;
			}
			num3 = num4;
			goto IL_0042;
		}
		goto IL_01a7;
		IL_0042:
		num2 |= num3 << 6;
		if ((lpYyEvoReyP & 1) != 0)
		{
			num2 |= 0x20;
		}
		num2 += 31 - num2 % 31;
		deflaterPending_0.WriteShortMSB(num2);
		if ((lpYyEvoReyP & 1) != 0)
		{
			int adler = deflaterEngine_0.Adler;
			deflaterEngine_0.ResetAdler();
			deflaterPending_0.WriteShortMSB(adler >> 16);
			deflaterPending_0.WriteShortMSB(adler & 0xFFFF);
		}
		lpYyEvoReyP = 0x10 | (lpYyEvoReyP & 0xC);
		goto IL_01a7;
		IL_01a7:
		while (true)
		{
			int num5 = deflaterPending_0.Flush(output, offset, length);
			offset += num5;
			long_0 += num5;
			length -= num5;
			if (length == 0 || lpYyEvoReyP == 30)
			{
				break;
			}
			if (deflaterEngine_0.Deflate((lpYyEvoReyP & 4) != 0, (lpYyEvoReyP & 8) != 0))
			{
				continue;
			}
			switch (lpYyEvoReyP)
			{
			case 28:
				deflaterPending_0.AlignToByte();
				if (!bool_0)
				{
					int adler2 = deflaterEngine_0.Adler;
					deflaterPending_0.WriteShortMSB(adler2 >> 16);
					deflaterPending_0.WriteShortMSB(adler2 & 0xFFFF);
				}
				lpYyEvoReyP = 30;
				break;
			case 20:
				if (int_0 != 0)
				{
					for (int num6 = 8 + (-deflaterPending_0.BitCount & 7); num6 > 0; num6 -= 10)
					{
						deflaterPending_0.WriteBits(2, 10);
					}
				}
				lpYyEvoReyP = 16;
				break;
			case 16:
				return num - length;
			}
		}
		return num - length;
	}

	public void SetDictionary(byte[] dictionary)
	{
		SetDictionary(dictionary, 0, dictionary.Length);
	}

	public void SetDictionary(byte[] dictionary, int index, int count)
	{
		if (lpYyEvoReyP != 0)
		{
			throw new InvalidOperationException();
		}
		lpYyEvoReyP = 1;
		deflaterEngine_0.SetDictionary(dictionary, index, count);
	}

	static Deflater()
	{
		Class72.smethod_20();
	}
}
