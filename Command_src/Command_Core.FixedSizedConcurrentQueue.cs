using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace Command_Core;

public sealed class FixedSizedConcurrentQueue<T>
{
	private ConcurrentQueue<T> concurrentQueue_0;

	private LockObject lockObject_0;

	[CompilerGenerated]
	private int int_0;

	internal static object object_0;

	public int Limit
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public FixedSizedConcurrentQueue(int theSize)
	{
		concurrentQueue_0 = new ConcurrentQueue<T>();
		lockObject_0 = new LockObject();
		Limit = theSize;
	}

	public void Enqueue(T obj)
	{
		concurrentQueue_0.Enqueue(obj);
		lock (lockObject_0)
		{
			T result;
			while (concurrentQueue_0.Count > Limit && concurrentQueue_0.TryDequeue(out result))
			{
			}
		}
	}

	static FixedSizedConcurrentQueue()
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
