using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace VntNet.PowerSchemeSwitcher;

internal class PowerLineHelper
{
	internal enum PowerLineStatus : byte
	{
		Battery = 0,
		AC = 1,
		Unknown = byte.MaxValue
	}

	private class Class38
	{
		[Flags]
		private enum Enum17 : byte
		{

		}

		private struct Struct44
		{
			internal PowerLineStatus powerLineStatus_0;

			internal Enum17 enum17_0;

			internal byte byte_0;

			internal byte byte_1;

			internal uint uint_0;

			internal uint uint_1;
		}

		[DllImport("kernel32")]
		private static extern bool GetSystemPowerStatus(out Struct44 struct44_0);

		public static PowerLineStatus smethod_0()
		{
			if (!GetSystemPowerStatus(out var struct44_))
			{
				return PowerLineStatus.Unknown;
			}
			return struct44_.powerLineStatus_0;
		}

		public static int smethod_1()
		{
			if (GetSystemPowerStatus(out var struct44_))
			{
				return struct44_.byte_0;
			}
			return -1;
		}

		static Class38()
		{
			Class72.smethod_20();
		}
	}

	private int int_0;

	private bool bool_0;

	private ManualResetEvent manualResetEvent_0;

	[CompilerGenerated]
	private Action<PowerLineStatus> action_0;

	[CompilerGenerated]
	private Action<int> action_1;

	public event Action<PowerLineStatus> PowerLineStatusChanged
	{
		[CompilerGenerated]
		add
		{
			Action<PowerLineStatus> action = action_0;
			Action<PowerLineStatus> action2;
			do
			{
				action2 = action;
				Action<PowerLineStatus> value2 = (Action<PowerLineStatus>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<PowerLineStatus> action = action_0;
			Action<PowerLineStatus> action2;
			do
			{
				action2 = action;
				Action<PowerLineStatus> value2 = (Action<PowerLineStatus>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public event Action<int> BatteryLifePercentChanged
	{
		[CompilerGenerated]
		add
		{
			Action<int> action = action_1;
			Action<int> action2;
			do
			{
				action2 = action;
				Action<int> value2 = (Action<int>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_1, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<int> action = action_1;
			Action<int> action2;
			do
			{
				action2 = action;
				Action<int> value2 = (Action<int>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_1, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public PowerLineHelper()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		manualResetEvent_0 = new ManualResetEvent(initialState: true);
		bool_0 = false;
		int_0 = 0;
		SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(HsKynArWqwo);
		Application.ApplicationExit += method_0;
		ThreadPool.QueueUserWorkItem(delegate
		{
			method_1();
		});
	}

	private void method_0(object sender, EventArgs e)
	{
		bool_0 = true;
	}

	private void method_1()
	{
		while (!bool_0)
		{
			manualResetEvent_0.WaitOne(30000);
			manualResetEvent_0.Reset();
			try
			{
				MpGynIvnaxx();
			}
			catch (Exception)
			{
			}
		}
	}

	internal void ForceBatteryStatuCheck()
	{
		manualResetEvent_0.Set();
	}

	private void MpGynIvnaxx()
	{
		int num = 0;
		if (Class38.smethod_0() == PowerLineStatus.Battery)
		{
			num = Class38.smethod_1();
			if (num != -1 && num != int_0)
			{
				method_2(num);
				int_0 = num;
			}
		}
	}

	private void method_2(int int_1)
	{
		if (action_1 != null)
		{
			action_1(int_1);
		}
	}

	private void HsKynArWqwo(object sender, PowerModeChangedEventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (action_0 != null)
		{
			action_0((PowerLineStatus)e.Mode);
		}
		if (Class38.smethod_0() == PowerLineStatus.Battery)
		{
			ForceBatteryStatuCheck();
		}
	}

	internal static int GetCurrentBatteryLifePercent()
	{
		return Class38.smethod_1();
	}

	[CompilerGenerated]
	private void method_3(object object_0)
	{
		method_1();
	}

	static PowerLineHelper()
	{
		Class72.smethod_20();
	}
}
