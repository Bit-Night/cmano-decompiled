using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using GodSharp.Sockets.Abstractions;
using GodSharp.Sockets.Extensions;

namespace GodSharp.Sockets.Udp;

public sealed class UdpConnection : NetConnection<IUdpConnection, NetClientEventArgs<IUdpConnection>>, IUdpConnection, IEvent<IUdpConnection, NetClientEventArgs<IUdpConnection>>, INetConnection, IDisposable
{
	[CompilerGenerated]
	private IUdpListener iudpListener_0;

	[CompilerGenerated]
	private IPEndPoint ipendPoint_1;

	[CompilerGenerated]
	private bool aDqyFaksGod;

	public override SocketEventHandler<NetClientEventArgs<IUdpConnection>> OnConnected
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public IUdpListener Listener
	{
		[CompilerGenerated]
		get
		{
			return iudpListener_0;
		}
		[CompilerGenerated]
		private set
		{
			iudpListener_0 = value;
		}
	}

	public IPEndPoint ListenEndPoint
	{
		[CompilerGenerated]
		get
		{
			return ipendPoint_1;
		}
		[CompilerGenerated]
		private set
		{
			ipendPoint_1 = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private bool method_2()
	{
		return aDqyFaksGod;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_3(bool bool_0)
	{
		aDqyFaksGod = bool_0;
	}

	internal UdpConnection(IPEndPoint remote, IPEndPoint local, AddressFamily family = AddressFamily.InterNetwork)
	{
		method_4(remote, local, family);
	}

	private void method_4(IPEndPoint ipendPoint_2, IPEndPoint ipendPoint_3, AddressFamily addressFamily_0 = AddressFamily.InterNetwork)
	{
		try
		{
			if (ipendPoint_2 == null && ipendPoint_3 == null)
			{
				throw new ArgumentNullException("remote,local");
			}
			if (ipendPoint_2 != null && IComparableExtensions.NotIn(ipendPoint_2.Port, 0, 65535))
			{
				throw new ArgumentOutOfRangeException("remote", string.Format("The {0} port must between {1} to {2}.", "remote", 0, 65535));
			}
			if (ipendPoint_3 != null && IComparableExtensions.NotIn(ipendPoint_3.Port, 0, 65535))
			{
				throw new ArgumentOutOfRangeException("local", string.Format("The {0} port must between {1} to {2}.", "remote", 0, 65535));
			}
			if (ipendPoint_2 != null && ipendPoint_3 != null)
			{
				if (ipendPoint_2.Port < 1 && ipendPoint_3.Port < 1)
				{
					throw new ArgumentNullException("Port, Port");
				}
			}
			else
			{
				if (ipendPoint_2 != null && ipendPoint_2.Port < 1)
				{
					throw new ArgumentOutOfRangeException("Port");
				}
				if (ipendPoint_3 != null && ipendPoint_3.Port < 1)
				{
					throw new ArgumentOutOfRangeException("Port");
				}
			}
			if (addressFamily_0 != AddressFamily.InterNetwork && addressFamily_0 != AddressFamily.InterNetworkV6)
			{
				throw new ArgumentOutOfRangeException("family", "The AddressFamily only support AddressFamily.InterNetwork and AddressFamily.InterNetworkV6.");
			}
			if (ipendPoint_2 != null && ipendPoint_2.AddressFamily != addressFamily_0)
			{
				throw new ArgumentException("The remote and family not match.");
			}
			if (ipendPoint_3 != null && ipendPoint_3.AddressFamily != addressFamily_0)
			{
				throw new ArgumentException("The local and family not match.");
			}
			method_3(ipendPoint_2 != null && ipendPoint_2.Port > 0);
			ListenEndPoint = (method_2() ? ipendPoint_2 : new IPEndPoint((addressFamily_0 == AddressFamily.InterNetworkV6) ? IPAddress.IPv6Any : IPAddress.Any, 0));
			Instance = new Socket(addressFamily_0, SocketType.Dgram, ProtocolType.Udp);
			if (ipendPoint_3 != null && ipendPoint_3.Port > 0)
			{
				Instance.Bind(ipendPoint_3);
			}
			LocalEndPoint = ipendPoint_3;
			RemoteEndPoint = ListenEndPoint;
			Key = ipendPoint_3.ToString();
			Name = Name ?? Key;
		}
		catch (Exception ex)
		{
			OnException?.Invoke(new NetClientEventArgs<IUdpConnection>(this)
			{
				Exception = ex
			});
			throw ex;
		}
	}

	public override void Start()
	{
		try
		{
			IUdpListener listener = Listener;
			if (listener == null || !listener.Running)
			{
				Listener = new UdpListener(this);
				Listener.Start();
				OnStarted?.Invoke(new NetClientEventArgs<IUdpConnection>(this));
			}
		}
		catch (Exception exception)
		{
			OnException?.Invoke(new NetClientEventArgs<IUdpConnection>(this)
			{
				Exception = exception
			});
		}
	}

	public override void Stop()
	{
		if (Listener == null || !Listener.Running)
		{
			return;
		}
		try
		{
			Listener?.Stop();
			OnStopped?.Invoke(new NetClientEventArgs<IUdpConnection>(this));
		}
		catch (Exception exception)
		{
			OnException?.Invoke(new NetClientEventArgs<IUdpConnection>(this)
			{
				Exception = exception
			});
		}
	}

	public override void Dispose()
	{
		Listener?.Dispose();
	}

	static UdpConnection()
	{
		Class72.smethod_20();
	}
}
