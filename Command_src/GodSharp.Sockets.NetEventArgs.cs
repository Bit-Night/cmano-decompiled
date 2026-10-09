using System;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets;

public abstract class NetEventArgs
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
		internal set
		{
			exception_0 = value;
		}
	}

	static NetEventArgs()
	{
		Class72.smethod_20();
	}
}
