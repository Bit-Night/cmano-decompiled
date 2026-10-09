using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace VntNet.PowerSchemeSwitcher;

public sealed class PowerSchemeHelper
{
	private class Class39
	{
		[Flags]
		private enum Enum18
		{

		}

		[DllImport("PowrProf.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.U4)]
		private static extern uint PowerEnumerate(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2, Enum18 enum18_0, uint uint_0, IntPtr intptr_3, ref uint uint_1);

		[DllImport("PowrProf.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.U4)]
		private static extern uint PowerReadFriendlyName(IntPtr intptr_0, ref Guid guid_0, IntPtr intptr_1, IntPtr intptr_2, IntPtr intptr_3, ref uint uint_0);

		[DllImport("PowrProf.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.U4)]
		private static extern uint PowerSetActiveScheme(IntPtr intptr_0, ref Guid guid_0);

		[DllImport("PowrProf.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.U4)]
		private static extern uint PowerGetActiveScheme(IntPtr intptr_0, ref IntPtr intptr_1);

		public static Guid smethod_0(uint uint_0)
		{
			uint uint_1 = 16u;
			uint num = 0u;
			Guid result = Guid.Empty;
			IntPtr intPtr = (intPtr = Marshal.AllocHGlobal(16));
			try
			{
				num = PowerEnumerate(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (Enum18)16, uint_0, intPtr, ref uint_1);
				if (num == 234)
				{
					Marshal.FreeHGlobal(intPtr);
					intPtr = Marshal.AllocHGlobal((int)uint_1);
					num = PowerEnumerate(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (Enum18)16, uint_0, intPtr, ref uint_1);
				}
				switch (num)
				{
				default:
					throw new Win32Exception(Marshal.GetLastWin32Error());
				case 259u:
					break;
				case 0u:
					result = (Guid)Marshal.PtrToStructure(intPtr, typeof(Guid));
					break;
				}
			}
			finally
			{
				Marshal.FreeHGlobal(intPtr);
			}
			return result;
		}

		public static string smethod_1(Guid guid_0)
		{
			uint uint_ = 255u;
			uint num = 0u;
			string text = null;
			IntPtr intPtr = (intPtr = Marshal.AllocHGlobal(255));
			num = PowerReadFriendlyName(IntPtr.Zero, ref guid_0, IntPtr.Zero, IntPtr.Zero, intPtr, ref uint_);
			if (num == 234)
			{
				Marshal.FreeHGlobal(intPtr);
				intPtr = Marshal.AllocHGlobal((int)uint_);
				num = PowerReadFriendlyName(IntPtr.Zero, ref guid_0, IntPtr.Zero, IntPtr.Zero, intPtr, ref uint_);
			}
			text = num switch
			{
				0u => Marshal.PtrToStringUni(intPtr), 
				2u => null, 
				_ => throw new Win32Exception(Marshal.GetLastWin32Error()), 
			};
			Marshal.FreeHGlobal(intPtr);
			return text;
		}

		public static bool smethod_2(Guid guid_0)
		{
			if (PowerSetActiveScheme(IntPtr.Zero, ref guid_0) != 0)
			{
				return false;
			}
			return true;
		}

		public static Guid smethod_3()
		{
			IntPtr intptr_ = Marshal.AllocHGlobal(16);
			Guid result = Guid.Empty;
			if (PowerGetActiveScheme(IntPtr.Zero, ref intptr_) == 0)
			{
				result = (Guid)Marshal.PtrToStructure(intptr_, typeof(Guid));
			}
			Marshal.FreeHGlobal(intptr_);
			return result;
		}

		static Class39()
		{
			Class72.smethod_20();
		}
	}

	public static bool SetPowerScheme(Guid schemeGuid)
	{
		if (!(Class39.smethod_3() == schemeGuid))
		{
			Class39.smethod_2(schemeGuid);
			return Class39.smethod_3() == schemeGuid;
		}
		return true;
	}

	public static Dictionary<Guid, PowerPlanInfo> GetAllPowerSchemas()
	{
		uint num = 0u;
		Dictionary<Guid, PowerPlanInfo> dictionary = new Dictionary<Guid, PowerPlanInfo>(3);
		while (true)
		{
			try
			{
				Guid guid = Class39.smethod_0(num);
				if (guid != Guid.Empty)
				{
					string friendlyName = Class39.smethod_1(guid);
					dictionary.Add(guid, new PowerPlanInfo
					{
						SchemeGuid = guid,
						FriendlyName = friendlyName
					});
					continue;
				}
				return dictionary;
			}
			finally
			{
				num++;
			}
		}
	}

	public static Guid GetPowerActiveScheme()
	{
		return Class39.smethod_3();
	}

	static PowerSchemeHelper()
	{
		Class72.smethod_20();
	}
}
