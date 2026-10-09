using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command.SmartAssembly.Attributes;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
public sealed class InvertableBool : INotifyPropertyChanged
{
	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	private bool bool_0;

	public bool Value
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			method_0("Value");
			method_0("Invert");
		}
	}

	public bool Invert
	{
		get
		{
			return !bool_0;
		}
		set
		{
			bool_0 = !value;
			method_0("Value");
			method_0("Invert");
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

	private void method_0(string string_0)
	{
		propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	public InvertableBool(bool b)
	{
		bool_0 = false;
		bool_0 = b;
	}

	public static implicit operator InvertableBool(bool b)
	{
		return new InvertableBool(b);
	}

	public static implicit operator bool(InvertableBool b)
	{
		return b.Value;
	}

	static InvertableBool()
	{
		Class72.smethod_20();
	}
}
