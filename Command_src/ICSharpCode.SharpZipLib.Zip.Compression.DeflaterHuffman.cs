using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression;

public class DeflaterHuffman
{
	private class Class36
	{
		public short[] short_0;

		public byte[] byte_0;

		public int int_0;

		public int int_1;

		private short[] short_1;

		private readonly int[] int_2;

		private readonly int int_3;

		private DeflaterHuffman deflaterHuffman_0;

		public Class36(DeflaterHuffman deflaterHuffman_1, int int_4, int int_5, int int_6)
		{
			deflaterHuffman_0 = deflaterHuffman_1;
			int_0 = int_5;
			int_3 = int_6;
			short_0 = new short[int_4];
			int_2 = new int[int_6];
		}

		public void Reset()
		{
			for (int i = 0; i < short_0.Length; i++)
			{
				short_0[i] = 0;
			}
			short_1 = null;
			byte_0 = null;
		}

		public void method_0(int int_4)
		{
			deflaterHuffman_0.pending.WriteBits(short_1[int_4] & 0xFFFF, byte_0[int_4]);
		}

		public void method_1()
		{
			bool flag = true;
			for (int i = 0; i < short_0.Length; i++)
			{
				flag &= short_0[i] == 0;
			}
			if (!flag)
			{
				throw new SharpZipBaseException("!Empty");
			}
		}

		public void BfFeXegVpSi(short[] short_2, byte[] byte_1)
		{
			short_1 = short_2;
			byte_0 = byte_1;
		}

		public void method_2()
		{
			int[] array = new int[int_3];
			int num = 0;
			short_1 = new short[short_0.Length];
			for (int i = 0; i < int_3; i++)
			{
				array[i] = num;
				num += int_2[i] << 15 - i;
			}
			for (int j = 0; j < int_1; j++)
			{
				int num2 = byte_0[j];
				if (num2 > 0)
				{
					short_1[j] = BitReverse(array[num2 - 1]);
					array[num2 - 1] += 1 << 16 - num2;
				}
			}
		}

		public void method_3()
		{
			int num = short_0.Length;
			int[] array = new int[num];
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				int num4 = short_0[i];
				if (num4 != 0)
				{
					int num5 = num2++;
					int num6;
					while (num5 > 0 && short_0[array[num6 = (num5 - 1) / 2]] > num4)
					{
						array[num5] = array[num6];
						num5 = num6;
					}
					array[num5] = i;
					num3 = i;
				}
			}
			while (num2 < 2)
			{
				int num7 = ((num3 < 2) ? (++num3) : 0);
				array[num2++] = num7;
			}
			int_1 = Math.Max(num3 + 1, int_0);
			int num8 = num2;
			int[] array2 = new int[4 * num2 - 2];
			int[] array3 = new int[2 * num2 - 1];
			int num9 = num8;
			for (int j = 0; j < num2; j++)
			{
				int num10 = (array2[2 * j] = array[j]);
				array2[2 * j + 1] = -1;
				array3[j] = short_0[num10] << 8;
				array[j] = j;
			}
			do
			{
				int num11 = array[0];
				int num12 = array[--num2];
				int num13 = 0;
				int num14;
				for (num14 = 1; num14 < num2; num14 = num14 * 2 + 1)
				{
					if (num14 + 1 < num2 && array3[array[num14]] > array3[array[num14 + 1]])
					{
						num14++;
					}
					array[num13] = array[num14];
					num13 = num14;
				}
				int num15 = array3[num12];
				while ((num14 = num13) > 0 && array3[array[num13 = (num14 - 1) / 2]] > num15)
				{
					array[num14] = array[num13];
				}
				array[num14] = num12;
				int num16 = array[0];
				num12 = num9++;
				array2[2 * num12] = num11;
				array2[2 * num12 + 1] = num16;
				int num17 = Math.Min(array3[num11] & 0xFF, array3[num16] & 0xFF);
				num15 = (array3[num12] = array3[num11] + array3[num16] - num17 + 1);
				num13 = 0;
				for (num14 = 1; num14 < num2; num14 = num13 * 2 + 1)
				{
					if (num14 + 1 < num2 && array3[array[num14]] > array3[array[num14 + 1]])
					{
						num14++;
					}
					array[num13] = array[num14];
					num13 = num14;
				}
				while ((num14 = num13) > 0 && array3[array[num13 = (num14 - 1) / 2]] > num15)
				{
					array[num14] = array[num13];
				}
				array[num14] = num12;
			}
			while (num2 > 1);
			if (array[0] != array2.Length / 2 - 1)
			{
				throw new SharpZipBaseException("Heap invariant violated");
			}
			method_7(array2);
		}

