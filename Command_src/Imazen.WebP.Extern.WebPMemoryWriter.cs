using System;
using System.Runtime.InteropServices;

namespace Imazen.WebP.Extern;

public struct WebPMemoryWriter
{
	public IntPtr mem;

	public UIntPtr size;

	public UIntPtr max_size;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.U4)]
	public uint[] pad;
}
