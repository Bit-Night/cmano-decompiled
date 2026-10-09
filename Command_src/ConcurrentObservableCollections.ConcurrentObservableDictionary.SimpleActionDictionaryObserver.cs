using System;

namespace ConcurrentObservableCollections.ConcurrentObservableDictionary;

internal class SimpleActionDictionaryObserver<TKey, TValue> : GInterface10<TKey, TValue>
{
	private readonly Action<DictionaryChangedEventArgs<TKey, TValue>> action_0;

	private static object object_0;

	public SimpleActionDictionaryObserver(Action<DictionaryChangedEventArgs<TKey, TValue>> action)
	{
		action_0 = action;
	}

	public void OnEventOccur(DictionaryChangedEventArgs<TKey, TValue> args)
	{
		action_0(args);
	}

	static SimpleActionDictionaryObserver()
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
