using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using GodSharp.Sockets.Abstractions;
using GodSharp.Sockets.Extensions;

namespace GodSharp.Sockets.Tcp;

public sealed class TcpConnection : NetConnection<ITcpConnection, NetClientEventArgs<ITcpConnection>>, ITcpConnection, IEvent<ITcpConnection, NetClientEventArgs<ITcpConnection>>, INetConnection, IDisposable
{
	private class Class45
	{
		[CompilerGenerated]
		private EventWaitHandle eventWaitHandle_0;

		[CompilerGenerated]
		private EventWaitHandle eventWaitHandle_1;

		[CompilerGenerated]
		private bool? nullable_0;

		[CompilerGenerated]
		private Exception exception_0;

		[SpecialName]
		[CompilerGenerated]
		private EventWaitHandle method_0()
		{
			return eventWaitHandle_0;
		}

		[SpecialName]
		[CompilerGenerated]
		private void method_1(EventWaitHandle eventWaitHandle_2)
		{
			eventWaitHandle_0 = eventWaitHandle_2;
		}

		[SpecialName]
		[CompilerGenerated]
		private EventWaitHandle method_2()
		{
			return eventWaitHandle_1;
		}

		[SpecialName]
		[CompilerGenerated]
		private void method_3(EventWaitHandle eventWaitHandle_2)
		{
			eventWaitHandle_1 = eventWaitHandle_2;
		}

