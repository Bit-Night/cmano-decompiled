using System;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip;

public class WindowsNameTransform : INameTransform
{
	private string string_0;

	private bool bool_0;

	private char char_0 = '_';

	private bool bool_1;

	private static readonly char[] char_1;

	public string BaseDirectory
	{
		get
		{
			return string_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			string_0 = Path.GetFullPath(value);
		}
	}

	public bool AllowParentTraversal
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool TrimIncomingPaths
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public char Replacement
	{
		get
		{
			return char_0;
		}
		set
		{
			int num = 0;
			while (true)
			{
				if (num < char_1.Length)
				{
					if (char_1[num] != value)
					{
						num++;
						continue;
					}
					throw new ArgumentException("invalid path character");
				}
				if (value != Path.DirectorySeparatorChar && value != Path.AltDirectorySeparatorChar)
				{
					break;
				}
				throw new ArgumentException("invalid replacement character");
			}
			char_0 = value;
		}
	}

	public WindowsNameTransform(string baseDirectory, bool allowParentTraversal = false)
	{
		BaseDirectory = baseDirectory ?? throw new ArgumentNullException("baseDirectory", "Directory name is invalid");
		AllowParentTraversal = allowParentTraversal;
	}

	public WindowsNameTransform()
	{
	}

	public string TransformDirectory(string name)
	{
		name = TransformFile(name);
		if (name.Length <= 0)
		{
			throw new InvalidNameException("Cannot have an empty directory name");
		}
		while (true)
		{
			string text = name;
			char directorySeparatorChar = Path.DirectorySeparatorChar;
			if (!text.EndsWith(directorySeparatorChar.ToString(), StringComparison.Ordinal))
			{
				break;
			}
			name = name.Remove(name.Length - 1, 1);
		}
		return name;
	}

	public string TransformFile(string name)
	{
		if (name == null)
		{
			name = string.Empty;
		}
		else
		{
			name = MakeValidName(name, char_0);
			if (bool_0)
			{
				name = Path.GetFileName(name);
			}
			if (string_0 != null)
			{
				name = Path.Combine(string_0, name);
				string text = Path.GetFullPath(string_0);
				if (text[text.Length - 1] != Path.DirectorySeparatorChar)
				{
					string text2 = text;
					char directorySeparatorChar = Path.DirectorySeparatorChar;
					text = text2 + directorySeparatorChar;
				}
				if (!bool_1 && !Path.GetFullPath(name).StartsWith(text, StringComparison.InvariantCultureIgnoreCase))
				{
					throw new InvalidNameException("Parent traversal in paths is not allowed");
				}
			}
		}
		return name;
	}

	public static bool IsValidName(string name)
	{
		int result;
		if (name == null)
		{
			result = 0;
		}
		else
		{
			if (name.Length <= 260)
			{
				return string.Compare(name, MakeValidName(name, '_'), StringComparison.Ordinal) == 0;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public static string MakeValidName(string name, char replacement)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		string text = name;
		char directorySeparatorChar = Path.DirectorySeparatorChar;
		name = PathUtils.DropPathRoot(text.Replace("/", directorySeparatorChar.ToString()));
		while (name.Length > 0 && name[0] == Path.DirectorySeparatorChar)
		{
			name = name.Remove(0, 1);
		}
		while (name.Length > 0 && name[name.Length - 1] == Path.DirectorySeparatorChar)
		{
			name = name.Remove(name.Length - 1, 1);
		}
		int num;
		for (num = name.IndexOf(string.Format("{0}{0}", Path.DirectorySeparatorChar), StringComparison.Ordinal); num >= 0; num = name.IndexOf(string.Format("{0}{0}", Path.DirectorySeparatorChar), StringComparison.Ordinal))
		{
			name = name.Remove(num, 1);
		}
		num = name.IndexOfAny(char_1);
		if (num >= 0)
		{
			StringBuilder stringBuilder = new StringBuilder(name);
			while (num >= 0)
			{
				stringBuilder[num] = replacement;
				num = ((num < name.Length) ? name.IndexOfAny(char_1, num + 1) : (-1));
			}
			name = stringBuilder.ToString();
		}
		if (name.Length > 260)
		{
			throw new PathTooLongException();
		}
		return name;
	}

	static WindowsNameTransform()
	{
		Class72.smethod_20();
		char_1 = new char[39]
		{
			'"', '<', '>', '|', '\0', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005',
			'\u0006', '\a', '\b', '\t', '\n', '\v', '\f', '\r', '\u000e', '\u000f',
			'\u0010', '\u0011', '\u0012', '\u0013', '\u0014', '\u0015', '\u0016', '\u0017', '\u0018', '\u0019',
			'\u001a', '\u001b', '\u001c', '\u001d', '\u001e', '\u001f', '*', '?', ':'
		};
	}
}
