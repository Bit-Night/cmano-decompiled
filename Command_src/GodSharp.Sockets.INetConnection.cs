using System;
using System.Net;
using System.Net.Sockets;

namespace GodSharp.Sockets;

public interface INetConnection : IDisposable
{
	int Id { get; }

	string Name { get; }

	string Key { get; }

	IPEndPoint LocalEndPoint { get; }

	IPEndPoint RemoteEndPoint { get; }

	Socket Instance { get; }

	void Start();

	void Stop();
}