		public int method_4()
		{
			int num = 0;
			for (int i = 0; i < short_0.Length; i++)
			{
				num += short_0[i] * byte_0[i];
			}
			return num;
		}

		public void method_5(Class36 class36_0)
		{
			int num = -1;
			int num2 = 0;
			while (num2 < int_1)
			{
				int num3 = 1;
				int num4 = byte_0[num2];
				int num5;
				int num6;
				if (num4 != 0)
				{
					num5 = 6;
					num6 = 3;
					if (num != num4)
					{
						class36_0.short_0[num4]++;
						num3 = 0;
					}
				}
				else
				{
					num5 = 138;
					num6 = 3;
				}
				num = num4;
				num2++;
				while (num2 < int_1 && num == byte_0[num2])
				{
					num2++;
					if (++num3 >= num5)
					{
						break;
					}
				}
				if (num3 >= num6)
				{
					if (num != 0)
					{
						class36_0.short_0[16]++;
					}
					else if (num3 > 10)
					{
						class36_0.short_0[18]++;
					}
					else
					{
						class36_0.short_0[17]++;
					}
				}
				else
				{
					class36_0.short_0[num] += (short)num3;
				}
			}
		}

		public void method_6(Class36 class36_0)
		{
			int num = -1;
			int num2 = 0;
			while (num2 < int_1)
			{
				int num3 = 1;
				int num4 = byte_0[num2];
				int num5;
				int num6;
				if (num4 != 0)
				{
					num5 = 6;
					num6 = 3;
					if (num != num4)
					{
						class36_0.method_0(num4);
						num3 = 0;
					}
				}
				else
				{
					num5 = 138;
					num6 = 3;
				}
				num = num4;
				num2++;
				while (num2 < int_1 && num == byte_0[num2])
				{
					num2++;
					if (++num3 >= num5)
					{
						break;
					}
				}
				if (num3 < num6)
				{
					while (num3-- > 0)
					{
						class36_0.method_0(num);
					}
				}
				else if (num != 0)
				{
					class36_0.method_0(16);
					deflaterHuffman_0.pending.WriteBits(num3 - 3, 2);
				}
				else if (num3 <= 10)
				{
					class36_0.method_0(17);
					deflaterHuffman_0.pending.WriteBits(num3 - 3, 3);
				}
				else
				{
					class36_0.method_0(18);
					deflaterHuffman_0.pending.WriteBits(num3 - 11, 7);
				}
			}
		}

