namespace GodSharp.Sockets.Abstractions.Events;

public interface INetEventMethods<T, U> where T : INetConnection where U : NetEventArgs
{
	void OnConnectedHandler(NetClientEventArgs<T> args);

	void OnReceivedHandler(NetClientReceivedEventArgs<T> args);

	void OnDisconnectedHandler(NetClientEventArgs<T> args);

	void OnStartedHandler(U args);

	void OnStoppedHandler(U args);

	void OnExceptionHandler(NetClientEventArgs<T> args);
}
