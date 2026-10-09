using System;
using System.ComponentModel;
using System.Globalization;

namespace Sharp3D.Math.Geometry2D;

public sealed class ArcConverter : ExpandableObjectConverter
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
		if (!(destinationType == typeof(string)))
		{
			return base.CanConvertTo(context, destinationType);
		}
		return true;
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == typeof(string) && value is Segment)
		{
			return ((Arc)value/*cast due to .constrained prefix*/).ToString();
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value.GetType() == typeof(string))
		{
			return Arc.Parse((string)value);
		}
		return base.ConvertFrom(context, culture, value);
	}

	static ArcConverter()
	{
		Class72.smethod_20();
	}
}
