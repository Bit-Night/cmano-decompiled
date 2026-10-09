using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class NaturalSortComparer<T> : IComparer<string>
{
	private bool bool_0;

	private Dictionary<string, string[]> dictionary_0;

	private static object object_0;

	public NaturalSortComparer(bool inAscendingOrder = true)
	{
		dictionary_0 = new Dictionary<string, string[]>();
		bool_0 = inAscendingOrder;
	}

	internal int Compare(string x, string y)
	{
		throw new NotImplementedException();
	}

	private int IComparer_Compare(string x, string y)
	{
		if (Operators.CompareString(x, y, false) == 0)
		{
			return 0;
		}
		if (string.IsNullOrEmpty(x))
		{
			return 1;
		}
		if (string.IsNullOrEmpty(y))
		{
			return -1;
		}
		if (!dictionary_0.TryGetValue(x, out var value))
		{
			value = Regex.Split(x.Replace(" ", ""), "([0-9]+)");
			dictionary_0.Add(x, value);
		}
		int num;
		if (!dictionary_0.TryGetValue(y, out var value2))
		{
			value2 = Regex.Split(y.Replace(" ", ""), "([0-9]+)");
			dictionary_0.Add(y, value2);
			num = 0;
		}
		else
		{
			num = 0;
		}
		int num2;
		for (int i = num; i < value.Length && i < value2.Length; i++)
		{
			if (Operators.CompareString(value[i], value2[i], false) != 0)
			{
				num2 = smethod_0(value[i], value2[i]);
				return (!bool_0) ? (-num2) : num2;
			}
		}
		num2 = ((value2.Length > value.Length) ? 1 : ((value.Length > value2.Length) ? (-1) : 0));
		return (!bool_0) ? (-num2) : num2;
	}

	int IComparer<string>.Compare(string x, string y)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IComparer_Compare
		return this.IComparer_Compare(x, y);
	}

	private static int smethod_0(string string_0, string string_1)
	{
		if (!int.TryParse(string_0, out var result))
		{
			return string_0.CompareTo(string_1);
		}
		if (!int.TryParse(string_1, out var result2))
		{
			return string_0.CompareTo(string_1);
		}
		return result.CompareTo(result2);
	}

	public void Dispose()
	{
		dictionary_0.Clear();
		dictionary_0 = null;
	}

	static NaturalSortComparer()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_1()
	{
		return object_0 == null;
	}

	internal static object smethod_2()
	{
		return object_0;
	}
}
