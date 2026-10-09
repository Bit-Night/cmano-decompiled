using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Collections.Pooled;

internal sealed class Class68<T>
{
	private readonly ICollection<T> icollection_0;

	private static object object_0;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public T[] Items
	{
		get
		{
			T[] array = new T[icollection_0.Count];
			icollection_0.CopyTo(array, 0);
			return array;
		}
	}

	public Class68(ICollection<T> collection)
	{
		icollection_0 = collection ?? throw new ArgumentNullException("collection");
	}

	static Class68()
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
