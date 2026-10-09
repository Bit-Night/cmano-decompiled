using System;
using System.IO;
using System.Threading;

namespace DiskQueue.Implementation;

public static class Atomic
{
	private static readonly object object_0;

	public static void Read(string path, Action<Stream> action)
	{
		lock (object_0)
		{
			if (FileExistsNative.FileExistsFast(path + ".old_copy") && smethod_0(path))
			{
				File.Move(path + ".old_copy", path);
			}
			using FileStream obj = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None, 65536, FileOptions.SequentialScan);
			SetPermissions.TryAllowReadWriteForAll(path);
			action(obj);
		}
	}

	public static void Write(string path, Action<Stream> action)
	{
		lock (object_0)
		{
			if (!FileExistsNative.FileExistsFast(path + ".old_copy"))
			{
				File.Move(path, path + ".old_copy");
			}
			using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 65536, FileOptions.WriteThrough | FileOptions.SequentialScan))
			{
				SetPermissions.TryAllowReadWriteForAll(path);
				action(fileStream);
				fileStream.Flush();
			}
			smethod_0(path + ".old_copy");
		}
	}

	private static bool smethod_0(string string_0)
	{
		for (int i = 0; i < 5; i++)
		{
			try
			{
				File.Delete(string_0);
				return true;
			}
			catch
			{
				Thread.Sleep(100);
			}
		}
		return false;
	}

	static Atomic()
	{
		Class72.smethod_20();
		object_0 = new object();
	}
}
