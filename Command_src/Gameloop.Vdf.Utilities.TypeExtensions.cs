using System;

namespace Gameloop.Vdf.Utilities;

internal static class TypeExtensions
{
	public static bool IsGenericType(this Type type)
	{
		return type.IsGenericType;
	}

	public static Type BaseType(this Type type)
	{
		return type.BaseType;
	}

	public static bool IsVisible(this Type type)
	{
		return type.IsVisible;
	}

	public static bool IsValueType(this Type type)
	{
		return type.IsValueType;
	}

	static TypeExtensions()
	{
		Class72.smethod_20();
	}
}
