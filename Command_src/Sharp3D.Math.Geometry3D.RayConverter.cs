using System;
using System.ComponentModel;
using System.Globalization;

namespace Sharp3D.Math.Geometry3D;

public sealed class RayConverter : ExpandableObjectConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (!(sourceType == typeof(string)))
		{
			return base.CanConvertFrom(context, sourceType);
		}
		return true;
	}

	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (destinationType == typeof(string))
		{
			return true;
		}
		return base.CanConvertTo(context, destinationType);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == typeof(string) && value is Ray ray)
		{
			return ray.ToString();
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (!(value.GetType() == typeof(string)))
		{
			return base.ConvertFrom(context, culture, value);
		}
		return Ray.Parse((string)value);
	}

	static RayConverter()
	{
		Class72.smethod_20();
	}
}
