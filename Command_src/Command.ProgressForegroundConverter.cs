using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public sealed class ProgressForegroundConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		double num = Conversions.ToDouble(value);
		Brush result = Brushes.Green;
		if (num < 90.0)
		{
			if (num >= 60.0)
			{
				result = Brushes.Yellow;
			}
		}
		else
		{
			result = Brushes.Red;
		}
		return result;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}

	static ProgressForegroundConverter()
	{
		Class72.smethod_20();
	}
}
