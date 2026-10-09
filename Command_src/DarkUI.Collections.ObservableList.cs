using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DarkUI.Collections;

public class ObservableList<T> : List<T>, IDisposable
{
	private bool bool_0;

	[CompilerGenerated]
	private EventHandler<ObservableListModified<T>> eventHandler_0;

	[CompilerGenerated]
	private EventHandler<ObservableListModified<T>> eventHandler_1;

	[CompilerGenerated]
	private EventHandler<object> eventHandler_2;

	private static object object_0;

	public event EventHandler<ObservableListModified<T>> ItemsAdded
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ObservableListModified<T>> eventHandler = eventHandler_0;
			EventHandler<ObservableListModified<T>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<T>> value2 = (EventHandler<ObservableListModified<T>>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ObservableListModified<T>> eventHandler = eventHandler_0;
			EventHandler<ObservableListModified<T>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<T>> value2 = (EventHandler<ObservableListModified<T>>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<ObservableListModified<T>> ItemsRemoved
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ObservableListModified<T>> eventHandler = eventHandler_1;
			EventHandler<ObservableListModified<T>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<T>> value2 = (EventHandler<ObservableListModified<T>>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ObservableListModified<T>> eventHandler = eventHandler_1;
			EventHandler<ObservableListModified<T>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<T>> value2 = (EventHandler<ObservableListModified<T>>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<object> ItemsCleared
	{
		[CompilerGenerated]
		add
		{
			EventHandler<object> eventHandler = eventHandler_2;
			EventHandler<object> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<object> value2 = (EventHandler<object>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<object> eventHandler = eventHandler_2;
			EventHandler<object> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<object> value2 = (EventHandler<object>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public ObservableList()
	{
	}

	public ObservableList(List<T> theArea)
	{
		AddRange(theArea);
	}

	~ObservableList()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!bool_0)
		{
			if (eventHandler_0 != null)
			{
				eventHandler_0 = null;
			}
			if (eventHandler_1 != null)
			{
				eventHandler_1 = null;
			}
			bool_0 = true;
		}
	}

	public new void Add(T item)
	{
		base.Add(item);
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, new ObservableListModified<T>(new List<T> { item }));
		}
	}

	public new void AddRange(IEnumerable<T> collection)
	{
		List<T> list = collection.ToList();
		base.AddRange((IEnumerable<T>)list);
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, new ObservableListModified<T>(list));
		}
	}

	public new void Remove(T item)
	{
		try
		{
			if (Contains(item))
			{
				base.Remove(item);
			}
		}
		finally
		{
			if (eventHandler_1 != null)
			{
				eventHandler_1(this, new ObservableListModified<T>(new List<T> { item }));
			}
		}
	}

	public new void RemoveAt(int index)
	{
		if (index >= 0 && index < base.Count)
		{
			T item = base[index];
			base.RemoveAt(index);
			if (eventHandler_1 != null)
			{
				eventHandler_1(this, new ObservableListModified<T>(new List<T> { item }));
			}
			return;
		}
		throw new ArgumentOutOfRangeException("index");
	}

	public new void Clear()
	{
		base.Clear();
		if (eventHandler_2 != null)
		{
			eventHandler_2(this, null);
		}
	}

	static ObservableList()
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
