using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ObservableCollections;

public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, INotifyPropertyChanged where TKey : notnull
{
	private readonly Dictionary<TKey, TValue> dictionary_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler? propertyChangedEventHandler_0;

	[CompilerGenerated]
	private EventHandler<DictionaryChangedEventArgs<TKey, TValue>>? tddewMbNob8;

	private static object object_0;

	public TValue this[TKey key]
	{
		get
		{
			if (dictionary_0.TryGetValue(key, out var value))
			{
				return value;
			}
			return default(TValue);
		}
		set
		{
			if (dictionary_0.TryGetValue(key, out var value2))
			{
				if (!EqualityComparer<TValue>.Default.Equals(value2, value))
				{
					dictionary_0[key] = value;
					OnDictionaryChanged(NotifyCollectionChangedAction.Replace, key, value2, value);
				}
			}
			else
			{
				dictionary_0[key] = value;
				OnPropertyChanged("Count");
				OnDictionaryChanged(NotifyCollectionChangedAction.Add, key, default(TValue), value);
			}
		}
	}

	public ICollection<TKey> Keys => dictionary_0.Keys;

	IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => dictionary_0.Keys;

	public ICollection<TValue> Values => dictionary_0.Values;

	IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => dictionary_0.Values;

	public int Count => dictionary_0.Count;

	public bool IsReadOnly => false;

	public event PropertyChangedEventHandler? PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public event EventHandler<DictionaryChangedEventArgs<TKey, TValue>>? DictionaryChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<DictionaryChangedEventArgs<TKey, TValue>> eventHandler = tddewMbNob8;
			EventHandler<DictionaryChangedEventArgs<TKey, TValue>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DictionaryChangedEventArgs<TKey, TValue>> value2 = (EventHandler<DictionaryChangedEventArgs<TKey, TValue>>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref tddewMbNob8, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<DictionaryChangedEventArgs<TKey, TValue>> eventHandler = tddewMbNob8;
			EventHandler<DictionaryChangedEventArgs<TKey, TValue>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DictionaryChangedEventArgs<TKey, TValue>> value2 = (EventHandler<DictionaryChangedEventArgs<TKey, TValue>>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref tddewMbNob8, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public ObservableDictionary()
	{
		dictionary_0 = new Dictionary<TKey, TValue>();
	}

	public ObservableDictionary(IEqualityComparer<TKey>? comparer)
	{
		dictionary_0 = new Dictionary<TKey, TValue>(comparer);
	}

	public void Add(TKey key, TValue value)
	{
		dictionary_0.Add(key, value);
		OnPropertyChanged("Count");
		OnDictionaryChanged(NotifyCollectionChangedAction.Add, key, default(TValue), value);
	}

	public bool Remove(TKey key)
	{
		if (!dictionary_0.TryGetValue(key, out var value))
		{
			return false;
		}
		bool num = dictionary_0.Remove(key);
		if (num)
		{
			OnPropertyChanged("Count");
			OnDictionaryChanged(NotifyCollectionChangedAction.Remove, key, value);
		}
		return num;
	}

	public void Clear()
	{
		if (dictionary_0.Count != 0)
		{
			KeyValuePair<TKey, TValue>[] array = dictionary_0.ToArray();
			dictionary_0.Clear();
			OnPropertyChanged("Count");
			IReadOnlyCollection<KeyValuePair<TKey, TValue>> items = (IReadOnlyCollection<KeyValuePair<TKey, TValue>>)(object)array;
			OnDictionaryChanged(NotifyCollectionChangedAction.Reset, default(TKey), default(TValue), default(TValue), items);
		}
	}

	public bool ContainsKey(TKey key)
	{
		return dictionary_0.ContainsKey(key);
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		return dictionary_0.TryGetValue(key, out value);
	}

	public void Add(KeyValuePair<TKey, TValue> item)
	{
		Add(item.Key, item.Value);
	}

	public bool Contains(KeyValuePair<TKey, TValue> item)
	{
		return ((ICollection<KeyValuePair<TKey, TValue>>)dictionary_0).Contains(item);
	}

	public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
	{
		((ICollection<KeyValuePair<TKey, TValue>>)dictionary_0).CopyTo(array, arrayIndex);
	}

	public bool Remove(KeyValuePair<TKey, TValue> item)
	{
		if (Contains(item))
		{
			return Remove(item.Key);
		}
		return false;
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		return dictionary_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	protected virtual void OnDictionaryChanged(NotifyCollectionChangedAction action, TKey? key = default(TKey?), TValue? oldValue = default(TValue?), TValue? newValue = default(TValue?), IReadOnlyCollection<KeyValuePair<TKey, TValue>>? items = null)
	{
		tddewMbNob8?.Invoke(this, new DictionaryChangedEventArgs<TKey, TValue>(action, key, oldValue, newValue, items));
	}

	static ObservableDictionary()
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
