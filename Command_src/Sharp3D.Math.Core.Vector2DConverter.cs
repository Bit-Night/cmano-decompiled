using System;
using System.ComponentModel;
using System.Globalization;

namespace Sharp3D.Math.Core;

public sealed class Vector2DConverter : ExpandableObjectConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (sourceType == typeof(string))
		{
			return true;
		}
		return base.CanConvertFrom(context, sourceType);
	}

	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (!(destinationType == typeof(string)))
		{
			return base.CanConvertTo(context, destinationType);
		}
		return true;
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == typeof(string) && value is Vector2D vector2D)
		{
			return vector2D.ToString();
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (!(value.GetType() == typeof(string)))
		{
			return base.ConvertFrom(context, culture, value);
		}
		return Vector2D.Parse((string)value);
	}

	public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
	{
		return new StandardValuesCollection(new object[3]
		{
			Vector2D.Zero,
			Vector2D.XAxis,
			Vector2D.YAxis
		});
	}

	static Vector2DConverter()
	{
		Class72.smethod_20();
	}
}
