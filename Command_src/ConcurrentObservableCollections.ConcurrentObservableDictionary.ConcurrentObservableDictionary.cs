using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Collections.Pooled;

namespace ConcurrentObservableCollections.ConcurrentObservableDictionary;

public class ConcurrentObservableDictionary<TKey, TValue> : ConcurrentDictionary<TKey, TValue>
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public ConcurrentObservableDictionary<TKey, TValue> concurrentObservableDictionary_0;

		public DictionaryChangedEventArgs<TKey, TValue> dictionaryChangedEventArgs_0;

		internal static object object_0;

		internal void RggYeYnvvyB()
		{
			concurrentObservableDictionary_0.eventHandler_0?.Invoke(concurrentObservableDictionary_0, dictionaryChangedEventArgs_0);
		}

		internal Task method_0(GInterface10<TKey, TValue> o)
		{
			return Task.Run((Action)new <>c__DisplayClass3_1
			{
				<>c__DisplayClass3_0_0 = this,
				ginterface10_0 = o
			}.method_0);
		}

		static <>c__DisplayClass3_0()
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

	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_1
	{
		public GInterface10<TKey, TValue> ginterface10_0;

		public <>c__DisplayClass3_0 <>c__DisplayClass3_0_0;

		internal static object object_0;

		internal void method_0()
		{
			ginterface10_0.OnEventOccur(<>c__DisplayClass3_0_0.dictionaryChangedEventArgs_0);
		}

		static <>c__DisplayClass3_1()
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

	[CompilerGenerated]
	private EventHandler<DictionaryChangedEventArgs<TKey, TValue>> eventHandler_0;

	private readonly ConcurrentDictionary<TKey, ICollection<GInterface10<TKey, TValue>>> concurrentDictionary_0 = new ConcurrentDictionary<TKey, ICollection<GInterface10<TKey, TValue>>>();

	internal static object object_0;

	public event EventHandler<DictionaryChangedEventArgs<TKey, TValue>> CollectionChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<DictionaryChangedEventArgs<TKey, TValue>> eventHandler = eventHandler_0;
			EventHandler<DictionaryChangedEventArgs<TKey, TValue>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DictionaryChangedEventArgs<TKey, TValue>> value2 = (EventHandler<DictionaryChangedEventArgs<TKey, TValue>>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<DictionaryChangedEventArgs<TKey, TValue>> eventHandler = eventHandler_0;
			EventHandler<DictionaryChangedEventArgs<TKey, TValue>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DictionaryChangedEventArgs<TKey, TValue>> value2 = (EventHandler<DictionaryChangedEventArgs<TKey, TValue>>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	protected virtual void OnCollectionChanged(DictionaryChangedEventArgs<TKey, TValue> changeAction)
	{
		PooledList<Task> pooledList = new PooledList<Task> { Task.Run(delegate
		{
			eventHandler_0?.Invoke(this, changeAction);
		}) };
		if (changeAction.Action != NotifyCollectionChangedAction.Reset && concurrentDictionary_0.TryGetValue(changeAction.Key, out var value))
		{
			<>c__DisplayClass3_0 CS$<>8__locals0;
			pooledList.AddRange(value.Select(delegate(GInterface10<TKey, TValue> o)
			{
				<>c__DisplayClass3_1 <>c__DisplayClass3_ = new <>c__DisplayClass3_1();
				<>c__DisplayClass3_.<>c__DisplayClass3_0_0 = CS$<>8__locals0;
				<>c__DisplayClass3_.ginterface10_0 = o;
				return Task.Run((Action)<>c__DisplayClass3_.method_0);
			}));
		}
		if (pooledList.Count > 0)
		{
			Task.WaitAll(pooledList.ToArray());
		}
		pooledList.Dispose();
	}

	public int Count_NoLock()
	{
		int num = 0;
		using IEnumerator<KeyValuePair<TKey, TValue>> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			_ = enumerator.Current;
			num++;
		}
		return num;
	}

	protected void OnCollectionChanged(NotifyCollectionChangedAction action, TKey key, TValue newValue, TValue oldValue)
	{
		OnCollectionChanged(new DictionaryChangedEventArgs<TKey, TValue>(action, key, newValue, oldValue));
	}

	protected void OnCollectionChanged(NotifyCollectionChangedAction action, TKey key, TValue value)
	{
		TValue newValue = default(TValue);
		TValue oldValue = default(TValue);
		switch (action)
		{
		default:
			return;
		case NotifyCollectionChangedAction.Remove:
			oldValue = value;
			break;
		case NotifyCollectionChangedAction.Add:
			newValue = value;
			break;
		}
		OnCollectionChanged(action, key, newValue, oldValue);
	}

	public ConcurrentObservableDictionary()
	{
	}

	public ConcurrentObservableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
		: base(collection)
	{
	}

	public ConcurrentObservableDictionary(IEqualityComparer<TKey> comparer)
		: base(comparer)
	{
	}

	public ConcurrentObservableDictionary(int concurrencyLevel, int capacity)
		: base(concurrencyLevel, capacity)
	{
	}

	public ConcurrentObservableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer)
		: base(collection, comparer)
	{
	}

	public ConcurrentObservableDictionary(int concurrencyLevel, int capacity, IEqualityComparer<TKey> comparer)
		: base(concurrencyLevel, capacity, comparer)
	{
	}

	public ConcurrentObservableDictionary(int concurrencyLevel, IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer)
		: base(concurrencyLevel, collection, comparer)
	{
	}

	public new void Clear()
	{
		base.Clear();
		OnCollectionChanged(new DictionaryChangedEventArgs<TKey, TValue>(NotifyCollectionChangedAction.Reset));
	}

	public new TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory)
	{
		bool bool_0 = false;
		TValue gparam_0 = default(TValue);
		TValue val = base.AddOrUpdate(key, addValue, (Func<TKey, TValue, TValue>)delegate(TKey k, TValue v)
		{
			bool_0 = true;
			gparam_0 = v;
			return updateValueFactory(k, v);
		});
		if (bool_0 && !val.Equals(gparam_0))
		{
			OnCollectionChanged(NotifyCollectionChangedAction.Replace, key, val, gparam_0);
		}
		else if (!bool_0)
		{
			OnCollectionChanged(NotifyCollectionChangedAction.Add, key, val);
		}
		return val;
	}

	public new TValue AddOrUpdate(TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
	{
		bool bool_0 = false;
		TValue gparam_0 = default(TValue);
		TValue val = base.AddOrUpdate(key, addValueFactory, (Func<TKey, TValue, TValue>)delegate(TKey k, TValue v)
		{
			bool_0 = true;
			gparam_0 = v;
			return updateValueFactory(k, v);
		});
		if (bool_0 && !val.Equals(gparam_0))
		{
			OnCollectionChanged(NotifyCollectionChangedAction.Replace, key, val, gparam_0);
		}
		else if (!bool_0)
		{
			OnCollectionChanged(NotifyCollectionChangedAction.Add, key, val);
		}
		return val;
	}

	public bool HasElements()
	{
		using (IEnumerator<KeyValuePair<TKey, TValue>> enumerator = GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				_ = enumerator.Current;
				return true;
			}
		}
		return false;
	}

	public TValue AddOrUpdate(TKey key, TValue value)
	{
		return AddOrUpdate(key, value, (TKey k, TValue v) => value);
	}

	public new TValue GetOrAdd(TKey key, TValue value)
	{
		return GetOrAdd(key, (TKey k) => value);
	}

	public new TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
	{
		bool bool_0 = false;
		TValue orAdd = base.GetOrAdd(key, (Func<TKey, TValue>)delegate(TKey k)
		{
			bool_0 = true;
			return valueFactory(k);
		});
		if (bool_0)
		{
			OnCollectionChanged(NotifyCollectionChangedAction.Add, key, orAdd);
		}
		return orAdd;
	}

	public new bool TryAdd(TKey key, TValue value)
	{
		bool num = base.TryAdd(key, value);
		if (num)
		{
			OnCollectionChanged(NotifyCollectionChangedAction.Add, key, value);
		}
		return num;
	}

	public new bool TryRemove(TKey key, out TValue value)
	{
		bool num = base.TryRemove(key, out value);
		if (num)
		{
			OnCollectionChanged(NotifyCollectionChangedAction.Remove, key, value);
		}
		return num;
	}

	public new bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue)
	{
		bool num = base.TryUpdate(key, newValue, comparisonValue);
		if (num)
		{
			OnCollectionChanged(NotifyCollectionChangedAction.Replace, key, newValue, comparisonValue);
		}
		return num;
	}

	public Dictionary<TKey, HashSet<GInterface10<TKey, TValue>>> AddPartialObserver(GInterface10<TKey, TValue> observer, params TKey[] keys)
	{
		if (observer != null)
		{
			if (keys == null)
			{
				throw new ArgumentNullException("keys");
			}
			foreach (TKey key in keys)
			{
				concurrentDictionary_0.AddOrUpdate(key, new HashSet<GInterface10<TKey, TValue>> { observer }, delegate(TKey k, ICollection<GInterface10<TKey, TValue>> o)
				{
					o.Add(observer);
					return o;
				});
			}
			return keys.ToDictionary((TKey k) => k, (TKey k) => new HashSet<GInterface10<TKey, TValue>> { observer });
		}
		throw new ArgumentNullException("observer");
	}

	public Dictionary<TKey, HashSet<GInterface10<TKey, TValue>>> AddPartialObserver(Action<DictionaryChangedEventArgs<TKey, TValue>> action, params TKey[] keys)
	{
		return AddPartialObserver(new SimpleActionDictionaryObserver<TKey, TValue>(action), keys);
	}

	public Dictionary<TKey, HashSet<GInterface10<TKey, TValue>>> RemovePartialObserver(GInterface10<TKey, TValue> observer, params TKey[] keys)
	{
		if (observer == null)
		{
			throw new ArgumentNullException("observer");
		}
		if (keys == null)
		{
			throw new ArgumentNullException("keys");
		}
		ICollection<GInterface10<TKey, TValue>> value;
		return keys.Where((TKey key) => concurrentDictionary_0.TryGetValue(key, out value) && value.Contains(observer) && value.Remove(observer)).ToDictionary((TKey k) => k, (TKey k) => new HashSet<GInterface10<TKey, TValue>> { observer });
	}

	public Dictionary<TKey, HashSet<GInterface10<TKey, TValue>>> RemovePartialObserver(GInterface10<TKey, TValue> observer)
	{
		if (observer == null)
		{
			throw new ArgumentNullException("observer");
		}
		return (from pair in concurrentDictionary_0
			where pair.Value.Contains(observer) && pair.Value.Remove(observer)
			select pair.Key).ToDictionary((TKey k) => k, (TKey k) => new HashSet<GInterface10<TKey, TValue>> { observer });
	}

	public Dictionary<TKey, HashSet<GInterface10<TKey, TValue>>> RemovePartialObserver(params TKey[] keys)
	{
		if (keys == null)
		{
			throw new ArgumentNullException("keys");
		}
		ICollection<GInterface10<TKey, TValue>> value;
		return (from gparam_0 in keys
			select (concurrentDictionary_0.ContainsKey(gparam_0) && concurrentDictionary_0.TryRemove(gparam_0, out value)) ? new KeyValuePair<TKey, HashSet<GInterface10<TKey, TValue>>>(gparam_0, new HashSet<GInterface10<TKey, TValue>>(value)) : new KeyValuePair<TKey, HashSet<GInterface10<TKey, TValue>>>(gparam_0, null) into pair
			where pair.Value != null
			select pair).ToDictionary((KeyValuePair<TKey, HashSet<GInterface10<TKey, TValue>>> pair) => pair.Key, (KeyValuePair<TKey, HashSet<GInterface10<TKey, TValue>>> pair) => pair.Value);
	}

	public Dictionary<TKey, HashSet<GInterface10<TKey, TValue>>> RemoveAllObservers()
	{
		Dictionary<TKey, HashSet<GInterface10<TKey, TValue>>> result = concurrentDictionary_0.ToDictionary((KeyValuePair<TKey, ICollection<GInterface10<TKey, TValue>>> kv) => kv.Key, (KeyValuePair<TKey, ICollection<GInterface10<TKey, TValue>>> kv) => new HashSet<GInterface10<TKey, TValue>>(kv.Value));
		concurrentDictionary_0.Clear();
		return result;
	}

	[CompilerGenerated]
	private KeyValuePair<TKey, HashSet<GInterface10<TKey, TValue>>> method_0(TKey gparam_0)
	{
		if (concurrentDictionary_0.ContainsKey(gparam_0) && concurrentDictionary_0.TryRemove(gparam_0, out var value))
		{
			return new KeyValuePair<TKey, HashSet<GInterface10<TKey, TValue>>>(gparam_0, new HashSet<GInterface10<TKey, TValue>>(value));
		}
		return new KeyValuePair<TKey, HashSet<GInterface10<TKey, TValue>>>(gparam_0, null);
	}

	static ConcurrentObservableDictionary()
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
