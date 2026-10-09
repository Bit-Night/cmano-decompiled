using System;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip;

public class ZipNameTransform : INameTransform
{
	private string string_0;

	private static readonly char[] char_0;

	private static readonly char[] char_1;

	public string TrimPrefix
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			if (string_0 != null)
			{
				string_0 = string_0.ToLower();
			}
		}
	}

	public ZipNameTransform()
	{
	}

	public ZipNameTransform(string trimPrefix)
	{
		TrimPrefix = trimPrefix;
	}

	static ZipNameTransform()
	{
		Class72.smethod_20();
		char[] invalidPathChars = Path.GetInvalidPathChars();
		int num = invalidPathChars.Length + 2;
		char_1 = new char[num];
		Array.Copy(invalidPathChars, 0, char_1, 0, invalidPathChars.Length);
		char_1[num - 1] = '*';
		char_1[num - 2] = '?';
		num = invalidPathChars.Length + 4;
		char_0 = new char[num];
		Array.Copy(invalidPathChars, 0, char_0, 0, invalidPathChars.Length);
		char_0[num - 1] = ':';
		char_0[num - 2] = '\\';
		char_0[num - 3] = '*';
		char_0[num - 4] = '?';
	}

	public string TransformDirectory(string name)
	{
		name = TransformFile(name);
		if (name.Length > 0)
		{
			if (!name.EndsWith("/", StringComparison.Ordinal))
			{
				name += "/";
			}
			return name;
		}
		throw new ZipException("Cannot have an empty directory name");
	}

	public string TransformFile(string name)
	{
		if (name == null)
		{
			name = string.Empty;
		}
		else
		{
			string text = name.ToLower();
			if (string_0 != null && text.IndexOf(string_0, StringComparison.Ordinal) == 0)
			{
				name = name.Substring(string_0.Length);
			}
			name = name.Replace("\\", "/");
			name = PathUtils.DropPathRoot(name);
			name = name.Trim(new char[1] { '/' });
			for (int num = name.IndexOf("//", StringComparison.Ordinal); num >= 0; num = name.IndexOf("//", StringComparison.Ordinal))
			{
				name = name.Remove(num, 1);
			}
			name = smethod_0(name, '_');
		}
		return name;
	}

	private static string smethod_0(string string_1, char char_2)
	{
		int num = string_1.IndexOfAny(char_0);
		if (num >= 0)
		{
			StringBuilder stringBuilder = new StringBuilder(string_1);
			while (num >= 0)
			{
				stringBuilder[num] = char_2;
				num = ((num < string_1.Length) ? string_1.IndexOfAny(char_0, num + 1) : (-1));
			}
			string_1 = stringBuilder.ToString();
		}
		if (string_1.Length > 65535)
		{
			throw new PathTooLongException();
		}
		return string_1;
	}

	public static bool IsValidName(string name, bool relaxed)
	{
		bool result;
		if (result = name != null)
		{
			result = (relaxed ? (name.IndexOfAny(char_1) < 0) : (name.IndexOfAny(char_0) < 0 && name.IndexOf('/') != 0));
		}
		return result;
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
			if (name.IndexOfAny(char_0) < 0)
			{
				return name.IndexOf('/') != 0;
			}
			result = 0;
		}
		return (byte)result != 0;
	}
}
