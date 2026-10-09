namespace GodSharp.Sockets;

public delegate void SocketEventHandler<T>(T e) where T : NetEventArgs;
