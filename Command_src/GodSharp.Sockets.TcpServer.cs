using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using GodSharp.Sockets.Abstractions;
using GodSharp.Sockets.Extensions;
using GodSharp.Sockets.Tcp;

namespace GodSharp.Sockets;

public sealed class TcpServer : NetBase<ITcpConnection, NetServerEventArgs>, ITcpServer, INetBase<ITcpConnection>, IDisposable, ITcpServerEvents, IEvent<ITcpConnection, NetServerEventArgs>
{
	private readonly object object_1 = new object();

	private bool bool_1;

	private bool bool_2;

	[CompilerGenerated]
	private Socket qnryxFmwkZg;

	[CompilerGenerated]
	private IPEndPoint ipendPoint_0;

	[CompilerGenerated]
	private IDictionary<string, ITcpConnection> idictionary_0 = new Dictionary<string, ITcpConnection>();

	[CompilerGenerated]
	private SocketEventHandler<NetServerEventArgs> socketEventHandler_6;

	public override bool Running => bool_2;

	public Socket Instance
	{
		[CompilerGenerated]
		get
		{
			return qnryxFmwkZg;
		}
		[CompilerGenerated]
		private set
		{
			qnryxFmwkZg = value;
		}
	}

	public IPEndPoint LocalEndPoint
	{
		[CompilerGenerated]
		get
		{
			return ipendPoint_0;
		}
		[CompilerGenerated]
		private set
		{
			ipendPoint_0 = value;
		}
	}

	public IDictionary<string, ITcpConnection> Connections
	{
		[CompilerGenerated]
		get
		{
			return idictionary_0;
		}
		[CompilerGenerated]
		private set
		{
			idictionary_0 = value;
		}
	}

	public SocketEventHandler<NetServerEventArgs> OnServerException
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

	public TcpServer(TcpServerOptions options)
	{
		bXwyxuoeuco(options);
	}

	public TcpServer(int port = 7788, string host = null, int backlog = int.MaxValue, AddressFamily family = AddressFamily.InterNetwork, string name = null, int id = 0)
	{
		try
		{
			TcpServerOptions tcpServerOptions_ = new TcpServerOptions(new IPEndPoint((!StringExtensions.IsNullOrWhiteSpace(host)) ? IPAddress.Parse(host) : ((family == AddressFamily.InterNetworkV6) ? IPAddress.IPv6Any : IPAddress.Any), port), backlog, family)
			{
				Id = id,
				Name = name
			};
			bXwyxuoeuco(tcpServerOptions_);
		}
		catch (Exception ex)
		{
			OnServerException?.Invoke(new NetServerEventArgs(this, LocalEndPoint)
			{
				Exception = ex
			});
			throw ex;
		}
	}

	private void bXwyxuoeuco(TcpServerOptions tcpServerOptions_0)
	{
		try
		{
			if (tcpServerOptions_0 == null)
			{
				throw new ArgumentNullException("options");
			}
			if (tcpServerOptions_0.LocalEndPoint == null)
			{
				throw new ArgumentNullException("LocalEndPoint");
			}
			if (IComparableExtensions.NotIn(tcpServerOptions_0.LocalEndPoint.Port, 0, 65535))
			{
				throw new ArgumentOutOfRangeException("Port", string.Format("The {0} must between {1} to {2}.", "Port", 0, 65535));
			}
			if (tcpServerOptions_0.LocalEndPoint.Port < 1)
			{
				throw new ArgumentOutOfRangeException("Port");
			}
			if (tcpServerOptions_0.Backlog < 1)
			{
				throw new ArgumentOutOfRangeException("Backlog");
			}
			if (tcpServerOptions_0.LocalEndPoint.AddressFamily != tcpServerOptions_0.Family)
			{
				throw new ArgumentException("The AddressFamily and Family not match.");
			}
			AddressFamily family = tcpServerOptions_0.Family;
			if (family != AddressFamily.InterNetwork && family != AddressFamily.InterNetworkV6)
			{
				throw new ArgumentOutOfRangeException("Family", "The AddressFamily only support AddressFamily.InterNetwork and AddressFamily.InterNetworkV6.");
			}
			if (tcpServerOptions_0.OnConnected != null)
			{
				OnConnected = tcpServerOptions_0.OnConnected;
			}
			if (tcpServerOptions_0.OnReceived != null)
			{
				base.OnReceived = tcpServerOptions_0.OnReceived;
			}
			if (tcpServerOptions_0.OnDisconnected != null)
			{
				base.OnDisconnected = tcpServerOptions_0.OnDisconnected;
			}
			if (tcpServerOptions_0.OnStarted != null)
			{
				base.OnStarted = tcpServerOptions_0.OnStarted;
			}
			if (tcpServerOptions_0.OnStopped != null)
			{
				base.OnStopped = tcpServerOptions_0.OnStopped;
			}
			if (tcpServerOptions_0.OnException != null)
			{
				base.OnException = tcpServerOptions_0.OnException;
			}
			LocalEndPoint = tcpServerOptions_0.LocalEndPoint;
			Instance = new Socket(tcpServerOptions_0.Family, SocketType.Stream, ProtocolType.Tcp);
			Instance.Bind(tcpServerOptions_0.LocalEndPoint);
			Instance.Listen(tcpServerOptions_0.Backlog);
			Key = tcpServerOptions_0.LocalEndPoint.ToString();
			Name = tcpServerOptions_0.Name ?? Key;
			Id = tcpServerOptions_0.Id;
		}
		catch (Exception ex)
		{
			OnServerException?.Invoke(new NetServerEventArgs(this, LocalEndPoint)
			{
				Exception = ex
			});
			throw ex;
		}
	}

