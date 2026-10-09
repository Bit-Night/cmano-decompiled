using System;
using System.Globalization;
using System.Linq;

namespace CSMaterial;

public static class FastDoubleParse
{
	private static readonly char char_0;

	private static readonly char char_1;

	private static readonly char char_2;

	private static readonly string string_0;

	private static readonly string string_1;

	private static readonly string string_2;

	private static readonly string string_3;

	private static readonly double[] double_0;

	private static readonly double[] double_1;

	public static bool FastTryParseDouble(string input, out double result)
	{
		int length = input.Length;
		if (length <= 0)
		{
			result = double.NaN;
			return false;
		}
		double num = 1.0;
		int num2 = 0;
		char c = input[0];
		if (c < '0' || c > '9')
		{
			if (length == 1)
			{
				return CheckForSpecialCaseDoubleStrings(input, out result);
			}
			if (c == char_0)
			{
				num = -1.0;
			}
			else
			{
				if (c == char_2)
				{
					result = 0.0;
					goto IL_00e8;
				}
				if (c != char_1)
				{
					return CheckForSpecialCaseDoubleStrings(input, out result);
				}
			}
			c = input[++num2];
			if (c < '0' || c > '9')
			{
				if (c != char_2)
				{
					return CheckForSpecialCaseDoubleStrings(input, out result);
				}
				result = 0.0;
				goto IL_00e8;
			}
		}
		result = c - 48;
		while (++num2 < length)
		{
			c = input[num2];
			if (c < '0' || c > '9')
			{
				break;
			}
			result = result * 10.0 + (double)(c - 48);
		}
		goto IL_00e8;
		IL_01e1:
		int num3 = c - 48;
		int result2;
		bool flag;
		while (true)
		{
			if (++num2 < length)
			{
				c = input[num2];
				if (c >= '0')
				{
					if (c <= '9')
					{
						num3 = num3 * 10 + c - 48;
						continue;
					}
					result2 = 0;
					break;
				}
				result2 = 0;
				break;
			}
			if (!flag)
			{
				if (num3 > 308)
				{
					return false;
				}
				result *= double_0[num3];
			}
			else
			{
				result *= ((num3 < 309) ? double_0[num3 + 308] : Math.Pow(10.0, -num3));
			}
			return !double.IsInfinity(result);
		}
		return (byte)result2 != 0;
		IL_00e8:
		if (c == char_2)
		{
			int num4 = ++num2;
			do
			{
				c = input[num2];
				if (c > '9' || c < '0')
				{
					break;
				}
				result = result * 10.0 + (double)(c - 48);
			}
			while (++num2 < length);
			num4 = num2 - num4;
			result *= ((num4 < 16) ? double_1[num4] : ((num4 < 308) ? double_0[308 + num4] : Math.Pow(10.0, -num4)));
		}
		result *= num;
		if (num2 >= length)
		{
			return true;
		}
		if (c != 'e' && c != 'E')
		{
			return false;
		}
		if (++num2 >= length)
		{
			return false;
		}
		c = input[num2];
		flag = false;
		if (c < '0' || c > '9')
		{
			if (c == char_0)
			{
				flag = true;
			}
			else if (c != char_1)
			{
				return false;
			}
			if (++num2 >= length)
			{
				return false;
			}
			c = input[num2];
			int result3;
			if (c >= '0')
			{
				if (c <= '9')
				{
					goto IL_01e1;
				}
				result3 = 0;
			}
			else
			{
				result3 = 0;
			}
			return (byte)result3 != 0;
		}
		goto IL_01e1;
	}

	public static bool CheckForSpecialCaseDoubleStrings(string input, out double result)
	{
		int result2;
		if (!(input == string_0))
		{
			if (!(input == string_1))
			{
				if (input == string_2)
				{
					result = double.NaN;
					result2 = 1;
				}
				else if (input == string_3)
				{
					result = 0.0;
					result2 = 1;
				}
				else
				{
					if (!input.Equals("unlimited", StringComparison.OrdinalIgnoreCase))
					{
						result = double.NaN;
						return false;
					}
					result = double.MaxValue;
					result2 = 1;
				}
			}
			else
			{
				result = double.NegativeInfinity;
				result2 = 1;
			}
		}
		else
		{
			result = double.PositiveInfinity;
			result2 = 1;
		}
		return (byte)result2 != 0;
	}

	static FastDoubleParse()
	{
		Class72.smethod_20();
		char_0 = CultureInfo.InvariantCulture.NumberFormat.NegativeSign[0];
		char_1 = CultureInfo.InvariantCulture.NumberFormat.PositiveSign[0];
		char_2 = CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator[0];
		string_0 = CultureInfo.InvariantCulture.NumberFormat.PositiveInfinitySymbol[0].ToString();
		string_1 = CultureInfo.InvariantCulture.NumberFormat.NegativeInfinitySymbol[0].ToString();
		string_2 = CultureInfo.InvariantCulture.NumberFormat.NaNSymbol[0].ToString();
		string_3 = CultureInfo.InvariantCulture.NumberFormat.NegativeSign[0].ToString();
		double_0 = (from i in Enumerable.Range(0, 309)
			select Math.Pow(10.0, i)).Concat(from i in Enumerable.Range(1, 308)
			select Math.Pow(10.0, -i)).ToArray();
		double_1 = (from i in Enumerable.Range(0, 16)
			select Math.Pow(10.0, -i)).ToArray();
	}
}
