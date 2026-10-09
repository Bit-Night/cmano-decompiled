using System;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Quadtree;

public class DoubleBits
{
	public const int EXPONENT_BIAS = 1023;

	private readonly double double_0;

	private long long_0;

	public virtual double Double => BitConverter.Int64BitsToDouble(long_0);

	public virtual int BiasedExponent => (int)(long_0 >> 52) & 0x7FF;

	public virtual int Exponent => BiasedExponent - 1023;

	public DoubleBits(double x)
	{
		double_0 = x;
		long_0 = BitConverter.DoubleToInt64Bits(x);
	}

	public static double PowerOf2(int exp)
	{
		if (exp > 1023 || exp < -1022)
		{
			throw new ArgumentException("Exponent out of bounds");
		}
		return BitConverter.Int64BitsToDouble((long)(exp + 1023) << 52);
	}

	public static int GetExponent(double d)
	{
		return new DoubleBits(d).Exponent;
	}

	public static double TruncateToPowerOfTwo(double d)
	{
		DoubleBits doubleBits = new DoubleBits(d);
		doubleBits.ZeroLowerBits(52);
		return doubleBits.Double;
	}

	public static string ToBinaryString(double d)
	{
		return new DoubleBits(d).ToString();
	}

	public static double MaximumCommonMantissa(double d1, double d2)
	{
		if (d1 != 0.0 && d2 != 0.0)
		{
			DoubleBits doubleBits = new DoubleBits(d1);
			DoubleBits doubleBits2 = new DoubleBits(d2);
			if (doubleBits.Exponent != doubleBits2.Exponent)
			{
				return 0.0;
			}
			int num = doubleBits.NumCommonMantissaBits(doubleBits2);
			doubleBits.ZeroLowerBits(64 - (12 + num));
			return doubleBits.Double;
		}
		return 0.0;
	}

	public virtual void ZeroLowerBits(int nBits)
	{
		long num = ~((1L << nBits) - 1L);
		long_0 &= num;
	}

	public virtual int GetBit(int i)
	{
		long num = 1L << i;
		return ((ulong)(long_0 & num) > 0uL) ? 1 : 0;
	}

	public virtual int NumCommonMantissaBits(DoubleBits db)
	{
		for (int i = 0; i < 52; i++)
		{
			if (GetBit(i) != db.GetBit(i))
			{
				return i;
			}
		}
		return 52;
	}

	public override string ToString()
	{
		string text = HexConverter.ConvertAny2Any(long_0.ToString(), 10, 2);
		string text2 = "0000000000000000000000000000000000000000000000000000000000000000" + text;
		string text3 = text2.Substring(text2.Length - 64);
		string[] obj = new string[10]
		{
			text3.Substring(0, 1),
			"  ",
			text3.Substring(1, 12),
			"(",
			Exponent.ToString(),
			") ",
			text3.Substring(12),
			" [ ",
			null,
			null
		};
		double num = double_0;
		obj[8] = num.ToString();
		obj[9] = " ]";
		return string.Concat(obj);
	}

	static DoubleBits()
	{
		Class72.smethod_20();
	}
}
