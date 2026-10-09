using System;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets.Abstractions;

public abstract class NetBase<T, U> : INetBase<T>, IDisposable, IEvent<T, U> where T : INetConnection where U : NetEventArgs
{
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

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private bool bool_0;

	private static object object_0;

	public virtual SocketEventHandler<NetClientEventArgs<T>> OnConnected
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_0;
		}
		[CompilerGenerated]
		set
		{
			socketEventHandler_0 = value;
		}
	}

	public SocketEventHandler<NetClientReceivedEventArgs<T>> OnReceived
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_1;
		}
		[CompilerGenerated]
		set
		{
			socketEventHandler_1 = value;
		}
	}

	public SocketEventHandler<NetClientEventArgs<T>> OnDisconnected
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_2;
		}
		[CompilerGenerated]
		set
		{
			socketEventHandler_2 = value;
		}
	}

	public SocketEventHandler<U> OnStarted
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_3;
		}
		[CompilerGenerated]
		set
		{
			socketEventHandler_3 = value;
		}
	}

	public SocketEventHandler<U> OnStopped
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_4;
		}
		[CompilerGenerated]
		set
		{
			socketEventHandler_4 = value;
		}
	}

	public SocketEventHandler<NetClientEventArgs<T>> OnException
	{
		[CompilerGenerated]
		get
		{
			return socketEventHandler_5;
		}
		[CompilerGenerated]
		set
		{
			socketEventHandler_5 = value;
		}
	}

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

	public virtual bool Running
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		protected set
		{
			bool_0 = value;
		}
	}

	public abstract void Start();

	public abstract void Stop();

	protected virtual void OnConnectedHandler(NetClientEventArgs<T> args)
	{
		OnConnected?.Invoke(args);
	}

	protected virtual void OnReceivedHandler(NetClientReceivedEventArgs<T> args)
	{
		OnReceived?.Invoke(args);
	}

	protected virtual void OnDisconnectedHandler(NetClientEventArgs<T> args)
	{
		OnDisconnected?.Invoke(args);
	}

	protected virtual void OnStartedHandler(U args)
	{
		OnStarted?.Invoke(args);
	}

	protected virtual void OnStoppedHandler(U args)
	{
		OnStopped?.Invoke(args);
	}

	protected virtual void OnExceptionHandler(NetClientEventArgs<T> args)
	{
		OnException?.Invoke(args);
	}

	public abstract void Dispose();

	static NetBase()
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
