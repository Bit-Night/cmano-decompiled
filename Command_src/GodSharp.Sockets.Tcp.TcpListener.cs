using System;
using System.Net;
using System.Net.Sockets;
using GodSharp.Sockets.Abstractions;

namespace GodSharp.Sockets.Tcp;

internal sealed class TcpListener : NetListener<ITcpConnection>, INetListener<ITcpConnection>, IDisposable, ITcpListener
{
	public TcpListener(ITcpConnection connection)
		: base(connection)
	{
	}

	protected override void OnBeginReceive(ref byte[] buffers)
	{
		Connection.Instance.BeginReceive(buffers, 0, buffers.Length, SocketFlags.None, ReceivedCallback, null);
	}

	protected override T OnEndReceive<T>(IAsyncResult result)
	{
		SocketError errorCode;
		return new ReceiveResult(Connection.Instance.EndReceive(result, out errorCode), Connection.RemoteEndPoint) as T;
	}

	protected override void OnReceiveHandling(byte[] buffers, IPEndPoint remote = null, IPEndPoint local = null)
	{
		Connection.OnReceived?.Invoke(new NetClientReceivedEventArgs<ITcpConnection>(Connection, buffers, remote, local));
	}

	protected override void OnStop(Exception exception)
	{
		Connection.OnDisconnected?.Invoke(new NetClientEventArgs<ITcpConnection>(Connection)
		{
			Exception = exception
		});
	}

	protected override void OnException(Exception exception)
	{
		Connection.OnException?.Invoke(new NetClientEventArgs<ITcpConnection>(Connection)
		{
			Exception = exception
		});
	}

	public override void Dispose()
	{
		Connection = null;
	}

	static TcpListener()
	{
		Class72.smethod_20();
	}
}