		[SpecialName]
		[CompilerGenerated]
		public bool? egxeKsPmyct()
		{
			return nullable_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public void kyFeKfExxEy(bool? nullable_1)
		{
			nullable_0 = nullable_1;
		}

		[SpecialName]
		[CompilerGenerated]
		public Exception method_4()
		{
			return exception_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public void method_5(Exception exception_1)
		{
			exception_0 = exception_1;
		}

		public bool method_6(int int_0 = -1)
		{
			if (int_0 >= 1)
			{
				return method_0().WaitOne(int_0);
			}
			return method_0().WaitOne();
		}

		public void method_7()
		{
			method_0().Set();
		}

		public bool method_8()
		{
			return method_2().WaitOne();
		}

		public bool method_9()
		{
			return method_2().Set();
		}

		public Class45()
		{
			method_1(new ManualResetEvent(initialState: false));
			method_3(new ManualResetEvent(initialState: false));
		}

		public Class45(bool bool_0, Exception exception_1 = null)
		{
			kyFeKfExxEy(bool_0);
			method_5(exception_1);
		}

		static Class45()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private IPEndPoint ipendPoint_1;

	[CompilerGenerated]
	private IPEndPoint ipendPoint_2;

	[CompilerGenerated]
	private ITcpListener itcpListener_0;

	[CompilerGenerated]
	private int int_1 = 3000;

	[CompilerGenerated]
	private bool bool_2 = true;

	private int int_2;

	private bool bool_3;

	private bool bool_4;

	[CompilerGenerated]
	private SocketEventHandler<TryConnectingEventArgs<ITcpConnection>> socketEventHandler_6;

	[CompilerGenerated]
	private ITryConnectionStrategy itryConnectionStrategy_0;

	public ITcpListener Listener
	{
		[CompilerGenerated]
		get
		{
			return itcpListener_0;
		}
		[CompilerGenerated]
		internal set
		{
			itcpListener_0 = value;
		}
	}

	public int ConnectTimeout
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		internal set
		{
			int_1 = value;
		}
	}

	public bool ReconnectEnable
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	internal SocketEventHandler<TryConnectingEventArgs<ITcpConnection>> OnTryConnecting
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

	internal ITryConnectionStrategy TryConnectionStrategy
	{
		[CompilerGenerated]
		get
		{
			return itryConnectionStrategy_0;
		}
		[CompilerGenerated]
		set
		{
			itryConnectionStrategy_0 = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private bool method_0()
	{
		return bool_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_1(bool bool_5)
	{
		bool_0 = bool_5;
	}

	[SpecialName]
	[CompilerGenerated]
	private bool method_2()
	{
		return bool_1;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_3(bool bool_5)
	{
		bool_1 = bool_5;
	}

	[SpecialName]
	[CompilerGenerated]
	private IPEndPoint method_4()
	{
		return ipendPoint_1;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_5(IPEndPoint ipendPoint_3)
	{
		ipendPoint_1 = ipendPoint_3;
	}

	[SpecialName]
	[CompilerGenerated]
	private IPEndPoint method_6()
	{
		return ipendPoint_2;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_7(IPEndPoint ipendPoint_3)
	{
		ipendPoint_2 = ipendPoint_3;
	}

	internal TcpConnection(Socket socket)
	{
		method_3(bool_5: false);
		if (socket.LocalEndPoint == null && socket.RemoteEndPoint == null)
		{
			throw new ArgumentException("This socket is not connected.");
		}
		Instance = socket;
		LocalEndPoint = EndPointExtensions.As(socket.LocalEndPoint);
		RemoteEndPoint = EndPointExtensions.As(socket.RemoteEndPoint);
		Key = RemoteEndPoint.ToString();
		Name = Name ?? Key;
		method_1(bool_5: true);
	}

	internal TcpConnection(IPEndPoint remote, IPEndPoint local)
	{
		method_8(remote, local);
	}

	private void method_8(IPEndPoint ipendPoint_3, IPEndPoint ipendPoint_4)
	{
		method_5(ipendPoint_3);
		method_7(ipendPoint_4);
		method_3(bool_5: true);
		try
		{
			if (ipendPoint_3 != null)
			{
				AddressFamily addressFamily = ipendPoint_3.AddressFamily;
				if (!IComparableExtensions.NotIn(ipendPoint_3.Port, 0, 65535))
				{
					if (ipendPoint_3.Port < 1)
					{
						throw new ArgumentOutOfRangeException("Port");
					}
					if (addressFamily != AddressFamily.InterNetwork && addressFamily != AddressFamily.InterNetworkV6)
					{
						throw new ArgumentOutOfRangeException("family", "The AddressFamily only support AddressFamily.InterNetwork and AddressFamily.InterNetworkV6.");
					}
					if (ipendPoint_4 != null && ipendPoint_4.AddressFamily != addressFamily)
					{
						throw new ArgumentException("The local and family not match.");
					}
					Instance = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp);
					if (ipendPoint_4 != null && ipendPoint_4.Port > 0)
					{
						Instance.Bind(ipendPoint_4);
					}
					RemoteEndPoint = ipendPoint_3;
					if (ipendPoint_4 != null && ipendPoint_4.Port > 0)
					{
						LocalEndPoint = ipendPoint_4;
					}
					Key = RemoteEndPoint.ToString();
					Name = Name ?? Key;
					return;
				}
				throw new ArgumentOutOfRangeException("Port", string.Format("The {0} must between {1} to {2}.", "Port", 0, 65535));
			}
			throw new ArgumentNullException("remote");
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	internal void Reconnect()
	{
		try
		{
			if (!ReconnectEnable || !method_2())
			{
				return;
			}
			bool_4 = true;
			bool flag = false;
			do
			{
				int_2++;
				Console.WriteLine(string.Format("[{0}]try connect to {1} {2} ...", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), EndPointExtensions.As(method_4()), int_2));
				OnTryConnecting?.Invoke(new TryConnectingEventArgs<ITcpConnection>(this, int_2));
				method_8(method_4(), method_6());
				if (flag = method_9())
				{
					continue;
				}
				try
				{
					if (TryConnectionStrategy != null)
					{
						Thread.Sleep(TryConnectionStrategy.Handle(int_2));
					}
				}
				catch (Exception exception)
				{
					OnException?.Invoke(new NetClientEventArgs<ITcpConnection>(this)
					{
						Exception = exception
					});
				}
			}
			while (!flag);
		}
		finally
		{
			bool_4 = false;
		}
	}

	public override void Start()
	{
		bool_3 = method_9();
		if (!bool_3)
		{
			ThreadPool.QueueUserWorkItem(delegate
			{
				Reconnect();
			});
		}
	}

	private bool method_9()
	{
		try
		{
			ITcpListener listener = Listener;
			if (listener != null && listener.Running)
			{
				return true;
			}
			int num;
			if (!method_0())
			{
				num = (Connect(ConnectTimeout) ? 1 : 0);
				if (num == 0)
				{
					goto IL_0052;
				}
			}
			else
			{
				num = 1;
			}
			int_2 = 0;
			Listener = new TcpListener(this);
			Listener.Start();
			goto IL_0052;
			IL_0052:
			ITcpListener listener2 = Listener;
			if (listener2 != null && listener2.Running)
			{
				OnStarted?.Invoke(new NetClientEventArgs<ITcpConnection>(this));
			}
			if (num != 0)
			{
				int result;
				if (!bool_3)
				{
					bool_3 = true;
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
		}
		catch (Exception ex)
		{
			OnException?.Invoke(new NetClientEventArgs<ITcpConnection>(this)
			{
				Exception = ex
			});
			if (!method_0() && !method_2())
			{
				throw ex;
			}
		}
		return false;
	}

	public override void Stop()
	{
		if (Listener != null && Listener.Running)
		{
			try
			{
				Listener?.Stop();
				OnStopped?.Invoke(new NetClientEventArgs<ITcpConnection>(this));
			}
			catch (Exception exception)
			{
				OnException?.Invoke(new NetClientEventArgs<ITcpConnection>(this)
				{
					Exception = exception
				});
			}
		}
	}

	private bool Connect(int millisecondsTimeout = -1)
	{
		Class45 @class = new Class45();
		Instance.BeginConnect(EndPointExtensions.As(RemoteEndPoint), method_10, @class);
		bool flag;
		if (!(flag = @class.method_6(millisecondsTimeout)))
		{
			@class.kyFeKfExxEy(flag);
		}
		@class.method_8();
		if (flag)
		{
			if (@class.egxeKsPmyct() == false && @class.method_4() != null)
			{
				OnException?.Invoke(new NetClientEventArgs<ITcpConnection>(this)
				{
					Exception = @class.method_4()
				});
				if (method_2())
				{
					throw @class.method_4();
				}
				return false;
			}
			return @class.egxeKsPmyct() == true;
		}
		throw new SocketException(10060);
	}

	private void method_10(IAsyncResult iasyncResult_0)
	{
		Class45 @class = iasyncResult_0.AsyncState as Class45;
		bool? flag = null;
		@class.method_7();
		try
		{
			Instance.EndConnect(iasyncResult_0);
			flag = false;
			if (@class.egxeKsPmyct() != false)
			{
				Console.WriteLine("tcp.client connected");
				RemoteEndPoint = EndPointExtensions.As(Instance.RemoteEndPoint);
				LocalEndPoint = EndPointExtensions.As(Instance.LocalEndPoint);
				OnConnected?.Invoke(new NetClientEventArgs<ITcpConnection>(this));
				@class.kyFeKfExxEy(true);
				flag = true;
			}
		}
		catch (Exception exception_)
		{
			@class.kyFeKfExxEy(false);
			@class.method_5(exception_);
		}
		finally
		{
			Console.WriteLine($"tcp.client ConnectCallback connected:{flag}");
			if (flag == false && @class.egxeKsPmyct() == false)
			{
				try
				{
					Instance.Close();
				}
				catch (Exception ex)
				{
					@class.method_5(@class.method_4() ?? ex);
				}
			}
			@class.method_9();
		}
	}

	public override void Dispose()
	{
		Listener?.Dispose();
	}

	[CompilerGenerated]
	private void method_11(object object_1)
	{
		Reconnect();
	}

	static TcpConnection()
	{
		Class72.smethod_20();
	}
}
