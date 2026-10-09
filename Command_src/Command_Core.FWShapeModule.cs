using System;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class FWShapeModule
{
	public delegate int Remove_Func([MarshalAs(UnmanagedType.LPStr)] string filename);

	public delegate int FClose_Func(int file);

	public struct SAHooks
	{
		public FClose_Func FClose;

		public Remove_Func Remove;
	}

	public struct SHPInfo
	{
		public SAHooks sHooks;
	}

	[DllImport("shapelib.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern void SHPClose(IntPtr hSHP);

	static FWShapeModule()
	{
		Class72.smethod_20();
	}
}
