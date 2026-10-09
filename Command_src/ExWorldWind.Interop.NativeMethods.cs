using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;

namespace ExWorldWind.Interop;

public sealed class NativeMethods
{
	public struct Message
	{
		public IntPtr hWnd;

		public uint msg;

		public IntPtr wParam;

		public IntPtr lParam;

		public uint time;

		public Point p;
	}

	private NativeMethods()
	{
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool PeekMessage(out Message msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);

	static NativeMethods()
	{
		Class72.smethod_20();
	}
}
