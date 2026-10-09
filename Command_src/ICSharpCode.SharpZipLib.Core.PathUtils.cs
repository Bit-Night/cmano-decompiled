using System.IO;
using System.Linq;

namespace ICSharpCode.SharpZipLib.Core;

public static class PathUtils
{
	public static string DropPathRoot(string path)
	{
		if (!(path == string.Empty))
		{
			char[] char_0 = Path.GetInvalidPathChars();
			bool bool_0 = path.Length >= 3 && path[1] == ':' && path[2] == ':';
			int num;
			for (num = Path.GetPathRoot(new string(path.Take(258).Select(delegate(char c, int i)
			{
				int result;
				if (!char_0.Contains(c))
				{
					if (!(i == 2 && bool_0))
					{
						return c;
					}
					result = 95;
				}
				else
				{
					result = 95;
				}
				return (char)result;
			}).ToArray()))?.Length ?? 0; path.Length > num && (path[num] == '/' || path[num] == '\\'); num++)
			{
			}
			return path.Substring(num);
		}
		return path;
	}

	public static string GetTempFileName(string original = null)
	{
		string tempPath = Path.GetTempPath();
		string text;
		do
		{
			text = ((original == null) ? Path.Combine(tempPath, Path.GetRandomFileName()) : (original + "." + Path.GetRandomFileName()));
		}
		while (File.Exists(text));
		return text;
	}

	static PathUtils()
	{
		Class72.smethod_20();
	}
}
