using System.Collections;
using Nini.Util;

namespace Nini.Ini;

public class IniSection
{
	private OrderedList orderedList_0 = new OrderedList();

	private string string_0 = "";

	private string string_1;

	private int int_0;

	public string Name => string_0;

	public string Comment => string_1;

	public int ItemCount => orderedList_0.Count;

	public IniSection(string name, string comment)
	{
		string_0 = name;
		string_1 = comment;
	}

	public IniSection(string name)
		: this(name, null)
	{
	}

	public string GetValue(string key)
	{
		string result = null;
		if (Contains(key))
		{
			result = ((IniItem)orderedList_0[key]).Value;
		}
		return result;
	}

	public IniItem GetItem(int index)
	{
		return (IniItem)orderedList_0[index];
	}

	public string[] GetKeys()
	{
		ArrayList arrayList = new ArrayList();
		IniItem iniItem = null;
		for (int i = 0; i < orderedList_0.Count; i++)
		{
			iniItem = (IniItem)orderedList_0[i];
			if (iniItem.Type == IniType.Key)
			{
				arrayList.Add(iniItem.Name);
			}
		}
		string[] array = new string[arrayList.Count];
		arrayList.CopyTo(array, 0);
		return array;
	}

	public bool Contains(string key)
	{
		return orderedList_0[key] != null;
	}

	public void Set(string key, string value, string comment)
	{
		IniItem iniItem = null;
		if (Contains(key))
		{
			iniItem = (IniItem)orderedList_0[key];
			iniItem.Value = value;
			iniItem.Comment = comment;
		}
		else
		{
			iniItem = new IniItem(key, value, IniType.Key, comment);
			orderedList_0.Add(key, iniItem);
		}
	}

	public void Set(string key, string value)
	{
		Set(key, value, null);
	}

	public void Set(string comment)
	{
		string text = "#comment" + int_0;
		IniItem value = new IniItem(text, null, IniType.Empty, comment);
		orderedList_0.Add(text, value);
		int_0++;
	}

	public void Set()
	{
		Set(null);
	}

	public void Remove(string key)
	{
		if (Contains(key))
		{
			orderedList_0.Remove(key);
		}
	}

	static IniSection()
	{
		Class72.smethod_20();
	}
}
