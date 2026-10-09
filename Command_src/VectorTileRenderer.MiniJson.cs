using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace VectorTileRenderer;

internal static class MiniJson
{
	private class Class23
	{
		private readonly string string_0;

		private int int_0;

		public Class23(string string_1)
		{
			string_0 = string_1;
			int_0 = 0;
		}

		public object method_0()
		{
			method_6();
			if (int_0 >= string_0.Length)
			{
				throw new FormatException("Unexpected end of JSON");
			}
			char c = string_0[int_0];
			switch (c)
			{
			case '{':
				return method_1();
			case '[':
				return method_2();
			case '"':
				return method_3();
			case 't':
				return method_5("true", true);
			case 'f':
				return method_5("false", false);
			case 'n':
				return method_5("null", null);
			default:
				if (!char.IsDigit(c))
				{
					throw new FormatException($"Unexpected character '{c}' at position {int_0}");
				}
				break;
			case '-':
				break;
			}
			return method_4();
		}

		private Dictionary<string, object> method_1()
		{
			method_7('{');
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			method_6();
			if (method_8() == '}')
			{
				int_0++;
				return dictionary;
			}
			while (true)
			{
				method_6();
				string key = method_3();
				method_6();
				method_7(':');
				object value = method_0();
				dictionary[key] = value;
				method_6();
				char c = string_0[int_0];
				switch (c)
				{
				case ',':
					break;
				default:
					throw new FormatException($"Expected ',' or '}}' at {int_0}, got '{c}'");
				case '}':
					int_0++;
					return dictionary;
				}
				int_0++;
			}
		}

		private List<object> method_2()
		{
			method_7('[');
			List<object> list = new List<object>();
			method_6();
			if (method_8() == ']')
			{
				int_0++;
				return list;
			}
			while (true)
			{
				list.Add(method_0());
				method_6();
				char c = string_0[int_0];
				switch (c)
				{
				case ',':
					break;
				default:
					throw new FormatException($"Expected ',' or ']' at {int_0}, got '{c}'");
				case ']':
					int_0++;
					return list;
				}
				int_0++;
			}
		}

		private string method_3()
		{
			method_7('"');
			StringBuilder stringBuilder = new StringBuilder();
			while (int_0 < string_0.Length)
			{
				char c = string_0[int_0++];
				switch (c)
				{
				case '\\':
				{
					char c2 = string_0[int_0++];
					switch (c2)
					{
					case '\\':
						stringBuilder.Append('\\');
						break;
					case '/':
						stringBuilder.Append('/');
						break;
					case '"':
						stringBuilder.Append('"');
						break;
					case 'f':
						stringBuilder.Append('\f');
						break;
					case 'b':
						stringBuilder.Append('\b');
						break;
					case 'r':
						stringBuilder.Append('\r');
						break;
					default:
						stringBuilder.Append(c2);
						break;
					case 't':
						stringBuilder.Append('\t');
						break;
					case 'u':
					{
						string value = string_0.Substring(int_0, 4);
						int_0 += 4;
						stringBuilder.Append((char)Convert.ToInt32(value, 16));
						break;
					}
					case 'n':
						stringBuilder.Append('\n');
						break;
					}
					break;
				}
				default:
					stringBuilder.Append(c);
					break;
				case '"':
					return stringBuilder.ToString();
				}
			}
			throw new FormatException("Unterminated string");
		}

		private double method_4()
		{
			int num = int_0;
			if (string_0[int_0] == '-')
			{
				int_0++;
			}
			while (int_0 < string_0.Length && (char.IsDigit(string_0[int_0]) || string_0[int_0] == '.' || string_0[int_0] == 'e' || string_0[int_0] == 'E' || string_0[int_0] == '+' || string_0[int_0] == '-'))
			{
				int_0++;
			}
			return double.Parse(string_0.Substring(num, int_0 - num), CultureInfo.InvariantCulture);
		}

		private object method_5(string string_1, object object_0)
		{
			if (string_0.Substring(int_0, string_1.Length) != string_1)
			{
				throw new FormatException($"Expected '{string_1}' at {int_0}");
			}
			int_0 += string_1.Length;
			return object_0;
		}

		private void method_6()
		{
			while (int_0 < string_0.Length && (string_0[int_0] == ' ' || string_0[int_0] == '\t' || string_0[int_0] == '\n' || string_0[int_0] == '\r'))
			{
				int_0++;
			}
		}

		private void method_7(char char_0)
		{
			if (int_0 >= string_0.Length || string_0[int_0] != char_0)
			{
				throw new FormatException($"Expected '{char_0}' at {int_0}, got '{((int_0 < string_0.Length) ? string_0[int_0] : '?')}'");
			}
			int_0++;
		}

		private char method_8()
		{
			if (int_0 < string_0.Length)
			{
				return string_0[int_0];
			}
			return '\0';
		}

		static Class23()
		{
			Class72.smethod_20();
		}
	}

	public static object Parse(string json)
	{
		if (json == null)
		{
			throw new ArgumentNullException("json");
		}
		return new Class23(json).method_0();
	}

	public static Dictionary<string, object> AsObject(object v)
	{
		return v as Dictionary<string, object>;
	}

	public static List<object> AsArray(object v)
	{
		return v as List<object>;
	}

	public static string AsString(object v)
	{
		return v as string;
	}

	public static double? AsDouble(object v)
	{
		if (v is double)
		{
			return (double)v;
		}
		if (v is string s && double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		return null;
	}

	public static float? AsFloat(object v)
	{
		double? num = AsDouble(v);
		if (!num.HasValue)
		{
			return null;
		}
		return (float)num.Value;
	}

	public static bool? AsBool(object v)
	{
		if (v is bool)
		{
			return (bool)v;
		}
		return null;
	}

	public static object Get(Dictionary<string, object> d, string key)
	{
		if (d == null)
		{
			return null;
		}
		if (!d.TryGetValue(key, out var value))
		{
			return null;
		}
		return value;
	}

	static MiniJson()
	{
		Class72.smethod_20();
	}
}
