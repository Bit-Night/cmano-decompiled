using System;

namespace Microsoft.Collections.Extensions;

internal static class HashHelpers
{
	internal static readonly int[] SizeOneIntArray;

	public const int HashCollisionThreshold = 100;

	public const int MaxPrimeArrayLength = 2146435069;

	public const int HashPrime = 101;

	public static readonly int[] primes;

	internal static int PowerOf2(int v)
	{
		if ((v & (v - 1)) == 0)
		{
			return v;
		}
		int num;
		for (num = 2; num < v; num <<= 1)
		{
		}
		return num;
	}

	public static bool IsPrime(int candidate)
	{
		if ((candidate & 1) != 0)
		{
			int num = (int)Math.Sqrt(candidate);
			int num2 = 3;
			while (true)
			{
				if (num2 <= num)
				{
					if (candidate % num2 == 0)
					{
						break;
					}
					num2 += 2;
					continue;
				}
				return true;
			}
			return false;
		}
		return candidate == 2;
	}

	public static int GetPrime(int min)
	{
		if (min < 0)
		{
			throw new ArgumentException("Hashtable's capacity overflowed and went negative. Check load factor, capacity and the current size of the table.");
		}
		int num = 0;
		int num2;
		while (true)
		{
			if (num < primes.Length)
			{
				num2 = primes[num];
				if (num2 >= min)
				{
					break;
				}
				num++;
				continue;
			}
			int num3 = min | 1;
			while (true)
			{
				if (num3 < int.MaxValue)
				{
					if (IsPrime(num3) && (num3 - 1) % 101 != 0)
					{
						break;
					}
					num3 += 2;
					continue;
				}
				return min;
			}
			return num3;
		}
		return num2;
	}

	public static int ExpandPrime(int oldSize)
	{
		int num = 2 * oldSize;
		if ((uint)num > 2146435069u && 2146435069 > oldSize)
		{
			return 2146435069;
		}
		return GetPrime(num);
	}

	static HashHelpers()
	{
		Class72.smethod_20();
		SizeOneIntArray = new int[1];
		primes = new int[72]
		{
			3, 7, 11, 17, 23, 29, 37, 47, 59, 71,
			89, 107, 131, 163, 197, 239, 293, 353, 431, 521,
			631, 761, 919, 1103, 1327, 1597, 1931, 2333, 2801, 3371,
			4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591, 17519, 21023,
			25229, 30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363,
			156437, 187751, 225307, 270371, 324449, 389357, 467237, 560689, 672827, 807403,
			968897, 1162687, 1395263, 1674319, 2009191, 2411033, 2893249, 3471899, 4166287, 4999559,
			5999471, 7199369
		};
	}
}
