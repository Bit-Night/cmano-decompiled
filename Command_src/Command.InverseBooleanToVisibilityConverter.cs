using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using Command.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscate]
public sealed class InverseBooleanToVisibilityConverter : IValueConverter
{
	private object method_0(object object_0)
	{
		if (!(object_0 is bool))
		{
			return (object)(Visibility)0;
		}
		if (Conversions.ToBoolean(object_0))
		{
			return (object)(Visibility)2;
		}
		return (object)(Visibility)0;
	}

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return method_0(RuntimeHelpers.GetObjectValue(value));
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}

	static InverseBooleanToVisibilityConverter()
	{
		Class72.smethod_20();
	}
}
