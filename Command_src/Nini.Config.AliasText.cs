using System;
using System.Collections;

namespace Nini.Config;

public class AliasText
{
	private Hashtable hashtable_0;

	private Hashtable hashtable_1;

	public AliasText()
	{
		hashtable_0 = method_2();
		hashtable_1 = method_2();
		method_0();
	}

	public void AddAlias(string key, string alias, int value)
	{
		if (hashtable_0.Contains(key))
		{
			((Hashtable)hashtable_0[key])[alias] = value;
			return;
		}
		Hashtable hashtable = method_2();
		hashtable[alias] = value;
		hashtable_0.Add(key, hashtable);
	}

	public void AddAlias(string alias, bool value)
	{
		hashtable_1[alias] = value;
	}

	public void AddAlias(string key, Enum enumAlias)
	{
		method_1(key, enumAlias);
	}

	public bool ContainsBoolean(string key)
	{
		return hashtable_1.Contains(key);
	}

	public bool ContainsInt(string key, string alias)
	{
		bool result = false;
		if (hashtable_0.Contains(key))
		{
			result = ((Hashtable)hashtable_0[key]).Contains(alias);
		}
		return result;
	}

	public bool GetBoolean(string key)
	{
		if (!hashtable_1.Contains(key))
		{
			throw new ArgumentException("Alias does not exist for text");
		}
		return (bool)hashtable_1[key];
	}

	public int GetInt(string key, string alias)
	{
		if (hashtable_0.Contains(key))
		{
			Hashtable obj = (Hashtable)hashtable_0[key];
			if (!obj.Contains(alias))
			{
				throw new ArgumentException("Config value does not match a supplied alias");
			}
			return (int)obj[alias];
		}
		throw new ArgumentException("Alias does not exist for key");
	}

	private void method_0()
	{
		AddAlias("true", value: true);
		AddAlias("false", value: false);
	}

	private void method_1(string string_0, Enum enum_0)
	{
		string[] names = Enum.GetNames(enum_0.GetType());
		int[] array = (int[])Enum.GetValues(enum_0.GetType());
		for (int i = 0; i < names.Length; i++)
		{
			AddAlias(string_0, names[i], array[i]);
		}
	}

	private Hashtable method_2()
	{
		return new Hashtable(CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default);
	}

	static AliasText()
	{
		Class72.smethod_20();
	}
}
