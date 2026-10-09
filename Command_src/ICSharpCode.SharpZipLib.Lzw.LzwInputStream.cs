using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace ICSharpCode.SharpZipLib.Lzw;

public class LzwInputStream : Stream
{
	[CompilerGenerated]
	private bool bool_0 = true;

	private Stream stream_0;

	private bool bool_1;

	private readonly byte[] byte_0 = new byte[1];

	private bool iWjyrmfumMe;

	private int[] int_0;

	private byte[] byte_1;

	private readonly int[] int_1 = new int[256];

	private byte[] byte_2;

	private bool bool_2;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private byte byte_3;

	private int int_8;

	private int int_9;

	private readonly byte[] byte_4 = new byte[8192];

	private int int_10;

	private int int_11;

	private int int_12;

	private bool bool_3;

	public bool IsStreamOwner
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public override bool CanRead => stream_0.CanRead;

	public override bool CanSeek => false;

	public override bool CanWrite => false;

	public override long Length => int_12;

	public override long Position
	{
		get
		{
			return stream_0.Position;
		}
		set
		{
			throw new NotSupportedException("InflaterInputStream Position not supported");
		}
	}

	public LzwInputStream(Stream baseInputStream)
	{
		stream_0 = baseInputStream;
	}

	public override int ReadByte()
	{
		if (Read(byte_0, 0, 1) == 1)
		{
			return byte_0[0] & 0xFF;
		}
		return -1;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (!iWjyrmfumMe)
		{
			method_1();
		}
		if (!bool_3)
		{
			int num = offset;
			int[] array = int_0;
			byte[] array2 = byte_1;
			byte[] array3 = byte_2;
			int num2 = int_2;
			int num3 = int_5;
			int num4 = int_4;
			int num5 = int_6;
			int num6 = int_7;
			byte b = byte_3;
			int num7 = int_8;
			int num8 = int_9;
			byte[] array4 = byte_4;
			int num9 = int_10;
			int num10 = array3.Length - num7;
			if (num10 > 0)
			{
				int num11 = ((num10 < count) ? num10 : count);
				Array.Copy(array3, num7, buffer, offset, num11);
				offset += num11;
				count -= num11;
				num7 += num11;
			}
			if (count == 0)
			{
				int_8 = num7;
				return offset - num;
			}
			while (true)
			{
				if (int_11 < 64)
				{
					Fill();
				}
				int num12 = ((int_12 <= 0) ? ((int_11 << 3) - (num2 - 1)) : (int_11 - int_11 % num2 << 3));
				while (true)
				{
					if (num9 < num12)
					{
						if (count != 0)
						{
							if (num8 <= num3)
							{
								int num13 = num9 >> 3;
								int num14 = (((array4[num13] & 0xFF) | ((array4[num13 + 1] & 0xFF) << 8) | ((array4[num13 + 2] & 0xFF) << 16)) >> (num9 & 7)) & num5;
								num9 += num2;
								if (num6 == -1)
								{
									if (num14 < 256)
									{
										b = (byte)(num6 = num14);
										buffer[offset++] = b;
										count--;
										continue;
									}
									throw new LzwException("corrupt input: " + num14 + " > 255");
								}
								if (num14 != 256 || !bool_2)
								{
									int num15 = num14;
									num7 = array3.Length;
									if (num14 >= num8)
									{
										if (num14 > num8)
										{
											throw new LzwException("corrupt input: code=" + num14 + ", freeEnt=" + num8);
										}
										array3[--num7] = b;
										num14 = num6;
									}
									while (num14 >= 256)
									{
										array3[--num7] = array2[num14];
										num14 = array[num14];
									}
									b = array2[num14];
									buffer[offset++] = b;
									count--;
									num10 = array3.Length - num7;
									int num16 = ((num10 < count) ? num10 : count);
									Array.Copy(array3, num7, buffer, offset, num16);
									offset += num16;
									count -= num16;
									num7 += num16;
									if (num8 < num4)
									{
										array[num8] = num6;
										array2[num8] = b;
										num8++;
									}
									num6 = num15;
									if (count != 0)
									{
										continue;
									}
									int_2 = num2;
									int_5 = num3;
									int_6 = num5;
									int_7 = num6;
									byte_3 = b;
									int_8 = num7;
									int_9 = num8;
									int_10 = num9;
									return offset - num;
								}
								Array.Copy(int_1, 0, array, 0, int_1.Length);
								num8 = 256;
								int num17 = num2 << 3;
								num9 = num9 - 1 + num17 - (num9 - 1 + num17) % num17;
								num2 = 9;
								num3 = 511;
								num5 = 511;
								num9 = method_0(num9);
								break;
							}
							int num18 = num2 << 3;
							num9 = num9 - 1 + num18 - (num9 - 1 + num18) % num18;
							num2++;
							num3 = ((num2 == int_3) ? num4 : ((1 << num2) - 1));
							num5 = (1 << num2) - 1;
							num9 = method_0(num9);
							break;
						}
						int_2 = num2;
						int_5 = num3;
						int_4 = num4;
						int_6 = num5;
						int_7 = num6;
						byte_3 = b;
						int_8 = num7;
						int_9 = num8;
						int_10 = num9;
						return offset - num;
					}
					num9 = method_0(num9);
					if (int_12 > 0)
					{
						break;
					}
					int_2 = num2;
					int_5 = num3;
					int_6 = num5;
					int_7 = num6;
					byte_3 = b;
					int_8 = num7;
					int_9 = num8;
					int_10 = num9;
					bool_3 = true;
					return offset - num;
				}
			}
		}
		return 0;
	}

