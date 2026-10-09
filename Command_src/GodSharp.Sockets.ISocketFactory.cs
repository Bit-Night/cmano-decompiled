using System.Net;
using System.Net.Sockets;

namespace GodSharp.Sockets;

public interface ISocketFactory
{
	ITcpClient CreateTcpClient(TcpClientOptions options);

	ITcpClient CreateTcpClient(string remoteHost, int remotePort, int localPort = 0, string localHost = null, int connectTimeout = 3000, string name = null, int id = 0);

	ITcpServer CreateTcpServer(TcpServerOptions options);

	ITcpServer CreateTcpServer(int port = 7788, string host = null, int backlog = int.MaxValue, AddressFamily family = AddressFamily.InterNetwork, string name = null, int id = 0);

	IUdpClient CreateUdpClient(UdpClientOptions options);

	IUdpClient CreateUdpClient(IPEndPoint remote, IPEndPoint local, AddressFamily family = AddressFamily.InterNetwork, string name = null, int id = 0);

	IUdpClient CreateUdpClient(string remoteHost, int remotePort, int localPort = 0, string localHost = null, AddressFamily family = AddressFamily.InterNetwork, string name = null, int id = 0);
}
