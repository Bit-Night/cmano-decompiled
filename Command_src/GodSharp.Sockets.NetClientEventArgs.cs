using System.Net;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets;

public class NetClientEventArgs<T> : NetEventArgs where T : INetConnection
{
	[CompilerGenerated]
	private IPEndPoint ipendPoint_0;

	[CompilerGenerated]
	private IPEndPoint ipendPoint_1;

	[CompilerGenerated]
	private T gparam_0;

	internal static object object_0;

	public IPEndPoint LocalEndPoint
	{
		[CompilerGenerated]
		get
		{
			return ipendPoint_0;
		}
		[CompilerGenerated]
		internal set
		{
			ipendPoint_0 = value;
		}
	}

	public IPEndPoint RemoteEndPoint
	{
		[CompilerGenerated]
		get
		{
			return ipendPoint_1;
		}
		[CompilerGenerated]
		internal set
		{
			ipendPoint_1 = value;
		}
	}

	public T NetConnection
	{
		[CompilerGenerated]
		get
		{
			return gparam_0;
		}
		[CompilerGenerated]
		internal set
		{
			gparam_0 = value;
		}
	}

	public NetClientEventArgs(T connection)
	{
		NetConnection = connection;
		RemoteEndPoint = connection?.RemoteEndPoint;
		LocalEndPoint = connection?.LocalEndPoint;
	}

	public NetClientEventArgs(T connection, IPEndPoint remote = null, IPEndPoint local = null)
		: this(connection)
	{
		if (remote != null)
		{
			RemoteEndPoint = remote;
		}
		if (local != null)
		{
			LocalEndPoint = local;
		}
	}

	static NetClientEventArgs()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_0()
	{
		return object_0 == null;
	}

	internal static object smethod_1()
	{
		return object_0;
	}
}
