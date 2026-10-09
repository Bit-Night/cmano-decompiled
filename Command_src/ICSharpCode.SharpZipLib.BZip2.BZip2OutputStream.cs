using System;
using System.IO;
using System.Runtime.CompilerServices;
using ICSharpCode.SharpZipLib.Checksum;

namespace ICSharpCode.SharpZipLib.BZip2;

public class BZip2OutputStream : Stream
{
	private struct Struct43
	{
		public int int_0;

		public int int_1;

		public int int_2;
	}

	private readonly int[] int_0 = new int[14]
	{
		1, 4, 13, 40, 121, 364, 1093, 3280, 9841, 29524,
		88573, 265720, 797161, 2391484
	};

	private int int_1;

	private int int_2;

	private int int_3;

	private bool bool_0;

	private int int_4;

	private int UmOybwwXmsl;

	private int int_5;

	private IChecksum ichecksum_0 = new BZip2Crc();

	private bool[] bool_1 = new bool[256];

	private int int_6;

	private char[] char_0 = new char[256];

	private char[] char_1 = new char[256];

	private char[] char_2 = new char[18002];

	private char[] char_3 = new char[18002];

	private byte[] byte_0;

	private int[] int_7;

	private int[] int_8;

	private short[] short_0;

	private int[] int_9;

	private int JkYybuSudIJ;

	private int[] int_10 = new int[258];

	private int int_11;

	private int int_12;

	private int int_13;

	private bool bool_2;

	private int jiTybAtNiEo;

	private int int_14 = -1;

	private int int_15;

	private uint uint_0;

	private uint uint_1;

	private int int_16;

	private readonly Stream stream_0;

	private bool bool_3;

	[CompilerGenerated]
	private bool bool_4 = true;

	public bool IsStreamOwner
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	public override bool CanRead => false;

	public override bool CanSeek => false;

	public override bool CanWrite => stream_0.CanWrite;

	public override long Length => stream_0.Length;

	public override long Position
	{
		get
		{
			return stream_0.Position;
		}
		set
		{
			throw new NotSupportedException("BZip2OutputStream position cannot be set");
		}
	}

	public int BytesWritten => int_4;

	public BZip2OutputStream(Stream stream)
		: this(stream, 9)
	{
	}

	public BZip2OutputStream(Stream stream, int blockSize)
	{
		if (stream != null)
		{
			stream_0 = stream;
			int_5 = 0;
			UmOybwwXmsl = 0;
			int_4 = 0;
			int_11 = 50;
			if (blockSize > 9)
			{
				blockSize = 9;
			}
			if (blockSize < 1)
			{
				blockSize = 1;
			}
			int_3 = blockSize;
			method_19();
			method_1();
			method_2();
			return;
		}
		throw new ArgumentNullException("stream");
	}

	~BZip2OutputStream()
	{
		Dispose(disposing: false);
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException("BZip2OutputStream Seek not supported");
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException("BZip2OutputStream SetLength not supported");
	}

