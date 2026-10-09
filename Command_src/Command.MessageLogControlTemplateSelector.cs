using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class MessageLogControlTemplateSelector : DataTemplateSelector, INotifyPropertyChanged
{
	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	private DataTemplate dataTemplate_0;

	private DataTemplate dataTemplate_1;

	public DataTemplate DefaultMessageLogTemplate
	{
		get
		{
			return dataTemplate_0;
		}
		set
		{
			SetProperty(ref dataTemplate_0, value, "DefaultMessageLogTemplate");
		}
	}

	public DataTemplate HTMLMessageLogTemplate
	{
		get
		{
			return dataTemplate_1;
		}
		set
		{
			SetProperty(ref dataTemplate_1, value, "HTMLMessageLogTemplate");
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

	public override DataTemplate SelectTemplate(object item, DependencyObject container)
	{
		if (((MLDetailViewModel)item).LongText.StartsWith("<BODY"))
		{
			return HTMLMessageLogTemplate;
		}
		return DefaultMessageLogTemplate;
	}

	static MessageLogControlTemplateSelector()
	{
		Class72.smethod_20();
	}
}
