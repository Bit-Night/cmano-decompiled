using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using GodSharp.Sockets.Abstractions;

namespace GodSharp.Sockets;

public class TcpServerOptions : NetOptions<ITcpConnection>
{
	[CompilerGenerated]
	private AddressFamily addressFamily_0 = AddressFamily.InterNetwork;

	[CompilerGenerated]
	private int int_1 = int.MaxValue;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<ITcpConnection>> socketEventHandler_3;

	[CompilerGenerated]
	private SocketEventHandler<NetServerEventArgs> socketEventHandler_4;

	[CompilerGenerated]
	private SocketEventHandler<NetServerEventArgs> socketEventHandler_5;

	[CompilerGenerated]
	private SocketEventHandler<NetServerEventArgs> socketEventHandler_6;

	public AddressFamily Family
	{
		[CompilerGenerated]
		get
		{
			return addressFamily_0;
		}
		[CompilerGenerated]
		set
		{
			addressFamily_0 = value;
		}
	}

	public int Backlog
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public SocketEventHandler<NetClientEventArgs<ITcpConnection>> OnConnected
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_3;
		}
		[CompilerGenerated]
		set
		{
			socketEventHandler_3 = value;
		}
	}

	public SocketEventHandler<NetServerEventArgs> OnStarted
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_4;
		}
		[CompilerGenerated]
		set
		{
			socketEventHandler_4 = value;
		}
	}

	public SocketEventHandler<NetServerEventArgs> OnStopped
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_5;
		}
		[CompilerGenerated]
		set
		{
			socketEventHandler_5 = value;
		}
	}

	public SocketEventHandler<NetServerEventArgs> OnServerException
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_6;
		}
		[CompilerGenerated]
		set
		{
			socketEventHandler_6 = value;
		}
	}

	public TcpServerOptions()
	{
	}

	public TcpServerOptions(IPEndPoint localEndPoint, int backlog = int.MaxValue, AddressFamily? family = null, SocketEventHandler<NetClientReceivedEventArgs<ITcpConnection>> handler = null)
	{
		base.LocalEndPoint = localEndPoint;
		if (backlog > 0)
		{
			Backlog = backlog;
		}
		if (family.HasValue)
		{
			Family = family.Value;
		}
		if (handler != null)
		{
			base.OnReceived = handler;
		}
	}

	static TcpServerOptions()
	{
		Class72.smethod_20();
	}
}
