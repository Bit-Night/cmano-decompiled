namespace ConcurrentObservableCollections.ConcurrentObservableDictionary;

public interface GInterface10<TKey, TValue>
{
	void OnEventOccur(DictionaryChangedEventArgs<TKey, TValue> args);
}
