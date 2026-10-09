using System;
using System.Runtime.InteropServices;

namespace Command;

public class DpiHelper
{
	private enum Enum0
	{

	}

	private static readonly IntPtr intptr_0;

	static DpiHelper()
	{
		Class72.smethod_20();
		intptr_0 = new IntPtr(-1);
	}

	[DllImport("user32.dll")]
	private static extern bool SetProcessDpiAwarenessContext(IntPtr intptr_1);

	[DllImport("user32.dll")]
	private static extern IntPtr GetThreadDpiAwarenessContext();

	[DllImport("user32.dll")]
	private static extern int GetAwarenessFromDpiAwarenessContext(IntPtr intptr_1);

	public static void SetUnaware()
	{
		SetProcessDpiAwarenessContext(intptr_0);
	}

	public static string StateDpiAwareness()
	{
		return "Current DPI Awareness: " + (Enum0)GetAwarenessFromDpiAwarenessContext(GetThreadDpiAwarenessContext())/*cast due to .constrained prefix*/;
	}
}
