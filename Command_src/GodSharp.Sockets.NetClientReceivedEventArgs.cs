using System.Net;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets;

public class NetClientReceivedEventArgs<T> : NetClientEventArgs<T> where T : INetConnection
{
	[CompilerGenerated]
	private byte[] byte_0;

	private static object object_1;

	public byte[] Buffers
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		internal set
		{
			byte_0 = value;
		}
	}

	public NetClientReceivedEventArgs(T connection, byte[] buffers)
		: this(connection, buffers, (IPEndPoint)null, (IPEndPoint)null)
	{
	}

	public NetClientReceivedEventArgs(T connection, byte[] buffers, IPEndPoint remote = null, IPEndPoint local = null)
		: base(connection, remote, local)
	{
		Buffers = buffers;
	}

	static NetClientReceivedEventArgs()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_2()
	{
		return object_1 == null;
	}

	internal static object smethod_3()
	{
		return object_1;
	}
}
