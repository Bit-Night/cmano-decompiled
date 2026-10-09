using System.Net;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets.Abstractions;

public abstract class NetOptions<T> where T : INetConnection
{
	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private IPEndPoint ipendPoint_0;

	[CompilerGenerated]
	private SocketEventHandler<NetClientReceivedEventArgs<T>> socketEventHandler_0;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<T>> socketEventHandler_1;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<T>> socketEventHandler_2;

	internal static object object_0;

	public int Id
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public virtual string Key
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public IPEndPoint LocalEndPoint
	{
		[CompilerGenerated]
		get
		{
			return ipendPoint_0;
		}
		[CompilerGenerated]
		set
		{
			ipendPoint_0 = value;
		}
	}

	public SocketEventHandler<NetClientReceivedEventArgs<T>> OnReceived
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_0;
		}
		[CompilerGenerated]
		set
		{
			socketEventHandler_0 = value;
		}
	}

	public SocketEventHandler<NetClientEventArgs<T>> OnDisconnected
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_1;
		}
		[CompilerGenerated]
		set
		{
			socketEventHandler_1 = value;
		}
	}

	public SocketEventHandler<NetClientEventArgs<T>> OnException
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_2;
		}
		[CompilerGenerated]
		set
		{
			socketEventHandler_2 = value;
		}
	}

	static NetOptions()
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
