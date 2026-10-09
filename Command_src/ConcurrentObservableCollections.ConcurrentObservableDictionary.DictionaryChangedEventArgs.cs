using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace ConcurrentObservableCollections.ConcurrentObservableDictionary;

public class DictionaryChangedEventArgs<TKey, TValue>
{
	[CompilerGenerated]
	private readonly NotifyCollectionChangedAction notifyCollectionChangedAction_0;

	[CompilerGenerated]
	private readonly TKey gparam_0;

	[CompilerGenerated]
	private readonly TValue gparam_1;

	[CompilerGenerated]
	private readonly TValue gparam_2;

	internal static object object_0;

	public NotifyCollectionChangedAction Action
	{
		[CompilerGenerated]
		get
		{
			return notifyCollectionChangedAction_0;
		}
	}

	public TKey Key
	{
		[CompilerGenerated]
		get
		{
			return gparam_0;
		}
	}

	public TValue NewValue
	{
		[CompilerGenerated]
		get
		{
			return gparam_1;
		}
	}

	public TValue OldValue
	{
		[CompilerGenerated]
		get
		{
			return gparam_2;
		}
	}

	public DictionaryChangedEventArgs(NotifyCollectionChangedAction action)
	{
		notifyCollectionChangedAction_0 = action;
	}

	public DictionaryChangedEventArgs(NotifyCollectionChangedAction action, TKey key, TValue newValue, TValue oldValue)
		: this(action)
	{
		gparam_0 = key;
		gparam_1 = newValue;
		gparam_2 = oldValue;
	}

	static DictionaryChangedEventArgs()
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
