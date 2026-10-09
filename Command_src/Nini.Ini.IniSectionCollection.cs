using System;
using System.Collections;
using Nini.Util;

namespace Nini.Ini;

public class IniSectionCollection : ICollection, IEnumerable
{
	private OrderedList orderedList_0 = new OrderedList();

	public IniSection this[int index] => (IniSection)orderedList_0[index];

	public IniSection this[string configName] => (IniSection)orderedList_0[configName];

	public int Count => orderedList_0.Count;

	public object SyncRoot => orderedList_0.SyncRoot;

	public bool IsSynchronized => orderedList_0.IsSynchronized;

	public void Add(IniSection section)
	{
		if (orderedList_0.Contains(section))
		{
			throw new ArgumentException("IniSection already exists");
		}
		orderedList_0.Add(section.Name, section);
	}

	public void Remove(string config)
	{
		orderedList_0.Remove(config);
	}

	public void CopyTo(Array array, int index)
	{
		orderedList_0.CopyTo(array, index);
	}

	public void CopyTo(IniSection[] array, int index)
	{
		((ICollection)orderedList_0).CopyTo((Array)array, index);
	}

	public IEnumerator GetEnumerator()
	{
		return orderedList_0.GetEnumerator();
	}

	static IniSectionCollection()
	{
		Class72.smethod_20();
	}
}
