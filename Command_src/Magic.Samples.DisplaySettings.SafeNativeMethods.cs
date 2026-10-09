using System.Runtime.InteropServices;

namespace Magic.Samples.DisplaySettings;

public static class SafeNativeMethods
{
	public struct DEVMODE
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string dmDeviceName;

		[MarshalAs(UnmanagedType.U2)]
		public ushort dmSpecVersion;

		[MarshalAs(UnmanagedType.U2)]
		public ushort dmDriverVersion;

		[MarshalAs(UnmanagedType.U2)]
		public ushort dmSize;

		[MarshalAs(UnmanagedType.U2)]
		public ushort dmDriverExtra;

		[MarshalAs(UnmanagedType.U4)]
		public uint dmFields;

		public POINTL dmPosition;

		[MarshalAs(UnmanagedType.U4)]
		public uint dmDisplayOrientation;

		[MarshalAs(UnmanagedType.U4)]
		public uint dmDisplayFixedOutput;

		[MarshalAs(UnmanagedType.I2)]
		public short dmColor;

		[MarshalAs(UnmanagedType.I2)]
		public short dmDuplex;

		[MarshalAs(UnmanagedType.I2)]
		public short dmYResolution;

		[MarshalAs(UnmanagedType.I2)]
		public short short_0;

		[MarshalAs(UnmanagedType.I2)]
		public short dmCollate;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string dmFormName;

		[MarshalAs(UnmanagedType.U2)]
		public ushort dmLogPixels;

		[MarshalAs(UnmanagedType.U4)]
		public uint dmBitsPerPel;

		[MarshalAs(UnmanagedType.U4)]
		public uint dmPelsWidth;

		[MarshalAs(UnmanagedType.U4)]
		public uint dmPelsHeight;

		[MarshalAs(UnmanagedType.U4)]
		public uint dmDisplayFlags;

		[MarshalAs(UnmanagedType.U4)]
		public uint dmDisplayFrequency;

		[MarshalAs(UnmanagedType.U4)]
		public uint uint_0;

		[MarshalAs(UnmanagedType.U4)]
		public uint uint_1;

		[MarshalAs(UnmanagedType.U4)]
		public uint dmMediaType;

		[MarshalAs(UnmanagedType.U4)]
		public uint dmDitherType;

		[MarshalAs(UnmanagedType.U4)]
		public uint dmReserved1;

		[MarshalAs(UnmanagedType.U4)]
		public uint dmReserved2;

		[MarshalAs(UnmanagedType.U4)]
		public uint dmPanningWidth;

		[MarshalAs(UnmanagedType.U4)]
		public uint dmPanningHeight;

		public void Initialize()
		{
			dmDeviceName = new string(new char[32]);
			dmFormName = new string(new char[32]);
			dmSize = (ushort)Marshal.SizeOf(this);
		}

		static DEVMODE()
		{
			Class72.smethod_20();
		}
	}

	public struct POINTL
	{
		public int x;

		public int y;
	}

	public const int ENUM_CURRENT_SETTINGS = -1;

	public const int DMDO_DEFAULT = 0;

	public const int DMDO_90 = 1;

	public const int DMDO_180 = 2;

	public const int DMDO_270 = 3;

	public const uint FORMAT_MESSAGE_FROM_HMODULE = 2048u;

	public const uint FORMAT_MESSAGE_ALLOCATE_BUFFER = 256u;

	public const uint FORMAT_MESSAGE_IGNORE_INSERTS = 512u;

	public const uint FORMAT_MESSAGE_FROM_SYSTEM = 4096u;

	public const uint FORMAT_MESSAGE_FLAGS = 4864u;

	[DllImport("user32.dll", BestFitMapping = false, SetLastError = true, ThrowOnUnmappableChar = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumDisplaySettings([MarshalAs(UnmanagedType.LPTStr)] string lpszDeviceName, [MarshalAs(UnmanagedType.U4)] int iModeNum, [In][Out] ref DEVMODE lpDevMode);

	[DllImport("user32.dll", BestFitMapping = false, SetLastError = true, ThrowOnUnmappableChar = true)]
	[return: MarshalAs(UnmanagedType.I4)]
	public static extern int ChangeDisplaySettings([In][Out] ref DEVMODE lpDevMode, [MarshalAs(UnmanagedType.U4)] uint dwflags);

	[DllImport("kernel32.dll", BestFitMapping = false, SetLastError = true, ThrowOnUnmappableChar = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern uint FormatMessage([MarshalAs(UnmanagedType.U4)] uint dwFlags, [MarshalAs(UnmanagedType.U4)] uint lpSource, [MarshalAs(UnmanagedType.U4)] uint dwMessageId, [MarshalAs(UnmanagedType.U4)] uint dwLanguageId, [MarshalAs(UnmanagedType.LPTStr)] out string lpBuffer, [MarshalAs(UnmanagedType.U4)] uint nSize, [MarshalAs(UnmanagedType.U4)] uint Arguments);

	static SafeNativeMethods()
	{
		Class72.smethod_20();
	}
}
