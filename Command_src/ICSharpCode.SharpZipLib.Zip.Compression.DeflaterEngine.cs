using System;
using ICSharpCode.SharpZipLib.Checksum;

namespace ICSharpCode.SharpZipLib.Zip.Compression;

public class DeflaterEngine
{
	private int int_0;

	private short[] short_0;

	private short[] short_1;

	private int int_1;

	private int int_2;

	private bool bool_0;

	private int int_3;

	private int int_4;

	private int int_5;

	private byte[] byte_0;

	private DeflateStrategy deflateStrategy_0;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private byte[] byte_1;

	private long long_0;

	private int int_11;

	private int int_12;

	private DeflaterPending deflaterPending_0;

	private DeflaterHuffman deflaterHuffman_0;

	private Adler32 adler32_0;

	public int Adler
	{
		get
		{
			if (adler32_0 == null)
			{
				return 0;
			}
			return (int)adler32_0.Value;
		}
	}

	public long TotalIn => long_0;

	public DeflateStrategy Strategy
	{
		get
		{
			return deflateStrategy_0;
		}
		set
		{
			deflateStrategy_0 = value;
		}
	}

	public DeflaterEngine(DeflaterPending pending)
		: this(pending, noAdlerCalculation: false)
	{
	}

	public DeflaterEngine(DeflaterPending pending, bool noAdlerCalculation)
	{
		deflaterPending_0 = pending;
		deflaterHuffman_0 = new DeflaterHuffman(pending);
		if (!noAdlerCalculation)
		{
			adler32_0 = new Adler32();
		}
		byte_0 = new byte[65536];
		short_0 = new short[32768];
		short_1 = new short[32768];
		int_4 = 1;
		int_3 = 1;
	}

	public bool Deflate(bool flush, bool finish)
	{
		int num = 13;
		bool flag = default(bool);
		while (true)
		{
			FillWindow();
			while (true)
			{
				IL_007e:
				int num2;
				if (!flush)
				{
					num2 = 0;
					goto IL_0079;
				}
				goto IL_006b;
				IL_006b:
				num2 = ((int_11 == int_12) ? 1 : 0);
				goto IL_0079;
				IL_0079:
				bool bool_ = (byte)num2 != 0;
				num = 8;
				while (true)
				{
					int num3 = int_10;
					num = 20;
					while (true)
					{
						if (num != 20)
						{
							if (num != 1001)
							{
								goto IL_00d1;
							}
							switch (num)
							{
							case 8:
								goto end_IL_0057;
							case 2:
								goto end_IL_005f;
							case 12:
								goto IL_007e;
							case 10:
								goto IL_0099;
							case 1:
								goto IL_00a4;
							case 11:
								goto IL_00b1;
							case 3:
							case 4:
							case 5:
								goto IL_00ba;
							case 6:
							case 13:
								goto end_IL_007e;
							case 7:
							case 9:
								goto IL_00d1;
							case 0:
								goto IL_00dc;
							}
							continue;
						}
						switch (num3)
						{
						case 0:
							break;
						case 1:
							goto IL_00a4;
						case 2:
							goto IL_00b1;
						default:
							goto IL_00d1;
						}
						goto IL_0099;
						IL_0099:
						flag = method_4(bool_, finish);
						goto IL_00ba;
						IL_00dc:
						return flag;
						IL_00ba:
						if (deflaterPending_0.IsFlushed && flag)
						{
							goto end_IL_007e;
						}
						goto IL_00dc;
						IL_00d1:
						throw new InvalidOperationException("unknown compressionFunction");
						IL_00b1:
						flag = method_6(bool_, finish);
						goto IL_00ba;
						IL_00a4:
						flag = method_5(bool_, finish);
						num = 3;
						goto IL_00ba;
						continue;
						end_IL_0057:
						break;
					}
					continue;
					end_IL_005f:
					break;
				}
				goto IL_006b;
				continue;
				end_IL_007e:
				break;
			}
		}
	}

