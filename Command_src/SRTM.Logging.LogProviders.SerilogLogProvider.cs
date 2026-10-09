using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace SRTM.Logging.LogProviders;

[ExcludeFromCodeCoverage]
internal class SerilogLogProvider : LogProviderBase
{
	[ExcludeFromCodeCoverage]
	internal class SerilogLogger
	{
		private readonly object object_0;

		private static readonly object object_1;

		private static readonly object object_2;

		private static readonly object object_3;

		private static readonly object object_4;

		private static readonly object object_5;

		private static readonly object object_6;

		private static readonly Func<object, object, bool> IsEnabled;

		private static readonly Action<object, object, string, object[]> action_0;

		private static readonly Action<object, object, Exception, string, object[]> action_1;

		private static SerilogLogger serilogLogger_0;

		static SerilogLogger()
		{
			Class72.smethod_20();
			Type type = Type.GetType("Serilog.Events.LogEventLevel, Serilog");
			if (type == null)
			{
				throw new InvalidOperationException("Type Serilog.Events.LogEventLevel was not found.");
			}
			object_1 = Enum.Parse(type, "Debug", ignoreCase: false);
			object_2 = Enum.Parse(type, "Error", ignoreCase: false);
			object_3 = Enum.Parse(type, "Fatal", ignoreCase: false);
			object_4 = Enum.Parse(type, "Information", ignoreCase: false);
			object_5 = Enum.Parse(type, "Verbose", ignoreCase: false);
			object_6 = Enum.Parse(type, "Warning", ignoreCase: false);
			Type type2 = Type.GetType("Serilog.ILogger, Serilog");
			if (type2 == null)
			{
				throw new InvalidOperationException("Type Serilog.ILogger was not found.");
			}
			MethodInfo methodPortable = TypeExtensions.GetMethodPortable(type2, "IsEnabled", type);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(object));
			UnaryExpression instance = Expression.Convert(parameterExpression, type2);
			ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object));
			UnaryExpression unaryExpression = Expression.Convert(parameterExpression2, type);
			IsEnabled = Expression.Lambda<Func<object, object, bool>>(Expression.Call(instance, methodPortable, unaryExpression), new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
			MethodInfo methodPortable2 = TypeExtensions.GetMethodPortable(type2, "Write", type, typeof(string), typeof(object[]));
			ParameterExpression parameterExpression3 = Expression.Parameter(typeof(string));
			ParameterExpression parameterExpression4 = Expression.Parameter(typeof(object[]));
			action_0 = Expression.Lambda<Action<object, object, string, object[]>>(Expression.Call(instance, methodPortable2, unaryExpression, parameterExpression3, parameterExpression4), new ParameterExpression[4] { parameterExpression, parameterExpression2, parameterExpression3, parameterExpression4 }).Compile();
			MethodInfo methodPortable3 = TypeExtensions.GetMethodPortable(type2, "Write", type, typeof(Exception), typeof(string), typeof(object[]));
			ParameterExpression parameterExpression5 = Expression.Parameter(typeof(Exception));
			action_1 = Expression.Lambda<Action<object, object, Exception, string, object[]>>(Expression.Call(instance, methodPortable3, unaryExpression, parameterExpression5, parameterExpression3, parameterExpression4), new ParameterExpression[5] { parameterExpression, parameterExpression2, parameterExpression5, parameterExpression3, parameterExpression4 }).Compile();
		}

		internal SerilogLogger(object logger)
		{
		}

		public bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception, params object[] formatParameters)
		{
			return true;
		}

		private void method_0(object object_7, Func<string> func_0, object[] object_8)
		{
		}

		private void method_1(object object_7, Func<string> func_0, Exception exception_0, object[] object_8)
		{
		}

		private static object smethod_0(LogLevel logLevel_0)
		{
			return null;
		}

		internal static bool smethod_1()
		{
			return true;
		}

		internal static SerilogLogger smethod_2()
		{
			return null;
		}
	}

	private readonly Func<string, object> IqmyobEtrgK;

	private static bool bool_0;

	private static Func<string, object, bool, IDisposable> func_0;

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

	public SerilogLogProvider()
	{
		if (!IsLoggerAvailable())
		{
			throw new InvalidOperationException("Serilog.Log not found");
		}
		IqmyobEtrgK = smethod_2();
		func_0 = smethod_0();
	}

	public override Logger GetLogger(string name)
	{
		return new SerilogLogger(IqmyobEtrgK(name)).Log;
	}

	internal static bool IsLoggerAvailable()
	{
		if (!bool_0)
		{
			return false;
		}
		return smethod_1() != null;
	}

	protected override OpenNdc GetOpenNdcMethod()
	{
		return (string message) => func_0("NDC", message, arg3: false);
	}

	protected override OpenMdc GetOpenMdcMethod()
	{
		return (string key, object value, bool destructure) => func_0(key, value, destructure);
	}

	private static Func<string, object, bool, IDisposable> smethod_0()
	{
		MethodInfo methodPortable = TypeExtensions.GetMethodPortable(Type.GetType("Serilog.Context.LogContext, Serilog") ?? Type.GetType("Serilog.Context.LogContext, Serilog.FullNetFx"), "PushProperty", typeof(string), typeof(object), typeof(bool));
		ParameterExpression parameterExpression = Expression.Parameter(typeof(string), "name");
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object), "value");
		ParameterExpression parameterExpression3 = Expression.Parameter(typeof(bool), "destructureObjects");
		MethodCallExpression body = Expression.Call(null, methodPortable, parameterExpression, parameterExpression2, parameterExpression3);
		Func<string, object, bool, IDisposable> func_0 = Expression.Lambda<Func<string, object, bool, IDisposable>>(body, new ParameterExpression[3] { parameterExpression, parameterExpression2, parameterExpression3 }).Compile();
		return (string key, object value, bool destructure) => func_0(key, value, destructure);
	}

	private static Type smethod_1()
	{
		return Type.GetType("Serilog.Log, Serilog");
	}

	private static Func<string, object> smethod_2()
	{
		MethodInfo methodPortable = TypeExtensions.GetMethodPortable(smethod_1(), "ForContext", typeof(string), typeof(object), typeof(bool));
		ParameterExpression parameterExpression = Expression.Parameter(typeof(string), "propertyName");
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object), "value");
		ParameterExpression parameterExpression3 = Expression.Parameter(typeof(bool), "destructureObjects");
		MethodCallExpression body = Expression.Call(null, methodPortable, new Expression[3] { parameterExpression, parameterExpression2, parameterExpression3 });
		Func<string, object, bool, object> func_0 = Expression.Lambda<Func<string, object, bool, object>>(body, new ParameterExpression[3] { parameterExpression, parameterExpression2, parameterExpression3 }).Compile();
		return (string name) => func_0("SourceContext", name, arg3: false);
	}

	static SerilogLogProvider()
	{
		Class72.smethod_20();
		bool_0 = true;
	}
}
