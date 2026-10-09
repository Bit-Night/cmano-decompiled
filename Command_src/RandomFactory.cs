using System;

public static class RandomFactory
{
	private static readonly Random random_0;

	private static readonly LockRandom lockRandom_0;

	private static readonly ThreadStaticRandom threadStaticRandom_0;

	private static readonly ThreadLocalRandom threadLocalRandom_0;

	public static Random GetRandom()
	{
		return random_0;
	}

	public static LockRandom GetLockRandom()
	{
		return lockRandom_0;
	}

	public static ThreadStaticRandom GetThreadStaticRandom()
	{
		return threadStaticRandom_0;
	}

	public static ThreadLocalRandom GetThreadLocalRandom()
	{
		return threadLocalRandom_0;
	}

	static RandomFactory()
	{
		Class72.smethod_20();
		random_0 = new Random();
		lockRandom_0 = new LockRandom();
		threadStaticRandom_0 = new ThreadStaticRandom();
		threadLocalRandom_0 = new ThreadLocalRandom();
	}
}