	public override int ReadByte()
	{
		throw new NotSupportedException("BZip2OutputStream ReadByte not supported");
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException("BZip2OutputStream Read not supported");
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset < 0)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (buffer.Length - offset < count)
		{
			throw new ArgumentException("Offset/count out of range");
		}
		for (int i = 0; i < count; i++)
		{
			WriteByte(buffer[offset + i]);
		}
	}

	public override void WriteByte(byte value)
	{
		int num = (256 + value) % 256;
		if (int_14 != -1)
		{
			if (int_14 == num)
			{
				int_15++;
				if (int_15 > 254)
				{
					method_0();
					int_14 = -1;
					int_15 = 0;
				}
			}
			else
			{
				method_0();
				int_15 = 1;
				int_14 = num;
			}
		}
		else
		{
			int_14 = num;
			int_15++;
		}
	}

	private void DcDyfzUfaDX()
	{
		int_6 = 0;
		for (int i = 0; i < 256; i++)
		{
			if (bool_1[i])
			{
				char_0[int_6] = (char)i;
				char_1[i] = (char)int_6;
				int_6++;
			}
		}
	}

	private void method_0()
	{
		if (int_1 >= int_16)
		{
			method_3();
			method_2();
			method_0();
			return;
		}
		bool_1[int_14] = true;
		for (int i = 0; i < int_15; i++)
		{
			ichecksum_0.Update(int_14);
		}
		switch (int_15)
		{
		default:
			bool_1[int_15 - 4] = true;
			int_1++;
			byte_0[int_1 + 1] = (byte)int_14;
			int_1++;
			byte_0[int_1 + 1] = (byte)int_14;
			int_1++;
			byte_0[int_1 + 1] = (byte)int_14;
			int_1++;
			byte_0[int_1 + 1] = (byte)int_14;
			int_1++;
			byte_0[int_1 + 1] = (byte)(int_15 - 4);
			break;
		case 1:
			int_1++;
			byte_0[int_1 + 1] = (byte)int_14;
			break;
		case 2:
			int_1++;
			byte_0[int_1 + 1] = (byte)int_14;
			int_1++;
			byte_0[int_1 + 1] = (byte)int_14;
			break;
		case 3:
			int_1++;
			byte_0[int_1 + 1] = (byte)int_14;
			int_1++;
			byte_0[int_1 + 1] = (byte)int_14;
			int_1++;
			byte_0[int_1 + 1] = (byte)int_14;
			break;
		}
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			try
			{
				base.Dispose(disposing);
				if (!bool_3)
				{
					bool_3 = true;
					if (int_15 > 0)
					{
						method_0();
					}
					int_14 = -1;
					method_3();
					method_4();
					Flush();
				}
			}
			finally
			{
				if (disposing && IsStreamOwner)
				{
					stream_0.Dispose();
				}
			}
		}
		catch
		{
		}
	}

	public override void Flush()
	{
		stream_0.Flush();
	}

	private void method_1()
	{
		int_4 = 0;
		jiTybAtNiEo = 0;
		method_7(66);
		method_7(90);
		method_7(104);
		method_7(48 + int_3);
		uint_1 = 0u;
	}

	private void method_2()
	{
		ichecksum_0.Reset();
		int_1 = -1;
		for (int i = 0; i < 256; i++)
		{
			bool_1[i] = false;
		}
		int_16 = 100000 * int_3 - 20;
	}

	private void method_3()
	{
		if (int_1 >= 0)
		{
			uint_0 = (uint)ichecksum_0.Value;
			uint_1 = (uint_1 << 1) | (uint_1 >> 31);
			uint_1 ^= uint_0;
			method_17();
			method_7(49);
			method_7(65);
			method_7(89);
			method_7(38);
			method_7(83);
			method_7(89);
			method_8((int)uint_0);
			if (!bool_0)
			{
				method_6(1, 0);
			}
			else
			{
				method_6(1, 1);
				jiTybAtNiEo++;
			}
			method_11();
		}
	}

	private void method_4()
	{
		method_7(23);
		method_7(114);
		method_7(69);
		method_7(56);
		method_7(80);
		method_7(144);
		method_8((int)uint_1);
		method_5();
	}

	private void method_5()
	{
		while (int_5 > 0)
		{
			int num = UmOybwwXmsl >> 24;
			stream_0.WriteByte((byte)num);
			UmOybwwXmsl <<= 8;
			int_5 -= 8;
			int_4++;
		}
	}

	private void method_6(int int_17, int int_18)
	{
		while (int_5 >= 8)
		{
			int num = UmOybwwXmsl >> 24;
			stream_0.WriteByte((byte)num);
			UmOybwwXmsl <<= 8;
			int_5 -= 8;
			int_4++;
		}
		UmOybwwXmsl |= int_18 << 32 - int_5 - int_17;
		int_5 += int_17;
	}

	private void method_7(int int_17)
	{
		method_6(8, int_17);
	}

	private void method_8(int int_17)
	{
		method_6(8, (int_17 >> 24) & 0xFF);
		method_6(8, (int_17 >> 16) & 0xFF);
		method_6(8, (int_17 >> 8) & 0xFF);
		method_6(8, int_17 & 0xFF);
	}

	private void method_9(int int_17, int int_18)
	{
		method_6(int_17, int_18);
	}

	private void method_10()
	{
		char[][] array = new char[6][];
		for (int i = 0; i < 6; i++)
		{
			array[i] = new char[258];
		}
		int num = 0;
		int num2 = int_6 + 2;
		for (int j = 0; j < 6; j++)
		{
			for (int k = 0; k < num2; k++)
			{
				array[j][k] = '\u000f';
			}
		}
		if (JkYybuSudIJ <= 0)
		{
			smethod_0();
		}
		int num3 = ((JkYybuSudIJ < 200) ? 2 : ((JkYybuSudIJ < 600) ? 3 : ((JkYybuSudIJ < 1200) ? 4 : ((JkYybuSudIJ < 2400) ? 5 : 6))));
		int num4 = num3;
		int num5 = JkYybuSudIJ;
		int num6 = 0;
		while (num4 > 0)
		{
			int num7 = num5 / num4;
			int l = 0;
			int num8;
			for (num8 = num6 - 1; l < num7; l += int_10[num8])
			{
				if (num8 >= num2 - 1)
				{
					break;
				}
				num8++;
			}
			int num9;
			if (num8 > num6 && num4 != num3 && num4 != 1 && (num3 - num4) % 2 == 1)
			{
				l -= int_10[num8];
				num8--;
				num9 = 0;
			}
			else
			{
				num9 = 0;
			}
			for (int m = num9; m < num2; m++)
			{
				if (m >= num6 && m <= num8)
				{
					array[num4 - 1][m] = '\0';
				}
				else
				{
					array[num4 - 1][m] = '\u000f';
				}
			}
			num4--;
			num6 = num8 + 1;
			num5 -= l;
		}
		int[][] array2 = new int[6][];
		for (int n = 0; n < 6; n++)
		{
			array2[n] = new int[258];
		}
		int[] array3 = new int[6];
		short[] array4 = new short[6];
		for (int num10 = 0; num10 < 4; num10++)
		{
			for (int num11 = 0; num11 < num3; num11++)
			{
				array3[num11] = 0;
			}
			for (int num12 = 0; num12 < num3; num12++)
			{
				for (int num13 = 0; num13 < num2; num13++)
				{
					array2[num12][num13] = 0;
				}
			}
			num = 0;
			int num14 = 0;
			num6 = 0;
			while (num6 < JkYybuSudIJ)
			{
				int num8 = num6 + 50 - 1;
				int num15;
				if (num8 < JkYybuSudIJ)
				{
					num15 = 0;
				}
				else
				{
					num8 = JkYybuSudIJ - 1;
					num15 = 0;
				}
				for (int num16 = num15; num16 < num3; num16++)
				{
					array4[num16] = 0;
				}
				int num25;
				if (num3 == 6)
				{
					short num17 = 0;
					short num18 = 0;
					short num19 = 0;
					short num20 = 0;
					short num21 = 0;
					short num22 = 0;
					for (int num23 = num6; num23 <= num8; num23++)
					{
						short num24 = short_0[num23];
						num22 += (short)array[0][num24];
						num21 += (short)array[1][num24];
						num20 += (short)array[2][num24];
						num19 += (short)array[3][num24];
						num18 += (short)array[4][num24];
						num17 += (short)array[5][num24];
					}
					array4[0] = num22;
					array4[1] = num21;
					array4[2] = num20;
					array4[3] = num19;
					array4[4] = num18;
					array4[5] = num17;
					num25 = 999999999;
				}
				else
				{
					for (int num26 = num6; num26 <= num8; num26++)
					{
						short num27 = short_0[num26];
						for (int num28 = 0; num28 < num3; num28++)
						{
							array4[num28] += (short)array[num28][num27];
						}
					}
					num25 = 999999999;
				}
				int num29 = num25;
				int num30 = -1;
				for (int num31 = 0; num31 < num3; num31++)
				{
					if (array4[num31] < num29)
					{
						num29 = array4[num31];
						num30 = num31;
					}
				}
				num14 += num29;
				array3[num30]++;
				char_2[num] = (char)num30;
				num++;
				for (int num32 = num6; num32 <= num8; num32++)
				{
					array2[num30][short_0[num32]]++;
				}
				num6 = num8 + 1;
			}
			for (int num33 = 0; num33 < num3; num33++)
			{
				smethod_1(array[num33], array2[num33], num2, 20);
			}
		}
		array2 = null;
		array3 = null;
		array4 = null;
		if (num3 >= 8)
		{
			smethod_0();
		}
		int num34;
		if (num < 32768 && num <= 18002)
		{
			num34 = 6;
		}
		else
		{
			smethod_0();
			num34 = 6;
		}
		char[] array5 = new char[num34];
		for (int num35 = 0; num35 < num3; num35++)
		{
			array5[num35] = (char)num35;
		}
		for (int num36 = 0; num36 < num; num36++)
		{
			char c = char_2[num36];
			int num37 = 0;
			char c2 = array5[0];
			while (c != c2)
			{
				num37++;
				char c3 = c2;
				c2 = array5[num37];
				array5[num37] = c3;
			}
			array5[0] = c2;
			char_3[num36] = (char)num37;
		}
		int[][] array6 = new int[6][];
		for (int num38 = 0; num38 < 6; num38++)
		{
			array6[num38] = new int[258];
		}
		for (int num39 = 0; num39 < num3; num39++)
		{
			int num40 = 32;
			int num41 = 0;
			for (int num42 = 0; num42 < num2; num42++)
			{
				if (array[num39][num42] > num41)
				{
					num41 = array[num39][num42];
				}
				if (array[num39][num42] < num40)
				{
					num40 = array[num39][num42];
				}
			}
			if (num41 > 20)
			{
				smethod_0();
			}
			if (num40 < 1)
			{
				smethod_0();
			}
			smethod_2(array6[num39], array[num39], num40, num41, num2);
		}
		bool[] array7 = new bool[16];
		for (int num43 = 0; num43 < 16; num43++)
		{
			array7[num43] = false;
			for (int num44 = 0; num44 < 16; num44++)
			{
				if (bool_1[num43 * 16 + num44])
				{
					array7[num43] = true;
				}
			}
		}
		for (int num45 = 0; num45 < 16; num45++)
		{
			if (!array7[num45])
			{
				method_6(1, 0);
			}
			else
			{
				method_6(1, 1);
			}
		}
		for (int num46 = 0; num46 < 16; num46++)
		{
			if (!array7[num46])
			{
				continue;
			}
			for (int num47 = 0; num47 < 16; num47++)
			{
				if (!bool_1[num46 * 16 + num47])
				{
					method_6(1, 0);
				}
				else
				{
					method_6(1, 1);
				}
			}
		}
		method_6(3, num3);
		method_6(15, num);
		for (int num48 = 0; num48 < num; num48++)
		{
			for (int num49 = 0; num49 < char_3[num48]; num49++)
			{
				method_6(1, 1);
			}
			method_6(1, 0);
		}
		for (int num50 = 0; num50 < num3; num50++)
		{
			int num51 = array[num50][0];
			method_6(5, num51);
			for (int num52 = 0; num52 < num2; num52++)
			{
				for (; num51 < array[num50][num52]; num51++)
				{
					method_6(2, 2);
				}
				while (num51 > array[num50][num52])
				{
					method_6(2, 3);
					num51--;
				}
				method_6(1, 0);
			}
		}
		int num53 = 0;
		num6 = 0;
		while (num6 < JkYybuSudIJ)
		{
			int num8 = num6 + 50 - 1;
			if (num8 >= JkYybuSudIJ)
			{
				num8 = JkYybuSudIJ - 1;
			}
			for (int num54 = num6; num54 <= num8; num54++)
			{
				method_6(array[(uint)char_2[num53]][short_0[num54]], array6[(uint)char_2[num53]][short_0[num54]]);
			}
			num6 = num8 + 1;
			num53++;
		}
		if (num53 != num)
		{
			smethod_0();
		}
	}

	private void method_11()
	{
		method_9(24, int_2);
		method_20();
		method_10();
	}

	private void method_12(int int_17, int int_18, int int_19)
	{
		int num = int_18 - int_17 + 1;
		if (num < 2)
		{
			return;
		}
		int i;
		for (i = 0; int_0[i] < num; i++)
		{
		}
		for (i--; i >= 0; i--)
		{
			int num2 = int_0[i];
			int num3 = int_17 + num2;
			while (num3 <= int_18)
			{
				int num4 = int_8[num3];
				int num5 = num3;
				while (method_18(int_8[num5 - num2] + int_19, num4 + int_19))
				{
					int_8[num5] = int_8[num5 - num2];
					num5 -= num2;
					if (num5 <= int_17 + num2 - 1)
					{
						break;
					}
				}
				int_8[num5] = num4;
				num3++;
				if (num3 > int_18)
				{
					break;
				}
				num4 = int_8[num3];
				num5 = num3;
				while (method_18(int_8[num5 - num2] + int_19, num4 + int_19))
				{
					int_8[num5] = int_8[num5 - num2];
					num5 -= num2;
					if (num5 <= int_17 + num2 - 1)
					{
						break;
					}
				}
				int_8[num5] = num4;
				num3++;
				if (num3 > int_18)
				{
					break;
				}
				num4 = int_8[num3];
				num5 = num3;
				while (method_18(int_8[num5 - num2] + int_19, num4 + int_19))
				{
					int_8[num5] = int_8[num5 - num2];
					num5 -= num2;
					if (num5 <= int_17 + num2 - 1)
					{
						break;
					}
				}
				int_8[num5] = num4;
				num3++;
				if (int_12 > int_13 && bool_2)
				{
					return;
				}
			}
		}
	}

	private void method_13(int int_17, int int_18, int int_19)
	{
		int num = 0;
		while (int_19 > 0)
		{
			num = int_8[int_17];
			int_8[int_17] = int_8[int_18];
			int_8[int_18] = num;
			int_17++;
			int_18++;
			int_19--;
		}
	}

	private void method_14(int int_17, int int_18, int int_19)
	{
		Struct43[] array = new Struct43[1000];
		int num = 0;
		array[0].int_0 = int_17;
		array[0].int_1 = int_18;
		array[0].int_2 = int_19;
		num = 1;
		while (num > 0)
		{
			if (num >= 1000)
			{
				smethod_0();
			}
			num--;
			int num2 = array[num].int_0;
			int num3 = array[num].int_1;
			int num4 = array[num].int_2;
			if (num3 - num2 >= 20 && num4 <= 10)
			{
				int num5 = smethod_3(byte_0[int_8[num2] + num4 + 1], byte_0[int_8[num3] + num4 + 1], byte_0[int_8[num2 + num3 >> 1] + num4 + 1]);
				int num7;
				int num6 = (num7 = num2);
				int num9;
				int num8 = (num9 = num3);
				while (true)
				{
					if (num6 <= num8)
					{
						int num10 = byte_0[int_8[num6] + num4 + 1] - num5;
						if (num10 == 0)
						{
							int num11 = int_8[num6];
							int_8[num6] = int_8[num7];
							int_8[num7] = num11;
							num7++;
							num6++;
							continue;
						}
						if (num10 <= 0)
						{
							num6++;
							continue;
						}
					}
					while (num6 <= num8)
					{
						int num10 = byte_0[int_8[num8] + num4 + 1] - num5;
						if (num10 == 0)
						{
							int num12 = int_8[num8];
							int_8[num8] = int_8[num9];
							int_8[num9] = num12;
							num9--;
							num8--;
						}
						else
						{
							if (num10 < 0)
							{
								break;
							}
							num8--;
						}
					}
					if (num6 > num8)
					{
						break;
					}
					int num13 = int_8[num6];
					int_8[num6] = int_8[num8];
					int_8[num8] = num13;
					num6++;
					num8--;
				}
				if (num9 >= num7)
				{
					int num10 = ((num7 - num2 < num6 - num7) ? (num7 - num2) : (num6 - num7));
					method_13(num2, num6 - num10, num10);
					int num14 = ((num3 - num9 >= num9 - num8) ? (num9 - num8) : (num3 - num9));
					method_13(num6, num3 - num14 + 1, num14);
					num10 = num2 + num6 - num7 - 1;
					num14 = num3 - (num9 - num8) + 1;
					array[num].int_0 = num2;
					array[num].int_1 = num10;
					array[num].int_2 = num4;
					num++;
					array[num].int_0 = num10 + 1;
					array[num].int_1 = num14 - 1;
					array[num].int_2 = num4 + 1;
					num++;
					array[num].int_0 = num14;
					array[num].int_1 = num3;
					array[num].int_2 = num4;
					num++;
				}
				else
				{
					array[num].int_0 = num2;
					array[num].int_1 = num3;
					array[num].int_2 = num4 + 1;
					num++;
				}
			}
			else
			{
				method_12(num2, num3, num4);
				if (int_12 > int_13 && bool_2)
				{
					break;
				}
			}
		}
	}

	private void method_15()
	{
		int[] array = new int[256];
		int[] array2 = new int[256];
		bool[] array3 = new bool[256];
		for (int i = 0; i < 20; i++)
		{
			byte_0[int_1 + i + 2] = byte_0[i % (int_1 + 1) + 1];
		}
		for (int i = 0; i <= int_1 + 20; i++)
		{
			int_7[i] = 0;
		}
		byte_0[0] = byte_0[int_1 + 1];
		if (int_1 < 4000)
		{
			for (int i = 0; i <= int_1; i++)
			{
				int_8[i] = i;
			}
			bool_2 = false;
			int_13 = 0;
			int_12 = 0;
			method_12(0, int_1, 0);
			return;
		}
		int num = 0;
		for (int i = 0; i <= 255; i++)
		{
			array3[i] = false;
		}
		for (int i = 0; i <= 65536; i++)
		{
			int_9[i] = 0;
		}
		int num2 = byte_0[0];
		for (int i = 0; i <= int_1; i++)
		{
			int num3 = byte_0[i + 1];
			int_9[(num2 << 8) + num3]++;
			num2 = num3;
		}
		for (int i = 1; i <= 65536; i++)
		{
			int_9[i] += int_9[i - 1];
		}
		num2 = byte_0[1];
		int num4;
		for (int i = 0; i < int_1; i++)
		{
			int num3 = byte_0[i + 2];
			num4 = (num2 << 8) + num3;
			num2 = num3;
			int_9[num4]--;
			int_8[int_9[num4]] = i;
		}
		num4 = (byte_0[int_1 + 1] << 8) + byte_0[1];
		int_9[num4]--;
		int_8[int_9[num4]] = int_1;
		for (int i = 0; i <= 255; i++)
		{
			array[i] = i;
		}
		int num5 = 1;
		int num6 = 3;
		while (true)
		{
			num5 = num6 * num5 + 1;
			if (num5 <= 256)
			{
				num6 = 3;
				continue;
			}
			break;
		}
		do
		{
			num5 /= 3;
			for (int i = num5; i <= 255; i++)
			{
				int num7 = array[i];
				num4 = i;
				while (int_9[array[num4 - num5] + 1 << 8] - int_9[array[num4 - num5] << 8] > int_9[num7 + 1 << 8] - int_9[num7 << 8])
				{
					array[num4] = array[num4 - num5];
					num4 -= num5;
					if (num4 <= num5 - 1)
					{
						break;
					}
				}
				array[num4] = num7;
			}
		}
		while (num5 != 1);
		for (int i = 0; i <= 255; i++)
		{
			int num8 = array[i];
			for (num4 = 0; num4 <= 255; num4++)
			{
				int num9 = (num8 << 8) + num4;
				if ((int_9[num9] & 0x200000) == 2097152)
				{
					continue;
				}
				int num10 = int_9[num9] & -2097153;
				int num11 = (int_9[num9 + 1] & -2097153) - 1;
				if (num11 > num10)
				{
					method_14(num10, num11, 2);
					num += num11 - num10 + 1;
					if (int_12 > int_13 && bool_2)
					{
						return;
					}
				}
				int_9[num9] |= 2097152;
			}
			array3[num8] = true;
			int num12;
			if (i >= 255)
			{
				num12 = 0;
			}
			else
			{
				int num13 = int_9[num8 << 8] & -2097153;
				int num14 = (int_9[num8 + 1 << 8] & -2097153) - num13;
				int j;
				for (j = 0; num14 >> j > 65534; j++)
				{
				}
				for (num4 = 0; num4 < num14; num4++)
				{
					int num15 = int_8[num13 + num4];
					int num16 = num4 >> j;
					int_7[num15] = num16;
					if (num15 < 20)
					{
						int_7[num15 + int_1 + 1] = num16;
					}
				}
				if (num14 - 1 >> j <= 65535)
				{
					num12 = 0;
				}
				else
				{
					smethod_0();
					num12 = 0;
				}
			}
			for (num4 = num12; num4 <= 255; num4++)
			{
				array2[num4] = int_9[(num4 << 8) + num8] & -2097153;
			}
			for (num4 = int_9[num8 << 8] & -2097153; num4 < (int_9[num8 + 1 << 8] & -2097153); num4++)
			{
				num2 = byte_0[int_8[num4]];
				if (!array3[num2])
				{
					int_8[array2[num2]] = ((int_8[num4] == 0) ? int_1 : (int_8[num4] - 1));
					array2[num2]++;
				}
			}
			for (num4 = 0; num4 <= 255; num4++)
			{
				int_9[(num4 << 8) + num8] |= 2097152;
			}
		}
	}

	private void method_16()
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < 256; i++)
		{
			bool_1[i] = false;
		}
		for (int i = 0; i <= int_1; i++)
		{
			if (num == 0)
			{
				num = ICSharpCode.SharpZipLib.BZip2.BZip2Constants.RandomNumbers[num2];
				num2++;
				if (num2 == 512)
				{
					num2 = 0;
				}
			}
			num--;
			byte_0[i + 1] ^= ((num == 1) ? ((byte)1) : ((byte)0));
			byte_0[i + 1] &= byte.MaxValue;
			bool_1[byte_0[i + 1]] = true;
		}
	}

	private void method_17()
	{
		int_13 = int_11 * int_1;
		int_12 = 0;
		bool_0 = false;
		bool_2 = true;
		method_15();
		if (int_12 > int_13 && bool_2)
		{
			method_16();
			int_12 = 0;
			int_13 = 0;
			bool_0 = true;
			bool_2 = false;
			method_15();
		}
		int_2 = -1;
		for (int i = 0; i <= int_1; i++)
		{
			if (int_8[i] == 0)
			{
				int_2 = i;
				break;
			}
		}
		if (int_2 == -1)
		{
			smethod_0();
		}
	}

	private bool method_18(int int_17, int int_18)
	{
		byte b = byte_0[int_17 + 1];
		byte b2 = byte_0[int_18 + 1];
		if (b != b2)
		{
			return b > b2;
		}
		int_17++;
		int_18++;
		b = byte_0[int_17 + 1];
		b2 = byte_0[int_18 + 1];
		if (b != b2)
		{
			return b > b2;
		}
		int_17++;
		int_18++;
		b = byte_0[int_17 + 1];
		b2 = byte_0[int_18 + 1];
		if (b != b2)
		{
			return b > b2;
		}
		int_17++;
		int_18++;
		b = byte_0[int_17 + 1];
		b2 = byte_0[int_18 + 1];
		if (b != b2)
		{
			return b > b2;
		}
		int_17++;
		int_18++;
		b = byte_0[int_17 + 1];
		b2 = byte_0[int_18 + 1];
		if (b != b2)
		{
			return b > b2;
		}
		int_17++;
		int_18++;
		b = byte_0[int_17 + 1];
		b2 = byte_0[int_18 + 1];
		if (b != b2)
		{
			return b > b2;
		}
		int_17++;
		int_18++;
		int num = int_1 + 1;
		do
		{
			b = byte_0[int_17 + 1];
			b2 = byte_0[int_18 + 1];
			if (b == b2)
			{
				int num2 = int_7[int_17];
				int num3 = int_7[int_18];
				if (num2 == num3)
				{
					int_17++;
					int_18++;
					b = byte_0[int_17 + 1];
					b2 = byte_0[int_18 + 1];
					if (b == b2)
					{
						num2 = int_7[int_17];
						num3 = int_7[int_18];
						if (num2 == num3)
						{
							int_17++;
							int_18++;
							b = byte_0[int_17 + 1];
							b2 = byte_0[int_18 + 1];
							if (b == b2)
							{
								num2 = int_7[int_17];
								num3 = int_7[int_18];
								if (num2 == num3)
								{
									int_17++;
									int_18++;
									b = byte_0[int_17 + 1];
									b2 = byte_0[int_18 + 1];
									if (b == b2)
									{
										num2 = int_7[int_17];
										num3 = int_7[int_18];
										if (num2 == num3)
										{
											int_17++;
											int_18++;
											if (int_17 > int_1)
											{
												int_17 -= int_1;
												int_17--;
											}
											if (int_18 > int_1)
											{
												int_18 -= int_1;
												int_18--;
											}
											num -= 4;
											int_12++;
											continue;
										}
										return num2 > num3;
									}
									return b > b2;
								}
								return num2 > num3;
							}
							return b > b2;
						}
						return num2 > num3;
					}
					return b > b2;
				}
				return num2 > num3;
			}
			return b > b2;
		}
		while (num >= 0);
		return false;
	}

	private void method_19()
	{
		int num = 100000 * int_3;
		byte_0 = new byte[num + 1 + 20];
		int_7 = new int[num + 20];
		int_8 = new int[num];
		int_9 = new int[65537];
		if (byte_0 == null || int_7 == null || int_8 == null)
		{
		}
		short_0 = new short[2 * num];
	}

	private void method_20()
	{
		char[] array = new char[256];
		DcDyfzUfaDX();
		int num = int_6 + 1;
		for (int i = 0; i <= num; i++)
		{
			int_10[i] = 0;
		}
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < int_6; i++)
		{
			array[i] = (char)i;
		}
		for (int i = 0; i <= int_1; i++)
		{
			char c = char_1[byte_0[int_8[i]]];
			int num4 = 0;
			char c2 = array[0];
			while (c != c2)
			{
				num4++;
				char c3 = c2;
				c2 = array[num4];
				array[num4] = c3;
			}
			array[0] = c2;
			if (num4 != 0)
			{
				if (num3 > 0)
				{
					num3--;
					while (true)
					{
						int num5 = num3 % 2;
						if (num5 != 0)
						{
							if (num5 == 1)
							{
								short_0[num2] = 1;
								num2++;
								int_10[1]++;
							}
						}
						else
						{
							short_0[num2] = 0;
							num2++;
							int_10[0]++;
						}
						if (num3 < 2)
						{
							break;
						}
						num3 = (num3 - 2) / 2;
					}
					num3 = 0;
				}
				short_0[num2] = (short)(num4 + 1);
				num2++;
				int_10[num4 + 1]++;
			}
			else
			{
				num3++;
			}
		}
		if (num3 > 0)
		{
			num3--;
			while (true)
			{
				int num5 = num3 % 2;
				if (num5 == 0)
				{
					short_0[num2] = 0;
					num2++;
					int_10[0]++;
				}
				else if (num5 == 1)
				{
					short_0[num2] = 1;
					num2++;
					int_10[1]++;
				}
				if (num3 < 2)
				{
					break;
				}
				num3 = (num3 - 2) / 2;
			}
		}
		short_0[num2] = (short)num;
		num2++;
		int_10[num]++;
		JkYybuSudIJ = num2;
	}

	private static void smethod_0()
	{
		throw new BZip2Exception("BZip2 output stream panic");
	}

	private static void smethod_1(object object_0, object object_1, int int_17, int int_18)
	{
		int[] array = new int[260];
		int[] array2 = new int[516];
		int[] array3 = new int[516];
		for (int i = 0; i < int_17; i++)
		{
			array2[i + 1] = ((((int[])object_1)[i] == 0) ? 1 : ((int[])object_1)[i]) << 8;
		}
		while (true)
		{
			int num = int_17;
			int num2 = 0;
			array[0] = 0;
			array2[0] = 0;
			array3[0] = -2;
			for (int j = 1; j <= int_17; j++)
			{
				array3[j] = -1;
				num2++;
				array[num2] = j;
				int num3 = num2;
				int num4 = array[num3];
				while (array2[num4] < array2[array[num3 >> 1]])
				{
					array[num3] = array[num3 >> 1];
					num3 >>= 1;
				}
				array[num3] = num4;
			}
			if (num2 >= 260)
			{
				smethod_0();
			}
			while (num2 > 1)
			{
				int num5 = array[1];
				array[1] = array[num2];
				num2--;
				int num6 = 1;
				int num7 = 0;
				int num8 = array[1];
				while (true)
				{
					num7 = num6 << 1;
					if (num7 > num2)
					{
						break;
					}
					if (num7 < num2 && array2[array[num7 + 1]] < array2[array[num7]])
					{
						num7++;
					}
					if (array2[num8] < array2[array[num7]])
					{
						break;
					}
					array[num6] = array[num7];
					num6 = num7;
				}
				array[num6] = num8;
				int num9 = array[1];
				array[1] = array[num2];
				num2--;
				num6 = 1;
				num7 = 0;
				num8 = array[1];
				while (true)
				{
					num7 = num6 << 1;
					if (num7 > num2)
					{
						break;
					}
					if (num7 < num2 && array2[array[num7 + 1]] < array2[array[num7]])
					{
						num7++;
					}
					if (array2[num8] < array2[array[num7]])
					{
						break;
					}
					array[num6] = array[num7];
					num6 = num7;
				}
				array[num6] = num8;
				num++;
				array3[num5] = (array3[num9] = num);
				array2[num] = (int)((array2[num5] & 0xFFFFFF00L) + (array2[num9] & 0xFFFFFF00L)) | (1 + (((array2[num5] & 0xFF) > (array2[num9] & 0xFF)) ? (array2[num5] & 0xFF) : (array2[num9] & 0xFF)));
				array3[num] = -1;
				num2++;
				array[num2] = num;
				num6 = num2;
				num8 = array[num6];
				while (array2[num8] < array2[array[num6 >> 1]])
				{
					array[num6] = array[num6 >> 1];
					num6 >>= 1;
				}
				array[num6] = num8;
			}
			int num10;
			if (num < 516)
			{
				num10 = 0;
			}
			else
			{
				smethod_0();
				num10 = 0;
			}
			bool flag = (byte)num10 != 0;
			for (int k = 1; k <= int_17; k++)
			{
				int num11 = 0;
				int num12 = k;
				while (array3[num12] >= 0)
				{
					num12 = array3[num12];
					num11++;
				}
				((short[])object_0)[k - 1] = (short)(ushort)num11;
				flag = flag || num11 > int_18;
			}
			if (flag)
			{
				for (int l = 1; l < int_17; l++)
				{
					int num11 = array2[l] >> 8;
					num11 = 1 + num11 / 2;
					array2[l] = num11 << 8;
				}
				continue;
			}
			break;
		}
	}

	private static void smethod_2(object object_0, object object_1, int int_17, int int_18, int int_19)
	{
		int num = 0;
		for (int i = int_17; i <= int_18; i++)
		{
			for (int j = 0; j < int_19; j++)
			{
				if (((ushort[])object_1)[j] == i)
				{
					((int[])object_0)[j] = num;
					num++;
				}
			}
			num <<= 1;
		}
	}

	private static byte smethod_3(byte byte_1, byte byte_2, byte byte_3)
	{
		if (byte_1 > byte_2)
		{
			byte num = byte_1;
			byte_1 = byte_2;
			byte_2 = num;
		}
		if (byte_2 > byte_3)
		{
			byte num2 = byte_2;
			byte_2 = byte_3;
			byte_3 = num2;
		}
		if (byte_1 > byte_2)
		{
			byte_2 = byte_1;
		}
		return byte_2;
	}

	static BZip2OutputStream()
	{
		Class72.smethod_20();
	}
}
