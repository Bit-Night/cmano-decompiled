using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ThreadSafeCollections;

public class TObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, INotifyCollectionChanged
{
	private bool bool_0 = true;

	private readonly ReaderWriterLockSlim readerWriterLockSlim_0 = new ReaderWriterLockSlim();

	private readonly Dictionary<TKey, TValue> dictionary_0;

	[CompilerGenerated]
	private NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler_0;

	private static object object_0;

	public ICollection<TKey> Keys
	{
		get
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.EnterReadLock();
				try
				{
					return dictionary_0.Keys.ToList();
				}
				finally
				{
					readerWriterLockSlim_0.ExitReadLock();
				}
			}
			return dictionary_0.Keys;
		}
	}

	public ICollection<TValue> Values
	{
		get
		{
			if (!bool_0)
			{
				return dictionary_0.Values;
			}
			readerWriterLockSlim_0.EnterReadLock();
			try
			{
				return dictionary_0.Values.ToList();
			}
			finally
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public TValue this[TKey key]
	{
		get
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.EnterReadLock();
				try
				{
					return dictionary_0[key];
				}
				finally
				{
					readerWriterLockSlim_0.ExitReadLock();
				}
			}
			return dictionary_0[key];
		}
		set
		{
			readerWriterLockSlim_0.EnterWriteLock();
			NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs_;
			try
			{
				if (dictionary_0.ContainsKey(key))
				{
					TValue value2 = dictionary_0[key];
					dictionary_0[key] = value;
					notifyCollectionChangedEventArgs_ = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, value), new KeyValuePair<TKey, TValue>(key, value2));
				}
				else
				{
					dictionary_0[key] = value;
					notifyCollectionChangedEventArgs_ = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
				}
			}
			finally
			{
				readerWriterLockSlim_0.ExitWriteLock();
			}
			ryMywSmbbwj(notifyCollectionChangedEventArgs_);
		}
	}

	public int Count
	{
		get
		{
			if (!bool_0)
			{
				return dictionary_0.Count;
			}
			readerWriterLockSlim_0.EnterReadLock();
			try
			{
				return dictionary_0.Count;
			}
			finally
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public bool IsReadOnly => false;

	public event NotifyCollectionChangedEventHandler CollectionChanged
	{
		[CompilerGenerated]
		add
		{
			NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = notifyCollectionChangedEventHandler_0;
			NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler2;
			do
			{
				notifyCollectionChangedEventHandler2 = notifyCollectionChangedEventHandler;
				NotifyCollectionChangedEventHandler value2 = (NotifyCollectionChangedEventHandler)Delegate.Combine(notifyCollectionChangedEventHandler2, value);
				notifyCollectionChangedEventHandler = Interlocked.CompareExchange(ref notifyCollectionChangedEventHandler_0, value2, notifyCollectionChangedEventHandler2);
			}
			while ((object)notifyCollectionChangedEventHandler != notifyCollectionChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = notifyCollectionChangedEventHandler_0;
			NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler2;
			do
			{
				notifyCollectionChangedEventHandler2 = notifyCollectionChangedEventHandler;
				NotifyCollectionChangedEventHandler value2 = (NotifyCollectionChangedEventHandler)Delegate.Remove(notifyCollectionChangedEventHandler2, value);
				notifyCollectionChangedEventHandler = Interlocked.CompareExchange(ref notifyCollectionChangedEventHandler_0, value2, notifyCollectionChangedEventHandler2);
			}
			while ((object)notifyCollectionChangedEventHandler != notifyCollectionChangedEventHandler2);
		}
	}

	public TObservableDictionary(bool useReadLock = false)
	{
		dictionary_0 = new Dictionary<TKey, TValue>();
		bool_0 = useReadLock;
	}

	public TObservableDictionary(int capacity, bool useReadLock = false)
	{
		dictionary_0 = new Dictionary<TKey, TValue>(capacity);
		bool_0 = useReadLock;
	}

	public TObservableDictionary(IEqualityComparer<TKey> comparer, bool useReadLock = true)
	{
		dictionary_0 = new Dictionary<TKey, TValue>(comparer);
		bool_0 = useReadLock;
	}

	public TObservableDictionary(IDictionary<TKey, TValue> dictionary, bool useReadLock = true)
	{
		dictionary_0 = new Dictionary<TKey, TValue>(dictionary);
		bool_0 = useReadLock;
	}

	public TObservableDictionary(int capacity, IEqualityComparer<TKey> comparer, bool useReadLock = true)
	{
		dictionary_0 = new Dictionary<TKey, TValue>(capacity, comparer);
		bool_0 = useReadLock;
	}

	public TObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer, bool useReadLock = true)
	{
		dictionary_0 = new Dictionary<TKey, TValue>(dictionary, comparer);
		bool_0 = useReadLock;
	}

	private void ryMywSmbbwj(NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs_0)
	{
		notifyCollectionChangedEventHandler_0?.Invoke(this, notifyCollectionChangedEventArgs_0);
	}

	public TValue GetValueAddIfNotExist(TKey key, Func<TValue> func)
	{
		TValue value = default(TValue);
		bool flag = false;
		readerWriterLockSlim_0.EnterUpgradeableReadLock();
		try
		{
			if (dictionary_0.TryGetValue(key, out value))
			{
				return value;
			}
			readerWriterLockSlim_0.EnterWriteLock();
			try
			{
				value = func();
				dictionary_0.Add(key, value);
				flag = true;
			}
			finally
			{
				readerWriterLockSlim_0.ExitWriteLock();
			}
		}
		finally
		{
			readerWriterLockSlim_0.ExitUpgradeableReadLock();
		}
		if (flag)
		{
			ryMywSmbbwj(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value)));
		}
		return value;
	}

	public void Add(TKey key, TValue value)
	{
		NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs_ = null;
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			dictionary_0.Add(key, value);
			notifyCollectionChangedEventArgs_ = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
		ryMywSmbbwj(notifyCollectionChangedEventArgs_);
	}

	public void Add(KeyValuePair<TKey, TValue> item)
	{
		Add(item.Key, item.Value);
	}

	public bool AddIfNotExists(TKey key, TValue value)
	{
		bool result = false;
		NotifyCollectionChangedEventArgs e = null;
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			if (!dictionary_0.ContainsKey(key))
			{
				dictionary_0.Add(key, value);
				result = true;
				e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
			}
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
		if (e != null)
		{
			ryMywSmbbwj(e);
		}
		return result;
	}

	public void AddIfNotExists(IEnumerable<TKey> keys, TValue defaultValue)
	{
		List<KeyValuePair<TKey, TValue>> list = new List<KeyValuePair<TKey, TValue>>();
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			foreach (TKey key in keys)
			{
				if (!dictionary_0.ContainsKey(key))
				{
					dictionary_0.Add(key, defaultValue);
					list.Add(new KeyValuePair<TKey, TValue>(key, defaultValue));
				}
			}
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
		foreach (KeyValuePair<TKey, TValue> item in list)
		{
			ryMywSmbbwj(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
		}
	}

	public bool AddIfNotExistsElseUpdate(TKey key, TValue value)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		bool result;
		NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs_;
		try
		{
			if (dictionary_0.TryGetValue(key, out var value2))
			{
				dictionary_0[key] = value;
				result = false;
				notifyCollectionChangedEventArgs_ = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, value), new KeyValuePair<TKey, TValue>(key, value2));
			}
			else
			{
				dictionary_0.Add(key, value);
				result = true;
				notifyCollectionChangedEventArgs_ = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
			}
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
		ryMywSmbbwj(notifyCollectionChangedEventArgs_);
		return result;
	}

	public bool UpdateValueIfKeyExists(TKey key, TValue NewValue)
	{
		bool result = false;
		NotifyCollectionChangedEventArgs e = null;
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			if (dictionary_0.ContainsKey(key))
			{
				TValue value = dictionary_0[key];
				dictionary_0[key] = NewValue;
				result = true;
				e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, NewValue), new KeyValuePair<TKey, TValue>(key, value));
			}
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
		if (e != null)
		{
			ryMywSmbbwj(e);
		}
		return result;
	}

	public bool Contains(KeyValuePair<TKey, TValue> item)
	{
		readerWriterLockSlim_0.EnterReadLock();
		try
		{
			return dictionary_0.ContainsKey(item.Key) && EqualityComparer<TValue>.Default.Equals(dictionary_0[item.Key], item.Value);
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
	}

	public bool ContainsKey(TKey key)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
			try
			{
				return dictionary_0.ContainsKey(key);
			}
			finally
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
		return dictionary_0.ContainsKey(key);
	}

	public bool ContainsValue(TValue value)
	{
		readerWriterLockSlim_0.EnterReadLock();
		try
		{
			return dictionary_0.ContainsValue(value);
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
	}

	public bool Remove(TKey key)
	{
		bool result = false;
		NotifyCollectionChangedEventArgs e = null;
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			if (dictionary_0.TryGetValue(key, out var value) && (result = dictionary_0.Remove(key)))
			{
				e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, new KeyValuePair<TKey, TValue>(key, value));
			}
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
		if (e != null)
		{
			ryMywSmbbwj(e);
		}
		return result;
	}

	public bool Remove(KeyValuePair<TKey, TValue> item)
	{
		bool result = false;
		NotifyCollectionChangedEventArgs e = null;
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			if (dictionary_0.TryGetValue(item.Key, out var value) && EqualityComparer<TValue>.Default.Equals(value, item.Value) && (result = dictionary_0.Remove(item.Key)))
			{
				e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item);
			}
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
		if (e != null)
		{
			ryMywSmbbwj(e);
		}
		return result;
	}

	public bool Remove(Predicate<TKey> predKey, Predicate<TValue> predValue)
	{
		List<KeyValuePair<TKey, TValue>> list = new List<KeyValuePair<TKey, TValue>>();
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			foreach (TKey item in dictionary_0.Keys.ToList())
			{
				bool flag = false;
				if (predKey != null && predKey(item))
				{
					flag = true;
				}
				if (!flag && predValue != null && predValue(dictionary_0[item]))
				{
					flag = true;
				}
				if (flag)
				{
					list.Add(new KeyValuePair<TKey, TValue>(item, dictionary_0[item]));
					dictionary_0.Remove(item);
				}
			}
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
		foreach (KeyValuePair<TKey, TValue> item2 in list)
		{
			ryMywSmbbwj(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item2));
		}
		return true;
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
			try
			{
				return dictionary_0.TryGetValue(key, out value);
			}
			finally
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
		return dictionary_0.TryGetValue(key, out value);
	}

	public void Clear()
	{
		bool flag = false;
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			if (dictionary_0.Count > 0)
			{
				flag = true;
				dictionary_0.Clear();
			}
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
		if (flag)
		{
			ryMywSmbbwj(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}
	}

	public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
	{
		readerWriterLockSlim_0.EnterReadLock();
		try
		{
			dictionary_0.ToArray().CopyTo(array, arrayIndex);
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		if (!bool_0)
		{
			return dictionary_0.GetEnumerator();
		}
		readerWriterLockSlim_0.EnterReadLock();
		KeyValuePair<TKey, TValue>[] array;
		try
		{
			array = dictionary_0.ToArray();
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
		return ((IEnumerable<KeyValuePair<TKey, TValue>>)array).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	static TObservableDictionary()
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
