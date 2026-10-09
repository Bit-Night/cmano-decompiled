using System;
using System.Text;

namespace QLicense;

internal class BASE36
{
	private static readonly char[] char_0;

	public static long Decode(string input)
	{
		long num = 0L;
		double num2 = 0.0;
		int num3 = input.Length - 1;
		while (num3 >= 0)
		{
			char value = input[num3];
			int num4 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(value);
			if (num4 > -1)
			{
				num += num4 * (long)Math.Pow("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length, num2);
				num2 += 1.0;
				num3--;
				continue;
			}
			return -1L;
		}
		return num;
	}

	public static string Encode(ulong input)
	{
		StringBuilder stringBuilder = new StringBuilder();
		do
		{
			stringBuilder.Append(char_0[input % (ulong)"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length]);
			input /= (ulong)"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length;
		}
		while (input != 0L);
		return xoqynBoahWH(stringBuilder.ToString());
	}

	private static string xoqynBoahWH(string string_0)
	{
		char[] array = string_0.ToCharArray();
		Array.Reverse((Array)array);
		return new string(array);
	}

	static BASE36()
	{
		Class72.smethod_20();
		char_0 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
	}
}
