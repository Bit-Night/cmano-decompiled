using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Command;

public sealed class GClass2 : IValueConverter
{
	private object IValueConverter_Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		if (value is string s)
		{
			BitmapImage val = new BitmapImage();
			val.BeginInit();
			val.StreamSource = new MemoryStream(Convert.FromBase64String(s));
			val.EndInit();
			return (object)val;
		}
		return null;
	}

	private object IValueConverter_ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}

	static GClass2()
	{
		Class72.smethod_20();
	}
}
