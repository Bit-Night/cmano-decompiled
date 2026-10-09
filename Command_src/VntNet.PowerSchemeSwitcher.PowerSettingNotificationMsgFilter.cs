using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace VntNet.PowerSchemeSwitcher;

internal class PowerSettingNotificationMsgFilter : IDisposable
{
	public enum PowerSavingLevelEnum
	{
		Max,
		Min,
		Typical,
		Unkown
	}

	private class Class40
	{
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		internal struct POWERBROADCAST_SETTING
		{
			public Guid PowerSetting;

			public int DataLength;
		}

		[Flags]
		public enum EXECUTION_STATE : uint
		{
			ES_SYSTEM_REQUIRED = 1u,
			ES_DISPLAY_REQUIRED = 2u,
			ES_CONTINUOUS = 0x80000000u
		}

		internal static Guid guid_0;

		internal static Guid guid_1;

		internal static Guid guid_2;

		private IntPtr intptr_0;

		[CompilerGenerated]
		private Action<Guid> action_0;

		private IntPtr intptr_1;

		private Guid OdNeumTjsot = new Guid("A7AD8041-B45A-4CAE-87A3-EECBB468A9E1");

		private Guid guid_3 = new Guid(41095189, 17680, 17702, 153, 230, 229, 161, 126, 189, 26, 234);

		private Guid guid_4 = new Guid(1564383833u, 59861, 19200, 166, 189, byte.MaxValue, 52, byte.MaxValue, 81, 101, 72);

		private Guid guid_5 = new Guid(610108737, 14659, 17442, 176, 37, 19, 167, 132, 246, 121, 183);

		[SpecialName]
		[CompilerGenerated]
		public void method_0(Action<Guid> action_1)
		{
			Action<Guid> action = action_0;
			Action<Guid> action2;
			do
			{
				action2 = action;
				Action<Guid> value = (Action<Guid>)Delegate.Combine(action2, action_1);
				action = Interlocked.CompareExchange(ref action_0, value, action2);
			}
			while ((object)action != action2);
		}

		[SpecialName]
		[CompilerGenerated]
		public void method_1(Action<Guid> action_1)
		{
			Action<Guid> action = action_0;
			Action<Guid> action2;
			do
			{
				action2 = action;
				Action<Guid> value = (Action<Guid>)Delegate.Remove(action2, action_1);
				action = Interlocked.CompareExchange(ref action_0, value, action2);
			}
			while ((object)action != action2);
		}

		[DllImport("user32", CallingConvention = CallingConvention.StdCall)]
		private static extern IntPtr RegisterPowerSettingNotification(IntPtr intptr_2, ref Guid guid_6, int int_0);

		[DllImport("user32", CallingConvention = CallingConvention.StdCall)]
		private static extern bool UnregisterPowerSettingNotification(IntPtr intptr_2);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE execution_STATE_0);

		public Class40(IntPtr intptr_2)
		{
			intptr_1 = intptr_2;
		}

		public void method_2()
		{
			intptr_0 = RegisterPowerSettingNotification(intptr_1, ref guid_5, 0);
		}

		public void method_3()
		{
			UnregisterPowerSettingNotification(intptr_0);
		}

		public bool method_4(ref Message message_0)
		{
			if (((Message)(ref message_0)).Msg == 536)
			{
				method_5(ref message_0);
				return true;
			}
			return false;
		}

		private void method_5(ref Message message_0)
		{
			if ((int)((Message)(ref message_0)).WParam == 32787)
			{
				method_6(ref message_0);
			}
		}

		private void method_6(ref Message message_0)
		{
			POWERBROADCAST_SETTING pOWERBROADCAST_SETTING = (POWERBROADCAST_SETTING)Marshal.PtrToStructure(((Message)(ref message_0)).LParam, typeof(POWERBROADCAST_SETTING));
			IntPtr intptr_ = (IntPtr)((int)((Message)(ref message_0)).LParam + Marshal.SizeOf(pOWERBROADCAST_SETTING));
			if (pOWERBROADCAST_SETTING.PowerSetting == guid_5)
			{
				method_7(pOWERBROADCAST_SETTING, intptr_);
			}
		}

		private void method_7(POWERBROADCAST_SETTING powerbroadcast_SETTING_0, IntPtr intptr_2)
		{
			if (powerbroadcast_SETTING_0.DataLength == Marshal.SizeOf(typeof(Guid)))
			{
				Guid obj = (Guid)Marshal.PtrToStructure(intptr_2, typeof(Guid));
				if (action_0 != null)
				{
					action_0(obj);
				}
			}
		}

		static Class40()
		{
			Class72.smethod_20();
			guid_0 = new Guid(2709787400u, 13633, 20395, 188, 129, 247, 21, 86, 242, 11, 74);
			guid_1 = new Guid(2355003354u, 59583, 19094, 154, 133, 166, 226, 58, 140, 99, 92);
			guid_2 = new Guid(941310498u, 63124, 16880, 150, 133, byte.MaxValue, 91, 178, 96, 223, 46);
		}
	}

	[CompilerGenerated]
	private Action<PowerSavingLevelEnum> action_0;

	private Class40 class40_0;

	private bool bool_0;

	internal event Action<PowerSavingLevelEnum> PowerSchemeChanged
	{
		[CompilerGenerated]
		add
		{
			Action<PowerSavingLevelEnum> action = action_0;
			Action<PowerSavingLevelEnum> action2;
			do
			{
				action2 = action;
				Action<PowerSavingLevelEnum> value2 = (Action<PowerSavingLevelEnum>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<PowerSavingLevelEnum> action = action_0;
			Action<PowerSavingLevelEnum> action2;
			do
			{
				action2 = action;
				Action<PowerSavingLevelEnum> value2 = (Action<PowerSavingLevelEnum>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public PowerSettingNotificationMsgFilter(Form form)
	{
		class40_0 = new Class40(((Control)form).Handle);
		class40_0.method_0(method_0);
		bool_0 = false;
		method_2();
	}

	private void method_0(Guid guid_0)
	{
		PowerSavingLevelEnum powerSavingLevelEnum_ = PowerSavingLevelEnum.Unkown;
		if (action_0 == null)
		{
			return;
		}
		if (!(guid_0 == Class40.guid_0))
		{
			if (guid_0 == Class40.guid_1)
			{
				powerSavingLevelEnum_ = PowerSavingLevelEnum.Min;
			}
			else if (guid_0 == Class40.guid_2)
			{
				powerSavingLevelEnum_ = PowerSavingLevelEnum.Typical;
			}
		}
		else
		{
			powerSavingLevelEnum_ = PowerSavingLevelEnum.Max;
		}
		method_1(powerSavingLevelEnum_);
	}

	private void method_1(PowerSavingLevelEnum powerSavingLevelEnum_0)
	{
		if (action_0 != null)
		{
			action_0(powerSavingLevelEnum_0);
		}
	}

	public bool PreFilterMessage(ref Message m)
	{
		if (bool_0)
		{
			return class40_0.method_4(ref m);
		}
		return false;
	}

	private void method_2()
	{
		if (!bool_0)
		{
			class40_0.method_2();
			bool_0 = true;
		}
	}

	public void Destroy()
	{
		if (bool_0)
		{
			class40_0.method_3();
			bool_0 = false;
		}
	}

	void IDisposable.Dispose()
	{
		Destroy();
	}

	static PowerSettingNotificationMsgFilter()
	{
		Class72.smethod_20();
	}
}
