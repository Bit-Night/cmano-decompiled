using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DarkUI.Collections;

public sealed class ObservableListModified<T> : EventArgs
{
	[CompilerGenerated]
	private IEnumerable<T> ienumerable_0;

	private static object object_0;

	public IEnumerable<T> Items
	{
		[CompilerGenerated]
		get
		{
			return ienumerable_0;
		}
		[CompilerGenerated]
		private set
		{
			ienumerable_0 = value;
		}
	}

	public ObservableListModified(IEnumerable<T> items)
	{
		Items = items;
	}

	static ObservableListModified()
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
