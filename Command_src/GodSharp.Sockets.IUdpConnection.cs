using System;
using System.Net;
using GodSharp.Sockets.Abstractions;

namespace GodSharp.Sockets;

public interface IUdpConnection : IEvent<IUdpConnection, NetClientEventArgs<IUdpConnection>>, INetConnection, IDisposable
{
	IUdpListener Listener { get; }

	IPEndPoint ListenEndPoint { get; }
}
