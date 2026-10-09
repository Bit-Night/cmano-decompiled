using System.Text;

namespace DotSpatial.Serialization;

public static class XmlHelper
{
	public static string EscapeInvalidCharacters(string text)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < text.Length; i++)
		{
			switch (text[i])
			{
			case '&':
				if (!smethod_0(text, i))
				{
					stringBuilder.Append("&amp;");
				}
				else
				{
					stringBuilder.Append(text[i]);
				}
				break;
			case '"':
				stringBuilder.Append("&quot;");
				break;
			default:
				stringBuilder.Append(text[i]);
				break;
			case '>':
				stringBuilder.Append("&gt;");
				break;
			case '<':
				stringBuilder.Append("&lt;");
				break;
			case '\'':
				stringBuilder.Append("&apos;");
				break;
			}
		}
		return stringBuilder.ToString();
	}

	public static string UnEscapeInvalidCharacters(string text)
	{
		text = text.Replace("&lt;", "<");
		text = text.Replace("&gt;", ">");
		text = text.Replace("&quot;", "\"");
		text = text.Replace("&apos;", "'");
		text = text.Replace("&amp;", "&");
		return text;
	}

	private static bool smethod_0(string string_0, int int_0)
	{
		int num = string_0.Length - int_0;
		if (num >= 6)
		{
			if ((string_0[int_0 + 1] == 'q' && string_0[int_0 + 2] == 'u' && string_0[int_0 + 3] == 'o' && string_0[int_0 + 4] == 't' && string_0[int_0 + 5] == ';') || (string_0[int_0 + 1] == 'a' && string_0[int_0 + 2] == 'p' && string_0[int_0 + 3] == 'o' && string_0[int_0 + 4] == 's' && string_0[int_0 + 5] == ';') || (string_0[int_0 + 1] == 'a' && string_0[int_0 + 2] == 'm' && string_0[int_0 + 3] == 'p' && string_0[int_0 + 4] == ';') || (string_0[int_0 + 1] == 'l' && string_0[int_0 + 2] == 't' && string_0[int_0 + 3] == ';'))
			{
				return true;
			}
			if (string_0[int_0 + 1] == 'g' && string_0[int_0 + 2] == 't')
			{
				return string_0[int_0 + 3] == ';';
			}
			return false;
		}
		if (num >= 5)
		{
			if ((string_0[int_0 + 1] == 'a' && string_0[int_0 + 2] == 'm' && string_0[int_0 + 3] == 'p' && string_0[int_0 + 4] == ';') || (string_0[int_0 + 1] == 'l' && string_0[int_0 + 2] == 't' && string_0[int_0 + 3] == ';'))
			{
				return true;
			}
			if (string_0[int_0 + 1] == 'g' && string_0[int_0 + 2] == 't')
			{
				return string_0[int_0 + 3] == ';';
			}
			return false;
		}
		if (num >= 4)
		{
			if (string_0[int_0 + 1] == 'l' && string_0[int_0 + 2] == 't' && string_0[int_0 + 3] == ';')
			{
				return true;
			}
			if (string_0[int_0 + 1] == 'g' && string_0[int_0 + 2] == 't')
			{
				return string_0[int_0 + 3] == ';';
			}
			return false;
		}
		return false;
	}

	static XmlHelper()
	{
		Class72.smethod_20();
	}
}
