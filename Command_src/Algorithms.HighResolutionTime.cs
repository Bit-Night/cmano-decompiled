using System.Runtime.InteropServices;

namespace Algorithms;

public static class HighResolutionTime
{
	private static long long_0;

	private static long long_1;

	[DllImport("kernel32.dll")]
	private static extern bool QueryPerformanceCounter(out long long_2);

	[DllImport("kernel32.dll")]
	private static extern bool QueryPerformanceFrequency(out long long_2);

	static HighResolutionTime()
	{
		Class72.smethod_20();
		QueryPerformanceFrequency(out long_1);
	}

	public static void Start()
	{
		QueryPerformanceCounter(out long_0);
	}

	public static double GetTime()
	{
		QueryPerformanceCounter(out var long_);
		return (double)(long_ - long_0) / (double)long_1;
	}
}
