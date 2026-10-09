using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Microsoft.Collections.Extensions;

internal sealed class DictionarySlimDebugView<K, V> where K : IEquatable<K>
{
	private readonly DictionarySlim<K, V> dictionarySlim_0;

	internal static object object_0;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public KeyValuePair<K, V>[] Items => dictionarySlim_0.ToArray();

	public DictionarySlimDebugView(DictionarySlim<K, V> dictionary)
	{
		dictionarySlim_0 = dictionary ?? throw new ArgumentNullException("dictionary");
	}

	static DictionarySlimDebugView()
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
