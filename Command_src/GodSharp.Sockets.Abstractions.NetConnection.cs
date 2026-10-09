using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets.Abstractions;

public abstract class NetConnection<T, U> : IEvent<T, U>, IDisposable where T : INetConnection where U : NetEventArgs
{
	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private Socket socket_0;

	[CompilerGenerated]
	private IPEndPoint ipendPoint_0;

	[CompilerGenerated]
	private IPEndPoint iUuyTetksYV;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<T>> socketEventHandler_0;

	[CompilerGenerated]
	private SocketEventHandler<NetClientReceivedEventArgs<T>> socketEventHandler_1;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<T>> socketEventHandler_2;

	[CompilerGenerated]
	private SocketEventHandler<U> socketEventHandler_3;

	[CompilerGenerated]
	private SocketEventHandler<U> socketEventHandler_4;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<T>> socketEventHandler_5;

	internal static object object_0;

	public virtual int Id
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		internal set
		{
			int_0 = value;
		}
	}

	public virtual string Name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		internal set
		{
			string_0 = value;
		}
	}

	public virtual string Key
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		internal set
		{
			string_1 = value;
		}
	}

	public virtual Socket Instance
	{
		[CompilerGenerated]
		get
		{
			return socket_0;
		}
		[CompilerGenerated]
		protected set
		{
			socket_0 = value;
		}
	}

	public virtual IPEndPoint LocalEndPoint
	{
		[CompilerGenerated]
		get
		{
			return ipendPoint_0;
		}
		[CompilerGenerated]
		protected set
		{
			ipendPoint_0 = value;
		}
	}

	public virtual IPEndPoint RemoteEndPoint
	{
		[CompilerGenerated]
		get
		{
			return iUuyTetksYV;
		}
		[CompilerGenerated]
		protected set
		{
			iUuyTetksYV = value;
		}
	}

	public virtual SocketEventHandler<NetClientEventArgs<T>> OnConnected
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_0;
		}
		[CompilerGenerated]
		internal set
		{
			socketEventHandler_0 = value;
		}
	}

	public virtual SocketEventHandler<NetClientReceivedEventArgs<T>> OnReceived
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_1;
		}
		[CompilerGenerated]
		internal set
		{
			socketEventHandler_1 = value;
		}
	}

	public virtual SocketEventHandler<NetClientEventArgs<T>> OnDisconnected
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_2;
		}
		[CompilerGenerated]
		internal set
		{
			socketEventHandler_2 = value;
		}
	}

	public virtual SocketEventHandler<U> OnStarted
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_3;
		}
		[CompilerGenerated]
		internal set
		{
			socketEventHandler_3 = value;
		}
	}

	public virtual SocketEventHandler<U> OnStopped
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_4;
		}
		[CompilerGenerated]
		internal set
		{
			socketEventHandler_4 = value;
		}
	}

	public virtual SocketEventHandler<NetClientEventArgs<T>> OnException
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_5;
		}
		[CompilerGenerated]
		internal set
		{
			socketEventHandler_5 = value;
		}
	}

	public abstract void Start();

	public abstract void Stop();

	public abstract void Dispose();

	static NetConnection()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_0()
	{
		return object_0 == null;
	}

	internal static object smethod_1()
	{
		return object_0;
	}
}
