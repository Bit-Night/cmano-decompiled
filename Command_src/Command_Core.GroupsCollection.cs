using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[Serializable]
public sealed class GroupsCollection : KeyedCollection<string, Group>
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

	protected override string GetKeyForItem(Group theGroup)
	{
		return theGroup.ObjectID;
	}

	protected override void InsertItem(int index, Group theGroup)
	{
		base.InsertItem(index, theGroup);
		collectionChangedEventHandler_0?.Invoke();
	}

	protected override void SetItem(int index, Group theGroup)
	{
		base.SetItem(index, theGroup);
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

	public Group GetByName(string theName)
	{
		return (from theG in this
			select (theG) into theG
			where Operators.CompareString(theG.Name, theName, false) == 0
			select theG).ElementAtOrDefault(0);
	}

	public bool ContainsByName(string theName)
	{
		return (from theG in this
			select (theG) into theG
			where Operators.CompareString(theG.Name, theName, false) == 0
			select theG).Count() > 0;
	}

	static GroupsCollection()
	{
		Class72.smethod_20();
	}
}