	public void SetInput(byte[] buffer, int offset, int count)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset >= 0)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (int_11 < int_12)
			{
				throw new InvalidOperationException("Old input was not completely processed");
			}
			int num = offset + count;
			if (offset > num || num > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			byte_1 = buffer;
			int_11 = offset;
			int_12 = num;
			return;
		}
		throw new ArgumentOutOfRangeException("offset");
	}

	public bool NeedsInput()
	{
		return int_12 == int_11;
	}

	public void SetDictionary(byte[] buffer, int offset, int length)
	{
		adler32_0?.Update(new ArraySegment<byte>(buffer, offset, length));
		if (length >= 3)
		{
			if (length > 32506)
			{
				offset += length - 32506;
				length = 32506;
			}
			Array.Copy(buffer, offset, byte_0, int_4, length);
			method_0();
			length--;
			while (--length > 0)
			{
				method_1();
				int_4++;
			}
			int_4 += 2;
			int_3 = int_4;
		}
	}

	public void Reset()
	{
		deflaterHuffman_0.Reset();
		adler32_0?.Reset();
		int_4 = 1;
		int_3 = 1;
		int_5 = 0;
		long_0 = 0L;
		bool_0 = false;
		int_2 = 2;
		for (int i = 0; i < 32768; i++)
		{
			short_0[i] = 0;
		}
		for (int j = 0; j < 32768; j++)
		{
			short_1[j] = 0;
		}
	}

	public void ResetAdler()
	{
		adler32_0?.Reset();
	}

	public void SetLevel(int level)
	{
		if (level >= 0 && level <= 9)
		{
			int_9 = DeflaterConstants.GOOD_LENGTH[level];
			int_7 = DeflaterConstants.MAX_LAZY[level];
			int_8 = DeflaterConstants.NICE_LENGTH[level];
			int_6 = DeflaterConstants.MAX_CHAIN[level];
			if (DeflaterConstants.COMPR_FUNC[level] == int_10)
			{
				return;
			}
			switch (int_10)
			{
			case 0:
				if (int_4 > int_3)
				{
					deflaterHuffman_0.FlushStoredBlock(byte_0, int_3, int_4 - int_3, lastBlock: false);
					int_3 = int_4;
				}
				method_0();
				break;
			case 1:
				if (int_4 > int_3)
				{
					deflaterHuffman_0.FlushBlock(byte_0, int_3, int_4 - int_3, lastBlock: false);
					int_3 = int_4;
				}
				break;
			case 2:
				if (bool_0)
				{
					deflaterHuffman_0.TallyLit(byte_0[int_4 - 1] & 0xFF);
				}
				if (int_4 > int_3)
				{
					deflaterHuffman_0.FlushBlock(byte_0, int_3, int_4 - int_3, lastBlock: false);
					int_3 = int_4;
				}
				bool_0 = false;
				int_2 = 2;
				break;
			}
			int_10 = DeflaterConstants.COMPR_FUNC[level];
			return;
		}
		throw new ArgumentOutOfRangeException("level");
	}

	public void FillWindow()
	{
		if (int_4 >= 65274)
		{
			method_2();
		}
		if (int_5 < 262 && int_11 < int_12)
		{
			int num = 65536 - int_5 - int_4;
			if (num > int_12 - int_11)
			{
				num = int_12 - int_11;
			}
			Array.Copy(byte_1, int_11, byte_0, int_4 + int_5, num);
			adler32_0?.Update(new ArraySegment<byte>(byte_1, int_11, num));
			int_11 += num;
			long_0 += num;
			int_5 += num;
		}
		if (int_5 >= 3)
		{
			method_0();
		}
	}

	private void method_0()
	{
		int_0 = (byte_0[int_4] << 5) ^ byte_0[int_4 + 1];
	}

	private int method_1()
	{
		int num = ((int_0 << 5) ^ byte_0[int_4 + 2]) & 0x7FFF;
		short num2 = (short_1[int_4 & 0x7FFF] = short_0[num]);
		short_0[num] = (short)int_4;
		int_0 = num;
		return num2 & 0xFFFF;
	}

	private void method_2()
	{
		Array.Copy(byte_0, 32768, byte_0, 0, 32768);
		int_1 -= 32768;
		int_4 -= 32768;
		int_3 -= 32768;
		for (int i = 0; i < 32768; i++)
		{
			int num = short_0[i] & 0xFFFF;
			short_0[i] = (short)((num >= 32768) ? (num - 32768) : 0);
		}
		for (int j = 0; j < 32768; j++)
		{
			int num2 = short_1[j] & 0xFFFF;
			short_1[j] = (short)((num2 >= 32768) ? (num2 - 32768) : 0);
		}
	}

	private bool method_3(int int_13)
	{
		int num = int_4;
		int num2 = num + Math.Min(258, int_5) - 1;
		int num3 = Math.Max(num - 32506, 0);
		byte[] array = byte_0;
		short[] array2 = short_1;
		int num4 = int_6;
		int num5 = Math.Min(int_8, int_5);
		int_2 = Math.Max(int_2, 2);
		if (num + int_2 <= num2)
		{
			byte b = array[num + int_2 - 1];
			byte b2 = array[num + int_2];
			if (int_2 >= int_9)
			{
				num4 >>= 2;
			}
			do
			{
				int num6 = int_13;
				num = int_4;
				if (array[num6 + int_2] != b2 || array[num6 + int_2 - 1] != b || array[num6] != array[num] || array[++num6] != array[++num])
				{
					continue;
				}
				switch ((num2 - num) % 8)
				{
				case 1:
					if (array[++num] != array[++num6])
					{
					}
					break;
				case 2:
					if (array[++num] == array[++num6] && array[++num] != array[++num6])
					{
					}
					break;
				case 3:
					if (array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] != array[++num6])
					{
					}
					break;
				case 4:
					if (array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] != array[++num6])
					{
					}
					break;
				case 5:
					if (array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] != array[++num6])
					{
					}
					break;
				case 6:
					if (array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] != array[++num6])
					{
					}
					break;
				case 7:
					if (array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] == array[++num6])
					{
						_ = array[++num];
						_ = array[++num6];
					}
					break;
				}
				if (array[num] == array[num6])
				{
					do
					{
						if (num == num2)
						{
							num++;
							num6++;
							break;
						}
					}
					while (array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] == array[++num6] && array[++num] == array[++num6]);
				}
				if (num - int_4 > int_2)
				{
					int_1 = int_13;
					int_2 = num - int_4;
					if (int_2 >= num5)
					{
						break;
					}
					b = array[num - 1];
					b2 = array[num];
				}
			}
			while ((int_13 = array2[int_13 & 0x7FFF] & 0xFFFF) > num3 && --num4 != 0);
			return int_2 >= 3;
		}
		return false;
	}

	private bool method_4(bool bool_1, bool bool_2)
	{
		if (!bool_1 && int_5 == 0)
		{
			return false;
		}
		int_4 += int_5;
		int_5 = 0;
		int num = int_4 - int_3;
		if (num >= DeflaterConstants.MAX_BLOCK_SIZE || (int_3 < 32768 && num >= 32506) || bool_1)
		{
			bool flag = bool_2;
			if (num > DeflaterConstants.MAX_BLOCK_SIZE)
			{
				num = DeflaterConstants.MAX_BLOCK_SIZE;
				flag = false;
			}
			deflaterHuffman_0.FlushStoredBlock(byte_0, int_3, num, flag);
			int_3 += num;
			if (flag)
			{
				return false;
			}
			return num != 0;
		}
		return true;
	}

	private bool method_5(bool bool_1, bool bool_2)
	{
		if (int_5 < 262 && !bool_1)
		{
			return false;
		}
		while (true)
		{
			if (int_5 >= 262 || bool_1)
			{
				if (int_5 == 0)
				{
					break;
				}
				if (int_4 > 65274)
				{
					method_2();
				}
				int num;
				if (int_5 >= 3 && (num = method_1()) != 0 && deflateStrategy_0 != DeflateStrategy.HuffmanOnly && int_4 - num <= 32506 && method_3(num))
				{
					bool flag = deflaterHuffman_0.TallyDist(int_4 - int_1, int_2);
					int_5 -= int_2;
					if (int_2 <= int_7 && int_5 >= 3)
					{
						while (--int_2 > 0)
						{
							int_4++;
							method_1();
						}
						int_4++;
					}
					else
					{
						int_4 += int_2;
						if (int_5 >= 2)
						{
							method_0();
						}
					}
					int_2 = 2;
					if (!flag)
					{
						continue;
					}
				}
				else
				{
					deflaterHuffman_0.TallyLit(byte_0[int_4] & 0xFF);
					int_4++;
					int_5--;
				}
				if (deflaterHuffman_0.IsFull())
				{
					bool flag2 = bool_2 && int_5 == 0;
					deflaterHuffman_0.FlushBlock(byte_0, int_3, int_4 - int_3, flag2);
					int_3 = int_4;
					return !flag2;
				}
				continue;
			}
			return true;
		}
		deflaterHuffman_0.FlushBlock(byte_0, int_3, int_4 - int_3, bool_2);
		int_3 = int_4;
		return false;
	}

	private bool method_6(bool bool_1, bool bool_2)
	{
		if (int_5 < 262 && !bool_1)
		{
			return false;
		}
		while (true)
		{
			if (int_5 >= 262 || bool_1)
			{
				if (int_5 == 0)
				{
					break;
				}
				if (int_4 >= 65274)
				{
					method_2();
				}
				int num = int_1;
				int num2 = int_2;
				if (int_5 >= 3)
				{
					int num3 = method_1();
					if (deflateStrategy_0 != DeflateStrategy.HuffmanOnly && num3 != 0 && int_4 - num3 <= 32506 && method_3(num3) && int_2 <= 5 && (deflateStrategy_0 == DeflateStrategy.Filtered || (int_2 == 3 && int_4 - int_1 > 4096)))
					{
						int_2 = 2;
					}
				}
				if (num2 >= 3 && int_2 <= num2)
				{
					deflaterHuffman_0.TallyDist(int_4 - 1 - num, num2);
					num2 -= 2;
					do
					{
						int_4++;
						int_5--;
						if (int_5 >= 3)
						{
							method_1();
						}
					}
					while (--num2 > 0);
					int_4++;
					int_5--;
					bool_0 = false;
					int_2 = 2;
				}
				else
				{
					if (bool_0)
					{
						deflaterHuffman_0.TallyLit(byte_0[int_4 - 1] & 0xFF);
					}
					bool_0 = true;
					int_4++;
					int_5--;
				}
				if (deflaterHuffman_0.IsFull())
				{
					int num4 = int_4 - int_3;
					if (bool_0)
					{
						num4--;
					}
					bool flag = bool_2 && int_5 == 0 && !bool_0;
					deflaterHuffman_0.FlushBlock(byte_0, int_3, num4, flag);
					int_3 += num4;
					return !flag;
				}
				continue;
			}
			return true;
		}
		if (bool_0)
		{
			deflaterHuffman_0.TallyLit(byte_0[int_4 - 1] & 0xFF);
		}
		bool_0 = false;
		deflaterHuffman_0.FlushBlock(byte_0, int_3, int_4 - int_3, bool_2);
		int_3 = int_4;
		return false;
	}

	static DeflaterEngine()
	{
		Class72.smethod_20();
	}
}
