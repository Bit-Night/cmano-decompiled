namespace GodSharp.Sockets.Abstractions;

public interface IEvent<T, U> where T : INetConnection where U : NetEventArgs
{
	SocketEventHandler<NetClientEventArgs<T>> OnConnected { get; }

	SocketEventHandler<NetClientReceivedEventArgs<T>> OnReceived { get; }

	SocketEventHandler<NetClientEventArgs<T>> OnDisconnected { get; }

	SocketEventHandler<U> OnStarted { get; }

	SocketEventHandler<U> OnStopped { get; }

	SocketEventHandler<NetClientEventArgs<T>> OnException { get; }
}
