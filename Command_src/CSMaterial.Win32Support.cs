using System;
using System.Runtime.InteropServices;

namespace CSMaterial;

public sealed class Win32Support
{
	public enum Bool
	{
		False,
		True
	}

	public enum TernaryRasterOperations
	{
		SRCCOPY = 13369376,
		SRCPAINT = 15597702,
		SRCAND = 8913094,
		SRCINVERT = 6684742,
		SRCERASE = 4457256,
		NOTSRCCOPY = 3342344,
		NOTSRCERASE = 1114278,
		MERGECOPY = 12583114,
		MERGEPAINT = 12255782,
		PATCOPY = 15728673,
		PATPAINT = 16452105,
		PATINVERT = 5898313,
		DSTINVERT = 5570569,
		BLACKNESS = 66,
		WHITENESS = 16711778
	}

	[DllImport("GDI32.DLL", ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

	[DllImport("GDI32.DLL", ExactSpelling = true, SetLastError = true)]
	public static extern Bool DeleteDC(IntPtr hdc);

	[DllImport("GDI32.DLL", ExactSpelling = true)]
	public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

	[DllImport("GDI32.DLL", ExactSpelling = true, SetLastError = true)]
	public static extern Bool DeleteObject(IntPtr hObject);

	[DllImport("GDI32.DLL", ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr CreateCompatibleBitmap(IntPtr hObject, int width, int height);

	[DllImport("GDI32.DLL", ExactSpelling = true, SetLastError = true)]
	public static extern Bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjSource, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);

	[DllImport("GDI32.DLL")]
	public static extern Bool GdiAlphaBlend(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int int_0, int int_1, int nWidthSrc, int nHeightSrc, BLENDFUNCTION blendFunction);

	static Win32Support()
	{
		Class72.smethod_20();
	}
}
