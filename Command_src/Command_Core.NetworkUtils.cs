using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class NetworkUtils
{
	internal static IPAddress GetSubnetMask(IPAddress address)
	{
		NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
		foreach (NetworkInterface networkInterface in allNetworkInterfaces)
		{
			foreach (UnicastIPAddressInformation unicastAddress in networkInterface.GetIPProperties().UnicastAddresses)
			{
				if (unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork && address.Equals(unicastAddress.Address))
				{
					return unicastAddress.IPv4Mask;
				}
			}
		}
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		throw new ArgumentException($"Can't find subnetmask for IP address '{address}'");
	}

	internal static IPAddress GetBroadcastAddress(IPAddress address, IPAddress subnetMask)
	{
		byte[] addressBytes = address.GetAddressBytes();
		byte[] addressBytes2 = subnetMask.GetAddressBytes();
		if (addressBytes.Length != addressBytes2.Length)
		{
			throw new ArgumentException("Lengths of IP address and subnet mask do not match.");
		}
		byte[] array = new byte[addressBytes.Length - 1 + 1];
		int num = array.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			array[i] = (byte)(addressBytes[i] | (addressBytes2[i] ^ 0xFF));
		}
		return new IPAddress(array);
	}

	internal static bool IsThisPortAvailable(int thePort)
	{
		TcpConnectionInformation[] activeTcpConnections = IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections();
		int num = 0;
		while (true)
		{
			if (num < activeTcpConnections.Length)
			{
				if (activeTcpConnections[num].LocalEndPoint.Port == thePort)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return true;
		}
		return false;
	}

	internal static string GetLocalIPAddress()
	{
		string result = string.Empty;
		try
		{
			using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP))
			{
				socket.Connect("8.8.8.8", 65530);
				result = ((IPEndPoint)socket.LocalEndPoint).Address.ToString();
			}
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
			foreach (IPAddress iPAddress in addressList)
			{
				if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					result = iPAddress.ToString();
					return result;
				}
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface networkInterface in allNetworkInterfaces)
			{
				if (networkInterface.OperationalStatus != OperationalStatus.Up)
				{
					continue;
				}
				foreach (UnicastIPAddressInformation unicastAddress in networkInterface.GetIPProperties().UnicastAddresses)
				{
					if (unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork)
					{
						result = unicastAddress.Address.ToString();
						return result;
					}
				}
			}
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			UnicastIPAddressInformation unicastIPAddressInformation = null;
			NetworkInterface[] allNetworkInterfaces2 = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface networkInterface2 in allNetworkInterfaces2)
			{
				if (networkInterface2.OperationalStatus != OperationalStatus.Up)
				{
					continue;
				}
				IPInterfaceProperties iPProperties = networkInterface2.GetIPProperties();
				if (iPProperties.GatewayAddresses.Count == 0)
				{
					continue;
				}
				foreach (UnicastIPAddressInformation unicastAddress2 in iPProperties.UnicastAddresses)
				{
					if (unicastAddress2.Address.AddressFamily != AddressFamily.InterNetwork || IPAddress.IsLoopback(unicastAddress2.Address))
					{
						continue;
					}
					if (unicastAddress2.IsDnsEligible)
					{
						if (unicastAddress2.PrefixOrigin == PrefixOrigin.Dhcp)
						{
							result = unicastAddress2.Address.ToString();
							return result;
						}
						if (unicastIPAddressInformation == null || !unicastIPAddressInformation.IsDnsEligible)
						{
							unicastIPAddressInformation = unicastAddress2;
						}
					}
					else if (unicastIPAddressInformation == null)
					{
						unicastIPAddressInformation = unicastAddress2;
					}
				}
			}
		}
		catch (Exception projectError4)
		{
			ProjectData.SetProjectError(projectError4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static NetworkUtils()
	{
		Class72.smethod_20();
	}
}
