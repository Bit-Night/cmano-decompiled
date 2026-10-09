using System;

public class LockRandom : Random
{
	private readonly object object_0 = new object();

	public LockRandom()
	{
	}

	public LockRandom(int seed)
		: base(seed)
	{
	}

	public override int Next()
	{
		lock (object_0)
		{
			return base.Next();
		}
	}

	public override int Next(int maxValue)
	{
		lock (object_0)
		{
			return base.Next(maxValue);
		}
	}

	public override int Next(int minValue, int maxValue)
	{
		lock (object_0)
		{
			return base.Next(minValue, maxValue);
		}
	}

	public override void NextBytes(byte[] buffer)
	{
		lock (object_0)
		{
			base.NextBytes(buffer);
		}
	}

	public override double NextDouble()
	{
		lock (object_0)
		{
			return base.NextDouble();
		}
	}

	protected override double Sample()
	{
		lock (object_0)
		{
			return base.Sample();
		}
	}

	static LockRandom()
	{
		Class72.smethod_20();
	}
}
