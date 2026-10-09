using System;
using System.Text;

public static class StringBuilderExtensions
{
	[ThreadStatic]
	private static char[] char_0;

	public static void AppendInt(this StringBuilder sb, int value)
	{
		char[] array = char_0 ?? (char_0 = new char[11]);
		int num = array.Length;
		bool flag;
		uint num2 = (uint)((!(flag = value < 0)) ? value : (-value));
		do
		{
			array[--num] = (char)(48 + num2 % 10);
			num2 /= 10;
		}
		while (num2 != 0);
		if (flag)
		{
			array[--num] = '-';
		}
		sb.Append(array, num, array.Length - num);
	}

	static StringBuilderExtensions()
	{
		Class72.smethod_20();
	}
}
