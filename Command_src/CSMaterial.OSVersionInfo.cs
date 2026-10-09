using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace CSMaterial;

public static class OSVersionInfo
{
	public enum SoftwareArchitecture
	{
		Unknown,
		Bit32,
		Bit64
	}

	public enum ProcessorArchitecture
	{
		Unknown,
		Bit32,
		Bit64,
		const_3
	}

	private delegate bool Delegate5([In] IntPtr handle, out bool isWow64Process);

	private struct Struct47
	{
		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;

		public int int_4;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string string_0;

		public short short_0;

		public short short_1;

		public short short_2;

		public byte byte_0;

		public byte byte_1;
	}

	public struct SYSTEM_INFO
	{
		internal _PROCESSOR_INFO_UNION uProcessorInfo;

		public uint dwPageSize;

		public IntPtr lpMinimumApplicationAddress;

		public IntPtr lpMaximumApplicationAddress;

		public IntPtr dwActiveProcessorMask;

		public uint dwNumberOfProcessors;

		public uint dwProcessorType;

		public uint dwAllocationGranularity;

		public ushort dwProcessorLevel;

		public ushort dwProcessorRevision;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct _PROCESSOR_INFO_UNION
	{
		[FieldOffset(0)]
		internal uint dwOemId;

		[FieldOffset(0)]
		internal ushort wProcessorArchitecture;

		[FieldOffset(2)]
		internal ushort wReserved;
	}

	private static string string_0;

	private static string string_1;

	public static SoftwareArchitecture ProgramBits
	{
		get
		{
			SoftwareArchitecture softwareArchitecture = SoftwareArchitecture.Unknown;
			Environment.GetEnvironmentVariables();
			return (IntPtr.Size * 8) switch
			{
				64 => SoftwareArchitecture.Bit64, 
				32 => SoftwareArchitecture.Bit32, 
				_ => SoftwareArchitecture.Unknown, 
			};
		}
	}

	public static SoftwareArchitecture OSBits
	{
		get
		{
			SoftwareArchitecture softwareArchitecture = SoftwareArchitecture.Unknown;
			switch (IntPtr.Size * 8)
			{
			case 64:
				return SoftwareArchitecture.Bit64;
			default:
				return SoftwareArchitecture.Unknown;
			case 32:
				if (smethod_1())
				{
					return SoftwareArchitecture.Bit64;
				}
				return SoftwareArchitecture.Bit32;
			}
		}
	}

	public static ProcessorArchitecture ProcessorBits
	{
		get
		{
			ProcessorArchitecture result = ProcessorArchitecture.Unknown;
			try
			{
				SYSTEM_INFO lpSystemInfo = default(SYSTEM_INFO);
				GetNativeSystemInfo(ref lpSystemInfo);
				result = lpSystemInfo.uProcessorInfo.wProcessorArchitecture switch
				{
					0 => ProcessorArchitecture.Bit32, 
					9 => ProcessorArchitecture.Bit64, 
					6 => ProcessorArchitecture.const_3, 
					_ => ProcessorArchitecture.Unknown, 
				};
			}
			catch
			{
			}
			return result;
		}
	}

