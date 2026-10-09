using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Collections.Pooled;

internal sealed class DictionaryValueCollectionDebugView<TKey, TValue>
{
	private readonly ICollection<TValue> icollection_0;

	private static object object_0;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public TValue[] Items
	{
		get
		{
			TValue[] array = new TValue[icollection_0.Count];
			icollection_0.CopyTo(array, 0);
			return array;
		}
	}

	public DictionaryValueCollectionDebugView(ICollection<TValue> collection)
	{
		icollection_0 = collection ?? throw new ArgumentNullException("collection");
	}

	static DictionaryValueCollectionDebugView()
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
