using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;

namespace SRTM.Logging.LogProviders;

[ExcludeFromCodeCoverage]
internal class EntLibLogProvider : LogProviderBase
{
	[ExcludeFromCodeCoverage]
	internal class EntLibLogger
	{
		private readonly string string_0;

		private readonly Action<string, string, int> action_0;

		private readonly Func<string, int, bool> lqZefaLgoFC;

		internal EntLibLogger(string loggerName, Action<string, string, int> writeLog, Func<string, int, bool> shouldLog)
		{
			string_0 = loggerName;
			action_0 = writeLog;
			lqZefaLgoFC = shouldLog;
		}

		public bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception, params object[] formatParameters)
		{
			int num = smethod_0(logLevel);
			if (messageFunc == null)
			{
				return lqZefaLgoFC(string_0, num);
			}
			messageFunc = LogMessageFormatter.SimulateStructuredLogging(messageFunc, formatParameters);
			if (exception != null)
			{
				return LogException(logLevel, messageFunc, exception);
			}
			action_0(string_0, messageFunc(), num);
			return true;
		}

		public bool LogException(LogLevel logLevel, Func<string> messageFunc, Exception exception)
		{
			int arg = smethod_0(logLevel);
			string arg2 = messageFunc() + Environment.NewLine + exception;
			action_0(string_0, arg2, arg);
			return true;
		}

		private static int smethod_0(LogLevel logLevel_0)
		{
			return logLevel_0 switch
			{
				LogLevel.Info => TraceEventTypeValues.Information, 
				LogLevel.Warn => TraceEventTypeValues.Warning, 
				LogLevel.Error => TraceEventTypeValues.Error, 
				LogLevel.Fatal => TraceEventTypeValues.Critical, 
				_ => TraceEventTypeValues.Verbose, 
			};
		}

		static EntLibLogger()
		{
			Class72.smethod_20();
		}
	}

	private static bool zaryohqwhMB;

	private static readonly Type type_0;

	private static readonly Type type_1;

	private static readonly Type type_2;

	private static readonly Action<string, string, int> UrZyoZtbvvZ;

	private static readonly Func<string, int, bool> func_0;

	public static bool ProviderIsAvailableOverride
	{
		get
		{
			return zaryohqwhMB;
		}
		set
		{
			zaryohqwhMB = value;
		}
	}

	static EntLibLogProvider()
	{
		Class72.smethod_20();
		zaryohqwhMB = true;
		type_0 = Type.GetType(string.Format(CultureInfo.InvariantCulture, "Microsoft.Practices.EnterpriseLibrary.Logging.{0}, Microsoft.Practices.EnterpriseLibrary.Logging", "LogEntry"));
		type_1 = Type.GetType(string.Format(CultureInfo.InvariantCulture, "Microsoft.Practices.EnterpriseLibrary.Logging.{0}, Microsoft.Practices.EnterpriseLibrary.Logging", "Logger"));
		type_2 = TraceEventTypeValues.Type;
		if (!(type_0 == null) && !(type_2 == null) && !(type_1 == null))
		{
			UrZyoZtbvvZ = smethod_0();
			func_0 = smethod_1();
		}
	}

	public EntLibLogProvider()
	{
		if (!IsLoggerAvailable())
		{
			throw new InvalidOperationException("Microsoft.Practices.EnterpriseLibrary.Logging.Logger not found");
		}
	}

	public override Logger GetLogger(string name)
	{
		return new EntLibLogger(name, UrZyoZtbvvZ, func_0).Log;
	}

	internal static bool IsLoggerAvailable()
	{
		int result;
		if (!zaryohqwhMB)
		{
			result = 0;
		}
		else
		{
			if (type_2 != null)
			{
				return type_0 != null;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	private static Action<string, string, int> smethod_0()
	{
		ParameterExpression parameterExpression = Expression.Parameter(typeof(string), "logName");
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(string), "message");
		ParameterExpression parameterExpression3 = Expression.Parameter(typeof(int), "severity");
		MemberInitExpression arg = smethod_2(parameterExpression2, Expression.Convert(parameterExpression3, type_2), parameterExpression);
		return Expression.Lambda<Action<string, string, int>>(Expression.Call(TypeExtensions.GetMethodPortable(type_1, "Write", type_0), arg), new ParameterExpression[3] { parameterExpression, parameterExpression2, parameterExpression3 }).Compile();
	}

	private static Func<string, int, bool> smethod_1()
	{
		ParameterExpression parameterExpression = Expression.Parameter(typeof(string), "logName");
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(int), "severity");
		MemberInitExpression arg = smethod_2(Expression.Constant("***dummy***"), Expression.Convert(parameterExpression2, type_2), parameterExpression);
		return Expression.Lambda<Func<string, int, bool>>(Expression.Call(TypeExtensions.GetMethodPortable(type_1, "ShouldLog", type_0), arg), new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
	}

	private static MemberInitExpression smethod_2(Expression expression_0, Expression expression_1, object object_0)
	{
		Type type = type_0;
		return Expression.MemberInit(Expression.New(type), Expression.Bind(TypeExtensions.GetPropertyPortable(type, "Message"), expression_0), Expression.Bind(TypeExtensions.GetPropertyPortable(type, "Severity"), expression_1), Expression.Bind(TypeExtensions.GetPropertyPortable(type, "TimeStamp"), Expression.Property(null, TypeExtensions.GetPropertyPortable(typeof(DateTime), "UtcNow"))), Expression.Bind(TypeExtensions.GetPropertyPortable(type, "Categories"), Expression.ListInit(Expression.New(typeof(List<string>)), TypeExtensions.GetMethodPortable(typeof(List<string>), "Add", typeof(string)), (Expression)object_0)));
	}
}
