using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class StripHTML
{
	private static Regex regex_0;

	static StripHTML()
	{
		Class72.smethod_20();
		regex_0 = new Regex("<.*?>", RegexOptions.Compiled);
	}

	internal static string StripTagsRegex(string source)
	{
		return Regex.Replace(source, "<.*?>", string.Empty);
	}

	internal static string StripTagsRegexCompiled(string source)
	{
		return regex_0.Replace(source, string.Empty).Replace("&nbsp;", " ").Replace("\ufffd", "°");
	}

	internal static string StripTagsCharArray(string source)
	{
		char[] array = new char[source.Length - 1 + 1];
		int num = 0;
		bool flag = false;
		int num2 = source.Length - 1;
		for (int i = 0; i <= num2; i++)
		{
			char c = source[i];
			switch (c)
			{
			case '<':
				flag = true;
				continue;
			case '>':
				flag = false;
				continue;
			}
			if (!flag)
			{
				array[num] = c;
				num++;
			}
		}
		return new string(array, 0, num);
	}
}
