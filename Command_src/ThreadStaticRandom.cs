using System;

public class ThreadStaticRandom : Random
{
	[ThreadStatic]
	private static Random random_0;

	internal ThreadStaticRandom()
	{
	}

	private Random method_0()
	{
		Random random = random_0;
		if (random == null)
		{
			random = (random_0 = method_1());
		}
		return random;
	}

	private Random method_1()
	{
		return RandomUtils.NewRandom();
	}

	public override int Next()
	{
		return method_0().Next();
	}

	public override int Next(int maxValue)
	{
		return method_0().Next(maxValue);
	}

	public override int Next(int minValue, int maxValue)
	{
		return method_0().Next(minValue, maxValue);
	}

	public override void NextBytes(byte[] buffer)
	{
		method_0().NextBytes(buffer);
	}

	public override double NextDouble()
	{
		return method_0().NextDouble();
	}

	protected override double Sample()
	{
		throw new NotImplementedException();
	}

	static ThreadStaticRandom()
	{
		Class72.smethod_20();
	}
}
