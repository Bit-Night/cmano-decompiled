using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace SRTM.Logging.LogProviders;

[ExcludeFromCodeCoverage]
internal static class LogMessageFormatter
{
	private static readonly Regex regex_0;

	public static Func<string> SimulateStructuredLogging(Func<string> messageBuilder, object[] formatParameters)
	{
		IEnumerable<string> patternMatches;
		if (formatParameters != null && formatParameters.Length != 0)
		{
			return () => FormatStructuredMessage(messageBuilder(), formatParameters, out patternMatches);
		}
		return messageBuilder;
	}

	private static string smethod_0(string string_0, string string_1, string string_2)
	{
		int num = string_0.IndexOf(string_1, StringComparison.Ordinal);
		if (num >= 0)
		{
			return string_0.Substring(0, num) + string_2 + string_0.Substring(num + string_1.Length);
		}
		return string_0;
	}

	public static string FormatStructuredMessage(string targetMessage, object[] formatParameters, out IEnumerable<string> patternMatches)
	{
		if (formatParameters.Length != 0)
		{
			List<string> list = (List<string>)(patternMatches = new List<string>());
			foreach (Match item in regex_0.Matches(targetMessage))
			{
				string value = item.Groups["arg"].Value;
				if (!int.TryParse(value, out var _))
				{
					int num = list.IndexOf(value);
					if (num == -1)
					{
						num = list.Count;
						list.Add(value);
					}
					targetMessage = smethod_0(targetMessage, item.Value, "{" + num + item.Groups["format"].Value + "}");
				}
			}
			try
			{
				return string.Format(CultureInfo.InvariantCulture, targetMessage, formatParameters);
			}
			catch (FormatException innerException)
			{
				throw new FormatException("The input string '" + targetMessage + "' could not be formatted using string.Format", innerException);
			}
		}
		patternMatches = Enumerable.Empty<string>();
		return targetMessage;
	}

	static LogMessageFormatter()
	{
		Class72.smethod_20();
		regex_0 = new Regex("(?<!{){@?(?<arg>[^ :{}]+)(?<format>:[^}]+)?}", RegexOptions.Compiled);
	}
}
