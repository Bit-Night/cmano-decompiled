using System;
using GodSharp.Sockets.Abstractions;

namespace GodSharp.Sockets;

public interface ITcpClient : INetBase<ITcpConnection>, IDisposable, ITcpClientEvents, IEvent<ITcpConnection, NetClientEventArgs<ITcpConnection>>
{
	ITcpConnection Connection { get; }
}
