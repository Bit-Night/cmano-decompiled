using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace ObservableCollections;

public class DictionaryChangedEventArgs<TKey, TValue> : EventArgs
{
	[CompilerGenerated]
	private readonly NotifyCollectionChangedAction notifyCollectionChangedAction_0;

	[CompilerGenerated]
	private readonly TKey? gparam_0;

	[CompilerGenerated]
	private readonly TValue? gparam_1;

	[CompilerGenerated]
	private readonly TValue? gparam_2;

	[CompilerGenerated]
	private readonly IReadOnlyCollection<KeyValuePair<TKey, TValue>> jisewgInQgA;

	public NotifyCollectionChangedAction Action
	{
		[CompilerGenerated]
		get
		{
			return notifyCollectionChangedAction_0;
		}
	}

	public TKey? Key
	{
		[CompilerGenerated]
		get
		{
			return gparam_0;
		}
	}

	public TValue? OldValue
	{
		[CompilerGenerated]
		get
		{
			return gparam_1;
		}
	}

	public TValue? NewValue
	{
		[CompilerGenerated]
		get
		{
			return gparam_2;
		}
	}

	public IReadOnlyCollection<KeyValuePair<TKey, TValue>> Items
	{
		[CompilerGenerated]
		get
		{
			return jisewgInQgA;
		}
	}

	public DictionaryChangedEventArgs(NotifyCollectionChangedAction action, TKey? key = default(TKey?), TValue? oldValue = default(TValue?), TValue? newValue = default(TValue?), IReadOnlyCollection<KeyValuePair<TKey, TValue>>? items = null)
	{
		notifyCollectionChangedAction_0 = action;
		gparam_0 = key;
		gparam_1 = oldValue;
		gparam_2 = newValue;
		jisewgInQgA = (IReadOnlyCollection<KeyValuePair<TKey, TValue>>)(((object)items) ?? ((object)Array.Empty<KeyValuePair<TKey, TValue>>()));
	}

	static DictionaryChangedEventArgs()
	{
		Class72.smethod_20();
	}
}
