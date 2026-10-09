using System;

namespace ICSharpCode.SharpZipLib.Core;

public class ScanFailureEventArgs : EventArgs
{
	private string string_0;

	private Exception exception_0;

	private bool bool_0;

	public string Name => string_0;

	public Exception Exception => exception_0;

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

	public ScanFailureEventArgs(string name, Exception e)
	{
		string_0 = name;
		exception_0 = e;
		bool_0 = true;
	}

	static ScanFailureEventArgs()
	{
		Class72.smethod_20();
	}
}
