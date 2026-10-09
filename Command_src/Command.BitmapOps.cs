using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using CSMaterial;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class BitmapOps
{
	private struct Struct7
	{
		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		public Struct7(byte byte_4, byte byte_5, byte byte_6, byte byte_7)
		{
			this = default(Struct7);
			byte_0 = byte_4;
			byte_1 = byte_5;
			byte_2 = byte_6;
			byte_3 = byte_7;
		}

		static Struct7()
		{
			Class72.smethod_20();
		}
	}

	[DllImport("GDI32.DLL", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern bool GdiAlphaBlend(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, IntPtr intptr_1, int int_4, int int_5, int int_6, int int_7, Struct7 struct7_0);

	public static bool AlphaBlend_PInvoke(IntPtr intptr_0, Bitmap theImage, int PositionX, int PositionY, int theWidth, int theHeight)
	{
		bool result = false;
		try
		{
			if (((Image)theImage).Width != theWidth || ((Image)theImage).Height != theHeight)
			{
				theImage = Module1.ResizeImage(theImage, new Size(theWidth, theHeight), preserveAspectRatio: false);
			}
			IntPtr intPtr = Win32Support.CreateCompatibleDC(intptr_0);
			if (!Client.Cache_GDIBitmapHandles.TryGetValue((Image)(object)theImage, out var value))
			{
				value = theImage.GetHbitmap(Color.Black);
				Client.Cache_GDIBitmapHandles.Add((Image)(object)theImage, value);
			}
			IntPtr hObject = Win32Support.SelectObject(intPtr, value);
			result = GdiAlphaBlend(intptr_0, PositionX, PositionY, ((Image)theImage).Width, ((Image)theImage).Height, intPtr, 0, 0, ((Image)theImage).Width, ((Image)theImage).Height, new Struct7(0, 0, byte.MaxValue, 1));
			Win32Support.SelectObject(intPtr, hObject);
			Win32Support.DeleteDC(intPtr);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static BitmapOps()
	{
		Class72.smethod_20();
	}
}
