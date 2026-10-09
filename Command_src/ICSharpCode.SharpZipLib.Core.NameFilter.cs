using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ICSharpCode.SharpZipLib.Core;

public class NameFilter : IScanFilter
{
	private string string_0;

	private List<Regex> list_0;

	private List<Regex> list_1;

	public NameFilter(string filter)
	{
		string_0 = filter;
		list_0 = new List<Regex>();
		list_1 = new List<Regex>();
		method_0();
	}

	public static bool IsValidExpression(string expression)
	{
		bool result = true;
		try
		{
			new Regex(expression, RegexOptions.IgnoreCase | RegexOptions.Singleline);
		}
		catch (ArgumentException)
		{
			result = false;
		}
		return result;
	}

	public static bool IsValidFilterExpression(string toTest)
	{
		bool result = true;
		try
		{
			if (toTest != null)
			{
				string[] array = SplitQuoted(toTest);
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != null && array[i].Length > 0)
					{
						string pattern = ((array[i][0] == '+') ? array[i].Substring(1, array[i].Length - 1) : ((array[i][0] != '-') ? array[i] : array[i].Substring(1, array[i].Length - 1)));
						new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
					}
				}
			}
		}
		catch (ArgumentException)
		{
			result = false;
		}
		return result;
	}

	public static string[] SplitQuoted(string original)
	{
		char c = '\\';
		char[] array = new char[1] { ';' };
		List<string> list = new List<string>();
		if (!string.IsNullOrEmpty(original))
		{
			int num = -1;
			StringBuilder stringBuilder = new StringBuilder();
			while (num < original.Length)
			{
				num++;
				if (num >= original.Length)
				{
					list.Add(stringBuilder.ToString());
				}
				else if (original[num] == c)
				{
					num++;
					if (num >= original.Length)
					{
						throw new ArgumentException("Missing terminating escape character", "original");
					}
					if (Array.IndexOf(array, original[num]) < 0)
					{
						stringBuilder.Append(c);
					}
					stringBuilder.Append(original[num]);
				}
				else if (Array.IndexOf(array, original[num]) < 0)
				{
					stringBuilder.Append(original[num]);
				}
				else
				{
					list.Add(stringBuilder.ToString());
					stringBuilder.Length = 0;
				}
			}
		}
		return list.ToArray();
	}

	public override string ToString()
	{
		return string_0;
	}

	public bool IsIncluded(string name)
	{
		bool result = false;
		if (list_0.Count == 0)
		{
			result = true;
		}
		else
		{
			foreach (Regex item in list_0)
			{
				if (item.IsMatch(name))
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}

	public bool IsExcluded(string name)
	{
		bool result = false;
		foreach (Regex item in list_1)
		{
			if (item.IsMatch(name))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public bool IsMatch(string name)
	{
		if (!IsIncluded(name))
		{
			return false;
		}
		return !IsExcluded(name);
	}

	private void method_0()
	{
		if (string_0 == null)
		{
			return;
		}
		string[] array = SplitQuoted(string_0);
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != null && array[i].Length > 0)
			{
				bool num = array[i][0] != '-';
				string pattern = ((array[i][0] == '+') ? array[i].Substring(1, array[i].Length - 1) : ((array[i][0] != '-') ? array[i] : array[i].Substring(1, array[i].Length - 1)));
				if (!num)
				{
					list_1.Add(new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline));
				}
				else
				{
					list_0.Add(new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline));
				}
			}
		}
	}

	static NameFilter()
	{
		Class72.smethod_20();
	}
}
