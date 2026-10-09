using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using MapReduce.NET.Collections;
using MapReduce.NET.Input;

namespace MapReduce.NET;

public class MapReduceTask : IUpdateSource
{
	private Stopwatch stopwatch_0;

	private long long_0;

	private uint KggeMwijHeY = 100u;

	[CompilerGenerated]
	private StatusDelegate statusDelegate_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private IOTask iotask_0;

	[CompilerGenerated]
	private IOTask iotask_1;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private IDictionary idictionary_0;

	[CompilerGenerated]
	private Thread thread_0;

	[CompilerGenerated]
	private Thread thread_1;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private IDictionary<string, string> idictionary_1;

	public string MapName
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public string ReduceName
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public IOTask Input
	{
		[CompilerGenerated]
		get
		{
			return iotask_0;
		}
		[CompilerGenerated]
		set
		{
			iotask_0 = value;
		}
	}

	public IOTask Output
	{
		[CompilerGenerated]
		get
		{
			return iotask_1;
		}
		[CompilerGenerated]
		set
		{
			iotask_1 = value;
		}
	}

	public bool Parallel
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public IDictionary ReduceResult
	{
		[CompilerGenerated]
		get
		{
			return idictionary_0;
		}
		[CompilerGenerated]
		set
		{
			idictionary_0 = value;
		}
	}

	internal Thread MapThread
	{
		[CompilerGenerated]
		get
		{
			return thread_0;
		}
		[CompilerGenerated]
		set
		{
			thread_0 = value;
		}
	}

	internal Thread ReduceThread
	{
		[CompilerGenerated]
		get
		{
			return thread_1;
		}
		[CompilerGenerated]
		set
		{
			thread_1 = value;
		}
	}

	internal bool PartialSaveInProgress
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public IDictionary<string, string> Parameters
	{
		[CompilerGenerated]
		get
		{
			return idictionary_1;
		}
		[CompilerGenerated]
		set
		{
			idictionary_1 = value;
		}
	}

	public bool IsRunning
	{
		get
		{
			if (MapThread != null)
			{
				return ReduceThread != null;
			}
			return false;
		}
	}

	public uint ReportEveryNth
	{
		get
		{
			return KggeMwijHeY;
		}
		set
		{
			if (value != 0)
			{
				KggeMwijHeY = value;
			}
		}
	}

