using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace VntNet.PowerSchemeSwitcher;

internal class PowerSettingChangeNotification
{
	[CompilerGenerated]
	private Action action_0;

	private RegistryChangesNotificationHelper registryChangesNotificationHelper_0;

	internal event Action PowerSettingsChanged
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

	public PowerSettingChangeNotification()
	{
		registryChangesNotificationHelper_0 = new RegistryChangesNotificationHelper(RegistryChangesNotificationHelper.HKeyEnum.LocalMachine, "SYSTEM\\CurrentControlSet\\Control\\Power\\User\\PowerSchemes", watchSubTree: true);
		registryChangesNotificationHelper_0.RegistryChanged += method_0;
	}

	private void method_0()
	{
		method_1();
	}

	private void method_1()
	{
		if (action_0 != null)
		{
			action_0();
		}
	}

	static PowerSettingChangeNotification()
	{
		Class72.smethod_20();
	}
}
