using System;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Precision;

public class CommonBits
{
	private long long_0;

	private int int_0 = 53;

	private long long_1;

	private bool bool_0 = true;

	public virtual double Common => BitConverter.Int64BitsToDouble(long_0);

	public static long SignExpBits(long num)
	{
		return num >> 52;
	}

	public static int NumCommonMostSigMantissaBits(long num1, long num2)
	{
		int num3 = 0;
		int num4 = 52;
		while (num4 >= 0)
		{
			if (GetBit(num1, num4) == GetBit(num2, num4))
			{
				num3++;
				num4--;
				continue;
			}
			return num3;
		}
		return 52;
	}

	public static long ZeroLowerBits(long bits, int nBits)
	{
		long num = ~((1L << nBits) - 1L);
		return bits & num;
	}

	public static int GetBit(long bits, int i)
	{
		long num = 1L << i;
		return ((ulong)(bits & num) > 0uL) ? 1 : 0;
	}

	public virtual void Add(double num)
	{
		long num2 = BitConverter.DoubleToInt64Bits(num);
		if (bool_0)
		{
			long_0 = num2;
			long_1 = SignExpBits(long_0);
			bool_0 = false;
		}
		else if (SignExpBits(num2) != long_1)
		{
			long_0 = 0L;
		}
		else
		{
			int_0 = NumCommonMostSigMantissaBits(long_0, num2);
			long_0 = ZeroLowerBits(long_0, 64 - (12 + int_0));
		}
	}

	public virtual string ToString(long bits)
	{
		double num = BitConverter.Int64BitsToDouble(bits);
		string text = HexConverter.ConvertAny2Any(bits.ToString(), 10, 2);
		string text2 = "0000000000000000000000000000000000000000000000000000000000000000" + text;
		string text3 = text2.Substring(text2.Length - 64);
		return text3.Substring(0, 1) + "  " + text3.Substring(1, 12) + "(exp) " + text3.Substring(12) + " [ " + num + " ]";
	}

	static CommonBits()
	{
		Class72.smethod_20();
	}
}
