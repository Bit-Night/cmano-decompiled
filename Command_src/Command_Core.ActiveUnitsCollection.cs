using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class ActiveUnitsCollection : KeyedCollection<string, ActiveUnit>
{
	public delegate void CollectionChangedEventHandler();

	[CompilerGenerated]
	private static CollectionChangedEventHandler collectionChangedEventHandler_0;

	public static event CollectionChangedEventHandler CollectionChanged
	{
		[CompilerGenerated]
		add
		{
			CollectionChangedEventHandler collectionChangedEventHandler = collectionChangedEventHandler_0;
			CollectionChangedEventHandler collectionChangedEventHandler2;
			do
			{
				collectionChangedEventHandler2 = collectionChangedEventHandler;
				CollectionChangedEventHandler value2 = (CollectionChangedEventHandler)Delegate.Combine(collectionChangedEventHandler2, value);
				collectionChangedEventHandler = Interlocked.CompareExchange(ref collectionChangedEventHandler_0, value2, collectionChangedEventHandler2);
			}
			while ((object)collectionChangedEventHandler != collectionChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CollectionChangedEventHandler collectionChangedEventHandler = collectionChangedEventHandler_0;
			CollectionChangedEventHandler collectionChangedEventHandler2;
			do
			{
				collectionChangedEventHandler2 = collectionChangedEventHandler;
				CollectionChangedEventHandler value2 = (CollectionChangedEventHandler)Delegate.Remove(collectionChangedEventHandler2, value);
				collectionChangedEventHandler = Interlocked.CompareExchange(ref collectionChangedEventHandler_0, value2, collectionChangedEventHandler2);
			}
			while ((object)collectionChangedEventHandler != collectionChangedEventHandler2);
		}
	}

	protected override string GetKeyForItem(ActiveUnit theUnit)
	{
		return theUnit.ObjectID;
	}

	protected override void InsertItem(int index, ActiveUnit theUnit)
	{
		base.InsertItem(index, theUnit);
		collectionChangedEventHandler_0?.Invoke();
	}

	protected override void SetItem(int index, ActiveUnit theUnit)
	{
		base.SetItem(index, theUnit);
		collectionChangedEventHandler_0?.Invoke();
	}

	protected override void RemoveItem(int index)
	{
		base.RemoveItem(index);
		collectionChangedEventHandler_0?.Invoke();
	}

	protected override void ClearItems()
	{
		base.ClearItems();
		collectionChangedEventHandler_0?.Invoke();
	}

	public ActiveUnit GetByName(string theName)
	{
		ActiveUnit result;
		try
		{
			using (IEnumerator<ActiveUnit> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ActiveUnit current = enumerator.Current;
					if (string.CompareOrdinal(current.Name, theName) != 0)
					{
						continue;
					}
					result = current;
					goto end_IL_0001;
				}
			}
			result = null;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100996", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static ActiveUnitsCollection()
	{
		Class72.smethod_20();
	}
}
