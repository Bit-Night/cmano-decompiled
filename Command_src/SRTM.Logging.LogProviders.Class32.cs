using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SRTM.Logging.LogProviders;

[ExcludeFromCodeCoverage]
internal class Class32 : LogProviderBase
{
	[ExcludeFromCodeCoverage]
	internal class Log4NetLogger
	{
		private readonly dynamic object_0;

		private static Type UiDefLdLsaD;

		private static readonly object object_1;

		private static readonly object object_2;

		private static readonly object object_3;

		private static readonly object object_4;

		private static readonly object object_5;

		private static readonly object object_6;

		private static readonly Func<object, object, bool> func_0;

		private static readonly Action<object, object> action_0;

		private static readonly Func<object, Type, object, string, Exception, object> func_1;

		private static readonly Action<object, string, object> action_1;

		internal static Log4NetLogger log4NetLogger_0;

		static Log4NetLogger()
		{
			Class72.smethod_20();
			object_1 = new object();
			Type type = Type.GetType("log4net.Core.Level, log4net");
			if (type == null)
			{
				throw new InvalidOperationException("Type log4net.Core.Level was not found.");
			}
			List<FieldInfo> source = TypeExtensions.GetFieldsPortable(type).ToList();
			object_2 = source.First((FieldInfo x) => x.Name == "Debug").GetValue(null);
			object_3 = source.First((FieldInfo x) => x.Name == "Info").GetValue(null);
			object_4 = source.First((FieldInfo x) => x.Name == "Warn").GetValue(null);
			object_5 = source.First((FieldInfo x) => x.Name == "Error").GetValue(null);
			object_6 = source.First((FieldInfo x) => x.Name == "Fatal").GetValue(null);
			Type type2 = Type.GetType("log4net.Core.ILogger, log4net");
			if (type2 == null)
			{
				throw new InvalidOperationException("Type log4net.Core.ILogger, was not found.");
			}
			ParameterExpression expression = Expression.Parameter(typeof(object));
			Expression.Convert(expression, type2);
			ParameterExpression expression2 = Expression.Parameter(typeof(object));
			Expression.Convert(expression2, type);
			func_0 = null;
			Type.GetType("log4net.Core.LoggingEvent, log4net");
			func_1 = null;
			action_0 = null;
			action_1 = null;
		}

		internal Log4NetLogger(dynamic logger)
		{
		}

		public bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception, params object[] formatParameters)
		{
			return true;
		}

		private void method_0(object object_7, IEnumerable<string> ienumerable_0, object[] object_8)
		{
		}

		private static bool smethod_0(Type type_0, Type type_1)
		{
			return true;
		}

		private bool method_1(LogLevel logLevel_0)
		{
			return true;
		}

		private object method_2(LogLevel logLevel_0)
		{
			return null;
		}

		internal static bool smethod_1()
		{
			return true;
		}

		internal static Log4NetLogger smethod_2()
		{
			return null;
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public Action<string, string> action_0;

		public Action<string> action_1;

		internal IDisposable method_0(string key, object value, bool _)
		{
			<>c__DisplayClass9_1 <>c__DisplayClass9_ = new <>c__DisplayClass9_1
			{
				<>c__DisplayClass9_0_0 = this,
				string_0 = key
			};
			action_0(<>c__DisplayClass9_.string_0, value.ToString());
			return new DisposableAction(<>c__DisplayClass9_.method_0);
		}

		static <>c__DisplayClass9_0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_1
	{
		public string string_0;

		public <>c__DisplayClass9_0 <>c__DisplayClass9_0_0;

		internal void method_0()
		{
			<>c__DisplayClass9_0_0.action_1(string_0);
		}

		static <>c__DisplayClass9_1()
		{
			Class72.smethod_20();
		}
	}

	private readonly Func<string, object> func_0;

	private static bool bool_0;

	public static bool ProviderIsAvailableOverride
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Class32()
	{
		if (!IsLoggerAvailable())
		{
			throw new InvalidOperationException("log4net.LogManager not found");
		}
		func_0 = smethod_1();
	}

	public override Logger GetLogger(string name)
	{
		return new Log4NetLogger(func_0(name)).Log;
	}

	internal static bool IsLoggerAvailable()
	{
		if (bool_0)
		{
			return smethod_0() != null;
		}
		return false;
	}

	protected override OpenNdc GetOpenNdcMethod()
	{
		PropertyInfo propertyPortable = TypeExtensions.GetPropertyPortable(Type.GetType("log4net.LogicalThreadContext, log4net"), "Stacks");
		PropertyInfo propertyPortable2 = TypeExtensions.GetPropertyPortable(propertyPortable.PropertyType, "Item");
		MethodInfo methodPortable = TypeExtensions.GetMethodPortable(propertyPortable2.PropertyType, "Push");
		ParameterExpression parameterExpression = Expression.Parameter(typeof(string), "message");
		return Expression.Lambda<OpenNdc>(Expression.Call(Expression.Property(Expression.Property(null, propertyPortable), propertyPortable2, Expression.Constant("NDC")), methodPortable, parameterExpression), new ParameterExpression[1] { parameterExpression }).Compile();
	}

	protected override OpenMdc GetOpenMdcMethod()
	{
		PropertyInfo propertyPortable = TypeExtensions.GetPropertyPortable(Type.GetType("log4net.LogicalThreadContext, log4net"), "Properties");
		Type propertyType = propertyPortable.PropertyType;
		PropertyInfo propertyPortable2 = TypeExtensions.GetPropertyPortable(propertyType, "Item");
		MethodInfo methodPortable = TypeExtensions.GetMethodPortable(propertyType, "Remove");
		ParameterExpression parameterExpression = Expression.Parameter(typeof(string), "key");
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(string), "value");
		MemberExpression instance = Expression.Property(null, propertyPortable);
		BinaryExpression body = Expression.Assign(Expression.Property(instance, propertyPortable2, parameterExpression), parameterExpression2);
		MethodCallExpression body2 = Expression.Call(instance, methodPortable, parameterExpression);
		Action<string, string> action_0 = Expression.Lambda<Action<string, string>>(body, new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
		Action<string> action_1 = Expression.Lambda<Action<string>>(body2, new ParameterExpression[1] { parameterExpression }).Compile();
		<>c__DisplayClass9_0 CS$<>8__locals0;
		return delegate(string key, object value, bool _)
		{
			<>c__DisplayClass9_1 <>c__DisplayClass9_ = new <>c__DisplayClass9_1();
			<>c__DisplayClass9_.<>c__DisplayClass9_0_0 = CS$<>8__locals0;
			<>c__DisplayClass9_.string_0 = key;
			action_0(<>c__DisplayClass9_.string_0, value.ToString());
			return new DisposableAction(<>c__DisplayClass9_.method_0);
		};
	}

	private static Type smethod_0()
	{
		return Type.GetType("log4net.LogManager, log4net");
	}

	private static Func<string, object> smethod_1()
	{
		MethodInfo methodPortable = TypeExtensions.GetMethodPortable(smethod_0(), "GetLogger", typeof(string));
		ParameterExpression parameterExpression = Expression.Parameter(typeof(string), "name");
		return Expression.Lambda<Func<string, object>>(Expression.Call(null, methodPortable, parameterExpression), new ParameterExpression[1] { parameterExpression }).Compile();
	}

	static Class32()
	{
		Class72.smethod_20();
		bool_0 = true;
	}
}