	public override void Start()
	{
		if (!Running)
		{
			try
			{
				method_2();
				bool_2 = true;
				base.OnStarted?.Invoke(new NetServerEventArgs(this, LocalEndPoint));
			}
			catch (Exception exception)
			{
				OnServerException?.Invoke(new NetServerEventArgs(this, LocalEndPoint)
				{
					Exception = exception
				});
			}
		}
	}

	public override void Stop()
	{
		if (!Running)
		{
			return;
		}
		bool_1 = true;
		SocketAggregateException ex = null;
		try
		{
			List<Exception> list = new List<Exception>();
			try
			{
				Instance.Close();
			}
			catch (Exception item)
			{
				list.Add(item);
			}
			IDictionary<string, ITcpConnection> connections = Connections;
			if (connections == null || connections.Count <= 0)
			{
				return;
			}
			string[] array = Connections.Keys.ToArray();
			foreach (string key in array)
			{
				try
				{
					Connections[key]?.Stop();
				}
				catch (Exception item2)
				{
					list.Add(item2);
				}
			}
			if (list.Count > 0)
			{
				ex = new SocketAggregateException("The tcp server " + Key + " throw exceptions when stopping.", list.ToArray());
			}
			bool_2 = false;
		}
		finally
		{
			if (ex != null)
			{
				OnServerException?.Invoke(new NetServerEventArgs(this, LocalEndPoint)
				{
					Exception = ex
				});
				throw ex;
			}
			if (bool_1)
			{
				base.OnStopped?.Invoke(new NetServerEventArgs(this, LocalEndPoint));
			}
			bool_1 = false;
		}
	}

	protected override void OnDisconnectedHandler(NetClientEventArgs<ITcpConnection> args)
	{
		method_4(args.NetConnection.Key);
		base.OnDisconnected?.Invoke(args);
	}

	private void method_2()
	{
		try
		{
			Instance.BeginAccept(method_3, null);
		}
		catch (Exception exception)
		{
			OnServerException?.Invoke(new NetServerEventArgs(this, LocalEndPoint)
			{
				Exception = exception
			});
			Stop();
		}
	}

	private void method_3(IAsyncResult iasyncResult_0)
	{
		bool flag = false;
		ITcpConnection tcpConnection = null;
		try
		{
			if (!Running || bool_1)
			{
				return;
			}
			Socket socket = Instance.EndAccept(iasyncResult_0);
			if (!bool_1)
			{
				method_2();
				flag = true;
				tcpConnection = new TcpConnection(socket)
				{
					OnConnected = OnConnectedHandler,
					OnReceived = OnReceivedHandler,
					OnDisconnected = OnDisconnectedHandler,
					OnException = OnExceptionHandler
				};
				tcpConnection.Start();
				method_4(tcpConnection.Key);
				lock (object_1)
				{
					Connections.Add(tcpConnection.Key, tcpConnection);
				}
				OnConnected?.Invoke(new NetClientEventArgs<ITcpConnection>(tcpConnection));
			}
		}
		catch (Exception exception)
		{
			OnServerException?.Invoke(new NetServerEventArgs(this, LocalEndPoint, tcpConnection)
			{
				Exception = exception
			});
		}
		finally
		{
			if (Running && !flag && !bool_1)
			{
				method_2();
			}
		}
	}

	private void method_4(string string_2)
	{
		bool flag = false;
		lock (object_1)
		{
			flag = Connections?.ContainsKey(string_2) ?? false;
		}
		try
		{
			if (flag)
			{
				Connections[string_2].Stop();
				Connections[string_2] = null;
			}
		}
		catch (Exception exception)
		{
			OnServerException?.Invoke(new NetServerEventArgs(this, LocalEndPoint)
			{
				Exception = exception
			});
		}
		finally
		{
			if (flag)
			{
				lock (object_1)
				{
					Connections?.Remove(string_2);
				}
			}
		}
	}

	public override void Dispose()
	{
		if (Running)
		{
			Instance.Close();
		}
	}

	static TcpServer()
	{
		Class72.smethod_20();
	}
}
