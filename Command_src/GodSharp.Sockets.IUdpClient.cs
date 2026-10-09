using System;
using GodSharp.Sockets.Abstractions;

namespace GodSharp.Sockets;

public interface IUdpClient : INetBase<IUdpConnection>, IDisposable, IUdpClientEvents, IEvent<IUdpConnection, NetClientEventArgs<IUdpConnection>>
{
	IUdpConnection Connection { get; }
}