	private int method_0(int int_13)
	{
		int num = int_13 >> 3;
		Array.Copy(byte_4, num, byte_4, 0, int_11 - num);
		int_11 -= num;
		return 0;
	}

	private void Fill()
	{
		int_12 = stream_0.Read(byte_4, int_11, byte_4.Length - 1 - int_11);
		if (int_12 > 0)
		{
			int_11 += int_12;
		}
	}

	private void method_1()
	{
		iWjyrmfumMe = true;
		byte[] array = new byte[3];
		if (stream_0.Read(array, 0, array.Length) >= 0)
		{
			if (array[0] == 31 && array[1] == 157)
			{
				bool_2 = (array[2] & 0x80) > 0;
				int_3 = array[2] & 0x1F;
				if (int_3 <= 16)
				{
					if ((array[2] & 0x60) > 0)
					{
						throw new LzwException("Unsupported bits set in the header.");
					}
					int_4 = 1 << int_3;
					int_2 = 9;
					int_5 = (1 << int_2) - 1;
					int_6 = int_5;
					int_7 = -1;
					byte_3 = 0;
					int_9 = ((!bool_2) ? 256 : 257);
					int_0 = new int[1 << int_3];
					byte_1 = new byte[1 << int_3];
					byte_2 = new byte[1 << int_3];
					int_8 = byte_2.Length;
					for (int num = 255; num >= 0; num--)
					{
						byte_1[num] = (byte)num;
					}
					return;
				}
				throw new LzwException("Stream compressed with " + int_3 + " bits, but decompression can only handle " + 16 + " bits.");
			}
			throw new LzwException($"Wrong LZW header. Magic bytes don't match. 0x{array[0]:x2} 0x{array[1]:x2}");
		}
		throw new LzwException("Failed to read LZW header");
	}

	public override void Flush()
	{
		stream_0.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException("Seek not supported");
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException("InflaterInputStream SetLength not supported");
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException("InflaterInputStream Write not supported");
	}

	public override void WriteByte(byte value)
	{
		throw new NotSupportedException("InflaterInputStream WriteByte not supported");
	}

	protected override void Dispose(bool disposing)
	{
		if (!bool_1)
		{
			bool_1 = true;
			if (IsStreamOwner)
			{
				stream_0.Dispose();
			}
		}
	}

	static LzwInputStream()
	{
		Class72.smethod_20();
	}
}
