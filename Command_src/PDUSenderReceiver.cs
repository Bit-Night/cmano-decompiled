using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using OpenDis.Core;
using OpenDis.Dis1998;

public class PDUSenderReceiver
{
	public static bool DebugMode;

	private static IPAddress ipaddress_0;

	private static int int_0;

	private static int int_1;

	private static Socket socket_0;

	private static Socket socket_1;

	private static MulticastOption multicastOption_0;

	private static IPEndPoint ipendPoint_0;

	private static EndPoint endPoint_0;

	public static string SentException;

	public static long BytesSent;

	public static int BytesRecv;

	public static string GetMulticastSocketDetails()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (socket_0 != null)
		{
			stringBuilder.AppendLine($"AddressFamily: {socket_0.AddressFamily}");
			stringBuilder.AppendLine($"Available data to read: {socket_0.Available}");
			stringBuilder.AppendLine($"Is Blocking: {socket_0.Blocking}");
			stringBuilder.AppendLine($"Is Connected: {socket_0.Connected}");
			stringBuilder.AppendLine($"Is Fragmentation allowed: {socket_0.DontFragment}");
			stringBuilder.AppendLine($"Is Broadcast enabled: {socket_0.EnableBroadcast}");
			stringBuilder.AppendLine($"Is ExclusiveAddressUse: {socket_0.ExclusiveAddressUse}");
			stringBuilder.AppendLine($"Handle: {socket_0.Handle}");
			stringBuilder.AppendLine($"Is Bound: {socket_0.IsBound}");
			stringBuilder.AppendLine($"LocalEndPoint: {socket_0.LocalEndPoint}");
			stringBuilder.AppendLine($"Is MulticastLoopback: {socket_0.MulticastLoopback}");
			stringBuilder.AppendLine($"ProtocolType: {socket_0.ProtocolType}");
			stringBuilder.AppendLine($"ReceiveBufferSize: {socket_0.ReceiveBufferSize}");
			stringBuilder.AppendLine($"ReceiveTimeout: {socket_0.ReceiveTimeout}");
			stringBuilder.AppendLine($"SendBufferSize: {socket_0.SendBufferSize}");
			stringBuilder.AppendLine($"SendTimeout: {socket_0.SendTimeout}");
			stringBuilder.AppendLine($"SocketType: {socket_0.SocketType}");
		}
		else
		{
			stringBuilder.AppendLine("Socket is null.");
		}
		return stringBuilder.ToString();
	}

	public static string GetSendSocketDetails()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (socket_1 != null)
		{
			stringBuilder.AppendLine($"AddressFamily: {socket_1.AddressFamily}");
			stringBuilder.AppendLine($"Available data to read: {socket_1.Available}");
			stringBuilder.AppendLine($"Is Blocking: {socket_1.Blocking}");
			stringBuilder.AppendLine($"Is Connected: {socket_1.Connected}");
			stringBuilder.AppendLine($"Is Fragmentation allowed: {socket_1.DontFragment}");
			stringBuilder.AppendLine($"Is Broadcast enabled: {socket_1.EnableBroadcast}");
			stringBuilder.AppendLine($"Is ExclusiveAddressUse: {socket_1.ExclusiveAddressUse}");
			stringBuilder.AppendLine($"Handle: {socket_1.Handle}");
			stringBuilder.AppendLine($"Is Bound: {socket_1.IsBound}");
			stringBuilder.AppendLine($"LocalEndPoint: {socket_1.LocalEndPoint}");
			stringBuilder.AppendLine($"Is MulticastLoopback: {socket_1.MulticastLoopback}");
			stringBuilder.AppendLine($"ProtocolType: {socket_1.ProtocolType}");
			stringBuilder.AppendLine($"ReceiveBufferSize: {socket_1.ReceiveBufferSize}");
			stringBuilder.AppendLine($"ReceiveTimeout: {socket_1.ReceiveTimeout}");
			stringBuilder.AppendLine($"SendBufferSize: {socket_1.SendBufferSize}");
			stringBuilder.AppendLine($"SendTimeout: {socket_1.SendTimeout}");
			stringBuilder.AppendLine($"SocketType: {socket_1.SocketType}");
		}
		else
		{
			stringBuilder.AppendLine("Socket is null.");
		}
		return stringBuilder.ToString();
	}

	private static void smethod_0()
	{
		Console.WriteLine("Current multicast group is: " + multicastOption_0.Group);
		Console.WriteLine("Current multicast local address is: " + multicastOption_0.LocalAddress);
	}

	public static void StartBroadcast_ForSend(IPAddress theIPAddress, int thePort, IPAddress Settings_SubnetMask)
	{
		try
		{
			ipaddress_0 = GetBroadcastAddress(theIPAddress, Settings_SubnetMask);
			int_0 = thePort;
			int_1 = thePort;
			socket_1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			socket_1.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
			ipendPoint_0 = new IPEndPoint(ipaddress_0, int_1);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}

	public static IPAddress GetBroadcastAddress(IPAddress ipAddress, IPAddress subnetMask)
	{
		byte[] addressBytes = ipAddress.GetAddressBytes();
		byte[] addressBytes2 = subnetMask.GetAddressBytes();
		if (addressBytes.Length != addressBytes2.Length)
		{
			throw new ArgumentException("IP address and subnet mask must be of the same type (IPv4 or IPv6).");
		}
		byte[] array = new byte[addressBytes.Length];
		for (int i = 0; i < addressBytes.Length; i++)
		{
			array[i] = (byte)(addressBytes[i] | ~addressBytes2[i]);
		}
		return new IPAddress(array);
	}

	public static void StartBroadcast_ForReceive(IPAddress theIPAddress, int thePort)
	{
		try
		{
			socket_1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			socket_1.ExclusiveAddressUse = false;
			socket_1.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
			socket_0 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			int_0 = thePort;
			int_1 = thePort;
			endPoint_0 = new IPEndPoint(theIPAddress, int_1);
			socket_0.ExclusiveAddressUse = false;
			socket_0.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, optionValue: true);
			socket_0.Bind(endPoint_0);
			Console.WriteLine("Receive Broadcat UDP on Port: " + int_1);
			Console.WriteLine("----------------------------");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
			Console.Write("Error ---->   HIT ENTER TO EXIT");
		}
	}

	public static void StopBroadcast()
	{
		if (socket_0 != null)
		{
			socket_0.Close();
		}
		if (socket_1 != null)
		{
			socket_1.Close();
		}
	}

	private static void smethod_1(byte[] byte_0)
	{
		Interlocked.Add(ref BytesSent, byte_0.Length);
		try
		{
			socket_1.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, optionValue: true);
			socket_1.SendTo(byte_0, ipendPoint_0);
		}
		catch (Exception ex)
		{
			SentException = ex.ToString();
		}
	}

	public static void SendSinglePDU(Pdu thePDU)
	{
		thePDU.Timestamp = DisTime.DisRelativeTimestamp;
		DataOutputStream dataOutputStream = new DataOutputStream(Endian.Big);
		thePDU.MarshalAutoLengthSet(dataOutputStream);
		smethod_1(dataOutputStream.ConvertToBytes(thePDU));
	}

	public static void ReceiveBroadcastMessages(Queue<object> theQueue, EventWaitHandle QueueEventWaitHandle)
	{
		bool flag = false;
		byte[] buffer = new byte[10000];
		int num = 0;
		PduProcessor pduProcessor = new PduProcessor();
		pduProcessor.Endian = Endian.Big;
		while (!flag)
		{
			try
			{
				num = socket_0.ReceiveFrom(buffer, ref endPoint_0);
				Interlocked.Add(ref BytesRecv, num);
				foreach (object item in pduProcessor.ProcessPdu(buffer, Endian.Big))
				{
					theQueue.Enqueue(item);
				}
				QueueEventWaitHandle.Set();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}

	static PDUSenderReceiver()
	{
		Class72.smethod_20();
		DebugMode = false;
		SentException = "";
		BytesSent = 0L;
		BytesRecv = 0;
	}
}
