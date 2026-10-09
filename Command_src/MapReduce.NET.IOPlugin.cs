using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MapReduce.NET;

public class IOPlugin : IUpdateSource
{
	[CompilerGenerated]
	private StatusDelegate statusDelegate_0;

	[CompilerGenerated]
	private object object_0;

	private uint uint_0 = 100u;

	public object Location
	{
		[CompilerGenerated]
		get
		{
			return object_0;
		}
		[CompilerGenerated]
		protected set
		{
			object_0 = value;
		}
	}

	public uint ReportEveryNth
	{
		get
		{
			return uint_0;
		}
		set
		{
			if (value != 0)
			{
				uint_0 = value;
			}
		}
	}

	internal event StatusDelegate StatusUpdate
	{
		[CompilerGenerated]
		add
		{
			StatusDelegate statusDelegate = statusDelegate_0;
			StatusDelegate statusDelegate2;
			do
			{
				statusDelegate2 = statusDelegate;
				StatusDelegate value2 = (StatusDelegate)Delegate.Combine(statusDelegate2, value);
				statusDelegate = Interlocked.CompareExchange(ref statusDelegate_0, value2, statusDelegate2);
			}
			while ((object)statusDelegate != statusDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			StatusDelegate statusDelegate = statusDelegate_0;
			StatusDelegate statusDelegate2;
			do
			{
				statusDelegate2 = statusDelegate;
				StatusDelegate value2 = (StatusDelegate)Delegate.Remove(statusDelegate2, value);
				statusDelegate = Interlocked.CompareExchange(ref statusDelegate_0, value2, statusDelegate2);
			}
			while ((object)statusDelegate != statusDelegate2);
		}
	}

	internal void RaiseStatusUpdate(UpdateType type, uint processedItems)
	{
		if (statusDelegate_0 != null)
		{
			if (type == UpdateType.Output)
			{
				statusDelegate_0(UpdateType.Output, this, processedItems);
			}
			if (type == UpdateType.Input)
			{
				statusDelegate_0(UpdateType.Input, this, processedItems);
			}
		}
	}

	static IOPlugin()
	{
		Class72.smethod_20();
	}
}