	public static string Edition
	{
		get
		{
			if (string_0 == null)
			{
				string result = string.Empty;
				OperatingSystem oSVersion = Environment.OSVersion;
				Struct47 struct47_ = new Struct47
				{
					int_0 = Marshal.SizeOf(typeof(Struct47))
				};
				if (GetVersionEx(ref struct47_))
				{
					int major = oSVersion.Version.Major;
					int minor = oSVersion.Version.Minor;
					byte byte_ = struct47_.byte_0;
					short short_ = struct47_.short_2;
					switch (major)
					{
					case 4:
						switch (byte_)
						{
						case 1:
							result = "Workstation";
							break;
						case 3:
							result = (((short_ & 2) != 0) ? "Enterprise Server" : "Standard Server");
							break;
						}
						break;
					case 5:
						switch (byte_)
						{
						case 1:
							result = (((short_ & 0x200) == 0) ? ((GetSystemMetrics(86) == 0) ? "Professional" : "Tablet Edition") : "Home");
							break;
						case 3:
							result = ((minor != 0) ? (((short_ & 0x80) == 0) ? (((short_ & 2) == 0) ? (((short_ & 0x400) == 0) ? "Standard" : "Web Edition") : "Enterprise") : "Datacenter") : (((short_ & 0x80) == 0) ? (((short_ & 2) != 0) ? "Advanced Server" : "Server") : "Datacenter Server"));
							break;
						}
						break;
					case 6:
					{
						if (GetProductInfo(major, minor, struct47_.short_0, struct47_.short_1, out var edition))
						{
							switch (edition)
							{
							case 0:
								result = "Unknown product";
								break;
							case 1:
								result = "Ultimate";
								break;
							case 2:
								result = "Home Basic";
								break;
							case 3:
								result = "Home Premium";
								break;
							case 4:
								result = "Enterprise";
								break;
							case 5:
								result = "Home Basic N";
								break;
							case 6:
								result = "Business";
								break;
							case 7:
								result = "Standard Server";
								break;
							case 8:
								result = "Datacenter Server";
								break;
							case 9:
								result = "Windows Small Business Server";
								break;
							case 10:
								result = "Enterprise Server";
								break;
							case 11:
								result = "Starter";
								break;
							case 12:
								result = "Datacenter Server (core installation)";
								break;
							case 13:
								result = "Standard Server (core installation)";
								break;
							case 14:
								result = "Enterprise Server (core installation)";
								break;
							case 15:
								result = "Enterprise Server for Itanium-based Systems";
								break;
							case 16:
								result = "Business N";
								break;
							case 17:
								result = "Web Server";
								break;
							case 18:
								result = "HPC Edition";
								break;
							case 20:
								result = "Express Storage Server";
								break;
							case 21:
								result = "Standard Storage Server";
								break;
							case 22:
								result = "Workgroup Storage Server";
								break;
							case 23:
								result = "Enterprise Storage Server";
								break;
							case 24:
								result = "Windows Essential Server Solutions";
								break;
							case 25:
								result = "Windows Small Business Server Premium";
								break;
							case 26:
								result = "Home Premium N";
								break;
							case 27:
								result = "Enterprise N";
								break;
							case 28:
								result = "Ultimate N";
								break;
							case 29:
								result = "Web Server (core installation)";
								break;
							case 30:
								result = "Windows Essential Business Management Server";
								break;
							case 31:
								result = "Windows Essential Business Security Server";
								break;
							case 32:
								result = "Windows Essential Business Messaging Server";
								break;
							case 33:
								result = "Server Foundation";
								break;
							case 34:
								result = "Home Premium Server";
								break;
							case 35:
								result = "Windows Essential Server Solutions without Hyper-V";
								break;
							case 36:
								result = "Standard Server without Hyper-V";
								break;
							case 37:
								result = "Datacenter Server without Hyper-V";
								break;
							case 38:
								result = "Enterprise Server without Hyper-V";
								break;
							case 39:
								result = "Datacenter Server without Hyper-V (core installation)";
								break;
							case 40:
								result = "Standard Server without Hyper-V (core installation)";
								break;
							case 41:
								result = "Enterprise Server without Hyper-V (core installation)";
								break;
							case 42:
								result = "Microsoft Hyper-V Server";
								break;
							case 43:
								result = "Express Storage Server (core installation)";
								break;
							case 44:
								result = "Standard Storage Server (core installation)";
								break;
							case 45:
								result = "Workgroup Storage Server (core installation)";
								break;
							case 46:
								result = "Enterprise Storage Server (core installation)";
								break;
							case 47:
								result = "Starter N";
								break;
							case 48:
								result = "Professional";
								break;
							case 49:
								result = "Professional N";
								break;
							case 50:
								result = "SB Solution Server";
								break;
							case 51:
								result = "Server for SB Solutions";
								break;
							case 52:
								result = "Standard Server Solutions";
								break;
							case 53:
								result = "Standard Server Solutions (core installation)";
								break;
							case 54:
								result = "SB Solution Server EM";
								break;
							case 55:
								result = "Server for SB Solutions EM";
								break;
							case 56:
								result = "Solution Embedded Server";
								break;
							case 57:
								result = "Solution Embedded Server (core installation)";
								break;
							case 59:
								result = "Essential Business Server MGMT";
								break;
							case 60:
								result = "Essential Business Server ADDL";
								break;
							case 61:
								result = "Essential Business Server MGMTSVC";
								break;
							case 62:
								result = "Essential Business Server ADDLSVC";
								break;
							case 63:
								result = "Windows Small Business Server Premium (core installation)";
								break;
							case 64:
								result = "HPC Edition without Hyper-V";
								break;
							case 65:
								result = "Embedded";
								break;
							case 66:
								result = "Starter E";
								break;
							case 67:
								result = "Home Basic E";
								break;
							case 68:
								result = "Home Premium E";
								break;
							case 69:
								result = "Professional E";
								break;
							case 70:
								result = "Enterprise E";
								break;
							case 71:
								result = "Ultimate E";
								break;
							}
						}
						break;
					}
					}
				}
				string_0 = result;
				return result;
			}
			return string_0;
		}
	}

