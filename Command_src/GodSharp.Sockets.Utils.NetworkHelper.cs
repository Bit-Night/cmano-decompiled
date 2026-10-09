using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

namespace GodSharp.Sockets.Utils;

public class NetworkHelper
{
	public static bool LocalPortUsed(int port)
	{
		IPGlobalProperties iPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
		if (iPGlobalProperties.GetActiveTcpConnections().FirstOrDefault((TcpConnectionInformation x) => x.LocalEndPoint.Port == port) == null)
		{
			if (iPGlobalProperties.GetActiveTcpListeners().FirstOrDefault((IPEndPoint x) => x.Port == port) != null)
			{
				return true;
			}
			if (iPGlobalProperties.GetActiveUdpListeners().FirstOrDefault((IPEndPoint x) => x.Port == port) != null)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public static TcpConnectionInformation GetTcpConnectionInformation(int local, int remote = 0)
	{
		IPGlobalProperties iPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
		Func<TcpConnectionInformation, bool> func = null;
		if (local > 0 && remote > 0)
		{
			func = (TcpConnectionInformation x) => x.LocalEndPoint.Port == local && x.RemoteEndPoint.Port == remote;
			if (iPGlobalProperties == null)
			{
				goto IL_0080;
			}
		}
		else if (local <= 0)
		{
			if (remote <= 0)
			{
				throw new ArgumentException("local and remote is invalid.");
			}
			func = (TcpConnectionInformation x) => x.RemoteEndPoint.Port == remote;
			if (iPGlobalProperties == null)
			{
				goto IL_0080;
			}
		}
		else
		{
			func = (TcpConnectionInformation x) => x.LocalEndPoint.Port == local;
			if (iPGlobalProperties == null)
			{
				goto IL_0080;
			}
		}
		return iPGlobalProperties.GetActiveTcpConnections()?.FirstOrDefault(func);
		IL_0080:
		return null;
	}

	public static IPAddress[] GetHostAddresses(string hostName = null)
	{
		return Dns.GetHostAddresses(hostName ?? Dns.GetHostName());
	}

	static NetworkHelper()
	{
		Class72.smethod_20();
	}
}
