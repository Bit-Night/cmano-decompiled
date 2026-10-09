using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ThreadSafeCollections;

public class TDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public TDictionary<TKey, TValue> tdictionary_0;

		public TKey gparam_0;

		public Func<TValue> func_0;

		internal static object object_0;

		internal TValue method_0()
		{
			<>c__DisplayClass9_1 <>c__DisplayClass9_ = new <>c__DisplayClass9_1
			{
				<>c__DisplayClass9_0_0 = this
			};
			if (tdictionary_0.dictionary_0.TryGetValue(gparam_0, out <>c__DisplayClass9_.gparam_0))
			{
				return <>c__DisplayClass9_.gparam_0;
			}
			ReadWriteLockSlimExtend.PerformUsingWriteLock(tdictionary_0.readerWriterLockSlim_0, (Func<TValue>)<>c__DisplayClass9_.method_0);
			return <>c__DisplayClass9_.gparam_0;
		}

		static <>c__DisplayClass9_0()
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
	private sealed class <>c__DisplayClass9_1
	{
		public TValue gparam_0;

		public <>c__DisplayClass9_0 <>c__DisplayClass9_0_0;

		private static object object_0;

		internal TValue method_0()
		{
			gparam_0 = <>c__DisplayClass9_0_0.func_0();
			<>c__DisplayClass9_0_0.tdictionary_0.dictionary_0.Add(<>c__DisplayClass9_0_0.gparam_0, gparam_0);
			return gparam_0;
		}

		static <>c__DisplayClass9_1()
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

	private bool VrHyqJabhaF = true;

	private readonly ReaderWriterLockSlim readerWriterLockSlim_0 = new ReaderWriterLockSlim();

	private readonly Dictionary<TKey, TValue> dictionary_0;

	internal static object object_0;

	public ICollection<TKey> Keys
	{
		get
		{
			if (VrHyqJabhaF)
			{
				if (VrHyqJabhaF)
				{
					readerWriterLockSlim_0.EnterReadLock();
				}
				try
				{
					return dictionary_0.Keys;
				}
				finally
				{
					if (VrHyqJabhaF)
					{
						readerWriterLockSlim_0.ExitReadLock();
					}
				}
			}
			return dictionary_0.Keys;
		}
	}

	public ICollection<TValue> Values
	{
		get
		{
			if (!VrHyqJabhaF)
			{
				return dictionary_0.Values;
			}
			if (VrHyqJabhaF)
			{
				readerWriterLockSlim_0.EnterReadLock();
			}
			try
			{
				return dictionary_0.Values;
			}
			finally
			{
				if (VrHyqJabhaF)
				{
					readerWriterLockSlim_0.ExitReadLock();
				}
			}
		}
	}

	public TValue this[TKey key]
	{
		get
		{
			if (VrHyqJabhaF)
			{
				return ReadWriteLockSlimExtend.PerformUsingReadLock(readerWriterLockSlim_0, () => dictionary_0[key]);
			}
			return dictionary_0[key];
		}
		set
		{
			ReadWriteLockSlimExtend.PerformUsingWriteLock(readerWriterLockSlim_0, () => dictionary_0[key] = value);
		}
	}

	public int Count
	{
		get
		{
			if (VrHyqJabhaF)
			{
				return ReadWriteLockSlimExtend.PerformUsingReadLock(readerWriterLockSlim_0, () => dictionary_0.Count);
			}
			return dictionary_0.Count;
		}
	}

	public bool IsReadOnly => false;

	public TDictionary(bool useReadLock = false)
	{
		dictionary_0 = new Dictionary<TKey, TValue>();
		VrHyqJabhaF = useReadLock;
	}

	public TDictionary(int capacity, bool useReadLock = false)
	{
		dictionary_0 = new Dictionary<TKey, TValue>(capacity);
		VrHyqJabhaF = useReadLock;
	}

	public TDictionary(IEqualityComparer<TKey> comparer, bool useReadLock = true)
	{
		dictionary_0 = new Dictionary<TKey, TValue>(comparer);
		VrHyqJabhaF = useReadLock;
	}

	public TDictionary(IDictionary<TKey, TValue> dictionary, bool useReadLock = true)
	{
		dictionary_0 = new Dictionary<TKey, TValue>(dictionary);
		VrHyqJabhaF = useReadLock;
	}

	public TDictionary(int capacity, IEqualityComparer<TKey> comparer, bool useReadLock = true)
	{
		dictionary_0 = new Dictionary<TKey, TValue>(capacity, comparer);
		VrHyqJabhaF = useReadLock;
	}

	public TDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer, bool useReadLock = true)
	{
		dictionary_0 = new Dictionary<TKey, TValue>(dictionary, comparer);
		VrHyqJabhaF = useReadLock;
	}

	public TValue GetValueAddIfNotExist(TKey key, Func<TValue> func)
	{
		<>c__DisplayClass9_0 CS$<>8__locals0;
		return ReadWriteLockSlimExtend.PerformUsingUpgradeableReadLock(readerWriterLockSlim_0, delegate
		{
			<>c__DisplayClass9_1 <>c__DisplayClass9_ = new <>c__DisplayClass9_1();
			<>c__DisplayClass9_.<>c__DisplayClass9_0_0 = CS$<>8__locals0;
			if (dictionary_0.TryGetValue(key, out <>c__DisplayClass9_.gparam_0))
			{
				return <>c__DisplayClass9_.gparam_0;
			}
			ReadWriteLockSlimExtend.PerformUsingWriteLock(readerWriterLockSlim_0, (Func<TValue>)<>c__DisplayClass9_.method_0);
			return <>c__DisplayClass9_.gparam_0;
		});
	}

	public void Add(TKey key, TValue value)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			dictionary_0.Add(key, value);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public void Add(KeyValuePair<TKey, TValue> item)
	{
		TKey key = item.Key;
		TValue value = item.Value;
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			dictionary_0.Add(key, value);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public bool AddIfNotExists(TKey key, TValue value)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			if (dictionary_0.ContainsKey(key))
			{
				return false;
			}
			dictionary_0.Add(key, value);
			return true;
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public void AddIfNotExists(IEnumerable<TKey> keys, TValue defaultValue)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			foreach (TKey key in keys)
			{
				if (!dictionary_0.ContainsKey(key))
				{
					dictionary_0.Add(key, defaultValue);
				}
			}
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public bool AddIfNotExistsElseUpdate(TKey key, TValue value)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			if (dictionary_0.TryGetValue(key, out var _))
			{
				dictionary_0[key] = value;
				return false;
			}
			dictionary_0.Add(key, value);
			return true;
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public bool UpdateValueIfKeyExists(TKey key, TValue NewValue)
	{
		bool bool_0 = false;
		ReadWriteLockSlimExtend.PerformUsingWriteLock(readerWriterLockSlim_0, delegate
		{
			if (dictionary_0.ContainsKey(key))
			{
				dictionary_0[key] = NewValue;
				bool_0 = true;
			}
		});
		return bool_0;
	}

	public bool Contains(KeyValuePair<TKey, TValue> item)
	{
		return ReadWriteLockSlimExtend.PerformUsingReadLock(readerWriterLockSlim_0, () => dictionary_0.ContainsKey(item.Key) && dictionary_0.ContainsValue(item.Value));
	}

	public bool ContainsKey(TKey key)
	{
		if (VrHyqJabhaF)
		{
			return ReadWriteLockSlimExtend.PerformUsingReadLock(readerWriterLockSlim_0, () => dictionary_0.ContainsKey(key));
		}
		return dictionary_0.ContainsKey(key);
	}

	public bool ContainsValue(TValue value)
	{
		return ReadWriteLockSlimExtend.PerformUsingReadLock(readerWriterLockSlim_0, () => dictionary_0.ContainsValue(value));
	}

	public bool Remove(TKey key)
	{
		return ReadWriteLockSlimExtend.PerformUsingWriteLock(readerWriterLockSlim_0, () => !dictionary_0.ContainsKey(key) || dictionary_0.Remove(key));
	}

	public bool Remove(KeyValuePair<TKey, TValue> item)
	{
		TValue value;
		return ReadWriteLockSlimExtend.PerformUsingWriteLock(readerWriterLockSlim_0, () => dictionary_0.TryGetValue(item.Key, out value) && value.Equals(item.Value) && dictionary_0.Remove(item.Key));
	}

	public bool Remove(Predicate<TKey> predKey, Predicate<TValue> predValue)
	{
		return ReadWriteLockSlimExtend.PerformUsingWriteLock(readerWriterLockSlim_0, delegate
		{
			if (dictionary_0.Keys.Count == 0)
			{
				return true;
			}
			List<TKey> list = new List<TKey>();
			foreach (TKey key in dictionary_0.Keys)
			{
				bool flag = false;
				if (predKey != null)
				{
					flag = predKey(key);
				}
				if (!flag && predValue != null && predValue(dictionary_0[key]))
				{
					flag = true;
				}
				if (flag)
				{
					list.Add(key);
				}
			}
			foreach (TKey item in list)
			{
				dictionary_0.Remove(item);
			}
			return true;
		});
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		if (VrHyqJabhaF)
		{
			if (VrHyqJabhaF)
			{
				readerWriterLockSlim_0.EnterReadLock();
			}
			try
			{
				return dictionary_0.TryGetValue(key, out value);
			}
			finally
			{
				if (VrHyqJabhaF)
				{
					readerWriterLockSlim_0.ExitReadLock();
				}
			}
		}
		return dictionary_0.TryGetValue(key, out value);
	}

	public void Clear()
	{
		ReadWriteLockSlimExtend.PerformUsingWriteLock(readerWriterLockSlim_0, delegate
		{
			dictionary_0.Clear();
		});
	}

	public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
	{
		ReadWriteLockSlimExtend.PerformUsingReadLock(readerWriterLockSlim_0, delegate
		{
			dictionary_0.ToArray().CopyTo(array, arrayIndex);
		});
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		if (VrHyqJabhaF)
		{
			Dictionary<TKey, TValue> dictionary_0 = null;
			ReadWriteLockSlimExtend.PerformUsingReadLock(readerWriterLockSlim_0, () => dictionary_0 = new Dictionary<TKey, TValue>(this.dictionary_0));
			return ((IEnumerable<KeyValuePair<TKey, TValue>>)dictionary_0).GetEnumerator();
		}
		return this.dictionary_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		Dictionary<TKey, TValue> dictionary_0 = null;
		ReadWriteLockSlimExtend.PerformUsingReadLock(readerWriterLockSlim_0, () => dictionary_0 = new Dictionary<TKey, TValue>(this.dictionary_0));
		return dictionary_0.GetEnumerator();
	}

	[CompilerGenerated]
	private void method_0()
	{
		dictionary_0.Clear();
	}

	[CompilerGenerated]
	private int method_1()
	{
		return dictionary_0.Count;
	}

	static TDictionary()
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
