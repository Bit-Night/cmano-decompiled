using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SRTM.Logging.LogProviders;

[ExcludeFromCodeCoverage]
internal class NLogLogProvider : LogProviderBase
{
	[ExcludeFromCodeCoverage]
	internal class NLogLogger
	{
		private readonly dynamic object_0;

		private static Func<string, object, string, Exception, object> func_0;

		private static readonly object object_1;

		private static readonly object object_2;

		private static readonly object object_3;

		private static readonly object object_4;

		private static readonly object object_5;

		private static readonly object ioUesIllhLY;

		static NLogLogger()
		{
			Class72.smethod_20();
			try
			{
				Type type = Type.GetType("NLog.LogLevel, NLog");
				if (type == null)
				{
					throw new InvalidOperationException("Type NLog.LogLevel was not found.");
				}
				List<FieldInfo> source = TypeExtensions.GetFieldsPortable(type).ToList();
				object_1 = source.First((FieldInfo x) => x.Name == "Trace").GetValue(null);
				object_2 = source.First((FieldInfo x) => x.Name == "Debug").GetValue(null);
				object_3 = source.First((FieldInfo x) => x.Name == "Info").GetValue(null);
				object_4 = source.First((FieldInfo x) => x.Name == "Warn").GetValue(null);
				object_5 = source.First((FieldInfo x) => x.Name == "Error").GetValue(null);
				ioUesIllhLY = source.First((FieldInfo x) => x.Name == "Fatal").GetValue(null);
				Type? type2 = Type.GetType("NLog.LogEventInfo, NLog");
				if (type2 == null)
				{
					throw new InvalidOperationException("Type NLog.LogEventInfo was not found.");
				}
				ConstructorInfo constructorPortable = TypeExtensions.GetConstructorPortable(type2, type, typeof(string), typeof(IFormatProvider), typeof(string), typeof(object[]), typeof(Exception));
				ParameterExpression parameterExpression = Expression.Parameter(typeof(string));
				ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object));
				ParameterExpression parameterExpression3 = Expression.Parameter(typeof(string));
				ParameterExpression parameterExpression4 = Expression.Parameter(typeof(Exception));
				UnaryExpression unaryExpression = Expression.Convert(parameterExpression2, type);
				func_0 = Expression.Lambda<Func<string, object, string, Exception, object>>(Expression.New(constructorPortable, unaryExpression, parameterExpression, Expression.Constant(null, typeof(IFormatProvider)), parameterExpression3, Expression.Constant(null, typeof(object[])), parameterExpression4), new ParameterExpression[4] { parameterExpression, parameterExpression2, parameterExpression3, parameterExpression4 }).Compile();
			}
			catch
			{
			}
		}

		internal NLogLogger(dynamic logger)
		{
			object_0 = logger;
		}

		public bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception, params object[] formatParameters)
		{
			if (messageFunc == null)
			{
				return method_1(logLevel);
			}
			Func<string> func = messageFunc;
			messageFunc = LogMessageFormatter.SimulateStructuredLogging(messageFunc, formatParameters);
			if (func_0 != null)
			{
				if (!method_1(logLevel))
				{
					return false;
				}
				Type typeFromHandle = typeof(NLogLogger);
				Type declaringType = func.Method.DeclaringType;
				if (!(declaringType == typeof(LogExtensions)) && (!(declaringType != null) || !(declaringType.DeclaringType == typeof(LogExtensions))))
				{
					if (declaringType == typeof(LoggerExecutionWrapper) || (declaringType != null && declaringType.DeclaringType == typeof(LoggerExecutionWrapper)))
					{
						typeFromHandle = typeof(LoggerExecutionWrapper);
					}
				}
				else
				{
					typeFromHandle = typeof(LogExtensions);
				}
				object obj = method_2(logLevel);
				dynamic val = func_0(object_0.Name, obj, messageFunc(), exception);
				object_0.Log(typeFromHandle, val);
				return true;
			}
			int result;
			if (exception == null)
			{
				switch (logLevel)
				{
				default:
					if (object_0.IsTraceEnabled)
					{
						object_0.Trace(messageFunc());
						return true;
					}
					goto IL_0732;
				case LogLevel.Debug:
					if (object_0.IsDebugEnabled)
					{
						object_0.Debug(messageFunc());
						return true;
					}
					goto IL_0732;
				case LogLevel.Info:
					if (object_0.IsInfoEnabled)
					{
						object_0.Info(messageFunc());
						return true;
					}
					result = 0;
					goto IL_07d2;
				case LogLevel.Warn:
					if (object_0.IsWarnEnabled)
					{
						object_0.Warn(messageFunc());
						return true;
					}
					goto IL_0732;
				case LogLevel.Error:
					if (object_0.IsErrorEnabled)
					{
						object_0.Error(messageFunc());
						return true;
					}
					goto IL_0732;
				case LogLevel.Fatal:
					{
						if (object_0.IsFatalEnabled)
						{
							object_0.Fatal(messageFunc());
							return true;
						}
						result = 0;
						goto IL_07d2;
					}
					IL_07d2:
					return (byte)result != 0;
					IL_0732:
					result = 0;
					goto IL_07d2;
				}
			}
			return method_0(logLevel, messageFunc, exception);
		}

		private bool method_0(LogLevel logLevel_0, Func<string> func_1, Exception exception_0)
		{
			int result;
			switch (logLevel_0)
			{
			default:
				if (object_0.IsTraceEnabled)
				{
					object_0.TraceException(func_1(), exception_0);
					return true;
				}
				goto IL_0673;
			case LogLevel.Debug:
				if (!(object_0.IsDebugEnabled ? true : false))
				{
					result = 0;
					break;
				}
				object_0.DebugException(func_1(), exception_0);
				return true;
			case LogLevel.Info:
				if (object_0.IsInfoEnabled)
				{
					object_0.InfoException(func_1(), exception_0);
					return true;
				}
				goto IL_0673;
			case LogLevel.Warn:
				if (!(object_0.IsWarnEnabled ? true : false))
				{
					result = 0;
					break;
				}
				object_0.WarnException(func_1(), exception_0);
				return true;
			case LogLevel.Error:
				if (object_0.IsErrorEnabled)
				{
					object_0.ErrorException(func_1(), exception_0);
					return true;
				}
				goto IL_0673;
			case LogLevel.Fatal:
				{
					if (object_0.IsFatalEnabled)
					{
						object_0.FatalException(func_1(), exception_0);
						return true;
					}
					goto IL_0673;
				}
				IL_0673:
				result = 0;
				break;
			}
			return (byte)result != 0;
		}

		private bool method_1(LogLevel logLevel_0)
		{
			return logLevel_0 switch
			{
				LogLevel.Debug => object_0.IsDebugEnabled, 
				LogLevel.Info => object_0.IsInfoEnabled, 
				LogLevel.Warn => object_0.IsWarnEnabled, 
				LogLevel.Error => object_0.IsErrorEnabled, 
				LogLevel.Fatal => object_0.IsFatalEnabled, 
				_ => object_0.IsTraceEnabled, 
			};
		}

		private object method_2(LogLevel logLevel_0)
		{
			return logLevel_0 switch
			{
				LogLevel.Trace => object_1, 
				LogLevel.Debug => object_2, 
				LogLevel.Info => object_3, 
				LogLevel.Warn => object_4, 
				LogLevel.Error => object_5, 
				LogLevel.Fatal => ioUesIllhLY, 
				_ => throw new ArgumentOutOfRangeException("logLevel", logLevel_0, null), 
			};
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public Action<string, string> gooesAfnxRj;

		public Action<string> action_0;

		internal IDisposable method_0(string key, object value, bool _)
		{
			<>c__DisplayClass9_1 <>c__DisplayClass9_ = new <>c__DisplayClass9_1
			{
				<>c__DisplayClass9_0_0 = this,
				string_0 = key
			};
			gooesAfnxRj(<>c__DisplayClass9_.string_0, value.ToString());
			return new DisposableAction(<>c__DisplayClass9_.OpgesJxipv8);
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

		internal void OpgesJxipv8()
		{
			<>c__DisplayClass9_0_0.action_0(string_0);
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

	public NLogLogProvider()
	{
		if (!IsLoggerAvailable())
		{
			throw new InvalidOperationException("NLog.LogManager not found");
		}
		func_0 = SrfyoigLrkZ();
	}

	public override Logger GetLogger(string name)
	{
		return new NLogLogger(func_0(name)).Log;
	}

	public static bool IsLoggerAvailable()
	{
		if (bool_0)
		{
			return smethod_0() != null;
		}
		return false;
	}

	protected override OpenNdc GetOpenNdcMethod()
	{
		MethodInfo methodPortable = TypeExtensions.GetMethodPortable(Type.GetType("NLog.NestedDiagnosticsContext, NLog"), "Push", typeof(string));
		ParameterExpression parameterExpression = Expression.Parameter(typeof(string), "message");
		return Expression.Lambda<OpenNdc>(Expression.Call(null, methodPortable, parameterExpression), new ParameterExpression[1] { parameterExpression }).Compile();
	}

	protected override OpenMdc GetOpenMdcMethod()
	{
		Type type = Type.GetType("NLog.MappedDiagnosticsContext, NLog");
		MethodInfo methodPortable = TypeExtensions.GetMethodPortable(type, "Set", typeof(string), typeof(string));
		MethodInfo methodPortable2 = TypeExtensions.GetMethodPortable(type, "Remove", typeof(string));
		ParameterExpression parameterExpression = Expression.Parameter(typeof(string), "key");
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(string), "value");
		MethodCallExpression body = Expression.Call(null, methodPortable, parameterExpression, parameterExpression2);
		MethodCallExpression body2 = Expression.Call(null, methodPortable2, parameterExpression);
		Action<string, string> gooesAfnxRj = Expression.Lambda<Action<string, string>>(body, new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
		Action<string> action_0 = Expression.Lambda<Action<string>>(body2, new ParameterExpression[1] { parameterExpression }).Compile();
		<>c__DisplayClass9_0 CS$<>8__locals0;
		return delegate(string key, object value, bool _)
		{
			<>c__DisplayClass9_1 <>c__DisplayClass9_ = new <>c__DisplayClass9_1();
			<>c__DisplayClass9_.<>c__DisplayClass9_0_0 = CS$<>8__locals0;
			<>c__DisplayClass9_.string_0 = key;
			gooesAfnxRj(<>c__DisplayClass9_.string_0, value.ToString());
			return new DisposableAction(<>c__DisplayClass9_.OpgesJxipv8);
		};
	}

	private static Type smethod_0()
	{
		return Type.GetType("NLog.LogManager, NLog");
	}

	private static Func<string, object> SrfyoigLrkZ()
	{
		MethodInfo methodPortable = TypeExtensions.GetMethodPortable(smethod_0(), "GetLogger", typeof(string));
		ParameterExpression parameterExpression = Expression.Parameter(typeof(string), "name");
		return Expression.Lambda<Func<string, object>>(Expression.Call(null, methodPortable, parameterExpression), new ParameterExpression[1] { parameterExpression }).Compile();
	}

	static NLogLogProvider()
	{
		Class72.smethod_20();
		bool_0 = true;
	}
}