		private void method_7(int[] int_4)
		{
			byte_0 = new byte[short_0.Length];
			int num = int_4.Length / 2;
			int num2 = (num + 1) / 2;
			int num3 = 0;
			for (int i = 0; i < int_3; i++)
			{
				int_2[i] = 0;
			}
			int[] array = new int[num];
			array[num - 1] = 0;
			for (int num4 = num - 1; num4 >= 0; num4--)
			{
				if (int_4[2 * num4 + 1] != -1)
				{
					int num5 = array[num4] + 1;
					if (num5 > int_3)
					{
						num5 = int_3;
						num3++;
					}
					array[int_4[2 * num4]] = (array[int_4[2 * num4 + 1]] = num5);
				}
				else
				{
					int num6 = array[num4];
					int_2[num6 - 1]++;
					byte_0[int_4[2 * num4]] = (byte)array[num4];
				}
			}
			if (num3 == 0)
			{
				return;
			}
			int num7 = int_3 - 1;
			while (true)
			{
				if (int_2[--num7] != 0)
				{
					do
					{
						int_2[num7]--;
						int_2[++num7]++;
						num3 -= 1 << int_3 - 1 - num7;
					}
					while (num3 > 0 && num7 < int_3 - 1);
					if (num3 <= 0)
					{
						break;
					}
				}
			}
			int_2[int_3 - 1] += num3;
			int_2[int_3 - 2] -= num3;
			int num8 = 2 * num2;
			for (int num9 = int_3; num9 != 0; num9--)
			{
				int num10 = int_2[num9 - 1];
				while (num10 > 0)
				{
					int num11 = 2 * int_4[num8++];
					if (int_4[num11 + 1] == -1)
					{
						byte_0[int_4[num11]] = (byte)num9;
						num10--;
					}
				}
			}
		}

