using System;
using System.Collections.Concurrent;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class ObjectPoolingSystem
{
	public static long Intantiated;

	public static long Intantiated_Pool;

	public static long Intantiated_NewObject;

	public static long Intantiated_FailedPooling;

	private static ConcurrentQueue<Ipoolable>[] concurrentQueue_0;

	public static int MaxItem;

	static ObjectPoolingSystem()
	{
		Class72.smethod_20();
		Intantiated = 0L;
		Intantiated_Pool = 0L;
		Intantiated_NewObject = 0L;
		Intantiated_FailedPooling = 0L;
		MaxItem = 0;
		int length = Enum.GetValues(typeof(PoolableObjectType)).Length;
		concurrentQueue_0 = new ConcurrentQueue<Ipoolable>[length - 1 + 1];
		int num = length - 1;
		for (int i = 0; i <= num; i++)
		{
			concurrentQueue_0[i] = new ConcurrentQueue<Ipoolable>();
		}
	}

	public static Ipoolable GetObject(PoolableObjectType objectType)
	{
		Ipoolable result;
		try
		{
			ConcurrentQueue<Ipoolable> concurrentQueue = concurrentQueue_0[(int)objectType];
			if (concurrentQueue.Count <= 0)
			{
				result = null;
			}
			else
			{
				Ipoolable result2 = null;
				result = ((!concurrentQueue.TryDequeue(out result2)) ? null : result2);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool ReturnObject(Ipoolable obj)
	{
		ConcurrentQueue<Ipoolable> concurrentQueue = concurrentQueue_0[(int)obj.PoolableType];
		if (concurrentQueue.Count < MaxItem)
		{
			obj.Reinitialize();
			concurrentQueue.Enqueue(obj);
			return true;
		}
		return false;
	}

	public static void ClearPool()
	{
		ConcurrentQueue<Ipoolable>[] array = concurrentQueue_0;
		foreach (ConcurrentQueue<Ipoolable> concurrentQueue in array)
		{
			Ipoolable result;
			do
			{
				result = null;
			}
			while (concurrentQueue.TryDequeue(out result));
		}
	}

	public static void ClearPool(PoolableObjectType objectType)
	{
		ConcurrentQueue<Ipoolable> concurrentQueue = concurrentQueue_0[(int)objectType];
		Ipoolable result;
		do
		{
			result = null;
		}
		while (concurrentQueue.TryDequeue(out result));
	}

	public static void DebugPrint(bool ClearLog = false)
	{
		if (ClearLog)
		{
			Intantiated = 0L;
			Intantiated_NewObject = 0L;
			Intantiated_FailedPooling = 0L;
			Intantiated_Pool = 0L;
		}
	}
}
