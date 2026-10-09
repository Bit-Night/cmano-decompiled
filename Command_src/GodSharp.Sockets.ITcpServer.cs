using System;
using System.Collections.Generic;
using System.Net.Sockets;
using GodSharp.Sockets.Abstractions;

namespace GodSharp.Sockets;

public interface ITcpServer : INetBase<ITcpConnection>, IDisposable, ITcpServerEvents, IEvent<ITcpConnection, NetServerEventArgs>
{
	Socket Instance { get; }

	IDictionary<string, ITcpConnection> Connections { get; }
}