		static Class36()
		{
			Class72.smethod_20();
		}
	}

	private static readonly int[] int_0;

	private static readonly byte[] byte_0;

	private static short[] short_0;

	private static byte[] byte_1;

	private static short[] short_1;

	private static byte[] byte_2;

	public DeflaterPending pending;

	private Class36 class36_0;

	private Class36 class36_1;

	private Class36 class36_2;

	private short[] short_2;

	private byte[] byte_3;

	private int int_1;

	private int int_2;

	static DeflaterHuffman()
	{
		Class72.smethod_20();
		int_0 = new int[19]
		{
			16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
			11, 4, 12, 3, 13, 2, 14, 1, 15
		};
		byte_0 = new byte[16]
		{
			0, 8, 4, 12, 2, 10, 6, 14, 1, 9,
			5, 13, 3, 11, 7, 15
		};
		short_0 = new short[286];
		byte_1 = new byte[286];
		int num = 0;
		while (num < 144)
		{
			short_0[num] = BitReverse(48 + num << 8);
			byte_1[num++] = 8;
		}
		while (num < 256)
		{
			short_0[num] = BitReverse(256 + num << 7);
			byte_1[num++] = 9;
		}
		while (num < 280)
		{
			short_0[num] = BitReverse(-256 + num << 9);
			byte_1[num++] = 7;
		}
		while (num < 286)
		{
			short_0[num] = BitReverse(-88 + num << 8);
			byte_1[num++] = 8;
		}
		short_1 = new short[30];
		byte_2 = new byte[30];
		for (num = 0; num < 30; num++)
		{
			short_1[num] = BitReverse(num << 11);
			byte_2[num] = 5;
		}
	}

	public DeflaterHuffman(DeflaterPending pending)
	{
		this.pending = pending;
		class36_0 = new Class36(this, 286, 257, 15);
		class36_1 = new Class36(this, 30, 1, 15);
		class36_2 = new Class36(this, 19, 4, 7);
		short_2 = new short[16384];
		byte_3 = new byte[16384];
	}

	public void Reset()
	{
		int_1 = 0;
		int_2 = 0;
		class36_0.Reset();
		class36_1.Reset();
		class36_2.Reset();
	}

	public void SendAllTrees(int blTreeCodes)
	{
		class36_2.method_2();
		class36_0.method_2();
		class36_1.method_2();
		pending.WriteBits(class36_0.int_1 - 257, 5);
		pending.WriteBits(class36_1.int_1 - 1, 5);
		pending.WriteBits(blTreeCodes - 4, 4);
		for (int i = 0; i < blTreeCodes; i++)
		{
			pending.WriteBits(class36_2.byte_0[int_0[i]], 3);
		}
		class36_0.method_6(class36_2);
		class36_1.method_6(class36_2);
	}

	public void CompressBlock()
	{
		for (int i = 0; i < int_1; i++)
		{
			int num = byte_3[i] & 0xFF;
			int num2 = short_2[i];
			if (num2-- == 0)
			{
				class36_0.method_0(num);
				continue;
			}
			int num3 = smethod_0(num);
			class36_0.method_0(num3);
			int num4 = (num3 - 261) / 4;
			if (num4 > 0 && num4 <= 5)
			{
				pending.WriteBits(num & ((1 << num4) - 1), num4);
			}
			int num5 = smethod_1(num2);
			class36_1.method_0(num5);
			num4 = num5 / 2 - 1;
			if (num4 > 0)
			{
				pending.WriteBits(num2 & ((1 << num4) - 1), num4);
			}
		}
		class36_0.method_0(256);
	}

	public void FlushStoredBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
	{
		pending.WriteBits(lastBlock ? 1 : 0, 3);
		pending.AlignToByte();
		pending.WriteShort(storedLength);
		pending.WriteShort(~storedLength);
		pending.WriteBlock(stored, storedOffset, storedLength);
		Reset();
	}

	public void FlushBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
	{
		class36_0.short_0[256]++;
		class36_0.method_3();
		class36_1.method_3();
		class36_0.method_5(class36_2);
		class36_1.method_5(class36_2);
		class36_2.method_3();
		int num = 4;
		for (int num2 = 18; num2 > num; num2--)
		{
			if (class36_2.byte_0[int_0[num2]] > 0)
			{
				num = num2 + 1;
			}
		}
		int num3 = 14 + num * 3 + class36_2.method_4() + class36_0.method_4() + class36_1.method_4() + int_2;
		int num4 = int_2;
		for (int i = 0; i < 286; i++)
		{
			num4 += class36_0.short_0[i] * byte_1[i];
		}
		for (int j = 0; j < 30; j++)
		{
			num4 += class36_1.short_0[j] * byte_2[j];
		}
		if (num3 >= num4)
		{
			num3 = num4;
		}
		if (storedOffset >= 0 && storedLength + 4 < num3 >> 3)
		{
			FlushStoredBlock(stored, storedOffset, storedLength, lastBlock);
		}
		else if (num3 == num4)
		{
			pending.WriteBits(2 + (lastBlock ? 1 : 0), 3);
			class36_0.BfFeXegVpSi(short_0, byte_1);
			class36_1.BfFeXegVpSi(short_1, byte_2);
			CompressBlock();
			Reset();
		}
		else
		{
			pending.WriteBits(4 + (lastBlock ? 1 : 0), 3);
			SendAllTrees(num);
			CompressBlock();
			Reset();
		}
	}

	public bool IsFull()
	{
		return int_1 >= 16384;
	}

	public bool TallyLit(int literal)
	{
		short_2[int_1] = 0;
		byte_3[int_1++] = (byte)literal;
		class36_0.short_0[literal]++;
		return IsFull();
	}

	public bool TallyDist(int distance, int length)
	{
		short_2[int_1] = (short)distance;
		byte_3[int_1++] = (byte)(length - 3);
		int num = smethod_0(length - 3);
		class36_0.short_0[num]++;
		if (num >= 265 && num < 285)
		{
			int_2 += (num - 261) / 4;
		}
		int num2 = smethod_1(distance - 1);
		class36_1.short_0[num2]++;
		if (num2 >= 4)
		{
			int_2 += num2 / 2 - 1;
		}
		return IsFull();
	}

	public static short BitReverse(int toReverse)
	{
		return (short)((byte_0[toReverse & 0xF] << 12) | (byte_0[(toReverse >> 4) & 0xF] << 8) | (byte_0[(toReverse >> 8) & 0xF] << 4) | byte_0[toReverse >> 12]);
	}

	private static int smethod_0(int int_3)
	{
		if (int_3 == 255)
		{
			return 285;
		}
		int num = 257;
		while (int_3 >= 8)
		{
			num += 4;
			int_3 >>= 1;
		}
		return num + int_3;
	}

	private static int smethod_1(int int_3)
	{
		int num = 0;
		while (int_3 >= 4)
		{
			num += 2;
			int_3 >>= 1;
		}
		return num + int_3;
	}
}
