using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command.SmartAssembly.Attributes;
using CommandNetcode.RT;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscate]
public class RealtimeClockControl : UserControl, InOutDisplay, INotifyPropertyChanged, IComponentConnector
{
	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private bool bool_0;

	public string IncommingData
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "IncommingData");
		}
	}

	public string OutgoingData
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "OutgoingData");
		}
	}

	public string OutgoingSummary
	{
		get
		{
			return string_2;
		}
		set
		{
			SetProperty(ref string_2, value, "OutgoingSummary");
		}
	}

	public string IncommingSummary
	{
		get
		{
			return string_3;
		}
		set
		{
			SetProperty(ref string_3, value, "IncommingSummary");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(field, value))
		{
			return false;
		}
		field = value;
		OnPropertyChanged(propertyName);
		return true;
	}

	public RealtimeClockControl()
	{
		InitializeComponent();
		((FrameworkElement)this).DataContext = this;
	}

	public void RefreshCaption(string Line1, string Line2)
	{
	}

	public void StatusEvent(StatusMessage msg)
	{
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/multiplayer/rtmp/realtimeclockcontrol.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		bool_0 = true;
	}

	static RealtimeClockControl()
	{
		Class72.smethod_20();
	}
}
