using System;
using System.ComponentModel;
using System.Globalization;

namespace Sharp3D.Math.Core;

public sealed class Vector3DConverter : ExpandableObjectConverter
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
		if (destinationType == typeof(string) && value is Vector3D vector3D)
		{
			return vector3D.ToString();
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value.GetType() == typeof(string))
		{
			return Vector3D.Parse((string)value);
		}
		return base.ConvertFrom(context, culture, value);
	}

	public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
	{
		return new StandardValuesCollection(new object[4]
		{
			Vector3D.Zero,
			Vector3D.XAxis,
			Vector3D.YAxis,
			Vector3D.ZAxis
		});
	}

	static Vector3DConverter()
	{
		Class72.smethod_20();
	}
}
