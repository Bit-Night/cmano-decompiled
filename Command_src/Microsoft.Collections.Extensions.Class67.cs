using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.Collections.Extensions;

internal sealed class Class67<K, V>
{
	private readonly IDictionary<K, V> idictionary_0;

	internal static object object_0;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public KeyValuePair<K, V>[] Items
	{
		get
		{
			KeyValuePair<K, V>[] array = new KeyValuePair<K, V>[idictionary_0.Count];
			idictionary_0.CopyTo(array, 0);
			return array;
		}
	}

	public Class67(IDictionary<K, V> dictionary)
	{
		idictionary_0 = dictionary ?? throw new ArgumentNullException("dictionary");
	}

	static Class67()
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