	public static string Name
	{
		get
		{
			if (string_1 != null)
			{
				return string_1;
			}
			string result = "unknown";
			OperatingSystem oSVersion = Environment.OSVersion;
			Struct47 struct47_ = new Struct47
			{
				int_0 = Marshal.SizeOf(typeof(Struct47))
			};
			if (GetVersionEx(ref struct47_))
			{
				int num = oSVersion.Version.Major;
				int num2 = oSVersion.Version.Minor;
				if (num == 6 && num2 == 2)
				{
					string text = smethod_3("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "CurrentVersion", "");
					if (!string.IsNullOrEmpty(text))
					{
						string[] array = text.Split(new char[1] { '.' });
						num = Convert.ToInt32(array[0]);
						num2 = Convert.ToInt32(array[1]);
					}
					if (smethod_2())
					{
						num = 10;
						num2 = 0;
					}
					if (OpreofTkxg8())
					{
						num = 11;
						num2 = 0;
					}
				}
				switch (oSVersion.Platform)
				{
				case PlatformID.Win32S:
					result = "Windows 3.1";
					break;
				case PlatformID.Win32Windows:
					if (num == 4)
					{
						string text2 = struct47_.string_0;
						switch (num2)
						{
						case 0:
							result = ((text2 == "B" || text2 == "C") ? "Windows 95 OSR2" : "Windows 95");
							break;
						case 90:
							result = "Windows Me";
							break;
						case 10:
							result = ((!(text2 == "A")) ? "Windows 98" : "Windows 98 Second Edition");
							break;
						}
					}
					break;
				case PlatformID.Win32NT:
				{
					byte byte_ = struct47_.byte_0;
					switch (num)
					{
					case 3:
						result = "Windows NT 3.51";
						break;
					case 4:
						switch (byte_)
						{
						case 3:
							result = "Windows NT 4.0 Server";
							break;
						case 1:
							result = "Windows NT 4.0";
							break;
						}
						break;
					case 5:
						switch (num2)
						{
						case 0:
							result = "Windows 2000";
							break;
						case 1:
							result = "Windows XP";
							break;
						case 2:
							result = "Windows Server 2003";
							break;
						}
						break;
					case 6:
						switch (num2)
						{
						case 0:
							switch (byte_)
							{
							case 3:
								result = "Windows Server 2008";
								break;
							case 1:
								result = "Windows Vista";
								break;
							}
							break;
						case 1:
							switch (byte_)
							{
							case 3:
								result = "Windows Server 2008 R2";
								break;
							case 1:
								result = "Windows 7";
								break;
							}
							break;
						case 2:
							switch (byte_)
							{
							case 3:
								result = "Windows Server 2012";
								break;
							case 1:
								result = "Windows 8";
								break;
							}
							break;
						case 3:
							switch (byte_)
							{
							case 3:
								result = "Windows Server 2012 R2";
								break;
							case 1:
								result = "Windows 8.1";
								break;
							}
							break;
						}
						break;
					case 10:
						if (num2 == 0)
						{
							switch (byte_)
							{
							case 3:
								result = "Windows Server 2016";
								break;
							case 1:
								result = "Windows 10";
								break;
							}
						}
						break;
					case 11:
						if (num2 == 0)
						{
							switch (byte_)
							{
							case 3:
								result = "Windows Server 2022+";
								break;
							case 1:
								result = "Windows 11";
								break;
							}
						}
						break;
					}
					break;
				}
				case PlatformID.WinCE:
					result = "Windows CE";
					break;
				}
			}
			string_1 = result;
			return result;
		}
	}

	public static string ServicePack
	{
		get
		{
			string empty = string.Empty;
			Struct47 struct47_ = new Struct47
			{
				int_0 = Marshal.SizeOf(typeof(Struct47))
			};
			if (GetVersionEx(ref struct47_))
			{
				empty = struct47_.string_0;
			}
			return empty;
		}
	}

	public static int BuildVersion => int.Parse(smethod_3("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "CurrentBuildNumber", "0"));

	public static string VersionString => Version.ToString();

	public static Version Version => new Version(MajorVersion, MinorVersion, BuildVersion, RevisionVersion);

	public static int MajorVersion
	{
		get
		{
			if (smethod_2())
			{
				return 10;
			}
			if (!OpreofTkxg8())
			{
				string text = smethod_3("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "CurrentVersion", "");
				if (!string.IsNullOrEmpty(text))
				{
					return int.Parse(text.Split(new char[1] { '.' })[0]);
				}
				return Environment.OSVersion.Version.Major;
			}
			return 11;
		}
	}

	public static int MinorVersion
	{
		get
		{
			int result;
			if (!smethod_2())
			{
				if (!OpreofTkxg8())
				{
					string text = smethod_3("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "CurrentVersion", "");
					if (string.IsNullOrEmpty(text))
					{
						return Environment.OSVersion.Version.Minor;
					}
					return int.Parse(text.Split(new char[1] { '.' })[1]);
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return result;
		}
	}

	public static int RevisionVersion
	{
		get
		{
			if (!smethod_2() && !OpreofTkxg8())
			{
				return Environment.OSVersion.Version.Revision;
			}
			return 0;
		}
	}

	[DllImport("kernel32.dll")]
	internal static extern bool GetProductInfo(int osMajorVersion, int osMinorVersion, int spMajorVersion, int spMinorVersion, out int edition);

	[DllImport("kernel32.dll")]
	private static extern bool GetVersionEx(ref Struct47 struct47_0);

	[DllImport("user32")]
	public static extern int GetSystemMetrics(int nIndex);

	[DllImport("kernel32.dll")]
	public static extern void GetSystemInfo([MarshalAs(UnmanagedType.Struct)] ref SYSTEM_INFO lpSystemInfo);

	[DllImport("kernel32.dll")]
	public static extern void GetNativeSystemInfo([MarshalAs(UnmanagedType.Struct)] ref SYSTEM_INFO lpSystemInfo);

	[DllImport("kernel32", SetLastError = true)]
	public static extern IntPtr LoadLibrary(string libraryName);

	[DllImport("kernel32", SetLastError = true)]
	public static extern IntPtr GetProcAddress(IntPtr hwnd, string procedureName);

	private static Delegate5 smethod_0()
	{
		IntPtr intPtr = LoadLibrary("kernel32");
		if (intPtr != IntPtr.Zero)
		{
			IntPtr procAddress = GetProcAddress(intPtr, "IsWow64Process");
			if (procAddress != IntPtr.Zero)
			{
				return (Delegate5)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Delegate5));
			}
		}
		return null;
	}

	private static bool smethod_1()
	{
		Delegate5 @delegate = smethod_0();
		if (@delegate != null)
		{
			if (@delegate(Process.GetCurrentProcess().Handle, out var isWow64Process))
			{
				return isWow64Process;
			}
			return false;
		}
		return false;
	}

	private static bool smethod_2()
	{
		int num = int.Parse((string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion").GetValue("CurrentBuild"));
		if (smethod_3("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "ProductName", "").StartsWith("Windows 10", StringComparison.OrdinalIgnoreCase) && num < 22000)
		{
			return true;
		}
		return false;
	}

	private static bool OpreofTkxg8()
	{
		return int.Parse((string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion").GetValue("CurrentBuild")) >= 22000;
	}

	private static string smethod_3(string string_2, string string_3, object object_0)
	{
		string result = "";
		string text = "";
		string text2 = "";
		try
		{
			RegistryKey val = null;
			string[] array = string_2.Split(new char[1] { '\\' });
			if (array.Length != 0)
			{
				array[0] = array[0].ToUpper();
				if (!(array[0] == "HKEY_CLASSES_ROOT"))
				{
					if (!(array[0] == "HKEY_CURRENT_USER"))
					{
						if (array[0] == "HKEY_LOCAL_MACHINE")
						{
							val = Registry.LocalMachine;
						}
						else if (array[0] == "HKEY_USERS")
						{
							val = Registry.Users;
						}
						else if (array[0] == "HKEY_CURRENT_CONFIG")
						{
							val = Registry.CurrentConfig;
						}
					}
					else
					{
						val = Registry.CurrentUser;
					}
				}
				else
				{
					val = Registry.ClassesRoot;
				}
				if (val != null)
				{
					for (int i = 1; i < array.Length; i++)
					{
						text2 = text2 + text + array[i];
						text = "\\";
					}
					if (text2 != "")
					{
						val = val.OpenSubKey(text2);
						result = (string)val.GetValue(string_3, object_0);
						val.Close();
					}
				}
			}
		}
		catch
		{
		}
		return result;
	}

	static OSVersionInfo()
	{
		Class72.smethod_20();
	}
}
