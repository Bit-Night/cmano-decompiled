using System.Runtime.InteropServices;

namespace DiskQueue.Implementation.CrossPlatform.Unix;

public sealed class UnsafeNativeMethods
{
	[DllImport("libc", BestFitMapping = false, CharSet = CharSet.Ansi, EntryPoint = "chmod", SetLastError = true, ThrowOnUnmappableChar = true)]
	private static extern int chmod_1(string string_0, uint uint_0);

	public static int chmod(string path, UnixFilePermissions mode)
	{
		return 0;
	}

	static UnsafeNativeMethods()
	{
		Class72.smethod_20();
	}
}
