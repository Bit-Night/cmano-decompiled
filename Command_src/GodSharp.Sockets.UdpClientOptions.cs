using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using GodSharp.Sockets.Abstractions;

namespace GodSharp.Sockets;

public class UdpClientOptions : NetOptions<IUdpConnection>
{
	[CompilerGenerated]
	private AddressFamily addressFamily_0 = AddressFamily.InterNetwork;

	[CompilerGenerated]
	private IPEndPoint ipendPoint_1;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<IUdpConnection>> socketEventHandler_3;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<IUdpConnection>> socketEventHandler_4;

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

	public SocketEventHandler<NetClientEventArgs<IUdpConnection>> OnStarted
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

	public SocketEventHandler<NetClientEventArgs<IUdpConnection>> OnStopped
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

	public UdpClientOptions()
	{
	}

	public UdpClientOptions(IPEndPoint localEndPoint, IPEndPoint remoteEndPoint, AddressFamily? family = null)
	{
		if (localEndPoint != null)
		{
			base.LocalEndPoint = localEndPoint;
		}
		if (remoteEndPoint != null)
		{
			RemoteEndPoint = remoteEndPoint;
		}
		if (family.HasValue)
		{
			Family = family.Value;
		}
	}

	static UdpClientOptions()
	{
		Class72.smethod_20();
	}
}
