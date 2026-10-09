using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Command;

public sealed class CustomPanelsEventRaiser
{
	public delegate void CustomPanelStatusChangedEventHandler();

	[CompilerGenerated]
	private static CustomPanelStatusChangedEventHandler customPanelStatusChangedEventHandler_0;

	public static event CustomPanelStatusChangedEventHandler CustomPanelStatusChanged
	{
		[CompilerGenerated]
		add
		{
			CustomPanelStatusChangedEventHandler customPanelStatusChangedEventHandler = customPanelStatusChangedEventHandler_0;
			CustomPanelStatusChangedEventHandler customPanelStatusChangedEventHandler2;
			do
			{
				customPanelStatusChangedEventHandler2 = customPanelStatusChangedEventHandler;
				CustomPanelStatusChangedEventHandler value2 = (CustomPanelStatusChangedEventHandler)Delegate.Combine(customPanelStatusChangedEventHandler2, value);
				customPanelStatusChangedEventHandler = Interlocked.CompareExchange(ref customPanelStatusChangedEventHandler_0, value2, customPanelStatusChangedEventHandler2);
			}
			while ((object)customPanelStatusChangedEventHandler != customPanelStatusChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CustomPanelStatusChangedEventHandler customPanelStatusChangedEventHandler = customPanelStatusChangedEventHandler_0;
			CustomPanelStatusChangedEventHandler customPanelStatusChangedEventHandler2;
			do
			{
				customPanelStatusChangedEventHandler2 = customPanelStatusChangedEventHandler;
				CustomPanelStatusChangedEventHandler value2 = (CustomPanelStatusChangedEventHandler)Delegate.Remove(customPanelStatusChangedEventHandler2, value);
				customPanelStatusChangedEventHandler = Interlocked.CompareExchange(ref customPanelStatusChangedEventHandler_0, value2, customPanelStatusChangedEventHandler2);
			}
			while ((object)customPanelStatusChangedEventHandler != customPanelStatusChangedEventHandler2);
		}
	}

	public static void FireChangeEvent()
	{
		customPanelStatusChangedEventHandler_0?.Invoke();
	}

	static CustomPanelsEventRaiser()
	{
		Class72.smethod_20();
	}
}
