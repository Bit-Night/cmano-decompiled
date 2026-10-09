using System;
using System.Diagnostics;

namespace Collections.Pooled;

internal sealed class QueueDebugView<T>
{
	private readonly PooledQueue<T> pooledQueue_0;

	internal static object object_0;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public T[] Items => pooledQueue_0.ToArray();

	public QueueDebugView(PooledQueue<T> queue)
	{
		pooledQueue_0 = queue ?? throw new ArgumentNullException("queue");
	}

	static QueueDebugView()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_0()
	{
		return object_0 == null;
	}

	internal static object smethod_1()
	{
		return object_0;
	}
}
