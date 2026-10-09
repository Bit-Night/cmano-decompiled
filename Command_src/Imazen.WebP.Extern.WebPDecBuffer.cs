using System;
using System.Runtime.InteropServices;

namespace Imazen.WebP.Extern;

public struct WebPDecBuffer
{
	public WEBP_CSP_MODE colorspace;

	public int width;

	public int height;

	public int is_external_memory;

	public Anonymous_690ed5ec_4c3d_40c6_9bd0_0747b5a28b54 u;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
	public uint[] pad;

	public IntPtr private_memory;
}
