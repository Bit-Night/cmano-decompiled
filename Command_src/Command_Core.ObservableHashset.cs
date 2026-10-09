using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Command_Core;

public sealed class ObservableHashset<T> : HashSet<T>, INotifyCollectionChanged
{
	[CompilerGenerated]
	private NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler_0;

	internal static object object_0;

	public event NotifyCollectionChangedEventHandler CollectionChanged
	{
		[CompilerGenerated]
		add
		{
			NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = notifyCollectionChangedEventHandler_0;
			NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler2;
			do
			{
				notifyCollectionChangedEventHandler2 = notifyCollectionChangedEventHandler;
				NotifyCollectionChangedEventHandler value2 = (NotifyCollectionChangedEventHandler)Delegate.Combine(notifyCollectionChangedEventHandler2, value);
				notifyCollectionChangedEventHandler = Interlocked.CompareExchange(ref notifyCollectionChangedEventHandler_0, value2, notifyCollectionChangedEventHandler2);
			}
			while ((object)notifyCollectionChangedEventHandler != notifyCollectionChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = notifyCollectionChangedEventHandler_0;
			NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler2;
			do
			{
				notifyCollectionChangedEventHandler2 = notifyCollectionChangedEventHandler;
				NotifyCollectionChangedEventHandler value2 = (NotifyCollectionChangedEventHandler)Delegate.Remove(notifyCollectionChangedEventHandler2, value);
				notifyCollectionChangedEventHandler = Interlocked.CompareExchange(ref notifyCollectionChangedEventHandler_0, value2, notifyCollectionChangedEventHandler2);
			}
			while ((object)notifyCollectionChangedEventHandler != notifyCollectionChangedEventHandler2);
		}
	}

	static ObservableHashset()
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
