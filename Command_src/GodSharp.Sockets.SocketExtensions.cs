using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace GodSharp.Sockets;

public static class SocketExtensions
{
	public static int Send(this Socket socket, string data, Encoding encoding = null)
	{
		if (encoding == null)
		{
			encoding = Encoding.UTF8;
		}
		return socket.Send(encoding.GetBytes(data));
	}

	public static IAsyncResult BeginSend(this Socket socket, string data, AsyncCallback callback, object state, Encoding encoding = null)
	{
		if (encoding == null)
		{
			encoding = Encoding.UTF8;
		}
		byte[] bytes = encoding.GetBytes(data);
		return socket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, callback, state);
	}

	public static int Send(this Socket socket, string data, SocketFlags socketFlags, Encoding encoding = null)
	{
		if (encoding == null)
		{
			encoding = Encoding.UTF8;
		}
		return socket.Send(encoding.GetBytes(data), socketFlags);
	}

	public static int Send(this Socket socket, string data, SocketFlags socketFlags, out SocketError socketError, Encoding encoding = null)
	{
		if (encoding == null)
		{
			encoding = Encoding.UTF8;
		}
		byte[] bytes = encoding.GetBytes(data);
		return socket.Send(bytes, 0, bytes.Length, socketFlags, out socketError);
	}

	public static int SendTo(this Socket socket, string data, EndPoint endPoint, Encoding encoding = null)
	{
		if (encoding == null)
		{
			encoding = Encoding.UTF8;
		}
		return socket.SendTo(encoding.GetBytes(data), endPoint);
	}

	public static int SendTo(this Socket socket, string data, SocketFlags socketFlags, EndPoint endPoint, Encoding encoding = null)
	{
		if (encoding == null)
		{
			encoding = Encoding.UTF8;
		}
		return socket.SendTo(encoding.GetBytes(data), socketFlags, endPoint);
	}

	public static IAsyncResult BeginSendTo(this Socket socket, byte[] buffers, EndPoint remoteEP, AsyncCallback callback, object state)
	{
		return socket.BeginSendTo(buffers, 0, buffers.Length, SocketFlags.None, remoteEP, callback, state);
	}

	public static IAsyncResult BeginSendTo(this Socket socket, string data, EndPoint remoteEP, AsyncCallback callback, object state, Encoding encoding = null)
	{
		if (encoding == null)
		{
			encoding = Encoding.UTF8;
		}
		byte[] bytes = encoding.GetBytes(data);
		return socket.BeginSendTo(bytes, 0, bytes.Length, SocketFlags.None, remoteEP, callback, state);
	}

	public static void KeepAlive(this Socket socket, int interval = 5000, int span = 1000)
	{
		byte[] array = new byte[Marshal.SizeOf(0u) * 3];
		BitConverter.GetBytes(1u).CopyTo(array, 0);
		BitConverter.GetBytes((uint)interval).CopyTo(array, Marshal.SizeOf(0u));
		BitConverter.GetBytes((uint)span).CopyTo(array, Marshal.SizeOf(0u) * 2);
		socket.IOControl(IOControlCode.KeepAliveValues, array, null);
	}

	static SocketExtensions()
	{
		Class72.smethod_20();
	}
}
