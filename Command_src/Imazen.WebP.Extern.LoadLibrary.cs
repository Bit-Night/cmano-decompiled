using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Imazen.WebP.Extern;

public static class LoadLibrary
{
	private static object object_0;

	private static Dictionary<string, IntPtr> dictionary_0;

	[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	private static extern IntPtr LoadLibraryEx(string string_0, IntPtr intptr_0, uint uint_0);

	public static bool EnsureLoadedByPath(string fullPath, bool throwException)
	{
		fullPath = Path.GetFullPath(fullPath);
		lock (object_0)
		{
			if (dictionary_0.TryGetValue(fullPath, out var value))
			{
				return true;
			}
			value = LoadByPath(fullPath, throwException);
			if (value != IntPtr.Zero)
			{
				dictionary_0.Add(fullPath, value);
				return true;
			}
		}
		return false;
	}

	public static IntPtr LoadByPath(string fullPath, bool throwException)
	{
		IntPtr intPtr = LoadLibraryEx(fullPath, IntPtr.Zero, 2304u);
		if (intPtr == IntPtr.Zero && throwException)
		{
			throw new Win32Exception(Marshal.GetLastWin32Error());
		}
		return intPtr;
	}

	public static void LoadWebPOrFail()
	{
		if (!AutoLoadNearby("libwebp.dll", throwFailure: true))
		{
			throw new FileNotFoundException("Failed to locate libwebp.dll");
		}
	}

	public static bool AutoLoadNearby(string name, bool throwFailure)
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		return AutoLoad(name, new string[2]
		{
			Path.GetDirectoryName(executingAssembly.Location),
			Path.GetDirectoryName(new Uri(executingAssembly.CodeBase).LocalPath)
		}, throwFailure, throwFailure);
	}

	public static bool AutoLoad(string name, string[] searchFolders, bool throwNotFound, bool throwExceptions)
	{
		string text = "";
		int num = 0;
		while (true)
		{
			if (num < searchFolders.Length)
			{
				string text2 = Path.Combine(Path.Combine(searchFolders[num], (IntPtr.Size == 8) ? "x64" : "x86"), name);
				if (string.IsNullOrEmpty(Path.GetExtension(text2)))
				{
					text2 += ".dll";
				}
				text = text + "\"" + text2 + "\", ";
				if (FileExistsNative.FileExistsFast(text2) && EnsureLoadedByPath(text2, throwExceptions))
				{
					break;
				}
				num++;
				continue;
			}
			if (throwNotFound)
			{
				throw new FileNotFoundException("Failed to locate '" + name + "' as " + text.TrimEnd(' ', ','));
			}
			return false;
		}
		return true;
	}

	static LoadLibrary()
	{
		Class72.smethod_20();
		object_0 = new object();
		dictionary_0 = new Dictionary<string, IntPtr>(StringComparer.OrdinalIgnoreCase);
	}
}
