using System;
using System.Runtime.CompilerServices;
using System.Threading;

public class ThreadLocalRandom : Random
{
	private static readonly ThreadLocal<Random> threadLocal_0;

	private static Random smethod_0()
	{
		return RandomUtils.NewRandom();
	}

	[SpecialName]
	private static Random smethod_1()
	{
		return threadLocal_0.Value;
	}

	internal ThreadLocalRandom()
	{
	}

	public override int Next()
	{
		return smethod_1().Next();
	}

	public override int Next(int maxValue)
	{
		return smethod_1().Next(maxValue);
	}

	public override int Next(int minValue, int maxValue)
	{
		return smethod_1().Next(minValue, maxValue);
	}

	public override void NextBytes(byte[] buffer)
	{
		smethod_1().NextBytes(buffer);
	}

	public override double NextDouble()
	{
		return smethod_1().NextDouble();
	}

	protected override double Sample()
	{
		throw new NotImplementedException();
	}

	static ThreadLocalRandom()
	{
		Class72.smethod_20();
		threadLocal_0 = new ThreadLocal<Random>(smethod_0);
	}
}
