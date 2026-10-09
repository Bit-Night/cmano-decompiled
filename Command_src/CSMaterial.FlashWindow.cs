using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CSMaterial;

public static class FlashWindow
{
	private struct Struct48
	{
		public uint uint_0;

		public IntPtr intptr_0;

		public uint uint_1;

		public uint uint_2;

		public uint uint_3;
	}

	public const uint FLASHW_STOP = 0u;

	public const uint FLASHW_CAPTION = 1u;

	public const uint FLASHW_TRAY = 2u;

	public const uint FLASHW_ALL = 3u;

	public const uint FLASHW_TIMER = 4u;

	public const uint FLASHW_TIMERNOFG = 12u;

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool FlashWindowEx(ref Struct48 struct48_0);

	public static bool Flash(Form form)
	{
		if (!smethod_1())
		{
			return false;
		}
		Struct48 struct48_ = smethod_0(((Control)form).Handle, 15u, uint.MaxValue, 0u);
		return FlashWindowEx(ref struct48_);
	}

	private static Struct48 smethod_0(IntPtr intptr_0, uint uint_0, uint uint_1, uint uint_2)
	{
		Struct48 @struct = default(Struct48);
		@struct.uint_0 = Convert.ToUInt32(Marshal.SizeOf(@struct));
		@struct.intptr_0 = intptr_0;
		@struct.uint_1 = uint_0;
		@struct.uint_2 = uint_1;
		@struct.uint_3 = uint_2;
		return @struct;
	}

	public static bool Flash(Form form, uint count)
	{
		if (smethod_1())
		{
			Struct48 struct48_ = smethod_0(((Control)form).Handle, 3u, count, 0u);
			return FlashWindowEx(ref struct48_);
		}
		return false;
	}

	public static bool Start(Form form)
	{
		if (smethod_1())
		{
			Struct48 struct48_ = smethod_0(((Control)form).Handle, 3u, uint.MaxValue, 0u);
			return FlashWindowEx(ref struct48_);
		}
		return false;
	}

	public static bool Stop(Form form)
	{
		if (smethod_1())
		{
			Struct48 struct48_ = smethod_0(((Control)form).Handle, 0u, uint.MaxValue, 0u);
			return FlashWindowEx(ref struct48_);
		}
		return false;
	}

	[SpecialName]
	private static bool smethod_1()
	{
		return Environment.OSVersion.Version.Major >= 5;
	}

	static FlashWindow()
	{
		Class72.smethod_20();
	}
}
