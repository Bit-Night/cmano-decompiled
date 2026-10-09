using System;

namespace Imazen.WebP.Extern;

public struct WebPRGBABuffer
{
	public IntPtr rgba;

	public int stride;

	public UIntPtr size;
}
