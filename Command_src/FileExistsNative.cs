using System;
using System.Runtime.InteropServices;
using System.Text;
using ThreadSafeCollections;

public static class FileExistsNative
{
	[ThreadStatic]
	private static StringBuilder stringBuilder_0;

	private static TDictionary<string, bool> tdictionary_0;

	[DllImport("shlwapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool PathFileExists(StringBuilder stringBuilder_1);

	public static bool FileExistsFast(string theFileName)
	{
		if (stringBuilder_0 != null)
		{
			stringBuilder_0.Clear();
		}
		else
		{
			stringBuilder_0 = new StringBuilder();
		}
		stringBuilder_0.Append(theFileName);
		return PathFileExists(stringBuilder_0);
	}

	public static bool FileExistsFast_CheckOnlyOnce(string theFileName)
	{
		if (tdictionary_0.TryGetValue(theFileName, out var value))
		{
			return value;
		}
		if (stringBuilder_0 == null)
		{
			stringBuilder_0 = new StringBuilder();
		}
		else
		{
			stringBuilder_0.Clear();
		}
		stringBuilder_0.Append(theFileName);
		bool flag = PathFileExists(stringBuilder_0);
		tdictionary_0.AddIfNotExists(theFileName, flag);
		return flag;
	}

	static FileExistsNative()
	{
		Class72.smethod_20();
		tdictionary_0 = new TDictionary<string, bool>();
	}
}
