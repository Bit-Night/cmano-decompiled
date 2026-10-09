using System;
using System.Runtime.InteropServices;

namespace CSMaterial.DeferWindowsPos;

public static class NativeMethods
{
	[DllImport("user32.dll")]
	private static extern IntPtr DeferWindowPos(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2, int int_0, int int_1, int int_2, int int_3, uint uint_0);

	[DllImport("user32.dll")]
	private static extern IntPtr BeginDeferWindowPos(int int_0);

	[DllImport("user32.dll")]
	private static extern bool EndDeferWindowPos(IntPtr intptr_0);

	static NativeMethods()
	{
		Class72.smethod_20();
	}
}
