using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Nini.Util;

public class ArgvParser
{
	private StringDictionary stringDictionary_0;

	public string this[string param] => stringDictionary_0[param];

	public ArgvParser(string args)
	{
		MatchCollection matchCollection = new Regex("(['\"][^\"]+['\"])\\s*|([^\\s]+)\\s*", RegexOptions.Compiled).Matches(args);
		string[] array = new string[matchCollection.Count - 1];
		for (int i = 1; i < matchCollection.Count; i++)
		{
			array[i - 1] = matchCollection[i].Value.Trim();
		}
	}

	public ArgvParser(string[] args)
	{
		method_0(args);
	}

	private void method_0(string[] string_0)
	{
		stringDictionary_0 = new StringDictionary();
		Regex regex = new Regex("^([/-]|--){1}(?<name>\\w+)([:=])?(?<value>.+)?$", RegexOptions.Compiled);
		char[] trimChars = new char[2] { '"', '\'' };
		string text = null;
		foreach (string text2 in string_0)
		{
			Match match = regex.Match(text2);
			if (match.Success)
			{
				text = match.Groups["name"].Value;
				stringDictionary_0.Add(text, match.Groups["value"].Value.Trim(trimChars));
			}
			else if (text != null)
			{
				stringDictionary_0[text] = text2.Trim(trimChars);
			}
		}
	}

	static ArgvParser()
	{
		Class72.smethod_20();
	}
}
