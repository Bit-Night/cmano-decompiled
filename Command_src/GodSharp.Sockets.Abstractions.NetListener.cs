using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets.Abstractions;

public abstract class NetListener<T> : INetListener<T>, IDisposable where T : INetConnection
{
	protected class ReceiveResult
	{
		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private IPEndPoint ipendPoint_0;

		internal static object object_0;

		public int Length
		{
			[CompilerGenerated]
			get
			{
				return int_0;
			}
			[CompilerGenerated]
			set
			{
				int_0 = value;
			}
		}

		public IPEndPoint RemoteEndPoint
		{
			[CompilerGenerated]
			get
			{
				return ipendPoint_0;
			}
			[CompilerGenerated]
			set
			{
				ipendPoint_0 = value;
			}
		}

		public ReceiveResult()
		{
		}

		public ReceiveResult(int length, IPEndPoint remoteEndPoint)
		{
			Length = length;
			RemoteEndPoint = remoteEndPoint;
		}

		static ReceiveResult()
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

	[CompilerGenerated]
	private T gparam_0;

	private bool bool_0;

	private byte[] byte_0;

	private static object object_0;

	public virtual T Connection
	{
		[CompilerGenerated]
		get
		{
			return gparam_0;
		}
		[CompilerGenerated]
		internal set
		{
			gparam_0 = value;
		}
	}

	public virtual bool Running
	{
		get
		{
			return bool_0;
		}
		internal set
		{
			bool_0 = value;
		}
	}

	public NetListener(T connection)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		Connection = connection;
	}

	public virtual void Start()
	{
		if (Running)
		{
			return;
		}
		try
		{
			SocketExtensions.KeepAlive(Connection.Instance, 1000, 500);
			BeginReceive();
			Running = true;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public void Stop()
	{
		if (!Running)
		{
			return;
		}
		Running = false;
		Exception exception = null;
		try
		{
			T connection = Connection;
			if (connection != null)
			{
				connection.Instance.Disconnect(reuseSocket: false);
			}
			connection = Connection;
			if (connection != null)
			{
				connection.Instance.Close();
			}
		}
		catch (Exception ex)
		{
			exception = ex;
		}
		OnStop(exception);
	}

	protected abstract void OnStop(Exception exception);

	protected abstract void OnException(Exception exception);

	public void BeginReceive()
	{
		byte_0 = new byte[Connection.Instance.ReceiveBufferSize];
		OnBeginReceive(ref byte_0);
	}

	protected abstract void OnBeginReceive(ref byte[] buffers);

	public void ReceivedCallback(IAsyncResult result)
	{
		bool flag = false;
		try
		{
			if (!Running)
			{
				return;
			}
			ReceiveResult receiveResult = OnEndReceive<ReceiveResult>(result);
			int num;
			if (receiveResult == null)
			{
				num = 1;
			}
			else
			{
				if (receiveResult.Length > 0)
				{
					byte[] array = new byte[receiveResult.Length];
					Buffer.BlockCopy(byte_0, 0, array, 0, receiveResult.Length);
					BeginReceive();
					OnReceiveHandling(array, receiveResult.RemoteEndPoint, Connection.LocalEndPoint);
					return;
				}
				num = 1;
			}
			flag = (byte)num != 0;
		}
		catch (Exception exception)
		{
			flag = true;
			OnException(exception);
		}
		finally
		{
			if (flag)
			{
				Stop();
			}
		}
	}

	protected abstract U OnEndReceive<U>(IAsyncResult result) where U : ReceiveResult, new();

	protected abstract void OnReceiveHandling(byte[] buffers, IPEndPoint remote = null, IPEndPoint local = null);

	public abstract void Dispose();

	static NetListener()
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
