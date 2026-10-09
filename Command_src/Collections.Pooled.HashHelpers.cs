using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;

namespace Collections.Pooled;

internal static class HashHelpers
{
	public const int HashCollisionThreshold = 100;

	public const int MaxPrimeArrayLength = 2146435069;

	public const int HashPrime = 101;

	public static readonly int[] primes;

	private static ConditionalWeakTable<object, SerializationInfo> conditionalWeakTable_0;

	public static ConditionalWeakTable<object, SerializationInfo> SerializationInfoTable
	{
		get
		{
			if (conditionalWeakTable_0 == null)
			{
				Interlocked.CompareExchange(ref conditionalWeakTable_0, new ConditionalWeakTable<object, SerializationInfo>(), null);
			}
			return conditionalWeakTable_0;
		}
	}

	public static bool IsPrime(int candidate)
	{
		if ((candidate & 1) == 0)
		{
			return candidate == 2;
		}
		int num = (int)Math.Sqrt(candidate);
		for (int i = 3; i <= num; i += 2)
		{
			if (candidate % i == 0)
			{
				return false;
			}
		}
		return true;
	}

	public static int GetPrime(int min)
	{
		if (min >= 0)
		{
			for (int i = 0; i < primes.Length; i++)
			{
				int num = primes[i];
				if (num >= min)
				{
					return num;
				}
			}
			int num2 = min | 1;
			while (true)
			{
				if (num2 < int.MaxValue)
				{
					if (IsPrime(num2) && (num2 - 1) % 101 != 0)
					{
						break;
					}
					num2 += 2;
					continue;
				}
				return min;
			}
			return num2;
		}
		throw new ArgumentException("Cannot get the next prime from a negative number.");
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
