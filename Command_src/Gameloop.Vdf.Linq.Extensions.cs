using System;
using System.Collections.Generic;
using System.Globalization;
using Gameloop.Vdf.Utilities;

namespace Gameloop.Vdf.Linq;

public static class Extensions
{
	public static U Value<U>(this IEnumerable<VToken> value)
	{
		return Value<VToken, U>(value);
	}

	public static U Value<T, U>(this IEnumerable<T> value) where T : VToken
	{
		ValidationUtils.ArgumentNotNull(value, "value");
		return Convert<VToken, U>((value as VToken) ?? throw new ArgumentException("Source value must be a JToken."));
	}

	internal static U Convert<T, U>(this T token) where T : VToken
	{
		if (token == null)
		{
			return default(U);
		}
		if (token is U && typeof(U) != typeof(IComparable) && typeof(U) != typeof(IFormattable))
		{
			return (U)(object)token;
		}
		if (!(token is VValue { Value: var value } vValue))
		{
			throw new InvalidCastException($"Cannot cast {token.GetType()} to {typeof(T)}.");
		}
		if (value is U)
		{
			return (U)value;
		}
		Type type = typeof(U);
		if (ReflectionUtils.IsNullableType(type))
		{
			if (vValue.Value == null)
			{
				return default(U);
			}
			type = Nullable.GetUnderlyingType(type);
		}
		if (smethod_0<U>(vValue.Value, out var gparam_))
		{
			return gparam_;
		}
		return (U)System.Convert.ChangeType(vValue.Value, type, CultureInfo.InvariantCulture);
	}

	private static bool smethod_0<T>(object object_0, out T gparam_0)
	{
		gparam_0 = default(T);
		if (typeof(T) == typeof(bool) || Nullable.GetUnderlyingType(typeof(T)) == typeof(bool))
		{
			switch (object_0 as string)
			{
			case "0":
				gparam_0 = (T)(object)false;
				return true;
			case "1":
				gparam_0 = (T)(object)true;
				return true;
			}
		}
		return false;
	}

	static Extensions()
	{
		Class72.smethod_20();
	}
}
