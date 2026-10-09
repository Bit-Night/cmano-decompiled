using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using GodSharp.Sockets.Abstractions;
using GodSharp.Sockets.Extensions;
using GodSharp.Sockets.Tcp;

namespace GodSharp.Sockets;

public sealed class TcpClient : NetBase<ITcpConnection, NetClientEventArgs<ITcpConnection>>, ITcpClient, INetBase<ITcpConnection>, IDisposable, ITcpClientEvents, IEvent<ITcpConnection, NetClientEventArgs<ITcpConnection>>
{
	private bool bool_1;

	[CompilerGenerated]
	private TcpConnection tcpConnection_0;

	[CompilerGenerated]
	private SocketEventHandler<TryConnectingEventArgs<ITcpConnection>> socketEventHandler_6;

	public override bool Running
	{
		get
		{
			ITcpConnection tcpConnection = Connection;
			if (tcpConnection != null)
			{
				return tcpConnection.Listener?.Running == true;
			}
			return false;
		}
	}

	private TcpConnection connection
	{
		[CompilerGenerated]
		get
		{
			return tcpConnection_0;
		}
		[CompilerGenerated]
		set
		{
			tcpConnection_0 = value;
		}
	}

	public ITcpConnection Connection => connection;

	public override string Key => Connection.Key;

	public override string Name => Connection.Name;

	public override int Id => Connection.Id;

	public SocketEventHandler<TryConnectingEventArgs<ITcpConnection>> OnTryConnecting
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_6;
		}
		[CompilerGenerated]
		set
		{
			socketEventHandler_6 = value;
		}
	}

	public TcpClient(TcpClientOptions options)
	{
		method_0(options);
	}

	public TcpClient(string remoteHost, int remotePort, int localPort = 0, string localHost = null, int connectTimeout = -1, string name = null, int id = 0)
	{
		try
		{
			TcpClientOptions tcpClientOptions = new TcpClientOptions
			{
				Id = id,
				Name = name
			};
			if (connectTimeout > 0)
			{
				tcpClientOptions.ConnectTimeout = connectTimeout;
			}
			tcpClientOptions.TryConnectionStrategy = new DefaultTryConnectionStrategy();
			tcpClientOptions.RemoteEndPoint = new IPEndPoint(IPAddress.Parse(remoteHost), remotePort);
			tcpClientOptions.LocalEndPoint = ((!StringExtensions.IsNullOrWhiteSpace(localHost) || localPort >= 1) ? new IPEndPoint((tcpClientOptions.RemoteEndPoint.AddressFamily == AddressFamily.InterNetworkV6) ? IPAddress.IPv6Any : IPAddress.Any, localPort) : null);
			method_0(tcpClientOptions);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private void method_0(TcpClientOptions tcpClientOptions_0)
	{
		if (tcpClientOptions_0 != null)
		{
			if (tcpClientOptions_0.RemoteEndPoint != null)
			{
				connection = new TcpConnection(tcpClientOptions_0.RemoteEndPoint, tcpClientOptions_0.LocalEndPoint)
				{
					OnConnected = OnConnectedHandler,
					OnReceived = OnReceivedHandler,
					OnDisconnected = OnDisconnectedHandler,
					OnStarted = OnStartedHandler,
					OnStopped = OnStoppedHandler,
					OnException = OnExceptionHandler,
					ConnectTimeout = tcpClientOptions_0.ConnectTimeout,
					OnTryConnecting = OnTryConnectingHandler,
					ReconnectEnable = tcpClientOptions_0.ReconnectEnable,
					TryConnectionStrategy = tcpClientOptions_0.TryConnectionStrategy
				};
				if (tcpClientOptions_0.Id > 0)
				{
					connection.Id = tcpClientOptions_0.Id;
				}
				if (!StringExtensions.IsNullOrWhiteSpace(tcpClientOptions_0.Name))
				{
					connection.Name = tcpClientOptions_0.Name;
				}
				if (tcpClientOptions_0.OnConnected != null)
				{
					OnConnected = tcpClientOptions_0.OnConnected;
				}
				if (tcpClientOptions_0.OnReceived != null)
				{
					base.OnReceived = tcpClientOptions_0.OnReceived;
				}
				if (tcpClientOptions_0.OnDisconnected != null)
				{
					base.OnDisconnected = tcpClientOptions_0.OnDisconnected;
				}
				if (tcpClientOptions_0.OnStarted != null)
				{
					base.OnStarted = tcpClientOptions_0.OnStarted;
				}
				if (tcpClientOptions_0.OnStopped != null)
				{
					base.OnStopped = tcpClientOptions_0.OnStopped;
				}
				if (tcpClientOptions_0.OnException != null)
				{
					base.OnException = tcpClientOptions_0.OnException;
				}
				if (tcpClientOptions_0.OnTryConnecting != null)
				{
					OnTryConnecting = tcpClientOptions_0.OnTryConnecting;
				}
				return;
			}
			throw new ArgumentNullException("RemoteEndPoint");
		}
		throw new ArgumentNullException("options");
	}

	public void ReconnectAvailable(bool v)
	{
		connection.ReconnectEnable = v;
	}

	public void UseTryConnectionStrategy(ITryConnectionStrategy strategy)
	{
		connection.TryConnectionStrategy = strategy;
	}

	public override void Start()
	{
		bool_1 = false;
		Connection?.Start();
	}

	public override void Stop()
	{
		bool_1 = true;
		Connection?.Stop();
	}

	protected override void OnDisconnectedHandler(NetClientEventArgs<ITcpConnection> args)
	{
		base.OnDisconnectedHandler(args);
		ThreadPool.QueueUserWorkItem(delegate
		{
			connection.Reconnect();
		});
	}

	protected void OnTryConnectingHandler(TryConnectingEventArgs<ITcpConnection> args)
	{
		OnTryConnecting?.Invoke(args);
	}

	public override void Dispose()
	{
		Connection?.Dispose();
	}

	[CompilerGenerated]
	private void method_1(object object_1)
	{
		connection.Reconnect();
	}

	static TcpClient()
	{
		Class72.smethod_20();
	}
}
