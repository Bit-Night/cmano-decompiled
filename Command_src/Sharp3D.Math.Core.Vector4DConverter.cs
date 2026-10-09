using System;
using System.ComponentModel;
using System.Globalization;

namespace Sharp3D.Math.Core;

public sealed class Vector4DConverter : ExpandableObjectConverter
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
		if (destinationType == typeof(string) && value is Vector4D vector4D)
		{
			return vector4D.ToString();
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value.GetType() == typeof(string))
		{
			return Vector4D.Parse((string)value);
		}
		return base.ConvertFrom(context, culture, value);
	}

	public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
	{
		return new StandardValuesCollection(new object[5]
		{
			Vector4D.Zero,
			Vector4D.XAxis,
			Vector4D.YAxis,
			Vector4D.ZAxis,
			Vector4D.WAxis
		});
	}

	static Vector4DConverter()
	{
		Class72.smethod_20();
	}
}
