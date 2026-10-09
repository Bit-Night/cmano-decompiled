using System;
using System.Runtime.InteropServices;

namespace WorldWind;

internal sealed class NativeMethods
{
	internal struct CopyDataStruct : IDisposable
	{
		public IntPtr dwData;

		public int cbData;

		public IntPtr lpData;

		public void Dispose()
		{
			if (lpData != IntPtr.Zero)
			{
				LocalFree(lpData);
				lpData = IntPtr.Zero;
			}
		}

		static CopyDataStruct()
		{
			Class72.smethod_20();
		}
	}

	public const int WM_COPYDATA = 74;

	public const int WM_ACTIVATEAPP = 28;

	private NativeMethods()
	{
	}

	[DllImport("user32.dll")]
	internal static extern bool SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref CopyDataStruct lParam);

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern IntPtr LocalAlloc(int flag, int size);

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern IntPtr LocalFree(IntPtr p);

	[DllImport("user32.dll")]
	internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

	public static bool SendArgs(IntPtr intptr_0, string args)
	{
		if (intptr_0 == IntPtr.Zero)
		{
			return false;
		}
		CopyDataStruct lParam = default(CopyDataStruct);
		try
		{
			lParam.cbData = (args.Length + 1) * 2;
			lParam.lpData = LocalAlloc(64, lParam.cbData);
			Marshal.Copy(args.ToCharArray(), 0, lParam.lpData, args.Length);
			lParam.dwData = (IntPtr)1;
			return SendMessage(intptr_0, 74, IntPtr.Zero, ref lParam);
		}
		finally
		{
			lParam.Dispose();
		}
	}

	static NativeMethods()
	{
		Class72.smethod_20();
	}
}
