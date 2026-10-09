using System.Net;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets;

public class TryConnectingEventArgs<T> : NetClientEventArgs<T> where T : INetConnection
{
	[CompilerGenerated]
	private int int_0;

	internal static object object_1;

	public int Counter
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		internal set
		{
			int_0 = value;
		}
	}

	public TryConnectingEventArgs(T connection, int counter)
		: this(connection, counter, (IPEndPoint)null, (IPEndPoint)null)
	{
	}

	public TryConnectingEventArgs(T connection, int counter, IPEndPoint remote = null, IPEndPoint local = null)
		: base(connection, remote, local)
	{
		Counter = counter;
	}

	static TryConnectingEventArgs()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_2()
	{
		return object_1 == null;
	}

	internal static object smethod_3()
	{
		return object_1;
	}
}
