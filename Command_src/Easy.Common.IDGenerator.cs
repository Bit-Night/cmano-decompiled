using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Easy.Common;

public sealed class IDGenerator
{
	private static readonly char[] char_0;

	private static long long_0;

	private static readonly ThreadLocal<char[]> threadLocal_0;

	[CompilerGenerated]
	private static readonly IDGenerator idgenerator_0;

	public static IDGenerator Instance
	{
		[CompilerGenerated]
		get
		{
			return idgenerator_0;
		}
	}

	public string Next => smethod_0(Interlocked.Increment(ref long_0));

	static IDGenerator()
	{
		Class72.smethod_20();
		char_0 = new char[6];
		long_0 = DateTime.UtcNow.Ticks;
		threadLocal_0 = new ThreadLocal<char[]>(() => new char[20]
		{
			char_0[0],
			char_0[1],
			char_0[2],
			char_0[3],
			char_0[4],
			char_0[5],
			'-',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0',
			'\0'
		});
		idgenerator_0 = new IDGenerator();
		smethod_1();
	}

	private IDGenerator()
	{
	}

	private static string smethod_0(long long_1)
	{
		char[] value = threadLocal_0.Value;
		value[7] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_1 >> 60) & 0x1F];
		value[8] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_1 >> 55) & 0x1F];
		value[9] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_1 >> 50) & 0x1F];
		value[10] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_1 >> 45) & 0x1F];
		value[11] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_1 >> 40) & 0x1F];
		value[12] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_1 >> 35) & 0x1F];
		value[13] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_1 >> 30) & 0x1F];
		value[14] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_1 >> 25) & 0x1F];
		value[15] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_1 >> 20) & 0x1F];
		value[16] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_1 >> 15) & 0x1F];
		value[17] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_1 >> 10) & 0x1F];
		value[18] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)(long_1 >> 5) & 0x1F];
		value[19] = "0123456789ABCDEFGHIJKLMNOPQRSTUV"[(int)long_1 & 0x1F];
		return new string(value, 0, value.Length);
	}

	private static void smethod_1()
	{
		string text = Base36.Encode(Math.Abs(Environment.MachineName.GetHashCode()));
		int num = char_0.Length - 1;
		int num2 = 0;
		while (num >= 0)
		{
			if (num2 >= text.Length)
			{
				char_0[num] = '0';
			}
			else
			{
				char_0[num] = text[num2];
				num2++;
			}
			num--;
		}
	}
}
