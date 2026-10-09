using System;
using System.Linq;
using System.Reflection;

namespace Gameloop.Vdf.Utilities;

internal static class ReflectionUtils
{
	public static bool IsNullable(Type t)
	{
		ValidationUtils.ArgumentNotNull(t, "t");
		if (!TypeExtensions.IsValueType(t))
		{
			return true;
		}
		return IsNullableType(t);
	}

	public static bool IsNullableType(Type t)
	{
		ValidationUtils.ArgumentNotNull(t, "t");
		if (TypeExtensions.IsGenericType(t))
		{
			return t.GetGenericTypeDefinition() == typeof(Nullable<>);
		}
		return false;
	}

	public static bool IsMethodOverridden(Type currentType, Type methodDeclaringType, string method)
	{
		return currentType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Any((MethodInfo info) => info.Name == method && info.DeclaringType != methodDeclaringType && info.GetBaseDefinition().DeclaringType == methodDeclaringType);
	}

	static ReflectionUtils()
	{
		Class72.smethod_20();
	}
}
