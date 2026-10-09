using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GodSharp.Sockets;

public static class IUdpConnectionExtensions
{
	private static T smethod_0<T>(IUdpConnection iudpConnection_0, Func<T> func_0, T gparam_0)
	{
		if (!smethod_1(iudpConnection_0))
		{
			return gparam_0;
		}
		return func_0();
	}

	private static bool smethod_1(IUdpConnection iudpConnection_0)
	{
		if (iudpConnection_0 != null)
		{
			if (iudpConnection_0.Listener != null)
			{
				if (iudpConnection_0.Listener.Running)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public static int SendTo(this IUdpConnection connection, byte[] buffer, EndPoint remoteEP)
	{
		return smethod_0(connection, () => connection.Instance.SendTo(buffer, remoteEP), -1);
	}

	public static int SendTo(this IUdpConnection connection, string str, EndPoint remoteEP)
	{
		return smethod_0(connection, () => SocketExtensions.SendTo(connection.Instance, str, remoteEP), -1);
	}

	public static int SendTo(this IUdpConnection connection, byte[] buffer, int offset, int size, SocketFlags socketFlags, EndPoint remoteEP)
	{
		return smethod_0(connection, () => connection.Instance.SendTo(buffer, offset, size, socketFlags, remoteEP), -1);
	}

	public static bool SendToAsync(this IUdpConnection connection, SocketAsyncEventArgs e)
	{
		return smethod_0(connection, () => connection.Instance.SendToAsync(e), gparam_0: false);
	}

	public static IAsyncResult BeginSendTo(this IUdpConnection connection, byte[] buffer, int offset, int size, SocketFlags socketFlags, EndPoint remoteEP, AsyncCallback callback, object state)
	{
		return smethod_0(connection, () => connection.Instance.BeginSendTo(buffer, offset, size, socketFlags, remoteEP, callback, state), null);
	}

	public static IAsyncResult BeginSendTo(this IUdpConnection connection, byte[] buffer, EndPoint remoteEP, AsyncCallback callback, object state)
	{
		return smethod_0(connection, () => SocketExtensions.BeginSendTo(connection.Instance, buffer, remoteEP, callback, state), null);
	}

	public static IAsyncResult BeginSendTo(this IUdpConnection connection, string str, EndPoint remoteEP, AsyncCallback callback, object state, Encoding encoding = null)
	{
		return smethod_0(connection, () => SocketExtensions.BeginSendTo(connection.Instance, str, remoteEP, callback, state, encoding), null);
	}

	public static int EndSendTo(this IUdpConnection connection, IAsyncResult asyncResult)
	{
		return smethod_0(connection, () => connection.Instance.EndSendTo(asyncResult), -1);
	}

	public static int ReceiveFrom(this IUdpConnection connection, byte[] buffer, ref EndPoint remoteEP)
	{
		if (smethod_1(connection))
		{
			return connection.Instance.ReceiveFrom(buffer, ref remoteEP);
		}
		return -1;
	}

	public static bool ReceiveFromAsync(this IUdpConnection connection, SocketAsyncEventArgs e)
	{
		return smethod_0(connection, () => connection.Instance.ReceiveFromAsync(e), gparam_0: false);
	}

	public static IAsyncResult BeginReceiveFrom(this IUdpConnection connection, byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP, AsyncCallback callback, object state)
	{
		if (!smethod_1(connection))
		{
			return null;
		}
		return connection.Instance.BeginReceiveFrom(buffer, offset, size, socketFlags, ref remoteEP, callback, state);
	}

	public static int EndReceiveFrom(this IUdpConnection connection, IAsyncResult asyncResult, ref EndPoint remoteEP)
	{
		if (!smethod_1(connection))
		{
			return -1;
		}
		return connection.Instance.EndReceiveFrom(asyncResult, ref remoteEP);
	}

	static IUdpConnectionExtensions()
	{
		Class72.smethod_20();
	}
}
