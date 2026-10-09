using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

internal class HoverInfoEnumConverter : EnumConverter
{
	private Type type_0;

	public HoverInfoEnumConverter(Type type)
		: base(type)
	{
		type_0 = type;
	}

	public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
	{
		return destType == typeof(string);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
	{
		DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(type_0.GetField(Enum.GetName(type_0, RuntimeHelpers.GetObjectValue(value))), typeof(DescriptionAttribute));
		if (descriptionAttribute == null)
		{
			return value.ToString();
		}
		return descriptionAttribute.Description;
	}

	public override bool CanConvertFrom(ITypeDescriptorContext context, Type srcType)
	{
		return srcType == typeof(string);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		FieldInfo[] fields = type_0.GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
			if (descriptionAttribute != null && Operators.CompareString(Conversions.ToString(value), descriptionAttribute.Description, true) == 0)
			{
				return Enum.Parse(type_0, fieldInfo.Name);
			}
		}
		return Enum.Parse(type_0, Conversions.ToString(value));
	}

	static HoverInfoEnumConverter()
	{
		Class72.smethod_20();
	}
}
