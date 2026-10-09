using System.Net;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets;

public class NetServerEventArgs : NetEventArgs
{
	[CompilerGenerated]
	private IPEndPoint ipendPoint_0;

	[CompilerGenerated]
	private ITcpServer itcpServer_0;

	[CompilerGenerated]
	private ITcpConnection itcpConnection_0;

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

	public ITcpServer TcpServer
	{
		[CompilerGenerated]
		get
		{
			return itcpServer_0;
		}
		[CompilerGenerated]
		internal set
		{
			itcpServer_0 = value;
		}
	}

	public ITcpConnection Connection
	{
		[CompilerGenerated]
		get
		{
			return itcpConnection_0;
		}
		[CompilerGenerated]
		set
		{
			itcpConnection_0 = value;
		}
	}

	public NetServerEventArgs()
	{
	}

	public NetServerEventArgs(ITcpServer tcpServer, IPEndPoint localEndPoint = null, ITcpConnection connection = null)
	{
		if (tcpServer != null)
		{
			TcpServer = tcpServer;
		}
		if (localEndPoint != null)
		{
			LocalEndPoint = localEndPoint;
		}
		if (connection != null)
		{
			Connection = connection;
		}
	}

	static NetServerEventArgs()
	{
		Class72.smethod_20();
	}
}
