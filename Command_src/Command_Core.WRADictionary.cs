using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class WRADictionary<WRA_FiringDoctrineEntry> : IDictionary<int, WRA_FiringDoctrineEntry>
{
	private WRA_FiringDoctrineEntry[] gparam_0;

	private int int_0;

	private static int[] int_1;

	private static int[] int_2;

	private static int int_3;

	private static object object_0;

	public WRA_FiringDoctrineEntry this[int key]
	{
		get
		{
			int num = method_0(key);
			return gparam_0[num];
		}
		set
		{
			int num = method_0(key);
			gparam_0[num] = value;
		}
	}

	public ICollection<int> Keys
	{
		get
		{
			List<int> list = new List<int>(gparam_0.Length);
			int num = gparam_0.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				if (gparam_0[i] != null)
				{
					list.Add(i);
				}
			}
			return list;
		}
	}

	public ICollection<WRA_FiringDoctrineEntry> Values
	{
		get
		{
			List<WRA_FiringDoctrineEntry> list = new List<WRA_FiringDoctrineEntry>(gparam_0.Length);
			int num = gparam_0.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				WRA_FiringDoctrineEntry val = gparam_0[i];
				if (val != null)
				{
					list.Add(val);
				}
			}
			return list;
		}
	}

	public int Count => int_0;

	public bool IsReadOnly
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public WRADictionary()
	{
		try
		{
			if (int_3 == 0)
			{
				int[] obj = (int[])Enum.GetValues(typeof(Doctrine._WRA_WeaponTargetType));
				int_3 = obj.Length - 1;
				int_1 = new int[int_3 + 1];
				obj.CopyTo(int_1, 0);
				int_2 = new int[obj[^1] + 1];
				int num = int_1.Length - 1;
				for (int i = 0; i <= num; i++)
				{
					int_2[int_1[i]] = i;
				}
			}
			gparam_0 = new WRA_FiringDoctrineEntry[int_3 + 1];
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private int method_0(int int_4)
	{
		int num = int_2[int_4];
		if (num < 0)
		{
			int num2;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			num = num2;
		}
		else if (num > gparam_0.Length - 1 && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		return num;
	}

	public void Add(int key, WRA_FiringDoctrineEntry value)
	{
		int num = method_0(key);
		if (gparam_0[num] != null)
		{
			throw new Exception();
		}
		gparam_0[num] = value;
		int_0++;
	}

	public void Add(KeyValuePair<int, WRA_FiringDoctrineEntry> item)
	{
		throw new NotImplementedException();
	}

	public void Clear()
	{
		int num = gparam_0.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			gparam_0[i] = default(WRA_FiringDoctrineEntry);
		}
	}

	public void CopyTo(KeyValuePair<int, WRA_FiringDoctrineEntry>[] array, int arrayIndex)
	{
		throw new NotImplementedException();
	}

	public bool ContainsKey(int key)
	{
		bool result = default(bool);
		try
		{
			int num = method_0(key);
			result = gparam_0[num] != null;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool Remove(int key)
	{
		int num = method_0(key);
		if (gparam_0[num] == null)
		{
			return false;
		}
		int_0--;
		gparam_0[num] = default(WRA_FiringDoctrineEntry);
		return true;
	}

	public bool Remove(KeyValuePair<int, WRA_FiringDoctrineEntry> item)
	{
		throw new NotImplementedException();
	}

	public bool TryGetValue(int key, ref WRA_FiringDoctrineEntry value)
	{
		int num = method_0(key);
		value = gparam_0[num];
		return value != null;
	}

	public bool Contains(KeyValuePair<int, WRA_FiringDoctrineEntry> item)
	{
		throw new NotImplementedException();
	}

	public IEnumerator<KeyValuePair<int, WRA_FiringDoctrineEntry>> GetEnumerator()
	{
		throw new NotImplementedException();
	}

	private IEnumerator IEnumerable_GetEnumerator()
	{
		return GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in IEnumerable_GetEnumerator
		return this.IEnumerable_GetEnumerator();
	}

	static WRADictionary()
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
