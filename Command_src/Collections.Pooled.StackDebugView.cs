using System;
using System.Diagnostics;

namespace Collections.Pooled;

internal sealed class StackDebugView<T>
{
	private readonly PooledStack<T> pooledStack_0;

	private static object object_0;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public T[] Items => pooledStack_0.ToArray();

	public StackDebugView(PooledStack<T> stack)
	{
		pooledStack_0 = stack ?? throw new ArgumentNullException("stack");
	}

	static StackDebugView()
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
