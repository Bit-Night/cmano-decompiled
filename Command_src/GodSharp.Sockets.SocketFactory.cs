using System.Net;
using System.Net.Sockets;

namespace GodSharp.Sockets;

public class SocketFactory : ISocketFactory
{
	public ITcpClient CreateTcpClient(TcpClientOptions options)
	{
		return new TcpClient(options);
	}

	public ITcpClient CreateTcpClient(string remoteHost, int remotePort, int localPort = 0, string localHost = null, int connectTimeout = 3000, string name = null, int id = 0)
	{
		return new TcpClient(remoteHost, remotePort, localPort, localHost, connectTimeout, name, id);
	}

	public ITcpServer CreateTcpServer(TcpServerOptions options)
	{
		return new TcpServer(options);
	}

	public ITcpServer CreateTcpServer(int port = 7788, string host = null, int backlog = int.MaxValue, AddressFamily family = AddressFamily.InterNetwork, string name = null, int id = 0)
	{
		return new TcpServer(port, host, backlog, family, name, id);
	}

	public IUdpClient CreateUdpClient(UdpClientOptions options)
	{
		return new UdpClient(options);
	}

	public IUdpClient CreateUdpClient(IPEndPoint remote, IPEndPoint local, AddressFamily family = AddressFamily.InterNetwork, string name = null, int id = 0)
	{
		return new UdpClient(remote, local, family, name, id);
	}

	public IUdpClient CreateUdpClient(string remoteHost, int remotePort, int localPort = 0, string localHost = null, AddressFamily family = AddressFamily.InterNetwork, string name = null, int id = 0)
	{
		return new UdpClient(remoteHost, remotePort, localPort, localHost, family, name, id);
	}

	static SocketFactory()
	{
		Class72.smethod_20();
	}
}
