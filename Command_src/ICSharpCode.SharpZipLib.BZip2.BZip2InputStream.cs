using System;
using System.IO;
using System.Runtime.CompilerServices;
using ICSharpCode.SharpZipLib.Checksum;

namespace ICSharpCode.SharpZipLib.BZip2;

public class BZip2InputStream : Stream
{
	private int int_0;

	private int int_1;

	private int int_2;

	private bool bool_0;

	private int int_3;

	private int int_4;

	private IChecksum ichecksum_0 = new BZip2Crc();

	private bool[] bool_1 = new bool[256];

	private int int_5;

	private byte[] byte_0 = new byte[256];

	private byte[] byte_1 = new byte[256];

	private byte[] byte_2 = new byte[18002];

	private byte[] byte_3 = new byte[18002];

	private int[] int_6;

	private byte[] byte_4;

	private int[] int_7 = new int[256];

	private int[][] int_8 = new int[6][];

	private int[][] thsyfrYscvt = new int[6][];

	private int[][] int_9 = new int[6][];

	private int[] int_10 = new int[6];

	private readonly Stream stream_0;

	private bool bool_2;

	private int int_11 = -1;

	private int upXyfneHocA = 1;

	private int int_12;

	private int int_13;

	private int int_14;

	private uint UegyfOqBnbh;

	private int int_15;

	private int int_16;

	private int int_17;

	private int int_18;

	private int int_19;

	private int int_20;

	private int int_21;

	private int int_22;

	private byte byte_5;

	[CompilerGenerated]
	private bool bool_3 = true;

	public bool IsStreamOwner
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public override bool CanRead => stream_0.CanRead;

	public override bool CanSeek => false;

	public override bool CanWrite => false;

	public override long Length => stream_0.Length;

	public override long Position
	{
		get
		{
			return stream_0.Position;
		}
		set
		{
			throw new NotSupportedException("BZip2InputStream position cannot be set");
		}
	}

	public BZip2InputStream(Stream stream)
	{
		if (stream != null)
		{
			for (int i = 0; i < 6; i++)
			{
				int_8[i] = new int[258];
				thsyfrYscvt[i] = new int[258];
				int_9[i] = new int[258];
			}
			stream_0 = stream;
			int_4 = 0;
			int_3 = 0;
			method_1();
			vonyftgpvcx();
			method_11();
			return;
		}
		throw new ArgumentNullException("stream");
	}

	public override void Flush()
	{
		stream_0.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException("BZip2InputStream Seek not supported");
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException("BZip2InputStream SetLength not supported");
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException("BZip2InputStream Write not supported");
	}

