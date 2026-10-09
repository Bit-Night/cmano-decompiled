using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace VntNet.PowerSchemeSwitcher;

internal class RegistryChangesNotificationHelper
{
	internal enum HKeyEnum
	{
		LocalMachine
	}

	private class Class41
	{
		private IntPtr intptr_0;

		private IntPtr intptr_1;

		private bool bool_0;

		[CompilerGenerated]
		private Action action_0;

		[DllImport("kernel32.dll")]
		private static extern IntPtr CreateEvent(IntPtr intptr_2, bool bool_1, bool bool_2, string string_0);

		[DllImport("advapi32.dll")]
		private static extern IntPtr RegOpenKey(IntPtr intptr_2, string string_0, out IntPtr intptr_3);

		[DllImport("advapi32.dll")]
		private static extern long RegNotifyChangeKeyValue(IntPtr intptr_2, bool bool_1, int int_0, IntPtr intptr_3, bool bool_2);

		[DllImport("kernel32.dll")]
		private static extern long WaitForSingleObject(IntPtr intptr_2, int int_0);

		[DllImport("kernel32.dll")]
		private static extern IntPtr CloseHandle(IntPtr intptr_2);

		[SpecialName]
		[CompilerGenerated]
		internal void method_0(Action action_1)
		{
			Action action = action_0;
			Action action2;
			do
			{
				action2 = action;
				Action value = (Action)Delegate.Combine(action2, action_1);
				action = Interlocked.CompareExchange(ref action_0, value, action2);
			}
			while ((object)action != action2);
		}

		[SpecialName]
		[CompilerGenerated]
		internal void method_1(Action action_1)
		{
			Action action = action_0;
			Action action2;
			do
			{
				action2 = action;
				Action value = (Action)Delegate.Remove(action2, action_1);
				action = Interlocked.CompareExchange(ref action_0, value, action2);
			}
			while ((object)action != action2);
		}

		internal unsafe Class41(long long_0, string string_0, bool bool_1)
		{
			bool_0 = bool_1;
			intptr_1 = CreateEvent((IntPtr)(void*)null, bool_1: false, bool_2: false, null);
			RegOpenKey(new IntPtr((int)long_0), string_0, out intptr_0);
			method_2();
		}

		private void method_2()
		{
			RegNotifyChangeKeyValue(intptr_0, bool_0, 5, intptr_1, bool_2: true);
		}

		internal void method_3()
		{
			WaitForSingleObject(intptr_1, -1);
			method_4();
			method_2();
		}

		private void method_4()
		{
			if (action_0 != null)
			{
				action_0();
			}
		}

		static Class41()
		{
			Class72.smethod_20();
		}
	}

	private bool bool_0;

	private Class41 class41_0;

	[CompilerGenerated]
	private Action action_0;

	internal event Action RegistryChanged
	{
		[CompilerGenerated]
		add
		{
			Action action = action_0;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = action_0;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public RegistryChangesNotificationHelper(HKeyEnum keyEnum, string subKeyPath, bool watchSubTree)
	{
		class41_0 = new Class41((keyEnum == HKeyEnum.LocalMachine) ? 2147483650L : 0L, subKeyPath, watchSubTree);
		Application.ApplicationExit += method_0;
		ThreadPool.QueueUserWorkItem(delegate
		{
			method_2();
		});
	}

	private void method_0(object sender, EventArgs e)
	{
		bool_0 = true;
	}

	private void method_1()
	{
		if (action_0 != null)
		{
			action_0();
		}
	}

	private void method_2()
	{
		while (!bool_0)
		{
			try
			{
				class41_0.method_3();
				method_1();
			}
			catch (Exception)
			{
			}
		}
	}

	[CompilerGenerated]
	private void method_3(object object_0)
	{
		method_2();
	}

	static RegistryChangesNotificationHelper()
	{
		Class72.smethod_20();
	}
}
