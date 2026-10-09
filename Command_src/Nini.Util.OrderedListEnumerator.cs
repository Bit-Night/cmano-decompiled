using System;
using System.Collections;

namespace Nini.Util;

public class OrderedListEnumerator : IDictionaryEnumerator, IEnumerator
{
	private int int_0 = -1;

	private ArrayList arrayList_0;

	object IEnumerator.Current
	{
		get
		{
			if (int_0 < 0 || int_0 >= arrayList_0.Count)
			{
				throw new InvalidOperationException();
			}
			return arrayList_0[int_0];
		}
	}

	public DictionaryEntry Current
	{
		get
		{
			if (int_0 < 0 || int_0 >= arrayList_0.Count)
			{
				throw new InvalidOperationException();
			}
			return (DictionaryEntry)arrayList_0[int_0];
		}
	}

	public DictionaryEntry Entry => Current;

	public object Key => Entry.Key;

	public object Value => Entry.Value;

	internal OrderedListEnumerator(ArrayList arrayList)
	{
		arrayList_0 = arrayList;
	}

	public bool MoveNext()
	{
		int_0++;
		if (int_0 < arrayList_0.Count)
		{
			return true;
		}
		return false;
	}

	public void Reset()
	{
		int_0 = -1;
	}

	static OrderedListEnumerator()
	{
		Class72.smethod_20();
	}
}