	public override void WriteByte(byte value)
	{
		throw new NotSupportedException("BZip2InputStream WriteByte not supported");
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (buffer != null)
		{
			for (int i = 0; i < count; i++)
			{
				int num = ReadByte();
				if (num != -1)
				{
					buffer[offset + i] = (byte)num;
					continue;
				}
				return i;
			}
			return count;
		}
		throw new ArgumentNullException("buffer");
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && IsStreamOwner)
		{
			stream_0.Dispose();
		}
	}

	public override int ReadByte()
	{
		if (bool_2)
		{
			return -1;
		}
		int result = int_11;
		switch (upXyfneHocA)
		{
		case 3:
			method_13();
			break;
		case 4:
			method_14();
			break;
		case 6:
			method_15();
			break;
		case 7:
			method_16();
			break;
		}
		return result;
	}

	private void method_0()
	{
		int_5 = 0;
		for (int i = 0; i < 256; i++)
		{
			if (bool_1[i])
			{
				byte_0[int_5] = (byte)i;
				byte_1[i] = (byte)int_5;
				int_5++;
			}
		}
	}

	private void method_1()
	{
		char num = method_6();
		char c = method_6();
		char c2 = method_6();
		char c3 = method_6();
		if (num == 'B' && c == 'Z' && c2 == 'h' && c3 >= '1' && c3 <= '9')
		{
			method_17(c3 - 48);
			UegyfOqBnbh = 0u;
		}
		else
		{
			bool_2 = true;
		}
	}

	private void vonyftgpvcx()
	{
		char c = method_6();
		char c2 = method_6();
		char c3 = method_6();
		char c4 = method_6();
		char c5 = method_6();
		char c6 = method_6();
		if (c == '\u0017' && c2 == 'r' && c3 == 'E' && c4 == '8' && c5 == 'P' && c6 == '\u0090')
		{
			method_3();
		}
		else if (c == '1' && c2 == 'A' && c3 == 'Y' && c4 == '&' && c5 == 'S' && c6 == 'Y')
		{
			int_12 = method_8();
			bool_0 = method_5(1) == 1;
			method_10();
			ichecksum_0.Reset();
			upXyfneHocA = 1;
		}
		else
		{
			smethod_2();
			bool_2 = true;
		}
	}

	private void method_2()
	{
		int_14 = (int)ichecksum_0.Value;
		if (int_12 != int_14)
		{
			smethod_3();
		}
		UegyfOqBnbh = ((UegyfOqBnbh << 1) & 0xFFFFFFFFu) | (UegyfOqBnbh >> 31);
		UegyfOqBnbh ^= (uint)int_14;
	}

	private void method_3()
	{
		int_13 = method_8();
		if (int_13 != (int)UegyfOqBnbh)
		{
			smethod_3();
		}
		bool_2 = true;
	}

	private void method_4()
	{
		int num = 0;
		try
		{
			num = stream_0.ReadByte();
		}
		catch (Exception)
		{
			smethod_0();
		}
		if (num == -1)
		{
			smethod_0();
		}
		int_3 = (int_3 << 8) | (num & 0xFF);
		int_4 += 8;
	}

	private int method_5(int int_23)
	{
		while (int_4 < int_23)
		{
			method_4();
		}
		int result = (int_3 >> int_4 - int_23) & ((1 << int_23) - 1);
		int_4 -= int_23;
		return result;
	}

	private char method_6()
	{
		return (char)method_5(8);
	}

	private int method_7(int int_23)
	{
		return method_5(int_23);
	}

	private int method_8()
	{
		return (((((method_5(8) << 8) | method_5(8)) << 8) | method_5(8)) << 8) | method_5(8);
	}

	private void method_9()
	{
		char[][] array = new char[6][];
		for (int i = 0; i < 6; i++)
		{
			array[i] = new char[258];
		}
		bool[] array2 = new bool[16];
		for (int j = 0; j < 16; j++)
		{
			array2[j] = method_5(1) == 1;
		}
		for (int k = 0; k < 16; k++)
		{
			if (array2[k])
			{
				for (int l = 0; l < 16; l++)
				{
					bool_1[k * 16 + l] = method_5(1) == 1;
				}
			}
			else
			{
				for (int m = 0; m < 16; m++)
				{
					bool_1[k * 16 + m] = false;
				}
			}
		}
		method_0();
		int num = int_5 + 2;
		int num2 = method_5(3);
		int num3 = method_5(15);
		for (int n = 0; n < num3; n++)
		{
			int num4 = 0;
			while (method_5(1) == 1)
			{
				num4++;
			}
			byte_3[n] = (byte)num4;
		}
		byte[] array3 = new byte[6];
		for (int num5 = 0; num5 < num2; num5++)
		{
			array3[num5] = (byte)num5;
		}
		for (int num6 = 0; num6 < num3; num6++)
		{
			int num7 = byte_3[num6];
			byte b = array3[num7];
			while (num7 > 0)
			{
				array3[num7] = array3[num7 - 1];
				num7--;
			}
			array3[0] = b;
			byte_2[num6] = b;
		}
		for (int num8 = 0; num8 < num2; num8++)
		{
			int num9 = method_5(5);
			for (int num10 = 0; num10 < num; num10++)
			{
				while (method_5(1) == 1)
				{
					num9 = ((method_5(1) != 0) ? (num9 - 1) : (num9 + 1));
				}
				array[num8][num10] = (char)num9;
			}
		}
		for (int num11 = 0; num11 < num2; num11++)
		{
			int num12 = 32;
			int num13 = 0;
			for (int num14 = 0; num14 < num; num14++)
			{
				num13 = Math.Max(num13, array[num11][num14]);
				num12 = Math.Min(num12, array[num11][num14]);
			}
			smethod_4(int_8[num11], thsyfrYscvt[num11], int_9[num11], array[num11], num12, num13, num);
			int_10[num11] = num12;
		}
	}

	private void method_10()
	{
		byte[] array = new byte[256];
		int num = 100000 * int_2;
		int_1 = method_7(24);
		method_9();
		int num2 = int_5 + 1;
		int num3 = -1;
		int num4 = 0;
		for (int i = 0; i <= 255; i++)
		{
			int_7[i] = 0;
		}
		for (int j = 0; j <= 255; j++)
		{
			array[j] = (byte)j;
		}
		int_0 = -1;
		if (num4 == 0)
		{
			num3++;
			num4 = 50;
		}
		num4--;
		int num5 = byte_2[num3];
		int num6 = int_10[num5];
		int num7 = method_5(num6);
		while (num7 > int_8[num5][num6])
		{
			if (num6 <= 20)
			{
				num6++;
				while (int_4 < 1)
				{
					method_4();
				}
				int num8 = (int_3 >> int_4 - 1) & 1;
				int_4--;
				num7 = (num7 << 1) | num8;
				continue;
			}
			throw new BZip2Exception("Bzip data error");
		}
		if (num7 - thsyfrYscvt[num5][num6] >= 0 && num7 - thsyfrYscvt[num5][num6] < 258)
		{
			int num9 = int_9[num5][num7 - thsyfrYscvt[num5][num6]];
			while (num9 != num2)
			{
				int num10;
				switch (num9)
				{
				case 1:
					num10 = -1;
					break;
				default:
				{
					int_0++;
					if (int_0 >= num)
					{
						smethod_1();
					}
					byte b = array[num9 - 1];
					int_7[byte_0[b]]++;
					byte_4[int_0] = byte_0[b];
					int num11 = num9 - 1;
					while (num11 > 0)
					{
						array[num11] = array[--num11];
					}
					array[0] = b;
					if (num4 == 0)
					{
						num3++;
						num4 = 50;
					}
					num4--;
					num5 = byte_2[num3];
					num6 = int_10[num5];
					num7 = method_5(num6);
					while (num7 > int_8[num5][num6])
					{
						num6++;
						while (int_4 < 1)
						{
							method_4();
						}
						int num8 = (int_3 >> int_4 - 1) & 1;
						int_4--;
						num7 = (num7 << 1) | num8;
					}
					num9 = int_9[num5][num7 - thsyfrYscvt[num5][num6]];
					continue;
				}
				case 0:
					num10 = -1;
					break;
				}
				int num12 = num10;
				int num13 = 1;
				do
				{
					if (num9 == 0)
					{
						num12 += num13;
					}
					else if (num9 == 1)
					{
						num12 += 2 * num13;
					}
					num13 <<= 1;
					if (num4 == 0)
					{
						num3++;
						num4 = 50;
					}
					num4--;
					num5 = byte_2[num3];
					num6 = int_10[num5];
					num7 = method_5(num6);
					while (num7 > int_8[num5][num6])
					{
						num6++;
						while (int_4 < 1)
						{
							method_4();
						}
						int num8 = (int_3 >> int_4 - 1) & 1;
						int_4--;
						num7 = (num7 << 1) | num8;
					}
					num9 = int_9[num5][num7 - thsyfrYscvt[num5][num6]];
				}
				while (num9 == 0 || num9 == 1);
				num12++;
				byte b2 = byte_0[array[0]];
				int_7[b2] += num12;
				while (num12 > 0)
				{
					int_0++;
					byte_4[int_0] = b2;
					num12--;
				}
				if (int_0 >= num)
				{
					smethod_1();
				}
			}
			return;
		}
		throw new BZip2Exception("Bzip data error");
	}

	private void method_11()
	{
		int[] array = new int[257];
		array[0] = 0;
		Array.Copy(int_7, 0, array, 1, 256);
		for (int i = 1; i <= 256; i++)
		{
			array[i] += array[i - 1];
		}
		for (int j = 0; j <= int_0; j++)
		{
			byte b = byte_4[j];
			int_6[array[b]] = j;
			array[b]++;
		}
		array = null;
		int_18 = int_6[int_1];
		int_15 = 0;
		int_21 = 0;
		int_17 = 256;
		if (!bool_0)
		{
			VlcyfPjsQo9();
			return;
		}
		int_19 = 0;
		int_20 = 0;
		method_12();
	}

	private void method_12()
	{
		if (int_21 <= int_0)
		{
			int_16 = int_17;
			int_17 = byte_4[int_18];
			int_18 = int_6[int_18];
			if (int_19 == 0)
			{
				int_19 = ICSharpCode.SharpZipLib.BZip2.BZip2Constants.RandomNumbers[int_20];
				int_20++;
				if (int_20 == 512)
				{
					int_20 = 0;
				}
			}
			int_19--;
			int_17 ^= ((int_19 == 1) ? 1 : 0);
			int_21++;
			int_11 = int_17;
			upXyfneHocA = 3;
			ichecksum_0.Update(int_17);
		}
		else
		{
			method_2();
			vonyftgpvcx();
			method_11();
		}
	}

	private void VlcyfPjsQo9()
	{
		if (int_21 > int_0)
		{
			method_2();
			vonyftgpvcx();
			method_11();
			return;
		}
		int_16 = int_17;
		int_17 = byte_4[int_18];
		int_18 = int_6[int_18];
		int_21++;
		int_11 = int_17;
		upXyfneHocA = 6;
		ichecksum_0.Update(int_17);
	}

	private void method_13()
	{
		if (int_17 != int_16)
		{
			upXyfneHocA = 2;
			int_15 = 1;
			method_12();
			return;
		}
		int_15++;
		if (int_15 < 4)
		{
			upXyfneHocA = 2;
			method_12();
			return;
		}
		byte_5 = byte_4[int_18];
		int_18 = int_6[int_18];
		if (int_19 == 0)
		{
			int_19 = ICSharpCode.SharpZipLib.BZip2.BZip2Constants.RandomNumbers[int_20];
			int_20++;
			if (int_20 == 512)
			{
				int_20 = 0;
			}
		}
		int_19--;
		byte_5 ^= ((int_19 == 1) ? ((byte)1) : ((byte)0));
		int_22 = 0;
		upXyfneHocA = 4;
		method_14();
	}

	private void method_14()
	{
		if (int_22 < byte_5)
		{
			int_11 = int_17;
			ichecksum_0.Update(int_17);
			int_22++;
		}
		else
		{
			upXyfneHocA = 2;
			int_21++;
			int_15 = 0;
			method_12();
		}
	}

	private void method_15()
	{
		if (int_17 != int_16)
		{
			upXyfneHocA = 5;
			int_15 = 1;
			VlcyfPjsQo9();
			return;
		}
		int_15++;
		if (int_15 >= 4)
		{
			byte_5 = byte_4[int_18];
			int_18 = int_6[int_18];
			upXyfneHocA = 7;
			int_22 = 0;
			method_16();
		}
		else
		{
			upXyfneHocA = 5;
			VlcyfPjsQo9();
		}
	}

	private void method_16()
	{
		if (int_22 >= byte_5)
		{
			upXyfneHocA = 5;
			int_21++;
			int_15 = 0;
			VlcyfPjsQo9();
		}
		else
		{
			int_11 = int_17;
			ichecksum_0.Update(int_17);
			int_22++;
		}
	}

	private void method_17(int int_23)
	{
		if (0 <= int_23 && int_23 <= 9 && 0 <= int_2 && int_2 <= 9)
		{
			int_2 = int_23;
			if (int_23 != 0)
			{
				int num = 100000 * int_23;
				byte_4 = new byte[num];
				int_6 = new int[num];
			}
			return;
		}
		throw new BZip2Exception("Invalid block size");
	}

	private static void smethod_0()
	{
		throw new EndOfStreamException("BZip2 input stream end of compressed stream");
	}

	private static void smethod_1()
	{
		throw new BZip2Exception("BZip2 input stream block overrun");
	}

	private static void smethod_2()
	{
		throw new BZip2Exception("BZip2 input stream bad block header");
	}

	private static void smethod_3()
	{
		throw new BZip2Exception("BZip2 input stream crc error");
	}

	private static void smethod_4(object object_0, object object_1, object object_2, object object_3, int int_23, int int_24, int int_25)
	{
		int num = 0;
		for (int i = int_23; i <= int_24; i++)
		{
			for (int j = 0; j < int_25; j++)
			{
				if (((ushort[])object_3)[j] == i)
				{
					((int[])object_2)[num] = j;
					num++;
				}
			}
		}
		for (int k = 0; k < 23; k++)
		{
			((int[])object_1)[k] = 0;
		}
		for (int l = 0; l < int_25; l++)
		{
			((int[])object_1)[((ushort[])object_3)[l] + 1]++;
		}
		for (int m = 1; m < 23; m++)
		{
			((int[])object_1)[m] += ((int[])object_1)[m - 1];
		}
		for (int n = 0; n < 23; n++)
		{
			((int[])object_0)[n] = 0;
		}
		int num2 = 0;
		for (int num3 = int_23; num3 <= int_24; num3++)
		{
			num2 += ((int[])object_1)[num3 + 1] - ((int[])object_1)[num3];
			((int[])object_0)[num3] = num2 - 1;
			num2 <<= 1;
		}
		for (int num4 = int_23 + 1; num4 <= int_24; num4++)
		{
			((int[])object_1)[num4] = (((int[])object_0)[num4 - 1] + 1 << 1) - ((int[])object_1)[num4];
		}
	}

	static BZip2InputStream()
	{
		Class72.smethod_20();
	}
}
