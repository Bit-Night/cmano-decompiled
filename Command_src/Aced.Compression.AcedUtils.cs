namespace Aced.Compression;

public sealed class AcedUtils
{
	internal static uint ReverseBits(uint n, int bits)
	{
		n = ((n & 0xFFFF) << 16) | (n >> 16);
		n = ((n & 0xFF00FF) << 8) | ((n & 0xFF00FF00u) >> 8);
		n = ((n & 0xF0F0F0F) << 4) | ((n & 0xF0F0F0F0u) >> 4);
		n = ((n & 0x33333333) << 2) | ((n & 0xCCCCCCCCu) >> 2);
		n = ((n & 0x55555555) << 1) | ((n & 0xAAAAAAAAu) >> 1);
		return n >> 32 - bits;
	}

	public unsafe static int Adler32(byte[] bytes, int offset, int length)
	{
		int result;
		if (bytes != null)
		{
			if (length != 0)
			{
				uint num = 1u;
				uint num2 = 0u;
				fixed (byte* ptr = &bytes[offset])
				{
					byte* ptr2 = ptr;
					while (length > 0)
					{
						int num3 = ((length >= 5552) ? 5552 : length);
						length -= num3;
						while (num3 >= 16)
						{
							num += *ptr2;
							num2 += num;
							num += ptr2[1];
							num2 += num;
							num += ptr2[2];
							num2 += num;
							num += ptr2[3];
							num2 += num;
							num += ptr2[4];
							num2 += num;
							num += ptr2[5];
							num2 += num;
							num += ptr2[6];
							num2 += num;
							num += ptr2[7];
							num2 += num;
							num += ptr2[8];
							num2 += num;
							num += ptr2[9];
							num2 += num;
							num += ptr2[10];
							num2 += num;
							num += ptr2[11];
							num2 += num;
							num += ptr2[12];
							num2 += num;
							num += ptr2[13];
							num2 += num;
							num += ptr2[14];
							num2 += num;
							num += ptr2[15];
							num2 += num;
							ptr2 += 16;
							num3 -= 16;
						}
						while (num3 > 0)
						{
							num += *ptr2;
							num2 += num;
							num3--;
							ptr2++;
						}
						num %= 65521;
						num2 %= 65521;
					}
				}
				return (int)(num | (num2 << 16));
			}
			result = 1;
		}
		else
		{
			result = 1;
		}
		return result;
	}

	internal unsafe static void CopyBytes(byte* ps, byte* pd, int length)
	{
		while (length >= 16)
		{
			*pd = *ps;
			pd[1] = ps[1];
			pd[2] = ps[2];
			pd[3] = ps[3];
			pd[4] = ps[4];
			pd[5] = ps[5];
			pd[6] = ps[6];
			pd[7] = ps[7];
			pd[8] = ps[8];
			pd[9] = ps[9];
			pd[10] = ps[10];
			pd[11] = ps[11];
			pd[12] = ps[12];
			pd[13] = ps[13];
			pd[14] = ps[14];
			pd[15] = ps[15];
			length -= 16;
			ps += 16;
			pd += 16;
		}
		while (length >= 4)
		{
			*pd = *ps;
			pd[1] = ps[1];
			pd[2] = ps[2];
			pd[3] = ps[3];
			length -= 4;
			ps += 4;
			pd += 4;
		}
		if (length >= 2)
		{
			if (length == 2)
			{
				*pd = *ps;
				pd[1] = ps[1];
			}
			else
			{
				*pd = *ps;
				pd[1] = ps[1];
				pd[2] = ps[2];
			}
		}
		else if (length == 1)
		{
			*pd = *ps;
		}
	}

	internal unsafe static void Fill(int value, int* p, int length)
	{
		while (length >= 16)
		{
			*p = value;
			p[1] = value;
			p[2] = value;
			p[3] = value;
			p[4] = value;
			p[5] = value;
			p[6] = value;
			p[7] = value;
			p[8] = value;
			p[9] = value;
			p[10] = value;
			p[11] = value;
			p[12] = value;
			p[13] = value;
			p[14] = value;
			p[15] = value;
			length -= 16;
			p += 16;
		}
		while (length >= 4)
		{
			*p = value;
			p[1] = value;
			p[2] = value;
			p[3] = value;
			length -= 4;
			p += 4;
		}
		if (length < 2)
		{
			if (length == 1)
			{
				*p = value;
			}
		}
		else if (length == 2)
		{
			*p = value;
			p[1] = value;
		}
		else
		{
			*p = value;
			p[1] = value;
			p[2] = value;
		}
	}

	private AcedUtils()
	{
	}

	static AcedUtils()
	{
		Class72.smethod_20();
	}
}
