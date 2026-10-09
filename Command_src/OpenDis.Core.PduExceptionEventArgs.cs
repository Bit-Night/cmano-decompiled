using System;
using System.Runtime.CompilerServices;

namespace OpenDis.Core;

public class PduExceptionEventArgs : EventArgs
{
	[CompilerGenerated]
	private Exception exception_0;

	public Exception Exception
	{
		[CompilerGenerated]
		get
		{
			return exception_0;
		}
		[CompilerGenerated]
		set
		{
			exception_0 = value;
		}
	}

	public PduExceptionEventArgs(Exception e)
	{
		Exception = e;
	}

	static PduExceptionEventArgs()
	{
		Class72.smethod_20();
	}
}