	internal event StatusDelegate StatusUpdate
	{
		[CompilerGenerated]
		add
		{
			StatusDelegate statusDelegate = statusDelegate_0;
			StatusDelegate statusDelegate2;
			do
			{
				statusDelegate2 = statusDelegate;
				StatusDelegate value2 = (StatusDelegate)Delegate.Combine(statusDelegate2, value);
				statusDelegate = Interlocked.CompareExchange(ref statusDelegate_0, value2, statusDelegate2);
			}
			while ((object)statusDelegate != statusDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			StatusDelegate statusDelegate = statusDelegate_0;
			StatusDelegate statusDelegate2;
			do
			{
				statusDelegate2 = statusDelegate;
				StatusDelegate value2 = (StatusDelegate)Delegate.Remove(statusDelegate2, value);
				statusDelegate = Interlocked.CompareExchange(ref statusDelegate_0, value2, statusDelegate2);
			}
			while ((object)statusDelegate != statusDelegate2);
		}
	}

	public void WaitForComplete()
	{
		if (MapThread != null)
		{
			MapThread.Join();
		}
		if (ReduceThread != null)
		{
			ReduceThread.Join();
		}
		MapThread = null;
		ReduceThread = null;
	}

	internal void FindTypesMap(out MethodInfo miMap, out object dictMap, out object mapper)
	{
		Type type = TypeFinder.FindType(MapName);
		miMap = null;
		dictMap = null;
		mapper = null;
		if (type != null)
		{
			miMap = type.GetMethod("Map");
			Type[] genericArguments = miMap.GetParameters()[2].ParameterType.GetGenericArguments();
			mapper = Activator.CreateInstance(type);
			Type type2 = typeof(CircularArray<, >).MakeGenericType(genericArguments[0], genericArguments[1]);
			dictMap = Activator.CreateInstance(type2);
		}
	}

	internal void FindTypesReduce(out MethodInfo miRed, out IDictionary dictRed, out object reducer)
	{
		Type type = TypeFinder.FindType(ReduceName);
		miRed = null;
		dictRed = null;
		reducer = null;
		if (type != null)
		{
			miRed = type.GetMethod("Reduce");
			ParameterInfo[] parameters = miRed.GetParameters();
			parameters[2].ParameterType.GetGenericArguments();
			Type type2 = typeof(CustomDictionary<, >).MakeGenericType(parameters[0].ParameterType, parameters[2].ParameterType);
			reducer = Activator.CreateInstance(type);
			dictRed = (IDictionary)Activator.CreateInstance(type2);
		}
	}

	internal IDictionary ExecuteMapReduce<MK, MV, NK, NV, RNV>(IEnumerable input, Mapper<MK, MV, NK, NV> mapper, Reducer<NK, NV, RNV> reducer, CircularArray<NK, NV> dictMap, IDictionary<NK, RNV> dictRed, bool executeMap, bool executeReduce) where MK : class
	{
		if (executeMap && mapper != null)
		{
			Map(input, mapper, dictMap);
		}
		if (executeReduce && reducer != null)
		{
			Reduce(reducer, dictMap, dictRed);
		}
		return dictRed as IDictionary;
	}

	private void Map<MK, MV, NK, NV>(IEnumerable input, Mapper<MK, MV, NK, NV> mapper, CircularArray<NK, NV> dictMap) where MK : class
	{
		mapper.Parameters = Parameters;
		InputPlugin<MV> inputPlugin = null;
		if (Input != null)
		{
			inputPlugin = Input.GetPlugin() as InputPlugin<MV>;
			inputPlugin.Open();
			input = inputPlugin.Read();
			inputPlugin.StatusUpdate += method_0;
		}
		if (input == null)
		{
			dictMap.MapInProgress = false;
			throw new ArgumentException("Empty data source");
		}
		bool flag = input is IDictionary;
		uint num = 0u;
		foreach (object item in input)
		{
			while (PartialSaveInProgress)
			{
				Thread.Sleep(100);
			}
			if (++num % ReportEveryNth == 0)
			{
				method_0(UpdateType.Map, this, num);
			}
			MK key;
			MV value;
			if (!flag)
			{
				key = null;
				value = (MV)item;
			}
			else
			{
				KeyValuePair<MK, MV> keyValuePair = (KeyValuePair<MK, MV>)item;
				key = keyValuePair.Key;
				value = keyValuePair.Value;
			}
			if (inputPlugin != null)
			{
				mapper.Context.Position = inputPlugin.Position;
				mapper.Context.Location = inputPlugin.Location;
			}
			mapper.Map(key, value, dictMap);
		}
		dictMap.MapInProgress = false;
		inputPlugin?.Close();
	}

	private void Reduce<NK, NV, RNV>(Reducer<NK, NV, RNV> reducer, CircularArray<NK, NV> dictMap, IDictionary<NK, RNV> dictRed)
	{
		reducer.Parameters = Parameters;
		while (dictMap.MapInProgress || dictMap.HasNext)
		{
			while (PartialSaveInProgress)
			{
				Thread.Sleep(100);
			}
			if (!dictMap.Pop(out var key, out var value))
			{
				Thread.Sleep(1);
				continue;
			}
			int pos = ((CustomDictionary<NK, RNV>)dictRed).InitOrGetPosition(key);
			RNV atPosition = ((CustomDictionary<NK, RNV>)dictRed).GetAtPosition(pos);
			RNV value2 = reducer.Reduce(key, value, atPosition);
			((CustomDictionary<NK, RNV>)dictRed).StoreAtPosition(pos, value2);
		}
		reducer.BeforeSave(dictRed);
	}

	internal void SetStopWatch(Stopwatch sw)
	{
		stopwatch_0 = sw;
	}

	internal void MergeDictionaries<K, V, NV>(Reducer<K, V, NV> reducer, IDictionary from)
	{
		if (from.GetType() != ReduceResult.GetType())
		{
			return;
		}
		foreach (KeyValuePair<K, NV> item in (IDictionary<K, NV>)from)
		{
			if (item.Value is IEnumerable)
			{
				foreach (object item2 in item.Value as IEnumerable)
				{
					int pos = ((CustomDictionary<K, NV>)ReduceResult).InitOrGetPosition(item.Key);
					NV atPosition = ((CustomDictionary<K, NV>)ReduceResult).GetAtPosition(pos);
					NV value = reducer.Reduce(item.Key, (V)item2, atPosition);
					((CustomDictionary<K, NV>)ReduceResult).StoreAtPosition(pos, value);
				}
			}
			else
			{
				int pos2 = ((CustomDictionary<K, NV>)ReduceResult).InitOrGetPosition(item.Key);
				NV atPosition2 = ((CustomDictionary<K, NV>)ReduceResult).GetAtPosition(pos2);
				NV value2 = reducer.Reduce(item.Key, (V)(object)item.Value, atPosition2);
				((CustomDictionary<K, NV>)ReduceResult).StoreAtPosition(pos2, value2);
			}
		}
		from.Clear();
	}

	private void method_0(UpdateType updateType_0, IUpdateSource iupdateSource_0, uint uint_0)
	{
		if (stopwatch_0 != null)
		{
			if (long_0 == 0L)
			{
				long_0 = stopwatch_0.ElapsedMilliseconds;
			}
			else if (stopwatch_0.ElapsedMilliseconds - long_0 < 800L)
			{
				iupdateSource_0.ReportEveryNth *= 2u;
			}
			else if (stopwatch_0.ElapsedMilliseconds - long_0 > 1200L)
			{
				iupdateSource_0.ReportEveryNth = (uint)((float)iupdateSource_0.ReportEveryNth / 1.5f);
			}
			long_0 = stopwatch_0.ElapsedMilliseconds;
			if (statusDelegate_0 != null)
			{
				statusDelegate_0(updateType_0, iupdateSource_0, uint_0);
			}
		}
	}

	static MapReduceTask()
	{
		Class72.smethod_20();
	}
}
