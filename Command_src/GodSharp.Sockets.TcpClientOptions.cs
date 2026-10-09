using System.Net;
using System.Runtime.CompilerServices;
using GodSharp.Sockets.Abstractions;
using GodSharp.Sockets.Tcp;

namespace GodSharp.Sockets;

public class TcpClientOptions : NetOptions<ITcpConnection>
{
	[CompilerGenerated]
	private int int_1 = -1;

	[CompilerGenerated]
	private IPEndPoint ipendPoint_1;

	[CompilerGenerated]
	private bool bool_0 = true;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<ITcpConnection>> socketEventHandler_3;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<ITcpConnection>> wxdyxsqecci;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<ITcpConnection>> socketEventHandler_4;

	[CompilerGenerated]
	private SocketEventHandler<TryConnectingEventArgs<ITcpConnection>> socketEventHandler_5;

	[CompilerGenerated]
	private ITryConnectionStrategy hpMyxXkUkGi = new DefaultTryConnectionStrategy();

	public int ConnectTimeout
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

	public IPEndPoint RemoteEndPoint
	{
		[CompilerGenerated]
		get
		{
			return ipendPoint_1;
		}
		[CompilerGenerated]
		set
		{
			ipendPoint_1 = value;
		}
	}

	public bool ReconnectEnable
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
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

	public SocketEventHandler<NetClientEventArgs<ITcpConnection>> OnStarted
	{
		[CompilerGenerated]
		get
		{
			return wxdyxsqecci;
		}
		[CompilerGenerated]
		set
		{
			wxdyxsqecci = value;
		}
	}

	public SocketEventHandler<NetClientEventArgs<ITcpConnection>> OnStopped
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

	public SocketEventHandler<TryConnectingEventArgs<ITcpConnection>> OnTryConnecting
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

	public ITryConnectionStrategy TryConnectionStrategy
	{
		[CompilerGenerated]
		get
		{
			return hpMyxXkUkGi;
		}
		[CompilerGenerated]
		set
		{
			hpMyxXkUkGi = value;
		}
	}

	public TcpClientOptions()
	{
	}

	public TcpClientOptions(IPEndPoint remoteEndPoint, IPEndPoint localEndPoint = null, SocketEventHandler<NetClientReceivedEventArgs<ITcpConnection>> handler = null)
	{
		if (localEndPoint != null)
		{
			base.LocalEndPoint = localEndPoint;
		}
		if (remoteEndPoint != null)
		{
			RemoteEndPoint = remoteEndPoint;
		}
		if (handler != null)
		{
			base.OnReceived = handler;
		}
	}

	static TcpClientOptions()
	{
		Class72.smethod_20();
	}
}
