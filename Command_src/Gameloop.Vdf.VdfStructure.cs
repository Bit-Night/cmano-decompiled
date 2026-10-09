namespace Gameloop.Vdf;

public static class VdfStructure
{
	public const char Quote = '"';

	public const char Escape = '\\';

	public const char Comment = '/';

	public const char Assign = ' ';

	public const char Indent = '\t';

	public const char ConditionalStart = '[';

	public const char ConditionalEnd = ']';

	public const char ObjectStart = '{';

	public const char ObjectEnd = '}';

	public const string string_0 = "$X360";

	public const string ConditionalWin32 = "$WIN32";

	public const string ConditionalWindows = "$WINDOWS";

	public const string ConditionalOSX = "$OSX";

	public const string ConditionalLinux = "$LINUX";

	public const string ConditionalPosix = "$POSIX";

	private static readonly bool[] bool_0;

	private static readonly char[] char_0;

	private static readonly char[] char_1;

	private static readonly char[,] char_2;

	static VdfStructure()
	{
		Class72.smethod_20();
		char_2 = new char[11, 2]
		{
			{ '\n', 'n' },
			{ '\t', 't' },
			{ '\v', 'v' },
			{ '\b', 'b' },
			{ '\r', 'r' },
			{ '\f', 'f' },
			{ '\a', 'a' },
			{ '\\', '\\' },
			{ '?', '?' },
			{ '\'', '\'' },
			{ '"', '"' }
		};
		bool_0 = new bool[128];
		char_0 = new char[128];
		char_1 = new char[128];
		for (int i = 0; i < 128L; i++)
		{
			char_0[i] = (char_1[i] = (char)i);
		}
		for (int j = 0; j < char_2.GetLength(0); j++)
		{
			char c = char_2[j, 0];
			char c2 = char_2[j, 1];
			bool_0[(uint)c] = true;
			char_0[(uint)c] = c2;
			char_1[(uint)c2] = c;
		}
	}

	public static bool IsEscapable(char ch)
	{
		if ((uint)ch >= 128u)
		{
			return false;
		}
		return bool_0[(uint)ch];
	}

	public static char GetEscape(char ch)
	{
		if ((uint)ch < 128u)
		{
			return char_0[(uint)ch];
		}
		return ch;
	}

	public static char GetUnescape(char ch)
	{
		if ((uint)ch >= 128u)
		{
			return ch;
		}
		return char_1[(uint)ch];
	}
}
