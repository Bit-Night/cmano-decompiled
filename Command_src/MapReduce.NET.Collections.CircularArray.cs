using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MapReduce.NET.Collections;

internal class CircularArray<K, V> : IQueue<K, V>
{
	private K[] gparam_0 = new K[10000];

	private V[] gparam_1 = new V[10000];

	private volatile uint uint_0;

	private volatile uint uint_1;

	[CompilerGenerated]
	private int int_0;

	private bool bool_0 = true;

	private static object object_0;

	public uint Length => 10000u;

	internal int DelayedWriteCount
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

	internal bool MapInProgress
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	internal bool HasNext => uint_0 > uint_1;

	public void Push(K key, V value)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		uint num = uint_0 + 1;
		while (num == uint_1 + 10000)
		{
			Thread.Sleep(0);
			DelayedWriteCount++;
		}
		uint num2 = uint_0 % 10000;
		gparam_0[num2] = key;
		gparam_1[num2] = value;
		uint_0 = num;
	}

	internal bool Pop(out K key, out V value)
	{
		uint num = uint_1 + 1;
		key = default(K);
		value = default(V);
		if (num <= uint_0)
		{
			uint num2 = uint_1 % 10000;
			key = gparam_0[num2];
			value = gparam_1[num2];
			uint_1 = num;
			return true;
		}
		return false;
	}

	static CircularArray()
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
