using System;

namespace ICSharpCode.SharpZipLib.Core;

public class ScanEventArgs : EventArgs
{
	private string string_0;

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

	public ScanEventArgs(string name)
	{
		string_0 = name;
	}

	static ScanEventArgs()
	{
		Class72.smethod_20();
	}
}
