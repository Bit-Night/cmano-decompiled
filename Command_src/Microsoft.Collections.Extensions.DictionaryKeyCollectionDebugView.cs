using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.Collections.Extensions;

internal sealed class DictionaryKeyCollectionDebugView<TKey, TValue>
{
	private readonly ICollection<TKey> icollection_0;

	internal static object object_0;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public TKey[] Items
	{
		get
		{
			TKey[] array = new TKey[icollection_0.Count];
			icollection_0.CopyTo(array, 0);
			return array;
		}
	}

	public DictionaryKeyCollectionDebugView(ICollection<TKey> collection)
	{
		icollection_0 = collection ?? throw new ArgumentNullException("collection");
	}

	static DictionaryKeyCollectionDebugView()
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
