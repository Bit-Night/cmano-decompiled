using System;

namespace Imazen.WebP.Extern;

public struct WebPYUVABuffer
{
	public IntPtr y;

	public IntPtr u;

	public IntPtr v;

	public IntPtr a;

	public int y_stride;

	public int u_stride;

	public int v_stride;

	public int a_stride;

	public UIntPtr y_size;

	public UIntPtr u_size;

	public UIntPtr v_size;

	public UIntPtr a_size;
}
