using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Command_Core;

internal class NativeMethods
{
	internal const int ERROR_IO_PENDING = 997;

	internal const int ERROR_PIPE_CONNECTED = 535;

	internal const int FILE_FLAG_OVERLAPPED = 1073741824;

	internal const int NMPWAIT_WAIT_FOREVER = 65535;

	internal const int PIPE_TYPE_BYTE = 0;

	internal const int PIPE_UNLIMITED_INSTANCES = 255;

	internal const int PIPE_WAIT = 0;

	[DllImport("kernel32.dll")]
	public static extern bool GetOverlappedResult(IntPtr hFile, [In] ref NativeOverlapped lpOverlapped, out uint lpNumberOfBytesTransferred, bool bWait);

	[DllImport("kernel32.dll")]
	internal static extern uint WaitForMultipleObjects(uint nCount, IntPtr[] lpHandles, bool bWaitAll, uint dwMilliseconds);

	[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
	internal static extern int ConnectNamedPipe(IntPtr hNamedPipe, [In] ref NativeOverlapped lpOverlapped);

	[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
	internal static extern IntPtr CreateFile(string lpFileName, int dwDesiredAccess, int dwShareMode, int lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);

	[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
	internal static extern IntPtr CreateNamedPipe(string lpName, int dwOpenMode, int dwPipeMode, int nMaxInstances, int nOutBufferSize, int nInBufferSize, int nDefaultTimeOut, IntPtr lpSecurityAttributes);

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern bool DisconnectNamedPipe(IntPtr hNamedPipe);

	[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
	internal static extern int WaitNamedPipe(string lpNamedPipeName, ushort nTimeOut);

	static NativeMethods()
	{
		Class72.smethod_20();
	}
}
