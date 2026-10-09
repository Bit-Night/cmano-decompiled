using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class FixedSizedQueue<T> : Queue
{
	private object object_0;

	[CompilerGenerated]
	private int int_0;

	internal static object object_1;

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

	public FixedSizedQueue(int theSize)
	{
		object_0 = new LockObject();
		Limit = theSize;
	}

	public override void Enqueue(object obj)
	{
		base.Enqueue(RuntimeHelpers.GetObjectValue(obj));
		if (Count <= Limit)
		{
			return;
		}
		object obj2 = object_0;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj2);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj2, ref lockTaken);
			while (Count > Limit)
			{
				RuntimeHelpers.GetObjectValue(Dequeue());
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj2);
			}
		}
	}

	static FixedSizedQueue()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_0()
	{
		return object_1 == null;
	}

	internal static object smethod_1()
	{
		return object_1;
	}
}
