using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Threading;

public sealed class FastObservableCollection<T> : ObservableCollection<T>
{
	private readonly object object_0 = new object();

	private bool bool_0;

	[CompilerGenerated]
	private NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler_0;

	private static object object_1;

	public override event NotifyCollectionChangedEventHandler CollectionChanged
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

	public FastObservableCollection()
	{
		bool_0 = false;
	}

	public void AddItems(IList<T> items)
	{
		lock (object_0)
		{
			SuspendCollectionChangeNotification();
			foreach (T item in items)
			{
				InsertItem(base.Count, item);
			}
			NotifyChanges();
		}
	}

	public void NotifyChanges()
	{
		ResumeCollectionChangeNotification();
		NotifyCollectionChangedEventArgs e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
		OnCollectionChanged(e);
	}

	public void RemoveItems(IList<T> items)
	{
		lock (object_0)
		{
			SuspendCollectionChangeNotification();
			foreach (T item in items)
			{
				Remove(item);
			}
			NotifyChanges();
		}
	}

	public void ResumeCollectionChangeNotification()
	{
		bool_0 = false;
	}

	public void SuspendCollectionChangeNotification()
	{
		bool_0 = true;
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		using (BlockReentrancy())
		{
			if (bool_0)
			{
				return;
			}
			NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = notifyCollectionChangedEventHandler_0;
			if (notifyCollectionChangedEventHandler == null)
			{
				return;
			}
			Delegate[] invocationList = notifyCollectionChangedEventHandler.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler2 = (NotifyCollectionChangedEventHandler)invocationList[i];
				object? target = notifyCollectionChangedEventHandler2.Target;
				DispatcherObject val = (DispatcherObject)((target is DispatcherObject) ? target : null);
				if (val != null && !val.CheckAccess())
				{
					val.Dispatcher.BeginInvoke((DispatcherPriority)8, (Delegate)notifyCollectionChangedEventHandler2, (object)this, new object[1] { e });
				}
				else
				{
					notifyCollectionChangedEventHandler2(this, e);
				}
			}
		}
	}

	static FastObservableCollection()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_0()
	{
		return object_1 == null;
	}

	internal static object smethod_1()
	{
		return object_1;
	}
}
