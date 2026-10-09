using System;
using System.Collections.Generic;
using System.Linq;

namespace Easy.Common;

public static class Base36
{
	public static string Encode(long input)
	{
		if (input < 0L)
		{
			throw new Exception("Input cannot be negative.");
		}
		char[] array = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
		Stack<char> stack = new Stack<char>();
		while (input != 0L)
		{
			stack.Push(array[input % 36L]);
			input /= 36L;
		}
		return new string(stack.ToArray());
	}

	public static long Decode(string input)
	{
		if (input == null)
		{
			throw new Exception("Input cannot be null.");
		}
		IEnumerable<char> enumerable = input.ToLower().Reverse();
		long num = 0L;
		int num2 = 0;
		foreach (char item in enumerable)
		{
			num += "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(item) * (long)Math.Pow(36.0, num2);
			num2++;
		}
		return num;
	}

	static Base36()
	{
		Class72.smethod_20();
	}
}
