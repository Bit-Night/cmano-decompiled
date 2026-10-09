using System;
using System.Net.Sockets;
using System.Text;

namespace GodSharp.Sockets;

public static class ITcpConnectionExtensions
{
	private static T paiyxQgdbEi<T>(ITcpConnection itcpConnection_0, Func<T> func_0, T gparam_0)
	{
		if (!smethod_0(itcpConnection_0))
		{
			return gparam_0;
		}
		return func_0();
	}

	private static bool smethod_0(ITcpConnection itcpConnection_0)
	{
		if (itcpConnection_0 != null)
		{
			if (itcpConnection_0.Listener == null)
			{
				return false;
			}
			if (!itcpConnection_0.Listener.Running)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static int Send(this ITcpConnection connection, byte[] buffer)
	{
		return paiyxQgdbEi(connection, () => connection.Instance.Send(buffer), -1);
	}

	public static int Send(this ITcpConnection connection, string str, Encoding encoding = null)
	{
		return paiyxQgdbEi(connection, () => SocketExtensions.Send(connection.Instance, str, encoding), -1);
	}

	public static int Send(this ITcpConnection connection, byte[] buffer, int offset, int size, SocketFlags socketFlags = SocketFlags.None)
	{
		return paiyxQgdbEi(connection, () => connection.Instance.Send(buffer, offset, size, socketFlags), -1);
	}

	public static bool SendAsync(this ITcpConnection connection, SocketAsyncEventArgs e)
	{
		return paiyxQgdbEi(connection, () => connection.Instance.SendAsync(e), gparam_0: false);
	}

	public static IAsyncResult BeginSend(this ITcpConnection connection, byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state)
	{
		errorCode = SocketError.Success;
		if (smethod_0(connection))
		{
			return connection.Instance.BeginSend(buffer, offset, size, socketFlags, out errorCode, callback, state);
		}
		return null;
	}

	public static IAsyncResult BeginSend(this ITcpConnection connection, string str, AsyncCallback callback, object state, Encoding encoding = null)
	{
		return paiyxQgdbEi(connection, () => SocketExtensions.BeginSend(connection.Instance, str, callback, state, encoding), null);
	}

	public static int EndSend(this ITcpConnection connection, IAsyncResult asyncResult, out SocketError errorCode)
	{
		errorCode = SocketError.Success;
		if (!smethod_0(connection))
		{
			return -1;
		}
		return connection.Instance.EndSend(asyncResult, out errorCode);
	}

	public static int EndSend(this ITcpConnection connection, IAsyncResult asyncResult)
	{
		return paiyxQgdbEi(connection, () => connection.Instance.EndSend(asyncResult), -1);
	}

	public static int Receive(this ITcpConnection connection, byte[] buffer)
	{
		return paiyxQgdbEi(connection, () => connection.Instance.Receive(buffer), -1);
	}

	public static bool ReceiveAsync(this ITcpConnection connection, SocketAsyncEventArgs e)
	{
		return paiyxQgdbEi(connection, () => connection.Instance.ReceiveAsync(e), gparam_0: false);
	}

	public static IAsyncResult BeginReceive(this ITcpConnection connection, byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state)
	{
		errorCode = SocketError.Success;
		if (smethod_0(connection))
		{
			return connection.Instance.BeginReceive(buffer, offset, size, socketFlags, out errorCode, callback, state);
		}
		return null;
	}

	public static int EndReceive(this ITcpConnection connection, IAsyncResult asyncResult, out SocketError errorCode)
	{
		errorCode = SocketError.Success;
		if (!smethod_0(connection))
		{
			return -1;
		}
		return connection.Instance.EndReceive(asyncResult, out errorCode);
	}

	public static int EndReceive(this ITcpConnection connection, IAsyncResult asyncResult)
	{
		return paiyxQgdbEi(connection, () => connection.Instance.EndReceive(asyncResult), -1);
	}

	static ITcpConnectionExtensions()
	{
		Class72.smethod_20();
	}
}
