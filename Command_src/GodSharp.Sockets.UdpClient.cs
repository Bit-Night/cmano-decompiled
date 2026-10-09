using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using GodSharp.Sockets.Abstractions;
using GodSharp.Sockets.Extensions;
using GodSharp.Sockets.Udp;

namespace GodSharp.Sockets;

public sealed class UdpClient : NetBase<IUdpConnection, NetClientEventArgs<IUdpConnection>>, IUdpClient, INetBase<IUdpConnection>, IDisposable, IUdpClientEvents, IEvent<IUdpConnection, NetClientEventArgs<IUdpConnection>>
{
	[CompilerGenerated]
	private UdpConnection udpConnection_0;

	public override bool Running
	{
		get
		{
			IUdpConnection udpConnection = Connection;
			if (udpConnection != null)
			{
				return udpConnection.Listener?.Running == true;
			}
			return false;
		}
	}

	public override string Key => Connection.Key;

	public override string Name => Connection.Name;

	public override int Id => Connection.Id;

	private UdpConnection connection
	{
		[CompilerGenerated]
		get
		{
			return udpConnection_0;
		}
		[CompilerGenerated]
		set
		{
			udpConnection_0 = value;
		}
	}

	public IUdpConnection Connection => connection;

	public UdpClient(UdpClientOptions options)
	{
		method_0(options);
	}

	public UdpClient(IPEndPoint remote, IPEndPoint local, AddressFamily family = AddressFamily.InterNetwork, string name = null, int id = 0)
	{
		method_0(new UdpClientOptions(local, remote, family)
		{
			Id = id,
			Name = name
		});
	}

	public UdpClient(int localPort, string localHost = null, AddressFamily family = AddressFamily.InterNetwork, string name = null, int id = 0)
	{
		method_0(new UdpClientOptions(new IPEndPoint((!StringExtensions.IsNullOrWhiteSpace(localHost)) ? IPAddress.Parse(localHost) : ((family == AddressFamily.InterNetworkV6) ? IPAddress.IPv6Any : IPAddress.Any), localPort), null, family)
		{
			Id = id,
			Name = name
		});
	}

	public UdpClient(string remoteHost, int remotePort, int localPort = 8899, string localHost = null, AddressFamily family = AddressFamily.InterNetwork, string name = null, int id = 0)
	{
		try
		{
			UdpClientOptions udpClientOptions_ = new UdpClientOptions(new IPEndPoint((!StringExtensions.IsNullOrWhiteSpace(localHost)) ? IPAddress.Parse(localHost) : ((family == AddressFamily.InterNetworkV6) ? IPAddress.IPv6Any : IPAddress.Any), localPort), StringExtensions.IsNullOrWhiteSpace(remoteHost) ? null : new IPEndPoint(IPAddress.Parse(remoteHost), remotePort), family)
			{
				Id = id,
				Name = name
			};
			method_0(udpClientOptions_);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private void method_0(UdpClientOptions udpClientOptions_0)
	{
		if (udpClientOptions_0 != null)
		{
			if (udpClientOptions_0.RemoteEndPoint == null && udpClientOptions_0.LocalEndPoint == null)
			{
				throw new ArgumentNullException("RemoteEndPoint");
			}
			connection = new UdpConnection(udpClientOptions_0.RemoteEndPoint, udpClientOptions_0.LocalEndPoint, udpClientOptions_0.Family)
			{
				OnReceived = OnReceivedHandler,
				OnDisconnected = OnDisconnectedHandler,
				OnStarted = OnStartedHandler,
				OnStopped = OnStoppedHandler,
				OnException = OnExceptionHandler
			};
			if (udpClientOptions_0.Id > 0)
			{
				connection.Id = udpClientOptions_0.Id;
			}
			if (!StringExtensions.IsNullOrWhiteSpace(udpClientOptions_0.Name))
			{
				connection.Name = udpClientOptions_0.Name;
			}
			if (udpClientOptions_0.OnReceived != null)
			{
				base.OnReceived = udpClientOptions_0.OnReceived;
			}
			if (udpClientOptions_0.OnDisconnected != null)
			{
				base.OnDisconnected = udpClientOptions_0.OnDisconnected;
			}
			if (udpClientOptions_0.OnStarted != null)
			{
				base.OnStarted = udpClientOptions_0.OnStarted;
			}
			if (udpClientOptions_0.OnStopped != null)
			{
				base.OnStopped = udpClientOptions_0.OnStopped;
			}
			if (udpClientOptions_0.OnException != null)
			{
				base.OnException = udpClientOptions_0.OnException;
			}
			return;
		}
		throw new ArgumentNullException("options");
	}

	public override void Start()
	{
		Connection?.Start();
	}

	public override void Stop()
	{
		Connection?.Stop();
	}

	protected override void OnConnectedHandler(NetClientEventArgs<IUdpConnection> args)
	{
		throw new NotSupportedException();
	}

	public override void Dispose()
	{
		Connection?.Dispose();
	}

	static UdpClient()
	{
		Class72.smethod_20();
	}
}
