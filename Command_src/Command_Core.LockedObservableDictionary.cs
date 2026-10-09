using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class LockedObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>
{
	public delegate void DictionaryChangingEventHandler();

	[AccessedThroughProperty("_dictionary")]
	[CompilerGenerated]
	private ObservableDictionary<TKey, TValue> observableDictionary_0;

	private readonly ReaderWriterLockSlim readerWriterLockSlim_0;

	[CompilerGenerated]
	private DictionaryChangingEventHandler dictionaryChangingEventHandler_0;

	public int Count;

	internal static object object_0;

	private virtual ObservableDictionary<TKey, TValue> _dictionary
	{
		[CompilerGenerated]
		get
		{
			return observableDictionary_0;
		}
		[CompilerGenerated]
		set
		{
			INotifyDictionaryChanged<TKey, TValue>.DictionaryChangedEventHandler obj = method_0;
			ObservableDictionary<TKey, TValue> observableDictionary = observableDictionary_0;
			if (observableDictionary != null)
			{
				observableDictionary.DictionaryChanged -= obj;
			}
			observableDictionary_0 = value;
			observableDictionary = observableDictionary_0;
			if (observableDictionary != null)
			{
				observableDictionary.DictionaryChanged += obj;
			}
		}
	}

	public TValue this[TKey key]
	{
		get
		{
			return _dictionary[key];
		}
		set
		{
			readerWriterLockSlim_0.EnterWriteLock();
			try
			{
				_dictionary[key] = value;
			}
			finally
			{
				readerWriterLockSlim_0.ExitWriteLock();
			}
		}
	}

	public ICollection<TKey> Keys => _dictionary.Keys;

	public ICollection<TValue> Values => _dictionary.Values;

	int ICollection<KeyValuePair<TKey, TValue>>._Count => _dictionary.Count;

	public bool IsReadOnly => _dictionary.IsReadOnly;

	public event DictionaryChangingEventHandler DictionaryChanging
	{
		[CompilerGenerated]
		add
		{
			DictionaryChangingEventHandler dictionaryChangingEventHandler = dictionaryChangingEventHandler_0;
			DictionaryChangingEventHandler dictionaryChangingEventHandler2;
			do
			{
				dictionaryChangingEventHandler2 = dictionaryChangingEventHandler;
				DictionaryChangingEventHandler value2 = (DictionaryChangingEventHandler)Delegate.Combine(dictionaryChangingEventHandler2, value);
				dictionaryChangingEventHandler = Interlocked.CompareExchange(ref dictionaryChangingEventHandler_0, value2, dictionaryChangingEventHandler2);
			}
			while ((object)dictionaryChangingEventHandler != dictionaryChangingEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DictionaryChangingEventHandler dictionaryChangingEventHandler = dictionaryChangingEventHandler_0;
			DictionaryChangingEventHandler dictionaryChangingEventHandler2;
			do
			{
				dictionaryChangingEventHandler2 = dictionaryChangingEventHandler;
				DictionaryChangingEventHandler value2 = (DictionaryChangingEventHandler)Delegate.Remove(dictionaryChangingEventHandler2, value);
				dictionaryChangingEventHandler = Interlocked.CompareExchange(ref dictionaryChangingEventHandler_0, value2, dictionaryChangingEventHandler2);
			}
			while ((object)dictionaryChangingEventHandler != dictionaryChangingEventHandler2);
		}
	}

	public LockedObservableDictionary()
	{
		_dictionary = new ObservableDictionary<TKey, TValue>();
		readerWriterLockSlim_0 = new ReaderWriterLockSlim();
	}

	public bool IsEmpty()
	{
		return Count == 0;
	}

	private void method_0(object sender, NotifyDictionaryChangedEventArgs<TKey, TValue> e)
	{
		Count = _dictionary.Count;
		dictionaryChangingEventHandler_0?.Invoke();
	}

	public bool ContainsKey(TKey key)
	{
		return _dictionary.ContainsKey(key);
	}

	public void Add(TKey key, TValue value)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			if (!_dictionary.ContainsKey(key))
			{
				_dictionary.Add(key, value);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	private bool Remove(TKey key)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			return _dictionary.Remove(key);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	bool IDictionary<TKey, TValue>.Remove(TKey key)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Remove
		return this.Remove(key);
	}

	public bool TryGetValue(TKey key, ref TValue value)
	{
		return _dictionary.TryGetValue(key, ref value);
	}

	public void Add(KeyValuePair<TKey, TValue> item)
	{
		((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).Add(item);
	}

	public void Clear()
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			_dictionary.Clear();
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public bool Contains(KeyValuePair<TKey, TValue> item)
	{
		return _dictionary.Contains(item);
	}

	public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
	{
		_dictionary.CopyTo(array, arrayIndex);
	}

	public bool Remove(KeyValuePair<TKey, TValue> item)
	{
		return ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).Remove(item);
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		return ((IEnumerable<KeyValuePair<TKey, TValue>>)_dictionary).GetEnumerator();
	}

	private IEnumerator IEnumerable_GetEnumerator()
	{
		return ((IEnumerable)_dictionary).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in IEnumerable_GetEnumerator
		return this.IEnumerable_GetEnumerator();
	}

	static LockedObservableDictionary()
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
