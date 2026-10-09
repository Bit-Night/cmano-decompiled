using System.Net;

namespace GodSharp.Sockets;

public static class EndPointExtensions
{
	public static IPEndPoint As(this EndPoint endPoint)
	{
		return endPoint as IPEndPoint;
	}

	public static EndPoint As(this IPEndPoint endPoint)
	{
		return endPoint;
	}

	static EndPointExtensions()
	{
		Class72.smethod_20();
	}
}
