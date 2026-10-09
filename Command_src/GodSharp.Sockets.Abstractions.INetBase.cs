using System;

namespace GodSharp.Sockets.Abstractions;

public interface INetBase<T> : IDisposable where T : INetConnection
{
	int Id { get; }

	string Name { get; }

	string Key { get; }

	bool Running { get; }

	void Start();

	void Stop();
}
