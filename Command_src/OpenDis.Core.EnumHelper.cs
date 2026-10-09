using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace OpenDis.Core;

public static class EnumHelper
{
	public static bool EnumerationForValueExists<T>(int number)
	{
		return Enum.IsDefined(typeof(T), number);
	}

	public static string GetDescription<T>(T value)
	{
		string result = string.Empty;
		DescriptionAttribute enumValueAttribute = GetEnumValueAttribute<DescriptionAttribute, T>(value);
		if (enumValueAttribute != null)
		{
			result = enumValueAttribute.Description;
		}
		return result;
	}

	public static T GetEnumerationForValue<T>(int number)
	{
		if (!Enum.IsDefined(typeof(T), number))
		{
			throw new EnumNotFoundException($"No enumeration found for value {number} of enumeration {typeof(T).Name}", typeof(T));
		}
		return (T)Enum.ToObject(typeof(T), number);
	}

	public static T GetEnumValueAttribute<T, U>(U value)
	{
		if (typeof(U).IsEnum)
		{
			if (value != null)
			{
				FieldInfo field = typeof(U).GetField(Enum.GetName(typeof(U), value));
				if (field != null)
				{
					object[] customAttributes = field.GetCustomAttributes(typeof(T), inherit: false);
					if (customAttributes != null && customAttributes.Length != 0)
					{
						return (T)customAttributes[0];
					}
				}
			}
			return default(T);
		}
		throw new ArgumentException("Type must be an enum.");
	}

	public static IEnumerable<T> GetEnumValueAttributes<T, U>(U value)
	{
		if (typeof(U).IsEnum)
		{
			if (value != null)
			{
				FieldInfo field = typeof(U).GetField(Enum.GetName(typeof(U), value));
				if (field != null)
				{
					object[] customAttributes = field.GetCustomAttributes(typeof(T), inherit: false);
					if (customAttributes != null && customAttributes.Length != 0)
					{
						return customAttributes.Cast<T>();
					}
				}
			}
			return new T[0];
		}
		throw new ArgumentException("Type must be an enum.");
	}

	public static string GetInternetDomainCode<T>(T value)
	{
		string result = string.Empty;
		InternetDomainCodeAttribute enumValueAttribute = GetEnumValueAttribute<InternetDomainCodeAttribute, T>(value);
		if (enumValueAttribute != null)
		{
			result = enumValueAttribute.InternetDomainCode;
		}
		return result;
	}

	public static T Parse<T>(string value)
	{
		return (T)Enum.Parse(typeof(T), value);
	}

	public static T Parse<T>(string value, bool ignoreCase)
	{
		return (T)Enum.Parse(typeof(T), value, ignoreCase);
	}

	static EnumHelper()
	{
		Class72.smethod_20();
	}
}
