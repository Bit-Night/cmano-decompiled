using System;

namespace GodSharp.Sockets.Abstractions;

public interface INetListener<T> : IDisposable where T : INetConnection
{
	T Connection { get; }

	bool Running { get; }

	void Start();

	void Stop();

	void BeginReceive();

	void ReceivedCallback(IAsyncResult result);
}
