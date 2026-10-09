using System;
using System.Threading;

public static class UtcProvider
{
	public static DateTimeOffset UtcNow;

	private static readonly Thread thread_0;

	private static bool bool_0;

	public static void Start()
	{
		if (!thread_0.IsAlive)
		{
			thread_0.IsBackground = true;
			thread_0.Start();
		}
	}

	public static void StopUpdater()
	{
		bool_0 = false;
	}

	private static void smethod_0()
	{
		while (bool_0)
		{
			UtcNow = DateTimeOffset.UtcNow;
			Thread.Sleep(1000);
		}
	}

	static UtcProvider()
	{
		Class72.smethod_20();
		UtcNow = DateTimeOffset.UtcNow;
		thread_0 = new Thread(smethod_0);
		bool_0 = true;
	}
}
