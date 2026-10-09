using System;
using System.Net;
using System.Net.Sockets;
using GodSharp.Sockets.Abstractions;

namespace GodSharp.Sockets.Udp;

internal sealed class UdpListener : NetListener<IUdpConnection>, INetListener<IUdpConnection>, IDisposable, IUdpListener
{
	public UdpListener(IUdpConnection connection)
		: base(connection)
	{
	}

	protected override void OnBeginReceive(ref byte[] buffers)
	{
		EndPoint remoteEP = EndPointExtensions.As(Connection.ListenEndPoint);
		Connection.Instance.BeginReceiveFrom(buffers, 0, buffers.Length, SocketFlags.None, ref remoteEP, ReceivedCallback, remoteEP);
	}

	protected override T OnEndReceive<T>(IAsyncResult result)
	{
		EndPoint endPoint = result.AsyncState as EndPoint;
		return new ReceiveResult(Connection.Instance.EndReceiveFrom(result, ref endPoint), EndPointExtensions.As(endPoint)) as T;
	}

	protected override void OnReceiveHandling(byte[] buffers, IPEndPoint remote = null, IPEndPoint local = null)
	{
		Connection.OnReceived?.Invoke(new NetClientReceivedEventArgs<IUdpConnection>(Connection, buffers, remote, local));
	}

	protected override void OnStop(Exception exception)
	{
		Connection.OnDisconnected?.Invoke(new NetClientEventArgs<IUdpConnection>(Connection)
		{
			Exception = exception
		});
	}

	protected override void OnException(Exception exception)
	{
		Connection.OnException?.Invoke(new NetClientEventArgs<IUdpConnection>(Connection)
		{
			Exception = exception
		});
	}

	public override void Dispose()
	{
		Connection = null;
	}

	static UdpListener()
	{
		Class72.smethod_20();
	}
}
