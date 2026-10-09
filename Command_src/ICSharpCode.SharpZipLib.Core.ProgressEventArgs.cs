using System;

namespace ICSharpCode.SharpZipLib.Core;

public class ProgressEventArgs : EventArgs
{
	private string string_0;

	private long long_0;

	private long long_1;

	private bool bool_0 = true;

	public string Name => string_0;

	public bool ContinueRunning
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public float PercentComplete
	{
		get
		{
			if (long_1 > 0L)
			{
				return (float)long_0 / (float)long_1 * 100f;
			}
			return 0f;
		}
	}

	public long Processed => long_0;

	public long Target => long_1;

	public ProgressEventArgs(string name, long processed, long target)
	{
		string_0 = name;
		long_0 = processed;
		long_1 = target;
	}

	static ProgressEventArgs()
	{
		Class72.smethod_20();
	}
}
