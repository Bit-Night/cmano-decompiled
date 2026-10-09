using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
internal sealed class CPULoad
{
	public static float CurrentCPULoad;

	public static void StartCPULoadMeasuringThread()
	{
		Thread thread = new Thread(smethod_0);
		thread.Name = "CPU-Load Measuring Thread";
		thread.Priority = ThreadPriority.Lowest;
		thread.Start();
	}

	private static void smethod_0()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		PerformanceCounter val = new PerformanceCounter("Processor", "% Processor Time", "_Total");
		try
		{
			val.NextValue();
			int millisecondsTimeout = 1000;
			while (true)
			{
				Thread.Sleep(millisecondsTimeout);
				CurrentCPULoad = val.NextValue();
				millisecondsTimeout = 1000;
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	static CPULoad()
	{
		Class72.smethod_20();
	}
}
